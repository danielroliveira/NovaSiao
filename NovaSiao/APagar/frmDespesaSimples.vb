Imports CamadaDTO
Imports CamadaBLL

Public Class frmDespesaSimples
    '
    Private _clDespesa As clDespesa
    Private _clAPagar As clAPagar
    Private _clMovSaida As clMovimentacao
    Private BindDespesa As New BindingSource
    Private BindAPagar As New BindingSource
    Private BindMovSaida As New BindingSource
    '
    Private _dtInicial As Date?
    Private _dtFinal As Date?
    Private _formOrigem As Form
    '
#Region "LOAD | PROPERTY"
    '
    '--- PROPRIEDADE PUBLICA RETURN
    Public Property propMovSaida() As clMovimentacao
        Get
            Return _clMovSaida
        End Get
        Set(ByVal value As clMovimentacao)
            _clMovSaida = value
            BindMovSaida.DataSource = value
        End Set
    End Property
    '
    Private Property propDespesa As clDespesa
        Get
            Return _clDespesa
        End Get
        Set(value As clDespesa)
            '
            _clDespesa = value
            _clDespesa.ApelidoFilial = ObterDefault("FilialDescricao")
            _clDespesa.IDFilial = Obter_FilialPadrao()
            lblFilial.Text = _clDespesa.ApelidoFilial
            BindDespesa.DataSource = value
            '
            '--- Seleciona o primeiro controle
            txtCredor.Focus()
            '
        End Set
    End Property
    '
    Private Property propAPagar() As clAPagar
        Get
            Return _clAPagar
        End Get
        Set(ByVal value As clAPagar)
            _clAPagar = value
            _clAPagar.Acrescimo = 0
            BindAPagar.DataSource = value
        End Set
    End Property
    '
    Private Property propIDFilial() As Integer?
        '
        Get
            Return _clDespesa.IDFilial
        End Get
        Set(ByVal value As Integer?)
            _clDespesa.IDFilial = value
            _clMovSaida.IDFilial = value
            _clAPagar.IDFilial = value
        End Set
        '
    End Property
    '
    Private Property propApelidoFilial() As String
        '
        Get
            Return _clDespesa.ApelidoFilial
        End Get
        Set(ByVal value As String)
            _clDespesa.ApelidoFilial = value
            _clMovSaida.ApelidoFilial = value
        End Set
        '
    End Property
    '
    Sub New(dtInicial As Date,
            dtFinal As Date,
            IDConta As Int16,
            IDFilial As Integer,
            ApelidoFilial As String,
            IDCaixa As Integer,
            formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        DefineDataBinding()
        PreencheDataBinding()
        '
        '--- Define os valores padrao do caixa
        _dtInicial = dtInicial
        _dtFinal = dtFinal
        _clDespesa.DespesaData = dtFinal
        propIDFilial = IDFilial
        propApelidoFilial = ApelidoFilial
        _clMovSaida.IDConta = IDConta
        _clMovSaida.IDCaixa = IDCaixa
        lblFilial.Text = ApelidoFilial
        _formOrigem = formOrigem
        '
        Handler_MouseDown()
        Handler_MouseUp()
        Handler_MouseMove()
        '
    End Sub
    '
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        DefineDataBinding()
        PreencheDataBinding()
        '
        Handler_MouseDown()
        Handler_MouseUp()
        Handler_MouseMove()
        '
    End Sub
    '
#End Region
    '
#Region "DATABINDING"
    '
    Private Sub DefineDataBinding()
        '
        ' DEFINE AS CLASSES
        '------------------------------------------------------------------------------------
        propDespesa = New clDespesa
        propAPagar = New clAPagar
        propMovSaida = New clMovimentacao(EnumMovimentacaoOrigem.APagar, EnumMovimento.Saida)
        '
        ' DEFINE OS DATABINDINGS
        '------------------------------------------------------------------------------------
        BindDespesa.DataSource = _clDespesa
        BindAPagar.DataSource = _clAPagar
        BindMovSaida.DataSource = _clMovSaida
        '
    End Sub
    '
    Private Sub PreencheDataBinding()
        '
        ' PREENCHE OS DATABINDINGS
        '------------------------------------------------------------------------------------
        '--- BIND DESPESA
        lblID.DataBindings.Add("text", BindDespesa, "IDDespesa", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", BindDespesa, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCredor.DataBindings.Add("Text", BindDespesa, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)
        lblCNP.DataBindings.Add("Text", BindDespesa, "CNP", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaTipo.DataBindings.Add("Text", BindDespesa, "DespesaTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescricao.DataBindings.Add("Text", BindDespesa, "Descricao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaData.DataBindings.Add("Text", BindDespesa, "DespesaData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDespesaValor.DataBindings.Add("Text", BindDespesa, "DespesaValor", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        '--- BIND APAGAR
        txtIdentificador.DataBindings.Add("Text", BindAPagar, "Identificador", True, DataSourceUpdateMode.OnPropertyChanged)
        txtAcrescimo.DataBindings.Add("Text", BindAPagar, "Acrescimo", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        '--- BIND MOVIMENTACAO SAIDAS
        txtObservacao.DataBindings.Add("Text", BindMovSaida, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        lblSaidaValor.DataBindings.Add("Text", BindMovSaida, "MovValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtConta.DataBindings.Add("Text", BindMovSaida, "Conta", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' CARREGA OS COMBOBOX
        '------------------------------------------------------------------------------------
        CarregaCmbCobrancaForma()
        CarregaCmbBancos()
        '
        ' FORMATA OS VALORES DO DATABINDING
        '------------------------------------------------------------------------------------
        '--- DESPESA
        AddHandler lblID.DataBindings("text").Format, AddressOf FormatRG
        AddHandler txtDespesaValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtDespesaData.DataBindings("text").Format, AddressOf FormatDT
        AddHandler lblCNP.DataBindings("text").Format, AddressOf FormatCNPNull
        AddHandler txtAcrescimo.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler lblSaidaValor.DataBindings("text").Format, AddressOf FormatCUR
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _clDespesa.AoAlterar, AddressOf HandlerAoAlterar
        AddHandler _clAPagar.AoAlterar, AddressOf HandlerAoAlterar
        AddHandler _clMovSaida.AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        eProvider.Clear()
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub FormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        If IsNothing(e.Value) Then
            e.Value = "Nova"
        Else
            e.Value = Format(e.Value, "0000")
        End If
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    Private Sub FormatDT(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "dd/MM/yyyy")
    End Sub
    '
    Private Sub FormatCNPNull(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        If IsNothing(e.Value) Then
            e.Value = "CNPJ/CPF Indefinido"
        End If
    End Sub
    '
#End Region
    '
#Region "COMBOS CARREGAR | CONTROLAR"
    '-------------------------------------------------------------------------------------------------
    ' PREENCHE COMBOS
    '-------------------------------------------------------------------------------------------------
    Private Sub CarregaCmbCobrancaForma()
        Dim pg As New APagarBLL
        '
        Try
            Dim dtForma As DataTable = pg.CobrancaFormas_APagar_GET
            '
            With cmbCobrancaForma
                .DataSource = dtForma
                .ValueMember = "IDCobrancaForma"
                .DisplayMember = "CobrancaForma"
                .DataBindings.Add("SelectedValue", BindAPagar, "IDCobrancaForma", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao obter a lista de Formas Pagamento:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub CarregaCmbBancos()
        Dim db As New BancosBLL
        '
        Try
            Dim dt As DataTable = db.GetBancosDt(True)
            '
            With cmbIDBanco
                .DataSource = dt
                .ValueMember = "RGBanco"
                .DisplayMember = "BancoNome"
                .DataBindings.Add("SelectedValue", BindAPagar, "RGBanco", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu obter lista de Bancos" & vbNewLine &
            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS"
    '
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    '-----------------------------------------------------------------------------------------------------
    Private Sub Control_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles txtDescricao.KeyDown,
        txtDespesaValor.KeyDown, txtIdentificador.KeyDown, txtAcrescimo.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub frmDespesaSimples_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "+" Then
            e.Handled = True
        End If
    End Sub
    '
    '--- VERIFICA A VALIDADE DA DATA
    Private Sub txtDespesaData_Validated(sender As Object, e As EventArgs) Handles txtDespesaData.Validated
        VerificaDataValida()
    End Sub
    '
    Private Function VerificaDataValida() As Boolean
        '
        If IsDate(txtDespesaData.Text) Then
            If Not IsNothing(_dtInicial) Then
                If CDate(txtDespesaData.Text) > _dtFinal OrElse CDate(txtDespesaData.Text) < _dtInicial Then
                    '
                    MessageBox.Show("A Data da Despesa precisa estar entre:" & vbNewLine &
                                    "Data Inicial: " & _dtInicial & vbNewLine &
                                    "Data Final: " & _dtFinal & vbNewLine &
                                    "Insira uma data válida no campo Data da Despesa", "Data da Despesa",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '
                    If _dtInicial = _dtFinal Then
                        txtDespesaData.Text = _dtFinal
                        _clDespesa.DespesaData = _dtFinal
                    Else
                        txtDespesaData.Focus()
                    End If
                    '
                    Return False
                    '
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Else
            MessageBox.Show("Insira uma data válida no campo Data da Despesa", "Data da Despesa",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        '
    End Function
    '
    Private Sub txtValor_Validated(sender As Object, e As EventArgs) Handles txtDespesaValor.Validated, txtAcrescimo.Validated
        '
        Dim v As Decimal = CDec(IIf(txtDespesaValor.Text.Trim.Length = 0, 0, txtDespesaValor.Text))
        Dim a As Decimal = CDec(IIf(txtAcrescimo.Text.Trim.Length = 0, 0, txtAcrescimo.Text))
        '
        lblSaidaValor.Text = Format(v + a, "C")
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS"
    '
    ' ESCOLHER CONTA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, propIDFilial, propMovSaida.IDConta)
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.Cancel Then
            _clMovSaida.IDConta = Nothing
            txtConta.Clear()
        Else
            '
            txtConta.Text = frmConta.propConta_Escolha.Conta
            _clMovSaida.IDConta = frmConta.propConta_Escolha.IDConta
            '
        End If
    End Sub
    '
    ' PROCURA DESPESA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        Close()
        '
        Dim frmP As New frmDespesaProcurar
        frmP.Show()
        '
    End Sub
    '
    ' CRIA UMA NOVA DESPESA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
        '
        propDespesa = New clDespesa
        propAPagar = New clAPagar
        propMovSaida = New clMovimentacao(EnumMovimentacaoOrigem.APagar, EnumMovimento.Saida)
        '
        txtCredor.Focus()
        '
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        If IsNothing(_formOrigem) Then
            Close()
            MostraMenuPrincipal()
        Else
            DialogResult = DialogResult.Cancel
            Close()
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles _
        txtCredor.KeyDown, txtDespesaTipo.KeyDown, txtConta.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtCredor"
                    btnCredor_Click(sender, e)
                Case "txtDespesaTipo"
                    btnTipo_Click(sender, e)
                Case "txtConta"
                    btnContaEscolher_Click(sender, e)
            End Select
        ElseIf e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            'e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    Private Sub btnCredor_Click(sender As Object, e As EventArgs) Handles btnCredor.Click
        Dim frmC As New frmCredorProcurar(True, Me)
        '
        frmC.ShowDialog()
        If frmC.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Dim Cred As clCredor = frmC.propCredorEscolhido
        '
        txtCredor.Text = Cred.Cadastro
        _clDespesa.CNP = Cred.CNP
        lblCNP.DataBindings.Item("text").ReadValue()
        _clDespesa.IDCredor = Cred.IDPessoa
        '
        If Cred.CredorTipo = 1 Then
            lblCNPTexto.Text = "CPF"
        ElseIf Cred.CredorTipo = 2 Then
            lblCNPTexto.Text = "CNPJ"
        Else Cred.CredorTipo = 0 OrElse Cred.CredorTipo = 3
            lblCNPTexto.Text = "CNPJ"
        End If
        '
    End Sub
    '
    Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        Dim frmT As New frmDespesaTipoProcurar(True, Me)
        '
        frmT.ShowDialog()
        If frmT.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        Dim T As clDespesaTipo = frmT.propDespesaEscolhida
        '
        txtDespesaTipo.Text = T.DespesaTipo
        _clDespesa.IDDespesaTipo = T.IDDespesaTipo
        _clDespesa.DespesaTipo = T.DespesaTipo
        '
    End Sub
    '
#End Region
    '
#Region "SALVAR REGISTRO"
    '
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- Verifica os Controles
        '----------------------------------------------------------------------
        If Not VerificaControles() Then Exit Sub
        '
        '--- Salva a Despesa
        '----------------------------------------------------------------------
        Dim dBLL As New DespesaBLL
        '
        Try
            propMovSaida = dBLL.DespesaSimples_InserirQuitar(_clDespesa, _clAPagar, _clMovSaida)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao inserir nova despesa:" & vbNewLine &
                            ex.Message & vbNewLine & "O registro não pode ser salvo...",
                            "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        '
        '--- Finaliza
        '----------------------------------------------------------------------
        If IsNothing(_clMovSaida.IDCaixa) Then
            '
            If MessageBox.Show("Registro de Despesa Simples Salvo com sucesso!" & vbNewLine & vbNewLine &
                               "Deseja inserir outra Despesa Simples?",
                               "Inserir Nova Despesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                '
                btnNova_Click(New Object, New EventArgs)
                txtCredor.Focus()
                '
            Else
                '
                Close()
                MostraMenuPrincipal()
                '
            End If
            '
        Else
            '
            MessageBox.Show("Registro de Despesa Simples Salvo com sucesso!" & vbNewLine & vbNewLine &
                            "Despesa será incluída no Caixa Atual...",
                            "Nova Despesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            DialogResult = DialogResult.OK
            Close()
            '
        End If
        '
    End Sub
    '
    Private Function VerificaControles() As Boolean
        Dim f As New Utilidades
        '
        '--- Verifica o campo CREDOR
        If f.VerificaDadosClasse(txtCredor, "Credor", _clDespesa, eProvider) = False Then
            Return False
        End If
        '
        '--- Verifica o campo TIPO DA DESPESA
        If f.VerificaDadosClasse(txtDespesaTipo, "Tipo da Despesa", _clDespesa, eProvider) = False Then
            Return False
        End If
        '
        '--- Verifica o campo DESCRICAO
        If f.VerificaDadosClasse(txtDescricao, "Credor", _clDespesa, eProvider) = False Then
            Return False
        End If
        '
        '--- Verifica o campo FORMA DE COBRANCA
        If f.VerificaDadosClasse(cmbCobrancaForma, "Forma de Cobrança", _clAPagar, eProvider) = False Then
            Return False
        End If
        '
        '--- Verifica o campo IDENTIFICADOR
        If f.VerificaDadosClasse(txtIdentificador, "Identificador", _clAPagar, eProvider) = False Then
            Return False
        End If
        '
        '--- Verifica o campo DATA DA DESPESA / VENCIMENTO
        If f.VerificaDadosClasse(txtDespesaData, "Data da Despesa / Vencimento", _clDespesa, eProvider) = False Then
            Return False
        End If
        '
        If VerificaDataValida() = False Then Return False
        '
        '--- Verifica o campo CONTA DA SAÍDA
        If f.VerificaDadosClasse(txtConta, "Conta do Débito/Saída", _clMovSaida, eProvider) = False Then
            Return False
        End If
        '
        '--- Verifica o campo VALOR DA DESPESA
        If f.VerificaDadosClasse(txtDespesaValor, "Valor da Despesa", _clDespesa, eProvider) = False Then
            Return False
        End If
        '
        '--- Verifica o campo ACRESCIMO
        If f.VerificaDadosClasse(txtAcrescimo, "Acrescimo", _clAPagar, eProvider) = False Then
            Return False
        End If
        '
        Return True
        '
    End Function
    '
#End Region
    '
#Region "EFEITOS SUB-FORMULARIO PADRAO"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
        '
    End Sub
    '
    Private Sub frmDespesaTipo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        '
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
        '
    End Sub
    '
#End Region
    '
End Class