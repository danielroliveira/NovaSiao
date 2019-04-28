<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDevolucaoCredito
    Inherits NovaSiao.frmModNBorder

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.txtMovValor = New Controles.Text_Monetario()
        Me.txtConta = New System.Windows.Forms.TextBox()
        Me.btnProcurarConta = New VIBlend.WinForms.Controls.vButton()
        Me.dtpMovData = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(362, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(65, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(297, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Receber Crédito Devolução"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Conta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Valor"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnOK.Location = New System.Drawing.Point(65, 208)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(111, 48)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "&Receber"
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(183, 208)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(111, 48)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblFilial
        '
        Me.lblFilial.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblFilial.BackColor = System.Drawing.Color.Gainsboro
        Me.lblFilial.Location = New System.Drawing.Point(4, 267)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblFilial.Size = New System.Drawing.Size(354, 23)
        Me.lblFilial.TabIndex = 10
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMovValor
        '
        Me.txtMovValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovValor.Location = New System.Drawing.Point(65, 146)
        Me.txtMovValor.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.txtMovValor.Name = "txtMovValor"
        Me.txtMovValor.Size = New System.Drawing.Size(111, 31)
        Me.txtMovValor.TabIndex = 7
        Me.txtMovValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConta
        '
        Me.txtConta.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConta.Location = New System.Drawing.Point(65, 66)
        Me.txtConta.Name = "txtConta"
        Me.txtConta.Size = New System.Drawing.Size(229, 31)
        Me.txtConta.TabIndex = 2
        '
        'btnProcurarConta
        '
        Me.btnProcurarConta.AllowAnimations = True
        Me.btnProcurarConta.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurarConta.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcurarConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcurarConta.Location = New System.Drawing.Point(300, 66)
        Me.btnProcurarConta.Name = "btnProcurarConta"
        Me.btnProcurarConta.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurarConta.RoundedCornersRadius = 0
        Me.btnProcurarConta.Size = New System.Drawing.Size(34, 31)
        Me.btnProcurarConta.TabIndex = 3
        Me.btnProcurarConta.TabStop = False
        Me.btnProcurarConta.Text = "..."
        Me.btnProcurarConta.UseCompatibleTextRendering = True
        Me.btnProcurarConta.UseVisualStyleBackColor = False
        Me.btnProcurarConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'dtpMovData
        '
        Me.dtpMovData.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpMovData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMovData.Location = New System.Drawing.Point(65, 106)
        Me.dtpMovData.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.dtpMovData.Name = "dtpMovData"
        Me.dtpMovData.Size = New System.Drawing.Size(155, 31)
        Me.dtpMovData.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data"
        '
        'frmDevolucaoCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(362, 294)
        Me.Controls.Add(Me.dtpMovData)
        Me.Controls.Add(Me.btnProcurarConta)
        Me.Controls.Add(Me.txtConta)
        Me.Controls.Add(Me.lblFilial)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtMovValor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmDevolucaoCredito"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtMovValor, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Controls.SetChildIndex(Me.txtConta, 0)
        Me.Controls.SetChildIndex(Me.btnProcurarConta, 0)
        Me.Controls.SetChildIndex(Me.dtpMovData, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMovValor As Controles.Text_Monetario
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblFilial As Label
    Friend WithEvents txtConta As TextBox
    Friend WithEvents btnProcurarConta As VIBlend.WinForms.Controls.vButton
    Friend WithEvents dtpMovData As DateTimePicker
    Friend WithEvents Label2 As Label
End Class
