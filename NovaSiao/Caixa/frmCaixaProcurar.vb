Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmCaixaProcurar
    Private cxLista As New List(Of clCaixa)
    Private _myMes As Date
    Private _Sit As EnumFlagEstado
    '
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
            '
            Get_Dados()
            '
        End Set
    End Property
    '
    Sub New()
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
        Dim cxBLL As New CaixaBLL
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                cxLista = cxBLL.GetCaixaLista_Procura(propIDConta)
            Else
                Dim f As New Utilidades
                Dim dtInicial As Date = f.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = f.LastDayOfMonth(myMes)
                '
                cxLista = cxBLL.GetCaixaLista_Procura(propIDConta, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = cxLista
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu exceção ao obter a lista de Caixas..." & vbNewLine &
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
        ' (0) COLUNA FILIAL
        dgvListagem.Columns.Add("clnFilial", "Filial")
        With dgvListagem.Columns("clnFilial")
            .DataPropertyName = "ApelidoFilial"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (1) COLUNA CONTA
        dgvListagem.Columns.Add("clnConta", "Conta")
        With dgvListagem.Columns("clnConta")
            .DataPropertyName = "Conta"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (2) COLUNA DT INICIAL
        dgvListagem.Columns.Add("clnDataInicial", "DataInicial")
        With dgvListagem.Columns("clnDataInicial")
            .DataPropertyName = "DataInicial"
            .Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA DT FINAL
        dgvListagem.Columns.Add("clnDataFinal", "DataFinal")
        With dgvListagem.Columns("clnDataFinal")
            .DataPropertyName = "DataFinal"
            .Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA SALDO ANTERIOR
        dgvListagem.Columns.Add("clnSaldoAnterior", "Sd. Anterior")
        With dgvListagem.Columns("clnSaldoAnterior")
            .DataPropertyName = "SaldoAnterior"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (5) COLUNA SALDO FINAL
        dgvListagem.Columns.Add("clnSaldoFinal", "Sd. Final")
        With dgvListagem.Columns("clnSaldoFinal")
            .DataPropertyName = "SaldoFinal"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (6) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("clnSituacao", "Situacao")
        With dgvListagem.Columns("clnSituacao")
            .DataPropertyName = "Situacao"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click

        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum Caixa selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim clCx As clCaixa = dgvListagem.SelectedRows(0).DataBoundItem
        '
        Dim cBLL As New CaixaBLL
        '
        Dim frm = New frmCaixa(clCx)
        frm.MdiParent = frmPrincipal
        frm.StartPosition = FormStartPosition.CenterScreen
        Close()
        frm.Show()
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnAbrir_Click(New Object, New EventArgs)
    End Sub
    '
    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, _IDFilial, _IDConta)
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.Cancel Then
            propIDConta = Nothing
        Else
            '
            txtConta.Text = frmConta.propConta_Escolha.Conta
            propIDConta = frmConta.propConta_Escolha.IDConta
            '
        End If
    End Sub
    '
    Private Sub btnInserirNovo_Click(sender As Object, e As EventArgs) Handles btnInserirNovo.Click
        Dim frmN As New frmCaixaInserir(Me)
        frmN.ShowDialog()
        '
        If frmN.DialogResult = DialogResult.OK Then
            Close()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLES GERAIS | FLUXO"
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnAbrir_Click(New Object, New EventArgs)
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
#End Region
    '
#Region "CONTROLE DO PERÍODO"
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
#Region "TRATAMENTO VISUAL"
    '
    Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlVenda.Paint
        '
        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
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
End Class
