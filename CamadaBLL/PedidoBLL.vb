Imports CamadaDAL
Imports CamadaDTO
'
Public Class PedidoBLL
    '
#Region "PEDIDO GERAL"
    '
    '===================================================================================================
    ' OBTER LISTA COMPLETA DE PEDIDO PELA SITUACAO, MES E ANO
    '===================================================================================================
    Public Function Pedido_GET_List(Situacao As Byte,
                                    IDFilial As Integer,
                                    Optional Ano As Integer? = Nothing,
                                    Optional Mes As Integer? = Nothing) As List(Of clPedido)
        '
        Dim bd As New AcessoDados
        Dim lst As New List(Of clPedido)
        '
        bd.LimparParametros()
        bd.AdicionarParametros("@Situacao", Situacao)
        bd.AdicionarParametros("@IDFilial", IDFilial)
        '
        '--- CREATE SQL QUERY
        Dim query As String = "SELECT * FROM qryPedidos WHERE Situacao = @Situacao AND IDFilial = @IDFilial "
        '
        If Not IsNothing(Ano) Then
            bd.AdicionarParametros("@Ano", Ano)
            query += "AND YEAR(InicioData) = @Ano "
        End If
        '
        If Not IsNothing(Mes) Then
            bd.AdicionarParametros("@Mes", Mes)
            query += "AND MONTH(InicioData) = @Mes"
        End If
        '        
        Try
            Dim dt As DataTable = bd.ExecutarConsulta(CommandType.Text, query)
            '
            For Each r As DataRow In dt.Rows
                '
                lst.Add(ConvertRowInPedido(r))
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
    '==========================================================================================
    ' CONVERT ROW IN CLPEDIDO
    '==========================================================================================
    Private Function ConvertRowInPedido(r As DataRow) As clPedido
        '
        Dim ped As New clPedido
        '
        ped.IDPedido = IIf(IsDBNull(r("IDPedido")), Nothing, r("IDPedido"))
        ped.IDFilial = IIf(IsDBNull(r("IDFilial")), Nothing, r("IDFilial"))
        ped.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
        ped.IDFornecedor = IIf(IsDBNull(r("IDFornecedor")), Nothing, r("IDFornecedor"))
        ped.Fornecedor = IIf(IsDBNull(r("Fornecedor")), String.Empty, r("Fornecedor"))
        ped.VendedorNome = IIf(IsDBNull(r("VendedorNome")), String.Empty, r("VendedorNome"))
        ped.EmailVendas = IIf(IsDBNull(r("EmailVendas")), String.Empty, r("EmailVendas"))
        ped.TelefoneContato = IIf(IsDBNull(r("TelefoneContato")), String.Empty, r("TelefoneContato"))
        ped.IDTransportadora = IIf(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora"))
        ped.Transportadora = IIf(IsDBNull(r("Transportadora")), String.Empty, r("Transportadora"))
        ped.TelefoneATransportadora = IIf(IsDBNull(r("TelefoneATransportadora")), String.Empty, r("TelefoneATransportadora"))
        ped.Situacao = IIf(IsDBNull(r("Situacao")), Nothing, r("Situacao"))
        ped.SituacaoDescricao = IIf(IsDBNull(r("SituacaoDescricao")), String.Empty, r("SituacaoDescricao"))
        ped.InicioData = IIf(IsDBNull(r("InicioData")), Nothing, r("InicioData"))
        ped.RevisaoData = IIf(IsDBNull(r("RevisaoData")), Nothing, r("RevisaoData"))
        ped.EnvioData = IIf(IsDBNull(r("EnvioData")), Nothing, r("EnvioData"))
        ped.ChegadaData = IIf(IsDBNull(r("ChegadaData")), Nothing, r("ChegadaData"))
        ped.Observacao = IIf(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        ped.TotalPedido = IIf(IsDBNull(r("TotalPedido")), Nothing, r("TotalPedido"))
        ped.TotalRecebido = IIf(IsDBNull(r("TotalRecebido")), Nothing, r("TotalRecebido"))
        ped.IDMigracao = IIf(IsDBNull(r("IDMigracao")), Nothing, r("IDMigracao"))
        '
        Return ped
        '
    End Function
    '
    '===================================================================================================
    ' INSERIR NOVO PEDIDO
    '===================================================================================================
    Public Function Pedido_Inserir(myPedido As clPedido) As Object
        Dim bd As New AcessoDados
        '
        bd.LimparParametros()
        '
        '--- ADICIONA OS PARAMENTROS NECESSARIOS
        'bd.AdicionarParametros("@IDPedido", myPedido.IDPedido)
        bd.AdicionarParametros("@IDFilial", myPedido.IDFilial)
        bd.AdicionarParametros("@IDFornecedor", myPedido.IDFornecedor)
        bd.AdicionarParametros("@Fornecedor", myPedido.Fornecedor)
        bd.AdicionarParametros("@VendedorNome", myPedido.VendedorNome)
        bd.AdicionarParametros("@EmailVendas", myPedido.EmailVendas)
        bd.AdicionarParametros("@TelefoneContato", myPedido.TelefoneContato)
        bd.AdicionarParametros("@IDTransportadora", myPedido.IDTransportadora)
        'bd.AdicionarParametros("@Situacao", myPedido.Situacao)
        bd.AdicionarParametros("@InicioData", myPedido.InicioData)
        bd.AdicionarParametros("@Observacao", myPedido.Observacao)
        '
        Try
            Dim myID As Object = bd.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedido_Inserir")
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
    ' ALTERAR REGISTRO DE PEDIDO
    '===================================================================================================
    Public Function Pedido_Alterar(myPedido As clPedido) As Object
        Dim bd As New AcessoDados
        '
        bd.LimparParametros()
        '
        '--- ADICIONA OS PARAMENTROS NECESSARIOS
        bd.AdicionarParametros("@IDPedido", myPedido.IDPedido)
        bd.AdicionarParametros("@IDFilial", myPedido.IDFilial)
        bd.AdicionarParametros("@IDFornecedor", myPedido.IDFornecedor)
        bd.AdicionarParametros("@Fornecedor", myPedido.Fornecedor)
        bd.AdicionarParametros("@VendedorNome", myPedido.VendedorNome)
        bd.AdicionarParametros("@EmailVendas", myPedido.EmailVendas)
        bd.AdicionarParametros("@TelefoneContato", myPedido.TelefoneContato)
        bd.AdicionarParametros("@IDTransportadora", myPedido.IDTransportadora)
        bd.AdicionarParametros("@Situacao", myPedido.Situacao)
        bd.AdicionarParametros("@InicioData", myPedido.InicioData)
        bd.AdicionarParametros("@RevisaoData", myPedido.RevisaoData)
        bd.AdicionarParametros("@EnvioData", myPedido.EnvioData)
        bd.AdicionarParametros("@ChegadaData", myPedido.ChegadaData)
        bd.AdicionarParametros("@Observacao", myPedido.Observacao)
        bd.AdicionarParametros("@TotalPedido", myPedido.TotalPedido)
        bd.AdicionarParametros("@TotalRecebido", myPedido.TotalRecebido)
        bd.AdicionarParametros("@IDMigracao", myPedido.IDMigracao)
        '
        Try
            Dim myID As Object = bd.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedido_Alterar")
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
    ' EXCLUIR PEDIDO
    '===================================================================================================
    Public Function Pedido_Excluir(IDPedido As Integer) As Boolean
        '
        '--- CHECK MIGRACAO OF PEDIDO
        '-----------------------------------------------------------------------
        If CountPedidosMigrados(IDPedido) > 0 Then
            Throw New AppException("Esse pedido não pode ser excluído porque tem outros pedidos migrados a ele." & vbCrLf &
                                   "Remova todas as migrações associadas antes de tentar excluir novamente.")

            Return False
        End If
        '
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        Dim query As String = ""
        '
        Try
            '
            '--- CHECK IF EXISTS RESERVAS ASSOCIATED WITH ITEMS
            '-----------------------------------------------------------------------
            db.LimparParametros()
            db.AdicionarParametros("@IDPedido", IDPedido)
            '
            '--- altera a reserva para aguardando pedido
            query = "UPDATE tblReserva SET IDPedidos = NULL, IDSituacaoReserva = 1 " +
                    "WHERE IDSituacaoReserva = 2 " +
                    "AND IDReserva = (" +
                    "SELECT IDOrigem FROM tblPedidoItens WHERE IDPedido = @IDPedido AND Origem = 1)"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            '--- DELETE ALL ITEMS OF PEDIDO
            '-----------------------------------------------------------------------
            db.LimparParametros()
            db.AdicionarParametros("@IDPedido", IDPedido)
            '
            query = "DELETE tblPedidoItens WHERE IDPedido = @IDPedido"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            '--- DELETE ALL MENSAGES OF PEDIDO
            '-----------------------------------------------------------------------
            db.LimparParametros()
            db.AdicionarParametros("@IDPedido", IDPedido)
            '
            query = "DELETE tblPedidoMensagens WHERE IDPedido = @IDPedido"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            '--- DELETE OBSERVACAO OF PEDIDO
            '-----------------------------------------------------------------------
            Dim oBLL As New ObservacaoBLL
            oBLL.DeleteObservacao(7, IDPedido, db)
            '
            '--- DELETE PEDIDO
            '-----------------------------------------------------------------------
            db.LimparParametros()
            db.AdicionarParametros("@IDPedido", IDPedido)
            '
            query = "DELETE tblPedido WHERE IDPedido = @IDPedido"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            db.CommitTransaction()
            Return True
            '
        Catch ex As Exception
            db.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' ALTERA A SITUCAO E AS DATAS DE CONTROLE DO PEDIDO
    '===================================================================================================
    Public Function Pedido_AlteraSituacao(IDPedido As Integer,
                                          NewSituacao As Byte,
                                          AlteracaoData As Date) As Boolean
        '
        Dim db As New AcessoDados
        Dim mySQL As String = ""
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDPedido", IDPedido)
        db.AdicionarParametros("@Situacao", NewSituacao)
        db.AdicionarParametros("@AlteracaoData", AlteracaoData)
        '
        Select Case NewSituacao
            '
            Case 0 '--- COMPONDO
                mySQL = "UPDATE tblPedido SET Situacao = @Situacao, InicioData = @AlteracaoData, " &
                        "EnvioData = NULL, RevisaoData = NULL, " &
                        "ChegadaData = NULL WHERE IDPedido = @IDPedido"

            Case 1 '--- ENVIADO
                mySQL = "UPDATE tblPedido SET Situacao = @Situacao, " &
                        "EnvioData = @AlteracaoData, " &
                        "ChegadaData = NULL WHERE IDPedido = @IDPedido"

            Case 2 '--- RECEBIDO
                mySQL = "UPDATE tblPedido SET Situacao = @Situacao, " &
                        "ChegadaData = @AlteracaoData WHERE IDPedido = {1}"

            Case 3 '--- CANCELADO
                '
                '--- check if Pedido has a migration
                If CountPedidosMigrados(IDPedido) > 0 Then
                    Throw New AppException("Esse pedido não pode ser cancelado pois existem outros pedidos migrados nele...")
                    Return False
                End If
                '
                mySQL = "UPDATE tblPedido SET Situacao = @Situacao, " &
                        "EnvioData = NULL, RevisaoData = @AlteracaoData, " &
                        "ChegadaData = NULL WHERE IDPedido = @IDPedido"
        End Select
        '
        '--- executa a alteracao no DB
        Try
            db.ExecutarManipulacao(CommandType.Text, mySQL)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' ALTERA A DATA DE REVISAO DO PEDIDO
    '===================================================================================================
    Public Function Pedido_AlteraDataRevisao(IDPedido As Integer,
                                             AlteracaoData As Date) As Boolean
        Dim SQL As New SQLControl
        Dim mySQL As String = String.Format("UPDATE tblPedido SET RevisaoData = '{0}' WHERE IDPedido = {1}",
                                            AlteracaoData.ToShortDateString, IDPedido)
        '
        '--- executa a alteracao no DB
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
    '==========================================================================================
    ' GET ANO INICIAL DA TBLPEDIDOS
    '==========================================================================================
    Public Function Pedido_Get_AnoInicial() As Integer?
        Dim bd As New AcessoDados
        '
        Dim mySQL As String = "SELECT TOP 1 YEAR(InicioData) AS ANO FROM tblPedido GROUP BY InicioData ORDER BY ANO"
        '
        Try
            Using DT As DataTable = bd.ExecutarConsulta(CommandType.Text, mySQL)
                If DT.Rows.Count > 0 Then
                    Dim myAno As Integer = DT.Rows(0)("ANO")
                    Return myAno
                Else
                    Return Nothing
                End If
            End Using
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
#End Region '/ PEDIDO GERAL
    '
#Region "ITEMS DO PEDIDO"
    '
    '==========================================================================================
    ' RETORNA UMA LISTA DE ITEMS DO PEDIDO FILTRADO PELO IDPEDIDO
    '==========================================================================================
    Public Function GetPedidoItens_IDPedido_List(myIDPedido As Integer, myFilial As Integer) As List(Of clPedidoItem)
        Dim objdb As New AcessoDados
        '
        '--- limpar os parâmetros
        objdb.LimparParametros()
        '--- adicionar os parâmetros
        objdb.AdicionarParametros("@IDPedido", myIDPedido)
        objdb.AdicionarParametros("@IDFilial", myFilial)
        '
        Dim query As String = "SELECT I.IDPedidoItem , I.IDPedido , I.IDProduto " +
                              ", I.RGProduto , I.Produto , I.IDProdutoTipo , I.ProdutoTipo " +
                              ", I.Autor , I.Quantidade , I.Preco , I.Desconto " +
                              ", I.Origem , I.OrigemDescricao , I.IDOrigem , I.IDFilialOrigem " +
                              ", I.ApelidoFilial " +
                              ", E.Quantidade AS Estoque , E.EstoqueNivel , E.EstoqueIdeal " +
                              "FROM qryPedidoItens AS I " +
                              "JOIN tblEstoque AS E ON E.IDProduto = I.IDProduto AND E.IDFilial = @IDFilial " +
                              "WHERE IDPedido = @IDPedido"
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, query)
            Dim lista As New List(Of clPedidoItem)
            '
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each r As DataRow In dt.Rows
                lista.Add(ConvertRowInPedidoItem(r))
            Next
            '
            Return lista
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    '==========================================================================================
    ' CONVERT ROW IN CLASS PEDIDO ITEM
    '==========================================================================================
    Private Function ConvertRowInPedidoItem(r As DataRow) As clPedidoItem
        '
        Dim itn As New clPedidoItem
        '
        '--- Itens da tblTransacaoItens
        itn.IDPedidoItem = IIf(IsDBNull(r("IDPedidoItem")), Nothing, r("IDPedidoItem"))
        itn.IDPedido = IIf(IsDBNull(r("IDPedido")), Nothing, r("IDPedido"))
        itn.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
        itn.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
        itn.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
        itn.IDProdutoTipo = IIf(IsDBNull(r("IDProdutoTipo")), Nothing, r("IDProdutoTipo"))
        itn.ProdutoTipo = IIf(IsDBNull(r("ProdutoTipo")), String.Empty, r("ProdutoTipo"))
        itn.Autor = IIf(IsDBNull(r("Autor")), String.Empty, r("Autor"))
        itn.Quantidade = IIf(IsDBNull(r("Quantidade")), Nothing, r("Quantidade"))
        itn.Preco = IIf(IsDBNull(r("Preco")), Nothing, r("Preco"))
        itn.Desconto = IIf(IsDBNull(r("Desconto")), Nothing, r("Desconto"))
        itn.Origem = IIf(IsDBNull(r("Origem")), Nothing, r("Origem"))
        itn.OrigemDescricao = IIf(IsDBNull(r("OrigemDescricao")), String.Empty, r("OrigemDescricao"))
        itn.IDOrigem = IIf(IsDBNull(r("IDOrigem")), Nothing, r("IDOrigem"))
        itn.IDFilialOrigem = IIf(IsDBNull(r("IDFilialOrigem")), Nothing, r("IDFilialOrigem"))
        itn.ApelidoFilial = IIf(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial"))
        '
        '--- Itens do tblEstoque
        itn.Estoque = IIf(IsDBNull(r("Estoque")), Nothing, r("Estoque"))
        itn.EstoqueNivel = IIf(IsDBNull(r("EstoqueNivel")), Nothing, r("EstoqueNivel"))
        itn.EstoqueIdeal = IIf(IsDBNull(r("EstoqueIdeal")), Nothing, r("EstoqueIdeal"))
        '
        Return itn
        '
    End Function
    '
    '==========================================================================================
    ' INSERE UM NOVO ITEM DE PEDIDO NO PEDIDO
    '==========================================================================================
    Public Function PedidoItem_Inserir(myItem As clPedidoItem) As Object
        '
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        Try
            '
            '--- CHECK IF PEDIDO ORIGINATES FROM RESERVA
            If myItem.Origem = 1 Then
                '
                Dim rBLL As New ReservaBLL
                rBLL.ResolveReservaWithPedido(myItem.IDOrigem, myItem.IDPedido, db)
                '
            End If
            '
            db.LimparParametros()
            '
            '--- ADICIONA OS PARAMENTROS NECESSARIOS
            db.AdicionarParametros("@IDPedido", myItem.IDPedido)
            db.AdicionarParametros("@IDProduto", myItem.IDProduto)
            db.AdicionarParametros("@Produto", myItem.Produto)
            db.AdicionarParametros("@IDProdutoTipo", myItem.IDProdutoTipo)
            db.AdicionarParametros("@Autor", myItem.Autor)
            db.AdicionarParametros("@Preco", myItem.Preco)
            db.AdicionarParametros("@Quantidade", myItem.Quantidade)
            db.AdicionarParametros("@Desconto", myItem.Desconto)
            db.AdicionarParametros("@Origem", myItem.Origem)
            db.AdicionarParametros("@IDOrigem", If(myItem.IDOrigem, DBNull.Value))
            db.AdicionarParametros("@IDFilialOrigem", myItem.IDFilialOrigem)
            '
            Dim query As String = "INSERT INTO tblPedidoItens " +
                                  "(IDPedido ,IDProduto ,Produto ,IDProdutoTipo ,Autor " +
                                  ",Quantidade ,Preco ,Desconto ,Origem ,IDOrigem,IDFilialOrigem) " +
                                  "VALUES " +
                                  "(@IDPedido ,@IDProduto ,@Produto ,@IDProdutoTipo ,@Autor " +
                                  ",@Quantidade ,@Preco ,@Desconto ,@Origem ,@IDOrigem ,@IDFilialOrigem);"
            '
            Dim myID As Integer = db.ExecutarInsertGetID(query)
            '
            db.CommitTransaction()
            Return myID
            '
        Catch ex As Exception
            db.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' ALTERA UM ITEM DE PEDIDO NO PEDIDO
    '==========================================================================================
    Public Function PedidoItem_Alterar(myItem As clPedidoItem) As Object
        Dim bd As New AcessoDados
        '
        bd.LimparParametros()
        '
        '--- ADICIONA OS PARAMENTROS NECESSARIOS
        bd.AdicionarParametros("@IDPedidoItem", myItem.IDPedidoItem)
        bd.AdicionarParametros("@IDPedido", myItem.IDPedido)
        bd.AdicionarParametros("@IDProduto", myItem.IDProduto)
        bd.AdicionarParametros("@Produto", myItem.Produto)
        bd.AdicionarParametros("@IDProdutoTipo", myItem.IDProdutoTipo)
        bd.AdicionarParametros("@Autor", myItem.Autor)
        bd.AdicionarParametros("@Quantidade", myItem.Quantidade)
        bd.AdicionarParametros("@Preco", myItem.Preco)
        bd.AdicionarParametros("@Desconto", myItem.Desconto)
        bd.AdicionarParametros("@Origem", myItem.Origem)
        bd.AdicionarParametros("@IDOrigem", If(myItem.IDOrigem, DBNull.Value))
        bd.AdicionarParametros("@IDFilialOrigem", myItem.IDFilialOrigem)
        '
        Dim query As String = "UPDATE tblPedidoItens SET " +
                              "IDPedido = @IDPedido " +
                              ",IDProduto = @IDProduto " +
                              ",Produto = @Produto " +
                              ",IDProdutoTipo = @IDProdutoTipo " +
                              ",Autor = @Autor " +
                              ",Quantidade = @Quantidade " +
                              ",Preco = @Preco " +
                              ",Desconto = @Desconto " +
                              ",Origem = @Origem " +
                              ",IDOrigem = @IDOrigem " +
                              ",IDFilialOrigem = @IDFilialOrigem " +
                              "WHERE IDPedidoItem = @IDPedidoItem;"
        '
        Try
            Dim myID As Object = bd.ExecutarManipulacao(CommandType.Text, query)
            '
            Return myItem.IDPedidoItem
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EXCLUI UM ITEM DE PEDIDO NO PEDIDO
    '==========================================================================================
    Public Function PedidoItem_Excluir(PedidoItem As clPedidoItem) As Boolean
        '
        Dim bd As New AcessoDados
        Dim query As String = ""
        bd.BeginTransaction()
        '
        bd.LimparParametros()
        Try
            '
            '--- check if ITEM has a RESERVA associated with it
            If PedidoItem.Origem = 1 And Not IsNothing(PedidoItem.IDOrigem) Then
                '
                bd.AdicionarParametros("@IDReserva", PedidoItem.IDOrigem)
                '
                '--- altera a reserva para aguardando pedido
                query = "UPDATE tblReserva SET IDPedido = NULL, IDSituacaoReserva = 1 " +
                        "WHERE IDReserva = @IDReserva AND IDSituacaoReserva = 2"
                '
                bd.ExecutarManipulacao(CommandType.Text, query)
                '
            End If
            '
            '--- DELETE ITEM
            bd.LimparParametros()
            bd.AdicionarParametros("@IDPedidoItem", PedidoItem.IDPedidoItem)
            '
            query = "DELETE tblPedidoItens WHERE IDPedidoItem = @IDPedidoItem"
            '
            bd.ExecutarManipulacao(CommandType.Text, query)
            '
            '--- RETURN
            bd.CommitTransaction()
            Return True
            '
        Catch ex As Exception
            bd.RollBackTransaction()
            Throw ex
        End Try
        '
    End Function
    '
#End Region '/ ITEMS DO PEDIDO
    '
#Region "MENSAGENS DO PEDIDO"
    '
    '==========================================================================================
    ' RETORNA UMA LISTA DE MENSAGEM DO PEDIDO FILTRADO PELO IDPEDIDO
    '==========================================================================================
    Public Function GetPedidoMensagens_IDPedido_List(myIDPedido As Integer) As List(Of clPedidoMensagem)
        '
        Dim objdb As New AcessoDados
        Dim sql As String = "SELECT * FROM tblPedidoMensagens WHERE IDPedido = " & myIDPedido
        '
        Try
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, sql)
            Dim lista As New List(Of clPedidoMensagem)
            '
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each r As DataRow In dt.Rows
                Dim itn As New clPedidoMensagem
                '
                '--- Itens da tblTransacaoItens
                itn.IDPedidoMensagem = IIf(IsDBNull(r("IDPedidoMensagem")), Nothing, r("IDPedidoMensagem"))
                itn.Mensagem = IIf(IsDBNull(r("Mensagem")), String.Empty, r("Mensagem"))
                itn.IDPedido = IIf(IsDBNull(r("IDPedido")), Nothing, r("IDPedido"))
                '
                lista.Add(itn)
                '
            Next
            '
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    '==========================================================================================
    ' INSERE UMA NOVA MENSAGEM DE PEDIDO NO PEDIDO
    '==========================================================================================
    Public Function PedidoMensagem_Inserir(myItem As clPedidoMensagem) As Integer
        Dim sql As New SQLControl
        '
        sql.AddParam("@IDPedido", myItem.IDPedido)
        sql.AddParam("@Mensagem", myItem.Mensagem)
        '
        Try
            sql.ExecQuery("INSERT INTO tblPedidoMensagens (Mensagem, IDPedido) VALUES (@Mensagem, @IDPedido)", True)
            '
            '--- verfica erros
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            Dim myID As Integer = sql.DBDT.Rows(0)("LastID")
            Return myID
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' ALTERA UMA MENSAGEM DE PEDIDO 
    '==========================================================================================
    Public Function PedidoMensagem_Alterar(myItem As clPedidoMensagem) As Integer
        '
        Dim sql As New SQLControl
        '
        sql.AddParam("@Mensagem", myItem.Mensagem)
        sql.AddParam("@IDPedidoMensagem", myItem.IDPedidoMensagem)
        '
        Try
            sql.ExecQuery("UPDATE tblPedidoMensagens SET Mensagem = @Mensagem WHERE IDPedidoMensagem = @IDPedidoMensagem")
            '
            '--- verfica erros
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            Dim myID As Integer = myItem.IDPedidoMensagem
            Return myID
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EXCLUI UMA MENSAGEM DE PEDIDO
    '==========================================================================================
    Public Function PedidoMensagem_Excluir(myIDPedidoMensagem As Integer) As Boolean
        Dim bd As New AcessoDados
        '
        Dim mySQL As String = "DELETE tblPedidoMensagens WHERE IDPedidoMensagem = " & myIDPedidoMensagem
        '
        Try
            bd.ExecutarManipulacao(CommandType.Text, mySQL)
            '
            Return True
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
#End Region '/ MENSAGENS DO PEDIDO
    '
#Region "VERIFICAR E ADICIONAR ITEMS AO PEDIDO"
    '
    '==========================================================================================
    ' VERIFICA E OBTEM PRODUTOS PELO ESTOQUE NIVEL POR TIPO
    '==========================================================================================
    Public Function VerificaProdutoEstoqueTipo(IDTipo As Integer, Pedido As clPedido) As List(Of clPedidoItem)
        '
        Try
            '
            If IsNothing(Pedido.IDFilial) Then
                Throw New AppException("O pedido ainda não tem Filial...")
                Return Nothing
            End If
            '
            Dim itemsList As New List(Of clPedidoItem)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDTipo", IDTipo)
            db.AdicionarParametros("@IDFilial", Pedido.IDFilial)
            '
            Dim query As String = "SELECT *, E.EstoqueIdeal, E.EstoqueNivel, E.Quantidade AS Estoque, E.IDFilial " +
                                  "FROM qryProdutos " +
                                  "LEFT JOIN tblEstoque AS E " +
                                  "ON qryProdutos.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial " +
                                  "WHERE IDProdutoTipo = @IDTipo AND " +
                                  "E.Quantidade < E.EstoqueNivel"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return itemsList
            '
            For Each r In dt.Rows
                '
                Dim item As clPedidoItem = ConvertRowInClass(r, Pedido)
                itemsList.Add(item)
                '
            Next
            '
            Return itemsList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' VERIFICA E OBTEM PRODUTOS PELO ESTOQUE NIVEL POR FABRICANTE
    '==========================================================================================
    Public Function VerificaProdutoEstoqueFabricante(IDFabricante As Integer,
                                                     Pedido As clPedido) As List(Of clPedidoItem)
        '
        Try
            '
            If IsNothing(Pedido.IDFilial) Then
                Throw New AppException("O pedido ainda não tem Filial...")
                Return Nothing
            End If
            '
            Dim itemsList As New List(Of clPedidoItem)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDFabricante", IDFabricante)
            db.AdicionarParametros("@IDFilial", Pedido.IDFilial)
            '
            Dim query As String = "SELECT *, E.EstoqueIdeal, E.EstoqueNivel, E.Quantidade AS Estoque, E.IDFilial " +
                                  "FROM qryProdutos " +
                                  "LEFT JOIN tblEstoque AS E " +
                                  "ON qryProdutos.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial " +
                                  "WHERE IDFabricante = @IDFabricante AND " +
                                  "E.Quantidade < E.EstoqueNivel"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return itemsList
            '
            For Each r In dt.Rows
                '
                Dim item As clPedidoItem = ConvertRowInClass(r, Pedido)
                itemsList.Add(item)
                '
            Next
            '
            Return itemsList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' VERIFICA E OBTEM PRODUTOS PELO ESTOQUE NIVEL POR FORNECEDOR
    '==========================================================================================
    Public Function VerificaProdutoEstoqueFornecedor(IDFornecedor As Integer,
                                                     Pedido As clPedido) As List(Of clPedidoItem)
        '
        Try
            '
            If IsNothing(Pedido.IDFilial) Then
                Throw New AppException("O pedido ainda não tem Filial...")
                Return Nothing
            End If
            '
            Dim itemsList As New List(Of clPedidoItem)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDFornecedor", IDFornecedor)
            db.AdicionarParametros("@IDFilial", Pedido.IDFilial)
            '
            Dim query As String = "SELECT *, E.EstoqueIdeal, E.EstoqueNivel, E.Quantidade AS Estoque, E.IDFilial " +
                                  "FROM qryProdutos " +
                                  "LEFT JOIN tblEstoque AS E " +
                                  "ON qryProdutos.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial " +
                                  "WHERE Quantidade < EstoqueNivel " +
                                  "AND qryProdutos.IDProduto IN (SELECT IDProduto FROM tblProdutoFornecedor WHERE IDFornecedor = @IDFornecedor) "
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return itemsList
            '
            For Each r In dt.Rows
                '
                Dim item As clPedidoItem = ConvertRowInClass(r, Pedido)
                itemsList.Add(item)
                '
            Next
            '
            Return itemsList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' VERIFICA E OBTEM PRODUTOS PELA RESERVA POR FORNECEDOR
    '==========================================================================================
    Public Function VerificaProdutoReservaFornecedor(IDFornecedor As Integer,
                                                     Pedido As clPedido) As List(Of clPedidoItem)
        '
        Try
            '
            If IsNothing(Pedido.IDFilial) Then
                Throw New AppException("O pedido ainda não tem Filial...")
                Return Nothing
            End If
            '
            Dim itemsList As New List(Of clPedidoItem)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDFornecedor", IDFornecedor)
            db.AdicionarParametros("@IDFilial", Pedido.IDFilial)
            '
            ' SELECT * FROM qryReserva WHERE IDProduto = (SELECT IDProduto FROM tblProdutoFornecedor WHERE IDFornecedor = 38)
            '
            Dim query As String = "SELECT *, E.EstoqueIdeal, E.EstoqueNivel, E.Quantidade AS Estoque, E.IDFilial " +
                                  "FROM qryReserva " +
                                  "LEFT JOIN tblEstoque AS E " +
                                  "ON qryReserva.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial " +
                                  "WHERE IDFornecedor = @IDFornecedor " +
                                  "AND qryReserva.IDFilial = @IDFilial " +
                                  "AND IDSituacaoReserva = 1 "
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return itemsList
            '
            For Each r In dt.Rows
                '
                Dim item As clPedidoItem = ConvertRowInClass(r, Pedido, 1, r("IDReserva"))
                itemsList.Add(item)
                '
            Next
            '
            Return itemsList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' VERIFICA E OBTEM PRODUTOS PELA RESERVA POR FORNECEDOR SECUNDARIO
    '==========================================================================================
    Public Function VerificaProdutoReservaFornecedorSecundario(IDFornecedor As Integer,
                                                               Pedido As clPedido) As List(Of clPedidoItem)
        '
        Try
            '
            If IsNothing(Pedido.IDFilial) Then
                Throw New AppException("O pedido ainda não tem Filial...")
                Return Nothing
            End If
            '
            Dim itemsList As New List(Of clPedidoItem)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDFornecedor", IDFornecedor)
            db.AdicionarParametros("@IDFilial", Pedido.IDFilial)
            '
            Dim query As String = "SELECT *, E.EstoqueIdeal, E.EstoqueNivel, E.Quantidade AS Estoque, E.IDFilial " +
                                  "FROM qryReserva " +
                                  "LEFT JOIN tblEstoque AS E " +
                                  "ON qryReserva.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial " +
                                  "WHERE qryReserva.IDFilial = @IDFilial " +
                                  "AND qryReserva.IDSituacaoReserva = 1 " +
                                  "AND qryReserva.IDProduto IN (SELECT IDProduto FROM tblProdutoFornecedor WHERE IDFornecedor = @IDFornecedor);"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return itemsList
            '
            For Each r In dt.Rows
                '
                Dim item As clPedidoItem = ConvertRowInClass(r, Pedido, 1, r("IDReserva"))
                itemsList.Add(item)
                '
            Next
            '
            Return itemsList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' VERIFICA E OBTEM PRODUTOS PELA RESERVA PELO TIPO DO PRODUTO
    '==========================================================================================
    Public Function VerificaProdutoReservaTipo(IDTipo As Integer,
                                               Pedido As clPedido) As List(Of clPedidoItem)
        '
        Try
            '
            If IsNothing(Pedido.IDFilial) Then
                Throw New AppException("O pedido ainda não tem Filial...")
                Return Nothing
            End If
            '
            Dim itemsList As New List(Of clPedidoItem)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDTipo", IDTipo)
            db.AdicionarParametros("@IDFilial", Pedido.IDFilial)
            '
            Dim query As String = "SELECT *, E.EstoqueIdeal, E.EstoqueNivel, E.Quantidade AS Estoque, E.IDFilial " +
                                  "FROM qryReserva " +
                                  "LEFT JOIN tblEstoque AS E " +
                                  "ON qryReserva.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial " +
                                  "WHERE IDProdutoTipo = @IDTipo " +
                                  "AND qryReserva.IDFilial = @IDFilial " +
                                  "AND IDSituacaoReserva = 1 "
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return itemsList
            '
            For Each r In dt.Rows
                '
                Dim item As clPedidoItem = ConvertRowInClass(r, Pedido, 1, r("IDReserva"))
                itemsList.Add(item)
                '
            Next
            '
            Return itemsList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' VERIFICA E OBTEM PRODUTOS PELA RESERVA PELO FABRICANTE DO PRODUTO
    '==========================================================================================
    Public Function VerificaProdutoReservaFabricante(IDFabricante As Integer,
                                                     Pedido As clPedido) As List(Of clPedidoItem)
        '
        Try
            '
            If IsNothing(Pedido.IDFilial) Then
                Throw New AppException("O pedido ainda não tem Filial...")
                Return Nothing
            End If
            '
            Dim itemsList As New List(Of clPedidoItem)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDFabricante", IDFabricante)
            db.AdicionarParametros("@IDFilial", Pedido.IDFilial)
            '
            Dim query As String = "SELECT *, E.EstoqueIdeal, E.EstoqueNivel, E.Quantidade AS Estoque, E.IDFilial " +
                                  "FROM qryReserva " +
                                  "LEFT JOIN tblEstoque AS E " +
                                  "ON qryReserva.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial " +
                                  "WHERE IDFabricante = @IDFabricante " +
                                  "AND qryReserva.IDFilial = @IDFilial " +
                                  "AND IDSituacaoReserva = 1 "
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return itemsList
            '
            For Each r In dt.Rows
                '
                Dim item As clPedidoItem = ConvertRowInClass(r, Pedido, 1, r("IDReserva"))
                itemsList.Add(item)
                '
            Next
            '
            Return itemsList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' CONVERT ROW EM CLPEDIDOITEM
    '==========================================================================================
    Private Function ConvertRowInClass(r As DataRow,
                                       pedido As clPedido,
                                       Optional Origem As Byte = 0,
                                       Optional IDOrigem As Integer? = Nothing) As clPedidoItem
        '
        Dim OrigemDescricao As String = ""
        Dim Quantidade As Integer = 1
        '
        Select Case Origem
            Case 0 'PedidoLocal
                OrigemDescricao = "Pedido Local"
                Quantidade = r("EstoqueIdeal") - r("Estoque")
            Case 1 'ReservaLocal
                OrigemDescricao = "Reserva Local"
                Quantidade = 1
        End Select
        '
        Dim item As New clPedidoItem With {
            .IDProduto = r("IDProduto"),
            .Produto = r("Produto"),
            .Autor = If(IsDBNull(r("Autor")), String.Empty, r("Autor")),
            .IDProdutoTipo = r("IDProdutoTipo"),
            .RGProduto = r("RGProduto"),
            .ProdutoTipo = r("ProdutoTipo"),
            .Preco = r("PCompra"),
            .Desconto = If(IsDBNull(r("DescontoCompra")), 0, r("DescontoCompra")),
            .Quantidade = Quantidade,
            .ApelidoFilial = pedido.ApelidoFilial,
            .Estoque = r("Estoque"),
            .EstoqueIdeal = r("EstoqueIdeal"),
            .EstoqueNivel = r("EstoqueNivel"),
            .IDFilialOrigem = pedido.IDFilial,
            .IDOrigem = IDOrigem,
            .Origem = Origem, '-- 0:PedidoLocal | 1:ReservaLocal | 2:PedidoFilial | 3:ReservaFilial | 4:MigracaoLocal
            .OrigemDescricao = OrigemDescricao,
            .IDPedido = pedido.IDPedido,
            .IDPedidoItem = Nothing
            }
        '
        Return item
        '
    End Function
    '
#End Region '/ VERIFICAR E ADICIONAR ITEMS AO PEDIDO
    '
#Region "MIGRACAO DE PEDIDOS"
    '
    '==========================================================================================
    ' GET LIST OF PEDIDOS MIGRATED TO OTHER BY IDMIGRACAO
    '==========================================================================================
    Public Function GetPedidosMigrados(IDMigracao As Integer) As List(Of clPedido)
        '
        Try
            '
            Dim db As New AcessoDados
            db.LimparParametros()
            db.AdicionarParametros("@IDMigracao", IDMigracao)
            Dim query As String = "SELECT * FROM qryPedidos WHERE IDMigracao = @IDMigracao"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            Dim list As New List(Of clPedido)
            If dt.Rows.Count = 0 Then Return list
            '
            For Each r In dt.Rows
                list.Add(ConvertRowInPedido(r))
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
    ' COUNT PEDIDOS MIGRATED TO OTHER BY IDMIGRACAO
    '==========================================================================================
    Public Function CountPedidosMigrados(IDMigracao As Integer) As Integer
        '
        Try
            '
            Dim db As New AcessoDados
            db.LimparParametros()
            db.AdicionarParametros("@IDMigracao", IDMigracao)
            Dim query As String = "SELECT COUNT(*) FROM qryPedidos WHERE IDMigracao = @IDMigracao"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then
                Return 0
            Else
                Dim obj As Object = dt.Rows(0).Item(0)
                '
                If IsNumeric(obj) Then
                    Return obj
                Else
                    Throw New Exception(obj.ToString)
                End If
                '
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' CREATE MIGRACAO
    '==========================================================================================
    Public Function MakeMigracao(IDPedido As Integer, IDMigracao As Integer) As Boolean
        '
        Try
            Dim bd As New AcessoDados
            '
            bd.LimparParametros()
            '
            '--- ADICIONA OS PARAMENTROS NECESSARIOS
            bd.AdicionarParametros("@IDPedido", IDPedido)
            bd.AdicionarParametros("@IDMigracao", IDMigracao)
            bd.AdicionarParametros("@RevisaoData", Today)
            '
            Dim query As String = "UPDATE tblPedido " +
                "SET IDMigracao = @IDMigracao, Situacao = 4, RevisaoData = @RevisaoData " +
                "WHERE IDPedido = @IDPedido"
            '
            bd.ExecutarManipulacao(CommandType.Text, query)
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' REMOVE MIGRACAO
    '==========================================================================================
    Public Function RemoveMigracao(IDPedido As Integer,
                                   IDMigracao As Integer,
                                   Optional dbTran As Object = Nothing) As Boolean
        '
        Try
            '
            If GetPedidoMigradoSituacaoOrigem(IDMigracao) <> 0 Then
                Throw New AppException("Não é possível remover a migração desse pedido porque " +
                                       "o pedido para o qual foi migrado já foi enviado ou recebido.")
                Return False
            End If
            '
            Dim bd As AcessoDados = If(dbTran, New AcessoDados)
            '
            bd.LimparParametros()
            '
            '--- ADICIONA OS PARAMENTROS NECESSARIOS
            bd.AdicionarParametros("@IDPedido", IDPedido)
            bd.AdicionarParametros("@IDMigracao", DBNull.Value)
            bd.AdicionarParametros("@RevisaoData", Today)
            '
            Dim query As String = "UPDATE tblPedido SET " +
                "IDMigracao = @IDMigracao, Situacao = 0, RevisaoData = @RevisaoData " +
                "WHERE IDPedido = @IDPedido"
            '
            bd.ExecutarManipulacao(CommandType.Text, query)
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET SITUACAO OF PEDIDO MIGRADO
    '==========================================================================================
    Public Function GetPedidoMigradoSituacaoOrigem(IDMigracao As Integer) As Byte
        '
        Try
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDMigracao", IDMigracao)
            '
            Dim query As String = "SELECT Situacao FROM tblPedido WHERE IDPedido = @IDMigracao"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then
                Throw New AppException("Não há pedido de origem com o ID informado...")
            End If
            '
            Dim obj As Object = dt.Rows(0).Item(0)
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
#End Region '/ MIGRACAO
    '
End Class