<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEnvioListagem
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcura = New System.Windows.Forms.TextBox()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnEnvioData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnEnvioDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnImpresso = New System.Windows.Forms.DataGridViewImageColumn()
        Me.clnEnviado = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudPularQtde = New System.Windows.Forms.NumericUpDown()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.cmbRelatorios = New VIBlend.WinForms.Controls.vComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPularQtde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(651, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(292, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(359, 50)
        Me.lblTitulo.Text = "Listagem de Envios | Mala Direta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Procura"
        '
        'txtProcura
        '
        Me.txtProcura.Location = New System.Drawing.Point(79, 62)
        Me.txtProcura.Margin = New System.Windows.Forms.Padding(6)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.Size = New System.Drawing.Size(285, 27)
        Me.txtProcura.TabIndex = 2
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnEditar.Location = New System.Drawing.Point(12, 554)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(165, 43)
        Me.btnEditar.TabIndex = 4
        Me.btnEditar.Text = "&Itens da Listagem"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnFechar.Location = New System.Drawing.Point(513, 554)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(126, 43)
        Me.btnFechar.TabIndex = 6
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        Me.dgvListagem.AllowUserToResizeColumns = False
        Me.dgvListagem.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvListagem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListagem.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvListagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListagem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvListagem.ColumnHeadersHeight = 25
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnEnvioData, Me.clnEnvioDescricao, Me.clnImpresso, Me.clnEnviado})
        Me.dgvListagem.EnableHeadersVisualStyles = False
        Me.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvListagem.Location = New System.Drawing.Point(12, 98)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        Me.dgvListagem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListagem.Size = New System.Drawing.Size(627, 363)
        Me.dgvListagem.TabIndex = 3
        '
        'clnEnvioData
        '
        Me.clnEnvioData.HeaderText = "Data"
        Me.clnEnvioData.Name = "clnEnvioData"
        Me.clnEnvioData.ReadOnly = True
        '
        'clnEnvioDescricao
        '
        Me.clnEnvioDescricao.HeaderText = "Descrição"
        Me.clnEnvioDescricao.Name = "clnEnvioDescricao"
        Me.clnEnvioDescricao.ReadOnly = True
        Me.clnEnvioDescricao.Width = 280
        '
        'clnImpresso
        '
        Me.clnImpresso.HeaderText = "Impresso"
        Me.clnImpresso.Name = "clnImpresso"
        Me.clnImpresso.ReadOnly = True
        Me.clnImpresso.Width = 90
        '
        'clnEnviado
        '
        Me.clnEnviado.HeaderText = "Enviado"
        Me.clnEnviado.Name = "clnEnviado"
        Me.clnEnviado.ReadOnly = True
        Me.clnEnviado.Width = 90
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 475)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Suprimir etiquetas no início"
        '
        'nudPularQtde
        '
        Me.nudPularQtde.Location = New System.Drawing.Point(203, 473)
        Me.nudPularQtde.Maximum = New Decimal(New Integer() {79, 0, 0, 0})
        Me.nudPularQtde.Name = "nudPularQtde"
        Me.nudPularQtde.Size = New System.Drawing.Size(71, 27)
        Me.nudPularQtde.TabIndex = 9
        '
        'lblInfo
        '
        Me.lblInfo.Location = New System.Drawing.Point(433, 471)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(206, 27)
        Me.lblInfo.TabIndex = 12
        Me.lblInfo.Text = "30 Etiquetas"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbRelatorios
        '
        Me.cmbRelatorios.BackColor = System.Drawing.Color.White
        Me.cmbRelatorios.DefaultText = "Selecione o Formato..."
        Me.cmbRelatorios.DisplayMember = ""
        Me.cmbRelatorios.DropDownMaximumSize = New System.Drawing.Size(1000, 1000)
        Me.cmbRelatorios.DropDownMinimumSize = New System.Drawing.Size(10, 10)
        Me.cmbRelatorios.DropDownResizeDirection = VIBlend.WinForms.Controls.SizingDirection.Both
        Me.cmbRelatorios.DropDownWidth = 204
        Me.cmbRelatorios.Location = New System.Drawing.Point(203, 506)
        Me.cmbRelatorios.Name = "cmbRelatorios"
        Me.cmbRelatorios.RoundedCornersMaskListItem = CType(15, Byte)
        Me.cmbRelatorios.Size = New System.Drawing.Size(204, 27)
        Me.cmbRelatorios.TabIndex = 11
        Me.cmbRelatorios.UseThemeBackColor = False
        Me.cmbRelatorios.UseThemeDropDownArrowColor = True
        Me.cmbRelatorios.UseThemeFont = False
        Me.cmbRelatorios.ValueMember = ""
        Me.cmbRelatorios.VIBlendScrollBarsTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        Me.cmbRelatorios.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.RETROBLUE
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 506)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Escolha o Formato"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.CausesValidation = False
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir_PEQ
        Me.btnImprimir.Location = New System.Drawing.Point(183, 554)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(165, 43)
        Me.btnImprimir.TabIndex = 13
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'frmEnvioListagem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(651, 605)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudPularQtde)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.cmbRelatorios)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.txtProcura)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmEnvioListagem"
        Me.Text = "Listagem de Envios"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtProcura, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
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

    Friend WithEvents Label1 As Label
    Friend WithEvents txtProcura As TextBox
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents MenuListagem As ContextMenuStrip
    Friend WithEvents AtivarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents clnEnvioData As DataGridViewTextBoxColumn
    Friend WithEvents clnEnvioDescricao As DataGridViewTextBoxColumn
    Friend WithEvents clnImpresso As DataGridViewImageColumn
    Friend WithEvents clnEnviado As DataGridViewImageColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents nudPularQtde As NumericUpDown
    Friend WithEvents lblInfo As Label
    Friend WithEvents cmbRelatorios As VIBlend.WinForms.Controls.vComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnImprimir As Button
End Class
