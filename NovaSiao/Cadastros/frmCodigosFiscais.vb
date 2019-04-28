Imports CamadaBLL
'
Public Class frmCodigosFiscais
    Private dtCod As DataTable
    Private _CFOP As Integer
    Private EmEdicao As Integer? = Nothing
    Property Escolhido As Integer?
    Dim _Sit As Byte
    ' 
    Public Sub New(Optional myDefaultCFOP As Nullable(Of Integer) = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        If Not IsNothing(myDefaultCFOP) Then _CFOP = myDefaultCFOP
        '
        PreencheListagem()
        FormataListagem()
    End Sub
    '
    ' PROPRIEDADE SIT
    Private Property Sit As EnumFlagEstado
        Get
            Sit = _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            Select Case _Sit
                Case EnumFlagEstado.RegistroSalvo
                    btnSalvar.Enabled = False
                    btnFechar.Text = "&Fechar"
                    btnNovo.Enabled = True
                    btnEditar.Enabled = True
                    btnEscolher.Enabled = True
                    btnExcluir.Enabled = True
                    EmEdicao = Nothing
                Case EnumFlagEstado.Alterado
                    btnSalvar.Enabled = True
                    btnFechar.Text = "&Cancelar"
                    btnNovo.Enabled = False
                    btnEditar.Enabled = False
                    btnEscolher.Enabled = False
                    btnExcluir.Enabled = False
                Case EnumFlagEstado.NovoRegistro
                    btnSalvar.Enabled = True
                    btnFechar.Text = "&Cancelar"
                    btnNovo.Enabled = False
                    btnEditar.Enabled = False
                    btnEscolher.Enabled = False
                    btnExcluir.Enabled = False
            End Select
        End Set
    End Property
    '
    Private Sub PreencheListagem()
        Dim SQL As New SQLControl
        '
        SQL.ExecQuery("SELECT * FROM tblCodigoFiscal")
        '
        If SQL.HasException Then
            MessageBox.Show("Um erro ocorreu no Banco de Dados", "Erro de Banco de Dados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Exit Sub
        End If
        '
        If SQL.RecordCount = 0 Then
            MessageBox.Show("Não existe nenhum registro de CFOP Cadastrados...", "Sem Registro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Exit Sub
        End If
        '
        dtCod = SQL.DBDT
        '
    End Sub
    '
    Private Sub FormataListagem()
        '
        ' limpa as colunas do datagrid
        dgvCFOP.Columns.Clear()
        dgvCFOP.AutoGenerateColumns = False
        dgvCFOP.DataSource = dtCod
        ' altera as propriedades importantes
        dgvCFOP.MultiSelect = False
        dgvCFOP.ColumnHeadersVisible = True
        dgvCFOP.AllowUserToResizeRows = False
        dgvCFOP.AllowUserToResizeColumns = False
        dgvCFOP.RowTemplate.Height = 26
        dgvCFOP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvCFOP.StandardTab = True
        dgvCFOP.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        '
        ' (1) COLUNA CFOP
        dgvCFOP.Columns.Add("CFOP", "CFOP")
        With dgvCFOP.Columns("CFOP")
            .DataPropertyName = "CFOP"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0,000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA DESCRIÇÃO
        dgvCFOP.Columns.Add("CodigoFiscal", "Descrição")
        With dgvCFOP.Columns("CodigoFiscal")
            .DataPropertyName = "CodigoFiscal"
            .Width = 550
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
    End Sub
    '
    '--- FORMATA O CFOP
    Private Sub dgvCFOP_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCFOP.CellFormatting
        If e.ColumnIndex = 0 AndAlso Not IsDBNull(e.Value) Then
            e.Value = Format(CInt(e.Value), "#,###")
        End If
    End Sub
    '
    '--- FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        If btnFechar.Text = "&Fechar" Then
            DialogResult = DialogResult.Cancel
        Else
            If Sit = EnumFlagEstado.NovoRegistro Then
                For Each r As DataRow In dtCod.Rows
                    If r.RowState = DataRowState.Added Then
                        dtCod.Rows.Remove(r)
                        Exit For
                    End If
                Next
            ElseIf Sit = enumFlagEstado.Alterado Then
                dgvCFOP.CancelEdit()
                dtCod.RejectChanges()
                dgvCFOP.CurrentCell = dgvCFOP.Rows(0).Cells(0)
                If dgvCFOP.CurrentCell.IsInEditMode Then
                    dgvCFOP.CurrentCell = dgvCFOP.Rows(0).Cells(1)
                End If
                PreencheListagem()
                FormataListagem()
            End If
            Sit = EnumFlagEstado.RegistroSalvo
        End If
    End Sub
    '
    '--- EDITAR
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvCFOP.SelectedCells.Count = 0 Then
            MessageBox.Show("Selecione um CFOP antes de Editar", "Editar CFOP",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvCFOP.Focus()
        End If
        '
        dgvCFOP.BeginEdit(True)
        dtCod.Rows(dgvCFOP.CurrentCell.RowIndex).SetModified()
        Sit = EnumFlagEstado.Alterado
        EmEdicao = dgvCFOP.CurrentCell.RowIndex
        '
    End Sub
    '
    '--- ESCOLHER
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        '--- seleciona o ROW
        If dgvCFOP.Rows.Count > 0 Then
            dgvCFOP.Rows(dgvCFOP.CurrentCell.RowIndex).Selected = True
        End If
        '
        If dgvCFOP.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um CFOP antes de Escolher", "Selecione CFOP",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvCFOP.Focus()
            Exit Sub
        End If
        '
        Escolhido = CInt(dgvCFOP.SelectedRows(0).Cells(0).Value)
        DialogResult = DialogResult.OK
    End Sub
    '
    ' SELECIONAR QUANDO CLICA DUAS VEZES
    Private Sub dgvCFOP_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCFOP.CellDoubleClick
        If IsNothing(EmEdicao) Then
            btnEscolher_Click(New Object, New EventArgs)
        Else
            If e.RowIndex = EmEdicao Then
                dgvCFOP.BeginEdit(True)
            End If
        End If
    End Sub
    '
    '--- BTN ADICIONAR NOVO CFOP
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        dtCod.Rows.Add()
        dgvCFOP.CurrentCell = dgvCFOP.Rows(dgvCFOP.Rows.Count - 1).Cells(0)
        dgvCFOP.BeginEdit(True)
        EmEdicao = dgvCFOP.CurrentCell.RowIndex
        Sit = EnumFlagEstado.NovoRegistro
    End Sub
    '
    '--- QUANDO ENTRA NA ROW DE EDICAO PERMITE EDITAR
    Private Sub dgvCFOP_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCFOP.CellEnter
        If Not IsNothing(EmEdicao) And e.RowIndex = EmEdicao Then
            dgvCFOP.BeginEdit(True)
        End If
    End Sub

    Private Sub dgvCFOP_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvCFOP.DataError
        If e.ColumnIndex = 0 Then
            MessageBox.Show("Digite um valor numérico, que não seja maior que 9999", "Valor Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    '
#Region "SALVAR REGISTRO"
    '
    ' SALVAR O REGISTRO
    '-----------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        EmEdicao = Nothing
        dgvCFOP.EndEdit()
        '
        For Each r As DataGridViewRow In dgvCFOP.Rows
            '
            ' verfica se já existe valor igual
            '-----------------------------------------------------------------------------------------------
            If dtCod.Rows(r.Index).RowState <> DataRowState.Unchanged Then
                '
                '--- verifica se existe valores preenchidos
                '-------------------------------------------------------------------------------------------
                Dim newCFOP As Object = dgvCFOP.Rows(r.Index).Cells(0).Value
                Dim newDescricao As Object = dgvCFOP.Rows(r.Index).Cells(1).Value
                '
                If IsDBNull(newCFOP) OrElse Not IsNumeric(newCFOP) Then
                    MessageBox.Show("O número do CFOP alterado é inválido ou vazio...",
                                    "CFOP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgvCFOP.CurrentCell = dgvCFOP.Rows(r.Index).Cells(0)
                    EmEdicao = r.Index
                    Exit Sub
                End If
                '
                If IsDBNull(newDescricao) OrElse newDescricao.ToString.Trim.Length = 0 Then
                    MessageBox.Show("A DESCRIÇÃO do CFOP alterada é inválida ou vazia...",
                                    "Descrição Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgvCFOP.CurrentCell = dgvCFOP.Rows(r.Index).Cells(1)
                    EmEdicao = r.Index
                    Exit Sub
                End If
                '
                '--- verifica se o numero CFOP ja existe
                '-------------------------------------------------------------------------------------------
                If VerificaDuplicado(r.Index, newCFOP, dtCod) = True Then
                    MessageBox.Show("Já existe um CFOP com o mesmo número:" & vbNewLine &
                                    CStr(newCFOP).ToUpper,
                                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgvCFOP.CurrentCell = dgvCFOP.Rows(r.Index).Cells(0)
                    EmEdicao = r.Index
                    Exit Sub
                End If
                '
                '--- verifica se a Descricao do CFOP ja existe
                '-------------------------------------------------------------------------------------------
                If VerificaDuplicado(r.Index, newDescricao, dtCod) = True Then
                    MessageBox.Show("Já existe um CFOP com a mesma descrição:" & vbNewLine &
                                    CStr(newDescricao).ToUpper,
                                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgvCFOP.CurrentCell = dgvCFOP.Rows(r.Index).Cells(1)
                    EmEdicao = r.Index
                    Exit Sub
                End If
                '
                '---salva os registros
                '-----------------------------------------------------------------------------------------------
                Dim SQL As New SQLControl
                Dim SQLString As String = ""
                '
                If dtCod.Rows(r.Index).RowState = DataRowState.Modified Then ' registro ALTERADO
                    SQLString = String.Format("UPDATE tblCodigoFiscal SET CFOP = {0}, CodigoFiscal = '{1}' WHERE CFOP = {0}",
                                              Convert.ToInt16(newCFOP), newDescricao.ToString)
                ElseIf dtCod.Rows(r.Index).RowState = DataRowState.Added Then ' registro NOVO
                    SQLString = String.Format("INSERT INTO tblCodigoFiscal (CFOP, CodigoFiscal) VALUES ({0}, '{1}')",
                                              Convert.ToInt16(newCFOP), newDescricao.ToString)
                End If
                '
                SQL.ExecQuery(SQLString)
                '
                '---veridica se houve erro e emite mensagem de sucesso
                If Not SQL.HasException(True) Then
                    '--- mensagem de sucesso---
                    If SQLString.Substring(0, 6) = "UPDATE" Then
                        MessageBox.Show("Sucesso ao alterar registro(s) de CFOP", "Registro Alterado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf SQLString.Substring(0, 6) = "INSERT" Then
                        MessageBox.Show("Sucesso ao salvar novo registro(s) de CFOP", "Registro Salvo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    '
                    '---preencher a listagem com os novos valores
                    PreencheListagem()
                    Sit = EnumFlagEstado.RegistroSalvo
                    FormataListagem()
                Else
                    MessageBox.Show("Ocorreu um erro ao salvar o registro..." & vbNewLine &
                    CStr(dgvCFOP.Rows(r.Index).Cells(1).Value).ToUpper, "Erro ao Salvar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    EmEdicao = r.Index
                End If
            End If
        Next
    End Sub
    '
    '
    ' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
    Public Function VerificaDuplicado(myRow As Integer, myNewValor As String, myTable As DataTable) As Boolean
        '
        '---se não houver nenhum registro, Exit
        If myTable.Rows.Count = 0 Then
            VerificaDuplicado = False
            Exit Function
        End If
        '
        '---verifica todos os ROWS procurando registro igual
        For i = 0 To myTable.Rows.Count - 1
            '
            If i = myRow Then Continue For '---se for a mesma ROW não verifica
            '
            Dim r As DataRow = myTable.Rows(i)
            '
            For Each c As DataColumn In myTable.Columns
                If myTable.Rows(i).Item(c.ColumnName).ToString.ToUpper = myNewValor.ToString.ToUpper Then
                    VerificaDuplicado = True
                    Exit Function
                End If
            Next c
        Next i
        '
        '---se não encontrar retorna FALSE
        VerificaDuplicado = False
    End Function
    '
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        '--- Verificar e Selecionar o ROW
        If dgvCFOP.Rows.Count > 0 Then
            dgvCFOP.Rows(dgvCFOP.CurrentCell.RowIndex).Selected = True
        End If
        '
        If dgvCFOP.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um CFOP para Excluir", "Selecione CFOP",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvCFOP.Focus()
            Exit Sub
        End If
        '
        '--- Perguntar ao usuario
        If MessageBox.Show("Você deseja definitivamente EXCLUIR o registro de CFOP?" & vbNewLine &
                           dgvCFOP.SelectedRows(0).Cells(1).Value.ToString.ToUpper, "Excluir CFOP",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- Verificar se o CFOP esta sendo usado em alguma Operacao
        Dim T As New TransacaoBLL
        Dim dtT As DataTable = T.Get_Operacao_DT
        '
        For Each r As DataRow In dtT.Rows
            If Not IsDBNull(r("CFOPDentro")) AndAlso r("CFOPDentro") = dgvCFOP.SelectedRows(0).Cells(0).Value Then
                MessageBox.Show("Não é possível EXCLUIR esse CFOP pois está associado a uma OPERAÇÃO:" & vbNewLine &
                                r("Operacao"), "CFOP Associado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            If Not IsDBNull(r("CFOPFora")) AndAlso r("CFOPFora") = dgvCFOP.SelectedRows(0).Cells(0).Value Then
                MessageBox.Show("Não é possível EXCLUIR esse CFOP pois está associado a uma OPERAÇÃO:" & vbNewLine &
                                r("Operacao"), "CFOP Associado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        '
        '--- Excluir
        Dim SQL As New SQLControl
        Dim strSQL As String = String.Format("DELETE FROM tblCodigoFiscal WHERE CFOP = {0}",
                                             dgvCFOP.SelectedRows(0).Cells(0).Value)
        '
        SQL.ExecQuery(strSQL)
        '
        If SQL.HasException() Then
            MessageBox.Show("Houve uma exceção ao EXCLUIR o CFOP..." & vbNewLine &
                            SQL.Exception, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        '
        '--- Atualizar o Datagrid e emitir mensagem
        PreencheListagem()
        FormataListagem()
        MessageBox.Show("O CFOP foi excluído com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    '
#End Region
    '
End Class
