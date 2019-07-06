Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient

Public Class UsuarioBLL
    '
    '--------------------------------------------------------------------------------------------------------------------
    ' GET LIST OF USUÁRIOS
    '--------------------------------------------------------------------------------------------------------------------
    Public Function GetUsuarios() As List(Of clUsuario)
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        strSql = "SELECT * FROM tblUsuario"
        '
        Try
            '
            Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
            Dim lista As New List(Of clUsuario)
            While dr.Read
                Dim usu As clUsuario = New clUsuario

                usu.IdUser = IIf(IsDBNull(dr("IdUser")), 0, dr("IdUser"))
                usu.UsuarioApelido = IIf(IsDBNull(dr("UsuarioApelido")), String.Empty, dr("UsuarioApelido"))
                usu.UsuarioAcesso = IIf(IsDBNull(dr("UsuarioAcesso")), Nothing, dr("UsuarioAcesso"))
                usu.UsuarioSenha = IIf(IsDBNull(dr("UsuarioSenha")), String.Empty, dr("UsuarioSenha"))
                usu.UsuarioAtivo = IIf(IsDBNull(dr("UsuarioAtivo")), Nothing, dr("UsuarioAtivo"))
                lista.Add(usu)

            End While

            '--- CLOSE DATAREADER
            dr.Close()

            '--- RETURN
            Return lista
            '
        Catch ex As Exception
            Throw ex
        Finally
            '
            '--- CLOSE DB CONNECTION
            objdb.CloseConn()
            '
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------------------------------
    ' UPDATE
    '--------------------------------------------------------------------------------------------------------------------
    Public Function AtualizaUsuario_Procedure_ID(ByVal _usuario As clUsuario) As Long
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand

        'Adiciona os Parâmetros
        Conn.Parameters.Add(New SqlParameter("@IdUser", _usuario.IdUser))
        Conn.Parameters.Add(New SqlParameter("@UsuarioApelido", _usuario.UsuarioApelido))
        Conn.Parameters.Add(New SqlParameter("@UsuarioAcesso", _usuario.UsuarioAcesso))
        Conn.Parameters.Add(New SqlParameter("@UsuarioSenha", _usuario.UsuarioSenha))
        Conn.Parameters.Add(New SqlParameter("@UsuarioAtivo", _usuario.UsuarioAtivo))

        Try
            Return objDB.ExecuteProcedureID("uspUsuario_Alterar", Conn.Parameters)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

    End Function
    '
    '--------------------------------------------------------------------------------------------------------------------
    ' SALVA NOVO USUÁRIO
    '--------------------------------------------------------------------------------------------------------------------
    Public Function SalvaNovoUsuario_Procedure_ID(ByVal _usuario As clUsuario) As Long
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand

        'Adiciona os Parâmetros
        Conn.Parameters.Add(New SqlParameter("@UsuarioApelido", _usuario.UsuarioApelido))
        Conn.Parameters.Add(New SqlParameter("@UsuarioAcesso", _usuario.UsuarioAcesso))
        Conn.Parameters.Add(New SqlParameter("@UsuarioSenha", _usuario.UsuarioSenha))
        Conn.Parameters.Add(New SqlParameter("@UsuarioAtivo", _usuario.UsuarioAtivo))

        Try
            Return objDB.ExecuteProcedureID("uspUsuario_Inserir", Conn.Parameters)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

    End Function
    '
    '--------------------------------------------------------------------------------------------------------------------
    ' DELETE
    '--------------------------------------------------------------------------------------------------------------------
    Public Function DeletaUsuario_PorID(ByVal _IdUser As Long) As Boolean
        Dim strSql As String
        Dim objDB As AcessoDados
        strSql = "DELETE FROM tblUsuario where IdUser=" & _IdUser
        objDB = New AcessoDados
        Try
            objDB.ExecuteQuery(strSql)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

        Return True
    End Function

End Class
