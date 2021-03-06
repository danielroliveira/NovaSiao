﻿Imports CamadaDAL
Imports CamadaDTO

Public Class ReservaBLL
	'
	'===================================================================================================
	' OBTER LISTA COMPLETA DE RESERVA PELA SITUACAO
	'===================================================================================================
	Public Function Reserva_GET_List(_IDFilial As Integer,
									 IsReservaPrioritaria As Boolean,
									 Optional _IDSituacaoReserva As Byte? = Nothing,
									 Optional _ReservaAtiva As Boolean? = Nothing) As List(Of clReserva)
		Dim bd As New AcessoDados
		Dim lst As New List(Of clReserva)
		'
		bd.LimparParametros()
		'
		'--- ADD FILIAL
		bd.AdicionarParametros("@IDFilial", _IDFilial)
		Dim query As String = "SELECT * FROM qryReserva WHERE IDFilial = @IDFilial "
		'
		'--- ADD RESERVA PRIORITARIA
		If IsReservaPrioritaria Then
			query += "AND ValorAntecipado IS NOT NULL "
		End If
		'
		'--- ADD RESERVAATIVA
		If Not IsNothing(_ReservaAtiva) Then
			bd.AdicionarParametros("@ReservaAtiva", _ReservaAtiva)
			query += "AND ReservaAtiva = @ReservaAtiva "
		End If
		'
		'--- ADD SITUACAO RESERVA
		If Not IsNothing(_IDSituacaoReserva) Then
			bd.AdicionarParametros("@IDSituacaoReserva", _IDSituacaoReserva)
			query += "AND IDSituacaoReserva = @IDSituacaoReserva "
		End If
		'
		'--- ORDER BY
		query += "ORDER BY ReservaData"
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
	' GET RESERVA PELO ID
	'==========================================================================================
	Public Function GetReservaPeloID(IDReserva As Integer) As clReserva
        '
        Try
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDReserva", IDReserva)
            Dim query As String = "SELECT * FROM qryReserva WHERE IDReserva = @IDReserva"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then
                Throw New AppException("Não existe reserva com o ID informado...")
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
    Public Function Reserva_Inserir(myReserva As clReserva) As Object
        '
        Dim db As New AcessoDados
        db.BeginTransaction()
		'
		Try
			'
			Dim query As String = ""
			Dim response As Object = Nothing
			Dim NewID As Integer = Nothing
			'
			'--- INSERT RESERVA - GET NewID
			'-------------------------------------------------------------------------------------------------
			db.LimparParametros()
			'
			'--- ADICIONA OS PARAMENTROS NECESSARIOS
			db.AdicionarParametros("@IDClienteSimples", myReserva.IDClienteSimples)
			db.AdicionarParametros("@ReservaData", myReserva.ReservaData)
			db.AdicionarParametros("@IDFuncionario", myReserva.IDFuncionario)
			db.AdicionarParametros("@IDFilial", myReserva.IDFilial)
			db.AdicionarParametros("@ProdutoConhecido", myReserva.ProdutoConhecido)
			db.AdicionarParametros("@IDProduto", If(myReserva.IDProduto, DBNull.Value))
			db.AdicionarParametros("@Produto", myReserva.Produto)
			db.AdicionarParametros("@Autor", If(myReserva.Autor, DBNull.Value))
			db.AdicionarParametros("@IDFornecedor", If(myReserva.IDFornecedor, DBNull.Value))
			db.AdicionarParametros("@IDFabricante", If(myReserva.IDFabricante, DBNull.Value))
			db.AdicionarParametros("@IDProdutoTipo", If(myReserva.IDProdutoTipo, DBNull.Value))
			db.AdicionarParametros("@IDPedido", If(myReserva.IDPedido, DBNull.Value))
			db.AdicionarParametros("@ValorAntecipado", If(myReserva.ValorAntecipado, DBNull.Value))
			'
			query =
			"INSERT INTO tblReserva " +
			"( ReservaData, IDFuncionario, IDFilial, IDClienteSimples " +
			", ProdutoConhecido, IDProduto, Produto, Autor " +
			", IDFornecedor, IDFabricante, IDProdutoTipo, IDSituacaoReserva, IDPedido, ValorAntecipado ) " +
			"VALUES " +
			"( @ReservaData, @IDFuncionario, @IDFilial, @IDClienteSimples " +
			", @ProdutoConhecido, @IDProduto, @Produto, @Autor " +
			", @IDFornecedor, @IDFabricante, @IDProdutoTipo, 1, @IDPedido, @ValorAntecipado )"
			'
			response = db.ExecutarInsertGetID(query)
			'
			If IsNumeric(response) Then
				NewID = response
			Else
				Throw New Exception(response.ToString)
			End If
			'
			'--- INSERT OBSERVACAO
			'-------------------------------------------------------------------------------------------------
			If If(myReserva.Observacao, "").Trim <> "" Then
				Dim oBLL As New ObservacaoBLL
				oBLL.SaveObservacao(6, NewID, myReserva.Observacao, db)
			End If
			'
			db.CommitTransaction()
			Return NewID
			'
		Catch ex As Exception
			db.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
	'
	'===================================================================================================
	' ALTERAR REGISTRO
	'===================================================================================================
	Public Function Reserva_Alterar(myReserva As clReserva) As Object
		'
		Dim db As New AcessoDados
		db.BeginTransaction()
		'
		Try
			'
			'--- UPDATE RESERVA
			'-------------------------------------------------------------------------------------------------
			db.LimparParametros()
			'
			'--- ADICIONA OS PARAMENTROS NECESSARIOS
			db.AdicionarParametros("@IDReserva", myReserva.IDReserva)
			db.AdicionarParametros("@ReservaData", myReserva.ReservaData)
			db.AdicionarParametros("@IDFuncionario", myReserva.IDFuncionario)
			db.AdicionarParametros("@IDFilial", myReserva.IDFilial)
			db.AdicionarParametros("@IDClienteSimples", myReserva.IDClienteSimples)
			db.AdicionarParametros("@ProdutoConhecido", myReserva.ProdutoConhecido)
			db.AdicionarParametros("@IDProduto", If(myReserva.IDProduto, DBNull.Value))
			db.AdicionarParametros("@Produto", myReserva.Produto)
			db.AdicionarParametros("@Autor", If(myReserva.Autor, DBNull.Value))
			db.AdicionarParametros("@IDFornecedor", If(myReserva.IDFornecedor, DBNull.Value))
			db.AdicionarParametros("@IDFabricante", If(myReserva.IDFabricante, DBNull.Value))
			db.AdicionarParametros("@IDProdutoTipo", If(myReserva.IDProdutoTipo, DBNull.Value))
			db.AdicionarParametros("@IDPedido", If(myReserva.IDPedido, DBNull.Value))
			db.AdicionarParametros("@IDSituacaoReserva", myReserva.IDSituacaoReserva)
			db.AdicionarParametros("@ConclusaoData", If(myReserva.ConclusaoData, DBNull.Value))
			db.AdicionarParametros("@ValorAntecipado", If(myReserva.ValorAntecipado, DBNull.Value))
			'
			Dim query = "UPDATE tblReserva SET " +
					"ReservaData = @ReservaData " +
					", IDFuncionario = @IDFuncionario " +
					", IDFilial = @IDFilial " +
					", IDClienteSimples = @IDClienteSimples " +
					", ProdutoConhecido = @ProdutoConhecido " +
					", IDProduto = @IDProduto " +
					", Produto = @Produto " +
					", Autor = @Autor " +
					", IDFornecedor = @IDFornecedor " +
					", IDFabricante = @IDFabricante " +
					", IDProdutoTipo = @IDProdutoTipo " +
					", IDPedido = @IDPedido " +
					", IDSituacaoReserva = @IDSituacaoReserva " +
					", ConclusaoData = @ConclusaoData " +
					", ValorAntecipado = @ValorAntecipado " +
					"WHERE " +
					"IDReserva = @IDReserva"
			'
			db.ExecutarManipulacao(CommandType.Text, query)
			'
			'--- OBSERVACAO
			Dim oBLL As New ObservacaoBLL
			oBLL.SaveObservacao(6, myReserva.IDReserva, myReserva.Observacao, db)
			'
			db.CommitTransaction()
			Return myReserva.IDReserva
			'
		Catch ex As Exception
			db.RollBackTransaction()
			Throw ex
		End Try
		'
	End Function
	'
	'===================================================================================================
	' ALTERA A SITUCAO DA RESERVA
	'===================================================================================================
	Public Function Reserva_AlteraSituacao(IDReserva As Integer, IDSituacao As Byte, dbTran As Object) As Boolean
        '
        Dim db As AcessoDados = dbTran
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDSituacaoReserva", IDSituacao)
        db.AdicionarParametros("@IDReserva", IDReserva)
        '
        Dim mySQL As String = "UPDATE tblReserva SET IDSituacaoReserva = @IDSituacaoReserva WHERE IDReserva = @IDReserva"
        '
        Try
            '
            db.ExecutarManipulacao(CommandType.Text, mySQL)
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' GET RESERVA SITUACAO
    '===================================================================================================
    Public Function ReservaSituacaoGetList(Optional ReservaAtiva As Boolean? = Nothing) As List(Of clReservaSituacao)
        '
        Try
            Dim db As New AcessoDados
            Dim str As String = ""
            '
            If IsNothing(ReservaAtiva) Then
                str = "SELECT * FROM tblReservaSituacao"
            Else
                str = "SELECT * FROM tblReservaSituacao WHERE ReservaAtiva = '" & ReservaAtiva.ToString & "'"
            End If
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, str)
            '
            Dim lst As New List(Of clReservaSituacao)
            '
            If dt.Rows.Count = 0 Then Return lst
            '
            For Each r As DataRow In dt.Rows
                Dim sit As New clReservaSituacao
                '
                sit.IDSituacaoReserva = r("IDSituacaoReserva")
                sit.SituacaoReserva = r("SituacaoReserva")
                sit.ReservaAtiva = r("ReservaAtiva")
                '
                lst.Add(sit)
                '
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
    ' CONVERT ROW IN CLASS
    '==========================================================================================
    Private Function ConvertRowClass(r As DataRow) As clReserva
        '
        Dim res As New clReserva
        '
        res.IDReserva = IIf(IsDBNull(r("IDReserva")), Nothing, r("IDReserva"))
        res.ReservaData = IIf(IsDBNull(r("ReservaData")), Nothing, r("ReservaData"))
        res.IDFuncionario = IIf(IsDBNull(r("IDFuncionario")), Nothing, r("IDFuncionario"))
        res.ApelidoFuncionario = IIf(IsDBNull(r("ApelidoFuncionario")), String.Empty, r("ApelidoFuncionario"))
        res.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
        res.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
		res.IDClienteSimples = IIf(IsDBNull(r("IDClienteSimples")), Nothing, r("IDClienteSimples"))
		res.ClienteNome = IIf(IsDBNull(r("ClienteNome")), String.Empty, r("ClienteNome"))
		res.TelefoneA = IIf(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
        res.TelefoneB = IIf(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
		res.TemWhatsapp = IIf(IsDBNull(r("TemWhatsapp")), Nothing, r("TemWhatsapp"))
		res.ClienteEmail = IIf(IsDBNull(r("ClienteEmail")), String.Empty, r("ClienteEmail"))
        res.ProdutoConhecido = IIf(IsDBNull(r("ProdutoConhecido")), Nothing, r("ProdutoConhecido"))
        res.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
        res.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
        res.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
        res.PVenda = IIf(IsDBNull(r("PVenda")), Nothing, r("PVenda"))
        res.Autor = IIf(IsDBNull(r("Autor")), String.Empty, r("Autor"))
        res.IDFornecedor = IIf(IsDBNull(r("IDFornecedor")), Nothing, r("IDFornecedor"))
        res.Fornecedor = IIf(IsDBNull(r("Fornecedor")), String.Empty, r("Fornecedor"))
        res.IDFabricante = IIf(IsDBNull(r("IDFabricante")), Nothing, r("IDFabricante"))
        res.Fabricante = IIf(IsDBNull(r("Fabricante")), String.Empty, r("Fabricante"))
        res.IDProdutoTipo = IIf(IsDBNull(r("IDProdutoTipo")), Nothing, r("IDProdutoTipo"))
        res.ProdutoTipo = IIf(IsDBNull(r("ProdutoTipo")), String.Empty, r("ProdutoTipo"))
        res.IDSituacaoReserva = IIf(IsDBNull(r("IDSituacaoReserva")), Nothing, r("IDSituacaoReserva"))
        res.SituacaoReserva = IIf(IsDBNull(r("SituacaoReserva")), String.Empty, r("SituacaoReserva"))
        res.ConclusaoData = IIf(IsDBNull(r("ConclusaoData")), Nothing, r("ConclusaoData"))
        res.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        res.ReservaAtiva = IIf(IsDBNull(r("ReservaAtiva")), Nothing, r("ReservaAtiva"))
		res.IDPedido = IIf(IsDBNull(r("IDPedido")), Nothing, r("IDPedido"))
		res.ValorAntecipado = IIf(IsDBNull(r("ValorAntecipado")), Nothing, r("ValorAntecipado"))
		'
		Return res
        '
    End Function
	'
	'==========================================================================================
	' DELETE RESERVA - BEFORE check PEDIDO
	'==========================================================================================
	' TODO: NEED TO CHECK IDCLIENTE RESERVA
	Public Function DeleteReserva(Reserva As clReserva, Optional SubtraiPedido As Boolean = False) As Boolean
        '
        Dim db As AcessoDados
        Dim query As String = ""
        '
        Try
            db = New AcessoDados
            db.BeginTransaction()
            '
            '--- check if is connected with Pedido
            If Not IsNothing(Reserva.IDPedido) Then
                '
                db.LimparParametros()
                db.AdicionarParametros("@IDPedido", Reserva.IDPedido)
                db.AdicionarParametros("@IDReserva", Reserva.IDReserva)
                '
                If Not SubtraiPedido Then
                    query = "UPDATE tblPedidoItens SET " &
                            "Origem = 0, IDOrigem = NULL " &
                            "WHERE Origem = 1 " & '--- origem RESERVA
                            "AND IDPedido = @IDPedido " &
                            "AND IDReserva = @IDReserva"
                    '
                    db.ExecutarManipulacao(CommandType.Text, query)
                    '
                Else '--- NESSE CASO RETIRA UMA QUANTIDADE DO PEDIDO SE PUDER
                    '
                    '--- CHECK old QUANTIDADE of Produto in Pedido
                    '------------------------------------------------
                    query = "SELECT tblPedidoItens " &
                            "WHERE Origem = 1 " & '--- origem RESERVA
                            "AND IDPedido = @IDPedido " &
                            "AND IDReserva = @IDReserva"
                    '
                    Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
                    '
                    If dt.Rows.Count = 0 Then
                        Throw New AppException("Não existe item com o Reserva informada...")
                    Else
                        If Not IsNumeric(dt.Rows(0).Item(0)) Then
                            Throw New Exception(dt.Rows(0).ToString)
                        End If
                    End If
                    '
                    Dim quant As Integer = dt.Rows(0).Item("Quantidade")
                    '
                    '--- UPDATE OR DELETE ITEM PEDIDO
                    '-------------------------------------------------------------------------
                    db.LimparParametros()
                    db.AdicionarParametros("@IDPedido", Reserva.IDPedido)
                    db.AdicionarParametros("@IDReserva", Reserva.IDReserva)
                    '
                    If quant <= 1 Then '--- DELETE ITEM DO PEDIDO
                        query = "DELETE tblPedidoItens " &
                                "WHERE Origem = 1 " & '--- origem RESERVA
                                "AND IDPedido = @IDPedido " &
                                "AND IDReserva = @IDReserva"
                    Else '--- REMOVE ONE UNITY OF PEDIDO
                        db.AdicionarParametros("@Quant", quant - 1)
                        '
                        query = "UPDATE tblPedidoItens SET " &
                                "Origem = 0, IDOrigem = NULL, Quantidade = @Quant " &
                                "WHERE Origem = 1 " & '--- origem RESERVA
                                "AND IDPedido = @IDPedido " &
                                "AND IDReserva = @IDReserva"
                    End If
                    '
                End If
                '
            End If
            '
            '--- DELETE RESERVA
            '-------------------------------------------------------------------
            db.LimparParametros()
            db.AdicionarParametros("@IDReserva", Reserva.IDReserva)
            '
            query = "DELETE tblReserva WHERE IDReserva = @IDReserva"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    ' 
    '==========================================================================================
    ' INSERT PEDIDO IN RESERVA AND CHANGE SITUACAO OF RESERVA
    '==========================================================================================
    Public Sub ResolveReservaWithPedido(IDReserva As Integer, IDPedido As Integer, dbTran As AcessoDados)
        '
        Try
            '
            dbTran.LimparParametros()
            dbTran.AdicionarParametros("@IDReserva", IDReserva)
            dbTran.AdicionarParametros("@IDPedido", IDPedido)
            '
            Dim query As String = "UPDATE tblReserva SET IDPedido = @IDPedido, " +
                                  "IDSituacaoReserva = 2 " +
                                  "WHERE IDReserva = @IDReserva"
            '
            dbTran.ExecutarManipulacao(CommandType.Text, query)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
	'
	'
#Region "ANTECIPACAO DA RESERVA INSERT | REMOVE | DOVOLUCAO"
	'
	'==========================================================================================
	' INSERT ADIANTAMENTO DE RESERVA : CREATE MOVIMENTACAO AND UPDATE RESERVA
	'==========================================================================================
	Public Function Adiantamento_Insert(Reserva As clReserva, Movimentacao As clMovimentacao) As Boolean
		'
		Dim dbTran As AcessoDados = Nothing
		'
		Try
			dbTran = New AcessoDados
			dbTran.BeginTransaction()
			'
			'--- INSERT MOVIMENTACAO
			'-------------------------------------------------------------------------------------------------
			Dim eBLL As New MovimentacaoBLL
			Movimentacao = eBLL.Movimentacao_Inserir(Movimentacao, dbTran)
			'
			'--- UPDATE RESERVA
			'-------------------------------------------------------------------------------------------------
			dbTran.LimparParametros()
			dbTran.AdicionarParametros("@IDReserva", Reserva.IDReserva)
			dbTran.AdicionarParametros("@ValorAntecipado", Movimentacao.MovValor)
			'
			Dim query As String = "UPDATE tblReserva SET ValorAntecipado = @ValorAntecipado WHERE IDReserva = @IDReserva"
			'
			dbTran.ExecutarManipulacao(CommandType.Text, query)
			'
			'--- COMMIT AND RETURN
			dbTran.CommitTransaction()
			Return True
			'
		Catch ex As Exception
			dbTran.RollBackTransaction()
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' ESTORNO VALOR ANTECIPADO
	'==========================================================================================
	Public Function Adiantamento_Estornar(_reserva As clReserva) As Boolean
		'
		Dim db As AcessoDados = Nothing
		Dim query As String = ""
		'
		Try
			db = New AcessoDados
			'
			'--- 1. CHECK IF MOVIMENTACAO IS INSERTED IN CAIXA
			db.LimparParametros()
			db.AdicionarParametros("@IDOrigem", _reserva.IDReserva)
			'
			query = "SELECT * FROM tblCaixaMovimentacao WHERE Origem = 5 AND IDOrigem = @IDOrigem"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then
				Throw New AppException("Não há nenhum adiantamento inserido na reserva...")
				Return False
			ElseIf Not IsNumeric(dt.Rows(0)(0)) Then
				Throw New Exception(dt.Rows(0)(0).ToString)
				Return False
			End If
			'
			'--- check IDCaixa
			If Not IsDBNull(dt.Rows(0)("IDCaixa")) Then
				Throw New AppException("Não é possível estornar o Adiantamento porque já foi inserido no Caixa.")
				Return False
			End If
			'
			'--- CREATE NEW TRANSACTION
			db.BeginTransaction()
			'
			'--- 2. DELETE MOVIMENTACAO
			db.LimparParametros()
			db.AdicionarParametros("@IDOrigem", _reserva.IDReserva)
			'
			query = "DELETE tblCaixaMovimentacao WHERE Origem = 5 AND IDOrigem = @IDOrigem"
			'
			db.ExecutarManipulacao(CommandType.Text, query)
			'
			'--- 3. UPDATE RESERVA
			db.LimparParametros()
			db.AdicionarParametros("@IDReserva", _reserva.IDReserva)
			'
			query = "UPDATE tblReserva SET ValorAntecipado = NULL WHERE IDReserva = @IDReserva"
			'
			db.ExecutarManipulacao(CommandType.Text, query)
			_reserva.ValorAntecipado = Nothing
			'
			'--- 4. COMMIT TRANSACTION
			db.CommitTransaction()
			Return True
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'==========================================================================================
	' DEVOLUCAO VALOR ANTECIPADO
	'==========================================================================================
	Public Function Adiantamento_Devolucao(_reserva As clReserva,
										   DevolucaoData As Date,
										   Optional dbTran As Object = Nothing) As Boolean
		'
		Dim db As AcessoDados = If(dbTran, New AcessoDados)
		Dim query As String = ""
		'
		Try
			db = New AcessoDados
			'
			'--- 1. CHECK IF MOVIMENTACAO IS INSERTED IN CAIXA
			'------------------------------------------------------------------------------
			db.LimparParametros()
			db.AdicionarParametros("@IDOrigem", _reserva.IDReserva)
			'
			query = "SELECT * FROM tblCaixaMovimentacao WHERE Origem = 5 AND IDOrigem = @IDOrigem"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then
				Throw New AppException("Não há nenhum adiantamento inserido na reserva...")
				Return False
			ElseIf Not IsNumeric(dt.Rows(0)(0)) Then
				Throw New Exception(dt.Rows(0)(0).ToString)
				Return False
			End If
			'
			'--- check IDCaixa
			If IsDBNull(dt.Rows(0)("IDCaixa")) Then
				Throw New AppException("O Adiantamento ainda não foi inserido no caixa..." & vbNewLine &
									   "Nesse caso, favor realizar o ESTORNO do adiantamento.")
				Return False
			End If
			'
			'--- check DevolucaoData
			Dim mBLL As New MovimentacaoBLL
			Dim OldMov As clMovimentacao = mBLL.Convert_DT_ListOF_Movimentacao(dt).Item(0)
			'
			Dim dtBloq As Date? = mBLL.Conta_GetDataBloqueio(OldMov.IDConta)
			'
			If dtBloq IsNot Nothing AndAlso dtBloq >= DevolucaoData Then
				Throw New AppException("A data informada está bloqueada pelo sistema" & vbNewLine &
					   "Favor verificar a Data da Devolução.")
				Return False
			End If
			'
			'--- CREATE NEW TRANSACTION
			If dbTran Is Nothing Then db.BeginTransaction()
			'
			'--- 2. CREATE AND INSERT NEW MOVIMENTACAO
			'------------------------------------------------------------------------------
			Dim newMov As New clMovimentacao(EnumMovimentacaoOrigem.Reserva, EnumMovimento.Saida) With {
				.Descricao = "Devolução de Adiantamento de Reserva: " & Format(_reserva.IDReserva, "0000") - _reserva.ClienteNome,
				.IDConta = OldMov.IDConta,
				.IDFilial = OldMov.IDFilial,
				.IDMeio = 1,
				.IDMovForma = 1,
				.IDMovTipo = 1,
				.IDOrigem = _reserva.IDReserva,
				.Origem = 5,
				.MovData = DevolucaoData,
				.MovValor = _reserva.ValorAntecipado
				}
			'
			'--- insert
			mBLL.Movimentacao_Inserir(newMov, db)
			'
			'--- 3. UPDATE RESERVA
			'------------------------------------------------------------------------------
			db.LimparParametros()
			db.AdicionarParametros("@IDReserva", _reserva.IDReserva)
			db.AdicionarParametros("@ValorAntecipado", _reserva.ValorAntecipado * (-1))
			'
			query = "UPDATE tblReserva SET ValorAntecipado = @ValorAntecipado WHERE IDReserva = @IDReserva"
			'
			db.ExecutarManipulacao(CommandType.Text, query)
			_reserva.ValorAntecipado *= -1
			'
			'--- 4. COMMIT TRANSACTION
			'------------------------------------------------------------------------------
			If dbTran Is Nothing Then db.CommitTransaction()
			Return True
			'
		Catch ex As Exception
			If dbTran Is Nothing Then db.RollBackTransaction()
			Throw ex
		End Try
		'
	End Function
	'
#End Region '/ ANTECIPACAO DA RESERVA INSERT | REMOVE | DOVOLUCAO
	'
End Class
