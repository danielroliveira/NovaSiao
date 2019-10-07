Imports CamadaDTO
Imports CamadaDAL
'
Public Class UsuarioBLL
    '
    '--------------------------------------------------------------------------------------------------------------------
    ' GET LIST OF USUÁRIOS
    '--------------------------------------------------------------------------------------------------------------------
    Public Function GetUsuarios() As List(Of clUsuario)
        Dim objdb As New AcessoDados
		'
		Dim query As String = "SELECT * FROM tblUsuario"
		'
		Try
			'
			Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, query)
			Dim lista As New List(Of clUsuario)
			'
			If dt.Rows.Count = 0 Then Return lista
			'
			For Each r In dt.Rows
				Dim usu As clUsuario = New clUsuario
				'
				usu.IdUser = IIf(IsDBNull(r("IdUser")), 0, r("IdUser"))
				usu.UsuarioApelido = IIf(IsDBNull(r("UsuarioApelido")), String.Empty, r("UsuarioApelido"))
				usu.UsuarioAcesso = IIf(IsDBNull(r("UsuarioAcesso")), Nothing, r("UsuarioAcesso"))
				usu.UsuarioSenha = IIf(IsDBNull(r("UsuarioSenha")), String.Empty, r("UsuarioSenha"))
				usu.UsuarioAtivo = IIf(IsDBNull(r("UsuarioAtivo")), Nothing, r("UsuarioAtivo"))
				lista.Add(usu)
				'
			Next
			'
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
	Public Function AtualizaUsuario_ID(ByVal _usuario As clUsuario) As Long
		'
		Dim objDB As New AcessoDados
		Dim query As String = "UPDATE tblUsuario SET " &
							  "UsuarioApelido = @UsuarioApelido, " &
							  "UsuarioAcesso = @UsuarioAcesso, " &
							  "UsuarioSenha = @UsuarioSenha, " &
							  "UsuarioAtivo = @UsuarioAtivo " &
							  "WHERE IdUser = @IdUser;"
		'
		'Adiciona os Parâmetros
		objDB.AdicionarParametros("@IdUser", _usuario.IdUser)
		objDB.AdicionarParametros("@UsuarioApelido", _usuario.UsuarioApelido)
		objDB.AdicionarParametros("@UsuarioAcesso", _usuario.UsuarioAcesso)
		objDB.AdicionarParametros("@UsuarioSenha", _usuario.UsuarioSenha)
		objDB.AdicionarParametros("@UsuarioAtivo", _usuario.UsuarioAtivo)
		'
		Try
			objDB.ExecutarManipulacao(CommandType.Text, query)
			'
			Return _usuario.IdUser
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'--------------------------------------------------------------------------------------------------------------------
	' SALVA NOVO USUÁRIO
	'--------------------------------------------------------------------------------------------------------------------
	Public Function SalvaNovoUsuario_ID(ByVal _usuario As clUsuario) As Long
		'
		Dim objDB As New AcessoDados
		Dim query As String = "INSERT INTO tblUsuario " &
							  "(UsuarioApelido, UsuarioAcesso, UsuarioSenha, UsuarioAtivo) " &
							  "VALUES " &
							  "(@UsuarioApelido, @UsuarioAcesso, @UsuarioSenha, @UsuarioAtivo);"
		'
		'Adiciona os Parâmetros
		objDB.AdicionarParametros("@UsuarioApelido", _usuario.UsuarioApelido)
		objDB.AdicionarParametros("@UsuarioAcesso", _usuario.UsuarioAcesso)
		objDB.AdicionarParametros("@UsuarioSenha", _usuario.UsuarioSenha)
		objDB.AdicionarParametros("@UsuarioAtivo", _usuario.UsuarioAtivo)
		'
		Try
			'
			Return objDB.ExecutarInsertGetID(query)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
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
