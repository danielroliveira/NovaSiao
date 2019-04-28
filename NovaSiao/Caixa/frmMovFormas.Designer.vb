<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovFormas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovFormas))
        Me.lstFormas = New ComponentOwl.BetterListView.BetterListView()
        Me.clnIDMovForma = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnMovForma = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.txtMovForma = New System.Windows.Forms.TextBox()
        Me.txtComissao = New Controles.Text_SoNumeros()
        Me.txtNoDias = New Controles.Text_SoNumeros()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblIDMovForma = New System.Windows.Forms.Label()
        Me.epValida = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtParcelas = New Controles.Text_SoNumeros()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.btnMovTipos = New VIBlend.WinForms.Controls.vButton()
        Me.txtMovTipo = New System.Windows.Forms.TextBox()
        Me.txtCartao = New System.Windows.Forms.TextBox()
        Me.btnCartao = New VIBlend.WinForms.Controls.vButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtConta = New System.Windows.Forms.TextBox()
        Me.btnContaEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.Panel1.SuspendLayout()
        CType(Me.lstFormas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(740, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(427, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(313, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Formas de Movimentação"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstFormas
        '
        Me.lstFormas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstFormas.ColorSortedColumn = System.Drawing.Color.LightBlue
        Me.lstFormas.Columns.Add(Me.clnIDMovForma)
        Me.lstFormas.Columns.Add(Me.clnMovForma)
        Me.lstFormas.DisplayMember = "IDMovForma"
        Me.lstFormas.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFormas.FontColumns = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFormas.ForeColor = System.Drawing.Color.Black
        Me.lstFormas.ForeColorColumns = System.Drawing.Color.Black
        Me.lstFormas.ForeColorGroups = System.Drawing.SystemColors.MenuHighlight
        Me.lstFormas.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid
        Me.lstFormas.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
        Me.lstFormas.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstFormas.Location = New System.Drawing.Point(12, 65)
        Me.lstFormas.MultiSelect = False
        Me.lstFormas.Name = "lstFormas"
        Me.lstFormas.Size = New System.Drawing.Size(324, 285)
        Me.lstFormas.TabIndex = 1
        '
        'clnIDMovForma
        '
        Me.clnIDMovForma.AllowResize = False
        Me.clnIDMovForma.DisplayMember = "IDMovForma"
        Me.clnIDMovForma.Name = "clnIDMovForma"
        Me.clnIDMovForma.Text = "Reg."
        Me.clnIDMovForma.ValueMember = "IDMovForma"
        Me.clnIDMovForma.Width = 50
        '
        'clnMovForma
        '
        Me.clnMovForma.AllowResize = False
        Me.clnMovForma.DisplayMember = "MovForma"
        Me.clnMovForma.Name = "clnMovForma"
        Me.clnMovForma.Text = "Descrição"
        Me.clnMovForma.ValueMember = "MovForma"
        Me.clnMovForma.Width = 220
        '
        'txtMovForma
        '
        Me.txtMovForma.Location = New System.Drawing.Point(466, 98)
        Me.txtMovForma.MaxLength = 30
        Me.txtMovForma.Name = "txtMovForma"
        Me.txtMovForma.Size = New System.Drawing.Size(234, 27)
        Me.txtMovForma.TabIndex = 5
        '
        'txtComissao
        '
        Me.txtComissao.Inteiro = False
        Me.txtComissao.Location = New System.Drawing.Point(632, 230)
        Me.txtComissao.MaxLength = 10
        Me.txtComissao.Name = "txtComissao"
        Me.txtComissao.Size = New System.Drawing.Size(68, 27)
        Me.txtComissao.TabIndex = 18
        Me.txtComissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoDias
        '
        Me.txtNoDias.Inteiro = True
        Me.txtNoDias.Location = New System.Drawing.Point(632, 263)
        Me.txtNoDias.Name = "txtNoDias"
        Me.txtNoDias.Size = New System.Drawing.Size(68, 27)
        Me.txtNoDias.TabIndex = 20
        Me.txtNoDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(423, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(387, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Descrição"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(356, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 19)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Tipo do Cartão"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(396, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Parcelas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(529, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 19)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Comissão (%)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(470, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 19)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Primeira Parcela (dias)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 362)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tsMenu)
        Me.SplitContainer1.Panel2Collapsed = True
        Me.SplitContainer1.Size = New System.Drawing.Size(740, 48)
        Me.SplitContainer1.SplitterDistance = 600
        Me.SplitContainer1.TabIndex = 21
        Me.SplitContainer1.TabStop = False
        '
        'tsMenu
        '
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovo, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnExcluir, Me.btnAtivo, Me.btnFechar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.tsMenu.Size = New System.Drawing.Size(740, 48)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Adicionar1
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(76, 45)
        Me.btnNovo.Text = "&Novo"
        Me.btnNovo.ToolTipText = "Nova Forma"
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
        Me.btnSalvar.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(82, 45)
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.ToolTipText = "Salvar Edição"
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
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(86, 45)
        Me.btnExcluir.Text = "E&xcluir"
        Me.btnExcluir.ToolTipText = "Excluir Forma"
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
        Me.btnAtivo.Size = New System.Drawing.Size(167, 41)
        Me.btnAtivo.Text = "Forma Ativa"
        Me.btnAtivo.ToolTipText = "Ativar/Desativar Forma"
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(418, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 19)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Reg."
        '
        'lblIDMovForma
        '
        Me.lblIDMovForma.BackColor = System.Drawing.Color.White
        Me.lblIDMovForma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIDMovForma.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDMovForma.Location = New System.Drawing.Point(466, 65)
        Me.lblIDMovForma.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIDMovForma.Name = "lblIDMovForma"
        Me.lblIDMovForma.Size = New System.Drawing.Size(63, 27)
        Me.lblIDMovForma.TabIndex = 3
        Me.lblIDMovForma.Text = "0000"
        Me.lblIDMovForma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'epValida
        '
        Me.epValida.ContainerControl = Me
        '
        'txtParcelas
        '
        Me.txtParcelas.Inteiro = True
        Me.txtParcelas.Location = New System.Drawing.Point(466, 230)
        Me.txtParcelas.Name = "txtParcelas"
        Me.txtParcelas.Size = New System.Drawing.Size(45, 27)
        Me.txtParcelas.TabIndex = 16
        Me.txtParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.CausesValidation = False
        Me.btnClose.Location = New System.Drawing.Point(709, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(19, 20)
        Me.btnClose.TabIndex = 3
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'btnMovTipos
        '
        Me.btnMovTipos.AllowAnimations = True
        Me.btnMovTipos.BackColor = System.Drawing.Color.Transparent
        Me.btnMovTipos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMovTipos.FlatAppearance.BorderSize = 0
        Me.btnMovTipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMovTipos.Image = CType(resources.GetObject("btnMovTipos.Image"), System.Drawing.Image)
        Me.btnMovTipos.ImageAbsolutePosition = New System.Drawing.Point(0, 0)
        Me.btnMovTipos.Location = New System.Drawing.Point(673, 131)
        Me.btnMovTipos.Name = "btnMovTipos"
        Me.btnMovTipos.RoundedCornersMask = CType(15, Byte)
        Me.btnMovTipos.RoundedCornersRadius = 2
        Me.btnMovTipos.Size = New System.Drawing.Size(27, 27)
        Me.btnMovTipos.StretchImage = True
        Me.btnMovTipos.TabIndex = 8
        Me.btnMovTipos.TabStop = False
        Me.btnMovTipos.UseAbsoluteImagePositioning = True
        Me.btnMovTipos.UseVisualStyleBackColor = True
        Me.btnMovTipos.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICESILVER
        '
        'txtMovTipo
        '
        Me.txtMovTipo.Location = New System.Drawing.Point(466, 131)
        Me.txtMovTipo.Name = "txtMovTipo"
        Me.txtMovTipo.Size = New System.Drawing.Size(201, 27)
        Me.txtMovTipo.TabIndex = 7
        '
        'txtCartao
        '
        Me.txtCartao.Location = New System.Drawing.Point(466, 164)
        Me.txtCartao.Name = "txtCartao"
        Me.txtCartao.Size = New System.Drawing.Size(201, 27)
        Me.txtCartao.TabIndex = 10
        '
        'btnCartao
        '
        Me.btnCartao.AllowAnimations = True
        Me.btnCartao.BackColor = System.Drawing.Color.Transparent
        Me.btnCartao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCartao.FlatAppearance.BorderSize = 0
        Me.btnCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCartao.Image = CType(resources.GetObject("btnCartao.Image"), System.Drawing.Image)
        Me.btnCartao.ImageAbsolutePosition = New System.Drawing.Point(0, 0)
        Me.btnCartao.Location = New System.Drawing.Point(673, 164)
        Me.btnCartao.Name = "btnCartao"
        Me.btnCartao.RoundedCornersMask = CType(15, Byte)
        Me.btnCartao.RoundedCornersRadius = 2
        Me.btnCartao.Size = New System.Drawing.Size(27, 27)
        Me.btnCartao.StretchImage = True
        Me.btnCartao.TabIndex = 11
        Me.btnCartao.TabStop = False
        Me.btnCartao.UseAbsoluteImagePositioning = True
        Me.btnCartao.UseVisualStyleBackColor = True
        Me.btnCartao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICESILVER
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label18.Location = New System.Drawing.Point(101, 3)
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
        Me.lblFilial.Location = New System.Drawing.Point(4, 15)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(240, 30)
        Me.lblFilial.TabIndex = 0
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(359, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 19)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Conta Destino"
        '
        'txtConta
        '
        Me.txtConta.Location = New System.Drawing.Point(466, 197)
        Me.txtConta.Name = "txtConta"
        Me.txtConta.Size = New System.Drawing.Size(201, 27)
        Me.txtConta.TabIndex = 13
        '
        'btnContaEscolher
        '
        Me.btnContaEscolher.AllowAnimations = True
        Me.btnContaEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnContaEscolher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnContaEscolher.FlatAppearance.BorderSize = 0
        Me.btnContaEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContaEscolher.Image = CType(resources.GetObject("btnContaEscolher.Image"), System.Drawing.Image)
        Me.btnContaEscolher.ImageAbsolutePosition = New System.Drawing.Point(0, 0)
        Me.btnContaEscolher.Location = New System.Drawing.Point(673, 197)
        Me.btnContaEscolher.Name = "btnContaEscolher"
        Me.btnContaEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnContaEscolher.RoundedCornersRadius = 2
        Me.btnContaEscolher.Size = New System.Drawing.Size(27, 27)
        Me.btnContaEscolher.StretchImage = True
        Me.btnContaEscolher.TabIndex = 14
        Me.btnContaEscolher.TabStop = False
        Me.btnContaEscolher.UseAbsoluteImagePositioning = True
        Me.btnContaEscolher.UseVisualStyleBackColor = True
        Me.btnContaEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICESILVER
        '
        'frmMovFormas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(740, 410)
        Me.Controls.Add(Me.btnCartao)
        Me.Controls.Add(Me.btnContaEscolher)
        Me.Controls.Add(Me.txtCartao)
        Me.Controls.Add(Me.txtConta)
        Me.Controls.Add(Me.txtMovTipo)
        Me.Controls.Add(Me.btnMovTipos)
        Me.Controls.Add(Me.txtParcelas)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblIDMovForma)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNoDias)
        Me.Controls.Add(Me.txtComissao)
        Me.Controls.Add(Me.txtMovForma)
        Me.Controls.Add(Me.lstFormas)
        Me.KeyPreview = True
        Me.Name = "frmMovFormas"
        Me.Text = "Formas de Pagamento"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lstFormas, 0)
        Me.Controls.SetChildIndex(Me.txtMovForma, 0)
        Me.Controls.SetChildIndex(Me.txtComissao, 0)
        Me.Controls.SetChildIndex(Me.txtNoDias, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.lblIDMovForma, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtParcelas, 0)
        Me.Controls.SetChildIndex(Me.btnMovTipos, 0)
        Me.Controls.SetChildIndex(Me.txtMovTipo, 0)
        Me.Controls.SetChildIndex(Me.txtConta, 0)
        Me.Controls.SetChildIndex(Me.txtCartao, 0)
        Me.Controls.SetChildIndex(Me.btnContaEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnCartao, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.lstFormas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstFormas As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnIDMovForma As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnMovForma As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents txtMovForma As TextBox
    Friend WithEvents txtComissao As Controles.Text_SoNumeros
    Friend WithEvents txtNoDias As Controles.Text_SoNumeros
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents Label8 As Label
    Friend WithEvents lblIDMovForma As Label
    Friend WithEvents epValida As ErrorProvider
    Friend WithEvents txtParcelas As Controles.Text_SoNumeros
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents btnMovTipos As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtCartao As TextBox
    Friend WithEvents txtMovTipo As TextBox
    Friend WithEvents btnCartao As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label18 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents btnContaEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtConta As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnFechar As ToolStripButton
End Class
