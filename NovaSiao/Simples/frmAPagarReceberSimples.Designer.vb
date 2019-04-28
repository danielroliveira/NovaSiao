<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPagarReceberSimples
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
        Me.txtFilialDestino = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnMesAtual = New VIBlend.WinForms.Controls.vButton()
        Me.btnPeriodoAnterior = New VIBlend.WinForms.Controls.vArrowButton()
        Me.btnPeriodoPosterior = New VIBlend.WinForms.Controls.vArrowButton()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.chkPeriodoTodos = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFilial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnSituacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lbl4 = New System.Windows.Forms.Label()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl0 = New System.Windows.Forms.Label()
        Me.pnlMes = New System.Windows.Forms.Panel()
        Me.dtMes = New System.Windows.Forms.MonthCalendar()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbSituacao = New Controles.ComboBox_OnlyValues()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbtAPagar = New System.Windows.Forms.RadioButton()
        Me.rbtAReceber = New System.Windows.Forms.RadioButton()
        Me.btnProcurarFilial = New VIBlend.WinForms.Controls.vButton()
        Me.VPanel1 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblT1 = New System.Windows.Forms.Label()
        Me.lblT2 = New System.Windows.Forms.Label()
        Me.VPanel2 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblPago = New System.Windows.Forms.Label()
        Me.lblT3 = New System.Windows.Forms.Label()
        Me.VPanel3 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblEmAberto = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlMes.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.VPanel1.Content.SuspendLayout()
        Me.VPanel1.SuspendLayout()
        Me.VPanel2.Content.SuspendLayout()
        Me.VPanel2.SuspendLayout()
        Me.VPanel3.Content.SuspendLayout()
        Me.VPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(941, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(584, 7)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(321, 34)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Simples Entradas - A Pagar"
        '
        'txtFilialDestino
        '
        Me.txtFilialDestino.Location = New System.Drawing.Point(124, 68)
        Me.txtFilialDestino.Name = "txtFilialDestino"
        Me.txtFilialDestino.Size = New System.Drawing.Size(208, 27)
        Me.txtFilialDestino.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Filial | Origem"
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
        Me.Panel2.TabIndex = 7
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
        Me.Label3.Size = New System.Drawing.Size(90, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Vencimento"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnVencimento, Me.clnFilial, Me.clnValor, Me.clnPago, Me.clnSituacao})
        Me.dgvListagem.GridColor = System.Drawing.Color.LightSteelBlue
        Me.dgvListagem.Location = New System.Drawing.Point(12, 175)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray
        Me.dgvListagem.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListagem.Size = New System.Drawing.Size(920, 368)
        Me.dgvListagem.TabIndex = 10
        '
        'clnVencimento
        '
        Me.clnVencimento.Frozen = True
        Me.clnVencimento.HeaderText = "Vencimento"
        Me.clnVencimento.Name = "clnVencimento"
        Me.clnVencimento.ReadOnly = True
        '
        'clnFilial
        '
        Me.clnFilial.Frozen = True
        Me.clnFilial.HeaderText = "Filial"
        Me.clnFilial.Name = "clnFilial"
        Me.clnFilial.ReadOnly = True
        Me.clnFilial.Width = 280
        '
        'clnValor
        '
        Me.clnValor.HeaderText = "Valor"
        Me.clnValor.Name = "clnValor"
        Me.clnValor.ReadOnly = True
        '
        'clnPago
        '
        Me.clnPago.HeaderText = "Pago"
        Me.clnPago.Name = "clnPago"
        Me.clnPago.ReadOnly = True
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
        Me.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(786, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(143, 41)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Fechar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray
        Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(12, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(143, 41)
        Me.btnEditar.TabIndex = 0
        Me.btnEditar.Text = "&Ver Origem"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlHeader.Controls.Add(Me.lbl4)
        Me.pnlHeader.Controls.Add(Me.lbl3)
        Me.pnlHeader.Controls.Add(Me.lbl2)
        Me.pnlHeader.Controls.Add(Me.lbl1)
        Me.pnlHeader.Controls.Add(Me.lbl0)
        Me.pnlHeader.Location = New System.Drawing.Point(12, 146)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(920, 28)
        Me.pnlHeader.TabIndex = 9
        '
        'lbl4
        '
        Me.lbl4.AutoSize = True
        Me.lbl4.BackColor = System.Drawing.Color.Transparent
        Me.lbl4.Location = New System.Drawing.Point(624, 4)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(64, 19)
        Me.lbl4.TabIndex = 4
        Me.lbl4.Text = "Situação"
        '
        'lbl3
        '
        Me.lbl3.BackColor = System.Drawing.Color.Transparent
        Me.lbl3.Location = New System.Drawing.Point(505, 4)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(100, 19)
        Me.lbl3.TabIndex = 3
        Me.lbl3.Text = "Pago"
        Me.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.BackColor = System.Drawing.Color.Transparent
        Me.lbl2.Location = New System.Drawing.Point(457, 4)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(42, 19)
        Me.lbl2.TabIndex = 2
        Me.lbl2.Text = "Valor"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Location = New System.Drawing.Point(132, 4)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(112, 19)
        Me.lbl1.TabIndex = 1
        Me.lbl1.Text = "Filial de Origem"
        '
        'lbl0
        '
        Me.lbl0.AutoSize = True
        Me.lbl0.BackColor = System.Drawing.Color.Transparent
        Me.lbl0.Location = New System.Drawing.Point(33, 4)
        Me.lbl0.Name = "lbl0"
        Me.lbl0.Size = New System.Drawing.Size(85, 19)
        Me.lbl0.TabIndex = 0
        Me.lbl0.Text = "Vencimento"
        '
        'pnlMes
        '
        Me.pnlMes.Controls.Add(Me.dtMes)
        Me.pnlMes.Location = New System.Drawing.Point(671, 363)
        Me.pnlMes.Name = "pnlMes"
        Me.pnlMes.Size = New System.Drawing.Size(234, 166)
        Me.pnlMes.TabIndex = 8
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
        Me.btnClose.TabIndex = 3
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(54, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 19)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Situação"
        '
        'cmbSituacao
        '
        Me.cmbSituacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSituacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSituacao.FormattingEnabled = True
        Me.cmbSituacao.Location = New System.Drawing.Point(124, 101)
        Me.cmbSituacao.Name = "cmbSituacao"
        Me.cmbSituacao.RestrictContentToListItems = True
        Me.cmbSituacao.Size = New System.Drawing.Size(170, 27)
        Me.cmbSituacao.TabIndex = 5
        '
        'btnQuitar
        '
        Me.btnQuitar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnQuitar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray
        Me.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnQuitar.Location = New System.Drawing.Point(161, 9)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(143, 41)
        Me.btnQuitar.TabIndex = 1
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuitar.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label18.Location = New System.Drawing.Point(65, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Filial:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(16, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(145, 30)
        Me.lblFilial.TabIndex = 0
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.rbtAPagar)
        Me.Panel3.Controls.Add(Me.rbtAReceber)
        Me.Panel3.Location = New System.Drawing.Point(386, 71)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(221, 55)
        Me.Panel3.TabIndex = 6
        '
        'rbtAPagar
        '
        Me.rbtAPagar.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtAPagar.BackColor = System.Drawing.Color.Gainsboro
        Me.rbtAPagar.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtAPagar.FlatAppearance.BorderSize = 0
        Me.rbtAPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.rbtAPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.rbtAPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtAPagar.Location = New System.Drawing.Point(6, 6)
        Me.rbtAPagar.Name = "rbtAPagar"
        Me.rbtAPagar.Size = New System.Drawing.Size(101, 42)
        Me.rbtAPagar.TabIndex = 0
        Me.rbtAPagar.TabStop = True
        Me.rbtAPagar.Text = "A Pagar"
        Me.rbtAPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtAPagar.UseVisualStyleBackColor = False
        '
        'rbtAReceber
        '
        Me.rbtAReceber.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtAReceber.BackColor = System.Drawing.Color.SlateGray
        Me.rbtAReceber.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rbtAReceber.FlatAppearance.BorderSize = 0
        Me.rbtAReceber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.rbtAReceber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.rbtAReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtAReceber.ForeColor = System.Drawing.Color.White
        Me.rbtAReceber.Location = New System.Drawing.Point(113, 6)
        Me.rbtAReceber.Name = "rbtAReceber"
        Me.rbtAReceber.Size = New System.Drawing.Size(101, 42)
        Me.rbtAReceber.TabIndex = 1
        Me.rbtAReceber.TabStop = True
        Me.rbtAReceber.Text = "A Receber"
        Me.rbtAReceber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtAReceber.UseVisualStyleBackColor = False
        '
        'btnProcurarFilial
        '
        Me.btnProcurarFilial.AllowAnimations = True
        Me.btnProcurarFilial.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurarFilial.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcurarFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcurarFilial.Location = New System.Drawing.Point(338, 68)
        Me.btnProcurarFilial.Name = "btnProcurarFilial"
        Me.btnProcurarFilial.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurarFilial.RoundedCornersRadius = 0
        Me.btnProcurarFilial.Size = New System.Drawing.Size(34, 27)
        Me.btnProcurarFilial.TabIndex = 3
        Me.btnProcurarFilial.TabStop = False
        Me.btnProcurarFilial.Text = "..."
        Me.btnProcurarFilial.UseCompatibleTextRendering = True
        Me.btnProcurarFilial.UseVisualStyleBackColor = False
        Me.btnProcurarFilial.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
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
        Me.VPanel1.Content.Controls.Add(Me.lblTotal)
        Me.VPanel1.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel1.Content.Name = "Content"
        Me.VPanel1.Content.Size = New System.Drawing.Size(144, 37)
        Me.VPanel1.Content.TabIndex = 3
        Me.VPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel1.Location = New System.Drawing.Point(174, 554)
        Me.VPanel1.Name = "VPanel1"
        Me.VPanel1.Opacity = 1.0!
        Me.VPanel1.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel1.Size = New System.Drawing.Size(146, 39)
        Me.VPanel1.TabIndex = 15
        Me.VPanel1.Text = "VPanel1"
        Me.VPanel1.UsePanelBorderColor = True
        Me.VPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblTotal
        '
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotal.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.Location = New System.Drawing.Point(0, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(144, 37)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "R$ 0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblT1
        '
        Me.lblT1.Location = New System.Drawing.Point(49, 559)
        Me.lblT1.Name = "lblT1"
        Me.lblT1.Size = New System.Drawing.Size(119, 27)
        Me.lblT1.TabIndex = 11
        Me.lblT1.Text = "A Pagar Total:"
        Me.lblT1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblT2
        '
        Me.lblT2.Location = New System.Drawing.Point(325, 559)
        Me.lblT2.Name = "lblT2"
        Me.lblT2.Size = New System.Drawing.Size(76, 27)
        Me.lblT2.TabIndex = 12
        Me.lblT2.Text = "Pago:"
        Me.lblT2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.VPanel2.Content.Controls.Add(Me.lblPago)
        Me.VPanel2.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel2.Content.Name = "Content"
        Me.VPanel2.Content.Size = New System.Drawing.Size(144, 37)
        Me.VPanel2.Content.TabIndex = 3
        Me.VPanel2.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel2.Location = New System.Drawing.Point(407, 554)
        Me.VPanel2.Name = "VPanel2"
        Me.VPanel2.Opacity = 1.0!
        Me.VPanel2.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel2.Size = New System.Drawing.Size(146, 39)
        Me.VPanel2.TabIndex = 15
        Me.VPanel2.Text = "VPanel1"
        Me.VPanel2.UsePanelBorderColor = True
        Me.VPanel2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblPago
        '
        Me.lblPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPago.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblPago.Location = New System.Drawing.Point(0, 0)
        Me.lblPago.Name = "lblPago"
        Me.lblPago.Size = New System.Drawing.Size(144, 37)
        Me.lblPago.TabIndex = 0
        Me.lblPago.Text = "R$ 0,00"
        Me.lblPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblT3
        '
        Me.lblT3.Location = New System.Drawing.Point(564, 559)
        Me.lblT3.Name = "lblT3"
        Me.lblT3.Size = New System.Drawing.Size(80, 27)
        Me.lblT3.TabIndex = 13
        Me.lblT3.Text = "Em Aberto:"
        Me.lblT3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VPanel3
        '
        Me.VPanel3.AllowAnimations = True
        Me.VPanel3.BorderRadius = 0
        '
        'VPanel3.Content
        '
        Me.VPanel3.Content.AutoScroll = True
        Me.VPanel3.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel3.Content.Controls.Add(Me.lblEmAberto)
        Me.VPanel3.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel3.Content.Name = "Content"
        Me.VPanel3.Content.Size = New System.Drawing.Size(144, 37)
        Me.VPanel3.Content.TabIndex = 3
        Me.VPanel3.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel3.Location = New System.Drawing.Point(649, 554)
        Me.VPanel3.Name = "VPanel3"
        Me.VPanel3.Opacity = 1.0!
        Me.VPanel3.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel3.Size = New System.Drawing.Size(146, 39)
        Me.VPanel3.TabIndex = 15
        Me.VPanel3.Text = "VPanel1"
        Me.VPanel3.UsePanelBorderColor = True
        Me.VPanel3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblEmAberto
        '
        Me.lblEmAberto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEmAberto.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblEmAberto.Location = New System.Drawing.Point(0, 0)
        Me.lblEmAberto.Name = "lblEmAberto"
        Me.lblEmAberto.Size = New System.Drawing.Size(144, 37)
        Me.lblEmAberto.TabIndex = 0
        Me.lblEmAberto.Text = "R$ 0,00"
        Me.lblEmAberto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.btnEditar)
        Me.Panel4.Controls.Add(Me.btnCancelar)
        Me.Panel4.Controls.Add(Me.btnQuitar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 608)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(941, 59)
        Me.Panel4.TabIndex = 14
        '
        'frmAPagarReceberSimples
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(941, 667)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.VPanel3)
        Me.Controls.Add(Me.lblT3)
        Me.Controls.Add(Me.VPanel2)
        Me.Controls.Add(Me.lblT2)
        Me.Controls.Add(Me.VPanel1)
        Me.Controls.Add(Me.lblT1)
        Me.Controls.Add(Me.btnProcurarFilial)
        Me.Controls.Add(Me.cmbSituacao)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.pnlMes)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFilialDestino)
        Me.Name = "frmAPagarReceberSimples"
        Me.Text = "Procurar Saída de Produto"
        Me.Controls.SetChildIndex(Me.txtFilialDestino, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.pnlHeader, 0)
        Me.Controls.SetChildIndex(Me.pnlMes, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.cmbSituacao, 0)
        Me.Controls.SetChildIndex(Me.btnProcurarFilial, 0)
        Me.Controls.SetChildIndex(Me.lblT1, 0)
        Me.Controls.SetChildIndex(Me.VPanel1, 0)
        Me.Controls.SetChildIndex(Me.lblT2, 0)
        Me.Controls.SetChildIndex(Me.VPanel2, 0)
        Me.Controls.SetChildIndex(Me.lblT3, 0)
        Me.Controls.SetChildIndex(Me.VPanel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMes.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.VPanel1.Content.ResumeLayout(False)
        Me.VPanel1.ResumeLayout(False)
        Me.VPanel2.Content.ResumeLayout(False)
        Me.VPanel2.ResumeLayout(False)
        Me.VPanel3.Content.ResumeLayout(False)
        Me.VPanel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilialDestino As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkPeriodoTodos As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents btnPeriodoAnterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents btnPeriodoPosterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lbl1 As Label
    Friend WithEvents lbl0 As Label
    Friend WithEvents lbl2 As Label
    Friend WithEvents lbl3 As Label
    Friend WithEvents btnMesAtual As VIBlend.WinForms.Controls.vButton
    Friend WithEvents pnlMes As Panel
    Friend WithEvents dtMes As MonthCalendar
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents txtDespesaTipo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbSituacao As Controles.ComboBox_OnlyValues
    Friend WithEvents btnQuitar As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rbtAPagar As RadioButton
    Friend WithEvents rbtAReceber As RadioButton
    Friend WithEvents btnProcurarFilial As VIBlend.WinForms.Controls.vButton
    Friend WithEvents lbl4 As Label
    Friend WithEvents clnVencimento As DataGridViewTextBoxColumn
    Friend WithEvents clnFilial As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents clnPago As DataGridViewTextBoxColumn
    Friend WithEvents clnSituacao As DataGridViewTextBoxColumn
    Friend WithEvents VPanel1 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblT1 As Label
    Friend WithEvents lblT2 As Label
    Friend WithEvents VPanel2 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblPago As Label
    Friend WithEvents lblT3 As Label
    Friend WithEvents VPanel3 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblEmAberto As Label
    Friend WithEvents Panel4 As Panel
End Class
