Imports CamadaDTO
Imports CamadaBLL
Imports System.ComponentModel
'
Public Class frmCompraItem
    '
    Private itemBLL As New TransacaoItemBLL
    Private _clItem As clTransacaoItem
    Private _acao As EnumFlagAcao
    Private _precoOrigem As EnumPrecoOrigem
    Private _formOrigem As Form
    Private _IDFilial As Integer?
    Private BindItem As New BindingSource
    Private _RGAlterado As Boolean = False '--> detecta alteracao do RGProduto
    Private QuantAnterior As Integer '--> backup da quantidade original
    '
#Region "NEW | PROPERTYS"
    '
    Sub New(fOrigem As Form, pOrigem As EnumPrecoOrigem, Filial As Integer, Item As clTransacaoItem)
        '
        ' This call is required by the designer.
        InitializeComponent()
        ' 
        ' Add any initialization after the InitializeComponent() call.
        _precoOrigem = pOrigem '--- DEFINE SE É ENTRADA OU SAÍDA PARA OBTER O PREÇO CORRETO
        _formOrigem = fOrigem '--- DEFINE O FORMULARIO DE ORIGEM PARA RETORNAR
        _IDFilial = Filial
        '
        '--- Define o BINDING
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
        '--- posiciona o form pelo FORMORIGEM
        Dim pos As Point = fOrigem.PointToScreen(Point.Empty)
        pos = New Point(pos.X + 10, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        '
        StartPosition = FormStartPosition.Manual
        Location = pos
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
                lblToolStripInfo.Text = "Inserindo Novo Item - Para cadastrar NOVO Produto pressione tecla N"
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
#Region "BINDINGS"
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
        txtMVA.DataBindings.Add("Text", BindItem, "MVA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtST.DataBindings.Add("Text", BindItem, "Substituicao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtICMS.DataBindings.Add("Text", BindItem, "ICMS", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIPI.DataBindings.Add("Text", BindItem, "IPI", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtRGProduto.DataBindings("text").Format, AddressOf idFormatRG
        AddHandler txtQuantidade.DataBindings("text").Format, AddressOf idFormatQ2
        AddHandler lblPreco.DataBindings("text").Format, AddressOf idFormatCUR
        AddHandler txtDesconto.DataBindings("text").Format, AddressOf idFormatPerc
        AddHandler txtMVA.DataBindings("text").Format, AddressOf idFormatPerc
        AddHandler txtICMS.DataBindings("text").Format, AddressOf idFormatPerc
        AddHandler txtIPI.DataBindings("text").Format, AddressOf idFormatPerc
        AddHandler txtST.DataBindings("text").Format, AddressOf idFormatCUR
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
        '--- obter as informacoes do produto digitado
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
                    .Substituicao = 0
                    .IPI = 0
                    .ICMS = 0
                    .MVA = 0
                End If
                '
            End With
            '
            BindItem.ResetBindings(True)
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu ao obter iformações do produto no BD..." & vbNewLine &
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
#End Region '/ VALIDA PRODUTO
    '
#Region "OUTRAS FUNCOES"
    '
    '--- SOMENTE PERMITE NUMEROS NO TEXTBOX
    Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGProduto.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- SELECIONA TODO O TEXTO DO TEXTBOX QUANDO RECEBE O FOCUS
    Private Sub Text_GotFocus(sender As Object, e As EventArgs) Handles txtRGProduto.GotFocus,
            txtDesconto.GotFocus, txtQuantidade.GotFocus, txtMVA.GotFocus, txtIPI.GotFocus, txtICMS.GotFocus, txtST.GotFocus
        If CType(sender, TextBox).Text.Length > 0 Then sender.SelectAll()
    End Sub
    '
    '--- QUANDO PRESSIONA ENTER ALTERNA ENTRE OS CONTROLES ENVIA TAB
    Private Sub txtRGProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRGProduto.KeyDown,
        txtQuantidade.KeyDown, txtDesconto.KeyDown, txtMVA.KeyDown, txtST.KeyDown, txtICMS.KeyDown, txtIPI.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '
    '--- PRESS ESC TO CLOSE | PRESS ADD TO OPEN FIND FORM | PRESS N TO NEW PRODUTO
    '----------------------------------------------------------------------------------
    Private Sub frmCompraItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        ElseIf e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            '--- verifica qual controle esta selecionado
            If ActiveControl Is txtRGProduto Then '--- RGProduto
                Dim p As New frmProdutoProcurar(Me, False)
                '
                p.ShowDialog()
                '
                If p.DialogResult = DialogResult.OK Then
                    txtRGProduto.Text = p.RGEscolhido
                    SendKeys.Send("{Tab}")
                End If
                '
            ElseIf ActiveControl Is txtDesconto Then '--- txtDesconto
                '
                '--- abre o form de Procura de Produto
                Dim fDesc As New frmProdutoValorDesconto(_clItem.PVenda * _clItem.Quantidade, _clItem.Desconto, Me)
                fDesc.ShowDialog()
                '
                '--- verifica se retornou algum valor
                If fDesc.DialogResult = vbCancel Then Exit Sub
                '
                '--- se retornou entao preenche o desconto ou aumenta o valor
                Dim precoAumentou As Boolean = fDesc.propValor > _clItem.Preco

                _clItem.Desconto = fDesc.propDesconto
                _clItem.Preco = Math.Round(fDesc.propValor / If(_clItem.Quantidade = 0, 1, _clItem.Quantidade), 4)
                '
                txtDesconto.DataBindings("text").ReadValue()
                lblPreco.DataBindings("text").ReadValue()
                lblSubTotal.DataBindings("text").ReadValue()
                lblTotal.DataBindings("text").ReadValue()
                '
                abrirDialog()
                '
            End If
            '
        ElseIf e.KeyCode = Keys.N AndAlso _acao = EnumFlagAcao.INSERIR Then
            e.Handled = True
            '
            Dim prod As New clProduto
            Dim f As New frmProduto(EnumFlagAcao.INSERIR, prod, Me)
            '
            f.ShowDialog()
            '
            If f.DialogResult = DialogResult.OK Then
                txtRGProduto.Text = f.RGEscolhido
                SendKeys.Send("{Tab}")
            End If
            '
        End If
        '
    End Sub
    '
#End Region '/ OUTRAS FUNCOES
    '
#Region "BUTONS FUNCTION"
    '
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
        Close()
    End Sub
    '
    '--- REALIZA O PREENCHIMENTO CORRETO DOS CAMPOS
    Private Function VerificaValores() As Boolean
        Dim f As New FuncoesUtilitarias
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
            '--- MOVIMENTO DE ENTRADA NO ESTOQUE
            '
        ElseIf _acao = EnumFlagAcao.EDITAR Then
            '
            '--- no caso de NAO ALTERACAO do produto
            '----------------------------------------------------
            If Not _RGAlterado Then
                '
                Dim estAnterior As Integer = _clItem.Estoque - QuantAnterior
                '
                If estAnterior + _clItem.Estoque < 0 Then
                    '
                    MessageBox.Show("Essa quantidade fará com que o estoque fique NEGATIVO..." &
                                    vbNewLine & vbNewLine &
                                    "Favor Inserir uma quantidade igual ou maior que: " &
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
                '--- MOVIMENTO DE ENTRADA NO ESTOQUE
                '
            End If
            '
        End If
        '
        Return True
        '
    End Function
    '
#End Region '/ BUTONS FUNCTION
    '
#Region "EFEITOS VISUAIS"
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
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub Me_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class
