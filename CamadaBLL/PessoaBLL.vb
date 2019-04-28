Imports CamadaDAL
Imports CamadaDTO
Imports System.Data.SqlClient
'
Public Class PessoaBLL
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNÇÃO PROCURAR PESSOA POR CPF OU CNPJ E RETORNA UMA CLASSE
    ' DEPENDENDO DO ARGUMENTO DE PROCURA ProcurarEm (CLIENTE | FORNECEDOR | FUNCIONARIO | TRANSPORTADORA | FILIAL)
    ' SE JÁ For CLIENTE RETORNA clClientePF ou clClientePJ
    ' SE JÁ FOR FORNECEDOR RETORNA clFornecedor;
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ProcurarCNP_Pessoa(CNP As String, ProcurarEm As String) As Object
        Dim db As New AcessoDados
        Dim cmd As New SqlCommand
        '
        Try
            'Adiciona os parametros
            cmd.Parameters.Add(New SqlParameter("@CNP", CNP))
            cmd.Parameters.Add(New SqlParameter("@ProcurarEm", ProcurarEm))
            'executa o procedure
            Dim dtPessoa As DataTable
            dtPessoa = db.ExecuteConsultaSQL_DataTable("uspPessoa_ProcurarCNP_Pessoa", cmd.Parameters)
            ' VERIFICA O ROW RETORNADO
            Dim r As DataRow = dtPessoa.Rows(0)
            '
            ' SE NÃO ENCONTRAR NENHUM CPF/CNPJ IGUAL RETORNA NOTHING
            If IsDBNull(r("IDPessoa")) Then Return Nothing
            '
            ' SE ENCONTRAR RETORNA A PESSOA FISICA OU JURÍDICA
            '-------------------------------------------------------------------------------------------------------------------------------
            '
            ' SE FOR PESSOA FÍSICA
            If r("PessoaTipo") = 1 Then
                Dim PF As clPessoaFisica = DirectCast(ConverteDtRow_Pessoa(r), clPessoaFisica)
                '
                If r("Encontrado") = False Then Return PF ' CLIENTE PF NÃO FOI ENCONTRADO (RETORNA clPessoaFisica)
                '
                Select Case ProcurarEm
                    Case "CLIENTE" ' VERIFICA O CLIENTE ENCONTRADO E RETORNA ClientePF
                        Return ConvertDtRow_Cliente(r)
                    Case "FUNCIONARIO"
                        Return ConvertDtRow_Funcionario(r)
                    Case Else
                        Return PF
                End Select
                '
            Else ' SE FOR PESSOA JURÍDICA
                Dim PJ As clPessoaJuridica = DirectCast(ConverteDtRow_Pessoa(r), clPessoaJuridica)
                '
                If r("Encontrado") = False Then Return PJ ' CLIENTE PJ NÃO FOI ENCONTRADO (RETORNA clPessoaJuridica)
                '
                Select Case ProcurarEm
                    Case "CLIENTE" ' VERIFICA O CLIENTE ENCONTRADO E RETORNA ClientePJ
                        Return ConvertDtRow_Cliente(r) ' RETORNA ClientePJ
                    Case "TRANSPORTADORA"
                        Return ConvertDtRow_Transportadora(r)
                    Case "FORNECEDOR"
                        Return ConvertDtRow_Fornecedor(r)
                    Case Else
                        Return PJ
                End Select
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE VERIFICA SE JÁ EXISTE CLIENTE COM O RGCliente FORNECIDO E RETORNA O ClientePF ou ClientePJ
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ProcurarCliente_RG_Cliente(myRGCliente As Integer) As Object
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        db.AdicionarParametros("@RGCliente", myRGCliente)
        '
        Try
            Dim myTable As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspCliente_Procurar_PorRG")
            '
            Dim r As DataRow = myTable.Rows(0)
            '
            If Not IsDBNull(r("PessoaTipo")) Then
                Return ConvertDtRow_Cliente(r)
            Else ' NÃO ENCONTROU UM CLIENTE PESSOA FÍSICA COM ESSE RG
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE VERIFICA QUAL É O MAIOR RGCliente CADASTRADO E O RETORNA ACRESCIDO DE 1
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ProcurarNextRG() As Integer?
        Dim SQL As New SQLControl

        SQL.ExecQuery("SELECT MAX(tblPessoaCliente.RGCliente) FROM tblPessoaCliente")

        If SQL.HasException(True) Then
            Return Nothing
            Exit Function
        End If

        If SQL.RecordCount > 0 Then
            Dim r As DataRow = SQL.DBDT.Rows(0)
            Return CInt(r(0)) + 1
        Else
            Return 1
        End If
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE CONVERTE UM DATAROW EM UM clPessoaFisica OU UM clPessoaJuridica
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConverteDtRow_Pessoa(myRow As DataRow) As Object
        If myRow("PessoaTipo") = 1 Then
            Dim PF As New clPessoaFisica
            '
            PF.IDPessoa = myRow("IDPessoa")
            PF.Cadastro = If(IsDBNull(myRow("Cadastro")), String.Empty, myRow("Cadastro"))
            PF.Sexo = If(IsDBNull(myRow("Sexo")), Nothing, myRow("Sexo"))
            PF.CPF = If(IsDBNull(myRow("CPF")), String.Empty, myRow("CPF"))
            PF.Identidade = If(IsDBNull(myRow("Identidade")), String.Empty, myRow("Identidade"))
            PF.IdentidadeOrgao = If(IsDBNull(myRow("IdentidadeOrgao")), String.Empty, myRow("IdentidadeOrgao"))
            PF.IdentidadeData = If(IsDBNull(myRow("IdentidadeData")), Nothing, myRow("IdentidadeData"))
            PF.NascimentoData = If(IsDBNull(myRow("NascimentoData")), Nothing, myRow("NascimentoData"))
            '
            PF.Endereco = If(IsDBNull(myRow("Endereco")), String.Empty, myRow("Endereco"))
            PF.Bairro = If(IsDBNull(myRow("Bairro")), String.Empty, myRow("Bairro"))
            PF.Cidade = If(IsDBNull(myRow("Cidade")), String.Empty, myRow("Cidade"))
            PF.UF = If(IsDBNull(myRow("UF")), String.Empty, myRow("UF"))
            PF.CEP = If(IsDBNull(myRow("CEP")), String.Empty, myRow("CEP"))
            '
            PF.Email = If(IsDBNull(myRow("Email")), String.Empty, myRow("Email"))
            PF.TelefoneA = If(IsDBNull(myRow("TelefoneA")), String.Empty, myRow("TelefoneA"))
            PF.TelefoneB = If(IsDBNull(myRow("TelefoneB")), String.Empty, myRow("TelefoneB"))
            '
            Return PF
        ElseIf myRow("PessoaTipo") = 2 Then
            Dim PJ As New clPessoaJuridica
            '
            With PJ
                .IDPessoa = If(IsDBNull(myRow("IDPessoa")), Nothing, myRow("IDPessoa"))
                .Cadastro = If(IsDBNull(myRow("Cadastro")), String.Empty, myRow("Cadastro"))
                .CNPJ = If(IsDBNull(myRow("CNPJ")), String.Empty, myRow("CNPJ"))
                .InscricaoEstadual = If(IsDBNull(myRow("InscricaoEstadual")), String.Empty, myRow("InscricaoEstadual"))
                .FundacaoData = If(IsDBNull(myRow("FundacaoData")), Nothing, myRow("FundacaoData"))
                .ContatoNome = If(IsDBNull(myRow("ContatoNome")), String.Empty, myRow("ContatoNome"))
                .NomeFantasia = If(IsDBNull(myRow("NomeFantasia")), String.Empty, myRow("NomeFantasia"))
                '
                .Endereco = If(IsDBNull(myRow("Endereco")), String.Empty, myRow("Endereco"))
                .Bairro = If(IsDBNull(myRow("Bairro")), String.Empty, myRow("Bairro"))
                .Cidade = If(IsDBNull(myRow("Cidade")), String.Empty, myRow("Cidade"))
                .UF = If(IsDBNull(myRow("UF")), String.Empty, myRow("UF"))
                .CEP = If(IsDBNull(myRow("CEP")), String.Empty, myRow("CEP"))
                '
                .Email = If(IsDBNull(myRow("Email")), String.Empty, myRow("Email"))
                .TelefoneA = If(IsDBNull(myRow("TelefoneA")), String.Empty, myRow("TelefoneA"))
                .TelefoneB = If(IsDBNull(myRow("TelefoneB")), String.Empty, myRow("TelefoneB"))
            End With
            '
            Return PJ
        Else
            Return Nothing
        End If
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE CONVERTE UM DATAROW EM UM clClientePF OU UM clClientePJ
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Cliente(r As DataRow) As Object
        If r("PessoaTipo") = 1 Then
            Dim CliPF As New clClientePF
            With CliPF
                ' PESSOA FISICA
                .IDPessoa = r("IDPessoa")
                .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                .Sexo = If(IsDBNull(r("Sexo")), Nothing, r("Sexo"))
                .CPF = If(IsDBNull(r("CPF")), String.Empty, r("CPF"))
                .Identidade = If(IsDBNull(r("Identidade")), String.Empty, r("Identidade"))
                .IdentidadeOrgao = If(IsDBNull(r("IdentidadeOrgao")), String.Empty, r("IdentidadeOrgao"))
                .IdentidadeData = If(IsDBNull(r("IdentidadeData")), Nothing, r("IdentidadeData"))
                .NascimentoData = If(IsDBNull(r("NascimentoData")), Nothing, r("NascimentoData"))
                '
                .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
                .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
                .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
                .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
                .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
                '
                .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
                .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
                .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
                '
                ' PESSOA CLIENTE
                .IDSituacao = If(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
                .ClienteDesde = If(IsDBNull(r("ClienteDesde")), Nothing, r("ClienteDesde"))
                .RGAtividade = If(IsDBNull(r("RGAtividade")), Nothing, r("RGAtividade"))
                .LimiteCompras = If(IsDBNull(r("LimiteCompras")), Nothing, r("LimiteCompras"))
                .UltimaVenda = If(IsDBNull(r("UltimaVenda")), Nothing, r("UltimaVenda"))
                .RGCliente = If(IsDBNull(r("RGCliente")), Nothing, r("RGCliente"))
                .Observacao = If(IsDBNull(r("Observacao")), "", r("Observacao"))
                ' PESSOA CLIENTEPF
                .Naturalidade = If(IsDBNull(r("Naturalidade")), String.Empty, r("Naturalidade"))
                .Pai = If(IsDBNull(r("Pai")), String.Empty, r("Pai"))
                .Mae = If(IsDBNull(r("Mae")), String.Empty, r("Mae"))
                .TrabalhoContratante = If(IsDBNull(r("TrabalhoContratante")), String.Empty, r("TrabalhoContratante"))
                .TrabalhoFuncao = If(IsDBNull(r("TrabalhoFuncao")), String.Empty, r("TrabalhoFuncao"))
                .TrabalhoTelefone = If(IsDBNull(r("TrabalhoTelefone")), String.Empty, r("TrabalhoTelefone"))
                .Renda = If(IsDBNull(r("Renda")), Nothing, r("Renda"))
                .EstadoCivil = If(IsDBNull(r("EstadoCivil")), Nothing, r("EstadoCivil"))
                .Conjuge = If(IsDBNull(r("Conjuge")), String.Empty, r("Conjuge"))
                .ConjugeRenda = If(IsDBNull(r("ConjugeRenda")), Nothing, r("ConjugeRenda"))
                .Igreja = If(IsDBNull(r("Igreja")), String.Empty, r("Igreja"))
                .IgrejaAtuacao = If(IsDBNull(r("IgrejaAtuacao")), String.Empty, r("IgrejaAtuacao"))
                .IgrejaFuncao = If(IsDBNull(r("IgrejaFuncao")), String.Empty, r("IgrejaFuncao"))
                .FichaPrint = If(IsDBNull(r("FichaPrint")), Nothing, r("FichaPrint"))
            End With
            '
            Return CliPF
        Else
            Dim CliPJ As New clClientePJ
            '
            With CliPJ
                .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
                .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
                .InscricaoEstadual = If(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual"))
                .FundacaoData = If(IsDBNull(r("FundacaoData")), Nothing, r("FundacaoData"))
                .ContatoNome = If(IsDBNull(r("ContatoNome")), String.Empty, r("ContatoNome"))
                .NomeFantasia = If(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia"))
                '
                .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
                .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
                .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
                .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
                .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
                '
                .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
                .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
                .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
                '
                ' PESSOA CLIENTE
                .IDSituacao = If(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
                .ClienteDesde = If(IsDBNull(r("ClienteDesde")), Nothing, r("ClienteDesde"))
                .RGAtividade = If(IsDBNull(r("RGAtividade")), Nothing, r("RGAtividade"))
                .LimiteCompras = If(IsDBNull(r("LimiteCompras")), Nothing, r("LimiteCompras"))
                .UltimaVenda = If(IsDBNull(r("UltimaVenda")), Nothing, r("UltimaVenda"))
                .RGCliente = If(IsDBNull(r("RGCliente")), Nothing, r("RGCliente"))
                .Observacao = If(IsDBNull(r("Observacao")), "", r("Observacao"))
            End With
            '
            Return CliPJ ' RETORNA ClientePJ
        End If
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE CONVERTE UM DATAROW EM UM clFuncionario
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Funcionario(r As DataRow) As clFuncionario
        Dim CliFunc As New clFuncionario
        With CliFunc
            ' PESSOA FISICA
            .IDPessoa = r("IDPessoa")
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            .Sexo = If(IsDBNull(r("Sexo")), Nothing, r("Sexo"))
            .CPF = If(IsDBNull(r("CPF")), String.Empty, r("CPF"))
            .Identidade = If(IsDBNull(r("Identidade")), String.Empty, r("Identidade"))
            .IdentidadeOrgao = If(IsDBNull(r("IdentidadeOrgao")), String.Empty, r("IdentidadeOrgao"))
            .IdentidadeData = If(IsDBNull(r("IdentidadeData")), Nothing, r("IdentidadeData"))
            .NascimentoData = If(IsDBNull(r("NascimentoData")), Nothing, r("NascimentoData"))
            '
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
            '
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
            .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
            .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
            '
            ' PESSOA FUNCIONARIO
            .AdmissaoData = If(IsDBNull(r("AdmissaoData")), Nothing, r("AdmissaoData"))
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
            .Vendedor = If(IsDBNull(r("AdmissaoData")), Nothing, r("AdmissaoData"))
            .ApelidoFuncionario = If(IsDBNull(r("ApelidoFuncionario")), String.Empty, r("ApelidoFuncionario"))
            ' PESSOA VENDEDOR
            .Comissao = If(IsDBNull(r("Comissao")), Nothing, r("Comissao"))
            .VendaTipo = If(IsDBNull(r("VendaTipo")), Nothing, r("VendaTipo"))
            .VendedorAtivo = If(IsDBNull(r("VendedorAtivo")), Nothing, r("VendedorAtivo"))
        End With
        '
        Return CliFunc
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE CONVERTE UM DATAROW EM UM CLTransportadora
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Transportadora(r As DataRow) As clTransportadora
        Dim Transp As New clTransportadora
        With Transp
            ' PESSOA JURIDICA
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
            .InscricaoEstadual = If(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual"))
            .FundacaoData = If(IsDBNull(r("FundacaoData")), Nothing, r("FundacaoData"))
            .ContatoNome = If(IsDBNull(r("ContatoNome")), String.Empty, r("ContatoNome"))
            .NomeFantasia = If(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia"))
            '
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
            '
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
            .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
            .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
            '
            ' PESSOA TRANSPORTADORA
            .IDPessoa = If(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora"))
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
            .Observacao = If(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        End With
        '
        Return Transp
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE CONVERTE UM DATAROW EM UM clFornecedor
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Fornecedor(r As DataRow) As clFornecedor
        Dim Forn As New clFornecedor
        With Forn
            ' PESSOA FISICA
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
            .InscricaoEstadual = If(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual"))
            .FundacaoData = If(IsDBNull(r("FundacaoData")), Nothing, r("FundacaoData"))
            .ContatoNome = If(IsDBNull(r("ContatoNome")), String.Empty, r("ContatoNome"))
            .NomeFantasia = If(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia"))
            '
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
            '
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
            .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
            .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
            '
            ' PESSOA TRANSPORTADORA
            .IDPessoa = If(IsDBNull(r("IDFornecedor")), Nothing, r("IDFornecedor"))
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
            .Observacao = If(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        End With
        '
        Return Forn
    End Function
End Class
