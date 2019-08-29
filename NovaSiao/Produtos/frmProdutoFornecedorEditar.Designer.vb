<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdutoFornecedorEditar
    Inherits NovaSiao.frmModFinBorder

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProduto = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFornecedor = New VIBlend.WinForms.Controls.vButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblApelidoFilial = New System.Windows.Forms.Label()
        Me.lblIDTransacao = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpUltimaEntrada = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPCompra = New Controles.Text_Monetario()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtDescontoCompra = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtRGProduto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtFornecedor = New System.Windows.Forms.TextBox()
        Me.lblPrecoFinal = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblVinculado = New System.Windows.Forms.Label()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.clnIDProdutoOrigem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnDescricaoOrigem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnCodBarrasOrigem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlItem = New System.Windows.Forms.Panel()
        Me.btnPanelCancel = New System.Windows.Forms.Button()
        Me.btnPanelOK = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCodBarrasOrigem = New System.Windows.Forms.TextBox()
        Me.txtDescricaoOrigem = New System.Windows.Forms.TextBox()
        Me.txtIDProdutoOrigem = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.mnuItens = New VIBlend.WinForms.Controls.vContextMenu()
        Me.MenuItemEditar = New System.Windows.Forms.MenuItem()
        Me.MenuItemInserir = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItemExcluir = New System.Windows.Forms.MenuItem()
        Me.Panel1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlItem.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblVinculado)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(624, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblVinculado, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(277, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(347, 50)
        Me.lblTitulo.Text = "Produto | Fornecedor - Editar"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(592, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 2
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'tsMenu
        '
        Me.tsMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsMenu.AutoSize = False
        Me.tsMenu.BackColor = System.Drawing.Color.Gainsboro
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalvar, Me.btnCancelar, Me.btnFechar, Me.btnAtivo})
        Me.tsMenu.Location = New System.Drawing.Point(4, 538)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsMenu.Size = New System.Drawing.Size(890, 48)
        Me.tsMenu.TabIndex = 10
        Me.tsMenu.TabStop = True
        Me.tsMenu.Text = "Menu Cliente PF"
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalvar.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(82, 45)
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.ToolTipText = "Salvar Produto"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.delete_page
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 45)
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar Edição"
        '
        'btnFechar
        '
        Me.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(0, 1, 7, 2)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnFechar.Size = New System.Drawing.Size(88, 45)
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAtivo
        '
        Me.btnAtivo.AutoSize = False
        Me.btnAtivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAtivo.CheckOnClick = True
        Me.btnAtivo.Image = Global.NovaSiao.My.Resources.Resources.Switch_ON_PEQ
        Me.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAtivo.Name = "btnAtivo"
        Me.btnAtivo.Size = New System.Drawing.Size(210, 41)
        Me.btnAtivo.Text = "Fornecedor Padrão"
        Me.btnAtivo.ToolTipText = "Fornecedor Padrão"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Reg.:"
        '
        'lblProduto
        '
        Me.lblProduto.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduto.Location = New System.Drawing.Point(106, 25)
        Me.lblProduto.Name = "lblProduto"
        Me.lblProduto.Size = New System.Drawing.Size(475, 27)
        Me.lblProduto.TabIndex = 3
        Me.lblProduto.Text = "Produto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Produto:"
        '
        'btnFornecedor
        '
        Me.btnFornecedor.AllowAnimations = True
        Me.btnFornecedor.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFornecedor.BackColor = System.Drawing.Color.Transparent
        Me.btnFornecedor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFornecedor.Location = New System.Drawing.Point(542, 8)
        Me.btnFornecedor.Name = "btnFornecedor"
        Me.btnFornecedor.RoundedCornersMask = CType(15, Byte)
        Me.btnFornecedor.RoundedCornersRadius = 0
        Me.btnFornecedor.Size = New System.Drawing.Size(34, 27)
        Me.btnFornecedor.TabIndex = 1
        Me.btnFornecedor.TabStop = False
        Me.btnFornecedor.Text = "..."
        Me.btnFornecedor.UseCompatibleTextRendering = True
        Me.btnFornecedor.UseVisualStyleBackColor = False
        Me.btnFornecedor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(17, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fornecedor:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(106, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 19)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Filial Envolvida:"
        '
        'lblApelidoFilial
        '
        Me.lblApelidoFilial.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApelidoFilial.Location = New System.Drawing.Point(106, 26)
        Me.lblApelidoFilial.Name = "lblApelidoFilial"
        Me.lblApelidoFilial.Size = New System.Drawing.Size(322, 27)
        Me.lblApelidoFilial.TabIndex = 3
        Me.lblApelidoFilial.Text = "Apelido Filial"
        '
        'lblIDTransacao
        '
        Me.lblIDTransacao.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDTransacao.Location = New System.Drawing.Point(7, 26)
        Me.lblIDTransacao.Name = "lblIDTransacao"
        Me.lblIDTransacao.Size = New System.Drawing.Size(89, 27)
        Me.lblIDTransacao.TabIndex = 1
        Me.lblIDTransacao.Text = "0000"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblIDTransacao)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lblApelidoFilial)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dtpUltimaEntrada)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(17, 84)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(587, 58)
        Me.Panel2.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Compra:"
        '
        'dtpUltimaEntrada
        '
        Me.dtpUltimaEntrada.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpUltimaEntrada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpUltimaEntrada.Location = New System.Drawing.Point(455, 25)
        Me.dtpUltimaEntrada.Name = "dtpUltimaEntrada"
        Me.dtpUltimaEntrada.Size = New System.Drawing.Size(125, 28)
        Me.dtpUltimaEntrada.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(453, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 19)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Data:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPCompra
        '
        Me.txtPCompra.Location = New System.Drawing.Point(135, 8)
        Me.txtPCompra.MaxLength = 10
        Me.txtPCompra.Name = "txtPCompra"
        Me.txtPCompra.Size = New System.Drawing.Size(118, 27)
        Me.txtPCompra.SomentePositivos = True
        Me.txtPCompra.TabIndex = 1
        Me.txtPCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 19)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Preço de Compra"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(271, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 19)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Desconto"
        '
        'txtDescontoCompra
        '
        Me.txtDescontoCompra.Location = New System.Drawing.Point(347, 8)
        Me.txtDescontoCompra.Name = "txtDescontoCompra"
        Me.txtDescontoCompra.Size = New System.Drawing.Size(81, 27)
        Me.txtDescontoCompra.TabIndex = 3
        Me.txtDescontoCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel3.Controls.Add(Me.txtRGProduto)
        Me.Panel3.Controls.Add(Me.lblProduto)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(17, 175)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(587, 58)
        Me.Panel3.TabIndex = 4
        '
        'txtRGProduto
        '
        Me.txtRGProduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtRGProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRGProduto.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRGProduto.Location = New System.Drawing.Point(12, 27)
        Me.txtRGProduto.Name = "txtRGProduto"
        Me.txtRGProduto.Size = New System.Drawing.Size(88, 24)
        Me.txtRGProduto.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(17, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Última Entrada | Compra:"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(17, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 20)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Produto:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel4.Controls.Add(Me.txtFornecedor)
        Me.Panel4.Controls.Add(Me.btnFornecedor)
        Me.Panel4.Location = New System.Drawing.Point(17, 267)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(587, 43)
        Me.Panel4.TabIndex = 7
        '
        'txtFornecedor
        '
        Me.txtFornecedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFornecedor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFornecedor.Location = New System.Drawing.Point(12, 10)
        Me.txtFornecedor.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFornecedor.Name = "txtFornecedor"
        Me.txtFornecedor.Size = New System.Drawing.Size(524, 24)
        Me.txtFornecedor.TabIndex = 0
        '
        'lblPrecoFinal
        '
        Me.lblPrecoFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrecoFinal.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecoFinal.Location = New System.Drawing.Point(440, 7)
        Me.lblPrecoFinal.Name = "lblPrecoFinal"
        Me.lblPrecoFinal.Size = New System.Drawing.Size(140, 27)
        Me.lblPrecoFinal.TabIndex = 4
        Me.lblPrecoFinal.Text = "R$ 0,00"
        Me.lblPrecoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel5.Controls.Add(Me.txtPCompra)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.txtDescontoCompra)
        Me.Panel5.Controls.Add(Me.Label22)
        Me.Panel5.Controls.Add(Me.lblPrecoFinal)
        Me.Panel5.Location = New System.Drawing.Point(13, 483)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(587, 43)
        Me.Panel5.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(13, 461)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Preço:"
        '
        'lblVinculado
        '
        Me.lblVinculado.AutoSize = True
        Me.lblVinculado.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVinculado.ForeColor = System.Drawing.Color.Gold
        Me.lblVinculado.Location = New System.Drawing.Point(6, 10)
        Me.lblVinculado.Name = "lblVinculado"
        Me.lblVinculado.Size = New System.Drawing.Size(214, 29)
        Me.lblVinculado.TabIndex = 0
        Me.lblVinculado.Text = "Vinculado à Compra"
        Me.lblVinculado.Visible = False
        '
        'dgvItens
        '
        Me.dgvItens.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvItens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItens.ColumnHeadersHeight = 25
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnIDProdutoOrigem, Me.clnDescricaoOrigem, Me.clnCodBarrasOrigem})
        Me.dgvItens.EnableHeadersVisualStyles = False
        Me.dgvItens.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvItens.Location = New System.Drawing.Point(17, 325)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.RowHeadersWidth = 30
        Me.dgvItens.RowTemplate.Height = 30
        Me.dgvItens.Size = New System.Drawing.Size(587, 130)
        Me.dgvItens.TabIndex = 5
        '
        'clnIDProdutoOrigem
        '
        Me.clnIDProdutoOrigem.HeaderText = "Cod."
        Me.clnIDProdutoOrigem.Name = "clnIDProdutoOrigem"
        Me.clnIDProdutoOrigem.Width = 80
        '
        'clnDescricaoOrigem
        '
        Me.clnDescricaoOrigem.HeaderText = "Descricao"
        Me.clnDescricaoOrigem.Name = "clnDescricaoOrigem"
        Me.clnDescricaoOrigem.Width = 300
        '
        'clnCodBarrasOrigem
        '
        Me.clnCodBarrasOrigem.HeaderText = "Cod.Barras"
        Me.clnCodBarrasOrigem.Name = "clnCodBarrasOrigem"
        Me.clnCodBarrasOrigem.Width = 120
        '
        'pnlItem
        '
        Me.pnlItem.Controls.Add(Me.btnPanelCancel)
        Me.pnlItem.Controls.Add(Me.btnPanelOK)
        Me.pnlItem.Controls.Add(Me.Label13)
        Me.pnlItem.Controls.Add(Me.Label14)
        Me.pnlItem.Controls.Add(Me.txtCodBarrasOrigem)
        Me.pnlItem.Controls.Add(Me.txtDescricaoOrigem)
        Me.pnlItem.Controls.Add(Me.txtIDProdutoOrigem)
        Me.pnlItem.Controls.Add(Me.Panel6)
        Me.pnlItem.Location = New System.Drawing.Point(0, 361)
        Me.pnlItem.Name = "pnlItem"
        Me.pnlItem.Size = New System.Drawing.Size(624, 71)
        Me.pnlItem.TabIndex = 11
        Me.pnlItem.Visible = False
        '
        'btnPanelCancel
        '
        Me.btnPanelCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPanelCancel.CausesValidation = False
        Me.btnPanelCancel.Image = Global.NovaSiao.My.Resources.Resources.delete_24px
        Me.btnPanelCancel.Location = New System.Drawing.Point(576, 32)
        Me.btnPanelCancel.Name = "btnPanelCancel"
        Me.btnPanelCancel.Size = New System.Drawing.Size(37, 31)
        Me.btnPanelCancel.TabIndex = 11
        Me.btnPanelCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPanelCancel.UseVisualStyleBackColor = True
        '
        'btnPanelOK
        '
        Me.btnPanelOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPanelOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnPanelOK.Location = New System.Drawing.Point(533, 32)
        Me.btnPanelOK.Name = "btnPanelOK"
        Me.btnPanelOK.Size = New System.Drawing.Size(37, 31)
        Me.btnPanelOK.TabIndex = 10
        Me.btnPanelOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPanelOK.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(111, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Descricao"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(12, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 15)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Cod."
        '
        'txtCodBarrasOrigem
        '
        Me.txtCodBarrasOrigem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCodBarrasOrigem.Location = New System.Drawing.Point(417, 34)
        Me.txtCodBarrasOrigem.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCodBarrasOrigem.Name = "txtCodBarrasOrigem"
        Me.txtCodBarrasOrigem.Size = New System.Drawing.Size(108, 27)
        Me.txtCodBarrasOrigem.TabIndex = 5
        Me.txtCodBarrasOrigem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescricaoOrigem
        '
        Me.txtDescricaoOrigem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDescricaoOrigem.Location = New System.Drawing.Point(106, 33)
        Me.txtDescricaoOrigem.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDescricaoOrigem.Name = "txtDescricaoOrigem"
        Me.txtDescricaoOrigem.Size = New System.Drawing.Size(301, 27)
        Me.txtDescricaoOrigem.TabIndex = 1
        '
        'txtIDProdutoOrigem
        '
        Me.txtIDProdutoOrigem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtIDProdutoOrigem.Location = New System.Drawing.Point(10, 33)
        Me.txtIDProdutoOrigem.Margin = New System.Windows.Forms.Padding(5)
        Me.txtIDProdutoOrigem.Name = "txtIDProdutoOrigem"
        Me.txtIDProdutoOrigem.Size = New System.Drawing.Size(86, 27)
        Me.txtIDProdutoOrigem.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(624, 26)
        Me.Panel6.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(414, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 15)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Cod.Barras"
        '
        'mnuItens
        '
        Me.mnuItens.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemEditar, Me.MenuItemInserir, Me.MenuItem3, Me.MenuItemExcluir})
        '
        'MenuItemEditar
        '
        Me.MenuItemEditar.Index = 0
        Me.MenuItemEditar.Text = "Editar Item"
        '
        'MenuItemInserir
        '
        Me.MenuItemInserir.Index = 1
        Me.MenuItemInserir.Text = "Inserir Novo Item"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "-"
        '
        'MenuItemExcluir
        '
        Me.MenuItemExcluir.Index = 3
        Me.MenuItemExcluir.Text = "Excluir Item"
        '
        'frmProdutoFornecedorEditar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(624, 589)
        Me.Controls.Add(Me.pnlItem)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.Label4)
        Me.KeyPreview = True
        Me.Name = "frmProdutoFornecedorEditar"
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.tsMenu, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel5, 0)
        Me.Controls.SetChildIndex(Me.dgvItens, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlItem, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlItem.ResumeLayout(False)
        Me.pnlItem.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents btnFechar As ToolStripButton
    Friend WithEvents Label2 As Label
    Friend WithEvents lblProduto As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFornecedor As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblApelidoFilial As Label
    Friend WithEvents lblIDTransacao As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpUltimaEntrada As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPCompra As Controles.Text_Monetario
    Friend WithEvents Label10 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtDescontoCompra As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblPrecoFinal As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFornecedor As TextBox
    Friend WithEvents lblVinculado As Label
    Friend WithEvents btnAtivo As ToolStripButton
    Friend WithEvents txtRGProduto As TextBox
    Friend WithEvents dgvItens As DataGridView
    Friend WithEvents clnIDProdutoOrigem As DataGridViewTextBoxColumn
    Friend WithEvents clnDescricaoOrigem As DataGridViewTextBoxColumn
    Friend WithEvents clnCodBarrasOrigem As DataGridViewTextBoxColumn
    Friend WithEvents pnlItem As Panel
    Friend WithEvents btnPanelCancel As Button
    Friend WithEvents btnPanelOK As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtCodBarrasOrigem As TextBox
    Friend WithEvents txtDescricaoOrigem As TextBox
    Friend WithEvents txtIDProdutoOrigem As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents mnuItens As VIBlend.WinForms.Controls.vContextMenu
    Friend WithEvents MenuItemEditar As MenuItem
    Friend WithEvents MenuItemInserir As MenuItem
    Friend WithEvents MenuItem3 As MenuItem
    Friend WithEvents MenuItemExcluir As MenuItem
End Class
