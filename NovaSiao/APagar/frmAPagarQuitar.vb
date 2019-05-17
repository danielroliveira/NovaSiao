Imports CamadaBLL
Imports CamadaDTO

Public Class frmAPagarQuitar
    Private _formOrigem As Form
    Private _vlMax As Decimal = 0
    Private _VerAlteracao As Boolean = False
    '
    Private bindSaida As New BindingSource
    Property propMovSaida As clMovimentacao
    Property propPagOrigem As clAPagar
    '
#Region "OPEN | LOAD | PROPRIEDADES"
    '
    Public Sub New(formOrigem As Form, _PagOrigem As clAPagar)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propPagOrigem = _PagOrigem
        _formOrigem = formOrigem
        _vlMax = _PagOrigem.APagarValor - _PagOrigem.ValorPago - If(_PagOrigem.Desconto, 0)
        '
        '--- PREENCHE A OBJETO CLSAIDAS
        propMovSaida = New clMovimentacao(EnumMovimentacaoOrigem.APagar, EnumMovimento.Saida)
        bindSaida.DataSource = propMovSaida
        propMovSaida.IDOrigem = propPagOrigem.IDAPagar
        propMovSaida.MovData = Obter_DataPadrao()
        propMovSaida.IDConta = Obter_ContaPadrao()
        propMovSaida.Conta = ObterDefault("ContaDescricao")
        txtConta.Text = propMovSaida.Conta
        propMovSaida.IDFilial = Obter_FilialPadrao()
        lblFilial.Text = ObterDefault("FilialDescricao")
        propMovSaida.Origem = 1 '--- ORIGEM IDAPAGAR
        propMovSaida.Creditar = False
        PreencheDataBinding()
        '
        '--- PREENCHE OS CAMPOS DOS CONTROLES
        txtValorPago.Text = FormatCurrency(_vlMax, 2)
        txtAcrescimo.Text = FormatCurrency(0, 2)
        CalculaValorPago()
        _VerAlteracao = True
        '
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
        lblSaidaValor.DataBindings.Add("Text", bindSaida, "MovValor", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpSaidaData.DataBindings.Add("Value", bindSaida, "MovData", True, DataSourceUpdateMode.OnPropertyChanged)
        txtObservacao.DataBindings.Add("Text", bindSaida, "Observacao", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblSaidaValor.DataBindings("Text").Format, AddressOf FormatCUR
        '
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As ConvertEventArgs)
        e.Value = FormatCurrency(Math.Abs(e.Value), 2)
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '
    ' ESCOLHER CONTA
    '-----------------------------------------------------------------------------------------------------
    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, propMovSaida.IDFilial, propMovSaida.IDConta)
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.Cancel Then
            propMovSaida.IDConta = Nothing
            txtConta.Clear()
        Else
            '
            txtConta.Text = frmConta.propConta_Escolha.Conta
            propMovSaida.IDConta = frmConta.propConta_Escolha.IDConta
            '
        End If
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        '
        '--- Verifica se os Valores estão preenchidos e corretos
        If VerificarValores() = False Then Exit Sub
        '
        '--- Verifica se a DATA DA ENTRADA é permitida pelo sistema
        If DataBloqueada(propMovSaida.MovData, propMovSaida.IDConta) Then
            Exit Sub
        End If
        '
        '--- Insere a SAIDA
        Dim pBLL As New APagarBLL
        Dim newID As Integer?
        '
        Try
            newID = pBLL.Quitar_APagar(propMovSaida.IDOrigem, propMovSaida.MovValor,
                                       IIf(IsNumeric(txtAcrescimo.Text), CDbl(txtAcrescimo.Text), 0),
                                       propMovSaida.MovData, propMovSaida.IDConta, propMovSaida.Observacao)

            '
            If Not IsNumeric(newID) Then
                Throw New Exception(newID.ToString)
            Else
                propMovSaida.IDMovimentacao = newID
                propMovSaida.Conta = txtConta.Text
            End If
            '
            DialogResult = DialogResult.OK
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao QUITAR o APagar:" & vbNewLine &
                            ex.Message, "Exceção Inesperada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
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
        If IsNothing(propMovSaida.IDConta) OrElse propMovSaida.IDConta = 0 Then

            MsgBox("O campo Conta de Saída não pode ficar vazio;" & vbCrLf &
                   "Preencha esse campo antes de Salvar o registro por favor...", vbInformation, "Campo Vazio")
            '
            Dim EP As New ErrorProvider
            EP.SetError(txtConta, "Preencha o valor desse campo!")
            '
            Return False
        End If
        '
        '--- Campo Data da Entrada
        If f.VerificaControlesForm(dtpSaidaData, "Data da Entrada") = False Then
            Return False
        End If
        '
        '--- Campo DoValor
        If f.VerificaControlesForm(txtValorPago, "Valor da Entrada") = False Then
            Return False
        End If
        '
        If IsNumeric(txtValorPago.Text) AndAlso CDec(txtValorPago.Text) = 0 Then
            MessageBox.Show("O Valor da Saída/Pagamento não pode ser igual a ZERO", "Valor Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtValorPago.Focus()
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
    '------------------------------------------------------------------------------------------
    ' USAR TAB AO KEYPRESS ENTER
    '------------------------------------------------------------------------------------------
    Private Sub txtValor_KeyDown(sender As Object, e As KeyEventArgs) Handles rbtTotal.KeyDown,
            txtValorPago.KeyDown,
            txtAcrescimo.KeyDown,
            txtObservacao.KeyDown,
            txtConta.KeyDown,
            dtpSaidaData.KeyDown
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
    '    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtConta.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            btnContaEscolher_Click(sender, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            txtConta.Clear()
            '
            If Not IsNothing(propMovSaida.IDFilial) Then
                propMovSaida.IDFilial = Nothing
            End If
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({"txtFilial"})
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS - CALCULOS"
    '
    '------------------------------------------------------------------------------------------
    ' CALCULA O VALOR DO CAMPO VALORPAGO = DOVALOR + ACRESCIMO - DESCONTO
    '------------------------------------------------------------------------------------------
    Private Sub CalculaValorPago()
        '
        Dim DoValor As Double = 0
        Dim Acresc As Double = 0
        Dim Desc As Double = 0
        '
        '--- Verifica o campo VALORPAGO
        If IsNumeric(txtValorPago.Text) Then
            DoValor = CDbl(txtValorPago.Text)
            '
            '--- verifica se o valor é maior para calcular o ACRESCIMO
            If DoValor > _vlMax Then
                '
                Dim dlgQ As New dlgAPagarQuitarAlteraValor(_vlMax, IIf(propPagOrigem.Origem = 3, True, False))
                '
                dlgQ.ShowDialog()
                '
                If dlgQ.DialogResult = 1 Then
                    '
                    '--- verifica qual o resultado da resposta
                    Select Case dlgQ.Resposta
                        Case 1 '--- Acresccentar no ACRESCIMO
                            txtAcrescimo.Text = Format(DoValor - _vlMax, "C")
                        Case 2 '--- ALTERAR o valor
                            propPagOrigem.APagarValor = DoValor + propPagOrigem.Desconto
                            _vlMax = propPagOrigem.APagarValor - propPagOrigem.ValorPago - propPagOrigem.Desconto
                        Case 3 '--- DESCARTAR a diferença
                            txtAcrescimo.Text = _vlMax
                    End Select
                    '
                Else
                    txtValorPago.Focus()
                End If
                '
                txtValorPago.Text = FormatCurrency(_vlMax, 2)
                DoValor = _vlMax
                '
            End If
            '
        End If
        '
        '--- Verifica o campo ACRESCIMO
        If IsNumeric(txtAcrescimo.Text) Then
            Acresc = CDbl(txtAcrescimo.Text)
        End If
        '
        '--- RETORNA O VALOR TOTAL
        propMovSaida.MovValor = DoValor + Acresc - Desc
        lblSaidaValor.DataBindings("text").ReadValue()
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' RECALCULA O VALOR PAGO QUANDO ALTERA TXTDOVALOR OU TXTACRESCIMO
    '------------------------------------------------------------------------------------------
    Private Sub txtValor_Validated(sender As Object, e As EventArgs) Handles txtValorPago.Validated, txtAcrescimo.Validated
        CalculaValorPago()
    End Sub
    '
#End Region
    '
#Region "VISUAL EFFECTS"
    '
    ' ALTERA A COR DO DATAGRIDVIEW QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgv_GotFocus(sender As Object, e As EventArgs) Handles rbtParcial.GotFocus, rbtTotal.GotFocus
        '
        pnlTipoPagamento.BackColor = Color.FromArgb(209, 215, 220)
        '
    End Sub
    '
    Private Sub dgv_LostFocus(sender As Object, e As EventArgs) Handles rbtParcial.LostFocus, rbtTotal.LostFocus
        '
        pnlTipoPagamento.BackColor = Color.FromArgb(218, 230, 242)
        '
    End Sub
#End Region '/ VISUAL EFFECTS
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
