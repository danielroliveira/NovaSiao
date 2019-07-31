Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
Imports ComponentOwl.BetterListView
'
Public Class frmReservaProcurar
    Private resLista As New List(Of clReserva)
    Private dtSituacao As DataTable
    Private IDProdutoTipo As Integer?
    Private IDFilial As Integer?
    Private _ReservaAtiva As Boolean?
    Private LiberaAtualizacao As Boolean = False
    '
    Friend WithEvents miOpcao1 As ToolStripMenuItem
    Friend WithEvents miOpcao2 As ToolStripMenuItem
    Friend WithEvents miOpcao3 As ToolStripMenuItem
    Friend WithEvents miOpcao4 As ToolStripMenuItem
    Friend WithEvents miOpcao5 As ToolStripMenuItem
    '
#Region "NEW | PROPRIEDADES"
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propReservaAtiva = True
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
        Get_Situacao()
        FormataListagem()
        FiltrarListagem()
        PreencheCombo_Situacao()
        cmbIDSituacao.SelectedValue = 1
        '
        CriaMenuAlteracao()
        LiberaAtualizacao = True
        '
    End Sub
    '
    Private Property propReservaAtiva() As Boolean?
        Get
            Return _ReservaAtiva
        End Get
        Set(ByVal value As Boolean?)
            _ReservaAtiva = value
            '
            Select Case value
                '--- seleciona o RADIO BUTON
                Case True '--- ATIVAS
                    rbtAtivas.Checked = True
                    rbtInativas.Checked = False
                    '
                Case False '--- INATIVAS
                    rbtAtivas.Checked = False
                    rbtInativas.Checked = True
                    '
            End Select
            '
            If LiberaAtualizacao = True Then
                PreencheCombo_Situacao()
                cmbIDSituacao_SelectedValueChanged(New Object, New EventArgs)
                CriaMenuAlteracao()
            End If
            '
        End Set
        '
    End Property
    '
    '--- PREENCHE O COMBO COM AS SITUACOES POSSIVEIS
    Private Sub PreencheCombo_Situacao()
        '
        '--- filtra o DataTable pelo Ativo/Inativo
        dtSituacao.DefaultView.RowFilter = "ReservaAtiva = " & propReservaAtiva
        '
        '--- adiciona a situação de TODAS AS SITUAÇÕES
        Dim r As DataRow = dtSituacao.NewRow()
        r("IDSituacaoReserva") = 100
        r("SituacaoReserva") = IIf(propReservaAtiva = True, "TODAS SITUAÇÕES ATIVAS", "TODAS SITUAÇÕES CONCLUÍDAS")
        r("ReservaAtiva") = propReservaAtiva
        dtSituacao.Rows(dtSituacao.Rows.Count - 1).Delete()
        dtSituacao.Rows.Add(r)
        '
        dtSituacao.DefaultView.Sort() = "IDSituacaoReserva"
        '
        cmbIDSituacao.DataSource = dtSituacao
        cmbIDSituacao.ValueMember = "IDSituacaoReserva"
        cmbIDSituacao.DisplayMember = "SituacaoReserva"
        '
        '--- Escolhe o valor DEFAULT para Situacao
        cmbIDSituacao.SelectedValue = DirectCast(cmbIDSituacao.Items(0), DataRowView)("IDSituacaoReserva")
        '
    End Sub
    '
    Private Sub Get_Situacao()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim rBLL As New ReservaBLL
            dtSituacao = rBLL.ReservaSituacao_GET_DT()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a situação das reservas..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub Get_Dados()
        '
        Dim ReservaBLL As New ReservaBLL
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If cmbIDSituacao.SelectedValue = 100 Then '--- TODAS AS SITUACOES
                resLista = ReservaBLL.Reserva_GET_List(IDFilial, , _ReservaAtiva)
            Else
                resLista = ReservaBLL.Reserva_GET_List(IDFilial, cmbIDSituacao.SelectedValue, _ReservaAtiva)
            End If
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
            frm = New frmReserva(clR)
            frm.MdiParent = frmPrincipal
            frm.StartPosition = FormStartPosition.CenterScreen
            Close()
            frm.Show()
        Else '--- o frmReserva já esta aberto
            DirectCast(frm, frmReserva).propReserva = clR
            frm.Focus()
            Close()
        End If
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
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    '--- QUANDO ATUALIZAR O COMBO SITUACAO
    Private Sub cmbIDSituacao_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIDSituacao.SelectedValueChanged
        '
        If LiberaAtualizacao Then
            Get_Dados()
            FiltrarListagem()
            chkAlterarSituacao.Enabled = False
        End If
        '
    End Sub
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
        txtProdutoTipo.KeyDown, rbtInativas.KeyDown, rbtAtivas.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- ATIVA | INATIVA
    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles rbtAtivas.CheckedChanged,
        rbtInativas.CheckedChanged
        '
        If rbtAtivas.Checked = True AndAlso propReservaAtiva = False Then
            propReservaAtiva = True
        ElseIf rbtInativas.Checked = True AndAlso propReservaAtiva = True Then
            propReservaAtiva = False
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
    'Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs)
    '    '
    '    Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
    '    e.Graphics.FillRectangle(brush, e.ClipRectangle)
    '    '
    'End Sub
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
        clnAutor.Width = 150
        '
        clnFornecedor.DisplayMember = "Fornecedor"
        clnFornecedor.Width = 100
        '
        clnFabricante.DisplayMember = "Fabricante"
        clnFabricante.Width = 100
        '
        clnProdutoTipo.DisplayMember = "ProdutoTipo"
        clnProdutoTipo.Width = 100
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
            .ContextMenuStrip = mnuListagem
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
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "0000")
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
        chkAlterarSituacao.Checked = False
        '
        If lstListagem.CheckedItems.Count > 0 Then
            chkAlterarSituacao.Enabled = True
            btnPrintEtiquetas.Enabled = True
        Else
            chkAlterarSituacao.Enabled = False
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
#Region "MENU SUSPENSO ALTERAR SITUACAO"
    '
    '--- REVELA O MENU DE ALTERACAO QUANDO PRESSIONA O BOTAO
    Private Sub chkAlterarSituacao_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlterarSituacao.CheckedChanged
        '
        If chkAlterarSituacao.Checked = False Then
            mnuListagem.Hide()
        Else
            '
            '--- desabilita o menu caso seja igual ao escolhido
            For Each t As ToolStripMenuItem In mnuListagem.Items
                If t.Tag = cmbIDSituacao.SelectedValue Then
                    t.Enabled = False
                Else
                    t.Enabled = True
                End If
            Next
            '
            '--- revela o menu
            Dim p As New Point(chkAlterarSituacao.Location.X + chkAlterarSituacao.Width, chkAlterarSituacao.Location.Y)
            'mnuListagem.Show(Me, p)
            mnuListagem.Show(Me, p, ToolStripDropDownDirection.AboveLeft)
            '
        End If
        '
    End Sub
    '
    Private Sub chkAlterarSituacao_LostFocus(sender As Object, e As EventArgs) Handles chkAlterarSituacao.LostFocus
        chkAlterarSituacao.Checked = False
    End Sub
    '
    '--- CRIAR O MENU ALTERACAO
    Private Sub CriaMenuAlteracao()

        '--- limpa todas os itemns
        mnuListagem.Items.Clear()

        miOpcao1 = New ToolStripMenuItem()
        miOpcao2 = New ToolStripMenuItem()
        miOpcao3 = New ToolStripMenuItem()
        miOpcao4 = New ToolStripMenuItem()
        miOpcao5 = New ToolStripMenuItem()

        Dim viewR As DataView = New DataView(dtSituacao)
        viewR.RowFilter = "IDSituacaoReserva <> 100 AND ReservaAtiva = " & propReservaAtiva

        If dtSituacao.Rows.Count > 0 Then

            Dim maxItens As Byte = 1

            For Each r In viewR.ToTable.Rows

                If r("ReservaAtiva") = propReservaAtiva Then

                    Select Case maxItens
                        Case 1
                            miOpcao1.Text = r("SituacaoReserva")
                            miOpcao1.Tag = r("IDSituacaoReserva")
                            miOpcao1.Image = Global.NovaSiao.My.Resources.Resources.refresh
                            Me.mnuListagem.Items.Add(miOpcao1)
                        Case 2
                            miOpcao2.Text = r("SituacaoReserva")
                            miOpcao2.Tag = r("IDSituacaoReserva")
                            miOpcao2.Image = Global.NovaSiao.My.Resources.Resources.refresh
                            Me.mnuListagem.Items.Add(miOpcao2)
                        Case 3
                            miOpcao3.Text = r("SituacaoReserva")
                            miOpcao3.Tag = r("IDSituacaoReserva")
                            miOpcao3.Image = Global.NovaSiao.My.Resources.Resources.refresh
                            Me.mnuListagem.Items.Add(miOpcao3)
                        Case 4
                            miOpcao4.Text = r("SituacaoReserva")
                            miOpcao4.Tag = r("IDSituacaoReserva")
                            miOpcao4.Image = Global.NovaSiao.My.Resources.Resources.refresh
                            Me.mnuListagem.Items.Add(miOpcao4)
                        Case 5
                            miOpcao5.Text = r("SituacaoReserva")
                            miOpcao5.Tag = r("IDSituacaoReserva")
                            miOpcao5.Image = Global.NovaSiao.My.Resources.Resources.refresh
                            Me.mnuListagem.Items.Add(miOpcao5)
                    End Select

                    maxItens += 1

                End If

                If maxItens > 5 Then Exit For

            Next

        End If

    End Sub
    '
    '--- ALTERAR A SITUACAO
    Private Sub Alterar_Situacao_Click(sender As Object, e As EventArgs) Handles miOpcao1.Click,
            miOpcao2.Click, miOpcao3.Click, miOpcao4.Click, miOpcao5.Click
        '
        '--- verifica a quantidade de itens selecionados
        If lstListagem.CheckedItems.Count = 0 Then Exit Sub
        '
        '--- obtem o item escolhido
        Dim mnu As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim NovaSituacao As Byte = mnu.Tag
        Dim NovaSituacaoTexto As String = mnu.Text
        '
        '--- pergunta ao usuário se deseja realmente realizar alterações
        If MessageBox.Show("Você deseja realmente alterar as Reservas escolhidas para" & vbNewLine &
                           NovaSituacaoTexto.ToUpper & "?", "Alterar Situação",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Return
        '
        '--- atualiza os registros
        For Each i In lstListagem.CheckedItems
            Dim rBLL As New ReservaBLL
            '
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                rBLL.Reserva_AlteraSituacao(i.Text, NovaSituacao)
                '
            Catch ex As Exception
                MessageBox.Show("Houve uma exceção inesperada ao Alterar a situação da reserva no BD" & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
            '
        Next
        '
        '--- atualiza a listagem
        Get_Dados()
        FiltrarListagem()
        '
    End Sub
    '
#End Region
    '
End Class
