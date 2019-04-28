Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmTrocaSimples
    '
    Private Shared _Troca As clTroca
    Private ItensGroupEntrada As ItensGroup
    '
    Private bindTroca As New BindingSource
    '
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private Shared _Filial As Integer
    Private _formOrigem As Form
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
                    txtObservacao.ReadOnly = False
                    btnExcluir.Enabled = True
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    '
                    lblSituacao.Text = "Alterada"
                    btnFinalizar.Text = "&Concluir"
                    txtObservacao.ReadOnly = False
                    btnExcluir.Enabled = True
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    '
                    lblSituacao.Text = "Em Aberto"
                    btnFinalizar.Text = "&Concluir"
                    txtObservacao.ReadOnly = False
                    btnExcluir.Enabled = True
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    '
                    lblSituacao.Text = "Bloqueada"
                    btnFinalizar.Text = "&Fechar"
                    txtObservacao.ReadOnly = True
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
            ItensGroupEntrada.PreencheItens()
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
        ItensGroupEntrada = New ItensGroup(dgvEntradas, TransacaoItemBLL.EnumMovimento.ENTRADA, Me)
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
        '
        lblCliente.DataBindings.Add("Text", bindTroca, "PessoaTroca", True, DataSourceUpdateMode.OnPropertyChanged)
        lblIDTroca.DataBindings.Add("Text", bindTroca, "IDTroca", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindTroca, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTrocaData.DataBindings.Add("Text", bindTroca, "TrocaData", True, DataSourceUpdateMode.OnPropertyChanged)
        lblVendedor.DataBindings.Add("Text", bindTroca, "ApelidoVenda", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindTroca, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTotalGeral.DataBindings.Add("Text", bindTroca, "ValorTotal", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDTroca.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler lblTotalGeral.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblTrocaData.DataBindings("text").Format, AddressOf FormatDT
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Troca.AoAlterar, AddressOf HandlerAoAlterar
        '
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
            ItensGroupEntrada.ItensList = tBLL.GetTransacaoItens_List(_Troca.IDTransacaoEntrada, _Troca.IDFilial)
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
        If ItensGroupEntrada.ItensList.Count > 0 Then
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
    Private Sub Text_KeyDown(sender As Object, e As KeyEventArgs) Handles _
            txtObservacao.KeyDown
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
        Dim c As Color = Color.FromArgb(209, 215, 220)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.Fixed3D
        '
    End Sub
    '
    Private Sub dgvEntradas_LostFocus(sender As Object, e As EventArgs) Handles dgvEntradas.LostFocus
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
            dgvEntradas.Focus()
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

        If ItensGroupEntrada.ItensList.Count > 0 Then
            Dim T As Double = 0
            '
            For Each i As clTransacaoItem In ItensGroupEntrada.ItensList
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
    '=================================================
    ' CLASSE ITENSGROUP
    '=================================================
    '
    Private Class ItensGroup
        '
#Region "CLASSE INTERNA ITENSGROUP"
        '
        Private WithEvents _ItensList As List(Of clTransacaoItem)
        Private WithEvents _BindItem As BindingSource
        Private WithEvents _Dgv As DataGridView
        '
        Private WithEvents mnuItensAcao As New ContextMenuStrip
        Private WithEvents mnuItemEditar As New ToolStripMenuItem
        Private WithEvents mnuItemInserir As New ToolStripMenuItem
        Private WithEvents mnuItemExcluir As New ToolStripMenuItem
        Private ToolStripSeparator1 As New ToolStripSeparator
        '
        Private frmOrigem As frmTrocaSimples
        Property Movimento As TransacaoItemBLL.EnumMovimento
        '
        Sub New(_datagrid As DataGridView, _movimento As TransacaoItemBLL.EnumMovimento, _frmOrigem As frmTrocaSimples)
            '
            BindItem = New BindingSource
            Dgv = _datagrid
            ItensList = New List(Of clTransacaoItem)
            frmOrigem = _frmOrigem
            Movimento = _movimento
            InicializarMenuItem()
            '
        End Sub
        '
        Public Property Dgv() As DataGridView
            Get
                Return _Dgv
            End Get
            Set(ByVal value As DataGridView)
                _Dgv = value
            End Set
        End Property
        '
        Public Property BindItem() As BindingSource
            Get
                Return _BindItem
            End Get
            Set(ByVal value As BindingSource)
                _BindItem = value
            End Set
        End Property
        '
        Public Property ItensList() As List(Of clTransacaoItem)
            Get
                Return _ItensList
            End Get
            Set(ByVal value As List(Of clTransacaoItem))
                _ItensList = value
                BindItem.DataSource = _ItensList
                Dgv.DataSource = BindItem
            End Set
        End Property
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
#End Region
        '
#Region "PREENCHE FORMATA DATAGRID"
        '
        '--- FORMATA E PREENCHE OS ITENS
        Friend Sub PreencheItens()
            '
            '--- limpa as colunas do datagrid
            Dgv.Columns.Clear()
            Dgv.AutoGenerateColumns = False
            '
            ' altera as propriedades importantes
            Dgv.MultiSelect = False
            Dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Dgv.ColumnHeadersVisible = True
            Dgv.AllowUserToResizeRows = False
            Dgv.AllowUserToResizeColumns = False
            Dgv.RowHeadersVisible = True
            Dgv.RowHeadersWidth = 30
            Dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            Dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            Dgv.StandardTab = True
            '
            '--- configura o DataSource da listagem
            'dgv.DataSource = _ItensListEntrada
            '
            '--- define o currentcell da listagem
            If Dgv.Rows.Count > 0 Then Dgv.CurrentCell = Dgv.Rows(Dgv.Rows.Count).Cells(1)
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
            Dgv.Columns.Add("clnIDTansacaoItem", "IDItem")
            With Dgv.Columns("clnIDTansacaoItem")
                .DataPropertyName = "IDTransacaoItem"
                .Width = 0
                .Resizable = DataGridViewTriState.False
                .Visible = False
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            '
            ' (2) COLUNA RGProduto
            Dgv.Columns.Add("clnRGProduto", "Reg.")
            With Dgv.Columns("clnRGProduto")
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
            Dgv.Columns.Add("clnProduto", "Descrição")
            With Dgv.Columns("clnProduto")
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
            Dgv.Columns.Add("clnQuantidade", "Qtde.")
            With Dgv.Columns("clnQuantidade")
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
            Dgv.Columns.Add("clnPreco", "Preço")
            With Dgv.Columns("clnPreco")
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
            Dgv.Columns.Add("clnSubTotal", "SubTotal")
            With Dgv.Columns("clnSubTotal")
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
            Dgv.Columns.Add("clnDesconto", "Desc.")
            With Dgv.Columns("clnDesconto")
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
            Dgv.Columns.Add("clnTotal", "Total")
            With Dgv.Columns("clnTotal")
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
#End Region ' // PREENCHE FORMATA DATAGRID
        '
#Region "MOVIMENTA ITENS CRUD PRODUTOS"
        '
        '--- INSERE UM NOVO ITEM NA LISTA DE PRODUTOS
        '---------------------------------------------------------------------------------------------
        Private Sub Inserir_Item()
            '
            '--- Verifica se esta Bloqueado ou Finalizado
            If frmOrigem.RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            If frmOrigem.RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
            '
            Dim newItem As New clTransacaoItem
            Dim fItem As New frmVendaItem(frmOrigem, Movimento, _Filial, newItem)
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
                myID = ItemBLL.InserirNovoItem(newItem, Movimento, _Troca.TrocaData, InsereCustos:=False)
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
            Dgv.DataSource = BindItem
            BindItem.MoveLast()
            '
            '--- Atualiza o label TOTAL
            frmOrigem.AtualizaTotalGeral()
            '
            '--- Salva a Troca
            frmOrigem.SalvaTroca()
            '
        End Sub
        '    
        '--- EDITA UM ITEM NA LISTA DE PRODUTOS
        '---------------------------------------------------------------------------------------------
        Private Sub Editar_Item()
            '
            '--- Verifica se esta Bloqueado ou Finalizado
            If frmOrigem.RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            If frmOrigem.RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
            '
            '--- Verifica se há um item selecionado
            If Dgv.SelectedRows.Count = 0 Then Exit Sub
            '
            '--- obtem o itemAtual
            Dim itmAtual As clTransacaoItem
            itmAtual = Dgv.SelectedRows(0).DataBoundItem
            '
            '--- Abre o frmItem
            Dim fitem As New frmVendaItem(frmOrigem, Movimento, _Filial, itmAtual)
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
                myID = ItemBLL.EditarItem(itmAtual, Movimento, _Troca.TrocaData, InsereCustos:=False)
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
            Dgv.DataSource = BindItem
            'bindItem.CurrencyManager.Position = i
            '
            '--- Atualiza o label TOTAL
            frmOrigem.AtualizaTotalGeral()
            '
            '--- Salva a Troca
            frmOrigem.SalvaTroca()
            '
        End Sub
        '    
        '--- EXCLUI UM ITEM NA LISTA DE PRODUTOS
        '---------------------------------------------------------------------------------------------
        Private Sub Excluir_Item()
            '
            '--- Verifica se esta Bloqueado ou Finalizado
            If frmOrigem.RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            If frmOrigem.RegistroFinalizado() Then Exit Sub '--- Verifica se o registro está Finalizado
            '
            '--- Verifica se há um item selecionado
            If Dgv.SelectedRows.Count = 0 Then Exit Sub
            '
            '--- obtem o itemAtual
            Dim itmAtual As clTransacaoItem
            itmAtual = Dgv.SelectedRows(0).DataBoundItem
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
                myID = ItemBLL.ExcluirItem(itmAtual, Movimento)
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
            Dgv.DataSource = BindItem
            '
            '--- Atualiza o label TOTAL
            frmOrigem.AtualizaTotalGeral()
            '
            '--- Salva a Troca
            frmOrigem.SalvaTroca()
            '
        End Sub
        '
        '---------------------------------------------------------------------------------------------------
        ' CRIA TECLA DE ATALHO PARA INSERIR/EDITAR PRODUTO
        '---------------------------------------------------------------------------------------------------
        Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles _Dgv.KeyDown
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
        Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles _Dgv.CellDoubleClick
            Editar_Item()
        End Sub
        '
        Private Sub dgv_MouseDown(sender As Object, e As MouseEventArgs) Handles _Dgv.MouseDown
            '
            If e.Button = MouseButtons.Right Then
                'Dim c As Control = DirectCast(sender, Control)
                Dim hit As DataGridView.HitTestInfo = Dgv.HitTest(e.X, e.Y)
                Dgv.ClearSelection()
                '
                If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
                '
                ' seleciona o ROW
                Dgv.CurrentCell = Dgv.Rows(hit.RowIndex).Cells(1)
                Dgv.Rows(hit.RowIndex).Selected = True
                '
                'mnuItens.Show(dgvItens, c.PointToScreen(e.Location))
                mnuItensAcao.Show(Dgv, e.Location)
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
    End Class
    '
    '=================================================
    '
End Class
