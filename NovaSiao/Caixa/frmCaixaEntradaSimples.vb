Public Class frmCaixaEntradaSimples
    '
    Private _formOrigem As Form
    Private _ValorAtual As Decimal
    Property PropValor_Escolhido As Decimal
    Property PropDescricao As String
    '
#Region "NEW "
    '-------------------------------------------------------------------------------------------------
    ' SUB NEW
    '-------------------------------------------------------------------------------------------------
    Sub New(Conta As String)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        lblConta.Text = Conta
        _ValorAtual = 0
        txtValor.Text = Format(0, "C")
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
    Private Sub txtValor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValor.KeyDown, txtDescricao.KeyDown
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
    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        '
        '--- VALIDATING
        '----------------------------------------------------------------------------------
        If IsNothing(txtValor.Text) OrElse txtValor.Text <= 0 Then
            AbrirDialog("O VALOR DA ENTRADA não pode ser menor ou igual a Zero..." & vbNewLine &
                        "Favor redefinir o valor desse campo.", "Valor Inválido",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            txtValor.Focus()
            txtValor.SelectAll()
            Exit Sub
        End If
        '
        If String.IsNullOrEmpty(txtDescricao.Text) Then
            AbrirDialog("A Descrição da Entrada precisa ser informada..." & vbNewLine &
                        "Favor informe a origem da Entrada na Descrição.",
                        "Descrição Vazia",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            txtDescricao.Focus()
            Exit Sub
        End If
        '
        If txtDescricao.Text.Trim.Length < 5 OrElse txtDescricao.Text.Length > 100 Then
            AbrirDialog("A Descrição da Entrada precisa ter entre 5 e 100 caracteres..." & vbNewLine &
                        "Favor informe corretamente a origem da Entrada na Descrição.",
                        "Descrição Incorreta",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            txtDescricao.Focus()
            Exit Sub
        End If
        '
        '--- RETURN | CLOSE
        '----------------------------------------------------------------------------------
        PropValor_Escolhido = txtValor.Text
        PropDescricao = txtDescricao.Text
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
