Imports CamadaDTO
Imports CamadaDAL
'
Public Class DevolucaoSaidaBLL
    '
    '===========================================================================--
    ' GET LIST COM WHERE
    '===========================================================================--
    Public Function GetDevolucao_List(Optional myWhere As String = "") As List(Of clDevolucaoSaida)
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryDevolucaoSaida"
        Else
            strSql = "SELECT * FROM qryDevolucaoSaida WHERE " & myWhere
        End If
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            Dim lista As New List(Of clDevolucaoSaida)
            '
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each r As DataRow In dt.Rows
                Dim vnd As clDevolucaoSaida = ConvertDtRow_clDevolucao(r)
                lista.Add(vnd)
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
    '==============================================================================
    ' GET REGISTRO POR ID/RG
    '==============================================================================
    Public Function GetDevolucao_PorID(IDDevolucao As Integer) As clDevolucaoSaida
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        objdb.LimparParametros()
        objdb.AdicionarParametros("@IDDevolucao", IDDevolucao)
        '
        strSql = "SELECT * FROM qryDevolucaoSaida WHERE IDDevolucao = @IDDevolucao"
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            Dim r As DataRow = Nothing
            '
            If dt.Rows.Count > 0 Then
                r = dt.Rows(0)
                Return ConvertDtRow_clDevolucao(r)
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
    '=============================================================================
    ' UPDATE
    '=============================================================================
    Public Function Update_Devolucao(_dev As clDevolucaoSaida,
                                     Optional myDB As Object = Nothing) As Boolean
        '
        Dim objDB As AcessoDados
        Dim TranLocal As Boolean = True
        '
        If IsNothing(myDB) Then
            objDB = New AcessoDados
            objDB.BeginTransaction()
        Else
            objDB = myDB
            TranLocal = False
        End If
        '
        Dim myQuery As String = ""
        '
        '--- 1. UPDATE TBLTRANSACAO
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLTRANSACAO
        objDB.AdicionarParametros("@IDDevolucao", _dev.IDDevolucao)
        objDB.AdicionarParametros("@IDPessoaDestino", _dev.IDPessoaDestino)
        objDB.AdicionarParametros("@IDSituacao", _dev.IDSituacao)
        objDB.AdicionarParametros("@TransacaoData", _dev.TransacaoData)
        '
        myQuery = "UPDATE tblTransacao " &
                  "SET IDPessoaDestino = @IDPessoaDestino, " &
                  "IDSituacao = @IDSituacao, " &
                  "TransacaoData = @TransacaoData " &
                  "WHERE IDTransacao = @IDDevolucao"
        '
        Try
            objDB.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            If TranLocal Then objDB.RollBackTransaction()
            Throw ex
            Return False
        End Try
        '
        '--- 2. UPDATE TBLDEVOLUCAO
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLDEVOLUCAO
        objDB.AdicionarParametros("@IDDevolucao", _dev.IDDevolucao)
        objDB.AdicionarParametros("@ValorProdutos", _dev.ValorProdutos)
        objDB.AdicionarParametros("@ValorAcrescimos", _dev.ValorAcrescimos)
        objDB.AdicionarParametros("@ValorDescontos", _dev.ValorDescontos)
        objDB.AdicionarParametros("@ValorTotal", _dev.ValorTotal)
        objDB.AdicionarParametros("@Enviada", _dev.Enviada)
        objDB.AdicionarParametros("@Creditada", _dev.Creditada)
        '
        myQuery = "UPDATE tblDevolucaoSaida " &
                  "SET ValorProdutos = @ValorProdutos, " &
                  "ValorAcrescimos = @ValorAcrescimos, " &
                  "ValorDescontos = @ValorDescontos, " &
                  "TotalDevolucao = @ValorTotal, " &
                  "Enviada = @Enviada, " &
                  "Creditada = @Creditada " &
                  "WHERE IDDevolucao = @IDDevolucao"
        '
        Try
            objDB.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            If TranLocal Then objDB.RollBackTransaction()
            Throw ex
            Return False
        End Try
        '
        '--- 3. UPDATE TBLOBSERVACAO
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        Try
            '
            Dim oBLL As New ObservacaoBLL
            oBLL.SaveObservacao(12, _dev.IDDevolucao, _dev.Observacao, objDB)
            '
        Catch ex As Exception
            If TranLocal Then objDB.RollBackTransaction()
            Throw ex
            Return False
        End Try
        '
        '--- 4. UPDATE TBLVENDAFRETE
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        ' Verifica IDAPagar no FRETE
        If IsNothing(_dev.IDApagar) Then
            '
            Try
                'Delete Frete Anterior caso houver
                myQuery = "DELETE tblFrete WHERE IDTransacao = " & _dev.IDDevolucao
                objDB.ExecutarManipulacao(CommandType.Text, myQuery)
                '
                '--- Insert if exist
                If _dev.FreteTipo <> 0 Then
                    '
                    '-- PARAMETROS DA TBLVENDAFRETE
                    objDB.AdicionarParametros("@IDDevolucao", _dev.IDDevolucao)
                    objDB.AdicionarParametros("@IDTransportadora", _dev.IDTransportadora)
                    objDB.AdicionarParametros("@FreteTipo", _dev.FreteTipo)
                    objDB.AdicionarParametros("@FreteValor", _dev.FreteValor)
                    objDB.AdicionarParametros("@Volumes", _dev.Volumes)
                    '
                    myQuery = "INSERT INTO tblFrete " &
                              "(IDTransacao, IDTransportadora, FreteTipo, FreteValor, Volumes) " &
                              "VALUES " &
                              "(@IDDevolucao, @IDTransportadora, @FreteTipo, @FreteValor, @Volumes)"
                    '
                    objDB.ExecutarManipulacao(CommandType.Text, myQuery)
                    '
                End If
                '
            Catch ex As Exception
                If TranLocal Then objDB.RollBackTransaction()
                Throw ex
                Return False
            End Try
            '
        End If
        '
        '--- 5. FINALIZA
        '--------------------------------------------------------------------------------------
        If TranLocal Then objDB.CommitTransaction()
        Return True
        '
    End Function
    '
    '=============================================================================
    ' INSERT NOVA DEVOLUCAO E RETORNA UMA CLDEVOLUCAO
    '=============================================================================
    Public Function Insert_Devolucao(_dev As clDevolucaoSaida) As clDevolucaoSaida
        '
        Dim objDB As New AcessoDados
        objDB.BeginTransaction()
        '
        Dim myQuery As String = ""
        Dim newID As Integer
        Dim newIDAReceber As Integer
        '
        '--- 1. INSERT TBLTRANSACAO
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLTRANSACAO
        objDB.AdicionarParametros("@IDPessoaOrigem", _dev.IDPessoaOrigem) '@IDPessoaOrigem AS INT, x
        objDB.AdicionarParametros("@IDPessoaDestino", _dev.IDPessoaDestino)
        objDB.AdicionarParametros("@IDOperacao", _dev.IDOperacao)
        objDB.AdicionarParametros("@IDSituacao", _dev.IDSituacao)
        objDB.AdicionarParametros("@TransacaoData", _dev.TransacaoData)
        objDB.AdicionarParametros("@CFOP", _dev.CFOP) '@CFOP AS INT(16), x
        objDB.AdicionarParametros("@IDUser", _dev.IDUser) '@IDUser AS INT, x
        '
        myQuery = "INSERT INTO tblTransacao (" &
                  "IDPessoaOrigem, IDPessoaDestino, IDOperacao, IDSituacao, TransacaoData, CFOP, IDUser ) " &
                  "VALUES (" &
                  "@IDPessoaOrigem, @IDPessoaDestino, 6, 1, @TransacaoData, @CFOP, @IDUser )"
        '
        Try
            objDB.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- obter NewID
            objDB.LimparParametros()
            myQuery = "SELECT @@IDENTITY As LastID;"
            Dim dt As DataTable = objDB.ExecutarConsulta(CommandType.Text, myQuery)
            '
            newID = dt.Rows(0)(0)
            '
        Catch ex As Exception
            objDB.RollBackTransaction()
            Throw ex
        End Try
        '
        '--- 2. INSERT TBLARECEBER
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLDEVOLUCAO
        objDB.AdicionarParametros("@IDDevolucao", newID)
        objDB.AdicionarParametros("@IDFilial", _dev.IDPessoaOrigem)
        objDB.AdicionarParametros("@IDPessoa", _dev.IDPessoaDestino)
        '
        myQuery = "INSERT INTO tblAReceber
			      (IDOrigem, Origem, IDFilial, IDPessoa, AReceberValor, ValorPagoTotal, SituacaoAReceber)
			      VALUES
			      (@IDDevolucao, 4, @IDFilial, @IDPessoa, 0, 0, 0)"
        '
        Try
            objDB.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- obter NewID
            objDB.LimparParametros()
            myQuery = "SELECT @@IDENTITY As LastID;"
            Dim dt As DataTable = objDB.ExecutarConsulta(CommandType.Text, myQuery)
            '
            newIDAReceber = dt.Rows(0)(0)
            '
        Catch ex As Exception
            objDB.RollBackTransaction()
            Throw ex
        End Try
        '
        '--- 3. INSERT TBLDEVOLUCAO
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLDEVOLUCAO
        objDB.AdicionarParametros("@IDDevolucao", newID)
        objDB.AdicionarParametros("@IDAReceber", newIDAReceber)
        '
        myQuery = "INSERT INTO tblDevolucaoSaida (" &
                  "IDDevolucao, IDAReceber, ValorProdutos, ValorAcrescimos, " &
                  "ValorDescontos, TotalDevolucao, Enviada, Creditada) " &
                  "VALUES( " &
                  "@IDDevolucao, @IDAReceber, 0, 0, 0, 0, 0, 0)"
        '
        Try
            objDB.ExecutarManipulacao(CommandType.Text, myQuery)
            objDB.CommitTransaction()
        Catch ex As Exception
            objDB.RollBackTransaction()
            Throw ex
        End Try
        '
        '--- 4. RETURN
        '--------------------------------------------------------------------------------------
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLDEVOLUCAO
        objDB.AdicionarParametros("@IDDevolucao", newID)
        '
        myQuery = "SELECT * FROM qryDevolucaoSaida WHERE IDDevolucao = @IDDevolucao"
        '
        Try
            Dim myDT As DataTable = objDB.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If myDT.Rows.Count > 0 Then
                Return ConvertDtRow_clDevolucao(myDT.Rows(0))
            Else
                Throw New Exception("Não foi retornado nenhum valor, o registro não foi inserido...")
            End If
            '
        Catch ex As Exception
            objDB.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
    '===========================================================================--
    ' DELETE DEVOLUCAO POR IDDEVOLUCAO
    '===========================================================================--
    Public Function DeletaDevolucaoPorID(IDDevolucao As Integer, IDFilial As Integer) As Boolean
        '
        Dim clDev As clDevolucaoSaida = Nothing
        Dim myQuery As String = ""
        '
        '--- OBTEM O clDev
        '=======================================================
        Try
            clDev = GetDevolucao_PorID(IDDevolucao)
            '
            If IsNothing(clDev) Then Throw New Exception("Registro da Devolucao não foi encontrado...")
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- VERIFICA MOVIMENTACAO ANTES DE EXCLUIR
        If Not VerificaLiberacaoDevolucao(clDev, "EXCLUIR") Then
            Return False
        End If
        '
        '--- GET ITEMS DEVOLUCAO
        '==================================================================
        '
        '--- get produtos | itens da DEVOLUCAO
        Dim ItemBLL As New TransacaoItemBLL
        Dim lstItens As New List(Of clTransacaoItem)
        '
        Try
            '--- get DEVOLUCAO ITENS
            lstItens = ItemBLL.GetTransacaoItens_List(IDDevolucao, IDFilial)
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
        '--- DELETE ALL ITENS OF DEVOLUCAO AND RESOLVE ESTOQUE
        '==================================================================
        '
        '--- delete all itens of DEVOLUCAO
        Try
            '
            For Each it In lstItens
                ItemBLL.ExcluirItem(it, TransacaoItemBLL.EnumMovimento.SAIDA, ObjDB)
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
        '--- DELETE ALL ARECEBER | PARCELAS | MOVIMENTACOES OF VENDA
        '==================================================================
        '
        '--- GET IDAReceber vinculado a DEVOLUCAO
        Try
            '
            '--- if IDARECEBER NOT NOTHING
            If Not IsNothing(clDev.IDAReceber) Then
                Dim rBLL As New AReceberBLL
                '
                '--- DELETA ARECEBER
                rBLL.Excluir_AReceber_Transacao(IDDevolucao, clAReceber.EnumAReceberOrigem.DevolucaoSaida, ObjDB)
                '
            End If
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
        If Not IsNothing(clDev.IDApagar) Then
            '
            Try
                '
                '--- DELETE MOVIMENTACOES DE FRETE
                ObjDB.LimparParametros()
                ObjDB.AdicionarParametros("@IDAPagar", clDev.IDApagar)
                '
                myQuery = "DELETE FROM tblCaixaMovimentacao WHERE Origem = 10 AND IDOrigem = @IDAPagar"
                '
                ObjDB.ExecutarManipulacao(CommandType.Text, myQuery)
                '
                '--- DELETE A PAGAR DE FRETE
                ObjDB.LimparParametros()
                ObjDB.AdicionarParametros("@IDAPagar", clDev.IDApagar)
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
            ObjDB.AdicionarParametros("@IDTransacao", clDev.IDDevolucao)
            '
            myQuery = "DELETE tblFrete WHERE IDTransacao = @IDTransacao"
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
        '--- DELETE NOTAS IF NECESSITY
        '==================================================================
        Try
            '
            ObjDB.LimparParametros()
            ObjDB.AdicionarParametros("@IDTransacao", clDev.IDDevolucao)
            '
            myQuery = "DELETE FROM tblTransacaoNotaFiscal WHERE IDTransacao = @IDTransacao"
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
        '--- DELETE VENDA FINNALY AND COMMIT
        '==================================================================
        '
        Try
            '
            ObjDB.LimparParametros()
            ObjDB.AdicionarParametros("@IDDevolucao", clDev.IDDevolucao)
            '
            myQuery = "DELETE FROM tblDevolucaoSaida WHERE IDDevolucao = @IDDevolucao"
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
    '===========================================================================--
    ' VERIFICA AS LIGACOES ANTES DE EXCLUIR UMA DEVOLUCAO
    '===========================================================================--
    Private Function VerificaLiberacaoDevolucao(clDev As clDevolucaoSaida, Acao As String) As Boolean
        '
        Dim myQuery As String
        Dim SQL As New SQLControl
        '
        '--- VERIFY TBLMOVIMENTACAO | ENTRADAS | RECEBIMENTOS
        '=======================================================
        '--- 1 - Devolucao => AReceber => Movimentacoes
        '--- 2 - Devolucao => Frete => APagar => Movimentacoes
        '==================================================================
        '
        ' 1. --- verifica movimentacao de entrada da Devolucao antes de excluir
        ' ORIGEM = 1 ( TBLTRANSACAO | TBLDEVOLUCAO )
        Try
            SQL.ClearParams()
            SQL.AddParam("@IDDevolucao", clDev.IDDevolucao)
            '
            myQuery = "SELECT COUNT(*) FROM tblCaixaMovimentacao
                       WHERE Origem = 1 AND IDOrigem = @IDDevolucao AND NOT IDCaixa IS NULL"
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
                Throw New Exception("Não é possível " & Acao & " uma Devolucao que possui " &
                                    "entradas/recebimentos que já foram incluídos em um caixa...")
                Return False
            End If
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        ' 2. --- verifica movimentacao de saida do frete antes de excluir
        ' FRETE => TBLAPAGAR => TBLMOVIMENTACAO
        '
        If IsNothing(clDev.IDApagar) Then Return True
        '
        Try
            '
            SQL.ClearParams()
            SQL.AddParam("@IDAPagar", clDev.IDApagar)
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
                Throw New Exception("Não é possível " & Acao & " uma Devolucao que possui " &
                                    "saidas/pagamentos de FRETE que já foram incluídos em um caixa...")
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
    '=============================================================================
    ' DESBLOQUEIA UMA DEVOLUCAO BLOQUEADA
    '=============================================================================
    Public Function DevolucaoDesbloquear(myDev As clDevolucaoSaida) As Boolean
        '
        If Not VerificaLiberacaoDevolucao(myDev, "DESBLOQUEAR") Then Return False
        '
        Try
            '--- altera a situacao da transacao atual
            myDev.IDSituacao = 2 'VENDA CONCLUÍDA
            '
            Dim obj As Object = Update_Devolucao(myDev)
            '
            If Not IsNumeric(obj) Then
                myDev.IDSituacao = 3
                Throw New Exception(obj.ToString)
            End If
            '
            Return True
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
    End Function
    '
    '===========================================================================--
    ' CONVERT DATAROW DA DATATABLE DEVOLUCAO EM UMA CLDEVOLUCAO 
    '===========================================================================--
    Private Function ConvertDtRow_clDevolucao(r As DataRow) As clDevolucaoSaida
        '
        Dim dev As New clDevolucaoSaida
        '
        '--- tblDevolucaoSaida
        '-----------------------------------------------------------------------------------------------
        dev.IDDevolucao = IIf(IsDBNull(r("IDDevolucao")), Nothing, r("IDDevolucao"))
        dev.ValorProdutos = IIf(IsDBNull(r("ValorProdutos")), 0, r("ValorProdutos"))
        dev.ValorDescontos = IIf(IsDBNull(r("ValorDescontos")), 0, r("ValorDescontos"))
        dev.ValorAcrescimos = IIf(IsDBNull(r("ValorAcrescimos")), 0, r("ValorAcrescimos"))
        dev.Enviada = IIf(IsDBNull(r("Enviada")), Nothing, r("Enviada"))
        dev.Creditada = IIf(IsDBNull(r("Creditada")), Nothing, r("Creditada"))
        dev.IDAReceber = IIf(IsDBNull(r("IDAReceber")), Nothing, r("IDAReceber"))
        '
        '--- tblTransacao
        '-----------------------------------------------------------------------------------------------
        dev.IDPessoaDestino = IIf(IsDBNull(r("IDPessoaDestino")), Nothing, r("IDPessoaDestino"))
        dev.IDPessoaOrigem = IIf(IsDBNull(r("IDPessoaOrigem")), Nothing, r("IDPessoaOrigem"))
        dev.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
        dev.IDUser = IIf(IsDBNull(r("IDUser")), Nothing, r("IDUser"))
        dev.CFOP = IIf(IsDBNull(r("CFOP")), String.Empty, r("CFOP"))
        dev.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao"))
        dev.IDSituacao = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
        dev.Situacao = IIf(IsDBNull(r("Situacao")), String.Empty, r("Situacao"))
        dev.TransacaoData = IIf(IsDBNull(r("TransacaoData")), Nothing, r("TransacaoData"))
        '
        '--- qryPessoaFisicaJuridica
        '-----------------------------------------------------------------------------------------------
        dev.Fornecedor = IIf(IsDBNull(r("Fornecedor")), String.Empty, r("Fornecedor"))
        dev.CNP = IIf(IsDBNull(r("CNP")), String.Empty, r("CNP"))
        dev.UF = IIf(IsDBNull(r("UF")), String.Empty, r("UF"))
        dev.Cidade = IIf(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
        dev.Transportadora = IIf(IsDBNull(r("Transportadora")), String.Empty, r("Transportadora"))
        '
        '--- Dados do tblObservacao
        dev.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        '
        '--- Dados do tblAReceber
        dev.SituacaoAReceber = IIf(IsDBNull(r("SituacaoAReceber")), Nothing, r("SituacaoAReceber"))
        dev.ValorPagoTotal = IIf(IsDBNull(r("ValorPagoTotal")), Nothing, r("ValorPagoTotal"))
        '
        '--- Dados da tblFrete
        dev.IDTransportadora = IIf(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora"))
        dev.FreteTipo = IIf(IsDBNull(r("FreteTipo")), Nothing, r("FreteTipo"))
        dev.FreteValor = IIf(IsDBNull(r("FreteValor")), Nothing, r("FreteValor"))
        dev.Volumes = IIf(IsDBNull(r("Volumes")), Nothing, r("Volumes"))
        dev.IDApagar = IIf(IsDBNull(r("IDApagar")), Nothing, r("IDApagar"))
        '
        Return dev
        '
    End Function
    '
    '===========================================================================--
    ' GET LISTA DEVOLUCAO PARA FRMPROCURA RETORNA LIST OF CLDEVOLUCAOSAIDA
    '===========================================================================--
    Public Function GetDevolucaoLista_Procura(IDFilial As Integer,
                                              Optional dtInicial As Date? = Nothing,
                                              Optional dtFinal As Date? = Nothing) As List(Of clDevolucaoSaida)
        '
        Dim sql As New SQLControl
        '
        sql.AddParam("@IDFilial", IDFilial)
        Dim myQuery As String = "SELECT * FROM qryDevolucaoSaida WHERE IDPessoaOrigem = @IDFilial"
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
            Dim devList As New List(Of clDevolucaoSaida)
            '
            sql.ExecQuery(myQuery)
            '
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            If sql.DBDT.Rows.Count = 0 Then Return devList
            '
            For Each r As DataRow In sql.DBDT.Rows
                Dim dev As New clDevolucaoSaida
                '
                dev = ConvertDtRow_clDevolucao(r)
                '
                devList.Add(dev)
                '
            Next
            '
            Return devList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
