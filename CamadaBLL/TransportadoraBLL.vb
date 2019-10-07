Imports CamadaDTO
Imports CamadaDAL
'
Public Class TransportadoraBLL
    '
    '-----------------------------------------------------------------------------------------------------
    ' GET DATATABLE SIMPLES DE TRANSPORTADORAS PARA COMBO
    '-----------------------------------------------------------------------------------------------------
    Public Function Transportadora_GET_ListaSimples(Optional Ativo As Boolean? = Nothing) As DataTable
        Dim db As New AcessoDados
		'
		Dim query As String = "SELECT IDTransportadora, P.Cadastro " &
							  "FROM tblPessoaTransportadora AS T " &
							  "JOIN tblPessoa AS P ON T.IDTransportadora = P.IDPessoa "
		'
		If Not IsNothing(Ativo) Then
			db.LimparParametros()
			db.AdicionarParametros("@Ativo", Ativo)
			query += "WHERE Ativo = @Ativo"
		End If
		'
		Try
			Return db.ExecutarConsulta(CommandType.Text, query)
		Catch ex As Exception
			Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------
    ' GET LISTA COMPLETA COM FILTRO OPCIONAL DE ATIVO
    '-----------------------------------------------------------------------------------------------------
    Public Function GetTransportadoras(Optional Ativo As Boolean? = Nothing) As List(Of clTransportadora)
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        If IsNothing(Ativo) Then
            strSql = "SELECT * FROM qryTransportadoras"
        Else
            strSql = "SELECT * FROM qryTransportadoras WHERE Ativo = '" & Ativo & "'"
        End If
        '
        Try
			'
			Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
			Dim lista As New List(Of clTransportadora)
			'
			For Each dr In dt.Rows
				Dim tran As New clTransportadora
				'
				tran.IDPessoa = IIf(IsDBNull(dr("IDTransportadora")), Nothing, dr("IDTransportadora"))
				tran.Ativo = IIf(IsDBNull(dr("Ativo")), 0, dr("Ativo"))
				tran.Observacao = IIf(IsDBNull(dr("Observacao")), String.Empty, dr("Observacao"))
				'
				tran.Cadastro = IIf(IsDBNull(dr("Cadastro")), String.Empty, dr("Cadastro"))
				tran.NomeFantasia = IIf(IsDBNull(dr("NomeFantasia")), String.Empty, dr("NomeFantasia"))
				tran.Endereco = IIf(IsDBNull(dr("Endereco")), String.Empty, dr("Endereco"))
				tran.Bairro = IIf(IsDBNull(dr("Bairro")), String.Empty, dr("Bairro"))
				tran.Cidade = IIf(IsDBNull(dr("Cidade")), String.Empty, dr("Cidade"))
				tran.UF = IIf(IsDBNull(dr("UF")), String.Empty, dr("UF"))
				tran.CEP = IIf(IsDBNull(dr("CEP")), String.Empty, dr("CEP"))
				tran.TelefoneA = IIf(IsDBNull(dr("TelefoneA")), String.Empty, dr("TelefoneA"))
				tran.TelefoneB = IIf(IsDBNull(dr("TelefoneB")), String.Empty, dr("TelefoneB"))
				tran.Email = IIf(IsDBNull(dr("Email")), String.Empty, dr("Email"))
				tran.CNPJ = IIf(IsDBNull(dr("CNPJ")), String.Empty, dr("CNPJ"))
				tran.InscricaoEstadual = IIf(IsDBNull(dr("InscricaoEstadual")), String.Empty, dr("InscricaoEstadual"))
				tran.ContatoNome = IIf(IsDBNull(dr("ContatoNome")), String.Empty, dr("ContatoNome"))
				tran.FundacaoData = IIf(IsDBNull(dr("FundacaoData")), Nothing, dr("FundacaoData"))
				lista.Add(tran)
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
    '-----------------------------------------------------------------------------------------------------
    ' GET TRANSPORTADORA PELO CNP
    '-----------------------------------------------------------------------------------------------------
    Public Function GetTransportadoraByCNPJ(CNPJ As String,
                                            Optional dbTran As Object = Nothing) As List(Of clTransportadora)
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        db.LimparParametros()
        Dim query As String = "SELECT * FROM qryTransportadoras WHERE CNPJ LIKE '" & CNPJ & "%'"
        '
        Try
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            Dim lista As New List(Of clTransportadora)
            '
            If dt.Rows.Count = 0 Then Return Nothing
            '
            For Each dr In dt.Rows
                '
                Dim tran As New clTransportadora
                '
                tran.IDPessoa = IIf(IsDBNull(dr("IDTransportadora")), Nothing, dr("IDTransportadora"))
                tran.Ativo = IIf(IsDBNull(dr("Ativo")), 0, dr("Ativo"))
                tran.Observacao = IIf(IsDBNull(dr("Observacao")), String.Empty, dr("Observacao"))
                '
                tran.Cadastro = IIf(IsDBNull(dr("Cadastro")), String.Empty, dr("Cadastro"))
                tran.NomeFantasia = IIf(IsDBNull(dr("NomeFantasia")), String.Empty, dr("NomeFantasia"))
                tran.Endereco = IIf(IsDBNull(dr("Endereco")), String.Empty, dr("Endereco"))
                tran.Bairro = IIf(IsDBNull(dr("Bairro")), String.Empty, dr("Bairro"))
                tran.Cidade = IIf(IsDBNull(dr("Cidade")), String.Empty, dr("Cidade"))
                tran.UF = IIf(IsDBNull(dr("UF")), String.Empty, dr("UF"))
                tran.CEP = IIf(IsDBNull(dr("CEP")), String.Empty, dr("CEP"))
                tran.TelefoneA = IIf(IsDBNull(dr("TelefoneA")), String.Empty, dr("TelefoneA"))
                tran.TelefoneB = IIf(IsDBNull(dr("TelefoneB")), String.Empty, dr("TelefoneB"))
                tran.Email = IIf(IsDBNull(dr("Email")), String.Empty, dr("Email"))
                tran.CNPJ = IIf(IsDBNull(dr("CNPJ")), String.Empty, dr("CNPJ"))
                tran.InscricaoEstadual = IIf(IsDBNull(dr("InscricaoEstadual")), String.Empty, dr("InscricaoEstadual"))
                tran.ContatoNome = IIf(IsDBNull(dr("ContatoNome")), String.Empty, dr("ContatoNome"))
                tran.FundacaoData = IIf(IsDBNull(dr("FundacaoData")), Nothing, dr("FundacaoData"))
                lista.Add(tran)
                '
            Next
            '
            '--- RETURN
            Return lista
            '
        Catch ex As Exception
            Throw ex
            '
        End Try
        '
    End Function
End Class
