Imports CamadaDAL

Public Class BackupBLL
	Private db As New AcessoBackup
	'
	Public Function getBancodeDadosSQL() As String()
		'
		Try
			Return db.GetListaBancoDeDadosSQLSever
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	Public Function backupDatabase(backupFile As String, backupDir As String, tempDir As String) As Boolean
		'
		Try
			Return db.BackupDatabase(backupFile, backupDir, tempDir)
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	Public Function getPropriedades() As DataTable
		Dim dbDados As New AcessoDados
		Dim strSQL As String = "SELECT TOP 1 * FROM tblPropriedades"
		'
		Try
			Dim dt As DataTable = dbDados.ExecutarConsulta(CommandType.Text, strSQL)
			'
			If dt.Rows.Count = 0 Then
				Throw New Exception("Não foi encontrado nenhuma propriedade definida. Comunique ao adminisrtador do sistema...")
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
