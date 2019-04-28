Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmEstoqueInicial
    '
    Private _AjusteList As List(Of clEstoqueAjuste)
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
    Public Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- define Filial
        _IDFilial = Obter_FilialPadrao()
        lblFilial.Text = ObterDefault("FilialDescricao")
        _IDUserAtual = UsuarioAtual.IdUser
        '
        '--- Get List of Ajustes (Estoque Inicial)
        getAjustes()
        bindAjuste.DataSource = _AjusteList
        PreencheBindAjuste()

        '--- if not exists Ajuste create NEW
        If _AjusteList.Count = 0 Then
            '
            Dim ajt As New clEstoqueAjuste With {
                .AjusteData = Today,
                .IDUser = _IDUserAtual,
                .UsuarioApelido = UsuarioAtual.UsuarioApelido,
                .IDFilial = _IDFilial,
                .ApelidoFilial = lblFilial.Text
            }
            '
            _AjusteList.Add(ajt)
            bindAjuste.ResetBindings(False)
            '
        Else
            txtObservacao.Text = _AjusteList.First().Observacao
            btnObservacaoSave.Visible = False
        End If
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
                ElseIf _ItemPanelVisible = EnumFlagAcao.EDITAR Then
                    txtRGProduto.ReadOnly = True
                    txtQuantidade.Focus()
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
                btnFinalizar.Text = "&Concluir"
                txtObservacao.ReadOnly = False
                '
            Else
                '
                lblSituacao.Text = "Bloqueada"
                btnFinalizar.Text = "&Fechar"
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
        lblID.DataBindings.Add("Text", bindAjuste, "IDEstoqueAjuste", True, DataSourceUpdateMode.OnPropertyChanged)
        lblAjusteData.DataBindings.Add("Text", bindAjuste, "AjusteData", True, DataSourceUpdateMode.OnPropertyChanged)
        lblUsuarioApelido.DataBindings.Add("Text", bindAjuste, "UsuarioApelido", True, DataSourceUpdateMode.OnPropertyChanged)
        lblBloqueado.DataBindings.Add("Text", bindAjuste, "BloqueadoDescricao", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' formata os valores do databinding
        AddHandler lblID.DataBindings("text").Format, AddressOf FormatRG
        AddHandler lblBloqueado.DataBindings("text").Format, AddressOf FormatBloqueado
        '
    End Sub
    '
    Private Sub PreencheBindItem()
        '
        txtRGProduto.DataBindings.Add("Text", bindItem, "RGProduto", True, DataSourceUpdateMode.OnPropertyChanged)
        txtQuantidade.DataBindings.Add("Text", bindItem, "Quantidade", True, DataSourceUpdateMode.OnPropertyChanged)
        lblProduto.DataBindings.Add("Text", bindItem, "Produto", True, DataSourceUpdateMode.OnPropertyChanged)
        lblPreco.DataBindings.Add("Text", bindItem, "Preco", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTotal.DataBindings.Add("Text", bindItem, "Total", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' formata os valores do databinding
        AddHandler txtRGProduto.DataBindings("text").Format, AddressOf FormatRG
        AddHandler lblPreco.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblTotal.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtQuantidade.DataBindings("text").Format, AddressOf Format00
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
            _RGAlterado = False
            AddHandler itemAtual.AoAlterarRGProduto, AddressOf RGProdutoAlterado
            '
            If Not IsNothing(itemAtual.IDEstoqueAjuste) Then
                '
                '--- turn ajuste position equals the item ajusteID
                bindAjuste.Position = _AjusteList.FindIndex(Function(x) x.IDEstoqueAjuste = itemAtual.IDEstoqueAjuste)
                '
                '--- update the navigation ajuste buttons
                UpdateNavigationButtons()
                '
            End If
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
        e.Value = Format(e.Value, "0000")
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
#Region "GET ITENS"
    '
    '--- RETORNA OS AJUSTES LIGADOS AO ESTOQUE INICIAL
    '----------------------------------------------------------------------------------
    Private Sub getAjustes()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _AjusteList = eBLL.GetEstoqueInicialList(_IDFilial)
            UpdateNavigationButtons()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a Lista de Ajustes do Estoque Inicial..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
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
            _ItensList = eBLL.GetEstoqueInicialItens_List(_IDFilial)
            dgvEntradas.DataSource = bindItem
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a listagem de Itens do Estoque Inicial..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '// GET ITENS
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
        ' (2) COLUNA QUANTIDADE
        With clnQuantidade
            .HeaderText = "Quant."
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
        ' (3) COLUNA PRECO
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
        ' (4) COLUNA SUB TOTAL
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
        dgvEntradas.Columns.AddRange({clnRGProduto, clnProduto, clnQuantidade, clnPreco, clnSubTotal})
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

        If MessageBox.Show("Deseja remover esse item da lista?" &
                           vbNewLine & vbNewLine &
                           bindItem.Current.Produto,
                           "Remover Item",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- efetua delete
            Item_ExcluirBD()
            '
            '--- Get AjusteAtual before remove item
            Dim AjusteAtual As clEstoqueAjuste = _AjusteList.Find(Function(x) x.IDEstoqueAjuste = bindItem.Current.IDEstoqueAjuste)
            UpdateNavigationButtons()
            '
            '--- remove the item of listagem
            bindItem.RemoveCurrent()
            '
            '--- Resolve ValorMovimentado of Ajuste Atual
            AjusteAtual.ValorMovimentado = _ItensList.Where(Function(x) x.IDEstoqueAjuste = AjusteAtual.IDEstoqueAjuste).Sum(Function(y) y.Total)
            '
            '--- calcula valor total
            AtualizaTotalGeral()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir item no BD..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
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
            MessageBox.Show("Favor definir o produto a ser Inserido.",
                            "Escolha o Produto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRGProduto.Focus()
            txtRGProduto.SelectAll()
            Return
        End If
        '
        '--- Verifica a quantidade Final inserida
        '----------------------------------------------------------------------------------
        If txtQuantidade.Text.Trim.Length = 0 Then
            MessageBox.Show("Favor inserir a quantidade do estoque do produto a ser inserido.",
                            "Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQuantidade.Focus()
            txtQuantidade.SelectAll()
            Return
        End If
        '
        '--- EXECUCAO
        '----------------------------------------------------------------------------------
        Dim AjusteAtual As clEstoqueAjuste = Nothing
        '
        '--- GET new Transaction
        Dim T As New TransactionControlBLL
        Dim dbTran As Object = T.GetNewAcessoWithTransaction
        '
        '--- VERIFICA AJUSTE ATUAL
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Verifica GET ou INSERT
            AjusteAtual = VerificaAjusteAtual(dbTran)
            bindAjuste.Position = bindAjuste.IndexOf(AjusteAtual)
            UpdateNavigationButtons()
            '
        Catch ex As Exception
            '
            '--- ROOLBACK
            T.RollbackAcessoWithTransaction(dbTran)
            '
            '--- MESSAGE
            MessageBox.Show("Uma exceção ocorreu ao Verificar Ajuste de Estoque Inicial Atual..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Exit Sub
            '
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '
        '--- SALVA OU EDITA O ITEM
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Select Case propItemPanelVisible
            '
                Case EnumFlagAcao.INSERIR
                    DirectCast(bindItem.Current, clEstoqueAjusteItem).IDEstoqueAjuste = AjusteAtual.IDEstoqueAjuste
                    bindItem.Current.IDEstoqueItem = Item_InserirBD(dbTran)
                    '
                Case EnumFlagAcao.EDITAR
                    Item_EditarBD(dbTran)
                    '
            End Select
            '
            '--- Resolve ValorMovimentado of Ajuste Atual
            AjusteAtual.ValorMovimentado = _ItensList.Where(Function(x) x.IDEstoqueAjuste = AjusteAtual.IDEstoqueAjuste).Sum(Function(y) y.Total)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar o Item no BD..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Exit Sub
            '
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- COMMMIT ACESSO
        T.CommitAcessoWithTransaction(dbTran)
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
    ' VERIFICA SE EXISTE AJUSTE DE ESTOQUE ATUAL
    '==========================================================================================
    Private Function VerificaAjusteAtual(dbTran As Object) As clEstoqueAjuste
        '
        '--- verifica se existe algum ajuste com a data atual
        '----------------------------------------------------------------------------------
        '
        '--- percorre pela lista de ajustes
        For Each ajuste As clEstoqueAjuste In bindAjuste
            '
            '--- procura com a mesma data e com o mesmo user
            If ajuste.AjusteData = Today AndAlso ajuste.IDUser = _IDUserAtual Then
                '
                '--- verifica se é real (se possui ID)
                If ajuste.IDEstoqueAjuste > 0 Then
                    '
                    '--- retorna
                    Return ajuste
                    Exit For
                    '
                Else '--- se não é real entao salva no BD
                    '
                    Try
                        '--- insere novo ajuste
                        Dim NewAjuste As clEstoqueAjuste = Ajuste_InserirDB(ajuste, dbTran)
                        '
                        '--- remove o ajuste vazio para substituir pelo que foi salvo
                        bindAjuste.RemoveAt(bindAjuste.IndexOf(ajuste))
                        bindAjuste.Add(NewAjuste)
                        bindAjuste.EndEdit()
                        '
                        '--- retorna
                        Return NewAjuste
                        Exit For
                        '
                    Catch ex As Exception
                        Throw ex
                    End Try
                    '
                End If
                '
            End If
            '
        Next
        '
        '--- Not find any compatible Ajuste, then insert new ajuste
        '----------------------------------------------------------------------------------
        '
        Dim ajt As New clEstoqueAjuste With {
                .AjusteData = Today,
                .IDUser = _IDUserAtual,
                .UsuarioApelido = UsuarioAtual.UsuarioApelido,
                .IDFilial = _IDFilial,
                .ApelidoFilial = lblFilial.Text
        }
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- create new ajuste 
            Dim NewAjuste As clEstoqueAjuste = Ajuste_InserirDB(ajt, dbTran)
            '
            '--- block all previous ajustes
            BlockAllPreviousAjustes()
            '
            '--- Add to DataBind
            bindAjuste.Add(NewAjuste)
            bindAjuste.EndEdit()
            '
            '--- retorna
            Return NewAjuste
            '
        Catch ex As Exception
            Throw ex
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
    '--- BLOCK ALL PREVIOUS AJUSTES
    '----------------------------------------------------------------------------------
    Private Sub BlockAllPreviousAjustes()
        '
        For Each ajt As clEstoqueAjuste In bindAjuste
            ajt.Bloqueado = True
        Next
        '
    End Sub
    '
    '==========================================================================================
    ' INSERE O AJUSTE NO BD
    '==========================================================================================
    Private Function Ajuste_InserirDB(ajt As clEstoqueAjuste, dbTran As Object) As clEstoqueAjuste
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- this insert and block all previous ajuste
            Return eBLL.InsertAjusteEstoqueInicial(ajt, dbTran)
            '
        Catch ex As Exception
            Throw ex
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' INSERE O ITEM NO BD
    '==========================================================================================
    Private Function Item_InserirBD(dbTran As Object) As Integer
        '
        Try
            Return eBLL.InserirItem(bindItem.Current, bindAjuste.Current.AjusteData, dbTran).IDEstoqueItem
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EDITA O ITEM NO BD
    '==========================================================================================
    Private Function Item_EditarBD(dbTran As Object) As Boolean
        '
        Try
            eBLL.EditarItem(bindItem.Current, bindAjuste.Current.AjusteData, dbTran)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' EXCLUI O ITEM NO BD
    '==========================================================================================
    Private Function Item_ExcluirBD() As Boolean
        '
        Try
            eBLL.ExcluirItem(bindItem.Current)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
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
                .Preco = ItemProduto.PCompra
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
    '--- OBTEM O ESTOQUE DO PRODUTO QUANDO AO EDITAR    
    'Private Sub ObtemEstoque()
    '    '
    '    Try
    '        '--- Ampulheta ON
    '        Cursor = Cursors.WaitCursor
    '        '
    '        Dim itemBLL As New TransacaoItemBLL
    '        Dim dt As DataTable = itemBLL.Item_GetEstoque(_clItem.IDProduto, _IDFilial)
    '        '
    '        If IsNumeric(dt.Rows(0)(0)) Then
    '            _clItem.Estoque = dt.Rows(0)(0)
    '            _clItem.Reservado = dt.Rows(0)(1)
    '        End If
    '        '
    '    Catch ex As Exception
    '        MessageBox.Show("Uma exceção ocorreu ao obter o estoque do produto..." & vbNewLine &
    '                        ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        '--- Ampulheta OFF
    '        Cursor = Cursors.Default
    '    End Try
    '    '
    'End Sub
    '
#End Region '/ VALIDA PRODUTO
    '
#Region "FORMATACAO E FLUXO"
    '
    '--- SOMENTE PERMITE NUMEROS NO TEXTBOX
    '---------------------------------------------------------------------------------------------------
    Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGProduto.KeyPress
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
            txtObservacao.KeyDown, txtRGProduto.KeyDown, txtQuantidade.KeyDown
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
                    txtRGProduto.Text = p.RGEscolhido
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
                txtRGProduto.Text = f.RGEscolhido
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
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click, btnClose.Click
        '-- apenas fechar
        Close()
        If My.Application.OpenForms.Count = 1 Then MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        '
        '--- move bind
        bindAjuste.MovePrevious()
        '
        '--- get the current IDAjuste
        Dim id As Integer = bindAjuste.Current.IDEstoqueAjuste
        '
        For Each r As DataGridViewRow In dgvEntradas.Rows
            If DirectCast(r.DataBoundItem, clEstoqueAjusteItem).IDEstoqueAjuste = id Then
                dgvEntradas.CurrentCell = r.Cells(0)
                Exit For
            End If
        Next
        '
    End Sub
    '
    Private Sub btnProximo_Click(sender As Object, e As EventArgs) Handles btnProximo.Click
        '
        '--- move bind
        bindAjuste.MoveNext()
        '
        '--- get the current IDAjuste
        Dim id As Integer = bindAjuste.Current.IDEstoqueAjuste
        '
        For Each r As DataGridViewRow In dgvEntradas.Rows
            If DirectCast(r.DataBoundItem, clEstoqueAjusteItem).IDEstoqueAjuste = id Then
                dgvEntradas.CurrentCell = r.Cells(0)
                Exit For
            End If
        Next

        'dgvEntradas.Rows(0).Cells(0).Style.BackColor = Color.Red
    End Sub
    '
    Private Sub btnObservacaoSave_Click(sender As Object, e As EventArgs) Handles btnObservacaoSave.Click
        '
        If bindAjuste.Count = 1 AndAlso bindAjuste.Current.IDEstoqueAjuste = 0 Then
            bindAjuste.Current.Observacao = txtObservacao.Text
            btnObservacaoSave.Visible = False
            Return
        End If
        '
        Dim idAjuste As Integer = _AjusteList.Min(Function(x) x.IDEstoqueAjuste)
        If idAjuste = 0 Then Exit Sub
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim oBLL As New ObservacaoBLL
            oBLL.SaveObservacao(14, idAjuste, txtObservacao.Text)
            '
            '--- Mesage
            MessageBox.Show("Observação Salva com sucesso!",
                            "Observação Salva",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            '
            btnObservacaoSave.Visible = False
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar a Observação..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
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
        Dim VM As Double = 0
        '
        VM = _AjusteList.Sum(Function(x) x.ValorMovimentado)
        T = _ItensList.Sum(Function(x) x.Total)
        '
        If VM <> T Then CorrigeValorMovimentado()
        '
        lblTotalGeral.Text = Format(T, "c")
        Return T
        '
    End Function
    '
    Private Sub CorrigeValorMovimentado()
        MsgBox("Fazer Correcao de Valores Movimentados")
    End Sub
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
    '----------------------------------------------------------------------------------
    '--- AO ALTERAR O ITEM UPDATE NAVIGATION BUTTONS
    '----------------------------------------------------------------------------------
    Private Sub UpdateNavigationButtons()
        '
        Dim countAjustes As Integer = _AjusteList.Count
        '
        If countAjustes <= 1 Then
            btnAnterior.Enabled = False
            btnProximo.Enabled = False
        Else
            Dim indexAtual As Integer = bindAjuste.Position
            '
            If indexAtual >= countAjustes - 1 Then
                btnProximo.Enabled = False
                btnAnterior.Enabled = True
            ElseIf indexAtual = 0 Then
                btnProximo.Enabled = True
                btnAnterior.Enabled = False
            Else
                btnProximo.Enabled = True
                btnAnterior.Enabled = True
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub txtObservacao_TextChanged(sender As Object, e As EventArgs) Handles txtObservacao.TextChanged
        btnObservacaoSave.Visible = True
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
