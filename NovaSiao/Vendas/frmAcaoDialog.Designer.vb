<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcaoDialog
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
        Me.btnFechar = New VIBlend.WinForms.Controls.vButton()
        Me.btnNova = New VIBlend.WinForms.Controls.vButton()
        Me.btnProcurar = New VIBlend.WinForms.Controls.vButton()
        Me.lblOrigem = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(430, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(156, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(274, 50)
        Me.lblTitulo.Text = "O que você deseja fazer?"
        '
        'btnFechar
        '
        Me.btnFechar.AllowAnimations = True
        Me.btnFechar.BackColor = System.Drawing.Color.Transparent
        Me.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageAbsolutePosition = New System.Drawing.Point(20, 10)
        Me.btnFechar.Location = New System.Drawing.Point(136, 178)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.RoundedCornersMask = CType(15, Byte)
        Me.btnFechar.Size = New System.Drawing.Size(153, 43)
        Me.btnFechar.TabIndex = 2
        Me.btnFechar.Text = "Apenas &Sair"
        Me.btnFechar.TextAbsolutePosition = New System.Drawing.Point(35, 5)
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseAbsoluteImagePositioning = True
        Me.btnFechar.UseAbsoluteTextPositioning = True
        Me.btnFechar.UseVisualStyleBackColor = False
        Me.btnFechar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnNova
        '
        Me.btnNova.AllowAnimations = True
        Me.btnNova.BackColor = System.Drawing.Color.Transparent
        Me.btnNova.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnNova.ImageAbsolutePosition = New System.Drawing.Point(35, 10)
        Me.btnNova.Location = New System.Drawing.Point(51, 123)
        Me.btnNova.Name = "btnNova"
        Me.btnNova.RoundedCornersMask = CType(15, Byte)
        Me.btnNova.Size = New System.Drawing.Size(153, 43)
        Me.btnNova.TabIndex = 0
        Me.btnNova.Text = "&Nova"
        Me.btnNova.TextAbsolutePosition = New System.Drawing.Point(20, 5)
        Me.btnNova.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNova.UseAbsoluteImagePositioning = True
        Me.btnNova.UseAbsoluteTextPositioning = True
        Me.btnNova.UseCompatibleTextRendering = True
        Me.btnNova.UseVisualStyleBackColor = False
        Me.btnNova.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnProcurar
        '
        Me.btnProcurar.AllowAnimations = True
        Me.btnProcurar.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnProcurar.ImageAbsolutePosition = New System.Drawing.Point(25, 5)
        Me.btnProcurar.Location = New System.Drawing.Point(226, 123)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurar.Size = New System.Drawing.Size(153, 43)
        Me.btnProcurar.TabIndex = 1
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.TextAbsolutePosition = New System.Drawing.Point(30, 5)
        Me.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProcurar.UseAbsoluteImagePositioning = True
        Me.btnProcurar.UseAbsoluteTextPositioning = True
        Me.btnProcurar.UseVisualStyleBackColor = False
        Me.btnProcurar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblOrigem
        '
        Me.lblOrigem.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrigem.ForeColor = System.Drawing.Color.SlateGray
        Me.lblOrigem.Location = New System.Drawing.Point(51, 66)
        Me.lblOrigem.Name = "lblOrigem"
        Me.lblOrigem.Size = New System.Drawing.Size(328, 27)
        Me.lblOrigem.TabIndex = 3
        Me.lblOrigem.Text = "Label1"
        Me.lblOrigem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAcaoDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(430, 238)
        Me.Controls.Add(Me.lblOrigem)
        Me.Controls.Add(Me.btnProcurar)
        Me.Controls.Add(Me.btnNova)
        Me.Controls.Add(Me.btnFechar)
        Me.Name = "frmAcaoDialog"
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnNova, 0)
        Me.Controls.SetChildIndex(Me.btnProcurar, 0)
        Me.Controls.SetChildIndex(Me.lblOrigem, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnFechar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnNova As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnProcurar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents lblOrigem As Label
End Class
