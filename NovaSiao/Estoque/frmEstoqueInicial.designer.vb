<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEstoqueInicial
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
        Me.dgvEntradas = New System.Windows.Forms.DataGridView()
        Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.btnProximo = New VIBlend.WinForms.Controls.vArrowButton()
        Me.btnAnterior = New VIBlend.WinForms.Controls.vArrowButton()
        Me.VPanel2 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblUsuarioApelido = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VPanel1 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblAjusteData = New System.Windows.Forms.Label()
        Me.VPanel3 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblTotalGeral = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.btnPanelCancel = New System.Windows.Forms.Button()
        Me.btnPanelOK = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPreco = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.txtQuantidade = New System.Windows.Forms.TextBox()
        Me.txtRGProduto = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.VPanel4 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblBloqueado = New System.Windows.Forms.Label()
        Me.btnObservacaoSave = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvEntradas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VPanel2.Content.SuspendLayout()
        Me.VPanel2.SuspendLayout()
        Me.VPanel1.Content.SuspendLayout()
        Me.VPanel1.SuspendLayout()
        Me.VPanel3.Content.SuspendLayout()
        Me.VPanel3.SuspendLayout()
        Me.pnlItem.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.VPanel4.Content.SuspendLayout()
        Me.VPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Size = New System.Drawing.Size(954, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label15, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(589, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(365, 50)
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Text = "Entrada de Estoque Inicial"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvEntradas
        '
        Me.dgvEntradas.AllowUserToAddRows = False
        Me.dgvEntradas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvEntradas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEntradas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dgvEntradas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEntradas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvEntradas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEntradas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEntradas.ColumnHeadersHeight = 30
        Me.dgvEntradas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnRGProduto, Me.clnProduto, Me.clnQuantidade, Me.clnPreco, Me.clnSubTotal})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEntradas.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEntradas.EnableHeadersVisualStyles = False
        Me.dgvEntradas.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvEntradas.Location = New System.Drawing.Point(9, 104)
        Me.dgvEntradas.Margin = New System.Windows.Forms.Padding(10)
        Me.dgvEntradas.Name = "dgvEntradas"
        Me.dgvEntradas.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEntradas.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEntradas.RowHeadersWidth = 35
        Me.dgvEntradas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvEntradas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEntradas.Size = New System.Drawing.Size(935, 467)
        Me.dgvEntradas.TabIndex = 5
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
        'txtObservacao
        '
        Me.txtObservacao.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtObservacao.Location = New System.Drawing.Point(9, 606)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(344, 64)
        Me.txtObservacao.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 577)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(125, 26)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Observações:"
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(921, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 5
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'lblSituacao
        '
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblSituacao.Location = New System.Drawing.Point(270, 16)
        Me.lblSituacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(238, 30)
        Me.lblSituacao.TabIndex = 2
        Me.lblSituacao.Text = "Em Aberto"
        Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.LightGray
        Me.Label15.Location = New System.Drawing.Point(357, 4)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 3
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
        Me.btnFinalizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnFinalizar.BackColor = System.Drawing.Color.Transparent
        Me.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.HoverEffectsEnabled = True
        Me.btnFinalizar.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnFinalizar.ImageAbsolutePosition = New System.Drawing.Point(20, 5)
        Me.btnFinalizar.Location = New System.Drawing.Point(453, 628)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Opacity = 0!
        Me.btnFinalizar.RoundedCornersMask = CType(15, Byte)
        Me.btnFinalizar.RoundedCornersRadius = 0
        Me.btnFinalizar.Size = New System.Drawing.Size(140, 42)
        Me.btnFinalizar.TabIndex = 10
        Me.btnFinalizar.Text = "&Concluir"
        Me.btnFinalizar.TextAbsolutePosition = New System.Drawing.Point(30, 1)
        Me.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFinalizar.UseAbsoluteImagePositioning = True
        Me.btnFinalizar.UseAbsoluteTextPositioning = True
        Me.btnFinalizar.UseVisualStyleBackColor = False
        Me.btnFinalizar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICESILVER
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.LightGray
        Me.Label18.Location = New System.Drawing.Point(13, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Filial:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(13, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(219, 30)
        Me.lblFilial.TabIndex = 1
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnProximo
        '
        Me.btnProximo.AllowAnimations = True
        Me.btnProximo.ArrowDirection = System.Windows.Forms.ArrowDirection.Right
        Me.btnProximo.Location = New System.Drawing.Point(571, 60)
        Me.btnProximo.Maximum = 100
        Me.btnProximo.Minimum = 0
        Me.btnProximo.Name = "btnProximo"
        Me.btnProximo.Size = New System.Drawing.Size(30, 30)
        Me.btnProximo.TabIndex = 4
        Me.btnProximo.TabStop = False
        Me.btnProximo.Text = "Avançar"
        Me.btnProximo.Value = 0
        Me.btnProximo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnAnterior
        '
        Me.btnAnterior.AllowAnimations = True
        Me.btnAnterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Left
        Me.btnAnterior.Location = New System.Drawing.Point(536, 60)
        Me.btnAnterior.Maximum = 100
        Me.btnAnterior.Minimum = 0
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(30, 30)
        Me.btnAnterior.TabIndex = 3
        Me.btnAnterior.TabStop = False
        Me.btnAnterior.Text = "Voltar"
        Me.btnAnterior.Value = 0
        Me.btnAnterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'VPanel2
        '
        Me.VPanel2.AllowAnimations = True
        Me.VPanel2.BorderRadius = 0
        '
        'VPanel2.Content
        '
        Me.VPanel2.Content.AutoScroll = True
        Me.VPanel2.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel2.Content.Controls.Add(Me.lblUsuarioApelido)
        Me.VPanel2.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel2.Content.Name = "Content"
        Me.VPanel2.Content.Size = New System.Drawing.Size(154, 29)
        Me.VPanel2.Content.TabIndex = 3
        Me.VPanel2.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel2.Location = New System.Drawing.Point(374, 60)
        Me.VPanel2.Name = "VPanel2"
        Me.VPanel2.Opacity = 1.0!
        Me.VPanel2.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel2.Size = New System.Drawing.Size(156, 31)
        Me.VPanel2.TabIndex = 19
        Me.VPanel2.TabStop = False
        Me.VPanel2.Text = "VPanel2"
        Me.VPanel2.UsePanelBorderColor = True
        Me.VPanel2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblUsuarioApelido
        '
        Me.lblUsuarioApelido.BackColor = System.Drawing.Color.White
        Me.lblUsuarioApelido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUsuarioApelido.Location = New System.Drawing.Point(0, 0)
        Me.lblUsuarioApelido.Name = "lblUsuarioApelido"
        Me.lblUsuarioApelido.Size = New System.Drawing.Size(154, 29)
        Me.lblUsuarioApelido.TabIndex = 0
        Me.lblUsuarioApelido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(303, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuário:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(144, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data:"
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
        Me.VPanel1.Content.Controls.Add(Me.lblAjusteData)
        Me.VPanel1.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel1.Content.Name = "Content"
        Me.VPanel1.Content.Size = New System.Drawing.Size(100, 29)
        Me.VPanel1.Content.TabIndex = 3
        Me.VPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel1.Location = New System.Drawing.Point(195, 60)
        Me.VPanel1.Name = "VPanel1"
        Me.VPanel1.Opacity = 1.0!
        Me.VPanel1.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel1.Size = New System.Drawing.Size(102, 31)
        Me.VPanel1.TabIndex = 19
        Me.VPanel1.TabStop = False
        Me.VPanel1.Text = "VPanel2"
        Me.VPanel1.UsePanelBorderColor = True
        Me.VPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblAjusteData
        '
        Me.lblAjusteData.BackColor = System.Drawing.Color.White
        Me.lblAjusteData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAjusteData.Location = New System.Drawing.Point(0, 0)
        Me.lblAjusteData.Name = "lblAjusteData"
        Me.lblAjusteData.Size = New System.Drawing.Size(100, 29)
        Me.lblAjusteData.TabIndex = 0
        Me.lblAjusteData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VPanel3
        '
        Me.VPanel3.AllowAnimations = True
        Me.VPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VPanel3.BorderRadius = 0
        '
        'VPanel3.Content
        '
        Me.VPanel3.Content.AutoScroll = True
        Me.VPanel3.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel3.Content.Controls.Add(Me.lblTotalGeral)
        Me.VPanel3.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel3.Content.Name = "Content"
        Me.VPanel3.Content.Size = New System.Drawing.Size(154, 38)
        Me.VPanel3.Content.TabIndex = 3
        Me.VPanel3.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel3.Location = New System.Drawing.Point(785, 628)
        Me.VPanel3.Name = "VPanel3"
        Me.VPanel3.Opacity = 1.0!
        Me.VPanel3.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel3.Size = New System.Drawing.Size(156, 40)
        Me.VPanel3.TabIndex = 20
        Me.VPanel3.TabStop = False
        Me.VPanel3.Text = "VPanel3"
        Me.VPanel3.UsePanelBorderColor = True
        Me.VPanel3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblTotalGeral
        '
        Me.lblTotalGeral.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalGeral.BackColor = System.Drawing.Color.White
        Me.lblTotalGeral.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGeral.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalGeral.Name = "lblTotalGeral"
        Me.lblTotalGeral.Size = New System.Drawing.Size(154, 38)
        Me.lblTotalGeral.TabIndex = 0
        Me.lblTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(651, 639)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Total do Estoque:"
        '
        'pnlItem
        '
        Me.pnlItem.Controls.Add(Me.btnPanelCancel)
        Me.pnlItem.Controls.Add(Me.btnPanelOK)
        Me.pnlItem.Controls.Add(Me.Label8)
        Me.pnlItem.Controls.Add(Me.Label11)
        Me.pnlItem.Controls.Add(Me.Label7)
        Me.pnlItem.Controls.Add(Me.Label6)
        Me.pnlItem.Controls.Add(Me.lblPreco)
        Me.pnlItem.Controls.Add(Me.lblTotal)
        Me.pnlItem.Controls.Add(Me.lblProduto)
        Me.pnlItem.Controls.Add(Me.txtQuantidade)
        Me.pnlItem.Controls.Add(Me.txtRGProduto)
        Me.pnlItem.Controls.Add(Me.Panel2)
        Me.pnlItem.Location = New System.Drawing.Point(14, 289)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(924, 71)
        Me.pnlItem.TabIndex = 7
        Me.pnlItem.Visible = False
        '
        'btnPanelCancel
        '
        Me.btnPanelCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPanelCancel.CausesValidation = False
        Me.btnPanelCancel.Image = Global.NovaSiao.My.Resources.Resources.delete_24px
        Me.btnPanelCancel.Location = New System.Drawing.Point(878, 32)
        Me.btnPanelCancel.Name = "btnPanelCancel"
        Me.btnPanelCancel.Size = New System.Drawing.Size(37, 31)
        Me.btnPanelCancel.TabIndex = 11
        Me.btnPanelCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPanelCancel.UseVisualStyleBackColor = True
        '
        'btnPanelOK
        '
        Me.btnPanelOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPanelOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnPanelOK.Location = New System.Drawing.Point(835, 32)
        Me.btnPanelOK.Name = "btnPanelOK"
        Me.btnPanelOK.Size = New System.Drawing.Size(37, 31)
        Me.btnPanelOK.TabIndex = 10
        Me.btnPanelOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPanelOK.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(563, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Quant."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(790, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 15)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(95, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Produto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Reg."
        '
        'lblPreco
        '
        Me.lblPreco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPreco.Location = New System.Drawing.Point(615, 34)
        Me.lblPreco.Name = "lblPreco"
        Me.lblPreco.Size = New System.Drawing.Size(96, 27)
        Me.lblPreco.TabIndex = 7
        Me.lblPreco.Text = "R$ 0,00"
        Me.lblPreco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Location = New System.Drawing.Point(722, 34)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(102, 27)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "R$ 0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProduto
        '
        Me.lblProduto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProduto.Location = New System.Drawing.Point(93, 34)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(423, 27)
        Me.lblProduto.TabIndex = 3
        Me.lblProduto.Text = "Descrição"
        Me.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtQuantidade.Location = New System.Drawing.Point(524, 34)
        Me.txtQuantidade.Margin = New System.Windows.Forms.Padding(5)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(83, 27)
        Me.txtQuantidade.TabIndex = 5
        Me.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRGProduto
        '
        Me.txtRGProduto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRGProduto.Location = New System.Drawing.Point(10, 34)
        Me.txtRGProduto.Margin = New System.Windows.Forms.Padding(5)
        Me.txtRGProduto.Name = "txtRGProduto"
        Me.txtRGProduto.Size = New System.Drawing.Size(75, 27)
        Me.txtRGProduto.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(924, 26)
        Me.Panel2.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(673, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 15)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Preço"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Reg.:"
        '
        'VPanel4
        '
        Me.VPanel4.AllowAnimations = True
        Me.VPanel4.BorderRadius = 0
        '
        'VPanel4.Content
        '
        Me.VPanel4.Content.AutoScroll = True
        Me.VPanel4.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel4.Content.Controls.Add(Me.lblID)
        Me.VPanel4.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel4.Content.Name = "Content"
        Me.VPanel4.Content.Size = New System.Drawing.Size(75, 29)
        Me.VPanel4.Content.TabIndex = 3
        Me.VPanel4.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel4.Location = New System.Drawing.Point(61, 60)
        Me.VPanel4.Name = "VPanel4"
        Me.VPanel4.Opacity = 1.0!
        Me.VPanel4.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel4.Size = New System.Drawing.Size(77, 31)
        Me.VPanel4.TabIndex = 19
        Me.VPanel4.TabStop = False
        Me.VPanel4.Text = "VPanel2"
        Me.VPanel4.UsePanelBorderColor = True
        Me.VPanel4.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.White
        Me.lblID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblID.Location = New System.Drawing.Point(0, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(75, 29)
        Me.lblID.TabIndex = 0
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBloqueado
        '
        Me.lblBloqueado.Location = New System.Drawing.Point(613, 60)
        Me.lblBloqueado.Name = "lblBloqueado"
        Me.lblBloqueado.Size = New System.Drawing.Size(165, 31)
        Me.lblBloqueado.TabIndex = 21
        Me.lblBloqueado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnObservacaoSave
        '
        Me.btnObservacaoSave.Image = Global.NovaSiao.My.Resources.Resources.Salvar_32x32
        Me.btnObservacaoSave.Location = New System.Drawing.Point(358, 606)
        Me.btnObservacaoSave.Name = "btnObservacaoSave"
        Me.btnObservacaoSave.Size = New System.Drawing.Size(43, 43)
        Me.btnObservacaoSave.TabIndex = 22
        Me.btnObservacaoSave.UseVisualStyleBackColor = True
        Me.btnObservacaoSave.Visible = False
        '
        'frmEstoqueInicial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(954, 680)
        Me.Controls.Add(Me.btnObservacaoSave)
        Me.Controls.Add(Me.lblBloqueado)
        Me.Controls.Add(Me.pnlItem)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.VPanel3)
        Me.Controls.Add(Me.VPanel4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.VPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.VPanel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnProximo)
        Me.Controls.Add(Me.dgvEntradas)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.btnFinalizar)
        Me.KeyPreview = True
        Me.Name = "frmEstoqueInicial"
        Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
        Me.Controls.SetChildIndex(Me.txtObservacao, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.dgvEntradas, 0)
        Me.Controls.SetChildIndex(Me.btnProximo, 0)
        Me.Controls.SetChildIndex(Me.btnAnterior, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.VPanel2, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.VPanel1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.VPanel4, 0)
        Me.Controls.SetChildIndex(Me.VPanel3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.pnlItem, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblBloqueado, 0)
        Me.Controls.SetChildIndex(Me.btnObservacaoSave, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvEntradas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VPanel2.Content.ResumeLayout(False)
        Me.VPanel2.ResumeLayout(False)
        Me.VPanel1.Content.ResumeLayout(False)
        Me.VPanel1.ResumeLayout(False)
        Me.VPanel3.Content.ResumeLayout(False)
        Me.VPanel3.ResumeLayout(False)
        Me.pnlItem.ResumeLayout(False)
        Me.pnlItem.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.VPanel4.Content.ResumeLayout(False)
        Me.VPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEntradas As DataGridView
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
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnFinalizar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label18 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents mnuItens As VIBlend.WinForms.Controls.vContextMenu
    Friend WithEvents btnProximo As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents btnAnterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents VPanel2 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblUsuarioApelido As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents VPanel1 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblAjusteData As Label
    Friend WithEvents VPanel3 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblTotalGeral As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlItem As Panel
    Friend WithEvents txtRGProduto As TextBox
    Friend WithEvents txtQuantidade As TextBox
    Friend WithEvents lblProduto As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblPreco As Label
    Friend WithEvents btnPanelOK As Button
    Friend WithEvents btnPanelCancel As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents VPanel4 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblID As Label
    Friend WithEvents lblBloqueado As Label
    Friend WithEvents btnObservacaoSave As Button
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnSubTotal As DataGridViewTextBoxColumn
End Class
