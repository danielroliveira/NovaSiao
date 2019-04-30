Imports CamadaDAL
Imports CamadaDTO
'
Public Class AcessoControlBLL
    '
    Property TentativasAcesso As Integer = 0
    '
    Sub New()
        TentativasAcesso = 0
    End Sub
    '
    '--------------------------------------------------------------------------------------------
    ' GET NEW LOGIN ACESSO
    '--------------------------------------------------------------------------------------------
    Public Function GetNewLoginAcesso(login As String, senha As String) As clUsuario
        '
        Dim db As New AcessoDados
        db.LimparParametros()
        '
        db.AdicionarParametros("@UsuarioApelido", login)
        db.AdicionarParametros("@UsuarioSenha", senha)
        '
        Dim myQuery As String = "SELECT TOP 1 * FROM tblUsuario " &
                                "WHERE UsuarioApelido = @UsuarioApelido " &
                                "AND UsuarioSenha = @UsuarioSenha COLLATE Latin1_General_CS_AS;"
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then
                TentativasAcesso += 1
                Return Nothing
            Else
                Dim r As DataRow = dt.Rows(0)
                Dim UsuarioAtual As New clUsuario With {
                    .IdUser = r("IdUser"),
                    .UsuarioAcesso = r("UsuarioAcesso"),
                    .UsuarioApelido = r("UsuarioApelido")
                    }
                Return UsuarioAtual
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' SAVE STRING CONNECTION
    '--------------------------------------------------------------------------------------------
    Public Function SaveConnString(SourceXMLFile As String, stringName As String) As Boolean
        '
        Try
            Dim conn As New GetConnection
            conn.SaveConnectionStringLocation(SourceXMLFile, stringName)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET STRING CONNECTION TO VISUALIZATION
    '--------------------------------------------------------------------------------------------
    Public Function GetConString() As String
        '
        Try
            Dim con As String = If(AcessoDados.GetConnectionString, "")
            Return con
        Catch ex As Exception
            Return Nothing
        End Try
        '
    End Function
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
