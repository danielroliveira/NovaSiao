Imports CamadaDAL
Imports CamadaDTO
'
Public Class FilialBLL
    '---------------------------------------------------------------------------------------------------
    ' GET DATABLE
    '---------------------------------------------------------------------------------------------------
    Public Function GetFiliais(Optional SomenteAtivas As Boolean = False) As List(Of clfilial)
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
            Dim dt As DataTable = objdb.ExecuteConsultaSQL_DataTable(strSql)
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
            .InsercaoData = If(IsDBNull(r("InsercaoData")), String.Empty, r("InsercaoData"))
        }
        '
        Return Fil
    End Function
    '
End Class
