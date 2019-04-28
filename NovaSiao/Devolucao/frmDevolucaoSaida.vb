Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmDevolucaoSaida
    '
    Private devBLL As New DevolucaoSaidaBLL
    Private _Dev As clDevolucaoSaida
    '
    Private _ItensList As New List(Of clTransacaoItem)
    Private _MovEntradaList As New List(Of clMovimentacao)
    '
    Private bindDev As New BindingSource
    Private bindItem As New BindingSource
    Private bindEnt As New BindingSource
    '
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _IDFilial As Integer
    Private VerificaAlteracao As Boolean
    '
    Dim EP As New ErrorProvider
    '
#Region "LOAD"
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            Select Case _Sit
                '
                Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
                    lblSituacao.Text = "Finalizada"
                    btnFinalizar.Text = "&Fechar"
                    '
                    btnData.Enabled = True
                    txtFreteValor.ReadOnly = False
                    txtObservacao.ReadOnly = False
                    txtVolumes.ReadOnly = False
                    '
                    txtValorDescontos.ReadOnly = False
                    txtValorAcrescimos.ReadOnly = False
                    '
                    btnExcluir.Enabled = True
                    btnDesbloquear.Enabled = False
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    lblSituacao.Text = "Alterada"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    btnData.Enabled = True
                    txtFreteValor.ReadOnly = False
                    txtObservacao.ReadOnly = False
                    txtVolumes.ReadOnly = False
                    '
                    txtValorDescontos.ReadOnly = False
                    txtValorAcrescimos.ReadOnly = False
                    '
                    btnExcluir.Enabled = True
                    btnDesbloquear.Enabled = False
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    lblSituacao.Text = "Em Aberto"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    btnData.Enabled = True
                    txtFreteValor.ReadOnly = False
                    txtObservacao.ReadOnly = False
                    txtVolumes.ReadOnly = False
                    '
                    txtValorDescontos.ReadOnly = False
                    txtValorAcrescimos.ReadOnly = False
                    '
                    btnExcluir.Enabled = True
                    btnDesbloquear.Enabled = False
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    lblSituacao.Text = "Bloqueada"
                    btnFinalizar.Text = "&Fechar"
                    '
                    btnData.Enabled = False
                    txtFreteValor.ReadOnly = True
                    txtObservacao.ReadOnly = True
                    txtVolumes.ReadOnly = True
                    '
                    txtValorDescontos.ReadOnly = True
                    txtValorAcrescimos.ReadOnly = True
                    '
                    btnExcluir.Enabled = False
                    btnDesbloquear.Enabled = True
                    '
            End Select
            '
            VerificaEnviada()
            '
        End Set
        '
    End Property
    '
    Property propDevolucao As clDevolucaoSaida
        '
        Get
            Return _Dev
        End Get
        '
        Set(value As clDevolucaoSaida)
            '
            VerificaAlteracao = False '--- Inibe a verificacao dos combos
            _Dev = value
            _IDFilial = _Dev.IDPessoaOrigem
            obterItens()
            obterCreditos()
            bindEnt.DataSource = _MovEntradaList
            bindItem.DataSource = _ItensList
            dgvItens.DataSource = bindItem
            '
            If IsNothing(bindDev.DataSource) Then
                bindDev.DataSource = _Dev
                PreencheDataBinding()
            Else
                bindDev.Clear()
                bindDev.DataSource = _Dev
                bindDev.ResetBindings(True)
            End If
            '
            '--- Preenche os Itens da Devolucao
            PreencheItens()
            '
            '--- Preenche Itens dgvEntradas (creditos)
            Preenche_Creditos()
            '
            '--- Atualiza o estado da Situacao: FLAGESTADO
            Select Case _Dev.IDSituacao
                Case 1 ' DEVOLUCAO INICIADA
                    Sit = EnumFlagEstado.NovoRegistro
                Case 2 ' DEVOLUCAO FINALIZADA
                    Sit = EnumFlagEstado.RegistroSalvo
                Case 3 ' DEVOLUCAO BLOQUEADA
                    Sit = EnumFlagEstado.RegistroBloqueado
                Case Else
            End Select
            '
            '--- Verifica se a Devolucao foi creditada
            If _Dev.Creditada Then
                lblCreditada.Text = "Creditada"
            Else
                lblCreditada.Text = "Não Creditada"
            End If
            '
            '--- Habilita ou Desabilita os campos do Frete da DEVOLUCAO
            Controla_cmbFrete()
            '
            '--- Permite a verificacao dos campos IDPlano
            VerificaAlteracao = True
            '
            '--- Atualiza o label TOTAL
            AtualizaTotalGeral()
            '
        End Set
        '
    End Property
    '
    Public Sub New(myDev As clDevolucaoSaida)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propDevolucao = myDev
        '
        '--- hANDLER Menu Acao
        MenuOpen_AdHandler()
        '
    End Sub
    '
    Private Sub frmDevolucaoSaida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- desabilita a verificacao de bloqueio
        VerificaAlteracao = False
        '
        '--- faz a leitura dos combobox para nao emitir mensagem na alteracao do TAB
        cmbFreteTipo.SelectedValue = _Dev.FreteTipo
        cmbIDTransportadora.SelectedValue = If(_Dev.IDTransportadora, -1)
        '
        '--- habilita a verificacao de bloqueio
        VerificaAlteracao = True
        '
    End Sub
    '
#End Region
    '
#Region "DATABINDING"
    '
    Private Sub PreencheDataBinding()
        '
        lblFornecedor.DataBindings.Add("Text", bindDev, "Fornecedor", True, DataSourceUpdateMode.OnPropertyChanged)
        lblIDDevolucao.DataBindings.Add("Text", bindDev, "IDDevolucao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindDev, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTransacaoData.DataBindings.Add("Text", bindDev, "TransacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtVolumes.DataBindings.Add("Text", bindDev, "Volumes", True, DataSourceUpdateMode.OnPropertyChanged)
        txtFreteValor.DataBindings.Add("Text", bindDev, "FreteValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindDev, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblValorProdutos.DataBindings.Add("Text", bindDev, "ValorProdutos", True, DataSourceUpdateMode.OnPropertyChanged)
        txtValorDescontos.DataBindings.Add("Text", bindDev, "ValorDescontos", True, DataSourceUpdateMode.OnPropertyChanged)
        txtValorAcrescimos.DataBindings.Add("Text", bindDev, "ValorAcrescimos", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTotalGeral.DataBindings.Add("Text", bindDev, "ValorTotal", True, DataSourceUpdateMode.OnPropertyChanged)
        chkEnviada.DataBindings.Add("checked", bindDev, "Enviada", True, DataSourceUpdateMode.OnPropertyChanged)
        chkCreditada.DataBindings.Add("checked", bindDev, "Creditada", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDDevolucao.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler txtFreteValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblValorProdutos.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtValorAcrescimos.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtValorDescontos.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblTotalGeral.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtVolumes.DataBindings("text").Format, AddressOf Format00
        AddHandler lblTransacaoData.DataBindings("text").Format, AddressOf FormatDT
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbFreteTipo()
        CarregaCmbTransportadora()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Dev.AoAlterar, AddressOf HandlerAoAlterar
        AddHandler _Dev.AoEnviadaAlterar, AddressOf HandlerAoEnviadaAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Dev.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
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
    '
#End Region
    '
#Region "CARREGA OS COMBOBOX"
    '
    Private Sub CarregaCmbFreteTipo()
        '
        Dim dtFTipo As New DataTable
        '--- Adiciona as Colunas
        dtFTipo.Columns.Add("idFTipo")
        dtFTipo.Columns.Add("FTipo")
        '--- Adiciona todas as possibilidades de Frete
        dtFTipo.Rows.Add(New Object() {0, "Sem Frete"})
        dtFTipo.Rows.Add(New Object() {1, "Emitente"})
        dtFTipo.Rows.Add(New Object() {2, "Destinatário"})
        'dtFTipo.Rows.Add(New Object() {3, "Reembolso Postal"})
        'dtFTipo.Rows.Add(New Object() {4, "A Cobrar"})
        '
        With cmbFreteTipo
            .DataSource = dtFTipo
            .ValueMember = "idFTipo"
            .DisplayMember = "FTipo"
            .DataBindings.Add("SelectedValue", bindDev, "FreteTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
    Private Sub CarregaCmbTransportadora()
        Dim tBLL As New TransportadoraBLL
        '
        Try
            Dim dt As DataTable = tBLL.Transportadora_GET_ListaSimples(True)
            '
            With cmbIDTransportadora
                .DataSource = dt
                .ValueMember = "IDTransportadora"
                .DisplayMember = "Cadastro"
                .DataBindings.Add("SelectedValue", bindDev, "IDTransportadora", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu obter lista de Transportadoras" & vbNewLine &
            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '--------------------------------------------------------------------------------------------------------
#End Region
    '
#Region "CARREGA/INSERE ITENS"
    '
    Private Sub PreencheItens()
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
        '--- configura o DataSource
        dgvItens.DataSource = GetType(List(Of))
        dgvItens.DataSource = _ItensList
        If dgvItens.Rows.Count > 0 Then dgvItens.CurrentCell = dgvItens.Rows(dgvItens.Rows.Count).Cells(1)
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    Private Sub FormataColunas_Itens()
        '
        ' (1) COLUNA IDItem
        dgvItens.Columns.Add("clnIDTansacaoItem", "IDItem")
        With dgvItens.Columns("clnIDTansacaoItem")
            .DataPropertyName = "IDTransacaoItem"
            .Width = 0
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA RGProduto
        dgvItens.Columns.Add("clnRGProduto", "Reg.")
        With dgvItens.Columns("clnRGProduto")
            .DataPropertyName = "RGProduto"
            .Width = 70
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
        dgvItens.Columns.Add("clnProduto", "Descrição")
        With dgvItens.Columns("clnProduto")
            .DataPropertyName = "Produto"
            .Width = 430
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA QUANTIDADE
        dgvItens.Columns.Add("clnQuantidade", "Qtde.")
        With dgvItens.Columns("clnQuantidade")
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
        ' (5) COLUNA PRECO
        dgvItens.Columns.Add("clnPreco", "Preço")
        With dgvItens.Columns("clnPreco")
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
        dgvItens.Columns.Add("clnSubTotal", "SubTotal")
        With dgvItens.Columns("clnSubTotal")
            .DataPropertyName = "SubTotal"
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
        ' (7) COLUNA DESCONTO
        dgvItens.Columns.Add("clnDesconto", "Desc.")
        With dgvItens.Columns("clnDesconto")
            .DataPropertyName = "Desconto"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (8) COLUNA TOTAL
        dgvItens.Columns.Add("clnTotal", "Total")
        With dgvItens.Columns("clnTotal")
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
    End Sub
    '
    '--- RETORNA TODOS OS ITENS DA DEVOLUCAO
    Private Sub obterItens()
        '
        Dim tBLL As New TransacaoItemBLL
        Try
            _ItensList = tBLL.GetTransacaoItens_List(_Dev.IDDevolucao, _IDFilial)
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter Itens da Devolucao:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- INSERE UM NOVO ITEM NA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------
    Private Sub Inserir_Item()
        '
        '--- Verifica se esta Bloqueado ou Finalizado
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        If DevolucaoEnviada("dgvItens") Then Exit Sub '--- Verifica se a devolucao foi enviada
        '
        '--- Abre o frmItem
        Dim newItem As New clTransacaoItem
        '
        Dim fItem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _IDFilial, newItem)
        fItem.ShowDialog()
        '
        '--- Verifica o retorno do Dialog
        If Not fItem.DialogResult = DialogResult.OK Then Exit Sub
        '
        '--- Insere o novo Item
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
        '----------------------------------------------------------------------------------------------
        '--- Insere o novo ITEM no BD
        Try
            newItem.IDTransacao = _Dev.IDDevolucao
            myID = ItemBLL.InserirNovoItem(newItem,
                                           TransacaoItemBLL.EnumMovimento.SAIDA,
                                           _Dev.TransacaoData,
                                           InsereCustos:=False
                                           )
            newItem.IDTransacaoItem = myID
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao INSERIR o item no BD..." & vbNewLine & ex.Message, "Exceção Inesperada",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        '--- Insere o ITEM na lista
        _ItensList.Add(newItem)
        bindItem.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvItens.DataSource = bindItem
        bindItem.MoveLast()
        '
        '--- Atualiza o label TOTAL
        AtualizaTotalGeral()
        '
    End Sub
    '    
    '--- EDITA UM ITEM NA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------
    Private Sub Editar_Item()
        '
        '--- Verifica se esta Bloqueado ou Finalizado
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        If DevolucaoEnviada("dgvItens") Then Exit Sub '--- Verifica se a devolucao foi enviada
        '
        '--- Verifica se há um item selecionado
        If dgvItens.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- obtem o itemAtual
        Dim itmAtual As clTransacaoItem
        itmAtual = dgvItens.SelectedRows(0).DataBoundItem
        '
        '--- Abre o frmItem
        Dim fitem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _IDFilial, itmAtual)
        fitem.ShowDialog()
        '
        '--- Verifica o retorno do Dialog
        If Not fitem.DialogResult = DialogResult.OK Then Exit Sub
        '
        '--- Edita o novo Item
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
        'Dim i As Integer = _ItensList.FindIndex(Function(x) x.IDTransacaoItem = itmAtual.IDTransacaoItem)
        '
        '--- Altera o ITEM no BD e reforma o ESTOQUE
        Try
            itmAtual.IDTransacao = _Dev.IDDevolucao
            myID = ItemBLL.EditarItem(itmAtual,
                                      TransacaoItemBLL.EnumMovimento.SAIDA,
                                      _Dev.TransacaoData,
                                      InsereCustos:=False)
            itmAtual.IDTransacaoItem = myID
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao ALTERAR o item no BD..." & vbNewLine & ex.Message,
                            "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        '--- Atualiza o ITEM da lista
        '
        '_ItensList.Item(i) = Item
        bindItem.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvItens.DataSource = bindItem
        'bindItem.CurrencyManager.Position = i
        '
        '--- Atualiza o label TOTAL
        AtualizaTotalGeral()
        '
    End Sub
    '    
    '--- EXCLUI UM ITEM NA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------
    Private Sub Excluir_Item()
        '
        '--- Verifica se esta Bloqueado ou Finalizado
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        If DevolucaoEnviada("dgvItens") Then Exit Sub '--- Verifica se a devolucao foi enviada
        '
        '--- Verifica se há um item selecionado
        If dgvItens.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- obtem o itemAtual
        Dim itmAtual As clTransacaoItem
        itmAtual = dgvItens.SelectedRows(0).DataBoundItem
        '
        '--- pergunta ao usuário se deseja excluir o item
        If MessageBox.Show("Deseja realmente REMOVER esse item da DEVOLUÇÃO?" & vbNewLine & vbNewLine &
                           itmAtual.Produto.ToUpper, "Excluir Item",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '--- Exclui o Item do BD
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
        Dim i As Integer = _ItensList.FindIndex(Function(x) x.IDTransacaoItem = itmAtual.IDTransacaoItem)
        '
        '--- Altera o ITEM no BD e reforma o ESTOQUE
        Try
            myID = ItemBLL.ExcluirItem(itmAtual, TransacaoItemBLL.EnumMovimento.SAIDA)
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao EXCLUIR o item no BD..." & vbNewLine & ex.Message,
                            "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        '--- Atualiza o ITEM da lista
        _ItensList.RemoveAt(i)
        bindItem.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvItens.DataSource = bindItem
        '
        '--- Atualiza o label TOTAL
        AtualizaTotalGeral()
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------------------
    ' CRIA TECLA DE ATALHO PARA INSERIR/EDITAR PRODUTO
    '---------------------------------------------------------------------------------------------------
    Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItens.KeyDown
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
    Private Sub dgvItens_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        Editar_Item()
    End Sub
    '
#End Region
    '
#Region "CONTROLE DO GRID CREDITOS"
    '
    '============================================================================================================
    ' CREDITOS CONTROLES
    '============================================================================================================
    '
    '--- RETORNA TODOS OS CREDITOS
    Private Sub obterCreditos()
        Dim pBLL As New MovimentacaoBLL
        Try
            _MovEntradaList = pBLL.Movimentacao_GET_PorOrigemID(EnumMovimentacaoOrigem.Devolucao, _Dev.IDDevolucao)
            '
            '--- Atualiza o label TOTAL PAGO
            AtualizaTotalCreditos()
            '
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter os Créditos/Entradas da Devolução:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- Preenche o DataGrid Creditos
    Private Sub Preenche_Creditos()
        '
        With dgvEntradas
            '
            '--- limpa as colunas do datagrid
            .Columns.Clear()
            .AutoGenerateColumns = False
            '
            ' altera as propriedades importantes
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersVisible = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .RowHeadersVisible = True
            .RowHeadersWidth = 30
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .StandardTab = True
            '
            '--- configura o DataSource
            .DataSource = bindEnt
            If .Rows.Count > 0 Then .CurrentCell = .Rows(.Rows.Count).Cells(1)
        End With
        '
        '--- formata as colunas do datagrid
        FormataGrid_Pagamentos()
        '
    End Sub
    '
    Private Sub FormataGrid_Pagamentos()
        '
        Dim cellStyleCur As New DataGridViewCellStyle
        cellStyleCur.Format = "c"
        cellStyleCur.NullValue = Nothing
        cellStyleCur.Alignment = DataGridViewContentAlignment.MiddleRight
        '
        ' (1) COLUNA MovData
        dgvEntradas.Columns.Add("clnMovData", "Data")
        With dgvEntradas.Columns("clnMovData")
            .DataPropertyName = "MovData"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "d"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA CONTA DE CREDITO
        dgvEntradas.Columns.Add("clnConta", "Conta")
        With dgvEntradas.Columns("clnConta")
            .DataPropertyName = "Conta"
            .Width = 200
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (3) COLUNA VALOR
        dgvEntradas.Columns.Add("clnMovValor", "Valor")
        With dgvEntradas.Columns("clnMovValor")
            .DefaultCellStyle = cellStyleCur
            .DataPropertyName = "MovValor"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
    End Sub
    '
    Private Sub dgvEntradas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvEntradas.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            '
            e.Handled = True
            Creditos_Adicionar()
            '
        ElseIf e.KeyCode = Keys.Enter Then
            '
            e.Handled = True
            Creditos_Editar()
            '
        ElseIf e.KeyCode = Keys.Delete Then
            '
            e.Handled = True
            Creditos_Excluir()
            '
        End If
    End Sub
    '
    '--- INSERT CREDITO DE DEVOLUCAO
    '====================================================================================================
    Private Sub Creditos_Adicionar()
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado'
        If Not DevolucaoEnviada("dgvEntradas") Then Exit Sub
        '
        '--- Atualiza o Valor do Total Geral
        Dim vl As Double = AtualizaTotalGeral()
        '
        '--- Verifica se o valor dos itens é maior que zero
        If vl = 0 Then
            MessageBox.Show("Não é possivel realizar Creditos de Devolução" & vbNewLine &
                            "Quando o valor da Devolução ainda é igual a Zero..." & vbNewLine &
                            "Adicione produtos primeiro e depois tente novamente.", "Novo Crédito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- Verifica se o ValorCreditado já é suficiente
        If AtualizaTotalCreditos() >= vl Then
            MessageBox.Show("Não é possivel adicionar novo Crédito de Devolução," & vbNewLine &
                            "porque o valor dos Créditos recebidos já é igual ao valor total da Devolução",
                            "Novo Crédito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- posiciona o form
        Dim pos As Point = dgvEntradas.PointToScreen(Point.Empty)
        pos = New Point(pos.X + dgvEntradas.Width - 10, pos.Y)
        '
        '--- cria nova Entrada
        Dim clMov As New clMovimentacao(EnumMovimentacaoOrigem.Devolucao, EnumMovimento.Entrada)
        Dim vlMax As Double = vl - _MovEntradaList.Sum(Function(x) x.MovValor)
        '
        clMov.MovValor = vlMax
        clMov.Origem = 4 '---> tblDevolucao
        clMov.IDOrigem = _Dev.IDDevolucao
        clMov.MovData = _Dev.TransacaoData
        clMov.IDConta = Obter_ContaPadrao()
        clMov.IDFilial = Obter_FilialPadrao()
        clMov.IDMovForma = 1
        clMov.IDMovimentacao = _MovEntradaList.Count + 1
        clMov.Descricao = "Credito Devolucao de " & _Dev.Fornecedor
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        '--- abre o form frmPagamentos
        Dim fCred As New frmDevolucaoCredito(Me, vlMax, clMov, EnumFlagAcao.INSERIR, pos)
        fCred.ShowDialog()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        '--- verifica o resultado do dialog
        If fCred.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        '--- insere no BD
        Dim mBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newID As Integer = mBLL.Movimentacao_Inserir(clMov).IDMovimentacao
            '
            clMov.IDMovimentacao = newID
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inserir Crédito de Devolução no BD..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- insere na listagem de Creditos
        _MovEntradaList.Add(clMov)
        bindEnt.ResetBindings(False)
        '
        '--- atualiza o datagrid
        dgvEntradas.DataSource = bindEnt
        bindEnt.MoveLast()
        '
        '--- AtualizaTotalCreditado
        AtualizaTotalCreditos()
        '
    End Sub
    '
    '--- EDIT CREDITO DE DEVOLUCAO
    '====================================================================================================
    Private Sub Creditos_Editar()
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        If Not DevolucaoEnviada("dgvEntradas") Then Exit Sub
        '
        '--- posiciona o form
        Dim pos As Point = dgvEntradas.PointToScreen(Point.Empty)
        pos = New Point(pos.X + dgvEntradas.Width - 10, pos.Y)
        '
        '--- GET Pagamentos do DataGrid
        If dgvEntradas.SelectedRows.Count = 0 Then Exit Sub
        '
        Dim credAtual As clMovimentacao = dgvEntradas.SelectedRows(0).DataBoundItem
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        Dim fCred As New frmDevolucaoCredito(Me, AtualizaTotalGeral(), credAtual, EnumFlagAcao.EDITAR, pos)
        fCred.ShowDialog()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        '--- verifica o resultado do dialog
        If fCred.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        '--- insere no BD
        Dim mBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            mBLL.Movimentacao_Update(credAtual)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Atualizar o Crédito de Devolução no BD..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- AtualizaTotalPago
        AtualizaTotalCreditos()
        '
    End Sub
    '
    '--- DELETE CREDITO DE DEVOLUCAO
    '====================================================================================================
    Private Sub Creditos_Excluir()
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        If Not DevolucaoEnviada("dgvEntradas") Then Exit Sub
        '
        '--- verifica se existe alguma parcela selecionada
        If dgvEntradas.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- seleciona a parcela
        Dim MovAtual As clMovimentacao = dgvEntradas.SelectedRows(0).DataBoundItem
        '
        '---verifica se a movimentacao esta anexada com caixa
        If Not IsNothing(MovAtual.IDCaixa) Then
            MessageBox.Show("Não é possível EXCLUIR esse Crédito de Devolução " &
                            "já que essa entrada está anexada ao um caixa.",
                            "Excluir Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- pergunta ao usuário se deseja excluir o item
        If MessageBox.Show("Deseja realmente REMOVER esse Crédito de Devolução?", "Excluir Crédito",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- envia o comando para excluir a parcela
        Dim mBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            mBLL.Movimentacao_Excluir(MovAtual)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir o Crédito de Devolução no BD..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- Atualiza o ITEM da lista
        _MovEntradaList.RemoveAt(_MovEntradaList.IndexOf(MovAtual))
        '
        bindEnt.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvEntradas.DataSource = bindEnt
        '--- AtualizaTotalPago
        AtualizaTotalCreditos()
        '
    End Sub
    '
    ' ALTERA A COR DO DATAGRIDVIEW QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgv_GotFocus(sender As Object, e As EventArgs) Handles dgvEntradas.GotFocus
        '
        Dim c As Color = Color.FromArgb(209, 215, 220)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.Fixed3D
        '
    End Sub
    '
    Private Sub dgv_LostFocus(sender As Object, e As EventArgs) Handles dgvEntradas.LostFocus
        '
        Dim c As Color = Color.FromArgb(224, 232, 243)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.None
        '
    End Sub
    '
    ' CONTROLA O MENU NO DATAGRID PAGAMENTOS
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvEntradas_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvEntradas.MouseDown
        If e.Button = MouseButtons.Right Then
            'Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvEntradas.HitTest(e.X, e.Y)
            dgvEntradas.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvEntradas.CurrentCell = dgvEntradas.Rows(hit.RowIndex).Cells(1)
            dgvEntradas.Rows(hit.RowIndex).Selected = True
            dgvEntradas.Focus()
            '
            mnuContexto.Show(dgvEntradas, e.Location)
            '
        End If
    End Sub
    '
    Private Sub dgvAReceber_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEntradas.CellDoubleClick
        Creditos_Editar()
    End Sub
    '
    '============================================================================================================
#End Region
    '
#Region "MENU CONTEXTO"
    '
    ' CONTROLA O MENU CONTEXTO NO DATAGRID ITENS
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvItens_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            'Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvItens.HitTest(e.X, e.Y)
            dgvItens.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvItens.CurrentCell = dgvItens.Rows(hit.RowIndex).Cells(1)
            dgvItens.Rows(hit.RowIndex).Selected = True
            '
            'mnuItens.Show(dgvItens, c.PointToScreen(e.Location))
            mnuContexto.Show(dgvItens, e.Location)
            '
        End If
        '
    End Sub
    '
    ' CONTROLA ACOES DO MENU CONTEXTO
    '-----------------------------------------------------------------------------------------------------
    Private Sub MenuItemEditar_Click(sender As Object, e As EventArgs) Handles mnuItemEditar.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Editar_Item()
        End If
        '
    End Sub
    '
    Private Sub MenuItemInserir_Click(sender As Object, e As EventArgs) Handles mnuItemInserir.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Inserir_Item()
        End If
        '
    End Sub
    '
    Private Sub MenuItemExcluir_Click(sender As Object, e As EventArgs) Handles mnuItemExcluir.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Excluir_Item()
        End If
        '
    End Sub
    '
#End Region '/ MENU CONTEXTO
    '
#Region "BOTOES DE ACAO"
    '
    '--- FECHAR | CLOSE
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Or Sit = EnumFlagEstado.Alterado Then
            '
            '--- ask to user
            If Not CanCloseMessage() Then Exit Sub
            '
        End If
        '
        Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
    '--- ALTERAR A DATA DA DEVOLUCAO
    Private Sub lblTransacaoData_DoubleClick(sender As Object, e As EventArgs) _
        Handles lblTransacaoData.DoubleClick, btnData.Click
        '
        Dim frmDt As New frmDataInformar("Informe a data da Devolução", EnumDataTipo.PassadoPresente, _Dev.TransacaoData, Me)
        frmDt.ShowDialog()
        '
        If frmDt.DialogResult <> DialogResult.OK Then Exit Sub
        '
        Dim newDt As Date = frmDt.propDataInfo
        '
        '--- verifica a data bloqueada
        If DataBloqueada(newDt, Obter_ContaPadrao) Then Exit Sub
        '
        '--- altera a data da DEVOLUCAO e salva no BD
        Try
            '
            Dim tranBLL As New TransacaoBLL
            If tranBLL.AtualizaTransacaoData(_Dev.IDDevolucao, newDt) Then
                '
                _Dev.TransacaoData = frmDt.propDataInfo
                lblTransacaoData.DataBindings("Text").ReadValue()
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao alterar a Data da Devolucao..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "MENU ACAO INFERIOR"
    '
    '--- CONTROLE DO MENU ACAO INFERIOR
    '=====================================
    Private Sub tsbButtonClick(sender As Object, e As EventArgs)
        '
        DirectCast(sender, ToolStripSplitButton).ShowDropDown()
        '
    End Sub
    '
    Private Sub MenuOpen_AdHandler()
        '
        AddHandler btnImprimir.ButtonClick, AddressOf tsbButtonClick
        AddHandler btnImprimir.MouseHover, AddressOf tsbButtonClick
        '
    End Sub
    '
    ' MENU ACAO INFERIOR
    '=====================================
    '
    ' PROCURAR
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        '--- ask user
        If Not CanCloseMessage() Then Exit Sub
        '
        '--- procura
        ProcuraDevolucao()
        '
    End Sub
    '
    ' ADICIONAR
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        '
        '--- ask user
        If Not CanCloseMessage() Then Exit Sub
        '
        '--- execute
        NovaDevolucao()
        '
    End Sub
    '
    ' EXCLUIR
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        '--- Verifica bloqueio
        If RegistroBloqueado() Then Exit Sub
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você deseja realmente excluir definitivamente essa Devolução?",
                           "Excluir DEVOLUÇÃO",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '--- Excluir DEVOLUCAO
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If devBLL.DeletaDevolucaoPorID(_Dev.IDDevolucao, _IDFilial) Then
                '
                '--- fecha
                Close()
                MostraMenuPrincipal()
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir a Devolução..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    ' DESBLOQUEAR DEVOLUCAO
    Private Sub btnDesbloquear_Click(sender As Object, e As EventArgs) Handles btnDesbloquear.Click
        '
        '--- Verifica se registro esta bloqueado
        If Sit <> EnumFlagEstado.RegistroBloqueado Then Exit Sub
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If devBLL.DevolucaoDesbloquear(_Dev) Then Sit = EnumFlagEstado.RegistroSalvo
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Desbloquear Registro..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    ' IMPRIMIR
    Private Sub miImprimirRelatorio_Click(sender As Object, e As EventArgs) Handles miImprimirRelatorio.Click
        MessageBox.Show("Ainda não foi implementado...")
    End Sub
    '
    ' CRIA UMA NOVA DEVOLUCAO
    '-----------------------------------------------------------------------------------------------------
    Public Sub NovaDevolucao()
        Dim acao As New AcaoGlobal
        Dim newDev As Object = acao.DevolucaoSaida_Nova
        '
        If IsNothing(newDev) Then Exit Sub
        '
        _Dev = newDev
        '
    End Sub
    '
    ' PROCURA DEVOLUCAO
    '-----------------------------------------------------------------------------------------------------
    Public Sub ProcuraDevolucao()
        '
        Me.Close()
        Dim frmP As New frmOperacaoSaidaProcurar(TransacaoBLL.EnumOperacao.DevolucaoDeSaida)
        OcultaMenuPrincipal()
        Dim fPrincipal As Form = Application.OpenForms.OfType(Of frmPrincipal)().First
        frmP.MdiParent = fPrincipal
        frmP.Show()
        '
    End Sub
    '
#End Region '/ MENU ACAO INFERIOR
    '
#Region "FORMATACAO E FLUXO"
    '
    ' CRIA TECLA DE ATALHO PARA O CONTROLE DE TABULACAO
    '---------------------------------------------------------------------------------------------------
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.D1 Then
            tabPrincipal.SelectedTab = vtab1
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D2 Then
            tabPrincipal.SelectedTab = vtab2
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D3 Then
            tabPrincipal.SelectedTab = vtab3
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        End If
    End Sub
    '
    Private Sub tabPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPrincipal.SelectedIndexChanged
        '
        If tabPrincipal.SelectedIndex = 0 Then
            dgvItens.Focus()
        ElseIf tabPrincipal.SelectedIndex = 1 Then
            txtValorDescontos.Focus()
        ElseIf tabPrincipal.SelectedIndex = 2 Then
            dgvNotasFiscais.Focus()
        End If
        '
    End Sub
    '
    ' HABILITA OU DESABILITA OS CONTROLES DO FRETE
    '---------------------------------------------------------------------------------------------------
    Private Sub cmbFreteTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Controla_cmbFrete()
    End Sub
    '
    Public Sub Controla_cmbFrete()
        If Not IsNumeric(cmbFreteTipo.SelectedValue) Then Exit Sub
        '
        'If cmbFreteTipo.SelectedValue = 0 Then
        If _Dev.FreteTipo = 0 Then
            '--- Nulifica os valores das propriedades do Frete
            _Dev.IDTransportadora = Nothing
            _Dev.FreteValor = Nothing
            _Dev.Volumes = Nothing
            '--- Atualiza os novos valores dos controles
            If cmbIDTransportadora.DataBindings.Count > 0 Then
                cmbIDTransportadora.DataBindings.Item("SelectedValue").ReadValue()
                cmbIDTransportadora.Text = String.Empty
                txtFreteValor.DataBindings.Item("Text").ReadValue()
                txtVolumes.DataBindings.Item("Text").ReadValue()
            End If
            '--- Desabilita os controles
            cmbIDTransportadora.Enabled = False
            txtFreteValor.Enabled = False
            txtVolumes.Enabled = False
        Else
            '--- Habilita os controles
            cmbIDTransportadora.Enabled = True
            txtFreteValor.Enabled = True
            txtVolumes.Enabled = True
        End If
        '
    End Sub
    '
    ' CONVERTE ENTER EM TAB DE ALGUNS CONTROLES
    '---------------------------------------------------------------------------------------------------
    Private Sub Text_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValorAcrescimos.KeyDown,
        txtFreteValor.KeyDown, txtValorDescontos.KeyDown,
        txtVolumes.KeyDown, txtObservacao.KeyDown
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
#End Region ' /FORMATACAO E FLUXO
    '
#Region "FINALIZAR"
    '
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        '
        '--- Verifica se a SITUACAO do registro permite salvar
        If Sit = EnumFlagEstado.Alterado OrElse Sit = EnumFlagEstado.NovoRegistro Then
            '
            '--- Faz as VERIFICACOES DOS CAMPOS E VALORES
            If Verificar() = False Then Exit Sub
            '
            '--- PERGUNTA AO USUÁRIO
            If MessageBox.Show("Deseja realmente Finalizar essa Transação de Devolução?", "Finalizar Devolução",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
            '
            '--- INICIA A TRANSACAO NO BD
            '----------------------------------------------------------------------------------------
            Dim tranBLL As New TransactionControlBLL
            Dim dbTran As Object = tranBLL.GetNewAcessoWithTransaction
            '
            '--- SALVA O ARECEBER NO BD
            '----------------------------------------------------------------------------------------
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                If Salvar_AReceber(dbTran) = False Then
                    '
                    '--- rollback trasaction
                    tranBLL.RollbackAcessoWithTransaction(dbTran)
                    Exit Sub
                    '
                End If
                '
            Catch ex As Exception
                '
                '--- RollBack Transaction
                tranBLL.RollbackAcessoWithTransaction(dbTran)
                '
                MessageBox.Show("Uma exceção ocorreu ao Salvar o A Receber..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
            '--- SALVA A TRANSACAO/DEVOLUCAO NO BD
            '----------------------------------------------------------------------------------------
            '--- verifica se os creditos ja foram totalizados
            If AtualizaTotalGeral() <= AtualizaTotalCreditos() Then
                _Dev.Creditada = True
                _Dev.IDSituacao = 3 '--- bloqueada
            Else
                _Dev.Creditada = False
                _Dev.IDSituacao = 2 '--- finalizada
            End If
            '
            If SalvarRegistro(dbTran) Then
                '--- COMMIT all 
                tranBLL.CommitAcessoWithTransaction(dbTran)
            Else
                '--- RollBack Transaction
                tranBLL.RollbackAcessoWithTransaction(dbTran)
            End If
            '
            '--- ALTERA A SITUACAO DO REGISTRO ATUAL
            '----------------------------------------------------------------------------------------
            If _Dev.IDSituacao = 2 Then
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
        End If
        '
        '--- PERGUNTA O QUE O USUARIO DESEJA FAZER
        '----------------------------------------------------------------------------------------
        Dim fAcao As New frmAcaoDialog(Me, "Devolução de Compra")
        '
        fAcao.ShowDialog()
        '
        If fAcao.DialogResult = DialogResult.Cancel Then
            Close()
            MostraMenuPrincipal()
        End If
        '
    End Sub
    '
    '--- SALVA A DEVOLUCAO NO BD
    Private Function SalvarRegistro(Optional dbTran As Object = Nothing) As Boolean
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim obj As Object = devBLL.Update_Devolucao(_Dev, dbTran)
            '
            If Not IsNumeric(obj) Then
                Throw New Exception(obj.ToString)
                Return False
            End If
            '
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar a Devolução no BD..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
    Private Function Verificar() As Boolean
        '--- Verifica se a Data não está BLOQUEADA pelo sistema?
        '
        '----------------------------------------------------------------------------------------------
        ' VERIFICA OS VALORES DA DEVOLUCAO E DO FRETE
        '----------------------------------------------------------------------------------------------
        '
        '--- Verifica o valor da DEVOLUCAO
        If AtualizaTotalGeral() = 0 Then
            MessageBox.Show("Não é possível finalizar uma Devolução de Compra cujo valor final é igual a Zero..." & vbNewLine &
                            "Favor incluir alguns produtos nessa Devolução.",
                            "Devolução de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab1
            dgvItens.Focus()
            Return False
        End If
        '
        '--- Verifica se há TIPO DE FRETE
        If IsNothing(_Dev.FreteTipo) Then
            MessageBox.Show("O campo TIPO DE FRETE não pode ficar vazio...", "Campo Necessário",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            cmbFreteTipo.Focus()
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    '--- SALVA | UPDATE A RECEBER
    Private Function Salvar_AReceber(dbTran As Object) As Boolean
        '
        Dim rBLL As New AReceberBLL
        '
        Dim rec As New clAReceber With {
            .IDAReceber = _Dev.IDAReceber,
            .IDFilial = _Dev.IDPessoaOrigem,
            .IDPessoa = _Dev.IDPessoaDestino,
            .IDOrigem = _Dev.IDDevolucao,
            .Origem = clAReceber.EnumAReceberOrigem.DevolucaoSaida,
            .SituacaoAReceber = 0,
            .AReceberValor = _Dev.ValorTotal,
            .ValorPagoTotal = AtualizaTotalCreditos()
        }
        '
        Try
            '--- Update A Receber
            rBLL.Update_AReceber(rec, dbTran)
            '
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao SALVAR o AReceber..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
    End Function
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS"
    '
    ' ATUALIZA O TOTAL DO GERAL
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalGeral() As Double
        '
        Dim T = AtualizaTotalProdutos() + _Dev.ValorAcrescimos - _Dev.ValorDescontos
        lblTotalGeral.DataBindings.Item("text").ReadValue()
        Return T
        '
    End Function
    '
    ' ATUALIZA O TOTAL DOS PRODUTOS VENDIDOS
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalProdutos() As Double
        '
        Dim T As Double = _ItensList.Sum(Function(x) x.Total)
        _Dev.ValorProdutos = T
        lblValorProdutos.DataBindings.Item("text").ReadValue()
        Return T
        '
    End Function
    '
    ' ATUALIZA O TOTAL DOS CREDITOS
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalCreditos() As Double
        '
        Dim T As Double = _MovEntradaList.Sum(Function(x) x.MovValor)
        lblTotalPago.Text = Format(T, "c")
        Return T
        '
    End Function
    '
    ' RECALCULA VALORES QUANDO ALTERA CONTROLES VALOR
    '-----------------------------------------------------------------------------------------------------
    Private Sub ValorText_Validated(sender As Object, e As EventArgs) Handles _
            txtValorAcrescimos.Validated, txtValorDescontos.Validated
        '
        AtualizaTotalGeral()
        '
    End Sub
    '
    '--- VERIFICA O SE O NOVO VALOR INSERIDO TORNARIA O TOTAL NEGATIVO
    Private Sub txtValorDescontos_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtValorDescontos.Validating
        '
        Dim t As Decimal = _Dev.ValorProdutos + _Dev.ValorAcrescimos
        '
        If String.IsNullOrEmpty(txtValorDescontos.Text) Then
            txtValorDescontos.Text = 0
        End If
        '
        If t - txtValorDescontos.Text < 0 Then
            '--- EMITE O ERROR PROVIDER
            EP.SetError(sender, "Valor não pode ser maior que: R$ " & Format(t, "#,##.00"))
            txtValorDescontos.Text = t
            e.Cancel = True
        Else
            EP.Clear()
        End If
        '
    End Sub
    '
    Private Sub txtValorAcrescimos_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtValorAcrescimos.Validating
        '
        Dim t As Decimal = _Dev.ValorProdutos - _Dev.ValorDescontos

        If String.IsNullOrEmpty(txtValorAcrescimos.Text) Then
            txtValorAcrescimos.Text = 0
        End If
        '
        If t + txtValorAcrescimos.Text < 0 Then
            '--- EMITE O ERROR PROVIDER
            EP.SetError(sender, "Valor não pode ser menor que: R$ " & Format(Math.Abs(t), "#,##.00"))
            txtValorAcrescimos.Text = Math.Abs(t)
            e.Cancel = True
        Else
            EP.Clear()
        End If
        '
    End Sub
    '
#End Region '/FUNCOES NECESSARIAS
    '
#Region "BLOQUEIO DE REGISTROS"
    '
    ' PROIBE EDICAO NOS COMBOBOX QUANDO DEVOLUCAO BLOQUEADA
    '-----------------------------------------------------------------------------------------------------
    Private Sub ComboBox_SelectedValueChanged(sender As Object, e As EventArgs) _
        Handles cmbFreteTipo.SelectedValueChanged,
                cmbIDTransportadora.SelectedValueChanged
        '
        If (Sit = EnumFlagEstado.RegistroBloqueado Or _Dev.Enviada) AndAlso VerificaAlteracao = True Then
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            '
            Select Case cmb.Name
                Case "cmbFreteTipo"
                    VerificaAlteracao = False
                    cmbFreteTipo.SelectedValue = IIf(IsNothing(_Dev.FreteTipo), -1, _Dev.FreteTipo)
                    VerificaAlteracao = True
                Case "cmbIDTransportadora"
                    VerificaAlteracao = False
                    cmbIDTransportadora.SelectedValue = IIf(IsNothing(_Dev.IDTransportadora), -1, _Dev.IDTransportadora)
                    VerificaAlteracao = True
            End Select
            '
            '--- emite mensagem padrao
            RegistroBloqueado()
            '
        End If
        '
    End Sub
    '
    ' FUNCAO QUE CONFERE REGISTRO BLOQUEADO E EMITE MENSAGEM PADRAO
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroBloqueado() As Boolean
        '
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            MessageBox.Show("Esse registro de Devolução está BLOQUEADO para alterações..." &
                            vbNewLine & vbNewLine &
                            "Não é possível adicionar produtos, excluir ou alterar algum dado!",
                            "Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    ' FUNCAO QUE CONFERE REGISTRO FINALIZADO E PERGUNTA SE DESEJA ALTERAR
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroFinalizado() As Boolean
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            If MessageBox.Show("Esse registro de Devolução já se encontra FINALIZADO..." & vbNewLine &
                               "Deseja realmente fazer alterações nesse registro?",
                               "Registro Finalizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                '
                '--- Edita o registro e altera a situação
                _Dev.IDSituacao = 1
                '
                '--- SALVA A TRANSACAO/DEVOLUCAO NO BD
                SalvarRegistro()
                '
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
        '
    End Function
    '
    Private Function CanCloseMessage() As Boolean
        '
        If MessageBox.Show("ALTERAÇÕES DA DEVOLUÇÃO NÃO SERÃO SALVAS!" & vbNewLine & vbNewLine &
                           "Se você fechar agora essa Devolução," & vbNewLine &
                           "algumas alterações podem ser perdidas," & vbNewLine &
                           "inclusive as alterações no Parcelamento..." & vbNewLine & vbNewLine &
                           "Deseja FECHAR a Devolução assim mesmo?", "Devolução não Finalizada",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
            '
            '--- Seleciona a TAB
            tabPrincipal.SelectedTab = vtab2
            '
            '--- Select Control txtValorFrete
            txtValorDescontos.Focus()
            '
            '--- return
            Return False
            '
        End If
        '
        '--- return
        Return True
        '
    End Function
    '
    '----VERIFICA SE A DEVOLUCAO FOI ENVIADA E BLOQUEIA OS ITENS
    '-----------------------------------------------------------------------------------------------------
    Private Function DevolucaoEnviada(source As String) As Boolean
        '
        'source => dgvItens OR dgvEntradas
        '
        If _Dev.Enviada Then
            '
            '--- emite a mensagem de aviso
            If source = "dgvItens" Then
                MessageBox.Show("Essa Devolução está BLOQUEADA para inserir produtos porque já foi enviada..." &
                                vbNewLine & vbNewLine &
                                "Não é possível adicionar, alterar ou excluir produtos.",
                                "Devolução Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '--- return
            Return True
            '
        Else
            '
            '--- emite a mensagem de aviso
            If source = "dgvEntradas" Then
                MessageBox.Show("Essa Devolução ainda está BLOQUEADA para inserir créditos, porque ainda não foi enviada...." &
                                vbNewLine & vbNewLine &
                                "Não é possível adicionar, alterar ou excluir créditos.",
                                "Devolução Não Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '--- return
            Return False
            '
        End If
        '
    End Function
    '
#End Region
    '
#Region "CONTROLE DO CHECK ENVIADA"
    '
    '--- VERIFICA A ALTERACAO DE ENVIADA E SALVA REGISTRO
    Private Sub HandlerAoEnviadaAlterar()
        '
        '--- salvar o registro no BD
        SalvarRegistro()
        '
    End Sub
    '
    Private Sub chkEnviada_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnviada.CheckedChanged
        '
        '--- Se foi enviada porem sem produtos
        If chkEnviada.Checked AndAlso AtualizaTotalProdutos() <= 0 Then
            '
            MessageBox.Show("Não é possível enviar uma devolução que ainda não tem produtos..." &
                            vbNewLine & "Favor informar os produtos antes de enviar a devolução.",
                            "Devolução Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chkEnviada.Checked = False
            Exit Sub
            '
        ElseIf Not chkEnviada.Checked AndAlso _MovEntradaList.Count > 0 Then '--- impedir não enviada porem com credito devolucao
            '
            MessageBox.Show("Não é possível alterar o estado do envio uma devolução que possui créditos de devolução..." &
                            vbNewLine & "Se ainda desejar alterar, exclua todos os créditos de devolução.",
                            "Devolução Enviada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chkEnviada.Checked = True
            Exit Sub
            '
        End If
        '
        If chkEnviada.Checked <> _Dev.Enviada Then
            '
            If chkEnviada.Checked Then
                '--- pergunta ao usuario
                If MessageBox.Show("Essa devolução já foi enviada?",
                                   "Devolução Enviada", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    chkEnviada.Checked = _Dev.Enviada
                    Exit Sub
                End If
            End If
            '
            If chkEnviada.Checked Then
                lblEnviada.Text = "Enviada"
            Else
                lblEnviada.Text = "Não Enviada"
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub VerificaEnviada()
        '
        If _Dev.Enviada Then
            lblEnviada.Text = "Enviada"
            txtValorDescontos.ReadOnly = True
            txtValorAcrescimos.ReadOnly = True
        Else
            lblEnviada.Text = "Não Enviada"
            txtValorDescontos.ReadOnly = False
            txtValorDescontos.ReadOnly = False
        End If
        '
    End Sub
    '
#End Region '/ CONTROLE DO CHECK ENVIADA
    '
End Class
