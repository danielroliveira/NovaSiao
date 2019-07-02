Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmPedidoProcurar
    '
    Private pedLista As New List(Of clPedido)
    Private SituacaoAtual As Byte? '--- property
    Private _formOrigem As Form
    Private _IDFornecedor As Integer? = Nothing
    Private _pedBLL As New PedidoBLL
    '
#Region "NEW | PROPERTY | LOAD"
    '
    Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        If Not formOrigem Is Nothing Then _formOrigem = formOrigem
        rbtCompondo.Checked = True
        propSituacaoAtual = 0
        CarregaCmbMes()
        CarregaCmbAno()
        FormataListagem()
        Get_Dados()
        PreencheListagem()
        '
    End Sub
    '
    Private Sub frmPedidoProcurar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '
        '--- permite alteracao pelos combos
        AddHandler cmbMes.SelectedValueChanged, AddressOf cmb_AoAlterar
        AddHandler cmbAno.SelectedValueChanged, AddressOf cmb_AoAlterar
        '
    End Sub
    '
    Public Property propSituacaoAtual() As Byte?
        '
        Get
            '
            controlaDataFinal()
            Return SituacaoAtual
            '
        End Get
        '
        Set(ByVal value As Byte?)
            '
            SituacaoAtual = value
            RemoverHandler()
            '
            Select Case SituacaoAtual
                Case 0 '--- Compondo
                    rbtCompondo.Focus()
                    lblDtFinal.Text = "Dt. da Revisão"
                Case 1 '--- Enviados
                    rbtEnviado.Focus()
                    lblDtFinal.Text = "Dt. do Envio"
                Case 2 '--- Recebidos
                    rbtRecebidos.Focus()
                    lblDtFinal.Text = "Dt. da Chegada"
                Case 3 '--- Cancelados
                    rbtCancelados.Focus()
                    lblDtFinal.Text = "Dt. do Cancelamento"
                Case Else '--- Todas
                    lblDtFinal.Text = "Dt. da Revisão"
            End Select
            '
            AdicionaHandler()
            '
        End Set
    End Property
    '
    '--- ALTERA O LABEL E O PROPERTY DA DATA FINAL DO DATAGRID
    Private Sub controlaDataFinal()
        Select Case SituacaoAtual
            Case 0 '--- Compondo
                lblDtFinal.Text = "Dt. da Revisão"
                clnRevisaoData.DataPropertyName = "RevisaoData"
                btnExcluir.Enabled = True
                btnEditar.Text = "&Editar"
            Case 1 '--- Enviados
                lblDtFinal.Text = "Dt. do Envio"
                clnRevisaoData.DataPropertyName = "EnvioData"
                btnExcluir.Enabled = False
                btnEditar.Text = "&Abrir"
            Case 2 '--- Recebidos
                lblDtFinal.Text = "Dt. da Chegada"
                clnRevisaoData.DataPropertyName = "ChegadaData"
                btnExcluir.Enabled = False
                btnEditar.Text = "&Abrir"
            Case 3 '--- Cancelados
                lblDtFinal.Text = "Cancelamento"
                clnRevisaoData.DataPropertyName = "RevisaoData"
                btnExcluir.Enabled = True
                btnEditar.Text = "&Editar"
        End Select
    End Sub
    '
#End Region
    '
#Region "LISTAGEM CONFIGURAÇÃO"
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
        dgvListagem.RowHeadersWidth = 30
        dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvListagem.StandardTab = True
        '
    End Sub
    '
    Private Sub Get_Dados()
        '
        '--- consulta o banco de dados
        Try
            'MsgBox("get")
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If cmbAno.SelectedValue = 0 AndAlso cmbMes.SelectedValue = 0 Then 'ANO e MES nulos
                pedLista = _pedBLL.Pedido_GET_List(propSituacaoAtual)
                '
            ElseIf cmbAno.SelectedValue = 0 AndAlso cmbMes.SelectedValue > 0 Then ' ANO NULO E MES PREENCHIDO
                pedLista = _pedBLL.Pedido_GET_List(propSituacaoAtual, Nothing, CInt(cmbMes.SelectedValue))
                '
            ElseIf cmbMes.SelectedValue = 0 AndAlso cmbAno.SelectedValue > 0 Then ' ANO PREENCHIDO E MES NULO
                pedLista = _pedBLL.Pedido_GET_List(propSituacaoAtual, CInt(cmbAno.SelectedValue), Nothing)
                '
            ElseIf cmbMes.SelectedValue > 0 AndAlso cmbAno.SelectedValue > 0 Then ' ANO E MES PREENCHIDOS
                pedLista = _pedBLL.Pedido_GET_List(propSituacaoAtual, CInt(cmbAno.SelectedValue), CInt(cmbMes.SelectedValue))
                '
            Else ' ANO E MES VAZIOS
                pedLista = _pedBLL.Pedido_GET_List(propSituacaoAtual)
                '
            End If
            '
            dgvListagem.DataSource = pedLista
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu exceção ao obter a lista de Pedidos..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub PreencheListagem()
        '
        ' (0) COLUNA DATA DO PEDIDO
        With clnInicioData
            .DataPropertyName = "InicioData"
            .Width = 130
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (1) COLUNA FORNECEDOR
        With clnFornecedor
            .DataPropertyName = "Fornecedor"
            .Width = 330
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA TOTAL PEDIDO
        With clnTotalPedido
            .DataPropertyName = "TotalPedido"
            .Width = 130
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (3) COLUNA DATA DA REVISAO
        With clnRevisaoData
            .DataPropertyName = "RevisaoData"
            .Width = 130
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        dgvListagem.Columns.AddRange(New DataGridViewColumn() {clnInicioData, clnFornecedor, clnTotalPedido, clnRevisaoData})
        '
    End Sub
    '
#End Region
    '
#Region "PREENCHE TRATA COMBOS"
    '-------------------------------------------------------------------------------------------------
    ' PREENCHE COMBO MES
    '-------------------------------------------------------------------------------------------------
    Private Sub CarregaCmbMes()
        '
        Dim dtMes As New DataTable
        '
        Try
            '
            '--- Adiciona as Colunas
            dtMes.Columns.Add("MesNumber")
            dtMes.Columns.Add("MesName")
            '--- Adiciona a possibilidade Qualquer Mes
            dtMes.Rows.Add(New Object() {0, "Qualquer Mês"})
            '
            '--- Adiciona todas as possibilidades de Meses do Ano
            For i = 1 To 12
                Dim mydate As Date = "01/" & i & "/2000"
                dtMes.Rows.Add(New Object() {i, Format(mydate, "MMMM").ToUpperInvariant})
            Next
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao obter a lista dos meses" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
        With cmbMes
            .DataSource = dtMes
            .ValueMember = "MesNumber"
            .DisplayMember = "MesName"
            .SelectedValue = Now.Month
        End With
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' PREENCHE COMBO ANO
    '-------------------------------------------------------------------------------------------------
    Private Sub CarregaCmbAno()
        '
        Dim dtAno As New DataTable
        '
        Try
            Dim AnoInicial As Integer? = _pedBLL.Pedido_Get_AnoInicial
            '--- Adiciona as Colunas
            dtAno.Columns.Add("ANOValue")
            dtAno.Columns.Add("ANONumber")
            '--- Adiciona a possibilidade Qualquer ANO
            dtAno.Rows.Add({0, "TODOS"})
            '
            '--- Adiciona os anos seguintes ate a data atual
            If Not IsNothing(AnoInicial) Then
                '
                For i = 0 To Now.Year - AnoInicial
                    dtAno.Rows.Add({AnoInicial + i, AnoInicial + i})
                Next
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao obter a lista Anos" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
        With cmbAno
            .DataSource = dtAno
            .ValueMember = "ANOValue"
            .DisplayMember = "ANONumber"
            .SelectedValue = Now.Year
        End With
        '
    End Sub
    '
    Private Sub cmb_AoAlterar(sender As Object, e As EventArgs)
        Get_Dados()
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    '--- PROCURAR PEDIDO
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs)
        Get_Dados()
        PreencheListagem()
        dgvListagem.Focus()
        '
        If pedLista.Count = 0 Then
            MessageBox.Show("Nenhum Pedido encontrado nessas condições...", "Procurar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '
    End Sub
    '
    '--- EDITAR PEDIDO
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum Pedido selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim clP As clPedido = dgvListagem.SelectedRows(0).DataBoundItem
        '
        '--- verifica se o frmPedido ja esta aberto
        Dim frm = Application.OpenForms("frmPedido")
        '
        '--- se não esta cria um new
        If IsNothing(frm) Then
            frm = New frmPedido(clP)
        Else
            DirectCast(frm, frmPedido).propPedido = clP
        End If
        '
        frm.MdiParent = frmPrincipal
        frm.StartPosition = FormStartPosition.CenterScreen
        Close()
        frm.Show()
        '
    End Sub
    '
    '--- FECHAR O FORM
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnClose.Click, btnFechar.Click
        '
        If Application.OpenForms("frmPedido") Is Nothing Then
            Close()
            MostraMenuPrincipal()
        Else
            Close()
        End If
        '
    End Sub
    '
    '--- DOUBLE CLICK ABRE O FRMPEDIDO
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnEditar_Click(New Object, New EventArgs)
    End Sub
    '
    '--- PROCURAR FORNECEDORES
    Private Sub btnProcFornecedores_Click(sender As Object, e As EventArgs) Handles btnProcFornecedores.Click
        '
        Dim frmF As New frmFornecedorProcurar(True, Me)
        '
        frmF.ShowDialog()
        If frmF.DialogResult = DialogResult.Cancel Then
            txtFornecedor.Clear()
            _IDFornecedor = Nothing
            btnFornecedor.Enabled = False
        Else
            txtFornecedor.Text = frmF.propFornecedor_Escolha.Cadastro
            _IDFornecedor = frmF.propFornecedor_Escolha.IDPessoa
            btnFornecedor.Enabled = True
        End If
        '
        txtFornecedor.Focus()
        '
    End Sub
    '
    '--- NOVO PEDIDO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '--- cria um novo pedido
        Dim clP As New clPedido
        '
        '--- verifica se o frmPedido ja esta aberto
        Dim frm = Application.OpenForms("frmPedido")
        '
        '--- se não esta cria um new
        If IsNothing(frm) Then
            frm = New frmPedido(clP)
        Else
            DirectCast(frm, frmPedido).propPedido = clP
        End If
        '
        frm.MdiParent = frmPrincipal
        frm.StartPosition = FormStartPosition.CenterScreen
        Close()
        frm.Show()
        '
    End Sub
    '
    '--- EDITAR FORNECEDOR
    Private Sub btnFornecedor_Click(sender As Object, e As EventArgs) Handles btnFornecedor.Click
        '
        Dim fBLL As New FornecedorBLL

        Dim f As clFornecedor = fBLL.GetFornecedores(_IDFornecedor).Item(0)
        Dim frmF As New frmFornecedor(f)
        '
        frmF.MdiParent = frmPrincipal
        frmF.StartPosition = FormStartPosition.CenterScreen
        Close()
        frmF.Show()
        '
    End Sub
    '
    '--- CONTROLE DAS MENSAGENS PADRAO
    Private Sub btnMensagens_Click(sender As Object, e As EventArgs) Handles btnMensagens.Click
        '
        Dim frmMensagem As New frmPedidoMensagens(Me)
        frmMensagem.ShowDialog()
        '
    End Sub
    '
    '--- EXCLUIR PEDIDO
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        '
        '--- verifica se existe algum ROW selecionado
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione o pedido que você deseja Excluir...", "Excluir Pedido",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        '--- verifica o pedido
        Dim ped As clPedido = dgvListagem.SelectedRows(0).DataBoundItem
        '
        '--- pergunta ao usuario
        If MessageBox.Show("Você realmente deseja excluir o registro de Pedido..." & vbNewLine &
                           ped.Fornecedor.ToUpper & vbNewLine &
                           "Data: " & ped.InicioData, "Excluir Pedido",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Exit Sub
        '
        '--- exclui o registro de pedido
        Try
            _pedBLL.Pedido_Excluir(ped.IDPedido)
            Get_Dados()
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir registro de Pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLES GERAIS | FLUXO"
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEditar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFornecedor.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            PreencheListagem()
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLE DOS BTN PESQUISA"
    '
    Private Sub AdicionaHandler()
        AddHandler rbtCompondo.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtRecebidos.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtCancelados.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler rbtEnviado.CheckedChanged, AddressOf Butons_CheckedChanged
    End Sub
    '
    Private Sub RemoverHandler()
        RemoveHandler rbtCompondo.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtRecebidos.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtCancelados.CheckedChanged, AddressOf Butons_CheckedChanged
        RemoveHandler rbtEnviado.CheckedChanged, AddressOf Butons_CheckedChanged
    End Sub
    '
    Private Sub Butons_CheckedChanged(sender As Object, e As EventArgs)
        '
        Dim valorAlterado As Byte?
        '
        If rbtCompondo.Checked = True Then
            valorAlterado = 0 '--- Compondo | Formulando
        ElseIf rbtEnviado.Checked = True Then
            valorAlterado = 1 '--- Enviados
        ElseIf rbtRecebidos.Checked = True Then
            valorAlterado = 2 '--- Recebidos
        ElseIf rbtCancelados.Checked = True Then
            valorAlterado = 3 '--- Cancelados
        Else
            valorAlterado = Nothing
        End If
        '
        If If(propSituacaoAtual, 4) <> If(valorAlterado, 4) Then
            propSituacaoAtual = valorAlterado
            Get_Dados()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "FILTRO FORNECEDOR"
    '
    '--- FILTA O NOME DOS CLIENTES
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtFornecedor.TextChanged
        '
        FiltrarListagem()
        btnFornecedor.Enabled = False
        _IDFornecedor = Nothing
        '
    End Sub
    '
    '--- FILTAR LISTAGEM PELO IDTIPO E IDFILIAL, TXTPRODUTO, TXTNOME
    Private Sub FiltrarListagem()
        '
        dgvListagem.DataSource = pedLista.FindAll(AddressOf FindProduto)
        '
    End Sub
    '
    Private Function FindProduto(ByVal res As clPedido) As Boolean
        '
        If (res.Fornecedor.ToLower Like "*" & txtFornecedor.Text.ToLower & "*") Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
#End Region
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
            Dim pedItem As clPedido = DirectCast(dgvListagem.Rows(hit.RowIndex).DataBoundItem, clPedido)
            '
            If pedItem.Situacao = 0 Then '--- Compondo
                miCompondo.Enabled = False
                miEnviado.Enabled = True
                miRecebido.Enabled = False
                miCancelado.Enabled = True
                miAlteraData.Enabled = True
                '
            ElseIf pedItem.Situacao = 1 Then '--- Enviado
                miCompondo.Enabled = True
                miEnviado.Enabled = False
                miRecebido.Enabled = True
                miCancelado.Enabled = True
                miAlteraData.Enabled = False
                '
            ElseIf pedItem.Situacao = 2 Then '--- Recebido
                miCompondo.Enabled = True
                miEnviado.Enabled = False
                miRecebido.Enabled = False
                miCancelado.Enabled = True
                miAlteraData.Enabled = False
                '
            ElseIf pedItem.Situacao = 3 Then '--- Cancelado
                miCompondo.Enabled = True
                miEnviado.Enabled = False
                miRecebido.Enabled = False
                miCancelado.Enabled = False
                miAlteraData.Enabled = False
                '
            End If
            '
            ' revela menu
            mnuOperacoes.Show(c.PointToScreen(e.Location))
        End If
    End Sub
    ' 
    '--- ALTERAR PARA COMPONDO PEDIDO
    '-------------------------------------------------------------------------------------------------------
    Private Sub miCompondo_Click(sender As Object, e As EventArgs) Handles miCompondo.Click
        '
        Try
            Dim myPed As clPedido = dgvListagem.CurrentRow.DataBoundItem
            _pedBLL.Pedido_AlteraSituacao(myPed.IDPedido, 0, Now)
            myPed.Situacao = 0
            propSituacaoAtual = 0
            Get_Dados()
        Catch ex As Exception
            MessageBox.Show("Houve uma execeção inesperada ao alterar a situação do Pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- ALTERAR PARA PEDIDO ENVIADO
    '-------------------------------------------------------------------------------------------------------
    Private Sub miEnviado_Click(sender As Object, e As EventArgs) Handles miEnviado.Click
        '
        Dim dt As Date? = DataInformar("Informe a Data de Envio do Pedido...",
                                       EnumDataTipo.PassadoPresente,
                                       Today, Me)
        '
        If IsNothing(dt) Then
            Exit Sub
        End If
        '
        Try
            Dim myPed As clPedido = dgvListagem.CurrentRow.DataBoundItem
            _pedBLL.Pedido_AlteraSituacao(myPed.IDPedido, 1, dt)
            myPed.Situacao = 1
            propSituacaoAtual = 1
            Get_Dados()
        Catch ex As Exception
            MessageBox.Show("Houve uma execeção inesperada ao alterar a situação do Pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- ALTERAR PARA PEDIDO RECEBIDO
    '-------------------------------------------------------------------------------------------------------
    Private Sub miRecebido_Click(sender As Object, e As EventArgs) Handles miRecebido.Click
        '
        Dim dt As Date? = DataInformar("Informe a Data que o Pedido foi recebido...",
                                       EnumDataTipo.PassadoPresente, Today, Me)
        '
        If IsNothing(dt) Then
            Exit Sub
        End If
        '
        Try
            Dim myPed As clPedido = dgvListagem.CurrentRow.DataBoundItem
            _pedBLL.Pedido_AlteraSituacao(myPed.IDPedido, 2, dt)
            myPed.Situacao = 2
            propSituacaoAtual = 2
            Get_Dados()
        Catch ex As Exception
            MessageBox.Show("Houve uma execeção inesperada ao alterar a situação do Pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- ALTERAR PARA PEDIDO CANCELADO
    '-------------------------------------------------------------------------------------------------------
    Private Sub miCancelado_Click(sender As Object, e As EventArgs) Handles miCancelado.Click
        '
        Try
            Dim myPed As clPedido = dgvListagem.CurrentRow.DataBoundItem
            _pedBLL.Pedido_AlteraSituacao(myPed.IDPedido, 3, Today)
            myPed.Situacao = 3
            propSituacaoAtual = 3
            Get_Dados()
        Catch ex As Exception
            MessageBox.Show("Houve uma execeção inesperada ao alterar a situação do Pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- ALTERAR DATA DE REVISAO DO PEDIDO
    '-------------------------------------------------------------------------------------------------------
    Private Sub miAlteraData_Click(sender As Object, e As EventArgs) Handles miAlteraData.Click
        '
        Dim dt As Date? = DataInformar("Informe a nova Data de Revisão do Pedido...",
                                       EnumDataTipo.FuturoPresente, Today, Me)
        '
        If IsNothing(dt) Then
            Exit Sub
        End If
        '
        Try
            Dim myPed As clPedido = dgvListagem.CurrentRow.DataBoundItem
            _pedBLL.Pedido_AlteraDataRevisao(myPed.IDPedido, dt)
            dgvListagem.CurrentRow.Cells("clnRevisaoData").Value = CType(dt, Date).ToShortDateString
            'Get_Dados()
        Catch ex As Exception
            MessageBox.Show("Houve uma execeção inesperada ao alterar a DATA de REVISÃO do Pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' APLICA DEGRADEE NOS PANELS
    '-------------------------------------------------------------------------------------------------
    Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlTitulo.Paint, pnlSituacao.Paint
        '
        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)
        '
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
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class
