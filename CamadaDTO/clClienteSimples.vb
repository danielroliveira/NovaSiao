Imports System.ComponentModel

Public Class clClienteSimples
	Implements IEditableObject
	'
#Region "ESTRUTURA DOS DADOS"
	Structure ClienteDados ' alguns usam FRIEND em vez de DIM
		'
		'--- Dados da tblClienteSimples
		Dim _IDClienteSimples As Integer?
		Dim _ChaveExclusiva As String
		Dim _ClienteNome As String
		Dim _TelefoneA As String
		Dim _TelefoneB As String
		Dim _TemWhatsapp As Boolean
		Dim _ClienteEmail As String
		Dim _InsercaoData As Date?
		Dim _Ativo As Boolean
		Dim _IDPessoa As Integer?
		Dim _Endereco As String
		Dim _Bairro As String
		Dim _Cidade As String
		Dim _UF As String
		Dim _CEP As String
		Dim _IDFilial As Integer?
		'
	End Structure
#End Region
	'
#Region "PRIVATE VARIABLES"
	Private RData As ClienteDados
	Private backupData As ClienteDados
	Private inTxn As Boolean = False
#End Region
	'
#Region "IMPLEMENTS EVENTS"
	'
	Public Sub New()
		RData = New ClienteDados()
		With RData
			._IDClienteSimples = Nothing
			._ChaveExclusiva = ""
			._Ativo = True
			._IDPessoa = Nothing
			._TemWhatsapp = False
			._IDFilial = Nothing
			._InsercaoData = Today.ToShortDateString
			._IDPessoa = Nothing
		End With
	End Sub
	'
	Public Sub BeginEdit() Implements IEditableObject.BeginEdit
		If Not inTxn Then
			Me.backupData = RData
			inTxn = True
		End If
	End Sub
	'
	Public Sub CancelEdit() Implements IEditableObject.CancelEdit
		If inTxn Then
			Me.RData = backupData
			inTxn = False
		End If
	End Sub
	'
	Public Sub EndEdit() Implements IEditableObject.EndEdit
		If inTxn Then
			backupData = New ClienteDados()
			inTxn = False
		End If
	End Sub
	'
	'_EVENTO PUBLIC AOALTERAR
	Public Event AoAlterar()
	'
	Public Overrides Function ToString() As String
		Return ClienteNome.ToString
	End Function
	'
	Public ReadOnly Property RegistroAlterado As Boolean
		Get
			Return inTxn
		End Get
	End Property
	'
#End Region
	'
#Region "PROPRIEDADES"
	'
	'--- Propriedade IDClienteSimples
	Public Property IDClienteSimples() As Integer?
		Get
			Return RData._IDClienteSimples
		End Get
		Set(ByVal value As Integer?)
			If value <> RData._IDClienteSimples Then
				RaiseEvent AoAlterar()
			End If
			RData._IDClienteSimples = value
		End Set
	End Property
	'
	'--- Propriedade ChaveExclusiva
	'------------------------------------------------------
	Public Property ChaveExclusiva() As String
		Get
			Return RData._ChaveExclusiva
		End Get
		Set(ByVal value As String)
			If value <> RData._ChaveExclusiva Then
				RaiseEvent AoAlterar()
			End If
			RData._ChaveExclusiva = value
		End Set
	End Property
	'
	'--- Propriedade ClienteNome
	'------------------------------------------------------
	Public Property ClienteNome() As String
		Get
			Return RData._ClienteNome
		End Get
		Set(ByVal value As String)
			If value <> RData._ClienteNome Then
				RaiseEvent AoAlterar()
			End If
			RData._ClienteNome = value
		End Set
	End Property
	'
	'--- Propriedade TelefoneA
	'------------------------------------------------------
	Public Property TelefoneA() As String
		Get
			Return RData._TelefoneA
		End Get
		Set(ByVal value As String)
			If value <> RData._TelefoneA Then
				RaiseEvent AoAlterar()
			End If
			RData._TelefoneA = value
		End Set
	End Property
	'
	'--- Propriedade TelefoneB
	'------------------------------------------------------
	Public Property TelefoneB() As String
		Get
			Return RData._TelefoneB
		End Get
		Set(ByVal value As String)
			If value <> RData._TelefoneB Then
				RaiseEvent AoAlterar()
			End If
			RData._TelefoneB = value
		End Set
	End Property
	'
	'--- Propriedade TemWhatsapp
	'------------------------------------------------------
	Public Property TemWhatsapp() As Boolean
		Get
			Return RData._TemWhatsapp
		End Get
		Set(ByVal value As Boolean)
			If value <> RData._TemWhatsapp Then
				RaiseEvent AoAlterar()
			End If
			RData._TemWhatsapp = value
		End Set
	End Property
	'
	'--- Propriedade ClienteEmail
	'------------------------------------------------------
	Public Property ClienteEmail() As String
		Get
			Return RData._ClienteEmail
		End Get
		Set(ByVal value As String)
			If value <> RData._ClienteEmail Then
				RaiseEvent AoAlterar()
			End If
			RData._ClienteEmail = value
		End Set
	End Property
	'
	'--- Propriedade InsercaoData
	'------------------------------------------------------
	Public Property InsercaoData() As Date
		Get
			Return RData._InsercaoData
		End Get
		Set(ByVal value As Date)
			If value <> RData._InsercaoData Then
				RaiseEvent AoAlterar()
			End If
			RData._InsercaoData = value
		End Set
	End Property
	'
	'--- Propriedade Ativo
	'------------------------------------------------------
	Public Property Ativo() As Boolean
		Get
			Return RData._Ativo
		End Get
		Set(ByVal value As Boolean)
			If value <> RData._Ativo Then
				RaiseEvent AoAlterar()
			End If
			RData._Ativo = value
		End Set
	End Property
	'
	'--- Propriedade IDPessoa
	'------------------------------------------------------
	Public Property IDPessoa() As Integer?
		Get
			Return RData._IDPessoa
		End Get
		Set(ByVal value As Integer?)
			If value <> RData._IDPessoa Then
				RaiseEvent AoAlterar()
			End If
			RData._IDPessoa = value
		End Set
	End Property
	'
	'--- Propriedade Endereco
	'------------------------------------------------------
	Public Property Endereco() As String
		Get
			Return RData._Endereco
		End Get
		Set(ByVal value As String)
			If value <> RData._Endereco Then
				RaiseEvent AoAlterar()
			End If
			RData._Endereco = value
		End Set
	End Property
	'
	'--- Propriedade Bairro
	'------------------------------------------------------
	Public Property Bairro() As String
		Get
			Return RData._Bairro
		End Get
		Set(ByVal value As String)
			If value <> RData._Bairro Then
				RaiseEvent AoAlterar()
			End If
			RData._Bairro = value
		End Set
	End Property
	'
	'--- Propriedade Cidade
	'------------------------------------------------------
	Public Property Cidade() As String
		Get
			Return RData._Cidade
		End Get
		Set(ByVal value As String)
			If value <> RData._Cidade Then
				RaiseEvent AoAlterar()
			End If
			RData._Cidade = value
		End Set
	End Property
	'
	'--- Propriedade UF
	'------------------------------------------------------
	Public Property UF() As String
		Get
			Return RData._UF
		End Get
		Set(ByVal value As String)
			If value <> RData._UF Then
				RaiseEvent AoAlterar()
			End If
			RData._UF = value
		End Set
	End Property
	'
	'--- Propriedade CEP
	'------------------------------------------------------
	Public Property CEP() As String
		Get
			Return RData._CEP
		End Get
		Set(ByVal value As String)
			If value <> RData._CEP Then
				RaiseEvent AoAlterar()
			End If
			RData._CEP = value
		End Set
	End Property
	'
	'--- Propriedade IDFilial
	'------------------------------------------------------
	Public Property IDFilial() As Integer?
		Get
			Return RData._IDFilial
		End Get
		Set(ByVal value As Integer?)
			If value <> RData._IDFilial Then
				RaiseEvent AoAlterar()
			End If
			RData._IDFilial = value
		End Set
	End Property
	'
	'--- Propriedade ApelidoFilial
	'------------------------------------------------------
	Public Property ApelidoFilial() As String
	'
	'--- Property to Get ChaveExclusiva Cliente
	'------------------------------------------------------
	Public ReadOnly Property GetChaveExclusiva As String
		'
		Get
			'--- SPLIT WORD IN ARRAY OF STRING
			Dim nomes As String() = ClienteNome.Split(" ")
			'
			Dim NovoNome As String = ""
			'
			'--- REMOVE PEQUENAS PALAVRAS LEN < 3 (A,O,DA,DE,E)
			For Each nome In nomes
				If nome.Length >= 3 Then
					NovoNome += nome
				End If
			Next
			'
			Dim vPos As Byte
			'
			'--- REMOVE ACENTOS
			Const vComAcento = "ÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÒÓÔÕÖÙÚÛÜàáâãäåçèéêëìíîïòóôõöùúûü"
			Const vSemAcento = "AAAAAACEEEEIIIIOOOOOUUUUaaaaaaceeeeiiiiooooouuuu"
			'
			For i = 1 To Len(NovoNome)
				vPos = InStr(1, vComAcento, Mid(NovoNome, i, 1))
				If vPos > 0 Then
					Mid(NovoNome, i, 1) = Mid(vSemAcento, vPos, 1)
				End If
			Next
			'
			'--- RETURN NEW WORD UPPER CASE WITHOUT SPACES
			Return NovoNome.ToUpper.Replace(" ", "")
			'
		End Get
		'
	End Property
	'
#End Region
	'
End Class

