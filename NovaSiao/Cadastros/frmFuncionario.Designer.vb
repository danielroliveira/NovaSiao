<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFuncionario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFuncionario))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtFuncionario = New System.Windows.Forms.TextBox()
        Me.txtNascimentoData = New Controles.MaskText_Data()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.txtUF = New System.Windows.Forms.TextBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.lblIDFuncionario = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.pnlVenda = New System.Windows.Forms.Panel()
        Me.chkVendedorAtivo = New System.Windows.Forms.CheckBox()
        Me.txtComissao = New System.Windows.Forms.TextBox()
        Me.cmbVendaTipo = New Controles.ComboBox_OnlyValues()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtApelidoFuncionario = New System.Windows.Forms.TextBox()
        Me.lblApelido = New System.Windows.Forms.Label()
        Me.chkVendas = New CheckedButton_OnOff.CheckedButton_OnOff()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtCPF = New System.Windows.Forms.MaskedTextBox()
        Me.txtTelefoneA = New Controles.MaskText_Telefone()
        Me.txtTelefoneB = New Controles.MaskText_Telefone()
        Me.txtIdentidade = New System.Windows.Forms.TextBox()
        Me.txtIdentidadeOrgao = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtIdentidadeData = New Controles.MaskText_Data()
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAdmissaoData = New Controles.MaskText_Data()
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VPanel1 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblApelidoFilial = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnAlterarFilial = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.pnlVenda.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VPanel1.Content.SuspendLayout()
        Me.VPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblIDFuncionario)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(922, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblIDFuncionario, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(650, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(272, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Cadastro de Funcionários"
        '
        'txtFuncionario
        '
        Me.txtFuncionario.BackColor = System.Drawing.Color.White
        Me.txtFuncionario.Location = New System.Drawing.Point(440, 68)
        Me.txtFuncionario.MaxLength = 50
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.Size = New System.Drawing.Size(454, 27)
        Me.txtFuncionario.TabIndex = 3
        '
        'txtNascimentoData
        '
        Me.txtNascimentoData.Location = New System.Drawing.Point(664, 134)
        Me.txtNascimentoData.Mask = "00/00/0000"
        Me.txtNascimentoData.Name = "txtNascimentoData"
        Me.txtNascimentoData.Size = New System.Drawing.Size(107, 27)
        Me.txtNascimentoData.TabIndex = 9
        Me.txtNascimentoData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(580, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Data Nasc."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(401, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "CPF"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(387, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nome"
        '
        'txtCidade
        '
        Me.txtCidade.BackColor = System.Drawing.Color.White
        Me.txtCidade.Location = New System.Drawing.Point(720, 233)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(174, 27)
        Me.txtCidade.TabIndex = 23
        '
        'txtUF
        '
        Me.txtUF.BackColor = System.Drawing.Color.White
        Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUF.Location = New System.Drawing.Point(440, 268)
        Me.txtUF.MaxLength = 2
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(46, 27)
        Me.txtUF.TabIndex = 25
        '
        'txtEndereco
        '
        Me.txtEndereco.BackColor = System.Drawing.Color.White
        Me.txtEndereco.Location = New System.Drawing.Point(440, 200)
        Me.txtEndereco.MaxLength = 50
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(454, 27)
        Me.txtEndereco.TabIndex = 19
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(383, 338)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "e-Mail"
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(440, 233)
        Me.txtBairro.MaxLength = 30
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(207, 27)
        Me.txtBairro.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(386, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 19)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Bairro"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(440, 334)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(357, 27)
        Me.txtEmail.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(365, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Endereço"
        '
        'txtCEP
        '
        Me.txtCEP.Location = New System.Drawing.Point(536, 268)
        Me.txtCEP.Mask = "00000-000"
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(94, 27)
        Me.txtCEP.TabIndex = 27
        Me.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(369, 305)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Telefone"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(500, 272)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 19)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "CEP"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(592, 304)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 19)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Celular"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(408, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 19)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "UF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(660, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 19)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Cidade"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(362, 371)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Admissão"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SplitContainer1.CausesValidation = False
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 494)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tsMenu)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFechar)
        Me.SplitContainer1.Size = New System.Drawing.Size(922, 48)
        Me.SplitContainer1.SplitterDistance = 819
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 39
        Me.SplitContainer1.TabStop = False
        '
        'tsMenu
        '
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovo, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnExcluir, Me.btnAtivo})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMenu.Size = New System.Drawing.Size(819, 48)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Adiconar_Usuário
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(76, 45)
        Me.btnNovo.Text = "&Novo"
        Me.btnNovo.ToolTipText = "Novo Funcionário"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 48)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 48)
        '
        'btnExcluir
        '
        Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.Lixeira
        Me.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(86, 45)
        Me.btnExcluir.Text = "E&xcluir"
        Me.btnExcluir.ToolTipText = "Excluir Funcionário"
        '
        'btnAtivo
        '
        Me.btnAtivo.AutoSize = False
        Me.btnAtivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAtivo.CheckOnClick = True
        Me.btnAtivo.Image = Global.NovaSiao.My.Resources.Resources.Switch_ON_PEQ
        Me.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAtivo.Name = "btnAtivo"
        Me.btnAtivo.Size = New System.Drawing.Size(192, 41)
        Me.btnAtivo.Text = "Funcionário Ativo"
        Me.btnAtivo.ToolTipText = "Ativar/Desativar Funcionário"
        '
        'btnFechar
        '
        Me.btnFechar.BackColor = System.Drawing.Color.Transparent
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.FlatAppearance.BorderSize = 0
        Me.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral
        Me.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.Location = New System.Drawing.Point(4, 0)
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(97, 48)
        Me.btnFechar.TabIndex = 0
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = False
        '
        'lblIDFuncionario
        '
        Me.lblIDFuncionario.BackColor = System.Drawing.Color.Transparent
        Me.lblIDFuncionario.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDFuncionario.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblIDFuncionario.Location = New System.Drawing.Point(9, 18)
        Me.lblIDFuncionario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIDFuncionario.Name = "lblIDFuncionario"
        Me.lblIDFuncionario.Size = New System.Drawing.Size(94, 30)
        Me.lblIDFuncionario.TabIndex = 0
        Me.lblIDFuncionario.Text = "0001"
        Me.lblIDFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_IdTexto
        '
        Me.lbl_IdTexto.AutoSize = True
        Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_IdTexto.ForeColor = System.Drawing.Color.LightGray
        Me.lbl_IdTexto.Location = New System.Drawing.Point(33, 5)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 1
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlVenda
        '
        Me.pnlVenda.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVenda.Controls.Add(Me.chkVendedorAtivo)
        Me.pnlVenda.Controls.Add(Me.txtComissao)
        Me.pnlVenda.Controls.Add(Me.cmbVendaTipo)
        Me.pnlVenda.Controls.Add(Me.Label12)
        Me.pnlVenda.Controls.Add(Me.Label11)
        Me.pnlVenda.Enabled = False
        Me.pnlVenda.Location = New System.Drawing.Point(387, 411)
        Me.pnlVenda.Name = "pnlVenda"
        Me.pnlVenda.Size = New System.Drawing.Size(488, 71)
        Me.pnlVenda.TabIndex = 38
        '
        'chkVendedorAtivo
        '
        Me.chkVendedorAtivo.AutoSize = True
        Me.chkVendedorAtivo.Checked = True
        Me.chkVendedorAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVendedorAtivo.Location = New System.Drawing.Point(346, 24)
        Me.chkVendedorAtivo.Name = "chkVendedorAtivo"
        Me.chkVendedorAtivo.Size = New System.Drawing.Size(126, 23)
        Me.chkVendedorAtivo.TabIndex = 4
        Me.chkVendedorAtivo.Text = "Vendedor Ativo"
        Me.chkVendedorAtivo.UseVisualStyleBackColor = True
        '
        'txtComissao
        '
        Me.txtComissao.Location = New System.Drawing.Point(230, 31)
        Me.txtComissao.MaxLength = 5
        Me.txtComissao.Name = "txtComissao"
        Me.txtComissao.Size = New System.Drawing.Size(59, 27)
        Me.txtComissao.TabIndex = 3
        '
        'cmbVendaTipo
        '
        Me.cmbVendaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendaTipo.FormattingEnabled = True
        Me.cmbVendaTipo.Location = New System.Drawing.Point(11, 30)
        Me.cmbVendaTipo.Name = "cmbVendaTipo"
        Me.cmbVendaTipo.RestrictContentToListItems = True
        Me.cmbVendaTipo.Size = New System.Drawing.Size(186, 27)
        Me.cmbVendaTipo.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(8, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 19)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Tipo de Venda"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(215, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 19)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Comissão (%)"
        '
        'txtApelidoFuncionario
        '
        Me.txtApelidoFuncionario.BackColor = System.Drawing.Color.White
        Me.txtApelidoFuncionario.Location = New System.Drawing.Point(440, 101)
        Me.txtApelidoFuncionario.MaxLength = 50
        Me.txtApelidoFuncionario.Name = "txtApelidoFuncionario"
        Me.txtApelidoFuncionario.Size = New System.Drawing.Size(186, 27)
        Me.txtApelidoFuncionario.TabIndex = 5
        '
        'lblApelido
        '
        Me.lblApelido.AutoSize = True
        Me.lblApelido.BackColor = System.Drawing.Color.Transparent
        Me.lblApelido.ForeColor = System.Drawing.Color.Black
        Me.lblApelido.Location = New System.Drawing.Point(376, 104)
        Me.lblApelido.Name = "lblApelido"
        Me.lblApelido.Size = New System.Drawing.Size(58, 19)
        Me.lblApelido.TabIndex = 4
        Me.lblApelido.Text = "Apelido"
        '
        'chkVendas
        '
        Me.chkVendas.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkVendas.BackColor = System.Drawing.Color.Transparent
        Me.chkVendas.BackgroundImage = CType(resources.GetObject("chkVendas.BackgroundImage"), System.Drawing.Image)
        Me.chkVendas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.chkVendas.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.chkVendas.FlatAppearance.BorderSize = 0
        Me.chkVendas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkVendas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkVendas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVendas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVendas.Location = New System.Drawing.Point(584, 369)
        Me.chkVendas.Margin = New System.Windows.Forms.Padding(0)
        Me.chkVendas.Name = "chkVendas"
        Me.chkVendas.Size = New System.Drawing.Size(50, 23)
        Me.chkVendas.TabIndex = 36
        Me.chkVendas.UseVisualStyleBackColor = False
        '
        'lblVendedor
        '
        Me.lblVendedor.Location = New System.Drawing.Point(636, 371)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(225, 19)
        Me.lblVendedor.TabIndex = 37
        Me.lblVendedor.Text = "Funcionário não é Vendedor"
        '
        'EProvider
        '
        Me.EProvider.ContainerControl = Me
        '
        'txtCPF
        '
        Me.txtCPF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCPF.Location = New System.Drawing.Point(440, 134)
        Me.txtCPF.Mask = "000,000,000-00"
        Me.txtCPF.Name = "txtCPF"
        Me.txtCPF.Size = New System.Drawing.Size(134, 27)
        Me.txtCPF.TabIndex = 7
        Me.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtTelefoneA
        '
        Me.txtTelefoneA.Location = New System.Drawing.Point(440, 301)
        Me.txtTelefoneA.Mask = "(99) 99000-0000"
        Me.txtTelefoneA.Name = "txtTelefoneA"
        Me.txtTelefoneA.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneA.TabIndex = 29
        '
        'txtTelefoneB
        '
        Me.txtTelefoneB.Location = New System.Drawing.Point(653, 301)
        Me.txtTelefoneB.Mask = "(99) 99000-0000"
        Me.txtTelefoneB.Name = "txtTelefoneB"
        Me.txtTelefoneB.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneB.TabIndex = 31
        '
        'txtIdentidade
        '
        Me.txtIdentidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdentidade.Location = New System.Drawing.Point(440, 167)
        Me.txtIdentidade.MaxLength = 20
        Me.txtIdentidade.Name = "txtIdentidade"
        Me.txtIdentidade.Size = New System.Drawing.Size(134, 27)
        Me.txtIdentidade.TabIndex = 13
        '
        'txtIdentidadeOrgao
        '
        Me.txtIdentidadeOrgao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdentidadeOrgao.Location = New System.Drawing.Point(636, 167)
        Me.txtIdentidadeOrgao.MaxLength = 10
        Me.txtIdentidadeOrgao.Name = "txtIdentidadeOrgao"
        Me.txtIdentidadeOrgao.Size = New System.Drawing.Size(110, 27)
        Me.txtIdentidadeOrgao.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(356, 170)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 19)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Identidade"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(581, 170)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 19)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Orgão"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(757, 170)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 19)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Data"
        '
        'txtIdentidadeData
        '
        Me.txtIdentidadeData.Location = New System.Drawing.Point(802, 167)
        Me.txtIdentidadeData.Mask = "00/00/0000"
        Me.txtIdentidadeData.Name = "txtIdentidadeData"
        Me.txtIdentidadeData.Size = New System.Drawing.Size(92, 27)
        Me.txtIdentidadeData.TabIndex = 17
        Me.txtIdentidadeData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbSexo
        '
        Me.cmbSexo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSexo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSexo.FormattingEnabled = True
        Me.cmbSexo.Location = New System.Drawing.Point(824, 135)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(70, 27)
        Me.cmbSexo.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(779, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 19)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Sexo"
        '
        'txtAdmissaoData
        '
        Me.txtAdmissaoData.Location = New System.Drawing.Point(440, 367)
        Me.txtAdmissaoData.Mask = "00/00/0000"
        Me.txtAdmissaoData.Name = "txtAdmissaoData"
        Me.txtAdmissaoData.Size = New System.Drawing.Size(100, 27)
        Me.txtAdmissaoData.TabIndex = 35
        Me.txtAdmissaoData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.AllowUserToAddRows = False
        Me.dgvFuncionarios.AllowUserToDeleteRows = False
        Me.dgvFuncionarios.AllowUserToResizeColumns = False
        Me.dgvFuncionarios.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.dgvFuncionarios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvFuncionarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvFuncionarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFuncionarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvFuncionarios.ColumnHeadersHeight = 33
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFuncionarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnNome})
        Me.dgvFuncionarios.EnableHeadersVisualStyles = False
        Me.dgvFuncionarios.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvFuncionarios.Location = New System.Drawing.Point(14, 68)
        Me.dgvFuncionarios.MultiSelect = False
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.ReadOnly = True
        Me.dgvFuncionarios.RowHeadersVisible = False
        Me.dgvFuncionarios.RowHeadersWidth = 45
        Me.dgvFuncionarios.RowTemplate.Height = 30
        Me.dgvFuncionarios.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFuncionarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFuncionarios.Size = New System.Drawing.Size(320, 275)
        Me.dgvFuncionarios.TabIndex = 1
        '
        'clnID
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle11.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.clnID.DefaultCellStyle = DataGridViewCellStyle11
        Me.clnID.HeaderText = "Reg.:"
        Me.clnID.Name = "clnID"
        Me.clnID.ReadOnly = True
        Me.clnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clnID.Width = 60
        '
        'clnNome
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.PowderBlue
        Me.clnNome.DefaultCellStyle = DataGridViewCellStyle12
        Me.clnNome.HeaderText = "Funcionário"
        Me.clnNome.Name = "clnNome"
        Me.clnNome.ReadOnly = True
        Me.clnNome.Width = 220
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
        Me.VPanel1.Content.Controls.Add(Me.lblApelidoFilial)
        Me.VPanel1.Content.Controls.Add(Me.btnAlterarFilial)
        Me.VPanel1.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel1.Content.Name = "Content"
        Me.VPanel1.Content.Size = New System.Drawing.Size(318, 36)
        Me.VPanel1.Content.TabIndex = 3
        Me.VPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel1.Location = New System.Drawing.Point(14, 349)
        Me.VPanel1.Name = "VPanel1"
        Me.VPanel1.Opacity = 1.0!
        Me.VPanel1.PanelBorderColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.VPanel1.Size = New System.Drawing.Size(320, 38)
        Me.VPanel1.TabIndex = 40
        Me.VPanel1.Text = "VPanel1"
        Me.VPanel1.UsePanelBorderColor = True
        Me.VPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblApelidoFilial
        '
        Me.lblApelidoFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblApelidoFilial.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApelidoFilial.Location = New System.Drawing.Point(3, 4)
        Me.lblApelidoFilial.Name = "lblApelidoFilial"
        Me.lblApelidoFilial.Size = New System.Drawing.Size(277, 28)
        Me.lblApelidoFilial.TabIndex = 4
        Me.lblApelidoFilial.Text = "Apelido Filial"
        Me.lblApelidoFilial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(770, 277)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 14)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Filial Sede:"
        '
        'btnAlterarFilial
        '
        Me.btnAlterarFilial.BackgroundImage = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnAlterarFilial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAlterarFilial.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnAlterarFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlterarFilial.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlterarFilial.Location = New System.Drawing.Point(286, 4)
        Me.btnAlterarFilial.Name = "btnAlterarFilial"
        Me.btnAlterarFilial.Size = New System.Drawing.Size(28, 28)
        Me.btnAlterarFilial.TabIndex = 25
        Me.btnAlterarFilial.TabStop = False
        Me.btnAlterarFilial.UseVisualStyleBackColor = True
        '
        'frmFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(922, 542)
        Me.Controls.Add(Me.VPanel1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.dgvFuncionarios)
        Me.Controls.Add(Me.txtAdmissaoData)
        Me.Controls.Add(Me.cmbSexo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtIdentidade)
        Me.Controls.Add(Me.txtApelidoFuncionario)
        Me.Controls.Add(Me.lblApelido)
        Me.Controls.Add(Me.txtIdentidadeOrgao)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtIdentidadeData)
        Me.Controls.Add(Me.txtTelefoneB)
        Me.Controls.Add(Me.txtTelefoneA)
        Me.Controls.Add(Me.txtCPF)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.chkVendas)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.txtUF)
        Me.Controls.Add(Me.txtEndereco)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtBairro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCEP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFuncionario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNascimentoData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlVenda)
        Me.Name = "frmFuncionario"
        Me.Text = "Cadastro de Funcionários"
        Me.Controls.SetChildIndex(Me.pnlVenda, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtNascimentoData, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtFuncionario, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtCEP, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtEmail, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtBairro, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtEndereco, 0)
        Me.Controls.SetChildIndex(Me.txtUF, 0)
        Me.Controls.SetChildIndex(Me.txtCidade, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.chkVendas, 0)
        Me.Controls.SetChildIndex(Me.lblVendedor, 0)
        Me.Controls.SetChildIndex(Me.txtCPF, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneA, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneB, 0)
        Me.Controls.SetChildIndex(Me.txtIdentidadeData, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txtIdentidadeOrgao, 0)
        Me.Controls.SetChildIndex(Me.lblApelido, 0)
        Me.Controls.SetChildIndex(Me.txtApelidoFuncionario, 0)
        Me.Controls.SetChildIndex(Me.txtIdentidade, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.cmbSexo, 0)
        Me.Controls.SetChildIndex(Me.txtAdmissaoData, 0)
        Me.Controls.SetChildIndex(Me.dgvFuncionarios, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.VPanel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.pnlVenda.ResumeLayout(False)
        Me.pnlVenda.PerformLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VPanel1.Content.ResumeLayout(False)
        Me.VPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFuncionario As TextBox
    Friend WithEvents txtNascimentoData As Controles.MaskText_Data
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCidade As TextBox
    Friend WithEvents txtUF As TextBox
    Friend WithEvents txtEndereco As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtBairro As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCEP As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents btnFechar As Button
    Friend WithEvents lblIDFuncionario As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents pnlVenda As Panel
    Friend WithEvents txtApelidoFuncionario As TextBox
    Friend WithEvents lblApelido As Label
    Friend WithEvents cmbVendaTipo As Controles.ComboBox_OnlyValues
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents chkVendas As CheckedButton_OnOff.CheckedButton_OnOff
    Friend WithEvents lblVendedor As Label
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents txtCPF As MaskedTextBox
    Friend WithEvents txtTelefoneB As Controles.MaskText_Telefone
    Friend WithEvents txtTelefoneA As Controles.MaskText_Telefone
    Friend WithEvents txtComissao As TextBox
    Friend WithEvents txtIdentidade As TextBox
    Friend WithEvents txtIdentidadeOrgao As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtIdentidadeData As Controles.MaskText_Data
    Friend WithEvents cmbSexo As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents chkVendedorAtivo As CheckBox
    Friend WithEvents txtAdmissaoData As Controles.MaskText_Data
    Friend WithEvents dgvFuncionarios As DataGridView
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnNome As DataGridViewTextBoxColumn
    Friend WithEvents VPanel1 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblApelidoFilial As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents btnAlterarFilial As Button
End Class
