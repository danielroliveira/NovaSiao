Public Class frmProdutoAlterarEstMinimoIdeal
    '
    'Private _EstoqueMinimo As Integer? = Nothing
    'Private _EstoqueIdeal As Integer? = Nothing
    Private _formOrigem As Form = Nothing
    '
    Public Property propEstoqueMinimo As Integer? = Nothing
    Public Property propEstoqueIdeal As Integer? = Nothing
    '
#Region "NEW | LOAD"
    Sub New(formOrigem As Form)

        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        CampoNecessario(txtEstoqueMinimo, False)
        CampoNecessario(txtEstoqueIdeal, False)
        '
    End Sub
#End Region '// NEW | LOAD

#Region "OUTRAS FUNCOES"
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If Char.IsNumber(e.KeyChar) OrElse e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles _
        txtEstoqueMinimo.KeyDown,
        txtEstoqueIdeal.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- QUANDO ALTERA O TEXTO DOS CONTROLES
    Private Sub txtEstoqueMinimo_TextChanged(sender As Object, e As EventArgs) _
        Handles txtEstoqueMinimo.TextChanged, txtEstoqueIdeal.TextChanged
        '
        Dim txt As TextBox = DirectCast(sender, TextBox)
        '
        If txt.Text.Trim.Length > 0 Then
            CampoNecessario(txt, True)
        Else
            CampoNecessario(txt, False)
        End If
        '
    End Sub
    '
#End Region '// OUTRAS FUNCOES
    '
#Region "BUTTONS"
    '
    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        '
        If String.IsNullOrEmpty(txtEstoqueIdeal.Text) Then
            propEstoqueIdeal = Nothing
        Else
            propEstoqueIdeal = CInt(txtEstoqueIdeal.Text)
        End If
        '
        If String.IsNullOrEmpty(txtEstoqueMinimo.Text) Then
            propEstoqueMinimo = Nothing
        Else
            propEstoqueMinimo = CInt(txtEstoqueMinimo.Text)
        End If
        '
        ' verifica se o minimo é maior que o ideal
        If Not IsNothing(propEstoqueIdeal) AndAlso Not IsNothing(propEstoqueMinimo) Then
            '
            If propEstoqueMinimo.GetValueOrDefault > propEstoqueIdeal.GetValueOrDefault Then
                MessageBox.Show("Não é possível que o Estoque Mínimo seja MAIOR que o Estoque Ideal..." & vbNewLine & vbNewLine &
                                "Favor ajustar o valor do Estoque Mínimo ou do Ideal.",
                                "Estoque",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                txtEstoqueMinimo.Focus()
                Return
            End If
            '
        End If
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
#End Region '// BUTTONS
    '
#Region "TRATAMENTO VISUAL"
    '
    Private Sub CampoNecessario(txt As TextBox, preenchido As Boolean)
        '
        If txt.Name = "txtEstoqueMinimo" Then
            lblA.Visible = Not preenchido
        ElseIf txt.Name = "txtEstoqueIdeal" Then
            lblB.Visible = Not preenchido
        End If
        '
        If txtEstoqueIdeal.Text.Trim.Length = 0 AndAlso txtEstoqueMinimo.Text.Trim.Length = 0 Then
            btnAlterar.Enabled = False
        Else
            btnAlterar.Enabled = True
        End If
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class
