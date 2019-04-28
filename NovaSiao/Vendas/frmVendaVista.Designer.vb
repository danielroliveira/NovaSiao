<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVendaVista
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
        Me.tabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
        Me.vtab1 = New VIBlend.WinForms.Controls.vTabPage()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.clnIDTransacaoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vtab2 = New VIBlend.WinForms.Controls.vTabPage()
        Me.VPanel3 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblValorProdutos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlTroca = New VIBlend.WinForms.Controls.vPanel()
        Me.lblValorDevolucao = New System.Windows.Forms.Label()
        Me.lblTroca = New System.Windows.Forms.Label()
        Me.VPanel2 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblTotalPago = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnLimparPagamentos = New System.Windows.Forms.Button()
        Me.btnTroca = New System.Windows.Forms.Button()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvPagamentos = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnMovForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.btnVendedorAlterar = New System.Windows.Forms.Button()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.btnData = New VIBlend.WinForms.Controls.vArrowButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.lblVendaData = New System.Windows.Forms.Label()
        Me.lblIDVenda = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.lblTotalGeral = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.VApplicationMenuItem2 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.VApplicationMenuItem3 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.VApplicationMenuItem4 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.btnFinalizar = New VIBlend.WinForms.Controls.vButton()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.VPanel1 = New VIBlend.WinForms.Controls.vPanel()
        Me.tspMenuAcao = New System.Windows.Forms.ToolStrip()
        Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.btnAdicionar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcluirVenda = New System.Windows.Forms.ToolStripButton()
        Me.btnDesbloquearVenda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.miImprimirEtiquetas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContexto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuItemEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuItemInserir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemExcluir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.tabPrincipal.SuspendLayout()
        Me.vtab1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vtab2.SuspendLayout()
        Me.VPanel3.Content.SuspendLayout()
        Me.VPanel3.SuspendLayout()
        Me.pnlTroca.Content.SuspendLayout()
        Me.pnlTroca.SuspendLayout()
        Me.VPanel2.Content.SuspendLayout()
        Me.VPanel2.SuspendLayout()
        CType(Me.dgvPagamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VPanel1.Content.SuspendLayout()
        Me.VPanel1.SuspendLayout()
        Me.tspMenuAcao.SuspendLayout()
        Me.mnuContexto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnData)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Controls.Add(Me.lblIDVenda)
        Me.Panel1.Controls.Add(Me.lblVendaData)
        Me.Panel1.Size = New System.Drawing.Size(1049, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblVendaData, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblIDVenda, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnData, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label15, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label4, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label3, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(684, 4)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(331, 38)
        Me.lblTitulo.Text = "Venda A Vista"
        '
        'tabPrincipal
        '
        Me.tabPrincipal.AllowAnimations = True
        Me.tabPrincipal.AllPagesHeight = 28
        Me.tabPrincipal.Controls.Add(Me.vtab1)
        Me.tabPrincipal.Controls.Add(Me.vtab2)
        Me.tabPrincipal.ForeColor = System.Drawing.Color.Black
        Me.tabPrincipal.Location = New System.Drawing.Point(9, 106)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 38, 0, 0)
        Me.tabPrincipal.Size = New System.Drawing.Size(1030, 500)
        Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
        Me.tabPrincipal.TabIndex = 4
        Me.tabPrincipal.TabPages.Add(Me.vtab1)
        Me.tabPrincipal.TabPages.Add(Me.vtab2)
        Me.tabPrincipal.TabsAreaBackColor = System.Drawing.Color.OldLace
        Me.tabPrincipal.TabsInitialOffset = 40
        Me.tabPrincipal.TabsShape = VIBlend.WinForms.Controls.TabsShape.Chrome
        Me.tabPrincipal.TabsSpacing = 10
        Me.tabPrincipal.TitleHeight = 38
        Me.tabPrincipal.UseTabsAreaBackColor = True
        Me.tabPrincipal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        '
        'vtab1
        '
        Me.vtab1.Controls.Add(Me.dgvItens)
        Me.vtab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.ForeColor = System.Drawing.Color.Black
        Me.vtab1.Location = New System.Drawing.Point(0, 38)
        Me.vtab1.Name = "vtab1"
        Me.vtab1.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab1.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.Size = New System.Drawing.Size(1030, 462)
        Me.vtab1.TabIndex = 3
        Me.vtab1.Text = "Produtos"
        Me.vtab1.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.TooltipText = "TabPage"
        Me.vtab1.UseDefaultTextFont = False
        Me.vtab1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab1.Visible = False
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItens.ColumnHeadersHeight = 30
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDTransacaoItem, Me.clnRGProduto, Me.clnProduto, Me.clnQuantidade, Me.clnPreco, Me.clnSubTotal, Me.clnDesconto, Me.clnTotal})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItens.EnableHeadersVisualStyles = False
        Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvItens.Location = New System.Drawing.Point(9, 9)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItens.RowHeadersWidth = 35
        Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvItens.Size = New System.Drawing.Size(1012, 444)
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
        Me.clnRGProduto.Width = 70
        '
        'clnProduto
        '
        Me.clnProduto.Frozen = True
        Me.clnProduto.HeaderText = "Produto"
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.ReadOnly = True
        Me.clnProduto.Width = 430
        '
        'clnQuantidade
        '
        Me.clnQuantidade.Frozen = True
        Me.clnQuantidade.HeaderText = "Qtde"
        Me.clnQuantidade.Name = "clnQuantidade"
        Me.clnQuantidade.ReadOnly = True
        Me.clnQuantidade.Width = 70
        '
        'clnPreco
        '
        Me.clnPreco.Frozen = True
        Me.clnPreco.HeaderText = "Preço"
        Me.clnPreco.Name = "clnPreco"
        Me.clnPreco.ReadOnly = True
        '
        'clnSubTotal
        '
        Me.clnSubTotal.Frozen = True
        Me.clnSubTotal.HeaderText = "SubTotal"
        Me.clnSubTotal.Name = "clnSubTotal"
        Me.clnSubTotal.ReadOnly = True
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
        '
        'vtab2
        '
        Me.vtab2.Controls.Add(Me.VPanel3)
        Me.vtab2.Controls.Add(Me.pnlTroca)
        Me.vtab2.Controls.Add(Me.VPanel2)
        Me.vtab2.Controls.Add(Me.btnLimparPagamentos)
        Me.vtab2.Controls.Add(Me.btnTroca)
        Me.vtab2.Controls.Add(Me.txtObservacao)
        Me.vtab2.Controls.Add(Me.Label12)
        Me.vtab2.Controls.Add(Me.dgvPagamentos)
        Me.vtab2.Controls.Add(Me.Label6)
        Me.vtab2.Controls.Add(Me.ShapeContainer2)
        Me.vtab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Location = New System.Drawing.Point(0, 38)
        Me.vtab2.Name = "vtab2"
        Me.vtab2.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab2.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Size = New System.Drawing.Size(1030, 462)
        Me.vtab2.TabIndex = 0
        Me.vtab2.Text = "Pagamentos"
        Me.vtab2.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.TooltipText = "TabPage"
        Me.vtab2.UseDefaultTextFont = False
        Me.vtab2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab2.Visible = False
        '
        'VPanel3
        '
        Me.VPanel3.AllowAnimations = True
        Me.VPanel3.BorderRadius = 0
        '
        'VPanel3.Content
        '
        Me.VPanel3.Content.AutoScroll = True
        Me.VPanel3.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel3.Content.Controls.Add(Me.lblValorProdutos)
        Me.VPanel3.Content.Controls.Add(Me.Label5)
        Me.VPanel3.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel3.Content.Name = "Content"
        Me.VPanel3.Content.Size = New System.Drawing.Size(212, 39)
        Me.VPanel3.Content.TabIndex = 3
        Me.VPanel3.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel3.Location = New System.Drawing.Point(809, 363)
        Me.VPanel3.Name = "VPanel3"
        Me.VPanel3.Opacity = 1.0!
        Me.VPanel3.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel3.Size = New System.Drawing.Size(214, 41)
        Me.VPanel3.TabIndex = 18
        Me.VPanel3.Text = "VPanel3"
        Me.VPanel3.UsePanelBorderColor = True
        Me.VPanel3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblValorProdutos
        '
        Me.lblValorProdutos.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblValorProdutos.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorProdutos.Location = New System.Drawing.Point(88, 0)
        Me.lblValorProdutos.Name = "lblValorProdutos"
        Me.lblValorProdutos.Size = New System.Drawing.Size(124, 39)
        Me.lblValorProdutos.TabIndex = 12
        Me.lblValorProdutos.Text = "R$ 0,00"
        Me.lblValorProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 19)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Produtos:"
        '
        'pnlTroca
        '
        Me.pnlTroca.AllowAnimations = True
        Me.pnlTroca.BorderRadius = 0
        '
        'pnlTroca.Content
        '
        Me.pnlTroca.Content.AutoScroll = True
        Me.pnlTroca.Content.BackColor = System.Drawing.SystemColors.Control
        Me.pnlTroca.Content.Controls.Add(Me.lblValorDevolucao)
        Me.pnlTroca.Content.Controls.Add(Me.lblTroca)
        Me.pnlTroca.Content.Location = New System.Drawing.Point(1, 1)
        Me.pnlTroca.Content.Name = "Content"
        Me.pnlTroca.Content.Size = New System.Drawing.Size(212, 39)
        Me.pnlTroca.Content.TabIndex = 3
        Me.pnlTroca.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.pnlTroca.Location = New System.Drawing.Point(809, 412)
        Me.pnlTroca.Name = "pnlTroca"
        Me.pnlTroca.Opacity = 1.0!
        Me.pnlTroca.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlTroca.Size = New System.Drawing.Size(214, 41)
        Me.pnlTroca.TabIndex = 18
        Me.pnlTroca.Text = "VPanel3"
        Me.pnlTroca.UsePanelBorderColor = True
        Me.pnlTroca.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblValorDevolucao
        '
        Me.lblValorDevolucao.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblValorDevolucao.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorDevolucao.Location = New System.Drawing.Point(67, 0)
        Me.lblValorDevolucao.Name = "lblValorDevolucao"
        Me.lblValorDevolucao.Size = New System.Drawing.Size(145, 39)
        Me.lblValorDevolucao.TabIndex = 12
        Me.lblValorDevolucao.Text = "R$ 0,00"
        Me.lblValorDevolucao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTroca
        '
        Me.lblTroca.AutoSize = True
        Me.lblTroca.BackColor = System.Drawing.Color.Transparent
        Me.lblTroca.Location = New System.Drawing.Point(12, 9)
        Me.lblTroca.Name = "lblTroca"
        Me.lblTroca.Size = New System.Drawing.Size(48, 19)
        Me.lblTroca.TabIndex = 17
        Me.lblTroca.Text = "Troca:"
        '
        'VPanel2
        '
        Me.VPanel2.AllowAnimations = True
        Me.VPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel2.BorderRadius = 0
        '
        'VPanel2.Content
        '
        Me.VPanel2.Content.AutoScroll = True
        Me.VPanel2.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel2.Content.Controls.Add(Me.lblTotalPago)
        Me.VPanel2.Content.Controls.Add(Me.Label17)
        Me.VPanel2.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel2.Content.Name = "Content"
        Me.VPanel2.Content.Size = New System.Drawing.Size(454, 39)
        Me.VPanel2.Content.TabIndex = 3
        Me.VPanel2.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel2.Location = New System.Drawing.Point(23, 364)
        Me.VPanel2.Name = "VPanel2"
        Me.VPanel2.Opacity = 1.0!
        Me.VPanel2.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel2.Size = New System.Drawing.Size(456, 41)
        Me.VPanel2.TabIndex = 10
        Me.VPanel2.Text = "VPanel2"
        Me.VPanel2.UsePanelBorderColor = True
        Me.VPanel2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblTotalPago
        '
        Me.lblTotalPago.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPago.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPago.Location = New System.Drawing.Point(270, 0)
        Me.lblTotalPago.Name = "lblTotalPago"
        Me.lblTotalPago.Size = New System.Drawing.Size(151, 39)
        Me.lblTotalPago.TabIndex = 4
        Me.lblTotalPago.Text = "R$ 0,00"
        Me.lblTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(147, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 19)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Total Recebido:"
        '
        'btnLimparPagamentos
        '
        Me.btnLimparPagamentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLimparPagamentos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLimparPagamentos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PeachPuff
        Me.btnLimparPagamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimparPagamentos.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimparPagamentos.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnLimparPagamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimparPagamentos.Location = New System.Drawing.Point(304, 412)
        Me.btnLimparPagamentos.Name = "btnLimparPagamentos"
        Me.btnLimparPagamentos.Size = New System.Drawing.Size(175, 39)
        Me.btnLimparPagamentos.TabIndex = 5
        Me.btnLimparPagamentos.TabStop = False
        Me.btnLimparPagamentos.Text = "Limpar Pagamentos"
        Me.btnLimparPagamentos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimparPagamentos.UseVisualStyleBackColor = True
        '
        'btnTroca
        '
        Me.btnTroca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTroca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnTroca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PeachPuff
        Me.btnTroca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTroca.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTroca.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnTroca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTroca.Location = New System.Drawing.Point(635, 412)
        Me.btnTroca.Name = "btnTroca"
        Me.btnTroca.Size = New System.Drawing.Size(168, 41)
        Me.btnTroca.TabIndex = 6
        Me.btnTroca.TabStop = False
        Me.btnTroca.Text = "Inserir &Troca"
        Me.btnTroca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTroca.UseVisualStyleBackColor = True
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(529, 52)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(476, 132)
        Me.txtObservacao.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(529, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(234, 26)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Observações Importantes:"
        '
        'dgvPagamentos
        '
        Me.dgvPagamentos.AllowUserToAddRows = False
        Me.dgvPagamentos.AllowUserToDeleteRows = False
        Me.dgvPagamentos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvPagamentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPagamentos.ColumnHeadersHeight = 30
        Me.dgvPagamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnMovForma, Me.clnValor})
        Me.dgvPagamentos.EnableHeadersVisualStyles = False
        Me.dgvPagamentos.Location = New System.Drawing.Point(23, 52)
        Me.dgvPagamentos.MultiSelect = False
        Me.dgvPagamentos.Name = "dgvPagamentos"
        Me.dgvPagamentos.ReadOnly = True
        Me.dgvPagamentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPagamentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPagamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPagamentos.Size = New System.Drawing.Size(456, 308)
        Me.dgvPagamentos.TabIndex = 2
        '
        'clnID
        '
        Me.clnID.HeaderText = "Reg."
        Me.clnID.Name = "clnID"
        Me.clnID.ReadOnly = True
        Me.clnID.Width = 90
        '
        'clnMovForma
        '
        Me.clnMovForma.HeaderText = "Forma"
        Me.clnMovForma.Name = "clnMovForma"
        Me.clnMovForma.ReadOnly = True
        Me.clnMovForma.Width = 200
        '
        'clnValor
        '
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.clnValor.DefaultCellStyle = DataGridViewCellStyle5
        Me.clnValor.HeaderText = "Valor"
        Me.clnValor.Name = "clnValor"
        Me.clnValor.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(19, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 19)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Pagamentos da Venda:"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(4, 4)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1022, 454)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape3.BorderWidth = 3
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 760
        Me.LineShape3.X2 = 1000
        Me.LineShape3.Y1 = 30
        Me.LineShape3.Y2 = 30
        '
        'btnVendedorAlterar
        '
        Me.btnVendedorAlterar.BackgroundImage = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnVendedorAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVendedorAlterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnVendedorAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVendedorAlterar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVendedorAlterar.Location = New System.Drawing.Point(301, 64)
        Me.btnVendedorAlterar.Name = "btnVendedorAlterar"
        Me.btnVendedorAlterar.Size = New System.Drawing.Size(23, 23)
        Me.btnVendedorAlterar.TabIndex = 3
        Me.btnVendedorAlterar.TabStop = False
        Me.btnVendedorAlterar.UseVisualStyleBackColor = True
        '
        'lblVendedor
        '
        Me.lblVendedor.BackColor = System.Drawing.Color.White
        Me.lblVendedor.Location = New System.Drawing.Point(97, 63)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(192, 25)
        Me.lblVendedor.TabIndex = 2
        Me.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vendedor:"
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.RectangleShape1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal
        Me.RectangleShape1.Location = New System.Drawing.Point(93, 60)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(235, 30)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1049, 667)
        Me.ShapeContainer1.TabIndex = 11
        Me.ShapeContainer1.TabStop = False
        '
        'btnData
        '
        Me.btnData.AllowAnimations = True
        Me.btnData.ArrowDirection = System.Windows.Forms.ArrowDirection.Left
        Me.btnData.Location = New System.Drawing.Point(266, 24)
        Me.btnData.Maximum = 100
        Me.btnData.Minimum = 0
        Me.btnData.Name = "btnData"
        Me.btnData.Size = New System.Drawing.Size(16, 16)
        Me.btnData.TabIndex = 52
        Me.btnData.TabStop = False
        Me.btnData.Value = 0
        Me.btnData.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
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
        'lblVendaData
        '
        Me.lblVendaData.BackColor = System.Drawing.Color.Transparent
        Me.lblVendaData.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendaData.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblVendaData.Location = New System.Drawing.Point(112, 16)
        Me.lblVendaData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendaData.Name = "lblVendaData"
        Me.lblVendaData.Size = New System.Drawing.Size(155, 30)
        Me.lblVendaData.TabIndex = 48
        Me.lblVendaData.Text = "01/01/2017"
        Me.lblVendaData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIDVenda
        '
        Me.lblIDVenda.BackColor = System.Drawing.Color.Transparent
        Me.lblIDVenda.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDVenda.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblIDVenda.Location = New System.Drawing.Point(5, 16)
        Me.lblIDVenda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIDVenda.Name = "lblIDVenda"
        Me.lblIDVenda.Size = New System.Drawing.Size(85, 30)
        Me.lblIDVenda.TabIndex = 49
        Me.lblIDVenda.Text = "0001"
        Me.lblIDVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(1018, 14)
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
        Me.lblTotalGeral.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTotalGeral.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGeral.Location = New System.Drawing.Point(67, 0)
        Me.lblTotalGeral.Name = "lblTotalGeral"
        Me.lblTotalGeral.Size = New System.Drawing.Size(145, 37)
        Me.lblTotalGeral.TabIndex = 12
        Me.lblTotalGeral.Text = "R$ 0,00"
        Me.lblTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(11, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 19)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Total:"
        '
        'lblSituacao
        '
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblSituacao.Location = New System.Drawing.Point(514, 16)
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
        Me.Label15.Location = New System.Drawing.Point(551, 4)
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
        Me.btnFinalizar.Location = New System.Drawing.Point(455, 616)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Opacity = 0!
        Me.btnFinalizar.RoundedCornersMask = CType(15, Byte)
        Me.btnFinalizar.RoundedCornersRadius = 0
        Me.btnFinalizar.Size = New System.Drawing.Size(140, 42)
        Me.btnFinalizar.TabIndex = 16
        Me.btnFinalizar.Text = "&Finalizar"
        Me.btnFinalizar.TextAbsolutePosition = New System.Drawing.Point(20, 1)
        Me.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFinalizar.UseAbsoluteImagePositioning = True
        Me.btnFinalizar.UseAbsoluteTextPositioning = True
        Me.btnFinalizar.UseVisualStyleBackColor = False
        Me.btnFinalizar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICEBLACK
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(305, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(188, 30)
        Me.lblFilial.TabIndex = 49
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(376, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Filial:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'VPanel1
        '
        Me.VPanel1.AllowAnimations = True
        Me.VPanel1.BorderRadius = 0
        '
        'VPanel1.Content
        '
        Me.VPanel1.Content.AutoScroll = True
        Me.VPanel1.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel1.Content.Controls.Add(Me.Label13)
        Me.VPanel1.Content.Controls.Add(Me.lblTotalGeral)
        Me.VPanel1.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel1.Content.Name = "Content"
        Me.VPanel1.Content.Size = New System.Drawing.Size(212, 37)
        Me.VPanel1.Content.TabIndex = 17
        Me.VPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel1.Location = New System.Drawing.Point(818, 617)
        Me.VPanel1.Name = "VPanel1"
        Me.VPanel1.Opacity = 1.0!
        Me.VPanel1.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel1.Size = New System.Drawing.Size(214, 39)
        Me.VPanel1.TabIndex = 17
        Me.VPanel1.Text = "VPanel1"
        Me.VPanel1.UsePanelBorderColor = True
        Me.VPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'tspMenuAcao
        '
        Me.tspMenuAcao.AutoSize = False
        Me.tspMenuAcao.BackColor = System.Drawing.Color.Transparent
        Me.tspMenuAcao.Dock = System.Windows.Forms.DockStyle.None
        Me.tspMenuAcao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnAdicionar, Me.ToolStripSeparator2, Me.btnExcluirVenda, Me.btnDesbloquearVenda, Me.ToolStripSeparator1, Me.btnImprimir})
        Me.tspMenuAcao.Location = New System.Drawing.Point(9, 613)
        Me.tspMenuAcao.Name = "tspMenuAcao"
        Me.tspMenuAcao.Size = New System.Drawing.Size(443, 47)
        Me.tspMenuAcao.TabIndex = 15
        Me.tspMenuAcao.Text = "ToolStrip1"
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
        Me.btnProcurar.Text = "Procurar Venda"
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
        Me.btnAdicionar.Text = "Adicionar Nova Venda"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 47)
        '
        'btnExcluirVenda
        '
        Me.btnExcluirVenda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExcluirVenda.Image = Global.NovaSiao.My.Resources.Resources.Lixeira_PEQ
        Me.btnExcluirVenda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExcluirVenda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcluirVenda.Name = "btnExcluirVenda"
        Me.btnExcluirVenda.Size = New System.Drawing.Size(45, 44)
        Me.btnExcluirVenda.Text = "Excluir Venda"
        Me.btnExcluirVenda.ToolTipText = "Excluir a Venda"
        '
        'btnDesbloquearVenda
        '
        Me.btnDesbloquearVenda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDesbloquearVenda.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnDesbloquearVenda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDesbloquearVenda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDesbloquearVenda.Name = "btnDesbloquearVenda"
        Me.btnDesbloquearVenda.Size = New System.Drawing.Size(36, 44)
        Me.btnDesbloquearVenda.Text = "Desbloquear Venda"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 47)
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirEtiquetas})
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.btnImprimir.Size = New System.Drawing.Size(56, 44)
        Me.btnImprimir.Text = "Imprimir"
        '
        'miImprimirEtiquetas
        '
        Me.miImprimirEtiquetas.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.miImprimirEtiquetas.Name = "miImprimirEtiquetas"
        Me.miImprimirEtiquetas.Size = New System.Drawing.Size(172, 22)
        Me.miImprimirEtiquetas.Text = "Relatório de Venda"
        '
        'mnuContexto
        '
        Me.mnuContexto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemEditar, Me.ToolStripSeparator3, Me.mnuItemInserir, Me.mnuItemExcluir})
        Me.mnuContexto.Name = "mnuContexto"
        Me.mnuContexto.Size = New System.Drawing.Size(136, 76)
        '
        'mnuItemEditar
        '
        Me.mnuItemEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.mnuItemEditar.Name = "mnuItemEditar"
        Me.mnuItemEditar.Size = New System.Drawing.Size(135, 22)
        Me.mnuItemEditar.Text = "Editar Item"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(132, 6)
        '
        'mnuItemInserir
        '
        Me.mnuItemInserir.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.mnuItemInserir.Name = "mnuItemInserir"
        Me.mnuItemInserir.Size = New System.Drawing.Size(135, 22)
        Me.mnuItemInserir.Text = "Inserir Item"
        '
        'mnuItemExcluir
        '
        Me.mnuItemExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.mnuItemExcluir.Name = "mnuItemExcluir"
        Me.mnuItemExcluir.Size = New System.Drawing.Size(135, 22)
        Me.mnuItemExcluir.Text = "Excluir Item"
        '
        'frmVendaVista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1049, 667)
        Me.Controls.Add(Me.tspMenuAcao)
        Me.Controls.Add(Me.VPanel1)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnVendedorAlterar)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tabPrincipal)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.KeyPreview = True
        Me.Name = "frmVendaVista"
        Me.Controls.SetChildIndex(Me.ShapeContainer1, 0)
        Me.Controls.SetChildIndex(Me.tabPrincipal, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblVendedor, 0)
        Me.Controls.SetChildIndex(Me.btnVendedorAlterar, 0)
        Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
        Me.Controls.SetChildIndex(Me.VPanel1, 0)
        Me.Controls.SetChildIndex(Me.tspMenuAcao, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabPrincipal.ResumeLayout(False)
        Me.vtab1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vtab2.ResumeLayout(False)
        Me.vtab2.PerformLayout()
        Me.VPanel3.Content.ResumeLayout(False)
        Me.VPanel3.Content.PerformLayout()
        Me.VPanel3.ResumeLayout(False)
        Me.pnlTroca.Content.ResumeLayout(False)
        Me.pnlTroca.Content.PerformLayout()
        Me.pnlTroca.ResumeLayout(False)
        Me.VPanel2.Content.ResumeLayout(False)
        Me.VPanel2.Content.PerformLayout()
        Me.VPanel2.ResumeLayout(False)
        CType(Me.dgvPagamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VPanel1.Content.ResumeLayout(False)
        Me.VPanel1.ResumeLayout(False)
        Me.tspMenuAcao.ResumeLayout(False)
        Me.tspMenuAcao.PerformLayout()
        Me.mnuContexto.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
    Friend WithEvents vtab1 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents vtab2 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvPagamentos As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents btnVendedorAlterar As Button
    Friend WithEvents lblVendedor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RectangleShape1 As PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents btnData As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents Label3 As Label
    Friend WithEvents lblIDVenda As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents lblVendaData As Label
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents lblTotalGeral As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents clnIDTransacaoItem As DataGridViewTextBoxColumn
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnSubTotal As DataGridViewTextBoxColumn
    Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
    Friend WithEvents clnTotal As DataGridViewTextBoxColumn
    Friend WithEvents Label15 As Label
    Friend WithEvents lblSituacao As Label
    Friend WithEvents VApplicationMenuItem2 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents VApplicationMenuItem3 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents VApplicationMenuItem4 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
    Friend WithEvents lblTotalPago As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents LineShape3 As PowerPacks.LineShape
    Friend WithEvents btnFinalizar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label4 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnMovForma As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents btnTroca As Button
    Friend WithEvents btnLimparPagamentos As Button
    Friend WithEvents VPanel1 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents VPanel2 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents pnlTroca As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblValorDevolucao As Label
    Friend WithEvents lblTroca As Label
    Friend WithEvents VPanel3 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblValorProdutos As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tspMenuAcao As ToolStrip
    Friend WithEvents btnProcurar As ToolStripButton
    Friend WithEvents btnAdicionar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnImprimir As ToolStripSplitButton
    Friend WithEvents miImprimirEtiquetas As ToolStripMenuItem
    Friend WithEvents btnExcluirVenda As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnDesbloquearVenda As ToolStripButton
    Friend WithEvents mnuContexto As ContextMenuStrip
    Friend WithEvents mnuItemEditar As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuItemInserir As ToolStripMenuItem
    Friend WithEvents mnuItemExcluir As ToolStripMenuItem
End Class
