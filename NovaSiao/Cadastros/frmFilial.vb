Imports CamadaBLL
Imports CamadaDTO

Public Class frmFilial
    '
    Private _filial As clFilialDados
    Private _formOrigem As Form
    Private BindFil As New BindingSource
    Dim _Sit As Byte
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
#Region "LOAD | NEW"
    '
    '--- SUB NEW
    Sub New(filial As clFilialDados, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        propFilial = filial
        NewCommon()
        '
    End Sub
    '
    '--- SUB NEW
    Sub New(filial As clFilial, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        '--- convert clFilial in clFilialDados
        Dim FilialDados As New clFilialDados
        '
        If Not IsNothing(filial.IDPessoa) Then
            FilialDados = If(GetFilialDados(filial.IDPessoa), New clFilialDados)
        End If
        '
        propFilial = FilialDados
        NewCommon()
        '
    End Sub
    '
    '--- SUB NEW COMMOM
    Private Sub NewCommon()
        '
        BindFil.DataSource = _filial
        PreencheDataBindings()
        '
        HandlerKeyDownControl()
        '
    End Sub
    '
    ' PROPRIEDADE SIT
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                lblID.Text = If(Format(_filial.IDPessoa, "0000"), "")
                btnSalvar.Enabled = False
                btnCancelar.Enabled = False
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtApelidoFilial.Focus()
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
                lblID.Text = "NOVA"
            End If
        End Set
    End Property
    '
    Public Property propFilial() As clFilialDados
        '
        Get
            Return _filial
        End Get
        '
        Set(ByVal value As clFilialDados)
            '
            _filial = value
            '
            If IsNothing(value.IDPessoa) Then
                Sit = EnumFlagEstado.NovoRegistro
            Else
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
            BindFil.DataSource = _filial
            AtivoButtonImage()
            '
        End Set
        '
    End Property
    '
    Private Function GetFilialDados(IDFilial As Integer) As clFilialDados
        '
        Dim fBLL As New FilialBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Return fBLL.GetFilialDados(IDFilial)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter os Dados da Filial..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
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
        lblID.DataBindings.Add("Tag", BindFil, "IDPessoa")
        txtRazaoSocial.DataBindings.Add("Text", BindFil, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNomeFantasia.DataBindings.Add("Text", BindFil, "NomeFantasia", True, DataSourceUpdateMode.OnPropertyChanged)
        txtApelidoFilial.DataBindings.Add("Text", BindFil, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCNPJ.DataBindings.Add("Text", BindFil, "CNPJ", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIncricao.DataBindings.Add("Text", BindFil, "InscricaoEstadual", True, DataSourceUpdateMode.OnPropertyChanged)
        txtAliquotaICMS.DataBindings.Add("Text", BindFil, "AliquotaICMS", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEndereco.DataBindings.Add("Text", BindFil, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", BindFil, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", BindFil, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", BindFil, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", BindFil, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefonePrincipal.DataBindings.Add("Text", BindFil, "TelefonePrincipal", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneGerencia.DataBindings.Add("Text", BindFil, "TelefoneGerencia", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneFinanceiro.DataBindings.Add("Text", BindFil, "TelefoneFinanceiro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtContatoGerencia.DataBindings.Add("Text", BindFil, "ContatoGerencia", True, DataSourceUpdateMode.OnPropertyChanged)
        txtContatoFinanceiro.DataBindings.Add("Text", BindFil, "ContatoFinanceiro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNumeroWhatsapp.DataBindings.Add("Text", BindFil, "NumeroWhatsapp", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", BindFil, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler txtAliquotaICMS.DataBindings("Text").Format, AddressOf idFormatDesc
        AddHandler BindFil.CurrentChanged, AddressOf handler_CurrentChanged
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(BindFil.CurrencyManager.Current, clFilialDados).AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(BindFil.CurrencyManager.Current, clFilialDados).AoAlterar, AddressOf HandlerAoAlterar
        '
        '--- Nesse caso é um novo registro
        If IsNothing(DirectCast(BindFil.Current, clFilialDados).IDPessoa) Then
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
        If BindFil.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
    ' FORMATA OS BINDINGS
    Private Sub idFormatDesc(sender As Object, e As ConvertEventArgs)
        If IsDBNull(e.Value) Then Exit Sub
        e.Value = Format(e.Value, "#,##0.00")
    End Sub
    '
#End Region
    '
#Region "ACAO BOTOES"
    '
    '--- FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        AutoValidate = AutoValidate.Disable
        Close()
    End Sub
    '
    '--- BTN CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        AutoValidate = AutoValidate.Disable
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
    '--- BTN PROCURAR
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR uma Nova Filial...", "Desativar Filial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim filial As clFilialDados = BindFil.Current
        '
        If filial.Ativo = True Then ' Filial Ativo
            '
            If MessageBox.Show("Você deseja realmente DESATIVAR a Filial:" & vbNewLine &
                        txtApelidoFilial.Text.ToUpper, "Inativar Filial", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                filial.BeginEdit()
                filial.Ativo = False
                AtivoButtonImage()
            End If
            '
        ElseIf filial.Ativo = False Then ' Filial Inativo
            '
            If MessageBox.Show("Você deseja realmente ATIVAR a Filial:" & vbNewLine &
            txtApelidoFilial.Text.ToUpper, "Ativar Filial", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                filial.BeginEdit()
                filial.Ativo = True
                AtivoButtonImage()
            End If
            '
        End If
        '
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        Dim filial As clFilial = BindFil.Current
        '
        If filial.Ativo = True Then ' Nesse caso é Filial Ativa
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Ativa"
        ElseIf filial.Ativo = False Then ' Nesse caso é Filial Inativa
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Inativa"
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLES"
    '
    '---------------------------------------------------------------------------------------
    ' ADD HANDLER EVENTO KEYDOWN DOS CONTROLES COM VTAB
    '---------------------------------------------------------------------------------------
    Private Sub HandlerKeyDownControl()
        '
        '--- Tipos de Controles
        Dim myTypes As Type() = {GetType(TextBox),
                                 GetType(ComboBox),
                                 GetType(MaskedTextBox),
                                 GetType(Controles.Text_Monetario)}
        '
        '--- para cada TabPage no tabPrincipal
        For Each c As Control In Me.Controls
            '
            If myTypes.Contains(c.GetType) Then
                AddHandler c.KeyDown, AddressOf txtControl_KeyDown
            End If
            '
        Next
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    '---------------------------------------------------------------------------------------
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs)
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    ' EVITA DIGITACAO DE TEXTO
    '---------------------------------------------------------------------------------------
    Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAliquotaICMS.KeyPress
        '
        If Char.IsNumber(e.KeyChar) OrElse New Char() {vbBack, ","}.Contains(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "."c Then
            DirectCast(sender, TextBox).SelectedText = ","
            e.Handled = True
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
#End Region '/ CONTROLES
    '
#Region "SALVAR REGISTRO"
    '
    ' SALVAR O REGISTRO
    '-----------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- Get Authorization
        If Not GetAuthorization(EnumAcessoTipo.Administrador, "Inserir Nova Filial", Me) Then Exit Sub
        '
        '--- check if Apelido and Aliquota is OK
        If Not VerificaCampos() Then Return
        '
        '--- SAVE
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim db As New PessoaBLL
            '
            If Sit = EnumFlagEstado.NovoRegistro Then '--> SAVE NEW
                '
                Dim resolve As Object = db.InsertNewPessoa(_filial, PessoaBLL.EnumPessoaGrupo.FILIAL)
                '
                If Not IsNumeric(resolve) Then
                    Throw New Exception("Uma exceção inesperada ocorreu ao Salvar Registro")
                    Return
                End If
                '
                _filial.IDPessoa = resolve
                lblID.DataBindings.Item("Tag").ReadValue()
                '
            ElseIf Sit = EnumFlagEstado.Alterado Then '--> UPDATE
                '
                db.UpdatePessoa(_filial, PessoaBLL.EnumPessoaGrupo.FILIAL)
                '
            End If
            '
            MessageBox.Show("Filial Salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BindFil.EndEdit()
            Sit = EnumFlagEstado.RegistroSalvo
            '
            DialogResult = DialogResult.OK
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inserir Nova Filial..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Function VerificaCampos() As Boolean
        '
        '--- FILIAL NAME
        '----------------------------------------------------------------------------------
        '
        '--- Tamanho Mínimo
        If txtApelidoFilial.Text.Length < 5 Then
            MessageBox.Show("O Apelido da Filial deve ter no mínimo de 5 caracteres...",
                            "Preecha os Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtApelidoFilial.Focus()
            Return False
        End If
        '
        '---Check CNPJ
        Dim checkCNPJ As String = txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "")
        '
        If checkCNPJ.Length = 0 OrElse Not IsNumeric(checkCNPJ) OrElse checkCNPJ.Length <> 14 Then
            MessageBox.Show("O CNPJ deve conter um valor válido",
                            "Preecha os Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCNPJ.Focus()
            txtCNPJ.SelectAll()
            Return False
        Else
            If ValidaCNP() = False Then
                MessageBox.Show("O CNPJ deve conter um valor válido",
                "Preecha os Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCNPJ.Focus()
                txtCNPJ.SelectAll()
                Return False
            End If

        End If
        '
        '--- Transforma primeira em Maiuscula
        txtApelidoFilial.Text = Utilidades.PrimeiraLetraMaiuscula(txtApelidoFilial.Text)
        '
        '--- PROCURAR MESMO CADASTRO NOME
        '----------------------------------------------------------------------------------
        Dim db As New PessoaBLL
        Dim pes As clPessoa = db.ProcuraPessoaPeloCadastroNome(txtApelidoFilial.Text)
        '
        If Not IsNothing(pes) Then
            '
            If IsNothing(_filial.IDPessoa) OrElse _filial.IDPessoa = 0 Then '--> NOVO REGISTRO
                '
                MessageBox.Show("Já existe um cadastro de 'PESSOA' com esse mesmo 'NOME'...")
                txtApelidoFilial.Focus()
                Return False
                '
            Else '---> REGISTRO SALVO
                '
                If _filial.IDPessoa <> pes.IDPessoa Then
                    MessageBox.Show("Já existe um cadastro de 'PESSOA' com esse mesmo 'NOME'...")
                    txtApelidoFilial.Focus()
                    Return False
                End If
                '
            End If
            '
        End If
        '
        '--- ALIQUOTA ICMS
        '----------------------------------------------------------------------------------
        '
        If txtAliquotaICMS.Text.Trim.Length = 0 Then txtAliquotaICMS.Text = "0"
        '
        Dim icms As Double = 0
        Double.TryParse(txtAliquotaICMS.Text, icms)
        '
        If icms < 0 OrElse icms > 99 Then
            MessageBox.Show("O valor da Alíquota do ICMS deve estar entre 0 e 99")
            txtAliquotaICMS.Focus()
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    ' VALIDAR O NÚMERO DO CNPJ OU CPF
    Private Function ValidaCNP() As Boolean
        '
        Dim obj As New Valida_CPF_CNPJ
        '
        Try
            '
            obj.cnpj = txtCNPJ.Text
            '
            If obj.isCnpjValido = False Then
                MessageBox.Show("O CNPJ digitado é inválido!", "CNPJ inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                Return True
            End If
            '
        Catch ex As Exception
            '
            MessageBox.Show(ex.Message, "Erro inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            '
        End Try
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
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmAPagarItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region
    '
End Class
