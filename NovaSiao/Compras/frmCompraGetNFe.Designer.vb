<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCompraGetNFe
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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.btnImportar = New System.Windows.Forms.Button()
		Me.btnFechar = New System.Windows.Forms.Button()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.dgvItens = New System.Windows.Forms.DataGridView()
		Me.clnIDProdutoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnProdutoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnQuantidadeNFe = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnPrecoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnDescontoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnTotalNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.btnCorrelacao = New System.Windows.Forms.Button()
		Me.lblRazaoSocial = New System.Windows.Forms.Label()
		Me.lblCNPJ = New System.Windows.Forms.Label()
		Me.mnuItens = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.miAnexarProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.miObterProdutoDBAnterior = New System.Windows.Forms.ToolStripMenuItem()
		Me.miNovoProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.miAbrirProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnSalvarCompra = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblTransportadora = New System.Windows.Forms.Label()
		Me.lblTranspCNPJ = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.lblSelectInfo = New System.Windows.Forms.Label()
		Me.tspMenuFornecedor = New System.Windows.Forms.ToolStrip()
		Me.btnMenuFornecedor = New System.Windows.Forms.ToolStripSplitButton()
		Me.btnInserirFornecedor = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnVincularCNPJFornecedor = New System.Windows.Forms.ToolStripMenuItem()
		Me.tspMenuTransp = New System.Windows.Forms.ToolStrip()
		Me.btnMenuTransp = New System.Windows.Forms.ToolStripSplitButton()
		Me.btnInserirTransportadora = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnVincularCNPJTransp = New System.Windows.Forms.ToolStripMenuItem()
		Me.Panel1.SuspendLayout()
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.mnuItens.SuspendLayout()
		Me.tspMenuFornecedor.SuspendLayout()
		Me.tspMenuTransp.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Size = New System.Drawing.Size(1191, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(872, 0)
		Me.lblTitulo.Size = New System.Drawing.Size(319, 50)
		Me.lblTitulo.Text = "Importar Entrada NFe XML"
		Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnImportar
		'
		Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnImportar.Image = Global.NovaSiao.My.Resources.Resources.download
		Me.btnImportar.Location = New System.Drawing.Point(10, 601)
		Me.btnImportar.Name = "btnImportar"
		Me.btnImportar.Size = New System.Drawing.Size(195, 43)
		Me.btnImportar.TabIndex = 13
		Me.btnImportar.Text = "Importar XML"
		Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnImportar.UseVisualStyleBackColor = True
		'
		'btnFechar
		'
		Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
		Me.btnFechar.Location = New System.Drawing.Point(1007, 601)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(166, 43)
		Me.btnFechar.TabIndex = 16
		Me.btnFechar.Text = "Fechar"
		Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnFechar.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Location = New System.Drawing.Point(81, 104)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(40, 19)
		Me.Label4.TabIndex = 3
		Me.Label4.Text = "CNPJ"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Location = New System.Drawing.Point(40, 69)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(81, 19)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Fornecedor"
		'
		'dgvItens
		'
		Me.dgvItens.AllowUserToAddRows = False
		Me.dgvItens.AllowUserToDeleteRows = False
		Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvItens.ColumnHeadersHeight = 25
		Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDProdutoNfe, Me.clnProdutoNfe, Me.clnQuantidadeNFe, Me.clnPrecoNfe, Me.clnDescontoNfe, Me.clnTotalNfe, Me.clnRGProduto, Me.clnProduto})
		Me.dgvItens.EnableHeadersVisualStyles = False
		Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvItens.Location = New System.Drawing.Point(12, 145)
		Me.dgvItens.Name = "dgvItens"
		Me.dgvItens.ReadOnly = True
		Me.dgvItens.RowHeadersWidth = 30
		Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvItens.Size = New System.Drawing.Size(1161, 444)
		Me.dgvItens.TabIndex = 12
		Me.dgvItens.VirtualMode = True
		'
		'clnIDProdutoNfe
		'
		Me.clnIDProdutoNfe.Frozen = True
		Me.clnIDProdutoNfe.HeaderText = "Cod. NFe"
		Me.clnIDProdutoNfe.Name = "clnIDProdutoNfe"
		Me.clnIDProdutoNfe.ReadOnly = True
		Me.clnIDProdutoNfe.Width = 80
		'
		'clnProdutoNfe
		'
		Me.clnProdutoNfe.Frozen = True
		Me.clnProdutoNfe.HeaderText = "Desc. Origem NFe"
		Me.clnProdutoNfe.Name = "clnProdutoNfe"
		Me.clnProdutoNfe.ReadOnly = True
		Me.clnProdutoNfe.Width = 375
		'
		'clnQuantidadeNFe
		'
		Me.clnQuantidadeNFe.Frozen = True
		Me.clnQuantidadeNFe.HeaderText = "Qtde"
		Me.clnQuantidadeNFe.Name = "clnQuantidadeNFe"
		Me.clnQuantidadeNFe.ReadOnly = True
		Me.clnQuantidadeNFe.Width = 60
		'
		'clnPrecoNfe
		'
		Me.clnPrecoNfe.Frozen = True
		Me.clnPrecoNfe.HeaderText = "Preço"
		Me.clnPrecoNfe.Name = "clnPrecoNfe"
		Me.clnPrecoNfe.ReadOnly = True
		Me.clnPrecoNfe.Width = 90
		'
		'clnDescontoNfe
		'
		Me.clnDescontoNfe.HeaderText = "Desc. (%)"
		Me.clnDescontoNfe.Name = "clnDescontoNfe"
		Me.clnDescontoNfe.ReadOnly = True
		Me.clnDescontoNfe.Width = 80
		'
		'clnTotalNfe
		'
		Me.clnTotalNfe.HeaderText = "Total"
		Me.clnTotalNfe.Name = "clnTotalNfe"
		Me.clnTotalNfe.ReadOnly = True
		Me.clnTotalNfe.Width = 90
		'
		'clnRGProduto
		'
		Me.clnRGProduto.HeaderText = "Reg."
		Me.clnRGProduto.Name = "clnRGProduto"
		Me.clnRGProduto.ReadOnly = True
		Me.clnRGProduto.Width = 60
		'
		'clnProduto
		'
		Me.clnProduto.HeaderText = "Produto Encontrado"
		Me.clnProduto.Name = "clnProduto"
		Me.clnProduto.ReadOnly = True
		Me.clnProduto.Width = 250
		'
		'btnCorrelacao
		'
		Me.btnCorrelacao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnCorrelacao.Enabled = False
		Me.btnCorrelacao.Image = Global.NovaSiao.My.Resources.Resources.refresh1
		Me.btnCorrelacao.Location = New System.Drawing.Point(211, 601)
		Me.btnCorrelacao.Name = "btnCorrelacao"
		Me.btnCorrelacao.Size = New System.Drawing.Size(195, 43)
		Me.btnCorrelacao.TabIndex = 14
		Me.btnCorrelacao.Tag = "Clique aqui para Relacionar Itens e Produtos"
		Me.btnCorrelacao.Text = "Fazer Correlação"
		Me.btnCorrelacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCorrelacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnCorrelacao.UseVisualStyleBackColor = True
		'
		'lblRazaoSocial
		'
		Me.lblRazaoSocial.BackColor = System.Drawing.Color.White
		Me.lblRazaoSocial.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRazaoSocial.ForeColor = System.Drawing.Color.Black
		Me.lblRazaoSocial.Location = New System.Drawing.Point(127, 67)
		Me.lblRazaoSocial.Name = "lblRazaoSocial"
		Me.lblRazaoSocial.Size = New System.Drawing.Size(494, 26)
		Me.lblRazaoSocial.TabIndex = 2
		Me.lblRazaoSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCNPJ
		'
		Me.lblCNPJ.BackColor = System.Drawing.Color.White
		Me.lblCNPJ.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCNPJ.ForeColor = System.Drawing.Color.Black
		Me.lblCNPJ.Location = New System.Drawing.Point(127, 101)
		Me.lblCNPJ.Name = "lblCNPJ"
		Me.lblCNPJ.Size = New System.Drawing.Size(494, 28)
		Me.lblCNPJ.TabIndex = 4
		Me.lblCNPJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'mnuItens
		'
		Me.mnuItens.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mnuItens.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAnexarProduto, Me.miObterProdutoDBAnterior, Me.miNovoProduto, Me.ToolStripSeparator1, Me.miAbrirProduto})
		Me.mnuItens.Name = "mnuItens"
		Me.mnuItens.Size = New System.Drawing.Size(249, 128)
		'
		'miAnexarProduto
		'
		Me.miAnexarProduto.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miAnexarProduto.Name = "miAnexarProduto"
		Me.miAnexarProduto.Size = New System.Drawing.Size(248, 24)
		Me.miAnexarProduto.Text = "Anexar a um Produto"
		Me.miAnexarProduto.ToolTipText = "Correlacionar com um produto existente"
		'
		'miObterProdutoDBAnterior
		'
		Me.miObterProdutoDBAnterior.Image = Global.NovaSiao.My.Resources.Resources.download
		Me.miObterProdutoDBAnterior.Name = "miObterProdutoDBAnterior"
		Me.miObterProdutoDBAnterior.Size = New System.Drawing.Size(248, 24)
		Me.miObterProdutoDBAnterior.Text = "Obter Produto DB Anterior"
		'
		'miNovoProduto
		'
		Me.miNovoProduto.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.miNovoProduto.Name = "miNovoProduto"
		Me.miNovoProduto.Size = New System.Drawing.Size(248, 24)
		Me.miNovoProduto.Text = "Criar novo Produto"
		Me.miNovoProduto.ToolTipText = "Um produto que nunca foi inserido"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(245, 6)
		'
		'miAbrirProduto
		'
		Me.miAbrirProduto.Image = Global.NovaSiao.My.Resources.Resources.Estoque_24px
		Me.miAbrirProduto.Name = "miAbrirProduto"
		Me.miAbrirProduto.Size = New System.Drawing.Size(248, 24)
		Me.miAbrirProduto.Text = "Visualizar Produto"
		Me.miAbrirProduto.ToolTipText = "Abrir o cadastro do produto"
		'
		'btnSalvarCompra
		'
		Me.btnSalvarCompra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnSalvarCompra.Enabled = False
		Me.btnSalvarCompra.Image = Global.NovaSiao.My.Resources.Resources.save
		Me.btnSalvarCompra.Location = New System.Drawing.Point(412, 601)
		Me.btnSalvarCompra.Name = "btnSalvarCompra"
		Me.btnSalvarCompra.Size = New System.Drawing.Size(195, 43)
		Me.btnSalvarCompra.TabIndex = 15
		Me.btnSalvarCompra.Tag = "Clique aqui para criar uma nova Compra"
		Me.btnSalvarCompra.Text = "Salvar Compra"
		Me.btnSalvarCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnSalvarCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnSalvarCompra.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Location = New System.Drawing.Point(647, 69)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(107, 19)
		Me.Label1.TabIndex = 7
		Me.Label1.Text = "Transportadora"
		'
		'lblTransportadora
		'
		Me.lblTransportadora.BackColor = System.Drawing.Color.White
		Me.lblTransportadora.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTransportadora.ForeColor = System.Drawing.Color.Black
		Me.lblTransportadora.Location = New System.Drawing.Point(760, 66)
		Me.lblTransportadora.Name = "lblTransportadora"
		Me.lblTransportadora.Size = New System.Drawing.Size(413, 26)
		Me.lblTransportadora.TabIndex = 8
		Me.lblTransportadora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblTranspCNPJ
		'
		Me.lblTranspCNPJ.BackColor = System.Drawing.Color.White
		Me.lblTranspCNPJ.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTranspCNPJ.ForeColor = System.Drawing.Color.Black
		Me.lblTranspCNPJ.Location = New System.Drawing.Point(760, 100)
		Me.lblTranspCNPJ.Name = "lblTranspCNPJ"
		Me.lblTranspCNPJ.Size = New System.Drawing.Size(413, 28)
		Me.lblTranspCNPJ.TabIndex = 10
		Me.lblTranspCNPJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.ForeColor = System.Drawing.Color.Black
		Me.Label6.Location = New System.Drawing.Point(714, 104)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(40, 19)
		Me.Label6.TabIndex = 9
		Me.Label6.Text = "CNPJ"
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
		Me.btnClose.Location = New System.Drawing.Point(1159, 12)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RibbonStyle = False
		Me.btnClose.RoundedCornersMask = CType(15, Byte)
		Me.btnClose.ShowFocusRectangle = False
		Me.btnClose.Size = New System.Drawing.Size(20, 20)
		Me.btnClose.TabIndex = 0
		Me.btnClose.TabStop = False
		Me.btnClose.UseVisualStyleBackColor = False
		Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
		'
		'lblSelectInfo
		'
		Me.lblSelectInfo.AutoSize = True
		Me.lblSelectInfo.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSelectInfo.Location = New System.Drawing.Point(689, 608)
		Me.lblSelectInfo.Name = "lblSelectInfo"
		Me.lblSelectInfo.Size = New System.Drawing.Size(181, 26)
		Me.lblSelectInfo.TabIndex = 17
		Me.lblSelectInfo.Text = "Selecionado: 1 Item"
		Me.lblSelectInfo.Visible = False
		'
		'tspMenuFornecedor
		'
		Me.tspMenuFornecedor.BackColor = System.Drawing.Color.White
		Me.tspMenuFornecedor.Dock = System.Windows.Forms.DockStyle.None
		Me.tspMenuFornecedor.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tspMenuFornecedor.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.tspMenuFornecedor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMenuFornecedor})
		Me.tspMenuFornecedor.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
		Me.tspMenuFornecedor.Location = New System.Drawing.Point(476, 102)
		Me.tspMenuFornecedor.Name = "tspMenuFornecedor"
		Me.tspMenuFornecedor.Size = New System.Drawing.Size(145, 28)
		Me.tspMenuFornecedor.TabIndex = 18
		Me.tspMenuFornecedor.Tag = "Clique aqui para definir um Fornecedor"
		Me.tspMenuFornecedor.Text = "Menu Fornecedor"
		'
		'btnMenuFornecedor
		'
		Me.btnMenuFornecedor.BackColor = System.Drawing.Color.White
		Me.btnMenuFornecedor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnInserirFornecedor, Me.btnVincularCNPJFornecedor})
		Me.btnMenuFornecedor.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnMenuFornecedor.ForeColor = System.Drawing.Color.Maroon
		Me.btnMenuFornecedor.Image = Global.NovaSiao.My.Resources.Resources.delete
		Me.btnMenuFornecedor.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnMenuFornecedor.Name = "btnMenuFornecedor"
		Me.btnMenuFornecedor.Size = New System.Drawing.Size(143, 23)
		Me.btnMenuFornecedor.Text = "Não Encontrado"
		Me.btnMenuFornecedor.ToolTipText = "Fornecedor não Encontrado"
		'
		'btnInserirFornecedor
		'
		Me.btnInserirFornecedor.Image = Global.NovaSiao.My.Resources.Resources.add_32x32
		Me.btnInserirFornecedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnInserirFornecedor.Name = "btnInserirFornecedor"
		Me.btnInserirFornecedor.Size = New System.Drawing.Size(353, 38)
		Me.btnInserirFornecedor.Text = "Inserir um Novo Fornecedor"
		'
		'btnVincularCNPJFornecedor
		'
		Me.btnVincularCNPJFornecedor.Image = Global.NovaSiao.My.Resources.Resources.refresh1
		Me.btnVincularCNPJFornecedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnVincularCNPJFornecedor.Name = "btnVincularCNPJFornecedor"
		Me.btnVincularCNPJFornecedor.Size = New System.Drawing.Size(353, 38)
		Me.btnVincularCNPJFornecedor.Text = "Vincular CNPJ com Fornecedor existente"
		'
		'tspMenuTransp
		'
		Me.tspMenuTransp.BackColor = System.Drawing.Color.White
		Me.tspMenuTransp.Dock = System.Windows.Forms.DockStyle.None
		Me.tspMenuTransp.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tspMenuTransp.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.tspMenuTransp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMenuTransp})
		Me.tspMenuTransp.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
		Me.tspMenuTransp.Location = New System.Drawing.Point(1028, 101)
		Me.tspMenuTransp.Name = "tspMenuTransp"
		Me.tspMenuTransp.Size = New System.Drawing.Size(145, 28)
		Me.tspMenuTransp.TabIndex = 19
		Me.tspMenuTransp.Tag = "Clique aqui para definir uma Transportadora"
		Me.tspMenuTransp.Text = "Menu Transportadora"
		'
		'btnMenuTransp
		'
		Me.btnMenuTransp.BackColor = System.Drawing.Color.White
		Me.btnMenuTransp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnInserirTransportadora, Me.btnVincularCNPJTransp})
		Me.btnMenuTransp.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnMenuTransp.ForeColor = System.Drawing.Color.Maroon
		Me.btnMenuTransp.Image = Global.NovaSiao.My.Resources.Resources.delete
		Me.btnMenuTransp.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnMenuTransp.Name = "btnMenuTransp"
		Me.btnMenuTransp.Size = New System.Drawing.Size(143, 23)
		Me.btnMenuTransp.Text = "Não Encontrada"
		Me.btnMenuTransp.ToolTipText = "Transportadora não Encontrada"
		'
		'btnInserirTransportadora
		'
		Me.btnInserirTransportadora.Image = Global.NovaSiao.My.Resources.Resources.add_32x32
		Me.btnInserirTransportadora.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnInserirTransportadora.Name = "btnInserirTransportadora"
		Me.btnInserirTransportadora.Size = New System.Drawing.Size(379, 38)
		Me.btnInserirTransportadora.Text = "Inserir uma Nova Transportadora"
		'
		'btnVincularCNPJTransp
		'
		Me.btnVincularCNPJTransp.Image = Global.NovaSiao.My.Resources.Resources.refresh1
		Me.btnVincularCNPJTransp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnVincularCNPJTransp.Name = "btnVincularCNPJTransp"
		Me.btnVincularCNPJTransp.Size = New System.Drawing.Size(379, 38)
		Me.btnVincularCNPJTransp.Text = "Vincular CNPJ com Transportadora existente"
		'
		'frmCompraGetNFe
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1191, 656)
		Me.Controls.Add(Me.tspMenuTransp)
		Me.Controls.Add(Me.tspMenuFornecedor)
		Me.Controls.Add(Me.lblSelectInfo)
		Me.Controls.Add(Me.dgvItens)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.lblTranspCNPJ)
		Me.Controls.Add(Me.lblCNPJ)
		Me.Controls.Add(Me.lblTransportadora)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.lblRazaoSocial)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.btnFechar)
		Me.Controls.Add(Me.btnSalvarCompra)
		Me.Controls.Add(Me.btnCorrelacao)
		Me.Controls.Add(Me.btnImportar)
		Me.Name = "frmCompraGetNFe"
		Me.Controls.SetChildIndex(Me.btnImportar, 0)
		Me.Controls.SetChildIndex(Me.btnCorrelacao, 0)
		Me.Controls.SetChildIndex(Me.btnSalvarCompra, 0)
		Me.Controls.SetChildIndex(Me.btnFechar, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.lblRazaoSocial, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.lblTransportadora, 0)
		Me.Controls.SetChildIndex(Me.lblCNPJ, 0)
		Me.Controls.SetChildIndex(Me.lblTranspCNPJ, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.Label6, 0)
		Me.Controls.SetChildIndex(Me.dgvItens, 0)
		Me.Controls.SetChildIndex(Me.lblSelectInfo, 0)
		Me.Controls.SetChildIndex(Me.tspMenuFornecedor, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.tspMenuTransp, 0)
		Me.Panel1.ResumeLayout(False)
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
		Me.mnuItens.ResumeLayout(False)
		Me.tspMenuFornecedor.ResumeLayout(False)
		Me.tspMenuFornecedor.PerformLayout()
		Me.tspMenuTransp.ResumeLayout(False)
		Me.tspMenuTransp.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnImportar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents btnCorrelacao As Button
    Friend WithEvents lblRazaoSocial As Label
    Friend WithEvents lblCNPJ As Label
    Friend WithEvents mnuItens As ContextMenuStrip
    Friend WithEvents miAnexarProduto As ToolStripMenuItem
    Friend WithEvents miAbrirProduto As ToolStripMenuItem
    Friend WithEvents miNovoProduto As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miObterProdutoDBAnterior As ToolStripMenuItem
    Friend WithEvents btnSalvarCompra As Button
    Friend WithEvents clnIDProdutoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnProdutoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidadeNFe As DataGridViewTextBoxColumn
    Friend WithEvents clnPrecoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnDescontoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnTotalNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTransportadora As Label
    Friend WithEvents lblTranspCNPJ As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents lblSelectInfo As Label
    Friend WithEvents tspMenuFornecedor As ToolStrip
    Friend WithEvents btnMenuFornecedor As ToolStripSplitButton
    Friend WithEvents btnInserirFornecedor As ToolStripMenuItem
    Friend WithEvents btnVincularCNPJFornecedor As ToolStripMenuItem
    Friend WithEvents tspMenuTransp As ToolStrip
    Friend WithEvents btnMenuTransp As ToolStripSplitButton
    Friend WithEvents btnInserirTransportadora As ToolStripMenuItem
    Friend WithEvents btnVincularCNPJTransp As ToolStripMenuItem
End Class
