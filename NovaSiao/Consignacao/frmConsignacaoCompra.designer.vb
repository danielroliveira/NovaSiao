<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsignacaoCompra
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
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.dgvItens = New System.Windows.Forms.DataGridView()
		Me.clnIDItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lbl_IdTexto = New System.Windows.Forms.Label()
		Me.lblTrocaData = New System.Windows.Forms.Label()
		Me.lblIDTroca = New System.Windows.Forms.Label()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.lblSituacao = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.mnuItens = New VIBlend.WinForms.Controls.vContextMenu()
		Me.MenuItemEditar = New System.Windows.Forms.MenuItem()
		Me.MenuItemInserir = New System.Windows.Forms.MenuItem()
		Me.MenuItem3 = New System.Windows.Forms.MenuItem()
		Me.MenuItemExcluir = New System.Windows.Forms.MenuItem()
		Me.VApplicationMenuItem2 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
		Me.VApplicationMenuItem3 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
		Me.VApplicationMenuItem4 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
		Me.btnFinalizar = New VIBlend.WinForms.Controls.vButton()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.lblFilial = New System.Windows.Forms.Label()
		Me.btnExcluir = New VIBlend.WinForms.Controls.vButton()
		Me.lblTotalProdutos = New System.Windows.Forms.Label()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.vtab2 = New VIBlend.WinForms.Controls.vTabPage()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.txtDescontos = New Controles.Text_Monetario()
		Me.txtDespesas = New Controles.Text_Monetario()
		Me.txtICMSValor = New Controles.Text_Monetario()
		Me.txtFreteCobrado = New Controles.Text_Monetario()
		Me.txtObservacao = New System.Windows.Forms.TextBox()
		Me.dgvAPagar = New System.Windows.Forms.DataGridView()
		Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.lblTotalCobrado = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.lblCobrancaTipo = New System.Windows.Forms.Label()
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.vtab1 = New VIBlend.WinForms.Controls.vTabPage()
		Me.tabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
		Me.Panel1.SuspendLayout()
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtab2.SuspendLayout()
		CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.vtab1.SuspendLayout()
		Me.tabPrincipal.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Label18)
		Me.Panel1.Controls.Add(Me.lblFilial)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.Controls.Add(Me.Label15)
		Me.Panel1.Controls.Add(Me.lbl_IdTexto)
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Controls.Add(Me.lblSituacao)
		Me.Panel1.Controls.Add(Me.lblIDTroca)
		Me.Panel1.Controls.Add(Me.lblTrocaData)
		Me.Panel1.Size = New System.Drawing.Size(1060, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTrocaData, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblIDTroca, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label15, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label3, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.Location = New System.Drawing.Point(756, 0)
		Me.lblTitulo.Size = New System.Drawing.Size(304, 50)
		Me.lblTitulo.Text = "Consignação Compra"
		'
		'dgvItens
		'
		Me.dgvItens.AllowUserToAddRows = False
		Me.dgvItens.AllowUserToDeleteRows = False
		DataGridViewCellStyle6.BackColor = System.Drawing.Color.Azure
		Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
		Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
		Me.dgvItens.ColumnHeadersHeight = 30
		Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDItem, Me.clnRGProduto, Me.clnProduto, Me.clnQuantidade, Me.clnPreco, Me.clnSubTotal, Me.clnDesconto, Me.clnTotal})
		DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue
		DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
		DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle8
		Me.dgvItens.EnableHeadersVisualStyles = False
		Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvItens.Location = New System.Drawing.Point(14, 14)
		Me.dgvItens.Margin = New System.Windows.Forms.Padding(10)
		Me.dgvItens.Name = "dgvItens"
		Me.dgvItens.ReadOnly = True
		DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
		DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
		Me.dgvItens.RowHeadersWidth = 35
		Me.dgvItens.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvItens.Size = New System.Drawing.Size(1012, 332)
		Me.dgvItens.TabIndex = 4
		'
		'clnIDItem
		'
		Me.clnIDItem.Frozen = True
		Me.clnIDItem.HeaderText = "IDItem"
		Me.clnIDItem.Name = "clnIDItem"
		Me.clnIDItem.ReadOnly = True
		Me.clnIDItem.Visible = False
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
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.LightGray
		Me.Label3.Location = New System.Drawing.Point(167, 4)
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
		Me.lbl_IdTexto.ForeColor = System.Drawing.Color.LightGray
		Me.lbl_IdTexto.Location = New System.Drawing.Point(29, 4)
		Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.lbl_IdTexto.Name = "lbl_IdTexto"
		Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
		Me.lbl_IdTexto.TabIndex = 51
		Me.lbl_IdTexto.Text = "Reg."
		Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTrocaData
		'
		Me.lblTrocaData.BackColor = System.Drawing.Color.Transparent
		Me.lblTrocaData.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTrocaData.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblTrocaData.Location = New System.Drawing.Point(113, 16)
		Me.lblTrocaData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblTrocaData.Name = "lblTrocaData"
		Me.lblTrocaData.Size = New System.Drawing.Size(155, 30)
		Me.lblTrocaData.TabIndex = 48
		Me.lblTrocaData.Text = "01/01/2017"
		Me.lblTrocaData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblIDTroca
		'
		Me.lblIDTroca.BackColor = System.Drawing.Color.Transparent
		Me.lblIDTroca.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIDTroca.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblIDTroca.Location = New System.Drawing.Point(5, 16)
		Me.lblIDTroca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblIDTroca.Name = "lblIDTroca"
		Me.lblIDTroca.Size = New System.Drawing.Size(85, 30)
		Me.lblIDTroca.TabIndex = 49
		Me.lblIDTroca.Text = "0001"
		Me.lblIDTroca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
		Me.btnClose.Location = New System.Drawing.Point(1027, 14)
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
		'lblSituacao
		'
		Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
		Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblSituacao.Location = New System.Drawing.Point(305, 16)
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
		Me.Label15.ForeColor = System.Drawing.Color.LightGray
		Me.Label15.Location = New System.Drawing.Point(342, 4)
		Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(67, 13)
		Me.Label15.TabIndex = 51
		Me.Label15.Text = "Situação:"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'mnuItens
		'
		Me.mnuItens.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemEditar, Me.MenuItemInserir, Me.MenuItem3, Me.MenuItemExcluir})
		'
		'MenuItemEditar
		'
		Me.MenuItemEditar.Index = 0
		Me.MenuItemEditar.Text = "Editar Item"
		'
		'MenuItemInserir
		'
		Me.MenuItemInserir.Index = 1
		Me.MenuItemInserir.Text = "Inserir Novo Item"
		'
		'MenuItem3
		'
		Me.MenuItem3.Index = 2
		Me.MenuItem3.Text = "-"
		'
		'MenuItemExcluir
		'
		Me.MenuItemExcluir.Index = 3
		Me.MenuItemExcluir.Text = "Excluir Item"
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
		Me.btnFinalizar.ImageAbsolutePosition = New System.Drawing.Point(20, 5)
		Me.btnFinalizar.Location = New System.Drawing.Point(381, 497)
		Me.btnFinalizar.Name = "btnFinalizar"
		Me.btnFinalizar.Opacity = 0!
		Me.btnFinalizar.RoundedCornersMask = CType(15, Byte)
		Me.btnFinalizar.RoundedCornersRadius = 5
		Me.btnFinalizar.Size = New System.Drawing.Size(140, 42)
		Me.btnFinalizar.TabIndex = 6
		Me.btnFinalizar.Text = "&Concluir"
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
		Me.Label18.ForeColor = System.Drawing.Color.LightGray
		Me.Label18.Location = New System.Drawing.Point(509, 4)
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
		Me.lblFilial.Location = New System.Drawing.Point(460, 16)
		Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblFilial.Name = "lblFilial"
		Me.lblFilial.Size = New System.Drawing.Size(145, 30)
		Me.lblFilial.TabIndex = 55
		Me.lblFilial.Text = "Filial"
		Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnExcluir
		'
		Me.btnExcluir.AllowAnimations = True
		Me.btnExcluir.BackColor = System.Drawing.Color.Transparent
		Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnExcluir.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnExcluir.HoverEffectsEnabled = True
		Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete
		Me.btnExcluir.ImageAbsolutePosition = New System.Drawing.Point(30, 10)
		Me.btnExcluir.Location = New System.Drawing.Point(527, 497)
		Me.btnExcluir.Name = "btnExcluir"
		Me.btnExcluir.Opacity = 0!
		Me.btnExcluir.RoundedCornersMask = CType(15, Byte)
		Me.btnExcluir.RoundedCornersRadius = 5
		Me.btnExcluir.Size = New System.Drawing.Size(140, 42)
		Me.btnExcluir.TabIndex = 7
		Me.btnExcluir.Text = "&Excluir"
		Me.btnExcluir.TextAbsolutePosition = New System.Drawing.Point(20, 1)
		Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnExcluir.UseAbsoluteImagePositioning = True
		Me.btnExcluir.UseAbsoluteTextPositioning = True
		Me.btnExcluir.UseVisualStyleBackColor = False
		Me.btnExcluir.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
		'
		'lblTotalProdutos
		'
		Me.lblTotalProdutos.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalProdutos.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalProdutos.Location = New System.Drawing.Point(875, 356)
		Me.lblTotalProdutos.Margin = New System.Windows.Forms.Padding(0)
		Me.lblTotalProdutos.Name = "lblTotalProdutos"
		Me.lblTotalProdutos.Size = New System.Drawing.Size(151, 32)
		Me.lblTotalProdutos.TabIndex = 15
		Me.lblTotalProdutos.Text = "R$ 0,00"
		Me.lblTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label27
		'
		Me.Label27.AutoSize = True
		Me.Label27.BackColor = System.Drawing.Color.Transparent
		Me.Label27.Location = New System.Drawing.Point(735, 361)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(134, 19)
		Me.Label27.TabIndex = 18
		Me.Label27.Text = "Valor dos Produtos:"
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
		'vtab2
		'
		Me.vtab2.Controls.Add(Me.Label1)
		Me.vtab2.Controls.Add(Me.Label2)
		Me.vtab2.Controls.Add(Me.Label5)
		Me.vtab2.Controls.Add(Me.Label20)
		Me.vtab2.Controls.Add(Me.txtDescontos)
		Me.vtab2.Controls.Add(Me.txtDespesas)
		Me.vtab2.Controls.Add(Me.txtICMSValor)
		Me.vtab2.Controls.Add(Me.txtFreteCobrado)
		Me.vtab2.Controls.Add(Me.txtObservacao)
		Me.vtab2.Controls.Add(Me.dgvAPagar)
		Me.vtab2.Controls.Add(Me.Label19)
		Me.vtab2.Controls.Add(Me.Label7)
		Me.vtab2.Controls.Add(Me.Label8)
		Me.vtab2.Controls.Add(Me.Label9)
		Me.vtab2.Controls.Add(Me.Label12)
		Me.vtab2.Controls.Add(Me.lblTotalCobrado)
		Me.vtab2.Controls.Add(Me.Label11)
		Me.vtab2.Controls.Add(Me.Label25)
		Me.vtab2.Controls.Add(Me.lblCobrancaTipo)
		Me.vtab2.Controls.Add(Me.ShapeContainer1)
		Me.vtab2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtab2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtab2.Location = New System.Drawing.Point(0, 38)
		Me.vtab2.Name = "vtab2"
		Me.vtab2.Padding = New System.Windows.Forms.Padding(0)
		Me.vtab2.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtab2.Size = New System.Drawing.Size(1044, 397)
		Me.vtab2.TabIndex = 4
		Me.vtab2.Text = "Pagamentos"
		Me.vtab2.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtab2.TooltipText = "TabPage"
		Me.vtab2.UseDefaultTextFont = False
		Me.vtab2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtab2.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Location = New System.Drawing.Point(736, 270)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(126, 19)
		Me.Label1.TabIndex = 13
		Me.Label1.Text = "Tipo de Cobrança:"
		'
		'Label2
		'
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(868, 351)
		Me.Label2.Margin = New System.Windows.Forms.Padding(0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(151, 32)
		Me.Label2.TabIndex = 12
		Me.Label2.Text = "R$ 0,00"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Location = New System.Drawing.Point(728, 356)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(134, 19)
		Me.Label5.TabIndex = 13
		Me.Label5.Text = "Valor dos Produtos:"
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
		'txtDescontos
		'
		Me.txtDescontos.Location = New System.Drawing.Point(363, 84)
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
		Me.txtICMSValor.Location = New System.Drawing.Point(363, 51)
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
		'txtObservacao
		'
		Me.txtObservacao.Location = New System.Drawing.Point(40, 160)
		Me.txtObservacao.Multiline = True
		Me.txtObservacao.Name = "txtObservacao"
		Me.txtObservacao.Size = New System.Drawing.Size(423, 95)
		Me.txtObservacao.TabIndex = 8
		'
		'dgvAPagar
		'
		Me.dgvAPagar.AllowUserToAddRows = False
		Me.dgvAPagar.AllowUserToDeleteRows = False
		Me.dgvAPagar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvAPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvAPagar.ColumnHeadersHeight = 30
		Me.dgvAPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
		Me.dgvAPagar.EnableHeadersVisualStyles = False
		Me.dgvAPagar.Location = New System.Drawing.Point(488, 51)
		Me.dgvAPagar.MultiSelect = False
		Me.dgvAPagar.Name = "dgvAPagar"
		Me.dgvAPagar.ReadOnly = True
		Me.dgvAPagar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvAPagar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvAPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvAPagar.Size = New System.Drawing.Size(549, 204)
		Me.dgvAPagar.TabIndex = 9
		'
		'DataGridViewTextBoxColumn8
		'
		Me.DataGridViewTextBoxColumn8.HeaderText = "IDAPagar"
		Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
		Me.DataGridViewTextBoxColumn8.ReadOnly = True
		Me.DataGridViewTextBoxColumn8.Visible = False
		'
		'DataGridViewTextBoxColumn9
		'
		Me.DataGridViewTextBoxColumn9.HeaderText = "Forma"
		Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
		Me.DataGridViewTextBoxColumn9.ReadOnly = True
		Me.DataGridViewTextBoxColumn9.Width = 160
		'
		'DataGridViewTextBoxColumn10
		'
		Me.DataGridViewTextBoxColumn10.HeaderText = "No. Reg.:"
		Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
		Me.DataGridViewTextBoxColumn10.ReadOnly = True
		'
		'DataGridViewTextBoxColumn11
		'
		DataGridViewCellStyle10.Format = "C2"
		DataGridViewCellStyle10.NullValue = "0"
		Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle10
		Me.DataGridViewTextBoxColumn11.HeaderText = "Vencimento"
		Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
		Me.DataGridViewTextBoxColumn11.ReadOnly = True
		Me.DataGridViewTextBoxColumn11.Width = 110
		'
		'DataGridViewTextBoxColumn12
		'
		Me.DataGridViewTextBoxColumn12.HeaderText = "Valor"
		Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
		Me.DataGridViewTextBoxColumn12.ReadOnly = True
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Location = New System.Drawing.Point(280, 87)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(77, 19)
		Me.Label19.TabIndex = 9
		Me.Label19.Text = "Descontos"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Location = New System.Drawing.Point(23, 87)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(120, 19)
		Me.Label7.TabIndex = 9
		Me.Label7.Text = "Outras Despesas"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Location = New System.Drawing.Point(257, 54)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(100, 19)
		Me.Label8.TabIndex = 9
		Me.Label8.Text = "ICMS Cobrado"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Location = New System.Drawing.Point(43, 54)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(100, 19)
		Me.Label9.TabIndex = 9
		Me.Label9.Text = "Frete Cobrado"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.Location = New System.Drawing.Point(20, 121)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(234, 26)
		Me.Label12.TabIndex = 15
		Me.Label12.Text = "Observações Importantes:"
		'
		'lblTotalCobrado
		'
		Me.lblTotalCobrado.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalCobrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTotalCobrado.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTotalCobrado.Location = New System.Drawing.Point(868, 309)
		Me.lblTotalCobrado.Name = "lblTotalCobrado"
		Me.lblTotalCobrado.Size = New System.Drawing.Size(151, 32)
		Me.lblTotalCobrado.TabIndex = 12
		Me.lblTotalCobrado.Text = "R$ 0,00"
		Me.lblTotalCobrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Location = New System.Drawing.Point(759, 314)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(103, 19)
		Me.Label11.TabIndex = 13
		Me.Label11.Text = "Total Cobrado:"
		'
		'Label25
		'
		Me.Label25.AutoSize = True
		Me.Label25.BackColor = System.Drawing.Color.Transparent
		Me.Label25.Font = New System.Drawing.Font("Calibri", 15.75!)
		Me.Label25.Location = New System.Drawing.Point(483, 15)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(264, 26)
		Me.Label25.TabIndex = 1
		Me.Label25.Text = "Desdobramento das Parcelas:"
		'
		'lblCobrancaTipo
		'
		Me.lblCobrancaTipo.BackColor = System.Drawing.Color.Transparent
		Me.lblCobrancaTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCobrancaTipo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCobrancaTipo.Location = New System.Drawing.Point(868, 266)
		Me.lblCobrancaTipo.Name = "lblCobrancaTipo"
		Me.lblCobrancaTipo.Size = New System.Drawing.Size(151, 32)
		Me.lblCobrancaTipo.TabIndex = 1
		Me.lblCobrancaTipo.Text = "Tipo de Cobrança"
		Me.lblCobrancaTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'ShapeContainer1
		'
		Me.ShapeContainer1.Location = New System.Drawing.Point(4, 4)
		Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer1.Name = "ShapeContainer2"
		Me.ShapeContainer1.Size = New System.Drawing.Size(1036, 389)
		Me.ShapeContainer1.TabIndex = 14
		Me.ShapeContainer1.TabStop = False
		'
		'vtab1
		'
		Me.vtab1.Controls.Add(Me.dgvItens)
		Me.vtab1.Controls.Add(Me.lblTotalProdutos)
		Me.vtab1.Controls.Add(Me.Label27)
		Me.vtab1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vtab1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtab1.ForeColor = System.Drawing.Color.Black
		Me.vtab1.Location = New System.Drawing.Point(0, 38)
		Me.vtab1.Name = "vtab1"
		Me.vtab1.Padding = New System.Windows.Forms.Padding(0)
		Me.vtab1.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtab1.Size = New System.Drawing.Size(1044, 397)
		Me.vtab1.TabIndex = 3
		Me.vtab1.Text = "Produtos"
		Me.vtab1.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.vtab1.TooltipText = "TabPage"
		Me.vtab1.UseDefaultTextFont = False
		Me.vtab1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
		Me.vtab1.Visible = False
		'
		'tabPrincipal
		'
		Me.tabPrincipal.AllowAnimations = True
		Me.tabPrincipal.AllPagesHeight = 28
		Me.tabPrincipal.Controls.Add(Me.vtab1)
		Me.tabPrincipal.Controls.Add(Me.vtab2)
		Me.tabPrincipal.ForeColor = System.Drawing.Color.Black
		Me.tabPrincipal.Location = New System.Drawing.Point(9, 56)
		Me.tabPrincipal.Name = "tabPrincipal"
		Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 38, 0, 0)
		Me.tabPrincipal.Size = New System.Drawing.Size(1044, 435)
		Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
		Me.tabPrincipal.TabIndex = 20
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
		'frmConsignacaoCompra
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1060, 544)
		Me.Controls.Add(Me.tabPrincipal)
		Me.Controls.Add(Me.btnExcluir)
		Me.Controls.Add(Me.btnFinalizar)
		Me.KeyPreview = True
		Me.Name = "frmConsignacaoCompra"
		Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
		Me.Controls.SetChildIndex(Me.btnExcluir, 0)
		Me.Controls.SetChildIndex(Me.tabPrincipal, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtab2.ResumeLayout(False)
		Me.vtab2.PerformLayout()
		CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).EndInit()
		Me.vtab1.ResumeLayout(False)
		Me.vtab1.PerformLayout()
		Me.tabPrincipal.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents dgvItens As DataGridView
	Friend WithEvents Label3 As Label
	Friend WithEvents lblIDTroca As Label
	Friend WithEvents lbl_IdTexto As Label
	Friend WithEvents lblTrocaData As Label
	Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
	Friend WithEvents Label15 As Label
	Friend WithEvents lblSituacao As Label
	Friend WithEvents MenuItemEditar As MenuItem
	Friend WithEvents MenuItemInserir As MenuItem
	Friend WithEvents MenuItem3 As MenuItem
	Friend WithEvents MenuItemExcluir As MenuItem
	Friend WithEvents VApplicationMenuItem2 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents VApplicationMenuItem3 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents VApplicationMenuItem4 As VIBlend.WinForms.Controls.vApplicationMenuItem
	Friend WithEvents btnFinalizar As VIBlend.WinForms.Controls.vButton
	Friend WithEvents Label18 As Label
	Friend WithEvents lblFilial As Label
	Friend WithEvents mnuItens As VIBlend.WinForms.Controls.vContextMenu
	Friend WithEvents btnExcluir As VIBlend.WinForms.Controls.vButton
	Friend WithEvents clnIDItem As DataGridViewTextBoxColumn
	Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
	Friend WithEvents clnProduto As DataGridViewTextBoxColumn
	Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
	Friend WithEvents clnPreco As DataGridViewTextBoxColumn
	Friend WithEvents clnSubTotal As DataGridViewTextBoxColumn
	Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
	Friend WithEvents clnTotal As DataGridViewTextBoxColumn
	Friend WithEvents lblTotalProdutos As Label
	Friend WithEvents Label27 As Label
	Private WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
	Friend WithEvents vtab2 As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label20 As Label
	Friend WithEvents txtDescontos As Controles.Text_Monetario
	Friend WithEvents txtDespesas As Controles.Text_Monetario
	Friend WithEvents txtICMSValor As Controles.Text_Monetario
	Friend WithEvents txtFreteCobrado As Controles.Text_Monetario
	Friend WithEvents txtObservacao As TextBox
	Friend WithEvents dgvAPagar As DataGridView
	Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
	Friend WithEvents Label19 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label12 As Label
	Friend WithEvents lblTotalCobrado As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents Label25 As Label
	Friend WithEvents lblCobrancaTipo As Label
	Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
	Friend WithEvents vtab1 As VIBlend.WinForms.Controls.vTabPage
	Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
End Class
