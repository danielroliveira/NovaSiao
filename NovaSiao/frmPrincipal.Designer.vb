<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
		Me.tsPrincipal = New System.Windows.Forms.ToolStrip()
		Me.tsbClientes = New System.Windows.Forms.ToolStripSplitButton()
		Me.miClienteNovo = New System.Windows.Forms.ToolStripMenuItem()
		Me.miClientePFInserir = New System.Windows.Forms.ToolStripMenuItem()
		Me.miClientePJInserir = New System.Windows.Forms.ToolStripMenuItem()
		Me.miClienteProcurar = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.miClientesSimples = New System.Windows.Forms.ToolStripMenuItem()
		Me.miCartasClientes = New System.Windows.Forms.ToolStripMenuItem()
		Me.miGerarParaAniversariantes = New System.Windows.Forms.ToolStripMenuItem()
		Me.miEnvioMalaDiretaImpressão = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsbCadastros = New System.Windows.Forms.ToolStripSplitButton()
		Me.miFuncionarios = New System.Windows.Forms.ToolStripMenuItem()
		Me.miTransportadoras = New System.Windows.Forms.ToolStripMenuItem()
		Me.miFornecedores = New System.Windows.Forms.ToolStripMenuItem()
		Me.miCredores = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsbProdutos = New System.Windows.Forms.ToolStripSplitButton()
		Me.miProdutoNovo = New System.Windows.Forms.ToolStripMenuItem()
		Me.miEditarProduto = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.miProdutoListagem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.miProdutoTipos = New System.Windows.Forms.ToolStripMenuItem()
		Me.miFabricantesMarcas = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
		Me.miProdutoEtiquetaVenda = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
		Me.miControleDeEstoque = New System.Windows.Forms.ToolStripMenuItem()
		Me.miAjusteEstoque = New System.Windows.Forms.ToolStripMenuItem()
		Me.miProcurarAjusteDeEstoque = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
		Me.miEstoqueInicial = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
		Me.tsbVendas = New System.Windows.Forms.ToolStripSplitButton()
		Me.miNovaVendaVista = New System.Windows.Forms.ToolStripMenuItem()
		Me.miNovaVendaPrazo = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
		Me.miNovaSimplesSaida = New System.Windows.Forms.ToolStripMenuItem()
		Me.miNovaDevolucaoSaida = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.miProcurarOperacaoSaida = New System.Windows.Forms.ToolStripMenuItem()
		Me.miProcurarTroca = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsbCompras = New System.Windows.Forms.ToolStripSplitButton()
		Me.miNovaCompra = New System.Windows.Forms.ToolStripMenuItem()
		Me.miNovaCompraNormal = New System.Windows.Forms.ToolStripMenuItem()
		Me.miNovaCompraNFeXML = New System.Windows.Forms.ToolStripMenuItem()
		Me.miSimplesEntrada = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
		Me.miProcurarOperacaoEntrada = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
		Me.miNovaReserva = New System.Windows.Forms.ToolStripMenuItem()
		Me.miProcurarReserva = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
		Me.miControleDePedidos = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
		Me.tsbAReceber = New System.Windows.Forms.ToolStripSplitButton()
		Me.miAReceberCliente = New System.Windows.Forms.ToolStripMenuItem()
		Me.miAReceberMovInterna = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsbAPagar = New System.Windows.Forms.ToolStripSplitButton()
		Me.miNovaDespesa = New System.Windows.Forms.ToolStripMenuItem()
		Me.miNovaDespesaQuitada = New System.Windows.Forms.ToolStripMenuItem()
		Me.miProcurarDespesa = New System.Windows.Forms.ToolStripMenuItem()
		Me.miTipoDeDespesa = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
		Me.miAPagarProcurar = New System.Windows.Forms.ToolStripMenuItem()
		Me.miAPagarMovInterna = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
		Me.miDespesasPeriodicas = New System.Windows.Forms.ToolStripMenuItem()
		Me.miFretes = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsbCaixa = New System.Windows.Forms.ToolStripSplitButton()
		Me.miProcurarCaixa = New System.Windows.Forms.ToolStripMenuItem()
		Me.miFinalizarCaixa = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
		Me.miTransferencias = New System.Windows.Forms.ToolStripMenuItem()
		Me.miContas = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
		Me.miFormasDeMovimentacao = New System.Windows.Forms.ToolStripMenuItem()
		Me.miControlesMovimentacao = New System.Windows.Forms.ToolStripMenuItem()
		Me.miTiposDeMovimentacao = New System.Windows.Forms.ToolStripMenuItem()
		Me.miTiposDeCartao = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
		Me.tsbConfig = New System.Windows.Forms.ToolStripSplitButton()
		Me.miConfiguracaoDataPadrao = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
		Me.miConfiguracaoSistema = New System.Windows.Forms.ToolStripMenuItem()
		Me.miCFOP = New System.Windows.Forms.ToolStripMenuItem()
		Me.miEmailServer = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.miConfiguracaoUsuarios = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
		Me.miFazerBackup = New System.Windows.Forms.ToolStripMenuItem()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.lblInfoMessage = New System.Windows.Forms.Label()
		Me.btnMinimizer = New System.Windows.Forms.Button()
		Me.lblTituloGeral = New System.Windows.Forms.Label()
		Me.SContainerPrincipal = New System.Windows.Forms.SplitContainer()
		Me.btnSair = New System.Windows.Forms.Button()
		Me.PainelInferior = New System.Windows.Forms.Panel()
		Me.lblConta = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.lblVersao = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblFilial = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lblDataSis = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblHora = New System.Windows.Forms.Label()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.miOutrasConfigurações = New System.Windows.Forms.ToolStripMenuItem()
		Me.miAtividadesDosClientes = New System.Windows.Forms.ToolStripMenuItem()
		Me.miPlanosDeParcelamento = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsPrincipal.SuspendLayout()
		Me.Panel1.SuspendLayout()
		CType(Me.SContainerPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SContainerPrincipal.Panel1.SuspendLayout()
		Me.SContainerPrincipal.Panel2.SuspendLayout()
		Me.SContainerPrincipal.SuspendLayout()
		Me.PainelInferior.SuspendLayout()
		Me.SuspendLayout()
		'
		'tsPrincipal
		'
		Me.tsPrincipal.AutoSize = False
		Me.tsPrincipal.BackColor = System.Drawing.Color.Transparent
		Me.tsPrincipal.Dock = System.Windows.Forms.DockStyle.None
		Me.tsPrincipal.Font = New System.Drawing.Font("Calibri", 12.0!)
		Me.tsPrincipal.ImageScalingSize = New System.Drawing.Size(60, 60)
		Me.tsPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbClientes, Me.tsbCadastros, Me.tsbProdutos, Me.ToolStripSeparator12, Me.tsbVendas, Me.tsbCompras, Me.ToolStripSeparator13, Me.tsbAReceber, Me.tsbAPagar, Me.tsbCaixa, Me.ToolStripSeparator14, Me.tsbConfig})
		Me.tsPrincipal.Location = New System.Drawing.Point(0, 4)
		Me.tsPrincipal.Name = "tsPrincipal"
		Me.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.tsPrincipal.Size = New System.Drawing.Size(806, 67)
		Me.tsPrincipal.TabIndex = 0
		Me.tsPrincipal.TabStop = True
		Me.tsPrincipal.Text = "Menu Principal"
		'
		'tsbClientes
		'
		Me.tsbClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.tsbClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbClientes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miClienteNovo, Me.miClienteProcurar, Me.ToolStripSeparator1, Me.miClientesSimples, Me.miCartasClientes})
		Me.tsbClientes.Image = Global.NovaSiao.My.Resources.Resources.Clientes
		Me.tsbClientes.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbClientes.Name = "tsbClientes"
		Me.tsbClientes.Size = New System.Drawing.Size(76, 64)
		Me.tsbClientes.Tag = "1"
		Me.tsbClientes.Text = "&Clientes"
		Me.tsbClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.tsbClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		'
		'miClienteNovo
		'
		Me.miClienteNovo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miClientePFInserir, Me.miClientePJInserir})
		Me.miClienteNovo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miClienteNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miClienteNovo.Name = "miClienteNovo"
		Me.miClienteNovo.Size = New System.Drawing.Size(213, 38)
		Me.miClienteNovo.Tag = "3"
		Me.miClienteNovo.Text = "Novo Cliente"
		'
		'miClientePFInserir
		'
		Me.miClientePFInserir.Image = Global.NovaSiao.My.Resources.Resources.Novo_PEQ
		Me.miClientePFInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miClientePFInserir.Name = "miClientePFInserir"
		Me.miClientePFInserir.Size = New System.Drawing.Size(242, 46)
		Me.miClientePFInserir.Text = "Cliente Pessoa Física"
		'
		'miClientePJInserir
		'
		Me.miClientePJInserir.Image = Global.NovaSiao.My.Resources.Resources.cliente_empresa
		Me.miClientePJInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miClientePJInserir.Name = "miClientePJInserir"
		Me.miClientePJInserir.ShowShortcutKeys = False
		Me.miClientePJInserir.Size = New System.Drawing.Size(242, 46)
		Me.miClientePJInserir.Text = "Cliente Pessoa Jurídica"
		'
		'miClienteProcurar
		'
		Me.miClienteProcurar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miClienteProcurar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miClienteProcurar.Name = "miClienteProcurar"
		Me.miClienteProcurar.Size = New System.Drawing.Size(213, 38)
		Me.miClienteProcurar.Tag = "3"
		Me.miClienteProcurar.Text = "Procurar Cliente"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(210, 6)
		'
		'miClientesSimples
		'
		Me.miClientesSimples.Image = Global.NovaSiao.My.Resources.Resources.Cliente_Ativo
		Me.miClientesSimples.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.miClientesSimples.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miClientesSimples.Name = "miClientesSimples"
		Me.miClientesSimples.Size = New System.Drawing.Size(213, 38)
		Me.miClientesSimples.Text = "Clientes Simples"
		'
		'miCartasClientes
		'
		Me.miCartasClientes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miGerarParaAniversariantes, Me.miEnvioMalaDiretaImpressão})
		Me.miCartasClientes.Image = Global.NovaSiao.My.Resources.Resources.mail
		Me.miCartasClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miCartasClientes.Name = "miCartasClientes"
		Me.miCartasClientes.Size = New System.Drawing.Size(213, 38)
		Me.miCartasClientes.Text = "Cartas e Etiquetas"
		'
		'miGerarParaAniversariantes
		'
		Me.miGerarParaAniversariantes.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miGerarParaAniversariantes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miGerarParaAniversariantes.Name = "miGerarParaAniversariantes"
		Me.miGerarParaAniversariantes.Size = New System.Drawing.Size(305, 36)
		Me.miGerarParaAniversariantes.Text = "Gerar Envio para Aniversariantes"
		'
		'miEnvioMalaDiretaImpressão
		'
		Me.miEnvioMalaDiretaImpressão.Image = Global.NovaSiao.My.Resources.Resources.Imprimir_PEQ
		Me.miEnvioMalaDiretaImpressão.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miEnvioMalaDiretaImpressão.Name = "miEnvioMalaDiretaImpressão"
		Me.miEnvioMalaDiretaImpressão.Size = New System.Drawing.Size(305, 36)
		Me.miEnvioMalaDiretaImpressão.Text = "Envio Mala Direta - Impressão"
		'
		'tsbCadastros
		'
		Me.tsbCadastros.AutoSize = False
		Me.tsbCadastros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbCadastros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFuncionarios, Me.miTransportadoras, Me.miFornecedores, Me.miCredores})
		Me.tsbCadastros.Image = Global.NovaSiao.My.Resources.Resources.Cadastros
		Me.tsbCadastros.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbCadastros.Name = "tsbCadastros"
		Me.tsbCadastros.Size = New System.Drawing.Size(76, 64)
		Me.tsbCadastros.Text = "&Cadastros"
		Me.tsbCadastros.ToolTipText = "Cadastros"
		'
		'miFuncionarios
		'
		Me.miFuncionarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.miFuncionarios.Font = New System.Drawing.Font("Calibri", 12.0!)
		Me.miFuncionarios.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miFuncionarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miFuncionarios.Name = "miFuncionarios"
		Me.miFuncionarios.Padding = New System.Windows.Forms.Padding(0)
		Me.miFuncionarios.Size = New System.Drawing.Size(191, 28)
		Me.miFuncionarios.Text = "Funcionários"
		Me.miFuncionarios.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
		Me.miFuncionarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
		'
		'miTransportadoras
		'
		Me.miTransportadoras.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miTransportadoras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miTransportadoras.Name = "miTransportadoras"
		Me.miTransportadoras.Size = New System.Drawing.Size(191, 30)
		Me.miTransportadoras.Text = "Transportadoras"
		'
		'miFornecedores
		'
		Me.miFornecedores.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miFornecedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miFornecedores.Name = "miFornecedores"
		Me.miFornecedores.Size = New System.Drawing.Size(191, 30)
		Me.miFornecedores.Text = "Fornecedores"
		'
		'miCredores
		'
		Me.miCredores.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miCredores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miCredores.Name = "miCredores"
		Me.miCredores.Size = New System.Drawing.Size(191, 30)
		Me.miCredores.Text = "Credores"
		'
		'tsbProdutos
		'
		Me.tsbProdutos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbProdutos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miProdutoNovo, Me.miEditarProduto, Me.ToolStripSeparator4, Me.miProdutoListagem, Me.ToolStripSeparator3, Me.miProdutoTipos, Me.miFabricantesMarcas, Me.ToolStripSeparator11, Me.miProdutoEtiquetaVenda, Me.ToolStripSeparator19, Me.miControleDeEstoque})
		Me.tsbProdutos.Image = Global.NovaSiao.My.Resources.Resources.livros_produtos
		Me.tsbProdutos.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbProdutos.Name = "tsbProdutos"
		Me.tsbProdutos.Size = New System.Drawing.Size(76, 64)
		Me.tsbProdutos.Text = "Produtos"
		'
		'miProdutoNovo
		'
		Me.miProdutoNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.miProdutoNovo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miProdutoNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProdutoNovo.Name = "miProdutoNovo"
		Me.miProdutoNovo.Size = New System.Drawing.Size(278, 38)
		Me.miProdutoNovo.Tag = "2"
		Me.miProdutoNovo.Text = "Novo Produto"
		'
		'miEditarProduto
		'
		Me.miEditarProduto.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miEditarProduto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miEditarProduto.Name = "miEditarProduto"
		Me.miEditarProduto.Size = New System.Drawing.Size(278, 38)
		Me.miEditarProduto.Text = "Editar Produto"
		'
		'ToolStripSeparator4
		'
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		Me.ToolStripSeparator4.Size = New System.Drawing.Size(275, 6)
		'
		'miProdutoListagem
		'
		Me.miProdutoListagem.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProdutoListagem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProdutoListagem.Name = "miProdutoListagem"
		Me.miProdutoListagem.Size = New System.Drawing.Size(278, 38)
		Me.miProdutoListagem.Tag = "3"
		Me.miProdutoListagem.Text = "Procurar e Alterar Produto"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(275, 6)
		'
		'miProdutoTipos
		'
		Me.miProdutoTipos.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miProdutoTipos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProdutoTipos.Name = "miProdutoTipos"
		Me.miProdutoTipos.Size = New System.Drawing.Size(278, 38)
		Me.miProdutoTipos.Text = "Tipos de Produtos - Controle"
		'
		'miFabricantesMarcas
		'
		Me.miFabricantesMarcas.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miFabricantesMarcas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miFabricantesMarcas.Name = "miFabricantesMarcas"
		Me.miFabricantesMarcas.Size = New System.Drawing.Size(278, 38)
		Me.miFabricantesMarcas.Text = "Fabricantes - Marcas"
		'
		'ToolStripSeparator11
		'
		Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
		Me.ToolStripSeparator11.Size = New System.Drawing.Size(275, 6)
		'
		'miProdutoEtiquetaVenda
		'
		Me.miProdutoEtiquetaVenda.Image = Global.NovaSiao.My.Resources.Resources.print
		Me.miProdutoEtiquetaVenda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProdutoEtiquetaVenda.Name = "miProdutoEtiquetaVenda"
		Me.miProdutoEtiquetaVenda.Size = New System.Drawing.Size(278, 38)
		Me.miProdutoEtiquetaVenda.Text = "Etiqueta de Venda"
		'
		'ToolStripSeparator19
		'
		Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
		Me.ToolStripSeparator19.Size = New System.Drawing.Size(275, 6)
		'
		'miControleDeEstoque
		'
		Me.miControleDeEstoque.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAjusteEstoque, Me.miProcurarAjusteDeEstoque, Me.ToolStripSeparator20, Me.miEstoqueInicial})
		Me.miControleDeEstoque.Image = Global.NovaSiao.My.Resources.Resources.Estoque_24px
		Me.miControleDeEstoque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miControleDeEstoque.Name = "miControleDeEstoque"
		Me.miControleDeEstoque.Size = New System.Drawing.Size(278, 38)
		Me.miControleDeEstoque.Text = "Controle de Estoque"
		'
		'miAjusteEstoque
		'
		Me.miAjusteEstoque.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miAjusteEstoque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miAjusteEstoque.Name = "miAjusteEstoque"
		Me.miAjusteEstoque.Size = New System.Drawing.Size(261, 30)
		Me.miAjusteEstoque.Text = "Novo Ajuste de Estoque"
		'
		'miProcurarAjusteDeEstoque
		'
		Me.miProcurarAjusteDeEstoque.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProcurarAjusteDeEstoque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProcurarAjusteDeEstoque.Name = "miProcurarAjusteDeEstoque"
		Me.miProcurarAjusteDeEstoque.Size = New System.Drawing.Size(261, 30)
		Me.miProcurarAjusteDeEstoque.Text = "Procurar Ajuste de Estoque"
		'
		'ToolStripSeparator20
		'
		Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
		Me.ToolStripSeparator20.Size = New System.Drawing.Size(258, 6)
		'
		'miEstoqueInicial
		'
		Me.miEstoqueInicial.Image = Global.NovaSiao.My.Resources.Resources.EstoqueEntradas_24px
		Me.miEstoqueInicial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miEstoqueInicial.Name = "miEstoqueInicial"
		Me.miEstoqueInicial.Size = New System.Drawing.Size(261, 30)
		Me.miEstoqueInicial.Text = "Estoque Inicial"
		'
		'ToolStripSeparator12
		'
		Me.ToolStripSeparator12.AutoSize = False
		Me.ToolStripSeparator12.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
		Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
		Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 50)
		'
		'tsbVendas
		'
		Me.tsbVendas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbVendas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNovaVendaVista, Me.miNovaVendaPrazo, Me.ToolStripSeparator18, Me.miNovaSimplesSaida, Me.miNovaDevolucaoSaida, Me.ToolStripSeparator5, Me.miProcurarOperacaoSaida, Me.miProcurarTroca})
		Me.tsbVendas.Image = CType(resources.GetObject("tsbVendas.Image"), System.Drawing.Image)
		Me.tsbVendas.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbVendas.Name = "tsbVendas"
		Me.tsbVendas.Size = New System.Drawing.Size(76, 64)
		Me.tsbVendas.Text = "Saída de Produtos"
		'
		'miNovaVendaVista
		'
		Me.miNovaVendaVista.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaVendaVista.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaVendaVista.Name = "miNovaVendaVista"
		Me.miNovaVendaVista.Size = New System.Drawing.Size(234, 30)
		Me.miNovaVendaVista.Text = "Nova Venda à Vista"
		'
		'miNovaVendaPrazo
		'
		Me.miNovaVendaPrazo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaVendaPrazo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaVendaPrazo.Name = "miNovaVendaPrazo"
		Me.miNovaVendaPrazo.Size = New System.Drawing.Size(234, 30)
		Me.miNovaVendaPrazo.Text = "Nova Venda à Prazo"
		'
		'ToolStripSeparator18
		'
		Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
		Me.ToolStripSeparator18.Size = New System.Drawing.Size(231, 6)
		'
		'miNovaSimplesSaida
		'
		Me.miNovaSimplesSaida.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaSimplesSaida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaSimplesSaida.Name = "miNovaSimplesSaida"
		Me.miNovaSimplesSaida.Size = New System.Drawing.Size(234, 30)
		Me.miNovaSimplesSaida.Text = "Nova Simples Saída"
		'
		'miNovaDevolucaoSaida
		'
		Me.miNovaDevolucaoSaida.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaDevolucaoSaida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaDevolucaoSaida.Name = "miNovaDevolucaoSaida"
		Me.miNovaDevolucaoSaida.Size = New System.Drawing.Size(234, 30)
		Me.miNovaDevolucaoSaida.Text = "Nova Devolução"
		'
		'ToolStripSeparator5
		'
		Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
		Me.ToolStripSeparator5.Size = New System.Drawing.Size(231, 6)
		'
		'miProcurarOperacaoSaida
		'
		Me.miProcurarOperacaoSaida.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProcurarOperacaoSaida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProcurarOperacaoSaida.Name = "miProcurarOperacaoSaida"
		Me.miProcurarOperacaoSaida.Size = New System.Drawing.Size(234, 30)
		Me.miProcurarOperacaoSaida.Text = "Procurar Venda | Saída"
		'
		'miProcurarTroca
		'
		Me.miProcurarTroca.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProcurarTroca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProcurarTroca.Name = "miProcurarTroca"
		Me.miProcurarTroca.Size = New System.Drawing.Size(234, 30)
		Me.miProcurarTroca.Text = "Procurar Troca"
		'
		'tsbCompras
		'
		Me.tsbCompras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbCompras.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNovaCompra, Me.miSimplesEntrada, Me.ToolStripSeparator6, Me.miProcurarOperacaoEntrada, Me.ToolStripSeparator16, Me.miNovaReserva, Me.miProcurarReserva, Me.ToolStripSeparator17, Me.miControleDePedidos})
		Me.tsbCompras.Image = Global.NovaSiao.My.Resources.Resources.compras_entradas
		Me.tsbCompras.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbCompras.Name = "tsbCompras"
		Me.tsbCompras.Size = New System.Drawing.Size(76, 64)
		Me.tsbCompras.Text = "Entrada de Produtos"
		'
		'miNovaCompra
		'
		Me.miNovaCompra.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNovaCompraNormal, Me.miNovaCompraNFeXML})
		Me.miNovaCompra.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaCompra.Name = "miNovaCompra"
		Me.miNovaCompra.Size = New System.Drawing.Size(259, 30)
		Me.miNovaCompra.Text = "Nova Compra"
		'
		'miNovaCompraNormal
		'
		Me.miNovaCompraNormal.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miNovaCompraNormal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaCompraNormal.Name = "miNovaCompraNormal"
		Me.miNovaCompraNormal.Size = New System.Drawing.Size(168, 30)
		Me.miNovaCompraNormal.Text = "Normal"
		'
		'miNovaCompraNFeXML
		'
		Me.miNovaCompraNFeXML.Image = Global.NovaSiao.My.Resources.Resources.download
		Me.miNovaCompraNFeXML.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaCompraNFeXML.Name = "miNovaCompraNFeXML"
		Me.miNovaCompraNFeXML.Size = New System.Drawing.Size(168, 30)
		Me.miNovaCompraNFeXML.Text = "Por NFe XML"
		'
		'miSimplesEntrada
		'
		Me.miSimplesEntrada.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miSimplesEntrada.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miSimplesEntrada.Name = "miSimplesEntrada"
		Me.miSimplesEntrada.Size = New System.Drawing.Size(259, 30)
		Me.miSimplesEntrada.Text = "Simples Entrada"
		'
		'ToolStripSeparator6
		'
		Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
		Me.ToolStripSeparator6.Size = New System.Drawing.Size(256, 6)
		'
		'miProcurarOperacaoEntrada
		'
		Me.miProcurarOperacaoEntrada.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProcurarOperacaoEntrada.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProcurarOperacaoEntrada.Name = "miProcurarOperacaoEntrada"
		Me.miProcurarOperacaoEntrada.Size = New System.Drawing.Size(259, 30)
		Me.miProcurarOperacaoEntrada.Text = "Procurar Compra | Entrada"
		'
		'ToolStripSeparator16
		'
		Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
		Me.ToolStripSeparator16.Size = New System.Drawing.Size(256, 6)
		'
		'miNovaReserva
		'
		Me.miNovaReserva.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaReserva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaReserva.Name = "miNovaReserva"
		Me.miNovaReserva.Size = New System.Drawing.Size(259, 30)
		Me.miNovaReserva.Text = "Nova Reserva"
		'
		'miProcurarReserva
		'
		Me.miProcurarReserva.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProcurarReserva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProcurarReserva.Name = "miProcurarReserva"
		Me.miProcurarReserva.Size = New System.Drawing.Size(259, 30)
		Me.miProcurarReserva.Text = "Procurar Reserva"
		'
		'ToolStripSeparator17
		'
		Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
		Me.ToolStripSeparator17.Size = New System.Drawing.Size(256, 6)
		'
		'miControleDePedidos
		'
		Me.miControleDePedidos.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miControleDePedidos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miControleDePedidos.Name = "miControleDePedidos"
		Me.miControleDePedidos.Size = New System.Drawing.Size(259, 30)
		Me.miControleDePedidos.Text = "Controle de Pedidos"
		'
		'ToolStripSeparator13
		'
		Me.ToolStripSeparator13.AutoSize = False
		Me.ToolStripSeparator13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
		Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
		Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 50)
		'
		'tsbAReceber
		'
		Me.tsbAReceber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbAReceber.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAReceberCliente, Me.miAReceberMovInterna})
		Me.tsbAReceber.Image = Global.NovaSiao.My.Resources.Resources.AReceber
		Me.tsbAReceber.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbAReceber.Name = "tsbAReceber"
		Me.tsbAReceber.Size = New System.Drawing.Size(76, 64)
		Me.tsbAReceber.Text = "A Receber"
		'
		'miAReceberCliente
		'
		Me.miAReceberCliente.Image = CType(resources.GetObject("miAReceberCliente.Image"), System.Drawing.Image)
		Me.miAReceberCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miAReceberCliente.Name = "miAReceberCliente"
		Me.miAReceberCliente.Size = New System.Drawing.Size(252, 36)
		Me.miAReceberCliente.Text = "A Receber por Cliente"
		'
		'miAReceberMovInterna
		'
		Me.miAReceberMovInterna.Image = CType(resources.GetObject("miAReceberMovInterna.Image"), System.Drawing.Image)
		Me.miAReceberMovInterna.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miAReceberMovInterna.Name = "miAReceberMovInterna"
		Me.miAReceberMovInterna.Size = New System.Drawing.Size(252, 36)
		Me.miAReceberMovInterna.Text = "A Receber - Mov. Interna"
		'
		'tsbAPagar
		'
		Me.tsbAPagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbAPagar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNovaDespesa, Me.miNovaDespesaQuitada, Me.miProcurarDespesa, Me.miTipoDeDespesa, Me.ToolStripSeparator8, Me.miAPagarProcurar, Me.miAPagarMovInterna, Me.ToolStripSeparator21, Me.miDespesasPeriodicas, Me.miFretes})
		Me.tsbAPagar.Image = Global.NovaSiao.My.Resources.Resources.APagar
		Me.tsbAPagar.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbAPagar.Name = "tsbAPagar"
		Me.tsbAPagar.Size = New System.Drawing.Size(76, 64)
		Me.tsbAPagar.Text = "A Pagar | Despesas"
		'
		'miNovaDespesa
		'
		Me.miNovaDespesa.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaDespesa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaDespesa.Name = "miNovaDespesa"
		Me.miNovaDespesa.Size = New System.Drawing.Size(241, 36)
		Me.miNovaDespesa.Text = "Nova Despesa"
		'
		'miNovaDespesaQuitada
		'
		Me.miNovaDespesaQuitada.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miNovaDespesaQuitada.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miNovaDespesaQuitada.Name = "miNovaDespesaQuitada"
		Me.miNovaDespesaQuitada.Size = New System.Drawing.Size(241, 36)
		Me.miNovaDespesaQuitada.Text = "Nova Despesa Quitada"
		'
		'miProcurarDespesa
		'
		Me.miProcurarDespesa.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProcurarDespesa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProcurarDespesa.Name = "miProcurarDespesa"
		Me.miProcurarDespesa.Size = New System.Drawing.Size(241, 36)
		Me.miProcurarDespesa.Text = "Procurar Despesa"
		'
		'miTipoDeDespesa
		'
		Me.miTipoDeDespesa.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miTipoDeDespesa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miTipoDeDespesa.Name = "miTipoDeDespesa"
		Me.miTipoDeDespesa.Size = New System.Drawing.Size(241, 36)
		Me.miTipoDeDespesa.Text = "Tipos de Despesa"
		'
		'ToolStripSeparator8
		'
		Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
		Me.ToolStripSeparator8.Size = New System.Drawing.Size(238, 6)
		'
		'miAPagarProcurar
		'
		Me.miAPagarProcurar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miAPagarProcurar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miAPagarProcurar.Name = "miAPagarProcurar"
		Me.miAPagarProcurar.Size = New System.Drawing.Size(241, 36)
		Me.miAPagarProcurar.Text = "A Pagar Procurar"
		'
		'miAPagarMovInterna
		'
		Me.miAPagarMovInterna.Image = Global.NovaSiao.My.Resources.Resources.APagar_30px
		Me.miAPagarMovInterna.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miAPagarMovInterna.Name = "miAPagarMovInterna"
		Me.miAPagarMovInterna.Size = New System.Drawing.Size(241, 36)
		Me.miAPagarMovInterna.Text = "A Pagar - Mov. Interna"
		'
		'ToolStripSeparator21
		'
		Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
		Me.ToolStripSeparator21.Size = New System.Drawing.Size(238, 6)
		'
		'miDespesasPeriodicas
		'
		Me.miDespesasPeriodicas.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miDespesasPeriodicas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miDespesasPeriodicas.Name = "miDespesasPeriodicas"
		Me.miDespesasPeriodicas.Size = New System.Drawing.Size(241, 36)
		Me.miDespesasPeriodicas.Text = "Despesas Periódicas"
		'
		'miFretes
		'
		Me.miFretes.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miFretes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miFretes.Name = "miFretes"
		Me.miFretes.Size = New System.Drawing.Size(241, 36)
		Me.miFretes.Text = "Fretes"
		'
		'tsbCaixa
		'
		Me.tsbCaixa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbCaixa.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miProcurarCaixa, Me.miFinalizarCaixa, Me.ToolStripSeparator10, Me.miTransferencias, Me.miContas, Me.ToolStripSeparator9, Me.miFormasDeMovimentacao, Me.miControlesMovimentacao})
		Me.tsbCaixa.Image = Global.NovaSiao.My.Resources.Resources.Caixa
		Me.tsbCaixa.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbCaixa.Name = "tsbCaixa"
		Me.tsbCaixa.Size = New System.Drawing.Size(76, 64)
		Me.tsbCaixa.Text = "Caixa | Fechamento"
		'
		'miProcurarCaixa
		'
		Me.miProcurarCaixa.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miProcurarCaixa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miProcurarCaixa.Name = "miProcurarCaixa"
		Me.miProcurarCaixa.Size = New System.Drawing.Size(276, 38)
		Me.miProcurarCaixa.Text = "Procurar Caixa"
		'
		'miFinalizarCaixa
		'
		Me.miFinalizarCaixa.Image = Global.NovaSiao.My.Resources.Resources.accept
		Me.miFinalizarCaixa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miFinalizarCaixa.Name = "miFinalizarCaixa"
		Me.miFinalizarCaixa.Size = New System.Drawing.Size(276, 38)
		Me.miFinalizarCaixa.Text = "Finalizar Caixa"
		'
		'ToolStripSeparator10
		'
		Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
		Me.ToolStripSeparator10.Size = New System.Drawing.Size(273, 6)
		'
		'miTransferencias
		'
		Me.miTransferencias.Image = Global.NovaSiao.My.Resources.Resources.refresh1
		Me.miTransferencias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miTransferencias.Name = "miTransferencias"
		Me.miTransferencias.Size = New System.Drawing.Size(276, 38)
		Me.miTransferencias.Text = "Transferências entre Contas"
		'
		'miContas
		'
		Me.miContas.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miContas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miContas.Name = "miContas"
		Me.miContas.Size = New System.Drawing.Size(276, 38)
		Me.miContas.Text = "Manutenção de Contas"
		'
		'ToolStripSeparator9
		'
		Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
		Me.ToolStripSeparator9.Size = New System.Drawing.Size(273, 6)
		'
		'miFormasDeMovimentacao
		'
		Me.miFormasDeMovimentacao.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miFormasDeMovimentacao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miFormasDeMovimentacao.Name = "miFormasDeMovimentacao"
		Me.miFormasDeMovimentacao.Size = New System.Drawing.Size(276, 38)
		Me.miFormasDeMovimentacao.Text = "Formas de Movimentação"
		'
		'miControlesMovimentacao
		'
		Me.miControlesMovimentacao.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miTiposDeMovimentacao, Me.miTiposDeCartao})
		Me.miControlesMovimentacao.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
		Me.miControlesMovimentacao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miControlesMovimentacao.Name = "miControlesMovimentacao"
		Me.miControlesMovimentacao.Size = New System.Drawing.Size(276, 38)
		Me.miControlesMovimentacao.Text = "Controles de Movimentação"
		'
		'miTiposDeMovimentacao
		'
		Me.miTiposDeMovimentacao.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miTiposDeMovimentacao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miTiposDeMovimentacao.Name = "miTiposDeMovimentacao"
		Me.miTiposDeMovimentacao.Size = New System.Drawing.Size(241, 30)
		Me.miTiposDeMovimentacao.Text = "Tipos de Movimentação"
		'
		'miTiposDeCartao
		'
		Me.miTiposDeCartao.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
		Me.miTiposDeCartao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miTiposDeCartao.Name = "miTiposDeCartao"
		Me.miTiposDeCartao.Size = New System.Drawing.Size(241, 30)
		Me.miTiposDeCartao.Text = "Tipos de Cartão"
		'
		'ToolStripSeparator14
		'
		Me.ToolStripSeparator14.AutoSize = False
		Me.ToolStripSeparator14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
		Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
		Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 50)
		'
		'tsbConfig
		'
		Me.tsbConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.tsbConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miConfiguracaoDataPadrao, Me.ToolStripSeparator7, Me.miConfiguracaoSistema, Me.miCFOP, Me.miEmailServer, Me.miOutrasConfigurações, Me.ToolStripSeparator2, Me.miConfiguracaoUsuarios, Me.ToolStripSeparator15, Me.miFazerBackup})
		Me.tsbConfig.Image = Global.NovaSiao.My.Resources.Resources.Controles
		Me.tsbConfig.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbConfig.Name = "tsbConfig"
		Me.tsbConfig.Size = New System.Drawing.Size(76, 64)
		Me.tsbConfig.Tag = "1"
		Me.tsbConfig.Text = "Controles"
		Me.tsbConfig.ToolTipText = "Configuração e Controles"
		'
		'miConfiguracaoDataPadrao
		'
		Me.miConfiguracaoDataPadrao.Image = Global.NovaSiao.My.Resources.Resources.calendar
		Me.miConfiguracaoDataPadrao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miConfiguracaoDataPadrao.Name = "miConfiguracaoDataPadrao"
		Me.miConfiguracaoDataPadrao.Size = New System.Drawing.Size(246, 30)
		Me.miConfiguracaoDataPadrao.Tag = "3"
		Me.miConfiguracaoDataPadrao.Text = "Conta | Data Padrão"
		'
		'ToolStripSeparator7
		'
		Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
		Me.ToolStripSeparator7.Size = New System.Drawing.Size(243, 6)
		'
		'miConfiguracaoSistema
		'
		Me.miConfiguracaoSistema.Image = Global.NovaSiao.My.Resources.Resources.Controles_24x24
		Me.miConfiguracaoSistema.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miConfiguracaoSistema.Name = "miConfiguracaoSistema"
		Me.miConfiguracaoSistema.Size = New System.Drawing.Size(246, 30)
		Me.miConfiguracaoSistema.Tag = "1"
		Me.miConfiguracaoSistema.Text = "Configuração do Sistema"
		'
		'miCFOP
		'
		Me.miCFOP.Image = Global.NovaSiao.My.Resources.Resources.Controles_24x24
		Me.miCFOP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miCFOP.Name = "miCFOP"
		Me.miCFOP.Size = New System.Drawing.Size(246, 30)
		Me.miCFOP.Text = "CFOP das Operações"
		'
		'miEmailServer
		'
		Me.miEmailServer.Image = Global.NovaSiao.My.Resources.Resources.Controles_24x24
		Me.miEmailServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miEmailServer.Name = "miEmailServer"
		Me.miEmailServer.Size = New System.Drawing.Size(246, 30)
		Me.miEmailServer.Text = "Configuração do Email"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(243, 6)
		'
		'miConfiguracaoUsuarios
		'
		Me.miConfiguracaoUsuarios.Image = Global.NovaSiao.My.Resources.Resources.users
		Me.miConfiguracaoUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miConfiguracaoUsuarios.Name = "miConfiguracaoUsuarios"
		Me.miConfiguracaoUsuarios.Size = New System.Drawing.Size(246, 30)
		Me.miConfiguracaoUsuarios.Tag = "1"
		Me.miConfiguracaoUsuarios.Text = "Usuários"
		'
		'ToolStripSeparator15
		'
		Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
		Me.ToolStripSeparator15.Size = New System.Drawing.Size(243, 6)
		'
		'miFazerBackup
		'
		Me.miFazerBackup.Image = Global.NovaSiao.My.Resources.Resources.Backup_ICO
		Me.miFazerBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miFazerBackup.Name = "miFazerBackup"
		Me.miFazerBackup.Size = New System.Drawing.Size(246, 30)
		Me.miFazerBackup.Text = "Fazer Backup"
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.SlateGray
		Me.Panel1.Controls.Add(Me.lblInfoMessage)
		Me.Panel1.Controls.Add(Me.btnMinimizer)
		Me.Panel1.Controls.Add(Me.lblTituloGeral)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(1204, 38)
		Me.Panel1.TabIndex = 0
		'
		'lblInfoMessage
		'
		Me.lblInfoMessage.AutoSize = True
		Me.lblInfoMessage.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
		Me.lblInfoMessage.ForeColor = System.Drawing.Color.LightYellow
		Me.lblInfoMessage.Location = New System.Drawing.Point(12, 7)
		Me.lblInfoMessage.Name = "lblInfoMessage"
		Me.lblInfoMessage.Size = New System.Drawing.Size(126, 26)
		Me.lblInfoMessage.TabIndex = 11
		Me.lblInfoMessage.Text = "Mensagem..."
		Me.lblInfoMessage.Visible = False
		'
		'btnMinimizer
		'
		Me.btnMinimizer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnMinimizer.BackColor = System.Drawing.Color.Transparent
		Me.btnMinimizer.FlatAppearance.BorderSize = 0
		Me.btnMinimizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow
		Me.btnMinimizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
		Me.btnMinimizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnMinimizer.Image = Global.NovaSiao.My.Resources.Resources.minimize_fina_peq
		Me.btnMinimizer.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnMinimizer.Location = New System.Drawing.Point(1166, 3)
		Me.btnMinimizer.Margin = New System.Windows.Forms.Padding(0)
		Me.btnMinimizer.Name = "btnMinimizer"
		Me.btnMinimizer.Size = New System.Drawing.Size(32, 30)
		Me.btnMinimizer.TabIndex = 10
		Me.btnMinimizer.TabStop = False
		Me.btnMinimizer.UseVisualStyleBackColor = False
		'
		'lblTituloGeral
		'
		Me.lblTituloGeral.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.lblTituloGeral.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
		Me.lblTituloGeral.ForeColor = System.Drawing.Color.White
		Me.lblTituloGeral.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblTituloGeral.Location = New System.Drawing.Point(908, 5)
		Me.lblTituloGeral.Name = "lblTituloGeral"
		Me.lblTituloGeral.Size = New System.Drawing.Size(251, 26)
		Me.lblTituloGeral.TabIndex = 0
		Me.lblTituloGeral.Text = "Programa Loja"
		Me.lblTituloGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'SContainerPrincipal
		'
		Me.SContainerPrincipal.Dock = System.Windows.Forms.DockStyle.Top
		Me.SContainerPrincipal.IsSplitterFixed = True
		Me.SContainerPrincipal.Location = New System.Drawing.Point(0, 38)
		Me.SContainerPrincipal.Name = "SContainerPrincipal"
		'
		'SContainerPrincipal.Panel1
		'
		Me.SContainerPrincipal.Panel1.Controls.Add(Me.tsPrincipal)
		'
		'SContainerPrincipal.Panel2
		'
		Me.SContainerPrincipal.Panel2.Controls.Add(Me.btnSair)
		Me.SContainerPrincipal.Size = New System.Drawing.Size(1204, 70)
		Me.SContainerPrincipal.SplitterDistance = 1030
		Me.SContainerPrincipal.TabIndex = 1
		Me.SContainerPrincipal.TabStop = False
		'
		'btnSair
		'
		Me.btnSair.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSair.Image = Global.NovaSiao.My.Resources.Resources.Fechar
		Me.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnSair.Location = New System.Drawing.Point(52, 9)
		Me.btnSair.Margin = New System.Windows.Forms.Padding(4)
		Me.btnSair.Name = "btnSair"
		Me.btnSair.Size = New System.Drawing.Size(108, 50)
		Me.btnSair.TabIndex = 0
		Me.btnSair.Text = "&Sair"
		Me.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me.btnSair.UseVisualStyleBackColor = True
		'
		'PainelInferior
		'
		Me.PainelInferior.BackColor = System.Drawing.Color.SlateGray
		Me.PainelInferior.Controls.Add(Me.lblConta)
		Me.PainelInferior.Controls.Add(Me.Label4)
		Me.PainelInferior.Controls.Add(Me.lblVersao)
		Me.PainelInferior.Controls.Add(Me.Label1)
		Me.PainelInferior.Controls.Add(Me.lblFilial)
		Me.PainelInferior.Controls.Add(Me.Label3)
		Me.PainelInferior.Controls.Add(Me.lblDataSis)
		Me.PainelInferior.Controls.Add(Me.Label2)
		Me.PainelInferior.Controls.Add(Me.lblHora)
		Me.PainelInferior.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.PainelInferior.Location = New System.Drawing.Point(0, 713)
		Me.PainelInferior.Name = "PainelInferior"
		Me.PainelInferior.Size = New System.Drawing.Size(1204, 35)
		Me.PainelInferior.TabIndex = 2
		'
		'lblConta
		'
		Me.lblConta.ForeColor = System.Drawing.Color.Transparent
		Me.lblConta.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblConta.Location = New System.Drawing.Point(396, 7)
		Me.lblConta.Name = "lblConta"
		Me.lblConta.Size = New System.Drawing.Size(186, 19)
		Me.lblConta.TabIndex = 5
		Me.lblConta.Text = "..."
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.ForeColor = System.Drawing.Color.Transparent
		Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label4.Location = New System.Drawing.Point(351, 7)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(51, 19)
		Me.Label4.TabIndex = 4
		Me.Label4.Text = "Conta:"
		'
		'lblVersao
		'
		Me.lblVersao.ForeColor = System.Drawing.Color.Transparent
		Me.lblVersao.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblVersao.Location = New System.Drawing.Point(643, 7)
		Me.lblVersao.Name = "lblVersao"
		Me.lblVersao.Size = New System.Drawing.Size(102, 19)
		Me.lblVersao.TabIndex = 3
		Me.lblVersao.Text = "..."
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.ForeColor = System.Drawing.Color.Transparent
		Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label1.Location = New System.Drawing.Point(590, 7)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(57, 19)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Versão:"
		'
		'lblFilial
		'
		Me.lblFilial.ForeColor = System.Drawing.Color.Transparent
		Me.lblFilial.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblFilial.Location = New System.Drawing.Point(248, 7)
		Me.lblFilial.Name = "lblFilial"
		Me.lblFilial.Size = New System.Drawing.Size(102, 19)
		Me.lblFilial.TabIndex = 3
		Me.lblFilial.Text = "..."
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.ForeColor = System.Drawing.Color.Transparent
		Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label3.Location = New System.Drawing.Point(205, 7)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(44, 19)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Filial:"
		'
		'lblDataSis
		'
		Me.lblDataSis.ForeColor = System.Drawing.Color.Transparent
		Me.lblDataSis.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblDataSis.Location = New System.Drawing.Point(131, 7)
		Me.lblDataSis.Name = "lblDataSis"
		Me.lblDataSis.Size = New System.Drawing.Size(68, 19)
		Me.lblDataSis.TabIndex = 1
		Me.lblDataSis.Text = "..."
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.ForeColor = System.Drawing.Color.Transparent
		Me.Label2.Location = New System.Drawing.Point(12, 7)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(119, 19)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Data do Sistema:"
		'
		'lblHora
		'
		Me.lblHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblHora.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold)
		Me.lblHora.ForeColor = System.Drawing.Color.White
		Me.lblHora.Image = Global.NovaSiao.My.Resources.Resources.RelogioIcon_peq
		Me.lblHora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.lblHora.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblHora.Location = New System.Drawing.Point(1097, 3)
		Me.lblHora.Name = "lblHora"
		Me.lblHora.Size = New System.Drawing.Size(102, 30)
		Me.lblHora.TabIndex = 6
		Me.lblHora.Text = "Hora"
		Me.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		Me.Timer1.Interval = 600
		'
		'miOutrasConfigurações
		'
		Me.miOutrasConfigurações.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAtividadesDosClientes, Me.miPlanosDeParcelamento})
		Me.miOutrasConfigurações.Image = Global.NovaSiao.My.Resources.Resources.Controles_24x24
		Me.miOutrasConfigurações.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miOutrasConfigurações.Name = "miOutrasConfigurações"
		Me.miOutrasConfigurações.Size = New System.Drawing.Size(246, 30)
		Me.miOutrasConfigurações.Text = "Outras Configurações"
		'
		'miAtividadesDosClientes
		'
		Me.miAtividadesDosClientes.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miAtividadesDosClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miAtividadesDosClientes.Name = "miAtividadesDosClientes"
		Me.miAtividadesDosClientes.Size = New System.Drawing.Size(242, 30)
		Me.miAtividadesDosClientes.Text = "Atividades dos Clientes"
		'
		'miPlanosDeParcelamento
		'
		Me.miPlanosDeParcelamento.Image = Global.NovaSiao.My.Resources.Resources.editar
		Me.miPlanosDeParcelamento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.miPlanosDeParcelamento.Name = "miPlanosDeParcelamento"
		Me.miPlanosDeParcelamento.Size = New System.Drawing.Size(242, 30)
		Me.miPlanosDeParcelamento.Text = "Planos de Parcelamento"
		'
		'frmPrincipal
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(1204, 748)
		Me.Controls.Add(Me.PainelInferior)
		Me.Controls.Add(Me.SContainerPrincipal)
		Me.Controls.Add(Me.Panel1)
		Me.Font = New System.Drawing.Font("Calibri", 12.0!)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.IsMdiContainer = True
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.MinimizeBox = False
		Me.Name = "frmPrincipal"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Principal"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.tsPrincipal.ResumeLayout(False)
		Me.tsPrincipal.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.SContainerPrincipal.Panel1.ResumeLayout(False)
		Me.SContainerPrincipal.Panel2.ResumeLayout(False)
		CType(Me.SContainerPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SContainerPrincipal.ResumeLayout(False)
		Me.PainelInferior.ResumeLayout(False)
		Me.PainelInferior.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents btnSair As Button
    Friend WithEvents tsPrincipal As ToolStrip
    Friend WithEvents miClienteNovo As ToolStripMenuItem
    Friend WithEvents miProdutoNovo As ToolStripMenuItem
    Friend WithEvents miProdutoListagem As ToolStripMenuItem
    Friend WithEvents miClienteProcurar As ToolStripMenuItem
    Friend WithEvents lblTituloGeral As Label
    Friend WithEvents tsbVendas As ToolStripSplitButton
    Friend WithEvents tsbAReceber As ToolStripSplitButton
    Friend WithEvents tsbCompras As ToolStripSplitButton
    Friend WithEvents tsbClientes As ToolStripSplitButton
    Friend WithEvents tsbAPagar As ToolStripSplitButton
	Friend WithEvents SContainerPrincipal As SplitContainer
	Friend WithEvents Panel1 As Panel
	Friend WithEvents PainelInferior As Panel
	Friend WithEvents Timer1 As Timer
	Friend WithEvents lblHora As Label
	Friend WithEvents btnMinimizer As Button
	Friend WithEvents tsbConfig As ToolStripSplitButton
	Friend WithEvents miConfiguracaoDataPadrao As ToolStripMenuItem
	Friend WithEvents miConfiguracaoSistema As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
	Friend WithEvents miConfiguracaoUsuarios As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
	Friend WithEvents miProdutoTipos As ToolStripMenuItem
	Friend WithEvents miEditarProduto As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
	Friend WithEvents miNovaVendaVista As ToolStripMenuItem
	Friend WithEvents miNovaVendaPrazo As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
	Friend WithEvents miProcurarOperacaoSaida As ToolStripMenuItem
	Friend WithEvents tsbCadastros As ToolStripSplitButton
	Friend WithEvents miFuncionarios As ToolStripMenuItem
	Friend WithEvents miFornecedores As ToolStripMenuItem
	Friend WithEvents miTransportadoras As ToolStripMenuItem
	Friend WithEvents Label2 As Label
	Friend WithEvents lblDataSis As Label
	Friend WithEvents lblFilial As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents miNovaCompra As ToolStripMenuItem
	Friend WithEvents miProcurarOperacaoEntrada As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
	Friend WithEvents miAReceberCliente As ToolStripMenuItem
	Friend WithEvents miFabricantesMarcas As ToolStripMenuItem
	Friend WithEvents miCredores As ToolStripMenuItem
	Friend WithEvents miTipoDeDespesa As ToolStripMenuItem
	Friend WithEvents miNovaDespesa As ToolStripMenuItem
	Friend WithEvents miProcurarDespesa As ToolStripMenuItem
	Friend WithEvents miAPagarProcurar As ToolStripMenuItem
	Friend WithEvents miDespesasPeriodicas As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
	Friend WithEvents tsbCaixa As ToolStripSplitButton
	Friend WithEvents miFinalizarCaixa As ToolStripMenuItem
	Friend WithEvents miContas As ToolStripMenuItem
	Friend WithEvents miFormasDeMovimentacao As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
	Friend WithEvents miControlesMovimentacao As ToolStripMenuItem
	Friend WithEvents miTiposDeMovimentacao As ToolStripMenuItem
	Friend WithEvents miTiposDeCartao As ToolStripMenuItem
	Friend WithEvents miNovaDespesaQuitada As ToolStripMenuItem
	Friend WithEvents miProcurarCaixa As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
	Friend WithEvents lblConta As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
	Friend WithEvents miProdutoEtiquetaVenda As ToolStripMenuItem
	Friend WithEvents tsbProdutos As ToolStripSplitButton
	Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
	Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
	Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
	Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
	Friend WithEvents miFazerBackup As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
	Friend WithEvents miNovaReserva As ToolStripMenuItem
	Friend WithEvents miProcurarReserva As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator17 As ToolStripSeparator
	Friend WithEvents miControleDePedidos As ToolStripMenuItem
	Friend WithEvents miProcurarTroca As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator18 As ToolStripSeparator
	Friend WithEvents miNovaSimplesSaida As ToolStripMenuItem
	Friend WithEvents miSimplesEntrada As ToolStripMenuItem
	Friend WithEvents miAReceberMovInterna As ToolStripMenuItem
	Friend WithEvents miAPagarMovInterna As ToolStripMenuItem
	Friend WithEvents miNovaDevolucaoSaida As ToolStripMenuItem
	Friend WithEvents miCFOP As ToolStripMenuItem
	Friend WithEvents miTransferencias As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator19 As ToolStripSeparator
	Friend WithEvents miControleDeEstoque As ToolStripMenuItem
	Friend WithEvents miEstoqueInicial As ToolStripMenuItem
	Friend WithEvents miAjusteEstoque As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator20 As ToolStripSeparator
	Friend WithEvents miProcurarAjusteDeEstoque As ToolStripMenuItem
	Friend WithEvents lblVersao As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents ToolStripSeparator21 As ToolStripSeparator
	Friend WithEvents miFretes As ToolStripMenuItem
	Friend WithEvents miEmailServer As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
	Friend WithEvents miNovaCompraNormal As ToolStripMenuItem
	Friend WithEvents miNovaCompraNFeXML As ToolStripMenuItem
	Friend WithEvents lblInfoMessage As Label
	Friend WithEvents miCartasClientes As ToolStripMenuItem
	Friend WithEvents miGerarParaAniversariantes As ToolStripMenuItem
	Friend WithEvents miEnvioMalaDiretaImpressão As ToolStripMenuItem
	Friend WithEvents miClientePFInserir As ToolStripMenuItem
	Friend WithEvents miClientePJInserir As ToolStripMenuItem
	Friend WithEvents miClientesSimples As ToolStripMenuItem
	Friend WithEvents miOutrasConfigurações As ToolStripMenuItem
	Friend WithEvents miAtividadesDosClientes As ToolStripMenuItem
	Friend WithEvents miPlanosDeParcelamento As ToolStripMenuItem
End Class
