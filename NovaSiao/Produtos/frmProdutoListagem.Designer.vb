<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProdutoListagem
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
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.btnFechar = New System.Windows.Forms.Button()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.btnNovo = New System.Windows.Forms.Button()
		Me.lblFilial = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnPrintListagem = New System.Windows.Forms.Button()
		Me.chkAlterarProdutos = New System.Windows.Forms.CheckBox()
		Me.btnLimpar = New System.Windows.Forms.Button()
		Me.mnuAlteracao = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.itemAtivar = New System.Windows.Forms.ToolStripMenuItem()
		Me.itemDesativar = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.itemAlterarTipo = New System.Windows.Forms.ToolStripMenuItem()
		Me.itemAlterarCategoria = New System.Windows.Forms.ToolStripMenuItem()
		Me.itemAlterarFabricante = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.itemAlterarEstMinimoIdeal = New System.Windows.Forms.ToolStripMenuItem()
		Me.chkSelecionarTudo = New System.Windows.Forms.CheckBox()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.lblTotalProdutos = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.lblSelecionados = New System.Windows.Forms.Label()
		Me.lblSelTitulo = New System.Windows.Forms.Label()
		Me.btnPesquisar = New System.Windows.Forms.Button()
		Me.btnFirst = New VIBlend.WinForms.Controls.vCircularButton()
		Me.btnPrev = New VIBlend.WinForms.Controls.vCircularButton()
		Me.btnNext = New VIBlend.WinForms.Controls.vCircularButton()
		Me.btnLast = New VIBlend.WinForms.Controls.vCircularButton()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.lblPaginas = New System.Windows.Forms.Label()
		Me.dgvItens = New Controles.ctrlDataGridView()
		Me.clnSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnAutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnSubTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnFabricante = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnEstoque = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnEstoqueNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnEstoqueIdeal = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnAtivoImage = New System.Windows.Forms.DataGridViewImageColumn()
		Me.mnuProduto = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.miEditarProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.miTransacoes = New System.Windows.Forms.ToolStripMenuItem()
		Me.miFornecedores = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.miAtivarProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.miDesativarProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.miVerificarEstoqueNormalizado = New System.Windows.Forms.ToolStripMenuItem()
		Me.Panel1.SuspendLayout()
		Me.mnuAlteracao.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.mnuProduto.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.lblFilial)
		Me.Panel1.Controls.Add(Me.Label6)
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Size = New System.Drawing.Size(1350, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label6, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(986, 0)
		Me.lblTitulo.Padding = New System.Windows.Forms.Padding(0, 0, 40, 6)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(364, 50)
		Me.lblTitulo.TabIndex = 2
		Me.lblTitulo.Text = "Produtos -  Procura Avançada"
		'
		'btnFechar
		'
		Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnFechar.ForeColor = System.Drawing.Color.DarkRed
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
		Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnFechar.Location = New System.Drawing.Point(1187, 5)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(153, 41)
		Me.btnFechar.TabIndex = 4
		Me.btnFechar.Text = "&Fechar"
		Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnFechar.UseVisualStyleBackColor = True
		'
		'btnEditar
		'
		Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnEditar.ForeColor = System.Drawing.Color.DarkBlue
		Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.btnEditar.Location = New System.Drawing.Point(168, 5)
		Me.btnEditar.Name = "btnEditar"
		Me.btnEditar.Size = New System.Drawing.Size(153, 41)
		Me.btnEditar.TabIndex = 1
		Me.btnEditar.Text = "&Editar"
		Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnEditar.UseVisualStyleBackColor = True
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
		Me.btnClose.Location = New System.Drawing.Point(1319, 14)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RibbonStyle = False
		Me.btnClose.RoundedCornersMask = CType(15, Byte)
		Me.btnClose.ShowFocusRectangle = False
		Me.btnClose.Size = New System.Drawing.Size(20, 20)
		Me.btnClose.TabIndex = 2
		Me.btnClose.TabStop = False
		Me.btnClose.UseVisualStyleBackColor = False
		Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
		'
		'btnNovo
		'
		Me.btnNovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnNovo.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnNovo.ForeColor = System.Drawing.Color.DarkBlue
		Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.btnNovo.Location = New System.Drawing.Point(327, 5)
		Me.btnNovo.Name = "btnNovo"
		Me.btnNovo.Size = New System.Drawing.Size(153, 41)
		Me.btnNovo.TabIndex = 2
		Me.btnNovo.Text = "&Novo"
		Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnNovo.UseVisualStyleBackColor = True
		'
		'lblFilial
		'
		Me.lblFilial.BackColor = System.Drawing.Color.Transparent
		Me.lblFilial.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblFilial.Location = New System.Drawing.Point(7, 17)
		Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblFilial.Name = "lblFilial"
		Me.lblFilial.Size = New System.Drawing.Size(204, 30)
		Me.lblFilial.TabIndex = 0
		Me.lblFilial.Text = "Filial"
		Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Silver
		Me.Label6.Location = New System.Drawing.Point(90, 4)
		Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(39, 13)
		Me.Label6.TabIndex = 1
		Me.Label6.Text = "Filial"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'btnPrintListagem
		'
		Me.btnPrintListagem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnPrintListagem.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnPrintListagem.ForeColor = System.Drawing.Color.DarkBlue
		Me.btnPrintListagem.Image = Global.NovaSiao.My.Resources.Resources.print
		Me.btnPrintListagem.Location = New System.Drawing.Point(9, 5)
		Me.btnPrintListagem.Name = "btnPrintListagem"
		Me.btnPrintListagem.Size = New System.Drawing.Size(153, 41)
		Me.btnPrintListagem.TabIndex = 0
		Me.btnPrintListagem.Text = "Listagem"
		Me.btnPrintListagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnPrintListagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnPrintListagem.UseVisualStyleBackColor = True
		'
		'chkAlterarProdutos
		'
		Me.chkAlterarProdutos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.chkAlterarProdutos.Appearance = System.Windows.Forms.Appearance.Button
		Me.chkAlterarProdutos.Enabled = False
		Me.chkAlterarProdutos.Image = Global.NovaSiao.My.Resources.Resources.refresh1
		Me.chkAlterarProdutos.Location = New System.Drawing.Point(486, 5)
		Me.chkAlterarProdutos.Name = "chkAlterarProdutos"
		Me.chkAlterarProdutos.Size = New System.Drawing.Size(198, 41)
		Me.chkAlterarProdutos.TabIndex = 3
		Me.chkAlterarProdutos.Text = "Alterar Produtos"
		Me.chkAlterarProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.chkAlterarProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.chkAlterarProdutos.UseVisualStyleBackColor = True
		'
		'btnLimpar
		'
		Me.btnLimpar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnLimpar.BackColor = System.Drawing.Color.AntiqueWhite
		Me.btnLimpar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnLimpar.Enabled = False
		Me.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.Sienna
		Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnLimpar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnLimpar.ForeColor = System.Drawing.Color.Brown
		Me.btnLimpar.Image = Global.NovaSiao.My.Resources.Resources.limpar_24x24
		Me.btnLimpar.Location = New System.Drawing.Point(171, 566)
		Me.btnLimpar.Name = "btnLimpar"
		Me.btnLimpar.Size = New System.Drawing.Size(153, 52)
		Me.btnLimpar.TabIndex = 6
		Me.btnLimpar.Text = "&Limpar"
		Me.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnLimpar.UseVisualStyleBackColor = False
		'
		'mnuAlteracao
		'
		Me.mnuAlteracao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemAtivar, Me.itemDesativar, Me.ToolStripSeparator1, Me.itemAlterarTipo, Me.itemAlterarCategoria, Me.itemAlterarFabricante, Me.ToolStripSeparator2, Me.itemAlterarEstMinimoIdeal})
		Me.mnuAlteracao.Name = "mnuAlteracao"
		Me.mnuAlteracao.Size = New System.Drawing.Size(266, 148)
		'
		'itemAtivar
		'
		Me.itemAtivar.Font = New System.Drawing.Font("Calibri", 11.25!)
		Me.itemAtivar.Image = Global.NovaSiao.My.Resources.Resources.accept
		Me.itemAtivar.Name = "itemAtivar"
		Me.itemAtivar.Size = New System.Drawing.Size(265, 22)
		Me.itemAtivar.Text = "ATIVAR Produtos"
		'
		'itemDesativar
		'
		Me.itemDesativar.Font = New System.Drawing.Font("Calibri", 11.25!)
		Me.itemDesativar.Image = Global.NovaSiao.My.Resources.Resources.block
		Me.itemDesativar.Name = "itemDesativar"
		Me.itemDesativar.Size = New System.Drawing.Size(265, 22)
		Me.itemDesativar.Text = "DESATIVAR Produtos"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(262, 6)
		'
		'itemAlterarTipo
		'
		Me.itemAlterarTipo.Font = New System.Drawing.Font("Calibri", 11.25!)
		Me.itemAlterarTipo.Image = Global.NovaSiao.My.Resources.Resources.refresh
		Me.itemAlterarTipo.Name = "itemAlterarTipo"
		Me.itemAlterarTipo.Size = New System.Drawing.Size(265, 22)
		Me.itemAlterarTipo.Text = "Alterar TIPO | SUBTIPO"
		'
		'itemAlterarCategoria
		'
		Me.itemAlterarCategoria.Font = New System.Drawing.Font("Calibri", 11.25!)
		Me.itemAlterarCategoria.Image = Global.NovaSiao.My.Resources.Resources.refresh
		Me.itemAlterarCategoria.Name = "itemAlterarCategoria"
		Me.itemAlterarCategoria.Size = New System.Drawing.Size(265, 22)
		Me.itemAlterarCategoria.Text = "Alterar CATEGORIA"
		'
		'itemAlterarFabricante
		'
		Me.itemAlterarFabricante.Font = New System.Drawing.Font("Calibri", 11.25!)
		Me.itemAlterarFabricante.Image = Global.NovaSiao.My.Resources.Resources.refresh
		Me.itemAlterarFabricante.Name = "itemAlterarFabricante"
		Me.itemAlterarFabricante.Size = New System.Drawing.Size(265, 22)
		Me.itemAlterarFabricante.Text = "Alterar FABRICANTE"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(262, 6)
		'
		'itemAlterarEstMinimoIdeal
		'
		Me.itemAlterarEstMinimoIdeal.Font = New System.Drawing.Font("Calibri", 11.25!)
		Me.itemAlterarEstMinimoIdeal.Image = Global.NovaSiao.My.Resources.Resources.refresh
		Me.itemAlterarEstMinimoIdeal.Name = "itemAlterarEstMinimoIdeal"
		Me.itemAlterarEstMinimoIdeal.Size = New System.Drawing.Size(265, 22)
		Me.itemAlterarEstMinimoIdeal.Text = "Alterar Estoque Mínimo | Ideal"
		'
		'chkSelecionarTudo
		'
		Me.chkSelecionarTudo.AutoSize = True
		Me.chkSelecionarTudo.Enabled = False
		Me.chkSelecionarTudo.Location = New System.Drawing.Point(21, 53)
		Me.chkSelecionarTudo.Margin = New System.Windows.Forms.Padding(0)
		Me.chkSelecionarTudo.Name = "chkSelecionarTudo"
		Me.chkSelecionarTudo.Size = New System.Drawing.Size(137, 23)
		Me.chkSelecionarTudo.TabIndex = 1
		Me.chkSelecionarTudo.Text = "Selecionar Todos"
		Me.chkSelecionarTudo.UseVisualStyleBackColor = True
		Me.chkSelecionarTudo.Visible = False
		'
		'Panel2
		'
		Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Panel2.BackColor = System.Drawing.Color.Silver
		Me.Panel2.Controls.Add(Me.btnFechar)
		Me.Panel2.Controls.Add(Me.btnNovo)
		Me.Panel2.Controls.Add(Me.btnPrintListagem)
		Me.Panel2.Controls.Add(Me.btnEditar)
		Me.Panel2.Controls.Add(Me.chkAlterarProdutos)
		Me.Panel2.Location = New System.Drawing.Point(3, 626)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1344, 51)
		Me.Panel2.TabIndex = 10
		'
		'lblTotalProdutos
		'
		Me.lblTotalProdutos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblTotalProdutos.Location = New System.Drawing.Point(1132, 604)
		Me.lblTotalProdutos.Name = "lblTotalProdutos"
		Me.lblTotalProdutos.Size = New System.Drawing.Size(206, 19)
		Me.lblTotalProdutos.TabIndex = 9
		Me.lblTotalProdutos.Text = "00 Produtos Encontrados"
		'
		'Label8
		'
		Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.Location = New System.Drawing.Point(1070, 604)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(56, 19)
		Me.Label8.TabIndex = 8
		Me.Label8.Text = "TOTAL:"
		'
		'lblSelecionados
		'
		Me.lblSelecionados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblSelecionados.Location = New System.Drawing.Point(307, 54)
		Me.lblSelecionados.Name = "lblSelecionados"
		Me.lblSelecionados.Size = New System.Drawing.Size(148, 19)
		Me.lblSelecionados.TabIndex = 3
		Me.lblSelecionados.Text = "00 Produtos"
		'
		'lblSelTitulo
		'
		Me.lblSelTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblSelTitulo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSelTitulo.Location = New System.Drawing.Point(192, 54)
		Me.lblSelTitulo.Name = "lblSelTitulo"
		Me.lblSelTitulo.Size = New System.Drawing.Size(121, 19)
		Me.lblSelTitulo.TabIndex = 2
		Me.lblSelTitulo.Text = "SELECIONADOS:"
		'
		'btnPesquisar
		'
		Me.btnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnPesquisar.BackColor = System.Drawing.Color.PowderBlue
		Me.btnPesquisar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
		Me.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnPesquisar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnPesquisar.ForeColor = System.Drawing.Color.DarkSlateGray
		Me.btnPesquisar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.btnPesquisar.Location = New System.Drawing.Point(12, 566)
		Me.btnPesquisar.Name = "btnPesquisar"
		Me.btnPesquisar.Size = New System.Drawing.Size(153, 52)
		Me.btnPesquisar.TabIndex = 5
		Me.btnPesquisar.Text = "&Pesquisar"
		Me.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnPesquisar.UseVisualStyleBackColor = False
		'
		'btnFirst
		'
		Me.btnFirst.AllowAnimations = True
		Me.btnFirst.BackColor = System.Drawing.Color.Transparent
		Me.btnFirst.Image = Global.NovaSiao.My.Resources.Resources.First_32px_disabled
		Me.btnFirst.Location = New System.Drawing.Point(3, 3)
		Me.btnFirst.Name = "btnFirst"
		Me.btnFirst.RoundedCornersMask = CType(15, Byte)
		Me.btnFirst.Size = New System.Drawing.Size(32, 32)
		Me.btnFirst.StyleKey = "CircularButton"
		Me.btnFirst.TabIndex = 0
		Me.btnFirst.TabStop = False
		Me.btnFirst.UseVisualStyleBackColor = False
		Me.btnFirst.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnPrev
		'
		Me.btnPrev.AllowAnimations = True
		Me.btnPrev.BackColor = System.Drawing.Color.Transparent
		Me.btnPrev.Image = Global.NovaSiao.My.Resources.Resources.Previous_32px_disabled
		Me.btnPrev.Location = New System.Drawing.Point(41, 3)
		Me.btnPrev.Name = "btnPrev"
		Me.btnPrev.RoundedCornersMask = CType(15, Byte)
		Me.btnPrev.Size = New System.Drawing.Size(32, 32)
		Me.btnPrev.StyleKey = "CircularButton"
		Me.btnPrev.TabIndex = 1
		Me.btnPrev.TabStop = False
		Me.btnPrev.UseVisualStyleBackColor = False
		Me.btnPrev.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnNext
		'
		Me.btnNext.AllowAnimations = True
		Me.btnNext.BackColor = System.Drawing.Color.Transparent
		Me.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon
		Me.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
		Me.btnNext.Image = Global.NovaSiao.My.Resources.Resources.Next_32px_disabled
		Me.btnNext.Location = New System.Drawing.Point(194, 3)
		Me.btnNext.Name = "btnNext"
		Me.btnNext.RoundedCornersMask = CType(15, Byte)
		Me.btnNext.Size = New System.Drawing.Size(32, 32)
		Me.btnNext.StyleKey = "CircularButton"
		Me.btnNext.TabIndex = 3
		Me.btnNext.TabStop = False
		Me.btnNext.UseVisualStyleBackColor = False
		Me.btnNext.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnLast
		'
		Me.btnLast.AllowAnimations = True
		Me.btnLast.BackColor = System.Drawing.Color.Transparent
		Me.btnLast.Image = Global.NovaSiao.My.Resources.Resources.Last_32px_disabled
		Me.btnLast.Location = New System.Drawing.Point(232, 3)
		Me.btnLast.Name = "btnLast"
		Me.btnLast.RoundedCornersMask = CType(15, Byte)
		Me.btnLast.Size = New System.Drawing.Size(32, 32)
		Me.btnLast.StyleKey = "CircularButton"
		Me.btnLast.TabIndex = 4
		Me.btnLast.TabStop = False
		Me.btnLast.UseVisualStyleBackColor = False
		Me.btnLast.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.btnFirst)
		Me.Panel3.Controls.Add(Me.btnLast)
		Me.Panel3.Controls.Add(Me.btnPrev)
		Me.Panel3.Controls.Add(Me.btnNext)
		Me.Panel3.Controls.Add(Me.lblPaginas)
		Me.Panel3.Location = New System.Drawing.Point(1071, 563)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(268, 38)
		Me.Panel3.TabIndex = 7
		'
		'lblPaginas
		'
		Me.lblPaginas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblPaginas.Location = New System.Drawing.Point(80, 9)
		Me.lblPaginas.Name = "lblPaginas"
		Me.lblPaginas.Size = New System.Drawing.Size(108, 19)
		Me.lblPaginas.TabIndex = 2
		Me.lblPaginas.Text = "Pag. 1 de 1"
		Me.lblPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'dgvItens
		'
		Me.dgvItens.AllowUserToAddRows = False
		Me.dgvItens.AllowUserToDeleteRows = False
		Me.dgvItens.AllowUserToResizeColumns = False
		Me.dgvItens.AllowUserToResizeRows = False
		DataGridViewCellStyle7.BackColor = System.Drawing.Color.Azure
		Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
		Me.dgvItens.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
		Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dgvItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvItens.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
		Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
		Me.dgvItens.ColumnHeadersHeight = 30
		Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnSelect, Me.clnRGProduto, Me.clnProduto, Me.clnAutor, Me.clnTipo, Me.clnSubTipo, Me.clnCategoria, Me.clnFabricante, Me.clnEstoque, Me.clnEstoqueNivel, Me.clnEstoqueIdeal, Me.clnPreco, Me.clnAtivoImage})
		DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.SteelBlue
		DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
		DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle10
		Me.dgvItens.EnableHeadersVisualStyles = False
		Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvItens.Location = New System.Drawing.Point(12, 79)
		Me.dgvItens.MultiSelect = False
		Me.dgvItens.Name = "dgvItens"
		DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
		DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
		Me.dgvItens.RowHeadersVisible = False
		Me.dgvItens.RowHeadersWidth = 35
		DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
		DataGridViewCellStyle12.Font = New System.Drawing.Font("Pathway Gothic One", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
		Me.dgvItens.RowsDefaultCellStyle = DataGridViewCellStyle12
		Me.dgvItens.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Pathway Gothic One", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgvItens.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
		Me.dgvItens.RowTemplate.Height = 33
		Me.dgvItens.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvItens.Size = New System.Drawing.Size(1326, 480)
		Me.dgvItens.TabIndex = 4
		'
		'clnSelect
		'
		Me.clnSelect.HeaderText = "S"
		Me.clnSelect.Name = "clnSelect"
		Me.clnSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.clnSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		Me.clnSelect.Width = 30
		'
		'clnRGProduto
		'
		DataGridViewCellStyle9.Format = "N0"
		DataGridViewCellStyle9.NullValue = Nothing
		Me.clnRGProduto.DefaultCellStyle = DataGridViewCellStyle9
		Me.clnRGProduto.HeaderText = "Reg."
		Me.clnRGProduto.MaxInputLength = 20
		Me.clnRGProduto.Name = "clnRGProduto"
		Me.clnRGProduto.Width = 50
		'
		'clnProduto
		'
		Me.clnProduto.HeaderText = "Produto"
		Me.clnProduto.MaxInputLength = 50
		Me.clnProduto.Name = "clnProduto"
		Me.clnProduto.Width = 310
		'
		'clnAutor
		'
		Me.clnAutor.HeaderText = "Autor/Artista"
		Me.clnAutor.MaxInputLength = 50
		Me.clnAutor.Name = "clnAutor"
		Me.clnAutor.Width = 200
		'
		'clnTipo
		'
		Me.clnTipo.HeaderText = "Tipo"
		Me.clnTipo.Name = "clnTipo"
		Me.clnTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.clnTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.clnTipo.Width = 95
		'
		'clnSubTipo
		'
		Me.clnSubTipo.HeaderText = "Subtipo"
		Me.clnSubTipo.Name = "clnSubTipo"
		Me.clnSubTipo.Width = 95
		'
		'clnCategoria
		'
		Me.clnCategoria.HeaderText = "Categoria"
		Me.clnCategoria.Name = "clnCategoria"
		Me.clnCategoria.Width = 95
		'
		'clnFabricante
		'
		Me.clnFabricante.HeaderText = "Fabricante"
		Me.clnFabricante.Name = "clnFabricante"
		Me.clnFabricante.Width = 124
		'
		'clnEstoque
		'
		Me.clnEstoque.HeaderText = "Est."
		Me.clnEstoque.Name = "clnEstoque"
		Me.clnEstoque.Width = 65
		'
		'clnEstoqueNivel
		'
		Me.clnEstoqueNivel.HeaderText = "Niv."
		Me.clnEstoqueNivel.MaxInputLength = 10
		Me.clnEstoqueNivel.Name = "clnEstoqueNivel"
		Me.clnEstoqueNivel.Width = 65
		'
		'clnEstoqueIdeal
		'
		Me.clnEstoqueIdeal.HeaderText = "Alvo"
		Me.clnEstoqueIdeal.MaxInputLength = 10
		Me.clnEstoqueIdeal.Name = "clnEstoqueIdeal"
		Me.clnEstoqueIdeal.Width = 65
		'
		'clnPreco
		'
		Me.clnPreco.HeaderText = "Preço"
		Me.clnPreco.MaxInputLength = 20
		Me.clnPreco.Name = "clnPreco"
		Me.clnPreco.Width = 80
		'
		'clnAtivoImage
		'
		Me.clnAtivoImage.HeaderText = "Ativo"
		Me.clnAtivoImage.Name = "clnAtivoImage"
		Me.clnAtivoImage.Width = 50
		'
		'mnuProduto
		'
		Me.mnuProduto.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mnuProduto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEditarProduto, Me.ToolStripSeparator3, Me.miTransacoes, Me.miFornecedores, Me.ToolStripSeparator4, Me.miAtivarProduto, Me.miDesativarProduto, Me.ToolStripSeparator5, Me.miVerificarEstoqueNormalizado})
		Me.mnuProduto.Name = "mnuProduto"
		Me.mnuProduto.Size = New System.Drawing.Size(273, 188)
		'
		'miEditarProduto
		'
		Me.miEditarProduto.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.miEditarProduto.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miEditarProduto.Name = "miEditarProduto"
		Me.miEditarProduto.Size = New System.Drawing.Size(272, 24)
		Me.miEditarProduto.Text = "Editar Produto"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(269, 6)
		'
		'miTransacoes
		'
		Me.miTransacoes.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.miTransacoes.Image = Global.NovaSiao.My.Resources.Resources.search_peq
		Me.miTransacoes.Name = "miTransacoes"
		Me.miTransacoes.Size = New System.Drawing.Size(272, 24)
		Me.miTransacoes.Text = "Ver Transações"
		'
		'miFornecedores
		'
		Me.miFornecedores.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.miFornecedores.Image = Global.NovaSiao.My.Resources.Resources.search_peq
		Me.miFornecedores.Name = "miFornecedores"
		Me.miFornecedores.Size = New System.Drawing.Size(272, 24)
		Me.miFornecedores.Text = "Ver Fornecedores"
		'
		'ToolStripSeparator4
		'
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		Me.ToolStripSeparator4.Size = New System.Drawing.Size(269, 6)
		'
		'miAtivarProduto
		'
		Me.miAtivarProduto.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.miAtivarProduto.Image = Global.NovaSiao.My.Resources.Resources.accept
		Me.miAtivarProduto.Name = "miAtivarProduto"
		Me.miAtivarProduto.Size = New System.Drawing.Size(272, 24)
		Me.miAtivarProduto.Text = "Ativar Produto"
		'
		'miDesativarProduto
		'
		Me.miDesativarProduto.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.miDesativarProduto.Image = Global.NovaSiao.My.Resources.Resources.block
		Me.miDesativarProduto.Name = "miDesativarProduto"
		Me.miDesativarProduto.Size = New System.Drawing.Size(272, 24)
		Me.miDesativarProduto.Text = "Desativar Produto"
		'
		'ToolStripSeparator5
		'
		Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
		Me.ToolStripSeparator5.Size = New System.Drawing.Size(269, 6)
		'
		'miVerificarEstoqueNormalizado
		'
		Me.miVerificarEstoqueNormalizado.Name = "miVerificarEstoqueNormalizado"
		Me.miVerificarEstoqueNormalizado.Size = New System.Drawing.Size(272, 24)
		Me.miVerificarEstoqueNormalizado.Text = "Verificar Estoque Normalizado"
		'
		'frmProdutoListagem
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1350, 680)
		Me.Controls.Add(Me.dgvItens)
		Me.Controls.Add(Me.lblSelecionados)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.lblSelTitulo)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.lblTotalProdutos)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.chkSelecionarTudo)
		Me.Controls.Add(Me.btnPesquisar)
		Me.Controls.Add(Me.btnLimpar)
		Me.KeyPreview = True
		Me.Name = "frmProdutoListagem"
		Me.Text = "Procurar Saída de Produto"
		Me.Controls.SetChildIndex(Me.btnLimpar, 0)
		Me.Controls.SetChildIndex(Me.btnPesquisar, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.chkSelecionarTudo, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.lblTotalProdutos, 0)
		Me.Controls.SetChildIndex(Me.Label8, 0)
		Me.Controls.SetChildIndex(Me.lblSelTitulo, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Controls.SetChildIndex(Me.lblSelecionados, 0)
		Me.Controls.SetChildIndex(Me.dgvItens, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.mnuAlteracao.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
		Me.mnuProduto.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents btnFechar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents btnNovo As Button
    Friend WithEvents lblFilial As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnPrintListagem As Button
    Friend WithEvents chkAlterarProdutos As CheckBox
    Friend WithEvents btnLimpar As Button
    Friend WithEvents mnuAlteracao As ContextMenuStrip
    Friend WithEvents itemAlterarTipo As ToolStripMenuItem
    Friend WithEvents itemAlterarFabricante As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents itemAtivar As ToolStripMenuItem
    Friend WithEvents itemDesativar As ToolStripMenuItem
    Friend WithEvents chkSelecionarTudo As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents itemAlterarEstMinimoIdeal As ToolStripMenuItem
    Friend WithEvents lblTotalProdutos As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblSelecionados As Label
    Friend WithEvents lblSelTitulo As Label
    Friend WithEvents itemAlterarCategoria As ToolStripMenuItem
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents btnFirst As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents btnPrev As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents btnNext As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents btnLast As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblPaginas As Label
    Friend WithEvents dgvItens As Controles.ctrlDataGridView
    Friend WithEvents mnuProduto As ContextMenuStrip
    Friend WithEvents miEditarProduto As ToolStripMenuItem
    Friend WithEvents miFornecedores As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents miTransacoes As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents miAtivarProduto As ToolStripMenuItem
    Friend WithEvents miDesativarProduto As ToolStripMenuItem
    Friend WithEvents clnSelect As DataGridViewCheckBoxColumn
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnAutor As DataGridViewTextBoxColumn
    Friend WithEvents clnTipo As DataGridViewTextBoxColumn
    Friend WithEvents clnSubTipo As DataGridViewTextBoxColumn
    Friend WithEvents clnCategoria As DataGridViewTextBoxColumn
    Friend WithEvents clnFabricante As DataGridViewTextBoxColumn
    Friend WithEvents clnEstoque As DataGridViewTextBoxColumn
    Friend WithEvents clnEstoqueNivel As DataGridViewTextBoxColumn
    Friend WithEvents clnEstoqueIdeal As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnAtivoImage As DataGridViewImageColumn
	Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
	Friend WithEvents miVerificarEstoqueNormalizado As ToolStripMenuItem
End Class
