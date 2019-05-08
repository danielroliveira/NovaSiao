Public Class frmUserAuthorization
    '
    Dim _formOrigem As Form = Nothing
    Property propUser As String
    Property propSenha As String
    '
    Sub New(AuthDescription As String, Optional formOrigem As Form = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        lblMessage.Text = AuthDescription

    End Sub
    '
    '==========================================================================================
    ' BUTTONS FUNCTION
    '==========================================================================================
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        If Not VerificaControles() Then Exit Sub
        '
        propUser = txtApelido.Text
        propSenha = txtSenha.Text
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        propUser = String.Empty
        propSenha = String.Empty
        DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Function VerificaControles() As Boolean
        '
        If txtApelido.Text.Trim.Length = 0 Then
            AbrirDialog("O campo Nome do Usuário precisa estar preenchido...",
                        "Nome do Usuário",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            txtApelido.Focus()
            Return False
        End If
        '
        If txtSenha.Text.Trim.Length = 0 Then
            AbrirDialog("O campo Senha precisa estar preenchido...",
                        "Senha do Usuário",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            txtApelido.Focus()
            Return False
        End If
        '
        If txtSenha.Text.Trim.Length < 8 Then
            AbrirDialog("O campo Senha precisa ter 8 caracteres",
                        "Senha do Usuário",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            txtApelido.Focus()
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    '==========================================================================================
    ' CONTROLE DOS CAMPOS
    '==========================================================================================
    Private Sub txtApelido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApelido.KeyDown, txtSenha.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '
        If IsNothing(_formOrigem) Then Return
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
        '
    End Sub
    '
    Private Sub form_closed(sender As Object, e As EventArgs) Handles Me.Closed
        '
        If IsNothing(_formOrigem) Then Return
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
        '
    End Sub
    '
End Class
