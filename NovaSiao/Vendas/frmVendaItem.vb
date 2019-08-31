Imports CamadaDTO
Imports CamadaBLL
Imports System.ComponentModel
Imports System.Reflection
'
Public Class frmVendaItem
    '
    Private itemBLL As New TransacaoItemBLL
    Private _clItem As clTransacaoItem
    Private _acao As EnumFlagAcao
    Private _precoOrigem As EnumPrecoOrigem
    Private _formOrigem As Form
    Private _IDFilial As Integer?
    Private _descontoMaximo As Double
    Private BindItem As New BindingSource
    Private _RGAlterado As Boolean = False '--> detecta alteracao do RGProduto
    Private QuantAnterior As Integer '--> backup da quantidade original
    Private WithEvents BlinkTimer As New Timer
    '
#Region "NEW | PROPERTYS"
    '
    Sub New(fOrigem As Form, pOrigem As EnumPrecoOrigem, Filial As Integer, Item As clTransacaoItem)

        ' This call is required by the designer.
        InitializeComponent()
        ' 
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- Define se é entrada ou saida no caso de TROCA de produtos
        _precoOrigem = pOrigem '--- DEFINE SE É ENTRADA OU SAÍDA
        _formOrigem = fOrigem '--- DEFINE O FORMULARIO DE ORIGEM PARA RETORNAR
        _IDFilial = Filial
        '
        '--- get DescontoMaximo
        If Array.Exists(fOrigem.GetType().GetProperties(), Function(x) x.Name = "DescontoMaximo") Then
            _descontoMaximo = fOrigem.GetType().GetProperties().First(Function(x) x.Name = "DescontoMaximo").GetValue(fOrigem)
        End If
        '
        '--- DEFINE E PREECHE A CLASSE
        _clItem = Item
        BindItem.DataSource = _clItem
        PreencheDataBindings()
        '
        If IsNothing(Item.IDTransacaoItem) Then '--- DEFINE SE É NOVA OU ALTERAÇÃO
            propAcao = EnumFlagAcao.INSERIR
        Else
            propAcao = EnumFlagAcao.EDITAR
            QuantAnterior = Item.Quantidade
            ObtemEstoque()
        End If
        '
        '--- evento que detecta alteracao do RGProduto
        _RGAlterado = False
        '
        '--- Alteracoes visuais
        BackColor = Color.Azure
        Panel1.BackColor = Color.SlateGray
        '
        If fOrigem.Name = "frmTrocaSimples" Then
            lblTitulo.Text = "Entrada de Produto - Item"
        End If
        '
    End Sub
    '
    '--- Propriedade propAcao
    Public Property propAcao() As EnumFlagAcao
        '
        Get
            Return _acao
        End Get
        '
        Set(ByVal value As EnumFlagAcao)
            _acao = value
            '
            If _acao = EnumFlagAcao.INSERIR Then
                btnOK.Text = "&Inserir"
                lblToolStripInfo.Text = "Inserindo Novo Item"
            ElseIf _acao = EnumFlagAcao.EDITAR Then
                btnOK.Text = "&Alterar"
                lblToolStripInfo.Text = "Editando Item"
            End If
            '
        End Set
        '
    End Property
    '
#End Region
    '
#Region "DATA BINDINGS"
    '
    Private Sub PreencheDataBindings()
        '
        '--- PREENCHE OS DATABINDGS DOS CONTROLES
        '
        txtRGProduto.DataBindings.Add("Text", BindItem, "RGProduto", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDesconto.DataBindings.Add("Text", BindItem, "Desconto", True, DataSourceUpdateMode.OnPropertyChanged)
        txtQuantidade.DataBindings.Add("Text", BindItem, "Quantidade", True, DataSourceUpdateMode.OnPropertyChanged)
        lblProduto.DataBindings.Add("Text", BindItem, "Produto", True, DataSourceUpdateMode.OnPropertyChanged)
        lblEstoque.DataBindings.Add("Text", BindItem, "Estoque", True, DataSourceUpdateMode.OnPropertyChanged)
        lblReservado.DataBindings.Add("Text", BindItem, "Reservado", True, DataSourceUpdateMode.OnPropertyChanged)
        lblPreco.DataBindings.Add("Text", BindItem, "Preco", True, DataSourceUpdateMode.OnPropertyChanged)
        lblSubTotal.DataBindings.Add("Text", BindItem, "SubTotal")
        lblTotal.DataBindings.Add("Text", BindItem, "Total")
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtRGProduto.DataBindings("text").Format, AddressOf idFormatRG
        AddHandler txtQuantidade.DataBindings("text").Format, AddressOf idFormatQ2
        AddHandler lblPreco.DataBindings("text").Format, AddressOf idFormatCUR
        AddHandler txtDesconto.DataBindings("text").Format, AddressOf idFormatPerc
        AddHandler lblSubTotal.DataBindings("text").Format, AddressOf idFormatCUR
        AddHandler lblTotal.DataBindings("text").Format, AddressOf idFormatCUR
        AddHandler lblEstoque.DataBindings("text").Format, AddressOf idFormatQ2
        AddHandler lblReservado.DataBindings("text").Format, AddressOf idFormatQ2
        '
        '--- Detecta quando o IDProduto foi alterado
        AddHandler _clItem.AoAlterarRGProduto, AddressOf RGProdutoAlterado
        '
    End Sub
    '
    '--- DETECTA QUANDO O IDPRODUTO FOI ALTERADO
    Private Sub RGProdutoAlterado()
        _RGAlterado = True
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    Private Sub idFormatQ2(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "00")
    End Sub
    Private Sub idFormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    Private Sub idFormatPerc(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0.00")
    End Sub
    '
#End Region
    '
#Region "VALIDA RGPRODUTO OU COD BARRAS"
    '
    '--- VALIDA O TEXTO DO RGPRODUTO E ACIONA O ObterProdutoPeloRG OU CODBARRAS
    Private Sub txtRGProduto_Validating(sender As Object, e As CancelEventArgs) Handles txtRGProduto.Validating
        '
        '-- Verifica se o controle RGProduto sofreu alguma alteracao
        If Not _RGAlterado Then Exit Sub
        '
        If ObterProdutoPeloRG() = False Then e.Cancel = True
        '
    End Sub
    '
    '--- OBTEM AS INFORMACOES DO PRODUTO APOS INSERIR RGPRODUTO
    Private Function ObterProdutoPeloRG() As Boolean
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim ItemProduto As clTransacaoItem = itemBLL.TransacaoItem_Get_New(txtRGProduto.Text, _IDFilial)
            '
            If String.IsNullOrEmpty(ItemProduto.Produto) Then
                MessageBox.Show("Registro de Produto não encontrado..." & vbNewLine &
                                "Favor digitar um Registro válido.", "Reg. Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '
                BindItem.CancelEdit()
                Return False
                '
            End If
            '
            '--- Preenche a classe clItem
            With _clItem
                .Produto = ItemProduto.Produto
                .PVenda = ItemProduto.PVenda
                .PCompra = ItemProduto.PCompra
                .IDProduto = ItemProduto.IDProduto
                .CodBarrasA = ItemProduto.CodBarrasA
                .ProdutoAtivo = ItemProduto.ProdutoAtivo
                .Estoque = ItemProduto.Estoque
                .Reservado = ItemProduto.Reservado
                .IDFilial = ItemProduto.IDFilial
                .RGProduto = ItemProduto.RGProduto
                '
                '--- define o preco de VENDA OU DE COMPRA
                If _precoOrigem = EnumPrecoOrigem.PRECO_VENDA Then
                    .Preco = ItemProduto.PVenda
                ElseIf _precoOrigem = EnumPrecoOrigem.PRECO_COMPRA Then
                    .Preco = ItemProduto.PCompra
                    .Desconto = ItemProduto.DescontoCompra
                End If
                '
            End With
            '
            '--- destaca o estoque caso zero ou negativo
            If _clItem.Estoque <= 0 Then
                BlinkTimer.Enabled = True
            Else
                lblEstoque.BackColor = SystemColors.InactiveBorder
            End If
            '
            BindItem.ResetBindings(True)
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter o produto no BD..." & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
    '--- OBTEM O ESTOQUE DO PRODUTO QUANDO AO EDITAR    
    Private Sub ObtemEstoque()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim dt As DataTable = itemBLL.Item_GetEstoque(_clItem.IDProduto, _IDFilial)
            '
            If IsNumeric(dt.Rows(0)(0)) Then
                _clItem.Estoque = dt.Rows(0)(0)
                _clItem.Reservado = dt.Rows(0)(1)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter o estoque do produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '/ VALIDA RGPRODUTO
    '
#Region "FUNCOES NECESSARIAS"
    '
    ' CONTROLA O KEYPRESS DO RGPRODUTO
    Private Sub txtRGProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGProduto.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        ElseIf e.KeyChar = "+" Then
            e.Handled = True
            '
            '--- abre o form de Procura de Produto
            Dim p As New frmProdutoProcurar(Me, True)
            p.ShowDialog()
            '
            '--- verifica se retornou algum valor
            If p.DialogResult = vbCancel Then Exit Sub
            '
            '--- se retornou entao preenche o RGProduto
            txtRGProduto.Text = p.ProdutoEscolhido.RGProduto
            SendKeys.Send("{TAB}")
            '
        Else
            e.Handled = True
        End If
    End Sub
    '    
    ' CONTROLA O KEYPRESS DO DESCONTO
    Private Sub txtDesconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesconto.KeyPress
        '
        If Char.IsNumber(e.KeyChar) OrElse New Char() {vbBack, ",", "."}.Contains(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "+" Then
            e.Handled = True
            '
            '--- abre o form de Procura de Produto
            Dim fDesc As New frmProdutoValorDesconto(_clItem.PVenda * _clItem.Quantidade, _clItem.Desconto, Me)
            fDesc.ShowDialog()
            '
            '--- verifica se retornou algum valor
            If fDesc.DialogResult = vbCancel Then Exit Sub
            '
            '--- se retornou entao preenche o desconto ou aumenta o valor
            _clItem.Desconto = fDesc.propDesconto
            _clItem.Preco = Math.Round(fDesc.propValor / If(_clItem.Quantidade = 0, 1, _clItem.Quantidade), 4)
            '
            txtDesconto.DataBindings("text").ReadValue()
            lblPreco.DataBindings("text").ReadValue()
            lblSubTotal.DataBindings("text").ReadValue()
            lblTotal.DataBindings("text").ReadValue()
            '
        Else
            e.Handled = True
        End If
    End Sub
    '
    ' AO RECEBER O FOCO SELECIONA O TEXTO
    Private Sub Text_GotFocus(sender As Object, e As EventArgs) Handles txtRGProduto.GotFocus,
            txtDesconto.GotFocus, txtQuantidade.GotFocus
        If CType(sender, TextBox).Text.Length > 0 Then sender.SelectAll()
    End Sub
    '
    ' AO PRESSIONAR ENTER ENVIA TAB NAVEGA ENTRE CONTROLES
    Private Sub txtRGProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRGProduto.KeyDown,
        txtQuantidade.KeyDown, txtDesconto.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '--- VERIFICA SE OS VALORES ESTÃO PREENCHIDOS
        If Not VerificaValores() Then Return
        '
        '--- VERIFICA ESTOQUE
        If Not VerificaEstoque() Then Return
        '
        '--- RETORNA O OBJETO PARA O FORMULARIO ORIGEM
        _clItem.EndEdit()
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        BindItem.CancelEdit()
        DialogResult = DialogResult.Cancel
    End Sub
    '
    '--- REALIZA O PREENCHIMENTO CORRETO DOS CAMPOS
    Private Function VerificaValores() As Boolean
        Dim f As New Utilidades
        '
        If Not f.VerificaDadosClasse(txtRGProduto, "Reg. do Produto", _clItem) Then
            Return False
        End If
        '
        If IsNothing(_clItem.Produto) OrElse String.IsNullOrEmpty(_clItem.Produto) Then
            MessageBox.Show("O produto ainda não foi especificado...",
                            "Produto Incompleto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            txtRGProduto.Focus()
            Return False
        End If
        '
        If _clItem.Quantidade <= 0 Then
            MessageBox.Show("Necessário especificar a quantidade MAIOR que Zero...",
                            "Produto Quantidade",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            txtQuantidade.Focus()
            Return False
        End If
        '
        If _clItem.Desconto < 0 Then
            MessageBox.Show("O DESCONTO não pode ser MENOR que Zero...",
                            "Produto Desconto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            txtDesconto.Focus()
            Return False
        End If
        '
        If _descontoMaximo > 0 AndAlso _clItem.Desconto > _descontoMaximo Then
            '
            If AbrirDialog("O DESCONTO não pode ser maior que " & Format(_descontoMaximo, "#,##.00") & "%" &
                            vbNewLine &
                            "Deseja solicitar autorização?",
                            "Desconto Máximo",
                            frmDialog.DialogType.SIM_NAO,
                            frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                '
                If GetAuthorization(EnumAcessoTipo.UsuarioSenior, "Desconto Máximo", Me) Then
                    Return True
                Else
                    txtDesconto.Focus()
                    Return False
                End If
                '
            Else
                txtDesconto.Focus()
                Return False
            End If
            '
        End If
        '
        Return True
        '
    End Function
    '
    '--- REALIZA A VERIFICACAO DE ESTOQUE NEGATIVO
    Private Function VerificaEstoque() As Boolean
        '
        '--- verifica CONFIG se estoque negativo permitido
        '---------------------------------------------------------------
        Dim ver As String = ObterDefault("EstoqueNegativo")
        If String.IsNullOrEmpty(ver) Then ver = "FALSE"
        '
        '--- se for TRUE entao nao verifica
        If CBool(ver) Then Return True
        '
        '--- write binding quantidade
        txtQuantidade.DataBindings.Item("text").WriteValue()
        '
        '--- verifica se existe estoque obtido no BD
        If IsNothing(_clItem.Estoque) Then Return True
        '
        '--- VERIFICACAO DE ESTOQUE
        '---------------------------------------------------------------------
        If _acao = EnumFlagAcao.INSERIR Then
            '
            If _clItem.Estoque <= 0 Then '--- se o estoque É igual a ZERO ou NEGATIVO
                '
                MessageBox.Show("Não existe quantidade em estoque desse produto...",
                                "Estoque Nulo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '
                BlinkTimer.Enabled = True
                txtQuantidade.Focus()
                txtQuantidade.SelectAll()
                Return False
                '
            ElseIf _clItem.Estoque - _clItem.Quantidade < 0 Then '--- se o estoque FICAR NEGATIVO
                '
                MessageBox.Show("Essa quantidade fará com que o estoque fique NEGATIVO..." &
                                vbNewLine & vbNewLine &
                                "Favor Inserir uma quantidade igual ou menor que: " &
                                Format(_clItem.Estoque, "00"),
                                "Estoque Negativo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '
                BlinkTimer.Enabled = True
                txtQuantidade.Focus()
                txtQuantidade.SelectAll()
                Return False
                '
            End If
            '
        ElseIf _acao = EnumFlagAcao.EDITAR Then
            '
            '--- no caso de NAO ALTERACAO do produto
            If Not _RGAlterado Then
                '
                Dim estAnterior As Integer = _clItem.Estoque + QuantAnterior
                '
                If estAnterior - _clItem.Estoque < 0 Then
                    '
                    MessageBox.Show("Essa quantidade fará com que o estoque fique NEGATIVO..." &
                                    vbNewLine & vbNewLine &
                                    "Favor Inserir uma quantidade igual ou menor que: " &
                                    Format(estAnterior, "00"),
                                    "Estoque Negativo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '
                    txtQuantidade.Focus()
                    txtQuantidade.SelectAll()
                    Return False
                    '
                End If
                '
            Else '--- no caso de produto ALTERADO
                '
                If _clItem.Estoque <= 0 Then '--- se o estoque É igual a ZERO ou NEGATIVO
                    '
                    MessageBox.Show("Não existe quantidade em estoque desse produto...",
                                    "Estoque Nulo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '
                    txtQuantidade.Focus()
                    txtQuantidade.SelectAll()
                    Return False
                    '
                ElseIf _clItem.Estoque - _clItem.Quantidade < 0 Then
                    '
                    MessageBox.Show("Essa quantidade fará com que o estoque fique NEGATIVO..." &
                                    vbNewLine & vbNewLine &
                                    "Favor Inserir uma quantidade igual ou menor que: " &
                                    Format(_clItem.Estoque, "00"),
                                    "Estoque Negativo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '
                    txtQuantidade.Focus()
                    txtQuantidade.SelectAll()
                    Return False
                    '
                End If
                '
            End If
            '
        End If
        '
        Return True
        '
    End Function
    '
#End Region
    '
#Region "DESIGN VISUAL"
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.SlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    Private Sub frmTransacaoItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub form_closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' EFEITO VISUAL CONTROLE PISCANDO
    '-------------------------------------------------------------------------------------------------
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles BlinkTimer.Tick
        '
        '--- permuta a cor
        If lblEstoque.BackColor = Color.Gold Then
            lblEstoque.BackColor = SystemColors.InactiveBorder
        Else
            lblEstoque.BackColor = Color.Gold
        End If
        '
        '--- add contagem
        If IsNothing(BlinkTimer.Tag) Then BlinkTimer.Tag = 0
        BlinkTimer.Tag += 1
        '
        '--- verifica a contagem e desabilita o timer
        If lblEstoque.BackColor = Color.Gold And BlinkTimer.Tag > 10 Then
            BlinkTimer.Tag = 0
            BlinkTimer.Enabled = False
        End If
        '
    End Sub

#End Region
    '
End Class
