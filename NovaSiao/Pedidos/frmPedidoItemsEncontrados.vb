Imports CamadaDTO
Imports CamadaBLL

Public Class frmPedidoItemsEncontrados
    '
    Private _ItensList As List(Of clPedidoItem)
    Private bindItens As New BindingSource
    Const rowHeight As Integer = 25 '--- define o tamanho da row no DataGridView
    Private _formOrigem As Form
    Private ItensInseridos As Integer = 0
    '
#Region "SUB NEW"
    '
    Sub New(ItensList As List(Of clPedidoItem), ItensInseridos As List(Of clPedidoItem), formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _ItensList = ItensList
        bindItens.DataSource = _ItensList
        '
        '--- verify items inserted
        VerificaItemsInseridos(ItensInseridos)
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
        ' (0) COLUNA IDItem
        With clnIDPedidoItem
            .DataPropertyName = "IDPedidoItem"
            .Width = 0
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (1) COLUNA RGProduto
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
        ' (2) COLUNA PRODUTO
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
        ' (3) COLUNA AUTOR
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
        ' (4) COLUNA PRODUTO TIPO
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
        ' (5) COLUNA ESTOQUE
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
        ' (6) COLUNA ESTOQUE NIVEL
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
        ' (6) COLUNA ESTOQUE IDEAL
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
        ' (7) COLUNA QUANTIDADE
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
        ' (8) COLUNA PRECO
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
        ' (6) COLUNA DESCONTO
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
        ' (9) COLUNA SUB TOTAL
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
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnIDPedidoItem, clnRGProduto,
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
            Select Case myOrigem
                Case 0, 1, 2 '--- Origem PEDIDO
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    e.CellStyle.ForeColor = Color.Black
                Case 10 '--- ITEM ALREADY INSERTED
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Firebrick
                    e.CellStyle.ForeColor = Color.Red
            End Select
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
        '
        If dgvItens.Rows(e.RowIndex).IsNewRow Then
            _rowSit = EnumFlagEstado.NovoRegistro
        Else
            _rowSit = EnumFlagEstado.Alterado
        End If
        '
        If e.ColumnIndex = clnEstoqueIdeal.Index Then
            '--- obtem o item do dgv
            Dim item As clPedidoItem = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem)
            '
            If IsNothing(item) OrElse IsNothing(item.IDProduto) Then
                e.Cancel = True
                MessageBox.Show("Esse item contém um produto novo..." & vbNewLine &
                                "O Estoque Nivel e Ideal não podem ser alterados de um produto que ainda não foi inserido.",
                                "Produto Novo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '
        ElseIf e.ColumnIndex = clnEstoqueNivel.Index Then
            '--- obtem o item do dgv
            Dim item As clPedidoItem = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem)
            '
            If IsNothing(item) OrElse IsNothing(item.IDProduto) Then
                e.Cancel = True
                MessageBox.Show("Esse item contém um produto novo..." & vbNewLine &
                                "O Estoque Nivel e Ideal não podem ser alterados de um produto que ainda não foi inserido.",
                                "Produto Novo", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If _rowSit = EnumFlagEstado.NovoRegistro OrElse _rowSit = EnumFlagEstado.Alterado Then
            '
            '--- Verifica os valores inseridos
            If VerificaItem(e.RowIndex) = False Then
                e.Cancel = True
                'bindItens.CancelEdit()
            Else
                If _rowSit = EnumFlagEstado.NovoRegistro Then
                    '
                    Try
                        Dim myItem As clPedidoItem = dgvItens.Rows(e.RowIndex).DataBoundItem
                        '
                        myItem.IDPedido = _pedido.IDPedido
                        myItem.IDFilialOrigem = _pedido.IDFilial
                        '
                        ItemInserir(dgvItens.Rows(e.RowIndex).DataBoundItem)
                        bindItens.EndEdit()
                        currentEditRow = Nothing
                    Catch ex As Exception
                        bindItens.CancelEdit()
                    End Try
                    '
                ElseIf _rowSit = EnumFlagEstado.Alterado Then
                    '
                    Try
                        ItemAlterar(dgvItens.Rows(e.RowIndex).DataBoundItem)
                        bindItens.EndEdit()
                        currentEditRow = Nothing
                    Catch ex As Exception
                        bindItens.CancelEdit()
                    End Try
                    '
                End If
                '
                bindItens.EndEdit()
                _rowSit = EnumFlagEstado.RegistroSalvo
                AtualizaTotalGeral()
                '
            End If
            '
        End If
        '
    End Sub
    '
    '--- INSERE NOVO ITEM NO PEDIDO
    Private Function ItemInserir(myItem As clPedidoItem) As Integer
        '
        Try
            Dim myI As Object = _pedBLL.PedidoItem_Inserir(myItem)
            '
            If IsNumeric(myI) Then
                myItem.IDPedidoItem = myI
                myItem.Origem = 0
                Return myI
            Else
                Throw New Exception(myI.ToString)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção ao inserir novo Item no Pedido" & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        '
    End Function
    '
    '--- ALTERA ITEM NO PEDIDO
    Private Function ItemAlterar(myItem As clPedidoItem) As Integer
        '
        Try
            Dim myI As Object = _pedBLL.PedidoItem_Alterar(myItem)
            '
            If IsNumeric(myI) Then
                Return myI
            Else
                Throw New Exception(myI.ToString)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção ao ALTERAR Item do Pedido" & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        '
    End Function
    '
    '--- VERIFICACAO SE O ITEM ESTA PRONTO PARA SER INSERIDO OU ALTERADO
    Private Function VerificaItem(rowIndex As Integer) As Boolean
        '
        Dim myItem As clPedidoItem
        '
        Try
            myItem = dgvItens.Rows(rowIndex).DataBoundItem
        Catch ex As Exception
            myItem = Nothing
        End Try
        '
        If myItem Is Nothing Then Return False
        '
        If String.IsNullOrEmpty(myItem.Produto) Then
            dgvItens.CurrentCell = dgvItens.Rows(currentEditRow).Cells(2)
            MessageBox.Show("A descrição do Produto pedido não pode ficar vazia..." & currentEditRow, "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        '
        If IsNothing(myItem.IDProdutoTipo) Then
            dgvItens.CurrentCell = dgvItens.Rows(currentEditRow).Cells(4)
            MessageBox.Show("O tipo do Produto pedido não pode ficar vazio..." & currentEditRow, "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
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
        If e.ColumnIndex = 1 Then
            '
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                e.Cancel = False
                Return
            End If
            '
            If ProcuraItemRG(e.FormattedValue) = False Then
                dgvItens.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
                e.Cancel = True
                Return
            End If
            '
        ElseIf e.ColumnIndex = clnEstoqueIdeal.Index Then
            '
            '--- obtem o item do dgv
            Dim item As clPedidoItem = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem)
            '
            '--- verifica se existe RGProduto
            If Not item.IDProduto Is Nothing Then
                Altera_Item_EstoqueNivel(item.IDProduto, item.EstoqueNivel, e.FormattedValue)
            End If
            '
        ElseIf e.ColumnIndex = clnEstoqueNivel.Index Then
            '
            '--- obtem o item do dgv
            Dim item As clPedidoItem = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clPedidoItem)
            '
            '--- verifica se existe RGProduto
            If Not item.IDProduto Is Nothing Then
                Altera_Item_EstoqueNivel(item.IDProduto, e.FormattedValue, item.EstoqueIdeal)
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
                prodBLL.ProdutoAlterarEstoqueMinimoIdeal(IDProduto, _pedido.IDFilial, EstNivel, EstIdeal)
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
    '--- AO EXCLUIR O ITEM DO PEDIDO
    Private Sub dgvItens_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvItens.UserDeletingRow
        '
        Dim delItem As clPedidoItem = e.Row.DataBoundItem
        '
        '--- verifica se existe numero de IDPedidoItem
        If IsNothing(delItem.IDPedidoItem) Then
            e.Cancel = True
            Return
        End If
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você realmente deseja excluir o produto:" & vbNewLine & delItem.Produto.ToUpper & "?",
                           "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
            Return
        End If
        '
        '--- exclui o registro no BD
        '
        Try
            '
            _pedBLL.PedidoItem_Excluir(delItem.IDPedidoItem)
            e.Cancel = False
            AtualizaTotalGeral()
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao excluir o item do pedido:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
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
            If lista.Exists(Function(x) x.IDProduto = item.IDProduto) Then
                item.Origem = 10
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
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class
