<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientePFFicha
    Inherits NovaSiao.frmModFinBorderSizeable

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
		Me.btnFechar = New System.Windows.Forms.Button()
		Me.rptvClienteFicha = New Microsoft.Reporting.WinForms.ReportViewer()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.Panel1.Size = New System.Drawing.Size(1073, 50)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(652, 8)
		Me.lblTitulo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 13)
		Me.lblTitulo.Size = New System.Drawing.Size(339, 40)
		Me.lblTitulo.Text = "Ficha de Cliente Pessoa Física"
		'
		'btnClose
		'
		Me.btnClose.Location = New System.Drawing.Point(1039, 12)
		Me.btnClose.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		'
		'btnMaximizar
		'
		Me.btnMaximizar.Location = New System.Drawing.Point(1006, 12)
		Me.btnMaximizar.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		'
		'btnFechar
		'
		Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnFechar.CausesValidation = False
		Me.btnFechar.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
		Me.btnFechar.Location = New System.Drawing.Point(912, 701)
		Me.btnFechar.Margin = New System.Windows.Forms.Padding(4)
		Me.btnFechar.Name = "btnFechar"
		Me.btnFechar.Size = New System.Drawing.Size(154, 51)
		Me.btnFechar.TabIndex = 18
		Me.btnFechar.Text = "&Fechar"
		Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnFechar.UseVisualStyleBackColor = True
		'
		'rptvClienteFicha
		'
		Me.rptvClienteFicha.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rptvClienteFicha.LocalReport.EnableExternalImages = True
		Me.rptvClienteFicha.LocalReport.ReportEmbeddedResource = "NovaSiao.rptClientePFFicha.rdlc"
		Me.rptvClienteFicha.Location = New System.Drawing.Point(13, 61)
		Me.rptvClienteFicha.Margin = New System.Windows.Forms.Padding(4)
		Me.rptvClienteFicha.Name = "rptvClienteFicha"
		Me.rptvClienteFicha.ServerReport.BearerToken = Nothing
		Me.rptvClienteFicha.Size = New System.Drawing.Size(1053, 632)
		Me.rptvClienteFicha.TabIndex = 17
		'
		'frmClientePFFicha
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(1079, 761)
		Me.Controls.Add(Me.btnFechar)
		Me.Controls.Add(Me.rptvClienteFicha)
		Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.Name = "frmClientePFFicha"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.rptvClienteFicha, 0)
		Me.Controls.SetChildIndex(Me.btnFechar, 0)
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents btnFechar As Button
    Friend WithEvents rptvClienteFicha As Microsoft.Reporting.WinForms.ReportViewer
End Class
