Imports CamadaDAL

Public Class TransactionControlBLL
    '
    '--------------------------------------------------------------------------------------------
    ' GET ACESSO + TRANSACTION
    '--------------------------------------------------------------------------------------------
    Public Function GetNewAcessoWithTransaction() As Object
        '
        Dim myDB As New AcessoDados
        myDB.BeginTransaction()
        '
        '--- return
        Return myDB
        '
    End Function
    '    
    '--------------------------------------------------------------------------------------------
    ' COMMIT ACESSO + TRANSACTION 
    '--------------------------------------------------------------------------------------------
    Public Function CommitAcessoWithTransaction(myDB As Object) As Boolean
        '
        If myDB.GetType Is GetType(AcessoDados) Then
            '
            DirectCast(myDB, AcessoDados).CommitTransaction()
            Return True
            '
        Else
            Return False
        End If
        '
    End Function
    '    
    '--------------------------------------------------------------------------------------------
    ' ROLLBACK ACESSO + TRANSACTION 
    '--------------------------------------------------------------------------------------------
    Public Function RollbackAcessoWithTransaction(myDB As Object) As Boolean
        '
        If myDB.GetType Is GetType(AcessoDados) Then
            '
            DirectCast(myDB, AcessoDados).RollBackTransaction()
            Return True
            '
        Else
            Return False
        End If
        '
    End Function
    '
End Class
