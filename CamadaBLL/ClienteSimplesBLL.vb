Imports CamadaDAL
Imports CamadaDTO
'
Public Class ClienteSimplesBLL
	'
	'===================================================================================================
	' OBTER LISTA COMPLETA DE CLIENTES | IDFILIAL | ATIVO
	'===================================================================================================
	Public Function ClienteSimples_GET_List(IDFilial As Integer,
											Optional ClienteNome As String = "",
											Optional Ativo As Boolean? = Nothing) As List(Of clClienteSimples)
		Dim bd As New AcessoDados
		Dim lst As New List(Of clClienteSimples)
		'
		bd.LimparParametros()
		'
		'--- ADD FILIAL
		bd.AdicionarParametros("@IDFilial", IDFilial)
		Dim query As String = "SELECT * FROM qryClienteSimples WHERE IDFilial = @IDFilial "
		'
		'--- ADD ATIVO
		If Not IsNothing(Ativo) Then
			bd.AdicionarParametros("@Ativo", Ativo)
			query += "AND Ativo = @Ativo "
		End If
		'
		'--- ADD NOME CLIENTE
		If ClienteNome.Trim.Length > 0 Then
			bd.AdicionarParametros("@ClienteNome", ClienteNome)
			query += "AND ClienteNome LIKE '%'+@ClienteNome+'%' "
		End If
		'
		'--- ORDER BY
		query += "ORDER BY ClienteNome"
		'
		'--- EXECUTE
		Try
			Dim dt As DataTable = bd.ExecutarConsulta(CommandType.Text, query)
			'
			For Each r As DataRow In dt.Rows
				lst.Add(ConvertRowClass(r))
			Next
			'
			Return lst
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' GET CLIENTE SIMPLES PELO ID
	'==========================================================================================
	Public Function GetClientePeloID(IDClienteSimples As Integer) As clClienteSimples
		'
		Try
			Dim db As New AcessoDados
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDClienteSimples", IDClienteSimples)
			Dim query As String = "SELECT * FROM qryClienteSimples WHERE IDClienteSimples = @IDClienteSimples"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then
				Throw New AppException("Não existe Cliente Simples com o ID informado...")
			Else
				If Not IsNumeric(dt.Rows(0).Item(0)) Then
					Throw New Exception(dt.Rows(0).ToString)
				End If
			End If
			'
			Return ConvertRowClass(dt.Rows(0))
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' GET CLIENTE SIMPLES PELO NOME
	'==========================================================================================
	Public Function GetClientePeloNome(ClienteNome As String) As clClienteSimples
		'
		Try
			Dim db As New AcessoDados
			Dim query As String = ""
			'
			db.LimparParametros()
			db.AdicionarParametros("@ClienteNome", ClienteNome)
			query = "SELECT * FROM qryClienteSimples WHERE ClienteNome = @ClienteNome"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then
				Throw New AppException("Não existe Cliente Simples com o Nome informado...")
			Else
				If Not IsNumeric(dt.Rows(0).Item(0)) Then
					Throw New Exception(dt.Rows(0).ToString)
				End If
			End If
			'
			Return ConvertRowClass(dt.Rows(0))
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' GET CLIENTE SIMPLES PELA CHAVE EXCLUSIVA
	'==========================================================================================
	Public Function GetClientePelaChaveExclusiva(ChaveExclusiva As String) As clClienteSimples
		'
		Try
			Dim db As New AcessoDados
			Dim query As String = ""
			'
			db.LimparParametros()
			db.AdicionarParametros("@ChaveExclusiva", ChaveExclusiva)
			query = "SELECT * FROM qryClienteSimples WHERE ChaveExclusiva = @ChaveExclusiva"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then
				Throw New AppException("Não existe Cliente Simples com a Chave informada...")
			Else
				If Not IsNumeric(dt.Rows(0).Item(0)) Then
					Throw New Exception(dt.Rows(0).ToString)
				End If
			End If
			'
			Return ConvertRowClass(dt.Rows(0))
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' INSERIR NOVO
	'===================================================================================================
	Public Function ClienteSimples_Inserir(ClienteSimples As clClienteSimples,
										   Optional dbTran As Object = Nothing) As Object
		'
		Dim db As AcessoDados = Nothing
		'
		If dbTran Is Nothing Then
			db = New AcessoDados
			db.BeginTransaction()
		Else
			db = dbTran
		End If
		'
		db.LimparParametros()
		'
		'--- ADICIONA OS PARAMENTROS NECESSARIOS
		db.AdicionarParametros("@ClienteNome", ClienteSimples.ClienteNome)
		db.AdicionarParametros("@ChaveExclusiva", ClienteSimples.ChaveExclusiva)
		db.AdicionarParametros("@TelefoneA", If(ClienteSimples.TelefoneA, DBNull.Value))
		db.AdicionarParametros("@TelefoneB", If(ClienteSimples.TelefoneB, DBNull.Value))
		db.AdicionarParametros("@TemWhatsapp", ClienteSimples.TemWhatsapp)
		db.AdicionarParametros("@ClienteEmail", If(ClienteSimples.ClienteEmail, DBNull.Value))
		db.AdicionarParametros("@Ativo", ClienteSimples.Ativo)
		db.AdicionarParametros("@InsercaoData", ClienteSimples.InsercaoData)
		db.AdicionarParametros("@IDFilial", ClienteSimples.IDFilial)
		'
		Dim query As String =
			"INSERT INTO tblClienteSimples " &
			"(ClienteNome, TelefoneA, TelefoneB, TemWhatsapp, ClienteEmail, ChaveExclusiva, InsercaoData, Ativo, IDFilial) " &
			"VALUES (@ClienteNome, @TelefoneA, @TelefoneB, @TemWhatsapp, @ClienteEmail, @ChaveExclusiva, @InsercaoData, @Ativo, @IDFilial)"
		'
		Try
			'
			Dim obj As Object = db.ExecutarInsertGetID(query)
			'
			If Not IsNumeric(obj) Then
				Throw New Exception(obj.ToString)
			End If
			'
			'--- INSERT ENDERECO IF NECESSARY
			If ClienteSimples.Endereco IsNot Nothing AndAlso ClienteSimples.Endereco.Trim.Length > 0 Then
				'
				db.LimparParametros()
				db.AdicionarParametros("@IDClienteSimples", obj)
				db.AdicionarParametros("@Endereco", ClienteSimples.Endereco)
				db.AdicionarParametros("@Bairro", ClienteSimples.Bairro)
				db.AdicionarParametros("@Cidade", ClienteSimples.Cidade)
				db.AdicionarParametros("@UF", ClienteSimples.UF)
				db.AdicionarParametros("@CEP", ClienteSimples.CEP)
				'
				query = "INSERT INTO tblClienteSimplesEndereco " &
						"(IDClienteSimples, Endereco, Bairro, Cidade, UF, CEP) " &
						"VALUES (@IDClienteSimples, @Endereco, @Bairro, @Cidade, @UF, @CEP)"
				'
				db.ExecutarManipulacao(CommandType.Text, query)
				'
			End If
			'
			If dbTran Is Nothing Then db.CommitTransaction()
			Return obj
			'
		Catch ex As SqlClient.SqlException
			'
			If dbTran Is Nothing Then db.RollBackTransaction()
			'
			If ex.Number = 2627 Then
				Return GetClientePelaChaveExclusiva(ClienteSimples.ChaveExclusiva)
			Else
				Throw ex
			End If
			'
		Catch ex As Exception
			If dbTran Is Nothing Then db.RollBackTransaction()
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' ALTERAR REGISTRO
	'===================================================================================================
	Public Function ClienteSimples_Alterar(ClienteSimples As clClienteSimples,
										   Optional dbTran As Object = Nothing) As Object
		'
		Dim db As AcessoDados = Nothing
		'
		If dbTran Is Nothing Then
			db = New AcessoDados
			db.BeginTransaction()
		Else
			db = dbTran
		End If
		'
		db.LimparParametros()
		'
		'--- ADICIONA OS PARAMENTROS NECESSARIOS
		db.AdicionarParametros("@IDClienteSimples", ClienteSimples.IDClienteSimples)
		db.AdicionarParametros("@ClienteNome", ClienteSimples.ClienteNome)
		db.AdicionarParametros("@ChaveExclusiva", ClienteSimples.ChaveExclusiva)
		db.AdicionarParametros("@TelefoneA", If(ClienteSimples.TelefoneA, DBNull.Value))
		db.AdicionarParametros("@TelefoneB", If(ClienteSimples.TelefoneB, DBNull.Value))
		db.AdicionarParametros("@TemWhatsapp", ClienteSimples.TemWhatsapp)
		db.AdicionarParametros("@ClienteEmail", If(ClienteSimples.ClienteEmail, DBNull.Value))
		db.AdicionarParametros("@Ativo", ClienteSimples.Ativo)
		db.AdicionarParametros("@InsercaoData", ClienteSimples.InsercaoData)
		db.AdicionarParametros("@IDFilial", ClienteSimples.IDFilial)
		db.AdicionarParametros("@IDPessoa", If(ClienteSimples.IDPessoa, DBNull.Value))
		'
		Dim query = "UPDATE tblClienteSimples SET " &
					"ClienteNome = @ClienteNome, " &
					"TelefoneA = @TelefoneA, " &
					"TelefoneB = @TelefoneB, " &
					"TemWhatsapp = @TemWhatsapp, " &
					"ClienteEmail = @ClienteEmail, " &
					"ChaveExclusiva	= @ChaveExclusiva, " &
					"IDPessoa = @IDPessoa, " &
					"InsercaoData = @InsercaoData, " &
					"Ativo = @Ativo, " &
					"IDFilial = @IDFilial " &
					"WHERE IDClienteSimples = @IDClienteSimples"
		'
		Try
			'
			db.ExecutarManipulacao(CommandType.Text, query)
			'
			'--- DELETE AND INSERT ENDERECO IF NECESSARY
			db.LimparParametros()
			db.AdicionarParametros("@IDClienteSimples", ClienteSimples.IDClienteSimples)
			'
			query = "DELETE tblClienteSimplesEndereco WHERE IDClienteSimples = @IDClienteSimples"
			db.ExecutarManipulacao(CommandType.Text, query)
			'
			'--- INSERT ENDERECO IF NECESSARY
			If ClienteSimples.Endereco IsNot Nothing AndAlso ClienteSimples.Endereco.Trim.Length > 0 Then
				'
				db.LimparParametros()
				db.AdicionarParametros("@IDClienteSimples", ClienteSimples.IDClienteSimples)
				db.AdicionarParametros("@Endereco", ClienteSimples.Endereco)
				db.AdicionarParametros("@Bairro", ClienteSimples.Bairro)
				db.AdicionarParametros("@Cidade", ClienteSimples.Cidade)
				db.AdicionarParametros("@UF", ClienteSimples.UF)
				db.AdicionarParametros("@CEP", ClienteSimples.CEP)
				'
				query = "INSERT INTO tblClienteSimplesEndereco " &
						"(IDClienteSimples, Endereco, Bairro, Cidade, UF, CEP) " &
						"VALUES (@IDClienteSimples, @Endereco, @Bairro, @Cidade, @UF, @CEP)"
				'
				db.ExecutarManipulacao(CommandType.Text, query)
				'
			End If
			'
			If dbTran Is Nothing Then db.CommitTransaction()
			Return ClienteSimples.IDClienteSimples
			'
		Catch ex As Exception
			If dbTran Is Nothing Then db.RollBackTransaction()
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' CONVERT ROW IN CLASS
	'==========================================================================================
	Private Function ConvertRowClass(r As DataRow) As clClienteSimples
		'
		Dim cliente As New clClienteSimples With {
			.IDClienteSimples = IIf(IsDBNull(r("IDClienteSimples")), Nothing, r("IDClienteSimples")),
			.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial")),
			.ChaveExclusiva = IIf(IsDBNull(r("ChaveExclusiva")), String.Empty, r("ChaveExclusiva")),
			.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial")),
			.ClienteNome = IIf(IsDBNull(r("ClienteNome")), String.Empty, r("ClienteNome")),
			.TelefoneA = IIf(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA")),
			.TelefoneB = IIf(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB")),
			.TemWhatsapp = IIf(IsDBNull(r("TemWhatsapp")), Nothing, r("TemWhatsapp")),
			.ClienteEmail = IIf(IsDBNull(r("ClienteEmail")), String.Empty, r("ClienteEmail")),
			.Endereco = IIf(IsDBNull(r("Endereco")), Nothing, r("Endereco")),
			.Bairro = IIf(IsDBNull(r("Bairro")), Nothing, r("Bairro")),
			.Cidade = IIf(IsDBNull(r("Cidade")), Nothing, r("Cidade")),
			.UF = IIf(IsDBNull(r("UF")), Nothing, r("UF")),
			.CEP = IIf(IsDBNull(r("CEP")), Nothing, r("CEP")),
			.Ativo = IIf(IsDBNull(r("Ativo")), Nothing, r("Ativo")),
			.IDPessoa = IIf(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa")),
			.InsercaoData = IIf(IsDBNull(r("InsercaoData")), Nothing, r("InsercaoData"))
			}
		'
		Return cliente
		'
	End Function
	'
End Class
