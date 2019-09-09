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
    Public Function InsertEnvio(envio As clPessoaEnvio) As clPessoaEnvio
        '

        '
    End Function
    '
    '==========================================================================================
    ' INSERT ONE ITEM PESSOA IN ENVIO
    '==========================================================================================
    Public Function InsertEnvioPessoa(IDPessoaEnvio As Integer,
                                      IDPessoa As Integer,
                                      Optional dtPostagem As Date = Nothing) As clPessoaEnvioEndereco
        '

        '
    End Function
    '
End Class
