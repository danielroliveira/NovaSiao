Imports System.Windows.Forms
Public Class MaskText_Telefone
    Inherits MaskedTextBox
    Sub New()
        Me.Mask = "(99) 99000-0000"
        Me.Width = 144
        Me.Height = 27
    End Sub

    Private Sub MaskText_Telefone_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.SelectAll()
    End Sub

    Private Sub MaskText_Telefone_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class
