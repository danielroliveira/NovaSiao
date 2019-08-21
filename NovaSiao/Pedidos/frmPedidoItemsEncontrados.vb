Imports CamadaDTO
Imports CamadaBLL

Public Class frmPedidoItemsEncontrados
    '
    Private _ItensList As List(Of clPedidoItem) '--- itens encontrados na procura
    Private _ItensInseridos As List(Of clPedidoItem) '--- itens presentes no pedido
    Private bindItens As New BindingSource
    Const rowHeight As Integer = 25 '--- define o tamanho da row no DataGridView
    Private _formOrigem As frmPedido
    Private ItensInseridos As Integer = 0
    Private currentEditRow As Integer? = Nothing
    Private _rowSit As EnumFlagEstado = EnumFlagEstado.RegistroSalvo
    '
#Region "SUB NEW"
    '
    Sub New(ItensList As List(Of clPedidoItem),
            OrigemReserva As Boolean,
            TipoProcura As String,
            formOrigem As frmPedido)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        If OrigemReserva Then
            lblTitulo.Text = "Produtos Encontrados nas Reservas - " + TipoProcura
        Else
            lblTitulo.Text = "Produtos Encontrados sem Estoque - " + TipoProcura
        End If

        _formOrigem = formOrigem
        _ItensList = ItensList
        bindItens.DataSource = _ItensList
        '
        '--- verify items inserted
        _ItensInseridos = formOrigem.ItensList
        VerificaItemsInseridos(_ItensInseridos)
        PreencheItens()
        ControlaLegenda()
        '
    End Sub
    '
#End Region '/ SUB NEW
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
        dgvItens.RowHeadersWidth = rowHeight
        dgvItens.RowTemplate.Height = rowHeight
        dgvItens.RowTemplate.MinimumHeight = rowHeight
        '
        '--- configura o DataSource
        dgvItens.DataSource = bindItens
        '
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    Private Sub FormataColunas_Itens()
        '
        With clnSelect
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Resizable = DataGridViewTriState.False
        End With
        '
        ' (2) COLUNA RGProduto
        With clnRGProduto
            .DataPropertyName = "RGProduto"
            '.Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (3) COLUNA PRODUTO
        With clnProduto
            .DataPropertyName = "Produto"
            '.Width = 400
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA AUTOR
        With clnAutor
            .DataPropertyName = "Autor"
            '.Width = 220
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (5) COLUNA PRODUTO TIPO
        With clnIDProdutoTipo
            .DataPropertyName = "ProdutoTipo"
            '.Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (6) COLUNA ESTOQUE
        With clnEstoque
            .DataPropertyName = "Estoque"
            .HeaderText = "Est."
            '.Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (7) COLUNA ESTOQUE NIVEL
        With clnEstoqueNivel
            .DataPropertyName = "EstoqueNivel"
            .HeaderText = "Niv."
            '.Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (8) COLUNA ESTOQUE IDEAL
        With clnEstoqueIdeal
            .DataPropertyName = "EstoqueIdeal"
            .HeaderText = "Alvo"
            '.Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (9) COLUNA QUANTIDADE
        With clnQuantidade
            .DataPropertyName = "Quantidade"
            .HeaderText = "Quant."
            '.Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (10) COLUNA PRECO
        With clnPreco
            .DataPropertyName = "Preco"
            '.Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "C"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (11) COLUNA DESCONTO
        With clnDesconto
            .DataPropertyName = "Desconto"
            .HeaderText = "Desc(%)"
            '.Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (12) COLUNA SUB TOTAL
        With clnSubTotal
            .DataPropertyName = "SubTotal"
            '.Width = 80
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
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnSelect, clnRGProduto,
                                                            clnProduto, clnAutor, clnIDProdutoTipo, clnEstoque, clnEstoqueNivel,
                                                            clnEstoqueIdeal, clnQuantidade, clnPreco, clnDesconto, clnSubTotal})
        '
    End Sub
    '
    Private Sub dgvItens_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvItens.CellFormatting
        '
        If e.ColumnIndex = 1 Then
            '
            Dim myOrigem As Byte = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem).Origem
            '
            If myOrigem >= 10 Then
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Firebrick
                e.CellStyle.ForeColor = Color.Red
            Else
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                e.CellStyle.ForeColor = Color.Black
            End If
            '
        End If
        '
    End Sub
    '
#End Region '/ DATAGRID
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
    '--- CONTROLA HANDLER KEYPRESS DO DATAGRIDVIEW
    Private Sub dgvItens_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvItens.EditingControlShowing
        '
        Dim colName As String = dgvItens.Columns(dgvItens.CurrentCell.ColumnIndex).Name
        '
        Select Case colName
            Case "clnRGProduto", "clnEstoqueNivel", "clnEstoqueIdeal", "clnQuantidade"
                AddHandler e.Control.Leave, AddressOf txtCell_RemoveHandler
                AddHandler e.Control.KeyPress, AddressOf txtcell_onlyNumber_keypress
                'AddHandler e.Control.KeyDown, AddressOf txtCell_KeyDown
            Case "clnDesconto", "clnPreco"
                AddHandler e.Control.Leave, AddressOf txtCell_RemoveHandler
                AddHandler e.Control.KeyPress, AddressOf txtcell_decimal_keypress
        End Select
        '
    End Sub
    '
    '--- REMOVE HANDLER DAS CELLS
    Private Sub txtCell_RemoveHandler(sender As Object, e As EventArgs)
        '
        RemoveHandler DirectCast(sender, DataGridViewTextBoxEditingControl).KeyPress, AddressOf txtcell_onlyNumber_keypress
        RemoveHandler DirectCast(sender, DataGridViewTextBoxEditingControl).KeyPress, AddressOf txtcell_decimal_keypress
        RemoveHandler DirectCast(sender, DataGridViewTextBoxEditingControl).Leave, AddressOf txtCell_RemoveHandler
        '
    End Sub
    '
    '--- PERMITE SOMENTE NUMEROS
    Private Sub txtcell_onlyNumber_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '
        '--- verifica se a tecla + foi pressionada e abre a caixa de procura de produto
        If e.KeyChar = "+"c And dgvItens.CurrentCell.ColumnIndex = 1 Then
            e.Handled = True
            '
            '--- abre o form de Procura de Produto
            Dim p As New frmProdutoProcurar(Me, True)
            p.ShowDialog()
            '
            '--- verifica se retornou algum valor
            If p.DialogResult = vbCancel Then Exit Sub
            '
            '--- se retornou entao preenche o RGProduto
            Dim n As String
            Dim strRG As String = p.RGEscolhido.ToString

            For i = 1 To Len(strRG)
                n = Mid(p.RGEscolhido.ToString, i, 1)

                SendKeys.Send(n)
            Next

            SendKeys.Send("{ENTER}")
            Exit Sub
            '
        End If
        '
        '--- verifica se foi tecla numerica
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = vbBack AndAlso Not e.KeyChar = ChrW(Keys.Delete) Then
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- PERMITE SOMENTE NUMEROS E (.) E (,) PARA DECIMAL
    Private Sub txtcell_decimal_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        '
        ' converte (.) em (,)
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
        ' verifica se foi digitado numero, backspace ou virgula
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack And Not e.KeyChar = "." And Not e.KeyChar = "," And Not e.KeyChar = ChrW(Keys.Delete) Then
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
        If e.ColumnIndex = clnEstoqueIdeal.Index Then
            '
            '--- obtem o item do dgv
            Dim item As clPedidoItem = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem)
            '
            '--- verifica se existe RGProduto
            If Not item.IDProduto Is Nothing Then
                '
                If item.EstoqueNivel <= e.FormattedValue Then
                    Altera_Item_EstoqueNivel(item.IDProduto, item.EstoqueNivel, e.FormattedValue)
                ElseIf _rowSit = EnumFlagEstado.Alterado Then
                    AbrirDialog("O Nivel de Estoque não pode ser maior que o Estoque Ideal...",
                                "Estoque Nivel", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                    dgvItens.CancelEdit()
                    _rowSit = EnumFlagEstado.RegistroSalvo
                End If
                '
            End If
            '
        ElseIf e.ColumnIndex = clnEstoqueNivel.Index Then
            '
            '--- obtem o item do dgv
            Dim item As clPedidoItem = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem)
            '
            '--- verifica se existe RGProduto
            If Not item.IDProduto Is Nothing Then
                '
                If item.EstoqueIdeal > e.FormattedValue Then
                    Altera_Item_EstoqueNivel(item.IDProduto, e.FormattedValue, item.EstoqueIdeal)
                ElseIf _rowSit = EnumFlagEstado.Alterado Then
                    AbrirDialog("O Nivel de Estoque não pode ser maior que o Estoque Ideal...",
                                "Estoque Nivel", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                    dgvItens.CancelEdit()
                    _rowSit = EnumFlagEstado.RegistroSalvo
                End If
                '
            End If
            '
        End If
        '
    End Sub
    '
    '--- ALTERA O ESTOQUE MINIMO E/OU IDEAL
    '----------------------------------------------------------------------------------
    Private Sub Altera_Item_EstoqueNivel(IDProduto As Integer, EstNivel As Integer, EstIdeal As Integer)
        '
        Using prodBLL As New ProdutoBLL
            '
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                Dim IDFilial As Integer = _ItensList(0).IDFilialOrigem
                prodBLL.ProdutoAlterarEstoqueMinimoIdeal(IDProduto, IDFilial, EstNivel, EstIdeal)
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao Atualizar o estoque Mínimo e/ou Ideal..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
        End Using
        '
    End Sub
    '
    '--- ON ENTER IN ROW VERIFY SITUATION OF THEN
    Private Sub dgvItens_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.RowEnter
        '
        If Not IsNothing(dgvItens.Rows(e.RowIndex).Cells(0).Value) Then
            currentEditRow = Nothing
            _rowSit = EnumFlagEstado.RegistroSalvo
        End If
        '
    End Sub
    '
    '--- AO SELECIONAR O ITEM ALTERA A CONTAGEM
    Private Sub dgvItens_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellValueChanged
        '
        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
            '
            '--- check if already quantity
            If dgvItens.Rows(e.RowIndex).Cells(0).Value = True Then
                '
                Dim item As clPedidoItem = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem)
                '
                '--- check if ORIGEM is RESERVA AND ESTOQUE is greater than ZERO
                If (item.Origem = 1 Or item.Origem = 11) AndAlso item.Estoque > 0 Then
                    '--- message to USER
                    If AbrirDialog("O produto: " + item.Produto + vbCrLf +
                           "possui quantidade suficiente no estoque atual para atender a reserva..." + vbCrLf +
                           "Deseja inserir esse produto no pedido assim mesmo?",
                           "Produto com Estoque",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.No Then
                        '
                        dgvItens.Rows(e.RowIndex).Cells(0).Value = False
                        dgvItens.CancelEdit()
                        Exit Sub
                        '
                    End If
                    '
                End If
                '
            End If
            '
            Dim quant As Integer = 0
            '
            For Each row As DataGridViewRow In dgvItens.Rows
                If row.Cells(0).Value = True Then
                    quant += 1
                End If
            Next
            '
            If quant > 0 Then
                lblSelecionados.Visible = True
                lblSelecionados.Text = Format(quant, "00") + " Item(s) Selecionado(s)"
                btnInserirSelecionados.Visible = True
            Else
                lblSelecionados.Visible = False
                lblSelecionados.Text = Format(quant, "00") + " Item(s) Selecionado(s)"
                btnInserirSelecionados.Visible = False
            End If
            '
        End If
        '
    End Sub
    '
    '--- AO SELECIONAR O ITEM ALTERA A CONTAGEM
    Private Sub dgvItens_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellContentClick
        '
        If e.ColumnIndex = 0 Then
            dgvItens.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '
    End Sub
    '
    '--- AO CLICAR NO ROW HEADER TRANSFERIR O ITEM
    Private Sub dgvItens_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvItens.RowHeaderMouseDoubleClick
        '
        Try
            ItemTransferir(dgvItens.Rows(e.RowIndex).DataBoundItem, True)
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Transferir Item para o pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        '
        btnFechar_Click(sender, e)
        '
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
    End Sub
    '
#End Region '/ BUTONS FUNCTION
    '
#Region "OUTRAS FUNCOES"
    '
    Private Sub VerificaItemsInseridos(lista As List(Of clPedidoItem))
        '
        If lista.Count = 0 Then Return
        '
        For Each item In _ItensList
            If lista.Exists(Function(x) If(x.IDProduto, 0) = item.IDProduto) Then
                item.Origem += 10
                ItensInseridos += 1
            End If
        Next
        '
    End Sub
    '
    Private Sub ControlaLegenda()
        '
        If _ItensList.Count > 0 Then
            lblEncontrados.Text = "Produtos Encontrados: " & Format(_ItensList.Count, "00")
        End If
        '
        If ItensInseridos > 0 Then
            lblInseridos.Text = "Produtos já Inseridos: " & Format(ItensInseridos, "00")
        End If
        '
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
            _formOrigem.Controls("tsMenu").Enabled = False
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
            _formOrigem.Controls("tsMenu").Enabled = True
        End If
    End Sub
    '
#End Region
    '
#Region "TRANSFERIR ITENS"
    '
    Private Sub ItemTransferir(item As clPedidoItem, Optional emitirMensagem As Boolean = True)
        '
        '--- IF FROM RESERVA CHECK QUANTITY IN ESTOQUE AND ASK TO USER
        If emitirMensagem Then

            If (item.Origem = 1 Or item.Origem = 11) And item.Estoque > 0 Then
                '
                If AbrirDialog("O produto: " + item.Produto + vbCrLf +
                           "possui quantidade suficiente no estoque atual para atender a reserva..." + vbCrLf +
                           "Deseja inserir esse produto no pedido assim mesmo?",
                           "Produto com Estoque",
                frmDialog.DialogType.SIM_NAO,
                frmDialog.DialogIcon.Question) = DialogResult.No Then Exit Sub
                '
            End If
            '
            If item.Origem >= 10 Then
                '
                If AbrirDialog("O produto: " + item.Produto + vbCrLf +
                               "já foi inserido no pedido..." + vbCrLf +
                               "Deseja inserir esse produto no pedido assim mesmo?",
                               "Produto Já Inserido",
                frmDialog.DialogType.SIM_NAO,
                frmDialog.DialogIcon.Question) = DialogResult.No Then Exit Sub
                '
            End If
            '
        End If
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica se o item esta marcado como repetido (origem >= 10)
            '--- se sim, retorna a origem correta ao item
            If item.Origem >= 10 Then
                item.Origem -= 10
            End If
            '
            _formOrigem.ItemInserir(item)
            _ItensInseridos.Add(item)
            _formOrigem.bindItens.ResetBindings(False)
            _formOrigem.AtualizaTotalGeral()
            bindItens.Remove(item)
            '
        Catch ex As Exception
            '
            Throw ex
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub btnInserirSelecionados_Click(sender As Object, e As EventArgs) Handles btnInserirSelecionados.Click
        '
        Dim quant As Integer = 0
        '
        For Each row As DataGridViewRow In dgvItens.Rows
            If row.Cells(0).Value = True Then
                If row.DataBoundItem.Origem = 10 Then quant += 1
            End If
        Next
        '
        If AbrirDialog("Existe(m) " + Format(quant, "00") + " produto(s) que" + vbCrLf +
                       "já foram inseridos no pedido..." + vbCrLf +
                       "Deseja inserir os produtos selecionados mesmo assim?",
                       "Produto(s) Já Inserido(s)",
                       frmDialog.DialogType.SIM_NAO,
                       frmDialog.DialogIcon.Question) = DialogResult.No Then Exit Sub
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            For Each row As DataGridViewRow In dgvItens.Rows
                If row.Cells(0).Value = True Then
                    ItemTransferir(row.DataBoundItem, False)
                End If
            Next
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Transferir os Items para o pedido..." & vbNewLine &
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
#End Region '/ TRANSFERIR ITENS
    '
End Class
