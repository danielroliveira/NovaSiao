Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmAPagarReceberSimples
    Private SourceList As Object
    Private _myMes As Date
    Private EntradaSaida As Boolean '--- property
    Private _IDFilial As Integer?
    Private _IDFilialPadrao As Integer?
    '
#Region "PROPERTY E EVENTO LOAD"
    '
    Private Property myMes() As DateTime
        Get
            Return _myMes
        End Get
        Set(ByVal value As DateTime)
            '
            If CDate(value.ToShortDateString) > CDate(Now.ToShortDateString) Then
                value = Now.ToShortDateString
                btnPeriodoPosterior.Enabled = False
            Else
                btnPeriodoPosterior.Enabled = True
            End If
            '
            _myMes = value
            lblPeriodo.Text = Format(_myMes, "MMMM | yyyy")
            '
        End Set
    End Property
    '
    Public Property propEntradaSaida() As Boolean
        '
        Get
            Return EntradaSaida
        End Get
        '
        Set(ByVal value As Boolean)
            '
            '--- IF not change resume
            If value = EntradaSaida AndAlso Me.Visible = True Then Return
            '
            '--- IF is really changed
            EntradaSaida = value
            '
            '--- obtem a nova listagem source e altera o DataGrid
            GetList_AlteraListagem()
            '
            '--- altara as etiquetas do header acima do datagrid
            AlteraEtiquetas()
            '
        End Set
        '
    End Property
    '
    Private Sub frmAPagaReceberSimples_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- define a posicao do pnlMes
        pnlMes.Location = New Point(636, 130)
        '
    End Sub
    '
    Sub New(Movimentacao As Boolean)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- define a FilialPadrao
        _IDFilialPadrao = Obter_FilialPadrao()
        lblFilial.Text = ObterDefault("FilialDescricao")
        '---
        CarregaCmbSituacao()
        myMes = ObterDefault("DataPadrao")
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        FormataListagem()
        '
        propEntradaSaida = Movimentacao '--> FALSE: A PAGAR | TRUE: A RECEBER
        rbtAPagar.Checked = Not Movimentacao
        rbtAReceber.Checked = Movimentacao
        Butons_CheckedChanged(Me, New EventArgs)
        '
        '--- Add Handlers
        AddHandler rbtAPagar.CheckedChanged, AddressOf Butons_CheckedChanged
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
        'AddHandler cmbSituacao.SelectedIndexChanged, AddressOf cmbSituacao_SelectedIndexChanged
        '
    End Sub
    '
    '--- OBTEM A NOVA LISTAGEM SOURCE E ALTERA O DATAGRID
    Private Sub GetList_AlteraListagem()
        '
        Select Case EntradaSaida
            Case False '--- A PAGAR | SIMPLES ENTRADA
                GetList_APagar()
                PreencheColunas_APagar()
                '
                '--- calcula Totais
                Dim lst As List(Of clAPagar) = SourceList
                Dim APagar As Double = lst.Sum(Function(x) x.APagarValor)
                Dim Pago As Double = lst.Sum(Function(x) x.ValorPago)
                '
                lblTotal.Text = Format(APagar, "C")
                lblPago.Text = Format(Pago, "C")
                lblEmAberto.Text = Format(APagar - Pago, "C")
                '
            Case True '--- A RECEBER | SIMPLES SAIDAS
                GetList_AReceber()
                PreencheColunas_AReceber()
                '
                '--- calcula Totais
                Dim lst As List(Of clAReceberParcela) = SourceList
                Dim AReceber As Double = lst.Sum(Function(x) x.ParcelaValor)
                Dim Recebido As Double = lst.Sum(Function(x) x.ValorPagoParcela)
                '
                lblTotal.Text = Format(AReceber, "C")
                lblPago.Text = Format(Recebido, "C")
                lblEmAberto.Text = Format(AReceber - Recebido, "C")
                '
        End Select
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' PREENCHE COMBO
    '-------------------------------------------------------------------------------------------------
    Private Sub CarregaCmbSituacao()
        '
        Try

            Dim dtSit As New DataTable
            '
            dtSit.Columns.Add("IDSit", GetType(Integer))
            dtSit.Columns.Add("Situacao", GetType(String))
            '
            dtSit.Rows.Add({1, "Em Aberto"})
            dtSit.Rows.Add({2, "Pagas"})
            '
            With cmbSituacao
                .DataSource = dtSit
                .ValueMember = "IDSit"
                .DisplayMember = "Situacao"
                .SelectedValue = 1
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao obter a lista de Situacao:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub GetList_APagar()
        '
        Dim pagBLL As New APagarBLL
        '
        '--- consulta o banco de dados
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                SourceList = pagBLL.GetAPagarLista_Procura(_IDFilialPadrao,
                                                           txtFilialDestino.Text,
                                                           False, True)
            Else
                Dim f As New Utilidades
                Dim dtInicial As Date = f.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = f.LastDayOfMonth(myMes)
                '
                SourceList = pagBLL.GetAPagarLista_Procura(_IDFilialPadrao,
                                                           txtFilialDestino.Text,
                                                           False, True, Nothing,
                                                           dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = SourceList
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter a lista de A Pagar..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub GetList_AReceber()
        '
        Dim simplesBLL As New SimplesMovimentacaoBLL
        '
        '--- consulta o banco de dados
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                SourceList = simplesBLL.GetSimplesAReceberLista_Procura(_IDFilialPadrao, _IDFilial)
            Else
                Dim f As New Utilidades
                Dim dtInicial As Date = f.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = f.LastDayOfMonth(myMes)
                '
                SourceList = simplesBLL.GetSimplesAReceberLista_Procura(_IDFilialPadrao, _IDFilial, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = SourceList
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao obter lista de A Receber..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region '/PROPERTY E EVENTO LOAD
    '
#Region "LISTAGEM CONFIGURAÇÃO"
    '
    Private Sub FormataListagem()
        '
        ' altera as propriedades importantes
        dgvListagem.MultiSelect = False
        dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListagem.ColumnHeadersVisible = False
        dgvListagem.AllowUserToResizeRows = False
        dgvListagem.AllowUserToResizeColumns = False
        dgvListagem.RowHeadersVisible = True
        dgvListagem.RowHeadersWidth = 30
        dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvListagem.StandardTab = True
        dgvListagem.AutoGenerateColumns = False
        '
    End Sub
    '
    Private Sub PreencheColunas_APagar()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUNA VENCIMENTO
        dgvListagem.Columns.Add("clnVencimento", "Vencto")
        With dgvListagem.Columns("clnVencimento")
            .DataPropertyName = "Vencimento"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (1) COLUNA FILIAL (CLNFILIAL) ORIGEM
        dgvListagem.Columns.Add("clnCadastro", "Filial Origem")
        With dgvListagem.Columns("clnCadastro")
            .DataPropertyName = "Cadastro"
            .Width = 280
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA VALOR
        dgvListagem.Columns.Add("clnAPagarValor", "Valor")
        With dgvListagem.Columns("clnAPagarValor")
            .DataPropertyName = "APagarValor"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (3) COLUNA VALOR PAGO
        dgvListagem.Columns.Add("clnValorPago", "Pago")
        With dgvListagem.Columns("clnValorPago")
            .DataPropertyName = "ValorPago"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (4) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("clnSituacao", "Situacao")
        With dgvListagem.Columns("clnSituacao")
            .DataPropertyName = "SituacaoDescricao"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
    End Sub
    '
    Private Sub PreencheColunas_AReceber()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUNA VENCIMENTO
        dgvListagem.Columns.Add("clnVencimento", "Vencto")
        With dgvListagem.Columns("clnVencimento")
            .DataPropertyName = "Vencimento"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (1) COLUNA FILIAL (CLNFILIAL) ORIGEM
        dgvListagem.Columns.Add("clnCadastro", "Filial Destino")
        With dgvListagem.Columns("clnCadastro")
            .DataPropertyName = "Cadastro"
            .Width = 280
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA VALOR
        dgvListagem.Columns.Add("clnParcelaValor", "Valor")
        With dgvListagem.Columns("clnParcelaValor")
            .DataPropertyName = "ParcelaValor"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (3) COLUNA VALOR PAGO
        dgvListagem.Columns.Add("clnValorPago", "Recebido")
        With dgvListagem.Columns("clnValorPago")
            .DataPropertyName = "ValorPagoParcela"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (4) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("clnSituacao", "Situacao")
        With dgvListagem.Columns("clnSituacao")
            .DataPropertyName = "SituacaoDescricao"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
    End Sub
    '
    '--- ALTERA AS ETIQUETAS PARA COMBINAR COM A LISTAGEM
    Private Sub AlteraEtiquetas()
        '
        Try
            '
            Dim r As New Rectangle
            '
            lbl0.Text = dgvListagem.Columns(0).HeaderText
            lbl1.Text = dgvListagem.Columns(1).HeaderText
            lbl2.Text = dgvListagem.Columns(2).HeaderText
            '
            ' column 3 - Column SIT
            lbl3.Text = dgvListagem.Columns(3).HeaderText
            'r = dgvListagem.GetCellDisplayRectangle(3, 0, False)
            'lbl3.Width = r.Width
            'lbl3.Location = New Point(r.X, lbl3.Location.Y)
            'lbl3.TextAlign = ContentAlignment.MiddleRight
            '
            ' column 4
            lbl4.Text = dgvListagem.Columns(4).HeaderText

            '
        Catch ex As Exception
            lbl0.Text = ""
            lbl1.Text = ""
            lbl2.Text = ""
            lbl3.Text = ""
            lbl4.Text = ""
        End Try
        '
    End Sub
    '
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        '--- Define o texto do APAGAR quando esta VENCIDO
        If e.ColumnIndex = 4 AndAlso e.Value = "Em Aberto" Then
            Dim dtVenc As Date = dgvListagem.Rows(e.RowIndex).Cells(0).Value
            If dtVenc < Date.Today Then
                e.Value = "Vencida"
                e.CellStyle.ForeColor = Color.Red
            End If
        End If
        '
    End Sub
    '
#End Region '/LISTAGEM CONFIGURAÇÃO
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        '
        Dim f As New frmSimplesQuitar(Me, propEntradaSaida,
                                      _IDFilialPadrao,
                                      lblFilial.Text,
                                      _IDFilial,
                                      txtFilialDestino.Text)
        '
        f.ShowDialog()
        '
        '--- Se retornar DIALOGRESULT = OK THEN
        If f.DialogResult <> DialogResult.Cancel Then
            GetList_AlteraListagem()
        End If
        '
    End Sub
    '
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        '
        '--- Verifica se esta selecionado
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Não existe nenhum A Pagar selecionado na listagem", "Escolher",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim sBLL As New SimplesMovimentacaoBLL
        '
        If propEntradaSaida = False Then '--- A PAGAR | SIMPLES ENTRADA
            '
            Dim clP As clAPagar = dgvListagem.SelectedRows(0).DataBoundItem
            '
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                Dim simples As clSimplesEntrada = sBLL.GetSimplesEntrada_PorID(clP.IDOrigem)
                '
                Dim frm = New frmSimplesEntrada(simples)
                frm.MdiParent = frmPrincipal
                frm.StartPosition = FormStartPosition.CenterScreen
                Close()
                frm.Show()
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao obter a Simples Entrada..." & vbNewLine &
                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
        ElseIf propEntradaSaida = True Then '--- A RECEBER | SIMPLES SAIDA
            '
            Dim clP As clAReceberParcela = dgvListagem.SelectedRows(0).DataBoundItem
            '
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                Dim simples As clSimplesSaida = sBLL.GetSimplesSaida_PorID(clP.IDOrigem)
                '
                Dim frm = New frmSimplesSaida(simples)
                frm.MdiParent = frmPrincipal
                frm.StartPosition = FormStartPosition.CenterScreen
                Close()
                frm.Show()
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao obter a Simples Saída..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
        End If
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        '
        btnEditar_Click(sender, New EventArgs)
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    '--- BOTAO PROCURAR FILIAL
    Private Sub btnProcurarFilial_Click(sender As Object, e As EventArgs) Handles btnProcurarFilial.Click
        ProcurarEscolherFilial(txtFilialDestino)
    End Sub
    '
    '--- ESCOLHER FILIAL
    Private Sub ProcurarEscolherFilial(sender As Control)
        '
        Dim frmT As Form = Nothing
        Dim oldID As Integer?
        oldID = _IDFilial
        frmT = New frmFilialEscolher(Me, oldID)
        '
        ' revela o formulario dependendo do controle acionado
        frmT.ShowDialog()
        '
        ' ao fechar dialog verifica o resultado
        If frmT.DialogResult <> DialogResult.Cancel Then
            '
            '--- verify if is same Filial
            Dim IDFilialEscolha As Integer = DirectCast(frmT, frmFilialEscolher).propFilial.IDPessoa
            '
            If If(_IDFilialPadrao, 0) = IDFilialEscolha Then
                MessageBox.Show("Você escolheu a mesma Filial Atual:" & vbNewLine &
                                lblFilial.Text.ToUpper & vbNewLine &
                                "Não é possível possuir A Receber ou A Pagar para mesma filial." & vbNewLine &
                                "Favor escolher uma Filial diferente...",
                                "Mesma Filial Padrão",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFilialDestino.Focus()
                Return
            End If
            '
            txtFilialDestino.Text = DirectCast(frmT, frmFilialEscolher).propFilial.ApelidoFilial
            _IDFilial = IDFilialEscolha
            '
            ' altera o FlagEstado para ALTERADO
            If If(oldID, 0) <> If(_IDFilial, 0) Then
                '
                '--- Verifica o BD
                GetList_AlteraListagem()
                '
            End If
            '
            ' move focus
            txtFilialDestino.Focus()
            '
        End If
        '
    End Sub
    '
#End Region '/ACAO DOS BOTOES
    '
#Region "CONTROLES GERAIS | FLUXO"
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnQuitar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtFilialDestino.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            btnProcurarFilial_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            txtFilialDestino.Clear()
            '
            If Not IsNothing(_IDFilial) Then
                _IDFilial = Nothing
                GetList_AlteraListagem()
            End If
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({"txtFilial"})
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilialDestino.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region '/CONTROLES GERAIS | FLUXO
    '
#Region "CONTROLE DO PERÍODO"
    '
    Private Sub btnPeriodoAnterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoAnterior.Click
        myMes = myMes.AddMonths(-1)
        dtMes.SelectionStart = myMes
    End Sub
    '
    Private Sub btnPeriodoPosterior_Click(sender As Object, e As EventArgs) Handles btnPeriodoPosterior.Click
        myMes = myMes.AddMonths(1)
        dtMes.SelectionStart = myMes
        '
        If Year(myMes) = Year(Now) AndAlso Month(myMes) = Month(Now) Then
            btnPeriodoPosterior.Enabled = False
        Else
            btnPeriodoPosterior.Enabled = True
        End If
        '
    End Sub
    '
    Private Sub btnMesAtual_Click(sender As Object, e As EventArgs) Handles btnMesAtual.Click
        myMes = Now
        dtMes.SelectionStart = myMes
        btnPeriodoPosterior.Enabled = False
    End Sub
    '
    Private Sub dtMes_DateChanged(sender As Object, e As DateRangeEventArgs)
        '
        If CDate(e.Start.ToShortDateString) <= CDate(Today.ToShortDateString) Then
            myMes = e.Start
            lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
            '
            '--- obtem a nova listagem source e altera o DataGrid
            GetList_AlteraListagem()
            '
        Else
            MessageBox.Show("Escolha um mês anterior ou igual ao mês atual...",
                "Período", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtMes.SelectionStart = Now
            myMes = Now
        End If
        '
    End Sub
    '
    Private Sub chkPeriodoTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodoTodos.CheckedChanged
        '
        If chkPeriodoTodos.Checked = False Then
            btnPeriodoAnterior.Enabled = True
            btnPeriodoPosterior.Enabled = True
            btnMesAtual.Enabled = True
            lblPeriodo.Visible = True
        Else
            btnPeriodoAnterior.Enabled = False
            btnPeriodoPosterior.Enabled = False
            btnMesAtual.Enabled = False
            lblPeriodo.Visible = False
        End If
        '
        GetList_AlteraListagem()
        '
    End Sub
    '
    Private Sub lblPerido_Click(sender As Object, e As EventArgs) Handles lblPeriodo.Click
        pnlMes.Visible = True
        dtMes.Focus()
    End Sub
    '
    Private Sub pnlMes_Leave(sender As Object, e As EventArgs) Handles pnlMes.MouseLeave, dtMes.LostFocus
        pnlMes.Visible = False
    End Sub
    '
#End Region '/CONTROLE DO PERÍODO
    '
#Region "CONTROLE DOS BTN PESQUISA"
    '
    Private Sub Butons_CheckedChanged(sender As Object, e As EventArgs)
        '
        If rbtAPagar.Checked = True Then ' A PAGAR
            If propEntradaSaida <> False Then propEntradaSaida = False
            '
            rbtAPagar.BackColor = Color.SlateGray
            rbtAPagar.ForeColor = Color.White
            rbtAReceber.BackColor = Color.Gainsboro
            rbtAReceber.ForeColor = Color.Black
            '
            lblTitulo.Text = "Simples Entradas - A Pagar"
            '
            lblT1.Text = "A Pagar Total"
            lblT2.Text = "Pago"
            lbl3.Text = "Pago"
            '
            btnQuitar.Text = "&Quitar"
            '
        Else ' A RECEBER
            If propEntradaSaida <> True Then propEntradaSaida = True
            '
            rbtAPagar.BackColor = Color.Gainsboro
            rbtAPagar.ForeColor = Color.Black
            rbtAReceber.BackColor = Color.SlateGray
            rbtAReceber.ForeColor = Color.White
            '
            lblTitulo.Text = "Simples Saídas - A Receber"
            '
            lblT1.Text = "A Receber Total"
            lblT2.Text = "Recebido"
            lbl3.Text = "Recebido"
            '
            btnQuitar.Text = "&Receber"
            '
        End If
        '
    End Sub
    '
#End Region '/ CONTROLE DOS BTN PESQUISA
    '
#Region "TRATAMENTO VISUAL"
    '
    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint
        '
        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)
        '
    End Sub
    '
#End Region '/ TRATAMENTO VISUAL
    '
End Class
