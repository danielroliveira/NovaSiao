<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompraGetNFe
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
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
        Me.lblInscricao = New System.Windows.Forms.Label()
        Me.mnuItens = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAnexarProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNovoProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miAbrirProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miObterProdutoDBAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuItens.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(1191, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(943, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(248, 50)
        Me.lblTitulo.Text = "Importar Entrada XML"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Image = Global.NovaSiao.My.Resources.Resources.download
        Me.btnImportar.Location = New System.Drawing.Point(10, 601)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(195, 43)
        Me.btnImportar.TabIndex = 2
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
        Me.btnFechar.TabIndex = 2
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(365, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 19)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Insc. Estadual"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(81, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 19)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "CNPJ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Razao Social"
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
        Me.dgvItens.Size = New System.Drawing.Size(1161, 444)
        Me.dgvItens.TabIndex = 18
        '
        'clnIDProdutoNfe
        '
        Me.clnIDProdutoNfe.Frozen = True
        Me.clnIDProdutoNfe.HeaderText = "Cod."
        Me.clnIDProdutoNfe.Name = "clnIDProdutoNfe"
        Me.clnIDProdutoNfe.ReadOnly = True
        Me.clnIDProdutoNfe.Width = 60
        '
        'clnProdutoNfe
        '
        Me.clnProdutoNfe.Frozen = True
        Me.clnProdutoNfe.HeaderText = "Desc. Origem"
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
        Me.clnDescontoNfe.HeaderText = "Desc."
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
        Me.btnCorrelacao.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnCorrelacao.Location = New System.Drawing.Point(211, 601)
        Me.btnCorrelacao.Name = "btnCorrelacao"
        Me.btnCorrelacao.Size = New System.Drawing.Size(195, 43)
        Me.btnCorrelacao.TabIndex = 2
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
        Me.lblRazaoSocial.Size = New System.Drawing.Size(575, 26)
        Me.lblRazaoSocial.TabIndex = 12
        '
        'lblCNPJ
        '
        Me.lblCNPJ.BackColor = System.Drawing.Color.White
        Me.lblCNPJ.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCNPJ.ForeColor = System.Drawing.Color.Black
        Me.lblCNPJ.Location = New System.Drawing.Point(127, 101)
        Me.lblCNPJ.Name = "lblCNPJ"
        Me.lblCNPJ.Size = New System.Drawing.Size(232, 26)
        Me.lblCNPJ.TabIndex = 12
        '
        'lblInscricao
        '
        Me.lblInscricao.BackColor = System.Drawing.Color.White
        Me.lblInscricao.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInscricao.ForeColor = System.Drawing.Color.Black
        Me.lblInscricao.Location = New System.Drawing.Point(470, 101)
        Me.lblInscricao.Name = "lblInscricao"
        Me.lblInscricao.Size = New System.Drawing.Size(232, 26)
        Me.lblInscricao.TabIndex = 12
        '
        'mnuItens
        '
        Me.mnuItens.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuItens.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAnexarProduto, Me.miNovoProduto, Me.miObterProdutoDBAnterior, Me.ToolStripSeparator1, Me.miAbrirProduto})
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
        'miObterProdutoDBAnterior
        '
        Me.miObterProdutoDBAnterior.Image = Global.NovaSiao.My.Resources.Resources.download
        Me.miObterProdutoDBAnterior.Name = "miObterProdutoDBAnterior"
        Me.miObterProdutoDBAnterior.Size = New System.Drawing.Size(248, 24)
        Me.miObterProdutoDBAnterior.Text = "Obter Produto DB Anterior"
        '
        'frmCompraGetNFe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1191, 656)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblInscricao)
        Me.Controls.Add(Me.lblCNPJ)
        Me.Controls.Add(Me.lblRazaoSocial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnCorrelacao)
        Me.Controls.Add(Me.btnImportar)
        Me.Name = "frmCompraGetNFe"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnImportar, 0)
        Me.Controls.SetChildIndex(Me.btnCorrelacao, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblRazaoSocial, 0)
        Me.Controls.SetChildIndex(Me.lblCNPJ, 0)
        Me.Controls.SetChildIndex(Me.lblInscricao, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuItens.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnImportar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents btnCorrelacao As Button
    Friend WithEvents clnIDProdutoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnProdutoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidadeNFe As DataGridViewTextBoxColumn
    Friend WithEvents clnPrecoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnDescontoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnTotalNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents lblRazaoSocial As Label
    Friend WithEvents lblCNPJ As Label
    Friend WithEvents lblInscricao As Label
    Friend WithEvents mnuItens As ContextMenuStrip
    Friend WithEvents miAnexarProduto As ToolStripMenuItem
    Friend WithEvents miAbrirProduto As ToolStripMenuItem
    Friend WithEvents miNovoProduto As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miObterProdutoDBAnterior As ToolStripMenuItem
End Class
