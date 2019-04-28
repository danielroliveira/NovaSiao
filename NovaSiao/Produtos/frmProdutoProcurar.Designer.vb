<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProdutoProcurar
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtProcurar = New System.Windows.Forms.TextBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkProdutosAtivos = New System.Windows.Forms.CheckBox()
        Me.chkComEstoque = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlProduto = New System.Windows.Forms.Panel()
        Me.MenuProd = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AtivarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.txtSubTipo = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.btnSubTipoEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.btnTipoEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProduto.SuspendLayout()
        Me.MenuProd.SuspendLayout()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(620, 37)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(428, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(192, 37)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Escolher Produto"
        '
        'txtProcurar
        '
        Me.txtProcurar.Location = New System.Drawing.Point(90, 174)
        Me.txtProcurar.Name = "txtProcurar"
        Me.txtProcurar.Size = New System.Drawing.Size(301, 27)
        Me.txtProcurar.TabIndex = 8
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(42, 177)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(42, 19)
        Me.lblDesc.TabIndex = 7
        Me.lblDesc.Text = "Filtro"
        '
        'btnEscolher
        '
        Me.btnEscolher.FlatAppearance.BorderSize = 0
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnEscolher.Location = New System.Drawing.Point(332, 509)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(135, 41)
        Me.btnEscolher.TabIndex = 13
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(473, 509)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 41)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkProdutosAtivos)
        Me.GroupBox1.Controls.Add(Me.chkComEstoque)
        Me.GroupBox1.Location = New System.Drawing.Point(408, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 146)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções:"
        '
        'chkProdutosAtivos
        '
        Me.chkProdutosAtivos.AutoSize = True
        Me.chkProdutosAtivos.Location = New System.Drawing.Point(20, 87)
        Me.chkProdutosAtivos.Name = "chkProdutosAtivos"
        Me.chkProdutosAtivos.Size = New System.Drawing.Size(145, 42)
        Me.chkProdutosAtivos.TabIndex = 1
        Me.chkProdutosAtivos.Text = "Somente Produtos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ativos"
        Me.chkProdutosAtivos.UseVisualStyleBackColor = True
        '
        'chkComEstoque
        '
        Me.chkComEstoque.AutoSize = True
        Me.chkComEstoque.Location = New System.Drawing.Point(20, 28)
        Me.chkComEstoque.Name = "chkComEstoque"
        Me.chkComEstoque.Size = New System.Drawing.Size(145, 42)
        Me.chkComEstoque.TabIndex = 0
        Me.chkComEstoque.Text = "Somente Produtos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "com Estoque"
        Me.chkComEstoque.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(9, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Reg."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(74, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 19)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Descrição"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(462, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 19)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Preço"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(514, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 19)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Ativo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(372, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 19)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Est."
        '
        'pnlProduto
        '
        Me.pnlProduto.BackColor = System.Drawing.Color.Transparent
        Me.pnlProduto.Controls.Add(Me.Label6)
        Me.pnlProduto.Controls.Add(Me.Label3)
        Me.pnlProduto.Controls.Add(Me.Label7)
        Me.pnlProduto.Controls.Add(Me.Label5)
        Me.pnlProduto.Controls.Add(Me.Label4)
        Me.pnlProduto.Location = New System.Drawing.Point(10, 216)
        Me.pnlProduto.Name = "pnlProduto"
        Me.pnlProduto.Size = New System.Drawing.Size(598, 28)
        Me.pnlProduto.TabIndex = 9
        '
        'MenuProd
        '
        Me.MenuProd.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.ToolStripSeparator1, Me.AtivarToolStripMenuItem, Me.DesativarToolStripMenuItem})
        Me.MenuProd.Name = "MenuFab"
        Me.MenuProd.Size = New System.Drawing.Size(169, 76)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EditarToolStripMenuItem.Text = "Editar Produto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'AtivarToolStripMenuItem
        '
        Me.AtivarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem"
        Me.AtivarToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AtivarToolStripMenuItem.Text = "Ativar Produto"
        '
        'DesativarToolStripMenuItem
        '
        Me.DesativarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem"
        Me.DesativarToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DesativarToolStripMenuItem.Text = "Desativar Produto"
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.AllowUserToResizeColumns = False
        Me.dgvProdutos.AllowUserToResizeRows = False
        Me.dgvProdutos.BackgroundColor = System.Drawing.Color.Snow
        Me.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumOrchid
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProdutos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProdutos.EnableHeadersVisualStyles = False
        Me.dgvProdutos.GridColor = System.Drawing.SystemColors.Control
        Me.dgvProdutos.Location = New System.Drawing.Point(10, 245)
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.ReadOnly = True
        Me.dgvProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdutos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProdutos.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvProdutos.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProdutos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue
        Me.dgvProdutos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvProdutos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProdutos.Size = New System.Drawing.Size(598, 258)
        Me.dgvProdutos.TabIndex = 10
        '
        'txtSubTipo
        '
        Me.txtSubTipo.Location = New System.Drawing.Point(90, 110)
        Me.txtSubTipo.Name = "txtSubTipo"
        Me.txtSubTipo.Size = New System.Drawing.Size(206, 27)
        Me.txtSubTipo.TabIndex = 5
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(90, 66)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(206, 27)
        Me.txtTipo.TabIndex = 2
        '
        'btnSubTipoEscolher
        '
        Me.btnSubTipoEscolher.AllowAnimations = True
        Me.btnSubTipoEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnSubTipoEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSubTipoEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubTipoEscolher.Location = New System.Drawing.Point(302, 110)
        Me.btnSubTipoEscolher.Name = "btnSubTipoEscolher"
        Me.btnSubTipoEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnSubTipoEscolher.RoundedCornersRadius = 0
        Me.btnSubTipoEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnSubTipoEscolher.TabIndex = 6
        Me.btnSubTipoEscolher.TabStop = False
        Me.btnSubTipoEscolher.Text = "..."
        Me.btnSubTipoEscolher.UseCompatibleTextRendering = True
        Me.btnSubTipoEscolher.UseVisualStyleBackColor = False
        Me.btnSubTipoEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnTipoEscolher
        '
        Me.btnTipoEscolher.AllowAnimations = True
        Me.btnTipoEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnTipoEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTipoEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTipoEscolher.Location = New System.Drawing.Point(302, 66)
        Me.btnTipoEscolher.Name = "btnTipoEscolher"
        Me.btnTipoEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnTipoEscolher.RoundedCornersRadius = 0
        Me.btnTipoEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnTipoEscolher.TabIndex = 3
        Me.btnTipoEscolher.TabStop = False
        Me.btnTipoEscolher.Text = "..."
        Me.btnTipoEscolher.UseCompatibleTextRendering = True
        Me.btnTipoEscolher.UseVisualStyleBackColor = False
        Me.btnTipoEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SubTipo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 19)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Tipo"
        '
        'frmProdutoProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(620, 557)
        Me.Controls.Add(Me.txtSubTipo)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.btnSubTipoEscolher)
        Me.Controls.Add(Me.btnTipoEscolher)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvProdutos)
        Me.Controls.Add(Me.pnlProduto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.txtProcurar)
        Me.KeyPreview = True
        Me.Name = "frmProdutoProcurar"
        Me.Text = "Procurar Produto"
        Me.Controls.SetChildIndex(Me.txtProcurar, 0)
        Me.Controls.SetChildIndex(Me.lblDesc, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.pnlProduto, 0)
        Me.Controls.SetChildIndex(Me.dgvProdutos, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnTipoEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnSubTipoEscolher, 0)
        Me.Controls.SetChildIndex(Me.txtTipo, 0)
        Me.Controls.SetChildIndex(Me.txtSubTipo, 0)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlProduto.ResumeLayout(False)
        Me.pnlProduto.PerformLayout()
        Me.MenuProd.ResumeLayout(False)
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtProcurar As TextBox
    Friend WithEvents lblDesc As Label
    Friend WithEvents btnEscolher As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkProdutosAtivos As CheckBox
    Friend WithEvents chkComEstoque As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlProduto As Panel
    Friend WithEvents MenuProd As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgvProdutos As DataGridView
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents txtSubTipo As TextBox
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents btnSubTipoEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnTipoEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
End Class
