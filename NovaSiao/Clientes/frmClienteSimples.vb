Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmClienteSimples
	'
	Private _cliente As clClienteSimples
	Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
	Private _formOrigem As Form = Nothing
	Private BindCliente As New BindingSource
	Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
	Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
	Private _RegistrarEndereco As Boolean = True
	'
#Region "LOAD E PROPERTIES"
	'
	Sub New(ClienteSimples As clClienteSimples, Optional formOrigem As Form = Nothing)
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		_formOrigem = formOrigem
		propCliente = ClienteSimples
		PreencheDataBindings()
		'
		If Not IsNothing(_cliente.IDClienteSimples) Then Sit = EnumFlagEstado.RegistroSalvo
		'
	End Sub
	'
	Private Sub frmClienteSimples_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		AddHandlerControles() ' adiciona o handler para selecionar e usar tab com a tecla enter
	End Sub
	'
	Private Sub frmClienteSimples_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		txtClienteNome.Focus()
	End Sub
	'
	'--- DEFINE SITUACAO PROPERTY
	'----------------------------------------------------------------------------------
	Private Property Sit As EnumFlagEstado
		'
		Get
			Return _Sit
		End Get
		'
		Set(value As EnumFlagEstado)
			_Sit = value
			'
			If _Sit = EnumFlagEstado.RegistroSalvo Then
				btnSalvar.Enabled = False
				btnNovo.Enabled = True
				btnCancelar.Enabled = False
				btnProcurar.Enabled = True
			ElseIf _Sit = EnumFlagEstado.Alterado Then
				btnSalvar.Enabled = True
				btnNovo.Enabled = False
				btnCancelar.Enabled = True
				btnProcurar.Enabled = False
			ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
				txtClienteNome.Select()
				btnSalvar.Enabled = True
				btnNovo.Enabled = False
				btnCancelar.Enabled = True
				btnProcurar.Enabled = False
				lblID.Text = "NOVO"
			End If
			'
			'--- check if FormOrigem is DEFINED
			If Not IsNothing(_formOrigem) Then
				btnProcurar.Enabled = False
				btnNovo.Enabled = False
				btnFechar.Text = "OK"
				btnFechar.Image = My.Resources.accept
			End If
			'
		End Set
		'
	End Property
	'
	'--- DEFINE O CLIENTE PROPERTY
	'----------------------------------------------------------------------------------
	Public Property propCliente() As clClienteSimples
		'
		Get
			Return _cliente
		End Get
		'
		Set(ByVal value As clClienteSimples)
			'
			_cliente = value
			BindCliente.DataSource = _cliente
			AddHandler DirectCast(BindCliente.CurrencyManager.Current, clClienteSimples).AoAlterar, AddressOf HandlerAoAlterar
			'
			If Not IsNothing(_cliente.IDClienteSimples) Then
				Sit = EnumFlagEstado.RegistroSalvo
			Else
				Sit = EnumFlagEstado.NovoRegistro
				_cliente.IDFilial = Obter_FilialPadrao()
			End If
			'
			AtivoButtonImage()
			'
			If Not IsNothing(_cliente.IDClienteSimples) Then
				lblID.Text = Format(_cliente.IDClienteSimples, "0000")
			End If
			'
			PropRegistrarEndereco = _cliente.Endereco IsNot Nothing AndAlso _cliente.Endereco.Length > 0
			chkEndereco.Checked = _cliente.Endereco IsNot Nothing AndAlso _cliente.Endereco.Length > 0
			'
		End Set
		'
	End Property
	'
	'--- PROPERTY REGISTRAR ENDERECO
	'----------------------------------------------------------------------------------
	Private Property PropRegistrarEndereco As Boolean
		'
		Get
			Return _RegistrarEndereco
		End Get
		'
		Set(value As Boolean)
			'
			If value <> _RegistrarEndereco Then
				'
				txtEndereco.Enabled = value
				txtBairro.Enabled = value
				txtCidade.Enabled = value
				txtCEP.Enabled = value
				txtUF.Enabled = value
				'
				lbl1.ForeColor = IIf(value, Color.Black, Color.Gainsboro)
				lbl2.ForeColor = IIf(value, Color.Black, Color.Gainsboro)
				lbl3.ForeColor = IIf(value, Color.Black, Color.Gainsboro)
				lbl4.ForeColor = IIf(value, Color.Black, Color.Gainsboro)
				lbl5.ForeColor = IIf(value, Color.Black, Color.Gainsboro)
				'
			End If
			'
			_RegistrarEndereco = value
			'
		End Set
		'
	End Property
	'
#End Region
	'
#Region "DATABINDINGS"

	Private Sub PreencheDataBindings()
		'
		' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
		lblID.DataBindings.Add("Tag", BindCliente, "IDClienteSimples")
		txtClienteNome.DataBindings.Add("Text", BindCliente, "ClienteNome", True, DataSourceUpdateMode.OnPropertyChanged)
		txtTelefoneA.DataBindings.Add("Text", BindCliente, "TelefoneA", True, DataSourceUpdateMode.OnPropertyChanged)
		txtTelefoneB.DataBindings.Add("Text", BindCliente, "TelefoneB", True, DataSourceUpdateMode.OnPropertyChanged)
		chkTemWhatsapp.DataBindings.Add("Checked", BindCliente, "TemWhatsapp", True, DataSourceUpdateMode.OnPropertyChanged)
		txtClienteEmail.DataBindings.Add("Text", BindCliente, "ClienteEmail", True, DataSourceUpdateMode.OnPropertyChanged, "")
		'
		txtEndereco.DataBindings.Add("Text", BindCliente, "Endereco", True, DataSourceUpdateMode.OnPropertyChanged)
		txtBairro.DataBindings.Add("Text", BindCliente, "Bairro", True, DataSourceUpdateMode.OnPropertyChanged)
		txtCidade.DataBindings.Add("Text", BindCliente, "Cidade", True, DataSourceUpdateMode.OnPropertyChanged)
		txtUF.DataBindings.Add("Text", BindCliente, "UF", True, DataSourceUpdateMode.OnPropertyChanged)
		txtCEP.DataBindings.Add("Text", BindCliente, "CEP", True, DataSourceUpdateMode.OnPropertyChanged)
		'
		' FORMATA OS VALORES DO DATABINDING
		AddHandler lblID.DataBindings("Tag").Format, AddressOf idFormatRG
		AddHandler BindCliente.CurrentChanged, AddressOf handler_CurrentChanged
		'
	End Sub
	'
	Private Sub handler_CurrentChanged()
		'
		'--- Nesse caso é um novo registro
		If IsNothing(DirectCast(BindCliente.Current, clClienteSimples).IDClienteSimples) Then
			Exit Sub
		Else
			' LER O ID
			lblID.DataBindings.Item("Tag").ReadValue()
			' ALTERAR PARA REGISTRO SALVO
			Sit = EnumFlagEstado.RegistroSalvo
		End If
		'
	End Sub
	'
	Private Sub HandlerAoAlterar()
		If BindCliente.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
			Sit = EnumFlagEstado.Alterado
		End If
	End Sub
	'
	' FORMATA OS BINDINGS
	Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
		If IsDBNull(e.Value) Then Exit Sub
		e.Value = Format(e.Value, "0000")
	End Sub
	'
#End Region
	'
#Region "ACAO BOTOES"
	'
	'--- BTN PROCURAR
	Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
		'Close()
		''
		'Dim fProc As New frmClienteSimplesProcurar
		'fProc.Show()
		'
	End Sub
	'
	'--- BTN NOVO
	Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
		'
		Try
			propCliente = New clClienteSimples
			txtClienteNome.Focus()
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao inserir novo registro de Cliente Simples..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		'
	End Sub
	'
	'--- BTN CANCELAR
	Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
		'
		If Sit = EnumFlagEstado.NovoRegistro Then
			'
			If IsNothing(_formOrigem) Then
				btnProcurar_Click(btnCancelar, New EventArgs)
				Exit Sub
			Else
				DialogResult = DialogResult.Cancel
				_formOrigem.Visible = True
				Me.Close()
			End If
			'
		ElseIf Sit = EnumFlagEstado.Alterado Then
			'
			BindCliente.CancelEdit()
			AtivoButtonImage()
			'
		End If
		'
		Sit = EnumFlagEstado.RegistroSalvo
		'
	End Sub
	'
	'--- BTN PROCURAR
	Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
		'
		If Sit = EnumFlagEstado.NovoRegistro Then
			AbrirDialog("Você não pode INATIVAR um Novo Cliente...",
						"Inativar Cliente",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		Dim Cliente As clClienteSimples = BindCliente.Current
		'
		If Cliente.Ativo = True Then ' Cliente Ativo
			'
			If AbrirDialog("Você deseja realmente INATIVAR o Cliente:" & vbNewLine &
							   txtClienteNome.Text.ToUpper,
							   "Inativar Cliente",
							   frmDialog.DialogType.SIM_NAO,
							   frmDialog.DialogIcon.Question,
							   frmDialog.DialogDefaultButton.Second) = DialogResult.Yes Then
				'
				Cliente.BeginEdit()
				Cliente.Ativo = False
				AtivoButtonImage()
				'
			End If
			'
		ElseIf Cliente.Ativo = False Then ' Cliente Inativo
			'
			If AbrirDialog("Você deseja realmente ATIVAR o Cliente:" & vbNewLine &
						   txtClienteNome.Text.ToUpper,
						   "Ativar Cliente",
						   frmDialog.DialogType.SIM_NAO,
						   frmDialog.DialogIcon.Question,
						   frmDialog.DialogDefaultButton.Second) = DialogResult.Yes Then
				'
				Cliente.BeginEdit()
				Cliente.Ativo = True
				AtivoButtonImage()
				'
			End If
			'
		End If
		'
	End Sub
	'
	' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
	Private Sub AtivoButtonImage()
		'
		If _cliente.Ativo = True Then ' Nesse caso é Fornecedor Ativo
			btnAtivo.Image = AtivarImage
			btnAtivo.Text = "Ativo"
		ElseIf _cliente.Ativo = False Then ' Nesse caso é Fornecedor Inativo
			btnAtivo.Image = DesativarImage
			btnAtivo.Text = "Inativo"
		End If
		'
	End Sub
	'
	'--- BTN FECHAR
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
		'
		AutoValidate = AutoValidate.Disable
		'
		If Not IsNothing(_formOrigem) Then
			'
			If Sit = EnumFlagEstado.RegistroSalvo Then
				DialogResult = DialogResult.OK
			Else
				DialogResult = DialogResult.Cancel
			End If
			'
			_formOrigem.Visible = True
		Else
			Me.Close()
			MostraMenuPrincipal()
		End If
		'
	End Sub
	'
#End Region

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
		Dim NewID As Integer
		Dim pBLL As New ClienteSimplesBLL
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Salva mas antes define se é ATUALIZAR OU UM NOVO REGISTRO
			If Sit = EnumFlagEstado.NovoRegistro Then 'Nesse caso é um NOVO REGISTRO
				'
				Dim response = pBLL.ClienteSimples_Inserir(_cliente)
				'
				If TypeOf response Is Integer Then
					NewID = response
				Else
					Throw New Exception(response.ToString)
				End If
				'
			ElseIf Sit = EnumFlagEstado.Alterado Then 'Nesse caso é um REGISTRO EDITADO
				'
				If pBLL.ClienteSimples_Alterar(_cliente) Then
					NewID = _cliente.IDClienteSimples
				End If
				'
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
		If IsNumeric(NewID) AndAlso NewID <> 0 Then
			'
			'--- Retorna o número de Registro do Novo Cliente Cadastrado
			If Sit = EnumFlagEstado.NovoRegistro Then
				_cliente.IDClienteSimples = NewID
				lblID.DataBindings("Tag").ReadValue()
			End If

			'--- Altera a Situação
			Sit = EnumFlagEstado.RegistroSalvo
			BindCliente.EndEdit()
			BindCliente.CurrencyManager.Refresh()
			'
			'--- Mensagem de Sucesso:
			AbrirDialog("Registro Salvo com sucesso!",
						"Registro Salvo",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Information)
			'
			'--- check if exists formOrigem and close
			If Not IsNothing(_formOrigem) Then
				'
				DialogResult = DialogResult.OK
				Close()
				_formOrigem.Visible = True
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
		EProvider.Clear()
		'
		Dim f As New Utilidades
		'
		If Not f.VerificaControlesForm(txtClienteNome, "Nome do Cliente", EProvider) Then Return False
		'
		If txtClienteNome.Text.Length < 5 Then
			AbrirDialog("O Nome do cliente deve ter pelo menos 6 caracteres...",
						"Nome do Cliente", frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			txtClienteNome.Focus()
			Return False
		Else
			_cliente.ChaveExclusiva = f.removeAcentos(txtClienteNome.Text.ToUpper.Replace(" ", ""))
			MsgBox(_cliente.ChaveExclusiva)
		End If
		'
		If chkEndereco.Checked Then
			'
			If Not f.VerificaControlesForm(txtEndereco, "Endereço", EProvider) Then Return False
			'
			If Not f.VerificaControlesForm(txtBairro, "Bairro", EProvider) Then Return False
			'
			If Not f.VerificaControlesForm(txtCidade, "Cidade", EProvider) Then Return False
			'
			If Not f.VerificaControlesForm(txtUF, "UF", EProvider) Then Return False
			'
			If Not f.VerificaControlesForm(txtCEP, "CEP", EProvider) Then Return False
			'
		End If
		'
		'--- Verifica se existe pelo menos um telefone Inserido
		Dim telA As Boolean = IsNothing(_cliente.TelefoneA) OrElse _cliente.TelefoneA.Length = 0
		Dim telB As Boolean = IsNothing(_cliente.TelefoneB) OrElse _cliente.TelefoneB.Length = 0
		'
		If telA And telB Then
			AbrirDialog("Deve haver pelo menos um telefone cadastrado nos dados do Cliente...",
						"Telefone de Contato", frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			txtTelefoneB.Focus()
			Return False
		End If
		'
		'Se nenhuma das condições acima forem verdadeira retorna TRUE
		Return True
		'
	End Function
	'
#End Region
	'
#Region "NAVEGACAO NO FORM"
	'
	Private Sub AddHandlerControles()
		'
		For Each c As Control In Me.Controls
			'
			If c.HasChildren Then
				For Each cp As Control In c.Controls
					If TypeOf cp Is CheckBox Then
						AddHandler cp.KeyDown, AddressOf EnterForTab
					End If
				Next
			End If
			'
			If c.GetType = GetType(TextBox) Then
				AddHandler DirectCast(c, TextBox).GotFocus, AddressOf SelTodoTexto
				AddHandler DirectCast(c, TextBox).KeyDown, AddressOf EnterForTab
			ElseIf c.GetType = GetType(MaskedTextBox) Then
				AddHandler DirectCast(c, MaskedTextBox).GotFocus, AddressOf SelTodoTexto
				AddHandler DirectCast(c, MaskedTextBox).KeyDown, AddressOf EnterForTab
			ElseIf c.GetType = GetType(CheckBox) Then
				AddHandler DirectCast(c, CheckBox).KeyDown, AddressOf EnterForTab
			End If
			'
		Next
		'
	End Sub
	'
	' HANDLER SELECIONAR TODO O TEXTO
	Private Sub SelTodoTexto(sender As Object, e As EventArgs)
		If sender.GetType = GetType(TextBox) Then
			DirectCast(sender, TextBox).SelectAll()
		ElseIf sender.GetType = GetType(MaskedTextBox) Then
			DirectCast(sender, MaskedTextBox).SelectAll()
		End If

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
	'--- QUANDO CHKBOX RECEBE O FOCO REALÇA A COR DA IMAGEM
	Private Sub chkTemWathsapp_ControleFocus(sender As Object, e As EventArgs) Handles chkTemWhatsapp.GotFocus, chkTemWhatsapp.LostFocus
		'
		If chkTemWhatsapp.Focused Then
			pnlChk.BackColor = Color.Gainsboro
		Else
			pnlChk.BackColor = Color.Transparent
		End If
		'
	End Sub
	'
	Private Sub picWathsapp_Click(sender As Object, e As EventArgs) Handles picWathsapp.Click
		chkTemWhatsapp.Focus()
	End Sub

	Private Sub chkEndereco_CheckedChanged(sender As Object, e As EventArgs) Handles chkEndereco.CheckedChanged
		'
		PropRegistrarEndereco = chkEndereco.Checked
		If chkEndereco.Checked Then
			txtEndereco.Focus()
		End If
		'
	End Sub
	'
#End Region
	'


	'
	'--- TRANSFORM 'NOME' IN UPPER CASE
	'----------------------------------------------------------------------------------
	Private Sub txtClienteNome_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtClienteNome.Validating
		'
		If txtClienteNome.Text.Length > 0 Then
			txtClienteNome.Text = Utilidades.PrimeiraLetraMaiuscula(txtClienteNome.Text)
		End If
		'
	End Sub


End Class
