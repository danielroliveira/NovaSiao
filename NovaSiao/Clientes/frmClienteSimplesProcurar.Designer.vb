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
		Me.dgvLista = New System.Windows.Forms.DataGridView()
		Me.clnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.clnNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.lblProc = New System.Windows.Forms.Label()
		Me.btnProcurar = New System.Windows.Forms.Button()
		Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
		Me.Panel1.SuspendLayout()
		CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnClose)
		Me.Panel1.Size = New System.Drawing.Size(427, 50)
		Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
		Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
		'
		'lblTitulo
		'
		Me.lblTitulo.Location = New System.Drawing.Point(135, 0)
		Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitulo.Size = New System.Drawing.Size(292, 50)
		Me.lblTitulo.Text = "Cliente Simples Procurar"
		Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
		Me.btnAdicionar.Location = New System.Drawing.Point(286, 437)
		Me.btnAdicionar.Name = "btnAdicionar"
		Me.btnAdicionar.Size = New System.Drawing.Size(120, 42)
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
		Me.btnEditar.Location = New System.Drawing.Point(153, 437)
		Me.btnEditar.Name = "btnEditar"
		Me.btnEditar.Size = New System.Drawing.Size(120, 42)
		Me.btnEditar.TabIndex = 21
		Me.btnEditar.Text = "&Editar"
		Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnEditar.UseVisualStyleBackColor = True
		'
		'dgvLista
		'
		Me.dgvLista.AllowUserToAddRows = False
		Me.dgvLista.AllowUserToDeleteRows = False
		Me.dgvLista.AllowUserToResizeColumns = False
		Me.dgvLista.AllowUserToResizeRows = False
		DataGridViewCellStyle9.BackColor = System.Drawing.Color.AntiqueWhite
		DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
		Me.dgvLista.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
		Me.dgvLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
		Me.dgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
		DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy
		DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
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
		Me.clnNome.HeaderText = "Cliente"
		Me.clnNome.Name = "clnNome"
		Me.clnNome.ReadOnly = True
		Me.clnNome.Width = 270
		'
		'lblProc
		'
		Me.lblProc.BackColor = System.Drawing.Color.White
		Me.lblProc.Font = New System.Drawing.Font("Calibri Light", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblProc.Location = New System.Drawing.Point(92, 70)
		Me.lblProc.Margin = New System.Windows.Forms.Padding(0)
		Me.lblProc.Name = "lblProc"
		Me.lblProc.Size = New System.Drawing.Size(172, 19)
		Me.lblProc.TabIndex = 42
		Me.lblProc.Text = "Digite algo para procurar..."
		Me.lblProc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnProcurar
		'
		Me.btnProcurar.Enabled = False
		Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.refresh1
		Me.btnProcurar.Location = New System.Drawing.Point(20, 437)
		Me.btnProcurar.Name = "btnProcurar"
		Me.btnProcurar.Size = New System.Drawing.Size(120, 42)
		Me.btnProcurar.TabIndex = 43
		Me.btnProcurar.Text = "&Procurar"
		Me.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnProcurar.UseVisualStyleBackColor = True
		'
		'btnClose
		'
		Me.btnClose.AllowAnimations = True
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.BackColor = System.Drawing.Color.Transparent
		Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
		Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
		Me.btnClose.CausesValidation = False
		Me.btnClose.Location = New System.Drawing.Point(396, 14)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.RibbonStyle = False
		Me.btnClose.RoundedCornersMask = CType(15, Byte)
		Me.btnClose.ShowFocusRectangle = False
		Me.btnClose.Size = New System.Drawing.Size(19, 20)
		Me.btnClose.TabIndex = 26
		Me.btnClose.TabStop = False
		Me.btnClose.UseVisualStyleBackColor = False
		Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
		'
		'frmClienteSimplesProcurar
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
		Me.ClientSize = New System.Drawing.Size(427, 491)
		Me.Controls.Add(Me.btnProcurar)
		Me.Controls.Add(Me.lblProc)
		Me.Controls.Add(Me.dgvLista)
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
		Me.Controls.SetChildIndex(Me.dgvLista, 0)
		Me.Controls.SetChildIndex(Me.Panel1, 0)
		Me.Controls.SetChildIndex(Me.lblProc, 0)
		Me.Controls.SetChildIndex(Me.btnProcurar, 0)
		Me.Panel1.ResumeLayout(False)
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
	Friend WithEvents dgvLista As DataGridView
	Friend WithEvents clnID As DataGridViewTextBoxColumn
	Friend WithEvents clnNome As DataGridViewTextBoxColumn
	Friend WithEvents lblProc As Label
	Friend WithEvents btnProcurar As Button
	Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
End Class
