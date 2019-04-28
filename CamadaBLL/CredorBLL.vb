Imports CamadaDAL
Imports CamadaDTO

Public Class CredorBLL
    '===================================================================================================
    ' OBTER LISTA COMPLETA PELO CREDORTIPO
    '===================================================================================================
    Public Function Credor_GET_List(Optional CredorTipo As Byte? = Nothing) As List(Of clCredor)
        Dim bd As New AcessoDados
        Dim lst As New List(Of clCredor)
        '
        bd.LimparParametros()
        '
        If Not IsNothing(CredorTipo) Then
            bd.AdicionarParametros("@CredorTipo", CredorTipo)
        End If
        '
        Try
            Dim dt As DataTable = bd.ExecutarConsulta(CommandType.StoredProcedure, "uspCredor_GET_PorTipo")
            '
            For Each r As DataRow In dt.Rows
                Dim cred As New clCredor
                '
                cred.IDPessoa = IIf(IsDBNull(r("IDCredor")), Nothing, r("IDCredor"))
                cred.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                cred.CredorTipo = IIf(IsDBNull(r("CredorTipo")), Nothing, r("CredorTipo"))
                cred.Ativo = IIf(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
                '
                If Not IsDBNull(r("CNPJ")) Then
                    cred.CNP = IIf(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
                Else
                    If Not IsDBNull(r("CPF")) Then
                        cred.CNP = IIf(IsDBNull(r("CPF")), String.Empty, r("CPF"))
                    Else
                        cred.CNP = Nothing
                    End If
                End If
                '
                cred.Endereco = IIf(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
                cred.Bairro = IIf(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
                cred.Cidade = IIf(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
                cred.UF = IIf(IsDBNull(r("UF")), String.Empty, r("UF"))
                cred.CEP = IIf(IsDBNull(r("CEP")), String.Empty, r("CEP"))
                cred.TelefoneA = IIf(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
                cred.TelefoneB = IIf(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
                cred.Email = IIf(IsDBNull(r("Email")), String.Empty, r("Email"))
                '
                lst.Add(cred)
                '
            Next
            '
            Return lst
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' INSERIR NOVO
    '===================================================================================================
    Public Function Credor_Inserir(myCredor As clCredor) As Object
        Dim bd As New AcessoDados
        '
        bd.LimparParametros()
        '
        '--- ADICIONA OS PARAMENTROS NECESSARIOS
        bd.AdicionarParametros("Cadastro", myCredor.Cadastro)
        bd.AdicionarParametros("CredorTipo", myCredor.CredorTipo)
        '--- CNPJ | CPF
        bd.AdicionarParametros("CNP", myCredor.CNP)
        '--- ENDERECO
        bd.AdicionarParametros("Endereco", myCredor.Endereco)
        bd.AdicionarParametros("Bairro", myCredor.Bairro)
        bd.AdicionarParametros("Cidade", myCredor.Cidade)
        bd.AdicionarParametros("UF", myCredor.UF)
        bd.AdicionarParametros("CEP", myCredor.CEP)
        '--- TELEFONES
        bd.AdicionarParametros("TelefoneA", myCredor.TelefoneA)
        bd.AdicionarParametros("TelefoneB", myCredor.TelefoneB)
        '--- EMAIL
        bd.AdicionarParametros("Email", myCredor.Email)
        '
        Try
            Dim myID As Object = bd.ExecutarManipulacao(CommandType.StoredProcedure, "uspCredor_Inserir")
            '
            If IsNumeric(myID) Then
                Return myID
            Else
                Throw New Exception(myID.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' ALTERAR REGISTRO
    '===================================================================================================
    Public Function Credor_Alterar(myCredor As clCredor) As clCredor
        Dim bd As New AcessoDados
        '
        bd.LimparParametros()
        '
        '--- ADICIONA OS PARAMENTROS NECESSARIOS
        bd.AdicionarParametros("IDCredor", myCredor.IDPessoa)
        bd.AdicionarParametros("Cadastro", myCredor.Cadastro)
        bd.AdicionarParametros("CredorTipo", myCredor.CredorTipo)
        '--- ENDERECO
        bd.AdicionarParametros("Endereco", myCredor.Endereco)
        bd.AdicionarParametros("Bairro", myCredor.Bairro)
        bd.AdicionarParametros("Cidade", myCredor.Cidade)
        bd.AdicionarParametros("UF", myCredor.UF)
        bd.AdicionarParametros("CEP", myCredor.CEP)
        '--- TELEFONES
        bd.AdicionarParametros("TelefoneA", myCredor.TelefoneA)
        bd.AdicionarParametros("TelefoneB", myCredor.TelefoneB)
        '--- EMAIL
        bd.AdicionarParametros("Email", myCredor.Email)
        '
        Try
            Dim myResp As Object = bd.ExecutarConsulta(CommandType.StoredProcedure, "uspCredor_Alterar")
            '
            Dim r As DataRow = myResp.Rows(0)
            '
            If IsNumeric(r.Item(0)) Then
                myCredor.Cadastro = r.Item(1)
                Return myCredor
            Else
                Throw New Exception(r.Item(0))
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' ATIVA DESATIVA CREDOR
    '===================================================================================================
    Public Function Credor_AtivaDesativa(IDCredor As Integer, Ativo As Boolean) As Boolean
        Dim SQL As New SQLControl
        Dim mySQL As String = String.Format("UPDATE tblPessoaCredor SET Ativo = '{0}' WHERE IDCredor = {1}", Ativo, IDCredor)
        '
        SQL.ExecQuery(mySQL)
        '
        If SQL.HasException Then
            Throw New Exception(SQL.Exception)
        Else
            Return True
        End If
        '
    End Function
End Class
