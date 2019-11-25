Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmVendaVista
    '
    Private vndBLL As New VendaBLL
    Private _Venda As clVenda
    Private _Troca As clTroca
    Private _ItensList As New List(Of clTransacaoItem)
    Private _MovEntradaList As New List(Of clMovimentacao)
    Private bindVenda As New BindingSource
    Private bindItem As New BindingSource
    Private bindEnt As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _IDFilial As Integer
    Private VerificaAlteracao As Boolean
    Property DescontoMaximo As Double
    '
    Private Parciais As New List(Of SomaParcial)
	'
	Private Class SomaParcial
		'
		Property itemInicio As Integer
		Property itemFinal As Integer
		'
		Sub New(inicio As Integer, Optional fim As Integer = 0)
			itemInicio = inicio
			If fim = 0 Then
				itemFinal = inicio
			Else
				itemFinal = fim
			End If
		End Sub
		'
	End Class
	'
#Region "NEW | PROPERTIES LOAD"
	'
	Public Sub New(myVenda As clVenda)
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		propVenda = myVenda
		'
		' Add Handler Menu Acao
		MenuOpen_AdHandler()
		'
		'--- Define a DESCONTO MAXIMO padrao
		DescontoMaximo = Obter_DescontoMaximo()
		'
	End Sub
	'
	Private Property Sit As EnumFlagEstado
        '
        Get
            Return _Sit
        End Get
        '
        Set(value As EnumFlagEstado)
            '
            _Sit = value
            Select Case _Sit
                '
                Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
                    lblSituacao.Text = "Finalizada"
                    btnFinalizar.Text = "&Fechar"
                    btnTroca.Enabled = True
                    btnLimparPagamentos.Enabled = False
                    '
                    btnVendedorAlterar.Enabled = True
                    btnData.Enabled = True
                    txtObservacao.ReadOnly = False
                    '
                    btnExcluirVenda.Enabled = True
                    btnDesbloquearVenda.Enabled = False
                    '                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    lblSituacao.Text = "Alterada"
                    btnFinalizar.Text = "&Finalizar"
                    btnTroca.Enabled = True
                    btnLimparPagamentos.Enabled = True
                    '
                    btnVendedorAlterar.Enabled = True
                    btnData.Enabled = True
                    txtObservacao.ReadOnly = False
                    '
                    btnExcluirVenda.Enabled = True
                    btnDesbloquearVenda.Enabled = False
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    lblSituacao.Text = "Em Aberto"
                    btnFinalizar.Text = "&Finalizar"
                    btnTroca.Enabled = True
                    btnLimparPagamentos.Enabled = True
                    '
                    btnVendedorAlterar.Enabled = True
                    btnData.Enabled = True
                    txtObservacao.ReadOnly = False
                    '
                    btnExcluirVenda.Enabled = True
                    btnDesbloquearVenda.Enabled = False
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    lblSituacao.Text = "Bloqueada"
                    btnFinalizar.Text = "&Fechar"
                    btnTroca.Enabled = False
                    btnLimparPagamentos.Enabled = False
                    '
                    btnVendedorAlterar.Enabled = False
                    btnData.Enabled = False
                    txtObservacao.ReadOnly = True
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
            obterPagamentos()
            bindItem.DataSource = _ItensList
            bindEnt.DataSource = _MovEntradaList
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
                'AddHandler _ClientePF.AoAlterar, AddressOf HandlerAoAlterar
            End If
            '
            '--- Preenche os Itens da Venda
            PreencheItens()
            '
            '--- Preenche Itens do A Receber (parcelas)
            Preenche_Pagamentos()
            '
            '--- Verifica se a FilialPadrão = PessoaOrigem se não bloqueia alterações
            If _Venda.IDPessoaOrigem <> Obter_FilialPadrao() Then
                MessageBox.Show("A configuração da Filial Padrão atual não coincide" & vbNewLine &
                                "com a Filial ao qual pertence essa Venda..." & vbNewLine &
                                "Assim, não é possível realizar alterações nessa venda.",
                                "Filial Divergente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Sit = EnumFlagEstado.RegistroBloqueado
            Else
                '--- Atualiza o estado da Situacao: FLAGESTADO
                Select Case _Venda.IDSituacao
                    Case 1 ' VENDA INICIADA
                        Sit = EnumFlagEstado.NovoRegistro
                    Case 2 ' VENDA FINALIZADA
                        Sit = EnumFlagEstado.RegistroSalvo
                    Case 3 ' VENDA BLOQUEADA
                        Sit = EnumFlagEstado.RegistroBloqueado
                    Case Else
                End Select
            End If
            '
            '--- Check Consistency
            CheckConsistency()
            '
            '--- Verifica o TotalGeral
            AtualizaTotalGeral()
            '
            '--- Permite a verificacao dos campos IDPlano
            VerificaAlteracao = True
            '
            ' ADD HANDLER PARA DATABINGS
            AddHandler _Venda.AoAlterar, AddressOf HandlerAoAlterar
            '
        End Set
        '
    End Property

    Private Sub CheckConsistency()
        '
        '--- Check Situation SIT property

        '
        '--- Check Products Values and VendaTotal Value

        '
        '--- Check Payment Values and VendaTotal Value

        '
        'Throw New NotImplementedException()
        '
    End Sub
	'
#End Region ' / LOAD
	'
#Region "DATABINDING"
	'
	Private Sub PreencheDataBinding()
        '
        lblIDVenda.DataBindings.Add("Text", bindVenda, "IDVenda", True, DataSourceUpdateMode.OnPropertyChanged)
        lblVendaData.DataBindings.Add("Text", bindVenda, "TransacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        lblVendedor.DataBindings.Add("Text", bindVenda, "ApelidoFuncionario", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindVenda, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindVenda, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTotalGeral.DataBindings.Add("Text", bindVenda, "TotalVenda", True, DataSourceUpdateMode.OnPropertyChanged)
        lblValorDevolucao.DataBindings.Add("Text", bindVenda, "ValorDevolucao", True, DataSourceUpdateMode.OnPropertyChanged)
		lblValorProdutos.DataBindings.Add("Text", bindVenda, "ValorProdutos", True, DataSourceUpdateMode.OnPropertyChanged)
		lblClienteSimplesNome.DataBindings.Add("Text", bindVenda, "ClienteSimplesNome", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
		lblClienteSimplesNome.DataBindings.Add("Tag", bindVenda, "IDClienteSimples", True, DataSourceUpdateMode.OnPropertyChanged, Nothing)
		'
		' FORMATA OS VALORES DO DATABINDING
		AddHandler lblIDVenda.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler lblVendaData.DataBindings("text").Format, AddressOf FormatDT
        AddHandler lblTotalGeral.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler lblValorDevolucao.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler lblValorProdutos.DataBindings("Text").Format, AddressOf FormatCUR
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
	Private Sub FormatCliente(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
		If e.Value = "" Then
			e.Value = "Cliente Varejo"
		End If
	End Sub
	'
#End Region ' / DATABINDINGS
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
    '--- RETORNA TODOS OS ITENS DA VENDA
    Private Sub obterItens()
        '
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
        '
        Dim newItem As New clTransacaoItem
        Dim fItem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_VENDA, _IDFilial, newItem)
        fItem.ShowDialog()
        '
        '--- Verifica o retorno do Dialog
        If Not fItem.DialogResult = DialogResult.OK Then Exit Sub
        '
        '--- Insere o novo ITEM no BD
        '--------------------------------------------------------
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
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
        '--------------------------------------------------------
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
        Dim itmAtual As clTransacaoItem = dgvItens.SelectedRows(0).DataBoundItem
        '
        '--- Abre o frmItem
        Dim fitem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_VENDA, _IDFilial, itmAtual)
        fitem.ShowDialog()
        '
        '--- Verifica o retorno do Dialog
        If Not fitem.DialogResult = DialogResult.OK Then Exit Sub
        '
        '--- Altera o ITEM no BD e reforma o ESTOQUE
        '-------------------------------------------------------------------------
        Dim ItemBLL As New TransacaoItemBLL
        Dim myID As Long? = Nothing
        '
        Try
            itmAtual.IDTransacao = _Venda.IDVenda
            myID = ItemBLL.EditarItem(itmAtual,
                                      TransacaoItemBLL.EnumMovimento.SAIDA,
                                      _Venda.TransacaoData,
                                      InsereCustos:=False
                                      )
            itmAtual.IDTransacaoItem = myID
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao ALTERAR o item no BD..." & vbNewLine & ex.Message,
                            "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        '--- Atualiza o ITEM da lista
        '--------------------------------------------------------
        '_ItensList.Item(i) = Item
        bindItem.ResetBindings(False)
        ParcialRecalcula(_ItensList.IndexOf(itmAtual))
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
        '--------------------------------------------------------
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
        '--------------------------------------------------------
        _ItensList.RemoveAt(i)
        ParcialRemoverItem(i)
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
#End Region '/ CARREGA/INSERE ITENS
    '
#Region "MENU CONTEXTO"
    '
    Private Sub dgvItens_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
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
            'mnuContexto.Show(dgvItens, c.PointToScreen(e.Location))
            mnuContexto.Show(dgvItens, e.Location)
            '
        End If
    End Sub
    '
    Private Sub MenuItemEditar_Click(sender As Object, e As EventArgs) Handles mnuItemEditar.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Editar_Item()
        Else
            Pagamentos_Editar()
        End If
        '
    End Sub
    '
    Private Sub MenuItemInserir_Click(sender As Object, e As EventArgs) Handles mnuItemInserir.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Inserir_Item()
        Else
            Pagamentos_Adicionar()
        End If
        '
    End Sub
    '
    Private Sub MenuItemExcluir_Click(sender As Object, e As EventArgs) Handles mnuItemExcluir.Click
        '
        If mnuContexto.SourceControl.Name = "dgvItens" Then
            Excluir_Item()
        Else
            Pagamentos_Excluir()
        End If
        '
    End Sub
    '
#End Region '/ MENU CONTEXTO
    '
#Region "BOTOES DE ACAO"
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If Sit = EnumFlagEstado.NovoRegistro Or Sit = EnumFlagEstado.Alterado Then
            Dim vlReceber As Double = AtualizaTotalPago()
            '
            If vlReceber > 0 Then
                '--- Verifica se o valor da venda é igual à soma das parcelas
                If Math.Abs(AtualizaTotalGeral() - AtualizaTotalPago()) > 1 Then
                    If Not CanCloseMessage() Then Exit Sub
                End If
            End If
        End If
        '
        Close()
        MostraMenuPrincipal()
    End Sub
	'
	'--- ALTERA O VENDEDOR E SALVA NO BD
	Private Sub btnVendedorAlterar_Click(sender As Object, e As EventArgs) Handles btnVendedorAlterar.Click
		'
		Dim fFunc As New frmFuncionarioEscolher(True, Me)
		fFunc.ShowDialog()
		If fFunc.DialogResult = DialogResult.Cancel Then Exit Sub
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim newID As Integer = fFunc.IDEscolhido
			'
			If vndBLL.AtualizaVendaVendedor(_Venda.IDVenda, newID) Then
				_Venda.IDVendedor = newID
				_Venda.ApelidoFuncionario = fFunc.NomeEscolhido
				lblVendedor.DataBindings("Text").ReadValue()
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao atualizar o Vendedor..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- ALTERA ou REMOVE O CLIENTE SIMPLES E SALVA NO BD
	Private Sub btnClienteSimplesInsertRemove_Click(sender As Object, e As EventArgs) Handles btnClienteSimplesEscolher.Click, btnClienteSimplesRemover.Click
		'
		Try
			'
			If DirectCast(sender, Button).Name = "btnClienteSimplesEscolher" Then '---> ALTERAR / INSERIR
				'
				Dim newID As Integer
				Dim ClienteNome As String
				'
				'--- open form Procurar Cliente
				Dim fCli As New frmClienteSimplesProcurar(True, Me)
				fCli.ShowDialog()
				'
				'--- check return (OK => cliente selected | RETRY => client NEW | CANCEL => canceled)
				If fCli.DialogResult = DialogResult.OK Then
					'
					newID = fCli.propCliente_Escolha.IDClienteSimples
					ClienteNome = fCli.propCliente_Escolha.ClienteNome
					'
				ElseIf fCli.DialogResult = DialogResult.Retry Then
					'
					'--- Ampulheta ON
					Cursor = Cursors.WaitCursor
					'
					'--- open form Add Cliente Simples
					Dim frmC As New frmClienteSimples(New clClienteSimples, Me)
					'
					frmC.ShowDialog()
					If frmC.DialogResult <> DialogResult.OK Then Exit Sub
					'
					newID = frmC.propCliente.IDClienteSimples
					ClienteNome = frmC.propCliente.ClienteNome
					'
				Else
					Exit Sub
				End If
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				If vndBLL.AtualizaRemoveVendaClienteSimples(_Venda.IDVenda, newID) Then
					_Venda.IDClienteSimples = newID
					_Venda.ClienteSimplesNome = ClienteNome
				End If
				'
			Else '---> REMOVER
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				If vndBLL.AtualizaRemoveVendaClienteSimples(_Venda.IDVenda, Nothing) Then
					_Venda.IDClienteSimples = Nothing
					_Venda.ClienteSimplesNome = String.Empty
				End If
				'
			End If
			'
			lblClienteSimplesNome.DataBindings("Text").ReadValue()
			lblClienteSimplesNome.DataBindings("Tag").ReadValue()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao atualizar o Cliente Simples da Venda..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
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
        Dim tranBLL As New TransacaoBLL
        Dim tc As New AcessoControlBLL
        Dim dBtran As Object = tc.GetNewAcessoWithTransaction
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If tranBLL.AtualizaTransacaoData(_Venda.IDVenda, newDt, dBtran) Then
                '
                _Venda.TransacaoData = frmDt.propDataInfo
                lblVendaData.DataBindings("Text").ReadValue()
                '
                '--- verifica se existe troca e altera a data da troca
                If Not IsNothing(_Troca) Then
                    Dim tBLL As New TrocaBLL
                    _Troca.TrocaData = newDt
                    '--- updata trocadata 
                    tBLL.AtualizaTroca_Procedure_ID(_Troca, dBtran)
                End If
                '
                '--- COMMIT
                tc.CommitAcessoWithTransaction(dBtran)
                '
            End If
            '
        Catch ex As Exception
            '
            '--- ROOLBACK
            tc.RollbackAcessoWithTransaction(dBtran)
            '
            '--- MESSAGE
            MessageBox.Show("Uma exceção ocorreu ao Evento..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- LIMPAR TODOS OS PAGAMENTOS DA VENDA
    Private Sub btnLimparPagamentos_Click(sender As Object, e As EventArgs) Handles btnLimparPagamentos.Click
        '
        '--- Verifica se o registro esta bloqueado
        If RegistroBloqueado() Then Exit Sub
        '
        '--- Verifica se ha entrada para limpar
        If _MovEntradaList.Count = 0 Then
            MessageBox.Show("Não existem pagamentos de Entrada nessa Venda para serem removidos...",
                            "Limpar Pagamentos", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            dgvPagamentos.Focus()
            Return
        End If
        '
        '--- Pergunta ao Usuário se Deseja inserir LIMPAR PAGAMENTOS
        If MessageBox.Show("Você deseja realmente LIMPAR todos os Pagamentos/Entradas dessa venda?",
                           "Limpar Pagamentos", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Return
        '
        '--- Faz a limpeza
        Limpa_Pagamentos()
        '
    End Sub
    '
    '--- CONTROLE DO MENU ACAO INFERIOR
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
        '--- verifica e pergunta
        If Not CanCloseMessage() Then Exit Sub
        '
        ProcuraVenda()
        '
    End Sub
    '
    ' ADICIONAR
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        '
        '--- verifica e pergunta
        If Not CanCloseMessage() Then Exit Sub
        '
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
#End Region '/ BOTOES ACAO
    '
#Region "FORMATACAO E FLUXO"
    '
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
        End If
        '
        If e.KeyCode = Keys.Divide Then
            ParcialFechar()
        End If
        '
    End Sub
    '
    Private Sub tabPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPrincipal.SelectedIndexChanged
        '
        If tabPrincipal.SelectedIndex = 0 Then
            dgvItens.Focus()
        ElseIf tabPrincipal.SelectedIndex = 1 Then
            dgvPagamentos.Focus()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLE DO GRID PAGAMENTOS"
    '
    '============================================================================================================
    ' PAGAMENTOS CONTROLES
    '============================================================================================================
    '
    '--- RETORNA TODOS OS PAGAMENTOS
    Private Sub obterPagamentos()
        '
        Dim pBLL As New MovimentacaoBLL
        '
        Try
            _MovEntradaList = pBLL.Movimentacao_GET_PorOrigemID(EnumMovimentacaoOrigem.Venda, _Venda.IDVenda)
            '--- Atualiza o label TOTAL PAGO
            AtualizaTotalPago()
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter os Pagamentos/Entradas da Venda:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- Preenche o DataGrid AReceber
    Private Sub Preenche_Pagamentos()
        '
        With dgvPagamentos
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
        ' (1) COLUNA IDEntrada
        dgvPagamentos.Columns.Add("clnID", "ID")
        With dgvPagamentos.Columns("clnID")
            .DataPropertyName = "IDMovimentacao"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA FORMA
        dgvPagamentos.Columns.Add("clnMovForma", "Forma")
        With dgvPagamentos.Columns("clnMovForma")
            .DataPropertyName = "MovForma"
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
        dgvPagamentos.Columns.Add("clnValor", "Valor")
        With dgvPagamentos.Columns("clnValor")
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
    Private Sub dgvPagamentos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPagamentos.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            '
            e.Handled = True
            Pagamentos_Adicionar()
            '
        ElseIf e.KeyCode = Keys.Enter Then
            '
            e.Handled = True
            Pagamentos_Editar()
            '
        ElseIf e.KeyCode = Keys.Delete Then
            '
            e.Handled = True
            Pagamentos_Excluir()
            '
        End If
        '
    End Sub
    '
    Private Sub Pagamentos_Adicionar()
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        '--- Atualiza o Valor do Total Geral
        Dim vl As Double = AtualizaTotalGeral()
        '
        '--- Verifica se o valor dos itens é maior que zero
        If vl = 0 Then
            MessageBox.Show("Não é possivel realizar pagamentos" & vbNewLine &
                            "Quando o valor da Venda ainda é igual a Zero..." & vbNewLine &
                            "Adicione produtos primeiro e depois tente novamente.", "Novo Pagamento",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- Verifica se o ValorPago já é suficiente
        If AtualizaTotalPago() >= vl Then
            MessageBox.Show("Não é possivel adicionar novo pagamento," & vbNewLine &
                "porque o valor dos Pagamentos já é igual ao valor total da venda", "Novo Pagamento",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- posiciona o form
        Dim pos As Point = dgvPagamentos.PointToScreen(Point.Empty)
        pos = New Point(pos.X + dgvPagamentos.Width - 10, pos.Y)
        '
        '--- cria nova Entrada
        Dim clPag As New clMovimentacao(EnumMovimentacaoOrigem.Venda, EnumMovimento.Entrada)
        Dim vlMax As Double = vl - _MovEntradaList.Sum(Function(x) x.MovValor)
        '
        clPag.MovValor = vlMax
        clPag.Origem = 1
        clPag.IDOrigem = _Venda.IDVenda
        clPag.MovData = _Venda.TransacaoData
        clPag.IDConta = Obter_ContaPadrao()
        clPag.IDMovimentacao = _MovEntradaList.Count + 1
        clPag.IDFilial = _IDFilial
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        '--- abre o form frmPagamentos
        Dim fPag As New frmVendaEntrada(Me, vlMax, clPag, EnumFlagAcao.INSERIR, pos)
        fPag.ShowDialog()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        '--- Check DialogResult
        If fPag.DialogResult = DialogResult.Cancel Then Return
        '
        '--- Insere o ITEM na lista
        _MovEntradaList.Add(clPag)
        bindEnt.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvPagamentos.DataSource = bindEnt
        bindEnt.MoveLast()
        '
        '--- AtualizaTotalPago
        AtualizaTotalPago()
        '
    End Sub
    '
    Private Sub Pagamentos_Editar()
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        '
        '--- posiciona o form
        Dim pos As Point = dgvPagamentos.PointToScreen(Point.Empty)
        pos = New Point(pos.X + dgvPagamentos.Width - 10, pos.Y)
        '
        '--- GET Pagamentos do DataGrid
        If dgvPagamentos.SelectedRows.Count = 0 Then Exit Sub
        '
        Dim PagAtual As clMovimentacao = dgvPagamentos.SelectedRows(0).DataBoundItem
        '
        Dim fPag As New frmVendaEntrada(Me, AtualizaTotalGeral(), PagAtual, EnumFlagAcao.EDITAR, pos)
        fPag.ShowDialog()
        '
        '--- AtualizaTotalPago
        AtualizaTotalPago()
        '
    End Sub
    '
    Private Sub Pagamentos_Excluir()
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro nao esta finalizado
        '
        '--- verifica se existe alguma parcela selecionada
        If dgvPagamentos.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- seleciona a parcela
        Dim PagAtual As clMovimentacao
        PagAtual = dgvPagamentos.SelectedRows(0).DataBoundItem
        '
        '--- pergunta ao usuário se deseja excluir o item
        If MessageBox.Show("Deseja realmente REMOVER esse Pagamento?", "Excluir Pagamento",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- envia o comando para excluir a parcela
        '
        Dim i As Integer = dgvPagamentos.SelectedRows(0).Index
        '
        '--- Atualiza o ITEM da lista
        _MovEntradaList.RemoveAt(i)
        '
        '--- Atualiza a contagem dos itens
        i = 1
        '
        For Each pg As clMovimentacao In _MovEntradaList
            pg.IDMovimentacao = i
            i += 1
        Next
        '
        bindEnt.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvPagamentos.DataSource = bindEnt
        '--- AtualizaTotalPago
        AtualizaTotalPago()
        '
    End Sub
    '
    ' ALTERA A COR DO DATAGRIDVIEW QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgv_GotFocus(sender As Object, e As EventArgs) Handles dgvPagamentos.GotFocus
        '
        Dim c As Color = Color.FromArgb(209, 215, 220)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.Fixed3D
        '
    End Sub
    '
    Private Sub dgv_LostFocus(sender As Object, e As EventArgs) Handles dgvPagamentos.LostFocus
        '
        Dim c As Color = Color.FromArgb(224, 232, 243)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.None
        '
    End Sub
    '
    ' CONTROLA O MENU NO DATAGRID PAGAMENTOS
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvPagamentos_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvPagamentos.MouseDown
        If e.Button = MouseButtons.Right Then
            'Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvPagamentos.HitTest(e.X, e.Y)
            dgvPagamentos.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvPagamentos.CurrentCell = dgvPagamentos.Rows(hit.RowIndex).Cells(1)
            dgvPagamentos.Rows(hit.RowIndex).Selected = True
            dgvPagamentos.Focus()
            '
            mnuContexto.Show(dgvPagamentos, e.Location)
            '
        End If
    End Sub
    '
    Private Sub dgvAReceber_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPagamentos.CellDoubleClick
        Pagamentos_Editar()
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
            '--- CREATE NEW ACESSO WITH TRANSACTION
            Dim tBLL As New AcessoControlBLL
            '
            Dim myDBTran As Object = tBLL.GetNewAcessoWithTransaction
            '
            '--- SALVA OS PAGAMENTOS NO BD
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                Salvar_Pagamentos(myDBTran)
                '
            Catch ex As Exception
                '
                '--- ROOLBACK TRANSACTION
                tBLL.RollbackAcessoWithTransaction(myDBTran)
                '
                MessageBox.Show("Uma exceção ocorreu ao Salvar as Movimentações de Entrada..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
                '
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
            '--- SALVA A TRANSACAO/VENDA NO BD
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                '--- altera a situacao da transacao atual
                _Venda.IDSituacao = 2 'CONCLUÍDA
                '
                Dim obj As Object = vndBLL.AtualizaVenda_Procedure_ID(_Venda, myDBTran)
                '
                If Not IsNumeric(obj) Then
                    Throw New Exception(obj.ToString)
                End If
                '
                '--- COMMIT TRANSACTION
                tBLL.CommitAcessoWithTransaction(myDBTran)
                '
                '--- ALTERA A SITUACAO DO REGISTRO ATUAL
                Sit = EnumFlagEstado.RegistroSalvo
                '
            Catch ex As Exception
                '
                '--- ROOLBACK TRANSACTION
                tBLL.RollbackAcessoWithTransaction(myDBTran)
                '
                '--- MESSAGE
                MessageBox.Show("Uma exceção ocorreu ao Salvar a Venda..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '
                '--- RETURN
                Return
                '
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
        End If
        '
        '--- PERGUNTA O QUE O USUARIO DESEJA FAZER
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
        '--- Verifica se a Data não está BLOQUEADA pelo sistema
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
        '--- Verifica se o valor da venda é igual à soma dos pagamentos
        If Math.Abs(AtualizaTotalGeral() - AtualizaTotalPago()) >= 1 Then
            tabPrincipal.SelectedTab = vtab2
            dgvPagamentos.Focus()
            If MessageBox.Show("A soma dos pagamentos é diferente da soma dos produtos" & vbNewLine &
                               "Deseja Inserir os pagamentos agora?",
                               "Inserir Pagamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                '
                Efetuar_Pagamentos()
                '
                '--- Verifica novamente se o valor da venda é igual à soma dos pagamentos
                If Math.Abs(AtualizaTotalGeral() - AtualizaTotalPago()) >= 1 Then
                    Return False
                Else
                    Return True
                End If
                '
            Else
                Return False
            End If
        End If
        '
        Return True
        '
    End Function
    '
    Private Function Salvar_Pagamentos(myDBTran As Object) As Boolean
        '
        '--- verifica se existem pagamentos
        If _MovEntradaList.Count = 0 Then Return False
        '
        '==========================================================================
        '--- 1. Excluir todas as MOVIMENTACOES DE ENTRADA da Venda Atual
        '--- 2. UPDATE AReceber da Venda atual
        '--- 3. INSERE AS MOVIMENTACOES DE ENTRADA NO BD
        '==========================================================================
        '
        Dim recBLL As New AReceberBLL
        '
        '--- PASSO 1
        '----------------------------------------
        Try
            Dim movBLL As New MovimentacaoBLL
            '
            '--- 1. Excluir todas as MOVIMENTACOES DE ENTRADA da Venda Atual
            movBLL.MovimentacaoDeletePorOrigem(_Venda.IDVenda, EnumMovimentacaoOrigem.Venda, myDBTran)
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- PASSO 2
        '----------------------------------------
        Try
            '
            Dim rec As New clAReceber
            '
            rec.IDAReceber = _Venda.IDAReceber
            rec.AReceberValor = _Venda.TotalVenda
            rec.IDPessoa = _Venda.IDPessoaDestino
            rec.IDCobrancaForma = Nothing
            rec.IDPlano = Nothing
            rec.ValorPagoTotal = AtualizaTotalGeral()
            rec.SituacaoAReceber = 1 '--- QUITADO/PAGO
            '
            '--- 2. UPDATE um AReceber no BD
            recBLL.Update_AReceber(rec, myDBTran)
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- PASSO 3. insere as movimentacoes de entrada no BD
        '------------------------------------------------------
        Try
            Return AgrupaAndSalvaMovimentacoesEntrada(myDBTran)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------
    ' INSERE A MOVIMENTACOES DE ENTRADA
    '---------------------------------------------------------------------------------------------
    Private Function AgrupaAndSalvaMovimentacoesEntrada(myDBTran As Object) As Boolean
        '
        '--- INSERE AS MOVIMENTACOES DE ENTRADA NO BD
        '--- Agrupa as Entradas pelo IDMovForma (soma seus valores)
        '--- Cria uma nova lista de Entradas pelo agrupamento
        '
        Dim PagGroupList As New List(Of clMovimentacao)
        Dim ContaPadrao As Integer = Obter_ContaPadrao()
        '
        For Each pagItem As clMovimentacao In _MovEntradaList
            '
            If Not PagGroupList.Exists(Function(x) x.IDMovForma = pagItem.IDMovForma) Then
                '--- cria nova Entrada
                Dim clPag As New clMovimentacao(EnumMovimentacaoOrigem.Venda, EnumMovimento.Entrada)
                '
                clPag.MovValor = 0
                clPag.Origem = 1
                clPag.IDOrigem = _Venda.IDVenda
                clPag.MovData = _Venda.TransacaoData
                clPag.IDConta = ContaPadrao
                clPag.IDMovForma = pagItem.IDMovForma
                clPag.IDMeio = pagItem.IDMeio
                clPag.MovForma = pagItem.MovForma
                '
                PagGroupList.Add(clPag)
            End If
            '
            Dim pg As clMovimentacao = PagGroupList.Find(Function(x) x.IDMovForma = pagItem.IDMovForma)
            pg.MovValor = pg.MovValor + pagItem.MovValor
            '
        Next
        '
        '--- Remove os itens que foram agrupados
        _MovEntradaList.Clear()
        '
        '--- Atualiza a listagem
        bindEnt.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvPagamentos.DataSource = bindEnt
        '
        '--- Adiciona a nova lista agrupada ao BD
        Dim pagBll As New MovimentacaoBLL
        Dim recBLL As New AReceberBLL
        '
        Try
            For Each pag As clMovimentacao In PagGroupList
                '
                '--- Insere A MOVIMENTACAO DE ENTRADA
                pag = pagBll.Movimentacao_Inserir(pag, myDBTran)
                '
                '--- Insere a nova lista DataGrid pagamentos
                _MovEntradaList.Add(pag)
                '
                '--- Atualiza a listagem
                bindEnt.ResetBindings(False)
                '--- Atualiza o DataGrid
                dgvPagamentos.DataSource = bindEnt
                '
            Next
            '
            Return True
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
    End Function
    '
    '---------------------------------------------------------------------------------------------
    ' ADICIONA PAGAMENTOS EM LOOP ATE COMPLETAR O VALOR TOTAL DA VENDA
    '---------------------------------------------------------------------------------------------
    Private Sub Efetuar_Pagamentos()
        '
        Dim vlTotal As Double = AtualizaTotalGeral()
        Dim vlPago As Double = AtualizaTotalPago()
        Dim qtdePag As Integer = _MovEntradaList.Count
        '
        Do While Math.Abs(vlTotal - vlPago) >= 1
            '
            '--- posiciona o form
            Dim pos As Point = dgvPagamentos.PointToScreen(Point.Empty)
            pos = New Point(pos.X + dgvPagamentos.Width - 10, pos.Y)
            '
            '--- cria nova Entrada/Pagamento
            Dim clPag As New clMovimentacao
            Dim vlMax As Double = vlTotal - _MovEntradaList.Sum(Function(x) x.MovValor)
            '
            clPag.MovValor = vlMax
            clPag.Origem = 1
            clPag.IDOrigem = _Venda.IDVenda
            clPag.MovData = _Venda.TransacaoData
            clPag.IDConta = Obter_ContaPadrao()
            clPag.IDMovimentacao = _MovEntradaList.Count + 1
            clPag.IDFilial = _IDFilial
            '
            '--- abre o form frmPagamentos
            Dim fPag As New frmVendaEntrada(Me, vlMax, clPag, EnumFlagAcao.INSERIR, pos)
            fPag.ShowDialog()
            '
            '--- Verifica se foi adiciona algum novo pagamento
            If _MovEntradaList.Count - qtdePag = 0 Then ' nesse caso não foi adicionado nenhum pagamento
                Exit Do
            Else ' refaz o calculo da nova quantidade de pagamento
                qtdePag = _MovEntradaList.Count
            End If
            '
            '--- AtualizaTotalPago
            AtualizaTotalPago()
            vlPago = _MovEntradaList.Sum(Function(x) x.MovValor)
            '
        Loop
        '
    End Sub
    '
    '--- LIMPA TODOS OS PAGAMENTOS DA VENDA
    Private Function Limpa_Pagamentos() As Boolean
        '
        '--- LIMPA TODOS OS PAGAMENTOS DA VENDA
        '----------------------------------------------------------------
        Dim movBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            movBLL.MovimentacaoDeletePorOrigem(_Venda.IDVenda, EnumMovimentacaoOrigem.Venda)
            '
            For i = 0 To _MovEntradaList.Count - 1
                If _MovEntradaList.Item(i).IDMovimentacao <> 0 Then _MovEntradaList.RemoveAt(i)
            Next
            '
            '--- Atualiza a listagem
            bindEnt.ResetBindings(False)
            '
            '--- Atualiza o DataGrid
            dgvPagamentos.DataSource = bindEnt
            '
            '---Atualiza o valor pago
            AtualizaTotalPago()
            '
            '--- return
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Limpar as Movimentações de Entrada..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
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
        Dim VlProdutos As Double = _ItensList.Sum(Function(x) x.Total)
        '
        _Venda.ValorProdutos = VlProdutos
        '
        lblTotalGeral.DataBindings.Item("text").ReadValue()
        lblValorProdutos.DataBindings.Item("text").ReadValue()
        lblValorDevolucao.DataBindings.Item("text").ReadValue()
        '
        Return _Venda.TotalVenda
        '
    End Function
    '
    ' ATUALIZA O TOTAL DOS PAGAMENTOS
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalPago() As Double
        '
        Dim T As Double = _MovEntradaList.Sum(Function(x) x.MovValor)
        '
        _Venda.ValorPagoTotal = T
        lblTotalPago.Text = Format(T, "c")
        '
        Return T
        '
    End Function
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
            Dim newVenda As Object = v.VendaAVista_Nova
            '
            If IsNothing(newVenda) Then Return
            '
            propVenda = newVenda
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inserir nova Venda..." & vbNewLine &
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
        Me.Close()
        Dim frmP As New frmOperacaoSaidaProcurar
        OcultaMenuPrincipal()
        Dim fPrincipal As Form = Application.OpenForms.OfType(Of frmPrincipal)().First
        frmP.MdiParent = fPrincipal
        frmP.Show()
    End Sub
    '
#End Region
    '
#Region "PARCIAIS DE VENDA"
    '
    '--- CONTROLA PARCIAIS | SUBTOTAIS
    '----------------------------------------------------------------------------------
    Private Sub ParcialRecalcula(index As Integer)
        '
        If Parciais.Count = 0 Then Exit Sub
        '
        Dim totalParcial As Double = 0
        '
        For Each parcial As SomaParcial In Parciais
            If index >= parcial.itemInicio And index <= parcial.itemFinal Then
                Dim pRange = _ItensList.GetRange(parcial.itemInicio, parcial.itemFinal - parcial.itemInicio + 1)
                totalParcial = pRange.Sum(Function(x) x.SubTotal)
                lblParcial.Text = Format(totalParcial, "c")
                Exit For
            End If
        Next
        '
        '--- if index is out of created parcial
        If totalParcial = 0 Then
            '
            '--- get last parcial item
            Dim lastIndex As Integer = Parciais.Last.itemFinal
            '
            If index >= lastIndex Then
                Dim count = _ItensList.Count - lastIndex - 1
                Dim pRange = _ItensList.GetRange(lastIndex + 1, count)
                totalParcial = pRange.Sum(Function(x) x.SubTotal)
                lblParcial.Text = Format(totalParcial, "c")
            End If
            '
        End If
        '
    End Sub
    '
    '--- FECHAR PARCIAL
    '----------------------------------------------------------------------------------
    Private Sub ParcialFechar()
        '
        Dim countItens As Integer = _ItensList.Count
        '
        '--- check if exist items
        If countItens = 0 Then
            Parciais.Clear()
            pnlParcial.Visible = False
            lblParcial.Text = 0
            Exit Sub
        End If
        '
        '--- check if exits any PARCIAIS
        If Parciais.Count = 0 Then
            Parciais.Add(New SomaParcial(0, countItens - 1))
            ParcialRecalcula(0)
        Else
            '-- verifica se existe novo item que ainda nao foi incluido
            If countItens <= Parciais.Last().itemFinal + 1 Then Exit Sub

            '-- verify the last item included
            Dim itemInicial As Integer = Parciais.Last().itemFinal + 1

            '-- include new items
            Parciais.Add(New SomaParcial(itemInicial, countItens - 1))
            ParcialRecalcula(countItens - 1)

        End If
        '
        pnlParcial.Visible = True
        '
    End Sub
    '
    '--- REMOVE PARCIAL AND RECALC
    '----------------------------------------------------------------------------------
    Private Sub ParcialRemoverItem(index As Integer)
        '
        '--- check if exists parcial
        If Parciais.Count = 0 Then Exit Sub
        '
        '--- check if exists rows yet
        If existsItems() = 0 Then Exit Sub
        '
        Dim parcialEncontrada As Boolean = False
        '
        For Each parcial As SomaParcial In Parciais
            '
            If Not parcialEncontrada Then
                '
                If index >= parcial.itemInicio And index <= parcial.itemFinal Then
                    parcial.itemFinal -= 1
                    parcialEncontrada = True
                End If
                '
            Else
                '
                parcial.itemInicio -= 1
                parcial.itemFinal -= 1
                '
            End If
        Next
        '
    End Sub
    '
    '--- PUT ONE LINE ON BOTTOM OF PARCIAL GROUP
    '----------------------------------------------------------------------------------
    Private Sub dgvItens_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvItens.RowPostPaint
        '
        If Parciais.Count = 0 Then Exit Sub
        '
        If Parciais.Exists(Function(x) x.itemFinal + 1 = e.RowIndex) Then
            Dim pen As New Pen(Color.SlateGray, 3)
            pen.DashStyle = Drawing2D.DashStyle.Dash
            e.Graphics.DrawLine(pen, 30, e.RowBounds.Top, e.ClipBounds.Right - 32, e.RowBounds.Top)
        End If
        '
    End Sub
    '
    '--- ALTERA SOMA PARCIAL
    '----------------------------------------------------------------------------------
    Private Sub dgvItens_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.RowEnter
        '
        If Parciais.Count = 0 Then Exit Sub
        '
        Dim item As clTransacaoItem = dgvItens.Rows(e.RowIndex).DataBoundItem
        Dim lstItemIndex As Integer = _ItensList.IndexOf(item)
        '
        ParcialRecalcula(lstItemIndex)
        '
    End Sub
    '
    '--- MOUSE OVER LBLPARCIAL
    '----------------------------------------------------------------------------------
    Private Sub lblParcialBtn_MouseHover(sender As Object, e As EventArgs) Handles lblParcialBtn.MouseHover
        DirectCast(sender, Label).BackColor = Color.LightGray
    End Sub
    Private Sub lblParcialBtn_MouseLeave(sender As Object, e As EventArgs) Handles lblParcialBtn.MouseLeave
        DirectCast(sender, Label).BackColor = Color.Transparent
    End Sub
    '
    '--- INSERT PARCIAL
    '----------------------------------------------------------------------------------
    Private Sub lblParcialBtn_Click(sender As Object, e As EventArgs) Handles lblParcialBtn.Click
        '
        '--- check if exist items
        Dim nItems As Integer = existsItems()
        If nItems = 0 Then Exit Sub
        '
        '--- check if exits any PARCIAIS
        If Parciais.Count = 0 Then
            Parciais.Add(New SomaParcial(0, nItems - 1))
            ParcialRecalcula(0)
            Return '-- exit
        End If
        '
        '-- get the actual row index
        Dim actualRow As Integer = dgvItens.CurrentRow.Index
        Dim insertBefore As Integer = -1
        Dim insertFinalRow As Integer = -1
        Dim insertInicioRow As Integer = -1
        Dim i As Integer = 0
        '
        '-- go through parcial looking for the actualrow
        For Each parcial As SomaParcial In Parciais
            '
            If actualRow = parcial.itemFinal Then '--- already exists parcial in actual row
                Exit For
            Else
                '
                If insertInicioRow <> -1 Then
                    'parcial.itemInicio = insertInicioRow
                    insertFinalRow = parcial.itemInicio - 1
                    Exit For
                End If
                '
                If actualRow >= parcial.itemInicio And actualRow < parcial.itemFinal Then
                    parcial.itemFinal = actualRow
                    insertInicioRow = actualRow + 1
                    insertBefore = i + 1
                End If
                '
            End If
            '
            i += 1
            '
        Next
        '
        '--- check if there is parcial for to be included
        If insertBefore = -1 Then Exit Sub
        '
        '--- insert new Parcial
        If insertFinalRow = -1 Then insertFinalRow = nItems - 1
        Parciais.Insert(insertBefore, New SomaParcial(insertInicioRow, insertFinalRow))
        '
        ParcialRecalcula(nItems - 1)
        dgvItens.Refresh()
        '
    End Sub
    '
    '--- FUNCTION RETURN NUMBER OF ITEMS AND HIDE PARCIAL CONTROLS
    '----------------------------------------------------------------------------------
    Function existsItems() As Integer
        '
        Dim countItens As Integer = _ItensList.Count
        '
        '--- check if exist items
        If countItens = 0 Then
            Parciais.Clear()
            pnlParcial.Visible = False
            lblParcial.Text = 0
        End If
        '
        Return countItens
        '
    End Function
    '
    Private Sub btnParcialClear_Click(sender As Object, e As EventArgs) Handles btnParcialClear.Click
        Parciais.Clear()
        pnlParcial.Visible = False
        lblParcial.Text = 0
        dgvItens.Refresh()
    End Sub
    '
#End Region '/ PARCIAIS DE VENDA
    '
#Region "BLOQUEIO DE REGISTRO"

    ' FUNCAO QUE CONFERE REGISTRO BLOQUEADO E EMITE MENSAGEM PADRAO
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroBloqueado() As Boolean
        '
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            MessageBox.Show("Esse registro de Venda está BLOQUEADO para alterações..." & vbNewLine &
                            "Não é possível adicionar produtos ou alterar algum dado!",
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
        If Not Sit = EnumFlagEstado.RegistroSalvo Then Return False
        '
        If MessageBox.Show("Esse registro de Venda já se encontra FINALIZADO..." & vbNewLine &
                           "Deseja realmente fazer alterações nesse registro?",
                           "Registro Finalizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Return True
        '
        '--- SALVA A TRANSACAO/VENDA NO BD
        '-------------------------------------------------------------------
        _Venda.IDSituacao = 1 '--- Edita o registro e altera a situação
        '
        Try
            Dim obj As Object = vndBLL.AtualizaVenda_Procedure_ID(_Venda)
            '
            If Not IsNumeric(obj) Then
                Throw New Exception(obj.ToString)
            End If
            '
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return True
        End Try
        '
    End Function
    '
    Private Function CanCloseMessage() As Boolean
        '
        If MessageBox.Show("Se você fechar essa VENDA agora os pagamentos não serão salvos..." & vbNewLine &
                           "Deseja Fechar a Venda assim mesmo?",
                           "Fechar a Venda",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = vbNo Then
            '
            '--- Seleciona a TAB
            tabPrincipal.SelectedTab = vtab2
            '
            '--- Select Control
            dgvPagamentos.Focus()
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
#Region "TROCA FUNCOES"
    '
    '--- VERIFICA SE EXISTE TROCA E ALTERA O BTNTROCA
    Private Sub VerificaTroca()
        '
        Dim tBLL As New TrocaBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _Troca = tBLL.GetTroca_PorIDVenda_clTroca(_Venda.IDVenda)
            '
            If Not IsNothing(_Troca) Then
                '
                '--- atualiza a propriedade VALORDEVOLUCAO da Venda
                If _Venda.ValorDevolucao <> _Troca.ValorTotal Then _Venda.ValorDevolucao = _Troca.ValorTotal
                '
                '--- Se houver Troca atualiza o marca o AGREGA DEVOLUCAO
                If Not _Venda.AgregaDevolucao Then _Venda.AgregaDevolucao = True '--- varejo COM troca
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
                '--- Se houver Troca atualiza o VendaTipo
                If _Venda.AgregaDevolucao Then _Venda.AgregaDevolucao = False '--- varejo SEM troca
                '
            End If
            '
            '--- Exibe ou esconde o Label do valor da troca
            Troca_EditaLabel()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao verificar se existe TROCA anexada à Venda..." & vbNewLine &
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
                '--- cria nova troca
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
    '--- VERIFICA E ADICIONA OU ALTERA A TROCA NA LISTA DE ENTRADA
    Private Sub Troca_EditaLabel()
        '
        If Not IsNothing(_Troca) Then
            pnlTroca.Visible = True
            '
            '-- atualiza o btnTroca e o lblTroca
            btnTroca.Text = "Altera &Troca"
            '
            '-- atualiza o lbltitulo
            lblTitulo.Text = "Venda A Vista com Troca"
        Else
            '
            pnlTroca.Visible = True
            '
            '-- atualiza o btnTroca e o lblTroca
            btnTroca.Text = "Insere &Troca"
            '
            '-- atualiza o lbltitulo
            lblTitulo.Text = "Venda Vista"
            '
        End If
        '
    End Sub
	'
#End Region '/ TROCA FUNCOES
	'
End Class
