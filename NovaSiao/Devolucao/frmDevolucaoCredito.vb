Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmDevolucaoCredito
    '
    Private _formOrigem As Form
    Private _vlMaximo As Double
    Private _Mov As clMovimentacao
    Private bindMov As New BindingSource
    Private _Conta As clConta
    Private _DataPadrao As Date?
    Private _Acao As EnumFlagAcao
    '
#Region "NEW | BINDING | COMBOBOX"
    '
    '-------------------------------------------------------------------------------------------------
    ' SUB NEW
    '-------------------------------------------------------------------------------------------------
    Sub New(fOrigem As Form,
            TranVlTotal As Double,
            Mov As clMovimentacao,
            Acao As EnumFlagAcao,
            Optional Posicao As Point = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = fOrigem
        _vlMaximo = TranVlTotal
        _Mov = Mov
        _Acao = Acao
        _DataPadrao = Obter_DataPadrao()
        '
        '--- se for editar obtem info da CONTA
        If Acao = EnumFlagAcao.EDITAR Then
            Dim cBLL As New MovimentacaoBLL
            _Conta = cBLL.Conta_GET_PorIDConta(_Mov.IDConta)
        End If
        '
        bindMov.DataSource = _Mov
        PreencheDataBinding()
        '
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
        txtMovValor.DataBindings.Add("Text", bindMov, "MovValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtConta.DataBindings.Add("Text", bindMov, "Conta", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpMovData.DataBindings.Add("Text", bindMov, "MovData", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtMovValor.DataBindings("Text").Format, AddressOf FormatCUR
        '
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
#End Region '/ NEW | BINDING | COMBOBOX
    '
#Region "ATALHOS | FUNCOES UTILITARIAS"
    '
    '------------------------------------------------------------------------------------------
    ' USAR TAB AO KEYPRESS ENTER
    '------------------------------------------------------------------------------------------
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtMovValor.KeyDown, txtConta.KeyDown, dtpMovData.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        Else
            '--- bloqueados de alteracao
            If DirectCast(sender, Control).Name = "txtConta" Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    '---------------------------------------------------------------------------------------
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtConta.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            Select Case ctr.Name
                Case "txtConta"
                    btnProcurarConta_Click(New Object, New EventArgs)
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtConta"
                    txtConta.Clear()
                    _Mov.IDConta = Nothing
            End Select
            '
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ITENS DA LISTAGEM
    '------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            '
            e.Handled = True
            btnCancelar_Click(New Object, New EventArgs)
            '
        End If
        '
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
                "txtConta"
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
        If IsNothing(_Mov.IDConta) Then
            MessageBox.Show("O campo CONTA não pode ficar vazio..." & vbNewLine &
                            "Favor escolher um valor para esse campo.", "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtConta.Focus()
            Exit Sub
        End If
        '
        If IsNothing(_Mov.MovData) Then
            MessageBox.Show("O campo da DATA não pode ficar vazio..." & vbNewLine &
                            "Favor escolher um valor para esse campo.", "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpMovData.Focus()
            Exit Sub
        End If
        '
        If IsNothing(_Mov.MovValor) OrElse _Mov.MovValor <= 0 OrElse _Mov.MovValor > _vlMaximo Then
            MessageBox.Show("O VALOR do Crédito de Devolução não pode ser igual ou menor que Zero..." & vbNewLine &
                            "bem como também não pode ser maior que o total da Devolução que ainda não foi creditada: " & Format(_vlMaximo, "c") &
                            vbNewLine & vbNewLine &
                            "Favor determinar um novo valor para esse campo.", "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMovValor.Focus()
            txtMovValor.SelectAll()
            Exit Sub
        End If
        '
        '--- Devolve o credito para o formOrigem
        _Mov.Conta = txtConta.Text
        _Mov.IDConta = _Conta.IDConta
        _Mov.MovValor = txtMovValor.Text
        _Mov.MovData = dtpMovData.Value
        '
        bindMov.EndEdit()
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    '--- BTN FECHAR | CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        bindMov.CancelEdit()
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
    '--- BTN PROCURAR CONTA
    Private Sub btnProcurarConta_Click(sender As Object, e As EventArgs) Handles btnProcurarConta.Click
        '
        '--- Verifica se existe uma filial definida
        If IsNothing(_Mov.IDFilial) Then
			AbrirDialog("É necessário definir a Filial para escolher a conta a partir dela..." & vbNewLine &
						"Favor escolher uma Filial Padrão...",
						"Escolher Filial",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Information)
			Return
        End If
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, _Mov.IDFilial, _Mov.IDConta)
        frmConta.ShowDialog()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        If frmConta.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        '--- Define os valores escolhidos
        _Conta = frmConta.propConta_Escolha
        _Mov.Conta = _Conta.Conta
        _Mov.IDConta = _Conta.IDConta
        txtConta.Text = _Conta.Conta
        '
        txtConta.Focus()
        '
        '--- Verifica a Data de Bloqueio
        DefineDtPadrao_DtMin_DtMax()
        '
    End Sub
    '
    '--- DEFINE OS VALORES DAS DATAS E DAS LABELS
    Private Function DefineDtPadrao_DtMin_DtMax() As Boolean
        '
        '--- DEFINE OS VALORES
        '---------------------------------------------------
        If Not IsNothing(_Conta.BloqueioData) Then
            '
            '-- define a propriedade DATA PADRAO
            dtpMovData.MinDate = _Conta.BloqueioData
            dtpMovData.MaxDate = Today
            '
            '-- Verify if DataPadrao is before to DataBloqueio
            If _DataPadrao < _Conta.BloqueioData Then
                _DataPadrao = _Conta.BloqueioData
            End If
            '
            dtpMovData.Value = _DataPadrao
            '
            Return True
            '
        Else '-- Se não houver DataBloqueio definida escolhe o dia de HOJE
			AbrirDialog("A CONTA PADRÃO escolhida: " & _Conta.Conta.ToUpper & vbNewLine &
						"ainda não tem data de bloqueio definida..." & vbNewLine &
						"A DATA PADRÃO do sistema será definida para " &
						"DATA ATUAL: " & Format(Now, "dd \d\e MMMM \d\e yyyy"),
						"Data Padrão",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			'
			dtpMovData.MinDate = Today.AddYears(-10)
            dtpMovData.MaxDate = Today
            '
            '-- Verify if DataPadrao is before to DataBloqueio
            If _DataPadrao < dtpMovData.MinDate Then
                _DataPadrao = dtpMovData.MinDate
            End If
            '
            dtpMovData.Value = _DataPadrao
            '
            Return False
            '
        End If
        '
    End Function
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
    '
#End Region '/ EFEITO VISUAL
    '
End Class
