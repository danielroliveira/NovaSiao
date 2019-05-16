Imports CamadaDAL
Imports CamadaDTO

Public Class CredorBLL
    '
    '===================================================================================================
    ' OBTER LISTA COMPLETA PELO CREDORTIPO
    '===================================================================================================
    Public Function Credor_GET_List(Optional CredorTipo As Byte? = Nothing) As List(Of clCredor)
        Dim bd As New AcessoDados
        Dim lst As New List(Of clCredor)
        '
        '--- declare Query
        Dim myQuery As String = "SELECT * FROM qryCredor"
        '
        '--- Paramns
        bd.LimparParametros()
        '
        If Not IsNothing(CredorTipo) Then
            bd.AdicionarParametros("@CredorTipo", CredorTipo)
            myQuery += " WHERE CredorTipo = @CredorTipo"
        End If
        '
        '--- Execute Query
        Try
            Dim dt As DataTable = bd.ExecutarConsulta(CommandType.Text, myQuery)
            '
            For Each r As DataRow In dt.Rows
                lst.Add(ConvertDtRow_Credor(r))
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
    ' GET CREDOR PELO ID
    '===================================================================================================
    Public Function CredorGetPeloID(IDCredor) As clCredor
        Dim bd As New AcessoDados
        '
        '--- declare Query
        Dim myQuery As String = "SELECT * FROM qryCredor WHERE IDCredor = @IDCredor"
        '
        '--- Paramns
        bd.LimparParametros()
        bd.AdicionarParametros("@IDCredor", IDCredor)
        '
        '--- Execute Query
        Try
            Dim dt As DataTable = bd.ExecutarConsulta(CommandType.Text, myQuery)
            If dt.Rows.Count = 0 Then Return Nothing
            '
            Return ConvertDtRow_Credor(dt.Rows(0))
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' CONVERTE UM DATAROW EM UM CLCREDOR
    '==========================================================================================
    Shared Function ConvertDtRow_Credor(r As DataRow) As clCredor
        '
        Dim Cred As New clCredor With {
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa")),
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro")),
            .CNP = If(IsDBNull(r("CNP")), String.Empty, r("CNP")),
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco")),
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro")),
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade")),
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF")),
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP")),
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email")),
            .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA")),
            .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB")),
            .PessoaTipo = If(IsDBNull(r("PessoaTipo")), Nothing, r("PessoaTipo")),
            .CredorTipo = If(IsDBNull(r("CredorTipo")), Nothing, r("CredorTipo")),
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo")),
            .Observacao = If(IsDBNull(r("Observacao")), String.Empty, r("Observacao")),
            .InsercaoData = If(IsDBNull(r("InsercaoData")), Nothing, r("InsercaoData"))
        }
        '
        Return Cred
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
    '
End Class
