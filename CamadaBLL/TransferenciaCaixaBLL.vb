Imports CamadaDAL
Imports CamadaDTO

Public Class TransferenciaCaixaBLL
    '
    '============================================================================================
    ' INSERT NOVA TRANSFERENCIA E RETORNA UM CLTRANSFERENCIA
    '============================================================================================
    Public Function InserirNova_Transferencia(Transf As clTransferenciaCaixa,
                                              Optional dbTran As Object = Nothing) As clTransferenciaCaixa

        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        Dim myQuery As String = ""
        '
        '--- INICIA UMA TRANSACAO SE NECESSARIO
        '---------------------------------------------------------------------------------------------
        Dim tranInterna As Boolean = False
        '
        If Not db.isTransaction Then
            db.BeginTransaction()
            tranInterna = True
        End If
        '
        '--- INSERT A TRANSFERENCIA DE CAIXA
        '---------------------------------------------------------------------------------------------
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDContaDebito", Transf.IDContaDebito)
        db.AdicionarParametros("@IDContaCredito", Transf.IDContaCredito)
        db.AdicionarParametros("@TransferenciaData", Transf.TransferenciaData)
        db.AdicionarParametros("@TransferenciaValor", Transf.TransferenciaValor)
        db.AdicionarParametros("@ComissaoValor", Transf.ComissaoValor)
        db.AdicionarParametros("@IDCaixa", If(Transf.IDCaixa, DBNull.Value))
        '
        myQuery = "INSERT INTO tblCaixaTransferencia" &
                  "(IDContaDebito, IDContaCredito, TransferenciaData, TransferenciaValor, ComissaoValor, IDCaixa)" &
                  "VALUES(@IDContaDebito, @IDContaCredito, @TransferenciaData, @TransferenciaValor, @ComissaoValor, @IDCaixa)"
        '
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- Get IDENTITY
            db.LimparParametros()
            Transf.IDTransferencia = db.ExecutarConsulta(CommandType.Text, "SELECT @@IDENTITY As LastID;").Rows(0)(0)
            '
        Catch ex As Exception
            If tranInterna Then db.RollBackTransaction()
            Throw New Exception("Uma exceção ocorreu ao Inserir uma Nova Tranferência..." & vbNewLine & vbNewLine &
                                ex.Message)
        End Try
        '
        '--- INSERT A OBSERVACAO IF NECESSARY
        '---------------------------------------------------------------------------------------------
        If Not IsNothing(Transf.Observacao) AndAlso Transf.Observacao.Trim.Length > 0 Then
            '
            Dim oBLL As New ObservacaoBLL
            '
            Try
                oBLL.SaveObservacao(13, Transf.IDTransferencia, Transf.Observacao, db)
            Catch ex As Exception
                If tranInterna Then db.RollBackTransaction()
                Throw New Exception("Uma exceção ocorreu ao Inserir uma Nova Observação..." & vbNewLine & vbNewLine &
                                    ex.Message)
            End Try
            '
        End If
        '
        '--- INSERT A MOVIMENTACAO DE SAIDA
        '---------------------------------------------------------------------------------------------
        Dim mBLL As New MovimentacaoBLL
        Dim movSaida As New clMovimentacao(EnumMovimentacaoOrigem.Transferencia, EnumMovimento.Transferencia)
        '
        movSaida.IDConta = Transf.IDContaDebito
        movSaida.Creditar = False
        movSaida.Descricao = "Débito de Transferencia para Conta: " & Transf.ContaCredito
        movSaida.IDFilial = Transf.IDFilial
        movSaida.IDMeio = Transf.IDMeio
        movSaida.MovData = Transf.TransferenciaData
        movSaida.Movimento = 4 '--- transferencia de Saida (TS)
        movSaida.MovValor = Transf.TransferenciaValor
        movSaida.IDOrigem = Transf.IDTransferencia '--- IDTranferencia
        movSaida.Origem = 11 '--- tblCaixaTransferencia
        movSaida.IDCaixa = Transf.IDCaixa '--> somente insere a saida no caixa
        '
        Try
            movSaida = mBLL.Movimentacao_Inserir(movSaida, db)
        Catch ex As Exception
            If tranInterna Then db.RollBackTransaction()
            Throw New Exception("Uma exceção ocorreu ao Inserir uma Nova Movimentação..." & vbNewLine & vbNewLine &
                                ex.Message)
        End Try
        '
        '--- INSERT A MOVIMENTACAO DE CREDITO
        '---------------------------------------------------------------------------------------------
        Dim movEntrada As New clMovimentacao(EnumMovimentacaoOrigem.Transferencia, EnumMovimento.Transferencia)
        '
        movEntrada.IDConta = Transf.IDContaCredito
        movEntrada.Creditar = False
        movEntrada.Descricao = "Crédito de Transferencia da Conta: " & Transf.ContaDebito
        movEntrada.IDFilial = Transf.IDFilial
        movEntrada.IDMeio = Transf.IDMeio
        movEntrada.MovData = Transf.TransferenciaData
        movEntrada.Movimento = 3 '--- transferencia de Entrada (TE)
        movEntrada.MovValor = Transf.TransferenciaValor - Transf.ComissaoValor
        movEntrada.IDOrigem = Transf.IDTransferencia '--- IDTranferencia
        movEntrada.Origem = 11 '--- tblCaixaTransferencia
        'movEntrada.IDCaixa = Transf.IDCaixa '--> nao insere a entrada no caixa recebido
        '
        Try
            movEntrada = mBLL.Movimentacao_Inserir(movEntrada, db)
        Catch ex As Exception
            If tranInterna Then db.RollBackTransaction()
            Throw New Exception("Uma exceção ocorreu ao Inserir uma Nova Movimentação..." & vbNewLine & vbNewLine &
                                ex.Message)
        End Try
        '
        '--- UPDATE TBLTRANSFERENCIA WITH IDMOVCREDITO AND IDMOVDEBITO
        '---------------------------------------------------------------------------------------------
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDTransferencia", Transf.IDTransferencia)
        db.AdicionarParametros("@IDMovDebito", movSaida.IDMovimentacao)
        db.AdicionarParametros("@IDMovCredito", movEntrada.IDMovimentacao)
        '
        myQuery = "UPDATE tblCaixaTransferencia SET " &
                  "IDMovDebito = @IDMovDebito, IDMovCredito = @IDMovCredito " &
                  "WHERE IDTransferencia = @IDTransferencia"
        '
        Try
            '
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            If tranInterna Then db.CommitTransaction()
            Return Transf
            '
        Catch ex As Exception
            If tranInterna Then db.RollBackTransaction()
            Throw New Exception("Uma exceção ocorreu ao Inserir uma Nova Tranferência..." & vbNewLine & vbNewLine &
                                ex.Message)
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET LIST OF TRANSFERENCIAS
    '==========================================================================================
    Public Function GetTransferenciasLista_Procura(myIDContaDebito As Int16,
                                                   Optional dtInicial As Date? = Nothing,
                                                   Optional dtFinal As Date? = Nothing,
                                                   Optional NotTransfCaixa As Boolean = True) As List(Of clTransferenciaCaixa)
        '
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDContaDebito", myIDContaDebito)
        Dim myQuery As String = "SELECT * FROM qryCaixaTransferencia WHERE IDContaDebito = @IDContaDebito"
        '
        If NotTransfCaixa = True Then
            myQuery = myQuery & " AND IDCaixa IS NULL"
        End If
        '
        If Not IsNothing(dtInicial) Then
            '
            db.AdicionarParametros("@DataInicial", dtInicial)
            myQuery = myQuery & " AND TransferenciaData >= @DataInicial"
            '
        End If
        '
        If Not IsNothing(dtFinal) Then
            '
            db.AdicionarParametros("@DataFinal", dtFinal)
            myQuery = myQuery & " AND TransferenciaData <= @DataFinal"
            '
        End If
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            Dim tList As New List(Of clTransferenciaCaixa)
            '
            If dt.Rows.Count = 0 Then Return tList
            '
            For Each r In dt.Rows
                '
                tList.Add(Convert_DtRow_clTransferencia(r))
                '
            Next
            '
            Return tList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' CONVERTER DTROW EM CLTRANSFERENCIA
    '==========================================================================================
    Private Function Convert_DtRow_clTransferencia(r As DataRow) As clTransferenciaCaixa
        '
        Dim clT As New clTransferenciaCaixa
        '
        Try
            '
            clT.IDTransferencia = If(IsDBNull(r("IDTransferencia")), Nothing, r("IDTransferencia"))
            clT.IDFilial = If(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
            clT.ApelidoFilial = If(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
            clT.TransferenciaData = If(IsDBNull(r("TransferenciaData")), Nothing, r("TransferenciaData"))
            clT.TransferenciaValor = If(IsDBNull(r("TransferenciaValor")), Nothing, r("TransferenciaValor"))
            clT.ComissaoValor = If(IsDBNull(r("ComissaoValor")), Nothing, r("ComissaoValor"))
            clT.Observacao = If(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
            clT.IDMeio = If(IsDBNull(r("IDMeio")), Nothing, r("IDMeio"))
            clT.Meio = If(IsDBNull(r("Meio")), String.Empty, r("Meio"))
            clT.IDCaixa = If(IsDBNull(r("IDCaixa")), Nothing, r("IDCaixa"))
            '
            clT.IDContaDebito = If(IsDBNull(r("IDContaDebito")), Nothing, r("IDContaDebito"))
            clT.ContaDebito = If(IsDBNull(r("ContaDebito")), String.Empty, r("ContaDebito"))
            clT.IDMovDebito = If(IsDBNull(r("IDMovDebito")), Nothing, r("IDMovDebito"))
            '
            clT.IDContaCredito = If(IsDBNull(r("IDContaCredito")), Nothing, r("IDContaCredito"))
            clT.ContaCredito = If(IsDBNull(r("ContaCredito")), String.Empty, r("ContaCredito"))
            clT.IDMovCredito = If(IsDBNull(r("IDMovCredito")), Nothing, r("IDMovCredito"))
            '
            Return clT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EXCLUIR TRANSFERENCIA
    '==========================================================================================
    Public Function Excluir_Transferencia(Transf As clTransferenciaCaixa,
                                          Optional dbTran As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- create TRANSACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        Dim tranInterna As Boolean = False
        '
        If Not db.isTransaction Then
            tranInterna = True
            db.BeginTransaction()
        End If
        '
        '--- get MOVIMENTACAO
        '----------------------------------------------------------------------------------
        Dim lstMovs As List(Of clMovimentacao) = Nothing
        Dim movBLL As New MovimentacaoBLL
        lstMovs = movBLL.Movimentacao_GET_PorOrigemID(EnumMovimentacaoOrigem.Transferencia, Transf.IDTransferencia)
        '
        '--- DELETE OBSERVACAO
        '----------------------------------------------------------------------------------
        Try
            Dim oBLL As New ObservacaoBLL
            '
            oBLL.DeleteObservacao(13, Transf.IDTransferencia)
            '
        Catch ex As Exception
            '
            If tranInterna Then db.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '--- DELETE TRANSFERENCIA
        '----------------------------------------------------------------------------------
        Try
            '
            '--- DELETE OBSERVACAO
            db.LimparParametros()
            db.AdicionarParametros("@IDTransferencia", Transf.IDTransferencia)
            '
            Dim myQuery As String = "DELETE tblCaixaTransferencia WHERE IDTransferencia = @IDTransferencia"
            '
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
        Catch ex As Exception
            '
            If tranInterna Then db.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
        '--- DELETE MOVIMENTACAO CAIXA
        Try
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
            If tranInterna Then db.CommitTransaction()
            Return True
            '
        Catch ex As Exception
            '
            If tranInterna Then db.RollBackTransaction()
            Throw ex
            Return False
            '
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EXCLUIR TRANSFERENCIAS DE CAIXA
    '==========================================================================================
    Public Function Excluir_Transferencias_deCaixa(IDCaixa As Integer, dbTran As Object) As Boolean
        '
        Dim db As AcessoDados = dbTran
        '
        '--- Get ALL Transferencias of Caixa
        db.LimparParametros()
        db.AdicionarParametros("@IDCaixa", IDCaixa)
        '
        Dim query As String = "SELECT * FROM qryCaixaTransferencia WHERE IDCaixa = @IDCaixa"
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            '--- verifica se existe alguma transferecia ligada ao IDCaixa
            If dt.Rows.Count = 0 Then Return True
            '
            For Each r In dt.Rows
                '
                '--- converter row em clTransferencia
                Dim Transf As clTransferenciaCaixa = Convert_DtRow_clTransferencia(r)
                '
                '--- excluir cada transferencia
                Excluir_Transferencia(Transf, db)
                '
            Next
            '
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
