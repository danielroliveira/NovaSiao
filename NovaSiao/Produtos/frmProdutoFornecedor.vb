Imports CamadaBLL
Imports CamadaDTO

Public Class frmProdutoFornecedor
    '
    Private prodBLL As New ProdutoFornecedorBLL
    Private _list As New List(Of clProdutoFornecedor)
    Private bindList As New BindingSource
    Private _formOrigem As Form
    Private _Produto As clProduto
    Private currentEditRow As Integer? = Nothing
    Private _rowSit As EnumFlagEstado
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
        lblRGProduto.Text = Format(_Produto.RGProduto, "0000")
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
        ' (0) COLUNA COD IDPRODUTOORIGEM
        With clnIDProdutoFornecedor
            .DataPropertyName = "IDProdutoOrigem"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (1) COLUNA Data
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
        ' (2) COLUNA APELIDOFILIAL
        With clnApelidoFilial
            .DataPropertyName = "ApelidoFilial"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA FORNECEDOR
        With clnFornecedor
            .DataPropertyName = "Cadastro"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA PRECO
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
        ' (5) COLUNA DESCONTOCOMPRA
        With clnDesconto
            .DataPropertyName = "DescontoCompra"
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
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnIDProdutoFornecedor, clnData, clnApelidoFilial,
                                  clnFornecedor, clnPreco, clnDesconto})
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        btnEditar_Click(New Object, New EventArgs)
    End Sub
    '
#End Region
    '
#Region "EDICAO DATAGRID ITENS"
    '
    '--- CONTROLA O ROW QUE ESTA SENDO EDITADO
    Private Sub dgvItens_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvItens.CellBeginEdit
        '
        currentEditRow = e.RowIndex
        _rowSit = EnumFlagEstado.Alterado
        '
    End Sub
    '
    '--- VALIDA O ROW E INSERE/ALTERA O ITEM DA LISTAGEM
    Private Sub dgvItens_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvItens.RowValidating
        '
        '--- verifica se é um ROW editado ou novo
        If _rowSit = EnumFlagEstado.Alterado Then
            '
            '--- Verifica os valores inseridos
            If VerificaItem(e.RowIndex) = False Then
                e.Cancel = True
            Else
                '
                Try
                    ItemSave(dgvItens.Rows(e.RowIndex).DataBoundItem)
                    bindList.EndEdit()
                    currentEditRow = Nothing
                Catch ex As Exception
                    bindList.CancelEdit()
                End Try
                '
                bindList.EndEdit()
                _rowSit = EnumFlagEstado.RegistroSalvo
                '
            End If
            '
        End If
        '
    End Sub
    '
    '--- INSERE NOVO ITEM NA LISTAGEM
    Public Function ItemSave(myItem As clProdutoFornecedor) As clProdutoFornecedor
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim obj As Object = prodBLL.InsertUpdate_ProdutoFornecedor(myItem)
            '
            If obj.GetType Is GetType(clProdutoFornecedor) Then
                Return obj
            Else
                Throw New Exception(obj.ToString)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção ao SALVAR novo registro de Fornecedor" & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
    '--- VERIFICACAO SE O ITEM ESTA PRONTO PARA SER INSERIDO OU ALTERADO
    Private Function VerificaItem(rowIndex As Integer) As Boolean
        '
        Return True
        '
    End Function
    '
    '--- CONTROLA HANDLER KEYPRESS DO DATAGRIDVIEW
    Private Sub dgvItens_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvItens.EditingControlShowing
        '
        Dim colName As String = dgvItens.Columns(dgvItens.CurrentCell.ColumnIndex).Name
        '
        If colName = "clnIDProdutoFornecedor" Then
            AddHandler e.Control.Leave, AddressOf txtCell_RemoveHandler
            AddHandler e.Control.KeyPress, AddressOf txtcell_onlyUpperCase_keypress
        End If
        '
    End Sub
    '
    '--- REMOVE HANDLER DAS CELLS
    Private Sub txtCell_RemoveHandler(sender As Object, e As EventArgs)
        '
        RemoveHandler DirectCast(sender, DataGridViewTextBoxEditingControl).KeyPress, AddressOf txtcell_onlyUpperCase_keypress
        RemoveHandler DirectCast(sender, DataGridViewTextBoxEditingControl).Leave, AddressOf txtCell_RemoveHandler
        '
    End Sub
    '
    '--- PERMITE SOMENTE NUMEROS
    Private Sub txtcell_onlyUpperCase_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            DirectCast(sender, TextBox).SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB) NO DATAGRID
    Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItens.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            '
            Dim iColumn As Integer = dgvItens.CurrentCell.ColumnIndex
            Dim iRow As Integer = dgvItens.CurrentCell.RowIndex
            '
            e.SuppressKeyPress = True
            e.Handled = True
            '
            If iColumn = dgvItens.ColumnCount - 1 Then
                If (dgvItens.RowCount > (iRow + 1)) Then

                    dgvItens.CurrentCell = dgvItens(1, iRow + 1)

                Else
                    'focus next control
                End If
            Else
                dgvItens.CurrentCell = dgvItens(iColumn + 1, iRow)
            End If
            '
        End If
        '
    End Sub
    '
    '--- VALIDA O CELL RGPRODUTO E PROCURA O PRODUTO PELO RGPRODUTO
    Private Sub dgvItens_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvItens.CellValidating
        '
        '--- verifica se a currenteCELL is Dirty
        If Not dgvItens.IsCurrentCellDirty Then Return
        '
        If e.ColumnIndex = clnIDProdutoFornecedor.Index Then
            '
            '--- obtem o item do dgv
            Dim item As clProdutoFornecedor = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clProdutoFornecedor)
            '
            '--- SAVE
            Try
                Altera_Item_IDProdutoOrigem(item.IDProduto, item.IDFornecedor, e.FormattedValue)
                currentEditRow = Nothing
                _rowSit = EnumFlagEstado.RegistroSalvo
            Catch ex As Exception
                e.Cancel = True
            End Try
            '
        End If
        '
    End Sub
    '
    '--- ALTERA O CODIGO DO PRODUTO ORIGEM
    '----------------------------------------------------------------------------------
    Private Sub Altera_Item_IDProdutoOrigem(IDProduto As Integer,
                                            IDFornecedor As Integer,
                                            IDProdutoOrigem As String)
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            prodBLL.InsertUpdate_IDProdutoOrigem(IDProduto, IDFornecedor, IDProdutoOrigem)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar o ID do produto da Origem..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- ON ENTER IN ROW VERIFY SITUATION OF THEN
    Private Sub dgvItens_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.RowEnter
        '
        currentEditRow = Nothing
        _rowSit = EnumFlagEstado.RegistroSalvo
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
        If form.DialogResult <> DialogResult.OK Then
            prodForn.CancelEdit()
            bindList.ResetBindings(False)
            Exit Sub
        End If
        '
        '--- check if FORNECEDOR already inserted
        If _list.Exists(Function(x) x.IDFornecedor = prodForn.IDFornecedor) Then
            AbrirDialog("Já existe um registro inserido com o fornecedor:" & vbCrLf &
                        prodForn.Cadastro,
                        "Fornecedor Existente",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '
            Dim obj As Object = prodBLL.InsertUpdate_ProdutoFornecedor(prodForn)
            '
            If Not obj.GetType Is GetType(clProdutoFornecedor) Then
                Throw New Exception(obj.ToString)
            End If
            '
            _list.Add(prodForn)
            bindList.ResetBindings(False)
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar Registro de Fornecedor..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '
        If dgvItens.Rows.Count = 0 OrElse IsNothing(dgvItens.CurrentRow) Then
            AbrirDialog("Selecione um registro na listagem para editar...",
                        "Selecionar Registro", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Dim prodForn As clProdutoFornecedor = dgvItens.CurrentRow.DataBoundItem
        '
        Dim form As New frmProdutoFornecedorEditar(prodForn, Me)
        form.ShowDialog()
        '
        If form.DialogResult <> DialogResult.OK Then
            prodForn.CancelEdit()
            bindList.ResetBindings(False)
            Exit Sub
        End If
        '
        '--- check if FORNECEDOR already inserted
        If _list.Exists(Function(x) x.IDFornecedor = prodForn.IDFornecedor) Then
            AbrirDialog("Já existe um registro inserido com o fornecedor:" & vbCrLf &
                        prodForn.Cadastro,
                        "Fornecedor Existente",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            prodForn.CancelEdit()
            Exit Sub
        End If
        '
        _list.Add(prodForn)
        bindList.ResetBindings(False)
        '
    End Sub
    '
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        If IsNothing(dgvItens.CurrentRow) Then
            MessageBox.Show("Não não nenhum registro selecionado ainda...",
                            "Selecione um Registro", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '
        Dim delItem As clProdutoFornecedor = dgvItens.CurrentRow.DataBoundItem
        '
        If Not IsNothing(delItem.IDTransacao) Then
            AbrirDialog("Não é possível excluir um registro de Fornecedor quando está vinculado à uma compra...",
                        "Registro Vinculado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Return
        End If
        '
        '--- pergunta ao usuario
        If AbrirDialog("Você realmente deseja excluir o FORNECEDOR:" & vbNewLine & delItem.Cadastro.ToUpper & "?",
                       "Excluir Fornecedor",
                       frmDialog.DialogType.SIM_NAO,
                       frmDialog.DialogIcon.Question,
                       frmDialog.DialogDefaultButton.Second) = DialogResult.No Then
            Return
        End If
        '
        '--- exclui o registro no BD
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            prodBLL.Delete_ProdutoFornecedor(delItem)
            bindList.RemoveCurrent()
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao excluir o Fornecedor:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
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
