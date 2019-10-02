Imports CamadaDAL
Imports CamadaDTO

Public Class ClienteReferenciaBLL
	'
	'==========================================================================================
	' GET REFERENCIAS DO CLIENTE PELO IDPESSOA RETURN DATATABLE
	'==========================================================================================
	Private Function ClienteReferencia_GET_PorID_DT(myID As Integer) As DataTable
		'
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDCliente", myID)
		'
		Dim myQuery As String = "SELECT * FROM tblClienteReferencia WHERE IDCliente = @IDCliente"
		'
		Try
			Return db.ExecutarConsulta(CommandType.Text, myQuery)
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' GET REFERENCIAS DO CLIENTE PELO IDPESSOA
	'==========================================================================================
	Public Function ClienteReferencia_GET_PorID(ID As Integer) As List(Of clClienteReferencia)
		'
		Try
			'
			Dim dt As DataTable = ClienteReferencia_GET_PorID_DT(ID)
			Dim list As New List(Of clClienteReferencia)
			'
			If dt.Rows.Count = 0 Then Return list
			'
			For Each r As DataRow In dt.Rows
				Dim ref As New clClienteReferencia With {
				.IDCliente = r("IDCliente"),
				.ReferenciaNome = r("ReferenciaNome"),
				.ReferenciaTelefone = r("ReferenciaTelefone"),
				.Afinidade = r("Afinidade")
				}
				'
				list.Add(ref)
				'
			Next
			'
			Return list
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' SALVA REFERENCIAS DO CLIENTE
	'==========================================================================================
	Public Function ClienteReferencia_INSERT(myID As Integer, RefList As List(Of clClienteReferencia)) As Boolean
		'
		'--- inicia o acesso
		Dim db As AcessoDados = Nothing
		'
		Try
			'
			'inicia uma transacao
			db = New AcessoDados
			db.BeginTransaction()
			'
			'--- 1. DELETE todas as referencias do Cliente
			'-----------------------------------------------------------------------
			DeleteAllReferenciasByID(myID, db)
			'
			'--- 2. INSERE novamente todas as referencias
			'-----------------------------------------------------------------------
			'--- create Query
			Dim myQuery As String = "INSERT INTO tblClienteReferencia " &
									"(IDCliente, ReferenciaNome, Afinidade, ReferenciaTelefone) " &
									"VALUES " &
									"(@IDCliente, @ReferenciaNome, @Afinidade, @ReferenciaTelefone)"
			'
			'--- verifica se existe algum ROW no tblRefs
			If RefList.Count = 0 Then Return True
			'
			' se houver pelo menos um item
			For Each item As clClienteReferencia In RefList
				'
				'--- Limpa os parametros
				db.LimparParametros()
				'
				' ADICIONA OS PARÂMETROS
				db.AdicionarParametros("@IDCliente", myID)
				db.AdicionarParametros("@ReferenciaNome", item.ReferenciaNome)
				db.AdicionarParametros("@Afinidade", item.Afinidade)
				db.AdicionarParametros("@ReferenciaTelefone", item.ReferenciaTelefone)

				'PARA UM REGISTRO NOVO - INSERT
				db.ExecutarManipulacao(CommandType.Text, myQuery)
				'
			Next
			'
			'--- Commit Transaction
			db.CommitTransaction()
			Return True
			'
		Catch ex As Exception
			db.RollBackTransaction()
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' DELETE ALL REFERENCIA BY ID CLIENTE
	'==========================================================================================
	Private Sub DeleteAllReferenciasByID(IDCliente As Integer, Optional dbTran As AcessoDados = Nothing)
		'
		Try
			Dim db As AcessoDados = If(dbTran, New AcessoDados)
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDCliente", IDCliente)
			'
			Dim myQuery As String = "DELETE tblClienteReferencia WHERE IDCliente = @IDCliente"
			'
			db.ExecutarManipulacao(CommandType.Text, myQuery)
		Catch ex As Exception
			Throw ex
        End Try
        '
    End Sub
    '
End Class
