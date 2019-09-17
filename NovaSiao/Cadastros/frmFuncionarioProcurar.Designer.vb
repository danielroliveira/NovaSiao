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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbAtivo = New Controles.ComboBox_OnlyValues()
        Me.txtProcura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.lblApelidoFilial = New System.Windows.Forms.Label()
        Me.btnAlterarFilial = New System.Windows.Forms.Button()
        Me.dgvFuncionarios = New System.Windows.Forms.DataGridView()
        Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAlterarFilial)
        Me.Panel1.Controls.Add(Me.lblApelidoFilial)
        Me.Panel1.Size = New System.Drawing.Size(427, 50)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblApelidoFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnAlterarFilial, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(195, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(232, 50)
        Me.lblTitulo.Text = "Procurar Funcionário"
        '
        'cmbAtivo
        '
        Me.cmbAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAtivo.FormattingEnabled = True
        Me.cmbAtivo.Location = New System.Drawing.Point(325, 66)
        Me.cmbAtivo.Name = "cmbAtivo"
        Me.cmbAtivo.RestrictContentToListItems = True
        Me.cmbAtivo.Size = New System.Drawing.Size(82, 27)
        Me.cmbAtivo.TabIndex = 20
        '
        'txtProcura
        '
        Me.txtProcura.Location = New System.Drawing.Point(80, 66)
        Me.txtProcura.Margin = New System.Windows.Forms.Padding(6)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.Size = New System.Drawing.Size(188, 27)
        Me.txtProcura.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(277, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Ativo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 19)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Procura"
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdicionar.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.btnAdicionar.Location = New System.Drawing.Point(149, 437)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(126, 42)
        Me.btnAdicionar.TabIndex = 22
        Me.btnAdicionar.Text = "&Adicionar"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(17, 437)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(126, 42)
        Me.btnEditar.TabIndex = 21
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnFechar.Location = New System.Drawing.Point(281, 437)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(126, 42)
        Me.btnFechar.TabIndex = 23
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'lblApelidoFilial
        '
        Me.lblApelidoFilial.AutoSize = True
        Me.lblApelidoFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblApelidoFilial.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApelidoFilial.ForeColor = System.Drawing.Color.White
        Me.lblApelidoFilial.Location = New System.Drawing.Point(12, 13)
        Me.lblApelidoFilial.Name = "lblApelidoFilial"
        Me.lblApelidoFilial.Size = New System.Drawing.Size(114, 23)
        Me.lblApelidoFilial.TabIndex = 4
        Me.lblApelidoFilial.Text = "Apelido Filial"
        Me.lblApelidoFilial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAlterarFilial
        '
        Me.btnAlterarFilial.BackColor = System.Drawing.Color.Transparent
        Me.btnAlterarFilial.BackgroundImage = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnAlterarFilial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAlterarFilial.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnAlterarFilial.FlatAppearance.BorderSize = 0
        Me.btnAlterarFilial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.btnAlterarFilial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAlterarFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlterarFilial.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlterarFilial.Location = New System.Drawing.Point(132, 11)
        Me.btnAlterarFilial.Name = "btnAlterarFilial"
        Me.btnAlterarFilial.Size = New System.Drawing.Size(28, 28)
        Me.btnAlterarFilial.TabIndex = 25
        Me.btnAlterarFilial.TabStop = False
        Me.btnAlterarFilial.UseVisualStyleBackColor = False
        '
        'dgvFuncionarios
        '
        Me.dgvFuncionarios.AllowUserToAddRows = False
        Me.dgvFuncionarios.AllowUserToDeleteRows = False
        Me.dgvFuncionarios.AllowUserToResizeColumns = False
        Me.dgvFuncionarios.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.dgvFuncionarios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvFuncionarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvFuncionarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFuncionarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvFuncionarios.ColumnHeadersHeight = 33
        Me.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFuncionarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnNome})
        Me.dgvFuncionarios.EnableHeadersVisualStyles = False
        Me.dgvFuncionarios.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvFuncionarios.Location = New System.Drawing.Point(20, 112)
        Me.dgvFuncionarios.MultiSelect = False
        Me.dgvFuncionarios.Name = "dgvFuncionarios"
        Me.dgvFuncionarios.ReadOnly = True
        Me.dgvFuncionarios.RowHeadersVisible = False
        Me.dgvFuncionarios.RowHeadersWidth = 45
        Me.dgvFuncionarios.RowTemplate.Height = 30
        Me.dgvFuncionarios.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFuncionarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFuncionarios.Size = New System.Drawing.Size(387, 311)
        Me.dgvFuncionarios.TabIndex = 41
        '
        'clnID
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle11.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.clnID.DefaultCellStyle = DataGridViewCellStyle11
        Me.clnID.HeaderText = "Reg.:"
        Me.clnID.Name = "clnID"
        Me.clnID.ReadOnly = True
        Me.clnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clnID.Width = 60
        '
        'clnNome
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.PowderBlue
        Me.clnNome.DefaultCellStyle = DataGridViewCellStyle12
        Me.clnNome.HeaderText = "Funcionário"
        Me.clnNome.Name = "clnNome"
        Me.clnNome.ReadOnly = True
        Me.clnNome.Width = 220
        '
        'frmFuncionarioProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(427, 491)
        Me.Controls.Add(Me.dgvFuncionarios)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.cmbAtivo)
        Me.Controls.Add(Me.txtProcura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.KeyPreview = True
        Me.Name = "frmFuncionarioProcurar"
        Me.Text = "Escolha um Funcionario"
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtProcura, 0)
        Me.Controls.SetChildIndex(Me.cmbAtivo, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnAdicionar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.dgvFuncionarios, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbAtivo As Controles.ComboBox_OnlyValues
    Friend WithEvents txtProcura As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents lblApelidoFilial As Label
    Friend WithEvents btnAlterarFilial As Button
    Friend WithEvents dgvFuncionarios As DataGridView
    Friend WithEvents clnID As DataGridViewTextBoxColumn
    Friend WithEvents clnNome As DataGridViewTextBoxColumn
End Class
