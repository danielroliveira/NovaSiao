<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModFinBorderSizeable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnMaximizar = New VIBlend.WinForms.Controls.vFormButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.btnMaximizar)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 50)
        Me.Panel1.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.CausesValidation = False
        Me.btnClose.Location = New System.Drawing.Point(764, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 8
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(611, 0)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.lblTitulo.Size = New System.Drawing.Size(122, 50)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Label1"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnMaximizar
        '
        Me.btnMaximizar.AllowAnimations = True
        Me.btnMaximizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximizar.BackColor = System.Drawing.Color.Transparent
        Me.btnMaximizar.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
        Me.btnMaximizar.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.MaximizeButton
        Me.btnMaximizar.CausesValidation = False
        Me.btnMaximizar.Location = New System.Drawing.Point(740, 12)
        Me.btnMaximizar.Name = "btnMaximizar"
        Me.btnMaximizar.RibbonStyle = False
        Me.btnMaximizar.RoundedCornersMask = CType(15, Byte)
        Me.btnMaximizar.ShowFocusRectangle = False
        Me.btnMaximizar.Size = New System.Drawing.Size(20, 20)
        Me.btnMaximizar.TabIndex = 9
        Me.btnMaximizar.TabStop = False
        Me.btnMaximizar.UseVisualStyleBackColor = False
        Me.btnMaximizar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'frmModFinBorderSizeable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmModFinBorderSizeable"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Protected WithEvents Panel1 As Panel
    Protected WithEvents lblTitulo As Label
    Protected Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Protected Friend WithEvents btnMaximizar As VIBlend.WinForms.Controls.vFormButton
End Class
