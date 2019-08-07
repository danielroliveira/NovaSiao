<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDespesaTipoProcurar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcura = New System.Windows.Forms.TextBox()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(475, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(173, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(302, 50)
        Me.lblTitulo.Text = "Procurar Tipo de Despesa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Procura"
        '
        'txtProcura
        '
        Me.txtProcura.Location = New System.Drawing.Point(79, 62)
        Me.txtProcura.Margin = New System.Windows.Forms.Padding(6)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.Size = New System.Drawing.Size(285, 27)
        Me.txtProcura.TabIndex = 2
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(41, 467)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(126, 42)
        Me.btnEditar.TabIndex = 4
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.btnAdicionar.Location = New System.Drawing.Point(173, 467)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(126, 42)
        Me.btnAdicionar.TabIndex = 5
        Me.btnAdicionar.Text = "&Adicionar"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnFechar.Location = New System.Drawing.Point(305, 467)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(126, 42)
        Me.btnFechar.TabIndex = 6
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        Me.dgvListagem.AllowUserToResizeColumns = False
        Me.dgvListagem.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.BackgroundColor = System.Drawing.Color.FloralWhite
        Me.dgvListagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListagem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListagem.ColumnHeadersHeight = 25
        Me.dgvListagem.EnableHeadersVisualStyles = False
        Me.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvListagem.Location = New System.Drawing.Point(12, 98)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        Me.dgvListagem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListagem.Size = New System.Drawing.Size(451, 363)
        Me.dgvListagem.TabIndex = 3
        '
        'frmDespesaTipoProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(475, 518)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.txtProcura)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmDespesaTipoProcurar"
        Me.Text = "Fornecedor"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtProcura, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnAdicionar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtProcura As TextBox
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents MenuListagem As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvListagem As DataGridView
End Class
