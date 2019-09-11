Imports CamadaBLL
'
Public Class frmProdutoTipo
    Private dtTipo, dtSubTipo, dtCat As DataTable
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Private ImgNew As Image = My.Resources.Adicionar1
    Private Abrindo As Boolean = True
    Private _formProcura As ProcurarPor
    Property ItemEscolhido() As Integer? '--- quando o form fechar informa o Tipo, SubTipo ou Categoria
    Private _tipoPadrao As Integer?
    Private pTipoBLL As New TipoSubTipoCategoriaBLL
    Dim _Sit As Byte
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
            dtTipo = pTipoBLL.ProdutoTipo_GET_WithWhere()
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
        dgvTipos.Columns.Clear()
        dgvTipos.AutoGenerateColumns = False
        '
        dgvTipos.DataSource = dtTipo
        '
    End Sub
    '
    '--- FORMATA LISTA TIPO
    Private Sub FormataListaTipo()
        '
        ' (1) COLUNA REG
        dgvTipos.Columns.Add("clnIDProdutoTipo", "Reg.")
        With dgvTipos.Columns("clnIDProdutoTipo")
            .DataPropertyName = "IDProdutoTipo"
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
            .DataPropertyName = "ProdutoTipo"
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
        ' (1) COLUNA REG
        dgvSubTipo.Columns.Add("clnIDProdutoSubTipo", "Reg.")
        With dgvSubTipo.Columns("clnIDProdutoSubTipo")
            .DataPropertyName = "IDProdutoSubTipo"
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
            .DataPropertyName = "ProdutoSubTipo"
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
            '
            Dim query As String = "IDProdutoTipo = " & propTipoPadrao
            dtSubTipo = pTipoBLL.ProdutoSubTipo_GET_WithWhere(query, "ProdutoSubTipo")
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
        dgvSubTipo.DataSource = dtSubTipo
        '
    End Sub
    '
    '--- FORMATA LISTA CATEGORIA
    Private Sub FormataListaCategoria()
        '
        dgvCategoria.Columns.Clear()
        dgvCategoria.AutoGenerateColumns = False
        '
        ' (1) COLUNA REG
        dgvCategoria.Columns.Add("clnIDCategoria", "Reg.")
        With dgvCategoria.Columns("clnIDCategoria")
            .DataPropertyName = "IDCategoria"
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
            .DataPropertyName = "ProdutoCategoria"
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
            dtCat = pTipoBLL.ProdutoCategoria_GET_WithWhere(query, "ProdutoCategoria")
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
        dgvCategoria.DataSource = dtCat
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
            Dim r As DataRowView = myLista.Rows(e.RowIndex).DataBoundItem
            '
            If IsDBNull(r("Ativo")) Then

            ElseIf r("Ativo") = True Then
                e.Value = ImgAtivo
            ElseIf r("Ativo") = False Then
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
            Case 0 ' Adicionar TIPO
                '---adiciona novo ROW no datatable 
                dtTipo.Rows.Add()
                ' seleciona a cell
                dgvTipos.Focus()
                dgvTipos.CurrentCell = dgvTipos.Rows(dgvTipos.Rows.Count - 1).Cells(1)
                dgvTipos.BeginEdit(True)
                '---adiciona a imagem no NOVO ROW
                dgvTipos.CurrentRow.Cells(2).Value = ImgNew
            Case 1 ' Adicionar SubTipo
                '---adiciona novo ROW no datatable 
                dtSubTipo.Rows.Add()
                ' seleciona a cell
                dgvSubTipo.Focus()
                dgvSubTipo.CurrentCell = dgvSubTipo.Rows(dgvSubTipo.Rows.Count - 1).Cells(1)
                dgvSubTipo.BeginEdit(True)
                '---adiciona a imagem no NOVO ROW
                dgvSubTipo.CurrentRow.Cells(2).Value = ImgNew
            Case 2 ' Adicionar Categoria
                '---adiciona novo ROW no datatable 
                dtCat.Rows.Add()
                ' seleciona a cell
                dgvCategoria.Focus()
                dgvCategoria.CurrentCell = dgvCategoria.Rows(dgvCategoria.Rows.Count - 1).Cells(1)
                dgvCategoria.BeginEdit(True)
                '---adiciona a imagem no NOVO ROW
                dgvCategoria.CurrentRow.Cells(2).Value = ImgNew
        End Select
        Sit = EnumFlagEstado.NovoRegistro
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
        '-- variavel para informar o número de registros salvos
        Dim regSalvos As Integer = 0
        '
        For Each r As DataGridViewRow In dgvTipos.Rows
            '
            ' verfica se já existe valor igual
            If dtTipo.Rows(r.Index).RowState <> DataRowState.Unchanged Then
                If VerificaDuplicado(r.Index, r.Cells(1).Value, dtTipo) = True Then
                    MessageBox.Show("Já existe um Tipo de Produto com a mesma descrição:" & vbNewLine &
                                    CStr(r.Cells(1).Value).ToUpper,
                                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Continue For
                End If
            End If
            '
            '---salva os registros
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                If dtTipo.Rows(r.Index).RowState = DataRowState.Modified Then ' registro ALTERADO
                    '
                    pTipoBLL.ProdutoTipo_Update(r.Cells(0).Value,
                                                r.Cells(1).Value,
                                                r.Cells(3).Value)
                    regSalvos += 1
                    '
                ElseIf dtTipo.Rows(r.Index).RowState = DataRowState.Added Then ' registro NOVO
                    '
                    pTipoBLL.ProdutoTipo_Insert(r.Cells(1).Value)
                    regSalvos += 1
                    '
                End If
                '
            Catch ex As Exception
                MessageBox.Show("O seguinte registro não pôde ser salvo:" & vbNewLine &
                                    CStr(r.Cells(1).Value).ToUpper, "Erro ao Salvar",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("Sucesso ao salvar registro(s) de Tipo de Produto" & vbNewLine &
                            "Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
                            IIf(regSalvos > 1, " registros", " registro"),
                            "Registro(s) Salvo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            ' verfica se já existe valor igual
            If dtSubTipo.Rows(r.Index).RowState <> DataRowState.Unchanged Then
                If VerificaDuplicado(r.Index, r.Cells(1).Value, dtSubTipo) = True Then
                    MessageBox.Show("Já existe uma Classificação de Produto com a mesma descrição:" & vbNewLine &
                                        CStr(r.Cells(1).Value).ToUpper,
                                        "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Continue For
                End If
            End If
            '
            '---salva os registros
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                If dtSubTipo.Rows(r.Index).RowState = DataRowState.Modified Then ' registro ALTERADO
                    '
                    pTipoBLL.ProdutoSubTipo_Update(r.Cells(0).Value, r.Cells(1).Value, r.Cells(3).Value)
                    regSalvos += 1
                    '
                ElseIf dtSubTipo.Rows(r.Index).RowState = DataRowState.Added Then ' registro NOVO
                    '
                    pTipoBLL.ProdutoSubTipo_Insert(r.Cells(1).Value, propTipoPadrao)
                    regSalvos += 1
                    '
                End If
                '
            Catch ex As Exception
                MessageBox.Show("O seguinte registro não pôde ser salvo:" & vbNewLine &
                                CStr(r.Cells(1).Value).ToUpper, "Erro ao Salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("Sucesso ao salvar registro(s) de Classificação de Produto" & vbNewLine &
                            "Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
                            IIf(regSalvos > 1, " registros", " registro"),
                            "Registro(s) Salvo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
        '---preencher a listagem com os novos valores
        GetListaSubTipo()
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    Private Sub SalvarCategoria()
        '-- variavel para informar o número de registros salvos
        Dim regSalvos As Integer = 0
        '
        For Each r As DataGridViewRow In dgvCategoria.Rows
            ' verfica se já existe valor igual
            If dtCat.Rows(r.Index).RowState <> DataRowState.Unchanged Then
                If VerificaDuplicado(r.Index, r.Cells(1).Value, dtCat) = True Then
                    MessageBox.Show("Já existe uma Categoria de Produto com a mesma descrição:" & vbNewLine &
                                    CStr(r.Cells(1).Value).ToUpper,
                                    "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Continue For
                End If
            End If
            '
            '---salva os registros
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                If dtCat.Rows(r.Index).RowState = DataRowState.Modified Then ' registro ALTERADO
                    '
                    pTipoBLL.ProdutoCategoria_Update(r.Cells(0).Value, r.Cells(1).Value, r.Cells(3).Value)
                    regSalvos += 1
                    '
                ElseIf dtCat.Rows(r.Index).RowState = DataRowState.Added Then ' registro NOVO
                    '
                    pTipoBLL.ProdutoCategoria_Insert(r.Cells(1).Value, propTipoPadrao)
                    regSalvos += 1
                    '
                End If
                '
            Catch ex As Exception
                '
                MessageBox.Show("O seguinte registro não pôde ser salvo:" & vbNewLine &
                            CStr(r.Cells(1).Value).ToUpper, "Erro ao Salvar",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("Sucesso ao salvar registro(s) de Categoria de Produto" & vbNewLine &
                            "Foram salvo(s) com sucesso " & Format(regSalvos, "00") &
                            IIf(regSalvos > 1, " registros", " registro"),
                            "Registro(s) Salvo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
        '---preencher a listagem com os novos valores
        GetListaCategoria()
        Sit = EnumFlagEstado.RegistroSalvo
    End Sub
    '
#End Region
    '
#Region "VALIDAÇÃO"
    '
    ' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
    Public Function VerificaDuplicado(myRow As Integer, myNewValor As String, myTable As DataTable) As Boolean
        '---se não houver nenhum registro, Exit
        If myTable.Rows.Count = 0 Then
            VerificaDuplicado = False
            Exit Function
        End If
        '---verifica todos os ROWS procurando registro igual
        For i = 0 To myTable.Rows.Count - 1
            If i = myRow Then Continue For '---se for a mesma ROW não verifica
            If myTable.Rows(i).Item(1).ToString.ToUpper = myNewValor Then
                VerificaDuplicado = True
                Exit Function
            End If
        Next i
        '---se não encontrar retorna FALSE
        VerificaDuplicado = False
    End Function
    '
    Private Sub ValidaDescricao_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvTipos.CellValidating,
            dgvSubTipo.CellValidating, dgvCategoria.CellValidating
        '
        If Abrindo = True Then Exit Sub
        '
        Dim myList As DataGridView = DirectCast(sender, DataGridView)
        '
        ' Valida o entrada para a descrição não permitindo valores em branco
        If e.ColumnIndex = 1 Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
                myList.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO da Conta não pode ficar vazia..."
                e.Cancel = True
                Exit Sub
            End If
        End If
        '---procura por valores duplicados da descrição 
        Dim verDup As Boolean
        Dim strTab As String = ""
        '
        Select Case myList.Name
            Case "dgvTipo"
                verDup = VerificaDuplicado(e.RowIndex, e.FormattedValue.ToString.ToUpper, dtTipo)
                strTab = "Tipo de Produto"
            Case "dgvSubTipo"
                verDup = VerificaDuplicado(e.RowIndex, e.FormattedValue.ToString.ToUpper, dtSubTipo)
                strTab = "Classificação de Produto"
            Case "dgvCategoria"
                verDup = VerificaDuplicado(e.RowIndex, e.FormattedValue.ToString.ToUpper, dtCat)
                strTab = "Categoria de Produto"
        End Select
        '
        If verDup Then
            MessageBox.Show("Já existe um Registro de " & strTab & " com a mesma descrição:" & vbNewLine &
                            e.FormattedValue.ToString.ToUpper,
                            "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            myList.Rows(e.RowIndex).ErrorText = "A DESCRIÇÃO de " & strTab & " precisa ser EXCLUSIVA..."
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    '
    Private Sub EndEdit_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTipos.CellEndEdit,
            dgvSubTipo.CellEndEdit, dgvCategoria.CellEndEdit
        '
        Dim myList As DataGridView = DirectCast(sender, DataGridView)
        ' Limpa o erro da linha no caso do usuário pressionar ESC
        myList.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub AoEditar_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTipos.EditingControlShowing,
            dgvSubTipo.EditingControlShowing, dgvCategoria.EditingControlShowing
        '
        '---restringe a entrada de dados para a coluna 'Forma de Cobrança'
        Dim myList As DataGridView = DirectCast(sender, DataGridView)
        If myList.CurrentCell.ColumnIndex = 1 And Not e.Control Is Nothing Then
            Dim tb As TextBox = CType(e.Control, TextBox)
            '---inclui um tratamento de evento para o controle TextBox---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub
    '
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '
        '---Se o usuario pressionou a tecla ESC na edição ---
        If e.KeyChar = Convert.ToChar(27) Then
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
                ' revela menu
                MenuSuspenso.Show(c.PointToScreen(e.Location))
            End If
        End If
    End Sub
    '
    Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
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
    End Sub
    '
    Private Sub AlterarAtivo(myList As DataGridView, myAtivo As Boolean)
        '--- verifica se existe alguma cell 
        If IsDBNull(myList.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- altera o valor
        Dim r As DataRow = Nothing
        '
        Select Case myList.Name
            Case "dgvTipos"
                r = dtTipo.Select("ProdutoTipo = '" & dgvTipos.CurrentRow.Cells(1).Value & "'").First
                r("Ativo") = myAtivo
            Case "dgvSubTipo"
                r = dtSubTipo.Select("ProdutoSubTipo = '" & dgvSubTipo.CurrentRow.Cells(1).Value & "'").First
                r("Ativo") = myAtivo
            Case "dgvCategoria"
                r = dtCat.Select("ProdutoCategoria = '" & dgvCategoria.CurrentRow.Cells(1).Value & "'").First
                r("Ativo") = myAtivo
        End Select
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
