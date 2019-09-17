Imports CamadaBLL
Imports CamadaDTO

Public Class frmCredor
    '
    Property _Credor As clCredor
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private BindCred As New BindingSource
    Private _Tipo As Byte
    '
    Private _formOrigem As Form
    '
#Region "LOAD OPEN"
    '
    '--- SUB NEW
    '----------------------------------------------------------------------------------
    Sub New(Credor As clCredor, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        propCredor = Credor
        PreencheDataBindings()
        '
        '--- verifica se o é um NOVO CREDOR
        If Not IsNothing(_Credor.IDPessoa) Then Sit = EnumFlagEstado.RegistroSalvo
        '
        Handler_MouseDown()
        Handler_MouseUp()
        Handler_MouseMove()
        '
    End Sub
    '
    '--- PROPERTY CREDOR
    '----------------------------------------------------------------------------------
    Public Property propCredor() As clCredor
        '
        Get
            Return _Credor
        End Get
        '
        Set(ByVal value As clCredor)
            '
            _Credor = value
            BindCred.DataSource = _Credor
            AddHandler DirectCast(BindCred.CurrencyManager.Current, clCredor).AoAlterar, AddressOf HandlerAoAlterar
            propTipo = _Credor.CredorTipo
            If Not IsNothing(_Credor.IDPessoa) Then Sit = EnumFlagEstado.RegistroSalvo
            '
            If Not IsNothing(_Credor.IDPessoa) Then
                lblIDCredor.Text = Format(_Credor.IDPessoa, "0000")
            End If
            '
        End Set
        '
    End Property
    '
    '--- PROPERTY TIPO
    '----------------------------------------------------------------------------------
    Public Property propTipo() As Byte
        '
        Get
            Return _Tipo
        End Get
        '
        Set(ByVal value As Byte)
            _Tipo = value

            If value = 0 Or value = 3 Then '--- SIMPLES or ORGAO PUBLICO
                lblCNPTexto.Visible = False
                lblCNP.Visible = False
                lblCadastro.Text = "Descrição"
                pnlEndereco.Enabled = False
                pnlEndereco.BackColor = Color.Gainsboro
                '
            ElseIf value = 1 Then '--- PF
                lblCNPTexto.Visible = True
                lblCNP.Visible = True
                lblCNPTexto.Text = "CPF"
                lblCadastro.Text = "Nome"
                pnlEndereco.Enabled = True
                pnlEndereco.BackColor = Color.FromArgb(255, 234, 213)
                '
            ElseIf value = 2 Then '--- PJ
                lblCNPTexto.Visible = True
                lblCNP.Visible = True
                lblCNPTexto.Text = "CNPJ"
                lblCadastro.Text = "Razão Social"
                pnlEndereco.Enabled = True
                pnlEndereco.BackColor = Color.FromArgb(255, 234, 213)
                '
            End If
            '
        End Set
        '
    End Property
    '
    '--- GET TIPO AND CNP OF NEW CREDOR
    '----------------------------------------------------------------------------------
    Public Function InsertNewCNP(frmOrigem As Form) As Boolean
        '
        '--- GET THE CREDOR TIPO
        Dim frmTipo As New frmCredorTipo(frmOrigem)
        '
        frmTipo.ShowDialog()
        If frmTipo.DialogResult = DialogResult.Cancel Then
            Return False
        End If
        '
        Dim newCredorTipo As Byte = frmTipo.CredorTipo
        '
        '--- GET CNPJ OR CPF IF NECESSARY
        If newCredorTipo = 0 Or newCredorTipo = 3 Then '--> CREDOR SIMPLES OU GOVERNO
            _Credor.CredorTipo = newCredorTipo
            _Credor.CNP = Nothing
            Return True
        ElseIf newCredorTipo = 1 Then '---> CREDOR PESSOA FISICA
            Return GetNewCPF(frmOrigem)
        ElseIf newCredorTipo = 2 Then '---> CREDOR PESSOA JURIDICA
            Return GetNewCNPJ(frmOrigem)
        End If
        '
        Return False
        '
    End Function
    '
    '--- GET CNPJ OF NEW CREDOR PJ
    '----------------------------------------------------------------------------------
    Public Function GetNewCNPJ(frmOrigem As Form) As Boolean
        '
        Dim frmCNP As New frmCNPInserir(PessoaBLL.EnumPessoaGrupo.CREDOR, frmOrigem, "CNPJ")
        '
        frmCNP.ShowDialog()
        If frmCNP.DialogResult = DialogResult.Cancel Then
            Return False
        End If
        '
        If TypeOf frmCNP.propPessoa Is clCredor Then
            '
            propCredor = frmCNP.propPessoa
            '
            If IsNothing(propCredor.IDPessoa) Then
                '
                '--- SET VALORES DEFAULT DOS CAMPOS
                _Credor.Cidade = ObterDefault("CidadePadrao")
                _Credor.UF = ObterDefault("UFPadrao")
                '
                '--- SET NEW
                Sit = EnumFlagEstado.NovoRegistro
            Else
                AbrirDialog("Já existe um CREDOR com esse mesmo CNPJ." & vbNewLine &
                            "O registro dO CREDOR encontrado será aberto...",
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
                           "Deseja inserir um novo CREDOR com os dados dessa pessoa Jurídica?",
                           "CNPJ Encontrado",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.No Then
                '
                Return False
                '
            End If
            '
            propCredor = New clCredor With {
                .IDPessoa = PJ.IDPessoa,
                .Cadastro = PJ.Cadastro,
                .CNP = PJ.CNPJ,
                .PessoaTipo = PJ.PessoaTipo,
                .Ativo = True,
                .Endereco = PJ.Endereco,
                .Bairro = PJ.Bairro,
                .Cidade = PJ.Cidade,
                .UF = PJ.UF,
                .CEP = PJ.CEP,
                .TelefoneA = PJ.TelefoneA,
                .TelefoneB = PJ.TelefoneB,
                .Email = PJ.Email,
                .InsercaoData = PJ.InsercaoData
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
    '--- GET CPF OF NEW CREDOR PF
    '----------------------------------------------------------------------------------
    Public Function GetNewCPF(frmOrigem As Form) As Boolean
        '
        Dim frmCNP As New frmCNPInserir(PessoaBLL.EnumPessoaGrupo.CREDOR, frmOrigem, "CPF")
        '
        frmCNP.ShowDialog()
        If frmCNP.DialogResult = DialogResult.Cancel Then
            Return False
        End If
        '
        If TypeOf frmCNP.propPessoa Is clCredor Then
            '
            propCredor = frmCNP.propPessoa
            '
            If IsNothing(propCredor.IDPessoa) Then
                '
                '--- SET VALORES DEFAULT DOS CAMPOS
                _Credor.Cidade = ObterDefault("CidadePadrao")
                _Credor.UF = ObterDefault("UFPadrao")
                '
                '--- SET NEW
                Sit = EnumFlagEstado.NovoRegistro
            Else
                AbrirDialog("Já existe um CREDOR com esse mesmo CPF." & vbNewLine &
                            "O registro dO CREDOR encontrado será aberto...",
                            "CPF Encontrado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
        Else
            '
            Dim PF As clPessoaFisica = frmCNP.propPessoa
            '
            If AbrirDialog("Foi encontrada uma Pessoa Física que possui o mesmo CPF informado." & vbNewLine &
                           PF.Cadastro & vbNewLine &
                           "Deseja inserir um novo CREDOR com os dados dessa pessoa Física?",
                           "CPF Encontrado",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.No Then
                '
                Return False
                '
            End If
            '
            propCredor = New clCredor With {
                .IDPessoa = PF.IDPessoa,
                .Cadastro = PF.Cadastro,
                .CNP = PF.CPF,
                .PessoaTipo = PF.PessoaTipo,
                .Ativo = True,
                .Endereco = PF.Endereco,
                .Bairro = PF.Bairro,
                .Cidade = PF.Cidade,
                .UF = PF.UF,
                .CEP = PF.CEP,
                .TelefoneA = PF.TelefoneA,
                .TelefoneB = PF.TelefoneB,
                .Email = PF.Email,
                .InsercaoData = PF.InsercaoData
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
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                btnSalvar.Enabled = True
            End If
        End Set
        '
    End Property
    '
#End Region
    '
#Region "BINDING"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblIDCredor.DataBindings.Add("Text", BindCred, "IDPessoa")
        lblCredorTipo.DataBindings.Add("Text", BindCred, "CredorTipoDescricao")
        txtCadastro.DataBindings.Add("Text", BindCred, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCNP.DataBindings.Add("Text", BindCred, "CNP")
        txtEndereco.DataBindings.Add("Text", BindCred, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", BindCred, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", BindCred, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", BindCred, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", BindCred, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneA.DataBindings.Add("Text", BindCred, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneB.DataBindings.Add("Text", BindCred, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", BindCred, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDCredor.DataBindings("Text").Format, AddressOf idFormatRG
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Credor.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    '
#End Region
    '
#Region "FUNCOES UTILITARIAS"
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCadastro.KeyDown,
            txtEndereco.KeyDown, txtBairro.KeyDown, txtCidade.KeyDown,
            txtUF.KeyDown, txtCEP.KeyDown, txtEmail.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- CONTROLA TECLA ESCAPE
    Private Sub Me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            btnFechar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO BOTOES"

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click

        BindCred.CancelEdit()
        DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If VerificaControles() = False Then Exit Sub
        '
        Select Case Sit
            Case EnumFlagEstado.NovoRegistro
                InserirNovoRegistro() '--- INSERIR NOVO REGISTRO
            Case EnumFlagEstado.Alterado
                AlterarRegistro() '--- ALTERAR REGISTRO
        End Select
        '
    End Sub
    '
    Private Sub InserirNovoRegistro()
        '
        Dim cBLL As New PessoaBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Define PessoaTipo
            '0:Credor Simples | 1:Credor PF | 2:Credor PJ | 3:OrgaoPublico
            If _Credor.CredorTipo = 0 OrElse _Credor.CredorTipo = 3 Then
                _Credor.PessoaTipo = 4 '---> PESSOATIPO: CredorSimples
            ElseIf _Credor.CredorTipo = 1 Then
                _Credor.PessoaTipo = 1 '---> PESSOATIPO: PessoaFisica
            ElseIf _Credor.CredorTipo = 2 Then
                _Credor.PessoaTipo = 2 '---> PESSOATIPO: PessoaJuridica
            End If
            '
            Dim newID As Object = cBLL.InsertNewPessoa(_Credor, PessoaBLL.EnumPessoaGrupo.CREDOR)
            '
            If Not TypeOf newID Is Integer Then
                Throw New Exception("PJ, CNPJ ou Nome do Credor duplicados...")
            End If
            '
            _Credor.IDPessoa = newID
            lblIDCredor.DataBindings.Item("Text").ReadValue()
            Sit = EnumFlagEstado.RegistroSalvo
            MessageBox.Show("Registro Salvo com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            DialogResult = DialogResult.OK
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção inesperada ao salvar Credor:" &
                            vbNewLine & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCadastro.Focus()
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub AlterarRegistro()
        '
        Dim cBLL As New PessoaBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            cBLL.UpdatePessoa(_Credor, PessoaBLL.EnumPessoaGrupo.CREDOR)
            '
            MessageBox.Show("Registro Alterado com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sit = EnumFlagEstado.RegistroSalvo
            btnFechar.Focus()
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção inesperada ao alterar o Credor:" & vbNewLine & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCadastro.Focus()
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Function VerificaControles() As Boolean
        Dim f As New Utilidades
        '
        If f.VerificaControlesForm(txtCadastro, "Nome/Razão Social do Credor", EProvider) = False Then
            Return False
        End If
        '
        If propTipo = 1 Or propTipo = 2 Then

            If f.VerificaControlesForm(txtBairro, "Bairro", EProvider) = False Then
                Return False
            End If

            If f.VerificaControlesForm(txtCidade, "Cidade", EProvider) = False Then
                Return False
            End If

            If f.VerificaControlesForm(txtEndereco, "Endereço", EProvider) = False Then
                Return False
            End If

            If f.VerificaControlesForm(txtCEP, "CEP", EProvider) = False Then
                Return False
            End If

            If f.VerificaControlesForm(txtUF, "UF", EProvider) = False Then
                Return False
            End If

        End If
        '
        Return True
        '   
    End Function
    '
#End Region
    '
#Region "EFEITOS SUB-FORMULARIO PADRAO"
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.DarkSlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        _formOrigem.Visible = False
    End Sub
    '
    Private Sub frmDespesaTipo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If IsNothing(_formOrigem) Then Exit Sub
        _formOrigem.Visible = True
        '
    End Sub
    '
#End Region
    '
End Class