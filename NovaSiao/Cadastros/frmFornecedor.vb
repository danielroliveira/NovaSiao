Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmFornecedor
    Private _forn As clFornecedor
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private BindForn As New BindingSource
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
#Region "LOAD E PROPERTIES"
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnCancelar.Enabled = False
                btnProcurar.Enabled = True
                txtCNPJ.ReadOnly = True
            ElseIf _Sit = enumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                btnProcurar.Enabled = False
                txtCNPJ.ReadOnly = True
            ElseIf _Sit = enumFlagEstado.NovoRegistro Then
                txtRazaoSocial.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                btnProcurar.Enabled = False
                txtCNPJ.ReadOnly = False
                lblID.Text = "NOVO"
            End If
        End Set
    End Property
    '
    Public Property propForn() As clFornecedor
        Get
            Return _forn
        End Get
        Set(ByVal value As clFornecedor)
            _forn = value
            BindForn.DataSource = _forn
            AtivoButtonImage()
        End Set
    End Property
    '
    Sub New(objForn As clFornecedor)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        If IsNothing(objForn) Then
            MessageBox.Show("Esse formulário não pode ser aberto assim...", "Erro ao abrir")
        End If
        '
        propForn = objForn
        PreencheDataBindings()
        '
        If Not IsNothing(_forn.IDPessoa) Then
            Sit = EnumFlagEstado.RegistroSalvo
            lblID.Text = Format(_forn.IDPessoa, "0000")
        Else
            Sit = EnumFlagEstado.NovoRegistro
            ' OBTER OS VALORES DEFAULT DOS CAMPOS
            _forn.Cidade = ObterDefault("Cidade")
            _forn.UF = ObterDefault("UF")
        End If
        '
    End Sub
    '
    Private Sub frmFornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandlerControles() ' adiciona o handler para selecionar e usar tab com a tecla enter
    End Sub
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
    '--- BTN NOVO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        propForn = New clFornecedor
        Sit = EnumFlagEstado.NovoRegistro
        txtRazaoSocial.Focus()
    End Sub
    '
    '--- BTN CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If Sit = EnumFlagEstado.NovoRegistro Then
            btnProcurar_Click(btnCancelar, New EventArgs)
            '
        ElseIf Sit = enumFlagEstado.Alterado Then
            BindForn.CancelEdit()
        End If
        '
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    '--- BTN PROCURAR
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode INATIVAR um Novo Fornecedor...", "Inativar Fornecedor",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim transp As clFornecedor = BindForn.Current

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
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        Dim transp As clFornecedor = BindForn.Current

        If transp.Ativo = True Then ' Nesse caso é Fornecedor Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Ativo"
        ElseIf transp.Ativo = False Then ' Nesse caso é Fornecedor Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Inativo"
        End If
    End Sub
    '
    '--- BTN FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        AutoValidate = AutoValidate.Disable
        Me.Close()
        MostraMenuPrincipal()
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
        If Not f.VerificaControlesForm(txtVendedor, "Nome do Vendedor", EProvider) Then
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
#Region "VALIDACAO DO CNPJ/CPF"
    '--------------------------------------------------------------------------------------------------------------------------------------
    ' VALIDA O CNPJ - PROCURA UMA PESSOA COM MESMO CNPJ 
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Sub txtCNPJ_Leave(sender As Object, e As EventArgs) Handles txtCNPJ.Leave
        '
        If Sit <> EnumFlagEstado.NovoRegistro Then Exit Sub
        '
        ' verifica somente os numeros do CPF
        Dim CNPJ As String = ""
        CNPJ = txtCNPJ.Text
        CNPJ = CNPJ.Replace(".", String.Empty)
        CNPJ = CNPJ.Replace("-", String.Empty)
        CNPJ = CNPJ.Replace("/", String.Empty)
        CNPJ = CNPJ.Replace("_", String.Empty)
        '
        ' se nao houver numero nenhum entao sai
        If String.IsNullOrWhiteSpace(CNPJ) Then Exit Sub
        '
        ' verifica a quantidade de caracteres digitados
        If CNPJ.Length <> 14 Then
            MessageBox.Show("Digite apenas números no CNPJ e apenas 14 dígitos...",
                            "CNPJ inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCNPJ.Focus()
            txtCNPJ.SelectAll()
            Exit Sub
        End If
        '
        '--- Verifica a validade do CNPJ
        If ValidaCNPJ() = False Then
            txtCNPJ.Focus()
            txtCNPJ.SelectAll()
            Exit Sub
        End If
        '
        'VERIFICAR SE O CNPJ JÁ ESTÁ CADASTRADO COMO PESSOA OU FORNECEDOR
        Dim transp As Object = VerPessoaExistente()
        '
        If IsNothing(transp) Then Exit Sub
        '
        Select Case transp.GetType()
            Case Is = GetType(clPessoaJuridica) ' É APENAS PessoaJuridica
                If MessageBox.Show("Já Existe PESSOA JURÍDICA cadastrada com esse mesmo CNPJ:" & vbCrLf & vbCrLf &
                                   DirectCast(transp, clPessoaJuridica).Cadastro.ToUpper & vbCrLf & vbCrLf &
                                   "Deseja preencher os dados automaticamente com as informações dessa pessoa?",
                                   "Copiar os Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    '
                    Dim t As New clPessoaJuridica
                    t = DirectCast(transp, clPessoaJuridica)
                    '
                    '--- PREENCHE OS DADOS AUTOMATICAMENTE
                    txtRazaoSocial.Text = t.Cadastro
                    txtNomeFantasia.Text = t.NomeFantasia
                    txtInscricao.Text = t.InscricaoEstadual
                    txtEndereco.Text = t.Endereco
                    txtBairro.Text = t.Bairro
                    txtCidade.Text = t.Cidade
                    txtUF.Text = t.UF
                    txtCEP.Text = t.CEP
                    txtTelefoneA.Text = t.TelefoneA
                    txtTelefoneB.Text = t.TelefoneB
                    txtEmail.Text = t.Email
                    txtFundacaoData.Text = t.FundacaoData
                    txtContatoNome.Text = t.ContatoNome
                    '
                End If
            Case Is = GetType(clFornecedor) ' JÁ é um FUNCIONARIO
                MessageBox.Show("Já existe um FORNECEDOR cadastrado com esse mesmo CNPJ..." & vbCrLf & vbNewLine &
                                "Não é possível inserir um novo FORNECEDOR com o mesmo CNPJ",
                                "CNPJ Já existe como FORNECEDOR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCNPJ.Text = String.Empty
                txtCNPJ.Focus()
        End Select
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------------------
    ' FUNÇÃO QUE VALIDA O CPF
    '---------------------------------------------------------------------------------------------------
    Private Function ValidaCNPJ() As Boolean
        Dim vCPF As New Valida_CPF_CNPJ
        vCPF.cnpj = txtCNPJ.Text
        '
        If vCPF.isCnpjValido = False Then
            MessageBox.Show("O número de CNPJ digitado é inválido." & vbNewLine &
                            "Digite um CNPJ válido por favor...", "CNPJ Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCNPJ.Focus()
            txtCNPJ.SelectAll()
            Return False
        Else
            Return True
        End If
    End Function
    '
    '---------------------------------------------------------------------------------------------------
    ' FUNCAO QUE VERIFICA PESSOA EXISTENTE RETORNA UM clFornecedor
    '---------------------------------------------------------------------------------------------------
    Private Function VerPessoaExistente() As Object
        Dim db As New PessoaBLL
        Dim myPessoa As Object = Nothing
        '
        Try
            myPessoa = db.ProcurarCNP_Pessoa(txtCNPJ.Text, PessoaBLL.EnumPessoaGrupo.FORNECEDOR)
            '
            ' NÃO ENCOTROU NENHUM CLIENTE NO CPF/CNPJ RETORNA NOVO CLIENTE
            If IsNothing(myPessoa) Then Return Nothing
            '
            ' VERIFICA SE A PESSOA ENCONTRADA É PJ OU FORNECEDOR
            Return myPessoa
            '
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu: " & ex.Message,
                            "Falha na procura de CPF/CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------
    ' FUNCAO QUE CONTROLA A DIGITACAO DO CNPJ
    '---------------------------------------------------------------------------------------------------
    Private Sub txtCNPJ_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCNPJ.KeyPress
        ' NÃO PERMITIR DIGITAÇÃO DE LETRAS OU CONTROLES
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
        ' NÃO PERMITIR TEXTO MAIOR QUE 14 DÍGITOS
        If txtCNPJ.TextLength >= 14 And Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
        '
    End Sub
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
