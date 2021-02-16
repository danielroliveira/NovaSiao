Imports CamadaDAL
Imports CamadaDTO
'
Public Class MovimentacaoBLL
	'
	Dim SQL As New SQLControl
	'
#Region "MOVIMENTACAO: ENTRADAS E SAIDAS"
	'
	'===================================================================================================
	' OBTER LISTA DE TODAS MOVIMENTACOES INFORMANDO O TIPO DE ORIGEM E PELO IDORIGEM 
	'===================================================================================================
	Public Function Movimentacao_GET_PorOrigemID(Origem As EnumMovimentacaoOrigem,
												 IDOrigem As Integer) As List(Of clMovimentacao)
		Dim db As New AcessoDados
		'
		'--- limpa os paramentros
		db.LimparParametros()
		'
		'--- adiciona os parametros
		db.AdicionarParametros("@Origem", CByte(Origem)) ' ORIGEM TRANSACAO/VENDA
		db.AdicionarParametros("@IDOrigem", IDOrigem)
		'
		Dim myQuery As String = "SELECT * FROM qryMovimentacao WHERE " &
								"Origem = @Origem AND IDOrigem = @IDOrigem"
		'
		Try
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
			'
			'--- RETURN
			Return Convert_DT_ListOF_Movimentacao(dt)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' OBTER LISTA DE TODAS MOVIMENTACOES (ENTRADA) DE UM ARECEBER
	'===================================================================================================
	Public Function Movimentacao_GET_PorIDAReceber(IDAReceber As Integer) As List(Of clMovimentacao)
		Dim db As New AcessoDados
		'
		'--- limpa os paramentros
		db.LimparParametros()
		'
		'--- adiciona os parametros
		db.AdicionarParametros("@IDAReceber", IDAReceber)
		'
		Dim myQuery As String = "SELECT * FROM qryMovimentacao " &
								"WHERE Origem = 2 AND " &
								"IDOrigem IN " &
								"(SELECT IDAReceberParcela FROM tblAReceberParcela WHERE IDAReceber = @IDAReceber)"
		'
		Try
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
			'
			'--- RETURN
			Return Convert_DT_ListOF_Movimentacao(dt)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' SALVA NOVA ENTRADA/PAGAMENTO NO BD
	'===================================================================================================
	Public Function Movimentacao_Inserir(Movimentacao As clMovimentacao,
										 Optional dbTran As Object = Nothing) As clMovimentacao
		'
		Dim db As AcessoDados = If(dbTran, New AcessoDados)
		'
		'--- limpa os parametros
		db.LimparParametros()
		'
		'--- adiciona o parametros
		db.AdicionarParametros("@Origem", Movimentacao.Origem)
		db.AdicionarParametros("@IDOrigem", Movimentacao.IDOrigem)
		db.AdicionarParametros("@IDConta", Movimentacao.IDConta)
		db.AdicionarParametros("@IDMeio", Movimentacao.IDMeio)
		db.AdicionarParametros("@MovData", Movimentacao.MovData)
		db.AdicionarParametros("@MovValor", Movimentacao.MovValor)
		db.AdicionarParametros("@IDMovForma", If(Movimentacao.IDMovForma, DBNull.Value))
		db.AdicionarParametros("@Creditar", Movimentacao.Creditar)
		db.AdicionarParametros("@Descricao", If(IsNothing(Movimentacao.Descricao) OrElse Movimentacao.Descricao.Length = 0, DBNull.Value, Movimentacao.Descricao))
		db.AdicionarParametros("@Movimento", Movimentacao.Movimento)
		db.AdicionarParametros("@IDCaixa", If(Movimentacao.IDCaixa, DBNull.Value))
		db.AdicionarParametros("@Observacao", Movimentacao.Observacao)
		'
		Try
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspMovimentacao_Inserir")
			'
			If dt.Rows.Count = 0 Then
				Throw New Exception("Não foi retornado registro de movimentação...")
			End If
			'
			Return Convert_DT_ListOF_Movimentacao(dt).Item(0)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' UPDATE MOVIMENTACAO NO BD
	'===================================================================================================
	Public Function Movimentacao_Update(_mov As clMovimentacao,
										Optional myDB As Object = Nothing) As Boolean
		'
		Dim db As AcessoDados = If(myDB, New AcessoDados)
		Dim tranInterna As Boolean = False
		'
		If Not db.isTransaction Then
			db.BeginTransaction()
			tranInterna = True
		End If
		'
		'--- Verifica se a movimentacao tem IDCaixa Vinculado
		Dim myQuery As String = "SELECT IDCaixa FROM tblCaixaMovimentacao WHERE IDMovimentacao = " & _mov.IDMovimentacao
		'
		Try
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
			'
			If Not IsDBNull(dt.Rows(0)(0)) Then
				Throw New Exception("Não é possível atualizar uma movimentação que está vinculada a um caixa...")
			End If
			'
		Catch ex As Exception
			If tranInterna Then db.RollBackTransaction()
			Throw ex
			Return False
		End Try
		'
		'--- executa o UPDATE
		myQuery = "UPDATE tblCaixaMovimentacao SET " &
				  "IDConta = @IDConta, " &
				  "MovData = @MovData, " &
				  "MovValor = @MovValor, " &
				  "IDMovForma = @IDMovForma, " &
				  "IDMeio = @IDMeio, " &
				  "Descricao = @Descricao " &
				  "WHERE IDMovimentacao = @IDMovimentacao"
		'
		'--- limpa os parametros
		db.LimparParametros()
		'
		'--- adiciona o parametros
		db.AdicionarParametros("@IDMovimentacao", _mov.IDMovimentacao)
		db.AdicionarParametros("@IDConta", _mov.IDConta)
		db.AdicionarParametros("@MovData", _mov.MovData)
		db.AdicionarParametros("@MovValor", _mov.MovValor)
		db.AdicionarParametros("@IDMovForma", _mov.IDMovForma)
		db.AdicionarParametros("@IDMeio", _mov.IDMeio)
		db.AdicionarParametros("@Descricao", _mov.Descricao)
		'
		Try
			'
			db.ExecutarManipulacao(CommandType.Text, myQuery)
			'
			'--- DELETE / INSERT OBSERVACAO
			'--------------------------------------------------------
			Dim oBLL As New ObservacaoBLL
			oBLL.SaveObservacao(3, _mov.IDMovimentacao, _mov.Observacao, db)
			'
			'--- COMMIT
			If tranInterna Then db.CommitTransaction()
			'
			'--- RETURN
			Return True
			'
		Catch ex As Exception
			If tranInterna Then db.RollBackTransaction()
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' EXCLUI TODOS OS REGISTROS DE MOVIMENTACAO DA ORIGEM
	'===================================================================================================
	Public Function MovimentacaoDeletePorOrigem(IDOrigem As Integer, Origem As EnumMovimentacaoOrigem,
												Optional dbTran As Object = Nothing) As Boolean
		'
		Dim db As AcessoDados = If(dbTran, New AcessoDados)
		'
		Try
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDOrigem", IDOrigem)
			db.AdicionarParametros("@Origem", Origem)
			'
			Dim query As String = "SELECT * FROM tblCaixaMovimentacao WHERE Origem = @Origem AND IDOrigem = @IDOrigem"
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count > 0 Then
				'
				'--- get list of IDMOVIMENTACAO to Delete OBSERVACAO associated    
				Dim IDMovs As List(Of Integer) = New List(Of Integer)
				'
				'--- CHECK IF EXISTS CAIXA DONE
				'---------------------------------------------------------------------------
				For Each r In dt.Rows
					'
					IDMovs.Add(r("IDMovimentacao")) '--> add to list
					'
					If Not IsDBNull(r("IDCaixa")) Then
						Throw New Exception("Não é possível excluir a Movimentação quando está associada a um caixa.")
					End If
				Next
				'
				'--- DELETE MOVIMENTACAO
				'---------------------------------------------------------------------------
				db.LimparParametros()
				db.AdicionarParametros("@IDOrigem", IDOrigem)
				db.AdicionarParametros("@Origem", Origem)

				query = "DELETE FROM tblCaixaMovimentacao WHERE Origem = @Origem AND IDOrigem = @IDOrigem"
				db.ExecutarManipulacao(CommandType.Text, query)
				'
				'--- DELETE OBSERVACAO ASSOCIATED
				'------------------------------------------------------------------
				Dim oBLL As New ObservacaoBLL
				For Each id In IDMovs
					oBLL.DeleteObservacao(3, id, db)
				Next
				'
			End If
			'
			Return True
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' EXCLUI O REGISTRO DE MOVIMENTACAO PELO CLMOVIMENTACAO
	'===================================================================================================
	Public Function Movimentacao_Excluir(clMov As clMovimentacao,
										 Optional myDB As Object = Nothing) As Boolean
		'
		If Not IsNothing(clMov.IDCaixa) Then
			Throw New Exception("Não é possível excluir movimentacões que foram incluídas no Caixa...")
			Return False
		End If
		' 
		Dim db As AcessoDados = If(myDB, New AcessoDados)
		Dim tranInterna As Boolean = False
		'
		'--- verifica TRANSACAO e INICIA caso nao haja
		If Not db.isTransaction Then
			db.BeginTransaction()
			tranInterna = True
		End If
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDMovimentacao", clMov.IDMovimentacao)
		'
		Dim myQuery As String = "DELETE FROM tblCaixaMovimentacao WHERE IDMovimentacao = @IDMovimentacao"
		'
		Try
			'
			db.ExecutarManipulacao(CommandType.Text, myQuery)
			'
			'--- DELETE OBSERVACAO
			'------------------------------------------------------------------
			Dim oBLL As New ObservacaoBLL
			oBLL.DeleteObservacao(3, clMov.IDMovimentacao, db)
			'
			'--- FINALIZE
			'------------------------------------------------------------------
			If tranInterna Then db.CommitTransaction()
			Return True
			'
		Catch ex As Exception
			If tranInterna Then db.RollBackTransaction()
			Throw ex
			Return False
		End Try
		'
	End Function
	'
	'============================================================================================
	' GET MOVIMENTACOES DE CAIXA PELO ID CAIXA
	'============================================================================================
	Public Function GetMovimentos_IDCaixa(Caixa As clCaixa) As List(Of clMovimentacao)
		'
		Dim db As AcessoDados = Nothing
		'
		Try
			db = New AcessoDados
			'
			db.BeginTransaction()
			Dim query As String = ""
			'
			'
			If Caixa.IDSituacao = 1 Then '-- INICIADA (LIBERADA PARA EDICAO)
				'
				'-- REMOVE MOVS DE ENTRADA ANTERIORES
				'---------------------------------------------------------------------
				db.LimparParametros()
				db.AdicionarParametros("@IDCaixa", Caixa.IDCaixa)
				'
				query = "UPDATE tblCaixaMovimentacao SET IDCaixa = NULL WHERE IDCaixa = @IDCaixa"
				'
				db.ExecutarManipulacao(CommandType.Text, query)
				'
				'-- ADICIONA MOVS DE ENTRADA NOVOS
				'---------------------------------------------------------------------
				db.LimparParametros()
				db.AdicionarParametros("@IDCaixa", Caixa.IDCaixa)
				db.AdicionarParametros("@dtInicial", Caixa.DataInicial)
				db.AdicionarParametros("@dtFinal", Caixa.DataFinal)
				db.AdicionarParametros("@IDConta", Caixa.IDConta)
				'
				query = "UPDATE tblCaixaMovimentacao SET IDCaixa = @IDCaixa WHERE IDConta = @IDConta 
			            AND MovData <= @dtFinal
			            AND MovData >= @dtInicial"
				'
				db.ExecutarManipulacao(CommandType.Text, query)
				'
			End If
			'
			'--- GET MOVIMENTACOES
			'---------------------------------------------------------------------
			db.LimparParametros()
			db.AdicionarParametros("@IDCaixa", Caixa.IDCaixa)
			query = "SELECT * FROM qryMovimentacao WHERE IDCaixa = @IDCaixa ORDER BY MovData"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			'--- SE NAO HA REGISTRO ENTAO RETORNA VAZIO
			If dt.Rows.Count = 0 Then
				Return New List(Of clMovimentacao)
			ElseIf Not IsNumeric(dt.Rows(0).Item(0)) Then
				Throw New Exception(dt.Rows(0).Item(0).ToString)
			End If
			'
			'--- COMMIT CONVERT E RETURN
			db.CommitTransaction()
			Return Convert_DT_ListOF_Movimentacao(dt)
			'
		Catch ex As Exception
			'
			db.RollBackTransaction()
			Throw ex
			'
		End Try
		'
	End Function
	'
	'===================================================================================================
	' CONVERTE DATATABLE EM LIST OF CLMOVIMENTACAO
	'===================================================================================================
	Public Function Convert_DT_ListOF_Movimentacao(myDT As DataTable) As List(Of clMovimentacao)
		'
		'--- CREATE A NEW LIST
		Dim listMov As New List(Of clMovimentacao)
		'
		'--- ADD ROW IN LIST
		If myDT.Rows.Count > 0 Then
			'
			Try
				'
				For Each r As DataRow In myDT.Rows
					'
					'--- CREATE A NEW CLASS
					Dim clM As New clMovimentacao()
					'
					With clM
						.IDMovimentacao = IIf(IsDBNull(r("IDMovimentacao")), Nothing, r("IDMovimentacao"))
						.IDOrigem = IIf(IsDBNull(r("IDOrigem")), Nothing, r("IDOrigem"))
						.Origem = IIf(IsDBNull(r("Origem")), Nothing, r("Origem"))
						.IDConta = IIf(IsDBNull(r("IDConta")), Nothing, r("IDConta"))
						.Conta = IIf(IsDBNull(r("Conta")), String.Empty, r("Conta"))
						.IDMeio = If(IsDBNull(r("IDMeio")), Nothing, r("IDMeio"))
						.Meio = If(IsDBNull(r("Meio")), String.Empty, r("Meio"))
						.IDMovForma = IIf(IsDBNull(r("IDMovForma")), Nothing, r("IDMovForma"))
						.MovForma = IIf(IsDBNull(r("MovForma")), String.Empty, r("MovForma"))
						.IDMovTipo = IIf(IsDBNull(r("IDMovTipo")), Nothing, r("IDMovTipo"))
						.MovTipo = IIf(IsDBNull(r("MovTipo")), String.Empty, r("MovTipo"))
						.IDCartaoTipo = IIf(IsDBNull(r("IDCartaoTipo")), Nothing, r("IDCartaoTipo"))
						.Cartao = IIf(IsDBNull(r("Cartao")), String.Empty, r("Cartao"))
						.MovData = IIf(IsDBNull(r("MovData")), Nothing, r("MovData"))
						.MovValor = IIf(IsDBNull(r("MovValor")), 0, r("MovValor"))
						.Creditar = IIf(IsDBNull(r("Creditar")), Nothing, r("Creditar"))
						.IDCaixa = IIf(IsDBNull(r("IDCaixa")), Nothing, r("IDCaixa"))
						.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
						.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
						.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
						.Movimento = If(IsDBNull(r("Movimento")), Nothing, r("Movimento"))
						.Mov = If(IsDBNull(r("Mov")), Nothing, r("Mov"))
						.Descricao = IIf(IsDBNull(r("Descricao")), String.Empty, r("Descricao"))
						.IDContaPadrao = If(IsDBNull(r("IDContaPadrao")), Nothing, r("IDContaPadrao"))
						.ContaPadrao = If(IsDBNull(r("ContaPadrao")), String.Empty, r("ContaPadrao"))
					End With
					'
					'--- Adiciona o ROW na listagem
					listMov.Add(clM)
					'
				Next
				'
			Catch ex As Exception
				Throw ex
			End Try
			'
		Else
			Return listMov
		End If
		'
		Return listMov
		'
	End Function
	'
#End Region '/ MOVIMENTACAO: ENTRADAS E SAIDAS
	'
#Region "CONTAS: CaixaContas"
	'
	'===================================================================================================
	' RETURN LIST OF CONTAS PELO IDFILIAL
	'===================================================================================================
	Public Function Contas_GET_PorIDFilial(Optional IDFilial As Integer? = Nothing,
										   Optional OnlyContaCaixa As Boolean = False) As List(Of clConta)
		'
		Try
			Dim DT As DataTable = Contas_GET_PorIDFilial_DT(IDFilial, OnlyContaCaixa)
			Return Conta_Convert_Dt_To_List(DT)
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' OBTER DATATABLE DAS CONTAS PELO IDFILIAL
	'===================================================================================================
	Public Function Contas_GET_PorIDFilial_DT(Optional IDFilial As Integer? = Nothing,
											  Optional OnlyContaCaixa As Boolean = False) As DataTable
		Dim db As New AcessoDados
		Dim dtConta As DataTable
		'
		Dim myQuery As String = "SELECT * FROM qryContas"
		'
		db.LimparParametros()
		'
		If Not IsNothing(IDFilial) Then
			'--- adiciona os parametros
			db.AdicionarParametros("@IDFilial", IDFilial)
			myQuery = myQuery & " WHERE IDFilial = @IDFilial"
		End If
		'
		If OnlyContaCaixa Then '--- diferente de ContaTipo Cartao
			If myQuery.Contains("WHERE") Then
				myQuery = myQuery & " AND ContaTipo <> 3"
			Else
				myQuery = myQuery & " WHERE ContaTipo <> 3"
			End If
		End If
		'
		Try
			'--- executa o procedure
			dtConta = db.ExecutarConsulta(CommandType.Text, myQuery)
			Return dtConta
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' RETURN CLCONTA PELO IDCONTA
	'===================================================================================================
	Public Function Conta_GET_PorIDConta(IDConta As Int16) As clConta
		'
		Dim db As New AcessoDados
		Dim dtConta As DataTable
		'
		Dim myQuery As String = "SELECT * FROM qryContas"
		'
		If Not IsNothing(IDConta) Then
			db.LimparParametros()
			'--- adiciona os parametros
			db.AdicionarParametros("@IDConta", IDConta)
			myQuery = myQuery & " WHERE IDConta = @IDConta"
		End If
		'
		Try
			'--- executa o procedure
			dtConta = db.ExecutarConsulta(CommandType.Text, myQuery)
			'
			'--- verifica a quantidade
			If dtConta.Rows.Count > 0 Then
				Return Conta_Convert_Dt_To_List(dtConta).Item(0)
			Else
				Return Nothing
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' CONVERTER CONTA DATATABLE NUMA LIST OF
	'===================================================================================================
	Private Function Conta_Convert_Dt_To_List(dtConta As DataTable) As List(Of clConta)
		'
		Dim list As New List(Of clConta)
		'
		If dtConta.Rows.Count = 0 Then Return list
		'
		For Each r As DataRow In dtConta.Rows
			Dim clC As New clConta
			'
			clC.IDConta = IIf(IsDBNull(r("IDConta")), Nothing, r("IDConta"))
			clC.Conta = IIf(IsDBNull(r("Conta")), String.Empty, r("Conta"))
			clC.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
			clC.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
			clC.CNPJFilial = IIf(IsDBNull(r("CNPJFilial")), String.Empty, r("CNPJFilial"))
			clC.ContaTipo = IIf(IsDBNull(r("ContaTipo")), Nothing, r("ContaTipo"))
			clC.BloqueioData = IIf(IsDBNull(r("BloqueioData")), Nothing, r("BloqueioData"))
			clC.Ativo = IIf(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
			clC.LastIDCaixa = IIf(IsDBNull(r("LastIDCaixa")), Nothing, r("LastIDCaixa"))
			clC.SaldoAtual = IIf(IsDBNull(r("SaldoAtual")), Nothing, r("SaldoAtual"))
			'
			list.Add(clC)
			'
		Next
		'
		Return list
		'
	End Function
	'
	'============================================================================================
	' GET DATA DE BLOQUEIO DA CONTA INFORMADA 
	'============================================================================================
	Public Function Conta_GetDataBloqueio(IDConta As Int16) As Date?
		'
		SQL.ClearParams()
		SQL.AddParam("@IDConta", IDConta)
		'
		Dim strSQL As String = "SELECT BloqueioData FROM tblCaixaContas WHERE IDConta = @IDConta"
		'
		Try
			SQL.ExecQuery(strSQL)
			'
			'--- verifica erro
			If SQL.HasException Then
				Throw New Exception(SQL.Exception)
			End If
			'
			'--- verifica retorno
			If SQL.DBDT.Rows.Count > 0 Then
				'
				Dim r As DataRow = SQL.DBDT.Rows(0)
				Dim dtBloq As Date? = If(IsDBNull(r.Item("BloqueioData")), Nothing, r.Item("BloqueioData"))
				'
				Return dtBloq
				'
			Else
				Throw New Exception("Não foi encontrada nenhuma conta com esse ID...")
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	' INSERT NOVA CONTA 
	'============================================================================================
	Public Function Conta_Insert(myConta As clConta) As Integer
		'
		SQL.ClearParams()
		SQL.AddParam("@Conta", myConta.Conta)
		SQL.AddParam("@ContaTipo", myConta.ContaTipo)
		SQL.AddParam("@IDFilial", myConta.IDFilial)
		'
		Dim strSQL As String = "INSERT INTO tblCaixaContas (Conta, ContaTipo, Ativo, IDFilial, SaldoAtual) " &
							   "VALUES (@Conta, @ContaTipo, 'TRUE', @IDFilial, 0)"
		'
		Try
			SQL.ExecQuery(strSQL, True)
			'
			If SQL.HasException Then
				Throw New Exception(SQL.Exception)
			End If
			'
			'--- return the new ID
			Return SQL.DBDT.Rows(0).Item(0)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	' UPDATE CONTA 
	'============================================================================================
	Public Function Conta_Update(myConta As clConta) As Boolean
		'
		SQL.ClearParams()
		SQL.AddParam("@IDConta", myConta.IDConta)
		SQL.AddParam("@Conta", myConta.Conta)
		SQL.AddParam("@ContaTipo", myConta.ContaTipo)
		SQL.AddParam("@Ativo", myConta.Ativo)
		SQL.AddParam("@IDFilial", myConta.IDFilial)
		SQL.AddParam("@SaldoAtual", 0)
		'
		Dim strSQL As String = "UPDATE tblCaixaContas SET " &
							   "Conta = @Conta, Ativo = @Ativo, ContaTipo = @ContaTipo, " &
							   "IDFilial = @IDFilial, SaldoAtual = @SaldoAtual " &
							   "WHERE IDConta = @IDConta"
		'
		Try
			SQL.ExecQuery(strSQL)
			'
			If SQL.HasException Then
				Throw New Exception(SQL.Exception)
				Return False
			End If
			'
			'--- return
			Return True
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
#End Region '/ CONTAS
	'
#Region "FORMAS DE PAGAMENTO: CaixaMovFormas"
	'
	'===================================================================================================
	' OBTER LISTA DAS FORMAS DE PAGAMENTO
	'===================================================================================================
	Public Function MovForma_GET_DT(IDFilial As Integer,
									Optional Ativo As Boolean? = Nothing) As DataTable
		'
		Dim db As New AcessoDados
		'
		Dim myQuery = "SELECT * FROM qryMovForma WHERE IDFilial = @IDFilial"
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDFilial", IDFilial)
		'
		If Not IsNothing(Ativo) Then
			db.AdicionarParametros("@Ativo", Ativo)
			myQuery = myQuery + " AND Ativo = @Ativo"
		End If
		'
		'
		Try
			'
			Return db.ExecutarConsulta(CommandType.Text, myQuery)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'=========================================================================================
	' OBTER LISTA DAS FORMAS DE MOVIMENTACAO
	'=========================================================================================
	' --- OBTER LISTA
	Public Function MovForma_GET_List(IDFilial As Integer,
									  Optional Ativo As Boolean? = Nothing) As List(Of clMovForma)
		'
		Try
			Dim dt As DataTable = MovForma_GET_DT(IDFilial, Ativo)
			'
			Dim list As New List(Of clMovForma)
			'
			If dt.Rows.Count = 0 Then Return list
			'
			For Each r As DataRow In dt.Rows
				Dim clF As New clMovForma
				'
				clF.IDMovForma = IIf(IsDBNull(r("IDMovForma")), Nothing, r("IDMovForma"))
				clF.MovForma = IIf(IsDBNull(r("MovForma")), String.Empty, r("MovForma"))
				clF.IDMovTipo = IIf(IsDBNull(r("IDMovTipo")), Nothing, r("IDMovTipo"))
				clF.MovTipo = IIf(IsDBNull(r("MovTipo")), String.Empty, r("MovTipo"))
				clF.IDCartao = IIf(IsDBNull(r("IDCartaoTipo")), Nothing, r("IDCartaoTipo"))
				clF.Cartao = IIf(IsDBNull(r("Cartao")), String.Empty, r("Cartao"))
				clF.Parcelas = IIf(IsDBNull(r("Parcelas")), Nothing, r("Parcelas"))
				clF.Comissao = IIf(IsDBNull(r("Comissao")), Nothing, r("Comissao"))
				clF.NoDias = IIf(IsDBNull(r("NoDias")), Nothing, r("NoDias"))
				clF.Ativo = IIf(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
				clF.IDContaPadrao = IIf(IsDBNull(r("IDContaPadrao")), Nothing, r("IDContaPadrao"))
				clF.ContaPadrao = IIf(IsDBNull(r("ContaPadrao")), String.Empty, r("ContaPadrao"))
				clF.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
				clF.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
				clF.IDMeio = IIf(IsDBNull(r("IDMeio")), Nothing, r("IDMeio"))
				'
				list.Add(clF)
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
	'=========================================================================================
	'--- SALVAR REGISTRO
	'=========================================================================================
	Public Function MovForma_Inserir(myMovForma As clMovForma) As Int16?
		'
		Dim mySQL As New SQLControl
		'
		'---adiciona os parâmentros
		mySQL.AddParam("@MovForma", myMovForma.MovForma)
		mySQL.AddParam("@IDMovTipo", myMovForma.IDMovTipo)
		mySQL.AddParam("@IDCartao", IIf(IsNothing(myMovForma.IDCartao), DBNull.Value, myMovForma.IDCartao))
		mySQL.AddParam("@Parcelas", IIf(IsNothing(myMovForma.Parcelas), DBNull.Value, myMovForma.Parcelas))
		mySQL.AddParam("@Comissao", IIf(IsNothing(myMovForma.Comissao), DBNull.Value, myMovForma.Comissao))
		mySQL.AddParam("@NoDias", IIf(IsNothing(myMovForma.NoDias), DBNull.Value, myMovForma.NoDias))
		mySQL.AddParam("@IDFilial", IIf(IsNothing(myMovForma.IDFilial), DBNull.Value, myMovForma.IDFilial))
		mySQL.AddParam("@IDContaPadrao", IIf(IsNothing(myMovForma.IDContaPadrao), DBNull.Value, myMovForma.IDContaPadrao))
		mySQL.AddParam("@Ativo", True)
		'
		Try
			'---salva o NOVO registro
			mySQL.ExecQuery("INSERT INTO tblCaixaMovForma " &
							"(IDMovTipo, MovForma, IDContaPadrao, IDFilial, IDCartaoTipo, Parcelas, Comissao, NoDias, Ativo) " &
							"VALUES (@IDMovTipo, @MovForma, @IDContaPadrao, @IDFilial, @IDCartao, @Parcelas, @Comissao, @NoDias, @Ativo);", True)
			'
			If mySQL.HasException() Then Throw New Exception(mySQL.Exception)
			'
			Dim newID As Int16? = Convert.ToInt16(mySQL.DBDT.Rows(0)("LastID"))
			'
			Return newID
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'=========================================================================================
	'--- ATUALIZAR REGISTRO DE FORMA DE MOVIMENTACAO
	'=========================================================================================
	Public Function MovForma_Update(myMovForma As clMovForma) As Int16?
		'
		Dim mySQL As New SQLControl
		'
		'---adiciona os parâmentros
		mySQL.AddParam("@IDMovForma", myMovForma.IDMovForma)
		mySQL.AddParam("@MovForma", myMovForma.MovForma)
		mySQL.AddParam("@IDMovTipo", myMovForma.IDMovTipo)
		mySQL.AddParam("@IDCartao", IIf(IsNothing(myMovForma.IDCartao), DBNull.Value, myMovForma.IDCartao))
		mySQL.AddParam("@Parcelas", IIf(IsNothing(myMovForma.Parcelas), DBNull.Value, myMovForma.Parcelas))
		mySQL.AddParam("@Comissao", IIf(IsNothing(myMovForma.Comissao), DBNull.Value, myMovForma.Comissao))
		mySQL.AddParam("@NoDias", IIf(IsNothing(myMovForma.NoDias), DBNull.Value, myMovForma.NoDias))
		mySQL.AddParam("@IDFilial", IIf(IsNothing(myMovForma.IDFilial), DBNull.Value, myMovForma.IDFilial))
		mySQL.AddParam("@IDContaPadrao", If(myMovForma.IDContaPadrao, DBNull.Value))
		mySQL.AddParam("@Ativo", True)
		'
		Try
			'---atualiza o registro ALTERADO
			mySQL.ExecQuery("UPDATE tblCaixaMovForma " &
							"SET IDMovTipo=@IDMovTipo, MovForma=@MovForma, IDContaPadrao=@IDContaPadrao, IDFilial=@IDFilial, " &
							"IDCartaoTipo=@IDCartao, Parcelas=@Parcelas, Comissao=@Comissao, NoDias=@NoDias, Ativo=@Ativo " &
							"WHERE IDMovForma=@IDMovForma;")
			'
			If mySQL.HasException() Then Throw New Exception(mySQL.Exception)
			'
			Return myMovForma.IDMovForma
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'*******************************************************************************************************************
	'
#End Region '/ FORMAS DE PAGAMENTO
	'
#Region "TIPOS DE FORMAS DE PAGAMENTO: CaixaMovFormaTipo"
	'
	'=========================================================================================
	' TIPOS DE FORMAS DE MOVIMENTACAO
	'=========================================================================================
	' --- OBTER LISTA
	Public Function MovTipo_GET_Dt(Optional Ativo As Boolean? = Nothing) As DataTable
		Dim SQL As New SQLControl
		Dim myQuery As String = ""

		If IsNothing(Ativo) Then
			myQuery = "SELECT * FROM tblCaixaMovFormaTipo"
		Else
			SQL.AddParam("@Ativo", Ativo)
			myQuery = "SELECT * FROM tblCaixaMovFormaTipo WHERE Ativo = @Ativo"
		End If
		'
		Try
			'
			SQL.ExecQuery(myQuery)
			Dim dtTipo As DataTable = SQL.DBDT
			'
			If SQL.HasException Then
				Throw New Exception(SQL.Exception)
				Exit Function
			End If
			'
			Return dtTipo
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'=========================================================================================
	' --- SALVAR REGISTRO DE TIPO DE MOVIMENTACAO
	'=========================================================================================
	Public Function MovTipo_Inserir(MovTipo As String, IDMeio As Byte) As Byte
		'
		Dim lng As Integer = MovTipo.Trim.Length
		'
		If lng = 0 Then
			Throw New Exception("A descrição do Tipo de Movimentação está vazia...")
		ElseIf lng > 30 Then
			Throw New Exception("A descrição do Tipo de Movimentação não pode ser maior de 30 caracteres")
		End If
		'
		If IDMeio = 0 OrElse IsNothing(IDMeio) Then
			Throw New Exception("O Meio de Pagamento não pode ficar vazio...")
		End If
		'
		SQL.ClearParams()
		SQL.AddParam("@MovTipo", MovTipo)
		SQL.AddParam("@IDMeio", IDMeio)
		'
		Dim strSQL As String = "INSERT INTO tblCaixaMovFormaTipo (MovTipo, IDMeio, Ativo) VALUES (@MovTipo, @IDMeio, 'TRUE')"
		'
		Try
			'
			SQL.ExecQuery(strSQL, True)
			'
			If SQL.HasException Then Throw New Exception(SQL.Exception)
			'
			If SQL.RecordCount > 0 Then
				Dim r As DataRow = SQL.DBDT.Rows(0)
				'
				Return r("LastID")
			Else
				Throw New Exception("Não foi retornado o novo ID...")
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'=========================================================================================
	' --- ATUALIZAR REGISTRO DE TIPO DE MOVIMENTACAO
	'=========================================================================================
	Public Function MovTipo_Update(IDMovTipo As Integer, MovTipo As String, Ativo As Boolean, IDMeio As Byte) As Byte
		'
		SQL.ClearParams()
		SQL.AddParam("@IDMovTipo", IDMovTipo)
		SQL.AddParam("@MovTipo", MovTipo)
		SQL.AddParam("@Ativo", Ativo)
		SQL.AddParam("@IDMeio", IDMeio)
		'
		Dim strSQL As String = "UPDATE tblCaixaMovFormaTipo " &
							   "SET MovTipo = @MovTipo, Ativo = @Ativo, IDMeio = @IDMeio " &
							   "WHERE IDMovTipo = @IDMovTipo"
		'
		Try
			'
			SQL.ExecQuery(strSQL, False)
			'
			If Not SQL.HasException Then
				Return IDMovTipo
			Else
				Throw New Exception(SQL.Exception)
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'--- VERIFICA ATIVIDADE (Se esta sendo utilizado)
	'--- retorna a quantidade de MovForma que se utiliza desse MOVTIPO
	Public Function MovTipo_Atividade(IDMovTipo As Integer) As Integer
		'
		Try
			'
			SQL.ExecQuery("SELECT COUNT(IDMovTipo) AS numReg FROM tblCaixaMovForma WHERE IDMovTipo = " & IDMovTipo)
			'
			If SQL.HasException Then Throw New Exception(SQL.Exception)
			'
			If SQL.RecordCount > 0 Then
				Return SQL.DBDT.Rows(0)("numReg")
			Else
				Return 0
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
#End Region '/ TIPOS DE FORMAS DE PAGAMENTO
	'
#Region "CARTAO TIPOS: CaixaCartaoTipo"
	'
	'=========================================================================================
	' TIPOS DE CARTAO DE CREDITO
	'=========================================================================================
	' --- OBTER LISTA
	Public Function MovCartao_GET_Dt() As DataTable
		Dim SQL As New SQLControl
		'
		Try
			'
			SQL.ExecQuery("SELECT * FROM tblCaixaCartaoTipo")
			Dim dtC As DataTable = SQL.DBDT
			'
			If SQL.HasException Then
				Throw New Exception(SQL.Exception)
				Exit Function
			End If
			'
			Return dtC
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	' --- SALVAR REGISTRO
	Public Function Cartao_Inserir(Cartao As String) As Integer
		'
		Dim lng As Integer = Cartao.Trim.Length
		'
		If lng = 0 Then
			Throw New Exception("A descrição do Tipo de Cartão está vazia...")
		ElseIf lng > 30 Then
			Throw New Exception("A descrição do Tipo de Cartão não pode ser maior de 30 caracteres")
		End If
		'
		Dim SQL As New SQLControl
		Dim strSQL As String = String.Format("INSERT INTO tblCaixaCartaoTipo (Cartao, Ativo) VALUES ('{0}', 'TRUE')", Cartao)
		'
		Try
			'
			SQL.ExecQuery(strSQL, True)
			'
			If SQL.HasException Then Throw New Exception(SQL.Exception)
			'
			If SQL.RecordCount > 0 Then
				Dim r As DataRow = SQL.DBDT.Rows(0)
				'
				Return r("LastID")
			Else
				Throw New Exception("Não foi retornado o novo ID...")
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	' --- ATUALIZAR REGISTRO
	Public Function Cartao_Update(IDCartao As Integer, Cartao As String, Ativo As Boolean) As Integer
		'
		Dim SQL As New SQLControl
		Dim strSQL As String = String.Format("UPDATE tblCaixaCartaoTipo SET Cartao = '{1}', Ativo = '{2}' WHERE IDCartaoTipo = {0}",
											 IDCartao, Cartao, Ativo.ToString)
		'
		Try
			'
			SQL.ExecQuery(strSQL, False)
			'
			If Not SQL.HasException Then
				Return IDCartao
			Else
				Throw New Exception(SQL.Exception)
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'*******************************************************************************************************************
#End Region '/ CARTAO TIPOS
	'
End Class
