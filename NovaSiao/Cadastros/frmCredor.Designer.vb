<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCredor
    Inherits NovaSiao.frmModFinBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtCadastro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCadastro = New System.Windows.Forms.Label()
        Me.lblCNPTexto = New System.Windows.Forms.Label()
        Me.lblIDCredor = New System.Windows.Forms.Label()
        Me.lbl_IdTexto = New System.Windows.Forms.Label()
        Me.txtTelefoneB = New Controles.MaskText_Telefone()
        Me.txtTelefoneA = New Controles.MaskText_Telefone()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.txtUF = New System.Windows.Forms.TextBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlEndereco = New System.Windows.Forms.Panel()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.lblCNP = New System.Windows.Forms.Label()
        Me.lblCredorTipo = New System.Windows.Forms.Label()
        Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.pnlEndereco.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblIDCredor)
        Me.Panel1.Controls.Add(Me.lbl_IdTexto)
        Me.Panel1.Size = New System.Drawing.Size(550, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lbl_IdTexto, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblIDCredor, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(331, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(219, 50)
        Me.lblTitulo.Text = "Cadastro de Credor"
        '
        'txtCadastro
        '
        Me.txtCadastro.Location = New System.Drawing.Point(105, 47)
        Me.txtCadastro.Name = "txtCadastro"
        Me.txtCadastro.Size = New System.Drawing.Size(368, 27)
        Me.txtCadastro.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo"
        '
        'lblCadastro
        '
        Me.lblCadastro.Location = New System.Drawing.Point(9, 50)
        Me.lblCadastro.Name = "lblCadastro"
        Me.lblCadastro.Size = New System.Drawing.Size(90, 19)
        Me.lblCadastro.TabIndex = 4
        Me.lblCadastro.Text = "Cadastro"
        Me.lblCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCNPTexto
        '
        Me.lblCNPTexto.Location = New System.Drawing.Point(240, 17)
        Me.lblCNPTexto.Name = "lblCNPTexto"
        Me.lblCNPTexto.Size = New System.Drawing.Size(50, 19)
        Me.lblCNPTexto.TabIndex = 4
        Me.lblCNPTexto.Text = "CNPJ"
        Me.lblCNPTexto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIDCredor
        '
        Me.lblIDCredor.BackColor = System.Drawing.Color.Transparent
        Me.lblIDCredor.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDCredor.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblIDCredor.Location = New System.Drawing.Point(7, 16)
        Me.lblIDCredor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIDCredor.Name = "lblIDCredor"
        Me.lblIDCredor.Size = New System.Drawing.Size(94, 30)
        Me.lblIDCredor.TabIndex = 44
        Me.lblIDCredor.Text = "0001"
        Me.lblIDCredor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_IdTexto
        '
        Me.lbl_IdTexto.AutoSize = True
        Me.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_IdTexto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_IdTexto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_IdTexto.Location = New System.Drawing.Point(31, 3)
        Me.lbl_IdTexto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_IdTexto.Name = "lbl_IdTexto"
        Me.lbl_IdTexto.Size = New System.Drawing.Size(35, 13)
        Me.lbl_IdTexto.TabIndex = 45
        Me.lbl_IdTexto.Text = "Reg."
        Me.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTelefoneB
        '
        Me.txtTelefoneB.Location = New System.Drawing.Point(332, 147)
        Me.txtTelefoneB.Mask = "(99) 99000-0000"
        Me.txtTelefoneB.Name = "txtTelefoneB"
        Me.txtTelefoneB.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneB.TabIndex = 6
        '
        'txtTelefoneA
        '
        Me.txtTelefoneA.Location = New System.Drawing.Point(106, 147)
        Me.txtTelefoneA.Mask = "(99) 99000-0000"
        Me.txtTelefoneA.Name = "txtTelefoneA"
        Me.txtTelefoneA.Size = New System.Drawing.Size(144, 27)
        Me.txtTelefoneA.TabIndex = 5
        '
        'txtCidade
        '
        Me.txtCidade.BackColor = System.Drawing.Color.White
        Me.txtCidade.Location = New System.Drawing.Point(106, 81)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(191, 27)
        Me.txtCidade.TabIndex = 2
        '
        'txtUF
        '
        Me.txtUF.BackColor = System.Drawing.Color.White
        Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUF.Location = New System.Drawing.Point(341, 81)
        Me.txtUF.MaxLength = 2
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(46, 27)
        Me.txtUF.TabIndex = 3
        '
        'txtEndereco
        '
        Me.txtEndereco.BackColor = System.Drawing.Color.White
        Me.txtEndereco.Location = New System.Drawing.Point(105, 15)
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(372, 27)
        Me.txtEndereco.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(48, 183)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 19)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "e-Mail"
        '
        'txtBairro
        '
        Me.txtBairro.Location = New System.Drawing.Point(106, 48)
        Me.txtBairro.MaxLength = 30
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(191, 27)
        Me.txtBairro.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(51, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 19)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Bairro"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(106, 180)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(370, 27)
        Me.txtEmail.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(30, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Endereço"
        '
        'txtCEP
        '
        Me.txtCEP.Location = New System.Drawing.Point(106, 114)
        Me.txtCEP.Mask = "00000-000"
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(94, 27)
        Me.txtCEP.TabIndex = 4
        Me.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(34, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Telefone"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(65, 118)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 19)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "CEP"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(271, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 19)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Celular"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(307, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 19)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "UF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(45, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 19)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Cidade"
        '
        'pnlEndereco
        '
        Me.pnlEndereco.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.pnlEndereco.Controls.Add(Me.txtTelefoneB)
        Me.pnlEndereco.Controls.Add(Me.txtTelefoneA)
        Me.pnlEndereco.Controls.Add(Me.txtCidade)
        Me.pnlEndereco.Controls.Add(Me.txtUF)
        Me.pnlEndereco.Controls.Add(Me.txtEndereco)
        Me.pnlEndereco.Controls.Add(Me.Label16)
        Me.pnlEndereco.Controls.Add(Me.txtBairro)
        Me.pnlEndereco.Controls.Add(Me.Label6)
        Me.pnlEndereco.Controls.Add(Me.txtEmail)
        Me.pnlEndereco.Controls.Add(Me.Label5)
        Me.pnlEndereco.Controls.Add(Me.txtCEP)
        Me.pnlEndereco.Controls.Add(Me.Label9)
        Me.pnlEndereco.Controls.Add(Me.Label15)
        Me.pnlEndereco.Controls.Add(Me.Label10)
        Me.pnlEndereco.Controls.Add(Me.Label8)
        Me.pnlEndereco.Controls.Add(Me.Label7)
        Me.pnlEndereco.Location = New System.Drawing.Point(12, 160)
        Me.pnlEndereco.Name = "pnlEndereco"
        Me.pnlEndereco.Size = New System.Drawing.Size(522, 222)
        Me.pnlEndereco.TabIndex = 3
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.save
        Me.btnSalvar.Location = New System.Drawing.Point(149, 393)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(128, 48)
        Me.btnSalvar.TabIndex = 20
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnFechar.Location = New System.Drawing.Point(283, 393)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(128, 48)
        Me.btnFechar.TabIndex = 21
        Me.btnFechar.Text = "&Cancelar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.pnlPrincipal.Controls.Add(Me.lblCNP)
        Me.pnlPrincipal.Controls.Add(Me.lblCredorTipo)
        Me.pnlPrincipal.Controls.Add(Me.lblCNPTexto)
        Me.pnlPrincipal.Controls.Add(Me.lblCadastro)
        Me.pnlPrincipal.Controls.Add(Me.Label1)
        Me.pnlPrincipal.Controls.Add(Me.txtCadastro)
        Me.pnlPrincipal.Location = New System.Drawing.Point(12, 66)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(521, 88)
        Me.pnlPrincipal.TabIndex = 1
        '
        'lblCNP
        '
        Me.lblCNP.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCNP.Location = New System.Drawing.Point(296, 14)
        Me.lblCNP.Name = "lblCNP"
        Me.lblCNP.Size = New System.Drawing.Size(177, 27)
        Me.lblCNP.TabIndex = 5
        Me.lblCNP.Text = "000.000.000-00"
        '
        'lblCredorTipo
        '
        Me.lblCredorTipo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredorTipo.Location = New System.Drawing.Point(105, 14)
        Me.lblCredorTipo.Name = "lblCredorTipo"
        Me.lblCredorTipo.Size = New System.Drawing.Size(133, 27)
        Me.lblCredorTipo.TabIndex = 5
        Me.lblCredorTipo.Text = "Tipo"
        '
        'EProvider
        '
        Me.EProvider.ContainerControl = Me
        '
        'frmCredor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 452)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.pnlEndereco)
        Me.KeyPreview = True
        Me.Name = "frmCredor"
        Me.Text = "frmCredor"
        Me.Controls.SetChildIndex(Me.pnlEndereco, 0)
        Me.Controls.SetChildIndex(Me.btnSalvar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.pnlPrincipal, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlEndereco.ResumeLayout(False)
        Me.pnlEndereco.PerformLayout()
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlPrincipal.PerformLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCadastro As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCadastro As Label
    Friend WithEvents lblCNPTexto As Label
    Friend WithEvents lblIDCredor As Label
    Friend WithEvents lbl_IdTexto As Label
    Friend WithEvents txtTelefoneB As Controles.MaskText_Telefone
    Friend WithEvents txtTelefoneA As Controles.MaskText_Telefone
    Friend WithEvents txtCidade As TextBox
    Friend WithEvents txtUF As TextBox
    Friend WithEvents txtEndereco As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtBairro As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCEP As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlEndereco As Panel
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents pnlPrincipal As Panel
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents lblCredorTipo As Label
    Friend WithEvents lblCNP As Label
End Class
