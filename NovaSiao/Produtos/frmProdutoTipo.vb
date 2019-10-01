Imports CamadaBLL
'
Public Class frmProdutoTipo
	'Private dtTipo, dtSubTipo, dtCat As DataTable
	Private listTipo, listSubTipo, listCat As List(Of ClassTipo)
	Private bindTipo, bindSubTipo, bindCat As New BindingSource
	'
	Private ImgInativo As Image = My.Resources.block
	Private ImgAtivo As Image = My.Resources.accept
	Private ImgNew As Image = My.Resources.Adicionar1
	'
	Private Abrindo As Boolean = True
    Private _formProcura As ProcurarPor
    Property ItemEscolhido() As Integer? '--- quando o form fechar informa o Tipo, SubTipo ou Categoria
    Private _tipoPadrao As Integer?
    Private pTipoBLL As New TipoSubTipoCategoriaBLL
    Dim _Sit As Byte
	'
#Region "CLASS TIPO"
	'
	Private Class ClassTipo
		'
		Sub New()
			ID = Nothing
			IsNew = True
			IsUpdated = False
			Ativo = True
		End Sub
		'
		Property ID As Integer?
		Property IDOrigem As Integer
		Property Descricao As String
		Property Ativo As Boolean
		Property IsNew As Boolean
		Property IsUpdated As Boolean
		'
	End Class
	'
#End Region '/ CLASS TIPO
	'
#Region "LOAD"
	'
	Sub New(formProcura As ProcurarPor, Optional tipoPadrao As Integer? = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        GetListaTipo()
        Sit = EnumFlagEstado.RegistroSalvo
        _formProcura = formProcura
        '
        lblTitulo.Text = "Controle de Tipos de Produto"
        '
        '--- Formata as Listas Insert Columns
        FormataListaTipo()
        FormataListaSubTipo()
        FormataListaCategoria()
        '
        '--- Define Tipo and obtain SubTipo and Tipo For TipoPadrao
        propTipoPadrao = tipoPadrao
        '
        '--- Se houver um tipo selecionado
        If Not IsNothing(propTipoPadrao) Then
            '
            '--- Seleciona o Tipo informado no tipoPadrao
            dgvTipos.ClearSelection()
            For Each row As DataGridViewRow In dgvTipos.Rows
                '
                For Each cell As DataGridViewCell In row.Cells
                    If cell.ColumnIndex = 0 AndAlso cell.Value = propTipoPadrao Then
                        dgvTipos.CurrentCell = cell
                        cell.Style.BackColor = Color.Yellow
                        dgvTipos.Rows(cell.RowIndex).Cells(1).Style.BackColor = Color.Yellow
                        dgvTipos.Rows(cell.RowIndex).Cells(2).Style.BackColor = Color.Yellow
                        '
                        '--- altera as labels
                        lblTipo1.Text = "Classificações de " & row.Cells(1).Value.ToString.ToUpper
                        lblTipo2.Text = "Categorias de " & row.Cells(1).Value.ToString.ToUpper
                        '
                    End If
                Next
                '
            Next
            '
        End If
        '
        '--- Abre o form na guia correta pela PROCURARPOR
        If _formProcura <> ProcurarPor.None Then
            Select Case _formProcura
                Case ProcurarPor.Tipo
                    tabPrincipal.SelectedTab = VTabTipos
                Case ProcurarPor.SubTipo
                    tabPrincipal.SelectedTab = VTabSubTipo
                Case ProcurarPor.Categoria
                    tabPrincipal.SelectedTab = VTabCategoria
            End Select
        End If
        '
        '
    End Sub
    '
    Private Sub frmProdutoTipo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Abrindo = False
    End Sub
    '
    ' PROPRIEDADE SIT
    Private Property Sit As EnumFlagEstado
        '
        Get
            Sit = _Sit
        End Get
        '
        Set(value As EnumFlagEstado)
            _Sit = value
            Select Case _Sit
                Case EnumFlagEstado.RegistroSalvo
                    btnSalvar.Enabled = False
                    If _formProcura <> ProcurarPor.None Then
                        btnFechar.Text = "&Escolher"
                    Else
                        btnFechar.Text = "&Fechar"
                    End If
                    AtualizarTabs(True)
                Case EnumFlagEstado.Alterado
                    btnSalvar.Enabled = True
                    btnFechar.Text = "&Cancelar"
                    AtualizarTabs(False)
                Case EnumFlagEstado.NovoRegistro
                    btnSalvar.Enabled = True
                    btnFechar.Text = "&Cancelar"
                    AtualizarTabs(False)
            End Select
            '
        End Set
        '
    End Property
    '
    '--- Propriedade que declara o tipo de procura
    Public Property propTipoPadrao() As Integer?
        '
        Get
            Return _tipoPadrao
        End Get
        '
        Set(ByVal value As Integer?)
            '
            '--- Change value only new value is diferent
            If If(value, -1) <> If(_tipoPadrao, -1) Then
                _tipoPadrao = value
                GetListaSubTipo()
                GetListaCategoria()
            End If
            '
        End Set
        '
    End Property
    '
    Enum ProcurarPor
        None = 0
        Tipo = 1
        SubTipo = 2
        Categoria = 3
    End Enum
	'
#End Region
	'
#Region "CONTROLE DOS DATAGRID"
	'
	' PREENCHE LISTAGEM TIPOS
	Private Sub GetListaTipo()
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim dtTipo As DataTable = pTipoBLL.ProdutoTipo_GET_WithWhere()
			'
			listTipo = New List(Of ClassTipo)
			'
			For Each r As DataRow In dtTipo.Rows
				Dim item As New ClassTipo With {
					.ID = r("IDProdutoTipo"),
					.IDOrigem = r("IDProdutoTipo"),
					.Descricao = r("ProdutoTipo"),
					.Ativo = r("Ativo"),
					.IsUpdated = False,
					.IsNew = False
				}
				listTipo.Add(item)
			Next
			'
			bindTipo.DataSource = listTipo
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Evento: Obter Lista de Tipos de Produto..." & vbNewLine &
			ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- FORMATA LISTA TIPO
	Private Sub FormataListaTipo()
		'
		dgvTipos.Columns.Clear()
		dgvTipos.AutoGenerateColumns = False
		'
		dgvTipos.DataSource = bindTipo
		'
		' (1) COLUNA REG
		dgvTipos.Columns.Add("clnIDProdutoTipo", "Reg.")
		With dgvTipos.Columns("clnIDProdutoTipo")
			.DataPropertyName = "ID"
			.Width = 50
			.Visible = True
			.ReadOnly = True
			.Resizable = False
			.DefaultCellStyle.Format = "00"
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With

		' (2) COLUNA TIPOS
		dgvTipos.Columns.Add("clnProdutoTipo", "Tipo")
		With dgvTipos.Columns("clnProdutoTipo")
			.DataPropertyName = "Descricao"
			.Width = 200
			.Visible = True
			.ReadOnly = False
			.Resizable = False
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With

		' (3) Coluna da imagem
		Dim colImage As New DataGridViewImageColumn
		With colImage
			.Name = "clnTipoAtivoImagem"
			.HeaderText = "Ativo"
			.Resizable = False
			.Width = 60
			.ImageLayout = DataGridViewImageCellLayout.Zoom
		End With
		dgvTipos.Columns.Add(colImage)

		' (4) COLUNA ATIVO
		dgvTipos.Columns.Add("clnTipoAtivo", "Ativo")
		With dgvTipos.Columns("clnTipoAtivo")
			.DataPropertyName = "Ativo"
			.Width = 50
			.Visible = False
			.ReadOnly = True
			.Resizable = False
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With
		'
	End Sub
	'
	'--- FORMATA LISTA SUBTIPO
	Private Sub FormataListaSubTipo()
        '
        dgvSubTipo.Columns.Clear()
		dgvSubTipo.AutoGenerateColumns = False
		'
		dgvSubTipo.DataSource = bindSubTipo
		'
		' (1) COLUNA REG
		dgvSubTipo.Columns.Add("clnIDProdutoSubTipo", "Reg.")
        With dgvSubTipo.Columns("clnIDProdutoSubTipo")
			.DataPropertyName = "ID"
			.Width = 50
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        ' (2) COLUNA SUB TIPOS
        dgvSubTipo.Columns.Add("clnProdutoSubTipo", "Classificação")
        With dgvSubTipo.Columns("clnProdutoSubTipo")
			.DataPropertyName = "Descricao"
			.Width = 200
            .Visible = True
            .ReadOnly = False
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        ' (3) Coluna da imagem
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .Name = "clnSubTipoAtivoImagem"
            .HeaderText = "Ativo"
            .Resizable = False
            .Width = 60
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        End With
        dgvSubTipo.Columns.Add(colImage)

        ' (4) COLUNA ATIVO
        dgvSubTipo.Columns.Add("clnSubTipoAtivo", "Ativo")
        With dgvSubTipo.Columns("clnSubTipoAtivo")
            .DataPropertyName = "Ativo"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
    End Sub
    '
    ' PREENCHE LISTAGEM SUB TIPOS
    Private Sub GetListaSubTipo()
        '
        If dgvTipos.Rows.Count = 0 Then Exit Sub
        If IsNothing(propTipoPadrao) Then Exit Sub
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
			'
			Dim query As String = "IDProdutoTipo = " & propTipoPadrao
			Dim dtSubTipo As DataTable = pTipoBLL.ProdutoSubTipo_GET_WithWhere(query, "ProdutoSubTipo")
			'
			listSubTipo = New List(Of ClassTipo)
			'
			For Each r As DataRow In dtSubTipo.Rows
				Dim item As New ClassTipo With {
					.ID = r("IDProdutoSubTipo"),
					.IDOrigem = r("IDProdutoTipo"),
					.Descricao = r("ProdutoSubTipo"),
					.Ativo = r("Ativo"),
					.IsUpdated = False,
					.IsNew = False
				}
				listSubTipo.Add(item)
			Next
			'
			bindSubTipo.DataSource = listSubTipo
			'
		Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter SubTipos de Produtos..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
		'
	End Sub
    '
    '--- FORMATA LISTA CATEGORIA
    Private Sub FormataListaCategoria()
        '
        dgvCategoria.Columns.Clear()
		dgvCategoria.AutoGenerateColumns = False
		dgvCategoria.DataSource = bindCat
		'
		' (1) COLUNA REG
		dgvCategoria.Columns.Add("clnIDCategoria", "Reg.")
        With dgvCategoria.Columns("clnIDCategoria")
			.DataPropertyName = "ID"
			.Width = 50
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        ' (2) COLUNA CATEGORIA
        dgvCategoria.Columns.Add("clnProdutoCategoria", "Categoria")
        With dgvCategoria.Columns("clnProdutoCategoria")
			.DataPropertyName = "Descricao"
			.Width = 200
            .Visible = True
            .ReadOnly = False
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        ' (3) Coluna da imagem
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .Name = "clnCatAtivoImagem"
            .HeaderText = "Ativo"
            .Resizable = False
            .Width = 60
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        End With
        dgvCategoria.Columns.Add(colImage)

        ' (4) COLUNA ATIVO
        dgvCategoria.Columns.Add("clnCatAtivo", "Ativo")
        With dgvCategoria.Columns("clnCatAtivo")
            .DataPropertyName = "Ativo"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
    End Sub
    '
    ' PREENCHE LISTAGEM CATEGORIAS
    Private Sub GetListaCategoria()
        '
        If dgvTipos.Rows.Count = 0 Then Exit Sub
        If IsNothing(propTipoPadrao) Then Exit Sub
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim query As String = "IDProdutoTipo = " & propTipoPadrao
			Dim dtCat As DataTable = pTipoBLL.ProdutoCategoria_GET_WithWhere(query, "ProdutoCategoria")
			'
			listCat = New List(Of ClassTipo)
			'
			For Each r As DataRow In dtCat.Rows
				Dim item As New ClassTipo With {
					.ID = r("IDCategoria"),
					.IDOrigem = r("IDProdutoTipo"),
					.Descricao = r("ProdutoCategoria"),
					.Ativo = r("Ativo"),
					.IsUpdated = False,
					.IsNew = False
				}
				listCat.Add(item)
			Next
			'
			bindCat.DataSource = listCat
			'
		Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter Lista de Categorias de Produto..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
		'
	End Sub
    '
    ' PREENCHE AS IMAGENS DA LISTA
    '
    Private Sub dgvProdutos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
        Handles dgvTipos.CellFormatting,
                dgvSubTipo.CellFormatting,
                dgvCategoria.CellFormatting

        If e.ColumnIndex = 2 Then
            Dim myLista As DataGridView = DirectCast(sender, DataGridView)
			Dim r As ClassTipo = myLista.Rows(e.RowIndex).DataBoundItem
			'
			If r.Ativo = True Then
				e.Value = ImgAtivo
			ElseIf r.Ativo = False Then
				e.Value = ImgInativo
            End If
            '
        End If
    End Sub
    '
    ' AO EDITAR DOS DATAGRID
    Private Sub dgv_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvTipos.CellBeginEdit,
            dgvTipos.CellBeginEdit, dgvSubTipo.CellBeginEdit
        If Sit <> EnumFlagEstado.NovoRegistro Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    '--- AO ENTRAR NA ROW DO TIPO ALTERAR SUBTIPOS E CATEGORIAS
    Private Sub dgvTipos_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTipos.RowValidated
        '
        If Not IsDBNull(dgvTipos.Rows(e.RowIndex).Cells(0).Value) AndAlso Abrindo = False Then
            '
            propTipoPadrao = dgvTipos.Rows(e.RowIndex).Cells(0).Value
            '
            If Not IsNothing(dgvTipos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                lblTipo1.Text = "Classificações de " & dgvTipos.Rows(e.RowIndex).Cells(1).Value.ToString.ToUpper
                lblTipo2.Text = "Categorias de " & dgvTipos.Rows(e.RowIndex).Cells(1).Value.ToString.ToUpper
            End If
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLE DOS BOTOES DE ACAO"
    '
    ' BOTAO NOVO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
		'
		Select Case tabPrincipal.SelectedIndex
			'
			Case 0 ' Adicionar TIPO
				'
				'---adiciona novo ROW no datatable 
				bindTipo.AddNew()
				'
				' seleciona a cell
				dgvTipos.Focus()
				dgvTipos.CurrentCell = dgvTipos.Rows(dgvTipos.Rows.Count - 1).Cells(1)
				dgvTipos.BeginEdit(True)
				'
				'---adiciona a imagem no NOVO ROW
				dgvTipos.CurrentRow.Cells(2).Value = ImgNew
				'
			Case 1 ' Adicionar SubTipo
				'
				'---adiciona novo ROW no datatable 
				bindSubTipo.AddNew()
				'
				' seleciona a cell
				dgvSubTipo.Focus()
				dgvSubTipo.CurrentCell = dgvSubTipo.Rows(dgvSubTipo.Rows.Count - 1).Cells(1)
				dgvSubTipo.BeginEdit(True)
				'
				'---adiciona a imagem no NOVO ROW
				dgvSubTipo.CurrentRow.Cells(2).Value = ImgNew
				'
			Case 2 ' Adicionar Categoria
				'
				'---adiciona novo ROW no datatable 
				bindCat.AddNew()
				'
				' seleciona a cell
				dgvCategoria.Focus()
				dgvCategoria.CurrentCell = dgvCategoria.Rows(dgvCategoria.Rows.Count - 1).Cells(1)
				dgvCategoria.BeginEdit(True)
				'
				'---adiciona a imagem no NOVO ROW
				dgvCategoria.CurrentRow.Cells(2).Value = ImgNew
				'
		End Select
		'
		Sit = EnumFlagEstado.NovoRegistro
		'
	End Sub
    '
    ' BOTAO FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        '---pergunta ao usuário se deseja fechar
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Me.Close()
            '
            If Application.OpenForms.Count = 1 Then
                MostraMenuPrincipal()
            End If
            '
            Exit Sub
        ElseIf Sit = EnumFlagEstado.NovoRegistro Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        ElseIf Sit = EnumFlagEstado.Alterado Then
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        End If
        '
        '---efetua o cancelamento das edições feitas
        Select Case tabPrincipal.SelectedIndex
            Case 0
                If Sit = EnumFlagEstado.NovoRegistro Then
                    dgvTipos.Rows.Remove(dgvTipos.CurrentRow)
                Else
                    dgvTipos.CancelEdit()
                End If
                '
                GetListaTipo()
            Case 1
                If Sit = EnumFlagEstado.NovoRegistro Then
                    dgvSubTipo.Rows.Remove(dgvSubTipo.CurrentRow)
                Else
                    dgvSubTipo.CancelEdit()
                End If
                '
                GetListaSubTipo()
            Case 2
                If Sit = EnumFlagEstado.NovoRegistro Then
                    dgvCategoria.Rows.Remove(dgvCategoria.CurrentRow)
                Else
                    dgvCategoria.CancelEdit()
                End If
                '
                GetListaCategoria()
        End Select
        '
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    ' BOTAO SALVAR
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        Select Case tabPrincipal.SelectedIndex
            Case 0 ' Salvar TIPO
                SalvarTipo()
            Case 1 ' Salvar SubTipo
                SalvarSubTipo()
            Case 2 ' Salvar Categoria
                SalvarCategoria()
        End Select
        '
    End Sub
    '
    Private Sub SalvarTipo()
		'
		Dim regSalvos As Integer = 0 '--> variavel para informar o número de registros salvos
		'
		For Each r As DataGridViewRow In dgvTipos.Rows
			'
			' verfica se já existe valor igual
			If listTipo.Exists(Function(x) x.Descricao = r.Cells(1).Value And x.ID <> r.Cells(0).Value) Then
				AbrirDialog("Já existe um Tipo de Produto com a mesma descrição:" & vbNewLine &
							CStr(r.Cells(1).Value).ToUpper,
							"Valor Duplicado",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Exclamation)
				Continue For
			End If
			'
			'---salva os registros
			Try
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				Dim item As ClassTipo = DirectCast(r.DataBoundItem, ClassTipo)
				'
				If item.IsUpdated Then
					'
					pTipoBLL.ProdutoTipo_Update(r.Cells(0).Value,
												r.Cells(1).Value,
												r.Cells(3).Value)
					regSalvos += 1
					item.IsUpdated = False
					'
				ElseIf item.IsNew Then
					'
					pTipoBLL.ProdutoTipo_Insert(r.Cells(1).Value)
					regSalvos += 1
					item.IsNew = False
					'
				End If
				'
			Catch ex As Exception
				AbrirDialog("O seguinte registro não pôde ser salvo:" & vbNewLine &
							CStr(r.Cells(1).Value).ToUpper,
							"Erro ao Salvar",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Exclamation)
				regSalvos -= 1
            Finally
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
            '
        Next
		'
		'--- mensagem de sucesso---
		If regSalvos > 0 Then
			AbrirDialog("Sucesso ao salvar registro(s) de Tipo de Produto" & vbNewLine &
						"Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
						IIf(regSalvos > 1, " registros", " registro"),
						"Registro(s) Salvo(s)",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Information)
		End If
		'
		'---preencher a listagem com os novos valores
		GetListaTipo()
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    Private Sub SalvarSubTipo()
        '
        '-- variavel para informar o número de registros salvos
        Dim regSalvos As Integer = 0
		'
		For Each r As DataGridViewRow In dgvSubTipo.Rows
			'
			' verfica se já existe valor igual
			If listSubTipo.Exists(Function(x) x.Descricao = r.Cells(1).Value And x.ID <> r.Cells(0).Value) Then
				AbrirDialog("Já existe uma Classificação de Produto com a mesma descrição:" & vbNewLine &
								CStr(r.Cells(1).Value).ToUpper,
								"Valor Duplicado",
								frmDialog.DialogType.OK,
								frmDialog.DialogIcon.Exclamation)
				Continue For
			End If
			'
			'---salva os registros
			Try
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				Dim item As ClassTipo = DirectCast(r.DataBoundItem, ClassTipo)
				'
				If item.IsUpdated Then
					'
					pTipoBLL.ProdutoSubTipo_Update(r.Cells(0).Value, r.Cells(1).Value, r.Cells(3).Value)
					regSalvos += 1
					item.IsUpdated = False
					'
				ElseIf item.IsNew Then
					'
					pTipoBLL.ProdutoSubTipo_Insert(r.Cells(1).Value, propTipoPadrao)
					regSalvos += 1
					item.IsNew = False
					'
				End If
				'
			Catch ex As Exception
				AbrirDialog("O seguinte registro não pôde ser salvo:" & vbNewLine &
							CStr(r.Cells(1).Value).ToUpper,
							"Erro ao Salvar",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Exclamation)
				regSalvos -= 1
			Finally
				'
				'--- Ampulheta OFF
				Cursor = Cursors.Default
				'
			End Try
		Next
		'
		'--- mensagem de sucesso---
		If regSalvos > 0 Then
			AbrirDialog("Sucesso ao salvar registro(s) de Classificação de Produto" & vbNewLine &
						"Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
						IIf(regSalvos > 1, " registros", " registro"),
						"Registro(s) Salvo(s)",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Information)
		End If
		'
		'---preencher a listagem com os novos valores
		GetListaSubTipo()
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
	'
	Private Sub SalvarCategoria()
		'
		'-- variavel para informar o número de registros salvos
		Dim regSalvos As Integer = 0
		'
		For Each r As DataGridViewRow In dgvCategoria.Rows
			'
			' verfica se já existe valor igual
			If listCat.Exists(Function(x) x.Descricao = r.Cells(1).Value And x.ID <> r.Cells(0).Value) Then
				AbrirDialog("Já existe uma Categoria de Produto com a mesma descrição:" & vbNewLine &
							CStr(r.Cells(1).Value).ToUpper,
							"Valor Duplicado",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Exclamation)
				Continue For
			End If
			'
			'---salva os registros
			Try
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				Dim item As ClassTipo = DirectCast(r.DataBoundItem, ClassTipo)
				'
				If item.IsUpdated Then
					'
					pTipoBLL.ProdutoCategoria_Update(r.Cells(0).Value, r.Cells(1).Value, r.Cells(3).Value)
					regSalvos += 1
					item.IsUpdated = False
					'
				ElseIf item.IsNew Then
					'
					pTipoBLL.ProdutoCategoria_Insert(r.Cells(1).Value, propTipoPadrao)
					regSalvos += 1
					item.IsNew = False
					'
				End If
				'
			Catch ex As Exception
				'
				AbrirDialog("O seguinte registro não pôde ser salvo:" & vbNewLine &
							CStr(r.Cells(1).Value).ToUpper,
							"Erro ao Salvar",
							frmDialog.DialogType.OK,
							frmDialog.DialogIcon.Exclamation)
				regSalvos -= 1
				'
			Finally
				'
				'--- Ampulheta OFF
				Cursor = Cursors.Default
				'
			End Try
		Next
		'
		'--- mensagem de sucesso---
		If regSalvos > 0 Then
			AbrirDialog("Sucesso ao salvar registro(s) de Categoria de Produto" & vbNewLine &
						"Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
						IIf(regSalvos > 1, " registros", " registro"),
						"Registro(s) Salvo(s)",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Information)
		End If
		'
		'---preencher a listagem com os novos valores
		GetListaCategoria()
		Sit = EnumFlagEstado.RegistroSalvo
		'
	End Sub
	'
#End Region
	'
#Region "VALIDAÇÃO"
	'
	' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
	Private Function VerificaDuplicado(newDescricao As String, clTipo As ClassTipo, myList As List(Of ClassTipo)) As Boolean
		'
		'---se não houver nenhum registro, return FALSE
		If myList Is Nothing OrElse myList.Count = 0 Then
			Return False
		End If
		'
		'---verifica todos os ITENS procurando registro igual
		If IsNothing(clTipo.ID) Then
			'
			Dim item As ClassTipo = myList.FirstOrDefault(Function(x) If(x.Descricao, "").ToUpper = newDescricao.ToUpper)
			If item IsNot Nothing AndAlso Not item.Equals(clTipo) Then
				Return True
			End If
			'
		Else
			If myList.Exists(Function(x) x.Descricao.ToUpper = newDescricao.ToUpper And x.ID <> clTipo.ID) Then
				Return True
			End If
		End If
		'
		'---se não encontrar retorna FALSE
		Return False
		'
	End Function
	'
	Private Sub ValidaDescricao_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvTipos.CellValidating,
            dgvSubTipo.CellValidating, dgvCategoria.CellValidating
        '
        If Abrindo = True Then Exit Sub
		If e.ColumnIndex <> 1 Then Exit Sub
		'
		' Valida o entrada para a descrição não permitindo valores em branco
		Dim myList As DataGridView = DirectCast(sender, DataGridView)
		'
		If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
			myList.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO da Conta não pode ficar vazia..."
			e.Cancel = True
			Exit Sub
		End If
		'
		'---procura por valores duplicados da descrição 
		Dim verDup As Boolean
        Dim strTab As String = ""
        '
        Select Case myList.Name
			Case "dgvTipos"
				verDup = VerificaDuplicado(e.FormattedValue.ToString.ToUpper, dgvTipos.Rows(e.RowIndex).DataBoundItem, listTipo)
				strTab = "Tipo de Produto"
            Case "dgvSubTipo"
				verDup = VerificaDuplicado(e.FormattedValue.ToString.ToUpper, dgvSubTipo.Rows(e.RowIndex).DataBoundItem, listSubTipo)
				strTab = "Classificação de Produto"
            Case "dgvCategoria"
				verDup = VerificaDuplicado(e.FormattedValue.ToString.ToUpper, dgvCategoria.Rows(e.RowIndex).DataBoundItem, listCat)
				strTab = "Categoria de Produto"
        End Select
		'
		If verDup Then
			'
			AbrirDialog("Já existe um Registro de " & strTab & " com a mesma descrição:" & vbNewLine & vbNewLine &
						e.FormattedValue.ToString.ToUpper,
						"Valor Duplicado",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			'
			myList.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO de " & strTab & " precisa ser EXCLUSIVA..."
			e.Cancel = True
			Exit Sub
			'
		End If
		'
	End Sub
    '
    Private Sub EndEdit_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTipos.CellEndEdit,
            dgvSubTipo.CellEndEdit, dgvCategoria.CellEndEdit
		'
		Dim myList As DataGridView = DirectCast(sender, DataGridView)
		'
		' Limpa o erro da linha no caso do usuário pressionar ESC
		myList.Rows(e.RowIndex).ErrorText = String.Empty
		'
	End Sub

    Private Sub AoEditar_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTipos.EditingControlShowing,
            dgvSubTipo.EditingControlShowing, dgvCategoria.EditingControlShowing
		'
		'--- GET DATAGRID
		Dim myList As DataGridView = DirectCast(sender, DataGridView)
		'
		If myList.CurrentCell.ColumnIndex = 1 And Not e.Control Is Nothing Then
			'
			'--- marca IsUpdated
			If myList.CurrentRow.DataBoundItem.ID IsNot Nothing Then myList.CurrentRow.DataBoundItem.IsUpdated = True
			'
			'---inclui um tratamento de evento para o controle TextBox---
			Dim tb As TextBox = CType(e.Control, TextBox)
			AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
			'
		End If
		'
	End Sub
    '
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
		'
		'---Se o usuario pressionou a tecla ESC na edição ---
		If e.KeyChar = Convert.ToChar(27) Then
			'
			If Sit <> EnumFlagEstado.RegistroSalvo Then
				e.Handled = True
				'
				'---cancela a adição do registro
				Select Case tabPrincipal.SelectedIndex
					Case 0 ' cancela TIPO
						If Sit = EnumFlagEstado.NovoRegistro Then dgvTipos.Rows.Remove(dgvTipos.CurrentRow)
						GetListaTipo()
					Case 1 ' cancela SubTipo
						If Sit = EnumFlagEstado.NovoRegistro Then dgvSubTipo.Rows.Remove(dgvSubTipo.CurrentRow)
						GetListaSubTipo()
					Case 2 ' cancela Categoria
						If Sit = EnumFlagEstado.NovoRegistro Then dgvCategoria.Rows.Remove(dgvCategoria.CurrentRow)
						GetListaCategoria()
				End Select
				'
				Sit = EnumFlagEstado.RegistroSalvo
				'
			End If
			'
		End If
		'
	End Sub
    '
#End Region
    '
#Region "CONTROLE DA TAB"
    '
    Private Sub tabPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPrincipal.SelectedIndexChanged
        '
        Select Case tabPrincipal.SelectedIndex
            Case 0
                btnNovo.Text = "&Novo Tipo"
            Case 1
                btnNovo.Text = "&Nova Classificação"
            Case 2
                btnNovo.Text = "&Nova Categoria"
        End Select
        '
    End Sub
    '
    Private Sub AtualizarTabs(myTabEstado As Boolean)
        '
        If myTabEstado = False Then
            Select Case tabPrincipal.SelectedIndex
                Case 0
                    tabPrincipal.TabPages(0).Enabled = True
                    tabPrincipal.TabPages(1).Enabled = False
                    tabPrincipal.TabPages(2).Enabled = False
                Case 1
                    tabPrincipal.TabPages(0).Enabled = False
                    tabPrincipal.TabPages(1).Enabled = True
                    tabPrincipal.TabPages(2).Enabled = False
                Case 2
                    tabPrincipal.TabPages(0).Enabled = False
                    tabPrincipal.TabPages(1).Enabled = False
                    tabPrincipal.TabPages(2).Enabled = True
            End Select
        Else
            For Each Tb In tabPrincipal.TabPages
                Tb.Enabled = True
            Next
        End If
        '
    End Sub
    '
    ' CRIA TECLA DE ATALHO PARA O CONTROLE DE TABULACAO
    '---------------------------------------------------------------------------------------------------
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.Alt AndAlso e.KeyCode = Keys.D1 Then
            If VTabTipos.Enabled Then
                tabPrincipal.SelectedTab = VTabTipos
                tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
            End If
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D2 Then
            If VTabSubTipo.Enabled Then
                tabPrincipal.SelectedTab = VTabSubTipo
                tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
            End If
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D3 Then
            If VTabCategoria.Enabled Then
                tabPrincipal.SelectedTab = VTabCategoria
                tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
            End If
        End If
        '
    End Sub
    '
#End Region
    '
#Region "MENU SUSPENSO"
    '
    Private Sub dgvTipos_MouseDown(sender As Control, e As MouseEventArgs) Handles dgvTipos.MouseDown,
            dgvSubTipo.MouseDown, dgvCategoria.MouseDown
        '
        Dim myList As DataGridView
        myList = DirectCast(sender, DataGridView)
        '
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = myList.HitTest(e.X, e.Y)
            myList.ClearSelection()

            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            myList.CurrentCell = myList.Rows(hit.RowIndex).Cells(2)
            myList.Rows(hit.RowIndex).Selected = True
            '
            ' mostra o MENU ativar e desativar
            If hit.ColumnIndex = 2 Then
				If myList.Rows(hit.RowIndex).Cells(3).Value = True Then
					AtivarToolStripMenuItem.Enabled = False
					DesativarToolStripMenuItem.Enabled = True
				Else
					AtivarToolStripMenuItem.Enabled = True
					DesativarToolStripMenuItem.Enabled = False
				End If
				'
				' revela menu
				MenuSuspenso.Show(c.PointToScreen(e.Location))
				'
			End If
        End If
    End Sub
	'
	Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
		'
		Select Case tabPrincipal.SelectedIndex
			Case 0
				AlterarAtivo(dgvTipos, True)
			Case 1
				AlterarAtivo(dgvSubTipo, True)
			Case 2
				AlterarAtivo(dgvCategoria, True)
		End Select
		'
		Sit = EnumFlagEstado.Alterado
		'
	End Sub
	'
	Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesativarToolStripMenuItem.Click
        Select Case tabPrincipal.SelectedIndex
            Case 0
                AlterarAtivo(dgvTipos, False)
            Case 1
                AlterarAtivo(dgvSubTipo, False)
            Case 2
                AlterarAtivo(dgvCategoria, False)
        End Select
		'
		Sit = EnumFlagEstado.Alterado
		'
	End Sub
	'
	Private Sub AlterarAtivo(myList As DataGridView, myAtivo As Boolean)
		'
		'--- verifica se existe alguma cell 
		If IsDBNull(myList.CurrentRow.Cells(0).Value) Then Exit Sub
		'
		'--- altera o valor
		Select Case myList.Name
			Case "dgvTipos"
				dgvTipos.CurrentRow.DataBoundItem.Ativo = myAtivo
				dgvTipos.CurrentRow.DataBoundItem.IsUpdated = True
			Case "dgvSubTipo"
				dgvSubTipo.CurrentRow.DataBoundItem.Ativo = myAtivo
				dgvSubTipo.CurrentRow.DataBoundItem.IsUpdated = True
			Case "dgvCategoria"
				dgvCategoria.CurrentRow.DataBoundItem.Ativo = myAtivo
				dgvCategoria.CurrentRow.DataBoundItem.IsUpdated = True
		End Select
		'
		'--- atualiza os botoes
		Sit = EnumFlagEstado.Alterado
		'
	End Sub
	'
#End Region
	'
#Region "EFEITOS SUB-FORMULARIO PADRAO"
	'
	'------------------------------------------------------------------------------------------
	'-- CONVERTE A TECLA ESC EM CANCELAR
	'------------------------------------------------------------------------------------------
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
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.SlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
#End Region
    '
End Class
