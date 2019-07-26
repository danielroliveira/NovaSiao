Imports System.ComponentModel
'
'==================================================================================
' CLASSE PRODUTO
'==================================================================================
Public Class clProduto
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure ProdutoDados ' alguns usam FRIEND em vez de DIM
        '
        '--- Dados da tblProduto
        Dim _IDProduto As Nullable(Of Integer)
        Dim _RGProduto As Nullable(Of Integer)
        Dim _Produto As String
        Dim _IDFabricante As Nullable(Of Integer)
        Dim _Fabricante As String
        Dim _IDProdutoTipo As Integer?
        Dim _ProdutoTipo As String
        Dim _IDProdutoSubTipo As Integer?
        Dim _ProdutoSubTipo As String
        Dim _IDCategoria As Nullable(Of Integer)
        Dim _ProdutoCategoria As String
        Dim _Autor As String
        Dim _Unidade As Integer
        Dim _PCompra As Double
        Dim _DescontoCompra As Decimal
        Dim _PVenda As Double
        Dim _ProdutoAtivo As Boolean
        Dim _SitTributaria As Nullable(Of Byte)
        Dim _SituacaoTributaria As String
        Dim _NCM As String
        Dim _UltAltera As Nullable(Of Date)
        Dim _EntradaData As Nullable(Of Date)
        Dim _CodBarrasA As String
        Dim _Movimento As Byte
        Dim _MovimentoDescricao As String
        '
        '--- Dados da tblEstoque
        Dim _Estoque As Integer
        Dim _EstoqueIdeal As Integer
        Dim _EstoqueNivel As Integer
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private PData As ProdutoDados
    Private backupData As ProdutoDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        PData = New ProdutoDados()
        With PData
            ._IDProduto = Nothing
            ._RGProduto = Nothing
            ._Produto = ""
            ._IDFabricante = Nothing
            ._IDProdutoTipo = Nothing
            ._IDProdutoSubTipo = Nothing
            ._IDCategoria = Nothing
            ._Autor = ""
            ._Unidade = 1
            ._PCompra = 0
            ._DescontoCompra = 0
            ._PVenda = 0
            ._ProdutoAtivo = True
            ._SitTributaria = Nothing
            ._NCM = ""
            ._UltAltera = Date.Now.ToShortDateString
            ._EntradaData = Date.Now.ToShortDateString
            ._CodBarrasA = ""
            ._Estoque = 0
            ._EstoqueNivel = 0
            ._EstoqueIdeal = 0
        End With
    End Sub
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = PData
            inTxn = True
        End If
    End Sub
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.PData = backupData
            inTxn = False
        End If
    End Sub
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New ProdutoDados()
            inTxn = False
        End If
    End Sub
    '_EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    Public Overrides Function ToString() As String
        Return Produto.ToString
    End Function
    Public ReadOnly Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
    End Property
#End Region
    '
#Region "PROPRIEDADES"
    Property IDProduto() As Nullable(Of Integer)
        Get
            Return PData._IDProduto
        End Get
        Set(ByVal value As Nullable(Of Integer))
            PData._IDProduto = value
        End Set
    End Property
    '
    Property RGProduto() As Nullable(Of Integer)
        Get
            Return PData._RGProduto
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(PData._RGProduto) Then
                If value <> PData._RGProduto Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._RGProduto = value
        End Set
    End Property
    '
    Property Produto() As String
        Get
            Return PData._Produto
        End Get
        Set(value As String)
            If Not IsNothing(PData._Produto) Then
                If value <> PData._Produto Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._Produto = value
        End Set
    End Property
    '
    Property IDFabricante() As Nullable(Of Integer)
        Get
            Return PData._IDFabricante
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(PData._IDFabricante) Then
                If value <> PData._IDFabricante Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._IDFabricante = value
        End Set
    End Property
    '
    '--- Propriedade Fabricante
    '------------------------------------------------------
    Public Property Fabricante() As String
        Get
            Return PData._Fabricante
        End Get
        Set(ByVal value As String)
            If value <> PData._Fabricante Then
                RaiseEvent AoAlterar()
            End If
            PData._Fabricante = value
        End Set
    End Property
    '
    Property IDProdutoTipo() As Nullable(Of Integer)
        Get
            Return PData._IDProdutoTipo
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(PData._IDProdutoTipo) Then
                If value <> PData._IDProdutoTipo Then
                    RaiseEvent AoAlterar()
                End If
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
    Property IDProdutoSubTipo() As Nullable(Of Integer)
        Get
            Return PData._IDProdutoSubTipo
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(PData._IDProdutoSubTipo) Then
                If value <> PData._IDProdutoSubTipo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._IDProdutoSubTipo = value
        End Set
    End Property
    '
    '--- Propriedade ProdutoSubTipo
    '------------------------------------------------------
    Public Property ProdutoSubTipo() As String
        Get
            Return PData._ProdutoSubTipo
        End Get
        Set(ByVal value As String)
            If value <> PData._ProdutoSubTipo Then
                RaiseEvent AoAlterar()
            End If
            PData._ProdutoSubTipo = value
        End Set
    End Property
    '
    Property IDCategoria() As Nullable(Of Integer)
        Get
            Return PData._IDCategoria
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(PData._IDCategoria) Then
                If value <> PData._IDCategoria Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._IDCategoria = value
        End Set
    End Property
    '
    '--- Propriedade ProdutoCategoria
    '------------------------------------------------------
    Public Property ProdutoCategoria() As String
        Get
            Return PData._ProdutoCategoria
        End Get
        Set(ByVal value As String)
            If value <> PData._ProdutoCategoria Then
                RaiseEvent AoAlterar()
            End If
            PData._ProdutoCategoria = value
        End Set
    End Property
    '
    Property Autor() As String
        Get
            Return PData._Autor
        End Get
        Set(value As String)
            If Not IsNothing(PData._Autor) Then
                If value <> PData._Autor Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._Autor = value
        End Set
    End Property
    '
    Property Unidade() As Integer
        Get
            Return PData._Unidade
        End Get
        Set(value As Integer)
            If Not IsNothing(PData._Unidade) Then
                If value <> PData._Unidade Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._Unidade = value
        End Set
    End Property
    '
    Property PCompra() As Double
        Get
            Return PData._PCompra
        End Get
        Set(value As Double)
            If Not IsNothing(PData._PCompra) Then
                If value <> PData._PCompra Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._PCompra = value
        End Set
    End Property
    '
    '--- Propriedade DescontoCompra
    '------------------------------------------------------
    Public Property DescontoCompra() As Decimal
        Get
            Return PData._DescontoCompra
        End Get
        Set(ByVal value As Decimal)
            If value <> PData._DescontoCompra Then
                RaiseEvent AoAlterar()
            End If
            PData._DescontoCompra = value
        End Set
    End Property
    '
    Property PVenda() As Double
        Get
            Return PData._PVenda
        End Get
        Set(value As Double)
            If Not IsNothing(PData._PVenda) Then
                If value <> PData._PVenda Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._PVenda = value
        End Set
    End Property
    '
    ReadOnly Property MargemDe As Decimal
        Get
            If PCompra = 0 Then Return 0
            Dim n = Math.Round((CDbl(PVenda) - CDbl(PCompra)) / CDbl(PCompra) * 100, 2)
            Return n
        End Get
    End Property
    '
    ReadOnly Property DescontoDe As Decimal
        Get
            If PVenda = 0 Then Return 0
            Dim n = Math.Round((CDbl(PVenda) - CDbl(PCompra)) / CDbl(PVenda) * 100, 2)
            Return n
        End Get
    End Property
    '
    Property ProdutoAtivo() As Nullable(Of Boolean)
        Get
            Return PData._ProdutoAtivo
        End Get
        Set(value As Nullable(Of Boolean))
            If Not IsNothing(PData._ProdutoAtivo) Then
                If value <> PData._ProdutoAtivo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._ProdutoAtivo = value
        End Set
    End Property
    '
    Property SitTributaria() As Nullable(Of Byte)
        Get
            Return PData._SitTributaria
        End Get
        Set(value As Nullable(Of Byte))
            If Not IsNothing(PData._SitTributaria) Then
                If value <> PData._SitTributaria Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._SitTributaria = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoTributaria
    '------------------------------------------------------
    Public Property SituacaoTributaria() As String
        Get
            Return PData._SituacaoTributaria
        End Get
        Set(ByVal value As String)
            If value <> PData._SituacaoTributaria Then
                RaiseEvent AoAlterar()
            End If
            PData._SituacaoTributaria = value
        End Set
    End Property
    '
    Property NCM() As String
        Get
            Return PData._NCM
        End Get
        Set(value As String)
            If Not IsNothing(PData._NCM) Then
                If value <> PData._NCM Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._NCM = value
        End Set
    End Property
    '
    Property UltAltera() As Nullable(Of Date)
        Get
            Return PData._UltAltera
        End Get
        Set(value As Nullable(Of Date))
            If Not IsNothing(PData._UltAltera) Then
                If value <> PData._UltAltera Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._UltAltera = value
        End Set
    End Property
    '
    Property EntradaData() As Nullable(Of Date)
        Get
            Return PData._EntradaData
        End Get
        Set(value As Nullable(Of Date))
            If Not IsNothing(PData._EntradaData) Then
                If value <> PData._EntradaData Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._EntradaData = value
        End Set
    End Property
    '
    Property CodBarrasA() As String
        Get
            Return PData._CodBarrasA
        End Get
        Set(value As String)
            If Not IsNothing(PData._CodBarrasA) Then
                If value <> PData._CodBarrasA Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._CodBarrasA = value
        End Set
    End Property
    '
    '--- Propriedade Movimento
    '------------------------------------------------------
    Public Property Movimento() As Byte
        Get
            Return PData._Movimento
        End Get
        Set(ByVal value As Byte)
            If value <> PData._Movimento Then
                RaiseEvent AoAlterar()
            End If
            PData._Movimento = value
        End Set
    End Property
    '
    '--- Propriedade MovimentoDescricao
    '------------------------------------------------------
    Public Property MovimentoDescricao() As String
        Get
            Return PData._MovimentoDescricao
        End Get
        Set(ByVal value As String)
            If value <> PData._MovimentoDescricao Then
                RaiseEvent AoAlterar()
            End If
            PData._MovimentoDescricao = value
        End Set
    End Property
    '
    Property Estoque() As Integer
        Get
            Return PData._Estoque
        End Get
        Set(value As Integer)
            If Not IsNothing(PData._Estoque) Then
                If value <> PData._Estoque Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._Estoque = value
        End Set
    End Property
    '
    Property EstoqueNivel() As Integer
        Get
            Return PData._EstoqueNivel
        End Get
        Set(value As Integer)
            If Not IsNothing(PData._EstoqueNivel) Then
                If value <> PData._EstoqueNivel Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._EstoqueNivel = value
        End Set
    End Property
    '
    Property EstoqueIdeal() As Integer
        Get
            Return PData._EstoqueIdeal
        End Get
        Set(value As Integer)
            If Not IsNothing(PData._EstoqueIdeal) Then
                If value <> PData._EstoqueIdeal Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._EstoqueIdeal = value
        End Set
    End Property
    '
    '--- PROPRIEDADES READONLY da TBLPRODUTOCUSTOS
    '
    '--- PRECOMEDIO
    Private _PrecoMedio As Decimal?
    Public ReadOnly Property PrecoMedio() As Decimal
        Get
            Return If(_PrecoMedio, 0)
        End Get
    End Property
    '
    '--- PERCENTUAL DO FRETE
    Private _FretePercentual As Decimal?
    Public ReadOnly Property FretePercentual() As Decimal
        Get
            Return If(_FretePercentual, 0)
        End Get
    End Property
    '
    '--- IMPOSTO FEDERAL PERCENTUAL
    Private _ImpostoFederalPerc As Decimal?
    Public ReadOnly Property ImpostoFederalPerc() As Decimal
        Get
            Return If(_ImpostoFederalPerc, 0)
        End Get
    End Property
    '
    '--- IMPOSTO ESTADUAL PERCENTUAL
    Private _ImpostoEstadualPerc As Decimal?
    Public ReadOnly Property ImpostoEstadualPerc() As Decimal
        Get
            Return If(_ImpostoEstadualPerc, 0)
        End Get
    End Property
    '
#End Region
    '
#Region "ENUM PRODUTO MOVIMENTO"
    '
    Public Enum EnumProdutoMovimento As Byte
        '0:Normal | 1:Sem Movimento | 2:Protegido | 3:Periodico
        NORMAL = 0
        SEM_MOVIMENTO = 1
        PROTEGIDO = 2
        PERIODICO = 3
    End Enum
    '
#End Region '/ ENUM PRODUTO MOVIMENTO
    '
End Class
'
'==================================================================================
' CLASSE PRODUTO ETIQUETA
'==================================================================================
Public Class clProdutoEtiqueta
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure ProdutoDados ' alguns usam FRIEND em vez de DIM
        '
        '--- Dados da tblProduto
        Dim _IDEtiqueta As Integer?
        Dim _IDProduto As Integer?
        Dim _RGProduto As Integer?
        Dim _Produto As String
        Dim _ProdutoTipo As String
        Dim _ProdutoSubTipo As String
        Dim _Quantidade As Integer
        Dim _PVenda As Decimal?
        Dim _PrecoVenda As Decimal?
        Dim _PrecoPromocao As Nullable(Of Decimal)
        Dim _CodBarrasA As String
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private PData As ProdutoDados
    Private backupData As ProdutoDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        PData = New ProdutoDados()
        With PData
            ._IDEtiqueta = Nothing
            ._IDProduto = Nothing
            ._RGProduto = Nothing
            ._Quantidade = 1
            ._Produto = ""
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
            backupData = New ProdutoDados()
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
#End Region
    '
#Region "PROPRIEDADES"
    '
    Property IDEtiqueta() As Integer?
        Get
            Return PData._IDEtiqueta
        End Get
        Set(ByVal value As Integer?)
            PData._IDEtiqueta = value
        End Set
    End Property
    '
    Property IDProduto() As Integer?
        Get
            Return PData._IDProduto
        End Get
        Set(ByVal value As Integer?)
            PData._IDProduto = value
        End Set
    End Property
    '
    Property RGProduto() As Integer?
        Get
            Return PData._RGProduto
        End Get
        Set(value As Integer?)
            If Not IsNothing(PData._RGProduto) Then
                If value <> PData._RGProduto Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._RGProduto = value
        End Set
    End Property
    '
    Property Produto() As String
        Get
            Return PData._Produto
        End Get
        Set(value As String)
            If Not IsNothing(PData._Produto) Then
                If value <> PData._Produto Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._Produto = value
        End Set
    End Property
    '
    Property ProdutoTipo() As String
        Get
            Return PData._ProdutoTipo
        End Get
        Set(value As String)
            If Not IsNothing(PData._ProdutoTipo) Then
                If value <> PData._ProdutoTipo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._ProdutoTipo = value
        End Set
    End Property
    '
    Property ProdutoSubTipo() As String
        Get
            Return PData._ProdutoSubTipo
        End Get
        Set(value As String)
            If Not IsNothing(PData._ProdutoSubTipo) Then
                If value <> PData._ProdutoSubTipo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._ProdutoSubTipo = value
        End Set
    End Property
    '
    Property PVenda() As Decimal?
        Get
            Return PData._PVenda
        End Get
        Set(value As Decimal?)
            If Not IsNothing(PData._PVenda) Then
                If value <> PData._PVenda Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._PVenda = value
        End Set
    End Property
    '
    '--- Propriedade Quantidade
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
    '--- Propriedade PrecoVenda
    Public Property PrecoVenda() As Decimal?
        Get
            Return PData._PrecoVenda
        End Get
        Set(ByVal value As Decimal?)
            If value <> PData._PrecoVenda Then
                RaiseEvent AoAlterar()
            End If
            PData._PrecoVenda = value
        End Set
    End Property
    '
    '--- Propriedade PrecoPromocao
    Public Property PrecoPromocao() As Nullable(Of Decimal)
        Get
            If IsNothing(PData._PrecoPromocao) Then
                Return PData._PrecoVenda
            Else
                Return PData._PrecoPromocao
            End If
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If value <> PData._PrecoPromocao Then
                RaiseEvent AoAlterar()
            End If
            PData._PrecoPromocao = value
        End Set
    End Property
    '
    Property CodBarrasA() As String
        Get
            Return PData._CodBarrasA
        End Get
        Set(value As String)
            If Not IsNothing(PData._CodBarrasA) Then
                If value <> PData._CodBarrasA Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._CodBarrasA = value
        End Set
    End Property
    '
#End Region
    '
End Class
'
'==================================================================================
' CLASSE PRODUTO FORNECEDOR => relaciona produtos aos fornecedores
'==================================================================================
Public Class clProdutoFornecedor
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    '
    Structure ProdutoDados ' alguns usam FRIEND em vez de DIM
        '
        '--- Dados da tblProduto
        '========================================
        Dim _IDProduto As Integer?
        'Dim RGProduto As Integer?
        'Dim Produto As String
        Dim _IDFornecedor As Integer?
        'Dim Cadastro As String
        'Dim CNPJ As String
        Dim _IDTransacao As Integer?
        Dim _UltimaEntrada As Date?
        Dim _PCompra As Decimal?
        Dim _DescontoCompra As Decimal?
        Dim _IDProdutoOrigem As String
        'Dim IDFilial As String
        'Dim ApelidoFilial As String
        '=========================================
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private PData As ProdutoDados
    Private backupData As ProdutoDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        PData = New ProdutoDados()
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
            backupData = New ProdutoDados()
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
#End Region
    '
#Region "PROPRIEDADES"
    '
    Property IDProduto() As Integer?
        Get
            Return PData._IDProduto
        End Get
        Set(ByVal value As Integer?)
            PData._IDProduto = value
        End Set
    End Property
    '
    Property RGProduto() As Integer?
    '
    Property Produto() As String
    '
    '--- Propriedade IDFornecedor
    '------------------------------------------------------
    Public Property IDFornecedor() As Integer
        Get
            Return PData._IDFornecedor
        End Get
        Set(ByVal value As Integer)
            If value <> PData._IDFornecedor Then
                RaiseEvent AoAlterar()
            End If
            PData._IDFornecedor = value
        End Set
    End Property
    '
    Property Cadastro() As String
    '
    Property CNPJ() As String
    '
    '--- Propriedade IDTransacao
    '------------------------------------------------------
    Public Property IDTransacao() As Integer
        Get
            Return PData._IDTransacao
        End Get
        Set(ByVal value As Integer)
            If value <> PData._IDTransacao Then
                RaiseEvent AoAlterar()
            End If
            PData._IDTransacao = value
        End Set
    End Property
    '
    '--- Propriedade UltimaEntrada
    '------------------------------------------------------
    Public Property UltimaEntrada() As Date?
        Get
            Return PData._UltimaEntrada
        End Get
        Set(ByVal value As Date?)
            If value <> PData._UltimaEntrada Then
                RaiseEvent AoAlterar()
            End If
            PData._UltimaEntrada = value
        End Set
    End Property
    '    
    Property PCompra() As Decimal?
        Get
            Return PData._PCompra
        End Get
        Set(value As Decimal?)
            If Not IsNothing(PData._PCompra) Then
                If value <> PData._PCompra Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._PCompra = value
        End Set
    End Property
    '
    '--- Propriedade DescontoCompra
    '------------------------------------------------------
    Public Property DescontoCompra() As Decimal?
        Get
            Return PData._DescontoCompra
        End Get
        Set(ByVal value As Decimal?)
            If value <> PData._DescontoCompra Then
                RaiseEvent AoAlterar()
            End If
            PData._DescontoCompra = value
        End Set
    End Property
    '
    Property IDProdutoOrigem() As String
        Get
            Return PData._IDProdutoOrigem
        End Get
        Set(value As String)
            If Not IsNothing(PData._IDProdutoOrigem) Then
                If value <> PData._IDProdutoOrigem Then
                    RaiseEvent AoAlterar()
                End If
            End If
            PData._IDProdutoOrigem = value
        End Set
    End Property
    '
    Property IDFilial() As Integer?
    '
    Property ApelidoFilial() As String
    '
#End Region
    '
End Class