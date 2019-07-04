<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFreteAPagar
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
        Me.txAPagarValor = New Controles.Text_Monetario()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCobrancaForma = New Controles.ComboBox_OnlyValues()
        Me.cmbIDBanco = New Controles.ComboBox_OnlyValues()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdentificador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpVencimento = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(341, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(144, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(197, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Inserir Cobrança"
        '
        'btnCancelar
        '
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(172, 252)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(126, 46)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnOK.Location = New System.Drawing.Point(38, 252)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(126, 46)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "Inserir"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.SlateGray
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStripInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 322)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(341, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblToolStripInfo
        '
        Me.lblToolStripInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblToolStripInfo.ForeColor = System.Drawing.Color.White
        Me.lblToolStripInfo.Name = "lblToolStripInfo"
        Me.lblToolStripInfo.Size = New System.Drawing.Size(130, 17)
        Me.lblToolStripInfo.Text = "Editando Item Existente"
        '
        'txAPagarValor
        '
        Me.txAPagarValor.Location = New System.Drawing.Point(111, 166)
        Me.txAPagarValor.Name = "txAPagarValor"
        Me.txAPagarValor.Size = New System.Drawing.Size(100, 27)
        Me.txAPagarValor.SomentePositivos = True
        Me.txAPagarValor.TabIndex = 8
        Me.txAPagarValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Vencimento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Valor"
        '
        'cmbCobrancaForma
        '
        Me.cmbCobrancaForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCobrancaForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCobrancaForma.FormattingEnabled = True
        Me.cmbCobrancaForma.Location = New System.Drawing.Point(111, 67)
        Me.cmbCobrancaForma.Name = "cmbCobrancaForma"
        Me.cmbCobrancaForma.RestrictContentToListItems = True
        Me.cmbCobrancaForma.Size = New System.Drawing.Size(160, 27)
        Me.cmbCobrancaForma.TabIndex = 2
        '
        'cmbIDBanco
        '
        Me.cmbIDBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDBanco.FormattingEnabled = True
        Me.cmbIDBanco.Location = New System.Drawing.Point(111, 199)
        Me.cmbIDBanco.Name = "cmbIDBanco"
        Me.cmbIDBanco.RestrictContentToListItems = True
        Me.cmbIDBanco.Size = New System.Drawing.Size(187, 27)
        Me.cmbIDBanco.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Identificador"
        '
        'txtIdentificador
        '
        Me.txtIdentificador.Location = New System.Drawing.Point(111, 100)
        Me.txtIdentificador.MaxLength = 30
        Me.txtIdentificador.Name = "txtIdentificador"
        Me.txtIdentificador.Size = New System.Drawing.Size(100, 27)
        Me.txtIdentificador.TabIndex = 4
        Me.txtIdentificador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Forma"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Banco"
        '
        'dtpVencimento
        '
        Me.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVencimento.Location = New System.Drawing.Point(111, 133)
        Me.dtpVencimento.Name = "dtpVencimento"
        Me.dtpVencimento.Size = New System.Drawing.Size(160, 27)
        Me.dtpVencimento.TabIndex = 6
        Me.dtpVencimento.Value = New Date(2019, 7, 3, 0, 0, 0, 0)
        '
        'frmFreteAPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(341, 344)
        Me.Controls.Add(Me.dtpVencimento)
        Me.Controls.Add(Me.cmbIDBanco)
        Me.Controls.Add(Me.cmbCobrancaForma)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIdentificador)
        Me.Controls.Add(Me.txAPagarValor)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmFreteAPagar"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.StatusStrip1, 0)
        Me.Controls.SetChildIndex(Me.txAPagarValor, 0)
        Me.Controls.SetChildIndex(Me.txtIdentificador, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cmbCobrancaForma, 0)
        Me.Controls.SetChildIndex(Me.cmbIDBanco, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dtpVencimento, 0)
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
    Friend WithEvents txAPagarValor As Controles.Text_Monetario
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbCobrancaForma As Controles.ComboBox_OnlyValues
    Friend WithEvents cmbIDBanco As Controles.ComboBox_OnlyValues
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIdentificador As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpVencimento As DateTimePicker
End Class
