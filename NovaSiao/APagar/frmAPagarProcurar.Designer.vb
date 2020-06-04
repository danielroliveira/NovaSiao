<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPagarProcurar
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
		Me.txtCredorCadastro = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.pnlPorPeriodo = New System.Windows.Forms.Panel()
		Me.lblDtFinal = New System.Windows.Forms.Label()
		Me.lblDtInicial = New System.Windows.Forms.Label()
		Me.btnDtFinal = New VIBlend.WinForms.Controls.vButton()
		Me.btnDtInicial = New VIBlend.WinForms.Controls.vButton()
		Me.rbtTodas = New System.Windows.Forms.RadioButton()
		Me.rbtPorPeriodo = New System.Windows.Forms.RadioButton()
		Me.rbtPorMes = New System.Windows.Forms.RadioButton()
		Me.pnlPorMes = New System.Windows.Forms.Panel()
		Me.btnPeriodoPosterior = New VIBlend.WinForms.Controls.vArrowButton()
		Me.btnMesAtual = New VIBlend.WinForms.Controls.vButton()
		Me.btnPeriodoAnterior = New VIBlend.WinForms.Controls.vArrowButton()
		Me.lblPeriodo = New System.Windows.Forms.Label()
		Me.dgvListagem = New System.Windows.Forms.DataGridView()
		Me.clnVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnCredor = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnOrigem = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnValorPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnSituacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.pnlVenda = New System.Windows.Forms.Panel()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.pnlMes = New System.Windows.Forms.Panel()
		Me.dtMes = New System.Windows.Forms.MonthCalendar()
		Me.btnProcurar = New VIBlend.WinForms.Controls.vButton()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.btnQuitar = New System.Windows.Forms.Button()
		Me.mnuOperacoes = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.QuitarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.NegativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.NormalizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.VerOrigemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.cmbSituacao = New Controles.ComboBox_OnlyValues()
		Me.cmbCobrancaForma = New Controles.ComboBox_OnlyValues()
		Me.btnImprimir = New System.Windows.Forms.Button()
		Me.lblValorTotal = New System.Windows.Forms.Label()
		Me.lblPagoTotal = New System.Windows.Forms.Label()
		Me.lblEmAbertoTotal = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.pnlPorPeriodo.SuspendLayout()
		Me.pnlPorMes.SuspendLayout()
		CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlVenda.SuspendLayout()
		Me.pnlMes.SuspendLayout()
		Me.mnuOperacoes.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Size = New System.Drawing.Size(1063, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
		Me.lblTitulo.Location = New System.Drawing.Point(804, 7)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(219, 34)
		Me.lblTitulo.TabIndex = 0
		Me.lblTitulo.Text = "A Pagar - Procurar"
		'
		'txtCredorCadastro
		'
		Me.txtCredorCadastro.Location = New System.Drawing.Point(156, 101)
		Me.txtCredorCadastro.Name = "txtCredorCadastro"
		Me.txtCredorCadastro.Size = New System.Drawing.Size(362, 27)
		Me.txtCredorCadastro.TabIndex = 4
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(96, 104)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(52, 19)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Credor"
		'
		'Panel2
		'
		Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(231, Byte), Integer))
		Me.Panel2.Controls.Add(Me.pnlPorPeriodo)
		Me.Panel2.Controls.Add(Me.rbtTodas)
		Me.Panel2.Controls.Add(Me.rbtPorPeriodo)
		Me.Panel2.Controls.Add(Me.rbtPorMes)
		Me.Panel2.Controls.Add(Me.pnlPorMes)
		Me.Panel2.Location = New System.Drawing.Point(698, 61)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(351, 100)
		Me.Panel2.TabIndex = 7
		'
		'pnlPorPeriodo
		'
		Me.pnlPorPeriodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(231, Byte), Integer))
		Me.pnlPorPeriodo.Controls.Add(Me.lblDtFinal)
		Me.pnlPorPeriodo.Controls.Add(Me.lblDtInicial)
		Me.pnlPorPeriodo.Controls.Add(Me.btnDtFinal)
		Me.pnlPorPeriodo.Controls.Add(Me.btnDtInicial)
		Me.pnlPorPeriodo.Location = New System.Drawing.Point(10, 51)
		Me.pnlPorPeriodo.Name = "pnlPorPeriodo"
		Me.pnlPorPeriodo.Size = New System.Drawing.Size(330, 38)
		Me.pnlPorPeriodo.TabIndex = 16
		Me.pnlPorPeriodo.Visible = False
		'
		'lblDtFinal
		'
		Me.lblDtFinal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDtFinal.Location = New System.Drawing.Point(256, 7)
		Me.lblDtFinal.Name = "lblDtFinal"
		Me.lblDtFinal.Size = New System.Drawing.Size(60, 25)
		Me.lblDtFinal.TabIndex = 17
		Me.lblDtFinal.Text = "10/10"
		Me.lblDtFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblDtInicial
		'
		Me.lblDtInicial.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDtInicial.Location = New System.Drawing.Point(99, 7)
		Me.lblDtInicial.Name = "lblDtInicial"
		Me.lblDtInicial.Size = New System.Drawing.Size(60, 25)
		Me.lblDtInicial.TabIndex = 17
		Me.lblDtInicial.Text = "10/10"
		Me.lblDtInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnDtFinal
		'
		Me.btnDtFinal.AllowAnimations = True
		Me.btnDtFinal.BackColor = System.Drawing.Color.Transparent
		Me.btnDtFinal.Location = New System.Drawing.Point(165, 7)
		Me.btnDtFinal.Name = "btnDtFinal"
		Me.btnDtFinal.RoundedCornersMask = CType(15, Byte)
		Me.btnDtFinal.RoundedCornersRadius = 0
		Me.btnDtFinal.Size = New System.Drawing.Size(85, 25)
		Me.btnDtFinal.TabIndex = 17
		Me.btnDtFinal.TabStop = False
		Me.btnDtFinal.Text = "Dt. Final"
		Me.btnDtFinal.UseVisualStyleBackColor = False
		Me.btnDtFinal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnDtInicial
		'
		Me.btnDtInicial.AllowAnimations = True
		Me.btnDtInicial.BackColor = System.Drawing.Color.Transparent
		Me.btnDtInicial.Location = New System.Drawing.Point(8, 7)
		Me.btnDtInicial.Name = "btnDtInicial"
		Me.btnDtInicial.RoundedCornersMask = CType(15, Byte)
		Me.btnDtInicial.RoundedCornersRadius = 0
		Me.btnDtInicial.Size = New System.Drawing.Size(85, 25)
		Me.btnDtInicial.TabIndex = 17
		Me.btnDtInicial.TabStop = False
		Me.btnDtInicial.Text = "Dt. Inicial"
		Me.btnDtInicial.UseVisualStyleBackColor = False
		Me.btnDtInicial.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'rbtTodas
		'
		Me.rbtTodas.Appearance = System.Windows.Forms.Appearance.Button
		Me.rbtTodas.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(239, Byte), Integer))
		Me.rbtTodas.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
		Me.rbtTodas.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
		Me.rbtTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.rbtTodas.Location = New System.Drawing.Point(232, 10)
		Me.rbtTodas.Name = "rbtTodas"
		Me.rbtTodas.Size = New System.Drawing.Size(102, 29)
		Me.rbtTodas.TabIndex = 8
		Me.rbtTodas.Text = "Todas"
		Me.rbtTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rbtTodas.UseVisualStyleBackColor = False
		'
		'rbtPorPeriodo
		'
		Me.rbtPorPeriodo.Appearance = System.Windows.Forms.Appearance.Button
		Me.rbtPorPeriodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(239, Byte), Integer))
		Me.rbtPorPeriodo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
		Me.rbtPorPeriodo.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
		Me.rbtPorPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.rbtPorPeriodo.Location = New System.Drawing.Point(124, 10)
		Me.rbtPorPeriodo.Name = "rbtPorPeriodo"
		Me.rbtPorPeriodo.Size = New System.Drawing.Size(102, 29)
		Me.rbtPorPeriodo.TabIndex = 7
		Me.rbtPorPeriodo.Text = "Por Período"
		Me.rbtPorPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rbtPorPeriodo.UseVisualStyleBackColor = False
		'
		'rbtPorMes
		'
		Me.rbtPorMes.Appearance = System.Windows.Forms.Appearance.Button
		Me.rbtPorMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(239, Byte), Integer))
		Me.rbtPorMes.Checked = True
		Me.rbtPorMes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
		Me.rbtPorMes.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
		Me.rbtPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.rbtPorMes.Location = New System.Drawing.Point(16, 10)
		Me.rbtPorMes.Name = "rbtPorMes"
		Me.rbtPorMes.Size = New System.Drawing.Size(102, 29)
		Me.rbtPorMes.TabIndex = 6
		Me.rbtPorMes.TabStop = True
		Me.rbtPorMes.Text = "Por Mês"
		Me.rbtPorMes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.rbtPorMes.UseVisualStyleBackColor = False
		'
		'pnlPorMes
		'
		Me.pnlPorMes.Controls.Add(Me.btnPeriodoPosterior)
		Me.pnlPorMes.Controls.Add(Me.btnMesAtual)
		Me.pnlPorMes.Controls.Add(Me.btnPeriodoAnterior)
		Me.pnlPorMes.Controls.Add(Me.lblPeriodo)
		Me.pnlPorMes.Location = New System.Drawing.Point(10, 51)
		Me.pnlPorMes.Name = "pnlPorMes"
		Me.pnlPorMes.Size = New System.Drawing.Size(330, 38)
		Me.pnlPorMes.TabIndex = 16
		'
		'btnPeriodoPosterior
		'
		Me.btnPeriodoPosterior.AllowAnimations = True
		Me.btnPeriodoPosterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Right
		Me.btnPeriodoPosterior.Location = New System.Drawing.Point(220, 7)
		Me.btnPeriodoPosterior.Maximum = 100
		Me.btnPeriodoPosterior.Minimum = 0
		Me.btnPeriodoPosterior.Name = "btnPeriodoPosterior"
		Me.btnPeriodoPosterior.Size = New System.Drawing.Size(25, 25)
		Me.btnPeriodoPosterior.TabIndex = 4
		Me.btnPeriodoPosterior.TabStop = False
		Me.btnPeriodoPosterior.Text = "VArrowButton1"
		Me.btnPeriodoPosterior.Value = 0
		Me.btnPeriodoPosterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnMesAtual
		'
		Me.btnMesAtual.AllowAnimations = True
		Me.btnMesAtual.BackColor = System.Drawing.Color.Transparent
		Me.btnMesAtual.Location = New System.Drawing.Point(251, 7)
		Me.btnMesAtual.Name = "btnMesAtual"
		Me.btnMesAtual.RoundedCornersMask = CType(15, Byte)
		Me.btnMesAtual.RoundedCornersRadius = 0
		Me.btnMesAtual.Size = New System.Drawing.Size(48, 25)
		Me.btnMesAtual.TabIndex = 5
		Me.btnMesAtual.TabStop = False
		Me.btnMesAtual.Text = "Atual"
		Me.btnMesAtual.UseVisualStyleBackColor = False
		Me.btnMesAtual.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnPeriodoAnterior
		'
		Me.btnPeriodoAnterior.AllowAnimations = True
		Me.btnPeriodoAnterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Left
		Me.btnPeriodoAnterior.Location = New System.Drawing.Point(13, 6)
		Me.btnPeriodoAnterior.Maximum = 100
		Me.btnPeriodoAnterior.Minimum = 0
		Me.btnPeriodoAnterior.Name = "btnPeriodoAnterior"
		Me.btnPeriodoAnterior.Size = New System.Drawing.Size(25, 25)
		Me.btnPeriodoAnterior.TabIndex = 3
		Me.btnPeriodoAnterior.TabStop = False
		Me.btnPeriodoAnterior.Text = "VArrowButton1"
		Me.btnPeriodoAnterior.Value = 0
		Me.btnPeriodoAnterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'lblPeriodo
		'
		Me.lblPeriodo.BackColor = System.Drawing.Color.Transparent
		Me.lblPeriodo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPeriodo.Location = New System.Drawing.Point(9, 4)
		Me.lblPeriodo.Name = "lblPeriodo"
		Me.lblPeriodo.Size = New System.Drawing.Size(238, 30)
		Me.lblPeriodo.TabIndex = 2
		Me.lblPeriodo.Text = "Novembro | 2017"
		Me.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'dgvListagem
		'
		Me.dgvListagem.AllowUserToAddRows = False
		Me.dgvListagem.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
		Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvListagem.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnVencimento, Me.clnCredor, Me.clnOrigem, Me.clnForma, Me.clnValor, Me.clnValorPago, Me.clnSituacao})
		Me.dgvListagem.GridColor = System.Drawing.Color.LightSteelBlue
		Me.dgvListagem.Location = New System.Drawing.Point(12, 201)
		Me.dgvListagem.MultiSelect = False
		Me.dgvListagem.Name = "dgvListagem"
		Me.dgvListagem.ReadOnly = True
		Me.dgvListagem.RowHeadersWidth = 30
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray
		Me.dgvListagem.RowsDefaultCellStyle = DataGridViewCellStyle2
		Me.dgvListagem.Size = New System.Drawing.Size(1037, 368)
		Me.dgvListagem.TabIndex = 10
		'
		'clnVencimento
		'
		Me.clnVencimento.Frozen = True
		Me.clnVencimento.HeaderText = "Vencimento"
		Me.clnVencimento.Name = "clnVencimento"
		Me.clnVencimento.ReadOnly = True
		'
		'clnCredor
		'
		Me.clnCredor.Frozen = True
		Me.clnCredor.HeaderText = "Credor"
		Me.clnCredor.Name = "clnCredor"
		Me.clnCredor.ReadOnly = True
		Me.clnCredor.Width = 280
		'
		'clnOrigem
		'
		Me.clnOrigem.HeaderText = "Origem"
		Me.clnOrigem.Name = "clnOrigem"
		Me.clnOrigem.ReadOnly = True
		Me.clnOrigem.Width = 150
		'
		'clnForma
		'
		Me.clnForma.HeaderText = "Forma"
		Me.clnForma.Name = "clnForma"
		Me.clnForma.ReadOnly = True
		Me.clnForma.Width = 150
		'
		'clnValor
		'
		Me.clnValor.HeaderText = "Valor"
		Me.clnValor.Name = "clnValor"
		Me.clnValor.ReadOnly = True
		'
		'clnValorPago
		'
		Me.clnValorPago.HeaderText = "Pago"
		Me.clnValorPago.Name = "clnValorPago"
		Me.clnValorPago.ReadOnly = True
		'
		'clnSituacao
		'
		Me.clnSituacao.HeaderText = "Situação"
		Me.clnSituacao.Name = "clnSituacao"
		Me.clnSituacao.ReadOnly = True
		Me.clnSituacao.Width = 80
		'
		'btnCancelar
		'
		Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
		Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
		Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCancelar.Location = New System.Drawing.Point(906, 631)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(143, 41)
		Me.btnCancelar.TabIndex = 15
		Me.btnCancelar.Text = "&Fechar"
		Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnCancelar.UseVisualStyleBackColor = True
		'
		'btnEditar
		'
		Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnEditar.ForeColor = System.Drawing.Color.DarkBlue
		Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.btnEditar.Location = New System.Drawing.Point(310, 631)
		Me.btnEditar.Name = "btnEditar"
		Me.btnEditar.Size = New System.Drawing.Size(143, 41)
		Me.btnEditar.TabIndex = 14
		Me.btnEditar.Text = "&Editar Origem"
		Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnEditar.UseVisualStyleBackColor = True
		'
		'pnlVenda
		'
		Me.pnlVenda.BackColor = System.Drawing.Color.LightSteelBlue
		Me.pnlVenda.Controls.Add(Me.Label10)
		Me.pnlVenda.Controls.Add(Me.Label3)
		Me.pnlVenda.Controls.Add(Me.Label9)
		Me.pnlVenda.Controls.Add(Me.Label6)
		Me.pnlVenda.Controls.Add(Me.Label7)
		Me.pnlVenda.Controls.Add(Me.Label5)
		Me.pnlVenda.Controls.Add(Me.Label8)
		Me.pnlVenda.Location = New System.Drawing.Point(12, 172)
		Me.pnlVenda.Name = "pnlVenda"
		Me.pnlVenda.Size = New System.Drawing.Size(1037, 28)
		Me.pnlVenda.TabIndex = 9
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Location = New System.Drawing.Point(914, 4)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(64, 19)
		Me.Label10.TabIndex = 5
		Me.Label10.Text = "Situação"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Location = New System.Drawing.Point(866, 4)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(41, 19)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "Pago"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Location = New System.Drawing.Point(766, 4)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(42, 19)
		Me.Label9.TabIndex = 4
		Me.Label9.Text = "Valor"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Location = New System.Drawing.Point(565, 4)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(134, 19)
		Me.Label6.TabIndex = 3
		Me.Label6.Text = "Forma de Cobrança"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Location = New System.Drawing.Point(132, 4)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(52, 19)
		Me.Label7.TabIndex = 1
		Me.Label7.Text = "Credor"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Location = New System.Drawing.Point(414, 4)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(109, 19)
		Me.Label5.TabIndex = 2
		Me.Label5.Text = "Origem do Pag."
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Location = New System.Drawing.Point(33, 4)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(85, 19)
		Me.Label8.TabIndex = 0
		Me.Label8.Text = "Vencimento"
		'
		'pnlMes
		'
		Me.pnlMes.Controls.Add(Me.dtMes)
		Me.pnlMes.Location = New System.Drawing.Point(722, 300)
		Me.pnlMes.Name = "pnlMes"
		Me.pnlMes.Size = New System.Drawing.Size(234, 166)
		Me.pnlMes.TabIndex = 8
		Me.pnlMes.Visible = False
		'
		'dtMes
		'
		Me.dtMes.Location = New System.Drawing.Point(3, 1)
		Me.dtMes.Name = "dtMes"
		Me.dtMes.TabIndex = 0
		'
		'btnProcurar
		'
		Me.btnProcurar.AllowAnimations = True
		Me.btnProcurar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnProcurar.BackColor = System.Drawing.Color.Transparent
		Me.btnProcurar.Enabled = False
		Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.search1
		Me.btnProcurar.ImageAbsolutePosition = New System.Drawing.Point(10, 12)
		Me.btnProcurar.Location = New System.Drawing.Point(547, 83)
		Me.btnProcurar.Name = "btnProcurar"
		Me.btnProcurar.RoundedCornersMask = CType(15, Byte)
		Me.btnProcurar.RoundedCornersRadius = 0
		Me.btnProcurar.Size = New System.Drawing.Size(126, 57)
		Me.btnProcurar.TabIndex = 11
		Me.btnProcurar.TabStop = False
		Me.btnProcurar.Text = "&Procurar"
		Me.btnProcurar.TextAbsolutePosition = New System.Drawing.Point(25, 5)
		Me.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnProcurar.UseAbsoluteImagePositioning = True
		Me.btnProcurar.UseAbsoluteTextPositioning = True
		Me.btnProcurar.UseVisualStyleBackColor = False
		Me.btnProcurar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
		Me.btnClose.Location = New System.Drawing.Point(1030, 12)
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
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.ForeColor = System.Drawing.Color.Black
		Me.Label12.Location = New System.Drawing.Point(16, 71)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(134, 19)
		Me.Label12.TabIndex = 1
		Me.Label12.Text = "Forma de Cobrança"
		'
		'btnQuitar
		'
		Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnQuitar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnQuitar.ForeColor = System.Drawing.Color.DarkBlue
		Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
		Me.btnQuitar.Location = New System.Drawing.Point(12, 631)
		Me.btnQuitar.Name = "btnQuitar"
		Me.btnQuitar.Size = New System.Drawing.Size(143, 41)
		Me.btnQuitar.TabIndex = 12
		Me.btnQuitar.Text = "&Quitar"
		Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnQuitar.UseVisualStyleBackColor = True
		'
		'mnuOperacoes
		'
		Me.mnuOperacoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarToolStripMenuItem, Me.CancelarToolStripMenuItem, Me.NegativarToolStripMenuItem, Me.NormalizarToolStripMenuItem, Me.ToolStripSeparator2, Me.VerOrigemToolStripMenuItem})
		Me.mnuOperacoes.Name = "mnuOperacoes"
		Me.mnuOperacoes.Size = New System.Drawing.Size(134, 120)
		'
		'QuitarToolStripMenuItem
		'
		Me.QuitarToolStripMenuItem.Name = "QuitarToolStripMenuItem"
		Me.QuitarToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
		Me.QuitarToolStripMenuItem.Text = "Quitar"
		'
		'CancelarToolStripMenuItem
		'
		Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
		Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
		Me.CancelarToolStripMenuItem.Text = "Cancelar"
		'
		'NegativarToolStripMenuItem
		'
		Me.NegativarToolStripMenuItem.Name = "NegativarToolStripMenuItem"
		Me.NegativarToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
		Me.NegativarToolStripMenuItem.Text = "Negativar"
		'
		'NormalizarToolStripMenuItem
		'
		Me.NormalizarToolStripMenuItem.Name = "NormalizarToolStripMenuItem"
		Me.NormalizarToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
		Me.NormalizarToolStripMenuItem.Text = "Normalizar"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(130, 6)
		'
		'VerOrigemToolStripMenuItem
		'
		Me.VerOrigemToolStripMenuItem.Name = "VerOrigemToolStripMenuItem"
		Me.VerOrigemToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
		Me.VerOrigemToolStripMenuItem.Text = "Ver Origem"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Location = New System.Drawing.Point(86, 137)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(64, 19)
		Me.Label1.TabIndex = 5
		Me.Label1.Text = "Situação"
		'
		'DataGridViewTextBoxColumn1
		'
		Me.DataGridViewTextBoxColumn1.Frozen = True
		Me.DataGridViewTextBoxColumn1.HeaderText = "Vencimento"
		Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
		'
		'DataGridViewTextBoxColumn2
		'
		Me.DataGridViewTextBoxColumn2.Frozen = True
		Me.DataGridViewTextBoxColumn2.HeaderText = "Credor"
		Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
		Me.DataGridViewTextBoxColumn2.Width = 280
		'
		'DataGridViewTextBoxColumn3
		'
		Me.DataGridViewTextBoxColumn3.HeaderText = "Origem"
		Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
		Me.DataGridViewTextBoxColumn3.Width = 150
		'
		'DataGridViewTextBoxColumn4
		'
		Me.DataGridViewTextBoxColumn4.HeaderText = "Forma"
		Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
		Me.DataGridViewTextBoxColumn4.Width = 150
		'
		'DataGridViewTextBoxColumn5
		'
		Me.DataGridViewTextBoxColumn5.HeaderText = "Valor"
		Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
		'
		'DataGridViewTextBoxColumn6
		'
		Me.DataGridViewTextBoxColumn6.HeaderText = "Situação"
		Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
		Me.DataGridViewTextBoxColumn6.Width = 80
		'
		'cmbSituacao
		'
		Me.cmbSituacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbSituacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSituacao.FormattingEnabled = True
		Me.cmbSituacao.Location = New System.Drawing.Point(156, 134)
		Me.cmbSituacao.Name = "cmbSituacao"
		Me.cmbSituacao.RestrictContentToListItems = True
		Me.cmbSituacao.Size = New System.Drawing.Size(187, 27)
		Me.cmbSituacao.TabIndex = 6
		'
		'cmbCobrancaForma
		'
		Me.cmbCobrancaForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbCobrancaForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbCobrancaForma.FormattingEnabled = True
		Me.cmbCobrancaForma.Location = New System.Drawing.Point(156, 68)
		Me.cmbCobrancaForma.Name = "cmbCobrancaForma"
		Me.cmbCobrancaForma.RestrictContentToListItems = True
		Me.cmbCobrancaForma.Size = New System.Drawing.Size(187, 27)
		Me.cmbCobrancaForma.TabIndex = 2
		'
		'btnImprimir
		'
		Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnImprimir.ForeColor = System.Drawing.Color.DarkBlue
		Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir_PEQ
		Me.btnImprimir.Location = New System.Drawing.Point(161, 631)
		Me.btnImprimir.Name = "btnImprimir"
		Me.btnImprimir.Size = New System.Drawing.Size(143, 41)
		Me.btnImprimir.TabIndex = 13
		Me.btnImprimir.Text = "&Imprimir"
		Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnImprimir.UseVisualStyleBackColor = True
		'
		'lblValorTotal
		'
		Me.lblValorTotal.BackColor = System.Drawing.Color.LightGray
		Me.lblValorTotal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblValorTotal.Location = New System.Drawing.Point(610, 591)
		Me.lblValorTotal.Name = "lblValorTotal"
		Me.lblValorTotal.Size = New System.Drawing.Size(137, 27)
		Me.lblValorTotal.TabIndex = 16
		Me.lblValorTotal.Text = "R$ 0,00"
		Me.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblPagoTotal
		'
		Me.lblPagoTotal.BackColor = System.Drawing.Color.LightGray
		Me.lblPagoTotal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPagoTotal.Location = New System.Drawing.Point(760, 591)
		Me.lblPagoTotal.Name = "lblPagoTotal"
		Me.lblPagoTotal.Size = New System.Drawing.Size(137, 27)
		Me.lblPagoTotal.TabIndex = 16
		Me.lblPagoTotal.Text = "R$ 0,00"
		Me.lblPagoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblEmAbertoTotal
		'
		Me.lblEmAbertoTotal.BackColor = System.Drawing.Color.LightGray
		Me.lblEmAbertoTotal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEmAbertoTotal.Location = New System.Drawing.Point(910, 591)
		Me.lblEmAbertoTotal.Name = "lblEmAbertoTotal"
		Me.lblEmAbertoTotal.Size = New System.Drawing.Size(137, 27)
		Me.lblEmAbertoTotal.TabIndex = 16
		Me.lblEmAbertoTotal.Text = "R$ 0,00"
		Me.lblEmAbertoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.DimGray
		Me.Label4.Location = New System.Drawing.Point(678, 572)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(69, 15)
		Me.Label4.TabIndex = 17
		Me.Label4.Text = "Valor Total:"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.ForeColor = System.Drawing.Color.DimGray
		Me.Label11.Location = New System.Drawing.Point(794, 572)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(99, 15)
		Me.Label11.TabIndex = 17
		Me.Label11.Text = "Valor Pago Total:"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label13.ForeColor = System.Drawing.Color.DimGray
		Me.Label13.Location = New System.Drawing.Point(952, 572)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(95, 15)
		Me.Label13.TabIndex = 17
		Me.Label13.Text = "Em Aberto Total:"
		'
		'frmAPagarProcurar
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1063, 681)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.lblEmAbertoTotal)
		Me.Controls.Add(Me.lblPagoTotal)
		Me.Controls.Add(Me.lblValorTotal)
		Me.Controls.Add(Me.cmbSituacao)
		Me.Controls.Add(Me.cmbCobrancaForma)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Label12)
		Me.Controls.Add(Me.btnProcurar)
		Me.Controls.Add(Me.pnlMes)
		Me.Controls.Add(Me.pnlVenda)
		Me.Controls.Add(Me.btnImprimir)
		Me.Controls.Add(Me.btnQuitar)
		Me.Controls.Add(Me.btnEditar)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.dgvListagem)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtCredorCadastro)
		Me.Name = "frmAPagarProcurar"
		Me.Text = "Procurar Saída de Produto"
		Me.Controls.SetChildIndex(Me.txtCredorCadastro, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.dgvListagem, 0)
		Me.Controls.SetChildIndex(Me.btnCancelar, 0)
		Me.Controls.SetChildIndex(Me.btnEditar, 0)
		Me.Controls.SetChildIndex(Me.btnQuitar, 0)
		Me.Controls.SetChildIndex(Me.btnImprimir, 0)
		Me.Controls.SetChildIndex(Me.pnlVenda, 0)
		Me.Controls.SetChildIndex(Me.pnlMes, 0)
		Me.Controls.SetChildIndex(Me.btnProcurar, 0)
		Me.Controls.SetChildIndex(Me.Label12, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.cmbCobrancaForma, 0)
		Me.Controls.SetChildIndex(Me.cmbSituacao, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.lblValorTotal, 0)
		Me.Controls.SetChildIndex(Me.lblPagoTotal, 0)
		Me.Controls.SetChildIndex(Me.lblEmAbertoTotal, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.Label11, 0)
		Me.Controls.SetChildIndex(Me.Label13, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.pnlPorPeriodo.ResumeLayout(False)
		Me.pnlPorMes.ResumeLayout(False)
		CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlVenda.ResumeLayout(False)
		Me.pnlVenda.PerformLayout()
		Me.pnlMes.ResumeLayout(False)
		Me.mnuOperacoes.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtCredorCadastro As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents btnPeriodoAnterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents btnPeriodoPosterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents pnlVenda As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnMesAtual As VIBlend.WinForms.Controls.vButton
    Friend WithEvents pnlMes As Panel
    Friend WithEvents dtMes As MonthCalendar
    Friend WithEvents btnProcurar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents txtDespesaTipo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbCobrancaForma As Controles.ComboBox_OnlyValues
    Friend WithEvents btnQuitar As Button
    Friend WithEvents mnuOperacoes As ContextMenuStrip
    Friend WithEvents QuitarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NegativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormalizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents VerOrigemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSituacao As Controles.ComboBox_OnlyValues
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents rbtTodas As RadioButton
    Friend WithEvents rbtPorPeriodo As RadioButton
    Friend WithEvents rbtPorMes As RadioButton
    Friend WithEvents pnlPorMes As Panel
    Friend WithEvents pnlPorPeriodo As Panel
    Friend WithEvents btnDtInicial As VIBlend.WinForms.Controls.vButton
    Friend WithEvents lblDtFinal As Label
    Friend WithEvents lblDtInicial As Label
    Friend WithEvents btnDtFinal As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnImprimir As Button
    Friend WithEvents clnVencimento As DataGridViewTextBoxColumn
    Friend WithEvents clnCredor As DataGridViewTextBoxColumn
    Friend WithEvents clnOrigem As DataGridViewTextBoxColumn
    Friend WithEvents clnForma As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents clnValorPago As DataGridViewTextBoxColumn
    Friend WithEvents clnSituacao As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents lblValorTotal As Label
    Friend WithEvents lblPagoTotal As Label
    Friend WithEvents lblEmAbertoTotal As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
End Class
