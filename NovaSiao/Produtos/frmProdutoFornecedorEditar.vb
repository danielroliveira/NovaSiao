Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmProdutoFornecedorEditar
    '
    Private _prodForn As clProdutoFornecedor
    Private bindProd As New BindingSource
    Private _Sit As EnumFlagEstado
    Private _formOrigem As Form = Nothing
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    Private _isProdutoFixed As Boolean
    '
#Region "SUB NEW"
    '
    Sub New(prodForn As clProdutoFornecedor, isProdutoFixed As Boolean, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _prodForn = prodForn
        _isProdutoFixed = isProdutoFixed
        bindProd.DataSource = _prodForn
        PreencheDataBindings()
        '
        If IsNothing(_prodForn.IDFornecedor) Then '--> NEW | INSERT
            Sit = EnumFlagEstado.NovoRegistro
        Else '--> SAVED | UPDATE
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
        If IsNothing(_prodForn.IDTransacao) Then
            '
            If isProdutoFixed Then
                btnFornecedor.Enabled = True
                txtFornecedor.ReadOnly = False
                txtRGProduto.ReadOnly = True
            Else
                btnFornecedor.Enabled = False
                txtFornecedor.ReadOnly = True
                txtRGProduto.ReadOnly = False
            End If
            '
            dtpUltimaEntrada.Enabled = True
            txtDescontoCompra.ReadOnly = False
            txtPCompra.ReadOnly = False
            lblVinculado.Visible = False
        Else
            btnFornecedor.Enabled = False
            txtFornecedor.ReadOnly = True
            txtRGProduto.ReadOnly = True
            dtpUltimaEntrada.Enabled = False
            txtDescontoCompra.ReadOnly = True
            txtPCompra.ReadOnly = True
            lblVinculado.Visible = True
        End If
        '
        dtpUltimaEntrada.MaxDate = Today
        AtivoButtonImage()
        '
    End Sub
    '
    'PROPERTY SIT
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnCancelar.Enabled = False
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
            End If
        End Set
    End Property
    '
#End Region '/ SUB NEW
    '
#Region "BINDINGS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA

        lblIDTransacao.DataBindings.Add("Text", bindProd, "IDTransacao")
        lblApelidoFilial.DataBindings.Add("Text", bindProd, "ApelidoFilial")
        dtpUltimaEntrada.DataBindings.Add("Value", bindProd, "UltimaEntrada", True, DataSourceUpdateMode.OnPropertyChanged)

        txtRGProduto.DataBindings.Add("Text", bindProd, "RGProduto", True, DataSourceUpdateMode.OnPropertyChanged)
        lblProduto.DataBindings.Add("Text", bindProd, "Produto")
        txtFornecedor.DataBindings.Add("Text", bindProd, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)

        txtPCompra.DataBindings.Add("Text", bindProd, "PCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescontoCompra.DataBindings.Add("Text", bindProd, "DescontoCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        lblPrecoFinal.DataBindings.Add("Text", bindProd, "SubTotal")
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtPCompra.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler txtDescontoCompra.DataBindings("text").Format, AddressOf FormatPercent
        AddHandler txtRGProduto.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblIDTransacao.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblPrecoFinal.DataBindings("Text").Format, AddressOf FormatCUR
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _prodForn.AoAlterar, AddressOf HandlerAoAlterar
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _prodForn.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    Private Sub FormatPercent(sender As Object, e As ConvertEventArgs)
        e.Value = Format(e.Value / 100, "0.00%")
    End Sub
    '
#End Region '/ BINDINGS
    '
#Region "BUTTONS FUNCTION"
    '
    '--- CLOSE FORM
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        DialogResult = DialogResult.Cancel
    End Sub
    '
    '--- BTN ESCOLHER FORNECEDOR
    Private Sub btnFornecedor_Click(sender As Object, e As EventArgs) Handles btnFornecedor.Click
        '
        If Not IsNothing(_prodForn.IDTransacao) Then Exit Sub
        '
        Dim frmF As frmFornecedorProcurar
        Dim oldID As Integer?
        '
        oldID = _prodForn.IDFornecedor
        frmF = New frmFornecedorProcurar(True, Me)
        '
        ' revela o formulario dependendo do controle acionado
        frmF.ShowDialog()
        '
        ' ao fechar dialog verifica o resultado
        If frmF.DialogResult <> DialogResult.OK Then Exit Sub
        '
        txtFornecedor.Text = frmF.propFornecedor_Escolha.Cadastro
        _prodForn.Cadastro = frmF.propFornecedor_Escolha.Cadastro
        _prodForn.IDFornecedor = frmF.propFornecedor_Escolha.IDPessoa
        txtFornecedor.Focus()
        '
        ' altera o EnumFlagEstado para ALTERADO
        If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_prodForn.IDFornecedor), 0, _prodForn.IDFornecedor) Then
            '
            ' altera o EnumFlagEstado
            If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
            '
        End If
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If Sit = EnumFlagEstado.Alterado Then
            _prodForn.CancelEdit()
            bindProd.ResetBindings(False)
            AtivoButtonImage()
            Sit = EnumFlagEstado.RegistroSalvo
        Else
            DialogResult = DialogResult.Cancel
        End If
        '
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If Not IsNothing(_prodForn.IDTransacao) Then
            AbrirDialog("Não é possível salvar esse registro porque está vinculado a uma Transação de Compra...",
                        "Registro Vinculado",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Exclamation)

            _prodForn.CancelEdit()
            bindProd.ResetBindings(False)
            AtivoButtonImage()
            Sit = EnumFlagEstado.RegistroSalvo
            Exit Sub
        End If
        '
        If Not VerificaValores() Then Exit Sub
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    ' ATIVAR OU DESATIVAR FORNECEDOR PADRAO BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            AbrirDialog("Não é possível definir Fornecedor Padrão para um registro que ainda não foi Salvo" & vbNewLine &
                        "Para definir esse fornecedor, favor salvar o registro antes.",
                        "Definir Fornecedor Padrão",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        If _prodForn.FornecedorPadrao = True Then ' Fornecedor Padrão
            '
            AbrirDialog("Não é possível remover o Fornecedor Padrão..." & vbNewLine &
                        "Para remover desse Fornecedor, defina outro Fornecedor Padrão.",
                        "Remover Fornecedor Padrão",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            '
        ElseIf _prodForn.FornecedorPadrao = False Then ' Fornecedor Auxiliar
            '
            If AbrirDialog("Você deseja realmente definir o Fornecedor padrão do Produto para:" & vbNewLine &
                           txtFornecedor.Text.ToUpper,
                           "Definir Fornecedor Padrão",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question,
                           frmDialog.DialogDefaultButton.Second) = DialogResult.Yes Then
                '
                Try
                    '
                    '--- Ampulheta ON
                    Cursor = Cursors.WaitCursor
                    '
                    DirectCast(_formOrigem, frmProdutoFornecedor).DefineFornecedorPadrao(_prodForn)
                    '
                Catch ex As Exception
                    '
                    MessageBox.Show("Uma exceção ocorreu ao Definir fornecedor Padrão..." & vbNewLine &
                                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    '
                    '--- Ampulheta OFF
                    Cursor = Cursors.Default
                End Try
                '
                _prodForn.FornecedorPadrao = True
                _prodForn.EndEdit()
                Sit = EnumFlagEstado.RegistroSalvo
                AtivoButtonImage()
            End If
        End If
        '
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        If _prodForn.FornecedorPadrao = True Then ' Nesse caso é Produto Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Fornecedor Padrão"
        ElseIf _prodForn.FornecedorPadrao = False Then ' Nesse caso é Produto Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Fornecedor Auxiliar"
        End If
        '
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "OUTRAS FUNCOES"
    '
    Private Function VerificaValores() As Boolean
        '
        Dim EP As New ErrorProvider
        Dim f As New Utilidades
        '
        If Not f.VerificaDadosClasse(dtpUltimaEntrada, "Ultima Data da Entrada", _prodForn, EP) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtFornecedor, "Fornecedor", _prodForn, EP) Then
            btnFornecedor.Focus()
            Return False
        End If
        '
        If IsNothing(_prodForn.IDFornecedor) Then
            '
            '--- MENSAGEM E ERROR PROVIDER
            MessageBox.Show("O campo Fornecedor não pode ficar vazio;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro por favor...",
                            "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- CONTROLA O ERROR PROVIDER
            EP.SetError(txtFornecedor, "Preencha o valor desse campo!")
            txtFornecedor.Focus()
            '
            Return False
            '
        End If
        '
        If Not f.VerificaDadosClasse(txtPCompra, "Preço de Compra", _prodForn, EP) Then
            Return False
        End If
        '
        If _prodForn.PCompra <= 0 Then
            '
            '--- MENSAGEM E ERROR PROVIDER
            MessageBox.Show("O campo Preço de Compra não pode ser igual ou menor que Zero;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro, por favor...",
                            "Campo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- CONTROLA O ERROR PROVIDER
            EP.SetError(txtPCompra, "Preencha o valor desse campo!")
            txtPCompra.Focus()
            '
            Return False
            '
        End If
        '
        If Not f.VerificaDadosClasse(txtDescontoCompra, "Desconto de Compra", _prodForn, EP) Then
            Return False
        End If
        '
        If _prodForn.DescontoCompra < 0 OrElse _prodForn.DescontoCompra > 90 Then
            '
            '--- MENSAGEM E ERROR PROVIDER
            MessageBox.Show("O campo Desconto de Compra não pode menor que Zero, ou maior que 90;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro, por favor...",
                            "Campo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- CONTROLA O ERROR PROVIDER
            EP.SetError(txtDescontoCompra, "Preencha o valor desse campo!")
            txtDescontoCompra.Focus()
            '
            Return False
            '
        End If
        '
        Return True
        '
    End Function
    '
    '---------------------------------------------------------------------------------------
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    '---------------------------------------------------------------------------------------
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles dtpUltimaEntrada.KeyDown, txtPCompra.KeyDown, txtDescontoCompra.KeyDown, txtRGProduto.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' FAZ A TECLA ESC FECHAR O FORM
    '------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
#End Region '/ OUTRAS FUNCOES
    '
#Region "EFEITOS VISUAIS"
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
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub

    Private Sub txtDescontoCompra_Leave(sender As Object, e As EventArgs) Handles txtDescontoCompra.Leave
        bindProd.ResetBindings(False)
    End Sub
    '
#End Region
    '
#Region "CONTROLS"
    '
    '---------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
                "txtFornecedor", "txtRGProduto"
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
    Private Sub txtFornecedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFornecedor.KeyDown

        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            If Not _isProdutoFixed Then
                MessageBox.Show("Não é possível alterar o fornecedor...",
                                "Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            btnFornecedor_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    Private Sub txtFornecedor_Enter(sender As Object, e As EventArgs) Handles txtFornecedor.Enter, txtRGProduto.Enter
        DirectCast(sender, Control).BackColor = Color.White
    End Sub

    Private Sub txtFornecedor_Leave(sender As Object, e As EventArgs) Handles txtFornecedor.Leave, txtRGProduto.Leave
        DirectCast(sender, Control).BackColor = Color.FromArgb(219, 228, 240)
    End Sub
    '
    ' CONTROLA O KEYPRESS DO RGPRODUTO (PERMITE SOMENTE NUMERO)
    Private Sub txtRGProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGProduto.KeyPress
        '
        'MsgBox(e.KeyChar.ToString)
        '
        If _isProdutoFixed And e.KeyChar <> vbCr Then
            MessageBox.Show("Não é possível alterar o produto...",
                            "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
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
            txtRGProduto.Text = p.RGEscolhido
            SendKeys.Send("{TAB}")
            '
        ElseIf e.KeyChar = vbCr Then '--- pressiona ENTER
            e.Handled = False
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- VALIDA O RGPRODUTO PARA OBTER OS DADOS DO PRODUTO
    Private Sub txtRGProduto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRGProduto.Validating
        '
        If _isProdutoFixed Then Exit Sub
        '
        If String.IsNullOrEmpty(txtRGProduto.Text) OrElse Sit = EnumFlagEstado.RegistroSalvo Then Exit Sub
        '
        If Produto_ObterDados(txtRGProduto.Text) = False Then
            e.Cancel = True
        End If
        '
    End Sub
    '
    '--- FUNCAO PARA OBTER OS DADOS DO PRODUTO INSERIDO PELO RGPRODUTO
    Private Function Produto_ObterDados(RGProduto As Integer) As Boolean
        Dim pBLL As New ProdutoBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim prod As clProduto = pBLL.GetProduto_PorRG(RGProduto, Obter_FilialPadrao)
            '
            If IsNothing(prod) Then
                MessageBox.Show("Esse código de Produto não foi encontrado...",
                                "Registro Inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            '--- Define os itens do produto encontrado
            _prodForn.Produto = prod.Produto
            _prodForn.IDProduto = prod.IDProduto
            _prodForn.RGProduto = prod.RGProduto
            _prodForn.PCompra = prod.PCompra
            _prodForn.DescontoCompra = prod.DescontoCompra
            '
            '--- RETORNA
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter os dados do produto informado...",
                            "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
#End Region '/ CONTROLS
    '
End Class
