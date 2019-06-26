Imports System.ComponentModel
Imports CamadaBLL
Imports CamadaDTO

Public Class frmCredor
    Private _Tipo As Byte
    Property _Credor As clCredor
    Private BindCred As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private VerificaAlteracao As Boolean = False
    Private _formOrigem As Form
    '
#Region "LOAD OPEN"
    '
    '--- Property Tipo
    Public Property propTipo() As Byte
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Byte)
            _Tipo = value

            If value = 0 Or value = 3 Then '--- SIMPLES or ORGAO PUBLICO
                txtCNP.Enabled = False
                lblCNP.Text = "CNP"
                lblCadastro.Text = "Descrição"
                pnlEndereco.Enabled = False
                pnlEndereco.BackColor = Color.Gainsboro
                '
            ElseIf value = 1 Then '--- PF
                txtCNP.Enabled = True
                txtCNP.Mask = "000,000,000-00"
                lblCNP.Text = "CPF"
                lblCadastro.Text = "Nome"
                pnlEndereco.Enabled = True
                pnlEndereco.BackColor = Color.FromArgb(255, 234, 213)
                '
            ElseIf value = 2 Then '--- PJ
                txtCNP.Enabled = True
                txtCNP.Mask = "00,000,000/0000-00"
                lblCNP.Text = "CNPJ"
                lblCadastro.Text = "Razão Social"
                pnlEndereco.Enabled = True
                pnlEndereco.BackColor = Color.FromArgb(255, 234, 213)
                '
            End If
            '
            '--- Apaga os valores do campos
            If value = 0 Or value = 3 Then
                txtCNP.Clear()
                txtEndereco.Clear()
                txtBairro.Clear()
                txtCidade.Clear()
                txtUF.Clear()
                txtCEP.Clear()
                txtTelefoneA.Clear()
                txtTelefoneB.Clear()
                txtEmail.Clear()
            End If
        End Set
    End Property
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                txtCNP.ReadOnly = True
                btnSalvar.Enabled = False
            ElseIf _Sit = enumFlagEstado.Alterado Then
                txtCNP.ReadOnly = True
                btnSalvar.Enabled = True
            ElseIf _Sit = enumFlagEstado.NovoRegistro Then
                txtCNP.ReadOnly = False
                btnSalvar.Enabled = True
            End If
        End Set
    End Property
    '
    Sub New(Credor As clCredor, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        CarregaComboTipo()
        _Credor = Credor
        BindCred.DataSource = _Credor
        PreencheDataBindings()
        '
        '
        '--- verifica se o é um NOVO CREDOR
        If IsNothing(_Credor.IDPessoa) Then
            propTipo = 0
            Sit = EnumFlagEstado.NovoRegistro
        Else
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
        AddHandler cmbCredorTipo.SelectedIndexChanged, AddressOf cmbCredorTipo_SelectedIndexChanged
        AddHandler cmbCredorTipo.SelectedValueChanged, AddressOf cmbCredorTipo_SelectedValueChanged
        '
        Handler_MouseDown()
        Handler_MouseUp()
        Handler_MouseMove()
        '
        VerificaAlteracao = True
        '
    End Sub
#End Region
    '
#Region "BINDING"
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblIDCredor.DataBindings.Add("Text", BindCred, "IDPessoa")
        txtCadastro.DataBindings.Add("Text", BindCred, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCNP.DataBindings.Add("Text", BindCred, "CNP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEndereco.DataBindings.Add("Text", BindCred, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", BindCred, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", BindCred, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", BindCred, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", BindCred, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneA.DataBindings.Add("Text", BindCred, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneB.DataBindings.Add("Text", BindCred, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", BindCred, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' --- valor definido ao alterar o cmbTipo
        ' txtCNP.DataBindings.Add("Text", BindCred, "CredorPJ.CNPJ", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDCredor.DataBindings("Text").Format, AddressOf idFormatRG
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Credor.AoAlterar, AddressOf HandlerAoAlterar
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
#Region "CARREGA E CONTROLA COMBOS"
    '
    ' CARREGA OS COMBOBOX
    '--------------------------------------------------------------------------------------------------------
    Private Sub CarregaComboTipo()
        Dim dtTipo As New DataTable
        'Adiciona todas as possibilidades
        dtTipo.Columns.Add("IDTipo")
        dtTipo.Columns.Add("Tipo")
        dtTipo.Rows.Add(New Object() {0, "Simples"})
        dtTipo.Rows.Add(New Object() {1, "Pessoa Física"})
        dtTipo.Rows.Add(New Object() {2, "Pessoa Jurídica"})
        dtTipo.Rows.Add(New Object() {3, "Orgão Público"})
        With cmbCredorTipo
            .DataSource = dtTipo
            .ValueMember = "IDTipo"
            .DisplayMember = "Tipo"
            .SelectedValue = -1
            .DataBindings.Add("SelectedValue", BindCred, "CredorTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
    End Sub
    '
    ' COMBO TIPO ATUALIZAR ALTERA ESTADO DOS CONTROLES
    '--------------------------------------------------------------------------------------------------------
    Private Sub cmbCredorTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        '
        If VerificaAlteracao = False Then Exit Sub
        '
        propTipo = cmbCredorTipo.SelectedValue
        '
    End Sub
    '
    ' INIBE A ALTERACAO DO TIPO QUANDO NÃO FOR UM NOVO REGISTRO
    '--------------------------------------------------------------------------------------------------------
    Private Sub cmbCredorTipo_SelectedValueChanged(sender As Object, e As EventArgs)
        '
        If _Credor.CredorTipo = 0 Or _Credor.CredorTipo = 3 Then Exit Sub
        '
        If Sit <> EnumFlagEstado.NovoRegistro Then
            VerificaAlteracao = False
            cmbCredorTipo.SelectedValue = IIf(IsNothing(_Credor.CredorTipo), -1, _Credor.CredorTipo)
            VerificaAlteracao = True
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' CRIA UM ATALHO PARA OS COMBO BOX
    '------------------------------------------------------------------------------------------
    Private Sub cmbTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCredorTipo.KeyPress
        If Char.IsNumber(e.KeyChar) AndAlso Sit = EnumFlagEstado.NovoRegistro Then
            e.Handled = True
            '
            Dim dt As DataTable = cmbCredorTipo.DataSource
            Dim rCount As Integer = dt.Rows.Count
            Dim item As Integer = e.KeyChar.ToString
            '
            If item <= rCount And item > 0 Then
                Dim Valor As Integer = dt.Rows(e.KeyChar.ToString - 1)("IDTipo")
                '
                cmbCredorTipo.SelectedValue = Valor
                '
            End If
        End If
    End Sub
    '
#End Region
    '
#Region "FUNCOES UTILITARIAS"
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCadastro.KeyDown, txtCNP.KeyDown,
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
#Region "VALIDACAO DO CNP"
    '
    '=============================================================================================
    ' VALIDA CNPJ / CPF
    '=============================================================================================
    Private Sub txtCNP_Validating(sender As Object, e As CancelEventArgs) Handles txtCNP.Validating
        '
        ' Verifica o texto do CNP
        Dim CNP As String = ""
        '
        For Each c As Char In txtCNP.Text
            If IsNumeric(c) Then
                CNP = CNP & c.ToString
            End If
        Next
        '
        If CNP.Length > 0 AndAlso ValidaCNP() = False Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub
    '
    Private Sub txtCNP_Validated(sender As Object, e As EventArgs) Handles txtCNP.Validated
        '
        VerPessoaExistente()
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' FUNCAO QUE PROCURA UMA PESSOA PJ OU PF PELO CNP
    ' VERIFICA PESSOA EXISTENTE RETORNA UM clClientePF ou PJ
    '------------------------------------------------------------------------------------------
    Private Sub VerPessoaExistente()
        Dim db As New PessoaBLL
        Dim myPessoa As Object = Nothing
        '
        Try
            myPessoa = db.ProcurarCNP_Pessoa(txtCNP.Text, PessoaBLL.EnumPessoaGrupo.CREDOR)
            '
            ' NÃO ENCOTROU NENHUM CLIENTE NO CPF/CNPJ RETORNA NOVO CLIENTE
            If IsNothing(myPessoa) Then
                Exit Sub
            End If
            '
            ' VERIFICA SE A PESSOA ENCONTRADA É PF OU PJ
            If txtCNP.TextLength = 14 Then ' PESSOA FÍSICA
                '
                Dim myPF As clPessoaFisica = DirectCast(myPessoa, clPessoaFisica)
                '
                txtCadastro.Text = myPF.Cadastro
                txtEndereco.Text = myPF.Endereco
                txtBairro.Text = myPF.Bairro
                txtCidade.Text = myPF.Cidade
                txtUF.Text = myPF.UF
                txtCEP.Text = myPF.CEP
                txtTelefoneA.Text = myPF.TelefoneA
                txtTelefoneB.Text = myPF.TelefoneB
                txtEmail.Text = myPF.Email
                '
            ElseIf txtCNP.TextLength = 18 Then ' PESSOA JURIDICA
                '
                Dim myPJ As clPessoaJuridica = DirectCast(myPessoa, clPessoaJuridica)
                '
                txtCadastro.Text = myPJ.Cadastro
                txtEndereco.Text = myPJ.Endereco
                txtBairro.Text = myPJ.Bairro
                txtCidade.Text = myPJ.Cidade
                txtUF.Text = myPJ.UF
                txtCEP.Text = myPJ.CEP
                txtTelefoneA.Text = myPJ.TelefoneA
                txtTelefoneB.Text = myPJ.TelefoneB
                txtEmail.Text = myPJ.Email
                '
            End If
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu: " & ex.Message,
                            "Falha na procura de CPF/CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    ' VALIDAR O NÚMERO DO CNPJ OU CPF
    Private Function ValidaCNP() As Boolean
        Dim obj As New Valida_CPF_CNPJ
        '
        Try
            If propTipo = 1 Then
                obj.cpf = txtCNP.Text
                If obj.isCpfValido = False Then
                    MessageBox.Show("O CPF digitado é inválido!", "CPF inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                Else
                    Return True
                End If
            ElseIf propTipo = 2 Then
                obj.cnpj = txtCNP.Text
                If obj.isCnpjValido = False Then
                    MessageBox.Show("O CNPJ digitado é inválido!", "CNPJ inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
        '
    End Function
    '
    Private Sub txtCNP_GotFocus(sender As Object, e As EventArgs) Handles txtCNP.GotFocus
        '
        txtCNP.SelectAll()
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
            If f.VerificaControlesForm(txtCNP, "CPF/CNPJ", EProvider) = False Then
                Return False
            End If

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