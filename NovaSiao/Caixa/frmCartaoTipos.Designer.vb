<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCartaoTipos
    Inherits NovaSiao.frmModFinBorder

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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.dgvListagem = New System.Windows.Forms.DataGridView()
		Me.IDFabricante = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.btnFechar = New System.Windows.Forms.Button()
		Me.btnNovo = New System.Windows.Forms.Button()
		Me.btnSalvar = New System.Windows.Forms.Button()
		Me.MenuListagem = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.AtivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DesativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.Panel1.SuspendLayout()
		CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MenuListagem.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Size = New System.Drawing.Size(455, 50)
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
		Me.lblTitulo.Location = New System.Drawing.Point(192, 6)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(229, 40)
		Me.lblTitulo.Text = "Bandeiras de Cartão"
		'
		'dgvListagem
		'
		Me.dgvListagem.AllowUserToAddRows = False
		Me.dgvListagem.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvListagem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvListagem.ColumnHeadersHeight = 27
		Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDFabricante})
		Me.dgvListagem.EnableHeadersVisualStyles = False
		Me.dgvListagem.Location = New System.Drawing.Point(10, 62)
		Me.dgvListagem.MultiSelect = False
		Me.dgvListagem.Name = "dgvListagem"
		Me.dgvListagem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvListagem.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.dgvListagem.RowHeadersWidth = 36
		Me.dgvListagem.RowTemplate.Height = 30
		Me.dgvListagem.Size = New System.Drawing.Size(434, 345)
		Me.dgvListagem.TabIndex = 4
		'
		'IDFabricante
		'
		Me.IDFabricante.HeaderText = "Reg."
		Me.IDFabricante.Name = "IDFabricante"
		Me.IDFabricante.ReadOnly = True
		'
		'btnFechar
		'
		Me.btnFechar.CausesValidation = False
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
		Me.btnFechar.Location = New System.Drawing.Point(317, 413)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(127, 41)
		Me.btnFechar.TabIndex = 12
		Me.btnFechar.Text = "&Fechar"
		Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnFechar.UseVisualStyleBackColor = True
		'
		'btnNovo
		'
		Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.btnNovo.Location = New System.Drawing.Point(10, 413)
		Me.btnNovo.Name = "btnNovo"
		Me.btnNovo.Size = New System.Drawing.Size(136, 41)
		Me.btnNovo.TabIndex = 10
		Me.btnNovo.Text = "&Novo Cartão"
		Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnNovo.UseVisualStyleBackColor = True
		'
		'btnSalvar
		'
		Me.btnSalvar.Enabled = False
		Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.save
		Me.btnSalvar.Location = New System.Drawing.Point(152, 413)
		Me.btnSalvar.Name = "btnSalvar"
		Me.btnSalvar.Size = New System.Drawing.Size(136, 41)
		Me.btnSalvar.TabIndex = 11
		Me.btnSalvar.Text = "&Salvar"
		Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnSalvar.UseVisualStyleBackColor = True
		'
		'MenuListagem
		'
		Me.MenuListagem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtivarToolStripMenuItem, Me.DesativarToolStripMenuItem})
		Me.MenuListagem.Name = "MenuFab"
		Me.MenuListagem.Size = New System.Drawing.Size(158, 48)
		'
		'AtivarToolStripMenuItem
		'
		Me.AtivarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.accept
		Me.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem"
		Me.AtivarToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.AtivarToolStripMenuItem.Text = "Ativar Conta"
		'
		'DesativarToolStripMenuItem
		'
		Me.DesativarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
		Me.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem"
		Me.DesativarToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.DesativarToolStripMenuItem.Text = "Desativar Conta"
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.CausesValidation = False
		Me.btnClose.Location = New System.Drawing.Point(425, 14)
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
		'frmCartaoTipos
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(455, 462)
		Me.Controls.Add(Me.btnFechar)
		Me.Controls.Add(Me.btnNovo)
		Me.Controls.Add(Me.btnSalvar)
		Me.Controls.Add(Me.dgvListagem)
		Me.KeyPreview = True
		Me.Name = "frmCartaoTipos"
		Me.Text = "Tipos de Pagamento"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.dgvListagem, 0)
		Me.Controls.SetChildIndex(Me.btnSalvar, 0)
		Me.Controls.SetChildIndex(Me.btnNovo, 0)
		Me.Controls.SetChildIndex(Me.btnFechar, 0)
		Me.Panel1.ResumeLayout(False)
		CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MenuListagem.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents IDFabricante As DataGridViewTextBoxColumn
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents MenuListagem As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
End Class
