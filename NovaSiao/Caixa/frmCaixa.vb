Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmCaixa
    Private lstMov As List(Of clMovimentacao)
    Private bindMovs As New BindingSource
    Private dtSaldo As New DataTable
    Private cxBLL As New CaixaBLL
    Private _Caixa As clCaixa
    Private _TEntradas As Double
    Private _TSaidas As Double
    Private _TTransf As Double
    Private WithEvents bindCaixa As New BindingSource

#Region "SUB NEW | PROPERTIES"
    '
    Sub New(myCaixa As clCaixa)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propCaixa = myCaixa
        '
        obterMovimentacoes()
        PreencheDataBindings()
        FormataDTSaldo()
        ObterSaldos()
        '
        CalculaTotais()
        '
    End Sub
    '
    Public Property propCaixa() As clCaixa
        '
        Get
            Return _Caixa
        End Get
        '
        Set(ByVal value As clCaixa)
            _Caixa = value
            bindCaixa.DataSource = value
            propIDSituacao = _Caixa.IDSituacao
        End Set
        '
    End Property
    '
    'PROPERTY SITUACAO
    Private Property propIDSituacao As Byte
        Get
            Return _Caixa.IDSituacao
        End Get
        Set(value As Byte)
            '
            Select Case _Caixa.IDSituacao
                Case 1 ' INICIADO
                    btnAlterar.Enabled = True
                    btnFinalizar.Enabled = True
                    btnExcluirCaixa.Enabled = True
                    '
                    txtObservacao.ReadOnly = False
                    '
                    btnFinalizar.Text = "Finalizar Caixa"
                    btnFinalizar.Image = My.Resources.accept
                    '
                Case 2 ' FINALIZADO
                    btnAlterar.Enabled = False
                    btnFinalizar.Enabled = True
                    btnExcluirCaixa.Enabled = False
                    '
                    txtObservacao.ReadOnly = True
                    '
                    btnFinalizar.Text = "Desbloqueio"
                    btnFinalizar.Image = My.Resources.unlock
                    '
                Case 3 ' BLOQUEADO
                    btnAlterar.Enabled = False
                    btnFinalizar.Enabled = False
                    btnExcluirCaixa.Enabled = False
                    '
                    txtObservacao.ReadOnly = True
                    '
                    btnFinalizar.Text = "Finalizar Caixa"
                    btnFinalizar.Image = My.Resources.accept
                    '
            End Select
            '
        End Set
    End Property
    '
#End Region
    '
#Region "BINDINGS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA

        lblIDProduto.DataBindings.Add("Text", bindCaixa, "IDCaixa")
        lblDataFinal.DataBindings.Add("Text", bindCaixa, "DataFinal", True, DataSourceUpdateMode.OnPropertyChanged)
        lblDataInicial.DataBindings.Add("Text", bindCaixa, "DataInicial", True, DataSourceUpdateMode.OnPropertyChanged)
        lblApelidoFilial.DataBindings.Add("Text", bindCaixa, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        lblConta.DataBindings.Add("Text", bindCaixa, "Conta", True, DataSourceUpdateMode.OnPropertyChanged)
        lblSituacao.DataBindings.Add("Text", bindCaixa, "Situacao")
        lblApelidoFuncionario.DataBindings.Add("Text", bindCaixa, "ApelidoFuncionario", True, DataSourceUpdateMode.OnPropertyChanged)
        lblSaldoAnterior.DataBindings.Add("Text", bindCaixa, "SaldoAnterior", True)
        txtObservacao.DataBindings.Add("Text", bindCaixa, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDProduto.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblSaldoAnterior.DataBindings("Text").Format, AddressOf idFormatCUR
        AddHandler lblApelidoFuncionario.DataBindings("Text").Format, AddressOf FormatNULLFuncionario
        '
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    '
    Private Sub idFormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    Private Sub FormatNULLFuncionario(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        '
        If IsNothing(e.Value) Or String.IsNullOrEmpty(e.Value) Then
            e.Value = "Não Determinado"
        End If
        '
    End Sub
    '
#End Region
    '
#Region "DATAGRID MOVIMENTAÇÃO"
    '
    Private Sub obterMovimentacoes()
        '
        Dim movBLL As New MovimentacaoBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- GET Lista de Movimentacoes
            lstMov = movBLL.GetMovimentos_IDCaixa(propCaixa.IDCaixa)
            bindMovs.DataSource = lstMov
            dgvListagem.DataSource = bindMovs
            '
        Catch ex As Exception
            MessageBox.Show("Um exceção ocorreu ao tentar obter os Entradas | Saídas dessa Conta ..." & vbNewLine &
                            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        PreencheListagem()
        '
    End Sub
    '
    Private Sub PreencheListagem()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        dgvListagem.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvListagem.MultiSelect = False
        dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListagem.ColumnHeadersVisible = True
        dgvListagem.AllowUserToResizeRows = False
        dgvListagem.AllowUserToResizeColumns = False
        dgvListagem.RowHeadersVisible = True
        dgvListagem.RowHeadersWidth = 30
        dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvListagem.StandardTab = True
        '
        FormataColunas()
        '
    End Sub
    '
    Private Sub FormataColunas()
        '
        ' (0) COLUNA MOV
        With clnMov
            .HeaderText = ""
            .DataPropertyName = "Mov"
            .Width = 40
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (1) COLUNA DATA
        With clnMovData
            .HeaderText = "Data"
            .DataPropertyName = "MovData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

        End With
        '
        ' (2) COLUNA DESCRICAO 
        With clnDescricao
            .HeaderText = "Descrição"
            .DataPropertyName = "Descricao"
            .Width = 400
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA FORMA 
        With clnMovForma
            .HeaderText = "Forma"
            .DataPropertyName = "MovForma"
            .Width = 200
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA VALOR
        With clnValor
            .HeaderText = "Valor"
            .DataPropertyName = "MovValor"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "C"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        Me.dgvListagem.Columns.AddRange(New DataGridViewColumn() {
                                        clnMov,
                                        clnMovData,
                                        clnDescricao,
                                        clnMovForma,
                                        clnValor})
        '
    End Sub
    '
    '--- CONTROLA AS CORES DA LISTAGEM
    '=====================================================================================================
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        If e.ColumnIndex = 0 Then
            If Not IsNothing(DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clMovimentacao).IDContaPadrao) Then
                e.Value = "E/S"
            End If
        End If
        '
        If e.ColumnIndex = 4 Then
            '
            Dim M As String = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clMovimentacao).Mov
            '
            Select Case M
                '
                Case "S"
                    '
                    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Firebrick
                    '
                    e.CellStyle.ForeColor = Color.Red
                Case "E"
                    '
                    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(219, 228, 240) 'Color.Azure
                    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                    '
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case "T"
                    '
                    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(205, 247, 205) 'Color.LightGreen
                    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.DarkGreen
                    '
                    If e.Value > 0 Then
                        e.CellStyle.ForeColor = Color.DarkBlue
                    Else
                        e.CellStyle.ForeColor = Color.Red
                    End If
                    '
            End Select
            '
        End If
        '
        If e.ColumnIndex = 3 Then '--- se nao houver movForma then
            If e.Value = "" Then
                e.Value = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clMovimentacao).Meio
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "DATAGRID SALDOS"
    '
    Private Sub FormataDTSaldo()
        '
        '--- Adiciona as COLUNAS da DataTable: dtSaldos
        '--------------------------------------------------------------
        Dim IDMeio As New DataColumn
        '
        With IDMeio
            .ColumnName = "IDMeio"
            .DataType = GetType(Byte)
            .Caption = "ID"
            .ReadOnly = False
            .Unique = True
        End With
        '
        dtSaldo.Columns.Add(IDMeio)
        Dim Keys(0) As DataColumn
        Keys(0) = IDMeio
        dtSaldo.PrimaryKey = Keys
        '
        dtSaldo.Columns.Add("Meio", GetType(String))
        dtSaldo.Columns.Add("IDConta", GetType(Short))
        dtSaldo.Columns.Add("Conta", GetType(String))
        dtSaldo.Columns.Add("SaldoAnterior", GetType(Decimal))
        dtSaldo.Columns.Add("SaldoFinal", GetType(Decimal))
        dtSaldo.Columns.Add("Nivelamento", GetType(Boolean))
        dtSaldo.Columns.Add("ATransferir", GetType(Decimal))
        '
    End Sub
    '
    Private Sub ObterSaldos()
        '
        '--- Limpa todas as ROWS do dtSaldo
        dtSaldo.Rows.Clear()
        '
        '--- Adiciona os DADOS da DataTable: dtSaldos
        '--------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Adiciona os DADOS do SALDOANTERIOR
            Dim dtSaldoAnterior As DataTable = cxBLL.GetSaldo_ContaTipos_IDCaixa(_Caixa.IDCaixa)
            '
            If dtSaldoAnterior.Rows.Count > 0 Then
                '
                For Each r As DataRow In dtSaldoAnterior.Rows
                    dtSaldo.Rows.Add({r("IDMeio"),
                                      r("Meio"),
                                      r("IDConta"),
                                      r("Conta"),
                                      r("SaldoFinal"),
                                      r("SaldoFinal"),
                                      0})
                Next
                '
            End If
            '
            '--- Calcula os DADOS do SALDOATUAL
            For Each c As clMovimentacao In lstMov
                '
                '--- GET valor real positivo para entrada e negativo para saída
                Dim MovValor As Double = c.MovValor
                '
                '--- Find IDMEIO no DataTable SaldoAnterior
                Dim saldoFind As DataRow = dtSaldo.Rows.Find(c.IDMeio)
                '
                '--- adiciona os valores
                If IsNothing(saldoFind) Then
                    If c.Descricao.ToString.Contains("Nivelamento") Then
                        dtSaldo.Rows.Add({c.IDMeio,
                                         c.Meio,
                                         c.IDConta,
                                         c.Conta,
                                         0,
                                         MovValor,
                                         True,
                                         0})
                    Else
                        dtSaldo.Rows.Add({c.IDMeio,
                                         c.Meio,
                                         c.IDConta,
                                         c.Conta,
                                         0,
                                         MovValor,
                                         False,
                                         If(IsNothing(c.IDContaPadrao), 0, c.MovValorReal)})
                    End If
                Else
                    saldoFind.BeginEdit()
                    '
                    If c.Descricao.ToString.Contains("Nivelamento") Then
                        saldoFind("Nivelamento") = True
                    End If
                    '
                    If IsDBNull(saldoFind("ATransferir")) Then saldoFind("ATransferir") = 0
                    '
                    If Not IsNothing(c.IDContaPadrao) Then
                        saldoFind("ATransferir") += MovValor
                    End If
                    '
                    saldoFind("SaldoFinal") += MovValor
                    saldoFind.AcceptChanges()
                    '
                End If
                '
            Next
            '
            dgvSaldos.DataSource = dtSaldo
            '
            PreencheDgvSaldos()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter Saldos Anteriores..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub PreencheDgvSaldos()
        '
        '--- limpa as colunas do datagrid
        dgvSaldos.Columns.Clear()
        dgvSaldos.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvSaldos.MultiSelect = False
        dgvSaldos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSaldos.ColumnHeadersVisible = True
        dgvSaldos.AllowUserToResizeRows = False
        dgvSaldos.AllowUserToResizeColumns = False
        dgvSaldos.RowHeadersVisible = True
        dgvSaldos.RowHeadersWidth = 30
        dgvSaldos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvSaldos.StandardTab = True
        dgvSaldos.RowTemplate.Height = 33
        dgvSaldos.RowTemplate.Resizable = DataGridViewTriState.False
        '
        FormataDgvSaldos()
        '
    End Sub
    '
    Private Sub FormataDgvSaldos()
        '
        ' (0) COLUNA MOVFORMA
        With clnTipo
            .HeaderText = "Meio"
            .DataPropertyName = "Meio"
            .Width = 140
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 10)
        End With
        '
        ' (1) COLUNA SALDO ANTERIOR
        With clnSaldoAnterior
            .HeaderText = "Sd Anterior"
            .DataPropertyName = "SaldoAnterior"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "C"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
        '
        ' (2) COLUNA SALDO FINAL 
        With clnSaldoFinal
            .HeaderText = "Sd Final"
            .DataPropertyName = "SaldoFinal"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "C"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (3) COLUNA A TRANSFERIR 
        With clnTransferir
            .HeaderText = "Auto Transf."
            .DataPropertyName = "ATransferir"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "C"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        Me.dgvSaldos.Columns.AddRange(New DataGridViewColumn() {
                                      clnTipo,
                                      clnSaldoAnterior,
                                      clnSaldoFinal,
                                      clnTransferir})
        '
    End Sub
    '
    Private Sub dgvSaldos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvSaldos.CellFormatting
        '
        If e.ColumnIndex = 3 Then
            If e.Value = 0 Then
                e.CellStyle.ForeColor = Color.Blue
                e.CellStyle.SelectionForeColor = Color.Blue
            Else
                e.CellStyle.ForeColor = Color.Red
                e.CellStyle.SelectionForeColor = Color.Red
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, btnFechar.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    Private Sub btnInserirDespesa_Click(sender As Object, e As EventArgs)
        '
        '--- abre o form de DespesaSimples
        Dim f As New frmDespesaSimples(_Caixa.DataInicial,
                                       _Caixa.DataFinal,
                                       _Caixa.IDConta,
                                       _Caixa.IDFilial,
                                       _Caixa.ApelidoFilial,
                                       _Caixa.IDCaixa,
                                       Me)
        '
        f.ShowDialog()
        '
        '--- se a resultado for cancel então exit
        If f.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Dim newMov As clMovimentacao = f.propMovSaida
        '
        '--- retorna os valores e insere na listagem
        bindMovs.Add(newMov)
        ObterSaldos()
        CalculaTotais()
        '
        '--- seleciona a row com o NOVO nivelamento
        Dim i As Integer = lstMov.FindIndex(Function(x) x.Descricao = newMov.Descricao)
        dgvListagem.CurrentCell = dgvListagem.Rows(i).Cells(0)
        '
    End Sub
    '
    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        Dim f As New frmCaixaInserir(_Caixa, Me)
        '
        f.ShowDialog()
        If f.DialogResult <> DialogResult.OK Then Exit Sub
        '
        _Caixa.DataFinal = f.propMaxDate
        lblDataFinal.DataBindings("Text").ReadValue()
        '
        Try
            cxBLL.Caixa_AlteraPeriodo(_Caixa.IDCaixa, _Caixa.DataFinal)
            MessageBox.Show("Período do caixa alterado com sucesso!", "Alteração do Período",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- Atualiza a listagem de Movimentacao
            obterMovimentacoes()
            CalculaTotais()
            ObterSaldos()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção inesperada ocorreu ao alterar o Período do caixa:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        '
        If propIDSituacao = 1 Then
            FinalizarCaixa()
        ElseIf propIDSituacao = 2 Then
            DesbloquearCaixa()
        End If
        '
    End Sub
    '
    '--- FUNCAO DE FINALIZAR O CAIXA
    Private Sub FinalizarCaixa()
        '
        '--- verifica se a quantidade de movimentacoes confere com a listagem
        '----------------------------------------------------------------------------------
        If Not VerificaMovs() Then Exit Sub
        '
        '--- ask the user
        '----------------------------------------------------------------------------------
        If MessageBox.Show("Deseja realmente finalizar esse Caixa?",
                           "Finalizar Caixa",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        '
        '--- verifica se caixa final do dia
        '----------------------------------------------------------------------------------
        If MessageBox.Show("Esse caixa é o ultimo caixa da conta " & _Caixa.Conta & " no dia?" &
                           vbNewLine & vbNewLine &
                           "Se SIM, a data de: " & _Caixa.DataFinal.ToShortDateString &
                           " será bloqueada para realizar novas operações..." & vbNewLine & vbNewLine &
                           "Se NÃO, essa data continuará em aberto.",
                           "Finalizar Caixa",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            _Caixa.CaixaFinalDia = True
        Else
            _Caixa.CaixaFinalDia = False
        End If
        '
        '--- Inicia AcessoDados
        Dim tranBLL As New AcessoControlBLL
        Dim dbTran As Object = tranBLL.GetNewAcessoWithTransaction()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Realiza as transferencias automaticas
            cxBLL.CaixaFinalizar_TransfereMovs(lstMov, _Caixa.IDCaixa, dbTran)
            '
            '--- Finaliza o caixa
            cxBLL.CaixaFinalizar(_Caixa, dbTran)
            '
            '--- Bloqueia todas as transaçoes ligadas ao caixa
            cxBLL.CaixaFinalizar_BloqueiaTransacoes(lstMov, dbTran)
            '
            '--- Commit Transaction
            tranBLL.CommitAcessoWithTransaction(dbTran)
            '
            '--- SET NEW Data Padrao
            If Obter_ContaPadrao() = _Caixa.IDConta Then
                '
                '--- define new conta datapadrao
                Dim myDate As Date = _Caixa.DataFinal
                '
                If _Caixa.CaixaFinalDia = True Then
                    '
                    '--- add one day if final do dia
                    myDate = myDate.AddDays(1)
                    '
                    '--- if sunday add one day
                    If myDate.DayOfWeek = DayOfWeek.Sunday Then
                        myDate = myDate.AddDays(1)
                    End If
                    '
                End If
                '
                DirectCast(ParentForm, frmPrincipal).propDataPadrao = myDate
                SetarDefault("DataPadrao", myDate)
                '
            End If
            '
            '--- SUCCESS USER MESSAGE
            MessageBox.Show("Caixa Finalizado com sucesso...", "Finalizar Caixa",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- CLOSE FORM
            Close()
            MostraMenuPrincipal()
            '
        Catch ex As Exception
            '
            tranBLL.RollbackAcessoWithTransaction(dbTran)
            '
            MessageBox.Show("Uma exceção ocorreu ao Finalizar o Caixa..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- VERIFICA A CONSISTENCIA DAS MOVIMENTACOES ANTES DE FINALIZAR
    '--- SE TODAS AS MOVS DA CONTA NO PERIODO ESTAO INCLUIDAS NO CAIXA
    '----------------------------------------------------------------------------------
    Private Function VerificaMovs() As Boolean
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim total As Integer = cxBLL.CountMovsCaixa(_Caixa)
            '
            If lstMov.Count <> total Then
                MessageBox.Show("A quantidade de movimentações é diferente da quantidade existente na listagem..." &
                                vbNewLine &
                                "Alguma movimentação foi incluída na conta depois de iniciar o caixa atual." &
                                vbNewLine &
                                "Favor fechar e abrir novamente para obter todas a movimentações.",
                                "Movimentações",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a quantidade de movimentações..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Function
    '
    '--- FUNCAO DE DESBLOQUEAR O CAIXA
    Private Sub DesbloquearCaixa()
        '
        If MessageBox.Show("Deseja realmente DESBLOQUEAR esse Caixa?",
                           "Desbloquear Caixa",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        '
        '--- verifica se existe outro caixa na mesma conta depois desse
        '-----------------------------------------------------------------------------------------------
        If VerificaUltimoCaixa() = False Then
            MessageBox.Show("Esse caixa NÃO poderá ser DESBLOQUEADO já que existe um ou mais outros caixas " &
                            "na mesma conta que foram efetuados após esse caixa...", "Desbloqueio",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '
        '--- verifica se existe caixa fechado nas contas de transferencias padrao
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim myRetErroMsn As String = ""
            '
            If Not cxBLL.VerificaBloqueioContaTransf(lstMov, myRetErroMsn) Then
                Throw New Exception(myRetErroMsn)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao verificar bloqueio de conta transferencia padrao..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- efetua o desbloqueio
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            cxBLL.DesbloquearCaixa(propCaixa.IDCaixa)
            '
            propCaixa.IDSituacao = 1
            propIDSituacao = 1
            '
            '--- Atualiza a listagem de Movimentacao
            obterMovimentacoes()
            CalculaTotais()
            ObterSaldos()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao DESBLOQUEAR o caixa..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub btnExcluirCaixa_Click(sender As Object, e As EventArgs) Handles btnExcluirCaixa.Click
        '
        If MessageBox.Show("Deseja realmente EXCLUIR esse Caixa?" & vbNewLine & vbNewLine &
                           "Essa operação não tem como VOLTAR atrás...",
                           "Excluir Caixa",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '--- verifica se existe outro caixa na mesma conta depois desse
        '-----------------------------------------------------------------------------------------------
        If VerificaUltimoCaixa() = False Then
            MessageBox.Show("Esse caixa NÃO poderá ser EXCLUÍDO já que existe um ou mais caixas " &
                            "após esse caixa, dessa mesma conta...", "Desbloqueio",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                cxBLL.ExcluirCaixa(propCaixa.IDCaixa)
                Close()
                MostraMenuPrincipal()
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao tentar EXCLUIR o Caixa ..." & vbNewLine &
                                ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        '
    End Sub
    '
    '--- SALVA A OBSERVACAO DO CAIXA
    Private Sub btnSalvarObservacao_Click(sender As Object, e As EventArgs) Handles btnSalvarObservacao.Click
        '
        Try
            '
            If SalvarCaixa() Then
                MessageBox.Show("Observação salva com sucesso!", "Caixa",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtObservacao.Focus()
                btnSalvarObservacao.Visible = False
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao atualizar a observação do Caixa..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- SALVA FUNCIONARIO OPERADOR DE CAIXA
    Private Sub btnFuncionarioAlterar_Click(sender As Object, e As EventArgs) Handles btnFuncionarioAlterar.Click
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        Dim fFunc As New frmFuncionarioProcurar(False, Me)
        Cursor = Cursors.Default
        '
        fFunc.ShowDialog()
        If fFunc.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Try
            '
            Dim newID As Integer = fFunc.IDEscolhido
            '
            '--- se for o mesmo Funcionario
            If newID = If(_Caixa.IDFuncionario, 0) Then Return
            '
            '--- define o novo operador de caixa
            _Caixa.IDFuncionario = newID
            lblApelidoFuncionario.Text = fFunc.NomeEscolhido
            '
            If SalvarCaixa() Then
                MessageBox.Show("Operador de Caixa salvo com sucesso!", "Caixa",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao atualizar o Operador de Caixa..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Function SalvarCaixa() As Boolean
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If cxBLL.UpdateCaixa(_Caixa) Then
                Return True
            Else
                Return False
            End If
            '
        Catch ex As Exception
            Throw ex
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
#Region "FUNCOES IMPORTANTES"
    '
    Private Sub CalculaTotais()
        '
        Dim E As Double = 0
        Dim S As Double = 0
        Dim Transf As Double = 0
        '
        For Each cl As clMovimentacao In lstMov
            '
            If cl.Mov = "E" Then
                E = E + cl.MovValor
            ElseIf cl.Mov = "S" Then
                S = S + cl.MovValor
            Else
                Transf = Transf + cl.MovValorReal
            End If
            '
            _TEntradas = E
            lblTEntradas.Text = Format(E, "C")
            _TSaidas = S
            lblTSaidas.Text = Format(S, "C")
            _TTransf = Transf
            lblTTransf.Text = Format(Transf, "C")
            '
            '--- Calcula SALDOS
            _Caixa.SaldoFinal = _TEntradas + _TTransf - _TSaidas
            lblSaldoFinal.Text = Format(_Caixa.SaldoFinal, "C")
            '
            If _Caixa.SaldoFinal >= 0 Then
                lblSaldoFinal.ForeColor = Color.Blue
            Else
                lblSaldoFinal.ForeColor = Color.Red
            End If
            '
        Next
        '
    End Sub
    '
    '--- TROCAR A COR DO CAMPO QUANDO FOCUS
    Private Sub txtObservacao_GotFocus(sender As Object, e As EventArgs) Handles txtObservacao.GotFocus
        txtObservacao.BackColor = Color.White
    End Sub
    '
    Private Sub txtObservacao_LostFocus(sender As Object, e As EventArgs) Handles txtObservacao.LostFocus
        txtObservacao.BackColor = SystemColors.Control
    End Sub
    '
    '--- MOSTRA BTN SALVAR OBSERVACAO
    Private Sub txtObservacao_TextChanged(sender As Object, e As EventArgs) Handles txtObservacao.TextChanged
        '
        If Not CanFocus Then Exit Sub
        '
        If txtObservacao.Text.Length > 0 Then
            btnSalvarObservacao.Visible = True
        Else
            btnSalvarObservacao.Visible = False
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacao.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- VERIFICA SE EXISTE OUTRO CAIXA INICIADO APOS O CAIXA INFORMADO
    Private Function VerificaUltimoCaixa() As Boolean
        '
        '--- verifica se o caixa atual é o ultimo caixa dessa conta
        '--- retorna TRUE se realmente for o ultimo caixa retorna TRUE
        '-----------------------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- GET datas inicial e Final
            Dim dt As DataTable = cxBLL.GetLastDados_IDConta(propCaixa.IDConta)
            Dim r As DataRow = dt.Rows(0)
            '
            Dim LastIDCaixa As Integer = IIf(IsDBNull(r("LastIDCaixa")), Nothing, r("LastIDCaixa"))
            '
            If Not IsNothing(LastIDCaixa) AndAlso LastIDCaixa <> propCaixa.IDCaixa Then
                Return False
            Else
                Return True
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao tentar obter o ultimo Caixa da Conta..." & vbNewLine &
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
#Region "MENU SUSPENSO SALDOS"
    '
    ' CONTROLE DO MENU SUSPENSO
    Private Sub dgvSaldos_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvSaldos.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            '
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvSaldos.HitTest(e.X, e.Y)
            dgvSaldos.ClearSelection()
            '
            '---VERIFICAÇÕES NECESSÁRIAS
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvSaldos.Rows(hit.RowIndex).Cells(0).Selected = True
            dgvSaldos.Rows(hit.RowIndex).Selected = True
            '
            ' mostra o menu nivelamento
            Dim r As DataRowView = dgvSaldos.Rows(hit.RowIndex).DataBoundItem
            '
            If propIDSituacao = 1 Then ' AndAlso r("IDOperadora") = 1
                '
                If r("Nivelamento") = True Then
                    miExcluirNivelamento.Enabled = True
                    miInserirNivelamento.Enabled = True
                Else
                    miExcluirNivelamento.Enabled = False
                    miInserirNivelamento.Enabled = True
                End If
                '
            Else
                miExcluirNivelamento.Enabled = False
                miInserirNivelamento.Enabled = False
            End If
            '
            ' revela menu
            MenuSaldos.Show(c.PointToScreen(e.Location))
            '
        End If
        '
    End Sub
    '
    Private Sub miInserirNivelamento_Click(sender As Object, e As EventArgs) Handles miInserirNivelamento.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvSaldos.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- Verifica se existe valor que nao sera transferido
        Dim r As DataRowView = dgvSaldos.CurrentRow.DataBoundItem
        Dim ValorAtual As Double = r("SaldoFinal") - If(IsDBNull(r("ATransferir")), 0, r("ATransferir"))
        '
        If ValorAtual = 0 Then
            AbrirDialog("Todo o valor do saldo desse item será transferido para outra Conta..." & vbNewLine &
                        "Não é possível realizar Nivelamento, porque o saldo restante será Nulo.",
                        "Saldo Transferido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Return
        End If
        '
        '--- Verifica se já houve um nivelamento efetuado com o mesmo IDMeio
        If r("Nivelamento") = True Then
            '
            '--- percorre pela lista de movimentacoes do caixa
            For Each c As clMovimentacao In lstMov
                If c.Descricao.ToString.Contains("Nivelamento") Then
                    If c.IDMovTipo = r("IDMeio") Then
                        AbrirDialog("Já existe um Nivelamento efetuado nesse mesmo Meio de Movimentação." & vbNewLine &
                                    "Se deseja realizar Novo Nivelamento, exclua todos os outros anteriores...",
                                    "Nivelamento Duplicado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                        '
                        '--- selçeciona a row com o nivelamento duplicado
                        Dim i As Integer = lstMov.IndexOf(c)
                        '
                        dgvListagem.CurrentCell = dgvListagem.Rows(i).Cells(0)
                        '
                        Exit Sub
                    End If
                End If
            Next
            '
        End If
        '
        '--- abre o frmNivelamento
        Dim frmN As New frmNivelamento(ValorAtual, r("Conta"), r("Meio"))
        '
        frmN.ShowDialog()
        '
        '--- verifica o resultado do form
        If frmN.DialogResult <> DialogResult.OK Then Exit Sub
        '
        '--- recupera os valores
        Dim myNivValor As Decimal = frmN.PropNivValor_Escolhido
        '
        '--- salva o nivelamento
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newMov As clMovimentacao = cxBLL.InserirNivelamento(_Caixa.IDCaixa, r("IDMeio"), myNivValor)
            '
            '--- retorna os valores e insere na listagem
            bindMovs.Add(newMov)
            ObterSaldos()
            CalculaTotais()
            '
            '--- seleciona a row com o NOVO nivelamento
            Dim i As Integer = lstMov.FindIndex(Function(x) x.Descricao = newMov.Descricao)
            dgvListagem.CurrentCell = dgvListagem.Rows(i).Cells(0)
            '
            r("Nivelamento") = True
            '
            '--- seleciona o nivelamento no datagrid
            dgvSaldos.CurrentCell = dgvSaldos.Rows(dgvSaldos.Rows.Count - 1).Cells(0)

        Catch ex As Exception
            MessageBox.Show("Uma execeção ocorreu ao Inserir Nivelamento..." & vbNewLine &
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
    Private Sub miExcluirNivelamento_Click(sender As Object, e As EventArgs) Handles miExcluirNivelamento.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvSaldos.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- pergunta ao usuário
        '
        Dim r As DataRowView = dgvSaldos.CurrentRow.DataBoundItem
        '
        If MessageBox.Show("Você deseja excluir todos os nivelamentos desse caixa?" & vbNewLine &
                           r("Meio").ToString.ToUpper, "Excluir Nivelamentos",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Exit Sub
        '
        '--- DELETE NIVELAMENTO
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim resp As Boolean = cxBLL.ExcluirNivelamentos(lstMov)
            '
            '--- retorna os valores e insere na listagem
            If resp = False Then Exit Sub
            '
            obterMovimentacoes()
            bindMovs.ResetBindings(False)
            CalculaTotais()
            ObterSaldos()
            '
            MessageBox.Show("Nivelamentos removidos com sucesso...",
                            "Nivelamentos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma execeção ocorreu ao Excluir Nivelamentos..." & vbNewLine &
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
#Region "MENU SUSPENSO INSERIR"
    '
    ' CONTROLE DO MENU SUSPENSO
    Private Sub dgvListagem_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvListagem.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            '
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvListagem.HitTest(e.X, e.Y)
            dgvListagem.ClearSelection()
            '
            '---VERIFICAÇÕES NECESSÁRIAS
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvListagem.Rows(hit.RowIndex).Cells(0).Selected = True
            dgvListagem.Rows(hit.RowIndex).Selected = True
            '
            ' mostra o menu nivelamento
            Dim mov As clMovimentacao = dgvListagem.Rows(hit.RowIndex).DataBoundItem
            '
            ' mostra o menu nivelamento
            '
            If propIDSituacao = 1 Then '--- Enabled IF only Situacao = 1 
                '
                If mov.Origem <> 3 Then '--- ORIGEM <> 3 => NOT Origem Caixa
                    '
                    miInserirEntrada.Enabled = True
                    miInserirDespesas.Enabled = True
                    miExcluirEntrada.Enabled = False
                    miExcluirNivelamentoLista.Enabled = False
                    '
                Else '--- ORIGEM = 3 => Origem Caixa
                    '
                    miInserirEntrada.Enabled = False
                    miInserirDespesas.Enabled = False
                    '
                    '--- check if is ENTRADA or NIVELAMENTO
                    If mov.Mov = "E" AndAlso Not mov.Descricao.ToString.Contains("Nivelamento") Then
                        miExcluirEntrada.Enabled = True '--- ENABLE Excluir Entrada
                        miExcluirNivelamentoLista.Enabled = False '--- DISABLE Excluir Nivelamento
                    Else
                        miExcluirEntrada.Enabled = False '--- DISABLE Excluir Entrada
                        miExcluirNivelamentoLista.Enabled = True '--- ENABLE Excluir Nivelamento
                    End If
                    '
                End If
                '
            Else
                '
                miInserirEntrada.Enabled = False
                miInserirDespesas.Enabled = False
                '
            End If
            '
            ' revela menu
            mnuInserir.Show(c.PointToScreen(e.Location))
            '
        End If
        '
    End Sub
    '
    '--- INSERIR ENTRADA SIMPLES
    '----------------------------------------------------------------------------------
    Private Sub miInserirEntrada_Click(sender As Object, e As EventArgs) Handles miInserirEntrada.Click
        '
        '--- abre o frmEntrada
        Dim frmE As New frmCaixaEntradaSimples(_Caixa.Conta)
        '
        frmE.ShowDialog()
        '
        '--- verifica o resultado do form
        If frmE.DialogResult <> DialogResult.OK Then Exit Sub
        '
        '--- recupera os valores
        Dim myEntradaValor As Decimal = frmE.PropValor_Escolhido
        Dim myDescricao As String = frmE.PropDescricao
        '
        '--- insere a Entrada
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim newMov As clMovimentacao = cxBLL.InserirEntradaSimplesCaixa(_Caixa.IDCaixa, myEntradaValor, myDescricao)
            '
            '--- retorna os valores e insere na listagem
            bindMovs.Add(newMov)
            ObterSaldos()
            CalculaTotais()
            '
            '--- seleciona a row com o NOVA entrada
            Dim i As Integer = lstMov.FindIndex(Function(x) x.Descricao = newMov.Descricao)
            dgvListagem.CurrentCell = dgvListagem.Rows(i).Cells(0)
            '
            '--- seleciona o entrada no datagrid
            dgvSaldos.CurrentCell = dgvSaldos.Rows(dgvSaldos.Rows.Count - 1).Cells(0)

        Catch ex As Exception
            MessageBox.Show("Uma execeção ocorreu ao Inserir Entrada..." & vbNewLine &
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
    '--- INSERIR DESPESA
    '----------------------------------------------------------------------------------
    Private Sub miInserirDespesas_Click(sender As Object, e As EventArgs) Handles miInserirDespesas.Click
        '
        '--- abre o form de DespesaSimples
        Dim f As New frmDespesaSimples(_Caixa.DataInicial,
                                       _Caixa.DataFinal,
                                       _Caixa.IDConta,
                                       _Caixa.IDFilial,
                                       _Caixa.ApelidoFilial,
                                       _Caixa.IDCaixa,
                                       Me)
        '
        f.ShowDialog()
        '
        '--- se a resultado for cancel então exit
        If f.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Dim newMov As clMovimentacao = f.propMovSaida
        '
        '--- retorna os valores e insere na listagem
        bindMovs.Add(newMov)
        ObterSaldos()
        CalculaTotais()
        '
        '--- seleciona a row com o NOVO nivelamento
        Dim i As Integer = lstMov.FindIndex(Function(x) x.Descricao = newMov.Descricao)
        dgvListagem.CurrentCell = dgvListagem.Rows(i).Cells(0)
        '
    End Sub
    '
    '--- EXCLUIR NIVELAMENTO ESPECIFICO
    '----------------------------------------------------------------------------------
    Private Sub miExcluirNivelamentoLista_Click(sender As Object, e As EventArgs) Handles miExcluirNivelamentoLista.Click
        '
        '--- pergunta ao usuário
        '
        Dim mov As clMovimentacao = dgvListagem.CurrentRow.DataBoundItem
        '
        If AbrirDialog("Você deseja EXCLUIR o seguinte NIVELAMENTO de CAIXA?" & vbNewLine & vbNewLine &
                        mov.Descricao & vbNewLine &
                        Format(mov.MovValor, "C"), "Excluir Nivelamento",
                        frmDialog.DialogType.SIM_NAO, frmDialog.DialogIcon.Question,
                        frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Exit Sub
        '
        '--- DELETE NIVELAMENTO
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim resp As Boolean = cxBLL.ExcluirNivelamentos(lstMov.FindAll(Function(x) x.IDMovimentacao = mov.IDMovimentacao))
            '
            '--- retorna os valores e insere na listagem
            If resp = False Then Exit Sub
            '
            obterMovimentacoes()
            bindMovs.ResetBindings(False)
            CalculaTotais()
            ObterSaldos()
            '
            MessageBox.Show("Nivelamentos removidos com sucesso...",
                            "Nivelamento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma execeção ocorreu ao Excluir Nivelamentos..." & vbNewLine &
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
    '--- EXCLUIR ENTRADA
    '----------------------------------------------------------------------------------
    Private Sub miExcluirEntrada_Click(sender As Object, e As EventArgs) Handles miExcluirEntrada.Click
        '
        '--- pergunta ao usuário
        Dim mov As clMovimentacao = dgvListagem.CurrentRow.DataBoundItem
        '
        If AbrirDialog("Você deseja EXCLUIR a seguinte ENTRADA de CAIXA?" & vbNewLine & vbNewLine &
                        mov.Descricao & vbNewLine &
                        Format(mov.MovValor, "C"), "Excluir Entrada",
                        frmDialog.DialogType.SIM_NAO, frmDialog.DialogIcon.Question,
                        frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Exit Sub
        '
        '--- DELETE ENTRADA
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim resp As Boolean = cxBLL.ExcluirEntradaSimplesCaixa(mov)
            '
            '--- retorna os valores e insere na listagem
            If resp = False Then
                AbrirDialog("Por algum motivo desconhecido, nenhuma entrada foi removida...",
                            "Exceção",
                            frmDialog.DialogType.OK,
                            frmDialog.DialogIcon.Exclamation)
                Exit Sub
            End If
            '
            obterMovimentacoes()
            bindMovs.ResetBindings(False)
            CalculaTotais()
            ObterSaldos()
            '
            MessageBox.Show("Entrada removida com sucesso...",
                            "Entrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma execeção ocorreu ao Remover Entrada..." & vbNewLine &
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
#End Region '/ MENU SUSPENSO INSERIR
    '
End Class
