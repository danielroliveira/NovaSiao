Public Class frmDialog
    '
    Private _dialogType As DialogType
    Private _icon As DialogIcon
    '
    Public Enum DialogType
        SIM_NAO
        OK
        OK_CANCELAR
        SIM_NAO_CANCELAR
    End Enum
    '
    Public Enum DialogIcon
        Question
        Information
        Exclamation
        Warning
    End Enum
    '
    Sub New(mensagem As String, titulo As String, dialogType As DialogType, Icon As MessageBoxIcon)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTitulo.Text = titulo
        lblMensagem.Text = mensagem
        '
        propIcon = Icon
        propDialogType = dialogType
        '
    End Sub
    '
    Public Property propDialogType() As DialogType
        '
        Get
            Return _dialogType
        End Get
        '
        Set(ByVal value As DialogType)
            _dialogType = value
            '
            Select Case _dialogType
                '
                Case DialogType.SIM_NAO
                    btnCancel.Visible = False
                    btnSim.Text = "Sim"
                    btnSim.DialogResult = DialogResult.Yes
                    btnNao.Text = "Não"
                    btnNao.DialogResult = DialogResult.No

                Case DialogType.OK
                    btnCancel.Visible = False
                    btnNao.Visible = False
                    btnSim.Text = "OK"
                    btnSim.DialogResult = DialogResult.OK

                Case DialogType.SIM_NAO_CANCELAR
                    btnCancel.Visible = True
                    btnSim.Text = "Sim"
                    btnSim.DialogResult = DialogResult.Yes
                    btnNao.Text = "Não"
                    btnNao.DialogResult = DialogResult.No
                    btnCancel.Text = "Cancelar"
                    btnCancel.DialogResult = DialogResult.Cancel

                Case DialogType.OK_CANCELAR
                    btnCancel.Visible = False
                    btnSim.Text = "OK"
                    btnSim.DialogResult = DialogResult.OK
                    btnNao.Text = "Cancelar"
                    btnNao.DialogResult = DialogResult.Cancel

            End Select
            '
        End Set
        '
    End Property
    '
    Public Property propIcon() As DialogIcon
        Get
            Return _icon
        End Get
        Set(ByVal value As DialogIcon)
            _icon = value
            '
            Select Case _icon
                Case DialogIcon.Question
                    picLogo.Image = My.Resources.icon_question
                    Panel1.BackColor = Color.FromArgb(0, 56, 140)
                Case DialogIcon.Information
                    picLogo.Image = My.Resources.icon_information
                    Panel1.BackColor = Color.FromArgb(23, 128, 34)
                Case DialogIcon.Exclamation
                    picLogo.Image = My.Resources.icon_exclamation
                    Panel1.BackColor = Color.FromArgb(245, 121, 0)
                Case DialogIcon.Warning
                    picLogo.Image = My.Resources.icon_warning
                    Panel1.BackColor = Color.FromArgb(164, 21, 21)
                Case Else
                    picLogo.Image = My.Resources.delete_24px
                    Panel1.BackColor = Color.SlateGray
            End Select
            '
        End Set
    End Property
    '
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click, btnNao.Click, btnSim.Click
        Me.Close()
    End Sub
    '
End Class
