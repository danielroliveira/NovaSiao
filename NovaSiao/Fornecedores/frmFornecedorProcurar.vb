Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmFornecedorProcurar
	'
	Private fBLL As New FornecedorBLL
	Private WithEvents listForn As New List(Of clFornecedor)
	Private _formOrigem As Form
	Private IsOpened = False
	Private _propPreenchido As Boolean?
	Private _IsProcura As Boolean = False
	'
	Private ImgInativo As Image = My.Resources.block
	Private ImgAtivo As Image = My.Resources.accept
	'
	'--- PROPRIEDADES DE RESPOSTA
	Property propFornecedor_Escolha As clFornecedor
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
		'
		FormataListagem()
		'
		_IsProcura = IsProcura
		If IsProcura Then
			btnEditar.Text = "&Escolher"
			btnEditar.Image = My.Resources.accept
			btnFechar.Text = "&Cancelar"
			btnAdicionar.Enabled = False
			lblTitulo.Text = "Escolher Fornecedor"
		Else
			btnEditar.Text = "&Editar"
			btnEditar.Image = My.Resources.editar
			btnFechar.Text = "&Fechar"
			btnAdicionar.Enabled = True
			lblTitulo.Text = "Procurar Fornecedor"
		End If
		'
	End Sub
	'
	Private Sub frmFornecedorProcurar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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
			'
			listForn = fBLL.GetFornecedores(Nothing, txtProcura.Text, Ativo)
			'
		Catch ex As Exception
			MessageBox.Show("Houve uma exceção ao obter a lista de Fornecedores..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Set Datasource
		dgvLista.DataSource = listForn
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
			.DataPropertyName = "IDPessoa"
			.Visible = True
			.ReadOnly = True
			.Resizable = False
			.SortMode = DataGridViewColumnSortMode.NotSortable
			Dim newPadding As New Padding(5, 0, 0, 0)
			.DefaultCellStyle.Padding = newPadding
		End With
		'
		' (2) COLUNA FORNECEDOR | CADASTRO
		With clnCadastro
			.DataPropertyName = "Cadastro"
			.Visible = True
			.ReadOnly = True
			.Resizable = False
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' (3) Coluna da imagem
		With clnImage
			.Name = "Ativo"
			.Resizable = False
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
		End With
		'
		'--- Add Columns
		dgvLista.Columns.AddRange({clnID, clnCadastro, clnImage})
		'
	End Sub
	'
	'--- CONTROLA AS IMAGENS DA LISTAGEM
	'=====================================================================================================
	Private Sub dgvLista_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvLista.CellFormatting
		'
		If e.ColumnIndex = 2 Then
			If DirectCast(dgvLista.Rows(e.RowIndex).DataBoundItem, clFornecedor).Ativo Then
				e.Value = ImgAtivo
			Else
				e.Value = ImgInativo
			End If
		End If
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
			MessageBox.Show("Não existe nenhum Fornecedor selecionado...", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			dgvLista.Focus()
			Exit Sub
		End If
		'
		'--- Seleciona o Fornecedor
		Dim forn As clFornecedor = dgvLista.SelectedRows(0).DataBoundItem
		'
		If _IsProcura = True Then '--- se for para escolha e procura
			'Dim ID As Integer = dgvListagem.SelectedRows(0).Cells("clnID").Value
			propFornecedor_Escolha = forn
			Me.DialogResult = DialogResult.OK
		Else '--- se for para EDICAO
			Dim frmF As New frmFornecedor(forn)
			frmF.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
			Close()
			frmF.Show()
		End If
		'
	End Sub
	'
	'--- FECHAR
	'----------------------------------------------------------------------------------
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnClose.Click, btnFechar.Click
		'
		If _IsProcura = True Then '--- se for um form de PROCURA
			Me.DialogResult = DialogResult.Cancel
		Else '--- se for um form de CONTROLE EDICAO
			Close()
			MostraMenuPrincipal()
		End If
		'
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
			Dim frmF As New frmFornecedor(New clFornecedor, Me)
			'
			If Not frmF.InsertNewCNP(Me) Then
				frmF.Dispose()
				Exit Sub
			End If
			'
			frmF.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
			Close()
			frmF.Show()
			'
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao inserir novo Fornecedor..." & vbNewLine &
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
			listForn.Clear()
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
				Dim x As Integer = txtProcura.Location.X + 43
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

				Dim x As Integer = txtProcura.Location.X + 40
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
#Region "MENU SUSPENSO"
	'
	' CONTROLE DO MENU SUSPENSO
	Private Sub dgvListagem_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvLista.MouseDown
		'
		If e.Button = MouseButtons.Right Then
			Dim c As Control = DirectCast(sender, Control)
			Dim hit As DataGridView.HitTestInfo = dgvLista.HitTest(e.X, e.Y)
			dgvLista.ClearSelection()
			'
			'---VERIFICAÇÕES NECESSÁRIAS
			If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
			'
			' seleciona o ROW
			dgvLista.Rows(hit.RowIndex).Cells(0).Selected = True
			dgvLista.Rows(hit.RowIndex).Selected = True
			'
			' mostra o MENU ativar e desativar
			If dgvLista.Columns(hit.ColumnIndex).Name = "Ativo" Then
				'
				If dgvLista.Rows(hit.RowIndex).DataBoundItem.Ativo = True Then
					miAtivar.Enabled = False
					miDesativar.Enabled = True
				Else
					miAtivar.Enabled = True
					miDesativar.Enabled = False
				End If
				'
				' revela menu
				MenuDatagrid.Show(c.PointToScreen(e.Location))
				'
			End If
			'
		End If
		'
	End Sub
	'
	Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles miAtivar.Click
		'
		'--- verifica se existe alguma cell 
		If dgvLista.SelectedRows.Count = 0 Then Exit Sub
		'
		'--- Verifica o item
		Dim selForn As clFornecedor = dgvLista.SelectedRows(0).DataBoundItem
		'
		'---pergunta ao usuário
		If AbrirDialog("Deseja realmente ATIVAR esse Fornecedor?" & vbNewLine &
					   selForn.Cadastro.ToUpper, "Ativar",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question) = vbNo Then Exit Sub
		'
		'--- altera o valor
		selForn.Ativo = True
		'
		'--- Salvar o Registro
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim fBLL As New PessoaBLL
			fBLL.UpdatePessoa(selForn, PessoaBLL.EnumPessoaGrupo.FORNECEDOR)
			'
			'--- Refresh DataGridView Data
			GetDados()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Atualizar o registro..." & vbNewLine &
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
		If dgvLista.SelectedRows.Count = 0 Then Exit Sub
		'
		'--- Verifica o item
		Dim selForn As clFornecedor = dgvLista.SelectedRows(0).DataBoundItem
		'
		'---pergunta ao usuário
		If MessageBox.Show("Deseja realmente INATIVAR esse Fornecedor?" & vbNewLine &
						   selForn.Cadastro.ToUpper, "Inativar",
						   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
		'
		'--- altera o valor
		selForn.Ativo = False
		'
		'--- Salvar o Registro
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim fBLL As New PessoaBLL
			fBLL.UpdatePessoa(selForn, PessoaBLL.EnumPessoaGrupo.FORNECEDOR)
			'
			'--- Refresh DataGridView Data
			GetDados()
			'
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao Atualizar o Registro..." & vbNewLine &
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
End Class
