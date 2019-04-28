<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodigosFiscais
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.dgvCFOP = New System.Windows.Forms.DataGridView()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCFOP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(721, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(465, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(256, 50)
        Me.lblTitulo.Text = "Editar | Escolher CFOP"
        '
        'btnFechar
        '
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnFechar.Location = New System.Drawing.Point(597, 414)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(111, 43)
        Me.btnFechar.TabIndex = 7
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'dgvCFOP
        '
        Me.dgvCFOP.AllowUserToAddRows = False
        Me.dgvCFOP.AllowUserToDeleteRows = False
        Me.dgvCFOP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCFOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCFOP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCFOP.Location = New System.Drawing.Point(12, 63)
        Me.dgvCFOP.Name = "dgvCFOP"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCFOP.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCFOP.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCFOP.RowTemplate.Height = 44
        Me.dgvCFOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCFOP.Size = New System.Drawing.Size(697, 341)
        Me.dgvCFOP.StandardTab = True
        Me.dgvCFOP.TabIndex = 1
        '
        'btnEscolher
        '
        Me.btnEscolher.CausesValidation = False
        Me.btnEscolher.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEscolher.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEscolher.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnEscolher.Location = New System.Drawing.Point(480, 414)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(111, 43)
        Me.btnEscolher.TabIndex = 6
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.ForeColor = System.Drawing.Color.Blue
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(12, 414)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(111, 43)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.TabStop = False
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.CausesValidation = False
        Me.btnNovo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNovo.ForeColor = System.Drawing.Color.Green
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.btnNovo.Location = New System.Drawing.Point(129, 414)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(111, 43)
        Me.btnNovo.TabIndex = 3
        Me.btnNovo.TabStop = False
        Me.btnNovo.Text = "&Adicionar"
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.CausesValidation = False
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalvar.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.save
        Me.btnSalvar.Location = New System.Drawing.Point(246, 414)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(111, 43)
        Me.btnSalvar.TabIndex = 4
        Me.btnSalvar.TabStop = False
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.CausesValidation = False
        Me.btnExcluir.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Red
        Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnExcluir.Location = New System.Drawing.Point(363, 414)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(111, 43)
        Me.btnExcluir.TabIndex = 5
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Text = "&Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'frmCodigosFiscaisProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(721, 466)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.dgvCFOP)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.btnFechar)
        Me.Name = "frmCodigosFiscaisProcurar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnNovo, 0)
        Me.Controls.SetChildIndex(Me.btnSalvar, 0)
        Me.Controls.SetChildIndex(Me.dgvCFOP, 0)
        Me.Controls.SetChildIndex(Me.btnExcluir, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvCFOP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFechar As Button
    Friend WithEvents dgvCFOP As DataGridView
    Friend WithEvents btnEscolher As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnNovo As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnExcluir As Button
End Class
