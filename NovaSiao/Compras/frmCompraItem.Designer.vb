<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCompraItem
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
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.lblPreco = New System.Windows.Forms.Label()
        Me.txtQuantidade = New Controles.Text_SoNumeros()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblEstoque = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblReservado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRGProduto = New System.Windows.Forms.TextBox()
        Me.txtDesconto = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblToolStripInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMVA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtST = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtICMS = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIPI = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(538, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(246, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(292, 50)
        Me.lblTitulo.Text = "Entrada de Produto - Item"
        '
        'lblProduto
        '
        Me.lblProduto.BackColor = System.Drawing.Color.Transparent
        Me.lblProduto.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduto.Location = New System.Drawing.Point(19, 127)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(504, 27)
        Me.lblProduto.TabIndex = 2
        Me.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPreco
        '
        Me.lblPreco.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreco.Location = New System.Drawing.Point(92, 188)
        Me.lblPreco.Name = "lblPreco"
        Me.lblPreco.Size = New System.Drawing.Size(100, 27)
        Me.lblPreco.TabIndex = 4
        Me.lblPreco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Inteiro = True
        Me.txtQuantidade.Location = New System.Drawing.Point(21, 188)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(65, 27)
        Me.txtQuantidade.TabIndex = 3
        Me.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Reg.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Preço:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Quant.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Desc.: (%)"
        '
        'lblSubTotal
        '
        Me.lblSubTotal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubTotal.Location = New System.Drawing.Point(198, 188)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(100, 27)
        Me.lblSubTotal.TabIndex = 5
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 19)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "SubTotal:"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Location = New System.Drawing.Point(92, 244)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(100, 27)
        Me.lblTotal.TabIndex = 7
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(96, 222)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Total:"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnOK.Location = New System.Drawing.Point(144, 343)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(118, 46)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "&Inserir"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(268, 343)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(118, 46)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblEstoque
        '
        Me.lblEstoque.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstoque.Location = New System.Drawing.Point(363, 245)
        Me.lblEstoque.Name = "lblEstoque"
        Me.lblEstoque.Size = New System.Drawing.Size(77, 27)
        Me.lblEstoque.TabIndex = 8
        Me.lblEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(362, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Estoque:"
        '
        'lblReservado
        '
        Me.lblReservado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblReservado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReservado.Location = New System.Drawing.Point(446, 245)
        Me.lblReservado.Name = "lblReservado"
        Me.lblReservado.Size = New System.Drawing.Size(77, 27)
        Me.lblReservado.TabIndex = 9
        Me.lblReservado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(445, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 19)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Reservado:"
        '
        'txtRGProduto
        '
        Me.txtRGProduto.Location = New System.Drawing.Point(21, 92)
        Me.txtRGProduto.Name = "txtRGProduto"
        Me.txtRGProduto.Size = New System.Drawing.Size(171, 27)
        Me.txtRGProduto.TabIndex = 1
        '
        'txtDesconto
        '
        Me.txtDesconto.Location = New System.Drawing.Point(21, 244)
        Me.txtDesconto.Name = "txtDesconto"
        Me.txtDesconto.Size = New System.Drawing.Size(65, 27)
        Me.txtDesconto.TabIndex = 6
        Me.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStripInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(2, 400)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(534, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblToolStripInfo
        '
        Me.lblToolStripInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblToolStripInfo.Name = "lblToolStripInfo"
        Me.lblToolStripInfo.Size = New System.Drawing.Size(130, 17)
        Me.lblToolStripInfo.Text = "Editando Item Existente"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 284)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 19)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "MVA: (%)"
        '
        'txtMVA
        '
        Me.txtMVA.Location = New System.Drawing.Point(21, 305)
        Me.txtMVA.Name = "txtMVA"
        Me.txtMVA.Size = New System.Drawing.Size(65, 27)
        Me.txtMVA.TabIndex = 10
        Me.txtMVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(131, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 19)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "ST: (R$)"
        '
        'txtST
        '
        Me.txtST.Location = New System.Drawing.Point(92, 305)
        Me.txtST.Name = "txtST"
        Me.txtST.Size = New System.Drawing.Size(99, 27)
        Me.txtST.TabIndex = 11
        Me.txtST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(195, 284)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 19)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "ICMS: (%)"
        '
        'txtICMS
        '
        Me.txtICMS.Location = New System.Drawing.Point(197, 305)
        Me.txtICMS.Name = "txtICMS"
        Me.txtICMS.Size = New System.Drawing.Size(65, 27)
        Me.txtICMS.TabIndex = 12
        Me.txtICMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(272, 284)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 19)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "IPI: (%)"
        '
        'txtIPI
        '
        Me.txtIPI.Location = New System.Drawing.Point(268, 305)
        Me.txtIPI.Name = "txtIPI"
        Me.txtIPI.Size = New System.Drawing.Size(65, 27)
        Me.txtIPI.TabIndex = 13
        Me.txtIPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmCompraItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(538, 424)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtIPI)
        Me.Controls.Add(Me.txtICMS)
        Me.Controls.Add(Me.txtST)
        Me.Controls.Add(Me.txtMVA)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtDesconto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtRGProduto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.lblReservado)
        Me.Controls.Add(Me.lblEstoque)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblSubTotal)
        Me.Controls.Add(Me.lblPreco)
        Me.Controls.Add(Me.lblProduto)
        Me.KeyPreview = True
        Me.Name = "frmCompraItem"
        Me.Controls.SetChildIndex(Me.lblProduto, 0)
        Me.Controls.SetChildIndex(Me.lblPreco, 0)
        Me.Controls.SetChildIndex(Me.lblSubTotal, 0)
        Me.Controls.SetChildIndex(Me.lblTotal, 0)
        Me.Controls.SetChildIndex(Me.lblEstoque, 0)
        Me.Controls.SetChildIndex(Me.lblReservado, 0)
        Me.Controls.SetChildIndex(Me.txtQuantidade, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtRGProduto, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txtDesconto, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtMVA, 0)
        Me.Controls.SetChildIndex(Me.txtST, 0)
        Me.Controls.SetChildIndex(Me.txtICMS, 0)
        Me.Controls.SetChildIndex(Me.txtIPI, 0)
        Me.Controls.SetChildIndex(Me.StatusStrip1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProduto As Label
    Friend WithEvents lblPreco As Label
    Friend WithEvents txtQuantidade As Controles.Text_SoNumeros
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblSubTotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblEstoque As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblReservado As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtRGProduto As TextBox
    Friend WithEvents txtDesconto As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblToolStripInfo As ToolStripStatusLabel
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMVA As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtST As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtICMS As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtIPI As TextBox
End Class
