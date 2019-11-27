Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmProdutoListagem
    '
    Private prodLista As New List(Of clProduto)
    Private bindLista As New BindingSource
    '
    Private _ProdutoAtivo As Byte '--> 0:TODOS | 1:ATIVOS | 2:INATIVOS
    Private _Movimento As Byte?
    Private _Produto As String
    Private _Autor As String
    Private _IDProdutoTipo As Integer?
    Private _ProdutoTipo As String
    Private _IDProdutoSubTipo As Integer?
    Private _ProdutoSubTipo As String
    Private _IDCategoria As Integer?
    Private _ProdutoCategoria As String
    Private _IDFabricante As Integer?
    Private _Fabricante As String
    Private _IDFilial As Integer?
    '
    Private myWhere As String = ""
    '
    '--- PAGINACAO
    Private _totalProdutos As Integer ' quantidade total de produtos da listagem
    Const _itemsPorPagina As Integer = 14 ' quantidade de itens que cabem na listagem
    Const rowHeight As Integer = 32 '--- define o tamanho da row no DataGridView
    Private _paginaAtual As Integer = 1
    '
    '--- IMAGENS
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Private BackupRowBackColor As Color
    '
#Region "NEW"
    '
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- verifica a Filial padrao
        _IDFilial = Obter_FilialPadrao()
        '
        If _IDFilial Is Nothing Then
            MessageBox.Show("Não há nehuma filial padrão selecionada...", "Filial Padrão",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            lblFilial.Text = ObterDefault("FilialDescricao")
        End If
        '
        '--- preenche a listagem
        _ProdutoAtivo = 1 '--- ATIVO
        _Movimento = 0 '--- TODOS MOVIMENTOS
        ConfiguraDatagrid()
        AtualizaLabelSelecionados()
        totalProdutos = 0
        '
    End Sub
    '
    Private Sub frmProdutoListagem_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        chkSelecionarTudo.Visible = True
    End Sub
    '
    Private Sub Get_Dados()
        '
        Dim prodBLL As New ProdutoBLL
        '
        '--- consulta o banco de dados
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim myOrder As String = "Produto"
            '
            '--- Get BD Dados
            Dim startRecord = (PaginaAtual * _itemsPorPagina) - _itemsPorPagina
            prodLista = prodBLL.GetProdutosWithEstoque_Where_Limited(_IDFilial,
                                                                     GetWhere,
                                                                     _itemsPorPagina,
                                                                     startRecord,
                                                                     totalProdutos,
                                                                     myOrder)
            '
            '--- verifica se o record inicial é maior que o total dos produtos
            '    se for, refaz a consulta e alterando a pagina atual para 1 
            If totalProdutos > 0 AndAlso startRecord + 1 > totalProdutos Then
                PaginaAtual = 1
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter lista de produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- CRIA E RETORNA A CLAUSULA WHERE DA BUSCA NO BD
    Private Function GetWhere() As String
        '
        myWhere = ""
        '
        '--- Produto DESCRICAO
        If _Produto.Trim.Length > 0 Then
            myWhere += "Produto LIKE '%" & _Produto & "%'"
        End If
        '
        '--- Produto AUTOR
        If _Autor.Trim.Length > 0 Then
            myWhere += IIf(myWhere.Length = 0, "", " AND ")
            myWhere += "Autor LIKE '%" & _Autor & "%'"
        End If
        '
        '--- Produto MOVIMENTO
        If Not IsNothing(_Movimento) AndAlso _Movimento <> 0 Then
            myWhere += IIf(myWhere.Length = 0, "", " AND ")
            myWhere += "Movimento = " & _Movimento
        End If
        '
        '--- Produto 1:ATIVO | 2:INATIVO | 3:TODOS
        If _ProdutoAtivo <> 3 Then
            myWhere += IIf(myWhere.Length = 0, "", " AND ")
            myWhere += "ProdutoAtivo = '" & IIf(_ProdutoAtivo = 1, True, False) & "'"
        End If
        '
        '--- ProdutoTipo
        If Not IsNothing(_IDProdutoTipo) Then
            myWhere += IIf(myWhere.Length = 0, "", " AND ")
            myWhere += "IDProdutoTipo = " & _IDProdutoTipo
        End If
        '
        '--- ProdutoSubTipo
        If Not IsNothing(_IDProdutoSubTipo) Then
            myWhere += IIf(myWhere.Length = 0, "", " AND ")
            myWhere += "IDProdutoSubTipo = " & _IDProdutoSubTipo
        End If
        '
        '--- ProdutoCategoria
        If Not IsNothing(_IDCategoria) Then
            myWhere += IIf(myWhere.Length = 0, "", " AND ")
            myWhere += "IDCategoria = " & _IDCategoria
        End If
        '
        '--- ProdutoCategoria
        If Not IsNothing(_IDFabricante) Then
            myWhere += IIf(myWhere.Length = 0, "", " AND ")
            myWhere += "IDFabricante = " & _IDFabricante
        End If
        '
        Return myWhere
        '
    End Function
    '
    '--- ATUALIZA A LISTAGEM
    Private Sub AtualizaListagem()
        '
        Get_Dados()
        bindLista.DataSource = prodLista
        '
        '--- uncheck todos os items
        If chkSelecionarTudo.Checked = True Then
            AtualizaLabelSelecionados()
            chkSelecionarTudo.Checked = False
        End If
        '
    End Sub
    '----------------------------------------------------------------------------------------
    '
#End Region '// NEW
    '
#Region "PROPRIEDADES"
    '
    '--- QUANTIDADE TOTAL DOS FILTRADOS
    Public Property totalProdutos() As Integer
        '
        Get
            Return _totalProdutos
        End Get
        '
        Set(ByVal value As Integer)
            _totalProdutos = value
            '
            If value = 0 Then
                lblTotalProdutos.Text = "Nenhum Produto Encontrado"
                VerificaNavegacaoButtons()
                btnLimpar.Enabled = False
                chkSelecionarTudo.Enabled = False
            ElseIf value = 1 Then
                lblTotalProdutos.Text = "01 Produto Encontrado"
                VerificaNavegacaoButtons()
                btnLimpar.Enabled = True
                chkSelecionarTudo.Enabled = True
            Else
                lblTotalProdutos.Text = Format(value, "00") & " Produtos Encontrados"
                lblPaginas.Text = "Pag. 1 de 1"
                VerificaNavegacaoButtons()
                btnLimpar.Enabled = True
                chkSelecionarTudo.Enabled = True
            End If
            '
        End Set
        '
    End Property
    '
    Public Property PaginaAtual() As Integer
        '
        Get
            Return _paginaAtual
        End Get
        '
        Set(ByVal value As Integer)
            Dim pags As Integer = Math.Ceiling(_totalProdutos / _itemsPorPagina)
            '
            If value <= pags Or value = 1 Then
                _paginaAtual = value
                VerificaNavegacaoButtons()
                AtualizaListagem()
            End If
            '
        End Set
        '
    End Property
    '
#End Region '/ PROPRIEDADES
    '
#Region "DATAGRID"
    '
    Private Sub ConfiguraDatagrid()
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
        dgvItens.RowHeadersVisible = False
        dgvItens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvItens.StandardTab = True
        '
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgvItens.RowHeadersWidth = rowHeight
        dgvItens.RowTemplate.Height = rowHeight
        dgvItens.RowTemplate.MinimumHeight = rowHeight
        '
        dgvItens.ColumnHeadersDefaultCellStyle.Font = New Font("Pathway Gothic One", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        '--- configura o DataSource
        dgvItens.DataSource = bindLista
        '
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    Private Sub FormataColunas_Itens()
        '
        With clnSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
        With clnTipo
            .DataPropertyName = "ProdutoTipo"
            '.Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (6) COLUNA PRODUTO SUBTIPO
        With clnSubTipo
            .DataPropertyName = "ProdutoSubTipo"
            '.Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (7) COLUNA PRODUTO CATEGORIA
        With clnCategoria
            .DataPropertyName = "ProdutoCategoria"
            '.Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (8) COLUNA FABRICANTE
        With clnFabricante
            .DataPropertyName = "Fabricante"
            '.Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (9) COLUNA ESTOQUE
        With clnEstoque
            .DataPropertyName = "Estoque"
            .HeaderText = "Estoque"
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
        ' (10) COLUNA ESTOQUE NIVEL
        With clnEstoqueNivel
            .DataPropertyName = "EstoqueNivel"
            .HeaderText = "Est.Nivel"
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
        ' (11) COLUNA ESTOQUE IDEAL
        With clnEstoqueIdeal
            .DataPropertyName = "EstoqueIdeal"
            .HeaderText = "Est.Ideal"
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
        ' (11) COLUNA PRECO
        With clnPreco
            .DataPropertyName = "PVenda"
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
        ' (12) COLUNA ATIVO
        With clnAtivoImage
            .HeaderText = "Ativo"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        '--- adiciona as colunas editadas
        dgvItens.Columns.AddRange(New DataGridViewColumn() {clnSelect, clnRGProduto,
                                                            clnProduto, clnAutor, clnTipo, clnSubTipo, clnCategoria, clnFabricante,
                                                            clnEstoque, clnEstoqueNivel, clnEstoqueIdeal, clnPreco, clnAtivoImage})
        '
    End Sub
    '
    Private Sub dgvItens_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvItens.CellFormatting
        '
        '--- altera a IMAGEM ATIVO
        If e.ColumnIndex = clnAtivoImage.Index Then '--- coluna Imagem Situação
            Dim ativo As Boolean = DirectCast(dgvItens.Rows(e.RowIndex).DataBoundItem, clProduto).ProdutoAtivo
            '
            ' Imagem Ativo | Inativo
            If ativo Then
                e.Value = ImgAtivo
            Else
                e.Value = ImgInativo
            End If
            '
        End If
        '
    End Sub
    '
    '--- AO SELECIONAR O ITEM ALTERA A CONTAGEM
    Private Sub dgvItens_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellValueChanged
        '
        If e.ColumnIndex = 0 Then
            '
            chkAlterarProdutos.Checked = False
            AtualizaLabelSelecionados()
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
    '--- ATUALIZA LBLSELECIONADOS
    Private Sub AtualizaLabelSelecionados()
        '
        Dim sel As Integer = ItensSelecionadosCount()
        '
        If sel > 0 Then
            chkAlterarProdutos.Enabled = True
            '
            If sel = 1 Then
                lblSelTitulo.Visible = True
                lblSelecionados.Visible = True
                lblSelecionados.Text = "01 Produto Selecionado"
            Else
                lblSelTitulo.Visible = True
                lblSelecionados.Visible = True
                lblSelecionados.Text = Format(sel, "00") & " Produtos Selecionados"
            End If
            '
        Else
            lblSelTitulo.Visible = False
            lblSelecionados.Visible = False
            chkAlterarProdutos.Enabled = False
        End If
        '
    End Sub
    '
    Private Function ItensSelecionadosCount() As Integer
        '
        Dim sel As Integer = 0
        '
        For Each row As DataGridViewRow In dgvItens.Rows
            If row.Cells(0).Value = True Then
                sel += 1
            End If
        Next
        '
        Return sel
        '
    End Function
    '
#End Region '/ DATAGRID
    '
#Region "ACAO DOS BOTOES"
    '
    '--- PESQUISA NO BD
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        '
        Dim f As New frmProdutoListagemFiltro(_ProdutoAtivo,
                                              _Movimento,
                                              _Produto, _Autor,
                                              _IDProdutoTipo, _ProdutoTipo,
                                              _IDProdutoSubTipo, _ProdutoSubTipo,
                                              _IDCategoria, _ProdutoCategoria,
                                              _IDFabricante, _Fabricante, Me)
        '
        f.ShowDialog()
        If f.DialogResult <> DialogResult.OK Then Exit Sub
        '
        _ProdutoAtivo = f._ProdutoAtivo
        _Movimento = f._Movimento
        _Produto = f._Produto
        _Autor = f._Autor
        _IDProdutoTipo = f._IDProdutoTipo
        _ProdutoTipo = f._ProdutoTipo
        _IDProdutoSubTipo = f._IDProdutoSubTipo
        _ProdutoSubTipo = f._ProdutoSubTipo
        _IDCategoria = f._IDCategoria
        _ProdutoCategoria = f._ProdutoCategoria
        _IDFabricante = f._IDFabricante
        _Fabricante = f._Fabricante
        '
        PaginaAtual = 1
        '
    End Sub
	'
	Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click, miEditarProduto.Click
		'
		If dgvItens.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhum PRODUTO selecionado na listagem", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If
		'
		Dim clProd As clProduto = dgvItens.SelectedRows(0).DataBoundItem
		'
		'--- Verifica se o form Produto ja esta aberto
		Dim frm As Form = Nothing
		'
		For Each f As Form In Application.OpenForms
			If f.Name = "frmProduto" Then
				frm = f
			End If
		Next
		'
		If IsNothing(frm) Then '--- o frmProduto não esta aberto
			frm = New frmProduto(EnumFlagAcao.EDITAR, clProd, Me)
			frm.MdiParent = frmPrincipal
			frm.StartPosition = FormStartPosition.CenterScreen
			Me.Visible = False
			frm.Show()
		Else '--- o frmProduto já esta aberto
			DirectCast(frm, frmProduto).propProduto = clProd
			frm.Focus()
			Close()
		End If
		''
	End Sub
	'
	Private Sub dgvItens_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
		btnEditar_Click(New Object, New EventArgs)
	End Sub
	'
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        Dim prod As New clProduto
        '
        Dim frm As New frmProduto(EnumFlagAcao.INSERIR, prod)
        frm.MdiParent = frmPrincipal
        frm.StartPosition = FormStartPosition.CenterScreen
        Close()
        frm.Show()
        '
    End Sub
    '
    '--- IMPRIMIR LISTAGEM
    Private Sub btnPrintListagem_Click(sender As Object, e As EventArgs) Handles btnPrintListagem.Click
        MsgBox("Em implementação")
    End Sub
    '
    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        '
        _ProdutoAtivo = 1
        _Autor = Nothing
        _Produto = Nothing
        _IDProdutoTipo = Nothing
        _IDProdutoSubTipo = Nothing
        _IDCategoria = Nothing
        _IDFabricante = Nothing
        '
        prodLista.Clear()
        bindLista.ResetBindings(False)
        totalProdutos = 0
        PaginaAtual = 1
        '
    End Sub
    '
#End Region '// ACAO DOS BOTOES
    '
#Region "TRATAMENTO VISUAL"
    '
    '--- ALTERA O BACKGROUND DA LISTAGEM QUANDO RECEBE O FOCO
    Private Sub Listagem_GetLostFocus(sender As Object, e As EventArgs) _
        Handles dgvItens.GotFocus, dgvItens.LostFocus
        '
        'If dgvItens.ContainsFocus Then
        '    dgvItens.BorderStyle = BorderStyle.Fixed3D
        'Else
        '    dgvItens.BorderStyle = BorderStyle.None
        'End If
        '
    End Sub
    '
    Private Sub dgvItens_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellMouseEnter
        '
        If e.RowIndex = -1 Then Exit Sub
        '--- backup actual color
        BackupRowBackColor = dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor
        '--- change to new color
        dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Lavender
        '
    End Sub
    '
    Private Sub dgvItens_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellMouseLeave
        '
        If e.RowIndex = -1 Then Exit Sub
        '--- restore backuped color
        dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = BackupRowBackColor
        '
    End Sub
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER) DA LISTAGEM
    Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItens.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEditar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
#End Region '//TRATAMENTO VISUAL
    '
#Region "MENU ALTERACAO"
    '
    Private Sub chkAlterarProdutos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlterarProdutos.CheckedChanged
        '
        If chkAlterarProdutos.Checked = False And mnuAlteracao.Visible() Then
            mnuAlteracao.Hide()
        ElseIf Not mnuAlteracao.Visible() Then
            '
            '--- revela o menu
            Dim p As New Point(chkAlterarProdutos.Location.X + 4, Me.Height - chkAlterarProdutos.Height - chkAlterarProdutos.Location.Y - 4)
            mnuAlteracao.Show(Me, p, ToolStripDropDownDirection.AboveRight)
            '
        End If
        '
    End Sub
    '
    '--- SELECIONA TODOS OS PRODUTOS
    Private Sub chkSelecionarTudo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelecionarTudo.CheckedChanged
        '
        If dgvItens.Rows.Count = 0 Then
            chkSelecionarTudo.Checked = False
            Return
        End If
        '
        For Each r In dgvItens.Rows
            r.Cells(0).Value = chkSelecionarTudo.Checked
        Next
        '
    End Sub
    '
    '--- AO VISUALIZAR MENU ALTERACAO
    Private Sub mnuAlteracao_VisibleChanged(sender As Object, e As EventArgs) Handles mnuAlteracao.VisibleChanged
        If Not mnuAlteracao.Visible() And chkAlterarProdutos.Checked = True Then chkAlterarProdutos.Checked = False
    End Sub
    '
    Private Sub itemAtivar_Click(sender As Object, e As EventArgs) Handles itemAtivar.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = ItensSelecionadosCount()
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ATIVAR todos os produtos selecionados?" & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Ativar Produtos",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each r As DataGridViewRow In dgvItens.Rows
                    If r.Cells(0).Value = True Then
                        pBLL.ProdutoAtivarDesativar(r.DataBoundItem.IDProduto, True)
                    End If
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Ativação de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Ativar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemDesativar_Click(sender As Object, e As EventArgs) Handles itemDesativar.Click
        '
        '--- check Estoque
        For Each r As DataGridViewRow In dgvItens.Rows
            If r.Cells(0).Value = True Then
                Dim clProd As clProduto = r.DataBoundItem
                '
                If Not IsNothing(clProd.Estoque) AndAlso clProd.Estoque > 0 Then
                    '
                    AbrirDialog("Os produto " + clProd.Produto + " ainda possui quantidade em estoque..." + vbCrLf +
                                "Não é possível desativar um produto que possui estoque." + vbCrLf +
                                "Esse produto será retirado da seleção...",
                                "Produto com Estoque",
                                frmDialog.DialogType.OK,
                                frmDialog.DialogIcon.Information)
                    r.Cells(0).Value = False
                    '
                End If
                '
            End If
        Next
        '
        ' Verifica se ainda existem produtos selecionados
        Dim sel = ItensSelecionadosCount()
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente DESATIVAR todos os produtos selecionados?" & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Desativar Produtos",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each r As DataGridViewRow In dgvItens.Rows
                    If r.Cells(0).Value = True Then
                        pBLL.ProdutoAtivarDesativar(r.DataBoundItem.IDProduto, False)
                    End If
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Inativação de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inativar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarTipo_Click(sender As Object, e As EventArgs) Handles itemAlterarTipo.Click
        '
        ' Abre o dialog frmFabricantes para escolher novo Fabricante
        Dim frmF As New frmProdutoAlterarTipoSubTipo(Me)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        ' Define os novos valores
        Dim newTipo As String = frmF.propTipoEscolhido.ToUpper
        Dim newIDTipo As Integer? = frmF.propIDTipoEscolhido
        Dim newSubTipo As String = frmF.propSubTipoEscolhido.ToUpper
        Dim newIDSubTipo As Integer? = frmF.propIDSubTipoEscolhido
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR os produtos selecionados para:" & vbNewLine & vbNewLine &
                           "TIPO: " & IIf(String.IsNullOrEmpty(newTipo), "Não alterar", newTipo) & vbNewLine &
                           "SUBTIPO: " & IIf(String.IsNullOrEmpty(newSubTipo), "Não alterar", newSubTipo) & vbNewLine & vbNewLine &
                           "ATENÇÃO! Essa operação irá EXCLUIR a CATEGORIA do produto caso seja incompatível com o novo TIPO!",
                           "Alterar Tipo | Subtipo",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' Verifica se existe categoria incompativel e avisa ao usuário
        Dim idCat As Integer?
        Dim idTipo As Integer?
        Dim strIncompat As String = ""
        Dim prod As clProduto = Nothing
        '
        For Each r As DataGridViewRow In dgvItens.Rows
            If r.Cells(0).Value = True Then
                '
                prod = DirectCast(r.DataBoundItem, clProduto)
                '
                idCat = prod.IDCategoria
                idTipo = prod.IDProdutoTipo
                '
                If Not IsNothing(idCat) Then
                    '
                    If idTipo <> newIDTipo Then
                        strIncompat = strIncompat + prod.Produto.ToUpper + vbNewLine
                    End If
                    '
                End If
                '
            End If
        Next
        '
        If strIncompat.Length > 0 Then
            If MessageBox.Show("Existem Categorias incompatíveis com o NOVO TIPO nos seguintes produtos:" &
                               vbNewLine & vbNewLine &
                               strIncompat &
                               vbNewLine & vbNewLine &
                               "As CATEGORIAS desses produtos serão EXCLUÍDAS..." & vbNewLine &
                               "Deseja continuar assim mesmo?",
                               "Categorias Incompatíveis",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then Return
        End If
        '
        ' realiza a operacao de alteracao
        Try
            Dim pBLL As New ProdutoBLL
            Using pBLL
                '
                For Each r As DataGridViewRow In dgvItens.Rows
                    If r.Cells(0).Value = True Then
                        '
                        prod = DirectCast(r.DataBoundItem, clProduto)
                        '
                        ' verifica alteracao de tipo para limpar a categoria
                        If prod.IDProdutoTipo <> newIDTipo Then
                            pBLL.ProdutoAlterarTipoSubTipo(prod.IDProduto, newIDTipo, newIDSubTipo, True)
                        Else
                            pBLL.ProdutoAlterarTipoSubTipo(prod.IDProduto, newIDTipo, newIDSubTipo, False)
                        End If
                        '
                    End If
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarFabricante_Click(sender As Object, e As EventArgs) Handles itemAlterarFabricante.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = ItensSelecionadosCount()
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Abre o dialog frmFabricantes para escolher novo Fabricante
        Dim frmF As New frmFabricanteProcurar(Me)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        Dim newIDFab As Integer = frmF.propIDFab_Escolha
        Dim newFab As String = frmF.propFab_Escolha
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR o fabricante de todos os produtos selecionados" &
                           "para: " & vbNewLine & "NOVO FABRICANTE: " & newFab & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Alterar Fabricante",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each r As DataGridViewRow In dgvItens.Rows
                    If r.Cells(0).Value = True Then
                        pBLL.ProdutoAlterarFabricante(r.DataBoundItem.IDProduto, newIDFab)
                    End If
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarCategoria_Click(sender As Object, e As EventArgs) Handles itemAlterarCategoria.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = ItensSelecionadosCount()
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Verifica se todos os produtos selecionados possuem o mesmo TIPO de Produto
        Dim idTipo As Integer? = Nothing
        '
        For Each r As DataGridViewRow In dgvItens.Rows
            If r.Cells(0).Value = True Then
                '
                If IsNothing(idTipo) Then
                    idTipo = r.DataBoundItem.IDProdutoTipo
                End If
                '
                If idTipo <> r.DataBoundItem.IDProdutoTipo Then
                    '
                    MessageBox.Show("Não é possível alterar a CATEGORIA de Tipos de Produtos diferentes." & vbNewLine &
                                "Todos os produtos selecionados devem ser do mesmo TIPO.",
                                "Tipos Diferentes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                    Return
                    '
                End If
                '
            End If
        Next
        '
        ' Abre o dialog frmProdutoProcurarCategoria para escolher nova Categoria
        Dim frmF As New frmProdutoProcurarCategoria(Me, Nothing, idTipo)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        Dim newIDCat As Integer = frmF.propIdCategoria_Escolha
        Dim newCat As String = frmF.propCategoria_Escolha
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR a Categoria de todos os produtos selecionados" &
                           "para: " & vbNewLine & vbNewLine &
                           "NOVA CATEGORIA: " & newCat.ToUpper & vbNewLine & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Alterar Categoria",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each r As DataGridViewRow In dgvItens.Rows
                    If r.Cells(0).Value = True Then
                        pBLL.ProdutoAlterarCategoria(r.DataBoundItem.IDProduto, newIDCat)
                    End If
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarEstMinimoIdeal_Click(sender As Object, e As EventArgs) Handles itemAlterarEstMinimoIdeal.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = ItensSelecionadosCount()
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...",
                            "Selecione Produtos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return
        End If
        '
        ' Abre o dialog frmProdutoAlterarEstMinimoIdeal
        Dim frmF As New frmProdutoAlterarEstMinimoIdeal(Me)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        Dim newEstMinimo As Integer? = frmF.propEstoqueMinimo
        Dim newEstIdeal As Integer? = frmF.propEstoqueIdeal
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR o Est. Mínimo e/ou Ideal de todos os produtos selecionados?" &
                           "para: " & vbNewLine & vbNewLine &
                           "ESTOQUE MÍNIMO: " &
                           IIf(IsNothing(newEstMinimo), "Não Alterar", Format(newEstMinimo, "00")) &
                           vbNewLine &
                           "ESTOQUE IDEAL: " &
                           IIf(IsNothing(newEstIdeal), "Não Alterar", Format(newEstIdeal, "00")),
                           "Alterar Est. Mínimo/Ideal",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each r As DataGridViewRow In dgvItens.Rows
                    If r.Cells(0).Value = True Then
                        '
                        Dim prod = DirectCast(r.DataBoundItem, clProduto)
                        '
                        ' verifica se o est minimo é maior que o est ideal
                        If IsNothing(newEstMinimo) Then
                            '
                            ' verifica o estoque minimo atual do produto que será preservado
                            Dim estMinimo As Integer = prod.EstoqueNivel
                            '
                            If newEstIdeal < estMinimo Then
                                pBLL.ProdutoAlterarEstoqueMinimoIdeal(prod.IDProduto, _IDFilial, newEstIdeal, newEstIdeal)
                            Else
                                pBLL.ProdutoAlterarEstoqueMinimoIdeal(prod.IDProduto, _IDFilial, Nothing, newEstIdeal)
                            End If
                            '
                        ElseIf IsNothing(newEstIdeal) Then
                            '
                            ' verifica o estoque ideal atual do produto que será preservado
                            Dim estIdeal As Integer = prod.EstoqueIdeal
                            '
                            If newEstMinimo > estIdeal Then
                                pBLL.ProdutoAlterarEstoqueMinimoIdeal(prod.IDProduto, _IDFilial, newEstMinimo, newEstMinimo)
                            Else
                                pBLL.ProdutoAlterarEstoqueMinimoIdeal(prod.IDProduto, _IDFilial, newEstMinimo, Nothing)
                            End If
                            '
                        Else
                            '
                            pBLL.ProdutoAlterarEstoqueMinimoIdeal(prod.IDProduto, _IDFilial, newEstMinimo, newEstIdeal)
                            '
                        End If
                        '
                    End If
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region '// MENU ALTERACAO
    '
#Region "PAGINACAO"
    '
    '--- VERIFICA BTN DE NAVEGACAO
    '----------------------------------------------------------------------------------
    Private Sub VerificaNavegacaoButtons()
        '
        If _totalProdutos < 10 Then
            If _totalProdutos = 0 Then
                lblPaginas.Text = "Pag. 0 de 0"
            Else
                lblPaginas.Text = "Pag. 1 de 1"
            End If
            btnFirst.Enabled = False
            btnFirst.Image = My.Resources.First_32px_disabled
            btnPrev.Enabled = False
            btnPrev.Image = My.Resources.Previous_32px_disabled
            btnNext.Enabled = False
            btnNext.Image = My.Resources.Next_32px_disabled
            btnLast.Enabled = False
            btnLast.Image = My.Resources.Last_32px_disabled
        Else
            Dim pags As Integer = Math.Ceiling(_totalProdutos / _itemsPorPagina)
            lblPaginas.Text = "Pag. " & _paginaAtual & " de " & pags
            '
            If _paginaAtual = 1 Then
                btnFirst.Enabled = False
                btnFirst.Image = My.Resources.First_32px_disabled
                btnPrev.Enabled = False
                btnPrev.Image = My.Resources.Previous_32px_disabled
                btnNext.Enabled = True
                btnNext.Image = My.Resources.Next_32px
                btnLast.Enabled = True
                btnLast.Image = My.Resources.Last_32px
            ElseIf _paginaAtual = pags Then
                btnFirst.Enabled = True
                btnFirst.Image = My.Resources.First_32px
                btnPrev.Enabled = True
                btnPrev.Image = My.Resources.Previous_32px
                btnNext.Enabled = False
                btnNext.Image = My.Resources.Next_32px_disabled
                btnLast.Enabled = False
                btnLast.Image = My.Resources.Last_32px_disabled
            Else
                btnFirst.Enabled = True
                btnFirst.Image = My.Resources.First_32px
                btnPrev.Enabled = True
                btnPrev.Image = My.Resources.Previous_32px
                btnNext.Enabled = True
                btnNext.Image = My.Resources.Next_32px
                btnLast.Enabled = True
                btnLast.Image = My.Resources.Last_32px
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        PaginaAtual -= 1
    End Sub
    '
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        PaginaAtual += 1
    End Sub
    '
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        PaginaAtual = Math.Ceiling(_totalProdutos / _itemsPorPagina)
    End Sub
    '
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        PaginaAtual = 1
    End Sub
    '
#End Region '/ PAGINACAO
    '
#Region "MENU PRODUTO | ITENS"
    '
    ' CONTROLE DO MENU SUSPENSO
    '----------------------------------------------------------------------------------------------------------
    Private Sub dgvItens_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            '
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvItens.HitTest(e.X, e.Y)
            dgvItens.ClearSelection()
            '
            '---VERIFICAÇÕES NECESSÁRIAS
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvItens.Rows(hit.RowIndex).Cells(0).Selected = True
            dgvItens.Rows(hit.RowIndex).Selected = True
            '

            ' Habilita | Desabilita itens do menu
            Dim prod As clProduto = dgvItens.Rows(hit.RowIndex).DataBoundItem
            '
            If prod.ProdutoAtivo = True Then
                miAtivarProduto.Enabled = False
                miDesativarProduto.Enabled = True
            Else
                miAtivarProduto.Enabled = True
                miDesativarProduto.Enabled = False
            End If
            '
            ' revela menu
            mnuProduto.Show(c.PointToScreen(e.Location))
            '
        End If
        '
    End Sub

    Private Sub miFornecedores_Click(sender As Object, e As EventArgs) Handles miFornecedores.Click
        '
        If dgvItens.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum PRODUTO selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim clProd As clProduto = dgvItens.SelectedRows(0).DataBoundItem
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frm As Form = New frmProdutoFornecedor(clProd, Me)
            frm.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir o formulário de fornecedores do produto..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub

    Private Sub miTransacoes_Click(sender As Object, e As EventArgs) Handles miTransacoes.Click
        '
        If dgvItens.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum PRODUTO selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim clProd As clProduto = dgvItens.SelectedRows(0).DataBoundItem
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frm As Form = New frmProdutoTransacoes(clProd, Me)
            frm.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de transações do produto..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub

    Private Sub miAtivarProduto_Click(sender As Object, e As EventArgs) Handles miAtivarProduto.Click
        '
        If dgvItens.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum PRODUTO selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        ' realiza a ATIVACAO
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Using pBLL As New ProdutoBLL
                '
                pBLL.ProdutoAtivarDesativar(dgvItens.SelectedRows(0).DataBoundItem.IDProduto, True)
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Ativação de Produto realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Ativar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub

    Private Sub miDesativarProduto_Click(sender As Object, e As EventArgs) Handles miDesativarProduto.Click
        '
        If dgvItens.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum PRODUTO selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- check Estoque
        Dim clProd As clProduto = dgvItens.SelectedRows(0).DataBoundItem
        '
        If Not IsNothing(clProd.Estoque) AndAlso clProd.Estoque > 0 Then
            '
            AbrirDialog("Os produto " + clProd.Produto + " ainda possui quantidade em estoque..." + vbCrLf +
                        "Não é possível desativar um produto que possui estoque.",
                        "Produto com Estoque",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            '
            Exit Sub
            '
        End If
        '
        ' realiza a DESATIVACAO
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Using pBLL As New ProdutoBLL
                '
                pBLL.ProdutoAtivarDesativar(dgvItens.SelectedRows(0).DataBoundItem.IDProduto, False)
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Inativação de Produto realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Desativar Produtos..." & vbNewLine &
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
	'--- CHECK ESTOQUE NORMALIZADO
	'----------------------------------------------------------------------------------
	Private Sub miVerificarEstoqueNormalizado_Click(sender As Object, e As EventArgs) Handles miVerificarEstoqueNormalizado.Click
		'
		If dgvItens.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhum PRODUTO selecionado na listagem", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If
		'
		'--- check Estoque
		Dim clProd As clProduto = dgvItens.SelectedRows(0).DataBoundItem
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim eBLL As New EstoqueNormalizarBLL
			'
			Dim estoque As Integer = eBLL.GetEstoqueNormalizado(clProd.IDProduto, _IDFilial)
			'
			If Not IsNothing(clProd.Estoque) AndAlso clProd.Estoque <> estoque Then
				'
				Dim message As String = $"O Produto: {clProd.Produto}" + vbCrLf
				message += $"possui uma quantidade normalizada de estoque de {estoque:00} un" + vbCrLf
				message += $"porém a sua quantidade atual é divergente {clProd.Estoque:00} un"
				'
				AbrirDialog(message, "Estoque Divergente",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Exclamation)
				'
				Exit Sub
				'
			ElseIf IsNothing(clProd.Estoque) AndAlso estoque > 0 Then
				'
				Dim message As String = $"O Produto: {clProd.Produto}" + vbCrLf
				message += $"possui uma quantidade normalizada de estoque de {estoque:00} un" + vbCrLf
				message += $"porém no momento não possui nenhum movimento de estoque."
				'
				AbrirDialog(message, "Estoque Divergente",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Exclamation)
				'
				Exit Sub
				'
			Else
				Dim message As String = $"O Produto: {clProd.Produto}" + vbCrLf
				message += $"possui uma quantidade normalizada de estoque de {estoque:00} un" + vbCrLf
				message += $"O Estoque está correto!"
				'
				AbrirDialog(message, "Estoque Correto",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Information)
				'
				Exit Sub
				'
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Verificar o Estoque..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
#End Region '/ MENU PRODUTO | ITENS
	'
End Class
