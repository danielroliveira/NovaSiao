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
		Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.tabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
		Me.vtabProdutos = New VIBlend.WinForms.Controls.vTabPage()
		Me.dgvItens = New System.Windows.Forms.DataGridView()
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
		Me.lblTotalProdutos = New System.Windows.Forms.Label()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.btnTransportadoraAdd = New System.Windows.Forms.Button()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtObservacao = New System.Windows.Forms.TextBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.txtDescontos = New Controles.Text_Monetario()
		Me.txtDespesas = New Controles.Text_Monetario()
		Me.txtICMSValor = New Controles.Text_Monetario()
		Me.txtFreteCobrado = New Controles.Text_Monetario()
		Me.txtVolumes = New Controles.Text_SoNumeros()
		Me.txtFreteValor = New Controles.Text_Monetario()
		Me.cmbIDTransportadora = New Controles.ComboBox_OnlyValues()
		Me.cmbFreteTipo = New Controles.ComboBox_OnlyValues()
		Me.vtabCompra = New VIBlend.WinForms.Controls.vTabPage()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.vtabDevolução = New VIBlend.WinForms.Controls.vTabPage()
		Me.dgvDevolucao = New System.Windows.Forms.DataGridView()
		Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.vtabNotas = New VIBlend.WinForms.Controls.vTabPage()
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
		Me.dgvNotas = New System.Windows.Forms.DataGridView()
		Me.clnChaveAcesso = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnEmissaoData = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNotaValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.VButton2 = New VIBlend.WinForms.Controls.vButton()
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
		Me.lblTotalGeral = New System.Windows.Forms.Label()
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
		Me.btnData = New VIBlend.WinForms.Controls.vArrowButton()
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
		Me.vtabAPagar = New VIBlend.WinForms.Controls.vTabPage()
		Me.vtabFreteDevolucao = New VIBlend.WinForms.Controls.vTabPage()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.lblTotalCobrado = New System.Windows.Forms.Label()
		Me.Label26 = New System.Windows.Forms.Label()
		Me.Label28 = New System.Windows.Forms.Label()
		Me.lblCobrancaTipo = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label29 = New System.Windows.Forms.Label()
		Me.Label30 = New System.Windows.Forms.Label()
		Me.Label31 = New System.Windows.Forms.Label()
		Me.Label32 = New System.Windows.Forms.Label()
		Me.Label33 = New System.Windows.Forms.Label()
		Me.Label34 = New System.Windows.Forms.Label()
		Me.ShapeContainer4 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.Text_SoNumeros1 = New Controles.Text_SoNumeros()
		Me.Text_Monetario1 = New Controles.Text_Monetario()
		Me.ComboBox_OnlyValues1 = New Controles.ComboBox_OnlyValues()
		Me.ComboBox_OnlyValues2 = New Controles.ComboBox_OnlyValues()
		Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvAPagar = New System.Windows.Forms.DataGridView()
		Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnIDItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Panel1.SuspendLayout()
		Me.tabPrincipal.SuspendLayout()
		Me.vtabProdutos.SuspendLayout()
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtabFrete.SuspendLayout()
		Me.vtabCompra.SuspendLayout()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtabDevolução.SuspendLayout()
		CType(Me.dgvDevolucao, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtabNotas.SuspendLayout()
		Me.pnlNota.SuspendLayout()
		CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.cmsMenuAPagar.SuspendLayout()
		Me.mnuAcao.SuspendLayout()
		Me.vtabAPagar.SuspendLayout()
		Me.vtabFreteDevolucao.SuspendLayout()
		CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnData)
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
		Me.Panel1.Controls.SetChildIndex(Me.btnData, 0)
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
		Me.tabPrincipal.Controls.Add(Me.vtabDevolução)
		Me.tabPrincipal.Controls.Add(Me.vtabFreteDevolucao)
		Me.tabPrincipal.Controls.Add(Me.vtabNotas)
		Me.tabPrincipal.ForeColor = System.Drawing.Color.Black
		Me.tabPrincipal.Location = New System.Drawing.Point(9, 106)
		Me.tabPrincipal.Name = "tabPrincipal"
		Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 38, 0, 0)
		Me.tabPrincipal.Size = New System.Drawing.Size(1180, 500)
		Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
		Me.tabPrincipal.TabIndex = 2
		Me.tabPrincipal.TabPages.Add(Me.vtabProdutos)
		Me.tabPrincipal.TabPages.Add(Me.vtabFrete)
		Me.tabPrincipal.TabPages.Add(Me.vtabCompra)
		Me.tabPrincipal.TabPages.Add(Me.vtabAPagar)
		Me.tabPrincipal.TabPages.Add(Me.vtabDevolução)
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
		Me.vtabProdutos.Controls.Add(Me.dgvItens)
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
		'dgvItens
		'
		Me.dgvItens.AllowUserToAddRows = False
		Me.dgvItens.AllowUserToDeleteRows = False
		DataGridViewCellStyle14.BackColor = System.Drawing.Color.Azure
		Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
		Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
		Me.dgvItens.ColumnHeadersHeight = 25
		Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDTransacaoItem, Me.clnRGProduto, Me.clnProduto, Me.clnQuantidade, Me.clnPreco, Me.clnSubTotal, Me.clnDesconto, Me.clnTotal, Me.clnICMS, Me.clnST, Me.clnMVA, Me.clnIPI})
		Me.dgvItens.EnableHeadersVisualStyles = False
		Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvItens.Location = New System.Drawing.Point(9, 9)
		Me.dgvItens.Name = "dgvItens"
		Me.dgvItens.ReadOnly = True
		Me.dgvItens.RowHeadersWidth = 30
		Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvItens.Size = New System.Drawing.Size(1162, 444)
		Me.dgvItens.TabIndex = 0
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
		Me.vtabFrete.Controls.Add(Me.lblTotalProdutos)
		Me.vtabFrete.Controls.Add(Me.Label27)
		Me.vtabFrete.Controls.Add(Me.btnTransportadoraAdd)
		Me.vtabFrete.Controls.Add(Me.Label20)
		Me.vtabFrete.Controls.Add(Me.Label19)
		Me.vtabFrete.Controls.Add(Me.Label5)
		Me.vtabFrete.Controls.Add(Me.Label2)
		Me.vtabFrete.Controls.Add(Me.Label1)
		Me.vtabFrete.Controls.Add(Me.txtObservacao)
		Me.vtabFrete.Controls.Add(Me.Label12)
		Me.vtabFrete.Controls.Add(Me.Label14)
		Me.vtabFrete.Controls.Add(Me.Label10)
		Me.vtabFrete.Controls.Add(Me.Label9)
		Me.vtabFrete.Controls.Add(Me.Label8)
		Me.vtabFrete.Controls.Add(Me.Label7)
		Me.vtabFrete.Controls.Add(Me.ShapeContainer2)
		Me.vtabFrete.Controls.Add(Me.txtDescontos)
		Me.vtabFrete.Controls.Add(Me.txtDespesas)
		Me.vtabFrete.Controls.Add(Me.txtICMSValor)
		Me.vtabFrete.Controls.Add(Me.txtFreteCobrado)
		Me.vtabFrete.Controls.Add(Me.txtVolumes)
		Me.vtabFrete.Controls.Add(Me.txtFreteValor)
		Me.vtabFrete.Controls.Add(Me.cmbIDTransportadora)
		Me.vtabFrete.Controls.Add(Me.cmbFreteTipo)
		Me.vtabFrete.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabFrete.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFrete.Location = New System.Drawing.Point(0, 38)
		Me.vtabFrete.Name = "vtabFrete"
		Me.vtabFrete.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabFrete.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFrete.Size = New System.Drawing.Size(1180, 462)
		Me.vtabFrete.TabIndex = 1
		Me.vtabFrete.Text = "Frete e Despesas"
		Me.vtabFrete.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFrete.TooltipText = "TabPage"
		Me.vtabFrete.UseDefaultTextFont = False
		Me.vtabFrete.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabFrete.Visible = False
		'
		'lblTotalProdutos
		'
		Me.lblTotalProdutos.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalProdutos.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalProdutos.Location = New System.Drawing.Point(995, 406)
		Me.lblTotalProdutos.Margin = New System.Windows.Forms.Padding(0)
		Me.lblTotalProdutos.Name = "lblTotalProdutos"
		Me.lblTotalProdutos.Size = New System.Drawing.Size(151, 32)
		Me.lblTotalProdutos.TabIndex = 17
		Me.lblTotalProdutos.Text = "R$ 0,00"
		Me.lblTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label27
		'
		Me.Label27.AutoSize = True
		Me.Label27.BackColor = System.Drawing.Color.Transparent
		Me.Label27.Location = New System.Drawing.Point(855, 411)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(134, 19)
		Me.Label27.TabIndex = 18
		Me.Label27.Text = "Valor dos Produtos:"
		'
		'btnTransportadoraAdd
		'
		Me.btnTransportadoraAdd.FlatAppearance.BorderSize = 0
		Me.btnTransportadoraAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnTransportadoraAdd.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.btnTransportadoraAdd.Location = New System.Drawing.Point(443, 200)
		Me.btnTransportadoraAdd.Name = "btnTransportadoraAdd"
		Me.btnTransportadoraAdd.Size = New System.Drawing.Size(28, 27)
		Me.btnTransportadoraAdd.TabIndex = 16
		Me.btnTransportadoraAdd.TabStop = False
		Me.btnTransportadoraAdd.UseVisualStyleBackColor = True
		'
		'Label20
		'
		Me.Label20.AutoSize = True
		Me.Label20.BackColor = System.Drawing.Color.Transparent
		Me.Label20.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label20.Location = New System.Drawing.Point(20, 15)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(158, 26)
		Me.Label20.TabIndex = 13
		Me.Label20.Text = "Outras Despesas:"
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Location = New System.Drawing.Point(288, 87)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(77, 19)
		Me.Label19.TabIndex = 9
		Me.Label19.Text = "Descontos"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Location = New System.Drawing.Point(23, 87)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(120, 19)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "Outras Despesas"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Location = New System.Drawing.Point(265, 54)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(100, 19)
		Me.Label2.TabIndex = 9
		Me.Label2.Text = "ICMS Cobrado"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Location = New System.Drawing.Point(43, 54)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(100, 19)
		Me.Label1.TabIndex = 9
		Me.Label1.Text = "Frete Cobrado"
		'
		'txtObservacao
		'
		Me.txtObservacao.Location = New System.Drawing.Point(40, 329)
		Me.txtObservacao.Multiline = True
		Me.txtObservacao.Name = "txtObservacao"
		Me.txtObservacao.Size = New System.Drawing.Size(431, 109)
		Me.txtObservacao.TabIndex = 8
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.Location = New System.Drawing.Point(20, 290)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(234, 26)
		Me.Label12.TabIndex = 15
		Me.Label12.Text = "Observações Importantes:"
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.BackColor = System.Drawing.Color.Transparent
		Me.Label14.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.Location = New System.Drawing.Point(20, 130)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(62, 26)
		Me.Label14.TabIndex = 13
		Me.Label14.Text = "Frete:"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Location = New System.Drawing.Point(264, 237)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(64, 19)
		Me.Label10.TabIndex = 8
		Me.Label10.Text = "Volumes"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Location = New System.Drawing.Point(44, 237)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(99, 19)
		Me.Label9.TabIndex = 9
		Me.Label9.Text = "Valor do Frete"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Location = New System.Drawing.Point(36, 204)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(107, 19)
		Me.Label8.TabIndex = 10
		Me.Label8.Text = "Transportadora"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Location = New System.Drawing.Point(49, 171)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(94, 19)
		Me.Label7.TabIndex = 11
		Me.Label7.Text = "Tipo de Frete"
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
		'txtDescontos
		'
		Me.txtDescontos.Location = New System.Drawing.Point(371, 84)
		Me.txtDescontos.Name = "txtDescontos"
		Me.txtDescontos.Size = New System.Drawing.Size(100, 27)
		Me.txtDescontos.SomentePositivos = True
		Me.txtDescontos.TabIndex = 3
		Me.txtDescontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtDespesas
		'
		Me.txtDespesas.Location = New System.Drawing.Point(149, 84)
		Me.txtDespesas.Name = "txtDespesas"
		Me.txtDespesas.Size = New System.Drawing.Size(100, 27)
		Me.txtDespesas.SomentePositivos = True
		Me.txtDespesas.TabIndex = 2
		Me.txtDespesas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtICMSValor
		'
		Me.txtICMSValor.Location = New System.Drawing.Point(371, 51)
		Me.txtICMSValor.Name = "txtICMSValor"
		Me.txtICMSValor.Size = New System.Drawing.Size(100, 27)
		Me.txtICMSValor.SomentePositivos = True
		Me.txtICMSValor.TabIndex = 1
		Me.txtICMSValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtFreteCobrado
		'
		Me.txtFreteCobrado.Location = New System.Drawing.Point(149, 51)
		Me.txtFreteCobrado.Name = "txtFreteCobrado"
		Me.txtFreteCobrado.Size = New System.Drawing.Size(100, 27)
		Me.txtFreteCobrado.SomentePositivos = True
		Me.txtFreteCobrado.TabIndex = 0
		Me.txtFreteCobrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtVolumes
		'
		Me.txtVolumes.Inteiro = True
		Me.txtVolumes.Location = New System.Drawing.Point(334, 234)
		Me.txtVolumes.Name = "txtVolumes"
		Me.txtVolumes.Size = New System.Drawing.Size(49, 27)
		Me.txtVolumes.TabIndex = 7
		Me.txtVolumes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtFreteValor
		'
		Me.txtFreteValor.Location = New System.Drawing.Point(149, 234)
		Me.txtFreteValor.Name = "txtFreteValor"
		Me.txtFreteValor.Size = New System.Drawing.Size(100, 27)
		Me.txtFreteValor.SomentePositivos = True
		Me.txtFreteValor.TabIndex = 6
		Me.txtFreteValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'cmbIDTransportadora
		'
		Me.cmbIDTransportadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbIDTransportadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbIDTransportadora.FormattingEnabled = True
		Me.cmbIDTransportadora.Location = New System.Drawing.Point(149, 201)
		Me.cmbIDTransportadora.Name = "cmbIDTransportadora"
		Me.cmbIDTransportadora.RestrictContentToListItems = True
		Me.cmbIDTransportadora.Size = New System.Drawing.Size(288, 27)
		Me.cmbIDTransportadora.TabIndex = 5
		'
		'cmbFreteTipo
		'
		Me.cmbFreteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbFreteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbFreteTipo.FormattingEnabled = True
		Me.cmbFreteTipo.Location = New System.Drawing.Point(149, 168)
		Me.cmbFreteTipo.Name = "cmbFreteTipo"
		Me.cmbFreteTipo.RestrictContentToListItems = True
		Me.cmbFreteTipo.Size = New System.Drawing.Size(149, 27)
		Me.cmbFreteTipo.TabIndex = 4
		'
		'vtabCompra
		'
		Me.vtabCompra.Controls.Add(Me.DataGridView1)
		Me.vtabCompra.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabCompra.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabCompra.Location = New System.Drawing.Point(0, 38)
		Me.vtabCompra.Name = "vtabCompra"
		Me.vtabCompra.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabCompra.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabCompra.Size = New System.Drawing.Size(1180, 462)
		Me.vtabCompra.TabIndex = 2
		Me.vtabCompra.Text = "Aquisições"
		Me.vtabCompra.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabCompra.TooltipText = "TabPage"
		Me.vtabCompra.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabCompra.Visible = False
		'
		'DataGridView1
		'
		Me.DataGridView1.AllowUserToAddRows = False
		Me.DataGridView1.AllowUserToDeleteRows = False
		DataGridViewCellStyle16.BackColor = System.Drawing.Color.Azure
		Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
		Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle17.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
		Me.DataGridView1.ColumnHeadersHeight = 25
		Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDItem, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35})
		DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle18.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.SteelBlue
		DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
		DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle18
		Me.DataGridView1.EnableHeadersVisualStyles = False
		Me.DataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.DataGridView1.Location = New System.Drawing.Point(9, 9)
		Me.DataGridView1.Margin = New System.Windows.Forms.Padding(10)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.ReadOnly = True
		DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle19.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
		DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
		Me.DataGridView1.RowHeadersWidth = 30
		Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.DataGridView1.Size = New System.Drawing.Size(825, 332)
		Me.DataGridView1.TabIndex = 5
		'
		'vtabDevolução
		'
		Me.vtabDevolução.Controls.Add(Me.dgvDevolucao)
		Me.vtabDevolução.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabDevolução.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabDevolução.Location = New System.Drawing.Point(0, 38)
		Me.vtabDevolução.Name = "vtabDevolução"
		Me.vtabDevolução.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabDevolução.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
		Me.vtabDevolução.Size = New System.Drawing.Size(1180, 462)
		Me.vtabDevolução.TabIndex = 4
		Me.vtabDevolução.Text = "Devolução"
		Me.vtabDevolução.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabDevolução.TooltipText = "Devolução de Consignação"
		Me.vtabDevolução.UseDefaultTextFont = False
		Me.vtabDevolução.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabDevolução.Visible = False
		'
		'dgvDevolucao
		'
		Me.dgvDevolucao.AllowUserToAddRows = False
		Me.dgvDevolucao.AllowUserToDeleteRows = False
		DataGridViewCellStyle20.BackColor = System.Drawing.Color.Azure
		Me.dgvDevolucao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle20
		Me.dgvDevolucao.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvDevolucao.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvDevolucao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvDevolucao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle21.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle21.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvDevolucao.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
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
		'vtabNotas
		'
		Me.vtabNotas.Controls.Add(Me.pnlNota)
		Me.vtabNotas.Controls.Add(Me.Label11)
		Me.vtabNotas.Controls.Add(Me.dgvNotas)
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
		Me.pnlNota.Location = New System.Drawing.Point(882, 46)
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
		Me.txtChaveAcesso.TabIndex = 0
		'
		'btnNotaCancel
		'
		Me.btnNotaCancel.ForeColor = System.Drawing.Color.Maroon
		Me.btnNotaCancel.Location = New System.Drawing.Point(144, 296)
		Me.btnNotaCancel.Name = "btnNotaCancel"
		Me.btnNotaCancel.Size = New System.Drawing.Size(113, 38)
		Me.btnNotaCancel.TabIndex = 7
		Me.btnNotaCancel.Text = "Cancelar"
		Me.btnNotaCancel.UseVisualStyleBackColor = True
		'
		'btnNotaOK
		'
		Me.btnNotaOK.ForeColor = System.Drawing.Color.DarkGreen
		Me.btnNotaOK.Location = New System.Drawing.Point(25, 296)
		Me.btnNotaOK.Name = "btnNotaOK"
		Me.btnNotaOK.Size = New System.Drawing.Size(113, 38)
		Me.btnNotaOK.TabIndex = 6
		Me.btnNotaOK.Text = "Inserir"
		Me.btnNotaOK.UseVisualStyleBackColor = True
		'
		'lblNota
		'
		Me.lblNota.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNota.Location = New System.Drawing.Point(20, 7)
		Me.lblNota.Name = "lblNota"
		Me.lblNota.Size = New System.Drawing.Size(245, 26)
		Me.lblNota.TabIndex = 7
		Me.lblNota.Text = "Inserindo Nota Fiscal"
		Me.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.Location = New System.Drawing.Point(143, 179)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(60, 19)
		Me.Label23.TabIndex = 6
		Me.Label23.Text = "Número"
		'
		'Label25
		'
		Me.Label25.AutoSize = True
		Me.Label25.Location = New System.Drawing.Point(143, 231)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(78, 19)
		Me.Label25.TabIndex = 6
		Me.Label25.Text = "Valor Total"
		'
		'Label24
		'
		Me.Label24.AutoSize = True
		Me.Label24.Location = New System.Drawing.Point(25, 231)
		Me.Label24.Name = "Label24"
		Me.Label24.Size = New System.Drawing.Size(86, 19)
		Me.Label24.TabIndex = 6
		Me.Label24.Text = "Dt. Emissão"
		'
		'Label22
		'
		Me.Label22.AutoSize = True
		Me.Label22.Location = New System.Drawing.Point(25, 179)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(41, 19)
		Me.Label22.TabIndex = 6
		Me.Label22.Text = "Série"
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(25, 127)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(72, 19)
		Me.Label21.TabIndex = 6
		Me.Label21.Text = "Nota Tipo"
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(25, 44)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(119, 19)
		Me.Label16.TabIndex = 6
		Me.Label16.Text = "Chave de Acesso"
		'
		'txtNotaValor
		'
		Me.txtNotaValor.Location = New System.Drawing.Point(147, 253)
		Me.txtNotaValor.Name = "txtNotaValor"
		Me.txtNotaValor.Size = New System.Drawing.Size(110, 27)
		Me.txtNotaValor.SomentePositivos = True
		Me.txtNotaValor.TabIndex = 5
		Me.txtNotaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtEmissaoData
		'
		Me.txtEmissaoData.Location = New System.Drawing.Point(25, 253)
		Me.txtEmissaoData.Mask = "00/00/0000"
		Me.txtEmissaoData.Name = "txtEmissaoData"
		Me.txtEmissaoData.Size = New System.Drawing.Size(100, 27)
		Me.txtEmissaoData.TabIndex = 4
		'
		'txtNotaNumero
		'
		Me.txtNotaNumero.Inteiro = True
		Me.txtNotaNumero.Location = New System.Drawing.Point(147, 201)
		Me.txtNotaNumero.MaxLength = 12
		Me.txtNotaNumero.Name = "txtNotaNumero"
		Me.txtNotaNumero.Size = New System.Drawing.Size(110, 27)
		Me.txtNotaNumero.TabIndex = 3
		Me.txtNotaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtNotaSerie
		'
		Me.txtNotaSerie.Inteiro = True
		Me.txtNotaSerie.Location = New System.Drawing.Point(25, 201)
		Me.txtNotaSerie.MaxLength = 4
		Me.txtNotaSerie.Name = "txtNotaSerie"
		Me.txtNotaSerie.Size = New System.Drawing.Size(68, 27)
		Me.txtNotaSerie.TabIndex = 2
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
		Me.cmbNotaTipo.TabIndex = 1
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Location = New System.Drawing.Point(26, 17)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(185, 19)
		Me.Label11.TabIndex = 4
		Me.Label11.Text = "Notas e/ou Cupons Fiscais:"
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
		DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.ButtonFace
		DataGridViewCellStyle22.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvNotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
		Me.dgvNotas.ColumnHeadersHeight = 30
		Me.dgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dgvNotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnChaveAcesso, Me.clnNotaTipo, Me.clnNotaSerie, Me.clnNotaNumero, Me.clnEmissaoData, Me.clnNotaValor})
		Me.dgvNotas.EnableHeadersVisualStyles = False
		Me.dgvNotas.Location = New System.Drawing.Point(20, 46)
		Me.dgvNotas.Name = "dgvNotas"
		Me.dgvNotas.ReadOnly = True
		Me.dgvNotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		DataGridViewCellStyle23.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgvNotas.RowsDefaultCellStyle = DataGridViewCellStyle23
		Me.dgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvNotas.Size = New System.Drawing.Size(846, 312)
		Me.dgvNotas.TabIndex = 3
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
		'VButton2
		'
		Me.VButton2.AllowAnimations = True
		Me.VButton2.BackColor = System.Drawing.Color.Transparent
		Me.VButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.VButton2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.VButton2.HoverEffectsEnabled = True
		Me.VButton2.Image = Global.NovaSiao.My.Resources.Resources.upload_button
		Me.VButton2.ImageAbsolutePosition = New System.Drawing.Point(20, 5)
		Me.VButton2.Location = New System.Drawing.Point(678, 612)
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
		Me.lblCli.TabIndex = 6
		Me.lblCli.Text = "Fornecedor:"
		'
		'lblFornecedor
		'
		Me.lblFornecedor.BackColor = System.Drawing.Color.White
		Me.lblFornecedor.Location = New System.Drawing.Point(115, 67)
		Me.lblFornecedor.Name = "lblFornecedor"
		Me.lblFornecedor.Size = New System.Drawing.Size(614, 25)
		Me.lblFornecedor.TabIndex = 1
		Me.lblFornecedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ShapeContainer1
		'
		Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
		Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer1.Name = "ShapeContainer1"
		Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
		Me.ShapeContainer1.Size = New System.Drawing.Size(1200, 661)
		Me.ShapeContainer1.TabIndex = 11
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
		'lblTotalGeral
		'
		Me.lblTotalGeral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalGeral.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalGeral.Location = New System.Drawing.Point(968, 618)
		Me.lblTotalGeral.Margin = New System.Windows.Forms.Padding(0)
		Me.lblTotalGeral.Name = "lblTotalGeral"
		Me.lblTotalGeral.Size = New System.Drawing.Size(187, 32)
		Me.lblTotalGeral.TabIndex = 12
		Me.lblTotalGeral.Text = "R$ 0,00"
		Me.lblTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(878, 624)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(84, 19)
		Me.Label13.TabIndex = 13
		Me.Label13.Text = "Total Geral:"
		'
		'lblSituacao
		'
		Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
		Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblSituacao.Location = New System.Drawing.Point(512, 16)
		Me.lblSituacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblSituacao.Name = "lblSituacao"
		Me.lblSituacao.Size = New System.Drawing.Size(145, 30)
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
		Me.btnFinalizar.Location = New System.Drawing.Point(529, 612)
		Me.btnFinalizar.Name = "btnFinalizar"
		Me.btnFinalizar.Opacity = 0!
		Me.btnFinalizar.RoundedCornersMask = CType(15, Byte)
		Me.btnFinalizar.RoundedCornersRadius = 5
		Me.btnFinalizar.Size = New System.Drawing.Size(143, 42)
		Me.btnFinalizar.TabIndex = 3
		Me.btnFinalizar.Text = "&Finalizar"
		Me.btnFinalizar.TextAbsolutePosition = New System.Drawing.Point(20, 1)
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
		Me.mnuAcao.TabIndex = 17
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
		'btnData
		'
		Me.btnData.AllowAnimations = True
		Me.btnData.ArrowDirection = System.Windows.Forms.ArrowDirection.Left
		Me.btnData.Location = New System.Drawing.Point(269, 24)
		Me.btnData.Maximum = 100
		Me.btnData.Minimum = 0
		Me.btnData.Name = "btnData"
		Me.btnData.Size = New System.Drawing.Size(16, 16)
		Me.btnData.TabIndex = 57
		Me.btnData.TabStop = False
		Me.btnData.Value = 0
		Me.btnData.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
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
		DataGridViewCellStyle24.Format = "C2"
		DataGridViewCellStyle24.NullValue = "0"
		Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle24
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
		'vtabAPagar
		'
		Me.vtabAPagar.Controls.Add(Me.Label4)
		Me.vtabAPagar.Controls.Add(Me.Label6)
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
		Me.vtabAPagar.TabIndex = 3
		Me.vtabAPagar.Text = "Pagamentos"
		Me.vtabAPagar.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabAPagar.TooltipText = "TabPage"
		Me.vtabAPagar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabAPagar.Visible = False
		'
		'vtabFreteDevolucao
		'
		Me.vtabFreteDevolucao.Controls.Add(Me.Button1)
		Me.vtabFreteDevolucao.Controls.Add(Me.TextBox1)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label29)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label30)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label31)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label32)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label33)
		Me.vtabFreteDevolucao.Controls.Add(Me.Label34)
		Me.vtabFreteDevolucao.Controls.Add(Me.Text_SoNumeros1)
		Me.vtabFreteDevolucao.Controls.Add(Me.Text_Monetario1)
		Me.vtabFreteDevolucao.Controls.Add(Me.ComboBox_OnlyValues1)
		Me.vtabFreteDevolucao.Controls.Add(Me.ComboBox_OnlyValues2)
		Me.vtabFreteDevolucao.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtabFreteDevolucao.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFreteDevolucao.Location = New System.Drawing.Point(0, 38)
		Me.vtabFreteDevolucao.Name = "vtabFreteDevolucao"
		Me.vtabFreteDevolucao.Padding = New System.Windows.Forms.Padding(0)
		Me.vtabFreteDevolucao.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFreteDevolucao.Size = New System.Drawing.Size(1180, 462)
		Me.vtabFreteDevolucao.TabIndex = 5
		Me.vtabFreteDevolucao.Text = "Frete Saída"
		Me.vtabFreteDevolucao.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtabFreteDevolucao.TooltipText = "TabPage"
		Me.vtabFreteDevolucao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtabFreteDevolucao.Visible = False
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Location = New System.Drawing.Point(271, 270)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(126, 19)
		Me.Label4.TabIndex = 32
		Me.Label4.Text = "Tipo de Cobrança:"
		'
		'Label6
		'
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label6.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(403, 351)
		Me.Label6.Margin = New System.Windows.Forms.Padding(0)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(151, 32)
		Me.Label6.TabIndex = 30
		Me.Label6.Text = "R$ 0,00"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.BackColor = System.Drawing.Color.Transparent
		Me.Label17.Location = New System.Drawing.Point(263, 356)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(134, 19)
		Me.Label17.TabIndex = 33
		Me.Label17.Text = "Valor dos Produtos:"
		'
		'lblTotalCobrado
		'
		Me.lblTotalCobrado.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalCobrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalCobrado.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalCobrado.Location = New System.Drawing.Point(403, 309)
		Me.lblTotalCobrado.Name = "lblTotalCobrado"
		Me.lblTotalCobrado.Size = New System.Drawing.Size(151, 32)
		Me.lblTotalCobrado.TabIndex = 31
		Me.lblTotalCobrado.Text = "R$ 0,00"
		Me.lblTotalCobrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label26
		'
		Me.Label26.AutoSize = True
		Me.Label26.BackColor = System.Drawing.Color.Transparent
		Me.Label26.Location = New System.Drawing.Point(294, 314)
		Me.Label26.Name = "Label26"
		Me.Label26.Size = New System.Drawing.Size(103, 19)
		Me.Label26.TabIndex = 34
		Me.Label26.Text = "Total Cobrado:"
		'
		'Label28
		'
		Me.Label28.AutoSize = True
		Me.Label28.BackColor = System.Drawing.Color.Transparent
		Me.Label28.Font = New System.Drawing.Font("Calibri", 15.75!)
		Me.Label28.Location = New System.Drawing.Point(18, 15)
		Me.Label28.Name = "Label28"
		Me.Label28.Size = New System.Drawing.Size(264, 26)
		Me.Label28.TabIndex = 27
		Me.Label28.Text = "Desdobramento das Parcelas:"
		'
		'lblCobrancaTipo
		'
		Me.lblCobrancaTipo.BackColor = System.Drawing.Color.Transparent
		Me.lblCobrancaTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCobrancaTipo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCobrancaTipo.Location = New System.Drawing.Point(403, 266)
		Me.lblCobrancaTipo.Name = "lblCobrancaTipo"
		Me.lblCobrancaTipo.Size = New System.Drawing.Size(151, 32)
		Me.lblCobrancaTipo.TabIndex = 28
		Me.lblCobrancaTipo.Text = "Tipo de Cobrança"
		Me.lblCobrancaTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Button1
		'
		Me.Button1.FlatAppearance.BorderSize = 0
		Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.Button1.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.Button1.Location = New System.Drawing.Point(444, 86)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(28, 27)
		Me.Button1.TabIndex = 28
		Me.Button1.TabStop = False
		Me.Button1.UseVisualStyleBackColor = True
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(41, 215)
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(431, 109)
		Me.TextBox1.TabIndex = 21
		'
		'Label29
		'
		Me.Label29.AutoSize = True
		Me.Label29.BackColor = System.Drawing.Color.Transparent
		Me.Label29.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label29.Location = New System.Drawing.Point(21, 176)
		Me.Label29.Name = "Label29"
		Me.Label29.Size = New System.Drawing.Size(219, 26)
		Me.Label29.TabIndex = 27
		Me.Label29.Text = "Observações Devolução:"
		'
		'Label30
		'
		Me.Label30.AutoSize = True
		Me.Label30.BackColor = System.Drawing.Color.Transparent
		Me.Label30.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label30.Location = New System.Drawing.Point(21, 16)
		Me.Label30.Name = "Label30"
		Me.Label30.Size = New System.Drawing.Size(156, 26)
		Me.Label30.TabIndex = 26
		Me.Label30.Text = "Frete Devolução:"
		'
		'Label31
		'
		Me.Label31.AutoSize = True
		Me.Label31.BackColor = System.Drawing.Color.Transparent
		Me.Label31.Location = New System.Drawing.Point(265, 123)
		Me.Label31.Name = "Label31"
		Me.Label31.Size = New System.Drawing.Size(64, 19)
		Me.Label31.TabIndex = 22
		Me.Label31.Text = "Volumes"
		'
		'Label32
		'
		Me.Label32.AutoSize = True
		Me.Label32.BackColor = System.Drawing.Color.Transparent
		Me.Label32.Location = New System.Drawing.Point(45, 123)
		Me.Label32.Name = "Label32"
		Me.Label32.Size = New System.Drawing.Size(99, 19)
		Me.Label32.TabIndex = 23
		Me.Label32.Text = "Valor do Frete"
		'
		'Label33
		'
		Me.Label33.AutoSize = True
		Me.Label33.BackColor = System.Drawing.Color.Transparent
		Me.Label33.Location = New System.Drawing.Point(37, 90)
		Me.Label33.Name = "Label33"
		Me.Label33.Size = New System.Drawing.Size(107, 19)
		Me.Label33.TabIndex = 24
		Me.Label33.Text = "Transportadora"
		'
		'Label34
		'
		Me.Label34.AutoSize = True
		Me.Label34.BackColor = System.Drawing.Color.Transparent
		Me.Label34.Location = New System.Drawing.Point(50, 57)
		Me.Label34.Name = "Label34"
		Me.Label34.Size = New System.Drawing.Size(94, 19)
		Me.Label34.TabIndex = 25
		Me.Label34.Text = "Tipo de Frete"
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
		'Text_SoNumeros1
		'
		Me.Text_SoNumeros1.Inteiro = True
		Me.Text_SoNumeros1.Location = New System.Drawing.Point(335, 120)
		Me.Text_SoNumeros1.Name = "Text_SoNumeros1"
		Me.Text_SoNumeros1.Size = New System.Drawing.Size(49, 27)
		Me.Text_SoNumeros1.TabIndex = 20
		Me.Text_SoNumeros1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Text_Monetario1
		'
		Me.Text_Monetario1.Location = New System.Drawing.Point(150, 120)
		Me.Text_Monetario1.Name = "Text_Monetario1"
		Me.Text_Monetario1.Size = New System.Drawing.Size(100, 27)
		Me.Text_Monetario1.SomentePositivos = True
		Me.Text_Monetario1.TabIndex = 19
		Me.Text_Monetario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'ComboBox_OnlyValues1
		'
		Me.ComboBox_OnlyValues1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.ComboBox_OnlyValues1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.ComboBox_OnlyValues1.FormattingEnabled = True
		Me.ComboBox_OnlyValues1.Location = New System.Drawing.Point(150, 87)
		Me.ComboBox_OnlyValues1.Name = "ComboBox_OnlyValues1"
		Me.ComboBox_OnlyValues1.RestrictContentToListItems = True
		Me.ComboBox_OnlyValues1.Size = New System.Drawing.Size(288, 27)
		Me.ComboBox_OnlyValues1.TabIndex = 18
		'
		'ComboBox_OnlyValues2
		'
		Me.ComboBox_OnlyValues2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.ComboBox_OnlyValues2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.ComboBox_OnlyValues2.FormattingEnabled = True
		Me.ComboBox_OnlyValues2.Location = New System.Drawing.Point(150, 54)
		Me.ComboBox_OnlyValues2.Name = "ComboBox_OnlyValues2"
		Me.ComboBox_OnlyValues2.RestrictContentToListItems = True
		Me.ComboBox_OnlyValues2.Size = New System.Drawing.Size(149, 27)
		Me.ComboBox_OnlyValues2.TabIndex = 17
		'
		'DataGridViewTextBoxColumn40
		'
		Me.DataGridViewTextBoxColumn40.HeaderText = "Valor"
		Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
		Me.DataGridViewTextBoxColumn40.ReadOnly = True
		'
		'DataGridViewTextBoxColumn39
		'
		DataGridViewCellStyle13.Format = "C2"
		DataGridViewCellStyle13.NullValue = "0"
		Me.DataGridViewTextBoxColumn39.DefaultCellStyle = DataGridViewCellStyle13
		Me.DataGridViewTextBoxColumn39.HeaderText = "Vencimento"
		Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
		Me.DataGridViewTextBoxColumn39.ReadOnly = True
		Me.DataGridViewTextBoxColumn39.Width = 110
		'
		'DataGridViewTextBoxColumn38
		'
		Me.DataGridViewTextBoxColumn38.HeaderText = "No. Reg.:"
		Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
		Me.DataGridViewTextBoxColumn38.ReadOnly = True
		'
		'DataGridViewTextBoxColumn37
		'
		Me.DataGridViewTextBoxColumn37.HeaderText = "Forma"
		Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
		Me.DataGridViewTextBoxColumn37.ReadOnly = True
		Me.DataGridViewTextBoxColumn37.Width = 160
		'
		'DataGridViewTextBoxColumn36
		'
		Me.DataGridViewTextBoxColumn36.HeaderText = "IDAPagar"
		Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
		Me.DataGridViewTextBoxColumn36.ReadOnly = True
		Me.DataGridViewTextBoxColumn36.Visible = False
		'
		'dgvAPagar
		'
		Me.dgvAPagar.AllowUserToAddRows = False
		Me.dgvAPagar.AllowUserToDeleteRows = False
		Me.dgvAPagar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvAPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvAPagar.ColumnHeadersHeight = 30
		Me.dgvAPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40})
		Me.dgvAPagar.EnableHeadersVisualStyles = False
		Me.dgvAPagar.Location = New System.Drawing.Point(23, 51)
		Me.dgvAPagar.MultiSelect = False
		Me.dgvAPagar.Name = "dgvAPagar"
		Me.dgvAPagar.ReadOnly = True
		Me.dgvAPagar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvAPagar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvAPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvAPagar.Size = New System.Drawing.Size(549, 204)
		Me.dgvAPagar.TabIndex = 29
		'
		'DataGridViewTextBoxColumn35
		'
		Me.DataGridViewTextBoxColumn35.HeaderText = "Total"
		Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
		Me.DataGridViewTextBoxColumn35.ReadOnly = True
		'
		'DataGridViewTextBoxColumn34
		'
		Me.DataGridViewTextBoxColumn34.HeaderText = "Desc."
		Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
		Me.DataGridViewTextBoxColumn34.ReadOnly = True
		Me.DataGridViewTextBoxColumn34.Width = 70
		'
		'DataGridViewTextBoxColumn32
		'
		Me.DataGridViewTextBoxColumn32.Frozen = True
		Me.DataGridViewTextBoxColumn32.HeaderText = "Preço"
		Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
		Me.DataGridViewTextBoxColumn32.ReadOnly = True
		Me.DataGridViewTextBoxColumn32.Width = 90
		'
		'DataGridViewTextBoxColumn31
		'
		Me.DataGridViewTextBoxColumn31.Frozen = True
		Me.DataGridViewTextBoxColumn31.HeaderText = "Qtde"
		Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
		Me.DataGridViewTextBoxColumn31.ReadOnly = True
		Me.DataGridViewTextBoxColumn31.Width = 60
		'
		'DataGridViewTextBoxColumn30
		'
		Me.DataGridViewTextBoxColumn30.Frozen = True
		Me.DataGridViewTextBoxColumn30.HeaderText = "Produto"
		Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
		Me.DataGridViewTextBoxColumn30.ReadOnly = True
		Me.DataGridViewTextBoxColumn30.Width = 375
		'
		'DataGridViewTextBoxColumn29
		'
		Me.DataGridViewTextBoxColumn29.Frozen = True
		Me.DataGridViewTextBoxColumn29.HeaderText = "Reg."
		Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
		Me.DataGridViewTextBoxColumn29.ReadOnly = True
		Me.DataGridViewTextBoxColumn29.Width = 60
		'
		'clnIDItem
		'
		Me.clnIDItem.Frozen = True
		Me.clnIDItem.HeaderText = "IDItem"
		Me.clnIDItem.Name = "clnIDItem"
		Me.clnIDItem.ReadOnly = True
		Me.clnIDItem.Visible = False
		'
		'frmConsignacao
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1200, 661)
		Me.Controls.Add(Me.mnuAcao)
		Me.Controls.Add(Me.btnFinalizar)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.VButton2)
		Me.Controls.Add(Me.lblTotalGeral)
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
		Me.Controls.SetChildIndex(Me.lblTotalGeral, 0)
		Me.Controls.SetChildIndex(Me.VButton2, 0)
		Me.Controls.SetChildIndex(Me.Label13, 0)
		Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
		Me.Controls.SetChildIndex(Me.mnuAcao, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.tabPrincipal.ResumeLayout(False)
		Me.vtabProdutos.ResumeLayout(False)
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtabFrete.ResumeLayout(False)
		Me.vtabFrete.PerformLayout()
		Me.vtabCompra.ResumeLayout(False)
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtabDevolução.ResumeLayout(False)
		CType(Me.dgvDevolucao, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtabNotas.ResumeLayout(False)
		Me.vtabNotas.PerformLayout()
		Me.pnlNota.ResumeLayout(False)
		Me.pnlNota.PerformLayout()
		CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).EndInit()
		Me.cmsMenuAPagar.ResumeLayout(False)
		Me.mnuAcao.ResumeLayout(False)
		Me.mnuAcao.PerformLayout()
		Me.vtabAPagar.ResumeLayout(False)
		Me.vtabAPagar.PerformLayout()
		Me.vtabFreteDevolucao.ResumeLayout(False)
		Me.vtabFreteDevolucao.PerformLayout()
		CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
    Friend WithEvents vtabProdutos As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents vtabFrete As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents txtVolumes As Controles.Text_SoNumeros
    Friend WithEvents txtFreteValor As Controles.Text_Monetario
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbIDTransportadora As Controles.ComboBox_OnlyValues
    Friend WithEvents cmbFreteTipo As Controles.ComboBox_OnlyValues
	Friend WithEvents vtabNotas As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents Label11 As Label
	Friend WithEvents dgvNotas As DataGridView
	Friend WithEvents lblCli As Label
	Friend WithEvents lblFornecedor As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents lblIDConsignacao As Label
	Friend WithEvents lbl_IdTexto As Label
	Friend WithEvents lblConsignacaoData As Label
	Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
	Friend WithEvents lblTotalGeral As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents Label15 As Label
	Friend WithEvents lblSituacao As Label
	Friend WithEvents VApplicationMenuItem2 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents VApplicationMenuItem3 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents VApplicationMenuItem4 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents Label14 As Label
	Friend WithEvents txtObservacao As TextBox
	Friend WithEvents Label12 As Label
	Friend WithEvents btnFinalizar As VIBlend.WinForms.Controls.vButton
	Friend WithEvents Label18 As Label
	Friend WithEvents lblFilial As Label
	Friend WithEvents txtICMSValor As Controles.Text_Monetario
	Friend WithEvents Label2 As Label
	Friend WithEvents txtFreteCobrado As Controles.Text_Monetario
	Friend WithEvents Label1 As Label
	Friend WithEvents Label20 As Label
	Friend WithEvents txtDescontos As Controles.Text_Monetario
	Friend WithEvents txtDespesas As Controles.Text_Monetario
	Friend WithEvents Label19 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents pnlNota As Panel
	Friend WithEvents txtNotaValor As Controles.Text_Monetario
	Friend WithEvents txtEmissaoData As Controles.MaskText_Data
	Friend WithEvents txtNotaNumero As Controles.Text_SoNumeros
	Friend WithEvents txtNotaSerie As Controles.Text_SoNumeros
	Friend WithEvents cmbNotaTipo As Controles.ComboBox_OnlyValues
	Friend WithEvents Label23 As Label
	Friend WithEvents Label25 As Label
	Friend WithEvents Label24 As Label
	Friend WithEvents Label22 As Label
	Friend WithEvents Label21 As Label
	Friend WithEvents Label16 As Label
	Friend WithEvents lblNota As Label
	Friend WithEvents btnNotaOK As Button
	Friend WithEvents btnNotaCancel As Button
	Friend WithEvents clnChaveAcesso As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaTipo As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaSerie As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaNumero As DataGridViewTextBoxColumn
	Friend WithEvents clnEmissaoData As DataGridViewTextBoxColumn
	Friend WithEvents clnNotaValor As DataGridViewTextBoxColumn
	Friend WithEvents txtChaveAcesso As TextBox
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
	Private WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
	Private WithEvents LineShape1 As PowerPacks.LineShape
	Private WithEvents LineShape2 As PowerPacks.LineShape
	Private WithEvents LineShape3 As PowerPacks.LineShape
	Private WithEvents LineShape4 As PowerPacks.LineShape
	Friend WithEvents btnData As VIBlend.WinForms.Controls.vArrowButton
	Friend WithEvents btnExcluir As ToolStripButton
	Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
	Friend WithEvents btnTransportadoraAdd As Button
	Friend WithEvents VButton2 As VIBlend.WinForms.Controls.vButton
	Friend WithEvents vtabDevolução As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents dgvDevolucao As DataGridView
	Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
	Friend WithEvents lblTotalProdutos As Label
	Friend WithEvents Label27 As Label
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
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents vtabAPagar As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents Label4 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents Label17 As Label
	Friend WithEvents lblTotalCobrado As Label
	Friend WithEvents Label26 As Label
	Friend WithEvents Label28 As Label
	Friend WithEvents lblCobrancaTipo As Label
	Friend WithEvents vtabFreteDevolucao As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents Button1 As Button
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label29 As Label
	Friend WithEvents Label30 As Label
	Friend WithEvents Label31 As Label
	Friend WithEvents Label32 As Label
	Friend WithEvents Label33 As Label
	Friend WithEvents Label34 As Label
	Friend WithEvents Text_SoNumeros1 As Controles.Text_SoNumeros
	Friend WithEvents Text_Monetario1 As Controles.Text_Monetario
	Friend WithEvents ComboBox_OnlyValues1 As Controles.ComboBox_OnlyValues
	Friend WithEvents ComboBox_OnlyValues2 As Controles.ComboBox_OnlyValues
	Private WithEvents ShapeContainer4 As PowerPacks.ShapeContainer
	Friend WithEvents clnIDItem As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn
	Friend WithEvents dgvAPagar As DataGridView
	Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn
End Class
