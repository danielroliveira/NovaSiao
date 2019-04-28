Imports CamadaBLL
Imports CamadaDTO

Public Class frmVendaEntrada
    '
    Private _formOrigem As Form
    Private _vlMaximo As Double
    Private _Pag As clMovimentacao
    Private _Acao As EnumFlagAcao
    Private bindPag As New BindingSource
    '
    Private dtTipo As DataTable
    Private lstForma As List(Of clMovForma)
    '
#Region "NEW | BINDING | COMBOBOX"
    '
    '-------------------------------------------------------------------------------------------------
    ' SUB NEW
    '-------------------------------------------------------------------------------------------------
    Sub New(fOrigem As Form,
            TranVlTotal As Double,
            Pag As clMovimentacao,
            Acao As EnumFlagAcao,
            Optional Posicao As Point = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = fOrigem
        _vlMaximo = TranVlTotal
        _Pag = Pag
        _Acao = Acao
        '
        '--- Preenche a lsita de Formas e Tipos
        Dim TipoBLL As New MovimentacaoBLL
        '
        '--- Get DataTable Tipos e Formas
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            lstForma = TipoBLL.MovForma_GET_List(Pag.IDFilial, True)
            dtTipo = TipoBLL.MovTipo_GET_Dt(True)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Evento..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        PreencheListagem()
        bindPag.DataSource = _Pag
        PreencheDataBinding()
        '
        ' Verifica valor do IDMovTipo pelo MovForma
        If IsNothing(_Pag.IDMovForma) Then
            '
            txtFormaTipo.Text = ""
            _Pag.IDMovTipo = Nothing
            '
        Else
            '
            Dim f = lstForma.Single(Function(x) x.IDMovForma = _Pag.IDMovForma)
            txtFormaTipo.Text = f.MovTipo
            _Pag.IDMovTipo = f.IDMovTipo
            '
        End If
        '
        lblConta.Text = ObterDefault("ContaDescricao")
        lblFilial.Text = ObterDefault("FilialDescricao")
        '
        '--- Define a posicao do form
        If Not IsNothing(Posicao) Then
            StartPosition = FormStartPosition.Manual
            Location = Posicao
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    ' PREENCHE O DATABINDING
    '------------------------------------------------------------------------------------------
    Private Sub PreencheDataBinding()
        '
        txtValor.DataBindings.Add("Text", bindPag, "MovValor", True, DataSourceUpdateMode.OnPropertyChanged)
        lstItens.DataBindings.Add("Text", bindPag, "IDMovForma", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtValor.DataBindings("Text").Format, AddressOf FormatCUR
        '
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
#End Region '/ NEW | BINDING | COMBOBOX
    '
#Region "LISTAGEM"
    '
    '--- PREENCHE LISTAGEM
    Private Sub PreencheListagem()
        lstItens.DataSource = lstForma '.OrderBy(Function(x) x.MovForma).ToList
        FormataListagem()
        HabilitaPesquisa()
    End Sub
    '
    '--- FORMATA LISTAGEM DE CLIENTE
    Private Sub FormataListagem()
        '
        lstItens.MultiSelect = False
        lstItens.HideSelection = False
        '
        clnForma.ValueMember = "IDMovForma"
        clnForma.DisplayMember = "MovForma"
        '
    End Sub
    '
#End Region '/ LISTAGEM
    '
#Region "ATALHOS | FUNCOES UTILITARIAS"
    '
    '------------------------------------------------------------------------------------------
    ' USAR TAB AO KEYPRESS ENTER
    '------------------------------------------------------------------------------------------
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtValor.KeyDown, txtFormaTipo.KeyDown,
        lstItens.KeyDown, txtPesquisa.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    '---------------------------------------------------------------------------------------
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtFormaTipo.KeyDown, txtPesquisa.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            Select Case ctr.Name
                Case "txtFormaTipo"
                    btnProcurarTipo_Click(New Object, New EventArgs)
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtFormaTipo"
                    txtFormaTipo.Clear()
                    _Pag.IDMovTipo = Nothing
                    FiltrarListagem()
                Case "txtPesquisa"
                    txtPesquisa.Clear()
                    FiltrarListagem()
            End Select
            '
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ITENS DA LISTAGEM
    '------------------------------------------------------------------------------------------
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
    '------------------------------------------------------------------------------------------
    '--- BLOQUEIA PRESS A TECLA (+)
    '---------------------------------------------------------------------------------------
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
                "txtFormaTipo"
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
    '------------------------------------------------------------------------------------------
    ' CRIA UM ATALHO NUMERICO PARA o CONTROLE
    '------------------------------------------------------------------------------------------
    Private Sub txtFormaTipo_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles txtFormaTipo.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
            '
            Dim rCount As Integer = dtTipo.Rows.Count
            Dim item As Integer = e.KeyChar.ToString
            '
            If item <= rCount And item > 0 Then
                Dim Valor As Integer = dtTipo.Rows(e.KeyChar.ToString - 1)("IDMovTipo")
                '
                _Pag.IDMovTipo = Valor
                txtFormaTipo.Text = dtTipo.Rows(e.KeyChar.ToString - 1)("MovTipo")
                FiltrarListagem()
                '
                HabilitaPesquisa()
                '
            End If
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
#End Region '/ ATALHOS | FUNCOES UTILITARIAS
    '
#Region "PESQUISA"
    '
    '------------------------------------------------------------------------------------------
    ' ALTERA A FORMA DE PAGAMENTO PELA ALTERACAO DO TIPO DE PAGAMENTO
    '------------------------------------------------------------------------------------------
    '
    '--- FILTAR LISTAGEM PELO TIPO E PESQUISA TEXTO
    Private Sub FiltrarListagem()
        '
        lstItens.DataSource = lstForma.FindAll(AddressOf FindProduto).OrderBy(Function(x) x.MovForma).ToList
        '
        If lstItens.Items.Count = 1 Then
            lstItens.SelectedIndices(0) = 0
            _Pag.IDMovForma = lstItens.SelectedItems(0).Value
        End If
        '
    End Sub
    '
    Private Function FindProduto(ByVal f As clMovForma) As Boolean
        '
        If (f.MovForma.ToLower Like "*" & txtPesquisa.Text.ToLower & "*") AndAlso
           If(_Pag.IDMovTipo = 0, True, (_Pag.IDMovTipo = f.IDMovTipo)) Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    '--- TORNA VISIVEL O TXTPESQUISA PARA PROCURA
    Private Sub HabilitaPesquisa()
        '
        If lstItens.Items.Count > 5 Then
            txtPesquisa.Visible = True
            lblPesquisa.Visible = True
        Else
            txtPesquisa.Clear()
            txtPesquisa.Visible = False
            lblPesquisa.Visible = False
        End If
        '
    End Sub
    '
    Private Sub txtPesquisa_TextChanged(sender As Object, e As EventArgs) Handles txtPesquisa.TextChanged
        FiltrarListagem()
    End Sub
    '
#End Region '/ PESQUISA
    '
#Region "BUTONS ACTIONS"
    '
    '------------------------------------------------------------------------------------------
    ' ACAO DOS BOTOES
    '------------------------------------------------------------------------------------------
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '--- Verifica campos/valores
        If IsNothing(_Pag.IDMovTipo) Then
            MessageBox.Show("O campo TIPO de Entrada não pode ficar vazio..." & vbNewLine &
                            "Favor escolher um valor para esse campo.", "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFormaTipo.Focus()
            Exit Sub
        End If
        '
        If lstItens.SelectedItems.Count > 0 Then
            _Pag.IDMovForma = lstItens.SelectedItems(0).Value
        Else
            MessageBox.Show("O campo FORMA de Entrada não pode ficar vazio..." & vbNewLine &
                            "Favor escolher um valor para esse campo.", "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            lstItens.Focus()
            Exit Sub
        End If
        '
        If IsNothing(_Pag.MovValor) OrElse _Pag.MovValor <= 0 OrElse _Pag.MovValor > _vlMaximo Then
            '
            MessageBox.Show("O VALOR da Entrada não pode ser igual ou menor que Zero..." & vbNewLine &
                            "bem como também não pode ser maior que o total da venda..." & vbNewLine &
                            "Favor escolher um valor para esse campo.", "Campo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtValor.Focus()
            txtValor.SelectAll()
            Exit Sub
            '
        End If
        '
        '--- Devolve o credito para o formOrigem
        _Pag.MovForma = lstItens.SelectedItems(0).Text
        _Pag.IDMovForma = lstItens.SelectedItems(0).Value
        _Pag.IDMeio = lstForma.First(Function(x) x.IDMovForma = _Pag.IDMovForma).IDMeio
        _Pag.MovValor = txtValor.Text
        '
        bindPag.EndEdit()
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    '--- BTN FECHAR | CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        bindPag.CancelEdit()
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
    '--- BTN PROCURAR TIPO
    Private Sub btnProcurarTipo_Click(sender As Object, e As EventArgs) Handles btnProcurarTipo.Click
        '
        '---abre o formTipos
        Dim frmTipo As New frmMovTipoProcurar(Me)
        frmTipo.ShowDialog()
        '
        '---verifica os valores
        If frmTipo.DialogResult <> DialogResult.OK Then
            txtFormaTipo.Focus()
            Exit Sub
        End If
        '
        '--- grava os novos valores
        txtFormaTipo.Text = frmTipo.propMovTipo_Escolha
        _Pag.IDMovTipo = frmTipo.propIdMovTipo_Escolha
        FiltrarListagem()
        txtFormaTipo.Focus()
        txtFormaTipo.SelectAll()
        '
    End Sub
    '
#End Region '/ BUTONS ACTIONS
    '
#Region "EFEITO VISUAL"
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
    Private Sub frmAReceberItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.Silver
            End If
        Next
    End Sub
    '
    Private Sub frmVendaPagamento_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If IsNothing(_formOrigem) Then Exit Sub
        '
        For Each c As Control In _formOrigem.Controls
            If c.Name = "Panel1" Then
                c.BackColor = Color.SlateGray
            End If
        Next
    End Sub
    '
#End Region '/ EFEITO VISUAL
    '
End Class
