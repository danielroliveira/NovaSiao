Imports System.Xml
Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmSimplesSaida
    Private _Simples As clSimplesSaida
    Private simplesBLL As New SimplesMovimentacaoBLL
    Private _ItensList As New List(Of clTransacaoItem)
    Private _ParcelaList As New List(Of clAReceberParcela)
    Private bindSimples As New BindingSource
    Private bindItem As New BindingSource
    Private bindParc As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _Filial As Integer
    Private VerificaAlteracao As Boolean
    Private Taxa As Double?
    '
#Region "LOAD | PROPERTYS"
    '
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
                    txtObservacao.ReadOnly = False
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    lblSituacao.Text = "Alterada"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    btnData.Enabled = True
                    txtObservacao.ReadOnly = False
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    lblSituacao.Text = "Em Aberto"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    btnData.Enabled = True
                    txtObservacao.ReadOnly = False
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    lblSituacao.Text = "Bloqueada"
                    btnFinalizar.Text = "&Fechar"
                    '
                    btnData.Enabled = False
                    txtObservacao.ReadOnly = True
                    '
            End Select
        End Set
    End Property
    '
    Property propSimples As clSimplesSaida
        '
        Get
            Return _Simples
        End Get
        '
        Set(value As clSimplesSaida)
            '
            VerificaAlteracao = False '--- Inibe a verificacao dos campos IDPlano
            _Simples = value
            _Filial = _Simples.IDPessoaOrigem
            obterItens()
            obterParcelas()
            bindItem.DataSource = _ItensList
            bindParc.DataSource = _ParcelaList
            dgvItens.DataSource = bindItem
            '
            '
            If IsNothing(bindSimples.DataSource) Then
                bindSimples.DataSource = _Simples
                PreencheDataBinding()
            Else
                bindSimples.Clear()
                bindSimples.DataSource = _Simples
                bindSimples.ResetBindings(True)
            End If
            '
            '--- Preenche os Itens da Simples
            PreencheItens()
            '
            '--- Preenche Itens do A Receber (parcelas)
            Preenche_AReceber()
            cmbIDPlano.SelectedValue = IIf(IsNothing(_Simples.IDPlano), -1, _Simples.IDPlano)
            '
            '--- Atualiza o estado da Situacao: EnumFlagEstado
            Select Case _Simples.IDSituacao
                Case 1 ' SIMPLES INICIADA
                    Sit = EnumFlagEstado.NovoRegistro
                Case 2 ' SIMPLES FINALIZADA
                    Sit = EnumFlagEstado.RegistroSalvo
                Case 3 ' SIMPLES BLOQUEADA
                    Sit = EnumFlagEstado.RegistroBloqueado
                Case Else
            End Select
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
    Public Sub New(mySimples As clSimplesSaida)
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propSimples = mySimples
        '
        '--- Define a TAXA PERMANENCIA padrao
        Try
            Taxa = Convert.ToDouble(ObterDefault("TaxaPermanencia"))
        Catch ex As Exception
            Taxa = 0
        End Try
        '
    End Sub
    '
    Private Sub frmSimplesSaida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- desabilita a verificacao de bloqueio
        VerificaAlteracao = False
        '
        '--- faz a leitura dos combobox para nao emitir mensagem na alteracao do TAB
        cmbIDPlano.SelectedValue = If(_Simples.IDPlano, -1)
        '
        '--- habilita a verificacao de bloqueio
        VerificaAlteracao = True
        '
    End Sub
    '
#End Region '/ LOAD | PROPERTYS
    '
#Region "DATABINDING"
    '
    Private Sub PreencheDataBinding()
        '
        lblPessoaDestino.DataBindings.Add("Text", bindSimples, "PessoaDestino", True, DataSourceUpdateMode.OnPropertyChanged)
        lblIDTransacao.DataBindings.Add("Text", bindSimples, "IDTransacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindSimples, "PessoaOrigem", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTransacaoData.DataBindings.Add("Text", bindSimples, "TransacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindSimples, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTotalGeral.DataBindings.Add("Text", bindSimples, "ValorTotal", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDTransacao.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler lblTotalGeral.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblTransacaoData.DataBindings("text").Format, AddressOf FormatDT
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbPlano()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Simples.AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Simples.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
#End Region '/ DATABINDING
    '
#Region "CARREGA OS COMBOBOX"
    '
    Private Sub CarregaCmbPlano()
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
            .DataBindings.Add("SelectedValue", bindSimples, "IDPlano", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
    '--------------------------------------------------------------------------------------------------------
#End Region '/ CARREGA OS COMBOBOX
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
    '--- RETORNA TODOS OS ITENS DA SIMPLES
    Private Sub obterItens()
        Dim tBLL As New TransacaoItemBLL
        Try
            _ItensList = tBLL.GetTransacaoItens_List(_Simples.IDTransacao, _Filial)
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter Itens da Simples Saída:" & vbNewLine &
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
        Dim fItem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _Filial, newItem)
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
            newItem.IDTransacao = _Simples.IDTransacao

            myID = ItemBLL.InserirNovoItem(newItem,
                                           TransacaoItemBLL.EnumMovimento.SAIDA,
                                           _Simples.TransacaoData,
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
        Dim fitem As New frmVendaItem(Me, EnumPrecoOrigem.PRECO_COMPRA, _Filial, itmAtual)
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
            itmAtual.IDTransacao = _Simples.IDTransacao
            myID = ItemBLL.EditarItem(itmAtual,
                                      TransacaoItemBLL.EnumMovimento.SAIDA,
                                      _Simples.TransacaoData,
                                      InsereCustos:=False)
            '
            itmAtual.IDTransacaoItem = myID
            '
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
        If MessageBox.Show("Deseja realmente REMOVER esse item da Simples Saída?" & vbNewLine & vbNewLine &
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
#End Region ' /CARREGA/INSERE ITENS
    '
#Region "MENU CONTEXTO"
    '
    ' CONTROLA O MENU CONTEXTO NO DATAGRID ITENS
    '-----------------------------------------------------------------------------------------------------
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
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If Sit = EnumFlagEstado.NovoRegistro Or Sit = EnumFlagEstado.Alterado Then
            If MessageBox.Show("ALTERAÇÕES DA Simples Saída NÃO SERÃO SALVAS!" & vbNewLine & vbNewLine &
                               "Se você fechar agora essa Simples Saída," & vbNewLine &
                               "todas alterações serão perdidas," & vbNewLine &
                               "inclusive as alterações no Parcelamento..." & vbNewLine & vbNewLine &
                               "Deseja Fechar assim mesmo?", "Simples não Finalizada",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                tabPrincipal.SelectedTab = vtab2
                '
                cmbIDPlano.Focus()
                Exit Sub
            End If
            '
        End If
        '
        Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
    '--- ALTERAR A DATA DA SIMPLES
    Private Sub lblTransacaoData_DoubleClick(sender As Object, e As EventArgs) _
        Handles lblTransacaoData.DoubleClick, btnData.Click
        '
        Dim frmDt As New frmDataInformar("Informe a data da Simples Saída", EnumDataTipo.PassadoPresente, _Simples.TransacaoData, Me)
        frmDt.ShowDialog()
        '
        If frmDt.DialogResult <> DialogResult.OK Then Exit Sub
        '
        Dim newDt As Date = frmDt.propDataInfo
        '
        '--- verifica a data bloqueada
        If DataBloqueada(newDt, Obter_ContaPadrao) Then Exit Sub
        '
        '--- altera a data da simples e salva no BD
        Try
            '
            Dim tranBLL As New TransacaoBLL
            If tranBLL.AtualizaTransacaoData(_Simples.IDTransacao, newDt) Then
                '
                _Simples.TransacaoData = frmDt.propDataInfo
                lblTransacaoData.DataBindings("Text").ReadValue()
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao alterar a Data da Simples Saída..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region ' /BOTOES DE ACAO
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
        ProcuraSimples()
    End Sub
    '
    ' ADICIONAR
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        NovaSimples()
    End Sub
    '
    ' EXCLUIR
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        '--- Verifica bloqueio
        If RegistroBloqueado() Then Exit Sub
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você deseja realmente excluir definitivamente essa Simples Saída?",
                           "Excluir Venda",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        MsgBox("Ainda não implementado")
        Return
        '
        '--- Excluir Venda
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            'If vndBLL.DeletaVendaPorID(_Venda.IDVenda, _IDFilial) Then
            '    '
            '    '--- fecha
            '    Close()
            '    MostraMenuPrincipal()
            '    '
            'End If
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
    ' IMPRIMIR
    Private Sub miImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles miImprimirRelatorio.Click
        MessageBox.Show("Ainda não foi implementado...", "Imprimir Relatório")
    End Sub
    '
    ' PROCURA SIMPLES SAÍDA
    '-----------------------------------------------------------------------------------------------------
    Public Sub ProcuraSimples()
        '
        Me.Close()
        Dim frmP As New frmOperacaoSaidaProcurar(4)
        OcultaMenuPrincipal()
        Dim fPrincipal As Form = Application.OpenForms.OfType(Of frmPrincipal)().First
        frmP.MdiParent = fPrincipal
        frmP.Show()
        '
    End Sub
    '
    ' CRIA UMA NOVA SIMPLES SAIDA
    '-----------------------------------------------------------------------------------------------------
    Public Sub NovaSimples()
        Dim a As New AcaoGlobal
        Dim newSimples As Object = a.SimplesSaida_Nova
        '
        If IsNothing(newSimples) Then Exit Sub
        '
        _Simples = newSimples
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
            cmbIDPlano.Focus()
        ElseIf tabPrincipal.SelectedIndex = 2 Then
            dgvVendaNotas.Focus()
        End If
        '
    End Sub
    '
    ' CONVERTE ENTER EM TAB DE ALGUNS CONTROLES
    '---------------------------------------------------------------------------------------------------
    Private Sub Text_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacao.KeyDown
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
            _ParcelaList = rBLL.Parcela_GET_PorIDOrigem(3, _Simples.IDTransacao)
            '--- Atualiza o label TOTAL
            AtualizaTotalAReceber()
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter o A Receber da Simples Saída:" & vbNewLine &
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
        '--- Atualiza o Valor do Total Geral
        Dim vl As Double = AtualizaTotalGeral()
        '--- Verifica se o valor dos itens é maior que zero
        If vl = 0 Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Receber" & vbNewLine &
                            "Quando o valor da Simples Saída ainda é igual a Zero..." & vbNewLine &
                            "Adicione produtos primeiro e depois tente novamente.", "Nova Parcela",
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
        clPar.PermanenciaTaxa = Taxa
        clPar.IDAReceber = _Simples.IDAReceber
        clPar.IDPessoa = _Simples.IDPessoaDestino
        clPar.ParcelaValor = vl - _ParcelaList.Sum(Function(x) x.ParcelaValor)
        clPar.Vencimento = _Simples.TransacaoData
        clPar.Letra = myLetra.ToString
        '
        '--- abre o form frmAReceber
        Dim fRec As New frmAReceberItem(Me, vl, _Simples.TransacaoData, clPar, EnumFlagAcao.INSERIR, pos)
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
        Dim fRec As New frmAReceberItem(Me, AtualizaTotalGeral(), _Simples.TransacaoData, ParcAtual, EnumFlagAcao.EDITAR, pos)
        fRec.ShowDialog()
        '
        '--- AtualizaTotalAReceber
        AtualizaTotalAReceber()
        Sit = EnumFlagEstado.Alterado
    End Sub
    '
    Private Sub Parcela_Excluir()
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
    End Sub
    '
    Private Sub cmbIDPlano_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIDPlano.SelectedValueChanged
        '
        '--- Se não houver SelectedVaue então exit
        If Not IsNumeric(cmbIDPlano.SelectedValue) OrElse VerificaAlteracao = False Then Exit Sub
        '
        '--- Se o registro da simples saida esta bloqueado não permite alteracao
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            VerificaAlteracao = False
            cmbIDPlano.SelectedValue = If(_Simples.IDPlano, -1)
            VerificaAlteracao = True
            RegistroBloqueado() '--- mensagem padrao
            Exit Sub
        End If
        '
        '--- Se Valor Total da Simples for igual a Zero então Avisa e Exit
        Dim vlTotal As Double = AtualizaTotalGeral()
        If vlTotal = 0 Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Receber" & vbNewLine &
                            "Quando o valor da Simples Saída ainda é igual a Zero..." & vbNewLine &
                            "Adicione produtos primeiro e depois tente novamente.", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            VerificaAlteracao = False
            cmbIDPlano.SelectedValue = IIf(IsNothing(_Simples.IDPlano), -1, _Simples.IDPlano)
            VerificaAlteracao = True
            Exit Sub
        End If
        '
        '--- Pergunta ao usuario
        If Not IsNothing(_Simples.IDPlano) Then 'AndAlso cmbIDPlano.SelectedValue <> _Simples.IDPlano Then
            Dim a As DialogResult
            a = MessageBox.Show("Você deseja realmente alterar a forma de parcelamento dessa Simples Saída?",
                                "Alterar Parcelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If a = DialogResult.No Then
                VerificaAlteracao = False
                cmbIDPlano.SelectedValue = If(_Simples.IDPlano, -1)
                VerificaAlteracao = True
                Exit Sub
            End If
        End If
        '
        '--- Verifica se o parcelamento escolhido é o PERSONALIZADO = 0
        If cmbIDPlano.SelectedValue = 0 Then
            dgvAReceber.Focus()
            Exit Sub
        End If
        '
        '--- Obtem o DataTable do cmbPlano
        Dim dtPlano As DataTable = cmbIDPlano.DataSource
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
            _parc.ParcelaValor = vlParcela
            _parc.Vencimento = _Simples.TransacaoData.AddMonths(i)
            _parc.IDAReceber = _Simples.IDAReceber
            _parc.IDPessoa = _Simples.IDPessoaDestino
            _parc.SituacaoParcela = 0
            _parc.PermanenciaTaxa = Taxa
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
    ' DOUBLE CLICK NO DATAGRID ARECEBER
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgvAReceber_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAReceber.CellDoubleClick
        Parcela_Editar()
    End Sub
    '
    '============================================================================================================
#End Region ' /CONTROLE DO A RECEBER 
    '
#Region "FINALIZAR SIMPLES"
    '
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        '
        '--- Verifica se a SITUACAO do registro permite salvar
        If Not (Sit = EnumFlagEstado.Alterado Or Sit = EnumFlagEstado.NovoRegistro) Then
            '
            '--- Cria arquivo XML ou gera Simples Entrada Automatica
            VerificaXML_AND_SimplesEntrada()
            '
            '--- Close Form
            Close()
            MostraMenuPrincipal()
            Exit Sub
            '
        End If
        '
        '--- Faz as VERIFICACOES DOS CAMPOS E VALORES
        If Verificar() = False Then Exit Sub
        '
        '--- PERGUNTA AO USUÁRIO
        If MessageBox.Show("Deseja realmente Finalizar essa Transação de Simples Saída?",
                           "Finalizar Simples Saída",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        '
        '--- SALVA O ARECEBER PARCELAS NO BD
        If Salvar_Parcelas() = False Then Exit Sub
        '
        '--- SALVA A TRANSACAO/Simples Saída NO BD
        Try
            '--- altera a situacao da transacao atual
            _Simples.IDSituacao = 2 'CONCLUÍDA
            '
            simplesBLL.AtualizaSimplesSaida_Procedure_DT(_Simples)
            '
            '--- ALTERA A SITUACAO DO REGISTRO ATUAL
            Sit = EnumFlagEstado.RegistroSalvo
            '
            '--- PERGUNTA AO USUÁRIO SE DESEJA FECHAR
            If MessageBox.Show("Registro SALVO com sucesso!!! " &
                               vbNewLine & vbNewLine &
                               "Deseja SAIR dessa Simples Saída e fechar o formulário?",
                               "Fechar",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            '--- FECHA
            Close()
            MostraMenuPrincipal()
            '
        Catch ex As Exception
            _Simples.IDSituacao = 1 'INICIADA
            MessageBox.Show("Uma exceção ocorreu ao Finalizar e Salvar a Simples Saída..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- VERIFICA GERACAO DE ARQUIVO XML OU GERACAO DE SIMPLES ENTRADA
    Private Function VerificaXML_AND_SimplesEntrada() As Boolean
        '
        '--- verifica se o servidor é local
        Dim NodeServidorLocal As String = ObterConfigValorNode("ServidorLocal")
        '
        If String.IsNullOrEmpty(NodeServidorLocal) OrElse NodeServidorLocal.ToUpper = "TRUE" Then '--> Servidor LOCAL
            '
            If _Simples.ArquivoGerado Then Return True
            '
            If MessageBox.Show("Deseja gerar arquivo de transmissão de Simples Saída?",
                               "Gerar Arquivo",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = vbYes Then
                '
                '--- cria o arquivo XML
                If CriarArquivoXML() Then
                    '
                    _Simples.IDSituacao = 3 '--- BLOQUEADA
                    _Simples.ArquivoGerado = True
                    _Simples.ArquivoRecebido = True
                    simplesBLL.AtualizaSimplesSaida_Procedure_DT(_Simples)
                    Return True
                    '
                Else
                    Return False
                End If
                '
            End If
            '
        Else '--> Servidor REMOTO 
            '
            ' Verifica se a SIMPLES ENTRADA foi GERADA e pergunta ao Usuario
            Dim entrada As clSimplesEntrada = simplesBLL.VerificaEntrada(_Simples.IDTransacao)
            '
            If IsNothing(entrada) Then
                '
                '--- ask user if create a SIMPLES ENTRADA
                If MessageBox.Show("Deseja CRIAR automaticamente uma SIMPLES ENTRADA para a Filial Destino? " &
                                   vbNewLine & vbNewLine &
                                   _Simples.PessoaDestino.ToUpper,
                                   "Gerar Simples Entrada",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) = vbYes Then
                    '
                    '--- cria SIMPLES ENTRADA
                    '
                    Try
                        '--- Ampulheta ON
                        Cursor = Cursors.WaitCursor
                        '
                        simplesBLL.Insert_SimplesEntrada_FROM_SimplesSaida(_Simples)
                        '
                        _Simples.ArquivoGerado = True
                        _Simples.ArquivoRecebido = True
                        simplesBLL.AtualizaSimplesSaida_Procedure_DT(_Simples)
                        '
                        MessageBox.Show("Simples Entrada gerada com sucesso!",
                                        "Simples Entrada",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                        '
                        Return True
                        '
                    Catch ex As Exception
                        MessageBox.Show("Uma exceção ocorreu ao criar Simples Entrada..." & vbNewLine &
                                        ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    Finally
                        '--- Ampulheta OFF
                        Cursor = Cursors.Default
                    End Try
                    '
                End If
                '
            End If
            '
        End If
        '
        Return True
        '
    End Function
    '
    Private Function Verificar() As Boolean
        '--- Verifica se a Data não está BLOQUEADA pelo sistema
        '
        '----------------------------------------------------------------------------------------------
        ' VERIFICA OS VALORES DA SIMPLES SAIDA, DAS PARCELAS E DO FRETE
        '----------------------------------------------------------------------------------------------
        '
        '--- Verifica o valor da SIMPLES SAIDA
        If AtualizaTotalGeral() = 0 Then
            MessageBox.Show("Não é possível finalizar uma Simples Saída cujo valor final é igual a Zero..." & vbNewLine &
                            "Favor incluir alguns produtos nessa Simples Saída.",
                            "Simples Saída Nula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab1
            dgvItens.Focus()
            Return False
        End If
        '
        '--- Verifica se o valor da Simples Saída é igual à soma das parcelas
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
        ' VERIFICA OS CAMPOS NECESSÁRIOS DA SIMPLES SAÍDA
        '----------------------------------------------------------------------------------------------
        '--- Verifica se há PLANO DE PAGAMENTO
        If IsNothing(_Simples.IDPlano) Then
            MessageBox.Show("O campo PLANO DE PAGAMENTO não pode ficar vazio...", "Campo Necessário",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            tabPrincipal.SelectedTab = vtab2
            cmbIDPlano.Focus()
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    Private Function Salvar_Parcelas() As Boolean
        '
        If _ParcelaList.Count = 0 Then Return False
        '
        Dim parcBLL As New ParcelaBLL
        '
        Try
            '--- Exclui todos os registros de Parcela da Simples Saída atual
            parcBLL.Excluir_Parcelas_AReceber(_Simples.IDAReceber)
            '
            '--- Insere cada um AReceber no BD
            For Each parc As clAReceberParcela In _ParcelaList
                parc.IDAReceber = _Simples.IDAReceber
                parc = parcBLL.InserirNova_Parcela(parc)
            Next
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
#End Region ' /FINALIZAR SIMPLES
    '
#Region "FUNCOES NECESSARIAS"
    '
    ' ATUALIZA O TOTAL DO GERAL
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalGeral() As Double
        '
        If _ItensList.Count > 0 Then
            Dim T As Double = 0
            '
            For Each i As clTransacaoItem In _ItensList
                T = T + i.Total
            Next
            '
            _Simples.ValorTotal = T
            lblTotalGeral.DataBindings.Item("text").ReadValue()
            Return T
        Else
            Return 0
        End If
        '
    End Function
    '
    ' ATUALIZA O TOTAL DO ARECEBER
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalAReceber() As Double
        If _ParcelaList.Count > 0 Then
            Dim T As Double = 0
            '
            For Each p As clAReceberParcela In _ParcelaList
                T = T + p.ParcelaValor
            Next
            '
            lblTotalCobrado.Text = Format(T, "c")
            Return T
        Else
            lblTotalCobrado.Text = Format(0, "c")
            Return 0
        End If
    End Function
    '
#End Region '/FUNCOES NECESSARIAS
    '
#Region "BLOQUEIO DE REGISTROS"
    '
    ' FUNCAO QUE CONFERE REGISTRO BLOQUEADO E EMITE MENSAGEM PADRAO
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroBloqueado() As Boolean
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            MessageBox.Show("Esse registro de Simples Saída está BLOQUEADO para alterações..." & vbNewLine &
                            "Não é possível adicionar produtos ou alterar algum dado!",
                            "Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RegistroBloqueado = True
        Else
            RegistroBloqueado = False
        End If
    End Function
    '
    ' FUNCAO QUE CONFERE REGISTRO FINALIZADO E PERGUNTA SE DESEJA ALTERAR
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroFinalizado() As Boolean
        If Sit = EnumFlagEstado.RegistroSalvo Then
            If MessageBox.Show("Esse registro de Simples Saída já se encontra FINALIZADO..." & vbNewLine &
                               "Deseja realmente fazer alterações nesse registro?",
                               "Registro Finalizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                '--- Edita o registro e altera a situação
                _Simples.IDSituacao = 1
                '
                '--- SALVA A TRANSACAO/SIMPLES SAÍDA NO BD
                Try
                    '
                    simplesBLL.AtualizaSimplesSaida_Procedure_DT(_Simples)
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
    End Function
    '
#End Region '/ BLOQUEIO DE REGISTROS
    '
#Region "XML"
    '
    Private Function CriarArquivoXML() As Boolean
        '
        Dim saveDir As String = ""
        '
        '--- get the path
        Using FBDiag As New FolderBrowserDialog With {
            .Description = "Escolher Pasta de Salvamento",
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}
            '
            If FBDiag.ShowDialog = DialogResult.OK Then
                '
                saveDir = FBDiag.SelectedPath
                '
            Else
                Return False
            End If
            '
        End Using
        '
        Try
            '
            Dim settings As XmlWriterSettings = New XmlWriterSettings() With {.Indent = True}
            Dim arqName As String = "SS" & Format(_Simples.IDTransacao, "0000") & "O" & Format(_Simples.IDPessoaOrigem, "00")
            Dim writer As XmlWriter = XmlWriter.Create(saveDir & "\" & arqName & ".xml", settings)
            '
            writer.WriteStartDocument()
            writer.WriteDocType("SimplesSaida", Nothing, Nothing, Nothing)
            '
            'define a indentação do arquivo
            writer.WriteStartElement("Dados")
            '
            ' atributo para marcar arquivo recebido
            writer.WriteAttributeString("Recebido", False)

            ' atributo para marcar arquivo devolvido e confirmado
            writer.WriteAttributeString("Confirmado", False)
            '
            ' envia o clSimplesSaida
            SimplesXML.WriteObjProperty_XML(_Simples, writer)
            '
            ' envia os produtos
            SimplesXML.WriteObjProperty_XML(_ItensList, writer)
            '
            ' envia os APagar
            SimplesXML.WriteObjProperty_XML(_ParcelaList, writer)
            '
            ' send every envolved products in clProduto
            Dim pBLL As New ProdutoBLL
            Dim pList As New List(Of clProduto)
            '
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                pList = pBLL.GetProdutosLista_Transacao(_Simples.IDTransacao)
                '
            Catch ex As Exception
                '
                MessageBox.Show("Uma exceção ocorreu ao Obter Produtos da Simples Saída..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
                '
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
            ' envia os clProdutos LIST
            SimplesXML.WriteObjProperty_XML(pList, writer)
            '
            'FECHA XML
            writer.WriteEndElement()
            '
            'escreve o xml para o arquivo e fecha o objeto escritor
            ' Write the XML to file and close the writer
            writer.Flush()
            writer.Close()
            '
            '--- pergunta ao usuario se deseja abrir a pasta
            If MessageBox.Show("Arquivo de Transmissão da Simples Saída criado com sucesso!" & vbNewLine & vbNewLine &
                               "Deseja abrir a pasta do arquivo de transmissão?",
                               "Arquivo Criado",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = vbYes Then
                '
                Process.Start("explorer.exe", "/select," & saveDir & "\" & arqName & ".xml")
                '
            End If
            '
            Return True
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Gerar Arquivo de Simples Saída..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
    End Function
    '
#End Region
    '
End Class
