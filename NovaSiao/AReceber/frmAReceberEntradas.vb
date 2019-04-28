Imports CamadaDTO
Imports CamadaBLL

Public Class frmAReceberEntradas
    '
    Private _Parcela As clAReceberParcela
    Private EntradaList As List(Of clMovimentacao)
    Private EntradaBind As New BindingSource
    Private _formOrigem As Form
    Private _DataPadrao As Date?
    Private Atraso As Integer
    Private vlPermanencia As Double
    Private EmAberto As Double
    Private Estornado As Boolean = False
    '
    Sub New(Parcela As clAReceberParcela, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        '--- obtem a DataPadrao do sistema para calcular atraso e permanencia
        _DataPadrao = Obter_DataPadrao()
        If Not IsNothing(_DataPadrao) Then lblDataPadrao.Text = _DataPadrao
        '
        ' Add any initialization after the InitializeComponent() call.
        propParcela = Parcela
        _formOrigem = formOrigem
        '
    End Sub
    '
    Public Property propParcela() As clAReceberParcela
        Get
            Return _Parcela
        End Get
        Set(ByVal value As clAReceberParcela)
            _Parcela = value
            '
            With _Parcela
                lblReg.Text = .CodRegistro
                lblCadastro.Text = .Cadastro
                lblVencimento.Text = .Vencimento
                lblParcelaValor.Text = Format(.ParcelaValor, "C")
                lblValorPagoParcela.Text = Format(.ValorPagoParcela, "C")
                lblPermanenciaTaxa.Text = Format(.PermanenciaTaxa, "0.00") & "%"
                '
                '--- calcula o valor EmAberto
                EmAberto = .ParcelaValor - .ValorPagoParcela
                lblValorEmAberto.Text = Format(EmAberto, "C")
                '
                '--- verifica a dtPadrao e o atraso
                If Not IsNothing(_DataPadrao) Then
                    Atraso = DateDiff(DateInterval.Day, CDate(.Vencimento), CDate(_DataPadrao))
                    If Atraso < 0 Then Atraso = 0
                Else
                    Atraso = 0
                End If
                lblEmAtrasoDias.Text = Format(Atraso, "00") & " Dias"
                '
                '--- calcula o valor da permanencia pela taxa
                vlPermanencia = .ParcelaValor * Atraso * (.PermanenciaTaxa / 100) / 30
                vlPermanencia = Math.Round(vlPermanencia, 2)
                lblPermanenciaValor.Text = Format(vlPermanencia, "C")
                '
                '--- bloqueia o Botão QUITAR se já estiver PAGA
                If .SituacaoParcela = 1 Then btnQuitar.Enabled = False
                lblSituacao.Text = "... " & .SituacaoDescricao & " ..."
                '
            End With
            '
            ObterEntradas()
            '
        End Set
    End Property
    '
#Region "CARREGA ITENS"
    '
    Private Sub ObterEntradas()
        '
        Dim eBLL As New MovimentacaoBLL
        '
        Try
            '
            EntradaList = eBLL.Movimentacao_GET_PorOrigemID(EnumMovimentacaoOrigem.AReceberParcela,
                                                            _Parcela.IDAReceberParcela)
            EntradaBind.DataSource = EntradaList
            '
            PreencheItens()
            '
        Catch ex As Exception
            MessageBox.Show("Um exceção ocorreu ao tentar obter os Pagamentos/Entradas dessa parcela..." & vbNewLine &
                            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub PreencheItens()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        dgvListagem.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvListagem.MultiSelect = False
        dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListagem.ColumnHeadersVisible = True
        dgvListagem.AllowUserToResizeRows = False
        dgvListagem.AllowUserToResizeColumns = False
        dgvListagem.RowHeadersVisible = True
        dgvListagem.RowHeadersWidth = 30
        dgvListagem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvListagem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvListagem.StandardTab = True
        '
        '--- configura o DataSource
        dgvListagem.DataSource = EntradaBind
        If dgvListagem.Rows.Count > 0 Then dgvListagem.CurrentCell = dgvListagem.Rows(dgvListagem.Rows.Count).Cells(1)
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    Private Sub FormataColunas_Itens()
        '
        ' (1) COLUNA PAGAMENTO DATA
        With clnEntradaData
            .HeaderText = "Data"
            .DataPropertyName = "EntradaData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA PAGAMENTO VALOR
        With clnEntradaValor
            .DataPropertyName = "EntradaValor"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "C"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
        '
        ' (3) COLUNA PAGAMENTO FORMA
        With clnMovForma
            .DataPropertyName = "MovForma"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA CONTA 
        With clnIDConta
            .DataPropertyName = "Conta"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnEntradaData, Me.clnEntradaValor, Me.clnMovForma, Me.clnIDConta})
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS SUB FORMULARIO PADRAO"
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
    '-- CONVERTE A TECLA ESC EM CANCELAR
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnFechar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmAReceberEntradas_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        If Estornado = False Then
            DialogResult = DialogResult.Cancel
        Else
            DialogResult = DialogResult.Yes '--- para fechar e atualizar o frmOrigem
        End If
    End Sub
    '
    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        '
        'Verifica se a situacao da transacao esta EM ABERTO = 1 
        If VerificaTransacaoSit() = False Then Exit Sub
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor

        Dim fEntrada As New frmAReceberQuitar(Me, EmAberto, _Parcela.IDAReceberParcela, vlPermanencia)
        fEntrada.ShowDialog()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        '--- adiciona o item de entrada na listagem
        If fEntrada.DialogResult = DialogResult.OK Then
            '
            '--- Quita a parcela
            Dim p As New ParcelaBLL
            Dim ID As Integer
            '
            Try
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                ID = p.Quitar_Parcela(_Parcela.IDAReceberParcela,
                                      fEntrada.prop_vlPagoDoValor,
                                      fEntrada.prop_vlPagoJuros,
                                      fEntrada.propMovEntrada.MovData)
            Catch ex As Exception
                MessageBox.Show("Ocorreu uma exceção inesperada ao Quitar a Parcela..." & vbNewLine &
                                ex.Message, "Exceção Insperada", MessageBoxButtons.OK)
                Exit Sub
            Finally
                '
                '--- Ampulheta OFF
                Cursor = Cursors.Default
                '
            End Try
            '
            '--- Mensagem de Sucesso
            MessageBox.Show("Parcela quitada com sucesso!", "Entrada Efetuada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '--- Fecha o form
            DialogResult = DialogResult.OK
            '
        End If
        '
    End Sub
    '
    '--- FUNCAO QUE VERIFICA SE A TRANSACAO DE ORIGEM DA PARCELA JÁ ESTA CONCLUIDA
    Private Function VerificaTransacaoSit() As Boolean
        '
        Dim rBLL As New AReceberBLL
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim Sit As Byte = rBLL.AReceber_VerificaSituacaoOrigem(_Parcela.IDAReceber)
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
            If Sit = 1 Then '--- SITUACAO INICIADA MAS NÃO CONCLUIDA
                MessageBox.Show("Não se pode QUITAR uma parcela de uma TRANSAÇÃO que ainda não está FINALIZADA..." & vbNewLine &
                "Finalize a Transação/Venda para poder quitar essa parcela devidamente.",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            Else
                Return True
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Ocorreu uma exceção inesperada ao Verificar a situacao da Origem do A Receber..." & vbNewLine &
                            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
    End Function
    '
    '--- ESTORNAR O ENTRADA DA PARCELA
    Private Sub btnEstornar_Click(sender As Object, e As EventArgs) Handles btnEstornar.Click
        '
        If dgvListagem.Rows.Count = 0 Then
            MessageBox.Show("Não há nenhuma Entrada para ser Estornada...", "Estornar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione uma Entrada para Estornar...", "Estornar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Show()
            Exit Sub
        End If
        '
        Dim clEnt As clMovimentacao = DirectCast(dgvListagem.SelectedRows(0).DataBoundItem, clMovimentacao)
        '
        '--- Pergunta ao usuário
        If MessageBox.Show("Você realmente deseja realizar o ESTORNO da entrada?" & vbNewLine &
                           "VALOR: " & FormatCurrency(clEnt.MovValor) & vbNewLine &
                           "DATA: " & clEnt.MovData, "Estornar Entrada",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        '
        '--- Realiza o Estorno
        Dim p As New ParcelaBLL
        Dim newPar As clAReceberParcela
        '
        Try
            newPar = p.EstornarEntradaParcela(_Parcela.IDAReceberParcela, clEnt.IDMovimentacao)
            '
            '--- Preenche os controles com a nova clParcela recebida
            propParcela = newPar
            Estornado = True '--- variavel para atualizar o frmOrigem quando sair
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção inesperada ocorreu ao estornar entrada/parcela..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
End Class
