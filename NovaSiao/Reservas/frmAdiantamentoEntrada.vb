Imports CamadaBLL
Imports CamadaDTO

Public Class frmAdiantamentoEntrada
    '
    Private _formOrigem As Form
	Private dtTipo As DataTable
	'
	Private bindEntrada As New BindingSource
    Private _vlMax As Decimal = 0
    Private _VerAlteracao As Boolean = False
    '
    Property propMovEntrada As clMovimentacao
    Property prop_vlPagoDoValor As Double '--- retorna o valor pago sem o acrescimo
    Property prop_vlPagoJuros As Double '--- retorna o valor pago do Acrescimo / Juros
	'
#Region "SUB NEW | GET DADOS"
	'
	Public Sub New(formOrigem As Form,
				   vlMax As Decimal,
				   IDReserva As Integer)
		'
		' This call is required by the designer.
		InitializeComponent()
		'
		' Add any initialization after the InitializeComponent() call.
		_formOrigem = formOrigem
		_vlMax = vlMax
		'
		'--- cria uma nova movimentacao
		propMovEntrada = New clMovimentacao(EnumMovimentacaoOrigem.AReceberParcela, EnumMovimento.Entrada)
		'
		'--- define os valores da movimentacao
		propMovEntrada.MovData = Obter_DataPadrao()
		propMovEntrada.IDConta = Obter_ContaPadrao()
		propMovEntrada.IDFilial = Obter_FilialPadrao()
		propMovEntrada.Origem = 3 '--- ORIGEM CREDITO
		propMovEntrada.IDOrigem = IDReserva
		propMovEntrada.Creditar = False
		propMovEntrada.Movimento = 1 '--- ORIGEM ENTRADA
		propMovEntrada.Conta = ObterDefault("ContaDescricao")
		'
		'--- preenche o databind
		bindEntrada.DataSource = propMovEntrada
		PreencheDataBinding()
		CarregaDtTipo()
		'
		If dtTipo.Rows.Count > 0 Then
			txtTipo.Text = dtTipo.Rows(0)("MovTipo")
			propMovEntrada.IDMovTipo = dtTipo.Rows(0)("IDMovTipo")
			propMovEntrada.IDMeio = dtTipo.Rows(0)("IDMeio")
		End If
		'
		txtDoValor.Text = FormatCurrency(vlMax, 2)
		txtAcrescimo.Text = FormatCurrency(Acrescimo, 2)
		CalculaValorPago()
		'
		'--- se a origem for tblVendaPrazo entao...
		If formOrigem.Name = "frmVendaPrazo" Then
			txtAcrescimo.Text = FormatCurrency(0, 2)
			txtAcrescimo.Enabled = False
			lblTitulo.Text = "A Receber Entrada"
		End If
		'
		'--- libera alteraçoes
		_VerAlteracao = True
		'
	End Sub
	'
	Private Sub frmAdiantamentoEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtConta.Focus()
    End Sub
    '
    Private Sub CarregaDtTipo()
        '
        Dim TipoBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            dtTipo = TipoBLL.MovTipo_GET_Dt
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter os Tipo de Pagamento..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '/ SUB NEW | PROPERTIES
    '
#Region "DATA BINDINGS"
    '------------------------------------------------------------------------------------------
    ' PREENCHE O DATABINDING
    '------------------------------------------------------------------------------------------
    Private Sub PreencheDataBinding()
        '
        lblEntradaValor.DataBindings.Add("Text", bindEntrada, "MovValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEntradaData.DataBindings.Add("Text", bindEntrada, "MovData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindEntrada, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTipo.DataBindings.Add("Text", bindEntrada, "MovTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtConta.DataBindings.Add("Text", bindEntrada, "Conta", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' CARREGA OS COMBOBOX
        CarregaCmbForma()
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblEntradaValor.DataBindings("Text").Format, AddressOf FormatCUR
        '
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
#End Region
    '
#Region "PREENCHE COMBOS"
    '
    '------------------------------------------------------------------------------------------
    ' CARREGAR OS COMBOBOX
    '------------------------------------------------------------------------------------------
    Private Sub CarregaCmbForma()
        '
        Dim TipoBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim dtForma As DataTable = TipoBLL.MovForma_GET_DT(propMovEntrada.IDFilial)
            '
            With cmbIDMovForma
                .DataSource = dtForma
                .DisplayMember = "MovForma"
                .ValueMember = "IDMovForma"
                .DataBindings.Add("SelectedValue", bindEntrada, "IDMovForma", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter lista de Tipos de Movimentacao..." & vbNewLine &
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
#Region "BUTONS FUNCTION"
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        '
        '--- Verifica se os Valores estão preenchidos e corretos
        If VerificarValores() = False Then
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Verifica se a DATA DA ENTRADA é permitida pelo sistema
            If DataBloqueada(propMovEntrada.MovData, propMovEntrada.IDConta) Then
                Return
            End If
            '
            '--- Insere a Entrada
            Dim eBLL As New MovimentacaoBLL
            '
            propMovEntrada = eBLL.Movimentacao_Inserir(propMovEntrada, _dbTran)
            '
            '--- retorna valores salvos
            prop_vlPagoDoValor = CDbl(txtDoValor.Text)
            prop_vlPagoJuros = CDbl(txtAcrescimo.Text)
            '
            DialogResult = DialogResult.OK
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao inserir Nova Entrada..." & vbNewLine &
                            "Comunique ao administrador do sistema." & vbNewLine &
                            ex.Message, "Exceção Inesperada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' VERIFICACAO DOS CAMPOS NECESSARIOS
    '------------------------------------------------------------------------------------------
    Private Function VerificarValores() As Boolean
        Dim f As New Utilidades
        '
        '--- Campo Conta de Entrada
        If f.VerificaControlesForm(txtConta, "Conta da Entrada") = False Then
            Return False
        End If
        '
        '--- Campo Data da Entrada
        If f.VerificaControlesForm(txtEntradaData, "Data da Entrada") = False Then
            Return False
        End If
        '
        '--- Campo DoValor
        If f.VerificaControlesForm(txtDoValor, "Valor da Entrada") = False Then
            Return False
        End If
        '
        If IsNumeric(txtDoValor.Text) AndAlso CDec(txtDoValor.Text) = 0 Then
            MessageBox.Show("O Valor da Entrada não pode ser igual a ZERO", "Valor Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDoValor.Focus()
            Return False
        End If
        '
        '--- Campo Tipo de Entrada
        If f.VerificaControlesForm(txtTipo, "Tipo de Pagamento da Entrada") = False Then
            Return False
        End If
        '
        '--- Campo Forma da Entrada
        If f.VerificaControlesForm(cmbIDMovForma, "Forma de Pagamento da Entrada") = False Then
            Return False
        End If
        '
        '--- Campo Observacao
        If txtObservacao.Text.Trim.Length = 0 Then
            txtObservacao.Text = ""
        Else
            txtObservacao.Text = txtObservacao.Text.Trim
        End If
        '
        '--- RETORNA TRUE
        Return True
        '
    End Function
    '
    '===================================================================================
    ' ABRE FORM PARA ESCOLHER CONTA
    '===================================================================================
    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        '--- Abre o frmContas
        '---------------------------------------------------------------------------------------
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        Dim frmConta As New frmContaProcurar(Me, propMovEntrada.IDFilial, propMovEntrada.IDConta, True)
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.OK Then
            '
            txtConta.Text = frmConta.propConta_Escolha.Conta
            propMovEntrada.IDConta = frmConta.propConta_Escolha.IDConta
            '
        End If
        '
    End Sub
    '
    '===================================================================================
    ' ABRE FORM PARA ESCOLHER MOVTIPO
    '===================================================================================
    Private Sub btnTipoEscolher_Click(sender As Object, e As EventArgs) Handles btnTipoEscolher.Click
        '
        '--- Abre o frmMovTipoProcurar
        '---------------------------------------------------------------------------------------
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        Dim frmTipo As New frmMovTipoProcurar(Me, propMovEntrada.IDMovTipo)
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        frmTipo.ShowDialog()
        '
        If frmTipo.DialogResult = DialogResult.OK Then
            '
            If propMovEntrada.IDMovTipo <> frmTipo.propIdMovTipo_Escolha Then
                propMovEntrada.IDMovForma = Nothing
                cmbIDMovForma.DataBindings.Item("SelectedValue").ReadValue()
            End If
            '
            txtTipo.Text = frmTipo.propMovTipo_Escolha
            propMovEntrada.IDMovTipo = frmTipo.propIdMovTipo_Escolha
            propMovEntrada.IDMeio = frmTipo.propMeio_Escolha
            IDMovTipo_Alterado()
            '
        End If
        '
    End Sub
    '
    '===================================================================================
    ' ALTERA A FORMA DE PAGAMENTO PELA ALTERACAO DO TIPO DE PAGAMENTO
    '===================================================================================
    Private Sub IDMovTipo_Alterado()
        '
        If _VerAlteracao = False Then Exit Sub
        If IsNothing(propMovEntrada.IDMovTipo) Then Exit Sub
        '
        Dim dtForma As DataTable = cmbIDMovForma.DataSource
        dtForma.DefaultView.RowFilter = "IDMovTipo = " & propMovEntrada.IDMovTipo
        '
        _VerAlteracao = False
        '
        If cmbIDMovForma.Items.Count = 1 Then
            cmbIDMovForma.SelectedIndex = 0
            propMovEntrada.IDMovForma = dtForma.Rows(0).Item("IDMovForma")
        Else
            cmbIDMovForma.SelectedIndex = -1
        End If
        '
        _VerAlteracao = True
        '
    End Sub
    '
#End Region
    '
#Region "ATALHOS - NAVEGAÇÃO"
    '
    '---------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
            "txtConta",
            "txtTipo"
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
    '---------------------------------------------------------------------------------------
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    '---------------------------------------------------------------------------------------
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles txtConta.KeyDown,
            txtTipo.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            Select Case ctr.Name
                Case "txtConta"
                    btnContaEscolher_Click(New Object, New EventArgs)
                Case "txtTipo"
                    btnTipoEscolher_Click(New Object, New EventArgs)
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtConta"
                    txtConta.Clear()
                    propMovEntrada.IDConta = Nothing
                Case "txtTipo"
                    txtTipo.Clear()
                    propMovEntrada.IDMovTipo = Nothing
                    propMovEntrada.IDMovForma = Nothing
                    cmbIDMovForma.DataBindings.Item("SelectedValue").ReadValue()
            End Select
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({"txtConta"})
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
            '
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' CRIA UM ATALHO PARA OS COMBO BOX
    '------------------------------------------------------------------------------------------
    Private Sub txtTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTipo.KeyPress
        '
        e.Handled = True
        '
        If Char.IsNumber(e.KeyChar) Then
            '
            Dim rCount As Integer = dtTipo.Rows.Count
            Dim item As Integer = e.KeyChar.ToString
            '
            If item <= rCount And item > 0 Then
                '
                propMovEntrada.IDMovTipo = dtTipo.Rows(e.KeyChar.ToString - 1)("IDMovTipo")
                txtTipo.Text = dtTipo.Rows(e.KeyChar.ToString - 1)("MovTipo")
                IDMovTipo_Alterado()
                '
            End If
            '
        End If
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' SELECIONA A FORMA DE PAGAMENTO CRIANDO ATALHO NUMERICO
    '-------------------------------------------------------------------------------------------------
    Private Sub cmbForma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbIDMovForma.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
            '
            Dim num As Integer = e.KeyChar.ToString
            Dim dtF As DataTable = cmbIDMovForma.DataSource
            Dim i As Integer = 1
            '
            For Each r As DataRow In dtF.Rows
                '
                If r("IDMovTipo") = propMovEntrada.IDMovTipo Then
                    '
                    If num = i Then
                        propMovEntrada.IDMovForma = r("IDMovForma")
                        cmbIDMovForma.DataBindings("SelectedValue").ReadValue()
                        Exit For
                    Else
                        i += 1
                    End If
                    '
                End If
                '
            Next
            '
        End If
        '
    End Sub
	'
	'------------------------------------------------------------------------------------------
	' USAR TAB AO KEYPRESS ENTER
	'------------------------------------------------------------------------------------------
	Private Sub txtValor_KeyDown(sender As Object, e As KeyEventArgs) Handles _
		txtConta.KeyDown,
		txtDoValor.KeyDown,
		txtTipo.KeyDown
		'
		If e.KeyCode = Keys.Enter Then
			e.SuppressKeyPress = True
			SendKeys.Send("{Tab}")
		End If
		'
	End Sub
	'
	'------------------------------------------------------------------------------------------
	'-- CONVERTE A TECLA ESC EM CANCELAR
	'------------------------------------------------------------------------------------------
	Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyCode = Keys.Escape Then
			e.Handled = True
			'
			btnCancelar_Click(New Object, New EventArgs)
		End If
	End Sub
	'
#End Region
	'
#Region "FUNCOES NECESSARIAS - CALCULOS"
	'
	'------------------------------------------------------------------------------------------
	' CALCULA O VALOR DO CAMPO VALORPAGO = DOVALOR + ACRESCIMO
	'------------------------------------------------------------------------------------------
	Private Sub CalculaValorPago()
		Dim DoValor As Decimal = 0
		Dim Acresc As Decimal = 0
		'
		If IsNumeric(txtDoValor.Text) Then
			DoValor = CDec(txtDoValor.Text)
			'
			If DoValor > _vlMax Then
				'
				If txtAcrescimo.Enabled Then '--- se o acrescimo nao esta bloqueado
					'
					If MessageBox.Show("O valor da Entrada não pode ser maior que R$ " &
									   Format(_vlMax, "#,##0.00") & vbNewLine & vbNewLine &
									   "Deseja inserir a diferença no valor do ACRÉSCIMO?",
									   "Inserir Acréscimo", MessageBoxButtons.YesNo,
										MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
						txtAcrescimo.Text = Format(DoValor - _vlMax, "C")
					Else
						txtDoValor.Focus()
					End If
					'
					DoValor = _vlMax
					txtDoValor.Text = FormatCurrency(_vlMax, 2)
					'
				Else '--- nesse caso acrescimo esta bloqueado (no caso de entrada de parcelamento)
					MessageBox.Show("O valor da Entrada não pode ser maior que R$ " &
									Format(_vlMax, "#,##0.00"),
									"Valor do Pagamento", MessageBoxButtons.OK,
									MessageBoxIcon.Information)
					DoValor = _vlMax
					txtDoValor.Text = FormatCurrency(_vlMax, 2)
				End If
				'
			End If
			'
		End If
		'
		If IsNumeric(txtAcrescimo.Text) Then
			Acresc = CDec(txtAcrescimo.Text)
		End If
		'
		propMovEntrada.MovValor = DoValor + Acresc
		lblEntradaValor.DataBindings("text").ReadValue()
		'
	End Sub
	'
	'------------------------------------------------------------------------------------------
	' RECALCULA O VALOR PAGO QUANDO ALTERA TXTDOVALOR OU TXTACRESCIMO
	'------------------------------------------------------------------------------------------
	Private Sub txtValor_Validated(sender As Object, e As EventArgs) Handles txtDoValor.Validated
		CalculaValorPago()
	End Sub
	'
#End Region
	'
#Region "EFEITOS SUB-FORMULARIO PADRAO"
	'
	'-------------------------------------------------------------------------------------------------
	' CONSTRUIR UMA BORDA NO FORMULÁRIO
	'-------------------------------------------------------------------------------------------------
	Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.DarkSlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
        '
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = False
        End If
        '
    End Sub
    '
    Private Sub frmAPagarItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Closed
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
        '
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = True
        End If
        '
    End Sub
    '
#End Region
    '
End Class
