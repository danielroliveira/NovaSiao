<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCredorProcurar
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCredorTipo = New Controles.ComboBox_OnlyValues()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuListagem.SuspendLayout()
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
        Me.lblTitulo.Text = "Procurar Credor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Procura"
        '
        'txtProcura
        '
        Me.txtProcura.Location = New System.Drawing.Point(88, 92)
        Me.txtProcura.Margin = New System.Windows.Forms.Padding(6)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.Size = New System.Drawing.Size(285, 27)
        Me.txtProcura.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(400, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ativo"
        '
        'dgvListagem
        '
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListagem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvListagem.Location = New System.Drawing.Point(21, 128)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListagem.Size = New System.Drawing.Size(547, 358)
        Me.dgvListagem.TabIndex = 4
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(178, 501)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(126, 42)
        Me.btnEditar.TabIndex = 5
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.btnAdicionar.Location = New System.Drawing.Point(310, 501)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(126, 42)
        Me.btnAdicionar.TabIndex = 6
        Me.btnAdicionar.Text = "&Adicionar"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnFechar.Location = New System.Drawing.Point(442, 501)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(126, 42)
        Me.btnFechar.TabIndex = 7
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
        Me.cmbAtivo.Location = New System.Drawing.Point(448, 92)
        Me.cmbAtivo.Name = "cmbAtivo"
        Me.cmbAtivo.RestrictContentToListItems = True
        Me.cmbAtivo.Size = New System.Drawing.Size(119, 27)
        Me.cmbAtivo.TabIndex = 3
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tipo"
        '
        'cmbCredorTipo
        '
        Me.cmbCredorTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCredorTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCredorTipo.FormattingEnabled = True
        Me.cmbCredorTipo.Location = New System.Drawing.Point(88, 56)
        Me.cmbCredorTipo.Name = "cmbCredorTipo"
        Me.cmbCredorTipo.RestrictContentToListItems = True
        Me.cmbCredorTipo.Size = New System.Drawing.Size(142, 27)
        Me.cmbCredorTipo.TabIndex = 1
        '
        'frmCredorProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(590, 556)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbCredorTipo)
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
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtProcura, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnAdicionar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.cmbAtivo, 0)
        Me.Controls.SetChildIndex(Me.cmbCredorTipo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuListagem.ResumeLayout(False)
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
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCredorTipo As Controles.ComboBox_OnlyValues
End Class
