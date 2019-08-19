<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoProcurar
    Inherits NovaSiao.frmModNBorder

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnInicioData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnTotalPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnRevisaoData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblDtFinal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.pnlSituacao = New System.Windows.Forms.Panel()
        Me.rbtCancelados = New System.Windows.Forms.RadioButton()
        Me.rbtRecebidos = New System.Windows.Forms.RadioButton()
        Me.rbtCompondo = New System.Windows.Forms.RadioButton()
        Me.rbtEnviado = New System.Windows.Forms.RadioButton()
        Me.mnuOperacoes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miCompondo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRecebido = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCancelado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAlteraData = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnProcFornecedores = New VIBlend.WinForms.Controls.vButton()
        Me.txtFornecedor = New System.Windows.Forms.TextBox()
        Me.cmbMes = New Controles.ComboBox_OnlyValues()
        Me.cmbAno = New Controles.ComboBox_OnlyValues()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mnuOpcoes = New System.Windows.Forms.ToolStrip()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFornecedor = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.btnMensagens = New System.Windows.Forms.ToolStripButton()
        Me.rbtMigrados = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlSituacao.SuspendLayout()
        Me.mnuOperacoes.SuspendLayout()
        Me.mnuOpcoes.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(814, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(530, 9)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(241, 34)
        Me.lblTitulo.Text = "Controle de Pedidos"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnInicioData, Me.clnFornecedor, Me.clnTotalPedido, Me.clnRevisaoData})
        Me.dgvListagem.GridColor = System.Drawing.Color.LightSteelBlue
        Me.dgvListagem.Location = New System.Drawing.Point(12, 175)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray
        Me.dgvListagem.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListagem.Size = New System.Drawing.Size(790, 368)
        Me.dgvListagem.TabIndex = 8
        '
        'clnInicioData
        '
        Me.clnInicioData.Frozen = True
        Me.clnInicioData.HeaderText = "Data Inicial"
        Me.clnInicioData.Name = "clnInicioData"
        Me.clnInicioData.ReadOnly = True
        Me.clnInicioData.Width = 130
        '
        'clnFornecedor
        '
        Me.clnFornecedor.Frozen = True
        Me.clnFornecedor.HeaderText = "Fornecedor"
        Me.clnFornecedor.Name = "clnFornecedor"
        Me.clnFornecedor.ReadOnly = True
        Me.clnFornecedor.Width = 330
        '
        'clnTotalPedido
        '
        Me.clnTotalPedido.Frozen = True
        Me.clnTotalPedido.HeaderText = "Total do Pedido"
        Me.clnTotalPedido.Name = "clnTotalPedido"
        Me.clnTotalPedido.ReadOnly = True
        Me.clnTotalPedido.Width = 130
        '
        'clnRevisaoData
        '
        Me.clnRevisaoData.Frozen = True
        Me.clnRevisaoData.HeaderText = "Rever Em"
        Me.clnRevisaoData.Name = "clnRevisaoData"
        Me.clnRevisaoData.ReadOnly = True
        Me.clnRevisaoData.Width = 130
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitulo.Controls.Add(Me.lblDtFinal)
        Me.pnlTitulo.Controls.Add(Me.Label7)
        Me.pnlTitulo.Controls.Add(Me.Label5)
        Me.pnlTitulo.Controls.Add(Me.Label8)
        Me.pnlTitulo.Location = New System.Drawing.Point(12, 146)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(790, 28)
        Me.pnlTitulo.TabIndex = 7
        '
        'lblDtFinal
        '
        Me.lblDtFinal.BackColor = System.Drawing.Color.Transparent
        Me.lblDtFinal.Location = New System.Drawing.Point(623, 4)
        Me.lblDtFinal.Name = "lblDtFinal"
        Me.lblDtFinal.Size = New System.Drawing.Size(125, 19)
        Me.lblDtFinal.TabIndex = 7
        Me.lblDtFinal.Text = "Dt. da Revisão"
        Me.lblDtFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(160, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Fornecedor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(525, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Total do Ped."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(33, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 19)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Data Inicial"
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(778, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 47
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'pnlSituacao
        '
        Me.pnlSituacao.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlSituacao.Controls.Add(Me.rbtMigrados)
        Me.pnlSituacao.Controls.Add(Me.rbtCancelados)
        Me.pnlSituacao.Controls.Add(Me.rbtRecebidos)
        Me.pnlSituacao.Controls.Add(Me.rbtCompondo)
        Me.pnlSituacao.Controls.Add(Me.rbtEnviado)
        Me.pnlSituacao.Location = New System.Drawing.Point(12, 549)
        Me.pnlSituacao.Name = "pnlSituacao"
        Me.pnlSituacao.Size = New System.Drawing.Size(790, 42)
        Me.pnlSituacao.TabIndex = 9
        '
        'rbtCancelados
        '
        Me.rbtCancelados.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtCancelados.Location = New System.Drawing.Point(478, 5)
        Me.rbtCancelados.Name = "rbtCancelados"
        Me.rbtCancelados.Size = New System.Drawing.Size(131, 33)
        Me.rbtCancelados.TabIndex = 4
        Me.rbtCancelados.TabStop = True
        Me.rbtCancelados.Text = "Cancelados"
        Me.rbtCancelados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtCancelados.UseVisualStyleBackColor = True
        '
        'rbtRecebidos
        '
        Me.rbtRecebidos.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtRecebidos.Location = New System.Drawing.Point(328, 5)
        Me.rbtRecebidos.Name = "rbtRecebidos"
        Me.rbtRecebidos.Size = New System.Drawing.Size(131, 33)
        Me.rbtRecebidos.TabIndex = 3
        Me.rbtRecebidos.TabStop = True
        Me.rbtRecebidos.Text = "Recebidos"
        Me.rbtRecebidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtRecebidos.UseVisualStyleBackColor = True
        '
        'rbtCompondo
        '
        Me.rbtCompondo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtCompondo.Location = New System.Drawing.Point(28, 5)
        Me.rbtCompondo.Name = "rbtCompondo"
        Me.rbtCompondo.Size = New System.Drawing.Size(131, 33)
        Me.rbtCompondo.TabIndex = 1
        Me.rbtCompondo.TabStop = True
        Me.rbtCompondo.Text = "Compondo"
        Me.rbtCompondo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtCompondo.UseVisualStyleBackColor = True
        '
        'rbtEnviado
        '
        Me.rbtEnviado.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtEnviado.Location = New System.Drawing.Point(178, 5)
        Me.rbtEnviado.Name = "rbtEnviado"
        Me.rbtEnviado.Size = New System.Drawing.Size(131, 33)
        Me.rbtEnviado.TabIndex = 2
        Me.rbtEnviado.TabStop = True
        Me.rbtEnviado.Text = "Enviados"
        Me.rbtEnviado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtEnviado.UseVisualStyleBackColor = True
        '
        'mnuOperacoes
        '
        Me.mnuOperacoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miCompondo, Me.miEnviado, Me.miRecebido, Me.miCancelado, Me.miAlteraData})
        Me.mnuOperacoes.Name = "mnuOperacoes"
        Me.mnuOperacoes.Size = New System.Drawing.Size(192, 114)
        '
        'miCompondo
        '
        Me.miCompondo.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.miCompondo.Name = "miCompondo"
        Me.miCompondo.Size = New System.Drawing.Size(191, 22)
        Me.miCompondo.Text = "Em Composição"
        '
        'miEnviado
        '
        Me.miEnviado.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.miEnviado.Name = "miEnviado"
        Me.miEnviado.Size = New System.Drawing.Size(191, 22)
        Me.miEnviado.Text = "Pedido Enviado"
        '
        'miRecebido
        '
        Me.miRecebido.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.miRecebido.Name = "miRecebido"
        Me.miRecebido.Size = New System.Drawing.Size(191, 22)
        Me.miRecebido.Text = "Pedido Recebido"
        '
        'miCancelado
        '
        Me.miCancelado.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.miCancelado.Name = "miCancelado"
        Me.miCancelado.Size = New System.Drawing.Size(191, 22)
        Me.miCancelado.Text = "Pedido Cancelado"
        '
        'miAlteraData
        '
        Me.miAlteraData.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.miAlteraData.Name = "miAlteraData"
        Me.miAlteraData.Size = New System.Drawing.Size(191, 22)
        Me.miAlteraData.Text = "Altera Data de Revisão"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Fornecedor"
        '
        'btnProcFornecedores
        '
        Me.btnProcFornecedores.AllowAnimations = True
        Me.btnProcFornecedores.BackColor = System.Drawing.Color.Transparent
        Me.btnProcFornecedores.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcFornecedores.Location = New System.Drawing.Point(446, 63)
        Me.btnProcFornecedores.Name = "btnProcFornecedores"
        Me.btnProcFornecedores.RoundedCornersMask = CType(15, Byte)
        Me.btnProcFornecedores.RoundedCornersRadius = 0
        Me.btnProcFornecedores.Size = New System.Drawing.Size(34, 27)
        Me.btnProcFornecedores.TabIndex = 16
        Me.btnProcFornecedores.TabStop = False
        Me.btnProcFornecedores.Text = "..."
        Me.btnProcFornecedores.UseCompatibleTextRendering = True
        Me.btnProcFornecedores.UseVisualStyleBackColor = False
        Me.btnProcFornecedores.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtFornecedor
        '
        Me.txtFornecedor.BackColor = System.Drawing.Color.White
        Me.txtFornecedor.Location = New System.Drawing.Point(113, 63)
        Me.txtFornecedor.MaxLength = 50
        Me.txtFornecedor.Name = "txtFornecedor"
        Me.txtFornecedor.Size = New System.Drawing.Size(327, 27)
        Me.txtFornecedor.TabIndex = 15
        '
        'cmbMes
        '
        Me.cmbMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(113, 96)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.RestrictContentToListItems = True
        Me.cmbMes.Size = New System.Drawing.Size(166, 27)
        Me.cmbMes.TabIndex = 17
        '
        'cmbAno
        '
        Me.cmbAno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAno.FormattingEnabled = True
        Me.cmbAno.Location = New System.Drawing.Point(345, 96)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.RestrictContentToListItems = True
        Me.cmbAno.Size = New System.Drawing.Size(95, 27)
        Me.cmbAno.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(70, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 19)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Mês"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(305, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 19)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Ano"
        '
        'mnuOpcoes
        '
        Me.mnuOpcoes.AutoSize = False
        Me.mnuOpcoes.BackColor = System.Drawing.Color.Transparent
        Me.mnuOpcoes.Dock = System.Windows.Forms.DockStyle.None
        Me.mnuOpcoes.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOpcoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEditar, Me.ToolStripSeparator1, Me.btnNovo, Me.btnExcluir, Me.ToolStripSeparator3, Me.btnFornecedor, Me.btnFechar, Me.btnMensagens})
        Me.mnuOpcoes.Location = New System.Drawing.Point(12, 600)
        Me.mnuOpcoes.Name = "mnuOpcoes"
        Me.mnuOpcoes.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mnuOpcoes.Size = New System.Drawing.Size(790, 40)
        Me.mnuOpcoes.TabIndex = 19
        Me.mnuOpcoes.Text = "ToolStrip1"
        '
        'btnEditar
        '
        Me.btnEditar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 37)
        Me.btnEditar.Text = "&Editar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'btnNovo
        '
        Me.btnNovo.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(70, 37)
        Me.btnNovo.Text = "&Novo"
        '
        'btnExcluir
        '
        Me.btnExcluir.ForeColor = System.Drawing.Color.Maroon
        Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete_page_24px
        Me.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(80, 37)
        Me.btnExcluir.Text = "E&xcluir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'btnFornecedor
        '
        Me.btnFornecedor.Enabled = False
        Me.btnFornecedor.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnFornecedor.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnFornecedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFornecedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFornecedor.Name = "btnFornecedor"
        Me.btnFornecedor.Size = New System.Drawing.Size(151, 37)
        Me.btnFornecedor.Text = "Editar &Fornecedor"
        '
        'btnFechar
        '
        Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnFechar.Size = New System.Drawing.Size(100, 37)
        Me.btnFechar.Text = "&Fechar"
        '
        'btnMensagens
        '
        Me.btnMensagens.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnMensagens.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMensagens.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMensagens.Name = "btnMensagens"
        Me.btnMensagens.Size = New System.Drawing.Size(161, 37)
        Me.btnMensagens.Text = "Mensagens Padrão"
        '
        'rbtMigrados
        '
        Me.rbtMigrados.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtMigrados.Location = New System.Drawing.Point(628, 5)
        Me.rbtMigrados.Name = "rbtMigrados"
        Me.rbtMigrados.Size = New System.Drawing.Size(131, 33)
        Me.rbtMigrados.TabIndex = 5
        Me.rbtMigrados.TabStop = True
        Me.rbtMigrados.Text = "Migrados"
        Me.rbtMigrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtMigrados.UseVisualStyleBackColor = True
        '
        'frmPedidoProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(814, 646)
        Me.Controls.Add(Me.mnuOpcoes)
        Me.Controls.Add(Me.cmbAno)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnProcFornecedores)
        Me.Controls.Add(Me.txtFornecedor)
        Me.Controls.Add(Me.pnlSituacao)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.dgvListagem)
        Me.Name = "frmPedidoProcurar"
        Me.Text = "Procurar Saída de Produto"
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.pnlTitulo, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlSituacao, 0)
        Me.Controls.SetChildIndex(Me.txtFornecedor, 0)
        Me.Controls.SetChildIndex(Me.btnProcFornecedores, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmbMes, 0)
        Me.Controls.SetChildIndex(Me.cmbAno, 0)
        Me.Controls.SetChildIndex(Me.mnuOpcoes, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlSituacao.ResumeLayout(False)
        Me.mnuOperacoes.ResumeLayout(False)
        Me.mnuOpcoes.ResumeLayout(False)
        Me.mnuOpcoes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblDtFinal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents txtDespesaTipo As TextBox
    Friend WithEvents pnlSituacao As Panel
    Friend WithEvents rbtCancelados As RadioButton
    Friend WithEvents rbtRecebidos As RadioButton
    Friend WithEvents rbtCompondo As RadioButton
    Friend WithEvents rbtEnviado As RadioButton
    Friend WithEvents mnuOperacoes As ContextMenuStrip
    Friend WithEvents miCompondo As ToolStripMenuItem
    Friend WithEvents miEnviado As ToolStripMenuItem
    Friend WithEvents miRecebido As ToolStripMenuItem
    Friend WithEvents miCancelado As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents btnProcFornecedores As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtFornecedor As TextBox
    Friend WithEvents cmbMes As Controles.ComboBox_OnlyValues
    Friend WithEvents cmbAno As Controles.ComboBox_OnlyValues
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents mnuOpcoes As ToolStrip
    Friend WithEvents btnEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnFornecedor As ToolStripButton
    Friend WithEvents btnFechar As ToolStripButton
    Friend WithEvents miAlteraData As ToolStripMenuItem
    Friend WithEvents btnMensagens As ToolStripButton
    Friend WithEvents clnInicioData As DataGridViewTextBoxColumn
    Friend WithEvents clnFornecedor As DataGridViewTextBoxColumn
    Friend WithEvents clnTotalPedido As DataGridViewTextBoxColumn
    Friend WithEvents clnRevisaoData As DataGridViewTextBoxColumn
    Friend WithEvents rbtMigrados As RadioButton
End Class
