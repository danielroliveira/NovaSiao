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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.txtInscricao = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCNPJ = New System.Windows.Forms.MaskedTextBox()
        Me.txtRazaoSocial = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.btnCorrelacao = New System.Windows.Forms.Button()
        Me.clnIDProdutoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProdutoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidadeNFe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPrecoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDescontoNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnTotalNfe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnImportar.Location = New System.Drawing.Point(10, 601)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(195, 43)
        Me.btnImportar.TabIndex = 2
        Me.btnImportar.Text = "Importar XML"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.Location = New System.Drawing.Point(1069, 601)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(104, 43)
        Me.btnFechar.TabIndex = 2
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'txtInscricao
        '
        Me.txtInscricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInscricao.Location = New System.Drawing.Point(391, 101)
        Me.txtInscricao.MaxLength = 20
        Me.txtInscricao.Name = "txtInscricao"
        Me.txtInscricao.Size = New System.Drawing.Size(190, 27)
        Me.txtInscricao.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(286, 104)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 19)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Insc. Estadual"
        '
        'txtCNPJ
        '
        Me.txtCNPJ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCNPJ.Location = New System.Drawing.Point(127, 101)
        Me.txtCNPJ.Mask = "00,000,000/0000-00"
        Me.txtCNPJ.Name = "txtCNPJ"
        Me.txtCNPJ.Size = New System.Drawing.Size(152, 27)
        Me.txtCNPJ.TabIndex = 15
        Me.txtCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtRazaoSocial
        '
        Me.txtRazaoSocial.BackColor = System.Drawing.Color.White
        Me.txtRazaoSocial.Location = New System.Drawing.Point(127, 68)
        Me.txtRazaoSocial.MaxLength = 50
        Me.txtRazaoSocial.Name = "txtRazaoSocial"
        Me.txtRazaoSocial.Size = New System.Drawing.Size(454, 27)
        Me.txtRazaoSocial.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(81, 104)
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
        Me.Label2.Location = New System.Drawing.Point(31, 71)
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
        'btnCorrelacao
        '
        Me.btnCorrelacao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCorrelacao.Location = New System.Drawing.Point(211, 601)
        Me.btnCorrelacao.Name = "btnCorrelacao"
        Me.btnCorrelacao.Size = New System.Drawing.Size(195, 43)
        Me.btnCorrelacao.TabIndex = 2
        Me.btnCorrelacao.Text = "Fazer Correlação"
        Me.btnCorrelacao.UseVisualStyleBackColor = True
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
        'frmCompraGetNFe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1191, 656)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.txtInscricao)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtCNPJ)
        Me.Controls.Add(Me.txtRazaoSocial)
        Me.Controls.Add(Me.Label4)
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
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtRazaoSocial, 0)
        Me.Controls.SetChildIndex(Me.txtCNPJ, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txtInscricao, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnImportar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents txtInscricao As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCNPJ As MaskedTextBox
    Friend WithEvents txtRazaoSocial As TextBox
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
End Class
