Imports CamadaDTO
Imports CamadaBLL

Public Class frmAPagarSaidas
    '
    Private _APagar As clAPagar
    Private SaidasMovList As List(Of clMovimentacao)
    Private SaidaBind As New BindingSource
    Private _formOrigem As Form
    Private _DataPadrao As Date?
    Private Atraso As Integer
    Private EmAberto As Double
    Private vlDescontoAnterior As Double = 0
    Private Estornado As Boolean = False
    '
#Region "NEW | PROPERTYS"
    '
    Sub New(myAPagar As clAPagar, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        '--- obtem a DataPadrao do sistema para calcular atraso
        _DataPadrao = Obter_DataPadrao()
        If Not IsNothing(_DataPadrao) Then lblDataPadrao.Text = _DataPadrao
        '
        ' Add any initialization after the InitializeComponent() call.
        propAPagar = myAPagar
        _formOrigem = formOrigem
        '
        Handler_MouseDown()
        Handler_MouseUp()
        Handler_MouseMove()
        '
    End Sub
    '
    Public Property propAPagar() As clAPagar
        '
        Get
            Return _APagar
        End Get
        '
        Set(ByVal value As clAPagar)
            _APagar = value
            '
            With _APagar
                lblIdentificador.Text = .Identificador
                lblCadastro.Text = .Cadastro
                lblVencimento.Text = .Vencimento
                lblCobrancaForma.Text = .CobrancaForma
                lblBancoNome.Text = .BancoNome
                txtAPagarValor.Text = Format(.APagarValor, "C")
                'If IsNothing(.Desconto) Then .Desconto = 0
                txtDesconto.Text = Format(.Desconto, "C")
                txtValorPago.Text = Format(.ValorPago, "C")
                '
                '--- calcula o valor EmAberto
                EmAberto = .APagarValor - .ValorPago - If(.Desconto, 0)
                txtValorEmAberto.Text = Format(EmAberto, "C")
                '
                '--- verifica a dtPadrao e o atraso
                If Not IsNothing(_DataPadrao) Then
                    Atraso = DateDiff(DateInterval.Day, CDate(.Vencimento), CDate(_DataPadrao))
                    If Atraso < 0 Then Atraso = 0
                Else
                    Atraso = 0
                End If
                '
                lblEmAtrasoDias.Text = Format(Atraso, "00") & " Dias"
                '
                '--- bloqueia o Botão QUITAR se já estiver PAGA
                '--- bloqueia o conceder desconto se o APagar estiver quitado
                If .Situacao = 1 Then
                    btnQuitar.Enabled = False
                    btnConcederDesconto.Enabled = False
                Else
                    btnQuitar.Enabled = True
                    btnConcederDesconto.Enabled = True
                End If
                '
                '--- Verify if is APAGAR PERIODICO
                '----------------------------------------------------------------------------------
                If .Origem = 3 Then
                    '
                    If IsNothing(.IDAPagar) Then
                        btnQuitar.Text = "Tornar &Real"
                        btnConcederDesconto.Enabled = False
                        '
                        '--- Altera o label da situação
                        lblSituacao.Text = "Despesa Periódica"
                    Else
                        btnQuitar.Text = "&Quitar"
                        btnConcederDesconto.Enabled = True
                        '
                        '--- Altera o label da situação
                        lblSituacao.Text = "Despesa Periódica Real"
                    End If
                    '
                Else
                    '
                    '--- Altera o label da situação
                    lblSituacao.Text = "... " & .SituacaoDescricao & " ..."
                    '
                End If
                '
            End With
            '
            ObterSaidas()
            '
        End Set
        '
    End Property
    '
#End Region
    '
#Region "CONTROLA MOVIMENTACOES SAIDA"
    '
    Private Sub ObterSaidas()
        '
        If IsNothing(_APagar.IDAPagar) Then
            Exit Sub
        End If
        '
        Dim sBLL As New MovimentacaoBLL
        '
        Try
            SaidasMovList = sBLL.Movimentacao_GET_PorOrigemID(EnumMovimentacaoOrigem.APagar, _APagar.IDAPagar)
            SaidaBind.DataSource = SaidasMovList
            '
            PreencheItens()
            '
        Catch ex As Exception
            MessageBox.Show("Um exceção ocorreu ao tentar obter os Pagamentos/Saídas desse APagar ..." & vbNewLine &
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
        dgvListagem.DataSource = SaidaBind
        If dgvListagem.Rows.Count > 0 Then dgvListagem.CurrentCell = dgvListagem.Rows(dgvListagem.Rows.Count).Cells(1)
        '--- formata as colunas do datagrid
        FormataColunas_Itens()
        '
    End Sub
    '
    Private Sub FormataColunas_Itens()
        '
        ' (0) COLUNA PAGAMENTO DATA
        With clnEntradaData
            .HeaderText = "Data"
            .DataPropertyName = "MovData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (1) COLUNA PAGAMENTO VALOR
        With clnEntradaValor
            .HeaderText = "Valor"
            .DataPropertyName = "MovValor"
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
        ' (2) COLUNA CONTA 
        With clnIDConta
            .HeaderText = "Conta de Saída"
            .DataPropertyName = "Conta"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA OBSERVACAO 
        With clnObservacao
            .HeaderText = "Observação"
            .DataPropertyName = "Observacao"
            .Width = 200
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        Me.dgvListagem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnEntradaData, Me.clnEntradaValor, Me.clnIDConta, Me.clnObservacao})
        '
    End Sub
    '
    ' ALTERA A COR DO DATAGRIDVIEW QUANDO GANHA OU PERDE O FOCO
    '-----------------------------------------------------------------------------------------------------
    Private Sub dgv_GotFocus(sender As Object, e As EventArgs) Handles dgvListagem.GotFocus
        '
        Dim c As Color = Color.FromArgb(209, 215, 220)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.FixedSingle
        '
    End Sub
    '
    Private Sub dgv_LostFocus(sender As Object, e As EventArgs) Handles dgvListagem.LostFocus
        '
        Dim c As Color = Color.FromArgb(224, 232, 243)
        sender.BackgroundColor = c
        DirectCast(sender, DataGridView).BorderStyle = BorderStyle.Fixed3D
        '
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '
    Private Sub btnConcederDesconto_Click(sender As Object, e As EventArgs) Handles btnConcederDesconto.Click
        vlDescontoAnterior = CDbl(txtDesconto.Text)
        txtDesconto.BackColor = Color.White
        txtDesconto.ReadOnly = False
        txtDesconto.Focus()
    End Sub
    '
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
        '--- QUITAR DESPESA OU TORNAR REAL
        '--------------------------------------------------------------------------------------------
        If _APagar.Origem = 3 And IsNothing(_APagar.IDAPagar) Then '--- DESPESA PERIODICA - Torna a Despesa Real 
            '
            Dim dBLL As New DespesaPeriodicaBLL
            '
            Try
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                _APagar.IDAPagar = dBLL.DespesaPeriodica_TornarReal(_APagar)
                propAPagar = _APagar
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao Tornar a Despesa Real..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                '--- Ampulheta OFF
                Cursor = Cursors.Default
            End Try
            '
        Else '--- QUITAR DESPESA REAL
            '
            Dim fSaida As New frmAPagarQuitar(Me, _APagar)
            fSaida.ShowDialog()
            '
            If fSaida.DialogResult = DialogResult.OK Then DialogResult = DialogResult.OK
            '
        End If
        '
    End Sub
    '
    '--- FUNCAO QUE VERIFICA SE A TRANSACAO DE ORIGEM DO APAGAR JÁ ESTA CONCLUIDA
    Private Function VerificaTransacaoSit() As Boolean
        '
        '--- VERIFICA A ORIGEM DESPESA DIFERENTE DE TRANSACAO
        '--------------------------------------------------------------------------------------------
        If _APagar.Origem <> 1 Then
            Return True
        End If
        '
        '--- ORIGEM TRANSACAO DE COMPRA
        '--------------------------------------------------------------------------------------------
        Dim SQL As New SQLControl
        Dim mySQL As String = "SELECT IDSituacao FROM tblTransacao WHERE IDTransacao = " & _APagar.IDOrigem
        '
        SQL.ExecQuery(mySQL)
        '
        If SQL.HasException Then
            MessageBox.Show("Houve uma exceção ao verificar se a transação está FINALIZADA..." & vbNewLine &
                            SQL.Exception, "Exceção Inesperada", MessageBoxButtons.OK)
            Return False
        End If
        '
        Dim r As DataRow = SQL.DBDT.Rows(0)
        '
        '--- verifica
        If r(0) = 1 Then '--- SITUACAO INICIADA MAS NÃO CONCLUIDA
            MessageBox.Show("Não se pode QUITAR um APAGAR de uma TRANSAÇÃO/COMPRA que ainda não está FINALIZADA..." & vbNewLine &
                            "Finalize a Transação/COMPRA para poder quitar devidamente.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    '--- ESTORNAR A QUITAÇÃO DO APAGAR
    Private Sub btnEstornar_Click(sender As Object, e As EventArgs) Handles btnEstornar.Click

        If dgvListagem.Rows.Count = 0 Then
            MessageBox.Show("Não há nenhum Pagamento para ser Estornado...", "Estornar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        If dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um Pagamento para Estornar...", "Estornar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Show()
            Exit Sub
        End If
        '
        Dim clS As clMovimentacao = DirectCast(dgvListagem.SelectedRows(0).DataBoundItem, clMovimentacao)
        '
        '--- Pergunta ao usuário
        If MessageBox.Show("Você realmente deseja realizar o ESTORNO do Pagamento?" & vbNewLine &
                           "VALOR: " & FormatCurrency(clS.MovValor) & vbNewLine &
                           "DATA: " & clS.MovData, "Estornar Pagamento",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        '--- Realiza o Estorno
        Dim p As New APagarBLL
        Dim newPag As clAPagar

        Try
            newPag = p.Estornar_APagar(_APagar.IDAPagar, clS.IDMovimentacao)
            '
            '--- Preenche os controles com a nova clParcela recebida
            propAPagar = newPag
            Estornado = True '--- variavel para atualizar o frmOrigem quando sair
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção inesperada ocorreu ao estornar Pagamento..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    Private Sub txtDesconto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesconto.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    Private Sub txtDesconto_Leave(sender As Object, e As EventArgs) Handles txtDesconto.Leave
        '
        txtDesconto.ReadOnly = True
        txtDesconto.BackColor = Color.FromArgb(230, 230, 230)
        '
        '--- verifica se o desconto foi alterado
        Dim newDesconto As Double = CDbl(txtDesconto.Text)

        If vlDescontoAnterior <> newDesconto Then
            '
            '--- verifica se o novo valor do desconto é menor que o valor do APagar
            If newDesconto >= _APagar.APagarValor - _APagar.ValorPago Then
                MessageBox.Show("Não é possível conceder um valor de DESCONTO MAIOR ou IGUAL ao valor EM ABERTO desse A PAGAR...",
                                "Conceder Desconto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDesconto.Text = Format(vlDescontoAnterior, "C")
                Exit Sub
            End If
            '
            Dim pBLL As New APagarBLL
            '
            Try
                pBLL.ConcederDesconto_APagar(_APagar.IDAPagar, newDesconto)
                _APagar.Desconto = newDesconto
                '
                '--- recalcula o valor em aberto
                EmAberto = _APagar.APagarValor - _APagar.ValorPago - _APagar.Desconto
                txtValorEmAberto.Text = Format(EmAberto, "C")
                '
            Catch ex As Exception
                MessageBox.Show("Uma exceção ocorreu ao Conceder Desconto ao APagar..." & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDesconto.Text = Format(vlDescontoAnterior, "C")
            End Try
            '
        End If
        '
    End Sub
    '
    '------------------------------------------------------------------------------------------
    '-- CONVERTE A TECLA ESC EM CANCELAR
    '------------------------------------------------------------------------------------------
    Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnFechar_Click(New Object, New EventArgs)
        End If
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
    Private Sub frmAPagarSaidas_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class
