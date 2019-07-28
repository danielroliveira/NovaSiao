Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
Imports ComponentOwl.BetterListView
'
Public Class frmProdutoListagem
    Private prodLista As New List(Of clProduto)
    '
    Private _IDProdutoTipo As Integer?
    Private _IDProdutoSubTipo As Integer?
    Private _IDCategoria As Integer?
    Private _IDFabricante As Integer?
    Private _IDFilial As Integer?
    Private _ProdutoAtivo As Byte '--> 0:TODOS | 1:ATIVOS | 2:INATIVOS
    '
    Private _HabilitaPesquisa As Boolean = True '-- property que habilita o btnPesquisar
    '
    Private myWhere As String = ""
    Private LiberaAtualizacao As Boolean = False
    Private _totalProdutos As Integer ' quantidade total de produtos da listagem
    '
    '--- IMAGENS
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    '
#Region "NEW | PROPRIEDADES"
    '
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- verifica a Filial padrao
        _IDFilial = Obter_FilialPadrao()
        '
        If _IDFilial Is Nothing Then
            MessageBox.Show("Não há nehuma filial padrão selecionada...", "Filial Padrão",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            lblFilial.Text = ObterDefault("FilialDescricao")
        End If
        '
        '--- preenche a listagem
        propProdutoAtivo = 1 '--- ATIVO
        PreencheCombo_Movimento()
        cmbMovimento.SelectedValue = 0 '--- MOV NORMAL
        FormataListagem()
        propHabilitaPesquisa = False
        'Get_Dados()
        'FiltrarListagem()
        AtualizaLabelSelecionados()
        '
        LiberaAtualizacao = True
        '
    End Sub
    '
    Private Sub me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addToolTipHandler()
    End Sub
    '
    Private Property propProdutoAtivo() As Byte
        Get
            Return _ProdutoAtivo
        End Get
        Set(ByVal value As Byte)
            '
            Dim atualizar As Boolean = IIf(_ProdutoAtivo = value, False, True)
            '
            _ProdutoAtivo = value
            '
            Select Case value
                '--- seleciona o RADIO BUTON
                Case 1 '--- ATIVAS
                    If rbtAtivas.Checked <> True Then
                        '
                        rbtAtivas.Checked = True
                        rbtInativas.Checked = False
                        rbtTodos.Checked = False
                        '
                    End If
                    '
                Case 2 '--- INATIVAS
                    If rbtInativas.Checked <> True Then
                        '
                        rbtInativas.Checked = True
                        rbtAtivas.Checked = False
                        rbtTodos.Checked = False
                        '
                    End If
                    '
                Case 3 '--- TODAS
                    If rbtTodos.Checked <> True Then
                        '
                        rbtTodos.Checked = True
                        rbtAtivas.Checked = False
                        rbtInativas.Checked = False
                        '
                    End If
                    '
            End Select
            '
            If atualizar Then AtualizaListagem()
            '
        End Set
        '
    End Property
    '
    '--- HABILITAR PROCURA DE DADOS
    Public Property propHabilitaPesquisa() As Boolean
        '
        Get
            Return _HabilitaPesquisa
        End Get
        '
        Set(ByVal value As Boolean)
            '
            If value <> _HabilitaPesquisa Then
                '
                If value = True Then
                    '
                    btnPesquisar.Enabled = True
                    lstListagem.Clear(True)
                    '
                Else
                    btnPesquisar.Enabled = False
                End If
                '
            End If
            '
            '--- Define o TOOLTIP
            If value = True Then
                '
                Dim toolTip1 As New ToolTip
                ' Define o delay para a ToolTip.
                With toolTip1
                    .AutoPopDelay = 2000
                    .InitialDelay = 1000
                    .ReshowDelay = 500
                    .IsBalloon = True
                    .UseAnimation = True
                    .UseFading = True
                End With
                toolTip1.Show("Pressione AQUI...", btnPesquisar, btnPesquisar.Width - 30, -40, 1000)
                '
            End If
            '
            _HabilitaPesquisa = value
            '
        End Set
        '
    End Property
    '
    '--- QUANTIDADE TOTAL DOS FILTRADOS
    Public Property totalProdutos() As Integer
        Get
            Return _totalProdutos
        End Get
        Set(ByVal value As Integer)
            _totalProdutos = value
            '
            If value = 0 Then
                lblTotalProdutos.Text = "Nenhum Produto Encontrado"
            ElseIf value = 1 Then
                lblTotalProdutos.Text = "01 Produto Encontrado"
            Else
                lblTotalProdutos.Text = Format(value, "00") & " Produtos"
            End If
            '
        End Set
    End Property
    '
    '--- PREENCHE O COMBO COM AS SITUACOES POSSIVEIS
    Private Sub PreencheCombo_Movimento()

        Dim dtMov As New DataTable
        '
        'Adiciona todas as possibilidades de movimentacao
        dtMov.Columns.Add("Movimento")
        dtMov.Columns.Add("MovDescricao")
        dtMov.Rows.Add(New Object() {0, "Normal"})
        dtMov.Rows.Add(New Object() {1, "Sem Movimento"})
        dtMov.Rows.Add(New Object() {2, "Protegido"})
        dtMov.Rows.Add(New Object() {3, "Periódico"})

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
    Private Sub Get_Dados()
        '
        Dim prodBLL As New ProdutoBLL
        '
        '--- consulta o banco de dados
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Verifica a quantidade de produtos retornados
            If prodBLL.CountProdutos_Where(GetWhere) > 100 Then
                If MessageBox.Show("Maior que 100...") = DialogResult.No Then
                    'Return
                End If
            End If
            '
            '--- Get BD Dados
            prodLista = prodBLL.GetProdutosWithEstoque_Where(_IDFilial, GetWhere)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter lista de produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- CRIA E RETORNA A CLAUSULA WHERE DA BUSCA NO BD
    Private Function GetWhere() As String
        '
        myWhere = "Movimento = " & cmbMovimento.SelectedValue
        '
        '--- Produto ATIVO | INATIVO | TODOS
        If propProdutoAtivo <> 3 Then
            myWhere = myWhere & " AND ProdutoAtivo = '" & IIf(propProdutoAtivo = 1, True, False) & "'"
        End If
        '
        '--- ProdutoTipo
        If Not IsNothing(_IDProdutoTipo) Then
            myWhere = myWhere & " AND IDProdutoTipo = " & _IDProdutoTipo
        End If
        '
        '--- ProdutoSubTipo
        If Not IsNothing(_IDProdutoSubTipo) Then
            myWhere = myWhere & " AND IDProdutoSubTipo = " & _IDProdutoSubTipo
        End If
        '
        '--- ProdutoCategoria
        If Not IsNothing(_IDCategoria) Then
            myWhere = myWhere & " AND IDCategoria = " & _IDCategoria
        End If
        '
        '--- ProdutoCategoria
        If Not IsNothing(_IDFabricante) Then
            myWhere = myWhere & " AND IDFabricante = " & _IDFabricante
        End If
        '
        Return myWhere
        '
    End Function
    '
    '--- FILTAR LISTAGEM PELO IDTIPO E _IDFilial, TXTPRODUTO, TXTNOME
    Private Sub FiltrarListagem()
        '
        If txtProduto.Text.Length > 0 OrElse txtAutor.Text.Length > 0 Then
            lstListagem.DataSource = prodLista.FindAll(AddressOf FindProduto)
        Else
            lstListagem.DataSource = prodLista
            'lstListagem.DataSource = prodLista.Take(8).ToList
            'lstListagem.DataSource = prodLista.GetRange(0, 7)
        End If
        '
    End Sub
    '
    Private Function FindProduto(ByVal p As clProduto) As Boolean
        '
        If (p.Produto.ToLower Like "*" & txtProduto.Text.ToLower & "*") AndAlso
           (p.Autor.ToLower Like "*" & txtAutor.Text.ToLower & "*") Then
            Return True
        Else
            Return False
        End If
        '
        '--- CASO SEJA SERVIDOR LOCAL...
        '-----------------------------------------------------------------------------------------------------
        'If (p.Produto.ToLower Like "*" & txtProduto.Text.ToLower & "*") AndAlso
        '   (p.Autor.ToLower Like "*" & txtAutor.Text.ToLower & "*") AndAlso
        '   IIf(IsNothing(_IDProdutoTipo), True, (p.IDProdutoTipo = _IDProdutoTipo)) AndAlso
        '   IIf(IsNothing(_IDProdutoSubTipo), True, (p.IDProdutoSubTipo = _IDProdutoSubTipo)) AndAlso
        '   IIf(IsNothing(_IDCategoria), True, (p.IDCategoria = _IDCategoria)) AndAlso
        '   IIf(IsNothing(_IDFabricante), True, (p.IDFabricante = _IDFabricante)) Then
        '    Return True
        'Else
        '    Return False
        'End If
        '-----------------------------------------------------------------------------------------------------
        '
    End Function
    '
    '--- ATUALIZA A LISTAGEM
    Private Sub AtualizaListagem()
        '
        '--- verifica se ja esta liberado a pesquisa
        If Not LiberaAtualizacao Then Exit Sub
        '
        Get_Dados()
        'MsgBox(myWhere)
        FiltrarListagem()
        propHabilitaPesquisa = False
        '
        '--- uncheck todos os items
        If chkSelecionarTudo.Checked = True Then
            AtualizaLabelSelecionados()
            chkSelecionarTudo.Checked = False
        End If
        '
        '
    End Sub
    '
    '--- ATUALIZA LBLSELECIONADOS
    Private Sub AtualizaLabelSelecionados()
        '
        Dim sel As Integer = lstListagem.CheckedItems.Count
        '
        If sel > 0 Then
            chkAlterarProdutos.Enabled = True
            '
            If sel = 1 Then
                lblSelTitulo.Visible = True
                lblSelecionados.Visible = True
                lblSelecionados.Text = "01 Produto Selecionado"
            Else
                lblSelTitulo.Visible = True
                lblSelecionados.Visible = True
                lblSelecionados.Text = Format(sel, "00") & " Produtos Selecionados"
            End If
            '
        Else
            lblSelTitulo.Visible = False
            lblSelecionados.Visible = False
            chkAlterarProdutos.Enabled = False
        End If
        '
    End Sub
    '----------------------------------------------------------------------------------------
    '
#End Region '// LOAD | NEW
    '
#Region "ACAO DOS BOTOES"
    '
    '--- PESQUISA NO BD
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        '
        AtualizaListagem()
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
        _IDProdutoTipo = Nothing
        _IDProdutoSubTipo = Nothing
        _IDCategoria = Nothing
        _IDFabricante = Nothing
        '
        '--- Desabilita btnPesquisa
        propHabilitaPesquisa = False
        '
        '--- Limpa listagem
        lstListagem.Clear(True)
        totalProdutos = 0
        '
    End Sub
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If lstListagem.SelectedItems.Count = 0 Then
            MessageBox.Show("Não existe nenhum PRODUTO selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim selIndex As Integer = lstListagem.SelectedItems(0).Index
        Dim clProd As clProduto = prodLista.Item(selIndex)
        '
        '--- Verifica se o form Produto ja esta aberto
        Dim frm As Form = Nothing
        '
        For Each f As Form In Application.OpenForms
            If f.Name = "frmProduto" Then
                frm = f
            End If
        Next
        '
        If IsNothing(frm) Then '--- o frmProduto não esta aberto
            frm = New frmProduto(EnumFlagAcao.EDITAR, clProd)
            frm.MdiParent = frmPrincipal
            frm.StartPosition = FormStartPosition.CenterScreen
            Close()
            frm.Show()
        Else '--- o frmProduto já esta aberto
            DirectCast(frm, frmProduto).propProduto = clProd
            frm.Focus()
            Close()
        End If
        ''
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
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        Dim prod As New clProduto
        '
        Dim frm As New frmProduto(EnumFlagAcao.INSERIR, prod)
        frm.MdiParent = frmPrincipal
        frm.StartPosition = FormStartPosition.CenterScreen
        Close()
        frm.Show()
        '
    End Sub
    '
    '--- IMPRIMIR LISTAGEM
    Private Sub btnPrintListagem_Click(sender As Object, e As EventArgs) Handles btnPrintListagem.Click
        MsgBox("Em implementação")
    End Sub
    '
#End Region '// ACAO DOS BOTOES
    '
#Region "OUTRAS FUNCOES"
    '
    '--- QUANDO ATUALIZAR O COMBO MOVIMENTO
    Private Sub cmbMovimento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMovimento.SelectedValueChanged
        '
        If Not LiberaAtualizacao Then Return
        AtualizaListagem()
        '
    End Sub
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
                    propHabilitaPesquisa = True
                Case "txtProdutoSubTipo"
                    txtProdutoSubTipo.Clear()
                    _IDProdutoSubTipo = Nothing
                    propHabilitaPesquisa = True
                Case "txtProdutoCategoria"
                    txtProdutoCategoria.Clear()
                    _IDCategoria = Nothing
                    propHabilitaPesquisa = True
                Case "txtFabricante"
                    txtFabricante.Clear()
                    _IDFabricante = Nothing
                    propHabilitaPesquisa = True
                Case "txtAutor"
                    txtAutor.Clear()
                    'FiltrarListagem()
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
                    '
                    ' move focus
                    txtAutor.Focus()
                    '
                Case "txtFabricante"
                    txtFabricante.Text = DirectCast(frmT, frmFabricanteProcurar).propFab_Escolha
                    _IDFabricante = DirectCast(frmT, frmFabricanteProcurar).propIDFab_Escolha
                    '
                    ' Filtra Listagem novamente
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_IDFabricante), 0, _IDFabricante) Then
                        propHabilitaPesquisa = True
                    End If
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
                        propHabilitaPesquisa = True
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
                    ' Filtra Listagem novamente
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_IDProdutoSubTipo), 0, _IDProdutoSubTipo) Then
                        propHabilitaPesquisa = True
                    End If
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
                    ' Filtra Listagem novamente
                    If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_IDCategoria), 0, _IDCategoria) Then
                        propHabilitaPesquisa = True
                    End If
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
    '--- FILTRA PELOS DADOS ESCOLHIDOS
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtAutor.TextChanged, txtProduto.TextChanged
        '
        FiltrarListagem()
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
        txtProdutoCategoria.KeyDown,
        rbtInativas.KeyDown,
        rbtAtivas.KeyDown,
        rbtTodos.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- ATIVA | INATIVA
    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles _
        rbtAtivas.CheckedChanged,
        rbtInativas.CheckedChanged,
        rbtTodos.CheckedChanged
        '
        If rbtAtivas.Checked = True Then
            propProdutoAtivo = 1
        ElseIf rbtInativas.Checked = True Then
            propProdutoAtivo = 2
        ElseIf rbtTodos.Checked = True Then
            propProdutoAtivo = 3
        End If
        '
    End Sub
    '
#End Region '//OUTRAS FUNCOES
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
    '--- ALTERA A COR DO PAINEL QUANDO RECEBE O FOCO
    Private Sub pnlAtivas_EnterLeave(sender As Object, e As EventArgs) _
        Handles _
        rbtAtivas.GotFocus, rbtAtivas.LostFocus,
        rbtInativas.GotFocus, rbtInativas.LostFocus,
        rbtTodos.GotFocus, rbtTodos.LostFocus,
        cmbMovimento.GotFocus, cmbMovimento.LostFocus
        '
        If rbtAtivas.ContainsFocus OrElse rbtInativas.ContainsFocus OrElse rbtTodos.ContainsFocus Then
            pnlAtivas.BackColor = Color.LightSteelBlue
            pnlMovimento.BackColor = Color.FromArgb(223, 228, 231)
        ElseIf cmbMovimento.ContainsFocus Then
            pnlMovimento.BackColor = Color.LightSteelBlue
            pnlAtivas.BackColor = Color.FromArgb(223, 228, 231)
        Else
            pnlAtivas.BackColor = Color.FromArgb(223, 228, 231)
            pnlMovimento.BackColor = Color.FromArgb(223, 228, 231)
        End If
        '
    End Sub
    '
    '--- ALTERA O BACKGROUND DA LISTAGEM QUANDO RECEBE O FOCO
    Private Sub Listagem_Focus(sender As Object, e As EventArgs) _
        Handles lstListagem.GotFocus, lstListagem.LostFocus
        '
        If lstListagem.ContainsFocus Then
            lstListagem.BackColor = Color.FromArgb(244, 246, 247)
        Else
            lstListagem.BackColor = Color.White
        End If
        '
    End Sub
    '
#End Region '//TRATAMENTO VISUAL
    '
#Region "LISTAGEM"
    '
    '--- FORMATA LISTAGEM DE CLIENTE
    Private Sub FormataListagem()
        '
        ' RGProduto
        clnRGProduto.DisplayMember = "RGProduto"
        clnRGProduto.ValueMember = "IDProduto"
        clnRGProduto.Width = 70
        clnRGProduto.AllowResize = False
        '
        ' Produto
        clnProduto.DisplayMember = "Produto"
        clnProduto.Width = 300
        clnProduto.AllowResize = True
        '
        ' Autor
        clnAutor.DisplayMember = "Autor"
        clnAutor.Width = 190
        clnAutor.AllowResize = True
        '
        ' PVenda
        clnPreco.ValueMember = "PVenda"
        clnPreco.Width = 80
        clnPreco.AllowResize = False
        '
        ' Estoque
        clnEstoque.DisplayMember = "Estoque"
        clnEstoque.ValueMember = "Estoque"
        clnEstoque.Width = 70
        clnEstoque.AllowResize = False
        '
        ' EstoqueNivel
        clnEstoqueMinimo.DisplayMember = "EstoqueNivel"
        clnEstoqueMinimo.ValueMember = "EstoqueNivel"
        clnEstoqueMinimo.Width = 65
        clnEstoqueMinimo.AllowResize = False
        '
        ' EstoqueIdeal
        clnEstoqueIdeal.DisplayMember = "EstoqueIdeal"
        clnEstoqueIdeal.ValueMember = "EstoqueIdeal"
        clnEstoqueIdeal.Width = 65
        clnEstoqueIdeal.AllowResize = False
        '
        ' ProdutoAtivo
        clnAtivo.ValueMember = "ProdutoAtivo"
        clnAtivo.Width = 60
        clnAtivo.AllowResize = False
        '
        ' Tipo
        clnTipo.DisplayMember = "ProdutoTipo"
        clnTipo.ValueMember = "IDProdutoTipo"
        clnTipo.Width = 95
        clnTipo.AllowResize = False
        '
        ' SubTipo
        clnSubTipo.DisplayMember = "ProdutoSubTipo"
        clnSubTipo.ValueMember = "IDProdutoSubTipo"
        clnSubTipo.Width = 95
        clnSubTipo.AllowResize = False
        '
        ' Categoria
        clnCategoria.DisplayMember = "ProdutoCategoria"
        clnCategoria.ValueMember = "IDCategoria"
        clnCategoria.Width = 95
        clnCategoria.AllowResize = False
        '
        ' Fabricante
        clnFabricante.DisplayMember = "Fabricante"
        clnFabricante.ValueMember = "IDFabricante"
        clnFabricante.Width = 100
        clnFabricante.AllowResize = False
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
            '.ContextMenuStrip = mnuListagem
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
        ' Formatacao
        eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "0000")
        eventArgs.Item.SubItems(3).Text = Format(CDbl(eventArgs.Item.SubItems(3).Value), "#,##0.00")
        '
        ' Alinhamento
        eventArgs.Item.SubItems(3).AlignHorizontal = TextAlignmentHorizontal.Right
        eventArgs.Item.SubItems(4).AlignHorizontal = TextAlignmentHorizontal.Right
        eventArgs.Item.SubItems(5).AlignHorizontal = TextAlignmentHorizontal.Right
        eventArgs.Item.SubItems(6).AlignHorizontal = TextAlignmentHorizontal.Right
        '
        ' Imagem Ativo | Inativo
        If eventArgs.Item.SubItems(7).Value = "True" Then
            eventArgs.Item.SubItems(7).Image = ImgAtivo
        Else
            eventArgs.Item.SubItems(7).Image = ImgInativo
        End If
        '
        eventArgs.Item.SubItems(7).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
        '
    End Sub
    '
    '--- QUANDO ATIVA O ITEM EDITA A PRODUTO
    Private Sub lstListagem_ItemActivate(sender As Object, eventArgs As BetterListViewItemActivateEventArgs) Handles lstListagem.ItemActivate
        '
        btnEditar_Click(New Object, New System.EventArgs)
        '
    End Sub
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER) DA LISTAGEM
    Private Sub lstListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles lstListagem.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEditar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
    ' --- QUANDO MARCA UM ITEM HABILITA O BTN ALTERAR
    Private Sub lstListagem_ItemChecked(sender As Object, eventArgs As BetterListViewItemCheckedEventArgs) Handles lstListagem.ItemChecked
        '
        chkAlterarProdutos.Checked = False
        '
        ' Altera a cor dos produtos selecionados
        If eventArgs.NewCheckState = CheckState.Checked Then
            eventArgs.Item.BackColor = Color.MistyRose
        Else
            eventArgs.Item.BackColor = Color.White
        End If
        '
        AtualizaLabelSelecionados()
        '
    End Sub
    '
    '--- RETORNA A QUANTIDADE DE PRODUTOS FILTRADOS
    Private Sub lstListagem_DataSourceChanged(sender As Object, e As EventArgs) Handles lstListagem.DataSourceChanged '
        '
        totalProdutos = lstListagem.Items.Count
        '
    End Sub
    '
#End Region '// LISTAGEM
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
#Region "MENU ALTERACAO"
    '
    Private Sub chkAlterarProdutos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlterarProdutos.CheckedChanged
        '
        If chkAlterarProdutos.Checked = False And mnuAlteracao.Visible() Then
            mnuAlteracao.Hide()
        ElseIf Not mnuAlteracao.Visible() Then
            '
            '--- revela o menu
            Dim p As New Point(chkAlterarProdutos.Location.X + 4, Me.Height - chkAlterarProdutos.Height - chkAlterarProdutos.Location.Y - 4)
            mnuAlteracao.Show(Me, p, ToolStripDropDownDirection.AboveRight)
            '
        End If
        '
    End Sub
    '
    '--- SELECIONA TODOS OS PRODUTOS
    Private Sub chkSelecionarTudo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelecionarTudo.CheckedChanged
        '
        For Each i In lstListagem.Items
            i.Checked = chkSelecionarTudo.Checked
        Next
        '
    End Sub
    '
    '--- AO VISUALIZAR MENU ALTERACAO
    Private Sub mnuAlteracao_VisibleChanged(sender As Object, e As EventArgs) Handles mnuAlteracao.VisibleChanged
        If Not mnuAlteracao.Visible() And chkAlterarProdutos.Checked = True Then chkAlterarProdutos.Checked = False
    End Sub
    '
    Private Sub itemAtivar_Click(sender As Object, e As EventArgs) Handles itemAtivar.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = lstListagem.CheckedItems.Count
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ATIVAR todos os produtos selecionados?" & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Ativar Produtos",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each i In lstListagem.CheckedItems
                    pBLL.ProdutoAtivarDesativar(i.Value, True)
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Ativação de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Ativar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemDesativar_Click(sender As Object, e As EventArgs) Handles itemDesativar.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = lstListagem.CheckedItems.Count
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente DESATIVAR todos os produtos selecionados?" & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Desativar Produtos",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each i In lstListagem.CheckedItems
                    pBLL.ProdutoAtivarDesativar(i.Value, False)
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Inativação de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inativar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarTipo_Click(sender As Object, e As EventArgs) Handles itemAlterarTipo.Click
        '
        ' Abre o dialog frmFabricantes para escolher novo Fabricante
        Dim frmF As New frmProdutoAlterarTipoSubTipo(Me)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        ' Define os novos valores
        Dim newTipo As String = frmF.propTipoEscolhido.ToUpper
        Dim newIDTipo As Integer? = frmF.propIDTipoEscolhido
        Dim newSubTipo As String = frmF.propSubTipoEscolhido.ToUpper
        Dim newIDSubTipo As Integer? = frmF.propIDSubTipoEscolhido
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR os produtos selecionados para:" & vbNewLine & vbNewLine &
                           "TIPO: " & IIf(String.IsNullOrEmpty(newTipo), "Não alterar", newTipo) & vbNewLine &
                           "SUBTIPO: " & IIf(String.IsNullOrEmpty(newSubTipo), "Não alterar", newSubTipo) & vbNewLine & vbNewLine &
                           "ATENÇÃO! Essa operação irá EXCLUIR a CATEGORIA do produto caso seja incompatível com o novo TIPO!",
                           "Alterar Tipo | Subtipo",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' Verifica se existe categoria incompativel e avisa ao usuário
        Dim idCat As Integer?
        Dim idTipo As Integer?
        Dim strIncompat As String = ""
        '
        For Each i In lstListagem.CheckedItems
            '
            idCat = i.SubItems(10).Value
            idTipo = i.SubItems(8).Value
            '
            If Not IsNothing(idCat) Then
                '
                If idTipo <> newIDTipo Then
                    strIncompat = strIncompat + i.SubItems(1).Text.ToUpper + vbNewLine
                End If
                '
            End If
            '
        Next
        '
        If strIncompat.Length > 0 Then
            If MessageBox.Show("Existem Categorias incompatíveis com o NOVO TIPO nos seguintes produtos:" &
                               vbNewLine & vbNewLine &
                               strIncompat &
                               vbNewLine & vbNewLine &
                               "As CATEGORIAS desses produtos serão EXCLUÍDAS..." & vbNewLine &
                               "Deseja continuar assim mesmo?",
                               "Categorias Incompatíveis",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then Return
        End If
        '
        ' realiza a operacao de alteracao
        Try
            Dim pBLL As New ProdutoBLL
            Using pBLL
                '
                For Each i In lstListagem.CheckedItems
                    '
                    ' verifica alteracao de tipo para limpar a categoria
                    If i.SubItems(8).Value <> newIDTipo Then
                        pBLL.ProdutoAlterarTipoSubTipo(i.Value, newIDTipo, newIDSubTipo, True)
                    Else
                        pBLL.ProdutoAlterarTipoSubTipo(i.Value, newIDTipo, newIDSubTipo, False)
                    End If
                    '
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarFabricante_Click(sender As Object, e As EventArgs) Handles itemAlterarFabricante.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = lstListagem.CheckedItems.Count
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Abre o dialog frmFabricantes para escolher novo Fabricante
        Dim frmF As New frmFabricanteProcurar(Me)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        Dim newIDFab As Integer = frmF.propIDFab_Escolha
        Dim newFab As String = frmF.propFab_Escolha
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR o fabricante de todos os produtos selecionados" &
                           "para: " & vbNewLine & "NOVO FABRICANTE: " & newFab & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Alterar Fabricante",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each i In lstListagem.CheckedItems
                    pBLL.ProdutoAlterarFabricante(i.Value, newIDFab)
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarCategoria_Click(sender As Object, e As EventArgs) Handles itemAlterarCategoria.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = lstListagem.CheckedItems.Count
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...", "Selecione Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        ' Verifica se todos os produtos selecionados possuem o mesmo TIPO de Produto
        Dim idTipo As Integer = lstListagem.CheckedItems(0).SubItems(8).Value
        '
        For Each i In lstListagem.CheckedItems
            '
            If idTipo <> i.SubItems(8).Value Then
                '
                MessageBox.Show("Não é possível alterar a CATEGORIA de Tipos de Produtos diferentes." & vbNewLine &
                                "Todos os produtos selecionados devem ser do mesmo TIPO.",
                                "Tipos Diferentes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Return
                '
            End If
            '
        Next
        '
        ' Abre o dialog frmProdutoProcurarCategoria para escolher nova Categoria
        Dim frmF As New frmProdutoProcurarCategoria(Me, Nothing, idTipo)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        Dim newIDCat As Integer = frmF.propIdCategoria_Escolha
        Dim newCat As String = frmF.propCategoria_Escolha
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR a Categoria de todos os produtos selecionados" &
                           "para: " & vbNewLine & vbNewLine &
                           "NOVA CATEGORIA: " & newCat.ToUpper & vbNewLine & vbNewLine &
                           "Quantidade: " & Format(sel, "00"),
                           "Alterar Categoria",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each i In lstListagem.CheckedItems
                    pBLL.ProdutoAlterarCategoria(i.Value, newIDCat)
                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub itemAlterarEstMinimoIdeal_Click(sender As Object, e As EventArgs) Handles itemAlterarEstMinimoIdeal.Click
        '
        ' Verifica se existe item selecionado
        Dim sel = lstListagem.CheckedItems.Count
        '
        If sel = 0 Then
            MessageBox.Show("Não há nenhum produto selecionado para ser alterado...",
                            "Selecione Produtos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return
        End If
        '
        ' Abre o dialog frmProdutoAlterarEstMinimoIdeal para escolher novo Fabricante
        Dim frmF As New frmProdutoAlterarEstMinimoIdeal(Me)
        '
        frmF.ShowDialog()
        '
        If frmF.DialogResult = DialogResult.Cancel Then Return
        '
        Dim newEstMinimo As Integer? = frmF.propEstoqueMinimo
        Dim newEstIdeal As Integer? = frmF.propEstoqueIdeal
        '
        ' Pergunta ao usuario
        If MessageBox.Show("Você deseja realmente ALTERAR o Est. Mínimo e/ou Ideal de todos os produtos selecionados?" &
                           "para: " & vbNewLine & vbNewLine &
                           "ESTOQUE MÍNIMO: " &
                           IIf(IsNothing(newEstMinimo), "Não Alterar", Format(newEstMinimo, "00")) &
                           vbNewLine &
                           "ESTOQUE IDEAL: " &
                           IIf(IsNothing(newEstIdeal), "Não Alterar", Format(newEstIdeal, "00")),
                           "Alterar Est. Mínimo/Ideal",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = vbNo Then Return
        '
        ' realiza a operacao
        Dim pBLL As New ProdutoBLL
        '
        Try
            Using pBLL
                '
                For Each i In lstListagem.CheckedItems
                    '
                    ' verifica se o est minimo é maior que o est ideal
                    If IsNothing(newEstMinimo) Then
                        '
                        ' verifica o estoque minimo atual do produto que será preservado
                        Dim estMinimo As Integer = IIf(i.SubItems(5).Text.Length = 0, 0, i.SubItems(5).Text)
                        '
                        If newEstIdeal < estMinimo Then
                            pBLL.ProdutoAlterarEstoqueMinimoIdeal(i.Value, _IDFilial, newEstIdeal, newEstIdeal)
                        Else
                            pBLL.ProdutoAlterarEstoqueMinimoIdeal(i.Value, _IDFilial, Nothing, newEstIdeal)
                        End If
                        '
                    ElseIf IsNothing(newEstIdeal) Then
                        '
                        ' verifica o estoque ideal atual do produto que será preservado
                        Dim estIdeal As Integer = IIf(i.SubItems(6).Text.Length = 0, 0, i.SubItems(6).Text)
                        '
                        If newEstMinimo > estIdeal Then
                            pBLL.ProdutoAlterarEstoqueMinimoIdeal(i.Value, _IDFilial, newEstMinimo, newEstMinimo)
                        Else
                            pBLL.ProdutoAlterarEstoqueMinimoIdeal(i.Value, _IDFilial, newEstMinimo, Nothing)
                        End If
                        '
                    Else
                        '
                        pBLL.ProdutoAlterarEstoqueMinimoIdeal(i.Value, _IDFilial, newEstMinimo, newEstIdeal)
                        '
                    End If

                Next
                '
            End Using
            '
            AtualizaListagem()
            '
            MessageBox.Show("Alteração de Produtos realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Alterar Produtos..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region '// MENU ALTERACAO
    '
End Class
