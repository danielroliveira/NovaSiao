<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespesaParcelamento
    Inherits NovaSiao.frmModFinBorder

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
        Me.cmbCobrancaForma = New Controles.ComboBox_OnlyValues()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbIDBanco = New Controles.ComboBox_OnlyValues()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblParcelas = New System.Windows.Forms.Label()
        Me.chkEntrada = New System.Windows.Forms.CheckBox()
        Me.txtParcelas = New Controles.Text_SoNumeros()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(370, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(116, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(254, 50)
        Me.lblTitulo.Text = "Parcelamento"
        '
        'cmbCobrancaForma
        '
        Me.cmbCobrancaForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCobrancaForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCobrancaForma.FormattingEnabled = True
        Me.cmbCobrancaForma.Location = New System.Drawing.Point(116, 81)
        Me.cmbCobrancaForma.Name = "cmbCobrancaForma"
        Me.cmbCobrancaForma.RestrictContentToListItems = True
        Me.cmbCobrancaForma.Size = New System.Drawing.Size(166, 27)
        Me.cmbCobrancaForma.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Forma"
        '
        'cmbIDBanco
        '
        Me.cmbIDBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIDBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIDBanco.FormattingEnabled = True
        Me.cmbIDBanco.Location = New System.Drawing.Point(116, 122)
        Me.cmbIDBanco.Name = "cmbIDBanco"
        Me.cmbIDBanco.RestrictContentToListItems = True
        Me.cmbIDBanco.Size = New System.Drawing.Size(225, 27)
        Me.cmbIDBanco.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 19)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Banco"
        '
        'btnCancelar
        '
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(185, 227)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(126, 46)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnOK.Location = New System.Drawing.Point(51, 227)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(126, 46)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblParcelas
        '
        Me.lblParcelas.AutoSize = True
        Me.lblParcelas.ForeColor = System.Drawing.Color.Black
        Me.lblParcelas.Location = New System.Drawing.Point(25, 167)
        Me.lblParcelas.Name = "lblParcelas"
        Me.lblParcelas.Size = New System.Drawing.Size(85, 19)
        Me.lblParcelas.TabIndex = 5
        Me.lblParcelas.Text = "Nº Parcelas"
        '
        'chkEntrada
        '
        Me.chkEntrada.AutoSize = True
        Me.chkEntrada.Location = New System.Drawing.Point(230, 168)
        Me.chkEntrada.Name = "chkEntrada"
        Me.chkEntrada.Size = New System.Drawing.Size(111, 23)
        Me.chkEntrada.TabIndex = 7
        Me.chkEntrada.Text = "Com Entrada"
        Me.chkEntrada.UseVisualStyleBackColor = True
        '
        'txtParcelas
        '
        Me.txtParcelas.Inteiro = True
        Me.txtParcelas.Location = New System.Drawing.Point(116, 164)
        Me.txtParcelas.Name = "txtParcelas"
        Me.txtParcelas.Size = New System.Drawing.Size(57, 27)
        Me.txtParcelas.TabIndex = 6
        Me.txtParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmDespesaParcelamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(370, 298)
        Me.Controls.Add(Me.txtParcelas)
        Me.Controls.Add(Me.chkEntrada)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbIDBanco)
        Me.Controls.Add(Me.lblParcelas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbCobrancaForma)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmDespesaParcelamento"
        Me.Text = "d"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmbCobrancaForma, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblParcelas, 0)
        Me.Controls.SetChildIndex(Me.cmbIDBanco, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.chkEntrada, 0)
        Me.Controls.SetChildIndex(Me.txtParcelas, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbCobrancaForma As Controles.ComboBox_OnlyValues
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbIDBanco As Controles.ComboBox_OnlyValues
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents lblParcelas As Label
    Friend WithEvents chkEntrada As CheckBox
    Friend WithEvents txtParcelas As Controles.Text_SoNumeros
End Class
