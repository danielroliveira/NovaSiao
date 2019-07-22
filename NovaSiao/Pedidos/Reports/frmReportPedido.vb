Imports System.IO
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
    End Sub
    '
    Private Sub me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim parameterLogo As New ReportParameter("LogoPath", "file:\\" + path)
        '
        params.Add(parameterLogo)
        rptvPadrao.LocalReport.SetParameters(params)
        rptvPadrao.LocalReport.Refresh()
        '
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click, btnEnviar.Click
        '
        Dim fornecedor As String = _pedido.Fornecedor
        fornecedor = fornecedor.Replace(" ", "_")
        '
        '--- get Folder Pedido
        Dim pedidoFolder As String = ObterConfigValorNode("PedidosFolder")
        If Trim(pedidoFolder) = "" Then
            AbrirDialog("A pasta padrão dos Pedidos ainda não foi configurada no Config.",
                        "Pasta dos Pedidos", frmDialog.DialogType.OK,
            frmDialog.DialogIcon.Exclamation)
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim bytes As Byte() = rptvPadrao.LocalReport.Render("PDF")
            '
            Dim regData As String = " - " & Format(_pedido.IDPedido, "0000") & " - " & Today.Year & Format(Today, "MM") & Format(Today, "dd")
            Dim arquivoPDF As String = pedidoFolder & "\" & fornecedor & regData & ".pdf"
            '
            Using fs As New FileStream(arquivoPDF, FileMode.Create)
                fs.Write(bytes, 0, bytes.Length)
            End Using
            '
            '--- INFORM USER
            If AbrirDialog("Arquivo PDF Salvo na pasta padrão..." & vbCrLf &
                           "Deseja enviar o pedido por E-mail?",
                           "Enviar Email",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                '
                '--- enviar Email
                If Trim(_pedido.EmailVendas) <> "" Then
                    EnviarEmail()
                Else
                    MessageBox.Show("Não há endereço de email do Fornecedor definido ainda...",
                                    "Email Destinatário",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                End If
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar pedido PDF..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Public Sub EnviarEmail()
        '
        Dim fornecedor As String = _pedido.Fornecedor
        fornecedor = fornecedor.Replace(" ", "_")
        '
        '--- get TEMP Folder
        Dim pedidoFolder As String = Path.GetTempPath
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- SAVE TEMPORARY FILE
            '-------------------------------------------------------------------------------------
            Dim bytes As Byte() = rptvPadrao.LocalReport.Render("PDF")
            '
            Dim regData As String = " - " & Format(_pedido.IDPedido, "0000") & " - " & Today.Year & Format(Today, "MM") & Format(Today, "dd")
            Dim arquivoPDF As String = pedidoFolder & fornecedor & regData & ".pdf"
            '
            Using fs As New FileStream(arquivoPDF, FileMode.Create)
                fs.Write(bytes, 0, bytes.Length)
                fs.Dispose()
            End Using
            '
            '--- SEND EMAIL
            '-------------------------------------------------------------------------------------
            '--- define Message
            Dim mensagem As String = "Pedido de produtos."
            For Each m In _mensagems
                mensagem += vbCrLf + m.Mensagem
            Next
            mensagem += vbCrLf + "Detalhamento do Pedido em arquivo anexo..."
            mensagem += vbCrLf + "Favor informar o recebimento deste pedido, obrigado!"
            '
            '--- define Title
            Dim title As String = "Pedido"
            '
            If Trim(_pedido.VendedorNome) <> "" Then
                title += " Att. " + _pedido.VendedorNome.ToUpper
            End If
            '
            Dim frmEmail As New frmEmail(_pedido.EmailVendas, title, mensagem, title, arquivoPDF)
            frmEmail.ShowDialog()
            '
            '--- DELETE TEMP FILE
            '-------------------------------------------------------------------------------------
            File.Delete(arquivoPDF)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar pedido PDF..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
End Class
