Imports CamadaBLL
Imports CamadaDTO
Imports ComponentOwl.BetterListView
Imports System.Drawing.Drawing2D
'
Public Class frmPedidoImportarMigrar
    '
    Private _formOrigem As Form
    Private _IDFornecedor As Integer? = Nothing
    Private pedLista As List(Of clPedido)
    Private _IDPedidoOrigem As Integer
    Property propPedido As clPedido
    Property propIDFilial As Integer
    '
#Region "SUB NEW"
    '
    Sub New(IsImportar As Boolean, IDFornecedor As Integer?, IDPedidoOrigem As Integer, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propIDFilial = Obter_FilialPadrao()
        txtFilial.Text = ObterDefault("FilialDescricao")
        _IDFornecedor = IDFornecedor
        _IDPedidoOrigem = IDPedidoOrigem
        _formOrigem = formOrigem
        '
        If IsImportar Then
            lblTitulo.Text = "Importar Pedido"
        Else
            lblTitulo.Text = "Migrar para Pedido"
        End If
        '
        GetDados()
        '
    End Sub
    '
    Private Sub GetDados()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim _pedBLL As New PedidoBLL
            pedLista = _pedBLL.Pedido_GET_List(0, propIDFilial)
            PreencheListagem()
            '
            If pedLista.Count = 0 Then
                btnImportar.Enabled = False
                AbrirDialog("Não foi encontrado nenhum pedido em composição na filial " + txtFilial.Text.ToUpper,
                            "Nenhum pedido encontrado", frmDialog.DialogType.OK,
                            frmDialog.DialogIcon.Information)
            Else
                btnImportar.Enabled = True
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter informações dos pedidos..." & vbNewLine &
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
        lstItens.DataSource = pedLista
        '
        With clnIDPedido
            .DisplayMember = "IDPedido"
            .ValueMember = "IDPedido"
        End With
        '
        With clnData
            .DisplayMember = "InicioData"
            .ValueMember = "InicioData"
        End With
        '
        With clnFornecedor
            .ValueMember = "IDFornecedor"
            .DisplayMember = "Fornecedor"
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
    Private Sub btnFilialEscolher_Click(sender As Object, e As EventArgs) Handles btnFilialEscolher.Click
        '
        '--- Abre o frmFilial
        Dim fFil As New frmFilialEscolher(Me, propIDFilial)
        '
        fFil.ShowDialog()
        '
        If fFil.DialogResult <> DialogResult.OK Then Exit Sub
        '
        '--- check if there was changes
        If fFil.propFilial.ApelidoFilial <> txtFilial.Text Then
            propIDFilial = fFil.propFilial.IDPessoa
            txtFilial.Text = fFil.propFilial.ApelidoFilial
            '
            GetDados()
            '
        End If
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        '
        If lstItens.SelectedItems.Count = 0 Then
            AbrirDialog("Não nenhum Pedido selecionado..." & vbNewLine &
                        "Favor antes selecione um pedido!",
                        "Escolher Pedido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            Return
        End If
        '
        '--- check if is the same FORNECEDOR
        If Not IsNothing(_IDFornecedor) AndAlso _IDFornecedor <> lstItens.SelectedItems(0).SubItems(2).Value Then
            AbrirDialog("O Pedido Importado | Migrado devem ser do mesmo fornecedor..." & vbNewLine &
                        "Favor selecionar um pedido que seja para o mesmo fornecedor!",
                        "Escolher Pedido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            Return
        End If
        '
        '--- check if is the same PEDIDO ORIGEM
        If _IDPedidoOrigem = lstItens.SelectedItems(0).Value Then
            AbrirDialog("Não é possível importar ou migrar um pedido no próprio pedido" & vbNewLine &
                        "Favor selecionar um pedido diferente do pedido para o qual você deseja importar | migrar",
                        "Escolher Pedido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            Return
        End If
        '
        '--- obter o ID do pedido
        propPedido = pedLista.Where(Function(x) x.IDPedido = lstItens.SelectedItems(0).Value)(0)
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub lstItens_ItemActivate(sender As Object, eventArgs As BetterListViewItemActivateEventArgs) Handles lstItens.ItemActivate
        '
        btnImportar_Click(sender, New EventArgs)
        '
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "CONTROLS AND NAVIGATION"
    '
    '---------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
            "txtFilial"
        }
            '
            If controlesBloqueados.Contains(ActiveControl.Name) Then
                e.Handled = True
            End If
            '
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilial.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtFilial"
                    btnFilialEscolher_Click(New Object, New EventArgs)
                    txtFilial.SelectAll()
            End Select
        ElseIf e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
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
