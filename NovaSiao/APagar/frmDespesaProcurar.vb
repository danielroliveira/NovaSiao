Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmDespesaProcurar
    Private despLista As New List(Of clDespesa)
    Private IDCredor As Integer?
    Private IDDespesaTipo As Integer?
    Private ImgVndAtivo As Image = My.Resources.accept
    Private ImgVndLock As Image = My.Resources.lock
    Private _myMes As Date
    Private _Sit As EnumFlagEstado
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
    Public Property Sit() As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(ByVal value As EnumFlagEstado)
            _Sit = value
            '
            If value = EnumFlagEstado.Alterado Then
                btnProcurar.Enabled = True
                dgvListagem.Columns.Clear()
            ElseIf value = enumFlagEstado.RegistroSalvo Then
                btnProcurar.Enabled = False
            End If
            '
        End Set
    End Property
    '
#Region "EVENTO LOAD"
    '
    Private Sub frmDespesaProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        myMes = ObterDefault("DataPadrao")
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        FormataListagem()
        '
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
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
        Dim despBLL As New DespesaBLL
        '--- consulta o banco de dados
        Try
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                despLista = despBLL.GetDespesaLista_Procura(IDDespesaTipo, IDCredor, txtDescricao.Text)
            Else
                Dim dtInicial As Date = Utilidades.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = Utilidades.LastDayOfMonth(myMes)
                '
                despLista = despBLL.GetDespesaLista_Procura(IDDespesaTipo, IDCredor, txtDescricao.Text, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = despLista
            '
            Sit = EnumFlagEstado.RegistroSalvo
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu exceção ao obter a lista de Despesas..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub PreencheListagem()
        '
        ' (1) COLUNA DESPESADATA
        dgvListagem.Columns.Add("clnDespesaData", "Data")
        With dgvListagem.Columns("clnDespesaData")
            .DataPropertyName = "DespesaData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (2) COLUNA CREDOR
        dgvListagem.Columns.Add("clnCadastro", "Credor")
        With dgvListagem.Columns("clnCadastro")
            .DataPropertyName = "Cadastro"
            .Width = 300
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA DESPESA TIPO
        dgvListagem.Columns.Add("clnDespesaTipo", "Tipo de Despesa")
        With dgvListagem.Columns("clnDespesaTipo")
            .DataPropertyName = "DespesaTipo"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA DESCRICAO
        dgvListagem.Columns.Add("clnDescricao", "Descricao")
        With dgvListagem.Columns("clnDescricao")
            .DataPropertyName = "Descricao"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (5) COLUNA VALOR
        dgvListagem.Columns.Add("clnDespesaValor", "Valor")
        With dgvListagem.Columns("clnDespesaValor")
            .DataPropertyName = "DespesaValor"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (6) COLUNA IMAGEM SITUACAO
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .HeaderText = "Situação"
            .Resizable = False
            .Width = 50
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (7) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("clnBloqueada", "Bloqueada")
        With dgvListagem.Columns("clnBloqueada")
            .DataPropertyName = "Bloqueada"
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
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        '--- altera a imagem da coluna 5
        If e.ColumnIndex = 5 Then '--- coluna Imagem Situação
            Dim cl As clDespesa = dgvListagem.Rows(e.RowIndex).DataBoundItem
            '
            Select Case cl.Bloqueada
                Case True
                    dgvListagem.Rows(e.RowIndex).Cells(5).Value = ImgVndLock
                Case False
                    dgvListagem.Rows(e.RowIndex).Cells(5).Value = ImgVndAtivo
            End Select
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        Get_Dados()
        PreencheListagem()
        dgvListagem.Focus()
        '
        If despLista.Count = 0 Then
            MessageBox.Show("Nenhuma despesa encontrada nessas condições...", "Procurar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
    End Sub
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhuma Despesa selecionada na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim clD As clDespesa = dgvListagem.SelectedRows(0).DataBoundItem
        '
        '--- Verifica se o form Despesa ja esta aberto
        Dim frm As Form = Nothing
        '
        For Each f As Form In Application.OpenForms
            If f.Name = "frmDespesa" Then
                frm = f
            End If
        Next
        '
        If IsNothing(frm) Then '--- o frmDespesa não esta aberto
            frm = New frmDespesa(clD)
            frm.MdiParent = frmPrincipal
            frm.StartPosition = FormStartPosition.CenterScreen
            Close()
            frm.Show()
        Else '--- o frmDespesa já esta aberto
            DirectCast(frm, frmDespesa).propDespesa = clD
            frm.Focus()
            Close()
        End If
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnEditar_Click(New Object, New EventArgs)
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
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEditar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescricao.KeyDown,
        txtDespesaTipo.KeyDown, txtCredor.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            'PreencheListagem()
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '
    Private Sub btnCredor_Click(sender As Object, e As EventArgs) Handles btnCredor.Click
        Dim frmC As New frmCredorProcurar(True, Me)
        Dim oldID As Integer? = IDCredor
        '
        frmC.ShowDialog()
        '
        If frmC.DialogResult = DialogResult.Cancel Then
            txtCredor.Clear()
            IDCredor = Nothing
        Else
            Dim Cred As clCredor = frmC.propCredorEscolhido
            '
            txtCredor.Text = Cred.Cadastro
            IDCredor = Cred.IDPessoa
        End If
        '
        If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(IDCredor), 0, IDCredor) Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        txtCredor.Focus()
        '
    End Sub

    Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        Dim frmT As New frmDespesaTipoProcurar(True, Me)
        Dim oldID As Integer? = IDDespesaTipo
        '
        frmT.ShowDialog()
        If frmT.DialogResult = DialogResult.Cancel Then
            txtDespesaTipo.Clear()
            IDDespesaTipo = Nothing
        Else
            Dim T As clDespesaTipo = frmT.propDespesaEscolhida
            '
            txtDespesaTipo.Text = T.DespesaTipo
            IDDespesaTipo = T.IDDespesaTipo
        End If
        '
        If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(IDDespesaTipo), 0, IDDespesaTipo) Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        txtDespesaTipo.Focus()
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
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCredor.KeyDown, txtDespesaTipo.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtCredor"
                    btnCredor_Click(New Object, New EventArgs)
                Case "txtDespesaTipo"
                    btnTipo_Click(New Object, New EventArgs)
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtCredor"
                    If Not IsNothing(IDCredor) Then Sit = EnumFlagEstado.Alterado
                    txtCredor.Clear()
                    IDCredor = Nothing
                Case "txtDespesaTipo"
                    If Not IsNothing(IDDespesaTipo) Then Sit = EnumFlagEstado.Alterado
                    txtDespesaTipo.Clear()
                    IDDespesaTipo = Nothing
            End Select
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    Private Sub txtDescricao_TextChanged(sender As Object, e As EventArgs) Handles txtDescricao.TextChanged
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
    End Sub
    '
    Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
        '--- Verifica se o form Despesa ja esta aberto
        Dim frm As Form = Nothing
        Dim clD As New clDespesa
        '
        For Each f As Form In Application.OpenForms
            If f.Name = "frmDespesa" Then
                frm = f
            End If
        Next
        '
        If IsNothing(frm) Then '--- o frmDespesa não esta aberto
            '
            frm = New frmDespesa(clD)
            frm.MdiParent = frmPrincipal
            frm.StartPosition = FormStartPosition.CenterScreen
            Close()
            frm.Show()
        Else '--- o frmDespesa já esta aberto
            Close()
            DirectCast(frm, frmDespesa).propDespesa = clD
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
    Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlVenda.Paint
        '
        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)
        '
    End Sub

#End Region
    '
End Class
