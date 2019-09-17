Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmFornecedor
    Private _forn As clFornecedor
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _formOrigem As Form = Nothing
    Private BindForn As New BindingSource
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
#Region "LOAD E PROPERTIES"
    '
    Sub New(objForn As clFornecedor, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        propForn = objForn
        PreencheDataBindings()
        '
        If Not IsNothing(_forn.IDPessoa) Then Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    Private Sub frmFornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandlerControles() ' adiciona o handler para selecionar e usar tab com a tecla enter
    End Sub
    '
    '--- DEFINE SITUACAO PROPERTY
    '----------------------------------------------------------------------------------
    Private Property Sit As EnumFlagEstado
        '
        Get
            Return _Sit
        End Get
        '
        Set(value As EnumFlagEstado)
            _Sit = value
            '
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnCancelar.Enabled = False
                btnProcurar.Enabled = True
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                btnProcurar.Enabled = False
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtRazaoSocial.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                btnProcurar.Enabled = False
                lblID.Text = "NOVO"
            End If
            '
            '--- check if FormOrigem is DEFINED
            If Not IsNothing(_formOrigem) Then
                btnProcurar.Enabled = False
                btnProdutos.Enabled = False
                btnNovo.Enabled = False
            End If
            '
        End Set
        '
    End Property
    '
    '--- DEFINE O FORNECEDOR PROPERTY
    '----------------------------------------------------------------------------------
    Public Property propForn() As clFornecedor
        '
        Get
            Return _forn
        End Get
        '
        Set(ByVal value As clFornecedor)
            _forn = value
            BindForn.DataSource = _forn
            AtivoButtonImage()
            '
            If Not IsNothing(_forn.IDPessoa) Then
                lblID.Text = Format(_forn.IDPessoa, "0000")
            End If
            '
        End Set
        '
    End Property
    '
    '--- GET CNPJ OF NEW FORNECEDOR
    '----------------------------------------------------------------------------------
    Public Function InsertNewCNP(frmOrigem As Form) As Boolean
        '
        Dim frmCNP As New frmCNPInserir(PessoaBLL.EnumPessoaGrupo.FORNECEDOR, frmOrigem)
        '
        frmCNP.ShowDialog()
        If frmCNP.DialogResult = DialogResult.Cancel Then
            Return False
        End If
        '
        If TypeOf frmCNP.propPessoa Is clFornecedor Then
            '
            propForn = frmCNP.propPessoa
            '
            If IsNothing(propForn.IDPessoa) Then
                '--- SET VALORES DEFAULT DOS CAMPOS
                If _forn.Cidade.Trim.Length = 0 Then _forn.Cidade = ObterDefault("CidadePadrao")
                If _forn.UF.Trim.Length = 0 Then _forn.UF = ObterDefault("UFPadrao")
                '--- SET NEW
                Sit = EnumFlagEstado.NovoRegistro
            Else
                AbrirDialog("Já existe um FORNECEDOR com esse mesmo CNPJ." & vbNewLine &
                            "O registro do FORNECEDOR encontrado será aberto...",
                            "CNPJ Encontrado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
        Else
            '
            Dim PJ As clPessoaJuridica = frmCNP.propPessoa
            '
            If AbrirDialog("Foi encontrada uma Pessoa Jurídica que possui o mesmo CNPJ informado." & vbNewLine &
                           PJ.Cadastro & vbNewLine &
                           "Deseja inserir um NOVO FORNECEDOR com os dados dessa pessoa Jurídica?",
                           "CNPJ Encontrado",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.No Then
                '
                Return False
                '
            End If
            '
            propForn = New clFornecedor With {
                .IDPessoa = PJ.IDPessoa,
                .Cadastro = PJ.Cadastro,
                .CNPJ = PJ.CNPJ,
                .PessoaTipo = PJ.PessoaTipo,
                .Ativo = True,
                .Endereco = PJ.Endereco,
                .Bairro = PJ.Bairro,
                .Cidade = PJ.Cidade,
                .UF = PJ.UF,
                .CEP = PJ.CEP,
                .TelefoneA = PJ.TelefoneA,
                .TelefoneB = PJ.TelefoneB,
                .InscricaoEstadual = PJ.InscricaoEstadual,
                .Email = PJ.Email,
                .EmailDestino = PJ.EmailDestino,
                .EmailPrincipal = PJ.EmailPrincipal,
                .ContatoNome = PJ.ContatoNome,
                .FundacaoData = PJ.FundacaoData,
                .InsercaoData = PJ.InsercaoData,
                .NomeFantasia = PJ.NomeFantasia
            }
        End If
        '
        Return True
        '
    End Function
    '
#End Region
    '
#Region "DATABINDINGS"

    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblID.DataBindings.Add("Tag", BindForn, "IDPessoa")
        txtObservacao.DataBindings.Add("Text", BindForn, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtRazaoSocial.DataBindings.Add("Text", BindForn, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNomeFantasia.DataBindings.Add("Text", BindForn, "NomeFantasia", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEndereco.DataBindings.Add("Text", BindForn, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", BindForn, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", BindForn, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", BindForn, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", BindForn, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneA.DataBindings.Add("Text", BindForn, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneB.DataBindings.Add("Text", BindForn, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", BindForn, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCNPJ.DataBindings.Add("Text", BindForn, "CNPJ", True, DataSourceUpdateMode.OnPropertyChanged)
        txtInscricao.DataBindings.Add("Text", BindForn, "InscricaoEstadual", True, DataSourceUpdateMode.OnPropertyChanged)
        txtContatoNome.DataBindings.Add("Text", BindForn, "ContatoNome", True, DataSourceUpdateMode.OnPropertyChanged, "")
        txtVendedor.DataBindings.Add("Text", BindForn, "Vendedor", True, DataSourceUpdateMode.OnPropertyChanged, "")
        txtEmailVendas.DataBindings.Add("Text", BindForn, "EmailVendas", True, DataSourceUpdateMode.OnPropertyChanged, "")
        txtFundacaoData.DataBindings.Add("Text", BindForn, "FundacaoData", True, DataSourceUpdateMode.OnPropertyChanged, "  /  /")
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler BindForn.CurrentChanged, AddressOf handler_CurrentChanged
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(BindForn.CurrencyManager.Current, clFornecedor).AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(BindForn.CurrencyManager.Current, clFornecedor).AoAlterar, AddressOf HandlerAoAlterar
        '
        '--- Nesse caso é um novo registro
        If IsNothing(DirectCast(BindForn.Current, clFornecedor).IDPessoa) Then
            Exit Sub
        Else
            ' LER O ID
            lblID.DataBindings.Item("Tag").ReadValue()
            ' ALTERAR PARA REGISTRO SALVO
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If BindForn.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
        If IsDBNull(e.Value) Then Exit Sub
        e.Value = Format(e.Value, "0000")
    End Sub
    '
#End Region
    '
#Region "ACAO BOTOES"
    '
    '--- BTN PROCURAR
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        Close()
        '
        Dim fProc As New frmFornecedorProcurar
        fProc.Show()
        '
    End Sub
    '
    '--- BTN PRODUTOS
    Private Sub btnProdutos_Click(sender As Object, e As EventArgs) Handles btnProdutos.Click
        '
        If IsNothing(_forn.IDPessoa) OrElse _forn.IDPessoa = 0 Then
            AbrirDialog("O registro de FORNECEDOR necessita ser Salvo antes de abrir os produtos...",
                        "Salve o Registro", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim form As New frmFornecedorProdutos(_forn, Me)
            form.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- BTN NOVO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '
        Try
            InsertNewCNP(Me)
            txtRazaoSocial.Focus()
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao inserir novo registro de fornecedor..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- BTN CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            '
            If IsNothing(_formOrigem) Then
                btnProcurar_Click(btnCancelar, New EventArgs)
                Exit Sub
            Else
                DialogResult = DialogResult.Cancel
                _formOrigem.Visible = True
                Me.Close()
            End If
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            '
            BindForn.CancelEdit()
            AtivoButtonImage()
            '
        End If
        '
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    '--- BTN PROCURAR
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode INATIVAR um Novo Fornecedor...", "Inativar Fornecedor",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim transp As clFornecedor = BindForn.Current
        '
        If transp.Ativo = True Then ' Fornecedor Ativo
            If MessageBox.Show("Você deseja realmente INATIVAR o Fornecedor:" & vbNewLine &
                        txtRazaoSocial.Text.ToUpper, "Inativar Fornecedor", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                transp.BeginEdit()
                transp.Ativo = False
                AtivoButtonImage()
            End If
        ElseIf transp.Ativo = False Then ' Fornecedor Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR o Fornecedor:" & vbNewLine &
            txtRazaoSocial.Text.ToUpper, "Ativar Fornecedor", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                transp.BeginEdit()
                transp.Ativo = True
                AtivoButtonImage()
            End If
        End If
        '
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        If _forn.Ativo = True Then ' Nesse caso é Fornecedor Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Ativo"
        ElseIf _forn.Ativo = False Then ' Nesse caso é Fornecedor Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Inativo"
        End If
        '
    End Sub
    '
    '--- BTN FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        AutoValidate = AutoValidate.Disable
        '
        If Not IsNothing(_formOrigem) Then
            DialogResult = DialogResult.Cancel
            _formOrigem.Visible = True
        Else
            Me.Close()
            MostraMenuPrincipal()
        End If
        '
    End Sub
    '
#End Region

#Region "SALVAR REGISTRO"
    ' SALVAR O REGISTRO
    '---------------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- verifica os dados se os campos estão preechidos
        If VerificaDados() = False Then Exit Sub
        '
        '--- define os dados da classe
        Dim NewFornID As Integer
        Dim pBLL As New PessoaBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Define o tipo de Pessoa
            _forn.PessoaTipo = 2 '---> PJ
            '
            '--- Salva mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
            If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
                '
                Dim response = pBLL.InsertNewPessoa(_forn, PessoaBLL.EnumPessoaGrupo.FORNECEDOR)
                '
                If TypeOf response Is Integer Then
                    NewFornID = response
                Else
                    Throw New Exception("Já existe FORNECEDOR com mesmo CNPJ...")
                End If
                '
            ElseIf Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
                '
                If pBLL.UpdatePessoa(_forn, PessoaBLL.EnumPessoaGrupo.FORNECEDOR) Then
                    NewFornID = _forn.IDPessoa
                End If
                '
            End If
        Catch ex As Exception
            MessageBox.Show("Um erro ocorreu ao salvar o registro!" & vbCrLf &
                            ex.Message, "Erro ao Salvar Registro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        '--- Verifica se houve Retorno da Função de Salvar
        If IsNumeric(NewFornID) AndAlso NewFornID <> 0 Then
            '
            '--- Retorna o número de Registro do Novo Cliente Cadastrado
            If Sit = EnumFlagEstado.NovoRegistro Then
                _forn.IDPessoa = NewFornID
                lblID.DataBindings("Tag").ReadValue()
            End If

            '--- Altera a Situação
            Sit = EnumFlagEstado.RegistroSalvo
            BindForn.EndEdit()
            BindForn.CurrencyManager.Refresh()
            '
            '--- Mensagem de Sucesso:
            MsgBox("Registro Salvo com sucesso!", vbInformation, "Registro Salvo")
            '
            '--- check if exists formOrigem and close
            If Not IsNothing(_formOrigem) Then
                '
                DialogResult = DialogResult.OK
                Close()
                _formOrigem.Visible = True
                '
            End If
            '
        Else
            MsgBox("Registro NÃO pôde ser salvo!", vbInformation, "Erro ao Salvar")
        End If
        '
    End Sub
    '
    ' FAZER VERIFICAÇÃO ANTES DE SALVAR
    Private Function VerificaDados() As Boolean
        EProvider.Clear()
        '
        Dim f As New Utilidades
        '
        If Not f.VerificaControlesForm(txtRazaoSocial, "Razão Social", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtCNPJ, "CNPJ", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtInscricao, "Inscrição Estadual", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtEndereco, "Endereço", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtBairro, "Bairro", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtCidade, "Cidade", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtUF, "UF", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtCEP, "CEP", EProvider) Then Return False
        '
        If Not f.VerificaControlesForm(txtVendedor, "Nome do Vendedor", EProvider) Then Return False
        '
        '--- Verifica se existe pelo menos um telefone Inserido na Fornecedor
        Dim telA As Boolean = IsNothing(_forn.TelefoneA) OrElse _forn.TelefoneA.Length = 0
        Dim telB As Boolean = IsNothing(_forn.TelefoneB) OrElse _forn.TelefoneB.Length = 0
        '
        If telA And telB Then
            AbrirDialog("Deve haver pelo menos um telefone cadastrado nos dados da Reserva...",
                        "Telefone de Contato", frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Exclamation)
            txtTelefoneA.Focus()
            Return False
        End If
        '
        'Se nenhuma das condições acima forem verdadeira retorna TRUE
        Return True
        '
    End Function
    '
#End Region
    '
#Region "NAVEGACAO NO FORM"
    Private Sub AddHandlerControles()
        For Each c As Control In Me.Controls
            If c.GetType = GetType(TextBox) Then
                AddHandler DirectCast(c, TextBox).GotFocus, AddressOf SelTodoTexto
                AddHandler DirectCast(c, TextBox).KeyDown, AddressOf EnterForTab
            ElseIf c.GetType = GetType(MaskedTextBox) Then
                AddHandler DirectCast(c, MaskedTextBox).GotFocus, AddressOf SelTodoTexto
                AddHandler DirectCast(c, MaskedTextBox).KeyDown, AddressOf EnterForTab
            End If
        Next
    End Sub
    '
    ' HANDLER SELECIONAR TODO O TEXTO
    Private Sub SelTodoTexto(sender As Object, e As EventArgs)
        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).SelectAll()
        ElseIf sender.GetType = GetType(MaskedTextBox) Then
            DirectCast(sender, MaskedTextBox).SelectAll()
        End If

    End Sub
    '
    ' HANDLER SUPRIMIR A TECLA ENTER
    Private Sub EnterForTab(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '
#End Region
    '
End Class
