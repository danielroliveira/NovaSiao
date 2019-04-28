Public Class frmModNBorder
    '
    Dim Px, Py As Integer
    Dim mover As Boolean
    '
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        Handler_MouseDown()
        Handler_MouseMove()
        Handler_MouseUp()
        '
    End Sub
    '
    ' MOVER O FORMULÁRIO SEM BORDA
    '-----------------------------------------------------------------------------------------------

    ' MOVER PELO PAINEL E PELO TÍTULO
    Private Sub Painel_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lblTitulo.MouseDown
        Px = Cursor.Position.X - Me.Left

        If Me.IsMdiChild Then
            Py = Cursor.Position.Y - Me.Top + Screen.PrimaryScreen.WorkingArea.Height - Parent.ClientSize.Height + 3
        Else
            Py = Cursor.Position.Y - Me.Top + Screen.PrimaryScreen.WorkingArea.Height - frmPrincipal.ClientSize.Height + Panel1.Height - 10
        End If
        mover = True
    End Sub
    Private Sub Painel_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lblTitulo.MouseUp
        mover = False
    End Sub
    Private Sub Painel_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lblTitulo.MouseMove
        'Dim c As Control = DirectCast(sender, Control)

        If mover = True Then
            Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - Px,
                                                     MousePosition.Y - Me.Location.Y - Py))
        End If
    End Sub
    '
    '=============================================================================
    ' HANDLERS ADICONA MOVE NOS CONTROLES DO PAINEL
    '=============================================================================
    Friend Sub Handler_MouseMove()
        '--- adiciona o Handler no Painel
        AddHandler Panel1.MouseMove, AddressOf Painel_MouseMove
        '
        '-- adiciona o Handler em todos os controles do painel
        For Each c As Control In Panel1.Controls
            AddHandler c.MouseMove, AddressOf Painel_MouseMove
        Next
    End Sub
    '
    Friend Sub Handler_MouseUp()
        '--- adiciona o Handler no Painel
        AddHandler Panel1.MouseUp, AddressOf Painel_MouseUp
        '
        '-- adiciona o Handler em todos os controles do painel
        For Each c As Control In Panel1.Controls
            AddHandler c.MouseUp, AddressOf Painel_MouseUp
        Next
    End Sub
    '
    Friend Sub Handler_MouseDown()
        '--- adiciona o Handler no Painel
        AddHandler Panel1.MouseDown, AddressOf Painel_MouseDown
        '
        '-- adiciona o Handler em todos os controles do painel
        For Each c As Control In Panel1.Controls
            AddHandler c.MouseDown, AddressOf Painel_MouseDown
        Next
    End Sub
    '
End Class