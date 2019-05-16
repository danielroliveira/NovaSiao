Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient
'
Public Class ClientePJ_BLL
    '===================================================================================================
    'GET CLIENTEPJ | POR ID | RETORNA CLIENTEPJ
    '===================================================================================================
    Public Function GetClientesPJ_PorID(ByVal IDCliente As Integer) As clClientePJ
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        Dim cli As clClientePJ = Nothing
        '
        strSql = "SELECT * FROM qryClientePJ WHERE IDPessoa = " & IDCliente
        '
        Try
            Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
            While dr.Read
                cli = New clClientePJ

                cli.IDPessoa = IIf(IsDBNull(dr("IDPessoa")), 0, dr("IDPessoa"))
                cli.Cadastro = IIf(IsDBNull(dr("Cadastro")), String.Empty, dr("Cadastro"))
                cli.CNPJ = IIf(IsDBNull(dr("CNPJ")), String.Empty, dr("CNPJ"))
                cli.InscricaoEstadual = IIf(IsDBNull(dr("InscricaoEstadual")), String.Empty, dr("InscricaoEstadual"))
                cli.ContatoNome = IIf(IsDBNull(dr("ContatoNome")), String.Empty, dr("ContatoNome"))
                cli.FundacaoData = IIf(IsDBNull(dr("FundacaoData")), Nothing, dr("FundacaoData"))
                cli.NomeFantasia = IIf(IsDBNull(dr("NomeFantasia")), String.Empty, dr("NomeFantasia"))
                '
                cli.Endereco = IIf(IsDBNull(dr("Endereco")), String.Empty, dr("Endereco"))
                cli.Bairro = IIf(IsDBNull(dr("Bairro")), String.Empty, dr("Bairro"))
                cli.Cidade = IIf(IsDBNull(dr("Cidade")), String.Empty, dr("Cidade"))
                cli.UF = IIf(IsDBNull(dr("UF")), String.Empty, dr("UF"))
                cli.CEP = IIf(IsDBNull(dr("CEP")), String.Empty, dr("CEP"))
                '
                cli.TelefoneA = IIf(IsDBNull(dr("TelefoneA")), String.Empty, dr("TelefoneA"))
                cli.TelefoneB = IIf(IsDBNull(dr("TelefoneB")), String.Empty, dr("TelefoneB"))
                '
                cli.Email = IIf(IsDBNull(dr("Email")), String.Empty, dr("Email"))
                '
                cli.ClienteDesde = IIf(IsDBNull(dr("ClienteDesde")), Nothing, dr("ClienteDesde"))
                cli.Observacao = IIf(IsDBNull(dr("Observacao")), String.Empty, dr("Observacao"))
                cli.IDSituacao = IIf(IsDBNull(dr("IDSituacao")), 0, dr("IDSituacao"))
                cli.Situacao = IIf(IsDBNull(dr("Situacao")), String.Empty, dr("Situacao"))
                cli.RGAtividade = IIf(IsDBNull(dr("RGAtividade")), 0, dr("RGAtividade"))
                cli.LimiteCompras = IIf(IsDBNull(dr("LimiteCompras")), 0, dr("LimiteCompras"))
                cli.UltimaVenda = IIf(IsDBNull(dr("UltimaVenda")), Nothing, dr("UltimaVenda"))
                cli.RGCliente = IIf(IsDBNull(dr("RGCliente")), 0, dr("RGCliente"))

            End While
            dr.Close()
            Return cli
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    'GET CLIENTEPJ | COM WHERE | RETORNA LISTAGEM CLIENTEPJ
    '===================================================================================================
    Public Function GetClientesPJ_Where(myWhere As String) As List(Of clClientePJ)
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryClientePJ"
        Else
            strSql = "SELECT * FROM qryClientePJ WHERE " & myWhere
        End If
        Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
        Dim lista As New List(Of clClientePJ)
        While dr.Read
            Dim cli As clClientePJ = New clClientePJ

            cli.IDPessoa = IIf(IsDBNull(dr("IDPessoa")), 0, dr("IDPessoa"))
            cli.Cadastro = IIf(IsDBNull(dr("Cadastro")), String.Empty, dr("Cadastro"))
            cli.CNPJ = IIf(IsDBNull(dr("CNPJ")), String.Empty, dr("CNPJ"))
            cli.InscricaoEstadual = IIf(IsDBNull(dr("InscricaoEstadual")), String.Empty, dr("InscricaoEstadual"))
            cli.ContatoNome = IIf(IsDBNull(dr("ContatoNome")), String.Empty, dr("ContatoNome"))
            cli.FundacaoData = IIf(IsDBNull(dr("FundacaoData")), Nothing, dr("FundacaoData"))
            cli.NomeFantasia = IIf(IsDBNull(dr("NomeFantasia")), String.Empty, dr("NomeFantasia"))
            '
            cli.Endereco = IIf(IsDBNull(dr("Endereco")), String.Empty, dr("Endereco"))
            cli.Bairro = IIf(IsDBNull(dr("Bairro")), String.Empty, dr("Bairro"))
            cli.Cidade = IIf(IsDBNull(dr("Cidade")), String.Empty, dr("Cidade"))
            cli.UF = IIf(IsDBNull(dr("UF")), String.Empty, dr("UF"))
            cli.CEP = IIf(IsDBNull(dr("CEP")), String.Empty, dr("CEP"))
            '
            cli.TelefoneA = IIf(IsDBNull(dr("TelefoneA")), String.Empty, dr("TelefoneA"))
            cli.TelefoneB = IIf(IsDBNull(dr("TelefoneB")), String.Empty, dr("TelefoneB"))
            '
            cli.Email = IIf(IsDBNull(dr("Email")), String.Empty, dr("Email"))
            '
            cli.ClienteDesde = IIf(IsDBNull(dr("ClienteDesde")), Nothing, dr("ClienteDesde"))
            cli.Observacao = IIf(IsDBNull(dr("Observacao")), String.Empty, dr("Observacao"))
            cli.IDSituacao = IIf(IsDBNull(dr("IDSituacao")), 0, dr("IDSituacao"))
            cli.Situacao = IIf(IsDBNull(dr("Situacao")), String.Empty, dr("Situacao"))
            cli.RGAtividade = IIf(IsDBNull(dr("RGAtividade")), 0, dr("RGAtividade"))
            cli.LimiteCompras = IIf(IsDBNull(dr("LimiteCompras")), 0, dr("LimiteCompras"))
            cli.UltimaVenda = IIf(IsDBNull(dr("UltimaVenda")), Nothing, dr("UltimaVenda"))
            cli.RGCliente = IIf(IsDBNull(dr("RGCliente")), 0, dr("RGCliente"))

            lista.Add(cli)

        End While
        dr.Close()
        Return lista
    End Function
    '
End Class
