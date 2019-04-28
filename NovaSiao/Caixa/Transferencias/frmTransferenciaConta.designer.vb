<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransferenciaConta
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
        Me.txtTransferenciaValor = New Controles.Text_Monetario()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComissaoValor = New Controles.Text_Monetario()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblValorReal = New System.Windows.Forms.Label()
        Me.btnEfetuar = New System.Windows.Forms.Button()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtContaCredito = New System.Windows.Forms.TextBox()
        Me.btnContaCredEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnContaDebEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.txtContaDebito = New System.Windows.Forms.TextBox()
        Me.dtpTransferenciaData = New System.Windows.Forms.DateTimePicker()
        Me.cmbMeio = New Controles.ComboBox_OnlyValues()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.VPanel1 = New VIBlend.WinForms.Controls.vPanel()
        Me.VPanel2 = New VIBlend.WinForms.Controls.vPanel()
        Me.VPanel3 = New VIBlend.WinForms.Controls.vPanel()
        Me.Panel1.SuspendLayout()
        Me.VPanel1.Content.SuspendLayout()
        Me.VPanel1.SuspendLayout()
        Me.VPanel2.Content.SuspendLayout()
        Me.VPanel2.SuspendLayout()
        Me.VPanel3.Content.SuspendLayout()
        Me.VPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Size = New System.Drawing.Size(477, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(238, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(239, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Efetuar Transferência"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data do Débito:"
        '
        'txtTransferenciaValor
        '
        Me.txtTransferenciaValor.Location = New System.Drawing.Point(157, 41)
        Me.txtTransferenciaValor.Name = "txtTransferenciaValor"
        Me.txtTransferenciaValor.Size = New System.Drawing.Size(127, 27)
        Me.txtTransferenciaValor.TabIndex = 3
        Me.txtTransferenciaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(105, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 19)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Valor:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(246, 414)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(141, 48)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(75, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Comissão:"
        '
        'txtComissaoValor
        '
        Me.txtComissaoValor.Location = New System.Drawing.Point(157, 74)
        Me.txtComissaoValor.Name = "txtComissaoValor"
        Me.txtComissaoValor.Size = New System.Drawing.Size(127, 27)
        Me.txtComissaoValor.TabIndex = 5
        Me.txtComissaoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 19)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Valor Transferido:"
        '
        'lblValorReal
        '
        Me.lblValorReal.BackColor = System.Drawing.Color.Transparent
        Me.lblValorReal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorReal.Location = New System.Drawing.Point(156, 110)
        Me.lblValorReal.Name = "lblValorReal"
        Me.lblValorReal.Size = New System.Drawing.Size(128, 25)
        Me.lblValorReal.TabIndex = 7
        Me.lblValorReal.Text = "R$ 0,00"
        Me.lblValorReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEfetuar
        '
        Me.btnEfetuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEfetuar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnEfetuar.Location = New System.Drawing.Point(92, 414)
        Me.btnEfetuar.Name = "btnEfetuar"
        Me.btnEfetuar.Size = New System.Drawing.Size(141, 48)
        Me.btnEfetuar.TabIndex = 4
        Me.btnEfetuar.Text = "&Transferir"
        Me.btnEfetuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEfetuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEfetuar.UseVisualStyleBackColor = True
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(157, 8)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(245, 54)
        Me.txtObservacao.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Observação:"
        '
        'txtContaCredito
        '
        Me.txtContaCredito.Location = New System.Drawing.Point(157, 42)
        Me.txtContaCredito.Name = "txtContaCredito"
        Me.txtContaCredito.Size = New System.Drawing.Size(205, 27)
        Me.txtContaCredito.TabIndex = 4
        '
        'btnContaCredEscolher
        '
        Me.btnContaCredEscolher.AllowAnimations = True
        Me.btnContaCredEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnContaCredEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnContaCredEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContaCredEscolher.Location = New System.Drawing.Point(368, 42)
        Me.btnContaCredEscolher.Name = "btnContaCredEscolher"
        Me.btnContaCredEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnContaCredEscolher.RoundedCornersRadius = 0
        Me.btnContaCredEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnContaCredEscolher.TabIndex = 5
        Me.btnContaCredEscolher.TabStop = False
        Me.btnContaCredEscolher.Text = "..."
        Me.btnContaCredEscolher.UseCompatibleTextRendering = True
        Me.btnContaCredEscolher.UseVisualStyleBackColor = False
        Me.btnContaCredEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(26, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 19)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Conta de Entrada:"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Conta de Saída:"
        '
        'btnContaDebEscolher
        '
        Me.btnContaDebEscolher.AllowAnimations = True
        Me.btnContaDebEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnContaDebEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnContaDebEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContaDebEscolher.Location = New System.Drawing.Point(368, 9)
        Me.btnContaDebEscolher.Name = "btnContaDebEscolher"
        Me.btnContaDebEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnContaDebEscolher.RoundedCornersRadius = 0
        Me.btnContaDebEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnContaDebEscolher.TabIndex = 2
        Me.btnContaDebEscolher.TabStop = False
        Me.btnContaDebEscolher.Text = "..."
        Me.btnContaDebEscolher.UseCompatibleTextRendering = True
        Me.btnContaDebEscolher.UseVisualStyleBackColor = False
        Me.btnContaDebEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtContaDebito
        '
        Me.txtContaDebito.Location = New System.Drawing.Point(157, 9)
        Me.txtContaDebito.Name = "txtContaDebito"
        Me.txtContaDebito.Size = New System.Drawing.Size(205, 27)
        Me.txtContaDebito.TabIndex = 1
        '
        'dtpTransferenciaData
        '
        Me.dtpTransferenciaData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransferenciaData.Location = New System.Drawing.Point(157, 8)
        Me.dtpTransferenciaData.Name = "dtpTransferenciaData"
        Me.dtpTransferenciaData.Size = New System.Drawing.Size(127, 27)
        Me.dtpTransferenciaData.TabIndex = 1
        '
        'cmbMeio
        '
        Me.cmbMeio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMeio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMeio.FormattingEnabled = True
        Me.cmbMeio.Location = New System.Drawing.Point(157, 75)
        Me.cmbMeio.Name = "cmbMeio"
        Me.cmbMeio.RestrictContentToListItems = True
        Me.cmbMeio.Size = New System.Drawing.Size(205, 27)
        Me.cmbMeio.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(57, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Meio de Pag."
        '
        'VPanel1
        '
        Me.VPanel1.AllowAnimations = True
        Me.VPanel1.BorderRadius = 0
        '
        'VPanel1.Content
        '
        Me.VPanel1.Content.AutoScroll = True
        Me.VPanel1.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel1.Content.Controls.Add(Me.cmbMeio)
        Me.VPanel1.Content.Controls.Add(Me.Label17)
        Me.VPanel1.Content.Controls.Add(Me.Label7)
        Me.VPanel1.Content.Controls.Add(Me.btnContaCredEscolher)
        Me.VPanel1.Content.Controls.Add(Me.Label3)
        Me.VPanel1.Content.Controls.Add(Me.txtContaDebito)
        Me.VPanel1.Content.Controls.Add(Me.txtContaCredito)
        Me.VPanel1.Content.Controls.Add(Me.btnContaDebEscolher)
        Me.VPanel1.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel1.Content.Name = "Content"
        Me.VPanel1.Content.Size = New System.Drawing.Size(451, 112)
        Me.VPanel1.Content.TabIndex = 3
        Me.VPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel1.Location = New System.Drawing.Point(12, 60)
        Me.VPanel1.Name = "VPanel1"
        Me.VPanel1.Opacity = 1.0!
        Me.VPanel1.PanelBorderColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.VPanel1.Size = New System.Drawing.Size(453, 114)
        Me.VPanel1.TabIndex = 1
        Me.VPanel1.Text = "VPanel1"
        Me.VPanel1.UsePanelBorderColor = True
        Me.VPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'VPanel2
        '
        Me.VPanel2.AllowAnimations = True
        Me.VPanel2.BorderRadius = 0
        '
        'VPanel2.Content
        '
        Me.VPanel2.Content.AutoScroll = True
        Me.VPanel2.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel2.Content.Controls.Add(Me.dtpTransferenciaData)
        Me.VPanel2.Content.Controls.Add(Me.Label1)
        Me.VPanel2.Content.Controls.Add(Me.Label4)
        Me.VPanel2.Content.Controls.Add(Me.Label5)
        Me.VPanel2.Content.Controls.Add(Me.Label6)
        Me.VPanel2.Content.Controls.Add(Me.lblValorReal)
        Me.VPanel2.Content.Controls.Add(Me.txtComissaoValor)
        Me.VPanel2.Content.Controls.Add(Me.txtTransferenciaValor)
        Me.VPanel2.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel2.Content.Name = "Content"
        Me.VPanel2.Content.Size = New System.Drawing.Size(451, 146)
        Me.VPanel2.Content.TabIndex = 3
        Me.VPanel2.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel2.Location = New System.Drawing.Point(12, 180)
        Me.VPanel2.Name = "VPanel2"
        Me.VPanel2.Opacity = 1.0!
        Me.VPanel2.PanelBorderColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.VPanel2.Size = New System.Drawing.Size(453, 148)
        Me.VPanel2.TabIndex = 2
        Me.VPanel2.Text = "VPanel2"
        Me.VPanel2.UsePanelBorderColor = True
        Me.VPanel2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'VPanel3
        '
        Me.VPanel3.AllowAnimations = True
        Me.VPanel3.BorderRadius = 0
        '
        'VPanel3.Content
        '
        Me.VPanel3.Content.AutoScroll = True
        Me.VPanel3.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel3.Content.Controls.Add(Me.txtObservacao)
        Me.VPanel3.Content.Controls.Add(Me.Label2)
        Me.VPanel3.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel3.Content.Name = "Content"
        Me.VPanel3.Content.Size = New System.Drawing.Size(451, 69)
        Me.VPanel3.Content.TabIndex = 3
        Me.VPanel3.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel3.Location = New System.Drawing.Point(12, 334)
        Me.VPanel3.Name = "VPanel3"
        Me.VPanel3.Opacity = 1.0!
        Me.VPanel3.PanelBorderColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.VPanel3.Size = New System.Drawing.Size(453, 71)
        Me.VPanel3.TabIndex = 3
        Me.VPanel3.Text = "VPanel3"
        Me.VPanel3.UsePanelBorderColor = True
        Me.VPanel3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'frmTransferenciaConta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(477, 474)
        Me.Controls.Add(Me.btnEfetuar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.VPanel1)
        Me.Controls.Add(Me.VPanel2)
        Me.Controls.Add(Me.VPanel3)
        Me.KeyPreview = True
        Me.Name = "frmTransferenciaConta"
        Me.Controls.SetChildIndex(Me.VPanel3, 0)
        Me.Controls.SetChildIndex(Me.VPanel2, 0)
        Me.Controls.SetChildIndex(Me.VPanel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnEfetuar, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.VPanel1.Content.ResumeLayout(False)
        Me.VPanel1.Content.PerformLayout()
        Me.VPanel1.ResumeLayout(False)
        Me.VPanel2.Content.ResumeLayout(False)
        Me.VPanel2.Content.PerformLayout()
        Me.VPanel2.ResumeLayout(False)
        Me.VPanel3.Content.ResumeLayout(False)
        Me.VPanel3.Content.PerformLayout()
        Me.VPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTransferenciaValor As Controles.Text_Monetario
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtComissaoValor As Controles.Text_Monetario
    Friend WithEvents Label6 As Label
    Friend WithEvents lblValorReal As Label
    Friend WithEvents btnEfetuar As Button
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtContaCredito As TextBox
    Friend WithEvents btnContaCredEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label17 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnContaDebEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtContaDebito As TextBox
    Friend WithEvents dtpTransferenciaData As DateTimePicker
    Friend WithEvents cmbMeio As Controles.ComboBox_OnlyValues
    Friend WithEvents Label7 As Label
    Friend WithEvents VPanel1 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents VPanel2 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents VPanel3 As VIBlend.WinForms.Controls.vPanel
End Class
