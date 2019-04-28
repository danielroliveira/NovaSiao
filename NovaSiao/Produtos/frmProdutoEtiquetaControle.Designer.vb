<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProdutoEtiquetaControle
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnRG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPVenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPrecoPromocao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.cmbRelatorios = New VIBlend.WinForms.Controls.vComboBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.nudPularQtde = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPularQtde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(891, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(510, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(349, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Impressão de Etiquetas de Venda"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToResizeColumns = False
        Me.dgvListagem.AllowUserToResizeRows = False
        Me.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListagem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvListagem.ColumnHeadersHeight = 27
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnRG, Me.clnProduto, Me.clnQuantidade, Me.clnPVenda, Me.clnPrecoPromocao})
        Me.dgvListagem.EnableHeadersVisualStyles = False
        Me.dgvListagem.Location = New System.Drawing.Point(13, 62)
        Me.dgvListagem.Margin = New System.Windows.Forms.Padding(5)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListagem.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvListagem.RowHeadersWidth = 36
        Me.dgvListagem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvListagem.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvListagem.RowTemplate.Height = 30
        Me.dgvListagem.Size = New System.Drawing.Size(864, 419)
        Me.dgvListagem.StandardTab = True
        Me.dgvListagem.TabIndex = 1
        '
        'clnRG
        '
        Me.clnRG.Frozen = True
        Me.clnRG.HeaderText = "Reg."
        Me.clnRG.Name = "clnRG"
        Me.clnRG.ReadOnly = True
        Me.clnRG.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clnRG.Width = 80
        '
        'clnProduto
        '
        Me.clnProduto.Frozen = True
        Me.clnProduto.HeaderText = "Produto"
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.ReadOnly = True
        Me.clnProduto.Width = 400
        '
        'clnQuantidade
        '
        Me.clnQuantidade.Frozen = True
        Me.clnQuantidade.HeaderText = "Quant."
        Me.clnQuantidade.Name = "clnQuantidade"
        Me.clnQuantidade.ReadOnly = True
        '
        'clnPVenda
        '
        Me.clnPVenda.Frozen = True
        Me.clnPVenda.HeaderText = "P. Venda"
        Me.clnPVenda.Name = "clnPVenda"
        Me.clnPVenda.ReadOnly = True
        '
        'clnPrecoPromocao
        '
        Me.clnPrecoPromocao.HeaderText = "Valor"
        Me.clnPrecoPromocao.Name = "clnPrecoPromocao"
        Me.clnPrecoPromocao.ReadOnly = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.CausesValidation = False
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.Location = New System.Drawing.Point(750, 521)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(127, 43)
        Me.btnFechar.TabIndex = 8
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 541)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Escolha o Tipo de Relatório"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.CausesValidation = False
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir_PEQ
        Me.btnImprimir.Location = New System.Drawing.Point(617, 521)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(127, 43)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'cmbRelatorios
        '
        Me.cmbRelatorios.BackColor = System.Drawing.Color.White
        Me.cmbRelatorios.DefaultText = "Selecione uma Etiqueta..."
        Me.cmbRelatorios.DisplayMember = ""
        Me.cmbRelatorios.DropDownMaximumSize = New System.Drawing.Size(1000, 1000)
        Me.cmbRelatorios.DropDownMinimumSize = New System.Drawing.Size(10, 10)
        Me.cmbRelatorios.DropDownResizeDirection = VIBlend.WinForms.Controls.SizingDirection.Both
        Me.cmbRelatorios.DropDownWidth = 204
        Me.cmbRelatorios.Location = New System.Drawing.Point(208, 537)
        Me.cmbRelatorios.Name = "cmbRelatorios"
        Me.cmbRelatorios.RoundedCornersMaskListItem = CType(15, Byte)
        Me.cmbRelatorios.Size = New System.Drawing.Size(204, 27)
        Me.cmbRelatorios.TabIndex = 5
        Me.cmbRelatorios.UseThemeBackColor = False
        Me.cmbRelatorios.UseThemeDropDownArrowColor = True
        Me.cmbRelatorios.UseThemeFont = False
        Me.cmbRelatorios.ValueMember = ""
        Me.cmbRelatorios.VIBlendScrollBarsTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.cmbRelatorios.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        '
        'lblInfo
        '
        Me.lblInfo.Location = New System.Drawing.Point(617, 488)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(260, 27)
        Me.lblInfo.TabIndex = 6
        Me.lblInfo.Text = "30 Etiquetas"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.CausesValidation = False
        Me.btnClose.Location = New System.Drawing.Point(862, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(19, 20)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'nudPularQtde
        '
        Me.nudPularQtde.Location = New System.Drawing.Point(208, 498)
        Me.nudPularQtde.Maximum = New Decimal(New Integer() {79, 0, 0, 0})
        Me.nudPularQtde.Name = "nudPularQtde"
        Me.nudPularQtde.Size = New System.Drawing.Size(71, 27)
        Me.nudPularQtde.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 500)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Suprimir etiquetas no início"
        '
        'frmProdutoEtiquetaControle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(891, 580)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudPularQtde)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.cmbRelatorios)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.dgvListagem)
        Me.KeyPreview = True
        Me.Name = "frmProdutoEtiquetaControle"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbRelatorios, 0)
        Me.Controls.SetChildIndex(Me.lblInfo, 0)
        Me.Controls.SetChildIndex(Me.nudPularQtde, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPularQtde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnFechar As Button
    Friend WithEvents clnRG As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents clnPVenda As DataGridViewTextBoxColumn
    Friend WithEvents clnPrecoPromocao As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents cmbRelatorios As VIBlend.WinForms.Controls.vComboBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents nudPularQtde As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
