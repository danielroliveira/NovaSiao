Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmConsignacaoCompra
    '
    Private _Troca As clTroca
    Private _ItensList As List(Of clTransacaoItem)
    Private bindTroca As New BindingSource
    Private BindItem As New BindingSource
    '
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _Filial As Integer
    Private _formOrigem As Form

    Private WithEvents mnuItensAcao As New ContextMenuStrip
    Private WithEvents mnuItemEditar As New ToolStripMenuItem
    Private WithEvents mnuItemInserir As New ToolStripMenuItem
    Private WithEvents mnuItemExcluir As New ToolStripMenuItem
    Private ToolStripSeparator1 As New ToolStripSeparator
    '
#Region "LOAD"
    '
    Private Property Sit As EnumFlagEstado
        '
        Get
            Return _Sit
        End Get
        '
        Set(value As EnumFlagEstado)
            _Sit = value
            Select Case _Sit
                Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
                    '
                    lblSituacao.Text = "Finalizada"
                    btnFinalizar.Text = "&Fechar"
					'txtObservacao.ReadOnly = False
					btnExcluir.Enabled = True
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    '
                    lblSituacao.Text = "Alterada"
                    btnFinalizar.Text = "&Concluir"
					'txtObservacao.ReadOnly = False
					btnExcluir.Enabled = True
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    '
                    lblSituacao.Text = "Em Aberto"
                    btnFinalizar.Text = "&Concluir"
					'txtObservacao.ReadOnly = False
					btnExcluir.Enabled = True
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    '
                    lblSituacao.Text = "Bloqueada"
                    btnFinalizar.Text = "&Fechar"
					'txtObservacao.ReadOnly = True
					btnExcluir.Enabled = False
                    '
            End Select
            '
        End Set
        '
    End Property
    '
    Property propTroca As clTroca
        '
        Get
            Return _Troca
        End Get
        '
        Set(value As clTroca)
            '
            '--- define a Troca Atual
            _Troca = value
            _Filial = _Troca.IDFilial
            '
            '--- obtem os produtos da listagem
            getItensList()
            '
            '--- preenche os BINDS
            If IsNothing(bindTroca.DataSource) Then
                bindTroca.DataSource = _Troca
                PreencheDataBinding()
            Else
                bindTroca.Clear()
                bindTroca.DataSource = _Troca
                bindTroca.ResetBindings(True)
            End If
            '
            '--- Preenche e formata os Datagrid de Itens da Troca
            PreencheItens()
            '
            '--- Atualiza o estado da Situacao: EnumFlagEstado
            Select Case _Troca.IDSituacao
                Case 1 ' TROCA INICIADA
                    Sit = EnumFlagEstado.NovoRegistro
                Case 2 ' TROCA FINALIZADA
                    Sit = EnumFlagEstado.RegistroSalvo
                Case 3 ' TROCA BLOQUEADA
                    Sit = EnumFlagEstado.RegistroBloqueado
                Case Else
            End Select
            '
            '--- Atualiza o label TOTAL
            AtualizaTotalGeral()
            '
        End Set
        '
    End Property
    '
    Public Sub New(myTroca As clTroca, myVenda As clVenda, formOrigem As Form)
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        InicializarMenuItem()
        propTroca = myTroca
        '
        '--- se a venda estiver finalizada entao a troca esta BLOQUEADA
        If myVenda.IDSituacao = 2 OrElse myVenda.IDSituacao = 3 Then ' VENDA FINALIZADA
            Sit = EnumFlagEstado.RegistroBloqueado ' TROCA BLOQUEADA
        End If
        '
        _formOrigem = formOrigem
        '
    End Sub
    '
#End Region '// LOAD
    '
#Region "DATABINDING"
    '
    Private Sub PreencheDataBinding()
		''
		'lblCliente.DataBindings.Add("Text", bindTroca, "PessoaTroca", True, DataSourceUpdateMode.OnPropertyChanged)
		'lblIDTroca.DataBindings.Add("Text", bindTroca, "IDTroca", True, DataSourceUpdateMode.OnPropertyChanged)
		'lblFilial.DataBindings.Add("Text", bindTroca, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
		'lblTrocaData.DataBindings.Add("Text", bindTroca, "TrocaData", True, DataSourceUpdateMode.OnPropertyChanged)
		'lblVendedor.DataBindings.Add("Text", bindTroca, "ApelidoVenda", True, DataSourceUpdateMode.OnPropertyChanged)
		'txtObservacao.DataBindings.Add("Text", bindTroca, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
		'lblTotalGeral.DataBindings.Add("Text", bindTroca, "ValorTotal", True, DataSourceUpdateMode.OnPropertyChanged)
		''
		'' FORMATA OS VALORES DO DATABINDING
		'AddHandler lblIDTroca.DataBindings("Text").Format, AddressOf FormatRG
		'AddHandler lblTotalGeral.DataBindings("text").Format, AddressOf FormatCUR
		'AddHandler lblTrocaData.DataBindings("text").Format, AddressOf FormatDT
		''
		'' ADD HANDLER PARA DATABINGS
		'AddHandler _Troca.AoAlterar, AddressOf HandlerAoAlterar
		''
	End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Troca.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
#End Region '// DATABINDING
    '
#Region "GET ITENS"
    '
    '--- RETORNA TODOS OS ITENS DA VENDA
    Private Sub getItensList()
        Dim tBLL As New TransacaoItemBLL
        Try
            '
            '--- get itens da transacao entradas relacionadas a troca
            _ItensList = tBLL.GetTransacaoItens_List(_Troca.IDTransacaoEntrada, _Troca.IDFilial)
            BindItem.DataSource = _ItensList
            dgvItens.DataSource = BindItem
            '
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter Produtos de Entrada da Troca:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region '// GET ITENS
    '
#Region "DATAGRID"
    '
    '--- FORMATA E PREENCHE OS ITENS
    Friend Sub PreencheItens()
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
        '--- configura o DataSource da listagem
        'dgv.DataSource = _ItensListEntrada
        '
        '--- define o currentcell da listagem
        If dgvItens.Rows.Count > 0 Then dgvItens.CurrentCell = dgvItens.Rows(dgvItens.Rows.Count).Cells(1)
        '
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    '--- FORMATA COLUNAS
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
#End Region '/ DATAGRID
    '
#Region "MOVIMENTA ITENS CRUD PRODUTOS"
    '
    '--- INSERE UM NOVO ITEM NA LISTA DE PRODUTOS
    '---------------------------------------------------------------------------------------------
    Private Sub Inserir_Item()
        '
        '--- Verifica se esta Bloqueado ou Finalizado
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        If RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
        '
        Dim newItem As New clTransacaoItem
        Dim fItem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_VENDA, _Filial, newItem)
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
            newItem.IDTransacao = _Troca.IDTransacaoEntrada
            '
            myID = ItemBLL.InserirNovoItem(newItem, TransacaoItemBLL.EnumMovimento.ENTRADA, _Troca.TrocaData, InsereCustos:=False)
            newItem.IDTransacaoItem = myID
            '
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao INSERIR o item no BD..." & vbNewLine & ex.Message, "Exceção Inesperada",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        '--- Insere o ITEM na lista
        _ItensList.Add(newItem)
        BindItem.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvItens.DataSource = BindItem
        BindItem.MoveLast()
        '
        '--- Atualiza o label TOTAL
        AtualizaTotalGeral()
        '
        '--- Salva a Troca
        SalvaTroca()
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
        Dim fitem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_VENDA, _Filial, itmAtual)
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
            itmAtual.IDTransacao = _Troca.IDTroca
            myID = ItemBLL.EditarItem(itmAtual, TransacaoItemBLL.EnumMovimento.ENTRADA, _Troca.TrocaData, InsereCustos:=False)
            itmAtual.IDTransacaoItem = myID
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao ALTERAR o item no BD..." & vbNewLine & ex.Message,
                            "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        '--- Atualiza o ITEM da lista
        '
        '_ItensList.Item(i) = Item
        BindItem.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvItens.DataSource = BindItem
        'bindItem.CurrencyManager.Position = i
        '
        '--- Atualiza o label TOTAL
        AtualizaTotalGeral()
        '
        '--- Salva a Troca
        SalvaTroca()
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
        If MessageBox.Show("Deseja realmente REMOVER esse item da Troca?" & vbNewLine & vbNewLine &
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
            myID = ItemBLL.ExcluirItem(itmAtual, TransacaoItemBLL.EnumMovimento.ENTRADA)
        Catch ex As Exception
            MessageBox.Show("Houve um exceção ao EXCLUIR o item no BD..." & vbNewLine & ex.Message,
                                "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        '--- Atualiza o ITEM da lista
        _ItensList.RemoveAt(i)
        BindItem.ResetBindings(False)
        '
        '--- Atualiza o DataGrid
        dgvItens.DataSource = BindItem
        '
        '--- Atualiza o label TOTAL
        AtualizaTotalGeral()
        '
        '--- Salva a Troca
        SalvaTroca()
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------------------
    ' CRIA TECLA DE ATALHO PARA INSERIR/EDITAR PRODUTO
    '---------------------------------------------------------------------------------------------------
    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItens.KeyDown
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
    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
        Editar_Item()
    End Sub
    '
    Private Sub dgv_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
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
            mnuItensAcao.Show(dgvItens, e.Location)
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
#End Region
    '
#Region "BOTOES DE ACAO"
    '
    '--- FECHAR TROCA
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Or Sit = EnumFlagEstado.Alterado Then
            'If MessageBox.Show("ALTERAÇÕES DA TROCA NÃO SERÃO SALVAS!" & vbNewLine & vbNewLine &
            '                   "Se você fechar agora essa Troca," & vbNewLine &
            '                   "todas alterações serão perdidas," & vbNewLine &
            '                   "inclusive as alterações no Parcelamento..." & vbNewLine & vbNewLine &
            '                   "Deseja Fechar assim mesmo?", "Troca não Finalizada",
            '                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        End If
        '
        Close()
        '
    End Sub
    '
    '--- EXCLUIR A TROCA
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        If _ItensList.Count > 0 Then
            MessageBox.Show("Não é possível excluir uma TROCA que ainda possui produtos..." &
                            vbNewLine &
                            "Retire todos os produtos para depois excluir a troca.",
                            "Excluir Troca",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        '
        Try
            Dim tBLL As New TrocaBLL
            '
            tBLL.DeletaTrocaPorID(_Troca.IDTroca)
            '
            _Troca = Nothing
            Close()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir a Troca..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
	'
#End Region
	'
#Region "FORMATACAO E FLUXO"
	'
	' CONVERTE ENTER EM TAB DE ALGUNS CONTROLES
	'---------------------------------------------------------------------------------------------------
	Private Sub Text_KeyDown(sender As Object, e As KeyEventArgs)
		''
		''--- Se for o campo observacao, verifica se esta preenchido com algum texto
		''--- Se esta preenchido entao permite que o ENTER funcione como nova linha
		'If DirectCast(sender, TextBox).Name = "txtObservacao" AndAlso txtObservacao.Text.Trim.Length > 0 Then
		'	Exit Sub
		'End If
		''
		'If e.KeyCode = Keys.Enter Then
		'	e.SuppressKeyPress = True
		'	SendKeys.Send("{Tab}")
		'End If
		''
	End Sub
	'
	' ALTERA A COR DO DATAGRIDVIEW QUANDO GANHA OU PERDE O FOCO
	'-----------------------------------------------------------------------------------------------------
	Private Sub dgvEntradas_GotFocus(sender As Object, e As EventArgs) Handles dgvItens.GotFocus
        '
        Dim c As Color = Color.FromArgb(209, 215, 220)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.Fixed3D
        '
    End Sub
    '
    Private Sub dgvEntradas_LostFocus(sender As Object, e As EventArgs) Handles dgvItens.LostFocus
        '
        Dim c As Color = Color.FromArgb(224, 232, 243)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.None
        '
    End Sub
    '
#End Region
    '
#Region "FINALIZAR TROCA"
    '
    Public Function SalvaTroca() As Boolean
        '
        '--- SALVA A TROCA NO BD
        Dim tBLL As New TrocaBLL
        Try
            '--- altera a situacao da transacao atual
            _Troca.IDSituacao = 2 'CONCLUÍDA
            '
            Dim obj As Object = tBLL.AtualizaTroca_Procedure_ID(_Troca)
            '
            If Not IsNumeric(obj) Then
                Throw New Exception(obj.ToString)
            End If
            '
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Concluir a Troca..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
    End Function
    '
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        '
        '--- Verifica se a SITUACAO do registro permite salvar
        If Sit = EnumFlagEstado.Alterado OrElse Sit = EnumFlagEstado.NovoRegistro Then
            '
            '--- Faz as VERIFICACOES DOS CAMPOS E VALORES
            If Verificar() = False Then Exit Sub
            '
            If SalvaTroca() Then
                '
                '--- ALTERA A SITUACAO DO REGISTRO ATUAL
                Sit = EnumFlagEstado.RegistroSalvo
                '
            End If
        Else
            '-- apenas fechar
            Close()
            '
        End If
        '
    End Sub
    '
    Private Function Verificar() As Boolean
        '
        '----------------------------------------------------------------------------------------------
        ' VERIFICA OS VALOR DA TROCA
        '----------------------------------------------------------------------------------------------
        '
        '--- Verifica o valor da TROCA
        If AtualizaTotalGeral() = 0 Then
            MessageBox.Show("Não é possível finalizar uma troca cujo valor final é igual a Zero..." & vbNewLine &
                            "Favor incluir alguns produtos nessa troca.",
                            "Troca Nula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvItens.Focus()
            Return False
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
    ' ATUALIZA O TOTAL DOS PRODUTOS ENTRADOS
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalGeral() As Double

        If _ItensList.Count > 0 Then
            Dim T As Double = 0
            '
            For Each i As clTransacaoItem In _ItensList
                T = T + i.Total
            Next
            '
            _Troca.ValorTotal = T
            lblTotalGeral.DataBindings.Item("Text").ReadValue()
            Return T
        Else
            _Troca.ValorTotal = 0
            Return 0
        End If
        '
    End Function
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
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            MessageBox.Show("Esse registro de Troca está BLOQUEADO para alterações..." & vbNewLine &
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
        '--- Edita o registro e altera a situação
        _Troca.IDSituacao = 1
        '
        '--- SALVA A TRANSACAO/TROCA NO BD
        Dim tBLL As New TrocaBLL
        Try
            Dim obj As Object = tBLL.AtualizaTroca_Procedure_ID(_Troca)
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
        '
    End Function
    '
#End Region
    '
#Region "MENU ITEM"
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
#End Region '/ MENU ITEM
    '
End Class
