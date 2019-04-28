Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient

Public Class SimplesMovimentacaoBLL
    '
    Private SQL As New SQLControl
    '
#Region "SIMPLES SAIDA"
    '
    '--------------------------------------------------------------------------------------------
    ' INSERT NOVA SIMPLES SAIDA E RETORNA UMA CLSIMPLESSAIDA
    '--------------------------------------------------------------------------------------------
    Public Function InsertSimplesSaida_Procedure_Classe(_simples As clSimplesSaida) As clSimplesSaida
        '
        Try
            Dim dtSimples As DataTable
            '
            dtSimples = InsertSimplesSaida_Procedure_DT(_simples)
            If dtSimples.Rows.Count > 0 Then
                Dim r As DataRow = dtSimples(0)
                '
                Return ConvertDtRow_clSimplesSaida(r)
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
    ' INSERT SIMPLES SAIDA E RETORNA UM DATATABLE
    '--------------------------------------------------------------------------------------------
    Public Function InsertSimplesSaida_Procedure_DT(ByVal _sim As clSimplesSaida) As DataTable
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand
        '
        'Adiciona os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLTRANSACAO
        '@IDPessoaDestino AS INT, x
        objDB.AdicionarParametros("@IDPessoaDestino", _sim.IDPessoaDestino)
        '@IDPessoaOrigem AS INT, x
        objDB.AdicionarParametros("@IDPessoaOrigem", _sim.IDPessoaOrigem)
        '@IDUser AS INT, x
        objDB.AdicionarParametros("@IDUser", _sim.IDUser)
        '@VendaData AS SMALLDATETIME, x
        objDB.AdicionarParametros("@TransacaoData", _sim.TransacaoData)
        '
        Try
            Dim dtV As DataTable = objDB.ExecutarConsulta(CommandType.StoredProcedure, "uspSimplesSaida_Inserir")
            If dtV.Rows.Count = 0 Then
                Throw New Exception("Um erro ineperado ocorreu na uspSimplesSaida_Inserir")
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
    ' UPDATE SIMPLES SAIDA E RETORNA UMA CLSIMPLESSAIDA
    '--------------------------------------------------------------------------------------------
    Public Function AtualizaSimplesSaida_Procedure_DT(ByVal _sim As clSimplesSaida) As Integer
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand
        '
        'Adiciona os Parâmetros
        objDB.LimparParametros()
        '
        '-- PARAMETROS DA TBLTRANSACAO
        objDB.AdicionarParametros("@IDTransacao", _sim.IDTransacao)
        objDB.AdicionarParametros("@IDPessoaDestino", _sim.IDPessoaDestino)
        objDB.AdicionarParametros("@IDPessoaOrigem", _sim.IDPessoaOrigem)
        objDB.AdicionarParametros("@IDSituacao", _sim.IDSituacao)
        objDB.AdicionarParametros("@IDUser", _sim.IDUser)
        objDB.AdicionarParametros("@TransacaoData", _sim.TransacaoData)
        objDB.AdicionarParametros("@ValorTotal", _sim.ValorTotal)
        objDB.AdicionarParametros("@Observacao", _sim.Observacao)
        objDB.AdicionarParametros("@IDPlano", _sim.IDPlano)
        objDB.AdicionarParametros("@ArquivoGerado", _sim.ArquivoGerado)
        objDB.AdicionarParametros("@ArquivoRecebido", _sim.ArquivoRecebido)
        '
        Try
            Dim dtV As DataTable = objDB.ExecutarConsulta(CommandType.StoredProcedure, "uspSimplesSaida_Alterar")
            If dtV.Rows.Count = 0 Then
                Throw New Exception("Um erro ineperado ocorreu na uspVenda_Inserir")
            End If
            '
            Dim obj As Object = dtV.Rows(0).Item(0)
            '
            If IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET SIMPLES SAIDA PELO ID RETORNA CL_SIMPLES_SAIDA
    '--------------------------------------------------------------------------------------------
    Public Function GetSimplesSaida_PorID(myID As Integer) As clSimplesSaida
        '
        SQL.AddParam("@IDTransacao", myID)
        Dim myQuery As String = "SELECT * FROM qrySimplesSaida WHERE IDTransacao = @IDTransacao"
        '
        Try
            SQL.ExecQuery(myQuery)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount > 0 Then
                Dim simples As clSimplesSaida = ConvertDtRow_clSimplesSaida(SQL.DBDT.Rows(0))
                '
                Return simples
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
    ' CONVERT DATAROW DA DATATABLE qrySimplesSaida EM UM clSimplesSaida
    '--------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_clSimplesSaida(r As DataRow) As clSimplesSaida
        '
        Dim sim As New clSimplesSaida
        '
        sim.IDTransacao = IIf(IsDBNull(r("IDTransacao")), Nothing, r("IDTransacao"))
        sim.ValorTotal = IIf(IsDBNull(r("ValorTotal")), 0, r("ValorTotal"))
        sim.ArquivoGerado = IIf(IsDBNull(r("ArquivoGerado")), Nothing, r("ArquivoGerado"))
        sim.ArquivoRecebido = IIf(IsDBNull(r("ArquivoRecebido")), Nothing, r("ArquivoRecebido"))
        sim.IDPessoaDestino = IIf(IsDBNull(r("IDPessoaDestino")), Nothing, r("IDPessoaDestino"))
        sim.PessoaDestino = IIf(IsDBNull(r("PessoaDestino")), String.Empty, r("PessoaDestino"))
        sim.IDPessoaOrigem = IIf(IsDBNull(r("IDPessoaOrigem")), Nothing, r("IDPessoaOrigem"))
        sim.PessoaOrigem = IIf(IsDBNull(r("PessoaOrigem")), String.Empty, r("PessoaOrigem"))
        sim.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao"))
        sim.IDSituacao = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
        sim.Situacao = IIf(IsDBNull(r("Situacao")), String.Empty, r("Situacao"))
        sim.IDUser = IIf(IsDBNull(r("IDUser")), Nothing, r("IDUser"))
        sim.CFOP = IIf(IsDBNull(r("CFOP")), String.Empty, r("CFOP"))
        sim.TransacaoData = IIf(IsDBNull(r("TransacaoData")), Nothing, r("TransacaoData"))
        sim.IDAReceber = IIf(IsDBNull(r("IDAReceber")), Nothing, r("IDAReceber"))
        sim.SituacaoAReceber = IIf(IsDBNull(r("SituacaoAReceber")), Nothing, r("SituacaoAReceber"))
        sim.ValorPagoTotal = IIf(IsDBNull(r("ValorPagoTotal")), 0, r("ValorPagoTotal"))
        sim.IDCobrancaForma = IIf(IsDBNull(r("IDCobrancaForma")), Nothing, r("IDCobrancaForma"))
        sim.IDPlano = IIf(IsDBNull(r("IDPlano")), Nothing, r("IDPlano"))
        sim.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        '
        Return sim
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET LISTA SIMPLES SAIDA PARA FRMPROCURA RETORNA LIST OF clSimplesSaida
    '--------------------------------------------------------------------------------------------
    Public Function GetSimplesSaidaLista_Procura(IDFilial As Integer,
                                                 Optional dtInicial As Date? = Nothing,
                                                 Optional dtFinal As Date? = Nothing) As List(Of clSimplesSaida)
        '
        SQL.AddParam("@IDFilial", IDFilial)
        Dim myQuery As String = "SELECT * FROM qrySimplesSaida WHERE IDPessoaOrigem = @IDFilial"
        '
        If Not IsNothing(dtInicial) Then
            '
            SQL.AddParam("@DataInicial", dtInicial)
            myQuery = myQuery & " AND TransacaoData >= @DataInicial"
            '
        End If
        '
        If Not IsNothing(dtFinal) Then
            '
            SQL.AddParam("@DataFinal", dtFinal)
            myQuery = myQuery & " AND TransacaoData <= @DataFinal"
            '
        End If
        '
        Try
            Dim sList As New List(Of clSimplesSaida)
            '
            sql.ExecQuery(myQuery)
            '
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            If sql.DBDT.Rows.Count = 0 Then Return sList
            '
            For Each r As DataRow In sql.DBDT.Rows
                Dim sim As New clSimplesSaida
                '
                sim = ConvertDtRow_clSimplesSaida(r)
                '
                sList.Add(sim)
                '
            Next
            '
            Return sList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET LISTA ARECEBER SIMPLES SAIDA PARA FRMPROCURA
    '--------------------------------------------------------------------------------------------
    Public Function GetSimplesAReceberLista_Procura(IDFilialOrigem As Integer,
                                                    Optional IDFilialDestino As Integer? = Nothing,
                                                    Optional dtInicial As Date? = Nothing,
                                                    Optional dtFinal As Date? = Nothing,
                                                    Optional Situacao As Byte? = Nothing) As List(Of clAReceberParcela)
        '
        Dim myQuery As String = "SELECT * FROM qryAReceberParcela WHERE Origem = 3 AND IDFilial = @IDFilialOrigem "
        '
        '--- Add Params
        '----------------------------------------------------------------
        SQL.AddParam("@IDFilialOrigem", IDFilialOrigem)
        '
        If Not IsNothing(IDFilialDestino) Then
            SQL.AddParam("@IDFilialDestino", IDFilialDestino)
            myQuery = myQuery & " AND IDPessoa = @IDFilialDestino "
        End If
        '
        If Not IsNothing(dtInicial) Then
            SQL.AddParam("@dtInicial", dtInicial)
            myQuery = myQuery & " AND Vencimento >= @dtInicial"
        End If
        '
        If Not IsNothing(dtFinal) Then
            SQL.AddParam("@dtFinal", dtFinal)
            myQuery = myQuery & " AND Vencimento <= @dtFinal"
        End If
        '
        If Not IsNothing(Situacao) Then '--- 0:EmAberto | 1:Pago | 2:Cancelada | 3:Negativada | 4:Negociada
            SQL.AddParam("@Situacao", Situacao)
            myQuery = myQuery & " AND SituacaoParcela = @Situacao"
        End If
        '
        '--- Execute
        '----------------------------------------------------------------
        Try
            '
            Dim eList As New List(Of clAReceberParcela)
            '
            SQL.ExecQuery(myQuery)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.DBDT.Rows.Count = 0 Then Return eList
            '
            For Each r As DataRow In SQL.DBDT.Rows
                '
                Dim newParcela As New clAReceberParcela
                '
                With newParcela
                    '--- tblAReceber
                    .IDAReceber = IIf(IsDBNull(r("IDAReceber")), Nothing, r("IDAReceber"))
                    .IDOrigem = IIf(IsDBNull(r("IDOrigem")), Nothing, r("IDOrigem"))
                    .Origem = IIf(IsDBNull(r("Origem")), Nothing, r("Origem"))
                    .IDPessoa = IIf(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
                    .AReceberValor = IIf(IsDBNull(r("AReceberValor")), Nothing, r("AReceberValor"))
                    .ValorPagoTotal = IIf(IsDBNull(r("ValorPagoTotal")), 0, r("ValorPagoTotal"))
                    .SituacaoAReceber = IIf(IsDBNull(r("SituacaoAReceber")), Nothing, r("SituacaoAReceber"))
                    .IDCobrancaForma = IIf(IsDBNull(r("IDCobrancaForma")), Nothing, r("IDCobrancaForma"))
                    .IDPlano = IIf(IsDBNull(r("IDPlano")), Nothing, r("IDPlano"))
                    '--- tblAReceberParcela
                    .IDAReceberParcela = IIf(IsDBNull(r("IDAReceberParcela")), Nothing, r("IDAReceberParcela"))
                    .Letra = IIf(IsDBNull(r("Letra")), String.Empty, r("Letra"))
                    .Vencimento = IIf(IsDBNull(r("Vencimento")), Nothing, r("Vencimento"))
                    .ParcelaValor = IIf(IsDBNull(r("ParcelaValor")), 0, r("ParcelaValor"))
                    .PermanenciaTaxa = IIf(IsDBNull(r("PermanenciaTaxa")), 0, r("PermanenciaTaxa"))
                    .ValorPagoParcela = IIf(IsDBNull(r("ValorPagoParcela")), 0, r("ValorPagoParcela"))
                    .ValorJuros = IIf(IsDBNull(r("ValorJuros")), Nothing, r("ValorJuros"))
                    .SituacaoParcela = IIf(IsDBNull(r("SituacaoParcela")), Nothing, r("SituacaoParcela"))
                    .PagamentoData = IIf(IsDBNull(r("PagamentoData")), Nothing, r("PagamentoData"))
                    '--- qryPessoaFisicaJuridica
                    .Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                    .CNP = IIf(IsDBNull(r("CNP")), String.Empty, r("CNP"))
                    '--- tblPessoaFilial
                    .IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
                    .ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
                End With
                '
                eList.Add(newParcela)
                '
            Next
            '
            Return eList
            '
        Catch ex As Exception
            '
            Throw ex
            '
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GERA SIMPLES ENTRADA A PARTIR DE UMA SIMPLES SAIDA
    '--------------------------------------------------------------------------------------------
    Public Function Insert_SimplesEntrada_FROM_SimplesSaida(_Simples As clSimplesSaida) As clSimplesEntrada ',
        '_IDFilial As Integer,
        '_IDUser As Integer) As clSimplesEntrada
        ' 
        '--- GET LIST OF ITENS E ARECEBER
        '========================================================================
        Dim SaidaItens As New List(Of clTransacaoItem)
        Dim SaidaAReceber As New List(Of clAReceberParcela)
        '
        Try
            '--- GET A LIST OF ITENS
            Dim tBLL As New TransacaoItemBLL
            SaidaItens = tBLL.GetTransacaoItens_List(_Simples.IDTransacao, _Simples.IDPessoaOrigem)
            '
            ' GET A LIST OF ARECEBER
            Dim rBLL As New ParcelaBLL
            SaidaAReceber = rBLL.Parcela_GET_PorIDOrigem(3, _Simples.IDTransacao)
            '
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        ' INIT ACESSODADOS AND TRANSACTION
        '========================================================================
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        ' INSERT SIMPLES ENTRADA
        '========================================================================
        Dim sBLL As New SimplesMovimentacaoBLL
        Dim newSimplesEntrada As New clSimplesEntrada
        '
        Dim newSEntrada As New clSimplesEntrada With {
            .IDPessoaDestino = _Simples.IDPessoaDestino,
            .IDPessoaOrigem = _Simples.IDPessoaOrigem,
            .IDUser = _Simples.IDUser,
            .TransacaoData = _Simples.TransacaoData,
            .EntradaData = _Simples.TransacaoData,
            .IDTransacaoOrigem = _Simples.IDTransacao,
            .ValorTotal = _Simples.ValorTotal
        }
        '
        Try
            newSimplesEntrada = sBLL.InsertSimplesEntrada_Procedure_Classe(newSEntrada, db)
        Catch ex As Exception
            Throw ex
            db.RollBackTransaction()
            Return Nothing
        End Try
        '
        ' INSERT ITENS
        '========================================================================
        Dim ItemBLL As New TransacaoItemBLL
        '
        For Each item As clTransacaoItem In SaidaItens
            '
            '--- cria o novo Item
            Dim newItem As New clTransacaoItem With {
                .Desconto = item.Desconto,
                .IDProduto = item.IDProduto,
                .Preco = item.Preco,
                .Quantidade = item.Quantidade,
                .IDFilial = _Simples.IDPessoaDestino,
                .IDTransacao = newSimplesEntrada.IDTransacao
            }
            '
            '
            Dim myID As Long? = Nothing
            '
            '--- Insere o novo ITEM no BD
            Try
                myID = ItemBLL.InserirNovoItem(newItem,
                                               TransacaoItemBLL.EnumMovimento.ENTRADA,
                                               newSimplesEntrada.EntradaData,
                                               False, db)
                newItem.IDTransacaoItem = myID
            Catch ex As Exception
                Throw ex
                db.RollBackTransaction()
                Return Nothing
            End Try
            '
        Next
        '
        ' INSERT A APAGAR
        '========================================================================
        Dim pagBLL As New APagarBLL
        '
        '--- transforma cada AReceber (SimplesSaida) em APagar (SimplesEntrada)
        For Each rec As clAReceberParcela In SaidaAReceber
            Dim newAPagar As New clAPagar With {
                    .Origem = 4, '--> tblSimplesEntrada
                    .IDOrigem = newSimplesEntrada.IDTransacao,
                    .IDPessoa = _Simples.IDPessoaOrigem,
                    .IDFilial = _Simples.IDPessoaDestino,
                    .IDCobrancaForma = 1, '--> EmCarteira
                    .Identificador = Format(rec.IDAReceber, "0000") & rec.Letra,
                    .RGBanco = Nothing,
                    .Vencimento = rec.Vencimento,
                    .APagarValor = rec.ParcelaValor,
                    .Situacao = 0,
                    .ValorPago = 0
            }
            '
            '--- Insere cada um APagar no BD
            Try
                pagBLL.InserirNovo_APagar(newAPagar, db)
            Catch ex As Exception
                Throw ex
                db.RollBackTransaction()
                Return Nothing
            End Try
            '
        Next
        '
        ' COMMIT TRANSACTION
        '========================================================================
        db.CommitTransaction()
        '
        Return newSimplesEntrada
        '
    End Function
    '
#End Region '/ SIMPLES SAIDA
    '
#Region "SIMPES ENTRADA"
    '
    '--------------------------------------------------------------------------------------------
    ' INSERT NOVA SIMPLES ENTRADA E RETORNA UMA CLSIMPLESENTRADA
    '--------------------------------------------------------------------------------------------
    Public Function InsertSimplesEntrada_Procedure_Classe(_simples As clSimplesEntrada,
                                                          Optional _myAcesso As Object = Nothing) As clSimplesEntrada
        Try
            Dim dtSimples As DataTable
            '
            dtSimples = InsertSimplesEntrada_Procedure_DT(_simples, _myAcesso)
            '
            If dtSimples.Rows.Count > 0 Then
                Dim r As DataRow = dtSimples(0)
                '
                Return ConvertDtRow_clSimplesEntrada(r)
            Else
                Return Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' INSERT SIMPLES ENTRADA E RETORNA UM DATATABLE
    '--------------------------------------------------------------------------------------------
    Public Function InsertSimplesEntrada_Procedure_DT(ByVal _sim As clSimplesEntrada,
                                                      Optional myAcesso As AcessoDados = Nothing) As DataTable
        '
        Dim objDB As AcessoDados
        '
        If IsNothing(myAcesso) Then
            objDB = New AcessoDados
        Else
            objDB = myAcesso
        End If
        '
        Dim Conn As New SqlCommand
        '
        'Adiciona os Parâmetros
        objDB.LimparParametros()
        objDB.BeginTransaction()
        '
        '-- PARAMETROS DA TBLTRANSACAO
        '@IDPessoaDestino AS INT, x
        objDB.AdicionarParametros("@IDPessoaDestino", _sim.IDPessoaDestino)
        '@IDPessoaOrigem AS INT, x
        objDB.AdicionarParametros("@IDPessoaOrigem", _sim.IDPessoaOrigem)
        '@IDUser AS INT, x
        objDB.AdicionarParametros("@IDUser", _sim.IDUser)
        '@VendaData AS SMALLDATETIME, x
        objDB.AdicionarParametros("@TransacaoData", _sim.TransacaoData)
        '@IDTransacaoOrigem AS INT
        objDB.AdicionarParametros("@IDTransacaoOrigem", _sim.IDTransacaoOrigem)
        '@EntradaData AS DATE
        objDB.AdicionarParametros("@EntradaData", _sim.EntradaData)
        '@ValorTotal AS MONEY
        objDB.AdicionarParametros("@ValorTotal", _sim.ValorTotal)
        '
        Try
            Dim dtV As DataTable = objDB.ExecutarConsulta(CommandType.StoredProcedure, "uspSimplesEntrada_Inserir")
            '
            If dtV.Rows.Count = 0 Then
                Throw New Exception("Um erro ineperado ocorreu na uspSimplesEntrada_Inserir")
            End If
            '
            If IsNumeric(dtV.Rows(0).Item(0)) Then
                objDB.CommitTransaction()
                Return dtV
            Else
                Throw New Exception(dtV.Rows(0).Item(0))
            End If
            '
        Catch ex As Exception
            objDB.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET LISTA SIMPLES ENTRADA PARA FRMPROCURA RETORNA LIST OF clSimplesEntrada
    '--------------------------------------------------------------------------------------------
    Public Function GetSimplesEntradaLista_Procura(IDFilial As Integer,
                                                   Optional dtInicial As Date? = Nothing,
                                                   Optional dtFinal As Date? = Nothing) As List(Of clSimplesEntrada)
        '
        SQL.AddParam("@IDFilial", IDFilial)
        Dim myQuery As String = "SELECT * FROM qrySimplesEntrada WHERE IDPessoaDestino = @IDFilial "
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
            Dim sList As New List(Of clSimplesEntrada)
            '
            sql.ExecQuery(myQuery)
            '
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            If sql.DBDT.Rows.Count = 0 Then Return sList
            '
            For Each r As DataRow In sql.DBDT.Rows
                Dim sim As New clSimplesEntrada
                '
                sim = ConvertDtRow_clSimplesEntrada(r)
                '
                sList.Add(sim)
                '
            Next
            '
            Return sList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET SIMPLES ENTRADA PELO ID RETORNA CL_SIMPLES_ENTRADA
    '--------------------------------------------------------------------------------------------
    Public Function GetSimplesEntrada_PorID(myID As Integer) As clSimplesEntrada
        '
        SQL.AddParam("@IDTransacao", myID)
        Dim myQuery As String = "SELECT * FROM qrySimplesEntrada WHERE IDTransacao = @IDTransacao"
        '
        Try
            SQL.ExecQuery(myQuery)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount > 0 Then
                Dim simples As clSimplesEntrada = ConvertDtRow_clSimplesEntrada(SQL.DBDT.Rows(0))
                '
                Return simples
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
    ' CONVERT DATAROW DA DATATABLE qrySimplesSaida EM UM clSimplesSaida
    '--------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_clSimplesEntrada(r As DataRow) As clSimplesEntrada
        '
        Dim sim As New clSimplesEntrada
        '
        sim.IDTransacao = IIf(IsDBNull(r("IDTransacao")), Nothing, r("IDTransacao"))
        sim.ValorTotal = IIf(IsDBNull(r("ValorTotal")), 0, r("ValorTotal"))
        sim.IDTransacaoOrigem = IIf(IsDBNull(r("IDTransacaoOrigem")), Nothing, r("IDTransacaoOrigem"))
        sim.EntradaData = IIf(IsDBNull(r("EntradaData")), Nothing, r("EntradaData"))
        sim.IDPessoaDestino = IIf(IsDBNull(r("IDPessoaDestino")), Nothing, r("IDPessoaDestino"))
        sim.PessoaDestino = IIf(IsDBNull(r("PessoaDestino")), String.Empty, r("PessoaDestino"))
        sim.IDPessoaOrigem = IIf(IsDBNull(r("IDPessoaOrigem")), Nothing, r("IDPessoaOrigem"))
        sim.PessoaOrigem = IIf(IsDBNull(r("PessoaOrigem")), String.Empty, r("PessoaOrigem"))
        sim.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao"))
        sim.IDSituacao = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
        sim.Situacao = IIf(IsDBNull(r("Situacao")), String.Empty, r("Situacao"))
        sim.IDUser = IIf(IsDBNull(r("IDUser")), Nothing, r("IDUser"))
        sim.CFOP = IIf(IsDBNull(r("CFOP")), String.Empty, r("CFOP"))
        sim.TransacaoData = IIf(IsDBNull(r("TransacaoData")), Nothing, r("TransacaoData"))
        sim.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        '
        Return sim
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' VERIFIES IF SIMPLES ENTRADA HAS ALREADY BEEN INSERTED RETURN NOTHING IF NOT INSERTED
    '--------------------------------------------------------------------------------------------
    Public Function VerificaEntrada(IDTransacaoOrigem As Integer) As clSimplesEntrada
        '
        Dim myQuery As String = "SELECT * FROM qrySimplesEntrada WHERE IDTransacaoOrigem = @ID"
        '
        SQL.AddParam("@ID", IDTransacaoOrigem)
        '
        Try
            SQL.ExecQuery(myQuery)
            '
            If SQL.HasException Then
                Throw New Exception
            End If
            '
            If SQL.DBDT.Rows.Count > 0 Then
                Dim r As DataRow = SQL.DBDT.Rows(0)
                '
                Return ConvertDtRow_clSimplesEntrada(r)
                '
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
#End Region '/ SIMPLES ENTRADA
    '
End Class
