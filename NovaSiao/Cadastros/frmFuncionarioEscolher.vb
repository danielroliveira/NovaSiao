Imports CamadaBLL
Imports ComponentOwl.BetterListView
'
Public Class frmFuncionarioEscolher
    '
    Private _DestinoVenda As Boolean
    Private _formOrigem As Form
    Private _IDFilial As Integer
    Private dtFunc As DataTable
    Property IDEscolhido As Integer?
    Property NomeEscolhido As String
    '
#Region "SUBNEW E LOAD"
    '
    '--- SUB NEW
    Public Sub New(Optional DestinoVenda As Boolean = False, Optional frmOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _IDFilial = Obter_FilialPadrao()
        lblFilial.Text = ObterDefault("FilialDescricao")
        _DestinoVenda = DestinoVenda
        '
        If Not IsNothing(frmOrigem) Then
            _formOrigem = frmOrigem
        End If
        '
    End Sub
    '
    '--- EVENTO LOAD
    Private Sub frmFuncionarioEscolher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        If PreencheData() = False Then
            Me.Close()
            Exit Sub
        End If
        '
        PreencheListagem()
        '
        If _DestinoVenda = False Then
            lblTitulo.Text = "Escolha um Funcionário"
        Else
            lblTitulo.Text = "Escolha um Vendedor"
        End If
        '
        AddHandler chkAtivo.CheckedChanged, AddressOf chkAtivo_CheckedChanged
        '
    End Sub
    '
#End Region '/ SUBNEW E LOAD
    '
#Region "LISTAGEM GET E CONTROLE"
    '
    Private Function PreencheData() As Boolean
        '
        Dim fBLL As New FuncionarioBLL
        Dim strSQL As String
        '
        '--- Preenche o Datatable
        Try
            If _DestinoVenda = True Then
                strSQL = $"Vendedor = 'TRUE' AND Ativo = '{chkAtivo.Checked}' AND IDFilial = {_IDFilial} ORDER BY ApelidoFuncionario ASC"
                dtFunc = fBLL.GetFuncionarios_DT(strSQL)
                '
                '--- verifica se retornou algum registro
                If dtFunc.Rows.Count = 0 Then
                    MessageBox.Show("Não há vendedores" & IIf(chkAtivo.Checked = True, " Ativos ", " Inativos ") & "cadastrados no sistema",
                                    "Sem Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                '
            Else
                strSQL = $"Ativo = '{chkAtivo.Checked}' AND IDFilial = {_IDFilial} ORDER BY Cadastro ASC"
                dtFunc = fBLL.GetFuncionarios_DT(strSQL)
                '
                '--- verifica se retornou algum registro
                If dtFunc.Rows.Count = 0 Then
                    MessageBox.Show("Não há funcionários" & IIf(chkAtivo.Checked = True, " Ativos ", " Inativos ") & "cadastrados no sistema",
                                    "Sem Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                '
            End If
            '
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Não foi possível apresentar a lista de funcionários...",
                            "Procurar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
        '
    End Function
    '
    Private Sub PreencheListagem()
        '
        lstListagem.DataSource = dtFunc
        lstListagem.Columns(1).DisplayMember = "ApelidoFuncionario"
        '
    End Sub
    '
    Private Sub lstListagem_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstListagem.DrawColumnHeader
        '
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            Dim brush As Brush = New SolidBrush(Color.LightSteelBlue)

            eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)
            eventArgs.Graphics.DrawString(eventArgs.ColumnHeader.Text, New Font("Verdana", 12, FontStyle.Regular), New SolidBrush(Color.Black), eventArgs.ColumnHeaderBounds.BoundsText)

            brush.Dispose()
        End If
        '
    End Sub
    Private Sub lstListagem_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstListagem.DrawItem
        '
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "00")
        End If
        '
    End Sub
    '
    Private Sub lstListagem_ItemActivate(sender As Object, eventArgs As BetterListViewItemActivateEventArgs) Handles lstListagem.ItemActivate
        btnEscolher_Click(New Object, New System.EventArgs)
    End Sub
    '
    Private Sub chkAtivo_CheckedChanged(sender As Object, e As EventArgs)
        PreencheData()
        PreencheListagem()
        '
        If lstListagem.Count > 0 Then
            lstListagem.Focus()
        Else
            btnCancelar.Focus()
        End If
        '
        If chkAtivo.Checked Then
            lblAtivo.Text = "Ativos"
        Else
            lblAtivo.Text = "Inativos"
        End If
    End Sub
    '
#End Region '/ LISTAGEM GET E CONTROLE
    '
#Region "BUTTONS FUNCTION"
    '
    ' BOTÃO FECHAR
    '----------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    '
    ' ESCOLHER E SAIR
    '----------------------------------------------------------------------------------
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If lstListagem.SelectedItems.Count = 0 Then
            MessageBox.Show("Não nenhum Funcionário selecionado..." & vbNewLine &
                "Favor antes selecione um Funcionário!",
                "Escolher Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        ' DEFINIR O VALOR
        IDEscolhido = CInt(lstListagem.SelectedItems(0).Text) ' ID DO FUNCIONARIO/VENDEDOR
        NomeEscolhido = lstListagem.SelectedItems(0).SubItems(1).Text ' NOME DO FUNCIONARIO/VENDEDOR
        '
        Me.DialogResult = DialogResult.OK
        '
    End Sub
    '
    '--- FECHAR QUANDO PRESS ESC
    '----------------------------------------------------------------------------------
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            '
            e.Handled = True
            btnCancelar_Click(New Object, New EventArgs)
            '
        End If
        '
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "EFEITO VISUAL"

    '
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
    Private Sub frmTransacaoItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAReceberItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.Silver
            End If
        Next
        '
    End Sub
    '
    Private Sub frmAReceberItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.SlateGray
            End If
        Next
        '
    End Sub
    '
#End Region '/ EFEITO VISUAL
    '
End Class
