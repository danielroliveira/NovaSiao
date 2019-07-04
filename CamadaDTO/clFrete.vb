Imports System.ComponentModel
'
'=======================================================================================
' CLFRETE
'=======================================================================================
Public Class clFrete : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure FreteStructure ' alguns usam FRIEND em vez de DIM
        Dim _IDTransacao As Integer
        Dim _TransacaoData As Date
        Dim _IDOperacao As Byte
        Dim _Operacao As String
        Dim _FreteTipo As Byte
        Dim _FreteTipoTexto As String
        Dim _FreteValor As Double
        Dim _Conhecimento As String
        Dim _ConhecimentoData As Date?
        Dim _IDFreteDespesa As Integer?
        Dim _IDTransportadora As Integer
        Dim _Transportadora As String
        Dim _Volumes As Int16
        Dim _IDFilial As Integer
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private FreteData As FreteStructure
    Private backupData As FreteStructure
    Private inTxn As Boolean = False
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New(IDTransacao As Integer, TransacaoData As Date, IDFilial As Integer)
        FreteData = New FreteStructure()
        With FreteData
            ._IDTransacao = IDTransacao
            ._TransacaoData = TransacaoData
            ._IDFilial = IDFilial
            ._FreteValor = 0
            ._Volumes = 1
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = FreteData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            FreteData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New FreteStructure()
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
    '--- Propriedade IDTransacao
    '------------------------------------------------------
    Public ReadOnly Property IDTransacao() As Integer
        Get
            Return FreteData._IDTransacao
        End Get
    End Property
    '
    '--- Propriedade TransacaoData
    '------------------------------------------------------
    Public ReadOnly Property TransacaoData() As Date
        Get
            Return FreteData._TransacaoData
        End Get
    End Property
    '
    '--- Propriedade IDOperacao
    '------------------------------------------------------
    Public Property IDOperacao() As Byte
        Get
            Return FreteData._IDOperacao
        End Get
        Set(ByVal value As Byte)
            If value <> FreteData._IDOperacao Then
                RaiseEvent AoAlterar()
            End If
            FreteData._IDOperacao = value
        End Set
    End Property
    '
    '--- Propriedade Operacao
    '------------------------------------------------------
    Public Property Operacao() As String
        Get
            Return FreteData._Operacao
        End Get
        Set(ByVal value As String)
            If value <> FreteData._Operacao Then
                RaiseEvent AoAlterar()
            End If
            FreteData._Operacao = value
        End Set
    End Property
    '
    '--- Propriedade FreteTipo
    '------------------------------------------------------
    Public Property FreteTipo() As Byte
        Get
            Return FreteData._FreteTipo
        End Get
        Set(ByVal value As Byte)
            If value <> FreteData._FreteTipo Then
                RaiseEvent AoAlterar()
            End If
            FreteData._FreteTipo = value
        End Set
    End Property
    '
    '--- Propriedade FreteTipoTexto
    '------------------------------------------------------
    Public Property FreteTipoTexto() As String
        Get
            Return FreteData._FreteTipoTexto
        End Get
        Set(ByVal value As String)
            If value <> FreteData._FreteTipoTexto Then
                RaiseEvent AoAlterar()
            End If
            FreteData._FreteTipoTexto = value
        End Set
    End Property
    '
    '--- Propriedade FreteValor
    '------------------------------------------------------
    Public Property FreteValor() As Double
        Get
            Return FreteData._FreteValor
        End Get
        Set(ByVal value As Double)
            If value <> FreteData._FreteValor Then
                RaiseEvent AoAlterar()
            End If
            FreteData._FreteValor = value
        End Set
    End Property
    '
    '--- Propriedade Conhecimento
    '------------------------------------------------------
    Public Property Conhecimento() As String
        Get
            Return FreteData._Conhecimento
        End Get
        Set(ByVal value As String)
            If value <> FreteData._Conhecimento Then
                RaiseEvent AoAlterar()
            End If
            FreteData._Conhecimento = value
        End Set
    End Property
    '
    '--- Propriedade ConhecimentoData
    '------------------------------------------------------
    Public Property ConhecimentoData() As Date?
        Get
            Return FreteData._ConhecimentoData
        End Get
        Set(ByVal value As Date?)
            If value <> FreteData._ConhecimentoData Then
                RaiseEvent AoAlterar()
            End If
            If IsDate(value) Then
                FreteData._ConhecimentoData = value.Value.ToShortDateString
            Else
                FreteData._ConhecimentoData = value
            End If
        End Set
    End Property
    '
    '--- Propriedade IDFreteDespesa
    '------------------------------------------------------
    Public Property IDFreteDespesa() As Integer?
        Get
            Return FreteData._IDFreteDespesa
        End Get
        Set(ByVal value As Integer?)
            If value <> FreteData._IDFreteDespesa Then
                RaiseEvent AoAlterar()
            End If
            FreteData._IDFreteDespesa = value
        End Set
    End Property
    '
    '--- Propriedade IDTransportadora
    '------------------------------------------------------
    Public Property IDTransportadora() As Integer
        Get
            Return FreteData._IDTransportadora
        End Get
        Set(ByVal value As Integer)
            If value <> FreteData._IDTransportadora Then
                RaiseEvent AoAlterar()
            End If
            FreteData._IDTransportadora = value
        End Set
    End Property
    '
    '--- Propriedade Transportadora
    '------------------------------------------------------
    Public Property Transportadora() As String
        Get
            Return FreteData._Transportadora
        End Get
        Set(ByVal value As String)
            If value <> FreteData._Transportadora Then
                RaiseEvent AoAlterar()
            End If
            FreteData._Transportadora = value
        End Set
    End Property
    '
    '--- Propriedade Volumes
    '------------------------------------------------------
    Public Property Volumes() As Int16
        Get
            Return FreteData._Volumes
        End Get
        Set(ByVal value As Int16)
            If value <> FreteData._Volumes Then
                RaiseEvent AoAlterar()
            End If
            FreteData._Volumes = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public ReadOnly Property IDFilial() As Integer
        Get
            Return FreteData._IDFilial
        End Get
    End Property
    '
#End Region
    '
End Class
