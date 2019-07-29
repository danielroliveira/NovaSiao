Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmProdutoProcurar
    '
    Private listProd As New List(Of clProduto)
    Private ImgProdAtivo As Image = My.Resources.accept
    Private ImgProdInativo As Image = My.Resources.block
    '
    Private pFilial As Integer?
    Private pTipo As Integer? = Nothing
    Private pSubTipo As Integer? = Nothing
    '
#Region "PROPRIEDADES E SUB NEW"
    ' PROPRIEDADES
    Private _formOrigem As Form = Nothing
    Private _ObjetivoSaida As Boolean? = Nothing ' TRUE para Venda; FALSE para COMPRA; NOTHING para OUTRO
    '
    Public Property RGEscolhido As Integer? '--- Propriedade para RGProduto escolhido
    Public Property IDEscolhido As Integer? '--- Propriedade para IDProduto escolhido
    '
    Private WriteOnly Property propFormOrigem As Form
        Set(ByVal value As Form)
            _formOrigem = value
            '
            'If IsNothing(value) Then
            '    StartPosition = FormStartPosition.CenterScreen
            'Else
            '    '--- posiciona o form pelo FORMORIGEM
            '    Dim pos As Point = value.PointToScreen(Point.Empty)
            '    Dim myPosX As Integer = pos.X + value.Width + 10
            '    '
            '    If myPosX + Me.Width > Screen.PrimaryScreen.WorkingArea.Width Then
            '        'myPosX = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 100
            '        StartPosition = FormStartPosition.CenterScreen
            '    Else
            '        pos = New Point(myPosX, pos.Y)
            '        '
            '        StartPosition = FormStartPosition.Manual
            '        Location = pos
            '    End If
            '    '
            'End If
            '
        End Set
    End Property
    '
    Private WriteOnly Property propObjetivoSaida As Nullable(Of Boolean)
        Set(value As Boolean?)
            Select Case value
                Case True ' formVenda solicitou a abertura do procurar produto
                    chkComEstoque.Checked = True
                    chkProdutosAtivos.Checked = True
                Case False ' formCompra solicitou a abertura do procurar produto
                    chkComEstoque.Checked = False
                    chkProdutosAtivos.Checked = True
                Case Else ' outro tipo de procura
                    chkComEstoque.Checked = False
                    chkProdutosAtivos.Checked = False
            End Select
            '
            _ObjetivoSaida = value
            '
        End Set
    End Property
    '
    Public Sub New(Optional formOrigem As Form = Nothing,
                   Optional ObjetivoSaida As Boolean? = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- obter valores padrão de TIPO, SUBTIPO E FILIAL
        pFilial = Obter_FilialPadrao()
        '
        Dim lastTipo As String = ObterDefault("IDProdutoTipoPadrao")
        If lastTipo.Trim.Length > 0 Then
            pTipo = lastTipo
            txtTipo.Text = ObterDefault("ProdutoTipoPadrao")
        End If
        '
        Dim lastSubTipo As String = ObterDefault("IDProdutoSubTipoPadrao")
        If lastSubTipo.Trim.Length > 0 Then
            pSubTipo = lastSubTipo
            txtSubTipo.Text = ObterDefault("ProdutoSubTipoPadrao")
        End If
        '
        '--- Definir FormOrigem e Objetivo ENTRADA ou SAIDA
        propFormOrigem = formOrigem
        propObjetivoSaida = ObjetivoSaida
        '
        Obtem_ProdutosList()
        Preenche_dgvProdutos()
        '
        AddHandler chkComEstoque.CheckedChanged, AddressOf chkBox_CheckedChanged
        AddHandler chkProdutosAtivos.CheckedChanged, AddressOf chkBox_CheckedChanged
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM"
    '
    Private Sub Obtem_ProdutosList()
        '
        '--- verifica se há algum tipo ou subtipo escolhido
        If IsNothing(pTipo) And IsNothing(pSubTipo) Then
            listProd.Clear()
            dgvProdutos.DataSource = listProd
            Exit Sub
        End If
        '
        '--- se há tipo ou subtipo efetua a procura
        Dim db As New ProdutoBLL
        Dim pComEstoque As Boolean = chkComEstoque.Checked
        Dim pSomenteAtivo As Boolean = chkProdutosAtivos.Checked
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            listProd = db.ProdutoProcurar(pFilial, pTipo, pSubTipo, pSomenteAtivo, pComEstoque, "")
            '
            dgvProdutos.DataSource = listProd
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter Lista de Produtos..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub

    ' FORMATA LISTAGEM DE PRODUTO
    Private Sub Preenche_dgvProdutos()
        dgvProdutos.AutoGenerateColumns = False
        Formata_dgvProdutos()
        dgvProdutos.ClearSelection()
    End Sub
    '
    Private Sub Formata_dgvProdutos()
        '
        ' limpa as colunas do datagrid
        dgvProdutos.Columns.Clear()
        ' altera as propriedades importantes
        dgvProdutos.MultiSelect = False
        dgvProdutos.ColumnHeadersVisible = False
        dgvProdutos.AllowUserToResizeRows = False
        dgvProdutos.AllowUserToResizeColumns = False
        dgvProdutos.RowTemplate.Height = 26
        dgvProdutos.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(211, 225, 230)
        '
        ' (1) COLUNA REG
        dgvProdutos.Columns.Add("clnRGProduto", "Reg.")
        With dgvProdutos.Columns("clnRGProduto")
            .DataPropertyName = "RGProduto"
            .Width = 70
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (2) COLUNA DESCRICAO
        dgvProdutos.Columns.Add("clnProdutoAutor", "Descrição")
        With dgvProdutos.Columns("clnProdutoAutor")
            .DataPropertyName = "Produto"
            .Width = 420
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (3) COLUNA ESTOQUE
        dgvProdutos.Columns.Add("clnEstoque", "Estoque")
        With dgvProdutos.Columns("clnEstoque")
            .DataPropertyName = "Estoque"
            .Width = 40
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA PRECO
        dgvProdutos.Columns.Add("clnPreco", "Preço")
        With dgvProdutos.Columns("clnPreco")
            .DataPropertyName = "PVenda"
            .Width = 100
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "#,##0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (5) Coluna da imagem
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .Name = "Ativo"
            .Resizable = False
            .Width = 50
        End With
        dgvProdutos.Columns.Add(colImage)
        '
        ' (6) COLUNA ATIVO
        dgvProdutos.Columns.Add("clnProdutoAtivo", "ProdutoAtivo")
        With dgvProdutos.Columns("clnProdutoAtivo")
            .DataPropertyName = "ProdutoAtivo"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        ' (7) COLUNA IDPRODUTO
        dgvProdutos.Columns.Add("clnIDProduto", "ID")
        With dgvProdutos.Columns("clnIDProduto")
            .DataPropertyName = "IDProduto"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
    End Sub
    '
    Private Sub dgvProdutos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProdutos.CellFormatting
        If e.ColumnIndex = 4 Then
            Dim p As clProduto = dgvProdutos.Rows(e.RowIndex).DataBoundItem
            '
            If p.ProdutoAtivo = True Then
                e.Value = ImgProdAtivo
            Else
                e.Value = ImgProdInativo
            End If
        End If
    End Sub
    '
    ' REVELA O MENUSTRIP
    Private Sub dgvProdutos_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvProdutos.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvProdutos.HitTest(e.X, e.Y)
            dgvProdutos.ClearSelection()

            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub

            ' seleciona o ROW
            dgvProdutos.Rows(hit.RowIndex).Selected = True

            ' mostra o MENU alterar, ativar e desativar
            If dgvProdutos.Rows(hit.RowIndex).Cells(5).Value = True Then
                AtivarToolStripMenuItem.Enabled = False
                DesativarToolStripMenuItem.Enabled = True
            Else
                AtivarToolStripMenuItem.Enabled = True
                DesativarToolStripMenuItem.Enabled = False
            End If
            '
            ' Se a ortigem não é da venda ou da compra OCULTA o editar produto
            If IsNothing(_ObjetivoSaida) Then
                EditarToolStripMenuItem.Enabled = False
            Else
                EditarToolStripMenuItem.Enabled = True
            End If

            ' revela menu
            MenuProd.Show(c.PointToScreen(e.Location))
        End If

    End Sub
    '
    ' SELECIONAR QUANDO CLICA DUAS VEZES
    Private Sub dgvProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProdutos.CellDoubleClick
        btnEscolher_Click(New Object, New EventArgs)
    End Sub
    '
    ' AO ENTRAR NO DATAGRID SE ESTIVER VAZIO SELECIONA O TIPO
    Private Sub dgvProdutos_Enter(sender As Object, e As EventArgs) Handles dgvProdutos.Enter
        If dgvProdutos.Rows.Count = 0 Then
            txtTipo.Focus()
        End If
    End Sub
    '
#End Region
    '
#Region "MENU STRIP"
    '
    Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
        Dim Pdt As Integer
        Pdt = IIf(IsDBNull(dgvProdutos.SelectedRows(0).Cells(0).Value), 0, dgvProdutos.SelectedRows(0).Cells(0).Value)
        If Pdt = 0 Then Exit Sub

        ' questiona se deseja ATIVAR realmente...
        If MessageBox.Show("Você deseja realmente ATIVAR o produto: " & vbNewLine &
                           dgvProdutos.SelectedRows(0).Cells(1).Value.ToString.ToUpper & "?",
                           "ATIVAR Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then Exit Sub
        ' executa o update
        AtivarDesativarProduto(dgvProdutos.SelectedRows(0).Cells(6).Value, True)
        dgvProdutos.SelectedRows(0).Cells(5).Value = "TRUE"
        dgvProdutos.SelectedRows(0).Cells(4).Value = ImgProdAtivo

    End Sub
    '
    Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesativarToolStripMenuItem.Click
        Dim Pdt As Integer
        Pdt = IIf(IsDBNull(dgvProdutos.SelectedRows(0).Cells(0).Value), 0, dgvProdutos.SelectedRows(0).Cells(0).Value)
        If Pdt = 0 Then Exit Sub

        ' questiona se deseja desativar realmente...
        If MessageBox.Show("Você deseja realmente DESATIVAR o produto: " & vbNewLine &
                           dgvProdutos.SelectedRows(0).Cells(1).Value.ToString.ToUpper & "?",
                           "DESATIVAR Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then Exit Sub
        ' executa o update
        AtivarDesativarProduto(dgvProdutos.SelectedRows(0).Cells(6).Value, False)
        dgvProdutos.SelectedRows(0).Cells(5).Value = "FALSE"
        dgvProdutos.SelectedRows(0).Cells(4).Value = ImgProdInativo

    End Sub
    '
    Private Sub AtivarDesativarProduto(myRG As Integer, myAtivo As Boolean)
        Dim sql As New SQLControl
        sql.ExecQuery("UPDATE tblProduto SET ProdutoAtivo = '" & myAtivo & "' WHERE IDProduto = " & myRG)
        sql.HasException(True)
        sql = Nothing
    End Sub
    '
    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Dim Pdt As Integer
        Pdt = IIf(IsDBNull(dgvProdutos.SelectedRows(0).Cells(0).Value), 0, dgvProdutos.SelectedRows(0).Cells(0).Value)

        If Pdt = 0 Then Exit Sub

        MsgBox("Ainda não está preparado")
        Exit Sub
        'AtivarDesativarProduto(dgvProdutos.SelectedRows(0).Cells(6).Value, True)

    End Sub
    '
#End Region
    '
#Region "BOTOES"
    '
    ' BTN ESCOLHER/SELECIONAR PRODUTO
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        If dgvProdutos.RowCount > 0 AndAlso dgvProdutos.SelectedRows.Count > 0 Then
            '
            '--- salva os ultimos TIPOS E SUBTIPO no CONFIG
            SetarDefault("IDProdutoTipoPadrao", IIf(IsNothing(pTipo), "", pTipo))
            SetarDefault("ProdutoTipoPadrao", txtTipo.Text)
            SetarDefault("IDProdutoSubTipoPadrao", IIf(IsNothing(pSubTipo), "", pSubTipo))
            SetarDefault("ProdutoSubTipoPadrao", txtSubTipo.Text)
            '
            '--- define os valores das propriedades do produto escolhido
            RGEscolhido = dgvProdutos.SelectedRows(0).Cells(0).Value
            IDEscolhido = dgvProdutos.SelectedRows(0).Cells(6).Value
            Me.DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Favor selecionar um produto antes de Escolher...", "Selecione um Produto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    '
    ' BTN FECHAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.DialogResult = DialogResult.Cancel
    End Sub
    '
    ' BTN TIPO ESCOLHER
    Private Sub btnTipoEscolher_Click(sender As Object, e As EventArgs) Handles btnTipoEscolher.Click
        Dim frmT As New frmProdutoProcurarTipo(Me)
        '
        frmT.ShowDialog()
        '
        If frmT.DialogResult = DialogResult.OK Then
            '
            Dim atualizado As Boolean = False
            '
            If IsNothing(pTipo) OrElse pTipo <> frmT.propIdTipo_Escolha Then
                atualizado = True
            End If
            '
            pTipo = frmT.propIdTipo_Escolha
            txtTipo.Text = frmT.propTipo_Escolha
            txtTipo.SelectAll()
            txtTipo.Focus()
            '
            If atualizado = True Then
                '--- limpa o subtipo
                txtSubTipo.Clear()
                pSubTipo = Nothing
                '
                '--- atualiza a listagem
                Obtem_ProdutosList()
                '
            End If
            '
        End If
        '
    End Sub
    '
    ' BTN SUBTIPO ESCOLHER
    Private Sub btnSubTipoEscolher_Click(sender As Object, e As EventArgs) Handles btnSubTipoEscolher.Click
        '
        Dim frmS As New frmProdutoProcurarSubTipo(Me, pSubTipo, pTipo)
        '
        frmS.ShowDialog()
        '
        If frmS.DialogResult = DialogResult.OK Then
            '
            Dim atualizado As Boolean = False
            '
            If IsNothing(pSubTipo) OrElse pSubTipo <> frmS.propIdSubTipo_Escolha Then
                atualizado = True
            End If
            '
            pSubTipo = frmS.propIdSubTipo_Escolha
            txtSubTipo.Text = frmS.propSubTipo_Escolha
            txtSubTipo.SelectAll()
            txtSubTipo.Focus()
            '
            If atualizado = True Then
                '--- atualiza a listagem
                Obtem_ProdutosList()
                '
            End If
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    ' ALTERAR O TEXTO PROCURA
    Private Sub txtProcurar_TextChanged(sender As Object, e As EventArgs) Handles txtProcurar.TextChanged
        '
        If txtProcurar.Text.Trim.Length > 0 Then
            Dim listProdFilter = From p In listProd
            listProdFilter = listProdFilter.Where(Function(p) p.Produto.Contains(txtProcurar.Text.ToUpper)).ToList
            dgvProdutos.DataSource = listProdFilter
        Else
            dgvProdutos.DataSource = listProd
        End If
        '
    End Sub
    '
    ' OUTRAS FUNCOES
    Private Sub chkBox_CheckedChanged(sender As Object, e As EventArgs)
        '
        '--- atualiza a listagem
        Obtem_ProdutosList()
        '
    End Sub
    '
    '--- quando pressiona a tecla (+) envia vazio
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "+"c Then
            e.Handled = True
            e.KeyChar = ""
        End If
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipo.KeyDown, txtSubTipo.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtTipo"
                    btnTipoEscolher_Click(New Object, New EventArgs)
                    txtTipo.Text = txtTipo.Text.Replace("+", "")
                    txtTipo.SelectAll()
                Case "txtSubTipo"
                    btnSubTipoEscolher_Click(New Object, New EventArgs)
                    txtSubTipo.Text = txtSubTipo.Text.Replace("+", "")
                    txtSubTipo.SelectAll()
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtTipo"
                    pTipo = Nothing
                    txtTipo.Clear()
                    Obtem_ProdutosList()
                    Preenche_dgvProdutos()
                Case "txtSubTipo"
                    pSubTipo = Nothing
                    txtSubTipo.Clear()
                    Obtem_ProdutosList()
                    Preenche_dgvProdutos()
            End Select
        ElseIf e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            e.Handled = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    '--- LIMPAR CONTROLE TXTPROCURA QUANDO PRESSIONA DELETE
    Private Sub txtProcurar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProcurar.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            If dgvProdutos.SelectedRows.Count > 0 Then
                btnEscolher_Click(New Object, New System.EventArgs)
            Else
                e.Handled = True
                SendKeys.Send("{Tab}")
            End If
        ElseIf e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            txtProcurar.Clear()
            Obtem_ProdutosList()
        End If
        '
    End Sub
    '
    '--- NAO PERMITIR ACENTOS NO CONTROLE DE PROCURA
    Private Sub txtProcurar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProcurar.KeyPress
        Dim strAcentos As String = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç"
        '
        If strAcentos.IndexOf(e.KeyChar) > 0 Then
            e.Handled = True
        ElseIf Not Char.IsLetter(e.KeyChar) AndAlso Not e.KeyChar = vbBack AndAlso Not e.KeyChar = " " Then
            e.Handled = True
        End If
        '
    End Sub
    '
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ROWS DO DATAGRID
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then '--- fecha o formulario
            e.Handled = True
            btnCancelar_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Up Then '--- seta para cima navega no datagrid
            e.Handled = True
            '
            If dgvProdutos.Rows.Count > 0 Then
                If dgvProdutos.SelectedRows.Count > 0 Then
                    Dim i As Integer = dgvProdutos.SelectedRows(0).Index
                    '
                    dgvProdutos.Rows(i).Selected = False
                    '
                    If i = 0 Then
                        i = dgvProdutos.Rows.Count
                    End If
                    '
                    dgvProdutos.Rows(i - 1).Selected = True
                    'dgvProdutos.EnsureVisible(i - 1)
                Else
                    dgvProdutos.Rows(0).Selected = True
                    'dgvProdutos.EnsureVisible(0)
                End If
            End If
            '
        ElseIf e.KeyCode = Keys.Down Then '--- seta para baixo navega no datagrid
            e.Handled = True
            '
            If dgvProdutos.Rows.Count > 0 Then
                If dgvProdutos.SelectedRows.Count > 0 Then
                    Dim i As Integer = dgvProdutos.SelectedRows(0).Index
                    '
                    dgvProdutos.Rows(i).Selected = False
                    '
                    If i = dgvProdutos.Rows.Count - 1 Then
                        i = -1
                    End If
                    '
                    dgvProdutos.Rows(i + 1).Selected = True
                    'dgvProdutos.EnsureVisible(i + 1)
                Else
                    dgvProdutos.Rows(0).Selected = True
                End If
            End If
            '
        End If
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' FAZER DEGRADE NO PANEL CABEÇALHO DO DATAGRID
    '-------------------------------------------------------------------------------------------------
    Private Sub pnlProduto_Paint(sender As Object, e As PaintEventArgs) Handles pnlProduto.Paint

        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.Transparent, Color.FromArgb(100, Color.LightSlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)

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
