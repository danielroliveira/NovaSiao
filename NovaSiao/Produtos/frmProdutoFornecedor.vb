Imports CamadaBLL
Imports CamadaDTO

Public Class frmProdutoFornecedor
    '
    Private prodBLL As New ProdutoFornecedorBLL
    Private _list As New List(Of clProdutoFornecedor)
    Private bindList As New BindingSource
    Private _formOrigem As Form
    Private _Produto As clProduto
    '
#Region "SUB NEW"
    '
    Sub New(Produto As clProduto, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _Produto = Produto
        _list = GetListByID(Produto.IDProduto)
        bindList.DataSource = _list
        '
        PreencheLabels()
        PreencheItens()
        '
    End Sub
    '
    Sub New(IDProduto As Integer, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _list = GetListByID(IDProduto)
        bindList.DataSource = _list
        '
        If _list.Count > 0 Then
            _Produto = New clProduto
            _Produto.Produto = _list(0).Produto
            _Produto.IDProduto = _list(0).IDProduto
            _Produto.RGProduto = _list(0).RGProduto
        Else
            _Produto = getProdutoByID(IDProduto)
        End If
        '
        PreencheLabels()
        PreencheItens()
        '
    End Sub
    '
    Private Sub frmProdutoFornecedor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        '
        If IsNothing(_Produto) OrElse IsNothing(_Produto.IDProduto) Then
            '
            MessageBox.Show("Uma exceção ocorreu ao Abrir esse formulário..." & vbNewLine &
                            "Não foi encontrado nenhum produto.", "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DialogResult = DialogResult.Cancel
        End If
        '
    End Sub
    '
    Private Sub PreencheLabels()
        '
        If IsNothing(_Produto) OrElse IsNothing(_Produto.IDProduto) Then Exit Sub
        '
        lblProduto.Text = _Produto.Produto
        lblRGProduto.Text = _Produto.RGProduto
        '
    End Sub
    '
#End Region '/ SUB NEW
    '
#Region "GET DADOS"
    '
    Private Function GetListByID(IDProduto As Integer) As List(Of clProdutoFornecedor)
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Return prodBLL.GetListProdutoFornecedorByIDProduto(IDProduto)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a lista de Fornecedores do Produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        Return Nothing
        '
    End Function
    '
    '--- GET PRODUTO PELO ID
    '----------------------------------------------------------------------------------
    Private Function getProdutoByID(IDProduto As Integer) As clProduto
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim pBLL As New ProdutoBLL
            Return pBLL.GetProduto_PorID(IDProduto, Obter_FilialPadrao)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter Produto pelo ID..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
#End Region '/ GET DADOS
    '
#Region "DATAGRID"
    '
    Private Sub PreencheItens()
        '
        '--- limpa as colunas do datagrid
        dgvItens.Columns.Clear()
        dgvItens.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvItens.MultiSelect = False
        dgvItens.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        dgvItens.ColumnHeadersVisible = True
        dgvItens.AllowUserToResizeRows = False
        dgvItens.AllowUserToResizeColumns = False
        dgvItens.RowHeadersVisible = True
        dgvItens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvItens.StandardTab = True
        '
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgvItens.RowHeadersWidth = 25
        dgvItens.RowTemplate.Height = 25
        dgvItens.RowTemplate.MinimumHeight = 25
        '
        '--- configura o DataSource
        dgvItens.DataSource = bindList
        '
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    Private Sub FormataColunas_Itens()
        '
        ' (0) COLUNA Data
        With clnData
            .DataPropertyName = "UltimaEntrada"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "dd/MM/yyyy"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA APELIDOFILIAL
        With clnApelidoFilial
            .DataPropertyName = "ApelidoFilial"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA FORNECEDOR
        With clnFornecedor
            .DataPropertyName = "Cadastro"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA PRECO
        With clnPreco
            .DataPropertyName = "PCompra"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "C"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA DESCONTOCOMPRA
        With clnDesconto
            .DataPropertyName = "DescontoCompra"
            .HeaderText = "Desc(%)"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (5) COLUNA COD IDPRODUTOORIGEM
        With clnIDProdutoFornecedor
            .DataPropertyName = "IDProdutoOrigem"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        '--- adiciona as colunas editadas
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnData, clnApelidoFilial, clnFornecedor,
                                  clnPreco, clnDesconto, clnIDProdutoFornecedor})
        '
    End Sub
    '
#End Region
    '
#Region "FUNCTION BUTTONS"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        Close()
    End Sub
    '
    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        '
        Dim prodForn As New clProdutoFornecedor With {
            .Produto = _Produto.Produto,
            .RGProduto = _Produto.RGProduto,
            .IDProduto = _Produto.IDProduto,
            .UltimaEntrada = Today,
            .ApelidoFilial = ObterConfigValorNode("FilialDescricao"),
            .IDFilial = Obter_FilialPadrao()
        }
        '
        Dim form As New frmProdutoFornecedorEditar(prodForn, Me)
        form.ShowDialog()
        '
        If form.DialogResult <> DialogResult.OK Then Exit Sub
        '
        _list.Add(prodForn)
        bindList.ResetBindings(False)
        '
    End Sub
    '
#End Region '/ FUNCTION BUTTONS
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = False
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = True
        End If
    End Sub


    '
#End Region
    '
End Class
