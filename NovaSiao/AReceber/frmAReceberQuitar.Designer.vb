<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAReceberQuitar
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
        Me.txtEntradaData = New Controles.MaskText_Data()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDoValor = New Controles.Text_Monetario()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtCreditar = New System.Windows.Forms.RadioButton()
        Me.rbtEntrada = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAcrescimo = New Controles.Text_Monetario()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEntradaValor = New System.Windows.Forms.Label()
        Me.cmbIDMovForma = New Controles.ComboBox_OnlyValues()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnContaEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.txtConta = New System.Windows.Forms.TextBox()
        Me.btnTipoEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(426, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(186, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(240, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "A Receber - Quitar"
        '
        'txtEntradaData
        '
        Me.txtEntradaData.Location = New System.Drawing.Point(170, 134)
        Me.txtEntradaData.Mask = "00/00/0000"
        Me.txtEntradaData.Name = "txtEntradaData"
        Me.txtEntradaData.Size = New System.Drawing.Size(109, 27)
        Me.txtEntradaData.TabIndex = 6
        Me.txtEntradaData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Entrada Data:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Conta da Entrada:"
        '
        'txtDoValor
        '
        Me.txtDoValor.Location = New System.Drawing.Point(170, 167)
        Me.txtDoValor.Name = "txtDoValor"
        Me.txtDoValor.Size = New System.Drawing.Size(109, 27)
        Me.txtDoValor.TabIndex = 8
        Me.txtDoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(95, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Do Valor:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(218, 404)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(128, 48)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel2.Controls.Add(Me.rbtCreditar)
        Me.Panel2.Controls.Add(Me.rbtEntrada)
        Me.Panel2.Location = New System.Drawing.Point(12, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(402, 33)
        Me.Panel2.TabIndex = 25
        '
        'rbtCreditar
        '
        Me.rbtCreditar.AutoSize = True
        Me.rbtCreditar.Enabled = False
        Me.rbtCreditar.Location = New System.Drawing.Point(231, 5)
        Me.rbtCreditar.Name = "rbtCreditar"
        Me.rbtCreditar.Size = New System.Drawing.Size(79, 23)
        Me.rbtCreditar.TabIndex = 1
        Me.rbtCreditar.Text = "Creditar"
        Me.rbtCreditar.UseVisualStyleBackColor = True
        '
        'rbtEntrada
        '
        Me.rbtEntrada.AutoSize = True
        Me.rbtEntrada.Checked = True
        Me.rbtEntrada.Cursor = System.Windows.Forms.Cursors.Default
        Me.rbtEntrada.Location = New System.Drawing.Point(102, 5)
        Me.rbtEntrada.Name = "rbtEntrada"
        Me.rbtEntrada.Size = New System.Drawing.Size(77, 23)
        Me.rbtEntrada.TabIndex = 0
        Me.rbtEntrada.Text = "Entrada"
        Me.rbtEntrada.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Do Acréscimo:"
        '
        'txtAcrescimo
        '
        Me.txtAcrescimo.Location = New System.Drawing.Point(170, 200)
        Me.txtAcrescimo.Name = "txtAcrescimo"
        Me.txtAcrescimo.Size = New System.Drawing.Size(109, 27)
        Me.txtAcrescimo.TabIndex = 10
        Me.txtAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 19)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Valor a ser Recebido:"
        '
        'lblEntradaValor
        '
        Me.lblEntradaValor.BackColor = System.Drawing.Color.Transparent
        Me.lblEntradaValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntradaValor.Location = New System.Drawing.Point(170, 237)
        Me.lblEntradaValor.Name = "lblEntradaValor"
        Me.lblEntradaValor.Size = New System.Drawing.Size(109, 25)
        Me.lblEntradaValor.TabIndex = 12
        Me.lblEntradaValor.Text = "R$ 0,00"
        Me.lblEntradaValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbIDMovForma
        '
        Me.cmbIDMovForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDMovForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDMovForma.FormattingEnabled = True
        Me.cmbIDMovForma.Location = New System.Drawing.Point(170, 307)
        Me.cmbIDMovForma.Name = "cmbIDMovForma"
        Me.cmbIDMovForma.RestrictContentToListItems = True
        Me.cmbIDMovForma.Size = New System.Drawing.Size(234, 27)
        Me.cmbIDMovForma.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(110, 310)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 19)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Forma:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(122, 277)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 19)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Tipo:"
        '
        'btnQuitar
        '
        Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnQuitar.Location = New System.Drawing.Point(81, 404)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(128, 48)
        Me.btnQuitar.TabIndex = 20
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(170, 340)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(234, 54)
        Me.txtObservacao.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 340)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Observação:"
        '
        'btnContaEscolher
        '
        Me.btnContaEscolher.AllowAnimations = True
        Me.btnContaEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnContaEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnContaEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContaEscolher.Location = New System.Drawing.Point(380, 101)
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
        'txtConta
        '
        Me.txtConta.Location = New System.Drawing.Point(170, 101)
        Me.txtConta.Name = "txtConta"
        Me.txtConta.Size = New System.Drawing.Size(204, 27)
        Me.txtConta.TabIndex = 1
        '
        'btnTipoEscolher
        '
        Me.btnTipoEscolher.AllowAnimations = True
        Me.btnTipoEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnTipoEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTipoEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTipoEscolher.Location = New System.Drawing.Point(327, 274)
        Me.btnTipoEscolher.Name = "btnTipoEscolher"
        Me.btnTipoEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnTipoEscolher.RoundedCornersRadius = 0
        Me.btnTipoEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnTipoEscolher.TabIndex = 15
        Me.btnTipoEscolher.TabStop = False
        Me.btnTipoEscolher.Text = "..."
        Me.btnTipoEscolher.UseCompatibleTextRendering = True
        Me.btnTipoEscolher.UseVisualStyleBackColor = False
        Me.btnTipoEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(170, 274)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(151, 27)
        Me.txtTipo.TabIndex = 14
        '
        'frmAReceberQuitar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(426, 464)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.txtConta)
        Me.Controls.Add(Me.btnTipoEscolher)
        Me.Controls.Add(Me.btnContaEscolher)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.cmbIDMovForma)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtAcrescimo)
        Me.Controls.Add(Me.txtDoValor)
        Me.Controls.Add(Me.lblEntradaValor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEntradaData)
        Me.KeyPreview = True
        Me.Name = "frmAReceberQuitar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.txtEntradaData, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblEntradaValor, 0)
        Me.Controls.SetChildIndex(Me.txtDoValor, 0)
        Me.Controls.SetChildIndex(Me.txtAcrescimo, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnQuitar, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cmbIDMovForma, 0)
        Me.Controls.SetChildIndex(Me.txtObservacao, 0)
        Me.Controls.SetChildIndex(Me.btnContaEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnTipoEscolher, 0)
        Me.Controls.SetChildIndex(Me.txtConta, 0)
        Me.Controls.SetChildIndex(Me.txtTipo, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEntradaData As Controles.MaskText_Data
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDoValor As Controles.Text_Monetario
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbtCreditar As RadioButton
    Friend WithEvents rbtEntrada As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAcrescimo As Controles.Text_Monetario
    Friend WithEvents Label6 As Label
    Friend WithEvents lblEntradaValor As Label
    Friend WithEvents cmbIDMovForma As Controles.ComboBox_OnlyValues
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnQuitar As Button
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnContaEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtConta As TextBox
    Friend WithEvents btnTipoEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtTipo As TextBox
End Class
