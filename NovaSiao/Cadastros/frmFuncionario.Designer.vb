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
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
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
        Me.lblApelidoFilial = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.pnlVenda.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblIDFuncionario)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(768, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblIDFuncionario, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(496, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(272, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Cadastro de Funcionários"
        '
        'txtFuncionario
        '
        Me.txtFuncionario.BackColor = System.Drawing.Color.White
        Me.txtFuncionario.Location = New System.Drawing.Point(173, 66)
        Me.txtFuncionario.MaxLength = 50
        Me.txtFuncionario.Name = "txtFuncionario"
        Me.txtFuncionario.Size = New System.Drawing.Size(454, 27)
        Me.txtFuncionario.TabIndex = 3
        '
        'txtNascimentoData
        '
        Me.txtNascimentoData.Location = New System.Drawing.Point(397, 132)
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
        Me.Label3.Location = New System.Drawing.Point(313, 135)
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
        Me.Label4.Location = New System.Drawing.Point(134, 136)
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
        Me.Label2.Location = New System.Drawing.Point(120, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nome"
        '
        'txtCidade
        '
        Me.txtCidade.BackColor = System.Drawing.Color.White
        Me.txtCidade.Location = New System.Drawing.Point(453, 231)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(174, 27)
        Me.txtCidade.TabIndex = 23
        '
        'txtUF
        '
        Me.txtUF.BackColor = System.Drawing.Color.White
        Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUF.Location = New System.Drawing.Point(173, 266)
        Me.txtUF.MaxLength = 2
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(46, 27)
        Me.txtUF.TabIndex = 25
        '
        'txtEndereco
        '
        Me.txtEndereco.BackColor = System.Drawing.Color.White
        Me.txtEndereco.Location = New System.Drawing.Point(173, 198)
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
        Me.Label16.Location = New System.Drawing.Point(116, 336)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "e-Mail"
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(173, 231)
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
        Me.Label6.Location = New System.Drawing.Point(119, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 19)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Bairro"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(173, 332)
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
        Me.Label5.Location = New System.Drawing.Point(98, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Endereço"
        '
        'txtCEP
        '
        Me.txtCEP.Location = New System.Drawing.Point(269, 266)
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
        Me.Label9.Location = New System.Drawing.Point(102, 303)
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
        Me.Label15.Location = New System.Drawing.Point(233, 270)
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
        Me.Label10.Location = New System.Drawing.Point(325, 302)
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
        Me.Label8.Location = New System.Drawing.Point(141, 270)
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
        Me.Label7.Location = New System.Drawing.Point(393, 234)
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
        Me.Label1.Location = New System.Drawing.Point(95, 369)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Admissão"
        '
        'tsMenu
        '
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.AntiqueWhite
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnNovo, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnExcluir, Me.btnAtivo, Me.btnFechar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 494)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMenu.Size = New System.Drawing.Size(768, 48)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnProcurar
        '
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.Procurar_Usuário
        Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProcurar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(97, 45)
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.ToolTipText = "Procurar Cliente"
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
        Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(86, 45)
        Me.btnFechar.Text = "&Fechar"
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
        Me.pnlVenda.Location = New System.Drawing.Point(120, 409)
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
        Me.txtApelidoFuncionario.Location = New System.Drawing.Point(173, 99)
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
        Me.lblApelido.Location = New System.Drawing.Point(109, 102)
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
        Me.chkVendas.Location = New System.Drawing.Point(317, 367)
        Me.chkVendas.Margin = New System.Windows.Forms.Padding(0)
        Me.chkVendas.Name = "chkVendas"
        Me.chkVendas.Size = New System.Drawing.Size(50, 23)
        Me.chkVendas.TabIndex = 36
        Me.chkVendas.UseVisualStyleBackColor = False
        '
        'lblVendedor
        '
        Me.lblVendedor.Location = New System.Drawing.Point(369, 369)
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
        Me.txtCPF.Location = New System.Drawing.Point(173, 132)
        Me.txtCPF.Mask = "000,000,000-00"
        Me.txtCPF.Name = "txtCPF"
        Me.txtCPF.Size = New System.Drawing.Size(134, 27)
        Me.txtCPF.TabIndex = 7
        Me.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtTelefoneA
        '
        Me.txtTelefoneA.Location = New System.Drawing.Point(173, 299)
        Me.txtTelefoneA.Mask = "(99) 99000-0000"
        Me.txtTelefoneA.Name = "txtTelefoneA"
        Me.txtTelefoneA.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneA.TabIndex = 29
        '
        'txtTelefoneB
        '
        Me.txtTelefoneB.Location = New System.Drawing.Point(386, 299)
        Me.txtTelefoneB.Mask = "(99) 99000-0000"
        Me.txtTelefoneB.Name = "txtTelefoneB"
        Me.txtTelefoneB.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneB.TabIndex = 31
        '
        'txtIdentidade
        '
        Me.txtIdentidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdentidade.Location = New System.Drawing.Point(173, 165)
        Me.txtIdentidade.MaxLength = 20
        Me.txtIdentidade.Name = "txtIdentidade"
        Me.txtIdentidade.Size = New System.Drawing.Size(134, 27)
        Me.txtIdentidade.TabIndex = 13
        '
        'txtIdentidadeOrgao
        '
        Me.txtIdentidadeOrgao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdentidadeOrgao.Location = New System.Drawing.Point(369, 165)
        Me.txtIdentidadeOrgao.MaxLength = 10
        Me.txtIdentidadeOrgao.Name = "txtIdentidadeOrgao"
        Me.txtIdentidadeOrgao.Size = New System.Drawing.Size(110, 27)
        Me.txtIdentidadeOrgao.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(89, 168)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 19)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Identidade"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(314, 168)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 19)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Orgão"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(490, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 19)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Data"
        '
        'txtIdentidadeData
        '
        Me.txtIdentidadeData.Location = New System.Drawing.Point(535, 165)
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
        Me.cmbSexo.Location = New System.Drawing.Point(557, 133)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(70, 27)
        Me.cmbSexo.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(512, 136)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 19)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Sexo"
        '
        'txtAdmissaoData
        '
        Me.txtAdmissaoData.Location = New System.Drawing.Point(173, 365)
        Me.txtAdmissaoData.Mask = "00/00/0000"
        Me.txtAdmissaoData.Name = "txtAdmissaoData"
        Me.txtAdmissaoData.Size = New System.Drawing.Size(100, 27)
        Me.txtAdmissaoData.TabIndex = 35
        Me.txtAdmissaoData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblApelidoFilial
        '
        Me.lblApelidoFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblApelidoFilial.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApelidoFilial.ForeColor = System.Drawing.Color.DarkGray
        Me.lblApelidoFilial.Location = New System.Drawing.Point(432, 101)
        Me.lblApelidoFilial.Name = "lblApelidoFilial"
        Me.lblApelidoFilial.Size = New System.Drawing.Size(199, 24)
        Me.lblApelidoFilial.TabIndex = 4
        Me.lblApelidoFilial.Text = "Apelido Filial"
        Me.lblApelidoFilial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(768, 542)
        Me.Controls.Add(Me.lblApelidoFilial)
        Me.Controls.Add(Me.tsMenu)
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
        Me.Controls.SetChildIndex(Me.tsMenu, 0)
        Me.Controls.SetChildIndex(Me.lblApelidoFilial, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.pnlVenda.ResumeLayout(False)
        Me.pnlVenda.PerformLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents btnAtivo As ToolStripButton
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
    Friend WithEvents lblApelidoFilial As Label
    Friend WithEvents btnFechar As ToolStripButton
    Friend WithEvents btnProcurar As ToolStripButton
End Class
