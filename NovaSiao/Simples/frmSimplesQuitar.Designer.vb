<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSimplesQuitar
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
        Me.lblData = New System.Windows.Forms.Label()
        Me.lblContaOrigem = New System.Windows.Forms.Label()
        Me.cmbIDContaOrigem = New Controles.ComboBox_OnlyValues()
        Me.txtValor = New Controles.Text_Monetario()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtCredito = New System.Windows.Forms.RadioButton()
        Me.rbtTransferencia = New System.Windows.Forms.RadioButton()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnProcurarFilial = New VIBlend.WinForms.Controls.vButton()
        Me.lblFilialDestino = New System.Windows.Forms.Label()
        Me.txtFilialDestino = New System.Windows.Forms.TextBox()
        Me.lblContaDestino = New System.Windows.Forms.Label()
        Me.cmbIDContaDestino = New Controles.ComboBox_OnlyValues()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.dtpEntradaData = New System.Windows.Forms.DateTimePicker()
        Me.chkValorMaximo = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Size = New System.Drawing.Size(408, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label18, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(182, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(226, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Simples - Quitar"
        '
        'lblData
        '
        Me.lblData.Location = New System.Drawing.Point(12, 209)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(129, 19)
        Me.lblData.TabIndex = 9
        Me.lblData.Text = "Entrada Data"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblContaOrigem
        '
        Me.lblContaOrigem.Location = New System.Drawing.Point(12, 110)
        Me.lblContaOrigem.Name = "lblContaOrigem"
        Me.lblContaOrigem.Size = New System.Drawing.Size(129, 19)
        Me.lblContaOrigem.TabIndex = 2
        Me.lblContaOrigem.Text = "Conta da Entrada"
        Me.lblContaOrigem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbIDContaOrigem
        '
        Me.cmbIDContaOrigem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDContaOrigem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDContaOrigem.FormattingEnabled = True
        Me.cmbIDContaOrigem.Location = New System.Drawing.Point(147, 107)
        Me.cmbIDContaOrigem.Name = "cmbIDContaOrigem"
        Me.cmbIDContaOrigem.RestrictContentToListItems = True
        Me.cmbIDContaOrigem.Size = New System.Drawing.Size(234, 27)
        Me.cmbIDContaOrigem.TabIndex = 3
        '
        'txtValor
        '
        Me.txtValor.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Location = New System.Drawing.Point(147, 243)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(139, 31)
        Me.txtValor.TabIndex = 13
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValor
        '
        Me.lblValor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblValor.Location = New System.Drawing.Point(12, 246)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(129, 19)
        Me.lblValor.TabIndex = 12
        Me.lblValor.Text = "Valor"
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(204, 349)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(128, 48)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel2.Controls.Add(Me.rbtCredito)
        Me.Panel2.Controls.Add(Me.rbtTransferencia)
        Me.Panel2.Location = New System.Drawing.Point(2, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(404, 33)
        Me.Panel2.TabIndex = 1
        '
        'rbtCredito
        '
        Me.rbtCredito.AutoSize = True
        Me.rbtCredito.Location = New System.Drawing.Point(238, 5)
        Me.rbtCredito.Name = "rbtCredito"
        Me.rbtCredito.Size = New System.Drawing.Size(74, 23)
        Me.rbtCredito.TabIndex = 1
        Me.rbtCredito.TabStop = True
        Me.rbtCredito.Text = "Crédito"
        Me.rbtCredito.UseVisualStyleBackColor = True
        '
        'rbtTransferencia
        '
        Me.rbtTransferencia.AutoSize = True
        Me.rbtTransferencia.Checked = True
        Me.rbtTransferencia.Cursor = System.Windows.Forms.Cursors.Default
        Me.rbtTransferencia.Location = New System.Drawing.Point(87, 5)
        Me.rbtTransferencia.Name = "rbtTransferencia"
        Me.rbtTransferencia.Size = New System.Drawing.Size(115, 23)
        Me.rbtTransferencia.TabIndex = 0
        Me.rbtTransferencia.TabStop = True
        Me.rbtTransferencia.Text = "Transferência"
        Me.rbtTransferencia.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnQuitar.Location = New System.Drawing.Point(66, 349)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(128, 48)
        Me.btnQuitar.TabIndex = 16
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'txtObservacao
        '
        Me.txtObservacao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservacao.Location = New System.Drawing.Point(147, 280)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(234, 54)
        Me.txtObservacao.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(12, 280)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 19)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Observação"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnProcurarFilial
        '
        Me.btnProcurarFilial.AllowAnimations = True
        Me.btnProcurarFilial.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurarFilial.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcurarFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcurarFilial.Location = New System.Drawing.Point(347, 140)
        Me.btnProcurarFilial.Name = "btnProcurarFilial"
        Me.btnProcurarFilial.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurarFilial.RoundedCornersRadius = 0
        Me.btnProcurarFilial.Size = New System.Drawing.Size(34, 27)
        Me.btnProcurarFilial.TabIndex = 6
        Me.btnProcurarFilial.TabStop = False
        Me.btnProcurarFilial.Text = "..."
        Me.btnProcurarFilial.UseCompatibleTextRendering = True
        Me.btnProcurarFilial.UseVisualStyleBackColor = False
        Me.btnProcurarFilial.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblFilialDestino
        '
        Me.lblFilialDestino.Location = New System.Drawing.Point(12, 143)
        Me.lblFilialDestino.Name = "lblFilialDestino"
        Me.lblFilialDestino.Size = New System.Drawing.Size(129, 19)
        Me.lblFilialDestino.TabIndex = 4
        Me.lblFilialDestino.Text = "Filial | Origem"
        Me.lblFilialDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFilialDestino
        '
        Me.txtFilialDestino.Location = New System.Drawing.Point(147, 140)
        Me.txtFilialDestino.Name = "txtFilialDestino"
        Me.txtFilialDestino.Size = New System.Drawing.Size(194, 27)
        Me.txtFilialDestino.TabIndex = 5
        '
        'lblContaDestino
        '
        Me.lblContaDestino.Location = New System.Drawing.Point(12, 176)
        Me.lblContaDestino.Name = "lblContaDestino"
        Me.lblContaDestino.Size = New System.Drawing.Size(129, 19)
        Me.lblContaDestino.TabIndex = 7
        Me.lblContaDestino.Text = "Conta | Origem"
        Me.lblContaDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbIDContaDestino
        '
        Me.cmbIDContaDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDContaDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDContaDestino.FormattingEnabled = True
        Me.cmbIDContaDestino.Location = New System.Drawing.Point(147, 173)
        Me.cmbIDContaDestino.Name = "cmbIDContaDestino"
        Me.cmbIDContaDestino.RestrictContentToListItems = True
        Me.cmbIDContaDestino.Size = New System.Drawing.Size(234, 27)
        Me.cmbIDContaDestino.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label18.Location = New System.Drawing.Point(55, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Filial:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(6, 16)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(145, 30)
        Me.lblFilial.TabIndex = 0
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpEntradaData
        '
        Me.dtpEntradaData.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEntradaData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEntradaData.Location = New System.Drawing.Point(147, 206)
        Me.dtpEntradaData.Name = "dtpEntradaData"
        Me.dtpEntradaData.Size = New System.Drawing.Size(139, 31)
        Me.dtpEntradaData.TabIndex = 10
        '
        'chkValorMaximo
        '
        Me.chkValorMaximo.AutoSize = True
        Me.chkValorMaximo.Location = New System.Drawing.Point(16, 311)
        Me.chkValorMaximo.Name = "chkValorMaximo"
        Me.chkValorMaximo.Size = New System.Drawing.Size(117, 23)
        Me.chkValorMaximo.TabIndex = 11
        Me.chkValorMaximo.Text = "Valor Máximo"
        Me.chkValorMaximo.UseVisualStyleBackColor = True
        '
        'frmSimplesQuitar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(408, 409)
        Me.Controls.Add(Me.chkValorMaximo)
        Me.Controls.Add(Me.dtpEntradaData)
        Me.Controls.Add(Me.btnProcurarFilial)
        Me.Controls.Add(Me.lblFilialDestino)
        Me.Controls.Add(Me.txtFilialDestino)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.cmbIDContaDestino)
        Me.Controls.Add(Me.cmbIDContaOrigem)
        Me.Controls.Add(Me.lblContaDestino)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.lblContaOrigem)
        Me.Controls.Add(Me.lblData)
        Me.KeyPreview = True
        Me.Name = "frmSimplesQuitar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblData, 0)
        Me.Controls.SetChildIndex(Me.lblContaOrigem, 0)
        Me.Controls.SetChildIndex(Me.lblValor, 0)
        Me.Controls.SetChildIndex(Me.lblContaDestino, 0)
        Me.Controls.SetChildIndex(Me.cmbIDContaOrigem, 0)
        Me.Controls.SetChildIndex(Me.cmbIDContaDestino, 0)
        Me.Controls.SetChildIndex(Me.txtValor, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnQuitar, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtObservacao, 0)
        Me.Controls.SetChildIndex(Me.txtFilialDestino, 0)
        Me.Controls.SetChildIndex(Me.lblFilialDestino, 0)
        Me.Controls.SetChildIndex(Me.btnProcurarFilial, 0)
        Me.Controls.SetChildIndex(Me.dtpEntradaData, 0)
        Me.Controls.SetChildIndex(Me.chkValorMaximo, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblData As Label
    Friend WithEvents lblContaOrigem As Label
    Friend WithEvents cmbIDContaOrigem As Controles.ComboBox_OnlyValues
    Friend WithEvents txtValor As Controles.Text_Monetario
    Friend WithEvents lblValor As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbtCredito As RadioButton
    Friend WithEvents rbtTransferencia As RadioButton
    Friend WithEvents btnQuitar As Button
    Friend WithEvents txtObservacao As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnProcurarFilial As VIBlend.WinForms.Controls.vButton
    Friend WithEvents lblFilialDestino As Label
    Friend WithEvents txtFilialDestino As TextBox
    Friend WithEvents lblContaDestino As Label
    Friend WithEvents cmbIDContaDestino As Controles.ComboBox_OnlyValues
    Friend WithEvents Label18 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents dtpEntradaData As DateTimePicker
    Friend WithEvents chkValorMaximo As CheckBox
End Class
