Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient

Public Class ClientePF_BLL
    '===================================================================================================
    'GET CLIENTEPF | PELO ID | RETORNA CLIENTEPF
    '===================================================================================================
    Public Function GetClientePF_PorID(ByVal IDCliente As Integer) As clClientePF
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        Dim cli As clClientePF = Nothing
        '
        strSql = "SELECT * FROM qryClientePF WHERE IDPessoa = " & IDCliente
        '
        Try
            Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
            While dr.Read
                cli = New clClientePF
                '
                ' PESSOA FISICA
                cli.IDPessoa = If(IsDBNull(dr("IDPessoa")), 0, dr("IDPessoa"))
                cli.PessoaTipo = If(IsDBNull(dr("PessoaTipo")), 0, dr("PessoaTipo"))
                cli.Cadastro = If(IsDBNull(dr("Cadastro")), String.Empty, dr("Cadastro"))
                cli.CPF = If(IsDBNull(dr("CPF")), String.Empty, dr("CPF"))
                cli.Endereco = If(IsDBNull(dr("Endereco")), String.Empty, dr("Endereco"))
                cli.Bairro = If(IsDBNull(dr("Bairro")), String.Empty, dr("Bairro"))
                cli.Cidade = If(IsDBNull(dr("Cidade")), String.Empty, dr("Cidade"))
                cli.UF = If(IsDBNull(dr("UF")), String.Empty, dr("UF"))
                cli.CEP = If(IsDBNull(dr("CEP")), String.Empty, dr("CEP"))
                cli.NascimentoData = If(IsDBNull(dr("NascimentoData")), Nothing, dr("NascimentoData"))
                cli.Sexo = If(IsDBNull(dr("Sexo")), 0, dr("Sexo"))
                cli.Identidade = If(IsDBNull(dr("Identidade")), String.Empty, dr("Identidade"))
                cli.IdentidadeOrgao = If(IsDBNull(dr("IdentidadeOrgao")), String.Empty, dr("IdentidadeOrgao"))
                cli.IdentidadeData = If(IsDBNull(dr("IdentidadeData")), Nothing, dr("IdentidadeData"))
                cli.TelefoneA = If(IsDBNull(dr("TelefoneA")), String.Empty, dr("TelefoneA"))
                cli.TelefoneB = If(IsDBNull(dr("TelefoneB")), String.Empty, dr("TelefoneB"))
                cli.Email = If(IsDBNull(dr("Email")), String.Empty, dr("Email"))
                ' PESSOA CLIENTE
                cli.ClienteDesde = If(IsDBNull(dr("ClienteDesde")), Nothing, dr("ClienteDesde"))
                cli.Observacao = If(IsDBNull(dr("Observacao")), String.Empty, dr("Observacao"))
                cli.IDSituacao = If(IsDBNull(dr("IDSituacao")), 0, dr("IDSituacao"))
                cli.Situacao = If(IsDBNull(dr("Situacao")), String.Empty, dr("Situacao"))
                cli.RGAtividade = If(IsDBNull(dr("RGAtividade")), 0, dr("RGAtividade"))
                cli.Atividade = If(IsDBNull(dr("Atividade")), String.Empty, dr("Atividade"))
                cli.LimiteCompras = If(IsDBNull(dr("LimiteCompras")), 0, dr("LimiteCompras"))
                cli.UltimaVenda = If(IsDBNull(dr("UltimaVenda")), Nothing, dr("UltimaVenda"))
                cli.RGCliente = If(IsDBNull(dr("RGCliente")), 0, dr("RGCliente"))
                ' CLIENTEPF
                cli.Naturalidade = If(IsDBNull(dr("Naturalidade")), String.Empty, dr("Naturalidade"))
                cli.Pai = If(IsDBNull(dr("Pai")), String.Empty, dr("Pai"))
                cli.Mae = If(IsDBNull(dr("Mae")), String.Empty, dr("Mae"))
                cli.TrabalhoContratante = If(IsDBNull(dr("TrabalhoContratante")), String.Empty, dr("TrabalhoContratante"))
                cli.TrabalhoFuncao = If(IsDBNull(dr("TrabalhoFuncao")), String.Empty, dr("TrabalhoFuncao"))
                cli.TrabalhoTelefone = If(IsDBNull(dr("TrabalhoTelefone")), String.Empty, dr("TrabalhoTelefone"))
                cli.Renda = If(IsDBNull(dr("Renda")), 0, dr("Renda"))
                cli.EstadoCivil = If(IsDBNull(dr("EstadoCivil")), 0, dr("EstadoCivil"))
                cli.Conjuge = If(IsDBNull(dr("Conjuge")), String.Empty, dr("Conjuge"))
                cli.ConjugeRenda = If(IsDBNull(dr("ConjugeRenda")), 0, dr("ConjugeRenda"))
                cli.Igreja = If(IsDBNull(dr("Igreja")), String.Empty, dr("Igreja"))
                cli.IgrejaAtuacao = If(IsDBNull(dr("IgrejaAtuacao")), String.Empty, dr("IgrejaAtuacao"))
                cli.IgrejaFuncao = If(IsDBNull(dr("IgrejaFuncao")), String.Empty, dr("IgrejaFuncao"))
                cli.FichaPrint = If(IsDBNull(dr("FichaPrint")), 0, dr("FichaPrint"))
                '
            End While
            '
            dr.Close()
            '
            If Not IsNothing(cli.IDPessoa) Then
                Return cli
            Else
                Throw New Exception("Não retornou nenhum cliente...")
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    'GET CLIENTEPF | COM WHERE | RETORNA LISTAGEM
    '===================================================================================================
    Public Function GetClientesPF_Where(myWhere As String) As List(Of clClientePF)
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryClientePF"
        Else
            strSql = "SELECT * FROM qryClientePF WHERE " & myWhere
        End If
        Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
        Dim lista As New List(Of clClientePF)
        While dr.Read
            Dim cli As clClientePF = New clClientePF
            ' PESSOA FISICA
            cli.IDPessoa = If(IsDBNull(dr("IDPessoa")), 0, dr("IDPessoa"))
            cli.PessoaTipo = If(IsDBNull(dr("PessoaTipo")), 0, dr("PessoaTipo"))
            cli.Cadastro = If(IsDBNull(dr("Cadastro")), String.Empty, dr("Cadastro"))
            cli.CPF = If(IsDBNull(dr("CPF")), String.Empty, dr("CPF"))
            cli.Endereco = If(IsDBNull(dr("Endereco")), String.Empty, dr("Endereco"))
            cli.Bairro = If(IsDBNull(dr("Bairro")), String.Empty, dr("Bairro"))
            cli.Cidade = If(IsDBNull(dr("Cidade")), String.Empty, dr("Cidade"))
            cli.UF = If(IsDBNull(dr("UF")), String.Empty, dr("UF"))
            cli.CEP = If(IsDBNull(dr("CEP")), String.Empty, dr("CEP"))
            cli.NascimentoData = If(IsDBNull(dr("NascimentoData")), Nothing, dr("NascimentoData"))
            cli.Sexo = If(IsDBNull(dr("Sexo")), 0, dr("Sexo"))
            cli.Identidade = If(IsDBNull(dr("Identidade")), String.Empty, dr("Identidade"))
            cli.IdentidadeOrgao = If(IsDBNull(dr("IdentidadeOrgao")), String.Empty, dr("IdentidadeOrgao"))
            cli.IdentidadeData = If(IsDBNull(dr("IdentidadeData")), Nothing, dr("IdentidadeData"))
            cli.TelefoneA = If(IsDBNull(dr("TelefoneA")), String.Empty, dr("TelefoneA"))
            cli.TelefoneB = If(IsDBNull(dr("TelefoneB")), String.Empty, dr("TelefoneB"))
            cli.Email = If(IsDBNull(dr("Email")), String.Empty, dr("Email"))
            ' PESSOA CLIENTE
            cli.ClienteDesde = If(IsDBNull(dr("ClienteDesde")), Nothing, dr("ClienteDesde"))
            cli.Observacao = If(IsDBNull(dr("Observacao")), String.Empty, dr("Observacao"))
            cli.IDSituacao = If(IsDBNull(dr("IDSituacao")), 0, dr("IDSituacao"))
            cli.Situacao = If(IsDBNull(dr("Situacao")), String.Empty, dr("Situacao"))
            cli.RGAtividade = If(IsDBNull(dr("RGAtividade")), 0, dr("RGAtividade"))
            cli.Atividade = If(IsDBNull(dr("Atividade")), String.Empty, dr("Atividade"))
            cli.LimiteCompras = If(IsDBNull(dr("LimiteCompras")), 0, dr("LimiteCompras"))
            cli.UltimaVenda = If(IsDBNull(dr("UltimaVenda")), Nothing, dr("UltimaVenda"))
            cli.RGCliente = If(IsDBNull(dr("RGCliente")), 0, dr("RGCliente"))
            ' CLIENTEPF
            cli.Naturalidade = If(IsDBNull(dr("Naturalidade")), String.Empty, dr("Naturalidade"))
            cli.Pai = If(IsDBNull(dr("Pai")), String.Empty, dr("Pai"))
            cli.Mae = If(IsDBNull(dr("Mae")), String.Empty, dr("Mae"))
            cli.TrabalhoContratante = If(IsDBNull(dr("TrabalhoContratante")), String.Empty, dr("TrabalhoContratante"))
            cli.TrabalhoFuncao = If(IsDBNull(dr("TrabalhoFuncao")), String.Empty, dr("TrabalhoFuncao"))
            cli.TrabalhoTelefone = If(IsDBNull(dr("TrabalhoTelefone")), String.Empty, dr("TrabalhoTelefone"))
            cli.Renda = If(IsDBNull(dr("Renda")), 0, dr("Renda"))
            cli.EstadoCivil = If(IsDBNull(dr("EstadoCivil")), 0, dr("EstadoCivil"))
            cli.Conjuge = If(IsDBNull(dr("Conjuge")), String.Empty, dr("Conjuge"))
            cli.ConjugeRenda = If(IsDBNull(dr("ConjugeRenda")), 0, dr("ConjugeRenda"))
            cli.Igreja = If(IsDBNull(dr("Igreja")), String.Empty, dr("Igreja"))
            cli.IgrejaAtuacao = If(IsDBNull(dr("IgrejaAtuacao")), String.Empty, dr("IgrejaAtuacao"))
            cli.IgrejaFuncao = If(IsDBNull(dr("IgrejaFuncao")), String.Empty, dr("IgrejaFuncao"))
            cli.FichaPrint = If(IsDBNull(dr("FichaPrint")), 0, dr("FichaPrint"))
            '
            lista.Add(cli)
            '
        End While
        dr.Close()
        Return lista
    End Function
    '
    '===================================================================================================
    'ATUALIZA CLIENTEPF | RETORNA ID
    '===================================================================================================
    Public Function AtualizaClientePF_Procedure_ID(ByVal _cliente As clClientePF) As Long
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand

        'Adiciona os Parâmetros
        Conn.Parameters.Add(New SqlParameter("@IDPessoa", _cliente.IDPessoa))
        Conn.Parameters.Add(New SqlParameter("@PessoaTipo", _cliente.PessoaTipo))
        Conn.Parameters.Add(New SqlParameter("@Cadastro", _cliente.Cadastro))
        Conn.Parameters.Add(New SqlParameter("@CPF", _cliente.CPF))
        Conn.Parameters.Add(New SqlParameter("@Sexo", _cliente.Sexo))
        Conn.Parameters.Add(New SqlParameter("@NascimentoData", _cliente.NascimentoData))
        Conn.Parameters.Add(New SqlParameter("@Identidade", _cliente.Identidade))
        Conn.Parameters.Add(New SqlParameter("@IdentidadeOrgao", _cliente.IdentidadeOrgao))
        Conn.Parameters.Add(New SqlParameter("@IdentidadeData", _cliente.IdentidadeData))
        Conn.Parameters.Add(New SqlParameter("@Endereco", _cliente.Endereco))
        Conn.Parameters.Add(New SqlParameter("@Bairro", _cliente.Bairro))
        Conn.Parameters.Add(New SqlParameter("@Cidade", _cliente.Cidade))
        Conn.Parameters.Add(New SqlParameter("@UF", _cliente.UF))
        Conn.Parameters.Add(New SqlParameter("@CEP", _cliente.CEP))
        Conn.Parameters.Add(New SqlParameter("@TelefoneA", _cliente.TelefoneA))
        Conn.Parameters.Add(New SqlParameter("@TelefoneB", _cliente.TelefoneB))
        Conn.Parameters.Add(New SqlParameter("@Email", _cliente.Email))
        Conn.Parameters.Add(New SqlParameter("@IDSituacao", _cliente.IDSituacao))
        Conn.Parameters.Add(New SqlParameter("@ClienteDesde", _cliente.ClienteDesde))
        Conn.Parameters.Add(New SqlParameter("@RGAtividade", _cliente.RGAtividade))
        Conn.Parameters.Add(New SqlParameter("@LimiteCompras", _cliente.LimiteCompras))
        Conn.Parameters.Add(New SqlParameter("@UltimaVenda", _cliente.UltimaVenda))
        Conn.Parameters.Add(New SqlParameter("@RGCliente", _cliente.RGCliente))
        Conn.Parameters.Add(New SqlParameter("@Observacao", _cliente.Observacao))
        Conn.Parameters.Add(New SqlParameter("@Naturalidade", _cliente.Naturalidade))
        Conn.Parameters.Add(New SqlParameter("@Pai", _cliente.Pai))
        Conn.Parameters.Add(New SqlParameter("@Mae", _cliente.Mae))
        Conn.Parameters.Add(New SqlParameter("@TrabalhoContratante", _cliente.TrabalhoContratante))
        Conn.Parameters.Add(New SqlParameter("@TrabalhoFuncao", _cliente.TrabalhoFuncao))
        Conn.Parameters.Add(New SqlParameter("@TrabalhoTelefone", _cliente.TrabalhoTelefone))
        Conn.Parameters.Add(New SqlParameter("@Renda", _cliente.Renda))
        Conn.Parameters.Add(New SqlParameter("@EstadoCivil", _cliente.EstadoCivil))
        Conn.Parameters.Add(New SqlParameter("@Conjuge", _cliente.Conjuge))
        Conn.Parameters.Add(New SqlParameter("@ConjugeRenda", _cliente.ConjugeRenda))
        Conn.Parameters.Add(New SqlParameter("@Igreja", _cliente.Igreja))
        Conn.Parameters.Add(New SqlParameter("@IgrejaAtuacao", _cliente.IgrejaAtuacao))
        Conn.Parameters.Add(New SqlParameter("@IgrejaFuncao", _cliente.IgrejaFuncao))
        Conn.Parameters.Add(New SqlParameter("@FichaPrint", _cliente.FichaPrint))

        Try
            Return objDB.ExecuteProcedureID("uspClientePF_Alterar", Conn.Parameters)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

    End Function
    '
    '===================================================================================================
    'SALVA CLIENTEPF | RETORNA ID
    '===================================================================================================
    Public Function SalvaNovoClientePF_Procedure_ID(ByVal _cliente As clClientePF) As Long
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand

        'Adiciona os Parâmetros
        Conn.Parameters.Add(New SqlParameter("@PessoaTipo", _cliente.PessoaTipo))
        Conn.Parameters.Add(New SqlParameter("@Cadastro", _cliente.Cadastro))
        Conn.Parameters.Add(New SqlParameter("@CPF", _cliente.CPF))
        Conn.Parameters.Add(New SqlParameter("@Sexo", _cliente.Sexo))
        Conn.Parameters.Add(New SqlParameter("@NascimentoData", _cliente.NascimentoData))
        Conn.Parameters.Add(New SqlParameter("@Identidade", _cliente.Identidade))
        Conn.Parameters.Add(New SqlParameter("@IdentidadeOrgao", _cliente.IdentidadeOrgao))
        Conn.Parameters.Add(New SqlParameter("@IdentidadeData", _cliente.IdentidadeData))
        Conn.Parameters.Add(New SqlParameter("@Endereco", _cliente.Endereco))
        Conn.Parameters.Add(New SqlParameter("@Bairro", _cliente.Bairro))
        Conn.Parameters.Add(New SqlParameter("@Cidade", _cliente.Cidade))
        Conn.Parameters.Add(New SqlParameter("@UF", _cliente.UF))
        Conn.Parameters.Add(New SqlParameter("@CEP", _cliente.CEP))
        Conn.Parameters.Add(New SqlParameter("@TelefoneA", _cliente.TelefoneA))
        Conn.Parameters.Add(New SqlParameter("@TelefoneB", _cliente.TelefoneB))
        Conn.Parameters.Add(New SqlParameter("@Email", _cliente.Email))
        Conn.Parameters.Add(New SqlParameter("@IDSituacao", _cliente.IDSituacao))
        Conn.Parameters.Add(New SqlParameter("@ClienteDesde", _cliente.ClienteDesde))
        Conn.Parameters.Add(New SqlParameter("@RGAtividade", _cliente.RGAtividade))
        Conn.Parameters.Add(New SqlParameter("@LimiteCompras", _cliente.LimiteCompras))
        Conn.Parameters.Add(New SqlParameter("@UltimaVenda", _cliente.UltimaVenda))
        Conn.Parameters.Add(New SqlParameter("@RGCliente", _cliente.RGCliente))
        Conn.Parameters.Add(New SqlParameter("@Observacao", _cliente.Observacao))
        Conn.Parameters.Add(New SqlParameter("@Naturalidade", _cliente.Naturalidade))
        Conn.Parameters.Add(New SqlParameter("@Pai", _cliente.Pai))
        Conn.Parameters.Add(New SqlParameter("@Mae", _cliente.Mae))
        Conn.Parameters.Add(New SqlParameter("@TrabalhoContratante", _cliente.TrabalhoContratante))
        Conn.Parameters.Add(New SqlParameter("@TrabalhoFuncao", _cliente.TrabalhoFuncao))
        Conn.Parameters.Add(New SqlParameter("@TrabalhoTelefone", _cliente.TrabalhoTelefone))
        Conn.Parameters.Add(New SqlParameter("@Renda", _cliente.Renda))
        Conn.Parameters.Add(New SqlParameter("@EstadoCivil", _cliente.EstadoCivil))
        Conn.Parameters.Add(New SqlParameter("@Conjuge", _cliente.Conjuge))
        Conn.Parameters.Add(New SqlParameter("@ConjugeRenda", _cliente.ConjugeRenda))
        Conn.Parameters.Add(New SqlParameter("@Igreja", _cliente.Igreja))
        Conn.Parameters.Add(New SqlParameter("@IgrejaAtuacao", _cliente.IgrejaAtuacao))
        Conn.Parameters.Add(New SqlParameter("@IgrejaFuncao", _cliente.IgrejaFuncao))
        Conn.Parameters.Add(New SqlParameter("@FichaPrint", _cliente.FichaPrint))

        Try
            Return objDB.ExecuteProcedureID("uspClientePF_Inserir", Conn.Parameters)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

    End Function
    '
End Class
