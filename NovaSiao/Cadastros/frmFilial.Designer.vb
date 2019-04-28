<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFilial
    Inherits NovaSiao.frmModFinBorder

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvFiliais = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnImagem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnAtivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.MenuFil = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AtivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvFiliais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuFil.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(457, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(260, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(197, 50)
        Me.lblTitulo.Text = "Cadastro de Filial"
        '
        'dgvFiliais
        '
        Me.dgvFiliais.AllowUserToAddRows = False
        Me.dgvFiliais.AllowUserToDeleteRows = False
        Me.dgvFiliais.AllowUserToResizeColumns = False
        Me.dgvFiliais.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvFiliais.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFiliais.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvFiliais.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFiliais.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFiliais.ColumnHeadersHeight = 33
        Me.dgvFiliais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFiliais.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnFilia, Me.clnImagem, Me.clnAtivo})
        Me.dgvFiliais.EnableHeadersVisualStyles = False
        Me.dgvFiliais.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvFiliais.Location = New System.Drawing.Point(12, 65)
        Me.dgvFiliais.MultiSelect = False
        Me.dgvFiliais.Name = "dgvFiliais"
        Me.dgvFiliais.RowHeadersVisible = False
        Me.dgvFiliais.RowHeadersWidth = 45
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.dgvFiliais.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvFiliais.RowTemplate.Height = 30
        Me.dgvFiliais.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFiliais.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFiliais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFiliais.Size = New System.Drawing.Size(433, 293)
        Me.dgvFiliais.TabIndex = 2
        '
        'clnID
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.clnID.DefaultCellStyle = DataGridViewCellStyle3
        Me.clnID.HeaderText = "Reg.:"
        Me.clnID.Name = "clnID"
        Me.clnID.ReadOnly = True
        Me.clnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clnID.Width = 60
        '
        'clnFilia
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PowderBlue
        Me.clnFilia.DefaultCellStyle = DataGridViewCellStyle4
        Me.clnFilia.HeaderText = "Filial"
        Me.clnFilia.Name = "clnFilia"
        Me.clnFilia.Width = 220
        '
        'clnImagem
        '
        Me.clnImagem.HeaderText = "Ativo"
        Me.clnImagem.Name = "clnImagem"
        Me.clnImagem.ReadOnly = True
        '
        'clnAtivo
        '
        Me.clnAtivo.HeaderText = "Ativo"
        Me.clnAtivo.Name = "clnAtivo"
        Me.clnAtivo.ReadOnly = True
        Me.clnAtivo.Visible = False
        '
        'btnFechar
        '
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.Location = New System.Drawing.Point(318, 370)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(127, 38)
        Me.btnFechar.TabIndex = 6
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnNovo.Location = New System.Drawing.Point(12, 370)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(127, 38)
        Me.btnNovo.TabIndex = 4
        Me.btnNovo.Text = "&Novo"
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.save
        Me.btnSalvar.Location = New System.Drawing.Point(145, 370)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(127, 38)
        Me.btnSalvar.TabIndex = 5
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'MenuFil
        '
        Me.MenuFil.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtivarToolStripMenuItem, Me.DesativarToolStripMenuItem})
        Me.MenuFil.Name = "MenuFab"
        Me.MenuFil.Size = New System.Drawing.Size(150, 48)
        '
        'AtivarToolStripMenuItem
        '
        Me.AtivarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem"
        Me.AtivarToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AtivarToolStripMenuItem.Text = "Ativar Filial"
        '
        'DesativarToolStripMenuItem
        '
        Me.DesativarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem"
        Me.DesativarToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DesativarToolStripMenuItem.Text = "Desativar Filial"
        '
        'frmFilial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(457, 417)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.dgvFiliais)
        Me.Name = "frmFilial"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dgvFiliais, 0)
        Me.Controls.SetChildIndex(Me.btnSalvar, 0)
        Me.Controls.SetChildIndex(Me.btnNovo, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvFiliais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuFil.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvFiliais As DataGridView
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents MenuFil As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnFilia As DataGridViewTextBoxColumn
    Friend WithEvents clnImagem As DataGridViewTextBoxColumn
    Friend WithEvents clnAtivo As DataGridViewTextBoxColumn
End Class
