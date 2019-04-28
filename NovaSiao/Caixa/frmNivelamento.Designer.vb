<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNivelamento
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
        Me.txtValor = New Controles.Text_Monetario()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnNivelar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblConta = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMeio = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(362, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(115, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(247, 50)
        Me.lblTitulo.Text = "Nivelamento de Caixa"
        '
        'txtValor
        '
        Me.txtValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Location = New System.Drawing.Point(129, 257)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(135, 31)
        Me.txtValor.SomentePositivos = False
        Me.txtValor.TabIndex = 2
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Valor Real"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNivelar
        '
        Me.btnNivelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnNivelar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnNivelar.Location = New System.Drawing.Point(55, 315)
        Me.btnNivelar.Name = "btnNivelar"
        Me.btnNivelar.Size = New System.Drawing.Size(119, 48)
        Me.btnNivelar.TabIndex = 3
        Me.btnNivelar.Text = "&Nivelar"
        Me.btnNivelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNivelar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(189, 315)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(119, 48)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblConta
        '
        Me.lblConta.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConta.Location = New System.Drawing.Point(34, 25)
        Me.lblConta.Name = "lblConta"
        Me.lblConta.Size = New System.Drawing.Size(263, 29)
        Me.lblConta.TabIndex = 5
        Me.lblConta.Text = "Conta do Caixa"
        Me.lblConta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(246, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Informe o valor real que há na Conta"
        '
        'lblMeio
        '
        Me.lblMeio.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeio.Location = New System.Drawing.Point(41, 27)
        Me.lblMeio.Name = "lblMeio"
        Me.lblMeio.Size = New System.Drawing.Size(257, 29)
        Me.lblMeio.TabIndex = 5
        Me.lblMeio.Text = "Meio de Movimentação"
        Me.lblMeio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblConta)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 70)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Conta de Nivelamento: "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblMeio)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 146)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 70)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Meio de Movimentação: "
        '
        'frmNivelamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(362, 375)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnNivelar)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmNivelamento"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtValor, 0)
        Me.Controls.SetChildIndex(Me.btnNivelar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtValor As Controles.Text_Monetario
    Friend WithEvents Label3 As Label
    Friend WithEvents btnNivelar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblConta As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblMeio As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
