Imports System.Windows.Forms
Public Class ComboBox_OnlyValues
    Inherits ComboBox
    Public Property RestrictContentToListItems As Boolean = True
    Sub New()
        Me.Width = 234
        Me.Height = 27
        With Me
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End With
    End Sub

    Private Sub ComboBox_OnlyValues_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.SelectAll()
    End Sub

    Private Sub ComboBox_OnlyValues_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Escape Then
            SendKeys.Send("{Tab}")
            SendKeys.Send("{Esc}")
        End If
        '
    End Sub
    '
    Protected Overrides Sub OnValidating(e As System.ComponentModel.CancelEventArgs)
        If Me.Text.Length = 0 Then Exit Sub

        If RestrictContentToListItems AndAlso Me.Items.Count > 0 Then
            Dim index As Integer = Me.FindString(Me.Text)
            If index > -1 Then
                Me.SelectedIndex = index
            Else
                e.Cancel = True
                Me.Text = ""
                Beep()
                SendKeys.Send("%{DOWN}")
            End If
        End If
        MyBase.OnValidating(e)
    End Sub
    '
End Class
