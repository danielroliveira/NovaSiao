<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSimplesEntrada
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
        Me.vtab1 = New VIBlend.WinForms.Controls.vTabPage()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.clnIDTransacaoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnICMS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnMVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIPI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vtab2 = New VIBlend.WinForms.Controls.vTabPage()
        Me.btnInserirObservacao = New System.Windows.Forms.Button()
        Me.lblTotalProdutos = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalCobrado = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgvAPagar = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIdentificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.vtab3 = New VIBlend.WinForms.Controls.vTabPage()
        Me.pnlNota = New System.Windows.Forms.Panel()
        Me.txtChaveAcesso = New System.Windows.Forms.TextBox()
        Me.btnNotaCancel = New System.Windows.Forms.Button()
        Me.btnNotaOK = New System.Windows.Forms.Button()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNotaValor = New Controles.Text_Monetario()
        Me.txtEmissaoData = New Controles.MaskText_Data()
        Me.txtNotaNumero = New Controles.Text_SoNumeros()
        Me.txtNotaSerie = New Controles.Text_SoNumeros()
        Me.cmbNotaTipo = New Controles.ComboBox_OnlyValues()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvVendaNotas = New System.Windows.Forms.DataGridView()
        Me.clnChaveAcesso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnNotaTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnNotaSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnNotaNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnEmissaoData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnNotaValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCli = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.lblTransacaoData = New System.Windows.Forms.Label()
        Me.lblIDTransacao = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.VApplicationMenuItem2 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.VApplicationMenuItem3 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.VApplicationMenuItem4 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.btnFinalizar = New VIBlend.WinForms.Controls.vButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.btnAdicionar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.miImprimirEtiquetas = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImprimirRelatorio = New System.Windows.Forms.ToolStripMenuItem()
        Me.VPanel2 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblFilialOrigem = New System.Windows.Forms.Label()
        Me.Content = New VIBlend.WinForms.Controls.vContentPanel()
        Me.lblTotalGeral = New System.Windows.Forms.Label()
        Me.VPanel1 = New VIBlend.WinForms.Controls.vPanel()
        Me.Panel1.SuspendLayout()
        Me.tabPrincipal.SuspendLayout()
        Me.vtab1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vtab2.SuspendLayout()
        CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vtab3.SuspendLayout()
        Me.pnlNota.SuspendLayout()
        CType(Me.dgvVendaNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.VPanel2.Content.SuspendLayout()
        Me.VPanel2.SuspendLayout()
        Me.VPanel1.Content.SuspendLayout()
        Me.VPanel1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.lblIDTransacao)
        Me.Panel1.Controls.Add(Me.lblTransacaoData)
        Me.Panel1.Size = New System.Drawing.Size(1200, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTransacaoData, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblIDTransacao, 0)
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
        Me.lblTitulo.Location = New System.Drawing.Point(951, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(249, 50)
        Me.lblTitulo.Text = "Simples Entrada"
        '
        'tabPrincipal
        '
        Me.tabPrincipal.AllowAnimations = True
        Me.tabPrincipal.AllPagesHeight = 28
        Me.tabPrincipal.Controls.Add(Me.vtab1)
        Me.tabPrincipal.Controls.Add(Me.vtab2)
        Me.tabPrincipal.Controls.Add(Me.vtab3)
        Me.tabPrincipal.ForeColor = System.Drawing.Color.Black
        Me.tabPrincipal.Location = New System.Drawing.Point(9, 106)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 38, 0, 0)
        Me.tabPrincipal.Size = New System.Drawing.Size(1180, 500)
        Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
        Me.tabPrincipal.TabIndex = 2
        Me.tabPrincipal.TabPages.Add(Me.vtab1)
        Me.tabPrincipal.TabPages.Add(Me.vtab2)
        Me.tabPrincipal.TabPages.Add(Me.vtab3)
        Me.tabPrincipal.TabsAreaBackColor = System.Drawing.Color.OldLace
        Me.tabPrincipal.TabsInitialOffset = 40
        Me.tabPrincipal.TabsShape = VIBlend.WinForms.Controls.TabsShape.Chrome
        Me.tabPrincipal.TabsSpacing = 10
        Me.tabPrincipal.TitleHeight = 38
        Me.tabPrincipal.UseTabsAreaBackColor = True
        Me.tabPrincipal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        '
        'vtab1
        '
        Me.vtab1.Controls.Add(Me.dgvItens)
        Me.vtab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.ForeColor = System.Drawing.Color.Black
        Me.vtab1.Location = New System.Drawing.Point(0, 38)
        Me.vtab1.Name = "vtab1"
        Me.vtab1.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab1.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.Size = New System.Drawing.Size(1180, 462)
        Me.vtab1.TabIndex = 3
        Me.vtab1.Text = "Produtos"
        Me.vtab1.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.TooltipText = "TabPage"
        Me.vtab1.UseDefaultTextFont = False
        Me.vtab1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab1.Visible = False
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
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
        Me.dgvItens.ColumnHeadersHeight = 25
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDTransacaoItem, Me.clnRGProduto, Me.clnProduto, Me.clnQuantidade, Me.clnPreco, Me.clnSubTotal, Me.clnDesconto, Me.clnTotal, Me.clnICMS, Me.clnST, Me.clnMVA, Me.clnIPI})
        Me.dgvItens.EnableHeadersVisualStyles = False
        Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvItens.Location = New System.Drawing.Point(9, 9)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.ReadOnly = True
        Me.dgvItens.RowHeadersWidth = 30
        Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvItens.Size = New System.Drawing.Size(1162, 444)
        Me.dgvItens.TabIndex = 0
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
        Me.clnRGProduto.Width = 60
        '
        'clnProduto
        '
        Me.clnProduto.Frozen = True
        Me.clnProduto.HeaderText = "Produto"
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.ReadOnly = True
        Me.clnProduto.Width = 375
        '
        'clnQuantidade
        '
        Me.clnQuantidade.Frozen = True
        Me.clnQuantidade.HeaderText = "Qtde"
        Me.clnQuantidade.Name = "clnQuantidade"
        Me.clnQuantidade.ReadOnly = True
        Me.clnQuantidade.Width = 60
        '
        'clnPreco
        '
        Me.clnPreco.Frozen = True
        Me.clnPreco.HeaderText = "Preço"
        Me.clnPreco.Name = "clnPreco"
        Me.clnPreco.ReadOnly = True
        Me.clnPreco.Width = 90
        '
        'clnSubTotal
        '
        Me.clnSubTotal.Frozen = True
        Me.clnSubTotal.HeaderText = "SubTotal"
        Me.clnSubTotal.Name = "clnSubTotal"
        Me.clnSubTotal.ReadOnly = True
        Me.clnSubTotal.Width = 90
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
        Me.clnTotal.Width = 90
        '
        'clnICMS
        '
        Me.clnICMS.HeaderText = "ICMS"
        Me.clnICMS.Name = "clnICMS"
        Me.clnICMS.ReadOnly = True
        Me.clnICMS.Width = 60
        '
        'clnST
        '
        Me.clnST.HeaderText = "ST"
        Me.clnST.Name = "clnST"
        Me.clnST.ReadOnly = True
        Me.clnST.Width = 75
        '
        'clnMVA
        '
        Me.clnMVA.HeaderText = "MVA"
        Me.clnMVA.Name = "clnMVA"
        Me.clnMVA.ReadOnly = True
        Me.clnMVA.Width = 60
        '
        'clnIPI
        '
        Me.clnIPI.HeaderText = "IPI"
        Me.clnIPI.Name = "clnIPI"
        Me.clnIPI.ReadOnly = True
        Me.clnIPI.Width = 60
        '
        'vtab2
        '
        Me.vtab2.Controls.Add(Me.btnInserirObservacao)
        Me.vtab2.Controls.Add(Me.lblTotalProdutos)
        Me.vtab2.Controls.Add(Me.Label27)
        Me.vtab2.Controls.Add(Me.txtObservacao)
        Me.vtab2.Controls.Add(Me.Label12)
        Me.vtab2.Controls.Add(Me.lblTotalCobrado)
        Me.vtab2.Controls.Add(Me.Label17)
        Me.vtab2.Controls.Add(Me.dgvAPagar)
        Me.vtab2.Controls.Add(Me.Label6)
        Me.vtab2.Controls.Add(Me.ShapeContainer2)
        Me.vtab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Location = New System.Drawing.Point(0, 38)
        Me.vtab2.Name = "vtab2"
        Me.vtab2.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab2.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Size = New System.Drawing.Size(1180, 462)
        Me.vtab2.TabIndex = 4
        Me.vtab2.Text = "Pagamentos"
        Me.vtab2.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.TooltipText = "TabPage"
        Me.vtab2.UseDefaultTextFont = False
        Me.vtab2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab2.Visible = False
        '
        'btnInserirObservacao
        '
        Me.btnInserirObservacao.BackColor = System.Drawing.Color.Azure
        Me.btnInserirObservacao.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnInserirObservacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInserirObservacao.Location = New System.Drawing.Point(959, 172)
        Me.btnInserirObservacao.Name = "btnInserirObservacao"
        Me.btnInserirObservacao.Size = New System.Drawing.Size(163, 40)
        Me.btnInserirObservacao.TabIndex = 16
        Me.btnInserirObservacao.Tag = "Inserir"
        Me.btnInserirObservacao.Text = "Alterar &Observação"
        Me.btnInserirObservacao.UseVisualStyleBackColor = False
        '
        'lblTotalProdutos
        '
        Me.lblTotalProdutos.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalProdutos.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalProdutos.Location = New System.Drawing.Point(396, 315)
        Me.lblTotalProdutos.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalProdutos.Name = "lblTotalProdutos"
        Me.lblTotalProdutos.Size = New System.Drawing.Size(151, 32)
        Me.lblTotalProdutos.TabIndex = 12
        Me.lblTotalProdutos.Text = "R$ 0,00"
        Me.lblTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Location = New System.Drawing.Point(256, 315)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(134, 19)
        Me.Label27.TabIndex = 13
        Me.Label27.Text = "Valor dos Produtos:"
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(691, 57)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(431, 109)
        Me.txtObservacao.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(670, 15)
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
        Me.lblTotalCobrado.Location = New System.Drawing.Point(396, 273)
        Me.lblTotalCobrado.Name = "lblTotalCobrado"
        Me.lblTotalCobrado.Size = New System.Drawing.Size(151, 32)
        Me.lblTotalCobrado.TabIndex = 12
        Me.lblTotalCobrado.Text = "R$ 0,00"
        Me.lblTotalCobrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(287, 273)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 19)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Total Cobrado:"
        '
        'dgvAPagar
        '
        Me.dgvAPagar.AllowUserToAddRows = False
        Me.dgvAPagar.AllowUserToDeleteRows = False
        Me.dgvAPagar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvAPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAPagar.ColumnHeadersHeight = 30
        Me.dgvAPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnForma, Me.clnIdentificador, Me.clnVencimento, Me.clnValor})
        Me.dgvAPagar.EnableHeadersVisualStyles = False
        Me.dgvAPagar.Location = New System.Drawing.Point(33, 57)
        Me.dgvAPagar.MultiSelect = False
        Me.dgvAPagar.Name = "dgvAPagar"
        Me.dgvAPagar.ReadOnly = True
        Me.dgvAPagar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvAPagar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAPagar.Size = New System.Drawing.Size(550, 204)
        Me.dgvAPagar.TabIndex = 9
        '
        'clnID
        '
        Me.clnID.HeaderText = "IDAPagar"
        Me.clnID.Name = "clnID"
        Me.clnID.ReadOnly = True
        Me.clnID.Visible = False
        '
        'clnForma
        '
        Me.clnForma.HeaderText = "Forma"
        Me.clnForma.Name = "clnForma"
        Me.clnForma.ReadOnly = True
        Me.clnForma.Width = 160
        '
        'clnIdentificador
        '
        Me.clnIdentificador.HeaderText = "No. Reg.:"
        Me.clnIdentificador.Name = "clnIdentificador"
        Me.clnIdentificador.ReadOnly = True
        '
        'clnVencimento
        '
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.clnVencimento.DefaultCellStyle = DataGridViewCellStyle3
        Me.clnVencimento.HeaderText = "Vencimento"
        Me.clnVencimento.Name = "clnVencimento"
        Me.clnVencimento.ReadOnly = True
        Me.clnVencimento.Width = 110
        '
        'clnValor
        '
        Me.clnValor.HeaderText = "Valor"
        Me.clnValor.Name = "clnValor"
        Me.clnValor.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 15.75!)
        Me.Label6.Location = New System.Drawing.Point(18, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(264, 26)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Desdobramento das Parcelas:"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(4, 4)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1172, 454)
        Me.ShapeContainer2.TabIndex = 14
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape4.BorderWidth = 3
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 902
        Me.LineShape4.X2 = 1129
        Me.LineShape4.Y1 = 26
        Me.LineShape4.Y2 = 26
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape3.BorderWidth = 3
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 280
        Me.LineShape3.X2 = 580
        Me.LineShape3.Y1 = 26
        Me.LineShape3.Y2 = 26
        '
        'vtab3
        '
        Me.vtab3.Controls.Add(Me.pnlNota)
        Me.vtab3.Controls.Add(Me.Label11)
        Me.vtab3.Controls.Add(Me.dgvVendaNotas)
        Me.vtab3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab3.Location = New System.Drawing.Point(0, 38)
        Me.vtab3.Name = "vtab3"
        Me.vtab3.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab3.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab3.Size = New System.Drawing.Size(1180, 462)
        Me.vtab3.TabIndex = 5
        Me.vtab3.Text = "Notas Fiscais"
        Me.vtab3.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab3.TooltipText = "TabPage"
        Me.vtab3.UseDefaultTextFont = False
        Me.vtab3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab3.Visible = False
        '
        'pnlNota
        '
        Me.pnlNota.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlNota.Controls.Add(Me.txtChaveAcesso)
        Me.pnlNota.Controls.Add(Me.btnNotaCancel)
        Me.pnlNota.Controls.Add(Me.btnNotaOK)
        Me.pnlNota.Controls.Add(Me.lblNota)
        Me.pnlNota.Controls.Add(Me.Label23)
        Me.pnlNota.Controls.Add(Me.Label25)
        Me.pnlNota.Controls.Add(Me.Label24)
        Me.pnlNota.Controls.Add(Me.Label22)
        Me.pnlNota.Controls.Add(Me.Label21)
        Me.pnlNota.Controls.Add(Me.Label16)
        Me.pnlNota.Controls.Add(Me.txtNotaValor)
        Me.pnlNota.Controls.Add(Me.txtEmissaoData)
        Me.pnlNota.Controls.Add(Me.txtNotaNumero)
        Me.pnlNota.Controls.Add(Me.txtNotaSerie)
        Me.pnlNota.Controls.Add(Me.cmbNotaTipo)
        Me.pnlNota.Location = New System.Drawing.Point(882, 46)
        Me.pnlNota.Name = "pnlNota"
        Me.pnlNota.Size = New System.Drawing.Size(280, 352)
        Me.pnlNota.TabIndex = 5
        Me.pnlNota.Visible = False
        '
        'txtChaveAcesso
        '
        Me.txtChaveAcesso.Location = New System.Drawing.Point(25, 66)
        Me.txtChaveAcesso.Multiline = True
        Me.txtChaveAcesso.Name = "txtChaveAcesso"
        Me.txtChaveAcesso.Size = New System.Drawing.Size(232, 54)
        Me.txtChaveAcesso.TabIndex = 0
        '
        'btnNotaCancel
        '
        Me.btnNotaCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnNotaCancel.Location = New System.Drawing.Point(144, 296)
        Me.btnNotaCancel.Name = "btnNotaCancel"
        Me.btnNotaCancel.Size = New System.Drawing.Size(113, 38)
        Me.btnNotaCancel.TabIndex = 7
        Me.btnNotaCancel.Text = "Cancelar"
        Me.btnNotaCancel.UseVisualStyleBackColor = True
        '
        'btnNotaOK
        '
        Me.btnNotaOK.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnNotaOK.Location = New System.Drawing.Point(25, 296)
        Me.btnNotaOK.Name = "btnNotaOK"
        Me.btnNotaOK.Size = New System.Drawing.Size(113, 38)
        Me.btnNotaOK.TabIndex = 6
        Me.btnNotaOK.Text = "Inserir"
        Me.btnNotaOK.UseVisualStyleBackColor = True
        '
        'lblNota
        '
        Me.lblNota.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNota.Location = New System.Drawing.Point(20, 7)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(245, 26)
        Me.lblNota.TabIndex = 7
        Me.lblNota.Text = "Inserindo Nota Fiscal"
        Me.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(143, 179)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 19)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Número"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(143, 231)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(78, 19)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Valor Total"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(25, 231)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(86, 19)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Dt. Emissão"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(25, 179)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 19)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Série"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(25, 127)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 19)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Nota Tipo"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(25, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 19)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Chave de Acesso"
        '
        'txtNotaValor
        '
        Me.txtNotaValor.Location = New System.Drawing.Point(147, 253)
        Me.txtNotaValor.Name = "txtNotaValor"
        Me.txtNotaValor.Size = New System.Drawing.Size(110, 27)
        Me.txtNotaValor.TabIndex = 5
        Me.txtNotaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmissaoData
        '
        Me.txtEmissaoData.Location = New System.Drawing.Point(25, 253)
        Me.txtEmissaoData.Mask = "00/00/0000"
        Me.txtEmissaoData.Name = "txtEmissaoData"
        Me.txtEmissaoData.Size = New System.Drawing.Size(100, 27)
        Me.txtEmissaoData.TabIndex = 4
        '
        'txtNotaNumero
        '
        Me.txtNotaNumero.Inteiro = True
        Me.txtNotaNumero.Location = New System.Drawing.Point(147, 201)
        Me.txtNotaNumero.MaxLength = 12
        Me.txtNotaNumero.Name = "txtNotaNumero"
        Me.txtNotaNumero.Size = New System.Drawing.Size(110, 27)
        Me.txtNotaNumero.TabIndex = 3
        Me.txtNotaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNotaSerie
        '
        Me.txtNotaSerie.Inteiro = True
        Me.txtNotaSerie.Location = New System.Drawing.Point(25, 201)
        Me.txtNotaSerie.MaxLength = 4
        Me.txtNotaSerie.Name = "txtNotaSerie"
        Me.txtNotaSerie.Size = New System.Drawing.Size(68, 27)
        Me.txtNotaSerie.TabIndex = 2
        Me.txtNotaSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbNotaTipo
        '
        Me.cmbNotaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNotaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNotaTipo.FormattingEnabled = True
        Me.cmbNotaTipo.Location = New System.Drawing.Point(25, 149)
        Me.cmbNotaTipo.Name = "cmbNotaTipo"
        Me.cmbNotaTipo.RestrictContentToListItems = True
        Me.cmbNotaTipo.Size = New System.Drawing.Size(156, 27)
        Me.cmbNotaTipo.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(26, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(185, 19)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Notas e/ou Cupons Fiscais:"
        '
        'dgvVendaNotas
        '
        Me.dgvVendaNotas.AllowUserToAddRows = False
        Me.dgvVendaNotas.AllowUserToDeleteRows = False
        Me.dgvVendaNotas.AllowUserToResizeColumns = False
        Me.dgvVendaNotas.AllowUserToResizeRows = False
        Me.dgvVendaNotas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvVendaNotas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVendaNotas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVendaNotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvVendaNotas.ColumnHeadersHeight = 30
        Me.dgvVendaNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvVendaNotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnChaveAcesso, Me.clnNotaTipo, Me.clnNotaSerie, Me.clnNotaNumero, Me.clnEmissaoData, Me.clnNotaValor})
        Me.dgvVendaNotas.EnableHeadersVisualStyles = False
        Me.dgvVendaNotas.Location = New System.Drawing.Point(20, 46)
        Me.dgvVendaNotas.Name = "dgvVendaNotas"
        Me.dgvVendaNotas.ReadOnly = True
        Me.dgvVendaNotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvVendaNotas.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvVendaNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVendaNotas.Size = New System.Drawing.Size(846, 312)
        Me.dgvVendaNotas.TabIndex = 3
        '
        'clnChaveAcesso
        '
        Me.clnChaveAcesso.HeaderText = "Chave Acesso"
        Me.clnChaveAcesso.Name = "clnChaveAcesso"
        Me.clnChaveAcesso.ReadOnly = True
        Me.clnChaveAcesso.Width = 350
        '
        'clnNotaTipo
        '
        Me.clnNotaTipo.HeaderText = "Tipo"
        Me.clnNotaTipo.Name = "clnNotaTipo"
        Me.clnNotaTipo.ReadOnly = True
        Me.clnNotaTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'clnNotaSerie
        '
        Me.clnNotaSerie.HeaderText = "Série"
        Me.clnNotaSerie.Name = "clnNotaSerie"
        Me.clnNotaSerie.ReadOnly = True
        Me.clnNotaSerie.Width = 70
        '
        'clnNotaNumero
        '
        Me.clnNotaNumero.HeaderText = "Número"
        Me.clnNotaNumero.Name = "clnNotaNumero"
        Me.clnNotaNumero.ReadOnly = True
        Me.clnNotaNumero.Width = 70
        '
        'clnEmissaoData
        '
        Me.clnEmissaoData.HeaderText = "Data"
        Me.clnEmissaoData.Name = "clnEmissaoData"
        Me.clnEmissaoData.ReadOnly = True
        '
        'clnNotaValor
        '
        Me.clnNotaValor.HeaderText = "Valor"
        Me.clnNotaValor.Name = "clnNotaValor"
        Me.clnNotaValor.ReadOnly = True
        Me.clnNotaValor.Width = 80
        '
        'lblCli
        '
        Me.lblCli.AutoSize = True
        Me.lblCli.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCli.Location = New System.Drawing.Point(13, 69)
        Me.lblCli.Name = "lblCli"
        Me.lblCli.Size = New System.Drawing.Size(98, 19)
        Me.lblCli.TabIndex = 6
        Me.lblCli.Text = "Filial Origem:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(166, 4)
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
        Me.lbl_IdTexto.ForeColor = System.Drawing.Color.Gainsboro
        Me.lbl_IdTexto.Location = New System.Drawing.Point(29, 4)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 51
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTransacaoData
        '
        Me.lblTransacaoData.BackColor = System.Drawing.Color.Transparent
        Me.lblTransacaoData.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransacaoData.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblTransacaoData.Location = New System.Drawing.Point(112, 16)
        Me.lblTransacaoData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTransacaoData.Name = "lblTransacaoData"
        Me.lblTransacaoData.Size = New System.Drawing.Size(155, 30)
        Me.lblTransacaoData.TabIndex = 48
        Me.lblTransacaoData.Text = "01/01/2017"
        Me.lblTransacaoData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIDTransacao
        '
        Me.lblIDTransacao.BackColor = System.Drawing.Color.Transparent
        Me.lblIDTransacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDTransacao.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblIDTransacao.Location = New System.Drawing.Point(5, 16)
        Me.lblIDTransacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIDTransacao.Name = "lblIDTransacao"
        Me.lblIDTransacao.Size = New System.Drawing.Size(85, 30)
        Me.lblIDTransacao.TabIndex = 49
        Me.lblIDTransacao.Text = "0001"
        Me.lblIDTransacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(1168, 14)
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(897, 623)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 19)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Total Geral:"
        '
        'lblSituacao
        '
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblSituacao.Location = New System.Drawing.Point(320, 16)
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
        Me.Label15.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label15.Location = New System.Drawing.Point(357, 4)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Situação:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.btnFinalizar.ImageAbsolutePosition = New System.Drawing.Point(15, 5)
        Me.btnFinalizar.Location = New System.Drawing.Point(530, 614)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Opacity = 0!
        Me.btnFinalizar.RoundedCornersMask = CType(15, Byte)
        Me.btnFinalizar.RoundedCornersRadius = 0
        Me.btnFinalizar.Size = New System.Drawing.Size(140, 42)
        Me.btnFinalizar.TabIndex = 3
        Me.btnFinalizar.Text = "&Finalizar"
        Me.btnFinalizar.TextAbsolutePosition = New System.Drawing.Point(20, 1)
        Me.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFinalizar.UseAbsoluteImagePositioning = True
        Me.btnFinalizar.UseAbsoluteTextPositioning = True
        Me.btnFinalizar.UseVisualStyleBackColor = False
        Me.btnFinalizar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICEBLACK
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label18.Location = New System.Drawing.Point(522, 4)
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
        Me.lblFilial.Location = New System.Drawing.Point(473, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(145, 30)
        Me.lblFilial.TabIndex = 55
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnAdicionar, Me.ToolStripSeparator2, Me.btnImprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(10, 612)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(517, 47)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnProcurar
        '
        Me.btnProcurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.search1
        Me.btnProcurar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProcurar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(36, 44)
        Me.btnProcurar.Text = "ToolStripButton1"
        '
        'btnAdicionar
        '
        Me.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAdicionar.Image = Global.NovaSiao.My.Resources.Resources.add_32x32
        Me.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdicionar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(36, 44)
        Me.btnAdicionar.Text = "ToolStripButton2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 47)
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirEtiquetas, Me.miImprimirRelatorio})
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(56, 44)
        Me.btnImprimir.Text = "ToolStripSplitButton1"
        '
        'miImprimirEtiquetas
        '
        Me.miImprimirEtiquetas.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.miImprimirEtiquetas.Name = "miImprimirEtiquetas"
        Me.miImprimirEtiquetas.Size = New System.Drawing.Size(183, 22)
        Me.miImprimirEtiquetas.Text = "Etiquetas"
        '
        'miImprimirRelatorio
        '
        Me.miImprimirRelatorio.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.miImprimirRelatorio.Name = "miImprimirRelatorio"
        Me.miImprimirRelatorio.Size = New System.Drawing.Size(183, 22)
        Me.miImprimirRelatorio.Text = "Relatório da Compra"
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
        Me.VPanel2.Content.Controls.Add(Me.lblFilialOrigem)
        Me.VPanel2.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel2.Content.Name = "Content"
        Me.VPanel2.Content.Size = New System.Drawing.Size(346, 29)
        Me.VPanel2.Content.TabIndex = 3
        Me.VPanel2.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel2.Location = New System.Drawing.Point(116, 63)
        Me.VPanel2.Name = "VPanel2"
        Me.VPanel2.Opacity = 1.0!
        Me.VPanel2.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel2.Size = New System.Drawing.Size(348, 31)
        Me.VPanel2.TabIndex = 18
        Me.VPanel2.Text = "VPanel2"
        Me.VPanel2.UsePanelBorderColor = True
        Me.VPanel2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblFilialOrigem
        '
        Me.lblFilialOrigem.BackColor = System.Drawing.Color.White
        Me.lblFilialOrigem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFilialOrigem.Location = New System.Drawing.Point(0, 0)
        Me.lblFilialOrigem.Name = "lblFilialOrigem"
        Me.lblFilialOrigem.Size = New System.Drawing.Size(346, 29)
        Me.lblFilialOrigem.TabIndex = 5
        Me.lblFilialOrigem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Content
        '
        Me.Content.AutoScroll = True
        Me.Content.BackColor = System.Drawing.SystemColors.Control
        Me.Content.Location = New System.Drawing.Point(1, 1)
        Me.Content.Name = "Content"
        Me.Content.Size = New System.Drawing.Size(200, 37)
        Me.Content.TabIndex = 3
        '
        'lblTotalGeral
        '
        Me.lblTotalGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalGeral.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalGeral.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalGeral.Name = "lblTotalGeral"
        Me.lblTotalGeral.Size = New System.Drawing.Size(200, 37)
        Me.lblTotalGeral.TabIndex = 9
        Me.lblTotalGeral.Text = "R$ 0,00"
        Me.lblTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.VPanel1.Content.Controls.Add(Me.lblTotalGeral)
        Me.VPanel1.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel1.Content.Name = "Content"
        Me.VPanel1.Content.Size = New System.Drawing.Size(200, 37)
        Me.VPanel1.Content.TabIndex = 3
        Me.VPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel1.Location = New System.Drawing.Point(987, 614)
        Me.VPanel1.Name = "VPanel1"
        Me.VPanel1.Opacity = 1.0!
        Me.VPanel1.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel1.Size = New System.Drawing.Size(202, 39)
        Me.VPanel1.TabIndex = 17
        Me.VPanel1.Text = "VPanel1"
        Me.VPanel1.UsePanelBorderColor = True
        Me.VPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'frmSimplesEntrada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1200, 663)
        Me.Controls.Add(Me.VPanel1)
        Me.Controls.Add(Me.VPanel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblCli)
        Me.Controls.Add(Me.tabPrincipal)
        Me.KeyPreview = True
        Me.Name = "frmSimplesEntrada"
        Me.Controls.SetChildIndex(Me.tabPrincipal, 0)
        Me.Controls.SetChildIndex(Me.lblCli, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.VPanel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.VPanel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabPrincipal.ResumeLayout(False)
        Me.vtab1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vtab2.ResumeLayout(False)
        Me.vtab2.PerformLayout()
        CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vtab3.ResumeLayout(False)
        Me.vtab3.PerformLayout()
        Me.pnlNota.ResumeLayout(False)
        Me.pnlNota.PerformLayout()
        CType(Me.dgvVendaNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.VPanel2.Content.ResumeLayout(False)
        Me.VPanel2.ResumeLayout(False)
        Me.VPanel1.Content.ResumeLayout(False)
        Me.VPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
    Friend WithEvents vtab1 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents vtab2 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvAPagar As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents vtab3 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents Label11 As Label
    Friend WithEvents dgvVendaNotas As DataGridView
    Friend WithEvents lblCli As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblIDTransacao As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents lblTransacaoData As Label
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblSituacao As Label
    Friend WithEvents VApplicationMenuItem2 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents VApplicationMenuItem3 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents VApplicationMenuItem4 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents lblTotalCobrado As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnFinalizar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label18 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents clnIDTransacaoItem As DataGridViewTextBoxColumn
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnSubTotal As DataGridViewTextBoxColumn
    Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
    Friend WithEvents clnTotal As DataGridViewTextBoxColumn
    Friend WithEvents clnICMS As DataGridViewTextBoxColumn
    Friend WithEvents clnST As DataGridViewTextBoxColumn
    Friend WithEvents clnMVA As DataGridViewTextBoxColumn
    Friend WithEvents clnIPI As DataGridViewTextBoxColumn
    Friend WithEvents pnlNota As Panel
    Friend WithEvents txtNotaValor As Controles.Text_Monetario
    Friend WithEvents txtEmissaoData As Controles.MaskText_Data
    Friend WithEvents txtNotaNumero As Controles.Text_SoNumeros
    Friend WithEvents txtNotaSerie As Controles.Text_SoNumeros
    Friend WithEvents cmbNotaTipo As Controles.ComboBox_OnlyValues
    Friend WithEvents Label23 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblNota As Label
    Friend WithEvents btnNotaOK As Button
    Friend WithEvents btnNotaCancel As Button
    Friend WithEvents clnChaveAcesso As DataGridViewTextBoxColumn
    Friend WithEvents clnNotaTipo As DataGridViewTextBoxColumn
    Friend WithEvents clnNotaSerie As DataGridViewTextBoxColumn
    Friend WithEvents clnNotaNumero As DataGridViewTextBoxColumn
    Friend WithEvents clnEmissaoData As DataGridViewTextBoxColumn
    Friend WithEvents clnNotaValor As DataGridViewTextBoxColumn
    Friend WithEvents txtChaveAcesso As TextBox
    Friend WithEvents lblTotalProdutos As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnForma As DataGridViewTextBoxColumn
    Friend WithEvents clnIdentificador As DataGridViewTextBoxColumn
    Friend WithEvents clnVencimento As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnProcurar As ToolStripButton
    Friend WithEvents btnAdicionar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnImprimir As ToolStripSplitButton
    Friend WithEvents miImprimirEtiquetas As ToolStripMenuItem
    Friend WithEvents miImprimirRelatorio As ToolStripMenuItem
    Private WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
    Private WithEvents LineShape3 As PowerPacks.LineShape
    Private WithEvents LineShape4 As PowerPacks.LineShape
    Friend WithEvents VPanel2 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblFilialOrigem As Label
    Friend WithEvents Content As VIBlend.WinForms.Controls.vContentPanel
    Friend WithEvents lblTotalGeral As Label
    Friend WithEvents VPanel1 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents btnInserirObservacao As Button
End Class
