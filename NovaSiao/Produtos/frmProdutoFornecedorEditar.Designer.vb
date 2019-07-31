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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnFechar = New System.Windows.Forms.ToolStripButton()
        Me.btnAtivo = New System.Windows.Forms.ToolStripButton()
        Me.lblRGProduto = New System.Windows.Forms.Label()
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtFornecedor = New System.Windows.Forms.TextBox()
        Me.lblPrecoFinal = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblVinculado = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblVinculado)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(621, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblVinculado, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(274, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(347, 50)
        Me.lblTitulo.TabIndex = 0
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
        Me.btnClose.Location = New System.Drawing.Point(589, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 1
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
        Me.tsMenu.Location = New System.Drawing.Point(4, 411)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsMenu.Size = New System.Drawing.Size(615, 48)
        Me.tsMenu.TabIndex = 9
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
        'lblRGProduto
        '
        Me.lblRGProduto.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRGProduto.Location = New System.Drawing.Point(7, 25)
        Me.lblRGProduto.Name = "lblRGProduto"
        Me.lblRGProduto.Size = New System.Drawing.Size(89, 27)
        Me.lblRGProduto.TabIndex = 1
        Me.lblRGProduto.Text = "0000"
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
        Me.Label3.TabIndex = 5
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
        Me.Panel3.Controls.Add(Me.lblProduto)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblRGProduto)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(17, 175)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(587, 58)
        Me.Panel3.TabIndex = 4
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
        Me.Panel4.TabIndex = 6
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
        Me.Panel5.Location = New System.Drawing.Point(17, 342)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(587, 43)
        Me.Panel5.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(17, 320)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 7
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
        Me.lblVinculado.TabIndex = 2
        Me.lblVinculado.Text = "Vinculado à Compra"
        Me.lblVinculado.Visible = False
        '
        'frmProdutoFornecedorEditar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(621, 462)
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
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel5, 0)
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
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnSalvar As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents btnFechar As ToolStripButton
    Friend WithEvents lblRGProduto As Label
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
End Class
