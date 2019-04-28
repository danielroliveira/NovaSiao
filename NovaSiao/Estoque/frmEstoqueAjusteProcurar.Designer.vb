<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstoqueAjusteProcurar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtProcura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnMesAtual = New VIBlend.WinForms.Controls.vButton()
        Me.btnPeriodoAnterior = New VIBlend.WinForms.Controls.vArrowButton()
        Me.btnPeriodoPosterior = New VIBlend.WinForms.Controls.vArrowButton()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.chkPeriodoTodos = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnIDEstoqueItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnAjusteData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnQuantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.pnlVenda = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlMes = New System.Windows.Forms.Panel()
        Me.dtMes = New System.Windows.Forms.MonthCalendar()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.VPanel2 = New VIBlend.WinForms.Controls.vPanel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNovoAjuste = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVenda.SuspendLayout()
        Me.pnlMes.SuspendLayout()
        Me.VPanel2.Content.SuspendLayout()
        Me.VPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(818, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(342, 5)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(315, 34)
        Me.lblTitulo.Text = "Ajustes de Estoque - Procurar"
        '
        'txtProcura
        '
        Me.txtProcura.Location = New System.Drawing.Point(83, 66)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.Size = New System.Drawing.Size(386, 27)
        Me.txtProcura.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Produto"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.btnMesAtual)
        Me.Panel2.Controls.Add(Me.btnPeriodoAnterior)
        Me.Panel2.Controls.Add(Me.btnPeriodoPosterior)
        Me.Panel2.Controls.Add(Me.lblPeriodo)
        Me.Panel2.Controls.Add(Me.chkPeriodoTodos)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(496, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(310, 66)
        Me.Panel2.TabIndex = 6
        '
        'btnMesAtual
        '
        Me.btnMesAtual.AllowAnimations = True
        Me.btnMesAtual.BackColor = System.Drawing.Color.Transparent
        Me.btnMesAtual.Location = New System.Drawing.Point(253, 33)
        Me.btnMesAtual.Name = "btnMesAtual"
        Me.btnMesAtual.RoundedCornersMask = CType(15, Byte)
        Me.btnMesAtual.RoundedCornersRadius = 0
        Me.btnMesAtual.Size = New System.Drawing.Size(48, 25)
        Me.btnMesAtual.TabIndex = 7
        Me.btnMesAtual.TabStop = False
        Me.btnMesAtual.Text = "Atual"
        Me.btnMesAtual.UseVisualStyleBackColor = False
        Me.btnMesAtual.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnPeriodoAnterior
        '
        Me.btnPeriodoAnterior.AllowAnimations = True
        Me.btnPeriodoAnterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Left
        Me.btnPeriodoAnterior.Location = New System.Drawing.Point(18, 33)
        Me.btnPeriodoAnterior.Maximum = 100
        Me.btnPeriodoAnterior.Minimum = 0
        Me.btnPeriodoAnterior.Name = "btnPeriodoAnterior"
        Me.btnPeriodoAnterior.Size = New System.Drawing.Size(25, 25)
        Me.btnPeriodoAnterior.TabIndex = 6
        Me.btnPeriodoAnterior.TabStop = False
        Me.btnPeriodoAnterior.Text = "VArrowButton1"
        Me.btnPeriodoAnterior.Value = 0
        Me.btnPeriodoAnterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnPeriodoPosterior
        '
        Me.btnPeriodoPosterior.AllowAnimations = True
        Me.btnPeriodoPosterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Right
        Me.btnPeriodoPosterior.Location = New System.Drawing.Point(223, 33)
        Me.btnPeriodoPosterior.Maximum = 100
        Me.btnPeriodoPosterior.Minimum = 0
        Me.btnPeriodoPosterior.Name = "btnPeriodoPosterior"
        Me.btnPeriodoPosterior.Size = New System.Drawing.Size(25, 25)
        Me.btnPeriodoPosterior.TabIndex = 6
        Me.btnPeriodoPosterior.TabStop = False
        Me.btnPeriodoPosterior.Text = "VArrowButton1"
        Me.btnPeriodoPosterior.Value = 0
        Me.btnPeriodoPosterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblPeriodo
        '
        Me.lblPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriodo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.Location = New System.Drawing.Point(14, 30)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(238, 30)
        Me.lblPeriodo.TabIndex = 6
        Me.lblPeriodo.Text = "Novembro | 2017"
        Me.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkPeriodoTodos
        '
        Me.chkPeriodoTodos.AutoSize = True
        Me.chkPeriodoTodos.Location = New System.Drawing.Point(109, 4)
        Me.chkPeriodoTodos.Name = "chkPeriodoTodos"
        Me.chkPeriodoTodos.Size = New System.Drawing.Size(152, 23)
        Me.chkPeriodoTodos.TabIndex = 5
        Me.chkPeriodoTodos.TabStop = False
        Me.chkPeriodoTodos.Text = "Todos | Sem Limite"
        Me.chkPeriodoTodos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Período"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDEstoqueItem, Me.clnAjusteData, Me.clnProduto, Me.clnQuantidade, Me.clnTotal})
        Me.dgvListagem.GridColor = System.Drawing.Color.LightSteelBlue
        Me.dgvListagem.Location = New System.Drawing.Point(12, 178)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSlateGray
        Me.dgvListagem.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListagem.Size = New System.Drawing.Size(794, 368)
        Me.dgvListagem.TabIndex = 5
        '
        'clnIDEstoqueItem
        '
        Me.clnIDEstoqueItem.HeaderText = "Reg."
        Me.clnIDEstoqueItem.Name = "clnIDEstoqueItem"
        Me.clnIDEstoqueItem.ReadOnly = True
        Me.clnIDEstoqueItem.Width = 50
        '
        'clnAjusteData
        '
        Me.clnAjusteData.HeaderText = "Data"
        Me.clnAjusteData.Name = "clnAjusteData"
        Me.clnAjusteData.ReadOnly = True
        '
        'clnProduto
        '
        Me.clnProduto.HeaderText = "Produto"
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.ReadOnly = True
        Me.clnProduto.Width = 400
        '
        'clnQuantidade
        '
        Me.clnQuantidade.HeaderText = "Quantidade"
        Me.clnQuantidade.Name = "clnQuantidade"
        Me.clnQuantidade.ReadOnly = True
        Me.clnQuantidade.Width = 70
        '
        'clnTotal
        '
        Me.clnTotal.HeaderText = "Total"
        Me.clnTotal.Name = "clnTotal"
        Me.clnTotal.ReadOnly = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.Location = New System.Drawing.Point(664, 552)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(142, 41)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "&Fechar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEscolher
        '
        Me.btnEscolher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEscolher.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEscolher.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnEscolher.Location = New System.Drawing.Point(368, 552)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(142, 41)
        Me.btnEscolher.TabIndex = 7
        Me.btnEscolher.Text = "&Ver Ajuste"
        Me.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'pnlVenda
        '
        Me.pnlVenda.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlVenda.Controls.Add(Me.Label6)
        Me.pnlVenda.Controls.Add(Me.Label4)
        Me.pnlVenda.Controls.Add(Me.Label7)
        Me.pnlVenda.Controls.Add(Me.Label5)
        Me.pnlVenda.Controls.Add(Me.Label8)
        Me.pnlVenda.Location = New System.Drawing.Point(12, 149)
        Me.pnlVenda.Name = "pnlVenda"
        Me.pnlVenda.Size = New System.Drawing.Size(794, 28)
        Me.pnlVenda.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(669, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 19)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Valor Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(33, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Reg."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(183, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Produto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(590, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Quant."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(110, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 19)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Data"
        '
        'pnlMes
        '
        Me.pnlMes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMes.Controls.Add(Me.dtMes)
        Me.pnlMes.Location = New System.Drawing.Point(510, 223)
        Me.pnlMes.Name = "pnlMes"
        Me.pnlMes.Size = New System.Drawing.Size(234, 166)
        Me.pnlMes.TabIndex = 10
        Me.pnlMes.Visible = False
        '
        'dtMes
        '
        Me.dtMes.Location = New System.Drawing.Point(3, 0)
        Me.dtMes.Name = "dtMes"
        Me.dtMes.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(786, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 47
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'VPanel2
        '
        Me.VPanel2.AllowAnimations = True
        Me.VPanel2.BorderRadius = 0
        '
        'VPanel2.Content
        '
        Me.VPanel2.Content.AutoScroll = True
        Me.VPanel2.Content.BackColor = System.Drawing.SystemColors.Control
        Me.VPanel2.Content.Controls.Add(Me.lblTotal)
        Me.VPanel2.Content.Location = New System.Drawing.Point(1, 1)
        Me.VPanel2.Content.Name = "Content"
        Me.VPanel2.Content.Size = New System.Drawing.Size(122, 33)
        Me.VPanel2.Content.TabIndex = 3
        Me.VPanel2.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.VPanel2.Location = New System.Drawing.Point(130, 556)
        Me.VPanel2.Name = "VPanel2"
        Me.VPanel2.Opacity = 1.0!
        Me.VPanel2.PanelBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.VPanel2.Size = New System.Drawing.Size(124, 35)
        Me.VPanel2.TabIndex = 21
        Me.VPanel2.TabStop = False
        Me.VPanel2.Text = "VPanel2"
        Me.VPanel2.UsePanelBorderColor = True
        Me.VPanel2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotal.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(0, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(122, 33)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "R$ 0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 563)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 19)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Total Ajustado:"
        '
        'btnNovoAjuste
        '
        Me.btnNovoAjuste.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNovoAjuste.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNovoAjuste.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnNovoAjuste.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnNovoAjuste.Location = New System.Drawing.Point(516, 552)
        Me.btnNovoAjuste.Name = "btnNovoAjuste"
        Me.btnNovoAjuste.Size = New System.Drawing.Size(142, 41)
        Me.btnNovoAjuste.TabIndex = 7
        Me.btnNovoAjuste.Text = "&Novo Ajuste"
        Me.btnNovoAjuste.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovoAjuste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovoAjuste.UseVisualStyleBackColor = True
        '
        'frmEstoqueAjusteProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(818, 601)
        Me.Controls.Add(Me.VPanel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlMes)
        Me.Controls.Add(Me.pnlVenda)
        Me.Controls.Add(Me.btnNovoAjuste)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProcura)
        Me.Name = "frmEstoqueAjusteProcurar"
        Me.Text = "Procurar Saída de Produto"
        Me.Controls.SetChildIndex(Me.txtProcura, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnNovoAjuste, 0)
        Me.Controls.SetChildIndex(Me.pnlVenda, 0)
        Me.Controls.SetChildIndex(Me.pnlMes, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.VPanel2, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVenda.ResumeLayout(False)
        Me.pnlVenda.PerformLayout()
        Me.pnlMes.ResumeLayout(False)
        Me.VPanel2.Content.ResumeLayout(False)
        Me.VPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtProcura As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkPeriodoTodos As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents btnPeriodoAnterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents btnPeriodoPosterior As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEscolher As Button
    Friend WithEvents pnlVenda As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnMesAtual As VIBlend.WinForms.Controls.vButton
    Friend WithEvents pnlMes As Panel
    Friend WithEvents dtMes As MonthCalendar
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents Label6 As Label
    Friend WithEvents clnIDEstoqueItem As DataGridViewTextBoxColumn
    Friend WithEvents clnAjusteData As DataGridViewTextBoxColumn
    Friend WithEvents clnProduto As DataGridViewTextBoxColumn
    Friend WithEvents clnQuantidade As DataGridViewTextBoxColumn
    Friend WithEvents clnTotal As DataGridViewTextBoxColumn
    Friend WithEvents VPanel2 As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNovoAjuste As Button
End Class
