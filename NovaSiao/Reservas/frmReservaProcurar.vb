Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmReservaProcurar
	Private resLista As New List(Of clReserva)
	Private IDProdutoTipo As Integer?
	Private IDFilial As Integer?
	Private LiberaAtualizacao As Boolean = False
	Private ReservaSituacao As clReservaSituacao
	Private rBLL As New ReservaBLL
	'
	Const rowHeight As Integer = 32 '--- define o tamanho da row no DataGridView
	'
#Region "NEW | PROPRIEDADES"
	'
	Sub New()
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		ReservaSituacao = New clReservaSituacao With {
			.IDSituacaoReserva = 1,
			.ReservaAtiva = True,
			.SituacaoReserva = "Aguardando Pedido"
			}
		'
		DefineLabelSituacao()
		'
		'--- verifica a Filial padrao
		IDFilial = Obter_FilialPadrao()
		If IDFilial Is Nothing Then
			MessageBox.Show("Não há nehuma filial padrão selecionada...", "Filial Padrão",
							MessageBoxButtons.OK, MessageBoxIcon.Error)
		Else
			lblFilial.Text = ObterDefault("FilialDescricao")
		End If
		'
		'--- preenche a listagem
		Get_Dados()
		ConfiguraDatagrid()
		FiltrarListagem()
		'
		LiberaAtualizacao = True
		'
	End Sub
	'
	Private Sub frmReservaProcurar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		showToolTip()
	End Sub
	'
	Private Sub Get_Dados()
		'
		'--- consulta o banco de dados
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			resLista = rBLL.Reserva_GET_List(IDFilial,
											 chkPrioritaria.Checked,
											 ReservaSituacao.IDSituacaoReserva,
											 ReservaSituacao.ReservaAtiva)
			'
		Catch ex As Exception
			MessageBox.Show("Ocorreu exceção ao obter a listagem de Reservas..." & vbNewLine &
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
	Private Sub DefineLabelSituacao()
		lblReservaAtiva.Text = IIf(ReservaSituacao.ReservaAtiva, "Reservas Ativas", "Reservas Concluídas")
		lblSituacao.Text = ReservaSituacao.SituacaoReserva
	End Sub
	'
#End Region
	'
#Region "DATAGRID"
	'
	Private Sub ConfiguraDatagrid()
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
		dgvItens.RowHeadersVisible = False
		dgvItens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
		dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
		dgvItens.StandardTab = True
		'
		dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
		dgvItens.RowHeadersWidth = rowHeight
		dgvItens.RowTemplate.Height = rowHeight
		dgvItens.RowTemplate.MinimumHeight = rowHeight
		'
		dgvItens.ColumnHeadersDefaultCellStyle.Font = New Font("Pathway Gothic One", 12.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
		'
		'--- configura o DataSource
		dgvItens.DataSource = resLista
		'
		'--- formata as colunas do datagrid
		FormataColunas_Itens()
		'
	End Sub
	'
	Private Sub FormataColunas_Itens()
		'
		With clnSelect
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
			.Resizable = DataGridViewTriState.False
		End With
		'
		' COLUNA ID
		With clnIDReserva
			.DataPropertyName = "IDReserva"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.DefaultCellStyle.Format = "0000"
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		' COLUNA RESERVA DATA
		With clnReservaData
			.DataPropertyName = "ReservaData"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA NOME CLIENTE
		With clnClienteNome
			.DataPropertyName = "ClienteNome"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA TELEFONE B : CELULAR
		With clnTelefoneB
			.DataPropertyName = "TelefoneB"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA TELEFONE A : TELEFONE
		With clnTelefoneA
			.DataPropertyName = "TelefoneA"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA PRODUTO
		With clnProduto
			.DataPropertyName = "Produto"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA AUTOR
		With clnAutor
			.DataPropertyName = "Autor"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA TIPO PRODUTO
		With clnProdutoTipo
			.DataPropertyName = "ProdutoTipo"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA FORNECEDOR
		With clnFornecedor
			.DataPropertyName = "Fornecedor"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA FABRICANTE
		With clnFabricante
			.DataPropertyName = "Fabricante"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
		End With
		'
		' COLUNA VALOR ANTECIPADO
		With clnValorAntecipado
			.DataPropertyName = "ValorAntecipado"
			.Resizable = DataGridViewTriState.False
			.Visible = True
			.ReadOnly = True
			.SortMode = DataGridViewColumnSortMode.NotSortable
			.DefaultCellStyle.Format = "C"
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
		End With
		'
		'--- adiciona as colunas editadas
		dgvItens.Columns.AddRange(New DataGridViewColumn() {clnSelect, clnIDReserva, clnReservaData,
															clnClienteNome, clnTelefoneB, clnTelefoneA,
															clnProduto, clnAutor, clnFornecedor,
															clnFabricante, clnProdutoTipo, clnValorAntecipado})
		'
	End Sub
	'
	Private Sub dgvItens_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvItens.CellFormatting
		'
		If e.ColumnIndex = clnIDReserva.Index Then '--- coluna ID
			'
			If dgvItens.Rows(e.RowIndex).DataBoundItem.IDPedido IsNot Nothing Then
				dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.PeachPuff
			End If
			'
		ElseIf e.ColumnIndex = clnValorAntecipado.Index Then '--- coluna ValorAntecipado
			'
			Dim Antecipado As Decimal? = dgvItens.Rows(e.RowIndex).DataBoundItem.ValorAntecipado
			'
			If Antecipado IsNot Nothing AndAlso Antecipado > 0 Then
				dgvItens.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = pctBoxPrioritarias.BackColor
			End If
			'
		End If
		'
	End Sub
	'
	'--- AO SELECIONAR O ITEM ALTERA A CONTAGEM
	Private Sub dgvItens_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellValueChanged
		'
		If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
			'
			Dim reserva As clReserva = dgvItens.Rows(e.RowIndex).DataBoundItem
			'
			If Not IsNothing(reserva.IDPedido) AndAlso dgvItens.Rows(e.RowIndex).Cells(0).Value = True Then
				'
				AbrirDialog("Essa reserva não pode ser marcada para alteração porque está associada a um PEDIDO..." & vbCrLf &
							"Para alterá-la, favor remover a associação.",
							"Reserva com Pedido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
				dgvItens.CancelEdit()
				dgvItens.Rows(e.RowIndex).Cells(0).Value = False
				Exit Sub
				'
			End If
			'
			AtualizaLabelSelecionados()
			'
		End If
		'
	End Sub
	'
	'--- AO SELECIONAR O ITEM ALTERA A CONTAGEM
	Private Sub dgvItens_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellContentClick
		'
		If e.ColumnIndex = 0 Then
			dgvItens.CommitEdit(DataGridViewDataErrorContexts.Commit)
		End If
		'
	End Sub
	'
	'--- ATUALIZA LBLSELECIONADOS
	Private Sub AtualizaLabelSelecionados()
		'
		Dim sel As Integer = ItensSelecionadosCount()
		'
		If sel > 0 Then
			btnAlterarSituacao.Enabled = True
			btnPrintEtiquetas.Enabled = True
			'
			If sel = 1 Then
				lblSelTitulo.Visible = True
				lblSelecionados.Visible = True
				lblSelecionados.Text = "01 Reserva Selecionada"
			Else
				lblSelTitulo.Visible = True
				lblSelecionados.Visible = True
				lblSelecionados.Text = Format(sel, "00") & " Reservas Selecionadas"
			End If
			'
		Else
			lblSelTitulo.Visible = False
			lblSelecionados.Visible = False
			btnAlterarSituacao.Enabled = False
			btnPrintEtiquetas.Enabled = False
		End If
		'
	End Sub
	'
	Private Function ItensSelecionadosCount() As Integer
		'
		Dim sel As Integer = 0
		'
		For Each row As DataGridViewRow In dgvItens.Rows
			If row.Cells(0).Value = True Then
				sel += 1
			End If
		Next
		'
		Return sel
		'
	End Function
	'
	'--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER) DA LISTAGEM
	Private Sub dgvItens_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItens.KeyDown
		'
		If e.KeyCode = Keys.Enter Then
			e.Handled = True
			'
			btnEditar_Click(New Object, New EventArgs)
		End If
		'
	End Sub
	'
	Private Sub dgvItens_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItens.CellDoubleClick
		btnEditar_Click(New Object, New EventArgs)
	End Sub
	'
#End Region '/ DATAGRID
	'
#Region "ACAO DOS BOTOES"
	'
	Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
		'
		If dgvItens.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhuma RESERVA selecionada na listagem", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If
		'
		Dim clR As clReserva = dgvItens.SelectedRows(0).DataBoundItem
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Verifica se o form Reserva ja esta aberto
			Dim frm As Form = Nothing
			'
			For Each f As Form In Application.OpenForms
				If f.Name = "frmReserva" Then
					frm = f
				End If
			Next
			'
			If IsNothing(frm) Then '--- o frmReserva não esta aberto
				frm = New frmReserva(clR, Me)
				frm.MdiParent = frmPrincipal
				frm.StartPosition = FormStartPosition.CenterScreen
				Me.Visible = False 'Close()
				frm.Show()
			Else '--- o frmReserva já esta aberto
				DirectCast(frm, frmReserva).propReserva = clR
				frm.Focus()
				Me.Visible = False 'Close()
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao abrir a reserva..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
		btnEditar_Click(New Object, New EventArgs)
	End Sub
	'
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
		Close()
		MostraMenuPrincipal()
	End Sub
	'
	Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
		'
		Dim frmT As New frmProdutoProcurarTipo(Me, IDProdutoTipo)
		Dim oldID As Integer? = IDProdutoTipo
		'
		frmT.ShowDialog()
		If frmT.DialogResult = DialogResult.Cancel Then
			txtProdutoTipo.Clear()
			IDProdutoTipo = Nothing
		Else
			txtProdutoTipo.Text = frmT.propTipo_Escolha
			IDProdutoTipo = frmT.propIdTipo_Escolha
		End If
		'
		If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(IDProdutoTipo), 0, IDProdutoTipo) Then
			FiltrarListagem()
		End If
		'
		txtProdutoTipo.Focus()
		'
	End Sub
	'
	Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
		'
		'--- Verifica se o form Despesa ja esta aberto
		Dim frm As Form = Nothing
		Dim clR As New clReserva
		'
		For Each f As Form In Application.OpenForms
			If f.Name = "frmReserva" Then
				frm = f
			End If
		Next
		'
		If IsNothing(frm) Then '--- o frmReserva não esta aberto
			'
			frm = New frmReserva(clR)
			frm.MdiParent = frmPrincipal
			frm.StartPosition = FormStartPosition.CenterScreen
			Close()
			frm.Show()
		Else '--- o frmReserva já esta aberto
			Close()
			DirectCast(frm, frmReserva).propReserva = clR
		End If
		'
	End Sub
	'
	'--- IMPRIMIR LISTAGEM
	Private Sub btnPrintListagem_Click(sender As Object, e As EventArgs) Handles btnPrintListagem.Click
		MsgBox("Em implementação")
	End Sub
	'
	'--- IMPRIMIR BOTOES
	Private Sub btnPrintEtiquetas_Click(sender As Object, e As EventArgs) Handles btnPrintEtiquetas.Click
		MsgBox("Em implementação")
	End Sub
	'
	'--- ALTERAR SITUACAO DAS RESERVAS SELECIONADAS
	Private Sub btnAlterarSituacao_Click(sender As Object, e As EventArgs) Handles btnAlterarSituacao.Click
		'
		'--- verifica a situacao atual if IS RESERVA ATIVA
		If ReservaSituacao.ReservaAtiva = False Then
			AbrirDialog("Não é possível alterar a Situação de Reservas que não estão Ativas",
						"Alterar Situação", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If
		'
		'--- verifica a quantidade de itens selecionados
		If ItensSelecionadosCount() = 0 Then
			AbrirDialog("Necessário selecionar as reservas para alterar a situação...",
						"Selecionar", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If
		'
		'--- verifica se as Reservar selecionadas são simples ou prioritarias
		If chkPrioritaria.Checked Then
			AbrirDialog("As reservas prioritárias devem ser alteradas individualmente.",
						"Selecionar", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			'--- remove checked selection
			For Each r In dgvItens.Rows
				r.Cells(0).Value = False
			Next
			'
			Exit Sub
		Else
			For Each row As DataGridViewRow In dgvItens.Rows
				If row.Cells(0).Value = True Then
					If If(DirectCast(row.DataBoundItem, clReserva).ValorAntecipado, 0) > 0 Then
						AbrirDialog("Existem reservas prioritárias selecionadas..." & vbNewLine &
									"As reservas prioritárias devem ser alteradas individualmente.",
									"Selecionar", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
						Exit Sub
					End If
				End If
			Next
		End If
		'
		'--- obtem a nova situacao
		Dim newSit As clReservaSituacao = GetNewSituacao()
		If newSit Is Nothing Then Exit Sub
		'
		'--- pergunta ao usuário se deseja realmente realizar alterações
		Dim msn As String = "Você deseja realmente alterar as Reservas escolhidas para" & vbNewLine &
							newSit.SituacaoReserva.ToUpper & "?"
		'
		If newSit.ReservaAtiva = False Then
			msn += vbNewLine & "Essa alteração irá DESATIVAR definitavamente as reservas selecionadas."
		End If
		'
		If AbrirDialog(msn, "Alterar Situação",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question,
					   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Return
		'
		'--- atualiza os registros
		Dim accessBLL As New AcessoControlBLL
		Dim db As Object = accessBLL.GetNewAcessoWithTransaction()
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			For Each row As DataGridViewRow In dgvItens.Rows
				If row.Cells(0).Value = True Then
					rBLL.Reserva_AlteraSituacao(row.Cells(1).Value, newSit.IDSituacaoReserva, db)
				End If
			Next
			'
			'--- COMMIT CHANGES
			accessBLL.CommitAcessoWithTransaction(db)
			'
		Catch ex As Exception
			'
			'--- ROOLBACK ALL CHANGES
			accessBLL.RollbackAcessoWithTransaction(db)
			'
			'--- ERROR MESSAGE
			MessageBox.Show("Houve uma exceção inesperada ao Alterar a situação da reserva no BD" & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			'--- EXIT
			Exit Sub
			'
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- atualiza a listagem
		Get_Dados()
		FiltrarListagem()
		AtualizaLabelSelecionados()
		'
	End Sub
	'
	Private Sub EscolherSituacao_Click(sender As Object, e As EventArgs) Handles lblReservaAtiva.Click, lblSituacao.Click
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim frm As New frmReservaSituacaoProcurar(False, ReservaSituacao, Me)
			'
			frm.ShowDialog()
			If frm.DialogResult <> vbOK Then Exit Sub
			'
			ReservaSituacao = frm.ReservaSituacaoEscolhida
			DefineLabelSituacao()
			'
			Get_Dados()
			FiltrarListagem()
			AtualizaLabelSelecionados()
			'
			pnlAtivas.BackColor = Color.WhiteSmoke
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de Procura de Situações..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'------------------------------------------------------------------------------------------
	' ATALHO F5 PARA ALTERAR A SITUACAO
	'------------------------------------------------------------------------------------------
	Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
		If e.KeyCode = Keys.F5 Then
			e.Handled = True
			'
			EscolherSituacao_Click(New Object, New EventArgs)
		End If
	End Sub
	'
#End Region
	'
#Region "NAVEGACAO CONTROLES"
	'
	'--- BLOQUEIA PRESS A TECLA (+)
	Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
		If e.KeyChar = "+" Then
			e.Handled = True
		End If
	End Sub
	'
	'--- ESCOLHER PRODUTO TIPO
	Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProdutoTipo.KeyDown
		'
		Dim ctr As Control = DirectCast(sender, Control)
		'
		If e.KeyCode = Keys.Add Then
			e.Handled = True
			Select Case ctr.Name
				Case "txtProdutoTipo"
					btnTipo_Click(New Object, New EventArgs)
			End Select
		ElseIf e.KeyCode = Keys.Delete Then
			e.Handled = True
			Select Case ctr.Name
				Case "txtProdutoTipo"
					txtProdutoTipo.Clear()
					IDProdutoTipo = Nothing
			End Select
		Else
			e.Handled = True
			e.SuppressKeyPress = True
		End If
		'
	End Sub
	'
	'--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
	Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNomeCliente.KeyDown,
		txtProdutoTipo.KeyDown
		'
		If e.KeyCode = Keys.Enter Then
			e.SuppressKeyPress = True
			SendKeys.Send("{Tab}")
		End If
		'
	End Sub
	'
#End Region '/ NAVEGACAO CONTROLES
	'
#Region "FILTRO LISTAGEM"
	'
	Private Sub chkPrioritaria_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrioritaria.CheckedChanged
		'
		If chkPrioritaria.Checked Then
			chkPrioritaria.Image = My.Resources.Enable
			lblTitulo.Text = "Reservas Prioritárias - Procurar"
		Else
			chkPrioritaria.Image = My.Resources.Disable
			lblTitulo.Text = "Reservas - Procurar"
		End If
		'
		If LiberaAtualizacao Then
			Get_Dados()
			FiltrarListagem()
		End If
		'
	End Sub
	'
	'--- FILTA O NOME DOS CLIENTES
	Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtNomeCliente.TextChanged, txtProduto.TextChanged
		'
		FiltrarListagem()
		'
	End Sub
	'
	'--- FILTAR LISTAGEM PELO IDTIPO E IDFILIAL, TXTPRODUTO, TXTNOME
	Private Sub FiltrarListagem()
		'
		dgvItens.DataSource = resLista.FindAll(AddressOf FindProduto)
		'
	End Sub
	'
	Private Function FindProduto(ByVal res As clReserva) As Boolean
		'
		If IDProdutoTipo Is Nothing Then
			If (res.Produto.ToLower Like "*" & txtProduto.Text.ToLower & "*") AndAlso
				(res.ClienteNome.ToLower Like "*" & txtNomeCliente.Text.ToLower & "*") Then
				Return True
			Else
				Return False
			End If
		Else
			If (res.Produto.ToLower Like "*" & txtProduto.Text.ToLower & "*") AndAlso
				(res.ClienteNome.ToLower Like "*" & txtNomeCliente.Text.ToLower & "*") AndAlso
				(res.IDProdutoTipo = IDProdutoTipo) Then
				Return True
			Else
				Return False
			End If
		End If
		'
	End Function
	'----------------------------------------------------------------------------------------
	'
#End Region '/ FILTRO LISTAGEM
	'
#Region "TRATAMENTO VISUAL"
	'
	'--- ALTERAR A COR DE FUNDO DO HEADER DO DATAGRIDVIEW
	Private Sub dgvListagem_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
		If e.RowIndex = -1 Then
			'--- PRETO
			'Dim c1 As Color = Color.FromArgb(255, 54, 54, 54)
			'Dim c2 As Color = Color.FromArgb(255, 62, 62, 62)
			'Dim c3 As Color = Color.FromArgb(255, 98, 98, 98)
			'
			'--- AZUL
			Dim c1 As Color = Color.FromArgb(255, 143, 154, 168)
			Dim c2 As Color = Color.FromArgb(255, 100, 113, 130)
			Dim c3 As Color = Color.FromArgb(255, 74, 84, 96)
			'
			Dim br As LinearGradientBrush = New LinearGradientBrush(e.CellBounds, c1, c3, 90, True)
			Dim cb As ColorBlend = New ColorBlend()
			'
			cb.Positions = {0, CSng(0.5), 1}
			cb.Colors = {c1, c2, c3}
			br.InterpolationColors = cb
			e.Graphics.FillRectangle(br, e.CellBounds)
			e.PaintContent(e.ClipBounds)
			e.Handled = True
		End If
	End Sub
	'
#End Region
	'
#Region "VISUAL DESIGN"
	'
	Sub me_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
		pnlAtivas.BackColor = Color.WhiteSmoke
	End Sub
	'
	Private Sub panel_MouseEnter(sender As Object, e As EventArgs) Handles lblSituacao.MouseEnter, lblReservaAtiva.MouseEnter, pnlAtivas.MouseEnter
		pnlAtivas.BackColor = Color.Azure
	End Sub
	'
	Private Sub showToolTip()
		'
		Dim myControl As Control = pnlAtivas
		'
		' Cria a ToolTip e associa com o Form container.
		Dim toolTip1 As New ToolTip()
		'
		' Define o delay para a ToolTip.
		With toolTip1
			.AutoPopDelay = 2000
			.InitialDelay = 1000
			.ReshowDelay = 500
			.IsBalloon = True
			.UseAnimation = True
			.UseFading = True
		End With
		'
		If myControl.Tag = "" Then
			toolTip1.Show("Clique aqui para alterar a Situação ou pressione (F5)", myControl, myControl.Width - 30, -40, 1000)
		Else
			toolTip1.Show(myControl.Tag, myControl, myControl.Width - 30, -40, 1000)
		End If
		'
	End Sub
	'
#End Region '/ VISUAL DESIGN
	'
#Region "MENU CONTEXT RESERVA"
	'
	' CONTROLE DO MENU SUSPENSO
	'----------------------------------------------------------------------------------------------------------
	Private Sub dgvItens_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
		'
		If e.Button = MouseButtons.Right Then
			'
			Dim c As Control = DirectCast(sender, Control)
			Dim hit As DataGridView.HitTestInfo = dgvItens.HitTest(e.X, e.Y)
			dgvItens.ClearSelection()
			'
			'---VERIFICAÇÕES NECESSÁRIAS
			If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
			'
			' seleciona o ROW
			dgvItens.Rows(hit.RowIndex).Cells(0).Selected = True
			dgvItens.Rows(hit.RowIndex).Selected = True
			'
			' Habilita | Desabilita itens do menu
			Dim reserva As clReserva = dgvItens.Rows(hit.RowIndex).DataBoundItem
			Dim inPedido As Boolean = Not IsNothing(reserva.IDPedido)
			'
			'--- enable or disable items of menu
			miAbrirPedido.Enabled = inPedido
			miDesassociarDoPedido.Enabled = inPedido
			miExcluirReserva.Enabled = Not inPedido And reserva.IDSituacaoReserva = 1
			'
			'--- enable disable Estorno e Devolucao Adiantamento
			If If(reserva.ValorAntecipado, 0) > 0 Then '---> Is Reserva Prioritaria
				miEstornoDoValorAntecipado.Enabled = True
			Else
				miEstornoDoValorAntecipado.Enabled = False
			End If
			'
			' revela menu
			mnuReserva.Show(c.PointToScreen(e.Location))
			'
		End If
		'
	End Sub
	'
	Private Sub miEditarReserva_Click(sender As Object, e As EventArgs) Handles miEditarReserva.Click
		'
		btnEditar_Click(sender, e)
		'
	End Sub
	'
	Private Sub miExcluirReserva_Click(sender As Object, e As EventArgs) Handles miExcluirReserva.Click
		'
		If dgvItens.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhuma RESERVA selecionada na listagem", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If
		'
		Dim clR As clReserva = dgvItens.SelectedRows(0).DataBoundItem
		'
		If If(clR.ValorAntecipado, 0) > 0 Then
			AbrirDialog("Não é possível excluir uma Reserva que possua um valor antecipado..." & vbNewLine &
						"Faça o estorno do valor antecipado para depois excluir a reserva.",
						"Excluir Reserva", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		If AbrirDialog("Deseja realmente excluir a Reserva: " & vbCrLf &
					   clR.Produto & vbCrLf &
					   "Para: " & clR.ClienteNome,
					   "Excluir Reserva",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question,
					   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then
			Exit Sub
		End If
		'
		'--- VERIFICA Pedido
		Dim subtraiPedido As Boolean = False
		If Not IsNothing(clR.IDPedido) Then
			If AbrirDialog("Essa reserva já foi inserida em um pedido." & vbCrLf &
						   "Você deseja remover uma unidade desse do produto: " & vbCrLf &
						   clR.Produto & vbCrLf &
						   "do Pedido?",
						   "Reserva Vinculada",
						   frmDialog.DialogType.SIM_NAO,
						   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
				subtraiPedido = True
			End If
		End If
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			rBLL.DeleteReserva(clR, subtraiPedido)
			resLista.Remove(clR)
			FiltrarListagem()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Excluir a Reserva..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub miAbrirPedido_Click(sender As Object, e As EventArgs) Handles miAbrirPedido.Click
		'
		Dim pBLL As New PedidoBLL
		Dim reserva As clReserva = dgvItens.SelectedRows(0).DataBoundItem
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim pedido As clPedido = pBLL.GetPedidoPeloID(reserva.IDPedido)
			'
			Dim frm As New frmPedido(pedido)
			frm.MdiParent = My.Application.OpenForms().Item(0)
			'
			Close()
			frm.Show()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir o formulário de Pedido..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'
	End Sub
	'
	'--- ESTORNO VL ANTECIPADO
	'----------------------------------------------------------------------------------
	Private Sub miEstornoDoValorAntecipado_Click(sender As Object, e As EventArgs) Handles miEstornoDoValorAntecipado.Click
		'
		'--- verifica a situacao atual IS RESERVA ATIVA
		If ReservaSituacao.ReservaAtiva = False Then
			AbrirDialog("Não é possível ESTORNAR o valor do adiantamento de uma Reserva que não esta Ativa",
						"Estornar Adiantamento", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If
		'
		'--- verifica a quantidade de itens selecionados
		If dgvItens.SelectedRows.Count = 0 Then
			AbrirDialog("Necessário selecionar a reserva para ESTORNAR o VALOR DO ADIANTAMENTO...",
						"Selecionar", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If
		'
		'--- pergunta ao usuário se deseja realmente realizar alterações
		Dim message As String = "Você deseja realmente ESTORNAR o VALOR DO ADIANTAMENTO da Reserva selecionada?" &
			vbNewLine & vbNewLine &
			"ATENÇÃO: a reserva não será mais prioritária..."
		'
		If AbrirDialog(message, "Estornar Adiantamento",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question,
					   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Return
		'
		Try
			Dim selReserva As clReserva = dgvItens.SelectedRows(0).DataBoundItem
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			rBLL.Adiantamento_Estornar(selReserva)
			'
		Catch ex As AppException
			'
			'--- ERROR MESSAGE
			AbrirDialog("Não foi possível estornar o valor de adiantamento da reserva:" & vbNewLine &
						ex.Message,
						"Operação Cancelada",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
			'
		Catch ex As Exception
			'
			'--- ERROR MESSAGE
			MessageBox.Show("Houve uma exceção inesperada ao Alterar a situação da reserva no BD" & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
			'
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- atualiza a listagem
		Get_Dados()
		FiltrarListagem()
		AtualizaLabelSelecionados()
		'
	End Sub
	'
	'--- ALTERAR SITUACAO DA RESERVA INDIVIDUAL
	'----------------------------------------------------------------------------------
	Private Sub miAlterarSituacaoReserva_Click(sender As Object, e As EventArgs) Handles miAlterarSituacaoReserva.Click
		'
		'--- verifica a situacao atual if IS RESERVA ATIVA
		If ReservaSituacao.ReservaAtiva = False Then
			AbrirDialog("Não é possível alterar a Situação de Reservas que não estão Ativas",
						"Alterar Situação", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If
		'
		'--- verifica a quantidade de itens selecionados
		If dgvItens.SelectedRows.Count = 0 Then
			AbrirDialog("Necessário selecionar a reserva para alterar a situação...",
						"Selecionar", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If
		'
		'--- obtem a nova situacao
		Dim newSit As clReservaSituacao = GetNewSituacao()
		If newSit Is Nothing Then Exit Sub
		'
		'--- pergunta ao usuário se deseja realmente realizar alterações
		Dim message As String = "Você deseja realmente alterar a Reserva selecionada para" &
								vbNewLine &
								newSit.SituacaoReserva.ToUpper & "?"
		'
		If newSit.ReservaAtiva = False Then
			message += vbNewLine & "Essa alteração irá DESATIVAR definitavamente a reserva selecionada."
		End If
		'
		If AbrirDialog(message, "Alterar Situação",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question,
					   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Return
		'
		'--- check if exists ADIANTAMENTO on RESERVA ALTERADA
		'-----------------------------------------------------------------------------------------
		Dim selReserva As clReserva = dgvItens.SelectedRows(0).DataBoundItem
		Dim gerarDevolucao As Boolean = False
		Dim DevolucaoData As Date? = Nothing
		'
		If newSit.ReservaAtiva = False And If(selReserva.ValorAntecipado, 0) > 0 Then
			'
			message = "A reserva selecionada possui um valor de adiantamento. " &
				"Para que essa reserva seja desativada é necessário fazer a DEVOLUÇÃO do adiantamento para o cliente." &
				vbNewLine &
				"Tem certeza que deseja realizar a Devolução do Adiantamento?"
			'
			If AbrirDialog(message, "Alterar Situação",
						   frmDialog.DialogType.SIM_NAO,
						   frmDialog.DialogIcon.Question,
						   frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Return
			'
			'--- GET DEVOLUCAO DATA
			Dim frm As New frmDataInformar("Informe a Data do Caixa que a Devolução foi efetuada...",
										   EnumDataTipo.PassadoPresente, Obter_DataPadrao, Me)
			frm.ShowDialog()
			If frm.DialogResult = DialogResult.Cancel Then Exit Sub
			'
			DevolucaoData = frm.propDataInfo
			gerarDevolucao = True
			'
		End If
		'
		'--- atualiza os registros
		Dim accessBLL As New AcessoControlBLL
		Dim db As Object = accessBLL.GetNewAcessoWithTransaction()
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			rBLL.Reserva_AlteraSituacao(selReserva.IDReserva, newSit.IDSituacaoReserva, db)
			'
			'--- CHECK DEVOLUCAO
			If gerarDevolucao Then
				rBLL.Adiantamento_Devolucao(selReserva, DevolucaoData)
			End If
			'
			'--- COMMIT CHANGES
			accessBLL.CommitAcessoWithTransaction(db)
			'
		Catch ex As AppException
			'
			'--- ROOLBACK ALL CHANGES
			accessBLL.RollbackAcessoWithTransaction(db)
			'
			'--- ERROR MESSAGE
			AbrirDialog("Não foi possível alterar a situação:" & vbNewLine &
						ex.Message,
						"Operação Cancelada",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
			'
		Catch ex As Exception
			'
			'--- ROOLBACK ALL CHANGES
			accessBLL.RollbackAcessoWithTransaction(db)
			'
			'--- ERROR MESSAGE
			MessageBox.Show("Houve uma exceção inesperada ao Alterar a situação da reserva no BD" & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
			'
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- atualiza a listagem
		Get_Dados()
		FiltrarListagem()
		AtualizaLabelSelecionados()
		'
	End Sub

	Private Sub DevolucaoDoValorAntecipado()
		'

		'
	End Sub
	'
#End Region '/ MENU RESERVA
	'
#Region "OUTRAS FUNCOES"
	'
	Private Function GetNewSituacao() As clReservaSituacao
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim frm As New frmReservaSituacaoProcurar(True, ReservaSituacao, Me)
			'
			frm.ShowDialog()
			If frm.DialogResult <> vbOK Then Return Nothing
			'
			Return frm.ReservaSituacaoEscolhida
			'
		Catch ex As Exception
			Throw ex
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Function
	'
#End Region '/ OUTRAS FUNCOES
	'
End Class
