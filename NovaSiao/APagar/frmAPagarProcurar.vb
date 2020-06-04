Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmAPagarProcurar
	Private pagLista As New List(Of clAPagar)
	Private _myMes As Date
	Private SituacaoAtual As Byte? '--- property
	Private dtInicial As Date
	Private dtFinal As Date
	Private _HabilitaPesquisa As Boolean = False
	'
#Region "PROPERTY E EVENTO LOAD"
	'
	Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		myMes = ObterDefault("DataPadrao")
		FormataListagem()
		propSituacaoAtual = 0 '--> SITUACAO EMABERTO
		'
		pnlMes.Location() = New Point(722, 145)
		'
		CarregaCmbCobrancaForma()
		CarregaCmbSitucao()
		'
		AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
		AddHandler cmbCobrancaForma.SelectedIndexChanged, AddressOf cmbCobrancaForma_SelectedIndexChanged
		AddHandler rbtPorMes.CheckedChanged, AddressOf rbt_CheckedChanged
		AddHandler rbtPorPeriodo.CheckedChanged, AddressOf rbt_CheckedChanged
		AddHandler rbtTodas.CheckedChanged, AddressOf rbt_CheckedChanged
		'
	End Sub
	'
	Private Property myMes() As Date
		'
		Get
			Return _myMes
		End Get
		'
		Set(ByVal value As Date)
			'
			dtInicial = Utilidades.FirstDayOfMonth(value)
			dtFinal = Utilidades.LastDayOfMonth(value)
			'
			_myMes = value
			lblPeriodo.Text = Format(_myMes, "MMMM | yyyy")
			lblDtInicial.Text = Format(dtInicial, "dd/MM")
			lblDtFinal.Text = Format(dtFinal, "dd/MM")
			'
		End Set
		'
	End Property
	'
	Public Property propSituacaoAtual() As Byte?
		Get
			'
			Return SituacaoAtual
			'
		End Get
		'
		Set(ByVal value As Byte?)
			'
			SituacaoAtual = value
			Get_Dados()
			'
		End Set
		'
	End Property
	'
	'--- HABILITAR PROCURA DE DADOS
	Public Property propHabilitaPesquisa() As Boolean
		'
		Get
			Return _HabilitaPesquisa
		End Get
		'
		Set(ByVal value As Boolean)
			'
			If value <> _HabilitaPesquisa Then
				'
				If value = True Then
					'
					btnProcurar.Enabled = True
					dgvListagem.Columns.Clear()
					'
				Else
					btnProcurar.Enabled = False
				End If
				'
			End If
			'
			'--- Define o TOOLTIP
			If value = True Then
				'
				Dim toolTip1 As New ToolTip
				' Define o delay para a ToolTip.
				With toolTip1
					.AutoPopDelay = 2000
					.InitialDelay = 1000
					.ReshowDelay = 500
					.IsBalloon = True
					.UseAnimation = True
					.UseFading = True
				End With
				toolTip1.Show("Pressione AQUI...", btnProcurar, btnProcurar.Width - 30, -40, 1000)
				'
			End If
			'
			_HabilitaPesquisa = value
			'
		End Set
		'
	End Property
	'
#End Region
	'
#Region "PREENCHE TRATA COMBO"
	'
	'-------------------------------------------------------------------------------------------------
	' PREENCHE COMBO
	'-------------------------------------------------------------------------------------------------
	Private Sub CarregaCmbCobrancaForma()
		Dim pg As New APagarBLL
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim dtForma As DataTable = pg.CobrancaFormas_APagar_GET
			dtForma.Rows.Add({0, "TODAS FORMAS"})
			'
			With cmbCobrancaForma
				.DataSource = dtForma
				.ValueMember = "IDCobrancaForma"
				.DisplayMember = "CobrancaForma"
				.SelectedValue = 0
			End With
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao obter a lista de Formas Pagamento..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- COMBO SITUACAO
	'----------------------------------------------------------------------------------
	Private Sub CarregaCmbSitucao()
		Dim dtS As New DataTable
		'
		' Adiciona todas as possibilidades
		dtS.Columns.Add("IDSituacao")
		dtS.Columns.Add("Situacao")
		dtS.Rows.Add(New Object() {0, "Em Aberto"})
		dtS.Rows.Add(New Object() {1, "Quitadas"})
		dtS.Rows.Add(New Object() {2, "Canceladas"})
		dtS.Rows.Add(New Object() {3, "Negativadas"})
		dtS.Rows.Add(New Object() {4, "Negociadas"})
		dtS.Rows.Add(New Object() {5, "Todas"})
		'
		With cmbSituacao
			.DataSource = dtS
			.ValueMember = "IDSituacao"
			.DisplayMember = "Situacao"
			.SelectedValue = 0
		End With
		'
	End Sub
	'
	'--- AO ALTERAR SITUACAO
	'----------------------------------------------------------------------------------
	Private Sub cmbSituacao_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSituacao.SelectionChangeCommitted
		propSituacaoAtual = CByte(cmbSituacao.SelectedValue)
	End Sub
	'
#End Region
	'
#Region "LISTAGEM CONFIGURAÇÃO"
	'
	Private Sub FormataListagem()
		'
		dgvListagem.AutoGenerateColumns = False
		'
		' altera as propriedades importantes
		dgvListagem.MultiSelect = False
		dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvListagem.ColumnHeadersVisible = False
		dgvListagem.AllowUserToResizeRows = False
		dgvListagem.AllowUserToResizeColumns = False
		dgvListagem.RowHeadersVisible = True
		dgvListagem.RowHeadersWidth = 30
		dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
		dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
		dgvListagem.StandardTab = True
		'
	End Sub
	'
	Private Sub Get_Dados()
		'
		Dim pagBLL As New APagarBLL
		'
		'--- Verifica o IDCobrancaForma
		Dim myIDCobrancaForma As Int16?
		'
		If cmbCobrancaForma.SelectedIndex = -1 OrElse cmbCobrancaForma.SelectedValue = 0 Then
			myIDCobrancaForma = Nothing
		Else
			myIDCobrancaForma = cmbCobrancaForma.SelectedValue
		End If
		'
		'--- Verifica o IDFilial
		Dim myFilial As Integer = Obter_FilialPadrao()
		'
		'--- Verifica a Situacao
		Dim Situacao As Byte? = Nothing
		If Not IsNothing(propSituacaoAtual) Then Situacao = propSituacaoAtual
		'
		'--- consulta o banco de dados
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- verifica o filtro das datas
			If rbtTodas.Checked = True Then
				pagLista = pagBLL.GetAPagarLista_Procura(myFilial,
														 txtCredorCadastro.Text,
														 True, False,
														 myIDCobrancaForma,
														 Nothing, Nothing,
														 Situacao)
			Else
				'
				pagLista = pagBLL.GetAPagarLista_Procura(myFilial,
														 txtCredorCadastro.Text,
														 True, False,
														 myIDCobrancaForma,
														 dtInicial, dtFinal,
														 Situacao)
			End If
			'
			'--- define o souce da listagem
			dgvListagem.DataSource = pagLista
			'
			propHabilitaPesquisa = False
			'
			PreencheListagem()
			CalculaTotais()
			'
		Catch ex As Exception
			MessageBox.Show("Ocorreu exceção ao obter a lista de A Pagar..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- CALCULA OS TOTAIS E ALTERA AS LABELS
	'----------------------------------------------------------------------------------
	Private Sub CalculaTotais()
		'
		Dim vlTotal As Decimal = pagLista.Sum(Function(x) x.APagarValor)
		Dim vlPago As Decimal = pagLista.Sum(Function(x) x.ValorPago)
		'
		lblValorTotal.Text = Format(vlTotal, "C")
		lblPagoTotal.Text = Format(vlPago, "C")
		lblEmAbertoTotal.Text = Format(vlTotal - vlPago, "C")
		'
	End Sub
	'
	Private Sub PreencheListagem()
		'
		'--- limpa as colunas do datagrid
		dgvListagem.Columns.Clear()
		'
		' (0) COLUNA VENCIMENTO
		dgvListagem.Columns.Add("clnVencimento", "Vencto")
		With dgvListagem.Columns("clnVencimento")
			.DataPropertyName = "Vencimento"
			.Width = 100
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			'.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
		End With
		'
		' (1) COLUNA CREDOR
		dgvListagem.Columns.Add("clnCadastro", "Credor/Fornecedor")
		With dgvListagem.Columns("clnCadastro")
			.DataPropertyName = "Cadastro"
			.Width = 280
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' (2) COLUNA ORIGEM
		dgvListagem.Columns.Add("clnOrigemTexto", "Origem")
		With dgvListagem.Columns("clnOrigemTexto")
			.DataPropertyName = "OrigemTexto"
			.Width = 150
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' (3) COLUNA FORMA
		dgvListagem.Columns.Add("clnCobrancaForma", "Forma de Cobranca")
		With dgvListagem.Columns("clnCobrancaForma")
			.DataPropertyName = "CobrancaForma"
			.Width = 150
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' (4) COLUNA VALOR
		dgvListagem.Columns.Add("clnAPagarValor", "Valor")
		With dgvListagem.Columns("clnAPagarValor")
			.DataPropertyName = "APagarValor"
			.Width = 100
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
		End With
		'
		' (5) COLUNA VALORPAGO
		dgvListagem.Columns.Add("clnValorPago", "Pago")
		With dgvListagem.Columns("clnValorPago")
			.DataPropertyName = "ValorPago"
			.Width = 100
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Format = "C"
		End With
		'
		' (6) COLUNA SITUAÇÃO
		dgvListagem.Columns.Add("clnSituacao", "Situacao")
		With dgvListagem.Columns("clnSituacao")
			.DataPropertyName = "SituacaoDescricao"
			.Width = 80
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
	End Sub
	'
	Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
		'
		If DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clAPagar).Origem = 3 And
			IsNothing(DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clAPagar).IDAPagar) Then
			dgvListagem.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
			dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Yellow
		Else
			dgvListagem.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
			dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
		End If
		'
		'--- Define o texto do APAGAR quando esta VENCIDO
		If e.ColumnIndex = 6 AndAlso e.Value = "Em Aberto" Then
			Dim dtVenc As Date = dgvListagem.Rows(e.RowIndex).Cells(0).Value
			If dtVenc < Date.Today Then
				e.Value = "Vencida"
				e.CellStyle.ForeColor = Color.Red
			End If
		End If
		'
	End Sub
	'
#End Region
	'
#Region "ACAO DOS BOTOES"
	'
	Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
		'
		If dgvListagem.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhum A Pagar selecionado na listagem", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If
		'
		Dim clP As clAPagar = dgvListagem.SelectedRows(0).DataBoundItem
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim f As New frmAPagarSaidas(clP, Me)
			f.ShowDialog()
			'
			'--- Se retornar DIALOGRESULT = OK THEN
			If f.DialogResult <> DialogResult.Cancel Then
				FormataListagem()
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir formulário de pagamento..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
		'
		Get_Dados()
		dgvListagem.Focus()
		'
		If pagLista.Count = 0 Then
			MessageBox.Show("Nenhuma A Pagar encontrado nessas condições...", "Procurar",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
		'
	End Sub
	'
	Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

		If dgvListagem.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhum A Pagar selecionado na listagem", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If
		'
		Dim clP As clAPagar = dgvListagem.SelectedRows(0).DataBoundItem
		'
		If clP.Origem = 1 Then '--- A Origem é transacao de compras
			Dim cBLL As New CompraBLL
			'
			Dim clC As clCompra = cBLL.GetCompra_PorID_OBJ(clP.IDOrigem)
			'
			Dim frm = New frmCompra(clC)
			frm.MdiParent = frmPrincipal
			frm.StartPosition = FormStartPosition.CenterScreen
			Close()
			frm.Show()
		ElseIf clP.Origem = 2 Then '--- A Origem é Despesa
			Dim dBLL As New DespesaBLL
			'
			Dim clD As clDespesa = dBLL.GetDespesa_PorID(clP.IDOrigem)
			'
			Dim frm As New frmDespesa(clD)
			frm.MdiParent = frmPrincipal
			frm.StartPosition = FormStartPosition.CenterScreen
			Close()
			frm.Show()
		ElseIf clP.Origem = 3 Then '--- A Origem é DespesaPeriodica
			Dim dBLL As New DespesaPeriodicaBLL
			'
			Dim clD As clDespesaPeriodica = dBLL.GetDespesaPeriodica_PorID(clP.IDOrigem)
			'
			Dim frm As New frmDespesaPeriodica(clD)
			frm.MdiParent = frmPrincipal
			frm.StartPosition = FormStartPosition.CenterScreen
			Close()
			frm.Show()
		End If
		'
	End Sub
	'
	Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
		Close()
		MostraMenuPrincipal()
	End Sub
	'
	Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
		btnQuitar_Click(New Object, New EventArgs)
	End Sub
	'
	Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim frmPrint As New frmAPagarListPrint(pagLista)
			frmPrint.ShowDialog()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir relatório de A Pagar..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
#End Region
	'
#Region "CONTROLES GERAIS | FLUXO"
	'
	'--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
	Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
		If e.KeyCode = Keys.Enter Then
			e.Handled = True
			'
			btnQuitar_Click(New Object, New EventArgs)
		End If
	End Sub
	'
	'--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
	Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCredorCadastro.KeyDown
		'
		If e.KeyCode = Keys.Enter Then
			e.SuppressKeyPress = True
			PreencheListagem()
			SendKeys.Send("{Tab}")
		End If
		'
	End Sub
	'
	Private Sub txtDescricao_TextChanged(sender As Object, e As EventArgs) Handles txtCredorCadastro.TextChanged
		'
		If propHabilitaPesquisa = False Then propHabilitaPesquisa = True
		'
	End Sub
	'
	Private Sub cmbCobrancaForma_SelectedIndexChanged(sender As Object, e As EventArgs)
		'
		If propHabilitaPesquisa = False Then propHabilitaPesquisa = True
		'
	End Sub
	'
#End Region
	'
#Region "CONTROLE DO PERÍODO"
	'
	Private Sub btnPeriodoAnterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoAnterior.Click
		myMes = myMes.AddMonths(-1)
		dtMes.SelectionStart = myMes
	End Sub
	'
	Private Sub btnPeriodoPosterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoPosterior.Click
		'
		myMes = myMes.AddMonths(1)
		dtMes.SelectionStart = myMes
		'
	End Sub
	'
	Private Sub btnMesAtual_Click(sender As Object, e As EventArgs) Handles btnMesAtual.Click
		myMes = Now
		dtMes.SelectionStart = myMes
		btnPeriodoPosterior.Enabled = False
	End Sub
	'
	Private Sub dtMes_DateChanged(sender As Object, e As DateRangeEventArgs)
		'
		myMes = e.Start
		lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
		propHabilitaPesquisa = True
		'
	End Sub
	'
	Private Sub lblPerido_Click(sender As Object, e As EventArgs) Handles lblPeriodo.Click
		pnlMes.Visible = True
		dtMes.Focus()
	End Sub
	'
	Private Sub pnlMes_Leave(sender As Object, e As EventArgs) Handles pnlMes.MouseLeave, dtMes.LostFocus
		pnlMes.Visible = False
	End Sub
	'
	Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs)
		'
		If rbtTodas.Checked = True Then
			pnlPorMes.Visible = False
			pnlPorPeriodo.Visible = False
		ElseIf rbtPorMes.Checked = True Then
			pnlPorMes.Visible = True
			pnlPorPeriodo.Visible = False
			myMes = dtInicial
		ElseIf rbtPorPeriodo.Checked = True Then
			pnlPorMes.Visible = False
			pnlPorPeriodo.Visible = True
		End If
		'
		If Not propHabilitaPesquisa Then propHabilitaPesquisa = True
		'
	End Sub
	'
	'--- FORM PARA ESCOLHA DAS DATAS INICIAL E FINAL
	'----------------------------------------------------------------------------------
	Private Sub btnDtInicial_Click(sender As Object, e As EventArgs) Handles btnDtInicial.Click, btnDtFinal.Click
		'
		Dim IsDtInicial As Boolean = If(DirectCast(sender, Button).Name = "btnDtInicial", True, False)
		'
		Dim frm As New frmDataInformar(If(IsDtInicial, "Escolha a Data Inicial", "Escolha a Data Final"),
									   EnumDataTipo.PassadoOuFuturo,
									   If(IsDtInicial, dtInicial, dtFinal), Me)
		frm.ShowDialog()
		'
		If frm.DialogResult = DialogResult.Cancel Then Exit Sub
		'
		'--- define a data selecionada
		If IsDtInicial Then
			dtInicial = frm.propDataInfo
			lblDtInicial.Text = Format(dtInicial, "dd/MM")
			'
			'--- verifica se a data final é menor que a data inicial
			If dtFinal < dtInicial Then
				dtFinal = dtInicial
				lblDtFinal.Text = Format(dtFinal, "dd/MM")
			End If
			'
		Else
			dtFinal = frm.propDataInfo
			lblDtFinal.Text = Format(dtFinal, "dd/MM")
			'
			'--- verifica se a data final é menor que a data inicial
			If dtInicial > dtFinal Then
				dtInicial = dtFinal
				lblDtInicial.Text = Format(dtInicial, "dd/MM")
			End If
			'
		End If
		'
		propHabilitaPesquisa = True
		'
	End Sub
	'
#End Region
	'
#Region "MENU SUSPENSO"
	'
	Private Sub dgvListagem_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvListagem.MouseDown
		If e.Button = MouseButtons.Right Then
			Dim c As Control = DirectCast(sender, Control)
			Dim hit As DataGridView.HitTestInfo = dgvListagem.HitTest(e.X, e.Y)
			dgvListagem.ClearSelection()

			If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub

			' seleciona o ROW
			dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			dgvListagem.CurrentCell = dgvListagem.Rows(hit.RowIndex).Cells(2)
			dgvListagem.Rows(hit.RowIndex).Selected = True

			' mostra o MENU ativar e desativar
			Dim pagItem As clAPagar = DirectCast(dgvListagem.Rows(hit.RowIndex).DataBoundItem, clAPagar)
			'
			If pagItem.Situacao = 0 Then '--- EmAberto
				QuitarToolStripMenuItem.Enabled = True
				CancelarToolStripMenuItem.Enabled = True
				NegativarToolStripMenuItem.Enabled = True
				NormalizarToolStripMenuItem.Enabled = False

			ElseIf pagItem.Situacao = 1 Then '--- Pagas
				QuitarToolStripMenuItem.Enabled = False
				CancelarToolStripMenuItem.Enabled = False
				NegativarToolStripMenuItem.Enabled = False
				NormalizarToolStripMenuItem.Enabled = False

			ElseIf pagItem.Situacao = 2 Then '--- Canceladas
				QuitarToolStripMenuItem.Enabled = True
				CancelarToolStripMenuItem.Enabled = False
				NegativarToolStripMenuItem.Enabled = True
				NormalizarToolStripMenuItem.Enabled = True

			ElseIf pagItem.Situacao = 3 Then '--- Negativadas
				QuitarToolStripMenuItem.Enabled = False
				CancelarToolStripMenuItem.Enabled = False
				NegativarToolStripMenuItem.Enabled = True
				NormalizarToolStripMenuItem.Enabled = True

			ElseIf pagItem.Situacao = 4 Then '--- Negociadas
				QuitarToolStripMenuItem.Enabled = False
				CancelarToolStripMenuItem.Enabled = False
				NegativarToolStripMenuItem.Enabled = False
				NormalizarToolStripMenuItem.Enabled = False

			End If
			'
			' revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location))
		End If
	End Sub
	' 
	'--- QUITAR A PAGAR
	'-------------------------------------------------------------------------------------------------------
	Private Sub QuitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
		'
		btnQuitar_Click(New Object, New EventArgs)
		'
	End Sub
	'
	'--- CANCELAR A PAGAR
	'-------------------------------------------------------------------------------------------------------
	Private Sub CancelarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarToolStripMenuItem.Click
		'
		'--- verifica se existe alguma cell 
		If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
		'
		'--- verifica USER PERMIT
		If UsuarioAtual.UsuarioAcesso <> 1 Then '--- Usuario Administrador
			MessageBox.Show("Solicite autorização Administrativa...")
			Exit Sub
		End If
		'
		'--- Pergunta ao USER
		If MessageBox.Show("Você deseja realmente CANCELAR esse APagar selecionado?",
						   "Cancelar A Pagar", MessageBoxButtons.YesNo,
						   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If
		'
		'--- Cancela a APagar selecionado
		Dim pBLL As New APagarBLL
		Dim resp As Integer
		'
		'--- Verify if APagar is Despesa Periodica
		Dim Origem As clAPagar.Origem_APagar = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAPagar).Origem
		'
		If Origem = clAPagar.Origem_APagar.DespesaPeriodica Then
			MessageBox.Show("Esse A Pagar é uma DEPESA PERIÓDICA." &
							vbNewLine &
							"Não é possível CANCELAR uma Despesa Periódica.",
							"Despesa Periódica",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Exit Sub
		End If
		'
		Dim IDAPagar As Integer = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAPagar).IDAPagar
		'
		Try
			resp = pBLL.Cancelar_APagar(IDAPagar)
		Catch ex As Exception
			MessageBox.Show("Houve uma exceção inesperada ao Cancelar o APagar..." & vbNewLine &
							ex.Message, "Execeção Inesperada", MessageBoxButtons.OK)
			Exit Sub
		End Try
		'
		'--- atualiza a listagem
		DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAPagar).Situacao = 2 '-- 2 : Situacao CANCELADA
		dgvListagem.EndEdit()
		Get_Dados()
		'
	End Sub
	'
	'--- NORMALIZAR A PAGAR
	'-------------------------------------------------------------------------------------------------------
	Private Sub NormalizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalizarToolStripMenuItem.Click
		'
		'--- verifica se existe alguma cell 
		If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
		'
		'--- verifica USER PERMIT
		If UsuarioAtual.UsuarioAcesso <> 1 Then '--- Usuario Administrador
			MessageBox.Show("Solicite autorização Administrativa...")
			Exit Sub
		End If
		'
		'--- Pergunta ao USER
		If MessageBox.Show("Você deseja realmente NORMALIZAR esse APagar selecionado?",
						   "Normalizar A Pagar", MessageBoxButtons.YesNo,
						   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
			Exit Sub
		End If
		'
		'--- Normaliza a APagar selecionado
		Dim pBLL As New APagarBLL
		Dim resp As Integer
		Dim IDAPagar As Integer = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAPagar).IDAPagar
		'
		Try
			resp = pBLL.Normalizar_APagar(IDAPagar)
		Catch ex As Exception
			MessageBox.Show("Houve uma exceção inesperada ao Normalizar o A Pagar..." & vbNewLine &
							ex.Message, "Execeção Inesperada", MessageBoxButtons.OK)
			Exit Sub
		End Try
		'
		'--- atualiza a listagem
		'-- 2 : Situacao EM ABERTO
		DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAPagar).Situacao = 0
		dgvListagem.EndEdit()
		Get_Dados()
		'
	End Sub
	'
	'--- NEGATIVAR APAGAR
	'-------------------------------------------------------------------------------------------------------
	Private Sub NegativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegativarToolStripMenuItem.Click
		MsgBox("Em Implementação")
	End Sub
	'
	'--- VER ORIGEM DO APAGAR
	'-------------------------------------------------------------------------------------------------------
	Private Sub VerOrigemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerOrigemToolStripMenuItem.Click
		'
		'--- verifica se existe alguma cell 
		If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
		'
		btnEditar_Click(New Object, New EventArgs)
		'
	End Sub
	'
#End Region
	'
#Region "TRATAMENTO VISUAL"
	'
	Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlVenda.Paint
		'
		Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
		e.Graphics.FillRectangle(brush, e.ClipRectangle)
		'
	End Sub
	'
#End Region
	'
End Class
