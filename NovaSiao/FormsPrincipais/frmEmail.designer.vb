<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmail
    Inherits NovaSiao.frmModFinBorder

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
        Me.txtMailTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMailFrom = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtBodyMesssage = New System.Windows.Forms.TextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.lstAttachments = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAnexoIncluir = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnAnexoExcluir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLogoPath = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(668, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(491, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(177, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Enviar Email"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMailTo
        '
        Me.txtMailTo.Location = New System.Drawing.Point(83, 69)
        Me.txtMailTo.Margin = New System.Windows.Forms.Padding(6)
        Me.txtMailTo.Name = "txtMailTo"
        Me.txtMailTo.Size = New System.Drawing.Size(566, 27)
        Me.txtMailTo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 72)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Destino:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 111)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Origem:"
        '
        'txtMailFrom
        '
        Me.txtMailFrom.Location = New System.Drawing.Point(83, 108)
        Me.txtMailFrom.Margin = New System.Windows.Forms.Padding(6)
        Me.txtMailFrom.Name = "txtMailFrom"
        Me.txtMailFrom.ReadOnly = True
        Me.txtMailFrom.Size = New System.Drawing.Size(566, 27)
        Me.txtMailFrom.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 150)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Título:"
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(635, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(83, 147)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(566, 27)
        Me.txtSubject.TabIndex = 6
        '
        'txtBodyMesssage
        '
        Me.txtBodyMesssage.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBodyMesssage.Location = New System.Drawing.Point(19, 376)
        Me.txtBodyMesssage.Margin = New System.Windows.Forms.Padding(6)
        Me.txtBodyMesssage.Multiline = True
        Me.txtBodyMesssage.Name = "txtBodyMesssage"
        Me.txtBodyMesssage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBodyMesssage.Size = New System.Drawing.Size(630, 212)
        Me.txtBodyMesssage.TabIndex = 14
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Image = Global.NovaSiao.My.Resources.Resources.mail_send_32
        Me.btnEnviar.Location = New System.Drawing.Point(323, 604)
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(159, 44)
        Me.btnEnviar.TabIndex = 15
        Me.btnEnviar.Text = "&Enviar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'lstAttachments
        '
        Me.lstAttachments.FormattingEnabled = True
        Me.lstAttachments.ItemHeight = 19
        Me.lstAttachments.Location = New System.Drawing.Point(83, 186)
        Me.lstAttachments.Margin = New System.Windows.Forms.Padding(6)
        Me.lstAttachments.Name = "lstAttachments"
        Me.lstAttachments.Size = New System.Drawing.Size(397, 99)
        Me.lstAttachments.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 190)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Anexos:"
        '
        'btnAnexoIncluir
        '
        Me.btnAnexoIncluir.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.btnAnexoIncluir.Location = New System.Drawing.Point(495, 186)
        Me.btnAnexoIncluir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnexoIncluir.Name = "btnAnexoIncluir"
        Me.btnAnexoIncluir.Size = New System.Drawing.Size(154, 44)
        Me.btnAnexoIncluir.TabIndex = 9
        Me.btnAnexoIncluir.Text = "Incluir Anexo"
        Me.btnAnexoIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnexoIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAnexoIncluir.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnAnexoExcluir
        '
        Me.btnAnexoExcluir.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnAnexoExcluir.Location = New System.Drawing.Point(495, 241)
        Me.btnAnexoExcluir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnexoExcluir.Name = "btnAnexoExcluir"
        Me.btnAnexoExcluir.Size = New System.Drawing.Size(154, 44)
        Me.btnAnexoExcluir.TabIndex = 10
        Me.btnAnexoExcluir.Text = "Remover Anexo"
        Me.btnAnexoExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnexoExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAnexoExcluir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 300)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Logo:"
        '
        'txtLogoPath
        '
        Me.txtLogoPath.Location = New System.Drawing.Point(83, 297)
        Me.txtLogoPath.Margin = New System.Windows.Forms.Padding(6)
        Me.txtLogoPath.Name = "txtLogoPath"
        Me.txtLogoPath.ReadOnly = True
        Me.txtLogoPath.Size = New System.Drawing.Size(566, 27)
        Me.txtLogoPath.TabIndex = 12
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.Location = New System.Drawing.Point(490, 604)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(159, 44)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 344)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 26)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Mensagem:"
        '
        'frmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 663)
        Me.Controls.Add(Me.txtLogoPath)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnAnexoExcluir)
        Me.Controls.Add(Me.btnAnexoIncluir)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstAttachments)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtBodyMesssage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMailFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMailTo)
        Me.Name = "frmEmail"
        Me.Text = "frmEmail"
        Me.Controls.SetChildIndex(Me.txtMailTo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtMailFrom, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtSubject, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtBodyMesssage, 0)
        Me.Controls.SetChildIndex(Me.btnEnviar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.lstAttachments, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.btnAnexoIncluir, 0)
        Me.Controls.SetChildIndex(Me.btnAnexoExcluir, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtLogoPath, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMailTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMailFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtBodyMesssage As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents lstAttachments As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAnexoIncluir As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnAnexoExcluir As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLogoPath As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label6 As Label
End Class
