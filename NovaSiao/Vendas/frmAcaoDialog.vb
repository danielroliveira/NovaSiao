Public Class frmAcaoDialog
    Private _formOrigem As Form
    '
    Sub New(Origem As Form, OrigemTexto As String)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = Origem
        lblOrigem.Text = OrigemTexto.ToUpper
        btnNova.Text = "Nova"
        btnProcurar.Text = "Procurar"
        '
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
        '
        Select Case _formOrigem.Name
            Case "frmVendaPrazo"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmVendaPrazo).NovaVenda()
            Case "frmVendaVista"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmVendaVista).NovaVenda()
            Case "frmCompra"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmCompra).NovaCompra()
            Case "frmSimplesEntrada"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmSimplesEntrada).NovaSimples()
            Case "frmDevolucaoSaida"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmDevolucaoSaida).NovaDevolucao()
            Case Else
                Me.DialogResult = DialogResult.Cancel
        End Select
        '
    End Sub
    '
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        Select Case _formOrigem.Name
            Case "frmVendaPrazo"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmVendaPrazo).ProcuraVenda()
            Case "frmVendaVista"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmVendaVista).ProcuraVenda()
            Case "frmCompra"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmCompra).ProcuraCompra()
            Case "frmSimplesEntrada"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmSimplesEntrada).ProcuraSimples()
            Case "frmDevolucaoSaida"
                Me.DialogResult = DialogResult.OK
                DirectCast(_formOrigem, frmDevolucaoSaida).ProcuraDevolucao()
            Case Else
                Me.DialogResult = DialogResult.Cancel
        End Select
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.SlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    Private Sub me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnFechar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub Me_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.Silver
            End If
        Next
    End Sub
    '
    Private Sub Me_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.SlateGray
            End If
        Next
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR LINHA SOB O LBLORIGEM
    '-------------------------------------------------------------------------------------------------
    Private Sub lblOrigem_Paint(sender As Object, e As PaintEventArgs) Handles lblOrigem.Paint
        '
        Dim myPen As New Pen(Color.SlateGray, 2)
        Dim formGraphics As Graphics
        formGraphics = Me.CreateGraphics()

        Dim x1 As Integer = e.ClipRectangle.Left + lblOrigem.Location.X
        Dim x2 As Integer = e.ClipRectangle.Right + lblOrigem.Location.X
        Dim y1 As Integer = e.ClipRectangle.Bottom + lblOrigem.Location.Y + 5

        formGraphics.DrawLine(myPen, x1, y1, x2, y1)

        myPen.Dispose()
        formGraphics.Dispose()
        '
    End Sub
    '
End Class
