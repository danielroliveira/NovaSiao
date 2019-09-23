Public Class frmProdutoListagemFiltro
    '
    Public _ProdutoAtivo As Byte
    Public _Movimento As Byte?
    Public _Produto As String
    Public _Autor As String
    Public _IDProdutoTipo As Integer?
    Public _ProdutoTipo As String
    Public _IDProdutoSubTipo As Integer?
    Public _ProdutoSubTipo As String
    Public _IDCategoria As Integer?
    Public _ProdutoCategoria As String
    Public _IDFabricante As Integer?
    Public _Fabricante As String
    Private _formOrigem As Form
    '
#Region "NEW"
    '
    Sub New(ByVal ProdutoAtivo As Byte,
            ByVal Movimento As Byte?,
            ByVal Produto As String,
            ByVal Autor As String,
            ByVal IDProdutoTipo As Integer?,
            ByVal ProdutoTipo As String,
            ByVal IDProdutoSubTipo As Integer?,
            ByVal ProdutoSubTipo As String,
            ByVal IDCategoria As Integer?,
            ByVal ProdutoCategoria As String,
            ByVal IDFabricante As Integer?,
            ByVal Fabricante As String,
            Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        rbtAtivas.TabStop = False
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        _formOrigem = formOrigem
        '
        _ProdutoAtivo = ProdutoAtivo
        _Movimento = Movimento
        _Produto = Produto
        _Autor = Autor
        _IDProdutoTipo = IDProdutoTipo
        _ProdutoTipo = ProdutoTipo
        _IDProdutoSubTipo = IDProdutoSubTipo
        _ProdutoSubTipo = ProdutoSubTipo
        _IDCategoria = IDCategoria
        _ProdutoCategoria = ProdutoCategoria
        _IDFabricante = IDFabricante
        _Fabricante = Fabricante
        '
        PreencheCombo_Movimento()
        '
    End Sub
    '
    Private Sub me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        Select Case _ProdutoAtivo
            Case 1
                rbtAtivas.Checked = True
            Case 2
                rbtInativas.Checked = True
            Case 3
                rbtTodos.Checked = True
        End Select
        '
        txtProduto.Text = _Produto
        txtAutor.Text = _Autor
        txtProdutoTipo.Text = _ProdutoTipo
        txtProdutoSubTipo.Text = _ProdutoSubTipo
        txtProdutoCategoria.Text = _ProdutoCategoria
        txtFabricante.Text = _Fabricante
        cmbMovimento.SelectedValue = _Movimento
        '
        addToolTipHandler()
        '
    End Sub
    '
    '--- ATIVA | INATIVA
    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles _
        rbtAtivas.CheckedChanged,
        rbtInativas.CheckedChanged,
        rbtTodos.CheckedChanged
        '
        Dim newValue As Byte = DirectCast(sender, RadioButton).Tag
        '
        If _ProdutoAtivo = newValue Then Exit Sub
        '
        _ProdutoAtivo = newValue
        '
    End Sub
    '
    '--- PREENCHE O COMBO COM AS SITUACOES POSSIVEIS
    Private Sub PreencheCombo_Movimento()

        Dim dtMov As New DataTable
        '
        'Adiciona todas as possibilidades de movimentacao
        dtMov.Columns.Add("Movimento")
        dtMov.Columns.Add("MovDescricao")
        dtMov.Rows.Add(New Object() {0, "TODAS"})
        dtMov.Rows.Add(New Object() {1, "Normal"})
        dtMov.Rows.Add(New Object() {2, "Sem Movimento"})
        dtMov.Rows.Add(New Object() {3, "Protegido"})
        dtMov.Rows.Add(New Object() {4, "Periódico"})

        With cmbMovimento
            .DataSource = dtMov
            .ValueMember = "Movimento"
            .DisplayMember = "MovDescricao"
        End With
        '
        dtMov.Columns.Add()
        '
    End Sub
    '
#End Region '/ NEW
    '
#Region "FUNCOES NECESSARIAS"
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
                "txtProdutoSubTipo",
                "txtAutor",
                "txtProdutoSubTipo",
                "txtProdutoTipo",
                "txtProdutoCategoria",
                "txtFabricante"
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
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtProdutoTipo.KeyDown,
                txtProdutoSubTipo.KeyDown,
                txtProdutoCategoria.KeyDown,
                txtAutor.KeyDown,
                txtFabricante.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            Select Case ctr.Name
                Case "txtProdutoTipo"
                    ProcurarEscolherTipo(sender)
                Case "txtProdutoSubTipo"
                    ProcurarEscolherTipo(sender)
                Case "txtProdutoCategoria"
                    ProcurarEscolherTipo(sender)
                Case "txtAutor"
                    ProcurarEscolherTipo(sender)
                Case "txtFabricante"
                    ProcurarEscolherTipo(sender)
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtProdutoTipo"
                    txtProdutoTipo.Clear()
                    _IDProdutoTipo = Nothing
                Case "txtProdutoSubTipo"
                    txtProdutoSubTipo.Clear()
                    _IDProdutoSubTipo = Nothing
                Case "txtProdutoCategoria"
                    txtProdutoCategoria.Clear()
                    _IDCategoria = Nothing
                Case "txtFabricante"
                    txtFabricante.Clear()
                    _IDFabricante = Nothing
                Case "txtAutor"
                    txtAutor.Clear()
                    _Autor = Nothing
            End Select
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({
                                         "txtProdutoTipo",
                                         "txtProdutoSubTipo",
                                         "txtProdutoCategoria",
                                         "txtFabricante"
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
    '--- ESCOLHER TIPO DE PRODUTO | SUBTIPO DE PRODUTO | CATEGORIA | FABRICANTE
    Private Sub ProcurarEscolherTipo(sender As Control)
        '
        Dim frmT As Form = Nothing
        Dim oldID As Integer?
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- abre o formulário de ProdutoTipo, SubTipo, Categoria, Fabricante
            Select Case sender.Name
            '
                Case "txtAutor"
                    '
                    oldID = Nothing
                    frmT = New frmAutoresProcurar(Me)
                '
                Case "txtFabricante"
                    '
                    oldID = _IDFabricante
                    frmT = New frmFabricanteProcurar(Me, oldID)
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
                Case "txtProdutoCategoria"
                    '
                    ' verifica se existe TIPO selecionado
                    If IsNothing(_IDProdutoTipo) Then
                        MessageBox.Show("Favor escolher o TIPO de produto, antes de escolher a CATEGORIA...",
                                        "Escolher Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtProdutoTipo.Focus()
                        Return
                    End If
                    '
                    oldID = _IDCategoria
                    frmT = New frmProdutoProcurarCategoria(Me, oldID, _IDProdutoTipo)
                    '
            End Select
            '
            ' revela o formulario dependendo do controle acionado
            frmT.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Evento..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        ' ao fechar dialog verifica o resultado
        If frmT.DialogResult <> DialogResult.Cancel Then
            '
            Select Case sender.Name
            '
                Case "txtAutor"
                    txtAutor.Text = DirectCast(frmT, frmAutoresProcurar).propAutorEscolhido
                    _Autor = DirectCast(frmT, frmAutoresProcurar).propAutorEscolhido
                    '
                    ' move focus
                    txtAutor.Focus()
                    '
                Case "txtFabricante"
                    txtFabricante.Text = DirectCast(frmT, frmFabricanteProcurar).propFab_Escolha
                    _IDFabricante = DirectCast(frmT, frmFabricanteProcurar).propIDFab_Escolha
                    '
                    ' move focus
                    txtFabricante.Focus()
                    '
                Case "txtProdutoTipo"
                    txtProdutoTipo.Text = DirectCast(frmT, frmProdutoProcurarTipo).propTipo_Escolha
                    _IDProdutoTipo = DirectCast(frmT, frmProdutoProcurarTipo).propIdTipo_Escolha
                    '
                    ' Filtra Listagem novamente
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_IDProdutoTipo), 0, _IDProdutoTipo) Then
                        '
                        ' remove o SUBTIPO e a CATEGORIA porque o TIPO foi alterado
                        txtProdutoSubTipo.Text = ""
                        _IDProdutoSubTipo = Nothing
                        txtProdutoCategoria.Text = ""
                        _IDCategoria = Nothing
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
                    '
                    ' move focus
                    txtProdutoSubTipo.Focus()
                    '
                Case "txtProdutoCategoria"
                    '
                    ' define a categoria escolhida
                    txtProdutoCategoria.Text = DirectCast(frmT, frmProdutoProcurarCategoria).propCategoria_Escolha
                    _IDCategoria = DirectCast(frmT, frmProdutoProcurarCategoria).propIdCategoria_Escolha
                    '
                    ' move focus
                    txtProdutoCategoria.Focus()
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
        txtProduto.KeyDown,
        txtFabricante.KeyDown,
        txtAutor.KeyDown,
        txtProdutoTipo.KeyDown,
        txtProdutoSubTipo.KeyDown,
        txtProdutoCategoria.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- LIMPA TODOS OS CONTROLES E PREENCHE A LISTAGEM
    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        '
        '--- cria uma lista de controles que serao limpos
        Dim controlesLimpar As TextBox() = {
                txtProduto,
                txtProdutoTipo,
                txtProdutoSubTipo,
                txtProdutoCategoria,
                txtAutor,
                txtFabricante
            }
        '
        For Each t In controlesLimpar
            t.Clear()
        Next
        '
        rbtAtivas.Checked = True
        '
        _Autor = Nothing
        _Produto = Nothing
        _IDProdutoTipo = Nothing
        _IDProdutoSubTipo = Nothing
        _IDCategoria = Nothing
        _IDFabricante = Nothing
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        '
        _Produto = txtProduto.Text
        _Autor = txtAutor.Text
        _ProdutoTipo = txtProdutoTipo.Text
        _ProdutoSubTipo = txtProdutoSubTipo.Text
        _ProdutoCategoria = txtProdutoCategoria.Text
        _Fabricante = txtFabricante.Text
        _Movimento = CByte(cmbMovimento.SelectedValue)
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub txtProduto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtProduto.Validating
        '
        If txtProduto.Text.Trim.Length > 0 Then
			txtProduto.Text = Utilidades.removeAcentos(txtProduto.Text).ToUpper
		End If
        '
    End Sub
    '
#End Region '/ FUNCOES NECESSARIAS
    '
#Region "VISUAL DESIGN"
    '
    '--- ALTERA A COR DO PAINEL QUANDO RECEBE O FOCO
    Private Sub pnlAtivas_EnterLeave(sender As Object, e As EventArgs) _
        Handles _
        rbtAtivas.GotFocus, rbtAtivas.LostFocus,
        rbtInativas.GotFocus, rbtInativas.LostFocus,
        rbtTodos.GotFocus, rbtTodos.LostFocus
        '
        If rbtAtivas.ContainsFocus OrElse rbtInativas.ContainsFocus OrElse rbtTodos.ContainsFocus Then
            pnlAtivas.BackColor = Color.LightSteelBlue
        Else
            pnlAtivas.BackColor = Color.FromArgb(223, 228, 231)
        End If
        '
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
#End Region '/ VISUAL DESIGN
    '
#Region "TOOLTIPS"
    '
    Private Sub addToolTipHandler()
        '
        ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
        txtAutor.Tag = "Digite o Autor ou Pressione '+'  para escolher..."
        '
        Dim listControles As New List(Of Control)
        '
        listControles.Add(txtProdutoTipo)
        listControles.Add(txtProdutoSubTipo)
        listControles.Add(txtProdutoCategoria)
        listControles.Add(txtAutor)
        listControles.Add(txtFabricante)
        '
        For Each c As Control In listControles
            AddHandler c.GotFocus, AddressOf showToolTip
            AddHandler c.MouseHover, AddressOf showToolTip
        Next
        '
    End Sub
    '
    Private Sub showToolTip(sender As Object, e As EventArgs)
        '
        Dim myControl As Control = DirectCast(sender, Control)
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
            toolTip1.Show("Pressione '+'  para escolher...", myControl, myControl.Width - 30, -40, 1000)
        Else
            toolTip1.Show(myControl.Tag, myControl, myControl.Width - 30, -40, 1000)
        End If
        '
        RemoveHandler myControl.GotFocus, AddressOf showToolTip
        RemoveHandler myControl.MouseHover, AddressOf showToolTip
        '
    End Sub
    '
#End Region '// TOOLTIPS
    '
End Class
