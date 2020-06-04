<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsignacao
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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.tabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
		Me.vtabProdutos = New VIBlend.WinForms.Controls.vTabPage()
		Me.dgvItensConsignacao = New System.Windows.Forms.DataGridView()
		Me.clnIDTransacaoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnICMS = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnST = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnMVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnIPI = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.vtabFrete = New VIBlend.WinForms.Controls.vTabPage()
		Me.btnTransportadoraAdd = New System.Windows.Forms.Button()
		Me.txtObservacaoConsig = New System.Windows.Forms.TextBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtVolumesConsig = New Controles.Text_SoNumeros()
		Me.txtFreteValorConsig = New Controles.Text_Monetario()
		Me.cmbIDTransportadoraConsig = New Controles.ComboBox_OnlyValues()
		Me.cmbFreteTipoConsig = New Controles.ComboBox_OnlyValues()
		Me.vtabCompra = New VIBlend.WinForms.Controls.vTabPage()
		Me.btnCompraData = New VIBlend.WinForms.Controls.vArrowButton()
		Me.lblCompraData = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.lblTotalProdutosComprados = New System.Windows.Forms.Label()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.dgvItensComprados = New System.Windows.Forms.DataGridView()
		Me.clnRGProdutoCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnProdutoCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnQuantidadeCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnPrecoCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnDescontroCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnTotalCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.VButton2 = New VIBlend.WinForms.Controls.vButton()
		Me.vtabAPagar = New VIBlend.WinForms.Controls.vTabPage()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.lblTotalProdutosConsig = New System.Windows.Forms.Label()
		Me.Label36 = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtDescontos = New Controles.Text_Monetario()
		Me.txtICMSValor = New Controles.Text_Monetario()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtDespesas = New Controles.Text_Monetario()
		Me.txtFreteCobrado = New Controles.Text_Monetario()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.lblTotalAPagar = New System.Windows.Forms.Label()
		Me.Label35 = New System.Windows.Forms.Label()
		Me.lblTotalComprado = New System.Windows.Forms.Label()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.dgvAPagar = New System.Windows.Forms.DataGridView()
		Me.clnCobrancaForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnIdentificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnAPagarValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.lblTotalCobrado = New System.Windows.Forms.Label()
		Me.Label26 = New System.Windows.Forms.Label()
		Me.Label28 = New System.Windows.Forms.Label()
		Me.lblCobrancaTipo = New System.Windows.Forms.Label()
		Me.vtabDevolucao = New VIBlend.WinForms.Controls.vTabPage()
		Me.btnDevolucaoData = New VIBlend.WinForms.Controls.vArrowButton()
		Me.Label38 = New System.Windows.Forms.Label()
		Me.Label39 = New System.Windows.Forms.Label()
		Me.btnGerarConsignacao = New VIBlend.WinForms.Controls.vButton()
		Me.lblTotalProdutosDev = New System.Windows.Forms.Label()
		Me.Label37 = New System.Windows.Forms.Label()
		Me.dgvDevolucao = New System.Windows.Forms.DataGridView()
		Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.vtabFreteDevolucao = New VIBlend.WinForms.Controls.vTabPage()
		Me.btnTransportadoraAddDev = New System.Windows.Forms.Button()
		Me.txtObservacaoDev = New System.Windows.Forms.TextBox()
		Me.Label29 = New System.Windows.Forms.Label()
		Me.Label30 = New System.Windows.Forms.Label()
		Me.Label31 = New System.Windows.Forms.Label()
		Me.Label32 = New System.Windows.Forms.Label()
		Me.Label33 = New System.Windows.Forms.Label()
		Me.Label34 = New System.Windows.Forms.Label()
		Me.txtVolumesDev = New Controles.Text_SoNumeros()
		Me.txtFreteValorDev = New Controles.Text_Monetario()
		Me.cmbIDTransportadoraDev = New Controles.ComboBox_OnlyValues()
		Me.cmbFreteTipoDev = New Controles.ComboBox_OnlyValues()
		Me.vtabNotas = New VIBlend.WinForms.Controls.vTabPage()
		Me.dgvNotas = New System.Windows.Forms.DataGridView()
		Me.clnChaveAcesso = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnEmissaoData = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlNota = New System.Windows.Forms.Panel()
		Me.txtChaveAcesso = New System.Windows.Forms.TextBox()
		Me.btnNotaCancel = New System.Windows.Forms.Button()
		Me.btnNotaOK = New System.Windows.Forms.Button()
		Me.lblNota = New System.Windows.Forms.Label()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.Label24 = New System.Windows.Forms.Label()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.txtNotaValor = New Controles.Text_Monetario()
		Me.txtEmissaoData = New Controles.MaskText_Data()
		Me.txtNotaNumero = New Controles.Text_SoNumeros()
		Me.txtNotaSerie = New Controles.Text_SoNumeros()
		Me.cmbNotaTipo = New Controles.ComboBox_OnlyValues()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.lblCli = New System.Windows.Forms.Label()
		Me.lblFornecedor = New System.Windows.Forms.Label()
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lbl_IdTexto = New System.Windows.Forms.Label()
		Me.lblConsignacaoData = New System.Windows.Forms.Label()
		Me.lblIDConsignacao = New System.Windows.Forms.Label()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.lblTotalConsignacao = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.lblSituacao = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.VApplicationMenuItem2 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
		Me.VApplicationMenuItem3 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
		Me.VApplicationMenuItem4 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
		Me.btnFinalizar = New VIBlend.WinForms.Controls.vButton()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.lblFilial = New System.Windows.Forms.Label()
		Me.cmsMenuAPagar = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.miInserir = New System.Windows.Forms.ToolStripMenuItem()
		Me.miEditar = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.miExcluir = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuAcao = New System.Windows.Forms.ToolStrip()
		Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
		Me.btnAdicionar = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnImprimir = New System.Windows.Forms.ToolStripSplitButton()
		Me.miImprimirEtiquetas = New System.Windows.Forms.ToolStripMenuItem()
		Me.miImprimirRelatorio = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnConsignacaoData = New VIBlend.WinForms.Controls.vArrowButton()
		Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ShapeContainer4 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.Panel1.SuspendLayout()
		Me.tabPrincipal.SuspendLayout()
		Me.vtabProdutos.SuspendLayout()
		CType(Me.dgvItensConsignacao, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtabFrete.SuspendLayout()
		Me.vtabCompra.SuspendLayout()
		CType(Me.dgvItensComprados, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtabAPagar.SuspendLayout()
		CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtabDevolucao.SuspendLayout()
		CType(Me.dgvDevolucao, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtabFreteDevolucao.SuspendLayout()
		Me.vtabNotas.SuspendLayout()
		CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlNota.SuspendLayout()
		Me.cmsMenuAPagar.SuspendLayout()
		Me.mnuAcao.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnConsignacaoData)
		Me.Panel1.Controls.Add(Me.Label18)
		Me.Panel1.Controls.Add(Me.lblFilial)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.Controls.Add(Me.Label15)
		Me.Panel1.Controls.Add(Me.lbl_IdTexto)
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Controls.Add(Me.lblSituacao)
		Me.Panel1.Controls.Add(Me.lblIDConsignacao)
		Me.Panel1.Controls.Add(Me.lblConsignacaoData)
		Me.Panel1.Size = New System.Drawing.Size(1200, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblConsignacaoData, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblIDConsignacao, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label15, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label3, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnConsignacaoData, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.Location = New System.Drawing.Point(838, 0)
		Me.lblTitulo.Size = New System.Drawing.Size(362, 50)
		Me.lblTitulo.Text = "Operação de Consignação"
		'
		'tabPrincipal
		'
		Me.tabPrincipal.AllowAnimations = True
		Me.tabPrincipal.AllPagesHeight = 28
		Me.tabPrincipal.Controls.Add(Me.vtabProdutos)
		Me.tabPrincipal.Controls.Add(Me.vtabFrete)
		Me.tabPrincipal.Controls.Add(Me.vtabCompra)
		Me.tabPrincipal.Controls.Add(Me.vtabAPagar)
		Me.tabPrincipal.Controls.Add(Me.vtabDevolucao)
		Me.tabPrincipal.Controls.Add(Me.vtabFreteDevolucao)
		Me.tabPrincipal.Controls.Add(Me.vtabNotas)
		Me.tabPrincipal.ForeColor = System.Drawing.Color.Black
		Me.tabPrincipal.Location = New System.Drawing.Point(9, 106)
		Me.tabPrincipal.Name = "tabPrincipal"
		Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 38, 0, 0)
		Me.tabPrincipal.Size = New System.Drawing.Size(1180, 500)
		Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
		Me.tabPrincipal.TabIndex = 3
		Me.tabPrincipal.TabPages.Add(Me.vtabProdutos)
		Me.tabPrincipal.TabPages.Add(Me.vtabFrete)
		Me.tabPrincipal.TabPages.Add(Me.vtabCompra)
		Me.tabPrincipal.TabPages.Add(Me.vtabAPagar)
		Me.tabPrincipal.TabPages.Add(Me.vtabDevolucao)
		Me.tabPrincipal.TabPages.Add(Me.vtabFreteDevolucao)
		Me.tabPrincipal.TabPages.Add(Me.vtabNotas)
		Me.tabPrincipal.TabsAreaBackColor = System.Drawing.Color.OldLace
		Me.tabPrincipal.TabsInitialOffset = 40
		Me.tabPrincipal.TabsShape = VIBlend.WinForms.Controls.TabsShape.Chrome
		Me.tabPrincipal.TabsSpacing = 10
		Me.tabPrincipal.TitleHeight = 38
		Me.tabPrincipal.UseTabsAreaBackColor = True
		Me.tabPrincipal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		'
		'vtabProdutos
		'
		Me.vtabProdutos.Controls.Add(Me.dgvItensConsignacao)
		Me.vtabProdutos.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabProdutos.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabProdutos.ForeColor = System.Drawing.Color.Black
		Me.vtabProdutos.Location = New System.Drawing.Point(0, 38)
		Me.vtabProdutos.Name = "vtabProdutos"
		Me.vtabProdutos.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabProdutos.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabProdutos.Size = New System.Drawing.Size(1180, 462)
		Me.vtabProdutos.TabIndex = 0
		Me.vtabProdutos.Text = "Produtos Consignados"
		Me.vtabProdutos.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabProdutos.TooltipText = "TabPage"
		Me.vtabProdutos.UseDefaultTextFont = False
		Me.vtabProdutos.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabProdutos.Visible = False
		'
		'dgvItensConsignacao
		'
		Me.dgvItensConsignacao.AllowUserToAddRows = False
		Me.dgvItensConsignacao.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
		Me.dgvItensConsignacao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvItensConsignacao.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvItensConsignacao.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvItensConsignacao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvItensConsignacao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItensConsignacao.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.dgvItensConsignacao.ColumnHeadersHeight = 25
		Me.dgvItensConsignacao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDTransacaoItem, Me.clnRGProduto, Me.clnProduto, Me.clnQuantidade, Me.clnPreco, Me.clnSubTotal, Me.clnDesconto, Me.clnTotal, Me.clnICMS, Me.clnST, Me.clnMVA, Me.clnIPI})
		Me.dgvItensConsignacao.EnableHeadersVisualStyles = False
		Me.dgvItensConsignacao.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvItensConsignacao.Location = New System.Drawing.Point(9, 9)
		Me.dgvItensConsignacao.Name = "dgvItensConsignacao"
		Me.dgvItensConsignacao.ReadOnly = True
		Me.dgvItensConsignacao.RowHeadersWidth = 30
		Me.dgvItensConsignacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvItensConsignacao.Size = New System.Drawing.Size(1162, 444)
		Me.dgvItensConsignacao.TabIndex = 0
		'
		'clnIDTransacaoItem
		'
		Me.clnIDTransacaoItem.Frozen = True
		Me.clnIDTransacaoItem.HeaderText = "IDItem"
		Me.clnIDTransacaoItem.Name = "clnIDTransacaoItem"
		Me.clnIDTransacaoItem.ReadOnly = True
		Me.clnIDTransacaoItem.Visible = False
		'
		'clnRGProduto
		'
		Me.clnRGProduto.Frozen = True
		Me.clnRGProduto.HeaderText = "Reg."
		Me.clnRGProduto.Name = "clnRGProduto"
		Me.clnRGProduto.ReadOnly = True
		Me.clnRGProduto.Width = 60
		'
		'clnProduto
		'
		Me.clnProduto.Frozen = True
		Me.clnProduto.HeaderText = "Produto"
		Me.clnProduto.Name = "clnProduto"
		Me.clnProduto.ReadOnly = True
		Me.clnProduto.Width = 375
		'
		'clnQuantidade
		'
		Me.clnQuantidade.Frozen = True
		Me.clnQuantidade.HeaderText = "Qtde"
		Me.clnQuantidade.Name = "clnQuantidade"
		Me.clnQuantidade.ReadOnly = True
		Me.clnQuantidade.Width = 60
		'
		'clnPreco
		'
		Me.clnPreco.Frozen = True
		Me.clnPreco.HeaderText = "Preço"
		Me.clnPreco.Name = "clnPreco"
		Me.clnPreco.ReadOnly = True
		Me.clnPreco.Width = 90
		'
		'clnSubTotal
		'
		Me.clnSubTotal.Frozen = True
		Me.clnSubTotal.HeaderText = "SubTotal"
		Me.clnSubTotal.Name = "clnSubTotal"
		Me.clnSubTotal.ReadOnly = True
		Me.clnSubTotal.Width = 90
		'
		'clnDesconto
		'
		Me.clnDesconto.HeaderText = "Desc."
		Me.clnDesconto.Name = "clnDesconto"
		Me.clnDesconto.ReadOnly = True
		Me.clnDesconto.Width = 80
		'
		'clnTotal
		'
		Me.clnTotal.HeaderText = "Total"
		Me.clnTotal.Name = "clnTotal"
		Me.clnTotal.ReadOnly = True
		Me.clnTotal.Width = 90
		'
		'clnICMS
		'
		Me.clnICMS.HeaderText = "ICMS"
		Me.clnICMS.Name = "clnICMS"
		Me.clnICMS.ReadOnly = True
		Me.clnICMS.Width = 60
		'
		'clnST
		'
		Me.clnST.HeaderText = "ST"
		Me.clnST.Name = "clnST"
		Me.clnST.ReadOnly = True
		Me.clnST.Width = 75
		'
		'clnMVA
		'
		Me.clnMVA.HeaderText = "MVA"
		Me.clnMVA.Name = "clnMVA"
		Me.clnMVA.ReadOnly = True
		Me.clnMVA.Width = 60
		'
		'clnIPI
		'
		Me.clnIPI.HeaderText = "IPI%"
		Me.clnIPI.Name = "clnIPI"
		Me.clnIPI.ReadOnly = True
		Me.clnIPI.Width = 60
		'
		'vtabFrete
		'
		Me.vtabFrete.Controls.Add(Me.btnTransportadoraAdd)
		Me.vtabFrete.Controls.Add(Me.txtObservacaoConsig)
		Me.vtabFrete.Controls.Add(Me.Label12)
		Me.vtabFrete.Controls.Add(Me.Label14)
		Me.vtabFrete.Controls.Add(Me.Label10)
		Me.vtabFrete.Controls.Add(Me.Label9)
		Me.vtabFrete.Controls.Add(Me.Label8)
		Me.vtabFrete.Controls.Add(Me.Label7)
		Me.vtabFrete.Controls.Add(Me.txtVolumesConsig)
		Me.vtabFrete.Controls.Add(Me.txtFreteValorConsig)
		Me.vtabFrete.Controls.Add(Me.cmbIDTransportadoraConsig)
		Me.vtabFrete.Controls.Add(Me.cmbFreteTipoConsig)
		Me.vtabFrete.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabFrete.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFrete.Location = New System.Drawing.Point(0, 38)
		Me.vtabFrete.Name = "vtabFrete"
		Me.vtabFrete.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabFrete.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFrete.Size = New System.Drawing.Size(1180, 462)
		Me.vtabFrete.TabIndex = 0
		Me.vtabFrete.Text = "Frete de Entrada"
		Me.vtabFrete.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFrete.TooltipText = "TabPage"
		Me.vtabFrete.UseDefaultTextFont = False
		Me.vtabFrete.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabFrete.Visible = False
		'
		'btnTransportadoraAdd
		'
		Me.btnTransportadoraAdd.FlatAppearance.BorderSize = 0
		Me.btnTransportadoraAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnTransportadoraAdd.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnTransportadoraAdd.Location = New System.Drawing.Point(441, 85)
		Me.btnTransportadoraAdd.Name = "btnTransportadoraAdd"
		Me.btnTransportadoraAdd.Size = New System.Drawing.Size(28, 27)
		Me.btnTransportadoraAdd.TabIndex = 14
		Me.btnTransportadoraAdd.TabStop = False
		Me.btnTransportadoraAdd.UseVisualStyleBackColor = True
		'
		'txtObservacaoConsig
		'
		Me.txtObservacaoConsig.Location = New System.Drawing.Point(38, 228)
		Me.txtObservacaoConsig.Multiline = True
		Me.txtObservacaoConsig.Name = "txtObservacaoConsig"
		Me.txtObservacaoConsig.Size = New System.Drawing.Size(431, 109)
		Me.txtObservacaoConsig.TabIndex = 20
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.ForeColor = System.Drawing.Color.SlateGray
		Me.Label12.Location = New System.Drawing.Point(18, 189)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(239, 26)
		Me.Label12.TabIndex = 19
		Me.Label12.Text = "Observações Importantes:"
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.BackColor = System.Drawing.Color.Transparent
		Me.Label14.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.ForeColor = System.Drawing.Color.SlateGray
		Me.Label14.Location = New System.Drawing.Point(18, 14)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(300, 26)
		Me.Label14.TabIndex = 9
		Me.Label14.Text = "Frete da Entrada de Consignação:"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Location = New System.Drawing.Point(262, 122)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(64, 19)
		Me.Label10.TabIndex = 17
		Me.Label10.Text = "Volumes"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Location = New System.Drawing.Point(42, 122)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(99, 19)
		Me.Label9.TabIndex = 15
		Me.Label9.Text = "Valor do Frete"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Location = New System.Drawing.Point(34, 89)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(107, 19)
		Me.Label8.TabIndex = 12
		Me.Label8.Text = "Transportadora"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Location = New System.Drawing.Point(47, 56)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(94, 19)
		Me.Label7.TabIndex = 10
		Me.Label7.Text = "Tipo de Frete"
		'
		'txtVolumesConsig
		'
		Me.txtVolumesConsig.Inteiro = True
		Me.txtVolumesConsig.Location = New System.Drawing.Point(332, 119)
		Me.txtVolumesConsig.Name = "txtVolumesConsig"
		Me.txtVolumesConsig.Size = New System.Drawing.Size(49, 27)
		Me.txtVolumesConsig.TabIndex = 18
		Me.txtVolumesConsig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtFreteValorConsig
		'
		Me.txtFreteValorConsig.Location = New System.Drawing.Point(147, 119)
		Me.txtFreteValorConsig.Name = "txtFreteValorConsig"
		Me.txtFreteValorConsig.Size = New System.Drawing.Size(100, 27)
		Me.txtFreteValorConsig.SomentePositivos = True
		Me.txtFreteValorConsig.TabIndex = 16
		Me.txtFreteValorConsig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'cmbIDTransportadoraConsig
		'
		Me.cmbIDTransportadoraConsig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbIDTransportadoraConsig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbIDTransportadoraConsig.FormattingEnabled = True
		Me.cmbIDTransportadoraConsig.Location = New System.Drawing.Point(147, 86)
		Me.cmbIDTransportadoraConsig.Name = "cmbIDTransportadoraConsig"
		Me.cmbIDTransportadoraConsig.RestrictContentToListItems = True
		Me.cmbIDTransportadoraConsig.Size = New System.Drawing.Size(288, 27)
		Me.cmbIDTransportadoraConsig.TabIndex = 13
		'
		'cmbFreteTipoConsig
		'
		Me.cmbFreteTipoConsig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbFreteTipoConsig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbFreteTipoConsig.FormattingEnabled = True
		Me.cmbFreteTipoConsig.Location = New System.Drawing.Point(147, 53)
		Me.cmbFreteTipoConsig.Name = "cmbFreteTipoConsig"
		Me.cmbFreteTipoConsig.RestrictContentToListItems = True
		Me.cmbFreteTipoConsig.Size = New System.Drawing.Size(149, 27)
		Me.cmbFreteTipoConsig.TabIndex = 11
		'
		'vtabCompra
		'
		Me.vtabCompra.Controls.Add(Me.btnCompraData)
		Me.vtabCompra.Controls.Add(Me.lblCompraData)
		Me.vtabCompra.Controls.Add(Me.Label6)
		Me.vtabCompra.Controls.Add(Me.lblTotalProdutosComprados)
		Me.vtabCompra.Controls.Add(Me.Label27)
		Me.vtabCompra.Controls.Add(Me.dgvItensComprados)
		Me.vtabCompra.Controls.Add(Me.VButton2)
		Me.vtabCompra.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabCompra.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabCompra.Location = New System.Drawing.Point(0, 38)
		Me.vtabCompra.Name = "vtabCompra"
		Me.vtabCompra.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabCompra.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabCompra.Size = New System.Drawing.Size(1180, 462)
		Me.vtabCompra.TabIndex = 2
		Me.vtabCompra.Text = "Produtos Comprados"
		Me.vtabCompra.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabCompra.TooltipText = "TabPage"
		Me.vtabCompra.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabCompra.Visible = False
		'
		'btnCompraData
		'
		Me.btnCompraData.AllowAnimations = True
		Me.btnCompraData.ArrowDirection = System.Windows.Forms.ArrowDirection.Right
		Me.btnCompraData.Location = New System.Drawing.Point(957, 304)
		Me.btnCompraData.Maximum = 100
		Me.btnCompraData.Minimum = 0
		Me.btnCompraData.Name = "btnCompraData"
		Me.btnCompraData.Size = New System.Drawing.Size(16, 16)
		Me.btnCompraData.TabIndex = 57
		Me.btnCompraData.TabStop = False
		Me.btnCompraData.Value = 0
		Me.btnCompraData.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'lblCompraData
		'
		Me.lblCompraData.BackColor = System.Drawing.Color.Transparent
		Me.lblCompraData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCompraData.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCompraData.Location = New System.Drawing.Point(977, 296)
		Me.lblCompraData.Margin = New System.Windows.Forms.Padding(0)
		Me.lblCompraData.Name = "lblCompraData"
		Me.lblCompraData.Size = New System.Drawing.Size(183, 32)
		Me.lblCompraData.TabIndex = 24
		Me.lblCompraData.Text = "00/00/0000"
		Me.lblCompraData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Location = New System.Drawing.Point(1042, 277)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(118, 19)
		Me.Label6.TabIndex = 23
		Me.Label6.Text = "Data da Compra:"
		'
		'lblTotalProdutosComprados
		'
		Me.lblTotalProdutosComprados.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalProdutosComprados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalProdutosComprados.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalProdutosComprados.Location = New System.Drawing.Point(977, 359)
		Me.lblTotalProdutosComprados.Margin = New System.Windows.Forms.Padding(0)
		Me.lblTotalProdutosComprados.Name = "lblTotalProdutosComprados"
		Me.lblTotalProdutosComprados.Size = New System.Drawing.Size(183, 32)
		Me.lblTotalProdutosComprados.TabIndex = 24
		Me.lblTotalProdutosComprados.Text = "R$ 0,00"
		Me.lblTotalProdutosComprados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label27
		'
		Me.Label27.AutoSize = True
		Me.Label27.BackColor = System.Drawing.Color.Transparent
		Me.Label27.Location = New System.Drawing.Point(1013, 340)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(147, 19)
		Me.Label27.TabIndex = 23
		Me.Label27.Text = "Produtos Comprados:"
		'
		'dgvItensComprados
		'
		Me.dgvItensComprados.AllowUserToAddRows = False
		Me.dgvItensComprados.AllowUserToDeleteRows = False
		DataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure
		Me.dgvItensComprados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
		Me.dgvItensComprados.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvItensComprados.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvItensComprados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvItensComprados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItensComprados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
		Me.dgvItensComprados.ColumnHeadersHeight = 25
		Me.dgvItensComprados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnRGProdutoCompra, Me.clnProdutoCompra, Me.clnQuantidadeCompra, Me.clnPrecoCompra, Me.clnDescontroCompra, Me.clnTotalCompra})
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue
		DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
		DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvItensComprados.DefaultCellStyle = DataGridViewCellStyle5
		Me.dgvItensComprados.EnableHeadersVisualStyles = False
		Me.dgvItensComprados.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvItensComprados.Location = New System.Drawing.Point(9, 9)
		Me.dgvItensComprados.Margin = New System.Windows.Forms.Padding(10)
		Me.dgvItensComprados.Name = "dgvItensComprados"
		Me.dgvItensComprados.ReadOnly = True
		DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
		DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItensComprados.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
		Me.dgvItensComprados.RowHeadersWidth = 30
		Me.dgvItensComprados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvItensComprados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvItensComprados.Size = New System.Drawing.Size(825, 439)
		Me.dgvItensComprados.TabIndex = 5
		'
		'clnRGProdutoCompra
		'
		Me.clnRGProdutoCompra.HeaderText = "Reg."
		Me.clnRGProdutoCompra.Name = "clnRGProdutoCompra"
		Me.clnRGProdutoCompra.ReadOnly = True
		Me.clnRGProdutoCompra.Width = 60
		'
		'clnProdutoCompra
		'
		Me.clnProdutoCompra.HeaderText = "Produto"
		Me.clnProdutoCompra.Name = "clnProdutoCompra"
		Me.clnProdutoCompra.ReadOnly = True
		Me.clnProdutoCompra.Width = 375
		'
		'clnQuantidadeCompra
		'
		Me.clnQuantidadeCompra.HeaderText = "Qtde"
		Me.clnQuantidadeCompra.Name = "clnQuantidadeCompra"
		Me.clnQuantidadeCompra.ReadOnly = True
		Me.clnQuantidadeCompra.Width = 60
		'
		'clnPrecoCompra
		'
		Me.clnPrecoCompra.HeaderText = "Preço"
		Me.clnPrecoCompra.Name = "clnPrecoCompra"
		Me.clnPrecoCompra.ReadOnly = True
		Me.clnPrecoCompra.Width = 90
		'
		'clnDescontroCompra
		'
		Me.clnDescontroCompra.HeaderText = "Desc."
		Me.clnDescontroCompra.Name = "clnDescontroCompra"
		Me.clnDescontroCompra.ReadOnly = True
		Me.clnDescontroCompra.Width = 70
		'
		'clnTotalCompra
		'
		Me.clnTotalCompra.HeaderText = "Total"
		Me.clnTotalCompra.Name = "clnTotalCompra"
		Me.clnTotalCompra.ReadOnly = True
		'
		'VButton2
		'
		Me.VButton2.AllowAnimations = True
		Me.VButton2.BackColor = System.Drawing.Color.Transparent
		Me.VButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.VButton2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.VButton2.HoverEffectsEnabled = True
		Me.VButton2.Image = Global.NovaSiao.My.Resources.Resources.upload_button
		Me.VButton2.ImageAbsolutePosition = New System.Drawing.Point(20, 5)
		Me.VButton2.Location = New System.Drawing.Point(977, 401)
		Me.VButton2.Name = "VButton2"
		Me.VButton2.Opacity = 0!
		Me.VButton2.RoundedCornersMask = CType(15, Byte)
		Me.VButton2.RoundedCornersRadius = 5
		Me.VButton2.Size = New System.Drawing.Size(183, 42)
		Me.VButton2.TabIndex = 3
		Me.VButton2.Text = "&Gerar Devolução"
		Me.VButton2.TextAbsolutePosition = New System.Drawing.Point(45, 1)
		Me.VButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.VButton2.UseAbsoluteImagePositioning = True
		Me.VButton2.UseAbsoluteTextPositioning = True
		Me.VButton2.UseVisualStyleBackColor = False
		Me.VButton2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
		'
		'vtabAPagar
		'
		Me.vtabAPagar.Controls.Add(Me.Label20)
		Me.vtabAPagar.Controls.Add(Me.lblTotalProdutosConsig)
		Me.vtabAPagar.Controls.Add(Me.Label36)
		Me.vtabAPagar.Controls.Add(Me.Label19)
		Me.vtabAPagar.Controls.Add(Me.Label2)
		Me.vtabAPagar.Controls.Add(Me.txtDescontos)
		Me.vtabAPagar.Controls.Add(Me.txtICMSValor)
		Me.vtabAPagar.Controls.Add(Me.Label5)
		Me.vtabAPagar.Controls.Add(Me.txtDespesas)
		Me.vtabAPagar.Controls.Add(Me.txtFreteCobrado)
		Me.vtabAPagar.Controls.Add(Me.Label1)
		Me.vtabAPagar.Controls.Add(Me.Label4)
		Me.vtabAPagar.Controls.Add(Me.lblTotalAPagar)
		Me.vtabAPagar.Controls.Add(Me.Label35)
		Me.vtabAPagar.Controls.Add(Me.lblTotalComprado)
		Me.vtabAPagar.Controls.Add(Me.Label17)
		Me.vtabAPagar.Controls.Add(Me.dgvAPagar)
		Me.vtabAPagar.Controls.Add(Me.lblTotalCobrado)
		Me.vtabAPagar.Controls.Add(Me.Label26)
		Me.vtabAPagar.Controls.Add(Me.Label28)
		Me.vtabAPagar.Controls.Add(Me.lblCobrancaTipo)
		Me.vtabAPagar.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabAPagar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabAPagar.Location = New System.Drawing.Point(0, 38)
		Me.vtabAPagar.Name = "vtabAPagar"
		Me.vtabAPagar.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabAPagar.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabAPagar.Size = New System.Drawing.Size(1180, 462)
		Me.vtabAPagar.TabIndex = 0
		Me.vtabAPagar.Text = "Pagamentos"
		Me.vtabAPagar.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabAPagar.TooltipText = "TabPage"
		Me.vtabAPagar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabAPagar.Visible = False
		'
		'Label20
		'
		Me.Label20.AutoSize = True
		Me.Label20.BackColor = System.Drawing.Color.Transparent
		Me.Label20.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label20.ForeColor = System.Drawing.Color.SlateGray
		Me.Label20.Location = New System.Drawing.Point(18, 14)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(269, 26)
		Me.Label20.TabIndex = 0
		Me.Label20.Text = "Outras Despesas | Descontos:"
		'
		'lblTotalProdutosConsig
		'
		Me.lblTotalProdutosConsig.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalProdutosConsig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalProdutosConsig.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalProdutosConsig.Location = New System.Drawing.Point(181, 184)
		Me.lblTotalProdutosConsig.Margin = New System.Windows.Forms.Padding(3)
		Me.lblTotalProdutosConsig.Name = "lblTotalProdutosConsig"
		Me.lblTotalProdutosConsig.Size = New System.Drawing.Size(151, 27)
		Me.lblTotalProdutosConsig.TabIndex = 10
		Me.lblTotalProdutosConsig.Text = "R$ 0,00"
		Me.lblTotalProdutosConsig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label36
		'
		Me.Label36.AutoSize = True
		Me.Label36.BackColor = System.Drawing.Color.Transparent
		Me.Label36.Location = New System.Drawing.Point(45, 188)
		Me.Label36.Name = "Label36"
		Me.Label36.Size = New System.Drawing.Size(130, 19)
		Me.Label36.TabIndex = 9
		Me.Label36.Text = "Valor dos Produtos"
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Location = New System.Drawing.Point(98, 154)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(77, 19)
		Me.Label19.TabIndex = 7
		Me.Label19.Text = "Descontos"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Location = New System.Drawing.Point(75, 88)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 19)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "ICMS Cobrado"
		'
		'txtDescontos
		'
		Me.txtDescontos.Location = New System.Drawing.Point(181, 151)
		Me.txtDescontos.Name = "txtDescontos"
		Me.txtDescontos.Size = New System.Drawing.Size(151, 27)
		Me.txtDescontos.SomentePositivos = True
		Me.txtDescontos.TabIndex = 8
		Me.txtDescontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtICMSValor
		'
		Me.txtICMSValor.Location = New System.Drawing.Point(181, 85)
		Me.txtICMSValor.Name = "txtICMSValor"
		Me.txtICMSValor.Size = New System.Drawing.Size(151, 27)
		Me.txtICMSValor.SomentePositivos = True
		Me.txtICMSValor.TabIndex = 4
		Me.txtICMSValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Location = New System.Drawing.Point(55, 121)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(120, 19)
		Me.Label5.TabIndex = 5
		Me.Label5.Text = "Outras Despesas"
		'
		'txtDespesas
		'
		Me.txtDespesas.Location = New System.Drawing.Point(181, 118)
		Me.txtDespesas.Name = "txtDespesas"
		Me.txtDespesas.Size = New System.Drawing.Size(151, 27)
		Me.txtDespesas.SomentePositivos = True
		Me.txtDespesas.TabIndex = 6
		Me.txtDespesas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtFreteCobrado
		'
		Me.txtFreteCobrado.Location = New System.Drawing.Point(181, 52)
		Me.txtFreteCobrado.Name = "txtFreteCobrado"
		Me.txtFreteCobrado.Size = New System.Drawing.Size(151, 27)
		Me.txtFreteCobrado.SomentePositivos = True
		Me.txtFreteCobrado.TabIndex = 2
		Me.txtFreteCobrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Location = New System.Drawing.Point(75, 55)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 19)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Frete Cobrado"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Location = New System.Drawing.Point(629, 305)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(126, 19)
		Me.Label4.TabIndex = 12
		Me.Label4.Text = "Tipo de Cobrança:"
		'
		'lblTotalAPagar
		'
		Me.lblTotalAPagar.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalAPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalAPagar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalAPagar.Location = New System.Drawing.Point(181, 250)
		Me.lblTotalAPagar.Margin = New System.Windows.Forms.Padding(3)
		Me.lblTotalAPagar.Name = "lblTotalAPagar"
		Me.lblTotalAPagar.Size = New System.Drawing.Size(151, 27)
		Me.lblTotalAPagar.TabIndex = 16
		Me.lblTotalAPagar.Text = "R$ 0,00"
		Me.lblTotalAPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label35
		'
		Me.Label35.AutoSize = True
		Me.Label35.BackColor = System.Drawing.Color.Transparent
		Me.Label35.Location = New System.Drawing.Point(80, 254)
		Me.Label35.Name = "Label35"
		Me.Label35.Size = New System.Drawing.Size(95, 19)
		Me.Label35.TabIndex = 15
		Me.Label35.Text = "Total A Pagar"
		'
		'lblTotalComprado
		'
		Me.lblTotalComprado.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalComprado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalComprado.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalComprado.Location = New System.Drawing.Point(181, 217)
		Me.lblTotalComprado.Margin = New System.Windows.Forms.Padding(3)
		Me.lblTotalComprado.Name = "lblTotalComprado"
		Me.lblTotalComprado.Size = New System.Drawing.Size(151, 27)
		Me.lblTotalComprado.TabIndex = 16
		Me.lblTotalComprado.Text = "R$ 0,00"
		Me.lblTotalComprado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.BackColor = System.Drawing.Color.Transparent
		Me.Label17.Location = New System.Drawing.Point(63, 221)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(112, 19)
		Me.Label17.TabIndex = 15
		Me.Label17.Text = "Valor Comprado"
		'
		'dgvAPagar
		'
		Me.dgvAPagar.AllowUserToAddRows = False
		Me.dgvAPagar.AllowUserToDeleteRows = False
		Me.dgvAPagar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvAPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvAPagar.ColumnHeadersHeight = 30
		Me.dgvAPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnCobrancaForma, Me.clnIdentificador, Me.clnVencimento, Me.clnAPagarValor})
		Me.dgvAPagar.EnableHeadersVisualStyles = False
		Me.dgvAPagar.Location = New System.Drawing.Point(403, 52)
		Me.dgvAPagar.MultiSelect = False
		Me.dgvAPagar.Name = "dgvAPagar"
		Me.dgvAPagar.ReadOnly = True
		Me.dgvAPagar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvAPagar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvAPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvAPagar.Size = New System.Drawing.Size(549, 235)
		Me.dgvAPagar.TabIndex = 18
		'
		'clnCobrancaForma
		'
		Me.clnCobrancaForma.HeaderText = "Forma"
		Me.clnCobrancaForma.Name = "clnCobrancaForma"
		Me.clnCobrancaForma.ReadOnly = True
		Me.clnCobrancaForma.Width = 160
		'
		'clnIdentificador
		'
		Me.clnIdentificador.HeaderText = "No. Reg.:"
		Me.clnIdentificador.Name = "clnIdentificador"
		Me.clnIdentificador.ReadOnly = True
		'
		'clnVencimento
		'
		DataGridViewCellStyle7.Format = "C2"
		DataGridViewCellStyle7.NullValue = "0"
		Me.clnVencimento.DefaultCellStyle = DataGridViewCellStyle7
		Me.clnVencimento.HeaderText = "Vencimento"
		Me.clnVencimento.Name = "clnVencimento"
		Me.clnVencimento.ReadOnly = True
		Me.clnVencimento.Width = 110
		'
		'clnAPagarValor
		'
		Me.clnAPagarValor.HeaderText = "Valor"
		Me.clnAPagarValor.Name = "clnAPagarValor"
		Me.clnAPagarValor.ReadOnly = True
		'
		'lblTotalCobrado
		'
		Me.lblTotalCobrado.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalCobrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalCobrado.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalCobrado.Location = New System.Drawing.Point(761, 344)
		Me.lblTotalCobrado.Name = "lblTotalCobrado"
		Me.lblTotalCobrado.Size = New System.Drawing.Size(151, 32)
		Me.lblTotalCobrado.TabIndex = 14
		Me.lblTotalCobrado.Text = "R$ 0,00"
		Me.lblTotalCobrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label26
		'
		Me.Label26.AutoSize = True
		Me.Label26.BackColor = System.Drawing.Color.Transparent
		Me.Label26.Location = New System.Drawing.Point(652, 349)
		Me.Label26.Name = "Label26"
		Me.Label26.Size = New System.Drawing.Size(103, 19)
		Me.Label26.TabIndex = 13
		Me.Label26.Text = "Total Cobrado:"
		'
		'Label28
		'
		Me.Label28.AutoSize = True
		Me.Label28.BackColor = System.Drawing.Color.Transparent
		Me.Label28.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label28.ForeColor = System.Drawing.Color.SlateGray
		Me.Label28.Location = New System.Drawing.Point(398, 16)
		Me.Label28.Name = "Label28"
		Me.Label28.Size = New System.Drawing.Size(267, 26)
		Me.Label28.TabIndex = 17
		Me.Label28.Text = "Desdobramento das Parcelas:"
		'
		'lblCobrancaTipo
		'
		Me.lblCobrancaTipo.BackColor = System.Drawing.Color.Transparent
		Me.lblCobrancaTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCobrancaTipo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCobrancaTipo.Location = New System.Drawing.Point(761, 301)
		Me.lblCobrancaTipo.Name = "lblCobrancaTipo"
		Me.lblCobrancaTipo.Size = New System.Drawing.Size(151, 32)
		Me.lblCobrancaTipo.TabIndex = 11
		Me.lblCobrancaTipo.Text = "Tipo de Cobrança"
		Me.lblCobrancaTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'vtabDevolucao
		'
		Me.vtabDevolucao.Controls.Add(Me.btnDevolucaoData)
		Me.vtabDevolucao.Controls.Add(Me.Label38)
		Me.vtabDevolucao.Controls.Add(Me.Label39)
		Me.vtabDevolucao.Controls.Add(Me.btnGerarConsignacao)
		Me.vtabDevolucao.Controls.Add(Me.lblTotalProdutosDev)
		Me.vtabDevolucao.Controls.Add(Me.Label37)
		Me.vtabDevolucao.Controls.Add(Me.dgvDevolucao)
		Me.vtabDevolucao.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabDevolucao.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabDevolucao.Location = New System.Drawing.Point(0, 38)
		Me.vtabDevolucao.Name = "vtabDevolucao"
		Me.vtabDevolucao.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabDevolucao.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
		Me.vtabDevolucao.Size = New System.Drawing.Size(1180, 462)
		Me.vtabDevolucao.TabIndex = 4
		Me.vtabDevolucao.Text = "Produtos Devolvidos"
		Me.vtabDevolucao.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabDevolucao.TooltipText = "Devolução de Consignação"
		Me.vtabDevolucao.UseDefaultTextFont = False
		Me.vtabDevolucao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabDevolucao.Visible = False
		'
		'btnDevolucaoData
		'
		Me.btnDevolucaoData.AllowAnimations = True
		Me.btnDevolucaoData.ArrowDirection = System.Windows.Forms.ArrowDirection.Right
		Me.btnDevolucaoData.Location = New System.Drawing.Point(955, 304)
		Me.btnDevolucaoData.Maximum = 100
		Me.btnDevolucaoData.Minimum = 0
		Me.btnDevolucaoData.Name = "btnDevolucaoData"
		Me.btnDevolucaoData.Size = New System.Drawing.Size(16, 16)
		Me.btnDevolucaoData.TabIndex = 60
		Me.btnDevolucaoData.TabStop = False
		Me.btnDevolucaoData.Value = 0
		Me.btnDevolucaoData.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'Label38
		'
		Me.Label38.BackColor = System.Drawing.Color.Transparent
		Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label38.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label38.Location = New System.Drawing.Point(975, 296)
		Me.Label38.Margin = New System.Windows.Forms.Padding(0)
		Me.Label38.Name = "Label38"
		Me.Label38.Size = New System.Drawing.Size(183, 32)
		Me.Label38.TabIndex = 59
		Me.Label38.Text = "00/00/0000"
		Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label39
		'
		Me.Label39.AutoSize = True
		Me.Label39.BackColor = System.Drawing.Color.Transparent
		Me.Label39.Location = New System.Drawing.Point(1022, 277)
		Me.Label39.Name = "Label39"
		Me.Label39.Size = New System.Drawing.Size(136, 19)
		Me.Label39.TabIndex = 58
		Me.Label39.Text = "Data da Devolução:"
		'
		'btnGerarConsignacao
		'
		Me.btnGerarConsignacao.AllowAnimations = True
		Me.btnGerarConsignacao.BackColor = System.Drawing.Color.Transparent
		Me.btnGerarConsignacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnGerarConsignacao.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnGerarConsignacao.HoverEffectsEnabled = True
		Me.btnGerarConsignacao.Image = Global.NovaSiao.My.Resources.Resources.upload_button
		Me.btnGerarConsignacao.ImageAbsolutePosition = New System.Drawing.Point(10, 5)
		Me.btnGerarConsignacao.Location = New System.Drawing.Point(977, 401)
		Me.btnGerarConsignacao.Name = "btnGerarConsignacao"
		Me.btnGerarConsignacao.Opacity = 0!
		Me.btnGerarConsignacao.RoundedCornersMask = CType(15, Byte)
		Me.btnGerarConsignacao.RoundedCornersRadius = 5
		Me.btnGerarConsignacao.Size = New System.Drawing.Size(183, 42)
		Me.btnGerarConsignacao.TabIndex = 27
		Me.btnGerarConsignacao.Text = "&Gerar Consignação"
		Me.btnGerarConsignacao.TextAbsolutePosition = New System.Drawing.Point(45, 1)
		Me.btnGerarConsignacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnGerarConsignacao.UseAbsoluteImagePositioning = True
		Me.btnGerarConsignacao.UseAbsoluteTextPositioning = True
		Me.btnGerarConsignacao.UseVisualStyleBackColor = False
		Me.btnGerarConsignacao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
		'
		'lblTotalProdutosDev
		'
		Me.lblTotalProdutosDev.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalProdutosDev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalProdutosDev.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalProdutosDev.Location = New System.Drawing.Point(977, 359)
		Me.lblTotalProdutosDev.Margin = New System.Windows.Forms.Padding(0)
		Me.lblTotalProdutosDev.Name = "lblTotalProdutosDev"
		Me.lblTotalProdutosDev.Size = New System.Drawing.Size(183, 32)
		Me.lblTotalProdutosDev.TabIndex = 26
		Me.lblTotalProdutosDev.Text = "R$ 0,00"
		Me.lblTotalProdutosDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label37
		'
		Me.Label37.AutoSize = True
		Me.Label37.BackColor = System.Drawing.Color.Transparent
		Me.Label37.Location = New System.Drawing.Point(1013, 340)
		Me.Label37.Name = "Label37"
		Me.Label37.Size = New System.Drawing.Size(145, 19)
		Me.Label37.TabIndex = 25
		Me.Label37.Text = "Produtos Devolvidos:"
		'
		'dgvDevolucao
		'
		Me.dgvDevolucao.AllowUserToAddRows = False
		Me.dgvDevolucao.AllowUserToDeleteRows = False
		DataGridViewCellStyle8.BackColor = System.Drawing.Color.Azure
		Me.dgvDevolucao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
		Me.dgvDevolucao.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvDevolucao.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvDevolucao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvDevolucao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonFace
		DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvDevolucao.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
		Me.dgvDevolucao.ColumnHeadersHeight = 25
		Me.dgvDevolucao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
		Me.dgvDevolucao.EnableHeadersVisualStyles = False
		Me.dgvDevolucao.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvDevolucao.Location = New System.Drawing.Point(9, 9)
		Me.dgvDevolucao.Name = "dgvDevolucao"
		Me.dgvDevolucao.ReadOnly = True
		Me.dgvDevolucao.RowHeadersWidth = 30
		Me.dgvDevolucao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvDevolucao.Size = New System.Drawing.Size(914, 444)
		Me.dgvDevolucao.TabIndex = 1
		'
		'DataGridViewTextBoxColumn1
		'
		Me.DataGridViewTextBoxColumn1.Frozen = True
		Me.DataGridViewTextBoxColumn1.HeaderText = "IDItem"
		Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
		Me.DataGridViewTextBoxColumn1.ReadOnly = True
		Me.DataGridViewTextBoxColumn1.Visible = False
		'
		'DataGridViewTextBoxColumn2
		'
		Me.DataGridViewTextBoxColumn2.Frozen = True
		Me.DataGridViewTextBoxColumn2.HeaderText = "Reg."
		Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
		Me.DataGridViewTextBoxColumn2.ReadOnly = True
		Me.DataGridViewTextBoxColumn2.Width = 60
		'
		'DataGridViewTextBoxColumn3
		'
		Me.DataGridViewTextBoxColumn3.Frozen = True
		Me.DataGridViewTextBoxColumn3.HeaderText = "Produto"
		Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
		Me.DataGridViewTextBoxColumn3.ReadOnly = True
		Me.DataGridViewTextBoxColumn3.Width = 375
		'
		'DataGridViewTextBoxColumn4
		'
		Me.DataGridViewTextBoxColumn4.Frozen = True
		Me.DataGridViewTextBoxColumn4.HeaderText = "Qtde"
		Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
		Me.DataGridViewTextBoxColumn4.ReadOnly = True
		Me.DataGridViewTextBoxColumn4.Width = 60
		'
		'DataGridViewTextBoxColumn5
		'
		Me.DataGridViewTextBoxColumn5.Frozen = True
		Me.DataGridViewTextBoxColumn5.HeaderText = "Preço"
		Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
		Me.DataGridViewTextBoxColumn5.ReadOnly = True
		Me.DataGridViewTextBoxColumn5.Width = 90
		'
		'DataGridViewTextBoxColumn6
		'
		Me.DataGridViewTextBoxColumn6.Frozen = True
		Me.DataGridViewTextBoxColumn6.HeaderText = "SubTotal"
		Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
		Me.DataGridViewTextBoxColumn6.ReadOnly = True
		Me.DataGridViewTextBoxColumn6.Width = 90
		'
		'DataGridViewTextBoxColumn7
		'
		Me.DataGridViewTextBoxColumn7.HeaderText = "Desc."
		Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
		Me.DataGridViewTextBoxColumn7.ReadOnly = True
		Me.DataGridViewTextBoxColumn7.Width = 80
		'
		'DataGridViewTextBoxColumn8
		'
		Me.DataGridViewTextBoxColumn8.HeaderText = "Total"
		Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
		Me.DataGridViewTextBoxColumn8.ReadOnly = True
		Me.DataGridViewTextBoxColumn8.Width = 90
		'
		'vtabFreteDevolucao
		'
		Me.vtabFreteDevolucao.Controls.Add(Me.btnTransportadoraAddDev)
		Me.vtabFreteDevolucao.Controls.Add(Me.txtObservacaoDev)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label29)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label30)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label31)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label32)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label33)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label34)
		Me.vtabFreteDevolucao.Controls.Add(Me.txtVolumesDev)
		Me.vtabFreteDevolucao.Controls.Add(Me.txtFreteValorDev)
		Me.vtabFreteDevolucao.Controls.Add(Me.cmbIDTransportadoraDev)
		Me.vtabFreteDevolucao.Controls.Add(Me.cmbFreteTipoDev)
		Me.vtabFreteDevolucao.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabFreteDevolucao.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFreteDevolucao.Location = New System.Drawing.Point(0, 38)
		Me.vtabFreteDevolucao.Name = "vtabFreteDevolucao"
		Me.vtabFreteDevolucao.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabFreteDevolucao.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFreteDevolucao.Size = New System.Drawing.Size(1180, 462)
		Me.vtabFreteDevolucao.TabIndex = 0
		Me.vtabFreteDevolucao.Text = "Frete Saída"
		Me.vtabFreteDevolucao.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFreteDevolucao.TooltipText = "TabPage"
		Me.vtabFreteDevolucao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabFreteDevolucao.Visible = False
		'
		'btnTransportadoraAddDev
		'
		Me.btnTransportadoraAddDev.FlatAppearance.BorderSize = 0
		Me.btnTransportadoraAddDev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnTransportadoraAddDev.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnTransportadoraAddDev.Location = New System.Drawing.Point(441, 85)
		Me.btnTransportadoraAddDev.Name = "btnTransportadoraAddDev"
		Me.btnTransportadoraAddDev.Size = New System.Drawing.Size(28, 27)
		Me.btnTransportadoraAddDev.TabIndex = 5
		Me.btnTransportadoraAddDev.TabStop = False
		Me.btnTransportadoraAddDev.UseVisualStyleBackColor = True
		'
		'txtObservacaoDev
		'
		Me.txtObservacaoDev.Location = New System.Drawing.Point(38, 228)
		Me.txtObservacaoDev.Multiline = True
		Me.txtObservacaoDev.Name = "txtObservacaoDev"
		Me.txtObservacaoDev.Size = New System.Drawing.Size(431, 109)
		Me.txtObservacaoDev.TabIndex = 10
		'
		'Label29
		'
		Me.Label29.AutoSize = True
		Me.Label29.BackColor = System.Drawing.Color.Transparent
		Me.Label29.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label29.ForeColor = System.Drawing.Color.SlateGray
		Me.Label29.Location = New System.Drawing.Point(18, 189)
		Me.Label29.Name = "Label29"
		Me.Label29.Size = New System.Drawing.Size(250, 26)
		Me.Label29.TabIndex = 9
		Me.Label29.Text = "Observações da Devolução:"
		'
		'Label30
		'
		Me.Label30.AutoSize = True
		Me.Label30.BackColor = System.Drawing.Color.Transparent
		Me.Label30.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label30.ForeColor = System.Drawing.Color.SlateGray
		Me.Label30.Location = New System.Drawing.Point(18, 14)
		Me.Label30.Name = "Label30"
		Me.Label30.Size = New System.Drawing.Size(325, 26)
		Me.Label30.TabIndex = 0
		Me.Label30.Text = "Frete da Devolução de Consignação:"
		'
		'Label31
		'
		Me.Label31.AutoSize = True
		Me.Label31.BackColor = System.Drawing.Color.Transparent
		Me.Label31.Location = New System.Drawing.Point(262, 122)
		Me.Label31.Name = "Label31"
		Me.Label31.Size = New System.Drawing.Size(64, 19)
		Me.Label31.TabIndex = 7
		Me.Label31.Text = "Volumes"
		'
		'Label32
		'
		Me.Label32.AutoSize = True
		Me.Label32.BackColor = System.Drawing.Color.Transparent
		Me.Label32.Location = New System.Drawing.Point(42, 122)
		Me.Label32.Name = "Label32"
		Me.Label32.Size = New System.Drawing.Size(99, 19)
		Me.Label32.TabIndex = 23
		Me.Label32.Text = "Valor do Frete"
		'
		'Label33
		'
		Me.Label33.AutoSize = True
		Me.Label33.BackColor = System.Drawing.Color.Transparent
		Me.Label33.Location = New System.Drawing.Point(34, 89)
		Me.Label33.Name = "Label33"
		Me.Label33.Size = New System.Drawing.Size(107, 19)
		Me.Label33.TabIndex = 3
		Me.Label33.Text = "Transportadora"
		'
		'Label34
		'
		Me.Label34.AutoSize = True
		Me.Label34.BackColor = System.Drawing.Color.Transparent
		Me.Label34.Location = New System.Drawing.Point(47, 56)
		Me.Label34.Name = "Label34"
		Me.Label34.Size = New System.Drawing.Size(94, 19)
		Me.Label34.TabIndex = 1
		Me.Label34.Text = "Tipo de Frete"
		'
		'txtVolumesDev
		'
		Me.txtVolumesDev.Inteiro = True
		Me.txtVolumesDev.Location = New System.Drawing.Point(332, 119)
		Me.txtVolumesDev.Name = "txtVolumesDev"
		Me.txtVolumesDev.Size = New System.Drawing.Size(49, 27)
		Me.txtVolumesDev.TabIndex = 8
		Me.txtVolumesDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtFreteValorDev
		'
		Me.txtFreteValorDev.Location = New System.Drawing.Point(147, 119)
		Me.txtFreteValorDev.Name = "txtFreteValorDev"
		Me.txtFreteValorDev.Size = New System.Drawing.Size(100, 27)
		Me.txtFreteValorDev.SomentePositivos = True
		Me.txtFreteValorDev.TabIndex = 6
		Me.txtFreteValorDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'cmbIDTransportadoraDev
		'
		Me.cmbIDTransportadoraDev.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbIDTransportadoraDev.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbIDTransportadoraDev.FormattingEnabled = True
		Me.cmbIDTransportadoraDev.Location = New System.Drawing.Point(147, 86)
		Me.cmbIDTransportadoraDev.Name = "cmbIDTransportadoraDev"
		Me.cmbIDTransportadoraDev.RestrictContentToListItems = True
		Me.cmbIDTransportadoraDev.Size = New System.Drawing.Size(288, 27)
		Me.cmbIDTransportadoraDev.TabIndex = 4
		'
		'cmbFreteTipoDev
		'
		Me.cmbFreteTipoDev.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbFreteTipoDev.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbFreteTipoDev.FormattingEnabled = True
		Me.cmbFreteTipoDev.Location = New System.Drawing.Point(147, 53)
		Me.cmbFreteTipoDev.Name = "cmbFreteTipoDev"
		Me.cmbFreteTipoDev.RestrictContentToListItems = True
		Me.cmbFreteTipoDev.Size = New System.Drawing.Size(149, 27)
		Me.cmbFreteTipoDev.TabIndex = 2
		'
		'vtabNotas
		'
		Me.vtabNotas.Controls.Add(Me.dgvNotas)
		Me.vtabNotas.Controls.Add(Me.pnlNota)
		Me.vtabNotas.Controls.Add(Me.Label11)
		Me.vtabNotas.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabNotas.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabNotas.Location = New System.Drawing.Point(0, 38)
		Me.vtabNotas.Name = "vtabNotas"
		Me.vtabNotas.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabNotas.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabNotas.Size = New System.Drawing.Size(1180, 462)
		Me.vtabNotas.TabIndex = 6
		Me.vtabNotas.Text = "Notas Fiscais"
		Me.vtabNotas.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabNotas.TooltipText = "TabPage"
		Me.vtabNotas.UseDefaultTextFont = False
		Me.vtabNotas.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabNotas.Visible = False
		'
		'dgvNotas
		'
		Me.dgvNotas.AllowUserToAddRows = False
		Me.dgvNotas.AllowUserToDeleteRows = False
		Me.dgvNotas.AllowUserToResizeColumns = False
		Me.dgvNotas.AllowUserToResizeRows = False
		Me.dgvNotas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvNotas.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvNotas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
		DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonFace
		DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvNotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
		Me.dgvNotas.ColumnHeadersHeight = 30
		Me.dgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dgvNotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnChaveAcesso, Me.clnNotaTipo, Me.clnNotaSerie, Me.clnNotaNumero, Me.clnEmissaoData, Me.clnNotaValor})
		Me.dgvNotas.EnableHeadersVisualStyles = False
		Me.dgvNotas.Location = New System.Drawing.Point(23, 53)
		Me.dgvNotas.Name = "dgvNotas"
		Me.dgvNotas.ReadOnly = True
		Me.dgvNotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgvNotas.RowsDefaultCellStyle = DataGridViewCellStyle11
		Me.dgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvNotas.Size = New System.Drawing.Size(846, 312)
		Me.dgvNotas.TabIndex = 6
		'
		'clnChaveAcesso
		'
		Me.clnChaveAcesso.HeaderText = "Chave Acesso"
		Me.clnChaveAcesso.Name = "clnChaveAcesso"
		Me.clnChaveAcesso.ReadOnly = True
		Me.clnChaveAcesso.Width = 350
		'
		'clnNotaTipo
		'
		Me.clnNotaTipo.HeaderText = "Tipo"
		Me.clnNotaTipo.Name = "clnNotaTipo"
		Me.clnNotaTipo.ReadOnly = True
		Me.clnNotaTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'clnNotaSerie
		'
		Me.clnNotaSerie.HeaderText = "Série"
		Me.clnNotaSerie.Name = "clnNotaSerie"
		Me.clnNotaSerie.ReadOnly = True
		Me.clnNotaSerie.Width = 70
		'
		'clnNotaNumero
		'
		Me.clnNotaNumero.HeaderText = "Número"
		Me.clnNotaNumero.Name = "clnNotaNumero"
		Me.clnNotaNumero.ReadOnly = True
		Me.clnNotaNumero.Width = 70
		'
		'clnEmissaoData
		'
		Me.clnEmissaoData.HeaderText = "Data"
		Me.clnEmissaoData.Name = "clnEmissaoData"
		Me.clnEmissaoData.ReadOnly = True
		'
		'clnNotaValor
		'
		Me.clnNotaValor.HeaderText = "Valor"
		Me.clnNotaValor.Name = "clnNotaValor"
		Me.clnNotaValor.ReadOnly = True
		Me.clnNotaValor.Width = 80
		'
		'pnlNota
		'
		Me.pnlNota.BackColor = System.Drawing.SystemColors.GradientActiveCaption
		Me.pnlNota.Controls.Add(Me.txtChaveAcesso)
		Me.pnlNota.Controls.Add(Me.btnNotaCancel)
		Me.pnlNota.Controls.Add(Me.btnNotaOK)
		Me.pnlNota.Controls.Add(Me.lblNota)
		Me.pnlNota.Controls.Add(Me.Label23)
		Me.pnlNota.Controls.Add(Me.Label25)
		Me.pnlNota.Controls.Add(Me.Label24)
		Me.pnlNota.Controls.Add(Me.Label22)
		Me.pnlNota.Controls.Add(Me.Label21)
		Me.pnlNota.Controls.Add(Me.Label16)
		Me.pnlNota.Controls.Add(Me.txtNotaValor)
		Me.pnlNota.Controls.Add(Me.txtEmissaoData)
		Me.pnlNota.Controls.Add(Me.txtNotaNumero)
		Me.pnlNota.Controls.Add(Me.txtNotaSerie)
		Me.pnlNota.Controls.Add(Me.cmbNotaTipo)
		Me.pnlNota.Location = New System.Drawing.Point(881, 53)
		Me.pnlNota.Name = "pnlNota"
		Me.pnlNota.Size = New System.Drawing.Size(280, 352)
		Me.pnlNota.TabIndex = 5
		Me.pnlNota.Visible = False
		'
		'txtChaveAcesso
		'
		Me.txtChaveAcesso.Location = New System.Drawing.Point(25, 66)
		Me.txtChaveAcesso.Multiline = True
		Me.txtChaveAcesso.Name = "txtChaveAcesso"
		Me.txtChaveAcesso.Size = New System.Drawing.Size(232, 54)
		Me.txtChaveAcesso.TabIndex = 2
		'
		'btnNotaCancel
		'
		Me.btnNotaCancel.ForeColor = System.Drawing.Color.Maroon
		Me.btnNotaCancel.Location = New System.Drawing.Point(144, 296)
		Me.btnNotaCancel.Name = "btnNotaCancel"
		Me.btnNotaCancel.Size = New System.Drawing.Size(113, 38)
		Me.btnNotaCancel.TabIndex = 14
		Me.btnNotaCancel.Text = "Cancelar"
		Me.btnNotaCancel.UseVisualStyleBackColor = True
		'
		'btnNotaOK
		'
		Me.btnNotaOK.ForeColor = System.Drawing.Color.DarkGreen
		Me.btnNotaOK.Location = New System.Drawing.Point(25, 296)
		Me.btnNotaOK.Name = "btnNotaOK"
		Me.btnNotaOK.Size = New System.Drawing.Size(113, 38)
		Me.btnNotaOK.TabIndex = 13
		Me.btnNotaOK.Text = "Inserir"
		Me.btnNotaOK.UseVisualStyleBackColor = True
		'
		'lblNota
		'
		Me.lblNota.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNota.ForeColor = System.Drawing.Color.SlateGray
		Me.lblNota.Location = New System.Drawing.Point(20, 7)
		Me.lblNota.Name = "lblNota"
		Me.lblNota.Size = New System.Drawing.Size(245, 26)
		Me.lblNota.TabIndex = 0
		Me.lblNota.Text = "Inserindo Nota Fiscal"
		Me.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.Location = New System.Drawing.Point(143, 179)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(60, 19)
		Me.Label23.TabIndex = 7
		Me.Label23.Text = "Número"
		'
		'Label25
		'
		Me.Label25.AutoSize = True
		Me.Label25.Location = New System.Drawing.Point(143, 231)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(78, 19)
		Me.Label25.TabIndex = 11
		Me.Label25.Text = "Valor Total"
		'
		'Label24
		'
		Me.Label24.AutoSize = True
		Me.Label24.Location = New System.Drawing.Point(25, 231)
		Me.Label24.Name = "Label24"
		Me.Label24.Size = New System.Drawing.Size(86, 19)
		Me.Label24.TabIndex = 9
		Me.Label24.Text = "Dt. Emissão"
		'
		'Label22
		'
		Me.Label22.AutoSize = True
		Me.Label22.Location = New System.Drawing.Point(25, 179)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(41, 19)
		Me.Label22.TabIndex = 5
		Me.Label22.Text = "Série"
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(25, 127)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(72, 19)
		Me.Label21.TabIndex = 3
		Me.Label21.Text = "Nota Tipo"
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(25, 44)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(119, 19)
		Me.Label16.TabIndex = 1
		Me.Label16.Text = "Chave de Acesso"
		'
		'txtNotaValor
		'
		Me.txtNotaValor.Location = New System.Drawing.Point(147, 253)
		Me.txtNotaValor.Name = "txtNotaValor"
		Me.txtNotaValor.Size = New System.Drawing.Size(110, 27)
		Me.txtNotaValor.SomentePositivos = True
		Me.txtNotaValor.TabIndex = 12
		Me.txtNotaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtEmissaoData
		'
		Me.txtEmissaoData.Location = New System.Drawing.Point(25, 253)
		Me.txtEmissaoData.Mask = "00/00/0000"
		Me.txtEmissaoData.Name = "txtEmissaoData"
		Me.txtEmissaoData.Size = New System.Drawing.Size(100, 27)
		Me.txtEmissaoData.TabIndex = 10
		'
		'txtNotaNumero
		'
		Me.txtNotaNumero.Inteiro = True
		Me.txtNotaNumero.Location = New System.Drawing.Point(147, 201)
		Me.txtNotaNumero.MaxLength = 12
		Me.txtNotaNumero.Name = "txtNotaNumero"
		Me.txtNotaNumero.Size = New System.Drawing.Size(110, 27)
		Me.txtNotaNumero.TabIndex = 8
		Me.txtNotaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtNotaSerie
		'
		Me.txtNotaSerie.Inteiro = True
		Me.txtNotaSerie.Location = New System.Drawing.Point(25, 201)
		Me.txtNotaSerie.MaxLength = 4
		Me.txtNotaSerie.Name = "txtNotaSerie"
		Me.txtNotaSerie.Size = New System.Drawing.Size(68, 27)
		Me.txtNotaSerie.TabIndex = 6
		Me.txtNotaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'cmbNotaTipo
		'
		Me.cmbNotaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbNotaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbNotaTipo.FormattingEnabled = True
		Me.cmbNotaTipo.Location = New System.Drawing.Point(25, 149)
		Me.cmbNotaTipo.Name = "cmbNotaTipo"
		Me.cmbNotaTipo.RestrictContentToListItems = True
		Me.cmbNotaTipo.Size = New System.Drawing.Size(156, 27)
		Me.cmbNotaTipo.TabIndex = 4
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
		Me.Label11.ForeColor = System.Drawing.Color.SlateGray
		Me.Label11.Location = New System.Drawing.Point(18, 14)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(243, 26)
		Me.Label11.TabIndex = 3
		Me.Label11.Text = "Notas e/ou Cupons Fiscais:"
		'
		'LineShape4
		'
		Me.LineShape4.BorderColor = System.Drawing.Color.SlateGray
		Me.LineShape4.BorderWidth = 3
		Me.LineShape4.Name = "LineShape4"
		Me.LineShape4.X1 = 852
		Me.LineShape4.X2 = 1127
		Me.LineShape4.Y1 = 26
		Me.LineShape4.Y2 = 26
		'
		'LineShape3
		'
		Me.LineShape3.BorderColor = System.Drawing.Color.SlateGray
		Me.LineShape3.BorderWidth = 3
		Me.LineShape3.Name = "LineShape3"
		Me.LineShape3.X1 = 249
		Me.LineShape3.X2 = 500
		Me.LineShape3.Y1 = 301
		Me.LineShape3.Y2 = 301
		'
		'LineShape2
		'
		Me.LineShape2.BorderColor = System.Drawing.Color.SlateGray
		Me.LineShape2.BorderWidth = 3
		Me.LineShape2.Name = "LineShape2"
		Me.LineShape2.X1 = 176
		Me.LineShape2.X2 = 500
		Me.LineShape2.Y1 = 25
		Me.LineShape2.Y2 = 25
		'
		'LineShape1
		'
		Me.LineShape1.BorderColor = System.Drawing.Color.SlateGray
		Me.LineShape1.BorderWidth = 3
		Me.LineShape1.Name = "LineShape1"
		Me.LineShape1.X1 = 77
		Me.LineShape1.X2 = 500
		Me.LineShape1.Y1 = 140
		Me.LineShape1.Y2 = 140
		'
		'lblCli
		'
		Me.lblCli.AutoSize = True
		Me.lblCli.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCli.Location = New System.Drawing.Point(14, 69)
		Me.lblCli.Name = "lblCli"
		Me.lblCli.Size = New System.Drawing.Size(91, 19)
		Me.lblCli.TabIndex = 1
		Me.lblCli.Text = "Fornecedor:"
		'
		'lblFornecedor
		'
		Me.lblFornecedor.BackColor = System.Drawing.Color.White
		Me.lblFornecedor.Location = New System.Drawing.Point(115, 67)
		Me.lblFornecedor.Name = "lblFornecedor"
		Me.lblFornecedor.Size = New System.Drawing.Size(614, 25)
		Me.lblFornecedor.TabIndex = 2
		Me.lblFornecedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ShapeContainer1
		'
		Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
		Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer1.Name = "ShapeContainer1"
		Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
		Me.ShapeContainer1.Size = New System.Drawing.Size(1200, 661)
		Me.ShapeContainer1.TabIndex = 5
		Me.ShapeContainer1.TabStop = False
		'
		'RectangleShape2
		'
		Me.RectangleShape2.BackColor = System.Drawing.Color.White
		Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me.RectangleShape2.BorderColor = System.Drawing.SystemColors.ActiveCaption
		Me.RectangleShape2.FillColor = System.Drawing.Color.Transparent
		Me.RectangleShape2.FillGradientColor = System.Drawing.Color.Transparent
		Me.RectangleShape2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central
		Me.RectangleShape2.Location = New System.Drawing.Point(112, 64)
		Me.RectangleShape2.Name = "RectangleShape2"
		Me.RectangleShape2.Size = New System.Drawing.Size(626, 30)
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.Silver
		Me.Label3.Location = New System.Drawing.Point(166, 4)
		Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(41, 13)
		Me.Label3.TabIndex = 50
		Me.Label3.Text = "Data:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
		Me.lbl_IdTexto.TabIndex = 51
		Me.lbl_IdTexto.Text = "Reg."
		Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblConsignacaoData
		'
		Me.lblConsignacaoData.BackColor = System.Drawing.Color.Transparent
		Me.lblConsignacaoData.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblConsignacaoData.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblConsignacaoData.Location = New System.Drawing.Point(112, 16)
		Me.lblConsignacaoData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblConsignacaoData.Name = "lblConsignacaoData"
		Me.lblConsignacaoData.Size = New System.Drawing.Size(155, 30)
		Me.lblConsignacaoData.TabIndex = 48
		Me.lblConsignacaoData.Text = "01/01/2017"
		Me.lblConsignacaoData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblIDConsignacao
		'
		Me.lblIDConsignacao.BackColor = System.Drawing.Color.Transparent
		Me.lblIDConsignacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIDConsignacao.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblIDConsignacao.Location = New System.Drawing.Point(5, 16)
		Me.lblIDConsignacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblIDConsignacao.Name = "lblIDConsignacao"
		Me.lblIDConsignacao.Size = New System.Drawing.Size(85, 30)
		Me.lblIDConsignacao.TabIndex = 49
		Me.lblIDConsignacao.Text = "0001"
		Me.lblIDConsignacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
		Me.btnClose.Location = New System.Drawing.Point(1168, 14)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RibbonStyle = False
		Me.btnClose.RoundedCornersMask = CType(15, Byte)
		Me.btnClose.ShowFocusRectangle = False
		Me.btnClose.Size = New System.Drawing.Size(20, 20)
		Me.btnClose.TabIndex = 54
		Me.btnClose.TabStop = False
		Me.btnClose.UseVisualStyleBackColor = False
		Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
		'
		'lblTotalConsignacao
		'
		Me.lblTotalConsignacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalConsignacao.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalConsignacao.Location = New System.Drawing.Point(1001, 617)
		Me.lblTotalConsignacao.Margin = New System.Windows.Forms.Padding(0)
		Me.lblTotalConsignacao.Name = "lblTotalConsignacao"
		Me.lblTotalConsignacao.Size = New System.Drawing.Size(187, 32)
		Me.lblTotalConsignacao.TabIndex = 8
		Me.lblTotalConsignacao.Text = "R$ 0,00"
		Me.lblTotalConsignacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(778, 625)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(220, 19)
		Me.Label13.TabIndex = 7
		Me.Label13.Text = "Total dos Produtos Consignados:"
		'
		'lblSituacao
		'
		Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
		Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblSituacao.Location = New System.Drawing.Point(489, 16)
		Me.lblSituacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblSituacao.Name = "lblSituacao"
		Me.lblSituacao.Size = New System.Drawing.Size(187, 30)
		Me.lblSituacao.TabIndex = 49
		Me.lblSituacao.Text = "Em Aberto"
		Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.BackColor = System.Drawing.Color.Transparent
		Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label15.ForeColor = System.Drawing.Color.Silver
		Me.Label15.Location = New System.Drawing.Point(549, 4)
		Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(67, 13)
		Me.Label15.TabIndex = 51
		Me.Label15.Text = "Situação:"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'VApplicationMenuItem2
		'
		Me.VApplicationMenuItem2.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
		Me.VApplicationMenuItem2.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.MenuItem
		Me.VApplicationMenuItem2.Location = New System.Drawing.Point(0, 0)
		Me.VApplicationMenuItem2.Name = "VApplicationMenuItem2"
		Me.VApplicationMenuItem2.SelectedChildMenuItem = Nothing
		Me.VApplicationMenuItem2.Size = New System.Drawing.Size(200, 20)
		Me.VApplicationMenuItem2.TabIndex = 0
		Me.VApplicationMenuItem2.Text = "Salvar"
		Me.VApplicationMenuItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
		Me.VApplicationMenuItem2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'VApplicationMenuItem3
		'
		Me.VApplicationMenuItem3.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
		Me.VApplicationMenuItem3.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.Separator
		Me.VApplicationMenuItem3.Location = New System.Drawing.Point(0, 20)
		Me.VApplicationMenuItem3.Name = "VApplicationMenuItem3"
		Me.VApplicationMenuItem3.SelectedChildMenuItem = Nothing
		Me.VApplicationMenuItem3.Size = New System.Drawing.Size(200, 20)
		Me.VApplicationMenuItem3.TabIndex = 1
		Me.VApplicationMenuItem3.Text = "Imprimir"
		Me.VApplicationMenuItem3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
		Me.VApplicationMenuItem3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'VApplicationMenuItem4
		'
		Me.VApplicationMenuItem4.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
		Me.VApplicationMenuItem4.ItemType = VIBlend.WinForms.Controls.vApplicationMenuItemType.MenuItem
		Me.VApplicationMenuItem4.Location = New System.Drawing.Point(0, 40)
		Me.VApplicationMenuItem4.Name = "VApplicationMenuItem4"
		Me.VApplicationMenuItem4.SelectedChildMenuItem = Nothing
		Me.VApplicationMenuItem4.Size = New System.Drawing.Size(200, 20)
		Me.VApplicationMenuItem4.TabIndex = 2
		Me.VApplicationMenuItem4.Text = "vApplicationMenuItem"
		Me.VApplicationMenuItem4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
		Me.VApplicationMenuItem4.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnFinalizar
		'
		Me.btnFinalizar.AllowAnimations = True
		Me.btnFinalizar.BackColor = System.Drawing.Color.Transparent
		Me.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFinalizar.HoverEffectsEnabled = True
		Me.btnFinalizar.Image = Global.NovaSiao.My.Resources.Resources.accept
		Me.btnFinalizar.ImageAbsolutePosition = New System.Drawing.Point(15, 5)
		Me.btnFinalizar.Location = New System.Drawing.Point(489, 612)
		Me.btnFinalizar.Name = "btnFinalizar"
		Me.btnFinalizar.Opacity = 0!
		Me.btnFinalizar.RoundedCornersMask = CType(15, Byte)
		Me.btnFinalizar.RoundedCornersRadius = 5
		Me.btnFinalizar.Size = New System.Drawing.Size(204, 42)
		Me.btnFinalizar.TabIndex = 6
		Me.btnFinalizar.Text = "&Concluir Entrada"
		Me.btnFinalizar.TextAbsolutePosition = New System.Drawing.Point(30, 1)
		Me.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnFinalizar.UseAbsoluteImagePositioning = True
		Me.btnFinalizar.UseAbsoluteTextPositioning = True
		Me.btnFinalizar.UseVisualStyleBackColor = False
		Me.btnFinalizar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.BackColor = System.Drawing.Color.Transparent
		Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label18.ForeColor = System.Drawing.Color.Silver
		Me.Label18.Location = New System.Drawing.Point(377, 4)
		Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(43, 13)
		Me.Label18.TabIndex = 56
		Me.Label18.Text = "Filial:"
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblFilial
		'
		Me.lblFilial.BackColor = System.Drawing.Color.Transparent
		Me.lblFilial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblFilial.Location = New System.Drawing.Point(306, 16)
		Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblFilial.Name = "lblFilial"
		Me.lblFilial.Size = New System.Drawing.Size(193, 30)
		Me.lblFilial.TabIndex = 55
		Me.lblFilial.Text = "Filial"
		Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cmsMenuAPagar
		'
		Me.cmsMenuAPagar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miInserir, Me.miEditar, Me.ToolStripSeparator1, Me.miExcluir})
		Me.cmsMenuAPagar.Name = "cmsMenuAPagar"
		Me.cmsMenuAPagar.Size = New System.Drawing.Size(179, 76)
		'
		'miInserir
		'
		Me.miInserir.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.miInserir.Name = "miInserir"
		Me.miInserir.Size = New System.Drawing.Size(178, 22)
		Me.miInserir.Text = "Inserir Nova Parcela"
		'
		'miEditar
		'
		Me.miEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miEditar.Name = "miEditar"
		Me.miEditar.Size = New System.Drawing.Size(178, 22)
		Me.miEditar.Text = "Editar Parcela"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(175, 6)
		'
		'miExcluir
		'
		Me.miExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete
		Me.miExcluir.Name = "miExcluir"
		Me.miExcluir.Size = New System.Drawing.Size(178, 22)
		Me.miExcluir.Text = "Excluir Parcela"
		'
		'mnuAcao
		'
		Me.mnuAcao.AutoSize = False
		Me.mnuAcao.BackColor = System.Drawing.Color.Transparent
		Me.mnuAcao.Dock = System.Windows.Forms.DockStyle.None
		Me.mnuAcao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnAdicionar, Me.ToolStripSeparator2, Me.btnExcluir, Me.ToolStripSeparator3, Me.btnImprimir})
		Me.mnuAcao.Location = New System.Drawing.Point(10, 612)
		Me.mnuAcao.Name = "mnuAcao"
		Me.mnuAcao.Size = New System.Drawing.Size(350, 47)
		Me.mnuAcao.TabIndex = 4
		Me.mnuAcao.Text = "ToolStrip1"
		'
		'btnProcurar
		'
		Me.btnProcurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.search1
		Me.btnProcurar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnProcurar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
		Me.btnProcurar.Name = "btnProcurar"
		Me.btnProcurar.Size = New System.Drawing.Size(36, 44)
		Me.btnProcurar.Text = "Procurar Compra"
		'
		'btnAdicionar
		'
		Me.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnAdicionar.Image = Global.NovaSiao.My.Resources.Resources.add_32x32
		Me.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnAdicionar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
		Me.btnAdicionar.Name = "btnAdicionar"
		Me.btnAdicionar.Size = New System.Drawing.Size(36, 44)
		Me.btnAdicionar.Text = "Adicionar Compra"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 47)
		'
		'btnExcluir
		'
		Me.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.Lixeira_PEQ
		Me.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnExcluir.Name = "btnExcluir"
		Me.btnExcluir.Size = New System.Drawing.Size(45, 44)
		Me.btnExcluir.Text = "Excluir Compra"
		Me.btnExcluir.ToolTipText = "Excluir a Compra"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 47)
		'
		'btnImprimir
		'
		Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.btnImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirEtiquetas, Me.miImprimirRelatorio})
		Me.btnImprimir.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir
		Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnImprimir.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
		Me.btnImprimir.Name = "btnImprimir"
		Me.btnImprimir.Size = New System.Drawing.Size(56, 44)
		Me.btnImprimir.Text = "Imprimir"
		'
		'miImprimirEtiquetas
		'
		Me.miImprimirEtiquetas.Image = Global.NovaSiao.My.Resources.Resources.print
		Me.miImprimirEtiquetas.Name = "miImprimirEtiquetas"
		Me.miImprimirEtiquetas.Size = New System.Drawing.Size(211, 24)
		Me.miImprimirEtiquetas.Text = "Etiquetas"
		'
		'miImprimirRelatorio
		'
		Me.miImprimirRelatorio.Image = Global.NovaSiao.My.Resources.Resources.print
		Me.miImprimirRelatorio.Name = "miImprimirRelatorio"
		Me.miImprimirRelatorio.Size = New System.Drawing.Size(211, 24)
		Me.miImprimirRelatorio.Text = "Relatório da Compra"
		'
		'btnConsignacaoData
		'
		Me.btnConsignacaoData.AllowAnimations = True
		Me.btnConsignacaoData.ArrowDirection = System.Windows.Forms.ArrowDirection.Left
		Me.btnConsignacaoData.Location = New System.Drawing.Point(269, 24)
		Me.btnConsignacaoData.Maximum = 100
		Me.btnConsignacaoData.Minimum = 0
		Me.btnConsignacaoData.Name = "btnConsignacaoData"
		Me.btnConsignacaoData.Size = New System.Drawing.Size(16, 16)
		Me.btnConsignacaoData.TabIndex = 57
		Me.btnConsignacaoData.TabStop = False
		Me.btnConsignacaoData.Value = 0
		Me.btnConsignacaoData.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'ShapeContainer3
		'
		Me.ShapeContainer3.Location = New System.Drawing.Point(4, 4)
		Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer3.Name = "ShapeContainer2"
		Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
		Me.ShapeContainer3.Size = New System.Drawing.Size(1172, 454)
		Me.ShapeContainer3.TabIndex = 14
		Me.ShapeContainer3.TabStop = False
		'
		'DataGridViewTextBoxColumn9
		'
		Me.DataGridViewTextBoxColumn9.HeaderText = "ICMS"
		Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
		Me.DataGridViewTextBoxColumn9.Width = 60
		'
		'DataGridViewTextBoxColumn10
		'
		Me.DataGridViewTextBoxColumn10.HeaderText = "ST"
		Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
		Me.DataGridViewTextBoxColumn10.Width = 75
		'
		'DataGridViewTextBoxColumn11
		'
		Me.DataGridViewTextBoxColumn11.HeaderText = "MVA"
		Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
		Me.DataGridViewTextBoxColumn11.Width = 60
		'
		'DataGridViewTextBoxColumn12
		'
		Me.DataGridViewTextBoxColumn12.HeaderText = "IPI%"
		Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
		Me.DataGridViewTextBoxColumn12.Width = 60
		'
		'DataGridViewTextBoxColumn13
		'
		DataGridViewCellStyle12.Format = "C2"
		DataGridViewCellStyle12.NullValue = "0"
		Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle12
		Me.DataGridViewTextBoxColumn13.HeaderText = "Data"
		Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
		Me.DataGridViewTextBoxColumn13.Width = 150
		'
		'DataGridViewTextBoxColumn14
		'
		Me.DataGridViewTextBoxColumn14.HeaderText = "Valor"
		Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
		Me.DataGridViewTextBoxColumn14.Width = 150
		'
		'DataGridViewTextBoxColumn15
		'
		Me.DataGridViewTextBoxColumn15.HeaderText = "Chave Acesso"
		Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
		Me.DataGridViewTextBoxColumn15.Width = 350
		'
		'DataGridViewTextBoxColumn16
		'
		Me.DataGridViewTextBoxColumn16.HeaderText = "Tipo"
		Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
		Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'DataGridViewTextBoxColumn17
		'
		Me.DataGridViewTextBoxColumn17.HeaderText = "Série"
		Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
		Me.DataGridViewTextBoxColumn17.Width = 70
		'
		'DataGridViewTextBoxColumn18
		'
		Me.DataGridViewTextBoxColumn18.HeaderText = "Número"
		Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
		Me.DataGridViewTextBoxColumn18.Width = 70
		'
		'DataGridViewTextBoxColumn19
		'
		Me.DataGridViewTextBoxColumn19.HeaderText = "Data"
		Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
		'
		'DataGridViewTextBoxColumn20
		'
		Me.DataGridViewTextBoxColumn20.HeaderText = "Valor"
		Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
		Me.DataGridViewTextBoxColumn20.Width = 80
		'
		'DataGridViewTextBoxColumn21
		'
		Me.DataGridViewTextBoxColumn21.Frozen = True
		Me.DataGridViewTextBoxColumn21.HeaderText = "IDItem"
		Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
		Me.DataGridViewTextBoxColumn21.Visible = False
		'
		'DataGridViewTextBoxColumn22
		'
		Me.DataGridViewTextBoxColumn22.Frozen = True
		Me.DataGridViewTextBoxColumn22.HeaderText = "Reg."
		Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
		Me.DataGridViewTextBoxColumn22.Width = 60
		'
		'DataGridViewTextBoxColumn23
		'
		Me.DataGridViewTextBoxColumn23.Frozen = True
		Me.DataGridViewTextBoxColumn23.HeaderText = "Produto"
		Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
		Me.DataGridViewTextBoxColumn23.Width = 375
		'
		'DataGridViewTextBoxColumn24
		'
		Me.DataGridViewTextBoxColumn24.Frozen = True
		Me.DataGridViewTextBoxColumn24.HeaderText = "Qtde"
		Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
		Me.DataGridViewTextBoxColumn24.Width = 60
		'
		'DataGridViewTextBoxColumn25
		'
		Me.DataGridViewTextBoxColumn25.Frozen = True
		Me.DataGridViewTextBoxColumn25.HeaderText = "Preço"
		Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
		Me.DataGridViewTextBoxColumn25.Width = 90
		'
		'DataGridViewTextBoxColumn26
		'
		Me.DataGridViewTextBoxColumn26.Frozen = True
		Me.DataGridViewTextBoxColumn26.HeaderText = "SubTotal"
		Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
		Me.DataGridViewTextBoxColumn26.Width = 90
		'
		'DataGridViewTextBoxColumn27
		'
		Me.DataGridViewTextBoxColumn27.HeaderText = "Desc."
		Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
		Me.DataGridViewTextBoxColumn27.Width = 80
		'
		'DataGridViewTextBoxColumn28
		'
		Me.DataGridViewTextBoxColumn28.HeaderText = "Total"
		Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
		Me.DataGridViewTextBoxColumn28.Width = 90
		'
		'ShapeContainer4
		'
		Me.ShapeContainer4.Location = New System.Drawing.Point(4, 4)
		Me.ShapeContainer4.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer4.Name = "ShapeContainer2"
		Me.ShapeContainer4.Size = New System.Drawing.Size(1172, 454)
		Me.ShapeContainer4.TabIndex = 14
		Me.ShapeContainer4.TabStop = False
		'
		'ShapeContainer2
		'
		Me.ShapeContainer2.Location = New System.Drawing.Point(4, 4)
		Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer2.Name = "ShapeContainer2"
		Me.ShapeContainer2.Size = New System.Drawing.Size(1172, 454)
		Me.ShapeContainer2.TabIndex = 14
		Me.ShapeContainer2.TabStop = False
		'
		'frmConsignacao
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1200, 661)
		Me.Controls.Add(Me.mnuAcao)
		Me.Controls.Add(Me.btnFinalizar)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.lblTotalConsignacao)
		Me.Controls.Add(Me.lblCli)
		Me.Controls.Add(Me.lblFornecedor)
		Me.Controls.Add(Me.tabPrincipal)
		Me.Controls.Add(Me.ShapeContainer1)
		Me.KeyPreview = True
		Me.Name = "frmConsignacao"
		Me.Controls.SetChildIndex(Me.ShapeContainer1, 0)
		Me.Controls.SetChildIndex(Me.tabPrincipal, 0)
		Me.Controls.SetChildIndex(Me.lblFornecedor, 0)
		Me.Controls.SetChildIndex(Me.lblCli, 0)
		Me.Controls.SetChildIndex(Me.lblTotalConsignacao, 0)
		Me.Controls.SetChildIndex(Me.Label13, 0)
		Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
		Me.Controls.SetChildIndex(Me.mnuAcao, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.tabPrincipal.ResumeLayout(False)
		Me.vtabProdutos.ResumeLayout(False)
		CType(Me.dgvItensConsignacao, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtabFrete.ResumeLayout(False)
		Me.vtabFrete.PerformLayout()
		Me.vtabCompra.ResumeLayout(False)
		Me.vtabCompra.PerformLayout()
		CType(Me.dgvItensComprados, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtabAPagar.ResumeLayout(False)
		Me.vtabAPagar.PerformLayout()
		CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtabDevolucao.ResumeLayout(False)
		Me.vtabDevolucao.PerformLayout()
		CType(Me.dgvDevolucao, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtabFreteDevolucao.ResumeLayout(False)
		Me.vtabFreteDevolucao.PerformLayout()
		Me.vtabNotas.ResumeLayout(False)
		Me.vtabNotas.PerformLayout()
		CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlNota.ResumeLayout(False)
		Me.pnlNota.PerformLayout()
		Me.cmsMenuAPagar.ResumeLayout(False)
		Me.mnuAcao.ResumeLayout(False)
		Me.mnuAcao.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
	Friend WithEvents vtabProdutos As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents dgvItensConsignacao As DataGridView
	Friend WithEvents vtabFrete As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents vtabNotas As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents lblCli As Label
	Friend WithEvents lblFornecedor As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents lblIDConsignacao As Label
	Friend WithEvents lbl_IdTexto As Label
	Friend WithEvents lblConsignacaoData As Label
	Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
	Friend WithEvents lblTotalConsignacao As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents Label15 As Label
	Friend WithEvents lblSituacao As Label
	Friend WithEvents VApplicationMenuItem2 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents VApplicationMenuItem3 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents VApplicationMenuItem4 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents btnFinalizar As VIBlend.WinForms.Controls.vButton
	Friend WithEvents Label18 As Label
	Friend WithEvents lblFilial As Label
	Friend WithEvents cmsMenuAPagar As ContextMenuStrip
	Friend WithEvents miInserir As ToolStripMenuItem
	Friend WithEvents miEditar As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents miExcluir As ToolStripMenuItem
	Friend WithEvents mnuAcao As ToolStrip
	Friend WithEvents btnProcurar As ToolStripButton
	Friend WithEvents btnAdicionar As ToolStripButton
	Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
	Friend WithEvents btnImprimir As ToolStripSplitButton
	Friend WithEvents miImprimirEtiquetas As ToolStripMenuItem
	Friend WithEvents miImprimirRelatorio As ToolStripMenuItem
	Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
	Private WithEvents RectangleShape2 As PowerPacks.RectangleShape
	Private WithEvents LineShape1 As PowerPacks.LineShape
	Private WithEvents LineShape2 As PowerPacks.LineShape
	Private WithEvents LineShape3 As PowerPacks.LineShape
	Private WithEvents LineShape4 As PowerPacks.LineShape
	Friend WithEvents btnConsignacaoData As VIBlend.WinForms.Controls.vArrowButton
	Friend WithEvents btnExcluir As ToolStripButton
	Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
	Friend WithEvents VButton2 As VIBlend.WinForms.Controls.vButton
	Friend WithEvents vtabDevolucao As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents dgvDevolucao As DataGridView
	Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
	Private WithEvents ShapeContainer3 As PowerPacks.ShapeContainer
	Friend WithEvents clnIDTransacaoItem As DataGridViewTextBoxColumn
	Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
	Friend WithEvents clnProduto As DataGridViewTextBoxColumn
	Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
	Friend WithEvents clnPreco As DataGridViewTextBoxColumn
	Friend WithEvents clnSubTotal As DataGridViewTextBoxColumn
	Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
	Friend WithEvents clnTotal As DataGridViewTextBoxColumn
	Friend WithEvents clnICMS As DataGridViewTextBoxColumn
	Friend WithEvents clnST As DataGridViewTextBoxColumn
	Friend WithEvents clnMVA As DataGridViewTextBoxColumn
	Friend WithEvents clnIPI As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
	Friend WithEvents vtabCompra As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents dgvItensComprados As DataGridView
	Friend WithEvents vtabAPagar As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents Label4 As Label
	Friend WithEvents lblTotalComprado As Label
	Friend WithEvents Label17 As Label
	Friend WithEvents lblTotalCobrado As Label
	Friend WithEvents Label26 As Label
	Friend WithEvents Label28 As Label
	Friend WithEvents lblCobrancaTipo As Label
	Friend WithEvents vtabFreteDevolucao As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents btnTransportadoraAddDev As Button
	Friend WithEvents txtObservacaoDev As TextBox
	Friend WithEvents Label29 As Label
	Friend WithEvents Label30 As Label
	Friend WithEvents Label31 As Label
	Friend WithEvents Label32 As Label
	Friend WithEvents Label33 As Label
	Friend WithEvents Label34 As Label
	Friend WithEvents txtVolumesDev As Controles.Text_SoNumeros
	Friend WithEvents txtFreteValorDev As Controles.Text_Monetario
	Friend WithEvents cmbIDTransportadoraDev As Controles.ComboBox_OnlyValues
	Friend WithEvents cmbFreteTipoDev As Controles.ComboBox_OnlyValues
	Private WithEvents ShapeContainer4 As PowerPacks.ShapeContainer
	Friend WithEvents dgvAPagar As DataGridView
	Friend WithEvents btnTransportadoraAdd As Button
	Friend WithEvents txtObservacaoConsig As TextBox
	Friend WithEvents Label12 As Label
	Friend WithEvents Label14 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents txtVolumesConsig As Controles.Text_SoNumeros
	Friend WithEvents txtFreteValorConsig As Controles.Text_Monetario
	Friend WithEvents cmbIDTransportadoraConsig As Controles.ComboBox_OnlyValues
	Friend WithEvents cmbFreteTipoConsig As Controles.ComboBox_OnlyValues
	Private WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
	Friend WithEvents lblTotalProdutosComprados As Label
	Friend WithEvents Label27 As Label
	Friend WithEvents btnGerarConsignacao As VIBlend.WinForms.Controls.vButton
	Friend WithEvents lblTotalProdutosDev As Label
	Friend WithEvents Label37 As Label
	Friend WithEvents pnlNota As Panel
	Friend WithEvents txtChaveAcesso As TextBox
	Friend WithEvents btnNotaCancel As Button
	Friend WithEvents btnNotaOK As Button
	Friend WithEvents lblNota As Label
	Friend WithEvents Label23 As Label
	Friend WithEvents Label25 As Label
	Friend WithEvents Label24 As Label
	Friend WithEvents Label22 As Label
	Friend WithEvents Label21 As Label
	Friend WithEvents Label16 As Label
	Friend WithEvents txtNotaValor As Controles.Text_Monetario
	Friend WithEvents txtEmissaoData As Controles.MaskText_Data
	Friend WithEvents txtNotaNumero As Controles.Text_SoNumeros
	Friend WithEvents txtNotaSerie As Controles.Text_SoNumeros
	Friend WithEvents cmbNotaTipo As Controles.ComboBox_OnlyValues
	Friend WithEvents Label11 As Label
	Friend WithEvents dgvNotas As DataGridView
	Friend WithEvents clnChaveAcesso As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaTipo As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaSerie As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaNumero As DataGridViewTextBoxColumn
	Friend WithEvents clnEmissaoData As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaValor As DataGridViewTextBoxColumn
	Friend WithEvents clnRGProdutoCompra As DataGridViewTextBoxColumn
	Friend WithEvents clnProdutoCompra As DataGridViewTextBoxColumn
	Friend WithEvents clnQuantidadeCompra As DataGridViewTextBoxColumn
	Friend WithEvents clnPrecoCompra As DataGridViewTextBoxColumn
	Friend WithEvents clnDescontroCompra As DataGridViewTextBoxColumn
	Friend WithEvents clnTotalCompra As DataGridViewTextBoxColumn
	Friend WithEvents Label20 As Label
	Friend WithEvents lblTotalProdutosConsig As Label
	Friend WithEvents Label36 As Label
	Friend WithEvents Label19 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents txtDescontos As Controles.Text_Monetario
	Friend WithEvents txtICMSValor As Controles.Text_Monetario
	Friend WithEvents Label5 As Label
	Friend WithEvents txtDespesas As Controles.Text_Monetario
	Friend WithEvents txtFreteCobrado As Controles.Text_Monetario
	Friend WithEvents Label1 As Label
	Friend WithEvents clnCobrancaForma As DataGridViewTextBoxColumn
	Friend WithEvents clnIdentificador As DataGridViewTextBoxColumn
	Friend WithEvents clnVencimento As DataGridViewTextBoxColumn
	Friend WithEvents clnAPagarValor As DataGridViewTextBoxColumn
	Friend WithEvents lblTotalAPagar As Label
	Friend WithEvents Label35 As Label
	Friend WithEvents btnCompraData As VIBlend.WinForms.Controls.vArrowButton
	Friend WithEvents lblCompraData As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents btnDevolucaoData As VIBlend.WinForms.Controls.vArrowButton
	Friend WithEvents Label38 As Label
	Friend WithEvents Label39 As Label
End Class
