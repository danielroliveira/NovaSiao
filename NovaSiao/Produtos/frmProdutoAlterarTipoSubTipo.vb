Public Class frmProdutoAlterarTipoSubTipo
    '
    Private _IDProdutoTipo As Integer? = Nothing
    Private _IDProdutoSubTipo As Integer? = Nothing
    Private _formOrigem As Form = Nothing
    '
    Public Property propIDTipoEscolhido As Integer? = Nothing
    Public Property propTipoEscolhido As String = ""
    Public Property propIDSubTipoEscolhido As Integer? = Nothing
    Public Property propSubTipoEscolhido As String = ""
    '
#Region "NEW | LOAD"
    Sub New(formOrigem As Form)

        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        CampoNecessario(txtProdutoTipo, False)
        CampoNecessario(txtProdutoSubTipo, False)
        '
    End Sub
#End Region '// NEW | LOAD

#Region "OUTRAS FUNCOES"
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
                "txtProdutoTipo",
                "txtProdutoSubTipo"
            }

            If controlesBloqueados.Contains(ActiveControl.Name) Then
                e.Handled = True
            End If
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtProdutoTipo.KeyDown,
                txtProdutoSubTipo.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            e.SuppressKeyPress = True
            '
            Select Case ctr.Name
                Case "txtProdutoTipo"
                    ProcurarEscolherTipo(sender)
                Case "txtProdutoSubTipo"
                    ProcurarEscolherTipo(sender)
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtProdutoTipo"
                    '
                    txtProdutoTipo.Clear()
                    _IDProdutoTipo = Nothing
                    CampoNecessario(txtProdutoTipo, False)
                    txtProdutoSubTipo.Clear()
                    _IDProdutoSubTipo = Nothing
                    CampoNecessario(txtProdutoSubTipo, False)
                    '
                Case "txtProdutoSubTipo"
                    '
                    txtProdutoSubTipo.Clear()
                    _IDProdutoSubTipo = Nothing
                    CampoNecessario(txtProdutoSubTipo, False)
                    '
            End Select
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({
                                         "txtProdutoTipo",
                                         "txtProdutoSubTipo"
                                         })
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
    '--- ESCOLHER TIPO DE PRODUTO | SUBTIPO DE PRODUTO | CATEGORIA
    Private Sub ProcurarEscolherTipo(sender As Control)
        '
        Dim frmT As Form = Nothing
        Dim oldID As Integer?
        '
        '--- abre o formulário de ProdutoTipo, SubTipo, Categoria, Fabricante
        Select Case sender.Name
            '
            Case "txtProdutoTipo"
                '
                oldID = _IDProdutoTipo
                frmT = New frmProdutoProcurarTipo(Me, oldID)
                '
            Case "txtProdutoSubTipo"
                '
                ' verifica se existe TIPO selecionado
                If IsNothing(_IDProdutoTipo) Then
                    MessageBox.Show("Favor escolher o TIPO de produto, antes de escolher o SUBTIPO/CLASSIFICAÇÃO...",
                        "Escolher Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtProdutoTipo.Focus()
                    Return
                End If
                '
                oldID = _IDProdutoSubTipo
                frmT = New frmProdutoProcurarSubTipo(Me, oldID, _IDProdutoTipo)
                '
        End Select
        '
        ' revela o formulario dependendo do controle acionado
        frmT.ShowDialog()
        '
        ' ao fechar dialog verifica o resultado
        If frmT.DialogResult <> DialogResult.Cancel Then
            '
            Select Case sender.Name
                '
                '
                Case "txtProdutoTipo"
                    '
                    ' Define o tipo escolhido
                    txtProdutoTipo.Text = DirectCast(frmT, frmProdutoProcurarTipo).propTipo_Escolha
                    _IDProdutoTipo = DirectCast(frmT, frmProdutoProcurarTipo).propIdTipo_Escolha
                    CampoNecessario(txtProdutoTipo, True)
                    '
                    '
                    ' Limpa os campos
                    If oldID.GetValueOrDefault <> _IDProdutoTipo.GetValueOrDefault Then
                        '
                        ' remove o SUBTIPO porque o TIPO foi alterado
                        txtProdutoSubTipo.Text = ""
                        _IDProdutoSubTipo = Nothing
                        CampoNecessario(txtProdutoSubTipo, False)
                        '
                    End If
                    '
                    ' move focus
                    txtProdutoTipo.Focus()
                    '
                Case "txtProdutoSubTipo"
                    '
                    ' define o SubTipo escolhido
                    txtProdutoSubTipo.Text = DirectCast(frmT, frmProdutoProcurarSubTipo).propSubTipo_Escolha
                    _IDProdutoSubTipo = DirectCast(frmT, frmProdutoProcurarSubTipo).propIdSubTipo_Escolha
                    CampoNecessario(txtProdutoSubTipo, True)
                    '
                    ' move focus
                    txtProdutoSubTipo.Focus()
                    '
            End Select
            '
        End If
        '
    End Sub

    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles _
        txtProdutoTipo.KeyDown,
        txtProdutoSubTipo.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region '// OUTRAS FUNCOES
    '
#Region "BUTTONS"
    '
    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        '
        propIDTipoEscolhido = _IDProdutoTipo
        If Not IsNothing(propIDTipoEscolhido) Then
            propTipoEscolhido = txtProdutoTipo.Text
        Else
            MessageBox.Show("Escolha o novo Tipo do Produto para ser alterado.", "Produto Tipo",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProdutoTipo.Focus()
            Return
        End If
        '
        propIDSubTipoEscolhido = _IDProdutoSubTipo
        If Not IsNothing(propIDSubTipoEscolhido) Then propSubTipoEscolhido = txtProdutoSubTipo.Text
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
#End Region '// BUTTONS
    '
#Region "TRATAMENTO VISUAL"
    '
    Private Sub CampoNecessario(txt As TextBox, preenchido As Boolean)
        '
        If preenchido = True Then
            txt.ForeColor = Color.Black
            txt.Font = New Font(txt.Font, FontStyle.Regular)
            txt.TextAlign = HorizontalAlignment.Left
        Else
            txt.ForeColor = Color.Silver
            txt.Font = New Font(txt.Font, FontStyle.Italic)
            txt.TextAlign = HorizontalAlignment.Right
            txt.Text = "PREENCHER VALOR..."
        End If
        '
        If IsNothing(_IDProdutoTipo) Or IsNothing(_IDProdutoSubTipo) Then
            btnAlterar.Enabled = False
        Else
            btnAlterar.Enabled = True
        End If
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
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
