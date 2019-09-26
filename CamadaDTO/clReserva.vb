Imports System.ComponentModel
'
' CLASSE RESERVA
'==================================================================================
Public Class clReserva
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure ReservaDados ' alguns usam FRIEND em vez de DIM
        '
        '--- Dados da tblReserva
        Dim _IDReserva As Integer?
        Dim _ReservaData As Date?
        Dim _IDFuncionario As Integer?
        Dim _ApelidoFuncionario As String
        Dim _IDFilial As Integer?
		Dim _ApelidoFilial As String
		Dim _IDClienteSimples As Integer?
		'--- tblClienteSimples
		'Dim _ClienteNome As String
		'Dim _TelefoneA As String
		'Dim _TelefoneB As String
		'Dim _TemWhatsapp As Boolean
		'Dim _ClienteEmail As String
		Dim _ProdutoConhecido As Boolean
        '--- tblProduto
        Dim _IDProduto As Integer?
        Dim _RGProduto As Integer?
        Dim _Produto As String
        Dim _PVenda As Decimal?
        Dim _Autor As String
        Dim _IDFornecedor As Integer?
        Dim _Fornecedor As String
        Dim _IDFabricante As Integer?
        Dim _Fabricante As String
        Dim _IDProdutoTipo As Integer?
        Dim _ProdutoTipo As String
        '---
        Dim _IDSituacaoReserva As Byte?
        Dim _SituacaoReserva As String
        Dim _ConclusaoData As Date?
        Dim _Observacao As String
		Dim _ReservaAtiva As Boolean
		Dim _ValorAntecipado As Decimal?
		'
		Dim _IDPedido As Integer?
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private RData As ReservaDados
    Private backupData As ReservaDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        RData = New ReservaDados()
        With RData
            ._IDReserva = Nothing
            ._ProdutoConhecido = True
			._IDProduto = Nothing
			._IDClienteSimples = Nothing
			._RGProduto = Nothing
			._IDSituacaoReserva = 1
			._ReservaData = Today.ToShortDateString
            ._IDPedido = Nothing
        End With
    End Sub
    '
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = RData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.RData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New ReservaDados()
            inTxn = False
        End If
    End Sub
    '
    '_EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public Overrides Function ToString() As String
        Return Produto.ToString
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
    '--- Propriedade IDReserva
    Public Property IDReserva() As Integer?
        Get
            Return RData._IDReserva
        End Get
        Set(ByVal value As Integer?)
            If value <> RData._IDReserva Then
                RaiseEvent AoAlterar()
            End If
            RData._IDReserva = value
        End Set
    End Property
    '
    '--- Propriedade ReservaData
    Public Property ReservaData() As Date?
        Get
            Return RData._ReservaData
        End Get
        Set(ByVal value As Date?)
            If value <> RData._ReservaData Then
                RaiseEvent AoAlterar()
            End If
            RData._ReservaData = value
        End Set
    End Property
    '
    '--- Propriedade IDFuncionario
    Public Property IDFuncionario() As Integer?
        Get
            Return RData._IDFuncionario
        End Get
        Set(ByVal value As Integer?)
            If value <> RData._IDFuncionario Then
                RaiseEvent AoAlterar()
            End If
            RData._IDFuncionario = value
        End Set
    End Property
    '
    '--- Propriedade Funcionario
    Public Property ApelidoFuncionario() As String
        Get
            Return RData._ApelidoFuncionario
        End Get
        Set(ByVal value As String)
            If value <> RData._ApelidoFuncionario Then
                RaiseEvent AoAlterar()
            End If
            RData._ApelidoFuncionario = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    Public Property IDFilial() As Integer?
        Get
            Return RData._IDFilial
        End Get
        Set(ByVal value As Integer?)
            If value <> RData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            RData._IDFilial = value
        End Set
    End Property
	'
	'--- Propriedade ApelidoFilial
	Public Property ApelidoFilial() As String
		Get
			Return RData._ApelidoFilial
		End Get
		Set(ByVal value As String)
			If value <> RData._ApelidoFilial Then
				RaiseEvent AoAlterar()
			End If
			RData._ApelidoFilial = value
		End Set
	End Property
	'
	'--- Propriedade IDClienteSimples
	'------------------------------------------------------
	Public Property IDClienteSimples() As Integer?
		Get
			Return RData._IDClienteSimples
		End Get
		Set(ByVal value As Integer?)
			If value <> RData._IDClienteSimples Then
				RaiseEvent AoAlterar()
			End If
			RData._IDClienteSimples = value
		End Set
	End Property
	'
	'--- Propriedade ClienteNome
	Public Property ClienteNome() As String
	'
	'--- Propriedade TelefoneA
	Public Property TelefoneA() As String
	'
	'--- Propriedade TelefoneB
	Public Property TelefoneB() As String
	'
	'--- Propriedade TemWathsapp
	Public Property TemWhatsapp() As Boolean
	'
	'--- Propriedade ClienteEmail
	Public Property ClienteEmail() As String
	'
	'--- Propriedade ProdutoConhecido
	Public Property ProdutoConhecido() As Boolean
        Get
            Return RData._ProdutoConhecido
        End Get
        Set(ByVal value As Boolean)
            If value <> RData._ProdutoConhecido Then
                RaiseEvent AoAlterar()
            End If
            RData._ProdutoConhecido = value
        End Set
    End Property
    '
    '--- Propriedade IDProduto
    Public Property IDProduto() As Integer?
        Get
            Return RData._IDProduto
        End Get
        Set(value As Integer?)
            If value <> RData._IDProduto Then
                RaiseEvent AoAlterar()
            End If
            RData._IDProduto = value
        End Set
    End Property
    '
    '--- Propriedade RGProduto
    '------------------------------------------------------
    Public Property RGProduto() As Integer?
        Get
            Return RData._RGProduto
        End Get
        Set(ByVal value As Integer?)
            If value <> RData._RGProduto Then
                RaiseEvent AoAlterar()
            End If
            RData._RGProduto = value
        End Set
    End Property
    '
    Property Produto() As String
        Get
            Return RData._Produto
        End Get
        Set(value As String)
            If Not IsNothing(RData._Produto) Then
                If value <> RData._Produto Then
                    RaiseEvent AoAlterar()
                End If
            End If
            RData._Produto = value
        End Set
    End Property
    '
    '--- Propriedade PVenda
    Public Property PVenda() As Decimal?
        Get
            Return RData._PVenda
        End Get
        Set(ByVal value As Decimal?)
            If value <> RData._PVenda Then
                RaiseEvent AoAlterar()
            End If
            RData._PVenda = value
        End Set
    End Property
    '
    Property Autor() As String
        Get
            Return RData._Autor
        End Get
        Set(value As String)
            If Not IsNothing(RData._Autor) Then
                If value <> RData._Autor Then
                    RaiseEvent AoAlterar()
                End If
            End If
            RData._Autor = value
        End Set
    End Property
    '
    '--- Propriedade IDFornecedor
    Public Property IDFornecedor() As Integer?
        Get
            Return RData._IDFornecedor
        End Get
        Set(ByVal value As Integer?)
            If value <> RData._IDFornecedor Then
                RaiseEvent AoAlterar()
            End If
            RData._IDFornecedor = value
        End Set
    End Property
    '
    '--- Propriedade Fornecedor
    Public Property Fornecedor() As String
        Get
            Return RData._Fornecedor
        End Get
        Set(ByVal value As String)
            If value <> RData._Fornecedor Then
                RaiseEvent AoAlterar()
            End If
            RData._Fornecedor = value
        End Set
    End Property
    '
    Property IDFabricante() As Integer?
        Get
            Return RData._IDFabricante
        End Get
        Set(value As Integer?)
            If Not IsNothing(RData._IDFabricante) Then
                If value <> RData._IDFabricante Then
                    RaiseEvent AoAlterar()
                End If
            End If
            RData._IDFabricante = value
        End Set
    End Property
    '
    '--- Propriedade Fabricante
    Public Property Fabricante() As String
        Get
            Return RData._Fabricante
        End Get
        Set(ByVal value As String)
            If value <> RData._Fabricante Then
                RaiseEvent AoAlterar()
            End If
            RData._Fabricante = value
        End Set
    End Property
    '
    Property IDProdutoTipo() As Integer?
        Get
            Return RData._IDProdutoTipo
        End Get
        Set(value As Integer?)
            If Not IsNothing(RData._IDProdutoTipo) Then
                If value <> RData._IDProdutoTipo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            RData._IDProdutoTipo = value
        End Set
    End Property
    '
    '--- Propriedade ProdutoTipo
    Public Property ProdutoTipo() As String
        Get
            Return RData._ProdutoTipo
        End Get
        Set(ByVal value As String)
            If value <> RData._ProdutoTipo Then
                RaiseEvent AoAlterar()
            End If
            RData._ProdutoTipo = value
        End Set
    End Property
    '
    '--- Propriedade IDSituacaoReserva
    Public Property IDSituacaoReserva() As Byte?
        Get
            Return RData._IDSituacaoReserva
        End Get
        Set(ByVal value As Byte?)
            If value <> RData._IDSituacaoReserva Then
                RaiseEvent AoAlterar()
            End If
            RData._IDSituacaoReserva = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoReserva
    Public Property SituacaoReserva() As String
        Get
            Return RData._SituacaoReserva
        End Get
        Set(ByVal value As String)
            If value <> RData._SituacaoReserva Then
                RaiseEvent AoAlterar()
            End If
            RData._SituacaoReserva = value
        End Set
    End Property
    '
    '--- Propriedade ConclusaoData
    Public Property ConclusaoData() As Date?
        Get
            Return RData._ConclusaoData
        End Get
        Set(ByVal value As Date?)
            If value <> RData._ConclusaoData Then
                RaiseEvent AoAlterar()
            End If
            RData._ConclusaoData = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    Public Property Observacao() As String
        Get
            Return RData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> RData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            RData._Observacao = value
        End Set
    End Property
    '
    '--- Propriedade ReservaAtiva
    Public Property ReservaAtiva() As Boolean
        Get
            Return RData._ReservaAtiva
        End Get
        Set(ByVal value As Boolean)
            If value <> RData._ReservaAtiva Then
                RaiseEvent AoAlterar()
            End If
            RData._ReservaAtiva = value
        End Set
    End Property
    '
    '--- Propriedade IDPedido
    '------------------------------------------------------
    Public Property IDPedido() As Integer?
        Get
            Return RData._IDPedido
        End Get
        Set(ByVal value As Integer?)
            If value <> RData._IDPedido Then
                RaiseEvent AoAlterar()
            End If
            RData._IDPedido = value
        End Set
    End Property
	'
	'--- Propriedade ValorAntecipado
	'------------------------------------------------------
	Public Property ValorAntecipado() As Decimal?
		Get
			Return RData._ValorAntecipado
		End Get
		Set(ByVal value As Decimal?)
			'
			If value = 0 Then value = Nothing
			'
			If value <> RData._ValorAntecipado Then
				RaiseEvent AoAlterar()
			End If
			RData._ValorAntecipado = value
			'
		End Set
	End Property
	'
#End Region
	'
End Class
'
' CLASSE RESERVA SITUACAO
'==================================================================================
Public Class clReservaSituacao
    '
    Sub New()
        IDSituacaoReserva = Nothing
        SituacaoReserva = ""
        ReservaAtiva = Nothing
    End Sub
    '
    Property IDSituacaoReserva As Byte
    Property SituacaoReserva As String
    Property ReservaAtiva As Boolean
    '
End Class