Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmProdutoFornecedorEditar
    '
    Private prodBLL As New ProdutoFornecedorBLL
    Private _prodForn As clProdutoFornecedor
    Private bindProd As New BindingSource
    Private _Sit As EnumFlagEstado
    Private _isProdutoFixed As Boolean
    Private _formOrigem As Form = Nothing
    '
    '--- ITENS LIST CONTROL
    Private _itensList As New List(Of clProdutoFornecedorItem)
    Private bindItens As New BindingSource
    Private currentEditRow As Integer? = Nothing
    Private _rowSit As EnumFlagEstado
    '
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
#Region "SUB NEW"
    '
    Sub New(prodForn As clProdutoFornecedor, isProdutoFixed As Boolean, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _prodForn = prodForn
        _isProdutoFixed = isProdutoFixed
        '
        bindProd.DataSource = _prodForn
        PreencheDataBindings()
        '
        '
        If IsNothing(_prodForn.IDFornecedor) Then '--> NEW | INSERT
            Sit = EnumFlagEstado.NovoRegistro
        Else '--> SAVED | UPDATE
            Sit = EnumFlagEstado.RegistroSalvo
            _itensList = GetListItems()
            bindItens.DataSource = _itensList
            FormataDatagrid()
        End If
        '
        IsOrigemTransacao()
        '
        dtpUltimaEntrada.MaxDate = Today
        AtivoButtonImage()
        '
    End Sub
    '
    '--- CHECK ORIGEM TRANSACAO
    Private Sub IsOrigemTransacao()
        '
        If IsNothing(_prodForn.IDTransacao) Then
            dtpUltimaEntrada.Enabled = True
            txtDescontoCompra.ReadOnly = False
            txtPCompra.ReadOnly = False
            lblVinculado.Visible = False
        Else
            dtpUltimaEntrada.Enabled = False
            txtDescontoCompra.ReadOnly = True
            txtPCompra.ReadOnly = True
            lblVinculado.Visible = True
        End If
        '
    End Sub
    '
    'PROPERTY SIT
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnCancelar.Enabled = False
                dgvItens.Enabled = True
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
                dgvItens.Enabled = False
            End If
        End Set
    End Property
    '
#End Region '/ SUB NEW
    '
#Region "BINDINGS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA

        lblIDTransacao.DataBindings.Add("Text", bindProd, "IDTransacao")
        lblApelidoFilial.DataBindings.Add("Text", bindProd, "ApelidoFilial")
        dtpUltimaEntrada.DataBindings.Add("Value", bindProd, "UltimaEntrada", True, DataSourceUpdateMode.OnPropertyChanged)

        lblRGProduto.DataBindings.Add("Text", bindProd, "RGProduto", True, DataSourceUpdateMode.OnPropertyChanged)
        lblProduto.DataBindings.Add("Text", bindProd, "Produto")
        lblFornecedor.DataBindings.Add("Text", bindProd, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)

        txtPCompra.DataBindings.Add("Text", bindProd, "PCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescontoCompra.DataBindings.Add("Text", bindProd, "DescontoCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        lblPrecoFinal.DataBindings.Add("Text", bindProd, "SubTotal")
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtPCompra.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler txtDescontoCompra.DataBindings("text").Format, AddressOf FormatPercent
        AddHandler lblRGProduto.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblIDTransacao.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblPrecoFinal.DataBindings("Text").Format, AddressOf FormatCUR
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _prodForn.AoAlterar, AddressOf HandlerAoAlterar
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _prodForn.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    Private Sub FormatPercent(sender As Object, e As ConvertEventArgs)
        e.Value = Format(e.Value / 100, "0.00%")
    End Sub
    '
#End Region '/ BINDINGS
    '
#Region "GET DATAGRID ITEMS LIST"
    '
    Private Function GetListItems() As List(Of clProdutoFornecedorItem)
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Return prodBLL.GetListProdutoFornecedorItems(_prodForn.IDProdutoFornecedor)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a lista de Itens do Fornecedor..." & vbNewLine &
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
    Private Sub FormataDatagrid()
        '
        '--- limpa as colunas do datagrid
        dgvItens.Columns.Clear()
        dgvItens.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvItens.AllowUserToAddRows = True
        dgvItens.MultiSelect = False
        dgvItens.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        dgvItens.ColumnHeadersVisible = True
        dgvItens.AllowUserToResizeRows = False
        dgvItens.AllowUserToResizeColumns = False
        dgvItens.RowHeadersVisible = True
        dgvItens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvItens.StandardTab = False
        '
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgvItens.RowHeadersWidth = 25
        dgvItens.RowTemplate.Height = 25
        dgvItens.RowTemplate.MinimumHeight = 25
        '
        '--- configura o DataSource
        dgvItens.DataSource = bindItens
        '
        '--- formata as colunas do datagrid
        FormataColunas()
        '
    End Sub
    '
    Private Sub FormataColunas()
        '
        ' (0) COLUNA IDProdutoOrigem
        With clnIDProdutoOrigem
            .DataPropertyName = "IDProdutoOrigem"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA DescricaoOrigem
        With clnDescricaoOrigem
            .DataPropertyName = "DescricaoOrigem"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA CodBarrasOrigem
        With clnCodBarrasOrigem
            .DataPropertyName = "CodBarrasOrigem"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        '--- adiciona as colunas editadas
        dgvItens.Columns.AddRange(New DataGridViewColumn() {
                                  clnIDProdutoOrigem,
                                  clnDescricaoOrigem,
                                  clnCodBarrasOrigem
                                  })
        '
    End Sub
    '
#End Region '/ GET DATAGRID ITEMS LIST
    '
#Region "EDICAO DATAGRID ITENS"
    '
    '--- ON ENTER IN ROW VERIFY SITUATION OF THEN
    Private Sub dgvItens_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.RowEnter
        '
        If dgvItens.Rows.Count - 1 > e.RowIndex Then Exit Sub
        Dim item As clProdutoFornecedorItem = dgvItens.Rows(e.RowIndex).DataBoundItem
        '
        If Not IsNothing(item) AndAlso Not IsNothing(item.IDProdutoFornecedorItem) Then
            currentEditRow = Nothing
            _rowSit = EnumFlagEstado.RegistroSalvo
        Else
            _rowSit = EnumFlagEstado.NovoRegistro
        End If
        '
    End Sub
    '
    '--- CONTROLA O ROW QUE ESTA SENDO EDITADO
    Private Sub dgvItens_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvItens.CellBeginEdit
        '
        currentEditRow = e.RowIndex
        '
        If _rowSit = EnumFlagEstado.RegistroSalvo Then

            If e.ColumnIndex = clnIDProdutoOrigem.Index Then
                e.Cancel = True
                AbrirDialog("O Código de Fornecedor desse item não pode ser alterado " +
                            "se desejar faça a exclusão e a inserção de um novo código...",
                            "Código do Fornecedor", frmDialog.DialogType.OK,
                            frmDialog.DialogIcon.Information)
                Return
            End If
            '
            _rowSit = EnumFlagEstado.Alterado
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
        If e.ColumnIndex = 0 Then
            '
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                e.Cancel = False
                Return
            End If
            '
        End If
        '
    End Sub
    '
    '--- VALIDA O ROW E INSERE/ALTERA O ITEM DO PEDIDO
    Private Sub dgvItens_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvItens.RowValidating
        '
        '--- verifica se é um ROW editado ou novo
        If Not (_rowSit = EnumFlagEstado.NovoRegistro OrElse _rowSit = EnumFlagEstado.Alterado) Then Return
        '
        '--- se nao ha row sendo editada exit
        If IsNothing(currentEditRow) Then Return
        '
        '--- Verifica os valores inseridos
        If VerificaItem(e.RowIndex) = False Then
            e.Cancel = True
            Return
        End If
        '
        Try
            SaveItem()
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar o item..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- SAVE NEW ITEM
    Private Sub SaveItem()
        '
        If IsNothing(currentEditRow) Then Exit Sub
        Dim myItem As clProdutoFornecedorItem = dgvItens.Rows(currentEditRow).DataBoundItem
        '
        Try
            If _rowSit = EnumFlagEstado.NovoRegistro Then
                '
                Try
                    '
                    '--- Ampulheta ON
                    Cursor = Cursors.WaitCursor
                    '
                    myItem.IDProdutoFornecedor = _prodForn.IDProdutoFornecedor
                    '
                    ItemInserir(dgvItens.CurrentRow.DataBoundItem)
                    bindItens.EndEdit()
                    currentEditRow = Nothing
                    _rowSit = EnumFlagEstado.RegistroSalvo
                    '
                    '--- EMIT SUCCESS MESSAGE
                    AbrirDialog("Novo item salvo com sucesso!",
                                "Item Salvo", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                    '
                Catch ex As Exception
                    bindItens.CancelEdit()
                    Throw ex
                Finally
                    '
                    '--- Ampulheta OFF
                    Cursor = Cursors.Default
                    '
                End Try
                '
            ElseIf _rowSit = EnumFlagEstado.Alterado Then
                '
                Try
                    '
                    '--- Ampulheta ON
                    Cursor = Cursors.WaitCursor
                    '
                    ItemAlterar(dgvItens.CurrentRow.DataBoundItem)
                    bindItens.EndEdit()
                    currentEditRow = Nothing
                    _rowSit = EnumFlagEstado.RegistroSalvo
                    '
                    '--- EMIT SUCCESS MESSAGE
                    AbrirDialog("Item atualizado com sucesso!",
                                "Item Salvo", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                    '
                Catch ex As Exception
                    bindItens.CancelEdit()
                    Throw ex
                Finally
                    '
                    '--- Ampulheta OFF
                    Cursor = Cursors.Default
                    '
                End Try
                '
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- INSERE NOVO ITEM NO PEDIDO
    Public Sub ItemInserir(myItem As clProdutoFornecedorItem)
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim myI As Object = prodBLL.Insert_ProdutoFornecedorItem(myItem)
            '
            If IsNumeric(myI) Then
                myItem.IDProdutoFornecedorItem = myI
            Else
                Throw New AppException(myI.ToString)
            End If
            '
        Catch ex As Exception
            Throw New AppException("Ocorreu uma exceção ao inserir novo Item do Fornecedor" & vbNewLine &
                                   ex.Message)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    '--- ALTERA ITEM NO PEDIDO
    Private Sub ItemAlterar(myItem As clProdutoFornecedorItem)
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim myI As Object = prodBLL.Update_ProdutoFornecedorItem(myItem)
            '
            If myI = False Then
                Throw New AppException("Não foi possível salvar o registro...")
            End If
            '
        Catch ex As Exception
            Throw New AppException("Ocorreu uma exceção ao ALTERAR Item do Fornecedor" & vbNewLine &
                                   ex.Message)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    '--- VERIFICACAO SE O ITEM ESTA PRONTO PARA SER INSERIDO OU ALTERADO
    Private Function VerificaItem(rowIndex As Integer) As Boolean
        '
        Dim myItem As clProdutoFornecedorItem
        '
        Try
            myItem = dgvItens.Rows(rowIndex).DataBoundItem
        Catch ex As Exception
            myItem = Nothing
        End Try
        '
        If myItem Is Nothing Then Return False
        '
        '--- VERIFICA SE FOI INSERIDO O COD PRODUTO ORIGEM
        If String.IsNullOrEmpty(myItem.IDProdutoOrigem) Then
            dgvItens.CurrentCell = dgvItens.Rows(currentEditRow).Cells(0)
            MessageBox.Show("O código de origem do Produto não pode ficar vazio...", "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        '
        '--- VERIFICA SE O MESMO CODIGO JÁ FOI INSERIDO: IS DUPLICATED
        If _itensList.Where(Function(x) x.IDProdutoOrigem = myItem.IDProdutoOrigem And
                If(x.IDProdutoFornecedorItem, 0) <> If(myItem.IDProdutoFornecedorItem, 0)).Count > 0 Then
            AbrirDialog("Esse código já está presente na listagem... Favor inserir um código de produto diferente.",
                        "Código Repetido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Warning)
            myItem.IDProdutoOrigem = String.Empty
            dgvItens.CurrentCell = dgvItens(0, rowIndex)
            Return False
        End If
        '
        If String.IsNullOrEmpty(myItem.DescricaoOrigem) Then
            Return False
        Else
            myItem.DescricaoOrigem = myItem.DescricaoOrigem.ToUpper
        End If
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
        Select Case colName
            Case "clnCodBarrasOrigem"
                AddHandler e.Control.Leave, AddressOf txtCell_RemoveHandler
                AddHandler e.Control.KeyPress, AddressOf txtcell_onlyNumber_keypress
        End Select
        '
    End Sub
    '
    '--- REMOVE HANDLER DAS CELLS
    Private Sub txtCell_RemoveHandler(sender As Object, e As EventArgs)
        '
        RemoveHandler DirectCast(sender, DataGridViewTextBoxEditingControl).KeyPress, AddressOf txtcell_onlyNumber_keypress
        RemoveHandler DirectCast(sender, DataGridViewTextBoxEditingControl).Leave, AddressOf txtCell_RemoveHandler
        '
    End Sub
    '
    '--- PERMITE SOMENTE NUMEROS
    Private Sub txtcell_onlyNumber_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '
        '--- verifica se foi tecla numerica
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = vbBack AndAlso Not e.KeyChar = ChrW(Keys.Delete) Then
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
            e.SuppressKeyPress = True
            e.Handled = True
            Try
                MoveToNextCell()
            Catch ex As Exception

            End Try
            '
        ElseIf e.KeyCode = Keys.Escape Then
            currentEditRow = Nothing
        End If
        '
    End Sub
    '
    '--- MOVE PARA A PROXIMA CELL NO DATAGRID
    Private Sub MoveToNextCell()
        '
        Dim iColumn As Integer = dgvItens.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgvItens.CurrentCell.RowIndex
        '
        If iColumn = dgvItens.ColumnCount - 1 Then
            If (dgvItens.RowCount > (iRow + 1)) Then
                dgvItens.CurrentCell = dgvItens(0, iRow + 1)
            Else
                dgvItens.CurrentCell = dgvItens(0, iRow)
            End If
        Else
            dgvItens.CurrentCell = dgvItens(iColumn + 1, iRow)
        End If
        '
    End Sub
    '
    '--- AO EXCLUIR O ITEM DO PEDIDO
    Private Sub dgvItens_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvItens.UserDeletingRow
        '
        Dim delItem As clProdutoFornecedorItem = e.Row.DataBoundItem
        '
        '--- verifica se existe numero de IDPedidoItem
        If IsNothing(delItem.IDProdutoFornecedorItem) Then
            e.Cancel = True
            Return
        End If
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você realmente deseja excluir o item de produto do fornecedor:" & vbNewLine & delItem.IDProdutoOrigem & "?",
                           "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
            Return
        End If
        '
        '--- exclui o registro no BD
        Try
            '
            prodBLL.Delete_ProdutoFornecedorItem(delItem.IDProdutoFornecedorItem)
            currentEditRow = Nothing
            e.Cancel = False
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao excluir o item do produto:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End Try
        '
    End Sub
    '
    '--- AO ENTRAR NA CELL
    Private Sub dgvItens_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellEnter
        '
        If IsNothing(currentEditRow) Then Exit Sub
        '
        If e.ColumnIndex = 1 And _rowSit = EnumFlagEstado.NovoRegistro Then
            '
            '--- adiciona uma descricao automatica ao produto
            If IsNothing(dgvItens.Rows(e.RowIndex).Cells(1).Value) Then
                dgvItens.Rows(e.RowIndex).Cells(1).Value = _prodForn.Produto
            End If
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    '--- CLOSE FORM
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If Sit = EnumFlagEstado.Alterado Then
            _prodForn.CancelEdit()
            bindProd.ResetBindings(False)
            AtivoButtonImage()
            Sit = EnumFlagEstado.RegistroSalvo
        Else
            DialogResult = DialogResult.Cancel
        End If
        '
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If Not IsNothing(_prodForn.IDTransacao) Then
            AbrirDialog("Não é possível salvar esse registro porque está vinculado a uma Transação de Compra...",
                        "Registro Vinculado",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Exclamation)

            _prodForn.CancelEdit()
            bindProd.ResetBindings(False)
            AtivoButtonImage()
            Sit = EnumFlagEstado.RegistroSalvo
            Exit Sub
        End If
        '
        If Not VerificaValores() Then Exit Sub
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    ' ATIVAR OU DESATIVAR FORNECEDOR PADRAO BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            AbrirDialog("Não é possível definir Fornecedor Padrão para um registro que ainda não foi Salvo" & vbNewLine &
                        "Para definir esse fornecedor, favor salvar o registro antes.",
                        "Definir Fornecedor Padrão",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        If _prodForn.FornecedorPadrao = True Then ' Fornecedor Padrão
            '
            AbrirDialog("Não é possível remover o Fornecedor Padrão..." & vbNewLine &
                        "Para remover desse Fornecedor, defina outro Fornecedor Padrão.",
                        "Remover Fornecedor Padrão",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            '
        ElseIf _prodForn.FornecedorPadrao = False Then ' Fornecedor Auxiliar
            '
            If AbrirDialog("Você deseja realmente definir o Fornecedor padrão do Produto para:" & vbNewLine &
                           lblFornecedor.Text.ToUpper,
                           "Definir Fornecedor Padrão",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question,
                           frmDialog.DialogDefaultButton.Second) = DialogResult.Yes Then
                '
                Try
                    '
                    '--- Ampulheta ON
                    Cursor = Cursors.WaitCursor
                    '
                    DirectCast(_formOrigem, frmProdutoFornecedor).DefineFornecedorPadrao(_prodForn)
                    '
                Catch ex As Exception
                    '
                    MessageBox.Show("Uma exceção ocorreu ao Definir fornecedor Padrão..." & vbNewLine &
                                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    '
                    '--- Ampulheta OFF
                    Cursor = Cursors.Default
                End Try
                '
                _prodForn.FornecedorPadrao = True
                _prodForn.EndEdit()
                Sit = EnumFlagEstado.RegistroSalvo
                AtivoButtonImage()
            End If
        End If
        '
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        If _prodForn.FornecedorPadrao = True Then ' Nesse caso é Produto Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Fornecedor Padrão"
        ElseIf _prodForn.FornecedorPadrao = False Then ' Nesse caso é Produto Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Fornecedor Auxiliar"
        End If
        '
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "OUTRAS FUNCOES"
    '
    Private Function VerificaValores() As Boolean
        '
        Dim EP As New ErrorProvider
        Dim f As New Utilidades
        '
        If Not f.VerificaDadosClasse(dtpUltimaEntrada, "Ultima Data da Entrada", _prodForn, EP) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtPCompra, "Preço de Compra", _prodForn, EP) Then
            Return False
        End If
        '
        If _prodForn.PCompra <= 0 Then
            '
            '--- MENSAGEM E ERROR PROVIDER
            MessageBox.Show("O campo Preço de Compra não pode ser igual ou menor que Zero;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro, por favor...",
                            "Campo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- CONTROLA O ERROR PROVIDER
            EP.SetError(txtPCompra, "Preencha o valor desse campo!")
            txtPCompra.Focus()
            '
            Return False
            '
        End If
        '
        If Not f.VerificaDadosClasse(txtDescontoCompra, "Desconto de Compra", _prodForn, EP) Then
            Return False
        End If
        '
        If _prodForn.DescontoCompra < 0 OrElse _prodForn.DescontoCompra > 90 Then
            '
            '--- MENSAGEM E ERROR PROVIDER
            MessageBox.Show("O campo Desconto de Compra não pode menor que Zero, ou maior que 90;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro, por favor...",
                            "Campo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- CONTROLA O ERROR PROVIDER
            EP.SetError(txtDescontoCompra, "Preencha o valor desse campo!")
            txtDescontoCompra.Focus()
            '
            Return False
            '
        End If
        '
        Return True
        '
    End Function
    '
    '---------------------------------------------------------------------------------------
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    '---------------------------------------------------------------------------------------
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles dtpUltimaEntrada.KeyDown, txtPCompra.KeyDown, txtDescontoCompra.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' FAZ A TECLA ESC FECHAR O FORM
    '------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If ActiveControl.Name = "dgvItens" Then Exit Sub
        '
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
    End Sub
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
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub

    Private Sub txtDescontoCompra_Leave(sender As Object, e As EventArgs) Handles txtDescontoCompra.Leave
        bindProd.ResetBindings(False)
    End Sub
    '
#End Region
    '
#Region "CONTROLS"
    '
    '---------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
                "txtFornecedor", "txtRGProduto"
            }
            '
            If controlesBloqueados.Contains(ActiveControl.Name) Then
                e.Handled = True
            End If
            '
        End If
        '
    End Sub
    '
    '--- FUNCAO PARA OBTER OS DADOS DO PRODUTO INSERIDO PELO RGPRODUTO
    Private Function Produto_ObterDados(RGProduto As Integer) As Boolean
        Dim pBLL As New ProdutoBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim prod As clProduto = pBLL.GetProduto_PorRG(RGProduto, Obter_FilialPadrao)
            '
            If IsNothing(prod) Then
                MessageBox.Show("Esse código de Produto não foi encontrado...",
                                "Registro Inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            '--- Define os itens do produto encontrado
            _prodForn.Produto = prod.Produto
            _prodForn.IDProduto = prod.IDProduto
            _prodForn.RGProduto = prod.RGProduto
            _prodForn.PCompra = prod.PCompra
            _prodForn.DescontoCompra = prod.DescontoCompra
            '
            '--- RETORNA
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter os dados do produto informado...",
                            "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
#End Region '/ CONTROLS
    '
End Class
