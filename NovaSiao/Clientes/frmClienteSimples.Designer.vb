<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClienteSimples
	Inherits NovaSiao.frmModNBorder

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
		Me.components = New System.ComponentModel.Container()
		Me.txtTelefoneB = New Controles.MaskText_Telefone()
		Me.txtTelefoneA = New Controles.MaskText_Telefone()
		Me.txtCidade = New System.Windows.Forms.TextBox()
		Me.txtUF = New System.Windows.Forms.TextBox()
		Me.txtEndereco = New System.Windows.Forms.TextBox()
		Me.txtBairro = New System.Windows.Forms.TextBox()
		Me.lbl2 = New System.Windows.Forms.Label()
		Me.lbl1 = New System.Windows.Forms.Label()
		Me.txtCEP = New System.Windows.Forms.MaskedTextBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.lbl5 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.lbl4 = New System.Windows.Forms.Label()
		Me.lbl3 = New System.Windows.Forms.Label()
		Me.txtClienteNome = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.tsMenu = New System.Windows.Forms.ToolStrip()
		Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnNovo = New System.Windows.Forms.ToolStripButton()
		Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
		Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
		Me.btnFechar = New System.Windows.Forms.ToolStripButton()
		Me.lblID = New System.Windows.Forms.Label()
		Me.lbl_IdTexto = New System.Windows.Forms.Label()
		Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.txtClienteEmail = New System.Windows.Forms.TextBox()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.chkTemWhatsapp = New System.Windows.Forms.CheckBox()
		Me.picWathsapp = New System.Windows.Forms.PictureBox()
		Me.chkEndereco = New System.Windows.Forms.CheckBox()
		Me.pnlChk = New System.Windows.Forms.Panel()
		Me.Panel1.SuspendLayout()
		Me.tsMenu.SuspendLayout()
		CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picWathsapp, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlChk.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.lblID)
		Me.Panel1.Controls.Add(Me.lbl_IdTexto)
		Me.Panel1.Size = New System.Drawing.Size(597, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(408, 0)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(189, 50)
		Me.lblTitulo.TabIndex = 2
		Me.lblTitulo.Text = "Clientes Simples"
		'
		'txtTelefoneB
		'
		Me.txtTelefoneB.Location = New System.Drawing.Point(166, 120)
		Me.txtTelefoneB.Mask = "(99) 99000-0000"
		Me.txtTelefoneB.Name = "txtTelefoneB"
		Me.txtTelefoneB.Size = New System.Drawing.Size(144, 27)
		Me.txtTelefoneB.TabIndex = 4
		'
		'txtTelefoneA
		'
		Me.txtTelefoneA.Location = New System.Drawing.Point(166, 153)
		Me.txtTelefoneA.Mask = "(99) 99000-0000"
		Me.txtTelefoneA.Name = "txtTelefoneA"
		Me.txtTelefoneA.Size = New System.Drawing.Size(144, 27)
		Me.txtTelefoneA.TabIndex = 8
		'
		'txtCidade
		'
		Me.txtCidade.BackColor = System.Drawing.Color.White
		Me.txtCidade.Location = New System.Drawing.Point(166, 318)
		Me.txtCidade.MaxLength = 50
		Me.txtCidade.Name = "txtCidade"
		Me.txtCidade.Size = New System.Drawing.Size(190, 27)
		Me.txtCidade.TabIndex = 17
		'
		'txtUF
		'
		Me.txtUF.BackColor = System.Drawing.Color.White
		Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtUF.Location = New System.Drawing.Point(166, 351)
		Me.txtUF.MaxLength = 2
		Me.txtUF.Name = "txtUF"
		Me.txtUF.Size = New System.Drawing.Size(46, 27)
		Me.txtUF.TabIndex = 19
		'
		'txtEndereco
		'
		Me.txtEndereco.BackColor = System.Drawing.Color.White
		Me.txtEndereco.Location = New System.Drawing.Point(166, 252)
		Me.txtEndereco.MaxLength = 50
		Me.txtEndereco.Name = "txtEndereco"
		Me.txtEndereco.Size = New System.Drawing.Size(357, 27)
		Me.txtEndereco.TabIndex = 13
		'
		'txtBairro
		'
		Me.txtBairro.BackColor = System.Drawing.Color.White
		Me.txtBairro.Location = New System.Drawing.Point(166, 285)
		Me.txtBairro.MaxLength = 30
		Me.txtBairro.Name = "txtBairro"
		Me.txtBairro.Size = New System.Drawing.Size(190, 27)
		Me.txtBairro.TabIndex = 15
		'
		'lbl2
		'
		Me.lbl2.AutoSize = True
		Me.lbl2.BackColor = System.Drawing.Color.Transparent
		Me.lbl2.ForeColor = System.Drawing.Color.Black
		Me.lbl2.Location = New System.Drawing.Point(111, 289)
		Me.lbl2.Name = "lbl2"
		Me.lbl2.Size = New System.Drawing.Size(48, 19)
		Me.lbl2.TabIndex = 14
		Me.lbl2.Text = "Bairro"
		'
		'lbl1
		'
		Me.lbl1.AutoSize = True
		Me.lbl1.BackColor = System.Drawing.Color.Transparent
		Me.lbl1.ForeColor = System.Drawing.Color.Black
		Me.lbl1.Location = New System.Drawing.Point(90, 256)
		Me.lbl1.Name = "lbl1"
		Me.lbl1.Size = New System.Drawing.Size(69, 19)
		Me.lbl1.TabIndex = 12
		Me.lbl1.Text = "Endereço"
		'
		'txtCEP
		'
		Me.txtCEP.BackColor = System.Drawing.Color.White
		Me.txtCEP.Location = New System.Drawing.Point(262, 351)
		Me.txtCEP.Mask = "00000-000"
		Me.txtCEP.Name = "txtCEP"
		Me.txtCEP.Size = New System.Drawing.Size(94, 27)
		Me.txtCEP.TabIndex = 21
		Me.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.ForeColor = System.Drawing.Color.Black
		Me.Label9.Location = New System.Drawing.Point(94, 157)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(65, 19)
		Me.Label9.TabIndex = 7
		Me.Label9.Text = "Telefone"
		'
		'lbl5
		'
		Me.lbl5.AutoSize = True
		Me.lbl5.BackColor = System.Drawing.Color.Transparent
		Me.lbl5.ForeColor = System.Drawing.Color.Black
		Me.lbl5.Location = New System.Drawing.Point(226, 355)
		Me.lbl5.Name = "lbl5"
		Me.lbl5.Size = New System.Drawing.Size(34, 19)
		Me.lbl5.TabIndex = 20
		Me.lbl5.Text = "CEP"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.ForeColor = System.Drawing.Color.Black
		Me.Label10.Location = New System.Drawing.Point(104, 124)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(55, 19)
		Me.Label10.TabIndex = 3
		Me.Label10.Text = "Celular"
		'
		'lbl4
		'
		Me.lbl4.AutoSize = True
		Me.lbl4.BackColor = System.Drawing.Color.Transparent
		Me.lbl4.ForeColor = System.Drawing.Color.Black
		Me.lbl4.Location = New System.Drawing.Point(133, 355)
		Me.lbl4.Name = "lbl4"
		Me.lbl4.Size = New System.Drawing.Size(26, 19)
		Me.lbl4.TabIndex = 18
		Me.lbl4.Text = "UF"
		'
		'lbl3
		'
		Me.lbl3.AutoSize = True
		Me.lbl3.BackColor = System.Drawing.Color.Transparent
		Me.lbl3.ForeColor = System.Drawing.Color.Black
		Me.lbl3.Location = New System.Drawing.Point(105, 321)
		Me.lbl3.Name = "lbl3"
		Me.lbl3.Size = New System.Drawing.Size(54, 19)
		Me.lbl3.TabIndex = 16
		Me.lbl3.Text = "Cidade"
		'
		'txtClienteNome
		'
		Me.txtClienteNome.BackColor = System.Drawing.Color.White
		Me.txtClienteNome.Location = New System.Drawing.Point(166, 87)
		Me.txtClienteNome.MaxLength = 50
		Me.txtClienteNome.Name = "txtClienteNome"
		Me.txtClienteNome.Size = New System.Drawing.Size(357, 27)
		Me.txtClienteNome.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Location = New System.Drawing.Point(62, 90)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(97, 19)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Nome Cliente"
		'
		'tsMenu
		'
		Me.tsMenu.AutoSize = False
		Me.tsMenu.BackColor = System.Drawing.Color.AntiqueWhite
		Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
		Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.ToolStripSeparator5, Me.btnNovo, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnAtivo, Me.btnFechar})
		Me.tsMenu.Location = New System.Drawing.Point(0, 415)
		Me.tsMenu.Name = "tsMenu"
		Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
		Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.tsMenu.Size = New System.Drawing.Size(597, 48)
		Me.tsMenu.TabIndex = 0
		Me.tsMenu.TabStop = True
		Me.tsMenu.Text = "Menu Cliente PF"
		'
		'btnProcurar
		'
		Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.Procurar_Usuário
		Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnProcurar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
		Me.btnProcurar.Name = "btnProcurar"
		Me.btnProcurar.Size = New System.Drawing.Size(97, 45)
		Me.btnProcurar.Text = "&Procurar"
		Me.btnProcurar.ToolTipText = "Procurar Cliente"
		'
		'ToolStripSeparator5
		'
		Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
		Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 48)
		'
		'btnNovo
		'
		Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Adiconar_Usuário
		Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnNovo.Name = "btnNovo"
		Me.btnNovo.Size = New System.Drawing.Size(76, 45)
		Me.btnNovo.Text = "&Novo"
		Me.btnNovo.ToolTipText = "Novo Cliente Simples"
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
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 48)
		'
		'btnAtivo
		'
		Me.btnAtivo.AutoSize = False
		Me.btnAtivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		Me.btnAtivo.CheckOnClick = True
		Me.btnAtivo.Image = Global.NovaSiao.My.Resources.Resources.Switch_ON_PEQ
		Me.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnAtivo.Name = "btnAtivo"
		Me.btnAtivo.Size = New System.Drawing.Size(110, 41)
		Me.btnAtivo.Text = "Ativo"
		Me.btnAtivo.ToolTipText = "Ativar/Desativar"
		'
		'btnFechar
		'
		Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
		Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(86, 45)
		Me.btnFechar.Text = "&Fechar"
		'
		'lblID
		'
		Me.lblID.BackColor = System.Drawing.Color.Transparent
		Me.lblID.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblID.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblID.Location = New System.Drawing.Point(5, 17)
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
		Me.lbl_IdTexto.Location = New System.Drawing.Point(29, 4)
		Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.lbl_IdTexto.Name = "lbl_IdTexto"
		Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
		Me.lbl_IdTexto.TabIndex = 1
		Me.lbl_IdTexto.Text = "Reg."
		Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'EProvider
		'
		Me.EProvider.ContainerControl = Me
		'
		'txtClienteEmail
		'
		Me.txtClienteEmail.Location = New System.Drawing.Point(166, 186)
		Me.txtClienteEmail.MaxLength = 100
		Me.txtClienteEmail.Name = "txtClienteEmail"
		Me.txtClienteEmail.Size = New System.Drawing.Size(357, 27)
		Me.txtClienteEmail.TabIndex = 10
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.ForeColor = System.Drawing.Color.Black
		Me.Label13.Location = New System.Drawing.Point(108, 189)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(51, 19)
		Me.Label13.TabIndex = 9
		Me.Label13.Text = "e-Mail"
		'
		'chkTemWhatsapp
		'
		Me.chkTemWhatsapp.AutoSize = True
		Me.chkTemWhatsapp.Location = New System.Drawing.Point(33, 9)
		Me.chkTemWhatsapp.Name = "chkTemWhatsapp"
		Me.chkTemWhatsapp.Size = New System.Drawing.Size(15, 14)
		Me.chkTemWhatsapp.TabIndex = 0
		Me.chkTemWhatsapp.UseVisualStyleBackColor = True
		'
		'picWathsapp
		'
		Me.picWathsapp.Image = Global.NovaSiao.My.Resources.Resources.whatsapp_32
		Me.picWathsapp.Location = New System.Drawing.Point(3, 3)
		Me.picWathsapp.Name = "picWathsapp"
		Me.picWathsapp.Size = New System.Drawing.Size(25, 25)
		Me.picWathsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picWathsapp.TabIndex = 46
		Me.picWathsapp.TabStop = False
		'
		'chkEndereco
		'
		Me.chkEndereco.AutoSize = True
		Me.chkEndereco.Location = New System.Drawing.Point(166, 223)
		Me.chkEndereco.Name = "chkEndereco"
		Me.chkEndereco.Size = New System.Drawing.Size(170, 23)
		Me.chkEndereco.TabIndex = 11
		Me.chkEndereco.Text = "Registrar o Endereço?"
		Me.chkEndereco.UseVisualStyleBackColor = True
		'
		'pnlChk
		'
		Me.pnlChk.BackColor = System.Drawing.Color.Transparent
		Me.pnlChk.CausesValidation = False
		Me.pnlChk.Controls.Add(Me.picWathsapp)
		Me.pnlChk.Controls.Add(Me.chkTemWhatsapp)
		Me.pnlChk.Location = New System.Drawing.Point(316, 119)
		Me.pnlChk.Name = "pnlChk"
		Me.pnlChk.Size = New System.Drawing.Size(55, 32)
		Me.pnlChk.TabIndex = 6
		Me.pnlChk.TabStop = True
		'
		'frmClienteSimples
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(597, 463)
		Me.Controls.Add(Me.pnlChk)
		Me.Controls.Add(Me.chkEndereco)
		Me.Controls.Add(Me.tsMenu)
		Me.Controls.Add(Me.txtTelefoneB)
		Me.Controls.Add(Me.txtTelefoneA)
		Me.Controls.Add(Me.txtCidade)
		Me.Controls.Add(Me.txtUF)
		Me.Controls.Add(Me.txtEndereco)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.txtBairro)
		Me.Controls.Add(Me.lbl2)
		Me.Controls.Add(Me.txtClienteEmail)
		Me.Controls.Add(Me.lbl1)
		Me.Controls.Add(Me.txtCEP)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.lbl5)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.lbl4)
		Me.Controls.Add(Me.lbl3)
		Me.Controls.Add(Me.txtClienteNome)
		Me.Controls.Add(Me.Label2)
		Me.KeyPreview = True
		Me.Name = "frmClienteSimples"
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.txtClienteNome, 0)
		Me.Controls.SetChildIndex(Me.lbl3, 0)
		Me.Controls.SetChildIndex(Me.lbl4, 0)
		Me.Controls.SetChildIndex(Me.Label10, 0)
		Me.Controls.SetChildIndex(Me.lbl5, 0)
		Me.Controls.SetChildIndex(Me.Label9, 0)
		Me.Controls.SetChildIndex(Me.txtCEP, 0)
		Me.Controls.SetChildIndex(Me.lbl1, 0)
		Me.Controls.SetChildIndex(Me.txtClienteEmail, 0)
		Me.Controls.SetChildIndex(Me.lbl2, 0)
		Me.Controls.SetChildIndex(Me.txtBairro, 0)
		Me.Controls.SetChildIndex(Me.Label13, 0)
		Me.Controls.SetChildIndex(Me.txtEndereco, 0)
		Me.Controls.SetChildIndex(Me.txtUF, 0)
		Me.Controls.SetChildIndex(Me.txtCidade, 0)
		Me.Controls.SetChildIndex(Me.txtTelefoneA, 0)
		Me.Controls.SetChildIndex(Me.txtTelefoneB, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.tsMenu, 0)
		Me.Controls.SetChildIndex(Me.chkEndereco, 0)
		Me.Controls.SetChildIndex(Me.pnlChk, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.tsMenu.ResumeLayout(False)
		Me.tsMenu.PerformLayout()
		CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picWathsapp, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlChk.ResumeLayout(False)
		Me.pnlChk.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtTelefoneB As Controles.MaskText_Telefone
	Friend WithEvents txtTelefoneA As Controles.MaskText_Telefone
	Friend WithEvents txtCidade As TextBox
	Friend WithEvents txtUF As TextBox
	Friend WithEvents txtEndereco As TextBox
	Friend WithEvents txtBairro As TextBox
	Friend WithEvents lbl2 As Label
	Friend WithEvents lbl1 As Label
	Friend WithEvents txtCEP As MaskedTextBox
	Friend WithEvents Label9 As Label
	Friend WithEvents lbl5 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents lbl4 As Label
	Friend WithEvents lbl3 As Label
	Friend WithEvents txtClienteNome As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents tsMenu As ToolStrip
	Friend WithEvents btnNovo As ToolStripButton
	Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
	Friend WithEvents btnSalvar As ToolStripButton
	Friend WithEvents btnCancelar As ToolStripButton
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents btnAtivo As ToolStripButton
	Friend WithEvents btnProcurar As ToolStripButton
	Friend WithEvents lblID As Label
	Friend WithEvents lbl_IdTexto As Label
	Friend WithEvents EProvider As ErrorProvider
	Friend WithEvents Label13 As Label
	Friend WithEvents txtClienteEmail As TextBox
	Friend WithEvents btnFechar As ToolStripButton
	Friend WithEvents chkTemWhatsapp As CheckBox
	Friend WithEvents picWathsapp As PictureBox
	Friend WithEvents chkEndereco As CheckBox
	Friend WithEvents pnlChk As Panel
End Class
