Imports CamadaBLL
Public Class frmCobrancaForma
    Private dtForma As DataTable
    Dim SQL As New SQLControl
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Dim _Sit As Byte
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
                Case EnumFlagEstado.Alterado
                    btnSalvar.Enabled = True
                    btnFechar.Text = "&Cancelar"
                Case EnumFlagEstado.NovoRegistro
                    btnSalvar.Enabled = True
                    btnFechar.Text = "&Cancelar"
            End Select
        End Set
    End Property
    '
    ' EVENTO LOAD
    Private Sub frmFabricante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheListaFormas()
        Sit = EnumFlagEstado.RegistroSalvo
    End Sub
    '
    ' PREENCHE LISTAGEM
    Private Sub PreencheListaFormas()
        SQL.ExecQuery("SELECT * FROM tblCobrancaFormas")
        dtForma = SQL.DBDT
        '
        dgvFormas.Columns.Clear()
        dgvFormas.AutoGenerateColumns = False
        dgvFormas.RowHeadersWidth = 36
        '
        ' (1) COLUNA REG
        dgvFormas.Columns.Add("IDCobrancaForma", "Reg.")
        With dgvFormas.Columns("IDCobrancaForma")
            .DataPropertyName = "IDCobrancaForma"
            .Width = 50
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA FORMA
        dgvFormas.Columns.Add("CobrancaForma", "Forma de Cobrança")
        With dgvFormas.Columns("CobrancaForma")
            .DataPropertyName = "CobrancaForma"
            .Width = 200
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
        End With
        dgvFormas.Columns.Add(colImage)
        '
        ' (4) COLUNA ATIVO
        dgvFormas.Columns.Add("FAtivo", "Ativo")
        With dgvFormas.Columns("FAtivo")
            .DataPropertyName = "Ativo"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        dgvFormas.DataSource = dtForma
        PreencheListaImagem()
    End Sub
    '
    Private Sub PreencheListaImagem()
        Dim c As Integer = dtForma.Rows.Count

        For Each r As DataGridViewRow In dgvFormas.Rows
            If r.Cells(3).Value = True Then
                r.Cells(2).Value = ImgAtivo
            Else
                r.Cells(2).Value = ImgInativo
            End If
        Next
    End Sub
    '
    ' CONTROLE DA LISTAGEM
    Private Sub dgvFormas_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvFormas.CellBeginEdit
        If Sit <> EnumFlagEstado.NovoRegistro Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    Private Sub dgvFormas_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvFormas.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvFormas.HitTest(e.X, e.Y)
            dgvFormas.ClearSelection()
            '
            '---se o item clicado não for uma CELL, exit
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            '---se for um novo registro
            If Sit = EnumFlagEstado.NovoRegistro Then
                MessageBox.Show("Salve o novo registro para depois alterar a ATIVAÇÃO de alguma Conta",
                                "Desativar/Ativar Conta", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            ' seleciona o ROW
            dgvFormas.Rows(hit.RowIndex).Cells(0).Selected = True
            dgvFormas.Rows(hit.RowIndex).Selected = True
            '
            ' mostra o MENU ativar e desativar
            If dgvFormas.Columns(hit.ColumnIndex).Name = "Ativo" Then
                If dgvFormas.Rows(hit.RowIndex).Cells(3).Value = True Then
                    AtivarToolStripMenuItem.Enabled = False
                    DesativarToolStripMenuItem.Enabled = True
                Else
                    AtivarToolStripMenuItem.Enabled = True
                    DesativarToolStripMenuItem.Enabled = False
                End If
                ' revela menu
                MenuForma.Show(c.PointToScreen(e.Location))
            End If
        End If
    End Sub
    '
    Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvFormas.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = dtForma.Select("CobrancaForma = '" & dgvFormas.CurrentRow.Cells("CobrancaForma").Value & "'").First
        r("Ativo") = True
        dtForma.AcceptChanges()
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- altera a imagem
        PreencheListaImagem()
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
    End Sub
    '
    Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesativarToolStripMenuItem.Click
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvFormas.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = dtForma.Select("CobrancaForma = '" & dgvFormas.CurrentRow.Cells("CobrancaForma").Value & "'").First
        r("Ativo") = False
        dtForma.AcceptChanges()
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- altera a imagem
        PreencheListaImagem()
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
    End Sub
    '
    ' BOTOES DO FORMULARIO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '---adiciona novo ROW no datatable
        dtForma.Rows.Add()
        Sit = EnumFlagEstado.NovoRegistro
        ' seleciona a cell
        dgvFormas.Focus()
        dgvFormas.CurrentCell = dgvFormas.Rows(dgvFormas.Rows.Count - 1).Cells(1)
        dgvFormas.BeginEdit(True)
        '---adiciona a imagem no NOVO ROW
        dgvFormas.CurrentRow.Cells("Ativo").Value = My.Resources.NovoPeq
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Me.Close()
        ElseIf Sit = enumFlagEstado.NovoRegistro Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            dgvFormas.Rows.Remove(dgvFormas.CurrentRow)
            PreencheListaFormas()
            Sit = EnumFlagEstado.RegistroSalvo
        ElseIf Sit = enumFlagEstado.Alterado Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            dgvFormas.CancelEdit()
            PreencheListaFormas()
            Sit = EnumFlagEstado.RegistroSalvo
        End If
    End Sub
    '
    ' SALVAR REGISTRO
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '-- variavel para informar o número de registros salvos
        Dim regSalvos As Integer = 0
        '
        For Each r As DataGridViewRow In dgvFormas.Rows
            ' verfica se já existe valor igual
            If dtForma.Rows(r.Index).RowState <> DataRowState.Unchanged Then
                If VerificaDuplicado(r.Index, dgvFormas.Rows(r.Index).Cells(1).Value.ToString.ToUpper) = True Then
                    MessageBox.Show("Já existe uma Forma de Cobrança com a mesma descrição:" & vbNewLine &
                                        CStr(dgvFormas.Rows(r.Index).Cells(1).Value).ToUpper,
                                        "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Continue For
                End If
            End If
            '
            '---salva os registros
            If dtForma.Rows(r.Index).RowState = DataRowState.Modified Then ' registro ALTERADO
                SQL.ExecQuery("UPDATE tblCobrancaFormas " &
                              "SET CobrancaForma = '" & dgvFormas.Rows(r.Index).Cells(1).Value & "', " &
                              " Ativo = '" & dgvFormas.Rows(r.Index).Cells(3).Value & "'" &
                              " WHERE IDCobrancaForma = " & dgvFormas.Rows(r.Index).Cells(0).Value)
                regSalvos += 1
            ElseIf dtForma.Rows(r.Index).RowState = DataRowState.Added Then ' registro NOVO
                SQL.ExecQuery("INSERT INTO tblCobrancaFormas" &
                              " (CobrancaForma, Ativo) VALUES ('" & dgvFormas.Rows(r.Index).Cells(1).Value & "', 'TRUE')", True)
                regSalvos += 1
            End If
            '
            '---veridica se houve erro
            If SQL.HasException(True) Then
                MessageBox.Show("O seguinte registro não pôde ser salvo:" & vbNewLine &
                                CStr(dgvFormas.Rows(r.Index).Cells(1).Value).ToUpper, "Erro ao Salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                regSalvos -= 1
            End If
        Next
        '
        '--- mensagem de sucesso---
        If regSalvos > 0 Then
            MessageBox.Show("Sucesso ao salvar registro(s) de Forma de Cobrança" & vbNewLine &
                            "Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
                            IIf(regSalvos > 1, " registros", " registro"),
                            "Registro(s) Salvo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
        '---preencher a listagem com os novos valores
        PreencheListaFormas()
        Sit = EnumFlagEstado.RegistroSalvo
    End Sub
    '
    ' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
    Public Function VerificaDuplicado(myRow As Integer, myNewValor As String) As Boolean
        '---se não houver nenhum registro, Exit
        If dtForma.Rows.Count = 0 Then
            VerificaDuplicado = False
            Exit Function
        End If
        '---verifica todos os ROWS procurando registro igual
        For i = 0 To dtForma.Rows.Count - 1
            If i = myRow Then Continue For '---se for a mesma ROW não verifica
            If dtForma.Rows(i).Item("CobrancaForma").ToString.ToUpper = myNewValor Then
                VerificaDuplicado = True
                Exit Function
            End If
        Next i
        '---se não encontrar retorna FALSE
        VerificaDuplicado = False
    End Function
    '
    Private Sub dgvFormas_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvFormas.CellValidating
        ' Valida o entrada para a descrição não permitindo valores em branco
        If dgvFormas.Columns(e.ColumnIndex).Name = "CobrancaForma" Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                dgvFormas.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO da Forma de Cobrança não pode ficar vazia..."
                e.Cancel = True
                Exit Sub
            End If
        End If
        '---procura por valores duplicados da descrição 
        If VerificaDuplicado(e.RowIndex, e.FormattedValue.ToString.ToUpper) Then
            MessageBox.Show("Já existe uma Forma de Cobrança com a mesma descrição:" & vbNewLine &
                    e.FormattedValue.ToString.ToUpper,
                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvFormas.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO da Forma de Cobrança precisa ser EXCLUSIVA..."
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    '
    Private Sub dgvFormas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFormas.CellEndEdit
        ' Limpa o erro da linha no caso do usuário pressionar ESC
        dgvFormas.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub dgvFormas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvFormas.EditingControlShowing
        '---restringe a entrada de dados para a coluna 'Forma de Cobrança'
        If Me.dgvFormas.CurrentCell.ColumnIndex = 1 And Not e.Control Is Nothing Then
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
                If Sit = EnumFlagEstado.NovoRegistro Then dgvFormas.Rows.Remove(dgvFormas.CurrentRow)
                PreencheListaFormas()
                Sit = EnumFlagEstado.RegistroSalvo
            End If
        End If
    End Sub
    '


End Class
