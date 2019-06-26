Imports CamadaDAL
Imports CamadaDTO
'
Public Class DespesaBLL
    '===================================================================================================
    ' INSERIR NOVA DESPESA
    '===================================================================================================
    Public Function Despesa_Inserir(myDespesa As clDespesa, dbTran As Object) As Integer
        Dim db As AcessoDados = dbTran
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("IDCredor", myDespesa.IDCredor)
        db.AdicionarParametros("IDDespesaTipo", myDespesa.IDDespesaTipo)
        db.AdicionarParametros("IDFilial", myDespesa.IDFilial)
        db.AdicionarParametros("DespesaData", myDespesa.DespesaData)
        db.AdicionarParametros("DespesaValor", myDespesa.DespesaValor)
        db.AdicionarParametros("Descricao", myDespesa.Descricao)
        db.AdicionarParametros("Parcelado", myDespesa.Parcelado)
        '

        '
        '---Inserir a despesa
        Try
            Dim newID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspDespesa_Inserir")
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

    End Function
    '
    '===================================================================================================
    ' ALTERAR DESPESA
    '===================================================================================================
    Public Function Despesa_Alterar(myDespesa As clDespesa) As Integer
        Dim db As New AcessoDados
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("IDDespesa", myDespesa.IDDespesa)
        db.AdicionarParametros("IDCredor", myDespesa.IDCredor)
        db.AdicionarParametros("IDDespesaTipo", myDespesa.IDDespesaTipo)
        db.AdicionarParametros("IDFilial", myDespesa.IDFilial)
        db.AdicionarParametros("DespesaData", myDespesa.DespesaData)
        db.AdicionarParametros("DespesaValor", myDespesa.DespesaValor)
        db.AdicionarParametros("Descricao", myDespesa.Descricao)
        db.AdicionarParametros("Parcelado", myDespesa.Parcelado)
        '
        '---Inserir a despesa
        Try
            Dim newID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspDespesa_Alterar")
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

    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET LISTA DESPESA PARA FRMPROCURA
    '--------------------------------------------------------------------------------------------
    Public Function GetDespesaLista_Procura(myIDDespesaTipo As Integer?, myIDCredor As Integer?,
                                            myDescricao As String,
                                            Optional dtInicial As Date? = Nothing,
                                            Optional dtFinal As Date? = Nothing) As List(Of clDespesa)
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDDespesaTipo", myIDDespesaTipo)
        db.AdicionarParametros("@IDCredor", myIDCredor)
        db.AdicionarParametros("@Descricao", myDescricao)
        If Not IsNothing(dtInicial) Then
            db.AdicionarParametros("@DataInicial", dtInicial)
        End If
        '
        If Not IsNothing(dtFinal) Then
            db.AdicionarParametros("@DataFinal", dtFinal)
        End If
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspDespesa_ProcurarLista")
            Dim dList As New List(Of clDespesa)
            '
            For Each r In dt.Rows
                Dim d As New clDespesa
                '
                d.IDDespesa = IIf(IsDBNull(r("IDDespesa")), Nothing, r("IDDespesa"))
                d.IDCredor = IIf(IsDBNull(r("IDCredor")), Nothing, r("IDCredor"))
                d.IDDespesaTipo = IIf(IsDBNull(r("IDDespesaTipo")), Nothing, r("IDDespesaTipo"))
                d.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
                d.Descricao = IIf(IsDBNull(r("Descricao")), String.Empty, r("Descricao"))
                d.DespesaData = IIf(IsDBNull(r("DespesaData")), Nothing, r("DespesaData"))
                d.DespesaValor = IIf(IsDBNull(r("DespesaValor")), Nothing, r("DespesaValor"))
                d.Parcelado = IIf(IsDBNull(r("Parcelado")), Nothing, r("Parcelado"))
                d.Bloqueada = IIf(IsDBNull(r("Bloqueada")), Nothing, r("Bloqueada"))
                d.ValorPagoTotal = IIf(IsDBNull(r("ValorPagoTotal")), Nothing, r("ValorPagoTotal"))
                d.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
                d.DespesaTipo = IIf(IsDBNull(r("DespesaTipo")), String.Empty, r("DespesaTipo"))
                d.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                '
                dList.Add(d)
                '
            Next
            '
            Return dList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------
    ' GET DESPESA por IDDespesa
    '--------------------------------------------------------------------------------------------
    Public Function GetDespesa_PorID(myIDDespesa As Integer) As clDespesa
        Dim SQL As New SQLControl
        '
        Dim strSQL = "SELECT * FROM qryDespesa WHERE IDDespesa = " & myIDDespesa
        '
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount = 0 Then
                Throw New Exception("Não retornou nenhum registro de Despesa")
            End If
            '
            Dim r As DataRow = SQL.DBDT.Rows(0)
            Dim clD As New clDespesa

            '
            clD.IDDespesa = IIf(IsDBNull(r("IDDespesa")), Nothing, r("IDDespesa"))
            clD.IDCredor = IIf(IsDBNull(r("IDCredor")), Nothing, r("IDCredor"))
            clD.IDDespesaTipo = IIf(IsDBNull(r("IDDespesaTipo")), Nothing, r("IDDespesaTipo"))
            clD.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
            clD.Descricao = IIf(IsDBNull(r("Descricao")), String.Empty, r("Descricao"))
            clD.DespesaData = IIf(IsDBNull(r("DespesaData")), Nothing, r("DespesaData"))
            clD.DespesaValor = IIf(IsDBNull(r("DespesaValor")), Nothing, r("DespesaValor"))
            clD.Parcelado = IIf(IsDBNull(r("Parcelado")), Nothing, r("Parcelado"))
            clD.Bloqueada = IIf(IsDBNull(r("Bloqueada")), Nothing, r("Bloqueada"))
            clD.ValorPagoTotal = IIf(IsDBNull(r("ValorPagoTotal")), Nothing, r("ValorPagoTotal"))
            clD.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
            clD.DespesaTipo = IIf(IsDBNull(r("DespesaTipo")), String.Empty, r("DespesaTipo"))
            clD.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            '
            Return clD
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' DESPESA SIMPLES INSERIR E QUITAR E RETORNA clCaixaMovimentacao
    '===================================================================================================
    Public Function DespesaSimples_InserirQuitar(myDespesa As clDespesa,
                                                 myAPagar As clAPagar,
                                                 myMovSaida As clMovimentacao) As clMovimentacao
        Dim db As New AcessoDados
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDCredor", myDespesa.IDCredor)
        db.AdicionarParametros("@IDDespesaTipo", myDespesa.IDDespesaTipo)
        db.AdicionarParametros("@IDFilial", myDespesa.IDFilial)
        db.AdicionarParametros("@DespesaData", myDespesa.DespesaData)
        db.AdicionarParametros("@DespesaValor", myDespesa.DespesaValor)
        db.AdicionarParametros("@Descricao", myDespesa.Descricao)
        '
        db.AdicionarParametros("@IDCobrancaForma", myAPagar.IDCobrancaForma)
        db.AdicionarParametros("@Identificador", myAPagar.Identificador)
        db.AdicionarParametros("@RGBanco", myAPagar.RGBanco)
        db.AdicionarParametros("@Acrescimo", myAPagar.Acrescimo)
        '
        db.AdicionarParametros("@IDConta", myMovSaida.IDConta)
        db.AdicionarParametros("@Observacao", myMovSaida.Observacao)
        '
        If Not IsNothing(myMovSaida.IDCaixa) Then
            db.AdicionarParametros("@IDCaixa", myMovSaida.IDCaixa)
        End If
        '
        '---Inserir a despesa
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspDespesaSimples_InserirQuitar")
            '
            If dt.Rows.Count = 0 Then
                Throw New Exception("ERRO: Não foi retornado nenhum registro...")
            End If
            '
            Dim r As DataRow = dt.Rows(dt.Rows.Count - 1)
            '
            myMovSaida.IDMovimentacao = IIf(IsDBNull(r("ID")), Nothing, r("ID"))
            myMovSaida.IDOrigem = IIf(IsDBNull(r("IDOrigem")), Nothing, r("IDOrigem"))
            myMovSaida.Origem = IIf(IsDBNull(r("Origem")), Nothing, r("Origem"))
            myMovSaida.Mov = IIf(IsDBNull(r("Mov")), String.Empty, r("Mov"))
            myMovSaida.MovValor = IIf(IsDBNull(r("MovValor")), Nothing, r("MovValor"))
            myMovSaida.MovData = IIf(IsDBNull(r("MovData")), Nothing, r("MovData"))
            myMovSaida.IDMovForma = IIf(IsDBNull(r("IDMovForma")), Nothing, r("IDMovForma"))
            myMovSaida.MovForma = IIf(IsDBNull(r("MovForma")), String.Empty, r("MovForma"))
            myMovSaida.IDConta = IIf(IsDBNull(r("IDConta")), Nothing, r("IDConta"))
            myMovSaida.Descricao = IIf(IsDBNull(r("Descricao")), String.Empty, r("Descricao"))
            '
            Return myMovSaida
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
'
Public Class DespesaTipoBLL
    '===================================================================================================
    ' OBTER TIPOS DE DESPESA
    '===================================================================================================
    Public Function DespesaTipo_GET() As List(Of clDespesaTipo)
        Dim SQL As New SQLControl
        '
        Dim mySQL As String = String.Format("SELECT * FROM tblDespesaTipo")
        SQL.ExecQuery(mySQL)
        '
        If SQL.HasException Then
            Throw New Exception(SQL.Exception)
        End If
        '
        Dim dtList As New List(Of clDespesaTipo)
        '
        If SQL.DBDT.Rows.Count = 0 Then
            Return dtList
        End If
        '
        For Each r In SQL.DBDT.Rows
            Dim dt As New clDespesaTipo
            '
            dt.IDDespesaTipo = IIf(IsDBNull(r("IDDespesaTipo")), Nothing, r("IDDespesaTipo"))
            dt.DespesaTipo = IIf(IsDBNull(r("DespesaTipo")), String.Empty, r("DespesaTipo"))
            dt.Periodicidade = IIf(IsDBNull(r("Periodicidade")), Nothing, r("Periodicidade"))
            dt.Variacao = IIf(IsDBNull(r("Variacao")), Nothing, r("Variacao"))
            '
            dtList.Add(dt)
            '
        Next
        '
        Return dtList
        '
    End Function
    '
    '===================================================================================================
    ' SALVAR NOVO TIPO DE DESPESA
    '===================================================================================================
    Public Function DespesaTipo_Inserir(Tipo As clDespesaTipo) As Object
        Dim SQL As New SQLControl
        '
        Dim mySQL As String = String.Format("INSERT INTO tblDespesaTipo (DespesaTipo, Periodicidade, Variacao) " &
                                            "VALUES ('{0}', {1}, {2})",
                                            Tipo.DespesaTipo,
                                            Tipo.Periodicidade,
                                            Tipo.Variacao)
        SQL.ExecQuery(mySQL, True)
        '
        If SQL.HasException Then
            Throw New Exception(SQL.Exception)
        Else
            Dim newID As Integer = SQL.DBDT.Rows(0).Item(0)
            Return newID
        End If
        '
    End Function
    '
    '===================================================================================================
    ' ALTERAR TIPO DE DESPESA
    '===================================================================================================
    Public Function DespesaTipo_Alterar(Tipo As clDespesaTipo) As Boolean
        '
        Dim SQL As New SQLControl
        '
        Dim mySQL As String = String.Format("UPDATE tblDespesaTipo SET " &
                                            "DespesaTipo = '{0}', Periodicidade = {1}, Variacao = {2} " &
                                            "WHERE IDDespesaTipo = {3}",
                                            Tipo.DespesaTipo,
                                            Tipo.Periodicidade,
                                            Tipo.Variacao,
                                            Tipo.IDDespesaTipo)
        SQL.ExecQuery(mySQL)
        '
        If SQL.HasException Then
            Throw New Exception(SQL.Exception)
        End If
        '
        Return True
        '
    End Function
End Class
'
Public Class DespesaPeriodicaBLL
    '
    '===================================================================================================
    ' INSERIR NOVA DESPESA PERIODICA
    '===================================================================================================
    Public Function DespesaPeriodica_Inserir(myDespesa As clDespesaPeriodica) As Integer
        Dim db As New AcessoDados
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDCredor", myDespesa.IDCredor)
        db.AdicionarParametros("@IDDespesaTipo", myDespesa.IDDespesaTipo)
        db.AdicionarParametros("@IDFilial", myDespesa.IDFilial)
        db.AdicionarParametros("@IniciarData", myDespesa.IniciarData)
        db.AdicionarParametros("@DespesaValor", myDespesa.DespesaValor)
        db.AdicionarParametros("@Descricao", myDespesa.Descricao)
        db.AdicionarParametros("@Periodicidade", myDespesa.Periodicidade)
        db.AdicionarParametros("@DiaVencimento", myDespesa.DiaVencimento)
        db.AdicionarParametros("@MesVencimento", myDespesa.MesVencimento)
        db.AdicionarParametros("@IDCobrancaForma", myDespesa.IDCobrancaForma)
        db.AdicionarParametros("@RGBanco", myDespesa.RGBanco)
        '
        '---Inserir a despesa
        Try
            Dim newID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspDespesaPeriodica_Inserir")
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
    '===================================================================================================
    ' ALTERAR DESPESA PERIODICA
    '===================================================================================================
    Public Function DespesaPeriodica_Alterar(myDespesa As clDespesaPeriodica) As Integer
        Dim db As New AcessoDados
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDDespesaPeriodica", myDespesa.IDDespesaPeriodica)
        db.AdicionarParametros("@IDCredor", myDespesa.IDCredor)
        db.AdicionarParametros("@IDDespesaTipo", myDespesa.IDDespesaTipo)
        db.AdicionarParametros("@IDFilial", myDespesa.IDFilial)
        db.AdicionarParametros("@IniciarData", myDespesa.IniciarData)
        db.AdicionarParametros("@DespesaValor", myDespesa.DespesaValor)
        db.AdicionarParametros("@Descricao", myDespesa.Descricao)
        db.AdicionarParametros("@Periodicidade", myDespesa.Periodicidade)
        db.AdicionarParametros("@DiaVencimento", myDespesa.DiaVencimento)
        db.AdicionarParametros("@MesVencimento", myDespesa.MesVencimento)
        db.AdicionarParametros("@Ativa", myDespesa.Ativa)
        db.AdicionarParametros("@IDCobrancaForma", myDespesa.IDCobrancaForma)
        db.AdicionarParametros("@RGBanco", myDespesa.RGBanco)
        '
        '---Inserir a despesa
        Try
            Dim newID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspDespesaPeriodica_Alterar")
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
    '--------------------------------------------------------------------------------------------
    ' GET LISTA DESPESA PERIODICA PARA FORM PROCURA
    '--------------------------------------------------------------------------------------------
    Public Function GetDespesaPeriodicaLista_Procura(myIDDespesaTipo As Integer?, myIDCredor As Integer?,
                                                     myDescricao As String, Optional myPeriodicidade As Byte? = Nothing) As List(Of clDespesaPeriodica)
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDDespesaTipo", myIDDespesaTipo)
        db.AdicionarParametros("@IDCredor", myIDCredor)
        db.AdicionarParametros("@Descricao", myDescricao)
        db.AdicionarParametros("@Periodicidade", myPeriodicidade)
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspDespesaPeriodica_ProcurarLista")
            Dim dList As New List(Of clDespesaPeriodica)
            '
            For Each r In dt.Rows
                Dim d As New clDespesaPeriodica
                '
                d.IDDespesaPeriodica = IIf(IsDBNull(r("IDDespesaPeriodica")), Nothing, r("IDDespesaPeriodica"))
                d.IDCredor = IIf(IsDBNull(r("IDCredor")), Nothing, r("IDCredor"))
                d.IDDespesaTipo = IIf(IsDBNull(r("IDDespesaTipo")), Nothing, r("IDDespesaTipo"))
                d.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
                d.Descricao = IIf(IsDBNull(r("Descricao")), String.Empty, r("Descricao"))
                d.IniciarData = IIf(IsDBNull(r("IniciarData")), Nothing, r("IniciarData"))
                d.DespesaValor = IIf(IsDBNull(r("DespesaValor")), Nothing, r("DespesaValor"))
                d.Ativa = IIf(IsDBNull(r("Ativa")), Nothing, r("Ativa"))
                d.Periodicidade = IIf(IsDBNull(r("Periodicidade")), Nothing, r("Periodicidade"))
                d.DiaVencimento = IIf(IsDBNull(r("DiaVencimento")), Nothing, r("DiaVencimento"))
                d.MesVencimento = IIf(IsDBNull(r("MesVencimento")), Nothing, r("MesVencimento"))
                d.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
                d.DespesaTipo = IIf(IsDBNull(r("DespesaTipo")), String.Empty, r("DespesaTipo"))
                d.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                d.IDCobrancaForma = IIf(IsDBNull(r("IDCobrancaForma")), Nothing, r("IDCobrancaForma"))
                d.CobrancaForma = IIf(IsDBNull(r("CobrancaForma")), String.Empty, r("CobrancaForma"))
                d.RGBanco = IIf(IsDBNull(r("RGBanco")), Nothing, r("RGBanco"))
                d.BancoNome = IIf(IsDBNull(r("BancoNome")), String.Empty, r("BancoNome"))
                '
                dList.Add(d)
                '
            Next
            '
            Return dList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' ATIVAR/DESATIVAR DESPESA PERIODICA
    '===================================================================================================
    Public Function DespesaPeriodica_Ativar(myDespesa As clDespesaPeriodica, myAtivo As Boolean) As Integer
        Dim db As New AcessoDados
        '
        '--- Adicionar os paramentros
        db.LimparParametros()
        '
        db.AdicionarParametros("IDDespesaPeriodica", myDespesa.IDDespesaPeriodica)
        db.AdicionarParametros("IDCredor", myDespesa.IDCredor)
        db.AdicionarParametros("IDDespesaTipo", myDespesa.IDDespesaTipo)
        db.AdicionarParametros("IDFilial", myDespesa.IDFilial)
        db.AdicionarParametros("IniciarData", myDespesa.IniciarData)
        db.AdicionarParametros("DespesaValor", myDespesa.DespesaValor)
        db.AdicionarParametros("Descricao", myDespesa.Descricao)
        db.AdicionarParametros("Periodicidade", myDespesa.Periodicidade)
        db.AdicionarParametros("DiaVencimento", myDespesa.DiaVencimento)
        db.AdicionarParametros("MesVencimento", myDespesa.MesVencimento)
        db.AdicionarParametros("Ativa", myAtivo)
        db.AdicionarParametros("IDCobrancaForma", myDespesa.IDCobrancaForma)
        db.AdicionarParametros("RGBanco", myDespesa.RGBanco)
        '
        '---Inserir a despesa
        Try
            Dim newID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspDespesaPeriodica_Alterar")
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
    '===================================================================================================
    ' TORNA REAL UMA DESPESA PERIODICA
    '===================================================================================================
    Public Function DespesaPeriodica_TornarReal(myAPagar As clAPagar,
                                                Optional dbTran As Object = Nothing) As Integer
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- Verify if exists another APAGAR periodico before this
        '---------------------------------------------------------------------
        '--- GEt the DepesaPeriodica
        Try
            Dim clD As clDespesaPeriodica = GetDespesaPeriodica_PorID(myAPagar.IDOrigem)
            Dim PrimeiroVencimento As Date = clD.IniciarData
            '
            '--- GET PrimeiroVencimento (primeira Data de Vencimento a partir do IniciarData)
            Select Case clD.Periodicidade
                Case 1 '--- SEMANAL
                    '
                    Do While Not PrimeiroVencimento.DayOfWeek = clD.DiaVencimento
                        PrimeiroVencimento = PrimeiroVencimento.AddDays(1)
                    Loop
                    '
                Case 2 '--- MENSAL
                    '
                    '--- Define a mes do primeiro vencimento
                    If Day(PrimeiroVencimento) <= clD.DiaVencimento Then
                        PrimeiroVencimento = DateSerial(Year(PrimeiroVencimento), Month(PrimeiroVencimento), clD.DiaVencimento)
                    Else
                        PrimeiroVencimento = DateSerial(Year(PrimeiroVencimento), Month(PrimeiroVencimento) + 1, clD.DiaVencimento)
                    End If
                    '
                Case 3 '--- ANUAL
                    '
                    '--- Define o ano do primeiro vencimento
                    If Month(PrimeiroVencimento) <= clD.MesVencimento Then
                        PrimeiroVencimento = DateSerial(Year(PrimeiroVencimento), clD.MesVencimento, clD.DiaVencimento)
                    Else
                        PrimeiroVencimento = DateSerial(Year(PrimeiroVencimento) + 1, clD.MesVencimento, clD.DiaVencimento)
                    End If
                    '
                Case Else
                    '
            End Select
            '
            If myAPagar.Vencimento > PrimeiroVencimento Then
                Throw New Exception("Existem vencimentos anteriores que ainda não foram pagos nessa mesma despesa periódica:" &
                                    vbNewLine & vbNewLine &
                                    clD.Descricao.ToUpper)
            End If
            '
        Catch ex As Exception
            Throw ex
            Exit Function
        End Try
        '
        '--- EXECUTA A PROCEDURE DE TORNAR REAL
        '----------------------------------------------------------------------------------
        db.LimparParametros()
        '
        db.AdicionarParametros("@Origem", 3)
        db.AdicionarParametros("@IDOrigem", myAPagar.IDOrigem)
        db.AdicionarParametros("@IDPessoa", myAPagar.IDPessoa)
        db.AdicionarParametros("@IDFilial", myAPagar.IDFilial)
        db.AdicionarParametros("@IDCobrancaForma", myAPagar.IDCobrancaForma)
        db.AdicionarParametros("@Identificador", myAPagar.Identificador)
        db.AdicionarParametros("@RGBanco", myAPagar.RGBanco)
        db.AdicionarParametros("@Vencimento", myAPagar.Vencimento)
        db.AdicionarParametros("@APagarValor", myAPagar.APagarValor)
        '
        Try
            Dim newID As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspDespesaPeriodica_TornarReal")
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
    '--------------------------------------------------------------------------------------------
    ' GET DESPESAPERIODICA por IDDespesaPeriodica
    '--------------------------------------------------------------------------------------------
    Public Function GetDespesaPeriodica_PorID(myIDDespesaPeriodica As Integer) As clDespesaPeriodica
        Dim SQL As New SQLControl
        '
        Dim strSQL = "SELECT * FROM qryDespesaPeriodica WHERE IDDespesaPeriodica = " & myIDDespesaPeriodica
        '
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount = 0 Then
                Throw New Exception("Não retornou nenhum registro de Despesa")
            End If
            '
            Dim r As DataRow = SQL.DBDT.Rows(0)
            Dim d As New clDespesaPeriodica
            '
            d.IDDespesaPeriodica = IIf(IsDBNull(r("IDDespesaPeriodica")), Nothing, r("IDDespesaPeriodica"))
            d.IDCredor = IIf(IsDBNull(r("IDCredor")), Nothing, r("IDCredor"))
            d.IDDespesaTipo = IIf(IsDBNull(r("IDDespesaTipo")), Nothing, r("IDDespesaTipo"))
            d.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
            d.Descricao = IIf(IsDBNull(r("Descricao")), String.Empty, r("Descricao"))
            d.IniciarData = IIf(IsDBNull(r("IniciarData")), Nothing, r("IniciarData"))
            d.DespesaValor = IIf(IsDBNull(r("DespesaValor")), Nothing, r("DespesaValor"))
            d.Ativa = IIf(IsDBNull(r("Ativa")), Nothing, r("Ativa"))
            d.Periodicidade = IIf(IsDBNull(r("Periodicidade")), Nothing, r("Periodicidade"))
            d.DiaVencimento = IIf(IsDBNull(r("DiaVencimento")), Nothing, r("DiaVencimento"))
            d.MesVencimento = IIf(IsDBNull(r("MesVencimento")), Nothing, r("MesVencimento"))
            d.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
            d.DespesaTipo = IIf(IsDBNull(r("DespesaTipo")), String.Empty, r("DespesaTipo"))
            d.Cadastro = IIf(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            d.IDCobrancaForma = IIf(IsDBNull(r("IDCobrancaForma")), Nothing, r("IDCobrancaForma"))
            d.CobrancaForma = IIf(IsDBNull(r("CobrancaForma")), String.Empty, r("CobrancaForma"))
            d.RGBanco = IIf(IsDBNull(r("RGBanco")), Nothing, r("RGBanco"))
            d.BancoNome = IIf(IsDBNull(r("BancoNome")), String.Empty, r("BancoNome"))
            '
            Return d
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
