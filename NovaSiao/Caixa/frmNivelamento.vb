Public Class frmNivelamento
    '
    Private _formOrigem As Form
    Private _ValorAtual As Decimal
    Property PropNivValor_Escolhido As Decimal
    '
#Region "NEW | CARREGA COMBO"
    '-------------------------------------------------------------------------------------------------
    ' SUB NEW
    '-------------------------------------------------------------------------------------------------
    Sub New(ValorAtual As Double, Conta As String, Meio As String)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        lblConta.Text = Conta
        lblMeio.Text = Meio
        _ValorAtual = ValorAtual
        txtValor.Text = Format(ValorAtual, "C")
        '
        txtValor.SomentePositivos = False
        '
    End Sub
    '
#End Region
    '
#Region "FUNCOES UTILITARIAS"
    '
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' USAR TAB AO KEYPRESS ENTER
    '------------------------------------------------------------------------------------------
    Private Sub txtValor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '------------------------------------------------------------------------------------------
    ' ACAO DOS BOTOES
    '------------------------------------------------------------------------------------------
    Private Sub btnNivelar_Click(sender As Object, e As EventArgs) Handles btnNivelar.Click
        '
        If IsNothing(txtValor.Text) OrElse txtValor.Text = _ValorAtual Then
            MessageBox.Show("O VALOR REAL para Nivelamento não pode ser menor que Zero..." & vbNewLine &
                            "bem como, não pode ser igual ao Valor Atual do Saldo do Meio de Movimentação" & vbNewLine &
                            "Favor definir outro valor para esse campo.", "Valor Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtValor.Focus()
            txtValor.SelectAll()
            Exit Sub
        End If
        '
        PropNivValor_Escolhido = txtValor.Text - _ValorAtual
        '
        DialogResult = DialogResult.OK
        Close()
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS FORM SEM BORDA"
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.SlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub Me_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.Silver
            End If
        Next
    End Sub
    '
    Private Sub Me_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.SlateGray
            End If
        Next
    End Sub
    '
#End Region
    '
End Class
