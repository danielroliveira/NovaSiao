<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAPagarQuitar
    Inherits NovaSiao.frmModFinBorder

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
        Me.txtValorPago = New Controles.Text_Monetario()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlTipoPagamento = New System.Windows.Forms.Panel()
        Me.rbtParcial = New System.Windows.Forms.RadioButton()
        Me.rbtTotal = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAcrescimo = New Controles.Text_Monetario()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSaidaValor = New System.Windows.Forms.Label()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtConta = New System.Windows.Forms.TextBox()
        Me.btnContaEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpSaidaData = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.pnlTipoPagamento.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Size = New System.Drawing.Size(428, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(257, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(171, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "A Pagar - Quitar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Data do Débito:"
        '
        'txtValorPago
        '
        Me.txtValorPago.Location = New System.Drawing.Point(170, 167)
        Me.txtValorPago.Name = "txtValorPago"
        Me.txtValorPago.Size = New System.Drawing.Size(118, 27)
        Me.txtValorPago.SomentePositivos = True
        Me.txtValorPago.TabIndex = 8
        Me.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(96, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Do Valor:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(222, 350)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 48)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "&Fechar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlTipoPagamento
        '
        Me.pnlTipoPagamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pnlTipoPagamento.Controls.Add(Me.rbtParcial)
        Me.pnlTipoPagamento.Controls.Add(Me.rbtTotal)
        Me.pnlTipoPagamento.Location = New System.Drawing.Point(12, 59)
        Me.pnlTipoPagamento.Name = "pnlTipoPagamento"
        Me.pnlTipoPagamento.Size = New System.Drawing.Size(402, 33)
        Me.pnlTipoPagamento.TabIndex = 30
        '
        'rbtParcial
        '
        Me.rbtParcial.AutoSize = True
        Me.rbtParcial.Location = New System.Drawing.Point(216, 5)
        Me.rbtParcial.Name = "rbtParcial"
        Me.rbtParcial.Size = New System.Drawing.Size(148, 23)
        Me.rbtParcial.TabIndex = 1
        Me.rbtParcial.TabStop = True
        Me.rbtParcial.Text = "Pagamento Parcial"
        Me.rbtParcial.UseVisualStyleBackColor = True
        '
        'rbtTotal
        '
        Me.rbtTotal.AutoSize = True
        Me.rbtTotal.Checked = True
        Me.rbtTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.rbtTotal.Location = New System.Drawing.Point(55, 5)
        Me.rbtTotal.Name = "rbtTotal"
        Me.rbtTotal.Size = New System.Drawing.Size(136, 23)
        Me.rbtTotal.TabIndex = 0
        Me.rbtTotal.TabStop = True
        Me.rbtTotal.Text = "Pagamento Total"
        Me.rbtTotal.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(84, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Acréscimo:"
        '
        'txtAcrescimo
        '
        Me.txtAcrescimo.Location = New System.Drawing.Point(170, 200)
        Me.txtAcrescimo.Name = "txtAcrescimo"
        Me.txtAcrescimo.Size = New System.Drawing.Size(118, 27)
        Me.txtAcrescimo.SomentePositivos = True
        Me.txtAcrescimo.TabIndex = 10
        Me.txtAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 19)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Valor a ser Pago:"
        '
        'lblSaidaValor
        '
        Me.lblSaidaValor.BackColor = System.Drawing.Color.Transparent
        Me.lblSaidaValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaidaValor.Location = New System.Drawing.Point(169, 236)
        Me.lblSaidaValor.Name = "lblSaidaValor"
        Me.lblSaidaValor.Size = New System.Drawing.Size(109, 25)
        Me.lblSaidaValor.TabIndex = 13
        Me.lblSaidaValor.Text = "R$ 0,00"
        Me.lblSaidaValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnQuitar
        '
        Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnQuitar.Location = New System.Drawing.Point(92, 350)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(120, 48)
        Me.btnQuitar.TabIndex = 16
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(170, 277)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(234, 54)
        Me.txtObservacao.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Observação:"
        '
        'txtConta
        '
        Me.txtConta.Location = New System.Drawing.Point(170, 101)
        Me.txtConta.Name = "txtConta"
        Me.txtConta.Size = New System.Drawing.Size(205, 27)
        Me.txtConta.TabIndex = 3
        '
        'btnContaEscolher
        '
        Me.btnContaEscolher.AllowAnimations = True
        Me.btnContaEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnContaEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnContaEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContaEscolher.Location = New System.Drawing.Point(381, 101)
        Me.btnContaEscolher.Name = "btnContaEscolher"
        Me.btnContaEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnContaEscolher.RoundedCornersRadius = 0
        Me.btnContaEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnContaEscolher.TabIndex = 4
        Me.btnContaEscolher.TabStop = False
        Me.btnContaEscolher.Text = "..."
        Me.btnContaEscolher.UseCompatibleTextRendering = True
        Me.btnContaEscolher.UseVisualStyleBackColor = False
        Me.btnContaEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(54, 104)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(110, 19)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Conta da Saída:"
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(9, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(191, 30)
        Me.lblFilial.TabIndex = 0
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.LightGray
        Me.Label18.Location = New System.Drawing.Point(83, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Filial:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'dtpSaidaData
        '
        Me.dtpSaidaData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSaidaData.Location = New System.Drawing.Point(170, 134)
        Me.dtpSaidaData.Name = "dtpSaidaData"
        Me.dtpSaidaData.Size = New System.Drawing.Size(118, 27)
        Me.dtpSaidaData.TabIndex = 6
        '
        'frmAPagarQuitar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(428, 416)
        Me.Controls.Add(Me.dtpSaidaData)
        Me.Controls.Add(Me.txtConta)
        Me.Controls.Add(Me.btnContaEscolher)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlTipoPagamento)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtAcrescimo)
        Me.Controls.Add(Me.txtValorPago)
        Me.Controls.Add(Me.lblSaidaValor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmAPagarQuitar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblSaidaValor, 0)
        Me.Controls.SetChildIndex(Me.txtValorPago, 0)
        Me.Controls.SetChildIndex(Me.txtAcrescimo, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnQuitar, 0)
        Me.Controls.SetChildIndex(Me.pnlTipoPagamento, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtObservacao, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.btnContaEscolher, 0)
        Me.Controls.SetChildIndex(Me.txtConta, 0)
        Me.Controls.SetChildIndex(Me.dtpSaidaData, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTipoPagamento.ResumeLayout(False)
        Me.pnlTipoPagamento.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtValorPago As Controles.Text_Monetario
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents pnlTipoPagamento As Panel
    Friend WithEvents rbtParcial As RadioButton
    Friend WithEvents rbtTotal As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAcrescimo As Controles.Text_Monetario
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSaidaValor As Label
    Friend WithEvents btnQuitar As Button
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtConta As TextBox
    Friend WithEvents btnContaEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label17 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents dtpSaidaData As DateTimePicker
End Class
