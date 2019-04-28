<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVendaPrazo
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.vtab2 = New VIBlend.WinForms.Controls.vTabPage()
        Me.lblTroca = New System.Windows.Forms.Label()
        Me.btnTroca = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblValorProdutos = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dgvAReceber = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnReg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPermanencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTotalCobrado = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.txtVolumes = New Controles.Text_SoNumeros()
        Me.txtFreteValor = New Controles.Text_Monetario()
        Me.cmbIDTransportadora = New Controles.ComboBox_OnlyValues()
        Me.cmbFreteTipo = New Controles.ComboBox_OnlyValues()
        Me.txtValorAcrescimos = New Controles.Text_Monetario()
        Me.txtValorImpostos = New Controles.Text_Monetario()
        Me.txtValorFrete = New Controles.Text_Monetario()
        Me.cmbVendaTipo = New Controles.ComboBox_OnlyValues()
        Me.cmbIDPlano = New Controles.ComboBox_OnlyValues()
        Me.cmbIDCobrancaForma = New Controles.ComboBox_OnlyValues()
        Me.vtab3 = New VIBlend.WinForms.Controls.vTabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvVendaNotas = New System.Windows.Forms.DataGridView()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.btnVendedorAlterar = New System.Windows.Forms.Button()
        Me.lblCli = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnData = New VIBlend.WinForms.Controls.vArrowButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.lblVendaData = New System.Windows.Forms.Label()
        Me.lblIDVenda = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.lblTotalGeral = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.VApplicationMenuItem2 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.VApplicationMenuItem3 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.VApplicationMenuItem4 = New VIBlend.WinForms.Controls.vApplicationMenuItem()
        Me.btnFinalizar = New VIBlend.WinForms.Controls.vButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.VPanel1 = New VIBlend.WinForms.Controls.vPanel()
        Me.tspMenuAcao = New System.Windows.Forms.ToolStrip()
        Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.btnAdicionar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcluirVenda = New System.Windows.Forms.ToolStripButton()
        Me.btnDesbloquearVenda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.miImprimirEtiquetas = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuContexto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuItemEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuItemInserir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemExcluir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.tabPrincipal.SuspendLayout()
        Me.vtab1.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vtab2.SuspendLayout()
        CType(Me.dgvAReceber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vtab3.SuspendLayout()
        CType(Me.dgvVendaNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VPanel1.Content.SuspendLayout()
        Me.VPanel1.SuspendLayout()
        Me.tspMenuAcao.SuspendLayout()
        Me.mnuContexto.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.btnData)
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Controls.Add(Me.lblIDVenda)
        Me.Panel1.Controls.Add(Me.lblVendaData)
        Me.Panel1.Size = New System.Drawing.Size(1049, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblVendaData, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblIDVenda, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnData, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label15, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label3, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(686, 4)
        Me.lblTitulo.Size = New System.Drawing.Size(322, 42)
        Me.lblTitulo.Text = "Venda Prazo"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabPrincipal
        '
        Me.tabPrincipal.AllowAnimations = True
        Me.tabPrincipal.AllPagesHeight = 28
        Me.tabPrincipal.Controls.Add(Me.vtab1)
        Me.tabPrincipal.Controls.Add(Me.vtab3)
        Me.tabPrincipal.Controls.Add(Me.vtab2)
        Me.tabPrincipal.ForeColor = System.Drawing.Color.Black
        Me.tabPrincipal.Location = New System.Drawing.Point(9, 106)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 38, 0, 0)
        Me.tabPrincipal.Size = New System.Drawing.Size(1030, 500)
        Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
        Me.tabPrincipal.TabIndex = 9
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
        Me.vtab1.Size = New System.Drawing.Size(1030, 462)
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
        Me.dgvItens.ColumnHeadersHeight = 30
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDTransacaoItem, Me.clnRGProduto, Me.clnProduto, Me.clnQuantidade, Me.clnPreco, Me.clnSubTotal, Me.clnDesconto, Me.clnTotal})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItens.EnableHeadersVisualStyles = False
        Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvItens.Location = New System.Drawing.Point(4, 4)
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
        Me.dgvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvItens.Size = New System.Drawing.Size(1022, 454)
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
        'vtab2
        '
        Me.vtab2.Controls.Add(Me.dgvAReceber)
        Me.vtab2.Controls.Add(Me.Label10)
        Me.vtab2.Controls.Add(Me.Label9)
        Me.vtab2.Controls.Add(Me.Label8)
        Me.vtab2.Controls.Add(Me.Label7)
        Me.vtab2.Controls.Add(Me.txtVolumes)
        Me.vtab2.Controls.Add(Me.txtFreteValor)
        Me.vtab2.Controls.Add(Me.cmbIDTransportadora)
        Me.vtab2.Controls.Add(Me.cmbFreteTipo)
        Me.vtab2.Controls.Add(Me.lblTroca)
        Me.vtab2.Controls.Add(Me.txtValorAcrescimos)
        Me.vtab2.Controls.Add(Me.txtValorImpostos)
        Me.vtab2.Controls.Add(Me.txtValorFrete)
        Me.vtab2.Controls.Add(Me.cmbVendaTipo)
        Me.vtab2.Controls.Add(Me.cmbIDCobrancaForma)
        Me.vtab2.Controls.Add(Me.cmbIDPlano)
        Me.vtab2.Controls.Add(Me.btnTroca)
        Me.vtab2.Controls.Add(Me.Label19)
        Me.vtab2.Controls.Add(Me.lblValorProdutos)
        Me.vtab2.Controls.Add(Me.Label23)
        Me.vtab2.Controls.Add(Me.Label22)
        Me.vtab2.Controls.Add(Me.Label21)
        Me.vtab2.Controls.Add(Me.Label20)
        Me.vtab2.Controls.Add(Me.txtObservacao)
        Me.vtab2.Controls.Add(Me.Label12)
        Me.vtab2.Controls.Add(Me.Label16)
        Me.vtab2.Controls.Add(Me.lblTotalCobrado)
        Me.vtab2.Controls.Add(Me.Label17)
        Me.vtab2.Controls.Add(Me.Label14)
        Me.vtab2.Controls.Add(Me.Label2)
        Me.vtab2.Controls.Add(Me.Label5)
        Me.vtab2.Controls.Add(Me.Label6)
        Me.vtab2.Controls.Add(Me.Label4)
        Me.vtab2.Controls.Add(Me.ShapeContainer2)
        Me.vtab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Location = New System.Drawing.Point(0, 38)
        Me.vtab2.Name = "vtab2"
        Me.vtab2.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab2.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Size = New System.Drawing.Size(1030, 462)
        Me.vtab2.TabIndex = 4
        Me.vtab2.Text = "Forma de Cobrança"
        Me.vtab2.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.TooltipText = "TabPage"
        Me.vtab2.UseDefaultTextFont = False
        Me.vtab2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab2.Visible = False
        '
        'lblTroca
        '
        Me.lblTroca.BackColor = System.Drawing.Color.Transparent
        Me.lblTroca.Location = New System.Drawing.Point(295, 82)
        Me.lblTroca.Name = "lblTroca"
        Me.lblTroca.Size = New System.Drawing.Size(140, 60)
        Me.lblTroca.TabIndex = 30
        Me.lblTroca.Text = "Devolução de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "R$ 0,00"
        Me.lblTroca.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTroca.Visible = False
        '
        'btnTroca
        '
        Me.btnTroca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTroca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnTroca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTroca.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTroca.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnTroca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTroca.Location = New System.Drawing.Point(295, 47)
        Me.btnTroca.Name = "btnTroca"
        Me.btnTroca.Size = New System.Drawing.Size(140, 28)
        Me.btnTroca.TabIndex = 29
        Me.btnTroca.TabStop = False
        Me.btnTroca.Text = "Insere &Troca"
        Me.btnTroca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTroca.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(20, 193)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 26)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "Frete:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(305, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 19)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Volumes"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(72, 294)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 19)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Valor do Frete"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(65, 261)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 19)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Transportadora"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(77, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 19)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Tipo de Frete"
        '
        'lblValorProdutos
        '
        Me.lblValorProdutos.BackColor = System.Drawing.Color.Transparent
        Me.lblValorProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblValorProdutos.Location = New System.Drawing.Point(177, 48)
        Me.lblValorProdutos.Name = "lblValorProdutos"
        Me.lblValorProdutos.Size = New System.Drawing.Size(112, 27)
        Me.lblValorProdutos.TabIndex = 0
        Me.lblValorProdutos.Text = "R$ 0,00"
        Me.lblValorProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(41, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(130, 19)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "Valor dos Produtos"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(43, 151)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(128, 19)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "Valores Adicionais"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(38, 118)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(133, 19)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Impostos Cobrados"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(71, 85)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 19)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Frete Cobrado"
        '
        'dgvAReceber
        '
        Me.dgvAReceber.AllowUserToAddRows = False
        Me.dgvAReceber.AllowUserToDeleteRows = False
        Me.dgvAReceber.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvAReceber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAReceber.ColumnHeadersHeight = 30
        Me.dgvAReceber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnReg, Me.clnVencimento, Me.clnPermanencia, Me.clnValor})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAReceber.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAReceber.EnableHeadersVisualStyles = False
        Me.dgvAReceber.Location = New System.Drawing.Point(566, 193)
        Me.dgvAReceber.MultiSelect = False
        Me.dgvAReceber.Name = "dgvAReceber"
        Me.dgvAReceber.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAReceber.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvAReceber.RowHeadersWidth = 30
        Me.dgvAReceber.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvAReceber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAReceber.Size = New System.Drawing.Size(447, 210)
        Me.dgvAReceber.TabIndex = 12
        '
        'clnID
        '
        Me.clnID.HeaderText = "IDAReceber"
        Me.clnID.Name = "clnID"
        Me.clnID.ReadOnly = True
        Me.clnID.Visible = False
        '
        'clnReg
        '
        Me.clnReg.HeaderText = "Reg."
        Me.clnReg.Name = "clnReg"
        Me.clnReg.ReadOnly = True
        Me.clnReg.Width = 70
        '
        'clnVencimento
        '
        Me.clnVencimento.HeaderText = "Vencimento"
        Me.clnVencimento.Name = "clnVencimento"
        Me.clnVencimento.ReadOnly = True
        '
        'clnPermanencia
        '
        Me.clnPermanencia.HeaderText = "Perm."
        Me.clnPermanencia.Name = "clnPermanencia"
        Me.clnPermanencia.ReadOnly = True
        Me.clnPermanencia.Width = 90
        '
        'clnValor
        '
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.clnValor.DefaultCellStyle = DataGridViewCellStyle5
        Me.clnValor.HeaderText = "Valor"
        Me.clnValor.Name = "clnValor"
        Me.clnValor.ReadOnly = True
        Me.clnValor.Width = 120
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(44, 378)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(380, 64)
        Me.txtObservacao.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 342)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(234, 26)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Observações Importantes:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(143, 26)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Outros Valores:"
        '
        'lblTotalCobrado
        '
        Me.lblTotalCobrado.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCobrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCobrado.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobrado.Location = New System.Drawing.Point(828, 413)
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
        Me.Label17.Location = New System.Drawing.Point(721, 418)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 19)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Total Cobrado:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(567, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 26)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Cobrança:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(633, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo de Venda"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(632, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 19)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Plano de Pgto."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(565, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(202, 19)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Desbobramento das Parcelas:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(600, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 19)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Forma de Cobrança"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(4, 4)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1022, 454)
        Me.ShapeContainer2.TabIndex = 14
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape4.BorderWidth = 3
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 78
        Me.LineShape4.X2 = 440
        Me.LineShape4.Y1 = 203
        Me.LineShape4.Y2 = 203
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape3.BorderWidth = 3
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 255
        Me.LineShape3.X2 = 440
        Me.LineShape3.Y1 = 354
        Me.LineShape3.Y2 = 354
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape2.BorderWidth = 3
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 160
        Me.LineShape2.X2 = 440
        Me.LineShape2.Y1 = 26
        Me.LineShape2.Y2 = 26
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape1.BorderWidth = 3
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 665
        Me.LineShape1.X2 = 990
        Me.LineShape1.Y1 = 26
        Me.LineShape1.Y2 = 26
        '
        'txtVolumes
        '
        Me.txtVolumes.Inteiro = True
        Me.txtVolumes.Location = New System.Drawing.Point(375, 294)
        Me.txtVolumes.Name = "txtVolumes"
        Me.txtVolumes.Size = New System.Drawing.Size(49, 27)
        Me.txtVolumes.TabIndex = 7
        Me.txtVolumes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreteValor
        '
        Me.txtFreteValor.Location = New System.Drawing.Point(177, 291)
        Me.txtFreteValor.Name = "txtFreteValor"
        Me.txtFreteValor.Size = New System.Drawing.Size(112, 27)
        Me.txtFreteValor.SomentePositivos = True
        Me.txtFreteValor.TabIndex = 6
        Me.txtFreteValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbIDTransportadora
        '
        Me.cmbIDTransportadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDTransportadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDTransportadora.FormattingEnabled = True
        Me.cmbIDTransportadora.Location = New System.Drawing.Point(177, 258)
        Me.cmbIDTransportadora.Name = "cmbIDTransportadora"
        Me.cmbIDTransportadora.RestrictContentToListItems = True
        Me.cmbIDTransportadora.Size = New System.Drawing.Size(247, 27)
        Me.cmbIDTransportadora.TabIndex = 5
        '
        'cmbFreteTipo
        '
        Me.cmbFreteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFreteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFreteTipo.FormattingEnabled = True
        Me.cmbFreteTipo.Location = New System.Drawing.Point(177, 225)
        Me.cmbFreteTipo.Name = "cmbFreteTipo"
        Me.cmbFreteTipo.RestrictContentToListItems = True
        Me.cmbFreteTipo.Size = New System.Drawing.Size(112, 27)
        Me.cmbFreteTipo.TabIndex = 4
        '
        'txtValorAcrescimos
        '
        Me.txtValorAcrescimos.Location = New System.Drawing.Point(177, 148)
        Me.txtValorAcrescimos.Name = "txtValorAcrescimos"
        Me.txtValorAcrescimos.Size = New System.Drawing.Size(112, 27)
        Me.txtValorAcrescimos.SomentePositivos = True
        Me.txtValorAcrescimos.TabIndex = 3
        Me.txtValorAcrescimos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValorImpostos
        '
        Me.txtValorImpostos.Location = New System.Drawing.Point(177, 115)
        Me.txtValorImpostos.Name = "txtValorImpostos"
        Me.txtValorImpostos.Size = New System.Drawing.Size(112, 27)
        Me.txtValorImpostos.SomentePositivos = True
        Me.txtValorImpostos.TabIndex = 2
        Me.txtValorImpostos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValorFrete
        '
        Me.txtValorFrete.Location = New System.Drawing.Point(177, 82)
        Me.txtValorFrete.Name = "txtValorFrete"
        Me.txtValorFrete.Size = New System.Drawing.Size(112, 27)
        Me.txtValorFrete.SomentePositivos = True
        Me.txtValorFrete.TabIndex = 1
        Me.txtValorFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbVendaTipo
        '
        Me.cmbVendaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendaTipo.FormattingEnabled = True
        Me.cmbVendaTipo.Location = New System.Drawing.Point(743, 48)
        Me.cmbVendaTipo.Name = "cmbVendaTipo"
        Me.cmbVendaTipo.RestrictContentToListItems = True
        Me.cmbVendaTipo.Size = New System.Drawing.Size(181, 27)
        Me.cmbVendaTipo.TabIndex = 9
        '
        'cmbIDPlano
        '
        Me.cmbIDPlano.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDPlano.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDPlano.FormattingEnabled = True
        Me.cmbIDPlano.Location = New System.Drawing.Point(743, 115)
        Me.cmbIDPlano.Name = "cmbIDPlano"
        Me.cmbIDPlano.RestrictContentToListItems = True
        Me.cmbIDPlano.Size = New System.Drawing.Size(234, 27)
        Me.cmbIDPlano.TabIndex = 11
        '
        'cmbIDCobrancaForma
        '
        Me.cmbIDCobrancaForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDCobrancaForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDCobrancaForma.FormattingEnabled = True
        Me.cmbIDCobrancaForma.Location = New System.Drawing.Point(743, 82)
        Me.cmbIDCobrancaForma.Name = "cmbIDCobrancaForma"
        Me.cmbIDCobrancaForma.RestrictContentToListItems = True
        Me.cmbIDCobrancaForma.Size = New System.Drawing.Size(181, 27)
        Me.cmbIDCobrancaForma.TabIndex = 10
        '
        'vtab3
        '
        Me.vtab3.Controls.Add(Me.Label11)
        Me.vtab3.Controls.Add(Me.dgvVendaNotas)
        Me.vtab3.Controls.Add(Me.ShapeContainer3)
        Me.vtab3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab3.Location = New System.Drawing.Point(0, 38)
        Me.vtab3.Name = "vtab3"
        Me.vtab3.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab3.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab3.Size = New System.Drawing.Size(1030, 462)
        Me.vtab3.TabIndex = 5
        Me.vtab3.Text = "Notas Fiscais"
        Me.vtab3.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab3.TooltipText = "TabPage"
        Me.vtab3.UseDefaultTextFont = False
        Me.vtab3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab3.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 15.75!)
        Me.Label11.Location = New System.Drawing.Point(20, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(241, 26)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Notas e/ou Cupons Fiscais:"
        '
        'dgvVendaNotas
        '
        Me.dgvVendaNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVendaNotas.Location = New System.Drawing.Point(37, 62)
        Me.dgvVendaNotas.Name = "dgvVendaNotas"
        Me.dgvVendaNotas.Size = New System.Drawing.Size(484, 277)
        Me.dgvVendaNotas.TabIndex = 4
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(4, 4)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape5})
        Me.ShapeContainer3.Size = New System.Drawing.Size(1022, 454)
        Me.ShapeContainer3.TabIndex = 5
        Me.ShapeContainer3.TabStop = False
        '
        'LineShape5
        '
        Me.LineShape5.BorderColor = System.Drawing.Color.SlateGray
        Me.LineShape5.BorderWidth = 3
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 258
        Me.LineShape5.X2 = 538
        Me.LineShape5.Y1 = 26
        Me.LineShape5.Y2 = 26
        '
        'btnVendedorAlterar
        '
        Me.btnVendedorAlterar.BackgroundImage = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnVendedorAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVendedorAlterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnVendedorAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVendedorAlterar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVendedorAlterar.Location = New System.Drawing.Point(301, 64)
        Me.btnVendedorAlterar.Name = "btnVendedorAlterar"
        Me.btnVendedorAlterar.Size = New System.Drawing.Size(23, 23)
        Me.btnVendedorAlterar.TabIndex = 3
        Me.btnVendedorAlterar.TabStop = False
        Me.btnVendedorAlterar.UseVisualStyleBackColor = True
        '
        'lblCli
        '
        Me.lblCli.AutoSize = True
        Me.lblCli.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCli.Location = New System.Drawing.Point(345, 65)
        Me.lblCli.Name = "lblCli"
        Me.lblCli.Size = New System.Drawing.Size(60, 19)
        Me.lblCli.TabIndex = 4
        Me.lblCli.Text = "Cliente:"
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.White
        Me.lblCliente.Location = New System.Drawing.Point(416, 62)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(614, 25)
        Me.lblCliente.TabIndex = 5
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendedor
        '
        Me.lblVendedor.BackColor = System.Drawing.Color.White
        Me.lblVendedor.Location = New System.Drawing.Point(97, 63)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(192, 25)
        Me.lblVendedor.TabIndex = 2
        Me.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vendedor:"
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.RectangleShape1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal
        Me.RectangleShape1.Location = New System.Drawing.Point(93, 60)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(235, 30)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1049, 667)
        Me.ShapeContainer1.TabIndex = 11
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.White
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.RectangleShape2.FillColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.FillGradientColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central
        Me.RectangleShape2.Location = New System.Drawing.Point(412, 59)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(626, 30)
        '
        'btnData
        '
        Me.btnData.AllowAnimations = True
        Me.btnData.ArrowDirection = System.Windows.Forms.ArrowDirection.Left
        Me.btnData.Location = New System.Drawing.Point(269, 24)
        Me.btnData.Maximum = 100
        Me.btnData.Minimum = 0
        Me.btnData.Name = "btnData"
        Me.btnData.Size = New System.Drawing.Size(16, 16)
        Me.btnData.TabIndex = 53
        Me.btnData.TabStop = False
        Me.btnData.Value = 0
        Me.btnData.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Silver
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
        Me.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver
        Me.lbl_IdTexto.Location = New System.Drawing.Point(29, 4)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 51
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblVendaData
        '
        Me.lblVendaData.BackColor = System.Drawing.Color.Transparent
        Me.lblVendaData.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendaData.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblVendaData.Location = New System.Drawing.Point(112, 16)
        Me.lblVendaData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendaData.Name = "lblVendaData"
        Me.lblVendaData.Size = New System.Drawing.Size(155, 30)
        Me.lblVendaData.TabIndex = 48
        Me.lblVendaData.Text = "01/01/2017"
        Me.lblVendaData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIDVenda
        '
        Me.lblIDVenda.BackColor = System.Drawing.Color.Transparent
        Me.lblIDVenda.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDVenda.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblIDVenda.Location = New System.Drawing.Point(5, 16)
        Me.lblIDVenda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIDVenda.Name = "lblIDVenda"
        Me.lblIDVenda.Size = New System.Drawing.Size(85, 30)
        Me.lblIDVenda.TabIndex = 49
        Me.lblIDVenda.Text = "0001"
        Me.lblIDVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(1018, 14)
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
        Me.lblTotalGeral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalGeral.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalGeral.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalGeral.Name = "lblTotalGeral"
        Me.lblTotalGeral.Size = New System.Drawing.Size(200, 37)
        Me.lblTotalGeral.TabIndex = 9
        Me.lblTotalGeral.Text = "R$ 0,00"
        Me.lblTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(747, 627)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 19)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Total:"
        '
        'lblSituacao
        '
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblSituacao.Location = New System.Drawing.Point(512, 16)
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
        Me.Label15.ForeColor = System.Drawing.Color.Silver
        Me.Label15.Location = New System.Drawing.Point(549, 4)
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
        Me.btnFinalizar.Location = New System.Drawing.Point(455, 615)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Opacity = 0!
        Me.btnFinalizar.RoundedCornersMask = CType(15, Byte)
        Me.btnFinalizar.RoundedCornersRadius = 0
        Me.btnFinalizar.Size = New System.Drawing.Size(140, 42)
        Me.btnFinalizar.TabIndex = 10
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
        Me.Label18.ForeColor = System.Drawing.Color.Silver
        Me.Label18.Location = New System.Drawing.Point(377, 4)
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
        Me.lblFilial.Location = New System.Drawing.Point(306, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(193, 30)
        Me.lblFilial.TabIndex = 55
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.VPanel1.Location = New System.Drawing.Point(837, 616)
        Me.VPanel1.Name = "VPanel1"
        Me.VPanel1.Opacity = 1.0!
        Me.VPanel1.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel1.Size = New System.Drawing.Size(202, 39)
        Me.VPanel1.TabIndex = 12
        Me.VPanel1.Text = "VPanel1"
        Me.VPanel1.UsePanelBorderColor = True
        Me.VPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'tspMenuAcao
        '
        Me.tspMenuAcao.AutoSize = False
        Me.tspMenuAcao.BackColor = System.Drawing.Color.Transparent
        Me.tspMenuAcao.Dock = System.Windows.Forms.DockStyle.None
        Me.tspMenuAcao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnAdicionar, Me.ToolStripSeparator2, Me.btnExcluirVenda, Me.btnDesbloquearVenda, Me.ToolStripSeparator1, Me.btnImprimir})
        Me.tspMenuAcao.Location = New System.Drawing.Point(9, 613)
        Me.tspMenuAcao.Name = "tspMenuAcao"
        Me.tspMenuAcao.Size = New System.Drawing.Size(443, 47)
        Me.tspMenuAcao.TabIndex = 16
        Me.tspMenuAcao.Text = "ToolStrip1"
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
        Me.btnProcurar.Text = "Procurar Venda"
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
        Me.btnAdicionar.Text = "Adicionar Nova Venda"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 47)
        '
        'btnExcluirVenda
        '
        Me.btnExcluirVenda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExcluirVenda.Image = Global.NovaSiao.My.Resources.Resources.Lixeira_PEQ
        Me.btnExcluirVenda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExcluirVenda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcluirVenda.Name = "btnExcluirVenda"
        Me.btnExcluirVenda.Size = New System.Drawing.Size(45, 44)
        Me.btnExcluirVenda.Text = "Excluir Venda"
        Me.btnExcluirVenda.ToolTipText = "Excluir a Venda"
        '
        'btnDesbloquearVenda
        '
        Me.btnDesbloquearVenda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDesbloquearVenda.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnDesbloquearVenda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDesbloquearVenda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDesbloquearVenda.Name = "btnDesbloquearVenda"
        Me.btnDesbloquearVenda.Size = New System.Drawing.Size(36, 44)
        Me.btnDesbloquearVenda.Text = "Desbloquear Venda"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 47)
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirEtiquetas})
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.btnImprimir.Size = New System.Drawing.Size(56, 44)
        Me.btnImprimir.Text = "Imprimir"
        '
        'miImprimirEtiquetas
        '
        Me.miImprimirEtiquetas.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.miImprimirEtiquetas.Name = "miImprimirEtiquetas"
        Me.miImprimirEtiquetas.Size = New System.Drawing.Size(172, 22)
        Me.miImprimirEtiquetas.Text = "Relatório de Venda"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDItem"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Reg."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "Produto"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 430
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "Qtde"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "Preço"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "SubTotal"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Desc."
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "IDAReceber"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Reg."
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 70
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Vencimento"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Perm."
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 90
        '
        'DataGridViewTextBoxColumn13
        '
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn13.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 120
        '
        'mnuContexto
        '
        Me.mnuContexto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemEditar, Me.ToolStripSeparator3, Me.mnuItemInserir, Me.mnuItemExcluir})
        Me.mnuContexto.Name = "mnuContexto"
        Me.mnuContexto.Size = New System.Drawing.Size(136, 76)
        '
        'mnuItemEditar
        '
        Me.mnuItemEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.mnuItemEditar.Name = "mnuItemEditar"
        Me.mnuItemEditar.Size = New System.Drawing.Size(135, 22)
        Me.mnuItemEditar.Text = "Editar Item"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(132, 6)
        '
        'mnuItemInserir
        '
        Me.mnuItemInserir.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.mnuItemInserir.Name = "mnuItemInserir"
        Me.mnuItemInserir.Size = New System.Drawing.Size(135, 22)
        Me.mnuItemInserir.Text = "Inserir Item"
        '
        'mnuItemExcluir
        '
        Me.mnuItemExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.mnuItemExcluir.Name = "mnuItemExcluir"
        Me.mnuItemExcluir.Size = New System.Drawing.Size(135, 22)
        Me.mnuItemExcluir.Text = "Excluir Item"
        '
        'frmVendaPrazo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1049, 667)
        Me.Controls.Add(Me.tspMenuAcao)
        Me.Controls.Add(Me.VPanel1)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnVendedorAlterar)
        Me.Controls.Add(Me.lblCli)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tabPrincipal)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.KeyPreview = True
        Me.Name = "frmVendaPrazo"
        Me.Controls.SetChildIndex(Me.ShapeContainer1, 0)
        Me.Controls.SetChildIndex(Me.tabPrincipal, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblVendedor, 0)
        Me.Controls.SetChildIndex(Me.lblCliente, 0)
        Me.Controls.SetChildIndex(Me.lblCli, 0)
        Me.Controls.SetChildIndex(Me.btnVendedorAlterar, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnFinalizar, 0)
        Me.Controls.SetChildIndex(Me.VPanel1, 0)
        Me.Controls.SetChildIndex(Me.tspMenuAcao, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabPrincipal.ResumeLayout(False)
        Me.vtab1.ResumeLayout(False)
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vtab2.ResumeLayout(False)
        Me.vtab2.PerformLayout()
        CType(Me.dgvAReceber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vtab3.ResumeLayout(False)
        Me.vtab3.PerformLayout()
        CType(Me.dgvVendaNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VPanel1.Content.ResumeLayout(False)
        Me.VPanel1.ResumeLayout(False)
        Me.tspMenuAcao.ResumeLayout(False)
        Me.tspMenuAcao.PerformLayout()
        Me.mnuContexto.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
    Friend WithEvents vtab1 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents vtab2 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvAReceber As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbVendaTipo As Controles.ComboBox_OnlyValues
    Friend WithEvents cmbIDPlano As Controles.ComboBox_OnlyValues
    Friend WithEvents cmbIDCobrancaForma As Controles.ComboBox_OnlyValues
    Friend WithEvents vtab3 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents Label11 As Label
    Friend WithEvents dgvVendaNotas As DataGridView
    Friend WithEvents btnVendedorAlterar As Button
    Friend WithEvents lblCli As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents lblVendedor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RectangleShape1 As PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As PowerPacks.RectangleShape
    Friend WithEvents btnData As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents Label3 As Label
    Friend WithEvents lblIDVenda As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents lblVendaData As Label
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
    Friend WithEvents VApplicationMenuItem2 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents VApplicationMenuItem3 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents VApplicationMenuItem4 As VIBlend.WinForms.Controls.vApplicationMenuItem
    Friend WithEvents Label14 As Label
    Friend WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As PowerPacks.LineShape
    Friend WithEvents lblTotalCobrado As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LineShape2 As PowerPacks.LineShape
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents LineShape3 As PowerPacks.LineShape
    Friend WithEvents btnFinalizar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label18 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents lblValorProdutos As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtValorAcrescimos As Controles.Text_Monetario
    Friend WithEvents Label22 As Label
    Friend WithEvents txtValorImpostos As Controles.Text_Monetario
    Friend WithEvents Label21 As Label
    Friend WithEvents txtValorFrete As Controles.Text_Monetario
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtVolumes As Controles.Text_SoNumeros
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFreteValor As Controles.Text_Monetario
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbIDTransportadora As Controles.ComboBox_OnlyValues
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbFreteTipo As Controles.ComboBox_OnlyValues
    Friend WithEvents LineShape4 As PowerPacks.LineShape
    Friend WithEvents ShapeContainer3 As PowerPacks.ShapeContainer
    Friend WithEvents LineShape5 As PowerPacks.LineShape
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnReg As DataGridViewTextBoxColumn
    Friend WithEvents clnVencimento As DataGridViewTextBoxColumn
    Friend WithEvents clnPermanencia As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents btnTroca As Button
    Friend WithEvents lblTroca As Label
    Friend WithEvents VPanel1 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents tspMenuAcao As ToolStrip
    Friend WithEvents btnProcurar As ToolStripButton
    Friend WithEvents btnAdicionar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnExcluirVenda As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnImprimir As ToolStripSplitButton
    Friend WithEvents miImprimirEtiquetas As ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents btnDesbloquearVenda As ToolStripButton
    Friend WithEvents mnuContexto As ContextMenuStrip
    Friend WithEvents mnuItemEditar As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuItemInserir As ToolStripMenuItem
    Friend WithEvents mnuItemExcluir As ToolStripMenuItem
End Class
