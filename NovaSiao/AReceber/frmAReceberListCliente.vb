Imports CamadaDTO
Imports CamadaBLL

Public Class frmAReceberListCliente
    Private ListRec As List(Of clAReceberParcela)
    Private bindRec As New BindingSource
    Private SituacaoAtual As Byte? '--- property
    Private _Cliente As Object ' pode ser: ClientePF ou ClientePJ
    Private pBLL As New ParcelaBLL
    Private _IDFilial As Integer
    '
#Region "LOAD NEW"
    '
    Sub New(Cliente As Object, Optional Situacao As Byte = 0)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        lblFilial.Text = ObterDefault("FilialDescricao")
        _IDFilial = Obter_FilialPadrao()
        _Cliente = Cliente
        '
        DefineLabelsCliente()
        '
        propSituacaoAtual = Situacao
        ObterDados()
        PreencheItens()
        '
    End Sub
    '
    Private Sub DefineLabelsCliente()
        '
        lblReg.Text = Format(_Cliente.IDPessoa, "0000")
        lblCadastro.Text = _Cliente.Cadastro
        If TypeOf _Cliente Is clClientePF Then
            lblCNP.Text = _Cliente.CPF
        Else
            lblCNP.Text = _Cliente.CNPJ
        End If
        '
    End Sub
    '
    Private Sub ObterDados()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If chkTodasFiliais.Checked = False Then
                ListRec = pBLL.Parcela_GET_PorIDPessoa(_Cliente.IDPessoa, _IDFilial, propSituacaoAtual)
            Else
                ListRec = pBLL.Parcela_GET_PorIDPessoa(_Cliente.IDPessoa, Nothing, propSituacaoAtual)
            End If
            '
            bindRec.DataSource = ListRec
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a Lista de A Receber do Cliente..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Public Property propSituacaoAtual() As Byte?
        Get
            If rbtEmAberto.Checked = True Then
                SituacaoAtual = 0 '--- em aberto
            ElseIf rbtQuitadas.Checked = True Then
                SituacaoAtual = 1 '--- pagas
            ElseIf rbtCanceladas.Checked = True Then
                SituacaoAtual = 2 '--- canceladas
            ElseIf rbtNegativadas.Checked = True Then
                SituacaoAtual = 3 '--- negativadas
            ElseIf rbtNegociadas.Checked = True Then
                SituacaoAtual = 4 '--- Negociadas
            ElseIf rbtTodas.Checked = True Then
                SituacaoAtual = Nothing '--- Todas
            Else
                SituacaoAtual = Nothing
            End If
            '
            Return SituacaoAtual
            '
        End Get
        '
        Set(ByVal value As Byte?)
            SituacaoAtual = value
            '
            RemoverHandler()
            '
            Select Case SituacaoAtual
                Case 0 '--- Em aberto
                    rbtEmAberto.Checked = True
                    rbtQuitadas.Checked = False
                    rbtCanceladas.Checked = False
                    rbtNegativadas.Checked = False
                    rbtNegociadas.Checked = False
                    rbtTodas.Checked = False
                Case 1 '--- Pagas
                    rbtEmAberto.Checked = False
                    rbtQuitadas.Checked = True
                    rbtCanceladas.Checked = False
                    rbtNegativadas.Checked = False
                    rbtNegociadas.Checked = False
                    rbtTodas.Checked = False
                Case 2 '--- Canceladas
                    rbtEmAberto.Checked = False
                    rbtQuitadas.Checked = False
                    rbtCanceladas.Checked = True
                    rbtNegativadas.Checked = False
                    rbtNegociadas.Checked = False
                    rbtTodas.Checked = False
                Case 3 '--- Negativadas
                    rbtEmAberto.Checked = False
                    rbtQuitadas.Checked = False
                    rbtCanceladas.Checked = False
                    rbtNegativadas.Checked = True
                    rbtNegociadas.Checked = False
                    rbtTodas.Checked = False
                Case 4 '--- Negociadas
                    rbtEmAberto.Checked = False
                    rbtQuitadas.Checked = False
                    rbtCanceladas.Checked = False
                    rbtNegativadas.Checked = False
                    rbtNegociadas.Checked = True
                    rbtTodas.Checked = False
                Case Else '--- Todas
                    rbtEmAberto.Checked = False
                    rbtQuitadas.Checked = False
                    rbtCanceladas.Checked = False
                    rbtNegativadas.Checked = False
                    rbtNegociadas.Checked = False
                    rbtTodas.Checked = True
            End Select
            '
            AdicionaHandler()
            '
        End Set
    End Property
    '
#End Region
    '
#Region "CARREGA ITENS"
    '
    Private Sub PreencheItens()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        dgvListagem.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvListagem.MultiSelect = False
        dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListagem.ColumnHeadersVisible = True
        dgvListagem.AllowUserToResizeRows = False
        dgvListagem.AllowUserToResizeColumns = False
        dgvListagem.RowHeadersVisible = True
        dgvListagem.RowHeadersWidth = 30
        dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvListagem.StandardTab = True
        dgvListagem.EditMode = DataGridViewEditMode.EditProgrammatically
        '
        '--- configura o DataSource
        dgvListagem.DataSource = bindRec
        If dgvListagem.Rows.Count > 0 Then dgvListagem.CurrentCell = dgvListagem.Rows(dgvListagem.Rows.Count).Cells(1)
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    Private Sub FormataColunas_Itens()
        '
        '--- Limpa as colunas se houver
        If dgvListagem.Columns.Count > 0 Then
            dgvListagem.Columns.Clear()
        End If
        '
        ' (0) COLUNA Cadastro Nome
        dgvListagem.Columns.Add("clnCadastro", "Cadastro")
        With dgvListagem.Columns("clnCadastro")
            .DataPropertyName = "Cadastro"
            .Width = 280
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (1) COLUNA Registro
        dgvListagem.Columns.Add("clnReg", "Reg.")
        With dgvListagem.Columns("clnReg")
            .DataPropertyName = "CodRegistro"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA VENCIMENTO
        dgvListagem.Columns.Add("clnVencimento", "Vencimento")
        '
        With dgvListagem.Columns("clnVencimento")
            .DataPropertyName = "Vencimento"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (3) COLUNA VALOR  
        dgvListagem.Columns.Add("clnValor", "Valor")
        With dgvListagem.Columns("clnValor")
            .DataPropertyName = "ParcelaValor"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "#,#0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA DESCONTO
        dgvListagem.Columns.Add("clnPermanencia", "Perm.%")
        With dgvListagem.Columns("clnPermanencia")
            .DataPropertyName = "PermanenciaTaxa"
            .Width = 70
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (5) VALOR PAGO
        dgvListagem.Columns.Add("clnPago", "Valor Pago")
        With dgvListagem.Columns("clnPago")
            .DataPropertyName = "ValorPagoParcela"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "#,#0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (6) COLUNA SITUACAO
        dgvListagem.Columns.Add("clnSituacaoParcela", "Situação")
        With dgvListagem.Columns("clnSituacaoParcela")
            .DataPropertyName = "SituacaoDescricao"
            .Width = 130
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        '--- Inclui algumas colunas extras no caso de selecionar o PAGO ou TODAS
        If SituacaoAtual = 1 Or IsNothing(SituacaoAtual) Then
            '
            ' (7) COLUNA DATA PAGAMENTO
            dgvListagem.Columns.Add("clnPagamentoData", "Dt. Pag.")
            With dgvListagem.Columns("clnPagamentoData")
                .DataPropertyName = "PagamentoData"
                .Width = 100
                .Resizable = DataGridViewTriState.False
                .Visible = True
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '
            ' (8) VALOR JUROS
            dgvListagem.Columns.Add("clnAcrescimo", "Juros/Multa")
            With dgvListagem.Columns("clnAcrescimo")
                .DataPropertyName = "ValorJuros"
                .Width = 90
                .Resizable = DataGridViewTriState.False
                .Visible = True
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,#0.00"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End If
        '
        FormataVencimento()
        '
    End Sub
    '
    Private Sub FormataVencimento()
        '
        Dim index As Integer
        ' find the location of the column
        index = dgvListagem.Columns.IndexOf(dgvListagem.Columns("clnVencimento"))

        'remove Handler
        RemoveHandler dgvListagem.CellFormatting, AddressOf dgvListagem_CellFormatting

        ' remove the existing column
        dgvListagem.Columns.RemoveAt(index)

        ' create a new custom column
        Dim dgvMaskedCol As New Controles.DataGridViewMaskedEditColumn
        With dgvMaskedCol
            .Mask = "00/00/0000"
            .ValidatingType = GetType(String)
            .Name = "clnVencimento"
            .DataPropertyName = "Vencimento"
            .HeaderText = "Vencimento"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.Automatic  ' some more tweaking
        End With

        ' insert the new column at the same location
        dgvListagem.Columns.Insert(index, dgvMaskedCol)

        'Add Handler
        AddHandler dgvListagem.CellFormatting, AddressOf dgvListagem_CellFormatting
        '
    End Sub
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEscolher_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        If e.ColumnIndex = 6 AndAlso e.Value = "Em Aberto" Then
            Dim dtVenc As Date = dgvListagem.Rows(e.RowIndex).Cells(2).Value
            If dtVenc < Date.Today Then
                e.Value = "Vencida"
                e.CellStyle.ForeColor = Color.Red
            End If
        End If
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim p As New frmClienteProcurar(Me)
            '
            p.ShowDialog()
            If p.DialogResult = DialogResult.Cancel Then Exit Sub
            '
            _Cliente = p.propClienteEscolhido
            DefineLabelsCliente()
            ObterDados()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir o Form de Procura..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        MsgBox("Em implementação")
    End Sub
    '
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        '--- VERIFICA SE EXISTE UMA PARCELA SELECIONADA
        If dgvListagem.Rows.Count = 0 OrElse dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione uma Parcela antes de pressionar ESCOLHER" & vbNewLine &
                            "para QUITAR uma parcela.",
                            "Escolher Parcela", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Focus()
            Exit Sub
        End If
        '
        '--- ABRE O FORM DE RECEBIMENTO
        '----------------------------------------------------------------------------------
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim parcela As clAReceberParcela = dgvListagem.SelectedRows(0).DataBoundItem
            '
            Dim f As New frmAReceberEntradas(parcela, Me)
            '
            f.ShowDialog()
            '
            '--- Atualizar a listagem para verificar mudanças
            If f.DialogResult = DialogResult.OK Or f.DialogResult = DialogResult.Yes Then
                '
                ObterDados()
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir o Form de Recebimentos..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    Private Sub chkTodasFiliais_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodasFiliais.CheckedChanged
        ObterDados()
        dgvListagem.Focus()
    End Sub
    '
    Private Sub AdicionaHandler()
        AddHandler rbtEmAberto.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtCanceladas.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtNegativadas.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtQuitadas.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtNegociadas.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtTodas.CheckedChanged, AddressOf Butons_CheckedChanged
    End Sub
    '
    Private Sub RemoverHandler()
        RemoveHandler rbtEmAberto.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtCanceladas.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtNegativadas.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtQuitadas.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtNegociadas.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtTodas.CheckedChanged, AddressOf Butons_CheckedChanged
    End Sub
    '
    Private Sub Butons_CheckedChanged(sender As Object, e As EventArgs)
        ObterDados()
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnEscolher_Click(New Object, New EventArgs)
    End Sub
    '
#End Region
    '
#Region "NAVEGACAO E CONTROLE"
    '
    '-- CONVERTE A TECLA ESC EM CANCELAR
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            '
            e.Handled = True
            btnFechar_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Add Then
            '
            e.Handled = True
            btnProcurar_Click(sender, New EventArgs)
            '
        End If
        '
    End Sub
    '
#End Region '/ NAVEGACAO E CONTROLE
    '
#Region "MENU SUSPENSO"
    '
    Private Sub dgvListagem_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvListagem.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvListagem.HitTest(e.X, e.Y)
            dgvListagem.ClearSelection()

            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub

            ' seleciona o ROW
            dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvListagem.CurrentCell = dgvListagem.Rows(hit.RowIndex).Cells(2)
            dgvListagem.Rows(hit.RowIndex).Selected = True

            ' mostra o MENU ativar e desativar
            Dim recItem As clAReceberParcela = DirectCast(dgvListagem.Rows(hit.RowIndex).DataBoundItem, clAReceberParcela)
            '
            If recItem.SituacaoParcela = 0 Then '--- EmAberto
                QuitarToolStripMenuItem.Enabled = True
                CancelarToolStripMenuItem.Enabled = True
                AlterarToolStripMenuItem.Enabled = True
                NegativarToolStripMenuItem.Enabled = True
                NormalizarToolStripMenuItem.Enabled = False

            ElseIf recItem.SituacaoParcela = 1 Then '--- Pagas
                QuitarToolStripMenuItem.Enabled = False
                CancelarToolStripMenuItem.Enabled = False
                AlterarToolStripMenuItem.Enabled = False
                NegativarToolStripMenuItem.Enabled = False
                NormalizarToolStripMenuItem.Enabled = False

            ElseIf recItem.SituacaoParcela = 2 Then '--- Canceladas
                QuitarToolStripMenuItem.Enabled = True
                CancelarToolStripMenuItem.Enabled = False
                AlterarToolStripMenuItem.Enabled = False
                NegativarToolStripMenuItem.Enabled = True
                NormalizarToolStripMenuItem.Enabled = True

            ElseIf recItem.SituacaoParcela = 3 Then '--- Negativadas
                QuitarToolStripMenuItem.Enabled = False
                CancelarToolStripMenuItem.Enabled = False
                AlterarToolStripMenuItem.Enabled = False
                NegativarToolStripMenuItem.Enabled = True
                NormalizarToolStripMenuItem.Enabled = True

            ElseIf recItem.SituacaoParcela = 4 Then '--- Negociadas
                QuitarToolStripMenuItem.Enabled = False
                CancelarToolStripMenuItem.Enabled = False
                AlterarToolStripMenuItem.Enabled = False
                NegativarToolStripMenuItem.Enabled = False
                NormalizarToolStripMenuItem.Enabled = False

            End If
            '
            ' revela menu
            mnuOperacoes.Show(c.PointToScreen(e.Location))
        End If
    End Sub
    '
    Private Sub QuitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
        '
        btnEscolher_Click(New Object, New EventArgs)
        '
    End Sub
    '
    '--- CANCELAR A PARCELA
    '-------------------------------------------------------------------------------------------------------
    Private Sub CancelarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarToolStripMenuItem.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- verifica USER PERMIT
        If UsuarioAtual.UsuarioAcesso <> 1 Then '--- Usuario Administrador
            MessageBox.Show("Solicite autorização Administrativa...")
            Exit Sub
        End If
        '
        '--- Pergunta ao USER
        If MessageBox.Show("Você deseja realmente CANCELAR essa parcela selecionada?",
                                  "Cancelar Parcela", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- Cancela a parcela selecionada
        Dim p As New ParcelaBLL
        Dim resp As Integer
        Dim IDParcela As Integer = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAReceberParcela).IDAReceberParcela
        '
        Try
            resp = p.Cancelar_Parcela(IDParcela)
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao Cancelar a Parcela..." & vbNewLine &
                            ex.Message, "Execeção Inesperada", MessageBoxButtons.OK)
            Exit Sub
        End Try
        '
        '--- atualiza a listagem
        ObterDados()
        '
    End Sub
    '
    '--- NORMALIZAR A PARCELA
    '-------------------------------------------------------------------------------------------------------
    Private Sub NormalizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalizarToolStripMenuItem.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- verifica USER PERMIT
        If UsuarioAtual.UsuarioAcesso <> 1 Then '--- Usuario Administrador
            MessageBox.Show("Solicite autorização Administrativa...")
            Exit Sub
        End If
        '
        '--- Pergunta ao USER
        If MessageBox.Show("Você deseja realmente NORMALIZAR essa parcela selecionada?",
                           "Normalizar Parcela", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- Normaliza a parcela selecionada
        Dim p As New ParcelaBLL
        Dim resp As Integer
        Dim IDParcela As Integer = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAReceberParcela).IDAReceberParcela
        '
        Try
            resp = p.Normalizar_Parcela(IDParcela)
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao Normalizar a Parcela..." & vbNewLine &
                            ex.Message, "Execeção Inesperada", MessageBoxButtons.OK)
            Exit Sub
        End Try
        '
        '--- atualiza a listagem
        ObterDados()
        '
    End Sub
    '
    '--- NEGATIVAR A PARCELA
    '-------------------------------------------------------------------------------------------------------
    Private Sub NegativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegativarToolStripMenuItem.Click
        MsgBox("Em Implementação")
    End Sub
    '
    '--- ALTERAR DATA DA PARCELA
    '-------------------------------------------------------------------------------------------------------
    Private Sub AlterarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlterarToolStripMenuItem.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        dgvListagem.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvListagem.CurrentCell = dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).Cells(2)
        dgvListagem.BeginEdit(True)

        Dim c As Control = dgvListagem.EditingControl

        If DirectCast(c, MaskedTextBox).Text.Length > 1 Then
            DirectCast(c, MaskedTextBox).SelectAll()
        End If

        dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '
    End Sub
    '
    '--- VER VENDA DA PARCELA
    '-------------------------------------------------------------------------------------------------------
    Private Sub VerVendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerVendaToolStripMenuItem.Click
        '
        '--- verifica se existe alguma cell 
        If IsDBNull(dgvListagem.CurrentRow.Cells(0).Value) Then Exit Sub
        '
        '--- Abre a Venda da parcela selecionada
        Dim p As New ParcelaBLL
        Dim IDTransacao As Integer = DirectCast(dgvListagem.Rows(dgvListagem.CurrentCell.RowIndex).DataBoundItem, clAReceberParcela).IDOrigem
        Dim vBLL As New VendaBLL
        '
        Try
            Dim myVenda As clVenda = vBLL.GetVenda_PorID_OBJ(IDTransacao)
            '
            '--- Abre a Venda
            Dim frmV As New frmVendaPrazo(myVenda)
            frmV.Show()
            Close()
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao Abrir a Venda da Parcela..." & vbNewLine &
            ex.Message, "Execeção Inesperada", MessageBoxButtons.OK)
            Exit Sub
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM VENCIMENTO VALIDATION"
    '
    Private Sub dgvListagem_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvListagem.DataError
        If e.ColumnIndex = 2 Then
            MessageBox.Show("Valor da Data digitada é inválida" & vbNewLine &
                            "Favor digitar uma DATA válida...", "Data Inválida",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvListagem.CancelEdit()
        End If
    End Sub
    '
    Private Sub dgvListagem_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellValidated
        '
        If e.ColumnIndex = 2 Then
            If dgvListagem.CurrentCell.IsInEditMode = False Then Exit Sub
            '
            dgvListagem.EndEdit()
            '
            Dim parc As clAReceberParcela = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clAReceberParcela)
            Dim parcBLL As New ParcelaBLL
            '
            Dim IDTransacao As Integer? = parc.IDOrigem
            Dim myID As Integer = parc.IDAReceberParcela
            Dim newVenc As Date = parc.Vencimento
            '
            Try
                parcBLL.AlteraVencimento_Parcela(myID, newVenc, IDTransacao)
            Catch ex As Exception
                MessageBox.Show("Houve uma exceção inesperada ao SALVAR as Parcelas..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dgvListagem.CancelEdit()
            End Try
            '
        End If
        '
    End Sub
    '
#End Region
    '
End Class
