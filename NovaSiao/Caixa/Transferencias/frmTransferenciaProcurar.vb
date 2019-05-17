Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmTransferenciaProcurar
    Private tBLL As New TransferenciaCaixaBLL
    Private TransfLista As New List(Of clTransferenciaCaixa)
    Private _myMes As Date
    Private _Sit As EnumFlagEstado
    Private _formOrigem As Form = Nothing
    Private _IDFilial As Integer?
    Private _IDConta As Int16?
    '
#Region "PROPERTY E EVENTO LOAD"
    '
    Private Property myMes() As DateTime
        Get
            Return _myMes
        End Get
        Set(ByVal value As DateTime)
            If CDate(value.ToShortDateString) > CDate(Now.ToShortDateString) Then
                value = Now.ToShortDateString
                btnPeriodoPosterior.Enabled = False
            Else
                btnPeriodoPosterior.Enabled = True
            End If
            _myMes = value
            lblPeriodo.Text = Format(_myMes, "MMMM | yyyy")
        End Set
    End Property
    '
    Private Property propIDConta() As Int16
        Get
            Return _IDConta
        End Get
        Set(ByVal value As Int16)
            _IDConta = value
            Get_Dados()
        End Set
    End Property
    '
    Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        ''--- verifica a conta padrao
        _IDFilial = Obter_FilialPadrao()
        lblFilial.Text = ObterDefault("FilialDescricao")
        _IDConta = Obter_ContaPadrao()
        txtConta.Text = ObterDefault("ContaDescricao")
        '
        myMes = ObterDefault("DataPadrao")
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        FormataListagem()
        '
        _formOrigem = formOrigem
        '
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
        '
        pnlMes.Location() = New Point(636, 130)
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM CONFIGURAÇÃO"
    Private Sub FormataListagem()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        dgvListagem.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvListagem.MultiSelect = False
        dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListagem.ColumnHeadersVisible = False
        dgvListagem.AllowUserToResizeRows = False
        dgvListagem.AllowUserToResizeColumns = False
        dgvListagem.RowHeadersVisible = True
        dgvListagem.RowHeadersWidth = 30
        dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvListagem.StandardTab = True
        '
        Get_Dados()
        PreencheListagem()
        '
    End Sub
    '
    Private Sub Get_Dados()
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                TransfLista = tBLL.GetTransferenciasLista_Procura(propIDConta)
            Else
                Dim f As New Utilidades
                Dim dtInicial As Date = f.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = f.LastDayOfMonth(myMes)
                '
                TransfLista = tBLL.GetTransferenciasLista_Procura(propIDConta, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = TransfLista
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu exceção ao obter a lista de Transferências de Conta..." & vbNewLine &
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
    Private Sub PreencheListagem()
        '
        ' (0) COLUNA ID
        With clnIDTransferencia
            .DataPropertyName = "IDTransferencia"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Format = "0000"
        End With
        '
        ' (1) COLUNA DATA
        With clnTransferenciaData
            .DataPropertyName = "TransferenciaData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA CONTA DEBITO
        With clnContaDebito
            .DataPropertyName = "ContaDebito"
            .Width = 200
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA CONTA CREDITO
        With clnContaCredito
            .DataPropertyName = "ContaCredito"
            .Width = 200
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA MEIO
        With clnMeio
            .DataPropertyName = "Meio"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (5) COLUNA VALOR
        With clnTransferenciaValor
            .DataPropertyName = "TransferenciaValor"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        dgvListagem.Columns.AddRange(New DataGridViewColumn() {
                                     clnIDTransferencia,
                                     clnTransferenciaData,
                                     clnContaDebito,
                                     clnContaCredito,
                                     clnMeio,
                                     clnTransferenciaValor})
    End Sub
    '
    '--- FORMATA O DATAGRID
    '----------------------------------------------------------------------------------
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        'If DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clAPagar).Origem = 3 Then
        '    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
        '    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Yellow
        'Else
        '    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
        '    dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
        'End If
        ''
        ''--- Define o texto do APAGAR quando esta VENCIDO
        'If e.ColumnIndex = 5 AndAlso e.Value = "Em Aberto" Then
        '    Dim dtVenc As Date = dgvListagem.Rows(e.RowIndex).Cells(0).Value
        '    If dtVenc < Date.Today Then
        '        e.Value = "Vencida"
        '        e.CellStyle.ForeColor = Color.Red
        '    End If
        'End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    '--- EXCLUIR
    '----------------------------------------------------------------------------------
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        '--- Verifica Selecao
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Favor selecionar uma Transferência antes para poder excluir...",
                            "Excluir Transferencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        '--- GET Selected Transferencia
        Dim tr As clTransferenciaCaixa = dgvListagem.SelectedRows(0).DataBoundItem
        '
        '--- PERGUNTA AO USER
        '----------------------------------------------------------------------------------
        If MessageBox.Show("Você deseja realmente excluir a Transferência de número: " &
                           Format(tr.IDTransferencia, "0000") &
                           vbNewLine & "ORIGEM: " & tr.ContaDebito &
                           vbNewLine & "DESTINO: " & tr.ContaCredito,
                           "Excluir Transferência",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '
        '--- DELETE TRANSFERENCIA
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If tBLL.Excluir_Transferencia(tr) Then
                Get_Dados()
                MessageBox.Show("Transferência excluída com sucesso!",
                                "Transferência Excluída",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir Transferência..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- CANCELAR FECHAR
    '----------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
        '
        Close()
        If IsNothing(_formOrigem) Then MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, _IDFilial, _IDConta)
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.OK Then
            '
            txtConta.Text = frmConta.propConta_Escolha.Conta
            propIDConta = frmConta.propConta_Escolha.IDConta
            '
        End If
    End Sub
    '
    '--- EFETUAR NOVA TRANSFERENCIA
    '----------------------------------------------------------------------------------
    Private Sub btnEfetuarNova_Click(sender As Object, e As EventArgs) Handles btnEfetuarNova.Click
        '
        Dim frmN As New frmTransferenciaConta(Me)
        frmN.ShowDialog()
        '
        If frmN.DialogResult = DialogResult.OK Then
            Get_Dados()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLES GERAIS | FLUXO"
    '
    '---------------------------------------------------------------------------------------
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
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            'btnAbrir_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs)
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            PreencheListagem()
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConta.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtConta"
                    btnContaEscolher_Click(New Object, New EventArgs)
                    txtConta.Text = txtConta.Text.Replace("+", "")
                    txtConta.SelectAll()
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtConta"
                    propIDConta = Nothing
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
#End Region
    '
#Region "CONTROLE DO PERÍODO"
    '
    Private Sub btnPeriodoAnterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoAnterior.Click
        myMes = myMes.AddMonths(-1)
        dtMes.SelectionStart = myMes
    End Sub
    '
    Private Sub btnPeriodoPosterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoPosterior.Click
        myMes = myMes.AddMonths(1)
        dtMes.SelectionStart = myMes
        '
        If Year(myMes) = Year(Now) AndAlso Month(myMes) = Month(Now) Then
            btnPeriodoPosterior.Enabled = False
        Else
            btnPeriodoPosterior.Enabled = True
        End If
        '
    End Sub
    '
    Private Sub btnMesAtual_Click(sender As Object, e As EventArgs) Handles btnMesAtual.Click
        myMes = Now
        dtMes.SelectionStart = myMes
        btnPeriodoPosterior.Enabled = False
    End Sub
    '
    Private Sub dtMes_DateChanged(sender As Object, e As DateRangeEventArgs)
        '
        If CDate(e.Start.ToShortDateString) <= CDate(Today.ToShortDateString) Then
            myMes = e.Start
            lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
            FormataListagem()
        Else
            MessageBox.Show("Escolha um mês anterior ou igual ao mês atual...",
                "Período", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtMes.SelectionStart = Now
            myMes = Now
        End If
        '
    End Sub
    '
    Private Sub chkPeriodoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodoTodos.CheckedChanged
        If chkPeriodoTodos.Checked = False Then
            btnPeriodoAnterior.Enabled = True
            btnPeriodoPosterior.Enabled = True
            btnMesAtual.Enabled = True
            lblPeriodo.Visible = True
        Else
            btnPeriodoAnterior.Enabled = False
            btnPeriodoPosterior.Enabled = False
            btnMesAtual.Enabled = False
            lblPeriodo.Visible = False
        End If
        '
        FormataListagem()
        '
    End Sub
    '
    Private Sub lblPerido_Click(sender As Object, e As EventArgs) Handles lblPeriodo.Click
        pnlMes.Visible = True
        dtMes.Focus()
    End Sub
    '
    Private Sub pnlMes_Leave(sender As Object, e As EventArgs) Handles pnlMes.MouseLeave, dtMes.LostFocus
        pnlMes.Visible = False
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"

    '
    '--- COR PAINEL DO DATAGRID
    '----------------------------------------------------------------------------------
    Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlVenda.Paint
        '
        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)
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
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub Me_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class
