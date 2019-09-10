Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmEnvioListagem
    '
    Private WithEvents list As New List(Of clPessoaEnvio)
    Private _formOrigem As Form = Nothing
    Private ImageAtivo As Image = My.Resources.accept
    Private ImageInativo As Image = My.Resources.block
    '
#Region "LOAD FORM"
    '
    Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        CarregaDados()
        '
    End Sub
    '
    Private Sub CarregaDados()
        Dim eBLL As New PessoaEnvioBLL
        '
        Try
            list = eBLL.GetPessoaEnvios
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao obter a lista de Envios..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
        PreencheListagem()
        '
        '--- Preenche o DataSource com um Filtro
        FiltrarListagem()
        '
    End Sub
    '
#End Region
    '
#Region "PREENCHE LISTAGEM"
    '
    Private Sub PreencheListagem()
        '
        With dgvListagem
            .Columns.Clear()
            .AutoGenerateColumns = False
            ' altera as propriedades importantes
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ColumnHeadersVisible = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .RowHeadersWidth = 36
            .RowTemplate.Height = 30
            .StandardTab = True
        End With
        '
        ' (0) COLUNA DATA
        With clnEnvioData
            .DataPropertyName = "EnvioData"
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "dd/MM/yyyy"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (1) COLUNA DESCRICAO
        With clnEnvioDescricao
            .DataPropertyName = "EnvioDescricao"
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA IMPRESSO
        With clnImpresso
            .DataPropertyName = "Impresso"
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (3) COLUNA ENVIADO
        With clnEnviado
            .DataPropertyName = "Enviado"
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        dgvListagem.Columns.AddRange({clnEnvioData, clnEnvioDescricao, clnImpresso, clnEnviado})
        '
    End Sub
    '
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        If e.ColumnIndex = 0 Then
            'e.Value = Format(e.Value, "D4")
        ElseIf e.ColumnIndex = 2 Then
            If DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clPessoaEnvio).Impresso = True Then
                e.Value = ImageAtivo
            Else
                e.Value = ImageInativo
            End If
        ElseIf e.ColumnIndex = 3 Then
            If DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clPessoaEnvio).Enviado = True Then
                e.Value = ImageAtivo
            Else
                e.Value = ImageInativo
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs)
        '
        '
    End Sub
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        ''--- verifica se existe algum item selecionado
        'If dgvListagem.SelectedRows.Count = 0 Then
        '    MessageBox.Show("Não existe nenhum Tipo de Despesa selecionado...", "Escolher",
        '                    MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    dgvListagem.Focus()
        '    Exit Sub
        'End If
        ''
        ''--- Seleciona o Fornecedor
        'propDespesaEscolhida = dgvListagem.SelectedRows(0).DataBoundItem
        ''
        'If _Procura = True Then '--- se for para escolha e procura
        '    propEscolhido = propDespesaEscolhida.IDDespesaTipo
        '    Me.DialogResult = DialogResult.OK
        'Else '--- se for para EDICAO
        '    Dim frmDt As New frmDespesaTipo(propDespesaEscolhida, Me)
        '    frmDt.ShowDialog()
        '    '
        '    If frmDt.DialogResult = DialogResult.OK Then
        '        CarregaDados()
        '    End If
        '    '
        'End If
        ''
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnEditar_Click(New Object, New System.EventArgs)
    End Sub
    '
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    Private Sub Listagem_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            btnEditar_Click(New Object, New System.EventArgs)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "PROCURA"
    '
    '--- FILTRAR LISTAGEM
    Private Sub FiltrarListagem()

        dgvListagem.DataSource = list.FindAll(AddressOf FindDTipo)

    End Sub
    '
    Private Function FindDTipo(ByVal Dt As clPessoaEnvio) As Boolean
        '
        If Dt.EnvioDescricao.ToLower Like "*" & txtProcura.Text.ToLower & "*" Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    Private Sub txtProcura_TextChanged(sender As Object, e As EventArgs) Handles txtProcura.TextChanged
        FiltrarListagem()
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '------------------------------------------------------------------------------------------
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    '------------------------------------------------------------------------------------------
    Private Sub Control_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles txtProcura.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    Private Sub frmCredorProcurar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar.ToString = "+" Then
            e.Handled = True
            btnAdicionar_Click(New Object, New EventArgs)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            btnFechar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ITENS DA LISTAGEM
    '-------------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnFechar_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Up Then
            '
            e.Handled = True
            '
            If dgvListagem.Rows.Count > 0 Then
                If dgvListagem.SelectedRows.Count > 0 Then
                    Dim i As Integer = dgvListagem.SelectedRows(0).Index
                    '
                    dgvListagem.Rows(i).Selected = False
                    '
                    If i = 0 Then
                        i = dgvListagem.Rows.Count
                    End If
                    '
                    dgvListagem.Rows(i - 1).Selected = True
                Else
                    dgvListagem.Rows(0).Selected = True
                End If
                '
                dgvListagem.FirstDisplayedScrollingRowIndex = dgvListagem.SelectedRows(0).Index
                dgvListagem.SelectedRows(0).Cells(0).Selected = True
                '
            End If
            '
        ElseIf e.KeyCode = Keys.Down Then
            '
            e.Handled = True
            '
            If dgvListagem.Rows.Count > 0 Then
                If dgvListagem.SelectedRows.Count > 0 Then
                    Dim i As Integer = dgvListagem.SelectedRows(0).Index
                    '
                    dgvListagem.Rows(i).Selected = False
                    '
                    If i = dgvListagem.Rows.Count - 1 Then
                        i = -1
                    End If
                    '
                    dgvListagem.Rows(i + 1).Selected = True
                Else
                    dgvListagem.Rows(0).Selected = True
                End If
                '
                dgvListagem.FirstDisplayedScrollingRowIndex = dgvListagem.SelectedRows(0).Index
                dgvListagem.SelectedRows(0).Cells(0).Selected = True
                '
            End If
            '
        End If
        '
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
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
        '
    End Sub
    '
    Private Sub frmDespesaTipo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
        '
    End Sub
    '
#End Region
    '
End Class
