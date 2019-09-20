Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmFuncionarioProcurar
    '
    Private WithEvents listFunc As New List(Of clFuncionario)
    Private _formOrigem As Form
    Private _IDFilial As Integer
    Private IsOpened = False
    '
    '--- PROPRIEDADES DE RESPOSTA
    Property propFuncionario_Escolha As clFuncionario
    '
#Region "SUBNEW E LOAD"
    '
    '--- SUB NEW
    Public Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        CarregaCmbAtivo()
        _formOrigem = formOrigem
        _IDFilial = Obter_FilialPadrao()
        lblApelidoFilial.Text = ObterDefault("FilialDescricao")
        '
        FormataFuncionarios()
        GetData()
        FiltrarListagem()
        '
    End Sub
    '
    Private Sub frmFuncionarioProcurar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        IsOpened = True
    End Sub
    '
    '--- PREENCHE O COMBO ATIVO
    Private Sub CarregaCmbAtivo()
        '
        Dim dtAtivo As New DataTable
        '
        'Adiciona todas as possibilidades de instrucao
        dtAtivo.Columns.Add("Ativo")
        dtAtivo.Columns.Add("Texto")
        dtAtivo.Rows.Add(New Object() {True, "Ativo"})
        dtAtivo.Rows.Add(New Object() {False, "Inativo"})
        '
        With cmbAtivo
            .DataSource = dtAtivo
            .ValueMember = "Ativo"
            .DisplayMember = "Texto"
            .SelectedValue = True
        End With
        '
    End Sub
    '
#End Region '/ SUBNEW E LOAD
    '
#Region "LISTAGEM GET E CONTROLE"
    '
    '--- GET DATA FOR LIST OF FUNCIONARIOS
    '----------------------------------------------------------------------------------
    Private Sub GetData()
        '
        Dim fBLL As New FuncionarioBLL
        '
        '--- Preenche o Datatable
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            Dim Ativo As Boolean = cmbAtivo.SelectedValue
            listFunc = fBLL.GetFuncionarios(_IDFilial, Ativo)
            '
        Catch ex As Exception
            MessageBox.Show("Não foi possível apresentar a lista de funcionários..." & vbNewLine &
                            ex.Message,
                            "Procurar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    '--------------------------------------------------------------------------------------------------------
    ' PREENCHE A LISTAGEM
    '--------------------------------------------------------------------------------------------------------
    Private Sub FormataFuncionarios()
        '
        With dgvFuncionarios
            .Columns.Clear()
            .AutoGenerateColumns = False
            .DataSource = listFunc
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
        dgvFuncionarios.Columns.Add("clnID", "Reg.:")
        With dgvFuncionarios.Columns("clnID")
            .DataPropertyName = "IDPessoa"
            .Width = 60
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            Dim newPadding As New Padding(5, 0, 0, 0)
            .DefaultCellStyle.Padding = newPadding
        End With
        '
        ' (2) COLUNA NOME
        dgvFuncionarios.Columns.Add("clnCadastro", "Funcionário:")
        With dgvFuncionarios.Columns("clnCadastro")
            .DataPropertyName = "Cadastro"
            .Width = 220
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    '-------------------------------------------------------------------------------------------------
    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFuncionarios.CellDoubleClick
        btnEditar_Click(New Object, New EventArgs)
    End Sub
    '
#End Region '/ LISTAGEM GET E CONTROLE
    '
#Region "BUTTONS FUNCTION"
    '
    '--- FECHAR QUANDO PRESS ESC
    '----------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            '
            e.Handled = True
            btnFechar_Click(New Object, New EventArgs)
            '
        End If
        '
    End Sub
	'
	' ALTERAR A FILIAL SEDE DO FUNCIONARIO
	'----------------------------------------------------------------------------------
	Private Sub btnAlterarFilial_Click(sender As Object, e As EventArgs) Handles btnAlterarFilial.Click
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Abre o frmFilial
			Dim fFil As New frmFilialEscolher(Me, _IDFilial)
			'
			fFil.ShowDialog()
			'
			If fFil.DialogResult = DialogResult.Cancel Then Exit Sub
			'
			If fFil.propFilial.IDPessoa <> _IDFilial Then
				_IDFilial = fFil.propFilial.IDPessoa
				lblApelidoFilial.Text = fFil.propFilial.ApelidoFilial
				GetData()
				FiltrarListagem()
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de procurar filial..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- EDITAR
	'----------------------------------------------------------------------------------
	Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
		'
		'--- verifica se existe algum item selecionado
		If dgvFuncionarios.SelectedRows.Count = 0 Then
			MessageBox.Show("Não existe nenhum Funcionário selecionado...", "Escolher",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			dgvFuncionarios.Focus()
			Exit Sub
		End If
		'
		'--- Seleciona o Funcionario
		Dim func As clFuncionario = dgvFuncionarios.SelectedRows(0).DataBoundItem
		'
		'--- Ampulheta ON
		Cursor = Cursors.WaitCursor
		'
		Dim frmF As New frmFuncionario(func)
		frmF.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
		Close()
		frmF.Show()
		'
		'--- Ampulheta OFF
		Cursor = Cursors.Default
		'
	End Sub
	'
	'--- FECHAR
	'----------------------------------------------------------------------------------
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
		Close()
		MostraMenuPrincipal()
	End Sub
	'
	'--- ADICIONAR
	'----------------------------------------------------------------------------------
	Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim frmF As New frmFuncionario(New clFuncionario, Me)
			'
			If Not frmF.InsertNewCNP(Me) Then
				frmF.Dispose()
				Exit Sub
			End If
			'
			frmF.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).First
			Close()
			frmF.Show()
			'
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao inserir novo Funcionário..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			'
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Sub
	'
#End Region '/ BUTTONS FUNCTION
	'
#Region "EFEITO VISUAL"
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
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAReceberItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.Silver
            End If
        Next
        '
    End Sub
    '
    Private Sub frmAReceberItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.SlateGray
            End If
        Next
        '
    End Sub
    '
    '--- MOVE BTN FILIAL
    '----------------------------------------------------------------------------------
    Private Sub lblApelidoFilial_SizeChanged(sender As Object, e As EventArgs) Handles lblApelidoFilial.SizeChanged
        Dim newX As Integer = lblApelidoFilial.Location.X + lblApelidoFilial.Size.Width + 5
        btnAlterarFilial.Location = New Point(newX, btnAlterarFilial.Location.Y)
    End Sub
    '
#End Region '/ EFEITO VISUAL
    '
#Region "FILTRO LISTAGEM"
    '
    '--- FILTRAR LISTAGEM
    Private Sub FiltrarListagem()
        dgvFuncionarios.DataSource = listFunc.FindAll(AddressOf FindForn)
    End Sub
    '
    Private Function FindForn(ByVal T As clFuncionario) As Boolean
        '
        If T.Cadastro.ToLower Like "*" & txtProcura.Text.ToLower & "*" Then
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
    Private Sub cmbAtivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAtivo.SelectedValueChanged
        '
        If Not IsOpened Then Exit Sub
        '
        GetData()
        FiltrarListagem()
        '
    End Sub
	'
#End Region '/ FILTRO LISTAGEM
	'
End Class
