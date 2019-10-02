<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCNPInserir
    Inherits NovaSiao.frmModFinBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.lblSubtitulo = New System.Windows.Forms.Label()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.lblNum = New System.Windows.Forms.Label()
		Me.txtCNPJ = New System.Windows.Forms.TextBox()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Size = New System.Drawing.Size(543, 50)
		'
		'lblTitulo
		'
		Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lblTitulo.Location = New System.Drawing.Point(0, 0)
		Me.lblTitulo.Size = New System.Drawing.Size(543, 50)
		Me.lblTitulo.Text = "Deseja inserir um"
		Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblSubtitulo
		'
		Me.lblSubtitulo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSubtitulo.ForeColor = System.Drawing.Color.Black
		Me.lblSubtitulo.Location = New System.Drawing.Point(18, 100)
		Me.lblSubtitulo.Name = "lblSubtitulo"
		Me.lblSubtitulo.Size = New System.Drawing.Size(513, 36)
		Me.lblSubtitulo.TabIndex = 1
		Me.lblSubtitulo.Text = "Digite o CPF ou CNPJ"
		Me.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnOK
		'
		Me.btnOK.BackColor = System.Drawing.Color.AliceBlue
		Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnOK.Location = New System.Drawing.Point(155, 240)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(114, 44)
		Me.btnOK.TabIndex = 4
		Me.btnOK.Text = "&OK"
		Me.btnOK.UseVisualStyleBackColor = False
		'
		'btnCancelar
		'
		Me.btnCancelar.BackColor = System.Drawing.Color.PaleTurquoise
		Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCancelar.Location = New System.Drawing.Point(279, 240)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(114, 44)
		Me.btnCancelar.TabIndex = 5
		Me.btnCancelar.Text = "&Cancelar"
		Me.btnCancelar.UseVisualStyleBackColor = False
		'
		'lblNum
		'
		Me.lblNum.ForeColor = System.Drawing.Color.Red
		Me.lblNum.Location = New System.Drawing.Point(133, 190)
		Me.lblNum.Name = "lblNum"
		Me.lblNum.Size = New System.Drawing.Size(277, 21)
		Me.lblNum.TabIndex = 3
		Me.lblNum.Text = "CNPJ não pode ter mais do que 14 dígitos"
		Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblNum.Visible = False
		'
		'txtCNPJ
		'
		Me.txtCNPJ.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCNPJ.Location = New System.Drawing.Point(113, 149)
		Me.txtCNPJ.Name = "txtCNPJ"
		Me.txtCNPJ.Size = New System.Drawing.Size(317, 33)
		Me.txtCNPJ.TabIndex = 2
		Me.txtCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'frmCNPInserir
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
		Me.ClientSize = New System.Drawing.Size(543, 316)
		Me.Controls.Add(Me.txtCNPJ)
		Me.Controls.Add(Me.lblNum)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.lblSubtitulo)
		Me.KeyPreview = True
		Me.Name = "frmCNPInserir"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Novo Cliente"
		Me.TopMost = True
		Me.Controls.SetChildIndex(Me.lblSubtitulo, 0)
		Me.Controls.SetChildIndex(Me.btnOK, 0)
		Me.Controls.SetChildIndex(Me.btnCancelar, 0)
		Me.Controls.SetChildIndex(Me.lblNum, 0)
		Me.Controls.SetChildIndex(Me.txtCNPJ, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblSubtitulo As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblNum As Label
    Friend WithEvents txtCNPJ As TextBox
End Class
