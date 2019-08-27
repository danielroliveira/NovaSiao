Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmOperacaoEntradaProcurar
    Private SourceList As Object
    Private ImgAtivo As Image = My.Resources.accept
    Private ImgInativo As Image = My.Resources.block
    Private ImgLock As Image = My.Resources.lock
    Private _myMes As Date
    Private _Operacao As Byte
    '
    '
#Region "PROPERTYS"
    '
    Private Property myMes() As DateTime
        '
        Get
            Return _myMes
        End Get
        '
        Set(ByVal value As DateTime)
            If CDate(value.ToShortDateString) > CDate(Now.ToShortDateString) Then
                value = Now.ToShortDateString
                btnPeriodoPosterior.Enabled = False
            Else
                btnPeriodoPosterior.Enabled = True
            End If
            _myMes = value
            lblPeriodo.Text = Format(_myMes, "MMMM | yyyy")
        End Set
        '
    End Property
    '
    Private Property propOperacao As Byte
        '
        Get
            Return _Operacao
        End Get
        '
        Set(value As Byte)
            '
            _Operacao = value
            txtProcura.Clear()
            '
            '--- obtem a nova listagem source e altera o DataGrid
            GetList_AlteraListagem()
            '
            AlteraEtiquetas()
            '
        End Set
        '
    End Property
    '
#End Region '/ PROPERTYS
    '
#Region "EVENTO LOAD"
    '
    Private Sub frmOperacaoEntradaProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- define a posicao do pnlMes
        pnlMes.Location = New Point(636, 130)
        '
        PreencheComboOperacao()
        myMes = ObterDefault("DataPadrao")
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        FormataListagem()
        propOperacao = 2 '--- Operacao de Compra
        '
        AddHandler cmbOperacao.SelectedIndexChanged, AddressOf Handler_GetList
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
        '
    End Sub
    '
    Private Sub PreencheComboOperacao()
        Dim db As New TransacaoBLL
        Dim dtOp As New DataTable
        '
        Try
            dtOp = db.Get_Operacao_DT(TransacaoItemBLL.EnumMovimento.ENTRADA)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
        With cmbOperacao
            .DataSource = dtOp
            .ValueMember = "IdOperacao"
            .DisplayMember = "Operacao"
        End With
    End Sub
    '
    '--- OBTEM A NOVA LISTAGEM SOURCE E ALTERA O DATAGRID
    Private Sub GetList_AlteraListagem()
        '
        Select Case _Operacao
            Case 2 '--- OPERACAO DE COMPRA
                GetList_Compra()
                PreencheColunas_Compra()
            Case 3 '--- OPERACAO DE SIMPLES ENTRADA
                GetList_Simples()
                PreencheColunas_Simples()
            Case 5 '--- OPERACAO DE DEVOLUCAO DE VENDA
                GetList_Devolucao()
                PreencheColunas_Devolucao()
            Case 7 '--- CONSIGNACAO DE ENTRADA
                GetList_Consignacao()
                PreencheColunas_Consignacao()
        End Select
        '
    End Sub
    '
    Private Sub GetList_Compra()
        '
        Dim cBLL As New CompraBLL
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                SourceList = cBLL.GetCompraLista_Procura(Obter_FilialPadrao)
            Else
                Dim dtInicial As Date = Utilidades.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = Utilidades.LastDayOfMonth(myMes)
                '
                SourceList = cBLL.GetCompraLista_Procura(Obter_FilialPadrao, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = SourceList
            '
        Catch ex As Exception
            MessageBox.Show("Em erro ao obter a lista de Operações de Compra..." & vbNewLine &
            ex.Message, "Falha no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub GetList_Simples()
        '
        Dim sBLL As New SimplesMovimentacaoBLL
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                SourceList = sBLL.GetSimplesEntradaLista_Procura(Obter_FilialPadrao)
            Else
                Dim dtInicial As Date = Utilidades.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = Utilidades.LastDayOfMonth(myMes)
                '
                SourceList = sBLL.GetSimplesEntradaLista_Procura(Obter_FilialPadrao, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = SourceList
            '
        Catch ex As Exception
            MessageBox.Show("Em erro ao obter a lista de Operações de Simples Entradas..." & vbNewLine &
            ex.Message, "Falha no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub GetList_Devolucao()
        SourceList = Nothing
        dgvListagem.DataSource = Nothing
    End Sub
    '
    Private Sub GetList_Consignacao()
        SourceList = Nothing
        dgvListagem.DataSource = Nothing
    End Sub
    '
#End Region
    '
#Region "LISTAGEM CONFIGURAÇÃO"
    '
    Private Sub FormataListagem()
        '
        dgvListagem.AutoGenerateColumns = False
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
        '
    End Sub
    '
    Private Sub PreencheColunas_Compra()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUNA REG
        dgvListagem.Columns.Add("IDCompra", "Reg.")
        With dgvListagem.Columns("IDCompra")
            .DataPropertyName = "IDCompra"
            .Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA DATACOMPRA
        dgvListagem.Columns.Add("CompraData", "Data")
        With dgvListagem.Columns("CompraData")
            .DataPropertyName = "TransacaoData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (2) COLUNA NOME
        dgvListagem.Columns.Add("CadastroNome", "Fornecedor")
        With dgvListagem.Columns("CadastroNome")
            .DataPropertyName = "Cadastro"
            .Width = 400
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA VALOR
        dgvListagem.Columns.Add("TotalCompra", "Valor")
        With dgvListagem.Columns("TotalCompra")
            .DataPropertyName = "TotalCompra"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (4) COLUNA COBRANCA TIPO
        dgvListagem.Columns.Add("CobrancaTipoTexto", "Cobrança")
        With dgvListagem.Columns("CobrancaTipoTexto")
            .DataPropertyName = "CobrancaTipoTexto"
            .Width = 120
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (5) COLUNA IMAGEM SITUACAO
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .HeaderText = "Sit."
            .Resizable = False
            .Width = 50
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (6) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("Situacao", "Situação")
        With dgvListagem.Columns("Situacao")
            .DataPropertyName = "IDSituacao"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
    End Sub
    '
    Private Sub PreencheColunas_Simples()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUNA REG
        dgvListagem.Columns.Add("IDTransacao", "Reg.")
        With dgvListagem.Columns("IDTransacao")
            .DataPropertyName = "IDTransacao"
            .Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA TRANSACAODATA
        dgvListagem.Columns.Add("TransacaoData", "Data")
        With dgvListagem.Columns("TransacaoData")
            .DataPropertyName = "TransacaoData"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (2) COLUNA PESSOADESTINO
        dgvListagem.Columns.Add("PessoaDestino", "Filial Destino")
        With dgvListagem.Columns("PessoaDestino")
            .DataPropertyName = "PessoaDestino"
            .Width = 300
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA PESSOAORIGEM
        dgvListagem.Columns.Add("PessoaOrigem", "Filial Origem")
        With dgvListagem.Columns("PessoaOrigem")
            .DataPropertyName = "PessoaOrigem"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA VALORTOTAL
        dgvListagem.Columns.Add("ValorTotal", "Total")
        With dgvListagem.Columns("ValorTotal")
            .DataPropertyName = "ValorTotal"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (5) COLUNA IMAGEM SITUACAO
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .HeaderText = "Sit."
            .Resizable = False
            .Width = 50
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (6) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("Situacao", "Sit")
        With dgvListagem.Columns("Situacao")
            .HeaderText = "Sit."
            .DataPropertyName = "IDSituacao"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
    End Sub
    '
    Private Sub PreencheColunas_Devolucao()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
    End Sub
    '
    Private Sub PreencheColunas_Consignacao()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
    End Sub
    '
    Private Sub Handler_GetList(sender As Object, e As EventArgs) ' HANDLER cmbOpercao.SelectedIndexChanged
        '
        propOperacao = cmbOperacao.SelectedValue
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
            lbl1.Text = dgvListagem.Columns(0).HeaderText
            lbl2.Text = dgvListagem.Columns(1).HeaderText
            lbl3.Text = dgvListagem.Columns(2).HeaderText
            '
            ' coluna 4
            lbl4.Text = dgvListagem.Columns(3).HeaderText
            r = dgvListagem.GetCellDisplayRectangle(3, 0, False)
            lbl4.Width = r.Width
            lbl4.Location = New Point(r.X, lbl4.Location.Y)
            '
            ' column 5
            lbl5.Text = dgvListagem.Columns(4).HeaderText
            r = dgvListagem.GetCellDisplayRectangle(4, 0, False)
            lbl5.Width = r.Width
            lbl5.Location = New Point(r.X, lbl5.Location.Y)
            '
            ' column 6 - Column SIT
            lbl6.Text = dgvListagem.Columns(5).HeaderText
            r = dgvListagem.GetCellDisplayRectangle(5, 0, False)
            lbl6.Width = r.Width
            lbl6.Location = New Point(r.X, lbl6.Location.Y)
            lbl6.TextAlign = ContentAlignment.MiddleCenter
            '
        Catch ex As Exception
            lbl1.Text = ""
            lbl2.Text = ""
            lbl3.Text = ""
            lbl4.Text = ""
            lbl5.Text = ""
            lbl6.Text = ""
        End Try
        '
    End Sub
    '
    '
    '--- FILTAR LISTAGEM 
    Private Sub txtProcura_TextChanged_Venda(sender As Object, e As EventArgs) Handles txtProcura.TextChanged
        FiltrarListagem()
    End Sub
    '
    Private Sub FiltrarListagem()
        Select Case propOperacao
            Case 1 '--- VENDA
                dgvListagem.DataSource = DirectCast(SourceList, List(Of clVenda)).FindAll(AddressOf FindCadastro)
            Case 4 '--- SIMPLES SAIDA
                dgvListagem.DataSource = DirectCast(SourceList, List(Of clSimplesSaida)).FindAll(AddressOf FindCadastro)
        End Select

    End Sub
    '
    Private Function FindCadastro(ByVal v As clVenda) As Boolean
        '
        If (v.Cadastro.ToLower Like "*" & txtProcura.Text.ToLower & "*") Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    Private Function FindCadastro(ByVal s As clSimplesSaida) As Boolean
        '
        If (s.PessoaDestino.ToLower Like "*" & txtProcura.Text.ToLower & "*") Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        '
        '--- altera a IMAGEM da coluna 5
        If e.ColumnIndex = 5 Then '--- coluna Imagem Situação
            Dim sit As Integer
            '
            Select Case propOperacao
                Case 2 '--- COMPRA
                    sit = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clCompra).IDSituacao
                Case 3 '--- SIMPLES ENTRADA
                    sit = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clSimplesEntrada).IDSituacao
                Case 5 '--- DEVOLUCAO DE VENDA

                Case 7 '--- CONSIGNACAO DE ENTRADA

            End Select
            '
            Select Case sit
                Case 1
                    e.Value = ImgInativo
                Case 2
                    e.Value = ImgAtivo
                Case 3
                    e.Value = ImgLock
            End Select
        End If
        '
    End Sub
    '
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    Private Sub btnEscolher_Click(sender As Object, e As EventArgs) Handles btnEscolher.Click
        '
        If dgvListagem.Rows.Count = 0 OrElse dgvListagem.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione uma OPERAÇÃO DE ENTRADA antes de pressionar ESCOLHER...",
                            "Escolher Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Focus()
            Exit Sub
        End If
        '
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Select Case cmbOperacao.SelectedValue
                Case 2 ' COMPRAS
                    Dim _cmp As clCompra = dgvListagem.SelectedRows(0).DataBoundItem
                    '
                    Dim frm As New frmCompra(_cmp) With {
                        .MdiParent = frmPrincipal,
                        .StartPosition = FormStartPosition.CenterScreen
                    }
                    Close()
                    frm.Show()
                    ' 
                Case 3 ' SIMPLES ENTRADA
                    '
                    Dim _sim As clSimplesEntrada = dgvListagem.SelectedRows(0).DataBoundItem
                    '
                    Dim frm As New frmSimplesEntrada(_sim) With {
                        .MdiParent = frmPrincipal,
                        .StartPosition = FormStartPosition.CenterScreen
                    }
                    Close()
                    frm.Show()
                    ' 
                Case 5 ' DEVOLUÇÃO DE VENDA
                    MsgBox("Operação de Entrada: DEVOLUÇÃO DE VENDA, ainda não foi implementada")
                Case 7 ' CONSIGNAÇÃO DE ENTRADA
                    MsgBox("Operação de Entrada: CONSIGNAÇÃO DE ENTRADA, ainda não foi implementada")

            End Select
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir o registro de Saída..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub dgvListagem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListagem.CellDoubleClick
        btnEscolher_Click(New Object, New EventArgs)
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    '--- SELECIONAR ITEM QUANDO PRESSIONA A TECLA (ENTER)
    Private Sub dgvListagem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListagem.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            '
            btnEscolher_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB)
    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProcura.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLE DO PERÍODO"
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
        '--- obtem a nova listagem source e altera o DataGrid
        GetList_AlteraListagem()
        AlteraEtiquetas()
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
#End Region
    '
#Region "TRATAMENTO VISUAL"
    Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlVenda.Paint
        '
        Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, e.ClipRectangle)
        '
    End Sub
#End Region
    '
End Class
