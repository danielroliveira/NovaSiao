Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmEstoqueAjusteProcurar
    '
    Private eBLL As New EstoqueAjusteBLL
    Private ItensList As List(Of clEstoqueAjusteItem)
    Private _IDFilial As Integer
    Private _myMes As Date
    '
#Region "PROPERTIES"
    '
    Private Property myMes() As DateTime
        '
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
        '
    End Property
    '
#End Region '/ PROPERTIES
    '
#Region "EVENTO NEW LOAD"
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _IDFilial = Obter_FilialPadrao()
        myMes = Today
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        GetListItems()
        FormataDataGrid()
        '
    End Sub
    '
    Private Sub frmEstoqueAjusteProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        pnlMes.Location = New Point(510, 130)
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
        '
    End Sub
    '
    Private Sub GetListItems()
        '
        '--- consulta o banco de dados
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                ItensList = eBLL.GetItemsList_Procura(_IDFilial)
            Else
                Dim f As New FuncoesUtilitarias
                Dim dtInicial As Date = f.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = f.LastDayOfMonth(myMes)
                '
                ItensList = eBLL.GetItemsList_Procura(_IDFilial, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = ItensList
            CalculaValorTotal()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a Lista de Produtos Ajustados..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub CalculaValorTotal()
        '
        Dim T As Double = ItensList.Sum(Function(x) x.Total)
        '
        lblTotal.Text = Format(T, "c")
        '
        If T < 0 Then
            lblTotal.ForeColor = Color.Firebrick
        Else
            lblTotal.ForeColor = Color.DarkBlue
        End If
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM CONFIGURAÇÃO"
    '
    Private Sub FormataDataGrid()
        '
        ' altera as propriedades importantes
        dgvListagem.AutoGenerateColumns = False
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
        PreencheListagem()
        '
    End Sub
    '
    Private Sub PreencheListagem()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUNA ID
        With clnIDEstoqueItem
            .DataPropertyName = "IDEstoqueItem"
            .Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA DATA DO AJUSTE
        With clnAjusteData
            .DataPropertyName = "AjusteData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (2) COLUNA PRODUTO
        With clnProduto
            .DataPropertyName = "Produto"
            .Width = 400
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA QUANTIDADE
        With clnQuantidade
            .DataPropertyName = "Quantidade"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (4) COLUNA VALOR
        With clnTotal
            .DataPropertyName = "Total"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        dgvListagem.Columns.AddRange({clnIDEstoqueItem, clnAjusteData, clnProduto, clnQuantidade, clnTotal})
        '
    End Sub
    '
    '--- FILTAR LISTAGEM PELO IDTIPO E _IDFilial, TXTPRODUTO, TXTNOME
    Private Sub FiltrarListagem()
        '
        dgvListagem.DataSource = ItensList.FindAll(AddressOf FindItem)
        '
    End Sub
    '
    Private Function FindItem(ByVal i As clEstoqueAjusteItem) As Boolean
        '
        If (i.Produto.ToLower Like "*" & txtProcura.Text.ToLower & "*") Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtProcura.TextChanged
        '
        FiltrarListagem()
        '
    End Sub
    '
    '--- FORMATA O DATAGRID COM TEXTO E IMAGENS
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        If e.ColumnIndex = 0 Then
            e.Value = Format(e.Value, "0000")
        End If
        '
        '--- altera a coluna 3 (Quantidade)
        If e.ColumnIndex = 3 Then '--- coluna Movimentacao
            '
            If e.Value >= 0 Then
                e.Value = "+" & Format(e.Value, "00")
                e.CellStyle.ForeColor = Color.DarkBlue
                dgvListagem.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(219, 228, 240) 'Color.Azure
                dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
            Else
                e.Value = Format(e.Value, "00")
                e.CellStyle.ForeColor = Color.Red
                dgvListagem.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                dgvListagem.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Firebrick
            End If
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If dgvListagem.Rows.Count = 0 OrElse dgvListagem.SelectedRows.Count = 0 Then
            '
            MessageBox.Show("Selecione um Ajuste de Estoque antes de pressionar ESCOLHER...",
                            "Escolher Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Focus()
            Exit Sub
            '
        End If
        '
        '--- ABRE O AJUSTE E FECHA O FORM
        Dim item As clEstoqueAjusteItem = dgvListagem.SelectedRows(0).DataBoundItem
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim ajuste As clEstoqueAjuste = eBLL.GetAjustePeloID(item.IDEstoqueAjuste)
            '
            Dim frm As New frmEstoqueAjuste(ajuste) With {
            .MdiParent = frmPrincipal,
            .StartPosition = FormStartPosition.CenterScreen}
            '
            frm.Show()
            Close()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter o Ajuste de Estoque..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub btnNovoAjuste_Click(sender As Object, e As EventArgs) Handles btnNovoAjuste.Click
        '
        '--- ABRE NOVO AJUSTE E FECHA O FORM
        '
        Dim frm As New frmEstoqueAjuste(New clEstoqueAjuste) With {
            .MdiParent = frmPrincipal,
            .StartPosition = FormStartPosition.CenterScreen}
        '
        frm.Show()
        Close()
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnEscolher_Click(New Object, New EventArgs)
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEscolher_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProcura.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
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
            GetListItems()
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
        '
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
        GetListItems()
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
