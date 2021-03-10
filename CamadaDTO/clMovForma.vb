Imports System.ComponentModel
'
'=======================================================================================
' clMOVFORMA
'=======================================================================================
Public Class clMovForma : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure FormaStructure ' alguns usam FRIEND em vez de DIM
        Dim _IDMovForma As Int16?
        Dim _MovForma As String
        Dim _IDMovTipo As Int16?
        Dim _MovTipo As String
        Dim _IDCartao As Byte?
        Dim _Cartao As String
        Dim _Parcelas As Byte?
        Dim _Comissao As Decimal?
        Dim _NoDias As Byte?
        Dim _Ativo As Boolean
        '--- Adicionados
        Dim _IDFilial As Integer
        Dim _ApelidoFilial As String
        Dim _IDContaPadrao As Int16?
        Dim _ContaPadrao As String
        Dim _IDMeio As Byte
        'Dim _MeioDescricao As String
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private FData As FormaStructure
    Private backupData As FormaStructure
    Private inTxn As Boolean = False
    '
    'Enum Origem_APagar
    '    Compra = 1
    '    Despesa = 2
    'End Enum
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        FData = New FormaStructure()
        With FData
            ._Ativo = True
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        '
        If Not inTxn Then
            Me.backupData = FData
            inTxn = True
        End If
        '
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.FData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New FormaStructure()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
        Set(value As Boolean)
            inTxn = value
        End Set
    End Property
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    '--- Propriedade IDMovForma
    Public Property IDMovForma() As Int16?
        Get
            Return FData._IDMovForma
        End Get
        Set(ByVal value As Int16?)
            If value <> FData._IDMovForma Then
                RaiseEvent AoAlterar()
            End If
            FData._IDMovForma = value
        End Set
    End Property
    '
    '--- Propriedade MovForma
    Public Property MovForma() As String
        Get
            Return FData._MovForma
        End Get
        Set(ByVal value As String)
            If value <> FData._MovForma Then
                RaiseEvent AoAlterar()
            End If
            FData._MovForma = value
        End Set
    End Property
    '
    '--- Propriedade IDMovTipo
    Public Property IDMovTipo() As Int16?
        Get
            Return FData._IDMovTipo
        End Get
        Set(ByVal value As Int16?)
            '
            If Not value.Equals(FData._IDMovTipo) Then
                RaiseEvent AoAlterar()
            End If
            '
            FData._IDMovTipo = value
        End Set
    End Property
    '
    '--- Propriedade MovTipo
    Public Property MovTipo() As String
        Get
            Return FData._MovTipo
        End Get
        Set(ByVal value As String)
            If value <> FData._MovTipo Then
                RaiseEvent AoAlterar()
            End If
            FData._MovTipo = value
        End Set
    End Property
    '
    '--- Propriedade IDCartao
    Public Property IDCartao() As Byte?
        Get
            Return FData._IDCartao
        End Get
        Set(ByVal value As Byte?)
            If Not value.Equals(FData._IDCartao) Then
                RaiseEvent AoAlterar()
            End If
            FData._IDCartao = value
        End Set
    End Property
    '
    '--- Propriedade Cartao
    Public Property Cartao() As String
        Get
            Return FData._Cartao
        End Get
        Set(ByVal value As String)
            If value <> FData._Cartao Then
                RaiseEvent AoAlterar()
            End If
            FData._Cartao = value
        End Set
    End Property
    '
    '--- Propriedade Parcelas
    Public Property Parcelas() As Byte?
        Get
            Return FData._Parcelas
        End Get
        Set(ByVal value As Byte?)
            If Not value.Equals(FData._Parcelas) Then
                RaiseEvent AoAlterar()
            End If
            FData._Parcelas = value
        End Set
    End Property
    '
    '--- Propriedade Comissao
    Public Property Comissao() As Decimal?
        Get
            Return FData._Comissao
        End Get
        Set(ByVal value As Decimal?)
            If Not value.Equals(FData._Comissao) Then
                RaiseEvent AoAlterar()
            End If
            FData._Comissao = value
        End Set
    End Property
    '
    '--- Propriedade NoDias
    Public Property NoDias() As Byte?
        Get
            Return FData._NoDias
        End Get
        Set(ByVal value As Byte?)
            If Not value.Equals(FData._NoDias) Then
                RaiseEvent AoAlterar()
            End If
            FData._NoDias = value
        End Set
    End Property
    '
    '--- Propriedade Ativo
    Public Property Ativo() As Boolean
        Get
            Return FData._Ativo
        End Get
        Set(ByVal value As Boolean)
            If value <> FData._Ativo Then
                RaiseEvent AoAlterar()
            End If
            FData._Ativo = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public Property IDFilial() As Integer
        Get
            Return FData._IDFilial
        End Get
        Set(ByVal value As Integer)
            If value <> FData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            FData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade ApelidoFilial
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
        Get
            Return FData._ApelidoFilial
        End Get
        Set(ByVal value As String)
            If value <> FData._ApelidoFilial Then
                RaiseEvent AoAlterar()
            End If
            FData._ApelidoFilial = value
        End Set
    End Property
    '
    '--- Propriedade IDContaPadrao
    '------------------------------------------------------
    Public Property IDContaPadrao() As Int16?
        Get
            Return FData._IDContaPadrao
        End Get
        Set(ByVal value As Int16?)
            If Not value.Equals(FData._IDContaPadrao) Then
                RaiseEvent AoAlterar()
            End If
            FData._IDContaPadrao = value
        End Set
    End Property
    '
    '--- Propriedade ContaPadrao
    '------------------------------------------------------
    Public Property ContaPadrao() As String
        Get
            Return FData._ContaPadrao
        End Get
        Set(ByVal value As String)
            If value <> FData._ContaPadrao Then
                RaiseEvent AoAlterar()
            End If
            FData._ContaPadrao = value
        End Set
    End Property
    '
    '--- Propriedade Meio
    '------------------------------------------------------
    Public Property IDMeio() As Byte
        Get
            Return FData._IDMeio
        End Get
        Set(ByVal value As Byte)
            If value <> FData._IDMeio Then
                RaiseEvent AoAlterar()
            End If
            FData._IDMeio = value
        End Set
    End Property
    '
    '--- Propriedade MeioDescricao
    '------------------------------------------------------
    Public ReadOnly Property MeioDescricao() As String
        Get
            Select Case IDMeio
                Case 1
                    Return "Moeda"
                Case 2
                    Return "Cheque"
                Case 3
                    Return "Cartão"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    '
#End Region
    '
End Class

Public Class clMovTipo
    Property IDMovTipo As Short
    Property MovTipo As String
    Property Ativo As Boolean
    Property IDMeio As Byte
End Class