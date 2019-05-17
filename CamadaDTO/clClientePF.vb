Imports System.ComponentModel

Public Class clClientePF
    Inherits clPessoaFisica
    Implements IEditableObject

#Region "ESTRUTURA DOS DADOS"
    Structure StructureClientePF
        Friend _ClienteDesde As Date
        Friend _Observacao As String
        Friend _IDSituacao As Byte
        Friend _RGAtividade As Byte
        Friend _LimiteCompras As Double
        Friend _UltimaVenda As Date?
        Friend _RGCliente As Integer?
        Friend _Naturalidade As String
        Friend _Pai As String
        Friend _Mae As String
        Friend _TrabalhoContratante As String
        Friend _TrabalhoFuncao As String
        Friend _TrabalhoTelefone As String
        Friend _Renda As Double
        Friend _EstadoCivil As Byte?
        Friend _Conjuge As String
        Friend _ConjugeRenda As Double
        Friend _Igreja As String
        Friend _IgrejaAtuacao As String
        Friend _IgrejaFuncao As String
        Friend _FichaPrint As Boolean
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private CPFData As StructureClientePF
    Private CPFData_Backup As StructureClientePF
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        CPFData = New StructureClientePF()
        With CPFData
            ._ClienteDesde = Date.Now.ToShortDateString
            ._IDSituacao = 1
            Situacao = "ATIVO"
            ._LimiteCompras = 0
            ._Renda = 0
            ._ConjugeRenda = 0
            ._FichaPrint = 1
        End With
        '
    End Sub
    '
    Public Overrides Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            PEndData_Backup = PEndData
            PFData_Backup = PFData
            CPFData_Backup = CPFData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overrides Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            PFData = PFData_Backup
            CPFData = CPFData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overrides Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa
            PEndData_Backup = New StructurePEndereco
            PFData_Backup = New StructurePFisica
            CPFData_Backup = New StructureClientePF()
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
    '--- Propriedade ClienteDesde
    Public Property ClienteDesde() As Date
        Get
            Return CPFData._ClienteDesde
        End Get
        Set(ByVal value As Date)
            If value <> CPFData._ClienteDesde Then
                RaiseAoAlterar()
            End If
            CPFData._ClienteDesde = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    Public Property Observacao() As String
        Get
            Return CPFData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> CPFData._Observacao Then
                RaiseAoAlterar()
            End If
            CPFData._Observacao = value
        End Set
    End Property
    '
    '--- Propriedade IDSituacao
    Public Property IDSituacao() As Byte
        Get
            Return CPFData._IDSituacao
        End Get
        Set(ByVal value As Byte)
            If value <> CPFData._IDSituacao Then
                RaiseAoAlterar()
            End If
            CPFData._IDSituacao = value
        End Set
    End Property
    '
    '--- Propriedade Situacao
    Public Property Situacao() As String
    '
    '--- Propriedade RGAtividade
    Public Property RGAtividade() As Byte
        Get
            Return CPFData._RGAtividade
        End Get
        Set(ByVal value As Byte)
            If value <> CPFData._RGAtividade Then
                RaiseAoAlterar()
            End If
            CPFData._RGAtividade = value
        End Set
    End Property
    '
    '--- Propriedade Atividade
    Public Property Atividade() As String
    '
    '--- Propriedade LimiteCompras
    Public Property LimiteCompras() As Double
        Get
            Return CPFData._LimiteCompras
        End Get
        Set(ByVal value As Double)
            If value <> CPFData._LimiteCompras Then
                RaiseAoAlterar()
            End If
            CPFData._LimiteCompras = value
        End Set
    End Property
    '
    '--- Propriedade UltimaVenda
    Public Property UltimaVenda() As Date?
        Get
            Return CPFData._UltimaVenda
        End Get
        Set(ByVal value As Date?)
            If value <> CPFData._UltimaVenda Then
                RaiseAoAlterar()
            End If
            CPFData._UltimaVenda = value
        End Set
    End Property
    '
    '--- Propriedade RGCliente
    Public Property RGCliente() As Integer?
        Get
            Return CPFData._RGCliente
        End Get
        Set(ByVal value As Integer?)
            If value <> CPFData._RGCliente Then
                RaiseAoAlterar()
            End If
            CPFData._RGCliente = value
        End Set
    End Property
    '
    '
    Property Naturalidade() As String
        Get
            Return CPFData._Naturalidade
        End Get

        Set(value As String)
            If value <> CPFData._Naturalidade Then
                RaiseAoAlterar()
            End If
            CPFData._Naturalidade = value
        End Set
    End Property
    '
    Property Pai() As String
        Get
            Return CPFData._Pai
        End Get
        Set(value As String)
            If value <> CPFData._Pai Then
                RaiseAoAlterar()
            End If
            CPFData._Pai = value
        End Set
    End Property
    '
    Property Mae() As String
        Get
            Return CPFData._Mae
        End Get
        Set(value As String)
            If value <> CPFData._Mae Then
                RaiseAoAlterar()
            End If
            CPFData._Mae = value
        End Set
    End Property
    '
    Property TrabalhoContratante() As String
        Get
            Return CPFData._TrabalhoContratante
        End Get
        Set(value As String)
            If value <> CPFData._TrabalhoContratante Then
                RaiseAoAlterar()
            End If
            CPFData._TrabalhoContratante = value
        End Set
    End Property
    '
    Property TrabalhoFuncao() As String
        Get
            Return CPFData._TrabalhoFuncao
        End Get
        Set(value As String)
            If value <> CPFData._TrabalhoFuncao Then
                RaiseAoAlterar()
            End If
            CPFData._TrabalhoFuncao = value
        End Set
    End Property
    '
    Property TrabalhoTelefone() As String
        Get
            Return CPFData._TrabalhoTelefone
        End Get
        Set(value As String)
            If value <> CPFData._TrabalhoTelefone Then
                RaiseAoAlterar()
            End If
            CPFData._TrabalhoTelefone = value
        End Set
    End Property
    '
    Property Renda() As Double
        Get
            Return CPFData._Renda
        End Get
        Set(value As Double)
            If value <> CPFData._Renda Then
                RaiseAoAlterar()
            End If
            CPFData._Renda = value
        End Set
    End Property
    '
    Property EstadoCivil() As Byte?
        Get
            Return CPFData._EstadoCivil
        End Get
        Set(value As Byte?)
            If value <> CPFData._EstadoCivil Then
                RaiseAoAlterar()
            End If
            CPFData._EstadoCivil = value
        End Set
    End Property
    '
    Property Conjuge() As String
        Get
            Return CPFData._Conjuge
        End Get
        Set(value As String)
            If value <> CPFData._Conjuge Then
                RaiseAoAlterar()
            End If
            CPFData._Conjuge = value
        End Set
    End Property
    '
    Property ConjugeRenda() As Double
        Get
            Return CPFData._ConjugeRenda
        End Get
        Set(value As Double)
            If value <> CPFData._ConjugeRenda Then
                RaiseAoAlterar()
            End If
            CPFData._ConjugeRenda = value
        End Set
    End Property
    '
    Property Igreja() As String
        Get
            Return CPFData._Igreja
        End Get
        Set(value As String)
            If value <> CPFData._Igreja Then
                RaiseAoAlterar()
            End If
            CPFData._Igreja = value
        End Set
    End Property
    '
    Property IgrejaAtuacao() As String
        Get
            Return CPFData._IgrejaAtuacao
        End Get
        Set(value As String)
            If value <> CPFData._IgrejaAtuacao Then
                RaiseAoAlterar()
            End If
            CPFData._IgrejaAtuacao = value
        End Set
    End Property
    '
    Property IgrejaFuncao() As String
        Get
            Return CPFData._IgrejaFuncao
        End Get
        Set(value As String)
            If value <> CPFData._IgrejaFuncao Then
                RaiseAoAlterar()
            End If
            CPFData._IgrejaFuncao = value
        End Set
    End Property
    '
    Property FichaPrint() As Boolean
        Get
            Return CPFData._FichaPrint
        End Get
        Set(value As Boolean)
            If value <> CPFData._FichaPrint Then
                RaiseAoAlterar()
            End If
            CPFData._FichaPrint = value
        End Set
    End Property
    '
#End Region
    '
End Class
