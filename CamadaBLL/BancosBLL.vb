Imports CamadaDAL
'
Public Class BancosBLL
    Public Function GetBancosDt(Optional SomenteAtivo As Boolean = False) As DataTable
        Dim db As New AcessoDados
        Dim sqlDB As String = ""
        '
        If SomenteAtivo = False Then
            sqldb = "SELECT * FROM tblBancos"
        Else
            sqlDB = "SELECT * FROM tblBancos WHERE Ativo = 'TRUE'"
        End If
        '
        Return db.ExecutarConsulta(CommandType.Text, sqlDB)
        '
    End Function
End Class
