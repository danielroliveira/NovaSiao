Imports System.ComponentModel

Public Class clCredor
    Inherits clPessoaEndereco
    Implements IEditableObject

#Region "ESTRUTURA DOS DADOS"
    Structure StructureCredor ' alguns usam FRIEND em vez de DIM
        Dim _CNP As String
        Dim _CredorTipo As Byte '0:Credor Simples | 1:Credor PF | 2:Credor PJ | 3:OrgaoPublico
        Dim _Ativo As Boolean
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private CredData As StructureCredor
    Private CredData_Backup As StructureCredor
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        CredData = New StructureCredor()
        With CredData
            ._CredorTipo = 0
            ._Ativo = True
        End With
        '
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            PEndData_Backup = PEndData
            CredData_Backup = CredData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            CredData = CredData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa()
            PEndData_Backup = New StructurePEndereco()
            CredData_Backup = New StructureCredor()
            RegistroAlterado = False
        End If
    End Sub
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    '--- Propriedade CNP
    Public Property CNP() As String
        Get
            Return CredData._CNP
        End Get
        Set(ByVal value As String)
            If value <> CredData._CNP Then
                RaiseAoAlterar()
            End If
            CredData._CNP = value
        End Set
    End Property
    '
    '--- Propriedade CredorTipo
    Public Property CredorTipo() As Byte
        '0:Credor Simples | 1:Credor PF | 2:Credor PJ | 3:OrgaoPublico
        Get
            Return CredData._CredorTipo
        End Get
        Set(ByVal value As Byte)
            If value <> CredData._CredorTipo Then
                RaiseAoAlterar()
            End If
            CredData._CredorTipo = value
        End Set
    End Property
    '
    '--- Propriedade Ativo
    Public Property Ativo() As Boolean
        Get
            Return CredData._Ativo
        End Get
        Set(ByVal value As Boolean)
            If value <> CredData._Ativo Then
                RaiseAoAlterar()
            End If
            CredData._Ativo = value
        End Set
    End Property
    '
#End Region

End Class
