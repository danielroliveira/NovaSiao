Imports System.ComponentModel
'
Public Class clConsignacao : Implements IEditableObject
	'
#Region "ESTRUTURA DOS DADOS"
	Structure ConsigStructure ' alguns usam FRIEND em vez de DIM
		'
		' TBLTRANSACAO =====================================================
		Dim _IDConsignacao As Integer?
		Dim _IDPessoaDestino As Integer
		' Cadastro As String
		' CNP As String
		' UF As String
		' Cidade As String
		Dim _IDPessoaOrigem As Integer
		' Dim _ApelidoFilial As String
		Dim _IDOperacao As Byte
		Dim _IDSituacao As Byte
		Dim _IDUser As Integer
		Dim _CFOP As Int16
		Dim _TransacaoData As Date
		'
		' TBLCOMPRA =====================================================
		Dim _FreteTipo As Byte ' 0="Sem Frete" | 1="Emitente" | 2="Destinatário" | 3=Reembolso | 4="A Cobrar"
		Dim _FreteCobrado As Decimal
		Dim _ICMSValor As Decimal
		Dim _Despesas As Decimal
		Dim _Descontos As Decimal
		Dim _TotalConsignacao As Decimal
		Dim _Observacao As String
		'
		' TBLFRETE =====================================================
		Dim _IDTransportadora As Integer?
		' Transportadora As String
		Dim _FreteValor As Decimal?
		Dim _Volumes As Int16?
		Dim _IDFreteDespesa As Integer?
		'
	End Structure
#End Region
	'
#Region "PRIVATE VARIABLES"
	Private CData As ConsigStructure
	Private backupData As ConsigStructure
	Private inTxn As Boolean = False
#End Region
	'
#Region "IMPLEMENTS EVENTS"
	Public Sub New()
		CData = New ConsigStructure()
		With CData
			._IDConsignacao = Nothing
			._TransacaoData = DateTime.Today
			._IDSituacao = 0
			._FreteTipo = 0
			._TotalConsignacao = 0
			._FreteCobrado = 0
			._ICMSValor = 0
			._Descontos = 0
			._Despesas = 0
		End With
	End Sub
	'
	'-- IMPLEMENTS IEditableObject
	Public Sub BeginEdit() Implements IEditableObject.BeginEdit
		If Not inTxn Then
			Me.backupData = CData
			inTxn = True
		End If
	End Sub
	'
	Public Sub CancelEdit() Implements IEditableObject.CancelEdit
		If inTxn Then
			Me.CData = backupData
			inTxn = False
		End If
	End Sub
	'
	Public Sub EndEdit() Implements IEditableObject.EndEdit
		If inTxn Then
			backupData = New ConsigStructure()
			inTxn = False
		End If
	End Sub
	'
	'-- _EVENTO PUBLIC AOALTERAR
	Public Event AoAlterar()
	'
	Public Overrides Function ToString() As String
		Return IDConsignacao.ToString
	End Function
	'
	Public ReadOnly Property RegistroAlterado As Boolean
		Get
			Return inTxn
		End Get
	End Property
	'
#End Region
	'
#Region "PROPRIEDADES"
	'
	'===========================================================================================
	'--- TBLTRANSACAO
	'===========================================================================================
	'
	Property IDConsignacao() As Nullable(Of Integer)
		Get
			Return CData._IDConsignacao
		End Get
		Set(value As Nullable(Of Integer))
			CData._IDConsignacao = value
		End Set
	End Property
	'
	Property IDPessoaDestino() As Integer
		Get
			Return CData._IDPessoaDestino
		End Get
		Set(value As Integer)
			If Not IsNothing(CData._IDPessoaDestino) AndAlso value <> CData._IDPessoaDestino Then
				RaiseEvent AoAlterar()
			End If
			CData._IDPessoaDestino = value
		End Set
	End Property
	'
	'--- PROPRIEDADES SOMENTE LEITURA
	Public Property Cadastro
	Public Property CNP
	Public Property UF
	Public Property Cidade
	Public Property ApelidoFilial
	'
	'--- Propriedade IDPessoaOrigem
	Public Property IDPessoaOrigem() As Integer?
		Get
			Return CData._IDPessoaOrigem
		End Get
		Set(ByVal value As Integer?)
			If value <> CData._IDPessoaOrigem Then
				RaiseEvent AoAlterar()
			End If
			CData._IDPessoaOrigem = value
		End Set
	End Property
	'
	'--- Propriedade IDOperacao
	Public Property IDOperacao() As Byte
		Get
			Return CData._IDOperacao
		End Get
		Set(ByVal value As Byte)
			If value <> CData._IDOperacao Then
				RaiseEvent AoAlterar()
			End If
			CData._IDOperacao = value
		End Set
	End Property
	'
	Property IDSituacao() As Byte
		Get
			Return CData._IDSituacao
		End Get
		Set(value As Byte)
			If Not IsNothing(CData._IDSituacao) AndAlso value <> CData._IDSituacao Then
				RaiseEvent AoAlterar()
			End If
			CData._IDSituacao = value
		End Set
	End Property
	'
	Property Situacao As String ' texto da Situacao da Venda
	'
	Property IDUser() As Integer
		Get
			Return CData._IDUser
		End Get
		Set(value As Integer)
			If Not IsNothing(CData._IDUser) AndAlso value <> CData._IDUser Then
				RaiseEvent AoAlterar()
			End If
			CData._IDUser = value
		End Set
	End Property
	'
	Property CFOP() As Int16
		Get
			Return CData._CFOP
		End Get
		Set(value As Int16)
			If Not IsNothing(CData._CFOP) AndAlso value <> CData._CFOP Then
				RaiseEvent AoAlterar()
			End If
			CData._CFOP = value
		End Set
	End Property
	'
	Property TransacaoData() As Date
		Get
			Return CData._TransacaoData
		End Get
		Set(value As Date)
			If Not IsNothing(CData._TransacaoData) AndAlso value <> CData._TransacaoData Then
				RaiseEvent AoAlterar()
			End If
			CData._TransacaoData = value
		End Set
	End Property
	'
	'===========================================================================================
	'--- TBLCONSIGNACAO
	'===========================================================================================
	'
	Property FreteTipo() As Byte
		Get
			Return CData._FreteTipo
		End Get
		Set(value As Byte)
			If Not IsNothing(CData._FreteTipo) AndAlso value <> CData._FreteTipo Then
				RaiseEvent AoAlterar()
			End If
			CData._FreteTipo = value
		End Set
	End Property
	'
	'--- Propriedade FreteCobrado
	Public Property FreteCobrado() As Decimal
		Get
			Return CData._FreteCobrado
		End Get
		Set(ByVal value As Decimal)
			If value <> CData._FreteCobrado Then
				RaiseEvent AoAlterar()
			End If
			CData._FreteCobrado = value
		End Set
	End Property
	'
	'--- Propriedade ICMSValor
	Public Property ICMSValor() As Decimal
		Get
			Return CData._ICMSValor
		End Get
		Set(ByVal value As Decimal)
			If value <> CData._ICMSValor Then
				RaiseEvent AoAlterar()
			End If
			CData._ICMSValor = value
		End Set
	End Property
	'
	'--- Propriedade Despesas
	Public Property Despesas() As Decimal
		Get
			Return CData._Despesas
		End Get
		Set(ByVal value As Decimal)
			If value <> CData._Despesas Then
				RaiseEvent AoAlterar()
			End If
			CData._Despesas = value
		End Set
	End Property
	'
	'--- Propriedade Descontos
	Public Property Descontos() As Decimal
		Get
			Return CData._Descontos
		End Get
		Set(ByVal value As Decimal)
			If value <> CData._Descontos Then
				RaiseEvent AoAlterar()
			End If
			CData._Descontos = value
		End Set
	End Property
	'
	Property TotalConsignacao() As Decimal
		Get
			Return CData._TotalConsignacao
		End Get
		Set(value As Decimal)
			If Not IsNothing(CData._TotalConsignacao) AndAlso value <> CData._TotalConsignacao Then
				RaiseEvent AoAlterar()
			End If
			CData._TotalConsignacao = value
		End Set
	End Property
	'
	Property Observacao As String
		Get
			Return CData._Observacao
		End Get
		Set(value As String)
			If Not IsNothing(CData._Observacao) AndAlso value <> CData._Observacao Then
				RaiseEvent AoAlterar()
			End If
			CData._Observacao = value
		End Set
	End Property
	'
	'===========================================================================================
	'--- TBLVENDAFRETE
	'===========================================================================================
	'
	'--- Propriedade IDTransportadora
	Public Property IDTransportadora() As Integer?
		Get
			Return CData._IDTransportadora
		End Get
		Set(ByVal value As Integer?)
			If Not IsNothing(CData._IDTransportadora) Then
				If value <> CData._IDTransportadora Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._IDTransportadora = value
		End Set
	End Property
	'
	Public Property Transportadora
	'
	'--- Propriedade FreteValor
	Public Property FreteValor() As Decimal?
		Get
			Return CData._FreteValor
		End Get
		Set(ByVal value As Decimal?)
			If Not IsNothing(CData._FreteValor) Then
				If value <> CData._FreteValor Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._FreteValor = value
		End Set
	End Property
	'
	'--- Propriedade Volumes
	Public Property Volumes() As Int16?
		Get
			Return CData._Volumes
		End Get
		Set(ByVal value As Int16?)
			If Not IsNothing(CData._Volumes) Then
				If value <> CData._Volumes Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._Volumes = value
		End Set
	End Property
	'
	'--- Propriedade IDFreteDespesa do Frete
	Public Property IDFreteDespesa() As Integer?
		Get
			Return CData._IDFreteDespesa
		End Get
		Set(ByVal value As Integer?)
			If Not IsNothing(CData._IDFreteDespesa) Then
				If value <> CData._IDFreteDespesa Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._IDFreteDespesa = value
		End Set
	End Property
	'
#End Region
	'
End Class
'
Public Class clConsignacaoDevolucao : Implements IEditableObject
	'
#Region "ESTRUTURA DOS DADOS"
	Structure ConsigStructure ' alguns usam FRIEND em vez de DIM
		'
		' TBLTRANSACAO =====================================================
		Dim _IDConsignacaoDevolucao As Integer?
		Dim _IDPessoaDestino As Integer
		' Cadastro As String
		' CNP As String
		' UF As String
		' Cidade As String
		Dim _IDPessoaOrigem As Integer
		' Dim _ApelidoFilial As String
		Dim _IDOperacao As Byte
		Dim _IDSituacao As Byte
		Dim _IDUser As Integer
		Dim _CFOP As Int16
		Dim _TransacaoData As Date
		'
		' TBLCONSIGNACAO DEVOLUCAO =====================================================
		Dim _IDConsignacaoOrigem As Integer
		Dim _ValorProdutos As Decimal
		Dim _ValorAcrescimos As Decimal
		Dim _ValorDescontos As Decimal
		Dim _TotalDevolucao As Decimal
		Dim _Observacao As String
		'
		' TBLFRETE =====================================================
		' Transportadora As String
		Dim _IDTransportadora As Integer?
		Dim _FreteTipo As Byte ' 0="Sem Frete" | 1="Emitente" | 2="Destinatário" | 3=Reembolso | 4="A Cobrar"
		Dim _FreteValor As Decimal?
		Dim _Volumes As Int16?
		Dim _IDFreteDespesa As Integer?
		'
	End Structure
#End Region
	'
#Region "PRIVATE VARIABLES"
	Private CData As ConsigStructure
	Private backupData As ConsigStructure
	Private inTxn As Boolean = False
#End Region
	'
#Region "IMPLEMENTS EVENTS"
	Public Sub New()
		CData = New ConsigStructure()
		With CData
			._IDConsignacaoDevolucao = Nothing
			._TransacaoData = DateTime.Today
			._IDSituacao = 0
			._FreteTipo = 0
			._TotalDevolucao = 0
			._ValorDescontos = 0
			._ValorAcrescimos = 0
			._ValorProdutos = 0
		End With
	End Sub
	'
	'-- IMPLEMENTS IEditableObject
	Public Sub BeginEdit() Implements IEditableObject.BeginEdit
		If Not inTxn Then
			Me.backupData = CData
			inTxn = True
		End If
	End Sub
	'
	Public Sub CancelEdit() Implements IEditableObject.CancelEdit
		If inTxn Then
			Me.CData = backupData
			inTxn = False
		End If
	End Sub
	'
	Public Sub EndEdit() Implements IEditableObject.EndEdit
		If inTxn Then
			backupData = New ConsigStructure()
			inTxn = False
		End If
	End Sub
	'
	'-- _EVENTO PUBLIC AOALTERAR
	Public Event AoAlterar()
	'
	Public Overrides Function ToString() As String
		Return IDConsignacaoDevolucao.ToString
	End Function
	'
	Public ReadOnly Property RegistroAlterado As Boolean
		Get
			Return inTxn
		End Get
	End Property
	'
#End Region
	'
#Region "PROPRIEDADES"
	'
	'===========================================================================================
	'--- TBLTRANSACAO
	'===========================================================================================
	'
	Property IDConsignacaoDevolucao() As Nullable(Of Integer)
		Get
			Return CData._IDConsignacaoDevolucao
		End Get
		Set(value As Nullable(Of Integer))
			CData._IDConsignacaoDevolucao = value
		End Set
	End Property
	'
	Property IDPessoaDestino() As Integer
		Get
			Return CData._IDPessoaDestino
		End Get
		Set(value As Integer)
			If Not IsNothing(CData._IDPessoaDestino) AndAlso value <> CData._IDPessoaDestino Then
				RaiseEvent AoAlterar()
			End If
			CData._IDPessoaDestino = value
		End Set
	End Property
	'
	'--- PROPRIEDADES SOMENTE LEITURA
	Public Property Cadastro
	Public Property CNP
	Public Property UF
	Public Property Cidade
	Public Property ApelidoFilial
	'
	'--- Propriedade IDPessoaOrigem
	Public Property IDPessoaOrigem() As Integer?
		Get
			Return CData._IDPessoaOrigem
		End Get
		Set(ByVal value As Integer?)
			If value <> CData._IDPessoaOrigem Then
				RaiseEvent AoAlterar()
			End If
			CData._IDPessoaOrigem = value
		End Set
	End Property
	'
	'--- Propriedade IDOperacao
	Public Property IDOperacao() As Byte
		Get
			Return CData._IDOperacao
		End Get
		Set(ByVal value As Byte)
			If value <> CData._IDOperacao Then
				RaiseEvent AoAlterar()
			End If
			CData._IDOperacao = value
		End Set
	End Property
	'
	Property IDSituacao() As Byte
		Get
			Return CData._IDSituacao
		End Get
		Set(value As Byte)
			If Not IsNothing(CData._IDSituacao) AndAlso value <> CData._IDSituacao Then
				RaiseEvent AoAlterar()
			End If
			CData._IDSituacao = value
		End Set
	End Property
	'
	Property Situacao As String ' texto da Situacao da Venda
	'
	Property IDUser() As Integer
		Get
			Return CData._IDUser
		End Get
		Set(value As Integer)
			If Not IsNothing(CData._IDUser) AndAlso value <> CData._IDUser Then
				RaiseEvent AoAlterar()
			End If
			CData._IDUser = value
		End Set
	End Property
	'
	Property CFOP() As Int16
		Get
			Return CData._CFOP
		End Get
		Set(value As Int16)
			If Not IsNothing(CData._CFOP) AndAlso value <> CData._CFOP Then
				RaiseEvent AoAlterar()
			End If
			CData._CFOP = value
		End Set
	End Property
	'
	Property TransacaoData() As Date
		Get
			Return CData._TransacaoData
		End Get
		Set(value As Date)
			If Not IsNothing(CData._TransacaoData) AndAlso value <> CData._TransacaoData Then
				RaiseEvent AoAlterar()
			End If
			CData._TransacaoData = value
		End Set
	End Property
	'
	'===========================================================================================
	'--- TBLCONSIGNACAO
	'===========================================================================================
	'
	'--- Propriedade IDConsignacaoOrigem
	'------------------------------------------------------
	Public Property IDConsignacaoOrigem() As Integer
		Get
			Return CData._IDConsignacaoOrigem
		End Get
		Set(ByVal value As Integer)
			If value <> CData._IDConsignacaoOrigem Then
				RaiseEvent AoAlterar()
			End If
			CData._IDConsignacaoOrigem = value
		End Set
	End Property
	'
	Property FreteTipo() As Byte
		Get
			Return CData._FreteTipo
		End Get
		Set(value As Byte)
			If Not IsNothing(CData._FreteTipo) AndAlso value <> CData._FreteTipo Then
				RaiseEvent AoAlterar()
			End If
			CData._FreteTipo = value
		End Set
	End Property
	'
	'--- Propriedade ValorProdutos
	Public Property ValorProdutos() As Decimal
		Get
			Return CData._ValorProdutos
		End Get
		Set(ByVal value As Decimal)
			If value <> CData._ValorProdutos Then
				RaiseEvent AoAlterar()
			End If
			CData._ValorProdutos = value
		End Set
	End Property
	'
	'--- Propriedade ValorAcrescimos
	Public Property ValorAcrescimos() As Decimal
		Get
			Return CData._ValorAcrescimos
		End Get
		Set(ByVal value As Decimal)
			If value <> CData._ValorAcrescimos Then
				RaiseEvent AoAlterar()
			End If
			CData._ValorAcrescimos = value
		End Set
	End Property
	'
	'--- Propriedade Descontos
	Public Property ValorDescontos() As Decimal
		Get
			Return CData._ValorDescontos
		End Get
		Set(ByVal value As Decimal)
			If value <> CData._ValorDescontos Then
				RaiseEvent AoAlterar()
			End If
			CData._ValorDescontos = value
		End Set
	End Property
	'
	Property TotalDevolucao() As Decimal
		Get
			Return CData._TotalDevolucao
		End Get
		Set(value As Decimal)
			If Not IsNothing(CData._TotalDevolucao) AndAlso value <> CData._TotalDevolucao Then
				RaiseEvent AoAlterar()
			End If
			CData._TotalDevolucao = value
		End Set
	End Property
	'
	Property Observacao As String
		Get
			Return CData._Observacao
		End Get
		Set(value As String)
			If Not IsNothing(CData._Observacao) AndAlso value <> CData._Observacao Then
				RaiseEvent AoAlterar()
			End If
			CData._Observacao = value
		End Set
	End Property
	'
	'===========================================================================================
	'--- TBLVENDAFRETE
	'===========================================================================================
	'
	'--- Propriedade IDTransportadora
	Public Property IDTransportadora() As Integer?
		Get
			Return CData._IDTransportadora
		End Get
		Set(ByVal value As Integer?)
			If Not IsNothing(CData._IDTransportadora) Then
				If value <> CData._IDTransportadora Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._IDTransportadora = value
		End Set
	End Property
	'
	Public Property Transportadora
	'
	'--- Propriedade FreteValor
	Public Property FreteValor() As Decimal?
		Get
			Return CData._FreteValor
		End Get
		Set(ByVal value As Decimal?)
			If Not IsNothing(CData._FreteValor) Then
				If value <> CData._FreteValor Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._FreteValor = value
		End Set
	End Property
	'
	'--- Propriedade Volumes
	Public Property Volumes() As Int16?
		Get
			Return CData._Volumes
		End Get
		Set(ByVal value As Int16?)
			If Not IsNothing(CData._Volumes) Then
				If value <> CData._Volumes Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._Volumes = value
		End Set
	End Property
	'
	'--- Propriedade IDFreteDespesa do Frete
	Public Property IDFreteDespesa() As Integer?
		Get
			Return CData._IDFreteDespesa
		End Get
		Set(ByVal value As Integer?)
			If Not IsNothing(CData._IDFreteDespesa) Then
				If value <> CData._IDFreteDespesa Then
					RaiseEvent AoAlterar()
				End If
			End If
			CData._IDFreteDespesa = value
		End Set
	End Property
	'
#End Region
	'
End Class
'
Public Class clConsignacaoCompra
	'
	Sub New(IDConsignacao As Integer)
		_IDConsignacao = IDConsignacao
		IDConsignacaoCompra = Nothing
		CobrancaTipo = 0
		Despesas = 0
		Descontos = 0
		TotalCompra = 0
	End Sub
	'
	Property IDConsignacaoCompra As Integer?
	'
	Property IDConsignacao As Integer
	'
	Property CobrancaTipo As Byte 'tinyint ==> 0 = SemCobrança | 1 = A Vista | 2 = Parcelada
	'
	Property Despesas As Decimal
	'
	Property Descontos As Decimal
	'
	Property TotalCompra As Decimal
	'
	Property IDSituacao As Byte
	'
	ReadOnly Property CobrancaTipoTexto As String
		Get
			Select Case CobrancaTipo
				Case 0
					Return "Sem Cobrança"
				Case 1
					Return "A Vista"
				Case 2
					Return "Parcelada"
				Case Else
					Return ""
			End Select
		End Get
	End Property
	'
End Class
'
Public Class clConsignacaoCompraItem : Implements IEditableObject
	'
#Region "ESTRUTURA DOS DADOS"
	'
	Structure ItensDados ' alguns usam FRIEND em vez de DIM
		'--- Itens da tblTransacaoItens
		Dim _IDItem As Integer?
		Dim _IDConsignacaoCompra As Integer?
		Dim _IDProduto As Integer?
		Dim _Produto As String
		Dim _PCompra As Double
		Dim _PVenda As Double
		Dim _RGProduto As Integer?
		Dim _Quantidade As Integer
		Dim _Preco As Double
		Dim _Desconto As Double
		Dim _CodBarrasA As String
		Dim _DescontoCompra As Double
		Dim _ProdutoAtivo As Boolean?
		'--- Itens Calculados
		'   SubTotal
		'   Total
	End Structure
#End Region
	'
#Region "PRIVATE VARIABLES"
	Private itemData As ItensDados
	Private backupData As ItensDados
	Private inTxn As Boolean = False
#End Region
	'
#Region "IMPLEMENTS EVENTS"
	Public Sub New()
		itemData = New ItensDados()
		With itemData
			._IDItem = Nothing
			._IDConsignacaoCompra = Nothing
			._IDProduto = Nothing
			._Preco = 0
			._Quantidade = 1
			._Desconto = 0
			._DescontoCompra = 0
			._PCompra = 0
			._PVenda = 0
			._Produto = String.Empty
			._CodBarrasA = String.Empty
			._ProdutoAtivo = Nothing
		End With
	End Sub
	'
	'-- IMPLEMENTS IEditableObject
	Public Sub BeginEdit() Implements IEditableObject.BeginEdit
		If Not inTxn Then
			Me.backupData = itemData
			inTxn = True
		End If
	End Sub
	'
	Public Sub CancelEdit() Implements IEditableObject.CancelEdit
		If inTxn Then
			Me.itemData = backupData
			inTxn = False
		End If
	End Sub
	'
	Public Sub EndEdit() Implements IEditableObject.EndEdit
		If inTxn Then
			backupData = New ItensDados()
			inTxn = False
		End If
	End Sub
	'
	'-- _EVENTO PUBLIC AOALTERAR
	Public Event AoAlterar()
	'
	Public Event AoAlterarRGProduto()
	'
	Public Overrides Function ToString() As String
		Return IDProduto.ToString & " - " & Produto.ToString
	End Function
	'
	Public ReadOnly Property RegistroAlterado As Boolean
		Get
			Return inTxn
		End Get
	End Property
	'
#End Region
	'
#Region "PROPRIEDADES"
	'
	Property IDItem() As Integer?
		Get
			Return itemData._IDItem
		End Get
		Set(ByVal value As Nullable(Of Integer))
			itemData._IDItem = value
		End Set
	End Property
	'
	Property IDConsignacaoCompra() As Integer?
		Get
			Return itemData._IDConsignacaoCompra
		End Get
		Set(value As Nullable(Of Integer))
			If Not IsNothing(itemData._IDConsignacaoCompra) Then
				RaiseEvent AoAlterar()
			End If
			itemData._IDConsignacaoCompra = value
		End Set
	End Property
	'
	'--- Propriedade IDProduto
	Public Property IDProduto() As Integer?
		Get
			Return itemData._IDProduto
		End Get
		Set(ByVal value As Integer?)
			If value <> itemData._IDProduto Then
				RaiseEvent AoAlterar()
			End If
			itemData._IDProduto = value
		End Set
	End Property
	'
	'--- Propriedade Preco
	Public Property Preco() As Double
		Get
			Return itemData._Preco
		End Get
		Set(ByVal value As Double)
			If value <> itemData._Preco Then
				RaiseEvent AoAlterar()
			End If
			itemData._Preco = value
		End Set
	End Property
	'
	Property Quantidade() As Integer
		Get
			Return itemData._Quantidade
		End Get
		Set(value As Integer)
			If Not IsNothing(itemData._Quantidade) Then
				If value <> itemData._Quantidade Then
					RaiseEvent AoAlterar()
				End If
			End If
			itemData._Quantidade = value
		End Set
	End Property
	'
	Property Desconto() As Double
		Get
			Return itemData._Desconto
		End Get
		Set(value As Double)
			If Not IsNothing(itemData._Desconto) Then
				RaiseEvent AoAlterar()
			End If
			itemData._Desconto = value

		End Set
	End Property
	'
	'=================================================================================================
	'Propriedades DA TBLPRODUTO
	'=================================================================================================
	'
	Property RGProduto() As Integer?
		Get
			Return itemData._RGProduto
		End Get
		Set(value As Nullable(Of Integer))
			If Not IsNothing(itemData._RGProduto) Then
				RaiseEvent AoAlterar()
			End If
			itemData._RGProduto = value
			RaiseEvent AoAlterarRGProduto()
		End Set
	End Property
	'
	'--- Propriedade Produto
	Public Property Produto() As String
		Get
			Return itemData._Produto
		End Get
		Set(ByVal value As String)
			itemData._Produto = value
		End Set
	End Property
	'
	'--- Propriedade CodBarrasA
	Public Property CodBarrasA() As String
		Get
			Return itemData._CodBarrasA
		End Get
		Set(ByVal value As String)
			itemData._CodBarrasA = value
		End Set
	End Property
	'
	'--- Propriedade PVenda
	Public Property PVenda() As Double
		Get
			Return itemData._PVenda
		End Get
		Set(ByVal value As Double)
			If value <> itemData._PVenda Then
				RaiseEvent AoAlterar()
			End If
			itemData._PVenda = value
		End Set
	End Property
	'
	'--- Propriedade PCompra
	Public Property PCompra() As Double
		Get
			Return itemData._PCompra
		End Get
		Set(ByVal value As Double)
			If value <> itemData._PCompra Then
				RaiseEvent AoAlterar()
			End If
			itemData._PCompra = value
		End Set
	End Property
	'
	'--- Propriedade DescontoCompra
	'------------------------------------------------------
	Public Property DescontoCompra() As Double
		Get
			Return itemData._DescontoCompra
		End Get
		Set(ByVal value As Double)
			If value <> itemData._DescontoCompra Then
				RaiseEvent AoAlterar()
			End If
			itemData._DescontoCompra = value
		End Set
	End Property
	'
	'--- Propriedade ProdutoAtivo
	Public Property ProdutoAtivo() As Boolean?
		Get
			Return itemData._ProdutoAtivo
		End Get
		Set(ByVal value As Boolean?)
			itemData._ProdutoAtivo = value
		End Set
	End Property
	'
	'=================================================================================================
	'Propriedades calculadas
	'=================================================================================================
	ReadOnly Property SubTotal() As Double
		Get
			Return itemData._Quantidade * itemData._Preco
		End Get
	End Property
	'
	ReadOnly Property Total() As Double
		Get
			Return itemData._Quantidade * itemData._Preco * (100 - itemData._Desconto) / 100
		End Get
	End Property
	'
#End Region
	'
End Class