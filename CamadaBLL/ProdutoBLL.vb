Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient
'
'=================================================================================================================
' PRODUTO BLL
'=================================================================================================================
Public Class ProdutoBLL
    Implements IDisposable
    '
    '---------------------------------------------------------------------------------------------------------
    ' GET (LIST OF) COM FILTRO WHERE
    '---------------------------------------------------------------------------------------------------------
    Public Function GetProdutos_Where(Optional myWhere As String = "") As List(Of clProduto)
        '
        Dim db As New AcessoDados
        Dim strSql As String = ""
        '
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryProdutos"
        Else
            strSql = "SELECT * FROM qryProdutos WHERE " & myWhere
        End If
        '
        Try
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, strSql)
            Return ConvertDT_To_clProduto(dt)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' GET (LIST OF) COM ESTOQUE + FILTRO WHERE PELA FILIAL + LIMITED BY NUMBER OF RECORDS
    '---------------------------------------------------------------------------------------------------------
    Public Function GetProdutosWithEstoque_Where_Limited(IDFilial As Integer,
                                                         myWhere As String,
                                                         maxRecords As Integer,
                                                         startRecord As Integer,
                                                         ByRef countTotal As Integer,
                                                         Optional myOrder As String = ""
                                                         ) As List(Of clProduto)
        '
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDFilial", IDFilial)
        '
        Dim strSql As String = "SELECT * " &
                               ", E.EstoqueIdeal " &
                               ", E.EstoqueNivel " &
                               ", E.Quantidade AS Estoque " &
                               ", E.IDFilial " &
                               " FROM qryProdutos " &
                               " LEFT JOIN tblEstoque AS E " &
                               " ON qryProdutos.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial"
        '
        If Len(myWhere) > 0 Then
            strSql = strSql & " WHERE " & myWhere
        End If
        '
        Try
            '
            'Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, strSql)
            Dim dt As DataTable = db.ExecuteQueryLimited_Dt(strSql, startRecord, maxRecords, countTotal, myOrder)
            '
            If IsNothing(dt) Then
                Return Nothing
            End If
            '
            Return ConvertDT_To_clProduto(dt)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' COUNT PRODUTOS FILTRO WHERE PELA FILIAL
    '---------------------------------------------------------------------------------------------------------
    Public Function CountProdutos_Where(Optional myWhere As String = "") As Integer
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = "SELECT COUNT(*) FROM tblProduto"
        '
        If Len(myWhere) > 0 Then
            strSql = strSql & " WHERE " & myWhere
        End If
        '
        Try
            '
            Dim DT As DataTable = objdb.ExecutarConsulta(CommandType.Text, strSql)
            '
            If DT.Rows.Count > 0 Then
                Return DT.Rows(0).Item(0)
            Else
                Return 0
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' GET DATA TABLE E RETURN LIST OF CLPRODUTO
    '---------------------------------------------------------------------------------------------------------
    Public Function ConvertDT_To_clProduto(dt As DataTable) As List(Of clProduto)
        '
        Dim lstProd As New List(Of clProduto)
        Dim incluirEstoque As Boolean = False
        '
        If dt.Columns.IndexOf("Estoque") <> -1 Then
            incluirEstoque = True
        End If
        '
        If dt.Rows.Count = 0 Then Return lstProd
        '
        For Each r As DataRow In dt.Rows

            Dim prod As New clProduto With {
                .IDProduto = IIf(IsDBNull(r("IDProduto")), 0, r("IDProduto")),
                .RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto")),
                .Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto")),
                .IDFabricante = IIf(IsDBNull(r("IDFabricante")), Nothing, r("IDFabricante")),
                .Fabricante = IIf(IsDBNull(r("Fabricante")), String.Empty, r("Fabricante")),
                .IDProdutoTipo = IIf(IsDBNull(r("IDProdutoTipo")), Nothing, r("IDProdutoTipo")),
                .ProdutoTipo = IIf(IsDBNull(r("ProdutoTipo")), String.Empty, r("ProdutoTipo")),
                .IDProdutoSubTipo = IIf(IsDBNull(r("IDProdutoSubTipo")), Nothing, r("IDProdutoSubTipo")),
                .ProdutoSubTipo = IIf(IsDBNull(r("ProdutoSubTipo")), String.Empty, r("ProdutoSubTipo")),
                .IDCategoria = IIf(IsDBNull(r("IDCategoria")), Nothing, r("IDCategoria")),
                .ProdutoCategoria = IIf(IsDBNull(r("ProdutoCategoria")), String.Empty, r("ProdutoCategoria")),
                .Autor = IIf(IsDBNull(r("Autor")), String.Empty, r("Autor")),
                .Unidade = IIf(IsDBNull(r("Unidade")), 1, r("Unidade")),
                .PCompra = IIf(IsDBNull(r("PCompra")), 0, r("PCompra")),
                .DescontoCompra = IIf(IsDBNull(r("DescontoCompra")), Nothing, r("DescontoCompra")),
                .PVenda = IIf(IsDBNull(r("PVenda")), 0, r("PVenda")),
                .ProdutoAtivo = IIf(IsDBNull(r("ProdutoAtivo")), Nothing, r("ProdutoAtivo")),
                .SitTributaria = IIf(IsDBNull(r("SitTributaria")), Nothing, r("SitTributaria")),
                .SituacaoTributaria = IIf(IsDBNull(r("SituacaoTributaria")), String.Empty, r("SituacaoTributaria")),
                .NCM = IIf(IsDBNull(r("NCM")), String.Empty, r("NCM")),
                .UltAltera = IIf(IsDBNull(r("UltAltera")), Nothing, r("UltAltera")),
                .EntradaData = IIf(IsDBNull(r("EntradaData")), Nothing, r("EntradaData")),
                .CodBarrasA = IIf(IsDBNull(r("CodBarrasA")), String.Empty, r("CodBarrasA")),
                .Movimento = IIf(IsDBNull(r("Movimento")), Nothing, r("Movimento")),
                .MovimentoDescricao = IIf(IsDBNull(r("MovimentoDescricao")), String.Empty, r("MovimentoDescricao"))
            }
            '
            If incluirEstoque Then
                prod.Estoque = IIf(IsDBNull(r("Estoque")), 0, r("Estoque"))
                prod.EstoqueNivel = IIf(IsDBNull(r("EstoqueNivel")), 0, r("EstoqueNivel"))
                prod.EstoqueIdeal = IIf(IsDBNull(r("EstoqueIdeal")), 0, r("EstoqueIdeal"))
            End If
            '
            lstProd.Add(prod)
            '
        Next
        '
        Return lstProd
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' GET REGISTRO POR ID/RG
    '---------------------------------------------------------------------------------------------------------
    Public Function GetProduto_PorID(IDProduto As Integer, IDFilial As Integer) As clProduto
        Dim objdb As New AcessoDados
        Dim dt As DataTable
        '
        objdb.LimparParametros()
        objdb.AdicionarParametros("@IDProduto", IDProduto)
        objdb.AdicionarParametros("@IDFilial", IDFilial)
        '
        Dim query As String = "SELECT P.*, E.Quantidade AS Estoque, E.EstoqueNivel, E.EstoqueIdeal " +
                              "FROM qryProdutos AS P " +
                              "LEFT JOIN tblEstoque AS E " +
                              "ON E.IDProduto = P.IDProduto AND E.IDFilial = @IDFilial " +
                              "WHERE P.IDProduto = @IDProduto"
        '
        Try
            dt = objdb.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then
                Return New clProduto
            Else
                Return ConvertDT_To_clProduto(dt)(0)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' GET PRODUTO DADOS PELO RGPRODUTO
    '---------------------------------------------------------------------------------------------------------
    Public Function GetProduto_PorRG(RGProduto As Integer, IDFilial As Integer) As clProduto
        '
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        db.AdicionarParametros("@RGProduto", RGProduto)
        db.AdicionarParametros("@IDFilial", IDFilial)
        '
        Dim query As String = "SELECT P.*, E.Quantidade, E.EstoqueNivel, E.EstoqueIdeal " +
                              "FROM qryProdutos AS P " +
                              "LEFT JOIN tblEstoque AS E " +
                              "ON E.IDProduto = P.IDProduto AND E.IDFilial = @IDFilial " +
                              "WHERE P.RGProduto = @RGProduto"
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return ConvertDT_To_clProduto(dt)(0)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '=================================================================================================================
    ' GET LISTA PRODUTOS DE UMA TRANSACAO
    '=================================================================================================================
    Public Function GetProdutosLista_Transacao(IDTransacao As Integer) As List(Of clProduto)
        '
        Return GetProdutos_Where("IDProduto IN (SELECT IDProduto FROM tblTransacaoItens WHERE IDTransacao = " & IDTransacao & ")")
        '
    End Function
    '
    '=================================================================================================================
    ' UPDATE
    '=================================================================================================================
    Public Function AtualizaProduto_Procedure_ID(ByVal _prod As clProduto, _filial As Integer) As Integer
        '
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand
        '
        'PARAMETROS DA TBLPRODUTO
        Conn.Parameters.Add(New SqlParameter("@IDProduto", _prod.IDProduto))
        Conn.Parameters.Add(New SqlParameter("@RGProduto", _prod.RGProduto))
        Conn.Parameters.Add(New SqlParameter("@Produto", _prod.Produto))
        Conn.Parameters.Add(New SqlParameter("@CodBarrasA", _prod.CodBarrasA))
        Conn.Parameters.Add(New SqlParameter("@IDFabricante", _prod.IDFabricante))
        Conn.Parameters.Add(New SqlParameter("@IDProdutoTipo", _prod.IDProdutoTipo))
        Conn.Parameters.Add(New SqlParameter("@IDProdutoSubTipo", _prod.IDProdutoSubTipo))
        Conn.Parameters.Add(New SqlParameter("@IDCategoria", _prod.IDCategoria))
        Conn.Parameters.Add(New SqlParameter("@Autor", _prod.Autor))
        Conn.Parameters.Add(New SqlParameter("@Unidade", _prod.Unidade))
        Conn.Parameters.Add(New SqlParameter("@PCompra", _prod.PCompra))
        Conn.Parameters.Add(New SqlParameter("@DescontoCompra", _prod.DescontoCompra))
        Conn.Parameters.Add(New SqlParameter("@PVenda", _prod.PVenda))
        Conn.Parameters.Add(New SqlParameter("@ProdutoAtivo", _prod.ProdutoAtivo))
        Conn.Parameters.Add(New SqlParameter("@SitTributaria", _prod.SitTributaria))
        Conn.Parameters.Add(New SqlParameter("@NCM", _prod.NCM))
        Conn.Parameters.Add(New SqlParameter("@UltAltera", _prod.UltAltera))
        Conn.Parameters.Add(New SqlParameter("@EntradaData", _prod.EntradaData))
        Conn.Parameters.Add(New SqlParameter("@Movimento", _prod.Movimento))
        '
        ' PARAMETROS DA TBLESTOQUE
        Conn.Parameters.Add(New SqlParameter("@EstoqueNivel", _prod.EstoqueNivel))
        Conn.Parameters.Add(New SqlParameter("@EstoqueIdeal", _prod.EstoqueIdeal))
        Conn.Parameters.Add(New SqlParameter("@IDFilial", _filial))
        '
        Try
            Dim strReturn As String = objDB.ExecuteProcedureID("uspProduto_Alterar", Conn.Parameters)
            If IsNumeric(strReturn) Then
                Return CInt(strReturn)
            Else
                Throw New Exception(strReturn)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    '
    '=================================================================================================================
    ' INSERT
    '=================================================================================================================
    Public Function SalvaNovoProduto_Procedure_ID(ByVal _prod As clProduto, _filial As Integer) As Long
        '
        Dim objDB As New AcessoDados
        Dim Conn As New SqlCommand

        'Adiciona os Parâmetros
        Conn.Parameters.Add(New SqlParameter("@RGProduto", _prod.RGProduto))
        Conn.Parameters.Add(New SqlParameter("@Produto", _prod.Produto))
        Conn.Parameters.Add(New SqlParameter("@CodBarrasA", _prod.CodBarrasA))
        Conn.Parameters.Add(New SqlParameter("@IDFabricante", _prod.IDFabricante))
        Conn.Parameters.Add(New SqlParameter("@IDProdutoTipo", _prod.IDProdutoTipo))
        Conn.Parameters.Add(New SqlParameter("@IDProdutoSubTipo", _prod.IDProdutoSubTipo))
        Conn.Parameters.Add(New SqlParameter("@IDCategoria", _prod.IDCategoria))
        Conn.Parameters.Add(New SqlParameter("@Autor", _prod.Autor))
        Conn.Parameters.Add(New SqlParameter("@Unidade", _prod.Unidade))
        Conn.Parameters.Add(New SqlParameter("@PCompra", _prod.PCompra))
        Conn.Parameters.Add(New SqlParameter("@DescontoCompra", _prod.DescontoCompra))
        Conn.Parameters.Add(New SqlParameter("@PVenda", _prod.PVenda))
        Conn.Parameters.Add(New SqlParameter("@ProdutoAtivo", _prod.ProdutoAtivo))
        Conn.Parameters.Add(New SqlParameter("@SitTributaria", _prod.SitTributaria))
        Conn.Parameters.Add(New SqlParameter("@NCM", _prod.NCM))
        Conn.Parameters.Add(New SqlParameter("@UltAltera", _prod.UltAltera))
        Conn.Parameters.Add(New SqlParameter("@EntradaData", _prod.EntradaData))
        Conn.Parameters.Add(New SqlParameter("@Movimento", _prod.Movimento))
        '
        ' PARAMETROS DA TBLESTOQUE
        Conn.Parameters.Add(New SqlParameter("@EstoqueNivel", _prod.EstoqueNivel))
        Conn.Parameters.Add(New SqlParameter("@EstoqueIdeal", _prod.EstoqueIdeal))
        Conn.Parameters.Add(New SqlParameter("@IDFilial", _filial))
        '
        Try
            '
            Dim obj As Object = objDB.ExecuteProcedureID("uspProduto_Inserir", Conn.Parameters)
            '
            If Not IsNothing(obj) AndAlso IsNumeric(obj) Then
                Return obj
            Else
                Throw New Exception(obj)
            End If
            '
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
    End Function
    '
    '=================================================================================================================
    ' PROCURAR PRODUTO DO FRMPROCURAR PRODUTO
    '=================================================================================================================
    Public Function ProdutoProcurar(myFilial As Integer,
                                    myTipo As Integer?,
                                    mySubTipo As Integer?,
                                    myAtivo As Boolean?,
                                    myComEstoque As Boolean?,
                                    myDescricao As String) As List(Of clProduto)
        '
        Dim db As New AcessoDados
        Dim WhereOn As Boolean = False
        '
        db.LimparParametros()
        '
        '--- CRIA A QUERY
        '-----------------------------------------------------------------------------------
        Dim myQuery As String =
            "SELECT " &
            "P.IDProduto, P.RGProduto, P.Produto, P.Autor, " &
            "P.IDProdutoTipo, P.IDProdutoSubTipo, P.PVenda, " &
            "P.DescontoCompra, P.PCompra, P.ProdutoAtivo, " &
            "E.Quantidade As Estoque, E.Reservado " &
            "FROM tblProduto As P " &
            "LEFT JOIN tblEstoque As E " &
            "ON P.IDProduto = E.IDProduto AND E.IDFilial = @IDFilial"
        '
        db.AdicionarParametros("@IDFilial", myFilial)
        '
        If Not IsNothing(myTipo) Then
            db.AdicionarParametros("@IDProdutoTipo", myTipo)
            myQuery = myQuery + IIf(WhereOn, " And ", " WHERE ") + "IDProdutoTipo = @IDProdutoTipo"
            WhereOn = True
        End If
        '
        If Not IsNothing(mySubTipo) Then
            db.AdicionarParametros("@IDProdutoSubTipo", mySubTipo)
            myQuery = myQuery + IIf(WhereOn, " And ", " WHERE ") + "IDProdutoSubTipo = @IDProdutoSubTipo"
            WhereOn = True
        End If
        '
        If myAtivo Then
            db.AdicionarParametros("@ProdutoAtivo", myAtivo)
            myQuery = myQuery + IIf(WhereOn, " And ", " WHERE ") + "ProdutoAtivo = @ProdutoAtivo"
            WhereOn = True
        End If
        '
        If myComEstoque Then
            myQuery = myQuery + IIf(WhereOn, " And ", " WHERE ") + "E.Quantidade > 0"
            WhereOn = True
        End If
        '
        If myDescricao.Trim.Length > 0 Then
            db.AdicionarParametros("@Descricao", myDescricao.Trim)
            myQuery = myQuery + IIf(WhereOn, " And ", " WHERE ") + "Produto Like '%'+@Descricao+'%' "
            myQuery = myQuery + "OR Autor LIKE '%'+@Descricao+'%'"
        End If
        '
        '--- Order By
        myQuery = myQuery + " ORDER BY Produto"
        '
        '--- Execute select query
        '-----------------------------------------------------------------------------------
        Try
            Dim pList As New List(Of clProduto)
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            For Each r As DataRow In dt.Rows
                Dim p As New clProduto
                '
                p.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
                p.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
                p.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
                p.Autor = IIf(IsDBNull(r("Autor")), String.Empty, r("Autor"))
                p.IDProdutoTipo = IIf(IsDBNull(r("IDProdutoTipo")), Nothing, r("IDProdutoTipo"))
                p.IDProdutoSubTipo = IIf(IsDBNull(r("IDProdutoSubTipo")), Nothing, r("IDProdutoSubTipo"))
                p.PVenda = IIf(IsDBNull(r("PVenda")), Nothing, r("PVenda"))
                p.PCompra = IIf(IsDBNull(r("PCompra")), Nothing, r("PCompra"))
                p.DescontoCompra = IIf(IsDBNull(r("DescontoCompra")), Nothing, r("DescontoCompra"))
                p.ProdutoAtivo = IIf(IsDBNull(r("ProdutoAtivo")), Nothing, r("ProdutoAtivo"))
                p.Estoque = IIf(IsDBNull(r("Estoque")), Nothing, r("Estoque"))
                '
                pList.Add(p)
            Next
            '
            Return pList
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' RETORNA UMA DATATABLE DE AUTORES DE PRODUTOS
    '-----------------------------------------------------------------------------------------------------------------
    Public Function GetAutoresLista() As DataTable
        Dim db As New AcessoDados
        Dim sql As String
        '
        sql = "SELECT AUTOR, COUNT(Autor) AS Quantidade FROM tblProduto WHERE Autor <> '' GROUP BY Autor ORDER BY Autor "
        '
        Try
            Return db.ExecutarConsulta(CommandType.Text, sql)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' RETORNA UMA DATATABLE DE FABRICANTES DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function GetFabricantes(Optional Ativo As Boolean? = Nothing) As DataTable
        '
        Dim SQL As New SQLControl
        '
        Dim strSQL As String = "SELECT * FROM tblProdutoFabricante"
        '
        If Not Ativo Is Nothing Then
            strSQL = strSQL & " WHERE FabricanteAtivo = '" & CBool(Ativo).ToString & "'"
        End If
        '
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' RETORNA UMA DATATABLE DE SITUACAO TRIBUTARIA DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function GetSituacao() As DataTable
        '
        Dim SQL As New SQLControl
        '
        Dim strSQL As String = "SELECT * FROM tblProdutoSituacaoTributaria"
        '
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' BUSCA UM NOVO NUMERO DE REGISTRO RGPRODUTO VALIDO NA BASE DE DADOS
    '---------------------------------------------------------------------------------------------------------
    Public Function ProcuraMaxRGProduto() As Integer?
        '
        Dim SQL As New SQLControl
        '
        Try
            '--- Get MaxRGInterno
            Dim maxRGint As Integer = ProcuraMaxRGProduto_Interno()
            '
            '--- check if exists X_tblProdutos (TABELA ANTIGA)
            Dim sqlstr As String = "SELECT OBJECT_ID('X_tblProdutos') AS RETORNO"
            SQL.ExecQuery(sqlstr)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If Not IsDBNull(SQL.DBDT.Rows(0)("RETORNO")) Then '--- procura na X_TBLPRODUTOS
                SQL.ExecQuery("SELECT MAX(RGProduto) FROM X_tblProdutos")
                '
                If SQL.HasException(True) Then
                    Throw New Exception(SQL.Exception)
                End If
                '
                If SQL.RecordCount = 0 Then Return maxRGint
                '
                Dim r As DataRow = SQL.DBDT.Rows(0)
                '
                If IsDBNull(r(0)) OrElse Not IsNumeric(r(0)) Then
                    Return maxRGint
                Else
                    '--- Check which one is biggest
                    If maxRGint > r(0) Then
                        Return maxRGint
                    Else
                        Return r(0)
                    End If
                    '
                End If
                '
            Else '--- procura na TBLPRODUTO
                Return maxRGint
            End If
            '
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' BUSCA UM NOVO NUMERO DE REGISTRO RGPRODUTO VALIDO NA BASE DE DADOS
    '---------------------------------------------------------------------------------------------------------
    Public Function ProcuraMaxRGProduto_Interno() As Integer
        '
        Dim SQL As New SQLControl
        '
        Try
            SQL.ExecQuery("SELECT MAX(RGProduto) FROM tblProduto")
            '
            If SQL.HasException(True) Then
                Return Nothing
            End If
            '
            If SQL.RecordCount > 0 Then
                Dim r As DataRow = SQL.DBDT.Rows(0)
                If Not IsDBNull(r(0)) Then
                    Return r(0)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' ATIVA | DESATIVA O PRODUTO INFORMADO
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoAtivarDesativar(IDProduto As Integer, Ativar As Boolean) As Object
        '
        Dim SQL As New SQLControl
        Dim mySQL As String = ""
        '
        If Ativar = True Then
            mySQL = "UPDATE tblProduto SET ProdutoAtivo = 'TRUE' WHERE IDProduto = " & IDProduto
        Else
            mySQL = "UPDATE tblProduto SET ProdutoAtivo = 'FALSE' WHERE IDProduto = " & IDProduto
        End If
        '
        Try
            SQL.ExecQuery(mySQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' ALTERA O FABRICANTE DO PRODUTO INFORMADO
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoAlterarFabricante(IDProduto As Integer, newIDFabricante As Integer) As Object
        '
        Dim SQL As New SQLControl
        Dim mySQL As String = ""
        '
        mySQL = "UPDATE tblProduto SET IDFabricante = " & newIDFabricante & " WHERE IDProduto = " & IDProduto
        '
        Try
            SQL.ExecQuery(mySQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' ALTERA O TIPO | SUBTIPO DO PRODUTO INFORMADO
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoAlterarTipoSubTipo(IDProduto As Integer,
                                              newIDTipo As Integer,
                                              newIDSubTipo As Integer,
                                              LimparCategoria As Boolean) As Object
        '
        Dim SQL As New SQLControl
        Dim mySQL As String = ""
        '
        mySQL = "UPDATE tblProduto SET IDProdutoTipo = " & newIDTipo & ", IDProdutoSubTipo = " & newIDSubTipo
        '
        If LimparCategoria = True Then
            mySQL = mySQL & ", IDCategoria = NULL"
        End If
        '
        mySQL = mySQL & " WHERE IDProduto = " & IDProduto

        '
        Try
            SQL.ExecQuery(mySQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' ALTERA A CATEGORIA DO PRODUTO INFORMADO
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoAlterarCategoria(IDProduto As Integer, newIDCategoria As Integer) As Object
        '
        Dim SQL As New SQLControl
        Dim mySQL As String = ""
        '
        mySQL = "UPDATE tblProduto SET IDCategoria = " & newIDCategoria & " WHERE IDProduto = " & IDProduto
        '
        Try
            SQL.ExecQuery(mySQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' ALTERA O ESTOQUE MINIMO E IDEAL DO PRODUTO E FILIAL INFORMADOS
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoAlterarEstoqueMinimoIdeal(IDProduto As Integer,
                                                     IDFilial As Integer,
                                                     newEstMinimo As Integer?,
                                                     newEstIdeal As Integer?) As Object
        '
        Dim SQL As New SQLControl
        Dim mySQL As String = ""
        '
        If Not IsNothing(newEstIdeal) AndAlso Not IsNothing(newEstMinimo) Then
            mySQL = "UPDATE tblEstoque SET" &
                " EstoqueNivel = " & newEstMinimo &
                ", EstoqueIdeal = " & newEstIdeal &
                " WHERE IDProduto = " & IDProduto &
                " AND IDFilial = " & IDFilial
        ElseIf IsNothing(newEstIdeal) Then
            mySQL = "UPDATE tblEstoque SET" &
                " EstoqueNivel = " & newEstMinimo &
                " WHERE IDProduto = " & IDProduto &
                " AND IDFilial = " & IDFilial
        ElseIf IsNothing(newEstMinimo) Then
            mySQL = "UPDATE tblEstoque SET" &
                " EstoqueIdeal = " & newEstIdeal &
                " WHERE IDProduto = " & IDProduto &
                " AND IDFilial = " & IDFilial
        End If
        '
        Try
            SQL.ExecQuery(mySQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' ALTERA O PRECO DE COMPRA E/OU DESCONTO DE COMPRA DO PRODUTO INFORMADO
    '---------------------------------------------------------------------------------------------------------
    Public Function ProdutoAlterarPrecoDescontoCompra(IDProduto As Integer,
                                                      Optional newPrecoCompra? As Double = Nothing,
                                                      Optional newDescontoCompra? As Double = Nothing) As Object
        '
        Dim db As New AcessoDados
        Dim myQuery As String = "UPDATE tblProduto SET "
        '
        db.LimparParametros()
        '
        If Not IsNothing(newPrecoCompra) AndAlso Not IsNothing(newDescontoCompra) Then
            '
            db.AdicionarParametros("@PrecoCompra", newPrecoCompra)
            db.AdicionarParametros("@DescontoCompra", newDescontoCompra)
            '
            myQuery += "PCompra = @PrecoCompra" &
                       ", DescontoCompra = @DescontoCompra"
            '
        ElseIf IsNothing(newDescontoCompra) Then
            '
            db.AdicionarParametros("@PrecoCompra", newPrecoCompra)
            '
            myQuery += "PCompra = @PrecoCompra"
            '
        ElseIf IsNothing(newPrecoCompra) Then
            '
            db.AdicionarParametros("@DescontoCompra", newDescontoCompra)
            '
            myQuery += "DescontoCompra = @DescontoCompra"
            '
        End If
        '
        db.AdicionarParametros("@IDProduto", IDProduto)
        myQuery += " WHERE IDProduto = @IDProduto"
        '
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' dispose managed state (managed objects).
            End If

            ' free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' uncomment the following line if Finalize() is overridden above.
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    '
End Class
'
'
'*****************************************************************************************************************
'*****************************************************************************************************************
'
'=================================================================================================================
' PRODUTO ETIQUETA BLL
'=================================================================================================================
Public Class ProdutoEtiquetaBLL
    '
    Private db As AcessoDados
    '
    Sub New()
        db = New AcessoDados
    End Sub
    '
    '---------------------------------------------------------------------------------------------------------
    ' GET LISTA DE ETIQUETAS DO BD | RETURN LIST
    '---------------------------------------------------------------------------------------------------------
    Public Function Get_Etiquetas() As List(Of clProdutoEtiqueta)
        Dim lstEtiq As New List(Of clProdutoEtiqueta)
        '
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, "SELECT * FROM qryProdutoEtiqueta")
            '
            For Each r As DataRow In dt.Rows
                Dim e As New clProdutoEtiqueta
                '
                e.IDEtiqueta = IIf(IsDBNull(r("IDEtiqueta")), Nothing, r("IDEtiqueta"))
                e.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
                e.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
                e.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
                e.ProdutoTipo = IIf(IsDBNull(r("ProdutoTipo")), String.Empty, r("ProdutoTipo"))
                e.ProdutoSubTipo = IIf(IsDBNull(r("ProdutoSubTipo")), String.Empty, r("ProdutoSubTipo"))
                e.PVenda = IIf(IsDBNull(r("PVenda")), Nothing, r("PVenda"))
                e.Quantidade = IIf(IsDBNull(r("Quantidade")), Nothing, r("Quantidade"))
                e.PrecoVenda = IIf(IsDBNull(r("PrecoVenda")), Nothing, r("PrecoVenda"))
                e.PrecoPromocao = IIf(IsDBNull(r("PrecoPromocao")), Nothing, r("PrecoPromocao"))
                e.CodBarrasA = IIf(IsDBNull(r("CodBarrasA")), String.Empty, r("CodBarrasA"))
                '
                lstEtiq.Add(e)
            Next
            '
            Return lstEtiq
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' INSERT NOVO ITEM OU ALTERAR A ETIQUETA NO BD
    '---------------------------------------------------------------------------------------------------------
    Public Function InserirAlterar_EtiquetaItem(myEtiq As clProdutoEtiqueta) As clProdutoEtiqueta
        '
        '-- limpa e adiciona os parametros
        db.LimparParametros()
        '
        db.AdicionarParametros("@RGProduto", myEtiq.RGProduto)
        db.AdicionarParametros("@Quantidade", IIf(IsNothing(myEtiq.Quantidade), 1, myEtiq.Quantidade))
        '
        If Not IsNothing(myEtiq.PrecoPromocao) Then
            db.AdicionarParametros("@PrecoPromocao", myEtiq.PrecoPromocao)
        End If
        '
        If Not IsNothing(myEtiq.IDEtiqueta) Then
            db.AdicionarParametros("@IDEtiqueta", myEtiq.IDEtiqueta)
        End If
        '
        '-- insere altera a etiqueta retorna um clEtiqueta
        Try
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoEtiqueta_InserirAlterarItem")
            '
            If dt.Rows.Count = 0 Then
                Throw New Exception("Não retornou nenhum valor")
            End If
            '
            Dim e As New clProdutoEtiqueta
            Dim r As DataRow = dt.Rows(0)
            '
            If Not IsNumeric(r.Item(0)) Then
                Return e
            End If
            '
            e.IDEtiqueta = IIf(IsDBNull(r("IDEtiqueta")), Nothing, r("IDEtiqueta"))
            e.IDProduto = IIf(IsDBNull(r("IDProduto")), Nothing, r("IDProduto"))
            e.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
            e.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
            e.ProdutoTipo = IIf(IsDBNull(r("ProdutoTipo")), String.Empty, r("ProdutoTipo"))
            e.ProdutoSubTipo = IIf(IsDBNull(r("ProdutoSubTipo")), String.Empty, r("ProdutoSubTipo"))
            e.PVenda = IIf(IsDBNull(r("PVenda")), Nothing, r("PVenda"))
            e.Quantidade = IIf(IsDBNull(r("Quantidade")), Nothing, r("Quantidade"))
            e.PrecoVenda = IIf(IsDBNull(r("PrecoVenda")), Nothing, r("PrecoVenda"))
            e.PrecoPromocao = IIf(IsDBNull(r("PrecoPromocao")), Nothing, r("PrecoPromocao"))
            e.CodBarrasA = IIf(IsDBNull(r("CodBarrasA")), String.Empty, r("CodBarrasA"))
            '
            '-- retorna clEtiqueta
            Return e
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------------------
    ' INSERT ETIQUETAS DE UMA TRANSACAO | COMPRA NO BD
    '---------------------------------------------------------------------------------------------------------
    Public Sub Insert_EtiquetasTransacao(IDTransacao As Integer)
        Dim obj As Object
        '
        db.LimparParametros()
        db.AdicionarParametros("@IDTransacao", IDTransacao)
        '
        Try
            obj = db.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoEtiqueta_InserirTransacao")
            '
            If Not IsNumeric(obj) Then
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------------------------
    ' DELETE ITEM DE ETIQUETA NO BD
    '---------------------------------------------------------------------------------------------------------
    Public Sub Delete_Etiquetas(IDProduto As Integer)
        Try
            Dim strSQL As String = "DELETE tblProdutoEtiqueta WHERE IDProduto = " & IDProduto
            '
            db.ExecutarManipulacao(CommandType.Text, strSQL)
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
    '---------------------------------------------------------------------------------------------------------
    ' DELETE LIMPA TODA LISTAGEM DE ETIQUETAS DO BD
    '---------------------------------------------------------------------------------------------------------
    Public Sub Delete_Etiquetas()
        Try
            Dim strSQL As String = "DELETE tblProdutoEtiqueta"
            '
            db.ExecutarManipulacao(CommandType.Text, strSQL)
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
    '---------------------------------------------------------------------------------------------------------
    ' OBTER A LISTA DOS RELATORIOS DE ETIQUETA
    '---------------------------------------------------------------------------------------------------------
    Public Function Get_ProdutoEtiquetaRelatorios() As DataTable
        Try
            Dim strSQL As String = "SELECT * FROM tblProdutoEtiquetaRelatorio"
            '
            Return db.ExecutarConsulta(CommandType.Text, strSQL)
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
End Class
'
'
'*****************************************************************************************************************
'*****************************************************************************************************************
'
'=================================================================================================================
' PRODUTO TIPO SUBTIPO CATEGORIA
'=================================================================================================================
Public Class TipoSubTipoCategoriaBLL
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' GET TIPOS WITH WHERE DATATABLE
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoTipo_GET_WithWhere(Optional myWhere As String = "") As DataTable
        '
        Dim SQL As New SQLControl
        Dim myQuery As String = "SELECT * FROM tblProdutoTipo "
        '
        If myWhere.Length > 0 Then
            myQuery = myQuery & " WHERE " & myWhere
        End If
        '
        Try
            SQL.ExecQuery(myQuery, True)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' INSERE NOVO TIPO DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoTipo_Insert(ProdutoTipo As String) As Integer
        '
        Dim SQL As New SQLControl
        Dim newID As Integer
        Dim myQuery As String = "INSERT INTO tblProdutoTipo" &
                                " (ProdutoTipo, Ativo) VALUES (@ProdutoTipo, 'TRUE')"
        '
        SQL.AddParam("@ProdutoTipo", ProdutoTipo)
        '
        Try
            SQL.ExecQuery(myQuery, True)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount > 0 Then
                newID = SQL.DBDT.Rows(0).Item(0)
                Return newID
            Else
                Return Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' ALTERA TIPO DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoTipo_Update(IDProdutoTipo As Integer, ProdutoTipo As String, Ativo As Boolean) As Boolean
        '
        Dim SQL As New SQLControl
        Dim myQuery As String = "UPDATE tblProdutoTipo " &
                                "SET ProdutoTipo = @ProdutoTipo, " &
                                " Ativo = @Ativo" &
                                " WHERE IDProdutoTipo = @IDProdutoTipo"
        '
        SQL.AddParam("@ProdutoTipo", ProdutoTipo)
        SQL.AddParam("@Ativo", Ativo)
        SQL.AddParam("@IDProdutoTipo", IDProdutoTipo)
        '
        Try
            SQL.ExecQuery(myQuery)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' GET SUBTIPOS WITH WHERE DATATABLE
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoSubTipo_GET_WithWhere(Optional myWhere As String = "") As DataTable
        '
        Dim SQL As New SQLControl
        Dim myQuery As String = "SELECT * FROM tblProdutoSubTipo "
        '
        If myWhere.Length > 0 Then
            myQuery = myQuery & " WHERE " & myWhere
        End If
        '
        Try
            SQL.ExecQuery(myQuery, True)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' INSERE NOVO SUBTIPO DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoSubTipo_Insert(SubTipo As String, IDTipo As Integer) As Integer
        '
        Dim SQL As New SQLControl
        Dim newID As Integer
        Dim myQuery As String = "INSERT INTO tblProdutoSubTipo (ProdutoSubTipo, IDProdutoTipo, Ativo) " &
                                "VALUES (@SubTipo, @IDTipo, 'TRUE')"
        '
        SQL.AddParam("@IDTipo", IDTipo)
        SQL.AddParam("@SubTipo", SubTipo)
        '
        Try
            SQL.ExecQuery(myQuery, True)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount > 0 Then
                newID = SQL.DBDT.Rows(0).Item(0)
                Return newID
            Else
                Return Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' ALTERA SUBTIPO DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoSubTipo_Update(IDSubTipo As Integer, SubTipo As String, Ativo As Boolean) As Boolean
        '
        Dim SQL As New SQLControl
        Dim myQuery As String = "UPDATE tblProdutoSubTipo " &
                                "SET ProdutoSubTipo = @SubTipo, " &
                                " Ativo = @Ativo" &
                                " WHERE IDProdutoSubTipo = @IDSubTipo"
        '
        SQL.AddParam("@SubTipo", SubTipo)
        SQL.AddParam("@Ativo", Ativo)
        SQL.AddParam("@IDSubTipo", IDSubTipo)
        '
        Try
            SQL.ExecQuery(myQuery)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' GET CATEGORIAS WITH WHERE DATATABLE
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoCategoria_GET_WithWhere(Optional myWhere As String = "") As DataTable
        '
        Dim SQL As New SQLControl
        Dim myQuery As String = "SELECT * FROM tblProdutoCategoria "
        '
        If myWhere.Length > 0 Then
            myQuery = myQuery & " WHERE " & myWhere
        End If
        '
        Try
            SQL.ExecQuery(myQuery, True)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' INSERE NOVA CATEGORIA DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoCategoria_Insert(Categoria As String, IDTipo As Integer) As Integer
        '
        Dim SQL As New SQLControl
        Dim newID As Integer
        Dim myQuery As String = "INSERT INTO tblProdutoCategoria (ProdutoCategoria, IDProdutoTipo, Ativo) " &
                                "VALUES (@Categoria, @IDTipo, 'TRUE')"
        '
        SQL.AddParam("@IDTipo", IDTipo)
        SQL.AddParam("@Categoria", Categoria)
        '
        Try
            SQL.ExecQuery(myQuery, True)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            End If
            '
            If SQL.RecordCount > 0 Then
                newID = SQL.DBDT.Rows(0).Item(0)
                Return newID
            Else
                Return Nothing
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' ALTERA CATEGORIA DE PRODUTO
    '-----------------------------------------------------------------------------------------------------------------
    Public Function ProdutoCategoria_Update(IDCategoria As Integer, Categoria As String, Ativo As Boolean) As Boolean
        '
        Dim SQL As New SQLControl
        Dim myQuery As String = "UPDATE tblProdutoCategoria" &
                                " SET ProdutoCategoria = @Categoria, " &
                                " Ativo = @Ativo" &
                                " WHERE IDCategoria = @IDCategoria"
        '
        SQL.AddParam("@Categoria", Categoria)
        SQL.AddParam("@Ativo", Ativo)
        SQL.AddParam("@IDCategoria", IDCategoria)
        '
        Try
            SQL.ExecQuery(myQuery)
            '
            If SQL.HasException Then
                Throw New Exception(SQL.Exception)
            Else
                Return True
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' RETORNA UMA DATATABLE DE TIPOS DE PRODUTOS
    '-----------------------------------------------------------------------------------------------------------------
    Public Function GetTipos(Optional Ativo As Boolean? = Nothing) As DataTable
        Dim SQL As New SQLControl
        '
        Dim strSQL As String = "SELECT * FROM tblProdutoTipo"
        '
        If Not Ativo Is Nothing Then
            strSQL = strSQL & " WHERE Ativo = '" & CBool(Ativo).ToString & "'"
        End If
        '
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' RETORNA UMA DATATABLE DE SUBTIPOS DE PRODUTOS
    '-----------------------------------------------------------------------------------------------------------------
    Public Function GetSubTipos(Optional IDTipo As Integer? = Nothing,
                                Optional Ativo As Boolean? = Nothing) As DataTable
        '
        Dim SQL As New SQLControl
        Dim strSQL As String = "SELECT * FROM tblProdutoSubTipo"
        '
        '--- determina as possibiliadades da clausula WHERE
        If Not IDTipo Is Nothing AndAlso Not Ativo Is Nothing Then
            strSQL = strSQL & " WHERE IDProdutoTipo = " & IDTipo & " Ativo = '" & CBool(Ativo).ToString & "'"
        ElseIf IDTipo Is Nothing AndAlso Not Ativo Is Nothing Then
            strSQL = strSQL & " WHERE Ativo = '" & CBool(Ativo).ToString & "'"
        ElseIf Not IDTipo Is Nothing AndAlso Ativo Is Nothing Then
            strSQL = strSQL & " WHERE IDProdutoTipo = " & IDTipo
        End If
        '
        '--- executa o comando
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '-----------------------------------------------------------------------------------------------------------------
    ' RETORNA UMA DATATABLE DE CATEGORIAS DE PRODUTOS
    '-----------------------------------------------------------------------------------------------------------------
    Public Function GetCategorias(Optional IDTipo As Integer? = Nothing,
                                  Optional Ativo As Boolean? = Nothing) As DataTable
        '
        Dim SQL As New SQLControl
        Dim strSQL As String = "SELECT * FROM tblProdutoCategoria"
        '
        '--- determina as possibiliadades da clausula WHERE
        If Not IDTipo Is Nothing AndAlso Not Ativo Is Nothing Then
            strSQL = strSQL & " WHERE IDProdutoTipo = " & IDTipo & " Ativo = '" & CBool(Ativo).ToString & "'"
        ElseIf IDTipo Is Nothing AndAlso Not Ativo Is Nothing Then
            strSQL = strSQL & " WHERE Ativo = '" & CBool(Ativo).ToString & "'"
        ElseIf Not IDTipo Is Nothing AndAlso Ativo Is Nothing Then
            strSQL = strSQL & " WHERE IDProdutoTipo = " & IDTipo
        End If
        '
        '--- executa o comando
        Try
            SQL.ExecQuery(strSQL)
            '
            If SQL.HasException(True) Then
                Throw New Exception(SQL.Exception)
            End If
            '
            Return SQL.DBDT
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
'
'
'*****************************************************************************************************************
'*****************************************************************************************************************
'
'==========================================================================================
' PRODUTO FORNECEDOR
'==========================================================================================
Public Class ProdutoFornecedorBLL
    '
    '--- GET PRODUTO FORNECEDOR PELO IDPRODUTO
    '----------------------------------------------------------------------------------
    Public Function GetListProdutoFornecedorByIDProduto(IDProduto As Integer) As List(Of clProdutoFornecedor)
        '
        Try
            Dim query As String = "SELECT * FROM qryProdutoFornecedor WHERE IDProduto = @IDProduto"
            Dim list As New List(Of clProdutoFornecedor)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", IDProduto)
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return list
            '
            For Each r In dt.Rows
                list.Add(ConvertRowInClass(r))
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
    '--- GET PRODUTO FORNECEDOR PELO IDFORNECEDOR
    '----------------------------------------------------------------------------------
    Public Function GetListProdutoFornecedorByIDFornecedor(IDFornecedor As Integer) As List(Of clProdutoFornecedor)
        '
        Try
            Dim query As String = "SELECT * FROM qryProdutoFornecedor WHERE IDFornecedor = @IDFornecedor"
            Dim list As New List(Of clProdutoFornecedor)
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDFornecedor", IDFornecedor)
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return list
            '
            For Each r In dt.Rows
                list.Add(ConvertRowInClass(r))
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
    '--- GET PRODUTO-FORNECEDOR BY IDPRODUTO & IDFORNECEDOR
    '----------------------------------------------------------------------------------
    Public Function GetProdutoFornecedor(IDProduto As Integer,
                                         IDFornecedor As Integer,
                                         Optional mydb As AcessoDados = Nothing) As clProdutoFornecedor
        Try
            '
            Dim db As AcessoDados = If(mydb, New AcessoDados)
            Dim query As String = "SELECT * FROM qryProdutoFornecedor WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", IDProduto)
            db.AdicionarParametros("@IDFornecedor", IDFornecedor)
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return Nothing
            '
            Return ConvertRowInClass(dt.Rows(0))
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--- INSERT OR UPDATE PRODUTO FORNECEDOR
    '----------------------------------------------------------------------------------
    Public Function InsertUpdate_ProdutoFornecedor(prodForn As clProdutoFornecedor) As clProdutoFornecedor
        '
        Try
            '
            Dim db As New AcessoDados
            Dim query As String = ""
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", prodForn.IDProduto)
            db.AdicionarParametros("@IDFornecedor", prodForn.IDFornecedor)
            '
            query = "SELECT COUNT(*) FROM tblProdutoFornecedor WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            If dt.Rows.Count = 0 Then Throw New Exception("Consulta não retornou valor...")
            '
            If dt.Rows(0).Item(0) = 0 Then '--- INSERT
                '
                query = "INSERT INTO tblProdutoFornecedor " +
                        "(IDFornecedor, IDProduto, IDTransacao, UltimaEntrada, PCompra, DescontoCompra) " +
                        "VALUES " +
                        "(@IDFornecedor, @IDProduto, @IDTransacao, @UltimaEntrada, @PCompra, @DescontoCompra)"
                '
                db.LimparParametros()
                db.AdicionarParametros("@IDFornecedor", prodForn.IDFornecedor)
                db.AdicionarParametros("@IDProduto", prodForn.IDProduto)
                db.AdicionarParametros("@IDTransacao", If(prodForn.IDTransacao, DBNull.Value))
                db.AdicionarParametros("@UltimaEntrada", prodForn.UltimaEntrada)
                db.AdicionarParametros("@PCompra", prodForn.PCompra)
                db.AdicionarParametros("@DescontoCompra", prodForn.DescontoCompra)
                '
                db.ExecutarManipulacao(CommandType.Text, query)
                '
            ElseIf dt.Rows(0).Item(0) = 1 Then '--- UPDATE
                '
                query = "UPDATE tblProdutoFornecedor SET " +
                        "UltimaEntrada = @UltimaEntrada, " +
                        "IDTransacao = @IDTransacao, " +
                        "DescontoCompra = @DescontoCompra, " +
                        "PCompra = @PCompra " +
                        "WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
                '
                db.LimparParametros()
                db.AdicionarParametros("@IDFornecedor", prodForn.IDFornecedor)
                db.AdicionarParametros("@IDProduto", prodForn.IDProduto)
                db.AdicionarParametros("@IDTransacao", If(prodForn.IDTransacao, DBNull.Value))
                db.AdicionarParametros("@UltimaEntrada", prodForn.UltimaEntrada)
                db.AdicionarParametros("@PCompra", prodForn.PCompra)
                db.AdicionarParametros("@DescontoCompra", prodForn.DescontoCompra)
                '
                db.ExecutarManipulacao(CommandType.Text, query)
                '
            Else
                Throw New Exception("Consulta retornou MAIS do que um valor...")
            End If
            '
            Return GetProdutoFornecedor(prodForn.IDProduto, prodForn.IDFornecedor, db)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--- INSERT OR UPDATE PRODUTO CODIGO/ID FORNECEDOR
    '----------------------------------------------------------------------------------
    Public Function InsertUpdate_IDProdutoOrigem(IDProduto As Integer,
                                                 IDFornecedor As Integer,
                                                 IDProdutoOrigem As String) As Boolean
        '
        Try
            '
            Dim db As New AcessoDados
            Dim query As String = ""
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", IDProduto)
            db.AdicionarParametros("@IDFornecedor", IDFornecedor)
            '
            query = "SELECT COUNT(*) FROM tblProdutoFornecedorID WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            If dt.Rows.Count = 0 Then Throw New Exception("Consulta não retornou valor...")
            '
            If dt.Rows(0).Item(0) = 0 Then '--- INSERT
                '
                query = "INSERT INTO tblProdutoFornecedorID " +
                        "(IDFornecedor, IDProduto, IDProdutoOrigem) " +
                        "VALUES " +
                        "(@IDFornecedor, @IDProduto, @IDProdutoOrigem)"
                '
                db.LimparParametros()
                db.AdicionarParametros("@IDFornecedor", IDFornecedor)
                db.AdicionarParametros("@IDProduto", IDProduto)
                db.AdicionarParametros("@IDProdutoOrigem", IDProdutoOrigem)
                '
                db.ExecutarManipulacao(CommandType.Text, query)
                '
            ElseIf dt.Rows(0).Item(0) = 1 Then '--- UPDATE
                '
                query = "UPDATE tblProdutoFornecedorID SET " +
                        "IDProdutoOrigem = @IDProdutoOrigem " +
                        "WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
                '
                db.LimparParametros()
                db.AdicionarParametros("@IDFornecedor", IDFornecedor)
                db.AdicionarParametros("@IDProduto", IDProduto)
                db.AdicionarParametros("@IDProdutoOrigem", IDProdutoOrigem)
                '
                db.ExecutarManipulacao(CommandType.Text, query)
                '
            Else
                Throw New Exception("Consulta retornou MAIS do que um valor...")
            End If
            '
            Return True
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--- DELETE PRODUTO FORNECEDOR ITEM
    '----------------------------------------------------------------------------------
    Public Function Delete_ProdutoFornecedor(prodForn As clProdutoFornecedor) As Boolean
        '
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        Try
            '
            Dim query As String = ""
            '
            '--- DELETE TBLPRODUTOFORNECEDOR
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", prodForn.IDProduto)
            db.AdicionarParametros("@IDFornecedor", prodForn.IDFornecedor)
            '
            query = "DELETE tblProdutoFornecedor WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            '--- DELETE CODIGO ORIGEM
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", prodForn.IDProduto)
            db.AdicionarParametros("@IDFornecedor", prodForn.IDFornecedor)
            '
            query = "DELETE tblProdutoFornecedorID WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
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
    '--- DEFINE/SELECT FORNECEDOR PADRAO
    '----------------------------------------------------------------------------------
    Public Function DefineFornecedorPadrao(IDProduto As Integer,
                                           IDFornecedor As Integer) As Boolean
        '
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        Try
            '
            Dim query As String = ""
            '
            '--- REMOVE ALL FORNECEDOR PADRAO
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", IDProduto)
            query = "UPDATE tblProdutoFornecedor SET FornecedorPadrao = 'FALSE' WHERE IDProduto = @IDProduto"
            '
            db.ExecutarManipulacao(CommandType.Text, query)
            '
            '--- DEFINE FORNECEDOR PADRAO
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", IDProduto)
            db.AdicionarParametros("@IDFornecedor", IDFornecedor)
            '
            query = "UPDATE tblProdutoFornecedor SET FornecedorPadrao = 'TRUE' WHERE IDProduto = @IDProduto And IDFornecedor = @IDFornecedor"
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
    '--- GET FORNECEDOR PADRAO OF PRODUTO
    '----------------------------------------------------------------------------------
    Public Function GetFornecedorPadrao(IDProduto As Integer) As clProdutoFornecedor
        '
        Try
            Dim db As New AcessoDados
            Dim query As String = "SELECT * FROM qryProdutoFornecedor WHERE FornecedorPadrao = 'TRUE' AND IDProduto = @IDProduto"
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDProduto", IDProduto)
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            '
            If dt.Rows.Count = 0 Then Return Nothing
            '
            Return ConvertRowInClass(dt.Rows(0))
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--- CONVERT ROW IN CLASS
    '----------------------------------------------------------------------------------
    Private Function ConvertRowInClass(r) As clProdutoFornecedor
        '
        Return New clProdutoFornecedor With {
            .IDProduto = r("IDProduto"),
            .Produto = r("Produto"),
            .RGProduto = r("RGProduto"),
            .IDFornecedor = r("IDFornecedor"),
            .Cadastro = r("Cadastro"),
            .CNPJ = r("CNPJ"),
            .PCompra = If(IsDBNull(r("PCompra")), 0, r("PCompra")),
            .DescontoCompra = If(IsDBNull(r("DescontoCompra")), 0, r("DescontoCompra")),
            .IDTransacao = If(IsDBNull(r("IDTransacao")), Nothing, r("IDTransacao")),
            .UltimaEntrada = If(IsDBNull(r("UltimaEntrada")), Nothing, r("UltimaEntrada")),
            .IDProdutoOrigem = If(IsDBNull(r("IDProdutoOrigem")), String.Empty, r("IDProdutoOrigem")),
            .IDFilial = If(IsDBNull(r("IDFilial")), Nothing, r("IDFilial")),
            .ApelidoFilial = If(IsDBNull(r("ApelidoFilial")), String.Empty, r("ApelidoFilial")),
            .FornecedorPadrao = r("FornecedorPadrao")
            }
        '
    End Function
    '
End Class