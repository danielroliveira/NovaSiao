Imports CamadaBLL
Imports CamadaDTO

Public Class frmTransferenciaConta
    Private _formOrigem As Form
    '
    Private bindTransf As New BindingSource
    Private _clTransf As clTransferenciaCaixa
    Private _dtBloqueioCtDebito As Date? = Nothing
    Private _dtBloqueioCtCredito As Date? = Nothing
    '
#Region "OPEN | LOAD | PROPRIEDADES"
    '
    Public Sub New(formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        DefineDtMinBloqueio()
        '
        '--- PREENCHE A OBJETO CLSAIDAS
        _clTransf = New clTransferenciaCaixa With {
            .ApelidoFilial = ObterDefault("FilialDescricao"),
            .IDFilial = Obter_FilialPadrao(),
            .TransferenciaData = Obter_DataPadrao(),
            .ComissaoValor = 0,
            .IDContaDebito = Obter_ContaPadrao(),
            .ContaDebito = ObterDefault("ContaDescricao"),
            .IDMeio = 1,
            .TransferenciaValor = 0
        }
        '
        bindTransf.DataSource = _clTransf
        PreencheDataBinding()
        '
    End Sub
    '
#End Region
    '
#Region "DATA BINDINGS"
    '------------------------------------------------------------------------------------------
    ' PREENCHE O DATABINDING
    '------------------------------------------------------------------------------------------
    Private Sub PreencheDataBinding()
        '
        txtContaDebito.DataBindings.Add("Text", bindTransf, "ContaDebito", True, DataSourceUpdateMode.OnPropertyChanged)
        txtContaCredito.DataBindings.Add("Text", bindTransf, "ContaCredito", True, DataSourceUpdateMode.OnPropertyChanged)
        txtComissaoValor.DataBindings.Add("Text", bindTransf, "ComissaoValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTransferenciaValor.DataBindings.Add("Text", bindTransf, "TransferenciaValor", True, DataSourceUpdateMode.OnPropertyChanged)
        lblValorReal.DataBindings.Add("Text", bindTransf, "ValorReal", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindTransf, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpTransferenciaData.DataBindings.Add("Text", bindTransf, "TransferenciaData", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindTransf, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' CARREGA COMBO
        CarregaComboMeio()
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtComissaoValor.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler txtTransferenciaValor.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler lblValorReal.DataBindings("Text").Format, AddressOf FormatCUR
        '
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    '--- COMBO MEIO
    Private Sub CarregaComboMeio()
        '
        Dim dtMeio As New DataTable
        'Adiciona todas as possibilidades de instrucao
        dtMeio.Columns.Add("IDMeio")
        dtMeio.Columns.Add("Meio")
        dtMeio.Rows.Add(New Object() {1, "Moeda"})
        dtMeio.Rows.Add(New Object() {2, "Cheque"})
        dtMeio.Rows.Add(New Object() {3, "Cartão"})
        '
        With cmbMeio
            .DataSource = dtMeio
            .ValueMember = "IDMeio"
            .DisplayMember = "Meio"
            .DataBindings.Add("SelectedValue", bindTransf, "IDMeio", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
    '--- VERIFY IF COMISAO IS GREATE THAN COMISSAO
    '----------------------------------------------------------------------------------
    Private Sub txtTransferenciaValor_Leave(sender As Object, e As EventArgs) Handles _
        txtTransferenciaValor.Leave, txtComissaoValor.Leave
        '
        Dim txt As TextBox = DirectCast(sender, TextBox)
        txt.DataBindings.Item("Text").ReadValue()
        '
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '
    ' ESCOLHER CONTA
    '-----------------------------------------------------------------------------------------------------
    Private Sub ContaEscolher_Click(sender As Object, e As EventArgs) Handles _
        btnContaCredEscolher.Click, btnContaDebEscolher.Click
        '
        '--- get control 
        Dim ct As Control = DirectCast(sender, Control)
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        '--- Abre o frmContas
        Dim frmConta As Form = Nothing
        '
        If ct.Name = btnContaDebEscolher.Name OrElse ct.Name = txtContaDebito.Name Then
            frmConta = New frmContaProcurar(Me, _clTransf.IDFilial, _clTransf.IDContaDebito, True)
        ElseIf ct.Name = btnContaCredEscolher.Name OrElse ct.Name = txtContaCredito.Name Then
            frmConta = New frmContaProcurar(Me, _clTransf.IDFilial, _clTransf.IDContaCredito, True)
        End If
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.OK Then
            '
            If ct.Name = btnContaDebEscolher.Name OrElse ct.Name = txtContaDebito.Name Then
                '
                txtContaDebito.Text = DirectCast(frmConta, frmContaProcurar).propConta_Escolha.Conta
                _clTransf.IDContaDebito = DirectCast(frmConta, frmContaProcurar).propConta_Escolha.IDConta
                _dtBloqueioCtDebito = DirectCast(frmConta, frmContaProcurar).propConta_Escolha.BloqueioData
                '
            ElseIf ct.Name = btnContaCredEscolher.Name OrElse ct.Name = txtContaCredito.Name Then
                '
                txtContaCredito.Text = DirectCast(frmConta, frmContaProcurar).propConta_Escolha.Conta
                _clTransf.IDContaCredito = DirectCast(frmConta, frmContaProcurar).propConta_Escolha.IDConta
                _dtBloqueioCtCredito = DirectCast(frmConta, frmContaProcurar).propConta_Escolha.BloqueioData
                '
            End If
            '
            DefineDtMinBloqueio()
            '
        End If
        '
        '--- FOCUS TXT CONTROL
        If ct.Name = btnContaDebEscolher.Name Then
            txtContaDebito.Focus()
        ElseIf ct.Name = btnContaCredEscolher.Name Then
            txtContaCredito.Focus()
        End If
        '
    End Sub
    '
    '--- CANCELAR
    '----------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    '
    '==========================================================================================
    ' EFETUAR TRANSFERENCIA
    '==========================================================================================
    Private Sub btnEfetuar_Click(sender As Object, e As EventArgs) Handles btnEfetuar.Click
        '
        '--- Verifica se os Valores estão preenchidos e corretos
        '----------------------------------------------------------------------------------
        If VerificarValores() = False Then
            Exit Sub
        End If
        '
        '--- Verifica se a DATA DA ENTRADA é permitida pelo sistema
        '----------------------------------------------------------------------------------
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        '--- Conta Credito
        If DataBloqueada(_clTransf.TransferenciaData,
                         _clTransf.IDContaCredito,
                         _clTransf.ContaCredito,
                         _clTransf.ApelidoFilial) Then
            '
            Cursor = Cursors.Default
            Exit Sub
            '
        End If
        '
        '--- Conta Debito
        If DataBloqueada(_clTransf.TransferenciaData,
                         _clTransf.IDContaDebito,
                         _clTransf.ContaDebito,
                         _clTransf.ApelidoFilial) Then
            '
            Cursor = Cursors.Default
            Exit Sub
            '
        End If
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        '--- Efetua a Transferencia
        '----------------------------------------------------------------------------------
        Dim tBLL As New TransferenciaCaixaBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _clTransf = tBLL.InserirNova_Transferencia(_clTransf)
            '
            '--- Message OK
            If MessageBox.Show("Transferência realizada com sucesso!" & vbNewLine & vbNewLine &
                               "Deseja realizar OUTRA TRANSFERÊNCIA?",
                               "Transferência",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                '
                _clTransf = New clTransferenciaCaixa
                bindTransf.ResetBindings(False)
                '
            Else
                '
                DialogResult = DialogResult.OK
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao EFETUAR a Transferência:" & vbNewLine &
                            ex.Message, "Exceção Inesperada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' VERIFICACAO DOS CAMPOS NECESSARIOS
    '==========================================================================================
    Private Function VerificarValores() As Boolean
        Dim f As New FuncoesUtilitarias
        '
        '--- Campo Conta de Debito
        If IsNothing(_clTransf.IDContaDebito) OrElse _clTransf.IDContaDebito = 0 Then
            '
            MessageBox.Show("O campo Conta de Débito não pode ficar vazio;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro por favor...",
                            "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '
            Dim EP As New ErrorProvider
            EP.SetError(txtContaDebito, "Preencha o valor desse campo!")
            txtContaDebito.Focus()
            '
            Return False
        End If
        '
        '--- Campo Conta de Credito
        If IsNothing(_clTransf.IDContaCredito) OrElse _clTransf.IDContaCredito = 0 Then
            '
            MessageBox.Show("O campo Conta de Crédito não pode ficar vazio;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro por favor...",
                            "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '
            Dim EP As New ErrorProvider
            EP.SetError(txtContaCredito, "Preencha o valor desse campo!")
            txtContaCredito.Focus()
            '
            Return False
        End If
        '--- Verifica contas iguais
        If _clTransf.IDContaDebito = _clTransf.IDContaCredito Then
            '
            MessageBox.Show("As contas de Débito/Saída e Crédito/Entrada não podem ser iguais..." & vbCrLf &
                            "Altere a conta de Crédito ou de Débito",
                            "Contas Iguais",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '
            txtContaDebito.Focus()
            Return False
        End If
        '
        '--- Campo Data da Entrada
        If f.VerificaControlesForm(dtpTransferenciaData, "Data da Entrada") = False Then
            Return False
        End If
        '
        '--- Campo DoValor
        If f.VerificaControlesForm(txtTransferenciaValor, "Valor da Entrada") = False Then
            Return False
        End If
        '
        If IsNumeric(txtTransferenciaValor.Text) AndAlso CDec(txtTransferenciaValor.Text) <= 0 Then
            MessageBox.Show("O Valor da Saída/Pagamento não pode ser igual a ZERO", "Valor Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTransferenciaValor.Focus()
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
#End Region
    '
#Region "ATALHOS - NAVEGAÇÃO"
    '
    '---------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
            txtContaDebito.Name,
            txtContaDebito.Name
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
    ' USAR TAB AO KEYPRESS ENTER
    '------------------------------------------------------------------------------------------
    Private Sub txtValor_KeyDown(sender As Object, e As KeyEventArgs) Handles _
            txtContaCredito.KeyDown,
            txtContaDebito.KeyDown,
            txtObservacao.KeyDown,
            txtComissaoValor.KeyDown,
            txtTransferenciaValor.KeyDown,
            dtpTransferenciaData.KeyDown
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
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtContaCredito.KeyDown, txtContaDebito.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            '
            e.Handled = True
            ContaEscolher_Click(sender, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Delete Then
            '
            e.Handled = True
            '
            If ctr.Name = btnContaDebEscolher.Name Then
                '
                txtContaDebito.Clear()
                _clTransf.IDContaDebito = Nothing
                '
            ElseIf ctr.Name = btnContaCredEscolher.Name Then
                '
                txtContaCredito.Clear()
                _clTransf.IDContaCredito = Nothing
                '
            End If
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({txtContaCredito.Name, txtContaDebito.Name})
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
    '==========================================================================================
    ' DETERMINA DATA MAX E MIN PELA CONTA ESCOLHIDA
    '==========================================================================================
    Private Sub DefineDtMinBloqueio()
        '
        dtpTransferenciaData.MaxDate = Today
        '
        If IsNothing(_dtBloqueioCtCredito) And IsNothing(_dtBloqueioCtDebito) Then
            dtpTransferenciaData.MinDate = Today.AddYears(-10)
            Exit Sub
        End If
        '
        If IsNothing(_dtBloqueioCtDebito) OrElse _dtBloqueioCtCredito > _dtBloqueioCtDebito Then
            dtpTransferenciaData.MinDate = _dtBloqueioCtCredito
        ElseIf IsNothing(_dtBloqueioCtCredito) OrElse _dtBloqueioCtCredito <= _dtBloqueioCtDebito Then
            dtpTransferenciaData.MinDate = _dtBloqueioCtDebito
        End If
        '
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
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmAPagarItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region
    '
End Class
