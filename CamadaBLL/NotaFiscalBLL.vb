Imports CamadaDAL
Imports CamadaDTO
'
Public Class NotaFiscalBLL
    '
    '===================================================================================================
    ' OBTER LISTA DE NOTAS POR IDCOMPRA OU IDTRANSACAO
    '===================================================================================================
    Public Function NotaFiscal_GET_PorIDCompra(IDCompra As Integer) As List(Of clNotaFiscal)
        Dim db As New AcessoDados
        Dim dt As New DataTable
        Dim NotaList As New List(Of clNotaFiscal)
        '
        Try
            db.LimparParametros()
            db.AdicionarParametros("@IDTransacao", IDCompra)
            '
            dt = db.ExecutarConsulta(CommandType.StoredProcedure, "uspTransacaoNota_GET_PorIDTransacao")
            '
            If dt.Rows.Count = 0 Then Return NotaList
            '
            For Each r As DataRow In dt.Rows
                Dim clNota As New clNotaFiscal
                '
                With clNota
                    '--- tblTransacaoNotaFiscal
                    .IDNota = IIf(IsDBNull(r("IDNota")), Nothing, r("IDNota"))
                    .IDTransacao = IDCompra
                    .EmissaoData = IIf(IsDBNull(r("EmissaoData")), Nothing, r("EmissaoData"))
                    .NotaTipo = IIf(IsDBNull(r("NotaTipo")), Nothing, r("NotaTipo"))
                    .NotaSerie = IIf(IsDBNull(r("NotaSerie")), Nothing, r("NotaSerie"))
                    .NotaNumero = IIf(IsDBNull(r("NotaNumero")), Nothing, r("NotaNumero"))
                    .NotaValor = IIf(IsDBNull(r("NotaValor")), 0, r("NotaValor"))
                    .ChaveAcesso = IIf(IsDBNull(r("ChaveAcesso")), "", r("ChaveAcesso"))
                End With
                '
                NotaList.Add(clNota)
                '
            Next
            '
            Return NotaList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' SALVAR NOTA FISCAL DA TRANSACAO
    '===================================================================================================
    Public Function InserirNova_Nota(_Nota As clNotaFiscal,
                                     Optional dbTran As Object = Nothing) As Integer
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            With _Nota
                db.AdicionarParametros("@IDTransacao", .IDTransacao)
                db.AdicionarParametros("@EmissaoData", .EmissaoData)
                db.AdicionarParametros("@NotaTipo", .NotaTipo)
                db.AdicionarParametros("@NotaSerie", .NotaSerie)
                db.AdicionarParametros("@NotaNumero", .NotaNumero)
                db.AdicionarParametros("@NotaValor", .NotaValor)
                db.AdicionarParametros("@ChaveAcesso", .ChaveAcesso)
            End With
            '
            Dim query As String = "INSERT INTO tblTransacaoNotaFiscal " &
                  "(IDTransacao, NotaTipo, NotaSerie, NotaNumero, NotaValor, EmissaoData, ChaveAcesso) " &
                  "VALUES " &
                  "(@IDTransacao, @NotaTipo, @NotaSerie, @NotaNumero, @NotaValor, @EmissaoData, @ChaveAcesso)"
            '
            obj = db.ExecutarInsertGetID(query)
            '
            If IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' EDITAR/ALTERAR NOTA FISCAL DA TRANSACAO
    '===================================================================================================
    Public Function Editar_Nota(_Nota As clNotaFiscal) As Integer
        Dim db As New AcessoDados
        Dim obj As Object = Nothing
        '
        Try
            db.LimparParametros()
            '
            With _Nota
                db.AdicionarParametros("@IDNota", .IDNota)
                db.AdicionarParametros("@IDTransacao", .IDTransacao)
                db.AdicionarParametros("@EmissaoData", .EmissaoData)
                db.AdicionarParametros("@NotaTipo", .NotaTipo)
                db.AdicionarParametros("@NotaSerie", .NotaSerie)
                db.AdicionarParametros("@NotaNumero", .NotaNumero)
                db.AdicionarParametros("@NotaValor", .NotaValor)
                db.AdicionarParametros("@ChaveAcesso", .ChaveAcesso)
            End With
            '
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTransacaoNota_Alterar")
            '
            If IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' EXCLUIR NOTA FISCAL DE UMA TRANSACAO PELO IDTRANSACAO, OU UMA NOTA PELO IDNOTA
    '===================================================================================================
    Public Function Excluir_Nota_Transacao(Optional IDTransacao As Integer? = Nothing, Optional IDNota As Integer? = Nothing) As Boolean
        Dim db As New AcessoDados
        '
        '--- Limpa os paramentros
        db.LimparParametros()
        '
        '----------------------------------------------------------------------------------------------------
        '--- Se o IDTransacao for NULO então exclui pelo IDNota apenas uma nota
        '--- Se o IDNota for NULO então exclui pelo IDTransacaa todas as nota da transacao informada
        '----------------------------------------------------------------------------------------------------
        If Not IsNothing(IDTransacao) Then
            '--- Adiciona os paramentros
            db.AdicionarParametros("@IDTransacao", IDTransacao)
        ElseIf Not IsNothing(IDNota) Then
            '--- Adiciona os paramentros
            db.AdicionarParametros("@IDNota", IDNota)
        End If
        '
        Try
            Dim obj As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTransacaoNota_Excluir")
            Return CBool(obj)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
