<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdutosAntigosProcurar
    Inherits NovaSiao.frmModFinBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnAutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPrecoCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPrecoVenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuItens = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAnexarProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNovoProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miAbrirProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.txtProduto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuItens.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(1115, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(876, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(239, 50)
        Me.lblTitulo.Text = "Produtos BD Anterior"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEscolher
        '
        Me.btnEscolher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnEscolher.Location = New System.Drawing.Point(752, 601)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(173, 43)
        Me.btnEscolher.TabIndex = 2
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.Location = New System.Drawing.Point(931, 601)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(166, 43)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.AllowUserToDeleteRows = False
        Me.dgvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItens.ColumnHeadersHeight = 25
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnRGProduto, Me.clnProduto, Me.clnAutor, Me.clnTipo, Me.clnPrecoCompra, Me.clnPrecoVenda})
        Me.dgvItens.EnableHeadersVisualStyles = False
        Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvItens.Location = New System.Drawing.Point(12, 145)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.ReadOnly = True
        Me.dgvItens.RowHeadersWidth = 30
        Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvItens.Size = New System.Drawing.Size(1085, 444)
        Me.dgvItens.TabIndex = 18
        '
        'clnRGProduto
        '
        Me.clnRGProduto.Frozen = True
        Me.clnRGProduto.HeaderText = "Cod."
        Me.clnRGProduto.Name = "clnRGProduto"
        Me.clnRGProduto.ReadOnly = True
        Me.clnRGProduto.Width = 60
        '
        'clnProduto
        '
        Me.clnProduto.Frozen = True
        Me.clnProduto.HeaderText = "Descrição na Origem"
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.ReadOnly = True
        Me.clnProduto.Width = 375
        '
        'clnAutor
        '
        Me.clnAutor.HeaderText = "Autor"
        Me.clnAutor.Name = "clnAutor"
        Me.clnAutor.ReadOnly = True
        Me.clnAutor.Width = 220
        '
        'clnTipo
        '
        Me.clnTipo.HeaderText = "Tipo de Produto"
        Me.clnTipo.Name = "clnTipo"
        Me.clnTipo.ReadOnly = True
        Me.clnTipo.Width = 170
        '
        'clnPrecoCompra
        '
        Me.clnPrecoCompra.HeaderText = "P. Compra"
        Me.clnPrecoCompra.Name = "clnPrecoCompra"
        Me.clnPrecoCompra.ReadOnly = True
        Me.clnPrecoCompra.Width = 90
        '
        'clnPrecoVenda
        '
        Me.clnPrecoVenda.HeaderText = "P. Venda"
        Me.clnPrecoVenda.Name = "clnPrecoVenda"
        Me.clnPrecoVenda.ReadOnly = True
        Me.clnPrecoVenda.Width = 90
        '
        'mnuItens
        '
        Me.mnuItens.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuItens.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAnexarProduto, Me.miNovoProduto, Me.ToolStripSeparator1, Me.miAbrirProduto})
        Me.mnuItens.Name = "mnuItens"
        Me.mnuItens.Size = New System.Drawing.Size(214, 82)
        '
        'miAnexarProduto
        '
        Me.miAnexarProduto.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.miAnexarProduto.Name = "miAnexarProduto"
        Me.miAnexarProduto.Size = New System.Drawing.Size(213, 24)
        Me.miAnexarProduto.Text = "Anexar a um Produto"
        Me.miAnexarProduto.ToolTipText = "Correlacionar com um produto existente"
        '
        'miNovoProduto
        '
        Me.miNovoProduto.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.miNovoProduto.Name = "miNovoProduto"
        Me.miNovoProduto.Size = New System.Drawing.Size(213, 24)
        Me.miNovoProduto.Text = "Criar novo Produto"
        Me.miNovoProduto.ToolTipText = "Um produto que nunca foi inserido"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(210, 6)
        '
        'miAbrirProduto
        '
        Me.miAbrirProduto.Image = Global.NovaSiao.My.Resources.Resources.Estoque_24px
        Me.miAbrirProduto.Name = "miAbrirProduto"
        Me.miAbrirProduto.Size = New System.Drawing.Size(213, 24)
        Me.miAbrirProduto.Text = "Visualizar Produto"
        Me.miAbrirProduto.ToolTipText = "Abrir o cadastro do produto"
        '
        'cmbTipo
        '
        Me.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(133, 65)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(184, 27)
        Me.cmbTipo.TabIndex = 19
        '
        'txtProduto
        '
        Me.txtProduto.Location = New System.Drawing.Point(133, 103)
        Me.txtProduto.Name = "txtProduto"
        Me.txtProduto.Size = New System.Drawing.Size(296, 27)
        Me.txtProduto.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 19)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Tipo de Produto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Descrição"
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPesquisar.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.btnPesquisar.Enabled = False
        Me.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPesquisar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnPesquisar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnPesquisar.Location = New System.Drawing.Point(450, 78)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(153, 52)
        Me.btnPesquisar.TabIndex = 22
        Me.btnPesquisar.Text = "&Pesquisar"
        Me.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPesquisar.UseVisualStyleBackColor = False
        '
        'frmProdutosAntigosProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1115, 656)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProduto)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEscolher)
        Me.Name = "frmProdutosAntigosProcurar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Controls.SetChildIndex(Me.cmbTipo, 0)
        Me.Controls.SetChildIndex(Me.txtProduto, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnPesquisar, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuItens.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEscolher As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents mnuItens As ContextMenuStrip
    Friend WithEvents miAnexarProduto As ToolStripMenuItem
    Friend WithEvents miAbrirProduto As ToolStripMenuItem
    Friend WithEvents miNovoProduto As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents txtProduto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnAutor As DataGridViewTextBoxColumn
    Friend WithEvents clnTipo As DataGridViewTextBoxColumn
    Friend WithEvents clnPrecoCompra As DataGridViewTextBoxColumn
    Friend WithEvents clnPrecoVenda As DataGridViewTextBoxColumn
    Friend WithEvents btnPesquisar As Button
End Class
