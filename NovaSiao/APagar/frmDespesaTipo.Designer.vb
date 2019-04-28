<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespesaTipo
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
        Me.txtDespesaTipo = New System.Windows.Forms.TextBox()
        Me.cmbPeriodicidade = New Controles.ComboBox_OnlyValues()
        Me.cmbVariacao = New Controles.ComboBox_OnlyValues()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(415, 50)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblID, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(224, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(191, 50)
        Me.lblTitulo.Text = "Tipos de Despesa"
        '
        'txtDespesaTipo
        '
        Me.txtDespesaTipo.Location = New System.Drawing.Point(122, 74)
        Me.txtDespesaTipo.Name = "txtDespesaTipo"
        Me.txtDespesaTipo.Size = New System.Drawing.Size(255, 27)
        Me.txtDespesaTipo.TabIndex = 2
        '
        'cmbPeriodicidade
        '
        Me.cmbPeriodicidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPeriodicidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPeriodicidade.FormattingEnabled = True
        Me.cmbPeriodicidade.Location = New System.Drawing.Point(122, 121)
        Me.cmbPeriodicidade.Name = "cmbPeriodicidade"
        Me.cmbPeriodicidade.RestrictContentToListItems = True
        Me.cmbPeriodicidade.Size = New System.Drawing.Size(165, 27)
        Me.cmbPeriodicidade.TabIndex = 3
        '
        'cmbVariacao
        '
        Me.cmbVariacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVariacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVariacao.FormattingEnabled = True
        Me.cmbVariacao.Location = New System.Drawing.Point(122, 170)
        Me.cmbVariacao.Name = "cmbVariacao"
        Me.cmbVariacao.RestrictContentToListItems = True
        Me.cmbVariacao.Size = New System.Drawing.Size(165, 27)
        Me.cmbVariacao.TabIndex = 4
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblID.Location = New System.Drawing.Point(5, 17)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(94, 30)
        Me.lblID.TabIndex = 50
        Me.lblID.Text = "0001"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_IdTexto
        '
        Me.lbl_IdTexto.AutoSize = True
        Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_IdTexto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_IdTexto.Location = New System.Drawing.Point(29, 4)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 51
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Descrição"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Periodicidade"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Variação"
        '
        'btnFechar
        '
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnFechar.Location = New System.Drawing.Point(209, 228)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(128, 48)
        Me.btnFechar.TabIndex = 23
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.save
        Me.btnSalvar.Location = New System.Drawing.Point(75, 228)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(128, 48)
        Me.btnSalvar.TabIndex = 22
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'frmDespesaTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(415, 305)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbVariacao)
        Me.Controls.Add(Me.cmbPeriodicidade)
        Me.Controls.Add(Me.txtDespesaTipo)
        Me.Name = "frmDespesaTipo"
        Me.Text = "Despesa Tipo"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.txtDespesaTipo, 0)
        Me.Controls.SetChildIndex(Me.cmbPeriodicidade, 0)
        Me.Controls.SetChildIndex(Me.cmbVariacao, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnSalvar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDespesaTipo As TextBox
    Friend WithEvents cmbPeriodicidade As Controles.ComboBox_OnlyValues
    Friend WithEvents cmbVariacao As Controles.ComboBox_OnlyValues
    Friend WithEvents lblID As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnSalvar As Button
End Class
