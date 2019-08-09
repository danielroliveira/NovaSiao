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
        Me.txtAutor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.txtProdutoTipo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.pnlAtivas = New System.Windows.Forms.Panel()
        Me.rbtInativas = New System.Windows.Forms.RadioButton()
        Me.rbtTodos = New System.Windows.Forms.RadioButton()
        Me.rbtAtivas = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProduto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstListagem = New ComponentOwl.BetterListView.BetterListView()
        Me.clnRGProduto = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnProduto = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnAutor = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnPreco = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnEstoque = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnEstoqueMinimo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnEstoqueIdeal = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnAtivo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnTipo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnSubTipo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnCategoria = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnFabricante = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.txtProdutoCategoria = New System.Windows.Forms.TextBox()
        Me.txtProdutoSubTipo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPrintListagem = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFabricante = New System.Windows.Forms.TextBox()
        Me.cmbMovimento = New Controles.ComboBox_OnlyValues()
        Me.pnlMovimento = New System.Windows.Forms.Panel()
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
        Me.Panel1.SuspendLayout()
        Me.pnlAtivas.SuspendLayout()
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMovimento.SuspendLayout()
        Me.mnuAlteracao.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(2606, 9)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(330, 34)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Produtos -  Procura Avançada"
        '
        'txtAutor
        '
        Me.txtAutor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAutor.Location = New System.Drawing.Point(84, 508)
        Me.txtAutor.Name = "txtAutor"
        Me.txtAutor.Size = New System.Drawing.Size(346, 27)
        Me.txtAutor.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 511)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Autor"
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
        Me.btnEditar.Location = New System.Drawing.Point(165, 5)
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
        Me.btnClose.TabIndex = 3
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'txtProdutoTipo
        '
        Me.txtProdutoTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtProdutoTipo.Location = New System.Drawing.Point(639, 475)
        Me.txtProdutoTipo.Name = "txtProdutoTipo"
        Me.txtProdutoTipo.Size = New System.Drawing.Size(199, 27)
        Me.txtProdutoTipo.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(522, 478)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 19)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Tipo de Produto"
        '
        'btnNovo
        '
        Me.btnNovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNovo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNovo.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnNovo.Location = New System.Drawing.Point(324, 5)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(153, 41)
        Me.btnNovo.TabIndex = 2
        Me.btnNovo.Text = "&Novo"
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'pnlAtivas
        '
        Me.pnlAtivas.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlAtivas.Controls.Add(Me.rbtInativas)
        Me.pnlAtivas.Controls.Add(Me.rbtTodos)
        Me.pnlAtivas.Controls.Add(Me.rbtAtivas)
        Me.pnlAtivas.Location = New System.Drawing.Point(418, 57)
        Me.pnlAtivas.Name = "pnlAtivas"
        Me.pnlAtivas.Size = New System.Drawing.Size(289, 39)
        Me.pnlAtivas.TabIndex = 17
        '
        'rbtInativas
        '
        Me.rbtInativas.AutoSize = True
        Me.rbtInativas.Location = New System.Drawing.Point(104, 7)
        Me.rbtInativas.Name = "rbtInativas"
        Me.rbtInativas.Size = New System.Drawing.Size(78, 23)
        Me.rbtInativas.TabIndex = 2
        Me.rbtInativas.Tag = "2"
        Me.rbtInativas.Text = "Inativos"
        Me.rbtInativas.UseVisualStyleBackColor = True
        '
        'rbtTodos
        '
        Me.rbtTodos.AutoSize = True
        Me.rbtTodos.Location = New System.Drawing.Point(198, 7)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(65, 23)
        Me.rbtTodos.TabIndex = 3
        Me.rbtTodos.Tag = "3"
        Me.rbtTodos.Text = "Todos"
        Me.rbtTodos.UseVisualStyleBackColor = True
        '
        'rbtAtivas
        '
        Me.rbtAtivas.AutoSize = True
        Me.rbtAtivas.Checked = True
        Me.rbtAtivas.Location = New System.Drawing.Point(17, 7)
        Me.rbtAtivas.Name = "rbtAtivas"
        Me.rbtAtivas.Size = New System.Drawing.Size(67, 23)
        Me.rbtAtivas.TabIndex = 0
        Me.rbtAtivas.TabStop = True
        Me.rbtAtivas.Tag = "1"
        Me.rbtAtivas.Text = "Ativos"
        Me.rbtAtivas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Movimento"
        '
        'txtProduto
        '
        Me.txtProduto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtProduto.Location = New System.Drawing.Point(84, 475)
        Me.txtProduto.Name = "txtProduto"
        Me.txtProduto.Size = New System.Drawing.Size(346, 27)
        Me.txtProduto.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 478)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Produto"
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
        'lstListagem
        '
        Me.lstListagem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstListagem.BackColor = System.Drawing.Color.White
        Me.lstListagem.CheckBoxes = ComponentOwl.BetterListView.BetterListViewCheckBoxes.TwoState
        Me.lstListagem.Columns.Add(Me.clnRGProduto)
        Me.lstListagem.Columns.Add(Me.clnProduto)
        Me.lstListagem.Columns.Add(Me.clnAutor)
        Me.lstListagem.Columns.Add(Me.clnPreco)
        Me.lstListagem.Columns.Add(Me.clnEstoque)
        Me.lstListagem.Columns.Add(Me.clnEstoqueMinimo)
        Me.lstListagem.Columns.Add(Me.clnEstoqueIdeal)
        Me.lstListagem.Columns.Add(Me.clnAtivo)
        Me.lstListagem.Columns.Add(Me.clnTipo)
        Me.lstListagem.Columns.Add(Me.clnSubTipo)
        Me.lstListagem.Columns.Add(Me.clnCategoria)
        Me.lstListagem.Columns.Add(Me.clnFabricante)
        Me.lstListagem.Font = New System.Drawing.Font("Pathway Gothic One", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstListagem.ForeColorColumns = System.Drawing.Color.Black
        Me.lstListagem.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.lstListagem.Location = New System.Drawing.Point(12, 102)
        Me.lstListagem.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.lstListagem.MultiSelect = False
        Me.lstListagem.Name = "lstListagem"
        Me.lstListagem.Size = New System.Drawing.Size(1326, 360)
        Me.lstListagem.SmoothScroll = False
        Me.lstListagem.TabIndex = 19
        '
        'clnRGProduto
        '
        Me.clnRGProduto.AllowResize = False
        Me.clnRGProduto.ForeColor = System.Drawing.Color.Black
        Me.clnRGProduto.Name = "clnRGProduto"
        Me.clnRGProduto.Text = "Reg."
        Me.clnRGProduto.Width = 70
        '
        'clnProduto
        '
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.Text = "Produto"
        Me.clnProduto.Width = 300
        '
        'clnAutor
        '
        Me.clnAutor.Name = "clnAutor"
        Me.clnAutor.Text = "Autor"
        Me.clnAutor.Width = 200
        '
        'clnPreco
        '
        Me.clnPreco.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
        Me.clnPreco.AllowResize = False
        Me.clnPreco.Name = "clnPreco"
        Me.clnPreco.Text = "Preço"
        Me.clnPreco.Width = 80
        '
        'clnEstoque
        '
        Me.clnEstoque.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
        Me.clnEstoque.AllowResize = False
        Me.clnEstoque.DisplayMember = "Estoque"
        Me.clnEstoque.Name = "clnEstoque"
        Me.clnEstoque.Text = "Estoque"
        Me.clnEstoque.Width = 70
        '
        'clnEstoqueMinimo
        '
        Me.clnEstoqueMinimo.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
        Me.clnEstoqueMinimo.AllowResize = False
        Me.clnEstoqueMinimo.DisplayMember = "EstoqueMinimo"
        Me.clnEstoqueMinimo.Name = "clnEstoqueMinimo"
        Me.clnEstoqueMinimo.Text = "E.Min."
        Me.clnEstoqueMinimo.Width = 70
        '
        'clnEstoqueIdeal
        '
        Me.clnEstoqueIdeal.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
        Me.clnEstoqueIdeal.AllowResize = False
        Me.clnEstoqueIdeal.DisplayMember = "EstoqueIdeal"
        Me.clnEstoqueIdeal.Name = "clnEstoqueIdeal"
        Me.clnEstoqueIdeal.Text = "E.Ideal"
        Me.clnEstoqueIdeal.Width = 70
        '
        'clnAtivo
        '
        Me.clnAtivo.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        Me.clnAtivo.Name = "clnAtivo"
        Me.clnAtivo.Text = "Ativo"
        Me.clnAtivo.Width = 70
        '
        'clnTipo
        '
        Me.clnTipo.Name = "clnTipo"
        Me.clnTipo.Text = "Tipo"
        '
        'clnSubTipo
        '
        Me.clnSubTipo.Name = "clnSubTipo"
        Me.clnSubTipo.Text = "Subtipo"
        '
        'clnCategoria
        '
        Me.clnCategoria.Name = "clnCategoria"
        Me.clnCategoria.Text = "Categoria"
        '
        'clnFabricante
        '
        Me.clnFabricante.Name = "clnFabricante"
        Me.clnFabricante.Text = "Fabricante"
        '
        'txtProdutoCategoria
        '
        Me.txtProdutoCategoria.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtProdutoCategoria.Location = New System.Drawing.Point(639, 541)
        Me.txtProdutoCategoria.Name = "txtProdutoCategoria"
        Me.txtProdutoCategoria.Size = New System.Drawing.Size(199, 27)
        Me.txtProdutoCategoria.TabIndex = 10
        '
        'txtProdutoSubTipo
        '
        Me.txtProdutoSubTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtProdutoSubTipo.Location = New System.Drawing.Point(639, 508)
        Me.txtProdutoSubTipo.Name = "txtProdutoSubTipo"
        Me.txtProdutoSubTipo.Size = New System.Drawing.Size(199, 27)
        Me.txtProdutoSubTipo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(476, 511)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Subtipo | Classificação"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(561, 544)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Categoria"
        '
        'btnPrintListagem
        '
        Me.btnPrintListagem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintListagem.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPrintListagem.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnPrintListagem.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.btnPrintListagem.Location = New System.Drawing.Point(6, 5)
        Me.btnPrintListagem.Name = "btnPrintListagem"
        Me.btnPrintListagem.Size = New System.Drawing.Size(153, 41)
        Me.btnPrintListagem.TabIndex = 0
        Me.btnPrintListagem.Text = "Listagem"
        Me.btnPrintListagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintListagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintListagem.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(556, 577)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Fabricante"
        '
        'txtFabricante
        '
        Me.txtFabricante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFabricante.Location = New System.Drawing.Point(639, 574)
        Me.txtFabricante.Name = "txtFabricante"
        Me.txtFabricante.Size = New System.Drawing.Size(199, 27)
        Me.txtFabricante.TabIndex = 12
        '
        'cmbMovimento
        '
        Me.cmbMovimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMovimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMovimento.FormattingEnabled = True
        Me.cmbMovimento.Location = New System.Drawing.Point(100, 6)
        Me.cmbMovimento.Name = "cmbMovimento"
        Me.cmbMovimento.RestrictContentToListItems = True
        Me.cmbMovimento.Size = New System.Drawing.Size(175, 27)
        Me.cmbMovimento.TabIndex = 6
        '
        'pnlMovimento
        '
        Me.pnlMovimento.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlMovimento.Controls.Add(Me.cmbMovimento)
        Me.pnlMovimento.Controls.Add(Me.Label1)
        Me.pnlMovimento.Location = New System.Drawing.Point(721, 57)
        Me.pnlMovimento.Name = "pnlMovimento"
        Me.pnlMovimento.Size = New System.Drawing.Size(289, 39)
        Me.pnlMovimento.TabIndex = 18
        '
        'chkAlterarProdutos
        '
        Me.chkAlterarProdutos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAlterarProdutos.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkAlterarProdutos.Enabled = False
        Me.chkAlterarProdutos.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.chkAlterarProdutos.Location = New System.Drawing.Point(483, 5)
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
        Me.btnLimpar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpar.ForeColor = System.Drawing.Color.Brown
        Me.btnLimpar.Image = Global.NovaSiao.My.Resources.Resources.limpar_24x24
        Me.btnLimpar.Location = New System.Drawing.Point(288, 566)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(142, 41)
        Me.btnLimpar.TabIndex = 14
        Me.btnLimpar.Text = "&Limpar"
        Me.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpar.UseVisualStyleBackColor = True
        '
        'mnuAlteracao
        '
        Me.mnuAlteracao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemAtivar, Me.itemDesativar, Me.ToolStripSeparator1, Me.itemAlterarTipo, Me.itemAlterarCategoria, Me.itemAlterarFabricante, Me.ToolStripSeparator2, Me.itemAlterarEstMinimoIdeal})
        Me.mnuAlteracao.Name = "mnuAlteracao"
        Me.mnuAlteracao.Size = New System.Drawing.Size(234, 148)
        '
        'itemAtivar
        '
        Me.itemAtivar.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.itemAtivar.Name = "itemAtivar"
        Me.itemAtivar.Size = New System.Drawing.Size(233, 22)
        Me.itemAtivar.Text = "ATIVAR Produtos"
        '
        'itemDesativar
        '
        Me.itemDesativar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.itemDesativar.Name = "itemDesativar"
        Me.itemDesativar.Size = New System.Drawing.Size(233, 22)
        Me.itemDesativar.Text = "DESATIVAR Produtos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(230, 6)
        '
        'itemAlterarTipo
        '
        Me.itemAlterarTipo.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.itemAlterarTipo.Name = "itemAlterarTipo"
        Me.itemAlterarTipo.Size = New System.Drawing.Size(233, 22)
        Me.itemAlterarTipo.Text = "Alterar TIPO | SUBTIPO"
        '
        'itemAlterarCategoria
        '
        Me.itemAlterarCategoria.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.itemAlterarCategoria.Name = "itemAlterarCategoria"
        Me.itemAlterarCategoria.Size = New System.Drawing.Size(233, 22)
        Me.itemAlterarCategoria.Text = "Alterar CATEGORIA"
        '
        'itemAlterarFabricante
        '
        Me.itemAlterarFabricante.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.itemAlterarFabricante.Name = "itemAlterarFabricante"
        Me.itemAlterarFabricante.Size = New System.Drawing.Size(233, 22)
        Me.itemAlterarFabricante.Text = "Alterar FABRICANTE"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(230, 6)
        '
        'itemAlterarEstMinimoIdeal
        '
        Me.itemAlterarEstMinimoIdeal.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.itemAlterarEstMinimoIdeal.Name = "itemAlterarEstMinimoIdeal"
        Me.itemAlterarEstMinimoIdeal.Size = New System.Drawing.Size(233, 22)
        Me.itemAlterarEstMinimoIdeal.Text = "Alterar Estoque Mínimo | Ideal"
        '
        'chkSelecionarTudo
        '
        Me.chkSelecionarTudo.AutoSize = True
        Me.chkSelecionarTudo.Location = New System.Drawing.Point(24, 67)
        Me.chkSelecionarTudo.Name = "chkSelecionarTudo"
        Me.chkSelecionarTudo.Size = New System.Drawing.Size(137, 23)
        Me.chkSelecionarTudo.TabIndex = 16
        Me.chkSelecionarTudo.Text = "Selecionar Todos"
        Me.chkSelecionarTudo.UseVisualStyleBackColor = True
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
        Me.Panel2.TabIndex = 15
        '
        'lblTotalProdutos
        '
        Me.lblTotalProdutos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalProdutos.Location = New System.Drawing.Point(1191, 508)
        Me.lblTotalProdutos.Name = "lblTotalProdutos"
        Me.lblTotalProdutos.Size = New System.Drawing.Size(148, 19)
        Me.lblTotalProdutos.TabIndex = 24
        Me.lblTotalProdutos.Text = "00 Produtos"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1191, 483)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 19)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "TOTAL:"
        '
        'lblSelecionados
        '
        Me.lblSelecionados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSelecionados.Location = New System.Drawing.Point(1191, 566)
        Me.lblSelecionados.Name = "lblSelecionados"
        Me.lblSelecionados.Size = New System.Drawing.Size(148, 19)
        Me.lblSelecionados.TabIndex = 24
        Me.lblSelecionados.Text = "00 Produtos"
        '
        'lblSelTitulo
        '
        Me.lblSelTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSelTitulo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelTitulo.Location = New System.Drawing.Point(1191, 541)
        Me.lblSelTitulo.Name = "lblSelTitulo"
        Me.lblSelTitulo.Size = New System.Drawing.Size(121, 19)
        Me.lblSelTitulo.TabIndex = 24
        Me.lblSelTitulo.Text = "SELECIONADOS:"
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPesquisar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPesquisar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnPesquisar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnPesquisar.Location = New System.Drawing.Point(140, 566)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(142, 41)
        Me.btnPesquisar.TabIndex = 13
        Me.btnPesquisar.Text = "&Pesquisar"
        Me.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.AllowAnimations = True
        Me.btnFirst.BackColor = System.Drawing.Color.Transparent
        Me.btnFirst.Image = Global.NovaSiao.My.Resources.Resources.First_32px
        Me.btnFirst.Location = New System.Drawing.Point(3, 3)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.RoundedCornersMask = CType(15, Byte)
        Me.btnFirst.Size = New System.Drawing.Size(32, 32)
        Me.btnFirst.StyleKey = "CircularButton"
        Me.btnFirst.TabIndex = 25
        Me.btnFirst.UseVisualStyleBackColor = False
        Me.btnFirst.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnPrev
        '
        Me.btnPrev.AllowAnimations = True
        Me.btnPrev.BackColor = System.Drawing.Color.Transparent
        Me.btnPrev.Image = Global.NovaSiao.My.Resources.Resources.Previous_32px
        Me.btnPrev.Location = New System.Drawing.Point(41, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.RoundedCornersMask = CType(15, Byte)
        Me.btnPrev.Size = New System.Drawing.Size(32, 32)
        Me.btnPrev.StyleKey = "CircularButton"
        Me.btnPrev.TabIndex = 25
        Me.btnPrev.UseVisualStyleBackColor = False
        Me.btnPrev.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnNext
        '
        Me.btnNext.AllowAnimations = True
        Me.btnNext.BackColor = System.Drawing.Color.Transparent
        Me.btnNext.Image = Global.NovaSiao.My.Resources.Resources.Next_32px
        Me.btnNext.Location = New System.Drawing.Point(194, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.RoundedCornersMask = CType(15, Byte)
        Me.btnNext.Size = New System.Drawing.Size(32, 32)
        Me.btnNext.StyleKey = "CircularButton"
        Me.btnNext.TabIndex = 25
        Me.btnNext.UseVisualStyleBackColor = False
        Me.btnNext.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnLast
        '
        Me.btnLast.AllowAnimations = True
        Me.btnLast.BackColor = System.Drawing.Color.Transparent
        Me.btnLast.Image = Global.NovaSiao.My.Resources.Resources.Last_32px
        Me.btnLast.Location = New System.Drawing.Point(232, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.RoundedCornersMask = CType(15, Byte)
        Me.btnLast.Size = New System.Drawing.Size(32, 32)
        Me.btnLast.StyleKey = "CircularButton"
        Me.btnLast.TabIndex = 25
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
        Me.Panel3.Location = New System.Drawing.Point(879, 563)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(268, 38)
        Me.Panel3.TabIndex = 26
        '
        'lblPaginas
        '
        Me.lblPaginas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPaginas.Location = New System.Drawing.Point(80, 10)
        Me.lblPaginas.Name = "lblPaginas"
        Me.lblPaginas.Size = New System.Drawing.Size(108, 19)
        Me.lblPaginas.TabIndex = 24
        Me.lblPaginas.Text = "Pag. 1 de 1"
        Me.lblPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmProdutoListagem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1350, 680)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lblSelTitulo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblSelecionados)
        Me.Controls.Add(Me.lblTotalProdutos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.chkSelecionarTudo)
        Me.Controls.Add(Me.pnlMovimento)
        Me.Controls.Add(Me.txtFabricante)
        Me.Controls.Add(Me.txtProdutoCategoria)
        Me.Controls.Add(Me.txtProdutoSubTipo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstListagem)
        Me.Controls.Add(Me.txtProduto)
        Me.Controls.Add(Me.pnlAtivas)
        Me.Controls.Add(Me.txtProdutoTipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAutor)
        Me.KeyPreview = True
        Me.Name = "frmProdutoListagem"
        Me.Text = "Procurar Saída de Produto"
        Me.Controls.SetChildIndex(Me.txtAutor, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnLimpar, 0)
        Me.Controls.SetChildIndex(Me.btnPesquisar, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtProdutoTipo, 0)
        Me.Controls.SetChildIndex(Me.pnlAtivas, 0)
        Me.Controls.SetChildIndex(Me.txtProduto, 0)
        Me.Controls.SetChildIndex(Me.lstListagem, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtProdutoSubTipo, 0)
        Me.Controls.SetChildIndex(Me.txtProdutoCategoria, 0)
        Me.Controls.SetChildIndex(Me.txtFabricante, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlMovimento, 0)
        Me.Controls.SetChildIndex(Me.chkSelecionarTudo, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.lblTotalProdutos, 0)
        Me.Controls.SetChildIndex(Me.lblSelecionados, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblSelTitulo, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAtivas.ResumeLayout(False)
        Me.pnlAtivas.PerformLayout()
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMovimento.ResumeLayout(False)
        Me.pnlMovimento.PerformLayout()
        Me.mnuAlteracao.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAutor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents txtProdutoTipo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnNovo As Button
    Friend WithEvents pnlAtivas As Panel
    Friend WithEvents rbtInativas As RadioButton
    Friend WithEvents rbtAtivas As RadioButton
    Friend WithEvents cmbMovimento As Controles.ComboBox_OnlyValues
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProduto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lstListagem As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnRGProduto As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnPreco As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnEstoque As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnEstoqueMinimo As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnEstoqueIdeal As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnProduto As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnAutor As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnAtivo As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents txtProdutoCategoria As TextBox
    Friend WithEvents txtProdutoSubTipo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rbtTodos As RadioButton
    Friend WithEvents btnPrintListagem As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFabricante As TextBox
    Friend WithEvents pnlMovimento As Panel
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
    Friend WithEvents clnTipo As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnSubTipo As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnCategoria As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnFabricante As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents itemAlterarCategoria As ToolStripMenuItem
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents btnFirst As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents btnPrev As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents btnNext As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents btnLast As VIBlend.WinForms.Controls.vCircularButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblPaginas As Label
End Class
