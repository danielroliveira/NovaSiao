Public Class frmDataMesAno
    '
    Private _formOrigem As Form
    Property propMes As Integer = Nothing
    Property propAno As Integer = Nothing
    '
#Region "NEW | LOAD"
    '
    '--- WITH MES E ANO
    '--------------------------------------------------------------------------------------
    Sub New(SubTitulo As String,
            MesPadrao As Integer,
            AnoPadrao As Integer,
            AnoInicial As Integer,
            formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        lblTitulo.Text = "Informe o Mês e o Ano"
        lblSubTitulo.Text = SubTitulo
        '
        _formOrigem = formOrigem
        '
        PreencheComboMes()
        PreencheComboAno(AnoInicial)
        '
    End Sub
    '
    '--- ONLY MES | ANO DISABLED
    '--------------------------------------------------------------------------------------
    Sub New(SubTitulo As String,
            MesPadrao As Integer,
            formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        lblTitulo.Text = "Informe o Mês"
        lblSubTitulo.Text = SubTitulo
        '
        cmbAno.Enabled = False
        '
        _formOrigem = formOrigem
        '
        PreencheComboMes()
        cmbMes.SelectedValue = MesPadrao
        '
    End Sub
    '
    '--- ONLY ANO | MES DISABLED
    '--------------------------------------------------------------------------------------
    Sub New(SubTitulo As String,
            AnoPadrao As Integer,
            AnoInicial As Integer,
            formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        lblTitulo.Text = "Informe o Ano"
        lblSubTitulo.Text = SubTitulo
        '
        cmbMes.Enabled = False
        '
        _formOrigem = formOrigem
        '
        PreencheComboAno(AnoInicial)
        If AnoPadrao >= AnoInicial AndAlso AnoPadrao <= Year(Today) Then
            cmbAno.SelectedValue = AnoPadrao
        End If
        '
    End Sub
    '
    Private Sub PreencheComboMes()
        '
        Dim dtMes As New DataTable
        '
        '--- Adiciona as Colunas
        dtMes.Columns.Add("idMes")
        dtMes.Columns.Add("Mes")
        '
        '--- Adiciona todas as possibilidades de Meses
        dtMes.Rows.Add(New Object() {1, "Janeiro"})
        dtMes.Rows.Add(New Object() {2, "Fevereiro"})
        dtMes.Rows.Add(New Object() {3, "Março"})
        dtMes.Rows.Add(New Object() {4, "Abril"})
        dtMes.Rows.Add(New Object() {5, "Maio"})
        dtMes.Rows.Add(New Object() {6, "Junho"})
        dtMes.Rows.Add(New Object() {7, "Julho"})
        dtMes.Rows.Add(New Object() {8, "Agosto"})
        dtMes.Rows.Add(New Object() {9, "Setembro"})
        dtMes.Rows.Add(New Object() {10, "Outubro"})
        dtMes.Rows.Add(New Object() {11, "Novembro"})
        dtMes.Rows.Add(New Object() {12, "Dezembro"})
        '
        With cmbMes
            .DataSource = dtMes
            .ValueMember = "idMes"
            .DisplayMember = "Mes"
        End With
        '
    End Sub
    '
    Private Sub PreencheComboAno(AnoInicial As Integer)
        '
        Dim AnoFinal As Integer = Year(Today)
        '
        Do Until AnoInicial = AnoFinal
            cmbAno.Items.Add(New Object() {AnoInicial})
            AnoInicial += 1
        Loop
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        If cmbAno.Enabled Then propAno = cmbAno.SelectedText
        If cmbMes.Enabled Then propMes = cmbMes.SelectedValue
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
#End Region
    '
#Region "VISUAL EFFECTS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class
