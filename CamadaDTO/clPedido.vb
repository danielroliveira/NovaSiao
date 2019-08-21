Imports System.ComponentModel
'
'==================================================================================
' CLASSE PEDIDO DE PRODUTO
'==================================================================================
Public Class clPedido
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure PedItemDados ' alguns usam FRIEND em vez de DIM
        '
        '--- Dados da tblPedido
        Dim _IDPedido As Integer?
        Dim _IDFilial As Integer?
        Dim _ApelidoFilial As String
        Dim _IDFornecedor As Integer?
        Dim _Fornecedor As String
        Dim _VendedorNome As String
        Dim _EmailVendas As String
        Dim _TelefoneContato As String
        Dim _IDTransportadora As Integer?
        Dim _Transportadora As String
        Dim _TelefoneATransportadora As String
        Dim _Situacao As Byte
        Dim _SituacaoDescricao As String
        Dim _InicioData As Date?
        Dim _RevisaoData As Date?
        Dim _EnvioData As Date?
        Dim _ChegadaData As Date?
        Dim _Observacao As String
        Dim _TotalPedido As Decimal
        Dim _TotalRecebido As Decimal
        Dim _IDMigracao As Integer?
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private PData As PedItemDados
    Private backupData As PedItemDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        PData = New PedItemDados()
        With PData
            ._IDPedido = Nothing
            ._Situacao = 0
            ._SituacaoDescricao = "Compondo"
            ._InicioData = Now.ToShortDateString
            ._VendedorNome = ""
            ._TotalPedido = 0
            ._TotalRecebido = 0
            ._IDMigracao = Nothing
        End With
    End Sub
    '
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = PData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.PData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New PedItemDados()
            inTxn = False
        End If
    End Sub
    '
    '_EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public Overrides Function ToString() As String
        Return Fornecedor.ToString
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
    '--- Propriedade IDPedido
    '------------------------------------------------------
    Public Property IDPedido() As Integer?
        Get
            Return PData._IDPedido
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDPedido Then
                RaiseEvent AoAlterar()
            End If
            PData._IDPedido = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public Property IDFilial() As Integer?
        Get
            Return PData._IDFilial
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            PData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade ApelidoFilial
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
        Get
            Return PData._ApelidoFilial
        End Get
        Set(ByVal value As String)
            If value <> PData._ApelidoFilial Then
                RaiseEvent AoAlterar()
            End If
            PData._ApelidoFilial = value
        End Set
    End Property
    '
    '--- Propriedade IDFornecedor
    '------------------------------------------------------
    Public Property IDFornecedor() As Integer?
        Get
            Return PData._IDFornecedor
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDFornecedor Then
                RaiseEvent AoAlterar()
            End If
            PData._IDFornecedor = value
        End Set
    End Property
    '
    '--- Propriedade Fornecedor
    Public Property Fornecedor() As String
        Get
            Return PData._Fornecedor
        End Get
        Set(ByVal value As String)
            If value <> PData._Fornecedor Then
                RaiseEvent AoAlterar()
            End If
            PData._Fornecedor = value
        End Set
    End Property
    '
    '--- Propriedade VendedorNome
    '------------------------------------------------------
    Public Property VendedorNome() As String
        Get
            Return PData._VendedorNome
        End Get
        Set(ByVal value As String)
            If value <> PData._VendedorNome Then
                RaiseEvent AoAlterar()
            End If
            PData._VendedorNome = value
        End Set
    End Property
    '
    '--- Propriedade EmailVendas
    '------------------------------------------------------
    Public Property EmailVendas() As String
        Get
            Return PData._EmailVendas
        End Get
        Set(ByVal value As String)
            If value <> PData._EmailVendas Then
                RaiseEvent AoAlterar()
            End If
            PData._EmailVendas = value
        End Set
    End Property
    '
    '--- Propriedade TelefoneContato
    '------------------------------------------------------
    Public Property TelefoneContato() As String
        Get
            Return PData._TelefoneContato
        End Get
        Set(ByVal value As String)
            If value <> PData._TelefoneContato Then
                RaiseEvent AoAlterar()
            End If
            PData._TelefoneContato = value
        End Set
    End Property
    '
    '--- Propriedade IDTransportadora
    '------------------------------------------------------
    Public Property IDTransportadora() As Integer?
        Get
            Return PData._IDTransportadora
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDTransportadora Then
                RaiseEvent AoAlterar()
            End If
            PData._IDTransportadora = value
        End Set
    End Property
    '
    '--- Propriedade Transportadora
    '------------------------------------------------------
    Public Property Transportadora() As String
        Get
            Return PData._Transportadora
        End Get
        Set(ByVal value As String)
            If value <> PData._Transportadora Then
                RaiseEvent AoAlterar()
            End If
            PData._Transportadora = value
        End Set
    End Property
    '
    '--- Propriedade TelefoneATransportadora
    '------------------------------------------------------
    Public Property TelefoneATransportadora() As String
        Get
            Return PData._TelefoneATransportadora
        End Get
        Set(ByVal value As String)
            If value <> PData._TelefoneATransportadora Then
                RaiseEvent AoAlterar()
            End If
            PData._TelefoneATransportadora = value
        End Set
    End Property
    '
    '--- Propriedade Situacao
    '------------------------------------------------------
    Public Property Situacao() As Byte
        Get
            Return PData._Situacao
        End Get
        Set(ByVal value As Byte)
            If value <> PData._Situacao Then
                RaiseEvent AoAlterar()
            End If
            PData._Situacao = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoDescricao
    '------------------------------------------------------
    Public Property SituacaoDescricao() As String
        'Compondo = 0 | Enviado = 1 | Recebido = 2 | Cancelado = 3 | Migrado = 4
        Get
            Return PData._SituacaoDescricao
        End Get
        Set(ByVal value As String)
            If value <> PData._SituacaoDescricao Then
                RaiseEvent AoAlterar()
            End If
            PData._SituacaoDescricao = value
        End Set
    End Property
    '
    '--- Propriedade InicioData
    '------------------------------------------------------
    Public Property InicioData() As Date?
        Get
            Return PData._InicioData
        End Get
        Set(ByVal value As Date?)
            If value <> PData._InicioData Then
                RaiseEvent AoAlterar()
            End If
            PData._InicioData = value
        End Set
    End Property
    '
    '--- Propriedade RevisaoData
    '------------------------------------------------------
    Public Property RevisaoData() As Date?
        Get
            Return PData._RevisaoData
        End Get
        Set(ByVal value As Date?)
            If value <> PData._RevisaoData Then
                RaiseEvent AoAlterar()
            End If
            PData._RevisaoData = value
        End Set
    End Property
    '
    '--- Propriedade EnvioData
    '------------------------------------------------------
    Public Property EnvioData() As Date?
        Get
            Return PData._EnvioData
        End Get
        Set(ByVal value As Date?)
            If value <> PData._EnvioData Then
                RaiseEvent AoAlterar()
            End If
            PData._EnvioData = value
        End Set
    End Property
    '
    '--- Propriedade ChegadaData
    '------------------------------------------------------
    Public Property ChegadaData() As Date?
        Get
            Return PData._ChegadaData
        End Get
        Set(ByVal value As Date?)
            If value <> PData._ChegadaData Then
                RaiseEvent AoAlterar()
            End If
            PData._ChegadaData = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    '------------------------------------------------------
    Public Property Observacao() As String
        Get
            Return PData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> PData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            PData._Observacao = value
        End Set
    End Property
    '
    '--- Propriedade TotalPedido
    '------------------------------------------------------
    Public Property TotalPedido() As Decimal
        Get
            Return PData._TotalPedido
        End Get
        Set(ByVal value As Decimal)
            If value <> PData._TotalPedido Then
                RaiseEvent AoAlterar()
            End If
            PData._TotalPedido = value
        End Set
    End Property
    '
    '--- Propriedade TotalRecebido
    '------------------------------------------------------
    Public Property TotalRecebido() As Decimal
        Get
            Return PData._TotalRecebido
        End Get
        Set(ByVal value As Decimal)
            If value <> PData._TotalRecebido Then
                RaiseEvent AoAlterar()
            End If
            PData._TotalRecebido = value
        End Set
    End Property
    '
    '--- Propriedade IDMigracao
    '------------------------------------------------------
    Public Property IDMigracao() As Integer?
        Get
            Return PData._IDMigracao
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDMigracao Then
                RaiseEvent AoAlterar()
            End If
            PData._IDMigracao = value
        End Set
    End Property
    '
#End Region
    '
End Class
'
'==================================================================================
' CLASSE ITEM DE PEDIDO DE PRODUTO
'==================================================================================
Public Class clPedidoItem
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure PedItemDados ' alguns usam FRIEND em vez de DIM
        '
        '--- Dados da tblPedido
        Dim _IDPedidoItem As Integer?
        Dim _IDPedido As Integer?
        Dim _IDProduto As Integer?
        Dim _RGProduto As Integer?
        Dim _Produto As String
        Dim _IDProdutoTipo As Integer?
        Dim _ProdutoTipo As String
        Dim _Autor As String
        Dim _Quantidade As Integer
        Dim _Preco As Decimal
        Dim _Desconto As Decimal
        Dim _Origem As Byte
        Dim _OrigemDescricao As String
        Dim _IDOrigem As Integer?
        Dim _IDFilialOrigem As Integer?
        Dim _ApelidoFilial As String
        '
        '--- propriedades calculadas
        ' SUBTOTAL
        '
        '--- propriedades do Estoque
        ' ESTOQUE
        ' ESTOQUE NIVEL
        ' ESTOQUE IDEAL

    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private PData As PedItemDados
    Private backupData As PedItemDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        PData = New PedItemDados()
        With PData
            ._IDPedidoItem = Nothing
            ._IDPedido = Nothing
            ._Quantidade = 1
            ._Preco = 0
            ._Desconto = 0
            ._Origem = 0
        End With
    End Sub
    '
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = PData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.PData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New PedItemDados()
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
    '--- Propriedade IDPedidoItem
    '------------------------------------------------------
    Public Property IDPedidoItem() As Integer?
        Get
            Return PData._IDPedidoItem
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDPedidoItem Then
                RaiseEvent AoAlterar()
            End If
            PData._IDPedidoItem = value
        End Set
    End Property
    '
    '--- Propriedade IDPedido
    '------------------------------------------------------
    Public Property IDPedido() As Integer?
        Get
            Return PData._IDPedido
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDPedido Then
                RaiseEvent AoAlterar()
            End If
            PData._IDPedido = value
        End Set
    End Property
    '
    '--- Propriedade IDProduto
    '------------------------------------------------------
    Public Property IDProduto() As Integer?
        Get
            Return PData._IDProduto
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDProduto Then
                RaiseEvent AoAlterar()
            End If
            PData._IDProduto = value
        End Set
    End Property
    '
    '--- Propriedade RGProduto
    '------------------------------------------------------
    Public Property RGProduto() As Integer?
        Get
            Return PData._RGProduto
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._RGProduto Then
                RaiseEvent AoAlterar()
            End If
            PData._RGProduto = value
        End Set
    End Property
    '
    '--- Propriedade Produto
    '------------------------------------------------------
    Public Property Produto() As String
        Get
            Return PData._Produto
        End Get
        Set(ByVal value As String)
            If value <> PData._Produto Then
                RaiseEvent AoAlterar()
            End If
            PData._Produto = value
        End Set
    End Property
    '
    '--- Propriedade IDProdutoTipo
    '------------------------------------------------------
    Public Property IDProdutoTipo() As Integer?
        Get
            Return PData._IDProdutoTipo
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDProdutoTipo Then
                RaiseEvent AoAlterar()
            End If
            PData._IDProdutoTipo = value
        End Set
    End Property
    '
    '--- Propriedade ProdutoTipo
    '------------------------------------------------------
    Public Property ProdutoTipo() As String
        Get
            Return PData._ProdutoTipo
        End Get
        Set(ByVal value As String)
            If value <> PData._ProdutoTipo Then
                RaiseEvent AoAlterar()
            End If
            PData._ProdutoTipo = value
        End Set
    End Property
    '
    '--- Propriedade Autor
    '------------------------------------------------------
    Public Property Autor() As String
        Get
            Return PData._Autor
        End Get
        Set(ByVal value As String)
            If value <> PData._Autor Then
                RaiseEvent AoAlterar()
            End If
            PData._Autor = value
        End Set
    End Property
    '
    '--- Propriedade Quantidade
    '------------------------------------------------------
    Public Property Quantidade() As Integer
        Get
            Return PData._Quantidade
        End Get
        Set(ByVal value As Integer)
            If value <> PData._Quantidade Then
                RaiseEvent AoAlterar()
            End If
            PData._Quantidade = value
        End Set
    End Property
    '
    '--- Propriedade Preco
    '------------------------------------------------------
    Public Property Preco() As Decimal
        Get
            Return PData._Preco
        End Get
        Set(ByVal value As Decimal)
            If value <> PData._Preco Then
                RaiseEvent AoAlterar()
            End If
            PData._Preco = value
        End Set
    End Property
    '
    '--- Propriedade Desconto
    '------------------------------------------------------
    Public Property Desconto() As Decimal
        Get
            Return PData._Desconto
        End Get
        Set(ByVal value As Decimal)
            If value <> PData._Desconto Then
                RaiseEvent AoAlterar()
            End If
            PData._Desconto = value
        End Set
    End Property
    '
    '--- Propriedade Origem
    '------------------------------------------------------
    Public Property Origem() As Byte
        Get
            Return PData._Origem
        End Get
        Set(ByVal value As Byte)
            If value <> PData._Origem Then
                RaiseEvent AoAlterar()
            End If
            PData._Origem = value
        End Set
    End Property
    '
    '--- Propriedade OrigemDescricao
    '------------------------------------------------------
    'WHEN 0 THEN Pedido Local'
    'WHEN 1 THEN Reserva Local'
    'WHEN 2 THEN Pedido Filial'
    'WHEN 3 THEN Reserva Filial'
    'WHEN 4 THEN Migracao Local'
    '------------------------------------------------------
    Public Property OrigemDescricao() As String
        Get
            Return PData._OrigemDescricao
        End Get
        Set(ByVal value As String)
            If value <> PData._OrigemDescricao Then
                RaiseEvent AoAlterar()
            End If
            PData._OrigemDescricao = value
        End Set
    End Property
    '
    '--- Propriedade IDOrigem
    '------------------------------------------------------
    Public Property IDOrigem() As Integer?
        Get
            Return PData._IDOrigem
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDOrigem Then
                RaiseEvent AoAlterar()
            End If
            PData._IDOrigem = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public Property IDFilialOrigem() As Integer?
        Get
            Return PData._IDFilialOrigem
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDFilialOrigem Then
                RaiseEvent AoAlterar()
            End If
            PData._IDFilialOrigem = value
        End Set
    End Property
    '
    '--- Propriedade ApelidoFilial
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
        Get
            Return PData._ApelidoFilial
        End Get
        Set(ByVal value As String)
            If value <> PData._ApelidoFilial Then
                RaiseEvent AoAlterar()
            End If
            PData._ApelidoFilial = value
        End Set
    End Property
    '
    '=================================================================================================
    ' PROPRIEDADES CALCULADAS
    '=================================================================================================
    ReadOnly Property SubTotal() As Double
        Get
            Return PData._Quantidade * PData._Preco * (100 - PData._Desconto) / 100
        End Get
    End Property
    '
    '=================================================================================================
    ' PROPRIEDADES DE ESTOQUE
    '=================================================================================================
    Public Property Estoque() As Integer
    Public Property EstoqueNivel() As Integer
    Public Property EstoqueIdeal() As Integer
    '
#End Region
    '
End Class
'
'==================================================================================
' CLASSE MENSAGEM DE PEDIDO DE PRODUTO
'==================================================================================
Public Class clPedidoMensagem
    Property IDPedidoMensagem As Integer?
    Property Mensagem As String
    Property IDPedido As Integer?
End Class