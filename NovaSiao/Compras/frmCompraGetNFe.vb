Imports CamadaDTO
Imports CamadaBLL
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class frmCompraGetNFe
    '
    Private NotaNFe As TNfeProc
    Private ItensNFe As New List(Of clNFeItem)
    Private bindItens As New BindingSource
    Private FornecedorNFe As New clFornecedor
    Private IDTipoPadrao As Integer? = Nothing
    Private IDSubTipoPadrao As Integer? = Nothing
    Private IDFabricantePadrao As Integer? = Nothing
    Private RGTipoAnterior As Integer? = Nothing
    Private _propEstagio As Byte
    Private ProdFornBLL As New ProdutoFornecedorBLL
    '
    Private Class clNFeItem
        Inherits TNFeInfNFeDetProd
        '
        Property IDProduto As Integer?
        Property RGProduto As Integer?
        Property Produto As String
        Property PCompra As Double
        Property PVenda As Double
        Property DescontoCompra As Double
        Property CST As String
        Property DescontoNFe As Double
        '
    End Class
    '
#Region "NEW | OPEN | PROPS"
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        propEstagio = 1
        FormataDataGrid()
        '
    End Sub
    '
    Private Property propEstagio As Byte
        Get
            Return _propEstagio
        End Get
        Set(value As Byte)
            _propEstagio = value
            '
            Select Case value
                Case = 1 '--- ESTAGIO INICIAL
                    btnCorrelacao.Enabled = False
                    btnSalvarCompra.Enabled = False
                Case = 2 '--- XML OBTIDA
                    btnCorrelacao.Enabled = True
                    btnSalvarCompra.Enabled = False
                Case = 3 '--- CORRELACAO PESQUISADA
                    btnCorrelacao.Enabled = False
                    btnSalvarCompra.Enabled = False
                Case = 4 '--- PRONTO PARA INSERIR
                    btnCorrelacao.Enabled = False
                    btnSalvarCompra.Enabled = True
            End Select
            '
        End Set
    End Property
    '
#End Region '/ NEW | OPEN | PROPS
    '
#Region "DATAGRID FUNCTIONS"
    '
    Private Sub FormataDataGrid()
        '
        '--- limpa as colunas do datagrid
        dgvItens.Columns.Clear()
        dgvItens.AutoGenerateColumns = False
        '
        ' altera as propriedades importantes
        dgvItens.MultiSelect = False
        dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvItens.ColumnHeadersVisible = True
        dgvItens.AllowUserToResizeRows = False
        dgvItens.AllowUserToResizeColumns = False
        dgvItens.RowHeadersVisible = True
        dgvItens.RowHeadersWidth = 30
        dgvItens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvItens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvItens.StandardTab = True
        '
        '--- formata as colunas do datagrid
        FormataColunas()
        '
    End Sub
    '
    Private Sub FormataColunas()
        '
        ' (0) COLUNA IDProdutoOrigem
        With clnIDProdutoNfe
            .DataPropertyName = "cProd"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.DefaultCellStyle.Font = New Font("Arial Narrow", 12)
        End With
        '
        ' (1) COLUNA PRODUTO
        With clnProdutoNfe
            .DataPropertyName = "xProd"
            .Width = 375
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (2) COLUNA QUANTIDADE
        With clnQuantidadeNFe
            .DataPropertyName = "qCom"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        ' (3) COLUNA PRECO
        With clnPrecoNfe
            .DataPropertyName = "vUnCom"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (4) COLUNA DESCONTO
        With clnDescontoNfe
            .DataPropertyName = "DescontoNFe"
            .Width = 80
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "0.00"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (5) COLUNA TOTAL
        With clnTotalNfe
            .DataPropertyName = "vProd"
            .Width = 90
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "C"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (6) COLUNA IDProdutoOrigem
        With clnRGProduto
            .DataPropertyName = "RGProduto"
            .Width = 60
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .DefaultCellStyle.Format = "0000"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        '
        ' (1) COLUNA PRODUTO ENCONTRADO
        With clnProduto
            .DataPropertyName = "Produto"
            .Width = 250
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        dgvItens.Columns.AddRange({clnIDProdutoNfe, clnProdutoNfe, clnQuantidadeNFe, clnPrecoNfe,
                                   clnDescontoNfe, clnTotalNfe, clnRGProduto, clnProduto})
        '
    End Sub
    '
    Private Sub dgvItens_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvItens.CellFormatting
        '
        If e.ColumnIndex = 0 Then
            '
            Dim IDProduto As Integer? = If(IsNothing(dgvItens.Rows(e.RowIndex).DataBoundItem), Nothing, dgvItens.Rows(e.RowIndex).DataBoundItem.IDProduto)
            '
            If IsNothing(IDProduto) Then
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                e.CellStyle.ForeColor = Color.Black
            Else
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                dgvItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Firebrick
                e.CellStyle.ForeColor = Color.Red
            End If
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "IMPORT NFE XML"
    '
    '--- READ AND IMPORT ALL ITENS OF NFE XML 
    '----------------------------------------------------------------------------------
    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If ObterXML() Then
                dgvItens.DataSource = Nothing
                dgvItens.Rows.Clear()
                ImportItensNFe()
                bindItens.DataSource = ItensNFe
                dgvItens.DataSource = bindItens
                ImportFornecedorNFe()
                propEstagio = 2
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter os Dados do aquivo NFe XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            propEstagio = 1
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- GET XML FILE, CONVERT AND DESERIALIZE IN NFE CLASS
    '----------------------------------------------------------------------------------
    Private Function ObterXML() As Boolean
        '
        Try
            '
            '--- pergunta o nome do arquivo
            Dim arquivoXML As New OpenFileDialog
            With arquivoXML
                .AddExtension = True
                .DefaultExt = ".xml"
                .DereferenceLinks = True
                .Filter = "xml files (*.xml)|*.xml"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                .Title = "Informe qual é o arquivo de importação XML da NFe compra/entrada..."
                .Multiselect = False
                .RestoreDirectory = True
                .ShowDialog()
            End With
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If String.IsNullOrEmpty(arquivoXML.FileName) Then Return False
            '
            Dim ser As New XmlSerializer(GetType(TNfeProc))
            Dim textReader As TextReader = New StreamReader(arquivoXML.FileName)
            Dim reader As New XmlTextReader(textReader)
            '
            reader.Read()
            NotaNFe = ser.Deserialize(reader)
            '
            '--- RETURN
            Return True
            '
        Catch ex As Exception
            Throw ex
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
    '--- IMPORTAR OS ITENS DE PRODUTOS DA NFE XML
    '----------------------------------------------------------------------------------
    Private Sub ImportItensNFe()
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If IsNothing(NotaNFe) Then
                Throw New AppException("Ainda não há NFe, ou é nula...")
            End If
            '
            ItensNFe.Clear()
            Dim ItensXML = NotaNFe.NFe.infNFe.det
            '
            For Each p In ItensXML
                Dim clp As New clNFeItem
                '
                '--- COD DO PRPODUTO
                If IsNumeric(p.prod.cProd) Then
                    clp.cProd = CLng(p.prod.cProd)
                Else
                    clp.cProd = p.prod.cProd
                End If
                '
                clp.xProd = p.prod.xProd
                clp.qCom = CInt(p.prod.qCom.Replace(".", ","))
                clp.vUnCom = Format(CDbl(p.prod.vUnCom.Replace(".", ",")), "#,##0.00")
                clp.vProd = p.prod.vProd.Replace(".", ",")
                clp.cEAN = p.prod.cEAN
                clp.CFOP = p.prod.CFOP
                clp.NCM = p.prod.NCM

                If TypeOf p.imposto.Items(0).item Is TNFeInfNFeDetImpostoICMSICMSSN102 Then
                    clp.CST = p.imposto.Items(0).item.CSOSN
                ElseIf TypeOf p.imposto.Items(0).item Is TNFeInfNFeDetImpostoICMSICMS40 Then
                    clp.CST = p.imposto.Items(0).item.CST
                End If
                '
                '--- DESCONTO DO PRODUTO
                If Not IsNothing(p.prod.vDesc) Then
                    clp.vDesc = p.prod.vDesc.Replace(".", ",")
                    Dim pDesc As Double = p.prod.vDesc.Replace(".", ",")
                    Dim desc As Double = 100 * (clp.vProd - pDesc) / clp.vProd
                    clp.DescontoNFe = desc
                End If
                '
                ItensNFe.Add(clp)
                '
            Next
            '
            'bindItens.ResetBindings(False)
            '
        Catch ex As Exception
            Throw ex
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    '--- IMPORTAR O FORNECEDOR DA NFE XML
    '----------------------------------------------------------------------------------
    Private Sub ImportFornecedorNFe()
        '
        Try
            '
            If IsNothing(NotaNFe) Then
                Throw New AppException("Ainda não há NFe, ou é nula...")
            End If
            '
            Dim emit As TNFeInfNFeEmit = NotaNFe.NFe.infNFe.emit
            '
            With FornecedorNFe
                .Cadastro = Utilidades.PrimeiraLetraMaiuscula(emit.xNome)
                .NomeFantasia = Utilidades.PrimeiraLetraMaiuscula(emit.xFant)
                .CNPJ = Utilidades.CNPConvert(emit.Item)
                .InscricaoEstadual = emit.IE
                .Endereco = Utilidades.PrimeiraLetraMaiuscula(emit.enderEmit.xLgr) & " " & emit.enderEmit.nro & " " & emit.enderEmit.xCpl
                .Bairro = Utilidades.PrimeiraLetraMaiuscula(emit.enderEmit.xBairro)
                .Cidade = Utilidades.PrimeiraLetraMaiuscula(emit.enderEmit.xMun)
                Dim enumUF As TUf = emit.enderEmit.UF
                .UF = enumUF.ToString
                .CEP = emit.enderEmit.CEP
                Dim telLen As Byte = emit.enderEmit.fone.Trim.Length
                If telLen = 10 Then
                    .TelefoneA = emit.enderEmit.fone.Insert(2, " ")
                Else
                    .TelefoneA = emit.enderEmit.fone
                End If
            End With
            '
            PreencheLabelsFornecedor()
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    Private Sub PreencheLabelsFornecedor()
        '
        lblRazaoSocial.Text = FornecedorNFe.Cadastro
        lblCNPJ.Text = FornecedorNFe.CNPJ
        lblInscricao.Text = FornecedorNFe.InscricaoEstadual
        '
    End Sub
    '
#End Region '/ IMPORT NFE XML
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "CORRELACAO FUNCTIONS"
    '
    Private Sub btnCorrelacao_Click(sender As Object, e As EventArgs) Handles btnCorrelacao.Click
        '
        If ItensNFe.Count = 0 Then
            AbrirDialog("Não há items de produtos obtidos na NFe...",
                        "Nenhum Item", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            Exit Sub
        End If
        '
        Dim acesso As AcessoControlBLL = Nothing
        Dim dbTran As Object = Nothing
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- GET TRANSACAO for don't open new instances of db
            acesso = New AcessoControlBLL
            dbTran = acesso.GetNewAcessoWithTransaction
            '
            '--- LOOKING FOR FORNECEDOR
            '-----------------------------------------------------------------------------
            Dim procForn As clFornecedor = FornecedorFind()
            '
            If Not IsNothing(procForn) AndAlso Not IsNothing(procForn.IDPessoa) Then
                '
                FornecedorNFe.IDPessoa = procForn.IDPessoa
                AbrirDialog("Forncedor encontrado:" & vbCrLf & procForn.Cadastro,
                            "Fornecedor", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
                '
            Else
                '
                AbrirDialog("Um fornecedor correspondente à NFe não pode ser encontrado..." & vbCrLf &
                            "Favor tentar encontrar um fornecedor para inserir a NFe.",
                            "Fornecedor", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                Exit Sub
                '
            End If
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- LOOKING ITENS PRODUTOS
            '----------------------------------------------------------------------------------
            Dim countEncontrados As Integer = 0
            '
            For Each item In ItensNFe
                '
                '--- PERCORRE E ATUALIZA A LISTAGEM
                dgvItens.CurrentCell = dgvItens.Rows(ItensNFe.IndexOf(item)).Cells(0)
                dgvItens.Rows(ItensNFe.IndexOf(item)).Selected = True
                dgvItens.Refresh()
                '
                '--- PROCURA PRODUTO ITEM
                Dim prodEncontrado As clProdutoFornecedorItem = ProdutoFind(item, FornecedorNFe.IDPessoa, dbTran)
                '
                '--- SE ENCOTNTROU UM PRODUTO - PREENCHE A LISTA
                If Not IsNothing(prodEncontrado) Then
                    item.IDProduto = prodEncontrado.IDProduto
                    item.RGProduto = prodEncontrado.RGProduto
                    item.Produto = prodEncontrado.Produto
                    item.PCompra = prodEncontrado.PCompra
                    item.DescontoCompra = prodEncontrado.DescontoCompra
                    countEncontrados += 1
                    '
                    '--- CHECK PRECO COMPRA
                    '----------------------------------------------------------------------------------------------------
                    CheckPrecoDivergente(item, prodEncontrado.PCompra, prodEncontrado.IDProduto)
                    '
                End If
                '
            Next
            '
            '--- EMIT MENSAGE TO USER
            Dim message As String = ""
            '
            If countEncontrados = 0 Then
                message = "Não foram encontrados produtos que se relacionam com essa NFe."
            ElseIf countEncontrados = 1 Then
                message = "Foi encontrado 1 (UM) produto relacionado com a NFe."
            Else
                message = "Foram encontrados " & countEncontrados & " produtos relacionados com a NFe."
            End If
            '
            AbrirDialog(message, "Produtos Encontrados", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            '
            '--- ALTERA O ESTAGIO
            propEstagio = 3
            TryEnableEstagioCompra()
            '
        Catch ex As AppException
            acesso.RollbackAcessoWithTransaction(dbTran)
            AbrirDialog("Uma exceção ocorreu ao Fazer correlação da NFe..." & vbNewLine &
                        ex.Message, "Exceção", frmDialog.DialogType.OK, frmDialog.DialogIcon.Warning)
        Catch ex As Exception
            acesso.RollbackAcessoWithTransaction(dbTran)
            MessageBox.Show("Uma exceção ocorreu ao Fazer correlação da NFe..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '-- CLOSE ACESSO
            acesso.CommitAcessoWithTransaction(dbTran)
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    '--- PROCURA FORNECEDOR
    '----------------------------------------------------------------------------------
    Private Function FornecedorFind() As clFornecedor
        '
        Try
            '
            Dim pBLL As New PessoaBLL
            Dim pessoa As Object = pBLL.ProcurarCNP_Pessoa(FornecedorNFe.CNPJ, PessoaBLL.EnumPessoaGrupo.FORNECEDOR)
            '
            If TypeOf pessoa Is clFornecedor Then
                '
                '--- OPEN FRM FORNECEDOR
                OpenFrmFornecedor(pessoa)
                '
                Return DirectCast(pessoa, clFornecedor)
                '
            ElseIf TypeOf pessoa Is clPessoaJuridica Then
                '
                If AbrirDialog("Não foi encontrado um fornecedor correspondente, porém foi encontrado uma Pessoa Jurídica " &
                               "cadastrada com o mesmo CNPJ:" & vbCrLf & DirectCast(pessoa, clPessoaJuridica).Cadastro & vbCrLf &
                               "Deseja cadastrar essa Pessoa Jurídica como um novo fornecedor?",
                               "Pessoa Jurídica Encontrada",
                               frmDialog.DialogType.SIM_NAO,
                               frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                    '
                    Dim pj As New clPessoaJuridica
                    pj = DirectCast(pessoa, clPessoaJuridica)
                    '
                    '--- PREENCHE OS DADOS AUTOMATICAMENTE
                    Dim newForn As New clFornecedor With {
                        .Cadastro = pj.Cadastro,
                        .NomeFantasia = pj.NomeFantasia,
                        .InscricaoEstadual = pj.InscricaoEstadual,
                        .Endereco = pj.Endereco,
                        .Bairro = pj.Bairro,
                        .Cidade = pj.Cidade,
                        .UF = pj.UF,
                        .CEP = pj.CEP,
                        .TelefoneA = pj.TelefoneA,
                        .TelefoneB = pj.TelefoneB,
                        .Email = pj.Email,
                        .FundacaoData = If(pj.FundacaoData, ""),
                        .ContatoNome = pj.ContatoNome
                        }
                    '
                    '--- OPEN FRM FORNECEDOR
                    OpenFrmFornecedor(newForn)
                    '
                    Return newForn
                    '
                End If
                '
            Else
                If AbrirDialog("Não foi encontrado um fornecedor correspondente " &
                               "cadastrado com o mesmo CNPJ." & vbCrLf &
                               "Deseja cadastrar essa Pessoa Jurídica como um novo fornecedor?" & vbCrLf &
                               FornecedorNFe.Cadastro,
                               "Pessoa Jurídica Encontrada",
                               frmDialog.DialogType.SIM_NAO,
                               frmDialog.DialogIcon.Question) = DialogResult.Yes Then
                    '
                    '--- OPEN FRM FORNECEDOR
                    OpenFrmFornecedor(FornecedorNFe)
                    '
                    Return FornecedorNFe
                    '
                End If
            End If
            '
            Return Nothing
            '
        Catch ex As Exception
            Throw New AppException("Uma exceção ocorreu ao procurar o fornecedor..." & vbNewLine & ex.Message)
        End Try
        '
    End Function
    '
    '--- ABRE O FORM FORNECEDOR
    '----------------------------------------------------------------------------------
    Private Sub OpenFrmFornecedor(fornecedor As clFornecedor)
        '
        Try
            '
            Dim frmF As New frmFornecedor(fornecedor, Me)
            Me.Visible = False
            frmF.ShowDialog()
            '
            If frmF.DialogResult = DialogResult.OK Then
                fornecedor.IDPessoa = frmF.propForn.IDPessoa
            End If
            '
        Catch ex As Exception
            Throw New AppException("Uma exceção ocorreu ao abrir formulário de fornecedores..." & vbNewLine & ex.Message)
        End Try
        '
    End Sub
    '
    '--- PROCURA PRODUTO
    '----------------------------------------------------------------------------------
    Private Function ProdutoFind(item As clNFeItem, IDFornecedor As Integer, dbTran As Object) As clProdutoFornecedorItem
        '
        Try
            '
            Return ProdFornBLL.GetProdFornecedorItem(IDFornecedor, item.cProd, dbTran)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--- SALVA A RELACAO ENTRE ITEM E PRODUTO
    '----------------------------------------------------------------------------------
    Private Function SalvarRelacao(item As clNFeItem) As Boolean
        '
        '--- CHECK IF FORNECEDOR IS DEFINED
        If IsNothing(FornecedorNFe.IDPessoa) OrElse FornecedorNFe.IDPessoa = 0 Then
            AbrirDialog("O Fornecedor ainda não foi correlacionado com a NFe." + vbCrLf +
                        "Favor fazer a correlação antes.",
                        "Fornecedor Desconhecido", frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Exclamation)
            Return False
        End If
        '
        Dim prodFornItem As New clProdutoFornecedorItem With {
            .Cadastro = FornecedorNFe.Cadastro,
            .IDFornecedor = FornecedorNFe.IDPessoa,
            .UltimaEntrada = Today,
            .ApelidoFilial = ObterConfigValorNode("FilialDescricao"),
            .IDFilial = Obter_FilialPadrao(),
            .Produto = item.Produto,
            .IDProduto = item.IDProduto,
            .RGProduto = item.RGProduto,
            .PCompra = Format(CDbl(item.vUnCom.Replace(".", ",")), "#,##0.00"),
            .DescontoCompra = item.DescontoNFe,
            .IDProdutoOrigem = item.cProd,
            .DescricaoOrigem = item.xProd,
            .CodBarrasOrigem = item.cEAN
            }
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim obj As Object = ProdFornBLL.Insert_ProdutoFornecedorItem(prodFornItem)
            '
            If Not obj.GetType Is GetType(Integer) Then
                Throw New Exception(obj.ToString)
            End If
            '
            prodFornItem.IDProdutoFornecedorItem = obj
            Return True
            '
        Catch ex As Exception
            Throw New AppException("Uma exceção ocorreu ao Salvar Registro de Relacionamento..." & vbNewLine &
                                    ex.Message)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
    '--- INSERT NEW PRODUTO INTO LIST
    '----------------------------------------------------------------------------------
    Private Sub InsertNewProdutoIntoList(item As clNFeItem, produto As clProduto)
        '
        '--- AO ESCOLHER UM PRODUTO - PREENCHE A LISTA
        item.IDProduto = produto.IDProduto
        item.RGProduto = produto.RGProduto
        item.Produto = produto.Produto
        item.PCompra = produto.PCompra
        item.DescontoCompra = produto.DescontoCompra
        '
        '--- MESSAGE
        If AbrirDialog("Item relacionado com Produto com sucesso!" & vbCrLf & vbCrLf &
                       "Você deseja GUARDAR/SALVAR essa relação do Fornecedor com o Produto?",
                       "Item Relacionado",
                       frmDialog.DialogType.SIM_NAO,
                       frmDialog.DialogIcon.Question,
                       frmDialog.DialogDefaultButton.First) = DialogResult.Yes Then
            SalvarRelacao(item)
        End If
        '
        TryEnableEstagioCompra()
        '
    End Sub
    '
    Private Sub CheckPrecoDivergente(item As clNFeItem, PrecoCompra As Double, IDProduto As Integer)
        '
        '--- CHECK PRECO DE COMPRA
        '
        Dim ItemPrecoCompra As Double = Format(CDbl(item.vUnCom.Replace(".", ",")), "#,##0.00")
        '
        If PrecoCompra <> Format(CDbl(item.vUnCom.Replace(".", ",")), "#,##0.00") Then
            '
            If AbrirDialog("Novo Preço de Compra na NFe é diferente do atual..." & vbCrLf &
                           "ITEM: " & item.xProd & vbCrLf &
                           "NOVO PREÇO: " & Format(ItemPrecoCompra, "C") & vbCrLf &
                           "Você deseja alterar o Preço de Compra atual para o novo preço?",
                           "Preço Divergente",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question,
                           frmDialog.DialogDefaultButton.First) = DialogResult.Yes Then
                '
                '--- Ampulheta ON
                Cursor = Cursors.WaitCursor
                '
                Try
                    Using pBLL As New ProdutoBLL
                        pBLL.ProdutoAlterarPrecoDescontoCompra(IDProduto, ItemPrecoCompra)
                    End Using
                    '
                    ProdFornBLL.Update_ProdutoFornecedor_PrecoCompra(IDProduto, FornecedorNFe.IDPessoa, ItemPrecoCompra)
                    '
                Catch ex As Exception
                    Throw ex
                End Try
                '
            End If
            '
        End If
        '
    End Sub

#End Region '/ CORRELACAO FUNCTIONS
    '
#Region "MENU CONTEXT ITENS"
    '
    ' CONTROLE DO MENU SUSPENSO
    Private Sub dgvItens_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvItens.MouseDown
        '
        If e.Button = MouseButtons.Right Then
            '
            Dim c As Control = DirectCast(sender, Control)
            Dim hit As DataGridView.HitTestInfo = dgvItens.HitTest(e.X, e.Y)
            dgvItens.ClearSelection()
            '
            '---VERIFICAÇÕES NECESSÁRIAS
            If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
            '
            ' seleciona o ROW
            dgvItens.Rows(hit.RowIndex).Cells(1).Selected = True
            dgvItens.Rows(hit.RowIndex).Selected = True
            '
            ' mostra o menu item
            Dim item As clNFeItem = dgvItens.Rows(hit.RowIndex).DataBoundItem
            '
            ' mostra o menu item
            miAbrirProduto.Enabled = Not IsNothing(item.IDProduto)
            miAnexarProduto.Enabled = IsNothing(item.IDProduto) AndAlso propEstagio > 2
            miNovoProduto.Enabled = IsNothing(item.IDProduto) AndAlso propEstagio > 2
            miObterProdutoDBAnterior.Enabled = IsNothing(item.IDProduto) AndAlso propEstagio > 2
            '
            ' revela menu
            mnuItens.Show(c.PointToScreen(e.Location))
            '
        End If
        '
    End Sub
    '
    '--- MENU ITEM - ANEXAR PRODUTO
    '----------------------------------------------------------------------------------
    Private Sub miAnexarProduto_Click(sender As Object, e As EventArgs) Handles miAnexarProduto.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Get PRODUTO
            Dim f As New frmProdutoProcurar(Me)
            f.ShowDialog()
            '
            If f.DialogResult <> DialogResult.OK Then Exit Sub
            '
            Dim prodEncontrado As clProduto = f.ProdutoEscolhido
            Dim item As clNFeItem = dgvItens.CurrentRow.DataBoundItem
            '
            '--- ASK USER
            If AbrirDialog("Você deseja realmente relacionar o PRODUTO:" & vbCrLf &
                           item.xProd & vbCrLf &
                           "com o ITEM:" & vbCrLf &
                           prodEncontrado.Produto & " ?",
                           "Relacionar Item/Produto",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question,
                           frmDialog.DialogDefaultButton.First) = DialogResult.No Then
                Exit Sub
            End If
            '
            '--- CHECK PRECO DE COMPRA DIVERGENTE
            CheckPrecoDivergente(item, prodEncontrado.PCompra, prodEncontrado.IDProduto)
            '
            '--- AO ESCOLHER UM PRODUTO - PREENCHE A LISTA
            InsertNewProdutoIntoList(item, prodEncontrado)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao relacionar o produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- MENU ITEM - ABRIR PRODUTO
    '----------------------------------------------------------------------------------
    Private Sub miAbrirProduto_Click(sender As Object, e As EventArgs) Handles miAbrirProduto.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Get IDProduto and clProduto
            Dim item As clNFeItem = dgvItens.CurrentRow.DataBoundItem
            Dim pBLL As New ProdutoBLL
            Dim IDFilial As Integer = Obter_FilialPadrao()
            '
            Dim prod As clProduto = pBLL.GetProduto_PorID(item.IDProduto, IDFilial)
            '
            Dim frm As New frmProduto(EnumFlagAcao.EDITAR, prod, Me)
            frm.MdiParent = My.Application.OpenForms().Item(0)
            Me.Visible = False
            frm.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formuário de Produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- MENU ITEM - CRIAR NOVO PRODUTO
    '----------------------------------------------------------------------------------
    Private Sub miNovoProduto_Click(sender As Object, e As EventArgs) Handles miNovoProduto.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Get IDProduto and clProduto
            '---------------------------------------------------------------------------------
            Dim item As clNFeItem = dgvItens.CurrentRow.DataBoundItem
            Dim pBLL As New ProdutoBLL
            '
            '--- CREATE NEW PRODUTO
            '---------------------------------------------------------------------------------
            Dim prod As New clProduto With {
                .IDProduto = Nothing,
                .Produto = item.xProd,
                .CodBarrasA = item.cEAN,
                .DescontoCompra = item.DescontoCompra,
                .Movimento = 1,
                .NCM = item.NCM,
                .PCompra = item.vProd
                }
            '
            '--- get TIPO
            '---------------------------------------------------------------------------------
            Using frmTipo As New frmProdutoProcurarTipo(Me, IDTipoPadrao)
                '
                frmTipo.ShowDialog()
                If frmTipo.DialogResult <> DialogResult.OK Then Exit Sub
                '
                prod.IDProdutoTipo = frmTipo.propIdTipo_Escolha
                prod.ProdutoTipo = frmTipo.propTipo_Escolha
                IDTipoPadrao = frmTipo.propIdTipo_Escolha
                '
            End Using

            '
            '--- get SUB TIPO
            '---------------------------------------------------------------------------------
            Using frmSubTipo As New frmProdutoProcurarSubTipo(Me, IDSubTipoPadrao, IDTipoPadrao)
                '
                frmSubTipo.ShowDialog()
                If frmSubTipo.DialogResult <> DialogResult.OK Then Exit Sub
                '
                prod.IDProdutoSubTipo = frmSubTipo.propIdSubTipo_Escolha
                prod.ProdutoSubTipo = frmSubTipo.propSubTipo_Escolha
                IDSubTipoPadrao = frmSubTipo.propIdSubTipo_Escolha
                '
            End Using

            '
            '--- get FABRICANTE
            '---------------------------------------------------------------------------------
            Using frmFabricante As New frmFabricanteProcurar(Me, IDFabricantePadrao)
                '
                frmFabricante.ShowDialog()
                If frmFabricante.DialogResult <> DialogResult.OK Then Exit Sub
                '
                prod.IDFabricante = frmFabricante.propIDFab_Escolha
                prod.Fabricante = frmFabricante.propFab_Escolha
                IDFabricantePadrao = frmFabricante.propIDFab_Escolha
                '
            End Using
            '
            '--- get AUTOR
            '---------------------------------------------------------------------------------
            Using frmAutor As New frmAutoresProcurar(Me)
                '
                frmAutor.ShowDialog()
                If frmAutor.DialogResult = DialogResult.OK Then
                    prod.Autor = frmAutor.propAutorEscolhido
                End If
                '
            End Using
            '
            '--- OPEN PRODUTO TO INSERT OTHER FIELDS
            '---------------------------------------------------------------------------------
            Using frm As New frmProduto(EnumFlagAcao.INSERIR, prod, Me)
                Me.Visible = False
                frm.ShowDialog()
                '
                If frm.DialogResult = DialogResult.OK Then
                    prod = frm.propProduto
                End If
                '
            End Using
            '
            '--- CHECK IF NEW PRODUTO WAS INSERTED
            '----------------------------------------------------------------------------------
            If Not IsNothing(prod.IDProduto) Then
                InsertNewProdutoIntoList(item, prod)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formuário de Produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- MENU ITEM - OBTER PRODUTO PELO DB ANTERIOR
    '----------------------------------------------------------------------------------
    Private Sub miObterProdutoDBAnterior_Click(sender As Object, e As EventArgs) Handles miObterProdutoDBAnterior.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- get produto texto
            Dim item As clNFeItem = dgvItens.CurrentRow.DataBoundItem
            Dim RGProdAnteriorEscolhido As Integer
            '
            '--- Open frmProcura ProdutoAntigo
            Using frm As New frmProdutosAntigosProcurar(item.xProd, RGTipoAnterior, Me)
                '
                Visible = False
                frm.ShowDialog()
                '
                If frm.DialogResult <> DialogResult.OK Then Exit Sub
                '
                '--- save TipoAnterior for next find
                RGTipoAnterior = frm.ProdutoEscolhido.IDProdutoTipo
                RGProdAnteriorEscolhido = frm.ProdutoEscolhido.RGProduto
                '
            End Using
            '
            '--- CREATE NEW PRODUTO
            '---------------------------------------------------------------------------------
            Dim prod As New clProduto With {
                .IDProduto = Nothing,
                .RGProduto = RGProdAnteriorEscolhido,
                .Produto = item.xProd,
                .CodBarrasA = item.cEAN,
                .DescontoCompra = item.DescontoNFe,
                .Movimento = 1,
                .NCM = item.NCM,
                .PCompra = item.vProd
                }
            '
            '---TRY OPEN PRODUTO FORM
            Using frmProd As New frmProduto(EnumFlagAcao.INSERIR, prod, Me, RGProdAnteriorEscolhido)
                '
                Me.Visible = False
                frmProd.ShowDialog()
                '
                If frmProd.DialogResult <> DialogResult.OK Then Exit Sub
                '
                prod = frmProd.propProduto
                '
            End Using
            '
            '--- CHECK IF NEW PRODUTO WAS INSERTED
            '----------------------------------------------------------------------------------
            If Not IsNothing(prod.IDProduto) Then
                InsertNewProdutoIntoList(item, prod)
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formuário de Produto..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "OTHER FUNCTIONS"
    '
    Private Sub TryEnableEstagioCompra()
        '
        If ItensNFe.Count = 0 Then propEstagio = 1
        '
        If ItensNFe.Where(Function(x) IsNothing(x.IDProduto)).Count = 0 Then
            propEstagio = 4
            AbrirDialog("Todos items estão relacionados... " & vbNewLine &
                        "Pronto para inserir uma nova Compra",
                        "Items Relacionados",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
        End If
        '
    End Sub
    '
    Private Sub btnSalvarCompra_Click(sender As Object, e As EventArgs) Handles btnSalvarCompra.Click
        '
        '--- Verifica o FORNECEDOR
        Dim IDFornecedor As Integer = FornecedorNFe.IDPessoa
        Dim FornecedorUF As String = FornecedorNFe.UF
        '
        '--- Pergunta ao Usuário se Deseja inserir nova COMPRA
        If AbrirDialog("Você deseja realmente inserir uma NOVA COMPRA?",
                       "Inserir Nova Compra",
                       frmDialog.DialogType.OK,
                       frmDialog.DialogIcon.Information) <> DialogResult.OK Then
            Exit Sub
        End If
        '
        '--- Insere um novo Registro de COMPRA
        '---------------------------------------------------------------------------------------
        Dim cmpBLL As New CompraBLL
        Dim newCompra As New clCompra
        Dim tranBLL As New TransacaoBLL
        '
        '--- DEFINE DBTRAN
        '---------------------------------------------------------------------------------------
        Dim acesso As New AcessoControlBLL
        Dim dbTran As Object = acesso.GetNewAcessoWithTransaction
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Define os valores iniciais
            With newCompra
                .IDPessoaDestino = Obter_FilialPadrao()
                .IDPessoaOrigem = IDFornecedor
                .IDOperacao = 2
                .IDSituacao = TransacaoBLL.EnumTransacaoSituacao.INICIADA
                .IDUser = UsuarioAtual.IdUser
                If FornecedorUF = ObterDefault("UF") Then
                    .CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.Compra, TransacaoBLL.EnumCFOPUFDestino.DentroDaUF)
                Else
                    .CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.Compra, TransacaoBLL.EnumCFOPUFDestino.ForaDaUF)
                End If
                .TransacaoData = ObterDefault("DataPadrao")
                .CobrancaTipo = 0 '--- sem Cobrança
                .FreteTipo = 0 '--- sem frete
                .FreteCobrado = 0
                .ICMSValor = 0
                .Despesas = 0
                .Descontos = 0
                .TotalCompra = 0
                .Observacao = ""
            End With
            '
            newCompra = cmpBLL.SalvaNovaCompra_Procedure_Compra(newCompra, dbTran)
            '
            If IsNothing(newCompra) Then
                Throw New Exception("Um erro ocorreu ao salvar ao Inserir Nova Compra")
            End If
            '
            '--- INSERT ITEMS
            InsertCompraItens(newCompra, dbTran)
            '
            '--- COMMIT
            'acesso.CommitAcessoWithTransaction(dbTran)
            '
        Catch ex As Exception
            '
            '--- ROOLBACK
            acesso.RollbackAcessoWithTransaction(dbTran)
            '
            '--- MESSAGE
            MessageBox.Show("Uma exceção ocorreu ao Salvar nova Compra..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- INSERT ALL COMPRA ITEMS IN NEW COMPRA
    '----------------------------------------------------------------------------------
    Private Sub InsertCompraItens(Compra As clCompra, dbTran As Object)
        '
        Dim ItemBLL As New TransacaoItemBLL
        '
        '--- Insere o novo ITEM no BD
        Try
            '
            For Each item In ItensNFe
                '
                Dim newItem As New clTransacaoItem With {
                .IDProduto = item.IDProduto,
                .RGProduto = item.RGProduto,
                .Produto = item.Produto,
                .TransacaoData = Compra.TransacaoData,
                .IDTransacao = Compra.IDCompra,
                .Quantidade = item.qCom,
                .Desconto = item.DescontoNFe,
                .IDFilial = Compra.IDPessoaDestino,
                .Substituicao = 0,
                .IPI = 0,
                .ICMS = 0,
                .MVA = 0
                }
                '
                '--- INSERT ITEM IN DB
                Dim myID As Long? = Nothing
                myID = ItemBLL.InserirNovoItem(newItem,
                                               TransacaoItemBLL.EnumMovimento.ENTRADA,
                                               Compra.TransacaoData,
                                               True,
                                               dbTran)
                '
                newItem.IDTransacaoItem = myID
                '
            Next
            '
        Catch ex As Exception
            Throw New AppException("Houve um exceção ao INSERIR o item no BD..." & vbNewLine & ex.Message)
        End Try
        '
    End Sub
    '
#End Region '/ OTHER FUNCTIONS
    '
End Class
