'
Public Class frmCredorTipo
    '
    Private _formOrigem As Form = Nothing
    Public Property CredorTipo() As Byte
    '
#Region "SUB NEW | LOAD"
    '
    Sub New(formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem '---> form will be changed color of panel1
        '
        AddHandler rbtSimples.CheckedChanged, AddressOf Radio_CheckedChanged
        AddHandler rbtPF.CheckedChanged, AddressOf Radio_CheckedChanged
        AddHandler rbtPJ.CheckedChanged, AddressOf Radio_CheckedChanged
        AddHandler rbtOrgaoPublico.CheckedChanged, AddressOf Radio_CheckedChanged
        '
    End Sub
    '
    '--- CHANGE CREDOR TIPO RADIO
    '----------------------------------------------------------------------------------
    Private Sub Radio_CheckedChanged(sender As Object, e As EventArgs)
        '
        Dim newTipo As Byte = DirectCast(sender, Control).Tag
        '
        If CredorTipo <> newTipo Then
            CredorTipo = newTipo
        End If
        '
    End Sub
    '
#End Region '/ SUB NEW | LOAD
    '
#Region "NAVEGACAO E FORMATACAO"
    '
    '-------------------------------------------------------------------------------------------------
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- ATALHOS PARA ESCOLHER APENAS COM OS NUMEROS
    '-------------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnCancelar_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
            e.Handled = True
            e.SuppressKeyPress = True
            rbtSimples.Checked = True
        ElseIf e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
            e.Handled = True
            e.SuppressKeyPress = True
            rbtPF.Checked = True
        ElseIf e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3 Then
            e.Handled = True
            e.SuppressKeyPress = True
            rbtPJ.Checked = True
        ElseIf e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4 Then
            e.Handled = True
            e.SuppressKeyPress = True
            rbtOrgaoPublico.Checked = True
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    '------------------------------------------------------------------------------------------
    Private Sub Control_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles rbtSimples.KeyDown,
        rbtPF.KeyDown, rbtPJ.KeyDown, rbtOrgaoPublico.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region '/ NAVEGACAO E FORMATACAO
    '
#Region "FUNCOES INSERIR | BUTTONS"
    '
    '--- BUTTON OK
    '----------------------------------------------------------------------------------
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '--- FECHAR FORMULÁRIO
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    '--- BUTTON CANCELAR
    '----------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        '
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = True
        End If
        '
        If Application.OpenForms.Count() = 1 Then
            MostraMenuPrincipal()
        End If
        '
    End Sub
    '
#End Region '/ FUNCOES INSERIR | BUTTONS
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