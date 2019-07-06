Imports CamadaDAL
Imports CamadaDTO

Public Class FreteBLL
    '
    '===================================================================================================
    ' ALTERAR FRETE
    '===================================================================================================
    Public Function FreteUpdate(frete As clFrete, Optional dbTran As Object = Nothing) As Integer
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDTransacao", frete.IDTransacao)
        db.AdicionarParametros("@Conhecimento", If(frete.Conhecimento, DBNull.Value))
        db.AdicionarParametros("@ConhecimentoData", If(frete.ConhecimentoData, DBNull.Value))
        db.AdicionarParametros("@IDTransportadora", frete.IDTransportadora)
        db.AdicionarParametros("@FreteValor", frete.FreteValor)
        db.AdicionarParametros("@IDFreteDespesa", If(frete.IDFreteDespesa, DBNull.Value))
        db.AdicionarParametros("@Volumes", frete.Volumes)
        '
        Dim myQuery As String =
            "UPDATE tblFrete SET " &
            "Conhecimento = @Conhecimento, " &
            "ConhecimentoData = @ConhecimentoData, " &
            "IDTransportadora = @IDTransportadora, " &
            "FreteValor = @FreteValor, " &
            "IDFreteDespesa = @IDFreteDespesa, " &
            "Volumes = @Volumes " &
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
            myQuery = myQuery & "AND IDFreteDespesa IS NULL "
        Else
            myQuery = myQuery & "AND IDFreteDespesa IS NOT NULL "
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
        frete.Conhecimento = IIf(IsDBNull(r("Conhecimento")), String.Empty, r("Conhecimento"))
        frete.ConhecimentoData = IIf(IsDBNull(r("ConhecimentoData")), Nothing, r("ConhecimentoData"))
        frete.IDFreteDespesa = IIf(IsDBNull(r("IDFreteDespesa")), Nothing, r("IDFreteDespesa"))
        frete.IDTransportadora = IIf(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora"))
        frete.Transportadora = IIf(IsDBNull(r("Transportadora")), String.Empty, r("Transportadora"))
        frete.Volumes = IIf(IsDBNull(r("Volumes")), Nothing, r("Volumes"))
        '
        Return frete
        '
    End Function
    '
    '==========================================================================================
    ' ADD FRETE DESPESA
    '==========================================================================================
    Private Function FreteDespesaAdd(FreteDespesaValor As Decimal, dbTran As Object) As Integer
        '
        Dim db As AcessoDados = dbTran
        '
        db.LimparParametros()
        db.AdicionarParametros("@FreteDespesaData", Today)
        db.AdicionarParametros("@FreteDespesaValor", FreteDespesaValor)
        '
        Dim myQuery As String = "INSERT INTO tblFreteDespesa " &
                                "(FreteDespesaData, FreteDespesaValor) " &
                                "VALUES (@FreteDespesaData, @FreteDespesaValor)"
        '
        Try
            '
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- obter NewID
            db.LimparParametros()
            myQuery = "SELECT @@IDENTITY As LastID;"
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            Dim newID As Object = dt.Rows(0)(0)
            '
            If IsNumeric(newID) Then
                Return newID
            Else
                Throw New Exception(newID.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' FRETE DESPESA APAGAR CREATE
    '==========================================================================================
    Public Function FreteDespesaCreate(freteList As List(Of clFrete), aPagar As clAPagar) As Integer
        '
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        Try
            '
            '--- CREATE NEW FRETE DESPESA
            '----------------------------------------------------------------------------------
            Dim despesaValor As Decimal = freteList.Sum(Function(x) x.FreteValor)
            Dim newID As Integer = FreteDespesaAdd(despesaValor, db)
            '
            '--- UPDATE FRETES WITH NEW ID FRETEDESPESA
            '----------------------------------------------------------------------------------
            For Each frete In freteList
                frete.IDFreteDespesa = newID
                FreteUpdate(frete, db)
            Next
            '
            '--- CREATE NEW APAGAR
            '----------------------------------------------------------------------------------
            Dim pagBLL As New APagarBLL
            '
            aPagar.IDOrigem = newID
            pagBLL.InserirNovo_APagar(aPagar, db)
            '
            db.CommitTransaction()
            Return newID
            '
        Catch ex As Exception
            db.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
End Class
