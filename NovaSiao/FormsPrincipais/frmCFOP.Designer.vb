<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCFOP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.dgvOperacao = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnOpercao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.menuCFOP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProcurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimparToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvOperacao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuCFOP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 63)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(328, 11)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(387, 38)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "CFOP das Operações"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvOperacao
        '
        Me.dgvOperacao.AllowUserToAddRows = False
        Me.dgvOperacao.AllowUserToDeleteRows = False
        Me.dgvOperacao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOperacao.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOperacao.ColumnHeadersHeight = 30
        Me.dgvOperacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvOperacao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnOpercao})
        Me.dgvOperacao.EnableHeadersVisualStyles = False
        Me.dgvOperacao.Location = New System.Drawing.Point(12, 120)
        Me.dgvOperacao.Name = "dgvOperacao"
        Me.dgvOperacao.RowHeadersWidth = 36
        Me.dgvOperacao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvOperacao.RowTemplate.Height = 30
        Me.dgvOperacao.Size = New System.Drawing.Size(698, 379)
        Me.dgvOperacao.TabIndex = 3
        '
        'clnID
        '
        Me.clnID.HeaderText = "ID"
        Me.clnID.Name = "clnID"
        Me.clnID.Visible = False
        '
        'clnOpercao
        '
        Me.clnOpercao.HeaderText = "Operação"
        Me.clnOpercao.Name = "clnOpercao"
        Me.clnOpercao.ReadOnly = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.SlateGray
        Me.Label33.Location = New System.Drawing.Point(46, 78)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(546, 25)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "Tabela de Associação do CFOP com as Operações:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Linen
        Me.Panel2.Controls.Add(Me.btnCancelar)
        Me.Panel2.Controls.Add(Me.btnSalvar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 554)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(727, 59)
        Me.Panel2.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BurlyWood
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.cancelar_edicao
        Me.btnCancelar.Location = New System.Drawing.Point(564, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(149, 52)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.FlatAppearance.BorderSize = 0
        Me.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BurlyWood
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.Location = New System.Drawing.Point(8, 3)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(120, 52)
        Me.btnSalvar.TabIndex = 0
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'EProvider
        '
        Me.EProvider.ContainerControl = Me
        '
        'menuCFOP
        '
        Me.menuCFOP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcurarToolStripMenuItem, Me.LimparToolStripMenuItem})
        Me.menuCFOP.Name = "cmsCFOP"
        Me.menuCFOP.Size = New System.Drawing.Size(131, 52)
        '
        'ProcurarToolStripMenuItem
        '
        Me.ProcurarToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProcurarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.search_peq
        Me.ProcurarToolStripMenuItem.Name = "ProcurarToolStripMenuItem"
        Me.ProcurarToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.ProcurarToolStripMenuItem.Text = "Procurar"
        '
        'LimparToolStripMenuItem
        '
        Me.LimparToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LimparToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.LimparToolStripMenuItem.Name = "LimparToolStripMenuItem"
        Me.LimparToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.LimparToolStripMenuItem.Text = "Limpar"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(48, 513)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(630, 20)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Clique com o segundo botão do mouse na listagem para alterar o CFOP"
        '
        'frmCFOP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(727, 613)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dgvOperacao)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmCFOP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração Geral"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvOperacao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuCFOP.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents Label33 As Label
    Friend WithEvents menuCFOP As ContextMenuStrip
    Friend WithEvents ProcurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LimparToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgvOperacao As DataGridView
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnOpercao As DataGridViewTextBoxColumn
    Friend WithEvents Label19 As Label
End Class
