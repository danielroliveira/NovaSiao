<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClientePJ
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
        Me.lblIDCliente = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.PainelInferior = New System.Windows.Forms.Panel()
        Me.tsMenuCliente = New System.Windows.Forms.ToolStrip()
        Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripDropDownButton()
        Me.FichaCadastroToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtObservacoes = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtLimiteCompras = New Controles.Text_Monetario()
        Me.btnProcuraRG = New VIBlend.WinForms.Controls.vButton()
        Me.txtRGCliente = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtTelefoneB = New Controles.MaskText_Telefone()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCadastroNome = New System.Windows.Forms.TextBox()
        Me.txtTelefoneA = New Controles.MaskText_Telefone()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.txtContatoNome = New System.Windows.Forms.TextBox()
        Me.txtUF = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtInscricaoEstadual = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.cmbRGAtividade = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCNPJ_Texto = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape8 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNomeFantasia = New System.Windows.Forms.TextBox()
        Me.dtpDataFundacao = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.dtpClienteDesde = New System.Windows.Forms.DateTimePicker()
        Me.btnCEPProcura = New VIBlend.WinForms.Controls.vButton()
        Me.Panel1.SuspendLayout()
        Me.PainelInferior.SuspendLayout()
        Me.tsMenuCliente.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblIDCliente)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(764, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblIDCliente, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(505, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(259, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Cliente Pessoa Jurídica"
        '
        'lblIDCliente
        '
        Me.lblIDCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblIDCliente.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDCliente.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblIDCliente.Location = New System.Drawing.Point(6, 18)
        Me.lblIDCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIDCliente.Name = "lblIDCliente"
        Me.lblIDCliente.Size = New System.Drawing.Size(94, 30)
        Me.lblIDCliente.TabIndex = 0
        Me.lblIDCliente.Text = "0001"
        Me.lblIDCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_IdTexto
        '
        Me.lbl_IdTexto.AutoSize = True
        Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver
        Me.lbl_IdTexto.Location = New System.Drawing.Point(30, 5)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 1
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PainelInferior
        '
        Me.PainelInferior.BackColor = System.Drawing.Color.Beige
        Me.PainelInferior.Controls.Add(Me.tsMenuCliente)
        Me.PainelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PainelInferior.Location = New System.Drawing.Point(0, 633)
        Me.PainelInferior.Name = "PainelInferior"
        Me.PainelInferior.Size = New System.Drawing.Size(764, 47)
        Me.PainelInferior.TabIndex = 43
        '
        'tsMenuCliente
        '
        Me.tsMenuCliente.AutoSize = False
        Me.tsMenuCliente.BackColor = System.Drawing.Color.Transparent
        Me.tsMenuCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsMenuCliente.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenuCliente.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenuCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.ToolStripSeparator4, Me.btnNovo, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator5, Me.btnImprimir, Me.btnAtivo, Me.btnFechar})
        Me.tsMenuCliente.Location = New System.Drawing.Point(0, 0)
        Me.tsMenuCliente.Name = "tsMenuCliente"
        Me.tsMenuCliente.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.tsMenuCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMenuCliente.Size = New System.Drawing.Size(764, 47)
        Me.tsMenuCliente.TabIndex = 0
        Me.tsMenuCliente.TabStop = True
        Me.tsMenuCliente.Text = "Menu Cliente PF"
        '
        'btnProcurar
        '
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.Procurar
        Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProcurar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(97, 44)
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.ToolTipText = "Procurar Cliente"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 47)
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Novo_PEQ
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(76, 44)
        Me.btnNovo.Text = "&Novo"
        Me.btnNovo.ToolTipText = "Novo Cliente"
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(82, 44)
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.ToolTipText = "Salvar Registro"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.cancelar_edicao
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 44)
        Me.btnCancelar.Text = "&Cancelar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 47)
        '
        'btnImprimir
        '
        Me.btnImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichaCadastroToolStripMenuItem1})
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(106, 44)
        Me.btnImprimir.Text = "&Imprimir"
        '
        'FichaCadastroToolStripMenuItem1
        '
        Me.FichaCadastroToolStripMenuItem1.Name = "FichaCadastroToolStripMenuItem1"
        Me.FichaCadastroToolStripMenuItem1.Size = New System.Drawing.Size(174, 24)
        Me.FichaCadastroToolStripMenuItem1.Text = "Ficha Cadastro"
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
        Me.btnAtivo.Size = New System.Drawing.Size(160, 41)
        Me.btnAtivo.Text = "Cliente Ativo"
        '
        'btnFechar
        '
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(2, 1, 0, 2)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(86, 44)
        Me.btnFechar.Text = "&Fechar"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(21, 498)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(126, 23)
        Me.Label42.TabIndex = 38
        Me.Label42.Text = "OBSERVAÇÕES"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Location = New System.Drawing.Point(71, 565)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(93, 19)
        Me.Label37.TabIndex = 41
        Me.Label37.Text = "Observações"
        '
        'txtObservacoes
        '
        Me.txtObservacoes.Location = New System.Drawing.Point(170, 562)
        Me.txtObservacoes.MaxLength = 10000
        Me.txtObservacoes.Multiline = True
        Me.txtObservacoes.Name = "txtObservacoes"
        Me.txtObservacoes.Size = New System.Drawing.Size(518, 59)
        Me.txtObservacoes.TabIndex = 42
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Location = New System.Drawing.Point(34, 528)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(130, 19)
        Me.Label39.TabIndex = 39
        Me.Label39.Text = "Limite de Compras"
        '
        'txtLimiteCompras
        '
        Me.txtLimiteCompras.Location = New System.Drawing.Point(170, 525)
        Me.txtLimiteCompras.Name = "txtLimiteCompras"
        Me.txtLimiteCompras.Size = New System.Drawing.Size(124, 27)
        Me.txtLimiteCompras.SomentePositivos = True
        Me.txtLimiteCompras.TabIndex = 40
        Me.txtLimiteCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnProcuraRG
        '
        Me.btnProcuraRG.AllowAnimations = True
        Me.btnProcuraRG.BackColor = System.Drawing.Color.Transparent
        Me.btnProcuraRG.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcuraRG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcuraRG.Location = New System.Drawing.Point(527, 128)
        Me.btnProcuraRG.Name = "btnProcuraRG"
        Me.btnProcuraRG.RoundedCornersMask = CType(15, Byte)
        Me.btnProcuraRG.RoundedCornersRadius = 0
        Me.btnProcuraRG.Size = New System.Drawing.Size(34, 27)
        Me.btnProcuraRG.TabIndex = 8
        Me.btnProcuraRG.TabStop = False
        Me.btnProcuraRG.Text = "..."
        Me.btnProcuraRG.UseCompatibleTextRendering = True
        Me.btnProcuraRG.UseVisualStyleBackColor = False
        Me.btnProcuraRG.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtRGCliente
        '
        Me.txtRGCliente.Location = New System.Drawing.Point(464, 128)
        Me.txtRGCliente.MaxLength = 10
        Me.txtRGCliente.Name = "txtRGCliente"
        Me.txtRGCliente.Size = New System.Drawing.Size(57, 27)
        Me.txtRGCliente.TabIndex = 7
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(21, 300)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(96, 23)
        Me.Label34.TabIndex = 21
        Me.Label34.Text = "ENDEREÇO"
        '
        'txtTelefoneB
        '
        Me.txtTelefoneB.Location = New System.Drawing.Point(383, 428)
        Me.txtTelefoneB.Mask = "(99) 99000-0000"
        Me.txtTelefoneB.Name = "txtTelefoneB"
        Me.txtTelefoneB.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneB.TabIndex = 35
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(21, 60)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(99, 23)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "PRINCIPAIS"
        '
        'txtCadastroNome
        '
        Me.txtCadastroNome.BackColor = System.Drawing.Color.White
        Me.txtCadastroNome.Location = New System.Drawing.Point(170, 95)
        Me.txtCadastroNome.MaxLength = 50
        Me.txtCadastroNome.Name = "txtCadastroNome"
        Me.txtCadastroNome.Size = New System.Drawing.Size(541, 27)
        Me.txtCadastroNome.TabIndex = 3
        '
        'txtTelefoneA
        '
        Me.txtTelefoneA.Location = New System.Drawing.Point(170, 428)
        Me.txtTelefoneA.Mask = "(99) 99000-0000"
        Me.txtTelefoneA.Name = "txtTelefoneA"
        Me.txtTelefoneA.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneA.TabIndex = 33
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(398, 130)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(60, 19)
        Me.Label40.TabIndex = 6
        Me.Label40.Text = "RegAnt."
        '
        'txtCidade
        '
        Me.txtCidade.BackColor = System.Drawing.Color.White
        Me.txtCidade.Location = New System.Drawing.Point(520, 360)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(191, 27)
        Me.txtCidade.TabIndex = 27
        '
        'txtContatoNome
        '
        Me.txtContatoNome.BackColor = System.Drawing.Color.White
        Me.txtContatoNome.Location = New System.Drawing.Point(170, 260)
        Me.txtContatoNome.MaxLength = 50
        Me.txtContatoNome.Name = "txtContatoNome"
        Me.txtContatoNome.Size = New System.Drawing.Size(501, 27)
        Me.txtContatoNome.TabIndex = 20
        '
        'txtUF
        '
        Me.txtUF.BackColor = System.Drawing.Color.White
        Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUF.Location = New System.Drawing.Point(170, 395)
        Me.txtUF.MaxLength = 2
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(46, 27)
        Me.txtUF.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(44, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Data de Abertura"
        '
        'txtEndereco
        '
        Me.txtEndereco.BackColor = System.Drawing.Color.White
        Me.txtEndereco.Location = New System.Drawing.Point(170, 327)
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(541, 27)
        Me.txtEndereco.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(113, 464)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 19)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "e-Mail"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(336, 197)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 19)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Inscrição Estadual"
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(170, 360)
        Me.txtBairro.MaxLength = 30
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(279, 27)
        Me.txtBairro.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(124, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "CNPJ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(116, 363)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 19)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Bairro"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(94, 131)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 19)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "Atividade"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(170, 461)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(357, 27)
        Me.txtEmail.TabIndex = 37
        '
        'txtInscricaoEstadual
        '
        Me.txtInscricaoEstadual.BackColor = System.Drawing.Color.White
        Me.txtInscricaoEstadual.Location = New System.Drawing.Point(464, 194)
        Me.txtInscricaoEstadual.MaxLength = 30
        Me.txtInscricaoEstadual.Name = "txtInscricaoEstadual"
        Me.txtInscricaoEstadual.Size = New System.Drawing.Size(207, 27)
        Me.txtInscricaoEstadual.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(95, 330)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Endereço"
        '
        'txtCEP
        '
        Me.txtCEP.Location = New System.Drawing.Point(266, 395)
        Me.txtCEP.Mask = "00000-000"
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(94, 27)
        Me.txtCEP.TabIndex = 31
        Me.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbRGAtividade
        '
        Me.cmbRGAtividade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRGAtividade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRGAtividade.FormattingEnabled = True
        Me.cmbRGAtividade.Location = New System.Drawing.Point(170, 128)
        Me.cmbRGAtividade.Name = "cmbRGAtividade"
        Me.cmbRGAtividade.Size = New System.Drawing.Size(159, 27)
        Me.cmbRGAtividade.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(99, 431)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Telefone"
        '
        'lblCNPJ_Texto
        '
        Me.lblCNPJ_Texto.BackColor = System.Drawing.Color.White
        Me.lblCNPJ_Texto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCNPJ_Texto.Location = New System.Drawing.Point(170, 194)
        Me.lblCNPJ_Texto.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCNPJ_Texto.Name = "lblCNPJ_Texto"
        Me.lblCNPJ_Texto.Size = New System.Drawing.Size(159, 27)
        Me.lblCNPJ_Texto.TabIndex = 14
        Me.lblCNPJ_Texto.Text = "00.000.000/0000-00"
        Me.lblCNPJ_Texto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(230, 399)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 19)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "CEP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(74, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Razão Social"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(322, 431)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 19)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Celular"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(138, 398)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 19)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "UF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(460, 363)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 19)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Cidade"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(34, 263)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(130, 19)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Pessoa de Contato"
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.LightSlateGray
        Me.LineShape2.BorderWidth = 3
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 124
        Me.LineShape2.X2 = 750
        Me.LineShape2.Y1 = 72
        Me.LineShape2.Y2 = 72
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.LightSlateGray
        Me.LineShape3.BorderWidth = 3
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 117
        Me.LineShape3.X2 = 750
        Me.LineShape3.Y1 = 311
        Me.LineShape3.Y2 = 311
        '
        'LineShape8
        '
        Me.LineShape8.BorderColor = System.Drawing.Color.LightSlateGray
        Me.LineShape8.BorderWidth = 3
        Me.LineShape8.Cursor = System.Windows.Forms.Cursors.Default
        Me.LineShape8.Name = "LineShape8"
        Me.LineShape8.X1 = 148
        Me.LineShape8.X2 = 750
        Me.LineShape8.Y1 = 510
        Me.LineShape8.Y2 = 510
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape8, Me.LineShape3, Me.LineShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(764, 680)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'EProvider
        '
        Me.EProvider.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(58, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 19)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Nome Fantasia"
        '
        'txtNomeFantasia
        '
        Me.txtNomeFantasia.BackColor = System.Drawing.Color.White
        Me.txtNomeFantasia.Location = New System.Drawing.Point(170, 227)
        Me.txtNomeFantasia.MaxLength = 50
        Me.txtNomeFantasia.Name = "txtNomeFantasia"
        Me.txtNomeFantasia.Size = New System.Drawing.Size(501, 27)
        Me.txtNomeFantasia.TabIndex = 18
        '
        'dtpDataFundacao
        '
        Me.dtpDataFundacao.Checked = False
        Me.dtpDataFundacao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataFundacao.Location = New System.Drawing.Point(170, 161)
        Me.dtpDataFundacao.Name = "dtpDataFundacao"
        Me.dtpDataFundacao.ShowCheckBox = True
        Me.dtpDataFundacao.Size = New System.Drawing.Size(159, 27)
        Me.dtpDataFundacao.TabIndex = 10
        Me.dtpDataFundacao.Value = New Date(2019, 3, 15, 0, 0, 0, 0)
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(358, 165)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(100, 19)
        Me.Label44.TabIndex = 11
        Me.Label44.Text = "Cliente Desde"
        '
        'dtpClienteDesde
        '
        Me.dtpClienteDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpClienteDesde.Location = New System.Drawing.Point(464, 161)
        Me.dtpClienteDesde.Name = "dtpClienteDesde"
        Me.dtpClienteDesde.Size = New System.Drawing.Size(131, 27)
        Me.dtpClienteDesde.TabIndex = 12
        '
        'btnCEPProcura
        '
        Me.btnCEPProcura.AllowAnimations = True
        Me.btnCEPProcura.BackColor = System.Drawing.Color.Transparent
        Me.btnCEPProcura.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCEPProcura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCEPProcura.Location = New System.Drawing.Point(366, 395)
        Me.btnCEPProcura.Name = "btnCEPProcura"
        Me.btnCEPProcura.RoundedCornersMask = CType(15, Byte)
        Me.btnCEPProcura.RoundedCornersRadius = 0
        Me.btnCEPProcura.Size = New System.Drawing.Size(34, 27)
        Me.btnCEPProcura.TabIndex = 44
        Me.btnCEPProcura.TabStop = False
        Me.btnCEPProcura.Text = "..."
        Me.btnCEPProcura.UseCompatibleTextRendering = True
        Me.btnCEPProcura.UseVisualStyleBackColor = False
        Me.btnCEPProcura.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'frmClientePJ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(764, 680)
        Me.Controls.Add(Me.btnCEPProcura)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.dtpClienteDesde)
        Me.Controls.Add(Me.dtpDataFundacao)
        Me.Controls.Add(Me.txtNomeFantasia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtObservacoes)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.txtLimiteCompras)
        Me.Controls.Add(Me.btnProcuraRG)
        Me.Controls.Add(Me.txtRGCliente)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtTelefoneB)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtCadastroNome)
        Me.Controls.Add(Me.txtTelefoneA)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.txtContatoNome)
        Me.Controls.Add(Me.txtUF)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEndereco)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtBairro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtInscricaoEstadual)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCEP)
        Me.Controls.Add(Me.cmbRGAtividade)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblCNPJ_Texto)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.PainelInferior)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.KeyPreview = True
        Me.Name = "frmClientePJ"
        Me.Text = "Cliente Pesssoa Jurídica"
        Me.Controls.SetChildIndex(Me.ShapeContainer1, 0)
        Me.Controls.SetChildIndex(Me.PainelInferior, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.lblCNPJ_Texto, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cmbRGAtividade, 0)
        Me.Controls.SetChildIndex(Me.txtCEP, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtInscricaoEstadual, 0)
        Me.Controls.SetChildIndex(Me.txtEmail, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtBairro, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtEndereco, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtUF, 0)
        Me.Controls.SetChildIndex(Me.txtContatoNome, 0)
        Me.Controls.SetChildIndex(Me.txtCidade, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneA, 0)
        Me.Controls.SetChildIndex(Me.txtCadastroNome, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneB, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.txtRGCliente, 0)
        Me.Controls.SetChildIndex(Me.btnProcuraRG, 0)
        Me.Controls.SetChildIndex(Me.txtLimiteCompras, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.txtObservacoes, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.Label42, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtNomeFantasia, 0)
        Me.Controls.SetChildIndex(Me.dtpDataFundacao, 0)
        Me.Controls.SetChildIndex(Me.dtpClienteDesde, 0)
        Me.Controls.SetChildIndex(Me.Label44, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCEPProcura, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PainelInferior.ResumeLayout(False)
        Me.tsMenuCliente.ResumeLayout(False)
        Me.tsMenuCliente.PerformLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIDCliente As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents PainelInferior As Panel
    Friend WithEvents tsMenuCliente As ToolStrip
    Friend WithEvents btnProcurar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnImprimir As ToolStripDropDownButton
    Friend WithEvents FichaCadastroToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents btnFechar As ToolStripButton
    Friend WithEvents Label42 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtObservacoes As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents txtLimiteCompras As Controles.Text_Monetario
    Friend WithEvents btnProcuraRG As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtRGCliente As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtTelefoneB As Controles.MaskText_Telefone
    Friend WithEvents Label33 As Label
    Friend WithEvents txtCadastroNome As TextBox
    Friend WithEvents txtTelefoneA As Controles.MaskText_Telefone
    Friend WithEvents Label40 As Label
    Friend WithEvents txtCidade As TextBox
    Friend WithEvents txtContatoNome As TextBox
    Friend WithEvents txtUF As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEndereco As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtBairro As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtInscricaoEstadual As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCEP As MaskedTextBox
    Friend WithEvents cmbRGAtividade As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCNPJ_Texto As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents txtNomeFantasia As TextBox
    Friend WithEvents Label1 As Label
    Private WithEvents LineShape2 As PowerPacks.LineShape
    Private WithEvents LineShape3 As PowerPacks.LineShape
    Private WithEvents LineShape8 As PowerPacks.LineShape
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents dtpDataFundacao As DateTimePicker
    Friend WithEvents Label44 As Label
    Friend WithEvents dtpClienteDesde As DateTimePicker
    Friend WithEvents btnCEPProcura As VIBlend.WinForms.Controls.vButton
End Class
