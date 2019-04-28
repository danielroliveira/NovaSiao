<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVendaItem
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblEstoque = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblReservado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRGProduto = New System.Windows.Forms.TextBox()
        Me.txtDesconto = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblToolStripInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(538, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(256, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(282, 50)
        Me.lblTitulo.Text = "Saída de Produto - Item"
        '
        'lblProduto
        '
        Me.lblProduto.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProduto.Location = New System.Drawing.Point(92, 92)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(431, 27)
        Me.lblProduto.TabIndex = 4
        Me.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPreco
        '
        Me.lblPreco.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreco.Location = New System.Drawing.Point(92, 153)
        Me.lblPreco.Name = "lblPreco"
        Me.lblPreco.Size = New System.Drawing.Size(100, 27)
        Me.lblPreco.TabIndex = 4
        Me.lblPreco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Inteiro = True
        Me.txtQuantidade.Location = New System.Drawing.Point(21, 153)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(65, 27)
        Me.txtQuantidade.TabIndex = 1
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
        Me.Label2.Location = New System.Drawing.Point(92, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Preço:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Quant.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Desc.: (%)"
        '
        'lblSubTotal
        '
        Me.lblSubTotal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubTotal.Location = New System.Drawing.Point(198, 153)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(100, 27)
        Me.lblSubTotal.TabIndex = 4
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 19)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "SubTotal:"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Location = New System.Drawing.Point(92, 209)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(100, 27)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(96, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Total:"
        '
        'btnOK
        '
        Me.btnOK.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.Location = New System.Drawing.Point(144, 268)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(118, 46)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "Inserir"
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(92, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Produto:"
        '
        'btnCancelar
        '
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(268, 268)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(118, 46)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblEstoque
        '
        Me.lblEstoque.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstoque.Location = New System.Drawing.Point(363, 210)
        Me.lblEstoque.Name = "lblEstoque"
        Me.lblEstoque.Size = New System.Drawing.Size(77, 27)
        Me.lblEstoque.TabIndex = 4
        Me.lblEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(362, 188)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Estoque:"
        '
        'lblReservado
        '
        Me.lblReservado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lblReservado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReservado.Location = New System.Drawing.Point(446, 210)
        Me.lblReservado.Name = "lblReservado"
        Me.lblReservado.Size = New System.Drawing.Size(77, 27)
        Me.lblReservado.TabIndex = 4
        Me.lblReservado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(445, 187)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 19)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Reservado:"
        '
        'txtRGProduto
        '
        Me.txtRGProduto.Location = New System.Drawing.Point(21, 92)
        Me.txtRGProduto.Name = "txtRGProduto"
        Me.txtRGProduto.Size = New System.Drawing.Size(65, 27)
        Me.txtRGProduto.TabIndex = 0
        Me.txtRGProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesconto
        '
        Me.txtDesconto.Location = New System.Drawing.Point(21, 209)
        Me.txtDesconto.Name = "txtDesconto"
        Me.txtDesconto.Size = New System.Drawing.Size(65, 27)
        Me.txtDesconto.TabIndex = 2
        Me.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStripInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(4, 334)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(530, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblToolStripInfo
        '
        Me.lblToolStripInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblToolStripInfo.Name = "lblToolStripInfo"
        Me.lblToolStripInfo.Size = New System.Drawing.Size(130, 17)
        Me.lblToolStripInfo.Text = "Editando Item Existente"
        '
        'frmVendaItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(538, 360)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtDesconto)
        Me.Controls.Add(Me.txtRGProduto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtQuantidade)
        Me.Controls.Add(Me.lblReservado)
        Me.Controls.Add(Me.lblEstoque)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblSubTotal)
        Me.Controls.Add(Me.lblPreco)
        Me.Controls.Add(Me.lblProduto)
        Me.KeyPreview = True
        Me.Name = "frmVendaItem"
        Me.Controls.SetChildIndex(Me.lblProduto, 0)
        Me.Controls.SetChildIndex(Me.lblPreco, 0)
        Me.Controls.SetChildIndex(Me.lblSubTotal, 0)
        Me.Controls.SetChildIndex(Me.lblTotal, 0)
        Me.Controls.SetChildIndex(Me.lblEstoque, 0)
        Me.Controls.SetChildIndex(Me.lblReservado, 0)
        Me.Controls.SetChildIndex(Me.txtQuantidade, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtRGProduto, 0)
        Me.Controls.SetChildIndex(Me.txtDesconto, 0)
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
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblEstoque As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblReservado As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtRGProduto As TextBox
    Friend WithEvents txtDesconto As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblToolStripInfo As ToolStripStatusLabel
End Class
