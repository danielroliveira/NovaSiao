Imports System.ComponentModel
'
'=======================================================================================
' clCAIXA
'=======================================================================================
Public Class clCaixa : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure CaixaStructure ' alguns usam FRIEND em vez de DIM
        Dim _IDCaixa As Integer?
        Dim _IDFilial As Integer?
        Dim _IDConta As Int16?
        Dim _FechamentoData As Date
        Dim _DataInicial As Date
        Dim _DataFinal As Date
        Dim _IDSituacao As Byte? ' 1:INICIADA | 2:CONCLUIDA | 3:FINALIZADA
        Dim _SaldoFinal As Decimal
        Dim _SaldoAnterior As Decimal
        Dim _Observacao As String
        Dim _CaixaFinalDia As Boolean
        Dim _IDFuncionario As Integer? ' operador de caixa
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private CxData As CaixaStructure
    Private backupData As CaixaStructure
    Private inTxn As Boolean = False
    '
    Enum Origem_APagar
        Compra = 1
        Despesa = 2
    End Enum
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        CxData = New CaixaStructure()
        With CxData
            ._SaldoFinal = 0
            ._FechamentoData = Today
            ._IDSituacao = 1 '--- Iniciada
            ._Observacao = ""
            ._CaixaFinalDia = False
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = CxData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.CxData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New CaixaStructure()
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
    '--- Propriedade IDCaixa
    Public Property IDCaixa() As Integer?
        Get
            Return CxData._IDCaixa
        End Get
        Set(ByVal value As Integer?)
            If value <> CxData._IDCaixa Then
                RaiseEvent AoAlterar()
            End If
            CxData._IDCaixa = value
        End Set
    End Property
    '
    '--- Propriedade IDConta
    Public Property IDConta() As Int16?
        Get
            Return CxData._IDConta
        End Get
        Set(ByVal value As Int16?)
            If value <> CxData._IDConta Then
                RaiseEvent AoAlterar()
            End If
            CxData._IDConta = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    Public Property IDFilial() As Integer?
        Get
            Return CxData._IDFilial
        End Get
        Set(ByVal value As Integer?)
            If value <> CxData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            CxData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade FechamentoData
    Public Property FechamentoData() As Date
        Get
            Return CxData._FechamentoData
        End Get
        Set(ByVal value As Date)
            If value <> CxData._FechamentoData Then
                RaiseEvent AoAlterar()
            End If
            CxData._FechamentoData = value
        End Set
    End Property
    '
    '--- Propriedade IDSituacao
    Public Property IDSituacao() As Byte
        Get
            Return CxData._IDSituacao
        End Get
        Set(ByVal value As Byte)
            If value <> CxData._IDSituacao Then
                RaiseEvent AoAlterar()
            End If
            CxData._IDSituacao = value
        End Set
    End Property
    '
    '--- Propriedade DataInicial
    Public Property DataInicial() As Date
        Get
            Return CxData._DataInicial
        End Get
        Set(ByVal value As Date)
            If value <> CxData._DataInicial Then
                RaiseEvent AoAlterar()
            End If
            CxData._DataInicial = value
        End Set
    End Property
    '
    '--- Propriedade DataFinal
    Public Property DataFinal() As Date
        Get
            Return CxData._DataFinal
        End Get
        Set(ByVal value As Date)
            If value <> CxData._DataFinal Then
                RaiseEvent AoAlterar()
            End If
            CxData._DataFinal = value
        End Set
    End Property
    '
    '--- Propriedade SaldoFinal
    Public Property SaldoFinal() As Decimal
        Get
            Return CxData._SaldoFinal
        End Get
        Set(ByVal value As Decimal)
            If value <> CxData._SaldoFinal Then
                RaiseEvent AoAlterar()
            End If
            CxData._SaldoFinal = value
        End Set
    End Property
    '
    '--- Propriedade SaldoAnterior
    Public Property SaldoAnterior() As Decimal
        Get
            Return CxData._SaldoAnterior
        End Get
        Set(ByVal value As Decimal)
            If value <> CxData._SaldoAnterior Then
                RaiseEvent AoAlterar()
            End If
            CxData._SaldoAnterior = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    Public Property Observacao() As String
        Get
            Return CxData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> CxData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            CxData._Observacao = value
        End Set
    End Property
    '
    '--- Propriedade CaixaFinalDia
    '------------------------------------------------------
    Public Property CaixaFinalDia() As Boolean
        Get
            Return CxData._CaixaFinalDia
        End Get
        Set(ByVal value As Boolean)
            If value <> CxData._CaixaFinalDia Then
                RaiseEvent AoAlterar()
            End If
            CxData._CaixaFinalDia = value
        End Set
    End Property
    '
    '--- Propriedade IDFuncionario (operador de caixa)
    '------------------------------------------------------
    Public Property IDFuncionario() As Integer?
        Get
            Return CxData._IDFuncionario
        End Get
        Set(ByVal value As Integer?)
            If value <> CxData._IDFuncionario Then
                RaiseEvent AoAlterar()
            End If
            CxData._IDFuncionario = value
        End Set
    End Property
    '
    '----------------------------------------------------------------
    '  PROPRIEDADES DE OUTRAS TABELAS
    '----------------------------------------------------------------
    Property Conta As String
    Property ApelidoFilial As String
    Property Situacao As String
    Property ApelidoFuncionario As String
    '
#End Region
    '
End Class

Public Class clCaixaAnteriorInfo
    Property MovsDataInicial As Date?
    Property MovsDataFinal As Date?
    Property CaixaSaldoFinal As Decimal
    Property CaixaIDSituacao As Byte
    Property LastIDCaixa As Integer?
    Property BloqueiaDataFinal As Boolean
    Property CaixaDataFinal As Date?
End Class