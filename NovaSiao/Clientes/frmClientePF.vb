Imports CamadaDTO
Imports CamadaBLL
Imports VIBlend.WinForms.Controls
'
Public Class frmClientePF
    '
    Private WithEvents _ClientePF As clClientePF
    Private dtRef As DataTable
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _acao As EnumFlagAcao
    Private WithEvents BindingCliente As New BindingSource
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
#Region "PROPERTYS" ' DECLARAÇÃO DE VARIÁVEIS
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
                lblIDCliente.Text = Format(_ClientePF.IDPessoa, "0000")
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnProcurar.Enabled = False
                btnImprimir.Enabled = True
                btnCancelar.Enabled = True
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtClienteNome.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnProcurar.Enabled = False
                btnImprimir.Enabled = False
                btnCancelar.Enabled = False
                lblIDCliente.Text = "NOVO"
                ' OBTER OS VALORES DEFAULT DOS CAMPOS
                txtCidade.Text = ObterDefault("CidadePadrao")
                txtNaturalidade.Text = ObterDefault("NaturalidadePadrao")
                txtUF.Text = ObterDefault("UFPadrao")
                AtivoButtonImage()
            End If
        End Set
    End Property
    '
    '--- Propriedade propClientePF
    Public Property propClientePF() As clClientePF
        Get
            Return _ClientePF
        End Get
        Set(ByVal value As clClientePF)
            _ClientePF = value
            '
            If IsNothing(BindingCliente.DataSource) Then
                BindingCliente.DataSource = _ClientePF
                PreencheDataBindings()
            Else
                BindingCliente.Clear()
                BindingCliente.DataSource = _ClientePF
                BindingCliente.ResetBindings(True)
                AddHandler _ClientePF.AoAlterar, AddressOf HandlerAoAlterar
            End If
            '
            '--- VERIFICA O ESTADO CIVIL PARA HABILITAR O CONJUGE
            cmbEstadoCivil_SelectedIndexChanged(New Object, New EventArgs)
            '
            ' GET e formatar o dgvReferencias pessoais
            If Not IsNothing(value.IDPessoa) Then
                Dim dbRef As New ClienteReferenciaBLL
                '
                dtRef = dbRef.ClienteReferencia_GET_PorID(value.IDPessoa)
                PreencheReferencias()
            Else
                FormataReferencias()
            End If
            '
        End Set
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
            ElseIf value = enumFlagAcao.EDITAR Then
                Sit = EnumFlagEstado.RegistroSalvo
            End If
        End Set
    End Property
    '
#End Region
    '
#Region "FORM LOAD" ' FORM NEW e LOAD
    '
    Public Sub New(myAcao As EnumFlagAcao, myClientePF As clClientePF)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propClientePF = myClientePF
        propAcao = myAcao
        '
        HandlerKeyDownControl()
        '
    End Sub
    '
    Private Sub frmClientesPF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        AddHandler dgvReferencias.CellValueChanged, AddressOf AlteraReferencia
        '
    End Sub
#End Region
    '
#Region "BINDINGS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA

        lblIDCliente.DataBindings.Add("Tag", BindingCliente, "IDPessoa")
        txtClienteNome.DataBindings.Add("Text", BindingCliente, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCPF_Texto.DataBindings.Add("Text", BindingCliente, "CPF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEndereco.DataBindings.Add("Text", BindingCliente, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", BindingCliente, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", BindingCliente, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", BindingCliente, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", BindingCliente, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneA.DataBindings.Add("Text", BindingCliente, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneB.DataBindings.Add("Text", BindingCliente, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", BindingCliente, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", BindingCliente, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtLimiteCompras.DataBindings.Add("Text", BindingCliente, "LimiteCompras", True, DataSourceUpdateMode.OnPropertyChanged)
        txtRGCliente.DataBindings.Add("Text", BindingCliente, "RGCliente", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpNascimentoData.DataBindings.Add("Value", BindingCliente, "NascimentoData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNaturalidade.DataBindings.Add("Text", BindingCliente, "Naturalidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPai.DataBindings.Add("Text", BindingCliente, "Pai", True, DataSourceUpdateMode.OnPropertyChanged)
        txtMae.DataBindings.Add("Text", BindingCliente, "Mae", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIdentidade.DataBindings.Add("Text", BindingCliente, "Identidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIdentidadeOrgao.DataBindings.Add("Text", BindingCliente, "IdentidadeOrgao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIdentidadeData.DataBindings.Add("Text", BindingCliente, "IdentidadeData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTrabalhoContratante.DataBindings.Add("Text", BindingCliente, "TrabalhoContratante", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTrabalhoFuncao.DataBindings.Add("Text", BindingCliente, "TrabalhoFuncao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTrabalhoTelefone.DataBindings.Add("Text", BindingCliente, "TrabalhoTelefone", True, DataSourceUpdateMode.OnPropertyChanged)
        txtRenda.DataBindings.Add("Text", BindingCliente, "Renda", True, DataSourceUpdateMode.OnPropertyChanged)
        txtConjuge.DataBindings.Add("Text", BindingCliente, "Conjuge", True, DataSourceUpdateMode.OnPropertyChanged)
        txtConjugeRenda.DataBindings.Add("Text", BindingCliente, "ConjugeRenda", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIgreja.DataBindings.Add("Text", BindingCliente, "Igreja", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIgrejaAtuacao.DataBindings.Add("Text", BindingCliente, "IgrejaAtuacao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIgrejaFuncao.DataBindings.Add("Text", BindingCliente, "IgrejaFuncao", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpClienteDesde.DataBindings.Add("Value", BindingCliente, "ClienteDesde", True, DataSourceUpdateMode.OnPropertyChanged)

        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDCliente.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler txtLimiteCompras.DataBindings("text").Format, AddressOf idFormatCUR
        AddHandler txtRGCliente.DataBindings("text").Format, AddressOf idFormatRG
        AddHandler txtRenda.DataBindings("text").Format, AddressOf idFormatCUR
        AddHandler txtConjugeRenda.DataBindings("text").Format, AddressOf idFormatCUR

        ' CARREGA OS COMBOBOX
        CarregaComboSexo()
        CarregaComboEstadoCivil()
        CarregaAtividade()

        ' ADD HANDLER PARA DATABINGS
        AddHandler _ClientePF.AoAlterar, AddressOf HandlerAoAlterar
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _ClientePF.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    Private Sub idFormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    ' CARREGA OS COMBOBOX
    '--------------------------------------------------------------------------------------------------------
    Private Sub CarregaComboSexo()
        Dim dtSexo As New DataTable
        'Adiciona todas as possibilidades de instrucao
        dtSexo.Columns.Add("idSexo")
        dtSexo.Columns.Add("Sexo")
        dtSexo.Rows.Add(New Object() {False, "Masculino"})
        dtSexo.Rows.Add(New Object() {True, "Feminino"})
        With cmbSexo
            .DataSource = dtSexo
            .ValueMember = "idSexo"
            .DisplayMember = "Sexo"
            .DataBindings.Add("SelectedValue", BindingCliente, "Sexo", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
    End Sub
    '
    Private Sub CarregaComboEstadoCivil()
        '
        Dim dtEstadoCivil As New DataTable
        '
        'Adiciona todas as possibilidades de instrucao
        dtEstadoCivil.Columns.Add("idEstadoCivil")
        dtEstadoCivil.Columns.Add("EstadoCivil")
        dtEstadoCivil.Rows.Add(New Object() {1, "Solteiro(a)"})
        dtEstadoCivil.Rows.Add(New Object() {2, "Casado(a)"})
        dtEstadoCivil.Rows.Add(New Object() {3, "Viúvo(a)"})
        dtEstadoCivil.Rows.Add(New Object() {4, "Divorciado(a)"})
        dtEstadoCivil.Rows.Add(New Object() {5, "União Estável"})
        '
        With cmbEstadoCivil
            .DataSource = dtEstadoCivil
            .ValueMember = "idEstadoCivil"
            .DisplayMember = "EstadoCivil"
            .DataBindings.Add("SelectedValue", BindingCliente, "EstadoCivil", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
    Private Sub CarregaAtividade()
        '
        Dim cliBLL As New ClienteBLL
        '
        Try
            Dim dtAtiv As DataTable = cliBLL.GetClienteAtividades(False)
            '
            With cmbRGAtividade
                .DataSource = dtAtiv
                .ValueMember = "RGAtividade"
                .DisplayMember = "Atividade"
                .DataBindings.Add("SelectedValue", BindingCliente, "RGAtividade", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        'verifica os dados se os campos estão preechidos
        If VerificaDados() = False Then Exit Sub

        ' procurar se já existe cliente com o mesmo RGCLIENTE
        If VerificaRGCliente() = False Then Exit Sub

        ' verifica se existe campo vazio nas Referencias do Cliente
        If VerificaReferencias() = False Then Exit Sub

        'define os dados da classe
        Dim NewCliID As Integer
        Dim pessoaBLL As New PessoaBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            'Salva o Cliente, mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
            If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
                '
                Dim response As Object = pessoaBLL.InsertNewPessoa(_ClientePF, PessoaBLL.EnumPessoaGrupo.CLIENTE)
                '
                If TypeOf response Is Integer Then
                    NewCliID = response
                Else
                    Throw New Exception("Já existe Cliente Pessoa Física com mesmo CPF...")
                End If
                '
            ElseIf _Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
                '
                pessoaBLL.UpdatePessoa(_ClientePF, PessoaBLL.EnumPessoaGrupo.CLIENTE)
                NewCliID = _ClientePF.IDPessoa
                '
            End If
            '
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

        'Verifica se houve Retorno da Função de Salvar
        If NewCliID <> 0 Then
            'Retorna o número de Registro do Novo Cliente Cadastrado
            If _Sit = EnumFlagEstado.NovoRegistro Then
                _ClientePF.IDPessoa = NewCliID
                lblIDCliente.Tag = NewCliID
                lblIDCliente.Text = Format(lblIDCliente.Tag, "D4")
            End If
            '
            'Altera a Situação
            Sit = EnumFlagEstado.RegistroSalvo
            BindingCliente.EndEdit()
            '
            'Salva as referências do Cliente
            SalvaReferencias(NewCliID)
            '
            'Mensagem
            MsgBox("Registro Salvo com sucesso!", vbInformation, "Registro Salvo")
            '
            '--- Abre o formuário de ações após salvar
            Dim frmAcao As New frmClienteAcoesDialog(Me)
            frmAcao.ShowDialog()
            '
        Else
            MsgBox("Registro NÃO pode ser salvo!", vbInformation, "Erro ao Salvar")
        End If
        '
    End Sub
    '
    ' FAZER VERIFICAÇÃO ANTES DE SALVAR
    Private Function VerificaDados() As Boolean
        '
        EProvider.Clear()
        '
        Dim f As New Utilidades
        '
        'Verifica o campo nome
        If Not f.VerificaControlesForm(txtClienteNome, "Nome do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, txtClienteNome)
            Return False
        End If
        '
        'Verifica o campo Atividade do Cliente
        If Not f.VerificaControlesForm(cmbRGAtividade, "Atividade do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, cmbRGAtividade)
            Return False
        End If
        '
        'Verifica o campo Data de Nascimento
        If Not f.VerificaControlesForm(dtpNascimentoData, "Data de Nascimento", EProvider) Then
            TabControl_IrPara(vtab1, dtpNascimentoData)
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtEndereco, "Endereço do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, txtEndereco)
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtBairro, "Bairro da Residência do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, txtBairro)
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtCidade, "Cidade  da Residência do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, txtCidade)
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtUF, "Estado/UF da Residência do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, txtUF)
            Return False
        End If
        '
        'Verifica o campo endereço
        If Not f.VerificaControlesForm(txtCEP, "CEP da Residência do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, txtCEP)
            Return False
        End If
        '
        'Verifica o campo Sexo
        If Not f.VerificaControlesForm(cmbSexo, "Sexo do Cliente", EProvider) Then
            TabControl_IrPara(vtab1, cmbSexo)
            Return False
        End If
        '
        'Verifica o campo IDENTIDADE
        '
        If Not f.VerificaDadosClasse(txtIdentidade, "Número da Identidade", _ClientePF, EProvider) Then
            TabControl_IrPara(vtab2, txtIdentidade)
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtIdentidadeOrgao, "Órgão Expedidor da Identidade", _ClientePF, EProvider) Then
            TabControl_IrPara(vtab2, txtIdentidadeOrgao)
            Return False
        End If
        '
        'Verifica o campo ESTADOCIVIL
        If Not f.VerificaDadosClasse(cmbEstadoCivil, "Estado Civil", _ClientePF, EProvider) Then
            TabControl_IrPara(vtab2, cmbEstadoCivil)
            Return False
        End If
        '
        '--- Verifica se Existe CONJUGE MESMO NÃO SENDO CASADO
        cmbEstadoCivil.SelectedValue = If(_ClientePF.EstadoCivil, -1)
        '
        If Not (cmbEstadoCivil.SelectedValue = 2 Or cmbEstadoCivil.SelectedValue = 5) Then '--- Nesse caso essa pessoa NÃO tem CONJUGE
            If txtConjuge.Text.Length > 0 OrElse _ClientePF.ConjugeRenda > 0 Then
                If MessageBox.Show("Se o cliente não é CASADO ou não vive em UNIÃO ESTÁVEL..." & vbCrLf &
                                   "Não pode haver CÔNJUGE NOME e/ou RENDA DO CÔNJUGE..." & vbCrLf & vbCrLf &
                                   "Deseja limpar esses campos automaticamente?", "Cliente SEM Cônjuge",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    _ClientePF.Conjuge = ""
                    txtConjuge.DataBindings.Item("Text").ReadValue()
                    _ClientePF.ConjugeRenda = 0
                    txtConjugeRenda.DataBindings.Item("Text").ReadValue()
                    Return True
                Else
                    TabControl_IrPara(vtab2, cmbEstadoCivil)
                    Return False
                End If

            End If
        Else
            'Verifica o campo Cônjuge Nome
            If Not f.VerificaDadosClasse(txtConjuge, "Nome do Cônjuge", _ClientePF, EProvider) Then
                TabControl_IrPara(vtab2, txtConjuge)
                Return False
            End If
            '
            Return True
        End If
        '
        'Verifica o campo LimiteCompras
        txtLimiteCompras.Text = _ClientePF.LimiteCompras
        If txtLimiteCompras.Text <= 0 Then
            MsgBox("O campo Limite de Compras não pode ser menor ou igual a 0;" & vbCrLf &
                   "Preencha esse campo antes de Salvar o registro por favor...", vbInformation, "Valor Inválido")
            EProvider.SetError(txtLimiteCompras, "Preencha o valor desse campo!")
            '
            TabControl_IrPara(vtab3, txtLimiteCompras)
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtLimiteCompras, "Limite de Compras", _ClientePF, EProvider) Then
            TabControl_IrPara(vtab3, txtLimiteCompras)
            Return False
        End If
        '
        'Se nenhuma das condições acima forem verdadeira retorna TRUE
        EProvider.Clear()
        Return True
        '
    End Function
    '
    '
    '--- ALTERA A TAB DESABILITA E HABILITA O HANDLER
    '----------------------------------------------------------------------------------
    Private Sub TabControl_IrPara(irPara As vTabPage, focusControl As Control)
        RemoveHandler tabPrincipal.SelectedIndexChanged, AddressOf tabPrincipal_SelectedIndexChanged
        tabPrincipal.SelectedTab = irPara
        focusControl.Focus()
        AddHandler tabPrincipal.SelectedIndexChanged, AddressOf tabPrincipal_SelectedIndexChanged
    End Sub
    '
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
            If intID <> _ClientePF.IDPessoa Then '--- NESSE CASO NÃO É O MESMO CLIENTE
                MessageBox.Show("Já foi encontrado Cliente com esse mesmo número de Reg. Anterior..." & vbNewLine &
                                strCli.ToUpper & vbNewLine & "Insira outro Reg. Anterior ou altere o registro do outro Cliente.",
                                "Reg. Anterior Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRGCliente.Focus()
                Return False
            Else
                Return True '--- NÃO É O MESMO CLIENTE
            End If
        End If
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------
    ' FUNÇÃO PUBLICA QUE REALIZA AÇÕES A PARTIR DO frmClienteAcoesDialog
    '-----------------------------------------------------------------------------------------
    Public Sub RealizaAcaoInterna(myAcao As String)

        Select Case myAcao
            Case = "PERMANECER"
                tabPrincipal.SelectedTab = vtab1
                txtClienteNome.Focus()
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

    End Sub
    '---------------------------------------------------------------------------------------------------
#End Region
    '
#Region "FORMATAÇÃO E FLUXO"
    '
    ' CRIA TECLA DE ATALHO PARA O TAB
    '---------------------------------------------------------------------------------------------------
    Private Sub frmClientesPF_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.Alt AndAlso e.KeyCode = Keys.D1 Then
            tabPrincipal.SelectedTab = vtab1
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D2 Then
            tabPrincipal.SelectedTab = vtab2
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D3 Then
            tabPrincipal.SelectedTab = vtab3
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        End If
        '
    End Sub
    '
    Private Sub tabPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPrincipal.SelectedIndexChanged
        '
        If tabPrincipal.SelectedIndex = 0 Then
            txtClienteNome.Focus()
        ElseIf tabPrincipal.SelectedIndex = 1 Then
            txtIdentidade.Focus()
        ElseIf tabPrincipal.SelectedIndex = 2 Then
            txtLimiteCompras.Focus()
            RendaFamiliar()
        End If
        '
    End Sub
    '---------------------------------------------------------------------------------------------------
    '
    ' USAR SOMENTE NÚMERO NO CAMPO RGCLIENTE
    Private Sub txtRGCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGCliente.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    ' CAMPO UF SOMENTE MAIUSCULAS COM 2 CARACTERES
    Private Sub txtUF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUF.KeyPress
        '
        ' MAXIMO DE 2 CARACTERES
        If Len(txtUF.Text) >= 2 And Not e.KeyChar = vbBack Then
            e.Handled = True
            Exit Sub
        End If
        '
    End Sub
    '
    '--- USE TAB ON ENTER
    '----------------------------------------------------------------------------------
    ' ADD HANDLER EVENTO KEYDOWN DOS CONTROLES COM VTAB
    Private Sub HandlerKeyDownControl()
        '
        '--- Tipos de Controles
        Dim myTypes As Type() = {GetType(TextBox),
                                 GetType(ComboBox),
                                 GetType(MaskedTextBox),
                                 GetType(Controles.Text_Monetario),
                                 GetType(DateTimePicker)}
        '
        '--- para cada TabPage no tabPrincipal
        For Each t As vTabPage In tabPrincipal.TabPages
            '
            '--- para cada Controle no TabPage
            For Each c As Control In t.Controls '--- se o controle for textbox então
                '
                If myTypes.Contains(c.GetType) Then
                    AddHandler c.KeyDown, AddressOf txtControl_KeyDown
                End If
                '
            Next
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
            '
            '--- in case to be the last control in a TAB
            If DirectCast(sender, Control).Tag = "nexttab" Then
                '
                If tabPrincipal.SelectedIndex = 0 Then
                    tabPrincipal.SelectedTab = vtab2
                    tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
                ElseIf tabPrincipal.SelectedIndex = 1 Then
                    tabPrincipal.SelectedTab = vtab3
                    tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
                End If
                '
                Exit Sub
                '
            End If
            '
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
            '
        End If
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
            "txtCEP",
            "txtRGCliente"
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
    '---------------------------------------------------------------------------------------
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL)
    '---------------------------------------------------------------------------------------
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles txtCEP.KeyDown,
            txtRGCliente.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            Select Case ctr.Name
                Case "txtRGCliente"
                    btnProcuraRG_Click(New Object, New EventArgs)
                Case "txtCEP"
                    btnCEPProcura_Click(sender, New EventArgs)
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtRGCliente"
                    If Not IsNothing(_ClientePF.RGCliente) Then Sit = EnumFlagEstado.Alterado
                    txtRGCliente.Clear()
                    _ClientePF.RGCliente = Nothing
                Case "txtCEP"
                    If Not IsNothing(_ClientePF.CEP) Then Sit = EnumFlagEstado.Alterado
                    txtCEP.Clear()
                    _ClientePF.CEP = Nothing
            End Select
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "OPERAÇÕES DE REGISTRO"
    '
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
                Dim cliBll As New ClientePF_BLL
                '
                Dim myCliPF As clClientePF = cliBll.GetClientePF_PorID(frm.propClienteEscolhido.IDPessoa)
                propClientePF = myCliPF
                propAcao = EnumFlagAcao.EDITAR
                '
            ElseIf frm.propClienteEscolhido.PessoaTipo = 2 Then ' PESSOA JURÍDICA
                ' ABRIR FORMULÁRIO CLIENTEPJ
                Close()
                '
                Dim cliBLL As New ClientePJ_BLL
                '
                Dim myCliPJ As clClientePJ = cliBLL.GetClientesPJ_PorID(frm.propClienteEscolhido.IDPessoa)
                Dim frmCli As New frmClientePJ(EnumFlagAcao.EDITAR, myCliPJ)
                frmCli.Show()
                '
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            BindingCliente.CancelEdit()
            tabPrincipal.SelectedTab = vtab1
            txtClienteNome.Focus()
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
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

        If _ClientePF.IDSituacao = 1 Then ' Cliente ativo
            If MessageBox.Show("Você deseja realmente DESATIVAR o Cliente:" & vbNewLine &
                        txtClienteNome.Text.ToUpper, "Desativar Cliente", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _ClientePF.BeginEdit()
                _ClientePF.IDSituacao = 2
                _ClientePF.Situacao = "INATIVO"
                AtivoButtonImage()
            End If
        ElseIf _ClientePF.IDSituacao = 2 Then ' Cliente Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR o Cliente:" & vbNewLine &
            txtClienteNome.Text.ToUpper, "Ativar Cliente", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _ClientePF.BeginEdit()
                _ClientePF.IDSituacao = 1
                _ClientePF.Situacao = "ATIVO"
                AtivoButtonImage()
            End If
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    '-------------------------------------------------------------------------------------------------------
    Private Sub AtivoButtonImage()
        If _ClientePF.IDSituacao = 1 Then ' Nesse caso é Cliente Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = _ClientePF.Situacao
        Else ' Nesse caso é Cliente Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = _ClientePF.Situacao
        End If
    End Sub
    '
    ' FECHA O FORMULÁRIO
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
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
    ' BOTÃO NOVO REGISTRO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click

        ' ABRE O FORM NOVOCLIENTE
        Dim frm As New frmClienteNovo
        frm.ShowDialog()

    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNÇÕES"
    '
    '-------------------------------------------------------------------------------------------------------
    ' BTN PROCURAR RGCLIENTE
    '-------------------------------------------------------------------------------------------------------
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
    '-------------------------------------------------------------------------------------------------------
    ' ESTADOCIVIL AO ALTERAR DESABILITAR O NOME E A RENDA DO CONJUGE
    '-------------------------------------------------------------------------------------------------------
    Private Sub cmbEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoCivil.SelectedIndexChanged
        If Not IsNumeric(cmbEstadoCivil.SelectedValue) Then Exit Sub
        ' 
        If cmbEstadoCivil.SelectedValue = 2 Or cmbEstadoCivil.SelectedValue = 5 Then '--- Nesse caso essa pessoa tem CONJUGE
            txtConjuge.Enabled = True
            txtConjugeRenda.Enabled = True
        Else '--- Nesse caso essa pessoa não pode ter CONJUGE
            txtConjuge.Enabled = False
            txtConjugeRenda.Enabled = False
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' FUNÇÃO QUE CALCULA A SOMA DAS RENDA PESSOAL E DO CONJUGE E PREENCHE O LABEL RENDA FAMILIAR
    '-------------------------------------------------------------------------------------------------------
    Private Function RendaFamiliar() As Double
        Dim RendaPessoal As Double
        Dim RendaConjuge As Double
        Dim RendaSoma As Double

        Dim style As Globalization.NumberStyles = Globalization.NumberStyles.Number Or Globalization.NumberStyles.AllowCurrencySymbol
        Dim culture As Globalization.CultureInfo = Globalization.CultureInfo.InstalledUICulture

        '
        If Not Double.TryParse(_ClientePF.Renda, style, culture, RendaPessoal) Then
            RendaPessoal = 0
        End If
        '
        If Not Double.TryParse(_ClientePF.ConjugeRenda, style, culture, RendaConjuge) Then
            RendaConjuge = 0
        End If
        '
        RendaSoma = RendaPessoal + RendaConjuge
        lblRendaFamiliar.Text = Format(RendaSoma, "c")
        Return RendaSoma
    End Function
    '
    Private Sub miFichaCadastro_Click(sender As Object, e As EventArgs) Handles miFichaCadastro.Click
        Dim frm As New frmClientePFFicha(_ClientePF)
        '
        frm.ShowDialog()
        '
    End Sub
    '
    '--- PROCURA CEP
    '----------------------------------------------------------------------------------
    Private Sub btnCEPProcura_Click(sender As Object, e As EventArgs) Handles btnCEPProcura.Click
        Process.Start("http://www.buscacep.correios.com.br/sistemas/buscacep/buscaCepEndereco.cfm") 'Aqui você poderá alterar o site'
    End Sub
    '
#End Region
    '
#Region "REFERENCIAS"
    '
    Private Sub PreencheReferencias()
        dgvReferencias.AutoGenerateColumns = False
        dgvReferencias.DataSource = dtRef
        '
        FormataReferencias()
        '
    End Sub
    '
    Private Sub FormataReferencias()
        Dim index As Integer
        ' find the location of the column
        index = dgvReferencias.Columns.IndexOf(dgvReferencias.Columns("ReferenciaTelefone"))

        ' remove the existing column
        dgvReferencias.Columns.RemoveAt(index)

        ' create a new custom column
        Dim dgvMaskedCol As New Controles.DataGridViewMaskedEditColumn
        With dgvMaskedCol
            .Mask = "(00) 90000-0000"
            .ValidatingType = GetType(String)
            .Name = "ReferenciaTelefone"
            .DataPropertyName = "ReferenciaTelefone"
            .HeaderText = "Telefone"
            .Width = 130
            .SortMode = DataGridViewColumnSortMode.Automatic  ' some more tweaking
        End With

        ' insert the new column at the same location
        dgvReferencias.Columns.Insert(index, dgvMaskedCol)
    End Sub
    '
    Private Sub SalvaReferencias(myID As Long)
        '
        ' Verifica se as referências estão com campos completos
        If VerificaReferencias() = False Then
            Exit Sub
        End If
        '
        Dim dbRef As New ClienteReferenciaBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Salva registro
            dbRef.ClienteReferencia_INSERT(myID, dtRef)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao salvar as Referências..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub AlteraReferencia()
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
    Private Function VerificaReferencias() As Boolean
        '
        ' VERIFICA OS VALORES DAS CÉLULAS DO DATAGRID
        For i = 0 To dgvReferencias.RowCount - 2
            '
            If IsNothing(dgvReferencias.Rows(i).Cells(0).Value) OrElse String.IsNullOrEmpty(dgvReferencias.Rows(i).Cells(0).Value.ToString) Then
                MessageBox.Show("Os campos das referências do Cliente não podem ficar vazios" & vbNewLine &
                                "Favor conferir preencher todos os campos...", "Referências Incompletas",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvReferencias.Focus()
                dgvReferencias.CurrentCell = dgvReferencias.Rows(i).Cells(0)
                Return False
            ElseIf IsNothing(dgvReferencias.Rows(i).Cells(1).Value) OrElse String.IsNullOrEmpty(dgvReferencias.Rows(i).Cells(1).Value.ToString) Then
                MessageBox.Show("Os campos das referências do Cliente não podem ficar vazios" & vbNewLine &
                                "Favor conferir preencher todos os campos...", "Referências Incompletas",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvReferencias.Focus()
                dgvReferencias.CurrentCell = dgvReferencias.Rows(i).Cells(1)
                Return False
            ElseIf IsNothing(dgvReferencias.Rows(i).Cells(2).Value) OrElse String.IsNullOrEmpty(dgvReferencias.Rows(i).Cells(2).Value.ToString) Then
                MessageBox.Show("Os campos das referências do Cliente não podem ficar vazios" & vbNewLine &
                                "Favor conferir preencher todos os campos...", "Referências Incompletas",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvReferencias.Focus()
                dgvReferencias.CurrentCell = dgvReferencias.Rows(i).Cells(2)
                Return False
            End If
        Next
        '
        Return True
        '
    End Function
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB) NO DATAGRID
    Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvReferencias.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            '
            Dim iColumn As Integer = dgvReferencias.CurrentCell.ColumnIndex
            Dim iRow As Integer = dgvReferencias.CurrentCell.RowIndex
            '
            e.SuppressKeyPress = True
            e.Handled = True
            '
            If iColumn = dgvReferencias.ColumnCount - 1 Then
                '
                If (dgvReferencias.RowCount > (iRow + 1)) Then
                    dgvReferencias.CurrentCell = dgvReferencias(0, iRow + 1)
                Else
                    tsMenuCliente.Focus()
                    btnProcurar.Select()
                End If
            Else
                dgvReferencias.CurrentCell = dgvReferencias(iColumn + 1, iRow)
            End If
            '
        End If
        '
    End Sub
    '
    '--- TRANSFORM 'NOME' IN UPPER CASE
    '----------------------------------------------------------------------------------
    Private Sub txtClienteNome_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtClienteNome.Validating
        '
        If txtClienteNome.Text.Length > 0 Then
            txtClienteNome.Text = Utilidades.PrimeiraLetraMaiuscula(txtClienteNome.Text)
        End If
        '
    End Sub
    '
#End Region
    '
End Class