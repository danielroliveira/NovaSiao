<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog
    Inherits NovaSiao.frmModFinBorder

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
        Me.btnSim = New System.Windows.Forms.Button()
        Me.btnNao = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblMensagem = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(543, 30)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.lblTitulo.Padding = New System.Windows.Forms.Padding(10, 0, 0, 6)
        Me.lblTitulo.Size = New System.Drawing.Size(552, 30)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Titulo"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnSim
        '
        Me.btnSim.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSim.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnSim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSim.Location = New System.Drawing.Point(284, 244)
        Me.btnSim.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnSim.Name = "btnSim"
        Me.btnSim.Size = New System.Drawing.Size(118, 42)
        Me.btnSim.TabIndex = 1
        Me.btnSim.Text = "Sim"
        '
        'btnNao
        '
        Me.btnNao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNao.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick
        Me.btnNao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose
        Me.btnNao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNao.Location = New System.Drawing.Point(412, 244)
        Me.btnNao.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnNao.Name = "btnNao"
        Me.btnNao.Size = New System.Drawing.Size(118, 42)
        Me.btnNao.TabIndex = 2
        Me.btnNao.Text = "Não"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(156, 244)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 42)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancelar"
        '
        'lblMensagem
        '
        Me.lblMensagem.BackColor = System.Drawing.Color.Transparent
        Me.lblMensagem.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensagem.Location = New System.Drawing.Point(152, 45)
        Me.lblMensagem.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMensagem.Name = "lblMensagem"
        Me.lblMensagem.Size = New System.Drawing.Size(378, 186)
        Me.lblMensagem.TabIndex = 1
        Me.lblMensagem.Text = "Mensagem"
        Me.lblMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picLogo
        '
        Me.picLogo.Image = Global.NovaSiao.My.Resources.Resources.icon_warning
        Me.picLogo.InitialImage = Nothing
        Me.picLogo.Location = New System.Drawing.Point(15, 71)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(0)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(120, 130)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picLogo.TabIndex = 3
        Me.picLogo.TabStop = False
        '
        'frmDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(543, 299)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.lblMensagem)
        Me.Controls.Add(Me.btnNao)
        Me.Controls.Add(Me.btnSim)
        Me.Controls.Add(Me.btnCancel)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "frmDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmDialog"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnSim, 0)
        Me.Controls.SetChildIndex(Me.btnNao, 0)
        Me.Controls.SetChildIndex(Me.lblMensagem, 0)
        Me.Controls.SetChildIndex(Me.picLogo, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblMensagem As Label
    Friend WithEvents btnNao As Button
    Friend WithEvents btnSim As Button
    Friend WithEvents picLogo As PictureBox
End Class
