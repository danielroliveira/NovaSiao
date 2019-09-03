Imports CamadaDAL
Imports CamadaDTO
'
Public Class ProdutoAntigoBLL
    '
    Private _dbPath As String = ""
    Private _dtRef As DataTable
    '
    Private ReadOnly Property dtRef As DataTable
        '
        Get
            If IsNothing(_dtRef) Then
                '
                Try
                    Dim db As New AcessoDados
                    '
                    _dtRef = db.ExecutarConsulta(CommandType.Text, "SELECT * FROM qryProdutoReferencia")
                    '
                Catch ex As Exception
                    Throw ex
                End Try
                '
            End If
            '
            Return _dtRef
            '
        End Get
        '
    End Property
    '
    Public Enum EnumReferencia 'Tipo | Subtipo | Categoria | Fabricante | Situacao
        Tipo
        Subtipo
        Categoria
        Fabricante
        Situacao
    End Enum
    '
    Sub New(dbPath As String)
        _dbPath = dbPath
    End Sub
    '
    '--- CLASS CLREF
    '----------------------------------------------------------------------------------
    Private Class clRef
        '
        Sub New(ref As EnumReferencia, idExt As Integer)
            Referencia = ref
            IDExterno = idExt
        End Sub
        '
        Property Referencia As EnumReferencia
        Property IDInterno As Integer
        Property IDExterno As Integer
        Property DescricaoInterna As String
        '
    End Class
    '
    '==========================================================================================
    ' GET PRODUTO PELO ID NO DATABASE
    '==========================================================================================
    Public Function ProdutoIDGet(RGProduto As Integer) As DataTable
        '
        Try
            '
            If String.IsNullOrEmpty(_dbPath) Then
                Throw New Exception("Não há string de conexão válida...")
            End If
            '
            Dim db As New AcessoOLEDB(_dbPath)
            '
            db.LimparParametros()
            db.AdicionarParametros("@RGProduto", RGProduto)
            '
            Dim query As String = "SELECT * FROM qryProdutos WHERE RGProduto = @RGProduto"
            '
            Return db.ExecutarConsulta(CommandType.Text, query)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' BUSCA OS DADOS DO PRODUTO ANTERIOR NO DATABASE
    '==========================================================================================
    Public Function ProcuraProduto_CadastroAntigo(RGProduto As Integer) As clProduto
        '
        Try
            '
            If String.IsNullOrEmpty(_dbPath) Then
                Throw New Exception("Não há string de conexão válida...")
            End If
            '
            Dim dt As DataTable = ProdutoIDGet(RGProduto)
            '
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Dim myProd As New clProduto
                '
                '--- DADOS COMPATIVEIS
                myProd.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
                myProd.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
                myProd.Autor = IIf(IsDBNull(r("Autor")), String.Empty, r("Autor"))
                myProd.PVenda = IIf(IsDBNull(r("Venda")), Nothing, r("Venda"))
                myProd.PCompra = IIf(IsDBNull(r("Compra")), Nothing, r("Compra"))
                myProd.EstoqueNivel = IIf(IsDBNull(r("EstoqueNivel")), Nothing, r("EstoqueNivel"))
                myProd.EstoqueIdeal = IIf(IsDBNull(r("EstoqueIdeal")), Nothing, r("EstoqueIdeal"))
                '
                '--- DADOS INCOMPATIVEIS
                MakeReferencia(myProd, r, EnumReferencia.Tipo)
                MakeReferencia(myProd, r, EnumReferencia.SubTipo)
                MakeReferencia(myProd, r, EnumReferencia.Categoria)
                MakeReferencia(myProd, r, EnumReferencia.Fabricante)
                MakeReferencia(myProd, r, EnumReferencia.Situacao)
                '
                Return myProd
                '
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
    '==========================================================================================
    ' FAZ ASSOCIACAO DA REFERENCIA ANTERIOR
    '==========================================================================================
    Private Sub MakeReferencia(produto As clProduto, dadoAnterior As DataRow, referenciaTipo As EnumReferencia)
        '
        Select Case referenciaTipo
            '
            Case EnumReferencia.Tipo
                '
                Dim IDExterno As Integer? = If(IsDBNull(dadoAnterior("RGProdutoTipo")), Nothing, dadoAnterior("RGProdutoTipo"))
                If IsNothing(IDExterno) Then Return
                '
                Dim ref As New clRef(referenciaTipo, IDExterno)
                ref = FindIDCorrelacao(ref)
                '
                If IsNothing(ref) Then
                    produto.IDProdutoTipo = 0
                    produto.ProdutoTipo = dadoAnterior("RGProdutoTipo") & "::" & dadoAnterior("ProdutoTipo")
                    Return
                End If
                '
                produto.IDProdutoTipo = ref.IDInterno
                produto.ProdutoTipo = ref.DescricaoInterna
                '
            Case EnumReferencia.SubTipo
                '
                Dim IDExterno As Integer? = If(IsDBNull(dadoAnterior("RGSubTipo")), Nothing, CInt(dadoAnterior("RGSubTipo")))
                If IsNothing(IDExterno) Then Return
                '
                Dim ref As New clRef(referenciaTipo, IDExterno)
                ref = FindIDCorrelacao(ref)
                '
                If IsNothing(ref) Then
                    produto.IDProdutoSubTipo = 0
                    produto.ProdutoSubTipo = dadoAnterior("RGSubTipo") & "::" & dadoAnterior("SubTipo")
                    Return
                End If
                '
                '--- check if IDTipo is the SAME
                Dim separator As Char() = New Char() {":", ":"}
                Dim descricao As String = ref.DescricaoInterna.Split(separator)(0)
                Dim IDTipoInterno As Integer = ref.DescricaoInterna.Split(separator)(2)
                '
                If produto.IDProdutoTipo = IDTipoInterno Then
                    produto.IDProdutoSubTipo = ref.IDInterno
                    produto.ProdutoSubTipo = descricao
                Else
                    produto.IDProdutoSubTipo = -1
                    produto.ProdutoSubTipo = "incompatível"
                End If
                '
            Case EnumReferencia.Categoria
                '
                Dim IDExterno As Integer? = If(IsDBNull(dadoAnterior("RGCat")), Nothing, CInt(dadoAnterior("RGCat")))
                If IsNothing(IDExterno) Then Return
                '
                Dim ref As New clRef(referenciaTipo, IDExterno)
                ref = FindIDCorrelacao(ref)
                '
                If IsNothing(ref) Then
                    produto.IDCategoria = 0
                    produto.ProdutoCategoria = dadoAnterior("RGCat") & "::" & dadoAnterior("Categoria")
                    Return
                End If
                '
                '--- check if IDTipo is the SAME
                Dim separator As Char() = New Char() {":", ":"}
                Dim descricao As String = ref.DescricaoInterna.Split(separator)(0)
                Dim IDTipoInterno As Integer = ref.DescricaoInterna.Split(separator)(2)
                '
                If produto.IDProdutoTipo = IDTipoInterno Then
                    produto.IDCategoria = ref.IDInterno
                    produto.ProdutoCategoria = descricao
                Else
                    produto.IDCategoria = -1
                    produto.ProdutoCategoria = "incompatível"
                End If
                '
            Case EnumReferencia.Fabricante
                '
                Dim IDExterno As Integer? = If(IsDBNull(dadoAnterior("RGFabricante")), Nothing, dadoAnterior("RGFabricante"))
                If IsNothing(IDExterno) OrElse IDExterno = 0 Then Return
                '
                Dim ref As New clRef(referenciaTipo, IDExterno)
                ref = FindIDCorrelacao(ref)
                '
                If IsNothing(ref) Then
                    produto.IDFabricante = 0
                    produto.Fabricante = dadoAnterior("RGFabricante") & "::" & dadoAnterior("Fabricante")
                    Return
                End If
                '
                produto.IDFabricante = ref.IDInterno
                produto.Fabricante = ref.DescricaoInterna
                '
            Case EnumReferencia.Situacao
                '
                Dim IDExterno As Integer? = If(IsDBNull(dadoAnterior("SitTributaria")), Nothing, CInt(dadoAnterior("SitTributaria")))
                If IsNothing(IDExterno) Then Return
                '
                Dim ref As New clRef(referenciaTipo, IDExterno)
                ref = FindIDCorrelacao(ref)
                '
                If IsNothing(ref) Then
                    '
                    Dim situacaoTexto As String = "" '--> 1;"Normal";2;"Subst.Tributária";3;"Isento"
                    Select Case dadoAnterior("SitTributaria")
                        Case 1
                            situacaoTexto = "Normal"
                        Case 2
                            situacaoTexto = "Subst.Tributária"
                        Case 3
                            situacaoTexto = "Isento"
                    End Select
                    '
                    produto.SitTributaria = 0
                    produto.SituacaoTributaria = dadoAnterior("SitTributaria") & "::" & situacaoTexto
                    '
                    Return
                End If
                '
                produto.SitTributaria = CByte(ref.IDInterno)
                produto.SituacaoTributaria = ref.DescricaoInterna
                '
        End Select
        '
    End Sub
    '
    '==========================================================================================
    ' PROCURA CORRELACAO COM DATABASE ANTIGO
    '==========================================================================================
    Private Function FindIDCorrelacao(ref As clRef) As clRef
        '
        Try
            '
            If dtRef.Rows.Count = 0 Then Return Nothing
            '
            Dim myRow As DataRow = dtRef.AsEnumerable().FirstOrDefault(
                Function(x) x.Item("IDExterno") = ref.IDExterno And
                x.Item("Referencia") = ref.Referencia.ToString
                )
            '
            If IsNothing(myRow) Then Return Nothing
            '
            ref.IDInterno = myRow.Item("IDInterno")
            ref.DescricaoInterna = myRow.Item("DescricaoInterna")
            '
            Return ref
            '
            'Catch argumentNull
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' INSERT CORRELACAO BD
    '==========================================================================================
    Public Function MakeCorrelacaoDB(ReferenciaTipo As EnumReferencia,
                                     IDInterno As Integer,
                                     IDExterno As Integer) As Boolean
        '
        Try
            Dim db As New AcessoDados
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDInterno", IDInterno)
            db.AdicionarParametros("@IDExterno", IDExterno)
            db.AdicionarParametros("@Referencia", ReferenciaTipo.ToString)
            '
            Dim query As String = "INSERT INTO tblProdutoReferencia " &
                                  "(Referencia, IDExterno, IDInterno) " &
                                  "VALUES " &
                                  "(@Referencia, @IDExterno, @IDInterno)"
            '
            Dim obj As Object = db.ExecutarManipulacao(CommandType.Text, query)
            '
            If Not IsNothing(obj) Then
                Throw New Exception(obj)
            End If
            '
            Return True
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET PRODUTO TIPO LIST as DATATABLE
    '==========================================================================================
    Public Function ProdutoTipoList() As DataTable
        '
        Try
            '
            If String.IsNullOrEmpty(_dbPath) Then
                Throw New Exception("Não há string de conexão válida...")
            End If
            '
            Dim db As New AcessoOLEDB(_dbPath)
            '
            Dim query As String = "SELECT RGProdutoTipo, ProdutoTipo FROM tblProdutosTipos"
            '
            Return db.ExecutarConsulta(CommandType.Text, query)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' GET PRODUTO LIST by TIPO AS LIST CLPRODUTO
    '==========================================================================================
    Public Function ProdutoListByTipo(RGProdutoTipo As Integer) As List(Of clProduto)
        '
        Try
            '
            If String.IsNullOrEmpty(_dbPath) Then
                Throw New Exception("Não há string de conexão válida...")
            End If
            '
            Dim db As New AcessoOLEDB(_dbPath)
            '
            db.LimparParametros()
            db.AdicionarParametros("@RGProdutoTipo", RGProdutoTipo)
            '
            Dim query As String = "SELECT * FROM qryProdutos WHERE RGProdutoTipo = @RGProdutoTipo"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            Dim list As New List(Of clProduto)
            '
            If dt.Rows.Count = 0 Then Return list

            For Each r In dt.Rows
                '
                Dim myProd As New clProduto
                '
                '--- OBTER DADOS DA TABELA
                myProd.RGProduto = IIf(IsDBNull(r("RGProduto")), Nothing, r("RGProduto"))
                myProd.Produto = IIf(IsDBNull(r("Produto")), String.Empty, r("Produto"))
                myProd.Autor = IIf(IsDBNull(r("Autor")), String.Empty, r("Autor"))
                myProd.PVenda = IIf(IsDBNull(r("Venda")), Nothing, r("Venda"))
                myProd.PCompra = IIf(IsDBNull(r("Compra")), Nothing, r("Compra"))
                myProd.IDProdutoTipo = IIf(IsDBNull(r("RGProdutoTipo")), String.Empty, r("RGProdutoTipo"))
                myProd.ProdutoTipo = IIf(IsDBNull(r("ProdutoTipo")), String.Empty, r("ProdutoTipo"))
                myProd.ProdutoSubTipo = IIf(IsDBNull(r("SubTipo")), String.Empty, r("SubTipo"))
                myProd.ProdutoCategoria = IIf(IsDBNull(r("Categoria")), String.Empty, r("Categoria"))
                myProd.Fabricante = IIf(IsDBNull(r("Fabricante")), String.Empty, r("Fabricante"))
                '
                list.Add(myProd)
                '
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
End Class
