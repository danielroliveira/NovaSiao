Public Class frmProdutoValorDesconto
    '
    Property propDesconto As Decimal
    Property propValor As Decimal
    Private _formOrigem As Form
    '
    Sub New(vlPadrao As Decimal, descontoPadrao As Decimal, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propValor = vlPadrao
        propDesconto = descontoPadrao
        txtValorPadrao.Text = Format(vlPadrao, "C")
        _formOrigem = formOrigem
        '
    End Sub
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '--- calcula e verifica o desconto
        If VerificaDesconto() = True Then
            '
            DialogResult = DialogResult.OK
            '
        End If
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
    Private Function VerificaDesconto() As Boolean
        '
        '--- verifica se existe valor no txtValor
        If Not IsNumeric(txtValorPadrao.Text) OrElse CDec(txtValorPadrao.Text) = 0 Then
            MessageBox.Show("Não foi inserido nenhum valor no campo...", "Entrar Valor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtValorPadrao.Focus()
            Return False
        End If
        '
        Dim vlInserido = Math.Abs(CDec(txtValorPadrao.Text))
        '
        '--- verifica se o valor inserido é igual, maior ou menor que o vlPadrao (valor inicial)
        If vlInserido = propValor Then '-- não pode ser igual
            MessageBox.Show("O valor inserido é igual ao valor anterior...", "Valor Igual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtValorPadrao.Focus()
            Return False
        ElseIf vlInserido < propValor Then
            '--- calcula o desconto
            propDesconto = Math.Round(100 * (propValor - vlInserido) / propValor, 4)
            Return True
        ElseIf vlInserido > propValor Then
            '--- retorna o novo preço aumentado
            propValor = vlInserido
            propDesconto = 0
            Return True
        End If
        '
    End Function
    '
    Private Sub ControlKeyDown(sender As Object, e As KeyEventArgs) Handles txtValorPadrao.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    Private Sub me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.SuppressKeyPress = True
            e.Handled = True
            btnCancelar_Click(Me, New EventArgs)
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '
        If _formOrigem Is Nothing Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub form_closed(sender As Object, e As EventArgs) Handles Me.Closed
        '
        If _formOrigem Is Nothing Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
End Class
