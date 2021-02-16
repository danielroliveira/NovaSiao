<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCaixa
    Inherits NovaSiao.frmModFinBorder

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
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.dgvListagem = New System.Windows.Forms.DataGridView()
		Me.clnMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnMovData = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnMovForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvSaldos = New System.Windows.Forms.DataGridView()
		Me.clnTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnSaldoAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnSaldoFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnTransferir = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.lblDataInicial = New System.Windows.Forms.Label()
		Me.lblDataFinal = New System.Windows.Forms.Label()
		Me.lblConta = New System.Windows.Forms.Label()
		Me.lblApelidoFilial = New System.Windows.Forms.Label()
		Me.lblIDProduto = New System.Windows.Forms.Label()
		Me.lbl_IdTexto = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.lblSituacao = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.lblTEntradas = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.lblTSaidas = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.lblSaldoAnterior = New System.Windows.Forms.Label()
		Me.lblSaldoFinal = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.btnAlterar = New System.Windows.Forms.Button()
		Me.btnFinalizar = New System.Windows.Forms.Button()
		Me.btnFechar = New System.Windows.Forms.Button()
		Me.MenuSaldos = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.miInserirNivelamento = New System.Windows.Forms.ToolStripMenuItem()
		Me.miExcluirNivelamento = New System.Windows.Forms.ToolStripMenuItem()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.txtObservacao = New System.Windows.Forms.TextBox()
		Me.btnExcluirCaixa = New System.Windows.Forms.Button()
		Me.btnSalvarObservacao = New System.Windows.Forms.Button()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.lblTTransf = New System.Windows.Forms.Label()
		Me.lblApelidoFuncionario = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.btnFuncionarioAlterar = New System.Windows.Forms.Button()
		Me.mnuInserir = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.miInserirEntrada = New System.Windows.Forms.ToolStripMenuItem()
		Me.miInserirDespesas = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.miExcluirEntrada = New System.Windows.Forms.ToolStripMenuItem()
		Me.miExcluirNivelamentoLista = New System.Windows.Forms.ToolStripMenuItem()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.Panel1.SuspendLayout()
		CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MenuSaldos.SuspendLayout()
		Me.mnuInserir.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.lblIDProduto)
		Me.Panel1.Controls.Add(Me.Label6)
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.lbl_IdTexto)
		Me.Panel1.Controls.Add(Me.lblSituacao)
		Me.Panel1.Controls.Add(Me.lblApelidoFilial)
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Size = New System.Drawing.Size(1134, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblApelidoFilial, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label1, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label6, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblIDProduto, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(873, 0)
		Me.lblTitulo.Size = New System.Drawing.Size(261, 50)
		Me.lblTitulo.TabIndex = 6
		Me.lblTitulo.Text = "Fechamento de Caixa"
		Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'dgvListagem
		'
		Me.dgvListagem.AllowUserToAddRows = False
		Me.dgvListagem.AllowUserToDeleteRows = False
		Me.dgvListagem.AllowUserToResizeColumns = False
		Me.dgvListagem.AllowUserToResizeRows = False
		Me.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvListagem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvListagem.ColumnHeadersHeight = 27
		Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnMov, Me.clnMovData, Me.clnDescricao, Me.clnMovForma, Me.clnValor})
		Me.dgvListagem.EnableHeadersVisualStyles = False
		Me.dgvListagem.Location = New System.Drawing.Point(14, 111)
		Me.dgvListagem.MultiSelect = False
		Me.dgvListagem.Name = "dgvListagem"
		Me.dgvListagem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvListagem.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.dgvListagem.RowHeadersWidth = 36
		Me.dgvListagem.RowTemplate.Height = 30
		Me.dgvListagem.Size = New System.Drawing.Size(910, 318)
		Me.dgvListagem.TabIndex = 10
		'
		'clnMov
		'
		Me.clnMov.HeaderText = ""
		Me.clnMov.Name = "clnMov"
		Me.clnMov.ReadOnly = True
		Me.clnMov.Width = 40
		'
		'clnMovData
		'
		Me.clnMovData.HeaderText = "Data"
		Me.clnMovData.Name = "clnMovData"
		Me.clnMovData.ReadOnly = True
		'
		'clnDescricao
		'
		Me.clnDescricao.HeaderText = "Descrição"
		Me.clnDescricao.Name = "clnDescricao"
		Me.clnDescricao.ReadOnly = True
		Me.clnDescricao.Width = 400
		'
		'clnMovForma
		'
		Me.clnMovForma.HeaderText = "Forma"
		Me.clnMovForma.Name = "clnMovForma"
		Me.clnMovForma.ReadOnly = True
		Me.clnMovForma.Width = 200
		'
		'clnValor
		'
		Me.clnValor.HeaderText = "Valor"
		Me.clnValor.Name = "clnValor"
		Me.clnValor.ReadOnly = True
		'
		'dgvSaldos
		'
		Me.dgvSaldos.AllowUserToAddRows = False
		Me.dgvSaldos.AllowUserToDeleteRows = False
		Me.dgvSaldos.AllowUserToResizeRows = False
		Me.dgvSaldos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvSaldos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
		Me.dgvSaldos.ColumnHeadersHeight = 27
		Me.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dgvSaldos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnTipo, Me.clnSaldoAnterior, Me.clnSaldoFinal, Me.clnTransferir})
		DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvSaldos.DefaultCellStyle = DataGridViewCellStyle7
		Me.dgvSaldos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.dgvSaldos.EnableHeadersVisualStyles = False
		Me.dgvSaldos.Location = New System.Drawing.Point(14, 446)
		Me.dgvSaldos.MultiSelect = False
		Me.dgvSaldos.Name = "dgvSaldos"
		Me.dgvSaldos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
		DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray
		DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvSaldos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
		Me.dgvSaldos.RowHeadersWidth = 36
		Me.dgvSaldos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvSaldos.RowTemplate.Height = 30
		Me.dgvSaldos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvSaldos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvSaldos.Size = New System.Drawing.Size(546, 140)
		Me.dgvSaldos.TabIndex = 11
		'
		'clnTipo
		'
		Me.clnTipo.HeaderText = "Mov. Tipo"
		Me.clnTipo.Name = "clnTipo"
		Me.clnTipo.ReadOnly = True
		Me.clnTipo.Width = 140
		'
		'clnSaldoAnterior
		'
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
		Me.clnSaldoAnterior.DefaultCellStyle = DataGridViewCellStyle4
		Me.clnSaldoAnterior.HeaderText = "Sd Anterior"
		Me.clnSaldoAnterior.Name = "clnSaldoAnterior"
		Me.clnSaldoAnterior.ReadOnly = True
		'
		'clnSaldoFinal
		'
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
		Me.clnSaldoFinal.DefaultCellStyle = DataGridViewCellStyle5
		Me.clnSaldoFinal.HeaderText = "Sd Final"
		Me.clnSaldoFinal.Name = "clnSaldoFinal"
		Me.clnSaldoFinal.ReadOnly = True
		'
		'clnTransferir
		'
		DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
		Me.clnTransferir.DefaultCellStyle = DataGridViewCellStyle6
		Me.clnTransferir.HeaderText = "Auto Transf."
		Me.clnTransferir.Name = "clnTransferir"
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.CausesValidation = False
		Me.btnClose.Location = New System.Drawing.Point(1105, 13)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RibbonStyle = False
		Me.btnClose.RoundedCornersMask = CType(15, Byte)
		Me.btnClose.ShowFocusRectangle = False
		Me.btnClose.Size = New System.Drawing.Size(19, 20)
		Me.btnClose.TabIndex = 7
		Me.btnClose.TabStop = False
		Me.btnClose.UseVisualStyleBackColor = False
		Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
		'
		'lblDataInicial
		'
		Me.lblDataInicial.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDataInicial.Location = New System.Drawing.Point(14, 73)
		Me.lblDataInicial.Name = "lblDataInicial"
		Me.lblDataInicial.Size = New System.Drawing.Size(120, 31)
		Me.lblDataInicial.TabIndex = 2
		Me.lblDataInicial.Text = "00/00/0000"
		Me.lblDataInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblDataFinal
		'
		Me.lblDataFinal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDataFinal.Location = New System.Drawing.Point(140, 73)
		Me.lblDataFinal.Name = "lblDataFinal"
		Me.lblDataFinal.Size = New System.Drawing.Size(120, 31)
		Me.lblDataFinal.TabIndex = 4
		Me.lblDataFinal.Text = "00/00/0000"
		Me.lblDataFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblConta
		'
		Me.lblConta.BackColor = System.Drawing.Color.Transparent
		Me.lblConta.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblConta.ForeColor = System.Drawing.Color.Black
		Me.lblConta.Location = New System.Drawing.Point(266, 75)
		Me.lblConta.Name = "lblConta"
		Me.lblConta.Size = New System.Drawing.Size(258, 27)
		Me.lblConta.TabIndex = 6
		Me.lblConta.Text = "Conta"
		Me.lblConta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblApelidoFilial
		'
		Me.lblApelidoFilial.BackColor = System.Drawing.Color.Transparent
		Me.lblApelidoFilial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblApelidoFilial.ForeColor = System.Drawing.Color.White
		Me.lblApelidoFilial.Location = New System.Drawing.Point(110, 22)
		Me.lblApelidoFilial.Name = "lblApelidoFilial"
		Me.lblApelidoFilial.Size = New System.Drawing.Size(245, 23)
		Me.lblApelidoFilial.TabIndex = 2
		Me.lblApelidoFilial.Text = "Filial"
		Me.lblApelidoFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblIDProduto
		'
		Me.lblIDProduto.BackColor = System.Drawing.Color.Transparent
		Me.lblIDProduto.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIDProduto.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblIDProduto.Location = New System.Drawing.Point(9, 17)
		Me.lblIDProduto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblIDProduto.Name = "lblIDProduto"
		Me.lblIDProduto.Size = New System.Drawing.Size(94, 30)
		Me.lblIDProduto.TabIndex = 0
		Me.lblIDProduto.Text = "0001"
		Me.lblIDProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lbl_IdTexto
		'
		Me.lbl_IdTexto.AutoSize = True
		Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
		Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver
		Me.lbl_IdTexto.Location = New System.Drawing.Point(40, 4)
		Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.lbl_IdTexto.Name = "lbl_IdTexto"
		Me.lbl_IdTexto.Size = New System.Drawing.Size(23, 13)
		Me.lbl_IdTexto.TabIndex = 1
		Me.lbl_IdTexto.Text = "id."
		Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Silver
		Me.Label1.Location = New System.Drawing.Point(211, 4)
		Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(39, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Filial"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Location = New System.Drawing.Point(371, 58)
		Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(51, 19)
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "Conta:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(14, 58)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(87, 19)
		Me.Label3.TabIndex = 1
		Me.Label3.Text = "Data Inicial:"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(140, 58)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(79, 19)
		Me.Label4.TabIndex = 3
		Me.Label4.Text = "Data Final:"
		'
		'lblSituacao
		'
		Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
		Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSituacao.ForeColor = System.Drawing.Color.White
		Me.lblSituacao.Location = New System.Drawing.Point(357, 22)
		Me.lblSituacao.Name = "lblSituacao"
		Me.lblSituacao.Size = New System.Drawing.Size(186, 23)
		Me.lblSituacao.TabIndex = 4
		Me.lblSituacao.Text = "Em Aberto"
		Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Silver
		Me.Label6.Location = New System.Drawing.Point(417, 4)
		Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(63, 13)
		Me.Label6.TabIndex = 5
		Me.Label6.Text = "Situação"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Label5
		'
		Me.Label5.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(679, 475)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(85, 24)
		Me.Label5.TabIndex = 14
		Me.Label5.Text = "Entradas:"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblTEntradas
		'
		Me.lblTEntradas.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTEntradas.ForeColor = System.Drawing.Color.DarkBlue
		Me.lblTEntradas.Location = New System.Drawing.Point(766, 475)
		Me.lblTEntradas.Name = "lblTEntradas"
		Me.lblTEntradas.Size = New System.Drawing.Size(121, 24)
		Me.lblTEntradas.TabIndex = 15
		Me.lblTEntradas.Text = "R$ 0,00"
		Me.lblTEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label7
		'
		Me.Label7.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(679, 504)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(85, 24)
		Me.Label7.TabIndex = 16
		Me.Label7.Text = "Saídas:"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblTSaidas
		'
		Me.lblTSaidas.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTSaidas.ForeColor = System.Drawing.Color.DarkRed
		Me.lblTSaidas.Location = New System.Drawing.Point(766, 504)
		Me.lblTSaidas.Name = "lblTSaidas"
		Me.lblTSaidas.Size = New System.Drawing.Size(121, 24)
		Me.lblTSaidas.TabIndex = 17
		Me.lblTSaidas.Text = "R$ 0,00"
		Me.lblTSaidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label8
		'
		Me.Label8.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.Location = New System.Drawing.Point(626, 446)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(138, 24)
		Me.Label8.TabIndex = 12
		Me.Label8.Text = "Saldo Anterior:"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblSaldoAnterior
		'
		Me.lblSaldoAnterior.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSaldoAnterior.Location = New System.Drawing.Point(766, 446)
		Me.lblSaldoAnterior.Name = "lblSaldoAnterior"
		Me.lblSaldoAnterior.Size = New System.Drawing.Size(121, 24)
		Me.lblSaldoAnterior.TabIndex = 13
		Me.lblSaldoAnterior.Text = "R$ 0,00"
		Me.lblSaldoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblSaldoFinal
		'
		Me.lblSaldoFinal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSaldoFinal.Location = New System.Drawing.Point(766, 562)
		Me.lblSaldoFinal.Name = "lblSaldoFinal"
		Me.lblSaldoFinal.Size = New System.Drawing.Size(121, 24)
		Me.lblSaldoFinal.TabIndex = 21
		Me.lblSaldoFinal.Text = "R$ 0,00"
		Me.lblSaldoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label10
		'
		Me.Label10.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.Location = New System.Drawing.Point(626, 562)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(138, 24)
		Me.Label10.TabIndex = 20
		Me.Label10.Text = "Saldo Final Total:"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnAlterar
		'
		Me.btnAlterar.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.btnAlterar.BackColor = System.Drawing.Color.Honeydew
		Me.btnAlterar.FlatAppearance.BorderSize = 0
		Me.btnAlterar.Image = Global.NovaSiao.My.Resources.Resources.refresh1
		Me.btnAlterar.Location = New System.Drawing.Point(14, 294)
		Me.btnAlterar.Name = "btnAlterar"
		Me.btnAlterar.Size = New System.Drawing.Size(159, 45)
		Me.btnAlterar.TabIndex = 3
		Me.btnAlterar.Text = "&Alterar Período"
		Me.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnAlterar.UseVisualStyleBackColor = False
		'
		'btnFinalizar
		'
		Me.btnFinalizar.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.btnFinalizar.BackColor = System.Drawing.Color.AliceBlue
		Me.btnFinalizar.FlatAppearance.BorderSize = 0
		Me.btnFinalizar.Image = Global.NovaSiao.My.Resources.Resources.accept
		Me.btnFinalizar.Location = New System.Drawing.Point(14, 396)
		Me.btnFinalizar.Name = "btnFinalizar"
		Me.btnFinalizar.Size = New System.Drawing.Size(159, 63)
		Me.btnFinalizar.TabIndex = 5
		Me.btnFinalizar.Text = "Finalizar &Caixa"
		Me.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnFinalizar.UseVisualStyleBackColor = False
		'
		'btnFechar
		'
		Me.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.btnFechar.BackColor = System.Drawing.SystemColors.ButtonFace
		Me.btnFechar.FlatAppearance.BorderSize = 0
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
		Me.btnFechar.Location = New System.Drawing.Point(14, 491)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(159, 45)
		Me.btnFechar.TabIndex = 6
		Me.btnFechar.Text = "&Fechar"
		Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnFechar.UseVisualStyleBackColor = False
		'
		'MenuSaldos
		'
		Me.MenuSaldos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MenuSaldos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miInserirNivelamento, Me.miExcluirNivelamento})
		Me.MenuSaldos.Name = "MenuFab"
		Me.MenuSaldos.Size = New System.Drawing.Size(202, 48)
		'
		'miInserirNivelamento
		'
		Me.miInserirNivelamento.Image = Global.NovaSiao.My.Resources.Resources.add
		Me.miInserirNivelamento.Name = "miInserirNivelamento"
		Me.miInserirNivelamento.Size = New System.Drawing.Size(201, 22)
		Me.miInserirNivelamento.Text = "Inserir Nivelamento"
		'
		'miExcluirNivelamento
		'
		Me.miExcluirNivelamento.Image = Global.NovaSiao.My.Resources.Resources.delete
		Me.miExcluirNivelamento.Name = "miExcluirNivelamento"
		Me.miExcluirNivelamento.Size = New System.Drawing.Size(201, 22)
		Me.miExcluirNivelamento.Text = "Excluir Nivelamento"
		'
		'Label9
		'
		Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(48, 38)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(90, 19)
		Me.Label9.TabIndex = 0
		Me.Label9.Text = "Observação:"
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'txtObservacao
		'
		Me.txtObservacao.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.txtObservacao.BackColor = System.Drawing.SystemColors.Control
		Me.txtObservacao.Location = New System.Drawing.Point(14, 61)
		Me.txtObservacao.Multiline = True
		Me.txtObservacao.Name = "txtObservacao"
		Me.txtObservacao.Size = New System.Drawing.Size(159, 197)
		Me.txtObservacao.TabIndex = 1
		Me.txtObservacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'btnExcluirCaixa
		'
		Me.btnExcluirCaixa.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.btnExcluirCaixa.BackColor = System.Drawing.Color.MistyRose
		Me.btnExcluirCaixa.FlatAppearance.BorderSize = 0
		Me.btnExcluirCaixa.Image = Global.NovaSiao.My.Resources.Resources.delete_24px
		Me.btnExcluirCaixa.Location = New System.Drawing.Point(14, 345)
		Me.btnExcluirCaixa.Name = "btnExcluirCaixa"
		Me.btnExcluirCaixa.Size = New System.Drawing.Size(159, 45)
		Me.btnExcluirCaixa.TabIndex = 4
		Me.btnExcluirCaixa.Text = "&Excluir Caixa"
		Me.btnExcluirCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnExcluirCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnExcluirCaixa.UseVisualStyleBackColor = False
		'
		'btnSalvarObservacao
		'
		Me.btnSalvarObservacao.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.btnSalvarObservacao.Location = New System.Drawing.Point(52, 220)
		Me.btnSalvarObservacao.Name = "btnSalvarObservacao"
		Me.btnSalvarObservacao.Size = New System.Drawing.Size(86, 27)
		Me.btnSalvarObservacao.TabIndex = 2
		Me.btnSalvarObservacao.Text = "Salvar"
		Me.btnSalvarObservacao.UseVisualStyleBackColor = True
		Me.btnSalvarObservacao.Visible = False
		'
		'Label11
		'
		Me.Label11.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.Location = New System.Drawing.Point(626, 533)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(138, 24)
		Me.Label11.TabIndex = 18
		Me.Label11.Text = "Transferências:"
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblTTransf
		'
		Me.lblTTransf.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTTransf.Location = New System.Drawing.Point(766, 533)
		Me.lblTTransf.Name = "lblTTransf"
		Me.lblTTransf.Size = New System.Drawing.Size(121, 24)
		Me.lblTTransf.TabIndex = 19
		Me.lblTTransf.Text = "R$ 0,00"
		Me.lblTTransf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblApelidoFuncionario
		'
		Me.lblApelidoFuncionario.BackColor = System.Drawing.Color.White
		Me.lblApelidoFuncionario.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblApelidoFuncionario.Location = New System.Drawing.Point(535, 74)
		Me.lblApelidoFuncionario.Name = "lblApelidoFuncionario"
		Me.lblApelidoFuncionario.Size = New System.Drawing.Size(229, 28)
		Me.lblApelidoFuncionario.TabIndex = 8
		Me.lblApelidoFuncionario.Text = "Funcionário"
		Me.lblApelidoFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label13.Location = New System.Drawing.Point(536, 57)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(110, 14)
		Me.Label13.TabIndex = 7
		Me.Label13.Text = "Operador de Caixa:"
		'
		'btnFuncionarioAlterar
		'
		Me.btnFuncionarioAlterar.BackgroundImage = Global.NovaSiao.My.Resources.Resources.refresh
		Me.btnFuncionarioAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnFuncionarioAlterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnFuncionarioAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnFuncionarioAlterar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFuncionarioAlterar.Location = New System.Drawing.Point(770, 74)
		Me.btnFuncionarioAlterar.Name = "btnFuncionarioAlterar"
		Me.btnFuncionarioAlterar.Size = New System.Drawing.Size(28, 28)
		Me.btnFuncionarioAlterar.TabIndex = 9
		Me.btnFuncionarioAlterar.TabStop = False
		Me.btnFuncionarioAlterar.UseVisualStyleBackColor = True
		'
		'mnuInserir
		'
		Me.mnuInserir.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mnuInserir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miInserirEntrada, Me.miInserirDespesas, Me.ToolStripSeparator1, Me.miExcluirEntrada, Me.miExcluirNivelamentoLista})
		Me.mnuInserir.Name = "mnuInserir"
		Me.mnuInserir.Size = New System.Drawing.Size(208, 106)
		'
		'miInserirEntrada
		'
		Me.miInserirEntrada.Image = Global.NovaSiao.My.Resources.Resources.AReceber_30px
		Me.miInserirEntrada.Name = "miInserirEntrada"
		Me.miInserirEntrada.Size = New System.Drawing.Size(207, 24)
		Me.miInserirEntrada.Text = "Inserir Entrada"
		Me.miInserirEntrada.ToolTipText = "Insere uma nova Entrada"
		'
		'miInserirDespesas
		'
		Me.miInserirDespesas.Image = Global.NovaSiao.My.Resources.Resources.APagar_30px
		Me.miInserirDespesas.Name = "miInserirDespesas"
		Me.miInserirDespesas.Size = New System.Drawing.Size(207, 24)
		Me.miInserirDespesas.Text = "Inserir Despesa"
		Me.miInserirDespesas.ToolTipText = "Insere uma nova Despesa"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(204, 6)
		'
		'miExcluirEntrada
		'
		Me.miExcluirEntrada.Image = Global.NovaSiao.My.Resources.Resources.delete
		Me.miExcluirEntrada.Name = "miExcluirEntrada"
		Me.miExcluirEntrada.Size = New System.Drawing.Size(207, 24)
		Me.miExcluirEntrada.Text = "Excluir Entrada"
		'
		'miExcluirNivelamentoLista
		'
		Me.miExcluirNivelamentoLista.Image = Global.NovaSiao.My.Resources.Resources.delete
		Me.miExcluirNivelamentoLista.Name = "miExcluirNivelamentoLista"
		Me.miExcluirNivelamentoLista.Size = New System.Drawing.Size(207, 24)
		Me.miExcluirNivelamentoLista.Text = "Excluir Nivelamento"
		'
		'Panel2
		'
		Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
		Me.Panel2.Controls.Add(Me.btnSalvarObservacao)
		Me.Panel2.Controls.Add(Me.btnExcluirCaixa)
		Me.Panel2.Controls.Add(Me.txtObservacao)
		Me.Panel2.Controls.Add(Me.Label9)
		Me.Panel2.Controls.Add(Me.btnFechar)
		Me.Panel2.Controls.Add(Me.btnFinalizar)
		Me.Panel2.Controls.Add(Me.btnAlterar)
		Me.Panel2.Location = New System.Drawing.Point(941, 50)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(191, 547)
		Me.Panel2.TabIndex = 22
		'
		'frmCaixa
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1134, 599)
		Me.Controls.Add(Me.btnFuncionarioAlterar)
		Me.Controls.Add(Me.lblApelidoFuncionario)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.lblTTransf)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.lblSaldoFinal)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.lblTSaidas)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.lblSaldoAnterior)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.lblTEntradas)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.lblDataFinal)
		Me.Controls.Add(Me.lblDataInicial)
		Me.Controls.Add(Me.dgvSaldos)
		Me.Controls.Add(Me.dgvListagem)
		Me.Controls.Add(Me.lblConta)
		Me.Controls.Add(Me.Panel2)
		Me.Name = "frmCaixa"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.lblConta, 0)
		Me.Controls.SetChildIndex(Me.dgvListagem, 0)
		Me.Controls.SetChildIndex(Me.dgvSaldos, 0)
		Me.Controls.SetChildIndex(Me.lblDataInicial, 0)
		Me.Controls.SetChildIndex(Me.lblDataFinal, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.Label5, 0)
		Me.Controls.SetChildIndex(Me.lblTEntradas, 0)
		Me.Controls.SetChildIndex(Me.Label8, 0)
		Me.Controls.SetChildIndex(Me.lblSaldoAnterior, 0)
		Me.Controls.SetChildIndex(Me.Label7, 0)
		Me.Controls.SetChildIndex(Me.lblTSaidas, 0)
		Me.Controls.SetChildIndex(Me.Label10, 0)
		Me.Controls.SetChildIndex(Me.lblSaldoFinal, 0)
		Me.Controls.SetChildIndex(Me.Label11, 0)
		Me.Controls.SetChildIndex(Me.lblTTransf, 0)
		Me.Controls.SetChildIndex(Me.Label13, 0)
		Me.Controls.SetChildIndex(Me.lblApelidoFuncionario, 0)
		Me.Controls.SetChildIndex(Me.btnFuncionarioAlterar, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MenuSaldos.ResumeLayout(False)
		Me.mnuInserir.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.Panel2.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents dgvSaldos As DataGridView
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents lblDataInicial As Label
    Friend WithEvents lblDataFinal As Label
    Friend WithEvents lblApelidoFilial As Label
    Friend WithEvents lblConta As Label
    Friend WithEvents lblIDProduto As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSituacao As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTEntradas As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTSaidas As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblSaldoAnterior As Label
    Friend WithEvents lblSaldoFinal As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnAlterar As Button
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents clnSaldo As DataGridViewTextBoxColumn
    Friend WithEvents MenuSaldos As ContextMenuStrip
    Friend WithEvents miInserirNivelamento As ToolStripMenuItem
    Friend WithEvents miExcluirNivelamento As ToolStripMenuItem
    Friend WithEvents Label9 As Label
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents btnExcluirCaixa As Button
    Friend WithEvents btnSalvarObservacao As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents lblTTransf As Label
    Friend WithEvents lblApelidoFuncionario As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnFuncionarioAlterar As Button
    Friend WithEvents clnMov As DataGridViewTextBoxColumn
    Friend WithEvents clnMovData As DataGridViewTextBoxColumn
    Friend WithEvents clnDescricao As DataGridViewTextBoxColumn
    Friend WithEvents clnMovForma As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents clnTipo As DataGridViewTextBoxColumn
    Friend WithEvents clnSaldoAnterior As DataGridViewTextBoxColumn
    Friend WithEvents clnSaldoFinal As DataGridViewTextBoxColumn
    Friend WithEvents clnTransferir As DataGridViewTextBoxColumn
    Friend WithEvents mnuInserir As ContextMenuStrip
    Friend WithEvents miInserirEntrada As ToolStripMenuItem
    Friend WithEvents miInserirDespesas As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miExcluirEntrada As ToolStripMenuItem
    Friend WithEvents miExcluirNivelamentoLista As ToolStripMenuItem
End Class
