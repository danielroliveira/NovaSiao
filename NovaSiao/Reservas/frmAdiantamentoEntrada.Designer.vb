<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdiantamentoEntrada
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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtValorAdiantamento = New Controles.Text_Monetario()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.cmbIDMovForma = New Controles.ComboBox_OnlyValues()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.btnQuitar = New System.Windows.Forms.Button()
		Me.btnContaEscolher = New VIBlend.WinForms.Controls.vButton()
		Me.txtConta = New System.Windows.Forms.TextBox()
		Me.btnTipoEscolher = New VIBlend.WinForms.Controls.vButton()
		Me.txtTipo = New System.Windows.Forms.TextBox()
		Me.dtpEntradaData = New System.Windows.Forms.DateTimePicker()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Size = New System.Drawing.Size(426, 50)
		Me.Panel1.TabIndex = 0
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(145, 0)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(281, 50)
		Me.lblTitulo.TabIndex = 0
		Me.lblTitulo.Text = "Adiantamento de Reserva"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(55, 109)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(98, 19)
		Me.Label1.TabIndex = 4
		Me.Label1.Text = "Entrada Data:"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(28, 76)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(125, 19)
		Me.Label3.TabIndex = 1
		Me.Label3.Text = "Conta da Entrada:"
		'
		'txtValorAdiantamento
		'
		Me.txtValorAdiantamento.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtValorAdiantamento.Location = New System.Drawing.Point(160, 231)
		Me.txtValorAdiantamento.Name = "txtValorAdiantamento"
		Me.txtValorAdiantamento.Size = New System.Drawing.Size(131, 31)
		Me.txtValorAdiantamento.SomentePositivos = True
		Me.txtValorAdiantamento.TabIndex = 12
		Me.txtValorAdiantamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(43, 234)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(110, 19)
		Me.Label4.TabIndex = 11
		Me.Label4.Text = "Valor Recebido:"
		'
		'btnCancelar
		'
		Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
		Me.btnCancelar.Location = New System.Drawing.Point(218, 292)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(128, 48)
		Me.btnCancelar.TabIndex = 14
		Me.btnCancelar.Text = "&Cancelar"
		Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnCancelar.UseVisualStyleBackColor = True
		'
		'cmbIDMovForma
		'
		Me.cmbIDMovForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbIDMovForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbIDMovForma.FormattingEnabled = True
		Me.cmbIDMovForma.Location = New System.Drawing.Point(160, 185)
		Me.cmbIDMovForma.Name = "cmbIDMovForma"
		Me.cmbIDMovForma.RestrictContentToListItems = True
		Me.cmbIDMovForma.Size = New System.Drawing.Size(234, 27)
		Me.cmbIDMovForma.TabIndex = 10
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(100, 188)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(53, 19)
		Me.Label8.TabIndex = 9
		Me.Label8.Text = "Forma:"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(112, 155)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(41, 19)
		Me.Label9.TabIndex = 6
		Me.Label9.Text = "Tipo:"
		'
		'btnQuitar
		'
		Me.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnQuitar.Enabled = False
		Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
		Me.btnQuitar.Location = New System.Drawing.Point(81, 292)
		Me.btnQuitar.Name = "btnQuitar"
		Me.btnQuitar.Size = New System.Drawing.Size(128, 48)
		Me.btnQuitar.TabIndex = 13
		Me.btnQuitar.Text = "&Quitar"
		Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnQuitar.UseVisualStyleBackColor = True
		'
		'btnContaEscolher
		'
		Me.btnContaEscolher.AllowAnimations = True
		Me.btnContaEscolher.BackColor = System.Drawing.Color.Transparent
		Me.btnContaEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnContaEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnContaEscolher.Location = New System.Drawing.Point(370, 73)
		Me.btnContaEscolher.Name = "btnContaEscolher"
		Me.btnContaEscolher.RoundedCornersMask = CType(15, Byte)
		Me.btnContaEscolher.RoundedCornersRadius = 0
		Me.btnContaEscolher.Size = New System.Drawing.Size(34, 27)
		Me.btnContaEscolher.TabIndex = 3
		Me.btnContaEscolher.TabStop = False
		Me.btnContaEscolher.Text = "..."
		Me.btnContaEscolher.UseCompatibleTextRendering = True
		Me.btnContaEscolher.UseVisualStyleBackColor = False
		Me.btnContaEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'txtConta
		'
		Me.txtConta.Location = New System.Drawing.Point(160, 73)
		Me.txtConta.Name = "txtConta"
		Me.txtConta.Size = New System.Drawing.Size(204, 27)
		Me.txtConta.TabIndex = 2
		'
		'btnTipoEscolher
		'
		Me.btnTipoEscolher.AllowAnimations = True
		Me.btnTipoEscolher.BackColor = System.Drawing.Color.Transparent
		Me.btnTipoEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.btnTipoEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnTipoEscolher.Location = New System.Drawing.Point(360, 152)
		Me.btnTipoEscolher.Name = "btnTipoEscolher"
		Me.btnTipoEscolher.RoundedCornersMask = CType(15, Byte)
		Me.btnTipoEscolher.RoundedCornersRadius = 0
		Me.btnTipoEscolher.Size = New System.Drawing.Size(34, 27)
		Me.btnTipoEscolher.TabIndex = 8
		Me.btnTipoEscolher.TabStop = False
		Me.btnTipoEscolher.Text = "..."
		Me.btnTipoEscolher.UseCompatibleTextRendering = True
		Me.btnTipoEscolher.UseVisualStyleBackColor = False
		Me.btnTipoEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
		'
		'txtTipo
		'
		Me.txtTipo.Location = New System.Drawing.Point(160, 152)
		Me.txtTipo.Name = "txtTipo"
		Me.txtTipo.Size = New System.Drawing.Size(194, 27)
		Me.txtTipo.TabIndex = 7
		'
		'dtpEntradaData
		'
		Me.dtpEntradaData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dtpEntradaData.Location = New System.Drawing.Point(160, 106)
		Me.dtpEntradaData.Name = "dtpEntradaData"
		Me.dtpEntradaData.Size = New System.Drawing.Size(131, 27)
		Me.dtpEntradaData.TabIndex = 5
		'
		'frmAdiantamentoEntrada
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(426, 352)
		Me.Controls.Add(Me.dtpEntradaData)
		Me.Controls.Add(Me.txtTipo)
		Me.Controls.Add(Me.txtConta)
		Me.Controls.Add(Me.btnTipoEscolher)
		Me.Controls.Add(Me.btnContaEscolher)
		Me.Controls.Add(Me.cmbIDMovForma)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.btnQuitar)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.txtValorAdiantamento)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label1)
		Me.KeyPreview = True
		Me.Name = "frmAdiantamentoEntrada"
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.Label4, 0)
		Me.Controls.SetChildIndex(Me.txtValorAdiantamento, 0)
		Me.Controls.SetChildIndex(Me.btnCancelar, 0)
		Me.Controls.SetChildIndex(Me.btnQuitar, 0)
		Me.Controls.SetChildIndex(Me.Label9, 0)
		Me.Controls.SetChildIndex(Me.Label8, 0)
		Me.Controls.SetChildIndex(Me.cmbIDMovForma, 0)
		Me.Controls.SetChildIndex(Me.btnContaEscolher, 0)
		Me.Controls.SetChildIndex(Me.btnTipoEscolher, 0)
		Me.Controls.SetChildIndex(Me.txtConta, 0)
		Me.Controls.SetChildIndex(Me.txtTipo, 0)
		Me.Controls.SetChildIndex(Me.dtpEntradaData, 0)
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Label1 As Label
	Friend WithEvents Label3 As Label
    Friend WithEvents txtValorAdiantamento As Controles.Text_Monetario
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancelar As Button
	Friend WithEvents cmbIDMovForma As Controles.ComboBox_OnlyValues
	Friend WithEvents Label8 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents btnQuitar As Button
	Friend WithEvents btnContaEscolher As VIBlend.WinForms.Controls.vButton
	Friend WithEvents txtConta As TextBox
    Friend WithEvents btnTipoEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtTipo As TextBox
	Friend WithEvents dtpEntradaData As DateTimePicker
End Class
