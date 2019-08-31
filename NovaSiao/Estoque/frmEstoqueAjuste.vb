Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmEstoqueAjuste
    '
    Private _Ajuste As clEstoqueAjuste
    Private _ItensList As List(Of clEstoqueAjusteItem)
    '
    Dim eBLL As New EstoqueAjusteBLL
    '
    Private bindAjuste As New BindingSource
    Private WithEvents bindItem As New BindingSource
    '
    Private _Bloq As Boolean
    Private _IDFilial As Integer
    Private _IDUserAtual As Integer
    Private _formOrigem As Form
    Private _ItemPanelVisible As EnumFlagAcao?
    '
    Private _RGAlterado As Boolean = False '--> detecta alteracao do RGProduto
    '
    Private mnuItensAcao As New ContextMenuStrip
    Private WithEvents mnuItemEditar As New ToolStripMenuItem
    Private WithEvents mnuItemInserir As New ToolStripMenuItem
    Private WithEvents mnuItemExcluir As New ToolStripMenuItem
    Private ToolStripSeparator1 As New ToolStripSeparator
    '
#Region "LOAD"
    '
    Public Sub New(Ajuste As clEstoqueAjuste, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- define Filial
        _IDFilial = Obter_FilialPadrao()
        _IDUserAtual = UsuarioAtual.IdUser
        '
        '--- Bind Ajuste
        _Ajuste = Ajuste
        '
        If _Ajuste.IDEstoqueAjuste = 0 Then '--> Novo Ajuste
            _Ajuste.AjusteData = Today
            _Ajuste.AjusteOrigem = 2 '--> correcao de estoque
            _Ajuste.ApelidoFilial = ObterDefault("FilialDescricao")
            _Ajuste.IDFilial = _IDFilial
            _Ajuste.IDUser = _IDUserAtual
            _Ajuste.UsuarioApelido = UsuarioAtual.UsuarioApelido
            _Ajuste.ValorMovimentado = 0
            _Ajuste.Bloqueado = False
        End If
        '
        bindAjuste.DataSource = _Ajuste
        PreencheBindAjuste()
        propBloq = _Ajuste.Bloqueado
        '
        '--- Get List of Itens de Ajustes de Estoque Inicial
        FormataDataGrid()
        getItensList()
        bindItem.DataSource = _ItensList
        PreencheBindItem()
        '
        '--- calcula o Total
        AtualizaTotalGeral()
        '
        '--- evento que detecta alteracao do RGProduto
        _RGAlterado = False
        '
        _formOrigem = formOrigem
        InicializarMenuItem()
        '
        '--- add Handler change current Ajuste
        AddHandler bindItem.CurrentChanged, AddressOf HandlerRGAlterado
        '
    End Sub
    '
    '--- RETORNA TODOS OS ITENS DA VENDA
    Private Sub getItensList()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _ItensList = eBLL.GetAjusteItens_List(_Ajuste.IDEstoqueAjuste, _IDFilial)
            dgvEntradas.DataSource = bindItem
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a listagem de Itens do Ajuste de Estoque..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '
    Private Property propItemPanelVisible As EnumFlagAcao?
        '
        Get
            Return _ItemPanelVisible
        End Get
        '
        Set(value As EnumFlagAcao?)
            _ItemPanelVisible = value
            '
            If Not IsNothing(_ItemPanelVisible) Then
                pnlItem.Visible = True
                '
                '--- desabilita todos os controles
                For Each c As Control In Me.Controls
                    If c.Name <> "pnlItem" Then c.Enabled = False
                Next
                '
                Opacity = 0.5
                If _ItemPanelVisible = EnumFlagAcao.INSERIR Then
                    txtRGProduto.ReadOnly = False
                    txtRGProduto.Focus()
                    txtQuantidadeFinal.Text = 0
                ElseIf _ItemPanelVisible = EnumFlagAcao.EDITAR Then
                    txtRGProduto.ReadOnly = True
                    txtQuantidadeFinal.Text = Format(bindItem.Current.QuantidadeFinal, "00")
                    txtQuantidadeFinal.Focus()
                End If
                '
                AddHandler Me.KeyDown, AddressOf Handler_Me_KeyDown
                '
            Else
                '
                pnlItem.Visible = False
                '
                '--- habilita todos os controles
                For Each c As Control In Controls
                    If c.Name <> "pnlItem" Then c.Enabled = True
                Next
                '
                Opacity = 1
                dgvEntradas.Focus()
                '
                RemoveHandler Me.KeyDown, AddressOf Handler_Me_KeyDown
                '
            End If
            '
        End Set
        '
    End Property
    '
    Private Property propBloq As Boolean
        '
        Get
            Return _Bloq
        End Get
        '
        Set(value As Boolean)
            '
            _Bloq = value
            '
            If Not _Bloq Then
                '
                lblSituacao.Text = "Inserindo Itens"
                btnFinalizar.Enabled = True
                btnCancelar.Text = "&Cancelar"
                txtObservacao.ReadOnly = False
                '
            Else
                '
                lblSituacao.Text = "Bloqueada"
                btnFinalizar.Enabled = False
                btnCancelar.Text = "&Fechar"
                txtObservacao.ReadOnly = True
                '
            End If
            '
        End Set
        '
    End Property
    '
#End Region '// LOAD
    '
#Region "DATABINDING"
    '
    Private Sub PreencheBindAjuste()
        '
        lblIDEstoqueAjuste.DataBindings.Add("Text", bindAjuste, "IDEstoqueAjuste", True, DataSourceUpdateMode.OnPropertyChanged)
        lblAjusteData.DataBindings.Add("Text", bindAjuste, "AjusteData", True, DataSourceUpdateMode.OnPropertyChanged)
        lblUsuarioApelido.DataBindings.Add("Text", bindAjuste, "UsuarioApelido", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindAjuste, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblSituacao.DataBindings.Add("Text", bindAjuste, "BloqueadoDescricao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindAjuste, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' formata os valores do databinding
        AddHandler lblIDEstoqueAjuste.DataBindings("text").Format, AddressOf FormatRG
        AddHandler lblSituacao.DataBindings("text").Format, AddressOf FormatBloqueado
        '
    End Sub
    '
    Private Sub PreencheBindItem()
        '
        txtRGProduto.DataBindings.Add("Text", bindItem, "RGProduto", True, DataSourceUpdateMode.OnPropertyChanged)
        'txtQuantidade.DataBindings.Add("Text", bindItem, "Quantidade", True, DataSourceUpdateMode.OnPropertyChanged)
        lblProduto.DataBindings.Add("Text", bindItem, "Produto", True, DataSourceUpdateMode.OnPropertyChanged)
        lblPreco.DataBindings.Add("Text", bindItem, "Preco", True, DataSourceUpdateMode.OnPropertyChanged)
        lblEstoque.DataBindings.Add("Text", bindItem, "QuantidadeAnterior", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' formata os valores do databinding
        AddHandler txtRGProduto.DataBindings("text").Format, AddressOf FormatRG
        AddHandler lblPreco.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblEstoque.DataBindings("text").Format, AddressOf Format00
        'AddHandler txtQuantidade.DataBindings("text").Format, AddressOf Format00
        '
    End Sub
    '
    '--- HANDLER ON CHANGE CURRENT ITEM
    '----------------------------------------------------------------------------------
    Private Sub HandlerRGAlterado()
        '
        Dim itemAtual As clEstoqueAjusteItem = DirectCast(bindItem.Current, clEstoqueAjusteItem)
        '
        If Not IsNothing(itemAtual) Then
            '
            _RGAlterado = False
            AddHandler itemAtual.AoAlterarRGProduto, AddressOf RGProdutoAlterado
            '
        End If
        '
    End Sub
    '
    '--- DETECTA QUANDO O IDPRODUTO FOI ALTERADO
    '----------------------------------------------------------------------------------
    Private Sub RGProdutoAlterado()
        _RGAlterado = True
    End Sub
    '
    ' FORMATA OS BINDINGS
    '----------------------------------------------------------------------------------
    Private Sub FormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        '
        If e.Value = 0 Then
            e.Value = "Novo"
        Else
            e.Value = Format(e.Value, "0000")
        End If
        '
    End Sub
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    Private Sub FormatDT(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "dd/MM/yyyy")
    End Sub
    Private Sub Format00(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        If Not IsNothing(e.Value) Then
            e.Value = Format(CInt(e.Value), "00")
        End If
    End Sub
    Private Sub FormatBloqueado(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "Ajuste " & e.Value).ToUpper
    End Sub
    '
#End Region '// DATABINDING
    '
#Region "PREENCHE FORMATA DATAGRID"
    '
    '--- FORMATA E PREENCHE OS ITENS
    Friend Sub FormataDataGrid()
        '
        ' altera as propriedades importantes
        dgvEntradas.MultiSelect = False
        dgvEntradas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEntradas.ColumnHeadersVisible = True
        dgvEntradas.AllowUserToResizeRows = False
        dgvEntradas.AllowUserToResizeColumns = False
        dgvEntradas.RowHeadersVisible = True
        dgvEntradas.RowHeadersWidth = 30
        dgvEntradas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvEntradas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvEntradas.StandardTab = True
        '
        '--- formata as colunas do datagrid
        PreencheColunas_Itens()
        '
    End Sub
    '
    '--- FORMATA COLUNAS
    Private Sub PreencheColunas_Itens()
        '
        '--- limpa as colunas do datagrid
        dgvEntradas.Columns.Clear()
        dgvEntradas.AutoGenerateColumns = False
        '
        ' (0) COLUNA RGProduto
        With clnRGProduto
            .DataPropertyName = "RGProduto"
            .HeaderText = "Reg."
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA PRODUTO
        With clnProduto
            .HeaderText = "Produto"
            .DataPropertyName = "Produto"
            .Width = 430
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA QUANTIDADE ANTERIOR
        With clnQuantidadeAnterior
            .HeaderText = "Qt. Ant"
            .DataPropertyName = "QuantidadeAnterior"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (3) COLUNA QUANTIDADE MOVIMENTADA
        With clnQuantidade
            .HeaderText = "Qt. Mov"
            .DataPropertyName = "Quantidade"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (4) COLUNA QUANTIDADE FINAL
        With clnQuantidadeFinal
            .HeaderText = "Qt. Final"
            .DataPropertyName = "QuantidadeFinal"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (5) COLUNA PRECO
        With clnPreco
            .HeaderText = "Preço"
            .DataPropertyName = "Preco"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (6) COLUNA SUB TOTAL
        With clnSubTotal
            .HeaderText = "Total"
            .DataPropertyName = "Total"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        dgvEntradas.Columns.AddRange({clnRGProduto,
                                     clnProduto,
                                     clnQuantidadeAnterior,
                                     clnQuantidade,
                                     clnQuantidadeFinal,
                                     clnPreco,
                                     clnSubTotal})
        '
    End Sub
    '
    '--- FORMATA O DATAGRID
    Private Sub dgvEntradas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEntradas.CellFormatting
        '
        '--- altera a coluna 3
        If e.ColumnIndex = 3 Then '--- coluna Movimentacao
            '
            If e.Value >= 0 Then
                e.Value = "+" & Format(e.Value, "00")
                e.CellStyle.ForeColor = Color.DarkBlue
                dgvEntradas.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(219, 228, 240) 'Color.Azure
                dgvEntradas.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
            Else
                e.Value = Format(e.Value, "00")
                e.CellStyle.ForeColor = Color.Red
                dgvEntradas.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                dgvEntradas.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Firebrick
            End If
            '
        End If
        '
    End Sub
    '
#End Region ' // PREENCHE FORMATA DATAGRID
    '
#Region "MOVIMENTA ITENS CRUD PRODUTOS"
    '
    '--- INSERE UM NOVO ITEM NA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------
    Private Sub Inserir_Item()
        '
        '--- Verifica se esta Bloqueado
        If bindAjuste.Current.Bloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        bindItem.AddNew()
        propItemPanelVisible = EnumFlagAcao.INSERIR
        '
    End Sub
    '    
    '--- EDITA UM ITEM NA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------
    Private Sub Editar_Item()
        '
        '--- Verifica se esta Bloqueado
        If bindAjuste.Current.Bloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        propItemPanelVisible = EnumFlagAcao.EDITAR
        '
    End Sub
    '    
    '--- EXCLUI UM ITEM NA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------
    Private Sub Excluir_Item()
        '
        '--- Verifica se esta Bloqueado
        If bindAjuste.Current.Bloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        If IsNothing(bindItem.Current) Then Exit Sub
        '
        '--- remove the item of listagem
        bindItem.RemoveCurrent()
        '
        '--- Resolve ValorMovimentado of Ajuste Atual
        _Ajuste.ValorMovimentado = _ItensList.Sum(Function(y) y.Total)
        '
        '--- calcula valor total
        AtualizaTotalGeral()
        '
    End Sub
    '
    '----------------------------------------------------------------------------------
    '--- PRESS OK (EXECUTE INSERT OR EDIT OPERATIONS)
    '----------------------------------------------------------------------------------
    Private Sub btnPanelOK_Click(sender As Object, e As EventArgs) Handles btnPanelOK.Click
        '
        '--- Verifica se existe produto
        '----------------------------------------------------------------------------------
        If txtRGProduto.Text.Trim.Length = 0 OrElse lblProduto.Text.Length = 0 Then
            MessageBox.Show("Favor definir o produto a ser ajustado.",
                            "Escolha o Produto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRGProduto.Focus()
            txtRGProduto.SelectAll()
            Return
        End If
        '
        '--- Verifica a quantidade Final inserida
        '----------------------------------------------------------------------------------
        If txtQuantidadeFinal.Text.Trim.Length = 0 Then
            MessageBox.Show("Favor inserir a quantidade Real/Final do estoque do produto a ser ajustado.",
                            "Quantidade Real", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQuantidadeFinal.Focus()
            txtQuantidadeFinal.SelectAll()
            Return
        End If
        '
        If CInt(txtQuantidadeFinal.Text) < 0 Then
            MessageBox.Show("A quantidade REAL inserida não pode ser menor que Zero." &
                            vbNewLine & "Favor inserir uma quantidade diferente ou cancele a operação.",
                            "Sem alteração", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQuantidadeFinal.Focus()
            txtQuantidadeFinal.SelectAll()
            Return
        End If
        '
        If CInt(txtQuantidadeFinal.Text) = bindItem.Current.QuantidadeAnterior Then
            MessageBox.Show("A quantidade REAL inserida não pode ser igual à quantidade ATUAL no Estoque do produto." &
                            vbNewLine & "Favor inserir uma quantidade diferente ou cancele a operação.",
                            "Sem alteração", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQuantidadeFinal.Focus()
            txtQuantidadeFinal.SelectAll()
            Return
        End If
        '
        '--- Resolve ValorMovimentado of Ajuste Atual
        _Ajuste.ValorMovimentado = _ItensList.Sum(Function(y) y.Total)
        '
        '--- Atualiza Total
        AtualizaTotalGeral()
        '
        '--- Bind
        bindItem.EndEdit()
        bindItem.ResetBindings(False)
        propItemPanelVisible = Nothing
        '
    End Sub
    '
    '----------------------------------------------------------------------------------
    '--- PRESS CANCEL
    '----------------------------------------------------------------------------------
    Private Sub btnPanelCancel_Click(sender As Object, e As EventArgs) Handles btnPanelCancel.Click
        '
        bindItem.CancelEdit()
        propItemPanelVisible = Nothing
        '
    End Sub
    '
    '==========================================================================================
    ' INSERE O AJUSTE NO BD
    '==========================================================================================
    'Private Function Ajuste_InserirDB(ajt As clEstoqueAjuste, dbTran As Object) As clEstoqueAjuste
    '    '
    '    Try
    '        '--- Ampulheta ON
    '        Cursor = Cursors.WaitCursor
    '        '
    '        '--- this insert and block all previous ajuste
    '        Return eBLL.InsertAjusteEstoqueInicial(ajt, dbTran)
    '        '
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        '--- Ampulheta OFF
    '        Cursor = Cursors.Default
    '    End Try
    '    '
    'End Function
    '
    '==========================================================================================
    ' INSERE O ITEM NO BD
    '==========================================================================================
    'Private Function Item_InserirBD(dbTran As Object) As Integer
    '    '
    '    Try
    '        Return eBLL.InserirItem(bindItem.Current, bindAjuste.Current.AjusteData, dbTran).IDEstoqueItem
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    '
    'End Function
    '
    '==========================================================================================
    ' EDITA O ITEM NO BD
    '==========================================================================================
    'Private Function Item_EditarBD(dbTran As Object) As Boolean
    '    '
    '    Try
    '        eBLL.EditarItem(bindItem.Current, bindAjuste.Current.AjusteData, dbTran)
    '        Return True
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    '
    'End Function
    '
    '==========================================================================================
    ' EXCLUI O ITEM NO BD
    '==========================================================================================
    'Private Function Item_ExcluirBD() As Boolean
    '    '
    '    Try
    '        eBLL.ExcluirItem(bindItem.Current)
    '        Return True
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    '
    'End Function
    '
    '---------------------------------------------------------------------------------------------------
    ' CRIA TECLA DE ATALHO PARA INSERIR/EDITAR PRODUTO
    '---------------------------------------------------------------------------------------------------
    Private Sub dgvEntradas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvEntradas.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Inserir_Item()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            Editar_Item()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Excluir_Item()
        End If
        '
    End Sub
    '
    Private Sub dgvEntradas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEntradas.CellDoubleClick
        Editar_Item()
    End Sub
    '
#End Region '// MOVIMENTA ITENS CRUD PRODUTOS
    '
#Region "VALIDA RGPRODUTO OU COD BARRAS"
    '
    Private Sub txtRGProduto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRGProduto.Validating
        '
        '-- Verifica se o controle RGProduto sofreu alguma alteracao
        If Not _RGAlterado Then Exit Sub
        '
        '-- Verifica se o panel esta open
        If IsNothing(propItemPanelVisible) Then Exit Sub
        '
        If ObterProdutoPeloRG() = False Then e.Cancel = True
        '
    End Sub
    '
    '--- OBTEM AS INFORMACOES DO PRODUTO APOS INSERIR RGPRODUTO
    Private Function ObterProdutoPeloRG() As Boolean
        '
        '--- obter as informacoes do produto digitado
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim itemBLL As New TransacaoItemBLL
            Dim ItemProduto As clTransacaoItem = itemBLL.TransacaoItem_Get_New(txtRGProduto.Text, _IDFilial)
            '
            If String.IsNullOrEmpty(ItemProduto.Produto) Then
                MessageBox.Show("Registro de Produto não encontrado..." & vbNewLine &
                                "Favor digitar um Registro válido.", "Reg. Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '
                txtRGProduto.Clear()
                Return False
                '
            End If
            '
            '--- Preenche a classe clItem
            With DirectCast(bindItem.Current, clEstoqueAjusteItem)
                .Produto = ItemProduto.Produto
                .PVenda = ItemProduto.PVenda
                .PCompra = ItemProduto.PCompra
                .IDProduto = ItemProduto.IDProduto
                .CodBarrasA = ItemProduto.CodBarrasA
                .ProdutoAtivo = ItemProduto.ProdutoAtivo
                .Estoque = ItemProduto.Estoque
                If .Estoque > 0 Then
                    MessageBox.Show("CUIDADO..." & vbNewLine &
                                    "Esse produto possui: " & .Estoque & " unidades em estoque" & vbNewLine & vbNewLine &
                                    "Lembre-se que aqui você está adicionando mais quantidade...",
                                    "Produto com Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                .Reservado = ItemProduto.Reservado
                .IDFilial = ItemProduto.IDFilial
                .RGProduto = ItemProduto.RGProduto
                .Preco = ItemProduto.PCompra * (1 - ItemProduto.DescontoCompra / 100)
                .QuantidadeAnterior = ItemProduto.Estoque
                '
            End With
            '
            bindItem.ResetBindings(True)
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu ao obter informações do produto no BD..." & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
    Private Sub txtQuantidade_Validated(sender As Object, e As EventArgs) Handles txtQuantidadeFinal.Validated
        '
        Dim Item = DirectCast(bindItem.Current, clEstoqueAjusteItem)
        If IsNothing(Item) Then Exit Sub
        Item.Quantidade = txtQuantidadeFinal.Text - Item.Estoque
        '
    End Sub
    '
#End Region '/ VALIDA PRODUTO
    '
#Region "FORMATACAO E FLUXO"
    '
    '--- SOMENTE PERMITE NUMEROS NO TEXTBOX
    '---------------------------------------------------------------------------------------------------
    Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGProduto.KeyPress, txtQuantidadeFinal.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    '
    ' CONVERTE ENTER EM TAB DE ALGUNS CONTROLES
    '---------------------------------------------------------------------------------------------------
    Private Sub Text_KeyDown(sender As Object, e As KeyEventArgs) Handles _
            txtObservacao.KeyDown, txtRGProduto.KeyDown, txtQuantidadeFinal.KeyDown
        '
        '--- Se for o campo observacao, verifica se esta preenchido com algum texto
        '--- Se esta preenchido entao permite que o ENTER funcione como nova linha
        If DirectCast(sender, TextBox).Name = "txtObservacao" AndAlso txtObservacao.Text.Trim.Length > 0 Then
            Exit Sub
        End If
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    ' ALTERA A COR DO DATAGRIDVIEW QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvEntradas_GotFocus(sender As Object, e As EventArgs) Handles dgvEntradas.GotFocus
        '
        Dim c As Color = Color.FromArgb(224, 232, 243)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.Fixed3D
        '
    End Sub
    '
    Private Sub dgvEntradas_LostFocus(sender As Object, e As EventArgs) Handles dgvEntradas.LostFocus
        '
        Dim c As Color = Color.FromArgb(209, 215, 220)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.None
        '
    End Sub
    '
    '--- PRESS ADD TO OPEN FIND FORM | PRESS N TO NEW PRODUTO
    '----------------------------------------------------------------------------------
    Private Sub frmCompraItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            '
            '--- verifica qual controle esta selecionado
            If ActiveControl Is txtRGProduto Then '--- RGProduto
                e.Handled = True
                Dim p As New frmProdutoProcurar(Me, False)
                '
                p.ShowDialog()
                '
                If p.DialogResult = DialogResult.OK Then
                    txtRGProduto.Text = p.ProdutoEscolhido.RGProduto
                    SendKeys.Send("{Tab}")
                End If
            End If
            '
        ElseIf e.KeyCode = Keys.N And propItemPanelVisible = EnumFlagAcao.INSERIR Then
            e.Handled = True
            '
            Dim prod As New clProduto
            Dim f As New frmProduto(EnumFlagAcao.INSERIR, prod, Me)
            '
            f.ShowDialog()
            '
            If f.DialogResult = DialogResult.OK Then
                txtRGProduto.Text = f.ProdutoEscolhido.RGProduto
                SendKeys.Send("{Tab}")
            End If
            '
        End If
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        '
        '--- check if is blocked
        '----------------------------------------------------------------------------------
        If propBloq = True Then
            Close()
            If My.Application.OpenForms.Count = 1 Then MostraMenuPrincipal()
            Return
        End If
        '
        '--- check if exists Items
        '----------------------------------------------------------------------------------
        If _ItensList.Count = 0 Then
            MessageBox.Show("Esse ajuste não possui nenhum produto inserido..." & vbNewLine & vbNewLine &
                            "Favor inserir produtos antes de efetuar o Ajuste.",
                            "Nenhum Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        '--- ask to user
        '----------------------------------------------------------------------------------
        If MessageBox.Show("Você deseja realmente efetuar este ajuste no estoque da Filial: " &
                           lblFilial.Text.ToUpper & "?" &
                           vbNewLine & vbNewLine &
                           "Após efetuar, não haverá possibilidade de reverter a mudança...",
                           "Efetuar Ajuste",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            '
            Return
            '
        End If
        '
        '--- create a new Transaction
        '----------------------------------------------------------------------------------
        Dim eBLL As New EstoqueAjusteBLL
        Dim tBLL As New AcessoControlBLL
        Dim dbTran As Object = tBLL.GetNewAcessoWithTransaction
        '
        '--- Save the new Ajuste
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- check total value
            _Ajuste.ValorMovimentado = AtualizaTotalGeral()
            '
            '--- this insert and block the ajuste
            _Ajuste.IDEstoqueAjuste = eBLL.InsertEstoqueAjuste(_Ajuste, dbTran).IDEstoqueAjuste
            propBloq = True
            '
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu ao salvar o Ajuste de Estoque no BD..." & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            tBLL.RollbackAcessoWithTransaction(dbTran)
            Return
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- Save the Itens 
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            For Each item As clEstoqueAjusteItem In bindItem
                item.IDEstoqueAjuste = _Ajuste.IDEstoqueAjuste
                eBLL.InserirItem(item, _Ajuste.AjusteData, dbTran)
            Next
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu ao salvar os Itens de Ajuste de Estoque no BD..." & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            tBLL.RollbackAcessoWithTransaction(dbTran)
            Return
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- Commit Transaction
        '----------------------------------------------------------------------------------
        tBLL.CommitAcessoWithTransaction(dbTran)
        '
        MessageBox.Show("Ajuste efetuado com sucesso!", "Ajuste Salvo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        '
        '-- Close the Form
        '----------------------------------------------------------------------------------
        Close()
        If My.Application.OpenForms.Count = 1 Then MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
        '
        '--- check if is blocked
        '----------------------------------------------------------------------------------
        If propBloq = False OrElse _ItensList.Count = 0 Then
            '
            '--- ask to user
            '----------------------------------------------------------------------------------
            If MessageBox.Show("Você deseja realmente fechar e cancelar o ajuste de estoque? " & vbNewLine &
                               "Nenhuma operação de ajuste foi realizada ainda...",
                               "Cancelar Ajuste",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then
                '
                Return
                '
            End If
            '
        End If
        '
        Close()
        If My.Application.OpenForms.Count = 1 Then MostraMenuPrincipal()
        Return
        '
    End Sub
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS"
    '
    ' ATUALIZA O TOTAL DOS PRODUTOS ENTRADOS
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalGeral() As Double
        '
        Dim T As Double = 0
        '
        T = _ItensList.Sum(Function(x) x.Total)
        '
        lblTotalGeral.Text = Format(T, "c")
        Return T
        '
    End Function
    '
    '------------------------------------------------------------------------------------------
    ' FAZ A TECLA ESC FECHAR O PANEL
    '------------------------------------------------------------------------------------------
    Private Sub Handler_Me_KeyDown(sender As Object, e As KeyEventArgs)
        '
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnPanelCancel_Click(sender, e)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.SlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub me_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = False
            'Dim pnl As Panel = _formOrigem.Controls("Panel1")
            'pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub me_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = True
            'Dim pnl As Panel = _formOrigem.Controls("Panel1")
            'pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
#Region "BLOQUEIO DE REGISTROS"
    '
    ' FUNCAO QUE CONFERE REGISTRO BLOQUEADO E EMITE MENSAGEM PADRAO
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroBloqueado() As Boolean
        '
        If propBloq Then
            MessageBox.Show("Esse registro de Troca está BLOQUEADO para alterações..." & vbNewLine &
                            "Não é possível adicionar produtos ou alterar algum dado!",
                            "Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
#End Region
    '
#Region "CONTROLE MENU CONTEXTO"
    '
    Private Sub InicializarMenuItem()
        '
        ' verifica se já esta inicialzado
        If mnuItensAcao.Items.Count > 1 Then Exit Sub ' ja esta inicializado
        '
        'mnuItensAcao
        '
        mnuItensAcao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemEditar, Me.mnuItemInserir, Me.ToolStripSeparator1, Me.mnuItemExcluir})
        mnuItensAcao.Name = "mnuItensAcao"
        mnuItensAcao.Size = New System.Drawing.Size(181, 98)
        '
        'mnuItemEditar
        '
        mnuItemEditar.Image = My.Resources.editar
        mnuItemEditar.Name = "mnuItemEditar"
        mnuItemEditar.Size = New System.Drawing.Size(180, 22)
        mnuItemEditar.Text = "Editar Item"
        '
        'mnuItemInserir
        '
        mnuItemInserir.Image = My.Resources.add
        mnuItemInserir.Name = "mnuItemInserir"
        mnuItemInserir.Size = New System.Drawing.Size(180, 22)
        mnuItemInserir.Text = "Inserir Produto"
        '
        'ToolStripSeparator1
        '
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'mnuItemExcluir
        '
        mnuItemExcluir.Image = My.Resources.delete
        mnuItemExcluir.Name = "mnuItemExcluir"
        mnuItemExcluir.Size = New System.Drawing.Size(180, 22)
        mnuItemExcluir.Text = "Excluir Produto"
    End Sub
    '
    '
    Private Sub dgvEntradas_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvEntradas.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            'Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvEntradas.HitTest(e.X, e.Y)
            dgvEntradas.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            '
            ' seleciona o ROW
            dgvEntradas.CurrentCell = dgvEntradas.Rows(hit.RowIndex).Cells(1)
            dgvEntradas.Rows(hit.RowIndex).Selected = True
            '
            ' verifica bloqueio
            If bindAjuste.Current.Bloqueado = True Then
                mnuItemEditar.Enabled = False
                mnuItemExcluir.Enabled = False
            Else
                mnuItemEditar.Enabled = True
                mnuItemExcluir.Enabled = True
            End If
            '
            'mnuItens.Show(dgvEntradaBloqens, c.PointToScreen(e.Location))
            mnuItensAcao.Show(dgvEntradas, e.Location)
            '
        End If
        '
    End Sub
    '
    Private Sub MenuItemEditar_Click(sender As Object, e As EventArgs) Handles mnuItemEditar.Click
        Editar_Item()
    End Sub
    '
    Private Sub MenuItemInserir_Click(sender As Object, e As EventArgs) Handles mnuItemInserir.Click
        Inserir_Item()
    End Sub
    '
    Private Sub MenuItemExcluir_Click(sender As Object, e As EventArgs) Handles mnuItemExcluir.Click
        Excluir_Item()
    End Sub
    '
#End Region '/ CONTROLE MENU CONTEXTO
    '
End Class
