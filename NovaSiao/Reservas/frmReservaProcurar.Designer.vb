﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReservaProcurar
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
        Me.components = New System.ComponentModel.Container()
        Me.txtNomeCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.btnTipo = New VIBlend.WinForms.Controls.vButton()
        Me.txtProdutoTipo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnNova = New System.Windows.Forms.Button()
        Me.lblReservaAtiva = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.txtProduto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstListagem = New ComponentOwl.BetterListView.BetterListView()
        Me.clnIDReserva = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnReservaData = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnClienteNome = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnTelefoneA = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnTelefoneB = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnProduto = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnAutor = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnFornecedor = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnFabricante = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnProdutoTipo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.mnuReserva = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEditarReserva = New System.Windows.Forms.ToolStripMenuItem()
        Me.miExcluirReserva = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miAbrirPedido = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDesassociarDoPedido = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrintEtiquetas = New System.Windows.Forms.Button()
        Me.btnPrintListagem = New System.Windows.Forms.Button()
        Me.btnAlterarSituacao = New System.Windows.Forms.Button()
        Me.pnlAtivas = New VIBlend.WinForms.Controls.vPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuReserva.SuspendLayout()
        Me.pnlAtivas.Content.SuspendLayout()
        Me.pnlAtivas.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblFilial)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(1300, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Panel1.Controls.SetChildIndex(Me.Label6, 0)
        Me.Panel1.Controls.SetChildIndex(Me.lblFilial, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(1059, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(241, 50)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Reservas - Procurar"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNomeCliente
        '
        Me.txtNomeCliente.Location = New System.Drawing.Point(144, 127)
        Me.txtNomeCliente.Name = "txtNomeCliente"
        Me.txtNomeCliente.Size = New System.Drawing.Size(355, 27)
        Me.txtNomeCliente.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nome Cliente"
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFechar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnFechar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.Location = New System.Drawing.Point(1145, 628)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(143, 41)
        Me.btnFechar.TabIndex = 17
        Me.btnFechar.Text = "&Fechar"
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEditar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnEditar.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.btnEditar.Location = New System.Drawing.Point(847, 628)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(143, 41)
        Me.btnEditar.TabIndex = 15
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(1268, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 3
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'btnTipo
        '
        Me.btnTipo.AllowAnimations = True
        Me.btnTipo.BackColor = System.Drawing.Color.Transparent
        Me.btnTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTipo.Location = New System.Drawing.Point(354, 61)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.RoundedCornersMask = CType(15, Byte)
        Me.btnTipo.RoundedCornersRadius = 0
        Me.btnTipo.Size = New System.Drawing.Size(34, 27)
        Me.btnTipo.TabIndex = 3
        Me.btnTipo.TabStop = False
        Me.btnTipo.Text = "..."
        Me.btnTipo.UseCompatibleTextRendering = True
        Me.btnTipo.UseVisualStyleBackColor = False
        Me.btnTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtProdutoTipo
        '
        Me.txtProdutoTipo.Location = New System.Drawing.Point(144, 61)
        Me.txtProdutoTipo.Name = "txtProdutoTipo"
        Me.txtProdutoTipo.Size = New System.Drawing.Size(205, 27)
        Me.txtProdutoTipo.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(27, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Tipo de Produto"
        '
        'btnNova
        '
        Me.btnNova.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNova.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNova.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnNova.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnNova.Location = New System.Drawing.Point(996, 628)
        Me.btnNova.Name = "btnNova"
        Me.btnNova.Size = New System.Drawing.Size(143, 41)
        Me.btnNova.TabIndex = 16
        Me.btnNova.Text = "&Nova"
        Me.btnNova.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNova.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNova.UseVisualStyleBackColor = True
        '
        'lblReservaAtiva
        '
        Me.lblReservaAtiva.BackColor = System.Drawing.Color.Transparent
        Me.lblReservaAtiva.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblReservaAtiva.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReservaAtiva.Location = New System.Drawing.Point(0, 0)
        Me.lblReservaAtiva.Name = "lblReservaAtiva"
        Me.lblReservaAtiva.Size = New System.Drawing.Size(312, 30)
        Me.lblReservaAtiva.TabIndex = 18
        Me.lblReservaAtiva.Text = "Reservas Ativas"
        Me.lblReservaAtiva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSituacao
        '
        Me.lblSituacao.BackColor = System.Drawing.Color.Transparent
        Me.lblSituacao.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSituacao.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSituacao.Location = New System.Drawing.Point(0, 31)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(312, 28)
        Me.lblSituacao.TabIndex = 18
        Me.lblSituacao.Text = "Aguardando Pedido"
        Me.lblSituacao.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtProduto
        '
        Me.txtProduto.Location = New System.Drawing.Point(144, 94)
        Me.txtProduto.Name = "txtProduto"
        Me.txtProduto.Size = New System.Drawing.Size(355, 27)
        Me.txtProduto.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(79, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Produto"
        '
        'lblFilial
        '
        Me.lblFilial.BackColor = System.Drawing.Color.Transparent
        Me.lblFilial.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilial.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblFilial.Location = New System.Drawing.Point(7, 17)
        Me.lblFilial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Size = New System.Drawing.Size(204, 30)
        Me.lblFilial.TabIndex = 0
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(90, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Filial"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstListagem
        '
        Me.lstListagem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstListagem.BackColor = System.Drawing.Color.White
        Me.lstListagem.CheckBoxes = ComponentOwl.BetterListView.BetterListViewCheckBoxes.TwoState
        Me.lstListagem.Columns.Add(Me.clnIDReserva)
        Me.lstListagem.Columns.Add(Me.clnReservaData)
        Me.lstListagem.Columns.Add(Me.clnClienteNome)
        Me.lstListagem.Columns.Add(Me.clnTelefoneA)
        Me.lstListagem.Columns.Add(Me.clnTelefoneB)
        Me.lstListagem.Columns.Add(Me.clnProduto)
        Me.lstListagem.Columns.Add(Me.clnAutor)
        Me.lstListagem.Columns.Add(Me.clnFornecedor)
        Me.lstListagem.Columns.Add(Me.clnFabricante)
        Me.lstListagem.Columns.Add(Me.clnProdutoTipo)
        Me.lstListagem.ContextMenuStrip = Me.mnuReserva
        Me.lstListagem.Font = New System.Drawing.Font("Pathway Gothic One", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstListagem.ForeColorColumns = System.Drawing.Color.Black
        Me.lstListagem.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Sortable
        Me.lstListagem.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstListagem.Location = New System.Drawing.Point(12, 171)
        Me.lstListagem.MultiSelect = False
        Me.lstListagem.Name = "lstListagem"
        Me.lstListagem.Size = New System.Drawing.Size(1275, 444)
        Me.lstListagem.TabIndex = 11
        '
        'clnIDReserva
        '
        Me.clnIDReserva.AllowResize = False
        Me.clnIDReserva.ForeColor = System.Drawing.Color.Black
        Me.clnIDReserva.Name = "clnIDReserva"
        Me.clnIDReserva.Text = "ID"
        Me.clnIDReserva.Width = 70
        '
        'clnReservaData
        '
        Me.clnReservaData.AllowResize = False
        Me.clnReservaData.Name = "clnReservaData"
        Me.clnReservaData.Text = "Data"
        Me.clnReservaData.Width = 80
        '
        'clnClienteNome
        '
        Me.clnClienteNome.AllowResize = False
        Me.clnClienteNome.Name = "clnClienteNome"
        Me.clnClienteNome.Text = "Nome do Cliente"
        Me.clnClienteNome.Width = 150
        '
        'clnTelefoneA
        '
        Me.clnTelefoneA.AllowResize = False
        Me.clnTelefoneA.Name = "clnTelefoneA"
        Me.clnTelefoneA.Text = "Telefone"
        Me.clnTelefoneA.Width = 110
        '
        'clnTelefoneB
        '
        Me.clnTelefoneB.AllowResize = False
        Me.clnTelefoneB.Name = "clnTelefoneB"
        Me.clnTelefoneB.Text = "Celular"
        Me.clnTelefoneB.Width = 110
        '
        'clnProduto
        '
        Me.clnProduto.Name = "clnProduto"
        Me.clnProduto.Text = "Produto"
        '
        'clnAutor
        '
        Me.clnAutor.Name = "clnAutor"
        Me.clnAutor.Text = "Autor"
        '
        'clnFornecedor
        '
        Me.clnFornecedor.Name = "clnFornecedor"
        Me.clnFornecedor.Text = "Fornecedor"
        '
        'clnFabricante
        '
        Me.clnFabricante.Name = "clnFabricante"
        Me.clnFabricante.Text = "Fabricante"
        '
        'clnProdutoTipo
        '
        Me.clnProdutoTipo.Name = "clnProdutoTipo"
        Me.clnProdutoTipo.Text = "Tipo de Produto"
        '
        'mnuReserva
        '
        Me.mnuReserva.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuReserva.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEditarReserva, Me.miExcluirReserva, Me.ToolStripSeparator1, Me.miAbrirPedido, Me.miDesassociarDoPedido})
        Me.mnuReserva.Name = "mnuReserva"
        Me.mnuReserva.Size = New System.Drawing.Size(215, 98)
        '
        'miEditarReserva
        '
        Me.miEditarReserva.Image = Global.NovaSiao.My.Resources.Resources.editar
        Me.miEditarReserva.Name = "miEditarReserva"
        Me.miEditarReserva.Size = New System.Drawing.Size(214, 22)
        Me.miEditarReserva.Text = "Editar Reserva"
        '
        'miExcluirReserva
        '
        Me.miExcluirReserva.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.miExcluirReserva.Name = "miExcluirReserva"
        Me.miExcluirReserva.Size = New System.Drawing.Size(214, 22)
        Me.miExcluirReserva.Text = "Excluir Reserva"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(211, 6)
        '
        'miAbrirPedido
        '
        Me.miAbrirPedido.Image = Global.NovaSiao.My.Resources.Resources.full_page
        Me.miAbrirPedido.Name = "miAbrirPedido"
        Me.miAbrirPedido.Size = New System.Drawing.Size(214, 22)
        Me.miAbrirPedido.Text = "Abrir Pedido"
        '
        'miDesassociarDoPedido
        '
        Me.miDesassociarDoPedido.Image = Global.NovaSiao.My.Resources.Resources.delete_page_24px
        Me.miDesassociarDoPedido.Name = "miDesassociarDoPedido"
        Me.miDesassociarDoPedido.Size = New System.Drawing.Size(214, 22)
        Me.miDesassociarDoPedido.Text = "Desassociar do Pedido"
        '
        'btnPrintEtiquetas
        '
        Me.btnPrintEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintEtiquetas.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPrintEtiquetas.Enabled = False
        Me.btnPrintEtiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrintEtiquetas.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnPrintEtiquetas.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.btnPrintEtiquetas.Location = New System.Drawing.Point(185, 628)
        Me.btnPrintEtiquetas.Name = "btnPrintEtiquetas"
        Me.btnPrintEtiquetas.Size = New System.Drawing.Size(121, 41)
        Me.btnPrintEtiquetas.TabIndex = 13
        Me.btnPrintEtiquetas.Text = "Etiquetas"
        Me.btnPrintEtiquetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintEtiquetas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintEtiquetas.UseVisualStyleBackColor = True
        '
        'btnPrintListagem
        '
        Me.btnPrintListagem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintListagem.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPrintListagem.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrintListagem.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnPrintListagem.Image = Global.NovaSiao.My.Resources.Resources.print
        Me.btnPrintListagem.Location = New System.Drawing.Point(312, 628)
        Me.btnPrintListagem.Name = "btnPrintListagem"
        Me.btnPrintListagem.Size = New System.Drawing.Size(121, 41)
        Me.btnPrintListagem.TabIndex = 14
        Me.btnPrintListagem.Text = "Listagem"
        Me.btnPrintListagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintListagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintListagem.UseVisualStyleBackColor = True
        '
        'btnAlterarSituacao
        '
        Me.btnAlterarSituacao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAlterarSituacao.BackColor = System.Drawing.Color.SeaShell
        Me.btnAlterarSituacao.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAlterarSituacao.Enabled = False
        Me.btnAlterarSituacao.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.btnAlterarSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlterarSituacao.ForeColor = System.Drawing.Color.DarkRed
        Me.btnAlterarSituacao.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnAlterarSituacao.Location = New System.Drawing.Point(12, 628)
        Me.btnAlterarSituacao.Name = "btnAlterarSituacao"
        Me.btnAlterarSituacao.Size = New System.Drawing.Size(167, 41)
        Me.btnAlterarSituacao.TabIndex = 13
        Me.btnAlterarSituacao.Text = "&Alterar Situação"
        Me.btnAlterarSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlterarSituacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAlterarSituacao.UseVisualStyleBackColor = False
        '
        'pnlAtivas
        '
        Me.pnlAtivas.AllowAnimations = True
        Me.pnlAtivas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlAtivas.BorderRadius = 0
        '
        'pnlAtivas.Content
        '
        Me.pnlAtivas.Content.AutoScroll = True
        Me.pnlAtivas.Content.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlAtivas.Content.Controls.Add(Me.lblSituacao)
        Me.pnlAtivas.Content.Controls.Add(Me.lblReservaAtiva)
        Me.pnlAtivas.Content.Location = New System.Drawing.Point(1, 1)
        Me.pnlAtivas.Content.Name = "Content"
        Me.pnlAtivas.Content.Size = New System.Drawing.Size(312, 59)
        Me.pnlAtivas.Content.TabIndex = 3
        Me.pnlAtivas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlAtivas.CustomScrollersIntersectionColor = System.Drawing.Color.Empty
        Me.pnlAtivas.Location = New System.Drawing.Point(973, 64)
        Me.pnlAtivas.Name = "pnlAtivas"
        Me.pnlAtivas.Opacity = 1.0!
        Me.pnlAtivas.PanelBorderColor = System.Drawing.Color.Transparent
        Me.pnlAtivas.Size = New System.Drawing.Size(314, 61)
        Me.pnlAtivas.TabIndex = 18
        Me.pnlAtivas.Text = "VPanel1"
        Me.pnlAtivas.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(510, 642)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 15)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Vinculada ao Pedido"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.BackColor = System.Drawing.Color.PeachPuff
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(484, 639)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.TabIndex = 19
        Me.PictureBox4.TabStop = False
        '
        'frmReservaProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(1300, 680)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.pnlAtivas)
        Me.Controls.Add(Me.lstListagem)
        Me.Controls.Add(Me.txtProduto)
        Me.Controls.Add(Me.btnTipo)
        Me.Controls.Add(Me.txtProdutoTipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnNova)
        Me.Controls.Add(Me.btnPrintListagem)
        Me.Controls.Add(Me.btnAlterarSituacao)
        Me.Controls.Add(Me.btnPrintEtiquetas)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNomeCliente)
        Me.KeyPreview = True
        Me.Name = "frmReservaProcurar"
        Me.Text = "Procurar Saída de Produto"
        Me.Controls.SetChildIndex(Me.txtNomeCliente, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnEditar, 0)
        Me.Controls.SetChildIndex(Me.btnPrintEtiquetas, 0)
        Me.Controls.SetChildIndex(Me.btnAlterarSituacao, 0)
        Me.Controls.SetChildIndex(Me.btnPrintListagem, 0)
        Me.Controls.SetChildIndex(Me.btnNova, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtProdutoTipo, 0)
        Me.Controls.SetChildIndex(Me.btnTipo, 0)
        Me.Controls.SetChildIndex(Me.txtProduto, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lstListagem, 0)
        Me.Controls.SetChildIndex(Me.pnlAtivas, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuReserva.ResumeLayout(False)
        Me.pnlAtivas.Content.ResumeLayout(False)
        Me.pnlAtivas.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNomeCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents btnTipo As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtProdutoTipo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnNova As Button
    Friend WithEvents txtProduto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFilial As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lstListagem As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnIDReserva As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnReservaData As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnClienteNome As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnTelefoneA As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnTelefoneB As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnProduto As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnAutor As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnFornecedor As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnFabricante As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnProdutoTipo As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnPrintEtiquetas As Button
    Friend WithEvents btnPrintListagem As Button
    Friend WithEvents btnAlterarSituacao As Button
    Friend WithEvents lblSituacao As Label
    Friend WithEvents lblReservaAtiva As Label
    Friend WithEvents pnlAtivas As VIBlend.WinForms.Controls.vPanel
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents mnuReserva As ContextMenuStrip
    Friend WithEvents miEditarReserva As ToolStripMenuItem
    Friend WithEvents miExcluirReserva As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miAbrirPedido As ToolStripMenuItem
    Friend WithEvents miDesassociarDoPedido As ToolStripMenuItem
End Class
