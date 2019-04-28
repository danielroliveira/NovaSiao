Imports System.ComponentModel
'
Public Class clFuncionario
    Inherits clPessoaFisica
    Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure StructureFuncionario ' alguns usam FRIEND em vez de DIM
        Friend _AdmissaoData As Nullable(Of Date)
        Friend _Ativo As Boolean
        Friend _Vendedor As Boolean
        Friend _IDFilial As Integer?
        Friend _ApelidoFuncionario As String
        Friend _Comissao As Decimal?
        Friend _VendaTipo As Byte?
        Friend _VendedorAtivo As Boolean?
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private FuncData As StructureFuncionario
    Private FuncData_Backup As StructureFuncionario
    '
    Public Overrides Function ToString() As String
        Return Cadastro
    End Function
    '
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        FuncData = New StructureFuncionario()
        With FuncData
            ._Ativo = True
            ._Vendedor = False
            ._VendedorAtivo = True
        End With
    End Sub
    '
    Public Overrides Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            PEndData_Backup = PEndData
            PFData_Backup = PFData
            FuncData_Backup = FuncData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overrides Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            PFData = PFData_Backup
            FuncData = FuncData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overrides Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa
            PEndData_Backup = New StructurePEndereco
            PFData_Backup = New StructurePFisica
            FuncData_Backup = New StructureFuncionario()
            RegistroAlterado = False
        End If
    End Sub
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    Property AdmissaoData() As Date?
        Get
            Return FuncData._AdmissaoData
        End Get
        Set(value As Date?)
            If value <> FuncData._AdmissaoData Then
                RaiseAoAlterar()
            End If
            FuncData._AdmissaoData = value
        End Set
    End Property
    '
    Property Ativo() As Boolean
        Get
            Return FuncData._Ativo
        End Get
        Set(value As Boolean)
            If value <> FuncData._Ativo Then
                RaiseAoAlterar()
            End If
            FuncData._Ativo = value
        End Set
    End Property
    '
    Property Vendedor() As Boolean
        Get
            Return FuncData._Vendedor
        End Get
        Set(value As Boolean)
            If value <> FuncData._Vendedor Then
                RaiseAoAlterar()
            End If
            FuncData._Vendedor = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    Public Property IDFilial() As Integer
        Get
            Return FuncData._IDFilial
        End Get
        Set(ByVal value As Integer)
            If value <> FuncData._IDFilial Then
                RaiseAoAlterar()
            End If
            FuncData._IDFilial = value
        End Set
    End Property
    '
    Property ApelidoFuncionario() As String
        Get
            Return FuncData._ApelidoFuncionario
        End Get
        Set(value As String)
            If value <> FuncData._ApelidoFuncionario Then
                RaiseAoAlterar()
            End If
            FuncData._ApelidoFuncionario = value
        End Set
    End Property
    '
    Property Comissao() As Decimal?
        Get
            Return FuncData._Comissao
        End Get
        Set(value As Decimal?)
            If value <> FuncData._Comissao Then
                RaiseAoAlterar()
            End If
            '
            If Not IsNothing(value) Then
                FuncData._Comissao = CDec(value)
            Else
                FuncData._Comissao = value
            End If
            '
        End Set
    End Property
    '
    Property VendaTipo() As Byte?
        Get
            Return FuncData._VendaTipo
        End Get
        Set(value As Byte?)
            If value <> FuncData._VendaTipo Then
                RaiseAoAlterar()
            End If
            '
            If IsNothing(value) Then
                FuncData._VendaTipo = value
            Else
                FuncData._VendaTipo = CByte(value)
            End If
            '
        End Set
    End Property
    '
    Property VendedorAtivo() As Boolean?
        Get
            Return FuncData._VendedorAtivo
        End Get
        Set(value As Boolean?)
            If value <> FuncData._VendedorAtivo Then
                RaiseAoAlterar()
            End If
            FuncData._VendedorAtivo = value
        End Set
    End Property
    '
    Property ApelidoFilial As String
    '
#End Region
    '
End Class
