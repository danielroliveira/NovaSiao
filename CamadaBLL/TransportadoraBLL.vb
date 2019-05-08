Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient
'
Public Class TransportadoraBLL
    '
    '-----------------------------------------------------------------------------------------------------
    ' GET DATATABLE SIMPLES DE TRANSPORTADORAS PARA COMBO
    '-----------------------------------------------------------------------------------------------------
    Public Function Transportadora_GET_ListaSimples(Optional Ativo As Boolean? = Nothing) As DataTable
        Dim db As New AcessoDados
        '
        If Not IsNothing(Ativo) Then
            db.LimparParametros()
            db.AdicionarParametros("@Ativo", Ativo)
        End If
        '
        Try
            Return db.ExecutarConsulta(CommandType.StoredProcedure, "uspTransportadoras_GET_ListaSimples")
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
        Dim objdb As New AcessoDados
        Dim strSql As String = ""

        If IsNothing(Ativo) Then
            strSql = "SELECT * FROM qryTransportadoras"
        Else
            strSql = "SELECT * FROM qryTransportadoras WHERE Ativo = '" & Ativo & "'"
        End If
        '
        Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
        Dim lista As New List(Of clTransportadora)
        While dr.Read
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
        End While
        dr.Close()
        Return lista
    End Function
    '
    '-----------------------------------------------------------------------------------------------------
    ' INSERIR NOVA TRANSPORTADORA
    '-----------------------------------------------------------------------------------------------------
    Public Function SalvaNovaTransportadora_ID(transp As clTransportadora) As Integer
        Dim db As New AcessoDados
        '
        '--- Limpar Parametros
        db.LimparParametros()
        '
        '--- Adicionar Parametros
        db.AdicionarParametros("@PessoaTipo", 2)
        db.AdicionarParametros("@Cadastro", transp.Cadastro)
        db.AdicionarParametros("@CNPJ", transp.CNPJ)
        db.AdicionarParametros("@InscricaoEstadual", transp.InscricaoEstadual)
        db.AdicionarParametros("@NomeFantasia", transp.NomeFantasia)
        db.AdicionarParametros("@FundacaoData", If(transp.FundacaoData, DBNull.Value))
        db.AdicionarParametros("@ContatoNome", transp.ContatoNome)
        db.AdicionarParametros("@Endereco", transp.Endereco)
        db.AdicionarParametros("@Bairro", transp.Bairro)
        db.AdicionarParametros("@Cidade", transp.Cidade)
        db.AdicionarParametros("@UF", transp.UF)
        db.AdicionarParametros("@CEP", transp.CEP)
        db.AdicionarParametros("TelefoneA", transp.TelefoneA)
        db.AdicionarParametros("@TelefoneB", transp.TelefoneB)
        db.AdicionarParametros("@Email", transp.Email)
        db.AdicionarParametros("@Ativo", transp.Ativo)
        db.AdicionarParametros("@Observacao", transp.Observacao)
        '
        '--- Executa Procedure
        Try
            Return db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTransportadora_Inserir")
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------
    ' ATUALIZAR TRANSPORTADORA
    '-----------------------------------------------------------------------------------------------------
    Public Function AtualizaTransportadora(transp As clTransportadora) As Integer
        Dim db As New AcessoDados
        '
        '--- Limpar Parametros
        db.LimparParametros()
        '
        '--- Adicionar Parametros
        db.AdicionarParametros("@IDPessoa", transp.IDPessoa)
        db.AdicionarParametros("@PessoaTipo", 2)
        db.AdicionarParametros("@Cadastro", transp.Cadastro)
        db.AdicionarParametros("@CNPJ", transp.CNPJ)
        db.AdicionarParametros("@InscricaoEstadual", transp.InscricaoEstadual)
        db.AdicionarParametros("@NomeFantasia", transp.NomeFantasia)
        db.AdicionarParametros("@FundacaoData", transp.FundacaoData)
        db.AdicionarParametros("@ContatoNome", transp.ContatoNome)
        db.AdicionarParametros("@Endereco", transp.Endereco)
        db.AdicionarParametros("@Bairro", transp.Bairro)
        db.AdicionarParametros("@Cidade", transp.Cidade)
        db.AdicionarParametros("@UF", transp.UF)
        db.AdicionarParametros("@CEP", transp.CEP)
        db.AdicionarParametros("TelefoneA", transp.TelefoneA)
        db.AdicionarParametros("@TelefoneB", transp.TelefoneB)
        db.AdicionarParametros("@Email", transp.Email)
        db.AdicionarParametros("@Ativo", transp.Ativo)
        db.AdicionarParametros("@Observacao", transp.Observacao)
        '
        '--- Executa Procedure
        Try
            Return db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTransportadora_Alterar")
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
