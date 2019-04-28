Imports CamadaDAL

Public Class ObservacaoBLL
    '
    'Origem OrigemDescricao
    '------ --------------------------------------------------
    '1      tblTransacao
    '2      tblPessoa
    '3      tblCaixaMovimentacao
    '5      tblCaixa
    '6      tblReserva
    '7      tblPedido
    '8      tblTroca
    '9      tblVenda
    '10     tblSimplesSaida
    '11     tblSimplesEntrada
    '12     tblDevolucaoSaida
    '13     tblCaixaTransferencia
    '
    '===============================================================================
    ' SAVE NEW OBSERVACAO
    '===============================================================================
    Public Function SaveObservacao(Origem As Byte,
                                   IDOrigem As Integer,
                                   Observacao As String,
                                   Optional dbTran As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        Dim tranInterna As Boolean = False
        '
        If Not db.isTransaction Then
            db.BeginTransaction()
            tranInterna = True
        End If
        '
        Dim myQuery As String = ""
        '
        Try
            '--- DELETE old OBSERVACAO
            DeleteObservacao(Origem, IDOrigem)
            '
            '--- Verifica se existe observacao, se nao return TRUE
            If Observacao.Trim.Length = 0 Then
                '--- COMMIT
                If tranInterna Then
                    db.CommitTransaction()
                End If
                '
                Return True
                '
            End If
            '
            '--- INSERT NEW DETERMINA OS PARAMETROS
            db.LimparParametros()
            db.AdicionarParametros("@Origem", Origem)
            db.AdicionarParametros("@IDOrigem", IDOrigem)
            db.AdicionarParametros("@Observacao", Observacao)
            '
            '--- INSERE A NOVA OBSERVACAO
            myQuery = "INSERT INTO tblObservacao (IDOrigem, Origem, Observacao) VALUES (@IDOrigem, @Origem, @Observacao);"
            '
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- COMMIT
            If tranInterna Then
                db.CommitTransaction()
            End If
            '
            Return True
            '
        Catch ex As Exception
            '--- ROLLBACK
            If tranInterna Then
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
    ' DELETE OBSERVACAO
    '==========================================================================================
    Public Function DeleteObservacao(Origem As Byte,
                                     IDOrigem As Integer,
                                     Optional dbTran As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        Try
            '
            '--- DELETE OBSERVACAO
            db.LimparParametros()
            db.AdicionarParametros("@Origem", Origem)
            db.AdicionarParametros("@IDOrigem", IDOrigem)
            '
            Dim myQuery As String = "DELETE tblObservacao WHERE Origem = @Origem AND IDOrigem = @IDOrigem"
            '
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
End Class
