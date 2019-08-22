Imports CamadaDTO
Imports CamadaBLL
Imports System.Xml
'
Public Class frmPedido
    Private _pedido As clPedido
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private bindPedido As New BindingSource
    Private _pedBLL As New PedidoBLL
    Private _strPedidoImportado As String = ""
    '
    '--- Migracao
    Private _pedMigrados As New List(Of clPedido)
    Private ShowMessage As Boolean = False
    '
    '--- Itens do pedido
    Public ItensList As New List(Of clPedidoItem)
    Public bindItens As New BindingSource
    Private currentEditRow As Integer? = Nothing
    Private _rowSit As EnumFlagEstado
    Const rowHeight As Integer = 25 '--- define o tamanho da row no DataGridView
    '
    '--- Mensagens do Pedido
    Private _MensagensList As New List(Of clPedidoMensagem)
    Private bindMensagem As New BindingSource
    '
    '--- contantes para alterar o tamanho do form
    Private fHeight As Integer = 680
    Private _formAmpliado As Boolean = True
    '
#Region "LOAD E PROPERTIES"
    '
    Sub New(myPedido As clPedido)

        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- define o tamanho
        Dim tamMaxH = My.Application.OpenForms("frmPrincipal").Height - 73
        Height = tamMaxH - (tamMaxH * 3) / 100
        fHeight = Height
        '
        If IsNothing(myPedido) Then
            MessageBox.Show("Esse formulário não pode ser aberto assim...", "Erro ao abrir")
        End If
        '
        propPedido = myPedido
        PreencheDataBindings()
        '
        Handler_MouseMove()
        Handler_MouseUp()
        Handler_MouseDown()
        '
        AddHandlerControles() ' adiciona o handler para selecionar e usar tab com a tecla enter
        '
    End Sub
    '
    '--- DEFINE O TAMANHO DO FORM SE FOR NOVO REGISTRO
    Private Sub frmPedido_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            formAmpliado = False
        Else
            formAmpliado = True
        End If
        '
        If ShowMessage Then
            AbrirDialog("Como esse pedido foi migrado é possível apenas fazer alterações nos itens do pedido..." + vbCrLf +
                        "É possível: ALTERAR, REMOVER e INCLUIR produtos.",
                        "Pedido Migrado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
        End If
        '
    End Sub
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnCancelar.Enabled = False
                btnProcurar.Enabled = True
                btnExcluir.Enabled = True
                lblID.Text = Format(_pedido.IDPedido, "0000")
                formAmpliado = True
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                btnProcurar.Enabled = False
                formAmpliado = True
                btnExcluir.Enabled = False
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtFornecedor.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                btnProcurar.Enabled = False
                lblID.Text = "NOVO"
                btnExcluir.Enabled = False
                _pedido.IDFilial = Obter_FilialPadrao()
                _pedido.ApelidoFilial = ObterDefault("FilialDescricao")
                formAmpliado = False
            End If
            '
        End Set
    End Property
    '
    Public Property propPedido() As clPedido
        Get
            Return _pedido
        End Get
        Set(ByVal value As clPedido)
            '
            _pedido = value
            bindPedido.DataSource = _pedido
            '
            If Not IsNothing(_pedido.IDPedido) Then
                Sit = EnumFlagEstado.RegistroSalvo
                GetItens()
                PreencheItens()
                GetMensagens()
                PreencheMensagens()
                VerificaBloqueio()
            Else
                Sit = EnumFlagEstado.NovoRegistro
            End If
            '
        End Set
    End Property
    '
    Private Property formAmpliado() As Boolean
        '
        Get
            Return _formAmpliado
        End Get
        Set(ByVal value As Boolean)
            '
            If Me.CanFocus Then
                '
                If value <> _formAmpliado Then
                    AlteraTamanhoForm(value)
                End If
                '
                _formAmpliado = value
                '
            End If
            '
        End Set
        '
    End Property
    '
    '--- VERIFICA A SITUACAO E BLOQUEIA OU LIBERA A EDIÇÃO
    Private Sub VerificaBloqueio()
        '
        Dim compondo As Boolean
        Dim destino As Boolean = True
        '
        '--- se pedido esta em composicao
        compondo = IIf(_pedido.Situacao = 0, True, False)
        '
        '--- se pedido migrado then check pedidoDestino Situacao
        If Not IsNothing(_pedido.IDMigracao) Then
            Dim pedMigradoSituacao As Byte = GetSituacaoPedidoMigrado()
            destino = IIf(pedMigradoSituacao = 0, True, False)
            '
            If destino = True Then
                If Me.IsAccessible Or ShowMessage Then
                    AbrirDialog("Como esse pedido foi migrado é possível apenas fazer alterações nos itens do pedido..." + vbCrLf +
                                "É possível: ALTERAR, REMOVER e INCLUIR produtos.",
                                "Pedido Migrado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Else '--- revela a mensagem somente apos abrir o formulario
                    ShowMessage = True
                End If
            End If
            '
        End If
        '
        dgvItens.ReadOnly = Not compondo And Not destino
        dgvMensagens.ReadOnly = Not compondo
        '
        txtFornecedor.ReadOnly = Not compondo
        txtVendedorNome.ReadOnly = Not compondo
        txtTelefoneContato.ReadOnly = Not compondo
        txtObservacao.ReadOnly = Not compondo
        txtEmailVendas.ReadOnly = Not compondo
        '
        dgvItens.AllowUserToDeleteRows = compondo And Not destino
        dgvMensagens.AllowUserToDeleteRows = compondo
        btnProcFornecedores.Enabled = compondo
        btnProcTransportadora.Enabled = compondo
        btnMensagemPadrao.Enabled = compondo
        btnExcluir.Enabled = compondo
        btnVerificarAdicionar.Enabled = IIf(_pedido.Situacao = 4, destino, compondo)
        btnProdutosFornecedor.Enabled = IIf(_pedido.Situacao = 4, destino, compondo)
        btnImportarExportar.Enabled = compondo
        '
    End Sub
    '
    '--- GET PEDIDO MIGRADO SITUACAO
    Private Function GetSituacaoPedidoMigrado() As Byte
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Return _pedBLL.GetPedidoMigradoSituacaoOrigem(_pedido.IDMigracao)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a situacao do pedido migrado..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
#End Region
    '
#Region "DATABINDINGS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        '--- LABEL
        lblID.DataBindings.Add("Tag", bindPedido, "IDPedido")
        lblInicioData.DataBindings.Add("text", bindPedido, "InicioData")
        lblFilial.DataBindings.Add("Text", bindPedido, "ApelidoFilial")
        lblSituacaoDescricao.DataBindings.Add("Text", bindPedido, "SituacaoDescricao")
        lblValorTotal.DataBindings.Add("Text", bindPedido, "TotalPedido")
        '
        '--- TEXTBOX
        txtFornecedor.DataBindings.Add("Text", bindPedido, "Fornecedor", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
        txtVendedorNome.DataBindings.Add("Text", bindPedido, "VendedorNome", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
        txtTelefoneContato.DataBindings.Add("Text", bindPedido, "TelefoneContato", True, DataSourceUpdateMode.OnPropertyChanged, "  /  /")
        txtEmailVendas.DataBindings.Add("Text", bindPedido, "EmailVendas", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
        txtObservacao.DataBindings.Add("Text", bindPedido, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
        txtTransportadora.DataBindings.Add("Text", bindPedido, "Transportadora", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
        txtTelefoneATransportadora.DataBindings.Add("Text", bindPedido, "TelefoneATransportadora", True, DataSourceUpdateMode.OnPropertyChanged, "  /  /")
        '
        '--- FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler lblValorTotal.DataBindings("Text").Format, AddressOf FormatCUR
        '
        '--- ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(bindPedido.CurrencyManager.Current, clPedido).AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If bindPedido.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
        If IsDBNull(e.Value) Then Exit Sub
        e.Value = Format(e.Value, "0000")
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    '--- PREENCHE DGVCOMBO IDPRODUTOTIPO
    Private Sub PreencheCombo_IDProdutoTipo()
        Dim PBLL As New TipoSubTipoCategoriaBLL
        Try
            Dim TipoDt As DataTable = PBLL.GetTipos
            '
            clnIDProdutoTipo.DataSource = TipoDt
            clnIDProdutoTipo.DisplayMember = "ProdutoTipo"
            clnIDProdutoTipo.ValueMember = "IDProdutoTipo"
            '
        Catch ex As Exception

        End Try
        '
    End Sub
    '
#End Region
    '
#Region "CARREGA/INSERE ITENS"
    '
    '--- RETORNA TODOS OS ITENS DO PEDIDO
    Private Sub GetItens()
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            ItensList = _pedBLL.GetPedidoItens_IDPedido_List(_pedido.IDPedido, _pedido.IDFilial)
            bindItens.DataSource = ItensList
            '
            '--- Check Pedidos Migrados
            CheckPedidoMigrado()
            '
            '--- Atualiza o label TOTAL
            AtualizaTotalGeral()
            '
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter Itens do Pedido:" & vbNewLine &
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
            .ReadOnly = False
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
            .ReadOnly = False
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
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA PRODUTO TIPO
        With clnIDProdutoTipo
            .DataPropertyName = "IDProdutoTipo"
            '.Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
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
        '--- preenche o Combo IDProdutoTipo
        PreencheCombo_IDProdutoTipo()
        '
    End Sub
    '
    Private Sub dgvItens_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvItens.CellFormatting
        '
        'WHEN 0 THEN Pedido Local'
        'WHEN 1 THEN Reserva Local'
        'WHEN 2 THEN Pedido Filial'
        'WHEN 3 THEN Reserva Filial'
        'WHEN 4 THEN Migracao Local'
        '
        If e.ColumnIndex = 1 Then
            '
            Dim myOrigem As Byte = If(IsNothing(dgvItens.Rows(e.RowIndex).DataBoundItem), 0, dgvItens.Rows(e.RowIndex).DataBoundItem.Origem)
            '
            Select Case myOrigem
                Case 0 '--- Origem PEDIDO LOCAL
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    e.CellStyle.ForeColor = Color.Black
                Case 1 '--- Origem RESERVA LOCAL
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightCyan
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    e.CellStyle.ForeColor = Color.Black
                Case 2, 3 '--- Origem FILIAL, RESERVA FILIAL
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Firebrick
                    e.CellStyle.ForeColor = Color.Red
                Case 4 '--- Origem MIGRACAO LOCAL
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                    dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
            '
        End If
        '
    End Sub
    '
#End Region
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
            '
            '--- verifica se esse item tem origem na reserva e bloqueia alteracao do produto
            If dgvItens.Rows(e.RowIndex).DataBoundItem.Origem = 1 Then
                '
                If e.ColumnIndex <= 4 Then '--- RGProduto, Produto, Tipo, Autor
                    e.Cancel = True
                    AbrirDialog("O Produto desse item no pedido não pode ser alterado " +
                                "porque está vinculado a uma reserva de produto...",
                                "Item Reservado", frmDialog.DialogType.OK,
                                frmDialog.DialogIcon.Information)
                    Return
                End If
                '
            ElseIf dgvItens.Rows(e.RowIndex).DataBoundItem.Origem > 1 Then
                '
                '--- impede alteracoes nas seguintes colunas:
                '--- RGProduto, Produto, Tipo, Autor, quantidade
                If e.ColumnIndex <= 4 Or e.ColumnIndex = clnQuantidade.Index Then
                    e.Cancel = True
                    AbrirDialog("O Produto desse item no pedido não pode ser alterado " +
                                "porque está vinculado a migração de pedido...",
                                "Item Migrado", frmDialog.DialogType.OK,
                                frmDialog.DialogIcon.Information)
                    Return
                End If
                '
            End If
            '
            _rowSit = EnumFlagEstado.Alterado
            '
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
                Return
            ElseIf item.IDFilialOrigem <> _pedido.IDFilial Then
                e.Cancel = True
                MessageBox.Show("Esse item contém um produto migrado..." & vbNewLine &
                                "O Estoque Nivel e Ideal não podem ser alterados de um item migrado.",
                                "Item Migrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
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
                Return
            ElseIf item.IDFilialOrigem <> _pedido.IDFilial Then
                e.Cancel = True
                MessageBox.Show("Esse item contém um produto migrado..." & vbNewLine &
                                "O Estoque Nivel e Ideal não podem ser alterados de um item migrado.",
                                "Item Migrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If _rowSit = EnumFlagEstado.NovoRegistro OrElse _rowSit = EnumFlagEstado.Alterado Then
            '
            '--- Verifica os valores inseridos
            If VerificaItem(e.RowIndex) = False Then
                e.Cancel = True
                'bindItens.CancelEdit()
            Else
                '
                Dim myItem As clPedidoItem = dgvItens.Rows(e.RowIndex).DataBoundItem
                '
                If _rowSit = EnumFlagEstado.NovoRegistro Then
                    '
                    Try
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
                        '--- check if is not MIGRACAO
                        If myItem.Origem <= 1 Then '--- ORIGEM: Normal e Reserva --> pode alterar
                            ItemAlterar(dgvItens.Rows(e.RowIndex).DataBoundItem)
                        End If
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
    Public Function ItemInserir(myItem As clPedidoItem) As Integer
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim myI As Object = _pedBLL.PedidoItem_Inserir(myItem)
            '
            If IsNumeric(myI) Then
                myItem.IDPedidoItem = myI
                If IsNothing(myItem.Origem) Then
                    myItem.Origem = 0
                End If
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
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
    '--- ALTERA ITEM NO PEDIDO
    Private Function ItemAlterar(myItem As clPedidoItem) As Integer
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
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
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
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
    '--- PROCURA OS DADOS DO PRODUTO PELO RGPRODUTO E PREECHE O LISTOF
    Private Function ProcuraItemRG(myRG As Integer) As Boolean
        '
        '--- obter as informacoes do produto digitado
        Try
            Dim prod As clProduto = Nothing
            Using pBLL As New ProdutoBLL
                prod = pBLL.GetProduto_PorRG(myRG, _pedido.IDFilial)
            End Using
            '
            If IsNothing(prod) Then
                MessageBox.Show("Registro de Produto não encontrado..." & vbNewLine &
                                "Favor digite um Registro válido.", "Reg. Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            Dim clitem As clPedidoItem = bindItens.Current
            '
            clitem.RGProduto = prod.RGProduto
            clitem.IDProduto = prod.IDProduto
            clitem.Produto = prod.Produto
            clitem.Autor = prod.Autor
            clitem.IDProdutoTipo = prod.IDProdutoTipo
            clitem.Estoque = prod.Estoque
            clitem.EstoqueNivel = prod.EstoqueNivel
            clitem.EstoqueIdeal = prod.EstoqueIdeal
            clitem.Preco = prod.PCompra
            clitem.Desconto = prod.DescontoCompra
            clitem.Origem = 0
            '
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu..." & vbNewLine &
                            ex.Message, "Obter Produto",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
    End Function
    '
    '--- ALTERA O ESTOQUE MINIMO E/OU IDEAL
    '----------------------------------------------------------------------------------
    Private Sub Altera_Item_EstoqueNivel(IDProduto As Integer, EstNivel As Integer, EstIdeal As Integer)
        '
        Using prodBLL As New ProdutoBLL
            '
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
            _pedBLL.PedidoItem_Excluir(delItem)
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
    '--- INSERT PRODUTO DE UM FORMULARIO EXTERNO
    '---------------------------------------------------------------------------------------------
    Public Function InsertProdutoPedido(IDProduto) As Boolean
        '
        '--- verifica se o produto ja foi inserido
        If ItensList.Where(Function(x) x.IDProduto = IDProduto).Count > 0 Then
            Throw New Exception("Esse produto já está presente no pedido...")
            Return False
        End If
        '
        '--- obter as informacoes do produto digitado
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- GET PRODUTO AND CONVERT TO PEDIDO ITEM
            Dim prod As clProduto = Nothing
            Using pBLL As New ProdutoBLL
                prod = pBLL.GetProduto_PorID(IDProduto, _pedido.IDFilial)
            End Using
            '
            If IsNothing(prod) Then
                Throw New Exception("Produto não encontrado com esse ID...")
            End If
            '
            '--- CONVERT TO PEDIDO ITEM
            Dim clitem As New clPedidoItem
            '
            clitem.IDPedido = _pedido.IDPedido
            clitem.IDFilialOrigem = _pedido.IDFilial
            clitem.RGProduto = prod.RGProduto
            clitem.IDProduto = prod.IDProduto
            clitem.Produto = prod.Produto
            clitem.Autor = prod.Autor
            clitem.IDProdutoTipo = prod.IDProdutoTipo
            clitem.Estoque = prod.Estoque
            clitem.EstoqueNivel = prod.EstoqueNivel
            clitem.EstoqueIdeal = prod.EstoqueIdeal
            clitem.Preco = prod.PCompra
            clitem.Desconto = prod.DescontoCompra
            clitem.Origem = 0
            '
            '--- INSERT ITEM IN BD
            ItemInserir(clitem)
            '
            '--- INSERT ITEM IN BINDLIST
            bindItens.Add(clitem)
            bindItens.ResetBindings(False)
            '
            Return True
            '
        Catch ex As Exception
            Throw ex
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
#End Region
    '
#Region "MIGRACAO"
    '
    '--- CHECK ALL PEDIDOS MIGRATED IN
    '----------------------------------------------------------------------------------
    Private Sub CheckPedidoMigrado()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _pedMigrados = _pedBLL.GetPedidosMigrados(_pedido.IDPedido)
            '
            If _pedMigrados.Count > 0 Then
                '
                For Each ped In _pedMigrados
                    If ped.IDFilial = _pedido.IDFilial Then
                        InsertMigratedItens(ped.IDPedido, ped.IDFilial, 4) '--- migracao LOCAL
                    Else
                        InsertMigratedItens(ped.IDPedido, ped.IDFilial, 2) '--- migracao FILIAL
                    End If
                Next
                '
                '--- update Binding list
                bindItens.ResetBindings(False)
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter lista de pedidos migrados..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '

        '
    End Sub
    '
    '--- ADD ALL ITENS OF MIGRATED PEDIDO
    '----------------------------------------------------------------------------------
    Private Sub InsertMigratedItens(IDPedido As Integer,
                                    IDFilial As Integer,
                                    newOrigem As Byte)
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim migList As List(Of clPedidoItem) = _pedBLL.GetPedidoItens_IDPedido_List(IDPedido, IDFilial)
            '
            For Each item In migList
                item.Origem = newOrigem
            Next
            '
            ItensList.AddRange(migList)
            '
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter Itens do Pedido:" & vbNewLine &
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
    '--- IMPORTAR PEDIDO
    '----------------------------------------------------------------------------------
    Private Sub miImportarPedido_Click(sender As Object, e As EventArgs) Handles miImportarPedido.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- get the pedido that will be imported
            Dim frm As New frmPedidoImportarMigrar(True, _pedido.IDFornecedor, _pedido.IDPedido)
            frm.ShowDialog()
            '
            If frm.DialogResult <> DialogResult.OK Then Exit Sub
            '
            '--- Realiza a migracao
            _pedBLL.MakeMigracao(frm.propPedido.IDPedido, _pedido.IDPedido)
            _pedMigrados.Add(frm.propPedido)
            '
            If _pedido.IDFilial = frm.propIDFilial Then
                InsertMigratedItens(frm.propPedido.IDPedido, frm.propIDFilial, 4) '--- migracao LOCAL
            Else
                InsertMigratedItens(frm.propPedido.IDPedido, frm.propIDFilial, 2) '--- migracao FILIAL
            End If
            '
            bindItens.ResetBindings(False)
            '
            AbrirDialog("Pedido importado com sucesso!", "Pedido Importado",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao fazer a Importação do pedido" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- MIGRAR PEDIDO PARA OUTRO
    '----------------------------------------------------------------------------------
    Private Sub miMigrarPara_Click(sender As Object, e As EventArgs) Handles miMigrarPara.Click
        '
        If _pedMigrados.Count > 0 Then
            AbrirDialog("Não é possível migrar um pedido que possui outros pedidos migrados a ele.",
                        "Pedidos Migrados", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        If Sit <> EnumFlagEstado.RegistroSalvo Then
            AbrirDialog("É necessário salvar o pedido antes de fazer a migração",
                        "Necessário Salvamento", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- get the pedido that will be imported
            Dim frm As New frmPedidoImportarMigrar(False, _pedido.IDFornecedor, _pedido.IDPedido)
            frm.ShowDialog()
            '
            If frm.DialogResult <> DialogResult.OK Then Exit Sub
            '
            '--- Realiza a migracao
            _pedBLL.MakeMigracao(_pedido.IDPedido, frm.propPedido.IDPedido)
            _pedido.IDMigracao = frm.propPedido.IDPedido
            _pedido.Situacao = 4
            _pedido.SituacaoDescricao = "Migrado"
            lblSituacaoDescricao.DataBindings("Text").ReadValue()
            VerificaBloqueio()
            '
            AbrirDialog("Pedido migrado com sucesso!", "Pedido Migrado",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao fazer a migração do pedido" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '/ MIGRACAO
    '
#Region "ACAO BOTOES"
    '
    '--- BTN PROCURAR
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        Dim fProc As New frmPedidoProcurar(Me)
        fProc.ShowDialog()
        '
    End Sub
    '
    '--- BTN NOVO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        propPedido = New clPedido
        Sit = EnumFlagEstado.NovoRegistro
        txtFornecedor.Focus()
    End Sub
    '
    '--- BTN CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If Sit = EnumFlagEstado.NovoRegistro Then
            btnFechar_Click(sender, e)
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            bindPedido.CancelEdit()
        End If
        '
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    '--- BTN FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        If Sit <> EnumFlagEstado.RegistroSalvo Then
            If MessageBox.Show("O Registro de Pedido inserido ou alterado ainda NÃO FOI SALVO..." & vbNewLine &
                               "Deseja salvar antes de sair?", "Salvr Registro",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                '--- salva o registro
                btnSalvar_Click(sender, e)
                '
                '--- verifica salvamento
                If Sit <> EnumFlagEstado.RegistroSalvo Then
                    Exit Sub
                End If
                '
            End If
        End If
        '
        AutoValidate = AutoValidate.Disable
        Me.Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        '
        btnFechar_Click(sender, e)
        '
    End Sub
    '
    '
    '--- BTN EXCLUIR REGISTRO DE PEDIDO
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        '--- check pedidos migrados
        If _pedMigrados.Count > 0 Then
            AbrirDialog("Não é possível excluir um pedido que tenha outros pedidos migrados nele.",
                        "Pedidos Migrados", frmDialog.DialogType.OK, frmDialog.DialogIcon.Warning)
            Exit Sub
        End If
        '
        '--- pergunta ao usuario
        If AbrirDialog("Você realmente deseja excluir o registro de Pedido..." & vbNewLine &
                       _pedido.Fornecedor.ToUpper & vbNewLine &
                       "Data: " & _pedido.InicioData,
                       "Excluir Pedido",
                       frmDialog.DialogType.SIM_NAO,
                       frmDialog.DialogIcon.Question,
                       frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Exit Sub
        '
        '--- exclui o registro de pedido
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _pedBLL.Pedido_Excluir(_pedido.IDPedido)
            Close()
            MostraMenuPrincipal()
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir registro de Pedido..." & vbNewLine &
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
    Private Sub miImprimir_Click(sender As Object, e As EventArgs) Handles miImprimir.Click
        '
        Dim frm As New frmReportPedido(_pedido, ItensList, _MensagensList)
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        Me.Visible = False
        '
        frm.ShowDialog()
        '
        Me.Visible = True
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
    End Sub
    '
    Private Sub miEnviarPorEmail_Click(sender As Object, e As EventArgs) Handles miEnviarPorEmail.Click
        '
        Dim frm As New frmReportPedido(_pedido, ItensList, _MensagensList)
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        Me.Visible = False
        '
        frm.EnviarEmail()
        '
        Me.Visible = True
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
    End Sub
    '
#End Region
    '
#Region "BOTOES DE PROCURA"
    '
    Private Sub btnProcTransportadora_Click(sender As Object, e As EventArgs) Handles btnProcTransportadora.Click
        Dim frmT As New frmTransportadoraProcurar(True, Me)
        Dim oldID As Integer? = _pedido.IDTransportadora
        '
        frmT.ShowDialog()
        If frmT.DialogResult = DialogResult.Cancel Then
            _pedido.IDTransportadora = Nothing
            _pedido.Transportadora = String.Empty
            _pedido.TelefoneATransportadora = String.Empty
        Else
            _pedido.IDTransportadora = frmT.propTransportadora_Escolha.IDPessoa
            _pedido.Transportadora = frmT.propTransportadora_Escolha.Cadastro
            _pedido.TelefoneATransportadora = frmT.propTransportadora_Escolha.TelefoneA
        End If
        '
        '--- ler os valores e incluir nos campos
        txtTransportadora.DataBindings("Text").ReadValue()
        txtTelefoneATransportadora.DataBindings("Text").ReadValue()
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_pedido.IDTransportadora), 0, _pedido.IDTransportadora) Then
                Sit = EnumFlagEstado.Alterado
            End If
        End If
        '
        txtTransportadora.Focus()
        '
    End Sub
    '
    Private Sub btnProcFornecedores_Click(sender As Object, e As EventArgs) Handles btnProcFornecedores.Click
        '
        Dim frmF As New frmFornecedorProcurar(True, Me)
        Dim oldIDFornecedor As Integer? = _pedido.IDFornecedor
        '
        frmF.ShowDialog()
        If frmF.DialogResult = DialogResult.Cancel Then
            _pedido.Fornecedor = String.Empty
            _pedido.IDFornecedor = Nothing
            _pedido.TelefoneContato = String.Empty
            _pedido.VendedorNome = String.Empty
            _pedido.EmailVendas = String.Empty
        Else
            _pedido.Fornecedor = frmF.propFornecedor_Escolha.Cadastro
            _pedido.IDFornecedor = frmF.propFornecedor_Escolha.IDPessoa
            _pedido.TelefoneContato = frmF.propFornecedor_Escolha.TelefoneA
            _pedido.VendedorNome = frmF.propFornecedor_Escolha.Vendedor
            _pedido.EmailVendas = frmF.propFornecedor_Escolha.EmailVendas
        End If
        '
        txtFornecedor.DataBindings("text").ReadValue()
        txtEmailVendas.DataBindings("text").ReadValue()
        txtVendedorNome.DataBindings("text").ReadValue()
        txtTelefoneContato.DataBindings("text").ReadValue()
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            If IIf(IsNothing(oldIDFornecedor), 0, oldIDFornecedor) <> IIf(IsNothing(_pedido.IDFornecedor), 0, _pedido.IDFornecedor) Then
                Sit = EnumFlagEstado.Alterado
            End If
        End If
        '
        txtFornecedor.Focus()
        '
    End Sub
    '
#End Region
    '
#Region "SALVAR REGISTRO"
    '
    ' SALVAR O REGISTRO
    '---------------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- verifica os dados se os campos estão preechidos
        If VerificaDados() = False Then Exit Sub
        '
        '--- define os dados da classe
        Dim NewID As Long
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Salva mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
            If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
                NewID = _pedBLL.Pedido_Inserir(_pedido)
            ElseIf Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
                NewID = _pedBLL.Pedido_Alterar(_pedido)
            End If
        Catch ex As Exception
            MessageBox.Show("Um erro ocorreu ao salvar o registro!" & vbCrLf &
                            ex.Message, "Erro ao Salvar Registro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        '--- Verifica se houve Retorno da Função de Salvar
        If IsNumeric(NewID) AndAlso NewID <> 0 Then
            '
            '--- Retorna o número de Registro
            If Sit = EnumFlagEstado.NovoRegistro Then
                _pedido.IDPedido = NewID
                lblID.DataBindings("Tag").ReadValue()
                '
                '--- get Mensagens Padrao
                ObterMensagensPadrao()
                '
            End If
            '
            '--- Altera a Situação
            bindPedido.EndEdit()
            bindPedido.CurrencyManager.Refresh()
            Sit = EnumFlagEstado.RegistroSalvo
            '
            '--- Mensagem de Sucesso:
            MsgBox("Registro Salvo com sucesso!", vbInformation, "Registro Salvo")
        Else
            MsgBox("Registro NÃO pôde ser salvo!", vbInformation, "Erro ao Salvar")
        End If
        '
    End Sub
    '
    ' FAZER VERIFICAÇÃO ANTES DE SALVAR
    Private Function VerificaDados() As Boolean
        EProvider.Clear()
        '
        Dim f As New Utilidades
        '
        If Not f.VerificaControlesForm(txtFornecedor, "Fornecedor", EProvider) Then
            Return False
        End If
        '
        Return True
        '
    End Function
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    '--- HANDLER TODOS OS CONTROLES: SELECIONA TEXT | CONVERT ENTER EM TAB
    Private Sub AddHandlerControles()
        '
        For Each c As Control In Me.Controls
            '
            If c.HasChildren Then
                For Each cp As Control In c.Controls
                    If TypeOf cp Is TextBox Then
                        AddHandler cp.GotFocus, AddressOf SelTodoTexto
                        AddHandler cp.KeyDown, AddressOf EnterForTab
                    ElseIf TypeOf cp Is MaskedTextBox Then
                        AddHandler cp.GotFocus, AddressOf SelTodoTexto
                    ElseIf TypeOf cp Is CheckBox Then
                        AddHandler cp.KeyDown, AddressOf EnterForTab
                    End If
                Next
            Else
                If TypeOf c Is TextBox Then
                    AddHandler c.GotFocus, AddressOf SelTodoTexto
                    AddHandler c.KeyDown, AddressOf EnterForTab
                ElseIf TypeOf c Is MaskedTextBox Then
                    AddHandler c.GotFocus, AddressOf SelTodoTexto
                    AddHandler c.KeyDown, AddressOf EnterForTab
                End If
            End If
            '
        Next
        '
    End Sub
    '
    ' HANDLER SELECIONAR TODO O TEXTO
    Private Sub SelTodoTexto(sender As Object, e As EventArgs)
        '
        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).SelectAll()
        ElseIf sender.GetType = GetType(MaskedTextBox) Then
            DirectCast(sender, MaskedTextBox).SelectAll()
        End If
        '
    End Sub
    '
    ' HANDLER SUPRIMIR A TECLA ENTER
    Private Sub EnterForTab(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {"txtFornecedor", "txtTransportadora"}
            '
            If controlesBloqueados.Contains(ActiveControl.Name) Then
                e.Handled = True
            End If
            '
        End If
        '
    End Sub
    '
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFornecedor.KeyDown,
        txtTransportadora.KeyDown, txtTelefoneATransportadora.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtFornecedor"
                    btnProcFornecedores_Click(New Object, New EventArgs)
                Case "txtTransportadora"
                    btnProcTransportadora_Click(New Object, New EventArgs)
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtFornecedor"
                    If Not IsNothing(_pedido.IDPedido) Then Sit = EnumFlagEstado.Alterado
                    txtFornecedor.Clear()
                    _pedido.IDFornecedor = Nothing
                Case "txtTransportadora"
                    If Not IsNothing(_pedido.IDPedido) Then Sit = EnumFlagEstado.Alterado
                    txtTransportadora.Clear()
                    _pedido.IDTransportadora = Nothing
            End Select
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({"txtTransportadora", "txtTelefoneATransportadora"})
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
    Public Function AtualizaTotalGeral() As Decimal
        '
        If ItensList.Count > 0 Then
            Dim T As Double = 0
            '
            T = ItensList.Sum(Function(x) x.SubTotal)
            _pedido.TotalPedido = T
            lblValorTotal.Text = Format(T, "c")
            '
            Return T
        Else
            _pedido.TotalPedido = 0
            lblValorTotal.Text = Format(0, "c")
            Return 0
        End If
        '
    End Function
    '
    '--- PRESSIONA FORÇA A ABERURA DO MENU
    Private Sub tsbButtonClick(sender As Object, e As EventArgs) Handles btnVerificarAdicionar.ButtonClick
        '
        DirectCast(sender, ToolStripSplitButton).ShowDropDown()
        '
    End Sub
    '
#End Region
    '
#Region "ALTERA TAMANHO DO FORM"
    '
    Private Sub AlteraTamanhoForm(ampliado As Boolean)
        '
        Dim tm As New Timer
        '
        tm.Interval = 1
        AddHandler tm.Tick, AddressOf DisparaAlteraTamanho
        tm.Start()
        '
    End Sub
    '
    Private Sub DisparaAlteraTamanho(sender As Object, e As EventArgs)
        '
        If _formAmpliado = True Then
            If Me.Height < fHeight Then
                Me.Top -= 8
                Me.Height += 16
            Else
                Me.Height = fHeight
                tabPrincipal.Visible = True
                DirectCast(sender, Timer).Stop()
                DirectCast(sender, Timer).Dispose()
            End If
        Else
            tabPrincipal.Visible = False
            If Me.Height >= 210 Then
                Me.Top += 8
                Me.Height -= 16
            Else
                DirectCast(sender, Timer).Stop()
                DirectCast(sender, Timer).Dispose()
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "PREENCHE DATAGRID MENSAGENS"
    '
    '--- RETORNA TODOS OS ITENS DA VENDA
    Private Sub GetMensagens()
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _MensagensList = _pedBLL.GetPedidoMensagens_IDPedido_List(_pedido.IDPedido)
            bindMensagem.DataSource = _MensagensList
            '
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter as Mensagens do Pedido:" & vbNewLine &
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
    Private Sub PreencheMensagens()
        '
        '--- limpa as colunas do datagrid
        dgvMensagens.Columns.Clear()
        dgvMensagens.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvMensagens.MultiSelect = False
        dgvMensagens.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        dgvMensagens.ColumnHeadersVisible = True
        dgvMensagens.AllowUserToResizeRows = False
        dgvMensagens.AllowUserToResizeColumns = True
        'dgvMensagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvMensagens.RowHeadersVisible = True
        dgvMensagens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvMensagens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvMensagens.StandardTab = True
        '
        dgvMensagens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgvMensagens.RowHeadersWidth = rowHeight
        dgvMensagens.RowTemplate.Height = rowHeight
        dgvMensagens.RowTemplate.MinimumHeight = rowHeight
        '
        '--- configura o DataSource
        dgvMensagens.DataSource = bindMensagem
        '
        '--- formata as colunas do datagrid
        FormataColunas_Mensagens()
        '
    End Sub
    '
    Private Sub FormataColunas_Mensagens()
        '
        ' (0) COLUNA Mensagem/Avisos
        With clnMensagem
            .DataPropertyName = "Mensagem"
            .HeaderText = "Avisos | Mensagens"
            .Width = 550
            .Resizable = DataGridViewTriState.True
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (1) COLUNA IDPedidoMensagem
        With clnIDMensagem
            .DataPropertyName = "IDPedidoMensagem"
            .Width = 0
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        '--- adiciona as colunas editadas
        dgvMensagens.Columns.AddRange(New DataGridViewColumn() {clnMensagem, clnIDMensagem})
        '
    End Sub
    '
#End Region
    '
#Region "EDICAO DATAGRID MENSAGENS"
    '
    '--- VALIDA O ROW E INSERE/ALTERA O MENSAGEM DO PEDIDO
    Private Sub dgvMensagens_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvMensagens.RowValidating
        '
        '--- verifica se é um ROW editado ou novo
        Dim mySit As EnumFlagEstado
        Dim myMsn As clPedidoMensagem = DirectCast(dgvMensagens.Rows(e.RowIndex).DataBoundItem, clPedidoMensagem)
        '
        If IsNothing(myMsn) Then Exit Sub
        '
        If Not myMsn.IDPedidoMensagem Is Nothing Then
            If dgvMensagens.IsCurrentRowDirty Then
                mySit = EnumFlagEstado.Alterado
            Else
                mySit = EnumFlagEstado.RegistroSalvo
            End If
        Else
            mySit = EnumFlagEstado.NovoRegistro
        End If
        '
        '--- Verifica os valores inseridos
        If dgvMensagens.CurrentRow.Cells("clnMensagem").Value.ToString.Trim.Length = 0 Then
            e.Cancel = True
        Else
            If mySit = EnumFlagEstado.NovoRegistro Then
                '
                Try
                    myMsn.IDPedido = _pedido.IDPedido
                    '
                    MensagemInserir(myMsn)
                    bindMensagem.EndEdit()
                Catch ex As Exception
                    bindMensagem.CancelEdit()
                End Try
                '
            ElseIf mySit = EnumFlagEstado.Alterado Then
                '
                Try
                    MensagemAlterar(myMsn)
                    bindMensagem.EndEdit()
                Catch ex As Exception
                    bindMensagem.CancelEdit()
                End Try
                '
            End If
            '
            bindMensagem.EndEdit()
            '
        End If
        '
        '
    End Sub
    '
    '--- INSERE NOVA MENSAGEM NO PEDIDO
    Private Function MensagemInserir(myMsn As clPedidoMensagem) As Integer
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim myM As Object = _pedBLL.PedidoMensagem_Inserir(myMsn)
            '
            If IsNumeric(myM) Then
                myMsn.IDPedidoMensagem = myM
                Return myM
            Else
                Throw New Exception(myM.ToString)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção ao inserir uma nova Mensagem no Pedido" & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
    '--- ALTERA ITEM NO PEDIDO
    Private Function MensagemAlterar(myItem As clPedidoMensagem) As Integer
        '
        Try
            Dim myI As Object = _pedBLL.PedidoMensagem_Alterar(myItem)
            '
            If IsNumeric(myI) Then
                Return myI
            Else
                Throw New Exception(myI.ToString)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção ao ALTERAR a Mensagem do Pedido" & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        '
    End Function
    '
    '--- AO EXCLUIR O ITEM DO PEDIDO
    Private Sub dgvMensagens_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvMensagens.UserDeletingRow
        '
        Dim delItem As clPedidoMensagem = e.Row.DataBoundItem
        '
        '--- verifica se existe numero de IDPedidoItem
        If IsNothing(delItem.IDPedidoMensagem) Then
            e.Cancel = True
            Return
        End If
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você realmente deseja excluir a mensagem: '" & vbNewLine & delItem.Mensagem & "' ?",
                           "Excluir Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
            Return
        End If
        '
        '--- exclui o registro no BD
        '
        Try
            '
            _pedBLL.PedidoMensagem_Excluir(delItem.IDPedidoMensagem)
            e.Cancel = False
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao excluir a mensagem do pedido:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End Try
        '
    End Sub
    '
    ' PROCURAR E OBTER MENSAGENS PADRAO DO CONFIG XML
    '-----------------------------------------------------------------------------------------------
    Private Function ObterMensagensPadrao() As Boolean
        Dim myXML As New XmlDocument
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            myXML.Load(Application.StartupPath & "\ConfigFiles\Config.xml")
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu na tentativa de abrir abrir o CONFIG XML", "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        '--- verifica se existe node MENSAGEM PEDIDO
        Dim elemList As XmlNodeList = myXML.GetElementsByTagName("MensagemPedido")
        '
        '--- se não existir o node PAI entao cria
        If elemList.Count = 0 Then
            'Create a new node.
            Dim newNodeOrigem As XmlElement = myXML.CreateElement("MensagemPedido")
            myXML.SelectSingleNode("Configuracao").SelectSingleNode("PedidoConfig").AppendChild(newNodeOrigem)
        End If
        '
        Dim node As XmlNode = myXML.SelectSingleNode("Configuracao").SelectSingleNode("PedidoConfig").SelectSingleNode("MensagemPedido")
        '
        If Not node.HasChildNodes Then
            MessageBox.Show("Não há nenhuma mensagem padrão salva...", "Obter Mensagem Padrão",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If
        '
        For Each m As XmlNode In node.ChildNodes
            '
            Dim newMensag As New clPedidoMensagem
            '
            newMensag.IDPedido = _pedido.IDPedido
            newMensag.Mensagem = m.InnerText
            '
            MensagemInserir(newMensag)
            _MensagensList.Add(newMensag)
            '
        Next
        '
        GetMensagens()
        Return True
        '
    End Function
    '
    '--- BTN OBTER MENSAGENS PADRAO
    Private Sub btnMensagemPadrao_Click(sender As Object, e As EventArgs) Handles btnMensagemPadrao.Click
        ObterMensagensPadrao()
    End Sub
    '
#End Region
    '
#Region "VERIFICACAO DE ESTOQUE E DE RESERVAS"
    '
    '==========================================================================================
    ' PROCURAR ITEM: PELO ESTOQUE | PELO TIPO DO PRODUTO
    '==========================================================================================
    Private Sub miPeloEstoquePorTipo_Click(sender As Object, e As EventArgs) Handles miPeloEstoquePorTipo.Click
        '
        Dim form As New frmProdutoProcurarTipo(Me)
        '
        form.ShowDialog()
        If form.DialogResult <> DialogResult.OK Then Exit Sub
        '
        Dim IDTipo As Integer = form.propIdTipo_Escolha
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newItems As List(Of clPedidoItem) = _pedBLL.VerificaProdutoEstoqueTipo(IDTipo, _pedido)
            '
            If newItems.Count = 0 Then
                AbrirDialog("Não há produtos desse TIPO que estejam abaixo do Estoque Nível...",
                            "Nenhum produto selecionado",
                            frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Exit Sub
            End If
            '
            Dim formSelecionados As New frmPedidoItemsEncontrados(newItems, False, "pelo Tipo", Me)
            formSelecionados.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao pesquisar e inserir produtos no pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' PROCURAR ITEM: PELO ESTOQUE | PELO FABRICANTE DO PRODUTO
    '==========================================================================================
    Private Sub miPeloEstoquePorFabricante_Click(sender As Object, e As EventArgs) Handles miPeloEstoquePorFabricante.Click
        '
        Dim form As New frmFabricanteProcurar(Me)
        '
        form.ShowDialog()
        If form.DialogResult <> DialogResult.OK Then Exit Sub
        '
        Dim IDFabricante As Integer = form.propIDFab_Escolha
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newItems As List(Of clPedidoItem) = _pedBLL.VerificaProdutoEstoqueFabricante(IDFabricante, _pedido)
            '
            If newItems.Count = 0 Then
                AbrirDialog("Não há produtos desse FABRICANTE que estejam abaixo do Estoque Nível...",
                            "Nenhum produto selecionado",
                            frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Exit Sub
            End If
            '
            Dim formSelecionados As New frmPedidoItemsEncontrados(newItems, False, "pelo Fabricante", Me)
            formSelecionados.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao pesquisar e inserir produtos no pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' PROCURAR ITEM: PELO ESTOQUE | PELO FORNECEDOR DO PRODUTO
    '==========================================================================================
    Private Sub miPeloEstoquePorFornecedor_Click(sender As Object, e As EventArgs) Handles miPeloEstoquePorFornecedor.Click
        '
        If IsNothing(_pedido.IDFornecedor) OrElse _pedido.IDFornecedor = 0 Then
            AbrirDialog("Como esse Pedido não tem um Fornecedor já cadastrado não é possível verificar os produtos pelo Fornecedor",
                        "Fornecedor Indefinido",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newItems As List(Of clPedidoItem) = _pedBLL.VerificaProdutoEstoqueFornecedor(_pedido.IDFornecedor, _pedido)
            '
            If newItems.Count = 0 Then
                AbrirDialog("Não há produtos desse FORNECEDOR que estejam abaixo do Estoque Nível...",
                            "Nenhum produto selecionado",
                            frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Exit Sub
            End If
            '
            Dim formSelecionados As New frmPedidoItemsEncontrados(newItems, False, "pelo Fornecedor", Me)
            formSelecionados.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao pesquisar e inserir produtos no pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' PROCURAR ITEM: PELA RESERVA | PELO FORNECEDOR DO PRODUTO
    '==========================================================================================
    Private Sub miPelaReservaPorFornecedor_Click(sender As Object, e As EventArgs) Handles miPelaReservaPorFornecedor.Click
        '
        If IsNothing(_pedido.IDFornecedor) OrElse _pedido.IDFornecedor = 0 Then
            AbrirDialog("Como esse Pedido não tem um Fornecedor já cadastrado não é possível verificar os produtos pelo Fornecedor",
                        "Fornecedor Indefinido",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Get List by INSERTED Fornecedor in Reserva
            Dim newItems As List(Of clPedidoItem) = _pedBLL.VerificaProdutoReservaFornecedor(_pedido.IDFornecedor, _pedido)
            '
            '--- Get List by Reserva Produto Fornecedor SECUNDARIO
            Dim lstFornSec As IList(Of clPedidoItem) = _pedBLL.VerificaProdutoReservaFornecedorSecundario(_pedido.IDFornecedor, _pedido)
            '
            '--- check if exists duplicated Items on both lists
            If lstFornSec.Count > 0 Then
                For Each item As clPedidoItem In lstFornSec
                    '
                    If newItems.Where(Function(x) x.IDProduto = item.IDProduto).Count = 0 Then
                        newItems.Add(item)
                    End If
                    '
                Next
            End If
            '
            If newItems.Count = 0 Then
                AbrirDialog("Não há produtos desse FORNECEDOR em Reserva...",
                            "Nenhum produto selecionado",
                            frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Exit Sub
            End If
            '
            Dim formSelecionados As New frmPedidoItemsEncontrados(newItems, True, "pelo Fornecedor", Me)
            formSelecionados.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao pesquisar e inserir produtos no pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' PROCURAR ITEM: PELA RESERVA | PELO TIPO DO PRODUTO
    '==========================================================================================
    Private Sub miPelaReservaPorTipo_Click(sender As Object, e As EventArgs) Handles miPelaReservaPorTipo.Click
        '
        Dim IDTipo As Integer
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim form As New frmProdutoProcurarTipo(Me)
            '
            form.ShowDialog()
            If form.DialogResult <> DialogResult.OK Then Exit Sub
            '
            IDTipo = form.propIdTipo_Escolha
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir procura de tipo..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newItems As List(Of clPedidoItem) = _pedBLL.VerificaProdutoReservaTipo(IDTipo, _pedido)
            '
            If newItems.Count = 0 Then
                AbrirDialog("Não há produtos desse TIPO em Reserva...",
                            "Nenhum produto selecionado",
                            frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Exit Sub
            End If
            '
            Dim formSelecionados As New frmPedidoItemsEncontrados(newItems, True, "pelo Tipo", Me)
            formSelecionados.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao pesquisar e inserir produtos no pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' PROCURAR ITEM: PELA RESERVA | PELO FABRICANTE DO PRODUTO
    '==========================================================================================
    Private Sub miPelaReservaPorFabricante_Click(sender As Object, e As EventArgs) Handles miPelaReservaPorFabricante.Click
        '
        Dim IDFabricante As Integer
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim form As New frmFabricanteProcurar(Me)
            '
            form.ShowDialog()
            If form.DialogResult <> DialogResult.OK Then Exit Sub
            '
            IDFabricante = form.propIDFab_Escolha
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir procura de Fabricante..." & vbNewLine &
                             ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newItems As List(Of clPedidoItem) = _pedBLL.VerificaProdutoReservaFabricante(IDFabricante, _pedido)
            '
            If newItems.Count = 0 Then
                AbrirDialog("Não há produtos desse FABRICANTE em Reserva...",
                            "Nenhum produto selecionado",
                            frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                Exit Sub
            End If
            '
            Dim formSelecionados As New frmPedidoItemsEncontrados(newItems, True, "pelo Fabricante", Me)
            formSelecionados.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao pesquisar e inserir produtos no pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' PROCURAR PRODUTOS VINCULADOS AO FORNECEDOR
    '==========================================================================================
    Private Sub miFornecedorProdutos_Click(sender As Object, e As EventArgs) Handles btnProdutosFornecedor.Click
        '
        If IsNothing(_pedido.IDFornecedor) OrElse _pedido.IDFornecedor = 0 Then
            AbrirDialog("Ainda não existe nenhum Fornecedor relacionado ao pedido.",
                        "Sem Fornecedor",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim forn As New clFornecedor With {
                .IDPessoa = _pedido.IDFornecedor,
                .Cadastro = _pedido.Fornecedor}
            '
            Dim form As New frmFornecedorProdutos(forn, Me)
            form.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '/ VERIFICACAO DE ESTOQUE E DE RESERVAS
    '
#Region "IMPORTACAO | EXPORTACAO XML PEDIDOS"
    '
    Private Sub miExportarItens_Click(sender As Object, e As EventArgs) Handles miExportarItens.Click
        '
        '--------------------------------------------------------------------------------------
        AbrirDialog("Essa operação só é permitida em Banco de Dados locais...",
                    "Operação não permitida",
                    frmDialog.DialogType.OK,
                    frmDialog.DialogIcon.Warning)
        Return
        '--------------------------------------------------------------------------------------
        '
        '--- verifica se existem itens no pedido
        If ItensList.Count = 0 Then
            MessageBox.Show("O pedido ainda não tem nenhum item inserido..." & vbNewLine &
                            "Não possível criar arquivo de exportação sem produtos.",
                            "Pedido Vazio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        '
        '--- pergunta a pasta
        Dim pasta As New FolderBrowserDialog
        pasta.Description = "Informe onde o arquivo de exportação XML do pedido será salvo..."
        pasta.ShowDialog()
        '
        If String.IsNullOrEmpty(pasta.SelectedPath) Then Return
        '
        '--- cria o arquivo XML na pasta e envia mensagem ao usuario
        If CriaExportacaoXML(pasta.SelectedPath) = True Then
            Dim xmlName As String = "Pedido_exp_" & Format(_pedido.IDPedido, "0000") & ".xml"
            MessageBox.Show("Arquivo de exportação criado com sucesso..." & vbNewLine &
                            "Nome do arquivo: " & vbNewLine & xmlName,
                            "Exporta Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
    End Sub
    '
    ' CRIA ARQUIVO XML DE EXPORTACAO
    '-----------------------------------------------------------------------------------------------
    Private Function CriaExportacaoXML(pasta As String) As Boolean
        '
        '--- Verifica se ja existe arquivo de exportacao criado com o mesmo nome
        Dim xmlName As String = "Pedido_exp_" & Format(_pedido.IDPedido, "0000") & ".xml"
        Dim xmlCaminhoCompleto = pasta & "\" & xmlName
        '
        If IO.File.Exists(xmlCaminhoCompleto) Then
            IO.File.Delete(xmlCaminhoCompleto)
        End If
        '
        Try
            Dim writer As New XmlTextWriter(xmlCaminhoCompleto, Nothing)
            '
            With writer
                .WriteStartDocument()
                '
                'define a indentação do arquivo
                .Formatting = Formatting.Indented
                .WriteStartElement("Pedido")
                .WriteAttributeString("Importado", "0")

                ' Primeira Seção: DADOS PRINCIPAIS
                '----------------------------------------------------------------------------------
                .WriteStartElement("Principal")
                ' Sub Elementos
                .WriteElementString("IDPedido", _pedido.IDPedido)
                .WriteElementString("IDFilial", _pedido.IDFilial)
                .WriteElementString("ApelidoFilial", _pedido.ApelidoFilial)
                .WriteElementString("IDFornecedor", _pedido.IDFornecedor)
                .WriteElementString("Fornecedor", _pedido.Fornecedor)
                'encerra o elemento
                .WriteEndElement()
                '
                ' Segunda Seção: PRODUTOS
                '----------------------------------------------------------------------------------
                .WriteStartElement("Produtos")
                Dim us As New Globalization.CultureInfo("en-US")

                For Each i As clPedidoItem In ItensList
                    '
                    .WriteStartElement("Item")
                    .WriteAttributeString("IDPedidoItem", i.IDPedidoItem)
                    ' Sub Elementos
                    '.WriteElementString("IDPedidoItem", i.IDPedidoItem)
                    .WriteElementString("Produto", i.Produto)
                    .WriteElementString("IDPedido", i.IDPedido)
                    .WriteElementString("IDProduto", i.IDProduto)
                    .WriteElementString("RGProduto", i.RGProduto)
                    .WriteElementString("IDProdutoTipo", i.IDProdutoTipo)
                    .WriteElementString("ProdutoTipo", i.ProdutoTipo)
                    .WriteElementString("Autor", i.Autor)
                    .WriteElementString("Quantidade", i.Quantidade)
                    .WriteElementString("Preco", i.Preco.ToString(us))
                    .WriteElementString("Desconto", i.Desconto.ToString(us))
                    '
                    .WriteEndElement()
                Next
                '
                'encerra o elemento
                .WriteEndElement()
                '
                'escreve o xml para o arquivo e fecha o objeto escritor
                .WriteEndElement()
                .Close()
                '
                Return True
                '
            End With
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao criar o arquivo XML de exportação..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            '
        End Try
        '
    End Function
    '
    Private Sub miImportarItens_Click(sender As Object, e As EventArgs) Handles miImportarItens.Click
        '
        '--------------------------------------------------------------------------------------
        AbrirDialog("Essa operação só é permitida em Banco de Dados locais...",
                    "Operação não permitida",
                    frmDialog.DialogType.OK,
                    frmDialog.DialogIcon.Warning)
        Return
        '--------------------------------------------------------------------------------------
        '
        '--- verifica se a situacao do pedido
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Não é possível importar pedido em um pedido que ainda não foi salvo...",
                            "Importar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        '--- pergunta o nome do arquivo
        Dim arquivoXML As New OpenFileDialog
        With arquivoXML
            .AddExtension = True
            .DefaultExt = ".xml"
            .DereferenceLinks = True
            .Filter = "xml files (*.xml)|*.xml"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            .Title = "Informe onde o arquivo de exportação XML do pedido será salvo..."
            .Multiselect = False
            .RestoreDirectory = True
            .ShowDialog()
        End With
        '
        If String.IsNullOrEmpty(arquivoXML.FileName) Then Return
        '
        '--- valida o arquivo XML
        Dim validacao As New ValidaXML
        If validacao.ValidaXML(arquivoXML.FileName, "ConfigFiles\pedido.xsd") = False Then Return

        '--- cria o arquivo XML na pasta e envia mensagem ao usuario
        If ImportaPedidoXML(arquivoXML.FileName) = True Then
            '
            '--- Registra importacao na observacao do pedido
            Dim strObs As String = "Importação do Pedido --> " + _strPedidoImportado
            _pedido.Observacao = _pedido.Observacao + IIf(_pedido.Observacao.Length > 0, vbNewLine, "") + strObs
            '
            Dim xmlName As String = arquivoXML.SafeFileName
            MessageBox.Show("Arquivo de Pedido importado com sucesso..." & vbNewLine &
                            "Nome do arquivo: " & vbNewLine & xmlName,
                            "Importar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
    End Sub
    '
    Private Function ImportaPedidoXML(arquivoXML As String) As Boolean
        '
        Dim PedidoOrigem As Integer? = Nothing
        Dim ApelidoFilial As String = ""
        '
        Dim myXML As New XmlDocument
        myXML.Load(arquivoXML)
        '
        With myXML.SelectSingleNode("Pedido")
            '
            '--- verifica se o Pedido já foi importado
            If .Attributes("Importado").InnerText = "1" Then
                MessageBox.Show("O Pedido que você deseja importar já foi importado por outro pedido..." +
                                vbNewLine + vbNewLine +
                                "Arquivo XML já foi importado",
                                "Bloqueado para importação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            '--- verifica se o Pedido tem origem de outra Filial
            If .SelectSingleNode("Principal").SelectSingleNode("IDFilial").InnerText = _pedido.IDFilial Then
                MessageBox.Show("O Pedido que você deseja importar não pode ter origem na mesma filial do pedido de destino..." +
                                vbNewLine + vbNewLine +
                                "Filial: " & _pedido.ApelidoFilial.ToUpper +
                                vbNewLine + vbNewLine +
                                "Arquivo XML não pôde ser importado",
                                "Mesma Filial de Origem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            '--- verifica e avisa se o Pedido é destinado ao mesmo fornecedor
            If .SelectSingleNode("Principal").SelectSingleNode("IDFornecedor").InnerText <> _pedido.IDFornecedor Then
                If MessageBox.Show("O Pedido que você deseja importar não foi direcionado para o mesmo fornecedor" +
                                   vbNewLine + vbNewLine +
                                   "Fornecedor Origem: " + .SelectSingleNode("Principal").SelectSingleNode("Fornecedor").InnerText +
                                   vbNewLine +
                                   "Fornecedor Atual: " + _pedido.Fornecedor +
                                   vbNewLine + vbNewLine +
                                   "Deseja importar o arquivo de Pedido assim mesmo?",
                                   "Fornecedor Diferente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Return False
                End If
            End If
            '
            '--- adiciona os produtos do XML
            Dim FilialOrigem As Integer = .SelectSingleNode("Principal").SelectSingleNode("IDFilial").InnerText
            PedidoOrigem = .SelectSingleNode("Principal").SelectSingleNode("IDPedido").InnerText
            ApelidoFilial = .SelectSingleNode("Principal").SelectSingleNode("ApelidoFilial").InnerText
            '
            Dim ProdutosList As XmlNodeList = .SelectSingleNode("Produtos").ChildNodes
            Dim myValor As String = ""
            '
            For Each p As XmlNode In ProdutosList
                Dim item As New clPedidoItem
                '
                item.IDPedido = _pedido.IDPedido
                item.Produto = p.SelectSingleNode("Produto").InnerText
                item.IDProduto = p.SelectSingleNode("IDProduto").InnerText
                item.RGProduto = p.SelectSingleNode("RGProduto").InnerText
                item.IDProdutoTipo = p.SelectSingleNode("IDProdutoTipo").InnerText
                item.Autor = p.SelectSingleNode("Autor").InnerText
                item.Quantidade = p.SelectSingleNode("Quantidade").InnerText
                item.Preco = p.SelectSingleNode("Preco").InnerText.Replace(".", ",")
                item.Desconto = p.SelectSingleNode("Desconto").InnerText.Replace(".", ",")
                item.IDFilialOrigem = FilialOrigem
                item.Origem = 2
                item.IDOrigem = p.Attributes(0).InnerText
                '
                Try
                    '--- adiciona ao novos itens ao BD
                    _pedBLL.PedidoItem_Inserir(item)
                Catch ex As Exception
                    MessageBox.Show("Uma exceção ocorreu ao Inserir o item no BD..." & vbNewLine &
                                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Continue For
                End Try
                '
                '--- adiciona o item a listagem
                ItensList.Add(item)
                '
                bindItens.DataSource = ItensList
                bindItens.ResetBindings(False)
                AtualizaTotalGeral()
                '
            Next
            '
        End With
        '
        '--- altera o pedido.xml para 
        myXML.SelectSingleNode("Pedido").Attributes(0).InnerText = "-1"
        myXML.Save(arquivoXML)
        '
        '--- formata o texto para inserir na observacao
        _strPedidoImportado = "FILIAL: " + ApelidoFilial + " | PEDIDO: " & Format(PedidoOrigem, "0000")
        '
        Return True
        '
    End Function
    '
#End Region
    '
End Class
