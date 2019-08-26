Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports CamadaDTO

Public Class frmCompraGetNFe
    '
    Private ItensXML As New List(Of clTransacaoItem)
    Private Fornecedor As clFornecedor
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormataDataGrid()
        '
    End Sub

#Region "CARREGA/INSERE ITENS"
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



    Private Sub ImportarXML()
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
        If String.IsNullOrEmpty(arquivoXML.FileName) Then Return


        Dim ser As New XmlSerializer(GetType(TNfeProc))
        Dim textReader As TextReader = New StreamReader(arquivoXML.FileName)
        Dim reader As New XmlTextReader(textReader)

        reader.Read()

        Dim Nota As TNfeProc = ser.Deserialize(reader)

        Dim produtos = Nota.NFe.infNFe.det

        ItensXML.Clear()

        For Each p In produtos
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
            ItensXML.Add(clP)
        Next
        '
        txtRazaoSocial.Text = Nota.NFe.infNFe.emit.xNome
        txtCNPJ.Text = Nota.NFe.infNFe.emit.Item
        txtInscricao.Text = Nota.NFe.infNFe.emit.IE
        '
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        ImportarXML()
        dgvItens.DataSource = ItensXML
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class
