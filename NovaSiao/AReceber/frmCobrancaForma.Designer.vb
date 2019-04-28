<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCobrancaForma
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvFormas = New System.Windows.Forms.DataGridView()
        Me.IDFabricante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.MenuForma = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AtivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvFormas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuForma.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(454, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(234, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(220, 50)
        Me.lblTitulo.Text = "Formas de Cobrança"
        '
        'dgvFormas
        '
        Me.dgvFormas.AllowUserToAddRows = False
        Me.dgvFormas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFormas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFormas.ColumnHeadersHeight = 27
        Me.dgvFormas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFormas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDFabricante})
        Me.dgvFormas.EnableHeadersVisualStyles = False
        Me.dgvFormas.Location = New System.Drawing.Point(12, 67)
        Me.dgvFormas.MultiSelect = False
        Me.dgvFormas.Name = "dgvFormas"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFormas.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFormas.RowHeadersWidth = 36
        Me.dgvFormas.RowTemplate.Height = 30
        Me.dgvFormas.Size = New System.Drawing.Size(433, 345)
        Me.dgvFormas.TabIndex = 2
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
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.Location = New System.Drawing.Point(318, 422)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(127, 52)
        Me.btnFechar.TabIndex = 6
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Adicionar1
        Me.btnNovo.Location = New System.Drawing.Point(12, 422)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(127, 52)
        Me.btnNovo.TabIndex = 4
        Me.btnNovo.Text = "&Novo"
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.Location = New System.Drawing.Point(145, 422)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(127, 52)
        Me.btnSalvar.TabIndex = 5
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'MenuForma
        '
        Me.MenuForma.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtivarToolStripMenuItem, Me.DesativarToolStripMenuItem})
        Me.MenuForma.Name = "MenuFab"
        Me.MenuForma.Size = New System.Drawing.Size(160, 70)
        '
        'AtivarToolStripMenuItem
        '
        Me.AtivarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem"
        Me.AtivarToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AtivarToolStripMenuItem.Text = "Ativar Forma"
        '
        'DesativarToolStripMenuItem
        '
        Me.DesativarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem"
        Me.DesativarToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DesativarToolStripMenuItem.Text = "Desativar Forma"
        '
        'frmCobrancaForma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(454, 486)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.dgvFormas)
        Me.KeyPreview = True
        Me.Name = "frmCobrancaForma"
        Me.Text = "Formas de Cobrança"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dgvFormas, 0)
        Me.Controls.SetChildIndex(Me.btnSalvar, 0)
        Me.Controls.SetChildIndex(Me.btnNovo, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvFormas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuForma.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvFormas As DataGridView
    Friend WithEvents IDFabricante As DataGridViewTextBoxColumn
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents MenuForma As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
End Class
