Imports CamadaBLL
Imports CamadaDTO
Imports ComponentOwl.BetterListView

Public Class frmClienteProcurar
    '
    Private dtClientes As DataTable
    Dim Px, Py As Integer
    Dim Mover As Boolean
    Private ClienteAtivo As Image = My.Resources.Cliente_Ativo
    Private ClienteInativo As Image = My.Resources.Cliente_Inativo
    Private _formOrigem As Form = Nothing
    '
#Region "PROPRIEDADES, NEW E LOAD"
    '
    '--- SUB NEW
    Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        If Not IsNothing(formOrigem) Then
            propFormOrigem = formOrigem
        End If
        '
    End Sub
    '
    '--- FORM LOAD
    Private Sub frmClienteProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- Carrega o Combo de Atividades
        CarregaAtividade()
        '
        If cmbRGAtividade.Items.Count > 0 Then
            cmbRGAtividade.SelectedIndex = 0
        Else
            MessageBox.Show("Não há nenhum TIPO de Cliente Cadastrado no sistema..." & vbNewLine &
                            "Favor inserir ao menos uma ATIVIDADE DE CLIENTE",
                            "Não Há TIPOS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
            Exit Sub
        End If
        '
        '--- Carrega Combo Ativo
        CarregaAtivo()
        cmbAtivo.SelectedIndex = 0
        '
        'GetDados()
        FormataListagem()
        '
    End Sub
    '
    Private Sub frmClienteProcurar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Cursor = Cursors.WaitCursor Then Cursor = Cursors.Default
    End Sub
    '
    '--- PROPRIEDADES
    Public Property propClienteEscolhido As Object = Nothing
    Private _propPreenchido As Boolean?
    '
    Private WriteOnly Property propFormOrigem As Form
        Set(ByVal value As Form)
            _formOrigem = value
        End Set
    End Property
    '
    Property propPreenchido As Boolean?
        '
        Get
            Return _propPreenchido
        End Get
        '
        Set(value As Boolean?)
            '
            If IsNothing(value) Then
                lblProc.Visible = False
                '-- btnProcurar
                btnProcurar.Visible = False
                btnProcurar.Enabled = False
                '
            ElseIf If(value, 0) = True Then
                lblProc.Location = New Point(234, 55)
                lblProc.Font = New Font("Calibri Light", 9.0!, FontStyle.Bold)
                lblProc.Text = "Pressione ENTER..."
                lblProc.ForeColor = Color.DarkBlue
                lblProc.BackColor = Color.Transparent
                lblProc.SendToBack()
                lblProc.Visible = True
                '-- btnProcurar
                btnProcurar.Visible = True
                btnProcurar.Enabled = True
                '
            ElseIf If(value, -1) = False Then
                lblProc.Location = New Point(234, 75)
                lblProc.Font = New Font("Calibri Light", 12.0!, FontStyle.Italic)
                lblProc.Text = "Digite algo para procurar..."
                lblProc.ForeColor = Color.Black
                lblProc.BackColor = Color.White
                lblProc.BringToFront()
                lblProc.Visible = True
                '-- btnProcurar
                btnProcurar.Visible = True
                btnProcurar.Enabled = False
                '
                lstListagem.Items.Clear()
                '
            End If
            '
            _propPreenchido = value
            '
        End Set
        '
    End Property
    '
#End Region
    '
#Region "PREENCHER COMBOS"
    ' PREENCHE COMBO ATIVIDADES
    Private Sub CarregaAtividade()
        Dim cliBLL As New ClienteBLL
        '
        Try
            Dim dtAtiv As DataTable = cliBLL.GetClienteAtividades()
            '
            With cmbRGAtividade
                .DataSource = dtAtiv
                .ValueMember = "RGAtividade"
                .DisplayMember = "Atividade"
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- PREENCHE COMBO ATIVO
    Private Sub CarregaAtivo()
        Dim cliBLL As New ClienteBLL
        '
        Try
            Dim dtSit As DataTable = cliBLL.GetClienteSituacao()
            '
            With cmbAtivo
                .DataSource = dtSit
                .ValueMember = "IDSituacao"
                .DisplayMember = "Situacao"
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM"
    '
    '--- PREENCHE LISTAGEM
    Private Sub GetDados()
        '        
        '--- Cria myQuery
        Dim myQuery As String = "SELECT * FROM qryClienteAll WHERE RGAtividade = @RGAtividade AND IDSituacao = @IDSituacao"
        '
        '--- Preenche o DataTable
        Dim SQL As New SQLControl
        SQL.ClearParams()
        '
        '--- RGAtividade
        If IsNumeric(cmbRGAtividade.SelectedValue) Then
            SQL.AddParam("@RGAtividade", cmbRGAtividade.SelectedValue)
        Else
            SQL.AddParam("@RGAtividade", 1)
        End If
        '
        '--- IDSituacao
        If IsNumeric(cmbAtivo.SelectedValue) Then
            SQL.AddParam("@IDSituacao", cmbAtivo.SelectedValue)
        Else
            SQL.AddParam("@IDSituacao", 1)
        End If
        '
        '--- Outros Parametros
        If txtProcurar.TextLength > 0 AndAlso IsNumeric(txtProcurar.Text.Substring(0, 1)) Then
            If Integer.TryParse(txtProcurar.Text, Nothing) Then ' PROCURA PELO RG
                SQL.AddParam("@RGCliente", txtProcurar.Text)
                myQuery = myQuery + " AND  RGCliente = @RGCliente"
            Else
                SQL.AddParam("@CNP", txtProcurar.Text)
                myQuery = myQuery + " AND CNP LIKE '%'+@CNP+'%'"
            End If
        Else
            SQL.AddParam("@Cadastro", txtProcurar.Text)
            myQuery = myQuery + " AND Cadastro LIKE '%'+@Cadastro+'%'"
        End If
        '
        '--- Realiza Consulta
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            SQL.ExecQuery(myQuery)
            If SQL.HasException(True) Then Exit Sub
            dtClientes = SQL.DBDT
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao obter a lista de Clientes..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            SQL = Nothing
            '
        End Try
        '
        '--- Set Datasource
        lstListagem.DataSource = dtClientes
        propPreenchido = Nothing
        '
    End Sub
    '
    '--- FORMATA LISTAGEM DE CLIENTE
    Private Sub FormataListagem()
        clnRGCadastro.DisplayMember = "RGCliente"
        clnRGCadastro.Width = 50
        '
        clnCadastroNome.DisplayMember = "Cadastro"
        clnCadastroNome.Width = 300
        '
        clnCNP.DisplayMember = "CNP"
        clnCNP.Width = 190
        '
        clnAtivoImagem.Width = 60 ' imagem de ativo ou inativo
        '
        clnIDSituacao.DisplayMember = "IDSituacao"
        clnIDSituacao.Width = 0
        '
        clnRGAtividade.DisplayMember = "RGAtividade"
        clnRGAtividade.Width = 0
        '
        clnPessoaTipo.DisplayMember = "PessoaTipo"
        clnPessoaTipo.Width = 0
        '
        clnUF.DisplayMember = "UF"
        clnUF.Width = 0
        '
        clnID.DisplayMember = "IDPessoa"
        clnID.Width = 0
        '
        '
        lstListagem.SearchSettings = New BetterListViewSearchSettings(BetterListViewSearchMode.PrefixOrSubstring,
                                                                      BetterListViewSearchOptions.UpdateSearchHighlight,
                                                                      New Integer() {0, 1, 2})
    End Sub
    '
    '--- DESIGN DA LISTAGEM
    Private Sub lstListagem_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstListagem.DrawColumnHeader
        '
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            Dim brush As Brush = New SolidBrush(Color.LightSteelBlue)
            '
            eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)
            eventArgs.Graphics.DrawString(eventArgs.ColumnHeader.Text, New Font("Verdana", 12, FontStyle.Regular), New SolidBrush(Color.Black), eventArgs.ColumnHeaderBounds.BoundsText)
            '
            brush.Dispose()
        End If
        '
    End Sub
    '
    Private Sub lstListagem_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstListagem.DrawItem
        '
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "0000")
        End If
        '
        eventArgs.Item.SubItems(3).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
        '
        If eventArgs.Item.SubItems(4).Text = "1" Then
            eventArgs.Item.SubItems(3).Image = ClienteAtivo
        ElseIf eventArgs.Item.SubItems(4).Text = "2" Then
            eventArgs.Item.SubItems(3).Image = ClienteInativo
        End If
        '
    End Sub
    '
    Private Sub lstListagem_ItemActivate(sender As Object, eventArgs As BetterListViewItemActivateEventArgs) Handles lstListagem.ItemActivate
        btnEscolher_Click(New Object, New System.EventArgs)
    End Sub
    '
    '--- LIMPAR LISTAGEM
    Private Sub LimparListagem()
        lstListagem.Clear()
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '
    ' BOTÃO FECHAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        propClienteEscolhido = Nothing
        DialogResult = DialogResult.Cancel
    End Sub
    '
    ' ESCOLHER O CLIENTE
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If lstListagem.SelectedItems.Count = 0 Then
            MessageBox.Show("Não nenhum Cliente selecionado..." & vbNewLine &
                            "Favor antes selecione um cliente!",
                            "Escolher Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        '
        '--- obter o row do ClienteSelecionado
        Dim r As DataRowView = lstListagem.SelectedItems(0).Value

        If r("PessoaTipo") = 1 Then
            propClienteEscolhido = ConvertDataRowInPF(r)
        ElseIf r("PessoaTipo") = 2 Then
            propClienteEscolhido = ConvertDataRowInPJ(r)
        End If

        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Function ConvertDataRowInPF(r As DataRowView) As clClientePF
        '
        Dim cli As New clClientePF
        '
        cli.IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
        cli.Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
        cli.PessoaTipo = If(IsDBNull(r("PessoaTipo")), Nothing, r("PessoaTipo"))
        cli.IDSituacao = If(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
        cli.ClienteDesde = If(IsDBNull(r("ClienteDesde")), Nothing, r("ClienteDesde"))
        cli.RGAtividade = If(IsDBNull(r("RGAtividade")), Nothing, r("RGAtividade"))
        cli.Atividade = If(IsDBNull(r("Atividade")), String.Empty, r("Atividade"))
        cli.LimiteCompras = If(IsDBNull(r("LimiteCompras")), Nothing, r("LimiteCompras"))
        cli.UltimaVenda = If(IsDBNull(r("UltimaVenda")), Nothing, r("UltimaVenda"))
        cli.RGCliente = If(IsDBNull(r("RGCliente")), Nothing, r("RGCliente"))
        cli.CPF = If(IsDBNull(r("CNP")), String.Empty, r("CNP"))
        cli.Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
        cli.Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
        cli.Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
        cli.UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
        cli.CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
        '
        Return cli
        '
    End Function
    '
    Private Function ConvertDataRowInPJ(r As DataRowView) As clClientePJ
        '
        Dim cli As New clClientePJ
        '
        cli.IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
        cli.Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
        cli.PessoaTipo = If(IsDBNull(r("PessoaTipo")), Nothing, r("PessoaTipo"))
        cli.IDSituacao = If(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
        cli.ClienteDesde = If(IsDBNull(r("ClienteDesde")), Nothing, r("ClienteDesde"))
        cli.RGAtividade = If(IsDBNull(r("RGAtividade")), Nothing, r("RGAtividade"))
        cli.Atividade = If(IsDBNull(r("Atividade")), String.Empty, r("Atividade"))
        cli.LimiteCompras = If(IsDBNull(r("LimiteCompras")), Nothing, r("LimiteCompras"))
        cli.UltimaVenda = If(IsDBNull(r("UltimaVenda")), Nothing, r("UltimaVenda"))
        cli.RGCliente = If(IsDBNull(r("RGCliente")), Nothing, r("RGCliente"))
        cli.CNPJ = If(IsDBNull(r("CNP")), String.Empty, r("CNP"))
        cli.Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
        cli.Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
        cli.Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
        cli.UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
        cli.CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
        '
        Return cli
        '
    End Function
    '
    '--- BTN PROCURAR
    '----------------------------------------------------------------------------------
    Private Sub btnProcurar_Click(sender As Object, e As EventArgs) Handles btnProcurar.Click
        '
        If If(propPreenchido, 0) = True Then
            lstListagem.Focus()
            GetDados()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "NAVEGACAO E CONTROLE"
    '
    '------------------------------------------------------------------------------------------------
    ' TECLAS DE ATALHO:
    '
    '--- ESC --> FECHA FORM
    '--- SETA CIMA E BAIXO --> NAVEGA ENTRE OS ITENS DA LISTAGEM
    '--- PGDOWN E PGUP --> ALTERA TIPO
    '--- HOME E END --> ALTERA SITUACAO
    '------------------------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        Select Case e.KeyCode
            '
            Case Keys.Escape
                '
                e.Handled = True
                btnCancelar_Click(New Object, New EventArgs)
                '
            Case Keys.Up
                '
                e.Handled = True
                '
                If lstListagem.Items.Count > 0 Then
                    If lstListagem.SelectedItems.Count > 0 Then
                        Dim i As Integer = lstListagem.SelectedItems(0).Index
                        '
                        lstListagem.Items(i).Selected = False
                        '
                        If i = 0 Then
                            i = lstListagem.Items.Count
                        End If
                        '
                        lstListagem.Items(i - 1).Selected = True
                        lstListagem.EnsureVisible(i - 1)
                    Else
                        lstListagem.Items(0).Selected = True
                        lstListagem.EnsureVisible(0)
                    End If
                End If
                '
            Case Keys.Down
                '
                e.Handled = True
                '
                If lstListagem.Items.Count > 0 Then
                    If lstListagem.SelectedItems.Count > 0 Then
                        Dim i As Integer = lstListagem.SelectedItems(0).Index
                        '
                        lstListagem.Items(i).Selected = False
                        '
                        If i = lstListagem.Items.Count - 1 Then
                            i = -1
                        End If
                        '
                        lstListagem.Items(i + 1).Selected = True
                        lstListagem.EnsureVisible(i + 1)
                    Else
                        lstListagem.Items(0).Selected = True
                    End If
                End If
                ' 
            Case Keys.PageUp
                '
                e.Handled = True
                If cmbRGAtividade.SelectedIndex > 0 Then
                    cmbRGAtividade.SelectedIndex -= 1
                Else
                    cmbRGAtividade.SelectedIndex = cmbRGAtividade.Items.Count - 1
                End If
                '
            Case Keys.PageDown
                '
                e.Handled = True
                Dim maxIndex As Byte = cmbRGAtividade.Items.Count - 1
                '
                If cmbRGAtividade.SelectedIndex < maxIndex Then
                    cmbRGAtividade.SelectedIndex += 1
                Else
                    cmbRGAtividade.SelectedIndex = 0
                End If
                '
            Case Keys.Home
                '
                e.Handled = True
                If cmbAtivo.SelectedIndex > 0 Then
                    cmbAtivo.SelectedIndex -= 1
                Else
                    cmbAtivo.SelectedIndex = cmbAtivo.Items.Count - 1
                End If
                '
            Case Keys.End
                '
                e.Handled = True
                Dim maxIndex As Byte = cmbAtivo.Items.Count - 1
                '
                If cmbAtivo.SelectedIndex < maxIndex Then
                    cmbAtivo.SelectedIndex += 1
                Else
                    cmbAtivo.SelectedIndex = 0
                End If
                '
            Case Else
                e.Handled = False
        End Select
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    '---------------------------------------------------------------------------------------
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles txtProcurar.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            '
            If If(propPreenchido, 0) = True Then
                GetDados()
            ElseIf IsNothing(propPreenchido) Then
                If lstListagem.SelectedItems.Count > 0 Then
                    btnEscolher_Click(sender, New EventArgs)
                End If
            End If
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            '
            txtProcurar.Clear()
            propPreenchido = False
            lstListagem.Clear(True)
            '
        End If
        '
    End Sub
    '
#End Region '/ NAVEGACAO E CONTROLE
    '
#Region "FUNCAO PROCURAR CLIENTE"
    '
    '--- CONTROLE DO TXTPROCURAR
    '----------------------------------------------------------------------------------
    Private Sub txtProcurar_TextChanged(sender As Object, e As EventArgs) Handles txtProcurar.TextChanged
		'
		Dim itemsFound As BetterListViewItemCollection
        '
        If txtProcurar.Text.Length > 0 Then
            propPreenchido = True
            itemsFound = lstListagem.FindItemsWithText(txtProcurar.Text)
            ' select found items
            lstListagem.SelectedItems.[Set](itemsFound)
        Else
            propPreenchido = False
            lstListagem.FindItemsWithText("?")
            lstListagem.SelectedItems.Clear()
        End If
        '
    End Sub
    '
    Private Sub cmbRGAtividade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRGAtividade.SelectedIndexChanged, cmbAtivo.SelectedIndexChanged
        '
        If Not Me.CanFocus Then Exit Sub
        '
        If IsNumeric(cmbRGAtividade.SelectedValue) AndAlso Not IsNothing(dtClientes) Then
            '
            If txtProcurar.Text.Trim.Length > 0 Then
                propPreenchido = True
                btnProcurar_Click(sender, e)
            End If
            '
            lstListagem.FindItemsWithText("?")
            lstListagem.SelectedItems.Clear()
            txtProcurar.Focus()
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
    '
    ' MOVER O FORMULÁRIO SEM BORDA
    Private Sub Painel_MouseDown(sender As Object, e As MouseEventArgs) Handles Painel.MouseDown
        Px = e.X
        Py = e.Y
        Mover = True
    End Sub
    '
    Private Sub Painel_MouseUp(sender As Object, e As MouseEventArgs) Handles Painel.MouseUp
        Mover = False
    End Sub
    '
    Private Sub Painel_MouseMove(sender As Object, e As MouseEventArgs) Handles Painel.MouseMove
        If Mover = True Then
            Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - Px,
                                                     MousePosition.Y - Me.Location.Y - Py))
        End If
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