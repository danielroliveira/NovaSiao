Imports CamadaBLL
'
Public Class frmCartaoTipos
    '
    Private dtOrigem As DataTable
    Private _procura As Boolean = False
    Private _formOrigem As Form
    '
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Private ImgNew As Image = My.Resources.NovoPeq
    '
    Property IDOrigem_Escolhido As Int16?
    Property OrigemDesc_Escolhido As String
    '
    Dim _Sit As Byte
    '
#Region "NEW | PROPERTY"
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

                    If _procura = True Then
                        btnSalvar.Enabled = True
                        btnSalvar.Image = My.Resources.accept
                        btnSalvar.Text = "&Escolher"
                        btnFechar.Text = "&Fechar"
                    Else
                        btnSalvar.Enabled = False
                        btnSalvar.Image = My.Resources.save
                        btnSalvar.Text = "&Salvar"
                        btnFechar.Text = "&Fechar"
                    End If

                Case EnumFlagEstado.Alterado
                    btnSalvar.Enabled = True
                    btnSalvar.Image = My.Resources.save
                    btnSalvar.Text = "&Salvar"
                    btnFechar.Text = "&Cancelar"
                Case EnumFlagEstado.NovoRegistro
                    btnSalvar.Enabled = True
                    btnSalvar.Image = My.Resources.save
                    btnSalvar.Text = "&Salvar"
                    btnFechar.Text = "&Cancelar"
            End Select
        End Set
    End Property
    '
    Sub New(Optional procura As Boolean = False,
            Optional formOrigem As Form = Nothing,
            Optional IDPadrao As Int16? = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        _procura = procura
        _formOrigem = formOrigem
        '
        lblTitulo.Text = "Tipos de Cartao"
        AtivarToolStripMenuItem.Text = "Ativar Cartão"
        DesativarToolStripMenuItem.Text = "Desativar Cartão"
        '
        FormataListagem()
        '
        If dgvListagem.RowCount > 0 Then
            Sit = EnumFlagEstado.RegistroSalvo
            '
            '--- Seleciona o IDPadrao caso houver
            If Not IsNothing(IDPadrao) Then
                For i = 0 To dgvListagem.Rows.Count - 1
                    If dgvListagem.Rows(i).Cells(0).Value = IDPadrao Then
                        dgvListagem.CurrentCell = dgvListagem.Rows(i).Cells(0)
                        dgvListagem.Rows(i).Selected = True
                        Exit For
                    End If
                Next i
            End If
            '
        Else
            Sit = EnumFlagEstado.NovoRegistro
        End If
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM"
    '
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
        dgvListagem.RowHeadersWidth = 36
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
        Dim mbll As New MovimentacaoBLL
        dtOrigem = mbll.MovCartao_GET_Dt
        '
    End Sub
    '
    ' PREENCHE LISTAGEM
    Private Sub PreencheListagem()
        '
        ' (1) COLUNA REG
        dgvListagem.Columns.Add("ID", "Reg.")
        With dgvListagem.Columns("ID")
            .DataPropertyName = "IDCartaoTipo"
            .Width = 50
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA CONTA
        dgvListagem.Columns.Add("Desc", "")
        With dgvListagem.Columns("Desc")
            .HeaderText = "Tipo de Cartão"
            .DataPropertyName = "Cartao"
            .Width = 200
            .Visible = True
            .ReadOnly = False
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (3) COLUNA DA IMAGEM
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .Name = "Ativo"
            .Resizable = False
            .Width = 70
        End With
        '
        dgvListagem.Columns.Add(colImage)
        '
        dgvListagem.DataSource = dtOrigem
        '
    End Sub
    '
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        If e.ColumnIndex = 2 Then
            Dim r As DataRowView = dgvListagem.Rows(e.RowIndex).DataBoundItem
            '
            If IsDBNull(r("Ativo")) Then
                e.Value = ImgNew
            Else
                If r("Ativo") = True Then
                    e.Value = ImgAtivo
                Else
                    e.Value = ImgInativo
                End If
            End If
        End If
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    '-------------------------------------------------------------------------------------------------
    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnSalvar_Click(New Object, New EventArgs)
    End Sub
    '
    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnSalvar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
#End Region
    '
#Region "MENUSTRIP"
    '
    ' CONTROLE DO TOOLSTRIPMENU
    Private Sub dgvListagem_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvListagem.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvListagem.HitTest(e.X, e.Y)
            dgvListagem.ClearSelection()
            '
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvListagem.CurrentCell = dgvListagem.Rows(hit.RowIndex).Cells(1)
            dgvListagem.Rows(hit.RowIndex).Cells(2).Selected = True
            '
            ' mostra o MENU ativar e desativar
            If dgvListagem.Columns(hit.ColumnIndex).Name = "Ativo" Then
                If dgvListagem.Rows(hit.RowIndex).DataBoundItem("Ativo") = True Then
                    AtivarToolStripMenuItem.Enabled = False
                    DesativarToolStripMenuItem.Enabled = True
                Else
                    AtivarToolStripMenuItem.Enabled = True
                    DesativarToolStripMenuItem.Enabled = False
                End If
                '
                ' revela menu
                MenuListagem.Show(c.PointToScreen(e.Location))
                '
            End If
        End If
    End Sub
    '
    Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, DataRowView).Row
        '
        r("Ativo") = True
        dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).Cells(2).Value = ImgAtivo
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
    Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesativarToolStripMenuItem.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, DataRowView).Row
        '
        dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).Cells(2).Value = ImgInativo
        r("Ativo") = False
        '
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
        '
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"

    ' BOTOES DO FORMULARIO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '
        dtOrigem.Rows.Add()
        Sit = EnumFlagEstado.NovoRegistro
        '
        ' seleciona a cell
        dgvListagem.Focus()
        dgvListagem.CurrentCell = dgvListagem.Rows(dgvListagem.Rows.Count - 1).Cells(1)
        dgvListagem.BeginEdit(True)
        dgvListagem.CurrentRow.Cells("Ativo").Value = My.Resources.NovoPeq
        '
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            '
            If _procura = True Then
                DialogResult = DialogResult.Cancel
            Else
                MostraMenuPrincipal()
            End If
            '
            Close()
            '
        ElseIf Sit = EnumFlagEstado.NovoRegistro Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            dgvListagem.Rows.Remove(dgvListagem.CurrentRow)
            Get_Dados()
            Sit = EnumFlagEstado.RegistroSalvo
        ElseIf Sit = EnumFlagEstado.Alterado Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            dgvListagem.CancelEdit()
            Get_Dados()
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
    End Sub
    '
#End Region
    '
#Region "SALVAR REGISTRO"
    '
    ' ESCOLHER ou SALVAR REGISTRO
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If Sit <> EnumFlagEstado.RegistroSalvo Or _procura = False Then
            '
            SalvarRegistro_Cartao()
            '
        Else
            If dgvListagem.SelectedCells.Count = 0 Then
                MessageBox.Show("Selecione um registro antes de Escolher...", "Escolher",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvListagem.Focus()
                Exit Sub
            End If
            '
            IDOrigem_Escolhido = CShort(dgvListagem.Rows(dgvListagem.SelectedCells(0).RowIndex).DataBoundItem(0))
            OrigemDesc_Escolhido = dgvListagem.Rows(dgvListagem.SelectedCells(0).RowIndex).DataBoundItem(1)
            '
            DialogResult = DialogResult.OK
            Close()
            '
        End If
        '
    End Sub
    '
    ' SALVAR O REGISTRO CARTAO (INSERIDO | ALTERADO)
    Private Sub SalvarRegistro_Cartao()
        '
        '-- variavel para informar o número de registros salvos
        Dim regSalvos As Integer = 0
        '
        For Each r As DataGridViewRow In dgvListagem.Rows
            '
            ' verfica se já existe valor igual
            If DirectCast(r.DataBoundItem, DataRowView).Row.RowState <> DataRowState.Unchanged Then
                If VerificaDuplicado(r.Index, dgvListagem.Rows(r.Index).Cells(1).Value) = True Then
                    Continue For
                End If
            End If
            '
            '---salva os registros
            If dtOrigem.Rows(r.Index).RowState = DataRowState.Modified Then ' registro ALTERADO
                '
                If Salva_Cartao(r.Index, False) = True Then
                    regSalvos += 1
                End If
                '
            ElseIf dtOrigem.Rows(r.Index).RowState = DataRowState.Added Then ' registro NOVO
                '
                If Salva_Cartao(r.Index, True) = True Then
                    regSalvos += 1
                End If
                '
            End If
            '
        Next
        '
        '--- mensagem de sucesso---
        If regSalvos > 0 Then
            MessageBox.Show("Sucesso ao salvar registro(s) de Tipo de Cartao" & vbNewLine &
                            "Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
                            IIf(regSalvos > 1, " registros", " registro"),
                            "Registro(s) Salvo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
        '---preencher a listagem com os novos valores
        Get_Dados()
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    Private Function Salva_Cartao(myRowIndex As Integer, Inserir As Boolean) As Boolean
        '
        Dim mBLL As New MovimentacaoBLL
        Dim IDMovTipo As Integer? = If(IsDBNull(dgvListagem.Rows(myRowIndex).Cells(0).Value), Nothing, dgvListagem.Rows(myRowIndex).Cells(0).Value)
        Dim MovTipo As String = dgvListagem.Rows(myRowIndex).Cells(1).Value
        Dim Ativo As Boolean? = If(IsDBNull(dgvListagem.Rows(myRowIndex).DataBoundItem("Ativo")), Nothing, dgvListagem.Rows(myRowIndex).DataBoundItem("Ativo"))
        '
        If Inserir = True Then
            Try
                mBLL.Cartao_Inserir(MovTipo)
                Return True
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao inserir registro..." & vbNewLine &
                                ex.Message & vbNewLine &
                                "O seguinte registro não pôde ser salvo: " & MovTipo.ToUpper,
                                "Erro ao Salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        Else
            Try
                mBLL.Cartao_Update(IDMovTipo, MovTipo, Ativo)
                Return True
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao alterar registro..." & vbNewLine &
                                ex.Message & vbNewLine &
                                "O seguinte registro não pôde ser salvo: " & MovTipo.ToUpper,
                                "Erro ao Salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If
        '
    End Function
    '
    '
    ' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
    Public Function VerificaDuplicado(myRow As Integer, myNewValor As String) As Boolean
        '
        '---se não houver nenhum registro, Exit
        If dtOrigem.Rows.Count = 0 Then
            VerificaDuplicado = False
            Exit Function
        End If
        '---verifica todos os ROWS procurando registro igual
        For i = 0 To dtOrigem.Rows.Count - 1
            If i <> myRow Then
                If dtOrigem.Rows(i).Item(1).ToString.ToUpper = myNewValor Then
                    VerificaDuplicado = True
                    '
                    '--- Emite a mensagem de valor duplicado
                    MessageBox.Show("Já existe um Tipo de Cartão com a mesma descrição:" & vbNewLine &
                                    myNewValor.ToUpper,
                                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '
                End If
            End If
        Next i
        '
        '---se não encontrar retorna FALSE
        VerificaDuplicado = False
        '
    End Function
    '
#End Region
    '
#Region "LISTAGEM VALIDATION"
    '
    ' VALIDAÇÃO E MANUTENÇAO DA LISTAGEM
    Private Sub dgvListagem_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvListagem.CellBeginEdit
        If Sit <> EnumFlagEstado.NovoRegistro Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    Private Sub dgvListagem_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvListagem.CellValidating
        '
        ' Valida o entrada para a descrição não permitindo valores em branco
        If e.ColumnIndex = 1 Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                dgvListagem.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO não pode ficar vazia..."
                e.Cancel = True
                Exit Sub
            End If
        End If
        '
        '---procura por valores duplicados da descrição 
        If VerificaDuplicado(e.RowIndex, e.FormattedValue.ToString.ToUpper) Then
            dgvListagem.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO precisa ser EXCLUSIVA..."
            e.Cancel = True
            Exit Sub
        End If
        '
    End Sub
    '
    Private Sub dgvListagem_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellEndEdit
        '
        ' Limpa o erro da linha no caso do usuário pressionar ESC
        dgvListagem.Rows(e.RowIndex).ErrorText = String.Empty
        '
    End Sub
    '
    Private Sub dgvListagem_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvListagem.EditingControlShowing
        '
        '---restringe a entrada de dados para a coluna 'Forma de Cobrança'
        If Me.dgvListagem.CurrentCell.ColumnIndex = 1 And Not e.Control Is Nothing Then
            Dim tb As TextBox = CType(e.Control, TextBox)
            '---inclui um tratamento de evento para o controle TextBox---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
        '
    End Sub
    '
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '---Se o usuario pressionou a tecla ESC na edição ---
        If e.KeyChar = Convert.ToChar(27) Then
            If Sit <> EnumFlagEstado.RegistroSalvo Then
                e.Handled = True
                '---cancela a adição do registro
                If Sit = EnumFlagEstado.NovoRegistro Then dgvListagem.Rows.Remove(dgvListagem.CurrentRow)
                Get_Dados()
                Sit = EnumFlagEstado.RegistroSalvo
            End If
        End If
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        '
        If _procura = True And Sit = EnumFlagEstado.RegistroSalvo Then
            btnSalvar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ATALHOS NAVEGAÇÃO"
    '
    '------------------------------------------------------------------------------------------
    '-- CONVERTE A TECLA ESC EM CANCELAR
    '------------------------------------------------------------------------------------------
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnFechar_Click(New Object, New EventArgs)
        End If
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
        '
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
        '
    End Sub
    '
    Private Sub frmDespesaTipo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        '
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
