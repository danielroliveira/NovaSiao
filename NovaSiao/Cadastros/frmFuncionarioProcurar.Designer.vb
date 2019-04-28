<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFuncionarioProcurar
    Inherits NovaSiao.frmModNBorder

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFuncionarioProcurar))
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lstListagem = New ComponentOwl.BetterListView.BetterListView()
        Me.IDFuncionario = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.Funcionario = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.chkAtivo = New CheckedButton_OnOff.CheckedButton_OnOff()
        Me.lblAtivo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(398, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(97, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(301, 50)
        Me.lblTitulo.Text = "Escolha um Funcionário"
        '
        'btnEscolher
        '
        Me.btnEscolher.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEscolher.Location = New System.Drawing.Point(112, 428)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(136, 42)
        Me.btnEscolher.TabIndex = 5
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(254, 428)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(136, 42)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lstListagem
        '
        Me.lstListagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstListagem.Columns.Add(Me.IDFuncionario)
        Me.lstListagem.Columns.Add(Me.Funcionario)
        Me.lstListagem.DisplayMember = "IDFuncionario"
        Me.lstListagem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstListagem.FontColumns = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstListagem.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
        Me.lstListagem.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstListagem.Location = New System.Drawing.Point(12, 98)
        Me.lstListagem.Margin = New System.Windows.Forms.Padding(6)
        Me.lstListagem.MultiSelect = False
        Me.lstListagem.Name = "lstListagem"
        Me.lstListagem.Size = New System.Drawing.Size(378, 321)
        Me.lstListagem.TabIndex = 4
        '
        'IDFuncionario
        '
        Me.IDFuncionario.AllowResize = False
        Me.IDFuncionario.DisplayMember = "IDFuncionario"
        Me.IDFuncionario.ForeColor = System.Drawing.Color.Black
        Me.IDFuncionario.Name = "IDFuncionario"
        Me.IDFuncionario.Text = "No."
        Me.IDFuncionario.Width = 50
        '
        'Funcionario
        '
        Me.Funcionario.AllowResize = False
        Me.Funcionario.DisplayMember = "Funcionario"
        Me.Funcionario.ForeColor = System.Drawing.Color.Black
        Me.Funcionario.Name = "Funcionario"
        Me.Funcionario.Text = "Nome"
        Me.Funcionario.ValueMember = "Funcionario"
        Me.Funcionario.Width = 300
        '
        'chkAtivo
        '
        Me.chkAtivo.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkAtivo.BackColor = System.Drawing.Color.Transparent
        Me.chkAtivo.BackgroundImage = CType(resources.GetObject("chkAtivo.BackgroundImage"), System.Drawing.Image)
        Me.chkAtivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.chkAtivo.Checked = True
        Me.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAtivo.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.chkAtivo.FlatAppearance.BorderSize = 0
        Me.chkAtivo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkAtivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkAtivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAtivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAtivo.Location = New System.Drawing.Point(26, 443)
        Me.chkAtivo.Margin = New System.Windows.Forms.Padding(0)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(50, 23)
        Me.chkAtivo.TabIndex = 14
        Me.chkAtivo.UseVisualStyleBackColor = False
        '
        'lblAtivo
        '
        Me.lblAtivo.Location = New System.Drawing.Point(16, 423)
        Me.lblAtivo.Name = "lblAtivo"
        Me.lblAtivo.Size = New System.Drawing.Size(73, 19)
        Me.lblAtivo.TabIndex = 15
        Me.lblAtivo.Text = "Ativos"
        Me.lblAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 19)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Filial Sede:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFilial
        '
        Me.lblFilial.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.Location = New System.Drawing.Point(92, 60)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(274, 26)
        Me.lblFilial.TabIndex = 16
        Me.lblFilial.Text = "Filial Nome"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmFuncionarioProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(398, 480)
        Me.Controls.Add(Me.lblFilial)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAtivo)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lstListagem)
        Me.KeyPreview = True
        Me.Name = "frmFuncionarioProcurar"
        Me.Text = "Escolha um Funcionario"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lstListagem, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.chkAtivo, 0)
        Me.Controls.SetChildIndex(Me.lblAtivo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEscolher As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lstListagem As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents IDFuncionario As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents Funcionario As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents chkAtivo As CheckedButton_OnOff.CheckedButton_OnOff
    Friend WithEvents lblAtivo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFilial As Label
End Class
