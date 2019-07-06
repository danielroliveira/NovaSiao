Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmFreteProcurar
    Private freteLista As New List(Of clFrete)
    Private IDTransportadora As Integer?
    Private ImgVndAtivo As Image = My.Resources.accept
    Private ImgVndLock As Image = My.Resources.lock
    Private _myMes As Date
    Private IDFilial As Integer
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
#Region "EVENTO LOAD"
    '
    Private Sub frmFreteProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        rbtCobradas.Checked = False
        IDFilial = If(Obter_FilialPadrao(), 0)
        '
        myMes = ObterDefault("DataPadrao")
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        FormataListagem()
        '
        pnlMes.Location = New Point(234, 166)
        '
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
        AddHandler rbtCobradas.CheckedChanged, AddressOf rbtEmAberto_CheckedChanged
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM CONFIGURAÇÃO"
    '
    Private Sub FormataListagem()
        '
        '--- limpa as colunas do datagrid
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
        Dim freteBLL As New FreteBLL
        Dim cobradas As Boolean = rbtCobradas.Checked
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                freteLista = freteBLL.GetAPagarLista_Procura(IDFilial, cobradas, IDTransportadora)
            Else
                Dim f As New Utilidades
                Dim dtInicial As Date = f.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = f.LastDayOfMonth(myMes)
                '
                freteLista = freteBLL.GetAPagarLista_Procura(IDFilial, cobradas, IDTransportadora, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = freteLista
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu exceção ao obter a lista de Fretes..." & vbNewLine &
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
        '--- CLEAR COLUMNS
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUMN SELECT
        With clnSelect
            .ReadOnly = False
        End With
        '
        ' (1) COLUNA FRETEDATA
        With clnFreteData
            .DataPropertyName = "TransacaoData"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (2) COLUNA TRANSPORTADORA
        With clnTransportadora
            .DataPropertyName = "Transportadora"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA OPERACAO
        With clnOperacao
            .DataPropertyName = "Operacao"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (4) COLUNA CONHECIMENTO
        With clnConhecimento
            .DataPropertyName = "Conhecimento"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (5) COLUNA CONHECIMENTODATA
        With clnConhecimentoData
            .DataPropertyName = "ConhecimentoData"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (7) COLUNA VALOR
        With clnFreteValor
            .DataPropertyName = "FreteValor"
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "C"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        '--- ADD COLUMNS
        dgvListagem.Columns.AddRange({clnSelect,
                                     clnFreteData,
                                     clnTransportadora,
                                     clnOperacao,
                                     clnConhecimento,
                                     clnConhecimentoData,
                                     clnFreteValor})
        '
    End Sub
    '
    Private Sub rbtEmAberto_CheckedChanged(sender As Object, e As EventArgs)
        '
        btnDespesa.Enabled = rbtEmAberto.Checked
        btnEditar.Enabled = rbtEmAberto.Checked
        Get_Dados()
        '
    End Sub
    '
    Private Sub dgvListagem_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellValueChanged
        '
        If e.ColumnIndex = 0 Then
            Dim selFretes As New List(Of clFrete)
            '
            For Each row As DataGridViewRow In dgvListagem.Rows
                If row.Cells(0).Value = True Then
                    selFretes.Add(row.DataBoundItem)
                End If
            Next
            '
            Dim total As Decimal = selFretes.Sum(Function(x) x.FreteValor)
            '
            If total > 0 Then
                lblValorSelecionado.Visible = True
                lblValorSelecionado.Text = "Total Selecionado: " & Format(total, "C")
            Else
                lblValorSelecionado.Visible = False
                lblValorSelecionado.Text = "Total Selecionado: " & Format(0, "C")
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub dgvListagem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellContentClick
        '
        If e.ColumnIndex = 0 Then
            dgvListagem.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum Frete selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim clF As clFrete = dgvListagem.SelectedRows(0).DataBoundItem
        '
        Dim frm = New frmFrete(clF)
        frm.ShowDialog()
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        '
        If rbtCobradas.Checked Then Exit Sub '--- do not allow change fretes cobrados
        btnEditar_Click(New Object, New EventArgs)
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        '
        Close()
        If Application.OpenForms.Count = 1 Then MostraMenuPrincipal()
        '
    End Sub
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            If rbtCobradas.Checked Then Exit Sub '--- do not allow change fretes cobrados
            btnEditar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransportadora.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            'PreencheListagem()
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    Private Sub btnTransportadora_Click(sender As Object, e As EventArgs) Handles btnTransportadora.Click
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        Dim frmT As New frmTransportadoraProcurar(True, Me)
        Dim oldID As Integer? = IDTransportadora
        '
        frmT.ShowDialog()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        If frmT.DialogResult = DialogResult.Cancel Then
            txtTransportadora.Clear()
            IDTransportadora = Nothing
        Else
            Dim Transp As clTransportadora = frmT.propTransportadora_Escolha
            '
            txtTransportadora.Text = Transp.Cadastro
            IDTransportadora = Transp.IDPessoa
        End If
        '
        If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(IDTransportadora), 0, IDTransportadora) Then
            Get_Dados()
        End If
        '
        txtTransportadora.Focus()
        '
    End Sub
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub frmDespesa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "+" Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransportadora.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtTransportadora"
                    btnTransportadora_Click(New Object, New EventArgs)
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            Dim oldID As Integer? = IDTransportadora
            e.Handled = True
            Select Case ctr.Name
                Case "txtTransportadora"
                    txtTransportadora.Clear()
                    IDTransportadora = Nothing
                    If Not IsNothing(oldID) Then Get_Dados()
            End Select
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    Private Sub btnDespesa_Click(sender As Object, e As EventArgs) Handles btnDespesa.Click
        '
        '--- check number of items datagrid
        '--------------------------------------------------------------------------------------
        If dgvListagem.Rows.Count = 0 Then
            AbrirDialog("Não foi selecionado nenhum Frete para gerar cobrança... ",
                        "Gerar Cobrança",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Exclamation)
            Exit Sub
        End If
        '
        '--- count selected fretes and check same IDTransportadora
        '--------------------------------------------------------------------------------------
        Dim selFretes As New List(Of clFrete)
        Dim IDTransp As Integer? = Nothing
        '
        For Each row As DataGridViewRow In dgvListagem.Rows
            '
            If row.Cells(0).Value = True Then
                Dim frete As clFrete = row.DataBoundItem
                '
                If Not IsNothing(IDTransp) Then
                    If IDTransp <> frete.IDTransportadora Then
                        AbrirDialog("Todos os fretes selecionados devem ser da mesma transportadora...",
                                    "Gerar Cobrança",
                                    frmDialog.DialogType.OK,
                                    frmDialog.DialogIcon.Exclamation)
                        selFretes.Clear()
                        Exit Sub
                    End If
                End If
                '
                IDTransp = frete.IDTransportadora
                selFretes.Add(row.DataBoundItem)
                '
            End If
            '
        Next
        '
        '--- check total value
        '--------------------------------------------------------------------------------------
        Dim selValor As Decimal = selFretes.Sum(Function(x) x.FreteValor)
        '
        If selValor = 0 Then
            AbrirDialog("Não existe valor ou Não foi selecionado nenhum Frete para gerar cobrança... ",
                        "Gerar Cobrança",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Exclamation)
            Exit Sub
        End If
        '
        '--- check same IDTransportadora
        '--------------------------------------------------------------------------------------
        Dim pag As New clAPagar With {
            .APagarValor = selValor,
            .IDFilial = IDFilial,
            .IDPessoa = IDTransp,
            .Vencimento = Today,
            .Origem = 5 '-- tblFreteDespesa    
        }
        '
        '--- Create Despesa
        '--------------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmPag As New frmFreteAPagar(Me, selValor, Today, pag, EnumFlagAcao.INSERIR)
            frmPag.ShowDialog()
            '
            If frmPag.DialogResult <> DialogResult.OK Then Exit Sub
            '
            Dim freteBLL As New FreteBLL
            freteBLL.FreteDespesaCreate(selFretes, pag)
            Get_Dados()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir formulário de Cobrança..." & vbNewLine &
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
    Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlVenda.Paint
        '
        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)
        '
    End Sub
    '
#End Region
    '
End Class
