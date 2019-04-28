Imports CamadaDAL
'
Public Class FilialBLL
    '---------------------------------------------------------------------------------------------------
    ' GET DATABLE
    '---------------------------------------------------------------------------------------------------
    Public Function GetFiliais(Optional SomenteAtivas As Boolean = False) As DataTable
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        If SomenteAtivas = False Then
            strSql = "SELECT * FROM tblPessoaFilial"
        ElseIf SomenteAtivas = True Then
            strSql = "SELECT * FROM tblPessoaFilial WHERE Ativo = 1"
        End If
        '
        Try
            Return objdb.ExecuteConsultaSQL_DataTable(strSql)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------
    ' SALVAR FILIAL
    '---------------------------------------------------------------------------------------------------
    Public Function InsertFilial(Apelido As String, Aliquota As Double?) As Object
        Dim db As New AcessoDados
        '
        Try
            '
            db.LimparParametros()
            '
            db.AdicionarParametros("@ApelidoFilial", Apelido)
            db.AdicionarParametros("@AliquotaICMS", IIf(IsNothing(Aliquota), 0, Aliquota))
            '
            Return db.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoaFilial_Inserir")
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------
    ' ATUALIZAR FILIAL
    '---------------------------------------------------------------------------------------------------
    Public Function UpdateFilial(myID As Integer, Apelido As String, Ativo As Boolean) As Object
        Dim db As New AcessoDados
        '
        Try
            db.LimparParametros()
            db.AdicionarParametros("@IDFilial", myID)
            db.AdicionarParametros("@ApelidoFilial", Apelido)
            db.AdicionarParametros("@Ativo", Ativo)
            db.AdicionarParametros("@AliquotaICMS", 0)
            '
            Return db.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoaFilial_Alterar")
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function

End Class
