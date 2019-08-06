<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProdutoTransacoes
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.dgvItens = New Controles.ctrlDataGridView()
        Me.clnData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnOperacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRGProduto = New System.Windows.Forms.Label()
        Me.btnTransacao = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtSaidas = New System.Windows.Forms.RadioButton()
        Me.rbtEntradas = New System.Windows.Forms.RadioButton()
        Me.rbtEntradaConsignacao = New System.Windows.Forms.RadioButton()
        Me.rbtEntradaTroca = New System.Windows.Forms.RadioButton()
        Me.rbtDevolucaoConsignacao = New System.Windows.Forms.RadioButton()
        Me.rbtDevolucaoCompra = New System.Windows.Forms.RadioButton()
        Me.rbtSimplesEntrada = New System.Windows.Forms.RadioButton()
        Me.rbtSimplesSaida = New System.Windows.Forms.RadioButton()
        Me.rbtCompras = New System.Windows.Forms.RadioButton()
        Me.rbtVenda = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(782, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(517, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(265, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Produto | Transações"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(750, 12)
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
        Me.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.Location = New System.Drawing.Point(392, 428)
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(6)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(123, 40)
        Me.btnFechar.TabIndex = 8
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
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Azure
        Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnData, Me.clnOperacao, Me.clnQuantidade, Me.clnPreco, Me.clnDesconto})
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
        Me.dgvItens.Location = New System.Drawing.Point(12, 103)
        Me.dgvItens.MultiSelect = False
        Me.dgvItens.Name = "dgvItens"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvItens.RowHeadersWidth = 35
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvItens.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItens.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowTemplate.Height = 33
        Me.dgvItens.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.Size = New System.Drawing.Size(503, 316)
        Me.dgvItens.TabIndex = 5
        '
        'clnData
        '
        Me.clnData.HeaderText = "Data"
        Me.clnData.MaxInputLength = 50
        Me.clnData.Name = "clnData"
        Me.clnData.Width = 80
        '
        'clnOperacao
        '
        Me.clnOperacao.HeaderText = "Operação"
        Me.clnOperacao.Name = "clnOperacao"
        Me.clnOperacao.ReadOnly = True
        Me.clnOperacao.Width = 110
        '
        'clnQuantidade
        '
        Me.clnQuantidade.HeaderText = "Quant"
        Me.clnQuantidade.MaxInputLength = 50
        Me.clnQuantidade.Name = "clnQuantidade"
        Me.clnQuantidade.Width = 70
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Produto:"
        '
        'lblProduto
        '
        Me.lblProduto.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduto.Location = New System.Drawing.Point(225, 63)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(502, 28)
        Me.lblProduto.TabIndex = 4
        Me.lblProduto.Text = "Produto"
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
        'lblRGProduto
        '
        Me.lblRGProduto.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRGProduto.Location = New System.Drawing.Point(62, 63)
        Me.lblRGProduto.Name = "lblRGProduto"
        Me.lblRGProduto.Size = New System.Drawing.Size(92, 28)
        Me.lblRGProduto.TabIndex = 2
        Me.lblRGProduto.Text = "Produto"
        '
        'btnTransacao
        '
        Me.btnTransacao.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnTransacao.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnTransacao.Location = New System.Drawing.Point(12, 429)
        Me.btnTransacao.Margin = New System.Windows.Forms.Padding(6)
        Me.btnTransacao.Name = "btnTransacao"
        Me.btnTransacao.Size = New System.Drawing.Size(190, 40)
        Me.btnTransacao.TabIndex = 7
        Me.btnTransacao.Text = "&Ir para Transação"
        Me.btnTransacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTransacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTransacao.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel2.Controls.Add(Me.rbtSaidas)
        Me.Panel2.Controls.Add(Me.rbtEntradas)
        Me.Panel2.Controls.Add(Me.rbtEntradaConsignacao)
        Me.Panel2.Controls.Add(Me.rbtEntradaTroca)
        Me.Panel2.Controls.Add(Me.rbtDevolucaoConsignacao)
        Me.Panel2.Controls.Add(Me.rbtDevolucaoCompra)
        Me.Panel2.Controls.Add(Me.rbtSimplesEntrada)
        Me.Panel2.Controls.Add(Me.rbtSimplesSaida)
        Me.Panel2.Controls.Add(Me.rbtCompras)
        Me.Panel2.Controls.Add(Me.rbtVenda)
        Me.Panel2.Location = New System.Drawing.Point(529, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(238, 365)
        Me.Panel2.TabIndex = 6
        '
        'rbtSaidas
        '
        Me.rbtSaidas.AutoSize = True
        Me.rbtSaidas.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
        Me.rbtSaidas.ForeColor = System.Drawing.Color.Firebrick
        Me.rbtSaidas.Location = New System.Drawing.Point(72, 9)
        Me.rbtSaidas.Name = "rbtSaidas"
        Me.rbtSaidas.Size = New System.Drawing.Size(95, 30)
        Me.rbtSaidas.TabIndex = 0
        Me.rbtSaidas.TabStop = True
        Me.rbtSaidas.Tag = "100"
        Me.rbtSaidas.Text = "SAÍDAS"
        Me.rbtSaidas.UseVisualStyleBackColor = True
        '
        'rbtEntradas
        '
        Me.rbtEntradas.AutoSize = True
        Me.rbtEntradas.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
        Me.rbtEntradas.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rbtEntradas.Location = New System.Drawing.Point(55, 180)
        Me.rbtEntradas.Name = "rbtEntradas"
        Me.rbtEntradas.Size = New System.Drawing.Size(125, 30)
        Me.rbtEntradas.TabIndex = 5
        Me.rbtEntradas.TabStop = True
        Me.rbtEntradas.Tag = "101"
        Me.rbtEntradas.Text = "ENTRADAS"
        Me.rbtEntradas.UseVisualStyleBackColor = True
        '
        'rbtEntradaConsignacao
        '
        Me.rbtEntradaConsignacao.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtEntradaConsignacao.Location = New System.Drawing.Point(21, 316)
        Me.rbtEntradaConsignacao.Name = "rbtEntradaConsignacao"
        Me.rbtEntradaConsignacao.Size = New System.Drawing.Size(196, 29)
        Me.rbtEntradaConsignacao.TabIndex = 9
        Me.rbtEntradaConsignacao.Tag = "7"
        Me.rbtEntradaConsignacao.Text = "Entrada de Consignação"
        Me.rbtEntradaConsignacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtEntradaConsignacao.UseVisualStyleBackColor = True
        '
        'rbtEntradaTroca
        '
        Me.rbtEntradaTroca.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtEntradaTroca.Location = New System.Drawing.Point(21, 281)
        Me.rbtEntradaTroca.Name = "rbtEntradaTroca"
        Me.rbtEntradaTroca.Size = New System.Drawing.Size(196, 29)
        Me.rbtEntradaTroca.TabIndex = 8
        Me.rbtEntradaTroca.Tag = "5"
        Me.rbtEntradaTroca.Text = "Entrada de Troca"
        Me.rbtEntradaTroca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtEntradaTroca.UseVisualStyleBackColor = True
        '
        'rbtDevolucaoConsignacao
        '
        Me.rbtDevolucaoConsignacao.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtDevolucaoConsignacao.Location = New System.Drawing.Point(19, 145)
        Me.rbtDevolucaoConsignacao.Name = "rbtDevolucaoConsignacao"
        Me.rbtDevolucaoConsignacao.Size = New System.Drawing.Size(200, 29)
        Me.rbtDevolucaoConsignacao.TabIndex = 4
        Me.rbtDevolucaoConsignacao.Tag = "8"
        Me.rbtDevolucaoConsignacao.Text = "Devolução de Consignação"
        Me.rbtDevolucaoConsignacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtDevolucaoConsignacao.UseVisualStyleBackColor = True
        '
        'rbtDevolucaoCompra
        '
        Me.rbtDevolucaoCompra.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtDevolucaoCompra.Location = New System.Drawing.Point(19, 110)
        Me.rbtDevolucaoCompra.Name = "rbtDevolucaoCompra"
        Me.rbtDevolucaoCompra.Size = New System.Drawing.Size(200, 29)
        Me.rbtDevolucaoCompra.TabIndex = 3
        Me.rbtDevolucaoCompra.Tag = "6"
        Me.rbtDevolucaoCompra.Text = "Devolução de Compra"
        Me.rbtDevolucaoCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtDevolucaoCompra.UseVisualStyleBackColor = True
        '
        'rbtSimplesEntrada
        '
        Me.rbtSimplesEntrada.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtSimplesEntrada.Location = New System.Drawing.Point(21, 246)
        Me.rbtSimplesEntrada.Name = "rbtSimplesEntrada"
        Me.rbtSimplesEntrada.Size = New System.Drawing.Size(196, 29)
        Me.rbtSimplesEntrada.TabIndex = 7
        Me.rbtSimplesEntrada.Tag = "3"
        Me.rbtSimplesEntrada.Text = "Simples Entradas"
        Me.rbtSimplesEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtSimplesEntrada.UseVisualStyleBackColor = True
        '
        'rbtSimplesSaida
        '
        Me.rbtSimplesSaida.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtSimplesSaida.Location = New System.Drawing.Point(19, 75)
        Me.rbtSimplesSaida.Name = "rbtSimplesSaida"
        Me.rbtSimplesSaida.Size = New System.Drawing.Size(200, 29)
        Me.rbtSimplesSaida.TabIndex = 2
        Me.rbtSimplesSaida.Tag = "4"
        Me.rbtSimplesSaida.Text = "Simples Saídas"
        Me.rbtSimplesSaida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtSimplesSaida.UseVisualStyleBackColor = True
        '
        'rbtCompras
        '
        Me.rbtCompras.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtCompras.Location = New System.Drawing.Point(21, 211)
        Me.rbtCompras.Name = "rbtCompras"
        Me.rbtCompras.Size = New System.Drawing.Size(196, 29)
        Me.rbtCompras.TabIndex = 6
        Me.rbtCompras.Tag = "2"
        Me.rbtCompras.Text = "Compras"
        Me.rbtCompras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtCompras.UseVisualStyleBackColor = True
        '
        'rbtVenda
        '
        Me.rbtVenda.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtVenda.Checked = True
        Me.rbtVenda.Location = New System.Drawing.Point(19, 40)
        Me.rbtVenda.Name = "rbtVenda"
        Me.rbtVenda.Size = New System.Drawing.Size(200, 29)
        Me.rbtVenda.TabIndex = 1
        Me.rbtVenda.TabStop = True
        Me.rbtVenda.Tag = "1"
        Me.rbtVenda.Text = "Vendas"
        Me.rbtVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtVenda.UseVisualStyleBackColor = True
        '
        'frmProdutoTransacoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(782, 484)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblRGProduto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblProduto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.btnTransacao)
        Me.Controls.Add(Me.btnFechar)
        Me.Name = "frmProdutoTransacoes"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnTransacao, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblProduto, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblRGProduto, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents btnFechar As Button
    Friend WithEvents dgvItens As Controles.ctrlDataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblProduto As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblRGProduto As Label
    Friend WithEvents btnTransacao As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbtDevolucaoCompra As RadioButton
    Friend WithEvents rbtSimplesSaida As RadioButton
    Friend WithEvents rbtVenda As RadioButton
    Friend WithEvents rbtEntradaTroca As RadioButton
    Friend WithEvents rbtSimplesEntrada As RadioButton
    Friend WithEvents rbtCompras As RadioButton
    Friend WithEvents rbtEntradaConsignacao As RadioButton
    Friend WithEvents rbtDevolucaoConsignacao As RadioButton
    Friend WithEvents clnData As DataGridViewTextBoxColumn
    Friend WithEvents clnOperacao As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
    Friend WithEvents rbtEntradas As RadioButton
    Friend WithEvents rbtSaidas As RadioButton
End Class
