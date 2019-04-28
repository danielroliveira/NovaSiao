<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProdutoEtiquetaPrint
    Inherits NovaSiao.frmModFinBorderSizeable

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
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.rptvLocal = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(803, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(525, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(215, 50)
        Me.lblTitulo.Text = "Etiquetas de Venda"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(772, 12)
        '
        'btnMaximizar
        '
        Me.btnMaximizar.Location = New System.Drawing.Point(746, 12)
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.Location = New System.Drawing.Point(668, 483)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(127, 43)
        Me.btnFechar.TabIndex = 18
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'rptvLocal
        '
        Me.rptvLocal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptvLocal.LocalReport.ReportEmbeddedResource = "NovaSiao.rptProdutoEtiquetaVenda.rdlc"
        Me.rptvLocal.Location = New System.Drawing.Point(12, 57)
        Me.rptvLocal.Name = "rptvLocal"
        Me.rptvLocal.ServerReport.BearerToken = Nothing
        Me.rptvLocal.Size = New System.Drawing.Size(781, 418)
        Me.rptvLocal.TabIndex = 17
        '
        'frmProdutoEtiquetaPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(807, 535)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.rptvLocal)
        Me.Name = "frmProdutoEtiquetaPrint"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.rptvLocal, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFechar As Button
    Friend WithEvents rptvLocal As Microsoft.Reporting.WinForms.ReportViewer
End Class
