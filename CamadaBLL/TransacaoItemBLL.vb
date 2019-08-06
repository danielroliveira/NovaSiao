Imports CamadaDTO
Imports CamadaDAL
'
Public Class TransacaoItemBLL
    '
    '==========================================================================================
    ' ENUM MOVIMENTO de ENTRADA ou SAIDA
    '==========================================================================================
    Public Enum EnumMovimento
        ENTRADA '--- no caso de COMPRA, entrada de produto
        SAIDA '--- no caso de VENDA, saída de produto
    End Enum
    '
    '==========================================================================================
    ' RETORNA UMA LISTA DE ITEM TRANSACAO PELO IDTRANSACAO - SAIDA DE PRODUTOS
    '==========================================================================================
    Public Function GetTransacaoItens_List(IDTransacao As Integer, IDFilial As Integer) As List(Of clTransacaoItem)
        Dim objdb As New AcessoDados
        '
        '--- limpar os parâmetros
        objdb.LimparParametros()
        '
        '--- adicionar os parâmetros
        objdb.AdicionarParametros("@IDTransacao", IDTransacao)
        objdb.AdicionarParametros("@IDFilial", IDFilial)
        '
        '--- Create SELECT query
        Dim myQuery As String = "SELECT * FROM qryTransacaoItem WHERE IDTransacao = @IDTransacao AND IDFilial = @IDFilial"
        '
        Try
            '--- GET DATATABLE
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, myQuery)
            '
            '--- RETURN
            Return ConvertDt_in_ListOf(dt, False)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '===================================================================================================
    ' RETORNA UMA LISTA DE ITENS TRANSACAO PELO IDTRANSACAO COM CUSTOS - ENTRADA DE PRODUTOS
    '===================================================================================================
    Public Function GetTransacaoItens_WithCustos_List(myIDTransacao As Integer, myFilial As Integer) As List(Of clTransacaoItem)
        Dim objdb As New AcessoDados
        '
        '--- limpar os parâmetros
        objdb.LimparParametros()
        '--- adicionar os parâmetros
        objdb.AdicionarParametros("@IDTransacao", myIDTransacao)
        objdb.AdicionarParametros("@IDFilial", myFilial)
        '
        '--- Create SELECT query
        Dim myQuery As String = "SELECT * FROM qryTransacaoItemCustos WHERE IDTransacao = @IDTransacao AND IDFilial = @IDFilial"
        '
        Try
            '
            '--- GET TABLE
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, myQuery)
            '
            '--- RETURN
            Return ConvertDt_in_ListOf(dt, True)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET UM PRODUTO DO NOVO ITEM DA TRANSACAO
    '==========================================================================================
    Public Function TransacaoItem_Get_New(_CodProcurado As String, _IDFilial As Integer) As clTransacaoItem
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        '
        Dim myQuery As String = "SELECT P.*, E.Quantidade AS Estoque, E.Reservado, " &
                                "NULL AS IDTransacaoItem, NULL AS Preco, NULL AS IDTransacao, " &
                                "NULL AS Quantidade, NULL AS Desconto, @IDFilial AS IDFilial " &
                                "FROM qryProdutos AS P " &
                                "LEFT JOIN tblEstoque AS E " &
                                "ON P.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial"
        '
        '--- Adiciona IDFilial
        db.AdicionarParametros("@IDFilial", _IDFilial)
        '
        '--- verifica se o cod informado é RG ou CODBARRAS
        If Len(_CodProcurado) < 7 Then '--> FIND for RGProduto
            db.AdicionarParametros("@RGProduto", _CodProcurado)
            myQuery = myQuery & " WHERE RGProduto = @RGProduto"
        Else '--> FIND for CodBarrasA
            db.AdicionarParametros("@CodBarrasA", _CodProcurado)
            myQuery = myQuery & " WHERE CodBarrasA = @CodBarrasA"
        End If
        '
        Try
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then
                Return New clTransacaoItem '--- retorna um item vazio quando nao encontra
            Else
                Return ConvertDt_in_ListOf(dt, False)(0)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET O ESTOQUE DE UM PRODUTO PELO ID E PELA FILIAL
    '==========================================================================================
    Public Function Item_GetEstoque(_IDProduto As Integer, _IDFilial As Integer) As DataTable
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        '
        Dim myQuery As String = "SELECT E.Quantidade AS Estoque, E.Reservado " &
                                "FROM tblEstoque AS E " &
                                "WHERE IDProduto = @IDProduto AND IDFilial = @IDFilial"
        '
        '--- Adiciona IDFilial
        db.AdicionarParametros("@IDFilial", _IDFilial)
        db.AdicionarParametros("@IDProduto", _IDProduto)
        '
        Try
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then
                Throw New Exception("Estoque do Produto na Filial não foi encontrado...")
            Else
                Return dt
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' CONVERTE DATATABLE IN LIST OF CLTRANSACAOITEM
    '==========================================================================================
    Private Function ConvertDt_in_ListOf(dt As DataTable, withCustos As Boolean) As List(Of clTransacaoItem)
        '
        Dim lista As New List(Of clTransacaoItem)
        '
        If dt.Rows.Count = 0 Then Return lista
        '
        For Each r As DataRow In dt.Rows
            Dim itn As clTransacaoItem = New clTransacaoItem
            '--- Itens da tblTransacaoItens
            itn.IDTransacaoItem = IIf(IsDBNull(r("IDTransacaoItem")), Nothing, r("IDTransacaoItem"))
            itn.Preco = IIf(IsDBNull(r("Preco")), Nothing, r("Preco"))
            itn.IDTransacao = IIf(IsDBNull(r("IDTransacao")), Nothing, r("IDTransacao"))
            itn.Quantidade = IIf(IsDBNull(r("Quantidade")), Nothing, r("Quantidade"))
            itn.Desconto = IIf(IsDBNull(r("Desconto")), Nothing, r("Desconto"))
            '--- Itens Importados tblProdutos
            itn.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
            itn.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
            itn.CodBarrasA = IIf(IsDBNull(r("CodBarrasA")), Nothing, r("CodBarrasA"))
            itn.PVenda = IIf(IsDBNull(r("PVenda")), Nothing, r("PVenda"))
            itn.DescontoCompra = IIf(IsDBNull(r("DescontoCompra")), 0, r("DescontoCompra"))
            itn.PCompra = IIf(IsDBNull(r("PCompra")), Nothing, r("PCompra"))
            itn.ProdutoAtivo = IIf(IsDBNull(r("ProdutoAtivo")), Nothing, r("ProdutoAtivo"))
            itn.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
            itn.ProdutoAtivo = IIf(IsDBNull(r("ProdutoAtivo")), Nothing, r("ProdutoAtivo"))
            '--- Itens tblEstoque
            itn.Reservado = IIf(IsDBNull(r("Reservado")), Nothing, r("Reservado"))
            itn.Estoque = IIf(IsDBNull(r("Estoque")), Nothing, r("Estoque"))
            itn.IDFilial = r("IDFilial")
            '
            If withCustos Then '--> Add Custos
                '--- Itens Importados tblTransacaoItensCustos
                itn.FreteRateado = IIf(IsDBNull(r("FreteRateado")), Nothing, r("FreteRateado"))
                itn.ICMS = IIf(IsDBNull(r("ICMS")), Nothing, r("ICMS"))
                itn.Substituicao = IIf(IsDBNull(r("Substituicao")), Nothing, r("Substituicao"))
                itn.MVA = IIf(IsDBNull(r("MVA")), Nothing, r("MVA"))
                itn.IPI = IIf(IsDBNull(r("IPI")), Nothing, r("IPI"))
            End If
            '
            lista.Add(itn)
            '
        Next
        '
        Return lista
        '
    End Function
    '
    '==========================================================================================
    ' INSERE UM NOVO ITEM NA TRANSACAO
    '==========================================================================================
    Public Function InserirNovoItem(Item As clTransacaoItem,
                                    Movimento As EnumMovimento,
                                    MovData As Date,
                                    InsereCustos As Boolean,
                                    Optional dbTran As Object = Nothing) As Long
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- limpa os parametros
        db.LimparParametros()
        '
        '--- adiciona os parametros
        db.AdicionarParametros("@IDTransacao", Item.IDTransacao)
        db.AdicionarParametros("@IDProduto", Item.IDProduto)
        db.AdicionarParametros("@Quantidade", Item.Quantidade)
        db.AdicionarParametros("@Preco", Item.Preco)
        db.AdicionarParametros("@Desconto", Item.Desconto)
        db.AdicionarParametros("@IDFilial", Item.IDFilial)
        db.AdicionarParametros("@Movimento", Movimento.ToString)
        db.AdicionarParametros("@MovData", MovData)
        db.AdicionarParametros("@InsereCustos", InsereCustos)
        '
        If InsereCustos Then ' SE InsereCustos ADICIONA OS CUSTOS NO tblTransacaoItensCustos
            db.AdicionarParametros("@ICMS", Item.ICMS)
            db.AdicionarParametros("@Substituicao", Item.Substituicao)
            db.AdicionarParametros("@FreteRateado", Item.FreteRateado)
            db.AdicionarParametros("@MVA", Item.MVA)
            db.AdicionarParametros("@IPI", Item.IPI)
        End If
        '
        Try
            '--- executa a procedure
            Dim obj As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTransacaoItem_Inserir")
            '
            '--- verifica o resultado
            If Not IsNothing(obj) AndAlso IsNumeric(obj) Then
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
    '==========================================================================================
    ' EDITA UM ITEM EXISTENTE NA TRANSACAO
    '==========================================================================================
    Public Function EditarItem(Item As clTransacaoItem,
                               Movimento As EnumMovimento,
                               MovData As Date,
                               InsereCustos As Boolean,
                               Optional dbTran As Object = Nothing) As Long
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- limpa os parametros
        db.LimparParametros()
        '
        '--- adiciona os parametros
        db.AdicionarParametros("@IDTransacaoItem", Item.IDTransacaoItem)
        db.AdicionarParametros("@IDProduto", Item.IDProduto)
        db.AdicionarParametros("@Quantidade", Item.Quantidade)
        db.AdicionarParametros("@Preco", Item.Preco)
        db.AdicionarParametros("@Desconto", Item.Desconto)
        db.AdicionarParametros("@IDFilial", Item.IDFilial)
        db.AdicionarParametros("@Movimento", Left(Movimento.ToString, 1).ToUpper)
        db.AdicionarParametros("@MovData", MovData)
        db.AdicionarParametros("@InsereCustos", InsereCustos)
        '
        If InsereCustos Then ' SE insereCustos EDITA OS CUSTOS NO tblTransacaoItensCustos
            db.AdicionarParametros("@ICMS", Item.ICMS)
            db.AdicionarParametros("@Substituicao", Item.Substituicao)
            db.AdicionarParametros("@FreteRateado", Item.FreteRateado)
            db.AdicionarParametros("@MVA", Item.MVA)
            db.AdicionarParametros("@IPI", Item.IPI)
        End If
        '
        Try
            '--- executa a procedure
            Dim obj As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTransacaoItem_Editar")
            '
            '--- verifica o resultado
            If Not IsNothing(obj) AndAlso IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EXCLUI UM ITEM EXISTENTE NA TRANSACAO
    '==========================================================================================
    Public Function ExcluirItem(Item As clTransacaoItem,
                                Movimento As EnumMovimento,
                                Optional mydb As Object = Nothing) As Long
        '
        Dim db As AcessoDados = If(mydb, New AcessoDados)
        '
        '--- limpa os parametros
        db.LimparParametros()
        '
        '--- adiciona os parametros
        db.AdicionarParametros("@IDTransacaoItem", Item.IDTransacaoItem)
        db.AdicionarParametros("@IDProduto", Item.IDProduto)
        db.AdicionarParametros("@Quantidade", Item.Quantidade)
        db.AdicionarParametros("@IDFilial", Item.IDFilial)
        db.AdicionarParametros("@Movimento", Movimento.ToString)
        '
        Try
            '--- executa a procedure
            Dim obj As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspTransacaoItem_Excluir")
            '
            '--- verifica o resultado
            If Not IsNothing(obj) AndAlso IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    '--- ULTIMAS TRANSACOES (COMPRA | VENDA | SIMPLES | DEVOLUCAO ) DO PRODUTO --> DATATABLE
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoTransacoes(IDProduto As Integer,
                                      MovTipo As EnumMovimento,
                                      IDFilial As Integer,
                                      Optional Operacao As TransacaoBLL.EnumOperacao = Nothing,
                                      Optional dtInicial As Date? = Nothing,
                                      Optional dtFinal As Date? = Nothing) As List(Of clTransacaoItem)
        '
        Dim db As AcessoDados
        '
        Try
            db = New AcessoDados
        Catch ex As Exception
            Throw ex
        End Try
        '
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDProduto", IDProduto)
        db.AdicionarParametros("@IDFilial", IDFilial)
        '
        Dim query As String = "SELECT I.IDTransacaoItem, I.IDTransacao, I.IDProduto, I.Quantidade, I.Preco, I.Desconto, " +
                              "T.TransacaoData, T.IDOperacao, O.Operacao, O.MovimentoEstoque " +
                              "FROM tblTransacaoItens AS I " +
                              "JOIN tblTransacao AS T " +
                              "ON I.IDTransacao = T.IDTransacao " +
                              "JOIN tblOperacao AS O " +
                              "ON T.IDOperacao = O.IDOperacao " +
                              "WHERE I.IDProduto = @IDProduto "

        '
        If MovTipo = EnumMovimento.ENTRADA Then
            '--- CASO ENTRADA
            query += "AND T.IDPessoaDestino = @IDFilial AND O.MovimentoEstoque = 'E' "
        Else
            '--- CASO SAIDA
            query += "AND T.IDPessoaOrigem = @IDFilial AND O.MovimentoEstoque = 'S' "
        End If
        '
        '--- OPERACAO
        If Not IsNothing(Operacao) AndAlso Operacao > 0 Then
            '
            db.AdicionarParametros("@IDOperacao", Operacao)
            query += "AND O.IDOperacao = @IDOperacao "
            '
        End If
        '
        '--- DATA INICIAL
        If Not IsNothing(dtInicial) Then
            '
            db.AdicionarParametros("@DataInicial", dtInicial)
            query += "AND TransacaoData >= @DataInicial "
            '
        End If
        '
        '--- DATA FINAL
        If Not IsNothing(dtFinal) Then
            '
            db.AdicionarParametros("@DataFinal", dtFinal)
            query += "AND TransacaoData <= @DataFinal "
            '
        End If
        '
        '--- ORDER BY
        query += "ORDER BY T.TransacaoData"
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            Dim lista As New List(Of clTransacaoItem)
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each r As DataRow In dt.Rows
                Dim itn As clTransacaoItem = New clTransacaoItem
                '--- Itens da tblTransacaoItens
                itn.IDTransacaoItem = IIf(IsDBNull(r("IDTransacaoItem")), Nothing, r("IDTransacaoItem"))
                itn.IDTransacao = IIf(IsDBNull(r("IDTransacao")), Nothing, r("IDTransacao"))
                itn.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
                itn.Preco = IIf(IsDBNull(r("Preco")), Nothing, r("Preco"))
                itn.Quantidade = IIf(IsDBNull(r("Quantidade")), Nothing, r("Quantidade"))
                itn.Desconto = IIf(IsDBNull(r("Desconto")), Nothing, r("Desconto"))
                '--- Itens Importados tblTransacaoItensCustos
                itn.TransacaoData = IIf(IsDBNull(r("TransacaoData")), Nothing, r("TransacaoData"))
                itn.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao"))
                itn.Operacao = IIf(IsDBNull(r("Operacao")), Nothing, r("Operacao"))
                itn.MovimentoEstoque = IIf(IsDBNull(r("MovimentoEstoque")), Nothing, r("MovimentoEstoque"))
                '
                lista.Add(itn)
                '
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
    '---------------------------------------------------------------------------------------------------------
    '--- ULTIMAS TRANSACOES AGRUPADAS (COMPRA | VENDA | SIMPLES | DEVOLUCAO ) DO PRODUTO --> DATATABLE
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoTransacoesGroup(IDProduto As Integer,
                                           MovTipo As EnumMovimento,
                                           IDFilial As Integer,
                                           Optional Operacao As TransacaoBLL.EnumOperacao = Nothing,
                                           Optional dtInicial As Date? = Nothing,
                                           Optional dtFinal As Date? = Nothing) As List(Of clTransacaoItem)
        '
        Dim db As AcessoDados
        '
        Try
            db = New AcessoDados
        Catch ex As Exception
            Throw ex
        End Try
        '
        db.LimparParametros()
        '
        db.AdicionarParametros("@IDProduto", IDProduto)
        db.AdicionarParametros("@IDFilial", IDFilial)
        '
        Dim query As String = "SELECT I.IDTransacaoItem, I.IDTransacao, I.IDProduto, I.Quantidade, I.Preco, I.Desconto, " +
                              "T.TransacaoData, T.IDOperacao, O.Operacao, O.MovimentoEstoque " +
                              "FROM tblTransacaoItens AS I " +
                              "JOIN tblTransacao AS T " +
                              "ON I.IDTransacao = T.IDTransacao " +
                              "JOIN tblOperacao AS O " +
                              "ON T.IDOperacao = O.IDOperacao " +
                              "WHERE I.IDProduto = @IDProduto "

        query = "SELECT " +
                "I.IDProduto, " +
                "SUM(I.Quantidade) AS QuantidadeTotal, " +
                "SUM(I.Preco * I.Quantidade) AS ValorTotal, " +
                "SUM(I.Quantidade * I.Preco * I.Desconto/ 100) AS TotalDesc, " +
                "YEAR(T.TransacaoData) AS Ano, " +
                "MONTH(T.TransacaoData) AS Mes, " +
                "T.IDOperacao, O.Operacao, O.MovimentoEstoque " +
                "FROM tblTransacaoItens AS I " +
                "INNER JOIN " +
                "tblTransacao AS T ON I.IDTransacao = T.IDTransacao " +
                "INNER JOIN " +
                "tblOperacao AS O ON T.IDOperacao = O.IDOperacao " +
                "GROUP BY I.IDProduto, " +
                "YEAR(T.TransacaoData), MONTH(T.TransacaoData), " +
                "T.IDOperacao, O.Operacao, O.MovimentoEstoque " +
                "HAVING (I.IDProduto = @IDProduto)"

        '
        If MovTipo = EnumMovimento.ENTRADA Then
            '--- CASO ENTRADA
            query += "AND T.IDPessoaDestino = @IDFilial AND O.MovimentoEstoque = 'E' "
        Else
            '--- CASO SAIDA
            query += "AND T.IDPessoaOrigem = @IDFilial AND O.MovimentoEstoque = 'S' "
        End If
        '
        '--- OPERACAO
        If Not IsNothing(Operacao) AndAlso Operacao > 0 Then
            '
            db.AdicionarParametros("@IDOperacao", Operacao)
            query += "AND O.IDOperacao = @IDOperacao "
            '
        End If
        '
        '--- DATA INICIAL
        If Not IsNothing(dtInicial) Then
            '
            db.AdicionarParametros("@DataInicial", dtInicial)
            query += "AND TransacaoData >= @DataInicial "
            '
        End If
        '
        '--- DATA FINAL
        If Not IsNothing(dtFinal) Then
            '
            db.AdicionarParametros("@DataFinal", dtFinal)
            query += "AND TransacaoData <= @DataFinal "
            '
        End If
        '
        '--- ORDER BY
        query += "ORDER BY T.TransacaoData"
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            Dim lista As New List(Of clTransacaoItem)
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each r As DataRow In dt.Rows
                Dim itn As clTransacaoItem = New clTransacaoItem
                '--- Itens da tblTransacaoItens
                itn.IDTransacaoItem = IIf(IsDBNull(r("IDTransacaoItem")), Nothing, r("IDTransacaoItem"))
                itn.IDTransacao = IIf(IsDBNull(r("IDTransacao")), Nothing, r("IDTransacao"))
                itn.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
                itn.Preco = IIf(IsDBNull(r("Preco")), Nothing, r("Preco"))
                itn.Quantidade = IIf(IsDBNull(r("Quantidade")), Nothing, r("Quantidade"))
                itn.Desconto = IIf(IsDBNull(r("Desconto")), Nothing, r("Desconto"))
                '--- Itens Importados tblTransacaoItensCustos
                itn.TransacaoData = IIf(IsDBNull(r("TransacaoData")), Nothing, r("TransacaoData"))
                itn.IDOperacao = IIf(IsDBNull(r("IDOperacao")), Nothing, r("IDOperacao"))
                itn.Operacao = IIf(IsDBNull(r("Operacao")), Nothing, r("Operacao"))
                itn.MovimentoEstoque = IIf(IsDBNull(r("MovimentoEstoque")), Nothing, r("MovimentoEstoque"))
                '
                lista.Add(itn)
                '
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
End Class
