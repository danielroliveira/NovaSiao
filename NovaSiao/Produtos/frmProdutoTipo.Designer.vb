<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProdutoTipo
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvTipos = New System.Windows.Forms.DataGridView()
        Me.clnIDProdutoTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSubTipo = New System.Windows.Forms.DataGridView()
        Me.clnIDProdutoSubTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvCategoria = New System.Windows.Forms.DataGridView()
        Me.clnIDCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.tabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
        Me.VTabTipos = New VIBlend.WinForms.Controls.vTabPage()
        Me.VTabSubTipo = New VIBlend.WinForms.Controls.vTabPage()
        Me.lblTipo1 = New System.Windows.Forms.Label()
        Me.VTabCategoria = New VIBlend.WinForms.Controls.vTabPage()
        Me.lblTipo2 = New System.Windows.Forms.Label()
        Me.MenuSuspenso = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AtivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSubTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrincipal.SuspendLayout()
        Me.VTabTipos.SuspendLayout()
        Me.VTabSubTipo.SuspendLayout()
        Me.VTabCategoria.SuspendLayout()
        Me.MenuSuspenso.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(475, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(159, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(316, 50)
        Me.lblTitulo.Text = "Controle de Tipos de Produto"
        '
        'dgvTipos
        '
        Me.dgvTipos.AllowUserToAddRows = False
        Me.dgvTipos.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvTipos.ColumnHeadersHeight = 27
        Me.dgvTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTipos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDProdutoTipo})
        Me.dgvTipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTipos.EnableHeadersVisualStyles = False
        Me.dgvTipos.Location = New System.Drawing.Point(4, 4)
        Me.dgvTipos.MultiSelect = False
        Me.dgvTipos.Name = "dgvTipos"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvTipos.RowHeadersWidth = 37
        Me.dgvTipos.RowTemplate.Height = 30
        Me.dgvTipos.Size = New System.Drawing.Size(435, 371)
        Me.dgvTipos.TabIndex = 2
        '
        'clnIDProdutoTipo
        '
        Me.clnIDProdutoTipo.DataPropertyName = "IDProdutoTipo"
        Me.clnIDProdutoTipo.HeaderText = "Reg."
        Me.clnIDProdutoTipo.Name = "clnIDProdutoTipo"
        Me.clnIDProdutoTipo.ReadOnly = True
        '
        'dgvSubTipo
        '
        Me.dgvSubTipo.AllowUserToAddRows = False
        Me.dgvSubTipo.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubTipo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvSubTipo.ColumnHeadersHeight = 27
        Me.dgvSubTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSubTipo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDProdutoSubTipo})
        Me.dgvSubTipo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvSubTipo.EnableHeadersVisualStyles = False
        Me.dgvSubTipo.Location = New System.Drawing.Point(4, 33)
        Me.dgvSubTipo.MultiSelect = False
        Me.dgvSubTipo.Name = "dgvSubTipo"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubTipo.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvSubTipo.RowHeadersWidth = 37
        Me.dgvSubTipo.RowTemplate.Height = 30
        Me.dgvSubTipo.Size = New System.Drawing.Size(435, 342)
        Me.dgvSubTipo.TabIndex = 2
        '
        'clnIDProdutoSubTipo
        '
        Me.clnIDProdutoSubTipo.DataPropertyName = "IDProdutoSubTipo"
        Me.clnIDProdutoSubTipo.HeaderText = "Reg."
        Me.clnIDProdutoSubTipo.Name = "clnIDProdutoSubTipo"
        '
        'dgvCategoria
        '
        Me.dgvCategoria.AllowUserToAddRows = False
        Me.dgvCategoria.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCategoria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvCategoria.ColumnHeadersHeight = 27
        Me.dgvCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCategoria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDCategoria})
        Me.dgvCategoria.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvCategoria.EnableHeadersVisualStyles = False
        Me.dgvCategoria.Location = New System.Drawing.Point(4, 33)
        Me.dgvCategoria.MultiSelect = False
        Me.dgvCategoria.Name = "dgvCategoria"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCategoria.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvCategoria.RowHeadersWidth = 37
        Me.dgvCategoria.RowTemplate.Height = 30
        Me.dgvCategoria.Size = New System.Drawing.Size(435, 342)
        Me.dgvCategoria.TabIndex = 2
        '
        'clnIDCategoria
        '
        Me.clnIDCategoria.DataPropertyName = "IDCategoria"
        Me.clnIDCategoria.HeaderText = "Reg."
        Me.clnIDCategoria.Name = "clnIDCategoria"
        '
        'btnFechar
        '
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.Location = New System.Drawing.Point(318, 507)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(137, 52)
        Me.btnFechar.TabIndex = 6
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Adicionar1
        Me.btnNovo.Location = New System.Drawing.Point(12, 507)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(159, 52)
        Me.btnNovo.TabIndex = 5
        Me.btnNovo.Text = "&Novo Tipo"
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.Location = New System.Drawing.Point(177, 507)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(137, 52)
        Me.btnSalvar.TabIndex = 4
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'tabPrincipal
        '
        Me.tabPrincipal.AllowAnimations = True
        Me.tabPrincipal.Controls.Add(Me.VTabTipos)
        Me.tabPrincipal.Controls.Add(Me.VTabSubTipo)
        Me.tabPrincipal.Controls.Add(Me.VTabCategoria)
        Me.tabPrincipal.Location = New System.Drawing.Point(12, 65)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.Padding = New System.Windows.Forms.Padding(0, 45, 0, 0)
        Me.tabPrincipal.Size = New System.Drawing.Size(443, 424)
        Me.tabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
        Me.tabPrincipal.TabIndex = 3
        Me.tabPrincipal.TabPages.Add(Me.VTabTipos)
        Me.tabPrincipal.TabPages.Add(Me.VTabSubTipo)
        Me.tabPrincipal.TabPages.Add(Me.VTabCategoria)
        Me.tabPrincipal.TabsAreaBackColor = System.Drawing.Color.AntiqueWhite
        Me.tabPrincipal.TabsInitialOffset = 20
        Me.tabPrincipal.UseTabsAreaBackColor = True
        Me.tabPrincipal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'VTabTipos
        '
        Me.VTabTipos.Controls.Add(Me.dgvTipos)
        Me.VTabTipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VTabTipos.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabTipos.Location = New System.Drawing.Point(0, 45)
        Me.VTabTipos.Name = "VTabTipos"
        Me.VTabTipos.Padding = New System.Windows.Forms.Padding(0)
        Me.VTabTipos.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabTipos.Size = New System.Drawing.Size(443, 379)
        Me.VTabTipos.TabIndex = 3
        Me.VTabTipos.Text = "Tipos de Produto"
        Me.VTabTipos.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabTipos.TooltipText = "TabPage"
        Me.VTabTipos.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        Me.VTabTipos.Visible = False
        '
        'VTabSubTipo
        '
        Me.VTabSubTipo.Controls.Add(Me.lblTipo1)
        Me.VTabSubTipo.Controls.Add(Me.dgvSubTipo)
        Me.VTabSubTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VTabSubTipo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabSubTipo.Location = New System.Drawing.Point(0, 45)
        Me.VTabSubTipo.Name = "VTabSubTipo"
        Me.VTabSubTipo.Padding = New System.Windows.Forms.Padding(0)
        Me.VTabSubTipo.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabSubTipo.Size = New System.Drawing.Size(443, 379)
        Me.VTabSubTipo.TabIndex = 4
        Me.VTabSubTipo.Text = "Classificação de Tipos"
        Me.VTabSubTipo.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabSubTipo.TooltipText = "TabPage"
        Me.VTabSubTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        Me.VTabSubTipo.Visible = False
        '
        'lblTipo1
        '
        Me.lblTipo1.BackColor = System.Drawing.Color.AliceBlue
        Me.lblTipo1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTipo1.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo1.Location = New System.Drawing.Point(4, 4)
        Me.lblTipo1.Name = "lblTipo1"
        Me.lblTipo1.Size = New System.Drawing.Size(435, 26)
        Me.lblTipo1.TabIndex = 3
        Me.lblTipo1.Text = "Label1"
        Me.lblTipo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VTabCategoria
        '
        Me.VTabCategoria.Controls.Add(Me.lblTipo2)
        Me.VTabCategoria.Controls.Add(Me.dgvCategoria)
        Me.VTabCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VTabCategoria.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabCategoria.Location = New System.Drawing.Point(0, 45)
        Me.VTabCategoria.Name = "VTabCategoria"
        Me.VTabCategoria.Padding = New System.Windows.Forms.Padding(0)
        Me.VTabCategoria.SelectedTextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabCategoria.Size = New System.Drawing.Size(443, 379)
        Me.VTabCategoria.TabIndex = 5
        Me.VTabCategoria.Text = "Categorias"
        Me.VTabCategoria.TextFont = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VTabCategoria.TooltipText = "TabPage"
        Me.VTabCategoria.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        Me.VTabCategoria.Visible = False
        '
        'lblTipo2
        '
        Me.lblTipo2.BackColor = System.Drawing.Color.AliceBlue
        Me.lblTipo2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTipo2.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo2.Location = New System.Drawing.Point(4, 4)
        Me.lblTipo2.Name = "lblTipo2"
        Me.lblTipo2.Size = New System.Drawing.Size(435, 26)
        Me.lblTipo2.TabIndex = 4
        Me.lblTipo2.Text = "Label1"
        Me.lblTipo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuSuspenso
        '
        Me.MenuSuspenso.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtivarToolStripMenuItem, Me.DesativarToolStripMenuItem})
        Me.MenuSuspenso.Name = "MenuSuspenso"
        Me.MenuSuspenso.Size = New System.Drawing.Size(123, 48)
        '
        'AtivarToolStripMenuItem
        '
        Me.AtivarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem"
        Me.AtivarToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.AtivarToolStripMenuItem.Text = "Ativar"
        '
        'DesativarToolStripMenuItem
        '
        Me.DesativarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem"
        Me.DesativarToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.DesativarToolStripMenuItem.Text = "Desativar"
        '
        'frmProdutoTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(475, 572)
        Me.Controls.Add(Me.tabPrincipal)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnSalvar)
        Me.KeyPreview = True
        Me.Name = "frmProdutoTipo"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnSalvar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnNovo, 0)
        Me.Controls.SetChildIndex(Me.tabPrincipal, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSubTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrincipal.ResumeLayout(False)
        Me.VTabTipos.ResumeLayout(False)
        Me.VTabSubTipo.ResumeLayout(False)
        Me.VTabCategoria.ResumeLayout(False)
        Me.MenuSuspenso.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvTipos As DataGridView
    Friend WithEvents dgvSubTipo As DataGridView
    Friend WithEvents dgvCategoria As DataGridView
    Friend WithEvents clnIDProdutoTipo As DataGridViewTextBoxColumn
    Friend WithEvents clnIDProdutoSubTipo As DataGridViewTextBoxColumn
    Friend WithEvents clnIDCategoria As DataGridViewTextBoxColumn
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents tabPrincipal As VIBlend.WinForms.Controls.vTabControl
    Friend WithEvents VTabTipos As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents VTabSubTipo As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents VTabCategoria As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents MenuSuspenso As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblTipo1 As Label
    Friend WithEvents lblTipo2 As Label
End Class
