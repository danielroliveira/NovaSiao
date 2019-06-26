Imports CamadaDTO
Imports CamadaBLL
'
Public Class frmCredorProcurar
    '
    Private WithEvents listCred As New List(Of clCredor)
    Private WithEvents bindC As New BindingSource
    Private _Procura As Boolean
    Private ImgInativo As Image = My.Resources.block
    Private ImgAtivo As Image = My.Resources.accept
    Private IniciarFiltragem As Boolean = False
    Private _formOrigem As Form
    Property propEscolhido As Integer?
    Property propCredorEscolhido As clCredor = Nothing
    '
#Region "LOAD FORM"
    Sub New(Optional Procura As Boolean = False, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        CarregaCmbAtivo()
        CarregaComboTipo()
        _Procura = Procura
        _formOrigem = formOrigem
        '
        '--- Verifica se o form foi aberto para procura ou para controle de fornecedores 
        If Procura = True Then '--- nesse caso foi aberto para procura
            btnEditar.Text = "&Escolher"
            btnEditar.Image = My.Resources.accept
            btnAdicionar.Enabled = True
            btnFechar.Text = "&Cancelar"
            lblTitulo.Text = "Escolher Credor"
        Else
            btnEditar.Text = "&Editar"
            btnEditar.Image = My.Resources.editar
            btnAdicionar.Enabled = True
            btnFechar.Text = "&Fechar"
            lblTitulo.Text = "Procurar Credor"
        End If
        '
        CarregaDados()
        '
        IniciarFiltragem = True
        '
    End Sub
    '
    Private Sub CarregaDados()
        Dim cBLL As New CredorBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            listCred = cBLL.Credor_GET_List(CByte(cmbCredorTipo.SelectedValue))
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao obter a lista de Credores..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
        PreencheListagem()
        '
    End Sub
    '
#End Region
    '
#Region "PREENCHE LISTAGEM E COMBO"
    '
    Private Sub PreencheListagem()
        '
        With dgvListagem
            .Columns.Clear()
            .AutoGenerateColumns = False
            ' altera as propriedades importantes
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ColumnHeadersVisible = True
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .RowHeadersWidth = 36
            .RowTemplate.Height = 30
            .StandardTab = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        '
        ' (1) COLUNA REG
        dgvListagem.Columns.Add("clnID", "Reg.")
        With dgvListagem.Columns("clnID")
            .DataPropertyName = "IDPessoa"
            .Width = 70
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            Dim newPadding As New Padding(5, 0, 0, 0)
            .DefaultCellStyle.Padding = newPadding
        End With
        '
        ' (2) COLUNA TRANSPORTADORA
        dgvListagem.Columns.Add("clnCredor", "Credor")
        With dgvListagem.Columns("clnCredor")
            .DataPropertyName = "Cadastro"
            .Width = 300
            .Visible = True
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Format = "00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) Coluna da imagem
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .Name = "Ativo"
            .Resizable = False
            .Width = 70
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (4) COLUNA ATIVO
        dgvListagem.Columns.Add("FornAtivo", "Ativo")
        With dgvListagem.Columns("FornAtivo")
            .DataPropertyName = "Ativo"
            .Width = 50
            .Visible = False
            .ReadOnly = True
            .Resizable = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        '
        '--- Preenche o DataSource com um Filtro
        FiltrarListagem()
        '
    End Sub
    '
    '--- PREENCHE O COMBO ATIVO
    Private Sub CarregaCmbAtivo()
        Dim dtAtivo As New DataTable
        'Adiciona todas as possibilidades de instrucao
        dtAtivo.Columns.Add("Ativo")
        dtAtivo.Columns.Add("Texto")
        dtAtivo.Rows.Add(New Object() {False, "Inativo"})
        dtAtivo.Rows.Add(New Object() {True, "Ativo"})
        With cmbAtivo
            .DataSource = dtAtivo
            .ValueMember = "Ativo"
            .DisplayMember = "Texto"
            .SelectedValue = True
        End With
    End Sub
    '
    '
    ' CARREGA OS COMBOBOX
    '--------------------------------------------------------------------------------------------------------
    Private Sub CarregaComboTipo()
        Dim dtTipo As New DataTable
        'Adiciona todas as possibilidades
        dtTipo.Columns.Add("IDTipo")
        dtTipo.Columns.Add("Tipo")
        dtTipo.Rows.Add(New Object() {0, "Simples"})
        dtTipo.Rows.Add(New Object() {1, "Pessoa Física"})
        dtTipo.Rows.Add(New Object() {2, "Pessoa Jurídica"})
        dtTipo.Rows.Add(New Object() {3, "Orgão Público"})
        With cmbCredorTipo
            .DataSource = dtTipo
            .ValueMember = "IDTipo"
            .DisplayMember = "Tipo"
            '.SelectedValue = -1
        End With
    End Sub
    '
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        If e.ColumnIndex = 0 Then
            e.Value = Format(e.Value, "D4")
        ElseIf e.ColumnIndex = 2 Then
            If DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clCredor).Ativo = True Then
                e.Value = ImgAtivo
            Else
                e.Value = ImgInativo
            End If
        End If
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        If _Procura = True Then '--- se for um form de PROCURA
            Me.DialogResult = DialogResult.Cancel
        Else '--- se for um form de CONTROLE EDICAO
            Close()
            MostraMenuPrincipal()
        End If
    End Sub
    '
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        Dim cred As New clCredor
        Dim frmC As New frmCredor(cred, Me)
        '
        frmC.ShowDialog()
        '
        If frmC.DialogResult = DialogResult.OK Then
            '--- atualiza os dados da listagem
            cmbCredorTipo.SelectedValue = frmC._Credor.CredorTipo
            cmbAtivo.SelectedValue = True
            txtProcura.Clear()
            CarregaDados()
        End If
        '
    End Sub
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '--- verifica se existe algum item selecionado
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum Credor selecionado...", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Focus()
            Exit Sub
        End If
        '
        '--- Seleciona o Fornecedor
        propCredorEscolhido = dgvListagem.SelectedRows(0).DataBoundItem
        '
        If _Procura = True Then '--- se for para escolha e procura
            propEscolhido = propCredorEscolhido.IDPessoa
            Me.DialogResult = DialogResult.OK
        Else '--- se for para EDICAO
            Dim frmC As New frmCredor(propCredorEscolhido, Me)
            frmC.ShowDialog()
            '
            If frmC.DialogResult = DialogResult.OK Then
                '--- atualiza os dados da listagem
                cmbCredorTipo.SelectedValue = frmC._Credor.CredorTipo
                cmbAtivo.SelectedValue = True
                txtProcura.Clear()
                CarregaDados()
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnEditar_Click(New Object, New System.EventArgs)
    End Sub
    '
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    Private Sub Listagem_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            btnEditar_Click(New Object, New System.EventArgs)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "PROCURA"
    '
    '--- FILTRAR LISTAGEM
    Private Sub FiltrarListagem()
        '
        dgvListagem.DataSource = listCred.FindAll(AddressOf FindForn)
        '
    End Sub
    '
    Private Function FindForn(ByVal C As clCredor) As Boolean
        '
        If C.Ativo = cmbAtivo.SelectedValue AndAlso C.Cadastro.ToLower Like "*" & txtProcura.Text.ToLower & "*" Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    Private Sub txtProcura_TextChanged(sender As Object, e As EventArgs) Handles txtProcura.TextChanged
        FiltrarListagem()
    End Sub
    '
    Private Sub cmbAtivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAtivo.SelectedValueChanged
        If IniciarFiltragem = False Then Exit Sub
        '
        FiltrarListagem()
        '
    End Sub
    '
    Private Sub cmbCredorTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCredorTipo.SelectedValueChanged
        If IniciarFiltragem = False Then Exit Sub
        '
        CarregaDados()
        '
    End Sub
    '
#End Region
    '
#Region "MENU SUSPENSO"
    ' CONTROLE DO MENU SUSPENSO
    Private Sub dgvListagem_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvListagem.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvListagem.HitTest(e.X, e.Y)
            dgvListagem.ClearSelection()
            '
            '---VERIFICAÇÕES NECESSÁRIAS
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvListagem.Rows(hit.RowIndex).Cells(0).Selected = True
            dgvListagem.Rows(hit.RowIndex).Selected = True
            '
            ' mostra o MENU ativar e desativar
            If dgvListagem.Columns(hit.ColumnIndex).Name = "Ativo" Then
                If dgvListagem.Rows(hit.RowIndex).Cells("FornAtivo").Value = True Then
                    AtivarToolStripMenuItem.Enabled = False
                    DesativarToolStripMenuItem.Enabled = True
                Else
                    AtivarToolStripMenuItem.Enabled = True
                    DesativarToolStripMenuItem.Enabled = False
                End If
                ' revela menu
                MenuListagem.Show(c.PointToScreen(e.Location))
            End If
        End If
    End Sub
    '
    Private Sub AtivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtivarToolStripMenuItem.Click
        '--- verifica se existe alguma cell 
        If dgvListagem.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- Verifica o item
        Dim selID As Integer = dgvListagem.SelectedRows(0).Cells("clnID").Value
        Dim f As clCredor = listCred.Find(Function(x) x.IDPessoa = selID)
        '
        '---pergunta ao usuário
        If MessageBox.Show("Deseja realmente ATIVAR esse Credor?" & vbNewLine &
                           f.Cadastro.ToUpper, "Ativar",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        '
        '--- altera o valor
        f.Ativo = True
        '
        '--- Salvar o Registro
        Dim cBLL As New CredorBLL
        Try
            cBLL.Credor_AtivaDesativa(selID, True)
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Ativar o Credor..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
        '--- altera a imagem
        FiltrarListagem()
        '
    End Sub
    '
    Private Sub DesativarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesativarToolStripMenuItem.Click
        '--- verifica se existe alguma cell 
        If dgvListagem.SelectedRows.Count = 0 Then Exit Sub
        '
        '--- Verifica o item
        Dim selID As Integer = dgvListagem.SelectedRows(0).Cells("clnID").Value
        Dim f As clCredor = listCred.Find(Function(x) x.IDPessoa = selID)
        '
        '---pergunta ao usuário
        If MessageBox.Show("Deseja realmente INATIVAR esse Credor?" & vbNewLine &
                           f.Cadastro.ToUpper, "Inativar",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        '
        '--- altera o valor
        f.Ativo = False
        '
        '--- Salvar o Registro
        Dim cBLL As New CredorBLL
        Try
            cBLL.Credor_AtivaDesativa(selID, False)
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Desativar o Credor..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
        '--- altera a imagem
        FiltrarListagem()
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '------------------------------------------------------------------------------------------
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    '------------------------------------------------------------------------------------------
    Private Sub Control_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles txtProcura.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' CRIA UM ATALHO PARA OS COMBO BOX
    '------------------------------------------------------------------------------------------
    Private Sub ComboSelecionaPeloNumero(myCombo As ComboBox, myItemNumber As Integer)
        Dim dt As DataTable = myCombo.DataSource
        Dim rCount As Integer = dt.Rows.Count
        '
        If myItemNumber <= rCount And myItemNumber > 0 Then
            Dim Valor As Integer = dt.Rows(myItemNumber - 1)(0)
            '
            myCombo.SelectedValue = Valor
            '
        End If
        '
    End Sub
    '
    Private Sub frmCredorProcurar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
            ComboSelecionaPeloNumero(cmbCredorTipo, e.KeyChar.ToString)
        ElseIf e.KeyChar.ToString = "+" Then
            e.Handled = True
            btnAdicionar_Click(New Object, New EventArgs)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            btnFechar_Click(New Object, New EventArgs)
        End If
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS SUB-FORMULARIO PADRAO"
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.DarkSlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        _formOrigem.Visible = False
        '
    End Sub
    '
    Private Sub frmDespesaTipo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If IsNothing(_formOrigem) Then Exit Sub
        '
        _formOrigem.Visible = True
        '
    End Sub
    '
#End Region
    '
End Class
