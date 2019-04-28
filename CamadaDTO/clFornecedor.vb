Imports System.ComponentModel
'
Public Class clFornecedor
    Inherits clPessoaJuridica
    Implements IEditableObject

#Region "ESTRUTURA DOS DADOS"
    Structure StructureFornecedor
        Dim _Ativo As Boolean
        Dim _Vendedor As String
        Dim _EmailVendas As String
        Dim _Observacao As String
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES, NEW"
    Private FornData As StructureFornecedor
    Private FornData_Backup As StructureFornecedor
    '
    Public Sub New()
        FornData = New StructureFornecedor()
        With FornData
            ._Ativo = True
        End With
    End Sub
    '
    Public Overrides Function ToString() As String
        Return Cadastro.ToString
    End Function
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Overrides Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            PEndData_Backup = PEndData
            PJData_Backup = PJData
            FornData_Backup = FornData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overrides Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            PJData = PJData_Backup
            FornData = FornData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overrides Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa
            PEndData_Backup = New StructurePEndereco
            PJData_Backup = New StructurePJuridica
            FornData_Backup = New StructureFornecedor()
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
            Return FornData._Ativo
        End Get
        Set(ByVal value As Boolean)
            If value <> FornData._Ativo Then
                RaiseAoAlterar()
            End If
            FornData._Ativo = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    Public Property Observacao() As String
        Get
            Return FornData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> FornData._Observacao Then
                RaiseAoAlterar()
            End If
            FornData._Observacao = value
        End Set
    End Property
    '
    '--- Propriedade Vendedor
    Public Property Vendedor() As String
        Get
            Return FornData._Vendedor
        End Get
        Set(ByVal value As String)
            If value <> FornData._Vendedor Then
                RaiseAoAlterar()
            End If
            FornData._Vendedor = value
        End Set
    End Property
    '
    '--- Propriedade EmailVendas
    Public Property EmailVendas() As String
        Get
            Return FornData._EmailVendas
        End Get
        Set(ByVal value As String)
            If value <> FornData._EmailVendas Then
                RaiseAoAlterar()
            End If
            FornData._EmailVendas = value
        End Set
    End Property
    '
#End Region
    '
End Class
