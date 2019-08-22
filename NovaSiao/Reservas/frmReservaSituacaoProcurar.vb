Imports CamadaBLL
Imports CamadaDTO
Imports ComponentOwl.BetterListView
Imports System.Drawing.Drawing2D
'
Public Class frmReservaSituacaoProcurar
    '
    Private _formOrigem As Form
    Private list As List(Of clReservaSituacao)
    Private _SituacaoOrigem As clReservaSituacao
    Private _ReservaAtiva As Boolean
    Property ReservaSituacaoEscolhida As clReservaSituacao
    '
#Region "SUB NEW"
    '
    Sub New(IsAlterar As Boolean, SituacaoOrigem As clReservaSituacao, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _SituacaoOrigem = SituacaoOrigem
        _ReservaAtiva = SituacaoOrigem.ReservaAtiva
        _formOrigem = formOrigem
        '
        If _ReservaAtiva Then
            rbtAtivas.Checked = True
        Else
            rbtInativas.Checked = True
        End If
        '
        If IsAlterar Then
            lblTitulo.Text = "Alterar Situação"
        Else
            lblTitulo.Text = "Escolher Situação"
        End If
        '
        GetDados()
        PreencheListagem()
        '
        For Each item In lstItens.Items
            If item.Value = _SituacaoOrigem.IDSituacaoReserva Then
                item.Selected = True
                item.Focused = True
            Else
                item.Selected = False
            End If
        Next
        '
    End Sub
    '
    Private Sub GetDados()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim rBLL As New ReservaBLL
            list = rBLL.ReservaSituacaoGetList()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a lista de situação das reservas..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '/ SUB NEW
    '
#Region "LISTAGEM FORMATACAO"
    '
    ' FORMATAR A LISTAGEM
    Private Sub PreencheListagem()
        '
        lstItens.DataSource = list.Where(Function(x) x.ReservaAtiva = _ReservaAtiva).ToList
        '
        With clnSituacao
            .DisplayMember = "SituacaoReserva"
            .ValueMember = "IDSituacaoReserva"
        End With
        '
    End Sub
    '
    ' ALTERA A COR DO HEADER DO LISTBOX
    Private Sub lstItens_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstItens.DrawColumnHeader
        '
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso
            eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            ' Pode Colocar: AndAlso eventArgs.ColumnHeader.Index = 1 AndAlso
            '
            Dim brush As Brush = New LinearGradientBrush(eventArgs.ColumnHeaderBounds.BoundsOuter, Color.Transparent, Color.FromArgb(100, Color.LightSlateGray), LinearGradientMode.Vertical)
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
    ' ESCREVE OS TEXTOS DE TIPO DE ACESSO NA LISTAGEM
    Private Sub lstItens_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstItens.DrawItem
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "00")
        End If
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If lstItens.SelectedItems.Count = 0 Then
            AbrirDialog("Não nenhuma Situação selecionada..." & vbNewLine &
                        "Favor antes selecione uma Situação!",
                        "Escolher Situação", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Return
        End If
        '
        '--- check if is the same SITUACAO
        If Not IsNothing(_SituacaoOrigem) AndAlso _SituacaoOrigem.IDSituacaoReserva = lstItens.SelectedItems(0).Value Then
            AbrirDialog("O Situação selecionada é igual à anterior" & vbNewLine &
                        "Se deseja alterar, favor escolher uma situação diferente.",
                        "Escolher Situação", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            Return
        End If
        '
        '--- obter SITUACAO
        ReservaSituacaoEscolhida = list.Where(Function(x) x.IDSituacaoReserva = lstItens.SelectedItems(0).Value)(0)
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub lstItens_ItemActivate(sender As Object, eventArgs As BetterListViewItemActivateEventArgs) Handles lstItens.ItemActivate
        '
        btnEscolher_Click(sender, New EventArgs)
        '
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "CONTROLS AND NAVIGATION"
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles rbtInativas.KeyDown, rbtAtivas.KeyDown
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
        If rbtAtivas.Checked = True AndAlso _ReservaAtiva = False Then
            _ReservaAtiva = True
            PreencheListagem()
        ElseIf rbtInativas.Checked = True AndAlso _ReservaAtiva = True Then
            _ReservaAtiva = False
            PreencheListagem()
        End If
        '
    End Sub
    '
#End Region '/ CONTROLS AND NAVIGATION
    '
#Region "EFEITOS SUB-FORMULARIO PADRAO"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmAPagarItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region
    '
End Class
