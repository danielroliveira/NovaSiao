Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmFuncionario
    '
#Region "PRIVATE VARIAVEIS" ' DECLARAÇÃO DE VARIÁVEIS
    Private WithEvents t As New Timer
    Const Tmax = 535
    Const Tmin = 455
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private WithEvents listFunc As New List(Of clFuncionario)
    Private WithEvents bindFunc As New BindingSource
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    Private Opening As Boolean = True
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                dgvFuncionarios.Enabled = True
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnCancelar.Enabled = False
                lblIDFuncionario.Text = Format(lblIDFuncionario.Tag, "0000")
                txtCPF.ReadOnly = True
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                dgvFuncionarios.Enabled = True
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                txtCPF.ReadOnly = True
                AtivoButtonImage()
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                dgvFuncionarios.Enabled = False
                txtFuncionario.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                txtCPF.ReadOnly = False
                lblIDFuncionario.Text = "NOVO"
                ' OBTER OS VALORES DEFAULT DOS CAMPOS
                txtCidade.Text = ObterDefault("Cidade")
                txtUF.Text = ObterDefault("UF")
                AtivoButtonImage()
            End If
        End Set
    End Property
    '
#End Region
    '
#Region "EVENTO LOAD"
    '
    ' Evento LOAD
    Private Sub frmFuncionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim funcBLL As New FuncionarioBLL
        '
        Try
            listFunc = funcBLL.GetFuncionarios.OrderBy(Function(x) x.Cadastro).ToList
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
        bindFunc.DataSource = listFunc
        '
        If listFunc.Count = 0 Then
            '
            btnNovo_Click(Me, New EventArgs)
            PreencheDataBindings()
            '
        Else
            bindFunc.MoveFirst()
            PreencheDataBindings()
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
        ' preencher a listagem
        PreencheFuncionarios()
        ' redimensiona o form
        AddHandlerControles() ' adiciona o handler para selecionar e usar tab com a tecla enter
        RedimensionarForm()
        Opening = False
        '
    End Sub
    '
#End Region
    '
#Region "BINDINGS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblIDFuncionario.DataBindings.Add("Tag", bindFunc, "IDPessoa")
        txtFuncionario.DataBindings.Add("Text", bindFunc, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCPF.DataBindings.Add("Text", bindFunc, "CPF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNascimentoData.DataBindings.Add("Text", bindFunc, "NascimentoData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIdentidade.DataBindings.Add("Text", bindFunc, "Identidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIdentidadeOrgao.DataBindings.Add("Text", bindFunc, "IdentidadeOrgao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIdentidadeData.DataBindings.Add("Text", bindFunc, "IdentidadeData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEndereco.DataBindings.Add("Text", bindFunc, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
        txtBairro.DataBindings.Add("Text", bindFunc, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCidade.DataBindings.Add("Text", bindFunc, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUF.DataBindings.Add("Text", bindFunc, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCEP.DataBindings.Add("Text", bindFunc, "CEP", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
        txtTelefoneA.DataBindings.Add("Text", bindFunc, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTelefoneB.DataBindings.Add("Text", bindFunc, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEmail.DataBindings.Add("Text", bindFunc, "Email", True, DataSourceUpdateMode.OnPropertyChanged)
        txtAdmissaoData.DataBindings.Add("Text", bindFunc, "AdmissaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        chkVendas.DataBindings.Add("CheckState", bindFunc, "Vendedor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtApelidoFuncionario.DataBindings.Add("Text", bindFunc, "ApelidoFuncionario", True, DataSourceUpdateMode.OnPropertyChanged)
        txtComissao.DataBindings.Add("Text", bindFunc, "Comissao", True, DataSourceUpdateMode.OnPropertyChanged)
        chkVendedorAtivo.DataBindings.Add("CheckState", bindFunc, "VendedorAtivo", True, DataSourceUpdateMode.OnPropertyChanged)
        lblApelidoFilial.DataBindings.Add("Text", bindFunc, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDFuncionario.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler txtComissao.DataBindings("Text").Format, AddressOf idFormatPercent
        AddHandler bindFunc.CurrentChanged, AddressOf handler_CurrentChanged
        '
        ' CARREGA OS COMBOBOX
        CarregaComboVendaTipo()
        CarregaComboSexo()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(bindFunc.CurrencyManager.Current, clFuncionario).AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(bindFunc.CurrencyManager.Current, clFuncionario).AoAlterar, AddressOf HandlerAoAlterar
        '
        '--- Nesse caso é um novo registro
        If IsNothing(DirectCast(bindFunc.Current, clFuncionario).IDPessoa) Then
            Exit Sub
        Else
            ' LER O ID
            lblIDFuncionario.DataBindings.Item("Tag").ReadValue()
            ' ALTERAR PARA REGISTRO SALVO
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If bindFunc.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
    Private Sub idFormatPercent(sender As Object, e As ConvertEventArgs)
        e.Value = Format(e.Value, "#.##\%")
    End Sub
    '
    ' CARREGA OS COMBOBOX
    '--------------------------------------------------------------------------------------------------------
    Private Sub CarregaComboVendaTipo()
        Dim dtTipo As New DataTable
        'Adiciona todas as possibilidades de instrucao
        dtTipo.Columns.Add("VendaTipo")
        dtTipo.Columns.Add("Tipo")
        dtTipo.Rows.Add(New Object() {1, "Varejo"})
        dtTipo.Rows.Add(New Object() {2, "Atacado"})
        dtTipo.Rows.Add(New Object() {0, "Todas"})
        With cmbVendaTipo
            .DataSource = dtTipo
            .ValueMember = "VendaTipo"
            .DisplayMember = "Tipo"
            .DataBindings.Add("SelectedValue", bindFunc, "VendaTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
    End Sub
    '
    ' COMBOBOX SEXO
    '--------------------------------------------------------------------------------------------------------
    Private Sub CarregaComboSexo()
        Dim dtSexo As New DataTable
        'Adiciona todas as possibilidades de instrucao
        dtSexo.Columns.Add("idSexo")
        dtSexo.Columns.Add("Sexo")
        dtSexo.Rows.Add(New Object() {False, "Masc"})
        dtSexo.Rows.Add(New Object() {True, "Fem"})
        With cmbSexo
            .DataSource = dtSexo
            .ValueMember = "idSexo"
            .DisplayMember = "Sexo"
            .DataBindings.Add("SelectedValue", bindFunc, "Sexo", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
    End Sub
    '
    '--------------------------------------------------------------------------------------------------------
    ' PREENCHE A LISTAGEM
    '--------------------------------------------------------------------------------------------------------
    Private Sub PreencheFuncionarios()
        With dgvFuncionarios
            .Columns.Clear()
            .AutoGenerateColumns = False
            .DataSource = bindFunc
            ' altera as propriedades importantes
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ColumnHeadersVisible = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .RowHeadersWidth = 36
            .RowTemplate.Height = 30
            .StandardTab = True
        End With
        '
        ' (1) COLUNA REG
        dgvFuncionarios.Columns.Add("clnID", "Reg.:")
        With dgvFuncionarios.Columns("clnID")
            .DataPropertyName = "IDPessoa"
            .Width = 60
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            Dim newPadding As New Padding(5, 0, 0, 0)
            .DefaultCellStyle.Padding = newPadding
        End With
        '
        ' (2) COLUNA NOME
        dgvFuncionarios.Columns.Add("clnCadastro", "Funcionário:")
        With dgvFuncionarios.Columns("clnCadastro")
            .DataPropertyName = "Cadastro"
            .Width = 220
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

    End Sub
    '--------------------------------------------------------------------------------------------------------
#End Region
    '
#Region "SALVAR REGISTRO"
    ' SALVAR O REGISTRO
    '---------------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- verifica os dados se os campos estão preechidos
        If VerificaDados() = False Then Exit Sub
        '
        '--- verifica se o vendedor foi desabilitado e se existem vendas no ID
        If Sit = EnumFlagEstado.Alterado AndAlso Not chkVendas.Checked Then
            Dim qdeVendas As Integer = DesabilitaVendedor_Verificacao()
            '
            If qdeVendas > 0 Then
                MessageBox.Show("Esse funcionário não pode ser retirado de vendedor," & vbNewLine &
                            "já que existem " & qdeVendas & " vendas associadas a ele" & vbNewLine & vbNewLine &
                            "A caixa VENDEDOR ATIVO será desmarcada...", "Vendas Ativas",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                chkVendas.Checked = True
                chkVendedorAtivo.Checked = False
            End If
        End If
        '
        '--- define os dados da classe
        Dim NewFuncID As Long
        Dim func_BLL As New FuncionarioBLL
        '
        '--- salva ou não salva a tabela VendaFuncionario
        DirectCast(bindFunc.CurrencyManager.Current, clFuncionario).Vendedor = chkVendas.Checked
        If chkVendas.Checked = False Then
            txtComissao.Text = ""
        End If
        '
        Try
            '--- Salva mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
            If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
                NewFuncID = func_BLL.SalvaNovoFuncionario_Procedure_ID(bindFunc.CurrencyManager.Current)
            ElseIf Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
                NewFuncID = func_BLL.AtualizaFuncionario_Procedure_ID(bindFunc.CurrencyManager.Current)
            End If
        Catch ex As Exception
            MessageBox.Show("Um erro ocorreu ao salvar o registro!" & vbCrLf &
                            ex.Message, "Erro ao Salvar Registro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
        '--- Verifica se houve Retorno da Função de Salvar
        If IsNumeric(NewFuncID) AndAlso NewFuncID <> 0 Then
            '--- Retorna o número de Registro do Novo Cliente Cadastrado
            If _Sit = EnumFlagEstado.NovoRegistro Then
                DirectCast(bindFunc.Current, clFuncionario).IDPessoa = NewFuncID
                lblIDFuncionario.Tag = NewFuncID
            End If

            '--- Altera a Situação
            Sit = EnumFlagEstado.RegistroSalvo
            bindFunc.EndEdit()
            bindFunc.CurrencyManager.Refresh()
            '
            'PreencheFuncionarios()
            '
            '--- Mensagem de Sucesso:
            MsgBox("Registro Salvo com sucesso!", vbInformation, "Registro Salvo")
        Else
            MsgBox("Registro NÃO pode ser salvo!", vbInformation, "Erro ao Salvar")
        End If
        '
    End Sub
    '
    ' FAZER VERIFICAÇÃO ANTES DE SALVAR
    Private Function VerificaDados() As Boolean
        EProvider.Clear()
        '
        Dim f As New FuncoesUtilitarias
        '
        If Not f.VerificaControlesForm(txtFuncionario, "Nome do Funcionário", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtCPF, "CPF", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtNascimentoData, "Data de Nascimento", EProvider) Then
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
        If Not f.VerificaControlesForm(txtAdmissaoData, "Data de Admissão", EProvider) Then
            txtAdmissaoData.Text = Today.ToShortDateString
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtApelidoFuncionario, "Apelido Funcional", EProvider) Then
            Return False
        End If
        '
        If chkVendas.Checked = True Then
            '
            If Not f.VerificaControlesForm(cmbVendaTipo, "Tipo de Venda", EProvider) Then
                Return False
            End If
            '
        End If
        '
        'Se nenhuma das condições acima forem verdadeira retorna TRUE
        Return True
    End Function
    '
    ' VERIFICA PESSOA EXISTENTE RETORNA UM clFuncionario
    Private Function VerPessoaExistente() As Object
        Dim db As New PessoaBLL
        Dim myPessoa As Object = Nothing
        '
        Try
            myPessoa = db.ProcurarCNP_Pessoa(txtCPF.Text, "FUNCIONARIO")
            '
            ' NÃO ENCOTROU NENHUM CLIENTE NO CPF/CNPJ RETORNA NOVO CLIENTE
            If IsNothing(myPessoa) Then Return Nothing
            '
            ' VERIFICA SE A PESSOA ENCONTRADA É PF OU FUNCIONARIO
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
    ' FUNÇÃO QUE VALIDA O CPF
    '---------------------------------------------------------------------------------------------------
    Private Function ValidaCPF() As Boolean
        Dim vCPF As New Valida_CPF_CNPJ
        vCPF.cpf = txtCPF.Text
        '
        If vCPF.isCpfValido = False Then
            MessageBox.Show("O número de CPF digitado é inválido." & vbNewLine &
                            "Digite um CPF válido por favor...", "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCPF.Focus()
            txtCPF.SelectAll()
            Return False
        Else
            Return True
        End If
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    '--- FUNCAO QUE VERIFICA SE O FUNCIONARIO/VENDEDOR POSSUI ALGUM REGISTRO DE VENDA ASSOCIADO A ELE
    '-------------------------------------------------------------------------------------------------------
    Private Function DesabilitaVendedor_Verificacao() As Integer
        If chkVendas.Checked = False AndAlso Sit <> EnumFlagEstado.NovoRegistro Then
            Dim fBLL As New FuncionarioBLL
            Dim qdeVendas As Integer?
            '
            Try
                qdeVendas = fBLL.FuncionarioVendedor_GetVendas(DirectCast(bindFunc.Current, clFuncionario).IDPessoa)
                If Not IsNothing(qdeVendas) Then
                    Return qdeVendas
                Else
                    Return -1
                End If
            Catch ex As Exception
                MessageBox.Show("Uma falha inesperada ocorreu: " & vbNewLine & ex.Message)
                Return -1
            End Try
        Else
            Return 0
        End If
    End Function
    '
    '----------------------------------------------------------------------------------------------------------
#End Region

#Region "REDIMENSIONAR FORM"
    '
    ' Redimensionar o Form
    Private Sub RedimensionarForm()
        t.Interval = 1
        t.Start()
        AddHandler t.Tick, AddressOf DisparaTimer
    End Sub
    '
    Public Sub DisparaTimer(ByVal seder As Object, ByVal e As System.EventArgs)
        If chkVendas.Checked = True Then
            If Me.Height <= Tmax Then
                Me.Top -= 2
                Me.Height += 4
            Else
                t.Stop()
                pnlVenda.Visible = True
                If chkVendas.Focused Then
                    txtApelidoFuncionario.Focus()
                    txtApelidoFuncionario.SelectAll()
                End If
            End If
        Else
            If Me.Height >= Tmin Then
                Me.Top += 2
                Me.Height -= 4
            Else
                pnlVenda.Visible = False
                t.Stop()
            End If
        End If
    End Sub
    '
    Private Sub chkVendas_CheckedChanged(sender As Object, e As EventArgs) Handles chkVendas.CheckedChanged
        RedimensionarForm()
        pnlVenda.Enabled = chkVendas.Checked
        '
        If chkVendas.Checked = True Then
            If IsNothing(DirectCast(bindFunc.CurrencyManager.Current, clFuncionario).VendedorAtivo) Then
                DirectCast(bindFunc.CurrencyManager.Current, clFuncionario).VendedorAtivo = True
            End If
            '
            lblVendedor.Text = "Funcionário é Vendedor"
        Else
            lblVendedor.Text = "Funcionário NÃO é Vendedor"
        End If
        '
    End Sub
    '
#End Region
    '
#Region "VALIDACAO DO CPF/CNPJ"

    '--------------------------------------------------------------------------------------------------------------------------------------
    ' VALIDA O CPF - PROCURA UMA PESSOA COM MESMO CPF 
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Sub txtCPF_Leave(sender As Object, e As EventArgs) Handles txtCPF.Leave
        '
        If Sit <> EnumFlagEstado.NovoRegistro Then Exit Sub
        '
        ' verifica somente os numeros do CPF
        Dim CPF As String = ""
        CPF = txtCPF.Text
        CPF = CPF.Replace(".", String.Empty)
        CPF = CPF.Replace("-", String.Empty)
        '
        ' se nao houver numero nenhum entao sai
        If String.IsNullOrWhiteSpace(CPF) Then Exit Sub
        '
        ' verifica a quantidade de caracteres digitados
        If CPF.Length <> 11 Then
            MessageBox.Show("Digite apenas números no CPF e apenas 11 dígitos...",
                            "CPF inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCPF.Focus()
            txtCPF.SelectAll()
            Exit Sub
        End If
        '
        '--- Verifica a validade do CPF
        If ValidaCPF() = False Then
            txtCPF.Focus()
            txtCPF.SelectAll()
            Exit Sub
        End If
        '
        'VERIFICAR SE O CPF JÁ ESTÁ CADASTRADO COMO PESSOA OU FUNCIONARIO
        Dim func As Object = VerPessoaExistente()
        '
        If IsNothing(func) Then Exit Sub
        '
        Select Case func.GetType()
            Case Is = GetType(clPessoaFisica) ' É APENAS PessoaFisica
                If MessageBox.Show("Já Existe PESSOA FÍSICA cadastrada com esse mesmo CPF:" & vbCrLf & vbCrLf &
                                   DirectCast(func, clPessoaFisica).Cadastro.ToUpper & vbCrLf & vbCrLf &
                                   "Deseja preencher os dados automaticamente com as informações dessa pessoa?",
                                   "Copiar os Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    '
                    Dim f As New clPessoaFisica
                    f = DirectCast(func, clPessoaFisica)
                    '
                    '--- PREENCHE OS DADOS DO FUNCIONARIO AUTOMATICAMENTE
                    txtFuncionario.Text = f.Cadastro
                    txtNascimentoData.Text = f.NascimentoData
                    cmbSexo.SelectedValue = f.Sexo
                    txtEndereco.Text = f.Endereco
                    txtBairro.Text = f.Bairro
                    txtCidade.Text = f.Cidade
                    txtUF.Text = f.UF
                    txtCEP.Text = f.CEP
                    txtTelefoneA.Text = f.TelefoneA
                    txtTelefoneB.Text = f.TelefoneB
                    txtEmail.Text = f.Email
                    txtIdentidade.Text = f.Identidade
                    txtIdentidadeData.Text = f.IdentidadeData
                    txtIdentidadeOrgao.Text = f.IdentidadeOrgao
                    '
                End If
            Case Is = GetType(clFuncionario) ' JÁ é um FUNCIONARIO
                MessageBox.Show("Já existe um FUNCIONÁRIO cadastrado com esse mesmo CPF..." & vbCrLf & vbNewLine &
                                "Não é possível inserir um novo funcionário com o mesmo CPF",
                                "CPF Já existe como Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCPF.Text = String.Empty
                txtCPF.Focus()
        End Select
        '
    End Sub
#End Region
    '
#Region "NAVEGACAO NO FORM"
    Private Sub txtCPF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCPF.KeyPress
        ' NÃO PERMITIR DIGITAÇÃO DE LETRAS OU CONTROLES
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
        ' NÃO PERMITIR TEXTO MAIOR QUE 11 DÍGITOS
        If txtCPF.TextLength >= 11 And Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    '
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

    '-----------------------------------------------------------------------------------------------------
    'Sub QUE() VERIFICA A ALTERAÇÃO DE REGISTRO PELO DATAGRIDVIEW
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvFuncionarios_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvFuncionarios.RowValidating
        '
        If Sit = EnumFlagEstado.Alterado Then
            If MessageBox.Show("Esse registro foi alterado..." & vbNewLine &
                               "Se você alterar para outro registro irá perder todas as alterações feitas" &
                               vbNewLine & vbNewLine & "DESEJA SALVAR AS ALTERAÇÕES REALIZADAS?",
                               "Registro Alterado", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                e.Cancel = True
                btnSalvar_Click(New Object, New EventArgs)
                Exit Sub
            Else
                bindFunc.CancelEdit()
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        AutoValidate = AutoValidate.Disable
        Me.Close()
        MostraMenuPrincipal()
    End Sub
    '
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        'listFunc.Add(New clFuncionario)
        bindFunc.AddNew()
        bindFunc.MoveLast()
        bindFunc.Current.IDFilial = Obter_FilialPadrao()
        bindFunc.Current.ApelidoFilial = ObterDefault("FilialDescricao")
        dgvFuncionarios.ClearSelection()
        Sit = EnumFlagEstado.NovoRegistro
        txtFuncionario.Focus()
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If Sit = EnumFlagEstado.NovoRegistro Then
            If bindFunc.Count = 1 Then
                MessageBox.Show("Você não pode cancelar a inserção no primeiro registro de Funcionários" & vbNewLine &
                                "Se quiser sair pressione o botão 'FECHAR'", "Primeiro Registro",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '
            dgvFuncionarios.DataSource = Nothing
            bindFunc.CancelEdit()
            bindFunc.MoveLast()
            dgvFuncionarios.DataSource = bindFunc
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            bindFunc.CancelEdit()
        End If
        '
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        MsgBox("Em complementação...")
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        Dim _func As clFuncionario = bindFunc.Current

        If _func.Ativo = True Then ' Nesse caso é Cliente Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Funcionário Ativo"
        ElseIf _func.Ativo = False Then ' Nesse caso é Cliente Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Funcionário Inativo"
        End If
    End Sub
    '
    ' ATIVAR OU DESATIVAR USUARIO BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR um Funcionário Novo", "Desativar Funcionário",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim _func As clFuncionario = bindFunc.Current

        If _func.Ativo = True Then ' Funcionário ativo
            If MessageBox.Show("Você deseja realmente DESATIVAR o Funcionário:" & vbNewLine &
                        txtFuncionario.Text.ToUpper, "Desativar Funcionário", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _func.BeginEdit()
                _func.Ativo = False
                AtivoButtonImage()
            End If
        ElseIf _func.Ativo = False Then ' Funcionário Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR o Funcionário:" & vbNewLine &
            txtFuncionario.Text.ToUpper, "Ativar Funcionário", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _func.BeginEdit()
                _func.Ativo = True
                AtivoButtonImage()
            End If
        End If
    End Sub
    '
    ' ALTERAR A FILIAL SEDE DO FUNCIONARIO
    Private Sub btnAlterarFilial_Click(sender As Object, e As EventArgs) Handles btnAlterarFilial.Click
        '
        '--- Abre o frmFilial
        Dim fFil As New frmFilialEscolher()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            fFil.ShowDialog()
            '
            If fFil.DialogResult = DialogResult.Cancel Then Exit Sub
            '
            If fFil.propIdFilial_Escolha <> bindFunc.Current.IDFilial Then
                Sit = EnumFlagEstado.Alterado
                bindFunc.Current.IDFilial = fFil.propIdFilial_Escolha
                lblApelidoFilial.Text = fFil.propFilial_Escolha
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de procurar filial..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region
    '
End Class