Imports CamadaBLL
Imports CamadaDTO

Public Class frmProdutoTransacoes
    '
    Private _list As New List(Of clTransacaoItem)
    Private bindList As New BindingSource
    Private _formOrigem As Form
    Private _Produto As clProduto
    Private _IDFilial As Integer
    Private _Operacao As Byte
    '
#Region "SUB NEW"
    '
    Sub New(Produto As clProduto, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _IDFilial = Obter_FilialPadrao()
        _formOrigem = formOrigem
        _Produto = Produto
        Operacao = 1 '--- VENDA
        '
        PreencheLabels()
        PreencheItens()
        CreateRbtHandlers()
        '
    End Sub
    '
    Sub New(IDProduto As Integer, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _IDFilial = Obter_FilialPadrao()
        _formOrigem = formOrigem
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
        Operacao = 1 '--- VENDA
        '
        PreencheLabels()
        PreencheItens()
        CreateRbtHandlers()
        '
    End Sub
    '
    Private Sub frmProdutoTransacoes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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
        lblRGProduto.Text = Format(_Produto.RGProduto, "0000")
        '
    End Sub
    '
    Private Property Operacao As Byte
        Get
            Return _Operacao
        End Get
        Set(value As Byte)
            _Operacao = value
            '
            If Operacao < 100 Then
                If Operacao = 1 Or Operacao = 4 Or Operacao = 6 Or Operacao = 8 Then
                    '--- operacoes de SAIDA
                    _list = GetListByID(_Produto.IDProduto, TransacaoItemBLL.EnumMovimento.SAIDA, Operacao)
                Else
                    '--- operacoes de ENTRADA
                    _list = GetListByID(_Produto.IDProduto, TransacaoItemBLL.EnumMovimento.ENTRADA, Operacao)
                End If
            Else
                If Operacao = 100 Then
                    '--- TODAS operacoes de SAIDA
                    _list = GetListByID(_Produto.IDProduto, TransacaoItemBLL.EnumMovimento.SAIDA)
                ElseIf Operacao = 101 Then
                    '--- TODAS operacoes de ENTRADA
                    _list = GetListByID(_Produto.IDProduto, TransacaoItemBLL.EnumMovimento.ENTRADA)
                End If
            End If
            '
            '--- DEFINE O BINDING
            bindList.DataSource = _list
            '
            'Venda = 1               '--- Vendas                                  --> SAIDA
            'Compra = 2              '--- Compras                                 --> ENTRADA
            'SimplesEntrada = 3      '--- Simples Entrada                         --> ENTRADA
            'SimplesSaida = 4        '--- Simples Saída                           --> SAIDA
            'DevolucaoDeEntrada = 5  '--- Quando o Cliente devolve uma venda      --> ENTRADA
            'DevolucaoDeSaida = 6    '--- Quando a Filial Devolve uma Compra      --> SAIDA
            'ConsignacaoEntrada = 7  '--- Quando a Filial recebe uma Consignação  --> ENTRADA
            'ConsignacaoSaida = 8    '--- Quando a Filial devolve uma Consignação --> SAIDA
            '
        End Set
        '
    End Property
    '
#End Region '/ SUB NEW
    '
#Region "GET DADOS"
    '
    Private Function GetListByID(IDProduto As Integer,
                                 Mov As TransacaoItemBLL.EnumMovimento,
                                 Optional Operacao? As TransacaoBLL.EnumOperacao = Nothing) As List(Of clTransacaoItem)
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim itemBLL As New TransacaoItemBLL
            '
            If IsNothing(Operacao) Then
                Return itemBLL.ProdutoTransacoes(IDProduto, Mov, _IDFilial)
            Else
                Return itemBLL.ProdutoTransacoes(IDProduto, Mov, _IDFilial, Operacao)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a lista de Transações do Produto..." & vbNewLine &
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
            .DataPropertyName = "TransacaoData"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "dd/MM/yyyy"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA COD OPERACAO
        With clnOperacao
            .DataPropertyName = "Operacao"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA QUANTIDADE
        With clnQuantidade
            .DataPropertyName = "Quantidade"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA PRECO
        With clnPreco
            .DataPropertyName = "Preco"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "C"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA DESCONTO
        With clnDesconto
            .DataPropertyName = "Desconto"
            .HeaderText = "Desc(%)"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        '--- adiciona as colunas editadas
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnData, clnOperacao,
                                  clnQuantidade, clnPreco, clnDesconto})
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        'btnEditar_Click(New Object, New EventArgs)
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
    '--- ABRIR A COMPRA
    '----------------------------------------------------------------------------------
    Private Sub btnCompra_Click(sender As Object, e As EventArgs) Handles btnTransacao.Click
        '
        If IsNothing(dgvItens.CurrentRow) Then
            AbrirDialog("Selecione um registro na listagem para ir para a transação...",
                        "Selecionar Registro", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Dim selItem As clProdutoFornecedor = dgvItens.CurrentRow.DataBoundItem
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim cBLL As New CompraBLL
            Dim _cmp As clCompra = cBLL.GetCompra_PorID_OBJ(selItem.IDTransacao)
            '
            If IsNothing(_cmp) Then
                Throw New Exception("Não foi encontrado registro de Compra com esse ID..." & vbCrLf &
                                    "Talvez a transação não seja de Compra.")
            End If
            '
            '--- close FORM frmProduto
            If Not IsNothing(_formOrigem) Then
                _formOrigem.Close()
                _formOrigem = Nothing
            End If
            '
            Dim frm As New frmCompra(_cmp) With {
                        .MdiParent = frmPrincipal,
                        .StartPosition = FormStartPosition.CenterScreen
                    }
            '--- close ME and OPEN COMPRA
            Close()
            frm.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulario de Compras..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '/ FUNCTION BUTTONS
    '
#Region "CHANGE OPERACAO RADIO BUTTONS"
    '
    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs)
        '
        Dim novaOp As Byte = DirectCast(sender, Control).Tag
        '
        If Operacao <> novaOp Then Operacao = novaOp
        '
    End Sub
    '
    Private Sub CreateRbtHandlers()
        '
        AddHandler rbtVenda.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtSimplesSaida.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtDevolucaoCompra.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtDevolucaoConsignacao.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtCompras.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtSimplesEntrada.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtEntradaTroca.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtEntradaConsignacao.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtSaidas.CheckedChanged, AddressOf rbt_CheckedChanged
        AddHandler rbtEntradas.CheckedChanged, AddressOf rbt_CheckedChanged
        '
    End Sub
    '
#End Region '/ CHANGE OPERACAO RADIO BUTTONS
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Hide()
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Show()
        End If
    End Sub
    '
#End Region
    '
End Class
