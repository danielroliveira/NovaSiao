<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportPedido
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
        Me.rptvPadrao = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
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
        Me.lblTitulo.Location = New System.Drawing.Point(796, 8)
        Me.lblTitulo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 13)
        Me.lblTitulo.Size = New System.Drawing.Size(195, 40)
        Me.lblTitulo.Text = "Imprimir Pedido"
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
        'rptvPadrao
        '
        Me.rptvPadrao.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptvPadrao.LocalReport.EnableExternalImages = True
        Me.rptvPadrao.LocalReport.ReportEmbeddedResource = "NovaSiao.rptPedido.rdlc"
        Me.rptvPadrao.Location = New System.Drawing.Point(13, 61)
        Me.rptvPadrao.Margin = New System.Windows.Forms.Padding(4)
        Me.rptvPadrao.Name = "rptvPadrao"
        Me.rptvPadrao.ServerReport.BearerToken = Nothing
        Me.rptvPadrao.Size = New System.Drawing.Size(1053, 632)
        Me.rptvPadrao.TabIndex = 17
        '
        'btnSalvar
        '
        Me.btnSalvar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalvar.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_32x32
        Me.btnSalvar.Location = New System.Drawing.Point(12, 700)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(154, 51)
        Me.btnSalvar.TabIndex = 19
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Image = Global.NovaSiao.My.Resources.Resources.mail_send_32
        Me.btnEnviar.Location = New System.Drawing.Point(172, 700)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(154, 51)
        Me.btnEnviar.TabIndex = 19
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'frmReportPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1079, 761)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.rptvPadrao)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "frmReportPedido"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.rptvPadrao, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnSalvar, 0)
        Me.Controls.SetChildIndex(Me.btnEnviar, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFechar As Button
    Friend WithEvents rptvPadrao As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnEnviar As Button
End Class
