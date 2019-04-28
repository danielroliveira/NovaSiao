Imports CamadaBLL
Imports CamadaDTO

Public Class frmDespesaTipo
    Private _DTipo As clDespesaTipo
    Private BindTipo As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private VerificaAlteracao As Boolean = False
    Private _formOrigem As Form
    '
#Region "SUB NEW | PROPERTIES"
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnFechar.Text = "&Fechar"

            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnFechar.Text = "&Cancelar"

            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                btnSalvar.Enabled = True
                btnFechar.Text = "&Cancelar"

            End If
        End Set
    End Property
    '
    Sub New(DTipo As clDespesaTipo, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _DTipo = DTipo
        _formOrigem = formOrigem
        BindTipo.DataSource = _DTipo
        PreencheDataBindings()
        '
        '--- verifica se o é um NOVO CREDOR
        If IsNothing(_DTipo.IDDespesaTipo) Then
            Sit = EnumFlagEstado.NovoRegistro
        Else
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
        VerificaAlteracao = True
        '
    End Sub
    '
#End Region '/ SUB NEW | PROPERTIES
    '
#Region "BINDING"
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblID.DataBindings.Add("Text", BindTipo, "IDDespesaTipo")
        txtDespesaTipo.DataBindings.Add("Text", BindTipo, "DespesaTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' CARREGA OS COMBOS
        CarregaComboPeriodicidade()
        CarregaComboVariacao()

        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Text").Format, AddressOf idFormatRG
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _DTipo.AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _DTipo.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
    Private Sub CarregaComboPeriodicidade()
        Dim dtP As New DataTable
        '
        ' Adiciona todas as possibilidades
        dtP.Columns.Add("IDPerioricidade")
        dtP.Columns.Add("Perioricidade")
        dtP.Rows.Add(New Object() {0, "Variavel"})
        dtP.Rows.Add(New Object() {1, "Semanal"})
        dtP.Rows.Add(New Object() {2, "Mensal"})
        dtP.Rows.Add(New Object() {3, "Anual"})
        '
        With cmbPeriodicidade
            .DataSource = dtP
            .ValueMember = "IDPerioricidade"
            .DisplayMember = "Perioricidade"
            .DataBindings.Add("SelectedValue", BindTipo, "Periodicidade", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
    Private Sub CarregaComboVariacao()
        Dim dtV As New DataTable
        '
        ' Adiciona todas as possibilidades
        '0:Despesa Fixa | 1: Despesa Variavel | 2: Custo
        '
        dtV.Columns.Add("IDVariacao")
        dtV.Columns.Add("Variacao")
        dtV.Rows.Add(New Object() {0, "Despesa Fixa"})
        dtV.Rows.Add(New Object() {1, "Despesa Variavel"})
        dtV.Rows.Add(New Object() {2, "Custo"})
        '
        With cmbVariacao
            .DataSource = dtV
            .ValueMember = "IDVariacao"
            .DisplayMember = "Variacao"
            .DataBindings.Add("SelectedValue", BindTipo, "Variacao", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
#End Region
    '
#Region "FUNCOES UTILITARIAS"
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDespesaTipo.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' CRIA UM ATALHO PARA OS COMBO BOX
    '------------------------------------------------------------------------------------------
    Private Sub cmbTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPeriodicidade.KeyPress, cmbVariacao.KeyPress
        If Char.IsNumber(e.KeyChar) AndAlso Sit = EnumFlagEstado.NovoRegistro Then
            e.Handled = True
            '
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            Dim dt As DataTable = cmb.DataSource
            Dim rCount As Integer = dt.Rows.Count
            Dim item As Integer = e.KeyChar.ToString
            '
            If item <= rCount And item > 0 Then
                Dim Valor As Integer = dt.Rows(e.KeyChar.ToString - 1)(1)
                '
                cmb.SelectedValue = Valor
                '
            End If
        End If
    End Sub
    '
#End Region
    '
#Region "ACAO BOTOES"
    '
    '--- BTN FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Close()
        ElseIf Sit = enumFlagEstado.Alterado Then
            BindTipo.CancelEdit()
            Sit = EnumFlagEstado.RegistroSalvo
        ElseIf Sit = enumFlagEstado.NovoRegistro Then
            If MessageBox.Show("Deseja cancelar Inserir no Tipo de Despesa?", "Cancelar",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then
                txtDespesaTipo.Focus()
            Else
                DialogResult = DialogResult.Cancel
            End If
        End If
        '
    End Sub
    '
    '--- BTN SALVAR
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
        Dim tBLL As New DespesaTipoBLL
        '
        Try
            Dim newID As Integer = tBLL.DespesaTipo_Inserir(_DTipo)
            '
            _DTipo.IDDespesaTipo = newID
            lblID.DataBindings.Item("Text").ReadValue()
            Sit = EnumFlagEstado.RegistroSalvo
            MessageBox.Show("Registro Salvo com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção inesperada ao salvar Tipo de Despesa:" & vbNewLine & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDespesaTipo.Focus()
        End Try
    End Sub
    '
    Private Sub AlterarRegistro()
        '
        Dim tBLL As New DespesaTipoBLL
        '
        Try
            tBLL.DespesaTipo_Alterar(_DTipo)
            '
            MessageBox.Show("Registro Alterado com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Sit = EnumFlagEstado.RegistroSalvo
            DialogResult = DialogResult.OK
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção inesperada ao alterar o Tipo de Despesa:" & vbNewLine & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDespesaTipo.Focus()
        End Try
        '
    End Sub
    '
    Private Function VerificaControles() As Boolean
        Dim f As New FuncoesUtilitarias
        '
        If f.VerificaControlesForm(txtDespesaTipo, "Nome/Razão Social do Credor") = False Then
            Return False
        End If
        '
        If f.VerificaControlesForm(cmbPeriodicidade, "Periodicidade") = False Then
            Return False
        End If
        '
        If f.VerificaControlesForm(cmbVariacao, "Variacao") = False Then
            Return False
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
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmDespesaTipo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region
End Class
