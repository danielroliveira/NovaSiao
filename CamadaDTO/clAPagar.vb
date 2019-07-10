Imports System.ComponentModel

Public Class clAPagar : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure PagarStructure ' alguns usam FRIEND em vez de DIM
        '--- Itens da tblAPagar
        Dim _IDAPagar As Integer?
        Dim _Origem As Origem_APagar 'Compra = 1 | Despesa = 2
        Dim _IDOrigem As Integer?
        Dim _IDPessoa As Integer?
        Dim _IDFilial As Integer?
        Dim _IDCobrancaForma As Int16?
        Dim _CobrancaForma As String
        Dim _Identificador As String
        Dim _RGBanco As Int16?
        Dim _Vencimento As Date
        Dim _APagarValor As Decimal
        Dim _ValorPago As Decimal
        Dim _Situacao As Byte '--- 0:EmAberto | 1:Pago | 2:Cancelada | 3:Negativada | 4:Negociada
        ' Dim SituacaoTexto As String
        Dim _PagamentoData As Date?
        Dim _Desconto As Decimal?
        Dim _Acrescimo As Decimal?
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private PgData As PagarStructure
    Private backupData As PagarStructure
    Private inTxn As Boolean = False
    '
    Enum Origem_APagar
        Compra = 1
        Despesa = 2
        DespesaPeriodica = 3
        SimplesEntrada = 4
        FreteDespesa = 5
    End Enum
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        PgData = New PagarStructure()
        With PgData
            ._APagarValor = 0
            ._ValorPago = 0
            ._Situacao = 0
            ._PagamentoData = Nothing
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = PgData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.PgData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New PagarStructure()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
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
    '--- Propriedade IDAPagar
    Public Property IDAPagar() As Integer?
        Get
            Return PgData._IDAPagar
        End Get
        Set(ByVal value As Integer?)
            If value <> PgData._IDAPagar Then
                RaiseEvent AoAlterar()
            End If
            PgData._IDAPagar = value
        End Set
    End Property
    '
    '--- Propriedade Origem
    Public Property Origem() As Origem_APagar
        Get
            Return PgData._Origem
        End Get
        Set(ByVal value As Origem_APagar)
            If value <> PgData._Origem Then
                RaiseEvent AoAlterar()
            End If
            PgData._Origem = value
        End Set
    End Property
    '
    '--- Propriedade IDOrigem
    Public Property IDOrigem() As Integer?
        Get
            Return PgData._IDOrigem
        End Get
        Set(ByVal value As Integer?)
            If value <> PgData._IDOrigem Then
                RaiseEvent AoAlterar()
            End If
            PgData._IDOrigem = value
        End Set
    End Property
    '
    '--- Propriedade IDPessoa
    Public Property IDPessoa() As Integer?
        Get
            Return PgData._IDPessoa
        End Get
        Set(ByVal value As Integer?)
            If value <> PgData._IDPessoa Then
                RaiseEvent AoAlterar()
            End If
            PgData._IDPessoa = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    Public Property IDFilial() As Integer?
        Get
            Return PgData._IDFilial
        End Get
        Set(ByVal value As Integer?)
            If value <> PgData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            PgData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade CobrancaForma
    Public Property IDCobrancaForma() As Int16?
        Get
            Return PgData._IDCobrancaForma
        End Get
        Set(ByVal value As Int16?)
            If value <> PgData._IDCobrancaForma Then
                RaiseEvent AoAlterar()
            End If
            PgData._IDCobrancaForma = value
        End Set
    End Property
    '
    '--- Propriedade Identificador
    Public Property Identificador() As String
        Get
            Return PgData._Identificador
        End Get
        Set(ByVal value As String)
            If value <> PgData._Identificador Then
                RaiseEvent AoAlterar()
            End If
            PgData._Identificador = value
        End Set
    End Property
    '
    '--- Propriedade RGBanco
    Public Property RGBanco() As Int16?
        Get
            Return PgData._RGBanco
        End Get
        Set(ByVal value As Int16?)
            If value <> PgData._RGBanco Then
                RaiseEvent AoAlterar()
            End If
            PgData._RGBanco = value
        End Set
    End Property
    '
    '--- Propriedade Vencimento
    Public Property Vencimento() As Date
        Get
            Return PgData._Vencimento
        End Get
        Set(ByVal value As Date)
            If value <> PgData._Vencimento Then
                RaiseEvent AoAlterar()
            End If
            PgData._Vencimento = value
        End Set
    End Property
    '
    '--- Propriedade APagarValor
    Public Property APagarValor() As Decimal
        Get
            Return PgData._APagarValor
        End Get
        Set(ByVal value As Decimal)
            If value <> PgData._APagarValor Then
                RaiseEvent AoAlterar()
            End If
            PgData._APagarValor = value
        End Set
    End Property
    '
    '--- Propriedade ValorPago
    Public Property ValorPago() As Decimal
        Get
            Return PgData._ValorPago
        End Get
        Set(ByVal value As Decimal)
            If value <> PgData._ValorPago Then
                RaiseEvent AoAlterar()
            End If
            PgData._ValorPago = value
        End Set
    End Property
    '
    '--- Propriedade Situacao
    Public Property Situacao() As Byte
        Get
            Return PgData._Situacao
        End Get
        Set(ByVal value As Byte)
            If value <> PgData._Situacao Then
                RaiseEvent AoAlterar()
            End If
            PgData._Situacao = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoTexto
    Public ReadOnly Property SituacaoDescricao() As String
        Get
            '--- 0:EmAberto | 1:Pago | 2:Cancelada | 3:Negativada | 4:Negociada
            Select Case Situacao
                Case 0
                    Return "Em Aberto"
                Case 1
                    Return "Paga"
                Case 2
                    Return "Cancelada"
                Case 3
                    Return "Negativada"
                Case 4
                    Return "Negociada"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    '
    '--- Propriedade PagamentoData
    Public Property PagamentoData() As Date?
        Get
            Return PgData._PagamentoData
        End Get
        Set(ByVal value As Date?)
            If value <> PgData._PagamentoData Then
                RaiseEvent AoAlterar()
            End If
            PgData._PagamentoData = value
        End Set
    End Property
    '
    '--- Propriedade Desconto
    Public Property Desconto() As Decimal?
        Get
            Return PgData._Desconto
        End Get
        Set(ByVal value As Decimal?)
            If value <> PgData._Desconto Then
                RaiseEvent AoAlterar()
            End If
            PgData._Desconto = value
        End Set
    End Property
    '
    '--- Propriedade Acrescimo
    Public Property Acrescimo() As Decimal?
        Get
            Return PgData._Acrescimo
        End Get
        Set(ByVal value As Decimal?)
            If value <> PgData._Acrescimo Then
                RaiseEvent AoAlterar()
            End If
            PgData._Acrescimo = value
        End Set
    End Property
    '
    '--- PROPRIEDADES DE OUTRAS TABELAS
    '
    '--- Propriedade OrigemTexto
    Property OrigemTexto As String
    '
    '--- Propriedade Cadastro
    Property Cadastro As String
    '
    '--- Propriedade CobrancaFormaDesc
    Public Property CobrancaForma() As String
    '
    '--- Propriedade BancoNome
    Public Property BancoNome() As String
    '
#End Region
    '
End Class
