Imports CamadaDTO
Imports CamadaDAL
'
Public Class CompraBLL
    '
    '--------------------------------------------------------------------------------------------
    ' GET DATATABLE COM WHERE
    '--------------------------------------------------------------------------------------------
    Public Function GetCompra_DT(Optional myWhere As String = "") As DataTable
        '
        Dim objdb As New AcessoDados
        Dim dt As New DataTable
        Dim strSql As String
        '
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryCompra"
        Else
            strSql = "SELECT * FROM qryCompra WHERE " & myWhere
        End If
        '
        Try
            dt = objdb.ExecutarConsulta(CommandType.Text, strSql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET LIST COM WHERE
    '--------------------------------------------------------------------------------------------
    Public Function GetCompra_List(Optional myWhere As String = "") As List(Of clCompra)
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryCompra"
        Else
            strSql = "SELECT * FROM qryCompra WHERE " & myWhere
        End If
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            Dim lista As New List(Of clCompra)
            '
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each r As DataRow In dt.Rows
                Dim cmp As clCompra = New clCompra
                cmp = ConvertDtRow_clCompra(r)
                lista.Add(cmp)

            Next
            '
            Return lista
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET REGISTRO POR ID/RG
    '--------------------------------------------------------------------------------------------
    Public Function GetCompra_PorID_OBJ(ByVal myIDCompra As Integer) As clCompra
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        strSql = "SELECT * FROM qryCompra WHERE IDCompra = " & myIDCompra
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            '
            If dt.Rows.Count = 0 Then Return Nothing
            '
            Dim r As DataRow = dt.Rows(0)
            Return ConvertDtRow_clCompra(r)

        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' UPDATE
    '--------------------------------------------------------------------------------------------
    Public Function AtualizaCompra_Procedure_ID(ByVal _compra As clCompra) As String
		Dim dbTran As New AcessoDados
		'
		'Limpa os Parâmetros
		dbTran.LimparParametros()
		'
		'-- PARAMETROS DA TBLTRANSACAO
		dbTran.AdicionarParametros("@IDcompra", _compra.IDCompra)
		dbTran.AdicionarParametros("@IDPessoaDestino", _compra.IDPessoaDestino)
		dbTran.AdicionarParametros("@IDPessoaOrigem", _compra.IDPessoaOrigem)
		dbTran.AdicionarParametros("@IDOperacao", _compra.IDOperacao)
		dbTran.AdicionarParametros("@IDSituacao", _compra.IDSituacao)
		dbTran.AdicionarParametros("@IDUser", _compra.IDUser)
		dbTran.AdicionarParametros("@CFOP", _compra.CFOP)
		dbTran.AdicionarParametros("@TransacaoData", _compra.TransacaoData)
		'
		'-- PARAMETROS DA TBLCompra
		dbTran.AdicionarParametros("@FreteCobrado", _compra.FreteCobrado)
		dbTran.AdicionarParametros("@ICMSValor", _compra.ICMSValor)
		dbTran.AdicionarParametros("@Despesas", _compra.Despesas)
		dbTran.AdicionarParametros("@Descontos", _compra.Descontos)
		dbTran.AdicionarParametros("@CobrancaTipo", _compra.CobrancaTipo)
		dbTran.AdicionarParametros("@TotalCompra", _compra.TotalCompra)
		'
		'-- PARAMETROS DA TBLOBSERVACAO
		dbTran.AdicionarParametros("@Observacao", _compra.Observacao)
		'
		'-- PARAMETROS DA TBLFRETE
		dbTran.AdicionarParametros("@IDTransportadora", _compra.IDTransportadora)
		dbTran.AdicionarParametros("@FreteValor", _compra.FreteValor)
		dbTran.AdicionarParametros("@FreteTipo", _compra.FreteTipo) '-- 0|SEM FRETE ; 1|EMITENTE; 2|DESTINATARIO
		dbTran.AdicionarParametros("@Volumes", _compra.Volumes)
		dbTran.AdicionarParametros("@IDFreteDespesa", _compra.IDFreteDespesa)
		'
		Try
			Return dbTran.ExecutarManipulacao(CommandType.StoredProcedure, "uspCompra_Alterar")
		Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
    End Function
	'
	'--------------------------------------------------------------------------------------------
	' INSERT NOVA COMPRA E RETORNA UMA CLCOMPRA
	'--------------------------------------------------------------------------------------------
	Public Function SalvaNovaCompra_Compra(ByVal _compra As clCompra,
													 Optional dbTran As Object = Nothing) As clCompra
		'
		Try
			'
			Dim dtCompra As DataTable
			'
			dtCompra = SalvaNovaCompra_DT(_compra, dbTran)
			'
			If dtCompra.Rows.Count > 0 Then
				Dim r As DataRow = dtCompra(0)
				'
				Return ConvertDtRow_clCompra(r)
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
	'--------------------------------------------------------------------------------------------
	' INSERT NOVA COMPRA E RETORNA UM DATATABLE
	'--------------------------------------------------------------------------------------------
	Public Function SalvaNovaCompra_DT(ByVal _compra As clCompra,
                                       Optional dbTran As AcessoDados = Nothing) As DataTable
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
            'Adiciona os Parâmetros
            db.LimparParametros()
            '
            '-- PARAMETROS DA TBLTRANSACAO
            db.AdicionarParametros("@IDPessoaDestino", _compra.IDPessoaDestino)
            db.AdicionarParametros("@IDPessoaOrigem", _compra.IDPessoaOrigem)
            db.AdicionarParametros("@IDOperacao", _compra.IDOperacao)
            db.AdicionarParametros("@IDSituacao", _compra.IDSituacao)
            db.AdicionarParametros("@IDUser", _compra.IDUser)
            db.AdicionarParametros("@CFOP", _compra.CFOP)
            db.AdicionarParametros("@TransacaoData", _compra.TransacaoData)
            '
            '-- INSERIR NA TBLTRANSACAO
            '-- ===================================================
            Dim query As String = "INSERT INTO tblTransacao " &
                                  "(IDPessoaDestino, IDPessoaOrigem, IDOperacao, IDSituacao, IDUser, CFOP, TransacaoData) " &
                                  "VALUES " &
                                  "(@IDPessoaDestino, @IDPessoaOrigem, @IDOperacao, @IDSituacao, @IDUser, @CFOP, @TransacaoData)"
            '
            'Dim dt As Object = db.ExecutarConsulta(CommandType.StoredProcedure, "uspCompra_Inserir")
            Dim newID As Object = db.ExecutarInsertGetID(query)
            '
            If Not IsNumeric(newID) Then
                Throw New Exception("Um erro inesperado ocorreu no salvar entrada..." & vbNewLine & newID.ToString)
            End If
            '
            '-- INSERIR NA TBLCOMPRA
            '-- ===================================================
            db.LimparParametros()
            db.AdicionarParametros("@IDTransacao", newID)
            '
            query = "INSERT INTO tblCompra " &
                    "(IDCompra, FreteCobrado, ICMSValor, Despesas, Descontos, TotalCompra, CobrancaTipo) " &
                    "VALUES " &
                    "(@IDTransacao, 0, 0, 0, 0, 0, 0)"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            '-- INSERIR NA tblFrete (caso necessidade)
            '--======================================================================
            If Not IsNothing(_compra.IDTransportadora) AndAlso _compra.IDTransportadora > 0 Then
                '
                db.LimparParametros()
                db.AdicionarParametros("@IDTransacao", newID)
                db.AdicionarParametros("@IDTransportadora", _compra.IDTransportadora)
                db.AdicionarParametros("@FreteTipo", _compra.FreteTipo)
                db.AdicionarParametros("@Volumes", _compra.Volumes)
                db.AdicionarParametros("@FreteValor", If(_compra.FreteValor, 0))
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
            db.AdicionarParametros("@IDCompra", newID)
            '
            query = "SELECT * FROM qryCompra WHERE IDCompra = @IDCompra "
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
    ' DELETE COMPRA POR IDCOMPRA
    '--------------------------------------------------------------------------------------------
    Public Function DeletaCompraPorID(IDCompra As Integer, IDFilial As Integer, Info As Object) As Boolean
        '
        Dim clCmp As clCompra = Nothing
        Dim myQuery As String = ""
        '
        '--- INFO
        Info.InfoShow("Obtendo os dados da Compra")
        '
        '--- OBTEM O CLCOMPRA
        '------------------------------------------------------------------
        Try
            clCmp = GetCompra_PorID_OBJ(IDCompra)
            '
            If IsNothing(clCmp) Then Throw New Exception("Registro da Compra não foi encontrado...")
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- VERIFICA MOVIMENTACAO ANTES DE EXCLUIR
        If Not VerificaLiberacaoCompra(clCmp, "EXCLUIR") Then
            Return False
        End If
        '
        '--- GET ITEMS COMPRA
        '==================================================================
        '
        '--- INFO
        Info.InfoShow("Obtendo os items da Compra")
        '
        '--- get produtos | itens da COMPRA
        Dim ItemBLL As New TransacaoItemBLL
        Dim lstItens As New List(Of clTransacaoItem)
        '
        Try
            '--- get COMPRA ITENS
            lstItens = ItemBLL.GetTransacaoItens_List(IDCompra, IDFilial)
            '
        Catch ex As Exception
            '
            Throw ex
            Return False
            '
        End Try
        '
        '--- INIT TRANSACTION
        '==================================================================
        Dim ObjDB As New AcessoDados
        ObjDB.BeginTransaction()
        '
        '--- DELETE ALL ITENS OF COMPRA AND RESOLVE ESTOQUE
        '==================================================================
        '
        '--- INFO
        Info.InfoShow("Excluíndo os items da Compra")
        '
        '--- delete all itens of COMPRA
        Try
            '
            For Each it In lstItens
                ItemBLL.ExcluirItem(it, TransacaoItemBLL.EnumMovimento.ENTRADA, ObjDB)
            Next
            '
        Catch ex As Exception
            '
            ObjDB.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '--- DELETE ALL APAGAR | MOVIMENTACOES OF COMPRA
        '==================================================================
        '
        '--- INFO
        Info.InfoShow("Excluíndo o A Pagar da Compra")
        '
        '--- GET IDAPagar vinculado a Compra
        Try
            Dim pBLL As New APagarBLL
            '
            '--- DELETA APAGAR
            pBLL.APagarDeletePorOrigem(IDCompra, clAPagar.Origem_APagar.Compra, False, ObjDB)
            '
        Catch ex As Exception
            '
            ObjDB.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '--- DELETE APAGAR OF THE TBLVENDAFRETE RELATED
        '==================================================================
        '
        '--- FRETE -> APAGAR -> MOVIMENTACAO | FRETE -> APAGAR
        If Not IsNothing(clCmp.IDFreteDespesa) Then
            '
            Try
                Dim fBLL As New FreteBLL
                fBLL.FreteDespesaDelete(clCmp.IDFreteDespesa, ObjDB)
                '
            Catch ex As Exception
                '
                ObjDB.RollBackTransaction()
                Throw ex
                Return False
                '
            End Try
            '
        End If
        '
        '--- DELETE FRETE
        '
        '--- INFO
        Info.InfoShow("Excluíndo os fretes da Compra")
        '
        Try
            '
            ObjDB.LimparParametros()
            ObjDB.AdicionarParametros("@IDCompra", clCmp.IDCompra)
            '
            myQuery = "DELETE tblFrete WHERE IDTransacao = @IDCompra"
            '
            ObjDB.ExecutarManipulacao(CommandType.Text, myQuery)
            '
        Catch ex As Exception
            '
            ObjDB.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '--- DELETE NOTAS IF NECESSITY
        '==================================================================
        '
        '--- INFO
        Info.InfoShow("Excluíndo as NFe da Compra")
        '
        Try
            '
            ObjDB.LimparParametros()
            ObjDB.AdicionarParametros("@IDCompra", clCmp.IDCompra)
            '
            myQuery = "DELETE FROM tblTransacaoNotaFiscal WHERE IDTransacao = @IDCompra"
            '
            ObjDB.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            '
            ObjDB.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '--- REMOVE ALL REFERENCES OF COMPRA IN TBLPRODUTOFORNECEDOR
        '==================================================================
        '
        '--- INFO
        Info.InfoShow("Excluíndo as referências ao Fornecedor da Compra")
        '
        Try
            '
            ObjDB.LimparParametros()
            ObjDB.AdicionarParametros("@IDTransacao", clCmp.IDCompra)
            '
            myQuery = "UPDATE tblProdutoFornecedor SET IDTransacao = NULL WHERE IDTransacao = @IDTransacao"
            '
            ObjDB.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            '
            ObjDB.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '--- DELETE COMPRA
        '==================================================================
        '
        '--- INFO
        Info.InfoShow("Excluíndo a Transação de Compra")
        '
        Try
            '
            ObjDB.LimparParametros()
            ObjDB.AdicionarParametros("@IDCompra", clCmp.IDCompra)
            '
            myQuery = "DELETE FROM tblCompra WHERE IDCompra = @IDCompra"
            '
            ObjDB.ExecutarManipulacao(CommandType.Text, myQuery)
            '
        Catch ex As Exception
            '
            ObjDB.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '
        '--- FINNALY - DELETE TRANSACTION AND COMMIT
        '==================================================================
        Try
            '
            ObjDB.LimparParametros()
            ObjDB.AdicionarParametros("@IDTransacao", clCmp.IDCompra)
            '
            myQuery = "DELETE FROM tblTransacao WHERE IDTransacao = @IDTransacao"
            '
            ObjDB.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            ' COMMIT TRANSACTION
            ObjDB.CommitTransaction()
            Return True
            '
        Catch ex As Exception
            '
            ObjDB.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' VERIFICA AS LIGACOES ANTES DE EXCLUIR UMA COMPRA
    '--------------------------------------------------------------------------------------------
    Private Function VerificaLiberacaoCompra(clCmp As clCompra, Acao As String) As Boolean
        '
        Dim myQuery As String
        Dim SQL As New SQLControl
        '
        '--- VERIFY ESTOQUE | TBLMOVIMENTACAO | SAIDAS | PAGAMENTOS
        '------------------------------------------------------------------
        '--- 1 - Compra => APagar => Movimentacoes
        '--- 2 - Compra => Frete  => APagar => Movimentacoes
        '--- 3 - Compra => Itens  => Estoque
        '==================================================================
        '
        '
        ' 1. --- verifica movimentacao de entrada da Compra antes de excluir
        ' ORIGEM = 1 ( TBLTRANSACAO | TBLCOMPRA )
        Try
            SQL.ClearParams()
            SQL.AddParam("@IDCompra", clCmp.IDCompra)
            '
            myQuery = "SELECT COUNT(*) FROM tblCaixaMovimentacao " &
                      "WHERE Origem = 10 AND NOT IDCaixa IS NULL " &
                      "AND IDOrigem IN (SELECT IDAPagar FROM tblAPagar WHERE Origem = 1 AND IDOrigem = @IDCompra)"
            '
            '--- execute query
            SQL.ExecQuery(myQuery)
            '
            '--- verify error
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
                Return False
            End If
            '
            '--- get count of data returned
            Dim quant As Integer = SQL.DBDT.Rows(0).Item(0)
            '
            If quant > 0 Then
                Throw New Exception("Não é possível " & Acao & " uma Compra que possui " &
                                    "débitos/pagamentos que já foram incluídos em um caixa...")
                Return False
            End If
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '
        ' 2. --- verifica movimentacao de saida do frete antes de excluir
        ' FRETE => TBLAPAGAR => TBLMOVIMENTACAO
        If IsNothing(clCmp.IDFreteDespesa) Then Return True
        '
        Try
            '
            SQL.ClearParams()
            SQL.AddParam("@IDAPagar", clCmp.IDFreteDespesa)
            '
            myQuery = "SELECT COUNT(*) FROM tblCaixaMovimentacao
                       WHERE Origem = 10 AND IDOrigem = @IDAPagar AND NOT IDCaixa IS NULL"
            '
            '--- execute query
            SQL.ExecQuery(myQuery)
            '
            '--- verify error
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
                Return False
            End If
            '
            '--- get count of data returned
            Dim quant As Integer = SQL.DBDT.Rows(0).Item(0)
            '
            If quant > 0 Then
                Throw New Exception("Não é possível " & Acao & " uma Compra que possui " &
                                    "saidas/pagamentos de FRETE que já foram incluídos em um caixa...")
                Return False
            End If
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '
        ' 3. --- verifica estoque negativo before DELETE
        ' ( TBLESTOQUE | TBLITENS )
        '
        If Acao.ToUpper <> "EXCLUIR" Then Return True '--> somente verifica ESTOQUE caso for EXCLUIR
        '
        Try
            '
            SQL.ClearParams()
            SQL.AddParam("@IDTransacao", clCmp.IDCompra)
            '
            myQuery = "SELECT COUNT(*) AS Quant
                      FROM tblTransacaoItens AS I
                      JOIN tblTransacao AS T ON T.IDTransacao = I.IDTransacao
                      JOIN tblEstoque AS E ON E.IDFilial = T.IDPessoaDestino AND E.IDProduto = I.IDProduto
                      WHERE I.IDTransacao = @IDTransacao AND E.Quantidade - I.Quantidade < 0"
            '
            '--- execute query
            SQL.ExecQuery(myQuery)
            '
            '--- verify error
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
                Return False
            End If
            '
            '--- get count of data returned
            Dim Quant As Integer = SQL.DBDT.Rows(0).Item(0)
            '
            If Quant > 0 Then
                Throw New Exception("Não é possível " & Acao & " uma Compra que possui " &
                                    "items que se forem removidos farão com que o ESTOQUE se torne negativo...")
                Return False
            End If
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- RETORNA
        Return True
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' CONVERT DATAROW DA DATATABLE COMPRA EM UM CLCOMPRA 
    '--------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_clCompra(r As DataRow) As clCompra
        '
        Dim cmp As clCompra = New clCompra
        '
        '--- TBLTRANSACAO
        cmp.IDCompra = IIf(IsDBNull(r("IDCompra")), Nothing, r("IDCompra"))
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
        '--- TBLCOMPRA
        cmp.CobrancaTipo = IIf(IsDBNull(r("CobrancaTipo")), Nothing, r("CobrancaTipo"))
        cmp.CobrancaTipoTexto = IIf(IsDBNull(r("CobrancaTipoTexto")), String.Empty, r("CobrancaTipoTexto"))
        cmp.FreteTipo = IIf(IsDBNull(r("FreteTipo")), Nothing, r("FreteTipo"))
        cmp.FreteCobrado = IIf(IsDBNull(r("FreteCobrado")), Nothing, r("FreteCobrado"))
        cmp.ICMSValor = IIf(IsDBNull(r("ICMSValor")), Nothing, r("ICMSValor"))
        cmp.Despesas = IIf(IsDBNull(r("Despesas")), Nothing, r("Despesas"))
        cmp.Descontos = IIf(IsDBNull(r("Descontos")), Nothing, r("Descontos"))
        cmp.TotalCompra = IIf(IsDBNull(r("Totalcompra")), Nothing, r("Totalcompra"))
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
    '--------------------------------------------------------------------------------------------
    ' GET LISTA COMPRA PARA FRMPROCURA
    '--------------------------------------------------------------------------------------------
    Public Function GetCompraLista_Procura(IDFilial As Integer,
                                           Optional dtInicial As Date? = Nothing,
                                           Optional dtFinal As Date? = Nothing) As List(Of clCompra)
        '
        Dim sql As New SQLControl
        '
        sql.AddParam("@IDFilial", IDFilial)
        Dim myQuery As String = "SELECT * FROM qryCompra WHERE IDPessoaDestino = @IDFilial"
        '
        If Not IsNothing(dtInicial) Then
            '
            sql.AddParam("@DataInicial", dtInicial)
            myQuery = myQuery & " AND TransacaoData >= @DataInicial"
            '
        End If
        '
        If Not IsNothing(dtFinal) Then
            '
            sql.AddParam("@DataFinal", dtFinal)
            myQuery = myQuery & " AND TransacaoData <= @DataFinal"
            '
        End If
        '
        Try
            Dim cmpList As New List(Of clCompra)
            '
            sql.ExecQuery(myQuery)
            '
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            If sql.DBDT.Rows.Count = 0 Then Return cmpList
            '
            For Each r As DataRow In sql.DBDT.Rows
                Dim cmp As New clCompra
                '
                cmp = ConvertDtRow_clCompra(r)
                '
                cmpList.Add(cmp)
                '
            Next
            '
            Return cmpList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' EFETUA O RATEIO DO FRETE NOS ITENS DA COMPRA E REGISTRA O FORNECEDOR DOS PRODUTOS
    '--------------------------------------------------------------------------------------------
    Public Function CompraFinalizar(IDTransacao As Integer,
                                    TransacaoData As Date,
                                    IDFornecedor As Integer,
                                    FreteValor As Decimal,
                                    TotalProdutos As Decimal) As Integer?
        '
        Dim objdb As New AcessoDados
        '
        '--- limpar os parâmetros
        objdb.LimparParametros()
        '--- adicionar os parâmetros
        objdb.AdicionarParametros("@IDTransacao", IDTransacao)
        objdb.AdicionarParametros("@TransacaoData", TransacaoData)
        objdb.AdicionarParametros("@IDFornecedor", IDFornecedor)
        objdb.AdicionarParametros("@FreteValor", FreteValor)
        objdb.AdicionarParametros("@TotalProdutos", TotalProdutos)
        '
        Try
            Dim obj As Object
            '
            obj = objdb.ExecutarManipulacao(CommandType.StoredProcedure, "uspCompraFinalizar")
            '
            '--- verifica o resultado
            If Not IsNothing(obj) AndAlso IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If

        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
