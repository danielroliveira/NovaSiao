Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
Imports ComponentOwl.BetterListView
'
Public Class frmReservaProcurar
    Private resLista As New List(Of clReserva)
    Private IDProdutoTipo As Integer?
    Private IDFilial As Integer?
    Private LiberaAtualizacao As Boolean = False
    Private ReservaSituacao As clReservaSituacao
    Private rBLL As New ReservaBLL
    '
#Region "NEW | PROPRIEDADES"
    '
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        ReservaSituacao = New clReservaSituacao With {
            .IDSituacaoReserva = 1,
            .ReservaAtiva = True,
            .SituacaoReserva = "Aguardando Pedido"
            }
        '
        DefineLabelSituacao()
        '
        '--- verifica a Filial padrao
        IDFilial = Obter_FilialPadrao()
        If IDFilial Is Nothing Then
            MessageBox.Show("Não há nehuma filial padrão selecionada...", "Filial Padrão",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            lblFilial.Text = ObterDefault("FilialDescricao")
        End If
        '
        '--- preenche a listagem
        Get_Dados()
        FormataListagem()
        FiltrarListagem()
        '
        LiberaAtualizacao = True
        '
    End Sub
    '
    Private Sub frmReservaProcurar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        showToolTip()
    End Sub
    '
    Private Sub Get_Dados()
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            resLista = rBLL.Reserva_GET_List(IDFilial, ReservaSituacao.IDSituacaoReserva, ReservaSituacao.ReservaAtiva)
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu exceção ao obter a listagem de Reservas..." & vbNewLine &
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
    Private Sub DefineLabelSituacao()
        lblReservaAtiva.Text = IIf(ReservaSituacao.ReservaAtiva, "Reservas Ativas", "Reservas Concluídas")
        lblSituacao.Text = ReservaSituacao.SituacaoReserva
    End Sub
    '
#End Region
    '
#Region "LISTAGEM"
    '
    '--- FORMATA LISTAGEM DE CLIENTE
    Private Sub FormataListagem()
        '
        clnIDReserva.DisplayMember = "IDReserva"
        clnIDReserva.ValueMember = "IDReserva"
        clnIDReserva.Width = 70
        '
        clnReservaData.DisplayMember = "ReservaData"
        clnReservaData.ValueMember = "ReservaData"
        clnReservaData.Width = 80
        '
        clnClienteNome.DisplayMember = "ClienteNome"
        clnClienteNome.Width = 150
        '
        clnTelefoneA.DisplayMember = "TelefoneA"
        clnTelefoneA.Width = 110
        '
        clnTelefoneB.DisplayMember = "TelefoneB"
        clnTelefoneB.Width = 110
        '
        clnProduto.DisplayMember = "Produto"
        clnProduto.Width = 250
        '
        clnAutor.DisplayMember = "Autor"
		clnAutor.Width = 120
		'
		clnFornecedor.DisplayMember = "Fornecedor"
        clnFornecedor.Width = 100
        '
        clnFabricante.DisplayMember = "Fabricante"
        clnFabricante.Width = 100
        '
        clnProdutoTipo.DisplayMember = "ProdutoTipo"
		clnProdutoTipo.Width = 90
		'
		clnValorAntecipado.DisplayMember = "ValorAntecipado"
		clnValorAntecipado.ValueMember = "IDPedido"
		clnValorAntecipado.Width = 90
		clnValorAntecipado.AlignHorizontal = TextAlignmentHorizontal.Right
		'
		' setup the list
		With lstListagem
			'
			.BeginUpdate()
			'
			.CheckBoxes = BetterListViewCheckBoxes.TwoState
			.FullRowSelect = True
			.SortedColumnsRowsHighlight = BetterListViewSortedColumnsRowsHighlight.ShowAlways
			.View = BetterListViewView.Details
			'
			.EndUpdate()
			'
		End With
		'

	End Sub
    '
    '--- DESIGN DA LISTAGEM HEADER
    Private Sub lstListagem_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstListagem.DrawColumnHeader
        '
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso
            eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            ' Pode Colocar: AndAlso eventArgs.ColumnHeader.Index = 1 AndAlso
            '
            Dim brush As Brush = New LinearGradientBrush(eventArgs.ColumnHeaderBounds.BoundsOuter, Color.Transparent, Color.FromArgb(150, Color.LightSlateGray), LinearGradientMode.Vertical)

            Dim p As Pen = New Pen(Color.SlateGray, 2)
            '
            eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)
            '
            eventArgs.Graphics.DrawLine(p, eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x1
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Height, 'y1
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Width + eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x2
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Height) 'y2
            brush.Dispose()
            p.Dispose()
        End If
        '
    End Sub
    '
    '--- QUANDO DESENHA ITEM
    Private Sub lstListagem_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstListagem.DrawItem
		'
		If IsNumeric(eventArgs.Item.Text) Then
			'
			'--- formata o IDReserva
			eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "0000")
			'
			'--- formata o valor antecipado
			Dim vlAnt As Double = 0
			Double.TryParse(eventArgs.Item.SubItems(10).Text, vlAnt)
			eventArgs.Item.SubItems(10).Text = Format(vlAnt, "#,##0.00")
			'
			If Not IsNothing(eventArgs.Item.SubItems(10).Value) Then
				eventArgs.Item.BackColor = Color.PeachPuff
			End If
			'
		End If
		'
	End Sub
    '
    '--- QUANDO ATIVA O ITEM EDITA A RESERVA
    Private Sub lstListagem_ItemActivate(sender As Object, eventArgs As BetterListViewItemActivateEventArgs) Handles lstListagem.ItemActivate
        btnEditar_Click(New Object, New System.EventArgs)
    End Sub
    '
    '--- QUANDO MARCA UM ITEM HABILITA O BTN ALTERAR
    Private Sub lstListagem_ItemChecked(sender As Object, eventArgs As BetterListViewItemCheckedEventArgs) Handles lstListagem.ItemChecked
        '
        Dim reserva As clReserva = resLista.First(Function(x) x.IDReserva = eventArgs.Item.Value)
        '
        If Not IsNothing(reserva.IDPedido) AndAlso eventArgs.NewCheckState = CheckState.Checked Then
            AbrirDialog("Essa reserva não pode ser marcada para alteração porque está associada a um PEDIDO..." & vbCrLf &
                        "Para alterá-la, favor remover a associação.",
                        "Reserva com Pedido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            eventArgs.Item.Checked = False
            Exit Sub
        End If
        '
        VerifyCheckedItens()
        '
    End Sub
    '
    '--- VERIFY CHECKED ITEMS
    Private Sub VerifyCheckedItens()
        '
        If lstListagem.CheckedItems.Count > 0 Then
            btnAlterarSituacao.Enabled = True
            btnPrintEtiquetas.Enabled = True
        Else
            btnAlterarSituacao.Enabled = False
            btnPrintEtiquetas.Enabled = False
        End If
        '
    End Sub
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER) DA LISTAGEM
    Private Sub lstListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles lstListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEditar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '
        If lstListagem.SelectedItems.Count = 0 Then
            MessageBox.Show("Não existe nenhuma RESERVA selecionada na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim resID As Integer = lstListagem.SelectedItems(0).Value
        Dim clR As clReserva = resLista.Where(Function(x) x.IDReserva = resID)(0)
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Verifica se o form Reserva ja esta aberto
            Dim frm As Form = Nothing
            '
            For Each f As Form In Application.OpenForms
                If f.Name = "frmReserva" Then
                    frm = f
                End If
            Next
            '
            If IsNothing(frm) Then '--- o frmReserva não esta aberto
                frm = New frmReserva(clR, Me)
                frm.MdiParent = frmPrincipal
                frm.StartPosition = FormStartPosition.CenterScreen
                Me.Visible = False 'Close()
                frm.Show()
            Else '--- o frmReserva já esta aberto
                DirectCast(frm, frmReserva).propReserva = clR
                frm.Focus()
                Me.Visible = False 'Close()
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir a reserva..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        btnEditar_Click(New Object, New EventArgs)
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        '
        Dim frmT As New frmProdutoProcurarTipo(Me, IDProdutoTipo)
        Dim oldID As Integer? = IDProdutoTipo
        '
        frmT.ShowDialog()
        If frmT.DialogResult = DialogResult.Cancel Then
            txtProdutoTipo.Clear()
            IDProdutoTipo = Nothing
        Else
            txtProdutoTipo.Text = frmT.propTipo_Escolha
            IDProdutoTipo = frmT.propIdTipo_Escolha
        End If
        '
        If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(IDProdutoTipo), 0, IDProdutoTipo) Then
            FiltrarListagem()
        End If
        '
        txtProdutoTipo.Focus()
        '
    End Sub
    '
    Private Sub btnNova_Click(sender As Object, e As EventArgs) Handles btnNova.Click
        '
        '--- Verifica se o form Despesa ja esta aberto
        Dim frm As Form = Nothing
        Dim clR As New clReserva
        '
        For Each f As Form In Application.OpenForms
            If f.Name = "frmReserva" Then
                frm = f
            End If
        Next
        '
        If IsNothing(frm) Then '--- o frmReserva não esta aberto
            '
            frm = New frmReserva(clR)
            frm.MdiParent = frmPrincipal
            frm.StartPosition = FormStartPosition.CenterScreen
            Close()
            frm.Show()
        Else '--- o frmReserva já esta aberto
            Close()
            DirectCast(frm, frmReserva).propReserva = clR
        End If
        '
    End Sub
    '
    '--- IMPRIMIR LISTAGEM
    Private Sub btnPrintListagem_Click(sender As Object, e As EventArgs) Handles btnPrintListagem.Click
        MsgBox("Em implementação")
    End Sub
    '
    '--- IMPRIMIR BOTOES
    Private Sub btnPrintEtiquetas_Click(sender As Object, e As EventArgs) Handles btnPrintEtiquetas.Click
        MsgBox("Em implementação")
    End Sub
    '
    '--- ALTERAR SITUACAO DAS RESERVAS SELECIONADAS
    Private Sub btnAlterarSituacao_Click(sender As Object, e As EventArgs) Handles btnAlterarSituacao.Click
        '
        '--- verifica a quantidade de itens selecionados
        If lstListagem.CheckedItems.Count = 0 Then
            AbrirDialog("Necessário selecionar as reservas para alterar a situação...",
                        "Selecionar", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Exit Sub
        End If
        '
        '--- obtem a nova situacao
        Dim newSit As clReservaSituacao = Nothing
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frm As New frmReservaSituacaoProcurar(True, ReservaSituacao, Me)
            '
            frm.ShowDialog()
            If frm.DialogResult <> vbOK Then Exit Sub
            '
            newSit = frm.ReservaSituacaoEscolhida
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de Procura de Situações..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- pergunta ao usuário se deseja realmente realizar alterações
        If MessageBox.Show("Você deseja realmente alterar as Reservas escolhidas para" & vbNewLine &
                           newSit.SituacaoReserva.ToUpper & "?", "Alterar Situação",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Return
        '
        '--- atualiza os registros
        Dim accessBLL As New AcessoControlBLL
        Dim db As Object = accessBLL.GetNewAcessoWithTransaction()
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            For Each i In lstListagem.CheckedItems
                rBLL.Reserva_AlteraSituacao(i.Text, newSit.IDSituacaoReserva, db)
            Next
            '
            '--- COMMIT CHANGES
            accessBLL.CommitAcessoWithTransaction(db)
            '
        Catch ex As Exception
            '
            '--- ROOLBACK ALL CHANGES
            accessBLL.RollbackAcessoWithTransaction(db)
            '
            '--- ERROR MESSAGE
            MessageBox.Show("Houve uma exceção inesperada ao Alterar a situação da reserva no BD" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '--- EXIT
            Exit Sub
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        '--- atualiza a listagem
        Get_Dados()
        FiltrarListagem()
        VerifyCheckedItens()
        '
    End Sub
    '
    Private Sub EscolherSituacao_Click(sender As Object, e As EventArgs) Handles lblReservaAtiva.Click, lblSituacao.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frm As New frmReservaSituacaoProcurar(False, ReservaSituacao, Me)
            '
            frm.ShowDialog()
            If frm.DialogResult <> vbOK Then Exit Sub
            '
            ReservaSituacao = frm.ReservaSituacaoEscolhida
            DefineLabelSituacao()
            '
            Get_Dados()
            FiltrarListagem()
            VerifyCheckedItens()
            '
            pnlAtivas.BackColor = Color.WhiteSmoke
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de Procura de Situações..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' ATALHO F5 PARA ALTERAR A SITUACAO
    '------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            e.Handled = True
            '
            EscolherSituacao_Click(New Object, New EventArgs)
        End If
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "+" Then
            e.Handled = True
        End If
    End Sub
    '
    '--- ESCOLHER PRODUTO TIPO
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProdutoTipo.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtProdutoTipo"
                    btnTipo_Click(New Object, New EventArgs)
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtProdutoTipo"
                    txtProdutoTipo.Clear()
                    IDProdutoTipo = Nothing
            End Select
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNomeCliente.KeyDown,
        txtProdutoTipo.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- FILTA O NOME DOS CLIENTES
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtNomeCliente.TextChanged, txtProduto.TextChanged
        '
        FiltrarListagem()
        '
    End Sub
    '
    '--- FILTAR LISTAGEM PELO IDTIPO E IDFILIAL, TXTPRODUTO, TXTNOME
    Private Sub FiltrarListagem()
        '
        lstListagem.DataSource = resLista.FindAll(AddressOf FindProduto)
        '
    End Sub
    '
    Private Function FindProduto(ByVal res As clReserva) As Boolean
        '
        If IDProdutoTipo Is Nothing Then
            If (res.Produto.ToLower Like "*" & txtProduto.Text.ToLower & "*") AndAlso
                (res.ClienteNome.ToLower Like "*" & txtNomeCliente.Text.ToLower & "*") Then
                Return True
            Else
                Return False
            End If
        Else
            If (res.Produto.ToLower Like "*" & txtProduto.Text.ToLower & "*") AndAlso
                (res.ClienteNome.ToLower Like "*" & txtNomeCliente.Text.ToLower & "*") AndAlso
                (res.IDProdutoTipo = IDProdutoTipo) Then
                Return True
            Else
                Return False
            End If
        End If
        '
    End Function
    '----------------------------------------------------------------------------------------
    '
#End Region
    '
#Region "TRATAMENTO VISUAL"
    '
    '--- ALTERAR A COR DE FUNDO DO HEADER DO DATAGRIDVIEW
    Private Sub dgvListagem_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex = -1 Then
            '--- PRETO
            'Dim c1 As Color = Color.FromArgb(255, 54, 54, 54)
            'Dim c2 As Color = Color.FromArgb(255, 62, 62, 62)
            'Dim c3 As Color = Color.FromArgb(255, 98, 98, 98)
            '
            '--- AZUL
            Dim c1 As Color = Color.FromArgb(255, 143, 154, 168)
            Dim c2 As Color = Color.FromArgb(255, 100, 113, 130)
            Dim c3 As Color = Color.FromArgb(255, 74, 84, 96)
            '
            Dim br As LinearGradientBrush = New LinearGradientBrush(e.CellBounds, c1, c3, 90, True)
            Dim cb As ColorBlend = New ColorBlend()
            '
            cb.Positions = {0, CSng(0.5), 1}
            cb.Colors = {c1, c2, c3}
            br.InterpolationColors = cb
            e.Graphics.FillRectangle(br, e.CellBounds)
            e.PaintContent(e.ClipBounds)
            e.Handled = True
        End If
    End Sub
    '
#End Region
    '
#Region "VISUAL DESIGN"
    '
    Sub me_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        pnlAtivas.BackColor = Color.WhiteSmoke
    End Sub
    '
    Private Sub panel_MouseEnter(sender As Object, e As EventArgs) Handles lblSituacao.MouseEnter, lblReservaAtiva.MouseEnter, pnlAtivas.MouseEnter
        pnlAtivas.BackColor = Color.Azure
    End Sub
    '
    Private Sub showToolTip()
        '
        Dim myControl As Control = pnlAtivas
        '
        ' Cria a ToolTip e associa com o Form container.
        Dim toolTip1 As New ToolTip()
        '
        ' Define o delay para a ToolTip.
        With toolTip1
            .AutoPopDelay = 2000
            .InitialDelay = 1000
            .ReshowDelay = 500
            .IsBalloon = True
            .UseAnimation = True
            .UseFading = True
        End With
        '
        If myControl.Tag = "" Then
            toolTip1.Show("Clique aqui para alterar a Situação ou pressione (F5)", myControl, myControl.Width - 30, -40, 1000)
        Else
            toolTip1.Show(myControl.Tag, myControl, myControl.Width - 30, -40, 1000)
        End If
        '
    End Sub
    '
#End Region '/ VISUAL DESIGN
    '
#Region "MENU CONTEXT RESERVA"
    '
    Private Sub mnuReserva_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuReserva.Opening
        '
        If lstListagem.SelectedItems.Count = 0 Then
            e.Cancel = True
            Exit Sub
        End If
        '
        Dim ID As Integer = lstListagem.SelectedItems(0).Value
        Dim reserva As clReserva = resLista.First(Function(x) x.IDReserva = ID)
        Dim inPedido As Boolean = Not IsNothing(reserva.IDPedido)
        '
        '--- enable or disable items of menu
        miAbrirPedido.Enabled = inPedido
        miDesassociarDoPedido.Enabled = inPedido
        miExcluirReserva.Enabled = Not inPedido And reserva.IDSituacaoReserva = 1

    End Sub
    '
    Private Sub miEditarReserva_Click(sender As Object, e As EventArgs) Handles miEditarReserva.Click
        '
        btnEditar_Click(sender, e)
        '
    End Sub
    '
    Private Sub miExcluirReserva_Click(sender As Object, e As EventArgs) Handles miExcluirReserva.Click
        '
        If lstListagem.SelectedItems.Count = 0 Then
            MessageBox.Show("Não existe nenhuma RESERVA selecionada na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim resID As Integer = lstListagem.SelectedItems(0).Value
        Dim clR As clReserva = resLista.Where(Function(x) x.IDReserva = resID)(0)
        '
        If AbrirDialog("Deseja realmente excluir a Reserva: " & vbCrLf &
                       clR.Produto & vbCrLf &
                       "Para: " & clR.ClienteNome,
                       "Excluir Reserva",
                       frmDialog.DialogType.SIM_NAO,
                       frmDialog.DialogIcon.Question,
                       frmDialog.DialogDefaultButton.Second) = DialogResult.No Then
            Exit Sub
        End If
        '
        '--- VERIFICA Pedido
        Dim subtraiPedido As Boolean = False
        If Not IsNothing(clR.IDPedido) Then
            If AbrirDialog("Essa reserva já foi inserida em um pedido." & vbCrLf &
                           "Você deseja remover uma unidade desse do produto: " & vbCrLf &
                           clR.Produto & vbCrLf &
                           "do Pedido?",
                           "Reserva Vinculada",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                subtraiPedido = True
            End If
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            rBLL.DeleteReserva(clR, subtraiPedido)
            resLista.Remove(clR)
            FiltrarListagem()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Excluir a Reserva..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub miAbrirPedido_Click(sender As Object, e As EventArgs) Handles miAbrirPedido.Click
        '
        Dim pBLL As New PedidoBLL
        Dim ID As Integer = lstListagem.SelectedItems(0).Value
        Dim reserva As clReserva = resLista.First(Function(x) x.IDReserva = ID)
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim pedido As clPedido = pBLL.GetPedidoPeloID(reserva.IDPedido)
            '
            Dim frm As New frmPedido(pedido)
            frm.MdiParent = My.Application.OpenForms().Item(0)
            '
            Close()
            frm.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir o formulário de Pedido..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '
    End Sub
	'
#End Region '/ MENU RESERVA
	'
End Class
