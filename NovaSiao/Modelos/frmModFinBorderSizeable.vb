Public Class frmModFinBorderSizeable
    Dim Px, Py As Integer
    Dim mover As Boolean
    '
    Const WM_NCLBUTTONDOWN As Integer = &HA1S
    Const HTBOTTOM As Integer = 15
    Const HTBOTTOMLEFT As Integer = 16
    Const HTBOTTOMRIGHT As Integer = 17
    Const HTLEFT As Integer = 10
    Const HTRIGHT As Integer = 11
    Const HTTOP As Integer = 12
    Const HTTOPLEFT As Integer = 13
    Const HTTOPRIGHT As Integer = 14
    '
#Region "NEW | LOAD"
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
        Me.btnClose.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        '
    End Sub
    '
    Private Sub me_Show(sender As Object, e As EventArgs) Handles MyBase.Shown
        RedesenhaBorder()
    End Sub
    '
#End Region
    '
#Region "VISUAL"
    '
    Friend Sub RedesenhaBorder()
        '--- Redesenha a border do form
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.SlateGray, 5)
        '
        Me.Refresh()
        Me.CreateGraphics.DrawRectangle(pen, rect)
        '
    End Sub
    '
#End Region
    '
#Region "MOVIMENTO"
    '-----------------------------------------------------------------------------------------------
    ' MOVER O FORMULÁRIO SEM BORDA
    '-----------------------------------------------------------------------------------------------
    ' MOVER PELO PAINEL E PELO TÍTULO
    Private Sub Painel_MouseDown(sender As Object, e As MouseEventArgs)
        Px = Cursor.Position.X - Me.Left
        Py = Cursor.Position.Y - Me.Top '+ Screen.PrimaryScreen.WorkingArea.Height - frmPrincipal.ClientSize.Height + Panel1.Height


        'If Me.IsMdiChild Then
        '    Py = Cursor.Position.Y - Me.Top + Screen.PrimaryScreen.WorkingArea.Height - Parent.ClientSize.Height
        'Else
        '    Py = Cursor.Position.Y - Me.Top + Screen.PrimaryScreen.WorkingArea.Height - frmPrincipal.ClientSize.Height + Panel1.Height
        'End If
        mover = True
        Cursor = Cursors.SizeAll
    End Sub
    '
    Private Sub Painel_MouseUp(sender As Object, e As MouseEventArgs)
        mover = False
        Cursor = Cursors.Arrow
    End Sub
    '
    Private Sub Painel_MouseMove(sender As Object, e As MouseEventArgs)
        Dim c As Control = DirectCast(sender, Control)
        '
        If mover = True Then
            Cursor = Cursors.SizeAll
            Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - Px,
                                                  MousePosition.Y - Me.Location.Y - Py))
            RedesenhaBorder()
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
    '
    Friend Sub Handler_MouseMove()
        '--- adiciona o Handler no Painel
        AddHandler Panel1.MouseMove, AddressOf Painel_MouseMove
        '
        '-- adiciona o Handler em todos os controles  LABEL do painel
        For Each c As Control In Panel1.Controls
            If TypeOf c Is Label Then
                AddHandler c.MouseMove, AddressOf Painel_MouseMove
            End If
        Next
    End Sub
    '
    Friend Sub Handler_MouseUp()
        '--- adiciona o Handler no Painel
        AddHandler Panel1.MouseUp, AddressOf Painel_MouseUp
        '
        '-- adiciona o Handler em todos os controles LABEL do painel
        For Each c As Control In Panel1.Controls
            If TypeOf c Is Label Then
                AddHandler c.MouseUp, AddressOf Painel_MouseUp
            End If
        Next
    End Sub
    '
    Friend Sub Handler_MouseDown()
        '--- adiciona o Handler no Painel
        AddHandler Panel1.MouseDown, AddressOf Painel_MouseDown
        '
        '-- adiciona o Handler em todos os controles LABEL do painel
        For Each c As Control In Panel1.Controls
            If TypeOf c Is Label Then
                AddHandler c.MouseDown, AddressOf Painel_MouseDown
            End If
        Next
    End Sub
    '
#End Region
    '
#Region "REDIMENSIONAR"
    '
    Private Sub me_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        '
        If e.Button = MouseButtons.Left Then
            Me.Capture = False
            Dim theCursor As Cursor = Cursors.Arrow
            Dim Direction As New IntPtr(Bottom)
            '
            Dim posX, posY As Integer()
            '
            posX = {0, 1, 2, 3, Width - 1, Width - 2, Width - 3, Width - 4}
            posY = {Height - 1, Height - 2, Height - 3, Height - 4}
            '
            If posX.Contains(e.X) OrElse posY.Contains(e.Y) Then
                '
                Select Case e.X
                    Case 0 To 3 ' On the left line
                        Select Case e.Y
                            Case 0 To 3
                                ' top left corner
                                Direction = CType(HTTOPLEFT, IntPtr)
                                theCursor = Cursors.SizeNWSE
                            Case Me.Height - 4 To Me.Height - 1
                                ' bottom left corner
                                Direction = CType(HTBOTTOMLEFT, IntPtr)
                                theCursor = Cursors.SizeNESW
                            Case Else
                                ' left side
                                Direction = CType(HTLEFT, IntPtr)
                                theCursor = Cursors.SizeWE
                        End Select
                        '
                    Case Me.Width - 4 To Me.Width - 1 ' On the right line
                        Select Case e.Y
                            Case 0 To 3
                                ' top right corner
                                Direction = CType(HTTOPRIGHT, IntPtr)
                                theCursor = Cursors.SizeNESW
                            Case Me.Height - 4 To Me.Height - 1
                                ' bottom right corner
                                Direction = CType(HTBOTTOMRIGHT, IntPtr)
                                theCursor = Cursors.SizeNWSE
                            Case Else
                                ' right side
                                Direction = CType(HTRIGHT, IntPtr)
                                theCursor = Cursors.SizeWE
                        End Select
                    Case Else
                        Select Case e.Y
                            Case 0 To 3
                                ' top line
                                Direction = CType(HTTOP, IntPtr)
                                theCursor = Cursors.SizeNS
                            Case Me.Height - 4 To Me.Height - 1
                                ' bottom line
                                Direction = CType(HTBOTTOM, IntPtr)
                                theCursor = Cursors.SizeNS
                        End Select
                        '
                End Select
                '
                Me.Cursor = theCursor
                Dim msg As Message = Message.Create(Me.Handle, WM_NCLBUTTONDOWN, Direction, IntPtr.Zero)
                Me.DefWndProc(msg)
                '
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub me_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        Me.Cursor = Cursors.Arrow
    End Sub
    '
    Private Sub me_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        Me.Cursor = Cursors.Arrow
        RedesenhaBorder()
    End Sub
    '
    Private Sub me_MouseMove(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        '
        Dim posX, posY As Integer()
        '
        posX = {0, 1, 2, 3, Width - 1, Width - 2, Width - 3, Width - 4}
        posY = {Height - 1, Height - 2, Height - 3, Height - 4}
        '
        If posX.Contains(e.X) OrElse posY.Contains(e.Y) Then
            '
            Dim theCursor As Cursor = Cursors.Arrow
            '
            Select Case e.X
                Case 0 To 3 ' On the left line
                    Select Case e.Y
                        Case 0 To 3
                            ' top left corner
                            theCursor = Cursors.SizeNWSE

                        Case Me.Height - 4 To Me.Height - 1
                            ' bottom left corner
                            theCursor = Cursors.SizeNESW

                        Case Else
                            ' left side
                            theCursor = Cursors.SizeWE

                    End Select
                Case Me.Width - 4 To Me.Width - 1   ' On the right line
                    Select Case e.Y
                        Case 0 To 3
                            ' top right corner
                            theCursor = Cursors.SizeNESW
                        Case Me.Height - 4 To Me.Height - 1
                            ' bottom right corner
                            theCursor = Cursors.SizeNWSE
                        Case Else
                            ' right side
                            theCursor = Cursors.SizeWE
                    End Select
                Case Else
                    Select Case e.Y
                        Case 0 To 3
                            ' top line
                            theCursor = Cursors.SizeNS
                        Case Me.Height - 4 To Me.Height - 1
                            ' bottom line
                            theCursor = Cursors.SizeNS
                    End Select
            End Select
            '
            Me.Cursor = theCursor
            '
        Else
            If Me.Cursor IsNot Cursors.SizeAll Then
                Me.Cursor = Cursors.Arrow
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS"
    '
    Friend Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    '
    Private Sub btnMaximizar_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
            btnMaximizar.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.MinimizeButton
        Else
            WindowState = FormWindowState.Normal
            btnMaximizar.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.MaximizeButton
        End If
        RedesenhaBorder()
    End Sub
    '
#End Region
    '
End Class