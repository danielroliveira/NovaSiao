Imports System.ComponentModel
Imports System.Windows.Forms
'
Public Class Text_Monetario
    Inherits TextBox
    Private _onlypositivo As Boolean = True
    '
    <Browsable(True)>
    Public Property SomentePositivos() As Boolean
        Get
            Return _onlypositivo
        End Get
        Set
            _onlypositivo = Value
        End Set
    End Property
    '
    Sub New()
        Me.TextAlign = LeftRightAlignment.Right
    End Sub

    Private Sub Text_Monetario_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.SelectAll()
    End Sub

    Private Sub Text_Monetario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ","c Then
            e.Handled = False
        ElseIf e.KeyChar = "."c Then
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

    Private Sub Text_Monetario_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        If Me.TextLength > 0 Then
            '
            If Not IsNumeric(Me.Text) Then
                '
                MessageBox.Show("Valor númerico incorreto..." &
                                vbNewLine & "Favor digitar um valor numérico",
                                "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Focus()
                '
            ElseIf SomentePositivos AndAlso CDbl(Me.Text) < 0 Then
                '
                MessageBox.Show("Valor númerico incorreto..." &
                                vbNewLine & "Favor inserir um valor maior ou igual a 0 (zero)",
                                "Valor Negativo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Focus()
                '
            Else
                '
                If Me.Text = String.Empty Then
                    Me.Text = 0
                End If
                Me.Text = FormatCurrency(Me.Text, 2, TriState.True, TriState.True, TriState.True)
                '
            End If
            '
        End If
    End Sub
    '
End Class
