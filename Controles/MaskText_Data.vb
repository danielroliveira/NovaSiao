Imports System.Windows.Forms
Public Class MaskText_Data
    Inherits MaskedTextBox
    Sub New()
        Me.Mask = "00/00/0000"
    End Sub

    Private Sub MaskText_Data_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.SelectAll()
    End Sub

    Private Sub MaskText_Data_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

End Class
