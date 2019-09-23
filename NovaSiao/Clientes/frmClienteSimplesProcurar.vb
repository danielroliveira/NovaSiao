Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmClienteSimplesProcurar
	'
	Private cBLL As New ClienteSimplesBLL
	Private WithEvents listCliente As New List(Of clClienteSimples)
	Private _formOrigem As Form
	Private _IDFilial As Integer
	Private IsOpened = False
	Private _propPreenchido As Boolean?
	Private _IsProcura As Boolean = False
	'
	'--- PROPRIEDADES DE RESPOSTA
	Property propCliente_Escolha As clClienteSimples
	'
#Region "SUB NEW E LOAD"
	'
	'--- SUB NEW
	Public Sub New(IsProcura As Boolean,
				   Optional formOrigem As Form = Nothing)
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		CarregaCmbAtivo()
		_formOrigem = formOrigem
		_IDFilial = Obter_FilialPadrao()
		'
		FormataListagem()
		'
		_IsProcura = IsProcura
		If IsProcura Then
			btnEditar.Text = "&Escolher"
			btnEditar.Image = My.Resources.accept
		Else
			btnEditar.Text = "&Editar"
			btnEditar.Image = My.Resources.editar
		End If
		'
	End Sub
	'
	Private Sub frmClienteSimplesProcurar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		IsOpened = True
	End Sub
	'
	'--- PREENCHE O COMBO ATIVO
	Private Sub CarregaCmbAtivo()
		'
		Dim dtAtivo As New DataTable
		'
		'Adiciona todas as possibilidades de instrucao
		dtAtivo.Columns.Add("Ativo")
		dtAtivo.Columns.Add("Texto")
		dtAtivo.Rows.Add(New Object() {True, "Ativo"})
		dtAtivo.Rows.Add(New Object() {False, "Inativo"})
		'
		With cmbAtivo
			.DataSource = dtAtivo
			.ValueMember = "Ativo"
			.DisplayMember = "Texto"
			.SelectedValue = True
		End With
		'
	End Sub
	'
#End Region '/ SUBNEW E LOAD
	'
#Region "LISTAGEM GET E CONTROLE"
	'
	'--- GET DATA FOR LIST OF FUNCIONARIOS
	'----------------------------------------------------------------------------------
	Private Sub GetDados()
		'
		'--- Preenche o Datatable
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			Dim Ativo As Boolean = cmbAtivo.SelectedValue
			listCliente = cBLL.ClienteSimples_GET_List(_IDFilial, txtProcura.Text, Ativo)
			'
		Catch ex As Exception
			MessageBox.Show("Não foi possível apresentar a lista de clientes..." & vbNewLine &
							ex.Message,
							"Procurar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Set Datasource
		dgvLista.DataSource = listCliente
		propPreenchido = Nothing
		'
	End Sub
	'
	'--------------------------------------------------------------------------------------------------------
	' PREENCHE A LISTAGEM
	'--------------------------------------------------------------------------------------------------------
	Private Sub FormataListagem()
		'
		With dgvLista
			.Columns.Clear()
			.AutoGenerateColumns = False
			' altera as propriedades importantes
			.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			.MultiSelect = False
			.ColumnHeadersVisible = True
			.AllowUserToResizeRows = False
			.AllowUserToResizeColumns = False
			.RowHeadersWidth = 36
			.RowTemplate.Height = 30
			.StandardTab = True
		End With
		'
		' (1) COLUNA REG
		With clnID
			.DataPropertyName = "IDClienteSimples"
			.Visible = True
			.ReadOnly = True
			.Resizable = False
			.DefaultCellStyle.Format = "0000"
			.SortMode = DataGridViewColumnSortMode.NotSortable
			Dim newPadding As New Padding(5, 0, 0, 0)
			.DefaultCellStyle.Padding = newPadding
		End With
		'
		' (2) COLUNA NOME
		With clnNome
			.DataPropertyName = "ClienteNome"
			.Visible = True
			.ReadOnly = True
			.Resizable = False
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With
		'
		' (3) COLUNA TELEFONE B
		With clnTelefoneB
			.DataPropertyName = "TelefoneB"
			.Visible = True
			.ReadOnly = True
			.Resizable = False
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With
		'
		' (4) COLUNA TELEFONE A
		With clnTelefoneA
			.DataPropertyName = "TelefoneA"
			.Visible = True
			.ReadOnly = True
			.Resizable = False
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With
		'
		dgvLista.Columns.AddRange({clnID, clnNome, clnTelefoneB, clnTelefoneA})
		'
	End Sub
	'
	'-------------------------------------------------------------------------------------------------
	'--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
	'-------------------------------------------------------------------------------------------------
	Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLista.CellDoubleClick
		btnEditar_Click(New Object, New EventArgs)
	End Sub
	'
#End Region '/ LISTAGEM GET E CONTROLE
	'
#Region "BUTTONS FUNCTION"
	'
	'--- EDITAR
	'----------------------------------------------------------------------------------
	Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
		'
		'--- verifica se existe algum item selecionado
		If dgvLista.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhum Cliente selecionado...", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			dgvLista.Focus()
			Exit Sub
		End If
		'
		'--- Seleciona o Funcionario
		Dim cliente As clClienteSimples = dgvLista.SelectedRows(0).DataBoundItem
		'
		'--- Ampulheta ON
		Cursor = Cursors.WaitCursor
		'
		If Not _IsProcura Then
			Dim frmF As New frmClienteSimples(cliente)
			frmF.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
			Close()
			frmF.Show()
		Else
			propCliente_Escolha = cliente
			DialogResult = DialogResult.OK
		End If
		'
		'--- Ampulheta OFF
		Cursor = Cursors.Default
		'
	End Sub
	'
	'--- FECHAR
	'----------------------------------------------------------------------------------
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		'
		If Not _IsProcura Then
			Close()
			MostraMenuPrincipal()
		Else
			DialogResult = DialogResult.Cancel
		End If
		'
	End Sub
	'
	'--- ADICIONAR
	'----------------------------------------------------------------------------------
	Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
		'
		Try
			If Not _IsProcura Then
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				Dim frmC As New frmClienteSimples(New clClienteSimples, _formOrigem)
				'
				frmC.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
				Close()
				frmC.Show()
				'
			Else
				DialogResult = DialogResult.Retry
				Close()
			End If
			'
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao inserir novo Cliente Simples..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			'
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Sub
	'
#End Region '/ BUTTONS FUNCTION
	'
#Region "EFEITO VISUAL"
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
	Private Sub frmAReceberItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
		If IsNothing(_formOrigem) Then Exit Sub
		'
		For Each c As Control In _formOrigem.Controls
			If c.Name = "Panel1" Then
				c.BackColor = Color.Silver
			End If
		Next
		'
	End Sub
	'
	Private Sub frmAReceberItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
		If IsNothing(_formOrigem) Then Exit Sub
		'
		For Each c As Control In _formOrigem.Controls
			If c.Name = "Panel1" Then
				c.BackColor = Color.SlateGray
			End If
		Next
		'
	End Sub
	'
	Private Sub showToolTip(control As Control)
		'
		' Cria a ToolTip e associa com o Form container.
		Dim toolTip1 As New ToolTip()
		'
		' Define o delay para a ToolTip.
		With toolTip1
			.AutoPopDelay = 2000
			.InitialDelay = 2000
			.ReshowDelay = 500
			.IsBalloon = True
			.UseAnimation = True
			.UseFading = True
		End With
		'
		If control.Tag = "" Then
			toolTip1.Show("Clique aqui...", control, control.Width - 30, -40, 2000)
		Else
			toolTip1.Show(control.Tag, control, control.Width - 30, -40, 2000)
		End If
		'
		'
	End Sub
	'
	'--- ENABLE TOOLSTRIP
	'----------------------------------------------------------------------------------
	Private Sub btn_EnabledChanged(sender As Object, e As EventArgs) Handles btnProcurar.EnabledChanged
		'
		Dim control As Control = DirectCast(sender, Control)
		'
		If control.Enabled = True Then
			showToolTip(control)
		End If
		'
	End Sub
	'
#End Region '/ EFEITO VISUAL
	'
#Region "NAVEGACAO E CONTROLE"
	'
	'------------------------------------------------------------------------------------------------
	' TECLAS DE ATALHO:
	'
	'--- ESC --> FECHA FORM
	'--- SETA CIMA E BAIXO --> NAVEGA ENTRE OS ITENS DA LISTAGEM
	'--- PGDOWN E PGUP --> ALTERA ATIVO
	'------------------------------------------------------------------------------------------------
	Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
		'
		Select Case e.KeyCode
			'
			Case Keys.Escape
				'
				e.Handled = True
				btnFechar_Click(New Object, New EventArgs)
				'
			Case Keys.Add
				'
				e.Handled = True
				btnAdicionar_Click(New Object, New EventArgs)
				'
			Case Keys.Up
				'
				'--- garante que o combo não está aberto
				If cmbAtivo.DroppedDown = True Then Exit Sub
				'
				e.Handled = True
				'
				If dgvLista.Rows.Count > 0 Then
					If dgvLista.SelectedRows.Count > 0 Then
						Dim i As Integer = dgvLista.SelectedRows(0).Index
						'
						dgvLista.Rows(i).Selected = False
						'
						If i = 0 Then
							i = dgvLista.Rows.Count
						End If
						'
						dgvLista.Rows(i - 1).Selected = True
					Else
						dgvLista.Rows(0).Selected = True
					End If
					'
					dgvLista.FirstDisplayedScrollingRowIndex = dgvLista.SelectedRows(0).Index
					dgvLista.SelectedRows(0).Cells(0).Selected = True
					'
				End If
				'
			Case Keys.Down
				'
				'--- garante que o combo não está aberto
				If cmbAtivo.DroppedDown = True Then Exit Sub
				'
				e.Handled = True
				'
				If dgvLista.Rows.Count > 0 Then
					If dgvLista.SelectedRows.Count > 0 Then
						Dim i As Integer = dgvLista.SelectedRows(0).Index
						'
						dgvLista.Rows(i).Selected = False
						'
						If i = dgvLista.Rows.Count - 1 Then
							i = -1
						End If
						'
						dgvLista.Rows(i + 1).Selected = True
					Else
						dgvLista.Rows(0).Selected = True
					End If
					'
					dgvLista.FirstDisplayedScrollingRowIndex = dgvLista.SelectedRows(0).Index
					dgvLista.SelectedRows(0).Cells(0).Selected = True
					'
				End If
				'
			Case Keys.PageUp
				'
				e.Handled = True
				If cmbAtivo.SelectedIndex > 0 Then
					cmbAtivo.SelectedIndex -= 1
				Else
					cmbAtivo.SelectedIndex = cmbAtivo.Items.Count - 1
				End If
				'
			Case Keys.PageDown
				'
				e.Handled = True
				Dim maxIndex As Byte = cmbAtivo.Items.Count - 1
				'
				If cmbAtivo.SelectedIndex < maxIndex Then
					cmbAtivo.SelectedIndex += 1
				Else
					cmbAtivo.SelectedIndex = 0
				End If
				'
			Case Else
				e.Handled = False
		End Select
		'
	End Sub
	'
	'--- ON PRESS ENTER TXTPROCURA DO GET LISTA | PRESS DELETE DO CLEAR LIST
	'---------------------------------------------------------------------------------------
	Private Sub txtProcura_KeyDown(sender As Object, e As KeyEventArgs) _
	Handles txtProcura.KeyDown
		'
		If e.KeyCode = Keys.Enter Then
			e.SuppressKeyPress = True
			e.Handled = True
			'
			If If(propPreenchido, 0) = True Then
				GetDados()
			ElseIf IsNothing(propPreenchido) Then
				If dgvLista.SelectedRows.Count > 0 Then
					btnEditar_Click(sender, New EventArgs)
				End If
			End If
			'
		ElseIf e.KeyCode = Keys.Delete Then
			e.Handled = True
			'
			txtProcura.Clear()
			propPreenchido = False
			listCliente.Clear()
			dgvLista.DataSource = Nothing
			'
		End If
		'
	End Sub
	'
#End Region '/ NAVEGACAO E CONTROLE
	'
#Region "PROCURA"
	'
	'--- AO ALTERAR O TEXTO PROCURA
	'----------------------------------------------------------------------------------
	Private Sub txtProcura_TextChanged(sender As Object, e As EventArgs) Handles txtProcura.TextChanged
		'
		If txtProcura.Text.Length > 0 Then
			propPreenchido = True
		Else
			propPreenchido = False
		End If
		'
	End Sub
	'
	'--- PROPERTY DE CONTROLE DA PROCURA
	'----------------------------------------------------------------------------------
	Property propPreenchido As Boolean?
		'
		Get
			Return _propPreenchido
		End Get
		'
		Set(value As Boolean?)
			'
			If IsNothing(value) Then
				lblProc.Visible = False
				'-- btnProcurar
				btnProcurar.Visible = False
				btnProcurar.Enabled = False
				'
			ElseIf If(value, 0) = True Then

				lblProc.SendToBack()
				Dim x As Integer = txtProcura.Location.X + 15
				Dim y As Integer = txtProcura.Location.Y - 17
				Dim newPoint As Point = New Point(x, y)
				lblProc.Location = newPoint

				lblProc.Font = New Font("Calibri Light", 8.0!, FontStyle.Bold)
				lblProc.Text = "Pressione ENTER..."
				lblProc.ForeColor = Color.DarkBlue
				lblProc.BackColor = Color.Transparent
				lblProc.Visible = True
				'-- btnProcurar
				btnProcurar.Visible = True
				btnProcurar.Enabled = True
				'
			ElseIf If(value, -1) = False Then

				Dim x As Integer = txtProcura.Location.X + 12
				Dim y As Integer = txtProcura.Location.Y + 3
				Dim newPoint As Point = New Point(x, y)
				lblProc.Location = newPoint

				lblProc.Font = New Font("Calibri Light", 11.25!, FontStyle.Italic)
				lblProc.Text = "Digite algo para procurar..."
				lblProc.ForeColor = Color.Black
				lblProc.BackColor = Color.White
				lblProc.BringToFront()
				lblProc.Visible = True
				'-- btnProcurar
				btnProcurar.Visible = True
				btnProcurar.Enabled = False
				'
			End If
			'
			_propPreenchido = value
			'
		End Set
		'
	End Property
	'
	'--- BTN PROCURAR
	'----------------------------------------------------------------------------------
	Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
		'
		If If(propPreenchido, 0) = True Then
			dgvLista.Focus()
			GetDados()
		End If
		'
	End Sub
	'
	'--- AO ALTERAR O COMBO ATIVO CHECK STATE
	'----------------------------------------------------------------------------------
	Private Sub cmbAtivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAtivo.SelectedIndexChanged
		'
		If Not Me.CanFocus Then Exit Sub
		'
		If txtProcura.Text.Trim.Length > 0 Then
			GetDados()
		End If
		'
		txtProcura.Focus()
		'
	End Sub
	'
	Private Sub lblProc_Click(sender As Object, e As EventArgs) Handles lblProc.Click
		txtProcura.Focus()
	End Sub
	'
#End Region '/ PROCURA
	'
#Region "MENU CONTEXTO"
	'
	Private Sub dgvLista_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvLista.MouseDown
		'
		If e.Button = MouseButtons.Right Then
			'
			Dim c As Control = DirectCast(sender, Control)
			Dim hit As DataGridView.HitTestInfo = dgvLista.HitTest(e.X, e.Y)
			dgvLista.ClearSelection()
			'
			If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
			'
			' seleciona o ROW
			dgvLista.CurrentCell = dgvLista.Rows(hit.RowIndex).Cells(1)
			dgvLista.Rows(hit.RowIndex).Selected = True
			'
			' mostra o MENU ativar e desativar
			Dim Ativo As Boolean = cmbAtivo.SelectedValue
			'
			miAtivar.Enabled = Not Ativo
			miDesativar.Enabled = Ativo
			'
			' revela menu
			MenuDatagrid.Show(c.PointToScreen(e.Location))
			'
		End If
		'
	End Sub
	'
	Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles miAtivar.Click
		'
		'--- verifica se existe alguma cell 
		If IsDBNull(dgvLista.CurrentRow.Cells(0).Value) Then Exit Sub
		'
		'--- altera o valor
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim cli As clClienteSimples = dgvLista.CurrentRow.DataBoundItem
			cli.Ativo = True
			'
			cBLL.ClienteSimples_Alterar(cli)
			'
			'--- realiza a procura
			GetDados()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Ativar o registro..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles miDesativar.Click
		'
		'--- verifica se existe alguma cell 
		If IsDBNull(dgvLista.CurrentRow.Cells(0).Value) Then Exit Sub
		'
		'--- altera o valor
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim cli As clClienteSimples = dgvLista.CurrentRow.DataBoundItem
			cli.Ativo = False
			'
			cBLL.ClienteSimples_Alterar(cli)
			'
			'--- realiza a procura
			GetDados()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Desativar o registro..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
#End Region '/ MENU CONTEXTO
	'
End Class
