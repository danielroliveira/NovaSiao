Imports System.ComponentModel

Public Class clFilial
    Inherits clPessoa

#Region "ESTRUTURA DOS DADOS"
    Structure StructureFilial ' alguns usam FRIEND em vez de DIM
        Dim _ApelidoFilial As String
        Dim _CNPJ As String
        Dim _AliquotaICMS As Double
        Dim _Ativo As Boolean
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Friend FilialData As StructureFilial
    Friend FilialData_Backup As StructureFilial
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
        PData._PessoaTipo = 3 '---> Pessoa Filial
        '
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
            If If(PData._Cadastro, "") <> If(FilialData._ApelidoFilial, "") Then
                PData._Cadastro = FilialData._ApelidoFilial
            End If
            '
            Return FilialData._ApelidoFilial
            '
        End Get
        Set(ByVal value As String)
            If value <> FilialData._ApelidoFilial Then
                RaiseAoAlterar()
            End If
            PData._Cadastro = value
            FilialData._ApelidoFilial = value
        End Set
    End Property
    '
    '--- Propriedade CNPJ
    '------------------------------------------------------
    Public Property CNPJ() As String
        Get
            Return FilialData._CNPJ
        End Get
        Set(ByVal value As String)
            If value <> FilialData._CNPJ Then
                RaiseAoAlterar()
            End If
            FilialData._CNPJ = value
        End Set
    End Property
    '
    '--- Propriedade AliquotaICMS
    '------------------------------------------------------
    Public Property AliquotaICMS() As Double
        Get
            Return FilialData._AliquotaICMS
        End Get
        Set(ByVal value As Double)
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
'
'
'==========================================================================================
' FILIAL DADOS CLASS
'==========================================================================================
Public Class clFilialDados
    Inherits clFilial
    Implements IEditableObject

#Region "ESTRUTURA DOS DADOS"
    Structure StructureFilialDados ' alguns usam FRIEND em vez de DIM
        '
        Dim _InscricaoEstadual As String
        Dim _NomeFantasia As String
        Dim _Endereco As String
        Dim _Bairro As String
        Dim _Cidade As String
        Dim _UF As String
        Dim _CEP As String
        Dim _TelefonePrincipal As String
        Dim _TelefoneGerencia As String
        Dim _TelefoneFinanceiro As String
        Dim _ContatoGerencia As String
        Dim _ContatoFinanceiro As String
        Dim _NumeroWhatsapp As String
        Dim _Email As String
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private FilialDadosData As StructureFilialDados
    Private FilialDadosData_Backup As StructureFilialDados
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        '
        FilialDadosData = New StructureFilialDados()
        PData._PessoaTipo = 3 '---> Pessoa Filial
        '
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            PData_Backup = PData
            FilialData_Backup = FilialData
            FilialDadosData_Backup = FilialDadosData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            FilialData = FilialData_Backup
            FilialDadosData = FilialDadosData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa()
            FilialData_Backup = New StructureFilial()
            FilialDadosData_Backup = New StructureFilialDados()
            RegistroAlterado = False
        End If
    End Sub
    '
#End Region '/ IMPLEMENTS EVENTS
    '
#Region "PROPERTIES"
    '
    '--- Propriedade InscricaoEstadual
    '------------------------------------------------------
    Public Property InscricaoEstadual() As String
        Get
            Return FilialDadosData._InscricaoEstadual
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._InscricaoEstadual Then
                RaiseAoAlterar()
            End If
            FilialDadosData._InscricaoEstadual = value
        End Set
    End Property
    '
    '--- Propriedade NomeFantasia
    '------------------------------------------------------
    Public Property NomeFantasia() As String
        Get
            Return FilialDadosData._NomeFantasia
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._NomeFantasia Then
                RaiseAoAlterar()
            End If
            FilialDadosData._NomeFantasia = value
        End Set
    End Property
    '
    '--- Propriedade Endereco
    Public Property Endereco() As String
        Get
            Return FilialDadosData._Endereco
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._Endereco Then
                RaiseAoAlterar()
            End If
            FilialDadosData._Endereco = value
        End Set
    End Property
    '
    '--- Propriedade Bairro
    Public Property Bairro() As String
        Get
            Return FilialDadosData._Bairro
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._Bairro Then
                RaiseAoAlterar()
            End If
            FilialDadosData._Bairro = value
        End Set
    End Property
    '
    '--- Propriedade Cidade
    Public Property Cidade() As String
        Get
            Return FilialDadosData._Cidade
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._Cidade Then
                RaiseAoAlterar()
            End If
            FilialDadosData._Cidade = value
        End Set
    End Property
    '
    '--- Propriedade UF
    Public Property UF() As String
        Get
            Return FilialDadosData._UF
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._UF Then
                RaiseAoAlterar()
            End If
            FilialDadosData._UF = value
        End Set
    End Property
    '
    '--- Propriedade CEP
    Public Property CEP() As String
        Get
            Return FilialDadosData._CEP
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._CEP Then
                RaiseAoAlterar()
            End If
            FilialDadosData._CEP = value
        End Set
    End Property
    '
    '--- Propriedade Email
    Public Property Email() As String
        Get
            Return FilialDadosData._Email
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._Email Then
                RaiseAoAlterar()
            End If
            FilialDadosData._Email = value
        End Set
    End Property
    '
    '--- Propriedade TelefonePrincipal
    '------------------------------------------------------
    Public Property TelefonePrincipal() As String
        Get
            Return FilialDadosData._TelefonePrincipal
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._TelefonePrincipal Then
                RaiseAoAlterar()
            End If
            FilialDadosData._TelefonePrincipal = value
        End Set
    End Property
    '
    '--- Propriedade TelefoneGerencia
    '------------------------------------------------------
    Public Property TelefoneGerencia() As String
        Get
            Return FilialDadosData._TelefoneGerencia
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._TelefoneGerencia Then
                RaiseAoAlterar()
            End If
            FilialDadosData._TelefoneGerencia = value
        End Set
    End Property
    '
    '--- Propriedade TelefoneFinanceiro
    '------------------------------------------------------
    Public Property TelefoneFinanceiro() As String
        Get
            Return FilialDadosData._TelefoneFinanceiro
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._TelefoneFinanceiro Then
                RaiseAoAlterar()
            End If
            FilialDadosData._TelefoneFinanceiro = value
        End Set
    End Property
    '
    '--- Propriedade ContatoGerencia
    '------------------------------------------------------
    Public Property ContatoGerencia() As String
        Get
            Return FilialDadosData._ContatoGerencia
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._ContatoGerencia Then
                RaiseAoAlterar()
            End If
            FilialDadosData._ContatoGerencia = value
        End Set
    End Property
    '
    '--- Propriedade ContatoFinanceiro
    '------------------------------------------------------
    Public Property ContatoFinanceiro() As String
        Get
            Return FilialDadosData._ContatoFinanceiro
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._ContatoFinanceiro Then
                RaiseAoAlterar()
            End If
            FilialDadosData._ContatoFinanceiro = value
        End Set
    End Property
    '
    '--- Propriedade NumeroWhatsapp
    '------------------------------------------------------
    Public Property NumeroWhatsapp() As String
        Get
            Return FilialDadosData._NumeroWhatsapp
        End Get
        Set(ByVal value As String)
            If value <> FilialDadosData._NumeroWhatsapp Then
                RaiseAoAlterar()
            End If
            FilialDadosData._NumeroWhatsapp = value
        End Set
    End Property
    '
#End Region '/ PROPERTIES
    '
End Class