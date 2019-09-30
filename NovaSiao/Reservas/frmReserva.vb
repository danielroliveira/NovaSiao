Imports CamadaDTO
Imports CamadaBLL
Imports System.ComponentModel
'
Public Class frmReserva
	Private _Reserva As clReserva
	Private resBLL As New ReservaBLL
	Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
	Private _formOrigem As Form
	Private bindReserva As New BindingSource
	Private _RegistroBloqueado As Boolean = False
	Private ctrlrect As New Rectangle(0, 0, 0, 0) '--- rectangle created on chkProdutoConhecido.focus
	'
#Region "LOAD E PROPERTIES"
	'
	Sub New(objReserva As clReserva, Optional formOrigem As Form = Nothing)
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		_formOrigem = formOrigem
		'
		If IsNothing(objReserva) Then
			MessageBox.Show("Esse formulário não pode ser aberto assim...", "Erro ao abrir")
		End If
		'
		propReserva = objReserva
		PreencheDataBindings()
		'
		Handler_MouseMove()
		Handler_MouseUp()
		Handler_MouseDown()
		'
		AddHandlerControles() ' adiciona o handler para selecionar e usar tab com a tecla enter
		'
		AddHandler chkProdutoConhecido.CheckedChanged, AddressOf chkProdutoConhecido_CheckedChanged
		'
	End Sub
	'
	Private Sub frmReserva_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		txtFuncionario.Focus()
	End Sub
	'
	Private Property Sit As EnumFlagEstado
		'
		Get
			Return _Sit
		End Get
		'
		Set(value As EnumFlagEstado)
			'
			_Sit = value
			'
			If _Sit = EnumFlagEstado.RegistroSalvo Then
				'
				btnSalvar.Enabled = False
				btnNovo.Enabled = True
				btnCancelar.Enabled = False
				btnProcurar.Enabled = True
				lblIDReserva.Text = Format(_Reserva.IDReserva, "0000")
				'
			ElseIf _Sit = EnumFlagEstado.Alterado Then
				'
				btnSalvar.Enabled = True
				btnNovo.Enabled = False
				btnCancelar.Enabled = True
				btnProcurar.Enabled = False
				'
			ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
				'
				txtFuncionario.Select()
				btnSalvar.Enabled = True
				btnNovo.Enabled = False
				btnCancelar.Enabled = True
				btnProcurar.Enabled = False
				lblIDReserva.Text = "NOVO"
				_Reserva.IDFilial = Obter_FilialPadrao()
				_Reserva.ApelidoFilial = ObterDefault("FilialDescricao")
				'
			End If
			'
		End Set
		'
	End Property
	'
	Public Property propReserva() As clReserva
		'
		Get
			Return _Reserva
		End Get
		'
		Set(ByVal value As clReserva)
			'
			_Reserva = value
			bindReserva.DataSource = _Reserva
			'
			'--- check if Is New
			If Not IsNothing(_Reserva.IDReserva) Then
				Sit = EnumFlagEstado.RegistroSalvo
			Else
				Sit = EnumFlagEstado.NovoRegistro
			End If
			'
			'--- check ProdutoConhecido
			VerificaProdutoConhecido()
			'
			'--- define MaxDate
			dtpReservaData.MaxDate = Today
			'
			'--- check if Is Conected with PEDIDO and Block Reserva
			If Not IsNothing(_Reserva.IDPedido) OrElse _Reserva.IDSituacaoReserva > 1 Then
				RegistroBloqueado = True
				AddHandlerCancelUpdate()
			Else
				RegistroBloqueado = False
				RemoveHandlerCancelUpdate()
			End If
			'
			'--- Disabled btnAdiantamento
			If If(_Reserva.ValorAntecipado, 0) > 0 Then btnAdiantamento.Enabled = False
			'
			'--- Disable btnProcura if source form is ReservaProcurar
			If Not IsNothing(_formOrigem) AndAlso TypeOf _formOrigem IsNot frmReservaProcurar Then
				btnProcurar.Enabled = False
			End If
			'
		End Set
		'
	End Property
	'
#End Region
	'
#Region "REGISTRO BLOQUEADO"
	'
	Private Property RegistroBloqueado As Boolean
		'
		Get
			If _RegistroBloqueado Then
				AbrirDialog("Esse registro está bloqueado para alterações..." +
							"Não é possível salvá-lo.",
							"Registro Bloqueado",
							frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			End If
			Return _RegistroBloqueado
		End Get
		'
		Set(value As Boolean)
			_RegistroBloqueado = value
		End Set
		'
	End Property
	'
	Private Sub CancelUpdateHandler(sender As Object, e As KeyPressEventArgs)
		e.Handled = True
	End Sub
	'
	Private Sub AddHandlerCancelUpdate()
		'
		For Each c As Control In Me.Controls
			'
			If c.HasChildren Then
				For Each cp As Control In c.Controls
					If TypeOf cp Is TextBox Then
						AddHandler cp.KeyPress, AddressOf CancelUpdateHandler
					ElseIf TypeOf cp Is DateTimePicker Then
						AddHandler cp.KeyPress, AddressOf CancelUpdateHandler
					ElseIf TypeOf cp Is CheckBox Then
						AddHandler cp.KeyPress, AddressOf CancelUpdateHandler
					End If
				Next
			Else
				If TypeOf c Is TextBox Then
					AddHandler c.KeyPress, AddressOf CancelUpdateHandler
				ElseIf TypeOf c Is MaskedTextBox Then
					AddHandler c.KeyPress, AddressOf CancelUpdateHandler
				End If
			End If
			'
		Next
		'
	End Sub
	'
	Private Sub RemoveHandlerCancelUpdate()
		'
		For Each c As Control In Me.Controls
			'
			If c.HasChildren Then
				For Each cp As Control In c.Controls
					RemoveHandler cp.KeyPress, AddressOf CancelUpdateHandler
				Next
			Else
				RemoveHandler c.KeyPress, AddressOf CancelUpdateHandler
			End If
			'
		Next
		'
	End Sub
	'
#End Region '/ REGISTRO BLOQUEADO
	'
#Region "DATABINDINGS"

	Private Sub PreencheDataBindings()
		' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
		' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
		'
		lblIDReserva.DataBindings.Add("Tag", bindReserva, "IDReserva")
		lblFilial.DataBindings.Add("Text", bindReserva, "ApelidoFilial")
		dtpReservaData.DataBindings.Add("Value", bindReserva, "ReservaData", True, DataSourceUpdateMode.OnPropertyChanged, "  /  /")
		txtFuncionario.DataBindings.Add("Text", bindReserva, "ApelidoFuncionario")
		txtClienteNome.DataBindings.Add("Text", bindReserva, "ClienteNome", True, DataSourceUpdateMode.OnPropertyChanged)
		lblTelefoneA.DataBindings.Add("Text", bindReserva, "TelefoneA")
		lblTelefoneB.DataBindings.Add("Text", bindReserva, "TelefoneB")
		picWathsapp.DataBindings.Add("Visible", bindReserva, "TemWhatsapp")
		lblClienteEmail.DataBindings.Add("Text", bindReserva, "ClienteEmail")
		txtRGProduto.DataBindings.Add("Text", bindReserva, "RGProduto", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
		txtProduto.DataBindings.Add("Text", bindReserva, "Produto", True, DataSourceUpdateMode.OnPropertyChanged)
		txtPVenda.DataBindings.Add("Text", bindReserva, "PVenda", True, DataSourceUpdateMode.OnPropertyChanged, String.Empty)
		txtAutor.DataBindings.Add("Text", bindReserva, "Autor", True, DataSourceUpdateMode.OnPropertyChanged)
		txtFornecedor.DataBindings.Add("Text", bindReserva, "Fornecedor")
		txtFabricante.DataBindings.Add("Text", bindReserva, "Fabricante")
		txtProdutoTipo.DataBindings.Add("Text", bindReserva, "ProdutoTipo")
		txtObservacao.DataBindings.Add("Text", bindReserva, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
		chkProdutoConhecido.DataBindings.Add("Checked", bindReserva, "ProdutoConhecido", True, DataSourceUpdateMode.OnPropertyChanged)
		lblValorAntecipado.DataBindings.Add("Text", bindReserva, "ValorAntecipado")
		'
		' FORMATA OS VALORES DO DATABINDING
		AddHandler lblIDReserva.DataBindings("Tag").Format, AddressOf idFormatRG
		AddHandler txtRGProduto.DataBindings("Text").Format, AddressOf idFormatRG
		AddHandler txtPVenda.DataBindings("Text").Format, AddressOf FormatCUR
		AddHandler lblValorAntecipado.DataBindings("Text").Format, AddressOf FormatCUR
		'
		' ADD HANDLER PARA DATABINGS
		AddHandler DirectCast(bindReserva.CurrencyManager.Current, clReserva).AoAlterar, AddressOf HandlerAoAlterar
		'
	End Sub
	'
	Private Sub HandlerAoAlterar()
		'
		If RegistroBloqueado Then Exit Sub
		'
		If bindReserva.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
			Sit = EnumFlagEstado.Alterado
		End If
		'
	End Sub
	'
	' FORMATA OS BINDINGS
	Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
		If IsDBNull(e.Value) Then Exit Sub
		e.Value = Format(e.Value, "0000")
	End Sub
	'
	Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
		e.Value = FormatCurrency(e.Value, 2)
	End Sub
	'
#End Region
	'
#Region "ACAO BOTOES"
	'
	'--- BTN PROCURAR
	Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Close()
			'
			If Not IsNothing(_formOrigem) AndAlso TypeOf _formOrigem Is frmReservaProcurar Then
				_formOrigem.Visible = True
				Return
			End If
			'
			Dim fProc As New frmReservaProcurar
			fProc.Show()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao abrir Formulário..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- BTN NOVO
	Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
		propReserva = New clReserva
		Sit = EnumFlagEstado.NovoRegistro
		txtFuncionario.Focus()
	End Sub
	'
	'--- BTN CANCELAR
	Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
		'
		If Sit = EnumFlagEstado.NovoRegistro Then
			btnProcurar_Click(btnCancelar, New EventArgs)
			'
		ElseIf Sit = EnumFlagEstado.Alterado Then
			bindReserva.CancelEdit()
		End If
		'
		Sit = EnumFlagEstado.RegistroSalvo
		'
	End Sub
	'
	'--- BTN FECHAR
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
		'
		If Sit <> EnumFlagEstado.RegistroSalvo Then
			If MessageBox.Show("O Registro de Reserva inserido ou alterado ainda NÃO FOI SALVO..." & vbNewLine &
							   "Deseja realmente sair e perder as alterações?", "Registro Não foi Salvo",
							   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
							   MessageBoxDefaultButton.Button2) = DialogResult.No Then
				txtFuncionario.Focus()
				Exit Sub
			Else
				bindReserva.CancelEdit()
			End If
		ElseIf _RegistroBloqueado Then
			bindReserva.CancelEdit()
		End If
		'
		RemoveHandler DirectCast(bindReserva.CurrencyManager.Current, clReserva).AoAlterar, AddressOf HandlerAoAlterar
		AutoValidate = AutoValidate.Disable
		Me.Close()
		'MostraMenuPrincipal()
		'
	End Sub
	'
	'--- FORM CLOSED - FIND OPENING RESERVA PROCURAR
	'----------------------------------------------------------------------------------
	Private Sub frmReserva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
		If e.CloseReason = CloseReason.FormOwnerClosing Or e.CloseReason = CloseReason.UserClosing Then
			'
			If Not IsNothing(_formOrigem) Then
				_formOrigem.Visible = True
			Else
				MostraMenuPrincipal()
			End If
			'
		End If
		'
	End Sub
	'
	'--- INSERT ADD ADIANTAMENTO
	'----------------------------------------------------------------------------------
	Private Sub btnAdiantamento_Click(sender As Object, e As EventArgs) Handles btnAdiantamento.Click
		'
		'--- check if reserva is Saved
		If _Reserva.IDReserva Is Nothing OrElse Sit <> EnumFlagEstado.RegistroSalvo Then
			AbrirDialog("É necessário salvar a reserva para inserir um adiantemento...",
						"Criar Adiantamento", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			Exit Sub
		End If
		'
		'--- check if there is PrecoVenda Esperado
		If _Reserva.PVenda Is Nothing OrElse _Reserva.PVenda = 0 Then
			AbrirDialog("É necessário indicar o valor esperado do produto para inserir um adiantamento...",
						"Criar Adiantamento", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			txtPVenda.Focus()
			Exit Sub
		End If
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			Dim propMovEntrada As clMovimentacao = Nothing
			'
			Using frmA As New frmAdiantamentoEntrada(_Reserva.IDReserva,
													 _Reserva.ClienteNome,
													 _Reserva.PVenda, Me)
				frmA.ShowDialog()
				If frmA.DialogResult <> DialogResult.OK Then Exit Sub
				'
				propMovEntrada = frmA.propMovEntrada
				'
			End Using
			'
			'--- EXECUTE
			If resBLL.Adiantamento_Insert(_Reserva, propMovEntrada) Then
				AbrirDialog("Adiantamento de reserva efetuado com sucesso!",
							"Entrada de Reserva",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Information)
				_Reserva.ValorAntecipado = propMovEntrada.MovValor
				lblValorAntecipado.DataBindings.Item("Text").ReadValue()
				btnAdiantamento.Enabled = False
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir registro de Adiantamento..." & vbNewLine &
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
#Region "BOTOES DE PROCURA"
	'
	Private Sub btnClienteSimplesEditar_Click(sender As Object, e As EventArgs) Handles btnClienteSimplesEditar.Click
		'
		If _RegistroBloqueado Then Exit Sub
		'
		If _Reserva.IDClienteSimples Is Nothing Then
			AbrirDialog("Não como editar os dados do Cliente porque ainda não foi definido um...",
						"Cliente Indefinido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim cBLL As New ClienteSimplesBLL
			Dim cliente As clClienteSimples = cBLL.GetClientePeloID(_Reserva.IDClienteSimples)
			'
			Using frmC As New frmClienteSimples(cliente, Me, True)
				frmC.ShowDialog()
				'
				If frmC.DialogResult = DialogResult.OK Then
					cliente = frmC.propCliente
				Else
					Exit Sub
				End If
				'
			End Using
			'
			'--- DEFINE CLIENTE PREENCHE LABELS
			txtClienteNome.Text = cliente.ClienteNome
			_Reserva.TelefoneA = cliente.TelefoneA
			lblTelefoneA.DataBindings.Item("Text").ReadValue()
			_Reserva.TelefoneB = cliente.TelefoneB
			lblTelefoneB.DataBindings.Item("Text").ReadValue()
			_Reserva.ClienteEmail = cliente.ClienteEmail
			lblClienteEmail.DataBindings.Item("Text").ReadValue()
			_Reserva.TemWhatsapp = cliente.TemWhatsapp
			picWathsapp.DataBindings.Item("Visible").ReadValue()
			_Reserva.IDClienteSimples = cliente.IDClienteSimples
			'
			txtClienteNome.Focus()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir o Form de Cliente..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub btnClienteSimples_Click(sender As Object, e As EventArgs) Handles btnClienteSimples.Click
		'
		If _RegistroBloqueado Then Exit Sub
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- save old IDCiente
			Dim oldID As Integer? = _Reserva.IDClienteSimples
			Dim ClienteEscolhido As clClienteSimples = Nothing
			'
			Using frmC As New frmClienteSimplesProcurar(True, Me)
				'
				frmC.ShowDialog()
				'
				If frmC.DialogResult = DialogResult.OK Then
					ClienteEscolhido = frmC.propCliente_Escolha
				ElseIf frmC.DialogResult = DialogResult.Retry Then
					ClienteEscolhido = frmC.propCliente_Escolha
				Else
					txtClienteNome.Focus()
					Exit Sub
				End If
				'
			End Using
			'
			'--- CHECK IF NEW BUTTON WAS PRESSED
			If ClienteEscolhido Is Nothing OrElse ClienteEscolhido.IDClienteSimples Is Nothing Then
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				Using frmC As New frmClienteSimples(New clClienteSimples, Me, True)
					frmC.ShowDialog()
					'
					If frmC.DialogResult = DialogResult.OK Then
						ClienteEscolhido = frmC.propCliente
					Else
						txtClienteNome.Focus()
						Exit Sub
					End If
					'
				End Using
				'
			End If
			'
			'--- DEFINE CLIENTE PREENCHE LABELS
			txtClienteNome.Text = ClienteEscolhido.ClienteNome
			_Reserva.TelefoneA = ClienteEscolhido.TelefoneA
			lblTelefoneA.DataBindings.Item("Text").ReadValue()
			_Reserva.TelefoneB = ClienteEscolhido.TelefoneB
			lblTelefoneB.DataBindings.Item("Text").ReadValue()
			_Reserva.ClienteEmail = ClienteEscolhido.ClienteEmail
			lblClienteEmail.DataBindings.Item("Text").ReadValue()
			_Reserva.TemWhatsapp = ClienteEscolhido.TemWhatsapp
			picWathsapp.DataBindings.Item("Visible").ReadValue()
			_Reserva.IDClienteSimples = ClienteEscolhido.IDClienteSimples
			'
			If Sit = EnumFlagEstado.RegistroSalvo Then
				If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_Reserva.IDClienteSimples), 0, _Reserva.IDClienteSimples) Then
					Sit = EnumFlagEstado.Alterado
				End If
			End If
			'
			txtClienteNome.Focus()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Abrir o Form de Procurar Cliente..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	Private Sub btnProcFuncionario_Click(sender As Object, e As EventArgs) Handles btnProcFuncionario.Click
		'
		If _RegistroBloqueado Then Exit Sub
		'
		Dim frmF As New frmFuncionarioEscolher(False, Me)
		Dim oldID As Integer? = _Reserva.IDFuncionario
		'
		frmF.ShowDialog()
		If frmF.DialogResult = DialogResult.Cancel Then
			txtFuncionario.Clear()
			_Reserva.IDFuncionario = Nothing
		Else
			txtFuncionario.Text = frmF.NomeEscolhido
			_Reserva.IDFuncionario = frmF.IDEscolhido
		End If
		'
		If Sit = EnumFlagEstado.RegistroSalvo Then
			If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_Reserva.IDFuncionario), 0, _Reserva.IDFuncionario) Then
				Sit = EnumFlagEstado.Alterado
			End If
		End If
		'
		txtFuncionario.Focus()
		'
	End Sub
	'
	Private Sub btnProcProdutoTipo_Click(sender As Object, e As EventArgs) Handles btnProcProdutoTipo.Click
		'
		If _RegistroBloqueado Then Exit Sub
		'
		If _Reserva.ProdutoConhecido Then Exit Sub
		'
		Dim frmT As New frmProdutoProcurarTipo(Me, _Reserva.IDProdutoTipo)
		Dim oldID As Integer? = _Reserva.IDProdutoTipo
		'
		frmT.ShowDialog()
		If frmT.DialogResult = DialogResult.Cancel Then
			txtProdutoTipo.Clear()
			_Reserva.IDProdutoTipo = Nothing
		Else
			txtProdutoTipo.Text = frmT.propTipo_Escolha
			_Reserva.IDProdutoTipo = frmT.propIdTipo_Escolha
		End If
		'
		If Sit = EnumFlagEstado.RegistroSalvo Then
			If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_Reserva.IDProdutoTipo), 0, _Reserva.IDProdutoTipo) Then
				Sit = EnumFlagEstado.Alterado
			End If
		End If
		'
		txtProdutoTipo.Focus()
		'
	End Sub
	'
	Private Sub btnProcAutores_Click(sender As Object, e As EventArgs) Handles btnProcAutores.Click
		'
		If _RegistroBloqueado Then Exit Sub
		'
		If _Reserva.ProdutoConhecido Then Exit Sub
		'
		Dim frmA As New frmAutoresProcurar(Me)
		Dim oldAutor As String = _Reserva.Autor
		'
		frmA.ShowDialog()
		If frmA.DialogResult = DialogResult.Cancel Then
			txtAutor.Clear()
		Else
			txtAutor.Text = frmA.propAutorEscolhido
		End If
		'
		If Sit = EnumFlagEstado.RegistroSalvo Then
			If oldAutor <> txtAutor.Text Then
				Sit = EnumFlagEstado.Alterado
			End If
		End If
		'
		txtAutor.Focus()
		'
	End Sub
	'
	Private Sub btnProcFabricantes_Click(sender As Object, e As EventArgs) Handles btnProcFabricantes.Click
		'
		If _RegistroBloqueado Then Exit Sub
		'
		If _Reserva.ProdutoConhecido Then Exit Sub
		'
		Dim frmF As New frmFabricanteProcurar(Me, _Reserva.IDFabricante)
		Dim oldIDFabricante As Integer? = _Reserva.IDFabricante
		'
		frmF.ShowDialog()
		If frmF.DialogResult = DialogResult.Cancel Then
			txtFabricante.Clear()
			_Reserva.IDFabricante = Nothing
		Else
			txtFabricante.Text = frmF.propFab_Escolha
			_Reserva.IDFabricante = frmF.propIDFab_Escolha
		End If
		'
		If Sit = EnumFlagEstado.RegistroSalvo Then
			If IIf(IsNothing(oldIDFabricante), 0, oldIDFabricante) <> IIf(IsNothing(_Reserva.IDFabricante), 0, _Reserva.IDFabricante) Then
				Sit = EnumFlagEstado.Alterado
			End If
		End If
		'
		txtFabricante.Focus()
		'
	End Sub
	'
	Private Sub btnProcFornecedores_Click(sender As Object, e As EventArgs) Handles btnProcFornecedores.Click
		'
		If _RegistroBloqueado Then Exit Sub
		'
		Dim frmF As New frmFornecedorProcurar(True, Me)
		Dim oldIDFornecedor As Integer? = _Reserva.IDFornecedor
		'
		frmF.ShowDialog()
		If frmF.DialogResult = DialogResult.Cancel Then
			txtFornecedor.Clear()
			_Reserva.IDFornecedor = Nothing
		Else
			txtFornecedor.Text = frmF.propFornecedor_Escolha.Cadastro
			_Reserva.IDFornecedor = frmF.propFornecedor_Escolha.IDPessoa
		End If
		'
		If Sit = EnumFlagEstado.RegistroSalvo Then
			If IIf(IsNothing(oldIDFornecedor), 0, oldIDFornecedor) <> IIf(IsNothing(_Reserva.IDFornecedor), 0, _Reserva.IDFornecedor) Then
				Sit = EnumFlagEstado.Alterado
			End If
		End If
		'
		txtFornecedor.Focus()
		'
	End Sub
	'
#End Region
	'
#Region "SALVAR REGISTRO"
	'
	' SALVAR O REGISTRO
	'---------------------------------------------------------------------------------------------------
	Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
		'
		'--- verifica os dados se os campos estão preechidos
		If VerificaDados() = False Then Exit Sub
		'
		'--- define os dados da classe
		Dim NewReservaID As Long
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Salva mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
			If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
				NewReservaID = resBLL.Reserva_Inserir(_Reserva)
			ElseIf Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
				NewReservaID = resBLL.Reserva_Alterar(_Reserva)
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Um erro ocorreu ao salvar o registro!" & vbCrLf &
							ex.Message, "Erro ao Salvar Registro",
							MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
		'--- Verifica se houve Retorno da Função de Salvar
		If IsNumeric(NewReservaID) AndAlso NewReservaID <> 0 Then
			'
			'--- insert NEW ID
			_Reserva.IDReserva = NewReservaID
			lblIDReserva.DataBindings("Tag").ReadValue()
			bindReserva.EndEdit()
			bindReserva.CurrencyManager.Refresh()
			'
			'--- Retorna o número de Registro
			If Sit = EnumFlagEstado.NovoRegistro Then '---> NOVO
				'
				'--- Altera a Situação
				Sit = EnumFlagEstado.RegistroSalvo
				'
				Dim tryInsertValor As Boolean = False
				'
				'--- INSERT VALOR ? ask user Add Adiantamento
				If propReserva.ProdutoConhecido And If(propReserva.PVenda, 0) > 0 Then
					'
					If AbrirDialog("Registro Salvo com sucesso!" & vbNewLine &
								   "Deseja inserir um adiantamento de valor a essa reserva?",
								   "Inserir Adiantamento",
								   frmDialog.DialogType.SIM_NAO,
								   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
						'
						tryInsertValor = True
						'
					End If
					'
				End If
				'
				'--- INSERT ADIANTAMENTO
				If tryInsertValor Then
					btnAdiantamento_Click(sender, e)
				End If
				'
			Else
				'
				'--- Altera a Situação
				Sit = EnumFlagEstado.RegistroSalvo
				'
				'--- Mensagem de Sucesso:
				AbrirDialog("Registro Salvo com sucesso!",
							"Registro Salvo",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Information)
				'
			End If
			'
		Else
			MsgBox("Registro NÃO pôde ser salvo!", vbInformation, "Erro ao Salvar")
		End If
		'
	End Sub
	'
	' FAZER VERIFICAÇÃO ANTES DE SALVAR
	Private Function VerificaDados() As Boolean
		'
		EProvider.Clear()
		'
		Dim f As New Utilidades
		'
		If Not f.VerificaDadosClasse(txtFuncionario, "Nome do Funcionario", _Reserva, EProvider) Then
			Return False
		End If
		'
		If Not f.VerificaDadosClasse(dtpReservaData, "Data da Reserva", _Reserva, EProvider) Then
			Return False
		End If
		'
		If Not f.VerificaDadosClasse(txtClienteNome, "Nome do Cliente", _Reserva, EProvider) Then
			Return False
		End If
		'
		'--- Verifica se existe pelo menos um telefone Inserido na Reserva
		Dim telA As Boolean = IsNothing(_Reserva.TelefoneA)
		Dim telB As Boolean = IsNothing(_Reserva.TelefoneB)
		'
		If telA And telB Then
			MessageBox.Show("Deve haver pelo menos um telefone cadastrado nos dados da Reserva...", "Telefone de Contato",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			txtClienteNome.Focus()
			Return False
		End If
		'
		If Not f.VerificaDadosClasse(txtProduto, "Produto da Reserva", _Reserva, EProvider) Then
			Return False
		End If
		'
		If Not f.VerificaDadosClasse(txtProdutoTipo, "Tipo de Produto", _Reserva, EProvider) Then
			Return False
		End If
		'
		If Not f.VerificaDadosClasse(txtProduto, "Descrição do Produto", _Reserva, EProvider) Then
			Return False
		End If
		'
		If chkProdutoConhecido.Checked = True Then
			If Not f.VerificaDadosClasse(txtRGProduto, "Reg. do Produto", _Reserva, EProvider) Then
				Return False
			End If
		End If
		'
		'Se nenhuma das condições acima forem verdadeira retorna TRUE
		Return True
		'
	End Function
	'
#End Region
	'
#Region "OUTRAS FUNCOES"
	'
	Private Sub AddHandlerControles()
		'
		For Each c As Control In Me.Controls
			'
			If c.HasChildren Then
				For Each cp As Control In c.Controls
					If TypeOf cp Is TextBox Then
						AddHandler cp.GotFocus, AddressOf SelTodoTexto
						AddHandler cp.KeyDown, AddressOf EnterForTab
					ElseIf TypeOf cp Is DateTimePicker Then
						AddHandler cp.KeyDown, AddressOf EnterForTab
					ElseIf TypeOf cp Is CheckBox Then
						AddHandler cp.KeyDown, AddressOf EnterForTab
					End If
				Next
			Else
				If TypeOf c Is TextBox Then
					AddHandler c.GotFocus, AddressOf SelTodoTexto
					AddHandler c.KeyDown, AddressOf EnterForTab
				ElseIf TypeOf c Is MaskedTextBox Then
					AddHandler c.GotFocus, AddressOf SelTodoTexto
					AddHandler c.KeyDown, AddressOf EnterForTab
				End If
			End If
			'
		Next
		'
	End Sub
	'
	' HANDLER SELECIONAR TODO O TEXTO
	Private Sub SelTodoTexto(sender As Object, e As EventArgs)
		'
		If sender.GetType = GetType(TextBox) Then
			DirectCast(sender, TextBox).SelectAll()
		ElseIf sender.GetType = GetType(MaskedTextBox) Then
			DirectCast(sender, MaskedTextBox).SelectAll()
		End If
		'
	End Sub
	'
	' HANDLER SUPRIMIR A TECLA ENTER
	Private Sub EnterForTab(sender As Object, e As KeyEventArgs)
		If e.KeyCode = Keys.Enter Then
			e.SuppressKeyPress = True
			SendKeys.Send("{Tab}")
		End If
	End Sub
	'
	'--- BLOQUEIA PRESS A TECLA (+)
	Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
		'
		If e.KeyChar = "+" Then
			'
			'--- cria uma lista de controles que serao impedidos de receber '+'
			Dim controlesBloqueados As String() = {"txtProdutoTipo", "txtFuncionario",
				"txtFabricante", "txtFornecedor", "txtAutor", "txtProduto", "txtClienteNome"}
			'
			If controlesBloqueados.Contains(ActiveControl.Name) Then
				e.Handled = True
			End If
			'
		End If
		'
	End Sub
	'
	'--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
	'----------------------------------------------------------------------------------
	Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
		Handles txtProdutoTipo.KeyDown,
				txtFuncionario.KeyDown,
				txtAutor.KeyDown,
				txtFabricante.KeyDown,
				txtFornecedor.KeyDown,
				txtProduto.KeyDown,
				txtClienteNome.KeyDown
		'
		Dim ctr As Control = DirectCast(sender, Control)
		'
		If e.KeyCode = Keys.Add Then
			e.Handled = True
			Select Case ctr.Name
				Case "txtClienteNome"
					btnClienteSimples_Click(New Object, New EventArgs)
				Case "txtProdutoTipo"
					btnProcProdutoTipo_Click(New Object, New EventArgs)
				Case "txtFuncionario"
					btnProcFuncionario_Click(New Object, New EventArgs)
				Case "txtAutor"
					btnProcAutores_Click(New Object, New EventArgs)
				Case "txtFabricante"
					btnProcFabricantes_Click(New Object, New EventArgs)
				Case "txtFornecedor"
					btnProcFornecedores_Click(New Object, New EventArgs)
			End Select
		ElseIf e.KeyCode = Keys.Delete Then
			e.Handled = True
			Select Case ctr.Name
				Case "txtProdutoTipo"
					If Not IsNothing(_Reserva.IDProdutoTipo) Then Sit = EnumFlagEstado.Alterado
					txtProdutoTipo.Clear()
					_Reserva.IDProdutoTipo = Nothing
			End Select
		Else
			'--- cria uma lista de controles que serão bloqueados de alteracao
			Dim controlesBloqueados As New List(Of String)
			controlesBloqueados.AddRange({"txtClienteNome", "txtProdutoTipo", "txtFuncionario", "txtFabricante", "txtFornecedor"})
			'
			If chkProdutoConhecido.Checked = True Then '--- se for produto conhecido impede inserir o nome e o autor
				controlesBloqueados.AddRange({"txtProduto", "txtAutor"})
			End If
			'
			If controlesBloqueados.Contains(ctr.Name) Then
				e.Handled = True
				e.SuppressKeyPress = True
			End If
		End If
		'
	End Sub
	'
	'--- AO ALTERAR A SITUACAO DO CHECKED PRODUTO CONHECIDO
	Private Sub chkProdutoConhecido_CheckedChanged(sender As Object, e As EventArgs)
        '
        chkProdutoConhecido.DataBindings.Item("Checked").WriteValue()
        VerificaProdutoConhecido()
        '
    End Sub
    '
    ' CONTROLA SE O PRODUTO É CONHECIDO
    Private Sub VerificaProdutoConhecido()
        '
        'sendo um PRODUTO CONHECIDO bloquear a edicao Do Produto, fabricante, tipo, etc
        If _Reserva.ProdutoConhecido = True Then
            '
            If Sit <> EnumFlagEstado.RegistroSalvo Then
                If _Reserva.IDProduto Is Nothing Then
                    _Reserva.RGProduto = Nothing
                    _Reserva.Produto = String.Empty
                    _Reserva.IDProdutoTipo = Nothing
                    _Reserva.ProdutoTipo = String.Empty
                    _Reserva.IDFabricante = Nothing
                    _Reserva.Fabricante = String.Empty
                    _Reserva.Autor = String.Empty
                End If
            End If
            '
            lblProdConhecido.Text = "Produto CONHECIDO"
            '
            '--- RGProduto
            txtRGProduto.Visible = True
            lblRG.Visible = True
            '
            '--- Fornecedor
            'txtFornecedor.Enabled = True
            'btnProcFornecedores.Enabled = True
            '
            '--- Preco Venda
            txtPVenda.Enabled = True
            '
            '--- btn Tipo, Autor, Fabricante
            btnProcProdutoTipo.Enabled = False
            btnProcAutores.Enabled = False
            btnProcFabricantes.Enabled = False
			'
			'--- btnAdiantamento
			If If(_Reserva.ValorAntecipado, 0) = 0 Then btnAdiantamento.Enabled = True
			'
		Else '--- PRODUTO DESCONHECIDO
            '
            If Sit <> EnumFlagEstado.RegistroSalvo Then
                _Reserva.IDProduto = Nothing
                _Reserva.RGProduto = Nothing
                _Reserva.Produto = Nothing
                _Reserva.IDFornecedor = Nothing
                _Reserva.Fornecedor = String.Empty
                _Reserva.PVenda = Nothing
            End If
            '
            lblProdConhecido.Text = "Produto DESCONHECIDO"
            '--- RGProduto
            txtRGProduto.Visible = False
            lblRG.Visible = False
			'
			'--- Fornecedor
			'txtFornecedor.Enabled = False
			'btnProcFornecedores.Enabled = False
			'
			'--- Preco Venda
			'txtPVenda.Enabled = False
			'
			'--- btn Tipo, Autor, Fabricante
			btnProcProdutoTipo.Enabled = True
            btnProcAutores.Enabled = True
            btnProcFabricantes.Enabled = True
			'
			'--- btnAdiantamento
			btnAdiantamento.Enabled = False
			'
		End If
		'
	End Sub
    '
    ' CONTROLA O KEYPRESS DO RGPRODUTO (PERMITE SOMENTE NUMERO)
    Private Sub txtRGProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGProduto.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        ElseIf e.KeyChar = "+" Then
            e.Handled = True
            '
            '--- abre o form de Procura de Produto
            Dim p As New frmProdutoProcurar(Me, True)
            p.ShowDialog()
            '
            '--- verifica se retornou algum valor
            If p.DialogResult = vbCancel Then Exit Sub
            '
            '--- se retornou entao preenche o RGProduto
            txtRGProduto.Text = p.ProdutoEscolhido.RGProduto
            SendKeys.Send("{TAB}")
            '
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- VALIDA O RGPRODUTO PARA OBTER OS DADOS DO PRODUTO
    Private Sub txtRGProduto_Validating(sender As Object, e As CancelEventArgs) Handles txtRGProduto.Validating
        '
        If String.IsNullOrEmpty(txtRGProduto.Text) OrElse Sit = EnumFlagEstado.RegistroSalvo Then Exit Sub
        '
        If Produto_ObterDados(txtRGProduto.Text) = False Then
            e.Cancel = True
        End If
        '
    End Sub
    '
    '--- FUNCAO PARA OBTER OS DADOS DO PRODUTO INSERIDO PELO RGPRODUTO
    Private Function Produto_ObterDados(myRGProduto As Integer) As Boolean
        '
        Dim pBLL As New ProdutoBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim prod As clProduto = pBLL.GetProduto_PorRG(myRGProduto, _Reserva.IDFilial)
            '
            If IsNothing(prod) Then
                MessageBox.Show("Esse código de Produto não foi encontrado...",
                                "Registro Inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return False
            End If
            '
            '--- Define os itens do produto encontrado
            _Reserva.IDProduto = prod.IDProduto
            _Reserva.Produto = prod.Produto
            _Reserva.IDFabricante = prod.IDFabricante
            _Reserva.Fabricante = prod.Fabricante
            _Reserva.IDProdutoTipo = prod.IDProdutoTipo
            _Reserva.ProdutoTipo = prod.ProdutoTipo
            _Reserva.PVenda = prod.PVenda
            _Reserva.Autor = prod.Autor
            '
            '--- envia uma mensagem ao usuário caso houver ESTOQUE do produto na Filial
            Dim estoque As Integer = prod.Estoque
            '
            If estoque > 0 Then
                Dim msg As String = String.Format("{0} {1} {2} no estoque do produto {3}",
                IIf(estoque = 1, "Existe", "Existem"),
                Format(estoque, "00"),
                IIf(estoque = 1, "unidade", "unidades"),
                vbNewLine & prod.Produto.ToString.ToUpper)
                '
                AbrirDialog(msg, "Estoque", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                '
            End If
            '
            '--- Verify exists FornecedorPadrao
            Dim pfBLL As New ProdutoFornecedorBLL
            '
            Dim pf As clProdutoFornecedor = pfBLL.GetFornecedorPadrao(prod.IDProduto)
            If Not IsNothing(pf) Then
                _Reserva.Fornecedor = pf.Cadastro
                txtFornecedor.Text = pf.Cadastro
                _Reserva.IDFornecedor = pf.IDFornecedor
            End If
            '
            '--- RETORNA
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter os dados do produto informado...",
                            "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
    '--- CONVERT LETTERS TO UPPER CASE FOR NAMES
    '----------------------------------------------------------------------------------
    Private Sub txtClienteNome_Validating(sender As Object, e As CancelEventArgs) Handles txtClienteNome.Validating
        If txtClienteNome.Text.Length > 0 Then
            txtClienteNome.Text = Utilidades.PrimeiraLetraMaiuscula(txtClienteNome.Text)
        End If
    End Sub
	'
#End Region
	'
#Region "VISUAL EFFECTS"
	'
	'--- CREATE ONE BORDER OUT CHKPRODUTOCONHECIDO ON SELECTED
	'----------------------------------------------------------------------------------
	Private Sub chkProdutoConhecido_Enter(sender As Object, e As EventArgs) Handles chkProdutoConhecido.Enter
		Dim ctrl As Control = DirectCast(sender, Control)
		ctrlrect = New Rectangle(ctrl.Location.X - 3, ctrl.Location.Y - 3, ctrl.Width + 6, ctrl.Height + 6)
		Panel4.Refresh()
	End Sub

	Private Sub Panel4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel4.Paint
		If ctrlrect.Width > 0 Then
			Dim transColor As Color = Color.FromArgb(40, 40, 40, 200)
			e.Graphics.FillRectangle(New SolidBrush(transColor), ctrlrect) 'Draw a filled rectangle with transparent red color
			e.Graphics.DrawRectangle(Pens.Gainsboro, ctrlrect) 'Draw a solid red rectangle as a border
		End If
	End Sub

	Private Sub chkProdutoConhecido_Leave(sender As Object, e As EventArgs) Handles chkProdutoConhecido.Leave
		ctrlrect = New Rectangle(0, 0, 0, 0)
		Panel4.Refresh()
	End Sub
	'
#End Region '/ VISUAL EFFECTS
	'
End Class
