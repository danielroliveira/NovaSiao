<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespesaPeriodica
    Inherits NovaSiao.frmModFinBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.lblCNPTexto = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.lblCNP = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCredor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTipo = New VIBlend.WinForms.Controls.vButton()
        Me.btnCredor = New VIBlend.WinForms.Controls.vButton()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.txtDespesaTipo = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnNova = New System.Windows.Forms.Button()
        Me.btnProcurar = New System.Windows.Forms.Button()
        Me.eProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbDiaVencimento = New Controles.ComboBox_OnlyValues()
        Me.txtDespesaValor = New Controles.Text_Monetario()
        Me.txtIniciarData = New Controles.MaskText_Data()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPeriodicidade = New System.Windows.Forms.Panel()
        Me.rbtAnual = New System.Windows.Forms.RadioButton()
        Me.rbtMensal = New System.Windows.Forms.RadioButton()
        Me.rbtSemanal = New System.Windows.Forms.RadioButton()
        Me.cmbRGBanco = New Controles.ComboBox_OnlyValues()
        Me.cmbIDCobrancaForma = New Controles.ComboBox_OnlyValues()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbMesVencimento = New Controles.ComboBox_OnlyValues()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.eProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPeriodicidade.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(594, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(390, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(204, 50)
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Text = "Despesa Periódica"
        '
        'lblCNPTexto
        '
        Me.lblCNPTexto.AutoSize = True
        Me.lblCNPTexto.BackColor = System.Drawing.Color.Transparent
        Me.lblCNPTexto.ForeColor = System.Drawing.Color.Black
        Me.lblCNPTexto.Location = New System.Drawing.Point(115, 105)
        Me.lblCNPTexto.Name = "lblCNPTexto"
        Me.lblCNPTexto.Size = New System.Drawing.Size(40, 19)
        Me.lblCNPTexto.TabIndex = 4
        Me.lblCNPTexto.Text = "CNPJ"
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblID.Location = New System.Drawing.Point(6, 16)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(70, 30)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "0001"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_IdTexto
        '
        Me.lbl_IdTexto.AutoSize = True
        Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_IdTexto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_IdTexto.Location = New System.Drawing.Point(24, 3)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 1
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCNP
        '
        Me.lblCNP.BackColor = System.Drawing.Color.Transparent
        Me.lblCNP.Location = New System.Drawing.Point(164, 101)
        Me.lblCNP.Margin = New System.Windows.Forms.Padding(6)
        Me.lblCNP.Name = "lblCNP"
        Me.lblCNP.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.lblCNP.Size = New System.Drawing.Size(167, 27)
        Me.lblCNP.TabIndex = 5
        Me.lblCNP.Text = "00.000.000/0000-00"
        Me.lblCNP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(103, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Credor"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(124, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Filial:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(80, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(130, 30)
        Me.lblFilial.TabIndex = 2
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(38, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tipo de Despesa"
        '
        'txtCredor
        '
        Me.txtCredor.Location = New System.Drawing.Point(164, 66)
        Me.txtCredor.Margin = New System.Windows.Forms.Padding(5, 5, 2, 5)
        Me.txtCredor.Name = "txtCredor"
        Me.txtCredor.Size = New System.Drawing.Size(355, 27)
        Me.txtCredor.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(82, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Descrição"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(56, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Data do Início"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(33, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Valor da Despesa"
        '
        'btnTipo
        '
        Me.btnTipo.AllowAnimations = True
        Me.btnTipo.BackColor = System.Drawing.Color.Transparent
        Me.btnTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTipo.Location = New System.Drawing.Point(374, 137)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.RoundedCornersMask = CType(15, Byte)
        Me.btnTipo.RoundedCornersRadius = 0
        Me.btnTipo.Size = New System.Drawing.Size(34, 27)
        Me.btnTipo.TabIndex = 8
        Me.btnTipo.TabStop = False
        Me.btnTipo.Text = "..."
        Me.btnTipo.UseCompatibleTextRendering = True
        Me.btnTipo.UseVisualStyleBackColor = False
        Me.btnTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnCredor
        '
        Me.btnCredor.AllowAnimations = True
        Me.btnCredor.BackColor = System.Drawing.Color.Transparent
        Me.btnCredor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCredor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCredor.Location = New System.Drawing.Point(524, 66)
        Me.btnCredor.Name = "btnCredor"
        Me.btnCredor.RoundedCornersMask = CType(15, Byte)
        Me.btnCredor.RoundedCornersRadius = 0
        Me.btnCredor.Size = New System.Drawing.Size(34, 27)
        Me.btnCredor.TabIndex = 3
        Me.btnCredor.TabStop = False
        Me.btnCredor.Text = "..."
        Me.btnCredor.UseCompatibleTextRendering = True
        Me.btnCredor.UseVisualStyleBackColor = False
        Me.btnCredor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(164, 172)
        Me.txtDescricao.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDescricao.MaxLength = 100
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(394, 27)
        Me.txtDescricao.TabIndex = 10
        '
        'txtDespesaTipo
        '
        Me.txtDespesaTipo.Location = New System.Drawing.Point(164, 137)
        Me.txtDespesaTipo.Margin = New System.Windows.Forms.Padding(5, 5, 2, 5)
        Me.txtDespesaTipo.Name = "txtDespesaTipo"
        Me.txtDespesaTipo.Size = New System.Drawing.Size(205, 27)
        Me.txtDespesaTipo.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Panel2.Controls.Add(Me.btnFechar)
        Me.Panel2.Controls.Add(Me.btnSalvar)
        Me.Panel2.Controls.Add(Me.btnNova)
        Me.Panel2.Controls.Add(Me.btnProcurar)
        Me.Panel2.Location = New System.Drawing.Point(2, 443)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(590, 48)
        Me.Panel2.TabIndex = 25
        Me.Panel2.TabStop = True
        '
        'btnFechar
        '
        Me.btnFechar.FlatAppearance.BorderSize = 0
        Me.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Wheat
        Me.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.Location = New System.Drawing.Point(471, 3)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(116, 42)
        Me.btnFechar.TabIndex = 3
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.FlatAppearance.BorderSize = 0
        Me.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Wheat
        Me.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_32x32
        Me.btnSalvar.Location = New System.Drawing.Point(257, 3)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(105, 42)
        Me.btnSalvar.TabIndex = 2
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnNova
        '
        Me.btnNova.FlatAppearance.BorderSize = 0
        Me.btnNova.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Wheat
        Me.btnNova.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btnNova.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNova.Image = Global.NovaSiao.My.Resources.Resources.add_32x32
        Me.btnNova.Location = New System.Drawing.Point(130, 3)
        Me.btnNova.Name = "btnNova"
        Me.btnNova.Size = New System.Drawing.Size(105, 42)
        Me.btnNova.TabIndex = 1
        Me.btnNova.Text = "&Nova"
        Me.btnNova.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNova.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNova.UseVisualStyleBackColor = True
        '
        'btnProcurar
        '
        Me.btnProcurar.FlatAppearance.BorderSize = 0
        Me.btnProcurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Wheat
        Me.btnProcurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.search1
        Me.btnProcurar.Location = New System.Drawing.Point(3, 3)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(105, 42)
        Me.btnProcurar.TabIndex = 0
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProcurar.UseVisualStyleBackColor = True
        '
        'eProvider
        '
        Me.eProvider.ContainerControl = Me
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Periodicidade"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 331)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 19)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Vencimento DIA:"
        '
        'cmbDiaVencimento
        '
        Me.cmbDiaVencimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDiaVencimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDiaVencimento.FormattingEnabled = True
        Me.cmbDiaVencimento.Location = New System.Drawing.Point(164, 328)
        Me.cmbDiaVencimento.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbDiaVencimento.Name = "cmbDiaVencimento"
        Me.cmbDiaVencimento.RestrictContentToListItems = True
        Me.cmbDiaVencimento.Size = New System.Drawing.Size(167, 27)
        Me.cmbDiaVencimento.TabIndex = 18
        '
        'txtDespesaValor
        '
        Me.txtDespesaValor.Location = New System.Drawing.Point(164, 246)
        Me.txtDespesaValor.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDespesaValor.MaxLength = 15
        Me.txtDespesaValor.Name = "txtDespesaValor"
        Me.txtDespesaValor.Size = New System.Drawing.Size(100, 27)
        Me.txtDespesaValor.TabIndex = 14
        Me.txtDespesaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIniciarData
        '
        Me.txtIniciarData.Location = New System.Drawing.Point(164, 209)
        Me.txtIniciarData.Margin = New System.Windows.Forms.Padding(5)
        Me.txtIniciarData.Mask = "00/00/0000"
        Me.txtIniciarData.Name = "txtIniciarData"
        Me.txtIniciarData.Size = New System.Drawing.Size(100, 27)
        Me.txtIniciarData.TabIndex = 12
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDAPagar"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Forma"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "No. Reg.:"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn4.HeaderText = "Vencimento"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 110
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'pnlPeriodicidade
        '
        Me.pnlPeriodicidade.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlPeriodicidade.Controls.Add(Me.rbtAnual)
        Me.pnlPeriodicidade.Controls.Add(Me.rbtMensal)
        Me.pnlPeriodicidade.Controls.Add(Me.rbtSemanal)
        Me.pnlPeriodicidade.Location = New System.Drawing.Point(164, 281)
        Me.pnlPeriodicidade.Name = "pnlPeriodicidade"
        Me.pnlPeriodicidade.Size = New System.Drawing.Size(260, 39)
        Me.pnlPeriodicidade.TabIndex = 16
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
        'cmbRGBanco
        '
        Me.cmbRGBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRGBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRGBanco.FormattingEnabled = True
        Me.cmbRGBanco.Location = New System.Drawing.Point(164, 398)
        Me.cmbRGBanco.Name = "cmbRGBanco"
        Me.cmbRGBanco.RestrictContentToListItems = True
        Me.cmbRGBanco.Size = New System.Drawing.Size(205, 27)
        Me.cmbRGBanco.TabIndex = 24
        '
        'cmbIDCobrancaForma
        '
        Me.cmbIDCobrancaForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDCobrancaForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDCobrancaForma.FormattingEnabled = True
        Me.cmbIDCobrancaForma.Location = New System.Drawing.Point(164, 363)
        Me.cmbIDCobrancaForma.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbIDCobrancaForma.Name = "cmbIDCobrancaForma"
        Me.cmbIDCobrancaForma.RestrictContentToListItems = True
        Me.cmbIDCobrancaForma.Size = New System.Drawing.Size(167, 27)
        Me.cmbIDCobrancaForma.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(106, 401)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 19)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Banco"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 366)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 19)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Forma de Cobrança"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(346, 331)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 19)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "MÊS:"
        '
        'cmbMesVencimento
        '
        Me.cmbMesVencimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMesVencimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMesVencimento.FormattingEnabled = True
        Me.cmbMesVencimento.Location = New System.Drawing.Point(395, 328)
        Me.cmbMesVencimento.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbMesVencimento.Name = "cmbMesVencimento"
        Me.cmbMesVencimento.RestrictContentToListItems = True
        Me.cmbMesVencimento.Size = New System.Drawing.Size(163, 27)
        Me.cmbMesVencimento.TabIndex = 20
        '
        'frmDespesaPeriodica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 493)
        Me.Controls.Add(Me.cmbRGBanco)
        Me.Controls.Add(Me.cmbIDCobrancaForma)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pnlPeriodicidade)
        Me.Controls.Add(Me.cmbMesVencimento)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbDiaVencimento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCredor)
        Me.Controls.Add(Me.btnTipo)
        Me.Controls.Add(Me.txtDespesaValor)
        Me.Controls.Add(Me.txtIniciarData)
        Me.Controls.Add(Me.txtDespesaTipo)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtCredor)
        Me.Controls.Add(Me.lblCNP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCNPTexto)
        Me.KeyPreview = True
        Me.Name = "frmDespesaPeriodica"
        Me.Text = "frmDespesaPeriodica"
        Me.Controls.SetChildIndex(Me.lblCNPTexto, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblCNP, 0)
        Me.Controls.SetChildIndex(Me.txtCredor, 0)
        Me.Controls.SetChildIndex(Me.txtDescricao, 0)
        Me.Controls.SetChildIndex(Me.txtDespesaTipo, 0)
        Me.Controls.SetChildIndex(Me.txtIniciarData, 0)
        Me.Controls.SetChildIndex(Me.txtDespesaValor, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnTipo, 0)
        Me.Controls.SetChildIndex(Me.btnCredor, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cmbDiaVencimento, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cmbMesVencimento, 0)
        Me.Controls.SetChildIndex(Me.pnlPeriodicidade, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.cmbIDCobrancaForma, 0)
        Me.Controls.SetChildIndex(Me.cmbRGBanco, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.eProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPeriodicidade.ResumeLayout(False)
        Me.pnlPeriodicidade.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCNPTexto As Label
    Friend WithEvents lblID As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents lblCNP As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCredor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIniciarData As Controles.MaskText_Data
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDespesaValor As Controles.Text_Monetario
    Friend WithEvents Label6 As Label
    Friend WithEvents btnTipo As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnCredor As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents txtDespesaTipo As TextBox
    Friend WithEvents btnProcurar As Button
    Friend WithEvents btnNova As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents eProvider As ErrorProvider
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbDiaVencimento As Controles.ComboBox_OnlyValues
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlPeriodicidade As Panel
    Friend WithEvents rbtSemanal As RadioButton
    Friend WithEvents rbtAnual As RadioButton
    Friend WithEvents rbtMensal As RadioButton
    Friend WithEvents cmbRGBanco As Controles.ComboBox_OnlyValues
    Friend WithEvents cmbIDCobrancaForma As Controles.ComboBox_OnlyValues
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbMesVencimento As Controles.ComboBox_OnlyValues
    Friend WithEvents Label10 As Label
End Class
