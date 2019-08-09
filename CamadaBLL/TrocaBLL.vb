Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient
'
Public Class TrocaBLL
    '
    '--------------------------------------------------------------------------------------------
    ' GET LIST COM WHERE
    '--------------------------------------------------------------------------------------------
    Public Function GetTroca_List(Optional myWhere As String = "") As List(Of clTroca)
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryTroca"
        Else
            strSql = "SELECT * FROM qryTroca WHERE " & myWhere
        End If
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            Dim lista As New List(Of clTroca)
            '
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each r As DataRow In dt.Rows
                Dim trc As clTroca
                trc = ConvertDtRow_clTroca(r)
                lista.Add(trc)

            Next
            '
            Return lista
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET REGISTRO POR ID/RG
    '--------------------------------------------------------------------------------------------
    Public Function GetTroca_PorIDVenda_clTroca(ByVal myIDVenda As Integer) As clTroca
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        strSql = "SELECT * FROM qryTroca WHERE IDVenda = " & myIDVenda
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            Dim r As DataRow = Nothing
            '
            If dt.Rows.Count > 0 Then
                r = dt.Rows(0)
                Return ConvertDtRow_clTroca(r)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' UPDATE
    '--------------------------------------------------------------------------------------------
    Public Function AtualizaTroca_Procedure_ID(ByVal _troca As clTroca,
                                               Optional dBTran As Object = Nothing) As Object
        '
        Dim objDB As AcessoDados = If(dBTran, New AcessoDados)
        Dim Conn As New SqlCommand
        '
        'Limpa os Parâmetros
        objDB.LimparParametros()
        '
        '--- Inserir Parametros
        objDB.AdicionarParametros("@IDTroca", _troca.IDTroca)
        objDB.AdicionarParametros("@IDTransacaoEntrada", _troca.IDTransacaoEntrada)
        objDB.AdicionarParametros("@TrocaData", _troca.TrocaData)
        objDB.AdicionarParametros("@IDPessoaOrigem", _troca.IDPessoaTroca)
        objDB.AdicionarParametros("@ValorTotal", _troca.ValorTotal)
        objDB.AdicionarParametros("@IDSituacao", _troca.IDSituacao)
        objDB.AdicionarParametros("@Observacao", _troca.Observacao)
        '
        Try
            Return objDB.ExecutarManipulacao(CommandType.StoredProcedure, "uspTroca_Alterar")
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' INSERT NOVA TROCA E RETORNA UMA CLTROCA
    '--------------------------------------------------------------------------------------------
    Public Function InsereNovaTroca_Procedure(ByVal _troca As clTroca, _IDUser As Integer) As clTroca
        '
        Try
            Dim dtTroca As DataTable
            '
            dtTroca = InsereNovaTroca_Procedure_DT(_troca, _IDUser)
            If dtTroca.Rows.Count > 0 Then
                Dim r As DataRow = dtTroca(0)
                '
                Return ConvertDtRow_clTroca(r)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '================================================================================
    ' EFETUA NOVA TROCA SIMPLES
    '================================================================================
    Public Function TrocaSimples_Nova(
                                      IDVenda As Integer,
                                      TrocaData As Date,
                                      IDFilial As Integer,
                                      ApelidoFilial As String,
                                      IDPessoaTroca As Integer,
                                      PessoaTroca As String,
                                      Usuario As Integer
                                     ) As clTroca
        '
        '--- Insere um novo Registro de TROCA
        '---------------------------------------------------------------------------------------
        '
        Try
            Dim newTroca As New clTroca(IDVenda, TrocaData, IDFilial, ApelidoFilial, IDPessoaTroca, PessoaTroca)
            '
            newTroca = InsereNovaTroca_Procedure(newTroca, Usuario)
            '
            If IsNothing(newTroca) Then
                Throw New Exception("Um erro ocorreu ao salvar ao Inserir Nova Troca")
            End If
            '
            Return newTroca
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' INSERT NOVA TROCA E RETORNA UM DATATABLE
    '--------------------------------------------------------------------------------------------
    Public Function InsereNovaTroca_Procedure_DT(ByVal _troca As clTroca, _IDUser As Integer) As DataTable
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand
        '
        'Adiciona os Parâmetros
        objDB.LimparParametros()
        '
        '@IDUser AS INT
        objDB.AdicionarParametros("@IDUser", _IDUser)
        '
        '@TrocaData AS DATE
        objDB.AdicionarParametros("@TrocaData", _troca.TrocaData)
        '
        '@IDVenda AS INT
        objDB.AdicionarParametros("@IDVenda", _troca.IDVenda)
        '
        '@IDFilial AS INT
        objDB.AdicionarParametros("@IDFilial", _troca.IDFilial)
        '
        '@IDPessoaOrigem AS INT
        objDB.AdicionarParametros("@IDPessoaOrigem", _troca.IDPessoaTroca)
        '
        '@Observacao AS STRING
        objDB.AdicionarParametros("@Observacao", _troca.Observacao)
        '
        '
        Try
            Dim dtV As DataTable = objDB.ExecutarConsulta(CommandType.StoredProcedure, "uspTroca_Inserir")
            '
            If dtV.Rows.Count = 0 Then
                Throw New Exception("Um erro ineperado ocorreu ao INSERIR NOVA TROCA")
            End If
            '
            If IsNumeric(dtV.Rows(0).Item(0)) Then
                Return dtV
            Else
                Throw New Exception(dtV.Rows(0).Item(0))
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' DELETE TROCA POR IDTROCA
    '--------------------------------------------------------------------------------------------
    Public Function DeletaTrocaPorID(ByVal IDTroca As Integer,
                                     Optional myDB As Object = Nothing) As Object
        '
        Dim db As AcessoDados = If(myDB, New AcessoDados)
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDTroca", IDTroca)
        '
        Try
            Dim ret As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTroca_Excluir")
            '
            If ret.GetType().Equals(GetType(String)) AndAlso ret <> "TRUE" Then
                Throw New Exception(ret)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
        Return True
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' CONVERT DATAROW DA DATATABLE TROCA EM UM CLTROCA
    '--------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_clTroca(r As DataRow) As clTroca
        '
        '--- origem DATAROW: qryTroca
        '--- Dados do tblAReceber
        Dim t As clTroca = New clTroca With {
            .IDTroca = IIf(IsDBNull(r("IDTroca")), Nothing, r("IDTroca")),
            .TrocaData = IIf(IsDBNull(r("TrocaData")), Nothing, r("TrocaData")),
            .IDTransacaoEntrada = IIf(IsDBNull(r("IDTransacaoEntrada")), Nothing, r("IDTransacaoEntrada")),
            .IDVenda = IIf(IsDBNull(r("IDVenda")), Nothing, r("IDVenda")),
            .IDPessoaTroca = IIf(IsDBNull(r("IDPessoaTroca")), Nothing, r("IDPessoaTroca")),
            .PessoaTroca = IIf(IsDBNull(r("PessoaTroca")), String.Empty, r("PessoaTroca")),
            .IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial")),
            .ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial")),
            .IDVendedor = IIf(IsDBNull(r("IDVendedor")), Nothing, r("IDVendedor")),
            .ApelidoVenda = IIf(IsDBNull(r("ApelidoVenda")), String.Empty, r("ApelidoVenda")),
            .ValorTotal = IIf(IsDBNull(r("ValorTotal")), Nothing, r("ValorTotal")),
            .Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao")),
            .IDSituacao = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao")),
            .Situacao = IIf(IsDBNull(r("Situacao")), String.Empty, r("Situacao"))
        }
        '
        Return t
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET LISTA TROCA PARA FRMPROCURA RETORNA LIST OF CLTROCA
    '--------------------------------------------------------------------------------------------
    Public Function GetTrocaLista_Procura(Optional dtInicial As Date? = Nothing,
                                          Optional dtFinal As Date? = Nothing) As List(Of clTroca)
        '
        Dim sql As New SQLControl
        '
        Dim myQuery As String = "SELECT * FROM qryTroca"
        '
        If Not IsNothing(dtInicial) OrElse Not IsNothing(dtFinal) Then
            '
            myQuery = myQuery & " WHERE "
            '
            If Not IsNothing(dtInicial) Then
                sql.AddParam("@DataInicial", dtInicial)
                myQuery = myQuery & " TrocaData >= @DataInicial"
            End If
            '
            If Not IsNothing(dtFinal) Then
                sql.AddParam("@DataFinal", dtFinal)
                '
                If Not IsNothing(dtInicial) Then myQuery = myQuery & " AND "
                '
                myQuery = myQuery & " TrocaData <= @DataFinal"
            End If
            '
        End If
        '
        Try
            Dim tList As New List(Of clTroca)
            '
            sql.ExecQuery(myQuery)
            '
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            If sql.DBDT.Rows.Count = 0 Then Return tList
            '
            For Each r As DataRow In sql.DBDT.Rows
                Dim trc As New clTroca
                '
                trc = ConvertDtRow_clTroca(r)
                '
                tList.Add(trc)
                '
            Next
            '
            Return tList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
