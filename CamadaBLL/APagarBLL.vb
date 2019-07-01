Imports System.Globalization
Imports CamadaDAL
Imports CamadaDTO
'
Public Class APagarBLL
    '===================================================================================================
    ' OBTER LISTA DE APAGAR POR IDORIGEM E ORIGEM
    '===================================================================================================
    Public Function APagar_GET_PorOrigem(myIDOrigem As Integer, myOrigem As clAPagar.Origem_APagar) As List(Of clAPagar)
        Dim db As New AcessoDados
        Dim dt As New DataTable
        '
        '--- INSERT PARAMS
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDOrigem", myIDOrigem)
        db.AdicionarParametros("@Origem", myOrigem)
        '
        '--- CREATE A QUERY
        Dim myQuery As String = "SELECT * FROM qryAPagar WHERE IDOrigem = @IDOrigem AND Origem = @Origem"
        '
        '--- EXECUTE QUERY
        Try
            '
            dt = db.ExecutarConsulta(CommandType.Text, myQuery)
            Return ConvertDT_To_ListAPagar(dt)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' SALVAR ITEM APAGAR
    '===================================================================================================
    Public Function InserirNovo_APagar(_pag As clAPagar,
                                       Optional dbTran As Object = Nothing) As Integer
        '
        '
        '--- define o Acesso Dados
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- define o object response
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@Origem", _pag.Origem)
            db.AdicionarParametros("@IDOrigem", _pag.IDOrigem)
            db.AdicionarParametros("@IDPessoa", _pag.IDPessoa)
            db.AdicionarParametros("@IDFilial", _pag.IDFilial)
            db.AdicionarParametros("@IDCobrancaForma", _pag.IDCobrancaForma)
            db.AdicionarParametros("@Identificador", _pag.Identificador)
            db.AdicionarParametros("@RGBanco", _pag.RGBanco)
            db.AdicionarParametros("@Vencimento", _pag.Vencimento)
            db.AdicionarParametros("@APagarValor", _pag.APagarValor)
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAPagar_Inserir")
            '
            If IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' EXCLUIR TODOS APAGAR DE UMA TRANSACAO PELO ID
    '===================================================================================================
    Public Function Excluir_APagar_Origem(IDOrigem As Integer,
                                          Origem As clAPagar.Origem_APagar,
                                          Optional dbTran As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- Limpa os paramentros
        db.LimparParametros()
        '
        '--- Adiciona os paramentros
        db.AdicionarParametros("@Origem", Origem)
        db.AdicionarParametros("@IDOrigem", IDOrigem)
        '
        Try
            Dim obj As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAPagar_Excluir_PorOrigem")
            Return CBool(obj)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' GET COBRANCA FORMAS DE APAGAR
    '===================================================================================================
    Public Function CobrancaFormas_APagar_GET() As DataTable
        Dim SQL As New SQLControl
        '
        Dim strSQL As String = "SELECT IDCobrancaForma, CobrancaForma FROM tblCobrancaForma WHERE Saidas = 'TRUE'"
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' GET LISTA APAGAR PARA FRMPROCURA COM OU SEM DESPESA PERIODICA
    '===================================================================================================
    Public Function GetAPagarLista_Procura(myIDFilial As Integer,
                                           myCredorCadastro As String,
                                           withPeriodico As Boolean,
                                           onlySimples As Boolean,
                                           Optional myIDCobrancaForma As Int16? = Nothing,
                                           Optional dtInicial As Date? = Nothing,
                                           Optional dtFinal As Date? = Nothing,
                                           Optional Situacao As Byte? = Nothing) As List(Of clAPagar)
        '
        Dim db As New AcessoDados
        db.LimparParametros()
        '
        '--- ADICIONA PARAMETROS
        '--------------------------------------------------------------------------------------------
        db.AdicionarParametros("@IDFilial", myIDFilial)
        db.AdicionarParametros("@CredorCadastro", myCredorCadastro)
        '
        '--- CRIA MYQUERY
        Dim myQuery As String = "SELECT * FROM qryAPagar WHERE IDFilial = @IDFilial " &
                                "AND Cadastro LIKE '%'+@CredorCadastro+'%' "
        '
        '--- Verifica se é APagar Normal ou de SimplesEntrada
        If Not onlySimples Then
            myQuery = myQuery & "AND Origem <> 4 " '--> sem simples
        Else
            myQuery = myQuery & "AND Origem = 4 " '--> somente simples
        End If
        '
        If Not IsNothing(myIDCobrancaForma) Then
            db.AdicionarParametros("@IDCobrancaForma", myIDCobrancaForma)
            myQuery = myQuery & "AND IDCobrancaForma = @IDCobrancaForma "
        End If
        '
        If Not IsNothing(dtInicial) Then
            db.AdicionarParametros("@DataInicial", dtInicial)
            myQuery = myQuery & " AND Vencimento >= @DataInicial "
        End If
        '
        If Not IsNothing(dtFinal) Then
            db.AdicionarParametros("@DataFinal", dtFinal)
            myQuery = myQuery & " AND Vencimento <= @DataFinal "
        End If
        '
        If Not IsNothing(Situacao) Then
            db.AdicionarParametros("@Situacao", Situacao)
            myQuery = myQuery & "AND Situacao = @Situacao"
        End If
        '
        '--- EXECUTA CONSULTA QUERY E CRIA A LISTA
        '--------------------------------------------------------------------------------------------
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            Dim plist As List(Of clAPagar) = ConvertDT_To_ListAPagar(dt)
            '
            '--- Verifica se deve incluir as despesas periodicas
            If withPeriodico = False OrElse If(Situacao, 0) <> 0 Then
                '
                '--- retorna
                Return plist.OrderBy(Function(x) x.Vencimento).ToList
                '
            End If
            '
            'INSERE NA LISTA AS DESPESAS PERIODICAS
            '-----------------------------------------------------------------------------------------------------
            Dim pListPeriodica As List(Of clAPagar) = GetAPagarPeriodicoLista_Procura(myIDFilial,
                                                                                      myIDCobrancaForma,
                                                                                      myCredorCadastro,
                                                                                      dtInicial, dtFinal)
            '
            '--- Adiciona as listagem de APagar das Despesas Periodicas
            pList.AddRange(pListPeriodica)
            '
            '--- Ordena a listagem pelos vencimentos
            pList = pList.OrderBy(Function(x) x.Vencimento).ToList
            '
            Return pList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' CONVERTER APAGAR DATATABLE EM LIST OF CLAPAGAR
    '===================================================================================================
    Private Function ConvertDT_To_ListAPagar(dt As DataTable) As List(Of clAPagar)
        '
        Dim pList As New List(Of clAPagar)
        '
        For Each r In dt.Rows
            '
            Dim p As New clAPagar
            '
            p.IDAPagar = IIf(IsDBNull(r("IDAPagar")), Nothing, r("IDAPagar"))
            p.Origem = IIf(IsDBNull(r("Origem")), Nothing, r("Origem"))
            p.OrigemTexto = IIf(IsDBNull(r("OrigemTexto")), String.Empty, r("OrigemTexto"))
            p.IDOrigem = IIf(IsDBNull(r("IDOrigem")), Nothing, r("IDOrigem"))
            p.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
            p.IDPessoa = IIf(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
            p.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            p.IDCobrancaForma = IIf(IsDBNull(r("IDCobrancaForma")), Nothing, r("IDCobrancaForma"))
            p.CobrancaForma = IIf(IsDBNull(r("CobrancaForma")), String.Empty, r("CobrancaForma"))
            p.Identificador = IIf(IsDBNull(r("Identificador")), String.Empty, r("Identificador"))
            p.RGBanco = IIf(IsDBNull(r("RGBanco")), Nothing, r("RGBanco"))
            p.BancoNome = IIf(IsDBNull(r("BancoNome")), String.Empty, r("BancoNome"))
            p.Vencimento = IIf(IsDBNull(r("Vencimento")), Nothing, r("Vencimento"))
            p.APagarValor = IIf(IsDBNull(r("APagarValor")), 0, r("APagarValor"))
            p.Situacao = IIf(IsDBNull(r("Situacao")), Nothing, r("Situacao"))
            p.PagamentoData = IIf(IsDBNull(r("PagamentoData")), Nothing, r("PagamentoData"))
            p.ValorPago = IIf(IsDBNull(r("ValorPago")), 0, r("ValorPago"))
            p.Desconto = IIf(IsDBNull(r("Desconto")), Nothing, r("Desconto"))
            p.Acrescimo = IIf(IsDBNull(r("Acrescimo")), Nothing, r("Acrescimo"))
            '
            pList.Add(p)
            '
        Next
        '
        Return pList
        '
    End Function
    '
    '===================================================================================================
    ' GET LISTA APAGAR PERIODICO PARA FRMPROCURA
    '===================================================================================================
    Private Function GetAPagarPeriodicoLista_Procura(myIDFilial As Integer,
                                                     myIDCobrancaForma As Int16?,
                                                     myCredorCadastro As String,
                                                     Optional dtInicial As Date? = Nothing,
                                                     Optional dtFinal As Date? = Nothing,
                                                     Optional Ativa As Boolean = True) As List(Of clAPagar)
        Dim db As New AcessoDados
        '
        '--- Adiciona os Parametros da pesquisa
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDFilial", myIDFilial)
        db.AdicionarParametros("@CredorCadastro", myCredorCadastro)
        db.AdicionarParametros("@Ativa", Ativa)
        '
        '--- CRIA MYQUERY
        Dim myQuery As String = "SELECT * FROM qryDespesaPeriodica WHERE IDFilial = @IDFilial " &
                                "AND Cadastro LIKE '%'+@CredorCadastro+'%' " &
                                "AND Ativa = @Ativa "
        '
        If Not IsNothing(myIDCobrancaForma) Then
            db.AdicionarParametros("@IDCobrancaForma", myIDCobrancaForma)
            myQuery = myQuery & "AND IDCobrancaForma = @IDCobrancaForma "
        End If
        '
        Try
            '--- Get datatable DespesaPeriodica
            Dim dtDesp As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            Dim pList As New List(Of clAPagar)
            '
            '--- Verifica se retornou algum registro de despesa periódica
            If dtDesp.Rows.Count = 0 Then Return pList
            '
            For Each r In dtDesp.Rows
                '
                '--- Definir a data INICIAL
                Dim IniciarData As Date
                '
                If Not IsNothing(dtInicial) Then
                    If dtInicial >= r("IniciarData") Then
                        IniciarData = dtInicial
                    Else
                        IniciarData = r("IniciarData")
                    End If
                Else
                    IniciarData = r("IniciarData")
                End If
                '
                '--- Definir a data FINAL
                Dim FinalizarData As Date
                '
                If Not IsNothing(dtFinal) Then
                    FinalizarData = dtFinal
                Else
                    FinalizarData = CType(r("IniciarData"), Date).AddMonths(6)
                End If
                '
                '--- MULTIPLICA OS PAGAMENTOS E OBTEM UMA LISTA DE APAGAR
                Dim listAPagarPer As List(Of clAPagar) = GetAPagarPeriodicoList(IniciarData, FinalizarData,
                                                                                r("Periodicidade"),
                                                                                r("DiaVencimento"),
                                                                                IIf(IsDBNull(r("MesVencimento")),
                                                                                Nothing,
                                                                                r("MesVencimento")))
                For Each p In listAPagarPer
                    '
                    p.IDAPagar = Nothing
                    p.Origem = 3
                    p.OrigemTexto = "Despesa Periódica"
                    p.IDOrigem = IIf(IsDBNull(r("IDDespesaPeriodica")), Nothing, r("IDDespesaPeriodica"))
                    p.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
                    p.IDPessoa = IIf(IsDBNull(r("IDCredor")), Nothing, r("IDCredor"))
                    p.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                    p.IDCobrancaForma = IIf(IsDBNull(r("IDCobrancaForma")), Nothing, r("IDCobrancaForma"))
                    p.CobrancaForma = IIf(IsDBNull(r("CobrancaForma")), String.Empty, r("CobrancaForma"))
                    p.RGBanco = IIf(IsDBNull(r("RGBanco")), Nothing, r("RGBanco"))
                    p.BancoNome = IIf(IsDBNull(r("BancoNome")), String.Empty, r("BancoNome"))
                    p.APagarValor = IIf(IsDBNull(r("DespesaValor")), 0, r("DespesaValor"))
                    p.Situacao = 0
                    p.PagamentoData = Nothing
                    p.Desconto = 0
                    p.Acrescimo = 0
                    '
                    '--- Adiciona o novo APagar Periodico a listagem
                    pList.Add(p)
                    '
                Next
                '
            Next
            '
            Return pList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' CRIA LISTA CLAPAGAR PERIODICO
    '===================================================================================================
    Private Function GetAPagarPeriodicoList(dtInicial As Date,
                                            dtFinal As Date,
                                            Periodicidade As Byte,
                                            DiaVencimento As Byte,
                                            Optional MesVencimento As Byte? = Nothing) As List(Of clAPagar)
        '
        Dim APagar_list As New List(Of clAPagar)
        '
        ' PERIODICIDADE: 1:SEMANAL | 2:MENSAL | 3:ANUAL
        '-----------------------------------------------------------------
        Select Case Periodicidade
            Case 1 '--- SEMANAL
                '
                While dtInicial <= dtFinal

                    If dtInicial.DayOfWeek = DiaVencimento Then
                        '
                        '--- Calendar para obter o numero da semana para o IDENTIFICADOR
                        Dim dfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo
                        Dim cal As Calendar = dfi.Calendar
                        '
                        '--- Cria um novo APagar 
                        Dim newAPagar As New clAPagar
                        '
                        '--- Define os dados do APagar
                        newAPagar.Identificador = "S-" & Format(cal.GetWeekOfYear(dtInicial, dfi.CalendarWeekRule, DayOfWeek.Sunday), "00")
                        newAPagar.Vencimento = dtInicial
                        '
                        '--- Inclui o novo APagar a listagem
                        APagar_list.Add(newAPagar)
                        '
                        '--- Adiciona 6 dias adiantar uma semana
                        dtInicial = dtInicial.AddDays(6)
                        '
                    End If
                    '
                    '--- Adiciona 1 dia
                    dtInicial = dtInicial.AddDays(1)
                    '
                    '
                End While
                '
            Case 2 '--- MENSAL
                '
                '--- Define a mes do primeiro vencimento
                If Day(dtInicial) <= DiaVencimento Then
                    dtInicial = DateSerial(Year(dtInicial), Month(dtInicial), DiaVencimento)
                Else
                    dtInicial = DateSerial(Year(dtInicial), Month(dtInicial) + 1, DiaVencimento)
                End If
                '
                While dtInicial <= dtFinal
                    '
                    '--- Cria um novo APagar 
                    Dim newAPagar As New clAPagar
                    '
                    '--- Define os dados do APagar
                    newAPagar.Identificador = "REF-" & Format(dtInicial, "MM/yyyy")
                    newAPagar.Vencimento = dtInicial
                    '
                    '--- Inclui o novo APagar a listagem
                    APagar_list.Add(newAPagar)
                    '
                    '--- Adiciona 1 Mes a data inicial
                    dtInicial = dtInicial.AddMonths(1)
                    '
                End While
                '
            Case 3 '--- ANUAL
                '
                '--- Define o ano do primeiro vencimento
                If Month(dtInicial) <= MesVencimento Then
                    dtInicial = DateSerial(Year(dtInicial), MesVencimento, DiaVencimento)
                Else
                    dtInicial = DateSerial(Year(dtInicial) + 1, MesVencimento, DiaVencimento)
                End If
                '
                While dtInicial <= dtFinal
                    '
                    '--- Cria um novo APagar 
                    Dim newAPagar As New clAPagar
                    '
                    '--- Define os dados do APagar
                    newAPagar.Identificador = "REF-" & Format(dtInicial, "yyyy")
                    newAPagar.Vencimento = dtInicial
                    '
                    '--- Inclui o novo APagar a listagem
                    APagar_list.Add(newAPagar)
                    '
                    '--- Adiciona 1 Mes a data inicial
                    dtInicial = dtInicial.AddYears(1)
                    '
                End While
                '
            Case Else


        End Select
        '
        Return APagar_list
        '
    End Function
    '
    '===================================================================================================
    ' CANCELAR APAGAR
    '===================================================================================================
    Public Function Cancelar_APagar(IDAPagar As Integer) As Integer
        Dim db As New AcessoDados
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAPagar", IDAPagar)
            db.AdicionarParametros("@NovaSituacao", 2) '-- 2 : Situacao CANCELADA
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAPagar_AlterarSituacao")
            '
            If IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' NORMALIZAR APAGAR
    '===================================================================================================
    Public Function Normalizar_APagar(IDAPagar As Integer) As Integer
        Dim db As New AcessoDados
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAPagar", IDAPagar)
            db.AdicionarParametros("@NovaSituacao", 0) '-- 2 : Situacao CANCELADA
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAPagar_AlterarSituacao")
            '
            If IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' QUITAR APAGAR EFETUAR SAIDA
    '===================================================================================================
    Public Function Quitar_APagar(IDAPagar As Integer, ValorPago As Double,
                                  Acrescimo As Double, SaidaData As Date,
                                  IDConta As Byte, Observacao As String,
                                  Optional dbTran As Object = Nothing) As Integer
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAPagar", IDAPagar)
            db.AdicionarParametros("@ValorPago", If(ValorPago > 0, ValorPago * -1, ValorPago))
            db.AdicionarParametros("@Acrescimo", Acrescimo)
            db.AdicionarParametros("@SaidaData", SaidaData)
            db.AdicionarParametros("@IDConta", IDConta)
            db.AdicionarParametros("@Observacao", IIf(IsNothing(Observacao), String.Empty, Observacao))
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAPagar_Quitar")
            '
            If IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' CONCEDER DESCONTO APAGAR
    '===================================================================================================
    Public Function ConcederDesconto_APagar(IDAPagar As Integer, newDesconto As Double) As Boolean
        Dim SQL As New SQLControl
        '
        Dim strSQL As String = String.Format(New Globalization.CultureInfo("en-US"),
                                             "UPDATE tblAPagar SET Desconto = {0} WHERE IDAPagar = {1}",
                                              newDesconto, IDAPagar)
        '
        SQL.ExecQuery(strSQL)
        '
        If SQL.HasException Then
            Throw New Exception(SQL.Exception)
        Else
            Return True
        End If
        '
    End Function
    '
    '===================================================================================================
    ' ESTORNAR SAIDA APAGAR TRANSACAO | DESPESA
    '===================================================================================================
    Public Function Estornar_APagar(myIDAPagar As Integer, myIDMovimentacao As Integer) As clAPagar
        '
        Dim db As New AcessoDados
        Dim dtPag As DataTable
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAPagar", myIDAPagar)
            db.AdicionarParametros("@IDMovimentacao", myIDMovimentacao)
            '
            dtPag = db.ExecutarConsulta(CommandType.StoredProcedure, "uspAPagar_Estornar")
            '
            '--- verifica se retornou alguma ROW
            If dtPag.Rows.Count = 0 Then
                Throw New Exception("Uma exceção inesperada ocorreu ao Estornar Pagamento...")
            End If
            '
            '--- verifica se o RETORNO é uma clParcela
            If dtPag.Columns.Count = 1 Then '--- se tem mais de uma coluna então é uma clParcela
                Throw New Exception(dtPag.Rows(0)(0))
            End If
            '
            '--- Retorna
            Return ConvertDT_To_ListAPagar(dtPag).Item(0)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' RETORNA LIST OF APAGAR EM ABERTO SIMPLES BETWEEN TWO FILIAIS
    '===================================================================================================
    Public Function GetListAPagar_Simples_EmAberto(IDFilialCreditada As Integer,
                                                   IDFilialDebitada As Integer) As List(Of clAPagar)
        '
        Dim myDB As New AcessoDados
        '
        Dim myQuery As String = "SELECT * " &
                                "FROM qryAPagar " &
                                "WHERE Origem = 4 " & '--> Origem Simples Entrada
                                "AND Situacao = 0 " & '--> Situacao EmAberto
                                "AND IDFilial = @IDFilialDebitada " &
                                "AND IDPessoa = @IDFilialCreditada"
        '
        myDB.LimparParametros()
        myDB.AdicionarParametros("@IDFilialCreditada", IDFilialCreditada)
        myDB.AdicionarParametros("@IDFilialDebitada", IDFilialDebitada)
        '
        Try
            Dim dt As DataTable = myDB.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then
                Return New List(Of clAPagar)
            Else
                Return ConvertDT_To_ListAPagar(dt)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
