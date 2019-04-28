<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAReceberItem
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
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblToolStripInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtParcelaValor = New Controles.Text_Monetario()
        Me.txtVencimento = New Controles.MaskText_Data()
        Me.txtPermanencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblReg = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblReg)
        Me.Panel1.Size = New System.Drawing.Size(304, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblReg, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(128, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(176, 50)
        Me.lblTitulo.Text = "Editar Parcela"
        '
        'btnCancelar
        '
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(154, 191)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(118, 46)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnOK.Location = New System.Drawing.Point(27, 191)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(118, 46)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "Inserir"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.LightSlateGray
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStripInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(2, 260)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(300, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblToolStripInfo
        '
        Me.lblToolStripInfo.AutoSize = False
        Me.lblToolStripInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblToolStripInfo.ForeColor = System.Drawing.Color.White
        Me.lblToolStripInfo.Name = "lblToolStripInfo"
        Me.lblToolStripInfo.Size = New System.Drawing.Size(326, 17)
        Me.lblToolStripInfo.Text = "Editando Item Existente"
        '
        'txtParcelaValor
        '
        Me.txtParcelaValor.Location = New System.Drawing.Point(172, 138)
        Me.txtParcelaValor.Name = "txtParcelaValor"
        Me.txtParcelaValor.Size = New System.Drawing.Size(100, 27)
        Me.txtParcelaValor.TabIndex = 6
        Me.txtParcelaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVencimento
        '
        Me.txtVencimento.Location = New System.Drawing.Point(172, 72)
        Me.txtVencimento.Mask = "00/00/0000"
        Me.txtVencimento.Name = "txtVencimento"
        Me.txtVencimento.Size = New System.Drawing.Size(100, 27)
        Me.txtVencimento.TabIndex = 2
        Me.txtVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPermanencia
        '
        Me.txtPermanencia.Location = New System.Drawing.Point(172, 105)
        Me.txtPermanencia.Name = "txtPermanencia"
        Me.txtPermanencia.Size = New System.Drawing.Size(47, 27)
        Me.txtPermanencia.TabIndex = 4
        Me.txtPermanencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vencimento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Valor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Taxa de Permanência"
        '
        'lblReg
        '
        Me.lblReg.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReg.ForeColor = System.Drawing.Color.White
        Me.lblReg.Location = New System.Drawing.Point(8, 11)
        Me.lblReg.Name = "lblReg"
        Me.lblReg.Size = New System.Drawing.Size(105, 29)
        Me.lblReg.TabIndex = 0
        Me.lblReg.Text = "0000A"
        '
        'frmAReceberItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(304, 284)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPermanencia)
        Me.Controls.Add(Me.txtVencimento)
        Me.Controls.Add(Me.txtParcelaValor)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmAReceberItem"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.StatusStrip1, 0)
        Me.Controls.SetChildIndex(Me.txtParcelaValor, 0)
        Me.Controls.SetChildIndex(Me.txtVencimento, 0)
        Me.Controls.SetChildIndex(Me.txtPermanencia, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblToolStripInfo As ToolStripStatusLabel
    Friend WithEvents txtParcelaValor As Controles.Text_Monetario
    Friend WithEvents txtVencimento As Controles.MaskText_Data
    Friend WithEvents txtPermanencia As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblReg As Label
End Class
