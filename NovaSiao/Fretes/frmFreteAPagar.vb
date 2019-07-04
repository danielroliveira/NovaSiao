Imports CamadaDTO
Imports CamadaBLL

Public Class frmFreteAPagar
    Private _clAPag As clAPagar
    Private _acao As EnumFlagAcao
    Private _dtMinima As Date
    Private _formOrigem As Form
    Private _vlMaximo As Double
    Private BindPag As New BindingSource
    '
#Region "NEW LOAD"
    '-------------------------------------------------------------------------------------------------
    ' SUB NEW
    '-------------------------------------------------------------------------------------------------
    '
    Sub New(fOrigem As Form, VlMax As Double, dataMinima As Date,
            APagar As clAPagar, Acao As EnumFlagAcao,
            Optional Posicao As Point = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        ' 
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = fOrigem '--- DEFINE O FORMULARIO DE ORIGEM PARA RETORNAR
        _vlMaximo = VlMax
        _dtMinima = dataMinima
        dtpVencimento.MinDate = dataMinima
        propAPagar = APagar '--- DEFINE E PREECHE A CLASSE
        propAcao = Acao
        '
        txAPagarValor.ReadOnly = True
        '
        If Not Posicao.X = 0 Then
            StartPosition = FormStartPosition.Manual
            Location = New Point(Posicao.X - Me.Width, Posicao.Y)
        Else
            StartPosition = FormStartPosition.CenterScreen
        End If
        '
    End Sub
    '
    '--- Propriedade propAcao
    Public Property propAcao() As EnumFlagAcao
        Get
            Return _acao
        End Get
        Set(ByVal value As EnumFlagAcao)
            _acao = value
            '
            If _acao = EnumFlagAcao.INSERIR Then
                btnOK.Text = "&Inserir"
                lblToolStripInfo.Text = "Inserindo Nova Parcela"
                lblTitulo.Text = "Inserir Cobrança"
            ElseIf _acao = EnumFlagAcao.EDITAR Then
                btnOK.Text = "&Alterar"
                lblToolStripInfo.Text = "Editando Parcela"
                lblTitulo.Text = "Editar Cobrança"
            End If
            '
        End Set
    End Property
    '
    '--- Propriedade propItem
    Public Property propAPagar() As clAPagar
        Get
            Return _clAPag
        End Get
        Set(ByVal value As clAPagar)
            _clAPag = value
            '
            If IsNothing(BindPag.DataSource) Then
                BindPag.DataSource = _clAPag
                PreencheDataBindings()
            Else
                BindPag.Clear()
                BindPag.DataSource = _clAPag
                BindPag.ResetBindings(True)
            End If
        End Set
    End Property
    '
#End Region
    '
#Region "BINDING"
    '-------------------------------------------------------------------------------------------------
    ' BINDINGS DOS CAMPOS
    '-------------------------------------------------------------------------------------------------
    Private Sub PreencheDataBindings()
        '
        '--- PREENCHE OS DATABINDGS DOS CONTROLES
        '
        dtpVencimento.DataBindings.Add("value", BindPag, "Vencimento", True, DataSourceUpdateMode.OnPropertyChanged)
        txAPagarValor.DataBindings.Add("Text", BindPag, "APagarValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtIdentificador.DataBindings.Add("Text", BindPag, "Identificador", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txAPagarValor.DataBindings("text").Format, AddressOf FormatCUR
        '
        ' CARREGA OS COMBOS
        CarregaCmbCobrancaForma()
        CarregaCmbBancos()
        '
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
#End Region
    '
#Region "PREENCHE COMBOS"
    '-------------------------------------------------------------------------------------------------
    ' PREENCHE COMBOS
    '-------------------------------------------------------------------------------------------------
    Private Sub CarregaCmbCobrancaForma()
        Dim pg As New APagarBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim dtForma As DataTable = pg.CobrancaFormas_APagar_GET
            '
            With cmbCobrancaForma
                .DataSource = dtForma
                .ValueMember = "IDCobrancaForma"
                .DisplayMember = "CobrancaForma"
                .DataBindings.Add("SelectedValue", BindPag, "IDCobrancaForma", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao obter a lista de Formas Pagamento:" & vbNewLine &
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
    Private Sub CarregaCmbBancos()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim db As New BancosBLL
            '
            Dim dt As DataTable = db.GetBancosDt(True)
            '
            With cmbIDBanco
                .DataSource = dt
                .ValueMember = "RGBanco"
                .DisplayMember = "BancoNome"
                .DataBindings.Add("SelectedValue", BindPag, "RGBanco", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu obter lista de Bancos" & vbNewLine &
            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
#Region "BUTTONS"

    '-------------------------------------------------------------------------------------------------
    ' BTN INSERIR / FECHAR
    '-------------------------------------------------------------------------------------------------
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '-------------------------------------------------------------------
        ' VERIFICACOES
        '-------------------------------------------------------------------
        '--- Verifica VENCIMENTO é futuro ou atual da trasancao
        If IsNothing(_clAPag.Vencimento) OrElse _clAPag.Vencimento < _dtMinima Then
            MessageBox.Show("A data do VENCIMENTO não pode ser anterior à: " & vbNewLine &
                            _dtMinima.ToShortDateString, "Vencimento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpVencimento.Focus()
            Exit Sub
        End If
        '
        '--- Verifica VALOR
        If IsNothing(_clAPag.APagarValor) OrElse _clAPag.APagarValor <= 0 Then
            MessageBox.Show("O Valor da Cobrança não pode ser menor ou igual a Zero...",
                "Valor da Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txAPagarValor.Focus()
            txAPagarValor.SelectAll()
        End If
        '
        '--- Verifica VALOR nao é maior que o vlmaximo
        If _clAPag.APagarValor > _vlMaximo Then
            MessageBox.Show("O Valor da Cobrança não pode ser maior que R$ " & Format(_vlMaximo, "#,##0.00"),
                            "Valor da Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txAPagarValor.Focus()
            txAPagarValor.SelectAll()
            Exit Sub
        End If
        '
        '--- verifica se a FORMA esta vazio
        If IsNothing(_clAPag.IDCobrancaForma) OrElse cmbCobrancaForma.Text.Length = 0 Then
            MessageBox.Show("O Campo Forma de Cobrança não pode ficar vazio...",
                "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbCobrancaForma.Focus()
            cmbCobrancaForma.SelectAll()
            Exit Sub
        Else
            _clAPag.CobrancaForma = cmbCobrancaForma.Text
        End If
        '
        '--- verifica se o IDENTIFICADOR esta vazio
        If IsNothing(_clAPag.Identificador) Then
            MessageBox.Show("O Campo IDENTIFICADOR não pode ficar vazio...",
                "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtIdentificador.Focus()
            txtIdentificador.SelectAll()
            Exit Sub
        End If
        '
        '-------------------------------------------------------------------
        ' EXECUCAO ENVIO RETORNO
        '-------------------------------------------------------------------
        _clAPag.EndEdit()
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        BindPag.CancelEdit()
        DialogResult = DialogResult.Cancel
    End Sub
    '
#End Region
    '
#Region "FUNCOES CONTROLES"
    '-------------------------------------------------------------------------------------------------
    ' NAVEGACAO E CONTROLE DOS CAMPOS
    '-------------------------------------------------------------------------------------------------
    '
    '-- EVITA DIGITACAO DE TEXTO
    Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdentificador.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = ","c Then
            e.Handled = False
        ElseIf e.KeyChar = "."c Then
            DirectCast(sender, TextBox).SelectedText = ","
            e.Handled = True
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        ElseIf Char.IsLower(e.KeyChar) Then
            DirectCast(sender, TextBox).SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
        '
    End Sub
    '
    '-- SELECIONA TODO O TEXTO DO CAMPO AO RECEBER O FOCO
    Private Sub Text_GotFocus(sender As Object, e As EventArgs) Handles txAPagarValor.GotFocus, txtIdentificador.GotFocus
        If CType(sender, TextBox).Text.Length > 0 Then sender.SelectAll()
    End Sub
    '
    '-- CONVERTE TECLA ENTER EM TAB
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txAPagarValor.KeyDown,
        txtIdentificador.KeyDown, dtpVencimento.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '-- CONVERTE A TECLA ESC EM CANCELAR
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '--- CRIA UM ATALHO PARA OS COMBO BOX
    Private Sub cmbCobrancaForma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCobrancaForma.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
            '
            Dim dt As DataTable = cmbCobrancaForma.DataSource
            Dim rCount As Integer = dt.Rows.Count
            Dim item As Integer = e.KeyChar.ToString
            '
            If item <= rCount And item > 0 Then
                Dim Valor As Integer = dt.Rows(e.KeyChar.ToString - 1)("IDCobrancaForma")
                '
                propAPagar.IDCobrancaForma = Valor
                cmbCobrancaForma.SelectedValue = Valor
                '
            End If
        End If
    End Sub
    '
#End Region
    '
#Region "FORM SEM BORDA"
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
    Private Sub frmFreteAPagar_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmFreteAPagar_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region
    '
End Class
