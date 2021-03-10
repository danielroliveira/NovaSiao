Imports CamadaBLL
Imports CamadaDTO

Public Class frmVendaEntrada
	'
	Private _formOrigem As Form
	Private _vlMaximo As Double
	Private _Pag As clMovimentacao
	Private bindPag As New BindingSource
	'
	Private listTipos As List(Of clMovTipo)
	Private listFormas As List(Of clMovForma)


	'
#Region "NEW | BINDING | COMBOBOX"
	'
	'-------------------------------------------------------------------------------------------------
	' SUB NEW
	'-------------------------------------------------------------------------------------------------
	Sub New(fOrigem As Form,
			TranVlTotal As Double,
			Pag As clMovimentacao,
			Optional Posicao As Point = Nothing)
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		_formOrigem = fOrigem
		_vlMaximo = TranVlTotal
		_Pag = Pag
		'
		'--- Preenche a lsita de Formas e Tipos
		Dim TipoBLL As New MovimentacaoBLL
		'
		'--- Get DataTable Tipos e Formas
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			listFormas = TipoBLL.MovForma_GET_List(Pag.IDFilial, True)
			listTipos = TipoBLL.MovTipo_GET_List(True)
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Evento..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		AutoCompleteFormas()

		bindPag.DataSource = _Pag
		PreencheDataBinding()
		'
		' Verifica valor do IDMovTipo pelo MovForma
		If IsNothing(_Pag.IDMovForma) Then
			'
			txtFormaTipo.Text = ""
			_Pag.IDMovTipo = Nothing
			'
		Else
			'
			Dim f = listFormas.Single(Function(x) x.IDMovForma = _Pag.IDMovForma)
			txtFormaTipo.Text = f.MovTipo
			_Pag.IDMovTipo = f.IDMovTipo
			'
		End If
		'
		lblConta.Text = ObterDefault("ContaDescricao")
		lblFilial.Text = ObterDefault("FilialDescricao")
		'
		'--- Define a posicao do form
		If Not IsNothing(Posicao) Then
			StartPosition = FormStartPosition.Manual
			Location = Posicao
		End If
		'
	End Sub
	'
	'------------------------------------------------------------------------------------------
	' PREENCHE O DATABINDING
	'------------------------------------------------------------------------------------------
	Private Sub PreencheDataBinding()
		'
		txtValor.DataBindings.Add("Text", bindPag, "MovValor", True, DataSourceUpdateMode.OnPropertyChanged)
		lstItens.DataBindings.Add("Text", bindPag, "IDMovForma", True, DataSourceUpdateMode.OnPropertyChanged)
		'
		' FORMATA OS VALORES DO DATABINDING
		AddHandler txtValor.DataBindings("Text").Format, AddressOf FormatCUR
		'
	End Sub
	'
	Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
		e.Value = FormatCurrency(e.Value, 2)
	End Sub

#End Region '/ NEW | BINDING | COMBOBOX
	'
#Region "LISTAGEM"
	'
	'--- PREENCHE LISTAGEM
	Private Sub AutoCompleteFormas()

		If IsNothing(_Pag.IDMovTipo) OrElse _Pag.IDMovTipo = 0 Then

			If txtForma.Text.Length = 0 Then
				lstItens.DataSource = listFormas
			Else
				lstItens.DataSource = listFormas.Where(Function(x) x.MovForma.ToUpper() Like "*" & txtForma.Text.ToUpper() & "*").ToList()
			End If

		Else

			If txtForma.Text.Length = 0 Then
				lstItens.DataSource = listFormas.Where(Function(x) x.IDMovTipo = _Pag.IDMovTipo).ToList()
			Else
				lstItens.DataSource = listFormas.Where(Function(x) x.IDMovTipo = _Pag.IDMovTipo And x.MovForma.ToUpper() Like "*" & txtForma.Text.ToUpper() & "*").ToList()
			End If

		End If


		clnForma.ValueMember = "IDMovForma"
		clnForma.DisplayMember = "MovForma"

	End Sub
	'
	Private Sub txtForma_TextChanged(sender As Object, e As EventArgs) Handles txtForma.TextChanged
		AutoCompleteFormas()
	End Sub


#End Region '/ LISTAGEM
	'
#Region "ATALHOS | FUNCOES UTILITARIAS"
	'
	'------------------------------------------------------------------------------------------
	' USAR TAB AO KEYPRESS ENTER
	'------------------------------------------------------------------------------------------
	Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) _
		Handles txtValor.KeyDown, txtFormaTipo.KeyDown, txtForma.KeyDown,
		lstItens.KeyDown
		'
		Dim ctr As Control = DirectCast(sender, Control)

		If e.KeyCode = Keys.Enter Then

			e.SuppressKeyPress = True
			SendKeys.Send("{Tab}")

		ElseIf e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.F4 Then
			e.Handled = True

			Select Case ctr.Name
				Case txtFormaTipo.Name
					SetFormaTipo()
			End Select

		ElseIf (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Or (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) Then

			'--- cria um array de controles que serao liberados ao KEYPRESS
			Dim controlesLiberados As Control() = {txtFormaTipo, txtValor}

			'--- cria um array de controles que serao liberados ao KEYPRESS
			Dim controlesID As Control() = {txtFormaTipo}

			If controlesLiberados.Contains(ctr) Then
				e.Handled = False
			ElseIf controlesID.Contains(ctr) Then

				If Not String.IsNullOrEmpty(ctr.Text) AndAlso Not Integer.TryParse(ctr.Text, 0) Then
					ctr.Text = String.Empty
				End If

				e.Handled = False
			Else
				e.Handled = True
				e.SuppressKeyPress = True
			End If

		ElseIf e.Alt Then
			e.Handled = False
		Else
			Dim controlesBloqueados As Control() = {txtFormaTipo}

			If controlesBloqueados.Contains(ctr) Then
				e.Handled = True
				e.SuppressKeyPress = True
			End If

		End If
		'
	End Sub
	'
	'==========================================================================================
	' SET FORMA TIPO
	'==========================================================================================
	Private Sub btnSetFormaTipo_Click(sender As Object, e As EventArgs) Handles btnSetFormaTipo.Click
		SetFormaTipo()
	End Sub
	'
	Private Sub SetFormaTipo()
		'
		If listTipos.Count = 0 Then
			AbrirDialog("Não há Formas de Entradas cadastradas...", "Formas de Entrada",
						frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If

		Dim dic As Dictionary(Of Integer, String) = listTipos.ToDictionary(Function(x) CType(x.IDMovTipo, Integer), Function(x) x.MovTipo)

		Dim frm As New frmComboLista(dic, txtFormaTipo, _Pag.IDMovTipo)

		'--- show form
		frm.ShowDialog()
		'
		'--- check return
		If frm.DialogResult = DialogResult.OK Then
			_Pag.IDMovTipo = CType(frm.propEscolha.Key, Short)
			txtFormaTipo.Text = frm.propEscolha.Value
			AutoCompleteFormas()
		End If
		'
		'--- select
		txtFormaTipo.Focus()
		txtFormaTipo.SelectAll()

	End Sub

	'
	'------------------------------------------------------------------------------------------
	'--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
	'--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ITENS DA LISTAGEM
	'------------------------------------------------------------------------------------------
	Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
		If e.KeyCode = Keys.Escape Then
			e.Handled = True
			btnCancelar_Click(New Object, New EventArgs)
			'
		ElseIf e.KeyCode = Keys.Up Then
			e.Handled = True
			'
			If lstItens.Items.Count > 0 Then
				If lstItens.SelectedItems.Count > 0 Then
					Dim i As Integer = lstItens.SelectedItems(0).Index
					'
					lstItens.Items(i).Selected = False
					'
					If i = 0 Then
						i = lstItens.Items.Count
					End If
					'
					lstItens.Items(i - 1).Selected = True
					lstItens.EnsureVisible(i - 1)
				Else
					lstItens.Items(0).Selected = True
					lstItens.EnsureVisible(0)
				End If
			End If
			'
		ElseIf e.KeyCode = Keys.Down Then
			e.Handled = True
			'
			If lstItens.Items.Count > 0 Then
				If lstItens.SelectedItems.Count > 0 Then
					Dim i As Integer = lstItens.SelectedItems(0).Index
					'
					lstItens.Items(i).Selected = False
					'
					If i = lstItens.Items.Count - 1 Then
						i = -1
					End If
					'
					lstItens.Items(i + 1).Selected = True
					lstItens.EnsureVisible(i + 1)
				Else
					lstItens.Items(0).Selected = True
				End If
			End If
			'
		End If
	End Sub

	'
	'------------------------------------------------------------------------------------------
	'--- BLOQUEIA PRESS A TECLA (+)
	'---------------------------------------------------------------------------------------
	Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
		'
		If e.KeyChar = "+" Then
			'--- cria uma lista de controles que serao impedidos de receber '+'
			Dim controlesBloqueados As String() = {
				"txtFormaTipo"
			}
			'
			If controlesBloqueados.Contains(ActiveControl.Name) Then
				e.Handled = True
			End If
			'
		End If
		'
	End Sub
	'
	'------------------------------------------------------------------------------------------
	' CRIA UM ATALHO NUMERICO PARA o CONTROLE
	'------------------------------------------------------------------------------------------
	Private Sub txtFormaTipo_KeyPress(sender As Object, e As KeyPressEventArgs) _
		Handles txtFormaTipo.KeyPress

		If Char.IsNumber(e.KeyChar) Then
			e.Handled = True
			'

			If listTipos.Count > 0 Then

				Dim tipo As clMovTipo = listTipos.FirstOrDefault(Function(x) x.IDMovTipo = Integer.Parse(e.KeyChar.ToString()))

				If IsNothing(tipo) Then Exit Sub

				_Pag.IDMovTipo = tipo.IDMovTipo
				txtFormaTipo.Text = tipo.MovTipo
				AutoCompleteFormas()

			End If

		ElseIf Char.IsLetter(e.KeyChar) Then
			e.Handled = True

		Else
			e.Handled = True
		End If
		'
	End Sub
	'
#End Region '/ ATALHOS | FUNCOES UTILITARIAS
	'
#Region "BUTONS ACTIONS"
	'
	'------------------------------------------------------------------------------------------
	' ACAO DOS BOTOES
	'------------------------------------------------------------------------------------------
	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
		'
		'--- Verifica campos/valores
		If IsNothing(_Pag.IDMovTipo) Then
			MessageBox.Show("O campo TIPO de Entrada não pode ficar vazio..." & vbNewLine &
							"Favor escolher um valor para esse campo.", "Campo Vazio",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			txtFormaTipo.Focus()
			Exit Sub
		End If
		'
		If lstItens.SelectedItems.Count > 0 Then
			_Pag.IDMovForma = lstItens.SelectedItems(0).Value
		Else
			MessageBox.Show("O campo FORMA de Entrada não pode ficar vazio..." & vbNewLine &
							"Favor escolher um valor para esse campo.", "Campo Vazio",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			lstItens.Focus()
			Exit Sub
		End If
		'
		If IsNothing(_Pag.MovValor) OrElse _Pag.MovValor <= 0 OrElse _Pag.MovValor > _vlMaximo Then
			'
			MessageBox.Show("O VALOR da Entrada não pode ser igual ou menor que Zero..." & vbNewLine &
							"bem como também não pode ser maior que o total da venda..." & vbNewLine &
							"Favor escolher um valor para esse campo.", "Campo Vazio",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			txtValor.Focus()
			txtValor.SelectAll()
			Exit Sub
			'
		End If
		'
		'--- Devolve o credito para o formOrigem
		_Pag.MovForma = lstItens.SelectedItems(0).Text
		_Pag.IDMovForma = lstItens.SelectedItems(0).Value
		_Pag.IDMeio = listFormas.First(Function(x) x.IDMovForma = _Pag.IDMovForma).IDMeio
		_Pag.MovValor = txtValor.Text
		'
		bindPag.EndEdit()
		DialogResult = DialogResult.OK
		'
	End Sub
	'
	'--- BTN FECHAR | CANCELAR
	Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
		'
		bindPag.CancelEdit()
		DialogResult = DialogResult.Cancel
		'
	End Sub
	'
#End Region '/ BUTONS ACTIONS
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
	End Sub
	'
	Private Sub frmVendaPagamento_Closed(sender As Object, e As EventArgs) Handles Me.Closed
		If IsNothing(_formOrigem) Then Exit Sub
		'
		For Each c As Control In _formOrigem.Controls
			If c.Name = "Panel1" Then
				c.BackColor = Color.SlateGray
			End If
		Next
	End Sub

	Private Sub lstItens_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstItens.SelectedIndexChanged

		If lstItens.SelectedItems.Count > 0 Then lblForma.Text = lstItens.SelectedItems(0).Text

	End Sub
	'
#End Region '/ EFEITO VISUAL
	'
End Class
