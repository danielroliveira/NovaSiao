Imports CamadaDAL
Imports CamadaDTO
'
Public Class FilialBLL
    '
    '---------------------------------------------------------------------------------------------------
    ' GET DATABLE
    '---------------------------------------------------------------------------------------------------
    Public Function GetFiliais(Optional SomenteAtivas As Boolean = False) As List(Of clFilial)
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        If SomenteAtivas = False Then
            strSql = "SELECT * FROM qryFilial"
        ElseIf SomenteAtivas = True Then
            strSql = "SELECT * FROM qryFilial WHERE Ativo = 1"
        End If
        '
        Try
            Dim lstFilial As New List(Of clFilial)
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            '
            If dt.Rows.Count = 0 Then Return lstFilial
            '
            For Each r As DataRow In dt.Rows
                lstFilial.Add(ConvertDtRow_Filial(r))
            Next
            '
            Return lstFilial
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UM CLFilial
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Filial(r As DataRow) As clFilial
        '
        Dim Fil As New clFilial With {
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa")),
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro")),
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo")),
            .AliquotaICMS = If(IsDBNull(r("AliquotaICMS")), Nothing, r("AliquotaICMS")),
            .ApelidoFilial = If(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial")),
            .PessoaTipo = If(IsDBNull(r("PessoaTipo")), String.Empty, r("PessoaTipo")),
            .InsercaoData = If(IsDBNull(r("InsercaoData")), String.Empty, r("InsercaoData")),
            .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
        }
        '
        Return Fil
    End Function
    '
    '---------------------------------------------------------------------------------------------------
    ' GET DATABLE FILIAL DADOS
    '---------------------------------------------------------------------------------------------------
    Public Function GetFilialDados(IDFilial As Integer, Optional SomenteAtivas As Boolean = False) As clFilialDados
        '
        Dim db As New AcessoDados
        Dim strSql As String = ""
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDFilial", IDFilial)
        '
        If SomenteAtivas = False Then
            strSql = "SELECT * FROM qryFilialDados WHERE IDFilial = @IDFilial"
        ElseIf SomenteAtivas = True Then
            strSql = "SELECT * FROM qryFilialDados WHERE IDFilial = @IDFilial AND Ativo = 'TRUE'"
        End If
        '
        Try
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, strSql)
            '
            If dt.Rows.Count = 0 Then Return Nothing
            '
            If IsNumeric(dt.Rows(0).Item(0)) Then
                Return ConvertDtRow_FilialDados(dt.Rows(0))
            Else
                Throw New Exception(dt.Rows(0).Item(0))
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UM CLFilial
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_FilialDados(r As DataRow) As clFilialDados
        '
        Dim Fil As New clFilialDados With {
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa")),
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro")),
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo")),
            .AliquotaICMS = If(IsDBNull(r("AliquotaICMS")), Nothing, r("AliquotaICMS")),
            .ApelidoFilial = If(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial")),
            .PessoaTipo = If(IsDBNull(r("PessoaTipo")), String.Empty, r("PessoaTipo")),
            .InsercaoData = If(IsDBNull(r("InsercaoData")), String.Empty, r("InsercaoData")),
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco")),
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro")),
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade")),
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF")),
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP")),
            .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ")),
            .ContatoFinanceiro = If(IsDBNull(r("ContatoFinanceiro")), String.Empty, r("ContatoFinanceiro")),
            .ContatoGerencia = If(IsDBNull(r("ContatoGerencia")), String.Empty, r("ContatoGerencia")),
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email")),
            .InscricaoEstadual = If(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual")),
            .NomeFantasia = If(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia")),
            .NumeroWhatsapp = If(IsDBNull(r("NumeroWhatsapp")), String.Empty, r("NumeroWhatsapp")),
            .TelefoneFinanceiro = If(IsDBNull(r("TelefoneFinanceiro")), String.Empty, r("TelefoneFinanceiro")),
            .TelefoneGerencia = If(IsDBNull(r("TelefoneGerencia")), String.Empty, r("TelefoneGerencia")),
            .TelefonePrincipal = If(IsDBNull(r("TelefonePrincipal")), String.Empty, r("TelefonePrincipal"))
        }
        '
        Return Fil
        '
    End Function
    '
End Class
