Imports CamadaDTO
Imports CamadaDAL
'
Public Class FornecedorBLL
	'
	'-----------------------------------------------------------------------------------------------------
	' GET LISTA COMPLETA COM FILTRO OPCIONAL DE ATIVO
	'-----------------------------------------------------------------------------------------------------
	Public Function GetFornecedores(Optional IDFornecedor As Integer? = Nothing,
									Optional Cadastro As String = "",
									Optional Ativo As Boolean? = Nothing) As List(Of clFornecedor)
		'
		Try
			Dim db As New AcessoDados
			Dim query As String = "SELECT * FROM qryFornecedores "
			Dim Connector As String = "WHERE "
			'
			db.LimparParametros()
			'
			'--- Insert IDFornecedor
			If Not IsNothing(IDFornecedor) Then
				db.AdicionarParametros("@IDFornecedor", IDFornecedor)
				query += Connector & "IDFornecedor = @IDFornecedor "
				Connector = "AND "
			End If
			'
			'--- Insert Cadastro
			If Cadastro.Trim.Length > 0 Then
				db.AdicionarParametros("@Cadastro", Cadastro)
				query += Connector & "Cadastro LIKE '%'+@Cadastro+'%' "
				Connector = "AND "
			End If
			'
			'--- Insert Ativo
			If Not IsNothing(Ativo) Then
				db.AdicionarParametros("@Ativo", Ativo)
				query += Connector & "Ativo = @Ativo "
			End If
			'
			'--- ORDER BY
			query += "ORDER BY Cadastro"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			Dim Flist As New List(Of clFornecedor)
			'
			For Each r As DataRow In dt.Rows
				Dim forn As New clFornecedor
				'
				forn.IDPessoa = IIf(IsDBNull(r("IDFornecedor")), Nothing, r("IDFornecedor"))
				forn.Ativo = IIf(IsDBNull(r("Ativo")), 0, r("Ativo"))
				forn.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
				forn.Vendedor = IIf(IsDBNull(r("Vendedor")), String.Empty, r("Vendedor"))
				forn.EmailVendas = IIf(IsDBNull(r("EmailVendas")), String.Empty, r("EmailVendas"))
				'
				forn.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
				forn.NomeFantasia = IIf(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia"))
				forn.Endereco = IIf(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
				forn.Bairro = IIf(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
				forn.Cidade = IIf(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
				forn.UF = IIf(IsDBNull(r("UF")), String.Empty, r("UF"))
				forn.CEP = IIf(IsDBNull(r("CEP")), String.Empty, r("CEP"))
				forn.TelefoneA = IIf(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
				forn.TelefoneB = IIf(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
				forn.Email = IIf(IsDBNull(r("Email")), String.Empty, r("Email"))
				forn.CNPJ = IIf(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
				forn.InscricaoEstadual = IIf(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual"))
				forn.ContatoNome = IIf(IsDBNull(r("ContatoNome")), String.Empty, r("ContatoNome"))
				forn.FundacaoData = IIf(IsDBNull(r("FundacaoData")), Nothing, r("FundacaoData"))
				'
				Flist.Add(forn)
			Next
			'
			Return Flist
			'
		Catch ex As Exception
			Throw ex
		End Try
		'   
	End Function
	'
End Class
