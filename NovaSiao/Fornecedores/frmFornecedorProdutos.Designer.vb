<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFornecedorProdutos
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.dgvItens = New Controles.ctrlDataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFornecedor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblIDFornecedor = New System.Windows.Forms.Label()
        Me.btnInserir = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.mnuItens = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miUltimaCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAdicionarProdutoAoPedido = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDefinirFonecedorComoPadrao = New System.Windows.Forms.ToolStripMenuItem()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIDProdutoFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnApelidoFilial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFornecedorPadrao = New System.Windows.Forms.DataGridViewImageColumn()
        Me.miConfereEstoque = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuItens.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(913, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(527, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(386, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Fornecedor | Compras | Produtos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(881, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.Location = New System.Drawing.Point(775, 455)
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(6)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(123, 40)
        Me.btnFechar.TabIndex = 11
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.AllowUserToDeleteRows = False
        Me.dgvItens.AllowUserToResizeColumns = False
        Me.dgvItens.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Azure
        Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvItens.ColumnHeadersHeight = 30
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnProduto, Me.clnIDProdutoFornecedor, Me.clnPreco, Me.clnDesconto, Me.clnData, Me.clnApelidoFilial, Me.clnFornecedorPadrao})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvItens.EnableHeadersVisualStyles = False
        Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvItens.Location = New System.Drawing.Point(12, 103)
        Me.dgvItens.MultiSelect = False
        Me.dgvItens.Name = "dgvItens"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvItens.RowHeadersWidth = 35
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvItens.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItens.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowTemplate.Height = 33
        Me.dgvItens.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.Size = New System.Drawing.Size(886, 343)
        Me.dgvItens.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fornecedor:"
        '
        'lblFornecedor
        '
        Me.lblFornecedor.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFornecedor.Location = New System.Drawing.Point(251, 63)
        Me.lblFornecedor.Name = "lblFornecedor"
        Me.lblFornecedor.Size = New System.Drawing.Size(502, 28)
        Me.lblFornecedor.TabIndex = 4
        Me.lblFornecedor.Text = "Fornecedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Reg.:"
        '
        'lblIDFornecedor
        '
        Me.lblIDFornecedor.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDFornecedor.Location = New System.Drawing.Point(62, 63)
        Me.lblIDFornecedor.Name = "lblIDFornecedor"
        Me.lblIDFornecedor.Size = New System.Drawing.Size(92, 28)
        Me.lblIDFornecedor.TabIndex = 2
        Me.lblIDFornecedor.Text = "0000"
        '
        'btnInserir
        '
        Me.btnInserir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInserir.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnInserir.Location = New System.Drawing.Point(12, 455)
        Me.btnInserir.Margin = New System.Windows.Forms.Padding(6)
        Me.btnInserir.Name = "btnInserir"
        Me.btnInserir.Size = New System.Drawing.Size(120, 40)
        Me.btnInserir.TabIndex = 6
        Me.btnInserir.Text = "&Inserir"
        Me.btnInserir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInserir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInserir.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(138, 455)
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(6)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(120, 40)
        Me.btnEditar.TabIndex = 7
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete_24px
        Me.btnExcluir.Location = New System.Drawing.Point(264, 455)
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(6)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(120, 40)
        Me.btnExcluir.TabIndex = 8
        Me.btnExcluir.Text = "&Remover"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'mnuItens
        '
        Me.mnuItens.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miDefinirFonecedorComoPadrao, Me.miUltimaCompra, Me.ToolStripSeparator1, Me.miConfereEstoque, Me.miAdicionarProdutoAoPedido})
        Me.mnuItens.Name = "mnuItens"
        Me.mnuItens.Size = New System.Drawing.Size(270, 120)
        '
        'miUltimaCompra
        '
        Me.miUltimaCompra.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.miUltimaCompra.Image = Global.NovaSiao.My.Resources.Resources.search_peq
        Me.miUltimaCompra.Name = "miUltimaCompra"
        Me.miUltimaCompra.Size = New System.Drawing.Size(269, 22)
        Me.miUltimaCompra.Text = "Ir para última Compra"
        Me.miUltimaCompra.ToolTipText = "Fechar e abrir a última compra"
        '
        'miAdicionarProdutoAoPedido
        '
        Me.miAdicionarProdutoAoPedido.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.miAdicionarProdutoAoPedido.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.miAdicionarProdutoAoPedido.Name = "miAdicionarProdutoAoPedido"
        Me.miAdicionarProdutoAoPedido.Size = New System.Drawing.Size(269, 22)
        Me.miAdicionarProdutoAoPedido.Text = "Adicionar Produto ao Pedido"
        '
        'miDefinirFonecedorComoPadrao
        '
        Me.miDefinirFonecedorComoPadrao.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.miDefinirFonecedorComoPadrao.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.miDefinirFonecedorComoPadrao.Name = "miDefinirFonecedorComoPadrao"
        Me.miDefinirFonecedorComoPadrao.Size = New System.Drawing.Size(269, 22)
        Me.miDefinirFonecedorComoPadrao.Text = "Definir Fonecedor como Padrão"
        '
        'clnProduto
        '
        Me.clnProduto.HeaderText = "Produto"
        Me.clnProduto.MaxInputLength = 50
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.Width = 300
        '
        'clnIDProdutoFornecedor
        '
        Me.clnIDProdutoFornecedor.HeaderText = "Cod. Fornecedor"
        Me.clnIDProdutoFornecedor.Name = "clnIDProdutoFornecedor"
        Me.clnIDProdutoFornecedor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clnIDProdutoFornecedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clnIDProdutoFornecedor.Width = 120
        '
        'clnPreco
        '
        Me.clnPreco.HeaderText = "Preço"
        Me.clnPreco.MaxInputLength = 20
        Me.clnPreco.Name = "clnPreco"
        Me.clnPreco.Width = 80
        '
        'clnDesconto
        '
        Me.clnDesconto.HeaderText = "Desc(%)"
        Me.clnDesconto.MaxInputLength = 20
        Me.clnDesconto.Name = "clnDesconto"
        Me.clnDesconto.ReadOnly = True
        Me.clnDesconto.Width = 70
        '
        'clnData
        '
        Me.clnData.HeaderText = "Data"
        Me.clnData.MaxInputLength = 50
        Me.clnData.Name = "clnData"
        Me.clnData.Width = 80
        '
        'clnApelidoFilial
        '
        Me.clnApelidoFilial.HeaderText = "Filial"
        Me.clnApelidoFilial.Name = "clnApelidoFilial"
        Me.clnApelidoFilial.ReadOnly = True
        Me.clnApelidoFilial.Width = 110
        '
        'clnFornecedorPadrao
        '
        Me.clnFornecedorPadrao.HeaderText = "FP"
        Me.clnFornecedorPadrao.Name = "clnFornecedorPadrao"
        Me.clnFornecedorPadrao.ReadOnly = True
        Me.clnFornecedorPadrao.Width = 50
        '
        'miConfereEstoque
        '
        Me.miConfereEstoque.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.miConfereEstoque.Image = Global.NovaSiao.My.Resources.Resources.search_peq
        Me.miConfereEstoque.Name = "miConfereEstoque"
        Me.miConfereEstoque.Size = New System.Drawing.Size(269, 22)
        Me.miConfereEstoque.Text = "Confere Estoque Atual"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(239, 6)
        '
        'frmFornecedorProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(913, 506)
        Me.Controls.Add(Me.lblIDFornecedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFornecedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnInserir)
        Me.Controls.Add(Me.btnFechar)
        Me.Name = "frmFornecedorProdutos"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnInserir, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnExcluir, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblFornecedor, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblIDFornecedor, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuItens.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents btnFechar As Button
    Friend WithEvents dgvItens As Controles.ctrlDataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFornecedor As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblIDFornecedor As Label
    Friend WithEvents btnInserir As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents mnuItens As ContextMenuStrip
    Friend WithEvents miUltimaCompra As ToolStripMenuItem
    Friend WithEvents miAdicionarProdutoAoPedido As ToolStripMenuItem
    Friend WithEvents miDefinirFonecedorComoPadrao As ToolStripMenuItem
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnIDProdutoFornecedor As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
    Friend WithEvents clnData As DataGridViewTextBoxColumn
    Friend WithEvents clnApelidoFilial As DataGridViewTextBoxColumn
    Friend WithEvents clnFornecedorPadrao As DataGridViewImageColumn
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miConfereEstoque As ToolStripMenuItem
End Class
