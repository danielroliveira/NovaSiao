<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.TabPrincipal = New VIBlend.WinForms.Controls.vTabControl()
        Me.Tab1 = New VIBlend.WinForms.Controls.vTabPage()
        Me.cmbEstoqueNegativo = New Controles.ComboBox_OnlyValues()
        Me.btnEditarFilial = New System.Windows.Forms.Button()
        Me.btnContaAdd = New System.Windows.Forms.Button()
        Me.btnAlteraConta = New System.Windows.Forms.Button()
        Me.btnFilialAdd = New System.Windows.Forms.Button()
        Me.btnAlteraFilial = New System.Windows.Forms.Button()
        Me.lblDataBloqueio = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtContaPadrao = New System.Windows.Forms.TextBox()
        Me.txtFilialPadrao = New System.Windows.Forms.TextBox()
        Me.txtDescontoMaximo = New Controles.Text_SoNumeros()
        Me.txtPermanencia = New Controles.Text_SoNumeros()
        Me.dtpDataPadrao = New System.Windows.Forms.DateTimePicker()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNaturalidade = New System.Windows.Forms.TextBox()
        Me.txtUFPadrao = New System.Windows.Forms.TextBox()
        Me.txtCidadePadrao = New System.Windows.Forms.TextBox()
        Me.Tab2 = New VIBlend.WinForms.Controls.vTabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtUF = New System.Windows.Forms.TextBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.txtCEP = New Controles.MaskText_Telefone()
        Me.txtTelFinanceiro = New Controles.MaskText_Telefone()
        Me.txtTelGerencia = New Controles.MaskText_Telefone()
        Me.txtTelPrincipal = New Controles.MaskText_Telefone()
        Me.txtCNPJ = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIncricao = New System.Windows.Forms.TextBox()
        Me.txtContatoFinanceiro = New System.Windows.Forms.TextBox()
        Me.txtContatoGerencia = New System.Windows.Forms.TextBox()
        Me.txtFantasia = New System.Windows.Forms.TextBox()
        Me.txtRazao = New System.Windows.Forms.TextBox()
        Me.Tab4 = New VIBlend.WinForms.Controls.vTabPage()
        Me.picLogoColor = New System.Windows.Forms.PictureBox()
        Me.picLogoMono = New System.Windows.Forms.PictureBox()
        Me.btnProcLogoColor = New VIBlend.WinForms.Controls.vButton()
        Me.btnProcurarImagem = New VIBlend.WinForms.Controls.vButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLogoColorCaminho = New System.Windows.Forms.TextBox()
        Me.txtLogoMonoCaminho = New System.Windows.Forms.TextBox()
        Me.Tab3 = New VIBlend.WinForms.Controls.vTabPage()
        Me.btnBDAnterior = New VIBlend.WinForms.Controls.vButton()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtBDAnterior = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtServRemoto = New System.Windows.Forms.RadioButton()
        Me.rbtServLocal = New System.Windows.Forms.RadioButton()
        Me.chkVerBackup = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtStringConexao = New System.Windows.Forms.TextBox()
        Me.Tab5 = New VIBlend.WinForms.Controls.vTabPage()
        Me.btnPedidoFolder = New VIBlend.WinForms.Controls.vButton()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPedidoFolder = New System.Windows.Forms.TextBox()
        Me.dgvMensagens = New System.Windows.Forms.DataGridView()
        Me.clnMensagem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.EProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.menuCFOP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProcurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimparToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.TabPrincipal.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.Tab2.SuspendLayout()
        Me.Tab4.SuspendLayout()
        CType(Me.picLogoColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogoMono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Tab5.SuspendLayout()
        CType(Me.dgvMensagens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuCFOP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(746, 63)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(276, 11)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(464, 38)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Configuração do Sistema"
        '
        'TabPrincipal
        '
        Me.TabPrincipal.AllowAnimations = True
        Me.TabPrincipal.Controls.Add(Me.Tab1)
        Me.TabPrincipal.Controls.Add(Me.Tab2)
        Me.TabPrincipal.Controls.Add(Me.Tab4)
        Me.TabPrincipal.Controls.Add(Me.Tab3)
        Me.TabPrincipal.Controls.Add(Me.Tab5)
        Me.TabPrincipal.CornerRadius = 0
        Me.TabPrincipal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPrincipal.Location = New System.Drawing.Point(8, 69)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.Padding = New System.Windows.Forms.Padding(0, 40, 0, 0)
        Me.TabPrincipal.ShowFocusRectangle = True
        Me.TabPrincipal.Size = New System.Drawing.Size(728, 544)
        Me.TabPrincipal.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Top
        Me.TabPrincipal.TabIndex = 1
        Me.TabPrincipal.TabPages.Add(Me.Tab1)
        Me.TabPrincipal.TabPages.Add(Me.Tab2)
        Me.TabPrincipal.TabPages.Add(Me.Tab4)
        Me.TabPrincipal.TabPages.Add(Me.Tab3)
        Me.TabPrincipal.TabPages.Add(Me.Tab5)
        Me.TabPrincipal.TabsAreaBackColor = System.Drawing.Color.Linen
        Me.TabPrincipal.TabsInitialOffset = 15
        Me.TabPrincipal.TabStop = True
        Me.TabPrincipal.TitleHeight = 40
        Me.TabPrincipal.UseTabsAreaBackColor = True
        Me.TabPrincipal.UseTabsAreaBorderColor = True
        Me.TabPrincipal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ULTRABLUE
        '
        'Tab1
        '
        Me.Tab1.ContentBackColor = System.Drawing.Color.Azure
        Me.Tab1.ContentBorderColor = System.Drawing.Color.Transparent
        Me.Tab1.Controls.Add(Me.cmbEstoqueNegativo)
        Me.Tab1.Controls.Add(Me.btnEditarFilial)
        Me.Tab1.Controls.Add(Me.btnContaAdd)
        Me.Tab1.Controls.Add(Me.btnAlteraConta)
        Me.Tab1.Controls.Add(Me.btnFilialAdd)
        Me.Tab1.Controls.Add(Me.btnAlteraFilial)
        Me.Tab1.Controls.Add(Me.lblDataBloqueio)
        Me.Tab1.Controls.Add(Me.Label22)
        Me.Tab1.Controls.Add(Me.txtContaPadrao)
        Me.Tab1.Controls.Add(Me.txtFilialPadrao)
        Me.Tab1.Controls.Add(Me.txtDescontoMaximo)
        Me.Tab1.Controls.Add(Me.txtPermanencia)
        Me.Tab1.Controls.Add(Me.dtpDataPadrao)
        Me.Tab1.Controls.Add(Me.Label35)
        Me.Tab1.Controls.Add(Me.Label34)
        Me.Tab1.Controls.Add(Me.Label15)
        Me.Tab1.Controls.Add(Me.Label29)
        Me.Tab1.Controls.Add(Me.Label19)
        Me.Tab1.Controls.Add(Me.Label13)
        Me.Tab1.Controls.Add(Me.Label1)
        Me.Tab1.Controls.Add(Me.Label20)
        Me.Tab1.Controls.Add(Me.Label21)
        Me.Tab1.Controls.Add(Me.Label12)
        Me.Tab1.Controls.Add(Me.Label11)
        Me.Tab1.Controls.Add(Me.txtNaturalidade)
        Me.Tab1.Controls.Add(Me.txtUFPadrao)
        Me.Tab1.Controls.Add(Me.txtCidadePadrao)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.Location = New System.Drawing.Point(0, 40)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab1.SelectedTextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.Size = New System.Drawing.Size(728, 504)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "Valores Padrão"
        Me.Tab1.TextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.TooltipText = "Valores Padrão"
        Me.Tab1.UseContentBackColor = True
        Me.Tab1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ULTRABLUE
        Me.Tab1.Visible = False
        '
        'cmbEstoqueNegativo
        '
        Me.cmbEstoqueNegativo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEstoqueNegativo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEstoqueNegativo.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstoqueNegativo.FormattingEnabled = True
        Me.cmbEstoqueNegativo.Items.AddRange(New Object() {"SIM", "NÃO"})
        Me.cmbEstoqueNegativo.Location = New System.Drawing.Point(214, 321)
        Me.cmbEstoqueNegativo.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbEstoqueNegativo.Name = "cmbEstoqueNegativo"
        Me.cmbEstoqueNegativo.RestrictContentToListItems = True
        Me.cmbEstoqueNegativo.Size = New System.Drawing.Size(69, 26)
        Me.cmbEstoqueNegativo.TabIndex = 27
        '
        'btnEditarFilial
        '
        Me.btnEditarFilial.BackColor = System.Drawing.Color.Azure
        Me.btnEditarFilial.FlatAppearance.BorderSize = 0
        Me.btnEditarFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarFilial.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditarFilial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditarFilial.Location = New System.Drawing.Point(621, 64)
        Me.btnEditarFilial.Name = "btnEditarFilial"
        Me.btnEditarFilial.Size = New System.Drawing.Size(81, 30)
        Me.btnEditarFilial.TabIndex = 6
        Me.btnEditarFilial.TabStop = False
        Me.btnEditarFilial.Text = "Editar"
        Me.btnEditarFilial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditarFilial.UseVisualStyleBackColor = False
        '
        'btnContaAdd
        '
        Me.btnContaAdd.BackColor = System.Drawing.Color.Azure
        Me.btnContaAdd.FlatAppearance.BorderSize = 0
        Me.btnContaAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContaAdd.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnContaAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContaAdd.Location = New System.Drawing.Point(530, 104)
        Me.btnContaAdd.Name = "btnContaAdd"
        Me.btnContaAdd.Size = New System.Drawing.Size(81, 30)
        Me.btnContaAdd.TabIndex = 10
        Me.btnContaAdd.TabStop = False
        Me.btnContaAdd.Text = "Nova"
        Me.btnContaAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnContaAdd.UseVisualStyleBackColor = False
        '
        'btnAlteraConta
        '
        Me.btnAlteraConta.BackColor = System.Drawing.Color.Azure
        Me.btnAlteraConta.FlatAppearance.BorderSize = 0
        Me.btnAlteraConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlteraConta.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnAlteraConta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlteraConta.Location = New System.Drawing.Point(439, 104)
        Me.btnAlteraConta.Name = "btnAlteraConta"
        Me.btnAlteraConta.Size = New System.Drawing.Size(81, 30)
        Me.btnAlteraConta.TabIndex = 9
        Me.btnAlteraConta.TabStop = False
        Me.btnAlteraConta.Text = "Alterar"
        Me.btnAlteraConta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAlteraConta.UseVisualStyleBackColor = False
        '
        'btnFilialAdd
        '
        Me.btnFilialAdd.BackColor = System.Drawing.Color.Azure
        Me.btnFilialAdd.FlatAppearance.BorderSize = 0
        Me.btnFilialAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilialAdd.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnFilialAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFilialAdd.Location = New System.Drawing.Point(530, 64)
        Me.btnFilialAdd.Name = "btnFilialAdd"
        Me.btnFilialAdd.Size = New System.Drawing.Size(81, 30)
        Me.btnFilialAdd.TabIndex = 5
        Me.btnFilialAdd.TabStop = False
        Me.btnFilialAdd.Text = "Nova"
        Me.btnFilialAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFilialAdd.UseVisualStyleBackColor = False
        '
        'btnAlteraFilial
        '
        Me.btnAlteraFilial.BackColor = System.Drawing.Color.Azure
        Me.btnAlteraFilial.FlatAppearance.BorderSize = 0
        Me.btnAlteraFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlteraFilial.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnAlteraFilial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlteraFilial.Location = New System.Drawing.Point(439, 64)
        Me.btnAlteraFilial.Name = "btnAlteraFilial"
        Me.btnAlteraFilial.Size = New System.Drawing.Size(81, 30)
        Me.btnAlteraFilial.TabIndex = 4
        Me.btnAlteraFilial.TabStop = False
        Me.btnAlteraFilial.Text = "Alterar"
        Me.btnAlteraFilial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAlteraFilial.UseVisualStyleBackColor = False
        '
        'lblDataBloqueio
        '
        Me.lblDataBloqueio.BackColor = System.Drawing.Color.Transparent
        Me.lblDataBloqueio.Location = New System.Drawing.Point(336, 138)
        Me.lblDataBloqueio.Name = "lblDataBloqueio"
        Me.lblDataBloqueio.Size = New System.Drawing.Size(92, 18)
        Me.lblDataBloqueio.TabIndex = 12
        Me.lblDataBloqueio.Text = "01/01/2018"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(213, 138)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 16)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Data Bloqueada:"
        '
        'txtContaPadrao
        '
        Me.txtContaPadrao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContaPadrao.Location = New System.Drawing.Point(214, 106)
        Me.txtContaPadrao.Margin = New System.Windows.Forms.Padding(6)
        Me.txtContaPadrao.Name = "txtContaPadrao"
        Me.txtContaPadrao.Size = New System.Drawing.Size(212, 27)
        Me.txtContaPadrao.TabIndex = 8
        '
        'txtFilialPadrao
        '
        Me.txtFilialPadrao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilialPadrao.Location = New System.Drawing.Point(214, 67)
        Me.txtFilialPadrao.Margin = New System.Windows.Forms.Padding(6)
        Me.txtFilialPadrao.Name = "txtFilialPadrao"
        Me.txtFilialPadrao.Size = New System.Drawing.Size(212, 27)
        Me.txtFilialPadrao.TabIndex = 3
        '
        'txtDescontoMaximo
        '
        Me.txtDescontoMaximo.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescontoMaximo.Inteiro = False
        Me.txtDescontoMaximo.Location = New System.Drawing.Point(214, 282)
        Me.txtDescontoMaximo.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDescontoMaximo.Name = "txtDescontoMaximo"
        Me.txtDescontoMaximo.Size = New System.Drawing.Size(69, 27)
        Me.txtDescontoMaximo.TabIndex = 24
        Me.txtDescontoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPermanencia
        '
        Me.txtPermanencia.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPermanencia.Inteiro = False
        Me.txtPermanencia.Location = New System.Drawing.Point(214, 243)
        Me.txtPermanencia.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPermanencia.Name = "txtPermanencia"
        Me.txtPermanencia.Size = New System.Drawing.Size(69, 27)
        Me.txtPermanencia.TabIndex = 20
        Me.txtPermanencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDataPadrao
        '
        Me.dtpDataPadrao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDataPadrao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataPadrao.Location = New System.Drawing.Point(214, 28)
        Me.dtpDataPadrao.Margin = New System.Windows.Forms.Padding(6)
        Me.dtpDataPadrao.Name = "dtpDataPadrao"
        Me.dtpDataPadrao.Size = New System.Drawing.Size(164, 27)
        Me.dtpDataPadrao.TabIndex = 1
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(83, 109)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(125, 18)
        Me.Label35.TabIndex = 7
        Me.Label35.Text = "Conta Padrão:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(92, 34)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(116, 18)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Data Padrão:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(92, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 18)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Filial Padrão:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(24, 326)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(183, 16)
        Me.Label29.TabIndex = 26
        Me.Label29.Text = "Permitir Estoque Negativo!"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(49, 285)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(159, 18)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Desconto Máximo:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(26, 207)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(182, 18)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Naturalidade Padrão:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(289, 289)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(302, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "(% - Insira 0 para permitir todos descontos)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(20, 246)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(188, 18)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Taxa de Permanência:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(289, 250)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 16)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "(% ao mês)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(452, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 18)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "UF Padrão:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(75, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 18)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Cidade Padrão:"
        '
        'txtNaturalidade
        '
        Me.txtNaturalidade.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNaturalidade.Location = New System.Drawing.Point(214, 204)
        Me.txtNaturalidade.Margin = New System.Windows.Forms.Padding(6)
        Me.txtNaturalidade.MaxLength = 50
        Me.txtNaturalidade.Name = "txtNaturalidade"
        Me.txtNaturalidade.Size = New System.Drawing.Size(212, 27)
        Me.txtNaturalidade.TabIndex = 18
        '
        'txtUFPadrao
        '
        Me.txtUFPadrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUFPadrao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUFPadrao.Location = New System.Drawing.Point(556, 165)
        Me.txtUFPadrao.Margin = New System.Windows.Forms.Padding(6)
        Me.txtUFPadrao.MaxLength = 2
        Me.txtUFPadrao.Name = "txtUFPadrao"
        Me.txtUFPadrao.Size = New System.Drawing.Size(51, 27)
        Me.txtUFPadrao.TabIndex = 16
        '
        'txtCidadePadrao
        '
        Me.txtCidadePadrao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCidadePadrao.Location = New System.Drawing.Point(214, 165)
        Me.txtCidadePadrao.Margin = New System.Windows.Forms.Padding(6)
        Me.txtCidadePadrao.MaxLength = 50
        Me.txtCidadePadrao.Name = "txtCidadePadrao"
        Me.txtCidadePadrao.Size = New System.Drawing.Size(212, 27)
        Me.txtCidadePadrao.TabIndex = 14
        '
        'Tab2
        '
        Me.Tab2.ContentBackColor = System.Drawing.Color.Azure
        Me.Tab2.Controls.Add(Me.Label24)
        Me.Tab2.Controls.Add(Me.Label27)
        Me.Tab2.Controls.Add(Me.Label28)
        Me.Tab2.Controls.Add(Me.Label26)
        Me.Tab2.Controls.Add(Me.Label25)
        Me.Tab2.Controls.Add(Me.txtUF)
        Me.Tab2.Controls.Add(Me.txtEndereco)
        Me.Tab2.Controls.Add(Me.txtBairro)
        Me.Tab2.Controls.Add(Me.txtCidade)
        Me.Tab2.Controls.Add(Me.txtCEP)
        Me.Tab2.Controls.Add(Me.txtTelFinanceiro)
        Me.Tab2.Controls.Add(Me.txtTelGerencia)
        Me.Tab2.Controls.Add(Me.txtTelPrincipal)
        Me.Tab2.Controls.Add(Me.txtCNPJ)
        Me.Tab2.Controls.Add(Me.Label10)
        Me.Tab2.Controls.Add(Me.Label4)
        Me.Tab2.Controls.Add(Me.Label9)
        Me.Tab2.Controls.Add(Me.Label6)
        Me.Tab2.Controls.Add(Me.Label5)
        Me.Tab2.Controls.Add(Me.Label8)
        Me.Tab2.Controls.Add(Me.Label7)
        Me.Tab2.Controls.Add(Me.Label3)
        Me.Tab2.Controls.Add(Me.Label2)
        Me.Tab2.Controls.Add(Me.txtIncricao)
        Me.Tab2.Controls.Add(Me.txtContatoFinanceiro)
        Me.Tab2.Controls.Add(Me.txtContatoGerencia)
        Me.Tab2.Controls.Add(Me.txtFantasia)
        Me.Tab2.Controls.Add(Me.txtRazao)
        Me.Tab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab2.Location = New System.Drawing.Point(0, 40)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab2.SelectedTextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab2.Size = New System.Drawing.Size(728, 504)
        Me.Tab2.TabIndex = 2
        Me.Tab2.Text = "Dados da Empresa"
        Me.Tab2.TextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab2.TooltipText = "Dados da Empresa"
        Me.Tab2.UseContentBackColor = True
        Me.Tab2.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ULTRABLUE
        Me.Tab2.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(442, 382)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(36, 18)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "UF:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(159, 382)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 18)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "CEP:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(116, 304)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(89, 18)
        Me.Label28.TabIndex = 18
        Me.Label28.Text = "Endereço:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(142, 343)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(63, 18)
        Me.Label26.TabIndex = 20
        Me.Label26.Text = "Bairro:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(404, 343)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(71, 18)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Cidade:"
        '
        'txtUF
        '
        Me.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUF.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUF.Location = New System.Drawing.Point(484, 379)
        Me.txtUF.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtUF.MaxLength = 2
        Me.txtUF.Name = "txtUF"
        Me.txtUF.Size = New System.Drawing.Size(51, 27)
        Me.txtUF.TabIndex = 27
        '
        'txtEndereco
        '
        Me.txtEndereco.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndereco.Location = New System.Drawing.Point(214, 301)
        Me.txtEndereco.Margin = New System.Windows.Forms.Padding(6)
        Me.txtEndereco.MaxLength = 50
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(457, 27)
        Me.txtEndereco.TabIndex = 19
        '
        'txtBairro
        '
        Me.txtBairro.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBairro.Location = New System.Drawing.Point(214, 340)
        Me.txtBairro.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtBairro.MaxLength = 50
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.Size = New System.Drawing.Size(175, 27)
        Me.txtBairro.TabIndex = 21
        '
        'txtCidade
        '
        Me.txtCidade.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCidade.Location = New System.Drawing.Point(484, 340)
        Me.txtCidade.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtCidade.MaxLength = 50
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(187, 27)
        Me.txtCidade.TabIndex = 23
        '
        'txtCEP
        '
        Me.txtCEP.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEP.Location = New System.Drawing.Point(214, 379)
        Me.txtCEP.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtCEP.Mask = "99999-999"
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(117, 27)
        Me.txtCEP.TabIndex = 25
        '
        'txtTelFinanceiro
        '
        Me.txtTelFinanceiro.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelFinanceiro.Location = New System.Drawing.Point(214, 262)
        Me.txtTelFinanceiro.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtTelFinanceiro.Mask = "(99) 99000-0000"
        Me.txtTelFinanceiro.Name = "txtTelFinanceiro"
        Me.txtTelFinanceiro.Size = New System.Drawing.Size(164, 27)
        Me.txtTelFinanceiro.TabIndex = 15
        '
        'txtTelGerencia
        '
        Me.txtTelGerencia.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelGerencia.Location = New System.Drawing.Point(214, 223)
        Me.txtTelGerencia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtTelGerencia.Mask = "(99) 99000-0000"
        Me.txtTelGerencia.Name = "txtTelGerencia"
        Me.txtTelGerencia.Size = New System.Drawing.Size(164, 27)
        Me.txtTelGerencia.TabIndex = 11
        '
        'txtTelPrincipal
        '
        Me.txtTelPrincipal.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelPrincipal.Location = New System.Drawing.Point(214, 184)
        Me.txtTelPrincipal.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtTelPrincipal.Mask = "(99) 99000-0000"
        Me.txtTelPrincipal.Name = "txtTelPrincipal"
        Me.txtTelPrincipal.Size = New System.Drawing.Size(164, 27)
        Me.txtTelPrincipal.TabIndex = 9
        '
        'txtCNPJ
        '
        Me.txtCNPJ.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCNPJ.Location = New System.Drawing.Point(214, 106)
        Me.txtCNPJ.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtCNPJ.Mask = "00,000,000/0000-00"
        Me.txtCNPJ.Name = "txtCNPJ"
        Me.txtCNPJ.Size = New System.Drawing.Size(214, 27)
        Me.txtCNPJ.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(32, 265)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 18)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Telefone Financeiro:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(150, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "CNPJ:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(44, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 18)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Telefone Gerência:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 18)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Telefone Principal:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Inscrição Estadual:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(412, 265)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 18)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Falar Com:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(422, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 18)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Gerência:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(68, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nome Fantasia:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Razão Social:"
        '
        'txtIncricao
        '
        Me.txtIncricao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncricao.Location = New System.Drawing.Point(214, 145)
        Me.txtIncricao.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtIncricao.MaxLength = 50
        Me.txtIncricao.Name = "txtIncricao"
        Me.txtIncricao.Size = New System.Drawing.Size(214, 27)
        Me.txtIncricao.TabIndex = 7
        '
        'txtContatoFinanceiro
        '
        Me.txtContatoFinanceiro.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContatoFinanceiro.Location = New System.Drawing.Point(514, 262)
        Me.txtContatoFinanceiro.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtContatoFinanceiro.MaxLength = 30
        Me.txtContatoFinanceiro.Name = "txtContatoFinanceiro"
        Me.txtContatoFinanceiro.Size = New System.Drawing.Size(157, 27)
        Me.txtContatoFinanceiro.TabIndex = 17
        '
        'txtContatoGerencia
        '
        Me.txtContatoGerencia.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContatoGerencia.Location = New System.Drawing.Point(514, 223)
        Me.txtContatoGerencia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtContatoGerencia.MaxLength = 30
        Me.txtContatoGerencia.Name = "txtContatoGerencia"
        Me.txtContatoGerencia.Size = New System.Drawing.Size(157, 27)
        Me.txtContatoGerencia.TabIndex = 13
        '
        'txtFantasia
        '
        Me.txtFantasia.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFantasia.Location = New System.Drawing.Point(214, 67)
        Me.txtFantasia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtFantasia.MaxLength = 50
        Me.txtFantasia.Name = "txtFantasia"
        Me.txtFantasia.Size = New System.Drawing.Size(457, 27)
        Me.txtFantasia.TabIndex = 3
        '
        'txtRazao
        '
        Me.txtRazao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazao.Location = New System.Drawing.Point(214, 28)
        Me.txtRazao.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.txtRazao.MaxLength = 100
        Me.txtRazao.Name = "txtRazao"
        Me.txtRazao.Size = New System.Drawing.Size(457, 27)
        Me.txtRazao.TabIndex = 1
        '
        'Tab4
        '
        Me.Tab4.ContentBackColor = System.Drawing.Color.Azure
        Me.Tab4.Controls.Add(Me.picLogoColor)
        Me.Tab4.Controls.Add(Me.picLogoMono)
        Me.Tab4.Controls.Add(Me.btnProcLogoColor)
        Me.Tab4.Controls.Add(Me.btnProcurarImagem)
        Me.Tab4.Controls.Add(Me.Label18)
        Me.Tab4.Controls.Add(Me.Label17)
        Me.Tab4.Controls.Add(Me.txtLogoColorCaminho)
        Me.Tab4.Controls.Add(Me.txtLogoMonoCaminho)
        Me.Tab4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab4.Location = New System.Drawing.Point(0, 40)
        Me.Tab4.Name = "Tab4"
        Me.Tab4.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab4.SelectedTextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab4.Size = New System.Drawing.Size(728, 504)
        Me.Tab4.TabIndex = 3
        Me.Tab4.Text = "Logomarcas"
        Me.Tab4.TextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab4.TooltipText = "TabPage"
        Me.Tab4.UseContentBackColor = True
        Me.Tab4.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ULTRABLUE
        Me.Tab4.Visible = False
        '
        'picLogoColor
        '
        Me.picLogoColor.BackColor = System.Drawing.Color.Transparent
        Me.picLogoColor.InitialImage = Nothing
        Me.picLogoColor.Location = New System.Drawing.Point(214, 70)
        Me.picLogoColor.Name = "picLogoColor"
        Me.picLogoColor.Size = New System.Drawing.Size(413, 115)
        Me.picLogoColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogoColor.TabIndex = 12
        Me.picLogoColor.TabStop = False
        '
        'picLogoMono
        '
        Me.picLogoMono.BackColor = System.Drawing.Color.Transparent
        Me.picLogoMono.InitialImage = Nothing
        Me.picLogoMono.Location = New System.Drawing.Point(214, 255)
        Me.picLogoMono.Name = "picLogoMono"
        Me.picLogoMono.Size = New System.Drawing.Size(413, 115)
        Me.picLogoMono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogoMono.TabIndex = 12
        Me.picLogoMono.TabStop = False
        '
        'btnProcLogoColor
        '
        Me.btnProcLogoColor.AllowAnimations = True
        Me.btnProcLogoColor.BackColor = System.Drawing.Color.Transparent
        Me.btnProcLogoColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcLogoColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcLogoColor.Location = New System.Drawing.Point(636, 26)
        Me.btnProcLogoColor.Name = "btnProcLogoColor"
        Me.btnProcLogoColor.RoundedCornersMask = CType(15, Byte)
        Me.btnProcLogoColor.RoundedCornersRadius = 0
        Me.btnProcLogoColor.Size = New System.Drawing.Size(34, 30)
        Me.btnProcLogoColor.TabIndex = 10
        Me.btnProcLogoColor.TabStop = False
        Me.btnProcLogoColor.Text = "..."
        Me.btnProcLogoColor.UseCompatibleTextRendering = True
        Me.btnProcLogoColor.UseVisualStyleBackColor = False
        Me.btnProcLogoColor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnProcurarImagem
        '
        Me.btnProcurarImagem.AllowAnimations = True
        Me.btnProcurarImagem.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurarImagem.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcurarImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcurarImagem.Location = New System.Drawing.Point(636, 209)
        Me.btnProcurarImagem.Name = "btnProcurarImagem"
        Me.btnProcurarImagem.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurarImagem.RoundedCornersRadius = 0
        Me.btnProcurarImagem.Size = New System.Drawing.Size(34, 30)
        Me.btnProcurarImagem.TabIndex = 10
        Me.btnProcurarImagem.TabStop = False
        Me.btnProcurarImagem.Text = "..."
        Me.btnProcurarImagem.UseCompatibleTextRendering = True
        Me.btnProcurarImagem.UseVisualStyleBackColor = False
        Me.btnProcurarImagem.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(31, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(176, 18)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Logomarca Colorida:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(55, 214)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 18)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Logomarca Mono:"
        '
        'txtLogoColorCaminho
        '
        Me.txtLogoColorCaminho.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogoColorCaminho.Location = New System.Drawing.Point(214, 28)
        Me.txtLogoColorCaminho.MaxLength = 200
        Me.txtLogoColorCaminho.Name = "txtLogoColorCaminho"
        Me.txtLogoColorCaminho.Size = New System.Drawing.Size(413, 27)
        Me.txtLogoColorCaminho.TabIndex = 11
        '
        'txtLogoMonoCaminho
        '
        Me.txtLogoMonoCaminho.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogoMonoCaminho.Location = New System.Drawing.Point(214, 211)
        Me.txtLogoMonoCaminho.MaxLength = 200
        Me.txtLogoMonoCaminho.Name = "txtLogoMonoCaminho"
        Me.txtLogoMonoCaminho.Size = New System.Drawing.Size(413, 27)
        Me.txtLogoMonoCaminho.TabIndex = 11
        '
        'Tab3
        '
        Me.Tab3.BackColor = System.Drawing.Color.Linen
        Me.Tab3.ContentBackColor = System.Drawing.Color.Azure
        Me.Tab3.ContentBorderColor = System.Drawing.Color.Transparent
        Me.Tab3.Controls.Add(Me.btnBDAnterior)
        Me.Tab3.Controls.Add(Me.Label23)
        Me.Tab3.Controls.Add(Me.txtBDAnterior)
        Me.Tab3.Controls.Add(Me.GroupBox1)
        Me.Tab3.Controls.Add(Me.chkVerBackup)
        Me.Tab3.Controls.Add(Me.Label16)
        Me.Tab3.Controls.Add(Me.txtStringConexao)
        Me.Tab3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab3.Location = New System.Drawing.Point(0, 40)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab3.SelectedTextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab3.Size = New System.Drawing.Size(728, 504)
        Me.Tab3.TabIndex = 4
        Me.Tab3.Text = "Servidor de Dados"
        Me.Tab3.TextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab3.TooltipText = "Servidor de Dados"
        Me.Tab3.UseContentBackColor = True
        Me.Tab3.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ULTRABLUE
        Me.Tab3.Visible = False
        '
        'btnBDAnterior
        '
        Me.btnBDAnterior.AllowAnimations = True
        Me.btnBDAnterior.BackColor = System.Drawing.Color.Transparent
        Me.btnBDAnterior.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnBDAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBDAnterior.Location = New System.Drawing.Point(637, 304)
        Me.btnBDAnterior.Name = "btnBDAnterior"
        Me.btnBDAnterior.RoundedCornersMask = CType(15, Byte)
        Me.btnBDAnterior.RoundedCornersRadius = 0
        Me.btnBDAnterior.Size = New System.Drawing.Size(34, 30)
        Me.btnBDAnterior.TabIndex = 13
        Me.btnBDAnterior.TabStop = False
        Me.btnBDAnterior.Text = "..."
        Me.btnBDAnterior.UseCompatibleTextRendering = True
        Me.btnBDAnterior.UseVisualStyleBackColor = False
        Me.btnBDAnterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(99, 308)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(109, 18)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "BD Anterior:"
        '
        'txtBDAnterior
        '
        Me.txtBDAnterior.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBDAnterior.Location = New System.Drawing.Point(214, 305)
        Me.txtBDAnterior.MaxLength = 200
        Me.txtBDAnterior.Name = "txtBDAnterior"
        Me.txtBDAnterior.Size = New System.Drawing.Size(417, 27)
        Me.txtBDAnterior.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbtServRemoto)
        Me.GroupBox1.Controls.Add(Me.rbtServLocal)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(214, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Banco de Dados"
        '
        'rbtServRemoto
        '
        Me.rbtServRemoto.AutoSize = True
        Me.rbtServRemoto.Location = New System.Drawing.Point(173, 28)
        Me.rbtServRemoto.Name = "rbtServRemoto"
        Me.rbtServRemoto.Size = New System.Drawing.Size(89, 22)
        Me.rbtServRemoto.TabIndex = 1
        Me.rbtServRemoto.TabStop = True
        Me.rbtServRemoto.Text = "Remoto"
        Me.rbtServRemoto.UseVisualStyleBackColor = True
        '
        'rbtServLocal
        '
        Me.rbtServLocal.AutoSize = True
        Me.rbtServLocal.Location = New System.Drawing.Point(67, 28)
        Me.rbtServLocal.Name = "rbtServLocal"
        Me.rbtServLocal.Size = New System.Drawing.Size(68, 22)
        Me.rbtServLocal.TabIndex = 0
        Me.rbtServLocal.TabStop = True
        Me.rbtServLocal.Text = "Local"
        Me.rbtServLocal.UseVisualStyleBackColor = True
        '
        'chkVerBackup
        '
        Me.chkVerBackup.AutoSize = True
        Me.chkVerBackup.BackColor = System.Drawing.Color.Transparent
        Me.chkVerBackup.Checked = True
        Me.chkVerBackup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVerBackup.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerBackup.Location = New System.Drawing.Point(214, 251)
        Me.chkVerBackup.Name = "chkVerBackup"
        Me.chkVerBackup.Size = New System.Drawing.Size(300, 22)
        Me.chkVerBackup.TabIndex = 1
        Me.chkVerBackup.Text = "Verificar Ultimo Backup ao Iniciar"
        Me.chkVerBackup.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(43, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(165, 18)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "String de Conexão:"
        '
        'txtStringConexao
        '
        Me.txtStringConexao.BackColor = System.Drawing.Color.White
        Me.txtStringConexao.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStringConexao.Location = New System.Drawing.Point(214, 28)
        Me.txtStringConexao.Multiline = True
        Me.txtStringConexao.Name = "txtStringConexao"
        Me.txtStringConexao.Size = New System.Drawing.Size(457, 123)
        Me.txtStringConexao.TabIndex = 3
        '
        'Tab5
        '
        Me.Tab5.ContentBackColor = System.Drawing.Color.Azure
        Me.Tab5.Controls.Add(Me.btnPedidoFolder)
        Me.Tab5.Controls.Add(Me.Label30)
        Me.Tab5.Controls.Add(Me.txtPedidoFolder)
        Me.Tab5.Controls.Add(Me.dgvMensagens)
        Me.Tab5.Controls.Add(Me.Label14)
        Me.Tab5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab5.Location = New System.Drawing.Point(0, 40)
        Me.Tab5.Name = "Tab5"
        Me.Tab5.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab5.SelectedTextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab5.Size = New System.Drawing.Size(728, 504)
        Me.Tab5.TabIndex = 5
        Me.Tab5.Text = "Pedidos"
        Me.Tab5.TextFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab5.TooltipText = "TabPage"
        Me.Tab5.UseContentBackColor = True
        Me.Tab5.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.ULTRABLUE
        Me.Tab5.Visible = False
        '
        'btnPedidoFolder
        '
        Me.btnPedidoFolder.AllowAnimations = True
        Me.btnPedidoFolder.BackColor = System.Drawing.Color.Transparent
        Me.btnPedidoFolder.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnPedidoFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPedidoFolder.Location = New System.Drawing.Point(656, 216)
        Me.btnPedidoFolder.Name = "btnPedidoFolder"
        Me.btnPedidoFolder.RoundedCornersMask = CType(15, Byte)
        Me.btnPedidoFolder.RoundedCornersRadius = 0
        Me.btnPedidoFolder.Size = New System.Drawing.Size(34, 30)
        Me.btnPedidoFolder.TabIndex = 31
        Me.btnPedidoFolder.TabStop = False
        Me.btnPedidoFolder.Text = "..."
        Me.btnPedidoFolder.UseCompatibleTextRendering = True
        Me.btnPedidoFolder.UseVisualStyleBackColor = False
        Me.btnPedidoFolder.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(38, 220)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(166, 18)
        Me.Label30.TabIndex = 30
        Me.Label30.Text = "Pasta dos Pedidos:"
        '
        'txtPedidoFolder
        '
        Me.txtPedidoFolder.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedidoFolder.Location = New System.Drawing.Point(214, 217)
        Me.txtPedidoFolder.MaxLength = 200
        Me.txtPedidoFolder.Name = "txtPedidoFolder"
        Me.txtPedidoFolder.Size = New System.Drawing.Size(436, 27)
        Me.txtPedidoFolder.TabIndex = 32
        '
        'dgvMensagens
        '
        Me.dgvMensagens.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgvMensagens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMensagens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMensagens.ColumnHeadersHeight = 30
        Me.dgvMensagens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnMensagem})
        Me.dgvMensagens.EnableHeadersVisualStyles = False
        Me.dgvMensagens.Location = New System.Drawing.Point(214, 28)
        Me.dgvMensagens.Name = "dgvMensagens"
        Me.dgvMensagens.RowHeadersWidth = 35
        Me.dgvMensagens.RowTemplate.Height = 30
        Me.dgvMensagens.Size = New System.Drawing.Size(476, 173)
        Me.dgvMensagens.TabIndex = 29
        '
        'clnMensagem
        '
        Me.clnMensagem.HeaderText = "Avisos"
        Me.clnMensagem.Name = "clnMensagem"
        Me.clnMensagem.Width = 400
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(35, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(173, 18)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Avisos nos Pedidos:"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Linen
        Me.Panel2.Controls.Add(Me.btnCancelar)
        Me.Panel2.Controls.Add(Me.btnSalvar)
        Me.Panel2.Location = New System.Drawing.Point(0, 616)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(746, 59)
        Me.Panel2.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BurlyWood
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.cancelar_edicao
        Me.btnCancelar.Location = New System.Drawing.Point(590, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(149, 52)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalvar.FlatAppearance.BorderSize = 0
        Me.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BurlyWood
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Image = Global.NovaSiao.My.Resources.Resources.Salvar_PEQ
        Me.btnSalvar.Location = New System.Drawing.Point(8, 3)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(120, 52)
        Me.btnSalvar.TabIndex = 0
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'EProvider
        '
        Me.EProvider.ContainerControl = Me
        '
        'menuCFOP
        '
        Me.menuCFOP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcurarToolStripMenuItem, Me.LimparToolStripMenuItem})
        Me.menuCFOP.Name = "cmsCFOP"
        Me.menuCFOP.Size = New System.Drawing.Size(131, 52)
        '
        'ProcurarToolStripMenuItem
        '
        Me.ProcurarToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProcurarToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.search_peq
        Me.ProcurarToolStripMenuItem.Name = "ProcurarToolStripMenuItem"
        Me.ProcurarToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.ProcurarToolStripMenuItem.Text = "Procurar"
        '
        'LimparToolStripMenuItem
        '
        Me.LimparToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LimparToolStripMenuItem.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.LimparToolStripMenuItem.Name = "LimparToolStripMenuItem"
        Me.LimparToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.LimparToolStripMenuItem.Text = "Limpar"
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(746, 675)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabPrincipal)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmConfig"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração Geral"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPrincipal.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Tab2.ResumeLayout(False)
        Me.Tab2.PerformLayout()
        Me.Tab4.ResumeLayout(False)
        Me.Tab4.PerformLayout()
        CType(Me.picLogoColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogoMono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        Me.Tab3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Tab5.ResumeLayout(False)
        Me.Tab5.PerformLayout()
        CType(Me.dgvMensagens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.EProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuCFOP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents TabPrincipal As VIBlend.WinForms.Controls.vTabControl
    Friend WithEvents Tab1 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents Tab3 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Tab2 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents txtRazao As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFantasia As TextBox
    Friend WithEvents txtCNPJ As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIncricao As TextBox
    Friend WithEvents txtTelPrincipal As Controles.MaskText_Telefone
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtContatoGerencia As TextBox
    Friend WithEvents txtTelFinanceiro As Controles.MaskText_Telefone
    Friend WithEvents txtTelGerencia As Controles.MaskText_Telefone
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtContatoFinanceiro As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNaturalidade As TextBox
    Friend WithEvents txtUFPadrao As TextBox
    Friend WithEvents txtCidadePadrao As TextBox
    Friend WithEvents dtpDataPadrao As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtStringConexao As TextBox
    Friend WithEvents EProvider As ErrorProvider
    Friend WithEvents chkVerBackup As CheckBox
    Friend WithEvents Tab4 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents picLogoMono As PictureBox
    Friend WithEvents btnProcurarImagem As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label17 As Label
    Friend WithEvents txtLogoMonoCaminho As TextBox
    Friend WithEvents picLogoColor As PictureBox
    Friend WithEvents btnProcLogoColor As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label18 As Label
    Friend WithEvents txtLogoColorCaminho As TextBox
    Friend WithEvents menuCFOP As ContextMenuStrip
    Friend WithEvents ProcurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LimparToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtPermanencia As Controles.Text_SoNumeros
    Friend WithEvents Label21 As Label
    Friend WithEvents txtContaPadrao As TextBox
    Friend WithEvents txtFilialPadrao As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbtServRemoto As RadioButton
    Friend WithEvents rbtServLocal As RadioButton
    Friend WithEvents lblDataBloqueio As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtDescontoMaximo As Controles.Text_SoNumeros
    Friend WithEvents Label19 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEditarFilial As Button
    Friend WithEvents btnFilialAdd As Button
    Friend WithEvents btnAlteraFilial As Button
    Friend WithEvents btnContaAdd As Button
    Friend WithEvents btnAlteraConta As Button
    Friend WithEvents btnBDAnterior As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label23 As Label
    Friend WithEvents txtBDAnterior As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtUF As TextBox
    Friend WithEvents txtEndereco As TextBox
    Friend WithEvents txtBairro As TextBox
    Friend WithEvents txtCidade As TextBox
    Friend WithEvents txtCEP As Controles.MaskText_Telefone
    Friend WithEvents cmbEstoqueNegativo As Controles.ComboBox_OnlyValues
    Friend WithEvents Label29 As Label
    Friend WithEvents Tab5 As VIBlend.WinForms.Controls.vTabPage
    Friend WithEvents dgvMensagens As DataGridView
    Friend WithEvents clnMensagem As DataGridViewTextBoxColumn
    Friend WithEvents Label14 As Label
    Friend WithEvents btnPedidoFolder As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label30 As Label
    Friend WithEvents txtPedidoFolder As TextBox
End Class
