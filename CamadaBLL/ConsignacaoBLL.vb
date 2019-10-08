﻿Imports CamadaDTO
Imports CamadaDAL
'
Public Class ConsignacaoBLL
	'
	'==========================================================================================
	' INSERT CONSIGNACAO ENTRADA
	'==========================================================================================
	Public Function InsertConsignacaoEntrada(consig As clConsignacao,
											 Optional dbTran As Object = Nothing) As clConsignacao
		'
		Try
			'
			Dim dtCompra As DataTable
			'
			dtCompra = InsertConsignacaoEntrada_DT(consig, dbTran)
			'
			If dtCompra.Rows.Count > 0 Then
				Dim r As DataRow = dtCompra(0)
				'
				Return ConvertDtRow_clConsignacao(r)
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
	Private Function InsertConsignacaoEntrada_DT(consig As clConsignacao,
												 Optional dbTran As Object = Nothing) As DataTable
		'
		Dim db As AcessoDados
		'
		If IsNothing(dbTran) Then
			db = New AcessoDados
			db.BeginTransaction()
		Else
			db = dbTran
		End If
		'
		Try
			'
			'-- INSERIR NA TBLTRANSACAO
			'-- ===================================================
			'Adiciona os Parâmetros
			db.LimparParametros()
			'
			'-- PARAMETROS DA TBLTRANSACAO
			db.AdicionarParametros("@IDPessoaDestino", consig.IDPessoaDestino)
			db.AdicionarParametros("@IDPessoaOrigem", consig.IDPessoaOrigem)
			db.AdicionarParametros("@IDOperacao", consig.IDOperacao)
			db.AdicionarParametros("@IDSituacao", consig.IDSituacao)
			db.AdicionarParametros("@IDUser", consig.IDUser)
			db.AdicionarParametros("@CFOP", consig.CFOP)
			db.AdicionarParametros("@TransacaoData", consig.TransacaoData)
			'
			Dim query As String = "INSERT INTO tblTransacao " &
								  "(IDPessoaDestino, IDPessoaOrigem, IDOperacao, IDSituacao, IDUser, CFOP, TransacaoData) " &
								  "VALUES " &
								  "(@IDPessoaDestino, @IDPessoaOrigem, @IDOperacao, @IDSituacao, @IDUser, @CFOP, @TransacaoData)"
			'
			Dim newID As Object = db.ExecutarInsertGetID(query)
			'
			If Not IsNumeric(newID) Then
				Throw New Exception("Um erro inesperado ocorreu no salvar Consignação..." & vbNewLine & newID.ToString)
			End If
			'
			'-- INSERIR NA TBLCONSIGNACAO
			'-- ===================================================
			db.LimparParametros()
			db.AdicionarParametros("@IDTransacao", newID)
			'
			query = "INSERT INTO tblConsignacaoEntrada " &
					"(IDConsignacao, FreteCobrado, ICMSValor, Despesas, Descontos, TotalConsignacao) " &
					"VALUES " &
					"(@IDTransacao, 0, 0, 0, 0, 0)"
			'
			db.ExecutarManipulacao(CommandType.Text, query)
			'
			'-- INSERIR NA tblFrete (caso necessidade)
			'--======================================================================
			If Not IsNothing(consig.IDTransportadora) AndAlso consig.IDTransportadora > 0 Then
				'
				db.LimparParametros()
				db.AdicionarParametros("@IDTransacao", newID)
				db.AdicionarParametros("@IDTransportadora", consig.IDTransportadora)
				db.AdicionarParametros("@FreteTipo", consig.FreteTipo)
				db.AdicionarParametros("@Volumes", consig.Volumes)
				db.AdicionarParametros("@FreteValor", If(consig.FreteValor, 0))
				'
				query = "INSERT INTO tblFrete " &
						"(IDTransacao, IDTransportadora, FreteTipo, Volumes, FreteValor) " &
						"VALUES " &
						"(@IDTransacao, @IDTransportadora, @FreteTipo, @Volumes, @FreteValor)"
				'
				db.ExecutarManipulacao(CommandType.Text, query)
				'
			End If
			'
			'-- COMMIT
			'-- ===================================================
			If IsNothing(dbTran) Then '--- TRANSACTION LOCAL
				db.CommitTransaction()
			End If
			'
			'-- RETURN
			'-- ===================================================
			db.LimparParametros()
			db.AdicionarParametros("@IDConsignacao", newID)
			'
			query = "SELECT * FROM qryConsignacao WHERE IDConsignacao = @IDConsignacao "
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then Throw New Exception("Não houve retorno da Entrada, ou não foi inserida a entrada...")
			'
			If IsNumeric(dt.Rows(0).Item(0)) Then
				Return dt
			Else
				Throw New Exception("Uma exceção ocorreu ao inserir nova entrada." & vbNewLine & dt.Rows(0).Item(0))
			End If
			'
		Catch ex As Exception
			'
			If IsNothing(dbTran) Then '--- TRANSACTION LOCAL
				db.RollBackTransaction()
			End If
			'
			Throw ex
			'
		End Try
		'
	End Function
	'
	'==========================================================================================
	' UPDATE CONSIGNACAO ENTRADA
	'==========================================================================================
	Public Function UpdateConsignacaoEntrada(consig As clConsignacao) As Integer
		'
		Dim dbTran As AcessoDados = Nothing
		Dim query As String = ""
		'
		Try
			'
			'--- BEGIN TRANSACTION
			'----------------------------------------------------------------------------------
			dbTran = New AcessoDados
			dbTran.BeginTransaction()
			'
			'--- UPDATE TBLTRANSACAO
			'----------------------------------------------------------------------------------
			dbTran.LimparParametros()
			dbTran.AdicionarParametros("@IDConsignacao", consig.IDConsignacao)
			dbTran.AdicionarParametros("@IDPessoaDestino", consig.IDPessoaDestino)
			dbTran.AdicionarParametros("@IDPessoaOrigem", consig.IDPessoaOrigem)
			dbTran.AdicionarParametros("@IDSituacao", consig.IDSituacao)
			dbTran.AdicionarParametros("@IDUser", consig.IDUser)
			dbTran.AdicionarParametros("@TransacaoData", consig.TransacaoData)
			'
			query = "UPDATE tblTransacao SET " &
					"IDPessoaDestino= @IDPessoaDestino " &
					",IDPessoaOrigem = @IDPessoaOrigem " &
					",IDSituacao = @IDSituacao " &
					",IDUser = @IDUser " &
					",TransacaoData = @TransacaoData " &
					"WHERE IDTransacao = @IDConsignacao"
			'
			dbTran.ExecutarManipulacao(CommandType.Text, query)
			'
			'--- UPDATE TBLCONSIGNACAO
			'----------------------------------------------------------------------------------
			dbTran.LimparParametros()
			dbTran.AdicionarParametros("@IDConsignacao", consig.IDConsignacao)
			dbTran.AdicionarParametros("@FreteCobrado", consig.FreteCobrado)
			dbTran.AdicionarParametros("@ICMSValor", consig.ICMSValor)
			dbTran.AdicionarParametros("@Despesas", consig.Despesas)
			dbTran.AdicionarParametros("@Descontos", consig.Descontos)
			dbTran.AdicionarParametros("@TotalConsignacao", consig.TotalConsignacao)
			'
			query = "UPDATE tblConsignacao SET " &
					"FreteCobrado = @FreteCobrado " &
					",ICMSValor = @ICMSValor " &
					",Despesas = @Despesas " &
					",Descontos = @Descontos " &
					",TotalConsignacao = @TotalConsignacao " &
					"WHERE IDConsignacao = @IDConsignacao"
			'
			dbTran.ExecutarManipulacao(CommandType.Text, query)
			'
			'--- DELETE | UPDATE TBLFRETE
			'----------------------------------------------------------------------------------
			dbTran.LimparParametros()
			dbTran.AdicionarParametros("@IDConsignacao", consig.IDConsignacao)
			'
			query = "DELETE tblFrete WHERE IDTransacao = @IDConsignacao"
			'
			If Not IsNothing(consig.IDTransportadora) AndAlso consig.IDTransportadora > 0 Then
				'
				dbTran.LimparParametros()
				dbTran.AdicionarParametros("@IDTransacao", consig.IDConsignacao)
				dbTran.AdicionarParametros("@IDTransportadora", consig.IDTransportadora)
				dbTran.AdicionarParametros("@FreteTipo", consig.FreteTipo)
				dbTran.AdicionarParametros("@Volumes", consig.Volumes)
				dbTran.AdicionarParametros("@FreteValor", If(consig.FreteValor, 0))
				'
				query = "INSERT INTO tblFrete " &
						"(IDTransacao, IDTransportadora, FreteTipo, Volumes, FreteValor) " &
						"VALUES " &
						"(@IDTransacao, @IDTransportadora, @FreteTipo, @Volumes, @FreteValor)"
				'
				dbTran.ExecutarManipulacao(CommandType.Text, query)
				'
			End If
			'
			'--- UPDATE TBLOBSERVACAO
			'----------------------------------------------------------------------------------
			Dim oBLL As New ObservacaoBLL
			'
			oBLL.SaveObservacao(1, consig.IDConsignacao, consig.Observacao, dbTran)
			'
			'--- COMMIT TRANSACTION AND RETURN
			'----------------------------------------------------------------------------------
			dbTran.CommitTransaction()
			Return consig.IDConsignacao
			'
		Catch ex As Exception
			'
			dbTran.RollBackTransaction()
			Throw ex
			'
		End Try
		'
	End Function
	'
	'--------------------------------------------------------------------------------------------
	' CONVERT DATAROW DA DATATABLE COMPRA EM CLCONSIGNACAO
	'--------------------------------------------------------------------------------------------
	Private Function ConvertDtRow_clConsignacao(r As DataRow) As clConsignacao
		'
		Dim cmp As clConsignacao = New clConsignacao
		'
		'--- TBLTRANSACAO
		cmp.IDConsignacao = IIf(IsDBNull(r("IDConsignacao")), Nothing, r("IDConsignacao"))
		cmp.IDPessoaDestino = IIf(IsDBNull(r("IDPessoaDestino")), Nothing, r("IDPessoaDestino"))
		cmp.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
		cmp.CNP = IIf(IsDBNull(r("CNP")), String.Empty, r("CNP"))
		cmp.UF = IIf(IsDBNull(r("UF")), String.Empty, r("UF"))
		cmp.Cidade = IIf(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
		cmp.IDPessoaOrigem = IIf(IsDBNull(r("IDPessoaOrigem")), Nothing, r("IDPessoaOrigem"))
		cmp.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
		cmp.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao"))
		cmp.IDSituacao = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
		cmp.Situacao = IIf(IsDBNull(r("Situacao")), String.Empty, r("Situacao"))
		cmp.IDUser = IIf(IsDBNull(r("IDUser")), Nothing, r("IDUser"))
		cmp.CFOP = IIf(IsDBNull(r("CFOP")), String.Empty, r("CFOP"))
		cmp.TransacaoData = IIf(IsDBNull(r("TransacaoData")), Nothing, r("TransacaoData"))
		'
		'--- TBLCONSIGNACAO
		cmp.FreteTipo = IIf(IsDBNull(r("FreteTipo")), Nothing, r("FreteTipo"))
		cmp.FreteCobrado = IIf(IsDBNull(r("FreteCobrado")), Nothing, r("FreteCobrado"))
		cmp.ICMSValor = IIf(IsDBNull(r("ICMSValor")), Nothing, r("ICMSValor"))
		cmp.Despesas = IIf(IsDBNull(r("Despesas")), Nothing, r("Despesas"))
		cmp.Descontos = IIf(IsDBNull(r("Descontos")), Nothing, r("Descontos"))
		cmp.TotalConsignacao = IIf(IsDBNull(r("TotalConsignacao")), Nothing, r("TotalConsignacao"))
		'
		'--- TBLOBSERVACAO
		cmp.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
		'
		'--- Dados da tblFrete
		cmp.Transportadora = IIf(IsDBNull(r("Transportadora")), String.Empty, r("Transportadora"))
		cmp.IDTransportadora = IIf(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora"))
		cmp.FreteValor = IIf(IsDBNull(r("FreteValor")), Nothing, r("FreteValor"))
		cmp.Volumes = IIf(IsDBNull(r("Volumes")), Nothing, r("Volumes"))
		cmp.IDFreteDespesa = IIf(IsDBNull(r("IDFreteDespesa")), Nothing, r("IDFreteDespesa"))
		'
		Return cmp
		'
	End Function
	'
	'==========================================================================================
	' INSERT CONSIGNACAO COMPRA
	'==========================================================================================
	Public Function InsertConsignacaoCompra(IDConsignacao As Integer,
											dbTran As Object) As clConsignacaoCompra
		'
		Dim db As AcessoDados
		'
		If IsNothing(dbTran) Then
			db = New AcessoDados
			db.BeginTransaction()
		Else
			db = dbTran
		End If
		'
		Try
			Dim query As String = ""
			'
			'-- INSERIR NA TBLCONSIGNACAO COMPRA ==> CobrancaTipo: 0 = SemCobrança | 1 = A Vista | 2 = Parcelada
			'-- ===================================================
			db.LimparParametros()
			db.AdicionarParametros("@IDConsignacao", IDConsignacao)
			'
			query = "INSERT INTO tblConsignacaoCompra " &
					"(IDConsignacao, Despesas, Descontos, TotalCompra, CobrancaTipo) " &
					"VALUES " &
					"(@IDConsignacao, 0, 0, 0, 0)"
			'
			Dim newID As Integer = db.ExecutarInsertGetID(query)
			'
			'-- COMMIT
			'-- ===================================================
			If IsNothing(dbTran) Then '--- TRANSACTION LOCAL
				db.CommitTransaction()
			End If
			'
			'-- GET NEW CONSIG COMPRA DT
			'-- ===================================================
			db.LimparParametros()
			db.AdicionarParametros("@IDConsignacaoCompra", newID)
			'
			query = "SELECT * FROM tblConsignacaoCompra WHERE IDConsignacaoCompra = @IDConsignacaoCompra "
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then Throw New Exception("Não houve retorno da Entrada, ou não foi inserida a entrada...")
			'
			If Not IsNumeric(dt.Rows(0).Item(0)) Then
				Throw New Exception("Uma exceção ocorreu ao inserir nova entrada." & vbNewLine & dt.Rows(0).Item(0))
			End If
			'
			'--- CONVERT DT IN CLASS AND RETURN
			'-- ===================================================
			Dim r As DataRow = dt.Rows(0)
			'
			Dim Compra As New clConsignacaoCompra(IDConsignacao) With {
				.IDConsignacaoCompra = r("IDConsignacaoCompra"),
				.IDConsignacao = r("IDConsignacao"),
				.CobrancaTipo = r("CobrancaTipo"),
				.Descontos = r("Descontos"),
				.Despesas = r("Despesas"),
				.TotalCompra = r("TotalCompra")
			}
			'
			Return Compra
			'
		Catch ex As Exception
			'
			If IsNothing(dbTran) Then '--- TRANSACTION LOCAL
				db.RollBackTransaction()
			End If
			'
			Throw ex
			'
		End Try
		'
	End Function
	'
	'==========================================================================================
	' INSERT CONSIGNACAO ENTRADA
	'==========================================================================================
	Public Function InsertConsignacaoDevolucao(devolucao As clConsignacaoDevolucao,
											   Optional dbTran As Object = Nothing) As clConsignacaoDevolucao
		'
		Try
			'
			Dim dtCompra As DataTable
			'
			dtCompra = InsertConsignacaoDevolucao_DT(devolucao, dbTran)
			'
			If dtCompra.Rows.Count > 0 Then
				Dim r As DataRow = dtCompra(0)
				'
				Return ConvertDtRow_clConsignacaoDevolucao(r)
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
	Private Function InsertConsignacaoDevolucao_DT(devolucao As clConsignacaoDevolucao,
												   Optional dbTran As Object = Nothing) As DataTable
		'
		Dim db As AcessoDados
		'
		If IsNothing(dbTran) Then
			db = New AcessoDados
			db.BeginTransaction()
		Else
			db = dbTran
		End If
		'
		Try
			'
			'-- INSERIR NA TBLTRANSACAO
			'-- ===================================================
			'Adiciona os Parâmetros
			db.LimparParametros()
			'
			'-- PARAMETROS DA TBLTRANSACAO
			db.AdicionarParametros("@IDPessoaDestino", devolucao.IDPessoaDestino)
			db.AdicionarParametros("@IDPessoaOrigem", devolucao.IDPessoaOrigem)
			db.AdicionarParametros("@IDOperacao", devolucao.IDOperacao)
			db.AdicionarParametros("@IDSituacao", devolucao.IDSituacao)
			db.AdicionarParametros("@IDUser", devolucao.IDUser)
			db.AdicionarParametros("@CFOP", devolucao.CFOP)
			db.AdicionarParametros("@TransacaoData", devolucao.TransacaoData)
			'
			Dim query As String = "INSERT INTO tblTransacao " &
								  "(IDPessoaDestino, IDPessoaOrigem, IDOperacao, IDSituacao, IDUser, CFOP, TransacaoData) " &
								  "VALUES " &
								  "(@IDPessoaDestino, @IDPessoaOrigem, @IDOperacao, @IDSituacao, @IDUser, @CFOP, @TransacaoData)"
			'
			Dim newID As Object = db.ExecutarInsertGetID(query)
			'
			If Not IsNumeric(newID) Then
				Throw New Exception("Um erro inesperado ocorreu no salvar Consignação..." & vbNewLine & newID.ToString)
			End If
			'
			'-- INSERIR NA TBLCONSIGNACAO DEVOLUCAO
			'-- ===================================================
			db.LimparParametros()
			db.AdicionarParametros("@IDTransacao", newID)
			db.AdicionarParametros("@IDConsignacaoOrigem", devolucao.IDConsignacaoOrigem)
			'
			query = "INSERT INTO tblConsignacaoDevolucao " &
					"(IDConsignacaoDevolucao, IDConsignacaoOrigem, ValorProdutos, ValorAcrescimos, ValorDescontos, TotalDevolucao) " &
					"VALUES " &
					"(@IDTransacao, @IDConsignacaoOrigem, 0, 0, 0, 0)"
			'
			db.ExecutarManipulacao(CommandType.Text, query)
			'
			'-- INSERIR NA tblFrete (caso necessidade)
			'--======================================================================
			If Not IsNothing(devolucao.IDTransportadora) AndAlso devolucao.IDTransportadora > 0 Then
				'
				db.LimparParametros()
				db.AdicionarParametros("@IDTransacao", newID)
				db.AdicionarParametros("@IDTransportadora", devolucao.IDTransportadora)
				db.AdicionarParametros("@FreteTipo", devolucao.FreteTipo)
				db.AdicionarParametros("@Volumes", devolucao.Volumes)
				db.AdicionarParametros("@FreteValor", If(devolucao.FreteValor, 0))
				'
				query = "INSERT INTO tblFrete " &
						"(IDTransacao, IDTransportadora, FreteTipo, Volumes, FreteValor) " &
						"VALUES " &
						"(@IDTransacao, @IDTransportadora, @FreteTipo, @Volumes, @FreteValor)"
				'
				db.ExecutarManipulacao(CommandType.Text, query)
				'
			End If
			'
			'-- COMMIT
			'-- ===================================================
			If IsNothing(dbTran) Then '--- TRANSACTION LOCAL
				db.CommitTransaction()
			End If
			'
			'-- RETURN
			'-- ===================================================
			db.LimparParametros()
			db.AdicionarParametros("@IDConsignacaoDevolucao", newID)
			'
			query = "SELECT * FROM qryConsignacaoDevolucao WHERE IDConsignacaoDevolucao = @IDConsignacaoDevolucao "
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then Throw New Exception("Não houve retorno da Entrada, ou não foi inserida a entrada...")
			'
			If IsNumeric(dt.Rows(0).Item(0)) Then
				Return dt
			Else
				Throw New Exception("Uma exceção ocorreu ao inserir nova entrada." & vbNewLine & dt.Rows(0).Item(0))
			End If
			'
		Catch ex As Exception
			'
			If IsNothing(dbTran) Then '--- TRANSACTION LOCAL
				db.RollBackTransaction()
			End If
			'
			Throw ex
			'
		End Try
		'
	End Function
	'
	'--------------------------------------------------------------------------------------------
	' CONVERT DATAROW DA DATATABLE COMPRA EM UM CLCONSIGNACAO DEVOLUCAO 
	'--------------------------------------------------------------------------------------------
	Private Function ConvertDtRow_clConsignacaoDevolucao(r As DataRow) As clConsignacaoDevolucao
		'
		Return New clConsignacaoDevolucao With {
			.IDConsignacaoDevolucao = IIf(IsDBNull(r("IDConsignacaoDevolucao")), Nothing, r("IDConsignacaoDevolucao")),
			.IDConsignacaoOrigem = IIf(IsDBNull(r("IDConsignacaoOrigem")), Nothing, r("IDConsignacaoOrigem")),
			.IDPessoaDestino = IIf(IsDBNull(r("IDPessoaDestino")), Nothing, r("IDPessoaDestino")),
			.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro")),
			.CNP = IIf(IsDBNull(r("CNP")), String.Empty, r("CNP")),
			.UF = IIf(IsDBNull(r("UF")), String.Empty, r("UF")),
			.Cidade = IIf(IsDBNull(r("Cidade")), String.Empty, r("Cidade")),
			.IDPessoaOrigem = IIf(IsDBNull(r("IDPessoaOrigem")), Nothing, r("IDPessoaOrigem")),
			.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial")),
			.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao")),
			.IDSituacao = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao")),
			.Situacao = IIf(IsDBNull(r("Situacao")), String.Empty, r("Situacao")),
			.IDUser = IIf(IsDBNull(r("IDUser")), Nothing, r("IDUser")),
			.CFOP = IIf(IsDBNull(r("CFOP")), String.Empty, r("CFOP")),
			.TransacaoData = IIf(IsDBNull(r("TransacaoData")), Nothing, r("TransacaoData")),
			.FreteTipo = IIf(IsDBNull(r("FreteTipo")), Nothing, r("FreteTipo")),
			.ValorProdutos = IIf(IsDBNull(r("ValorProdutos")), Nothing, r("ValorProdutos")),
			.TotalDevolucao = IIf(IsDBNull(r("TotalDevolucao")), Nothing, r("TotalDevolucao")),
			.ValorAcrescimos = IIf(IsDBNull(r("ValorAcrescimos")), Nothing, r("ValorAcrescimos")),
			.ValorDescontos = IIf(IsDBNull(r("ValorDescontos")), Nothing, r("ValorDescontos")),
			.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao")),
			.Transportadora = IIf(IsDBNull(r("Transportadora")), String.Empty, r("Transportadora")),
			.IDTransportadora = IIf(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora")),
			.FreteValor = IIf(IsDBNull(r("FreteValor")), Nothing, r("FreteValor")),
			.Volumes = IIf(IsDBNull(r("Volumes")), Nothing, r("Volumes")),
			.IDFreteDespesa = IIf(IsDBNull(r("IDFreteDespesa")), Nothing, r("IDFreteDespesa"))
			}

		'
	End Function
	'
	'==========================================================================================
	' INSERT ITEM CONSIGNACAO COMPRA
	'==========================================================================================
	Public Function InsertItemConsigCompra(item As clConsignacaoCompraItem,
										   Optional dbTran As AcessoDados = Nothing) As clConsignacaoCompraItem
		'
		Try
			Dim db As AcessoDados = If(dbTran, New AcessoDados)
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDConsignacaoCompra", item.IDConsignacaoCompra)
			db.AdicionarParametros("@IDProduto", item.IDProduto)
			db.AdicionarParametros("@Quantidade", item.Quantidade)
			db.AdicionarParametros("@Preco", item.Preco)
			db.AdicionarParametros("@Desconto", item.Desconto)
			'
			Dim query As String = "INSERT INTO tblConsignacaoCompraItem " &
								  "(IDConsignacaoCompra, IDProduto, Quantidade, Preco, Desconto) " &
								  "VALUES " &
								  "(@IDConsignacaoCompra, @IDProduto, @Quantidade, @Preco, @Desconto)"
			'
			Dim newID As Integer = db.ExecutarInsertGetID(query)
			'
			item.IDItem = newID
			Return item
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' UPDATE ITEM CONSIGNACAO COMPRA
	'==========================================================================================
	Public Function UpdateItemConsigCompra(item As clConsignacaoCompraItem,
										   Optional dbTran As AcessoDados = Nothing) As Boolean
		'
		Try
			Dim db As AcessoDados = If(dbTran, New AcessoDados)
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDItem", item.IDItem)
			db.AdicionarParametros("@IDConsignacaoCompra", item.IDConsignacaoCompra)
			db.AdicionarParametros("@IDProduto", item.IDProduto)
			db.AdicionarParametros("@Quantidade", item.Quantidade)
			db.AdicionarParametros("@Preco", item.Preco)
			db.AdicionarParametros("@Desconto", item.Desconto)
			'
			Dim query As String = "UPDATE tblConsignacaoCompraItem SET " &
								  "IDConsignacaoCompra = @IDConsignacaoCompra, " &
								  "IDProduto = @IDProduto, " &
								  "Quantidade = @Quantidade, " &
								  "Preco = @Preco, " &
								  "Desconto = @Desconto " &
								  "WHERE IDItem = @Item"
			'
			db.ExecutarManipulacao(CommandType.Text, query)

			Return True
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' DELETE ITEM CONSIGNACAO COMPRA
	'==========================================================================================
	Public Function DeleteItemConsigCompra(item As clConsignacaoCompraItem,
										   Optional dbTran As AcessoDados = Nothing) As Boolean
		'
		Try
			Dim db As AcessoDados = If(dbTran, New AcessoDados)
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDItem", item.IDItem)
			'
			Dim query As String = "DELETE tblConsignacaoCompraItem " &
								  "WHERE IDItem = @Item"
			'
			db.ExecutarManipulacao(CommandType.Text, query)

			Return True
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
End Class
