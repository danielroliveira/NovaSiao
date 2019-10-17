<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProduto
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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblIDProduto = New System.Windows.Forms.Label()
		Me.lbl_IdTexto = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.txtProduto = New System.Windows.Forms.TextBox()
		Me.txtAutor = New System.Windows.Forms.TextBox()
		Me.txtUnidade = New System.Windows.Forms.TextBox()
		Me.txtPCompra = New Controles.Text_Monetario()
		Me.txtPVenda = New Controles.Text_Monetario()
		Me.cmbSitTributaria = New Controles.ComboBox_OnlyValues()
		Me.txtNCM = New System.Windows.Forms.MaskedTextBox()
		Me.tsMenu = New System.Windows.Forms.ToolStrip()
		Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
		Me.btnNovoGroup = New System.Windows.Forms.ToolStripDropDownButton()
		Me.btnNovoProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnNovoTipo = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnNovoSubTipo = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnNovaCategoria = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnNovoFabricante = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnFornecedores = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
		Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
		Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
		Me.btnFechar = New System.Windows.Forms.ToolStripButton()
		Me.Label33 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.lblMargem = New System.Windows.Forms.Label()
		Me.lblDesconto = New System.Windows.Forms.Label()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.txtRGProduto = New System.Windows.Forms.TextBox()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.txtCodBarrasA = New System.Windows.Forms.TextBox()
		Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.btnProcuraRG = New VIBlend.WinForms.Controls.vButton()
		Me.pnlCalculo = New System.Windows.Forms.Panel()
		Me.chkArredondar = New System.Windows.Forms.CheckBox()
		Me.txtDesconto = New System.Windows.Forms.TextBox()
		Me.txtMargemMin = New System.Windows.Forms.TextBox()
		Me.txtMargem = New System.Windows.Forms.TextBox()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtEstoqueIdeal = New Controles.Text_SoNumeros()
		Me.txtEstoqueNivel = New Controles.Text_SoNumeros()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.btnProcurarTipo = New VIBlend.WinForms.Controls.vButton()
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.btnAutoresLista = New VIBlend.WinForms.Controls.vButton()
		Me.btnFabricantes = New VIBlend.WinForms.Controls.vButton()
		Me.txtDescontoCompra = New System.Windows.Forms.TextBox()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.txtProdutoTipo = New System.Windows.Forms.TextBox()
		Me.txtProdutoSubTipo = New System.Windows.Forms.TextBox()
		Me.txtProdutoCategoria = New System.Windows.Forms.TextBox()
		Me.txtFabricante = New System.Windows.Forms.TextBox()
		Me.cmbMovimento = New Controles.ComboBox_OnlyValues()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.tsMenu.SuspendLayout()
		CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlCalculo.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.lblIDProduto)
		Me.Panel1.Controls.Add(Me.lbl_IdTexto)
		Me.Panel1.Size = New System.Drawing.Size(920, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblIDProduto, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(690, 0)
		Me.lblTitulo.Size = New System.Drawing.Size(230, 50)
		Me.lblTitulo.TabIndex = 2
		Me.lblTitulo.Text = "Cadastro de Produtos"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(130, 139)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(125, 19)
		Me.Label1.TabIndex = 7
		Me.Label1.Text = "Descrição | Título"
		'
		'lblIDProduto
		'
		Me.lblIDProduto.BackColor = System.Drawing.Color.Transparent
		Me.lblIDProduto.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIDProduto.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblIDProduto.Location = New System.Drawing.Point(10, 17)
		Me.lblIDProduto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblIDProduto.Name = "lblIDProduto"
		Me.lblIDProduto.Size = New System.Drawing.Size(94, 30)
		Me.lblIDProduto.TabIndex = 0
		Me.lblIDProduto.Text = "0001"
		Me.lblIDProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lbl_IdTexto
		'
		Me.lbl_IdTexto.AutoSize = True
		Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
		Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver
		Me.lbl_IdTexto.Location = New System.Drawing.Point(41, 4)
		Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.lbl_IdTexto.Name = "lbl_IdTexto"
		Me.lbl_IdTexto.Size = New System.Drawing.Size(23, 13)
		Me.lbl_IdTexto.TabIndex = 1
		Me.lbl_IdTexto.Text = "id."
		Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(178, 272)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(77, 19)
		Me.Label2.TabIndex = 19
		Me.Label2.Text = "Fabricante"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(144, 173)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(111, 19)
		Me.Label3.TabIndex = 9
		Me.Label3.Text = "Tipo de Produto"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(495, 206)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(72, 19)
		Me.Label4.TabIndex = 14
		Me.Label4.Text = "Categoria"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(95, 206)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(160, 19)
		Me.Label5.TabIndex = 12
		Me.Label5.Text = "Classificação | SubTipo"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(211, 239)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(44, 19)
		Me.Label6.TabIndex = 16
		Me.Label6.Text = "Autor"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(196, 336)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(63, 19)
		Me.Label9.TabIndex = 23
		Me.Label9.Text = "Unidade"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(137, 491)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(119, 19)
		Me.Label10.TabIndex = 37
		Me.Label10.Text = "Preço de Compra"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(557, 491)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(109, 19)
		Me.Label11.TabIndex = 42
		Me.Label11.Text = "Preço de Venda"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(125, 431)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(130, 19)
		Me.Label12.TabIndex = 32
		Me.Label12.Text = "Situação Tributária"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(451, 431)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(41, 19)
		Me.Label13.TabIndex = 34
		Me.Label13.Text = "NCM"
		'
		'txtProduto
		'
		Me.txtProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtProduto.Location = New System.Drawing.Point(261, 136)
		Me.txtProduto.MaxLength = 50
		Me.txtProduto.Name = "txtProduto"
		Me.txtProduto.Size = New System.Drawing.Size(511, 27)
		Me.txtProduto.TabIndex = 8
		'
		'txtAutor
		'
		Me.txtAutor.Location = New System.Drawing.Point(261, 236)
		Me.txtAutor.MaxLength = 50
		Me.txtAutor.Name = "txtAutor"
		Me.txtAutor.Size = New System.Drawing.Size(471, 27)
		Me.txtAutor.TabIndex = 17
		'
		'txtUnidade
		'
		Me.txtUnidade.Location = New System.Drawing.Point(261, 333)
		Me.txtUnidade.MaxLength = 10
		Me.txtUnidade.Name = "txtUnidade"
		Me.txtUnidade.Size = New System.Drawing.Size(50, 27)
		Me.txtUnidade.TabIndex = 24
		'
		'txtPCompra
		'
		Me.txtPCompra.Location = New System.Drawing.Point(261, 488)
		Me.txtPCompra.MaxLength = 10
		Me.txtPCompra.Name = "txtPCompra"
		Me.txtPCompra.Size = New System.Drawing.Size(100, 27)
		Me.txtPCompra.SomentePositivos = True
		Me.txtPCompra.TabIndex = 38
		Me.txtPCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtPVenda
		'
		Me.txtPVenda.Location = New System.Drawing.Point(672, 488)
		Me.txtPVenda.MaxLength = 10
		Me.txtPVenda.Name = "txtPVenda"
		Me.txtPVenda.Size = New System.Drawing.Size(100, 27)
		Me.txtPVenda.SomentePositivos = True
		Me.txtPVenda.TabIndex = 43
		Me.txtPVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'cmbSitTributaria
		'
		Me.cmbSitTributaria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbSitTributaria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSitTributaria.FormattingEnabled = True
		Me.cmbSitTributaria.Location = New System.Drawing.Point(261, 428)
		Me.cmbSitTributaria.Name = "cmbSitTributaria"
		Me.cmbSitTributaria.RestrictContentToListItems = True
		Me.cmbSitTributaria.Size = New System.Drawing.Size(173, 27)
		Me.cmbSitTributaria.TabIndex = 33
		'
		'txtNCM
		'
		Me.txtNCM.Location = New System.Drawing.Point(498, 428)
		Me.txtNCM.Name = "txtNCM"
		Me.txtNCM.Size = New System.Drawing.Size(150, 27)
		Me.txtNCM.TabIndex = 35
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
		Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnNovoGroup, Me.btnFornecedores, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnExcluir, Me.btnAtivo, Me.btnFechar})
		Me.tsMenu.Location = New System.Drawing.Point(2, 578)
		Me.tsMenu.Name = "tsMenu"
		Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
		Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		Me.tsMenu.Size = New System.Drawing.Size(916, 48)
		Me.tsMenu.TabIndex = 46
		Me.tsMenu.TabStop = True
		Me.tsMenu.Text = "Menu Cliente PF"
		'
		'btnProcurar
		'
		Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.Procurar
		Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnProcurar.Name = "btnProcurar"
		Me.btnProcurar.Size = New System.Drawing.Size(97, 45)
		Me.btnProcurar.Text = "&Procurar"
		Me.btnProcurar.ToolTipText = "Procurar Produto"
		'
		'btnNovoGroup
		'
		Me.btnNovoGroup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovoProduto, Me.ToolStripSeparator2, Me.btnNovoTipo, Me.btnNovoSubTipo, Me.btnNovaCategoria, Me.ToolStripSeparator3, Me.btnNovoFabricante})
		Me.btnNovoGroup.Image = Global.NovaSiao.My.Resources.Resources.produto
		Me.btnNovoGroup.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnNovoGroup.Name = "btnNovoGroup"
		Me.btnNovoGroup.Size = New System.Drawing.Size(130, 45)
		Me.btnNovoGroup.Text = "&Inserir Novo"
		'
		'btnNovoProduto
		'
		Me.btnNovoProduto.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnNovoProduto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnNovoProduto.Name = "btnNovoProduto"
		Me.btnNovoProduto.Size = New System.Drawing.Size(183, 24)
		Me.btnNovoProduto.Text = "Novo Produto"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(180, 6)
		'
		'btnNovoTipo
		'
		Me.btnNovoTipo.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnNovoTipo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnNovoTipo.Name = "btnNovoTipo"
		Me.btnNovoTipo.Size = New System.Drawing.Size(183, 24)
		Me.btnNovoTipo.Text = "Novo Tipo"
		'
		'btnNovoSubTipo
		'
		Me.btnNovoSubTipo.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnNovoSubTipo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnNovoSubTipo.Name = "btnNovoSubTipo"
		Me.btnNovoSubTipo.Size = New System.Drawing.Size(183, 24)
		Me.btnNovoSubTipo.Text = "Novo SubTipo"
		'
		'btnNovaCategoria
		'
		Me.btnNovaCategoria.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnNovaCategoria.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnNovaCategoria.Name = "btnNovaCategoria"
		Me.btnNovaCategoria.Size = New System.Drawing.Size(183, 24)
		Me.btnNovaCategoria.Text = "Nova Categoria"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
		'
		'btnNovoFabricante
		'
		Me.btnNovoFabricante.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnNovoFabricante.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnNovoFabricante.Name = "btnNovoFabricante"
		Me.btnNovoFabricante.Size = New System.Drawing.Size(183, 24)
		Me.btnNovoFabricante.Text = "Novo Fabricante"
		'
		'btnFornecedores
		'
		Me.btnFornecedores.Image = Global.NovaSiao.My.Resources.Resources.fornecedor_64px
		Me.btnFornecedores.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnFornecedores.Name = "btnFornecedores"
		Me.btnFornecedores.Size = New System.Drawing.Size(130, 45)
		Me.btnFornecedores.Text = "Fornecedores"
		'
		'ToolStripSeparator5
		'
		Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
		Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 48)
		'
		'btnSalvar
		'
		Me.btnSalvar.Enabled = False
		Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
		Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnSalvar.Name = "btnSalvar"
		Me.btnSalvar.Size = New System.Drawing.Size(82, 45)
		Me.btnSalvar.Text = "&Salvar"
		Me.btnSalvar.ToolTipText = "Salvar Produto"
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
		'btnExcluir
		'
		Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.Lixeira
		Me.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnExcluir.Name = "btnExcluir"
		Me.btnExcluir.Size = New System.Drawing.Size(86, 45)
		Me.btnExcluir.Text = "E&xcluir"
		Me.btnExcluir.ToolTipText = "Excluir Produto"
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
		Me.btnAtivo.Size = New System.Drawing.Size(167, 41)
		Me.btnAtivo.Text = "Produto Ativo"
		Me.btnAtivo.ToolTipText = "Produto Ativo"
		'
		'btnFechar
		'
		Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
		Me.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(91, 45)
		Me.btnFechar.Text = "&Fechar"
		'
		'Label33
		'
		Me.Label33.AutoSize = True
		Me.Label33.BackColor = System.Drawing.Color.Transparent
		Me.Label33.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label33.Location = New System.Drawing.Point(30, 66)
		Me.Label33.Name = "Label33"
		Me.Label33.Size = New System.Drawing.Size(89, 23)
		Me.Label33.TabIndex = 1
		Me.Label33.Text = "PRODUTO"
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.BackColor = System.Drawing.Color.Transparent
		Me.Label14.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.Location = New System.Drawing.Point(30, 400)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(113, 23)
		Me.Label14.TabIndex = 31
		Me.Label14.Text = "TRIBUTAÇÃO"
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.BackColor = System.Drawing.Color.Transparent
		Me.Label15.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label15.Location = New System.Drawing.Point(30, 462)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(214, 23)
		Me.Label15.TabIndex = 36
		Me.Label15.Text = "PREÇO COMPRA | VENDA"
		'
		'lblMargem
		'
		Me.lblMargem.AutoSize = True
		Me.lblMargem.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMargem.Location = New System.Drawing.Point(257, 518)
		Me.lblMargem.Name = "lblMargem"
		Me.lblMargem.Size = New System.Drawing.Size(104, 15)
		Me.lblMargem.TabIndex = 39
		Me.lblMargem.Text = "Margem de 0,00%"
		'
		'lblDesconto
		'
		Me.lblDesconto.AutoSize = True
		Me.lblDesconto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDesconto.Location = New System.Drawing.Point(668, 518)
		Me.lblDesconto.Name = "lblDesconto"
		Me.lblDesconto.Size = New System.Drawing.Size(110, 15)
		Me.lblDesconto.TabIndex = 44
		Me.lblDesconto.Text = "Desconto de 0,00%"
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(167, 106)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(88, 19)
		Me.Label16.TabIndex = 2
		Me.Label16.Text = "Reg. Interno"
		'
		'txtRGProduto
		'
		Me.txtRGProduto.Location = New System.Drawing.Point(261, 103)
		Me.txtRGProduto.MaxLength = 10
		Me.txtRGProduto.Name = "txtRGProduto"
		Me.txtRGProduto.Size = New System.Drawing.Size(79, 27)
		Me.txtRGProduto.TabIndex = 3
		Me.txtRGProduto.Tag = "Pressione DELETE para limpar"
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.Location = New System.Drawing.Point(483, 106)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(84, 19)
		Me.Label17.TabIndex = 5
		Me.Label17.Text = "Cod. Barras"
		'
		'txtCodBarrasA
		'
		Me.txtCodBarrasA.Location = New System.Drawing.Point(573, 103)
		Me.txtCodBarrasA.MaxLength = 15
		Me.txtCodBarrasA.Name = "txtCodBarrasA"
		Me.txtCodBarrasA.Size = New System.Drawing.Size(199, 27)
		Me.txtCodBarrasA.TabIndex = 6
		'
		'EProvider
		'
		Me.EProvider.ContainerControl = Me
		'
		'btnProcuraRG
		'
		Me.btnProcuraRG.AllowAnimations = True
		Me.btnProcuraRG.BackColor = System.Drawing.Color.Transparent
		Me.btnProcuraRG.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnProcuraRG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnProcuraRG.Location = New System.Drawing.Point(346, 103)
		Me.btnProcuraRG.Name = "btnProcuraRG"
		Me.btnProcuraRG.RoundedCornersMask = CType(15, Byte)
		Me.btnProcuraRG.RoundedCornersRadius = 0
		Me.btnProcuraRG.Size = New System.Drawing.Size(34, 27)
		Me.btnProcuraRG.TabIndex = 4
		Me.btnProcuraRG.TabStop = False
		Me.btnProcuraRG.Text = "..."
		Me.btnProcuraRG.UseCompatibleTextRendering = True
		Me.btnProcuraRG.UseVisualStyleBackColor = False
		Me.btnProcuraRG.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'pnlCalculo
		'
		Me.pnlCalculo.BackColor = System.Drawing.Color.AntiqueWhite
		Me.pnlCalculo.Controls.Add(Me.chkArredondar)
		Me.pnlCalculo.Controls.Add(Me.txtDesconto)
		Me.pnlCalculo.Controls.Add(Me.txtMargemMin)
		Me.pnlCalculo.Controls.Add(Me.txtMargem)
		Me.pnlCalculo.Controls.Add(Me.Label20)
		Me.pnlCalculo.Controls.Add(Me.Label19)
		Me.pnlCalculo.Controls.Add(Me.Label18)
		Me.pnlCalculo.Location = New System.Drawing.Point(654, 336)
		Me.pnlCalculo.Name = "pnlCalculo"
		Me.pnlCalculo.Size = New System.Drawing.Size(258, 130)
		Me.pnlCalculo.TabIndex = 45
		Me.pnlCalculo.Visible = False
		'
		'chkArredondar
		'
		Me.chkArredondar.AutoSize = True
		Me.chkArredondar.Checked = True
		Me.chkArredondar.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkArredondar.Location = New System.Drawing.Point(132, 24)
		Me.chkArredondar.Name = "chkArredondar"
		Me.chkArredondar.Size = New System.Drawing.Size(108, 42)
		Me.chkArredondar.TabIndex = 4
		Me.chkArredondar.TabStop = False
		Me.chkArredondar.Text = "Arrendondar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Centavos"
		Me.chkArredondar.UseVisualStyleBackColor = True
		'
		'txtDesconto
		'
		Me.txtDesconto.Location = New System.Drawing.Point(140, 89)
		Me.txtDesconto.MaxLength = 5
		Me.txtDesconto.Name = "txtDesconto"
		Me.txtDesconto.Size = New System.Drawing.Size(100, 27)
		Me.txtDesconto.TabIndex = 6
		Me.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtMargemMin
		'
		Me.txtMargemMin.Location = New System.Drawing.Point(20, 89)
		Me.txtMargemMin.MaxLength = 5
		Me.txtMargemMin.Name = "txtMargemMin"
		Me.txtMargemMin.Size = New System.Drawing.Size(100, 27)
		Me.txtMargemMin.TabIndex = 3
		Me.txtMargemMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtMargem
		'
		Me.txtMargem.Location = New System.Drawing.Point(20, 32)
		Me.txtMargem.MaxLength = 5
		Me.txtMargem.Name = "txtMargem"
		Me.txtMargem.Size = New System.Drawing.Size(100, 27)
		Me.txtMargem.TabIndex = 1
		Me.txtMargem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label20
		'
		Me.Label20.AutoSize = True
		Me.Label20.Location = New System.Drawing.Point(16, 65)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(107, 19)
		Me.Label20.TabIndex = 2
		Me.Label20.Text = "Margem Min.%"
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.Location = New System.Drawing.Point(144, 67)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(92, 19)
		Me.Label19.TabIndex = 5
		Me.Label19.Text = "Desc. Max.%"
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Location = New System.Drawing.Point(16, 8)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(78, 19)
		Me.Label18.TabIndex = 0
		Me.Label18.Text = "Margem %"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(30, 306)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(83, 23)
		Me.Label7.TabIndex = 22
		Me.Label7.Text = "ESTOQUE"
		'
		'txtEstoqueIdeal
		'
		Me.txtEstoqueIdeal.Inteiro = True
		Me.txtEstoqueIdeal.Location = New System.Drawing.Point(433, 333)
		Me.txtEstoqueIdeal.Name = "txtEstoqueIdeal"
		Me.txtEstoqueIdeal.Size = New System.Drawing.Size(50, 27)
		Me.txtEstoqueIdeal.TabIndex = 26
		Me.txtEstoqueIdeal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtEstoqueNivel
		'
		Me.txtEstoqueNivel.Inteiro = True
		Me.txtEstoqueNivel.Location = New System.Drawing.Point(598, 333)
		Me.txtEstoqueNivel.Name = "txtEstoqueNivel"
		Me.txtEstoqueNivel.Size = New System.Drawing.Size(50, 27)
		Me.txtEstoqueNivel.TabIndex = 28
		Me.txtEstoqueNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(330, 336)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(98, 19)
		Me.Label8.TabIndex = 25
		Me.Label8.Text = "Estoque Nível"
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(495, 336)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(97, 19)
		Me.Label21.TabIndex = 27
		Me.Label21.Text = "Estoque Ideal"
		'
		'btnProcurarTipo
		'
		Me.btnProcurarTipo.AllowAnimations = True
		Me.btnProcurarTipo.BackColor = System.Drawing.Color.Transparent
		Me.btnProcurarTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnProcurarTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnProcurarTipo.Location = New System.Drawing.Point(466, 170)
		Me.btnProcurarTipo.Name = "btnProcurarTipo"
		Me.btnProcurarTipo.RoundedCornersMask = CType(15, Byte)
		Me.btnProcurarTipo.RoundedCornersRadius = 0
		Me.btnProcurarTipo.Size = New System.Drawing.Size(34, 27)
		Me.btnProcurarTipo.TabIndex = 11
		Me.btnProcurarTipo.TabStop = False
		Me.btnProcurarTipo.Text = "..."
		Me.btnProcurarTipo.UseCompatibleTextRendering = True
		Me.btnProcurarTipo.UseVisualStyleBackColor = False
		Me.btnProcurarTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'ShapeContainer1
		'
		Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
		Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer1.Name = "ShapeContainer1"
		Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
		Me.ShapeContainer1.Size = New System.Drawing.Size(920, 628)
		Me.ShapeContainer1.TabIndex = 1
		Me.ShapeContainer1.TabStop = False
		'
		'LineShape4
		'
		Me.LineShape4.BorderColor = System.Drawing.Color.LightSlateGray
		Me.LineShape4.BorderWidth = 3
		Me.LineShape4.Name = "LineShape4"
		Me.LineShape4.X1 = 115
		Me.LineShape4.X2 = 860
		Me.LineShape4.Y1 = 318
		Me.LineShape4.Y2 = 318
		'
		'LineShape3
		'
		Me.LineShape3.BorderColor = System.Drawing.Color.LightSlateGray
		Me.LineShape3.BorderWidth = 3
		Me.LineShape3.Name = "LineShape3"
		Me.LineShape3.X1 = 250
		Me.LineShape3.X2 = 860
		Me.LineShape3.Y1 = 474
		Me.LineShape3.Y2 = 474
		'
		'LineShape2
		'
		Me.LineShape2.BorderColor = System.Drawing.Color.LightSlateGray
		Me.LineShape2.BorderWidth = 3
		Me.LineShape2.Name = "LineShape2"
		Me.LineShape2.X1 = 145
		Me.LineShape2.X2 = 860
		Me.LineShape2.Y1 = 412
		Me.LineShape2.Y2 = 412
		'
		'LineShape1
		'
		Me.LineShape1.BorderColor = System.Drawing.Color.LightSlateGray
		Me.LineShape1.BorderWidth = 3
		Me.LineShape1.Name = "LineShape1"
		Me.LineShape1.X1 = 120
		Me.LineShape1.X2 = 860
		Me.LineShape1.Y1 = 78
		Me.LineShape1.Y2 = 78
		'
		'btnAutoresLista
		'
		Me.btnAutoresLista.AllowAnimations = True
		Me.btnAutoresLista.BackColor = System.Drawing.Color.Transparent
		Me.btnAutoresLista.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnAutoresLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnAutoresLista.Location = New System.Drawing.Point(738, 236)
		Me.btnAutoresLista.Name = "btnAutoresLista"
		Me.btnAutoresLista.RoundedCornersMask = CType(15, Byte)
		Me.btnAutoresLista.RoundedCornersRadius = 0
		Me.btnAutoresLista.Size = New System.Drawing.Size(34, 27)
		Me.btnAutoresLista.TabIndex = 18
		Me.btnAutoresLista.TabStop = False
		Me.btnAutoresLista.Text = "..."
		Me.btnAutoresLista.UseCompatibleTextRendering = True
		Me.btnAutoresLista.UseVisualStyleBackColor = False
		Me.btnAutoresLista.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnFabricantes
		'
		Me.btnFabricantes.AllowAnimations = True
		Me.btnFabricantes.BackColor = System.Drawing.Color.Transparent
		Me.btnFabricantes.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnFabricantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnFabricantes.Location = New System.Drawing.Point(538, 269)
		Me.btnFabricantes.Name = "btnFabricantes"
		Me.btnFabricantes.RoundedCornersMask = CType(15, Byte)
		Me.btnFabricantes.RoundedCornersRadius = 0
		Me.btnFabricantes.Size = New System.Drawing.Size(34, 27)
		Me.btnFabricantes.TabIndex = 21
		Me.btnFabricantes.TabStop = False
		Me.btnFabricantes.Text = "..."
		Me.btnFabricantes.UseCompatibleTextRendering = True
		Me.btnFabricantes.UseVisualStyleBackColor = False
		Me.btnFabricantes.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'txtDescontoCompra
		'
		Me.txtDescontoCompra.Location = New System.Drawing.Point(473, 488)
		Me.txtDescontoCompra.Name = "txtDescontoCompra"
		Me.txtDescontoCompra.Size = New System.Drawing.Size(65, 27)
		Me.txtDescontoCompra.TabIndex = 41
		Me.txtDescontoCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label22
		'
		Me.Label22.AutoSize = True
		Me.Label22.Location = New System.Drawing.Point(397, 491)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(70, 19)
		Me.Label22.TabIndex = 40
		Me.Label22.Text = "Desconto"
		'
		'txtProdutoTipo
		'
		Me.txtProdutoTipo.Location = New System.Drawing.Point(261, 170)
		Me.txtProdutoTipo.Name = "txtProdutoTipo"
		Me.txtProdutoTipo.Size = New System.Drawing.Size(199, 27)
		Me.txtProdutoTipo.TabIndex = 10
		'
		'txtProdutoSubTipo
		'
		Me.txtProdutoSubTipo.Location = New System.Drawing.Point(261, 203)
		Me.txtProdutoSubTipo.Name = "txtProdutoSubTipo"
		Me.txtProdutoSubTipo.Size = New System.Drawing.Size(199, 27)
		Me.txtProdutoSubTipo.TabIndex = 13
		'
		'txtProdutoCategoria
		'
		Me.txtProdutoCategoria.Location = New System.Drawing.Point(573, 203)
		Me.txtProdutoCategoria.Name = "txtProdutoCategoria"
		Me.txtProdutoCategoria.Size = New System.Drawing.Size(199, 27)
		Me.txtProdutoCategoria.TabIndex = 15
		'
		'txtFabricante
		'
		Me.txtFabricante.Location = New System.Drawing.Point(261, 269)
		Me.txtFabricante.Name = "txtFabricante"
		Me.txtFabricante.Size = New System.Drawing.Size(271, 27)
		Me.txtFabricante.TabIndex = 20
		'
		'cmbMovimento
		'
		Me.cmbMovimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbMovimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbMovimento.FormattingEnabled = True
		Me.cmbMovimento.Location = New System.Drawing.Point(261, 366)
		Me.cmbMovimento.Name = "cmbMovimento"
		Me.cmbMovimento.RestrictContentToListItems = True
		Me.cmbMovimento.Size = New System.Drawing.Size(222, 27)
		Me.cmbMovimento.TabIndex = 30
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.Location = New System.Drawing.Point(112, 371)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(143, 19)
		Me.Label23.TabIndex = 29
		Me.Label23.Text = "Movimentação Atual"
		'
		'frmProduto
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(920, 628)
		Me.Controls.Add(Me.Label23)
		Me.Controls.Add(Me.cmbMovimento)
		Me.Controls.Add(Me.pnlCalculo)
		Me.Controls.Add(Me.txtFabricante)
		Me.Controls.Add(Me.txtProdutoCategoria)
		Me.Controls.Add(Me.txtProdutoSubTipo)
		Me.Controls.Add(Me.tsMenu)
		Me.Controls.Add(Me.txtProdutoTipo)
		Me.Controls.Add(Me.Label22)
		Me.Controls.Add(Me.txtDescontoCompra)
		Me.Controls.Add(Me.btnFabricantes)
		Me.Controls.Add(Me.btnAutoresLista)
		Me.Controls.Add(Me.btnProcurarTipo)
		Me.Controls.Add(Me.Label21)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.txtEstoqueNivel)
		Me.Controls.Add(Me.txtEstoqueIdeal)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.btnProcuraRG)
		Me.Controls.Add(Me.txtCodBarrasA)
		Me.Controls.Add(Me.Label17)
		Me.Controls.Add(Me.txtRGProduto)
		Me.Controls.Add(Me.Label16)
		Me.Controls.Add(Me.lblDesconto)
		Me.Controls.Add(Me.lblMargem)
		Me.Controls.Add(Me.Label15)
		Me.Controls.Add(Me.Label14)
		Me.Controls.Add(Me.Label33)
		Me.Controls.Add(Me.txtNCM)
		Me.Controls.Add(Me.txtPVenda)
		Me.Controls.Add(Me.txtPCompra)
		Me.Controls.Add(Me.cmbSitTributaria)
		Me.Controls.Add(Me.txtUnidade)
		Me.Controls.Add(Me.txtAutor)
		Me.Controls.Add(Me.txtProduto)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.Label12)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ShapeContainer1)
		Me.KeyPreview = True
		Me.Name = "frmProduto"
		Me.Controls.SetChildIndex(Me.ShapeContainer1, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.Label5, 0)
		Me.Controls.SetChildIndex(Me.Label6, 0)
		Me.Controls.SetChildIndex(Me.Label9, 0)
		Me.Controls.SetChildIndex(Me.Label10, 0)
		Me.Controls.SetChildIndex(Me.Label11, 0)
		Me.Controls.SetChildIndex(Me.Label12, 0)
		Me.Controls.SetChildIndex(Me.Label13, 0)
		Me.Controls.SetChildIndex(Me.txtProduto, 0)
		Me.Controls.SetChildIndex(Me.txtAutor, 0)
		Me.Controls.SetChildIndex(Me.txtUnidade, 0)
		Me.Controls.SetChildIndex(Me.cmbSitTributaria, 0)
		Me.Controls.SetChildIndex(Me.txtPCompra, 0)
		Me.Controls.SetChildIndex(Me.txtPVenda, 0)
		Me.Controls.SetChildIndex(Me.txtNCM, 0)
		Me.Controls.SetChildIndex(Me.Label33, 0)
		Me.Controls.SetChildIndex(Me.Label14, 0)
		Me.Controls.SetChildIndex(Me.Label15, 0)
		Me.Controls.SetChildIndex(Me.lblMargem, 0)
		Me.Controls.SetChildIndex(Me.lblDesconto, 0)
		Me.Controls.SetChildIndex(Me.Label16, 0)
		Me.Controls.SetChildIndex(Me.txtRGProduto, 0)
		Me.Controls.SetChildIndex(Me.Label17, 0)
		Me.Controls.SetChildIndex(Me.txtCodBarrasA, 0)
		Me.Controls.SetChildIndex(Me.btnProcuraRG, 0)
		Me.Controls.SetChildIndex(Me.Label7, 0)
		Me.Controls.SetChildIndex(Me.txtEstoqueIdeal, 0)
		Me.Controls.SetChildIndex(Me.txtEstoqueNivel, 0)
		Me.Controls.SetChildIndex(Me.Label8, 0)
		Me.Controls.SetChildIndex(Me.Label21, 0)
		Me.Controls.SetChildIndex(Me.btnProcurarTipo, 0)
		Me.Controls.SetChildIndex(Me.btnAutoresLista, 0)
		Me.Controls.SetChildIndex(Me.btnFabricantes, 0)
		Me.Controls.SetChildIndex(Me.txtDescontoCompra, 0)
		Me.Controls.SetChildIndex(Me.Label22, 0)
		Me.Controls.SetChildIndex(Me.txtProdutoTipo, 0)
		Me.Controls.SetChildIndex(Me.tsMenu, 0)
		Me.Controls.SetChildIndex(Me.txtProdutoSubTipo, 0)
		Me.Controls.SetChildIndex(Me.txtProdutoCategoria, 0)
		Me.Controls.SetChildIndex(Me.txtFabricante, 0)
		Me.Controls.SetChildIndex(Me.pnlCalculo, 0)
		Me.Controls.SetChildIndex(Me.cmbMovimento, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Label23, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.tsMenu.ResumeLayout(False)
		Me.tsMenu.PerformLayout()
		CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlCalculo.ResumeLayout(False)
		Me.pnlCalculo.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
    Friend WithEvents lblIDProduto As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtProduto As TextBox
    Friend WithEvents txtAutor As TextBox
    Friend WithEvents txtUnidade As TextBox
    Friend WithEvents txtPCompra As Controles.Text_Monetario
    Friend WithEvents txtPVenda As Controles.Text_Monetario
    Friend WithEvents cmbSitTributaria As Controles.ComboBox_OnlyValues
    Friend WithEvents txtNCM As MaskedTextBox
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents Label33 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblMargem As Label
    Friend WithEvents lblDesconto As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtRGProduto As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCodBarrasA As TextBox
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents btnProcurar As ToolStripButton
    Friend WithEvents btnProcuraRG As VIBlend.WinForms.Controls.vButton
    Friend WithEvents pnlCalculo As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtDesconto As TextBox
    Friend WithEvents txtMargem As TextBox
    Friend WithEvents txtMargemMin As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents chkArredondar As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEstoqueNivel As Controles.Text_SoNumeros
    Friend WithEvents txtEstoqueIdeal As Controles.Text_SoNumeros
    Friend WithEvents Label7 As Label
    Friend WithEvents btnProcurarTipo As VIBlend.WinForms.Controls.vButton
	Friend WithEvents btnAutoresLista As VIBlend.WinForms.Controls.vButton
	Friend WithEvents btnFabricantes As VIBlend.WinForms.Controls.vButton
	Friend WithEvents Label22 As Label
	Friend WithEvents txtDescontoCompra As TextBox
	Friend WithEvents txtProdutoTipo As TextBox
	Friend WithEvents btnFechar As ToolStripButton
	Friend WithEvents txtProdutoCategoria As TextBox
	Friend WithEvents txtProdutoSubTipo As TextBox
	Friend WithEvents btnNovoGroup As ToolStripDropDownButton
	Friend WithEvents btnNovoProduto As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
	Friend WithEvents btnNovoTipo As ToolStripMenuItem
	Friend WithEvents btnNovoSubTipo As ToolStripMenuItem
	Friend WithEvents btnNovaCategoria As ToolStripMenuItem
	Friend WithEvents txtFabricante As TextBox
	Friend WithEvents Label23 As Label
	Friend WithEvents cmbMovimento As Controles.ComboBox_OnlyValues
	Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
	Friend WithEvents btnNovoFabricante As ToolStripMenuItem
	Friend WithEvents btnFornecedores As ToolStripButton
	Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
	Private WithEvents LineShape4 As PowerPacks.LineShape
	Private WithEvents LineShape3 As PowerPacks.LineShape
	Private WithEvents LineShape2 As PowerPacks.LineShape
	Private WithEvents LineShape1 As PowerPacks.LineShape
End Class
