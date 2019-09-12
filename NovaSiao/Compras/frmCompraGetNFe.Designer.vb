<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCompraGetNFe
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
        Me.miObterProdutoDBAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNovoProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miAbrirProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalvarCompra = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTransportadora = New System.Windows.Forms.Label()
        Me.lblTranspCNPJ = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTransp = New System.Windows.Forms.Button()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.lblSelectInfo = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuItens.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(1191, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(872, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(319, 50)
        Me.lblTitulo.Text = "Importar Entrada NFe XML"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Image = Global.NovaSiao.My.Resources.Resources.download
        Me.btnImportar.Location = New System.Drawing.Point(10, 601)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(195, 43)
        Me.btnImportar.TabIndex = 13
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
        Me.btnFechar.TabIndex = 16
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(352, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 19)
        Me.Label17.TabIndex = 5
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
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "CNPJ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(40, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fornecedor"
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
        Me.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItens.Size = New System.Drawing.Size(1161, 444)
        Me.dgvItens.TabIndex = 12
        Me.dgvItens.VirtualMode = True
        '
        'clnIDProdutoNfe
        '
        Me.clnIDProdutoNfe.Frozen = True
        Me.clnIDProdutoNfe.HeaderText = "Cod. NFe"
        Me.clnIDProdutoNfe.Name = "clnIDProdutoNfe"
        Me.clnIDProdutoNfe.ReadOnly = True
        Me.clnIDProdutoNfe.Width = 80
        '
        'clnProdutoNfe
        '
        Me.clnProdutoNfe.Frozen = True
        Me.clnProdutoNfe.HeaderText = "Desc. Origem NFe"
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
        Me.clnDescontoNfe.HeaderText = "Desc. (%)"
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
        Me.btnCorrelacao.Enabled = False
        Me.btnCorrelacao.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnCorrelacao.Location = New System.Drawing.Point(211, 601)
        Me.btnCorrelacao.Name = "btnCorrelacao"
        Me.btnCorrelacao.Size = New System.Drawing.Size(195, 43)
        Me.btnCorrelacao.TabIndex = 14
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
        Me.lblRazaoSocial.Size = New System.Drawing.Size(540, 26)
        Me.lblRazaoSocial.TabIndex = 2
        '
        'lblCNPJ
        '
        Me.lblCNPJ.BackColor = System.Drawing.Color.White
        Me.lblCNPJ.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCNPJ.ForeColor = System.Drawing.Color.Black
        Me.lblCNPJ.Location = New System.Drawing.Point(127, 101)
        Me.lblCNPJ.Name = "lblCNPJ"
        Me.lblCNPJ.Size = New System.Drawing.Size(209, 26)
        Me.lblCNPJ.TabIndex = 4
        '
        'lblInscricao
        '
        Me.lblInscricao.BackColor = System.Drawing.Color.White
        Me.lblInscricao.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInscricao.ForeColor = System.Drawing.Color.Black
        Me.lblInscricao.Location = New System.Drawing.Point(457, 101)
        Me.lblInscricao.Name = "lblInscricao"
        Me.lblInscricao.Size = New System.Drawing.Size(210, 26)
        Me.lblInscricao.TabIndex = 6
        '
        'mnuItens
        '
        Me.mnuItens.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuItens.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAnexarProduto, Me.miObterProdutoDBAnterior, Me.miNovoProduto, Me.ToolStripSeparator1, Me.miAbrirProduto})
        Me.mnuItens.Name = "mnuItens"
        Me.mnuItens.Size = New System.Drawing.Size(249, 106)
        '
        'miAnexarProduto
        '
        Me.miAnexarProduto.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.miAnexarProduto.Name = "miAnexarProduto"
        Me.miAnexarProduto.Size = New System.Drawing.Size(248, 24)
        Me.miAnexarProduto.Text = "Anexar a um Produto"
        Me.miAnexarProduto.ToolTipText = "Correlacionar com um produto existente"
        '
        'miObterProdutoDBAnterior
        '
        Me.miObterProdutoDBAnterior.Image = Global.NovaSiao.My.Resources.Resources.download
        Me.miObterProdutoDBAnterior.Name = "miObterProdutoDBAnterior"
        Me.miObterProdutoDBAnterior.Size = New System.Drawing.Size(248, 24)
        Me.miObterProdutoDBAnterior.Text = "Obter Produto DB Anterior"
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
        'btnSalvarCompra
        '
        Me.btnSalvarCompra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalvarCompra.Enabled = False
        Me.btnSalvarCompra.Image = Global.NovaSiao.My.Resources.Resources.save
        Me.btnSalvarCompra.Location = New System.Drawing.Point(412, 601)
        Me.btnSalvarCompra.Name = "btnSalvarCompra"
        Me.btnSalvarCompra.Size = New System.Drawing.Size(195, 43)
        Me.btnSalvarCompra.TabIndex = 15
        Me.btnSalvarCompra.Text = "Salvar Compra"
        Me.btnSalvarCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvarCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvarCompra.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(706, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Transportadora"
        '
        'lblTransportadora
        '
        Me.lblTransportadora.BackColor = System.Drawing.Color.White
        Me.lblTransportadora.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransportadora.ForeColor = System.Drawing.Color.Black
        Me.lblTransportadora.Location = New System.Drawing.Point(819, 66)
        Me.lblTransportadora.Name = "lblTransportadora"
        Me.lblTransportadora.Size = New System.Drawing.Size(354, 26)
        Me.lblTransportadora.TabIndex = 8
        '
        'lblTranspCNPJ
        '
        Me.lblTranspCNPJ.BackColor = System.Drawing.Color.White
        Me.lblTranspCNPJ.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTranspCNPJ.ForeColor = System.Drawing.Color.Black
        Me.lblTranspCNPJ.Location = New System.Drawing.Point(819, 100)
        Me.lblTranspCNPJ.Name = "lblTranspCNPJ"
        Me.lblTranspCNPJ.Size = New System.Drawing.Size(185, 26)
        Me.lblTranspCNPJ.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(773, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 19)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "CNPJ"
        '
        'btnTransp
        '
        Me.btnTransp.BackColor = System.Drawing.Color.PeachPuff
        Me.btnTransp.FlatAppearance.BorderSize = 0
        Me.btnTransp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransp.Location = New System.Drawing.Point(1012, 100)
        Me.btnTransp.Name = "btnTransp"
        Me.btnTransp.Size = New System.Drawing.Size(161, 27)
        Me.btnTransp.TabIndex = 11
        Me.btnTransp.Text = "Não Encontrada"
        Me.btnTransp.UseVisualStyleBackColor = False
        Me.btnTransp.Visible = False
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(1159, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 0
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'lblSelectInfo
        '
        Me.lblSelectInfo.AutoSize = True
        Me.lblSelectInfo.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectInfo.Location = New System.Drawing.Point(690, 608)
        Me.lblSelectInfo.Name = "lblSelectInfo"
        Me.lblSelectInfo.Size = New System.Drawing.Size(181, 26)
        Me.lblSelectInfo.TabIndex = 17
        Me.lblSelectInfo.Text = "Selecionado: 1 Item"
        Me.lblSelectInfo.Visible = False
        '
        'frmCompraGetNFe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1191, 656)
        Me.Controls.Add(Me.lblSelectInfo)
        Me.Controls.Add(Me.btnTransp)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblInscricao)
        Me.Controls.Add(Me.lblTranspCNPJ)
        Me.Controls.Add(Me.lblCNPJ)
        Me.Controls.Add(Me.lblTransportadora)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblRazaoSocial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnSalvarCompra)
        Me.Controls.Add(Me.btnCorrelacao)
        Me.Controls.Add(Me.btnImportar)
        Me.Name = "frmCompraGetNFe"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnImportar, 0)
        Me.Controls.SetChildIndex(Me.btnCorrelacao, 0)
        Me.Controls.SetChildIndex(Me.btnSalvarCompra, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblRazaoSocial, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblTransportadora, 0)
        Me.Controls.SetChildIndex(Me.lblCNPJ, 0)
        Me.Controls.SetChildIndex(Me.lblTranspCNPJ, 0)
        Me.Controls.SetChildIndex(Me.lblInscricao, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Controls.SetChildIndex(Me.btnTransp, 0)
        Me.Controls.SetChildIndex(Me.lblSelectInfo, 0)
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
    Friend WithEvents lblRazaoSocial As Label
    Friend WithEvents lblCNPJ As Label
    Friend WithEvents lblInscricao As Label
    Friend WithEvents mnuItens As ContextMenuStrip
    Friend WithEvents miAnexarProduto As ToolStripMenuItem
    Friend WithEvents miAbrirProduto As ToolStripMenuItem
    Friend WithEvents miNovoProduto As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miObterProdutoDBAnterior As ToolStripMenuItem
    Friend WithEvents btnSalvarCompra As Button
    Friend WithEvents clnIDProdutoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnProdutoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidadeNFe As DataGridViewTextBoxColumn
    Friend WithEvents clnPrecoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnDescontoNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnTotalNfe As DataGridViewTextBoxColumn
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTransportadora As Label
    Friend WithEvents lblTranspCNPJ As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnTransp As Button
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents lblSelectInfo As Label
End Class
