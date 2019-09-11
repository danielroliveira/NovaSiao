Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmProdutoEtiquetaControle
    Private etiqBLL As New ProdutoEtiquetaBLL
    Private lstEtiq As New List(Of clProdutoEtiqueta)
    Private bindEtiq As New BindingSource
    Private dtRelatorios As New DataTable
    Private atualCell As TextBox
    Private returnKey As Boolean = False
    Private CancelCellEndEdit As Boolean = False
    Private EtqPorPag As Integer
    Private _formOrigem As Form = Nothing
    '
#Region "NEW | INICIALIZAR"
    '
    Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        obterEtiquetas()
        GetRelatoriosTipos()
        CarregaComboRelatorioTipo()
        '
    End Sub
    '
    Private Sub GetRelatoriosTipos()
        '
        '-- obtem os registros de tipos de relatorio de etiqueta
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            dtRelatorios = etiqBLL.Get_ProdutoEtiquetaRelatorios
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao obter a lista de relatórios" & vbNewLine &
                ex.Message, "Erro Inseperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub CarregaComboRelatorioTipo()
        '
        '-- define os valores padrao da combobox
        With cmbRelatorios
            .AutoCompleteEnabled = False
            .BackColor = System.Drawing.Color.White
            .DropDownArrowBackgroundEnabled = False
            .DropDownHeight = 200
            .DropDownMaximumSize = New System.Drawing.Size(1000, 1000)
            .DropDownMinimumSize = New System.Drawing.Size(10, 10)
            .DropDownResizeDirection = VIBlend.WinForms.Controls.SizingDirection.Both
            .DropDownWidth = 292
            .ItemHeight = 50
            .UseThemeFont = False
        End With
        '
        '-- preenche a listagem da combobox
        For Each r As DataRow In dtRelatorios.Rows
            '
            '-- cria novo item
            Dim listItem1 As VIBlend.WinForms.Controls.ListItem = New VIBlend.WinForms.Controls.ListItem()
            '
            '-- preenche a listagem com o datatable
            Dim etqQuant As Integer = r("PagLinhas") * r("PagColunas")
            listItem1.Description = r("Descricao") & vbLf & etqQuant & " Etiquetas por Pág."
            listItem1.ImageBeforeText = True
            listItem1.Text = r("EtiquetaRelatorio")
            listItem1.Value = r("IDEtiquetaRelatorio")
            '
            Me.cmbRelatorios.Items.Add(listItem1)
            '
            '--- seleciona o relatorio padrao
            If r("RelatorioPadrao") = True Then
                cmbRelatorios.SelectedIndex = dtRelatorios.Rows.IndexOf(r)
            End If
            '
        Next
        '
    End Sub
    '
#End Region
    '
#Region "DATAGRID DADOS | PREENCHIMENTO"
    '
    Private Sub obterEtiquetas()
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- GET Lista de Movimentacoes
            lstEtiq = etiqBLL.Get_Etiquetas()
            '
            bindEtiq.DataSource = lstEtiq
            dgvListagem.DataSource = bindEtiq
            '
        Catch ex As Exception
            MessageBox.Show("Um exceção ocorreu ao tentar obter a listagem de Etiquetas..." & vbNewLine &
                            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        PreencheListagem()
        '
    End Sub
    '
    Private Sub PreencheListagem()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        dgvListagem.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvListagem.MultiSelect = False
        dgvListagem.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        dgvListagem.ColumnHeadersVisible = True
        dgvListagem.AllowUserToResizeRows = False
        dgvListagem.AllowUserToResizeColumns = False
        dgvListagem.RowHeadersVisible = True
        dgvListagem.RowHeadersWidth = 30
        dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvListagem.StandardTab = False
        '
        FormataColunas()
        '
    End Sub
    '
    Private Sub FormataColunas()
        '
        ' (0) REG
        With clnRG
            .HeaderText = "Reg."
            .DataPropertyName = "RGProduto"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) PRODUTO
        With clnProduto
            .HeaderText = "Produto | Descrição"
            .DataPropertyName = "Produto"
            .Width = 420
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

        End With
        '
        ' (2) COLUNA QUANTIDADE 
        With clnQuantidade
            .HeaderText = "Quant."
            .DataPropertyName = "Quantidade"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .DefaultCellStyle.Format = "00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (3) COLUNA PRECO DE VENDA 
        With clnPVenda
            .HeaderText = "P. Venda"
            .DataPropertyName = "PVenda"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "C"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA VALOR PROMOCAO
        With clnPrecoPromocao
            .HeaderText = "Valor"
            .DataPropertyName = "PrecoPromocao"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .DefaultCellStyle.Format = "C"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {
                                        Me.clnRG,
                                        Me.clnProduto,
                                        Me.clnQuantidade,
                                        Me.clnPVenda,
                                        Me.clnPrecoPromocao})
        '
    End Sub
    '
#End Region
    '
#Region "DATAGRID EDIÇÃO"
    '
    '--- QUANDO PRESSIONA ENTER ENVIA TAB
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            SendKeys.Send("{tab}")
        ElseIf e.KeyCode = Keys.Right And dgvListagem.CurrentCell.ColumnIndex = dgvListagem.Columns.Count - 1 Then
            e.SuppressKeyPress = True
            e.Handled = True
            SendKeys.Send("{tab}")
        ElseIf e.KeyCode = Keys.Left Then '--- Seta Esquerda retornar a celula anterior
            returnKey = True
            If dgvListagem.CurrentCell.ColumnIndex = 0 AndAlso dgvListagem.CurrentCell.RowIndex <> 0 Then
                e.SuppressKeyPress = True
                e.Handled = True
                SendKeys.Send("+{tab}")
            End If
        End If
        '
    End Sub
    '
    '--- NAO PERMITE QUE LETRAS SEJAM INSERIDAS NAS CELLS DO DATAGRID
    Private Sub dgvListagem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvListagem.EditingControlShowing
        atualCell = TryCast(e.Control, TextBox)

        RemoveHandler atualCell.KeyPress, AddressOf cln_KeyPressNumReg
        RemoveHandler atualCell.KeyPress, AddressOf cln_KeyPressNum
        RemoveHandler atualCell.KeyPress, AddressOf cln_KeyPressMoeda

        If atualCell IsNot Nothing Then
            Select Case dgvListagem.CurrentCell.ColumnIndex
                Case 0
                    AddHandler atualCell.KeyPress, AddressOf cln_KeyPressNumReg
                Case 2
                    AddHandler atualCell.KeyPress, AddressOf cln_KeyPressNum
                Case 4
                    AddHandler atualCell.KeyPress, AddressOf cln_KeyPressMoeda
            End Select
            '
        End If
    End Sub
    '
    '--- HANDLE QUE PERMITE NUMEROS SOMENTE E (+) ADD PARA PROCURA
    Private Sub cln_KeyPressNumReg(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = "+"c Then
            e.Handled = True
        ElseIf e.KeyChar = "+"c Then
            e.Handled = True
            Dim f As New frmProdutoProcurar(Me)
            '
            f.ShowDialog()
            '
            If f.DialogResult = DialogResult.OK Then
                atualCell.Text = f.ProdutoEscolhido.RGProduto
            End If
            '
        End If
    End Sub
    '
    '--- HANDLE QUE PERMITE NUMEROS SOMENTE
    Private Sub cln_KeyPressNum(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    '
    '--- HANDLE QUE PERMITE NUMERO E VIRGULA DECIMAL SOMENTE
    Private Sub cln_KeyPressMoeda(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = "," Then
            e.Handled = True
        End If
    End Sub
    '
    '--- INTERCEPTA OS ERROS DA LISTAGEM
    Private Sub dgvListagem_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvListagem.DataError
        If e.Exception.HResult = -2146233033 Then

            If e.ColumnIndex = 4 Then
                MessageBox.Show("Favor digitar um preço válido...", "Preço", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                '
                atualCell.SelectAll()
                '
            End If
        Else
            MessageBox.Show("Um erro ocorreu na listagem:" & vbNewLine &
                            e.Exception.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        '
    End Sub
    '
    '--- IMPEDE TAB STOP NA CELL READONLY
    Private Sub dgvListagem_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvListagem.CellEnter
        '
        If CanFocus = False Then Exit Sub
        '
        Dim dgc As DataGridViewCell = TryCast(dgvListagem.Item(e.ColumnIndex, e.RowIndex), DataGridViewCell)
        If dgc Is Nothing Then Exit Sub
        '
        If dgc.ReadOnly Then
            '
            If returnKey = False Then
                SendKeys.Send("{Tab}")
            Else
                SendKeys.Send("+{Tab}")
                returnKey = False
            End If
            '
        End If
        '
    End Sub
    '
    '--- PREENCHE A NOVA ETIQUETA PELO RgPRODUTO INFORMADO
    Private Sub dgvListagem_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellValueChanged
        If CanFocus = False Then Exit Sub
        '
        Dim OLDetiq As clProdutoEtiqueta = dgvListagem.Rows(e.RowIndex).DataBoundItem
        '
        If e.ColumnIndex = 0 Then '--- alterado a column do RGProduto
            '
            Dim NEWetiq As New clProdutoEtiqueta
            '
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                If IsNothing(OLDetiq.IDEtiqueta) Then '--- etiqueta nova
                    '-- Insere nova etiqueta
                    NEWetiq = etiqBLL.InserirAlterar_EtiquetaItem(OLDetiq)
                Else '-- altera etiqueta
                    NEWetiq = etiqBLL.InserirAlterar_EtiquetaItem(OLDetiq)
                End If
                '
                If Not IsNothing(NEWetiq.IDEtiqueta) Then '--- Verifica se encontrou um produto
                    lstEtiq.Item(e.RowIndex) = NEWetiq
                    dgvListagem.CurrentCell = dgvListagem.Rows(e.RowIndex).Cells(2)
                    CancelCellEndEdit = False
                Else '--- se não encontrou o produto informa o cliente
                    MessageBox.Show("Produto com esse número de registro não foi encontrado...", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    CancelCellEndEdit = True '-- impede que o cellendedit mova o foco
                    dgvListagem.CancelEdit()
                End If
                '
                AtualizaLabelInfo()
                '
            Catch ex As Exception
                MessageBox.Show("Ocorreu uma exceção inseperada:" & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
            '
        ElseIf e.ColumnIndex = 2 Or e.ColumnIndex = 4 Then '--- alteração da column da Quantidade
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                etiqBLL.InserirAlterar_EtiquetaItem(OLDetiq)
                AtualizaLabelInfo()
            Catch ex As Exception
                MessageBox.Show("Ocorreu uma exceção inseperada ao alterar os dados da Etiqueta:" & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
        End If
        '
    End Sub
    '
    '--- VERIFICA SE O PRODUTO JA FOI INCLUIDO
    '--- VERIFICA SE É OS VALORES ESTAO CORRETOS
    Private Sub dgvListagem_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvListagem.CellValidating
        '
        '--- evita fazer verificacao antes de abrir o form
        If CanFocus = False Then Exit Sub
        '
        '--- verifica alteracoes na coluna RGProduto
        If e.ColumnIndex = 0 AndAlso e.FormattedValue.ToString.Trim.Length <> 0 Then
            '
            '-- verifica se é um código numerico valido
            If Not IsNumeric(e.FormattedValue) Then
                '
                MessageBox.Show("Entre com um código de produto válido...", "Reg. Produto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                e.Cancel = True
                Return
                '
            End If
            '
            '--- verifica se existe produto na listagem com o mesmo codigo
            Dim i As Integer = lstEtiq.FindIndex(Function(x) x.RGProduto = e.FormattedValue)
            '
            If i <> -1 And i <> e.RowIndex Then
                e.Cancel = True
                CancelCellEndEdit = True
                MessageBox.Show("Esse produto já está inserido na listagem", "Produto Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                dgvListagem.CancelEdit()
                dgvListagem.CurrentCell = dgvListagem.Rows(i).Cells(0)
                dgvListagem.Rows(i).DefaultCellStyle.BackColor = Color.LightCyan
                Return
            End If
            '
        Else '-- se não for a coluna RGProduto verifica se foi inserido o RG
            If IsNothing(dgvListagem.Item(0, e.RowIndex).Value) Then
                '-- cancela a edicao
                dgvListagem.CancelEdit()
                e.Cancel = True
                '-- vai para o proximo controle do form
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            End If
        End If
        '
    End Sub
    '
    '--- DEVOLVE COR DO BACKGROUND DA ROW PARA WHITE
    Private Sub dgvListagem_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.RowLeave
        dgvListagem.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    '
    '--- DELETA O REGISTRO NO BD QUANDO DELETA NO DATAGRIG
    Private Sub dgvListagem_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvListagem.UserDeletingRow
        Dim delEtiq As clProdutoEtiqueta = e.Row.DataBoundItem
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            etiqBLL.Delete_Etiquetas(delEtiq.IDProduto)
            AtualizaLabelInfo()
        Catch ex As Exception
            MessageBox.Show("Uma exceção inesperada ocorreu ao excluir esse produto da listagem de etiqueta:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    '--- EVITA QUE A TECLA ENTER LEVE O FOCO PARA ROW INFERIOR
    Private Sub dgvListagem_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellEndEdit
        '
        If CancelCellEndEdit = True Then
            CancelCellEndEdit = False
        Else
            SendKeys.Send("{up}")
        End If
        '
    End Sub
    '
    '-- NAO PERMITE EDITAR UM CELL QUANDO AINDA NAO FOI INSERIDO UM RGPRODUTO
    Private Sub dgvListagem_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvListagem.CellBeginEdit
        If e.ColumnIndex <> 0 AndAlso IsNothing(dgvListagem.Item(0, e.RowIndex).Value) Then
            e.Cancel = True
            MessageBox.Show("Favor inserir o reg. do Produto", "Reg. Produto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        '
        Close()
        If Application.OpenForms.Count = 1 Then
            MostraMenuPrincipal()
        End If
        '
    End Sub
    '
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim lstEtiqTotal As New List(Of clProdutoEtiqueta)

        For i = 0 To nudPularQtde.Value - 1
            lstEtiqTotal.Add(New clProdutoEtiqueta)
        Next

        For Each etq As clProdutoEtiqueta In lstEtiq
            '
            For i = 0 To etq.Quantidade - 1
                Dim xetq As New clProdutoEtiqueta
                '
                xetq.IDProduto = etq.IDProduto
                xetq.RGProduto = etq.RGProduto
                xetq.PrecoVenda = etq.PrecoVenda
                xetq.Produto = etq.Produto
                '
                lstEtiqTotal.Add(xetq)
                '
            Next
            '
        Next
        '
        Dim id As Integer = cmbRelatorios.SelectedIndex
        Dim myRows = dtRelatorios.Rows(id)("PagLinhas")
        Dim myCols = dtRelatorios.Rows(id)("PagColunas")
        '
        Dim fPrint As New frmProdutoEtiquetaPrint(FillPages(lstEtiqTotal, myCols, myRows))
        '
        fPrint.ShowDialog()
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '===================================================================================
    ' FORMATA A LISTAGEM DE ETIQUETAS PARA IMPRIMIR NA HORIZONTAL
    '===================================================================================
    Private Function FillPages(myList As List(Of clProdutoEtiqueta), myColNum As Integer, myRowNum As Integer) As List(Of clProdutoEtiqueta)
        '
        '--- define a quantidade de etiquetas
        Dim etqPorCol As Integer = EtqPorPag / myColNum '--- etiquetas por coluna
        '
        '--- adiciona as etiquetas no final da pagina ate completar o numero total de etiquetas por pagina
        Dim etqAddFim As Integer = EtqPorPag - IIf((myList.Count Mod EtqPorPag) = 0, EtqPorPag, (myList.Count Mod EtqPorPag))
        '
        If etqAddFim <> 0 Then
            For i = 0 To etqAddFim - 1
                myList.Add(New clProdutoEtiqueta)
            Next
        End If
        '
        '--- define as variaveis de contagem 
        Dim etqNumTotal As Integer = myList.Count '--- quantidade de etiquetas da listagem
        Dim pagesTotal As Integer = Math.Ceiling(etqNumTotal / EtqPorPag) '--- quant de paginas totais
        '
        Dim etqAtual As Integer = 0 '--- etiqueta atual para controle do FOR
        '
        '---
        '--- Array que retorna os resultados
        Dim etiquetas(etqNumTotal - 1) As clProdutoEtiqueta
        '
        '--- preenche a listagem
        For Each e As clProdutoEtiqueta In myList '--- PERCORRE PELAS ETIQUETAS DA LISTAGEM
            '
            For pageNum = 0 To pagesTotal '--- DEFINE A PAGINA
                For rowNum = 0 To myRowNum - 1 '--- DEFINE A LINHA
                    For colNum = 0 To myColNum - 1 '--- DEFINE A COLUNA
                        '
                        If etqAtual >= etqNumTotal Then Exit For
                        '
                        '--- numera as etiquetas

                        etiquetas(colNum * etqPorCol + rowNum + pageNum * EtqPorPag) = myList.Item(etqAtual)

                        'myList.Item(etqAtual).IDEtiqueta = colNum * etqPorCol + rowNum + pageNum * etqPorPag
                        etqAtual += 1
                        '
                    Next
                Next
            Next
            '
        Next
        '
        Return etiquetas.ToList
        '
    End Function

    '
    '-- ATUALIZA O LABEL INFO QUANDO ALTERA O TIPO DE ETIQUETA
    Private Sub cmbRelatorios_SelectedItemChanged(sender As Object, e As EventArgs) Handles cmbRelatorios.SelectedItemChanged
        '
        Dim i As Integer = cmbRelatorios.SelectedIndex
        EtqPorPag = dtRelatorios.Rows(i)("PagLinhas") * dtRelatorios.Rows(i)("PagColunas")
        '
        If nudPularQtde.Value >= EtqPorPag Then nudPularQtde.Value = EtqPorPag
        nudPularQtde.Maximum = EtqPorPag - 1
        '
        AtualizaLabelInfo()
        '
    End Sub
    '
    '-- ATUALIZA O LABEL INFO
    Private Sub AtualizaLabelInfo()
        '
        Dim qTotal As Integer = lstEtiq.Sum(Function(x) x.Quantidade) + nudPularQtde.Value
        '
        lblInfo.Text = String.Format("{0} Etiquetas | {1} {2}",
                                     Format(qTotal, "00"),
                                     Format(Math.Ceiling(qTotal / EtqPorPag), "00"),
                                     IIf((qTotal / EtqPorPag) <= 1, "Página", "Páginas"))

        '
    End Sub
    '
    Private Sub cmbRelatorios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRelatorios.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '
    '-- ATUALIZA O LABEL INFO QUANDO ALTERA A QUANTIDADE DE ETIQUETA PARA SALTAR
    Private Sub nudPularQtde_ValueChanged(sender As Object, e As EventArgs) Handles nudPularQtde.ValueChanged
        AtualizaLabelInfo()
    End Sub
    '
#End Region
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
End Class
