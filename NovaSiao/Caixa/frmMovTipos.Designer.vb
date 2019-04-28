<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovTipos
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
        Me.lstFormas = New ComponentOwl.BetterListView.BetterListView()
        Me.clnIDMovForma = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnMovForma = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.txtMovTipo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblIDMovTipo = New System.Windows.Forms.Label()
        Me.epValida = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.cmbMeio = New Controles.ComboBox_OnlyValues()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.lstFormas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(740, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(452, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(288, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Tipos de Movimentação"
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
        'txtMovTipo
        '
        Me.txtMovTipo.Location = New System.Drawing.Point(466, 98)
        Me.txtMovTipo.MaxLength = 30
        Me.txtMovTipo.Name = "txtMovTipo"
        Me.txtMovTipo.Size = New System.Drawing.Size(234, 27)
        Me.txtMovTipo.TabIndex = 5
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
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 366)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tsMenu)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFechar)
        Me.SplitContainer1.Size = New System.Drawing.Size(740, 48)
        Me.SplitContainer1.SplitterDistance = 625
        Me.SplitContainer1.TabIndex = 8
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
        Me.tsMenu.Size = New System.Drawing.Size(625, 48)
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
        Me.btnAtivo.Text = "Tipo Ativo"
        Me.btnAtivo.ToolTipText = "Ativar/Desativar Forma"
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
        Me.btnFechar.Location = New System.Drawing.Point(4, 4)
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(97, 40)
        Me.btnFechar.TabIndex = 0
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = False
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
        'lblIDMovTipo
        '
        Me.lblIDMovTipo.BackColor = System.Drawing.Color.White
        Me.lblIDMovTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIDMovTipo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDMovTipo.Location = New System.Drawing.Point(466, 65)
        Me.lblIDMovTipo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIDMovTipo.Name = "lblIDMovTipo"
        Me.lblIDMovTipo.Size = New System.Drawing.Size(63, 27)
        Me.lblIDMovTipo.TabIndex = 3
        Me.lblIDMovTipo.Text = "0000"
        Me.lblIDMovTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'epValida
        '
        Me.epValida.ContainerControl = Me
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
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'cmbMeio
        '
        Me.cmbMeio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMeio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMeio.FormattingEnabled = True
        Me.cmbMeio.Location = New System.Drawing.Point(466, 131)
        Me.cmbMeio.Name = "cmbMeio"
        Me.cmbMeio.RestrictContentToListItems = True
        Me.cmbMeio.Size = New System.Drawing.Size(234, 27)
        Me.cmbMeio.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(366, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Meio de Pag."
        '
        'frmMovTipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(740, 414)
        Me.Controls.Add(Me.cmbMeio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblIDMovTipo)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMovTipo)
        Me.Controls.Add(Me.lstFormas)
        Me.KeyPreview = True
        Me.Name = "frmMovTipos"
        Me.Text = "Tipos de Movimentação"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lstFormas, 0)
        Me.Controls.SetChildIndex(Me.txtMovTipo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.lblIDMovTipo, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.cmbMeio, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstFormas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
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
    Friend WithEvents txtMovTipo As TextBox
    Friend WithEvents Label2 As Label
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
    Friend WithEvents Label8 As Label
    Friend WithEvents lblIDMovTipo As Label
    Friend WithEvents epValida As ErrorProvider
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents cmbMeio As Controles.ComboBox_OnlyValues
    Friend WithEvents Label1 As Label
End Class
