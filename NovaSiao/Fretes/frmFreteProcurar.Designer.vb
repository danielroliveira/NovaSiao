<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFreteProcurar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnMesAtual = New VIBlend.WinForms.Controls.vButton()
        Me.btnPeriodoAnterior = New VIBlend.WinForms.Controls.vArrowButton()
        Me.btnPeriodoPosterior = New VIBlend.WinForms.Controls.vArrowButton()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.chkPeriodoTodos = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clnFreteData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnTransportadora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnOperacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnConhecimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnConhecimentoData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFreteValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlVenda = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlMes = New System.Windows.Forms.Panel()
        Me.dtMes = New System.Windows.Forms.MonthCalendar()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.btnTransportadora = New VIBlend.WinForms.Controls.vButton()
        Me.txtTransportadora = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnDespesa = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbtCobradas = New System.Windows.Forms.RadioButton()
        Me.rbtEmAberto = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVenda.SuspendLayout()
        Me.pnlMes.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(723, 7)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(182, 34)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Frete - Procurar"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.btnMesAtual)
        Me.Panel2.Controls.Add(Me.btnPeriodoAnterior)
        Me.Panel2.Controls.Add(Me.btnPeriodoPosterior)
        Me.Panel2.Controls.Add(Me.lblPeriodo)
        Me.Panel2.Controls.Add(Me.chkPeriodoTodos)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(622, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(310, 66)
        Me.Panel2.TabIndex = 6
        '
        'btnMesAtual
        '
        Me.btnMesAtual.AllowAnimations = True
        Me.btnMesAtual.BackColor = System.Drawing.Color.Transparent
        Me.btnMesAtual.Location = New System.Drawing.Point(253, 33)
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
        Me.btnPeriodoAnterior.Location = New System.Drawing.Point(18, 33)
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
        'btnPeriodoPosterior
        '
        Me.btnPeriodoPosterior.AllowAnimations = True
        Me.btnPeriodoPosterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Right
        Me.btnPeriodoPosterior.Location = New System.Drawing.Point(223, 33)
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
        'lblPeriodo
        '
        Me.lblPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriodo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.Location = New System.Drawing.Point(14, 30)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(238, 30)
        Me.lblPeriodo.TabIndex = 2
        Me.lblPeriodo.Text = "Novembro | 2017"
        Me.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkPeriodoTodos
        '
        Me.chkPeriodoTodos.AutoSize = True
        Me.chkPeriodoTodos.Location = New System.Drawing.Point(109, 4)
        Me.chkPeriodoTodos.Name = "chkPeriodoTodos"
        Me.chkPeriodoTodos.Size = New System.Drawing.Size(152, 23)
        Me.chkPeriodoTodos.TabIndex = 1
        Me.chkPeriodoTodos.TabStop = False
        Me.chkPeriodoTodos.Text = "Todos | Sem Limite"
        Me.chkPeriodoTodos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Período"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnSelect, Me.clnFreteData, Me.clnTransportadora, Me.clnOperacao, Me.clnConhecimento, Me.clnConhecimentoData, Me.clnFreteValor})
        Me.dgvListagem.GridColor = System.Drawing.Color.LightSteelBlue
        Me.dgvListagem.Location = New System.Drawing.Point(12, 172)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.RowHeadersWidth = 30
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray
        Me.dgvListagem.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListagem.Size = New System.Drawing.Size(920, 368)
        Me.dgvListagem.TabIndex = 8
        '
        'clnSelect
        '
        Me.clnSelect.HeaderText = "Select"
        Me.clnSelect.Name = "clnSelect"
        Me.clnSelect.Width = 30
        '
        'clnFreteData
        '
        Me.clnFreteData.HeaderText = "FreteData"
        Me.clnFreteData.Name = "clnFreteData"
        '
        'clnTransportadora
        '
        Me.clnTransportadora.HeaderText = "Transportadora"
        Me.clnTransportadora.Name = "clnTransportadora"
        Me.clnTransportadora.Width = 280
        '
        'clnOperacao
        '
        Me.clnOperacao.HeaderText = "Operação"
        Me.clnOperacao.Name = "clnOperacao"
        Me.clnOperacao.Width = 90
        '
        'clnConhecimento
        '
        Me.clnConhecimento.HeaderText = "Conhecimento"
        Me.clnConhecimento.Name = "clnConhecimento"
        Me.clnConhecimento.Width = 150
        '
        'clnConhecimentoData
        '
        Me.clnConhecimentoData.HeaderText = "ConData"
        Me.clnConhecimentoData.Name = "clnConhecimentoData"
        '
        'clnFreteValor
        '
        Me.clnFreteValor.HeaderText = "Valor"
        Me.clnFreteValor.Name = "clnFreteValor"
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFechar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.Location = New System.Drawing.Point(811, 551)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(121, 41)
        Me.btnFechar.TabIndex = 12
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
        Me.btnEditar.Location = New System.Drawing.Point(12, 551)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(165, 41)
        Me.btnEditar.TabIndex = 10
        Me.btnEditar.Text = "&Editar Frete"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'pnlVenda
        '
        Me.pnlVenda.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlVenda.Controls.Add(Me.Label10)
        Me.pnlVenda.Controls.Add(Me.Label9)
        Me.pnlVenda.Controls.Add(Me.Label6)
        Me.pnlVenda.Controls.Add(Me.Label7)
        Me.pnlVenda.Controls.Add(Me.Label5)
        Me.pnlVenda.Controls.Add(Me.Label8)
        Me.pnlVenda.Location = New System.Drawing.Point(12, 143)
        Me.pnlVenda.Name = "pnlVenda"
        Me.pnlVenda.Size = New System.Drawing.Size(920, 28)
        Me.pnlVenda.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(832, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 19)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Valor"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(684, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Con. Data"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(533, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Conhecimento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(163, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 19)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Transportadora"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(445, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Operação"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(64, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 19)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Data"
        '
        'pnlMes
        '
        Me.pnlMes.Controls.Add(Me.dtMes)
        Me.pnlMes.Location = New System.Drawing.Point(649, 260)
        Me.pnlMes.Name = "pnlMes"
        Me.pnlMes.Size = New System.Drawing.Size(234, 166)
        Me.pnlMes.TabIndex = 10
        Me.pnlMes.Visible = False
        '
        'dtMes
        '
        Me.dtMes.Location = New System.Drawing.Point(3, 0)
        Me.dtMes.Name = "dtMes"
        Me.dtMes.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(912, 12)
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
        'btnTransportadora
        '
        Me.btnTransportadora.AllowAnimations = True
        Me.btnTransportadora.BackColor = System.Drawing.Color.Transparent
        Me.btnTransportadora.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTransportadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransportadora.Location = New System.Drawing.Point(508, 105)
        Me.btnTransportadora.Name = "btnTransportadora"
        Me.btnTransportadora.RoundedCornersMask = CType(15, Byte)
        Me.btnTransportadora.RoundedCornersRadius = 0
        Me.btnTransportadora.Size = New System.Drawing.Size(34, 27)
        Me.btnTransportadora.TabIndex = 5
        Me.btnTransportadora.TabStop = False
        Me.btnTransportadora.Text = "..."
        Me.btnTransportadora.UseCompatibleTextRendering = True
        Me.btnTransportadora.UseVisualStyleBackColor = False
        Me.btnTransportadora.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtTransportadora
        '
        Me.txtTransportadora.Location = New System.Drawing.Point(148, 105)
        Me.txtTransportadora.Name = "txtTransportadora"
        Me.txtTransportadora.Size = New System.Drawing.Size(355, 27)
        Me.txtTransportadora.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(35, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 19)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Transportadora"
        '
        'btnDespesa
        '
        Me.btnDespesa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDespesa.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDespesa.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnDespesa.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnDespesa.Location = New System.Drawing.Point(184, 551)
        Me.btnDespesa.Name = "btnDespesa"
        Me.btnDespesa.Size = New System.Drawing.Size(165, 41)
        Me.btnDespesa.TabIndex = 11
        Me.btnDespesa.Text = "&Gerar Despesa"
        Me.btnDespesa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDespesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDespesa.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.rbtCobradas)
        Me.Panel3.Controls.Add(Me.rbtEmAberto)
        Me.Panel3.Location = New System.Drawing.Point(148, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(233, 32)
        Me.Panel3.TabIndex = 2
        '
        'rbtCobradas
        '
        Me.rbtCobradas.AutoSize = True
        Me.rbtCobradas.Location = New System.Drawing.Point(127, 4)
        Me.rbtCobradas.Name = "rbtCobradas"
        Me.rbtCobradas.Size = New System.Drawing.Size(88, 23)
        Me.rbtCobradas.TabIndex = 1
        Me.rbtCobradas.Text = "Cobradas"
        Me.rbtCobradas.UseVisualStyleBackColor = True
        '
        'rbtEmAberto
        '
        Me.rbtEmAberto.AutoSize = True
        Me.rbtEmAberto.Checked = True
        Me.rbtEmAberto.Location = New System.Drawing.Point(10, 4)
        Me.rbtEmAberto.Name = "rbtEmAberto"
        Me.rbtEmAberto.Size = New System.Drawing.Size(94, 23)
        Me.rbtEmAberto.TabIndex = 0
        Me.rbtEmAberto.TabStop = True
        Me.rbtEmAberto.Text = "Em Aberto"
        Me.rbtEmAberto.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(74, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Situação"
        '
        'frmFreteProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(944, 601)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnTransportadora)
        Me.Controls.Add(Me.txtTransportadora)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.pnlMes)
        Me.Controls.Add(Me.pnlVenda)
        Me.Controls.Add(Me.btnDespesa)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmFreteProcurar"
        Me.Text = "Procurar Saída de Produto"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnDespesa, 0)
        Me.Controls.SetChildIndex(Me.pnlVenda, 0)
        Me.Controls.SetChildIndex(Me.pnlMes, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtTransportadora, 0)
        Me.Controls.SetChildIndex(Me.btnTransportadora, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVenda.ResumeLayout(False)
        Me.pnlVenda.PerformLayout()
        Me.pnlMes.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkPeriodoTodos As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents btnPeriodoAnterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents btnPeriodoPosterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnFechar As Button
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
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents btnTransportadora As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtTransportadora As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnDespesa As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rbtEmAberto As RadioButton
    Friend WithEvents rbtCobradas As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents clnSelect As DataGridViewCheckBoxColumn
    Friend WithEvents clnFreteData As DataGridViewTextBoxColumn
    Friend WithEvents clnTransportadora As DataGridViewTextBoxColumn
    Friend WithEvents clnOperacao As DataGridViewTextBoxColumn
    Friend WithEvents clnConhecimento As DataGridViewTextBoxColumn
    Friend WithEvents clnConhecimentoData As DataGridViewTextBoxColumn
    Friend WithEvents clnFreteValor As DataGridViewTextBoxColumn
End Class
