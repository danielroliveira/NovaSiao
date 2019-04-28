<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBackup
    Inherits NovaSiao.frmModFinBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnRestaurar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.txtDirCaminho = New System.Windows.Forms.TextBox()
        Me.chkInserirData = New System.Windows.Forms.CheckBox()
        Me.chkInserirHora = New System.Windows.Forms.CheckBox()
        Me.btnDirEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.lblArquivoNome = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblUltBackup = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(788, 50)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(615, 6)
        Me.lblTitulo.Size = New System.Drawing.Size(137, 40)
        Me.lblTitulo.Text = "Backup BD"
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(290, 286)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(134, 45)
        Me.btnBackup.TabIndex = 2
        Me.btnBackup.Text = "&Backup"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'btnRestaurar
        '
        Me.btnRestaurar.Location = New System.Drawing.Point(430, 286)
        Me.btnRestaurar.Name = "btnRestaurar"
        Me.btnRestaurar.Size = New System.Drawing.Size(134, 45)
        Me.btnRestaurar.TabIndex = 3
        Me.btnRestaurar.Text = "&Restaurar"
        Me.btnRestaurar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Location = New System.Drawing.Point(637, 286)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(134, 45)
        Me.btnFechar.TabIndex = 4
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'txtDirCaminho
        '
        Me.txtDirCaminho.Location = New System.Drawing.Point(23, 26)
        Me.txtDirCaminho.Name = "txtDirCaminho"
        Me.txtDirCaminho.Size = New System.Drawing.Size(393, 27)
        Me.txtDirCaminho.TabIndex = 5
        '
        'chkInserirData
        '
        Me.chkInserirData.AutoSize = True
        Me.chkInserirData.Checked = True
        Me.chkInserirData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInserirData.Location = New System.Drawing.Point(25, 28)
        Me.chkInserirData.Name = "chkInserirData"
        Me.chkInserirData.Size = New System.Drawing.Size(104, 23)
        Me.chkInserirData.TabIndex = 6
        Me.chkInserirData.Text = "Inserir Data"
        Me.chkInserirData.UseVisualStyleBackColor = True
        '
        'chkInserirHora
        '
        Me.chkInserirHora.AutoSize = True
        Me.chkInserirHora.Checked = True
        Me.chkInserirHora.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInserirHora.Location = New System.Drawing.Point(168, 28)
        Me.chkInserirHora.Name = "chkInserirHora"
        Me.chkInserirHora.Size = New System.Drawing.Size(104, 23)
        Me.chkInserirHora.TabIndex = 6
        Me.chkInserirHora.Text = "Inserir Hora"
        Me.chkInserirHora.UseVisualStyleBackColor = True
        '
        'btnDirEscolher
        '
        Me.btnDirEscolher.AllowAnimations = True
        Me.btnDirEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnDirEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnDirEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDirEscolher.Location = New System.Drawing.Point(422, 26)
        Me.btnDirEscolher.Name = "btnDirEscolher"
        Me.btnDirEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnDirEscolher.RoundedCornersRadius = 0
        Me.btnDirEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnDirEscolher.TabIndex = 11
        Me.btnDirEscolher.Text = "..."
        Me.btnDirEscolher.UseCompatibleTextRendering = True
        Me.btnDirEscolher.UseVisualStyleBackColor = False
        Me.btnDirEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblArquivoNome
        '
        Me.lblArquivoNome.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArquivoNome.Location = New System.Drawing.Point(21, 58)
        Me.lblArquivoNome.Name = "lblArquivoNome"
        Me.lblArquivoNome.Size = New System.Drawing.Size(289, 24)
        Me.lblArquivoNome.TabIndex = 0
        Me.lblArquivoNome.Text = "Nome do Arquivo Indefinido"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUltBackup)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblArquivoNome)
        Me.GroupBox1.Controls.Add(Me.chkInserirHora)
        Me.GroupBox1.Controls.Add(Me.chkInserirData)
        Me.GroupBox1.Location = New System.Drawing.Point(288, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(483, 93)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nome do Arquivo de Backup"
        '
        'lblUltBackup
        '
        Me.lblUltBackup.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltBackup.Location = New System.Drawing.Point(364, 50)
        Me.lblUltBackup.Name = "lblUltBackup"
        Me.lblUltBackup.Size = New System.Drawing.Size(107, 24)
        Me.lblUltBackup.TabIndex = 7
        Me.lblUltBackup.Text = "00/00/0000"
        Me.lblUltBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(364, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Último Backup:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDirCaminho)
        Me.GroupBox2.Controls.Add(Me.btnDirEscolher)
        Me.GroupBox2.Location = New System.Drawing.Point(288, 175)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(483, 72)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pasta do Arquivo de Backup"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.NovaSiao.My.Resources.Resources.dbbackup_icon
        Me.PictureBox1.Location = New System.Drawing.Point(12, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(267, 269)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.CausesValidation = False
        Me.btnClose.Location = New System.Drawing.Point(757, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 9
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(788, 346)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnBackup)
        Me.Controls.Add(Me.btnRestaurar)
        Me.Name = "frmBackup"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnRestaurar, 0)
        Me.Controls.SetChildIndex(Me.btnBackup, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBackup As Button
    Friend WithEvents btnRestaurar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents txtDirCaminho As TextBox
    Friend WithEvents chkInserirData As CheckBox
    Friend WithEvents chkInserirHora As CheckBox
    Friend WithEvents btnDirEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents lblArquivoNome As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblUltBackup As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Protected Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
End Class
