Imports System.ComponentModel
'
'=============================================================================================
'CLASSE clAReceber
'CLASSE clAReceberParcela
'=============================================================================================
'
Public Class clAReceber : Implements IEditableObject
#Region "ESTRUTURA DOS DADOS"
    Structure ReceberStructure ' alguns usam FRIEND em vez de DIM
        '
        '--- Itens da tblAReceber
        Dim _IDAReceber As Integer?
        Dim _IDOrigem As Integer?
        Dim _Origem As Byte
        Dim _IDFilial As Integer
        Dim _IDPessoa As Integer?
        Dim _AReceberValor As Decimal
        Dim _ValorPagoTotal As Decimal
        Dim _SituacaoAReceber As Byte '--- 0:EmAberto | 1:Pago | 2:Cancelada
        Dim _IDCobrancaForma As Int16? 'smallint
        Dim _IDPlano As Int16?
        '--- Itens da qryPessoaFisicaJuridica
        Dim _Cadastro As String
        Dim _CNP As String
        '--- Itens da tblPessoaFilial
        Dim _ApelidoFilial As String
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Friend ReceberData As ReceberStructure
    Friend ReceberData_backup As ReceberStructure
    Friend inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        ReceberData = New ReceberStructure()
        With ReceberData
            ._IDOrigem = Nothing
            ._IDPessoa = Nothing
            ._AReceberValor = 0
            ._SituacaoAReceber = 0
            ._IDCobrancaForma = Nothing
            ._IDPlano = Nothing
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Overridable Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            ReceberData_backup = ReceberData
            inTxn = True
        End If
    End Sub
    '
    Public Overridable Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.ReceberData = ReceberData_backup
            inTxn = False
        End If
    End Sub
    '
    Public Overridable Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            ReceberData_backup = New ReceberStructure()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    '--- Propriedade que Aciona o evento AoAlterar
    Public Sub RaiseAoAlterar()
        RaiseEvent AoAlterar()
    End Sub
    '
    Public ReadOnly Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
    End Property
    '
    Public Enum EnumAReceberOrigem
        Venda = 1           ' IDOrigem : tblVenda
        Refinanciamento = 2 ' IDOrigem : tblRefinanciamento
        SimplesSaida = 3    ' IDOrigem : tblSimples
        DevolucaoSaida = 4  ' IDOrigem : tblDevolucaoSaida
    End Enum
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    '--- Propriedade IDAReceber
    Public Property IDAReceber() As Integer
        Get
            Return ReceberData._IDAReceber
        End Get
        Set(ByVal value As Integer)
            If value <> ReceberData._IDAReceber Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._IDAReceber = value
        End Set
    End Property
    '
    '--- Propriedade IDTransacao
    Public Property IDOrigem() As Integer
        Get
            Return ReceberData._IDOrigem
        End Get
        Set(ByVal value As Integer)
            If value <> ReceberData._IDOrigem Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._IDOrigem = value
        End Set
    End Property
    '
    '--- Propriedade Origem
    Public Property Origem() As EnumAReceberOrigem
        Get
            Return ReceberData._Origem
        End Get
        Set(ByVal value As EnumAReceberOrigem)
            If value <> ReceberData._Origem Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._Origem = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public Property IDFilial() As Integer
        Get
            Return ReceberData._IDFilial
        End Get
        Set(ByVal value As Integer)
            If value <> ReceberData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade FilialApelido
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
        Get
            Return ReceberData._ApelidoFilial
        End Get
        Set(ByVal value As String)
            If value <> ReceberData._ApelidoFilial Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._ApelidoFilial = value
        End Set
    End Property
    '
    '--- Propriedade IDPessoa
    Public Property IDPessoa() As Integer?
        Get
            Return ReceberData._IDPessoa
        End Get
        Set(ByVal value As Integer?)
            If value <> ReceberData._IDPessoa Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._IDPessoa = value
        End Set
    End Property
    '
    '--- Propriedade AReceberValor
    Public Property AReceberValor() As Decimal
        Get
            Return ReceberData._AReceberValor
        End Get
        Set(ByVal value As Decimal)
            If value <> ReceberData._AReceberValor Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._AReceberValor = value
        End Set
    End Property
    '
    '--- Propriedade ValorPago
    Public Property ValorPagoTotal() As Decimal
        Get
            Return ReceberData._ValorPagoTotal
        End Get
        Set(ByVal value As Decimal)
            If value <> ReceberData._ValorPagoTotal Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._ValorPagoTotal = value
        End Set
    End Property
    '
    '--- Propriedade Situacao
    Public Property SituacaoAReceber() As Byte
        Get
            Return ReceberData._SituacaoAReceber
        End Get
        Set(ByVal value As Byte)
            If value <> ReceberData._SituacaoAReceber Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._SituacaoAReceber = value
        End Set
    End Property
    '
    Property IDCobrancaForma() As Int16?
        Get
            Return ReceberData._IDCobrancaForma
        End Get
        Set(value As Int16?)
            If Not IsNothing(ReceberData._IDCobrancaForma) AndAlso value <> ReceberData._IDCobrancaForma Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._IDCobrancaForma = value
        End Set
    End Property
    '
    Public Property CobrancaForma As String
    '
    Property IDPlano() As Int16?
        Get
            Return ReceberData._IDPlano
        End Get
        Set(value As Nullable(Of Int16))
            If Not IsNothing(ReceberData._IDPlano) AndAlso value <> ReceberData._IDPlano Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._IDPlano = value
        End Set
    End Property
    '
    '--- Propriedade Cadastro
    Public Property Cadastro() As String
        Get
            Return ReceberData._Cadastro
        End Get
        Set(ByVal value As String)
            If value <> ReceberData._Cadastro Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._Cadastro = value
        End Set
    End Property
    '
    '--- Propriedade CNP
    Public Property CNP() As String
        Get
            Return ReceberData._CNP
        End Get
        Set(ByVal value As String)
            If value <> ReceberData._CNP Then
                RaiseEvent AoAlterar()
            End If
            ReceberData._CNP = value
        End Set
    End Property
    '
#End Region
    '
End Class
'
Public Class clAReceberParcela
    Inherits clAReceber
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure ParcelaStructure ' alguns usam FRIEND em vez de DIM
        '--- Itens da tblAReceberParcela
        Dim _IDAReceberParcela As Integer?
        Dim _Letra As String
        Dim _Vencimento As Date?
        Dim _ParcelaValor As Decimal
        Dim _PermanenciaTaxa As Double
        Dim _ValorPagoParcela As Decimal
        Dim _ValorJuros As Decimal
        Dim _SituacaoParcela As Byte  '--- 0:EmAberto | 1:Pago | 2:Cancelada | 3:Negativada | 4:Negociada
        Dim _PagamentoData As Date?
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private ParData As ParcelaStructure
    Private ParData_backup As ParcelaStructure
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        ParData = New ParcelaStructure()
        With ParData
            ._IDAReceberParcela = Nothing
            ._Letra = ""
            ._PermanenciaTaxa = 0
            ._ValorPagoParcela = 0
            ._SituacaoParcela = 0
            ._PagamentoData = Nothing
            ._ValorJuros = Nothing
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Overloads Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            ReceberData_backup = ReceberData
            ParData_backup = ParData
            inTxn = True
        End If
    End Sub
    '
    Public Overloads Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            ReceberData = ReceberData_backup
            ParData = ParData_backup
            inTxn = False
        End If
    End Sub
    '
    Public Overloads Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            ReceberData_backup = New ReceberStructure()
            ParData_backup = New ParcelaStructure()
            inTxn = False
        End If
    End Sub
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    '--- Propriedade IDAReceberParcela
    Public Property IDAReceberParcela() As Integer?
        Get
            Return ParData._IDAReceberParcela
        End Get
        Set(ByVal value As Integer?)
            If value <> ParData._IDAReceberParcela Then
                RaiseAoAlterar()
            End If
            ParData._IDAReceberParcela = value
        End Set
    End Property
    '
    '--- Propriedade Letra
    Public Property Letra() As String
        Get
            Return ParData._Letra
        End Get
        Set(ByVal value As String)
            If value <> ParData._Letra Then
                RaiseAoAlterar()
            End If
            ParData._Letra = value
        End Set
    End Property
    '
    '--- Propriedade Vencimento
    Public Property Vencimento() As Date?
        Get
            Return ParData._Vencimento
        End Get
        Set(ByVal value As Date?)
            If value <> ParData._Vencimento Then
                RaiseAoAlterar()
            End If
            ParData._Vencimento = value
        End Set
    End Property
    '
    '--- Propriedade PermanenciaTaxa
    Public Property PermanenciaTaxa() As Double
        Get
            Return ParData._PermanenciaTaxa
        End Get
        Set(ByVal value As Double)
            If value <> ParData._PermanenciaTaxa Then
                RaiseAoAlterar()
            End If
            ParData._PermanenciaTaxa = value
        End Set
    End Property
    '
    '--- Propriedade PagamentoData
    Public Property PagamentoData() As Date?
        Get
            Return ParData._PagamentoData
        End Get
        Set(ByVal value As Date?)
            If value <> ParData._PagamentoData Then
                RaiseAoAlterar()
            End If
            ParData._PagamentoData = value
        End Set
    End Property
    '
    '--- Propriedade ValorJuros
    Public Property ValorJuros() As Decimal
        Get
            Return ParData._ValorJuros
        End Get
        Set(ByVal value As Decimal)
            If value <> ParData._ValorJuros Then
                RaiseAoAlterar()
            End If
            ParData._ValorJuros = value
        End Set
    End Property
    '
    '--- Propriedade ParcelaValor
    Public Property ParcelaValor() As Decimal
        Get
            Return ParData._ParcelaValor
        End Get
        Set(ByVal value As Decimal)
            If value <> ParData._ParcelaValor Then
                RaiseAoAlterar()
            End If
            ParData._ParcelaValor = value
        End Set
    End Property
    '
    '--- Propriedade ValorPagoParcela
    Public Property ValorPagoParcela() As Decimal
        Get
            Return ParData._ValorPagoParcela
        End Get
        Set(ByVal value As Decimal)
            If value <> ParData._ValorPagoParcela Then
                RaiseAoAlterar()
            End If
            ParData._ValorPagoParcela = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoParcela
    Public Property SituacaoParcela() As Byte
        Get
            Return ParData._SituacaoParcela
        End Get
        Set(ByVal value As Byte)
            If value <> ParData._SituacaoParcela Then
                RaiseAoAlterar()
            End If
            ParData._SituacaoParcela = value
        End Set
    End Property
    '
    '--- Propriedade READONLY SituacaoDescricao
    Public ReadOnly Property SituacaoDescricao() As String
        Get
            Select Case SituacaoParcela
                Case = 0
                    Return "Em Aberto"
                Case = 1
                    Return "Pago"
                Case = 2
                    Return "Cancelada"
                Case = 3
                    Return "Negativada"
                Case = 4
                    Return "Negociada"
                Case Else
                    Return "Indeterminado"
            End Select
        End Get
    End Property
    '
    '--- Propriedade READONLY CodRegistro
    Public ReadOnly Property CodRegistro() As String
        Get
            Return Format(IDAReceber, "0000") & Letra
        End Get
    End Property
    '
    '--- Propriedade READONLY ValorPagoTotal
    Public ReadOnly Property ValorPagoMaisJuros() As Decimal?
        Get
            If Not IsNothing(ValorPagoParcela) AndAlso Not IsNothing(ValorJuros) Then
                Return ValorPagoParcela + ValorJuros
            Else
                Return Nothing
            End If
        End Get
    End Property
    '
#End Region
    '
End Class
