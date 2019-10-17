Imports System.ComponentModel
'
'========================================================================
' CLASSE PRIMARIA PESSOA
'========================================================================
Public Class clPessoa
    Structure StructurePessoa
        Dim _IDPessoa As Integer?
        Dim _Cadastro As String
        Dim _PessoaTipo As Byte
        Dim _InsercaoData As Date
    End Structure
    '
    Friend PData As StructurePessoa
    Friend PData_Backup As StructurePessoa
    Friend inTxn As Boolean = False
    '
    Public Event AoAlterar()
    '
    '--- Propriedade Generica
    Public Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
        Set(value As Boolean)
            inTxn = value
        End Set
    End Property
    '
    '--- Propriedade que Aciona o evento AoAlterar
    Public Sub RaiseAoAlterar()
        RaiseEvent AoAlterar()
    End Sub
    '
    '--- Propriedade IDPessoa
    Public Property IDPessoa() As Integer?
        Get
            Return PData._IDPessoa
        End Get
        Set(ByVal value As Integer?)
            If value <> PData._IDPessoa Then
                RaiseEvent AoAlterar()
            End If
            PData._IDPessoa = value
        End Set
    End Property
    '
    '--- Propriedade Cadastro
    Public Property Cadastro() As String
        Get
            Return PData._Cadastro
        End Get
		Set(ByVal value As String)
			'
			'--- check string length
			If value.Length > 100 Then value = value.Substring(0, 100)
			'
			If value <> PData._Cadastro Then
				RaiseEvent AoAlterar()
			End If
			PData._Cadastro = value
		End Set
	End Property
    '
    '--- Propriedade PessoaTipo
    Public Property PessoaTipo() As Byte
        Get
            Return PData._PessoaTipo
        End Get
        Set(ByVal value As Byte)
            If value <> PData._PessoaTipo Then
                RaiseEvent AoAlterar()
            End If
            PData._PessoaTipo = value
        End Set
    End Property
    '
    '--- Propriedade InsercaoData
    Public Property InsercaoData() As Date
        Get
            Return PData._InsercaoData
        End Get
        Set(ByVal value As Date)
            If value <> PData._InsercaoData Then
                RaiseEvent AoAlterar()
            End If
            PData._InsercaoData = value
        End Set
    End Property
    '
End Class
'
'========================================================================
' CLASSE SECUNDARIA PESSOAENDERECO (HERDA PESSOA)
'========================================================================
Public Class clPessoaEndereco
    Inherits clPessoa
    '
    Structure StructurePEndereco
        Dim _Endereco As String
        Dim _Bairro As String
        Dim _Cidade As String
        Dim _UF As String
        Dim _CEP As String
        Dim _Email As String
        Dim _EmailDestino As String
        Dim _EmailPrincipal As Boolean
        Dim _TelefoneA As String
        Dim _TelefoneB As String
    End Structure
    '
    Friend PEndData As StructurePEndereco
    Friend PEndData_Backup As StructurePEndereco
    '
    '--- Propriedade Endereco
    Public Property Endereco() As String
        Get
            Return PEndData._Endereco
        End Get
		Set(ByVal value As String)
			'
			'--- check string length
			If value.Length > 50 Then value = value.Substring(0, 50)
			'
			If value <> PEndData._Endereco Then
				RaiseAoAlterar()
			End If
			PEndData._Endereco = value
		End Set
	End Property
    '
    '--- Propriedade Bairro
    Public Property Bairro() As String
        Get
            Return PEndData._Bairro
        End Get
		Set(ByVal value As String)
			'
			'--- check string length
			If value.Length > 30 Then value = value.Substring(0, 30)
			'
			If value <> PEndData._Bairro Then
				RaiseAoAlterar()
			End If
			PEndData._Bairro = value
		End Set
	End Property
    '
    '--- Propriedade Cidade
    Public Property Cidade() As String
        Get
            Return PEndData._Cidade
        End Get
		Set(ByVal value As String)
			'
			'--- check string length
			If value.Length > 30 Then value = value.Substring(0, 30)
			'
			If value <> PEndData._Cidade Then
				RaiseAoAlterar()
			End If
			PEndData._Cidade = value
		End Set
	End Property
    '
    '--- Propriedade UF
    Public Property UF() As String
        Get
            Return PEndData._UF
        End Get
		Set(ByVal value As String)
			'
			'--- check string length
			If value.Length > 2 Then value = value.Substring(0, 2)
			'
			If value <> PEndData._UF Then
				RaiseAoAlterar()
			End If
			PEndData._UF = value
		End Set
	End Property
    '
    '--- Propriedade CEP
    Public Property CEP() As String
        Get
            Return PEndData._CEP
        End Get
        Set(ByVal value As String)
            If value <> PEndData._CEP Then
                RaiseAoAlterar()
            End If
            PEndData._CEP = value
        End Set
    End Property
    '
    '--- Propriedade Email
    Public Property Email() As String
        Get
            Return PEndData._Email
        End Get
		Set(ByVal value As String)
			'
			'--- check string length
			If value.Length > 100 Then value = value.Substring(0, 100)
			'
			If value <> PEndData._Email Then
				RaiseAoAlterar()
			End If
			PEndData._Email = value
		End Set
	End Property
    '
    '--- Propriedade EmailDestino
    Public Property EmailDestino() As String
        Get
            Return PEndData._EmailDestino
        End Get
        Set(ByVal value As String)
            If value <> PEndData._EmailDestino Then
                RaiseAoAlterar()
            End If
            PEndData._EmailDestino = value
        End Set
    End Property
    '
    '--- Propriedade EmailPrincipal
    Public Property EmailPrincipal() As Boolean
        Get
            Return PEndData._EmailPrincipal
        End Get
        Set(ByVal value As Boolean)
            If value <> PEndData._EmailPrincipal Then
                RaiseAoAlterar()
            End If
            PEndData._EmailPrincipal = value
        End Set
    End Property
    '
    '--- Propriedade TelefoneA
    Public Property TelefoneA() As String
        Get
            Return PEndData._TelefoneA
        End Get
        Set(ByVal value As String)
            If value <> PEndData._TelefoneA Then
                RaiseAoAlterar()
            End If
            PEndData._TelefoneA = value
        End Set
    End Property
    '
    '--- Propriedade TelefoneB
    Public Property TelefoneB() As String
        Get
            Return PEndData._TelefoneB
        End Get
        Set(ByVal value As String)
            If value <> PEndData._TelefoneB Then
                RaiseAoAlterar()
            End If
            PEndData._TelefoneB = value
        End Set
    End Property
    '
End Class
'
'========================================================================
' CLASSE PESSOAFISICA (HERDA PESSOAENDERECO)
'========================================================================
Public Class clPessoaFisica
    Inherits clPessoaEndereco
    Implements IEditableObject
    '
    Structure StructurePFisica
        'Dim _Nome As String
        Dim _CPF As String
        Dim _NascimentoData As Date?
        Dim _Sexo As Boolean?
        Dim _Identidade As String
        Dim _IdentidadeOrgao As String
        Dim _IdentidadeData As Date?
    End Structure
    '
    Friend PFData As StructurePFisica
    Friend PFData_Backup As StructurePFisica
    '
    Sub New()
        PData = New StructurePessoa
        PData._PessoaTipo = 1 '--- 1: PessoaFísica; 2:PessoaJurídica
    End Sub
    '
    Public Overridable Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            '--- reserva os dados para recuperacao futura
            PData_Backup = PData
            PEndData_Backup = PEndData
            PFData_Backup = PFData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overridable Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa()
            PEndData_Backup = New StructurePEndereco()
            PFData_Backup = New StructurePFisica
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overridable Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            PFData = PFData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    ' PROPRIEDADES
    '*********************
    '
    '--- Propriedade CPF
    Public Property CPF() As String
        Get
            Return PFData._CPF
        End Get
        Set(ByVal value As String)
            If value <> PFData._CPF Then
                RaiseAoAlterar()
            End If
            PFData._CPF = value
        End Set
    End Property
    '
    '--- Propriedade NascimentoData
    Public Property NascimentoData() As Date?
        Get
            Return PFData._NascimentoData
        End Get
        Set(ByVal value As Date?)
            If value <> PFData._NascimentoData Then
                RaiseAoAlterar()
            End If
            PFData._NascimentoData = value
        End Set
    End Property
    '
    '--- Propriedade Sexo
    Public Property Sexo() As Boolean?
        Get
            Return PFData._Sexo
        End Get
        Set(ByVal value As Boolean?)
            If value <> PFData._Sexo Then
                RaiseAoAlterar()
            End If
            PFData._Sexo = value
        End Set
    End Property
    '
    '--- Propriedade Identidade
    Public Property Identidade() As String
        Get
            Return PFData._Identidade
        End Get
        Set(ByVal value As String)
            If value <> PFData._Identidade Then
                RaiseAoAlterar()
            End If
            PFData._Identidade = value
        End Set
    End Property
    '
    '--- Propriedade IdentidadeOrgao
    Public Property IdentidadeOrgao() As String
        Get
            Return PFData._IdentidadeOrgao
        End Get
        Set(ByVal value As String)
            If value <> PFData._IdentidadeOrgao Then
                RaiseAoAlterar()
            End If
            PFData._IdentidadeOrgao = value
        End Set
    End Property
    '
    '--- Propriedade IdentidadeData
    Public Property IdentidadeData() As Date?
        Get
            Return PFData._IdentidadeData
        End Get
        Set(ByVal value As Date?)
            If value <> PFData._IdentidadeData Then
                RaiseAoAlterar()
            End If
            PFData._IdentidadeData = value
        End Set
    End Property
    '
End Class
'
'========================================================================
' CLASSE PESSOAJURIDICA (HERDA PESSOAENDERECO)
'========================================================================
Public Class clPessoaJuridica
    Inherits clPessoaEndereco
    Implements IEditableObject
    '
    Structure StructurePJuridica
        'Dim _RazaoSocial As String
        Dim _CNPJ As String
        Dim _InscricaoEstadual As String
        Dim _NomeFantasia As String
        Dim _FundacaoData As Date?
        Dim _ContatoNome As String
    End Structure
    '
    Friend PJData As StructurePJuridica
    Friend PJData_Backup As StructurePJuridica
    '
    Sub New()
        PData = New StructurePessoa
        PData._PessoaTipo = 2 '--- 1: PessoaFísica; 2:PessoaJurídica
    End Sub
    '
    Public Overridable Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            '--- reserva os dados para recuperacao futura
            PData_Backup = PData
            PEndData_Backup = PEndData
            PJData_Backup = PJData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overridable Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            PData_Backup = New StructurePessoa()
            PEndData_Backup = New StructurePEndereco()
            PJData_Backup = New StructurePJuridica
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overridable Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            PData = PData_Backup
            PEndData = PEndData_Backup
            PJData = PJData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    ' PROPRIEDADES
    '*********************
    '
    '--- Propriedade CNPJ
    Public Property CNPJ() As String
        Get
            Return PJData._CNPJ
        End Get
        Set(ByVal value As String)
            If value <> PJData._CNPJ Then
                RaiseAoAlterar()
            End If
            PJData._CNPJ = value
        End Set
    End Property
    '
    '--- Propriedade InscricaoEstadual
    Public Property InscricaoEstadual() As String
        Get
            Return PJData._InscricaoEstadual
        End Get
        Set(ByVal value As String)
            If value <> PJData._InscricaoEstadual Then
                RaiseAoAlterar()
            End If
            PJData._InscricaoEstadual = value
        End Set
    End Property
    '
    '--- Propriedade NomeFantasia
    Public Property NomeFantasia() As String
        Get
            Return PJData._NomeFantasia
        End Get
        Set(ByVal value As String)
            If value <> PJData._NomeFantasia Then
                RaiseAoAlterar()
            End If
            PJData._NomeFantasia = value
        End Set
    End Property
    '
    '--- Propriedade FundacaoData
    Public Property FundacaoData() As Date?
        Get
            Return PJData._FundacaoData
        End Get
        Set(ByVal value As Date?)
            If value <> PJData._FundacaoData Then
                RaiseAoAlterar()
            End If
            PJData._FundacaoData = value
        End Set
    End Property
    '
    '--- Propriedade ContatoNome
    Public Property ContatoNome() As String
        Get
            Return PJData._ContatoNome
        End Get
        Set(ByVal value As String)
            If value <> PJData._ContatoNome Then
                RaiseAoAlterar()
            End If
            PJData._ContatoNome = value
        End Set
    End Property
    '
End Class
'
'========================================================================
' CLASSE PESSOAENVIO
'========================================================================
Public Class clPessoaEnvio
    '
    Sub New()
        EnvioData = Today
        Impresso = False
        Enviado = False
    End Sub
    '
    Property IDPessoaEnvio As Integer
    Property EnvioDescricao As String
    Property EnvioData As Date
    Property Impresso As Boolean
    Property Enviado As Boolean
    '
End Class

Public Class clPessoaEnvioEndereco
    Inherits clPessoaEnvio
    '
    Sub New()
        DataPostagem = Nothing
    End Sub
    '
    Property IDPessoa As Integer
    Property Cadastro As String
    Property Endereco As String
    Property Bairro As String
    Property Cidade As String
    Property UF As String
    Property CEP As String
    Property DataPostagem As Date?
    '
End Class