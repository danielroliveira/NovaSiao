Imports CamadaBLL

Public Class frmFilial
    Private dtFil As DataTable
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Private _formOrigem As Form
    Dim _Sit As Byte
    Dim _formEscolha As Boolean
    Property IDFilialEscolhida As Integer?
    Property FilialEscolhida As String
    '
#Region "LOAD | NEW"
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
                    '
                    If _formEscolha = True Then
                        btnNovo.Enabled = False
                        btnSalvar.Enabled = True
                        btnSalvar.Text = "&Escolher"
                        btnSalvar.Image = My.Resources.accept
                        btnFechar.Text = "&Cancelar"
                    Else
                        btnNovo.Enabled = True
                        btnSalvar.Enabled = False
                        btnSalvar.Text = "&Salvar"
                        btnSalvar.Image = My.Resources.save
                        btnFechar.Text = "&Fechar"
                    End If
                    '
                Case EnumFlagEstado.Alterado
                    btnNovo.Enabled = False
                    btnSalvar.Enabled = True
                    btnSalvar.Text = "&Salvar"
                    btnSalvar.Image = My.Resources.save
                    btnFechar.Text = "&Cancelar"
                Case EnumFlagEstado.NovoRegistro
                    btnNovo.Enabled = False
                    btnSalvar.Enabled = True
                    btnSalvar.Text = "&Salvar"
                    btnSalvar.Image = My.Resources.save
                    btnFechar.Text = "&Cancelar"
            End Select
        End Set
    End Property
    '
    Sub New(Optional Escolha As Boolean = False, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formEscolha = Escolha
        _formOrigem = formOrigem
        '
        PreencheFiliais()
        '
        If _formEscolha = True Then
            dgvFiliais.EditMode = DataGridViewEditMode.EditProgrammatically
            lblTitulo.Text = "Escolher Filial"
        End If
        '
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM | DATAGRID CONTROLE"

    '--------------------------------------------------------------------------------------------------------
    ' PREENCHE A LISTAGEM
    '--------------------------------------------------------------------------------------------------------
    Private Sub PreencheFiliais()
        '
        Dim db As New FilialBLL
        Try
            dtFil = db.GetFiliais
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao obter a lista de Filiais" & vbNewLine &
                            ex.Message, "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        '
        With dgvFiliais
            .Columns.Clear()
            .AutoGenerateColumns = False
            ' altera as propriedades importantes
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ColumnHeadersVisible = True
            .RowHeadersVisible = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .RowHeadersWidth = 36
            .RowTemplate.Height = 30
            .StandardTab = True
        End With
        '
        ' (1) COLUNA REG
        dgvFiliais.Columns.Add("clnID", "Reg.:")
        With dgvFiliais.Columns("clnID")
            .DataPropertyName = "IDFilial"
            .Width = 70
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            Dim newPadding As New Padding(5, 0, 0, 0)
            .DefaultCellStyle.Padding = newPadding
        End With
        '
        ' (2) COLUNA FILIAL
        dgvFiliais.Columns.Add("clnFilial", "Filial:")
        With dgvFiliais.Columns("clnFilial")
            .DataPropertyName = "ApelidoFilial"
            .Width = 220
            .Visible = True
            .ReadOnly = False
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (3) Coluna da imagem
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .Name = "Ativo"
            .Resizable = False
            .Width = 70
            .ReadOnly = True
        End With
        dgvFiliais.Columns.Add(colImage)
        '
        ' (4) COLUNA ATIVO
        dgvFiliais.Columns.Add("clnAtivo", "Ativo")
        With dgvFiliais.Columns("clnAtivo")
            .DataPropertyName = "Ativo"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        dgvFiliais.DataSource = dtFil
        '
    End Sub
    '
    Private Sub dgvContas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvFiliais.CellFormatting
        If e.ColumnIndex = 2 Then
            Dim dr As DataRowView = DirectCast(dgvFiliais.Rows(e.RowIndex).DataBoundItem, DataRowView)
            '
            If IsDBNull(dr("Ativo")) Then Exit Sub
            '
            If dr("Ativo") = True Then
                e.Value = ImgAtivo
            Else
                e.Value = ImgInativo
            End If
        End If
    End Sub
    '
    '--- SELECIONA O REGISTRO COM DOUBLE_CLIC
    Private Sub dgvFiliais_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFiliais.CellDoubleClick
        '
        If e.ColumnIndex = 1 Then Exit Sub
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            EscolherRegistro()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        If Sit = EnumFlagEstado.RegistroSalvo Then
            DialogResult = DialogResult.Cancel
            Me.Close()
        ElseIf Sit = enumFlagEstado.NovoRegistro Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            dgvFiliais.Rows.Remove(dgvFiliais.CurrentRow)
            PreencheFiliais()
            Sit = EnumFlagEstado.RegistroSalvo
        ElseIf Sit = enumFlagEstado.Alterado Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            dtFil.RejectChanges()
            dgvFiliais.CancelEdit()
            'dgvFiliais.ClearSelection()
            PreencheFiliais()
            Sit = EnumFlagEstado.RegistroSalvo
        End If
    End Sub
    '
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '---adiciona novo ROW no datatable 
        dtFil.Rows.Add()
        Sit = EnumFlagEstado.NovoRegistro
        ' seleciona a cell
        dgvFiliais.Focus()
        dgvFiliais.CurrentCell = dgvFiliais.Rows(dgvFiliais.Rows.Count - 1).Cells(1)
        dgvFiliais.BeginEdit(True)
        '---adiciona a imagem no NOVO ROW
        dgvFiliais.CurrentRow.Cells("Ativo").Value = My.Resources.NovoPeq
    End Sub
    '
#End Region
    '
#Region "DATAGRID CONTROLE"

    '---CONTROLE DA EDIÇÃO DO DATAGRID
    '-----------------------------------------------------------------------------------------------
    Private Sub dgvFiliais_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvFiliais.CellValidating
        ' Valida o entrada para a descrição não permitindo valores em branco
        If dgvFiliais.Columns(e.ColumnIndex).Name = "clnFilial" Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                dgvFiliais.Rows(e.RowIndex).ErrorText = "O Apelido/Nome da Filial não pode ficar vazia..."
                e.Cancel = True
                Exit Sub
            End If
        End If
        '---procura por valores duplicados da descrição 
        If VerificaDuplicado(e.RowIndex, e.FormattedValue.ToString.ToUpper) Then
            MessageBox.Show("Já existe um Fabricante com a mesma descrição:" & vbNewLine &
                    e.FormattedValue.ToString.ToUpper,
                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvFiliais.Rows(e.RowIndex).ErrorText = "O nome do Fabricante precisa ser EXCLUSIVO..."
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    '
    ' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
    '-----------------------------------------------------------------------------------------------
    Public Function VerificaDuplicado(myRow As Integer, myNewValor As String) As Boolean
        '---se não houver nenhum registro, Exit
        If dtFil.Rows.Count = 0 Then
            VerificaDuplicado = False
            Exit Function
        End If
        '---verifica todos os ROWS procurando registro igual
        For i = 0 To dtFil.Rows.Count - 1
            If i = myRow Then Continue For '---se for a mesma ROW não verifica
            If dtFil.Rows(i).Item("ApelidoFilial").ToString.ToUpper = myNewValor Then
                VerificaDuplicado = True
                Exit Function
            End If
        Next i
        '---se não encontrar retorna FALSE
        VerificaDuplicado = False
    End Function
    '
    Private Sub dgvFiliais_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFiliais.CellEndEdit
        ' Limpa o erro da linha no caso do usuário pressionar ESC
        dgvFiliais.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub dgvFiliais_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvFiliais.EditingControlShowing
        '---restringe a entrada de dados para a coluna 'Forma de Cobrança'
        If dgvFiliais.CurrentCell.ColumnIndex = 1 And Not e.Control Is Nothing Then
            Dim tb As TextBox = CType(e.Control, TextBox)
            '---inclui um tratamento de evento para o controle TextBox---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub
    '
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '---Se o usuario pressionou a tecla ESC na edição ---
        If e.KeyChar = Convert.ToChar(27) Then
            If Sit <> EnumFlagEstado.RegistroSalvo Then
                e.Handled = True
                '---cancela a adição do registro
                If Sit = EnumFlagEstado.NovoRegistro Then dgvFiliais.Rows.Remove(dgvFiliais.CurrentRow)
                PreencheFiliais()
                Sit = EnumFlagEstado.RegistroSalvo
            End If
        End If
    End Sub
    '
    ' CONTROLE DA LISTAGEM
    Private Sub dgvFiliais_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvFiliais.CellBeginEdit
        If Not Sit <> EnumFlagEstado.NovoRegistro Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
#End Region
    '
#Region "SALVAR REGISTRO"

    ' SALVAR O REGISTRO
    '-----------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If (_formEscolha = False) Or (_formEscolha = True And Sit <> EnumFlagEstado.RegistroSalvo) Then
            SalvarAlteracoes()
        Else
            EscolherRegistro()
        End If
        '
    End Sub
    '
    Private Sub SalvarAlteracoes()
        '
        '-- variavel para informar o número de registros salvos
        Dim regSalvos As Integer = 0
        '
        For Each r As DataGridViewRow In dgvFiliais.Rows
            ' verfica se já existe valor igual
            If dtFil.Rows(r.Index).RowState <> DataRowState.Unchanged Then
                If VerificaDuplicado(r.Index, dgvFiliais.Rows(r.Index).Cells(1).Value) = True Then
                    MessageBox.Show("Já existe uma Filial com o mesmo Apelido/Nome:" & vbNewLine &
                                        CStr(dgvFiliais.Rows(r.Index).Cells(1).Value).ToUpper,
                                        "Nome Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Continue For
                End If
            End If
            '
            '--- Salva os registros
            Dim db As New FilialBLL
            '
            If dtFil.Rows(r.Index).RowState = DataRowState.Modified Then ' registro ALTERADO
                db.UpdateFilial(dgvFiliais.Rows(r.Index).Cells(0).Value,
                                dgvFiliais.Rows(r.Index).Cells(1).Value,
                                dgvFiliais.Rows(r.Index).Cells(3).Value)
                regSalvos += 1
            ElseIf dtFil.Rows(r.Index).RowState = DataRowState.Added Then ' registro NOVO
                db.InsertFilial(dgvFiliais.Rows(r.Index).Cells(1).Value, Nothing)
                r.Cells("clnAtivo").Value = True
                regSalvos += 1
            End If
        Next
        '
        '--- mensagem de sucesso---
        If regSalvos > 0 Then
            MessageBox.Show("Sucesso ao salvar registro(s) de Filiais(s)" & vbNewLine &
                            "Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
                            IIf(regSalvos > 1, " registros", " registro"),
                            "Registro(s) Salvo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
        '---preencher a listagem com os novos valores
        PreencheFiliais()
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    Private Sub EscolherRegistro()
        '
        If dgvFiliais.SelectedCells.Count = 0 Then
            MessageBox.Show("Selecione uma FILIAL antes de pressionar Escolher...", "Selecionar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvFiliais.Focus()
            Exit Sub
        End If
        '
        Dim dr As DataRowView = dgvFiliais.Rows(dgvFiliais.SelectedCells(0).RowIndex).DataBoundItem
        '
        If dr("Ativo") = False Then
            MessageBox.Show("Você não pode escolher uma FILIAL INATIVA...", "Escolher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvFiliais.Focus()
            Exit Sub
        End If
        '
        IDFilialEscolhida = dr("IDFilial")
        FilialEscolhida = dr("ApelidoFilial")
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
#End Region
    '
#Region "MENU SUSPENSO"

    Private Sub dgvFiliais_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvFiliais.MouseDown
        '
        If e.Button = MouseButtons.Right And _formEscolha = False Then
            '
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvFiliais.HitTest(e.X, e.Y)
            '
            dgvFiliais.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvFiliais.CurrentCell = dgvFiliais.Rows(hit.RowIndex).Cells(1)
            dgvFiliais.Rows(hit.RowIndex).Selected = True

            ' mostra o MENU ativar e desativar
            If dgvFiliais.Columns(hit.ColumnIndex).Name = "Ativo" Then
                If dgvFiliais.Rows(hit.RowIndex).Cells(3).Value = True Then
                    AtivarToolStripMenuItem.Enabled = False
                    DesativarToolStripMenuItem.Enabled = True
                Else
                    AtivarToolStripMenuItem.Enabled = True
                    DesativarToolStripMenuItem.Enabled = False
                End If
                ' revela menu
                MenuFil.Show(c.PointToScreen(e.Location))
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
        '--- verifica se existe alguma cell
        If IsDBNull(dgvFiliais.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = dtFil.Select("ApelidoFilial = '" & dgvFiliais.CurrentRow.Cells("clnFilial").Value & "'").First
        r("Ativo") = True
        dtFil.AcceptChanges()
        '
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
    End Sub
    '
    Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesativarToolStripMenuItem.Click
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvFiliais.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = dtFil.Select("ApelidoFilial = '" & dgvFiliais.CurrentRow.Cells("clnFilial").Value & "'").First
        r("Ativo") = False
        dtFil.AcceptChanges()
        '
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
    End Sub
    '
#End Region
    '
#Region "EFEITOS SUB-FORMULARIO PADRAO"
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.DarkSlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmAPagarItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region
    '
End Class
