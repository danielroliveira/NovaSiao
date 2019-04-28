<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoresProcurar
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvAutores = New System.Windows.Forms.DataGridView()
        Me.clnAutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtProcurar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvAutores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(511, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(345, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(166, 50)
        Me.lblTitulo.Text = "Procurar Autor"
        '
        'dgvAutores
        '
        Me.dgvAutores.AllowUserToAddRows = False
        Me.dgvAutores.AllowUserToDeleteRows = False
        Me.dgvAutores.AllowUserToResizeColumns = False
        Me.dgvAutores.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvAutores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAutores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvAutores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAutores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAutores.ColumnHeadersHeight = 33
        Me.dgvAutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvAutores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnAutor, Me.clnQuantidade})
        Me.dgvAutores.EnableHeadersVisualStyles = False
        Me.dgvAutores.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvAutores.Location = New System.Drawing.Point(12, 89)
        Me.dgvAutores.MultiSelect = False
        Me.dgvAutores.Name = "dgvAutores"
        Me.dgvAutores.RowHeadersVisible = False
        Me.dgvAutores.RowHeadersWidth = 45
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgvAutores.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAutores.RowTemplate.Height = 30
        Me.dgvAutores.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAutores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAutores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAutores.Size = New System.Drawing.Size(487, 323)
        Me.dgvAutores.TabIndex = 1
        '
        'clnAutor
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PowderBlue
        Me.clnAutor.DefaultCellStyle = DataGridViewCellStyle3
        Me.clnAutor.HeaderText = "Nome do Autor"
        Me.clnAutor.Name = "clnAutor"
        Me.clnAutor.Width = 350
        '
        'clnQuantidade
        '
        Me.clnQuantidade.HeaderText = "Livros Qde."
        Me.clnQuantidade.Name = "clnQuantidade"
        Me.clnQuantidade.ReadOnly = True
        '
        'txtProcurar
        '
        Me.txtProcurar.Location = New System.Drawing.Point(71, 56)
        Me.txtProcurar.Name = "txtProcurar"
        Me.txtProcurar.Size = New System.Drawing.Size(292, 27)
        Me.txtProcurar.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nome:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancelar.Location = New System.Drawing.Point(369, 418)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 44)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEscolher
        '
        Me.btnEscolher.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEscolher.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnEscolher.Location = New System.Drawing.Point(233, 418)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(130, 44)
        Me.btnEscolher.TabIndex = 2
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'frmAutoresProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(511, 472)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProcurar)
        Me.Controls.Add(Me.dgvAutores)
        Me.KeyPreview = True
        Me.Name = "frmAutoresProcurar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dgvAutores, 0)
        Me.Controls.SetChildIndex(Me.txtProcurar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvAutores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAutores As DataGridView
    Friend WithEvents clnAutor As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents txtProcurar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEscolher As Button
End Class
