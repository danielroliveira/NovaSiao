Imports System.ComponentModel
Public Class clCadastro
    Implements IEditableObject
#Region "ESTRUTURA DOS DADOS"
    Structure CadastroDados
        Dim _RGCadastro As Long '1
        Dim _CadastroTipo As Byte '2
        Dim _PessoaTipo As Boolean '3
        Dim _CadastroNome As String '4
        Dim _CNP As String '5
        Dim _Endereco As String '6
        Dim _Bairro As String '7
        Dim _Cidade As String '8
        Dim _UF As String '9
        Dim _CEP As String '10
        Dim _TelefoneA As String '11
        Dim _TelefoneB As String '12
        Dim _Email As String '13
        Dim _EntradaData As Date '14
        Dim _Observacoes As String '15
        Dim _Ativo As Byte '16
        Dim _UltimaAlteracao As Date '17
        Dim _acao As Byte 'propriedade de controle
    End Structure
#End Region
#Region "PRIVATE VARIABLES"
    Private CadData As CadastroDados
    Private backupData As CadastroDados
    Private inTxn As Boolean = False
#End Region
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        CadData = New CadastroDados
        With CadData
            ._RGCadastro = Nothing
            ._CadastroTipo = ""
            ._PessoaTipo = ""
            ._CadastroNome = ""
            ._CNP = ""
            ._Endereco = ""
            ._Bairro = ""
            ._Cidade = ""
            ._UF = ""
            ._CEP = ""
            ._TelefoneA = ""
            ._TelefoneB = ""
            ._email = ""
            ._EntradaData = Date.Now
            ._Observacoes = ""
            ._Ativo = 1
            ._UltimaAlteracao = Date.Now
            ._acao = Nothing
        End With
    End Sub
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = CadData
            inTxn = True
        End If
    End Sub
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.CadData = backupData
            inTxn = False
        End If
    End Sub
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New CadastroDados()
            inTxn = False
        End If
    End Sub
    '_EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
#End Region
#Region "PROPRIEDADES"
    Property RGCadastro() As Long '1
        Get
            Return CadData._RGCadastro
        End Get
        Set(ByVal value As Long)
            CadData._RGCadastro = value
        End Set
    End Property
    Property CadastroTipo As Byte
        Get
            Return CadData._CadastroTipo
        End Get
        Set(value As Byte)
            If Not IsNothing(CadData._CadastroTipo) Then
                If value <> CadData._CadastroTipo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._CadastroTipo = value
        End Set
    End Property
    Property PessoaTipo As Boolean
        Get
            Return CadData._PessoaTipo
        End Get
        Set(value As Boolean)
            If Not IsNothing(CadData._PessoaTipo) Then
                If value <> CadData._PessoaTipo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._PessoaTipo = value
        End Set
    End Property
    Property CadastroNome() As String
        Get
            Return CadData._CadastroNome
        End Get
        Set(value As String)
            If Not IsNothing(CadData._CadastroNome) Then
                If value <> CadData._CadastroNome Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._CadastroNome = value
        End Set
    End Property
    Property CNP() As String
        Get
            Return CadData._CNP
        End Get
        Set(value As String)
            If Not IsNothing(CadData._CNP) Then
                If value <> CadData._CNP Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._CNP = value
        End Set
    End Property
    Property Endereco() As String
        Get
            Return CadData._Endereco
        End Get
        Set(value As String)
            If Not IsNothing(CadData._Endereco) Then
                If value <> CadData._Endereco Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._Endereco = value
        End Set
    End Property
    Property Bairro() As String
        Get
            Return CadData._Bairro
        End Get
        Set(value As String)
            If Not IsNothing(CadData._Bairro) Then
                If value <> CadData._Bairro Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._Bairro = value
        End Set
    End Property
    Property Cidade() As String
        Get
            Return CadData._Cidade
        End Get
        Set(value As String)
            If Not IsNothing(CadData._Cidade) Then
                If value <> CadData._Cidade Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._Cidade = value
        End Set
    End Property
    Property UF() As String
        Get
            Return CadData._UF
        End Get
        Set(value As String)
            If Not IsNothing(CadData._UF) Then
                If value <> CadData._UF Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._UF = value
        End Set
    End Property
    Property CEP() As String
        Get
            Return CadData._CEP
        End Get
        Set(value As String)
            If Not IsNothing(CadData._CEP) Then
                If value <> CadData._CEP Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._CEP = value
        End Set
    End Property
    Property TelefoneA() As String
        Get
            Return CadData._TelefoneA
        End Get
        Set(value As String)
            If Not IsNothing(CadData._TelefoneA) Then
                If value <> CadData._TelefoneA Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._TelefoneA = value
        End Set
    End Property
    Property TelefoneB() As String
        Get
            Return CadData._TelefoneB
        End Get
        Set(value As String)
            If Not IsNothing(CadData._TelefoneB) Then
                If value <> CadData._TelefoneB Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._TelefoneB = value
        End Set
    End Property
    Property Email() As String
        Get
            Return CadData._Email
        End Get
        Set(value As String)
            If Not IsNothing(CadData._Email) Then
                If value <> CadData._Email Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._Email = value
        End Set
    End Property
    Property EntradaData() As Date
        Get
            Return CadData._EntradaData
        End Get
        Set(value As Date)
            If Not IsNothing(CadData._EntradaData) Then
                If value <> CadData._EntradaData Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._EntradaData = value
        End Set
    End Property
    Property Observacoes() As String
        Get
            Return CadData._Observacoes
        End Get
        Set(value As String)
            If Not IsNothing(CadData._Observacoes) Then
                If value <> CadData._Observacoes Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._Observacoes = value
        End Set
    End Property
    Property Ativo() As Byte
        Get
            Return CadData._Ativo
        End Get
        Set(value As Byte)
            If Not IsNothing(CadData._Ativo) Then
                If value <> CadData._Ativo Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._Ativo = value
        End Set
    End Property
    Property UltimaAlteracao() As Date
        Get
            Return CadData._UltimaAlteracao
        End Get
        Set(value As Date)
            If Not IsNothing(CadData._UltimaAlteracao) Then
                If value <> CadData._UltimaAlteracao Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CadData._UltimaAlteracao = value
        End Set
    End Property
    Property Acao() As Byte
        Get
            Return CadData._acao
        End Get
        Set(ByVal value As Byte)
            CadData._acao = value
        End Set
    End Property
#End Region
End Class