Imports System.ComponentModel
Public Class clTransacaoItem : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure ItensDados ' alguns usam FRIEND em vez de DIM
        '--- Itens da tblTransacaoItens
        Dim _IDTransacaoItem As Integer?
        Dim _IDTransacao As Integer?
        Dim _IDProduto As Integer?
        Dim _Quantidade As Integer
        Dim _Desconto As Double
        Dim _Preco As Double
        '--- Itens Importados tblProdutos
        Dim _RGProduto As Integer?
        Dim _Produto As String
        Dim _CodBarrasA As String
        Dim _PVenda As Double
        Dim _PCompra As Double
        Dim _DescontoCompra As Double
        Dim _ProdutoAtivo As Boolean?
        '--- Itens Importados tblEstoque
        Dim _Estoque As Integer
        Dim _Reservado As Integer
        Dim _IDFilial As Integer
        '--- Itens do tblTransacaoItensCustos
        Dim _FreteRateado As Decimal?
        Dim _Substituicao As Decimal?
        Dim _ICMS As Decimal?
        Dim _MVA As Decimal?
        Dim _IPI As Decimal?
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
            ._IDTransacaoItem = Nothing
            ._IDTransacao = Nothing
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
            ._Estoque = 0
            ._Reservado = 0
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
    Property IDTransacaoItem() As Integer?
        Get
            Return itemData._IDTransacaoItem
        End Get
        Set(ByVal value As Nullable(Of Integer))
            itemData._IDTransacaoItem = value
        End Set
    End Property
    '
    Property IDTransacao() As Integer?
        Get
            Return itemData._IDTransacao
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(itemData._IDTransacao) Then
                RaiseEvent AoAlterar()
            End If
            itemData._IDTransacao = value
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
    'Propriedades DA TBLESTOQUE
    '=================================================================================================
    '
    '--- Propriedade Estoque
    Public Property Estoque() As Integer
        Get
            Return itemData._Estoque
        End Get
        Set(ByVal value As Integer)
            If value <> itemData._Estoque Then
                RaiseEvent AoAlterar()
            End If
            itemData._Estoque = value
        End Set
    End Property
    '
    '--- Propriedade Reservado
    Public Property Reservado() As Integer
        Get
            Return itemData._Reservado
        End Get
        Set(ByVal value As Integer)
            If value <> itemData._Reservado Then
                RaiseEvent AoAlterar()
            End If
            itemData._Reservado = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    Public Property IDFilial() As Integer
        Get
            Return itemData._IDFilial
        End Get
        Set(ByVal value As Integer)
            If value <> itemData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            itemData._IDFilial = value
        End Set
    End Property
    '
    '=================================================================================================
    'Propriedades DA TBLTransacaoItensCustos
    '=================================================================================================
    '
    '--- Propriedade FreteRateado
    Public Property FreteRateado() As Decimal?
        Get
            Return If(itemData._FreteRateado, 0)
        End Get
        Set(ByVal value As Decimal?)
            If value <> itemData._FreteRateado Then
                RaiseEvent AoAlterar()
            End If
            itemData._FreteRateado = value
        End Set
    End Property
    '
    '--- Propriedade Substituicao
    Public Property Substituicao() As Decimal?
        Get
            Return If(itemData._Substituicao, 0)
        End Get
        Set(ByVal value As Decimal?)
            If value <> itemData._Substituicao Then
                RaiseEvent AoAlterar()
            End If
            itemData._Substituicao = value
        End Set
    End Property
    '
    '--- Propriedade ICMS
    Public Property ICMS() As Decimal?
        Get
            Return If(itemData._ICMS, 0)
        End Get
        Set(ByVal value As Decimal?)
            If value <> itemData._ICMS Then
                RaiseEvent AoAlterar()
            End If
            itemData._ICMS = value
        End Set
    End Property
    '
    '--- Propriedade MVA
    Public Property MVA() As Decimal?
        Get
            Return If(itemData._MVA, 0)
        End Get
        Set(ByVal value As Decimal?)
            If value <> itemData._MVA Then
                RaiseEvent AoAlterar()
            End If
            itemData._MVA = value
        End Set
    End Property
    '
    '--- Propriedade IPI
    Public Property IPI() As Decimal?
        Get
            Return If(itemData._IPI, 0)
        End Get
        Set(ByVal value As Decimal?)
            If value <> itemData._IPI Then
                RaiseEvent AoAlterar()
            End If
            itemData._IPI = value
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
