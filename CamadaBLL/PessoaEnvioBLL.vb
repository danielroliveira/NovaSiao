Imports CamadaDAL
Imports CamadaDTO

Public Class PessoaEnvioBLL
    '
    '==========================================================================================
    ' GET LIST OF PESSOA ENVIO
    '==========================================================================================
    Public Function GetPessoaEnvios() As List(Of clPessoaEnvio)
        '
        Dim db As New AcessoDados
        Dim query As String = ""
        '
        query = "SELECT * FROM tblPessoaEnvio"
        '
        Try
            Dim list As New List(Of clPessoaEnvio)
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return list
            '
            For Each r As DataRow In dt.Rows
                list.Add(ConvertDtRow_PessoaEnvio(r))
            Next
            '
            Return list
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET LIST OF PESSOA ENVIO ENDERECOS
    '==========================================================================================
    Public Function GetPessoaEnvioEnderecos() As List(Of clPessoaEnvioEndereco)
        '
        Dim db As New AcessoDados
        Dim query As String = ""
        '
        query = "SELECT * FROM  qryPessoaEnvioEndereco"
        '
        Try
            Dim list As New List(Of clPessoaEnvioEndereco)
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return list
            '
            For Each r As DataRow In dt.Rows
                list.Add(ConvertDtRow_PessoaEnvioEndereco(r))
            Next
            '
            Return list
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UMA CLASSE
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_PessoaEnvio(r As DataRow) As clPessoaEnvio
        '
        Dim PE As New clPessoaEnvio With {
            .IDPessoaEnvio = If(IsDBNull(r("IDPessoaEnvio")), Nothing, r("IDPessoaEnvio")),
            .EnvioDescricao = If(IsDBNull(r("EnvioDescricao")), String.Empty, r("EnvioDescricao")),
            .Impresso = If(IsDBNull(r("Impresso")), False, r("Impresso")),
            .Enviado = If(IsDBNull(r("Enviado")), False, r("Enviado")),
            .EnvioData = If(IsDBNull(r("EnvioData")), Nothing, r("EnvioData"))
        }
        '
        Return PE
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UMA CLASSE
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_PessoaEnvioEndereco(r As DataRow) As clPessoaEnvioEndereco
        '
        Dim PE As New clPessoaEnvioEndereco With {
            .IDPessoaEnvio = If(IsDBNull(r("IDPessoaEnvio")), Nothing, r("IDPessoaEnvio")),
            .EnvioDescricao = If(IsDBNull(r("EnvioDescricao")), String.Empty, r("EnvioDescricao")),
            .Impresso = If(IsDBNull(r("Impresso")), False, r("Impresso")),
            .Enviado = If(IsDBNull(r("Enviado")), False, r("Enviado")),
            .EnvioData = If(IsDBNull(r("EnvioData")), Nothing, r("EnvioData")),
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa")),
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro")),
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco")),
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro")),
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade")),
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF")),
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
        }
        '
        Return PE
        '
    End Function
    '
    '==========================================================================================
    ' INSERT PESSOA ENVIO
    '==========================================================================================
    Public Function InsertEnvio(envio As clPessoaEnvio,
                                Optional dbTran As Object = Nothing) As clPessoaEnvio
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        Try
            '
            Dim query As String = ""
            query = "INSERT INTO tblPessoaEnvio " &
                    "(EnvioDescricao, EnvioData, Impresso, Enviado) " &
                    "VALUES " &
                    "(@EnvioDescricao, @EnvioData, @Impresso, @Enviado)"
            '
            db.LimparParametros()
            db.AdicionarParametros("@EnvioDescricao", envio.EnvioDescricao)
            db.AdicionarParametros("@EnvioData", envio.EnvioData)
            db.AdicionarParametros("@Impresso", envio.Impresso)
            db.AdicionarParametros("@Enviado", envio.Enviado)
            '
            Dim NewID As Integer = db.ExecutarInsertGetID(query)
            '
            '--- return
            envio.IDPessoaEnvio = NewID
            Return envio
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' INSERT ONE ITEM PESSOA IN ENVIO
    '==========================================================================================
    Public Function InsertEnvioPessoa(IDPessoaEnvio As Integer,
                                      IDPessoa As Integer,
                                      Optional dtPostagem As Date = Nothing,
                                      Optional dbTran As Object = Nothing) As Boolean
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        Try
            '
            Dim query As String = ""
            query = "INSERT INTO tblPessoaEnvioEndereco " &
                    "(IDPessoaEnvio, IDPessoa, DataPostagem) " &
                    "VALUES " &
                    "(@IDPessoaEnvio, @IDPessoa, @DataPostagem)"
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDPessoaEnvio", IDPessoaEnvio)
            db.AdicionarParametros("@IDPessoa", IDPessoa)
            db.AdicionarParametros("@DataPostagem", dtPostagem)
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            '--- return
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
