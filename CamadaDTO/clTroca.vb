Imports System.ComponentModel

Public Class clTroca : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure TrocaDados ' alguns usam FRIEND em vez de DIM
        '
        'tblTroca =====================================================
        Dim _IDTroca As Integer
        Dim _TrocaData As Date
        Dim _IDTransacaoEntrada As Integer
        Dim _IDVenda As Integer
        Dim _Observacao As String
        Dim _IDSituacao As Byte 'tinyint
        Dim _ValorTotal As Decimal '--- Valor final da TROCA
        '
        'tblVenda =====================================================
        ' PROP IDFilial As Integer
        ' PROP ApelidoFilial As String
        ' PROP IDPessoaTroca As Integer
        ' PROP PessoaTroca As String
        ' PROP Situacao As String
        ' PROP IDVendedor as Integer
        ' PROP ApelidoVenda as String
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private TData As TrocaDados
    Private backupData As TrocaDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        TData = New TrocaDados()
        With TData
            ._IDTroca = Nothing
            ._IDSituacao = 1 '--- INICIADA
            ._ValorTotal = 0
        End With
    End Sub
    '
    Public Sub New(
                  myIDVenda As Integer,
                  myTrocaData As Date,
                  myIDFilial As Integer,
                  myApelidoFilial As String,
                  myIDPessoaTroca As Integer,
                  myPessoaTroca As String
                  )
        '
        TData = New TrocaDados With
            {
            ._IDTroca = Nothing,
            ._IDVenda = myIDVenda,
            ._TrocaData = myTrocaData,
            ._IDSituacao = 1,'--- INICIADA
            ._ValorTotal = 0
            }
        '
        IDFilial = myIDFilial
        ApelidoFilial = myApelidoFilial
        IDPessoaTroca = myIDPessoaTroca
        PessoaTroca = myPessoaTroca
        Situacao = "INICIADA"
        '
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = TData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.TData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New TrocaDados()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public Overrides Function ToString() As String
        Return IDTroca.ToString
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
    '--- TBLTROCA
    '===========================================================================================
    '
    Property IDTroca() As Integer
        Get
            Return TData._IDTroca
        End Get
        Set(value As Integer)
            TData._IDTroca = value
        End Set
    End Property
    '
    '--- Propriedade TrocaData
    '------------------------------------------------------
    Public Property TrocaData() As Date
        Get
            Return TData._TrocaData
        End Get
        Set(ByVal value As Date)
            If value <> TData._TrocaData Then
                RaiseEvent AoAlterar()
            End If
            TData._TrocaData = value
        End Set
    End Property
    '
    '--- Propriedade IDTransacaoEntrada
    '------------------------------------------------------
    Public Property IDTransacaoEntrada() As Integer
        Get
            Return TData._IDTransacaoEntrada
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDTransacaoEntrada Then
                RaiseEvent AoAlterar()
            End If
            TData._IDTransacaoEntrada = value
        End Set
    End Property
    '
    '--- Propriedade IDVenda
    '------------------------------------------------------
    Public Property IDVenda() As Integer
        Get
            Return TData._IDVenda
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDVenda Then
                RaiseEvent AoAlterar()
            End If
            TData._IDVenda = value
        End Set
    End Property
    '
    '--- Propriedade ValorTotal
    '------------------------------------------------------
    Public Property ValorTotal() As Decimal
        Get
            Return TData._ValorTotal
        End Get
        Set(ByVal value As Decimal)
            If value <> TData._ValorTotal Then
                RaiseEvent AoAlterar()
            End If
            TData._ValorTotal = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    '------------------------------------------------------
    Public Property Observacao() As String
        Get
            Return TData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> TData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            TData._Observacao = value
        End Set
    End Property
    '
    '--- Propriedade IDSituacao
    '------------------------------------------------------
    Public Property IDSituacao() As Byte
        Get
            Return TData._IDSituacao
        End Get
        Set(ByVal value As Byte)
            If value <> TData._IDSituacao Then
                RaiseEvent AoAlterar()
            End If
            TData._IDSituacao = value
        End Set
    End Property
    '
    '===========================================================================================
    '--- PROPRIEDADES PARA LEITURA
    '===========================================================================================
    '
    Property IDFilial As Integer
    Property ApelidoFilial As String
    Property IDPessoaTroca As Integer
    Property PessoaTroca As String
    Property Situacao As String
    Property IDVendedor As Integer
    Property ApelidoVenda As String
    '
#End Region
    '
End Class
