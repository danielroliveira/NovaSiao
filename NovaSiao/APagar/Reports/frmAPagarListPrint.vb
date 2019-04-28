Imports CamadaDTO
'
Public Class frmAPagarListPrint
    Private _lstAPagar As List(Of clAPagar)
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
    End Sub
    '
    Sub New(lstAPagar As List(Of clAPagar))
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _lstAPagar = lstAPagar '.OrderBy(Function(x) x.IDEtiqueta).ToList
        '
    End Sub
    '
    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        'Criar a lista
        'Dim lista As List(Of clProdutoEtiqueta) = _ProdutoEtiqueta
        '
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("dtsAPagar", _lstAPagar)
        '
        '--- define o relatório
        rptvLocal.LocalReport.DataSources.Clear()
        rptvLocal.LocalReport.DataSources.Add(ds)
        ds.Value = _lstAPagar
        rptvLocal.LocalReport.Refresh()
        rptvLocal.RefreshReport()
        rptvLocal.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        '
        '--- define o tamanho
        Width = Application.OpenForms("frmPrincipal").Width - 200
        Dim tamMaxH = Application.OpenForms("frmPrincipal").Height
        Height = tamMaxH - (tamMaxH * 20) / 100
        '
        '--- define a posicao
        'Dim posX As Integer = Width / 2 - 30
        'Location = New Point(posX, 50)
        Me.CenterToScreen()
        '
    End Sub
    '
End Class
