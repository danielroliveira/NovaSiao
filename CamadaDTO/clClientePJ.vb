Imports System.ComponentModel

Public Class clClientePJ
    Inherits clPessoaJuridica
    Implements IEditableObject

#Region "ESTRUTURA DOS DADOS"
    Structure StructureClientePJ ' alguns usam FRIEND em vez de DIM
        Dim _IDSituacao As Byte
        Dim _ClienteDesde As Date?
        Dim _RGAtividade As Byte
        Dim _LimiteCompras As Double
        Dim _UltimaVenda As Date?
        Dim _RGCliente As Integer?
        Dim _Observacao As String
    End Structure
#End Region

#Region "PRIVATE VARIABLES"
    Private CPJData As StructureClientePJ
    Private CPJData_Backup As StructureClientePJ
#End Region

#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        CPJData = New StructureClientePJ()
        CPJData._IDSituacao = 1
        Situacao = "ATIVO"
    End Sub
    '
    Public Overrides Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            PEndData_Backup = PEndData_Backup
            PJData_Backup = PJData
            CPJData_Backup = CPJData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overrides Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            PJData = PJData_Backup
            CPJData = CPJData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overrides Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa
            PEndData_Backup = New StructurePEndereco
            PJData_Backup = New StructurePJuridica
            CPJData_Backup = New StructureClientePJ
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overrides Function ToString() As String
        Return Cadastro.ToString
    End Function
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    '--- Propriedade PessoaDescricao
    'Public ReadOnly Property PessoaDescricao() As String
    '
    '--- Propriedade IDSituacao
    Public Property IDSituacao() As Byte
        Get
            Return CPJData._IDSituacao
        End Get
        Set(ByVal value As Byte)
            If value <> CPJData._IDSituacao Then
                RaiseAoAlterar()
            End If
            CPJData._IDSituacao = value
        End Set
    End Property
    '
    '--- Propriedade Situacao
    Public Property Situacao() As String
    '
    '--- Propriedade ClienteDesde
    Public Property ClienteDesde() As Date?
        Get
            Return CPJData._ClienteDesde
        End Get
        Set(ByVal value As Date?)
            If value <> CPJData._ClienteDesde Then
                RaiseAoAlterar()
            End If
            CPJData._ClienteDesde = value
        End Set
    End Property
    '
    '--- Propriedade RGAtividade
    Public Property RGAtividade() As Byte
        Get
            Return CPJData._RGAtividade
        End Get
        Set(ByVal value As Byte)
            If value <> CPJData._RGAtividade Then
                RaiseAoAlterar()
            End If
            CPJData._RGAtividade = value
        End Set
    End Property
    '
    '--- Propriedade Atividade
    Public Property Atividade() As String
    '
    '--- Propriedade LimiteCompras
    Public Property LimiteCompras() As Double
        Get
            Return CPJData._LimiteCompras
        End Get
        Set(ByVal value As Double)
            If value <> CPJData._LimiteCompras Then
                RaiseAoAlterar()
            End If
            CPJData._LimiteCompras = value
        End Set
    End Property
    '
    '--- Propriedade UltimaVenda
    Public Property UltimaVenda() As Date?
        Get
            Return CPJData._UltimaVenda
        End Get
        Set(ByVal value As Date?)
            If value <> CPJData._UltimaVenda Then
                RaiseAoAlterar()
            End If
            CPJData._UltimaVenda = value
        End Set
    End Property
    '
    '--- Propriedade RGCliente
    Public Property RGCliente() As Integer?
        Get
            Return CPJData._RGCliente
        End Get
        Set(ByVal value As Integer?)
            If value <> CPJData._RGCliente Then
                RaiseAoAlterar()
            End If
            CPJData._RGCliente = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    Public Property Observacao() As String
        Get
            Return CPJData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> CPJData._Observacao Then
                RaiseAoAlterar()
            End If
            CPJData._Observacao = value
        End Set
    End Property
    '
#End Region
    '
End Class


