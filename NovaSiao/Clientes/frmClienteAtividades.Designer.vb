<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClienteAtividades
    Inherits NovaSiao.frmModNBorder

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
        Me.components = New System.ComponentModel.Container()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.blvAtividades = New ComponentOwl.BetterListView.BetterListView()
        Me.RGAtividade = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.Atividade = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAtividade = New System.Windows.Forms.TextBox()
        Me.cmbClienteTipo = New System.Windows.Forms.ComboBox()
        Me.cmbVendaTipo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblRG = New System.Windows.Forms.Label()
        Me.epValida = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        CType(Me.blvAtividades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(665, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(418, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(247, 50)
        Me.lblTitulo.Text = "Atividades dos Clientes"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsMenu
        '
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Transparent
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovo, Me.ToolStripSeparator5, Me.btnSalvar, Me.btnCancel, Me.ToolStripSeparator1, Me.btnExcluir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsMenu.Size = New System.Drawing.Size(555, 48)
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
        Me.btnNovo.ToolTipText = "Nova Atividade"
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
        Me.btnSalvar.ToolTipText = "Salvar Registro"
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Image = Global.NovaSiao.My.Resources.Resources.delete_page
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 45)
        Me.btnCancel.Text = "&Cancelar"
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
        Me.btnExcluir.Size = New System.Drawing.Size(151, 45)
        Me.btnExcluir.Text = "E&xcluir Atividade"
        Me.btnExcluir.ToolTipText = "Excluir Atividade"
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
        'blvAtividades
        '
        Me.blvAtividades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.blvAtividades.ColorSortedColumn = System.Drawing.Color.LightBlue
        Me.blvAtividades.Columns.Add(Me.RGAtividade)
        Me.blvAtividades.Columns.Add(Me.Atividade)
        Me.blvAtividades.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blvAtividades.FontColumns = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blvAtividades.ForeColor = System.Drawing.Color.Black
        Me.blvAtividades.ForeColorColumns = System.Drawing.Color.Black
        Me.blvAtividades.ForeColorGroups = System.Drawing.SystemColors.MenuHighlight
        Me.blvAtividades.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid
        Me.blvAtividades.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.blvAtividades.Location = New System.Drawing.Point(12, 69)
        Me.blvAtividades.MultiSelect = False
        Me.blvAtividades.Name = "blvAtividades"
        Me.blvAtividades.Size = New System.Drawing.Size(265, 232)
        Me.blvAtividades.TabIndex = 0
        '
        'RGAtividade
        '
        Me.RGAtividade.AllowResize = False
        Me.RGAtividade.Name = "RGAtividade"
        Me.RGAtividade.Text = "Reg"
        Me.RGAtividade.Width = 60
        '
        'Atividade
        '
        Me.Atividade.AllowResize = False
        Me.Atividade.Name = "Atividade"
        Me.Atividade.Text = "Atividade"
        Me.Atividade.Width = 185
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 321)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tsMenu)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFechar)
        Me.SplitContainer1.Size = New System.Drawing.Size(665, 48)
        Me.SplitContainer1.SplitterDistance = 555
        Me.SplitContainer1.TabIndex = 11
        Me.SplitContainer1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(338, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 19)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Atividade"
        '
        'txtAtividade
        '
        Me.txtAtividade.Location = New System.Drawing.Point(418, 102)
        Me.txtAtividade.Name = "txtAtividade"
        Me.txtAtividade.Size = New System.Drawing.Size(219, 27)
        Me.txtAtividade.TabIndex = 2
        '
        'cmbClienteTipo
        '
        Me.cmbClienteTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbClienteTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClienteTipo.BackColor = System.Drawing.Color.White
        Me.cmbClienteTipo.FormattingEnabled = True
        Me.cmbClienteTipo.Location = New System.Drawing.Point(418, 135)
        Me.cmbClienteTipo.Name = "cmbClienteTipo"
        Me.cmbClienteTipo.Size = New System.Drawing.Size(159, 27)
        Me.cmbClienteTipo.TabIndex = 3
        '
        'cmbVendaTipo
        '
        Me.cmbVendaTipo.BackColor = System.Drawing.Color.White
        Me.cmbVendaTipo.FormattingEnabled = True
        Me.cmbVendaTipo.Location = New System.Drawing.Point(418, 168)
        Me.cmbVendaTipo.Name = "cmbVendaTipo"
        Me.cmbVendaTipo.Size = New System.Drawing.Size(159, 27)
        Me.cmbVendaTipo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(370, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 19)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Reg."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(301, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Tipo de Cliente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 19)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Tipo de Vendas"
        '
        'lblRG
        '
        Me.lblRG.BackColor = System.Drawing.Color.White
        Me.lblRG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRG.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRG.Location = New System.Drawing.Point(418, 68)
        Me.lblRG.Margin = New System.Windows.Forms.Padding(0)
        Me.lblRG.Name = "lblRG"
        Me.lblRG.Size = New System.Drawing.Size(63, 27)
        Me.lblRG.TabIndex = 1
        Me.lblRG.Text = "0000"
        Me.lblRG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'epValida
        '
        Me.epValida.ContainerControl = Me
        '
        'frmClienteAtividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 369)
        Me.Controls.Add(Me.cmbVendaTipo)
        Me.Controls.Add(Me.cmbClienteTipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblRG)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAtividade)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.blvAtividades)
        Me.Name = "frmClienteAtividades"
        Me.Text = "Cliente Atividades"
        Me.Controls.SetChildIndex(Me.blvAtividades, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.txtAtividade, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblRG, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmbClienteTipo, 0)
        Me.Controls.SetChildIndex(Me.cmbVendaTipo, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.blvAtividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.epValida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnNovo As ToolStripButton
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents blvAtividades As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents RGAtividade As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents Atividade As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAtividade As TextBox
    Friend WithEvents cmbClienteTipo As ComboBox
    Friend WithEvents cmbVendaTipo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblRG As Label
    Friend WithEvents epValida As ErrorProvider
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
