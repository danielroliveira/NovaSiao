<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespesaPeriodicaProcurar
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
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnDespesaData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnCredor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDespesaTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlVenda = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnProcurar = New VIBlend.WinForms.Controls.vButton()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.btnCredor = New VIBlend.WinForms.Controls.vButton()
        Me.txtCredor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnTipo = New VIBlend.WinForms.Controls.vButton()
        Me.txtDespesaTipo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnNova = New System.Windows.Forms.Button()
        Me.pnlPeriodicidade = New System.Windows.Forms.Panel()
        Me.rbtTodas = New System.Windows.Forms.RadioButton()
        Me.rbtAnual = New System.Windows.Forms.RadioButton()
        Me.rbtMensal = New System.Windows.Forms.RadioButton()
        Me.rbtSemanal = New System.Windows.Forms.RadioButton()
        Me.mnuListagem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAtivar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDesativar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVenda.SuspendLayout()
        Me.pnlPeriodicidade.SuspendLayout()
        Me.mnuListagem.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(599, 7)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(306, 34)
        Me.lblTitulo.Text = "Despesa Periódica - Procurar"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(144, 132)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(355, 27)
        Me.txtDescricao.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Descrição"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnDespesaData, Me.clnCredor, Me.clnDespesaTipo})
        Me.dgvListagem.GridColor = System.Drawing.Color.LightSteelBlue
        Me.dgvListagem.Location = New System.Drawing.Point(12, 198)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray
        Me.dgvListagem.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListagem.Size = New System.Drawing.Size(920, 368)
        Me.dgvListagem.TabIndex = 11
        '
        'clnDespesaData
        '
        Me.clnDespesaData.HeaderText = "DespesaData"
        Me.clnDespesaData.Name = "clnDespesaData"
        Me.clnDespesaData.ReadOnly = True
        '
        'clnCredor
        '
        Me.clnCredor.HeaderText = "Credor"
        Me.clnCredor.Name = "clnCredor"
        Me.clnCredor.ReadOnly = True
        Me.clnCredor.Width = 300
        '
        'clnDespesaTipo
        '
        Me.clnDespesaTipo.HeaderText = "DespesaTipo"
        Me.clnDespesaTipo.Name = "clnDespesaTipo"
        Me.clnDespesaTipo.ReadOnly = True
        Me.clnDespesaTipo.Width = 150
        '
        'btnFechar
        '
        Me.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFechar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.Location = New System.Drawing.Point(789, 574)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(143, 41)
        Me.btnFechar.TabIndex = 15
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEditar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(491, 574)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(143, 41)
        Me.btnEditar.TabIndex = 13
        Me.btnEditar.Text = "&Editar"
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
        Me.pnlVenda.Location = New System.Drawing.Point(12, 169)
        Me.pnlVenda.Name = "pnlVenda"
        Me.pnlVenda.Size = New System.Drawing.Size(920, 28)
        Me.pnlVenda.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(833, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 19)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Sit"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(740, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 19)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Valor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(583, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 19)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Descrição"
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
        Me.Label5.Location = New System.Drawing.Point(434, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 19)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Tipo de Despesa"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(33, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 19)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Início Data"
        '
        'btnProcurar
        '
        Me.btnProcurar.AllowAnimations = True
        Me.btnProcurar.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurar.Enabled = False
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.search1
        Me.btnProcurar.ImageAbsolutePosition = New System.Drawing.Point(10, 5)
        Me.btnProcurar.Location = New System.Drawing.Point(12, 574)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurar.RoundedCornersRadius = 0
        Me.btnProcurar.Size = New System.Drawing.Size(126, 41)
        Me.btnProcurar.TabIndex = 12
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
        Me.btnClose.Location = New System.Drawing.Point(912, 12)
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
        'btnCredor
        '
        Me.btnCredor.AllowAnimations = True
        Me.btnCredor.BackColor = System.Drawing.Color.Transparent
        Me.btnCredor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCredor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCredor.Location = New System.Drawing.Point(504, 99)
        Me.btnCredor.Name = "btnCredor"
        Me.btnCredor.RoundedCornersMask = CType(15, Byte)
        Me.btnCredor.RoundedCornersRadius = 0
        Me.btnCredor.Size = New System.Drawing.Size(34, 27)
        Me.btnCredor.TabIndex = 6
        Me.btnCredor.TabStop = False
        Me.btnCredor.Text = "..."
        Me.btnCredor.UseCompatibleTextRendering = True
        Me.btnCredor.UseVisualStyleBackColor = False
        Me.btnCredor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtCredor
        '
        Me.txtCredor.Location = New System.Drawing.Point(144, 99)
        Me.txtCredor.Name = "txtCredor"
        Me.txtCredor.Size = New System.Drawing.Size(355, 27)
        Me.txtCredor.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(84, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 19)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Credor"
        '
        'btnTipo
        '
        Me.btnTipo.AllowAnimations = True
        Me.btnTipo.BackColor = System.Drawing.Color.Transparent
        Me.btnTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTipo.Location = New System.Drawing.Point(354, 66)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.RoundedCornersMask = CType(15, Byte)
        Me.btnTipo.RoundedCornersRadius = 0
        Me.btnTipo.Size = New System.Drawing.Size(34, 27)
        Me.btnTipo.TabIndex = 3
        Me.btnTipo.TabStop = False
        Me.btnTipo.Text = "..."
        Me.btnTipo.UseCompatibleTextRendering = True
        Me.btnTipo.UseVisualStyleBackColor = False
        Me.btnTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtDespesaTipo
        '
        Me.txtDespesaTipo.Location = New System.Drawing.Point(144, 66)
        Me.txtDespesaTipo.Name = "txtDespesaTipo"
        Me.txtDespesaTipo.Size = New System.Drawing.Size(205, 27)
        Me.txtDespesaTipo.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Tipo de Despesa"
        '
        'btnNova
        '
        Me.btnNova.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNova.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnNova.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnNova.Location = New System.Drawing.Point(640, 574)
        Me.btnNova.Name = "btnNova"
        Me.btnNova.Size = New System.Drawing.Size(143, 41)
        Me.btnNova.TabIndex = 14
        Me.btnNova.Text = "&Nova"
        Me.btnNova.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNova.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNova.UseVisualStyleBackColor = True
        '
        'pnlPeriodicidade
        '
        Me.pnlPeriodicidade.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlPeriodicidade.Controls.Add(Me.rbtTodas)
        Me.pnlPeriodicidade.Controls.Add(Me.rbtAnual)
        Me.pnlPeriodicidade.Controls.Add(Me.rbtMensal)
        Me.pnlPeriodicidade.Controls.Add(Me.rbtSemanal)
        Me.pnlPeriodicidade.Location = New System.Drawing.Point(604, 69)
        Me.pnlPeriodicidade.Name = "pnlPeriodicidade"
        Me.pnlPeriodicidade.Size = New System.Drawing.Size(328, 39)
        Me.pnlPeriodicidade.TabIndex = 9
        '
        'rbtTodas
        '
        Me.rbtTodas.AutoSize = True
        Me.rbtTodas.Location = New System.Drawing.Point(255, 7)
        Me.rbtTodas.Name = "rbtTodas"
        Me.rbtTodas.Size = New System.Drawing.Size(65, 23)
        Me.rbtTodas.TabIndex = 3
        Me.rbtTodas.TabStop = True
        Me.rbtTodas.Text = "Todas"
        Me.rbtTodas.UseVisualStyleBackColor = True
        '
        'rbtAnual
        '
        Me.rbtAnual.AutoSize = True
        Me.rbtAnual.Location = New System.Drawing.Point(181, 7)
        Me.rbtAnual.Name = "rbtAnual"
        Me.rbtAnual.Size = New System.Drawing.Size(64, 23)
        Me.rbtAnual.TabIndex = 2
        Me.rbtAnual.TabStop = True
        Me.rbtAnual.Text = "Anual"
        Me.rbtAnual.UseVisualStyleBackColor = True
        '
        'rbtMensal
        '
        Me.rbtMensal.AutoSize = True
        Me.rbtMensal.Location = New System.Drawing.Point(100, 7)
        Me.rbtMensal.Name = "rbtMensal"
        Me.rbtMensal.Size = New System.Drawing.Size(75, 23)
        Me.rbtMensal.TabIndex = 1
        Me.rbtMensal.TabStop = True
        Me.rbtMensal.Text = "Mensal"
        Me.rbtMensal.UseVisualStyleBackColor = True
        '
        'rbtSemanal
        '
        Me.rbtSemanal.AutoSize = True
        Me.rbtSemanal.Location = New System.Drawing.Point(12, 7)
        Me.rbtSemanal.Name = "rbtSemanal"
        Me.rbtSemanal.Size = New System.Drawing.Size(82, 23)
        Me.rbtSemanal.TabIndex = 0
        Me.rbtSemanal.TabStop = True
        Me.rbtSemanal.Text = "Semanal"
        Me.rbtSemanal.UseVisualStyleBackColor = True
        '
        'mnuListagem
        '
        Me.mnuListagem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAtivar, Me.miDesativar})
        Me.mnuListagem.Name = "MenuFab"
        Me.mnuListagem.Size = New System.Drawing.Size(169, 48)
        '
        'miAtivar
        '
        Me.miAtivar.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.miAtivar.Name = "miAtivar"
        Me.miAtivar.Size = New System.Drawing.Size(168, 22)
        Me.miAtivar.Text = "Ativar Despesa"
        '
        'miDesativar
        '
        Me.miDesativar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.miDesativar.Name = "miDesativar"
        Me.miDesativar.Size = New System.Drawing.Size(168, 22)
        Me.miDesativar.Text = "Desativar Despesa"
        '
        'frmDespesaPeriodicaProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(944, 624)
        Me.Controls.Add(Me.pnlPeriodicidade)
        Me.Controls.Add(Me.btnTipo)
        Me.Controls.Add(Me.txtDespesaTipo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnCredor)
        Me.Controls.Add(Me.txtCredor)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnProcurar)
        Me.Controls.Add(Me.pnlVenda)
        Me.Controls.Add(Me.btnNova)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescricao)
        Me.Name = "frmDespesaPeriodicaProcurar"
        Me.Text = "Procurar Saída de Produto"
        Me.Controls.SetChildIndex(Me.txtDescricao, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnNova, 0)
        Me.Controls.SetChildIndex(Me.pnlVenda, 0)
        Me.Controls.SetChildIndex(Me.btnProcurar, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtCredor, 0)
        Me.Controls.SetChildIndex(Me.btnCredor, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txtDespesaTipo, 0)
        Me.Controls.SetChildIndex(Me.btnTipo, 0)
        Me.Controls.SetChildIndex(Me.pnlPeriodicidade, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVenda.ResumeLayout(False)
        Me.pnlVenda.PerformLayout()
        Me.pnlPeriodicidade.ResumeLayout(False)
        Me.pnlPeriodicidade.PerformLayout()
        Me.mnuListagem.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents Label2 As Label
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
    Friend WithEvents btnProcurar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents btnCredor As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtCredor As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnTipo As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtDespesaTipo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents clnDespesaData As DataGridViewTextBoxColumn
    Friend WithEvents clnCredor As DataGridViewTextBoxColumn
    Friend WithEvents clnDespesaTipo As DataGridViewTextBoxColumn
    Friend WithEvents btnNova As Button
    Friend WithEvents pnlPeriodicidade As Panel
    Friend WithEvents rbtTodas As RadioButton
    Friend WithEvents rbtAnual As RadioButton
    Friend WithEvents rbtMensal As RadioButton
    Friend WithEvents rbtSemanal As RadioButton
    Friend WithEvents mnuListagem As ContextMenuStrip
    Friend WithEvents miAtivar As ToolStripMenuItem
    Friend WithEvents miDesativar As ToolStripMenuItem
End Class
