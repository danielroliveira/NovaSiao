Imports System.ComponentModel
Public Class clTransportadora
    Inherits clPessoaJuridica
    Implements IEditableObject

#Region "ESTRUTURA DOS DADOS"
    Structure StructureTransp
        '--- ORIGEM tblPessoaTransportadora
        Dim _Ativo As Boolean
        Dim _Observacao As String
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES, NEW, FUNCTIONS"
    Private TData As StructureTransp
    Private TData_Backup As StructureTransp
    '
    Public Sub New()
        TData = New StructureTransp()
        With TData
            ._Ativo = True
        End With
    End Sub
    '
    Public Overrides Function ToString() As String
        Return Cadastro
    End Function
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Overrides Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            PEndData_Backup = PEndData
            PJData_Backup = PJData
            TData_Backup = TData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overrides Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            PJData = PJData_Backup
            TData = TData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overrides Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa
            PEndData_Backup = New StructurePEndereco
            PJData_Backup = New StructurePJuridica
            TData_Backup = New StructureTransp()
            RegistroAlterado = False
        End If
    End Sub
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    '--- Propriedade Ativo
    Public Property Ativo() As Boolean
        Get
            Return TData._Ativo
        End Get
        Set(ByVal value As Boolean)
            If value <> TData._Ativo Then
                RaiseAoAlterar()
            End If
            TData._Ativo = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    Public Property Observacao() As String
        Get
            Return TData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> TData._Observacao Then
                RaiseAoAlterar()
            End If
            TData._Observacao = value
        End Set
    End Property
    '
#End Region
    '
End Class
