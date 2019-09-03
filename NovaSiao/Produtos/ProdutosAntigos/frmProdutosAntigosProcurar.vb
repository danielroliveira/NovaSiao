Imports CamadaDTO
Imports CamadaBLL
Imports System.IO
'
Public Class frmProdutosAntigosProcurar
    '
    Private prodBLL As ProdutoAntigoBLL
    Private list As New List(Of clProduto)
    Private _formOrigem As Form
    Private TipoAtual As Integer
    Property ProdutoEscolhido As clProduto
    '
#Region "NEW | OPEN | PROPS"
    '
    Sub New(Optional PesquisaInicial As String = "",
            Optional TipoInicial As Integer? = Nothing,
            Optional formOrigem As Form = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        If PesquisaInicial.Trim.Length > 0 Then
            txtProduto.Text = PesquisaInicial
        End If
        '
        '--- try obtain BDAnterior
        Dim pathBD As String = ObterConfigValorNode("BDAnterior")
        '
        If String.IsNullOrEmpty(pathBD.Length) OrElse Not File.Exists(pathBD) Then
            '
            AbrirDialog("O BD Anterior ainda não foi configurado no CONFIG ou não existe...",
                        "BD Anterior",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            Return
            '
        Else
            prodBLL = New ProdutoAntigoBLL(pathBD)
        End If
        '
        '--- PREENCHE COMBO
        PreencheComboTipo()
        '
        If Not IsNothing(TipoInicial) Then
            cmbTipo.SelectedValue = TipoInicial
        End If
        '
        '--- PREENCHE DATAGRID
        FormataDataGrid()
        GetDadosProdutos()
        FiltrarListagem()
        btnPesquisar.Enabled = False
        '
    End Sub
    '
    Private Sub frmProdutosAntigosProcurar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If IsNothing(prodBLL) Then Close()
        AddHandler cmbTipo.SelectedIndexChanged, AddressOf cmbTipo_SelectedIndexChanged
    End Sub
    '
    Private Sub GetDadosProdutos()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim tipo As Integer = cmbTipo.SelectedValue
            TipoAtual = tipo
            list = prodBLL.ProdutoListByTipo(tipo)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a lsitagem de Produtos do Antigo BD..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '
    End Sub
    '
    Private Sub PreencheComboTipo()
        '
        Dim dtTipo As DataTable
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            dtTipo = prodBLL.ProdutoTipoList
            '
            With cmbTipo
                .DataSource = dtTipo
                .ValueMember = "RGProdutoTipo"
                .DisplayMember = "ProdutoTipo"
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a lista de Tipos de Produtos..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnPesquisar.Enabled = True
    End Sub
    '
#End Region '/ NEW | OPEN | PROPS
    '
#Region "DATAGRID FUNCTIONS"
    '
    Private Sub FormataDataGrid()
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
        dgvItens.RowHeadersWidth = 30
        dgvItens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvItens.StandardTab = True
        '
        '--- formata as colunas do datagrid
        FormataColunas()
        '
    End Sub
    '
    Private Sub FormataColunas()
        '
        ' (0) COLUNA RGProduto
        With clnRGProduto
            .DataPropertyName = "RGProduto"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (1) COLUNA PRODUTO
        With clnProduto
            .DataPropertyName = "Produto"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA AUTOR
        With clnAutor
            .DataPropertyName = "Autor"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (2) COLUNA TIPO
        With clnTipo
            .DataPropertyName = "ProdutoTipo"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (3) COLUNA PRECO COMPRA
        With clnPrecoCompra
            .DataPropertyName = "PCompra"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA PRECO VENDA
        With clnPrecoVenda
            .DataPropertyName = "PVenda"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        dgvItens.Columns.AddRange({clnRGProduto, clnProduto, clnAutor, clnTipo, clnPrecoCompra, clnPrecoVenda})
        '
    End Sub
    '
    Private Sub dgvItens_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        btnEscolher_Click(New Object, New EventArgs)
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
    '
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If IsNothing(dgvItens.CurrentRow) Then
            AbrirDialog("Escolha um produto antes de selecionar...",
                        "Escolher Produto", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            Exit Sub
        End If
        '
        ProdutoEscolhido = dgvItens.CurrentRow.DataBoundItem
        DialogResult = DialogResult.OK
        '
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "FILTRO LISTAGEM"
    '
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        '
        If cmbTipo.SelectedValue <> TipoAtual Then
            GetDadosProdutos()
        End If
        '
        FiltrarListagem()
        txtProduto.Focus()
        btnPesquisar.Enabled = False
        '
    End Sub
    '
    '--- MOSTRA 
    Private Sub btnPesquisar_EnabledChanged(sender As Object, e As EventArgs) Handles btnPesquisar.EnabledChanged
        '
        If btnPesquisar.Enabled = True Then
            btnPesquisar.BackColor = Color.AliceBlue
            showToolTip()
        Else
            btnPesquisar.BackColor = Color.Gainsboro
        End If
        '
    End Sub
    '
    '--- FILTA O NOME DOS CLIENTES
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtProduto.TextChanged
        '
        btnPesquisar.Enabled = True
        '
    End Sub
    '
    '--- FILTAR LISTAGEM PELO IDTIPO E IDFILIAL, TXTPRODUTO, TXTNOME
    Private Sub FiltrarListagem()
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        If txtProduto.Text.Trim.Length = 0 Then
            dgvItens.DataSource = list
        Else
            dgvItens.DataSource = list.FindAll(AddressOf FindProduto)
        End If
        '
        '--- CHANGE LABEL RESULTADO
        Dim cEncontrados = dgvItens.Rows.Count
        If cEncontrados = 0 Then
            lblResultado.Text = "Nenhum produto encontrado..."
            lblResultado.ForeColor = Color.DarkRed
        ElseIf cEncontrados = 1 Then
            lblResultado.Text = "Um produto encontrado..."
            lblResultado.ForeColor = Color.DarkBlue
        ElseIf cEncontrados > 1 Then
            lblResultado.Text = Format(cEncontrados, "00") & " produtos encontrados..."
            lblResultado.ForeColor = Color.DarkBlue
        End If
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
    End Sub
    '
    Private Function FindProduto(ByVal res As clProduto) As Boolean
        '
        If (res.Produto.ToLower Like "*" & txtProduto.Text.ToLower & "*") Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '----------------------------------------------------------------------------------------
    '
#End Region '/ FILTRO LSITAGEM
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
            _formOrigem.Visible = True
        End If
    End Sub
    '
    Private Sub showToolTip()
        '
        Dim myControl As Control = btnPesquisar
        '
        ' Cria a ToolTip e associa com o Form container.
        Dim toolTip1 As New ToolTip()
        '
        ' Define o delay para a ToolTip.
        With toolTip1
            .AutoPopDelay = 2000
            .InitialDelay = 1000
            .ReshowDelay = 500
            .IsBalloon = True
            .UseAnimation = True
            .UseFading = True
        End With
        '
        If myControl.Tag = "" Then
            toolTip1.Show("Clique aqui para realizar a Pesquisa e obter os dados...", myControl, myControl.Width - 30, -40, 1000)
        Else
            toolTip1.Show(myControl.Tag, myControl, myControl.Width - 30, -40, 1000)
        End If
        '
    End Sub
    '
#End Region
    '
End Class
