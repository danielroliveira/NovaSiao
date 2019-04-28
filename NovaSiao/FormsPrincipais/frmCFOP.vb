Imports CamadaBLL
Imports CamadaDTO

Public Class frmCFOP
    '
    ' VARIÁVEIS E PROPRIEDADES
    Dim Px, Py As Integer
    Dim Mover As Boolean
    Private _Sit As EnumFlagEstado
    '
#Region "LOAD"
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnCancelar.Text = "Fechar"
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnCancelar.Text = "Cancelar"
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                btnSalvar.Enabled = True
                btnCancelar.Text = "Sair"
            End If
        End Set
    End Property
    '
    ' EVENTO LOAD
    Private Sub frmCFOP_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        Sit = EnumFlagEstado.RegistroSalvo
        PreencheOperacoesCFOP()
        '
    End Sub
    '
#End Region
    '
#Region "DATAGRID OPERACOES"
    '
    ' PREENCHER DATAGRIDVIEW OPERACOES
    '-----------------------------------------------------------------------------------------------
    Private Sub PreencheOperacoesCFOP()
        Dim SQL As New SQLControl
        Dim dtOp As New DataTable
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            SQL.ExecQuery("SELECT * FROM tblOperacao ORDER BY MovimentoEstoque")
            dtOp = SQL.DBDT
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter lista de Operações..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        dgvOperacao.DataSource = dtOp
        FormataListagem()
        '
    End Sub
    '
    Private Sub FormataListagem()
        '
        With dgvOperacao
            ' limpa as colunas do datagrid
            .Columns.Clear()
            .AutoGenerateColumns = False
            ' altera as propriedades importantes
            .MultiSelect = False
            .ColumnHeadersVisible = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .StandardTab = True
            .RowHeadersVisible = False
        End With
        '
        ' (1) COLUNA ID
        dgvOperacao.Columns.Add("clnID", "ID")
        With dgvOperacao.Columns("clnID")
            .DataPropertyName = "IDOperacao"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA OPERACAO
        dgvOperacao.Columns.Add("clnOperacao", "Operação")
        With dgvOperacao.Columns("clnOperacao")
            .DataPropertyName = "Operacao"
            .Width = 220
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Font = New Font("Arial Narrow", 12)
            .DefaultCellStyle.BackColor = Color.Ivory
        End With
        '
        ' (3) COLUNA CFOP DENTRO
        dgvOperacao.Columns.Add("clnCFOPDentro", "Dentro")
        With dgvOperacao.Columns("clnCFOPDentro")
            .DataPropertyName = "CFOPDentro"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0,000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (3) COLUNA CFOP FORA
        dgvOperacao.Columns.Add("clnCFOPFora", "Fora")
        With dgvOperacao.Columns("clnCFOPFora")
            .DataPropertyName = "CFOPFora"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0,000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
        '
        ' (2) COLUNA DESCRIÇÃO
        dgvOperacao.Columns.Add("clnDescricao", "Descrição")
        With dgvOperacao.Columns("clnDescricao")
            .DataPropertyName = "Descricao"
            .Width = 300
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
    End Sub
    '
#End Region
    '
#Region "SALVAR DADOS"
    '
    ' SALVAR OS DADOS NO CONFIG
    '-----------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- Salva os registro de CFOP das operações
        If Salvar_CFOP() Then Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    Private Function Salvar_CFOP() As Boolean
        If dgvOperacao.Rows.Count = 0 Then Return True
        '
        Dim dt As DataTable = dgvOperacao.DataSource
        Dim tBLL As New TransacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            For Each r As DataRow In dt.Rows
                tBLL.SalvaOperacao_CFOP(r("IDOperacao"), r("CFOPDentro"), r("CFOPFora"))
            Next
            '
            Return True
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao salvar registros de Operações e CFOP no BD..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
            Return False
            '
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
#End Region
    '
#Region "MENU SUSPENSO CFOP"
    '
    '--- REVELA O MENU CFOP
    Private Sub dgvOperacao_MouseDown(sender As Control, e As MouseEventArgs) Handles dgvOperacao.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvOperacao.HitTest(e.X, e.Y)
            dgvOperacao.ClearSelection()

            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            If hit.ColumnIndex = 2 Or hit.ColumnIndex = 3 Then
                ' seleciona a CELL
                If hit.ColumnIndex = 2 Then
                    dgvOperacao.CurrentCell = dgvOperacao.Rows(hit.RowIndex).Cells(2)
                Else
                    dgvOperacao.CurrentCell = dgvOperacao.Rows(hit.RowIndex).Cells(3)
                End If
                '
                ' mostra o MENU
                menuCFOP.Show(c.PointToScreen(e.Location))
                '
            Else
                dgvOperacao.Rows(hit.RowIndex).Selected = True
            End If
        End If
    End Sub
    '
    '--- BTN PROCURAR MENUSTRIP
    Private Sub ProcurarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcurarToolStripMenuItem.Click
        Dim f As New frmCodigosFiscais
        '
        Me.Opacity = 0.6
        f.ShowDialog()
        Me.Opacity = 1

        If f.DialogResult = DialogResult.OK Then
            '
            For Each r As DataGridViewRow In dgvOperacao.Rows
                If Not IsDBNull(r.Cells("clnCFOPDentro").Value) AndAlso r.Cells("clnCFOPDentro").Value = f.Escolhido Then
                    MessageBox.Show("Esse CFOP já está associado a uma operação",
                                    "CFOP Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                '
                If Not IsDBNull(r.Cells("clnCFOPFora").Value) AndAlso r.Cells("clnCFOPFora").Value = f.Escolhido Then
                    MessageBox.Show("Esse CFOP já está associado a uma operação",
                                    "CFOP Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Next
            '
            '--- preenche com o valor escolhido
            dgvOperacao.CurrentCell.Value = f.Escolhido
            '
            Sit = EnumFlagEstado.Alterado
            '
        End If
        '
    End Sub
    '
    '--- BTN LIMPAR MENUSTRIP
    Private Sub LimparToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimparToolStripMenuItem.Click
        dgvOperacao.CurrentCell.Value = DBNull.Value
        '
        Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
#End Region
    '
#Region "BTN CANCELAR SAIR"
    '--------------------------------------------------------------------------------------------------------
    ' CANCELAR e SAIR
    '--------------------------------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        Me.Close()
        '
    End Sub
    '
#End Region
    '
#Region "MOVER FORM SEM BORDA"
    ' MOVER O FORMULÁRIO SEM BORDA
    '-----------------------------------------------------------------------------------------------
    Private Sub Painel_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lblTitulo.MouseDown
        '
        Px = Cursor.Position.X - Me.Left
        Py = Cursor.Position.Y - Me.Top + Screen.PrimaryScreen.WorkingArea.Height - frmPrincipal.ClientSize.Height + Panel1.Height - 25
        '
        Mover = True
        '
    End Sub
    Private Sub Painel_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lblTitulo.MouseUp
        Mover = False
    End Sub
    '
    Private Sub Painel_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lblTitulo.MouseMove
        If Mover = True Then
            Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - Px,
                                                     MousePosition.Y - Me.Location.Y - Py))
        End If
    End Sub
    '
#End Region
    '
End Class