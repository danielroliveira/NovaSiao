Imports CamadaDAL
'
Public Class ClienteBLL
    '
    '===================================================================================================
    'GET CLIENTE ATIVIDADES | RETORNA DT
    '===================================================================================================
    Public Function GetClienteAtividades(Optional ClienteTipo As Boolean? = Nothing) As DataTable
        '
        Dim db As New AcessoDados
        Try
            Dim strSQL As String
            '
            If IsNothing(ClienteTipo) Then
                strSQL = "SELECT * FROM tblClienteAtividade"
            Else
                strSQL = "SELECT * FROM tblClienteAtividade WHERE ClienteTipo = '" & ClienteTipo.ToString & "'"
            End If
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, strSQL)
            '
            If dt.Rows.Count = 0 Then
                Throw New Exception("Não há nenhum registro de atividade...")
            End If
            '
            Return dt
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    'GET CLIENTE SITUACAO | RETORNA DT
    '===================================================================================================
    Public Function GetClienteSituacao() As DataTable
        '
        Dim db As New AcessoDados
        Try
            Dim strSQL As String
            strSQL = "SELECT * FROM tblClienteSituacao"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, strSQL)
            '
            If dt.Rows.Count = 0 Then
                Throw New Exception("Não há nenhum registro de SITUACAO de Cliente inserida...")
            End If
            '
            Return dt
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
