Imports System.ComponentModel
'
'=======================================================================================
' CLCONTA
'=======================================================================================
Public Class clConta : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure ContaStructure ' alguns usam FRIEND em vez de DIM
        Dim _IDConta As Int16?
        Dim _Conta As String
        Dim _IDFilial As Integer
        Dim _ContaTipo As Byte
        Dim _Ativo As Boolean
        Dim _BloqueioData As Date?
        Dim _SaldoAtual As Double
        Dim _LastIDCaixa As Integer?
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private ContaData As ContaStructure
    Private backupData As ContaStructure
    Private inTxn As Boolean = False
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        ContaData = New ContaStructure()
        With ContaData
            ._SaldoAtual = 0
            ._LastIDCaixa = Nothing
            ._BloqueioData = Nothing
            ._Ativo = True
            ._ContaTipo = 1 '--- CONTA LOCAL
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = ContaData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            ContaData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New ContaStructure()
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
    '--- Propriedade IDConta
    '------------------------------------------------------
    Public Property IDConta() As Int16?
        Get
            Return ContaData._IDConta
        End Get
        Set(ByVal value As Int16?)
            If value <> ContaData._IDConta Then
                RaiseEvent AoAlterar()
            End If
            ContaData._IDConta = value
        End Set
    End Property
    '
    '--- Propriedade Conta
    '------------------------------------------------------
    Public Property Conta() As String
        Get
            Return ContaData._Conta
        End Get
        Set(ByVal value As String)
            If value <> ContaData._Conta Then
                RaiseEvent AoAlterar()
            End If
            ContaData._Conta = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public Property IDFilial() As Integer
        Get
            Return ContaData._IDFilial
        End Get
        Set(ByVal value As Integer)
            If value <> ContaData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            ContaData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade ApelidoFilial
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
    '
    '--- Propriedade CNPJFilial
    '------------------------------------------------------
    Public Property CNPJFilial() As String
    '
    '--- Propriedade ContaTipo
    '------------------------------------------------------
    Public Property ContaTipo() As Byte
        Get
            Return ContaData._ContaTipo
        End Get
        Set(ByVal value As Byte)
            If value <> ContaData._ContaTipo Then
                RaiseEvent AoAlterar()
            End If
            ContaData._ContaTipo = value
        End Set
    End Property
    '
    '--- Propriedade ContaTipoDescricao
    '------------------------------------------------------
    Public ReadOnly Property ContaTipoDescricao() As String
        Get
            Select Case ContaTipo
                Case 1
                    Return "Conta Local"
                Case 2
                    Return "Conta Bancária"
                Case 3
                    Return "Operadora de Cartão"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    '
    '--- Propriedade Ativo
    '------------------------------------------------------
    Public Property Ativo() As Boolean
        Get
            Return ContaData._Ativo
        End Get
        Set(ByVal value As Boolean)
            If value <> ContaData._Ativo Then
                RaiseEvent AoAlterar()
            End If
            ContaData._Ativo = value
        End Set
    End Property
    '
    '--- Propriedade BloqueioData
    '------------------------------------------------------
    Public Property BloqueioData() As Date?
        Get
            Return ContaData._BloqueioData
        End Get
        Set(ByVal value As Date?)
            If value <> ContaData._BloqueioData Then
                RaiseEvent AoAlterar()
            End If
            ContaData._BloqueioData = value
        End Set
    End Property
    '
    '--- Propriedade SaldoAtual
    '------------------------------------------------------
    Public Property SaldoAtual() As Double
        Get
            Return ContaData._SaldoAtual
        End Get
        Set(ByVal value As Double)
            If value <> ContaData._SaldoAtual Then
                RaiseEvent AoAlterar()
            End If
            ContaData._SaldoAtual = value
        End Set
    End Property
    '
    '--- Propriedade LastIDCaixa
    '------------------------------------------------------
    Public Property LastIDCaixa() As Integer?
        Get
            Return ContaData._LastIDCaixa
        End Get
        Set(ByVal value As Integer?)
            If value <> ContaData._LastIDCaixa Then
                RaiseEvent AoAlterar()
            End If
            ContaData._LastIDCaixa = value
        End Set
    End Property
    '
#End Region
    '
End Class
