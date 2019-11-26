Imports CamadaBLL

Public Class frmFabricante
    Private dtFab As DataTable
	Private fBLL As New FabricanteBLL
	Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Private _formOrigem As Form
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
    '--- SUB NEW
    Sub New(formProcura As Boolean, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '-------------------------------------------------------------------------------
        '
        '--- Define o FormOrigem
        _formOrigem = formOrigem
        '
        '--- Define o texto do btn Fechar se for FormProcura
        If formProcura = True Then
            btnFechar.Text = "&Escolher"
        Else
            btnFechar.Text = "&Fechar"
        End If
		'
		GetFabricantes()
		PreencheListaFabricante()
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
	'
	'--- EVENTO LOAD
	Private Sub frmFabricante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		PreencheListaImagem()
	End Sub
	'
	'--- GET DATATABLE OF FABRICANTES
	Private Sub GetFabricantes()
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			dtFab = fBLL.GetFabricantes()
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao obter datatable de Fabricantes..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	' PREENCHE LISTAGEM
	Private Sub PreencheListaFabricante()
		'
		dgvFabricantes.Columns.Clear()
        dgvFabricantes.AutoGenerateColumns = False
        '
        '--- PROPRIEDADES DA LISTAGEM
        ' altera as propriedades importantes
        dgvFabricantes.MultiSelect = False
        dgvFabricantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvFabricantes.ColumnHeadersVisible = True
        dgvFabricantes.AllowUserToResizeRows = False
        dgvFabricantes.AllowUserToResizeColumns = False
        dgvFabricantes.RowHeadersVisible = True
        dgvFabricantes.RowHeadersWidth = 35
        dgvFabricantes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvFabricantes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvFabricantes.StandardTab = True
        '
        ' (1) COLUNA REG
        dgvFabricantes.Columns.Add("IDFabricante", "Reg.")
        With dgvFabricantes.Columns("IDFabricante")
            .DataPropertyName = "IDFabricante"
            .Width = 50
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA FABRICANTE
        dgvFabricantes.Columns.Add("Fabricante", "Fabricante")
        With dgvFabricantes.Columns("Fabricante")
            .DataPropertyName = "Fabricante"
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
        dgvFabricantes.Columns.Add(colImage)
        '
        ' (4) COLUNA ATIVO
        dgvFabricantes.Columns.Add("FabricanteAtivo", "FabricanteAtivo")
        With dgvFabricantes.Columns("FabricanteAtivo")
            .DataPropertyName = "FabricanteAtivo"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        dgvFabricantes.DataSource = dtFab
        '
    End Sub
	'
	Private Sub PreencheListaImagem()
		'
		For Each r As DataGridViewRow In dgvFabricantes.Rows
			'
			If r.Cells(3).Value = True Then
				r.Cells(2).Value = ImgAtivo
			Else
				r.Cells(2).Value = ImgInativo
			End If
			'
		Next
		'
	End Sub
	'
	' CONTROLE DA LISTAGEM
	Private Sub dgvFabricantes_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvFabricantes.CellBeginEdit
		'
		If Sit <> EnumFlagEstado.NovoRegistro Then
			Sit = EnumFlagEstado.Alterado
		End If
		'
	End Sub
	'
	Private Sub dgvFabricantes_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvFabricantes.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvFabricantes.HitTest(e.X, e.Y)
            dgvFabricantes.ClearSelection()

            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub

            ' seleciona o ROW
            dgvFabricantes.CurrentCell = dgvFabricantes.Rows(hit.RowIndex).Cells(1)
            dgvFabricantes.Rows(hit.RowIndex).Selected = True

            ' mostra o MENU ativar e desativar
            If dgvFabricantes.Columns(hit.ColumnIndex).Name = "Ativo" Then
                If dgvFabricantes.Rows(hit.RowIndex).Cells(3).Value = True Then
                    AtivarToolStripMenuItem.Enabled = False
                    DesativarToolStripMenuItem.Enabled = True
                Else
                    AtivarToolStripMenuItem.Enabled = True
                    DesativarToolStripMenuItem.Enabled = False
                End If
                ' revela menu
                MenuFab.Show(c.PointToScreen(e.Location))
            End If
        End If
    End Sub
    '
    Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvFabricantes.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = dtFab.Select("Fabricante = '" & dgvFabricantes.CurrentRow.Cells("Fabricante").Value & "'").First
        r("FabricanteAtivo") = True
        'dtFab.AcceptChanges()
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- altera a imagem
        dgvFabricantes.CurrentRow.Cells("Ativo").Value = ImgAtivo
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
    End Sub
    '
    Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesativarToolStripMenuItem.Click
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvFabricantes.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = dtFab.Select("Fabricante = '" & dgvFabricantes.CurrentRow.Cells("Fabricante").Value & "'").First
        r("FabricanteAtivo") = False
        'dtFab.AcceptChanges()
        If r.RowState = DataRowState.Unchanged Then
            r.SetModified()
        End If
        '
        '--- altera a imagem
        dgvFabricantes.CurrentRow.Cells("Ativo").Value = ImgInativo
        '
        '--- atualiza os botoes
        Sit = EnumFlagEstado.Alterado
    End Sub
	'
	' BOTOES DO FORMULARIO
	Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
		'
		'---adiciona novo ROW no datatable 
		dtFab.Rows.Add()
		Sit = EnumFlagEstado.NovoRegistro
		'
		' seleciona a cell
		dgvFabricantes.Focus()
		dgvFabricantes.CurrentCell = dgvFabricantes.Rows(dgvFabricantes.Rows.Count - 1).Cells(1)
		dgvFabricantes.BeginEdit(True)
		'
		'---adiciona a imagem no NOVO ROW
		dgvFabricantes.CurrentRow.Cells("Ativo").Value = My.Resources.NovoPeq
		'
	End Sub
	'
	' SALVAR O REGISTRO
	'-----------------------------------------------------------------------------------------------
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        If Sit = EnumFlagEstado.RegistroSalvo Then
            '--- Fecha o Form
            Me.Close()
            '
            '--- Verifica se existe outro form aberto para revelar o menuprincipal
            If Application.OpenForms.Count = 1 Then MostraMenuPrincipal()
            '
        ElseIf Sit = EnumFlagEstado.NovoRegistro Then
            '--- questiona ao usuario
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            '--- Se SIM Remove a Row
            dgvFabricantes.Rows.Remove(dgvFabricantes.CurrentRow)
            '
            '--- preenche novamente a listagem
            PreencheListaFabricante()
            Sit = EnumFlagEstado.RegistroSalvo
            PreencheListaImagem()
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            '--- questiona ao usuario
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            '--- Se SIM Cancela a edicao
            dgvFabricantes.CancelEdit()
            dtFab.RejectChanges()
            '
            '--- Preenche novamente a listagem
            PreencheListaFabricante()
            Sit = EnumFlagEstado.RegistroSalvo
            PreencheListaImagem()
            '
        End If
    End Sub
	'
	' SALVAR O REGISTRO
	'-----------------------------------------------------------------------------------------------
	Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
		'
		'-- variavel para informar o número de registros salvos
		Dim regSalvos As Integer = 0
		Dim newID As Integer = 0
		'
		For Each r As DataGridViewRow In dgvFabricantes.Rows
			'
			' verfica se já existe valor igual
			If dtFab.Rows(r.Index).RowState <> DataRowState.Unchanged Then
				If VerificaDuplicado(r.Index, dgvFabricantes.Rows(r.Index).Cells(1).Value) = True Then
					MessageBox.Show("Já existe uma Forma de Cobrança com a mesma descrição:" & vbNewLine &
									CStr(dgvFabricantes.Rows(r.Index).Cells(1).Value).ToUpper,
									"Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Continue For
				End If
			End If
			'
			Try
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				'---salva os registros
				If DirectCast(r.DataBoundItem, DataRowView).Row.RowState = DataRowState.Modified Then ' registro ALTERADO
					fBLL.ProdutoFabricante_Update(dgvFabricantes.Rows(r.Index).Cells(0).Value,
												  dgvFabricantes.Rows(r.Index).Cells(1).Value,
												  dgvFabricantes.Rows(r.Index).Cells(3).Value)
					regSalvos += 1
				ElseIf DirectCast(r.DataBoundItem, DataRowview).Row.RowState = DataRowState.Added Then ' registro NOVO
					newID = fBLL.ProdutoFabricante_Insert(dgvFabricantes.Rows(r.Index).Cells(1).Value)
					DirectCast(r.DataBoundItem, DataRowView).Item(0) = newID
					DirectCast(r.DataBoundItem, DataRowView).Item(2) = True
					regSalvos += 1
				End If
				'
			Catch ex As Exception
				MessageBox.Show("Uma exceção ocorreu ao Salvar registro do Fabricante: " & vbNewLine &
								CStr(dgvFabricantes.Rows(r.Index).Cells(1).Value).ToUpper & vbNewLine &
								ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				'--- Ampulheta OFF
				Cursor = Cursors.Default
			End Try
			'
		Next
		'
		'--- mensagem de sucesso---
		If regSalvos > 0 Then
			MessageBox.Show("Sucesso ao salvar registro(s) de Fabricante(s)" & vbNewLine &
							"Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
							IIf(regSalvos > 1, " registros", " registro"),
							"Registro(s) Salvo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
		'
		'---preencher a listagem com os novos valores
		PreencheListaFabricante()
		Sit = EnumFlagEstado.RegistroSalvo
		PreencheListaImagem()
		'
	End Sub
	'
	' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
	'-----------------------------------------------------------------------------------------------
	Public Function VerificaDuplicado(myRow As Integer, myNewValor As String) As Boolean
        '---se não houver nenhum registro, Exit
        If dtFab.Rows.Count = 0 Then
            VerificaDuplicado = False
            Exit Function
        End If
        '---verifica todos os ROWS procurando registro igual
        For i = 0 To dtFab.Rows.Count - 1
            If i = myRow Then Continue For '---se for a mesma ROW não verifica
            If dtFab.Rows(i).Item("Fabricante").ToString.ToUpper = myNewValor Then
                VerificaDuplicado = True
                Exit Function
            End If
        Next i
        '---se não encontrar retorna FALSE
        VerificaDuplicado = False
    End Function
    '
    '---CONTROLE DA EDIÇÃO DO DATAGRID
    '-----------------------------------------------------------------------------------------------
    Private Sub dgvFabricantes_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvFabricantes.CellValidating
        ' Valida o entrada para a descrição não permitindo valores em branco
        If dgvFabricantes.Columns(e.ColumnIndex).Name = "Fabricante" Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                dgvFabricantes.Rows(e.RowIndex).ErrorText = "O nome do Fabricante não pode ficar vazio..."
                e.Cancel = True
                Exit Sub
            End If
        End If
        '---procura por valores duplicados da descrição 
        If VerificaDuplicado(e.RowIndex, e.FormattedValue.ToString.ToUpper) Then
            MessageBox.Show("Já existe um Fabricante com a mesma descrição:" & vbNewLine &
                    e.FormattedValue.ToString.ToUpper,
                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvFabricantes.Rows(e.RowIndex).ErrorText = "O nome do Fabricante precisa ser EXCLUSIVO..."
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    '
    Private Sub dgvFabricantes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFabricantes.CellEndEdit
        ' Limpa o erro da linha no caso do usuário pressionar ESC
        dgvFabricantes.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub
    '
    Private Sub dgvFabricantes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvFabricantes.EditingControlShowing
        '---restringe a entrada de dados para a coluna 'Forma de Cobrança'
        If dgvFabricantes.CurrentCell.ColumnIndex = 1 And Not e.Control Is Nothing Then
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
                If Sit = EnumFlagEstado.NovoRegistro Then dgvFabricantes.Rows.Remove(dgvFabricantes.CurrentRow)
                PreencheListaFabricante()
                Sit = EnumFlagEstado.RegistroSalvo
            End If
        End If
    End Sub
    '
#Region "EFEITOS SUB FORMULARIO PADRAO"
    '
    '-- CONVERTE A TECLA ESC EM CANCELAR E (+) EM ADICIONAR
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            If btnFechar.Enabled = True Then
                btnFechar_Click(New Object, New EventArgs)
            End If
            '
        ElseIf e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            If btnNovo.Enabled = True Then
                btnNovo_Click(New Object, New EventArgs)
            End If
            '
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmAReceberEntradas_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region

End Class
