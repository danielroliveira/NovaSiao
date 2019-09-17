Imports CamadaBLL
Imports CamadaDTO

Public Class frmCaixaInserir
    Private _IDFilial As Integer?
    Private _IDConta As Int16?
    Private _IDFuncionario As Integer?
    Private _Conta As String
    Private _CaixaDiario As Boolean
    Private _IDCaixa As Integer?
    '
    Private minDate As Date? = Nothing
    Private maxDate As Date? = Nothing
    Private dtFinalCaixa As Date? = Nothing
    Private LastIDCaixa As Integer? = Nothing
    Private LastSitCaixa As Byte? = Nothing
    Private SaldoAnterior As Decimal
    '
    Private _formOrigem As Form
    '
    Private controlaAlteracao As Boolean = False
    '
#Region "SUB NEW | PROPERTY"
    '
    Sub New(Optional formOrigem As Form = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        btnInserir.Text = "&Inserir"
        lblTitulo.Text = "Efetuar Fechamento de Caixa"
        '
        '--- verifica a conta padrao
        txtConta.Text = ObterDefault("ContaDescricao")
        _Conta = txtConta.Text
        propIDConta = Obter_ContaPadrao()
        _IDFilial = Obter_FilialPadrao()
        lblFilial.Text = ObterDefault("FilialDescricao")
        '
        controlaAlteracao = True
        '
        propCaixaDiario = True
        '
        _formOrigem = formOrigem
        '
    End Sub
    '
    Sub New(myCaixa As clCaixa,
            formOrigem As Form)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        btnInserir.Text = "&Alterar"
        lblTitulo.Text = "Alterar Período do Caixa"
        '
        _IDCaixa = myCaixa.IDCaixa
        _IDConta = myCaixa.IDConta
        _Conta = myCaixa.Conta
        _IDFilial = myCaixa.IDFilial
        lblFilial.Text = myCaixa.ApelidoFilial
        txtConta.Text = myCaixa.Conta
        _IDFuncionario = myCaixa.IDFuncionario
        txtFuncionarioApelido.Text = myCaixa.ApelidoFuncionario
        '
        obterInfoConta()
        propMinDate = myCaixa.DataInicial
        dtFinalCaixa = myCaixa.DataFinal
        If IsNothing(propMaxDate) Then propMaxDate = myCaixa.DataFinal
        dtpFinal.Value = myCaixa.DataFinal
        '
        chkDiario.Checked = False
        '
        btnContaEscolher.Enabled = False
        btnFuncEscolher.Enabled = False
        '
        _formOrigem = formOrigem
        '
        controlaAlteracao = True
        '
    End Sub
    '
    Public Property propMinDate() As Date?
        Get
            Return minDate
        End Get
        Set(ByVal value As Date?)
            minDate = value
            lblDtInicialValor.Text = IIf(IsNothing(minDate), "", minDate)
        End Set
    End Property
    '
    Public Property propMaxDate() As Date?
        Get
            Return maxDate
        End Get
        Set(ByVal value As Date?)
            maxDate = value
            '
            If Not IsNothing(value) Then
                dtpFinal.MaxDate = maxDate
                lblMax.Text = "max.:" & maxDate
            Else
                dtpFinal.ResetText()
            End If
            '
        End Set

    End Property
    '
    Public Property propIDConta() As Int16?
        Get
            Return _IDConta
        End Get
        Set(ByVal value As Int16?)
            '
            _IDConta = value
            '
            '--- Obtem as datas iniciais e finais das movimentações de caixa
            If obterInfoConta() = False OrElse VerificaSituacaoCaixa() = False OrElse VerificaExisteMovs() = False Then
                '
                dtpFinal.Enabled = False
                btnInserir.Enabled = False
                lblDtInicialValor.Text = "Vazia"
                txtConta.Clear()
                '
            Else
                dtpFinal.Enabled = True
                btnInserir.Enabled = True
            End If
            '
        End Set
        '
    End Property
    '
    Public Property propCaixaDiario() As Boolean
        Get
            Return _CaixaDiario
        End Get
        Set(ByVal value As Boolean)
            _CaixaDiario = value
            '
            If value = True Then
                '--- controla o tamanho do form
                pnlDtFinal.Visible = False
                Me.Height = 368
                '
                '--- define o valor do maxDate
                If Not IsNothing(propMinDate) Then dtpFinal.Value = propMinDate
                '
                '--- lblDtInicialTexto
                lblDtInicialTexto.Text = "Data do Caixa:"
                '
            Else
                '--- controla o tamanho do form
                pnlDtFinal.Visible = True
                Me.Height = 442
                '
                '--- define o valor do maxDate
                If Not IsNothing(propMaxDate) Then dtpFinal.Value = propMaxDate
                '
                '--- lblDtInicialTexto
                lblDtInicialTexto.Text = "Data Inicial:"
                '
            End If
            '
            '--- Redesenha a border do form
            Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
            Dim pen As New Pen(Color.SlateGray, 3)
            '
            Me.Refresh()
            Me.CreateGraphics.DrawRectangle(pen, rect)
            '
        End Set
    End Property
    '
#End Region
    '
#Region "GET DADOS"
    '
    Private Function obterInfoConta() As Boolean
        '
        If IsNothing(_IDConta) Then
            propMinDate = Nothing
            propMaxDate = Nothing
            LastSitCaixa = Nothing
            LastIDCaixa = Nothing
            SaldoAnterior = 0
            Return False
        End If
        '
        Dim db As New CaixaBLL
        '
        Try
            '--- GET datas inicial e Final
            Dim dt As DataTable = db.GetLastDados_IDConta(_IDConta)
            Dim r As DataRow = dt.Rows(0)
            '
            propMinDate = IIf(IsDBNull(r("dtInicial")), Nothing, r("dtInicial"))
            propMaxDate = IIf(IsDBNull(r("dtFinal")), Nothing, r("dtFinal"))
            LastSitCaixa = IIf(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
            LastIDCaixa = IIf(IsDBNull(r("LastIDCaixa")), Nothing, r("LastIDCaixa"))
            SaldoAnterior = IIf(IsDBNull(r("SaldoFinal")), Nothing, r("SaldoFinal"))
            '
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Um exceção ocorreu ao tentar obter as datas dessa Conta ..." & vbNewLine &
                            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
    End Function
    '
    Function VerificaSituacaoCaixa() As Boolean
        '
        '--- Verifica a Situacao do ultimo CAIXA
        '----------------------------------------------------------------------------------------
        If IsNothing(_IDCaixa) Then
            '
            If LastSitCaixa = 1 Then '--- já existe um caixa emaberto nessa conta
                '
                If Not Me.CanFocus Then
                    _IDConta = Nothing
                    _Conta = ""
                    Return False
                    Exit Function
                End If
                '
                If MessageBox.Show("A Conta Escolhida: " & _Conta.ToUpper & " apresenta um CAIXA EM ABERTO..." & vbNewLine &
                                   "Não é possível efetuar novo Caixa antes de finalizar o anterior." & vbNewLine & vbNewLine &
                                   "Deseja verificar esse Caixa em aberto?",
                                   "Caixa Em Aberto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    '
                    '--- Abre o frmCaixa com o ultimo caixa encontrado
                    Dim cBLL As New CaixaBLL
                    Dim clC As New clCaixa
                    '
                    clC = cBLL.GetCaixa_PeloID(LastIDCaixa)
                    '
                    Dim fCx As New frmCaixa(clC)
                    '
                    fCx.MdiParent = frmPrincipal
                    fCx.Show()
                    Me.Close()
                    '
                End If
                '
                Return False
                '
            Else
                Return True
            End If
            '
        Else
            If LastIDCaixa <> _IDCaixa Then
                Return False
            Else
                Return True
            End If
        End If
        '
    End Function

    Private Function VerificaExisteMovs() As Boolean
        '
        '--- Se for referente a um caixa Em aberto não verifica
        If Not IsNothing(_IDCaixa) Then Return True
        '
        '--- Verifica as DATAS das movimentações (Iicial e Final)
        '--- se não houver dtInicial então não há Entrada/Saida
        '----------------------------------------------------------------------------------------
        '
        If IsNothing(propMinDate) Then
            '
            MessageBox.Show("A Conta Escolhida: " & _Conta.ToUpper &
                            " não apresenta movimentações pendentes de Fechamento de Caixa..." &
                            vbNewLine & vbNewLine & "Favor Escolher outra conta...",
                            "Conta sem Movimentação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Return False
            '
        Else
            Return True
        End If
        '
    End Function
    '
#End Region
    '
#Region "BUTTONS FUNCTIONS"
    '
    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        '
        '--- Verifica os campos
        '---------------------------------------------------------------------------------------
        If VerificaCampos() = False Then Exit Sub
        '
        '--- Preenche os Valores
        '---------------------------------------------------------------------------------------
        If IsNothing(propMaxDate) OrElse propMaxDate <> dtpFinal.Value Then
            maxDate = dtpFinal.Value
        End If
        '
        _Conta = txtConta.Text
        '
        '--- Verifica se é INSERIR OU ALTERAR
        '---------------------------------------------------------------------------------------
        If IsNothing(_IDCaixa) Then '--- INSERIR NOVO REGISTRO DE CAIXA
            InserirNovoCaixa()
        ElseIf Not IsNothing(_IDCaixa) Then '--- ALTERAR O PERIODO DAS DATAS DO CAIXA
            AlterarCaixa()
        End If
        '
    End Sub
    '
    '--- SALVAR UM NOVO REGISTRO DE CAIXA
    Private Sub InserirNovoCaixa()
        '
        '--- Verifica a FILIAL/CONTA, DataInicial e DataFinal
        '-----------------------------------------------------------------------------
        '--- Pergunta ao usuário
        Dim strP As String = String.Format("Você realmente deseja efetuar o Caixa com os seguintes valores:{4}{4}" &
                                           "Filial: {1}{4}Conta: {0}{4}DE: {2}{4}ATÉ: {3}",
                                           _Conta.ToUpper,
                                           lblFilial.Text.ToUpper,
                                           Convert.ToDateTime(minDate).ToShortDateString,
                                           Convert.ToDateTime(maxDate).ToShortDateString,
                                           vbNewLine)
        '
        If MessageBox.Show(strP, "Efetuar Caixa",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1) = DialogResult.No Then
            Close()
        End If
        '
        '--- Insere um novo Registro de Caixa
        '-----------------------------------------------------------------------------
        Dim cxBLL As New CaixaBLL
        Dim newCaixa As New clCaixa
        '
        newCaixa.IDConta = _IDConta
        newCaixa.IDFilial = _IDFilial
        newCaixa.FechamentoData = Today.ToShortDateString
        newCaixa.IDSituacao = 1
        newCaixa.DataInicial = minDate
        newCaixa.DataFinal = maxDate
        newCaixa.IDFuncionario = _IDFuncionario
        '
        Try
            '
            newCaixa = cxBLL.InserirNovo_Caixa(newCaixa)
            '
            If IsNothing(newCaixa) Then
                MessageBox.Show("Um erro ocorreu ao EFETUAR Novo Fechamento de Caixa",
                                "Inserir Novo Caixa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '
            Dim fCx As New frmCaixa(newCaixa)
            '
            fCx.MdiParent = frmPrincipal
            fCx.Show()
            DialogResult = DialogResult.OK
            Close()
            '
        Catch ex As Exception
            MessageBox.Show("Um erro ocorreu ao EFETUAR Novo Fechamento de Caixa" & vbNewLine &
                            vbNewLine & ex.Message,
                            "Inserir Novo Caixa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
    End Sub
    '
    '--- ALTERA O PERIODO DAS DATAS DO CAIXA
    Private Sub AlterarCaixa()
        '
        If dtpFinal.Value = dtFinalCaixa Then
            MessageBox.Show("Não nenhuma alteração do período...", "Alterar Período",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.Cancel
            Close()
            Exit Sub
        End If
        '
        propMaxDate = dtpFinal.Value
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    '--- VERIFICA OS VALORES ANTES DE INSERIR
    Private Function VerificaCampos() As Boolean
        '
        '--- Verifica os controles
        '---------------------------------------------------------------------------------------
        If IsNothing(_IDFilial) Then
            MessageBox.Show("Escolha a FILIAL para a qual você deseja realizar o fechamento do caixa...",
                            "Filial Vazia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        '
        If IsNothing(_IDConta) Or txtConta.Text.Trim.Length = 0 Then
            MessageBox.Show("Escolha a CONTA na qual você deseja realizar o fechamento do caixa...",
                            "Conta Vazia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtConta.Focus()
            Return False
        End If
        '
        If dtpFinal.Value < minDate Then
            MessageBox.Show("A data Final não pode ser menor que a Data Inicial...",
                "Data Final / Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpFinal.Focus()
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        Me.Close()
        If IsNothing(_formOrigem) Then MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        If btnContaEscolher.Enabled = False Then Exit Sub
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, _IDFilial, _IDConta)
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult <> DialogResult.OK Then Exit Sub
        '
        _Conta = frmConta.propConta_Escolha.Conta
        txtConta.Text = _Conta
        propIDConta = frmConta.propConta_Escolha.IDConta
        '
    End Sub
    '
    Private Sub btnFuncEscolher_Click(sender As Object, e As EventArgs) Handles btnFuncEscolher.Click
        '
        If btnFuncEscolher.Enabled = False Then Exit Sub
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        Dim fFunc As New frmFuncionarioEscolher(False, Me)
        Cursor = Cursors.Default
        '
        fFunc.ShowDialog()
        If fFunc.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        _IDFuncionario = fFunc.IDEscolhido
        txtFuncionarioApelido.Text = fFunc.NomeEscolhido
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    '---------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
            "txtConta",
            "txtFuncionarioApelido"
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
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles _
        txtConta.KeyDown,
        txtFuncionarioApelido.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtConta"
                    btnContaEscolher_Click(New Object, New EventArgs)
                    txtConta.SelectAll()
                Case "txtFuncionarioApelido"
                    btnFuncEscolher_Click(New Object, New EventArgs)
                    txtFuncionarioApelido.SelectAll()
            End Select
        ElseIf e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    Private Sub chkDiario_KeyDown(sender As Object, e As KeyEventArgs) Handles chkDiario.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    Private Sub chkDiario_CheckedChanged(sender As Object, e As EventArgs) Handles chkDiario.CheckedChanged
        '
        If controlaAlteracao = False Then Exit Sub
        '
        propCaixaDiario = chkDiario.Checked
        dtpFinal.Focus()
        '
    End Sub
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
#End Region
    '
End Class
