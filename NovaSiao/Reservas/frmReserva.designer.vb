<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReserva
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReserva))
		Me.txtProduto = New System.Windows.Forms.TextBox()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.txtFuncionario = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.tsMenu = New System.Windows.Forms.ToolStrip()
		Me.btnProcurar = New System.Windows.Forms.ToolStripButton()
		Me.btnNovo = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
		Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
		Me.btnFechar = New System.Windows.Forms.ToolStripButton()
		Me.btnAdiantamento = New System.Windows.Forms.ToolStripButton()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.txtFornecedor = New System.Windows.Forms.TextBox()
		Me.lblIDReserva = New System.Windows.Forms.Label()
		Me.lbl_IdTexto = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtObservacao = New System.Windows.Forms.TextBox()
		Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.btnProcProdutoTipo = New VIBlend.WinForms.Controls.vButton()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.txtPVenda = New Controles.Text_Monetario()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.btnProcAutores = New VIBlend.WinForms.Controls.vButton()
		Me.txtAutor = New System.Windows.Forms.TextBox()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.txtClienteNome = New System.Windows.Forms.TextBox()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.btnProcFuncionario = New VIBlend.WinForms.Controls.vButton()
		Me.lblRG = New System.Windows.Forms.Label()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.btnProcFabricantes = New VIBlend.WinForms.Controls.vButton()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.btnProcFornecedores = New VIBlend.WinForms.Controls.vButton()
		Me.txtProdutoTipo = New System.Windows.Forms.TextBox()
		Me.txtFabricante = New System.Windows.Forms.TextBox()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.dtpReservaData = New System.Windows.Forms.DateTimePicker()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.lblTelefoneB = New System.Windows.Forms.Label()
		Me.lblClienteEmail = New System.Windows.Forms.Label()
		Me.lblTelefoneA = New System.Windows.Forms.Label()
		Me.picWathsapp = New System.Windows.Forms.PictureBox()
		Me.btnClienteSimples = New VIBlend.WinForms.Controls.vButton()
		Me.btnClienteSimplesEditar = New VIBlend.WinForms.Controls.vButton()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.txtRGProduto = New System.Windows.Forms.TextBox()
		Me.lblProdConhecido = New System.Windows.Forms.Label()
		Me.lblValorAntecipado = New System.Windows.Forms.Label()
		Me.chkProdutoConhecido = New CheckedButton_OnOff.CheckedButton_OnOff()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.lblFilial = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.tsMenu.SuspendLayout()
		CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		CType(Me.picWathsapp, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel4.SuspendLayout()
		Me.Panel5.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.lblFilial)
		Me.Panel1.Controls.Add(Me.Label6)
		Me.Panel1.Controls.Add(Me.lblIDReserva)
		Me.Panel1.Controls.Add(Me.lbl_IdTexto)
		Me.Panel1.Size = New System.Drawing.Size(627, 50)
		Me.Panel1.TabIndex = 0
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblIDReserva, 0)
		Me.Panel1.Controls.SetChildIndex(Me.Label6, 0)
		Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(380, 0)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(247, 50)
		Me.lblTitulo.TabIndex = 4
		Me.lblTitulo.Text = "Reservas de Produtos"
		'
		'txtProduto
		'
		Me.txtProduto.Location = New System.Drawing.Point(138, 46)
		Me.txtProduto.MaxLength = 30
		Me.txtProduto.Name = "txtProduto"
		Me.txtProduto.Size = New System.Drawing.Size(412, 27)
		Me.txtProduto.TabIndex = 5
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.BackColor = System.Drawing.Color.Transparent
		Me.Label16.ForeColor = System.Drawing.Color.Black
		Me.Label16.Location = New System.Drawing.Point(77, 82)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(51, 19)
		Me.Label16.TabIndex = 8
		Me.Label16.Text = "e-Mail"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.ForeColor = System.Drawing.Color.Black
		Me.Label9.Location = New System.Drawing.Point(62, 48)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(65, 19)
		Me.Label9.TabIndex = 3
		Me.Label9.Text = "Telefone"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.ForeColor = System.Drawing.Color.Black
		Me.Label10.Location = New System.Drawing.Point(290, 48)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(55, 19)
		Me.Label10.TabIndex = 5
		Me.Label10.Text = "Celular"
		'
		'txtFuncionario
		'
		Me.txtFuncionario.BackColor = System.Drawing.Color.White
		Me.txtFuncionario.Location = New System.Drawing.Point(137, 9)
		Me.txtFuncionario.MaxLength = 50
		Me.txtFuncionario.Name = "txtFuncionario"
		Me.txtFuncionario.Size = New System.Drawing.Size(208, 27)
		Me.txtFuncionario.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Location = New System.Drawing.Point(400, 12)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(40, 19)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Data"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Location = New System.Drawing.Point(43, 12)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(84, 19)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Funcionario"
		'
		'tsMenu
		'
		Me.tsMenu.AutoSize = False
		Me.tsMenu.BackColor = System.Drawing.Color.Gainsboro
		Me.tsMenu.Dock = System.Windows.Forms.DockStyle.None
		Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
		Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcurar, Me.btnNovo, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancelar, Me.btnFechar, Me.btnAdiantamento})
		Me.tsMenu.Location = New System.Drawing.Point(0, 628)
		Me.tsMenu.Name = "tsMenu"
		Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
		Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.tsMenu.Size = New System.Drawing.Size(627, 48)
		Me.tsMenu.TabIndex = 10
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
		Me.btnNovo.Text = "&Nova"
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
		'btnFechar
		'
		Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
		Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(86, 45)
		Me.btnFechar.Text = "&Fechar"
		'
		'btnAdiantamento
		'
		Me.btnAdiantamento.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
		Me.btnAdiantamento.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnAdiantamento.Name = "btnAdiantamento"
		Me.btnAdiantamento.Size = New System.Drawing.Size(134, 45)
		Me.btnAdiantamento.Text = "Adiantamento"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.ForeColor = System.Drawing.Color.Black
		Me.Label11.Location = New System.Drawing.Point(47, 211)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(81, 19)
		Me.Label11.TabIndex = 17
		Me.Label11.Text = "Fornecedor"
		'
		'txtFornecedor
		'
		Me.txtFornecedor.BackColor = System.Drawing.Color.White
		Me.txtFornecedor.Location = New System.Drawing.Point(138, 211)
		Me.txtFornecedor.MaxLength = 50
		Me.txtFornecedor.Name = "txtFornecedor"
		Me.txtFornecedor.Size = New System.Drawing.Size(412, 27)
		Me.txtFornecedor.TabIndex = 18
		'
		'lblIDReserva
		'
		Me.lblIDReserva.BackColor = System.Drawing.Color.Transparent
		Me.lblIDReserva.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIDReserva.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblIDReserva.Location = New System.Drawing.Point(5, 17)
		Me.lblIDReserva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblIDReserva.Name = "lblIDReserva"
		Me.lblIDReserva.Size = New System.Drawing.Size(94, 30)
		Me.lblIDReserva.TabIndex = 0
		Me.lblIDReserva.Text = "0001"
		Me.lblIDReserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lbl_IdTexto
		'
		Me.lbl_IdTexto.AutoSize = True
		Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
		Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver
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
		Me.Label3.Location = New System.Drawing.Point(44, 7)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(86, 19)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Observação"
		'
		'txtObservacao
		'
		Me.txtObservacao.Location = New System.Drawing.Point(137, 9)
		Me.txtObservacao.Margin = New System.Windows.Forms.Padding(6)
		Me.txtObservacao.Multiline = True
		Me.txtObservacao.Name = "txtObservacao"
		Me.txtObservacao.Size = New System.Drawing.Size(413, 54)
		Me.txtObservacao.TabIndex = 1
		'
		'EProvider
		'
		Me.EProvider.ContainerControl = Me
		'
		'btnProcProdutoTipo
		'
		Me.btnProcProdutoTipo.AllowAnimations = True
		Me.btnProcProdutoTipo.BackColor = System.Drawing.Color.Transparent
		Me.btnProcProdutoTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnProcProdutoTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnProcProdutoTipo.Location = New System.Drawing.Point(383, 79)
		Me.btnProcProdutoTipo.Name = "btnProcProdutoTipo"
		Me.btnProcProdutoTipo.RoundedCornersMask = CType(15, Byte)
		Me.btnProcProdutoTipo.RoundedCornersRadius = 0
		Me.btnProcProdutoTipo.Size = New System.Drawing.Size(34, 27)
		Me.btnProcProdutoTipo.TabIndex = 8
		Me.btnProcProdutoTipo.TabStop = False
		Me.btnProcProdutoTipo.Text = "..."
		Me.btnProcProdutoTipo.UseCompatibleTextRendering = True
		Me.btnProcProdutoTipo.UseVisualStyleBackColor = False
		Me.btnProcProdutoTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(91, 79)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(37, 19)
		Me.Label12.TabIndex = 6
		Me.Label12.Text = "Tipo"
		'
		'txtPVenda
		'
		Me.txtPVenda.Location = New System.Drawing.Point(138, 178)
		Me.txtPVenda.MaxLength = 10
		Me.txtPVenda.Name = "txtPVenda"
		Me.txtPVenda.Size = New System.Drawing.Size(100, 27)
		Me.txtPVenda.SomentePositivos = True
		Me.txtPVenda.TabIndex = 16
		Me.txtPVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(19, 181)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(109, 19)
		Me.Label13.TabIndex = 15
		Me.Label13.Text = "Preço de Venda"
		'
		'btnProcAutores
		'
		Me.btnProcAutores.AllowAnimations = True
		Me.btnProcAutores.BackColor = System.Drawing.Color.Transparent
		Me.btnProcAutores.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnProcAutores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnProcAutores.Location = New System.Drawing.Point(556, 112)
		Me.btnProcAutores.Name = "btnProcAutores"
		Me.btnProcAutores.RoundedCornersMask = CType(15, Byte)
		Me.btnProcAutores.RoundedCornersRadius = 0
		Me.btnProcAutores.Size = New System.Drawing.Size(34, 27)
		Me.btnProcAutores.TabIndex = 11
		Me.btnProcAutores.TabStop = False
		Me.btnProcAutores.Text = "..."
		Me.btnProcAutores.UseCompatibleTextRendering = True
		Me.btnProcAutores.UseVisualStyleBackColor = False
		Me.btnProcAutores.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'txtAutor
		'
		Me.txtAutor.Location = New System.Drawing.Point(138, 112)
		Me.txtAutor.MaxLength = 50
		Me.txtAutor.Name = "txtAutor"
		Me.txtAutor.Size = New System.Drawing.Size(412, 27)
		Me.txtAutor.TabIndex = 10
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(84, 115)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(44, 19)
		Me.Label14.TabIndex = 9
		Me.Label14.Text = "Autor"
		'
		'txtClienteNome
		'
		Me.txtClienteNome.BackColor = System.Drawing.Color.White
		Me.txtClienteNome.Location = New System.Drawing.Point(138, 12)
		Me.txtClienteNome.MaxLength = 50
		Me.txtClienteNome.Name = "txtClienteNome"
		Me.txtClienteNome.Size = New System.Drawing.Size(372, 27)
		Me.txtClienteNome.TabIndex = 1
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.ForeColor = System.Drawing.Color.Black
		Me.Label19.Location = New System.Drawing.Point(81, 14)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(47, 19)
		Me.Label19.TabIndex = 0
		Me.Label19.Text = "Nome"
		'
		'btnProcFuncionario
		'
		Me.btnProcFuncionario.AllowAnimations = True
		Me.btnProcFuncionario.BackColor = System.Drawing.Color.Transparent
		Me.btnProcFuncionario.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnProcFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnProcFuncionario.Location = New System.Drawing.Point(351, 9)
		Me.btnProcFuncionario.Name = "btnProcFuncionario"
		Me.btnProcFuncionario.RoundedCornersMask = CType(15, Byte)
		Me.btnProcFuncionario.RoundedCornersRadius = 0
		Me.btnProcFuncionario.Size = New System.Drawing.Size(34, 27)
		Me.btnProcFuncionario.TabIndex = 2
		Me.btnProcFuncionario.TabStop = False
		Me.btnProcFuncionario.Text = "..."
		Me.btnProcFuncionario.UseCompatibleTextRendering = True
		Me.btnProcFuncionario.UseVisualStyleBackColor = False
		Me.btnProcFuncionario.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'lblRG
		'
		Me.lblRG.AutoSize = True
		Me.lblRG.Location = New System.Drawing.Point(406, 14)
		Me.lblRG.Name = "lblRG"
		Me.lblRG.Size = New System.Drawing.Size(38, 19)
		Me.lblRG.TabIndex = 2
		Me.lblRG.Text = "Reg."
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(69, 49)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(59, 19)
		Me.Label21.TabIndex = 4
		Me.Label21.Text = "Produto"
		'
		'btnProcFabricantes
		'
		Me.btnProcFabricantes.AllowAnimations = True
		Me.btnProcFabricantes.BackColor = System.Drawing.Color.Transparent
		Me.btnProcFabricantes.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnProcFabricantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnProcFabricantes.Location = New System.Drawing.Point(383, 145)
		Me.btnProcFabricantes.Name = "btnProcFabricantes"
		Me.btnProcFabricantes.RoundedCornersMask = CType(15, Byte)
		Me.btnProcFabricantes.RoundedCornersRadius = 0
		Me.btnProcFabricantes.Size = New System.Drawing.Size(34, 27)
		Me.btnProcFabricantes.TabIndex = 14
		Me.btnProcFabricantes.TabStop = False
		Me.btnProcFabricantes.Text = "..."
		Me.btnProcFabricantes.UseCompatibleTextRendering = True
		Me.btnProcFabricantes.UseVisualStyleBackColor = False
		Me.btnProcFabricantes.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Location = New System.Drawing.Point(51, 148)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(77, 19)
		Me.Label18.TabIndex = 12
		Me.Label18.Text = "Fabricante"
		'
		'btnProcFornecedores
		'
		Me.btnProcFornecedores.AllowAnimations = True
		Me.btnProcFornecedores.BackColor = System.Drawing.Color.Transparent
		Me.btnProcFornecedores.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnProcFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnProcFornecedores.Location = New System.Drawing.Point(556, 211)
		Me.btnProcFornecedores.Name = "btnProcFornecedores"
		Me.btnProcFornecedores.RoundedCornersMask = CType(15, Byte)
		Me.btnProcFornecedores.RoundedCornersRadius = 0
		Me.btnProcFornecedores.Size = New System.Drawing.Size(34, 27)
		Me.btnProcFornecedores.TabIndex = 19
		Me.btnProcFornecedores.TabStop = False
		Me.btnProcFornecedores.Text = "..."
		Me.btnProcFornecedores.UseCompatibleTextRendering = True
		Me.btnProcFornecedores.UseVisualStyleBackColor = False
		Me.btnProcFornecedores.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'txtProdutoTipo
		'
		Me.txtProdutoTipo.Location = New System.Drawing.Point(138, 79)
		Me.txtProdutoTipo.MaxLength = 30
		Me.txtProdutoTipo.Name = "txtProdutoTipo"
		Me.txtProdutoTipo.Size = New System.Drawing.Size(239, 27)
		Me.txtProdutoTipo.TabIndex = 7
		'
		'txtFabricante
		'
		Me.txtFabricante.Location = New System.Drawing.Point(138, 145)
		Me.txtFabricante.MaxLength = 30
		Me.txtFabricante.Name = "txtFabricante"
		Me.txtFabricante.Size = New System.Drawing.Size(239, 27)
		Me.txtFabricante.TabIndex = 13
		'
		'Panel2
		'
		Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
		Me.Panel2.Controls.Add(Me.dtpReservaData)
		Me.Panel2.Controls.Add(Me.btnProcFuncionario)
		Me.Panel2.Controls.Add(Me.txtFuncionario)
		Me.Panel2.Controls.Add(Me.Label1)
		Me.Panel2.Controls.Add(Me.Label2)
		Me.Panel2.Location = New System.Drawing.Point(12, 63)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(604, 45)
		Me.Panel2.TabIndex = 1
		'
		'dtpReservaData
		'
		Me.dtpReservaData.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dtpReservaData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dtpReservaData.Location = New System.Drawing.Point(446, 9)
		Me.dtpReservaData.Name = "dtpReservaData"
		Me.dtpReservaData.Size = New System.Drawing.Size(144, 27)
		Me.dtpReservaData.TabIndex = 4
		'
		'Panel3
		'
		Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
		Me.Panel3.Controls.Add(Me.lblTelefoneB)
		Me.Panel3.Controls.Add(Me.lblClienteEmail)
		Me.Panel3.Controls.Add(Me.lblTelefoneA)
		Me.Panel3.Controls.Add(Me.picWathsapp)
		Me.Panel3.Controls.Add(Me.txtClienteNome)
		Me.Panel3.Controls.Add(Me.Label19)
		Me.Panel3.Controls.Add(Me.Label16)
		Me.Panel3.Controls.Add(Me.btnClienteSimples)
		Me.Panel3.Controls.Add(Me.btnClienteSimplesEditar)
		Me.Panel3.Controls.Add(Me.Label9)
		Me.Panel3.Controls.Add(Me.Label10)
		Me.Panel3.Location = New System.Drawing.Point(12, 138)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(604, 115)
		Me.Panel3.TabIndex = 4
		'
		'lblTelefoneB
		'
		Me.lblTelefoneB.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblTelefoneB.ForeColor = System.Drawing.Color.Black
		Me.lblTelefoneB.Location = New System.Drawing.Point(351, 45)
		Me.lblTelefoneB.Name = "lblTelefoneB"
		Me.lblTelefoneB.Size = New System.Drawing.Size(159, 27)
		Me.lblTelefoneB.TabIndex = 6
		Me.lblTelefoneB.Text = "Telefone"
		Me.lblTelefoneB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblClienteEmail
		'
		Me.lblClienteEmail.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblClienteEmail.ForeColor = System.Drawing.Color.Black
		Me.lblClienteEmail.Location = New System.Drawing.Point(139, 78)
		Me.lblClienteEmail.Name = "lblClienteEmail"
		Me.lblClienteEmail.Size = New System.Drawing.Size(371, 27)
		Me.lblClienteEmail.TabIndex = 9
		Me.lblClienteEmail.Text = "Telefone"
		Me.lblClienteEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblTelefoneA
		'
		Me.lblTelefoneA.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblTelefoneA.ForeColor = System.Drawing.Color.Black
		Me.lblTelefoneA.Location = New System.Drawing.Point(139, 45)
		Me.lblTelefoneA.Name = "lblTelefoneA"
		Me.lblTelefoneA.Size = New System.Drawing.Size(144, 27)
		Me.lblTelefoneA.TabIndex = 4
		Me.lblTelefoneA.Text = "Telefone"
		Me.lblTelefoneA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'picWathsapp
		'
		Me.picWathsapp.Image = Global.NovaSiao.My.Resources.Resources.whatsapp_32
		Me.picWathsapp.Location = New System.Drawing.Point(518, 46)
		Me.picWathsapp.Name = "picWathsapp"
		Me.picWathsapp.Size = New System.Drawing.Size(25, 25)
		Me.picWathsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picWathsapp.TabIndex = 44
		Me.picWathsapp.TabStop = False
		'
		'btnClienteSimples
		'
		Me.btnClienteSimples.AllowAnimations = True
		Me.btnClienteSimples.BackColor = System.Drawing.Color.Transparent
		Me.btnClienteSimples.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnClienteSimples.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnClienteSimples.Image = Global.NovaSiao.My.Resources.Resources.search_peq
		Me.btnClienteSimples.ImageAbsolutePosition = New System.Drawing.Point(5, 2)
		Me.btnClienteSimples.Location = New System.Drawing.Point(516, 12)
		Me.btnClienteSimples.Name = "btnClienteSimples"
		Me.btnClienteSimples.RoundedCornersMask = CType(15, Byte)
		Me.btnClienteSimples.RoundedCornersRadius = 0
		Me.btnClienteSimples.Size = New System.Drawing.Size(34, 27)
		Me.btnClienteSimples.TabIndex = 2
		Me.btnClienteSimples.TabStop = False
		Me.btnClienteSimples.UseAbsoluteImagePositioning = True
		Me.btnClienteSimples.UseCompatibleTextRendering = True
		Me.btnClienteSimples.UseVisualStyleBackColor = False
		Me.btnClienteSimples.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'btnClienteSimplesEditar
		'
		Me.btnClienteSimplesEditar.AllowAnimations = True
		Me.btnClienteSimplesEditar.BackColor = System.Drawing.Color.Transparent
		Me.btnClienteSimplesEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnClienteSimplesEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnClienteSimplesEditar.Image = Global.NovaSiao.My.Resources.Resources.edit
		Me.btnClienteSimplesEditar.ImageAbsolutePosition = New System.Drawing.Point(6, 3)
		Me.btnClienteSimplesEditar.Location = New System.Drawing.Point(556, 12)
		Me.btnClienteSimplesEditar.Name = "btnClienteSimplesEditar"
		Me.btnClienteSimplesEditar.RoundedCornersMask = CType(15, Byte)
		Me.btnClienteSimplesEditar.RoundedCornersRadius = 0
		Me.btnClienteSimplesEditar.Size = New System.Drawing.Size(34, 27)
		Me.btnClienteSimplesEditar.TabIndex = 2
		Me.btnClienteSimplesEditar.TabStop = False
		Me.btnClienteSimplesEditar.UseAbsoluteImagePositioning = True
		Me.btnClienteSimplesEditar.UseCompatibleTextRendering = True
		Me.btnClienteSimplesEditar.UseVisualStyleBackColor = False
		Me.btnClienteSimplesEditar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'Panel4
		'
		Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
		Me.Panel4.Controls.Add(Me.txtRGProduto)
		Me.Panel4.Controls.Add(Me.lblProdConhecido)
		Me.Panel4.Controls.Add(Me.lblValorAntecipado)
		Me.Panel4.Controls.Add(Me.chkProdutoConhecido)
		Me.Panel4.Controls.Add(Me.btnProcFabricantes)
		Me.Panel4.Controls.Add(Me.Label18)
		Me.Panel4.Controls.Add(Me.Label21)
		Me.Panel4.Controls.Add(Me.lblRG)
		Me.Panel4.Controls.Add(Me.btnProcFornecedores)
		Me.Panel4.Controls.Add(Me.btnProcAutores)
		Me.Panel4.Controls.Add(Me.txtAutor)
		Me.Panel4.Controls.Add(Me.Label14)
		Me.Panel4.Controls.Add(Me.txtPVenda)
		Me.Panel4.Controls.Add(Me.Label7)
		Me.Panel4.Controls.Add(Me.Label13)
		Me.Panel4.Controls.Add(Me.btnProcProdutoTipo)
		Me.Panel4.Controls.Add(Me.Label12)
		Me.Panel4.Controls.Add(Me.txtFabricante)
		Me.Panel4.Controls.Add(Me.txtProdutoTipo)
		Me.Panel4.Controls.Add(Me.txtProduto)
		Me.Panel4.Controls.Add(Me.txtFornecedor)
		Me.Panel4.Controls.Add(Me.Label11)
		Me.Panel4.Location = New System.Drawing.Point(12, 284)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(604, 251)
		Me.Panel4.TabIndex = 6
		'
		'txtRGProduto
		'
		Me.txtRGProduto.Location = New System.Drawing.Point(450, 13)
		Me.txtRGProduto.Name = "txtRGProduto"
		Me.txtRGProduto.Size = New System.Drawing.Size(100, 27)
		Me.txtRGProduto.TabIndex = 3
		Me.txtRGProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblProdConhecido
		'
		Me.lblProdConhecido.Location = New System.Drawing.Point(191, 14)
		Me.lblProdConhecido.Name = "lblProdConhecido"
		Me.lblProdConhecido.Size = New System.Drawing.Size(187, 19)
		Me.lblProdConhecido.TabIndex = 1
		Me.lblProdConhecido.Text = "Produto Conhecido"
		'
		'lblValorAntecipado
		'
		Me.lblValorAntecipado.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblValorAntecipado.ForeColor = System.Drawing.Color.Black
		Me.lblValorAntecipado.Location = New System.Drawing.Point(434, 178)
		Me.lblValorAntecipado.Name = "lblValorAntecipado"
		Me.lblValorAntecipado.Size = New System.Drawing.Size(116, 27)
		Me.lblValorAntecipado.TabIndex = 4
		Me.lblValorAntecipado.Text = "R$ 0,00"
		Me.lblValorAntecipado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'chkProdutoConhecido
		'
		Me.chkProdutoConhecido.Appearance = System.Windows.Forms.Appearance.Button
		Me.chkProdutoConhecido.BackColor = System.Drawing.Color.Transparent
		Me.chkProdutoConhecido.BackgroundImage = CType(resources.GetObject("chkProdutoConhecido.BackgroundImage"), System.Drawing.Image)
		Me.chkProdutoConhecido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.chkProdutoConhecido.FlatAppearance.BorderColor = System.Drawing.Color.Gray
		Me.chkProdutoConhecido.FlatAppearance.BorderSize = 0
		Me.chkProdutoConhecido.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
		Me.chkProdutoConhecido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.chkProdutoConhecido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.chkProdutoConhecido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chkProdutoConhecido.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkProdutoConhecido.Location = New System.Drawing.Point(137, 12)
		Me.chkProdutoConhecido.Margin = New System.Windows.Forms.Padding(0)
		Me.chkProdutoConhecido.Name = "chkProdutoConhecido"
		Me.chkProdutoConhecido.Size = New System.Drawing.Size(50, 23)
		Me.chkProdutoConhecido.TabIndex = 0
		Me.chkProdutoConhecido.UseVisualStyleBackColor = False
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(291, 181)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(137, 19)
		Me.Label7.TabIndex = 15
		Me.Label7.Text = "Valor Adiantamento"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.Gray
		Me.Label4.Location = New System.Drawing.Point(15, 116)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(56, 19)
		Me.Label4.TabIndex = 2
		Me.Label4.Text = "Cliente"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
		Me.Label5.ForeColor = System.Drawing.Color.Gray
		Me.Label5.Location = New System.Drawing.Point(15, 262)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(135, 19)
		Me.Label5.TabIndex = 5
		Me.Label5.Text = "Produto | Reserva"
		'
		'Panel5
		'
		Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
		Me.Panel5.Controls.Add(Me.txtObservacao)
		Me.Panel5.Controls.Add(Me.Label3)
		Me.Panel5.Location = New System.Drawing.Point(12, 545)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(604, 72)
		Me.Panel5.TabIndex = 7
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Silver
		Me.Label6.Location = New System.Drawing.Point(211, 4)
		Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(39, 13)
		Me.Label6.TabIndex = 3
		Me.Label6.Text = "Filial"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblFilial
		'
		Me.lblFilial.BackColor = System.Drawing.Color.Transparent
		Me.lblFilial.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
		Me.lblFilial.Location = New System.Drawing.Point(128, 17)
		Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lblFilial.Name = "lblFilial"
		Me.lblFilial.Size = New System.Drawing.Size(204, 30)
		Me.lblFilial.TabIndex = 2
		Me.lblFilial.Text = "Filial"
		Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'frmReserva
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(627, 674)
		Me.Controls.Add(Me.tsMenu)
		Me.Controls.Add(Me.Panel5)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Panel4)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel2)
		Me.KeyPreview = True
		Me.Name = "frmReserva"
		Me.Controls.SetChildIndex(Me.Panel2, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Panel3, 0)
		Me.Controls.SetChildIndex(Me.Panel4, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.Label5, 0)
		Me.Controls.SetChildIndex(Me.Panel5, 0)
		Me.Controls.SetChildIndex(Me.tsMenu, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.tsMenu.ResumeLayout(False)
		Me.tsMenu.PerformLayout()
		CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		Me.Panel2.PerformLayout()
		Me.Panel3.ResumeLayout(False)
		Me.Panel3.PerformLayout()
		CType(Me.picWathsapp, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel4.ResumeLayout(False)
		Me.Panel4.PerformLayout()
		Me.Panel5.ResumeLayout(False)
		Me.Panel5.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtProduto As TextBox
	Friend WithEvents Label16 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents txtFuncionario As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents tsMenu As ToolStrip
	Friend WithEvents btnNovo As ToolStripButton
	Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
	Friend WithEvents btnSalvar As ToolStripButton
	Friend WithEvents btnCancelar As ToolStripButton
	Friend WithEvents btnProcurar As ToolStripButton
	Friend WithEvents Label11 As Label
	Friend WithEvents txtFornecedor As TextBox
	Friend WithEvents lblIDReserva As Label
	Friend WithEvents lbl_IdTexto As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents txtObservacao As TextBox
	Friend WithEvents EProvider As ErrorProvider
	Friend WithEvents btnProcProdutoTipo As VIBlend.WinForms.Controls.vButton
	Friend WithEvents Label12 As Label
	Friend WithEvents txtPVenda As Controles.Text_Monetario
	Friend WithEvents Label13 As Label
	Friend WithEvents btnProcAutores As VIBlend.WinForms.Controls.vButton
	Friend WithEvents txtAutor As TextBox
	Friend WithEvents Label14 As Label
	Friend WithEvents txtClienteNome As TextBox
	Friend WithEvents Label19 As Label
	Friend WithEvents btnProcFuncionario As VIBlend.WinForms.Controls.vButton
	Friend WithEvents lblRG As Label
	Friend WithEvents Label21 As Label
	Friend WithEvents btnProcFabricantes As VIBlend.WinForms.Controls.vButton
	Friend WithEvents Label18 As Label
	Friend WithEvents btnProcFornecedores As VIBlend.WinForms.Controls.vButton
	Friend WithEvents txtFabricante As TextBox
	Friend WithEvents txtProdutoTipo As TextBox
	Friend WithEvents Panel3 As Panel
	Friend WithEvents Panel4 As Panel
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents picWathsapp As PictureBox
	Friend WithEvents Panel5 As Panel
	Friend WithEvents lblProdConhecido As Label
	Friend WithEvents chkProdutoConhecido As CheckedButton_OnOff.CheckedButton_OnOff
	Friend WithEvents lblFilial As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents txtRGProduto As TextBox
	Friend WithEvents btnFechar As ToolStripButton
	Friend WithEvents Panel2 As Panel
	Friend WithEvents dtpReservaData As DateTimePicker
	Friend WithEvents btnClienteSimplesEditar As VIBlend.WinForms.Controls.vButton
	Friend WithEvents lblTelefoneB As Label
	Friend WithEvents lblClienteEmail As Label
	Friend WithEvents lblTelefoneA As Label
	Friend WithEvents btnClienteSimples As VIBlend.WinForms.Controls.vButton
	Friend WithEvents lblValorAntecipado As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents btnAdiantamento As ToolStripButton
End Class
