Imports CamadaDTO
Imports CamadaBLL
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class frmCompraGetNFe
    '
    Private ItensNFe As New List(Of clTransacaoItem)
    Private FornecedorNFe As New clFornecedor
    Dim NotaNFe As TNfeProc
    '
#Region "NEW | OPEN | PROPS"
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormataDataGrid()
        '
    End Sub
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
        ' (2) COLUNA RGProduto
        dgvItens.Columns.Add("clnRGProduto", "Reg.")
        With dgvItens.Columns("clnRGProduto")
            .DataPropertyName = "IDProduto"
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
        ' (3) COLUNA PRODUTO
        dgvItens.Columns.Add("clnProduto", "Descrição")
        With dgvItens.Columns("clnProduto")
            .DataPropertyName = "Produto"
            .Width = 375
            .Resizable = DataGridViewTriState.False
            .Visible = True
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        '
        ' (4) COLUNA QUANTIDADE
        dgvItens.Columns.Add("clnQuantidade", "Qtde.")
        With dgvItens.Columns("clnQuantidade")
            .DataPropertyName = "Quantidade"
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
        ' (5) COLUNA PRECO
        dgvItens.Columns.Add("clnPreco", "Preço")
        With dgvItens.Columns("clnPreco")
            .DataPropertyName = "Preco"
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
        ' (6) COLUNA SUB TOTAL
        dgvItens.Columns.Add("clnSubTotal", "SubTotal")
        With dgvItens.Columns("clnSubTotal")
            .DataPropertyName = "SubTotal"
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
        ' (7) COLUNA DESCONTO
        dgvItens.Columns.Add("clnDesconto", "Desc.%")
        With dgvItens.Columns("clnDesconto")
            .DataPropertyName = "Desconto"
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
        ' (8) COLUNA TOTAL
        dgvItens.Columns.Add("clnTotal", "Total")
        With dgvItens.Columns("clnTotal")
            .DataPropertyName = "Total"
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
                ImportItensNFe()
                dgvItens.DataSource = ItensNFe
                ImportFornecedorNFe()
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter os Dados do aquivo NFe XML..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            If IsNothing(NotaNFe) Then
                Throw New AppException("Ainda não há NFe, ou é nula...")
            End If
            '
            ItensNFe.Clear()
            Dim ItensXML = NotaNFe.NFe.infNFe.det
            '
            For Each p In ItensXML
                '
                Dim clP As New clTransacaoItem With {
                .IDProduto = p.prod.cProd,
                .Produto = p.prod.xProd,
                .Preco = p.prod.vProd.Replace(".", ","),
                .CodBarrasA = p.prod.cEAN,
                .Quantidade = p.prod.qCom.Replace(".", ",")
                }
                '
                If Not IsNothing(p.prod.vDesc) Then
                    Dim pDesc As Double = p.prod.vDesc.Replace(".", ",")
                    Dim desc As Double = 100 * (clP.Preco - pDesc) / clP.Preco
                    clP.Desconto = desc
                End If
                '
                ItensNFe.Add(clP)
                '
            Next
            '
        Catch ex As Exception
            Throw ex
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
                .Cadastro = emit.xNome
                .NomeFantasia = emit.xFant
                .CNPJ = Utilidades.CNPConvert(emit.Item)
                .InscricaoEstadual = emit.IE
                .Endereco = emit.enderEmit.xLgr & " " & emit.enderEmit.nro & " " & emit.enderEmit.xCpl
                .Bairro = emit.enderEmit.xBairro
                .Cidade = emit.enderEmit.xMun
                .UF = emit.enderEmit.UF
                .CEP = emit.enderEmit.CEP
                .TelefoneA = emit.enderEmit.fone
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
        txtRazaoSocial.Text = NotaNFe.NFe.infNFe.emit.xNome
        txtCNPJ.Text = NotaNFe.NFe.infNFe.emit.Item
        txtInscricao.Text = NotaNFe.NFe.infNFe.emit.IE
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
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- LOOKING FOR FORNECEDOR
            '-----------------------------------------------------------------------------
            Dim procForn As clFornecedor = FornecedorFind()
            '
            If Not IsNothing(procForn) AndAlso Not IsNothing(procForn.IDPessoa) Then
                '
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
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Fazer correlação da NFe..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
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
#End Region '/ CORRELACAO FUNCTIONS
    '
End Class
