Imports CamadaDAL

Public Class ClienteReferenciaBLL
    '
    '==========================================================================================
    ' GET REFERENCIAS DO CLIENTE PELO IDPESSOA
    '==========================================================================================
    Public Function ClienteReferencia_GET_PorID(myID As Integer) As DataTable
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDCliente", myID)
        '
        Dim myQuery As String = "SELECT * FROM tblClienteReferencia WHERE IDCliente = @IDCliente"
        '
        Try
            Return db.ExecutarConsulta(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' SALVA REFERENCIAS DO CLIENTE
    '==========================================================================================
    Public Function ClienteReferencia_INSERT(myID As Integer, tblRefs As DataTable) As Boolean
        '
        '--- Apaga todas as referências anteriores do Cliente
        Dim db As New AcessoDados
        '
        'inicia um transacao
        db.BeginTransaction()
        '
        '--- create Query
        Dim myQuery As String = "INSERT INTO tblClienteReferencia " &
                                "(IDCliente, ReferenciaNome, Afinidade, ReferenciaTelefone) " &
                                "VALUES " &
                                "(@IDCliente, @ReferenciaNome, @Afinidade, @ReferenciaTelefone)"
        '
        Try
            '--- apaga todas as referencias anteriores do Cliente
            DeleteAllReferenciasByID(myID, db)
            '
            '--- verifica se existe algum ROW no tblRefs
            If IsNothing(tblRefs) OrElse tblRefs.Rows.Count = 0 Then
                Return True
            End If
            '
            ' se houver pelo menos um ROW então insere na tabela
            For Each r As DataRow In tblRefs.Rows
                '
                '--- Limpa os parametros
                db.LimparParametros()
                '
                ' ADICIONA OS PARÂMETROS
                db.AdicionarParametros("@IDCliente", myID)
                db.AdicionarParametros("@ReferenciaNome", r("ReferenciaNome"))
                db.AdicionarParametros("@Afinidade", r("Afinidade"))
                db.AdicionarParametros("@ReferenciaTelefone", r("ReferenciaTelefone"))

                'PARA UM REGISTRO NOVO - INSERT
                db.ExecutarManipulacao(CommandType.Text, myQuery)
                '
            Next
            '
            '--- Commit Transaction
            db.CommitTransaction()
            Return True
            '
        Catch ex As Exception
            db.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' DELETE ALL REFERENCIA BY ID CLIENTE
    '==========================================================================================
    Private Sub DeleteAllReferenciasByID(IDCliente As Integer, Optional dbTran As AcessoDados = Nothing)
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDCliente", IDCliente)
        '
        Dim myQuery As String = "DELETE tblClienteReferencia WHERE IDCliente = @IDCliente"
        '
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
End Class
