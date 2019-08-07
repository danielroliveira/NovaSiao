Imports CamadaBLL
'
Public Class frmAutoresProcurar
    Private dtAutor As DataTable
    Private _origem As Form
    Property propAutorEscolhido As String
    '
#Region "NEW | LOAD"
    '
    '--------------------------------------------------------------------------------------------------------
    ' NEW, LOAD FORM
    '--------------------------------------------------------------------------------------------------------
    Public Sub New(frmOrigem As Form)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _origem = frmOrigem

    End Sub
    '
    Private Sub frmAutoresProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim prodBLL As New ProdutoBLL
        Try
            dtAutor = prodBLL.GetAutoresLista
            PreencheListagem()
        Catch ex As Exception
            MessageBox.Show("Erro ao importar a lista de Autores..." & vbNewLine &
                            ex.Message, "BD Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.DialogResult = DialogResult.Abort
            Close()
        End Try
    End Sub
    '
#End Region
    '
#Region "LISTAGEM CONTROLE"
    '
    '--------------------------------------------------------------------------------------------------------
    ' PREENCHE A LISTAGEM
    '--------------------------------------------------------------------------------------------------------
    Private Sub PreencheListagem()
        With dgvAutores
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
        ' (1) COLUNA REG
        dgvAutores.Columns.Add("clnAutor", "Autor Nome")
        With dgvAutores.Columns("clnAutor")
            .DataPropertyName = "Autor"
            .Width = 350
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            Dim newPadding As New Padding(5, 0, 0, 0)
            .DefaultCellStyle.Padding = newPadding
        End With
        '
        ' (2) COLUNA FILIAL
        dgvAutores.Columns.Add("clnQuantidade", "Livros Qde.")
        With dgvAutores.Columns("clnQuantidade")
            .DataPropertyName = "Quantidade"
            .Width = 90
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        dgvAutores.DataSource = dtAutor
        '
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If dgvAutores.RowCount > 0 AndAlso dgvAutores.SelectedRows.Count > 0 Then
            '
            propAutorEscolhido = dgvAutores.SelectedRows(0).Cells(0).Value
            Me.DialogResult = DialogResult.OK
            '
        Else
            MessageBox.Show("Favor selecionar um autor antes de Escolher...", "Selecione um Produto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "FUNCOES NECESSARIAS"
    '
    ' PROCURAR AUTOR
    Private Sub ProcurarCliente()
        Dim dvAutor As DataView = dtAutor.DefaultView
        '
        If txtProcurar.TextLength > 0 Then
            dvAutor.RowFilter = "Autor LIKE '*" & txtProcurar.Text & "*'" ' PROCURA PELO NOME
        Else
            dvAutor.RowFilter = ""
        End If
    End Sub
    '
    Private Sub txtProcurar_TextChanged(sender As Object, e As EventArgs) Handles txtProcurar.TextChanged
        ProcurarCliente()
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    '-------------------------------------------------------------------------------------------------
    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAutores.CellDoubleClick
        btnEscolher_Click(New Object, New EventArgs)
    End Sub
    '
    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAutores.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEscolher_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ITENS DA LISTAGEM
    '-------------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnCancelar_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            '
            If dgvAutores.Rows.Count > 0 Then
                If dgvAutores.SelectedRows.Count > 0 Then
                    Dim i As Integer = dgvAutores.SelectedRows(0).Index
                    '
                    dgvAutores.Rows(i).Selected = False
                    '
                    If i = 0 Then
                        i = dgvAutores.Rows.Count
                    End If
                    '
                    dgvAutores.Rows(i - 1).Selected = True
                Else
                    dgvAutores.Rows(0).Selected = True
                End If
                '
                dgvAutores.FirstDisplayedScrollingRowIndex = dgvAutores.SelectedRows(0).Index
                '
            End If
            '
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            '
            If dgvAutores.Rows.Count > 0 Then
                If dgvAutores.SelectedRows.Count > 0 Then
                    Dim i As Integer = dgvAutores.SelectedRows(0).Index
                    '
                    dgvAutores.Rows(i).Selected = False
                    '
                    If i = dgvAutores.Rows.Count - 1 Then
                        i = -1
                    End If
                    '
                    dgvAutores.Rows(i + 1).Selected = True
                Else
                    dgvAutores.Rows(0).Selected = True
                End If
                '
                dgvAutores.FirstDisplayedScrollingRowIndex = dgvAutores.SelectedRows(0).Index
                '
            End If
            '
        End If
    End Sub
    '
    Private Sub txtProcurar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProcurar.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            If dgvAutores.SelectedRows.Count > 0 Then
                btnEscolher_Click(New Object, New System.EventArgs)
            Else
                e.Handled = True
                SendKeys.Send("{Tab}")
            End If
        ElseIf e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLES VISUAIS"
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
    Private Sub dgvAutores_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAutores.CellMouseDoubleClick
        btnEscolher_Click(New Object, New EventArgs)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' QUANDO O DGVLISTAGEM ESTA SELECIONADO MUDA DE COR FUNDO
    '-------------------------------------------------------------------------------------------------
    Private Sub dgv_Focus(sender As Object, e As EventArgs) Handles dgvAutores.GotFocus
        dgvAutores.BackgroundColor = Color.LightSteelBlue
    End Sub
    Private Sub dgv_LostFocus(sender As Object, e As EventArgs) Handles dgvAutores.LostFocus
        dgvAutores.BackgroundColor = Color.DarkGray
    End Sub
    '
#End Region
    '
End Class
