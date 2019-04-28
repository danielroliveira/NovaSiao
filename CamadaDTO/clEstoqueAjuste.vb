Imports System.ComponentModel
'
'
'==========================================================================================
' CLASSE PRODUTO ESTOQUE AJUSTE
'==========================================================================================
Public Class clEstoqueAjuste : Implements IEditableObject
    '
    Structure AjusteDados ' alguns usam FRIEND em vez de DIM
        '
        Dim _IDEstoqueAjuste As Integer
        Dim _IDFilial As Integer
        Dim _ApelidoFilial As String
        Dim _IDUser As Integer
        Dim _UsuarioApelido As String
        Dim _AjusteData As Date
        Dim _AjusteOrigem As Byte
        Dim _AjusteOrigemDescricao As String
        Dim _ValorMovimentado As Decimal
        Dim _Bloqueado As Boolean
        Dim _Observacao As String
        '
    End Structure
    '
#Region "PRIVATE VARIABLES"
    Private AData As AjusteDados
    Private backupData As AjusteDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        AData = New AjusteDados()
        With AData
            ._AjusteData = Today
            ._Bloqueado = False
            ._ValorMovimentado = 0
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = AData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.AData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New AjusteDados()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public Event AoAlterarRGProduto()
    '
    Public ReadOnly Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
    End Property
    '
#End Region
    '
#Region "PROPERTIES"
    '
    '--- Propriedade IDEstoqueAjuste
    '------------------------------------------------------
    Public Property IDEstoqueAjuste() As Integer
        Get
            Return AData._IDEstoqueAjuste
        End Get
        Set(ByVal value As Integer)
            If value <> AData._IDEstoqueAjuste Then
                RaiseEvent AoAlterar()
            End If
            AData._IDEstoqueAjuste = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public Property IDFilial() As Integer
        Get
            Return AData._IDFilial
        End Get
        Set(ByVal value As Integer)
            If value <> AData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            AData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade ApelidoFilial
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
        Get
            Return AData._ApelidoFilial
        End Get
        Set(ByVal value As String)
            AData._ApelidoFilial = value
        End Set
    End Property
    '
    '--- Propriedade IDUser
    '------------------------------------------------------
    Public Property IDUser() As Integer
        Get
            Return AData._IDUser
        End Get
        Set(ByVal value As Integer)
            If value <> AData._IDUser Then
                RaiseEvent AoAlterar()
            End If
            AData._IDUser = value
        End Set
    End Property
    '
    '--- Propriedade UsuarioApelido
    '------------------------------------------------------
    Public Property UsuarioApelido() As String
        Get
            Return AData._UsuarioApelido
        End Get
        Set(ByVal value As String)
            AData._UsuarioApelido = value
        End Set
    End Property
    '
    '--- Propriedade AjusteData
    '------------------------------------------------------
    Public Property AjusteData() As Date
        Get
            Return AData._AjusteData
        End Get
        Set(ByVal value As Date)
            If value <> AData._AjusteData Then
                RaiseEvent AoAlterar()
            End If
            AData._AjusteData = value
        End Set
    End Property
    '
    '--- Propriedade AjusteOrigem
    '------------------------------------------------------
    Public Property AjusteOrigem() As Byte
        Get
            Return AData._AjusteOrigem
        End Get
        Set(ByVal value As Byte)
            If value <> AData._AjusteOrigem Then
                RaiseEvent AoAlterar()
            End If
            AData._AjusteOrigem = value
        End Set
    End Property
    '
    '--- Propriedade AjusteOrigemDescricao
    '------------------------------------------------------
    Public Property AjusteOrigemDescricao() As String
        Get
            Return AData._AjusteOrigemDescricao
        End Get
        Set(ByVal value As String)
            AData._AjusteOrigemDescricao = value
        End Set
    End Property
    '
    '--- Propriedade ValorMovimentado
    '------------------------------------------------------
    Public Property ValorMovimentado() As Decimal
        Get
            Return AData._ValorMovimentado
        End Get
        Set(ByVal value As Decimal)
            If value <> AData._ValorMovimentado Then
                RaiseEvent AoAlterar()
            End If
            AData._ValorMovimentado = value
        End Set
    End Property
    '
    '--- Propriedade Bloqueado
    '------------------------------------------------------
    Public Property Bloqueado() As Boolean
        Get
            Return AData._Bloqueado
        End Get
        Set(ByVal value As Boolean)
            If value <> AData._Bloqueado Then
                RaiseEvent AoAlterar()
            End If
            AData._Bloqueado = value
        End Set
    End Property
    '
    Public ReadOnly Property BloqueadoDescricao() As String
        '
        Get
            If Bloqueado = True Then
                Return "Bloqueado"
            Else
                Return "Aberto"
            End If
        End Get
        '
    End Property
    '
    '--- Propriedade Observacao
    '------------------------------------------------------
    Public Property Observacao() As String
        Get
            Return AData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> AData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            AData._Observacao = value
        End Set
    End Property
    '
#End Region '/ PROPERTIES
    '
End Class
'
'==========================================================================================
' CLASSE PRODUTO ESTOQUE AJUSTE ITEM
'==========================================================================================
Public Class clEstoqueAjusteItem : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    '
    Structure ItensDados ' alguns usam FRIEND em vez de DIM
        '--- Itens da tblEstoqueAjusteItens
        Dim _IDEstoqueItem As Integer?
        Dim _IDEstoqueAjuste As Integer?
        Dim _IDProduto As Integer?
        Dim _QuantidadeAnterior As Integer
        Dim _Quantidade As Integer
        Dim _Preco As Double
        '--- Itens da tblEstoqueAjuste
        Dim _AjusteData As Date
        Dim _AjusteOrigem As Byte
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
        '--- Itens Calculados
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
            ._IDEstoqueItem = Nothing
            ._IDEstoqueAjuste = Nothing
            ._IDProduto = Nothing
            ._Preco = 0
            ._QuantidadeAnterior = 0
            ._Quantidade = 1
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
    Property IDEstoqueItem() As Integer?
        Get
            Return itemData._IDEstoqueItem
        End Get
        Set(ByVal value As Integer?)
            itemData._IDEstoqueItem = value
        End Set
    End Property
    '
    Property IDEstoqueAjuste() As Integer?
        Get
            Return itemData._IDEstoqueAjuste
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(itemData._IDEstoqueAjuste) Then
                RaiseEvent AoAlterar()
            End If
            itemData._IDEstoqueAjuste = value
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
    Property QuantidadeAnterior() As Integer
        Get
            Return itemData._QuantidadeAnterior
        End Get
        Set(value As Integer)
            If Not IsNothing(itemData._QuantidadeAnterior) Then
                RaiseEvent AoAlterar()
            End If
            itemData._QuantidadeAnterior = value

        End Set
    End Property
    '
    Public ReadOnly Property QuantidadeFinal() As Integer
        Get
            Return QuantidadeAnterior + Quantidade
        End Get
    End Property
    '
    Public Property AjusteData() As Date
        Get
            Return itemData._AjusteData
        End Get
        Set(ByVal value As Date)
            itemData._AjusteData = value
        End Set
    End Property
    '
    Public Property AjusteOrigem() As Byte
        Get
            Return itemData._AjusteOrigem
        End Get
        Set(ByVal value As Byte)
            itemData._AjusteOrigem = value
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
    'Propriedades calculadas
    '=================================================================================================
    ReadOnly Property Total() As Double
        Get
            Return itemData._Quantidade * itemData._Preco
        End Get
    End Property
    '
#End Region
    '
End Class
'

