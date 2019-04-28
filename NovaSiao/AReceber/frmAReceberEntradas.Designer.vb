<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAReceberEntradas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblReg = New System.Windows.Forms.Label()
        Me.lblCadastro = New System.Windows.Forms.Label()
        Me.lblVencimento = New System.Windows.Forms.Label()
        Me.lblParcelaValor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblValorPagoParcela = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblValorEmAberto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblEmAtrasoDias = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPermanenciaValor = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnEstornar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDataPadrao = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPermanenciaTaxa = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.clnEntradaData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnEntradaValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnMovForma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIDConta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Size = New System.Drawing.Size(788, 50)
        Me.Panel1.TabIndex = 3
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(527, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(261, 50)
        Me.lblTitulo.Text = "A Receber - Entradas"
        '
        'lblReg
        '
        Me.lblReg.BackColor = System.Drawing.Color.Gainsboro
        Me.lblReg.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReg.Location = New System.Drawing.Point(25, 89)
        Me.lblReg.Name = "lblReg"
        Me.lblReg.Size = New System.Drawing.Size(66, 26)
        Me.lblReg.TabIndex = 2
        Me.lblReg.Text = "0000A"
        '
        'lblCadastro
        '
        Me.lblCadastro.BackColor = System.Drawing.Color.Gainsboro
        Me.lblCadastro.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCadastro.Location = New System.Drawing.Point(112, 89)
        Me.lblCadastro.Name = "lblCadastro"
        Me.lblCadastro.Size = New System.Drawing.Size(415, 26)
        Me.lblCadastro.TabIndex = 2
        Me.lblCadastro.Text = "Nome do Cliente"
        '
        'lblVencimento
        '
        Me.lblVencimento.BackColor = System.Drawing.Color.Gainsboro
        Me.lblVencimento.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVencimento.Location = New System.Drawing.Point(533, 89)
        Me.lblVencimento.Name = "lblVencimento"
        Me.lblVencimento.Size = New System.Drawing.Size(104, 26)
        Me.lblVencimento.TabIndex = 2
        Me.lblVencimento.Text = "00/00/0000"
        '
        'lblParcelaValor
        '
        Me.lblParcelaValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParcelaValor.Location = New System.Drawing.Point(137, 136)
        Me.lblParcelaValor.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblParcelaValor.Name = "lblParcelaValor"
        Me.lblParcelaValor.Size = New System.Drawing.Size(101, 26)
        Me.lblParcelaValor.TabIndex = 9
        Me.lblParcelaValor.Text = "R$ 0,00"
        Me.lblParcelaValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Valor da Parcela:"
        '
        'lblValorPagoParcela
        '
        Me.lblValorPagoParcela.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorPagoParcela.Location = New System.Drawing.Point(137, 178)
        Me.lblValorPagoParcela.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblValorPagoParcela.Name = "lblValorPagoParcela"
        Me.lblValorPagoParcela.Size = New System.Drawing.Size(101, 26)
        Me.lblValorPagoParcela.TabIndex = 15
        Me.lblValorPagoParcela.Text = "R$ 0,00"
        Me.lblValorPagoParcela.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Valor Pago:"
        '
        'lblValorEmAberto
        '
        Me.lblValorEmAberto.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorEmAberto.Location = New System.Drawing.Point(137, 220)
        Me.lblValorEmAberto.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblValorEmAberto.Name = "lblValorEmAberto"
        Me.lblValorEmAberto.Size = New System.Drawing.Size(101, 26)
        Me.lblValorEmAberto.TabIndex = 17
        Me.lblValorEmAberto.Text = "R$ 0,00"
        Me.lblValorEmAberto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 19)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Em Aberto:"
        '
        'lblEmAtrasoDias
        '
        Me.lblEmAtrasoDias.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmAtrasoDias.Location = New System.Drawing.Point(137, 262)
        Me.lblEmAtrasoDias.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblEmAtrasoDias.Name = "lblEmAtrasoDias"
        Me.lblEmAtrasoDias.Size = New System.Drawing.Size(101, 26)
        Me.lblEmAtrasoDias.TabIndex = 19
        Me.lblEmAtrasoDias.Text = "00 Dias"
        Me.lblEmAtrasoDias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(53, 267)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 19)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Em Atraso:"
        '
        'lblPermanenciaValor
        '
        Me.lblPermanenciaValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermanenciaValor.Location = New System.Drawing.Point(137, 346)
        Me.lblPermanenciaValor.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblPermanenciaValor.Name = "lblPermanenciaValor"
        Me.lblPermanenciaValor.Size = New System.Drawing.Size(101, 26)
        Me.lblPermanenciaValor.TabIndex = 21
        Me.lblPermanenciaValor.Text = "R$ 0,00"
        Me.lblPermanenciaValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(35, 351)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 19)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Permanência:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(25, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 19)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Reg.:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(112, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 19)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Devedor:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(533, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 19)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Vencimento:"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListagem.BackgroundColor = System.Drawing.Color.AliceBlue
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
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnEntradaData, Me.clnEntradaValor, Me.clnMovForma, Me.clnIDConta})
        Me.dgvListagem.EnableHeadersVisualStyles = False
        Me.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvListagem.Location = New System.Drawing.Point(261, 136)
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        Me.dgvListagem.Size = New System.Drawing.Size(515, 271)
        Me.dgvListagem.TabIndex = 22
        '
        'btnQuitar
        '
        Me.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnQuitar.Location = New System.Drawing.Point(431, 419)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(111, 45)
        Me.btnQuitar.TabIndex = 0
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnEstornar
        '
        Me.btnEstornar.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnEstornar.Location = New System.Drawing.Point(548, 419)
        Me.btnEstornar.Name = "btnEstornar"
        Me.btnEstornar.Size = New System.Drawing.Size(111, 45)
        Me.btnEstornar.TabIndex = 1
        Me.btnEstornar.Text = "&Estornar"
        Me.btnEstornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEstornar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEstornar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnFechar.Location = New System.Drawing.Point(665, 419)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(111, 45)
        Me.btnFechar.TabIndex = 2
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.lblDataPadrao)
        Me.Panel2.Location = New System.Drawing.Point(2, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(784, 29)
        Me.Panel2.TabIndex = 7
        '
        'lblDataPadrao
        '
        Me.lblDataPadrao.BackColor = System.Drawing.Color.Gainsboro
        Me.lblDataPadrao.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataPadrao.Location = New System.Drawing.Point(668, 2)
        Me.lblDataPadrao.Name = "lblDataPadrao"
        Me.lblDataPadrao.Size = New System.Drawing.Size(104, 26)
        Me.lblDataPadrao.TabIndex = 2
        Me.lblDataPadrao.Text = "00/00/0000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(670, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Data Padrão:"
        '
        'lblPermanenciaTaxa
        '
        Me.lblPermanenciaTaxa.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermanenciaTaxa.Location = New System.Drawing.Point(137, 304)
        Me.lblPermanenciaTaxa.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblPermanenciaTaxa.Name = "lblPermanenciaTaxa"
        Me.lblPermanenciaTaxa.Size = New System.Drawing.Size(101, 26)
        Me.lblPermanenciaTaxa.TabIndex = 21
        Me.lblPermanenciaTaxa.Text = "0,00%"
        Me.lblPermanenciaTaxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 309)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 19)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Taxa ao mês:"
        '
        'lblSituacao
        '
        Me.lblSituacao.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.ForeColor = System.Drawing.Color.White
        Me.lblSituacao.Location = New System.Drawing.Point(8, 8)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(181, 35)
        Me.lblSituacao.TabIndex = 23
        Me.lblSituacao.Text = "... Em Aberto ..."
        Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'clnEntradaData
        '
        Me.clnEntradaData.HeaderText = "Data"
        Me.clnEntradaData.Name = "clnEntradaData"
        Me.clnEntradaData.ReadOnly = True
        '
        'clnEntradaValor
        '
        Me.clnEntradaValor.HeaderText = "Valor"
        Me.clnEntradaValor.Name = "clnEntradaValor"
        Me.clnEntradaValor.ReadOnly = True
        '
        'clnMovForma
        '
        Me.clnMovForma.HeaderText = "Forma"
        Me.clnMovForma.Name = "clnMovForma"
        Me.clnMovForma.ReadOnly = True
        '
        'clnIDConta
        '
        Me.clnIDConta.HeaderText = "Conta"
        Me.clnIDConta.Name = "clnIDConta"
        Me.clnIDConta.ReadOnly = True
        Me.clnIDConta.Width = 150
        '
        'frmAReceberEntradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(788, 475)
        Me.Controls.Add(Me.lblEmAtrasoDias)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnEstornar)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPermanenciaTaxa)
        Me.Controls.Add(Me.lblPermanenciaValor)
        Me.Controls.Add(Me.lblValorEmAberto)
        Me.Controls.Add(Me.lblValorPagoParcela)
        Me.Controls.Add(Me.lblParcelaValor)
        Me.Controls.Add(Me.lblVencimento)
        Me.Controls.Add(Me.lblCadastro)
        Me.Controls.Add(Me.lblReg)
        Me.Controls.Add(Me.Panel2)
        Me.KeyPreview = True
        Me.Name = "frmAReceberEntradas"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblReg, 0)
        Me.Controls.SetChildIndex(Me.lblCadastro, 0)
        Me.Controls.SetChildIndex(Me.lblVencimento, 0)
        Me.Controls.SetChildIndex(Me.lblParcelaValor, 0)
        Me.Controls.SetChildIndex(Me.lblValorPagoParcela, 0)
        Me.Controls.SetChildIndex(Me.lblValorEmAberto, 0)
        Me.Controls.SetChildIndex(Me.lblPermanenciaValor, 0)
        Me.Controls.SetChildIndex(Me.lblPermanenciaTaxa, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnQuitar, 0)
        Me.Controls.SetChildIndex(Me.btnEstornar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.lblEmAtrasoDias, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblReg As Label
    Friend WithEvents lblCadastro As Label
    Friend WithEvents lblVencimento As Label
    Friend WithEvents lblParcelaValor As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblValorPagoParcela As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblValorEmAberto As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblEmAtrasoDias As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblPermanenciaValor As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents dgvListagem As DataGridView
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnEstornar As Button
    Friend WithEvents btnFechar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblDataPadrao As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPermanenciaTaxa As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblSituacao As Label
    Friend WithEvents clnEntradaData As DataGridViewTextBoxColumn
    Friend WithEvents clnEntradaValor As DataGridViewTextBoxColumn
    Friend WithEvents clnMovForma As DataGridViewTextBoxColumn
    Friend WithEvents clnIDConta As DataGridViewTextBoxColumn
End Class
