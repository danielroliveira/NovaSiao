Imports CamadaDTO
Imports Microsoft.Reporting.WinForms
'
Public Class frmReportPedido
    Private _pedido As clPedido
    Private _items As List(Of clPedidoItem)
    Private _mensagems As New List(Of clPedidoMensagem)
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
    End Sub
    '
    Sub New(pedido As clPedido,
            pedidoItems As List(Of clPedidoItem),
            mensagems As List(Of clPedidoMensagem))
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _pedido = pedido
        _items = pedidoItems
        _mensagems = mensagems
        '
    End Sub
    '
    Private Sub me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        'Criar a lista de ClientePF
        Dim lista As New List(Of clPedido)
        lista.Add(_pedido)
        Dim dadosEmpresa As New List(Of clDadosEmpresa)
        dadosEmpresa.Add(ObterDadosEmpresa)
        '
        Dim ds As New ReportDataSource("dsPedido", lista)
        Dim dsItems As New ReportDataSource("dsItems", _items)
        Dim dsEmpresa As New ReportDataSource("dsEmpresa", dadosEmpresa)
        Dim dsMensagems As New ReportDataSource("dsMensagems", _mensagems)
        '
        '--- define o relatório
        '-------------------------------------------------------------
        '--- clear dataSources
        rptvPadrao.LocalReport.DataSources.Clear()
        '
        '--- insert data
        rptvPadrao.LocalReport.DataSources.Add(ds)
        rptvPadrao.LocalReport.DataSources.Add(dsItems)
        rptvPadrao.LocalReport.DataSources.Add(dsEmpresa)
        rptvPadrao.LocalReport.DataSources.Add(dsMensagems)
        '
        '--- set Logo Path
        getLogo(dadosEmpresa(0).ArquivoLogoMono)
        '
        '-- display
        rptvPadrao.SetDisplayMode(DisplayMode.PrintLayout)
        rptvPadrao.RefreshReport()
        '
        '--- define o tamanho
        Dim tamMaxH = Screen.PrimaryScreen.Bounds.Height
        Height = tamMaxH - (tamMaxH * 10) / 100
        Me.CenterToScreen()
        '
    End Sub
    '
    Private Sub getLogo(path As String)
        '
        Dim params As New List(Of ReportParameter)
        '
        rptvPadrao.LocalReport.EnableExternalImages = True
        Dim imagePath As String = path
        Dim parameterLogo As New ReportParameter("LogoPath", "file:\\" + imagePath)
        '
        params.Add(parameterLogo)
        rptvPadrao.LocalReport.SetParameters(params)
        rptvPadrao.LocalReport.Refresh()
        '
    End Sub
    '
End Class
