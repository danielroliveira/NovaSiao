Imports CamadaDTO
Imports CamadaBLL

Public Class frmDespesaPeriodica
    Private _Despesa As clDespesaPeriodica
    Private BindDespesa As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registr
    Private VerificaAlteracao As Boolean = False
    Private dtVencimento As New DataTable
    '
#Region "LOAD"
    Sub New(DespesaPeriodica As clDespesaPeriodica, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        VerificaAlteracao = False
        propDespesa = DespesaPeriodica
        '
        Handler_MouseDown()
        Handler_MouseUp()
        Handler_MouseMove()
        '
    End Sub
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            Select Case _Sit
                Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
                    '
                    '--- Botoes
                    btnNova.Enabled = True
                    btnProcurar.Enabled = True
                    btnSalvar.Enabled = False
                    btnCredor.Enabled = True
                    btnTipo.Enabled = True
                    btnFechar.Text = "&Fechar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = False
                    txtIniciarData.ReadOnly = False
                    txtDespesaValor.ReadOnly = False
                    txtDescricao.ReadOnly = False
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    '
                    '--- Botoes
                    btnNova.Enabled = False
                    btnProcurar.Enabled = False
                    btnSalvar.Enabled = True
                    btnCredor.Enabled = True
                    btnTipo.Enabled = True
                    btnFechar.Text = "&Cancelar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = False
                    txtIniciarData.ReadOnly = False
                    txtDespesaValor.ReadOnly = False
                    txtDescricao.ReadOnly = False
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    '
                    '--- Botoes
                    btnNova.Enabled = False
                    btnProcurar.Enabled = False
                    btnSalvar.Enabled = True
                    btnCredor.Enabled = True
                    btnTipo.Enabled = True
                    btnFechar.Text = "&Fechar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = False
                    txtIniciarData.ReadOnly = False
                    txtDespesaValor.ReadOnly = False
                    txtDescricao.ReadOnly = False
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    '
                    '--- Botoes
                    btnNova.Enabled = True
                    btnProcurar.Enabled = True
                    btnSalvar.Enabled = False
                    btnCredor.Enabled = False
                    btnTipo.Enabled = False
                    btnFechar.Text = "&Fechar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = True
                    txtIniciarData.ReadOnly = True
                    txtDespesaValor.ReadOnly = True
                    txtDescricao.ReadOnly = True
                    '
            End Select
        End Set
    End Property
    '
    Property propDespesa As clDespesaPeriodica
        Get
            Return _Despesa
        End Get
        Set(value As clDespesaPeriodica)
            '--- Não Permite a verificacao dos combo
            VerificaAlteracao = False
            '
            _Despesa = value
            lblFilial.Text = _Despesa.ApelidoFilial
            '
            If IsNothing(BindDespesa.DataSource) Then
                BindDespesa.DataSource = _Despesa
                PreencheDataBinding()
            Else
                BindDespesa.Clear()
                BindDespesa.DataSource = _Despesa
                BindDespesa.ResetBindings(True)
            End If
            '
            '--- Atualiza o estado da Situacao: FLAGESTADO
            If _Despesa.Ativa = False Then
                Sit = EnumFlagEstado.RegistroBloqueado
            ElseIf IsNothing(_Despesa.IDDespesaPeriodica) Then
                Sit = EnumFlagEstado.NovoRegistro
                _Despesa.IDFilial = Obter_FilialPadrao()
                _Despesa.ApelidoFilial = ObterDefault("FilialDescricao")
            Else
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
            '--- define a PERIODICIDADE
            propPeriodicidade = _Despesa.Periodicidade
            '
            '--- Seleciona o primeiro controle
            txtCredor.Focus()
            '
            '--- Permite a verificacao dos combo
            VerificaAlteracao = True
            '
        End Set
        '
    End Property
    '
    Private Property propPeriodicidade() As Byte?
        Get
            Return _Despesa.Periodicidade
        End Get
        Set(ByVal value As Byte?)
            _Despesa.Periodicidade = value
            '
            Select Case value
                '--- seleciona o RADIO BUTON
                Case 1 '--- SEMANAL
                    rbtSemanal.Checked = True
                    rbtMensal.Checked = False
                    rbtAnual.Checked = False
                    '
                    cmbMesVencimento.Enabled = False
                    '
                    dtVencimentoAlterar(1)
                    '
                Case 2 '--- MENSAL
                    rbtSemanal.Checked = False
                    rbtMensal.Checked = True
                    rbtAnual.Checked = False
                    '
                    cmbMesVencimento.Enabled = False
                    '
                    dtVencimentoAlterar(2)
                    '
                Case 3 '--- ANUAL
                    rbtSemanal.Checked = False
                    rbtMensal.Checked = False
                    rbtAnual.Checked = True
                    '
                    cmbMesVencimento.Enabled = True
                    '
                    dtVencimentoAlterar(3)
                    '
                Case Else
                    rbtSemanal.Checked = False
                    rbtMensal.Checked = False
                    rbtAnual.Checked = False
                    '
                    dtVencimentoAlterar(Nothing)
                    '
            End Select
            '
        End Set
        '
    End Property
    '
#End Region
    '
#Region "DATABINDING"
    '
    Private Sub PreencheDataBinding()
        '
        lblID.DataBindings.Add("Text", BindDespesa, "IDDespesaPeriodica", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", BindDespesa, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCredor.DataBindings.Add("Text", BindDespesa, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCNP.DataBindings.Add("Text", BindDespesa, "CNP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaTipo.DataBindings.Add("Text", BindDespesa, "DespesaTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescricao.DataBindings.Add("Text", BindDespesa, "Descricao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIniciarData.DataBindings.Add("Text", BindDespesa, "IniciarData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaValor.DataBindings.Add("Text", BindDespesa, "DespesaValor", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler txtDespesaValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtIniciarData.DataBindings("text").Format, AddressOf FormatDT
        AddHandler lblCNP.DataBindings("text").Format, AddressOf FormatCNPNull
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbDiaVencimento()
        CarregaCmbMesVencimento()
        CarregaCmbRGBanco()
        CarregaCmbIDCobrancaForma()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Despesa.AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Despesa.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        eProvider.Clear()
        '
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub FormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        If IsNothing(e.Value) Then
            e.Value = "Nova"
        Else
            e.Value = Format(e.Value, "0000")
        End If
    End Sub
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    Private Sub FormatDT(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "dd/MM/yyyy")
    End Sub
    Private Sub FormatCNPNull(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        If IsNothing(e.Value) Then
            e.Value = "CNPJ/CPF Indefinido"
        End If
    End Sub
    '
#End Region
    '
#Region "CARREGA COMBO"
    '
    '--- CARERGA O COMBO MESVENCIMENTO
    Private Sub CarregaCmbMesVencimento()
        '
        Dim dtMes As New DataTable
        '
        dtMes.Columns.Add("Id")
        dtMes.Columns.Add("Texto")
        '
        '--- Adiciona todas as possibilidades de Meses do Ano
        For i = 1 To 12
            dtMes.Rows.Add(New Object() {i, MonthName(i)})
        Next
        '
        '
        With cmbMesVencimento
            .DataSource = dtMes
            .ValueMember = "Id"
            .DisplayMember = "Texto"
            If .DataBindings.Count = 0 Then
                .DataBindings.Add("SelectedValue", BindDespesa, "MesVencimento", True, DataSourceUpdateMode.OnPropertyChanged)
            End If
        End With
        '
    End Sub
    '
    '--- CARERGA O COMBO DIAVENCIMENTO
    Private Sub CarregaCmbDiaVencimento()
        '
        If dtVencimento.Columns.Count = 0 Then
            dtVencimentoAlterar(Nothing)
        End If
        '
        With cmbDiaVencimento
            .DataSource = dtVencimento
            .ValueMember = "Id"
            .DisplayMember = "Texto"
            If .DataBindings.Count = 0 Then
                .DataBindings.Add("SelectedValue", BindDespesa, "DiaVencimento", True, DataSourceUpdateMode.OnPropertyChanged)
            End If
        End With
        '
    End Sub
    '
    Public Sub dtVencimentoAlterar(vlPeriodicidade As Byte?)
        '
        '--- Adiciona as Colunas do dtVencimento para preencher o cmbVencimento
        If dtVencimento.Columns.Count = 0 Then
            dtVencimento.Columns.Add("Id")
            dtVencimento.Columns.Add("Texto")
        End If
        '
        dtVencimento.Rows.Clear()
        '
        Select Case vlPeriodicidade
            Case 1 '--- SEMANAL
                '
                '--- Adiciona todas as possibilidades de Dia da Semana
                dtVencimento.Rows.Add(New Object() {1, "Segunda-feira"})
                dtVencimento.Rows.Add(New Object() {2, "Terça-feira"})
                dtVencimento.Rows.Add(New Object() {3, "Quarta-feira"})
                dtVencimento.Rows.Add(New Object() {4, "Quinta-feira"})
                dtVencimento.Rows.Add(New Object() {5, "Sexta-feira"})
                dtVencimento.Rows.Add(New Object() {6, "Sábado"})
                dtVencimento.Rows.Add(New Object() {0, "Domingo"})
                '
            Case 2, 3  '--- MENSAL
                '
                '--- Adiciona todas as possibilidades de Dia do Mês
                For i = 1 To 31
                    dtVencimento.Rows.Add(New Object() {i, Format(i, "00")})
                Next
                '
        End Select
        '
        If IsNothing(_Despesa.DiaVencimento) Then
            cmbDiaVencimento.SelectedIndex = -1
        End If
        '
    End Sub
    '
    Private Sub CarregaCmbIDCobrancaForma()
        Dim pg As New APagarBLL
        '
        Try
            Dim dtForma As DataTable = pg.CobrancaFormas_APagar_GET
            '
            With cmbIDCobrancaForma
                .DataSource = dtForma
                .ValueMember = "IDCobrancaForma"
                .DisplayMember = "CobrancaForma"
                .DataBindings.Add("SelectedValue", BindDespesa, "IDCobrancaForma", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao obter a lista de Formas Pagamento:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub CarregaCmbRGBanco()
        Dim db As New BancosBLL
        '
        Try
            Dim dt As DataTable = db.GetBancosDt(True)
            '
            With cmbRGBanco
                .DataSource = dt
                .ValueMember = "RGBanco"
                .DisplayMember = "BancoNome"
                .DataBindings.Add("SelectedValue", BindDespesa, "RGBanco", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu obter lista de Bancos" & vbNewLine &
            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "BLOQUEIO DE REGISTROS"
    '
    ' PROIBE EDICAO NOS COMBOBOX QUANDO COMPRA BLOQUEADA
    '-----------------------------------------------------------------------------------------------------
    '
    Private Sub cmbVencimento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDiaVencimento.SelectedValueChanged,
        cmbMesVencimento.SelectedValueChanged, cmbIDCobrancaForma.SelectedValueChanged, cmbRGBanco.SelectedValueChanged
        '
        If VerificaAlteracao = False Then Exit Sub
        '
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            '
            Dim cmb As Control = DirectCast(sender, Control)
            VerificaAlteracao = False
            '

            Select Case cmb.Name
                Case "cmbDiaVencimento"
                    cmbDiaVencimento.SelectedValue = IIf(IsNothing(_Despesa.DiaVencimento), -1, _Despesa.DiaVencimento)
                Case "cmbMesVencimento"
                    cmbMesVencimento.SelectedValue = IIf(IsNothing(_Despesa.MesVencimento), -1, _Despesa.MesVencimento)
                Case "cmbIDCobrancaForma"
                    cmbIDCobrancaForma.SelectedValue = IIf(IsNothing(_Despesa.IDCobrancaForma), -1, _Despesa.IDCobrancaForma)
                Case "cmbRGBanco"
                    cmbRGBanco.SelectedValue = IIf(IsNothing(_Despesa.RGBanco), -1, _Despesa.RGBanco)
            End Select
            '
            VerificaAlteracao = True
            '
            '--- emite mensagem padrao
            RegistroBloqueado()
            '
        End If
        '
    End Sub
    '
    ' FUNCAO QUE CONFERE REGISTRO BLOQUEADO E EMITE MENSAGEM PADRAO
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroBloqueado() As Boolean
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            MessageBox.Show("Esse registro de DESPESA PERIODICA está BLOQUEADO para alterações..." & vbNewLine &
                            "Não é possível adicionar ou alterar algum dado!",
                            "Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If
    End Function
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS"
    '
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    '-----------------------------------------------------------------------------------------------------
    Private Sub Control_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles txtDescricao.KeyDown, txtDespesaValor.KeyDown,
        rbtAnual.KeyDown, rbtMensal.KeyDown, rbtSemanal.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSemanal.CheckedChanged,
        rbtMensal.CheckedChanged, rbtAnual.CheckedChanged
        '
        If rbtSemanal.Checked = True Then
            propPeriodicidade = 1
        ElseIf rbtMensal.Checked = True Then
            propPeriodicidade = 2
        ElseIf rbtAnual.Checked = True Then
            propPeriodicidade = 3
        End If
        '
    End Sub
    '
    Private Sub cmbRGBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbRGBanco.KeyDown
        If e.KeyCode = Keys.Delete Then
            _Despesa.BeginEdit()
            cmbRGBanco.SelectedItem = -1
            cmbRGBanco.Text = ""
            _Despesa.RGBanco = Nothing
        End If
    End Sub
    '
#End Region
    '
#Region "BUTONS"
    '
    ' PROCURA DESPESA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        Dim frmP As New frmDespesaPeriodicaProcurar
        '
        frmP.ShowDialog()
        '
        If btnProcurar.Enabled = False Then txtCredor.Focus()
    End Sub
    '
    ' CRIA UMA NOVA DESPESA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
        Dim desp As New clDespesaPeriodica
        '
        Sit = EnumFlagEstado.NovoRegistro
        '
        propDespesa = desp
        '
        txtCredor.Focus()
        '
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        If Sit = EnumFlagEstado.Alterado Then '--- OPERAÇÃO DE CANCELAR
            BindDespesa.CancelEdit()
            propPeriodicidade = _Despesa.Periodicidade
            Sit = EnumFlagEstado.RegistroSalvo
            txtCredor.Focus()
        Else '--- OPERACAO DE FECHAR
            Close()
            MostraMenuPrincipal()
        End If '
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCredor.KeyDown, txtDespesaTipo.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtCredor"
                    btnCredor_Click(New Object, New EventArgs)
                Case "txtDespesaTipo"
                    btnTipo_Click(New Object, New EventArgs)
            End Select
        ElseIf e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            'e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    Private Sub btnCredor_Click(sender As Object, e As EventArgs) Handles btnCredor.Click
        Dim frmC As New frmCredorProcurar(True, Me)
        '
        frmC.ShowDialog()
        If frmC.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Dim Cred As clCredor = frmC.propCredorEscolhido
        '
        txtCredor.Text = Cred.Cadastro
        _Despesa.CNP = Cred.CNP
        lblCNP.DataBindings.Item("text").ReadValue()
        _Despesa.IDCredor = Cred.IDPessoa
        '
        If Cred.CredorTipo = 1 Then
            lblCNPTexto.Text = "CPF"
        ElseIf Cred.CredorTipo = 2 Then
            lblCNPTexto.Text = "CNPJ"
        Else Cred.CredorTipo = 0 OrElse Cred.CredorTipo = 3
            lblCNPTexto.Text = "CNPJ"
        End If
        '
    End Sub
    '
    Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        Dim frmT As New frmDespesaTipoProcurar(True, Me)
        '
        frmT.ShowDialog()
        If frmT.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Dim T As clDespesaTipo = frmT.propDespesaEscolhida
        '
        txtDespesaTipo.Text = T.DespesaTipo
        _Despesa.IDDespesaTipo = T.IDDespesaTipo
        _Despesa.DespesaTipo = T.DespesaTipo
        '
    End Sub
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub frmDespesaPeriodica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "+" Then
            e.Handled = True
        End If
    End Sub
#End Region
    '
#Region "SALVAR REGISTRO"
    '
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- Verifica os Controles
        '----------------------------------------------------------------------
        If Not VerificaControles() Then Exit Sub
        '
        '--- Salva a Despesa
        '----------------------------------------------------------------------
        Dim dBLL As New DespesaPeriodicaBLL
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            '
            Try
                Dim newID As Integer = dBLL.DespesaPeriodica_Inserir(_Despesa)
                '
                _Despesa.IDDespesaPeriodica = newID
                lblID.DataBindings("text").ReadValue()
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao inserir nova Despesa Periódica:" & vbNewLine &
                            ex.Message & vbNewLine & "O registro não pode ser salvo...",
                            "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            '
            Try
                Dim newID As Integer = dBLL.DespesaPeriodica_Alterar(_Despesa)
                '
                _Despesa.IDDespesaPeriodica = newID
                lblID.DataBindings("text").ReadValue()
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao alterar a despesa Periódica:" & vbNewLine &
                                ex.Message & vbNewLine & "O registro não pode ser salvo...",
                                "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            '
        End If
        '
        '--- Finaliza
        '----------------------------------------------------------------------
        MessageBox.Show("Registro Salvo com sucesso!",
                        "Registro Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Sit = EnumFlagEstado.RegistroSalvo
        txtCredor.Focus()
        '
    End Sub
    '
    Private Function VerificaControles() As Boolean
        Dim f As New FuncoesUtilitarias
        '
        If Not f.VerificaDadosClasse(txtCredor, "Credor", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDespesaTipo, "Tipo de Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDescricao, "Descrição da Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDespesaTipo, "Tipo de Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If IsNothing(_Despesa.Periodicidade) Then
            MessageBox.Show("Escolha a Periodicidade da Despesa Periódica...", "Periodicidade",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlPeriodicidade.Focus()
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtIniciarData, "Data da Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(cmbDiaVencimento, "Dia do Vencimento", _Despesa, eProvider) Then
            Return False
        End If
        '
        '--- caso periodicidade = anual, deve escolher o mes
        If _Despesa.Periodicidade = 3 Then
            If Not f.VerificaDadosClasse(cmbMesVencimento, "Mês do Vencimento", _Despesa, eProvider) Then
                Return False
            End If
        End If
        '
        '--- caso periodicidade = Semanal, verifica se a data inicial é o mesmo dia da semana
        If _Despesa.Periodicidade = 1 Then '--- Despesa SEMANAL
            If CDate(_Despesa.IniciarData).DayOfWeek <> _Despesa.DiaVencimento Then
                MessageBox.Show("A dia da semana da data início: " & Format(_Despesa.IniciarData, "dddd") &
                                " deve ser o mesmo dia da semana escolhido...", "Data Inicio",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIniciarData.Focus()
                Return False
            End If
        End If
        '
        If Not f.VerificaDadosClasse(txtDespesaValor, "Valor da Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If CDbl(txtDespesaValor.Text) = 0 Then
            MessageBox.Show("O Valor da Despesa Mensal não pode ser igual a Zero", "Valor da Despesa",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDespesaValor.Focus()
            Return False
        End If
        '
        Return True
        '
    End Function
    '
#End Region
    '
End Class