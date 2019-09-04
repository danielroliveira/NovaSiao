Imports CamadaDTO
Imports CamadaBLL

Public Class frmDespesa
    Private _Despesa As clDespesa
    Private _APagarList As New List(Of clAPagar)
    Private BindDespesa As New BindingSource
    Private BindAPagar As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registr
    Private VerificaAlteracao As Boolean = False
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
                    lblSituacao.ForeColor = Color.White
                    '
                    '--- Botoes
                    btnNova.Enabled = True
                    btnProcurar.Enabled = True
                    btnSalvar.Enabled = False
                    btnCredor.Enabled = True
                    btnTipo.Enabled = True
                    btnFechar.Text = "&Fechar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = False
                    txtDespesaData.ReadOnly = False
                    txtDespesaValor.ReadOnly = False
                    txtDescricao.ReadOnly = False
                    '
                    '--- listagem
                    dgvAPagar.ReadOnly = False
                    '
                Case EnumFlagEstado.Alterado '--- REGISTRO FINALIZADO ALTERADO
                    lblSituacao.Text = "Alterada"
                    lblSituacao.ForeColor = Color.Cyan
                    '
                    '--- Botoes
                    btnNova.Enabled = False
                    btnProcurar.Enabled = False
                    btnSalvar.Enabled = True
                    btnCredor.Enabled = True
                    btnTipo.Enabled = True
                    btnFechar.Text = "&Cancelar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = False
                    txtDespesaData.ReadOnly = False
                    txtDespesaValor.ReadOnly = False
                    txtDescricao.ReadOnly = False
                    '
                    '--- listagem
                    dgvAPagar.ReadOnly = False
                    '
                Case EnumFlagEstado.NovoRegistro '--- REGISTRO NÃO FINALIZADO
                    lblSituacao.Text = "Nova"
                    lblSituacao.ForeColor = Color.Yellow
                    '
                    '--- Botoes
                    btnNova.Enabled = False
                    btnProcurar.Enabled = False
                    btnSalvar.Enabled = True
                    btnCredor.Enabled = True
                    btnTipo.Enabled = True
                    btnFechar.Text = "&Fechar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = False
                    txtDespesaData.ReadOnly = False
                    txtDespesaValor.ReadOnly = False
                    txtDescricao.ReadOnly = False
                    '
                    '--- listagem
                    dgvAPagar.ReadOnly = False
                    '
                Case EnumFlagEstado.RegistroBloqueado '--- REGISTRO BLOQUEADO PARA ALTERACOES
                    lblSituacao.Text = "Bloqueada"
                    lblSituacao.ForeColor = Color.DarkRed
                    '
                    '--- Botoes
                    btnNova.Enabled = True
                    btnProcurar.Enabled = True
                    btnSalvar.Enabled = False
                    btnCredor.Enabled = False
                    btnTipo.Enabled = False
                    btnFechar.Text = "&Fechar"
                    '
                    '--- textbox
                    txtCredor.ReadOnly = True
                    txtDespesaData.ReadOnly = True
                    txtDespesaValor.ReadOnly = True
                    txtDescricao.ReadOnly = True
                    '
                    '--- listagem
                    dgvAPagar.ReadOnly = True
                    '
            End Select
        End Set
    End Property
    '
    Property propDespesa As clDespesa
        Get
            Return _Despesa
        End Get
        Set(value As clDespesa)
            _Despesa = value
            lblFilial.Text = _Despesa.ApelidoFilial
            '
            If Not IsNothing(_Despesa.IDDespesa) Then
                obterAPagar()
            Else
                _APagarList.Clear()
            End If
            '
            BindAPagar.DataSource = _APagarList
            '
            If IsNothing(BindDespesa.DataSource) Then
                BindDespesa.DataSource = _Despesa
                PreencheDataBinding()
            Else
                BindDespesa.Clear()
                BindDespesa.DataSource = _Despesa
                BindDespesa.ResetBindings(True)
            End If
            '
            '--- Preenche Itens do A Pagar (parcelas)
            Preenche_APagar()
            '
            '--- Atualiza o estado da Situacao: EnumFlagEstado
            If _Despesa.Bloqueada = True Then
                Sit = EnumFlagEstado.RegistroBloqueado
            ElseIf IsNothing(_Despesa.IDDespesa) Then
                Sit = EnumFlagEstado.NovoRegistro
                _Despesa.IDFilial = Obter_FilialPadrao()
                _Despesa.ApelidoFilial = ObterDefault("FilialDescricao")
            Else
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
            '--- Seleciona o primeiro controle
            txtCredor.Focus()
            '
        End Set
        '
    End Property
    '
    Sub New(Despesa As clDespesa, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propDespesa = Despesa
        '
        Handler_MouseDown()
        Handler_MouseUp()
        Handler_MouseMove()
        '
    End Sub
    '
    Private Sub frmDespesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- Permite a verificacao dos combo
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
        lblID.DataBindings.Add("Text", BindDespesa, "IDDespesa", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", BindDespesa, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCredor.DataBindings.Add("Text", BindDespesa, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCNP.DataBindings.Add("Text", BindDespesa, "CNP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaTipo.DataBindings.Add("Text", BindDespesa, "DespesaTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescricao.DataBindings.Add("Text", BindDespesa, "Descricao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaData.DataBindings.Add("Text", BindDespesa, "DespesaData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaValor.DataBindings.Add("Text", BindDespesa, "DespesaValor", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Text").Format, AddressOf FormatRG
        AddHandler txtDespesaValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtDespesaData.DataBindings("text").Format, AddressOf FormatDT
        AddHandler lblCNP.DataBindings("text").Format, AddressOf FormatCNPNull
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbParcelado()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _Despesa.AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If _Despesa.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        eProvider.Clear()
        '
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub FormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        If IsNothing(e.Value) Then
            e.Value = "Nova"
        Else
            e.Value = Format(e.Value, "0000")
        End If
    End Sub
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    Private Sub FormatDT(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "dd/MM/yyyy")
    End Sub
    Private Sub FormatCNPNull(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        If IsNothing(e.Value) Then
            e.Value = "CNPJ/CPF Indefinido"
        End If
    End Sub
    '
    '--- CARERGA O COMBO PARCELADO
    Private Sub CarregaCmbParcelado()
        '
        Dim dtP As New DataTable
        '--- Adiciona as Colunas
        dtP.Columns.Add("Id")
        dtP.Columns.Add("Parcelado")
        '--- Adiciona todas as possibilidades de Frete
        dtP.Rows.Add(New Object() {False, "Não"})
        dtP.Rows.Add(New Object() {True, "Sim"})
        '
        With cmbParcelado
            .DataSource = dtP
            .ValueMember = "Id"
            .DisplayMember = "Parcelado"
            .DataBindings.Add("SelectedValue", BindDespesa, "Parcelado", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
#End Region
    '
#Region "DATAGRID APAGAR CONTROLE"
    '=============================================================================
    ' PREENCHE A LIST DO APAGAR
    '=============================================================================
    Private Sub obterAPagar()
        Dim pBLL As New APagarBLL
        Try
            _APagarList = pBLL.APagar_GET_PorOrigem(_Despesa.IDDespesa, clAPagar.Origem_APagar.Despesa)
            '--- Atualiza o label TOTAL
            AtualizaTotalAPagar()
        Catch ex As Exception
            MessageBox.Show("Um execeção ocorreu ao obter o A Pagar da Despesa:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '=============================================================================
    ' PREENCHE O DATAGRID APAGAR
    '=============================================================================
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
            .DataSource = BindAPagar
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
    '=============================================================================
    '  CONTROLA AS FUNCOES DO DATAGRID APAGAR
    '=============================================================================
    Private Sub dgvAReceber_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAPagar.KeyDown
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            APagar_Adicionar()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            APagar_Editar()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
            APagar_Excluir()
        End If
    End Sub
    '
    Private Sub APagar_Adicionar()
        '
        '--- Verifica se a data está pronta
        If IsNothing(_Despesa.DespesaData) Then
            MessageBox.Show("Não é possivel adicionar Parcela(s) de A Pagar" & vbNewLine &
                            "Quando a Data da Despesa ainda não foi informada" & vbNewLine &
                            "Informe a Data da Despesa depois tente novamente....", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDespesaData.Focus()
            Exit Sub
        End If
        '
        '--- Verifica se o valor da Despesa é maior que zero
        Dim vl As Double? = _Despesa.DespesaValor
        '
        If IsNothing(vl) OrElse vl = 0 Then
            MessageBox.Show("Não é possivel adicionar Parcela(s) de A Pagar" & vbNewLine &
                            "Quando o valor da Despesa ainda é igual a Zero..." & vbNewLine &
                            "Informe o Valor Total da Despesa depois tente novamente....", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDespesaValor.Focus()
            Exit Sub
        End If
        '
        '--- Atualiza o Valor do Total Geral
        Dim vlPag As Double = AtualizaTotalAPagar()
        '
        '--- Verifica se o somatorio de APAGAR ainda é menor que o ValorTotalGeral
        If Math.Abs(IIf(IsNothing(vl), 0, vl) - vlPag) < 0.1 Then
            MessageBox.Show("Não é possivel adicionar Parcelas de A Pagar" & vbNewLine &
                            "pois o valor da(s) Parcela(s) já é igual ao valor da Despesa" & vbNewLine &
                            "Você pode Alterar ou Excluir parcelas.", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- cria novo APagar
        Dim clPag As New clAPagar
        '
        clPag.Origem = clAPagar.Origem_APagar.Despesa
        clPag.IDOrigem = _Despesa.IDDespesa
        clPag.IDFilial = _Despesa.IDFilial
        clPag.IDPessoa = _Despesa.IDCredor
        clPag.APagarValor = vl - _APagarList.Sum(Function(x) x.APagarValor)
        clPag.Vencimento = _Despesa.DespesaData
        clPag.Situacao = 0
        '
        '--- verifica se houve outro APagar anterior para obter valores padrão
        Dim pagCount As Integer = _APagarList.Count
        '
        If pagCount > 0 Then
            clPag.CobrancaForma = _APagarList.ElementAt(pagCount - 1).CobrancaForma
            clPag.RGBanco = _APagarList.ElementAt(pagCount - 1).RGBanco
            clPag.Vencimento = _APagarList.ElementAt(pagCount - 1).Vencimento.AddMonths(1)
        End If
        '
        '--- abre o form frmAPagar
        Dim fPag As New frmAPagarItem(Me, clPag.APagarValor, _Despesa.DespesaData, clPag, EnumFlagAcao.INSERIR)
        fPag.ShowDialog()
        '
        If fPag.DialogResult = DialogResult.OK Then
            '--- Insere o APAGAR na lista
            _APagarList.Add(clPag)
            BindAPagar.ResetBindings(False)
            '--- Atualiza o DataGrid
            dgvAPagar.DataSource = BindAPagar
            BindAPagar.MoveLast()
            '
            '--- AtualizaTotalAPagar
            AtualizaTotalAPagar()
            '
            Sit = EnumFlagEstado.Alterado
            '
        End If
        '
    End Sub
    '
    Private Sub APagar_Editar()
        '
        Dim vl As Double = IIf(IsNothing(_Despesa.DespesaValor), 0, _Despesa.DespesaValor)
        '
        If vl = 0 Then
            MessageBox.Show("Não é possivel editar Parcela(s) de A Pagar" & vbNewLine &
                            "Quando o valor da Despesa ainda é igual a Zero..." & vbNewLine &
                            "Informe o Valor Total da Despesa depois tente novamente....", "Nova Parcela",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDespesaValor.Focus()
            Exit Sub
        End If
        '
        '--- GET APagar do DataGrid
        If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
        '
        Dim PagAtual As clAPagar = dgvAPagar.SelectedRows(0).DataBoundItem
        Dim fPag As New frmAPagarItem(Me, vl, _Despesa.DespesaData, PagAtual, EnumFlagAcao.EDITAR)
        fPag.ShowDialog()
        '
        '--- AtualizaTotalAPagar
        AtualizaTotalAPagar()
        '
        Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
    Private Sub dgvAPagar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAPagar.CellDoubleClick
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        APagar_Editar()
        '
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
        BindAPagar.ResetBindings(False)
        '--- Atualiza o DataGrid
        dgvAPagar.DataSource = BindAPagar
        '--- AtualizaTotalAPagar
        AtualizaTotalAPagar()
        '
        Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
    ' ALTERA A COR DO DATAGRIDVIEW ARECEBER QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub Listagem_GotFocus(sender As Object, e As EventArgs) Handles dgvAPagar.GotFocus
        dgvAPagar.BackgroundColor = Color.LightSteelBlue
    End Sub
    Private Sub Listagem_LostFocus(sender As Object, e As EventArgs) Handles dgvAPagar.LostFocus
        Dim c As Color = Color.FromArgb(224, 232, 243)
        dgvAPagar.BackgroundColor = c
    End Sub
    '
#End Region
    '
#Region "CONTROLE DO CONTEXT MENUSTRIP"
    '
    '=============================================================================
    ' CONTROLA O MENU NO DATAGRID APAGAR
    '=============================================================================
    Private Sub dgvAPagar_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvAPagar.MouseDown
        If e.Button = MouseButtons.Right Then
            'Dim c As Control = DirectCast(sender, Control)
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
    Private Sub InserirNovaParcelaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirNovaParcelaToolStripMenuItem.Click
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        APagar_Adicionar()
        '
    End Sub
    '
    Private Sub EditarParcelaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarParcelaToolStripMenuItem.Click
        '
        If dgvAPagar.SelectedRows.Count = 0 Then Exit Sub
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        APagar_Editar()
        '
    End Sub
    '
    Private Sub ExcluirParcelaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirParcelaToolStripMenuItem.Click
        '
        If RegistroBloqueado() Then Exit Sub '--- Verifica se o registro nao esta bloqueado
        '
        APagar_Excluir()
        '
    End Sub
    '
#End Region
    '
#Region "BLOQUEIO DE REGISTROS"

    ' PROIBE EDICAO NOS COMBOBOX QUANDO COMPRA BLOQUEADA
    '-----------------------------------------------------------------------------------------------------
    Private Sub ComboBox_SelectedValueChanged(sender As Object, e As EventArgs) _
        Handles cmbParcelado.SelectedValueChanged
        '
        If VerificaAlteracao = False Then Exit Sub
        '
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            '
            Select Case cmb.Name
                Case "cmbParcelado"
                    VerificaAlteracao = False
                    cmbParcelado.SelectedValue = IIf(IsNothing(_Despesa.Parcelado), -1, _Despesa.Parcelado)
                    VerificaAlteracao = True
            End Select
            '
            '--- emite mensagem padrao
            RegistroBloqueado()
            '
            Exit Sub
        End If
        '
        '--- QUANDO ALTERA O PARCELADO EFETUA O PARCELAMENTO AUTOMÁTICO
        If cmbParcelado.SelectedValue = True Then
            AutoParcelar()
        End If
        '
    End Sub
    '
    ' FUNCAO QUE CONFERE REGISTRO BLOQUEADO E EMITE MENSAGEM PADRAO
    '-----------------------------------------------------------------------------------------------------
    Private Function RegistroBloqueado() As Boolean
        If Sit = EnumFlagEstado.RegistroBloqueado Then
            MessageBox.Show("Esse registro de DESPESA está BLOQUEADO para alterações..." & vbNewLine &
                            "Não é possível adicionar ou alterar algum dado!",
                            "Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If
    End Function
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS"
    '
    ' PARCELAMENTO AUTOMÁTICO
    '-----------------------------------------------------------------------------------------------------
    Private Sub AutoParcelar()
        '
        '--- Questiona se deseja efetuar o parcelamento automático
        If MessageBox.Show("Você deseja efetuar o parcelamento automático?", "Parcelamento",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- Verifica o preenchimento dos controles
        If VerificaControles() = False Then Exit Sub
        '
        Dim frmP As New frmDespesaParcelamento(Me, True)
        frmP.ShowDialog()
        If frmP.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Dim infoParcelas As Integer = frmP.propParcelas
        Dim infocomEntrada As Boolean = frmP.propComEntrada
        Dim infoIDCobrancaForma As Integer = frmP.propIDCobrancaForma
        Dim infoCobrancaFormaTexto As String = frmP.propCobrancaFormaTexto
        Dim infoRGBanco As Integer? = frmP.propRGBanco
        '
        '--- Limpa as parcelas da listagem
        '---------------------------------------------------------------------
        _APagarList.Clear()
        '
        '--- Efetua o parcelamento
        '---------------------------------------------------------------------
        Dim DataInicial As Date
        '
        If infocomEntrada = True Then
            DataInicial = _Despesa.DespesaData
        Else
            DataInicial = _Despesa.DespesaData.Value.AddMonths(1)
        End If
        '
        For i = 0 To infoParcelas - 1
            '
            '--- cria novo APagar
            Dim clPag As New clAPagar
            Dim pString As String = ""
            '
            If infocomEntrada = True Then
                If i = 0 Then
                    pString = "Entrada"
                Else
                    pString = "Parcela " & i & "/" & infoParcelas - 1
                End If
            Else
                pString = "Parcela " & i + 1 & "/" & infoParcelas
            End If
            '
            clPag.Origem = clAPagar.Origem_APagar.Despesa
            clPag.IDOrigem = _Despesa.IDDespesa
            clPag.IDFilial = _Despesa.IDFilial
            clPag.IDPessoa = _Despesa.IDCredor
            clPag.IDCobrancaForma = infoIDCobrancaForma
            clPag.CobrancaForma = infoCobrancaFormaTexto
            clPag.Identificador = pString
            clPag.APagarValor = _Despesa.DespesaValor / infoParcelas
            clPag.Vencimento = DataInicial.AddMonths(i)
            clPag.Situacao = 0
            clPag.RGBanco = infoRGBanco
            '
            '--- Insere o APAGAR na lista
            _APagarList.Add(clPag)
            BindAPagar.ResetBindings(False)
            '--- Atualiza o DataGrid
            dgvAPagar.DataSource = BindAPagar
            BindAPagar.MoveLast()
            '
        Next i
        '
    End Sub
    '
    ' ATUALIZA O TOTAL DO APAGAR
    '-----------------------------------------------------------------------------------------------------
    Private Function AtualizaTotalAPagar() As Double
        Dim T As Double = 0
        T = _APagarList.Sum(Function(x) x.APagarValor)
        Return T
    End Function
    '
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    '-----------------------------------------------------------------------------------------------------
    Private Sub Control_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles txtDescricao.KeyDown, txtDespesaValor.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTONS"
    '
    ' PROCURA DESPESA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        Dim frmP As New frmDespesaProcurar
        '
        frmP.ShowDialog()
        '
        If btnProcurar.Enabled = False Then txtCredor.Focus()
    End Sub
    '
    ' CRIA UMA NOVA DESPESA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
        Dim desp As New clDespesa
        _APagarList.Clear()
        Sit = EnumFlagEstado.NovoRegistro
        '
        propDespesa = desp
        '
        txtCredor.Focus()
        '
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        If Sit = EnumFlagEstado.Alterado Then '--- OPERAÇÃO DE CANCELAR
            BindDespesa.CancelEdit()
            '
            _APagarList.Clear()
            obterAPagar()
            BindAPagar.DataSource = _APagarList
            '
            Sit = EnumFlagEstado.RegistroSalvo
            txtCredor.Focus()
        Else '--- OPERACAO DE FECHAR
            Close()
            MostraMenuPrincipal()
        End If '
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCredor.KeyDown, txtDespesaTipo.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtCredor"
                    btnCredor_Click(New Object, New EventArgs)
                Case "txtDespesaTipo"
                    btnTipo_Click(New Object, New EventArgs)
            End Select
        ElseIf e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            'e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    Private Sub btnCredor_Click(sender As Object, e As EventArgs) Handles btnCredor.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmC As New frmCredorProcurar(True, Me)
            '
            frmC.ShowDialog()
            If frmC.DialogResult = DialogResult.Cancel Then Exit Sub
            '
            Dim Cred As clCredor = frmC.propCredorEscolhido
            '
            txtCredor.Text = Cred.Cadastro
            _Despesa.CNP = Cred.CNP
            lblCNP.DataBindings.Item("text").ReadValue()
            _Despesa.IDCredor = Cred.IDPessoa
            '
            If Cred.CredorTipo = 1 Then
                lblCNPTexto.Text = "CPF"
            ElseIf Cred.CredorTipo = 2 Then
                lblCNPTexto.Text = "CNPJ"
            Else Cred.CredorTipo = 0 OrElse Cred.CredorTipo = 3
                lblCNPTexto.Text = "CNPJ"
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir Formulário de Procura de Credores..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmT As New frmDespesaTipoProcurar(True, Me)
            '
            frmT.ShowDialog()
            If frmT.DialogResult = DialogResult.Cancel Then Exit Sub
            '
            Dim T As clDespesaTipo = frmT.propDespesaEscolhida
            '
            txtDespesaTipo.Text = T.DespesaTipo
            _Despesa.IDDespesaTipo = T.IDDespesaTipo
            _Despesa.DespesaTipo = T.DespesaTipo
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir formulário de Tipos de Despesas..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub frmDespesa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "+" Then
            e.Handled = True
        End If
    End Sub
#End Region
    '
#Region "SALVAR REGISTRO"
    '
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Verifica os Controles
            '----------------------------------------------------------------------
            If Not VerificaControles() Then Exit Sub
            '
            '--- Verifica a soma dos valores de APagar
            '----------------------------------------------------------------------
            If Not Verifica_APagar() Then Exit Sub
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar Despesa..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        '--- Salva a Despesa
        '----------------------------------------------------------------------
        Dim dBLL As New DespesaBLL
        Dim tran As New AcessoControlBLL
        Dim dbTran As Object = tran.GetNewAcessoWithTransaction
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                Dim newID As Integer = dBLL.Despesa_Inserir(_Despesa, dbTran)
                '
                _Despesa.IDDespesa = newID
                lblID.DataBindings("text").ReadValue()
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao inserir nova despesa:" & vbNewLine &
                                ex.Message & vbNewLine & "O registro não pode ser salvo...",
                                "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tran.RollbackAcessoWithTransaction(dbTran)
                Exit Sub
            Finally
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
        ElseIf Sit = EnumFlagEstado.Alterado Then
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                Dim newID As Integer = dBLL.Despesa_Alterar(_Despesa, dbTran)
                '
                _Despesa.IDDespesa = newID
                lblID.DataBindings("text").ReadValue()
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao alterar a despesa:" & vbNewLine &
                                ex.Message & vbNewLine & "O registro não pode ser salvo...",
                                "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tran.RollbackAcessoWithTransaction(dbTran)
                Exit Sub
            Finally
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
        End If
        '
        '--- Salva as Parcelas de APagar
        '----------------------------------------------------------------------
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Salvar_APagar(dbTran)
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao SALVAR Registros de APagar..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tran.RollbackAcessoWithTransaction(dbTran)
            Exit Sub
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- Finaliza
        '----------------------------------------------------------------------
        ' COMMIT TRANSACTION
        tran.CommitAcessoWithTransaction(dbTran)
        Sit = EnumFlagEstado.RegistroSalvo
        '
        ' USER MESSAGE
        MessageBox.Show("Registro Salvo com sucesso!",
                        "Registro Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtCredor.Focus()
        '
    End Sub
    '
    Private Function Verifica_APagar() As Boolean
        '
        Dim TotalAPagar As Double = AtualizaTotalAPagar()
        '
        If Math.Abs(_Despesa.DespesaValor - TotalAPagar) < 0.1 Then
            Return True
        ElseIf TotalAPagar > _Despesa.DespesaValor Then
            MessageBox.Show("A soma total das parcelas a Pagar não pode ser maior o valor da Despesa." & vbNewLine &
                            "Favor verificar essa diferença alterando as parcelas...", "Total A Pagar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvAPagar.Focus()
            Return False
        End If
        '
        Dim T As Double = TotalAPagar
        '
        While T < _Despesa.DespesaValor
            '
            '--- cria novo APagar
            Dim clPag As New clAPagar
            '
            clPag.Origem = clAPagar.Origem_APagar.Despesa
            clPag.IDOrigem = _Despesa.IDDespesa
            clPag.IDFilial = _Despesa.IDFilial
            clPag.IDPessoa = _Despesa.IDCredor
            clPag.APagarValor = _Despesa.DespesaValor - T
            clPag.Vencimento = _Despesa.DespesaData
            clPag.Situacao = 0
            clPag.Identificador = ""
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
            Dim fPag As New frmAPagarItem(Me, clPag.APagarValor, _Despesa.DespesaData, clPag, EnumFlagAcao.INSERIR)
            fPag.ShowDialog()
            '
            '--- se a resposta Dialog não foi OK
            If fPag.DialogResult <> DialogResult.OK Then
                MessageBox.Show("A soma total das parcelas a Pagar necessita ser igual ao valor da Despesa." & vbNewLine &
                                "Favor verificar essa diferença...", "Total A Pagar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
                Exit While
            End If
            '
            If _Despesa.DespesaValor - (clPag.APagarValor + T) >= 0 Then
                '--- Insere o APAGAR na lista
                _APagarList.Add(clPag)
                BindAPagar.ResetBindings(False)
                '--- Atualiza o DataGrid
                dgvAPagar.DataSource = BindAPagar
                BindAPagar.MoveLast()
                T += clPag.APagarValor
            Else
                MessageBox.Show("A soma da parcela não pode ser maior que:" & vbNewLine &
                                _Despesa.DespesaValor - (clPag.APagarValor + T), "Total A Pagar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End While
        '
        Return True
        '
    End Function
    '
    Private Sub Salvar_APagar(dbTran As Object)
        '
        Dim pagBLL As New APagarBLL
        '
        '--- Exclui todos os registros de APagar da Compra atual
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If Not IsNothing(_Despesa.IDDespesa) Then
                pagBLL.APagarDeletePorOrigem(_Despesa.IDDespesa, clAPagar.Origem_APagar.Despesa, True, dbTran)
            End If
            '
            '--- Insere cada um AReceber no BD
            For Each pag As clAPagar In _APagarList
                pag.IDOrigem = _Despesa.IDDespesa
                pagBLL.InserirNovo_APagar(pag, dbTran)
            Next
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
    End Sub
    '
    Private Function VerificaControles() As Boolean
        Dim f As New Utilidades
        '
        If Not f.VerificaDadosClasse(txtCredor, "Credor", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDespesaTipo, "Tipo de Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDescricao, "Descrição da Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDespesaTipo, "Tipo de Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDespesaData, "Data da Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtDespesaValor, "Valor da Despesa", _Despesa, eProvider) Then
            Return False
        End If
        '
        Return True
        '
    End Function
    '
#End Region
    '
End Class