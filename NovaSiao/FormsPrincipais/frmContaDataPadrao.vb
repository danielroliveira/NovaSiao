Imports CamadaBLL
Imports CamadaDTO

Public Class frmContaDataPadrao
    '
    Private _Conta As clConta
    Private _DataPadrao As Date?
    Private _formOrigem As Form
    Private controlaAlteracao As Boolean = False
    '
#Region "SUB NEW | PROPERTY"
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '
        '--- verifica a conta padrao
        Dim myIDConta As Integer? = Obter_ContaPadrao()
        If IsNothing(myIDConta) Then Return '--- fecha se for Nothing
        '
        '--- Get Conta pelo IDConta
        GetConta(myIDConta)
        If IsNothing(_Conta) Then Return '--- fecha se for Nothing
        '
        txtConta.Text = _Conta.Conta
        txtFilial.Text = _Conta.ApelidoFilial
        '
        '--- Get Data Padrao no CONFIG
        _DataPadrao = Obter_DataPadrao()
        lblDataPadrao.Text = _DataPadrao
        calDataPadrao.SetDate(_DataPadrao)
        '
        DefineDtPadrao_DtMin_DtMax()
        '
        controlaAlteracao = True
        '
    End Sub
    '
    Private Sub GetConta(IDConta As Byte)
        Dim mBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            _Conta = mBLL.Conta_GET_PorIDConta(IDConta)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a Conta pelo ID..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub frmContaDataPadrao_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        '
        '--- fecha se não encontar a Conta Padrao
        If IsNothing(_Conta) Then
            MessageBox.Show("Não foi encontrada uma Conta Padrão no CONFIG..." & vbNewLine &
                            "Defina a Conta Padrão no CONFIG." & vbNewLine &
                            "Esse formulário será encerrado!",
                            "Conta Padrão Inexistente",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '
            btnCancelar_Click(sender, e)
            '
        End If
        '
    End Sub
    '
    '--- VERIFICA INTEGRIDADE DO ARQUIVO DE CONFIG
    Private Sub VerificaValoresDefault()
        '
        '--- Descricao da Conta
        If Not _Conta.Conta.Equals(ObterDefault("ContaDescricao")) Then
            SetarDefault("ContaDescricao", _Conta.Conta)
        End If
        '
        '--- Descricao da Filial
        If Not _Conta.ApelidoFilial.Equals(ObterDefault("FilialDescricao")) Then
            SetarDefault("FilialDescricao", _Conta.ApelidoFilial)
        End If
        '
        '-- IDFilial
        If Not _Conta.IDFilial.Equals(Obter_FilialPadrao()) Then
            SetarDefault("FilialPadrao", _Conta.IDFilial)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTIONS"
    '
    Private Sub btnDefinir_Click(sender As Object, e As EventArgs) Handles btnDefinir.Click
        '
        '--- verifica os controles
        If VerificaCampos() = False Then Exit Sub
        '
        DirectCast(ParentForm, frmPrincipal).propDataPadrao = calDataPadrao.SelectionStart
        DirectCast(ParentForm, frmPrincipal).propContaPadrao = _Conta
        '
        SetarDefault("DataPadrao", calDataPadrao.SelectionStart)
        SetarDefault("FilialPadrao", _Conta.IDFilial)
        SetarDefault("FilialDescricao", txtFilial.Text)
        SetarDefault("ContaPadrao", _Conta.IDConta)
        SetarDefault("ContaDescricao", txtConta.Text)
        '
        Me.Close()
        If IsNothing(_formOrigem) Then MostraMenuPrincipal()
        '
    End Sub
    '
    '--- VERIFICA OS VALORES ANTES DE INSERIR
    Private Function VerificaCampos() As Boolean
        '
        '--- Verifica os controles
        '---------------------------------------------------------------------------------------
        If IsNothing(_Conta.IDFilial) Or txtFilial.Text.Trim.Length = 0 Then
            MessageBox.Show("Nenhuma FILIAL padrão foi escolhida...",
                            "Filial Vazia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFilial.Focus()
            Return False
        End If
        '
        If IsNothing(_Conta.IDConta) Or txtConta.Text.Trim.Length = 0 Then
            MessageBox.Show("Nenhuma CONTA padrão foi escolhida...",
                            "Conta Vazia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtConta.Focus()
            Return False
        End If
        '
        If IsNothing(calDataPadrao.SelectionStart) Then
            MessageBox.Show("Escolha a DATA na qual você deseja que seja a data padrão do sistema...",
                            "Escolha a Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            calDataPadrao.Focus()
            Return False
        End If
        '
        '--- verifica se a data padrao esta bloqueada pelo sistema
        If DataBloqueada(calDataPadrao.SelectionStart, _Conta.IDConta) Then
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
        '
        DialogResult = DialogResult.Cancel
        Me.Close()
        If IsNothing(_formOrigem) Then MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnFilialEscolher_Click(sender As Object, e As EventArgs) Handles btnFilialEscolher.Click
        '
        '--- Abre o frmFilial
        Dim fFil As New frmFilialEscolher(Me, _Conta.IDFilial)
        '
        fFil.ShowDialog()
        '
        If fFil.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        If fFil.propFilial.IDPessoa <> _Conta.IDFilial Then
            _Conta = New clConta
            txtConta.Clear()
        End If
        '
        _Conta.IDFilial = fFil.propFilial.IDPessoa
        _Conta.ApelidoFilial = fFil.propFilial.ApelidoFilial
        txtFilial.Text = fFil.propFilial.ApelidoFilial
        '
    End Sub

    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        '--- Verifica se existe uma filial definida
        If IsNothing(_Conta.IDFilial) Then
            MessageBox.Show("É necessário definir a Filial para escolher a conta a partir dela..." & vbNewLine &
                            "Favor escolher uma Filial Padrão...",
                            "Escolher Filial",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            txtFilial.Focus()
            Return
        End If
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, _Conta.IDFilial, _Conta.IDConta)
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        '--- Define os valores escolhidos
        _Conta = frmConta.propConta_Escolha
        txtConta.Text = _Conta.Conta
        '
        '--- Verifica a Data de Bloqueio
        DefineDtPadrao_DtMin_DtMax()
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    '--- DEFINE OS VALORES DAS DATAS E DAS LABELS
    Private Function DefineDtPadrao_DtMin_DtMax() As Boolean
        '
        '--- DEFINE OS VALORES
        '---------------------------------------------------
        If Not IsNothing(_Conta.BloqueioData) Then
            'blData = CDate(blData).AddDays(1)
            '
            '-- verifica se a data adicionada é DOMINGO, sendo adiciona um dia
            If CDate(_Conta.BloqueioData).DayOfWeek = DayOfWeek.Sunday Then CDate(_Conta.BloqueioData).AddDays(1)
            '
            '-- define a propriedade DATA PADRAO
            calDataPadrao.MinDate = _Conta.BloqueioData
            calDataPadrao.MaxDate = Today
            '
            '-- Verify if DataPadrao is before to DataBloqueio
            If _DataPadrao < _Conta.BloqueioData Then
                _DataPadrao = _Conta.BloqueioData
            End If
            '
            calDataPadrao.SetDate(_DataPadrao)
            '
            '-- define a etiqueta
            lblDataBloqueio.Text = _Conta.BloqueioData
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
			calDataPadrao.MinDate = Today.AddYears(-10)
            calDataPadrao.MaxDate = Today
            '
            '-- Verify if DataPadrao is before to DataBloqueio
            If _DataPadrao < calDataPadrao.MinDate Then
                _DataPadrao = calDataPadrao.MinDate
            End If
            '
            calDataPadrao.SetDate(_DataPadrao)
            '
            '-- define a etiqueta
            lblDataBloqueio.Text = calDataPadrao.MinDate
            '
            Return False
            '
        End If
        '
    End Function
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilial.KeyDown, txtConta.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtFilial"
                    btnFilialEscolher_Click(New Object, New EventArgs)
                    txtFilial.Text = txtFilial.Text.Replace("+", "")
                    txtFilial.SelectAll()
                Case "txtConta"
                    btnContaEscolher_Click(New Object, New EventArgs)
                    txtConta.Text = txtConta.Text.Replace("+", "")
                    txtConta.SelectAll()
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
    '--- ALTERA O LABEL AO SELECIONAR NOVA DATA
    Private Sub calDataPadrao_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calDataPadrao.DateChanged
        lblDataPadrao.Text = e.Start
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
