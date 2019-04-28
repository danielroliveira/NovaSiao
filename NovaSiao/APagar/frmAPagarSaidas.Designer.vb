<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAPagarSaidas
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblIdentificador = New System.Windows.Forms.Label()
        Me.lblCadastro = New System.Windows.Forms.Label()
        Me.lblVencimento = New System.Windows.Forms.Label()
        Me.txtAPagarValor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtValorPago = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtValorEmAberto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblEmAtrasoDias = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvListagem = New System.Windows.Forms.DataGridView()
        Me.clnEntradaData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnEntradaValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnIDConta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnObservacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnEstornar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDataPadrao = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCobrancaForma = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBancoNome = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtDesconto = New Controles.Text_Monetario()
        Me.btnConcederDesconto = New System.Windows.Forms.Button()
        Me.txtAcrescimo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblSituacao)
        Me.Panel1.Size = New System.Drawing.Size(675, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblSituacao, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(414, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(261, 50)
        Me.lblTitulo.Text = "A Pagar - Saídas - Quitar"
        '
        'lblIdentificador
        '
        Me.lblIdentificador.BackColor = System.Drawing.Color.White
        Me.lblIdentificador.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdentificador.Location = New System.Drawing.Point(391, 1)
        Me.lblIdentificador.Name = "lblIdentificador"
        Me.lblIdentificador.Size = New System.Drawing.Size(145, 26)
        Me.lblIdentificador.TabIndex = 2
        Me.lblIdentificador.Text = "0000A"
        Me.lblIdentificador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCadastro
        '
        Me.lblCadastro.BackColor = System.Drawing.Color.White
        Me.lblCadastro.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCadastro.Location = New System.Drawing.Point(23, 89)
        Me.lblCadastro.Name = "lblCadastro"
        Me.lblCadastro.Size = New System.Drawing.Size(400, 26)
        Me.lblCadastro.TabIndex = 5
        Me.lblCadastro.Text = "Nome do Credor"
        Me.lblCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVencimento
        '
        Me.lblVencimento.BackColor = System.Drawing.Color.White
        Me.lblVencimento.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVencimento.Location = New System.Drawing.Point(429, 89)
        Me.lblVencimento.Name = "lblVencimento"
        Me.lblVencimento.Size = New System.Drawing.Size(104, 26)
        Me.lblVencimento.TabIndex = 6
        Me.lblVencimento.Text = "00/00/0000"
        Me.lblVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAPagarValor
        '
        Me.txtAPagarValor.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtAPagarValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAPagarValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPagarValor.Location = New System.Drawing.Point(160, 430)
        Me.txtAPagarValor.Name = "txtAPagarValor"
        Me.txtAPagarValor.ReadOnly = True
        Me.txtAPagarValor.Size = New System.Drawing.Size(141, 24)
        Me.txtAPagarValor.TabIndex = 19
        Me.txtAPagarValor.TabStop = False
        Me.txtAPagarValor.Text = "R$ 0,00"
        Me.txtAPagarValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 433)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 19)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Total a Pagar:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValorPago
        '
        Me.txtValorPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtValorPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorPago.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorPago.Location = New System.Drawing.Point(160, 460)
        Me.txtValorPago.Name = "txtValorPago"
        Me.txtValorPago.ReadOnly = True
        Me.txtValorPago.Size = New System.Drawing.Size(141, 24)
        Me.txtValorPago.TabIndex = 21
        Me.txtValorPago.TabStop = False
        Me.txtValorPago.Text = "R$ 0,00"
        Me.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 463)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 19)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Valor Pago:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValorEmAberto
        '
        Me.txtValorEmAberto.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtValorEmAberto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValorEmAberto.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorEmAberto.Location = New System.Drawing.Point(461, 490)
        Me.txtValorEmAberto.Name = "txtValorEmAberto"
        Me.txtValorEmAberto.ReadOnly = True
        Me.txtValorEmAberto.Size = New System.Drawing.Size(141, 24)
        Me.txtValorEmAberto.TabIndex = 27
        Me.txtValorEmAberto.TabStop = False
        Me.txtValorEmAberto.Text = "R$ 0,00"
        Me.txtValorEmAberto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(372, 493)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 19)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Em Aberto:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmAtrasoDias
        '
        Me.lblEmAtrasoDias.BackColor = System.Drawing.Color.White
        Me.lblEmAtrasoDias.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmAtrasoDias.Location = New System.Drawing.Point(543, 1)
        Me.lblEmAtrasoDias.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblEmAtrasoDias.Name = "lblEmAtrasoDias"
        Me.lblEmAtrasoDias.Size = New System.Drawing.Size(101, 26)
        Me.lblEmAtrasoDias.TabIndex = 3
        Me.lblEmAtrasoDias.Text = "00 Dias"
        Me.lblEmAtrasoDias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(568, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 19)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Em Atraso:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(395, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 19)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Identificador:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(23, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 19)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Credor:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(429, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 19)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Vencimento:"
        '
        'dgvListagem
        '
        Me.dgvListagem.AllowUserToAddRows = False
        Me.dgvListagem.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure
        Me.dgvListagem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvListagem.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvListagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListagem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvListagem.ColumnHeadersHeight = 25
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnEntradaData, Me.clnEntradaValor, Me.clnIDConta, Me.clnObservacao})
        Me.dgvListagem.EnableHeadersVisualStyles = False
        Me.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvListagem.Location = New System.Drawing.Point(12, 204)
        Me.dgvListagem.MultiSelect = False
        Me.dgvListagem.Name = "dgvListagem"
        Me.dgvListagem.ReadOnly = True
        Me.dgvListagem.RowHeadersWidth = 30
        Me.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvListagem.Size = New System.Drawing.Size(651, 214)
        Me.dgvListagem.TabIndex = 16
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
        'clnIDConta
        '
        Me.clnIDConta.HeaderText = "Conta"
        Me.clnIDConta.Name = "clnIDConta"
        Me.clnIDConta.ReadOnly = True
        Me.clnIDConta.Width = 150
        '
        'clnObservacao
        '
        Me.clnObservacao.HeaderText = "Observação"
        Me.clnObservacao.Name = "clnObservacao"
        Me.clnObservacao.ReadOnly = True
        Me.clnObservacao.Width = 200
        '
        'btnQuitar
        '
        Me.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnQuitar.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnQuitar.Location = New System.Drawing.Point(13, 537)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(151, 45)
        Me.btnQuitar.TabIndex = 12
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnEstornar
        '
        Me.btnEstornar.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnEstornar.Location = New System.Drawing.Point(327, 537)
        Me.btnEstornar.Name = "btnEstornar"
        Me.btnEstornar.Size = New System.Drawing.Size(151, 45)
        Me.btnEstornar.TabIndex = 14
        Me.btnEstornar.Text = "&Estornar"
        Me.btnEstornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEstornar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEstornar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnFechar.Location = New System.Drawing.Point(552, 537)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(111, 45)
        Me.btnFechar.TabIndex = 15
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblDataPadrao)
        Me.Panel2.Location = New System.Drawing.Point(2, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(670, 29)
        Me.Panel2.TabIndex = 4
        '
        'lblDataPadrao
        '
        Me.lblDataPadrao.BackColor = System.Drawing.Color.White
        Me.lblDataPadrao.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataPadrao.Location = New System.Drawing.Point(538, 2)
        Me.lblDataPadrao.Name = "lblDataPadrao"
        Me.lblDataPadrao.Size = New System.Drawing.Size(104, 26)
        Me.lblDataPadrao.TabIndex = 0
        Me.lblDataPadrao.Text = "00/00/0000"
        Me.lblDataPadrao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(550, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Data Padrão:"
        '
        'lblSituacao
        '
        Me.lblSituacao.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.ForeColor = System.Drawing.Color.White
        Me.lblSituacao.Location = New System.Drawing.Point(8, 8)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(378, 35)
        Me.lblSituacao.TabIndex = 0
        Me.lblSituacao.Text = "... Em Aberto ..."
        Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 19)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Pagamentos:"
        '
        'lblCobrancaForma
        '
        Me.lblCobrancaForma.BackColor = System.Drawing.Color.White
        Me.lblCobrancaForma.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrancaForma.Location = New System.Drawing.Point(23, 1)
        Me.lblCobrancaForma.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblCobrancaForma.Name = "lblCobrancaForma"
        Me.lblCobrancaForma.Size = New System.Drawing.Size(182, 26)
        Me.lblCobrancaForma.TabIndex = 0
        Me.lblCobrancaForma.Text = "Forma"
        Me.lblCobrancaForma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Forma de Cobrança:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBancoNome
        '
        Me.lblBancoNome.BackColor = System.Drawing.Color.White
        Me.lblBancoNome.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBancoNome.Location = New System.Drawing.Point(213, 1)
        Me.lblBancoNome.Margin = New System.Windows.Forms.Padding(2, 8, 8, 8)
        Me.lblBancoNome.Name = "lblBancoNome"
        Me.lblBancoNome.Size = New System.Drawing.Size(171, 26)
        Me.lblBancoNome.TabIndex = 1
        Me.lblBancoNome.Text = "BancoNome"
        Me.lblBancoNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(278, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 19)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Banco:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(77, 493)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 19)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Desconto:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.lblEmAtrasoDias)
        Me.Panel3.Controls.Add(Me.lblCobrancaForma)
        Me.Panel3.Controls.Add(Me.lblBancoNome)
        Me.Panel3.Controls.Add(Me.lblIdentificador)
        Me.Panel3.Location = New System.Drawing.Point(2, 143)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(670, 29)
        Me.Panel3.TabIndex = 11
        '
        'txtDesconto
        '
        Me.txtDesconto.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDesconto.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesconto.Location = New System.Drawing.Point(159, 490)
        Me.txtDesconto.Name = "txtDesconto"
        Me.txtDesconto.ReadOnly = True
        Me.txtDesconto.Size = New System.Drawing.Size(142, 24)
        Me.txtDesconto.SomentePositivos = True
        Me.txtDesconto.TabIndex = 23
        Me.txtDesconto.TabStop = False
        Me.txtDesconto.Text = "R$ 0,00"
        Me.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnConcederDesconto
        '
        Me.btnConcederDesconto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConcederDesconto.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnConcederDesconto.Location = New System.Drawing.Point(170, 537)
        Me.btnConcederDesconto.Name = "btnConcederDesconto"
        Me.btnConcederDesconto.Size = New System.Drawing.Size(151, 45)
        Me.btnConcederDesconto.TabIndex = 13
        Me.btnConcederDesconto.Text = "Editar &Desconto"
        Me.btnConcederDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConcederDesconto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConcederDesconto.UseVisualStyleBackColor = True
        '
        'txtAcrescimo
        '
        Me.txtAcrescimo.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtAcrescimo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAcrescimo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcrescimo.Location = New System.Drawing.Point(462, 460)
        Me.txtAcrescimo.Name = "txtAcrescimo"
        Me.txtAcrescimo.ReadOnly = True
        Me.txtAcrescimo.Size = New System.Drawing.Size(141, 24)
        Me.txtAcrescimo.TabIndex = 25
        Me.txtAcrescimo.TabStop = False
        Me.txtAcrescimo.Text = "R$ 0,00"
        Me.txtAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(336, 463)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 19)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Acréscimo Pago:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmAPagarSaidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(675, 596)
        Me.Controls.Add(Me.txtDesconto)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnEstornar)
        Me.Controls.Add(Me.btnConcederDesconto)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.dgvListagem)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtValorEmAberto)
        Me.Controls.Add(Me.txtAcrescimo)
        Me.Controls.Add(Me.txtValorPago)
        Me.Controls.Add(Me.txtAPagarValor)
        Me.Controls.Add(Me.lblVencimento)
        Me.Controls.Add(Me.lblCadastro)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.KeyPreview = True
        Me.Name = "frmAPagarSaidas"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblCadastro, 0)
        Me.Controls.SetChildIndex(Me.lblVencimento, 0)
        Me.Controls.SetChildIndex(Me.txtAPagarValor, 0)
        Me.Controls.SetChildIndex(Me.txtValorPago, 0)
        Me.Controls.SetChildIndex(Me.txtAcrescimo, 0)
        Me.Controls.SetChildIndex(Me.txtValorEmAberto, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.dgvListagem, 0)
        Me.Controls.SetChildIndex(Me.btnQuitar, 0)
        Me.Controls.SetChildIndex(Me.btnConcederDesconto, 0)
        Me.Controls.SetChildIndex(Me.btnEstornar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.txtDesconto, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIdentificador As Label
    Friend WithEvents lblCadastro As Label
    Friend WithEvents lblVencimento As Label
    Friend WithEvents txtAPagarValor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtValorPago As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtValorEmAberto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblEmAtrasoDias As Label
    Friend WithEvents Label10 As Label
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
    Friend WithEvents lblSituacao As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCobrancaForma As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblBancoNome As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtDesconto As Controles.Text_Monetario
    Friend WithEvents clnEntradaData As DataGridViewTextBoxColumn
    Friend WithEvents clnEntradaValor As DataGridViewTextBoxColumn
    Friend WithEvents clnIDConta As DataGridViewTextBoxColumn
    Friend WithEvents clnObservacao As DataGridViewTextBoxColumn
    Friend WithEvents btnConcederDesconto As Button
    Friend WithEvents txtAcrescimo As TextBox
    Friend WithEvents Label4 As Label
End Class
