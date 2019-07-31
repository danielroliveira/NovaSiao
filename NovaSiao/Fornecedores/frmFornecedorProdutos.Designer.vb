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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.dgvItens = New Controles.ctrlDataGridView()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIDProdutoFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnApelidoFilial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFornecedorPadrao = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFornecedor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblIDFornecedor = New System.Windows.Forms.Label()
        Me.btnInserir = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnDefinirPadrao = New System.Windows.Forms.Button()
        Me.btnCompra = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(920, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(641, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(279, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Fornecedor | Produtos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(888, 12)
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
        Me.btnFechar.Location = New System.Drawing.Point(782, 455)
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
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnProduto, Me.clnIDProdutoFornecedor, Me.clnPreco, Me.clnDesconto, Me.clnData, Me.clnApelidoFilial, Me.clnFornecedorPadrao})
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
        Me.dgvItens.Location = New System.Drawing.Point(12, 103)
        Me.dgvItens.MultiSelect = False
        Me.dgvItens.Name = "dgvItens"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItens.RowHeadersWidth = 35
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvItens.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItens.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowTemplate.Height = 33
        Me.dgvItens.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.Size = New System.Drawing.Size(893, 343)
        Me.dgvItens.TabIndex = 5
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
        Me.btnInserir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btnExcluir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'btnDefinirPadrao
        '
        Me.btnDefinirPadrao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDefinirPadrao.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnDefinirPadrao.Location = New System.Drawing.Point(390, 455)
        Me.btnDefinirPadrao.Margin = New System.Windows.Forms.Padding(6)
        Me.btnDefinirPadrao.Name = "btnDefinirPadrao"
        Me.btnDefinirPadrao.Size = New System.Drawing.Size(190, 40)
        Me.btnDefinirPadrao.TabIndex = 9
        Me.btnDefinirPadrao.Text = "&Definir como Padrão"
        Me.btnDefinirPadrao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDefinirPadrao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDefinirPadrao.UseVisualStyleBackColor = True
        '
        'btnCompra
        '
        Me.btnCompra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCompra.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnCompra.Location = New System.Drawing.Point(586, 455)
        Me.btnCompra.Margin = New System.Windows.Forms.Padding(6)
        Me.btnCompra.Name = "btnCompra"
        Me.btnCompra.Size = New System.Drawing.Size(190, 40)
        Me.btnCompra.TabIndex = 10
        Me.btnCompra.Text = "&Ir para Compra"
        Me.btnCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCompra.UseVisualStyleBackColor = True
        '
        'frmFornecedorProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(920, 506)
        Me.Controls.Add(Me.lblIDFornecedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFornecedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.btnCompra)
        Me.Controls.Add(Me.btnDefinirPadrao)
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
        Me.Controls.SetChildIndex(Me.btnDefinirPadrao, 0)
        Me.Controls.SetChildIndex(Me.btnCompra, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblFornecedor, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblIDFornecedor, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnDefinirPadrao As Button
    Friend WithEvents btnCompra As Button
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnIDProdutoFornecedor As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
    Friend WithEvents clnData As DataGridViewTextBoxColumn
    Friend WithEvents clnApelidoFilial As DataGridViewTextBoxColumn
    Friend WithEvents clnFornecedorPadrao As DataGridViewImageColumn
End Class
