<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAReceberListCliente
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rbtQuitadas = New System.Windows.Forms.RadioButton()
        Me.rbtEmAberto = New System.Windows.Forms.RadioButton()
        Me.rbtCanceladas = New System.Windows.Forms.RadioButton()
        Me.pnlSituacao = New System.Windows.Forms.Panel()
        Me.rbtTodas = New System.Windows.Forms.RadioButton()
        Me.rbtNegociadas = New System.Windows.Forms.RadioButton()
        Me.rbtNegativadas = New System.Windows.Forms.RadioButton()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnCadastro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnReg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnVencimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnPermanencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnValorPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnSituacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.mnuOperacoes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuitarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NegativarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlterarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.VerVendaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnProcurar = New System.Windows.Forms.Button()
        Me.lblCadastro = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblReg = New System.Windows.Forms.Label()
        Me.lblCNP = New System.Windows.Forms.Label()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.chkTodasFiliais = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.pnlSituacao.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuOperacoes.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Size = New System.Drawing.Size(922, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label4, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(747, 0)
        Me.lblTitulo.Padding = New System.Windows.Forms.Padding(0, 0, 8, 6)
        Me.lblTitulo.Size = New System.Drawing.Size(175, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "A Receber"
        '
        'rbtQuitadas
        '
        Me.rbtQuitadas.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtQuitadas.Location = New System.Drawing.Point(208, 4)
        Me.rbtQuitadas.Name = "rbtQuitadas"
        Me.rbtQuitadas.Size = New System.Drawing.Size(112, 33)
        Me.rbtQuitadas.TabIndex = 1
        Me.rbtQuitadas.TabStop = True
        Me.rbtQuitadas.Text = "Quitadas"
        Me.rbtQuitadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtQuitadas.UseVisualStyleBackColor = True
        '
        'rbtEmAberto
        '
        Me.rbtEmAberto.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtEmAberto.Location = New System.Drawing.Point(90, 4)
        Me.rbtEmAberto.Name = "rbtEmAberto"
        Me.rbtEmAberto.Size = New System.Drawing.Size(112, 33)
        Me.rbtEmAberto.TabIndex = 0
        Me.rbtEmAberto.TabStop = True
        Me.rbtEmAberto.Text = "Em Aberto"
        Me.rbtEmAberto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtEmAberto.UseVisualStyleBackColor = True
        '
        'rbtCanceladas
        '
        Me.rbtCanceladas.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtCanceladas.Location = New System.Drawing.Point(326, 4)
        Me.rbtCanceladas.Name = "rbtCanceladas"
        Me.rbtCanceladas.Size = New System.Drawing.Size(112, 33)
        Me.rbtCanceladas.TabIndex = 2
        Me.rbtCanceladas.TabStop = True
        Me.rbtCanceladas.Text = "Canceladas"
        Me.rbtCanceladas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtCanceladas.UseVisualStyleBackColor = True
        '
        'pnlSituacao
        '
        Me.pnlSituacao.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlSituacao.Controls.Add(Me.rbtTodas)
        Me.pnlSituacao.Controls.Add(Me.rbtNegociadas)
        Me.pnlSituacao.Controls.Add(Me.rbtNegativadas)
        Me.pnlSituacao.Controls.Add(Me.rbtCanceladas)
        Me.pnlSituacao.Controls.Add(Me.rbtEmAberto)
        Me.pnlSituacao.Controls.Add(Me.rbtQuitadas)
        Me.pnlSituacao.Location = New System.Drawing.Point(12, 495)
        Me.pnlSituacao.Name = "pnlSituacao"
        Me.pnlSituacao.Size = New System.Drawing.Size(897, 42)
        Me.pnlSituacao.TabIndex = 5
        '
        'rbtTodas
        '
        Me.rbtTodas.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtTodas.Location = New System.Drawing.Point(680, 4)
        Me.rbtTodas.Name = "rbtTodas"
        Me.rbtTodas.Size = New System.Drawing.Size(112, 33)
        Me.rbtTodas.TabIndex = 5
        Me.rbtTodas.TabStop = True
        Me.rbtTodas.Text = "Todas"
        Me.rbtTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtTodas.UseVisualStyleBackColor = True
        '
        'rbtNegociadas
        '
        Me.rbtNegociadas.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNegociadas.Location = New System.Drawing.Point(562, 4)
        Me.rbtNegociadas.Name = "rbtNegociadas"
        Me.rbtNegociadas.Size = New System.Drawing.Size(112, 33)
        Me.rbtNegociadas.TabIndex = 4
        Me.rbtNegociadas.TabStop = True
        Me.rbtNegociadas.Text = "Negociadas"
        Me.rbtNegociadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNegociadas.UseVisualStyleBackColor = True
        '
        'rbtNegativadas
        '
        Me.rbtNegativadas.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNegativadas.Location = New System.Drawing.Point(444, 4)
        Me.rbtNegativadas.Name = "rbtNegativadas"
        Me.rbtNegativadas.Size = New System.Drawing.Size(112, 33)
        Me.rbtNegativadas.TabIndex = 3
        Me.rbtNegativadas.TabStop = True
        Me.rbtNegativadas.Text = "Negativadas"
        Me.rbtNegativadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNegativadas.UseVisualStyleBackColor = True
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.dgvListagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListagem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListagem.ColumnHeadersHeight = 25
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnCadastro, Me.clnReg, Me.clnVencimento, Me.clnValor, Me.clnPermanencia, Me.clnValorPago, Me.clnSituacao})
        Me.dgvListagem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvListagem.EnableHeadersVisualStyles = False
        Me.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvListagem.Location = New System.Drawing.Point(13, 102)
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.RowHeadersWidth = 30
        Me.dgvListagem.Size = New System.Drawing.Size(896, 389)
        Me.dgvListagem.TabIndex = 4
        '
        'clnCadastro
        '
        Me.clnCadastro.HeaderText = "Cadastro"
        Me.clnCadastro.Name = "clnCadastro"
        Me.clnCadastro.Width = 280
        '
        'clnReg
        '
        Me.clnReg.HeaderText = "Reg."
        Me.clnReg.Name = "clnReg"
        Me.clnReg.Width = 70
        '
        'clnVencimento
        '
        Me.clnVencimento.HeaderText = "Vencimento"
        Me.clnVencimento.Name = "clnVencimento"
        Me.clnVencimento.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'clnValor
        '
        Me.clnValor.HeaderText = "Valor"
        Me.clnValor.Name = "clnValor"
        Me.clnValor.Width = 90
        '
        'clnPermanencia
        '
        Me.clnPermanencia.HeaderText = "Perm."
        Me.clnPermanencia.Name = "clnPermanencia"
        Me.clnPermanencia.Width = 70
        '
        'clnValorPago
        '
        Me.clnValorPago.HeaderText = "Pago"
        Me.clnValorPago.Name = "clnValorPago"
        Me.clnValorPago.Width = 90
        '
        'clnSituacao
        '
        Me.clnSituacao.HeaderText = "Situação"
        Me.clnSituacao.Name = "clnSituacao"
        Me.clnSituacao.Width = 130
        '
        'btnFechar
        '
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.Location = New System.Drawing.Point(778, 544)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(131, 50)
        Me.btnFechar.TabIndex = 10
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'mnuOperacoes
        '
        Me.mnuOperacoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarToolStripMenuItem, Me.CancelarToolStripMenuItem, Me.NegativarToolStripMenuItem, Me.NormalizarToolStripMenuItem, Me.ToolStripSeparator1, Me.AlterarToolStripMenuItem, Me.ToolStripSeparator2, Me.VerVendaToolStripMenuItem})
        Me.mnuOperacoes.Name = "mnuOperacoes"
        Me.mnuOperacoes.Size = New System.Drawing.Size(133, 148)
        '
        'QuitarToolStripMenuItem
        '
        Me.QuitarToolStripMenuItem.Name = "QuitarToolStripMenuItem"
        Me.QuitarToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.QuitarToolStripMenuItem.Text = "Quitar"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'NegativarToolStripMenuItem
        '
        Me.NegativarToolStripMenuItem.Name = "NegativarToolStripMenuItem"
        Me.NegativarToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.NegativarToolStripMenuItem.Text = "Negativar"
        '
        'NormalizarToolStripMenuItem
        '
        Me.NormalizarToolStripMenuItem.Name = "NormalizarToolStripMenuItem"
        Me.NormalizarToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.NormalizarToolStripMenuItem.Text = "Normalizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(129, 6)
        '
        'AlterarToolStripMenuItem
        '
        Me.AlterarToolStripMenuItem.Name = "AlterarToolStripMenuItem"
        Me.AlterarToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.AlterarToolStripMenuItem.Text = "Alterar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(129, 6)
        '
        'VerVendaToolStripMenuItem
        '
        Me.VerVendaToolStripMenuItem.Name = "VerVendaToolStripMenuItem"
        Me.VerVendaToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.VerVendaToolStripMenuItem.Text = "Ver Venda"
        '
        'btnProcurar
        '
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.search1
        Me.btnProcurar.Location = New System.Drawing.Point(504, 544)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(131, 50)
        Me.btnProcurar.TabIndex = 8
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProcurar.UseVisualStyleBackColor = True
        '
        'lblCadastro
        '
        Me.lblCadastro.BackColor = System.Drawing.Color.White
        Me.lblCadastro.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCadastro.Location = New System.Drawing.Point(88, 61)
        Me.lblCadastro.Name = "lblCadastro"
        Me.lblCadastro.Size = New System.Drawing.Size(520, 30)
        Me.lblCadastro.TabIndex = 2
        Me.lblCadastro.Text = "Cadastro Nome"
        Me.lblCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.NovaSiao.My.Resources.Resources.Imprimir
        Me.btnImprimir.Location = New System.Drawing.Point(641, 544)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(131, 50)
        Me.btnImprimir.TabIndex = 9
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblReg
        '
        Me.lblReg.BackColor = System.Drawing.Color.White
        Me.lblReg.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReg.Location = New System.Drawing.Point(13, 61)
        Me.lblReg.Name = "lblReg"
        Me.lblReg.Size = New System.Drawing.Size(69, 30)
        Me.lblReg.TabIndex = 1
        Me.lblReg.Text = "0000"
        Me.lblReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCNP
        '
        Me.lblCNP.BackColor = System.Drawing.Color.White
        Me.lblCNP.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCNP.Location = New System.Drawing.Point(614, 61)
        Me.lblCNP.Name = "lblCNP"
        Me.lblCNP.Size = New System.Drawing.Size(295, 30)
        Me.lblCNP.TabIndex = 3
        Me.lblCNP.Text = "Cadastro Nome"
        Me.lblCNP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEscolher
        '
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnEscolher.Location = New System.Drawing.Point(367, 544)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(131, 50)
        Me.btnEscolher.TabIndex = 7
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(111, 3)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Filial:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(14, 15)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(239, 30)
        Me.lblFilial.TabIndex = 0
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkTodasFiliais
        '
        Me.chkTodasFiliais.AutoSize = True
        Me.chkTodasFiliais.Location = New System.Drawing.Point(18, 559)
        Me.chkTodasFiliais.Name = "chkTodasFiliais"
        Me.chkTodasFiliais.Size = New System.Drawing.Size(169, 23)
        Me.chkTodasFiliais.TabIndex = 6
        Me.chkTodasFiliais.TabStop = False
        Me.chkTodasFiliais.Text = "Obter de Todas Filiais"
        Me.chkTodasFiliais.UseVisualStyleBackColor = True
        '
        'frmAReceberListCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(922, 602)
        Me.Controls.Add(Me.chkTodasFiliais)
        Me.Controls.Add(Me.lblReg)
        Me.Controls.Add(Me.lblCNP)
        Me.Controls.Add(Me.lblCadastro)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.btnProcurar)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.pnlSituacao)
        Me.KeyPreview = True
        Me.Name = "frmAReceberListCliente"
        Me.Controls.SetChildIndex(Me.pnlSituacao, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnProcurar, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        Me.Controls.SetChildIndex(Me.lblCadastro, 0)
        Me.Controls.SetChildIndex(Me.lblCNP, 0)
        Me.Controls.SetChildIndex(Me.lblReg, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.chkTodasFiliais, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlSituacao.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuOperacoes.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtQuitadas As RadioButton
    Friend WithEvents rbtEmAberto As RadioButton
    Friend WithEvents rbtCanceladas As RadioButton
    Friend WithEvents pnlSituacao As Panel
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnFechar As Button
    Friend WithEvents rbtNegativadas As RadioButton
    Friend WithEvents mnuOperacoes As ContextMenuStrip
    Friend WithEvents QuitarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NegativarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents VerVendaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnProcurar As Button
    Friend WithEvents lblCadastro As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents lblReg As Label
    Friend WithEvents lblCNP As Label
    Friend WithEvents rbtTodas As RadioButton
    Friend WithEvents rbtNegociadas As RadioButton
    Friend WithEvents btnEscolher As Button
    Friend WithEvents NormalizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents clnCadastro As DataGridViewTextBoxColumn
    Friend WithEvents clnReg As DataGridViewTextBoxColumn
    Friend WithEvents clnVencimento As DataGridViewTextBoxColumn
    Friend WithEvents clnValor As DataGridViewTextBoxColumn
    Friend WithEvents clnPermanencia As DataGridViewTextBoxColumn
    Friend WithEvents clnValorPago As DataGridViewTextBoxColumn
    Friend WithEvents clnSituacao As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents chkTodasFiliais As CheckBox
End Class
