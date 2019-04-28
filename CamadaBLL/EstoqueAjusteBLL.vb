Imports CamadaDTO
Imports CamadaDAL
'
Public Class EstoqueAjusteBLL
    '
#Region "ESTOQUE AJUSTE"
    '
    '==========================================================================================
    ' CONVERT DATAROW DA DATATABLE QRYESTOQUEAJUSTE EM UM CLESTOQUEAJUSTE 
    '==========================================================================================
    Private Function ConvertDtRow_clEstoqueAjuste(r As DataRow) As clEstoqueAjuste
        '
        Dim ajt As New clEstoqueAjuste With {
            .IDEstoqueAjuste = If(IsDBNull(r("IDEstoqueAjuste")), Nothing, r("IDEstoqueAjuste")),
            .IDFilial = If(IsDBNull(r("IDFilial")), Nothing, r("IDFilial")),
            .ApelidoFilial = If(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial")),
            .IDUser = If(IsDBNull(r("IDUser")), Nothing, r("IDUser")),
            .UsuarioApelido = If(IsDBNull(r("UsuarioApelido")), String.Empty, r("UsuarioApelido")),
            .AjusteOrigem = If(IsDBNull(r("AjusteOrigem")), Nothing, r("AjusteOrigem")),
            .AjusteOrigemDescricao = If(IsDBNull(r("AjusteOrigemDescricao")), String.Empty, r("AjusteOrigemDescricao")),
            .AjusteData = If(IsDBNull(r("AjusteData")), Nothing, r("AjusteData")),
            .ValorMovimentado = If(IsDBNull(r("ValorMovimentado")), 0, r("ValorMovimentado")),
            .Bloqueado = If(IsDBNull(r("Bloqueado")), Nothing, r("Bloqueado")),
            .Observacao = If(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        }
        '
        Return ajt
        '
    End Function
    '
    '==========================================================================================
    ' GET ESTOQUE INICIAL LIST
    '==========================================================================================
    Public Function GetEstoqueInicialList(IDFilial As Integer) As List(Of clEstoqueAjuste)
        '
        Dim db As New AcessoDados
        '
        '--- check if exists some estoque inicial inserted on FILIAL
        '----------------------------------------------------------------------------------
        db.LimparParametros()
        db.AdicionarParametros("@IDFilial", IDFilial)
        '
        Dim myQuery As String = "SELECT * FROM qryEstoqueAjuste " &
                                "WHERE AjusteOrigem = 1 " &
                                "AND IDFilial = @IDFilial"
        Dim dt As DataTable
        Dim list As New List(Of clEstoqueAjuste)
        '
        Try
            dt = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then
                Return list
            Else
                For Each r As DataRow In dt.Rows
                    list.Add(ConvertDtRow_clEstoqueAjuste(r))
                Next
                '
                Return list
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
    ' INSERT NEW AJUSTE ESTOQUE INICIAL
    '==========================================================================================
    Public Function InsertAjusteEstoqueInicial(Ajuste As clEstoqueAjuste,
                                               Optional dbTran As Object = Nothing) As clEstoqueAjuste
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        Try
            '
            '--- Block all previous ajustes 
            db.ExecutarManipulacao(CommandType.Text, "UPDATE tblEstoqueAjuste SET Bloqueado = 'TRUE' WHERE AjusteOrigem = 1")
            '
            '--- create new record of Estoque Inicial
            '----------------------------------------------------------------------------------
            db.LimparParametros()
            '
            '--- Add params
            db.AdicionarParametros("@IDFilial", Ajuste.IDFilial)
            db.AdicionarParametros("@IDUser", Ajuste.IDUser)
            db.AdicionarParametros("@AjusteData", Ajuste.AjusteData)
            db.AdicionarParametros("@AjusteOrigem", 1)
            db.AdicionarParametros("@ValorMovimentado", 0)
            db.AdicionarParametros("@Bloqueado", False)
            '
            Dim myQuery As String = "INSERT INTO tblEstoqueAjuste " &
                                    "(IDFilial, AjusteData, IDUser, AjusteOrigem, ValorMovimentado, Bloqueado) " &
                                    "VALUES (@IDFilial, @AjusteData, @IDUser, @AjusteOrigem, @ValorMovimentado, @Bloqueado)"
            '
            '--- Insert new Ajuste
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- get new Ajuste ID
            db.LimparParametros()
            myQuery = "SELECT * FROM qryEstoqueAjuste WHERE IDEstoqueAjuste IN (SELECT @@IDENTITY)"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count > 0 Then

                Dim newAjt As clEstoqueAjuste = ConvertDtRow_clEstoqueAjuste(dt.Rows(0))
                '
                '--- Verifica se existe observacao
                Dim oBLL As New ObservacaoBLL
                oBLL.SaveObservacao(14, newAjt.IDEstoqueAjuste, If(Ajuste.Observacao, ""), dbTran)
                '
                Return newAjt
                '
            Else
                Throw New Exception("Não foi possível adicionar/editar Estoque Inicial...")
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' INSERT NEW ESTOQUE AJUSTE
    '==========================================================================================
    Public Function InsertEstoqueAjuste(Ajuste As clEstoqueAjuste,
                                        Optional dbTran As Object = Nothing) As clEstoqueAjuste
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        Try
            '
            '--- create new record of Estoque Inicial
            '----------------------------------------------------------------------------------
            db.LimparParametros()
            '
            '--- Add params
            db.AdicionarParametros("@IDFilial", Ajuste.IDFilial)
            db.AdicionarParametros("@IDUser", Ajuste.IDUser)
            db.AdicionarParametros("@AjusteData", Ajuste.AjusteData)
            db.AdicionarParametros("@AjusteOrigem", 2)
            db.AdicionarParametros("@ValorMovimentado", Ajuste.ValorMovimentado)
            db.AdicionarParametros("@Bloqueado", True)
            '
            Dim myQuery As String = "INSERT INTO tblEstoqueAjuste " &
                                    "(IDFilial, AjusteData, IDUser, AjusteOrigem, ValorMovimentado, Bloqueado) " &
                                    "VALUES (@IDFilial, @AjusteData, @IDUser, @AjusteOrigem, @ValorMovimentado, @Bloqueado)"
            '
            '--- Insert new Ajuste
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- get new Ajuste ID
            db.LimparParametros()
            myQuery = "SELECT * FROM qryEstoqueAjuste WHERE IDEstoqueAjuste IN (SELECT @@IDENTITY)"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count > 0 Then

                Dim newAjt As clEstoqueAjuste = ConvertDtRow_clEstoqueAjuste(dt.Rows(0))
                '
                '--- Verifica se existe observacao e save
                If Not IsNothing(Ajuste.Observacao) AndAlso Ajuste.Observacao.Length > 0 Then
                    Dim oBLL As New ObservacaoBLL
                    oBLL.SaveObservacao(14, newAjt.IDEstoqueAjuste, If(Ajuste.Observacao, ""), dbTran)
                End If
                '
                Return newAjt
                '
            Else
                Throw New Exception("Não foi possível adicionar/editar Ajuste de Estoque...")
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET AJUSTE PELO IDAJUSTE
    '==========================================================================================
    Public Function GetAjustePeloID(IDAjuste As Integer) As clEstoqueAjuste
        '
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDEstoqueAjuste", IDAjuste)
        '
        Dim myQuery As String = "SELECT * FROM qryEstoqueAjuste WHERE IDEstoqueAjuste = @IDEstoqueAjuste"
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            If dt.Rows.Count = 0 Then
                Throw New Exception("Não retornou nenhum ajuste de Estoque...")
            End If
            '
            Return ConvertDtRow_clEstoqueAjuste(dt.Rows(0))
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
#End Region '/ ESTOQUE INICIAL AJUSTE
    '
#Region "ESTOQUE AJUSTE ITENS"
    '
    '==========================================================================================
    ' GET LIST OF ESTOQUE AJUSTE ITENS OF A ID
    '==========================================================================================
    Public Function GetAjusteItens_List(IDEstoqueAjuste As Integer, IDFilial As Integer) As List(Of clEstoqueAjusteItem)
        Dim objdb As New AcessoDados
        '
        '--- limpar os parâmetros
        objdb.LimparParametros()
        '
        '--- adicionar os parâmetros
        objdb.AdicionarParametros("@IDEstoqueAjuste", IDEstoqueAjuste)
        objdb.AdicionarParametros("@IDFilial", IDFilial)
        '
        '--- Create SELECT query
        Dim myQuery As String = "SELECT * FROM qryEstoqueAjusteItens WHERE IDEstoqueAjuste = @IDEstoqueAjuste AND IDFilial = @IDFilial"
        '
        Try
            '--- GET DATATABLE
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, myQuery)
            '
            '--- RETURN
            Return ConvertDt_clEstoqueItem(dt)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' CONVERT DATATABLE IN LIST OF CLTRANSACAOITEM
    '==========================================================================================
    Private Function ConvertDt_clEstoqueItem(dt As DataTable) As List(Of clEstoqueAjusteItem)
        '
        Dim lista As New List(Of clEstoqueAjusteItem)
        '
        If dt.Rows.Count = 0 Then Return lista
        '
        For Each r As DataRow In dt.Rows
            '
            Dim itn As New clEstoqueAjusteItem
            '
            '--- Itens da tblEstoqueAjusteItem
            itn.IDEstoqueItem = IIf(IsDBNull(r("IDEstoqueItem")), Nothing, r("IDEstoqueItem"))
            itn.Preco = IIf(IsDBNull(r("Preco")), Nothing, r("Preco"))
            itn.IDEstoqueAjuste = IIf(IsDBNull(r("IDEstoqueAjuste")), Nothing, r("IDEstoqueAjuste"))
            itn.Quantidade = IIf(IsDBNull(r("Quantidade")), Nothing, r("Quantidade"))
            itn.QuantidadeAnterior = IIf(IsDBNull(r("QuantidadeAnterior")), Nothing, r("QuantidadeAnterior"))
            '--- Itens da tblEstoqueAjuste
            itn.AjusteData = IIf(IsDBNull(r("AjusteData")), Nothing, r("AjusteData"))
            itn.AjusteOrigem = IIf(IsDBNull(r("AjusteOrigem")), Nothing, r("AjusteOrigem"))
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
            lista.Add(itn)
            '
        Next
        '
        Return lista
        '
    End Function
    '
    '==========================================================================================
    ' GET LIST OF ESTOQUE AJUSTE ITENS OF AN ESTOQUE INICIAL
    '==========================================================================================
    Public Function GetEstoqueInicialItens_List(IDFilial As Integer) As List(Of clEstoqueAjusteItem)
        Dim objdb As New AcessoDados
        '
        '--- limpar os parâmetros
        objdb.LimparParametros()
        '
        '--- adicionar os parâmetros
        objdb.AdicionarParametros("@IDFilial", IDFilial)
        '
        '--- Create SELECT query
        Dim myQuery As String = "SELECT * FROM qryEstoqueAjusteItens " &
                                "WHERE IDFilial = @IDFilial AND IDEstoqueAjuste IN " &
                                "(SELECT IDEstoqueAjuste FROM tblEstoqueAjuste " &
                                "WHERE AjusteOrigem = 1 AND IDFilial = @IDFilial)"
        '
        Try
            '--- GET DATATABLE
            Dim dt As DataTable = objdb.ExecutarConsulta(CommandType.Text, myQuery)
            '
            '--- RETURN
            Return ConvertDt_clEstoqueItem(dt)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' INSERE UM NOVO ITEM DE AJUSTE DE ESTOQUE
    '==========================================================================================
    Public Function InserirItem(Item As clEstoqueAjusteItem,
                                AjusteData As Date,
                                Optional dbTran As Object = Nothing) As clEstoqueAjusteItem
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- limpa os parametros
        db.LimparParametros()
        '
        '--- adiciona os parametros
        db.AdicionarParametros("@IDEstoqueAjuste", Item.IDEstoqueAjuste)
        db.AdicionarParametros("@IDProduto", Item.IDProduto)
        db.AdicionarParametros("@Quantidade", Item.Quantidade)
        db.AdicionarParametros("@QuantidadeAnterior", Item.QuantidadeAnterior)
        db.AdicionarParametros("@Preco", Item.Preco)
        db.AdicionarParametros("@IDFilial", Item.IDFilial)
        db.AdicionarParametros("@AjusteData", AjusteData)
        '
        Try
            '--- executa a procedure
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspEstoqueAjusteItem_Inserir")
            '
            '--- verifica o resultado
            If dt.Rows.Count = 0 Then
                Throw New Exception("Erro: Não foi inserido nenhum item de Ajuste, a procedure retornou vazio")
            End If
            '
            Return ConvertDt_clEstoqueItem(dt).Item(0)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EDITA UM ITEM EXISTENTE NO ESTOQUE AJUSTE
    '==========================================================================================
    Public Function EditarItem(Item As clEstoqueAjusteItem,
                               AjusteData As Date,
                               Optional dbTran As Object = Nothing) As clEstoqueAjusteItem
        '
        Dim db As AcessoDados = If(dbTran, New AcessoDados)
        '
        '--- limpa os parametros
        db.LimparParametros()
        '
        '--- adiciona os parametros
        db.AdicionarParametros("@IDEstoqueItem", Item.IDEstoqueItem)
        db.AdicionarParametros("@IDProduto", Item.IDProduto)
        db.AdicionarParametros("@Quantidade", Item.Quantidade)
        db.AdicionarParametros("@QuantidadeAnterior", Item.QuantidadeAnterior)
        db.AdicionarParametros("@Preco", Item.Preco)
        db.AdicionarParametros("@IDFilial", Item.IDFilial)
        db.AdicionarParametros("@AjusteData", AjusteData)
        '
        Try
            '--- executa a procedure
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspEstoqueAjusteItem_Editar")
            '
            '--- verifica o resultado
            If dt.Rows.Count > 0 Then
                Return ConvertDt_clEstoqueItem(dt).Item(0)
            Else
                Throw New Exception("Erro: Não foi editado nenhum item de Ajuste, a procedure retornou vazio")
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EXCLUI UM ITEM EXISTENTE NA TRANSACAO
    '==========================================================================================
    Public Function ExcluirItem(Item As clEstoqueAjusteItem,
                                Optional mydb As Object = Nothing) As Long
        '
        Dim db As AcessoDados = If(mydb, New AcessoDados)
        '
        '--- limpa os parametros
        db.LimparParametros()
        '
        '--- adiciona os parametros
        db.AdicionarParametros("@IDEstoqueAjusteItem", Item.IDEstoqueItem)
        db.AdicionarParametros("@IDFilial", Item.IDFilial)
        '
        Try
            '--- executa a procedure
            Dim obj As Object = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspEstoqueAjusteItem_Excluir")
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
    ' GET LISTA TROCA PARA FRMPROCURA RETORNA DATATABLE
    '==========================================================================================
    Public Function GetItemsList_Procura(IDFilial As Integer,
                                         Optional dtInicial As Date? = Nothing,
                                         Optional dtFinal As Date? = Nothing) As List(Of clEstoqueAjusteItem)
        '
        Dim sql As New SQLControl
        '
        '
        sql.AddParam("@IDFilial", IDFilial)
        Dim myQuery As String = "SELECT * FROM qryEstoqueAjusteItens WHERE IDFilial = @IDFilial AND AjusteOrigem = 2 "
        '
        If Not IsNothing(dtInicial) OrElse Not IsNothing(dtFinal) Then
            '
            myQuery = myQuery & " AND "
            '
            If Not IsNothing(dtInicial) Then
                sql.AddParam("@DataInicial", dtInicial)
                myQuery = myQuery & " AjusteData >= @DataInicial"
            End If
            '
            If Not IsNothing(dtFinal) Then
                sql.AddParam("@DataFinal", dtFinal)
                '
                If Not IsNothing(dtInicial) Then myQuery = myQuery & " AND "
                '
                myQuery = myQuery & " AjusteData <= @DataFinal"
            End If
            '
        End If
        '
        Try
            Dim iList As New List(Of clEstoqueAjusteItem)
            '
            sql.ExecQuery(myQuery)
            '
            If sql.HasException Then
                Throw New Exception(sql.Exception)
            End If
            '
            If sql.DBDT.Rows.Count = 0 Then Return iList
            '
            Return ConvertDt_clEstoqueItem(sql.DBDT)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
#End Region '/ ESTOQUE AJUSTE ITENS
    '
End Class
