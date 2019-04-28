<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFornecedor
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
        Me.txtFundacaoData = New Controles.MaskText_Data()
        Me.txtInscricao = New System.Windows.Forms.TextBox()
        Me.txtContatoNome = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTelefoneB = New Controles.MaskText_Telefone()
        Me.txtTelefoneA = New Controles.MaskText_Telefone()
        Me.txtCNPJ = New System.Windows.Forms.MaskedTextBox()
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
        Me.txtRazaoSocial = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNomeFantasia = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtEmailVendas = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(614, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(300, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(314, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Cadastro de Fornecedores"
        '
        'txtFundacaoData
        '
        Me.txtFundacaoData.Location = New System.Drawing.Point(491, 396)
        Me.txtFundacaoData.Mask = "00/00/0000"
        Me.txtFundacaoData.Name = "txtFundacaoData"
        Me.txtFundacaoData.Size = New System.Drawing.Size(100, 27)
        Me.txtFundacaoData.TabIndex = 32
        Me.txtFundacaoData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFundacaoData.ValidatingType = GetType(Date)
        '
        'txtInscricao
        '
        Me.txtInscricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInscricao.Location = New System.Drawing.Point(401, 130)
        Me.txtInscricao.MaxLength = 20
        Me.txtInscricao.Name = "txtInscricao"
        Me.txtInscricao.Size = New System.Drawing.Size(190, 27)
        Me.txtInscricao.TabIndex = 8
        '
        'txtContatoNome
        '
        Me.txtContatoNome.Location = New System.Drawing.Point(137, 396)
        Me.txtContatoNome.MaxLength = 30
        Me.txtContatoNome.Name = "txtContatoNome"
        Me.txtContatoNome.Size = New System.Drawing.Size(237, 27)
        Me.txtContatoNome.TabIndex = 30
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(297, 133)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 19)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Insc. Estadual"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(10, 399)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(121, 19)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Contato Diretoria"
        '
        'txtTelefoneB
        '
        Me.txtTelefoneB.Location = New System.Drawing.Point(350, 297)
        Me.txtTelefoneB.Mask = "(99) 99000-0000"
        Me.txtTelefoneB.Name = "txtTelefoneB"
        Me.txtTelefoneB.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneB.TabIndex = 24
        '
        'txtTelefoneA
        '
        Me.txtTelefoneA.Location = New System.Drawing.Point(137, 297)
        Me.txtTelefoneA.Mask = "(99) 99000-0000"
        Me.txtTelefoneA.Name = "txtTelefoneA"
        Me.txtTelefoneA.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneA.TabIndex = 22
        '
        'txtCNPJ
        '
        Me.txtCNPJ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCNPJ.Location = New System.Drawing.Point(137, 130)
        Me.txtCNPJ.Mask = "00,000,000/0000-00"
        Me.txtCNPJ.Name = "txtCNPJ"
        Me.txtCNPJ.Size = New System.Drawing.Size(152, 27)
        Me.txtCNPJ.TabIndex = 6
        Me.txtCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtCidade
        '
        Me.txtCidade.BackColor = System.Drawing.Color.White
        Me.txtCidade.Location = New System.Drawing.Point(401, 196)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(190, 27)
        Me.txtCidade.TabIndex = 14
        '
        'txtUF
        '
        Me.txtUF.BackColor = System.Drawing.Color.White
        Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUF.Location = New System.Drawing.Point(137, 231)
        Me.txtUF.MaxLength = 2
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(46, 27)
        Me.txtUF.TabIndex = 16
        '
        'txtEndereco
        '
        Me.txtEndereco.BackColor = System.Drawing.Color.White
        Me.txtEndereco.Location = New System.Drawing.Point(137, 163)
        Me.txtEndereco.MaxLength = 50
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(454, 27)
        Me.txtEndereco.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(20, 366)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(111, 19)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "e-Mail Empresa"
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(137, 196)
        Me.txtBairro.MaxLength = 30
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(190, 27)
        Me.txtBairro.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(83, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 19)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Bairro"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(137, 363)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(357, 27)
        Me.txtEmail.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(62, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Endereço"
        '
        'txtCEP
        '
        Me.txtCEP.Location = New System.Drawing.Point(233, 231)
        Me.txtCEP.Mask = "00000-000"
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(94, 27)
        Me.txtCEP.TabIndex = 18
        Me.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(66, 301)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Telefone"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(197, 235)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 19)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "CEP"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(289, 301)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 19)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Celular"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(105, 235)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 19)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "UF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(341, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 19)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Cidade"
        '
        'txtRazaoSocial
        '
        Me.txtRazaoSocial.BackColor = System.Drawing.Color.White
        Me.txtRazaoSocial.Location = New System.Drawing.Point(137, 64)
        Me.txtRazaoSocial.MaxLength = 50
        Me.txtRazaoSocial.Name = "txtRazaoSocial"
        Me.txtRazaoSocial.Size = New System.Drawing.Size(454, 27)
        Me.txtRazaoSocial.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(391, 399)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 19)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Fundação Dt."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(91, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 19)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "CNPJ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(41, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Razao Social"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SplitContainer1.CausesValidation = False
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 502)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tsMenu)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFechar)
        Me.SplitContainer1.Size = New System.Drawing.Size(614, 48)
        Me.SplitContainer1.SplitterDistance = 506
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 36
        Me.SplitContainer1.TabStop = False
        '
        'tsMenu
        '
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnNovo, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnAtivo})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMenu.Size = New System.Drawing.Size(506, 48)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnProcurar
        '
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.Procurar
        Me.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProcurar.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(97, 45)
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.ToolTipText = "Procurar Cliente"
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Adicionar1
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
        'btnAtivo
        '
        Me.btnAtivo.AutoSize = False
        Me.btnAtivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAtivo.CheckOnClick = True
        Me.btnAtivo.Image = Global.NovaSiao.My.Resources.Resources.Switch_ON_PEQ
        Me.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAtivo.Name = "btnAtivo"
        Me.btnAtivo.Size = New System.Drawing.Size(110, 41)
        Me.btnAtivo.Text = "Ativo"
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(25, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 19)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Nome Fantasia"
        '
        'txtNomeFantasia
        '
        Me.txtNomeFantasia.BackColor = System.Drawing.Color.White
        Me.txtNomeFantasia.Location = New System.Drawing.Point(137, 97)
        Me.txtNomeFantasia.MaxLength = 50
        Me.txtNomeFantasia.Name = "txtNomeFantasia"
        Me.txtNomeFantasia.Size = New System.Drawing.Size(454, 27)
        Me.txtNomeFantasia.TabIndex = 4
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblID.Location = New System.Drawing.Point(5, 17)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(94, 30)
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
        Me.lbl_IdTexto.Location = New System.Drawing.Point(29, 4)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 1
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(45, 432)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 19)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Observação"
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(137, 429)
        Me.txtObservacao.Margin = New System.Windows.Forms.Padding(6)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(454, 54)
        Me.txtObservacao.TabIndex = 34
        '
        'EProvider
        '
        Me.EProvider.ContainerControl = Me
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(61, 267)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 19)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Vendedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(137, 264)
        Me.txtVendedor.MaxLength = 30
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(190, 27)
        Me.txtVendedor.TabIndex = 20
        '
        'txtEmailVendas
        '
        Me.txtEmailVendas.Location = New System.Drawing.Point(137, 330)
        Me.txtEmailVendas.MaxLength = 100
        Me.txtEmailVendas.Name = "txtEmailVendas"
        Me.txtEmailVendas.Size = New System.Drawing.Size(357, 27)
        Me.txtEmailVendas.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(29, 333)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 19)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "e-Mail Vendas"
        '
        'frmFornecedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(614, 550)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.txtFundacaoData)
        Me.Controls.Add(Me.txtInscricao)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.txtContatoNome)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtTelefoneB)
        Me.Controls.Add(Me.txtTelefoneA)
        Me.Controls.Add(Me.txtCNPJ)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.txtUF)
        Me.Controls.Add(Me.txtEndereco)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtBairro)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmailVendas)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCEP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtNomeFantasia)
        Me.Controls.Add(Me.txtRazaoSocial)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmFornecedor"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtRazaoSocial, 0)
        Me.Controls.SetChildIndex(Me.txtNomeFantasia, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtCEP, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtEmail, 0)
        Me.Controls.SetChildIndex(Me.txtEmailVendas, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtBairro, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtEndereco, 0)
        Me.Controls.SetChildIndex(Me.txtUF, 0)
        Me.Controls.SetChildIndex(Me.txtCidade, 0)
        Me.Controls.SetChildIndex(Me.txtCNPJ, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneA, 0)
        Me.Controls.SetChildIndex(Me.txtTelefoneB, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtContatoNome, 0)
        Me.Controls.SetChildIndex(Me.txtVendedor, 0)
        Me.Controls.SetChildIndex(Me.txtObservacao, 0)
        Me.Controls.SetChildIndex(Me.txtInscricao, 0)
        Me.Controls.SetChildIndex(Me.txtFundacaoData, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFundacaoData As Controles.MaskText_Data
    Friend WithEvents txtInscricao As TextBox
    Friend WithEvents txtContatoNome As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtTelefoneB As Controles.MaskText_Telefone
    Friend WithEvents txtTelefoneA As Controles.MaskText_Telefone
    Friend WithEvents txtCNPJ As MaskedTextBox
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
    Friend WithEvents txtRazaoSocial As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnProcurar As ToolStripButton
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNomeFantasia As TextBox
    Friend WithEvents lblID As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtEmailVendas As TextBox
End Class
