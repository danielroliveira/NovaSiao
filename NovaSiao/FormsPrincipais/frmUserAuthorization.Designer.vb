<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserAuthorization
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
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.txtApelido = New System.Windows.Forms.TextBox()
        Me.lblSenha = New System.Windows.Forms.Label()
        Me.lblApelido = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(454, 40)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(333, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(121, 40)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Autorização"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSenha
        '
        Me.txtSenha.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSenha.Location = New System.Drawing.Point(262, 136)
        Me.txtSenha.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSenha.MaxLength = 8
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(118, 23)
        Me.txtSenha.TabIndex = 6
        Me.txtSenha.Text = "dro12345"
        '
        'txtApelido
        '
        Me.txtApelido.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApelido.Location = New System.Drawing.Point(76, 136)
        Me.txtApelido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApelido.Name = "txtApelido"
        Me.txtApelido.Size = New System.Drawing.Size(156, 23)
        Me.txtApelido.TabIndex = 4
        Me.txtApelido.Text = "Daniel"
        '
        'lblSenha
        '
        Me.lblSenha.Location = New System.Drawing.Point(259, 114)
        Me.lblSenha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(69, 22)
        Me.lblSenha.TabIndex = 5
        Me.lblSenha.Text = "&Senha"
        Me.lblSenha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblApelido
        '
        Me.lblApelido.Location = New System.Drawing.Point(73, 114)
        Me.lblApelido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblApelido.Name = "lblApelido"
        Me.lblApelido.Size = New System.Drawing.Size(146, 22)
        Me.lblApelido.TabIndex = 3
        Me.lblApelido.Text = "&Nome do Usuário"
        Me.lblApelido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.AliceBlue
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(122, 185)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(99, 42)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(233, 185)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 42)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(22, 79)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(404, 31)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "objetivo"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(404, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Solicitada autorização adminsitrativa para:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmUserAuthorization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(454, 249)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.txtApelido)
        Me.Controls.Add(Me.lblSenha)
        Me.Controls.Add(Me.lblApelido)
        Me.Name = "frmUserAuthorization"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblApelido, 0)
        Me.Controls.SetChildIndex(Me.lblSenha, 0)
        Me.Controls.SetChildIndex(Me.txtApelido, 0)
        Me.Controls.SetChildIndex(Me.txtSenha, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.lblMessage, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSenha As TextBox
    Friend WithEvents txtApelido As TextBox
    Friend WithEvents lblSenha As Label
    Friend WithEvents lblApelido As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblMessage As Label
    Friend WithEvents Label1 As Label
End Class
