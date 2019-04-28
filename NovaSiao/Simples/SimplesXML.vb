Imports System.Xml
Imports System.Reflection
Imports CamadaDTO
Imports CamadaBLL
'
Public Class SimplesXML
    '
    Private pBLL As New ProdutoBLL
    '
    '--- WRITE ALL PROPERTYS OF OBJECT IN A XML FILE
    '-----------------------------------------------------------------------------------------------
    Public Shared Sub WriteObjProperty_XML(o As Object, writer As XmlWriter)
        '
        '--- verify if object is list(of) or class
        If IsList(o) Then '--- if list then pass to all ite
            Dim iCount As Integer = DirectCast(o, IList).Count
            '
            If iCount = 0 Then Return
            '
            '--- write header of class
            ' Write the root element.
            Dim ClasseTipo As String = DirectCast(o, IList).Item(0).GetType().Name
            writer.WriteStartElement(ClasseTipo)
            '
            For i = 0 To iCount - 1
                Dim c As Object = DirectCast(o, IList).Item(i)
                '
                ' Write the root item
                writer.WriteStartElement(ClasseTipo & "-ITEM")
                writer.WriteAttributeString("Item", i + 1)
                '
                Try
                    WritePropValuesXML(c, writer)
                Catch ex As Exception
                    Throw ex
                End Try
                '
                writer.WriteEndElement()
            Next
            '
            writer.WriteEndElement()
            '
        Else
            '
            ' Write the root element.
            Dim ClasseTipo As String = o.GetType().Name
            writer.WriteStartElement(ClasseTipo)
            '
            WritePropValuesXML(o, writer)
            '
            writer.WriteEndElement()
        End If
        '
    End Sub
    '
    '--- WRITE ALL PROPERTYS VALUES IN A XML FILE
    '-----------------------------------------------------------------------------------------------
    Public Shared Sub WritePropValuesXML(minhaclasse As Object, writer As XmlWriter)
        '
        Try
            '
            For Each p As PropertyInfo In minhaclasse.GetType().GetProperties()
                '--- verify if value is money or date
                Dim myValue As String = ""
                '
                If Not IsNothing(p.GetValue(minhaclasse)) Then
                    Dim T As Type = If(Nullable.GetUnderlyingType(p.PropertyType), p.PropertyType)
                    '
                    If T Is GetType(Date) Then
                        myValue = DirectCast(p.GetValue(minhaclasse), Date).ToShortDateString
                    ElseIf T Is GetType(Decimal) OrElse T Is GetType(Double) Then
                        myValue = Format(p.GetValue(minhaclasse), "#,##0.00").ToString
                    Else
                        myValue = p.GetValue(minhaclasse).ToString
                    End If
                    '
                    If T.IsEnum Then
                        myValue = CInt(p.GetValue(minhaclasse))
                    End If
                    '
                Else
                    myValue = ""
                End If
                '
                writer.WriteElementString(p.Name, myValue)
                '
            Next
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- VERIFY IF OBJECT IS ILIST
    '-----------------------------------------------------------------------------------------------
    Public Shared Function IsList(o As Object) As Boolean
        '
        If o Is Nothing Then Return False
        Return TypeOf o Is IList AndAlso
                o.[GetType]().IsGenericType AndAlso
                o.[GetType]().GetGenericTypeDefinition().IsAssignableFrom(GetType(List(Of)))
        '
    End Function
    '
    '--- GET THE XML NODE VALUES AND FILL CLASS
    '-----------------------------------------------------------------------------------------------
    Public Sub FillClassWithNode(o As Object, myNode As XmlNode)
        '
        '--- Verifica se existe child Node
        If myNode.HasChildNodes Then
            '
            '--- Percorre por todas propertys do object
            For Each p As PropertyInfo In o.GetType().GetProperties()
                '
                '--- get Type of Property
                Dim T As Type = If(Nullable.GetUnderlyingType(p.PropertyType), p.PropertyType)
                '
                '--- Se o Tipo for ENUM convert TIPO para byte
                If T.IsEnum Then
                    T = GetType(Byte)
                End If
                '
                '--- get Value of Node
                Dim v As String = myNode.SelectSingleNode(p.Name).InnerText
                '--- convert Value to Type of
                Dim x As Object = Nothing
                '
                If Not String.IsNullOrEmpty(v) Then
                    x = Convert.ChangeType(v, T)
                End If
                '
                '--- set value in new class
                If p.CanWrite Then p.SetValue(o, x)
                '
            Next
            '
        End If
        '
    End Sub
    '
#Region "INSERE SIMPLES ENTRADA PELO XML"
    '
    '--------------------------------------------------------------------------------------------
    ' INSERT NOVA SIMPLES ENTRADA PELO ARQUIVO XML
    '--------------------------------------------------------------------------------------------
    Public Function Insert_SimplesEntrada_XML(XMLfile As String) As clSimplesEntrada
        '
        Dim doc As New XmlDocument()
        Dim nodelist As XmlNodeList
        '
        '--- Try open XML document
        Try
            doc.Load(XMLfile)
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Ler o arquivo XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Return Nothing
            '
        End Try
        '
        '--- Try Load XML classes e propertys
        Try
            '
            '--- Verifica se o ARQUIVO ja foi recebido
            '------------------------------------------------------------------
            Dim dados As XmlNode = doc.GetElementsByTagName("Dados").Item(0)
            '
            If dados.Attributes.ItemOf("Recebido").Value Then
                MessageBox.Show("Esse Arquivo XML de Simples Entrada já foi devidamente Recebido!",
                                "Arquivo Recebido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return Nothing
            End If
            '
            '--- Verifica a ORIGEM e o DESTINO da Simples Saida de Origem
            '------------------------------------------------------------------
            Dim IDFil As Integer = Obter_FilialPadrao()
            Dim nodeSS As XmlElement = doc.GetElementsByTagName("clSimplesSaida")(0)
            '
            If CInt(nodeSS.Item("IDPessoaDestino").InnerText) <> IDFil Then
                MessageBox.Show("A Filial padrão é: " & ObterDefault("FilialDescricao").ToUpper &
                                vbNewLine & vbNewLine &
                                "Esse Arquivo XML de Simples Entrada é destinado à outra Filial!",
                                "Filial Padrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return Nothing
            End If
            '
            '--- Verifica e Insere a SIMPLES SAIDA
            '------------------------------------------------------------------
            Dim _simples As New clSimplesSaida
            FillClassWithNode(_simples, nodeSS)
            '
            '--- Fill the List OF PRODUTOS
            '------------------------------------------------------------------
            nodelist = doc.GetElementsByTagName("clProduto-ITEM")
            '
            If nodelist.Count = 0 Then
                Throw New Exception("Arquivo XML corrompido...")
            End If
            '
            Dim lstProdutos As New List(Of clProduto)
            '
            For Each node As XmlElement In nodelist
                Dim _produto As New clProduto
                FillClassWithNode(_produto, node)
                '
                lstProdutos.Add(_produto)
                '
            Next
            '
            '--- Fill the List OF ITENS da SIMPLES SAIDA 
            '------------------------------------------------------------------
            nodelist = doc.GetElementsByTagName("clTransacaoItem-ITEM")
            '
            If nodelist.Count = 0 Then
                Throw New Exception("Arquivo XML corrompido...")
            End If
            '
            Dim lstItens As New List(Of clTransacaoItem)
            '
            For Each node As XmlElement In nodelist
                Dim _item As New clTransacaoItem
                FillClassWithNode(_item, node)
                '
                lstItens.Add(_item)
                '
            Next
            '
            '--- Fill the List OF APAGAR da SIMPLES SAIDA
            '------------------------------------------------------------------
            nodelist = doc.GetElementsByTagName("clAReceberParcela-ITEM")
            '
            If nodelist.Count = 0 Then
                Throw New Exception("Arquivo XML corrompido...")
            End If
            '
            Dim lstAReceber As New List(Of clAReceberParcela)
            '
            For Each node As XmlElement In nodelist
                Dim _pag As New clAReceberParcela
                FillClassWithNode(_pag, node)
                '
                lstAReceber.Add(_pag)
                '
            Next
            '
            '============================================================================
            '--- INSERTS ON BD
            '============================================================================
            '
            '--- REALIZA INSERT DOS NOVOS PRODUTOS
            '------------------------------------------------------------------
            InsertProdutos(lstProdutos)
            '
            '--- If IsNothing lstProdutos houve incompatibilidade de Produtos
            '--- cancela toda a operacao
            If IsNothing(lstProdutos) Then
                '
                Return Nothing
                '
            End If
            '
            '--- Verifica se houve alteracao nos produtos da lista pela Filial Destino
            '--- Altera os Itens da lstItens com o ID e RG da filial destino
            For Each p In lstProdutos
                Dim results As List(Of clTransacaoItem) = lstItens.FindAll(Function(x) x.Produto = p.Produto)
                '
                For Each i In results
                    i.IDProduto = p.IDProduto
                Next
                '
            Next
            '
            '
            '--- REALIZA INSERT DA SIMPLES ENTRADA
            '------------------------------------------------------------------
            Dim NewSEntrada As clSimplesEntrada = InsertSimplesEntrada(_simples)
            '
            '--- REALIZA O INSERT DOS ITENS DA SIMPLES ENTRADA
            '------------------------------------------------------------------
            If InsertItems(lstItens, NewSEntrada) = False Then
                Return Nothing
            End If
            '
            '--- REALIZA O INSERT DOS A PAGAR DA SIMPLES ENTRADA
            '------------------------------------------------------------------
            If InsertAPagar(lstAReceber, NewSEntrada) = False Then
                Return Nothing
            End If
            '
            '--- ATUALIZA O ARQUIVO XML (RECEBIDO = TRUE)
            '------------------------------------------------------------------
            dados.Attributes.ItemOf("Recebido").Value = True
            doc.Save(XMLfile)
            '
            '--- RETORNA A NOVA SIMPLES ENTRADA
            '------------------------------------------------------------------
            Return NewSEntrada
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao salvar Simples Entrada..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Return Nothing
        End Try
        '
    End Function
    '
    '--- INSERT NOVOS PRODUTOS
    '-----------------------------------------------------------------------------------------------
    Private Sub InsertProdutos(ListProdutos As List(Of clProduto))
        '
        '--- Verifica se o produto ja existe --> procurara pelo mesmo RGProduto
        '--- Se encontra entao verifica o nome do Produto
        '--- Se nome diferente entao pergunta ao user
        For Each p As clProduto In ListProdutos
            '
            Dim NewProduto As Boolean = False
            '
            NewProduto = ProcuraProdutoPeloRG(p)
            '
            '--- procura pelo cod de barra
            If NewProduto AndAlso Not String.IsNullOrEmpty(p.CodBarrasA) Then
                '
                NewProduto = ProcuraProdutoPeloCodBarras(p)
                '
            End If
            '
            '--- procura pelo mesmo Nome de Produto
            If NewProduto Then
                '
                NewProduto = ProcuraProdutoPeloProdutoNome(p)
                '
                If IsNothing(p) Then '--- nesse caso houve incompatibilidade: produto diferentes com mesmo nome
                    ListProdutos = Nothing
                    Return
                End If
                '
            End If
            '
            '--- INSERE O NOVO PRODUTO NO BD
            If NewProduto Then
                '
                Dim pTipo As New TipoSubTipoCategoriaBLL
                Dim dt As New DataTable
                Dim newID As Integer
                '
                '--- Verifica o TIPO
                Try
                    dt = pTipo.ProdutoTipo_GET_WithWhere("ProdutoTipo = " & p.ProdutoTipo)
                    '
                    If dt.Rows.Count = 0 Then '--- O TIPO não existe, INSERE NOVO TIPO
                        newID = pTipo.ProdutoTipo_Insert(p.ProdutoTipo)
                        p.IDProdutoTipo = newID
                    Else '--- O Tipo foi encontrado
                        p.IDProdutoTipo = dt.Rows(0).Item("IDProdutoTipo")
                    End If
                    '
                Catch ex As Exception
                    '
                    MessageBox.Show("Uma exceção ocorreu ao Salvar o Produto Tipo..." & vbNewLine &
                                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ListProdutos = Nothing
                    Return
                    '
                End Try
                '
                '--- Verifica o SUBTIPO
                Try
                    dt = pTipo.ProdutoSubTipo_GET_WithWhere("ProdutoSubTipo = " & p.ProdutoSubTipo)
                    '
                    If dt.Rows.Count = 0 Then '--- O SUBTIPO não existe, INSERE NOVO SUBTIPO
                        newID = pTipo.ProdutoSubTipo_Insert(p.ProdutoSubTipo, p.IDProdutoTipo)
                        p.IDProdutoSubTipo = newID
                    Else '--- O SubTipo foi encontrado
                        p.IDProdutoSubTipo = dt.Rows(0).Item("IDProdutoTipo")
                    End If
                    '
                Catch ex As Exception
                    '
                    MessageBox.Show("Uma exceção ocorreu ao Salvar o Produto SUBTipo..." & vbNewLine &
                                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ListProdutos = Nothing
                    Return
                    '
                End Try
                '
                '
                '--- Verifica a CATEGORIA
                Try
                    dt = pTipo.ProdutoCategoria_GET_WithWhere("ProdutoCategoria = " & p.ProdutoCategoria)
                    '
                    If dt.Rows.Count = 0 Then '--- O CATEGORIA não existe, INSERE NOVO CATEGORIA
                        newID = pTipo.ProdutoCategoria_Insert(p.ProdutoCategoria, p.IDProdutoTipo)
                        p.IDCategoria = newID
                    Else '--- O SubTipo foi encontrado
                        p.IDCategoria = dt.Rows(0).Item("IDCategoria")
                    End If
                    '
                Catch ex As Exception
                    '
                    MessageBox.Show("Uma exceção ocorreu ao Salvar o Produto CATEGORIA..." & vbNewLine &
                                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ListProdutos = Nothing
                    Return
                    '
                End Try
                '
                '--- SALVA O NOVO PRODUTO
                Try
                    p.IDProduto = pBLL.SalvaNovoProduto_Procedure_ID(p, Obter_FilialPadrao)
                Catch ex As Exception
                    Throw ex
                    ListProdutos = Nothing
                End Try
                '
            End If
            '
        Next
        '
    End Sub
    '
    '--- PROCURA PRODUTO COM MESMO RGPRODUTO E VERIFICA COMPATIBILIDADE
    '-----------------------------------------------------------------------------------------------
    Private Function ProcuraProdutoPeloRG(p As clProduto) As Boolean
        '
        '--- procura pelo RG
        Dim myWhere As String = "RGProduto = " & p.RGProduto
        '
        Try
            Dim lstOldProd As List(Of clProduto) = pBLL.GetProdutos_Where(myWhere)
            '
            If lstOldProd.Count > 0 Then '--- achou produto com o mesmo RG
                Dim OldProd As clProduto = lstOldProd(0)
                p.IDProduto = OldProd.IDProduto
                '
                If p.Produto = OldProd.Produto Then '--- SAME product name
                    '
                    Return False '--> NAO INSERE
                    '
                Else
                    '
                    '--- verifica o nome do produto com o usuário
                    If MessageBox.Show("Verificar produto com mesmo número de REG..." & vbNewLine & vbNewLine &
                                       "Por gentileza verifique se os dois produtos abaixo são os mesmos:" & vbNewLine &
                                       p.Produto & vbNewLine &
                                       OldProd.Produto & vbNewLine & vbNewLine &
                                       "Responda SIM se forem os mesmos produtos e NÃO se forem produtos diferentes...",
                                       "Verificar Produto",
                                       MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        '
                        Return False '--> NAO INSERE
                        '
                    Else
                        '--> produtos diferentes usando o mesmo RG!
                        '--- procura um NOVO RG possível para o NOVO produto
                        p.RGProduto = pBLL.ProcuraMaxRGProduto
                        '
                        '--> Insere produto - NOVO PRODUTO COM RG NOVO
                        Return True
                        '
                    End If
                    '
                End If
                '
            End If
            '
            Return True '--> INSERE - NOVO PRODUTO
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao verificar cadastro de produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Return False
            '
        End Try
        '
    End Function
    '
    '--- PROCURA PRODUTO COM MESMO COD.BARRAS E VERIFICA COMPATIBILIDADE
    '-----------------------------------------------------------------------------------------------
    Private Function ProcuraProdutoPeloCodBarras(p As clProduto) As Boolean
        '
        '--- procura pelo RG
        Dim myWhereCod As String = "RGProduto <> " & p.RGProduto & " AND CodBarrasA LIKE '" & p.CodBarrasA & "'"
        '
        Try
            Dim lstOldProd As List(Of clProduto) = pBLL.GetProdutos_Where(myWhereCod)
            '
            If lstOldProd.Count > 0 Then '--- achou produto com o mesmo CODBARRAS
                Dim OldProd As clProduto = lstOldProd(0)
                '
                If p.Produto <> OldProd.Produto Then '--- if not same product name
                    '
                    '--- verifica o nome do produto com o Cliente
                    If MessageBox.Show("Verificar produto com mesmo Cod. Barras..." & vbNewLine & vbNewLine &
                                       "Por gentileza verifique se os dois produtos abaixo são os mesmos:" & vbNewLine &
                                       p.Produto & vbNewLine &
                                       OldProd.Produto & vbNewLine & vbNewLine &
                                       "Responda SIM se forem os mesmos produtos e NÃO se forem produtos diferentes...",
                                       "Verificar Produto",
                                       MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        '
                        p.IDProduto = OldProd.IDProduto
                        p.RGProduto = OldProd.RGProduto
                        Return False '--> nao insere
                        '
                    Else
                        '--> produtos diferentes usando o mesmo COD BARRAS!
                        '--- Limpa O COD DE BARRAS do novo produto
                        p.CodBarrasA = Nothing
                        '
                        '--> Insere produto
                        Return True
                        '
                    End If
                    '
                Else
                    Return False '---> Nao insere
                End If
                '
            End If
            '
            Return True '--> insere
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao verificar cadastro de produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Return False
            '
        End Try
        '
    End Function
    '
    '--- PROCURA PRODUTO COM MESMO NOME/DESCRICAO E VERIFICA COMPATIBILIDADE
    '-----------------------------------------------------------------------------------------------
    Private Function ProcuraProdutoPeloProdutoNome(p As clProduto) As Boolean
        '
        '--- procura pelo RG
        Dim myWhereCod As String = "RGProduto <> " & p.RGProduto & " AND Produto = " & p.Produto
        '
        Try
            Dim lstOldProd As List(Of clProduto) = pBLL.GetProdutos_Where(myWhereCod)
            '
            If lstOldProd.Count > 0 Then '--- achou produto com o mesmo CODBARRAS
                Dim OldProd As clProduto = lstOldProd(0)
                '
                '--- verifica o nome do produto com o Cliente
                If MessageBox.Show("Verificar produto com a mesma Descrição/Nome..." & vbNewLine & vbNewLine &
                                   "Por gentileza verifique se os dois produtos abaixo são os mesmos:" & vbNewLine &
                                   "(1) " & p.Produto.ToUpper & vbNewLine &
                                   "AUTOR:" & p.Autor & vbNewLine &
                                   "TIPO:" & p.ProdutoTipo & vbNewLine &
                                   "FABRICANTE:" & p.Fabricante & vbNewLine & vbNewLine &
                                   "(2) " & OldProd.Produto.ToUpper & vbNewLine &
                                   "AUTOR:" & OldProd.Autor & vbNewLine &
                                   "TIPO:" & OldProd.ProdutoTipo & vbNewLine &
                                   "FABRICANTE:" & OldProd.Fabricante,
                                   "Verificar Produto",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    '
                    p.IDProduto = OldProd.IDProduto
                    p.RGProduto = OldProd.RGProduto
                    Return True '--> insere
                    '
                Else
                    '--> produtos diferentes usando a mesma descricao!
                    '--- nao é possivel inserir produto assim
                    '--> Nao Insere produto
                    p = Nothing
                    MessageBox.Show("Houve um erro: produtos diferentes estão usando a mesma descrição..." & vbNewLine & vbNewLine &
                                    "É necessário que haja alteração na descrição desse produto em uma das Filiais." & vbNewLine &
                                    "Favor realizar essa alteração e gerar o arquivo de transmissão novamente.",
                                    "Erro: Mesma Descrição", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                    '
                End If
                '
                '
            End If
            '
            Return True '--> insere
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao verificar cadastro de produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Return False
            '
        End Try
        '
    End Function
    '
    '--- INSERT SIMPLES ENTRADA
    '-----------------------------------------------------------------------------------------------
    Private Function InsertSimplesEntrada(_simples As clSimplesSaida) As clSimplesEntrada
        '
        Dim sBLL As New SimplesMovimentacaoBLL
        '
        Dim newSEntrada As New clSimplesEntrada With {
            .IDPessoaDestino = _simples.IDPessoaDestino,
            .IDPessoaOrigem = _simples.IDPessoaOrigem,
            .IDUser = UsuarioAtual.IdUser,
            .TransacaoData = _simples.TransacaoData,
            .EntradaData = Today(),
            .IDTransacaoOrigem = _simples.IDTransacao,
            .ValorTotal = _simples.ValorTotal
        }
        '
        Try
            newSEntrada = sBLL.InsertSimplesEntrada_Procedure_Classe(newSEntrada)
            Return newSEntrada
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
    End Function
    '
    '--- INSERT ITEMS DA SIMPLES ENTRADA
    '-----------------------------------------------------------------------------------------------
    Private Function InsertItems(ListItems As List(Of clTransacaoItem), SEntrada As clSimplesEntrada) As Boolean
        '
        Dim ItemBLL As New TransacaoItemBLL
        '
        For Each item As clTransacaoItem In ListItems
            '
            '--- cria o novo Item
            Dim newItem As New clTransacaoItem With {
                .Desconto = item.Desconto,
                .IDProduto = item.IDProduto,
                .Preco = item.Preco,
                .Quantidade = item.Quantidade,
                .IDFilial = SEntrada.IDPessoaDestino,
                .IDTransacao = SEntrada.IDTransacao
            }
            '
            '
            Dim myID As Long? = Nothing
            '
            '--- Insere o novo ITEM no BD
            Try
                myID = ItemBLL.InserirNovoItem(newItem,
                                               TransacaoItemBLL.EnumMovimento.ENTRADA,
                                               SEntrada.EntradaData,
                                               InsereCustos:=False)
                newItem.IDTransacaoItem = myID
            Catch ex As Exception
                Throw ex
                Return False
            End Try
            '
        Next
        '
        Return True
        '
    End Function
    '
    '--- INSERT A PAGAR
    '-----------------------------------------------------------------------------------------------
    Private Function InsertAPagar(ListAPagar As List(Of clAReceberParcela),
                                  _simplesEntrada As clSimplesEntrada) As Boolean
        '
        Dim pagBLL As New APagarBLL
        '
        Try
            '--- transforma cada AReceber (SimplesSaida) em APagar (SimplesEntrada)
            For Each rec As clAReceberParcela In ListAPagar
                Dim newAPagar As New clAPagar With {
                    .Origem = 4, '--> tblSimplesEntrada
                    .IDOrigem = _simplesEntrada.IDTransacao,
                    .IDPessoa = _simplesEntrada.IDPessoaOrigem,
                    .IDFilial = _simplesEntrada.IDPessoaDestino,
                    .IDCobrancaForma = 1, '--> EmCarteira
                    .Identificador = Format(rec.IDAReceber, "0000") & rec.Letra,
                    .RGBanco = Nothing,
                    .Vencimento = rec.Vencimento,
                    .APagarValor = rec.ParcelaValor,
                    .Situacao = 0,
                    .ValorPago = 0
                }
                '
                '--- Insere cada um APagar no BD
                pagBLL.InserirNovo_APagar(newAPagar)
                '
            Next
            '
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
    End Function
    '
#End Region '/ INSERE SIMPLES ENTRADA PELO XML
    '
End Class

