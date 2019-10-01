<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVendaPlanos
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
		Me.txtMeses = New Controles.Text_SoNumeros()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.lblIDPlano = New System.Windows.Forms.Label()
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
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblJuros = New System.Windows.Forms.Label()
		Me.lblMeses = New System.Windows.Forms.Label()
		Me.txtComJuros = New Controles.Text_SoNumeros()
		Me.txtPlano = New System.Windows.Forms.TextBox()
		Me.lstPlanos = New ComponentOwl.BetterListView.BetterListView()
		Me.clnIDPlano = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
		Me.clnPlano = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
		Me.gbEntrada = New System.Windows.Forms.GroupBox()
		Me.rbtComEntradaNao = New System.Windows.Forms.RadioButton()
		Me.rbtComEntradaSim = New System.Windows.Forms.RadioButton()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.epValida = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.Panel1.SuspendLayout()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.tsMenu.SuspendLayout()
		CType(Me.lstPlanos, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.gbEntrada.SuspendLayout()
		CType(Me.epValida, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Size = New System.Drawing.Size(694, 50)
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(372, 0)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(322, 50)
		Me.lblTitulo.Text = "Planos de Venda - Crediário"
		Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtMeses
		'
		Me.txtMeses.Inteiro = True
		Me.txtMeses.Location = New System.Drawing.Point(437, 192)
		Me.txtMeses.Name = "txtMeses"
		Me.txtMeses.Size = New System.Drawing.Size(45, 27)
		Me.txtMeses.TabIndex = 4
		Me.txtMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.Location = New System.Drawing.Point(393, 74)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(38, 19)
		Me.Label8.TabIndex = 45
		Me.Label8.Text = "Reg."
		'
		'lblIDPlano
		'
		Me.lblIDPlano.BackColor = System.Drawing.Color.White
		Me.lblIDPlano.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblIDPlano.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIDPlano.Location = New System.Drawing.Point(437, 70)
		Me.lblIDPlano.Margin = New System.Windows.Forms.Padding(0)
		Me.lblIDPlano.Name = "lblIDPlano"
		Me.lblIDPlano.Size = New System.Drawing.Size(63, 27)
		Me.lblIDPlano.TabIndex = 1
		Me.lblIDPlano.Text = "00"
		Me.lblIDPlano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'SplitContainer1
		'
		Me.SplitContainer1.BackColor = System.Drawing.Color.AntiqueWhite
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.SplitContainer1.IsSplitterFixed = True
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 384)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.tsMenu)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.btnFechar)
		Me.SplitContainer1.Size = New System.Drawing.Size(694, 48)
		Me.SplitContainer1.SplitterDistance = 585
		Me.SplitContainer1.TabIndex = 6
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
		Me.tsMenu.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
		Me.tsMenu.Size = New System.Drawing.Size(585, 48)
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
		Me.btnNovo.ToolTipText = "Novo Plano"
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
		Me.btnExcluir.ToolTipText = "Excluir Plano"
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
		Me.btnAtivo.Text = "Plano Ativo"
		Me.btnAtivo.ToolTipText = "Ativar/Desativar Plano"
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
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(358, 106)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(73, 19)
		Me.Label2.TabIndex = 34
		Me.Label2.Text = "Descrição"
		'
		'lblJuros
		'
		Me.lblJuros.AutoSize = True
		Me.lblJuros.Location = New System.Drawing.Point(530, 195)
		Me.lblJuros.Name = "lblJuros"
		Me.lblJuros.Size = New System.Drawing.Size(67, 19)
		Me.lblJuros.TabIndex = 35
		Me.lblJuros.Text = "Juros (%)"
		'
		'lblMeses
		'
		Me.lblMeses.AutoSize = True
		Me.lblMeses.Location = New System.Drawing.Point(379, 195)
		Me.lblMeses.Name = "lblMeses"
		Me.lblMeses.Size = New System.Drawing.Size(52, 19)
		Me.lblMeses.TabIndex = 37
		Me.lblMeses.Text = "Meses"
		'
		'txtComJuros
		'
		Me.txtComJuros.Inteiro = False
		Me.txtComJuros.Location = New System.Drawing.Point(603, 192)
		Me.txtComJuros.MaxLength = 10
		Me.txtComJuros.Name = "txtComJuros"
		Me.txtComJuros.Size = New System.Drawing.Size(68, 27)
		Me.txtComJuros.TabIndex = 5
		Me.txtComJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtPlano
		'
		Me.txtPlano.Location = New System.Drawing.Point(437, 103)
		Me.txtPlano.MaxLength = 30
		Me.txtPlano.Name = "txtPlano"
		Me.txtPlano.Size = New System.Drawing.Size(234, 27)
		Me.txtPlano.TabIndex = 2
		'
		'lstPlanos
		'
		Me.lstPlanos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lstPlanos.ColorSortedColumn = System.Drawing.Color.LightBlue
		Me.lstPlanos.Columns.Add(Me.clnIDPlano)
		Me.lstPlanos.Columns.Add(Me.clnPlano)
		Me.lstPlanos.DisplayMember = "IDPlanos"
		Me.lstPlanos.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstPlanos.FontColumns = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstPlanos.ForeColor = System.Drawing.Color.Black
		Me.lstPlanos.ForeColorColumns = System.Drawing.Color.Black
		Me.lstPlanos.ForeColorGroups = System.Drawing.SystemColors.MenuHighlight
		Me.lstPlanos.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid
		Me.lstPlanos.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
		Me.lstPlanos.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
		Me.lstPlanos.Location = New System.Drawing.Point(12, 67)
		Me.lstPlanos.MultiSelect = False
		Me.lstPlanos.Name = "lstPlanos"
		Me.lstPlanos.Size = New System.Drawing.Size(324, 285)
		Me.lstPlanos.TabIndex = 0
		'
		'clnIDPlano
		'
		Me.clnIDPlano.AllowResize = False
		Me.clnIDPlano.DisplayMember = "IDPlanos"
		Me.clnIDPlano.Name = "clnIDPlano"
		Me.clnIDPlano.Text = "Reg."
		Me.clnIDPlano.Width = 50
		'
		'clnPlano
		'
		Me.clnPlano.AllowResize = False
		Me.clnPlano.DisplayMember = "MovForma"
		Me.clnPlano.Name = "clnPlano"
		Me.clnPlano.Text = "Descrição"
		Me.clnPlano.Width = 220
		'
		'gbEntrada
		'
		Me.gbEntrada.Controls.Add(Me.rbtComEntradaNao)
		Me.gbEntrada.Controls.Add(Me.rbtComEntradaSim)
		Me.gbEntrada.Location = New System.Drawing.Point(437, 136)
		Me.gbEntrada.Name = "gbEntrada"
		Me.gbEntrada.Size = New System.Drawing.Size(164, 50)
		Me.gbEntrada.TabIndex = 3
		Me.gbEntrada.TabStop = False
		Me.gbEntrada.Text = "Com Entrada"
		'
		'rbtComEntradaNao
		'
		Me.rbtComEntradaNao.AutoSize = True
		Me.rbtComEntradaNao.Location = New System.Drawing.Point(92, 21)
		Me.rbtComEntradaNao.Name = "rbtComEntradaNao"
		Me.rbtComEntradaNao.Size = New System.Drawing.Size(53, 23)
		Me.rbtComEntradaNao.TabIndex = 0
		Me.rbtComEntradaNao.TabStop = True
		Me.rbtComEntradaNao.Text = "Não"
		Me.rbtComEntradaNao.UseVisualStyleBackColor = True
		'
		'rbtComEntradaSim
		'
		Me.rbtComEntradaSim.AutoSize = True
		Me.rbtComEntradaSim.Location = New System.Drawing.Point(15, 21)
		Me.rbtComEntradaSim.Name = "rbtComEntradaSim"
		Me.rbtComEntradaSim.Size = New System.Drawing.Size(50, 23)
		Me.rbtComEntradaSim.TabIndex = 0
		Me.rbtComEntradaSim.TabStop = True
		Me.rbtComEntradaSim.Text = "Sim"
		Me.rbtComEntradaSim.UseVisualStyleBackColor = True
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.CausesValidation = False
		Me.btnClose.Location = New System.Drawing.Point(663, 12)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RibbonStyle = False
		Me.btnClose.RoundedCornersMask = CType(15, Byte)
		Me.btnClose.ShowFocusRectangle = False
		Me.btnClose.Size = New System.Drawing.Size(19, 20)
		Me.btnClose.TabIndex = 28
		Me.btnClose.TabStop = False
		Me.btnClose.UseVisualStyleBackColor = False
		Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
		'
		'epValida
		'
		Me.epValida.ContainerControl = Me
		'
		'frmVendaPlanos
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(694, 432)
		Me.Controls.Add(Me.gbEntrada)
		Me.Controls.Add(Me.txtMeses)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.lblIDPlano)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.lblJuros)
		Me.Controls.Add(Me.lblMeses)
		Me.Controls.Add(Me.txtComJuros)
		Me.Controls.Add(Me.txtPlano)
		Me.Controls.Add(Me.lstPlanos)
		Me.Name = "frmVendaPlanos"
		Me.Text = "Planos de Venda"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.lstPlanos, 0)
		Me.Controls.SetChildIndex(Me.txtPlano, 0)
		Me.Controls.SetChildIndex(Me.txtComJuros, 0)
		Me.Controls.SetChildIndex(Me.lblMeses, 0)
		Me.Controls.SetChildIndex(Me.lblJuros, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
		Me.Controls.SetChildIndex(Me.lblIDPlano, 0)
		Me.Controls.SetChildIndex(Me.Label8, 0)
		Me.Controls.SetChildIndex(Me.txtMeses, 0)
		Me.Controls.SetChildIndex(Me.gbEntrada, 0)
		Me.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.tsMenu.ResumeLayout(False)
		Me.tsMenu.PerformLayout()
		CType(Me.lstPlanos, System.ComponentModel.ISupportInitialize).EndInit()
		Me.gbEntrada.ResumeLayout(False)
		Me.gbEntrada.PerformLayout()
		CType(Me.epValida, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtMeses As Controles.Text_SoNumeros
    Friend WithEvents Label8 As Label
    Friend WithEvents lblIDPlano As Label
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
    Friend WithEvents Label2 As Label
    Friend WithEvents lblJuros As Label
    Friend WithEvents lblMeses As Label
    Friend WithEvents txtComJuros As Controles.Text_SoNumeros
    Friend WithEvents txtPlano As TextBox
    Friend WithEvents lstPlanos As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnIDPlano As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnPlano As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents gbEntrada As GroupBox
    Friend WithEvents rbtComEntradaNao As RadioButton
    Friend WithEvents rbtComEntradaSim As RadioButton
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents epValida As ErrorProvider
End Class
