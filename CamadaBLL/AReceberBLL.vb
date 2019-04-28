Imports CamadaDAL
Imports CamadaDTO
'
'
'==========================================================================================
' CLASSE ARECEBER
'==========================================================================================
Public Class AReceberBLL
    '
    '===================================================================================================
    ' OBTER ARECEBER POR IDORIGEM E ORIGEM (TRANSACAO OU FINANCIAMENTO)
    '===================================================================================================
    Public Function AReceber_GET_PorOrigem(IDOrigem As Integer, Origem As clAReceber.EnumAReceberOrigem) As clAReceber
        Dim db As New AcessoDados
        Dim dt As New DataTable
        Dim clRec As New clAReceber
        '
        Try
            db.LimparParametros()
            db.AdicionarParametros("@IDVenda", IDOrigem)
            db.AdicionarParametros("@Origem", Origem)
            '
            dt = db.ExecutarConsulta(CommandType.StoredProcedure, "uspAReceber_GET_PorIDOrigem")
            '
            If dt.Rows.Count = 0 Then Return clRec
            '
            Dim r As DataRow = dt.Rows(0)
            '
            With clRec
                '--- tblAReceber
                .IDAReceber = IIf(IsDBNull(r("IDAReceber")), Nothing, r("IDAReceber"))
                .IDOrigem = IDOrigem
                .Origem = Origem
                .IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
                .ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
                .IDPessoa = IIf(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
                .AReceberValor = IIf(IsDBNull(r("AReceberValor")), 0, r("AReceberValor"))
                .ValorPagoTotal = IIf(IsDBNull(r("ValorPagoTotal")), 0, r("ValorPagoTotal"))
                .SituacaoAReceber = IIf(IsDBNull(r("SituacaoAReceber")), Nothing, r("SituacaoAReceber"))
            End With
            '
            Return clRec
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' SALVAR ITEM ARECEBER DA TRANSACAO OU REFINANCIAMENTO
    '===================================================================================================
    Public Function InserirNovo_AReceber(clAReceber As clAReceber,
                                         Optional myDB As Object = Nothing) As Integer
        '
        Dim db As AcessoDados = If(myDB, New AcessoDados)
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            With clAReceber
                db.AdicionarParametros("@IDOrigem", .IDOrigem)
                db.AdicionarParametros("@Origem", .Origem)
                db.AdicionarParametros("@IDPessoa", .IDPessoa)
                db.AdicionarParametros("@AReceberValor", .AReceberValor)
                db.AdicionarParametros("@IDFilial", .IDFilial)
            End With
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAReceber_Inserir")
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
    ' UPDATE ARECEBER DA TRANSACAO OU REFINANCIAMENTO
    '===================================================================================================
    Public Function Update_AReceber(clAReceber As clAReceber,
                                    Optional myDB As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(myDB, New AcessoDados)
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDAReceber", clAReceber.IDAReceber)
        db.AdicionarParametros("@AReceberValor", clAReceber.AReceberValor)
        db.AdicionarParametros("@IDPessoa", clAReceber.IDPessoa)
        db.AdicionarParametros("@IDCobrancaForma", If(clAReceber.IDCobrancaForma, DBNull.Value))
        db.AdicionarParametros("@IDPlano", If(clAReceber.IDPlano, DBNull.Value))
        db.AdicionarParametros("@ValorPagoTotal", clAReceber.ValorPagoTotal)
        db.AdicionarParametros("@SituacaoAReceber", clAReceber.SituacaoAReceber)
        '
        Dim myQuery As String = "UPDATE tblAReceber SET " &
                                "AReceberValor = @AReceberValor, " &
                                "IDPessoa = @IDPessoa, " &
                                "ValorPagoTotal = @ValorPagoTotal, " &
                                "SituacaoAReceber = @SituacaoAReceber, " &
                                "IDCobrancaForma = @IDCobrancaForma, " &
                                "IDPlano = @IDPlano " &
                                "WHERE IDAReceber = @IDAReceber"
        '
        Try
            '--- execute Query
            db.ExecutarManipulacao(CommandType.Text, myQuery)
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
    ' QUITAR ARECEBER DA VENDA A VISTA
    '===================================================================================================
    'DELETE ===> Public Function Quitar_AReceber_AVista(IDTransacao As Integer,
    '                                       vlPago As Decimal,
    '                                       Optional myDB As Object = Nothing) As Boolean
    '    '
    '    Dim db As AcessoDados = If(myDB, New AcessoDados)
    '    '
    '    db.LimparParametros()
    '    db.AdicionarParametros("@IDOrigem", IDTransacao)
    '    db.AdicionarParametros("@ValorPagoTotal", vlPago)
    '    '
    '    Dim myQuery As String = "UPDATE tblAReceber SET ValorPagoTotal = @ValorPagoTotal, SituacaoAReceber = 1 " &
    '                            "WHERE Origem = 1 AND IDOrigem = @IDOrigem"
    '    '
    '    Try
    '        db.ExecutarManipulacao(CommandType.Text, myQuery)
    '        '
    '        Return True
    '        '
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    '
    'End Function
    '
    '===================================================================================================
    ' EXCLUIR TODOS ARECEBER E MOVIMENTACAO DE UMA TRANSACAO PELO ID
    '===================================================================================================
    Public Function Excluir_AReceber_Transacao(IDTransacao As Integer,
                                               Origem As clAReceber.EnumAReceberOrigem,
                                               Optional mydb As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(mydb, New AcessoDados)
        Dim tranLocal As Boolean = False '--- informa se foi iniciada uma transaction local
        '
        ' VERIFY IF EXISTS TRANSACTION
        '----------------------------------------------------------------------------
        If Not db.isTransaction Then
            db.BeginTransaction()
            tranLocal = True
        End If
        '
        Dim myQuery As String = ""
        '
        '--- 1. DELETE MOVIMENTACAO
        '----------------------------------------------------------------------------
        db.LimparParametros()
        db.AdicionarParametros("@IDVenda", IDTransacao)
        '
        myQuery = "DELETE tblCaixaMovimentacao " &
                  "WHERE Origem = 1 AND IDOrigem = @IDVenda"
        '
        Try
            '--- execute query
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- 2. DELETE ARECEBER
        '----------------------------------------------------------------------------
        db.LimparParametros()
        db.AdicionarParametros("@IDTransacao", IDTransacao)
        db.AdicionarParametros("@Origem", Origem)
        '
        myQuery = "DELETE tblAReceber WHERE Origem = @Origem AND IDOrigem = @IDTransacao"
        '
        Try
            '
            '--- execute query
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        If tranLocal Then db.CommitTransaction()
        Return True
        '
    End Function
    '
    '===================================================================================================
    ' GET COBRANCA FORMAS DE ARECEBER
    '===================================================================================================
    Public Function CobrancaFormas_AReceber_GET() As DataTable
        Dim SQL As New SQLControl
        '
        Dim strSQL As String = "SELECT IDCobrancaForma, CobrancaForma FROM tblCobrancaForma WHERE Entradas = 'TRUE'"
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
    ' VERIFICA SITUACAO DA ORIGEM DO ARECEBER
    '===================================================================================================
    Public Function AReceber_VerificaSituacaoOrigem(myIDAReceber As Integer) As Byte
        '
        Dim db As New AcessoDados
        '
        db.AdicionarParametros("@IDAReceber", myIDAReceber)
        '
        Try
            Dim Sit As Byte
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspAReceber_VerificaSituacaoOrigem")
            '
            If dt.Rows.Count > 0 Then
                Sit = dt.Rows(0)("Retorno")
                Return Sit
            Else
                Throw New Exception("Não foi retornado nenhum resultado...")
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
'
'==========================================================================================
' CLASSE ARECEBER PARCELAS
'==========================================================================================
Public Class ParcelaBLL
    '
    '===================================================================================================
    ' OBTER PARCELAS POR IDORIGEM (IDTRANSACAO OU PARCELAMENTO)
    '===================================================================================================
    Public Function Parcela_GET_PorIDOrigem(Origem As Byte, IDOrigem As Integer) As List(Of clAReceberParcela)
        '
        Dim db As New AcessoDados
        Dim dt As New DataTable
        Dim ParcList As New List(Of clAReceberParcela)
        '
        '--- INSERT PARAMS
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDOrigem", IDOrigem)
        db.AdicionarParametros("@Origem", Origem)
        '
        '--- CREATE QUERY STRING
        Dim myQuery As String = "SELECT * FROM qryAReceberParcela WHERE IDOrigem = @IDOrigem AND Origem = @Origem"
        '
        Try
            '
            dt = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then Return ParcList
            '
            For Each r As DataRow In dt.Rows
                '
                Dim clPar As clAReceberParcela = Convert_DataRow_ClAReceberParcela(r)
                ParcList.Add(clPar)
                '
            Next
            '
            Return ParcList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' SALVAR NOVA PARCELA DA VENDA / TRANSACAO
    '===================================================================================================
    Public Function InserirNova_Parcela(clParcela As clAReceberParcela,
                                        Optional dbTran As Object = Nothing) As clAReceberParcela
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        Dim obj As Object = Nothing
        '
        db.LimparParametros()
        '
        With clParcela
            db.AdicionarParametros("@IDAReceber", .IDAReceber)
            db.AdicionarParametros("@IDPessoa", .IDPessoa)
            db.AdicionarParametros("@Letra", .Letra)
            db.AdicionarParametros("@Vencimento", .Vencimento)
            db.AdicionarParametros("@ParcelaValor", .ParcelaValor)
            db.AdicionarParametros("@PermanenciaTaxa", .PermanenciaTaxa)
        End With
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspAReceberParcela_Inserir")
            '
            If dt.Rows.Count > 0 Then
                Return Convert_DataRow_ClAReceberParcela(dt.Rows(0))
            Else
                Throw New Exception("Uma exceção desconhecida ocorreu ao inserir nova parcela...")
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' OBTER LISTA DE PARCELAS POR IDPESSOA
    '===================================================================================================
    Public Function Parcela_GET_PorIDPessoa(IDPessoa As Integer,
                                            Optional IDFilial As Integer? = Nothing,
                                            Optional Situacao As Byte? = Nothing) As List(Of clAReceberParcela)
        '
        Dim db As New AcessoDados
        Dim dt As New DataTable
        Dim ParcList As New List(Of clAReceberParcela)
        '
        Dim myQuery As String = "SELECT * FROM qryAReceberParcela " &
                                "WHERE IDPessoa = @IDPessoa "
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", IDPessoa)
        '
        If Not IsNothing(IDFilial) Then
            db.AdicionarParametros("@IDFilial", IDFilial)
            myQuery = myQuery + " AND IDFilial = @IDFilial"
        End If
        '
        If Not IsNothing(Situacao) Then
            db.AdicionarParametros("@Situacao", Situacao)
            myQuery = myQuery + " AND SituacaoParcela = @Situacao"
        End If
        '
        myQuery = myQuery + " ORDER BY Vencimento"
        '
        Try
            '
            dt = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then Return ParcList
            '
            For Each r As DataRow In dt.Rows
                Dim clPar As clAReceberParcela = Convert_DataRow_ClAReceberParcela(r)
                '
                ParcList.Add(clPar)
                '
            Next
            '
            Return ParcList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' EXCLUIR TODOS PARCELAS DE UM ARECEBER PELO IDARECEBER
    '===================================================================================================
    Public Function Excluir_Parcelas_AReceber(IDAReceber As Integer,
                                              Optional mydb As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(mydb, New AcessoDados)
        Dim myQuery As String = ""
        Dim lstMovs As List(Of clMovimentacao) = Nothing
        '
        '--- verifica MOVIMENTACAO CAIXA
        Try
            Dim movBLL As New MovimentacaoBLL
            lstMovs = movBLL.Movimentacao_GET_PorIDAReceber(IDAReceber)
            '
            If lstMovs.Count > 0 Then
                '
                If lstMovs.Where(Function(a) Not IsNothing(a.IDCaixa)).Count > 0 Then
                    Throw New Exception("Não é possível excluir parcelas que tem movimentações incluídas no Caixa...")
                End If
                '
                '--- exclui as movimentacoes
                For Each mov In lstMovs
                    movBLL.Movimentacao_Excluir(mov, db)
                Next
                '
            End If
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- exclui as parcelas
        db.LimparParametros()
        db.AdicionarParametros("@IDAReceber", IDAReceber)
        '
        myQuery = "DELETE tblAReceberParcela WHERE IDAReceber = @IDAReceber"
        '
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' QUITAR PARCELA TRANSACAO
    '===================================================================================================
    Public Function Quitar_Parcela(IDParcela As Integer,
                                   vlRecebido As Double,
                                   vlJuros As Double,
                                   EntradaData As Date,
                                   Optional dbTran As Object = Nothing) As Integer
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAReceberParcela", IDParcela)
            db.AdicionarParametros("@ValorRecebidoParcela", vlRecebido)
            db.AdicionarParametros("@ValorRecebidoJuros", vlJuros)
            db.AdicionarParametros("@EntradaData", EntradaData)
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAReceberParcela_Quitar")
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
    ' CANCELAR PARCELA TRANSACAO | VENDA
    '===================================================================================================
    Public Function Cancelar_Parcela(IDParcela As Integer) As Integer
        Dim db As New AcessoDados
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAReceberParcela", IDParcela)
            db.AdicionarParametros("@NovaSituacao", 2) '-- 2 : Situacao CANCELADA
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAReceberParcela_AlterarSituacao")
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
    ' NORMALIZAR PARCELA TRANSACAO | VENDA
    '===================================================================================================
    Public Function Normalizar_Parcela(IDParcela As Integer) As Integer
        Dim db As New AcessoDados
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAReceberParcela", IDParcela)
            db.AdicionarParametros("@NovaSituacao", 0) '-- 2 : Situacao CANCELADA
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspAReceberParcela_AlterarSituacao")
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
    ' ALTERAR VENCIMENTO PARCELA TRANSACAO | VENDA
    '===================================================================================================
    Public Function AlteraVencimento_Parcela(IDParcela As Integer, Vencimento As Date,
                                             Optional IDTransacao As Integer? = Nothing) As Boolean
        Dim SQL As New SQLControl
        Dim myStr As String
        '
        '--- verifica se a data da transação não é posterior à nova data
        '--- a parcela precisa ter uma data de vencimento após a data da transacao
        If Not IsNothing(IDTransacao) Then
            myStr = "SELECT TransacaoData FROM tblTransacao WHERE IDTransacao = " & IDTransacao
            SQL.ExecQuery(myStr)
            If SQL.DBDT.Rows.Count > 0 Then
                Dim TranData As Date = SQL.DBDT.Rows(0)("TransacaoData")
                '
                If TranData > Vencimento Then
                    Throw New Exception("A Data de Vencimento não pode ser ANTERIOR à" & vbNewLine &
                                        "DATA DA TRANSAÇÃO/VENDA: " & TranData.ToShortDateString)
                End If
                '
            End If
        End If
        '
        myStr = String.Format("UPDATE tblAReceberParcela SET Vencimento = '{0}' WHERE IDAReceberParcela = {1}",
                               Vencimento.Date.ToString("yyyy-MM-dd"),
                               IDParcela)
        '
        SQL.ExecQuery(myStr)
        '

        If SQL.HasException() Then
            Throw New Exception(SQL.Exception)
        Else
            Return True
        End If
        '
    End Function
    '
    '===================================================================================================
    ' ESTORNAR ENTRADA PARCELA TRANSACAO | VENDA
    '===================================================================================================
    Public Function EstornarEntradaParcela(myIDParcela As Integer, myIDEntrada As Integer) As clAReceberParcela
        '
        Dim db As New AcessoDados
        Dim dtPar As DataTable
        '
        Try
            db.LimparParametros()
            '
            db.AdicionarParametros("@IDAReceberParcela", myIDParcela)
            db.AdicionarParametros("@IDMovimentacao", myIDEntrada)
            '
            dtPar = db.ExecutarConsulta(CommandType.StoredProcedure, "uspAReceberParcela_Estornar")
            '
            '--- verifica se retornou alguma ROW
            If dtPar.Rows.Count = 0 Then
                Throw New Exception("Uma exceção inesperada ocorreu ao Estornar a Entrada/Parcela...")
            End If
            '
            '--- seleciona a ROW
            Dim r As DataRow = dtPar.Rows(0)
            '
            '--- verifica se o RETORNO é uma clParcela
            If dtPar.Columns.Count = 1 Then '--- se tem mais de uma coluna então é uma clParcela
                Throw New Exception(r(0))
            End If
            '
            '--- Preenche Nova clParcela com a DataROW
            '---------------------------------------------------------------------
            Dim clPar As clAReceberParcela = Convert_DataRow_ClAReceberParcela(r)
            '
            '--- Retorna
            Return clPar
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' CONVERT DATAROW IN CLARECEBERPARCELA
    '===================================================================================================
    Private Function Convert_DataRow_ClAReceberParcela(r As DataRow) As clAReceberParcela
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
        Return newParcela
        '
    End Function
    '
End Class
