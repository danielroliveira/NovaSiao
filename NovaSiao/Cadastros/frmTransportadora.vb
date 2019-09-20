Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmTransportadora
    '
    Private _Transp As clTransportadora
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private BindTransp As New BindingSource
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
    Private _formOrigem As Form = Nothing
    '
#Region "LOAD E PROPERTIES"
    '
    '--- SUB NEW
    '----------------------------------------------------------------------------------
    Sub New(objTransp As clTransportadora, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        propTransp = objTransp
        PreencheDataBindings()
        '
        If Not IsNothing(_Transp.IDPessoa) Then Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    '--- ON LOAD FORM
    '----------------------------------------------------------------------------------
    Private Sub me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandlerControles() ' adiciona o handler para selecionar e usar tab com a tecla enter
    End Sub
    '
    '--- PROPERTY TRANSPORTADORA
    '----------------------------------------------------------------------------------
    Public Property propTransp() As clTransportadora
        '
        Get
            Return _Transp
        End Get
        '
        Set(ByVal value As clTransportadora)
            '
            _Transp = value
            BindTransp.DataSource = _Transp
            AddHandler DirectCast(BindTransp.CurrencyManager.Current, clTransportadora).AoAlterar, AddressOf HandlerAoAlterar
            If Not IsNothing(_Transp.IDPessoa) Then Sit = EnumFlagEstado.RegistroSalvo
            AtivoButtonImage()
            '
            If Not IsNothing(_Transp.IDPessoa) Then
                lblIDTransportadora.Text = Format(_Transp.IDPessoa, "0000")
            End If
            '
        End Set
        '
    End Property
    '
    '--- GET CNPJ OF NEW TRANSPORTADORA
    '----------------------------------------------------------------------------------
    Public Function InsertNewCNP(frmOrigem As Form) As Boolean
        '
        Dim frmCNP As New frmCNPInserir(PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA, frmOrigem)
        '
        frmCNP.ShowDialog()
        If frmCNP.DialogResult = DialogResult.Cancel Then
            Return False
        End If
        '
        If TypeOf frmCNP.propPessoa Is clTransportadora Then
            '
            propTransp = frmCNP.propPessoa
            '
            If IsNothing(propTransp.IDPessoa) Then
                '
                '--- SET VALORES DEFAULT DOS CAMPOS
                _Transp.Cidade = ObterDefault("CidadePadrao")
                _Transp.UF = ObterDefault("UFPadrao")
                '
                '--- SET NEW
                Sit = EnumFlagEstado.NovoRegistro
            Else
                AbrirDialog("Já existe uma transportadora com esse mesmo CNPJ." & vbNewLine &
                            "O registro da transpotadora encontrada será aberto...",
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
                        "Deseja inserir uma nova transportadora com os dados dessa pessoa Jurídica?",
                        "CNPJ Encontrado",
                        frmDialog.DialogType.SIM_NAO,
                        frmDialog.DialogIcon.Question) = DialogResult.No Then
                '
                Return False
                '
            End If
            '
            propTransp = New clTransportadora With {
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
            '
            '--- SET NEW
            Sit = EnumFlagEstado.NovoRegistro
            '
        End If
        '
        Return True
        '
    End Function
    '
    '--- SITUACAO DO REGISTRO
    '----------------------------------------------------------------------------------
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
                lblIDTransportadora.Text = "NOVO"
            End If
            '
            '--- check if FormOrigem is DEFINED
            If Not IsNothing(_formOrigem) Then
                btnProcurar.Enabled = False
                btnNovo.Enabled = False
                btnFechar.Text = "OK"
            End If
            '
        End Set
        '
    End Property
    '
#End Region
    '
#Region "DATABINDINGS"

    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblIDTransportadora.DataBindings.Add("Tag", BindTransp, "IDPessoa")
        txtObservacao.DataBindings.Add("Text", BindTransp, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtRazaoSocial.DataBindings.Add("Text", BindTransp, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNomeFantasia.DataBindings.Add("Text", BindTransp, "NomeFantasia", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEndereco.DataBindings.Add("Text", BindTransp, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", BindTransp, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", BindTransp, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", BindTransp, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", BindTransp, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneA.DataBindings.Add("Text", BindTransp, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneB.DataBindings.Add("Text", BindTransp, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", BindTransp, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCNPJ.DataBindings.Add("Text", BindTransp, "CNPJ", True, DataSourceUpdateMode.OnPropertyChanged)
        txtInscricao.DataBindings.Add("Text", BindTransp, "InscricaoEstadual", True, DataSourceUpdateMode.OnPropertyChanged)
        txtContatoNome.DataBindings.Add("Text", BindTransp, "ContatoNome", True, DataSourceUpdateMode.OnPropertyChanged)
        txtFundacaoData.DataBindings.Add("Text", BindTransp, "FundacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDTransportadora.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler BindTransp.CurrentChanged, AddressOf handler_CurrentChanged
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
		'
		'--- Nesse caso é um novo registro
		If IsNothing(DirectCast(BindTransp.Current, clTransportadora).IDPessoa) Then
            Exit Sub
        Else
            ' LER O ID
            lblIDTransportadora.DataBindings.Item("Tag").ReadValue()
            ' ALTERAR PARA REGISTRO SALVO
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If BindTransp.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
        Dim fProc As New frmTransportadoraProcurar
        fProc.Show()
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
            MessageBox.Show("Uma exceção ocorreu ao inserir novo registro de transportadora..." & vbNewLine &
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
                Close()
            End If
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            '
            BindTransp.CancelEdit()
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
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode INATIVAR uma Nova Transportadora...", "Inativar Transportadora",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim transp As clTransportadora = BindTransp.Current

        If transp.Ativo = True Then ' Transportadora Ativa
            If MessageBox.Show("Você deseja realmente INATIVAR a Transportadora:" & vbNewLine &
                        txtRazaoSocial.Text.ToUpper, "Inativar Transportadora", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                transp.BeginEdit()
                transp.Ativo = False
                AtivoButtonImage()
            End If
        ElseIf transp.Ativo = False Then ' Transportadora Inativa
            If MessageBox.Show("Você deseja realmente ATIVAR a Transportadora:" & vbNewLine &
            txtRazaoSocial.Text.ToUpper, "Ativar Transportadora", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                transp.BeginEdit()
                transp.Ativo = True
                AtivoButtonImage()
            End If
        End If
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        Dim transp As clTransportadora = BindTransp.Current

        If transp.Ativo = True Then ' Nesse caso é Transportadora Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Ativa"
        ElseIf transp.Ativo = False Then ' Nesse caso é Transportadora Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Inativa"
        End If
    End Sub
    '
    '--- BTN FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        AutoValidate = AutoValidate.Disable
        '
        If Not IsNothing(_formOrigem) Then
            '
            If Sit = EnumFlagEstado.RegistroSalvo Then
                DialogResult = DialogResult.OK
            Else
                DialogResult = DialogResult.Cancel
            End If
            '
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
    '
    ' SALVAR O REGISTRO
    '---------------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- verifica os dados se os campos estão preechidos
        If VerificaDados() = False Then Exit Sub
        '
        '--- define os dados da classe
        Dim NewTranspID As Long
        Dim pBLL As New PessoaBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Define Pessoa Tipo
            _Transp.PessoaTipo = 2 '---> PJ
            '
            '--- Salva mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
            If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
                '
                Dim response = pBLL.InsertNewPessoa(_Transp, PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA)
                '
                If TypeOf response Is Integer Then
                    NewTranspID = response
                Else
                    Throw New Exception("Já existe TRANSPORTADORA com mesmo CNPJ...")
                End If
                '
            ElseIf Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
                If pBLL.UpdatePessoa(_Transp, PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA) Then
                    '
                    NewTranspID = _Transp.IDPessoa
                    '
                End If
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
        If IsNumeric(NewTranspID) AndAlso NewTranspID <> 0 Then
            '--- Retorna o número de Registro do Novo Cliente Cadastrado
            If Sit = EnumFlagEstado.NovoRegistro Then
                _Transp.IDPessoa = NewTranspID
                lblIDTransportadora.DataBindings("Tag").ReadValue()
            End If

            '--- Altera a Situação
            Sit = EnumFlagEstado.RegistroSalvo
            BindTransp.EndEdit()
            BindTransp.CurrencyManager.Refresh()
            '
            '--- Mensagem de Sucesso:
            MsgBox("Registro Salvo com sucesso!", vbInformation, "Registro Salvo")
            '
            If Not IsNothing(_formOrigem) Then
                DialogResult = DialogResult.OK
                'btnFechar_Click(sender, e)
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
        If Not f.VerificaControlesForm(txtRazaoSocial, "Razão Social", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtCNPJ, "CNPJ", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtInscricao, "Inscrição Estadual", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtEndereco, "Endereço", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtBairro, "Bairro", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtCidade, "Cidade", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtUF, "UF", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtCEP, "CEP", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtTelefoneA, "Telefone", EProvider) Then
            Return False
        End If
        '
        'Se nenhuma das condições acima forem verdadeira retorna TRUE
        Return True
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

End Class
