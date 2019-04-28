Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmTrocaProcurar
    '
    Private tBLL As New TrocaBLL
    Private trcLista As List(Of clTroca)
    Private ImgAtivo As Image = My.Resources.accept
    Private ImgInativo As Image = My.Resources.block
    Private ImgBloq As Image = My.Resources.lock
    Private _myMes As Date
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
#Region "EVENTO LOAD"
    '
    Private Sub frmTrocaProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        myMes = ObterDefault("DataPadrao")
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        GetTrocaList()
        PreencheListagem()
        '
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
        '
    End Sub
    '
    Private Sub GetTrocaList()
        '
        '--- consulta o banco de dados
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                trcLista = tBLL.GetTrocaLista_Procura()
            Else
                Dim f As New FuncoesUtilitarias
                Dim dtInicial As Date = f.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = f.LastDayOfMonth(myMes)
                '
                trcLista = tBLL.GetTrocaLista_Procura(dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = trcLista
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a lista de Trocas..." & vbNewLine &
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
#Region "LISTAGEM CONFIGURAÇÃO"
    '
    Private Sub PreencheListagem()
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
        PreencheListagem_Venda()
        '
    End Sub
    '
    Private Sub PreencheListagem_Venda()
        '
        ' (1) COLUNA REG
        dgvListagem.Columns.Add("IDTroca", "Reg.")
        With dgvListagem.Columns("IDTroca")
            .DataPropertyName = "IDTroca"
            .Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (2) COLUNA DATAVENDA
        dgvListagem.Columns.Add("TrocaData", "Data")
        With dgvListagem.Columns("TrocaData")
            .DataPropertyName = "TrocaData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (3) COLUNA NOME
        dgvListagem.Columns.Add("CadastroNome", "Nome / Razão Social")
        With dgvListagem.Columns("CadastroNome")
            .DataPropertyName = "PessoaTroca"
            .Width = 300
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA VENDEDOR
        dgvListagem.Columns.Add("Apelido", "Vendedor")
        With dgvListagem.Columns("Apelido")
            .DataPropertyName = "ApelidoVenda"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (5) COLUNA VALOR
        dgvListagem.Columns.Add("ValorTotal", "Valor")
        With dgvListagem.Columns("ValorTotal")
            .DataPropertyName = "ValorTotal"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (6) COLUNA IDVENDA
        dgvListagem.Columns.Add("Venda", "Venda")
        With dgvListagem.Columns("Venda")
            .DataPropertyName = "IDVenda"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (7) COLUNA IMAGEM SITUACAO
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .HeaderText = "Situação"
            .Resizable = False
            .Width = 50
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (8) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("Situacao", "Situação")
        With dgvListagem.Columns("Situacao")
            .DataPropertyName = "IDSituacao"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
    End Sub
    '
    Private Sub Handler_GetList(sender As Object, e As EventArgs)
        '
        GetTrocaList()
        '
    End Sub
    '
    '--- FILTAR LISTAGEM PELO IDTIPO E _IDFilial, TXTPRODUTO, TXTNOME
    Private Sub FiltrarListagem()
        '
        dgvListagem.DataSource = trcLista.FindAll(AddressOf FindTroca)
        '
    End Sub
    '
    Private Function FindTroca(ByVal t As clTroca) As Boolean
        '
        If (t.PessoaTroca.ToLower Like "*" & txtProcura.Text.ToLower & "*") Then
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
        If e.ColumnIndex = 5 Then
            e.Value = Format(e.Value, "0000")
        End If
        '
        '--- altera a imagem da coluna 5
        If e.ColumnIndex = 6 Then '--- coluna Imagem Situação
            Dim sit As Integer = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clTroca).IDSituacao
            '
            Select Case sit
                Case 1
                    dgvListagem.Rows(e.RowIndex).Cells(6).Value = ImgInativo
                Case 2
                    dgvListagem.Rows(e.RowIndex).Cells(6).Value = ImgAtivo
                Case 3
                    dgvListagem.Rows(e.RowIndex).Cells(6).Value = ImgBloq
            End Select
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
            MessageBox.Show("Selecione um Operação de TROCA antes de pressionar ESCOLHER...",
                            "Escolher Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Focus()
            Exit Sub
        End If
        '
        '--- ABRE A TROCA E FECHA O FORM
        Dim trc As clTroca = dgvListagem.SelectedRows(0).DataBoundItem
        '
        Dim vndBLL As New VendaBLL
        Dim _vnd As clVenda = vndBLL.GetVenda_PorID_OBJ(trc.IDVenda)
        '
        If _vnd.CobrancaTipo = 1 Then ' VENDA À VISTA
            Dim frm As New frmVendaVista(_vnd) With {
                .MdiParent = frmPrincipal,
                .StartPosition = FormStartPosition.CenterScreen}
            Close()
            frm.Show()
        ElseIf _vnd.CobrancaTipo = 2 Then ' VENDA PARCELADA
            Dim frm As New frmVendaPrazo(_vnd) With {
                .MdiParent = frmPrincipal,
                .StartPosition = FormStartPosition.CenterScreen}
            Close()
            frm.Show()
        End If
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
            GetTrocaList()
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
        GetTrocaList()
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
