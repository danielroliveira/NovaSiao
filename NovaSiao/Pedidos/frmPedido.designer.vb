<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPedido
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnVerificarEstoque = New System.Windows.Forms.ToolStripSplitButton()
        Me.miPeloEstoquePorFornecedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPeloEstoquePorTipo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPeloEstoquePorFabricante = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnVerificarReservas = New System.Windows.Forms.ToolStripSplitButton()
        Me.miPelaReservaPorFornecedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPelaReservaPorTipo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPelaReservaPorFabricante = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviarPorEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportarExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.miImportarItens = New System.Windows.Forms.ToolStripMenuItem()
        Me.miExportarItens = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtVendedorNome = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTelefoneContato = New Controles.MaskText_Telefone()
        Me.txtEmailVendas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnProcFornecedores = New VIBlend.WinForms.Controls.vButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFornecedor = New System.Windows.Forms.TextBox()
        Me.tabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
        Me.vtab1 = New VIBlend.WinForms.Controls.vTabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblValorTotal = New System.Windows.Forms.Label()
        Me.dgvItens = New Controles.ctrlDataGridView()
        Me.clnIDPedidoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnRGProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnAutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIDProdutoTipo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.clnEstoque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnEstoqueNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnEstoqueIdeal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPreco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDesconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vtab2 = New VIBlend.WinForms.Controls.vTabPage()
        Me.dgvMensagens = New System.Windows.Forms.DataGridView()
        Me.clnMensagem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIDMensagem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnMensagemPadrao = New VIBlend.WinForms.Controls.vButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTransportadora = New System.Windows.Forms.TextBox()
        Me.btnProcTransportadora = New VIBlend.WinForms.Controls.vButton()
        Me.txtTelefoneATransportadora = New Controles.MaskText_Telefone()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblInicioData = New System.Windows.Forms.Label()
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
        Me.lblSituacaoDescricao = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.Panel1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.tabPrincipal.SuspendLayout()
        Me.vtab1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vtab2.SuspendLayout()
        CType(Me.dgvMensagens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.lblSituacaoDescricao)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.lblInicioData)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(1238, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label6, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblInicioData, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label10, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label11, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblSituacaoDescricao, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(3894, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(250, 50)
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Text = "Pedido de Produtos"
        '
        'tsMenu
        '
        Me.tsMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Beige
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnNovo, Me.btnSalvar, Me.ToolStripSeparator5, Me.btnCancelar, Me.btnExcluir, Me.ToolStripSeparator2, Me.btnVerificarEstoque, Me.btnVerificarReservas, Me.btnFechar, Me.ToolStripSeparator1, Me.ToolStripDropDownButton1, Me.btnImportarExportar})
        Me.tsMenu.Location = New System.Drawing.Point(2, 630)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsMenu.Size = New System.Drawing.Size(1234, 48)
        Me.tsMenu.TabIndex = 5
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnProcurar
        '
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.Procurar
        Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProcurar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(97, 45)
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.ToolTipText = "Procurar Cliente"
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Adicionar1
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(76, 45)
        Me.btnNovo.Text = "&Nova"
        Me.btnNovo.ToolTipText = "Novo Funcionário"
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(82, 45)
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.ToolTipText = "Salvar Alterações"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 48)
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.delete_page
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 45)
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar Edição"
        '
        'btnExcluir
        '
        Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.Lixeira
        Me.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(86, 45)
        Me.btnExcluir.Text = "&Excluir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 48)
        '
        'btnVerificarEstoque
        '
        Me.btnVerificarEstoque.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miPeloEstoquePorFornecedor, Me.miPeloEstoquePorTipo, Me.miPeloEstoquePorFabricante})
        Me.btnVerificarEstoque.Image = Global.NovaSiao.My.Resources.Resources.search1
        Me.btnVerificarEstoque.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVerificarEstoque.Name = "btnVerificarEstoque"
        Me.btnVerificarEstoque.Size = New System.Drawing.Size(164, 45)
        Me.btnVerificarEstoque.Text = "Verificar Estoque"
        '
        'miPeloEstoquePorFornecedor
        '
        Me.miPeloEstoquePorFornecedor.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.miPeloEstoquePorFornecedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miPeloEstoquePorFornecedor.Name = "miPeloEstoquePorFornecedor"
        Me.miPeloEstoquePorFornecedor.Size = New System.Drawing.Size(213, 30)
        Me.miPeloEstoquePorFornecedor.Text = "Por Fornecedor"
        '
        'miPeloEstoquePorTipo
        '
        Me.miPeloEstoquePorTipo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.miPeloEstoquePorTipo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miPeloEstoquePorTipo.Name = "miPeloEstoquePorTipo"
        Me.miPeloEstoquePorTipo.Size = New System.Drawing.Size(213, 30)
        Me.miPeloEstoquePorTipo.Text = "Por Tipo de Produto"
        '
        'miPeloEstoquePorFabricante
        '
        Me.miPeloEstoquePorFabricante.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.miPeloEstoquePorFabricante.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miPeloEstoquePorFabricante.Name = "miPeloEstoquePorFabricante"
        Me.miPeloEstoquePorFabricante.Size = New System.Drawing.Size(213, 30)
        Me.miPeloEstoquePorFabricante.Text = "Por Fabricante"
        '
        'btnVerificarReservas
        '
        Me.btnVerificarReservas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miPelaReservaPorFornecedor, Me.miPelaReservaPorTipo, Me.miPelaReservaPorFabricante})
        Me.btnVerificarReservas.Image = Global.NovaSiao.My.Resources.Resources.search1
        Me.btnVerificarReservas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVerificarReservas.Name = "btnVerificarReservas"
        Me.btnVerificarReservas.Size = New System.Drawing.Size(171, 45)
        Me.btnVerificarReservas.Text = "Verificar Reservas"
        '
        'miPelaReservaPorFornecedor
        '
        Me.miPelaReservaPorFornecedor.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.miPelaReservaPorFornecedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miPelaReservaPorFornecedor.Name = "miPelaReservaPorFornecedor"
        Me.miPelaReservaPorFornecedor.Size = New System.Drawing.Size(213, 30)
        Me.miPelaReservaPorFornecedor.Text = "Por Fornecedor"
        '
        'miPelaReservaPorTipo
        '
        Me.miPelaReservaPorTipo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.miPelaReservaPorTipo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miPelaReservaPorTipo.Name = "miPelaReservaPorTipo"
        Me.miPelaReservaPorTipo.Size = New System.Drawing.Size(213, 30)
        Me.miPelaReservaPorTipo.Text = "Por Tipo de Produto"
        '
        'miPelaReservaPorFabricante
        '
        Me.miPelaReservaPorFabricante.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.miPelaReservaPorFabricante.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miPelaReservaPorFabricante.Name = "miPelaReservaPorFabricante"
        Me.miPelaReservaPorFabricante.Size = New System.Drawing.Size(213, 30)
        Me.miPelaReservaPorFabricante.Text = "Por Fabricante"
        '
        'btnFechar
        '
        Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFechar.BackColor = System.Drawing.Color.Transparent
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 2, 2)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnFechar.Size = New System.Drawing.Size(106, 45)
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.ToolTipText = "Fechar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 48)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miEnviarPorEmail})
        Me.ToolStripDropDownButton1.Image = Global.NovaSiao.My.Resources.Resources.Imprimir_PEQ
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(106, 45)
        Me.ToolStripDropDownButton1.Text = "Imprimir"
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.miImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(204, 38)
        Me.miImprimir.Text = "Imprimir"
        '
        'miEnviarPorEmail
        '
        Me.miEnviarPorEmail.Image = Global.NovaSiao.My.Resources.Resources.mail_send_32
        Me.miEnviarPorEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.miEnviarPorEmail.Name = "miEnviarPorEmail"
        Me.miEnviarPorEmail.Size = New System.Drawing.Size(204, 38)
        Me.miEnviarPorEmail.Text = "Enviar por e-mail"
        '
        'btnImportarExportar
        '
        Me.btnImportarExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImportarItens, Me.miExportarItens})
        Me.btnImportarExportar.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnImportarExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImportarExportar.Name = "btnImportarExportar"
        Me.btnImportarExportar.Size = New System.Drawing.Size(167, 45)
        Me.btnImportarExportar.Text = "Importar/Exportar"
        '
        'miImportarItens
        '
        Me.miImportarItens.Name = "miImportarItens"
        Me.miImportarItens.Size = New System.Drawing.Size(169, 24)
        Me.miImportarItens.Text = "Importar Itens"
        '
        'miExportarItens
        '
        Me.miExportarItens.Name = "miExportarItens"
        Me.miExportarItens.Size = New System.Drawing.Size(169, 24)
        Me.miExportarItens.Text = "Exportar Itens"
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblID.Location = New System.Drawing.Point(5, 17)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(94, 30)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "0001"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.lbl_IdTexto.TabIndex = 1
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'EProvider
        '
        Me.EProvider.ContainerControl = Me
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(473, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Filial"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(390, 17)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(204, 30)
        Me.lblFilial.TabIndex = 2
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(20, 51)
        Me.txtObservacao.Margin = New System.Windows.Forms.Padding(6)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(514, 87)
        Me.txtObservacao.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtVendedorNome)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtTelefoneContato)
        Me.Panel2.Controls.Add(Me.txtEmailVendas)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnProcFornecedores)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtFornecedor)
        Me.Panel2.Location = New System.Drawing.Point(12, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(720, 80)
        Me.Panel2.TabIndex = 1
        '
        'txtVendedorNome
        '
        Me.txtVendedorNome.BackColor = System.Drawing.Color.White
        Me.txtVendedorNome.Location = New System.Drawing.Point(567, 9)
        Me.txtVendedorNome.MaxLength = 50
        Me.txtVendedorNome.Name = "txtVendedorNome"
        Me.txtVendedorNome.Size = New System.Drawing.Size(141, 27)
        Me.txtVendedorNome.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(491, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 19)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Vendedor"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(280, 46)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 19)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "e-Mail"
        '
        'txtTelefoneContato
        '
        Me.txtTelefoneContato.Location = New System.Drawing.Point(110, 42)
        Me.txtTelefoneContato.Mask = "(99) 99000-0000"
        Me.txtTelefoneContato.Name = "txtTelefoneContato"
        Me.txtTelefoneContato.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneContato.TabIndex = 6
        '
        'txtEmailVendas
        '
        Me.txtEmailVendas.Location = New System.Drawing.Point(341, 42)
        Me.txtEmailVendas.MaxLength = 100
        Me.txtEmailVendas.Name = "txtEmailVendas"
        Me.txtEmailVendas.Size = New System.Drawing.Size(367, 27)
        Me.txtEmailVendas.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fornecedor"
        '
        'btnProcFornecedores
        '
        Me.btnProcFornecedores.AllowAnimations = True
        Me.btnProcFornecedores.BackColor = System.Drawing.Color.Transparent
        Me.btnProcFornecedores.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcFornecedores.Location = New System.Drawing.Point(443, 9)
        Me.btnProcFornecedores.Name = "btnProcFornecedores"
        Me.btnProcFornecedores.RoundedCornersMask = CType(15, Byte)
        Me.btnProcFornecedores.RoundedCornersRadius = 0
        Me.btnProcFornecedores.Size = New System.Drawing.Size(34, 27)
        Me.btnProcFornecedores.TabIndex = 2
        Me.btnProcFornecedores.TabStop = False
        Me.btnProcFornecedores.Text = "..."
        Me.btnProcFornecedores.UseCompatibleTextRendering = True
        Me.btnProcFornecedores.UseVisualStyleBackColor = False
        Me.btnProcFornecedores.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(34, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Telefone"
        '
        'txtFornecedor
        '
        Me.txtFornecedor.BackColor = System.Drawing.Color.White
        Me.txtFornecedor.Location = New System.Drawing.Point(110, 9)
        Me.txtFornecedor.MaxLength = 50
        Me.txtFornecedor.Name = "txtFornecedor"
        Me.txtFornecedor.Size = New System.Drawing.Size(327, 27)
        Me.txtFornecedor.TabIndex = 1
        '
        'tabPrincipal
        '
        Me.tabPrincipal.AllowAnimations = True
        Me.tabPrincipal.AllPagesHeight = 28
        Me.tabPrincipal.Controls.Add(Me.vtab1)
        Me.tabPrincipal.Controls.Add(Me.vtab2)
        Me.tabPrincipal.CornerRadius = 5
        Me.tabPrincipal.ForeColor = System.Drawing.Color.Black
        Me.tabPrincipal.Location = New System.Drawing.Point(12, 152)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 38, 0, 0)
        Me.tabPrincipal.Size = New System.Drawing.Size(1214, 469)
        Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
        Me.tabPrincipal.TabIndex = 4
        Me.tabPrincipal.TabPages.Add(Me.vtab1)
        Me.tabPrincipal.TabPages.Add(Me.vtab2)
        Me.tabPrincipal.TabsAreaBackColor = System.Drawing.Color.Beige
        Me.tabPrincipal.TabsInitialOffset = 40
        Me.tabPrincipal.TabsShape = VIBlend.WinForms.Controls.TabsShape.Chrome
        Me.tabPrincipal.TabsSpacing = 0
        Me.tabPrincipal.TitleHeight = 38
        Me.tabPrincipal.UseTabsAreaBackColor = True
        Me.tabPrincipal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        '
        'vtab1
        '
        Me.vtab1.Controls.Add(Me.Label13)
        Me.vtab1.Controls.Add(Me.Label12)
        Me.vtab1.Controls.Add(Me.PictureBox3)
        Me.vtab1.Controls.Add(Me.Label3)
        Me.vtab1.Controls.Add(Me.PictureBox2)
        Me.vtab1.Controls.Add(Me.PictureBox1)
        Me.vtab1.Controls.Add(Me.Label4)
        Me.vtab1.Controls.Add(Me.lblValorTotal)
        Me.vtab1.Controls.Add(Me.dgvItens)
        Me.vtab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.ForeColor = System.Drawing.Color.Black
        Me.vtab1.Location = New System.Drawing.Point(0, 38)
        Me.vtab1.Name = "vtab1"
        Me.vtab1.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab1.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.Size = New System.Drawing.Size(1214, 431)
        Me.vtab1.TabIndex = 0
        Me.vtab1.Text = "Produtos"
        Me.vtab1.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab1.TooltipText = "Produtos Pedidos"
        Me.vtab1.UseDefaultTextFont = False
        Me.vtab1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab1.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(333, 395)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 15)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Origem Filial"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(193, 395)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 15)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Origem Reserva"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.MistyRose
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(307, 392)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.TabIndex = 3
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 395)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Origem Pedido"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.LightCyan
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(167, 392)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(30, 392)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(921, 393)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 19)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Total Pedido:"
        '
        'lblValorTotal
        '
        Me.lblValorTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblValorTotal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTotal.Location = New System.Drawing.Point(1020, 387)
        Me.lblValorTotal.Name = "lblValorTotal"
        Me.lblValorTotal.Size = New System.Drawing.Size(145, 28)
        Me.lblValorTotal.TabIndex = 1
        Me.lblValorTotal.Text = "R$ 0,00"
        Me.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToResizeColumns = False
        Me.dgvItens.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvItens.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.None
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
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDPedidoItem, Me.clnRGProduto, Me.clnProduto, Me.clnAutor, Me.clnIDProdutoTipo, Me.clnEstoque, Me.clnEstoqueNivel, Me.clnEstoqueIdeal, Me.clnQuantidade, Me.clnPreco, Me.clnDesconto, Me.clnSubTotal})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItens.EnableHeadersVisualStyles = False
        Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvItens.Location = New System.Drawing.Point(7, 5)
        Me.dgvItens.MultiSelect = False
        Me.dgvItens.Name = "dgvItens"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvItens.RowHeadersWidth = 35
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvItens.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItens.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvItens.RowTemplate.Height = 33
        Me.dgvItens.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItens.Size = New System.Drawing.Size(1200, 372)
        Me.dgvItens.TabIndex = 0
        '
        'clnIDPedidoItem
        '
        Me.clnIDPedidoItem.HeaderText = "IDItem"
        Me.clnIDPedidoItem.Name = "clnIDPedidoItem"
        Me.clnIDPedidoItem.Visible = False
        '
        'clnRGProduto
        '
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.clnRGProduto.DefaultCellStyle = DataGridViewCellStyle3
        Me.clnRGProduto.HeaderText = "Reg."
        Me.clnRGProduto.MaxInputLength = 20
        Me.clnRGProduto.Name = "clnRGProduto"
        Me.clnRGProduto.Width = 60
        '
        'clnProduto
        '
        Me.clnProduto.HeaderText = "Produto"
        Me.clnProduto.MaxInputLength = 50
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.Width = 400
        '
        'clnAutor
        '
        Me.clnAutor.HeaderText = "Autor/Artista"
        Me.clnAutor.MaxInputLength = 50
        Me.clnAutor.Name = "clnAutor"
        Me.clnAutor.Width = 250
        '
        'clnIDProdutoTipo
        '
        Me.clnIDProdutoTipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.clnIDProdutoTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clnIDProdutoTipo.HeaderText = "Tipo de Produto"
        Me.clnIDProdutoTipo.Name = "clnIDProdutoTipo"
        Me.clnIDProdutoTipo.Width = 120
        '
        'clnEstoque
        '
        Me.clnEstoque.HeaderText = "Est."
        Me.clnEstoque.Name = "clnEstoque"
        Me.clnEstoque.Width = 50
        '
        'clnEstoqueNivel
        '
        Me.clnEstoqueNivel.HeaderText = "Niv."
        Me.clnEstoqueNivel.MaxInputLength = 10
        Me.clnEstoqueNivel.Name = "clnEstoqueNivel"
        Me.clnEstoqueNivel.Width = 50
        '
        'clnEstoqueIdeal
        '
        Me.clnEstoqueIdeal.HeaderText = "Alvo"
        Me.clnEstoqueIdeal.MaxInputLength = 10
        Me.clnEstoqueIdeal.Name = "clnEstoqueIdeal"
        Me.clnEstoqueIdeal.Width = 50
        '
        'clnQuantidade
        '
        Me.clnQuantidade.HeaderText = "Qtde"
        Me.clnQuantidade.MaxInputLength = 10
        Me.clnQuantidade.Name = "clnQuantidade"
        Me.clnQuantidade.Width = 70
        '
        'clnPreco
        '
        Me.clnPreco.HeaderText = "Preço"
        Me.clnPreco.MaxInputLength = 20
        Me.clnPreco.Name = "clnPreco"
        Me.clnPreco.Width = 70
        '
        'clnDesconto
        '
        Me.clnDesconto.HeaderText = "Desc(%)"
        Me.clnDesconto.MaxInputLength = 20
        Me.clnDesconto.Name = "clnDesconto"
        Me.clnDesconto.Width = 70
        '
        'clnSubTotal
        '
        Me.clnSubTotal.HeaderText = "SubTotal"
        Me.clnSubTotal.Name = "clnSubTotal"
        Me.clnSubTotal.Width = 80
        '
        'vtab2
        '
        Me.vtab2.Controls.Add(Me.txtObservacao)
        Me.vtab2.Controls.Add(Me.dgvMensagens)
        Me.vtab2.Controls.Add(Me.btnMensagemPadrao)
        Me.vtab2.Controls.Add(Me.Label5)
        Me.vtab2.Controls.Add(Me.Label1)
        Me.vtab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vtab2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Location = New System.Drawing.Point(0, 38)
        Me.vtab2.Name = "vtab2"
        Me.vtab2.Padding = New System.Windows.Forms.Padding(0)
        Me.vtab2.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.Size = New System.Drawing.Size(1214, 431)
        Me.vtab2.TabIndex = 0
        Me.vtab2.Text = "Avisos e Informações"
        Me.vtab2.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtab2.TooltipText = "Observações"
        Me.vtab2.UseDefaultTextFont = False
        Me.vtab2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.vtab2.Visible = False
        '
        'dgvMensagens
        '
        Me.dgvMensagens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.dgvMensagens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMensagens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvMensagens.ColumnHeadersHeight = 30
        Me.dgvMensagens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnMensagem, Me.clnIDMensagem})
        Me.dgvMensagens.EnableHeadersVisualStyles = False
        Me.dgvMensagens.Location = New System.Drawing.Point(20, 200)
        Me.dgvMensagens.Name = "dgvMensagens"
        Me.dgvMensagens.Size = New System.Drawing.Size(514, 196)
        Me.dgvMensagens.TabIndex = 3
        '
        'clnMensagem
        '
        Me.clnMensagem.HeaderText = "Avisos"
        Me.clnMensagem.Name = "clnMensagem"
        Me.clnMensagem.Width = 300
        '
        'clnIDMensagem
        '
        Me.clnIDMensagem.HeaderText = "ID"
        Me.clnIDMensagem.Name = "clnIDMensagem"
        Me.clnIDMensagem.Visible = False
        '
        'btnMensagemPadrao
        '
        Me.btnMensagemPadrao.AllowAnimations = True
        Me.btnMensagemPadrao.BackColor = System.Drawing.Color.Transparent
        Me.btnMensagemPadrao.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnMensagemPadrao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMensagemPadrao.Location = New System.Drawing.Point(320, 164)
        Me.btnMensagemPadrao.Name = "btnMensagemPadrao"
        Me.btnMensagemPadrao.RoundedCornersMask = CType(15, Byte)
        Me.btnMensagemPadrao.Size = New System.Drawing.Size(214, 27)
        Me.btnMensagemPadrao.TabIndex = 2
        Me.btnMensagemPadrao.TabStop = False
        Me.btnMensagemPadrao.Text = "Obter Mensagens Padrão"
        Me.btnMensagemPadrao.UseCompatibleTextRendering = True
        Me.btnMensagemPadrao.UseVisualStyleBackColor = False
        Me.btnMensagemPadrao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(290, 26)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Avisos destinados ao Fornecedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Observação Interna"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtTransportadora)
        Me.Panel3.Controls.Add(Me.btnProcTransportadora)
        Me.Panel3.Controls.Add(Me.txtTelefoneATransportadora)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Location = New System.Drawing.Point(745, 62)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(482, 81)
        Me.Panel3.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 19)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Transportadora"
        '
        'txtTransportadora
        '
        Me.txtTransportadora.Location = New System.Drawing.Point(129, 9)
        Me.txtTransportadora.MaxLength = 50
        Me.txtTransportadora.Name = "txtTransportadora"
        Me.txtTransportadora.Size = New System.Drawing.Size(304, 27)
        Me.txtTransportadora.TabIndex = 1
        '
        'btnProcTransportadora
        '
        Me.btnProcTransportadora.AllowAnimations = True
        Me.btnProcTransportadora.BackColor = System.Drawing.Color.Transparent
        Me.btnProcTransportadora.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcTransportadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcTransportadora.Location = New System.Drawing.Point(439, 9)
        Me.btnProcTransportadora.Name = "btnProcTransportadora"
        Me.btnProcTransportadora.RoundedCornersMask = CType(15, Byte)
        Me.btnProcTransportadora.RoundedCornersRadius = 0
        Me.btnProcTransportadora.Size = New System.Drawing.Size(34, 27)
        Me.btnProcTransportadora.TabIndex = 2
        Me.btnProcTransportadora.TabStop = False
        Me.btnProcTransportadora.Text = "..."
        Me.btnProcTransportadora.UseCompatibleTextRendering = True
        Me.btnProcTransportadora.UseVisualStyleBackColor = False
        Me.btnProcTransportadora.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtTelefoneATransportadora
        '
        Me.txtTelefoneATransportadora.Location = New System.Drawing.Point(129, 42)
        Me.txtTelefoneATransportadora.Mask = "(99) 99000-0000"
        Me.txtTelefoneATransportadora.Name = "txtTelefoneATransportadora"
        Me.txtTelefoneATransportadora.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneATransportadora.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(58, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 19)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Telefone"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Silver
        Me.Label10.Location = New System.Drawing.Point(248, 4)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Data"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInicioData
        '
        Me.lblInicioData.BackColor = System.Drawing.Color.Transparent
        Me.lblInicioData.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicioData.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblInicioData.Location = New System.Drawing.Point(182, 17)
        Me.lblInicioData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInicioData.Name = "lblInicioData"
        Me.lblInicioData.Size = New System.Drawing.Size(169, 30)
        Me.lblInicioData.TabIndex = 5
        Me.lblInicioData.Text = "00/00/0000"
        Me.lblInicioData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDItem"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn2.HeaderText = "Reg."
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Produto"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 430
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Autor/Artista"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Estoque"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Est. Nivel"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Est. Ideal"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Qtde"
        Me.DataGridViewTextBoxColumn8.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 70
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Preço"
        Me.DataGridViewTextBoxColumn9.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Desc."
        Me.DataGridViewTextBoxColumn10.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "SubTotal"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'lblSituacaoDescricao
        '
        Me.lblSituacaoDescricao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacaoDescricao.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacaoDescricao.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblSituacaoDescricao.Location = New System.Drawing.Point(654, 17)
        Me.lblSituacaoDescricao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSituacaoDescricao.Name = "lblSituacaoDescricao"
        Me.lblSituacaoDescricao.Size = New System.Drawing.Size(204, 30)
        Me.lblSituacaoDescricao.TabIndex = 7
        Me.lblSituacaoDescricao.Text = "Situação"
        Me.lblSituacaoDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Silver
        Me.Label11.Location = New System.Drawing.Point(725, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Situação"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(1207, 15)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 9
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'frmPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1238, 680)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.tabPrincipal)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.KeyPreview = True
        Me.Name = "frmPedido"
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.tabPrincipal, 0)
        Me.Controls.SetChildIndex(Me.tsMenu, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tabPrincipal.ResumeLayout(False)
        Me.vtab1.ResumeLayout(False)
        Me.vtab1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vtab2.ResumeLayout(False)
        Me.vtab2.PerformLayout()
        CType(Me.dgvMensagens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents btnProcurar As ToolStripButton
    Friend WithEvents lblID As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents lblFilial As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents txtVendedorNome As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTelefoneContato As Controles.MaskText_Telefone
    Friend WithEvents txtEmailVendas As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnProcFornecedores As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFornecedor As TextBox
    Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
    Friend WithEvents vtab1 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents vtab2 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTransportadora As TextBox
    Friend WithEvents btnProcTransportadora As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtTelefoneATransportadora As Controles.MaskText_Telefone
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblInicioData As Label
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
    Friend WithEvents dgvItens As Controles.ctrlDataGridView
    Friend WithEvents lblSituacaoDescricao As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents clnIDPedidoItem As DataGridViewTextBoxColumn
    Friend WithEvents clnRGProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnAutor As DataGridViewTextBoxColumn
    Friend WithEvents clnIDProdutoTipo As DataGridViewComboBoxColumn
    Friend WithEvents clnEstoque As DataGridViewTextBoxColumn
    Friend WithEvents clnEstoqueNivel As DataGridViewTextBoxColumn
    Friend WithEvents clnEstoqueIdeal As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents clnPreco As DataGridViewTextBoxColumn
    Friend WithEvents clnDesconto As DataGridViewTextBoxColumn
    Friend WithEvents clnSubTotal As DataGridViewTextBoxColumn
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents btnVerificarEstoque As ToolStripSplitButton
    Friend WithEvents miPeloEstoquePorFornecedor As ToolStripMenuItem
    Friend WithEvents miPeloEstoquePorTipo As ToolStripMenuItem
    Friend WithEvents miPeloEstoquePorFabricante As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnVerificarReservas As ToolStripSplitButton
    Friend WithEvents miPelaReservaPorFornecedor As ToolStripMenuItem
    Friend WithEvents miPelaReservaPorTipo As ToolStripMenuItem
    Friend WithEvents miPelaReservaPorFabricante As ToolStripMenuItem
    Friend WithEvents lblValorTotal As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvMensagens As DataGridView
    Friend WithEvents clnMensagem As DataGridViewTextBoxColumn
    Friend WithEvents clnIDMensagem As DataGridViewTextBoxColumn
    Friend WithEvents btnMensagemPadrao As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnFechar As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnImportarExportar As ToolStripDropDownButton
    Friend WithEvents miImportarItens As ToolStripMenuItem
    Friend WithEvents miExportarItens As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents miImprimir As ToolStripMenuItem
    Friend WithEvents miEnviarPorEmail As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
