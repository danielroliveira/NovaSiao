Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmDespesaPeriodicaProcurar
    Private despLista As New List(Of clDespesaPeriodica)
    Private IDCredor As Integer?
    Private IDDespesaTipo As Integer?
    Private Periodicidade As Byte?
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Private LiberaAtualizacao As Boolean = False
    Private _Sit As EnumFlagEstado
    '
#Region "NEW | PROPRIEDADES"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        propPeriodicidade = 2
        FormataListagem()
        '
        LiberaAtualizacao = True
        '
    End Sub
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
            ElseIf value = EnumFlagEstado.RegistroSalvo Then
                btnProcurar.Enabled = False
            End If
            '
        End Set
    End Property
    '
    Public Property propPeriodicidade() As Byte?
        Get
            Return Periodicidade
        End Get
        Set(ByVal value As Byte?)
            Periodicidade = value
            '
            Select Case value
                '--- seleciona o RADIO BUTON
                Case 1 '--- SEMANAL
                    rbtSemanal.Checked = True
                    rbtMensal.Checked = False
                    rbtAnual.Checked = False
                    rbtTodas.Checked = False
                    '
                Case 2 '--- MENSAL
                    rbtSemanal.Checked = False
                    rbtMensal.Checked = True
                    rbtAnual.Checked = False
                    rbtTodas.Checked = False
                    '
                Case 3 '--- ANUAL
                    rbtSemanal.Checked = False
                    rbtMensal.Checked = False
                    rbtAnual.Checked = True
                    rbtTodas.Checked = False
                    '
                Case Else
                    rbtSemanal.Checked = False
                    rbtMensal.Checked = False
                    rbtAnual.Checked = False
                    rbtTodas.Checked = True
                    '
            End Select
            '
            If LiberaAtualizacao = True Then
                Get_Dados()
            End If
            '
        End Set
        '
    End Property
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
        Dim despBLL As New DespesaPeriodicaBLL
        '--- consulta o banco de dados
        Try
            If Not IsNothing(Periodicidade) Then
                despLista = despBLL.GetDespesaPeriodicaLista_Procura(IDDespesaTipo, IDCredor, txtDescricao.Text, propPeriodicidade)
            Else
                despLista = despBLL.GetDespesaPeriodicaLista_Procura(IDDespesaTipo, IDCredor, txtDescricao.Text)
            End If
            '--- verifica o filtro das datas
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
        dgvListagem.Columns.Add("clnIniciarData", "Data do Início")
        With dgvListagem.Columns("clnIniciarData")
            .DataPropertyName = "IniciarData"
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
            .HeaderText = "Ativa"
            .Resizable = False
            .Width = 50
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (7) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("clnAtiva", "Ativa")
        With dgvListagem.Columns("clnAtiva")
            .DataPropertyName = "Ativa"
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
            Dim cl As clDespesaPeriodica = dgvListagem.Rows(e.RowIndex).DataBoundItem
            '
            Select Case cl.Ativa
                Case True
                    dgvListagem.Rows(e.RowIndex).Cells(5).Value = ImgAtivo
                Case False
                    dgvListagem.Rows(e.RowIndex).Cells(5).Value = ImgInativo
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
            MessageBox.Show("Nenhuma DESPESA PERIÓDICA encontrada nessas condições...", "Procurar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
    End Sub
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhuma DESPESA PERIÓDICA selecionada na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim clD As clDespesaPeriodica = dgvListagem.SelectedRows(0).DataBoundItem
        '
        '--- Verifica se o form Despesa ja esta aberto
        Dim frm As Form = Nothing
        '
        For Each f As Form In Application.OpenForms
            If f.Name = "frmDespesaPeriodica" Then
                frm = f
            End If
        Next
        '
        If IsNothing(frm) Then '--- o frmDespesa não esta aberto
            frm = New frmDespesaPeriodica(clD)
            frm.MdiParent = frmPrincipal
            frm.StartPosition = FormStartPosition.CenterScreen
            Close()
            frm.Show()
        Else '--- o frmDespesa já esta aberto
            DirectCast(frm, frmDespesaPeriodica).propDespesa = clD
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
        '
        '--- verifica se o frmDespesaPeriodica IS OPEN
        If Application.OpenForms.Count = 1 Then
            MostraMenuPrincipal()
        End If
        '
    End Sub
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
    Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
        '--- Verifica se o form Despesa ja esta aberto
        Dim frm As Form = Nothing
        Dim clD As New clDespesaPeriodica
        '
        For Each f As Form In Application.OpenForms
            If f.Name = "frmDespesaPeriodica" Then
                frm = f
            End If
        Next
        '
        If IsNothing(frm) Then '--- o frmDespesa não esta aberto
            '
            frm = New frmDespesaPeriodica(clD)
            frm.MdiParent = frmPrincipal
            frm.StartPosition = FormStartPosition.CenterScreen
            Close()
            frm.Show()
        Else '--- o frmDespesaPeriodica já esta aberto
            Close()
            DirectCast(frm, frmDespesaPeriodica).propDespesa = clD
        End If
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    Private Sub txtDescricao_TextChanged(sender As Object, e As EventArgs) Handles txtDescricao.TextChanged
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
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
        txtDespesaTipo.KeyDown, txtCredor.KeyDown,
        rbtAnual.KeyDown, rbtMensal.KeyDown, rbtSemanal.KeyDown, rbtTodas.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSemanal.CheckedChanged,
        rbtMensal.CheckedChanged, rbtAnual.CheckedChanged, rbtTodas.CheckedChanged
        '
        If rbtSemanal.Checked = True Then
            propPeriodicidade = 1
        ElseIf rbtMensal.Checked = True Then
            propPeriodicidade = 2
        ElseIf rbtAnual.Checked = True Then
            propPeriodicidade = 3
        ElseIf rbtTodas.Checked = True Then
            propPeriodicidade = Nothing
        End If
        '
    End Sub
    '
#End Region
    '
#Region "MENU SUSPENSO"
    '
    Private Sub dgvListagem_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvListagem.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvListagem.HitTest(e.X, e.Y)
            dgvListagem.ClearSelection()

            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub

            ' seleciona o ROW
            dgvListagem.CurrentCell = dgvListagem.Rows(hit.RowIndex).Cells(1)
            dgvListagem.Rows(hit.RowIndex).Selected = True

            ' mostra o MENU ativar e desativar
            If dgvListagem.Rows(hit.RowIndex).Cells("clnAtiva").Value = True Then
                miAtivar.Enabled = False
                miDesativar.Enabled = True
            Else
                miAtivar.Enabled = True
                miDesativar.Enabled = False
            End If
            ' revela menu
            mnuListagem.Show(c.PointToScreen(e.Location))
            '
        End If
    End Sub
    '
    Private Sub miAtivar_Click(sender As Object, e As EventArgs) Handles miAtivar.Click
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim clDesp As clDespesaPeriodica = dgvListagem.SelectedRows(0).DataBoundItem
        '
        '--- Executa a alteracao no BD
        Dim dBLL As New DespesaPeriodicaBLL
        '
        Try
            dBLL.DespesaPeriodica_Ativar(clDesp, True)
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma execeção ao Ativar a Despesa..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        '
        '--- Executa a alteraçao na listagem
        clDesp.Ativa = True
        dgvListagem.SelectedRows(0).Cells(5).Value = ImgAtivo
        '
    End Sub
    '
    Private Sub miDesativar_Click(sender As Object, e As EventArgs) Handles miDesativar.Click
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim clDesp As clDespesaPeriodica = dgvListagem.SelectedRows(0).DataBoundItem
        '
        '--- Executa a alteracao no BD
        Dim dBLL As New DespesaPeriodicaBLL
        '
        Try
            dBLL.DespesaPeriodica_Ativar(clDesp, False)
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma execeção ao Desativar a Despesa..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        '
        '--- Executa a alteraçao na listagem
        clDesp.Ativa = False
        dgvListagem.SelectedRows(0).Cells(5).Value = ImgInativo
        '
    End Sub
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
