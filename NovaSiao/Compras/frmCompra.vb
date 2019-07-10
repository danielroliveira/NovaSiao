Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmCompra
    '--- CLASSE
    Private _Compra As clCompra
    Private cBLL As New CompraBLL
    Private _IDFilial As Integer
    '--- LISTS
    Private _ItensList As New List(Of clTransacaoItem)
    Private _APagarList As New List(Of clAPagar)
    Private _NotasList As New List(Of clNotaFiscal)
    '--- BINDINGS
    Private bindCompra As New BindingSource
    Private bindItem As New BindingSource
    Private bindAPagar As New BindingSource
    Private bindNota As New BindingSource
    '--- CONTROLES
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private VerificaAlteracao As Boolean
    '--- TOTAIS
    Private _TotalGeral As Decimal
    Private _TotalProdutos As Decimal
    '
#Region "LOAD"
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            Select Case _Sit
                Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
                    lblSituacao.Text = "Finalizada"
                    btnFinalizar.Text = "&Fechar"
                    '
                    btnData.Enabled = True
                    txtFreteValor.ReadOnly = False
                    txtObservacao.ReadOnly = False
                    txtVolumes.ReadOnly = False
                    '
                    txtFreteCobrado.ReadOnly = False
                    txtICMSValor.ReadOnly = False
                    txtDespesas.ReadOnly = False
                    txtDescontos.ReadOnly = False
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
                    txtFreteCobrado.ReadOnly = False
                    txtICMSValor.ReadOnly = False
                    txtDespesas.ReadOnly = False
                    txtDescontos.ReadOnly = False
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
                    txtFreteCobrado.ReadOnly = False
                    txtICMSValor.ReadOnly = False
                    txtDespesas.ReadOnly = False
                    txtDescontos.ReadOnly = False
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
                    txtFreteCobrado.ReadOnly = True
                    txtICMSValor.ReadOnly = True
                    txtDespesas.ReadOnly = True
                    txtDescontos.ReadOnly = True
                    '
            End Select
        End Set
    End Property
    '
    Property propCompra As clCompra
        Get
            Return _Compra
        End Get
        Set(value As clCompra)
            'VerificaAlteracao = False '--- Inibe a verificacao dos campos IDPlano
            _Compra = value
            _IDFilial = _Compra.IDPessoaDestino
            obterItens()
            obterAPagar()
            obterNotas()
            bindItem.DataSource = _ItensList
            bindAPagar.DataSource = _APagarList
            bindNota.DataSource = _NotasList
            dgvItens.DataSource = bindItem
            '
            If IsNothing(bindCompra.DataSource) Then
                bindCompra.DataSource = _Compra
                PreencheDataBinding()
            Else
                bindCompra.Clear()
                bindCompra.DataSource = _Compra
                bindCompra.ResetBindings(True)
                'AddHandler _ClientePF.AoAlterar, AddressOf HandlerAoAlterar
            End If
            '
            '--- Preenche os Itens da Compra
            PreencheItens()
            '
            '--- Preenche Itens do A Pagar (parcelas)
            Preenche_APagar()
            cmbFreteTipo.SelectedValue = _Compra.FreteTipo
            cmbIDTransportadora.SelectedValue = If(_Compra.IDTransportadora, -1)
            cmbNotaTipo.SelectedValue = -1
            '
            '--- Preenche Notas Fiscais
            Preenche_Notas()
            '
            '--- Atualiza o estado da Situacao: EnumFlagEstado
            Select Case _Compra.IDSituacao
                Case 1 ' COMPRA INICIADA
                    Sit = EnumFlagEstado.NovoRegistro
                Case 2 ' COMPRA FINALIZADA
                    Sit = EnumFlagEstado.RegistroSalvo
                Case 3 ' COMPRA BLOQUEADA
                    Sit = EnumFlagEstado.RegistroBloqueado
                Case Else
            End Select
            '
            '--- Habilita ou Desabilita os campos do Frete da Compra
            Controla_cmbFrete()
            '
            '--- Permite a verificacao dos campos IDPlano
            VerificaAlteracao = True
            '
        End Set
    End Property
    '
    Public ReadOnly Property TotalGeral() As Decimal
        Get
            '--- Declara variaveis do Total de produto e de adicionais da Compra
            Dim TAdic As Double = 0
            '
            TAdic = IIf(IsNothing(_Compra.FreteCobrado), 0, _Compra.FreteCobrado)
            TAdic = TAdic + IIf(IsNothing(_Compra.ICMSValor), 0, _Compra.ICMSValor)
            TAdic = TAdic + IIf(IsNothing(_Compra.Despesas), 0, _Compra.Despesas)
            TAdic = TAdic - IIf(IsNothing(_Compra.Descontos), 0, _Compra.Descontos)
            '
            '--- verifica se o valor Total de Adicionais é menor que zero
            If TAdic < 0 Then TAdic = 0
            '
            _TotalGeral = TotalProdutos + TAdic
            '
            '--- atualiza o label
            lblTotalGeral.Text = Format(_TotalGeral, "c")
            '
            '--- retorna
            Return _TotalGeral
            '
        End Get
    End Property
    '
    Public ReadOnly Property TotalProdutos() As Decimal
        Get
            Dim TProd As Decimal = _ItensList.Sum(Function(x) x.Total)
            _TotalProdutos = TProd
            '--- atualiza o label
            lblTotalProdutos.Text = Format(TProd, "c")
            '
            '--- retorna
            Return _TotalProdutos
            '
        End Get
    End Property
    '
    Public Sub New(myCompra As clCompra)
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propCompra = myCompra
        '
        '--- hANDLER Menu Acao
        MenuOpen_AdHandler()
        '
    End Sub
    '
#End Region
    '
#Region "DATABINDING"
    '
    Private Sub PreencheDataBinding()
        '
        txtFreteCobrado.DataBindings.Add("Text", bindCompra, "FreteCobrado", True, DataSourceUpdateMode.OnPropertyChanged)
        txtICMSValor.DataBindings.Add("Text", bindCompra, "ICMSValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesas.DataBindings.Add("Text", bindCompra, "Despesas", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescontos.DataBindings.Add("Text", bindCompra, "Descontos", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFornecedor.DataBindings.Add("Text", bindCompra, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblIDCompra.DataBindings.Add("Text", bindCompra, "IDCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindCompra, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCompraData.DataBindings.Add("Text", bindCompra, "TransacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtVolumes.DataBindings.Add("Text", bindCompra, "Volumes", True, DataSourceUpdateMode.OnPropertyChanged)
        txtFreteValor.DataBindings.Add("Text", bindCompra, "FreteValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindCompra, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCobrancaTipo.DataBindings.Add("Text", bindCompra, "CobrancaTipoTexto", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        'dgvItens.DataBindings.Add("Tag", bindItem, "IDProduto", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDCompra.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler txtFreteValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtDescontos.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtDespesas.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtFreteCobrado.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtICMSValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtVolumes.DataBindings("text").Format, AddressOf Format00
        AddHandler lblCompraData.DataBindings("text").Format, AddressOf FormatDT
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbFreteTipo()
        CarregaCmbTransportadora()
        CarregaCmbNotaTipo()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Compra.AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Compra.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
            .DataBindings.Add("SelectedValue", bindCompra, "FreteTipo", True, DataSourceUpdateMode.OnPropertyChanged)
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
                .DataBindings.Add("SelectedValue", bindCompra, "IDTransportadora", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu obter lista de Transportadoras" & vbNewLine &
            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub CarregaCmbNotaTipo()
        '
        Dim dtNTipo As New DataTable
        '
        With dtNTipo
            '--- Adiciona as Colunas
            .Columns.Add("idNTipo")
            .Columns.Add("NTipo")
            '--- Adiciona todas as possibilidades de Frete
            .Rows.Add(New Object() {1, "NF-e"})
            .Rows.Add(New Object() {2, "Cupom Fiscal"})
            .Rows.Add(New Object() {3, "Outros Tipos"})
        End With
        '
        With cmbNotaTipo
            .DataSource = dtNTipo
            .ValueMember = "idNTipo"
            .DisplayMember = "NTipo"
        End With
        '
    End Sub
    '
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
            .Width = 60
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
            .Width = 375
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
            .Width = 60
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
            .Width = 90
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
            .Width = 90
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
        dgvItens.Columns.Add("clnDesconto", "Desc.%")
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
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (9) COLUNA ICMS
        dgvItens.Columns.Add("clnICMS", "ICMS%")
        With dgvItens.Columns("clnICMS")
            .DataPropertyName = "ICMS"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (10) COLUNA ST
        dgvItens.Columns.Add("clnSubstituicao", "ST")
        With dgvItens.Columns("clnSubstituicao")
            .DataPropertyName = "Substituicao"
            .Width = 75
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (11) COLUNA MVA
        dgvItens.Columns.Add("clnMVA", "MVA%")
        With dgvItens.Columns("clnMVA")
            .DataPropertyName = "MVA"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (12) COLUNA IPI
        dgvItens.Columns.Add("clnIPI", "IPI%")
        With dgvItens.Columns("clnIPI")
            .DataPropertyName = "IPI"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub
    '
    '--- RETORNA TODOS OS ITENS DA COMPRA
    Private Sub obterItens()
        '
        Dim tBLL As New TransacaoItemBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _ItensList = tBLL.GetTransacaoItens_WithCustos_List(_Compra.IDCompra, _IDFilial)
            '--- Atualiza o label TOTAL
            Dim x = TotalGeral
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter Itens da Compra:..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- INSERIR NOVO ITEM NA LISTA DE PRODUTOS
    '----------------------------------------------------------------------------------------------------
    Private Sub Inserir_Item()
        '
        '--- Verifica se esta Bloqueado ou Finalizado
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        '
        '--- Abre o frmItem
        Dim newItem As New clTransacaoItem
        '
        Dim fItem As New frmCompraItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _IDFilial, newItem)
        fItem.ShowDialog()
        '
        '--- Verifica a resposa do Dialog
        If Not fItem.DialogResult = DialogResult.OK Then Exit Sub
        '
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
        '--- Insere o novo ITEM no BD
        Try
            newItem.IDTransacao = _Compra.IDCompra
            myID = ItemBLL.InserirNovoItem(newItem,
                                           TransacaoItemBLL.EnumMovimento.ENTRADA,
                                           _Compra.TransacaoData,
                                           InsereCustos:=True
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
        '--- Atualiza o DataGrid
        dgvItens.DataSource = bindItem
        bindItem.MoveLast()
        '
        '--- Atualiza o label TOTAL
        Dim a = TotalGeral
        '
    End Sub
    '
    '--- EDITAR ITEM DA LISTA DE PRODUTOS
    '----------------------------------------------------------------------------------------------------
    Private Sub Editar_Item()
        '
        '--- Verifica se existe algum item selecionado
        If dgvItens.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- Verifica se esta Bloqueado ou Finalizado
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        '
        '--- Abre o frmItem
        Dim itmAtual As clTransacaoItem
        itmAtual = dgvItens.SelectedRows(0).DataBoundItem
        '
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim fitem As New frmCompraItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _IDFilial, itmAtual)
            '
            fitem.ShowDialog()
            '
            '--- Verifica a resposa do Dialog
            If Not fitem.DialogResult = DialogResult.OK Then Exit Sub
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir Form de Item..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
        'Dim i As Integer = _ItensList.FindIndex(Function(x) x.IDTransacaoItem = Item.IDTransacaoItem)
        '
        '--- Altera o ITEM no BD e reforma o ESTOQUE
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            itmAtual.IDTransacao = _Compra.IDCompra
            myID = ItemBLL.EditarItem(itmAtual,
                                      TransacaoItemBLL.EnumMovimento.ENTRADA,
                                      _Compra.TransacaoData,
                                      InsereCustos:=True)
            '
            itmAtual.IDTransacaoItem = myID
            '
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao ALTERAR o item no BD..." & vbNewLine & ex.Message,
                            "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- Atualiza o ITEM da lista
        '_ItensList.Item(i) = Item
        bindItem.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvItens.DataSource = bindItem
        'bindItem.CurrencyManager.Position = i
        '
        '--- Atualiza o label TOTAL
        Dim a = TotalGeral
        '
    End Sub
    '
    '--- EXCLUIR ITEM DA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------------
    Private Sub Excluir_Item()
        '
        '--- Verifica se existe algum item selecionado
        If dgvItens.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- Verifica se esta Bloqueado ou Finalizado
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        '
        '--- seleciona o item
        Dim itmAtual As clTransacaoItem
        itmAtual = dgvItens.SelectedRows(0).DataBoundItem
        '
        '--- pergunta ao usuário se deseja excluir o item
        If MessageBox.Show("Deseja realmente REMOVER esse item da Compra?" & vbNewLine & vbNewLine &
                           itmAtual.Produto.ToUpper, "Excluir Item",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '--- Exclui o ITEM
        '------------------------------------------
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
        Dim i As Integer = _ItensList.FindIndex(Function(x) x.IDTransacaoItem = itmAtual.IDTransacaoItem)
        '
        '--- Altera o ITEM no BD e reforma o ESTOQUE
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            myID = ItemBLL.ExcluirItem(itmAtual, TransacaoItemBLL.EnumMovimento.ENTRADA)
            '
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao EXCLUIR o item no BD..." & vbNewLine & ex.Message,
                            "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- Atualiza o ITEM da lista
        _ItensList.RemoveAt(i)
        bindItem.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvItens.DataSource = bindItem
        '
        '--- Atualiza o label TOTAL
        Dim a = TotalGeral
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
    End Sub
    '
    Private Sub dgvItens_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        Editar_Item()
    End Sub
    '
#End Region
    '
#Region "BOTOES DE ACAO"
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        '
        '--- ASK USER
        If Not CanCloseMessage() Then Exit Sub
        '
        '--- CLOSE
        Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
    '--- ALTERAR A DATA DA COMPRA
    Private Sub lblCompraData_DoubleClick(sender As Object, e As EventArgs) _
        Handles lblCompraData.DoubleClick, btnData.Click
        '
        Dim frmDt As New frmDataInformar("Informe a data da Compra", EnumDataTipo.PassadoPresente, _Compra.TransacaoData, Me)
        frmDt.ShowDialog()
        '
        If frmDt.DialogResult <> DialogResult.OK Then Exit Sub
        '
        Dim newDt As Date = frmDt.propDataInfo
        '
        '--- verifica a data bloqueada
        If DataBloqueada(newDt, Obter_ContaPadrao) Then Exit Sub
        '
        '--- altera a data da TRANSACAO e salva no BD
        Try
            '
            Dim tranBLL As New TransacaoBLL
            If tranBLL.AtualizaTransacaoData(_Compra.IDCompra, newDt) Then
                '
                _Compra.TransacaoData = frmDt.propDataInfo
                lblCompraData.DataBindings("Text").ReadValue()
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao alterar a Data da Compra..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub btnTransportadoraAdd_Click(sender As Object, e As EventArgs) Handles btnTransportadoraAdd.Click
        '
        Dim fTransp As New frmTransportadora(New clTransportadora, Me)
        '
        Visible = False
        fTransp.ShowDialog()
        Visible = True
        cmbIDTransportadora.Focus()

        If fTransp.DialogResult = DialogResult.OK Then
            '
            '--- get new transportadora
            Dim newTransp As clTransportadora = fTransp.propTransp
            '
            '--- insert new transportadora in combo
            Dim dtTransp As DataTable = cmbIDTransportadora.DataSource

            Dim row As DataRow = dtTransp.NewRow()
            row("IDTransportadora") = newTransp.IDPessoa
            row("Cadastro") = newTransp.Cadastro
            dtTransp.Rows.Add(row)
            '
            '--- select new transportadora inserted
            cmbIDTransportadora.SelectedValue = newTransp.IDPessoa
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "FORMATACAO E FLUXO"
    ' CRIA TECLA DE ATALHO PARA O TAB
    '---------------------------------------------------------------------------------------------------
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
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
        '
    End Sub
    '
    Private Sub tabPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPrincipal.SelectedIndexChanged
        '
        If tabPrincipal.SelectedIndex = 0 Then
            dgvItens.Focus()
        ElseIf tabPrincipal.SelectedIndex = 1 Then
            txtFreteCobrado.Focus()
        ElseIf tabPrincipal.SelectedIndex = 2 Then
            dgvVendaNotas.Focus()
        End If
        '
    End Sub
    '
    ' HABILITA OU DESABILITA OS CONTROLES DO FRETE
    '---------------------------------------------------------------------------------------------------
    Private Sub cmbFreteTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFreteTipo.SelectedIndexChanged
        Controla_cmbFrete()
    End Sub
    '
    Public Sub Controla_cmbFrete()
        '
        If Not IsNumeric(cmbFreteTipo.SelectedValue) Then Exit Sub
        '
        If _Compra.FreteTipo = 0 Then
            '--- Nulifica os valores das propriedades do Frete
            _Compra.IDTransportadora = Nothing
            _Compra.FreteValor = Nothing
            _Compra.Volumes = Nothing
            '--- Atualiza os novos valores dos controles
            If cmbIDTransportadora.DataBindings.Count > 0 Then
                cmbIDTransportadora.DataBindings.Item("SelectedValue").ReadValue()
                cmbIDTransportadora.Text = String.Empty
                txtFreteValor.DataBindings.Item("Text").ReadValue()
                txtVolumes.DataBindings.Item("Text").ReadValue()
            End If
            '--- Desabilita os controles
            cmbIDTransportadora.Enabled = False
            btnTransportadoraAdd.Enabled = False
            txtFreteValor.Enabled = False
            txtVolumes.Enabled = False
        Else
            cmbIDTransportadora.Enabled = True
            btnTransportadoraAdd.Enabled = True
            txtFreteValor.Enabled = True
            txtVolumes.Enabled = True
        End If
        '
    End Sub
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFreteCobrado.KeyDown, txtICMSValor.KeyDown,
            txtDespesas.KeyDown, txtDescontos.KeyDown, txtFreteValor.KeyDown,
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
    '--- CALCULA VALOR TOTAL QUANDO ALTERA OS VALORES ADICIONAIS DA NOTA
    Private Sub txtControl_Validated(sender As Object, e As EventArgs) Handles txtFreteCobrado.Validated,
            txtICMSValor.Validated, txtDescontos.Validated, txtDespesas.Validated
        '
        Dim x = TotalGeral
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLE DO A PAGAR"
    '============================================================================================================
    ' A RECEBER CONTROLES
    '============================================================================================================
    '
    '--- RETORNA TODOS AS PARCELAS DE A RECEBER
    Private Sub obterAPagar()
        Dim pBLL As New APagarBLL
        Try
            _APagarList = pBLL.APagar_GET_PorOrigem(_Compra.IDCompra, clAPagar.Origem_APagar.Compra)
            '--- Atualiza o label TOTAL
            AtualizaTotalAPagar()
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter o A Pagar da Compra:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- Preenche o DataGrid AReceber
    Private Sub Preenche_APagar()
        With dgvAPagar
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
            .DataSource = bindAPagar
            If .Rows.Count > 0 Then .CurrentCell = .Rows(.Rows.Count).Cells(1)
        End With
        '
        '--- formata as colunas do datagrid
        FormataGrid_APagar()
        '
    End Sub
    '
    Private Sub FormataGrid_APagar()
        '
        Dim cellStyleCur As New DataGridViewCellStyle
        cellStyleCur.Format = "c"
        cellStyleCur.NullValue = Nothing
        cellStyleCur.Alignment = DataGridViewContentAlignment.MiddleRight
        '
        ' (1) COLUNA IDAPagar
        dgvAPagar.Columns.Add("clnID", "ID")
        With dgvAPagar.Columns("clnID")
            .DataPropertyName = "IDAPagar"
            .Width = 0
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA FORMA
        dgvAPagar.Columns.Add("clnCobrancaForma", "Forma de Cobrança")
        With dgvAPagar.Columns("clnCobrancaForma")
            .DataPropertyName = "CobrancaForma"
            .Width = 160
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (3) COLUNA IDENTIFICADOR
        dgvAPagar.Columns.Add("clnIdentificador", "No. Reg.")
        With dgvAPagar.Columns("clnIdentificador")
            .DefaultCellStyle = cellStyleCur
            .DataPropertyName = "Identificador"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA VENCIMENTO
        dgvAPagar.Columns.Add("clnVencimento", "Vencimento")
        With dgvAPagar.Columns("clnVencimento")
            .HeaderText = "Vencimento"
            .DataPropertyName = "Vencimento"
            .Width = 110
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (5) COLUNA VALOR
        dgvAPagar.Columns.Add("clnAPagarValor", "Valor")
        With dgvAPagar.Columns("clnAPagarValor")
            .DefaultCellStyle = cellStyleCur
            .DataPropertyName = "APagarValor"
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
    Private Sub dgvAReceber_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAPagar.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            '
            If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
            '
            APagar_Adicionar()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            '
            If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
            '
            APagar_Editar()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            '
            If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
            '
            APagar_Excluir()
        End If
    End Sub
    '
    Private Sub APagar_Adicionar()
        '--- Atualiza o Valor do Total Geral
        Dim vl As Double = TotalGeral
        Dim vlPag As Double = AtualizaTotalAPagar()
        '
        '--- Verifica se o valor dos itens é maior que zero
        If CDbl(lblTotalProdutos.Text) = 0 Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Pagar" & vbNewLine &
                            "Quando o valor da Compra ainda é igual a Zero..." & vbNewLine &
                            "Adicione produtos primeiro e depois tente novamente.", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- Verifica se o somatorio de APAGAR ainda é menor que o ValorTotalGeral
        If Math.Abs(vl - vlPag) < 0.1 Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Pagar" & vbNewLine &
                            "pois o valor cobrado já é igual ao valor do Total Geral" & vbNewLine &
                            "Você pode Alterar ou Excluir parcelas.", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- posiciona o form
        Dim pos As Point = dgvAPagar.PointToScreen(Point.Empty)
        pos = New Point(pos.X - 10, pos.Y)
        '
        '--- cria novo APagar
        Dim clPag As New clAPagar
        '
        clPag.Origem = 1
        clPag.IDOrigem = _Compra.IDCompra
        clPag.IDPessoa = _Compra.IDPessoaOrigem
        clPag.IDFilial = _Compra.IDPessoaDestino
        clPag.APagarValor = vl - _APagarList.Sum(Function(x) x.APagarValor)
        clPag.Vencimento = _Compra.TransacaoData
        clPag.Situacao = 0
        '
        '--- verifica se houve outro APagar anterior para obter valores padrão
        Dim pagCount As Integer = _APagarList.Count
        '
        If pagCount > 0 Then
            clPag.IDCobrancaForma = _APagarList.ElementAt(pagCount - 1).IDCobrancaForma
            clPag.CobrancaForma = _APagarList.ElementAt(pagCount - 1).CobrancaForma
            clPag.RGBanco = _APagarList.ElementAt(pagCount - 1).RGBanco
            clPag.Vencimento = _APagarList.ElementAt(pagCount - 1).Vencimento.AddMonths(1)
        End If
        '
        '--- abre o form frmAPagar
        Dim fPag As New frmAPagarItem(Me, clPag.APagarValor, _Compra.TransacaoData, clPag, EnumFlagAcao.INSERIR, pos)
        fPag.ShowDialog()
        '
        If fPag.DialogResult = DialogResult.OK Then
            '--- Insere o APAGAR na lista
            _APagarList.Add(clPag)
            bindAPagar.ResetBindings(False)
            '--- Atualiza o DataGrid
            dgvAPagar.DataSource = bindAPagar
            bindAPagar.MoveLast()
            '
            '--- AtualizaTotalAPagar
            AtualizaTotalAPagar()
            '
        End If
    End Sub
    '
    Private Sub APagar_Editar()
        '
        '--- posiciona o form
        Dim pos As Point = dgvAPagar.PointToScreen(Point.Empty)
        pos = New Point(pos.X - 10, pos.Y)
        '
        '--- GET APagar do DataGrid
        If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
        '
        Dim PagAtual As clAPagar = dgvAPagar.SelectedRows(0).DataBoundItem
        Dim fPag As New frmAPagarItem(Me, TotalGeral, _Compra.TransacaoData, PagAtual, EnumFlagAcao.EDITAR, pos)
        fPag.ShowDialog()
        '
        '--- AtualizaTotalAPagar
        AtualizaTotalAPagar()
    End Sub
    '
    Private Sub APagar_Excluir()
        '--- verifica se existe alguma parcela selecionada
        If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- seleciona a parcela
        Dim i As Integer = dgvAPagar.SelectedRows(0).Index
        '
        '--- pergunta ao usuário se deseja excluir o item
        If MessageBox.Show("Deseja realmente REMOVER essa parcela A Pagar?", "Excluir Parcela",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- envia o comando para excluir a parcela no BD
        '
        '--- Atualiza o ITEM da lista
        _APagarList.RemoveAt(i)
        bindAPagar.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvAPagar.DataSource = bindAPagar
        '--- AtualizaTotalAPagar
        AtualizaTotalAPagar()
    End Sub
    '
    ' ALTERA A COR DO DATAGRIDVIEW ARECEBER QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvAPagar_GotFocus(sender As Object, e As EventArgs) Handles dgvAPagar.GotFocus, dgvVendaNotas.GotFocus
        DirectCast(sender, DataGridView).BackgroundColor = Color.LightSteelBlue
    End Sub
    '
    Private Sub dgvAPagar_LostFocus(sender As Object, e As EventArgs) Handles dgvAPagar.LostFocus, dgvVendaNotas.LostFocus
        Dim c As Color = Color.FromArgb(224, 232, 243)
        DirectCast(sender, DataGridView).BackgroundColor = c
    End Sub
    '
    Private Sub dgvAPagar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAPagar.CellDoubleClick
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        APagar_Editar()
        '
    End Sub
    '
    '============================================================================================================
#End Region
    '
#Region "FINALIZAR COMPRA"
    '
    '==========================================================================================
    ' FINALIZE COMPRA WITH VERIFIES
    '==========================================================================================
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        '
        '--- Verifica se a SITUACAO do registro permite salvar
        If Sit = EnumFlagEstado.Alterado OrElse Sit = EnumFlagEstado.NovoRegistro Then
            '
            '--- Faz as VERIFICACOES DOS CAMPOS E VALORES
            If Verificar() = False Then Exit Sub
            '
            '--- PERGUNTA AO USUÁRIO
            If MessageBox.Show("Deseja realmente Finalizar essa Transação de Compra?",
                               "Finalizar Compra", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            '
            '--- Determina se o Tipo da Cobrança é A VISTA OU PARCELADA
            If _APagarList.Count = 0 Then
                _Compra.CobrancaTipo = 0 '--- SEM COBRANÇA
            Else
                For Each pag In _APagarList
                    If pag.Vencimento <> _Compra.TransacaoData Then
                        _Compra.CobrancaTipo = 2 '--- PARCELADA
                        Exit For
                    Else
                        _Compra.CobrancaTipo = 1 '--- A VISTA
                    End If
                Next
            End If
            '
            '
            Dim TGeral As Decimal = TotalGeral
            '
            '--- SALVA O APAGAR PARCELAS NO BD
            If Salvar_APagar() = False Then
                _Compra.IDSituacao = 1
                SalvaRegistroCompra()
                Sit = EnumFlagEstado.Alterado
                Return
            End If
            '
            '--- EFETUA O RATEIO DO FRETE NOS ITENS
            EfetuarRateio()
            '
            '--- altera a situacao da transacao atual
            _Compra.IDSituacao = 2 'CONCLUÍDA
            _Compra.TotalCompra = TGeral
            '
            '--- SALVA A TRANSACAO/COMPRA NO BD
            If SalvaRegistroCompra() Then
                '
                '--- ALTERA A SITUACAO DO REGISTRO ATUAL
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
        End If
        '
        '--- PERGUNTA O QUE O USUARIO DESEJA FAZER
        Dim fAcao As New frmAcaoDialog(Me, "Compra")
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
    '==========================================================================================
    ' SAVE IN BD
    '==========================================================================================
    Private Function SalvaRegistroCompra() As Boolean
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim obj As Object = cBLL.AtualizaCompra_Procedure_ID(_Compra)
            '
            If Not IsNumeric(obj) Then
                Throw New Exception(obj.ToString)
            End If
            '
            Return True
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar o Registro da Compra..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        Return False
        '
    End Function
    '
    '==========================================================================================
    ' CHECK TO SAVE
    '==========================================================================================
    Private Function Verificar() As Boolean
        '--- Verifica se a Data não está BLOQUEADA pelo sistema
        '
        '----------------------------------------------------------------------------------------------
        ' VERIFICA OS VALORES DA COMPRA, DAS PARCELAS E DO FRETE E DAS NOTAS FISCAIS
        '----------------------------------------------------------------------------------------------
        '
        '--- Verifica se existe algum item produto na compra
        If _ItensList.Count = 0 Then
            MessageBox.Show("Não é possível finalizar uma COMPRA que não possui nenhum produto lançado..." & vbNewLine &
                "Favor incluir alguns produtos nessa venda.",
                "COMPRA Sem Produtos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab1
            dgvItens.Focus()
            Return False
        End If
        '
        '--- Verifica o valor da COMPRA
        Dim TGeral As Double = TotalGeral
        '
        If TGeral = 0 Then
            MessageBox.Show("Não é possível finalizar uma COMPRA cujo valor final é igual a Zero..." & vbNewLine &
                            "Favor incluir alguns produtos nessa venda.",
                            "COMPRA Nula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab1
            dgvItens.Focus()
            Return False
        End If
        '
        '--- Verifica se o valor da COMPRA é igual à soma das parcelas
        If Math.Abs(TGeral - AtualizaTotalAPagar()) > 1 Then
            MessageBox.Show("A soma das parcelas é diferente da soma dos produtos" & vbNewLine &
                            "Favor corrigir esse erro alterando o parcelamento.",
                            "Parcelamento com Diferença", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            dgvAPagar.Focus()
            Return False
        End If
        '
        '--- Verifica o valor do Total das Notas Fiscais
        Dim TNf As Double = AtualizaTotalNotasFiscais()
        '
        If TNf > 0 AndAlso Math.Abs(TGeral - TNf) > 1 Then
            MessageBox.Show("A soma das Notas Fiscais é diferente da Soma dos Produtos" & vbNewLine &
                "Favor corrigir os valores das Notas Fiscais.",
                "Notas Fiscais com Diferença", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab3
            dgvVendaNotas.Focus()
        End If
        '
        '----------------------------------------------------------------------------------------------
        ' VERIFICA OS CAMPOS NECESSÁRIOS DA COMPRA
        '----------------------------------------------------------------------------------------------
        '
        '--- Verifica se há FRETE COBRADO
        If IsNothing(_Compra.FreteCobrado) OrElse _Compra.FreteCobrado < 0 Then _Compra.FreteCobrado = 0
        '
        '--- Verifica se há TIPO DE FRETE
        If IsNothing(_Compra.FreteTipo) Then
            MessageBox.Show("O campo TIPO DE FRETE não pode ficar vazio...", "Campo Necessário",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            cmbFreteTipo.Focus()
            Return False
        End If
        '
        '--- Verifica se houve dupla cobrança de FRETE na compra
        If _Compra.FreteTipo = 2 And _Compra.FreteCobrado > 0 Then
            MessageBox.Show("Quando o TIPO de FRETE é DESTINÁRIO, o valor do FRETE deve ser inserido no campo: VALOR DO FRETE..." & vbNewLine &
                            "Favor retirar o valor do FRETE COBRADO ou alterar o tipo de frete...", "Frete Cobrado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            txtFreteCobrado.Focus()
            Return False
        End If
        '
        If IsNothing(_Compra.ICMSValor) OrElse _Compra.ICMSValor < 0 Then _Compra.ICMSValor = 0
        If IsNothing(_Compra.Despesas) OrElse _Compra.Despesas < 0 Then _Compra.Despesas = 0
        If IsNothing(_Compra.Descontos) OrElse _Compra.Descontos < 0 Then _Compra.Descontos = 0
        '
        '
        Return True
        '
    End Function
    '
    '==========================================================================================
    ' SAVE A PAGAR
    '==========================================================================================
    Private Function Salvar_APagar() As Boolean
        If _APagarList.Count = 0 Then Return False
        '
        Dim pagBLL As New APagarBLL
        '
        '--- Exclui todos os registros de APagar da Compra atual
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            pagBLL.APagarDeletePorOrigem(_Compra.IDCompra, clAPagar.Origem_APagar.Compra, False)
            '
            '--- Insere cada um APagar no BD
            For Each pag As clAPagar In _APagarList
                pagBLL.InserirNovo_APagar(pag)
            Next
            '
            Return True
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao SALVAR Registros de APagar..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    '==========================================================================================
    ' DO RATEIO
    '==========================================================================================
    Private Sub EfetuarRateio()
        '
        Dim Rateio As Object = Nothing
        Dim TProdutos As Decimal = TotalProdutos
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim FreteTotal As Decimal = IIf(IsNothing(_Compra.FreteCobrado), 0, _Compra.FreteCobrado)
            FreteTotal = FreteTotal + IIf(IsNothing(_Compra.FreteValor), 0, _Compra.FreteValor)
            '
            Rateio = cBLL.CompraItens_ReteioFrete(_Compra.IDCompra, FreteTotal, TProdutos)
            '
            If Not IsNumeric(Rateio) Then
                Throw New Exception(Rateio.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção no Rateio do Frete..." & vbNewLine &
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
#End Region
    '
#Region "CONTROLE DO CONTEXT MENUSTRIP"
    '
    '=============================================================================
    ' CONTROLA O MENUSTRIP NO DATAGRID ITENS
    '=============================================================================
    Private Sub dgvItens_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
        If e.Button = MouseButtons.Right Then
            '
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
            cmsMenuAPagar.Show(dgvItens, e.Location)
            '
        End If
    End Sub
    '
    '=============================================================================
    ' CONTROLA O MENUSTRIP NO DATAGRID APAGAR
    '=============================================================================
    Private Sub dgvAPagar_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvAPagar.MouseDown
        If e.Button = MouseButtons.Right Then
            '
            Dim hit As DataGridView.HitTestInfo = dgvAPagar.HitTest(e.X, e.Y)
            dgvAPagar.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvAPagar.CurrentCell = dgvAPagar.Rows(hit.RowIndex).Cells(1)
            dgvAPagar.Rows(hit.RowIndex).Selected = True
            dgvAPagar.Focus()
            '
            cmsMenuAPagar.Show(dgvAPagar, e.Location)
            '
        End If
    End Sub
    '
    Private Sub miInserir_Click(sender As Object, e As EventArgs) Handles miInserir.Click
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado

        '
        '--- Verifica a origem do comando do MenuStrip
        If cmsMenuAPagar.SourceControl.Name = "dgvItens" Then
            Inserir_Item()
        ElseIf cmsMenuAPagar.SourceControl.Name = "dgvAPagar" Then
            APagar_Adicionar()
        End If
        '
    End Sub
    '
    Private Sub miEditar_Click(sender As Object, e As EventArgs) Handles miEditar.Click
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        '--- Verifica a origem do comando do MenuStrip
        If cmsMenuAPagar.SourceControl.Name = "dgvItens" Then
            Editar_Item()
        ElseIf cmsMenuAPagar.SourceControl.Name = "dgvAPagar" Then
            If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
            APagar_Editar()
        End If
        '
    End Sub
    '
    Private Sub miExcluir_Click(sender As Object, e As EventArgs) Handles miExcluir.Click
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        '--- Verifica a origem do comando do MenuStrip
        If cmsMenuAPagar.SourceControl.Name = "dgvItens" Then
            Excluir_Item()
        ElseIf cmsMenuAPagar.SourceControl.Name = "dgvAPagar" Then
            If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
            APagar_Excluir()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS"
    '
    ' ATUALIZA O TOTAL DO APAGAR
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalAPagar() As Double
        Dim T As Double = 0
        T = _APagarList.Sum(Function(x) x.APagarValor)
        lblTotalCobrado.Text = Format(T, "c")
        Return T
    End Function
    '
    ' ATUALIZA O TOTAL DAS NOTAS FISCAIS
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalNotasFiscais() As Double
        Dim T As Double = 0
        T = _NotasList.Sum(Function(x) x.NotaValor)
        Return T
    End Function
    '
#End Region
    '
#Region "BLOQUEIO DE REGISTROS"
    '
    ' PROIBE EDICAO NOS COMBOBOX QUANDO COMPRA BLOQUEADA
    '-----------------------------------------------------------------------------------------------------
    Private Sub ComboBox_SelectedValueChanged(sender As Object, e As EventArgs) _
        Handles cmbFreteTipo.SelectedValueChanged,
        cmbIDTransportadora.SelectedValueChanged
        '
        If Sit = EnumFlagEstado.RegistroBloqueado AndAlso VerificaAlteracao = True Then
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            '
            Select Case cmb.Name
                Case "cmbCobrancaTipo"
                    VerificaAlteracao = False
                    VerificaAlteracao = True
                Case "cmbFreteTipo"
                    VerificaAlteracao = False
                    cmbFreteTipo.SelectedValue = IIf(IsNothing(_Compra.FreteTipo), -1, _Compra.FreteTipo)
                    VerificaAlteracao = True
                Case "cmbIDTransportadora"
                    VerificaAlteracao = False
                    cmbIDTransportadora.SelectedValue = IIf(IsNothing(_Compra.IDTransportadora), -1, _Compra.IDTransportadora)
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
            MessageBox.Show("Esse registro de COMPRA está BLOQUEADO para alterações..." & vbNewLine &
                            "Não é possível adicionar produtos ou alterar algum dado!",
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
        '--- check Sit
        If Not Sit = EnumFlagEstado.RegistroSalvo Then Return False
        '
        '--- ask to user
        If AbrirDialog("Esse registro de COMPRA já se encontra FINALIZADO..." & vbNewLine &
                       "Deseja realmente fazer alterações nesse registro?",
                       "Registro Finalizado",
                       frmDialog.DialogType.SIM_NAO,
                       frmDialog.DialogIcon.Question) = DialogResult.No Then Return True
        '
        '--- Edita o registro e altera a situação
        _Compra.IDSituacao = 1
        Sit = EnumFlagEstado.Alterado
        '
        '--- SAVE A TRANSACAO/COMPRA NO BD
        If SalvaRegistroCompra() Then
            Return False
        Else
            Return True
        End If
        '
    End Function
    '
    Private Function CanCloseMessage() As Boolean
        '
        If Not (Sit = EnumFlagEstado.NovoRegistro Or Sit = EnumFlagEstado.Alterado) Then Return True
        '
        If AbrirDialog("Essa COMPRA ainda não está CONCLUÍDA!" & vbNewLine & vbNewLine &
                        "Se você fechar agora o fomulário de compra," & vbNewLine &
                        "Algumas alterações podem ser perdidas." & vbNewLine & vbNewLine &
                        "Deseja Fechar a Compra assim mesmo?",
                        "Fechar a Compra",
                        frmDialog.DialogType.SIM_NAO,
                        frmDialog.DialogIcon.Question) = vbNo Then
            '
            '--- Seleciona a TAB
            tabPrincipal.SelectedTab = vtab2
            '
            '--- Select Control txtValorFrete
            dgvAPagar.Focus()
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
#Region "NOTA FISCAL CONTROLE GRID"
    '
    Private Sub obterNotas()
        '
        Dim nBLL As New NotaFiscalBLL
        Try
            _NotasList = nBLL.NotaFiscal_GET_PorIDCompra(_Compra.IDCompra)
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter a listagem de Notas Fiscais:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub Preenche_Notas()
        '
        With dgvVendaNotas
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
            .DataSource = bindNota
            If .Rows.Count > 0 Then .CurrentCell = .Rows(.Rows.Count).Cells(1)
        End With
        '
        '--- formata as colunas do datagrid
        FormataGrid_Notas()
        '
    End Sub
    '
    Private Sub FormataGrid_Notas()
        '
        Dim cellStyleCur As New DataGridViewCellStyle
        cellStyleCur.Format = "c"
        cellStyleCur.NullValue = Nothing
        cellStyleCur.Alignment = DataGridViewContentAlignment.MiddleRight
        '
        ' (1) COLUNA CHAVE ACESSO
        dgvVendaNotas.Columns.Add("clnChaveAcesso", "Chave Acesso")
        With dgvVendaNotas.Columns("clnChaveAcesso")
            .DataPropertyName = "ChaveAcesso"
            .Width = 350
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA NOTA TIPO DESCRIÇÃO
        dgvVendaNotas.Columns.Add("clnNotaTipoDesc", "Nota Tipo")
        With dgvVendaNotas.Columns("clnNotaTipoDesc")
            .DataPropertyName = "NotaTipoDesc"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA NOTA SERIE
        dgvVendaNotas.Columns.Add("clnNotaSerie", "Série")
        With dgvVendaNotas.Columns("clnNotaSerie")
            .DefaultCellStyle.Format = "000"
            .DataPropertyName = "NotaSerie"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA NOTA NUMERO
        dgvVendaNotas.Columns.Add("clnNotaNumero", "Número")
        With dgvVendaNotas.Columns("clnNotaNumero")
            .DataPropertyName = "NotaNumero"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (5) COLUNA NOTA EMISSAO DATA
        dgvVendaNotas.Columns.Add("clnEmissaoData", "Emissão Dt.")
        With dgvVendaNotas.Columns("clnEmissaoData")
            .DataPropertyName = "EmissaoData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (6) COLUNA NOTA VALOR
        dgvVendaNotas.Columns.Add("clnNotaValor", "Valor")
        With dgvVendaNotas.Columns("clnNotaValor")
            .DefaultCellStyle = cellStyleCur
            .DataPropertyName = "NotaValor"
            .Width = 80
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
    ' COLOCA UM TEXTO QUANDO A CHAVE DE ACESSO É NULA
    Private Sub dgvVendaNotas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvVendaNotas.CellFormatting
        '
        If e.ColumnIndex = 0 Then '--- Coluna CHAVE ACESSO
            Select Case e.Value
                Case Nothing
                    e.Value = "SEM CHAVE DE ACESSO"
            End Select
        End If
        '
    End Sub
    '
    Private Sub dgvVendaNotas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvVendaNotas.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
            '
            Nota_Adicionar()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
            '
            Nota_Editar()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            '
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
            '
            Nota_Excluir()
        End If
        '
    End Sub
    '
    Private Sub Nota_Adicionar()
        '
        Nota_LimparControles()
        lblNota.Text = "Inserindo Nota Fiscal"
        btnNotaOK.Text = "Inserir"
        pnlNota.Visible = True
        txtChaveAcesso.Focus()
        '
    End Sub
    '
    Private Sub Nota_Editar()
        '
        If MessageBox.Show("Deseja Editar a Nota Fiscal Selecionada?", "Editar Nota Fiscal",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        Nota_PreencherControles()
        lblNota.Text = "Editando Nota Fiscal"
        btnNotaOK.Text = "Salvar"
        pnlNota.Visible = True
        txtChaveAcesso.Focus()
        '
    End Sub
    '
    Private Sub Nota_Excluir()
        ' Verifica qual item da NotaList esta selecionada
        If dgvVendaNotas.Rows.Count = 0 Then Exit Sub
        If IsNothing(dgvVendaNotas.CurrentCell) Then Exit Sub
        '
        ' --- pergunta ao usuário
        If MessageBox.Show("Deseja realmente EXCLUIR a Nota Fiscal Selecionada?", "Excluir Nota Fiscal",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        Dim Nota As clNotaFiscal = dgvVendaNotas.Rows(dgvVendaNotas.CurrentCell.RowIndex).DataBoundItem
        '
        ' Deleta a Nota no BD
        ExcluirNota(Nota.IDNota)
        '
    End Sub
    '
    Private Sub dgvVendaNotas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVendaNotas.CellDoubleClick
        SendKeys.Send("{ENTER}")
    End Sub
    '
    '--- Limpar os controles de texto da Nota Fiscal
    Private Sub Nota_LimparControles()
        txtChaveAcesso.Clear()
        cmbNotaTipo.SelectedIndex = -1
        txtNotaSerie.Clear()
        txtNotaNumero.Clear()
        txtNotaValor.Clear()
        txtEmissaoData.Text = _Compra.TransacaoData
    End Sub
    '
    '--- Preencher os controles da NF pelo NotaLista
    Private Sub Nota_PreencherControles()
        '
        ' Verifica qual item da NotaList esta selecionada
        If dgvVendaNotas.Rows.Count = 0 Then Exit Sub
        If IsNothing(dgvVendaNotas.CurrentCell) Then Exit Sub
        '
        Dim Nota As clNotaFiscal = dgvVendaNotas.Rows(dgvVendaNotas.CurrentCell.RowIndex).DataBoundItem
        '
        ' Preenche os controles da Nota Selecionada
        txtChaveAcesso.Text = Nota.ChaveAcesso
        txtChaveAcesso.Tag = Nota.IDNota
        cmbNotaTipo.SelectedValue = Nota.NotaTipo
        txtNotaSerie.Text = Format(Nota.NotaSerie, "000")
        txtNotaNumero.Text = Format(Nota.NotaNumero, "000,000,000")
        txtNotaValor.Text = Format(Nota.NotaValor, "C")
        txtEmissaoData.Text = Nota.EmissaoData
        '
        ' Deleta a Nota no BD
        ExcluirNota(Nota.IDNota)
        '
    End Sub
    '
    ' FUNÇÃO PARA EXCLUIR A NOTA FISCAL DO BD
    Private Sub ExcluirNota(myIDNota As Integer)
        ' Deleta a Nota no BD
        Dim NotaBLL As New NotaFiscalBLL
        Try
            NotaBLL.Excluir_Nota_Transacao(Nothing, myIDNota)
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao excluir a Nota no BD" & vbCrLf &
                            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        '
        ' Retira o item da Notalist
        Dim i As Integer = _NotasList.FindIndex(Function(x) x.IDNota = myIDNota)
        '
        '--- Atualiza o ITEM da lista
        _NotasList.RemoveAt(i)
        bindNota.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvVendaNotas.DataSource = bindNota
        '
    End Sub
    '
    '--- Permitir apenas numeros na Chave de Acesso da Nota
    Private Sub txtChaveAcesso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChaveAcesso.KeyPress
        If Char.IsNumber(e.KeyChar) OrElse e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    '
    '--- Cancelar INSERIR / EDITAR nota quando pressionar ESC
    Private Sub NotaControles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChaveAcesso.KeyDown,
        cmbNotaTipo.KeyDown, txtNotaSerie.KeyDown, txtNotaNumero.KeyDown, txtNotaValor.KeyDown, txtEmissaoData.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnNotaCancel_Click(sender, New EventArgs)
        End If
        '
    End Sub
    '
    '--- Tirar o som da teclar ESC
    Private Sub Controle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmissaoData.KeyPress,
            cmbNotaTipo.KeyPress
        '
        If e.KeyChar = Convert.ToChar(Keys.Enter) OrElse e.KeyChar = Convert.ToChar(Keys.Escape) Then
            ' stop annoying beep
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- Btn Efetuar Edição ou Inserir Nota Fiscal
    Private Sub btnNotaOK_Click(sender As Object, e As EventArgs) Handles btnNotaOK.Click
        '
        ' verifica os valores dos campos
        If Not VerificarNotaValores() Then Exit Sub
        '
        ' CRIA nova classe Nota
        Dim newNota As New clNotaFiscal
        '
        With newNota
            .ChaveAcesso = txtChaveAcesso.Text
            .EmissaoData = txtEmissaoData.Text
            .IDTransacao = _Compra.IDCompra
            .NotaNumero = txtNotaNumero.Text
            .NotaSerie = txtNotaSerie.Text
            .NotaTipo = Convert.ToByte(cmbNotaTipo.SelectedValue)
            .NotaValor = txtNotaValor.Text
        End With
        '
        ' INSERE NOTA NO BD
        Dim NotaBLL As New NotaFiscalBLL
        '
        Try
            newNota.IDNota = NotaBLL.InserirNova_Nota(newNota)
        Catch ex As Exception
            MessageBox.Show("Uma exceção inesperada ocorreu na tentativa de inserir Nova Nota Fiscal no BD..." & vbCrLf &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        '
        '--- Insere a NOTA na lista
        _NotasList.Add(newNota)
        bindNota.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvVendaNotas.DataSource = bindNota
        bindNota.MoveLast()
        dgvVendaNotas.Focus()
        '
        '--- Limpa os controles
        Nota_LimparControles()
        '
    End Sub
    '
    '--- Btn Cancelar a Edição da Nota Fiscal
    Private Sub btnNotaCancel_Click(sender As Object, e As EventArgs) Handles btnNotaCancel.Click
        Nota_LimparControles()
        pnlNota.Visible = False
        dgvVendaNotas.Focus()
    End Sub
    '
    '--- Função que Verifica os Campos/Valores da Nota Fiscal
    Private Function VerificarNotaValores() As Boolean
        Dim F As New Utilidades

        'verifica CHAVE ACESSO
        'If Not F.VerificaControlesForm(txtChaveAcesso, "Chave de Acesso") Then Return False
        '
        If txtChaveAcesso.Text.Length > 0 AndAlso txtChaveAcesso.Text.Length <> 44 Then
            MessageBox.Show("A chave de Acesso precisa ter 44 dígitos", "Chave de Acesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtChaveAcesso.Focus()
            Return False
        End If
        '
        'verifica NOTA TIPO
        If Not F.VerificaControlesForm(cmbNotaTipo, "Tipo da Nota") Then Return False
        '
        ' verifica NOTA SERIE
        If Not F.VerificaControlesForm(txtNotaSerie, "Série da Nota") Then Return False
        '
        ' verifica NOTA NUMERO
        If Not F.VerificaControlesForm(txtNotaNumero, "Número da Nota") Then Return False
        '
        ' verifica EMISSÃO DATA
        If Not F.VerificaControlesForm(txtEmissaoData, "Data de Emissão da Nota") Then Return False
        '
        ' verifica NOTA VALOR
        If Not F.VerificaControlesForm(txtNotaValor, "Valor Total da Nota") Then Return False
        '
        Return True
        '
    End Function
    '
    '--- Ao deixar o painel da Nota fica invisivel
    Private Sub pnlNota_Leave(sender As Object, e As EventArgs) Handles pnlNota.Leave
        pnlNota.Visible = False
    End Sub
    '
    Private Sub PreencheCamposPelaChave()

        MsgBox("Implantando leitura da chave de acesso...")
        Exit Sub

        If txtChaveAcesso.Text.Length >= 44 Then
            Dim C As String = txtChaveAcesso.Text
            Dim NotaData As Date = DateSerial(C.Substring(2, 2), C.Substring(4, 2), 1)
            txtEmissaoData.Text = NotaData
        End If
    End Sub
    '
    Private Sub txtChaveAcesso_TextChanged(sender As Object, e As EventArgs) Handles txtChaveAcesso.TextChanged
        If txtChaveAcesso.Text.Length >= 44 Then PreencheCamposPelaChave()
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
    ' PROCURA COMPRA
    '-----------------------------------------------------------------------------------------------------
    Public Sub ProcuraCompra()
        '
        '--- close
        Me.Close()
        '
        '--- open form procura
        Dim frmP As New frmOperacaoEntradaProcurar
        OcultaMenuPrincipal()
        Dim fPrincipal As Form = Application.OpenForms.OfType(Of frmPrincipal)().First
        frmP.MdiParent = fPrincipal
        frmP.Show()
        '
    End Sub
    '
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        '--- verifica e pergunta
        If Not CanCloseMessage() Then Exit Sub
        '
        '--- abre procura
        ProcuraCompra()
        '
    End Sub
    '
    ' CRIA UMA NOVA COMPRA
    '-----------------------------------------------------------------------------------------------------
    Public Sub NovaCompra()
        '
        Visible = False
        '
        Dim c As New AcaoGlobal
        Dim newCompra As Object = c.Compra_Nova
        '
        Me.Visible = True
        '
        If IsNothing(newCompra) Then Exit Sub
        '
        _Compra = newCompra
        '
    End Sub
    '
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        '
        '--- verifica e pergunta
        If Not CanCloseMessage() Then Exit Sub
        '
        NovaCompra()
        '
    End Sub
    '
    ' EXCLUIR COMPRA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        '--- Verifica bloqueio
        If RegistroBloqueado() Then Exit Sub
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você deseja realmente excluir definitivamente essa Compra?",
                           "Excluir Compra",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '--- Excluir Compra
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If cBLL.DeletaCompraPorID(_Compra.IDCompra, _IDFilial) Then
                '
                '--- fecha
                Close()
                MostraMenuPrincipal()
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir a Compra..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '


    End Sub
    '
    ' IMPRIMIR ETIQUETAS COMPRA
    '-----------------------------------------------------------------------------------------------------
    Private Sub miImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles miImprimirEtiquetas.Click
        MsgBox("Em Implementação")

    End Sub
    '
    ' IMPRIMIR RELATORIO
    '-----------------------------------------------------------------------------------------------------
    Private Sub miImprimirRelatorio_Click(sender As Object, e As EventArgs) Handles miImprimirRelatorio.Click
        MsgBox("Em Implementação")

    End Sub
    '
#End Region '/ MENU ACAO INFERIOR
    '
End Class
