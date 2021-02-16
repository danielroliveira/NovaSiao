Imports CamadaDAL
Imports CamadaDTO
'
Public Class CaixaBLL
	'
	'============================================================================================
	' INSERT NOVO CAIXA E RETORNA UM CLCAIXA
	'============================================================================================
	Public Function InserirNovo_Caixa(ByVal myCaixa As clCaixa) As clCaixa
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDConta", myCaixa.IDConta)
		db.AdicionarParametros("@IDFilial", myCaixa.IDFilial)
		db.AdicionarParametros("@FechamentoData", myCaixa.FechamentoData)
		db.AdicionarParametros("@IDSituacao", myCaixa.IDSituacao)
		db.AdicionarParametros("@DataInicial", myCaixa.DataInicial)
		db.AdicionarParametros("@DataFinal", myCaixa.DataFinal)
		db.AdicionarParametros("@SaldoFinal", myCaixa.SaldoFinal)
		db.AdicionarParametros("@SaldoAnterior", myCaixa.SaldoAnterior)
		db.AdicionarParametros("@Observacao", myCaixa.Observacao)
		db.AdicionarParametros("@CaixaFinalDia", myCaixa.CaixaFinalDia)
		db.AdicionarParametros("@IDFuncionario", If(myCaixa.IDFuncionario, DBNull.Value))
		'
		Try
			Dim dt As DataTable
			'
			dt = db.ExecutarConsulta(CommandType.StoredProcedure, "uspCaixa_Inserir")
			'
			If dt.Rows.Count > 0 Then
				'
				Dim r As DataRow = dt(0)
				Return Convert_DtRow_clCaixa(r)
				'
			Else
				Throw New Exception("Operação de salvamento não retornou nenhum dado...")
			End If
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	'  CONVERT DT ROW EM CLCAIXA
	'============================================================================================
	Private Function Convert_DtRow_clCaixa(r As DataRow) As clCaixa
		'
		Dim clC As New clCaixa
		'
		Try
			'
			clC.IDCaixa = IIf(IsDBNull(r("IDCaixa")), Nothing, r("IDCaixa"))
			clC.IDConta = IIf(IsDBNull(r("IDConta")), Nothing, r("IDConta"))
			clC.Conta = IIf(IsDBNull(r("Conta")), String.Empty, r("Conta"))
			clC.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
			clC.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
			clC.FechamentoData = IIf(IsDBNull(r("FechamentoData")), Nothing, r("FechamentoData"))
			clC.IDSituacao = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
			clC.Situacao = IIf(IsDBNull(r("Situacao")), String.Empty, r("Situacao"))
			clC.DataInicial = IIf(IsDBNull(r("DataInicial")), Nothing, r("DataInicial"))
			clC.DataFinal = IIf(IsDBNull(r("DataFinal")), Nothing, r("DataFinal"))
			clC.SaldoFinal = IIf(IsDBNull(r("SaldoFinal")), Nothing, r("SaldoFinal"))
			clC.SaldoAnterior = IIf(IsDBNull(r("SaldoAnterior")), Nothing, r("SaldoAnterior"))
			clC.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
			clC.CaixaFinalDia = IIf(IsDBNull(r("CaixaFinalDia")), Nothing, r("CaixaFinalDia"))
			clC.IDFuncionario = IIf(IsDBNull(r("IDFuncionario")), Nothing, r("IDFuncionario"))
			clC.ApelidoFuncionario = IIf(IsDBNull(r("ApelidoFuncionario")), String.Empty, r("ApelidoFuncionario"))
			'
			Return clC
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	'  GET CAIXA PELO ID
	'============================================================================================
	Public Function GetCaixa_PeloID(myIDCaixa As Integer) As clCaixa
		'
		Dim SQL As New SQLControl
		Dim str As String = "SELECT * FROM qryCaixa WHERE IDCaixa = " & myIDCaixa
		'
		Try
			SQL.ExecQuery(str)
			'
			If SQL.HasException Then
				Throw New Exception(SQL.Exception)
			End If
			'
			Dim dt As DataTable = SQL.DBDT
			'
			If dt.Rows.Count > 0 Then
				'
				Dim r As DataRow = dt(0)
				Return Convert_DtRow_clCaixa(r)
				'
			Else
				Throw New Exception("Não foi encontrado nenhum registro...")
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	' GET PRIMEIRA E ULTIMA DATAS DOS MOVIMENTOS DE ENTRADA E SAIDA PELO IDCONTA
	'============================================================================================
	Public Function GetLastDados_IDConta(myIDConta As Byte) As DataTable
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		'
		db.AdicionarParametros("@IDConta", myIDConta)
		'
		Try
			Return db.ExecutarConsulta(CommandType.StoredProcedure, "uspCaixa_GetLastDados_IDConta")
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	' GET SALDO DAS CONTAS DO CAIXA ANTERIOR PELO IDCAIXA
	'============================================================================================
	Public Function GetSaldo_ContaTipos_IDCaixa(myIDCaixa As Integer) As DataTable
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDCaixa", myIDCaixa)
		'
		Try
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspCaixa_GetSaldoContaTipos")
			Return dt
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	' INSERE NIVELAMENTO NO CAIXA E RETORNA UMA NOVA MOVIMENTACAO DE CAIXA
	'============================================================================================
	Public Function InserirNivelamento(IDCaixa As Integer, IDMeio As Int16, myValor As Decimal) As clMovimentacao
		'
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDCaixa", IDCaixa)
		db.AdicionarParametros("@IDMeio", IDMeio)
		db.AdicionarParametros("@Valor", myValor)
		'
		Try
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspCaixa_InserirNivelamento")
			'
			If dt.Rows.Count = 0 Then
				Throw New Exception("ERRO: Não foi adicionado nivelamento...")
			End If
			'
			Dim mBLL As New MovimentacaoBLL
			'
			Return mBLL.Convert_DT_ListOF_Movimentacao(dt)(0)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	' EXCLUIR TODOS NIVELAMENTOS NO CAIXA
	'============================================================================================
	Public Function ExcluirNivelamentos(Movs As List(Of clMovimentacao)) As Boolean
		'
		Dim db As New AcessoDados
		db.BeginTransaction()
		'
		Dim query As String = ""
		'
		Try
			'
			For Each mov As clMovimentacao In Movs.Where(Function(x) x.Origem = 3)
				'
				db.LimparParametros()
				db.AdicionarParametros("@IDCredito", mov.IDOrigem)
				'
				'-- EXCLUI O REGISTRO DE CREDITO
				query = "DELETE tblCaixaCreditos " &
						"OUTPUT deleted.IDCredito " &
						"WHERE IDCredito = @IDCredito AND IDCreditoTipo = 1"
				'
				Dim resp As DataTable = db.ExecutarConsulta(CommandType.Text, query)
				'
				If resp.Rows.Count > 0 Then
					'
					db.LimparParametros()
					db.AdicionarParametros("@IDMov", mov.IDMovimentacao)
					'
					query = "DELETE tblCaixaMovimentacao WHERE IDMovimentacao = @IDMov"
					'
					db.ExecutarManipulacao(CommandType.Text, query)
					'
				End If
				'
			Next
			'
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
	'============================================================================================
	' ALTERA O PEÍRODO DA DATA FINAL DO CAIXA PELO ID CAIXA
	'============================================================================================
	Public Sub Caixa_AlteraPeriodo(IDCaixa As Integer, dtFinal As Date)
		'
		Dim SQL As New SQLControl
		SQL.AddParam("@dtFinal", dtFinal)
		SQL.AddParam("@IDCaixa", IDCaixa)
		'
		Dim str As String = "UPDATE tblCaixa SET DataFinal = @dtFinal WHERE IDCaixa = @IDCaixa"
		'
		Try
			SQL.ExecQuery(str)
			'
			If SQL.HasException Then
				Throw New Exception(SQL.Exception)
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Sub
	'
	'============================================================================================
	' GET LISTAGEM DE CAIXAS PARA PROCURA
	'============================================================================================
	Public Function GetCaixaLista_Procura(myIDConta As Int16,
										  Optional dtInicial As Date? = Nothing,
										  Optional dtFinal As Date? = Nothing) As List(Of clCaixa)
		'
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		'
		db.AdicionarParametros("@IDConta", myIDConta)
		Dim myQuery As String = "SELECT * FROM qryCaixa WHERE IDConta = @IDConta"
		'
		If Not IsNothing(dtInicial) Then
			'
			db.AdicionarParametros("@DataInicial", dtInicial)
			myQuery = myQuery & " AND DataInicial >= @DataInicial"
			'
		End If
		'
		If Not IsNothing(dtFinal) Then
			'
			db.AdicionarParametros("@DataFinal", dtFinal)
			myQuery = myQuery & " AND DataFinal <= @DataFinal"
			'
		End If
		'
		Try
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
			Dim cxList As New List(Of clCaixa)
			'
			If dt.Rows.Count = 0 Then Return cxList
			'
			For Each r In dt.Rows
				'
				cxList.Add(Convert_DtRow_clCaixa(r))
				'
			Next
			'
			Return cxList
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'============================================================================================
	' FINALIZA O CAIXA
	'============================================================================================
	Public Function CaixaFinalizar(_caixa As clCaixa, lstMovs As List(Of clMovimentacao), dbTran As Object) As Integer
		'
		Dim db As AcessoDados = dbTran
		Dim query As String = ""
		'
		Try
			'--- GET IDCAIXA ANTERIOR
			db.LimparParametros()
			db.AdicionarParametros("@IDCaixa", _caixa.IDCaixa)
			db.AdicionarParametros("@IDConta", _caixa.IDConta)

			query = "SELECT TOP 1 IDCaixa, SaldoFinal " &
				"FROM tblCaixa WHERE IDConta = @IDConta " &
				"AND IDCaixa != @IDCaixa " &
				"ORDER BY IDCaixa DESC"

			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			Dim SaldoAnterior As Decimal = 0
			Dim IDCaixaAnterior As Integer? = Nothing

			If dt.Rows.Count > 0 Then
				IDCaixaAnterior = dt.Rows(0).Item(0)
				SaldoAnterior = dt.Rows(0).Item(1)
			End If

			'---  GET SALDO ANTERIOR FROM TBLCAIXASALDO
			Dim dicSaldoAnterior As Dictionary(Of Integer, Decimal) = New Dictionary(Of Integer, Decimal)

			If Not IsNothing(IDCaixaAnterior) Then
				db.LimparParametros()
				db.AdicionarParametros("@IDCaixaAnterior", IDCaixaAnterior)

				query = "SELECT IDMeio, SaldoFinal FROM tblCaixaSaldo WHERE IDCaixa = @IDCaixaAnterior"
				dt = db.ExecutarConsulta(CommandType.Text, query)

				For Each row As DataRow In dt.Rows
					dicSaldoAnterior.Add(row.Item(0), row.Item(1))
				Next

			End If

			'--- DELETE TODOS OS SALDOS DO CAIXA ATUAL
			db.LimparParametros()
			db.AdicionarParametros("@IDCaixa", _caixa.IDCaixa)

			query = "DELETE FROM tblCaixaSaldo WHERE IDCaixa = @IDCaixa"

			db.ExecutarManipulacao(CommandType.Text, query)

			'--- INSERT INPUT INICIAL TBLCAIXASALDO FROM CAIXA ANTERIOR
			Dim group = lstMovs.GroupBy(Function(m) m.IDMeio).
				Select(Function(g) New clMovimentacao With {
					.IDMeio = g.Key,
					.MovValor = g.Sum(Function(m) m.MovValor)
				})

			query = "INSERT INTO tblCaixaSaldo " &
				"(IDCaixa, IDMeio, IDConta, SaldoFinal) " &
				"VALUES " &
				"(@IDCaixa, @IDMeio, @IDConta, @SaldoItem)"

			For Each item As clMovimentacao In group

				Dim itemSdAnt As Decimal = item.MovValor

				If dicSaldoAnterior.ContainsKey(item.IDMeio) Then
					itemSdAnt += dicSaldoAnterior.Item(item.IDMeio)
				End If

				db.LimparParametros()
				db.AdicionarParametros("@IDCaixa", _caixa.IDCaixa)
				db.AdicionarParametros("@IDMeio", item.IDMeio)
				db.AdicionarParametros("@IDConta", _caixa.IDConta)
				db.AdicionarParametros("@SaldoItem", itemSdAnt)

				db.ExecutarManipulacao(CommandType.Text, query)

			Next

			'--================================================================
			'-- SALVA E BLOQUEIA O tblCaixa
			'--================================================================
			Dim FechamentoData As Date = Today

			'--- get saldo final
			Dim SaldoFinal = lstMovs.Sum(Function(x) x.MovValor)
			_caixa.SaldoFinal = SaldoFinal

			db.LimparParametros()
			db.AdicionarParametros("@FechamentoData", FechamentoData)
			db.AdicionarParametros("@SaldoAnterior", SaldoAnterior)
			db.AdicionarParametros("@SaldoFinal", _caixa.SaldoFinal)
			db.AdicionarParametros("@CaixaFinalDia", _caixa.CaixaFinalDia)
			db.AdicionarParametros("@IDFuncionario", If(_caixa.IDFuncionario, DBNull.Value))
			db.AdicionarParametros("@IDCaixa", _caixa.IDCaixa)


			query = "UPDATE tblCaixa SET " &
					"IDSituacao = 2 " &
					", FechamentoData = @FechamentoData " &
					", SaldoAnterior = @SaldoAnterior " &
					", SaldoFinal = @SaldoFinal " &
					", CaixaFinalDia = @CaixaFinalDia " &
					", IDFuncionario = @IDFuncionario " &
					"WHERE IDCaixa = @IDCaixa "

			db.ExecutarManipulacao(CommandType.Text, query)

			'-- SALVA A OBSERVACAO
			query = "DELETE tblObservacao WHERE IDOrigem = @IDCaixa AND Origem = 5"

			If _caixa.Observacao.Trim.Length > 0 Then

				db.AdicionarParametros("@IDCaixa", _caixa.IDCaixa)
				db.AdicionarParametros("@Observacao", _caixa.Observacao)

				query = "INSERT INTO tblObservacao " &
						"(IDOrigem, Origem, Observacao) " &
						"VALUES " &
						"(@IDCaixa, 5, @Observacao)"

				db.ExecutarManipulacao(CommandType.Text, query)

			End If

			'--================================================================
			'-- BLOQUEIA A CONTA
			'--================================================================

			'-- VERIFY BLOQUEIODATA WITH @CAIXAFINALDIA
			Dim bloqueioData As Date = _caixa.DataFinal
			If _caixa.CaixaFinalDia = True Then bloqueioData.AddDays(1)

			db.LimparParametros()
			db.AdicionarParametros("@BloqueioData", bloqueioData)
			db.AdicionarParametros("@SaldoAtual", _caixa.SaldoFinal)
			db.AdicionarParametros("@LastIDCaixa", _caixa.IDCaixa)
			db.AdicionarParametros("@IDConta", _caixa.IDConta)

			query = "UPDATE tblCaixaContas " &
				"SET BloqueioData = @BloqueioData, " &
				"SaldoAtual = @SaldoAtual, " &
				"LastIDCaixa = @LastIDCaixa " &
				"WHERE IDConta = @IDConta"

			db.ExecutarManipulacao(CommandType.Text, query)
			'
			Return _caixa.IDCaixa
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' RETURN TOTAL OF MOVIMENTACOES FROM CAIXA
	'==========================================================================================
	Public Function CountMovsCaixa(caixa As clCaixa) As Integer
		'
		Dim db As New AcessoDados
		'
		'--- add params
		db.LimparParametros()
		db.AdicionarParametros("@IDConta", caixa.IDConta)
		db.AdicionarParametros("@dtFinal", caixa.DataFinal)
		db.AdicionarParametros("@dtInicial", caixa.DataInicial)
		'
		Dim myQuery As String = "SELECT COUNT (*) AS Total FROM tblCaixaMovimentacao " &
								"WHERE IDConta = @IDConta AND MovData <= @dtFinal AND MovData >= @dtInicial"
		'
		Try
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
			'
			If dt.Rows.Count = 0 Then
				Throw New Exception("Não foram encontrados registros de contagem...")
			End If
			'
			Dim ret As Object = dt.Rows(0)(0)
			'
			If IsNumeric(ret) Then
				Return ret
			Else
				Throw New Exception(ret.ToString)
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' TRANSFERE AS MOVS PARA SUA CONTA PADRAO ANTES DE FINALIZAR
	'==========================================================================================
	Public Sub CaixaFinalizar_TransfereMovs(ByRef MovsTransf As List(Of clMovimentacao),
											IDCaixa As Integer,
											dbTran As Object)
		'
		Dim db As AcessoDados = dbTran
		'
		'--- verifica se existe movimentacoes
		If MovsTransf.Count = 0 Then Return
		'
		Try
			Dim transfBLL As New TransferenciaCaixaBLL
			'
			'--- verifica se a conta de credito ja esta bloqueada na data
			Dim myRetMessage As String = ""
			'
			If Not VerificaBloqueioContaTransf(MovsTransf, myRetMessage) Then
				Throw New Exception(myRetMessage)
			End If
			'
			'--- create a new list of clMovimentacao to ADD inserted trasfered movs
			Dim lstSaidaMovs As List(Of clMovimentacao) = New List(Of clMovimentacao)
			'
			For Each mov As clMovimentacao In MovsTransf
				'
				'--- IF not exist ContaPadrao then next
				If IsNothing(mov.IDContaPadrao) Then Continue For
				'
				' add new transferencia
				'----------------------------------------------------------------------------
				Dim transf As New clTransferenciaCaixa With {
					.ComissaoValor = 0,
					.IDContaDebito = mov.IDConta,
					.ContaDebito = mov.Conta,
					.IDContaCredito = mov.IDContaPadrao,
					.ContaCredito = mov.ContaPadrao,
					.IDCaixa = IDCaixa,
					.IDFilial = mov.IDFilial,
					.IDMeio = mov.IDMeio,
					.TransferenciaData = mov.MovData,
					.TransferenciaValor = mov.MovValor
				}
				'
				transfBLL.InserirNova_Transferencia(transf, db)
				'
				'--- create MOV TRANSFERENCIA DE SAIDA TO add list
				Dim movSaida As New clMovimentacao(EnumMovimentacaoOrigem.Transferencia, EnumMovimento.Transferencia)
				'
				movSaida.IDConta = transf.IDContaDebito
				movSaida.Creditar = False
				movSaida.Descricao = "Débito de Transferencia para Conta: " & transf.ContaCredito
				movSaida.IDFilial = transf.IDFilial
				movSaida.IDMeio = transf.IDMeio
				movSaida.MovData = transf.TransferenciaData
				movSaida.Movimento = 4 '--- transferencia de Saida (TS)
				movSaida.MovValor = transf.TransferenciaValor
				movSaida.IDOrigem = transf.IDTransferencia '--- IDTranferencia
				movSaida.Origem = 11 '--- tblCaixaTransferencia
				movSaida.IDCaixa = transf.IDCaixa '--> somente insere a saida no caixa

				lstSaidaMovs.Add(movSaida)

			Next
			'
			MovsTransf.AddRange(lstSaidaMovs)
			'
		Catch ex As Exception
			'
			Throw ex
			'
		End Try
		'
	End Sub
	'
	'================================================================================================
	' VERIFICA BLOQUEIO DAS CONTAS DE TRANSFERENCIA PADRAO ANTES DE FINALIZAR OU DESBLOQUEAR CAIXA
	'================================================================================================
	Public Function VerificaBloqueioContaTransf(MovsTransf As List(Of clMovimentacao),
												 Optional ByRef myRetMessage As String = "") As Boolean
		'
		Dim VerifyIDConta As Integer?
		'
		For Each mov As clMovimentacao In MovsTransf
			'
			'--- IF not exist ContaPadrao then next
			If IsNothing(mov.IDContaPadrao) Then Continue For
			'
			'--- verifica se a conta de credito ja nao esta bloqueada na data
			Dim VerifyBloq As Boolean = False
			'
			If IsNothing(VerifyIDConta) Then '--- PRIMEIRA CONTA
				VerifyIDConta = mov.IDContaPadrao
				VerifyBloq = True
			Else '--- CONTA ALTERADA
				If VerifyIDConta <> mov.IDContaPadrao Then
					VerifyBloq = True
				End If
			End If
			'
			'--- REALIZA A VERIFICACAO
			If VerifyBloq = True Then
				Dim mBLL As New MovimentacaoBLL
				Dim bloqData As Date?
				'
				Try
					bloqData = mBLL.Conta_GetDataBloqueio(mov.IDContaPadrao)
					'
					If Not IsNothing(bloqData) AndAlso bloqData > mov.MovData Then
						'--- retorna a mensagem
						myRetMessage = String.Format("A conta de transferência {0} está bloqueada na data: {1}",
													 mov.ContaPadrao, mov.MovData.ToShortDateString)
						Return False
						Exit For
					End If
					'
				Catch ex As Exception
					Throw ex
				End Try
				'
			End If
			'
		Next
		'
		Return True
		'
	End Function
	'
	'==========================================================================================
	' BLOQ ALL TRANSACOES CONNECTED OF THE CAIXA AFTER FINALIZATE
	'==========================================================================================
	Public Function CaixaFinalizar_BloqueiaTransacoes(MovsTransf As List(Of clMovimentacao),
													  dbTran As Object) As Boolean
		'
		Dim db As AcessoDados = dbTran
		'
		'--- verifica se existe movimentacoes
		If MovsTransf.Count = 0 Then Return True
		'
		For Each mov As clMovimentacao In MovsTransf
			'
			Select Case mov.Origem
				'
				Case 1 '--- TRANSACAO (BLOQUEIA VENDA)
					'
					Dim tBLL As New TransacaoBLL
					Try
						tBLL.BloqueiaSituacaoTransacao(mov.IDOrigem, dbTran)
					Catch ex As Exception
						Throw ex
					End Try
					'
				Case 2 '--- ARECEBERPARCELA (BLOQUEIA VENDA)
					'
					' Get o ID da venda que esta associada a parcela
					db.LimparParametros()
					db.AdicionarParametros("@IDParcela", mov.IDOrigem)
					'
					Dim myQuery As String = "SELECT Origem, IDOrigem FROM tblAReceber WHERE IDAReceber IN " &
											"(SELECT IDAReceber FROM tblAReceberParcela WHERE IDAReceberParcela = @IDParcela)"
					'
					Try
						Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
						'
						If dt.Rows.Count = 0 Then
							Continue For
						End If
						'
						If dt.Rows(0)("Origem") = 1 Then '--- origem VENDA => 1
							Dim IDVenda As Integer = dt.Rows(0)("IDOrigem")
							'
							Dim tBLL As New TransacaoBLL
							tBLL.BloqueiaSituacaoTransacao(IDVenda, dbTran)
							'
						End If
						'
					Catch ex As Exception
						Throw ex
					End Try
					'
				Case 4 '--- DEVOLUCAO SAIDA (BLOQUEIA DEVOLUCAO)
					'
					Dim tBLL As New TransacaoBLL
					Try
						tBLL.BloqueiaSituacaoTransacao(mov.IDOrigem, dbTran)
					Catch ex As Exception
						Throw ex
					End Try
					'
				Case 10 '--- APAGAR (BLOQUEIA COMPRA ou TRANSACAO LIGADA AO FRETE)
					'
					' Get o ID da ORIGEM do APagar
					db.LimparParametros()
					db.AdicionarParametros("@IDAPagar", mov.IDOrigem)
					'
					Dim myQuery As String = "SELECT Origem, IDOrigem FROM tblAPagar WHERE IDAPagar = @IDAPagar"
					'
					Try
						Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
						'
						If dt.Rows.Count = 0 Then
							Continue For
						End If
						'
						Dim IDTransacao As Integer = dt.Rows(0)("IDOrigem")
						Dim tBLL As New TransacaoBLL
						'
						'--- 1:origem COMPRA | 5:origem FRETE
						If dt.Rows(0)("Origem") = 1 OrElse dt.Rows(0)("Origem") = 5 Then
							tBLL.BloqueiaSituacaoTransacao(IDTransacao, dbTran)
						End If
						'
					Catch ex As Exception
						Throw ex
					End Try
					'
			End Select
			'
		Next
		'
		Return True
		'
	End Function
	'
	'============================================================================================
	' DESBLOQUEAR CAIXA E CONTA PELO ID CAIXA
	'============================================================================================
	Public Sub DesbloquearCaixa(IDCaixa As Integer)
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDCaixa", IDCaixa)
		'
		Try
			Dim ID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspCaixa_Desbloquear")
			'
			If Not IsNumeric(ID) Then
				Throw New Exception(ID.ToString)
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Sub
	'
	'============================================================================================
	' EXCLUIR CAIXA PELO ID CAIXA
	'============================================================================================
	Public Sub ExcluirCaixa(IDCaixa As Integer)
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDCaixa", IDCaixa)
		'
		Try
			Dim ID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspCaixa_Excluir")
			'
			If Not ID = True Then
				Throw New Exception(ID.ToString)
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Sub
	'
	'============================================================================================
	' SALVA CAIXA
	'============================================================================================
	Public Function UpdateCaixa(_caixa As clCaixa) As Boolean
		'
		Dim db As New AcessoDados
		'
		'--- inicia uma TRANSACTION 
		db.BeginTransaction()
		'
		Try
			'
			'--- SALVA a observacao
			'-------------------------------------------------------------------------------
			Dim obs As New ObservacaoBLL
			'
			If Not obs.SaveObservacao(5, _caixa.IDCaixa, _caixa.Observacao, db) Then
				Throw New Exception("Não foi possível salvar a observação do caixa...")
			End If
			'
			'--- SALVA o caixa
			'-------------------------------------------------------------------------------
			db.LimparParametros()
			db.AdicionarParametros("@IDCaixa", _caixa.IDCaixa)
			db.AdicionarParametros("@IDSituacao", _caixa.IDSituacao)
			db.AdicionarParametros("@DataInicial", _caixa.DataInicial)
			db.AdicionarParametros("@DataFinal", _caixa.DataFinal)
			db.AdicionarParametros("@SaldoFinal", _caixa.SaldoFinal)
			db.AdicionarParametros("@SaldoAnterior", _caixa.SaldoAnterior)
			db.AdicionarParametros("@Observacao", _caixa.Observacao)
			db.AdicionarParametros("@CaixaFinalDia", _caixa.CaixaFinalDia)
			db.AdicionarParametros("@IDFuncionario", If(_caixa.IDFuncionario, DBNull.Value))
			'
			Dim myQuery As String = "UPDATE tblCaixa SET " &
									"IDSituacao = @IDSituacao, DataInicial = @DataInicial, DataFinal = @DataFinal, " &
									"SaldoFinal = @SaldoFinal, SaldoAnterior = @SaldoAnterior, " &
									"CaixaFinalDia = @CaixaFinalDia, IDFuncionario = @IDFuncionario " &
									"WHERE IDCaixa = @IDCaixa"
			'
			db.ExecutarManipulacao(CommandType.Text, myQuery)
			'
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
	' INSERIR ENTRADA SIMPLES DE CAIXA
	'==========================================================================================
	Public Function InserirEntradaSimplesCaixa(IDCaixa As Integer,
											   EntradaValor As Double,
											   Descricao As String) As clMovimentacao
		Dim db As New AcessoDados
		'
		db.LimparParametros()
		db.AdicionarParametros("@IDCaixa", IDCaixa)
		db.AdicionarParametros("@Valor", EntradaValor)
		db.AdicionarParametros("@Descricao", Descricao)
		'
		Try
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspCaixa_InserirEntradaSimples")
			'
			If dt.Rows.Count = 0 Then
				Throw New Exception("ERRO: Não foi adicionada ENTRADA...")
			End If
			'
			Dim mBLL As New MovimentacaoBLL
			'
			Return mBLL.Convert_DT_ListOF_Movimentacao(dt)(0)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' EXCLUIR ENTRADA SIMPLES DE CAIXA
	'==========================================================================================
	Public Function ExcluirEntradaSimplesCaixa(mov As clMovimentacao) As Boolean
		'
		Dim db As New AcessoDados
		db.BeginTransaction()
		'
		Dim query As String = ""
		'
		Try
			'
			If mov.Origem <> 3 Then
				Return False
			End If
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDCredito", mov.IDOrigem)
			'
			'-- EXCLUI O REGISTRO DE CREDITO
			query = "DELETE tblCaixaCreditos " &
					"OUTPUT deleted.IDCredito " &
					"WHERE IDCredito = @IDCredito AND IDCreditoTipo = 3" '--> CreditoTipo: ENTRADA
			'
			Dim resp As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If resp.Rows.Count > 0 Then
				'
				db.LimparParametros()
				db.AdicionarParametros("@IDMov", mov.IDMovimentacao)
				'
				query = "DELETE tblCaixaMovimentacao WHERE IDMovimentacao = @IDMov"
				'
				db.ExecutarManipulacao(CommandType.Text, query)
				'
			End If
			'
			'
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
End Class
