Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmVendaPrazo
    '
    Private vndBLL As New VendaBLL
    Private _Venda As clVenda
    Private _Troca As clTroca
    '
    Private _ItensList As New List(Of clTransacaoItem)
    Private _ParcelaList As New List(Of clAReceberParcela)
    '
    Private bindVenda As New BindingSource
    Private bindItem As New BindingSource
    Private bindParc As New BindingSource
    '
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _IDFilial As Integer
    Private VerificaAlteracao As Boolean
    Private Taxa As Double?
    Property DescontoMaximo As Double
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
                    btnTroca.Enabled = True
                    btnVendedorAlterar.Enabled = True
                    btnData.Enabled = True
                    txtFreteValor.ReadOnly = False
                    txtObservacao.ReadOnly = False
                    txtVolumes.ReadOnly = False
                    '
                    txtValorFrete.ReadOnly = False
                    txtValorImpostos.ReadOnly = False
                    txtValorAcrescimos.ReadOnly = False
                    '
                    btnExcluirVenda.Enabled = True
                    btnDesbloquearVenda.Enabled = False
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    lblSituacao.Text = "Alterada"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    btnTroca.Enabled = True
                    btnVendedorAlterar.Enabled = True
                    btnData.Enabled = True
                    txtFreteValor.ReadOnly = False
                    txtObservacao.ReadOnly = False
                    txtVolumes.ReadOnly = False
                    '
                    txtValorFrete.ReadOnly = False
                    txtValorImpostos.ReadOnly = False
                    txtValorAcrescimos.ReadOnly = False
                    '
                    btnExcluirVenda.Enabled = True
                    btnDesbloquearVenda.Enabled = False
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    lblSituacao.Text = "Em Aberto"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    btnTroca.Enabled = True
                    btnVendedorAlterar.Enabled = True
                    btnData.Enabled = True
                    txtFreteValor.ReadOnly = False
                    txtObservacao.ReadOnly = False
                    txtVolumes.ReadOnly = False
                    '
                    txtValorFrete.ReadOnly = False
                    txtValorImpostos.ReadOnly = False
                    txtValorAcrescimos.ReadOnly = False
                    '
                    btnExcluirVenda.Enabled = True
                    btnDesbloquearVenda.Enabled = False
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    lblSituacao.Text = "Bloqueada"
                    btnFinalizar.Text = "&Fechar"
                    '
                    btnTroca.Enabled = False
                    btnVendedorAlterar.Enabled = False
                    btnData.Enabled = False
                    txtFreteValor.ReadOnly = True
                    txtObservacao.ReadOnly = True
                    txtVolumes.ReadOnly = True
                    '
                    txtValorFrete.ReadOnly = True
                    txtValorImpostos.ReadOnly = True
                    txtValorAcrescimos.ReadOnly = True
                    '
                    btnExcluirVenda.Enabled = False
                    btnDesbloquearVenda.Enabled = True
                    '
            End Select
            '
        End Set
        '
    End Property
    '
    Property propVenda As clVenda
        '
        Get
            Return _Venda
        End Get
        '
        Set(value As clVenda)
            '
            VerificaAlteracao = False '--- Inibe a verificacao dos campos IDPlano
            _Venda = value
            _IDFilial = _Venda.IDPessoaOrigem
            obterItens()
            obterParcelas()
            bindItem.DataSource = _ItensList
            bindParc.DataSource = _ParcelaList
            dgvItens.DataSource = bindItem
            '
            '--- Verifica se existe TROCA anexada a venda e preenche o _troca (clTroca)
            VerificaTroca()
            '
            If IsNothing(bindVenda.DataSource) Then
                bindVenda.DataSource = _Venda
                PreencheDataBinding()
            Else
                bindVenda.Clear()
                bindVenda.DataSource = _Venda
                bindVenda.ResetBindings(True)
            End If
            '
            '--- Preenche os Itens da Venda
            PreencheItens()
            '
            '--- Preenche Itens do A Receber (parcelas)
            Preenche_AReceber()
            cmbIDPlano.SelectedValue = If(_Venda.IDPlano, -1)
            cmbIDCobrancaForma.SelectedValue = If(_Venda.IDCobrancaForma, -1)
            '
            '--- Atualiza o estado da Situacao: EnumFlagEstado
            Select Case _Venda.IDSituacao
                Case 1 ' VENDA INICIADA
                    Sit = EnumFlagEstado.NovoRegistro
                Case 2 ' VENDA FINALIZADA
                    Sit = EnumFlagEstado.RegistroSalvo
                Case 3 ' VENDA BLOQUEADA
                    Sit = EnumFlagEstado.RegistroBloqueado
                Case Else
            End Select
            '
            '--- Habilita ou Desabilita os campos do Frete da Venda
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
    Public Sub New(myVenda As clVenda)
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propVenda = myVenda
        '
        '--- Define a TAXA PERMANENCIA padrao
        Try
            Taxa = Convert.ToDouble(ObterDefault("TaxaPermanencia"))
        Catch ex As Exception
            Taxa = 0
        End Try
        '
        '--- Define a DESCONTO MAXIMO padrao
        DescontoMaximo = Obter_DescontoMaximo()
        '
        '--- hANDLER Menu Acao
        MenuOpen_AdHandler()
        '
    End Sub
    '
    Private Sub frmVendaPrazo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- desabilita a verificacao de bloqueio
        VerificaAlteracao = False
        '
        '--- faz a leitura dos combobox para nao emitir mensagem na alteracao do TAB
        cmbVendaTipo.SelectedValue = _Venda.IDVendaTipo
        cmbIDCobrancaForma.SelectedValue = If(_Venda.IDCobrancaForma, -1)
        cmbFreteTipo.SelectedValue = _Venda.FreteTipo
        cmbIDTransportadora.SelectedValue = If(_Venda.IDTransportadora, -1)
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
        lblCliente.DataBindings.Add("Text", bindVenda, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblIDVenda.DataBindings.Add("Text", bindVenda, "IDVenda", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindVenda, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        lblVendaData.DataBindings.Add("Text", bindVenda, "TransacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        lblVendedor.DataBindings.Add("Text", bindVenda, "ApelidoFuncionario", True, DataSourceUpdateMode.OnPropertyChanged)
        txtVolumes.DataBindings.Add("Text", bindVenda, "Volumes", True, DataSourceUpdateMode.OnPropertyChanged)
        txtFreteValor.DataBindings.Add("Text", bindVenda, "FreteValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindVenda, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblValorProdutos.DataBindings.Add("Text", bindVenda, "ValorProdutos", True, DataSourceUpdateMode.OnPropertyChanged)
        txtValorFrete.DataBindings.Add("Text", bindVenda, "ValorFrete", True, DataSourceUpdateMode.OnPropertyChanged)
        txtValorImpostos.DataBindings.Add("Text", bindVenda, "ValorImpostos", True, DataSourceUpdateMode.OnPropertyChanged)
        txtValorAcrescimos.DataBindings.Add("Text", bindVenda, "ValorAcrescimos", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTotalGeral.DataBindings.Add("Text", bindVenda, "TotalVenda", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDVenda.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler txtFreteValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblValorProdutos.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtValorAcrescimos.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtValorFrete.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtValorImpostos.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblTotalGeral.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtVolumes.DataBindings("text").Format, AddressOf Format00
        AddHandler lblVendaData.DataBindings("text").Format, AddressOf FormatDT
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbVendaCobranca()
        CarregaCmbPlano()
        CarregaCmbFreteTipo()
        CarregaCmbTransportadora()
        CarregaCmbVendaTipo()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Venda.AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Venda.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
    ' CARREGA OS COMBOBOX
    '--------------------------------------------------------------------------------------------------------
    Private Sub CarregaCmbVendaCobranca()
        Dim sql As New SQLControl
        sql.ExecQuery("SELECT * FROM tblCobrancaForma WHERE Ativo = 'TRUE' AND Entradas = 'TRUE'")
        '
        If sql.HasException(True) Then
            Exit Sub
        End If
        '
        With cmbIDCobrancaForma
            .DataSource = sql.DBDT
            .ValueMember = "IDCobrancaForma"
            .DisplayMember = "CobrancaForma"
            .DataBindings.Add("SelectedValue", bindVenda, "IDCobrancaForma", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
    Private Sub CarregaCmbPlano()
        '
        Dim sql As New SQLControl
        sql.ExecQuery("SELECT * FROM tblVendaPlanos WHERE Ativo = 'TRUE'")
        '
        If sql.HasException(True) Then
            Exit Sub
        End If
        '
        With cmbIDPlano
            .DataSource = sql.DBDT
            .ValueMember = "IDPlano"
            .DisplayMember = "Plano"
            .DataBindings.Add("SelectedValue", bindVenda, "IDPlano", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
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
            .DataBindings.Add("SelectedValue", bindVenda, "FreteTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
    Private Sub CarregaCmbVendaTipo()
        '
        Try
            Dim dtVendaTipo As DataTable = vndBLL.GetVendaTipo_DT '--- Datatable do combo VendaTipo (Altera se há troca)
            '
            With cmbVendaTipo
                .DataSource = dtVendaTipo '--- a lista depende se ha troca/devolucao ou nao
                .ValueMember = "IDVendaTipo"
                .DisplayMember = "VendaTipo"
                .DataBindings.Add("SelectedValue", bindVenda, "IDVendaTipo", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter os tipos de Venda..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                .DataBindings.Add("SelectedValue", bindVenda, "IDTransportadora", True, DataSourceUpdateMode.OnPropertyChanged)
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
    '--- RETORNA TODOS OS ITENS DA VENDA
    Private Sub obterItens()
        Dim tBLL As New TransacaoItemBLL
        Try
            _ItensList = tBLL.GetTransacaoItens_List(_Venda.IDVenda, _IDFilial)
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter Itens da Venda:" & vbNewLine &
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
        '
        '--- Abre o frmItem
        Dim newItem As New clTransacaoItem
        '
        Dim fItem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_VENDA, _IDFilial, newItem)
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
            newItem.IDTransacao = _Venda.IDVenda
            myID = ItemBLL.InserirNovoItem(newItem,
                                           TransacaoItemBLL.EnumMovimento.SAIDA,
                                           _Venda.TransacaoData,
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
        '
        '--- Verifica se há um item selecionado
        If dgvItens.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- obtem o itemAtual
        Dim itmAtual As clTransacaoItem
        itmAtual = dgvItens.SelectedRows(0).DataBoundItem
        '
        '--- Abre o frmItem
        Dim fitem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_VENDA, _IDFilial, itmAtual)
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
            itmAtual.IDTransacao = _Venda.IDVenda
            myID = ItemBLL.EditarItem(itmAtual,
                                      TransacaoItemBLL.EnumMovimento.SAIDA,
                                      _Venda.TransacaoData,
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
        '
        '--- Verifica se há um item selecionado
        If dgvItens.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- obtem o itemAtual
        Dim itmAtual As clTransacaoItem
        itmAtual = dgvItens.SelectedRows(0).DataBoundItem
        '
        '--- pergunta ao usuário se deseja excluir o item
        If MessageBox.Show("Deseja realmente REMOVER esse item da Venda?" & vbNewLine & vbNewLine &
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
    ' CONTROLA O MENU CONTEXTO NO DATAGRID ARECEBER
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvAReceber_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvAReceber.MouseDown
        If e.Button = MouseButtons.Right Then
            'Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvAReceber.HitTest(e.X, e.Y)
            dgvAReceber.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvAReceber.CurrentCell = dgvAReceber.Rows(hit.RowIndex).Cells(1)
            dgvAReceber.Rows(hit.RowIndex).Selected = True
            dgvAReceber.Focus()
            '
            mnuContexto.Show(dgvAReceber, e.Location)
            '
        End If
    End Sub
    '
    ' CONTROLA ACOES DO MENU CONTEXTO
    '-----------------------------------------------------------------------------------------------------
    Private Sub MenuItemEditar_Click(sender As Object, e As EventArgs) Handles mnuItemEditar.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Editar_Item()
        Else
            Parcela_Editar()
        End If
        '
    End Sub
    '
    Private Sub MenuItemInserir_Click(sender As Object, e As EventArgs) Handles mnuItemInserir.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Inserir_Item()
        Else
            Parcela_Adicionar()
        End If
        '
    End Sub
    '
    Private Sub MenuItemExcluir_Click(sender As Object, e As EventArgs) Handles mnuItemExcluir.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Excluir_Item()
        Else
            Parcela_Excluir()
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
    '--- ALTERA O VENDEDOR E SALVA NO BD
    Private Sub btnVendedorAlterar_Click(sender As Object, e As EventArgs) Handles btnVendedorAlterar.Click
        '
        Dim fFunc As New frmFuncionarioProcurar(True, Me)
        fFunc.ShowDialog()
        If fFunc.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Try
            Dim newID As Integer = fFunc.IDEscolhido
            '
            If vndBLL.AtualizaVendaVendedor(_Venda.IDVenda, newID) Then
                _Venda.IDVendedor = newID
                _Venda.ApelidoFuncionario = fFunc.NomeEscolhido
                lblVendedor.DataBindings("Text").ReadValue()
            End If
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao atualizar o Vendedor..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- ALTERAR A DATA DA VENDA
    Private Sub lblVendaData_DoubleClick(sender As Object, e As EventArgs) _
        Handles lblVendaData.DoubleClick, btnData.Click
        '
        Dim frmDt As New frmDataInformar("Informe a data da Venda", EnumDataTipo.PassadoPresente, _Venda.TransacaoData, Me)
        frmDt.ShowDialog()
        '
        If frmDt.DialogResult <> DialogResult.OK Then Exit Sub
        '
        Dim newDt As Date = frmDt.propDataInfo
        '
        '--- verifica a data bloqueada
        If DataBloqueada(newDt, Obter_ContaPadrao) Then Exit Sub
        '
        '--- altera a data da venda e salva no BD
        Try
            '
            Dim tranBLL As New TransacaoBLL
            If tranBLL.AtualizaTransacaoData(_Venda.IDVenda, newDt) Then
                '
                _Venda.TransacaoData = frmDt.propDataInfo
                lblVendaData.DataBindings("Text").ReadValue()
                '
                '--- verifica se existe troca e altera a data da troca
                If Not IsNothing(_Troca) Then
                    Dim tBLL As New TrocaBLL
                    _Troca.TrocaData = newDt
                    tBLL.AtualizaTroca_Procedure_ID(_Troca)
                End If
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao alterar a Data da Venda..." & vbNewLine &
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
        ProcuraVenda()
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
        NovaVenda()
        '
    End Sub
    '
    ' EXCLUIR
    Private Sub btnExcluirVenda_Click(sender As Object, e As EventArgs) Handles btnExcluirVenda.Click
        '
        '--- Verifica bloqueio
        If RegistroBloqueado() Then Exit Sub
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você deseja realmente excluir definitivamente essa Venda?",
                           "Excluir Venda",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '--- Excluir Venda
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If vndBLL.DeletaVendaPorID(_Venda.IDVenda, _IDFilial) Then
                '
                '--- fecha
                Close()
                MostraMenuPrincipal()
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir a Venda..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    ' DESBLOQUEAR VENDA
    Private Sub btnDesbloquearVenda_Click(sender As Object, e As EventArgs) Handles btnDesbloquearVenda.Click
        '
        '--- Verifica se registro esta bloqueado
        If Sit <> EnumFlagEstado.RegistroBloqueado Then Exit Sub
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If vndBLL.VendaDesbloquear(_Venda) Then Sit = EnumFlagEstado.RegistroSalvo
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
    Private Sub miImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles miImprimirEtiquetas.Click
        MessageBox.Show("Ainda não foi implementado...")
    End Sub
    '
    ' CRIA UMA NOVA VENDA
    '-----------------------------------------------------------------------------------------------------
    Public Sub NovaVenda()
        Dim v As New AcaoGlobal
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newVenda As Object = v.VendaPrazo_Nova
            '
            If IsNothing(newVenda) Then Exit Sub
            '
            propVenda = newVenda
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inserir Nova Venda Prazo..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    ' PROCURA VENDA
    '-----------------------------------------------------------------------------------------------------
    Public Sub ProcuraVenda()
        '
        Me.Close()
        Dim frmP As New frmOperacaoSaidaProcurar
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
            txtValorFrete.Focus()
        ElseIf tabPrincipal.SelectedIndex = 2 Then
            dgvVendaNotas.Focus()
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
        If _Venda.FreteTipo = 0 Then
            '--- Nulifica os valores das propriedades do Frete
            _Venda.IDTransportadora = Nothing
            _Venda.FreteValor = Nothing
            _Venda.Volumes = Nothing
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
    Private Sub Text_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValorFrete.KeyDown,
        txtValorImpostos.KeyDown, txtValorAcrescimos.KeyDown, txtFreteValor.KeyDown,
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
#Region "CONTROLE DO A RECEBER"
    '============================================================================================================
    ' A RECEBER CONTROLES
    '============================================================================================================
    '
    '--- RETORNA TODOS AS PARCELAS DE A RECEBER
    Private Sub obterParcelas()
        Dim rBLL As New ParcelaBLL
        Try
            _ParcelaList = rBLL.Parcela_GET_PorIDOrigem(1, _Venda.IDVenda)
            '--- Atualiza o label TOTAL
            AtualizaTotalAReceber()
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter o A Receber da Venda:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- Preenche o DataGrid AReceber
    Private Sub Preenche_AReceber()
        With dgvAReceber
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
            .DataSource = bindParc
            If .Rows.Count > 0 Then .CurrentCell = .Rows(.Rows.Count).Cells(1)
        End With
        '
        '--- formata as colunas do datagrid
        FormataGrid_AReceber()
        '
    End Sub
    '
    Private Sub FormataGrid_AReceber()
        '
        Dim cellStyleCur As New DataGridViewCellStyle
        cellStyleCur.Format = "c"
        cellStyleCur.NullValue = Nothing
        cellStyleCur.Alignment = DataGridViewContentAlignment.MiddleRight
        '
        ' (1) COLUNA IDAReceber
        dgvAReceber.Columns.Add("clnID", "ID")
        With dgvAReceber.Columns("clnID")
            .DataPropertyName = "IDAReceberParcela"
            .Width = 0
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA REG
        dgvAReceber.Columns.Add("clnReg", "Reg.")
        With dgvAReceber.Columns("clnReg")
            .DataPropertyName = "CodRegistro"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (3) COLUNA VENCIMENTO
        dgvAReceber.Columns.Add("clnVencimento", "Vencimento")
        With dgvAReceber.Columns("clnVencimento")
            .HeaderText = "Vencimento"
            .DataPropertyName = "Vencimento"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (4) COLUNA PERMANENCIA
        dgvAReceber.Columns.Add("clnPermanencia", "Perm.(%)")
        With dgvAReceber.Columns("clnPermanencia")
            .DataPropertyName = "PermanenciaTaxa"
            .DefaultCellStyle.Format = "0.00"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (5) COLUNA VALOR
        dgvAReceber.Columns.Add("clnValor", "Valor")
        With dgvAReceber.Columns("clnValor")
            .DefaultCellStyle = cellStyleCur
            .DataPropertyName = "ParcelaValor"
            .Width = 120
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
    Private Sub dgvAReceber_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAReceber.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            '
            Parcela_Adicionar()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            '
            Parcela_Editar()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            '
            Parcela_Excluir()
        End If
    End Sub
    '
    Private Sub Parcela_Adicionar()
        '
        '--- Atualiza o Valor do Total Geral
        Dim vl As Double = AtualizaTotalGeral()
        Dim totalParcelas As Double = AtualizaTotalAReceber()
        '
        '--- Verifica se o valor dos itens é maior que zero
        If vl = 0 Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Receber." & vbNewLine &
                            "O valor da Venda ainda é igual a Zero..." & vbNewLine &
                            "Adicione produtos primeiro e depois tente novamente.", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- Verifica se o valor das parcelas é maior que o total da venda
        If totalParcelas >= vl Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Receber..." & vbNewLine &
                            "O valor das Parcelas já é igual ou maior ao Total da Venda.",
                            "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- posiciona o form
        Dim pos As Point = dgvAReceber.PointToScreen(Point.Empty)
        pos = New Point(pos.X - 10, pos.Y) ' aparecer no lado esquerdo
        '
        '--- cria novo AReceber
        Dim clPar As New clAReceberParcela
        Dim ParcelaCount As Integer = _ParcelaList.Count
        Dim myLetra As Char = Chr(ParcelaCount + 65)
        '
        clPar.PermanenciaTaxa = Taxa / 100
        clPar.IDAReceber = _Venda.IDAReceber
        clPar.IDPessoa = _Venda.IDPessoaDestino
        clPar.ParcelaValor = vl - _ParcelaList.Sum(Function(x) x.ParcelaValor)
        clPar.Vencimento = _Venda.TransacaoData
        clPar.Letra = myLetra.ToString
        '
        '--- abre o form frmAReceber
        Dim fRec As New frmAReceberItem(Me, vl, _Venda.TransacaoData, clPar, EnumFlagAcao.INSERIR, pos)
        fRec.ShowDialog()
        '
        If fRec.DialogResult = DialogResult.OK Then
            ' SE A RESPOSTA DO DIALOG FOR OK
            '----------------------------------------------------------------------------------------------
            '--- Insere o ITEM na lista
            _ParcelaList.Add(fRec.propAReceber)
            bindParc.ResetBindings(False)
            '--- Atualiza o DataGrid
            dgvAReceber.DataSource = bindParc
            bindParc.MoveLast()
            '
            '--- AtualizaTotalAReceber
            AtualizaTotalAReceber()
            Sit = EnumFlagEstado.Alterado
            '
        End If
        '
    End Sub
    '
    Private Sub Parcela_Editar()
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        '--- posiciona o form
        Dim pos As Point = dgvAReceber.PointToScreen(Point.Empty)
        pos = New Point(pos.X - 10, pos.Y) ' aparecer no lado esquerdo
        '
        '--- GET AReceber do DataGrid
        If dgvAReceber.SelectedRows.Count = 0 Then Exit Sub
        '
        Dim ParcAtual As clAReceberParcela = dgvAReceber.SelectedRows(0).DataBoundItem
        Dim fRec As New frmAReceberItem(Me, AtualizaTotalGeral(), _Venda.TransacaoData, ParcAtual, EnumFlagAcao.EDITAR, pos)
        fRec.ShowDialog()
        '
        '--- AtualizaTotalAReceber
        AtualizaTotalAReceber()
        Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
    Private Sub Parcela_Excluir()
        '    
        '--- verifica se existe alguma parcela selecionada
        If dgvAReceber.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- seleciona a parcela
        Dim ParcAtual As clAReceberParcela
        ParcAtual = dgvAReceber.SelectedRows(0).DataBoundItem
        '
        '--- pergunta ao usuário se deseja excluir o item
        If MessageBox.Show("Deseja realmente REMOVER essa parcela A Receber?" & vbNewLine & vbNewLine &
                           ParcAtual.CodRegistro, "Excluir Parcela",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- envia o comando para excluir a parcela
        '
        Dim i As Integer = _ParcelaList.FindIndex(Function(x) x.Letra = ParcAtual.Letra)
        '
        '--- Atualiza o ITEM da lista
        _ParcelaList.RemoveAt(i)
        bindParc.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvAReceber.DataSource = bindParc
        '--- AtualizaTotalAReceber
        AtualizaTotalAReceber()
        Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
    Private Sub cmbIDPlano_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIDPlano.SelectionChangeCommitted
        '
        '--- Se não houver SelectedVaue então exit
        '----------------------------------------------------------------------------------------------
        If Not IsNumeric(cmbIDPlano.SelectedValue) OrElse VerificaAlteracao = False Then Exit Sub
        '
        '--- Se o registro da venda esta bloqueado não permite alteracao
        '----------------------------------------------------------------------------------------------
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            VerificaAlteracao = False
            cmbIDPlano.SelectedValue = IIf(IsNothing(_Venda.IDPlano), -1, _Venda.IDPlano)
            VerificaAlteracao = True
            RegistroBloqueado() '--- mensagem padrao
            Exit Sub
        End If
        '
        '--- Se Valor Total da Venda for igual a Zero então Avisa e Exit
        '----------------------------------------------------------------------------------------------
        Dim vlTotal As Double = AtualizaTotalGeral()
        If vlTotal = 0 Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Receber" & vbNewLine &
                            "Quando o valor da Venda ainda é igual a Zero..." & vbNewLine &
                            "Adicione produtos primeiro e depois tente novamente.", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            VerificaAlteracao = False
            cmbIDPlano.SelectedValue = IIf(IsNothing(_Venda.IDPlano), -1, _Venda.IDPlano)
            VerificaAlteracao = True
            Exit Sub
        End If
        '
        '--- Pergunta ao usuario se for alteracao do plano
        '----------------------------------------------------------------------------------------------
        If Not IsNothing(_Venda.IDPlano) Then 'AndAlso cmbIDPlano.SelectedValue <> _Venda.IDPlano Then
            Dim a As DialogResult
            a = MessageBox.Show("Você deseja realmente alterar a forma de parcelamento dessa venda?",
                                "Alterar Parcelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If a = DialogResult.No Then
                VerificaAlteracao = False
                cmbIDPlano.SelectedValue = IIf(IsNothing(_Venda.IDPlano), -1, _Venda.IDPlano)
                VerificaAlteracao = True
                Exit Sub
            End If
        End If
        '
        '--- Verifica se o parcelamento escolhido é o PERSONALIZADO = 0
        '----------------------------------------------------------------------------------------------
        If cmbIDPlano.SelectedValue = 0 Then
            dgvAReceber.Focus()
            Exit Sub
        End If
        '
        '--- Obtem o DataTable do cmbPlano
        Dim dtPlano As DataTable = cmbIDPlano.DataSource
        '
        '--- Procura pelo ROW no DataTable
        Dim r As DataRow = dtPlano.Select("IDPlano = " & cmbIDPlano.SelectedValue.ToString)(0)
        '
        '--- Determina os criterios do parcelamento
        Dim Meses As Byte = r("Meses")
        Dim Entrada As Boolean = r("Entrada")
        Dim ComJuros As Double = r("ComJuros")
        '
        '--- Limpa a lista de parcelas
        _ParcelaList.Clear()
        '
        '--- Define alguns Valores
        Dim Parcelas As Byte = Meses + IIf(Entrada = True, 1, 0)
        Dim vlParcela As Decimal = Math.Round(vlTotal / Parcelas, 2)
        '
        '--- Insere na listagem e no Grid
        For i = 0 To Parcelas + IIf(Entrada = True, -1, 0)
            If Entrada = False And i = 0 Then i += 1
            Dim _parc As New clAReceberParcela
            '
            _parc.ParcelaValor = vlParcela
            _parc.Vencimento = _Venda.TransacaoData.AddMonths(i)
            _parc.IDAReceber = _Venda.IDAReceber
            _parc.IDPessoa = _Venda.IDPessoaDestino
            _parc.SituacaoParcela = 0
            _parc.PermanenciaTaxa = Taxa / 100
            '
            If Entrada = True Then
                _parc.Letra = Chr(i + 65)
            Else
                _parc.Letra = Chr(i + 64)
            End If
            '
            _ParcelaList.Add(_parc)
        Next
        '
        '--- Atualiza a listagem
        bindParc.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvAReceber.DataSource = bindParc
        bindParc.MoveLast()
        '
        '--- Atualiza o Total do AReceber
        AtualizaTotalAReceber()
        Sit = EnumFlagEstado.Alterado
        '
        ''--- Salva a Venda no BD
        'Try
        '    '--- Ampulheta ON
        '    Cursor = Cursors.WaitCursor
        '    '
        '    _Venda.IDSituacao = 1 '--> EM ABERTO
        '    _Venda.IDPlano = cmbIDPlano.SelectedValue
        '    '
        '    Dim obj As Object = vndBLL.AtualizaVenda_Procedure_ID(_Venda)
        '    '
        '    If Not IsNumeric(obj) Then
        '        Throw New Exception(obj.ToString)
        '    End If
        '    '
        'Catch ex As Exception
        '    MessageBox.Show("Uma exceção ocorreu ao Salvar Novo Parcelamento..." & vbNewLine &
        '                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    '--- Ampulheta OFF
        '    Cursor = Cursors.Default
        'End Try
        ''
        '
    End Sub
    '
    ' ALTERA A COR DO DATAGRIDVIEW ARECEBER QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvAReceber_GotFocus(sender As Object, e As EventArgs) Handles dgvAReceber.GotFocus
        dgvAReceber.BackgroundColor = Color.LightSteelBlue
    End Sub
    Private Sub dgvAReceber_LostFocus(sender As Object, e As EventArgs) Handles dgvAReceber.LostFocus
        Dim c As Color = Color.FromArgb(224, 232, 243)
        dgvAReceber.BackgroundColor = c
    End Sub
    '
    ' DOUBLE CLICK DGV ARECEBER
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvAReceber_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAReceber.CellDoubleClick
        Parcela_Editar()
    End Sub
    '
    '============================================================================================================
#End Region
    '
#Region "FINALIZAR VENDA"
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
            If MessageBox.Show("Deseja realmente Finalizar essa Transação de Venda?", "Finalizar Venda",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
            '
            '--- INICIA A TRANSACAO NO BD
            '----------------------------------------------------------------------------------------
            Dim tranBLL As New AcessoControlBLL
            Dim dbTran As Object = tranBLL.GetNewAcessoWithTransaction
            '
            '--- SALVA O ARECEBER PARCELAS NO BD
            '----------------------------------------------------------------------------------------
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                If Salvar_Parcelas(dbTran) = False Then
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
                MessageBox.Show("Uma exceção ocorreu ao Salvar as Parcelas..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
            '--- SALVA A TRANSACAO/VENDA NO BD
            '----------------------------------------------------------------------------------------
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                '--- altera a situacao da transacao atual
                '--- Havendo pag Entrada a venda é bloqueada
                If _Venda.IDSituacao <> 3 Then _Venda.IDSituacao = 2 ' BLOQUEADA OU CONCLUÍDA
                '
                Dim obj As Object = vndBLL.AtualizaVenda_Procedure_ID(_Venda, dbTran)
                '
                If Not IsNumeric(obj) Then
                    Throw New Exception(obj.ToString)
                End If
                '
                '--- COMMIT all 
                tranBLL.CommitAcessoWithTransaction(dbTran)
                '
            Catch ex As Exception
                '
                '--- RollBack Transaction
                tranBLL.RollbackAcessoWithTransaction(dbTran)
                '
                MessageBox.Show("Uma exceção ocorreu ao Salvar a Venda..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
            '--- ALTERA A SITUACAO DO REGISTRO ATUAL
            '----------------------------------------------------------------------------------------
            If _Venda.IDSituacao = 2 Then
                Sit = EnumFlagEstado.RegistroSalvo
            ElseIf _Venda.IDSituacao = 3 Then '--> bloqueia caso a venda tenha pag.Entrada
                Sit = EnumFlagEstado.RegistroBloqueado
            End If
            '
        End If
        '
        '--- PERGUNTA O QUE O USUARIO DESEJA FAZER
        '----------------------------------------------------------------------------------------
        Dim fAcao As New frmAcaoDialog(Me, "Venda")
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
    Private Function Verificar() As Boolean
        '--- Verifica se a Data não está BLOQUEADA pelo sistema?
        '
        '----------------------------------------------------------------------------------------------
        ' VERIFICA OS VALORES DA VENDA, DAS PARCELAS E DO FRETE
        '----------------------------------------------------------------------------------------------
        '
        '--- Verifica o valor da venda
        If AtualizaTotalGeral() = 0 Then
            MessageBox.Show("Não é possível finalizar uma venda cujo valor final é igual a Zero..." & vbNewLine &
                            "Favor incluir alguns produtos nessa venda.",
                            "Venda Nula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab1
            dgvItens.Focus()
            Return False
        End If
        '
        '--- Verifica se o valor da venda é igual à soma das parcelas
        If Math.Abs(AtualizaTotalGeral() - AtualizaTotalAReceber()) > 1 Then
            MessageBox.Show("A soma das parcelas é diferente da soma dos produtos" & vbNewLine &
                            "Favor corrigir esse erro alterando o parcelamento.",
                            "Parcelamento com Diferença", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            dgvAReceber.Focus()
            Return False
        End If
        '
        '
        '----------------------------------------------------------------------------------------------
        ' VERIFICA OS CAMPOS NECESSÁRIOS DA VENDA
        '----------------------------------------------------------------------------------------------
        '
        '--- Verifica se há TIPO DE VENDA
        If IsNothing(_Venda.IDVendaTipo) Then
            MessageBox.Show("O campo TIPO DE VENDA não pode ficar vazio...", "Campo Necessário",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            cmbVendaTipo.Focus()
            Return False
        End If
        '
        '--- Verifica se há FORMA DE COBRANCA
        If IsNothing(_Venda.IDCobrancaForma) Then
            MessageBox.Show("O campo FORMA DE COBRANÇA não pode ficar vazio...", "Campo Necessário",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            cmbIDCobrancaForma.Focus()
            Return False
        End If
        '
        '--- Verifica se há PLANO DE PAGAMENTO
        If IsNothing(_Venda.IDPlano) OrElse _Venda.IDPlano = 0 Then
            MessageBox.Show("O campo PLANO DE PAGAMENTO não pode ficar vazio...", "Campo Necessário",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            cmbIDPlano.Focus()
            Return False
        End If
        '
        '--- Verifica se há TIPO DE FRETE
        If IsNothing(_Venda.FreteTipo) Then
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
    '--- LIMPA E SALVA TODO PARCELAMENTO
    Private Function Salvar_Parcelas(dbTran As Object) As Boolean
        '
        If _ParcelaList.Count = 0 Then Return False
        '
        Dim parcBLL As New ParcelaBLL
        '
        Try
            '--- Exclui todos os registros de Parcela da Venda atual
            parcBLL.Excluir_Parcelas_AReceber(_Venda.IDAReceber, dbTran)
            '
            '--- Insere cada um AReceber no BD
            For Each parc As clAReceberParcela In _ParcelaList
                parc.IDAReceberParcela = parcBLL.InserirNova_Parcela(parc, dbTran).IDAReceberParcela
            Next
            '
            '--- RECEBE/QUITA A PARCELA QUE ESTA VENCIDA (ENTRADA OU A VISTA)
            If Not QuitaRecebeEntrada(dbTran) Then Return False
            '
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao SALVAR as Parcelas..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
    End Function
    '
    '--- RECEBE E QUITA A PARCELA DA ENTRADA
    Private Function QuitaRecebeEntrada(dbTran As Object) As Boolean
        '
        Dim dtPlano As DataTable = cmbIDPlano.DataSource
        '
        If Not IsNothing(dtPlano) AndAlso dtPlano.Rows.Count > 0 Then '--> verifica o plano de pagamento
            '
            Dim plano As DataRow = dtPlano.Select("IDPlano = " & _Venda.IDPlano)(0)
            '
            '--- verifica se existe entrada no plano escolhido
            If plano("Entrada") = True Then
                '
                '--- get e verifica se a primeira parcela de entrada já está quitada
                Dim firstParc As clAReceberParcela = _ParcelaList.OrderBy(Function(x) x.Vencimento).First()
                '
                If firstParc.SituacaoParcela = 1 Then 'já esta pago
                    Return True
                End If
                '
                '--- Entrada na movimentacao de Conta (LOOP)
                '---------------------------------------------------------------------------------------
                Try
                    '--- Ampulheta ON
                    Cursor = Cursors.WaitCursor
                    '
                    '--- Inicia o valor Recebido
                    Dim valorRecebido As Double = 0
                    '
                    Do While valorRecebido < firstParc.ParcelaValor
                        '
                        '--- open frmAReceberQuitar
                        Dim frmRec As New frmAReceberQuitar(Me,
                                                            firstParc.ParcelaValor - valorRecebido,
                                                            firstParc.IDAReceberParcela,
                                                            0, _Venda.TransacaoData,
                                                            dbTran)
                        frmRec.ShowDialog()
                        '
                        If frmRec.DialogResult <> DialogResult.OK Then
                            Return False
                            Exit Do
                        End If
                        '
                        '--- retorna e altera o valor que foi recebido
                        valorRecebido += frmRec.prop_vlPagoDoValor
                        '
                    Loop
                    '
                Catch ex As Exception
                    Throw ex
                    Return False
                Finally
                    '--- Ampulheta OFF
                    Cursor = Cursors.Default
                End Try
                '
                '--- quita a parcela
                '---------------------------------------------------------------------------------------
                Dim parcBLL As New ParcelaBLL
                '
                Try
                    '--- Ampulheta ON
                    Cursor = Cursors.WaitCursor
                    '
                    parcBLL.Quitar_Parcela(firstParc.IDAReceberParcela,
                                           firstParc.ParcelaValor, 0,
                                           firstParc.Vencimento,
                                           dbTran)
                    '
                    firstParc.SituacaoParcela = 1 '---> parcela paga
                    '
                Catch ex As Exception
                    Throw ex
                    Return False
                Finally
                    '--- Ampulheta OFF
                    Cursor = Cursors.Default
                End Try
                '
                '--- bloqueia a venda
                _Venda.IDSituacao = 3 '--> Venda Bloqueada
                '
            End If
            '
        End If
        '
        Return True
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
        Dim T As Double = 0
        '
        T = AtualizaTotalProdutos() + _Venda.ValorFrete + _Venda.ValorImpostos + _Venda.ValorAcrescimos - _Venda.ValorDevolucao
        '
        lblTotalGeral.DataBindings.Item("text").ReadValue()
        lblValorProdutos.DataBindings.Item("text").ReadValue()
        '
        Return If(T < 0, 0, T)
        '
    End Function
    '
    ' ATUALIZA O TOTAL DOS PRODUTOS VENDIDOS
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalProdutos() As Double
        '
        Dim T As Double = _ItensList.Sum(Function(x) x.Total)
        '
        _Venda.ValorProdutos = T
        Return T
        '
    End Function
    '
    ' ATUALIZA O TOTAL DO ARECEBER
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalAReceber() As Double
        '
        Dim T As Double = _ParcelaList.Sum(Function(x) x.ParcelaValor)
        '
        lblTotalCobrado.Text = Format(T, "c")
        Return T
        '
    End Function
    '
    ' RECALCULA VALORES QUANDO ALTERA CONTROLES VALOR
    '-----------------------------------------------------------------------------------------------------
    Private Sub ValorText_Validated(sender As Object, e As EventArgs) Handles txtValorFrete.Validated,
            txtValorAcrescimos.Validated, txtValorImpostos.Validated
        '
        AtualizaTotalGeral()
        '
    End Sub
    '
#End Region '/FUNCOES NECESSARIAS
    '
#Region "BLOQUEIO DE REGISTROS"
    '
    ' PROIBE EDICAO NOS COMBOBOX QUANDO VENDA BLOQUEADA
    '-----------------------------------------------------------------------------------------------------
    Private Sub ComboBox_SelectedValueChanged(sender As Object, e As EventArgs) _
        Handles cmbVendaTipo.SelectedValueChanged,
                cmbIDCobrancaForma.SelectedValueChanged,
                cmbFreteTipo.SelectedValueChanged,
                cmbIDTransportadora.SelectedValueChanged
        '
        If Sit = EnumFlagEstado.RegistroBloqueado AndAlso VerificaAlteracao = True Then
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            '
            Select Case cmb.Name
                Case "cmbVendaTipo"
                    VerificaAlteracao = False
                    cmbVendaTipo.SelectedValue = _Venda.IDVendaTipo
                    VerificaAlteracao = True
                Case "cmbIDCobrancaForma"
                    VerificaAlteracao = False
                    cmbIDCobrancaForma.SelectedValue = IIf(IsNothing(_Venda.IDCobrancaForma), -1, _Venda.IDCobrancaForma)
                    VerificaAlteracao = True
                Case "cmbFreteTipo"
                    VerificaAlteracao = False
                    cmbFreteTipo.SelectedValue = IIf(IsNothing(_Venda.FreteTipo), -1, _Venda.FreteTipo)
                    VerificaAlteracao = True
                Case "cmbIDTransportadora"
                    VerificaAlteracao = False
                    cmbIDTransportadora.SelectedValue = IIf(IsNothing(_Venda.IDTransportadora), -1, _Venda.IDTransportadora)
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
            MessageBox.Show("Esse registro de Venda está BLOQUEADO para alterações..." &
                            vbNewLine & vbNewLine &
                            "Não é possível adicionar produtos, excluir ou alterar algum dado!",
                            "Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RegistroBloqueado = True
        Else
            RegistroBloqueado = False
        End If
        '
    End Function
    '
    ' FUNCAO QUE CONFERE REGISTRO FINALIZADO E PERGUNTA SE DESEJA ALTERAR
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroFinalizado() As Boolean
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            If MessageBox.Show("Esse registro de Venda já se encontra FINALIZADO..." & vbNewLine &
                               "Deseja realmente fazer alterações nesse registro?",
                               "Registro Finalizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                '--- Edita o registro e altera a situação
                _Venda.IDSituacao = 1
                '
                '--- SALVA A TRANSACAO/VENDA NO BD
                Try
                    Dim obj As Object = vndBLL.AtualizaVenda_Procedure_ID(_Venda)
                    '
                    If Not IsNumeric(obj) Then
                        Throw New Exception(obj.ToString)
                    End If
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                '
                RegistroFinalizado = False
            Else
                RegistroFinalizado = True
            End If
        Else
            RegistroFinalizado = False
        End If
        '
    End Function
    '
    Private Function CanCloseMessage() As Boolean
        '
        If MessageBox.Show("ALTERAÇÕES DA VENDA NÃO SERÃO SALVAS!" & vbNewLine & vbNewLine &
                           "Se você fechar agora essa Venda," & vbNewLine &
                           "algumas alterações podem ser perdidas," & vbNewLine &
                           "inclusive as alterações no Parcelamento..." & vbNewLine & vbNewLine &
                           "Deseja FECHAR a venda assim mesmo?", "Venda não Finalizada",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
            '
            '--- Seleciona a TAB
            tabPrincipal.SelectedTab = vtab2
            '
            '--- Select Control txtValorFrete
            txtValorFrete.Focus()
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
#End Region
    '
#Region "TROCA"
    '
    '--- INSERE DEVOLUCAO DE TROCA E ABRE O FORMULARIO DE TROCA
    Private Sub btnTroca_Click(sender As Object, e As EventArgs) Handles btnTroca.Click
        '
        If IsNothing(_Troca) Then
            '--- Pergunta ao Usuário se Deseja inserir nova TROCA
            If MessageBox.Show("Você deseja realmente anexar uma Troca Simples nessa venda?",
                               "Inserir Troca", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Return
            '
        End If
        '
        '--- Verifica ou Cria uma nova TROCA
        Try
            If IsNothing(_Troca) Then '--- se a TROCA for nothing entao CRIA nova TROCA
                Dim tBLL As New TrocaBLL
                '
                _Troca = tBLL.TrocaSimples_Nova(_Venda.IDVenda,
                                                _Venda.TransacaoData,
                                                _Venda.IDPessoaOrigem,
                                                _Venda.ApelidoFilial,
                                                _Venda.IDPessoaDestino,
                                                _Venda.Cadastro,
                                                _Venda.IDUser)
                '
            End If
            '
            '--- abre o frmTROCA
            Dim old_vlTroca = If(IsNothing(_Troca), 0, _Troca.ValorTotal)
            Dim fTroca As New frmTrocaSimples(_Troca, _Venda, Me)
            fTroca.ShowDialog()
            '
            '--- verifica se houve alteracao da troca pelo valor
            VerificaTroca()
            '
            '--- se houve alteracao
            If old_vlTroca <> If(IsNothing(_Troca), 0, _Troca.ValorTotal) Then
                AtualizaTotalGeral()
                Sit = EnumFlagEstado.Alterado
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Verificar ou Inserir Troca..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- VERIFICA SE EXISTE TROCA E ALTERA O BTNTROCA
    Private Sub VerificaTroca()
        '
        Dim tBLL As New TrocaBLL
        Dim vBLL As New VendaBLL
        '
        Try
            _Troca = tBLL.GetTroca_PorIDVenda_clTroca(_Venda.IDVenda)
            '
            If Not IsNothing(_Troca) Then
                '--- atualializa a propriedade VALORDEVOLUCAO da Venda
                If _Venda.ValorDevolucao <> _Troca.ValorTotal Then _Venda.ValorDevolucao = _Troca.ValorTotal
                '
                '--- Se houver Troca atualiza o marca o AgregaTroca
                If Not _Venda.AgregaDevolucao Then _Venda.AgregaDevolucao = True
                '
                '--- Verifica se o IDSitucao da Troca é igual ao da Venda
                If _Venda.IDSituacao <> _Troca.IDSituacao Then
                    '
                    '--- iguala o IDSituacao
                    _Troca.IDSituacao = _Venda.IDSituacao
                    '
                    Try '--- atualiza a Troca
                        tBLL.AtualizaTroca_Procedure_ID(_Troca)
                    Catch ex As Exception
                        MessageBox.Show("Uma exceção ocorreu ao Atualizar a Situacao da Troca..." & vbNewLine &
                                        ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    '
                End If
                '
            Else
                '--- atualializa a propriedade VALORDEVOLUCAO da Venda
                _Venda.ValorDevolucao = 0
                '
                '--- Se nao houver Troca desmarca o AgregaTroca
                If _Venda.AgregaDevolucao Then _Venda.AgregaDevolucao = False
                '
            End If
            '
            Troca_EditaLabel()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao verificar se existe TROCA anexada à Venda..." & vbNewLine &
                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '
    '--- VERIFICA E ADICIONA OU ALTERA A TROCA NA LISTA DE ENTRADA
    Private Sub Troca_EditaLabel()
        '
        If Not IsNothing(_Troca) Then
            '
            '-- atualiza o btnTroca e o lblTroca
            btnTroca.Text = "Altera &Troca"
            lblTroca.Visible = True
            lblTroca.Text = "Devolução de " & vbNewLine & Format(_Troca.ValorTotal, "C")
            '
            '-- atualiza o lbltitulo
            lblTitulo.Text = "Venda Prazo com Troca"
            lblTitulo.Update()
            '
        Else
            '
            '-- atualiza o btnTroca e o lblTroca
            btnTroca.Text = "Insere &Troca"
            lblTroca.Visible = False
            lblTroca.Text = ""
            '
            '-- atualiza o lbltitulo
            lblTitulo.Text = "Venda Prazo"
            '
        End If
        '
    End Sub
    '
#End Region '/ TROCA
    '
End Class
