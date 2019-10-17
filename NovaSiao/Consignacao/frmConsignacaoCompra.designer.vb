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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.Label24 = New System.Windows.Forms.Label()
		Me.dgvItens = New System.Windows.Forms.DataGridView()
		Me.clnIDTransacaoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
		Me.lblTotalGeral = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
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
		Me.Panel1.SuspendLayout()
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.Panel1.Size = New System.Drawing.Size(1033, 50)
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
		Me.lblTitulo.Location = New System.Drawing.Point(729, 0)
		Me.lblTitulo.Size = New System.Drawing.Size(304, 50)
		Me.lblTitulo.Text = "Consignação Compra"
		'
		'Label24
		'
		Me.Label24.AutoSize = True
		Me.Label24.BackColor = System.Drawing.Color.Transparent
		Me.Label24.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label24.Location = New System.Drawing.Point(11, 58)
		Me.Label24.Name = "Label24"
		Me.Label24.Size = New System.Drawing.Size(191, 26)
		Me.Label24.TabIndex = 3
		Me.Label24.Text = "Produtos Comprados"
		'
		'dgvItens
		'
		Me.dgvItens.AllowUserToAddRows = False
		Me.dgvItens.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
		Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
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
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle3
		Me.dgvItens.EnableHeadersVisualStyles = False
		Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvItens.Location = New System.Drawing.Point(9, 88)
		Me.dgvItens.Margin = New System.Windows.Forms.Padding(10)
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
		Me.dgvItens.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvItens.Size = New System.Drawing.Size(1012, 198)
		Me.dgvItens.TabIndex = 4
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
		Me.btnClose.Location = New System.Drawing.Point(1000, 14)
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
		Me.lblTotalGeral.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
		Me.lblTotalGeral.Location = New System.Drawing.Point(864, 400)
		Me.lblTotalGeral.Name = "lblTotalGeral"
		Me.lblTotalGeral.Size = New System.Drawing.Size(158, 41)
		Me.lblTotalGeral.TabIndex = 9
		Me.lblTotalGeral.Text = "R$ 0,00"
		Me.lblTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(745, 412)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(113, 19)
		Me.Label13.TabIndex = 8
		Me.Label13.Text = "Total Devolvido:"
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
		Me.btnFinalizar.Location = New System.Drawing.Point(409, 402)
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
		Me.btnExcluir.Location = New System.Drawing.Point(555, 402)
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
		'frmConsignacaoCompra
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1033, 454)
		Me.Controls.Add(Me.dgvItens)
		Me.Controls.Add(Me.Label24)
		Me.Controls.Add(Me.btnExcluir)
		Me.Controls.Add(Me.btnFinalizar)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.lblTotalGeral)
		Me.KeyPreview = True
		Me.Name = "frmConsignacaoCompra"
		Me.Controls.SetChildIndex(Me.lblTotalGeral, 0)
		Me.Controls.SetChildIndex(Me.Label13, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
		Me.Controls.SetChildIndex(Me.btnExcluir, 0)
		Me.Controls.SetChildIndex(Me.Label24, 0)
		Me.Controls.SetChildIndex(Me.dgvItens, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents dgvItens As DataGridView
	Friend WithEvents Label3 As Label
	Friend WithEvents lblIDTroca As Label
	Friend WithEvents lbl_IdTexto As Label
	Friend WithEvents lblTrocaData As Label
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
	Friend WithEvents Label24 As Label
	Friend WithEvents mnuItens As VIBlend.WinForms.Controls.vContextMenu
	Friend WithEvents btnExcluir As VIBlend.WinForms.Controls.vButton
End Class
