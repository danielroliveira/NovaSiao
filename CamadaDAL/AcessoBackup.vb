Imports System.Data.SqlClient
Imports System.IO
'
Public Class AcessoBackup
    '
    Private Function getMasterStringConexao() As String
        '
        Dim conStr As String = AcessoDados.GetConnectionString
        Dim strRetorno As String = conStr.Replace(getDatabaseName, "Master")
        '
        Return strRetorno
        '
    End Function
    '
    Private Function getDatabaseName() As String
        '
        Dim conStr As String = AcessoDados.GetConnectionString
        '
        Dim lInicio As Integer = conStr.IndexOf("Catalog", 0)
        lInicio = lInicio + 8
        '
        Dim lFim As Integer = conStr.IndexOfAny(";", lInicio)
        Dim DataBaseName As String = conStr.Substring(lInicio, lFim - lInicio)
        '
        Return DataBaseName
        '
    End Function
    '
    Public Function GetListaBancoDeDadosSQLSever() As String()
        '
        'Dim conexaoSQLServer As String = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Master"
        Dim cn As New SqlConnection(getMasterStringConexao)

        Dim dbLista As New ArrayList
        ' retorn o nome de todos os banco de dados da tabela sysdatabases em MASTER
        Dim cmd As New SqlCommand("SELECT [name] FROM sysdatabases", cn)
        Dim reader As SqlDataReader
        cn.Open()
        '
        Try
            reader = cmd.ExecuteReader()
            '
            While reader.Read()
                ' inclui o nome no arraylist
                dbLista.Add(reader("name"))
            End While
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
        End Try
        '
        ' retorna o array de strings 
        Return dbLista.ToArray(GetType(String))
        '
    End Function
    '
    Public Function BackupDatabase(ByVal backupFileName As String, backupDir As String, tempDir As String) As Boolean
        '
        'Dim conexaoSQLServer As String = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Master"
        Dim cn As New SqlConnection(getMasterStringConexao)
        '
        Try
            '
            '--- verifica se o diretorio existe
            If Not Directory.Exists(tempDir) Then
                Throw New Exception("Diretório não encontrado")
                Return False
            End If
            '
            '--- cria o nome completo do arquivo de Backup
            Dim NomeCompleto As String = Path.Combine(tempDir, backupFileName) & ".bak"
            '
            ' comando para fazer o backup do Banco de dados
            Dim strSQLCommand As String = "BACKUP DATABASE [" & getDatabaseName() & "] TO DISK='" & NomeCompleto & "'" ', WITH FORMAT;" ', MEDIANAME = 'NovaSiaoMedia', MEDIADESCRIPTION = 'NovaSiao Backup';"
            '
            Dim cmdBackup As New SqlCommand(strSQLCommand, cn)
            cn.Open()
            cmdBackup.ExecuteNonQuery()
            '
            '--- copia o arquivo do DirTemp para o diretorio de Backup Padrão
            Dim TempDirBackup As String = backupDir & "\TempBackup\"
            MkDir(TempDirBackup)
            File.Copy(NomeCompleto, Path.Combine(TempDirBackup, backupFileName) & ".bak", True)
            '
            '--- salva a ultima data de Backup no tblPropriedades
            Dim db As New AcessoDados
            '
            Dim sqlProp As String = String.Format("UPDATE tblPropriedades SET BackupData = '{0}'", Today)
            db.ExecutarConsulta(CommandType.Text, sqlProp)
            '
            '--- retorna
            Return True
            '
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
        End Try
        '
    End Function
    '
    Public Function RestauraDatabase(ByVal nomeDB As String, ByVal backupFile As String) As Boolean
        '
        'Dim conexaoSQLServer As String = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Master"
        Dim cn As New SqlConnection(getMasterStringConexao)
        '
        Try
            'comando para restaurar o banco de dados
            Dim cmdBackup As New SqlCommand("RESTORE DATABASE [" & nomeDB & "] FROM DISK = '" & backupFile & "'", cn)
            cn.Open()
            cmdBackup.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
        End Try
    End Function
    '
End Class
