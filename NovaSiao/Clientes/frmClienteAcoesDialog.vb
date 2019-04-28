Public Class frmClienteAcoesDialog
    Dim myOrigem As Form

    Public Sub New(frmOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        myOrigem = frmOrigem
        '
    End Sub

    Private Sub frmClienteAcoesDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim A As New ToolStripButton
        Dim B As New ToolStripButton

        A.Text = "Ficha de Cadastro"
        A.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnImprimir.DropDownMenu.Items.Insert(0, A)
        AddHandler A.Click, AddressOf ImprimirFichaCadastro

        B.Text = "Ficha de Cobrança"
        B.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnImprimir.DropDownMenu.Items.Insert(1, B)
        AddHandler B.Click, AddressOf ImprimirFichaCobranca

    End Sub
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        btnImprimir.DropDownMenu.Show(btnImprimir.PointToScreen(New Point(0, btnImprimir.Height)))
    End Sub

    ' AÇÃO DOS BOTÕES
    '------------------------------------------------------------------------------------------------------
    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        '
        If myOrigem.Name = "frmClientePF" Then
            DirectCast(myOrigem, frmClientePF).RealizaAcaoInterna("PERMANECER")
        Else
            DirectCast(myOrigem, frmClientePJ).RealizaAcaoInterna("PERMANECER")
        End If
        '
        Me.Close()
        '
    End Sub
    '
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        '
        If myOrigem.Name = "frmClientePF" Then
            DirectCast(myOrigem, frmClientePF).RealizaAcaoInterna("NOVO")
        Else
            DirectCast(myOrigem, frmClientePJ).RealizaAcaoInterna("NOVO")
        End If
        '
        Me.Close()
        '
    End Sub
    '
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        If myOrigem.Name = "frmClientePF" Then
            DirectCast(myOrigem, frmClientePF).RealizaAcaoInterna("PROCURAR")
        Else
            DirectCast(myOrigem, frmClientePJ).RealizaAcaoInterna("PROCURAR")
        End If
        '
        Me.Close()
        '
    End Sub
    '
    Public Sub ImprimirFichaCadastro()
        '
        If myOrigem.Name = "frmClientePF" Then
            DirectCast(myOrigem, frmClientePF).RealizaAcaoInterna("FICHACADASTRO")
        Else
            DirectCast(myOrigem, frmClientePJ).RealizaAcaoInterna("FICHACADASTRO")
        End If
        '
        Me.Close()
        '
    End Sub
    '
    Public Sub ImprimirFichaCobranca()
        '
        If myOrigem.Name = "frmClientesPF" Then
            DirectCast(myOrigem, frmClientePF).RealizaAcaoInterna("FICHACOBRANCA")
        Else
            DirectCast(myOrigem, frmClientePJ).RealizaAcaoInterna("FICHACOBRANCA")
        End If
        '
        Me.Close()
        '
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        If myOrigem.Name = "frmClientePF" Then
            DirectCast(myOrigem, frmClientePF).RealizaAcaoInterna("FECHAR")
        Else
            DirectCast(myOrigem, frmClientePJ).RealizaAcaoInterna("FECHAR")
        End If
        '
        Me.Close()
        '
    End Sub
    '
End Class