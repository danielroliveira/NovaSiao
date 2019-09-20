<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClienteSimplesProcurar
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
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.cmbAtivo = New Controles.ComboBox_OnlyValues()
		Me.txtProcura = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.btnAdicionar = New System.Windows.Forms.Button()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnFechar = New System.Windows.Forms.Button()
		Me.lblApelidoFilial = New System.Windows.Forms.Label()
		Me.btnAlterarFilial = New System.Windows.Forms.Button()
		Me.dgvLista = New System.Windows.Forms.DataGridView()
		Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.lblProc = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.lblTitulo.Text = "Cliente Simples"
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
		'dgvLista
		'
		Me.dgvLista.AllowUserToAddRows = False
		Me.dgvLista.AllowUserToDeleteRows = False
		Me.dgvLista.AllowUserToResizeColumns = False
		Me.dgvLista.AllowUserToResizeRows = False
		DataGridViewCellStyle5.BackColor = System.Drawing.Color.AntiqueWhite
		DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
		Me.dgvLista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
		Me.dgvLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
		DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
		Me.dgvLista.ColumnHeadersHeight = 33
		Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
		Me.dgvLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnID, Me.clnNome})
		Me.dgvLista.EnableHeadersVisualStyles = False
		Me.dgvLista.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.dgvLista.Location = New System.Drawing.Point(20, 112)
		Me.dgvLista.MultiSelect = False
		Me.dgvLista.Name = "dgvLista"
		Me.dgvLista.ReadOnly = True
		Me.dgvLista.RowHeadersVisible = False
		Me.dgvLista.RowHeadersWidth = 45
		Me.dgvLista.RowTemplate.Height = 30
		Me.dgvLista.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dgvLista.Size = New System.Drawing.Size(387, 311)
		Me.dgvLista.TabIndex = 41
		'
		'clnID
		'
		DataGridViewCellStyle7.BackColor = System.Drawing.Color.PowderBlue
		DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
		Me.clnID.DefaultCellStyle = DataGridViewCellStyle7
		Me.clnID.HeaderText = "Reg.:"
		Me.clnID.Name = "clnID"
		Me.clnID.ReadOnly = True
		Me.clnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		Me.clnID.Width = 60
		'
		'clnNome
		'
		DataGridViewCellStyle8.BackColor = System.Drawing.Color.PowderBlue
		Me.clnNome.DefaultCellStyle = DataGridViewCellStyle8
		Me.clnNome.HeaderText = "Cliente"
		Me.clnNome.Name = "clnNome"
		Me.clnNome.ReadOnly = True
		Me.clnNome.Width = 270
		'
		'lblProc
		'
		Me.lblProc.BackColor = System.Drawing.Color.White
		Me.lblProc.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblProc.Location = New System.Drawing.Point(85, 70)
		Me.lblProc.Margin = New System.Windows.Forms.Padding(0)
		Me.lblProc.Name = "lblProc"
		Me.lblProc.Size = New System.Drawing.Size(182, 19)
		Me.lblProc.TabIndex = 42
		Me.lblProc.Text = "Digite algo para procurar..."
		Me.lblProc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'frmClienteSimplesProcurar
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(427, 491)
		Me.Controls.Add(Me.lblProc)
		Me.Controls.Add(Me.dgvLista)
		Me.Controls.Add(Me.btnFechar)
		Me.Controls.Add(Me.btnAdicionar)
		Me.Controls.Add(Me.btnEditar)
		Me.Controls.Add(Me.cmbAtivo)
		Me.Controls.Add(Me.txtProcura)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label3)
		Me.KeyPreview = True
		Me.Name = "frmClienteSimplesProcurar"
		Me.Text = "Escolha um Funcionario"
		Me.Controls.SetChildIndex(Me.Label3, 0)
		Me.Controls.SetChildIndex(Me.Label2, 0)
		Me.Controls.SetChildIndex(Me.txtProcura, 0)
		Me.Controls.SetChildIndex(Me.cmbAtivo, 0)
		Me.Controls.SetChildIndex(Me.btnEditar, 0)
		Me.Controls.SetChildIndex(Me.btnAdicionar, 0)
		Me.Controls.SetChildIndex(Me.btnFechar, 0)
		Me.Controls.SetChildIndex(Me.dgvLista, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.lblProc, 0)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvLista As DataGridView
	Friend WithEvents clnID As DataGridViewTextBoxColumn
	Friend WithEvents clnNome As DataGridViewTextBoxColumn
	Friend WithEvents lblProc As Label
End Class
