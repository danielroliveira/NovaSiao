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
    Public Function GetAuthorization(UsuarioApelido As String,
                                     UsuarioSenha As String,
                                     Optional UsuarioAcesso As EnumAcessoTipo = 3,
                                     Optional AuthDescription As String = "Acesso Login") As Object
        '
        Dim db As New AcessoDados
        db.LimparParametros()
        '
        db.AdicionarParametros("@UsuarioApelido", UsuarioApelido)
        db.AdicionarParametros("@UsuarioSenha", UsuarioSenha)
        db.AdicionarParametros("@UsuarioAcesso", UsuarioAcesso)
        db.AdicionarParametros("@AuthDescription", AuthDescription)
        db.AdicionarParametros("@AuthDate", Now)
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspUserGetAuthorization")
            '
            If dt.Rows.Count = 0 Then
                TentativasAcesso += 1
                Return Nothing
            Else
                Dim r As DataRow = dt.Rows(0)

                If r.ItemArray.Count = 1 Then
                    TentativasAcesso += 1
                    Return dt.Rows(0).Item(0)
                Else
                    Dim UsuarioAtual As New clUsuario With {
                    .IdUser = r("IdUser"),
                    .UsuarioAcesso = r("UsuarioAcesso"),
                    .UsuarioApelido = r("UsuarioApelido")
                    }
                    Return UsuarioAtual
                End If

            End If
            '
        Catch ex As Exception
            Return Nothing
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
