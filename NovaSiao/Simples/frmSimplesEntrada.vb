Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmSimplesEntrada
    Private _Simples As clSimplesEntrada
    Private _ItensList As New List(Of clTransacaoItem)
    Private _APagarList As New List(Of clAPagar)
    Private _NotasList As New List(Of clNotaFiscal)
    '
    Private bindSimples As New BindingSource
    Private bindItem As New BindingSource
    Private bindAPagar As New BindingSource
    Private bindNota As New BindingSource
    '
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private _Filial As Integer
    Private VerificaAlteracao As Boolean
    Private _TotalGeral As Decimal
    Private _TotalProdutos As Decimal
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
                Case EnumFlagEstado.RegistroSalvo '--- REGISTRO FINALIZADO | NÃO BLOQUEADO
                    lblSituacao.Text = "Finalizada"
                    btnFinalizar.Text = "&Fechar"
                    '
                    txtObservacao.ReadOnly = False
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    lblSituacao.Text = "Alterada"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    txtObservacao.ReadOnly = False
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    lblSituacao.Text = "Em Aberto"
                    btnFinalizar.Text = "&Finalizar"
                    '
                    txtObservacao.ReadOnly = False
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    lblSituacao.Text = "Bloqueada"
                    btnFinalizar.Text = "&Fechar"
                    '
                    txtObservacao.ReadOnly = True
                    '
            End Select
        End Set
    End Property
    '
    Property propSimples As clSimplesEntrada
        Get
            Return _Simples
        End Get
        Set(value As clSimplesEntrada)
            'VerificaAlteracao = False '--- Inibe a verificacao dos campos IDPlano
            _Simples = value
            _Filial = _Simples.IDPessoaDestino
            obterItens()
            obterAPagar()
            obterNotas()
            bindItem.DataSource = _ItensList
            bindAPagar.DataSource = _APagarList
            bindNota.DataSource = _NotasList
            dgvItens.DataSource = bindItem
            '
            If IsNothing(bindSimples.DataSource) Then
                bindSimples.DataSource = _Simples
                PreencheDataBinding()
            Else
                bindSimples.Clear()
                bindSimples.DataSource = _Simples
                bindSimples.ResetBindings(True)
                'AddHandler _ClientePF.AoAlterar, AddressOf HandlerAoAlterar
            End If
            '
            '--- Preenche os Itens da Compra
            PreencheItens()
            '
            '--- Preenche Itens do A Pagar (parcelas)
            Preenche_APagar()
            '
            '--- Preenche Notas Fiscais
            Preenche_Notas()
            '
            '--- Atualiza o estado da Situacao: EnumFlagEstado
            Select Case _Simples.IDSituacao
                Case 1 ' COMPRA INICIADA
                    Sit = EnumFlagEstado.NovoRegistro
                Case 2 ' COMPRA FINALIZADA
                    Sit = EnumFlagEstado.RegistroSalvo
                Case 3 ' COMPRA BLOQUEADA
                    Sit = EnumFlagEstado.RegistroBloqueado
                Case Else
            End Select
            '
            '--- Permite a verificacao dos campos IDPlano
            VerificaAlteracao = True
            '
        End Set
    End Property
    '
    Public ReadOnly Property TotalGeral() As Decimal
        Get
            '
            _TotalGeral = TotalProdutos()
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
    Public Sub New(myCompra As clSimplesEntrada)
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propSimples = myCompra
        '
    End Sub
    '
#End Region
    '
#Region "DATABINDING"
    '
    Private Sub PreencheDataBinding()
        '
        lblFilialOrigem.DataBindings.Add("Text", bindSimples, "PessoaOrigem", True, DataSourceUpdateMode.OnPropertyChanged)
        lblIDTransacao.DataBindings.Add("Text", bindSimples, "IDTransacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindSimples, "PessoaDestino", True, DataSourceUpdateMode.OnPropertyChanged)
        lblTransacaoData.DataBindings.Add("Text", bindSimples, "TransacaoData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindSimples, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDTransacao.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler lblTransacaoData.DataBindings("text").Format, AddressOf FormatDT
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbNotaTipo()
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
#End Region
    '
#Region "CARREGA OS COMBOBOX"
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
        Try
            _ItensList = tBLL.GetTransacaoItens_WithCustos_List(_Simples.IDTransacao, _Filial)
            '
            '--- Atualiza o label TOTAL
            Dim x = TotalGeral
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter Itens da Simples Entrada:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "BOTOES DE ACAO"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        '
        Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnInserirObservacao_Click(sender As Object, e As EventArgs) Handles btnInserirObservacao.Click
        '
        If btnInserirObservacao.Tag = "Inserir" Then
            '
            txtObservacao.ReadOnly = False
            btnInserirObservacao.Text = "Salvar &Observações"
            '
            btnInserirObservacao.ForeColor = Color.DarkRed
            btnInserirObservacao.BackColor = Color.MistyRose
            '
            btnInserirObservacao.Tag = "Salvar"
            txtObservacao.Focus()
            '
        Else
            '
            '--- Save Observacao
            Dim oBLL As New ObservacaoBLL
            '            
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                oBLL.SaveObservacao(11, _Simples.IDTransacao, txtObservacao.Text)
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao Salvar a Nova Observação..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '
                txtObservacao.ReadOnly = True
                btnInserirObservacao.Text = "Alterar &Observação"
                '
                btnInserirObservacao.ForeColor = Color.Black
                btnInserirObservacao.BackColor = Color.Azure
                '
                btnInserirObservacao.Tag = "Inserir"
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "FORMATACAO E FLUXO"
    '
    ' CRIA TECLA DE ATALHO PARA O TAB
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
        If tabPrincipal.SelectedIndex = 0 Then
            dgvItens.Focus()
        ElseIf tabPrincipal.SelectedIndex = 1 Then
            dgvAPagar.Focus()
        ElseIf tabPrincipal.SelectedIndex = 2 Then
            dgvVendaNotas.Focus()
        End If
    End Sub
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacao.KeyDown
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
            _APagarList = pBLL.APagar_GET_PorOrigem(_Simples.IDTransacao, clAPagar.Origem_APagar.SimplesEntrada)
            '--- Atualiza o label TOTAL
            AtualizaTotalAPagar()
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter o A Pagar da Simples Entrada:" & vbNewLine &
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
    '============================================================================================================
#End Region
    '
#Region "FINALIZAR COMPRA"
    '
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        '
        '--- PERGUNTA O QUE O USUARIO DESEJA FAZER
        Dim fAcao As New frmAcaoDialog(Me, "Simples Entrada")
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
    ' CRIA UMA NOVA COMPRA
    '-----------------------------------------------------------------------------------------------------
    Public Sub NovaSimples()
        '
        Me.Close()
        Dim frmN As New frmSimplesEntradaControle
        OcultaMenuPrincipal()
        Dim fPrincipal As Form = Application.OpenForms.OfType(Of frmPrincipal)().First
        frmN.MdiParent = fPrincipal
        frmN.Show()
        '
    End Sub
    '
    ' PROCURA COMPRA
    '-----------------------------------------------------------------------------------------------------
    Public Sub ProcuraSimples()
        '
        Me.Close()
        Dim frmP As New frmOperacaoEntradaProcurar
        OcultaMenuPrincipal()
        Dim fPrincipal As Form = Application.OpenForms.OfType(Of frmPrincipal)().First
        frmP.MdiParent = fPrincipal
        frmP.Show()
        '
    End Sub
    '
#End Region
    '
#Region "NOTA FISCAL CONTROLE GRID"
    '
    Private Sub obterNotas()
        '
        Dim nBLL As New NotaFiscalBLL
        Try
            _NotasList = nBLL.NotaFiscal_GET_PorIDCompra(_Simples.IDTransacao)
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
            '
            Nota_Adicionar()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            Nota_Editar()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
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
        txtEmissaoData.Text = _Simples.TransacaoData
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
            .IDTransacao = _Simples.IDTransacao
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
        Dim F As New FuncoesUtilitarias

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
End Class
