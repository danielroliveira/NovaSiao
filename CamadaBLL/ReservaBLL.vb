Imports CamadaDAL
Imports CamadaDTO

Public Class ReservaBLL
    '
    '===================================================================================================
    ' OBTER LISTA COMPLETA DE RESERVA PELA SITUACAO
    '===================================================================================================
    Public Function Reserva_GET_List(_IDFilial As Integer,
                                     Optional _IDSituacaoReserva As Byte? = Nothing,
                                     Optional _ReservaAtiva As Boolean? = Nothing) As List(Of clReserva)
        Dim bd As New AcessoDados
        Dim lst As New List(Of clReserva)
        '
        bd.LimparParametros()
        '
        bd.AdicionarParametros("@IDFilial", _IDFilial)
        '
        If Not IsNothing(_IDSituacaoReserva) Then
            bd.AdicionarParametros("@IDSituacaoReserva", _IDSituacaoReserva)
        End If
        '
        If Not IsNothing(_ReservaAtiva) Then
            bd.AdicionarParametros("@ReservaAtiva", _ReservaAtiva)
        End If
        '        
        Try
            Dim dt As DataTable = bd.ExecutarConsulta(CommandType.StoredProcedure, "uspReserva_GET")
            '
            For Each r As DataRow In dt.Rows
                Dim res As New clReserva
                '
                res.IDReserva = IIf(IsDBNull(r("IDReserva")), Nothing, r("IDReserva"))
                res.ReservaData = IIf(IsDBNull(r("ReservaData")), Nothing, r("ReservaData"))
                res.IDFuncionario = IIf(IsDBNull(r("IDFuncionario")), Nothing, r("IDFuncionario"))
                res.ApelidoFuncionario = IIf(IsDBNull(r("ApelidoFuncionario")), String.Empty, r("ApelidoFuncionario"))
                res.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
                res.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
                res.ClienteNome = IIf(IsDBNull(r("ClienteNome")), String.Empty, r("ClienteNome"))
                res.TelefoneA = IIf(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
                res.TelefoneB = IIf(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
                res.TemWathsapp = IIf(IsDBNull(r("TemWathsapp")), Nothing, r("TemWathsapp"))
                res.ClienteEmail = IIf(IsDBNull(r("ClienteEmail")), String.Empty, r("ClienteEmail"))
                res.ProdutoConhecido = IIf(IsDBNull(r("ProdutoConhecido")), Nothing, r("ProdutoConhecido"))
                res.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
                res.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
                res.PVenda = IIf(IsDBNull(r("PVenda")), Nothing, r("PVenda"))
                res.Autor = IIf(IsDBNull(r("Autor")), String.Empty, r("Autor"))
                res.IDFornecedor = IIf(IsDBNull(r("IDFornecedor")), Nothing, r("IDFornecedor"))
                res.Fornecedor = IIf(IsDBNull(r("Fornecedor")), String.Empty, r("Fornecedor"))
                res.IDFabricante = IIf(IsDBNull(r("IDFabricante")), Nothing, r("IDFabricante"))
                res.Fabricante = IIf(IsDBNull(r("Fabricante")), String.Empty, r("Fabricante"))
                res.IDProdutoTipo = IIf(IsDBNull(r("IDProdutoTipo")), Nothing, r("IDProdutoTipo"))
                res.ProdutoTipo = IIf(IsDBNull(r("ProdutoTipo")), String.Empty, r("ProdutoTipo"))
                res.IDSituacaoReserva = IIf(IsDBNull(r("IDSituacaoReserva")), Nothing, r("IDSituacaoReserva"))
                res.SituacaoReserva = IIf(IsDBNull(r("SituacaoReserva")), String.Empty, r("SituacaoReserva"))
                res.ConclusaoData = IIf(IsDBNull(r("ConclusaoData")), Nothing, r("ConclusaoData"))
                res.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
                res.ReservaAtiva = IIf(IsDBNull(r("ReservaAtiva")), Nothing, r("ReservaAtiva"))
                '
                lst.Add(res)
                '
            Next
            '
            Return lst
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' INSERIR NOVO
    '===================================================================================================
    Public Function Reserva_Inserir(myReserva As clReserva) As Object
        Dim bd As New AcessoDados
        '
        bd.LimparParametros()
        '
        '--- ADICIONA OS PARAMENTROS NECESSARIOS
        bd.AdicionarParametros("@ReservaData", myReserva.ReservaData)
        bd.AdicionarParametros("@IDFuncionario", myReserva.IDFuncionario)
        bd.AdicionarParametros("@IDFilial", myReserva.IDFilial)
        bd.AdicionarParametros("@ClienteNome", myReserva.ClienteNome)
        bd.AdicionarParametros("@TelefoneA", myReserva.TelefoneA)
        bd.AdicionarParametros("@TelefoneB", myReserva.TelefoneB)
        bd.AdicionarParametros("@TemWathsapp", myReserva.TemWathsapp)
        bd.AdicionarParametros("@ClienteEmail", myReserva.ClienteEmail)
        bd.AdicionarParametros("@ProdutoConhecido", myReserva.ProdutoConhecido)
        bd.AdicionarParametros("@RGProduto", myReserva.RGProduto)
        bd.AdicionarParametros("@Produto", myReserva.Produto)
        bd.AdicionarParametros("@Autor", myReserva.Autor)
        bd.AdicionarParametros("@IDFornecedor", myReserva.IDFornecedor)
        bd.AdicionarParametros("@IDFabricante", myReserva.IDFabricante)
        bd.AdicionarParametros("@IDProdutoTipo", myReserva.IDProdutoTipo)
        bd.AdicionarParametros("@Observacao", myReserva.Observacao)
        '
        Try
            Dim myID As Object = bd.ExecutarManipulacao(CommandType.StoredProcedure, "uspReserva_Inserir")
            '
            If IsNumeric(myID) Then
                Return myID
            Else
                Throw New Exception(myID.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' ALTERAR REGISTRO
    '===================================================================================================
    Public Function Reserva_Alterar(myReserva As clReserva) As Object
        Dim bd As New AcessoDados
        '
        bd.LimparParametros()
        '
        '--- ADICIONA OS PARAMENTROS NECESSARIOS
        bd.AdicionarParametros("@IDReserva", myReserva.IDReserva)
        bd.AdicionarParametros("@ReservaData", myReserva.ReservaData)
        bd.AdicionarParametros("@IDFuncionario", myReserva.IDFuncionario)
        bd.AdicionarParametros("@IDFilial", myReserva.IDFilial)
        bd.AdicionarParametros("@ClienteNome", myReserva.ClienteNome)
        bd.AdicionarParametros("@TelefoneA", myReserva.TelefoneA)
        bd.AdicionarParametros("@TelefoneB", myReserva.TelefoneB)
        bd.AdicionarParametros("@TemWathsapp", myReserva.TemWathsapp)
        bd.AdicionarParametros("@ClienteEmail", myReserva.ClienteEmail)
        bd.AdicionarParametros("@ProdutoConhecido", myReserva.ProdutoConhecido)
        bd.AdicionarParametros("@RGProduto", myReserva.RGProduto)
        bd.AdicionarParametros("@Produto", myReserva.Produto)
        bd.AdicionarParametros("@Autor", myReserva.Autor)
        bd.AdicionarParametros("@IDFornecedor", myReserva.IDFornecedor)
        bd.AdicionarParametros("@IDFabricante", myReserva.IDFabricante)
        bd.AdicionarParametros("@IDProdutoTipo", myReserva.IDProdutoTipo)
        bd.AdicionarParametros("@IDSituacaoReserva", myReserva.IDSituacaoReserva)
        bd.AdicionarParametros("@ConclusaoData", myReserva.ConclusaoData)
        bd.AdicionarParametros("@Observacao", myReserva.Observacao)
        '
        Try
            Dim myID As Object = bd.ExecutarManipulacao(CommandType.StoredProcedure, "uspReserva_Alterar")
            '
            If IsNumeric(myID) Then
                Return myID
            Else
                Throw New Exception(myID.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' ALTERA A SITUCAO DA RESERVA
    '===================================================================================================
    Public Function Reserva_AlteraSituacao(IDReserva As Integer, IDSituacao As Byte) As Boolean
        Dim SQL As New SQLControl
        Dim mySQL As String = String.Format("UPDATE tblReserva SET IDSituacaoReserva = '{0}' WHERE IDReserva = {1}", IDSituacao, IDReserva)
        '
        Try
            SQL.ExecQuery(mySQL)

            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' GET RESERVA SITUACAO
    '===================================================================================================
    Public Function ReservaSituacao_GET_DT(Optional _ReservaAtiva As Boolean? = Nothing) As DataTable
        Dim SQL As New SQLControl
        Dim str As String = ""
        '
        If IsNothing(_ReservaAtiva) Then
            str = "SELECT * FROM tblReservaSituacao"
        Else
            str = "SELECT * FROM tblReservaSituacao WHERE ReservaAtiva = '" & _ReservaAtiva.ToString & "'"
        End If
        '
        Try
            SQL.ExecQuery(str)
            '
            Using dt As DataTable = SQL.DBDT
                Return dt
            End Using
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' GET PRODUTO DADOS PELO RGPRODUTO
    '===================================================================================================
    Public Function ProdutoGet_PeloRG(_RGProduto As Integer, _IDFilial As Integer) As DataTable
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        db.AdicionarParametros("@RGProduto", _RGProduto)
        db.AdicionarParametros("@IDFilial", _IDFilial)
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspReserva_Produto_GET")
            '
            Return dt
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
