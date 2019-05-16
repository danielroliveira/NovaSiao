Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmClientePJ
    '
#Region "PRIVATE VARIAVEIS" ' DECLARAÇÃO DE VARIÁVEIS
    Private WithEvents _ClientePJ As clClientePJ
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private WithEvents BindingCliente As New BindingSource
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    Private _acao As EnumFlagAcao
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
                btnProcurar.Enabled = True
                btnImprimir.Enabled = True
                btnCancelar.Enabled = False
                lblIDCliente.Text = Format(_ClientePJ.IDPessoa, "0000")
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnProcurar.Enabled = False
                btnImprimir.Enabled = True
                btnCancelar.Enabled = True
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtCadastroNome.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnProcurar.Enabled = False
                btnImprimir.Enabled = False
                btnCancelar.Enabled = False
                lblIDCliente.Text = "NOVO"
                ' OBTER OS VALORES DEFAULT DOS CAMPOS
                txtCidade.Text = ObterDefault("Cidade")
                txtUF.Text = ObterDefault("UF")
                AtivoButtonImage()
            End If
        End Set
    End Property
#End Region
    '
#Region "FORM LOAD" ' FORM LOAD
    '
    Public Sub New(myAcao As EnumFlagAcao, myClientePJ As clClientePJ)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propClientePJ = myClientePJ
        propAcao = myAcao
        HandlerKeyDownControl()
        '
        dtpDataFundacao.MaxDate = Today
        '
    End Sub
    '
    '--- Propriedade propClientePJ
    Public Property propClientePJ() As clClientePJ
        '
        Get
            Return _ClientePJ
        End Get
        '
        Set(ByVal value As clClientePJ)
            '
            _ClientePJ = value
            '
            If IsNothing(BindingCliente.DataSource) Then
                BindingCliente.DataSource = _ClientePJ
                PreencheDataBindings()
            Else
                BindingCliente.Clear()
                BindingCliente.DataSource = _ClientePJ
                BindingCliente.ResetBindings(True)
                AddHandler _ClientePJ.AoAlterar, AddressOf HandlerAoAlterar
            End If
            '
            dtpDataFundacao.Checked = Not IsNothing(_ClientePJ.FundacaoData)
            '
        End Set
        '
    End Property
    '
    Public Property propAcao As EnumFlagAcao
        '
        Get
            Return _acao
        End Get
        '
        Set(value As EnumFlagAcao)
            '
            _acao = value
            '
            If value = EnumFlagAcao.INSERIR Then
                '
                Sit = EnumFlagEstado.NovoRegistro
                '
                dtpDataFundacao.Checked = False
                dtpDataFundacao.Value = Today
                '
            ElseIf value = EnumFlagAcao.EDITAR Then
                '
                Sit = EnumFlagEstado.RegistroSalvo
                '
                dtpDataFundacao.Checked = Not IsNothing(_ClientePJ.FundacaoData)
                '
            End If
            '
        End Set
        '
    End Property
    '
    Private Sub frmClientesPJ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = frmPrincipal
    End Sub
    '
#End Region
    '
#Region "BINDINGS"
    '
    Private Sub PreencheDataBindings()
        '
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        lblIDCliente.DataBindings.Add("Tag", BindingCliente, "IDPessoa")
        txtCadastroNome.DataBindings.Add("Text", BindingCliente, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCNPJ_Texto.DataBindings.Add("Text", BindingCliente, "CNPJ", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNomeFantasia.DataBindings.Add("Text", BindingCliente, "NomeFantasia", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEndereco.DataBindings.Add("Text", BindingCliente, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", BindingCliente, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", BindingCliente, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", BindingCliente, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", BindingCliente, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneA.DataBindings.Add("Text", BindingCliente, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneB.DataBindings.Add("Text", BindingCliente, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", BindingCliente, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacoes.DataBindings.Add("Text", BindingCliente, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtLimiteCompras.DataBindings.Add("Text", BindingCliente, "LimiteCompras", True, DataSourceUpdateMode.OnPropertyChanged)
        txtRGCliente.DataBindings.Add("Text", BindingCliente, "RGCliente", True, DataSourceUpdateMode.OnPropertyChanged)
        txtInscricaoEstadual.DataBindings.Add("Text", BindingCliente, "InscricaoEstadual", True, DataSourceUpdateMode.OnPropertyChanged)
        txtContatoNome.DataBindings.Add("Text", BindingCliente, "ContatoNome", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpDataFundacao.DataBindings.Add("Value", BindingCliente, "FundacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDCliente.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler txtLimiteCompras.DataBindings("text").Format, AddressOf idFormatCUR
        AddHandler txtRGCliente.DataBindings("text").Format, AddressOf idFormatRG
        '
        ' CARREGA OS COMBOBOX
        CarregaAtividade()
        '
        ' ADD HANDLER PARA DATABINGS
        'AddHandler BindingCliente.CurrentItemChanged, AddressOf HandlerAlteraSit
        AddHandler _ClientePJ.AoAlterar, AddressOf HandlerAoAlterar
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _ClientePJ.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    '
    Private Sub idFormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    ' CARREGA OS COMBOBOX
    '--------------------------------------------------------------------------------------------------------
    Private Sub CarregaAtividade()
        Dim cliBLL As New ClienteBLL
        '
        Try
            Dim dtAtiv As DataTable = cliBLL.GetClienteAtividades(True)
            '
            With cmbRGAtividade
                .DataSource = dtAtiv
                .ValueMember = "RGAtividade"
                .DisplayMember = "Atividade"
                .DataBindings.Add("SelectedValue", BindingCliente, "RGAtividade", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        '
    End Sub
    '--------------------------------------------------------------------------------------------------------
#End Region
    '
#Region "SALVAR REGISTRO"
    '
    ' SALVAR O REGISTRO
    '---------------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        '--- verifica os dados se os campos estão preechidos
        If VerificaDados() = False Then Exit Sub

        '--- procurar se já existe cliente com o mesmo RGCLIENTE
        If VerificaRGCliente() = False Then Exit Sub

        '--- define os dados da classe
        Dim NewCliID As Long
        Dim pessoaBLL As New PessoaBLL
        _ClientePJ.PessoaTipo = 2 '--> PJ
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            'Salva o Cliente, mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
            If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
                '
                Dim response = pessoaBLL.InsertNewPessoa(_ClientePJ, PessoaBLL.EnumPessoaGrupo.CLIENTE)
                '
                If TypeOf response Is Integer Then
                    NewCliID = response
                Else
                    Throw New Exception("Já existe CLIENTE com mesmo CNPJ...")
                End If
                '
            ElseIf _Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
                '
                If pessoaBLL.UpdatePessoa(_ClientePJ, PessoaBLL.EnumPessoaGrupo.CLIENTE) Then
                    NewCliID = _ClientePJ.IDPessoa
                End If
                '
            End If
        Catch ex As Exception
            MsgBox("Um erro ocorreu ao salvar o registro!" & vbCrLf &
                   ex.Message, vbCritical, "Erro ao Salvar")
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try

        'Verifica se houve Retorno da Função de Salvar
        If NewCliID <> 0 Then
            '
            'Retorna o número de Registro do Novo Aluno Cadastrado
            If _Sit = EnumFlagEstado.NovoRegistro Then
                lblIDCliente.Tag = NewCliID
                lblIDCliente.Text = Format(lblIDCliente.Tag, "D4")
            End If
            '
            'Altera a Situação
            Sit = EnumFlagEstado.RegistroSalvo
            BindingCliente.CurrencyManager.EndCurrentEdit()
            '
            'Mensagem
            MsgBox("Registro Salvo com sucesso!", vbInformation, "Registro Salvo")
            '
            '--- Mostra frmAcao após salvar
            Dim frmAcao As New frmClienteAcoesDialog(Me)
            frmAcao.ShowDialog()
            '
        Else
            MsgBox("Registro NÃO pode ser salvo!", vbInformation, "Erro ao Salvar")
        End If
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' FAZER VERIFICAÇÃO ANTES DE SALVAR
    '-------------------------------------------------------------------------------------------------------
    Private Function VerificaDados() As Boolean
        '
        Dim f As New FuncoesUtilitarias
        '
        'Se nenhuma das condições acima forem verdadeira retorna TRUE
        EProvider.Clear()
        '
        'Verifica o campo nome
        If Not f.VerificaControlesForm(txtCadastroNome, "Nome do Cliente", EProvider) Then
            Return False
        End If
        '
        'Verifica o campo Atividade do Cliente
        If Not f.VerificaControlesForm(cmbRGAtividade, "Atividade do Cliente", EProvider) Then
            Return False
        End If
        '
        'Verifica o campo Atividade do Cliente
        If dtpDataFundacao.Checked = False Then
            _ClientePJ.FundacaoData = Nothing
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtEndereco, "Endereço do Cliente", EProvider) Then
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtBairro, "Bairro da localidade do Cliente", EProvider) Then
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtCidade, "Cidade  da localidade do Cliente", EProvider) Then
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtUF, "Estado/UF da localidade do Cliente", EProvider) Then
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtCEP, "CEP da localidade do Cliente", EProvider) Then
            Return False
        End If
        '
        'Verifica o limite de crédito
        If Not f.VerificaControlesForm(txtLimiteCompras, "Limite de Compras", EProvider) Then
            Return False
        End If
        'Se nenhuma das condições acima forem verdadeira retorna TRUE
        EProvider.Clear()
        '
        Return True
        '
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    ' VERIFICA O RGCLIENTE
    '-------------------------------------------------------------------------------------------------------
    Private Function VerificaRGCliente() As Boolean
        Dim db As New PessoaBLL
        '
        'SE O CAMPO RGCLIENTE ESTIVER VAZIO
        '-------------------------------------------------------------------------------------------------------
        If String.IsNullOrWhiteSpace(txtRGCliente.Text) Then
            Dim r As DialogResult
            r = MessageBox.Show("O campor Registro Anterior do Cliente está vazio..." & vbNewLine &
                            "Você deseja que o sistema preencha automaticamente o valor desse campo?",
                            "Campo Vazio", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button3)
            If r = DialogResult.Yes Then
                ' Procura o valor para o campo
                Dim NextRG As Integer? = db.ProcurarNextRG()
                '
                If Not IsNothing(NextRG) Then
                    txtRGCliente.Text = Format(NextRG, "0000")
                    Return True
                Else
                    Return False
                End If
            ElseIf r = DialogResult.No Then
                txtRGCliente.Focus()
                Return False
            End If
        End If
        '
        'SE O CAMPO RGCLIENTE NÃO ESTIVER VAZIO VERIFICA DUPLICIDADE
        '-------------------------------------------------------------------------------------------------------
        Dim CliRG As Object = db.ProcurarCliente_RG_Cliente(CInt(txtRGCliente.Text))
        '
        If IsNothing(CliRG) Then
            Return True
        Else
            Dim strCli As String = ""
            Dim intID As Integer? = Nothing
            '
            '--- VERIFICA QUAL O NOME DO CLIENTE ENCONTRADO
            If CliRG.GetType = GetType(clClientePF) Then '--- retornou uma PESSOA FÍSICA
                strCli = DirectCast(CliRG, clClientePF).Cadastro.ToUpper
                intID = DirectCast(CliRG, clClientePF).IDPessoa
            Else '--- RETORNOU UMA PESSOA JURÍDICA
                strCli = DirectCast(CliRG, clClientePJ).Cadastro.ToUpper
                intID = DirectCast(CliRG, clClientePJ).IDPessoa
            End If
            '
            If intID <> _ClientePJ.IDPessoa Then '--- NESSE CASO NÃO É O MESMO CLIENTE
                MessageBox.Show("Já foi encontrado Cliente com esse mesmo número de Reg. Anterior..." & vbNewLine &
                                strCli.ToUpper & vbNewLine & "Insira outro Reg. Anterior ou altere o registro do outro Cliente.",
                                "Reg. Anterior Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRGCliente.Focus()
                Return False
            Else
                Return True '--- NÃO É O MESMO CLIENTE
            End If
        End If
    End Function
    '
    '-----------------------------------------------------------------------------------------
    ' FUNÇÃO PUBLICA QUE REALIZA AÇÕES A PARTIR DO frmClienteAcoesDialog
    '-----------------------------------------------------------------------------------------
    Public Sub RealizaAcaoInterna(myAcao As String)
        '
        Select Case myAcao
            Case = "PERMANECER"
                txtCadastroNome.Focus()
            Case = "NOVO"
                btnNovo_Click(New Object, New System.EventArgs)
            Case = "PROCURAR"
                btnProcurar_Click(New Object, New System.EventArgs)
            Case = "FICHACADASTRO"
                MessageBox.Show("Ainda não está pronto")
            Case = "FICHACOBRANCA"
                MessageBox.Show("Ainda não está pronto")
            Case = "FECHAR"
                btnFechar_Click(New Object, New System.EventArgs)
        End Select
        '
    End Sub
    '---------------------------------------------------------------------------------------------------
#End Region
    '
#Region "FORMATAÇÃO"
    '
    '-------------------------------------------------------------------------------------------------------
    ' USAR SOMENTE NÚMERO NO CAMPO RGCLIENTE
    '-------------------------------------------------------------------------------------------------------
    Private Sub txtRGCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGCliente.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' SOMENTE NÚMERO, PONTO OU TRAÇO NA INSCRIÇÃO SOCIAL
    '-------------------------------------------------------------------------------------------------------
    Private Sub txtInscricaoEstadual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInscricaoEstadual.KeyPress
        Select Case Asc(e.KeyChar) 'Se a tecla for numérica (0 - 9) ,backspace (8) ou hifen(-)
            Case Asc("0") To Asc("9"), Asc("."), Asc("-"), Asc(vbBack)
                e.Handled = False
            Case Else
                e.Handled = True 'Cancela a entrada
        End Select
    End Sub
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
                                 GetType(Controles.Text_Monetario),
                                 GetType(DateTimePicker)}
        '
        '--- para cada Controle no TabPage
        For Each c As Control In Me.Controls
            '
            If myTypes.Contains(c.GetType) Then '--- se ocontrole for do tipo myTypes()
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
#End Region
    '
#Region "OPERAÇÕES DE REGISTRO"
    '
    '-------------------------------------------------------------------------------------------------------
    ' PROCURAR CLIENTE POR ID
    '-------------------------------------------------------------------------------------------
    Public Sub ProcurarClientePorID(RG As Integer)
        Dim cliBLL As New ClientePJ_BLL

        _ClientePJ = cliBLL.GetClientesPJ_PorID(RG)

        If IsNothing(BindingCliente.DataSource) Then
            BindingCliente.DataSource = _ClientePJ
            PreencheDataBindings()
        Else
            'RemoveHandler BindingCliente.CurrentItemChanged, AddressOf HandlerAlteraSit
            BindingCliente.Clear()
            BindingCliente.DataSource = _ClientePJ
            'AddHandler BindingCliente.CurrentItemChanged, AddressOf HandlerAlteraSit
            AddHandler _ClientePJ.AoAlterar, AddressOf HandlerAoAlterar
        End If

        Sit = EnumFlagEstado.RegistroSalvo
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' BTN PROCURAR CLIENTE
    '-------------------------------------------------------------------------------------------------------
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        Dim frm As New frmClienteProcurar(Me)
        frm.ShowDialog()
        '
        If frm.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Try
            If frm.propClienteEscolhido.PessoaTipo = 1 Then ' PESSOA FÍSICA
                ' ABRIR FORMULÁRIO CLIENTEPF
                Close()
                '
                Dim cliBll As New ClientePF_BLL
                '
                Dim myCliPF As clClientePF = cliBll.GetClientePF_PorID(frm.propClienteEscolhido.IDPessoa)
                Dim frmCli As New frmClientePF(EnumFlagAcao.EDITAR, myCliPF)
                frmCli.Show()
                '
            ElseIf frm.propClienteEscolhido.PessoaTipo = 2 Then ' PESSOA JURÍDICA
                ' ABRIR FORMULÁRIO CLIENTEPJ
                '
                Dim cliBLL As New ClientePJ_BLL
                '
                Dim myCliPJ As clClientePJ = cliBLL.GetClientesPJ_PorID(frm.propClienteEscolhido.IDPessoa)
                propClientePJ = myCliPJ
                propAcao = EnumFlagAcao.EDITAR
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '
    '------------------------------------------------------------------------------------------------
    ' CANCELAR ALTERAÇÃO DO REGISTRO ATUAL
    '-------------------------------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("Deseja cancelar todas as alterações feitas no registro atual?",
                           "Cancelar Alterações", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            BindingCliente.CancelEdit()
            txtCadastroNome.Focus()
            Sit = EnumFlagEstado.RegistroSalvo
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' ATIVAR OU DESATIVAR CLIENTE BOTÃO
    '-------------------------------------------------------------------------------------------------------
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR um Cliente Novo", "Desativar Cliente",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If _ClientePJ.IDSituacao = 1 Then ' Cliente ativo
            If MessageBox.Show("Você deseja realmente DESATIVAR o Cliente:" & vbNewLine &
                        txtCadastroNome.Text.ToUpper, "Desativar Cliente", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _ClientePJ.BeginEdit()
                _ClientePJ.IDSituacao = 2
                _ClientePJ.Situacao = "INATIVO"
                AtivoButtonImage()
            End If
        ElseIf _ClientePJ.IDSituacao = 2 Then ' Cliente Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR o Cliente:" & vbNewLine &
            txtCadastroNome.Text.ToUpper, "Ativar Cliente", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _ClientePJ.BeginEdit()
                _ClientePJ.IDSituacao = 1
                _ClientePJ.Situacao = "ATIVO"
                AtivoButtonImage()
            End If
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    '-------------------------------------------------------------------------------------------------------
    Private Sub AtivoButtonImage()
        If _ClientePJ.IDSituacao = 1 Then ' Nesse caso é Cliente Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = _ClientePJ.Situacao
        ElseIf _ClientePJ.IDSituacao = 2 Then ' Nesse caso é Cliente Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = _ClientePJ.Situacao
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' FECHA O FORMULÁRIO
    '-------------------------------------------------------------------------------------------------------
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        If Sit <> EnumFlagEstado.RegistroSalvo Then
            If MessageBox.Show("Esse registro ainda não foi salvo..." & vbNewLine & vbNewLine &
                               "Se você fechar agora, todas as alterações feitas serão perdidas!" & vbNewLine &
                               "Tem certeza que você deseja fechar esse registro?", "Registro Alterado",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        End If
        '
        Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' BOTÃO NOVO REGISTRO
    '-------------------------------------------------------------------------------------------------------
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        ' ABRE O FORM NOVOCLIENTE
        Dim frm As New frmClienteNovo
        frm.ShowDialog()
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' BOTÃO IMPRIMIR REGISTRO
    '-------------------------------------------------------------------------------------------------------
    Private Sub FichaCadastroToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FichaCadastroToolStripMenuItem1.Click
        MessageBox.Show("Essa Função ainda não foi implementada...")
    End Sub
#End Region
    '
#Region "OUTRAS FUNÇÕES"
    '
    '--- BOTÃO PROCURAR RGCLIENTE
    Private Sub btnProcuraRG_Click(sender As Object, e As EventArgs) Handles btnProcuraRG.Click
        If txtRGCliente.Text.Length > 0 Then
            If MessageBox.Show("Deseja substituir o Reg. Anterior desse Cliente" & vbNewLine &
                               "por um novo validado pelo sistema?", "Novo Reg. Anterior",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then
                txtRGCliente.Focus()
                Exit Sub
            End If
        End If
        '
        Dim db As New PessoaBLL
        Dim NextRG As Integer? = db.ProcurarNextRG()
        '
        If Not IsNothing(NextRG) Then
            txtRGCliente.Text = Format(NextRG, "0000")
        End If
        '
        txtRGCliente.Focus()
        '
    End Sub
    '
    '--- VERIFICA ALTERACAO NO CHECKBOX DO DTPICKER
    '----------------------------------------------------------------------------------
    Private Sub dtpDataFundacao_ValueChanged(sender As Object, e As EventArgs) Handles dtpDataFundacao.ValueChanged
        '
        If Not IsNothing(_ClientePJ) Then
            '
            If dtpDataFundacao.Checked = IsNothing(_ClientePJ.FundacaoData) Then
                If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
            End If
            '
        End If
        '
    End Sub
    '
#End Region
    '
End Class
