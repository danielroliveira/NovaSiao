<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Me.components = New System.ComponentModel.Container()
        Me.cmbUsuarioAcesso = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIdUser = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsuarioApelido = New System.Windows.Forms.TextBox()
        Me.blvUsuarios = New ComponentOwl.BetterListView.BetterListView()
        Me.IdUser = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.UsuarioApelido = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.UsuarioAcessoTx = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.UsuarioAcesso = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.txtUsuarioSenha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.epValida = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.blvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(695, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(453, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(242, 50)
        Me.lblTitulo.Text = "Controle de Usuários"
        '
        'cmbUsuarioAcesso
        '
        Me.cmbUsuarioAcesso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUsuarioAcesso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUsuarioAcesso.BackColor = System.Drawing.Color.White
        Me.cmbUsuarioAcesso.FormattingEnabled = True
        Me.cmbUsuarioAcesso.Location = New System.Drawing.Point(455, 131)
        Me.cmbUsuarioAcesso.Name = "cmbUsuarioAcesso"
        Me.cmbUsuarioAcesso.Size = New System.Drawing.Size(159, 27)
        Me.cmbUsuarioAcesso.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(407, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 19)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Reg."
        '
        'lblIdUser
        '
        Me.lblIdUser.BackColor = System.Drawing.Color.White
        Me.lblIdUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIdUser.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdUser.Location = New System.Drawing.Point(455, 64)
        Me.lblIdUser.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdUser.Name = "lblIdUser"
        Me.lblIdUser.Size = New System.Drawing.Size(63, 27)
        Me.lblIdUser.TabIndex = 1
        Me.lblIdUser.Text = "0000"
        Me.lblIdUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(390, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 19)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Acesso"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(387, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Apelido"
        '
        'txtUsuarioApelido
        '
        Me.txtUsuarioApelido.Location = New System.Drawing.Point(455, 98)
        Me.txtUsuarioApelido.MaxLength = 16
        Me.txtUsuarioApelido.Name = "txtUsuarioApelido"
        Me.txtUsuarioApelido.Size = New System.Drawing.Size(219, 27)
        Me.txtUsuarioApelido.TabIndex = 2
        '
        'blvUsuarios
        '
        Me.blvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.blvUsuarios.ColorSortedColumn = System.Drawing.Color.LightBlue
        Me.blvUsuarios.Columns.Add(Me.IdUser)
        Me.blvUsuarios.Columns.Add(Me.UsuarioApelido)
        Me.blvUsuarios.Columns.Add(Me.UsuarioAcessoTx)
        Me.blvUsuarios.Columns.Add(Me.UsuarioAcesso)
        Me.blvUsuarios.DisplayMember = "IdUser"
        Me.blvUsuarios.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blvUsuarios.FontColumns = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blvUsuarios.ForeColor = System.Drawing.Color.Black
        Me.blvUsuarios.ForeColorColumns = System.Drawing.Color.Black
        Me.blvUsuarios.ForeColorGroups = System.Drawing.SystemColors.MenuHighlight
        Me.blvUsuarios.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid
        Me.blvUsuarios.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
        Me.blvUsuarios.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.blvUsuarios.Location = New System.Drawing.Point(12, 68)
        Me.blvUsuarios.MultiSelect = False
        Me.blvUsuarios.Name = "blvUsuarios"
        Me.blvUsuarios.Size = New System.Drawing.Size(352, 232)
        Me.blvUsuarios.TabIndex = 0
        '
        'IdUser
        '
        Me.IdUser.AllowResize = False
        Me.IdUser.DisplayMember = "IdUser"
        Me.IdUser.Name = "IdUser"
        Me.IdUser.Text = "Reg"
        Me.IdUser.Width = 50
        '
        'UsuarioApelido
        '
        Me.UsuarioApelido.AllowResize = False
        Me.UsuarioApelido.DisplayMember = "UsuarioApelido"
        Me.UsuarioApelido.Name = "UsuarioApelido"
        Me.UsuarioApelido.Text = "Apelido"
        Me.UsuarioApelido.Width = 140
        '
        'UsuarioAcessoTx
        '
        Me.UsuarioAcessoTx.AllowResize = False
        Me.UsuarioAcessoTx.Name = "UsuarioAcessoTx"
        Me.UsuarioAcessoTx.Text = "Acesso"
        Me.UsuarioAcessoTx.Width = 130
        '
        'UsuarioAcesso
        '
        Me.UsuarioAcesso.AllowResize = False
        Me.UsuarioAcesso.DisplayMember = "UsuarioAcesso"
        Me.UsuarioAcesso.Name = "UsuarioAcesso"
        Me.UsuarioAcesso.Text = "UsuarioAcesso"
        Me.UsuarioAcesso.Width = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 328)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tsMenu)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFechar)
        Me.SplitContainer1.Size = New System.Drawing.Size(695, 48)
        Me.SplitContainer1.SplitterDistance = 580
        Me.SplitContainer1.TabIndex = 23
        Me.SplitContainer1.TabStop = False
        '
        'tsMenu
        '
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovo, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancelar, Me.ToolStripSeparator1, Me.btnExcluir, Me.btnAtivo})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.tsMenu.Size = New System.Drawing.Size(580, 48)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnNovo
        '
        Me.btnNovo.Image = Global.NovaSiao.My.Resources.Resources.Novo_PEQ
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(76, 45)
        Me.btnNovo.Text = "&Novo"
        Me.btnNovo.ToolTipText = "Novo Usuário"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 48)
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(82, 45)
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.ToolTipText = "Salvar Usuário"
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.delete_page
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 45)
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar Edição"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 48)
        '
        'btnExcluir
        '
        Me.btnExcluir.Image = Global.NovaSiao.My.Resources.Resources.Lixeira
        Me.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(86, 45)
        Me.btnExcluir.Text = "E&xcluir"
        Me.btnExcluir.ToolTipText = "Excluir Usuário"
        '
        'btnAtivo
        '
        Me.btnAtivo.AutoSize = False
        Me.btnAtivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAtivo.CheckOnClick = True
        Me.btnAtivo.Image = Global.NovaSiao.My.Resources.Resources.Switch_ON_PEQ
        Me.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAtivo.Name = "btnAtivo"
        Me.btnAtivo.Size = New System.Drawing.Size(167, 41)
        Me.btnAtivo.Text = "Usuário Ativo"
        '
        'btnFechar
        '
        Me.btnFechar.BackColor = System.Drawing.Color.Transparent
        Me.btnFechar.FlatAppearance.BorderSize = 0
        Me.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral
        Me.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.Location = New System.Drawing.Point(4, 0)
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(97, 48)
        Me.btnFechar.TabIndex = 0
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = False
        '
        'txtUsuarioSenha
        '
        Me.txtUsuarioSenha.Location = New System.Drawing.Point(455, 164)
        Me.txtUsuarioSenha.MaxLength = 8
        Me.txtUsuarioSenha.Name = "txtUsuarioSenha"
        Me.txtUsuarioSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUsuarioSenha.Size = New System.Drawing.Size(159, 27)
        Me.txtUsuarioSenha.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(397, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 19)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Senha"
        '
        'epValida
        '
        Me.epValida.ContainerControl = Me
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(695, 376)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cmbUsuarioAcesso)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblIdUser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsuarioSenha)
        Me.Controls.Add(Me.txtUsuarioApelido)
        Me.Controls.Add(Me.blvUsuarios)
        Me.Name = "frmUsuarios"
        Me.Text = "Controle de Usuários"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.blvUsuarios, 0)
        Me.Controls.SetChildIndex(Me.txtUsuarioApelido, 0)
        Me.Controls.SetChildIndex(Me.txtUsuarioSenha, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lblIdUser, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmbUsuarioAcesso, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.blvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbUsuarioAcesso As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblIdUser As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsuarioApelido As TextBox
    Friend WithEvents blvUsuarios As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents IdUser As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents UsuarioApelido As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents btnFechar As Button
    Friend WithEvents txtUsuarioSenha As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents UsuarioAcessoTx As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents UsuarioAcesso As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents epValida As ErrorProvider
End Class
