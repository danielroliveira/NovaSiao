Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmClienteSimplesProcurar
	'
	Private WithEvents listCliente As New List(Of clClienteSimples)
	Private _formOrigem As Form
	Private _IDFilial As Integer
	Private IsOpened = False
	'
	'--- PROPRIEDADES DE RESPOSTA
	Property propCliente_Escolha As clClienteSimples
	'
#Region "SUB NEW E LOAD"
	'
	'--- SUB NEW
	Public Sub New(Optional formOrigem As Form = Nothing)
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
		'GetDados()
		'FiltrarListagem()
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
		Dim cBLL As New ClienteSimplesBLL
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
		dgvLista.Columns.AddRange({clnID, clnNome})
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
	'--- FECHAR QUANDO PRESS ESC
	'----------------------------------------------------------------------------------
	Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
		'
		If e.KeyCode = Keys.Escape Then
			'
			e.Handled = True
			btnFechar_Click(New Object, New EventArgs)
			'
		End If
		'
	End Sub

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
		Dim frmF As New frmClienteSimples(cliente)
		frmF.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
		Close()
		frmF.Show()
		'
		'--- Ampulheta OFF
		Cursor = Cursors.Default
		'
	End Sub
	'
	'--- FECHAR
	'----------------------------------------------------------------------------------
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Close()
		MostraMenuPrincipal()
	End Sub
	'
	'--- ADICIONAR
	'----------------------------------------------------------------------------------
	Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim frmC As New frmClienteSimples(New clClienteSimples)
			'
			frmC.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
			Close()
			frmC.Show()
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
#End Region '/ EFEITO VISUAL
	'
	'#Region "FILTRO LISTAGEM"
	'	'
	'	'--- FILTRAR LISTAGEM
	'	Private Sub FiltrarListagem()
	'		dgvLista.DataSource = listCliente.FindAll(AddressOf FindForn)
	'	End Sub
	'	'
	'	Private Function FindForn(ByVal T As clClienteSimples) As Boolean
	'		'
	'		If T.ClienteNome.ToLower Like "*" & txtProcura.Text.ToLower & "*" Then
	'			Return True
	'		Else
	'			Return False
	'		End If
	'		'
	'	End Function
	'	'
	'	Private Sub cmbAtivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAtivo.SelectedValueChanged
	'		'
	'		If Not IsOpened Then Exit Sub
	'		'
	'		GetDados()
	'		FiltrarListagem()
	'		'
	'	End Sub
	'	'
	'#End Region '/ FILTRO LISTAGEM



	Private Sub txtProcura_TextChanged(sender As Object, e As EventArgs) Handles txtProcura.TextChanged
		'
		If txtProcura.Text.Length > 0 Then
			propPreenchido = True
		Else
			propPreenchido = False
		End If
		'
		'FiltrarListagem()
	End Sub

	Private _propPreenchido As Boolean?

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


End Class
