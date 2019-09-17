<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCredorTipo
    Inherits NovaSiao.frmModFinBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlCredorTipo = New System.Windows.Forms.Panel()
        Me.rbtOrgaoPublico = New System.Windows.Forms.RadioButton()
        Me.rbtPJ = New System.Windows.Forms.RadioButton()
        Me.rbtSimples = New System.Windows.Forms.RadioButton()
        Me.rbtPF = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.pnlCredorTipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(575, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(575, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Deseja inserir um Novo Credor?"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.AutoSize = True
        Me.lblSubtitulo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitulo.ForeColor = System.Drawing.Color.Black
        Me.lblSubtitulo.Location = New System.Drawing.Point(157, 100)
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.Size = New System.Drawing.Size(268, 29)
        Me.lblSubtitulo.TabIndex = 0
        Me.lblSubtitulo.Text = "Escolha o tipo de Credor..."
        Me.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.AliceBlue
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(168, 240)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(114, 44)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Location = New System.Drawing.Point(292, 240)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(114, 44)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'pnlCredorTipo
        '
        Me.pnlCredorTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.pnlCredorTipo.Controls.Add(Me.rbtOrgaoPublico)
        Me.pnlCredorTipo.Controls.Add(Me.rbtPJ)
        Me.pnlCredorTipo.Controls.Add(Me.rbtSimples)
        Me.pnlCredorTipo.Controls.Add(Me.rbtPF)
        Me.pnlCredorTipo.Location = New System.Drawing.Point(12, 141)
        Me.pnlCredorTipo.Name = "pnlCredorTipo"
        Me.pnlCredorTipo.Size = New System.Drawing.Size(547, 46)
        Me.pnlCredorTipo.TabIndex = 1
        Me.pnlCredorTipo.TabStop = True
        '
        'rbtOrgaoPublico
        '
        Me.rbtOrgaoPublico.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtOrgaoPublico.BackColor = System.Drawing.Color.AliceBlue
        Me.rbtOrgaoPublico.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtOrgaoPublico.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
        Me.rbtOrgaoPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtOrgaoPublico.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtOrgaoPublico.Location = New System.Drawing.Point(421, 6)
        Me.rbtOrgaoPublico.Name = "rbtOrgaoPublico"
        Me.rbtOrgaoPublico.Size = New System.Drawing.Size(118, 33)
        Me.rbtOrgaoPublico.TabIndex = 3
        Me.rbtOrgaoPublico.Tag = "3"
        Me.rbtOrgaoPublico.Text = "4.Orgão Público"
        Me.rbtOrgaoPublico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtOrgaoPublico.UseVisualStyleBackColor = False
        '
        'rbtPJ
        '
        Me.rbtPJ.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtPJ.BackColor = System.Drawing.Color.AliceBlue
        Me.rbtPJ.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtPJ.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
        Me.rbtPJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtPJ.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtPJ.Location = New System.Drawing.Point(283, 6)
        Me.rbtPJ.Name = "rbtPJ"
        Me.rbtPJ.Size = New System.Drawing.Size(132, 33)
        Me.rbtPJ.TabIndex = 2
        Me.rbtPJ.Tag = "2"
        Me.rbtPJ.Text = "3.Pessoa Jurídica"
        Me.rbtPJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtPJ.UseVisualStyleBackColor = False
        '
        'rbtSimples
        '
        Me.rbtSimples.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtSimples.BackColor = System.Drawing.Color.AliceBlue
        Me.rbtSimples.Checked = True
        Me.rbtSimples.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtSimples.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
        Me.rbtSimples.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtSimples.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSimples.Location = New System.Drawing.Point(7, 6)
        Me.rbtSimples.Name = "rbtSimples"
        Me.rbtSimples.Size = New System.Drawing.Size(132, 33)
        Me.rbtSimples.TabIndex = 0
        Me.rbtSimples.TabStop = True
        Me.rbtSimples.Tag = "0"
        Me.rbtSimples.Text = "1.Credor Simples"
        Me.rbtSimples.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtSimples.UseVisualStyleBackColor = False
        '
        'rbtPF
        '
        Me.rbtPF.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtPF.BackColor = System.Drawing.Color.AliceBlue
        Me.rbtPF.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtPF.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
        Me.rbtPF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtPF.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtPF.Location = New System.Drawing.Point(145, 6)
        Me.rbtPF.Name = "rbtPF"
        Me.rbtPF.Size = New System.Drawing.Size(132, 33)
        Me.rbtPF.TabIndex = 1
        Me.rbtPF.Tag = "1"
        Me.rbtPF.Text = "2.Pessoa Física"
        Me.rbtPF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtPF.UseVisualStyleBackColor = False
        '
        'frmCredorTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(575, 316)
        Me.Controls.Add(Me.pnlCredorTipo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblSubtitulo)
        Me.KeyPreview = True
        Me.Name = "frmCredorTipo"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Novo Cliente"
        Me.TopMost = True
        Me.Controls.SetChildIndex(Me.lblSubtitulo, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlCredorTipo, 0)
        Me.Panel1.ResumeLayout(False)
        Me.pnlCredorTipo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubtitulo As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents pnlCredorTipo As Panel
    Friend WithEvents rbtOrgaoPublico As RadioButton
    Friend WithEvents rbtPJ As RadioButton
    Friend WithEvents rbtSimples As RadioButton
    Friend WithEvents rbtPF As RadioButton
End Class
