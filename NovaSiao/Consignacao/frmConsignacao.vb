Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmConsignacao
	'
	'--- CLASSE
	Private _Consig As clConsignacao
	Private _Devolucao As clConsignacaoDevolucao
	Private cBLL As New ConsignacaoBLL
	Private _IDFilial As Integer
	'
	'--- LISTS
	Public _ItensConsigList As New List(Of clTransacaoItem)
	Private _ItensCompraList As New List(Of clConsignacaoCompraItem)
	Private _ItensDevList As New List(Of clTransacaoItem)
	Private _NotasList As New List(Of clNotaFiscal)
	Private _APagarList As New List(Of clAPagar)
	'
	'--- BINDINGS
	Private bindConsig As New BindingSource
	Private bindConsigList As New BindingSource
	Private bindCompra As New BindingSource
	Private bindDevolucao As New BindingSource
	Private bindNota As New BindingSource
	Private bindAPagar As New BindingSource
	'
	'--- CONTROLES
	Private _SitConsig As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
	Private _SitDevolucao As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
	Private VerificaAlteracao As Boolean
	'
	'--- TOTAIS
	Private _TotalAPagar As Decimal
	Private _TotalProdutosConsignacao As Decimal
	Private _TotalProdutosCompra As Decimal
	Private _TotalProdutosDevolucao As Decimal
	Private _TotalCobrancas As Decimal
	'
#Region "LOAD | NEW"
	'
	'--- SUB NEW
	'----------------------------------------------------------------------------------
	Public Sub New(consignacao As clConsignacao)
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		propConsig = consignacao
		'
		'--- hANDLER Menu Acao
		'MenuOpen_AdHandler()
		'
	End Sub
	'
	'--- LOAD
	'----------------------------------------------------------------------------------
	Private Sub frmConsignacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'
		'--- faz a leitura dos combobox para nao emitir mensagem na alteracao do TAB
		cmbFreteTipoConsig.SelectedValue = _Consig.FreteTipo
		cmbIDTransportadoraConsig.SelectedValue = If(_Consig.IDTransportadora, -1)
		'
		cmbFreteTipoDev.SelectedValue = _Devolucao.FreteTipo
		cmbIDTransportadoraDev.SelectedValue = If(_Devolucao.IDTransportadora, -1)
		'
	End Sub
	'
	Private Property SitConsig As EnumFlagEstado
		'
		Get
			Return _SitConsig
		End Get
		'
		Set(value As EnumFlagEstado)
			'
			_SitConsig = value
			'
			'--- array of controls that can readonly
			Dim ReadOnlyControls As TextBox() = New TextBox() {
				txtFreteValorConsig,
				txtObservacaoConsig,
				txtVolumesConsig,
				txtFreteCobrado,
				txtICMSValor,
				txtDespesas,
				txtDescontos
			}
			'
			Select Case _SitConsig
				'
				Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
					btnConsignacaoData.Enabled = True
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = False)
					'
				Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
					btnConsignacaoData.Enabled = True
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = False)
					'
				Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
					btnConsignacaoData.Enabled = True
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = False)
					'
				Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
					btnConsignacaoData.Enabled = False
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = True)
					'
			End Select
			'
		End Set
		'
	End Property
	'
	Private Property SitDevolucao As EnumFlagEstado
		'
		Get
			Return _SitDevolucao
		End Get
		'
		Set(value As EnumFlagEstado)
			'
			_SitDevolucao = value
			'
			'--- array of controls that can readonly
			Dim ReadOnlyControls As TextBox() = New TextBox() {
				txtFreteValorDev,
				txtObservacaoDev,
				txtVolumesDev
			}
			'
			Select Case _SitDevolucao
				'
				Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
					btnConsignacaoData.Enabled = True
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = False)
					'
				Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
					btnConsignacaoData.Enabled = True
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = False)
					'
				Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
					btnConsignacaoData.Enabled = True
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = False)
					'
				Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
					btnConsignacaoData.Enabled = False
					Array.ForEach(ReadOnlyControls, Function(x) x.ReadOnly = True)
					'
			End Select
			'
		End Set
		'
	End Property
	'    
	Property propConsig As clConsignacao
		'
		Get
			Return _Consig
		End Get
		'
		Set(value As clConsignacao)
			'
			VerificaAlteracao = False '--- Inibe a verificacao dos campos IDPlano
			_Consig = value
			_IDFilial = _Consig.IDFilial
			'

			'
			ObterItensConsignacao()
			ObterItensCompra()
			ObterAPagar()
			ObterNotas()
			'
			ObterDevolucao()
			'
			If _Devolucao IsNot Nothing Then ObterItensDevolucao()
			'
			bindConsigList.DataSource = _ItensConsigList
			bindNota.DataSource = _NotasList
			bindCompra.DataSource = _ItensCompraList
			'
			bindConsig.DataSource = _Consig
			bindDevolucao.DataSource = _Devolucao
			PreencheDataBinding()
			'
			'--- Preenche os Itens da Consignacao
			PreencheItensConsignacao()
			PreencheItensCompra()
			'
			cmbFreteTipoConsig.SelectedValue = _Consig.FreteTipo
			cmbIDTransportadoraConsig.SelectedValue = If(_Consig.IDTransportadora, -1)
			cmbNotaTipo.SelectedValue = -1
			'
			'--- Preenche Notas Fiscais
			Preenche_Notas()
			'
			'--- Verifica Estado da Consignacao
			VerificaEstadoConsignacao()
			'
			'--- End edit
			_Consig.EndEdit()
			'
			'--- Habilita ou Desabilita os campos do Frete da Compra
			Controla_cmbFreteConsig()
			Controla_cmbFreteDev()
			'
			'--- Permite a verificacao dos campos IDPlano
			VerificaAlteracao = True
			'
		End Set
		'
	End Property
	'
	'--- Verifica Estado da Consignacao
	'---> 1: entrada | 2: compra | 3: devolucao
	Private Sub VerificaEstadoConsignacao()
		'
		If _Consig.IDSituacao = 1 AndAlso _Devolucao.IDSituacao = 0 Then
			btnFinalizar.Text = "&Concluir Entrada"
			lblSituacao.Text = "Entrada da Consignação"
			SitConsig = EnumFlagEstado.NovoRegistro
			SitDevolucao = EnumFlagEstado.RegistroBloqueado
			'
		ElseIf _Consig.IDSituacao = 2 AndAlso _Devolucao.IDSituacao = 0 Then
			btnFinalizar.Text = "&Concluir Compra"
			lblSituacao.Text = "Compra da Consignação"
			SitConsig = EnumFlagEstado.RegistroSalvo
			SitDevolucao = EnumFlagEstado.RegistroBloqueado
			'
		ElseIf _Consig.IDSituacao = 2 AndAlso _Devolucao.IDSituacao = 1 Then
			btnFinalizar.Text = "&Finalizar Consignação"
			lblSituacao.Text = "Devolução da Consignação"
			SitConsig = EnumFlagEstado.RegistroBloqueado
			SitDevolucao = EnumFlagEstado.NovoRegistro
			'
		ElseIf _Consig.IDSituacao = 3 Then
			btnFinalizar.Text = "&Consignação Boqueada"
			lblSituacao.Text = "Consignação Bloqueada"
			SitConsig = EnumFlagEstado.RegistroBloqueado
			SitDevolucao = EnumFlagEstado.RegistroBloqueado
			'
		End If
		'
	End Sub
	'
#End Region
	'
#Region "TOTAIS E LABELS TOTAIS"
	'
	'--- TOTAL DOS PRODUTOS DA CONSIGNACAO
	'----------------------------------------------------------------------------------
	Private Function TotalAPagar() As Decimal
		'
		'--- Declara variaveis do Total de produto e de adicionais da Compra
		Dim TAdic As Double = 0
		'
		TAdic = IIf(IsNothing(_Consig.FreteCobrado), 0, _Consig.FreteCobrado)
		TAdic = TAdic + IIf(IsNothing(_Consig.ICMSValor), 0, _Consig.ICMSValor)
		TAdic = TAdic + IIf(IsNothing(_Consig.Despesas), 0, _Consig.Despesas)
		TAdic = TAdic - IIf(IsNothing(_Consig.Descontos), 0, _Consig.Descontos)
		'
		_TotalAPagar = TotalProdutosCompra() + TAdic
		'
		'--- verifica se o valor Total Geral é menor que zero
		If _TotalAPagar < 0 Then _TotalAPagar = 0
		'
		'--- atualiza o label
		lblTotalAPagar.Text = Format(_TotalAPagar, "c")
		'
		'--- retorna
		Return _TotalAPagar
		'
	End Function
	'
	Private Function TotalProdutosConsignacao() As Decimal
		'
		Dim TProd As Decimal = _ItensConsigList.Sum(Function(x) x.Total)
		_TotalProdutosConsignacao = TProd
		'
		'--- atualiza o label
		lblTotalProdutosConsig.Text = Format(TProd, "c")
		lblTotalConsignacao.Text = Format(TProd, "c")
		'
		'--- retorna
		Return _TotalProdutosConsignacao
		'
	End Function
	'
	Private Function TotalProdutosCompra() As Decimal
		'
		Dim TProd As Decimal = _ItensCompraList.Sum(Function(x) x.Total)
		_TotalProdutosCompra = TProd
		'
		'--- atualiza o label
		lblTotalProdutosComprados.Text = Format(TProd, "c")
		lblTotalComprado.Text = Format(TProd, "c")
		'
		'--- retorna
		Return _TotalProdutosCompra
		'
	End Function
	'
	Private Function TotalProdutosDevolucao() As Decimal
		'
		Dim TProd As Decimal = _ItensDevList.Sum(Function(x) x.Total)
		_TotalProdutosDevolucao = TProd
		'
		'--- atualiza o label
		lblTotalProdutosDev.Text = Format(TProd, "c")
		'
		'--- retorna
		Return _TotalProdutosDevolucao
		'
	End Function
	'
	Private Function TotalCobrancas() As Decimal
		'
		Dim Total As Decimal = _APagarList.Sum(Function(x) x.APagarValor)
		_TotalCobrancas = Total
		'
		'--- atualiza o label
		lblTotalCobrado.Text = Format(Total, "c")
		'
		'--- retorna
		Return _TotalCobrancas
		'
	End Function
	'
#End Region '/ TOTAIS E LABELS TOTAIS
	'
#Region "DATABINDING"
	'
	Private Sub PreencheDataBinding()
		'
		txtFreteCobrado.DataBindings.Add("Text", bindConsig, "FreteCobrado", True, DataSourceUpdateMode.OnPropertyChanged)
		txtICMSValor.DataBindings.Add("Text", bindConsig, "ICMSValor", True, DataSourceUpdateMode.OnPropertyChanged)
		txtDespesas.DataBindings.Add("Text", bindConsig, "Despesas", True, DataSourceUpdateMode.OnPropertyChanged)
		txtDescontos.DataBindings.Add("Text", bindConsig, "Descontos", True, DataSourceUpdateMode.OnPropertyChanged)
		lblFornecedor.DataBindings.Add("Text", bindConsig, "Fornecedor", True, DataSourceUpdateMode.OnPropertyChanged)
		lblIDConsignacao.DataBindings.Add("Text", bindConsig, "IDConsignacao", True, DataSourceUpdateMode.OnPropertyChanged)
		lblFilial.DataBindings.Add("Text", bindConsig, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
		lblConsignacaoData.DataBindings.Add("Text", bindConsig, "TransacaoData", True, DataSourceUpdateMode.OnPropertyChanged)

		txtVolumesConsig.DataBindings.Add("Text", bindConsig, "Volumes", True, DataSourceUpdateMode.OnPropertyChanged)
		txtFreteValorConsig.DataBindings.Add("Text", bindConsig, "FreteValor", True, DataSourceUpdateMode.OnPropertyChanged)
		txtObservacaoConsig.DataBindings.Add("Text", bindConsig, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
		'
		'--- BIND DEVOLUCAO
		txtVolumesDev.DataBindings.Add("Text", bindDevolucao, "Volumes", True, DataSourceUpdateMode.OnPropertyChanged)
		txtFreteValorDev.DataBindings.Add("Text", bindDevolucao, "FreteValor", True, DataSourceUpdateMode.OnPropertyChanged)
		txtObservacaoDev.DataBindings.Add("Text", bindDevolucao, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
		'
		'dgvItens.DataBindings.Add("Tag", bindItem, "IDProduto", True, DataSourceUpdateMode.OnPropertyChanged)
		'
		' FORMATA OS VALORES DO DATABINDING
		AddHandler lblIDConsignacao.DataBindings("Text").Format, AddressOf FormatRG
		AddHandler txtFreteValorConsig.DataBindings("text").Format, AddressOf FormatCUR
		AddHandler txtDescontos.DataBindings("text").Format, AddressOf FormatCUR
		AddHandler txtDespesas.DataBindings("text").Format, AddressOf FormatCUR
		AddHandler txtFreteCobrado.DataBindings("text").Format, AddressOf FormatCUR
		AddHandler txtICMSValor.DataBindings("text").Format, AddressOf FormatCUR
		AddHandler txtVolumesConsig.DataBindings("text").Format, AddressOf Format00
		AddHandler lblConsignacaoData.DataBindings("text").Format, AddressOf FormatDT
		'
		' CARREGA OS COMBOBOX
		CarregaCmbFreteTipoConsig()
		CarregaCmbTransportadoraConsig()
		CarregaCmbNotaTipo()
		'
		' ADD HANDLER PARA DATABINGS
		AddHandler _Consig.AoAlterar, AddressOf HandlerAoAlterarConsig
		AddHandler _Devolucao.AoAlterar, AddressOf HandlerAoAlterarDev
		'
	End Sub
	'
	Private Sub HandlerAoAlterarConsig()
		If _Consig.RegistroAlterado = True And SitConsig = EnumFlagEstado.RegistroSalvo Then
			SitConsig = EnumFlagEstado.Alterado
		End If
	End Sub
	'
	Private Sub HandlerAoAlterarDev()
		If _Consig.RegistroAlterado = True And SitDevolucao = EnumFlagEstado.RegistroSalvo Then
			SitDevolucao = EnumFlagEstado.Alterado
		End If
	End Sub
	'
	' FORMATA OS BINDINGS
	Private Sub FormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
		e.Value = Format(e.Value, "0000")
	End Sub
	Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
		e.Value = FormatCurrency(e.Value, 2)
	End Sub
	Private Sub FormatDT(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
		e.Value = Format(e.Value, "dd/MM/yyyy")
	End Sub
	Private Sub Format00(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
		If Not IsNothing(e.Value) Then
			e.Value = Format(CInt(e.Value), "00")
		End If
	End Sub
	'
#End Region
	'    
#Region "CARREGA OS COMBOBOX"
	'
	Private Sub CarregaCmbFreteTipoConsig()
		'
		Dim dtFTipo As New DataTable
		'
		'--- Adiciona as Colunas
		dtFTipo.Columns.Add("idFTipo")
		dtFTipo.Columns.Add("FTipo")
		'
		'--- Adiciona todas as possibilidades de Frete
		dtFTipo.Rows.Add(New Object() {0, "Sem Frete"})
		dtFTipo.Rows.Add(New Object() {1, "Emitente"})
		dtFTipo.Rows.Add(New Object() {2, "Destinatário"})
		'
		With cmbFreteTipoConsig
			.DataSource = dtFTipo
			.ValueMember = "idFTipo"
			.DisplayMember = "FTipo"
			.DataBindings.Add("SelectedValue", bindConsig, "FreteTipo", True, DataSourceUpdateMode.OnPropertyChanged)
		End With
		'
		With cmbFreteTipoDev
			.DataSource = dtFTipo.Copy()
			.ValueMember = "idFTipo"
			.DisplayMember = "FTipo"
			.DataBindings.Add("SelectedValue", bindDevolucao, "FreteTipo", True, DataSourceUpdateMode.OnPropertyChanged)
		End With
		'
	End Sub
	'
	Private Sub CarregaCmbTransportadoraConsig()
		Dim tBLL As New TransportadoraBLL
		'
		Try
			Dim dt As DataTable = tBLL.Transportadora_GET_ListaSimples(True)
			'
			With cmbIDTransportadoraConsig
				.DataSource = dt
				.ValueMember = "IDTransportadora"
				.DisplayMember = "Cadastro"
				.DataBindings.Add("SelectedValue", bindConsig, "IDTransportadora", True, DataSourceUpdateMode.OnPropertyChanged)
			End With
			'
			With cmbIDTransportadoraDev
				.DataSource = dt.Copy()
				.ValueMember = "IDTransportadora"
				.DisplayMember = "Cadastro"
				.DataBindings.Add("SelectedValue", bindDevolucao, "IDTransportadora", True, DataSourceUpdateMode.OnPropertyChanged)
			End With
			'
		Catch ex As Exception
			MessageBox.Show("Um erro aconteceu obter lista de Transportadoras" & vbNewLine &
			ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		'
	End Sub
	'
	Private Sub CarregaCmbNotaTipo()
		'
		Dim dtNTipo As New DataTable
		'
		With dtNTipo
			'--- Adiciona as Colunas
			.Columns.Add("idNTipo")
			.Columns.Add("NTipo")
			'--- Adiciona todas as possibilidades de Frete
			.Rows.Add(New Object() {1, "NF-e"})
			.Rows.Add(New Object() {2, "Cupom Fiscal"})
			.Rows.Add(New Object() {3, "Outros Tipos"})
		End With
		'
		With cmbNotaTipo
			.DataSource = dtNTipo
			.ValueMember = "idNTipo"
			.DisplayMember = "NTipo"
		End With
		'
	End Sub
	'
	'--------------------------------------------------------------------------------------------------------
#End Region
	'
#Region "LOAD | INSERT ITENS CONSIGNACAO"
	'
	'--- RETORNA TODOS OS ITENS DA CONSIGNACAO
	Private Sub ObterItensConsignacao()
		'
		Dim tBLL As New TransacaoItemBLL
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			_ItensConsigList = tBLL.GetTransacaoItens_WithCustos_List(_Consig.IDConsignacao, _IDFilial)
			'
			'--- Atualiza o label TOTAL
			TotalProdutosConsignacao()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao obter Itens da Consignação:..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub PreencheItensConsignacao()
		'
		'--- limpa as colunas do datagrid
		dgvItensConsignacao.Columns.Clear()
		dgvItensConsignacao.AutoGenerateColumns = False
		'
		' altera as propriedades importantes
		dgvItensConsignacao.MultiSelect = False
		dgvItensConsignacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvItensConsignacao.ColumnHeadersVisible = True
		dgvItensConsignacao.AllowUserToResizeRows = False
		dgvItensConsignacao.AllowUserToResizeColumns = False
		dgvItensConsignacao.RowHeadersVisible = True
		dgvItensConsignacao.RowHeadersWidth = 30
		dgvItensConsignacao.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
		dgvItensConsignacao.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
		dgvItensConsignacao.StandardTab = True
		'
		'--- configura o DataSource
		dgvItensConsignacao.DataSource = bindConsigList
		If dgvItensConsignacao.Rows.Count > 0 Then dgvItensConsignacao.CurrentCell = dgvItensConsignacao.Rows(dgvItensConsignacao.Rows.Count).Cells(1)
		'
		'--- formata as colunas do datagrid
		FormataColunas_Itens()
		'
	End Sub
	'
	Private Sub FormataColunas_Itens()
		'
		' (1) COLUNA IDItem
		With clnIDTransacaoItem
			.DataPropertyName = "IDTransacaoItem"
			.Width = 0
			.Resizable = DataGridViewTriState.False
			.Visible = False
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With
		'
		' (2) COLUNA RGProduto
		With clnRGProduto
			.DataPropertyName = "RGProduto"
			.Width = 60
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.DefaultCellStyle.Format = "0000"
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			'.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
		End With
		'
		' (3) COLUNA PRODUTO
		With clnProduto
			.DataPropertyName = "Produto"
			.Width = 375
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' (4) COLUNA QUANTIDADE
		With clnQuantidade
			.DataPropertyName = "Quantidade"
			.Width = 60
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.DefaultCellStyle.Format = "00"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
		End With
		'
		' (5) COLUNA PRECO
		With clnPreco
			.DataPropertyName = "Preco"
			.Width = 90
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (6) COLUNA SUB TOTAL
		With clnSubTotal
			.DataPropertyName = "SubTotal"
			.Width = 90
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (7) COLUNA DESCONTO
		With clnDesconto
			.DataPropertyName = "Desconto"
			.Width = 80
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "0.00"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (8) COLUNA TOTAL
		With clnTotal
			.DataPropertyName = "Total"
			.Width = 90
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (9) COLUNA ICMS
		With clnICMS
			.DataPropertyName = "ICMS"
			.Width = 60
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "0.00"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (10) COLUNA ST
		With clnST
			.DataPropertyName = "Substituicao"
			.Width = 75
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (11) COLUNA MVA
		With clnMVA
			.DataPropertyName = "MVA"
			.Width = 60
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "0.00"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (12) COLUNA IPI
		With clnIPI
			.DataPropertyName = "IPI"
			.Width = 60
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "0.00"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		'--- ADD COLUMNS
		Me.dgvItensConsignacao.Columns.AddRange(New DataGridViewColumn() {
									 clnIDTransacaoItem, clnRGProduto, clnProduto, clnQuantidade,
									 clnPreco, clnSubTotal, clnDesconto, clnTotal, clnICMS,
									 clnST, clnMVA, clnIPI})

		'
	End Sub
	'
	'--- INSERIR NOVO ITEM NA LISTA DE PRODUTOS
	'----------------------------------------------------------------------------------------------------
	Private Sub Inserir_ItemConsig()
		'
		'--- Verifica se esta Bloqueado ou Finalizado
		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
		'
		'--- check if exists compra
		If _ItensCompraList.Count > 0 Then
			'
			AbrirDialog("Essa devolução já possui produtos comprados, por isso não é possível inserir/editar produtos...",
						"Produtos Comprados",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
			'
		End If
		'
		'--- Abre o frmItem
		Dim newItem As New clTransacaoItem
		'
		Using fItem As New frmCompraItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _IDFilial, newItem)
			'
			fItem.ShowDialog()
			'
			'--- Verifica a resposa do Dialog
			If Not fItem.DialogResult = DialogResult.OK Then Exit Sub
			'
		End Using
		'
		newItem.EndEdit()
		'
		'--- it doesn't permit duplicated products
		If _ItensConsigList.Exists(Function(x) x.RGProduto = newItem.RGProduto) Then
			AbrirDialog("Não é possível inserir um produto que já foi inserido na listagem..." &
						vbNewLine & "Favor inserir produtos que não estão na listagem.",
						"Produto já inserido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		Dim ItemBLL As New TransacaoItemBLL
		Dim myID As Long? = Nothing
		'
		'--- Insere o novo ITEM no BD
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			newItem.IDTransacao = _Consig.IDConsignacao
			myID = ItemBLL.InserirNovoItem(newItem,
										   TransacaoItemBLL.EnumMovimento.ENTRADA,
										   _Consig.TransacaoData,
										   InsereCustos:=True
										   )
			newItem.IDTransacaoItem = myID
		Catch ex As Exception
			MessageBox.Show("Houve um exceção ao INSERIR o item no BD..." & vbNewLine & ex.Message, "Exceção Inesperada",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Insere o ITEM na lista
		bindConsigList.Add(newItem)
		bindConsig.MoveLast()
		'
		'--- Atualiza o label TOTAL
		TotalProdutosConsignacao()
		'
	End Sub
	'
	'--- EDITAR ITEM DA LISTA DE PRODUTOS
	'----------------------------------------------------------------------------------------------------
	Private Sub Editar_ItemConsig()
		'
		'--- Verifica se existe algum item selecionado
		If dgvItensConsignacao.SelectedRows.Count = 0 Then Exit Sub
		'
		'--- Verifica se esta Bloqueado ou Finalizado
		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
		'
		'--- check if exists compra
		If _ItensCompraList.Count > 0 Then
			'
			AbrirDialog("Essa devolução já possui produtos comprados, por isso não é possível inserir/editar produtos...",
						"Produtos Comprados",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
			'
		End If
		'
		'--- Abre o frmItem
		Dim itmAtual As clTransacaoItem = dgvItensConsignacao.SelectedRows(0).DataBoundItem
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Using fitem As New frmCompraItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _IDFilial, itmAtual)
				'
				fitem.ShowDialog()
				'
				'--- Verifica a resposa do Dialog
				If fitem.DialogResult <> DialogResult.OK Then Exit Sub
				'
			End Using
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir Form de Item..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'--- check if duplicate product
		'--- it doesn't permit duplicated products
		If _ItensConsigList.Exists(Function(x) x.RGProduto = itmAtual.RGProduto And x.IDTransacaoItem <> itmAtual.IDTransacaoItem) Then
			AbrirDialog("Não é possível inserir um produto que já foi inserido na listagem..." &
						vbNewLine & "Favor inserir produtos que não estão na listagem.",
						"Produto já inserido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			itmAtual.CancelEdit()
			Exit Sub
		Else
			itmAtual.EndEdit()
		End If
		'
		Dim ItemBLL As New TransacaoItemBLL
		Dim myID As Long? = Nothing
		'
		'--- Altera o ITEM no BD e reforma o ESTOQUE
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			itmAtual.IDTransacao = _Consig.IDConsignacao
			myID = ItemBLL.EditarItem(itmAtual,
									  TransacaoItemBLL.EnumMovimento.ENTRADA,
									  _Consig.TransacaoData,
									  InsereCustos:=True)
			'
			itmAtual.IDTransacaoItem = myID
			'
		Catch ex As Exception
			MessageBox.Show("Houve um exceção ao ALTERAR o item no BD..." & vbNewLine & ex.Message,
							"Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'--- Atualiza o label TOTAL
		TotalProdutosConsignacao()
		'
	End Sub
	'
	'--- EXCLUIR ITEM DA LISTA DE PRODUTOS
	'---------------------------------------------------------------------------------------------------
	Private Sub Excluir_ItemConsig()
		'
		'--- Verifica se existe algum item selecionado
		If dgvItensConsignacao.SelectedRows.Count = 0 Then Exit Sub
		'
		'--- Verifica se esta Bloqueado ou Finalizado
		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
		'
		'--- check if exists compra
		If _ItensCompraList.Count > 0 Then
			'
			AbrirDialog("Essa devolução já possui produtos comprados, por isso não é possível inserir/editar produtos...",
						"Produtos Comprados",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
			'
		End If
		'
		'--- seleciona o item
		Dim itmAtual As clTransacaoItem
		itmAtual = dgvItensConsignacao.SelectedRows(0).DataBoundItem
		'
		'--- pergunta ao usuário se deseja excluir o item
		If AbrirDialog("Deseja realmente REMOVER esse item da Consignação?" & vbNewLine & vbNewLine &
					   itmAtual.Produto.ToUpper,
					   "Excluir Item",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question,
					   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Exit Sub
		'
		'--- Exclui o ITEM
		'------------------------------------------
		Dim ItemBLL As New TransacaoItemBLL
		Dim myID As Long? = Nothing
		'
		Dim i As Integer = _ItensConsigList.FindIndex(Function(x) x.IDTransacaoItem = itmAtual.IDTransacaoItem)
		'
		'--- Altera o ITEM no BD e reforma o ESTOQUE
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			myID = ItemBLL.ExcluirItem(itmAtual, TransacaoItemBLL.EnumMovimento.ENTRADA)
			'
		Catch ex As Exception
			MessageBox.Show("Houve um exceção ao EXCLUIR o item no BD..." & vbNewLine & ex.Message,
							"Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Atualiza o ITEM da lista
		bindConsigList.RemoveAt(i)
		'
		'--- Atualiza o label TOTAL
		TotalProdutosConsignacao()
		'
	End Sub
	'
	'---------------------------------------------------------------------------------------------------
	' CRIA TECLA DE ATALHO PARA INSERIR/EDITAR PRODUTO
	'---------------------------------------------------------------------------------------------------
	Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItensConsignacao.KeyDown
		'
		If e.KeyCode = Keys.Add Then
			e.Handled = True
			Inserir_ItemConsig()

		ElseIf e.KeyCode = Keys.Enter Then
			e.Handled = True
			Editar_ItemConsig()

		ElseIf e.KeyCode = Keys.Delete Then
			e.Handled = True
			Excluir_ItemConsig()
		End If
		'
	End Sub
	'
	Private Sub dgvItens_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItensConsignacao.CellDoubleClick
		Editar_ItemConsig()
	End Sub
	'
#End Region
	'
#Region "LOAD | INSERT ITENS - COMPRA"
	'
	'--- RETORNA TODOS OS ITENS DA COMPRA
	Private Sub ObterItensCompra()
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			_ItensCompraList = cBLL.GetConsigCompraItens_List(_Consig.IDConsignacao)
			'
			'--- Atualiza o label TOTAL
			TotalProdutosCompra()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao obter Itens da Compra da Consignação:" & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub PreencheItensCompra()
		'
		'--- limpa as colunas do datagrid
		dgvItensComprados.Columns.Clear()
		dgvItensComprados.AutoGenerateColumns = False
		'
		' altera as propriedades importantes
		dgvItensComprados.MultiSelect = False
		dgvItensComprados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvItensComprados.ColumnHeadersVisible = True
		dgvItensComprados.AllowUserToResizeRows = False
		dgvItensComprados.AllowUserToResizeColumns = False
		dgvItensComprados.RowHeadersVisible = True
		dgvItensComprados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
		dgvItensComprados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
		dgvItensComprados.StandardTab = True
		'
		'--- configura o DataSource
		dgvItensComprados.DataSource = bindCompra
		If dgvItensComprados.Rows.Count > 0 Then dgvItensComprados.CurrentCell = dgvItensComprados.Rows(dgvItensComprados.Rows.Count).Cells(1)
		'
		'--- formata as colunas do datagrid Compra
		FormataColunas_ItensCompra()
		'
	End Sub
	'
	Private Sub FormataColunas_ItensCompra()
		'
		' (0) COLUNA RGProduto
		With clnRGProdutoCompra
			.DataPropertyName = "RGProduto"
			.Width = 60
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.DefaultCellStyle.Format = "0000"
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			'.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
		End With
		'
		' (1) COLUNA PRODUTO
		With clnProdutoCompra
			.DataPropertyName = "Produto"
			.Width = 375
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' (2) COLUNA QUANTIDADE
		With clnQuantidadeCompra
			.DataPropertyName = "Quantidade"
			.Width = 60
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.DefaultCellStyle.Format = "00"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
		End With
		'
		' (3) COLUNA PRECO
		With clnPrecoCompra
			.DataPropertyName = "Preco"
			.Width = 90
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (4) COLUNA DESCONTO
		With clnDescontroCompra
			.DataPropertyName = "Desconto"
			.Width = 80
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "0.00"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (5) COLUNA TOTAL
		With clnTotalCompra
			.DataPropertyName = "Total"
			.Width = 90
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		'--- ADD COLUMNS
		Me.dgvItensComprados.Columns.AddRange(New DataGridViewColumn() {
									 clnRGProdutoCompra, clnProdutoCompra, clnQuantidadeCompra, clnPrecoCompra,
									 clnDescontroCompra, clnTotalCompra})

		'
	End Sub
	'
	'--- INSERIR NOVO ITEM NA LISTA DE PRODUTOS DA COMPRA
	'----------------------------------------------------------------------------------------------------
	Private Sub Inserir_ItemCompra()
		'
		'--- check if exists Consignacao
		If _ItensConsigList.Count = 0 Then
			AbrirDialog("Não é possível realizar compra em uma consignação que não há entradas de produtos..." &
						vbNewLine & "Favor informar os produtos consignados.",
						"Não há produtos", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		'--- Verifica se esta Bloqueado ou Finalizado
		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
		'
		'--- Abre o frmItem
		Dim newItem As New clConsignacaoCompraItem
		'
		Using fItem As New frmConsignacaoCompraItem(Me, newItem)
			'
			fItem.ShowDialog()
			'
			'--- Verifica a resposa do Dialog
			If fItem.DialogResult <> DialogResult.OK Then Exit Sub
			'
		End Using
		'
		'--- Check if Item was included in Consignacao
		Dim quant As Integer = _ItensConsigList.Sum(Function(x) x.Quantidade And x.RGProduto = newItem.RGProduto)
		'
		If quant = 0 Then
			AbrirDialog("Não é possível realizar uma compra de consignação de um produto que não está na listagem de consignação..." &
						vbNewLine & "Favor escolher somente produtos que estão na listagem.",
						"Produto não recebido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Exit Sub
		ElseIf quant < newItem.Quantidade Then
			AbrirDialog("A quantidade do produto que você está tentando inserir é maior que a quantidade que foi recebida na consignação" &
						vbNewLine & "Favor determinar uma quantidade menor ou igual à quantidade recebida.",
						"Quantidade inválida", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		'--- Check if quantity compra
		Dim quantComprada As Integer = _ItensCompraList.Sum(Function(x) x.Quantidade And x.RGProduto = newItem.RGProduto)
		'
		If quantComprada > 0 Then
			If quant < newItem.Quantidade + quantComprada Then
				AbrirDialog("A quantidade do produto que você está tentando inserir é maior que a quantidade que foi recebida na consignação" &
							vbNewLine & "Favor determinar uma quantidade menor ou igual à quantidade recebida.",
							"Quantidade inválida", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
				Exit Sub
			End If
		End If
		'
		'--- Insere o novo ITEM no BD
		Dim myID As Long? = Nothing
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			newItem.IDConsignacao = _Consig.IDConsignacao
			myID = cBLL.InsertItemConsigCompra(newItem).IDItem
			newItem.IDItem = myID
			'
		Catch ex As Exception
			MessageBox.Show("Houve um exceção ao INSERIR o item no BD..." & vbNewLine & ex.Message, "Exceção Inesperada",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Insere o ITEM na lista
		bindCompra.Add(newItem)
		bindCompra.MoveLast()
		'
		'--- Atualiza o label TOTAL
		TotalProdutosCompra()
		'
	End Sub
	'
	'--- EDITAR ITEM DA LISTA DE PRODUTOS COMPRADOS
	'----------------------------------------------------------------------------------------------------
	Private Sub Editar_ItemCompra()
		'
		'--- Verifica se existe algum item selecionado
		If dgvItensConsignacao.SelectedRows.Count = 0 Then Exit Sub
		'
		'--- Verifica se esta Bloqueado ou Finalizado
		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
		'
		'--- Abre o frmItem
		Dim itmAtual As clConsignacaoCompraItem
		itmAtual = dgvItensComprados.SelectedRows(0).DataBoundItem
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Using fitem As New frmConsignacaoCompraItem(Me, itmAtual)
				'
				fitem.ShowDialog()
				'
				'--- Verifica a resposa do Dialog
				If fitem.DialogResult <> DialogResult.OK Then Exit Sub
				'
			End Using
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir Form de Item..." & vbNewLine &
				ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'--- Altera o ITEM no BD e reforma o ESTOQUE
		Dim resp As Boolean = False
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			resp = cBLL.UpdateItemConsigCompra(itmAtual)
			'
			If Not resp Then
				bindCompra.CancelEdit()
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Houve um exceção ao ALTERAR o item no BD..." & vbNewLine & ex.Message,
							"Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'--- Atualiza o label TOTAL
		TotalProdutosCompra()
		'
	End Sub
	'
	'--- EXCLUIR ITEM DA LISTA DE PRODUTOS COMPRA
	'---------------------------------------------------------------------------------------------------
	Private Sub Excluir_ItemCompra()
		'
		'--- Verifica se existe algum item selecionado
		If dgvItensConsignacao.SelectedRows.Count = 0 Then Exit Sub
		'
		'--- Verifica se esta Bloqueado ou Finalizado
		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
		'
		'--- seleciona o item
		Dim itmAtual As clConsignacaoCompraItem
		itmAtual = dgvItensComprados.SelectedRows(0).DataBoundItem
		'
		'--- pergunta ao usuário se deseja excluir o item
		If AbrirDialog("Deseja realmente REMOVER esse item da Compra da Consignacão?" & vbNewLine & vbNewLine &
					   itmAtual.Produto.ToUpper, "Excluir Item",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question,
					   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Exit Sub
		'
		'--- Exclui o ITEM
		'------------------------------------------
		Dim i As Integer = _ItensCompraList.FindIndex(Function(x) x.IDItem = itmAtual.IDItem)
		'
		'--- Altera o ITEM no BD e reforma o ESTOQUE
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			cBLL.DeleteItemConsigCompra(itmAtual)
			'
		Catch ex As Exception
			MessageBox.Show("Houve um exceção ao EXCLUIR o item no BD..." & vbNewLine & ex.Message,
							"Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Atualiza o ITEM da lista
		bindCompra.RemoveAt(i)
		'
		'--- Atualiza o label TOTAL
		TotalProdutosCompra()
		'
	End Sub
	'
	'---------------------------------------------------------------------------------------------------
	' CRIA TECLA DE ATALHO PARA INSERIR/EDITAR PRODUTO
	'---------------------------------------------------------------------------------------------------
	Private Sub dgvItensComprados_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItensComprados.KeyDown
		'
		If e.KeyCode = Keys.Add Then
			e.Handled = True
			Inserir_ItemCompra()
			'
		ElseIf e.KeyCode = Keys.Enter Then
			e.Handled = True
			Editar_ItemCompra()
			'
		ElseIf e.KeyCode = Keys.Delete Then
			e.Handled = True
			Excluir_ItemCompra()
			'
		End If
		'
	End Sub
	'
	Private Sub dgvItensComprados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItensComprados.CellDoubleClick
		Editar_ItemCompra()
	End Sub
	'
#End Region '/ LOAD INSERT ITENS - COMPRA
	'    
#Region "BOTOES DE ACAO"
	'
	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		'
		'--- ASK USER
		If Not CanCloseMessage() Then Exit Sub
		'
		'--- CHECK AND SAVE TOTAL
		If _Consig.TotalConsignacao <> TotalProdutosConsignacao() Then
			'
			Try
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				SaveTotal()
				'
			Catch ex As Exception
				MessageBox.Show("Uma exceção ocorreu ao Salvar Total da Consignação..." & vbNewLine &
								ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				'--- Ampulheta OFF
				Cursor = Cursors.Default
			End Try
			'
		End If
		'
		'--- CLOSE
		Close()
		MostraMenuPrincipal()
		'
	End Sub
	'    '
	'    '--- ALTERAR A DATA DA CONSIGNACAO
	'    Private Sub lblCompraData_DoubleClick(sender As Object, e As EventArgs) _
	'        Handles lblCompraData.DoubleClick, btnData.Click
	'        '
	'        Dim frmDt As New frmDataInformar("Informe a data da Compra", EnumDataTipo.PassadoPresente, _Consig.TransacaoData, Me)
	'        frmDt.ShowDialog()
	'        '
	'        If frmDt.DialogResult <> DialogResult.OK Then Exit Sub
	'        '
	'        Dim newDt As Date = frmDt.propDataInfo
	'        '
	'        '--- verifica a data bloqueada
	'        If DataBloqueada(newDt, Obter_ContaPadrao) Then Exit Sub
	'        '
	'        '--- altera a data da TRANSACAO e salva no BD
	'        Try
	'            '
	'            Dim tranBLL As New TransacaoBLL
	'            If tranBLL.AtualizaTransacaoData(_Consig.IDCompra, newDt) Then
	'                '
	'                _Consig.TransacaoData = frmDt.propDataInfo
	'                lblCompraData.DataBindings("Text").ReadValue()
	'                '
	'            End If
	'            '
	'        Catch ex As Exception
	'            MessageBox.Show("Uma exceção ocorreu ao alterar a Data da Compra..." & vbNewLine &
	'                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'        End Try
	'        '
	'    End Sub
	'
	'
	Private Sub btnTransportadoraAdd_Click(sender As Object, e As EventArgs) Handles btnTransportadoraAdd.Click,
		btnTransportadoraAddDev.Click
		'
		Dim myCombo As ComboBox = If(sender = btnTransportadoraAdd, cmbIDTransportadoraConsig, cmbIDTransportadoraDev)
		'
		Dim fTransp As New frmTransportadora(New clTransportadora, Me)
		'
		Visible = False
		fTransp.ShowDialog()
		Visible = True
		myCombo.Focus()

		If fTransp.DialogResult = DialogResult.OK Then
			'
			'--- get new transportadora
			Dim newTransp As clTransportadora = fTransp.propTransp
			'
			'--- insert new transportadora in combo
			Dim dtTransp As DataTable = myCombo.DataSource

			Dim row As DataRow = dtTransp.NewRow()
			row("IDTransportadora") = newTransp.IDPessoa
			row("Cadastro") = newTransp.Cadastro
			dtTransp.Rows.Add(row)
			'
			'--- select new transportadora inserted
			myCombo.SelectedValue = newTransp.IDPessoa
			'
		End If
		'
	End Sub
	'
#End Region
	'    
#Region "FORMATACAO E FLUXO"
	'
	' CRIA TECLA DE ATALHO PARA O TAB
	'---------------------------------------------------------------------------------------------------
	Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
		'
		If e.KeyCode = Keys.PageDown Then
			'
			If tabPrincipal.SelectedTab.TabIndex = 0 Then
				tabPrincipal.SelectedTab = tabPrincipal.TabPages.First(Function(x) x.TabIndex = tabPrincipal.TabPages.Count - 1)
			Else
				Dim actualIndex As Integer = tabPrincipal.SelectedTab.TabIndex
				tabPrincipal.SelectedTab = tabPrincipal.TabPages.First(Function(x) x.TabIndex = actualIndex - 1)
			End If
			'
		ElseIf e.KeyCode = Keys.PageUp Then
			'
			If tabPrincipal.SelectedTab.TabIndex = tabPrincipal.TabPages.Count - 1 Then
				tabPrincipal.SelectedTab = tabPrincipal.TabPages.First(Function(x) x.TabIndex = 0)
			Else
				Dim actualIndex As Integer = tabPrincipal.SelectedTab.TabIndex
				tabPrincipal.SelectedTab = tabPrincipal.TabPages.First(Function(x) x.TabIndex = actualIndex + 1)
			End If
			'
		End If
		'
		If e.Alt AndAlso e.KeyCode = Keys.D1 Then
			tabPrincipal.SelectedTab = vtabProdutos
			tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)

		ElseIf e.Alt AndAlso e.KeyCode = Keys.D2 Then
			tabPrincipal.SelectedTab = vtabFrete
			tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)

		ElseIf e.Alt AndAlso e.KeyCode = Keys.D3 Then
			tabPrincipal.SelectedTab = vtabCompra
			tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)

		ElseIf e.Alt AndAlso e.KeyCode = Keys.D4 Then
			tabPrincipal.SelectedTab = vtabAPagar
			tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)

		ElseIf e.Alt AndAlso e.KeyCode = Keys.D5 Then
			tabPrincipal.SelectedTab = vtabDevolucao
			tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)

		ElseIf e.Alt AndAlso e.KeyCode = Keys.D6 Then
			tabPrincipal.SelectedTab = vtabFreteDevolucao
			tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)

		ElseIf e.Alt AndAlso e.KeyCode = Keys.D7 Then
			tabPrincipal.SelectedTab = vtabNotas
			tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
		End If
		'
	End Sub
	'
	Private Sub tabPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPrincipal.SelectedIndexChanged
		'
		If tabPrincipal.SelectedIndex = 0 Then
			dgvItensConsignacao.Focus()
			'
		ElseIf tabPrincipal.SelectedIndex = 1 Then
			cmbFreteTipoConsig.Focus()
			'
		ElseIf tabPrincipal.SelectedIndex = 2 Then
			dgvItensComprados.Focus()
			'
		ElseIf tabPrincipal.SelectedIndex = 3 Then
			txtFreteCobrado.Focus()
			'
		ElseIf tabPrincipal.SelectedIndex = 4 Then
			dgvDevolucao.Focus()
			'
		ElseIf tabPrincipal.SelectedIndex = 5 Then
			cmbFreteTipoDev.Focus()
			'
		ElseIf tabPrincipal.SelectedIndex = 6 Then
			dgvNotas.Focus()
			'
		End If
		'
	End Sub
	'
	' HABILITA OU DESABILITA OS CONTROLES DO FRETE
	'---------------------------------------------------------------------------------------------------
	Private Sub cmbFreteTipoConsig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFreteTipoConsig.SelectedIndexChanged,
		cmbFreteTipoConsig.SelectedIndexChanged
		'
		If DirectCast(sender, Control).Name = "cmbFreteTipoConsig" Then
			Controla_cmbFreteConsig()
		Else
			Controla_cmbFreteDev()
		End If
		'
	End Sub
	'
	Public Sub Controla_cmbFreteConsig()
		'
		If Not IsNumeric(cmbFreteTipoConsig.SelectedValue) Then Exit Sub
		'
		If _Consig.FreteTipo = 0 Then
			'
			'--- Nulifica os valores das propriedades do Frete
			_Consig.IDTransportadora = Nothing
			_Consig.FreteValor = Nothing
			_Consig.Volumes = Nothing
			'
			'--- Atualiza os novos valores dos controles
			If cmbIDTransportadoraConsig.DataBindings.Count > 0 Then
				cmbIDTransportadoraConsig.DataBindings.Item("SelectedValue").ReadValue()
				cmbIDTransportadoraConsig.Text = String.Empty
				txtFreteValorConsig.DataBindings.Item("Text").ReadValue()
				txtVolumesConsig.DataBindings.Item("Text").ReadValue()
			End If
			'
			'--- Desabilita os controles
			cmbIDTransportadoraConsig.Enabled = False
			btnTransportadoraAdd.Enabled = False
			txtFreteValorConsig.Enabled = False
			txtVolumesConsig.Enabled = False
			'
		Else
			'
			cmbIDTransportadoraConsig.Enabled = True
			btnTransportadoraAdd.Enabled = True
			txtFreteValorConsig.Enabled = True
			txtVolumesConsig.Enabled = True
			'
		End If
		'
	End Sub
	'
	Public Sub Controla_cmbFreteDev()
		'
		If Not IsNumeric(cmbFreteTipoDev.SelectedValue) Then Exit Sub
		'
		If _Devolucao.FreteTipo = 0 Then
			'
			'--- Nulifica os valores das propriedades do Frete
			_Devolucao.IDTransportadora = Nothing
			_Devolucao.FreteValor = Nothing
			_Devolucao.Volumes = Nothing
			'
			'--- Atualiza os novos valores dos controles
			If cmbIDTransportadoraDev.DataBindings.Count > 0 Then
				'
				cmbIDTransportadoraDev.DataBindings.Item("SelectedValue").ReadValue()
				cmbIDTransportadoraDev.Text = String.Empty
				txtFreteValorDev.DataBindings.Item("Text").ReadValue()
				txtVolumesDev.DataBindings.Item("Text").ReadValue()
				'
			End If
			'
			'--- Desabilita os controles
			cmbIDTransportadoraDev.Enabled = False
			btnTransportadoraAddDev.Enabled = False
			txtFreteValorDev.Enabled = False
			txtVolumesDev.Enabled = False
			'
		Else
			'
			cmbIDTransportadoraDev.Enabled = True
			btnTransportadoraAddDev.Enabled = True
			txtFreteValorDev.Enabled = True
			txtVolumesDev.Enabled = True
			'
		End If
		'
	End Sub



	'
	'--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
	Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDespesas.KeyDown,
		txtDescontos.KeyDown, txtFreteCobrado.KeyDown, txtICMSValor.KeyDown,
		txtObservacaoConsig.KeyDown, txtObservacaoDev.KeyDown,
		txtFreteValorConsig.KeyDown, txtVolumesConsig.KeyDown,
		cmbIDTransportadoraConsig.KeyDown, cmbFreteTipoConsig.KeyDown,
		txtVolumesDev.KeyDown, txtFreteValorDev.KeyDown,
		cmbIDTransportadoraDev.KeyDown, cmbFreteTipoDev.KeyDown
		'
		'--- Se for o campo observacao, verifica se esta preenchido com algum texto
		'--- Se esta preenchido entao permite que o ENTER funcione como nova linha
		If DirectCast(sender, TextBox).Name = "txtObservacaoConsig" AndAlso txtObservacaoConsig.Text.Trim.Length > 0 Then
			Exit Sub
		End If
		'
		If DirectCast(sender, TextBox).Name = "txtObservacaoDev" AndAlso txtObservacaoDev.Text.Trim.Length > 0 Then
			Exit Sub
		End If
		'
		If e.KeyCode = Keys.Enter Then
			e.SuppressKeyPress = True
			SendKeys.Send("{Tab}")
		End If
		'
	End Sub
	'
#End Region
	'	
#Region "CONTROLE DO A PAGAR"
	'
	'============================================================================================================
	' A PAGAR CONTROLES
	'============================================================================================================
	'
	'--- RETORNA TODOS AS COBRANCAS DE APAGAR
	Private Sub ObterAPagar()
		'
		Dim pBLL As New APagarBLL
		'
		Try
			_APagarList = pBLL.APagar_GET_PorOrigem(_Consig.IDConsignacao, clAPagar.Origem_APagar.Compra)
			'
			'--- Atualiza o label TOTAL
			TotalAPagar()
			TotalCobrancas()
			'
		Catch ex As Exception
			MessageBox.Show("Um execeção ocorreu ao obter o A Pagar da Compra:" & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		'
	End Sub
	'
	'--- Preenche o DataGrid AReceber
	Private Sub Preenche_APagar()
		With dgvAPagar
			'
			'--- limpa as colunas do datagrid
			.Columns.Clear()
			.AutoGenerateColumns = False
			'
			' altera as propriedades importantes
			.MultiSelect = False
			.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			.ColumnHeadersVisible = True
			.AllowUserToResizeRows = False
			.AllowUserToResizeColumns = False
			.RowHeadersVisible = True
			.RowHeadersWidth = 30
			.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
			.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
			.StandardTab = True
			'
			'--- configura o DataSource
			.DataSource = bindAPagar
			If .Rows.Count > 0 Then .CurrentCell = .Rows(.Rows.Count).Cells(1)
		End With
		'
		'--- formata as colunas do datagrid
		FormataGrid_APagar()
		'
	End Sub
	'
	Private Sub FormataGrid_APagar()
		'
		Dim cellStyleCur As New DataGridViewCellStyle
		cellStyleCur.Format = "c"
		cellStyleCur.NullValue = Nothing
		cellStyleCur.Alignment = DataGridViewContentAlignment.MiddleRight
		'
		' (0) COLUNA FORMA
		With clnCobrancaForma
			.DataPropertyName = "CobrancaForma"
			.Width = 160
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
			'.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
		End With
		'
		' (1) COLUNA IDENTIFICADOR
		With clnIdentificador
			.DefaultCellStyle = cellStyleCur
			.DataPropertyName = "Identificador"
			.Width = 100
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (2) COLUNA VENCIMENTO
		With clnVencimento
			.HeaderText = "Vencimento"
			.DataPropertyName = "Vencimento"
			.Width = 110
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
		End With
		'
		' (3) COLUNA VALOR
		With clnAPagarValor
			.DefaultCellStyle = cellStyleCur
			.DataPropertyName = "APagarValor"
			.Width = 100
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		dgvAPagar.Columns.AddRange({clnCobrancaForma, clnIdentificador, clnVencimento, clnAPagarValor})
		'
	End Sub
	'
	Private Sub dgvAReceber_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAPagar.KeyDown
		'
		If e.KeyCode = Keys.Add Then
			e.Handled = True
			'
			If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
			APagar_Adicionar()
			'
		ElseIf e.KeyCode = Keys.Enter Then
			e.Handled = True
			'
			If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
			APagar_Editar()
			'
		ElseIf e.KeyCode = Keys.Delete Then
			e.Handled = True
			'
			If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
			APagar_Excluir()
			'
		End If
		'
	End Sub
	'
	Private Sub APagar_Adicionar()
		'
		'--- Atualiza o Valor do Total Geral
		Dim vl As Double = TotalAPagar()
		Dim vlPag As Double = TotalCobrancas()
		'
		'--- Verifica se o valor dos itens COMPRADOS é maior que zero
		If vl <= 0 Then
			AbrirDialog("Não é possivel adicionar Parcelas de A Pagar" & vbNewLine &
						"Quando o valor da Consignação ainda é igual a Zero..." & vbNewLine &
						"Compre produtos primeiro para tentar novamente depois.",
						"Nova Parcela",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		'--- Verifica se o somatorio de APAGAR ainda é menor que o ValorTotalGeral
		If Math.Abs(vl - vlPag) < 0.1 Then
			AbrirDialog("Não é possivel adicionar Parcelas de A Pagar" & vbNewLine &
						"pois o valor cobrado já é igual ao valor do Total Geral" & vbNewLine &
						"Você pode Alterar ou Excluir parcelas.",
						"Nova Parcela",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		'--- posiciona o form
		Dim pos As Point = dgvAPagar.PointToScreen(Point.Empty)
		pos = New Point(pos.X - 10, pos.Y)
		'
		'--- cria novo APagar
		Dim clPag As New clAPagar
		'
		clPag.Origem = 1
		clPag.IDOrigem = _Consig.IDConsignacao
		clPag.IDPessoa = _Consig.IDFornecedor
		clPag.IDFilial = _Consig.IDFilial
		clPag.APagarValor = vl - _APagarList.Sum(Function(x) x.APagarValor)
		clPag.Vencimento = _Consig.TransacaoData
		clPag.Situacao = 0
		'
		'--- verifica se houve outro APagar anterior para obter valores padrão
		Dim pagCount As Integer = _APagarList.Count
		'
		If pagCount > 0 Then
			clPag.IDCobrancaForma = _APagarList.ElementAt(pagCount - 1).IDCobrancaForma
			clPag.CobrancaForma = _APagarList.ElementAt(pagCount - 1).CobrancaForma
			clPag.RGBanco = _APagarList.ElementAt(pagCount - 1).RGBanco
			clPag.Vencimento = _APagarList.ElementAt(pagCount - 1).Vencimento.AddMonths(1)
		End If
		'
		'--- abre o form frmAPagar
		Using fPag As New frmAPagarItem(Me, clPag.APagarValor, _Consig.TransacaoData, clPag, EnumFlagAcao.INSERIR, pos)
			'
			fPag.ShowDialog()
			'
			If fPag.DialogResult = DialogResult.OK Then
				'
				'--- Insere o APAGAR na lista
				bindAPagar.Add(clPag)
				bindAPagar.MoveLast()
				'
				'--- AtualizaTotalAPagar
				TotalCobrancas()
				'
			End If
			'
		End Using
		'
	End Sub
	'
	Private Sub APagar_Editar()
		'
		'--- posiciona o form
		Dim pos As Point = dgvAPagar.PointToScreen(Point.Empty)
		pos = New Point(pos.X - 10, pos.Y)
		'
		'--- GET APagar do DataGrid
		If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
		'
		Dim PagAtual As clAPagar = dgvAPagar.SelectedRows(0).DataBoundItem
		'
		Using fPag As New frmAPagarItem(Me, TotalAPagar, _Consig.TransacaoData, PagAtual, EnumFlagAcao.EDITAR, pos)
			'
			fPag.ShowDialog()
			'
			'--- AtualizaTotalAPagar
			TotalCobrancas()
			'
		End Using
		'
	End Sub
	'
	Private Sub APagar_Excluir()
		'
		'--- verifica se existe alguma parcela selecionada
		If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
		'
		'--- seleciona a parcela
		Dim i As Integer = dgvAPagar.SelectedRows(0).Index
		'
		'--- pergunta ao usuário se deseja excluir o item
		If AbrirDialog("Deseja realmente REMOVER essa parcela A Pagar?", "Excluir Parcela",
				   frmDialog.DialogType.SIM_NAO,
				   frmDialog.DialogIcon.Question,
				   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then
			Exit Sub
		End If
		'
		'--- envia o comando para excluir a parcela no BD
		'
		'--- Atualiza o ITEM da lista
		bindAPagar.RemoveAt(i)
		'
		'--- AtualizaTotalAPagar
		TotalCobrancas()
		'
	End Sub
	'
	Private Sub dgvAPagar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAPagar.CellDoubleClick
		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
		'
		APagar_Editar()
		'
	End Sub
	'
	'============================================================================================================
#End Region
	'	
#Region "FINALIZAR CONSIGNACAO"
	'	'
	'	'==========================================================================================
	'	' FINALIZE COMPRA WITH VERIFIES
	'	'==========================================================================================
	'	Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
	'		'
	'		'--- Verifica se a SITUACAO do registro permite salvar
	'		If Sit = EnumFlagEstado.Alterado OrElse Sit = EnumFlagEstado.NovoRegistro Then
	'			'
	'			'--- Faz as VERIFICACOES DOS CAMPOS E VALORES
	'			If Verificar() = False Then Exit Sub
	'			'
	'			'--- PERGUNTA AO USUÁRIO
	'			If AbrirDialog("Deseja realmente Finalizar essa Transação de Compra?",
	'							   "Finalizar Compra",frmDialog.DialogType.SIM_NAO,
	'							frmDialog.DialogIcon.Question) = DialogResult.No Then Exit Sub
	'			'
	'			'--- Determina se o Tipo da Cobrança é A VISTA OU PARCELADA
	'			If _APagarList.Count = 0 Then
	'				_Consig.CobrancaTipo = 0 '--- SEM COBRANÇA
	'			Else
	'				For Each pag In _APagarList
	'					If pag.Vencimento <> _Consig.TransacaoData Then
	'						_Consig.CobrancaTipo = 2 '--- PARCELADA
	'						Exit For
	'					Else
	'						_Consig.CobrancaTipo = 1 '--- A VISTA
	'					End If
	'				Next
	'			End If
	'			'
	'			'--- DEFINE TOTAL GERAL
	'			Dim TGeral As Decimal = TotalGeral
	'			'
	'			'--- SALVA O APAGAR PARCELAS NO BD
	'			If Salvar_APagar() = False Then
	'				'--- If FALSE cancel SAVE
	'				_Consig.IDSituacao = 1
	'				_Consig.TotalCompra = TGeral
	'				SalvaRegistroCompra()
	'				Sit = EnumFlagEstado.Alterado
	'				Return
	'				'
	'			End If
	'			'
	'			'--- EFETUA O RATEIO DO FRETE NOS ITENS | REGISTRA O FORNECEDOR AOS PRODUTOS
	'			EfetuarFinalizacao()
	'			'
	'			'--- altera a situacao da transacao atual
	'			_Consig.IDSituacao = 2 'CONCLUÍDA
	'			_Consig.TotalCompra = TGeral
	'			'
	'			'--- SALVA A TRANSACAO/COMPRA NO BD
	'			If SalvaRegistroCompra() Then
	'				'
	'				'--- ALTERA A SITUACAO DO REGISTRO ATUAL
	'				Sit = EnumFlagEstado.RegistroSalvo
	'			End If
	'			'
	'		End If
	'		'
	'		'--- PERGUNTA O QUE O USUARIO DESEJA FAZER
	'		Dim fAcao As New frmAcaoDialog(Me, "Compra")
	'		'
	'		fAcao.ShowDialog()
	'		'
	'		If fAcao.DialogResult = DialogResult.Cancel Then
	'			Close()
	'			MostraMenuPrincipal()
	'		End If
	'		'
	'	End Sub
	'	'
	'==========================================================================================
	' SAVE IN BD
	'==========================================================================================
	Private Function SalvaRegistroConsignacao() As Boolean
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim obj As Object = cBLL.UpdateConsignacaoEntrada(_Consig)
			'
			If Not IsNumeric(obj) Then
				Throw New Exception(obj.ToString)
			End If
			'
			Return True
			'
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao Salvar o Registro da Consignação..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		Return False
		'
	End Function
	'
	'==========================================================================================
	' SAVE TOTAL OF CONSIGNACAO
	'==========================================================================================
	Private Function SaveTotal() As Boolean
		'
		Try
			'
			Dim obj As Object = cBLL.UpdateConsignacaoEntradaTotal(_Consig.IDConsignacao, TotalProdutosConsignacao)
			'
			If Not IsNumeric(obj) Then
				Throw New Exception(obj.ToString)
			End If
			'
			Return True
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
		Return False
		'
	End Function
	'	'
	'	'==========================================================================================
	'	' CHECK TO SAVE
	'	'==========================================================================================
	'	Private Function Verificar() As Boolean
	'		'--- Verifica se a Data não está BLOQUEADA pelo sistema
	'		'
	'		'----------------------------------------------------------------------------------------------
	'		' VERIFICA OS VALORES DA COMPRA, DAS PARCELAS E DO FRETE E DAS NOTAS FISCAIS
	'		'----------------------------------------------------------------------------------------------
	'		'
	'		'--- Verifica se existe algum item produto na compra
	'		If _ItensConsigList.Count = 0 Then
	'			MessageBox.Show("Não é possível finalizar uma COMPRA que não possui nenhum produto lançado..." & vbNewLine &
	'				"Favor incluir alguns produtos nessa venda.",
	'				"COMPRA Sem Produtos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'			tabPrincipal.SelectedTab = vtab1
	'			dgvItens.Focus()
	'			Return False
	'		End If
	'		'
	'		'--- Verifica o valor da COMPRA
	'		Dim TGeral As Double = TotalGeral
	'		'
	'		If TGeral = 0 Then
	'			MessageBox.Show("Não é possível finalizar uma COMPRA cujo valor final é igual a Zero..." & vbNewLine &
	'							"Favor incluir alguns produtos nessa venda.",
	'							"COMPRA Nula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'			tabPrincipal.SelectedTab = vtab1
	'			dgvItens.Focus()
	'			Return False
	'		End If
	'		'
	'		'--- Verifica se o valor da COMPRA é igual à soma das parcelas
	'		If Math.Abs(TGeral - AtualizaTotalAPagar()) > 1 Then
	'			MessageBox.Show("A soma das parcelas é diferente da soma dos produtos" & vbNewLine &
	'							"Favor corrigir esse erro alterando o parcelamento.",
	'							"Parcelamento com Diferença", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'			tabPrincipal.SelectedTab = vtab2
	'			dgvAPagar.Focus()
	'			Return False
	'		End If
	'		'
	'		'--- Verifica o valor do Total das Notas Fiscais
	'		Dim TNf As Double = AtualizaTotalNotasFiscais()
	'		'
	'		If TNf > 0 AndAlso Math.Abs(TGeral - TNf) > 1 Then
	'			MessageBox.Show("A soma das Notas Fiscais é diferente da Soma dos Produtos" & vbNewLine &
	'				"Favor corrigir os valores das Notas Fiscais.",
	'				"Notas Fiscais com Diferença", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'			tabPrincipal.SelectedTab = vtab3
	'			dgvVendaNotas.Focus()
	'		End If
	'		'
	'		'----------------------------------------------------------------------------------------------
	'		' VERIFICA OS CAMPOS NECESSÁRIOS DA COMPRA
	'		'----------------------------------------------------------------------------------------------
	'		'
	'		'--- Verifica se há FRETE COBRADO
	'		If IsNothing(_Consig.FreteCobrado) OrElse _Consig.FreteCobrado < 0 Then _Consig.FreteCobrado = 0
	'		'
	'		'--- Verifica se há TIPO DE FRETE
	'		If IsNothing(_Consig.FreteTipo) Then
	'			MessageBox.Show("O campo TIPO DE FRETE não pode ficar vazio...", "Campo Necessário",
	'							MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'			tabPrincipal.SelectedTab = vtab2
	'			cmbFreteTipo.Focus()
	'			Return False
	'		End If
	'		'
	'		'--- Verifica se houve dupla cobrança de FRETE na compra
	'		If _Consig.FreteTipo = 2 Then
	'			If _Consig.FreteCobrado > 0 Then
	'				MessageBox.Show("Quando o TIPO de FRETE é DESTINÁRIO, o valor do FRETE deve ser inserido no campo: VALOR DO FRETE..." & vbNewLine &
	'								"Favor retirar o valor do FRETE COBRADO ou alterar o tipo de frete...", "Frete Cobrado",
	'								MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'				tabPrincipal.SelectedTab = vtab2
	'				txtFreteCobrado.Focus()
	'				Return False
	'			End If
	'			'
	'			'--- Verifica se o valor do Frete foi inserido
	'			If If(_Consig.FreteValor, 0) = 0 Then
	'				MessageBox.Show("O VALOR DO FRETE precisa ser maior do que Zero" & vbNewLine &
	'								"Favor inserir o Valor do Frete", "Frete Valor",
	'								MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'				tabPrincipal.SelectedTab = vtab2
	'				txtFreteValor.Focus()
	'				Return False
	'			End If
	'			'
	'		End If
	'		'
	'		If IsNothing(_Consig.ICMSValor) OrElse _Consig.ICMSValor < 0 Then _Consig.ICMSValor = 0
	'		If IsNothing(_Consig.Despesas) OrElse _Consig.Despesas < 0 Then _Consig.Despesas = 0
	'		If IsNothing(_Consig.Descontos) OrElse _Consig.Descontos < 0 Then _Consig.Descontos = 0
	'		'
	'		Return True
	'		'
	'	End Function
	'	'
	'	'==========================================================================================
	'	' SAVE A PAGAR
	'	'==========================================================================================
	'	Private Function Salvar_APagar() As Boolean
	'		If _APagarList.Count = 0 Then Return False
	'		'
	'		Dim pagBLL As New APagarBLL
	'		'
	'		'--- Exclui todos os registros de APagar da Compra atual
	'		Try
	'			'
	'			'--- Ampulheta ON
	'			Cursor = Cursors.WaitCursor
	'			'
	'			pagBLL.APagarDeletePorOrigem(_Consig.IDCompra, clAPagar.Origem_APagar.Compra, False)
	'			'
	'			'--- Insere cada um APagar no BD
	'			For Each pag As clAPagar In _APagarList
	'				pagBLL.InserirNovo_APagar(pag)
	'			Next
	'			'
	'			Return True
	'		Catch ex As Exception
	'			MessageBox.Show("Houve uma exceção inesperada ao SALVAR Registros de APagar..." & vbNewLine &
	'							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'			Return False
	'		Finally
	'			'
	'			'--- Ampulheta OFF
	'			Cursor = Cursors.Default
	'			'
	'		End Try
	'		'
	'	End Function
	'	'
	'	'==========================================================================================
	'	' RATEIO DO FRETE PARA OS ITENS | REGISTRA O FORNECEDOR DO PRODUTO
	'	'==========================================================================================
	'	Private Sub EfetuarFinalizacao()
	'		'
	'		Dim Response As Object = Nothing
	'		Dim TProdutos As Decimal = TotalProdutos
	'		'
	'		Try
	'			'
	'			'--- Ampulheta ON
	'			Cursor = Cursors.WaitCursor
	'			'
	'			Dim FreteTotal As Decimal = IIf(IsNothing(_Consig.FreteCobrado), 0, _Consig.FreteCobrado)
	'			FreteTotal += IIf(IsNothing(_Consig.FreteValor), 0, _Consig.FreteValor)
	'			'
	'			Response = cBLL.CompraFinalizar(_Consig.IDCompra, _Consig.TransacaoData, _Consig.IDPessoaOrigem, FreteTotal, TProdutos)
	'			'
	'			If Not IsNumeric(Response) Then
	'				Throw New Exception(Response.ToString)
	'			End If
	'			'
	'		Catch ex As Exception
	'			MessageBox.Show("Houve uma exceção na Finalização dessa Compra..." & vbNewLine &
	'							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'		Finally
	'			'
	'			'--- Ampulheta OFF
	'			Cursor = Cursors.Default
	'			'
	'		End Try
	'		'
	'	End Sub
	'	'   
#End Region
	'	
#Region "CONTROLE DO CONTEXT MENUSTRIP"
	'	'
	'	'=============================================================================
	'	' CONTROLA O MENUSTRIP NO DATAGRID ITENS
	'	'=============================================================================
	'	Private Sub dgvItens_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
	'		If e.Button = MouseButtons.Right Then
	'			'
	'			Dim hit As DataGridView.HitTestInfo = dgvItens.HitTest(e.X, e.Y)
	'			dgvItens.ClearSelection()
	'			'
	'			If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
	'			'
	'			' seleciona o ROW
	'			dgvItens.CurrentCell = dgvItens.Rows(hit.RowIndex).Cells(1)
	'			dgvItens.Rows(hit.RowIndex).Selected = True
	'			'
	'			'mnuItens.Show(dgvItens, c.PointToScreen(e.Location))
	'			cmsMenuAPagar.Show(dgvItens, e.Location)
	'			'
	'		End If
	'	End Sub
	'	'
	'	'=============================================================================
	'	' CONTROLA O MENUSTRIP NO DATAGRID APAGAR
	'	'=============================================================================
	'	Private Sub dgvAPagar_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvCompras.MouseDown
	'		If e.Button = MouseButtons.Right Then
	'			'
	'			Dim hit As DataGridView.HitTestInfo = dgvAPagar.HitTest(e.X, e.Y)
	'			dgvAPagar.ClearSelection()
	'			'
	'			If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
	'			'
	'			' seleciona o ROW
	'			dgvAPagar.CurrentCell = dgvAPagar.Rows(hit.RowIndex).Cells(1)
	'			dgvAPagar.Rows(hit.RowIndex).Selected = True
	'			dgvAPagar.Focus()
	'			'
	'			cmsMenuAPagar.Show(dgvAPagar, e.Location)
	'			'
	'		End If
	'	End Sub
	'	'
	'	Private Sub miInserir_Click(sender As Object, e As EventArgs) Handles miInserir.Click
	'		'
	'		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
	'		If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado

	'		'
	'		'--- Verifica a origem do comando do MenuStrip
	'		If cmsMenuAPagar.SourceControl.Name = "dgvItens" Then
	'			Inserir_Item()
	'		ElseIf cmsMenuAPagar.SourceControl.Name = "dgvAPagar" Then
	'			APagar_Adicionar()
	'		End If
	'		'
	'	End Sub
	'	'
	'	Private Sub miEditar_Click(sender As Object, e As EventArgs) Handles miEditar.Click
	'		'
	'		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
	'		'
	'		'--- Verifica a origem do comando do MenuStrip
	'		If cmsMenuAPagar.SourceControl.Name = "dgvItens" Then
	'			Editar_Item()
	'		ElseIf cmsMenuAPagar.SourceControl.Name = "dgvAPagar" Then
	'			If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
	'			APagar_Editar()
	'		End If
	'		'
	'	End Sub
	'	'
	'	Private Sub miExcluir_Click(sender As Object, e As EventArgs) Handles miExcluir.Click
	'		'
	'		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
	'		'
	'		'--- Verifica a origem do comando do MenuStrip
	'		If cmsMenuAPagar.SourceControl.Name = "dgvItens" Then
	'			Excluir_Item()
	'		ElseIf cmsMenuAPagar.SourceControl.Name = "dgvAPagar" Then
	'			If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
	'			APagar_Excluir()
	'		End If
	'		'
	'	End Sub
	'	'
	'#End Region
	'	'
	'#Region "FUNCOES NECESSARIAS"
	'	'
	'	' ATUALIZA O TOTAL DO APAGAR
	'	'-----------------------------------------------------------------------------------------------------
	'	Private Function AtualizaTotalAPagar() As Double
	'		Dim T As Double = 0
	'		T = _APagarList.Sum(Function(x) x.APagarValor)
	'		lblTotalCobrado.Text = Format(T, "c")
	'		Return T
	'	End Function
	'	'
	'	' ATUALIZA O TOTAL DAS NOTAS FISCAIS
	'	'-----------------------------------------------------------------------------------------------------
	'	Private Function AtualizaTotalNotasFiscais() As Double
	'		Dim T As Double = 0
	'		T = _NotasList.Sum(Function(x) x.NotaValor)
	'		Return T
	'	End Function
	'	'
#End Region
	'	
#Region "BLOQUEIO DE REGISTROS"
	'
	' PROIBE EDICAO NOS COMBOBOX QUANDO COMPRA BLOQUEADA
	'-----------------------------------------------------------------------------------------------------
	Private Sub ComboBox_SelectedValueChanged(sender As Object, e As EventArgs) _
		Handles cmbFreteTipoConsig.SelectedValueChanged,
		cmbIDTransportadoraConsig.SelectedValueChanged,
		cmbFreteTipoDev.SelectedValueChanged,
		cmbIDTransportadoraDev.SelectedValueChanged
		'
		If SitConsig = EnumFlagEstado.RegistroBloqueado AndAlso VerificaAlteracao = True Then
			'
			Dim cmb As ComboBox = DirectCast(sender, ComboBox)
			'
			Select Case cmb.Name
				'
				Case "cmbCobrancaTipo"
					VerificaAlteracao = False
					VerificaAlteracao = True
					'
				Case "cmbFreteTipoConsig"
					VerificaAlteracao = False
					cmbFreteTipoConsig.SelectedValue = IIf(IsNothing(_Consig.FreteTipo), -1, _Consig.FreteTipo)
					VerificaAlteracao = True
					'
				Case "cmbIDTransportadoraConsig"
					VerificaAlteracao = False
					cmbIDTransportadoraConsig.SelectedValue = IIf(IsNothing(_Consig.IDTransportadora), -1, _Consig.IDTransportadora)
					VerificaAlteracao = True
					'
				Case "cmbFreteTipoDev"
					VerificaAlteracao = False
					cmbFreteTipoDev.SelectedValue = IIf(IsNothing(_Devolucao.FreteTipo), -1, _Devolucao.FreteTipo)
					VerificaAlteracao = True
					'
				Case "cmbIDTransportadoraDev"
					VerificaAlteracao = False
					cmbIDTransportadoraDev.SelectedValue = IIf(IsNothing(_Devolucao.IDTransportadora), -1, _Devolucao.IDTransportadora)
					VerificaAlteracao = True
					'
			End Select
			'
			'--- emite mensagem padrao
			RegistroBloqueado()
			'
		End If
		'
	End Sub
	'	
	' FUNCAO QUE CONFERE REGISTRO BLOQUEADO E EMITE MENSAGEM PADRAO
	'-----------------------------------------------------------------------------------------------------
	Private Function RegistroBloqueado() As Boolean
		'
		If SitConsig = EnumFlagEstado.RegistroBloqueado Then
			MessageBox.Show("Esse registro de CONSIGNAÇÃO está BLOQUEADO para alterações..." & vbNewLine &
							"Não é possível adicionar produtos ou alterar algum dado!",
							"Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information)
			RegistroBloqueado = True
		Else
			RegistroBloqueado = False
		End If
		'
	End Function
	'
	Private Function CanCloseMessage() As Boolean
		'
		If Not (SitConsig = EnumFlagEstado.NovoRegistro Or SitConsig = EnumFlagEstado.Alterado) Then Return True
		'
		If AbrirDialog("Essa CONSIGNAÇÃO ainda não está CONCLUÍDA!" & vbNewLine & vbNewLine &
						"Se você fechar agora o fomulário," & vbNewLine &
						"Algumas alterações podem ser perdidas." & vbNewLine & vbNewLine &
						"Deseja Fechar assim mesmo?",
						"Fechar Consignação",
						frmDialog.DialogType.SIM_NAO,
						frmDialog.DialogIcon.Question) = vbNo Then
			'
			'--- Seleciona a TAB
			tabPrincipal.SelectedTab = vtabFrete
			'
			'--- return
			Return False
			'
		End If
		'
		'--- return
		Return True
		'
	End Function
	'	'
#End Region
	'
#Region "NOTA FISCAL CONTROLE GRID"
	'
	Private Sub ObterNotas()
		'
		Dim nBLL As New NotaFiscalBLL
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			_NotasList = nBLL.NotaFiscal_GET_PorIDCompra(_Consig.IDConsignacao)
		Catch ex As Exception
			MessageBox.Show("Um execeção ocorreu ao obter a listagem de Notas Fiscais:" & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Sub
	'
	Private Sub Preenche_Notas()
		'
		With dgvNotas
			'
			'--- limpa as colunas do datagrid
			.Columns.Clear()
			.AutoGenerateColumns = False
			'
			' altera as propriedades importantes
			.MultiSelect = False
			.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			.ColumnHeadersVisible = True
			.AllowUserToResizeRows = False
			.AllowUserToResizeColumns = False
			.RowHeadersVisible = True
			.RowHeadersWidth = 30
			.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
			.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
			.StandardTab = True
			'
			'--- configura o DataSource
			.DataSource = bindNota
			If .Rows.Count > 0 Then .CurrentCell = .Rows(.Rows.Count).Cells(1)
		End With
		'
		'--- formata as colunas do datagrid
		FormataGrid_Notas()
		'
	End Sub
	'	
	Private Sub FormataGrid_Notas()
		'
		Dim cellStyleCur As New DataGridViewCellStyle
		cellStyleCur.Format = "c"
		cellStyleCur.NullValue = Nothing
		cellStyleCur.Alignment = DataGridViewContentAlignment.MiddleRight
		'
		' (1) COLUNA CHAVE ACESSO
		With clnChaveAcesso
			.DataPropertyName = "ChaveAcesso"
			.Width = 350
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With
		'
		' (2) COLUNA NOTA TIPO DESCRIÇÃO
		With clnNotaTipo
			.DataPropertyName = "NotaTipoDesc"
			.Width = 100
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' (3) COLUNA NOTA SERIE
		With clnNotaSerie
			.DefaultCellStyle.Format = "000"
			.DataPropertyName = "NotaSerie"
			.Width = 70
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' (4) COLUNA NOTA NUMERO
		With clnNotaNumero
			.DataPropertyName = "NotaNumero"
			.Width = 70
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
		End With
		'
		' (5) COLUNA NOTA EMISSAO DATA
		With clnEmissaoData
			.DataPropertyName = "EmissaoData"
			.Width = 100
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
		End With
		'
		' (6) COLUNA NOTA VALOR
		With clnNotaValor
			.DefaultCellStyle = cellStyleCur
			.DataPropertyName = "NotaValor"
			.Width = 80
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		dgvNotas.Columns.AddRange({clnChaveAcesso, clnNotaTipo, clnNotaSerie, clnNotaNumero, clnEmissaoData, clnNotaValor})
		'
	End Sub
	'
	' COLOCA UM TEXTO QUANDO A CHAVE DE ACESSO É NULA
	Private Sub dgvVendaNotas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvNotas.CellFormatting
		'
		If e.ColumnIndex = 0 Then '--- Coluna CHAVE ACESSO
			Select Case e.Value
				Case Nothing
					e.Value = "SEM CHAVE DE ACESSO"
			End Select
		End If
		'
	End Sub

	'Private Sub dgvVendaNotas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvNotas.KeyDown
	'
	'	If e.KeyCode = Keys.Add Then
	'		e.Handled = True
	'
	'		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
	'		If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
	'
	'		Nota_Adicionar()
	'	ElseIf e.KeyCode = Keys.Enter Then
	'		e.Handled = True
	'
	'		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
	'		If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
	'
	'		Nota_Editar()
	'	ElseIf e.KeyCode = Keys.Delete Then
	'		e.Handled = True
	'
	'		If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
	'		If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
	'
	'		Nota_Excluir()
	'	End If
	'
	'End Sub
	'
	Private Sub Nota_Adicionar()
		'
		Nota_LimparControles()
		lblNota.Text = "Inserindo Nota Fiscal"
		btnNotaOK.Text = "Inserir"
		pnlNota.Visible = True
		txtChaveAcesso.Focus()
		'
	End Sub
	'
	Private Sub Nota_Editar()
		'
		If MessageBox.Show("Deseja Editar a Nota Fiscal Selecionada?", "Editar Nota Fiscal",
						   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If
		'
		Nota_PreencherControles()
		lblNota.Text = "Editando Nota Fiscal"
		btnNotaOK.Text = "Salvar"
		pnlNota.Visible = True
		txtChaveAcesso.Focus()
		'
	End Sub
	'
	Private Sub Nota_Excluir()
		' Verifica qual item da NotaList esta selecionada
		If dgvNotas.Rows.Count = 0 Then Exit Sub
		If IsNothing(dgvNotas.CurrentCell) Then Exit Sub
		'
		' --- pergunta ao usuário
		If AbrirDialog("Deseja realmente EXCLUIR a Nota Fiscal Selecionada?",
					   "Excluir Nota Fiscal",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question,
					   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then
			Exit Sub
		End If
		'
		Dim Nota As clNotaFiscal = dgvNotas.Rows(dgvNotas.CurrentCell.RowIndex).DataBoundItem
		'
		' Deleta a Nota no BD
		ExcluirNota(Nota.IDNota)
		'
	End Sub
	'
	Private Sub dgvVendaNotas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNotas.CellDoubleClick
		SendKeys.Send("{ENTER}")
	End Sub
	'
	'--- Limpar os controles de texto da Nota Fiscal
	Private Sub Nota_LimparControles()
		txtChaveAcesso.Clear()
		cmbNotaTipo.SelectedIndex = -1
		txtNotaSerie.Clear()
		txtNotaNumero.Clear()
		txtNotaValor.Clear()
		txtEmissaoData.Text = _Consig.TransacaoData
	End Sub
	'
	'--- Preencher os controles da NF pelo NotaLista
	Private Sub Nota_PreencherControles()
		'
		' Verifica qual item da NotaList esta selecionada
		If dgvNotas.Rows.Count = 0 Then Exit Sub
		If IsNothing(dgvNotas.CurrentCell) Then Exit Sub
		'
		Dim Nota As clNotaFiscal = dgvNotas.Rows(dgvNotas.CurrentCell.RowIndex).DataBoundItem
		'
		' Preenche os controles da Nota Selecionada
		txtChaveAcesso.Text = Nota.ChaveAcesso
		txtChaveAcesso.Tag = Nota.IDNota
		cmbNotaTipo.SelectedValue = Nota.NotaTipo
		txtNotaSerie.Text = Format(Nota.NotaSerie, "000")
		txtNotaNumero.Text = Format(Nota.NotaNumero, "000,000,000")
		txtNotaValor.Text = Format(Nota.NotaValor, "C")
		txtEmissaoData.Text = Nota.EmissaoData
		'
		' Deleta a Nota no BD
		ExcluirNota(Nota.IDNota)
		'
	End Sub
	'
	' FUNÇÃO PARA EXCLUIR A NOTA FISCAL DO BD
	Private Sub ExcluirNota(myIDNota As Integer)
		' Deleta a Nota no BD
		Dim NotaBLL As New NotaFiscalBLL
		Try
			NotaBLL.Excluir_Nota_Transacao(Nothing, myIDNota)
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao excluir a Nota no BD" & vbCrLf &
							ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End Try
		'
		' Retira o item da Notalist
		Dim i As Integer = _NotasList.FindIndex(Function(x) x.IDNota = myIDNota)
		'
		'--- Atualiza o ITEM da lista
		_NotasList.RemoveAt(i)
		bindNota.ResetBindings(False)
		'
		'--- Atualiza o DataGrid
		dgvNotas.DataSource = bindNota
		'
	End Sub
	'
	'--- Permitir apenas numeros na Chave de Acesso da Nota
	Private Sub txtChaveAcesso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChaveAcesso.KeyPress
		'
		If Char.IsNumber(e.KeyChar) OrElse e.KeyChar = vbBack Then
			e.Handled = False
		Else
			e.Handled = True
		End If
		'
	End Sub
	'
	'--- Cancelar INSERIR / EDITAR nota quando pressionar ESC
	Private Sub NotaControles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChaveAcesso.KeyDown,
		cmbNotaTipo.KeyDown, txtNotaSerie.KeyDown, txtNotaNumero.KeyDown, txtNotaValor.KeyDown, txtEmissaoData.KeyDown
		'
		If e.KeyCode = Keys.Escape Then
			e.Handled = True
			btnNotaCancel_Click(sender, New EventArgs)
		End If
		'
	End Sub
	'
	'--- Tirar o som da teclar ESC
	Private Sub Controle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmissaoData.KeyPress,
			cmbNotaTipo.KeyPress
		'
		If e.KeyChar = Convert.ToChar(Keys.Enter) OrElse e.KeyChar = Convert.ToChar(Keys.Escape) Then
			' stop annoying beep
			e.Handled = True
		End If
		'
	End Sub
	'
	'--- Btn Efetuar Edição ou Inserir Nota Fiscal
	Private Sub btnNotaOK_Click(sender As Object, e As EventArgs) Handles btnNotaOK.Click
		'
		' verifica os valores dos campos
		If Not VerificarNotaValores() Then Exit Sub
		'
		' CRIA nova classe Nota
		Dim newNota As New clNotaFiscal
		'
		With newNota
			.ChaveAcesso = txtChaveAcesso.Text
			.EmissaoData = txtEmissaoData.Text
			.IDTransacao = _Consig.IDConsignacao
			.NotaNumero = txtNotaNumero.Text
			.NotaSerie = txtNotaSerie.Text
			.NotaTipo = Convert.ToByte(cmbNotaTipo.SelectedValue)
			.NotaValor = txtNotaValor.Text
		End With
		'
		' INSERE NOTA NO BD
		Dim NotaBLL As New NotaFiscalBLL
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			newNota.IDNota = NotaBLL.InserirNova_Nota(newNota)
		Catch ex As Exception
			MessageBox.Show("Uma exceção inesperada ocorreu na tentativa de inserir Nova Nota Fiscal no BD..." & vbCrLf &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Insere a NOTA na lista
		_NotasList.Add(newNota)
		bindNota.ResetBindings(False)
		'
		'--- Atualiza o DataGrid
		dgvNotas.DataSource = bindNota
		bindNota.MoveLast()
		dgvNotas.Focus()
		'
		'--- Limpa os controles
		Nota_LimparControles()
		'
	End Sub
	'
	'--- Btn Cancelar a Edição da Nota Fiscal
	Private Sub btnNotaCancel_Click(sender As Object, e As EventArgs) Handles btnNotaCancel.Click
		'
		Nota_LimparControles()
		pnlNota.Visible = False
		dgvNotas.Focus()
		'
	End Sub
	'
	'--- Função que Verifica os Campos/Valores da Nota Fiscal
	Private Function VerificarNotaValores() As Boolean
		Dim F As New Utilidades

		'verifica CHAVE ACESSO
		'If Not F.VerificaControlesForm(txtChaveAcesso, "Chave de Acesso") Then Return False
		'
		If txtChaveAcesso.Text.Length > 0 AndAlso txtChaveAcesso.Text.Length <> 44 Then
			MessageBox.Show("A chave de Acesso precisa ter 44 dígitos", "Chave de Acesso",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			txtChaveAcesso.Focus()
			Return False
		End If
		'
		'verifica NOTA TIPO
		If Not F.VerificaControlesForm(cmbNotaTipo, "Tipo da Nota") Then Return False
		'
		' verifica NOTA SERIE
		If Not F.VerificaControlesForm(txtNotaSerie, "Série da Nota") Then Return False
		'
		' verifica NOTA NUMERO
		If Not F.VerificaControlesForm(txtNotaNumero, "Número da Nota") Then Return False
		'
		' verifica EMISSÃO DATA
		If Not F.VerificaControlesForm(txtEmissaoData, "Data de Emissão da Nota") Then Return False
		'
		' verifica NOTA VALOR
		If Not F.VerificaControlesForm(txtNotaValor, "Valor Total da Nota") Then Return False
		'
		Return True
		'
	End Function
	'
	'--- Ao deixar o painel da Nota fica invisivel
	Private Sub pnlNota_Leave(sender As Object, e As EventArgs) Handles pnlNota.Leave
		pnlNota.Visible = False
	End Sub
	'
	Private Sub PreencheCamposPelaChave()

		MsgBox("Implantando leitura da chave de acesso...")
		Exit Sub

		If txtChaveAcesso.Text.Length >= 44 Then
			Dim C As String = txtChaveAcesso.Text
			Dim NotaData As Date = DateSerial(C.Substring(2, 2), C.Substring(4, 2), 1)
			txtEmissaoData.Text = NotaData
		End If
	End Sub
	'
	Private Sub txtChaveAcesso_TextChanged(sender As Object, e As EventArgs) Handles txtChaveAcesso.TextChanged
		If txtChaveAcesso.Text.Length >= 44 Then PreencheCamposPelaChave()
	End Sub
	'
#End Region
	'
#Region "MENU ACAO INFERIOR"
	'	'
	'	'--- CONTROLE DO MENU ACAO INFERIOR
	'	'=====================================
	'	Private Sub tsbButtonClick(sender As Object, e As EventArgs)
	'		'
	'		DirectCast(sender, ToolStripSplitButton).ShowDropDown()
	'		'
	'	End Sub
	'	'
	'	Private Sub MenuOpen_AdHandler()
	'		'
	'		AddHandler btnImprimir.ButtonClick, AddressOf tsbButtonClick
	'		AddHandler btnImprimir.MouseHover, AddressOf tsbButtonClick
	'		'
	'	End Sub
	'	'
	'	' PROCURA COMPRA
	'	'-----------------------------------------------------------------------------------------------------
	'	Public Sub ProcuraCompra()
	'		'
	'		'--- close
	'		Me.Close()
	'		'
	'		'--- open form procura
	'		Dim frmP As New frmOperacaoEntradaProcurar
	'		OcultaMenuPrincipal()
	'		Dim fPrincipal As Form = Application.OpenForms.OfType(Of frmPrincipal)().First
	'		frmP.MdiParent = fPrincipal
	'		frmP.Show()
	'		'
	'	End Sub
	'	'
	'	Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
	'		'
	'		'--- verifica e pergunta
	'		If Not CanCloseMessage() Then Exit Sub
	'		'
	'		'--- abre procura
	'		ProcuraCompra()
	'		'
	'	End Sub
	'	'
	'	' CRIA UMA NOVA COMPRA
	'	'-----------------------------------------------------------------------------------------------------
	'	Public Sub NovaCompra()
	'		'
	'		Visible = False
	'		'
	'		Dim c As New AcaoGlobal
	'		Dim newCompra As Object = c.Compra_Nova
	'		'
	'		Me.Visible = True
	'		'
	'		If IsNothing(newCompra) Then Exit Sub
	'		'
	'		_Consig = newCompra
	'		'
	'	End Sub
	'	'
	'	Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
	'		'
	'		'--- verifica e pergunta
	'		If Not CanCloseMessage() Then Exit Sub
	'		'
	'		NovaCompra()
	'		'
	'	End Sub
	'	'
	'	' EXCLUIR COMPRA
	'	'-----------------------------------------------------------------------------------------------------
	'	Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
	'		'
	'		'--- Verifica bloqueio
	'		If RegistroBloqueado() Then Exit Sub
	'		'
	'		'--- pergunta ao usuario
	'		If AbrirDialog("Você deseja realmente excluir definitivamente essa Compra?",
	'					   "Excluir Compra",
	'						frmDialog.DialogType.SIM_NAO,
	'						frmDialog.DialogIcon.Question,
	'						frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Exit Sub
	'		'
	'		'--- Excluir Compra
	'		Try
	'			'--- Ampulheta ON
	'			Cursor = Cursors.WaitCursor
	'			'
	'			If cBLL.DeletaCompraPorID(_Consig.IDCompra, _IDFilial, New Info) Then
	'				'
	'				'--- fecha
	'				Close()
	'				MostraMenuPrincipal()
	'				'
	'			End If
	'			'
	'		Catch ex As Exception
	'			MessageBox.Show("Uma exceção ocorreu ao Excluir a Compra..." & vbNewLine &
	'							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'		Finally
	'			'
	'			'--- Info OFF
	'			Info.InfoHide()
	'			'
	'			'--- Ampulheta OFF
	'			Cursor = Cursors.Default
	'			'
	'		End Try
	'		'


	'	End Sub
	'	'
	'	' IMPRIMIR ETIQUETAS COMPRA
	'	'-----------------------------------------------------------------------------------------------------
	'	Private Sub miImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles miImprimirEtiquetas.Click
	'		'
	'		'--- CHECK IDCOMPRA
	'		If IsNothing(_Consig.IDCompra) OrElse _Consig.IDCompra = 0 Then
	'			'
	'			AbrirDialog("A Compra ainda não efetuada..." & vbNewLine &
	'						"Favor efetuar a compra para imprimir as Etiquetas.",
	'						"Efetue a Compra", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
	'			Exit Sub
	'			'
	'		End If
	'		'
	'		'--- CHECK LIST PRODUTOS COUNT
	'		If _ItensConsigList.Count = 0 Then
	'			'
	'			AbrirDialog("Essa Compra ainda não tem algum produto..." & vbNewLine &
	'						"Favor efetuar inserir produtos para imprimir as Etiquetas.",
	'						"Inserir Items", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
	'			Exit Sub
	'			'
	'		End If
	'		'
	'		Try
	'			'--- Ampulheta ON
	'			Cursor = Cursors.WaitCursor
	'			'
	'			Dim eBLL As New ProdutoEtiquetaBLL
	'			'
	'			eBLL.Insert_EtiquetasTransacao(_Consig.IDCompra)
	'			'
	'			If AbrirDialog("Etiquetas inseridas na listagem com sucesso..." & vbNewLine &
	'						   "Deseja abrir o formulário de Impressão de Etiquetas?",
	'						   "Etiquetas", frmDialog.DialogType.SIM_NAO, frmDialog.DialogIcon.Question) = DialogResult.Yes Then
	'				'
	'				Using frmE As Form = New frmProdutoEtiquetaControle(Me)
	'					'
	'					Visible = False
	'					frmE.ShowDialog()
	'					Visible = True
	'					'
	'				End Using
	'				'
	'			End If
	'			'
	'		Catch ex As Exception
	'			MessageBox.Show("Uma exceção ocorreu ao Inserir Etiquetas na Lista de Impressão..." & vbNewLine &
	'							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'		Finally
	'			'--- Ampulheta OFF
	'			Cursor = Cursors.Default
	'		End Try
	'		'
	'	End Sub
	'	'
	'	' IMPRIMIR RELATORIO
	'	'-----------------------------------------------------------------------------------------------------
	'	Private Sub miImprimirRelatorio_Click(sender As Object, e As EventArgs) Handles miImprimirRelatorio.Click
	'		MsgBox("Em Implementação")

	'	End Sub
	'	'
#End Region '/ MENU ACAO INFERIOR
	'
#Region "DESIGN VISUAL"
	'
	'-------------------------------------------------------------------------------------------------
	' QUANDO O DGVLISTAGEM ESTA SELECIONADO MUDA DE COR FUNDO
	'-------------------------------------------------------------------------------------------------
	Private Sub dgvListagem_Focus(sender As Object, e As EventArgs) Handles dgvNotas.GotFocus,
		dgvItensComprados.GotFocus, dgvDevolucao.GotFocus, dgvAPagar.GotFocus
		'
		Dim dgv As DataGridView = DirectCast(sender, DataGridView)
		dgv.BackgroundColor = Color.FromArgb(202, 215, 233)
		'
	End Sub
	'
	Private Sub dgvListagem_LostFocus(sender As Object, e As EventArgs) Handles dgvNotas.LostFocus,
		dgvItensComprados.LostFocus, dgvDevolucao.LostFocus, dgvAPagar.LostFocus
		'
		Dim dgv As DataGridView = DirectCast(sender, DataGridView)
		dgv.BackgroundColor = Color.LightGray
		'
	End Sub
	'
#End Region '/ DESIGN VISUAL
	'
#Region "LOAD | CREATE DEVOLUCAO"
	'
	Private Sub ObterDevolucao()
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			If _Consig.IDDevolucao IsNot Nothing Then
				_Devolucao = cBLL.GetDevolucao(_Consig.IDDevolucao)
			Else
				_Devolucao = Nothing
			End If
			'
			'--- Atualiza o label TOTAL
			TotalProdutosDevolucao()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Obter a Devolução da Consignação..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub ObterItensDevolucao()
		'
		Try
			'
			Dim tBLL As New TransacaoItemBLL
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			If _Consig.IDDevolucao IsNot Nothing Then
				_ItensDevList = tBLL.GetTransacaoItens_List(_Consig.IDDevolucao, _IDFilial)
			Else
				_ItensDevList.Clear()
			End If
			'
			'--- Atualiza o label TOTAL
			TotalProdutosConsignacao()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Obter os itens da Devolução da Consignação..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
#End Region '/ LOAD | CREATE DEVOLUCAO
	'





	'
	'
	'--- ON VALIDATED FIELDS CHECK TOTAL GERAL
	'----------------------------------------------------------------------------------
	Private Sub txtFreteCobrado_Validated(sender As Object, e As EventArgs) Handles txtFreteCobrado.Validated,
			txtDescontos.Validated, txtICMSValor.Validated, txtDespesas.Validated
		'
		TotalAPagar()
		'
	End Sub
	'
	'--- ON CHANGE TAB CHECK REGISTRO ALTERADO AND SAVE
	'----------------------------------------------------------------------------------
	Private Sub vtabAPagar_Leave(sender As Object, e As EventArgs) Handles vtabAPagar.Leave
		'
		If _Consig.RegistroAlterado Then
			SalvaRegistroConsignacao()
		End If
		'
	End Sub
	'
End Class
