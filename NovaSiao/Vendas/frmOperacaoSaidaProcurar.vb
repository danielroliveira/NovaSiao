Imports CamadaBLL
Imports CamadaDTO
Imports System.Drawing.Drawing2D
'
Public Class frmOperacaoSaidaProcurar
    '
    Private SourceList As Object
    Private ImgVndAtivo As Image = My.Resources.accept
    Private ImgVndInativo As Image = My.Resources.block
    Private ImgVndLock As Image = My.Resources.lock
    Private _myMes As Date
    Private _Operacao As Byte
    '
    Private Property myMes() As DateTime
        Get
            Return _myMes
        End Get
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
            AlteraEtiquetas()
            '
        End Set
        '
    End Property
    '
#Region "EVENTO LOAD"
    '
    Sub New(Optional Operacao As TransacaoBLL.EnumOperacao = 1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PreencheComboOperacao(Operacao)
        myMes = ObterDefault("DataPadrao")
        lblPeriodo.Text = Format(myMes, "MMMM | yyyy")
        FormataListagem()
        propOperacao = Operacao '--- 1:Operacao de Venda
        '
    End Sub
    '
    '--- EVENTO LOAD
    Private Sub frmOperacaoSaidaProcurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- define a posicao do pnlMes
        pnlMes.Location = New Point(636, 124)
        '
        AddHandler cmbOperacao.SelectedIndexChanged, AddressOf Handler_GetList
        AddHandler dtMes.DateChanged, AddressOf dtMes_DateChanged
        '
        '--- repetir execucao para garantir a exibicao das etiquetas
        AlteraEtiquetas()
        '
    End Sub
    '
    '--- PREECHE COMBO OPERACAO
    Private Sub PreencheComboOperacao(Optional myDefault As Byte = 1)
        '
        Dim db As New TransacaoBLL
        Dim dtOp As New DataTable
        '
        Try
            dtOp = db.Get_Operacao_DT(TransacaoItemBLL.EnumMovimento.SAIDA)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
        With cmbOperacao
            .DataSource = dtOp
            .ValueMember = "IdOperacao"
            .DisplayMember = "Operacao"
            .SelectedValue = myDefault
        End With
        '
    End Sub
    '
    '--- OBTEM A NOVA LISTAGEM SOURCE E ALTERA O DATAGRID
    Private Sub GetList_AlteraListagem()
        '
        Select Case _Operacao
            Case 1 '--- OPERACAO DE VENDA
                dgvListagem.Columns.Clear()
                GetList_Venda()
                PreencheColunas_Venda()
                '
                '--- altera o text do btnNovo
                btnNovo.Text = "Venda A Vista"
                btnNovo.Size = New Size(177, 41)
                btnNovo2.Visible = True
                '
            Case 4 '--- OPERACAO DE SIMPLES SAIDA
                GetList_Simples()
                PreencheColunas_Simples()
                '
                '--- altera o text do btnNovo
                btnNovo.Text = "Simples Saída"
                btnNovo.Size = New Size(177, 41)
                btnNovo2.Visible = False
                '
            Case 6 '--- OPERACAO DE DEVOLUCAO DE COMPRA
                GetList_Devolucao()
                PreencheColunas_Devolucao()
                '
                '--- altera o text do btnNovo
                btnNovo.Text = "Devolução de Compra"
                btnNovo.Size = New Size(195, 41)
                btnNovo2.Visible = False
                '
            Case 8 '--- OPERACAO DE DEVOLUCAO DE CONSIGNACAO
                GetList_Consignacao()
                PreencheColunas_Consignacao()
                '
                '--- altera o text do btnNovo
                btnNovo.Text = "Devolução de Consignação"
                btnNovo.Size = New Size(230, 41)
                btnNovo2.Visible = False
                '
        End Select
        '
    End Sub
    '
    Private Sub GetList_Venda()
        '
        Dim vndBLL As New VendaBLL
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                SourceList = vndBLL.GetVendaLista_Procura(Obter_FilialPadrao)
            Else
                Dim dtInicial As Date = Utilidades.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = Utilidades.LastDayOfMonth(myMes)
                '
                SourceList = vndBLL.GetVendaLista_Procura(Obter_FilialPadrao, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = SourceList
            '
        Catch ex As Exception
            MessageBox.Show("Em erro ao obter a lista de Operações de Venda..." & vbNewLine &
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
                SourceList = sBLL.GetSimplesSaidaLista_Procura(Obter_FilialPadrao)
            Else
                Dim dtInicial As Date = Utilidades.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = Utilidades.LastDayOfMonth(myMes)
                '
                SourceList = sBLL.GetSimplesSaidaLista_Procura(Obter_FilialPadrao, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = SourceList
            '
        Catch ex As Exception
            MessageBox.Show("Em erro ao obter a lista de Operações de Simples Saídas..." & vbNewLine &
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
        '
        Dim dBLL As New DevolucaoSaidaBLL
        '
        '--- consulta o banco de dados
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- verifica o filtro das datas
            If chkPeriodoTodos.Checked = True Then
                SourceList = dBLL.GetDevolucaoLista_Procura(Obter_FilialPadrao)
            Else
                Dim dtInicial As Date = Utilidades.FirstDayOfMonth(myMes)
                Dim dtFinal As Date = Utilidades.LastDayOfMonth(myMes)
                '
                SourceList = dBLL.GetDevolucaoLista_Procura(Obter_FilialPadrao, dtInicial, dtFinal)
            End If
            '
            dgvListagem.DataSource = SourceList
            '
        Catch ex As Exception
            MessageBox.Show("Em erro ao obter a lista de Operações de Devolução de Saída..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
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
    Private Sub PreencheColunas_Venda()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUNA REG
        dgvListagem.Columns.Add("IDVenda", "Reg.")
        With dgvListagem.Columns("IDVenda")
            .DataPropertyName = "IDVenda"
            .Width = 50
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "0000"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA DATAVENDA
        dgvListagem.Columns.Add("VendaData", "Data")
        With dgvListagem.Columns("VendaData")
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
        dgvListagem.Columns.Add("CadastroNome", "Nome / Razão Social")
        With dgvListagem.Columns("CadastroNome")
            .DataPropertyName = "Cadastro"
            .Width = 300
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA VENDEDOR
        dgvListagem.Columns.Add("Apelido", "Vendedor")
        With dgvListagem.Columns("Apelido")
            .DataPropertyName = "ApelidoFuncionario"
            .Width = 150
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA VALOR
        dgvListagem.Columns.Add("TotalVenda", "Valor Total")
        With dgvListagem.Columns("TotalVenda")
            .DataPropertyName = "TotalVenda"
            .Width = 100
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
        End With
        '
        ' (5) COLUNA COBRANCA TIPO
        dgvListagem.Columns.Add("CobrancaTipo", "Pagamento")
        With dgvListagem.Columns("CobrancaTipo")
            .DataPropertyName = "CobrancaTipo"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (6) COLUNA IMAGEM SITUACAO
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .HeaderText = "Sit."
            .Resizable = False
            .Width = 50
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (7) COLUNA SITUAÇÃO
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
        dgvListagem.Columns.Add("ValorTotal", "Valor Total")
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
        ' (5) COLUNA COBRANCA TIPO
        dgvListagem.Columns.Add("CobrancaTipo", "Pagamento")
        With dgvListagem.Columns("CobrancaTipo")
            .DataPropertyName = "CobrancaTipo"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (6) COLUNA IMAGEM SITUACAO
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .HeaderText = "Sit."
            .Resizable = False
            .Width = 50
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (7) COLUNA SITUAÇÃO
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
    Private Sub PreencheColunas_Devolucao()
        '
        '--- limpa as colunas do datagrid
        dgvListagem.Columns.Clear()
        '
        ' (0) COLUNA REG
        dgvListagem.Columns.Add("IDDevolucao", "Reg.")
        With dgvListagem.Columns("IDDevolucao")
            .DataPropertyName = "IDDevolucao"
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
        ' (2) COLUNA FORNECEDOR
        dgvListagem.Columns.Add("Fornecedor", "Fornecedor")
        With dgvListagem.Columns("Fornecedor")
            .DataPropertyName = "Fornecedor"
            .Width = 350
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (3) COLUNA VALORTOTAL
        dgvListagem.Columns.Add("ValorTotal", "Valor Total")
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
        ' (4) COLUNA ENVIADA
        Dim colImageEnviada As New DataGridViewImageColumn
        With colImageEnviada
            .HeaderText = "Enviada"
            .Resizable = False
            .Width = 80
        End With
        dgvListagem.Columns.Add(colImageEnviada)
        '
        ' (5) COLUNA CREDITADA
        Dim colImageCreditada As New DataGridViewImageColumn
        With colImageCreditada
            .HeaderText = "Creditada"
            .Resizable = False
            .Width = 80
        End With
        dgvListagem.Columns.Add(colImageCreditada)
        '
        ' (6) COLUNA IMAGEM SITUACAO
        Dim colImage As New DataGridViewImageColumn
        With colImage
            .HeaderText = "Sit."
            .Resizable = False
            .Width = 80
        End With
        dgvListagem.Columns.Add(colImage)
        '
        ' (7) COLUNA SITUAÇÃO
        dgvListagem.Columns.Add("Situacao", "Situação")
        With dgvListagem.Columns("Situacao")
            .DataPropertyName = "IDSituacao"
            .Width = 0
            .Resizable = DataGridViewTriState.False
            .Visible = False
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
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
        Dim r As New Rectangle
        '
        Try
            lbl1.Text = dgvListagem.Columns(0).HeaderText
            lbl2.Text = dgvListagem.Columns(1).HeaderText
            lbl3.Text = dgvListagem.Columns(2).HeaderText
            '
            lbl4.Text = dgvListagem.Columns(3).HeaderText
            r = dgvListagem.GetCellDisplayRectangle(3, 0, False)
            lbl4.Width = r.Width
            lbl4.Location = New Point(r.X, lbl4.Location.Y)
            lbl4.TextAlign = ContentAlignment.MiddleCenter
            '
            lbl5.Text = dgvListagem.Columns(4).HeaderText
            r = dgvListagem.GetCellDisplayRectangle(4, 0, False)
            lbl5.Width = r.Width
            lbl5.Location = New Point(r.X, lbl5.Location.Y)
            lbl5.TextAlign = ContentAlignment.MiddleCenter
            '
            lbl6.Text = dgvListagem.Columns(5).HeaderText
            r = dgvListagem.GetCellDisplayRectangle(5, 0, False)
            lbl6.Width = r.Width
            lbl6.Location = New Point(r.X, lbl6.Location.Y)
            lbl6.TextAlign = ContentAlignment.MiddleCenter
            '
            lbl7.Text = dgvListagem.Columns(6).HeaderText
            r = dgvListagem.GetCellDisplayRectangle(6, 0, False)
            lbl7.Width = r.Width
            lbl7.Location = New Point(r.X, lbl7.Location.Y)
            lbl7.TextAlign = ContentAlignment.MiddleCenter
            '
        Catch ex As Exception
            lbl1.Text = ""
            lbl2.Text = ""
            lbl3.Text = ""
            lbl4.Text = ""
            lbl5.Text = ""
            lbl6.Text = ""
            lbl7.Text = ""
        End Try
        '
    End Sub
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
            Case 6 '--- DEVOLUCAO DE COMPRA
                dgvListagem.DataSource = DirectCast(SourceList, List(Of clDevolucaoSaida)).FindAll(AddressOf FindCadastro)
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
    Private Function FindCadastro(ByVal d As clDevolucaoSaida) As Boolean
        '
        If (d.Fornecedor.ToLower Like "*" & txtProcura.Text.ToLower & "*") Then
            Return True
        Else
            Return False
        End If
        '
    End Function
    '
    '--- FORMATA O DATAGRID COM TEXTO E IMAGENS
    Private Sub dgvListagem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvListagem.CellFormatting
        ' 
        If propOperacao = 1 Then '--- SE FOR VENDA
            '
            If e.ColumnIndex = 5 Then '--- coluna Cobrança tipo
                Select Case e.Value
                    Case 0
                        e.Value = "Sem Cobrança"
                    Case 1
                        e.Value = "À Vista"
                    Case 2
                        e.Value = "À Prazo"
                End Select
            End If
            '
            If e.ColumnIndex = 2 Then '--- coluna Razão Social
                If IsDBNull(e.Value) Then
                    e.Value = "VENDA À VISTA"
                End If
            End If
            '
        End If
        '
        If e.ColumnIndex = 4 AndAlso propOperacao = 6 Then '--- Se for DEVOLUCAO
            '--- altera a IMAGEM da coluna 4
            Select Case DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clDevolucaoSaida).Enviada
                Case 0
                    e.Value = ImgVndInativo
                Case 1
                    e.Value = ImgVndAtivo
            End Select
            '
        End If
        '
        If e.ColumnIndex = 5 AndAlso propOperacao = 6 Then '--- Se for DEVOLUCAO
            '--- altera a IMAGEM da coluna 4
            Select Case DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clDevolucaoSaida).Creditada
                Case 0
                    e.Value = ImgVndInativo
                Case 1
                    e.Value = ImgVndAtivo
            End Select
            '
        End If
        '
        '--- altera a IMAGEM da coluna 6
        If e.ColumnIndex = 6 Then '--- coluna Imagem Situação
            Dim sit As Integer
            '
            Select Case propOperacao
                Case 1 '--- VENDA
                    sit = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clVenda).IDSituacao
                Case 4 '--- SIMPLES SAIDA
                    sit = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clSimplesSaida).IDSituacao
                Case 6 '--- DEVOLUCAO DE COMPRA
                    sit = DirectCast(dgvListagem.Rows(e.RowIndex).DataBoundItem, clDevolucaoSaida).IDSituacao
                Case 8 '--- DEVOLUCAO DE CONSIGNACAO

            End Select
            '
            Select Case sit
                Case 1
                    e.Value = ImgVndInativo
                Case 2
                    e.Value = ImgVndAtivo
                Case 3
                    e.Value = ImgVndLock
            End Select
            '
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
            MessageBox.Show("Selecione um Operação de Saída antes de pressionar ESCOLHER...",
                            "Escolher Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvListagem.Focus()
            Exit Sub
        End If
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Select Case propOperacao
                Case 1 ' VENDAS
                    Dim _vnd As clVenda = dgvListagem.SelectedRows(0).DataBoundItem
                    '
                    If _vnd.CobrancaTipo = 1 Then ' VENDA À VISTA
                        Dim frm As New frmVendaVista(_vnd) With {
                            .MdiParent = frmPrincipal,
                            .StartPosition = FormStartPosition.CenterScreen
                        }
                        Close()
                        frm.Show()
                    ElseIf _vnd.CobrancaTipo = 2 Then ' VENDA PARCELADA
                        Dim frm As New frmVendaPrazo(_vnd) With {
                            .MdiParent = frmPrincipal,
                            .StartPosition = FormStartPosition.CenterScreen
                        }
                        Close()
                        frm.Show()
                    End If
                Case 4 'SIMPLES SAÍDA
                    Dim _sim As clSimplesSaida = dgvListagem.SelectedRows(0).DataBoundItem
                    '
                    Dim frm As New frmSimplesSaida(_sim) With {
                        .MdiParent = frmPrincipal,
                        .StartPosition = FormStartPosition.CenterScreen
                    }
                    Close()
                    frm.Show()
                '
                Case 6 ' DEVOLUÇÃO DE COMPRA
                    Dim _dev As clDevolucaoSaida = dgvListagem.SelectedRows(0).DataBoundItem
                    '
                    Dim frm As New frmDevolucaoSaida(_dev) With {
                        .MdiParent = frmPrincipal,
                        .StartPosition = FormStartPosition.CenterScreen
                    }
                    Close()
                    frm.Show()
                '
                Case 8 'DEVOLUÇÃO DE CONSIGNAÇÃO


            End Select
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Select Case propOperacao
                Case 1 ' VENDAS
                    '
                    Visible = False
                    '
                    Dim v As New AcaoGlobal
                    Dim newVenda As Object = v.VendaAVista_Nova
                    '
                    If IsNothing(newVenda) Then
                        Visible = True
                        Return
                    End If
                    '
                    Close()
                    Dim f As New frmVendaVista(newVenda)
                    f.Show()
                    '
                Case 4 'SIMPLES SAÍDA
                    MessageBox.Show("Não implementado ainda")
                Case 6 ' DEVOLUÇÃO DE COMPRA
                    MessageBox.Show("Não implementado ainda")
                Case 8 'DEVOLUÇÃO DE CONSIGNAÇÃO
                    MessageBox.Show("Não implementado ainda")
            End Select
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao criar uma nova operação de Saída..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub btnNovo2_Click(sender As Object, e As EventArgs) Handles btnNovo2.Click
        '
        Dim v As New AcaoGlobal
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Visible = False
            Dim newVenda As Object = v.VendaPrazo_Nova
            '
            If IsNothing(newVenda) Then
                Visible = True
                Exit Sub
            End If
            '
            Close()
            Dim f As New frmVendaPrazo(newVenda)
            f.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inserir Nova Venda Prazo..." & vbNewLine &
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
        '
    End Sub
    '
    Private Sub lblPerido_Click(sender As Object, e As EventArgs) Handles lblPeriodo.Click
        pnlMes.Visible = True
        dtMes.Focus()
    End Sub
    '
    Private Sub pnlMes_Leave(sender As Object, e As EventArgs) Handles dtMes.LostFocus ', pnlMes.MouseLeave
        pnlMes.Visible = False
    End Sub
    '
#End Region
    '
#Region "TRATAMENTO VISUAL"
    Private Sub pnlVenda_Paint(sender As Object, e As PaintEventArgs) Handles pnlVenda.Paint
        '
        Try
            Dim brush As Brush = New LinearGradientBrush(e.ClipRectangle, Color.LightSteelBlue, Color.FromArgb(100, Color.SlateGray), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, e.ClipRectangle)
        Catch ex As Exception
            Return
        End Try
        '
    End Sub
    '
#End Region
    '
End Class
