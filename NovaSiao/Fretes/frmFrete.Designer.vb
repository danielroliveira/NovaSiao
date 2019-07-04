<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFrete
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
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.btnTransportadora = New VIBlend.WinForms.Controls.vButton()
        Me.txtTransportadora = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpConhecimentoData = New System.Windows.Forms.DateTimePicker()
        Me.txtFreteValor = New Controles.Text_Monetario()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConhecimento = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(574, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(429, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(145, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Editar Frete"
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblID.Location = New System.Drawing.Point(8, 17)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(94, 30)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "0001"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_IdTexto
        '
        Me.lbl_IdTexto.AutoSize = True
        Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver
        Me.lbl_IdTexto.Location = New System.Drawing.Point(32, 4)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 1
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tsMenu
        '
        Me.tsMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.AntiqueWhite
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalvar, Me.btnCancelar, Me.btnFechar})
        Me.tsMenu.Location = New System.Drawing.Point(4, 225)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMenu.Size = New System.Drawing.Size(568, 48)
        Me.tsMenu.TabIndex = 10
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(82, 45)
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.ToolTipText = "Salvar Alterações"
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.delete_page
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 45)
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar Edição"
        '
        'btnFechar
        '
        Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(86, 45)
        Me.btnFechar.Text = "&Fechar"
        '
        'btnTransportadora
        '
        Me.btnTransportadora.AllowAnimations = True
        Me.btnTransportadora.BackColor = System.Drawing.Color.Transparent
        Me.btnTransportadora.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTransportadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransportadora.Location = New System.Drawing.Point(511, 72)
        Me.btnTransportadora.Name = "btnTransportadora"
        Me.btnTransportadora.RoundedCornersMask = CType(15, Byte)
        Me.btnTransportadora.RoundedCornersRadius = 0
        Me.btnTransportadora.Size = New System.Drawing.Size(34, 27)
        Me.btnTransportadora.TabIndex = 3
        Me.btnTransportadora.TabStop = False
        Me.btnTransportadora.Text = "..."
        Me.btnTransportadora.UseCompatibleTextRendering = True
        Me.btnTransportadora.UseVisualStyleBackColor = False
        Me.btnTransportadora.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtTransportadora
        '
        Me.txtTransportadora.Location = New System.Drawing.Point(151, 72)
        Me.txtTransportadora.MaxLength = 50
        Me.txtTransportadora.Name = "txtTransportadora"
        Me.txtTransportadora.Size = New System.Drawing.Size(355, 27)
        Me.txtTransportadora.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(38, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 19)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Transportadora"
        '
        'dtpConhecimentoData
        '
        Me.dtpConhecimentoData.Checked = False
        Me.dtpConhecimentoData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpConhecimentoData.Location = New System.Drawing.Point(151, 138)
        Me.dtpConhecimentoData.Name = "dtpConhecimentoData"
        Me.dtpConhecimentoData.ShowCheckBox = True
        Me.dtpConhecimentoData.Size = New System.Drawing.Size(178, 27)
        Me.dtpConhecimentoData.TabIndex = 7
        Me.dtpConhecimentoData.Value = New Date(2019, 7, 3, 0, 0, 0, 0)
        '
        'txtFreteValor
        '
        Me.txtFreteValor.Location = New System.Drawing.Point(151, 171)
        Me.txtFreteValor.Name = "txtFreteValor"
        Me.txtFreteValor.Size = New System.Drawing.Size(123, 27)
        Me.txtFreteValor.SomentePositivos = True
        Me.txtFreteValor.TabIndex = 9
        Me.txtFreteValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "No. Conhecimento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Dt. Conhecimento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(46, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Valor do Frete"
        '
        'txtConhecimento
        '
        Me.txtConhecimento.Location = New System.Drawing.Point(151, 105)
        Me.txtConhecimento.MaxLength = 20
        Me.txtConhecimento.Name = "txtConhecimento"
        Me.txtConhecimento.Size = New System.Drawing.Size(178, 27)
        Me.txtConhecimento.TabIndex = 5
        '
        'frmFrete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(574, 275)
        Me.Controls.Add(Me.txtConhecimento)
        Me.Controls.Add(Me.txtFreteValor)
        Me.Controls.Add(Me.dtpConhecimentoData)
        Me.Controls.Add(Me.btnTransportadora)
        Me.Controls.Add(Me.txtTransportadora)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tsMenu)
        Me.KeyPreview = True
        Me.Name = "frmFrete"
        Me.Controls.SetChildIndex(Me.tsMenu, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtTransportadora, 0)
        Me.Controls.SetChildIndex(Me.btnTransportadora, 0)
        Me.Controls.SetChildIndex(Me.dtpConhecimentoData, 0)
        Me.Controls.SetChildIndex(Me.txtFreteValor, 0)
        Me.Controls.SetChildIndex(Me.txtConhecimento, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblID As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents btnFechar As ToolStripButton
    Friend WithEvents btnTransportadora As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtTransportadora As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpConhecimentoData As DateTimePicker
    Friend WithEvents txtFreteValor As Controles.Text_Monetario
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtConhecimento As TextBox
End Class
