﻿Imports CamadaBLL
Imports CamadaDTO

Public Class frmFornecedorProdutos
    '
    Private prodBLL As New ProdutoFornecedorBLL
    Private _list As New List(Of clProdutoFornecedor)
    Private bindList As New BindingSource
    Private _formOrigem As Form
    Private _Fornecedor As clFornecedor
    Private currentEditRow As Integer? = Nothing
    Private _rowSit As EnumFlagEstado
    Private ImgInativo As Image = My.Resources.full_page
    Private ImgAtivo As Image = My.Resources.accept
    '
#Region "SUB NEW"
    '
    Sub New(Fornecedor As clFornecedor, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _Fornecedor = Fornecedor
        _list = GetListByID(Fornecedor.IDPessoa)
        bindList.DataSource = _list
        '
        PreencheLabels()
        PreencheItens()
        EnableButtons()
        '
    End Sub
    '
    Sub New(IDFornecedor As Integer, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _list = GetListByID(IDFornecedor)
        bindList.DataSource = _list
        '
        If _list.Count > 0 Then
            _Fornecedor = New clFornecedor
            _Fornecedor.Cadastro = _list(0).Cadastro
            _Fornecedor.IDPessoa = _list(0).IDFornecedor
        Else
            _Fornecedor = getFornecedorByID(IDFornecedor)
        End If
        '
        PreencheLabels()
        PreencheItens()
        EnableButtons()
        '
    End Sub
    '
    Private Sub frmFornecedorProdutos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        '
        If IsNothing(_Fornecedor) OrElse IsNothing(_Fornecedor.IDPessoa) Then
            '
            MessageBox.Show("Uma exceção ocorreu ao Abrir esse formulário..." & vbNewLine &
                            "Não foi encontrado nenhum fornecedor.", "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DialogResult = DialogResult.Cancel
        End If
        '
    End Sub
    '
    Private Sub PreencheLabels()
        '
        If IsNothing(_Fornecedor) OrElse IsNothing(_Fornecedor.IDPessoa) Then Exit Sub
        '
        lblFornecedor.Text = _Fornecedor.Cadastro
        lblIDFornecedor.Text = Format(_Fornecedor.IDPessoa, "0000")
        '
    End Sub
    '
    Private Sub EnableButtons()
        '
        If _list.Count = 0 Then
            btnExcluir.Enabled = False
            btnEditar.Enabled = False
            btnDefinirPadrao.Enabled = False
        Else
            btnExcluir.Enabled = True
            btnEditar.Enabled = True
            btnDefinirPadrao.Enabled = True
        End If
        '
    End Sub
    '
#End Region '/ SUB NEW
    '
#Region "GET DADOS"
    '
    Private Function GetListByID(IDFornecedor As Integer) As List(Of clProdutoFornecedor)
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Return prodBLL.GetListProdutoFornecedorByIDFornecedor(IDFornecedor)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a lista de Produtos do Fornecedor..." & vbNewLine &
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
    Private Function getFornecedorByID(IDFornecedor As Integer) As clFornecedor
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim fBLL As New FornecedorBLL
            Return fBLL.GetFornecedores(IDFornecedor)(0)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter Fornecedor pelo ID..." & vbNewLine &
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
        ' (0) COLUNA PRODUTO
        With clnProduto
            .DataPropertyName = "Produto"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (1) COLUNA COD IDPRODUTOORIGEM
        With clnIDProdutoFornecedor
            .DataPropertyName = "IDProdutoOrigem"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA PRECO
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
        ' (3) COLUNA DESCONTOCOMPRA
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
        ' (4) COLUNA Data
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
        ' (5) COLUNA APELIDOFILIAL
        With clnApelidoFilial
            .DataPropertyName = "ApelidoFilial"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (6) COLUNA FORNECEDOR PADRAO
        With clnFornecedorPadrao
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        '--- adiciona as colunas editadas
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnProduto, clnIDProdutoFornecedor, clnPreco,
                                  clnDesconto, clnData, clnApelidoFilial, clnFornecedorPadrao})
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        btnEditar_Click(New Object, New EventArgs)
    End Sub
    '
    ' PREENCHE AS IMAGENS DA LISTA
    '------------------------------------------------------------------------------------------------------
    Private Sub dgvProdutos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
        Handles dgvItens.CellFormatting
        '
        If e.ColumnIndex = clnFornecedorPadrao.Index Then
            '
            Dim prodForn As clProdutoFornecedor = dgvItens.Rows(e.RowIndex).DataBoundItem
            '
            If IsDBNull(prodForn.FornecedorPadrao) Then
                e.Value = ImgInativo
            ElseIf prodForn.FornecedorPadrao = True Then
                e.Value = ImgAtivo
            ElseIf prodForn.FornecedorPadrao = False Then
                e.Value = ImgInativo
            End If
            '
        End If
        '
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
            MessageBox.Show("Ocorreu uma exceção ao SALVAR novo registro de Produto" & vbNewLine &
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
    '--- VALIDA O CELL
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
        Dim pf As clProdutoFornecedor = dgvItens.Rows(e.RowIndex).DataBoundItem
        '
        If IsNothing(pf.IDTransacao) Then
            btnExcluir.Enabled = True
            btnCompra.Enabled = False
        Else
            btnExcluir.Enabled = False
            btnCompra.Enabled = True
        End If
        '
        If pf.FornecedorPadrao Then
            btnDefinirPadrao.Enabled = False
        Else
            btnDefinirPadrao.Enabled = True
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
    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        '
        Dim prodForn As New clProdutoFornecedor With {
            .Cadastro = _Fornecedor.Cadastro,
            .IDProduto = _Fornecedor.IDPessoa,
            .UltimaEntrada = Today,
            .ApelidoFilial = ObterConfigValorNode("FilialDescricao"),
            .IDFilial = Obter_FilialPadrao()
        }
        '
        Dim form As New frmProdutoFornecedorEditar(prodForn, False, Me)
        form.ShowDialog()
        '
        If form.DialogResult <> DialogResult.OK Then
            prodForn.CancelEdit()
            bindList.ResetBindings(False)
            Exit Sub
        End If
        '
        '--- check if PRODUTO already inserted
        If _list.Exists(Function(x) x.IDProduto = prodForn.IDProduto) Then
            AbrirDialog("Já existe um registro inserido com o PRODUTO:" & vbCrLf &
                        prodForn.Produto,
                        "Produto Existente",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim obj As Object = prodBLL.InsertUpdate_ProdutoFornecedor(prodForn)
            '
            If Not obj.GetType Is GetType(clProdutoFornecedor) Then
                Throw New Exception(obj.ToString)
            End If
            '
            _list.Add(prodForn)
            bindList.ResetBindings(False)
            EnableButtons()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar Registro de Produto..." & vbNewLine &
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
        Dim form As New frmProdutoFornecedorEditar(prodForn, False, Me)
        form.ShowDialog()
        '
        If form.DialogResult <> DialogResult.OK Then
            prodForn.CancelEdit()
            bindList.ResetBindings(False)
            Exit Sub
        End If
        '
        '--- check if PRODUTO already inserted
        If _list.Exists(Function(x) x.IDProduto = prodForn.IDProduto) Then
            AbrirDialog("Já existe um registro inserido com o PRODUTO:" & vbCrLf &
                        prodForn.Produto,
                        "Produto Existente",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            prodForn.CancelEdit()
            bindList.ResetBindings(False)
            Exit Sub
        End If
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim obj As Object = prodBLL.InsertUpdate_ProdutoFornecedor(prodForn)
            '
            If Not obj.GetType Is GetType(clProdutoFornecedor) Then
                Throw New Exception(obj.ToString)
            End If
            '
            bindList.ResetBindings(False)
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar Registro de Produto..." & vbNewLine &
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
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        If IsNothing(dgvItens.CurrentRow) Then
            AbrirDialog("Selecione um registro na listagem para remover...",
                        "Selecionar Registro", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Dim delItem As clProdutoFornecedor = dgvItens.CurrentRow.DataBoundItem
        '
        If Not IsNothing(delItem.IDTransacao) Then
            AbrirDialog("Não é possível remover um registro de Produto quando está vinculado à uma compra...",
                        "Registro Vinculado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Return
        End If
        '
        If delItem.FornecedorPadrao Then
            AbrirDialog("Não é possível remover um registro de Produto quando é o Fornecedor Padrão do Produto...",
                        "Fornecedor Padrão", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Return
        End If
        '
        '--- pergunta ao usuario
        If AbrirDialog("Você realmente deseja remover o PRODUTO:" & vbNewLine & delItem.Produto.ToUpper & vbCrLf &
                       "da listagem desse Fornecedor?",
                       "Remover Produto",
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
            EnableButtons()
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao remover o Produto:" & vbNewLine &
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
    Private Sub btnDefinirPadrao_Click(sender As Object, e As EventArgs) Handles btnDefinirPadrao.Click
        '
        If IsNothing(dgvItens.CurrentRow) Then
            AbrirDialog("Selecione um registro na listagem para Definir como Padrão...",
                        "Selecionar Registro", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Dim selItem As clProdutoFornecedor = dgvItens.CurrentRow.DataBoundItem
        '
        DefineFornecedorPadrao(selItem)
        bindList.ResetBindings(False)
        '
    End Sub
    '
    '--- ABRIR A COMPRA
    '----------------------------------------------------------------------------------
    Private Sub btnCompra_Click(sender As Object, e As EventArgs) Handles btnCompra.Click
        '
        If IsNothing(dgvItens.CurrentRow) Then
            AbrirDialog("Selecione um registro na listagem para ver a compra...",
                        "Selecionar Registro", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Dim selItem As clProdutoFornecedor = dgvItens.CurrentRow.DataBoundItem
        '
        If selItem.IDFilial <> Obter_FilialPadrao() Then
            AbrirDialog("Não é possível visualizar uma compra que tem origem em outra Filial...",
                        "Filial Diferente",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Exclamation)
            Exit Sub
        End If
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
            '--- close FORM frmFornecedor
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
#Region "OUTRAS FUNCOES"
    '
    Public Function DefineFornecedorPadrao(prodForn As clProdutoFornecedor) As Boolean
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            prodBLL.DefineFornecedorPadrao(prodForn.IDProduto, prodForn.IDFornecedor)
            bindList.Current.FornecedorPadrao = True
            '
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Definir Fornecedor Padrao..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
#End Region '/ OUTRAS FUNCOES
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            If _formOrigem.Name = "frmPedido" Then
                Dim pnl As Panel = _formOrigem.Controls("Panel1")
                pnl.BackColor = Color.Silver
                _formOrigem.Controls("tsMenu").Enabled = False
            Else
                _formOrigem.Hide()
            End If
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            If _formOrigem.Name = "frmPedido" Then
                Dim pnl As Panel = _formOrigem.Controls("Panel1")
                pnl.BackColor = Color.SlateGray
                _formOrigem.Controls("tsMenu").Enabled = True
            Else
                _formOrigem.Show()
            End If
        End If
    End Sub
    '
#End Region
    '
End Class