<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClienteAcoesDialog
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdicionar = New VIBlend.WinForms.Controls.vButton()
        Me.btnImprimir = New VIBlend.WinForms.Controls.vSplitButton()
        Me.btnProcurar = New VIBlend.WinForms.Controls.vButton()
        Me.btnContinuar = New VIBlend.WinForms.Controls.vButton()
        Me.btnFechar = New VIBlend.WinForms.Controls.vButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(161, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "O que você deseja fazer?"
        '
        'btnAdicionar
        '
        Me.btnAdicionar.AllowAnimations = True
        Me.btnAdicionar.BackColor = System.Drawing.Color.Transparent
        Me.btnAdicionar.Image = Global.NovaSiao.My.Resources.Resources.Adiconar_Usuário
        Me.btnAdicionar.ImageAbsolutePosition = New System.Drawing.Point(5, 0)
        Me.btnAdicionar.Location = New System.Drawing.Point(217, 115)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.RoundedCornersMask = CType(15, Byte)
        Me.btnAdicionar.Size = New System.Drawing.Size(171, 63)
        Me.btnAdicionar.TabIndex = 1
        Me.btnAdicionar.Text = "Adicionar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Novo Cliente"
        Me.btnAdicionar.TextAbsolutePosition = New System.Drawing.Point(55, 5)
        Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdicionar.UseAbsoluteImagePositioning = True
        Me.btnAdicionar.UseAbsoluteTextPositioning = True
        Me.btnAdicionar.UseVisualStyleBackColor = False
        Me.btnAdicionar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir_PEQ
        Me.btnImprimir.ImageAbsolutePosition = New System.Drawing.Point(30, 18)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(124, 198)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(0)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Opacity = 0!
        Me.btnImprimir.RoundedCornersMask = CType(15, Byte)
        Me.btnImprimir.Size = New System.Drawing.Size(171, 63)
        Me.btnImprimir.StyleKey = "SplitButton"
        Me.btnImprimir.TabIndex = 3
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAbsolutePosition = New System.Drawing.Point(60, 5)
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnImprimir.UseAbsoluteTextPositioning = True
        Me.btnImprimir.UseVisualStyleBackColor = False
        Me.btnImprimir.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnProcurar
        '
        Me.btnProcurar.AllowAnimations = True
        Me.btnProcurar.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.Procurar_Usuário
        Me.btnProcurar.ImageAbsolutePosition = New System.Drawing.Point(5, 0)
        Me.btnProcurar.Location = New System.Drawing.Point(408, 115)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurar.Size = New System.Drawing.Size(171, 63)
        Me.btnProcurar.TabIndex = 2
        Me.btnProcurar.Text = "Procurar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cliente"
        Me.btnProcurar.TextAbsolutePosition = New System.Drawing.Point(40, 5)
        Me.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProcurar.UseAbsoluteImagePositioning = True
        Me.btnProcurar.UseAbsoluteTextPositioning = True
        Me.btnProcurar.UseVisualStyleBackColor = False
        Me.btnProcurar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnContinuar
        '
        Me.btnContinuar.AllowAnimations = True
        Me.btnContinuar.BackColor = System.Drawing.Color.Transparent
        Me.btnContinuar.Image = Global.NovaSiao.My.Resources.Resources.Aceitar_Usuario
        Me.btnContinuar.ImageAbsolutePosition = New System.Drawing.Point(5, 0)
        Me.btnContinuar.Location = New System.Drawing.Point(29, 115)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.RoundedCornersMask = CType(15, Byte)
        Me.btnContinuar.Size = New System.Drawing.Size(171, 63)
        Me.btnContinuar.TabIndex = 0
        Me.btnContinuar.Text = "Continuar no" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cliente Atual" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnContinuar.TextAbsolutePosition = New System.Drawing.Point(55, 5)
        Me.btnContinuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnContinuar.UseAbsoluteImagePositioning = True
        Me.btnContinuar.UseAbsoluteTextPositioning = True
        Me.btnContinuar.UseVisualStyleBackColor = False
        Me.btnContinuar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnFechar
        '
        Me.btnFechar.AllowAnimations = True
        Me.btnFechar.BackColor = System.Drawing.Color.Transparent
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageAbsolutePosition = New System.Drawing.Point(30, 22)
        Me.btnFechar.Location = New System.Drawing.Point(312, 198)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.RoundedCornersMask = CType(15, Byte)
        Me.btnFechar.Size = New System.Drawing.Size(171, 63)
        Me.btnFechar.TabIndex = 4
        Me.btnFechar.Text = "Apenas Sair"
        Me.btnFechar.TextAbsolutePosition = New System.Drawing.Point(40, 5)
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseAbsoluteImagePositioning = True
        Me.btnFechar.UseAbsoluteTextPositioning = True
        Me.btnFechar.UseVisualStyleBackColor = False
        Me.btnFechar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'frmClienteAcoesDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 290)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnProcurar)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClienteAcoesDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "O que deseja fazer?"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnImprimir As VIBlend.WinForms.Controls.vSplitButton
    Friend WithEvents btnContinuar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnProcurar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnAdicionar As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnFechar As VIBlend.WinForms.Controls.vButton
End Class
