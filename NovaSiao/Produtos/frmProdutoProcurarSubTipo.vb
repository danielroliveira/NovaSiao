Imports System.Drawing.Drawing2D
Imports CamadaBLL
Imports ComponentOwl.BetterListView

Public Class frmProdutoProcurarSubTipo
    Private dtSubTipos As DataTable = Nothing
    Private ItemAtivo As Image = My.Resources.accept
    Private ItemInativo As Image = My.Resources.block
    Private _formOrigem As Form = Nothing
    Private indexTipoPadrao As Integer? = Nothing '--- index na listagem do IDpadrao informado
    '
    Property propIdSubTipo_Escolha As Integer
    Property propSubTipo_Escolha As String
    '
#Region "SUB NEW | PROPERTYS"
    '
    Sub New(formOrigem As Form, Optional idSubTipoPadrao As Integer? = Nothing, Optional idTipoPadrao As Integer? = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        ObterSubTipo(idTipoPadrao)
        PreencheListagem()
        '
        _formOrigem = formOrigem
        '
        '--- verifica o subtipo padrao para selecionar na listagem
        If Not IsNothing(idSubTipoPadrao) Then
            For Each i As BetterListViewItem In lstItens
                If i.Text = idSubTipoPadrao Then
                    i.Selected = True
                    indexTipoPadrao = i.Index
                Else
                    i.Selected = False
                End If
            Next
        Else
            For Each i As BetterListViewItem In lstItens.SelectedItems
                i.Selected = False
            Next
        End If
        '
    End Sub
    '
    Private Sub frmFabricanteProcurar_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        '--- quando há IDPadrao informado pelo usuário
        '--- garante que o item selecionado esteja visível na listagem
        If indexTipoPadrao IsNot Nothing Then
            lstItens.EnsureVisible(indexTipoPadrao)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM"
    '
    '--- OBTER OS TIPOS
    Private Sub ObterSubTipo(myTipo As Integer?)
        '
        Dim pBLL As New TipoSubTipoCategoriaBLL
        '
        Try
            '
            If IsNothing(myTipo) Then
                dtSubTipos = pBLL.GetSubTipos
            Else
                dtSubTipos = pBLL.GetSubTipos(myTipo)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter lista de Tipos de Produtos", "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- PREENCHE LISTAGEM
    Private Sub PreencheListagem()
        lstItens.DataSource = dtSubTipos
        FormataListagem()
    End Sub
    '
    '--- FORMATA LISTAGEM DE CLIENTE
    Private Sub FormataListagem()
        '
        lstItens.MultiSelect = False
        lstItens.HideSelection = False
        '
        clnID.DisplayMember = "IDProdutoSubTipo"
        clnSubTipo.DisplayMember = "ProdutoSubTipo"
        clnAtivo.DisplayMember = "Ativo"
        clnAtivo.Width = 0
        '
        lstItens.SearchSettings = New BetterListViewSearchSettings(BetterListViewSearchMode.PrefixOrSubstring,
                                                                   BetterListViewSearchOptions.UpdateSearchHighlight,
                                                                   New Integer() {0, 1})
        '
    End Sub
    '
    '--- DESIGN DA LISTAGEM
    Private Sub lstListagem_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstItens.DrawColumnHeader
        '
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            Dim brush As Brush = New LinearGradientBrush(eventArgs.ColumnHeaderBounds.BoundsOuter, Color.Transparent, Color.FromArgb(64, Color.SteelBlue), LinearGradientMode.Vertical)
            '
            eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)
            brush.Dispose()
            '
        End If
        '
    End Sub
    '
    Private Sub lstItens_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstItens.DrawItem
        '
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "00")
        End If
        '
        eventArgs.Item.SubItems(3).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
        '
        If eventArgs.Item.SubItems(3).Text = "True" Then
            eventArgs.Item.SubItems(2).Image = ItemAtivo
        ElseIf eventArgs.Item.SubItems(3).Text = "False" Then
            eventArgs.Item.SubItems(2).Image = ItemInativo
        End If
        '
    End Sub
    '
    Private Sub lstItens_ItemActivate(sender As Object, eventArgs As BetterListViewItemActivateEventArgs) Handles lstItens.ItemActivate
        btnEscolher_Click(New Object, New System.EventArgs)
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If lstItens.SelectedItems.Count = 0 Then
            MessageBox.Show("Não nenhum SUBTIPO selecionado..." & vbNewLine &
                            "Favor antes selecione um TIPO!",
                            "Escolher SUBTIPO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        ' DEFINIR O VALOR
        propIdSubTipo_Escolha = CInt(lstItens.SelectedItems(0).Text) ' ID DO TIPO
        propSubTipo_Escolha = lstItens.SelectedItems(0).SubItems(1).Text ' DESCRICAO DO TIPO
        '
        Me.DialogResult = DialogResult.OK
        Me.Close()
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
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
#Region "OUTRAS FUNCOES"
    '
    Private Sub txtProcura_TextChanged(sender As Object, e As EventArgs) Handles txtProcura.TextChanged
        '
        ProcurarST()
        '
        Dim itemsFound As BetterListViewItemCollection
        '
        If txtProcura.Text.Length > 0 Then
            itemsFound = lstItens.FindItemsWithText(txtProcura.Text)
        Else
            lstItens.FindItemsWithText("?")
            lstItens.SelectedItems.Clear()
        End If
        '
    End Sub
    '
    ' PROCURAR TIPO
    Private Sub ProcurarST()
        '
        Dim dvClientes As DataView = dtSubTipos.DefaultView
        '
        If txtProcura.TextLength > 0 AndAlso IsNumeric(txtProcura.Text.Substring(0, 1)) Then
            dvClientes.RowFilter = "IDProdutoSubTipo = " & txtProcura.Text
        Else
            dvClientes.RowFilter = "ProdutoSubTipo LIKE '*" & txtProcura.Text & "*'" ' PROCURA PELO NOME
        End If
        '
    End Sub
    '
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ITENS DA LISTAGEM
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnCancelar_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            '
            If lstItens.Items.Count > 0 Then
                If lstItens.SelectedItems.Count > 0 Then
                    Dim i As Integer = lstItens.SelectedItems(0).Index
                    '
                    lstItens.Items(i).Selected = False
                    '
                    If i = 0 Then
                        i = lstItens.Items.Count
                    End If
                    '
                    lstItens.Items(i - 1).Selected = True
                    lstItens.EnsureVisible(i - 1)
                Else
                    lstItens.Items(0).Selected = True
                    lstItens.EnsureVisible(0)
                End If
            End If
            '
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            '
            If lstItens.Items.Count > 0 Then
                If lstItens.SelectedItems.Count > 0 Then
                    Dim i As Integer = lstItens.SelectedItems(0).Index
                    '
                    lstItens.Items(i).Selected = False
                    '
                    If i = lstItens.Items.Count - 1 Then
                        i = -1
                    End If
                    '
                    lstItens.Items(i + 1).Selected = True
                    lstItens.EnsureVisible(i + 1)
                Else
                    lstItens.Items(0).Selected = True
                End If
            End If
            '
        End If
    End Sub
    '
    Private Sub txtProcura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProcura.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            If lstItens.SelectedItems.Count > 0 Then
                btnEscolher_Click(New Object, New System.EventArgs)
            Else
                e.Handled = True
                SendKeys.Send("{Tab}")
            End If
        ElseIf e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
End Class
