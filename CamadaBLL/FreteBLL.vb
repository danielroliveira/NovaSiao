Imports CamadaDAL
Imports CamadaDTO

Public Class FreteBLL
    '
    '===================================================================================================
    ' ALTERAR FRETE
    '===================================================================================================
    Public Function Despesa_Alterar(frete As clFrete, dbTran As Object) As Integer
        Dim db As AcessoDados = dbTran
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("IDTransacao", frete.IDTransacao)
        db.AdicionarParametros("Conhecimento", If(frete.Conhecimento, DBNull.Value))
        db.AdicionarParametros("ConhecimentoData", If(frete.ConhecimentoData, DBNull.Value))
        db.AdicionarParametros("IDTransportadora", frete.IDTransportadora)
        db.AdicionarParametros("FreteValor", frete.FreteValor)
        db.AdicionarParametros("IDAPagar", If(frete.IDAPagar, DBNull.Value))
        db.AdicionarParametros("Volumes", frete.Volumes)
        '
        Dim myQuery As String =
            "UPDATE tblFrete SET " &
            "Conhecimento = @Conhecimento, " &
            "ConhecimentoData = @ConhecimentoData, " &
            "IDTransportadora = @IDTransportadora, " &
            "FreteValor = @FreteValor, " &
            "IDAPagar = @IDAPagar, " &
            "Volumes = @Volumes, " &
            "WHERE IDTransacao = @IDTransacao"
        '
        '-- Update a despesa
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            Return frete.IDTransacao
            '
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET FRETE por IDTransacao
    '--------------------------------------------------------------------------------------------
    Public Function GetFrete_PorID(myIDTransacao As Integer) As clFrete
        Dim SQL As New SQLControl
        '
        Dim strSQL = "SELECT * FROM qryFrete WHERE IDTransacao = " & myIDTransacao
        '
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount = 0 Then
                Throw New Exception("Não retornou nenhum registro de Frete")
            End If
            '
            Dim r As DataRow = SQL.DBDT.Rows(0)
            '
            Return ConvertRow(r)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' GET LISTA FRETE PARA FRMPROCURA
    '===================================================================================================
    Public Function GetAPagarLista_Procura(myIDFilial As Integer,
                                           Cobradas As Boolean,
                                           IDTransportadora As Integer?,
                                           Optional dtInicial As Date? = Nothing,
                                           Optional dtFinal As Date? = Nothing) As List(Of clFrete)
        '
        Dim db As New AcessoDados
        db.LimparParametros()
        '
        '--- ADICIONA PARAMETROS
        '--------------------------------------------------------------------------------------------
        db.AdicionarParametros("@IDFilial", myIDFilial)
        '
        '--- CRIA MYQUERY
        Dim myQuery As String = "SELECT * FROM qryFretes WHERE IDFilial = @IDFilial "
        '
        If Not Cobradas Then
            myQuery = myQuery & "AND IDAPagar IS NULL "
        Else
            myQuery = myQuery & "AND IDAPagar IS NOT NULL "
        End If
        '
        If Not IsNothing(IDTransportadora) Then
            db.AdicionarParametros("@IDTransportadora", IDTransportadora)
            myQuery = myQuery & "AND IDTransportadora = @IDTransportadora "
        End If
        '
        If Not IsNothing(dtInicial) Then
            db.AdicionarParametros("@DataInicial", dtInicial)
            myQuery = myQuery & "AND TransacaoData >= @DataInicial "
        End If
        '
        If Not IsNothing(dtFinal) Then
            db.AdicionarParametros("@DataFinal", dtFinal)
            myQuery = myQuery & "AND TransacaoData <= @DataFinal "
        End If
        '
        '--- EXECUTA CONSULTA QUERY E CRIA A LISTA
        '--------------------------------------------------------------------------------------------
        Try
            Dim fList As New List(Of clFrete)
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then Return fList
            '
            For Each r As DataRow In dt.Rows
                fList.Add(ConvertRow(r))
            Next
            '
            Return fList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--- CONVERT DATAROW IN CLASS
    '----------------------------------------------------------------------------------
    Private Function ConvertRow(r As DataRow) As clFrete
        '
        Dim frete As New clFrete(r("IDTransacao"), r("TransacaoData"), r("IDFilial"))
        '
        frete.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao"))
        frete.Operacao = IIf(IsDBNull(r("Operacao")), String.Empty, r("Operacao"))
        frete.FreteTipo = IIf(IsDBNull(r("FreteTipo")), Nothing, r("FreteTipo"))
        frete.FreteTipoTexto = IIf(IsDBNull(r("FreteTipoTexto")), String.Empty, r("FreteTipoTexto"))
        frete.FreteValor = IIf(IsDBNull(r("FreteValor")), Nothing, r("FreteValor"))
        frete.Conhecimento = IIf(IsDBNull(r("Conhecimento")), Nothing, r("Conhecimento"))
        frete.ConhecimentoData = IIf(IsDBNull(r("ConhecimentoData")), Nothing, r("ConhecimentoData"))
        frete.IDAPagar = IIf(IsDBNull(r("IDAPagar")), Nothing, r("IDAPagar"))
        frete.IDTransportadora = IIf(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora"))
        frete.Transportadora = IIf(IsDBNull(r("Transportadora")), String.Empty, r("Transportadora"))
        frete.Volumes = IIf(IsDBNull(r("Volumes")), Nothing, r("Volumes"))
        '
        Return frete
        '
    End Function
    '
End Class
