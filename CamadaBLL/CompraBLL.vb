Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient

Public Class CompraBLL
    '
    '--------------------------------------------------------------------------------------------
    ' GET DATATABLE COM WHERE
    '--------------------------------------------------------------------------------------------
    Public Function GetCompra_DT(Optional myWhere As String = "") As DataTable
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
            dt = objdb.ExecuteConsultaSQL_DataTable(strSql)
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
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryCompra"
        Else
            strSql = "SELECT * FROM qryCompra WHERE " & myWhere
        End If
        '
        Try
            Dim dt As DataTable = objdb.ExecuteConsultaSQL_DataTable(strSql)
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
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        strSql = "SELECT * FROM qryCompra WHERE IDCompra = " & myIDCompra
        '
        Try
            Dim dt As DataTable = objdb.ExecuteConsultaSQL_DataTable(strSql)
            Dim r As DataRow = Nothing
            '
            If dt.Rows.Count > 0 Then
                r = dt.Rows(0)
                Return ConvertDtRow_clCompra(r)
            Else
                Return Nothing
            End If
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
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand
        '
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLTRANSACAO
        '@IDcompra AS INT
        objDB.AdicionarParametros("@IDcompra", _compra.IDCompra)
        '@IDPessoaDestino AS INT, 
        objDB.AdicionarParametros("@IDPessoaDestino", _compra.IDPessoaDestino)
        '@IDPessoaOrigem AS INT, 
        objDB.AdicionarParametros("@IDPessoaOrigem", _compra.IDPessoaOrigem)
        '@IDOperacao AS BYTE, 
        objDB.AdicionarParametros("@IDOperacao", _compra.IDOperacao)
        '@IDSituacao AS TINYINT = 0, --0|INSERIDA ; 1|VERIFICADA ; 2|FECHADA 
        objDB.AdicionarParametros("@IDSituacao", _compra.IDSituacao)
        '@IDUser AS INT,
        objDB.AdicionarParametros("@IDUser", _compra.IDUser)
        '@CFOP AS INT(16), 
        objDB.AdicionarParametros("@CFOP", _compra.CFOP)
        '@compraData AS SMALLDATETIME, 
        objDB.AdicionarParametros("@TransacaoData", _compra.TransacaoData)
        '
        '-- PARAMETROS DA TBLCompra
        objDB.AdicionarParametros("@FreteCobrado", _compra.FreteCobrado)
        objDB.AdicionarParametros("@ICMSValor", _compra.ICMSValor)
        objDB.AdicionarParametros("@Despesas", _compra.Despesas)
        objDB.AdicionarParametros("@Descontos", _compra.Descontos)
        objDB.AdicionarParametros("@CobrancaTipo", _compra.CobrancaTipo)
        objDB.AdicionarParametros("@TotalCompra", _compra.TotalCompra)
        '
        '-- PARAMETROS DA TBLOBSERVACAO
        '@Observacao AS VARCHAR(max) = null, 
        objDB.AdicionarParametros("@Observacao", _compra.Observacao)
        '
        '-- PARAMETROS DA TBLFRETE
        '@IDTransportadora AS INT = NULL,
        objDB.AdicionarParametros("@IDTransportadora", _compra.IDTransportadora)
        '@FreteValor AS MONEY = 0,
        objDB.AdicionarParametros("@FreteValor", _compra.FreteValor)
        objDB.AdicionarParametros("@FreteTipo", _compra.FreteTipo) '-- 0|SEM FRETE ; 1|EMITENTE; 2|DESTINATARIO
        '@Volumes AS SMALLINT = 1,
        objDB.AdicionarParametros("@Volumes", _compra.Volumes)
        '@IDAPagar AS INT = NULL
        objDB.AdicionarParametros("@IDFreteDespesa", _compra.IDFreteDespesa)
        '
        '
        Try
            Return objDB.ExecutarManipulacao(CommandType.StoredProcedure, "uspCompra_Alterar")
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
    Public Function SalvaNovaCompra_Procedure_Compra(ByVal _compra As clCompra) As clCompra
        Try
            Dim dtCompra As DataTable
            '
            dtCompra = SalvaNovaCompra_Procedure_DT(_compra)
            If dtCompra.Rows.Count > 0 Then
                Dim r As DataRow = dtCompra(0)
                '
                Return ConvertDtRow_clCompra(r)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' INSERT NOVA COMPRA E RETORNA UM DATATABLE
    '--------------------------------------------------------------------------------------------
    Public Function SalvaNovaCompra_Procedure_DT(ByVal _compra As clCompra) As DataTable
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand
        '
        'Adiciona os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLTRANSACAO
        objDB.AdicionarParametros("@IDPessoaDestino", _compra.IDPessoaDestino)
        objDB.AdicionarParametros("@IDPessoaOrigem", _compra.IDPessoaOrigem)
        objDB.AdicionarParametros("@IDOperacao", _compra.IDOperacao)
        objDB.AdicionarParametros("@IDSituacao", _compra.IDSituacao)
        objDB.AdicionarParametros("@IDUser", _compra.IDUser)
        objDB.AdicionarParametros("@CFOP", _compra.CFOP)
        objDB.AdicionarParametros("@TransacaoData", _compra.TransacaoData)
        '
        '-- PARAMETROS DA TBLCompra
        'objDB.AdicionarParametros("@FreteTipo", _compra.FreteTipo) '-- 0|SEM FRETE ; 1|EMITENTE; 2|DESTINATARIO; 3|REEMBOLSO ; 4|A COBRAR 
        'objDB.AdicionarParametros("@FreteCobrado", _compra.FreteCobrado)
        'objDB.AdicionarParametros("@ICMSValor", _compra.ICMSValor)
        'objDB.AdicionarParametros("@Despesas", _compra.Despesas)
        'objDB.AdicionarParametros("@Descontos", _compra.Descontos)
        'objDB.AdicionarParametros("@CobrancaTipo", _compra.CobrancaTipo)
        'objDB.AdicionarParametros("@TotalCompra", _compra.TotalCompra)
        '
        '-- PARAMETROS DA TBLOBSERVACAO
        'objDB.AdicionarParametros("@Observacao", _compra.Observacao)
        '
        '-- PARAMETROS DA TBLcompraFRETE
        'objDB.AdicionarParametros("@IDTransportadora", _compra.IDTransportadora)
        'objDB.AdicionarParametros("@FreteValor", _compra.FreteValor)
        'objDB.AdicionarParametros("@Volumes", _compra.Volumes)
        'objDB.AdicionarParametros("@IDAPagar", _compra.IDFreteDespesa)
        '
        Try
            Dim dtV As DataTable = objDB.ExecutarConsulta(CommandType.StoredProcedure, "uspCompra_Inserir")
            If dtV.Rows.Count = 0 Then
                Throw New Exception("Um erro inesperado ocorreu na uspCompra_Inserir")
            End If
            '
            If IsNumeric(dtV.Rows(0).Item(0)) Then
                Return dtV
            Else
                Throw New Exception(dtV.Rows(0).Item(0))
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' DELETE COMPRA POR IDCOMPRA
    '--------------------------------------------------------------------------------------------
    Public Function DeletaCompraPorID(IDCompra As Integer, IDFilial As Integer) As Boolean
        '
        Dim clCmp As clCompra = Nothing
        Dim myQuery As String = ""
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
        '--- GET IDAPagar vinculado a Compra
        Try
            Dim pBLL As New APagarBLL
            '
            '--- DELETA APAGAR
            pBLL.Excluir_APagar_Origem(IDCompra, clAPagar.Origem_APagar.Compra, ObjDB)
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

        Throw New Exception("INCOMPLETO")


        '
        '--- FRETE -> APAGAR -> MOVIMENTACAO | FRETE -> APAGAR
        If Not IsNothing(clCmp.IDFreteDespesa) Then
            '
            Try
                '
                '--- DELETE MOVIMENTACOES DE FRETE
                ObjDB.LimparParametros()
                ObjDB.AdicionarParametros("@IDAPagar", clCmp.IDFreteDespesa)
                '
                myQuery = "DELETE FROM tblMovimentacoes WHERE Origem = 10 AND IDOrigem = @IDAPagar"
                '
                ObjDB.ExecutarManipulacao(CommandType.Text, myQuery)
                '
                '--- DELETE A PAGAR DE FRETE
                ObjDB.LimparParametros()
                ObjDB.AdicionarParametros("@IDAPagar", clCmp.IDFreteDespesa)
                '
                myQuery = "DELETE FROM tblAPagar WHERE IDAPagar = @IDAPagar"
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
        End If
        '
        '--- DELETE FRETE
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
        '--- DELETE COMPRA FINNALY AND COMMIT
        '==================================================================
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
    ' EFETUA O RATEIO DO FRETE NOS ITENS DA COMPRA
    '--------------------------------------------------------------------------------------------
    Public Function CompraItens_ReteioFrete(IDCompra As Integer, FreteValor As Decimal, TotalProdutos As Decimal) As Integer?
        Dim objdb As New AcessoDados
        '
        '--- limpar os parâmetros
        objdb.LimparParametros()
        '--- adicionar os parâmetros
        objdb.AdicionarParametros("@IDCompra", IDCompra)
        objdb.AdicionarParametros("@FreteValor", FreteValor)
        objdb.AdicionarParametros("@TotalProdutos", TotalProdutos)
        '
        Try
            Dim obj As Object
            '
            obj = objdb.ExecutarManipulacao(CommandType.StoredProcedure, "uspCompraRatearFrete")
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
End Class
