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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.rptvClienteFicha = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(805, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(448, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(319, 50)
        Me.lblTitulo.Text = "Ficha de Cliente Pessoa Física"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(774, 12)
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.Location = New System.Drawing.Point(670, 474)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(127, 52)
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
        ReportDataSource1.Name = "dsClientePF"
        ReportDataSource1.Value = Nothing
        Me.rptvClienteFicha.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvClienteFicha.LocalReport.ReportEmbeddedResource = "NovaSiao.rptClientePFFicha.rdlc"
        Me.rptvClienteFicha.Location = New System.Drawing.Point(12, 62)
        Me.rptvClienteFicha.Name = "rptvClienteFicha"
        Me.rptvClienteFicha.ServerReport.BearerToken = Nothing
        Me.rptvClienteFicha.Size = New System.Drawing.Size(783, 403)
        Me.rptvClienteFicha.TabIndex = 17
        '
        'frmClientePF_Ficha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(809, 535)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.rptvClienteFicha)
        Me.Name = "frmClientePF_Ficha"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.rptvClienteFicha, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFechar As Button
    Friend WithEvents rptvClienteFicha As Microsoft.Reporting.WinForms.ReportViewer
End Class
