Imports CamadaBLL
Imports CamadaDTO

Public Class frmProdutoTransacoesDetalhes
    '
    Private _list As New List(Of clTransacaoItem)
    Private bindList As New BindingSource
    Private _formOrigem As Form
    Private _Produto As clProduto
    Private _IDFilial As Integer
    Private _Operacao As Byte
    Private _dtInicial As Date
    Private _dtFinal As Date
    '
#Region "SUB NEW"
    '
    Sub New(Produto As clProduto, Operacao As Byte, dtInicial As Date, dtFinal As Date, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _IDFilial = Obter_FilialPadrao()
        _formOrigem = formOrigem
        _Produto = Produto
        _dtInicial = dtInicial
        _dtFinal = dtFinal
        propOperacao = Operacao
        '
        PreencheLabels()
        PreencheItens()
        '
    End Sub
    '
    '--- LOAD
    Private Sub frmProdutoTransacoesDetalhes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- posiciona o form
        Top = _formOrigem.Top
        'Left = _formOrigem.Left + _formOrigem.Width - 270
        '
    End Sub
    '
    '--- SHOW
    Private Sub frmProdutoTransacoesDetalhes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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
    '--- PREENCHER OS LABELS
    Private Sub PreencheLabels()
        '
        If IsNothing(_Produto) OrElse IsNothing(_Produto.IDProduto) Then Exit Sub
        '
        lblProduto.Text = _Produto.Produto
        lblPeriodo.Text = "Período: " + Format(_dtInicial, "dd/MMM/yyyy") + " até " + Format(_dtFinal, "dd/MMM/yyyy")
        '
        Select Case propOperacao
            Case 1
                lblTitulo.Text = "VENDAS"
            Case 2
                lblTitulo.Text = "COMPRAS"
            Case 3
                lblTitulo.Text = "SIMPLES ENTRADAS"
            Case 4
                lblTitulo.Text = "SIMPLES SAÍDAS"
            Case 5
                lblTitulo.Text = "DEVOLUÇÃO DE VENDA"
            Case 6
                lblTitulo.Text = "DEVOLUÇÃO DE COMPRA"
            Case 7
                lblTitulo.Text = "CONSIGNAÇÃO DE ENTRADA"
            Case 8
                lblTitulo.Text = "DEVOLUÇÃO DE CONSIGNAÇÃO"
            Case 100
                lblTitulo.Text = "SAÍDAS DE PRODUTOS"
            Case 101
                lblTitulo.Text = "ENTRADAS DE PRODUTOS"
        End Select
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
    End Sub
    '
    Private Property propOperacao As Byte
        '
        Get
            Return _Operacao
        End Get
        '
        Set(value As Byte)
            _Operacao = value
            '
            If _Operacao < 100 Then
                If _Operacao = 1 Or _Operacao = 4 Or _Operacao = 6 Or _Operacao = 8 Then
                    '--- operacoes de SAIDA
                    _list = GetListByID(_Produto.IDProduto, TransacaoItemBLL.EnumMovimento.SAIDA, _Operacao)
                Else
                    '--- operacoes de ENTRADA
                    _list = GetListByID(_Produto.IDProduto, TransacaoItemBLL.EnumMovimento.ENTRADA, _Operacao)
                End If
            Else
                If _Operacao = 100 Then
                    '--- TODAS operacoes de SAIDA
                    _list = GetListByID(_Produto.IDProduto, TransacaoItemBLL.EnumMovimento.SAIDA)
                ElseIf _Operacao = 101 Then
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
            Return itemBLL.ProdutoTransacoes(IDProduto, Mov, _IDFilial, Operacao, _dtInicial, _dtFinal)
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
        dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
        ' COLUNA Data
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
        ' COLUNA QUANTIDADE
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
        ' COLUNA DESCONTO
        With clnDesconto
            .DataPropertyName = "Desconto"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' COLUNA PRECO
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
        ' COLUNA TOTAL
        With clnTotal
            .DataPropertyName = "Total"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "C"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        '--- adiciona as colunas editadas
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnData, clnQuantidade,
                                  clnDesconto, clnPreco, clnTotal})
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        btnTransacao_Click(New Object, New EventArgs)
    End Sub
    '
    Private Sub dgvItens_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvItens.CellFormatting
        '
        If e.ColumnIndex = clnDesconto.Index Then
            e.Value = Format(e.Value, "0.00") & "%"
        End If
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
    '--- ABRIR A COMPRA
    '----------------------------------------------------------------------------------
    Private Sub btnTransacao_Click(sender As Object, e As EventArgs) Handles btnTransacao.Click
        '
        AbrirDialog("Desculpe, ainda não foi implementado...",
                    "Em implementação", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
        Exit Sub
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
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '
        If Not IsNothing(_formOrigem) Then
            '
            _formOrigem.Controls("Panel1").BackColor = Color.Silver
            '
            If IsNothing(_formOrigem.ParentForm) Then
                _formOrigem.Opacity = 0.6
            End If
        End If
        '
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        '
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Controls("Panel1").BackColor = Color.SlateGray
            _formOrigem.Opacity = 1
        End If
        '
    End Sub
    '
#End Region
    '
End Class
