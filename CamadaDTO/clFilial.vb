Imports System.ComponentModel

Public Class clFilial
    Inherits clPessoa
    Implements IEditableObject

#Region "ESTRUTURA DOS DADOS"
    Structure StructureFilial ' alguns usam FRIEND em vez de DIM
        Dim _ApelidoFilial As String
        Dim _AliquotaICMS As Decimal
        Dim _Ativo As Boolean
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private FilialData As StructureFilial
    Private FilialData_Backup As StructureFilial
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        FilialData = New StructureFilial()
        With FilialData
            ._AliquotaICMS = 0
            ._Ativo = True
        End With
        '
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            FilialData_Backup = FilialData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            FilialData = FilialData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa()
            FilialData_Backup = New StructureFilial()
            RegistroAlterado = False
        End If
    End Sub
    '
#End Region '/ IMPLEMENTS EVENTS
    '
#Region "PROPERTIES"
    '
    '--- Propriedade ApelidoFilial
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
        Get
            Return FilialData._ApelidoFilial
        End Get
        Set(ByVal value As String)
            If value <> FilialData._ApelidoFilial Then
                RaiseAoAlterar()
            End If
            FilialData._ApelidoFilial = value
        End Set
    End Property
    '
    '--- Propriedade AliquotaICMS
    '------------------------------------------------------
    Public Property AliquotaICMS() As Decimal
        Get
            Return FilialData._AliquotaICMS
        End Get
        Set(ByVal value As Decimal)
            If value <> FilialData._AliquotaICMS Then
                RaiseAoAlterar()
            End If
            FilialData._AliquotaICMS = value
        End Set
    End Property
    '
    '--- Propriedade Ativo
    '------------------------------------------------------
    Public Property Ativo() As Boolean
        Get
            Return FilialData._Ativo
        End Get
        Set(ByVal value As Boolean)
            If value <> FilialData._Ativo Then
                RaiseAoAlterar()
            End If
            FilialData._Ativo = value
        End Set
    End Property
    '
#End Region '/ PROPERTIES
    '
End Class
