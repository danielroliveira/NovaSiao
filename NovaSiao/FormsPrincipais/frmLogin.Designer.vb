<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.txtApelido = New System.Windows.Forms.TextBox()
        Me.lblSenha = New System.Windows.Forms.Label()
        Me.lblApelido = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.Panel1.Controls.Add(Me.txtSenha)
        Me.Panel1.Controls.Add(Me.txtApelido)
        Me.Panel1.Controls.Add(Me.lblSenha)
        Me.Panel1.Controls.Add(Me.lblApelido)
        Me.Panel1.Location = New System.Drawing.Point(0, 280)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(569, 65)
        Me.Panel1.TabIndex = 3
        '
        'txtSenha
        '
        Me.txtSenha.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSenha.Location = New System.Drawing.Point(319, 32)
        Me.txtSenha.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSenha.MaxLength = 8
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(118, 23)
        Me.txtSenha.TabIndex = 3
        Me.txtSenha.Text = "dro12345"
        '
        'txtApelido
        '
        Me.txtApelido.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApelido.Location = New System.Drawing.Point(133, 32)
        Me.txtApelido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApelido.Name = "txtApelido"
        Me.txtApelido.Size = New System.Drawing.Size(156, 23)
        Me.txtApelido.TabIndex = 1
        Me.txtApelido.Text = "Daniel"
        '
        'lblSenha
        '
        Me.lblSenha.Location = New System.Drawing.Point(316, 10)
        Me.lblSenha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(69, 22)
        Me.lblSenha.TabIndex = 2
        Me.lblSenha.Text = "&Senha"
        Me.lblSenha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApelido
        '
        Me.lblApelido.Location = New System.Drawing.Point(130, 10)
        Me.lblApelido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblApelido.Name = "lblApelido"
        Me.lblApelido.Size = New System.Drawing.Size(146, 22)
        Me.lblApelido.TabIndex = 0
        Me.lblApelido.Text = "&Nome do Usuário"
        Me.lblApelido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.AliceBlue
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(176, 364)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(99, 42)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(287, 364)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 42)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(569, 57)
        Me.Panel2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(107, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(355, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Faça o Login no Sistema"
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picLogo.Location = New System.Drawing.Point(12, 72)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(545, 191)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 7
        Me.picLogo.TabStop = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Faça o Login no Sistema"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSenha As TextBox
    Friend WithEvents txtApelido As TextBox
    Friend WithEvents lblSenha As Label
    Friend WithEvents lblApelido As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents picLogo As PictureBox
End Class
