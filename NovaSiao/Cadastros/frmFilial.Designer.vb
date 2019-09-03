<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFilial
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuFil = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AtivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtApelidoFilial = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAliquotaICMS = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtUF = New System.Windows.Forms.TextBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.txtCEP = New Controles.MaskText_Telefone()
        Me.txtTelefoneFinanceiro = New Controles.MaskText_Telefone()
        Me.txtTelefoneGerencia = New Controles.MaskText_Telefone()
        Me.txtTelefonePrincipal = New Controles.MaskText_Telefone()
        Me.txtCNPJ = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIncricao = New System.Windows.Forms.TextBox()
        Me.txtContatoFinanceiro = New System.Windows.Forms.TextBox()
        Me.txtContatoGerencia = New System.Windows.Forms.TextBox()
        Me.txtNumeroWhatsapp = New Controles.MaskText_Telefone()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNomeFantasia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRazaoSocial = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        Me.MenuFil.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(633, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(436, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(197, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Cadastro de Filial"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuFil
        '
        Me.MenuFil.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtivarToolStripMenuItem, Me.DesativarToolStripMenuItem})
        Me.MenuFil.Name = "MenuFab"
        Me.MenuFil.Size = New System.Drawing.Size(150, 48)
        '
        'AtivarToolStripMenuItem
        '
        Me.AtivarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem"
        Me.AtivarToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AtivarToolStripMenuItem.Text = "Ativar Filial"
        '
        'DesativarToolStripMenuItem
        '
        Me.DesativarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem"
        Me.DesativarToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DesativarToolStripMenuItem.Text = "Desativar Filial"
        '
        'txtApelidoFilial
        '
        Me.txtApelidoFilial.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApelidoFilial.Location = New System.Drawing.Point(171, 159)
        Me.txtApelidoFilial.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtApelidoFilial.MaxLength = 50
        Me.txtApelidoFilial.Name = "txtApelidoFilial"
        Me.txtApelidoFilial.Size = New System.Drawing.Size(177, 27)
        Me.txtApelidoFilial.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Apelido da Filial:"
        '
        'txtAliquotaICMS
        '
        Me.txtAliquotaICMS.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAliquotaICMS.Location = New System.Drawing.Point(495, 237)
        Me.txtAliquotaICMS.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtAliquotaICMS.MaxLength = 6
        Me.txtAliquotaICMS.Name = "txtAliquotaICMS"
        Me.txtAliquotaICMS.Size = New System.Drawing.Size(69, 27)
        Me.txtAliquotaICMS.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(374, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 19)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Aliquota ICMS %"
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
        Me.lblID.TabIndex = 1
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
        Me.lbl_IdTexto.TabIndex = 2
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
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnAtivo, Me.btnFechar})
        Me.tsMenu.Location = New System.Drawing.Point(4, 600)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMenu.Size = New System.Drawing.Size(627, 48)
        Me.tsMenu.TabIndex = 37
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
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
        Me.btnAtivo.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.btnAtivo.Name = "btnAtivo"
        Me.btnAtivo.Size = New System.Drawing.Size(110, 41)
        Me.btnAtivo.Text = "Ativa"
        Me.btnAtivo.ToolTipText = "Ativar/Desativar Filial"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(350, 357)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(30, 19)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "UF:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(127, 357)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(38, 19)
        Me.Label27.TabIndex = 19
        Me.Label27.Text = "CEP:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(92, 279)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 19)
        Me.Label28.TabIndex = 13
        Me.Label28.Text = "Endereço:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(113, 318)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 19)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Bairro:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(322, 318)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 19)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "Cidade:"
        '
        'txtUF
        '
        Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUF.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUF.Location = New System.Drawing.Point(386, 354)
        Me.txtUF.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtUF.MaxLength = 2
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(51, 27)
        Me.txtUF.TabIndex = 22
        '
        'txtEndereco
        '
        Me.txtEndereco.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndereco.Location = New System.Drawing.Point(171, 276)
        Me.txtEndereco.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtEndereco.MaxLength = 50
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(393, 27)
        Me.txtEndereco.TabIndex = 14
        '
        'txtBairro
        '
        Me.txtBairro.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBairro.Location = New System.Drawing.Point(171, 315)
        Me.txtBairro.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtBairro.MaxLength = 50
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(140, 27)
        Me.txtBairro.TabIndex = 16
        '
        'txtCidade
        '
        Me.txtCidade.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCidade.Location = New System.Drawing.Point(386, 315)
        Me.txtCidade.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(178, 27)
        Me.txtCidade.TabIndex = 18
        '
        'txtCEP
        '
        Me.txtCEP.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEP.Location = New System.Drawing.Point(171, 354)
        Me.txtCEP.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtCEP.Mask = "99999-999"
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(140, 27)
        Me.txtCEP.TabIndex = 20
        '
        'txtTelefoneFinanceiro
        '
        Me.txtTelefoneFinanceiro.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefoneFinanceiro.Location = New System.Drawing.Point(171, 471)
        Me.txtTelefoneFinanceiro.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtTelefoneFinanceiro.Mask = "(99) 99000-0000"
        Me.txtTelefoneFinanceiro.Name = "txtTelefoneFinanceiro"
        Me.txtTelefoneFinanceiro.Size = New System.Drawing.Size(140, 27)
        Me.txtTelefoneFinanceiro.TabIndex = 30
        '
        'txtTelefoneGerencia
        '
        Me.txtTelefoneGerencia.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefoneGerencia.Location = New System.Drawing.Point(171, 432)
        Me.txtTelefoneGerencia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtTelefoneGerencia.Mask = "(99) 99000-0000"
        Me.txtTelefoneGerencia.Name = "txtTelefoneGerencia"
        Me.txtTelefoneGerencia.Size = New System.Drawing.Size(140, 27)
        Me.txtTelefoneGerencia.TabIndex = 26
        '
        'txtTelefonePrincipal
        '
        Me.txtTelefonePrincipal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefonePrincipal.Location = New System.Drawing.Point(171, 393)
        Me.txtTelefonePrincipal.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtTelefonePrincipal.Mask = "(99) 99000-0000"
        Me.txtTelefonePrincipal.Name = "txtTelefonePrincipal"
        Me.txtTelefonePrincipal.Size = New System.Drawing.Size(140, 27)
        Me.txtTelefonePrincipal.TabIndex = 24
        '
        'txtCNPJ
        '
        Me.txtCNPJ.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCNPJ.Location = New System.Drawing.Point(171, 198)
        Me.txtCNPJ.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtCNPJ.Mask = "00,000,000/0000-00"
        Me.txtCNPJ.Name = "txtCNPJ"
        Me.txtCNPJ.Size = New System.Drawing.Size(177, 27)
        Me.txtCNPJ.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 474)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 19)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Telefone Financeiro:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CNPJ:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(34, 435)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 19)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Telefone Gerência:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(36, 396)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 19)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Telefone Principal:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Inscrição Estadual:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(325, 474)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 19)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Falar com:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(325, 435)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 19)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Falar com:"
        '
        'txtIncricao
        '
        Me.txtIncricao.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncricao.Location = New System.Drawing.Point(171, 237)
        Me.txtIncricao.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtIncricao.MaxLength = 50
        Me.txtIncricao.Name = "txtIncricao"
        Me.txtIncricao.Size = New System.Drawing.Size(178, 27)
        Me.txtIncricao.TabIndex = 10
        '
        'txtContatoFinanceiro
        '
        Me.txtContatoFinanceiro.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContatoFinanceiro.Location = New System.Drawing.Point(407, 471)
        Me.txtContatoFinanceiro.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtContatoFinanceiro.MaxLength = 30
        Me.txtContatoFinanceiro.Name = "txtContatoFinanceiro"
        Me.txtContatoFinanceiro.Size = New System.Drawing.Size(157, 27)
        Me.txtContatoFinanceiro.TabIndex = 32
        '
        'txtContatoGerencia
        '
        Me.txtContatoGerencia.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContatoGerencia.Location = New System.Drawing.Point(407, 432)
        Me.txtContatoGerencia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtContatoGerencia.MaxLength = 30
        Me.txtContatoGerencia.Name = "txtContatoGerencia"
        Me.txtContatoGerencia.Size = New System.Drawing.Size(157, 27)
        Me.txtContatoGerencia.TabIndex = 28
        '
        'txtNumeroWhatsapp
        '
        Me.txtNumeroWhatsapp.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroWhatsapp.Location = New System.Drawing.Point(171, 510)
        Me.txtNumeroWhatsapp.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtNumeroWhatsapp.Mask = "(99) 99000-0000"
        Me.txtNumeroWhatsapp.Name = "txtNumeroWhatsapp"
        Me.txtNumeroWhatsapp.Size = New System.Drawing.Size(140, 27)
        Me.txtNumeroWhatsapp.TabIndex = 34
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(55, 552)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 19)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "e-Mail Contato:"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(171, 549)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(393, 27)
        Me.txtEmail.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(31, 513)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 19)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Numero Whatsapp:"
        '
        'txtNomeFantasia
        '
        Me.txtNomeFantasia.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomeFantasia.Location = New System.Drawing.Point(171, 120)
        Me.txtNomeFantasia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtNomeFantasia.MaxLength = 50
        Me.txtNomeFantasia.Name = "txtNomeFantasia"
        Me.txtNomeFantasia.Size = New System.Drawing.Size(177, 27)
        Me.txtNomeFantasia.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nome Fantasia:"
        '
        'txtRazaoSocial
        '
        Me.txtRazaoSocial.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazaoSocial.Location = New System.Drawing.Point(172, 81)
        Me.txtRazaoSocial.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtRazaoSocial.MaxLength = 50
        Me.txtRazaoSocial.Name = "txtRazaoSocial"
        Me.txtRazaoSocial.Size = New System.Drawing.Size(392, 27)
        Me.txtRazaoSocial.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(71, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Razão Social:"
        '
        'btnFechar
        '
        Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(86, 45)
        Me.btnFechar.Text = "&Fechar"
        '
        'frmFilial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(633, 650)
        Me.Controls.Add(Me.txtNumeroWhatsapp)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtUF)
        Me.Controls.Add(Me.txtEndereco)
        Me.Controls.Add(Me.txtBairro)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.txtCEP)
        Me.Controls.Add(Me.txtTelefoneFinanceiro)
        Me.Controls.Add(Me.txtTelefoneGerencia)
        Me.Controls.Add(Me.txtTelefonePrincipal)
        Me.Controls.Add(Me.txtCNPJ)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtIncricao)
        Me.Controls.Add(Me.txtContatoFinanceiro)
        Me.Controls.Add(Me.txtContatoGerencia)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAliquotaICMS)
        Me.Controls.Add(Me.txtRazaoSocial)
        Me.Controls.Add(Me.txtNomeFantasia)
        Me.Controls.Add(Me.txtApelidoFilial)
        Me.KeyPreview = True
        Me.Name = "frmFilial"
        Me.Controls.SetChildIndex(Me.txtApelidoFilial, 0)
        Me.Controls.SetChildIndex(Me.txtNomeFantasia, 0)
        Me.Controls.SetChildIndex(Me.txtRazaoSocial, 0)
        Me.Controls.SetChildIndex(Me.txtAliquotaICMS, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.tsMenu, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.txtContatoGerencia, 0)
        Me.Controls.SetChildIndex(Me.txtContatoFinanceiro, 0)
        Me.Controls.SetChildIndex(Me.txtIncricao, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtCNPJ, 0)
        Me.Controls.SetChildIndex(Me.txtTelefonePrincipal, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneGerencia, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneFinanceiro, 0)
        Me.Controls.SetChildIndex(Me.txtCEP, 0)
        Me.Controls.SetChildIndex(Me.txtCidade, 0)
        Me.Controls.SetChildIndex(Me.txtBairro, 0)
        Me.Controls.SetChildIndex(Me.txtEndereco, 0)
        Me.Controls.SetChildIndex(Me.txtUF, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtEmail, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroWhatsapp, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuFil.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuFil As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtApelidoFilial As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAliquotaICMS As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblID As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents Label24 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtUF As TextBox
    Friend WithEvents txtEndereco As TextBox
    Friend WithEvents txtBairro As TextBox
    Friend WithEvents txtCidade As TextBox
    Friend WithEvents txtCEP As Controles.MaskText_Telefone
    Friend WithEvents txtTelefoneFinanceiro As Controles.MaskText_Telefone
    Friend WithEvents txtTelefoneGerencia As Controles.MaskText_Telefone
    Friend WithEvents txtTelefonePrincipal As Controles.MaskText_Telefone
    Friend WithEvents txtCNPJ As MaskedTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtIncricao As TextBox
    Friend WithEvents txtContatoFinanceiro As TextBox
    Friend WithEvents txtContatoGerencia As TextBox
    Friend WithEvents txtNumeroWhatsapp As Controles.MaskText_Telefone
    Friend WithEvents Label16 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNomeFantasia As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRazaoSocial As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnFechar As ToolStripButton
End Class
