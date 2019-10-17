Imports System.ComponentModel
Imports CamadaBLL
Imports CamadaDTO
Imports System.Math
Imports System.IO

Public Class frmProduto
    '
    Private prodBLL As New ProdutoBLL
    Private _produto As clProduto
    Private WithEvents bindP As New BindingSource
    '
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _acao As EnumFlagAcao
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
    Private _formOrigem As Form
    Private _OldRGProduto As Integer? '--- control changes in value of RGProduto
    '
#Region "EVENTO LOAD E PROPRIEDADE SIT"
    '
    Public Sub New(myAcao As EnumFlagAcao, myProduto As clProduto,
                   Optional formOrigem As Form = Nothing,
                   Optional RGAntigo As Integer? = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        propProduto = myProduto
        propAcao = myAcao
        '
        If Not IsNothing(RGAntigo) Then
            _produto.RGProduto = RGAntigo
            txtRGProduto.DataBindings.Item("text").ReadValue()
            FindProdutoAntigoAndAddNew(RGAntigo)
        End If
        '
    End Sub
    '
    'PROPERTY SIT
    Private Property Sit As EnumFlagEstado
        '
        Get
            Return _Sit
        End Get
        '
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnNovoProduto.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False
                btnProcurar.Enabled = True
                btnFornecedores.Enabled = True
                lblIDProduto.Text = Format(_produto.IDProduto, "0000")
                CalcMargemDescontoLabel()
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovoProduto.Enabled = False
                btnExcluir.Enabled = True
                btnCancelar.Enabled = True
                btnProcurar.Enabled = False
                btnFornecedores.Enabled = False
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtRGProduto.Select()
                btnSalvar.Enabled = True
                btnNovoProduto.Enabled = False
                btnExcluir.Enabled = False
                btnProcurar.Enabled = False
                btnFornecedores.Enabled = False
                lblIDProduto.Text = "NOVO"
                AtivoButtonImage()
                If IsNothing(_formOrigem) Then '--- Não tem formulário de origem
                    btnCancelar.Enabled = True
                Else '--- Tem origem em outro processo
                    btnCancelar.Enabled = False
                End If
            End If
        End Set
    End Property
    '
    '--- Propriedade propClientePF
    Public Property propProduto() As clProduto
        '
        Get
            Return _produto
        End Get
        '
        Set(ByVal value As clProduto)

            _produto = value
            '
            If IsNothing(bindP.DataSource) Then
                bindP.DataSource = _produto
                PreencheDataBindings()
                '
                ' LER OS DADOS AGORA FORMATADOS
                txtPCompra.DataBindings("Text").ReadValue()
                txtRGProduto.DataBindings("Text").ReadValue()
                txtPVenda.DataBindings("Text").ReadValue()
                txtUnidade.DataBindings("Text").ReadValue()
                '
            Else
                bindP.Clear()
                bindP.DataSource = _produto
                bindP.ResetBindings(True)
                AddHandler _produto.AoAlterar, AddressOf HandlerAoAlterar
            End If
            '
        End Set
        '
    End Property
    '
    Public Property propAcao As EnumFlagAcao
        Get
            Return _acao
        End Get
        Set(value As EnumFlagAcao)
            _acao = value
            If value = EnumFlagAcao.INSERIR Then
                Sit = EnumFlagEstado.NovoRegistro
            ElseIf value = EnumFlagAcao.EDITAR Then
                Sit = EnumFlagEstado.RegistroSalvo
            End If
        End Set
    End Property
    '
    ' EVENTO LOAD
    Private Sub frmProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        addToolTipHandler()
        pnlCalculo.Location = New Point(466, 357)
        '
    End Sub
    '
#End Region '// EVENTO LOAD E PROPRIEDADE SIT
    '
#Region "BINDINGS"
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA

        lblIDProduto.DataBindings.Add("Tag", bindP, "IDProduto")
        txtRGProduto.DataBindings.Add("Text", bindP, "RGProduto", True, DataSourceUpdateMode.OnPropertyChanged)
        txtProduto.DataBindings.Add("Text", bindP, "Produto", True, DataSourceUpdateMode.OnPropertyChanged)

        txtProdutoTipo.DataBindings.Add("Text", bindP, "ProdutoTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtProdutoSubTipo.DataBindings.Add("Text", bindP, "ProdutoSubTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtProdutoCategoria.DataBindings.Add("Text", bindP, "ProdutoCategoria", True, DataSourceUpdateMode.OnPropertyChanged)

        txtAutor.DataBindings.Add("Text", bindP, "Autor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUnidade.DataBindings.Add("Text", bindP, "Unidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPCompra.DataBindings.Add("Text", bindP, "PCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescontoCompra.DataBindings.Add("Text", bindP, "DescontoCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPVenda.DataBindings.Add("Text", bindP, "PVenda", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNCM.DataBindings.Add("Text", bindP, "NCM", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCodBarrasA.DataBindings.Add("Text", bindP, "CodBarrasA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEstoqueIdeal.DataBindings.Add("Text", bindP, "EstoqueIdeal", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEstoqueNivel.DataBindings.Add("Text", bindP, "EstoqueNivel", True, DataSourceUpdateMode.OnPropertyChanged)
        txtFabricante.DataBindings.Add("Text", bindP, "Fabricante", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtPCompra.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler txtRGProduto.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler txtPVenda.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler txtUnidade.DataBindings("Text").Format, AddressOf FormataN2
        AddHandler txtEstoqueIdeal.DataBindings("Text").Format, AddressOf FormataN2
        AddHandler txtEstoqueNivel.DataBindings("Text").Format, AddressOf FormataN2
        AddHandler txtDescontoCompra.DataBindings("text").Format, AddressOf FormatPercent
        '
        ' CARREGA OS COMBOBOX
        CarregaComboSitTributaria()
        CarregaComboMovimento()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _produto.AoAlterar, AddressOf HandlerAoAlterar
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _produto.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    '
    Private Sub FormataN2(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "00")
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    Private Sub FormatPercent(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value / 100, "0.00%")
    End Sub
    '
    ' CARREGA OS COMBOBOX
    '--------------------------------------------------------------------------------------------------------
    '
    '--- COMBO SITUACAO TRIBUTARIA
    Private Sub CarregaComboSitTributaria()
        '
        Dim dtSituacao As DataTable
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            dtSituacao = prodBLL.GetSituacao()
            '
            With cmbSitTributaria
                .DataSource = dtSituacao
                .ValueMember = "CodSituacaoTributaria"
                .DisplayMember = "SituacaoTributaria"
                .DataBindings.Add("SelectedValue", bindP, "SitTributaria", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a lista de Situação Tributária..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- COMBO MOVIMENTO DE ESTOQUE
    Private Sub CarregaComboMovimento()
        '
        Dim dtMovimento As New DataTable
        '
        'Adiciona todas as possibilidades de movimento
        dtMovimento.Columns.Add("ID")
        dtMovimento.Columns.Add("Mov")
        '
        'For Each e As clProduto.EnumProdutoMovimento In System.Enum.GetValues(GetType(clProduto.EnumProdutoMovimento))
        '    dtMovimento.Rows.Add(New Object() {CByte(e), e.ToString})
        'Next

        dtMovimento.Rows.Add(New Object() {1, "Normal"})
        dtMovimento.Rows.Add(New Object() {2, "Sem Movimento"})
        dtMovimento.Rows.Add(New Object() {3, "Protegido"})
        dtMovimento.Rows.Add(New Object() {4, "Periódico"})
        '
        With cmbMovimento
            .DataSource = dtMovimento
            .ValueMember = "ID"
            .DisplayMember = "Mov"
            .DataBindings.Add("SelectedValue", bindP, "Movimento", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
#End Region '// BINDINGS
    '
#Region "SALVAR REGISTRO"
    ' SALVAR O REGISTRO
    '---------------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        'verifica os dados se os campos estão preechidos
        If VerificaDados() = False Then Exit Sub
        '
        ' procurar se já existe cliente com o mesmo RGPRODUTO
        If VerificaRGProduto() = False Then Exit Sub
        '
        ' verifica a filial padrão
        Dim myFilial As Integer? = Obter_FilialPadrao()
        If IsNothing(myFilial) Then Exit Sub
        '
        'define os dados da classe
        Dim NewProdID As Long
        '
        Try
            'Salva o Produto, mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
            If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
                NewProdID = prodBLL.SalvaNovoProduto_Procedure_ID(_produto, myFilial)
            ElseIf _Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
                _produto.UltAltera = Now.ToShortDateString
                NewProdID = prodBLL.AtualizaProduto_Procedure_ID(_produto, myFilial)
            End If
        Catch ex As Exception
            MessageBox.Show("Um erro ocorreu ao salvar o registro!" & vbCrLf &
                            ex.Message, "Erro ao Salvar Registro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Verifica se houve Retorno da Função de Salvar
        If NewProdID <> 0 Then
            '
            'Obtem o número de Registro do Novo Produto Cadastrado
            If _Sit = EnumFlagEstado.NovoRegistro Then
                _produto.IDProduto = NewProdID
                lblIDProduto.Tag = NewProdID
                lblIDProduto.Text = Format(NewProdID, "D4")
            End If

            If IsNothing(_formOrigem) Then '--- nesse caso mantém o formulário aberto depois de salvar
                'Altera a Situação
                Sit = EnumFlagEstado.RegistroSalvo
                bindP.CurrencyManager.EndCurrentEdit()

                'Mensagem
                MessageBox.Show("Registro Salvo com sucesso!", "Registro Salvo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else '--- nesse caso fecha o formulário depois de salvar e retorna o IDProduto
                '
                '--- Mensagem
                MessageBox.Show("Registro Salvo com sucesso!", "Registro Salvo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
                '--- fecha o formulario de cadastro
                DialogResult = DialogResult.OK
                Close()
                _formOrigem.Show()
                '
            End If
        Else
            MessageBox.Show("Registro NÃO pode ser salvo!", "Erro ao Salvar",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    '
    ' FAZER VERIFICAÇÃO ANTES DE SALVAR
    Private Function VerificaDados() As Boolean

        Dim f As New Utilidades
        '
        If Not f.VerificaControlesForm(txtProduto, "Descrição do Produto", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtRGProduto, "Registro do Produto", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtProdutoTipo, "Tipo do Produto", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtProdutoSubTipo, "Classificação do Produto", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(cmbSitTributaria, "Situação Tributária do Produto", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtPCompra, "Preço de Compra", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtPVenda, "Preço de Venda", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(cmbMovimento, "Movimento do Estoque", _produto, EProvider) Then
            Return False
        End If
        '
        '--- verifica precos de venda e de compra
        '---------------------------------------------------------------------------------------------
        If _produto.PVenda <= 0 OrElse _produto.PCompra <= 0 Then
            AbrirDialog("O Preço de Venda e/ou o Preço de Compra não podem ser igual ou menor que zero...",
                        "Preço de Venda", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            txtPCompra.Focus()
            Return False
        End If
        '
        If _produto.PVenda < _produto.PCompra Then
            AbrirDialog("O Preço de Venda não pode ser menor que o preço de compra...",
                        "Preço de Venda", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            txtPVenda.Focus()
            Return False
        End If
        '
        'Se nenhuma das condições acima forem verdadeira retorna TRUE
        EProvider.Clear()
        Return True
    End Function
    '
    Private Function VerificaRGProduto() As Boolean
        '
        '--- verifica se existe RGProduto
        If String.IsNullOrWhiteSpace(txtRGProduto.Text) Then
            Dim r As DialogResult
            r = MessageBox.Show("O campo Registro Interno do Produto está vazio..." & vbNewLine &
                                "Você deseja que o sistema preencha automaticamente o valor desse campo?",
                                "Campo Vazio", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3)
            If r = DialogResult.Yes Then
                '
                ' Procura o valor para o campo
                btnProcuraRG_Click(New Object, New EventArgs)
                '
                '--- verifica novamente se o campo foi automaticamente preenchido
                If IsNothing(_produto.RGProduto) OrElse _produto.RGProduto = 0 Then
                    Return False
                Else
                    Return True
                End If
                '
            ElseIf r = DialogResult.No Then
                txtRGProduto.Focus()
                Return False
            End If
        End If
        '
        Dim ProdRG As clProduto = Nothing
        '
        ProdRG = ProcurarProduto_RG(txtRGProduto.Text)
        '
        If Not IsNothing(ProdRG) Then
            AbrirDialog("Já foi encontrado um Produto com esse mesmo número de Reg. Interno..." & vbNewLine &
                        ProdRG.Produto.ToUpper & vbNewLine &
                        "Insira outro Reg. Interno ou altere o registro do outro Produto.",
                        "Reg. Interno Duplicado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            txtRGProduto.Focus()
            Return False
        Else
            Return True
        End If

    End Function
    '---------------------------------------------------------------------------------------------------
#End Region '// SALVAR REGISTRO
    '
#Region "OPERAÇÕES DE REGISTRO"
    '
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            'Abre o formulário de procurar Produto
            Dim frmP As New frmProdutoProcurar()
            frmP.ShowDialog()
            '
            If frmP.DialogResult = DialogResult.Cancel Then
                MessageBox.Show("Procura Cancelada...", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim pReg As Integer = frmP.ProdutoEscolhido.IDProduto
                propProduto = prodBLL.GetProduto_PorID(pReg, Obter_FilialPadrao)
                '
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir a janela de procura do produto..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '------------------------------------------------------------------------------------------------
    '
    ' CANCELAR ALTERAÇÃO DO REGISTRO ATUAL
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If MessageBox.Show("Deseja cancelar todas as alterações feitas no registro atual?",
                           "Cancelar Alterações", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Return
        End If
        '
        bindP.CancelEdit()
        '
        If Not IsNothing(DirectCast(bindP.Current, clProduto).IDProduto) Then
            txtProduto.Focus()
            Sit = EnumFlagEstado.RegistroSalvo
        Else
            btnFechar_Click(sender, e)
        End If
        '
    End Sub
    '
    ' ATIVAR OU DESATIVAR PRODUTO BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR um Produto Novo", "Desativar Produto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        If _produto.ProdutoAtivo = True Then ' Produto esta ativo
            If MessageBox.Show("Você deseja realmente DESATIVAR o Produto:" & vbNewLine &
                        txtProduto.Text.ToUpper, "Desativar Produto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _produto.BeginEdit()
                _produto.ProdutoAtivo = False
                AtivoButtonImage()
            End If
        ElseIf _produto.ProdutoAtivo = False Then ' Produto esta Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR o Produto:" & vbNewLine &
            txtProduto.Text.ToUpper, "Ativar Produto", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _produto.BeginEdit()
                _produto.ProdutoAtivo = True
                AtivoButtonImage()
            End If
        End If
        '
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        If _produto.ProdutoAtivo = True Then ' Nesse caso é Produto Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Produto Ativo"
        ElseIf _produto.ProdutoAtivo = False Then ' Nesse caso é Produto Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Produto Inativo"
        End If
    End Sub
    '
    ' FECHA O FORMULÁRIO
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        AutoValidate = AutoValidate.Disable
        '
        If IsNothing(_formOrigem) Then
            Close()
            MostraMenuPrincipal()
        Else
            DialogResult = DialogResult.Cancel
            Close()
            _formOrigem.Visible = True
        End If
        '
    End Sub
    '
    ' BOTÃO NOVO REGISTRO
    Private Sub btnNovoProduto_Click(sender As Object, e As EventArgs) Handles btnNovoProduto.Click
        propProduto = New clProduto
        propAcao = EnumFlagAcao.INSERIR
    End Sub
    '
#End Region '// OPERAÇÕES DE REGISTRO
    '
#Region "OUTRAS FUNÇÕES"
    '
    ' PROCURAR PRODUTO COM O MESMO RGProduto
    '--------------------------------------------------------------------------------------------------
    Private Function ProcurarProduto_RG(myRGProduto As Integer) As clProduto
        Dim lista As New List(Of clProduto)
        '
        ' VERIFICA A CONEXÃO COM O SQL
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '
            If Sit = EnumFlagEstado.NovoRegistro Then ' nesse caso é um novo registro
                lista = prodBLL.GetProdutos_Where("RGProduto = " & myRGProduto)
            ElseIf Sit = EnumFlagEstado.RegistroSalvo Then
                lista = prodBLL.GetProdutos_Where("IDProduto <> " & _produto.IDProduto & " AND RGProduto = " & myRGProduto)
            End If
            '
        Catch ex As Exception
            '
            MessageBox.Show(ex.Message)
            Return Nothing
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        If lista.Count = 0 Then
            Return Nothing
        Else
            Return lista(0)
        End If
        '
    End Function
    '
    '--- BUSCA UM NOVO NUMERO DE REGISTRO SEM USO
    Private Sub btnProcuraRG_Click(sender As Object, e As EventArgs) Handles btnProcuraRG.Click
        '
        If txtRGProduto.Text.Length > 0 Then
            If MessageBox.Show("Deseja substituir o Reg. Anterior desse Produto" & vbNewLine &
                               "por um novo registro validado pelo sistema?", "Novo Reg. Anterior",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then
                txtRGProduto.Focus()
                Exit Sub
            End If
        End If
        '
        '--- acessa BD
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim maxRG As Integer = If(prodBLL.ProcuraMaxRGProduto, 0)
            txtRGProduto.Text = Format(maxRG + 1, "0000")
            txtRGProduto.Focus()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Procurar um novo RG Válido para o produto..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    ' USAR SOMENTE NÚMERO NO CAMPO RGPRODUTO
    Private Sub txtRGProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGProduto.KeyPress
        '
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- GET THE RGPRODUTO VALUE
    Private Sub txtRGProduto_Enter(sender As Object, e As EventArgs) Handles txtRGProduto.Enter
        '--- save the RGProduto to control changes
        _OldRGProduto = _produto.RGProduto
    End Sub
	'
	' AO ENTRAR NO MENU SELECIONAR O btnProcurar
	Private Sub tsMenu_Enter(sender As Object, e As EventArgs) Handles tsMenu.Enter
        If btnProcurar.Enabled Then btnProcurar.Select()
    End Sub
    '
    ' REMOVE OS ACENTOS DA DIGITAÇÃO NO txtProduto
    Private Sub txtProduto_Validating(sender As Object, e As CancelEventArgs) Handles txtProduto.Validating
        '
        If txtProduto.Text.Trim.Length > 0 Then
			txtProduto.Text = Utilidades.removeAcentos(txtProduto.Text)
		End If
        '
    End Sub
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
                "txtRGProduto",
                "txtProdutoTipo",
                "txtProdutoSubTipo",
                "txtProdutoCategoria",
                "txtAutor",
                "txtFabricante",
                "txtDescontoCompra",
                "txtPCompra",
                "txtPVenda",
                "txtMargem",
                "txtMargemMin",
                "txtDesconto"
            }
            '
            If controlesBloqueados.Contains(ActiveControl.Name) Then
                e.Handled = True
            End If
            '
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtRGProduto.KeyDown,
                txtProdutoTipo.KeyDown,
                txtProdutoSubTipo.KeyDown,
                txtProdutoCategoria.KeyDown,
                txtAutor.KeyDown,
                txtFabricante.KeyDown,
                txtDescontoCompra.KeyDown,
                txtPCompra.KeyDown,
                txtPVenda.KeyDown,
                txtMargem.KeyDown,
                txtMargemMin.KeyDown,
                txtDesconto.KeyDown 'cmbIDProdutoSubTipo.KeyDown, cmbIDCategoria.KeyDown,
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            Select Case ctr.Name
                Case "txtRGProduto"
                    btnProcuraRG_Click(New Object, New EventArgs)
                Case "txtProdutoTipo"
                    ProcurarEscolherTipo(sender)
                Case "txtProdutoSubTipo"
                    ProcurarEscolherTipo(sender)
                Case "txtProdutoCategoria"
                    ProcurarEscolherTipo(sender)
                Case "txtAutor"
                    btnAutoresLista_Click(New Object, New EventArgs)
                Case "txtFabricante"
                    btnFabricantes_Click(New Object, New EventArgs)
                Case "txtPCompra"
                    AbrePainelMargem(txtMargem, txtPCompra)
                Case "txtPVenda"
                    AbrePainelMargem(txtDesconto, txtPVenda)
                Case "txtDescontoCompra"
                    AbrePainelMargem(txtDesconto, txtDescontoCompra)
                Case "txtMargem"
                    FechaPainelMargem()
                Case "txtMargemMin"
                    FechaPainelMargem()
                Case "txtDesconto"
                    FechaPainelMargem()
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtProdutoTipo"
                    If Not IsNothing(_produto.IDProdutoTipo) Then Sit = EnumFlagEstado.Alterado
                    txtProdutoTipo.Clear()
                    _produto.IDProdutoTipo = Nothing
                Case "txtProdutoSubTipo"
                    If Not IsNothing(_produto.IDProdutoSubTipo) Then Sit = EnumFlagEstado.Alterado
                    txtProdutoSubTipo.Clear()
                    _produto.IDProdutoSubTipo = Nothing
                Case "txtProdutoCategoria"
                    If Not IsNothing(_produto.IDCategoria) Then Sit = EnumFlagEstado.Alterado
                    txtProdutoCategoria.Clear()
                    _produto.IDCategoria = Nothing
                Case "txtFabricante"
                    If Not IsNothing(_produto.IDFabricante) Then Sit = EnumFlagEstado.Alterado
                    txtFabricante.Clear()
                    _produto.IDFabricante = Nothing
                Case "txtRGProduto"
                    txtRGProduto.Clear()
                    AutoValidate = AutoValidate.Disable
            End Select
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({"txtProdutoTipo", "txtProdutoSubTipo", "txtProdutoCategoria", "txtFabricante"})
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles _
        txtProduto.KeyDown, txtRGProduto.KeyDown, txtCodBarrasA.KeyDown,
        txtAutor.KeyDown, txtUnidade.KeyDown, txtEstoqueNivel.KeyDown,
        txtEstoqueIdeal.KeyDown, txtNCM.KeyDown, txtPCompra.KeyDown,
        txtPVenda.KeyDown, txtProdutoTipo.KeyDown, txtProdutoSubTipo.KeyDown,
        txtProdutoCategoria.KeyDown, txtDesconto.KeyDown, txtFabricante.KeyDown,
        txtDescontoCompra.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
	'
#End Region '// OUTRAS FUNÇÕES
	'
#Region "CORRELACAO DB ANTERIOR"
	'
	'--- PROCURA PELO CADASTRO DADOS ANTERIORES DA NA X_TBLPRODUTOS
	Private Sub txtRGProduto_Validating(sender As Object, e As CancelEventArgs) Handles txtRGProduto.Validating
		'
		'--- VERIFICA VALOR
		If Sit = EnumFlagEstado.RegistroSalvo OrElse txtRGProduto.Text.Trim.Length = 0 Then
			Return
		End If
		'
		'--- CHECK ANY CHANGES IN RGPRODUTO
		If txtRGProduto.Text = _OldRGProduto Then
			Return '---> no changes
		End If
		'
		'--- CHECK IF RGPRODUTO IS ALREADY IN USE
		If Not IsNothing(ProcurarProduto_RG(txtRGProduto.Text)) Then
			'
			AbrirDialog("Já existe produto cadastrado com esse mesmo número de Reg. Interno...",
						"Reg. Interno",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			'
			showToolTip(sender, New EventArgs)
			e.Cancel = True
			Return
			'
		End If
		'
		'--- procura no cadastro antigo o registro do produto pelo RG
		FindProdutoAntigoAndAddNew(txtRGProduto.Text)
		'
	End Sub
	'
	Private Sub txtRGProduto_Validated(sender As Object, e As EventArgs) Handles txtRGProduto.Validated
		_OldRGProduto = _produto.RGProduto
	End Sub
	'
	'--- PROCURA NO CADASTRO ANTIGO E FAZ RELACAO
	'----------------------------------------------------------------------------------
	Public Function FindProdutoAntigoAndAddNew(RGProdutoAntigo As Integer) As Boolean
        '
        Try
            '--- try obtain BDANTERIOR
            Dim pathBD As String = ObterConfigValorNode("BDAnterior")
            '
            If String.IsNullOrEmpty(pathBD.Length) OrElse Not File.Exists(pathBD) Then
                '
                Throw New AppException("O BD Anterior ainda não foi configurado no CONFIG ou não existe...")
                '
            End If
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim oldProdutoBLL As New ProdutoAntigoBLL(pathBD)
            Dim clP As clProduto = oldProdutoBLL.ProcuraProduto_CadastroAntigo(RGProdutoAntigo)
            '
            If IsNothing(clP) Then Return False
            '
            Dim msn As String = String.Format("Deseja preencher automaticamente com os dados anteriores? {4}{4} " +
                                              "PRODUTO: {0}{4} AUTOR: {1}{4} PREÇO DE VENDA: {2}{4} PREÇO DE COMPRA: {3}",
                                              clP.Produto, clP.Autor, Format(clP.PVenda, "C"), Format(clP.PCompra, "C"), vbNewLine)
            '
            If AbrirDialog(msn, "Obter Dados Anteriores",
                           frmDialog.DialogType.SIM_NAO, frmDialog.DialogIcon.Question,
                           frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Return False
			'
			'--- CHECK PRECO DE COMPRA
			'----------------------------------------------------------------------------------------------------
			If _produto.PCompra > 0 AndAlso _produto.PCompra <> clP.PCompra Then
				'
				AbrirDialog("O Preço de Compra da NFe é diferente do Preço Anterior..." & vbCrLf &
							"O preço anterior será substituído pelo preço da NFe",
							"Preço Divergente",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Information)
				'
				'If AbrirDialog("Novo Preço de Compra da NFe é diferente do Preço Anterior..." & vbCrLf &
				'			   "Você deseja alterar o Preço de compra Atual para o novo preço da NFe?",
				'			   "Preço Divergente",
				'			   frmDialog.DialogType.SIM_NAO,
				'			   frmDialog.DialogIcon.Question,
				'			   frmDialog.DialogDefaultButton.First) = DialogResult.No Then
				'	'
				'	_produto.PCompra = clP.PCompra
				'	'
				'End If
				'
			ElseIf IsNothing(_produto.PCompra) OrElse _produto.PCompra = 0 Then
				_produto.PCompra = clP.PCompra
			End If
			'
			'--- ITEMS WITH SAME OLD VALUE
			'----------------------------------------------------------------------------------------------------
			_produto.Produto = clP.Produto
            _produto.Autor = clP.Autor
            _produto.PVenda = clP.PVenda
            _produto.PCompra = clP.PCompra
            _produto.EstoqueNivel = clP.EstoqueNivel
            _produto.EstoqueIdeal = clP.EstoqueIdeal
            '
            '--- CORRELACIONADOS (TIPO | SUBTIPO | CATEGORIA | SIT.TRIBUTARIA)
            '----------------------------------------------------------------------------------------------------
            _produto.ProdutoTipo = clP.ProdutoTipo
            _produto.IDProdutoTipo = clP.IDProdutoTipo
            _produto.ProdutoSubTipo = clP.ProdutoSubTipo
            _produto.IDProdutoSubTipo = clP.IDProdutoSubTipo
            _produto.ProdutoCategoria = clP.ProdutoCategoria
            _produto.IDCategoria = clP.IDCategoria
            _produto.IDFabricante = clP.IDFabricante
            _produto.Fabricante = clP.Fabricante
            _produto.SitTributaria = clP.SitTributaria
            _produto.SituacaoTributaria = clP.SituacaoTributaria
            '
            '--- MAKE CORRELATION WITH ITEMS DONT RELATED
            CheckCorrelacaoDBAnterior(oldProdutoBLL)
            '
            '--- RECALC MARGEM DESCONTO/LUCRO
            CalcMargemDescontoLabel()
            '
            Return True
            '
        Catch ex As Exception
            Throw New AppException("Uma exceção ocorreu ao verificar cadastro de produto antigo..." & vbNewLine &
                                   ex.Message)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
    '--- CHECK CORRELACAO ITENS
    '----------------------------------------------------------------------------------
    Private Sub CheckCorrelacaoDBAnterior(oldProdutoBLL As ProdutoAntigoBLL)
        '
        Try
            '
            '--- TIPO
            If _produto.IDProdutoTipo = 0 Then
                CheckCorrelacaoTipo(oldProdutoBLL)
            End If
            '
            '--- SUBTIPO
            If _produto.IDProdutoSubTipo = 0 AndAlso Not IsNothing(_produto.IDProdutoTipo) Then
                CheckCorrelacaoSubTipo(oldProdutoBLL)
            ElseIf IsNothing(_produto.IDProdutoTipo) Then
                _produto.ProdutoSubTipo = Nothing
            End If
            '
            '--- CATEGORIA
            If _produto.IDCategoria = 0 AndAlso Not IsNothing(_produto.IDProdutoTipo) Then
                CheckCorrelacaoCategoria(oldProdutoBLL)
            ElseIf IsNothing(_produto.IDProdutoTipo) Then
                _produto.ProdutoCategoria = Nothing
            End If
            '
            '--- FABRICANTE
            If _produto.IDFabricante = 0 Then
                CheckCorrelacaoFabricante(oldProdutoBLL)
            End If
            '
            '--- SITUACAO
            If _produto.SitTributaria = 0 Then
                CheckCorrelacaoSituacao(oldProdutoBLL)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CHECK CORRELACAO TIPO
    '----------------------------------------------------------------------------------
    Private Sub CheckCorrelacaoTipo(oldProdutoBLL As ProdutoAntigoBLL)
        '
        Try
            '
            Dim separator As Char() = New Char() {":", ":"}
            Dim idAnterior As Integer = _produto.ProdutoTipo.Split(separator)(0)
            Dim descricaoAnterior As String = _produto.ProdutoTipo.Split(separator)(2).ToUpper
            '
            If AbrirDialog("Não foi encontrada correlação de TIPO" & vbCrLf &
                           "Deseja selecionar um TIPO cadastrado para correlacionar com:" &
                           vbCrLf & vbCrLf &
                           descricaoAnterior,
                           "Inserir Correlação",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                '
                Dim frmC As New frmProdutoProcurarTipo(Me)
                '
                frmC.ShowDialog()
                '
                If frmC.DialogResult = DialogResult.OK Then
                    Dim idInterno As Integer = frmC.propIdTipo_Escolha
                    '
                    '--- SAVE REFERENCE
                    oldProdutoBLL.MakeCorrelacaoDB(ProdutoAntigoBLL.EnumReferencia.Tipo, idInterno, idAnterior)
                    _produto.IDProdutoTipo = idInterno
                    _produto.ProdutoTipo = frmC.propTipo_Escolha
                    '
                Else
                    _produto.IDProdutoTipo = Nothing
                    _produto.ProdutoTipo = Nothing
                End If
                '
            Else
                _produto.IDProdutoTipo = Nothing
                _produto.ProdutoTipo = Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CHECK CORRELACAO SUBTIPO
    '----------------------------------------------------------------------------------
    Private Sub CheckCorrelacaoSubTipo(oldProdutoBLL As ProdutoAntigoBLL)
        '
        Try
            '
            Dim separator As Char() = New Char() {":", ":"}
            Dim idAnterior As Integer = _produto.ProdutoSubTipo.Split(separator)(0)
            Dim descricaoAnterior As String = _produto.ProdutoSubTipo.Split(separator)(2).ToUpper
            '
            If AbrirDialog("Não foi encontrada correlação de SUBTIPO" & vbCrLf &
                           "Deseja selecionar um SUBTIPO cadastrado para correlacionar com:" &
                           vbCrLf & vbCrLf &
                           descricaoAnterior,
                           "Inserir Correlação",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                '
                Dim frmC As New frmProdutoProcurarSubTipo(Me, , _produto.IDProdutoTipo)
                '
                frmC.ShowDialog()
                '
                If frmC.DialogResult = DialogResult.OK Then
                    Dim idInterno As Integer = frmC.propIdSubTipo_Escolha
                    '
                    '--- SAVE REFERENCE
                    oldProdutoBLL.MakeCorrelacaoDB(ProdutoAntigoBLL.EnumReferencia.Subtipo, idInterno, idAnterior)
                    _produto.IDProdutoSubTipo = idInterno
                    _produto.ProdutoSubTipo = frmC.propSubTipo_Escolha
                    '
                Else
                    _produto.IDProdutoSubTipo = Nothing
                    _produto.ProdutoSubTipo = Nothing
                End If
                '
            Else
                _produto.IDProdutoSubTipo = Nothing
                _produto.ProdutoSubTipo = Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CHECK CORRELACAO CATEGORIA
    '----------------------------------------------------------------------------------
    Private Sub CheckCorrelacaoCategoria(oldProdutoBLL As ProdutoAntigoBLL)
        '
        Try
            '
            Dim separator As Char() = New Char() {":", ":"}
            Dim idAnterior As Integer = _produto.ProdutoCategoria.Split(separator)(0)
            Dim descricaoAnterior As String = _produto.ProdutoCategoria.Split(separator)(2).ToUpper
            '
            If AbrirDialog("Não foi encontrada correlação de CATEGORIA" & vbCrLf &
                           "Deseja selecionar uma CATEGORIA cadastrado para correlacionar com:" &
                           vbCrLf & vbCrLf &
                           descricaoAnterior,
                           "Inserir Correlação",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                '
                Dim frmC As New frmProdutoProcurarCategoria(Me, , _produto.IDProdutoTipo)
                '
                frmC.ShowDialog()
                '
                If frmC.DialogResult = DialogResult.OK Then
                    Dim idInterno As Integer = frmC.propIdCategoria_Escolha
                    '
                    '--- SAVE REFERENCE
                    oldProdutoBLL.MakeCorrelacaoDB(ProdutoAntigoBLL.EnumReferencia.Categoria, idInterno, idAnterior)
                    _produto.IDCategoria = idInterno
                    _produto.ProdutoCategoria = frmC.propCategoria_Escolha
                    '
                Else
                    _produto.IDCategoria = Nothing
                    _produto.ProdutoCategoria = Nothing
                End If
                '
            Else
                _produto.IDCategoria = Nothing
                _produto.ProdutoCategoria = Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CHECK CORRELACAO FABRICANTE
    '----------------------------------------------------------------------------------
    Private Sub CheckCorrelacaoFabricante(oldProdutoBLL As ProdutoAntigoBLL)
        '
        Try
            '
            Dim separator As Char() = New Char() {":", ":"}
            Dim idAnterior As Integer = _produto.Fabricante.Split(separator)(0)
            Dim descricaoAnterior As String = _produto.Fabricante.Split(separator)(2).ToUpper
            '
            If AbrirDialog("Não foi encontrada correlação de FABRICANTE" & vbCrLf &
                           "Deseja selecionar um FABRICANTE cadastrado para correlacionar com:" &
                           vbCrLf & vbCrLf &
                           descricaoAnterior,
                           "Inserir Correlação",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                '
                Dim frmC As New frmFabricanteProcurar(Me)
                '
                frmC.ShowDialog()
                '
                If frmC.DialogResult = DialogResult.OK Then
                    Dim idInterno As Integer = frmC.propIDFab_Escolha
                    '
                    '--- SAVE REFERENCE
                    oldProdutoBLL.MakeCorrelacaoDB(ProdutoAntigoBLL.EnumReferencia.Fabricante, idInterno, idAnterior)
                    _produto.IDFabricante = idInterno
                    _produto.Fabricante = frmC.propFab_Escolha
                    '
                Else
                    _produto.IDFabricante = Nothing
                    _produto.Fabricante = Nothing
                End If
                '
            Else
                _produto.IDFabricante = Nothing
                _produto.Fabricante = Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CHECK CORRELACAO SITUACAO TRIBUTARIA
    '----------------------------------------------------------------------------------
    Private Sub CheckCorrelacaoSituacao(oldProdutoBLL As ProdutoAntigoBLL)
        '
        Try
            '
            Dim separator As Char() = New Char() {":", ":"}
            Dim idAnterior As Integer = _produto.SituacaoTributaria.Split(separator)(0)
            Dim descricaoAnterior As String = _produto.SituacaoTributaria.Split(separator)(2).ToUpper
            '
            If AbrirDialog("Não foi encontrada correlação de SITUAÇÃO TRIBUTÁRIA" & vbCrLf &
                           "Deseja selecionar uma SITUAÇÃO TRIBUTÁRIA cadastrada para correlacionar com:" &
                           vbCrLf & vbCrLf &
                           descricaoAnterior,
                           "Inserir Correlação",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                '
                Dim frmC As New frmSituacaoProcurar(Me)
                '
                frmC.ShowDialog()
                '
                If frmC.DialogResult = DialogResult.OK Then
                    Dim idInterno As Integer = frmC.propCodSit_Escolha
                    '
                    '--- SAVE REFERENCE
                    oldProdutoBLL.MakeCorrelacaoDB(ProdutoAntigoBLL.EnumReferencia.Situacao, idInterno, idAnterior)
                    _produto.SitTributaria = CByte(idInterno)
                    _produto.SituacaoTributaria = frmC.propSituacao_Escolha
                    '
                Else
                    _produto.SitTributaria = Nothing
                    _produto.SituacaoTributaria = Nothing
                End If
                '                
            Else
                _produto.SitTributaria = Nothing
                _produto.SituacaoTributaria = Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
#End Region '/ CORRELACAO DB ANTERIOR
    '
#Region "CONTROLE PAINEL MARGEM"
    '
    Private Sub AbrePainelMargem(FocusTo As TextBox, Sender As Control)
        '
        Dim x As Integer = Sender.Location.X - pnlCalculo.Width + Sender.Width
        Dim y As Integer = Sender.Location.Y - pnlCalculo.Height - 2
        '
        pnlCalculo.Location = New Point(x, y)
        '
        pnlCalculo.Visible = True
        pnlCalculo.Tag = Sender.Name
        txtMargem.Text = Format(CalcMargemDescontoLabel(0), "#,##0.00")
        txtDesconto.Text = Format(CalcMargemDescontoLabel(1), "#,##0.00")
        txtMargemMin.Text = Format(0, "#,##0.00")
        '
        FocusTo.Focus()
        FocusTo.SelectAll()
        '
    End Sub
    '
    Private Sub FechaPainelMargem()
        '
        pnlCalculo.Visible = False
        Me.Controls(pnlCalculo.Tag).Focus()
        Me.Controls(pnlCalculo.Tag).SelectAll()
        '
    End Sub
    '
    Private Sub txtMargem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMargem.KeyDown, txtDesconto.KeyDown, txtMargemMin.KeyDown
        '
        If e.KeyCode = Keys.Escape AndAlso pnlCalculo.Visible = True Then
            e.Handled = True
            FechaPainelMargem()
        End If
        '
    End Sub
    '
    Private Sub SoNumero(sender As Object, e As KeyPressEventArgs) Handles txtMargem.KeyPress, txtDesconto.KeyPress, txtMargemMin.KeyPress
        ' converte (.) em (,)
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
        ' verifica se foi digitado numero, backspace ou virgula
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack And Not e.KeyChar = "." And Not e.KeyChar = "," Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub txtMargem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMargem.KeyPress
        '
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            If Not IsNumeric(txtMargem.Text) Then
                txtPCompra.Focus()
                txtPCompra.SelectAll()
                pnlCalculo.Visible = False
                Exit Sub
            End If

            If IsNumeric(txtPCompra.Text) Then
                If CDbl(txtPCompra.Text) <= 0 Then
                    MsgBox("Qual é Valor do Preço de Compra?",, "Margem")
                    pnlCalculo.Visible = False
                    txtPCompra.Focus()
                    txtPCompra.SelectAll()
                    Exit Sub
                End If

                txtMargem.Text = Format(CDbl(txtMargem.Text), "#,##0.00")
                If chkArredondar.Checked = True Then
                    txtPVenda.Text = Ceiling(Round(txtPCompra.Text + txtPCompra.Text * ((CDbl(txtMargem.Text)) / 100), 2) * 10) / 10
                Else
                    txtPVenda.Text = Round(txtPCompra.Text + txtPCompra.Text * ((CDbl(txtMargem.Text)) / 100), 2)
                End If

                txtMargem.SelectAll()
                CalcMargemDescontoLabel()
                txtPVenda.DataBindings("Text").WriteValue()
            End If
        End If
    End Sub
    '
    Private Sub txtDesconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesconto.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            ' verifica se o txtDesconto e numero
            If Not IsNumeric(txtDesconto.Text) Then
                txtPVenda.Focus()
                txtPVenda.SelectAll()
                pnlCalculo.Visible = False
                Exit Sub
            End If
            ' formata o txtdesconto
            txtDesconto.Text = Format(CDbl(txtDesconto.Text), "#,##0.00")
            ' verifica se o txtPCompra e numero e se e maior que zero
            If Not IsNumeric(txtPCompra.Text) OrElse CDbl(txtPCompra.Text) <= 0 Then
                MsgBox("Qual é Valor do Preço de Venda?",, "Desconto")
                pnlCalculo.Visible = False
                txtPCompra.Focus()
                txtPCompra.SelectAll()
                Exit Sub
            End If
            ' executa o calculo
            Dim Pmin As Double

            If IsNumeric(txtMargemMin.Text) Then
                Pmin = txtPCompra.Text + txtPCompra.Text * txtMargemMin.Text / 100
            ElseIf Not IsNumeric(txtMargemMin.Text) OrElse txtMargemMin.Text <= 0 Then
                Pmin = txtPCompra.Text
            End If

            If chkArredondar.Checked = True Then
                txtPVenda.Text = Ceiling(Round(Pmin / (1 - txtDesconto.Text / 100), 2) * 10) / 10
            Else
                txtPVenda.Text = Round(Pmin / (100 - txtDesconto.Text), 2)
            End If

            txtDesconto.SelectAll()
            CalcMargemDescontoLabel()
            txtPCompra.DataBindings("Text").WriteValue()
        End If

    End Sub
    '
    Private Function CalcMargemDescontoLabel() As Double()
        Dim m As String = "Margem de "
        Dim d As String = "Desconto de "
        Dim n As Double
        Dim ret(1) As Double
        '
        If Not IsNothing(_produto.PCompra) AndAlso Not IsNothing(_produto.PVenda) Then
            '
            ' verifica se o valor é dos preços ainda é igual a Zero
            If _produto.PCompra = 0 AndAlso _produto.PVenda = 0 Then
                lblMargem.Text = "Margem de 0,00%"
                lblDesconto.Text = "Desconto de 0,00%"
                ret(0) = 0
                ret(1) = 0
                Return ret
            End If
            '
            ' calcula a margem e coloca no label
            'n = Round((CDbl(_produto.PVenda) - CDbl(_produto.PCompra)) / CDbl(_produto.PCompra) * 100, 2)
            n = _produto.MargemDe
            ' escreve o label
            lblMargem.Text = m & Format(n, "#,##0.00") & "%"
            ret(0) = n
            ' calcula o desconto e coloca no label
            'n = Round((CDbl(_produto.PVenda) - CDbl(_produto.PCompra)) / CDbl(_produto.PVenda) * 100, 2)
            n = _produto.DescontoDe
            lblDesconto.Text = d & Format(n, "#,##0.00") & "%"
            ret(1) = n
            Return ret
        Else
            ret(0) = 0
            ret(1) = 0
            Return ret
        End If
        '
    End Function
    '
    Private Sub pnlCalculo_Leave(sender As Object, e As EventArgs) Handles pnlCalculo.Leave
        '
        '--- verifica se existe active control no frmProduto
        If IsNothing(ActiveControl) Then Return
        '
        Dim c As Panel = sender
        Dim voltar As Boolean = True
        '
        For Each ctl As Control In pnlCalculo.Controls
            If Me.ActiveControl.Name = ctl.Name Then
                voltar = False
            End If
        Next
        '
        If voltar = True Then
            txtMargem.Focus()
        End If
        '
    End Sub
    '
    Private Sub txtMargem_Leave(sender As Object, e As EventArgs) Handles txtMargem.Leave, txtDesconto.Leave, txtMargemMin.Leave
        '
        Dim txt As TextBox = sender
        If txt.Text.Trim.Length > 0 AndAlso IsNumeric(txt.Text) Then
            txt.Text = Format(CDbl(txt.Text), "#,##0.00")
        End If
        '
    End Sub
    '
    Private Sub txtPVenda_Validated(sender As Object, e As EventArgs) Handles txtPVenda.Validated, txtPCompra.Validated
        CalcMargemDescontoLabel()
    End Sub
    '
#End Region '// CONTROLE PAINEL MARGEM
    '
#Region "BOTOES FUNCAO"
    '
    '--- BOTAO PROCURAR TIPO
    Private Sub btnProcurarTipo_Click(sender As Object, e As EventArgs) Handles btnProcurarTipo.Click
        ProcurarEscolherTipo(txtProdutoTipo)
    End Sub
    '
    '--- BOTAO PROCURAR FABRICANTE
    Private Sub btnFabricantes_Click(sender As Object, e As EventArgs) Handles btnFabricantes.Click
        ProcurarEscolherTipo(txtFabricante)
    End Sub
    '
    '--- ESCOLHER TIPO DE PRODUTO | SUBTIPO DE PRODUTO | CATEGORIA
    Private Sub ProcurarEscolherTipo(sender As Control)
        '
        Dim frmT As Form = Nothing
        Dim oldID As Integer?
        '
        '--- abre o formulário de ProdutoTipo, SubTipo e Categoria
        Select Case sender.Name
            '
            Case "txtProdutoTipo"
                '
                oldID = _produto.IDProdutoTipo
                frmT = New frmProdutoProcurarTipo(Me, oldID)
                '
            Case "txtProdutoSubTipo"
                '
                ' verifica se existe TIPO selecionado
                If IsNothing(_produto.IDProdutoTipo) Then
                    MessageBox.Show("Favor escolher o TIPO de produto, antes de escolher o SUBTIPO/CLASSIFICAÇÃO...",
                        "Escolher Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtProdutoTipo.Focus()
                    Return
                End If
                '
                oldID = _produto.IDProdutoSubTipo
                frmT = New frmProdutoProcurarSubTipo(Me, oldID, _produto.IDProdutoTipo)
                '
            Case "txtProdutoCategoria"
                '
                ' verifica se existe TIPO selecionado
                If IsNothing(_produto.IDProdutoTipo) Then
                    MessageBox.Show("Favor escolher o TIPO de produto, antes de escolher a CATEGORIA...",
                        "Escolher Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtProdutoTipo.Focus()
                    Return
                End If
                '
                oldID = _produto.IDCategoria
                frmT = New frmProdutoProcurarCategoria(Me, oldID, _produto.IDProdutoTipo)
                '
            Case "txtFabricante"
                '
                oldID = _produto.IDFabricante
                frmT = New frmFabricanteProcurar(Me, oldID)
                '
        End Select
        '
        ' revela o formulario dependendo do controle acionado
        frmT.ShowDialog()
        '
        ' ao fechar dialog verifica o resultado
        If frmT.DialogResult <> DialogResult.Cancel Then
            '
            Select Case sender.Name
            '
                Case "txtProdutoTipo"
                    txtProdutoTipo.Text = DirectCast(frmT, frmProdutoProcurarTipo).propTipo_Escolha
                    _produto.IDProdutoTipo = DirectCast(frmT, frmProdutoProcurarTipo).propIdTipo_Escolha
                    '
                    ' altera o EnumFlagEstado para ALTERADO
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_produto.IDProdutoTipo), 0, _produto.IDProdutoTipo) Then
                        '
                        ' remove o SUBTIPO e a CATEGORIA porque o TIPO foi alterado
                        txtProdutoSubTipo.Text = ""
                        _produto.IDProdutoSubTipo = Nothing
                        txtProdutoCategoria.Text = ""
                        _produto.IDCategoria = Nothing
                        '
                        ' altera o EnumFlagEstado
                        If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
                        '
                    End If
                    '
                    ' move focus
                    txtProdutoTipo.Focus()
                    '
                Case "txtProdutoSubTipo"
                    '
                    ' define o SubTipo escolhido
                    txtProdutoSubTipo.Text = DirectCast(frmT, frmProdutoProcurarSubTipo).propSubTipo_Escolha
                    _produto.IDProdutoSubTipo = DirectCast(frmT, frmProdutoProcurarSubTipo).propIdSubTipo_Escolha
                    '
                    ' altera o EnumFlagEstado para ALTERADO
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_produto.IDProdutoSubTipo), 0, _produto.IDProdutoSubTipo) Then
                        If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
                    End If
                    '
                    ' move focus
                    txtProdutoSubTipo.Focus()
                    '
                Case "txtProdutoCategoria"
                    '
                    ' define a categoria escolhida
                    txtProdutoCategoria.Text = DirectCast(frmT, frmProdutoProcurarCategoria).propCategoria_Escolha
                    _produto.IDCategoria = DirectCast(frmT, frmProdutoProcurarCategoria).propIdCategoria_Escolha
                    '
                    ' altera o EnumFlagEstado para ALTERADO
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_produto.IDCategoria), 0, _produto.IDCategoria) Then
                        If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
                    End If
                    '
                    ' move focus
                    txtProdutoCategoria.Focus()
                    '
                Case "txtFabricante"
                    '
                    ' define o Fabricante escolhido
                    txtFabricante.Text = DirectCast(frmT, frmFabricanteProcurar).propFab_Escolha
                    _produto.IDFabricante = DirectCast(frmT, frmFabricanteProcurar).propIDFab_Escolha
                    '
                    ' altera o EnumFlagEstado para ALTERADO
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_produto.IDFabricante), 0, _produto.IDFabricante) Then
                        If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
                    End If
                    '
                    ' move focus
                    txtFabricante.Focus()
                    '
            End Select
            '
        End If
        '
    End Sub
    '
    Private Sub btnNovoTipo_Click(sender As Object, e As EventArgs) Handles _
        btnNovoTipo.Click, btnNovoSubTipo.Click, btnNovaCategoria.Click
        '
        Dim myTipo As Integer? = _produto.IDProdutoTipo
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmTipo As New Form
            '
            Select Case DirectCast(sender, ToolStripMenuItem).Name
                Case "btnNovoTipo"
                    frmTipo = New frmProdutoTipo(frmProdutoTipo.ProcurarPor.None, myTipo)
                Case "btnNovoSubTipo"
                    If IsNothing(myTipo) Then
                        MessageBox.Show("É necessário escolher um Tipo de Produto antes de inserir novo SubTipo...",
                                        "Inserir SubTipo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtProdutoTipo.Focus()
                        Return
                    End If
                    frmTipo = New frmProdutoTipo(frmProdutoTipo.ProcurarPor.SubTipo, myTipo)
                Case "btnNovaCategoria"
                    If IsNothing(myTipo) Then
                        MessageBox.Show("É necessário escolher um Tipo de Produto antes de inserir nova Categoria...",
                                        "Inserir Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtProdutoTipo.Focus()
                        Return
                    End If
                    frmTipo = New frmProdutoTipo(frmProdutoTipo.ProcurarPor.Categoria, myTipo)
            End Select
            '
            Panel1.BackColor = Color.Silver
            frmTipo.ShowDialog()
            Panel1.BackColor = Color.SlateGray
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir formulário de Tipos/SubTipos/Categorias..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- suspende o Binding para preservar os valores
        lblIDProduto.Tag = 0
        bindP.SuspendBinding()
        '
        '--- retoma os Binding que foi suspenso
        bindP.ResumeBinding()
        '
    End Sub
    '
    Private Sub btnNovoFabricante_Click(sender As Object, e As EventArgs) Handles btnNovoFabricante.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmFabricante As New frmFabricante(False, Me)
            frmFabricante.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de Fabricantes..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub btnAutoresLista_Click(sender As Object, e As EventArgs) Handles btnAutoresLista.Click
        '
        Panel1.BackColor = Color.Silver
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmAut As New frmAutoresProcurar(Me)
            '
            frmAut.ShowDialog()
            '
            If frmAut.DialogResult = DialogResult.OK Then
                txtAutor.Text = frmAut.propAutorEscolhido
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a lista de Autores..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        Panel1.BackColor = Color.SlateGray
        '
        txtAutor.Focus()
        txtAutor.SelectAll()
        '
    End Sub
    '
    Private Sub frmProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape AndAlso pnlCalculo.Visible = False Then
            e.Handled = True
            '
            If IsNothing(_formOrigem) Then
                If btnCancelar.Enabled = True Then btnCancelar_Click(New Object, New EventArgs)
            Else
                If MessageBox.Show("Você deseja realmente fechar o formulário de cadastro de Produto?",
                                   "Fechar Formulário", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    btnFechar_Click(New Object, New EventArgs)
                End If
            End If
        End If
        '
    End Sub
    '
    '--- EXCLUIR PRODUTO
    '----------------------------------------------------------------------------------
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        MsgBox("Ainda não foi implementado...")
    End Sub
    '
    '--- FORNECEDORES DO PRODUTO
    '----------------------------------------------------------------------------------
    Private Sub btnFornecedores_Click(sender As Object, e As EventArgs) Handles btnFornecedores.Click
        '
        If IsNothing(_produto.IDProduto) OrElse _produto.IDProduto = 0 Then
            AbrirDialog("O registro de produto necessita ser Salvo antes de abrir os fornecedores...",
                        "Salve o Registro", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim form As New frmProdutoFornecedor(_produto, Me)
            form.MdiParent = Me.MdiParent
            form.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de Fornecedores..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '// BOTOES FUNCAO
    '
#Region "EFEITO VISUAL"
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
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProduto_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' DESENHA DUAS LINHAS NAS LATERAIS DO PNLCALCULO
    '-------------------------------------------------------------------------------------------------
    Private Sub pnlCalculo_Paint(sender As Object, e As PaintEventArgs) Handles pnlCalculo.Paint
        '
        Dim p As New Pen(Color.Tan, 10)
        '
        Dim p1 As New Point(pnlCalculo.ClientRectangle.Left, pnlCalculo.ClientRectangle.Top)
        Dim p2 As New Point(pnlCalculo.ClientRectangle.Left, pnlCalculo.ClientRectangle.Bottom)
        Dim p3 As New Point(pnlCalculo.ClientRectangle.Right, pnlCalculo.ClientRectangle.Top)
        Dim p4 As New Point(pnlCalculo.ClientRectangle.Right, pnlCalculo.ClientRectangle.Bottom)
        '
        e.Graphics.DrawLine(p, p1, p2)
        e.Graphics.DrawLine(p, p3, p4)
        '
    End Sub
    '
#End Region '// EFEITO VISUAL
    '
#Region "TOOLTIPS"
    '
    Private Sub addToolTipHandler()
        '
        ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
        txtMargem.Tag = "Margem Bruta aplicada sobre Preço de Compra"
        txtMargemMin.Tag = "Margem Mínima de lucro, mesmo com desconto máximo"
        txtDesconto.Tag = "Desconto Máximo para alcançar a Margem Mínima"
        txtDescontoCompra.Tag = "Abrir caixa para cálculo do Preço de Venda"
        chkArredondar.Tag = "Arrendondar centavos para cima"
        btnProcuraRG.Tag = "Procurar um Novo Reg. vazio para o Produto"
        btnFabricantes.Tag = "Editar Fabricantes de Produtos"
        btnAutoresLista.Tag = "Escolher Autor pelo Nome"
        '
        Dim listControles As New List(Of Control)
        '
        listControles.Add(txtProdutoTipo)
        listControles.Add(txtProdutoSubTipo)
        listControles.Add(txtProdutoCategoria)
        listControles.Add(txtAutor)
        listControles.Add(txtFabricante)
        listControles.Add(txtMargem)
        listControles.Add(txtMargemMin)
        listControles.Add(txtDesconto)
        listControles.Add(txtDescontoCompra)
        listControles.Add(chkArredondar)
        listControles.Add(btnProcuraRG)
        listControles.Add(btnFabricantes)
        listControles.Add(btnAutoresLista)
        '
        For Each c As Control In listControles
            AddHandler c.GotFocus, AddressOf showToolTip
            AddHandler c.MouseHover, AddressOf showToolTip
        Next
        '
    End Sub
    '
    Private Sub showToolTip(sender As Object, e As EventArgs)
        '
        Dim myControl As Control = DirectCast(sender, Control)
        '
        ' Cria a ToolTip e associa com o Form container.
        Dim toolTip1 As New ToolTip()
        '
        ' Define o delay para a ToolTip.
        With toolTip1
            .AutoPopDelay = 2000
            .InitialDelay = 1000
            .ReshowDelay = 500
            .IsBalloon = True
            .UseAnimation = True
            .UseFading = True
        End With
        '
        If myControl.Tag = "" Then
            toolTip1.Show("Pressione '+'  para escolher...", myControl, myControl.Width - 30, -40, 1000)
        Else
            toolTip1.Show(myControl.Tag, myControl, myControl.Width - 30, -40, 1000)
        End If
        '
        RemoveHandler myControl.GotFocus, AddressOf showToolTip
        RemoveHandler myControl.MouseHover, AddressOf showToolTip
        '
    End Sub
	'
#End Region '// TOOLTIPS
	' 
End Class
