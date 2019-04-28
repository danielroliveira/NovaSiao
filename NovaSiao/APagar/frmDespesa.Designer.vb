<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespesa
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnTipo = New VIBlend.WinForms.Controls.vButton()
        Me.btnCredor = New VIBlend.WinForms.Controls.vButton()
        Me.dgvAPagar = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIdentificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.txtDespesaTipo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnNova = New System.Windows.Forms.Button()
        Me.btnProcurar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbParcelado = New Controles.ComboBox_OnlyValues()
        Me.txtDespesaValor = New Controles.Text_Monetario()
        Me.txtDespesaData = New Controles.MaskText_Data()
        Me.eProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmsMenuAPagar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InserirNovaParcelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarParcelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcluirParcelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.eProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMenuAPagar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(594, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label15, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(353, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(241, 50)
        Me.lblTitulo.Text = "Cadastro de Despesas"
        '
        'lblCNPTexto
        '
        Me.lblCNPTexto.AutoSize = True
        Me.lblCNPTexto.BackColor = System.Drawing.Color.Transparent
        Me.lblCNPTexto.ForeColor = System.Drawing.Color.Black
        Me.lblCNPTexto.Location = New System.Drawing.Point(93, 110)
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
        Me.lblID.TabIndex = 48
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
        Me.lbl_IdTexto.TabIndex = 49
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCNP
        '
        Me.lblCNP.BackColor = System.Drawing.Color.Transparent
        Me.lblCNP.Location = New System.Drawing.Point(145, 106)
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
        Me.Label1.Location = New System.Drawing.Point(84, 74)
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
        Me.Label18.TabIndex = 58
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
        Me.lblFilial.TabIndex = 57
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tipo de Despesa"
        '
        'txtCredor
        '
        Me.txtCredor.Location = New System.Drawing.Point(145, 71)
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
        Me.Label3.Location = New System.Drawing.Point(64, 180)
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
        Me.Label5.Location = New System.Drawing.Point(13, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Data da Despesa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(15, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Valor da Despesa"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(259, 254)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 19)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Parcelado"
        '
        'btnTipo
        '
        Me.btnTipo.AllowAnimations = True
        Me.btnTipo.BackColor = System.Drawing.Color.Transparent
        Me.btnTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTipo.Location = New System.Drawing.Point(355, 142)
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
        Me.btnCredor.Location = New System.Drawing.Point(505, 71)
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
        'dgvAPagar
        '
        Me.dgvAPagar.AllowUserToAddRows = False
        Me.dgvAPagar.AllowUserToDeleteRows = False
        Me.dgvAPagar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvAPagar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvAPagar.ColumnHeadersHeight = 30
        Me.dgvAPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvAPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnForma, Me.clnIdentificador, Me.clnVencimento, Me.clnValor})
        Me.dgvAPagar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAPagar.EnableHeadersVisualStyles = False
        Me.dgvAPagar.Location = New System.Drawing.Point(23, 295)
        Me.dgvAPagar.MultiSelect = False
        Me.dgvAPagar.Name = "dgvAPagar"
        Me.dgvAPagar.ReadOnly = True
        Me.dgvAPagar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvAPagar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAPagar.Size = New System.Drawing.Size(550, 204)
        Me.dgvAPagar.TabIndex = 17
        '
        'clnID
        '
        Me.clnID.HeaderText = "IDAPagar"
        Me.clnID.Name = "clnID"
        Me.clnID.ReadOnly = True
        Me.clnID.Visible = False
        '
        'clnForma
        '
        Me.clnForma.HeaderText = "Forma"
        Me.clnForma.Name = "clnForma"
        Me.clnForma.ReadOnly = True
        Me.clnForma.Width = 160
        '
        'clnIdentificador
        '
        Me.clnIdentificador.HeaderText = "No. Reg.:"
        Me.clnIdentificador.Name = "clnIdentificador"
        Me.clnIdentificador.ReadOnly = True
        '
        'clnVencimento
        '
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.clnVencimento.DefaultCellStyle = DataGridViewCellStyle1
        Me.clnVencimento.HeaderText = "Vencimento"
        Me.clnVencimento.Name = "clnVencimento"
        Me.clnVencimento.ReadOnly = True
        Me.clnVencimento.Width = 110
        '
        'clnValor
        '
        Me.clnValor.HeaderText = "Valor"
        Me.clnValor.Name = "clnValor"
        Me.clnValor.ReadOnly = True
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(145, 177)
        Me.txtDescricao.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDescricao.MaxLength = 100
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(355, 27)
        Me.txtDescricao.TabIndex = 10
        '
        'txtDespesaTipo
        '
        Me.txtDespesaTipo.Location = New System.Drawing.Point(145, 142)
        Me.txtDespesaTipo.Margin = New System.Windows.Forms.Padding(5, 5, 2, 5)
        Me.txtDespesaTipo.Name = "txtDespesaTipo"
        Me.txtDespesaTipo.Size = New System.Drawing.Size(205, 27)
        Me.txtDespesaTipo.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(249, 4)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "Situação:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSituacao
        '
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblSituacao.Location = New System.Drawing.Point(214, 16)
        Me.lblSituacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(136, 30)
        Me.lblSituacao.TabIndex = 59
        Me.lblSituacao.Text = "Em Aberto"
        Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Panel2.Controls.Add(Me.btnFechar)
        Me.Panel2.Controls.Add(Me.btnSalvar)
        Me.Panel2.Controls.Add(Me.btnNova)
        Me.Panel2.Controls.Add(Me.btnProcurar)
        Me.Panel2.Location = New System.Drawing.Point(2, 518)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(590, 48)
        Me.Panel2.TabIndex = 18
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
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "Vencimento"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 110
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Valor"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'cmbParcelado
        '
        Me.cmbParcelado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbParcelado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbParcelado.FormattingEnabled = True
        Me.cmbParcelado.Location = New System.Drawing.Point(341, 251)
        Me.cmbParcelado.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbParcelado.Name = "cmbParcelado"
        Me.cmbParcelado.RestrictContentToListItems = True
        Me.cmbParcelado.Size = New System.Drawing.Size(74, 27)
        Me.cmbParcelado.TabIndex = 16
        '
        'txtDespesaValor
        '
        Me.txtDespesaValor.Location = New System.Drawing.Point(144, 251)
        Me.txtDespesaValor.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDespesaValor.MaxLength = 15
        Me.txtDespesaValor.Name = "txtDespesaValor"
        Me.txtDespesaValor.Size = New System.Drawing.Size(100, 27)
        Me.txtDespesaValor.TabIndex = 14
        Me.txtDespesaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDespesaData
        '
        Me.txtDespesaData.Location = New System.Drawing.Point(145, 214)
        Me.txtDespesaData.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDespesaData.Mask = "00/00/0000"
        Me.txtDespesaData.Name = "txtDespesaData"
        Me.txtDespesaData.Size = New System.Drawing.Size(100, 27)
        Me.txtDespesaData.TabIndex = 12
        '
        'eProvider
        '
        Me.eProvider.ContainerControl = Me
        '
        'cmsMenuAPagar
        '
        Me.cmsMenuAPagar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InserirNovaParcelaToolStripMenuItem, Me.EditarParcelaToolStripMenuItem, Me.ToolStripSeparator1, Me.ExcluirParcelaToolStripMenuItem})
        Me.cmsMenuAPagar.Name = "cmsMenuAPagar"
        Me.cmsMenuAPagar.Size = New System.Drawing.Size(179, 98)
        '
        'InserirNovaParcelaToolStripMenuItem
        '
        Me.InserirNovaParcelaToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.InserirNovaParcelaToolStripMenuItem.Name = "InserirNovaParcelaToolStripMenuItem"
        Me.InserirNovaParcelaToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.InserirNovaParcelaToolStripMenuItem.Text = "Inserir Nova Parcela"
        '
        'EditarParcelaToolStripMenuItem
        '
        Me.EditarParcelaToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.EditarParcelaToolStripMenuItem.Name = "EditarParcelaToolStripMenuItem"
        Me.EditarParcelaToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.EditarParcelaToolStripMenuItem.Text = "Editar Parcela"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(175, 6)
        '
        'ExcluirParcelaToolStripMenuItem
        '
        Me.ExcluirParcelaToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.ExcluirParcelaToolStripMenuItem.Name = "ExcluirParcelaToolStripMenuItem"
        Me.ExcluirParcelaToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ExcluirParcelaToolStripMenuItem.Text = "Excluir Parcela"
        '
        'frmDespesa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 568)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvAPagar)
        Me.Controls.Add(Me.btnCredor)
        Me.Controls.Add(Me.btnTipo)
        Me.Controls.Add(Me.cmbParcelado)
        Me.Controls.Add(Me.txtDespesaValor)
        Me.Controls.Add(Me.txtDespesaData)
        Me.Controls.Add(Me.txtDespesaTipo)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtCredor)
        Me.Controls.Add(Me.lblCNP)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCNPTexto)
        Me.KeyPreview = True
        Me.Name = "frmDespesa"
        Me.Text = "frmDespesa"
        Me.Controls.SetChildIndex(Me.lblCNPTexto, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.lblCNP, 0)
        Me.Controls.SetChildIndex(Me.txtCredor, 0)
        Me.Controls.SetChildIndex(Me.txtDescricao, 0)
        Me.Controls.SetChildIndex(Me.txtDespesaTipo, 0)
        Me.Controls.SetChildIndex(Me.txtDespesaData, 0)
        Me.Controls.SetChildIndex(Me.txtDespesaValor, 0)
        Me.Controls.SetChildIndex(Me.cmbParcelado, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnTipo, 0)
        Me.Controls.SetChildIndex(Me.btnCredor, 0)
        Me.Controls.SetChildIndex(Me.dgvAPagar, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvAPagar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.eProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMenuAPagar.ResumeLayout(False)
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
    Friend WithEvents txtDespesaData As Controles.MaskText_Data
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDespesaValor As Controles.Text_Monetario
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbParcelado As Controles.ComboBox_OnlyValues
    Friend WithEvents Label7 As Label
    Friend WithEvents btnTipo As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnCredor As VIBlend.WinForms.Controls.vButton
    Friend WithEvents dgvAPagar As DataGridView
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents txtDespesaTipo As TextBox
    Friend WithEvents lblSituacao As Label
    Friend WithEvents Label15 As Label
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
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnForma As DataGridViewTextBoxColumn
    Friend WithEvents clnIdentificador As DataGridViewTextBoxColumn
    Friend WithEvents clnVencimento As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents eProvider As ErrorProvider
    Friend WithEvents cmsMenuAPagar As ContextMenuStrip
    Friend WithEvents InserirNovaParcelaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarParcelaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExcluirParcelaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
