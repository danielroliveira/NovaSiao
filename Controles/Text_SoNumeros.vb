Imports System.ComponentModel
Imports System.Windows.Forms
'
Public Class Text_SoNumeros
    Inherits TextBox
    Private _inteiro As Boolean = True
    '
    <Browsable(True)>
    Public Property Inteiro() As Boolean
        Get
            Return _inteiro
        End Get
        Set
            _inteiro = Value
        End Set
    End Property
    '
    Sub New()
        Me.TextAlign = LeftRightAlignment.Right
    End Sub
    '
    Private Sub Text_SoNumeros_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If Me.Text.Length > 0 Then Me.SelectAll()
        AddHandler Me.Validating, AddressOf Text_SoNumeros_Validating
    End Sub
    '
    Private Sub Text_SoNumeros_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        RemoveHandler Me.Validating, AddressOf Text_SoNumeros_Validating
    End Sub
    '
    Private Sub Text_SoNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ","c AndAlso Inteiro = False Then
            e.Handled = False
        ElseIf e.KeyChar = "."c AndAlso Inteiro = False Then
            SelectedText = ","
            e.Handled = True
        ElseIf Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    '
    Private Sub Text_SoNumeros_Validating(sender As Object, e As CancelEventArgs)
        Dim v As Integer
        '
        If Me.TextLength > 0 Then
            If IsNumeric(Me.Text) = False Then
                MessageBox.Show("Valor númerico incorreto..." &
                                vbNewLine & "Digite um valor numérico",
                                "Valor Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            ElseIf _inteiro = True And Integer.TryParse(Me.Text, v) = False Then
                MessageBox.Show("Valor númerico incorreto..." & vbNewLine &
                                "Digite um INTEIRO", "Valor Incorreto",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            Else
                e.Cancel = False
                Exit Sub
            End If
        Else
            e.Cancel = False
            Exit Sub
        End If
    End Sub
    '
End Class
