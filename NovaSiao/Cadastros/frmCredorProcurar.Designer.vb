<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCredorProcurar
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.cmbAtivo = New Controles.ComboBox_OnlyValues()
        Me.MenuListagem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AtivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.rbtOrgaoPublico = New System.Windows.Forms.RadioButton()
        Me.rbtPJ = New System.Windows.Forms.RadioButton()
        Me.rbtPF = New System.Windows.Forms.RadioButton()
        Me.rbtSimples = New System.Windows.Forms.RadioButton()
        Me.pnlCredorTipo = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuListagem.SuspendLayout()
        Me.pnlCredorTipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(590, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(343, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(247, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Procurar Credor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Procura"
        '
        'txtProcura
        '
        Me.txtProcura.Location = New System.Drawing.Point(88, 122)
        Me.txtProcura.Margin = New System.Windows.Forms.Padding(6)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.Size = New System.Drawing.Size(285, 27)
        Me.txtProcura.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(400, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ativo"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        Me.dgvListagem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListagem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvListagem.Location = New System.Drawing.Point(21, 174)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListagem.Size = New System.Drawing.Size(547, 358)
        Me.dgvListagem.StandardTab = True
        Me.dgvListagem.TabIndex = 6
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(178, 547)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(126, 42)
        Me.btnEditar.TabIndex = 7
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdicionar.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.btnAdicionar.Location = New System.Drawing.Point(310, 547)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(126, 42)
        Me.btnAdicionar.TabIndex = 8
        Me.btnAdicionar.Text = "&Adicionar"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnFechar.Location = New System.Drawing.Point(442, 547)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(126, 42)
        Me.btnFechar.TabIndex = 9
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'cmbAtivo
        '
        Me.cmbAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAtivo.FormattingEnabled = True
        Me.cmbAtivo.Location = New System.Drawing.Point(448, 122)
        Me.cmbAtivo.Name = "cmbAtivo"
        Me.cmbAtivo.RestrictContentToListItems = True
        Me.cmbAtivo.Size = New System.Drawing.Size(119, 27)
        Me.cmbAtivo.TabIndex = 5
        '
        'MenuListagem
        '
        Me.MenuListagem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtivarToolStripMenuItem, Me.DesativarToolStripMenuItem})
        Me.MenuListagem.Name = "MenuFab"
        Me.MenuListagem.Size = New System.Drawing.Size(162, 48)
        '
        'AtivarToolStripMenuItem
        '
        Me.AtivarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem"
        Me.AtivarToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AtivarToolStripMenuItem.Text = "Ativar Credor"
        '
        'DesativarToolStripMenuItem
        '
        Me.DesativarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem"
        Me.DesativarToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.DesativarToolStripMenuItem.Text = "Desativar Credor"
        '
        'rbtOrgaoPublico
        '
        Me.rbtOrgaoPublico.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtOrgaoPublico.BackColor = System.Drawing.Color.AliceBlue
        Me.rbtOrgaoPublico.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtOrgaoPublico.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
        Me.rbtOrgaoPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtOrgaoPublico.Location = New System.Drawing.Point(403, 6)
        Me.rbtOrgaoPublico.Name = "rbtOrgaoPublico"
        Me.rbtOrgaoPublico.Size = New System.Drawing.Size(118, 33)
        Me.rbtOrgaoPublico.TabIndex = 4
        Me.rbtOrgaoPublico.Tag = "3"
        Me.rbtOrgaoPublico.Text = "Orgão Público"
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
        Me.rbtPJ.Location = New System.Drawing.Point(271, 6)
        Me.rbtPJ.Name = "rbtPJ"
        Me.rbtPJ.Size = New System.Drawing.Size(118, 33)
        Me.rbtPJ.TabIndex = 3
        Me.rbtPJ.Tag = "2"
        Me.rbtPJ.Text = "Pessoa Jurídica"
        Me.rbtPJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtPJ.UseVisualStyleBackColor = False
        '
        'rbtPF
        '
        Me.rbtPF.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtPF.BackColor = System.Drawing.Color.AliceBlue
        Me.rbtPF.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtPF.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
        Me.rbtPF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtPF.Location = New System.Drawing.Point(139, 6)
        Me.rbtPF.Name = "rbtPF"
        Me.rbtPF.Size = New System.Drawing.Size(118, 33)
        Me.rbtPF.TabIndex = 2
        Me.rbtPF.Tag = "1"
        Me.rbtPF.Text = "Pessoa Física"
        Me.rbtPF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtPF.UseVisualStyleBackColor = False
        '
        'rbtSimples
        '
        Me.rbtSimples.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtSimples.BackColor = System.Drawing.Color.AliceBlue
        Me.rbtSimples.Checked = True
        Me.rbtSimples.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.rbtSimples.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue
        Me.rbtSimples.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtSimples.Location = New System.Drawing.Point(7, 6)
        Me.rbtSimples.Name = "rbtSimples"
        Me.rbtSimples.Size = New System.Drawing.Size(118, 33)
        Me.rbtSimples.TabIndex = 1
        Me.rbtSimples.TabStop = True
        Me.rbtSimples.Tag = "0"
        Me.rbtSimples.Text = "Credor Simples"
        Me.rbtSimples.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtSimples.UseVisualStyleBackColor = False
        '
        'pnlCredorTipo
        '
        Me.pnlCredorTipo.BackColor = System.Drawing.Color.Transparent
        Me.pnlCredorTipo.Controls.Add(Me.rbtOrgaoPublico)
        Me.pnlCredorTipo.Controls.Add(Me.rbtPJ)
        Me.pnlCredorTipo.Controls.Add(Me.rbtSimples)
        Me.pnlCredorTipo.Controls.Add(Me.rbtPF)
        Me.pnlCredorTipo.Location = New System.Drawing.Point(30, 63)
        Me.pnlCredorTipo.Name = "pnlCredorTipo"
        Me.pnlCredorTipo.Size = New System.Drawing.Size(527, 46)
        Me.pnlCredorTipo.TabIndex = 1
        '
        'frmCredorProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(590, 602)
        Me.Controls.Add(Me.pnlCredorTipo)
        Me.Controls.Add(Me.cmbAtivo)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.txtProcura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmCredorProcurar"
        Me.Text = "Fornecedor"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtProcura, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnAdicionar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.cmbAtivo, 0)
        Me.Controls.SetChildIndex(Me.pnlCredorTipo, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuListagem.ResumeLayout(False)
        Me.pnlCredorTipo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtProcura As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents cmbAtivo As Controles.ComboBox_OnlyValues
    Friend WithEvents MenuListagem As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents rbtSimples As RadioButton
    Friend WithEvents rbtPJ As RadioButton
    Friend WithEvents rbtPF As RadioButton
    Friend WithEvents rbtOrgaoPublico As RadioButton
    Friend WithEvents pnlCredorTipo As Panel
End Class
