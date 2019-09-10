Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient

Public Class ClientePF_BLL
    '
    '===================================================================================================
    '--- GET CLIENTEPF | PELO ID | RETORNA CLIENTEPF
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
            '--- CLOSE DATAREADER
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
        Finally
            '
            '--- CLOSE DB CONNECTION
            objdb.CloseConn()
            '
        End Try
        '
    End Function
    '
    '===================================================================================================
    '--- GET CLIENTEPF | COM WHERE | RETORNA LISTAGEM
    '===================================================================================================
    Public Function GetClientesPF_Where(myWhere As String) As List(Of clClientePF)
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryClientePF"
        Else
            strSql = "SELECT * FROM qryClientePF WHERE " & myWhere
        End If
        '
        Try
            '
            Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
            Dim lista As New List(Of clClientePF)
            '
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
            '
            '--- CLOSE DATAREADER
            dr.Close()
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
    '===================================================================================================
    '--- INSERT CLIENTEPF ANIVERSARIANTES
    '===================================================================================================
    Public Function ClienteSearchInsertAniversariantes(MesRef As Integer) As Integer
        '
        Dim db As AcessoDados = Nothing
        '
        Try
            '
            db = New AcessoDados
            Dim query As String = ""
            '
            '--- GET CLIENTES ANIVERSARIANTES
            '----------------------------------------------------------------------------------
            db.LimparParametros()
            db.AdicionarParametros("@Mes", MesRef)
            '
            query = "SELECT IDPessoa, NascimentoData " &
                    "FROM qryClientePF " &
                    "WHERE IDSituacao = 1 AND MONTH(NascimentoData) = @Mes"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            Dim NiverCount As Integer = dt.Rows.Count
            If NiverCount = 0 Then Return 0
            '
            If Not IsNumeric(dt.Rows(0).Item(0)) Then
                Throw New Exception(dt.Rows(0).Item(0))
            End If
            '
            '--- Cria TRANSACTION
            '----------------------------------------------------------------------------------
            db.BeginTransaction()
            '
            '--- Cria o ENVIO
            '----------------------------------------------------------------------------------
            Dim Envio As New clPessoaEnvio With {
                .EnvioDescricao = "Aniversariantes do Mês de " & Format(DateSerial(Year(Today), MesRef, 1), "MMMM"),
                .EnvioData = Today
            }
            '
            Dim eBLL As New PessoaEnvioBLL
            Dim response As clPessoaEnvio = eBLL.InsertEnvio(Envio, db)
            '
            '--- Insere cada Cliente encontrado na Lista de Envio
            '----------------------------------------------------------------------------------
            For Each r In dt.Rows
                '
                Dim DiaNascimento As Integer = DirectCast(r("NascimentoData"), Date).Day
                '
                Dim dtPostagem As Date = DateSerial(Year(Today), MesRef, DiaNascimento)
                If Not eBLL.InsertEnvioPessoa(response.IDPessoaEnvio, r("IDPessoa"), dtPostagem, db) Then
                    Throw New Exception("Um erro desconhecido ocorreu ao inserir Aniversariantes...")
                End If
                '
            Next
            '
            '--- COMMIT AND RETURN
            '----------------------------------------------------------------------------------
            db.CommitTransaction()
            Return NiverCount
            '
        Catch ex As Exception
            db.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
End Class
