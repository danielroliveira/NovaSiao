Imports CamadaDTO
Imports CamadaBLL
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text.RegularExpressions

Public Class frmCompraGetNFe
	'
	Private NotaNFe As TNfeProc
	Private ItensNFe As New List(Of clNFeItem)
	Private bindItens As New BindingSource
	Private FornecedorNFe As clFornecedor = Nothing
	Private TranspNFe As clTransportadora = Nothing
	Private IDTipoPadrao As Integer? = Nothing
	Private IDSubTipoPadrao As Integer? = Nothing
	Private IDFabricantePadrao As Integer? = Nothing
	Private RGTipoAnterior As Integer? = Nothing
	Private _propEstagio As Byte
	Private ProdFornBLL As New ProdutoFornecedorBLL
	Private CNPJFilial As String
	Private _APagarList As New List(Of clAPagar)
	Private _AreSelectedRows As Boolean
	Private _RelacaoFornecedorEncontrada As Boolean = False
	Private _RelacaoTranspEncontrada As Boolean = False
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
		Property Selected As Boolean = False
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
		GetCNPJFilial()
		'
	End Sub
	'
	Private Sub frmCompraGetNFe_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		'
		If String.IsNullOrEmpty(CNPJFilial) Then
			Close()
			MostraMenuPrincipal()
		End If
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
					tspMenuFornecedor.Visible = False
					tspMenuTransp.Visible = False
					lblRazaoSocial.Font = New Font("Calibri", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
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
	Property AreSelectedRows As Boolean
		Get
			Return _AreSelectedRows
		End Get
		Set(value As Boolean)
			_AreSelectedRows = value
			'
			'--- clear all old selected
			For Each r As DataGridViewRow In dgvItens.Rows
				r.DataBoundItem.Selected = False
			Next
			'
			If value Then
				'--- cria o backup da selecao nos items
				For Each r As DataGridViewRow In dgvItens.SelectedRows
					r.DataBoundItem.Selected = True
				Next
			End If
			'
		End Set
		'
	End Property
	'
	Private Function GetCNPJFilial() As String
		'
		Dim frmP As frmPrincipal = My.Application.OpenForms().OfType(Of frmPrincipal).First()
		'
		If Not IsNothing(frmP.propContaPadrao) Then
			'
			CNPJFilial = frmP.propContaPadrao.CNPJFilial
			'
			If CNPJFilial.Length > 0 AndAlso CNPJFilial <> "00.000.000/0000-00" Then
				Return CNPJFilial
			End If
			'
		End If
		'
		AbrirDialog("Não foi possível obter o CNPJ da Filial padrão..." &
					"Favor definir o CNPJ nas configurações.",
					"CNPJ Indefinido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
		Return String.Empty
		'
	End Function
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
		dgvItens.MultiSelect = True
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
	'--- AFTER HIDE | ON SHOW FORM RETURN STATE OF SELECTED ITEMS IN DATAGRIDVIEW
	'----------------------------------------------------------------------------------
	Private Sub dgvItens_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvItens.DataBindingComplete
		'
		If AreSelectedRows Then
			'
			'--- Reselect Backuped itens
			For Each r As DataGridViewRow In dgvItens.Rows
				If r.DataBoundItem.selected Then
					r.Selected = True
				Else
					r.Selected = False
				End If
			Next
			'
		End If
		'
	End Sub
	'
	'--- UPDATE LABEL ITENS SELECIONADOS
	'----------------------------------------------------------------------------------
	Private Sub dgvItens_SelectionChanged(sender As Object, e As EventArgs) Handles dgvItens.SelectionChanged
		'
		Dim sel As Integer = dgvItens.SelectedRows.Count
		'
		If sel > 1 Then
			lblSelectInfo.Text = "Selecionados: " & sel & " Itens"
			lblSelectInfo.Visible = True
		ElseIf sel = 1 Then
			lblSelectInfo.Text = "Selecionado: 1 Item"
			lblSelectInfo.Visible = True
		Else
			lblSelectInfo.Visible = False
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
			'
			If ObterXML() Then
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				'--- Clear old values
				propEstagio = 1
				FornecedorNFe = New clFornecedor
				PreencheLabelsFornecedor()
				_RelacaoFornecedorEncontrada = False
				_RelacaoTranspEncontrada = False
				TranspNFe = New clTransportadora
				PreencheLabelsTransp()
				'
				dgvItens.DataSource = Nothing
				dgvItens.Rows.Clear()
				_APagarList.Clear()
				'
				'--- verifica CNPJ compativel com NFe obtida
				If CheckCNPJNFe() = False Then
					Exit Sub
				End If
				'
				'--- Import new values
				ImportItensNFe()
				bindItens.DataSource = ItensNFe
				dgvItens.DataSource = bindItens
				ImportFornecedorNFe()
				ImportaAPagarNFe()
				ImportTranspNFe()
				propEstagio = 2
				'
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
			If String.IsNullOrEmpty(arquivoXML.FileName) Then Return False
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Check XML to find xPais BUG
			Dim xmlTempPath As String = CreateXMLTemp(arquivoXML.FileName)
			'
			' ler o arquivo config xml
			Dim ser As New XmlSerializer(GetType(TNfeProc))
			Dim textReader As TextReader = New StreamReader(xmlTempPath)
			'
			Dim reader As New XmlTextReader(textReader)
			'
			reader.Read()
			'
			NotaNFe = ser.Deserialize(reader)
			textReader.Close()
			File.Delete(xmlTempPath)
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
	'--- CRIA UMA COPIA DO XML TO Looking For and FIX xPais BUG IN NEW XML
	'----------------------------------------------------------------------------------
	Private Function CreateXMLTemp(XmlPath As String) As String
		'
		Try
			'
			Dim PathFolder As String = Path.GetTempPath()
			'
			'--- CREATE TEMP FOLDER
			Dim TempFolder As String = PathFolder & "ProgramaLoja"
			If Not Directory.Exists(TempFolder) Then
				Directory.CreateDirectory(TempFolder)
			End If

			Dim FileName As String = XmlPath.Split("\").Last().Replace(".XML", "")
			'
			Dim NewXMLFile As String = TempFolder + "\" + FileName + "_TEMP.XML"
			If File.Exists(NewXMLFile) Then File.Delete(NewXMLFile)
			'
			'--- COPY THE ORIGINAL FILE TO NEW FOLDER
			File.Copy(XmlPath, NewXMLFile)
			'
			Dim myXML As New XmlDocument
			myXML.Load(NewXMLFile)
			'
			Dim MyXMLNode As XmlNode = myXML.GetElementsByTagName("xPais")(0)
			'
			'--- CHECK IF xPais IS BRASIL or Brasil
			Dim Pais As String = MyXMLNode.InnerText
			'
			If Pais <> "BRASIL" Then
				MyXMLNode.InnerText = "BRASIL"
				myXML.Save(NewXMLFile)
			End If
			'
			'--- RETURN
			Return NewXMLFile
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
					'Dim desc As Double = 100 * (clp.vProd - pDesc) / clp.vProd
					Dim desc As Double = pDesc * 100 / clp.vProd
					clp.DescontoNFe = desc
				End If
				'
				ItensNFe.Add(clp)
				'
			Next
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
				.NomeFantasia = Utilidades.PrimeiraLetraMaiuscula(If(emit.xFant, ""))
				.CNPJ = Utilidades.CNPConvert(emit.Item)
				.InscricaoEstadual = emit.IE
				.Endereco = Utilidades.PrimeiraLetraMaiuscula(emit.enderEmit.xLgr) & " " & emit.enderEmit.nro & " " & emit.enderEmit.xCpl
				.Bairro = Utilidades.PrimeiraLetraMaiuscula(emit.enderEmit.xBairro)
				.Cidade = Utilidades.PrimeiraLetraMaiuscula(emit.enderEmit.xMun)
				Dim enumUF As TUf = emit.enderEmit.UF
				.UF = enumUF.ToString
				.CEP = emit.enderEmit.CEP
				If emit.enderEmit.fone IsNot Nothing Then
					Dim telLen As Byte = emit.enderEmit.fone.Trim.Length
					If telLen = 10 Then
						.TelefoneA = emit.enderEmit.fone.Insert(2, " ")
					Else
						.TelefoneA = emit.enderEmit.fone
					End If
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
		If Not IsNothing(FornecedorNFe) Then
			lblRazaoSocial.Text = FornecedorNFe.Cadastro
			lblCNPJ.Text = FornecedorNFe.CNPJ
		Else
			lblRazaoSocial.Text = ""
			lblCNPJ.Text = ""
		End If
		'
	End Sub
	'
	'--- IMPORTAR OS A PAGAR DA NFE
	'----------------------------------------------------------------------------------
	Private Sub ImportaAPagarNFe()
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
			_APagarList.Clear()
			'
			'--- CHECK IF EXIST DUPS
			If IsNothing(NotaNFe.NFe.infNFe) OrElse IsNothing(NotaNFe.NFe.infNFe.cobr) OrElse IsNothing(NotaNFe.NFe.infNFe.cobr.dup) Then
				AbrirDialog("Não há informação de Duplicatas a Pagar nessa NFe...",
							"Sem A Pagar", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
				Exit Sub
			End If
			'
			Dim dupsXML = NotaNFe.NFe.infNFe.cobr.dup
			'
			For Each d In dupsXML
				Dim clp As New clAPagar
				'
				clp.APagarValor = d.vDup.Replace(".", ",")
				clp.Vencimento = Date.SpecifyKind(d.dVenc, DateTimeKind.Utc)
				clp.Identificador = d.nDup
				clp.IDCobrancaForma = 1
				clp.Origem = 1
				clp.Situacao = 0
				'
				_APagarList.Add(clp)
				'
			Next
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
	'--- IMPORTAR A TRANSPORTADORA DA NFE XML
	'----------------------------------------------------------------------------------
	Private Sub ImportTranspNFe()
		'
		Try
			'
			If IsNothing(NotaNFe) Then
				Throw New AppException("Ainda não há NFe, ou é nula...")
			End If
			'
			Dim transp As TNFeInfNFeTransp = NotaNFe.NFe.infNFe.transp
			'
			If IsNothing(transp.transporta) Then
				AbrirDialog("Não há informação de Transportadora nessa NFe.",
							"Sem Transportadora", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
				TranspNFe = Nothing
				Exit Sub
			End If
			'
			With TranspNFe
				.Cadastro = Utilidades.PrimeiraLetraMaiuscula(transp.transporta.xNome)
				.CNPJ = Utilidades.CNPConvert(transp.transporta.Item)
				.InscricaoEstadual = transp.transporta.IE
				.Endereco = Utilidades.PrimeiraLetraMaiuscula(If(transp.transporta.xEnder, ""))
				.Cidade = Utilidades.PrimeiraLetraMaiuscula(If(transp.transporta.xMun, ""))
				Dim enumUF As TUf = transp.transporta.UF
				.UF = enumUF.ToString
			End With
			'
			PreencheLabelsTransp()
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Sub
	'
	Private Sub PreencheLabelsTransp()
		'
		If Not IsNothing(TranspNFe) Then
			lblTransportadora.Text = TranspNFe.Cadastro
			lblTranspCNPJ.Text = TranspNFe.CNPJ
		Else
			lblTransportadora.Text = ""
			lblTranspCNPJ.Text = ""
		End If
		'
	End Sub
	'
	Private Function CheckCNPJNFe() As Boolean
		'
		Dim CNPJ_NFe As String = NotaNFe.NFe.infNFe.dest.Item
		Dim CNPJ_Filial As String = CNPJFilial.Replace(".", "").Replace("/", "").Replace("-", "")
		'
		If NotaNFe.NFe.infNFe.dest.Item <> CNPJ_Filial Then
			AbrirDialog("O CNPJ da NFe escolhida é Diferente do CNPJ da Filial Padrão Atual...",
						"CNPJ Divergente",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Warning)
			Return False
		End If
		'
		Return True
		'
	End Function
	'
#End Region '/ IMPORT NFE XML
	'
#Region "BUTTONS FUNCTION"
	'
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
		Close()
		MostraMenuPrincipal()
	End Sub
	'
#End Region '/ BUTTONS FUNCTION
	'
#Region "CORRELACAO FUNCTIONS"
	'
	'--- FAZER CORRELACAO ENTRE ITEMS E PRODUTOS PELO FORNECEDOR
	'----------------------------------------------------------------------------------
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
			Info.InfoShow("Verificando se a NFe já foi inserida...")
			'
			'--- GET TRANSACAO for don't open new instances of db
			'-----------------------------------------------------------------------------
			acesso = New AcessoControlBLL
			dbTran = acesso.GetNewAcessoWithTransaction
			'
			'--- CHECK IF THE NOTA IS NEW
			'-----------------------------------------------------------------------------
			If CheckNotDuplicateNFe() = False Then
				AbrirDialog("Essa NFe já foi inserida nas compras..." & vbCrLf &
							"Não é possível inserir essa NFe novamente.",
							"Compra Inserida", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
				Exit Sub
			End If
			'
			'--- LOOKING FOR FORNECEDOR
			'-----------------------------------------------------------------------------
			Info.InfoShow("Verificando o fornecedor da NFe...")
			'
			If IsNothing(FornecedorNFe.IDPessoa) Then
				'
				Dim procForn As clFornecedor = FornecedorFind(dbTran) '---> PROCURA
				'
				If Not IsNothing(procForn) AndAlso Not IsNothing(procForn.IDPessoa) Then '---> ENCONTRADO
					'
					tspMenuFornecedor.Visible = False
					FornecedorNFe.IDPessoa = procForn.IDPessoa
					AbrirDialog("Fornecedor encontrado:" & vbCrLf & vbCrLf & procForn.Cadastro,
								"Fornecedor", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
					'
				Else '---> NAO ENCONTRADO
					If _RelacaoFornecedorEncontrada Then Exit Sub
					'
					AbrirDialog("Um fornecedor correspondente à NFe não pode ser encontrado..." & vbCrLf &
								"Favor tentar encontrar um fornecedor para inserir a NFe.",
								"Fornecedor", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
					tspMenuFornecedor.Visible = True
					Exit Sub
					'
				End If
				'
			End If
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- LOOKING FOR TRANSPORTADORA
			'-----------------------------------------------------------------------------
			Info.InfoShow("Verificando a Transportadora...")
			'
			If Not IsNothing(TranspNFe) AndAlso IsNothing(TranspNFe.IDPessoa) Then
				'
				Dim procTransp As clTransportadora = TransportadoraFind(dbTran) '---> PROCURA
				'
				If IsNothing(procTransp) OrElse IsNothing(procTransp.IDPessoa) Then '---> NAO ENCONTRADA
					If _RelacaoTranspEncontrada Then Exit Sub
					'
					AbrirDialog("Uma TRANSPORTADORA correspondente à NFe não pode ser encontrada." & vbCrLf &
								"É possível inserir a transportadora...",
								"Transportadora", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
					'
					tspMenuTransp.Visible = True
					Exit Sub
					'
				Else '---> ENCONTRADA
					TranspNFe = procTransp
					AbrirDialog("Transportadora encontrada:" & vbCrLf & vbCrLf & TranspNFe.Cadastro,
								"Tranportadora", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
				End If
				'
			End If
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- LOOKING ITENS PRODUTOS
			'----------------------------------------------------------------------------------
			Info.InfoShow("Verificando os Itens da NFe...")
			Dim countEncontrados As Integer = 0
			Dim countItens As Integer = dgvItens.Rows.Count
			Dim atualItem As Integer = 1
			'
			For Each item In ItensNFe
				'
				'--- EMIT INFO
				Info.InfoShow("Verificando os Itens da NFe... ITEM " & Format(atualItem, "00") & " DE " & Format(countItens, "00"))
				atualItem += 1
				'
				'--- PERCORRE E ATUALIZA A LISTAGEM
				dgvItens.CurrentCell = dgvItens.Rows(ItensNFe.IndexOf(item)).Cells(0)
				dgvItens.Rows(ItensNFe.IndexOf(item)).Selected = True
				dgvItens.Refresh()
				'
				'--- PROCURA PRODUTO ITEM
				Dim prodEncontrado As clProdutoFornecedorItem = ProdutoFind(item, FornecedorNFe.IDPessoa, dbTran)
				'
				'--- SE ENCONTROU UM PRODUTO - PREENCHE A LISTA
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
					CheckPrecoDivergente(item, prodEncontrado.PCompra, prodEncontrado.IDProduto, dbTran)
					'
				End If
				'
			Next
			'
			'--- MOVE TO FIRST ITEM DATAGRID
			dgvItens.CurrentCell = dgvItens.Rows(0).Cells(0)
			dgvItens.Rows(0).Selected = True
			dgvItens.Refresh()
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
			Me.Visible = True
		Catch ex As Exception
			acesso.RollbackAcessoWithTransaction(dbTran)
			MessageBox.Show("Uma exceção ocorreu ao Fazer correlação da NFe..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.Visible = True
		Finally
			Info.InfoHide()
			'
			'-- CLOSE ACESSO
			acesso.CommitAcessoWithTransaction(dbTran)
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Sub
	'
	'--- CHECK DUPLICATED NOTA
	'----------------------------------------------------------------------------------
	Private Function CheckNotDuplicateNFe() As Boolean
		'
		'--- Remove all letters of Chave
		Dim chave As String = NotaNFe.NFe.infNFe.Id
		chave = Regex.Replace(chave, "[^0-9.]", "")
		'
		'--- CHECK DUPLICATE NOTA IN BD BY CHAVE
		Try
			Dim notaBLL As New NotaFiscalBLL
			'
			'--- CHECK NOTA IN DB
			Dim nota As clNotaFiscal = notaBLL.NotaFiscal_GET_PorChave(chave)
			'
			If IsNothing(nota) Then
				Return True
			Else
				Return False
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
	'--- PROCURA FORNECEDOR
	'----------------------------------------------------------------------------------
	Private Function FornecedorFind(dbTran As Object) As clFornecedor
		'
		Try
			'
			Dim pBLL As New PessoaBLL
			Dim pessoa As Object = pBLL.ProcurarCNP_Pessoa(FornecedorNFe.CNPJ, PessoaBLL.EnumPessoaGrupo.FORNECEDOR, dbTran)
			'
			'--- VERIFICA PESSOA RETORNADA
			'-----------------------------------------------------------------------------------------
			If TypeOf pessoa Is clFornecedor Then '---> FORNCEDOR ENCONTRADO
				'
				'--- OPEN FRM FORNECEDOR
				Return OpenFrmFornecedor(pessoa)
				'
			ElseIf TypeOf pessoa Is clPessoaJuridica Then '---> PESSOA JURIDICA MESMO CNPJ
				'
				If AbrirDialog("Não foi encontrado um fornecedor correspondente, porém foi encontrado uma Pessoa Jurídica " &
							   "cadastrada com o mesmo CNPJ:" & vbCrLf & DirectCast(pessoa, clPessoaJuridica).Cadastro & vbCrLf &
							   "Deseja cadastrar essa Pessoa Jurídica como um novo fornecedor?",
							   "Pessoa Jurídica Encontrada",
							   frmDialog.DialogType.SIM_NAO,
							   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
					'
					Dim PJ As New clPessoaJuridica
					PJ = DirectCast(pessoa, clPessoaJuridica)
					'
					'--- PREENCHE OS DADOS AUTOMATICAMENTE
					Dim newForn As New clFornecedor With {
						.Cadastro = PJ.Cadastro,
						.NomeFantasia = PJ.NomeFantasia,
						.InscricaoEstadual = PJ.InscricaoEstadual,
						.Endereco = PJ.Endereco,
						.Bairro = PJ.Bairro,
						.Cidade = PJ.Cidade,
						.UF = PJ.UF,
						.CEP = PJ.CEP,
						.TelefoneA = PJ.TelefoneA,
						.TelefoneB = PJ.TelefoneB,
						.Email = PJ.Email,
						.FundacaoData = If(PJ.FundacaoData, ""),
						.ContatoNome = PJ.ContatoNome
						}
					'
					'--- OPEN FRM FORNECEDOR
					Return OpenFrmFornecedor(newForn)
					'
				Else '--> RESPOSTA NAO
					'
					FornecedorNFe.IDPessoa = Nothing
					Return Nothing
					'
				End If
				'
			Else '---> NAO ENCONTRADO (FORNECEDOR AND PJ)
				'
				'--- VERIFICA CNPJ RELACIONADO
				'-----------------------------------------------------------------------------------------
				Dim PessoaRelacionada As Object = VerCNPJRelacionadoFornecedor(dbTran)
				'
				If IsNothing(PessoaRelacionada) Then
					FornecedorNFe.IDPessoa = Nothing
					Return Nothing
				Else
					_RelacaoFornecedorEncontrada = True
				End If
				'
				If TypeOf PessoaRelacionada Is clFornecedor Then '---> FORNCEDOR RELACIONADO ENCONTRADO
					'
					If AbrirDialog("O CNPJ da NFe está relacionado com o CNPJ de:" & vbNewLine &
								   PessoaRelacionada.Cadastro & vbNewLine &
								   "Deseja usar a relação existente e transferir a compra para o CNPJ relacionado?",
								   "CNPJ Relacionado",
								   frmDialog.DialogType.SIM_NAO,
								   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
						'
						'--- CHANGE LABELS OF RELACAO
						lblRazaoSocial.Text += " (" & PessoaRelacionada.Cadastro & ")"
						lblCNPJ.Text += " >>> " & PessoaRelacionada.CNPJ
						ResizeFontLabel(lblRazaoSocial)
						'
						Return PessoaRelacionada
						'
					Else
						Return Nothing
					End If
					'
				ElseIf TypeOf PessoaRelacionada Is clPessoaJuridica Then '---> PJ RELACIONADA ENCONTRADA (NAO FORNECEDOR)
					'
					'--- REMOVE RELACAO ? ASK USER
					If AbrirDialog("Foi encontrada uma Pessoa Jurídica relacionada com esse CNPJ, mas que ainda não é um Fornecedor:" &
								   vbCrLf & vbCrLf & DirectCast(PessoaRelacionada, clPessoaJuridica).Cadastro & vbCrLf & vbCrLf &
								   "Deseja remover esse relacionamento entre CNPJs para Correlacionar a NFe?",
								   "CNPJs Relacionados",
								   frmDialog.DialogType.SIM_NAO,
								   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
						'
						'--- REMOVE RELACAO
						RemoveRelacaoCNPJ(FornecedorNFe.CNPJ)
						'
						AbrirDialog("Relação entre CNPJs removida com sucesso!" & vbNewLine &
									"Favor fazer a Correlação novamente...",
									"Relação Removida", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
						'
						_RelacaoFornecedorEncontrada = False
						'
					End If
					'
					FornecedorNFe.IDPessoa = Nothing
					Return Nothing
					'
				End If
				'
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
	Private Function OpenFrmFornecedor(fornecedor As clFornecedor) As clFornecedor
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Using frmF As New frmFornecedor(fornecedor, Me)
				'
				Me.Visible = False
				frmF.ShowDialog()
				'
				If frmF.DialogResult = DialogResult.OK Then
					fornecedor.IDPessoa = frmF.propForn.IDPessoa
					Return frmF.propForn
				Else
					fornecedor.IDPessoa = Nothing
					Return Nothing
				End If
				'
			End Using
			'
		Catch ex As Exception
			Throw New AppException("Uma exceção ocorreu ao abrir formulário de fornecedores..." & vbNewLine & ex.Message)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Function
	'
	'--- PROCURA TRANSPORTADORA
	'----------------------------------------------------------------------------------
	Private Function TransportadoraFind(dbTran As Object) As clTransportadora
		'
		Try
			'
			Dim pBLL As New PessoaBLL
			Dim pessoa As Object = pBLL.ProcurarCNP_Pessoa(TranspNFe.CNPJ, PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA, dbTran)
			'
			'--- VERIFICA PESSOA RETORNADA
			'-----------------------------------------------------------------------------------------
			If TypeOf pessoa Is clTransportadora Then '---> TRANSPORTADORA ENCONTRADA
				'
				'--- RETURN PESSOA
				Return pessoa
				'
			ElseIf TypeOf pessoa Is clPessoaJuridica Then '---> PESSOA JURIDICA MESMO CNPJ
				'
				If AbrirDialog("Não foi encontrado um TRANSPORTADORA correspondente, porém foi encontrado uma Pessoa Jurídica " &
							   "cadastrada com o mesmo CNPJ:" & vbCrLf & DirectCast(pessoa, clPessoaJuridica).Cadastro & vbCrLf &
							   "Deseja cadastrar essa Pessoa Jurídica como uma NOVA TRANSPORTADORA?",
							   "Pessoa Jurídica Encontrada",
							   frmDialog.DialogType.SIM_NAO,
							   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
					'
					Dim PJ As clPessoaJuridica = DirectCast(pessoa, clPessoaJuridica)
					'
					'--- PREENCHE OS DADOS AUTOMATICAMENTE
					Dim newTransp As New clTransportadora With {
						.Cadastro = PJ.Cadastro,
						.NomeFantasia = PJ.NomeFantasia,
						.InscricaoEstadual = PJ.InscricaoEstadual,
						.Endereco = PJ.Endereco,
						.Bairro = PJ.Bairro,
						.Cidade = PJ.Cidade,
						.UF = PJ.UF,
						.CEP = PJ.CEP,
						.TelefoneA = PJ.TelefoneA,
						.TelefoneB = PJ.TelefoneB,
						.Email = PJ.Email,
						.FundacaoData = If(PJ.FundacaoData, ""),
						.ContatoNome = PJ.ContatoNome,
						.IDPessoa = PJ.IDPessoa,
						.CNPJ = PJ.CNPJ,
						.PessoaTipo = PJ.PessoaTipo
						}
					'
					'--- OPEN FRM FORNECEDOR
					Return OpenFrmTransportadora(newTransp)
					'
				Else '--> RESPOSTA NAO
					'
					TranspNFe.IDPessoa = Nothing
					Return Nothing
					'
				End If
				'
			Else '---> NAO ENCONTRADO (TRANSPORTADORA AND PJ)
				'
				'--- VERIFICA CNPJ RELACIONADO
				'-----------------------------------------------------------------------------------------
				Dim PessoaRelacionada As Object = VerCNPJRelacionadoTransp(dbTran)
				'
				If IsNothing(PessoaRelacionada) Then
					TranspNFe.IDPessoa = Nothing
					Return Nothing
				Else
					_RelacaoTranspEncontrada = True
				End If
				'
				If TypeOf PessoaRelacionada Is clTransportadora Then '---> TRANSPORTADORA RELACIONADA ENCONTRADA
					'
					If AbrirDialog("O CNPJ da Tranportadora na NFe está relacionado com o CNPJ de:" & vbNewLine &
								   PessoaRelacionada.Cadastro & vbNewLine &
								   "Deseja usar a relação existente e substituir o transporte para o CNPJ relacionado?",
								   "CNPJ Relacionado",
								   frmDialog.DialogType.SIM_NAO,
								   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
						'
						'--- CHANGE LABELS OF RELACAO
						lblTransportadora.Text += " (" & PessoaRelacionada.Cadastro & ")"
						lblTranspCNPJ.Text += " >>> " & PessoaRelacionada.CNPJ
						ResizeFontLabel(lblTransportadora)
						'
						Return PessoaRelacionada
						'
					Else
						Return Nothing
					End If
					'
				ElseIf TypeOf PessoaRelacionada Is clPessoaJuridica Then '---> PJ RELACIONADA ENCONTRADA (NAO TRANSPORTADORA)
					'
					'--- REMOVE RELACAO ? ASK USER
					If AbrirDialog("Foi encontrada uma Pessoa Jurídica relacionada com esse CNPJ, mas que ainda não é uma TRANSPORTADORA:" &
								   vbCrLf & vbCrLf & DirectCast(PessoaRelacionada, clPessoaJuridica).Cadastro & vbCrLf & vbCrLf &
								   "Deseja remover esse relacionamento entre CNPJs para Correlacionar a NFe?",
								   "CNPJs Relacionados",
								   frmDialog.DialogType.SIM_NAO,
								   frmDialog.DialogIcon.Question) = DialogResult.Yes Then
						'
						'--- REMOVE RELACAO
						RemoveRelacaoCNPJ(FornecedorNFe.CNPJ)
						'
						AbrirDialog("Relação entre CNPJs removida com sucesso!" & vbNewLine &
									"Favor fazer a Correlação novamente...",
									"Relação Removida", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
						'
						_RelacaoTranspEncontrada = False
						'
					End If
					'
					TranspNFe.IDPessoa = Nothing
					Return Nothing
					'
				End If
				'
			End If
			'
			Return Nothing
			'
		Catch ex As Exception
			Throw New AppException("Uma exceção ocorreu ao procurar o transportadora..." & vbNewLine & ex.Message)
		End Try
		'
	End Function
	'
	'--- ABRE O FORM TRANSPORTADORA
	'----------------------------------------------------------------------------------
	Private Function OpenFrmTransportadora(transp As clTransportadora) As clTransportadora
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Using frmT As New frmTransportadora(transp, Me)
				'
				Me.Visible = False
				frmT.ShowDialog()
				'
				If frmT.DialogResult = DialogResult.OK Then
					transp.IDPessoa = frmT.propTransp.IDPessoa
					Return frmT.propTransp
				Else
					transp.IDPessoa = Nothing
					Return Nothing
				End If
				'
			End Using
			'
		Catch ex As Exception
			Throw New AppException("Uma exceção ocorreu ao abrir formulário de transportadoras..." &
								   vbNewLine & ex.Message)
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Function
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
	Private Function SalvarRelacao(item As clNFeItem, dbTran As Object) As Boolean
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
			Dim obj As Object = ProdFornBLL.Insert_ProdutoFornecedorItem(prodFornItem, dbTran)
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
			'
		End Try
		'
	End Function
	'
	'--- INSERT NEW PRODUTO INTO LIST
	'----------------------------------------------------------------------------------
	Private Sub InsertNewProdutoIntoList(item As clNFeItem,
										 produto As clProduto)
		'
		'--- AO ESCOLHER UM PRODUTO - PREENCHE A LISTA
		item.IDProduto = produto.IDProduto
		item.RGProduto = produto.RGProduto
		item.Produto = produto.Produto
		item.PCompra = produto.PCompra
		item.DescontoCompra = produto.DescontoCompra
		'
	End Sub
	'
	Private Sub CheckPrecoDivergente(item As clNFeItem,
									 PrecoCompra As Double,
									 IDProduto As Integer,
									 dbTran As Object)
		'
		'--- CHECK PRECO DE COMPRA
		Dim ItemPrecoCompra As Double = Format(CDbl(item.vUnCom.Replace(".", ",")), "#,##0.00")
		'
		If PrecoCompra <> ItemPrecoCompra Then
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
						pBLL.ProdutoAlterarPrecoDescontoCompra(IDProduto, ItemPrecoCompra, , dbTran)
					End Using
					'
					ProdFornBLL.Update_ProdutoFornecedor_PrecoCompra(IDProduto,
																	 FornecedorNFe.IDPessoa,
																	 ItemPrecoCompra, Nothing,
																	 dbTran)
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
	'
	'--- VERIFICA SE O CNPJ DO FORNECEDOR ESTA RELACIONADO COM UMA PESSOA JURIDICA
	'----------------------------------------------------------------------------------
	Private Function VerCNPJRelacionadoFornecedor(dbTran As Object) As Object
		'
		Dim db As New PessoaBLL
		Dim Pessoa As clPessoaJuridica = Nothing
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- PROCURA CNPJ RELACIONADO PELO CNP
			Pessoa = db.ProcurarCNPJRelacionado(FornecedorNFe.CNPJ, dbTran)
			If IsNothing(Pessoa) Then Return Nothing
			'
			'--- PROCURA PJ ENCONTRADA PELO TIPO
			Dim pBLL As New PessoaBLL
			Dim fornecedor As Object = pBLL.ProcurarCNP_Pessoa(Pessoa.CNPJ, PessoaBLL.EnumPessoaGrupo.FORNECEDOR, dbTran)
			'
			If TypeOf fornecedor Is clFornecedor Then
				Return DirectCast(fornecedor, clFornecedor)
			Else
				Return Pessoa
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Procurar CNPJ Relacionado..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return Nothing
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Function
	'
	'--- VERIFICA SE O CNPJ DA TRANSPORTADORA ESTA RELACIONADO COM UMA PESSOA JURIDICA 
	'----------------------------------------------------------------------------------
	Private Function VerCNPJRelacionadoTransp(dbTran As Object) As Object
		'
		Dim db As New PessoaBLL
		Dim Pessoa As clPessoaJuridica = Nothing
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- PROCURA CNPJ RELACIONADO PELO CNP
			Pessoa = db.ProcurarCNPJRelacionado(TranspNFe.CNPJ, dbTran)
			If IsNothing(Pessoa) Then Return Nothing
			'
			'--- PROCURA PJ ENCONTRADA PELO TIPO
			Dim pBLL As New PessoaBLL
			Dim transp As Object = pBLL.ProcurarCNP_Pessoa(Pessoa.CNPJ, PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA, dbTran)
			'
			If TypeOf transp Is clTransportadora Then
				Return DirectCast(transp, clTransportadora)
			Else
				Return Pessoa
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Procurar CNPJ Relacionado..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return Nothing
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Function
	'
	'--- REMOVE A RELACAO ENTRE CNPJ RELACIONADOS
	'----------------------------------------------------------------------------------
	Private Function RemoveRelacaoCNPJ(CNPJ As String) As Boolean
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim db As New PessoaBLL
			db.RemoverCNPJRelacionado(CNPJ)
			'
			Return True
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Remover a Relação entre CNPJs..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Function
	'
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
			'
			'---VERIFICAÇÕES NECESSÁRIAS
			If Not hit.Type = DataGridViewHitTestType.Cell Then Exit Sub
			'
			' seleciona o ROW se estiver fora da selecao
			If dgvItens.Rows(hit.RowIndex).Selected = False Then
				dgvItens.ClearSelection()
				dgvItens.CurrentCell = dgvItens.Rows(hit.RowIndex).Cells(1)
				dgvItens.Rows(hit.RowIndex).Selected = True
			End If
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
		'--- 1. GET PRODUTO
		'----------------------------------------------------------------------------------
		Dim prodEncontrado As clProduto = Nothing
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Check LIST of Selected Items
			If Not VerifyToInsertNewProduto() Then Exit Sub
			'
			'--- Get PRODUTO
			Dim f As New frmProdutoProcurar(Me)
			f.ShowDialog()
			'
			If f.DialogResult <> DialogResult.OK Then Exit Sub
			'
			prodEncontrado = f.ProdutoEscolhido
			'
			'--- Create Message AND ask to USER
			Dim message As String = ""
			Dim CountItemsSelected As Integer = dgvItens.SelectedRows.Count
			'
			If CountItemsSelected = 1 Then
				Dim curItem As clNFeItem = dgvItens.CurrentRow.DataBoundItem
				message = "Você deseja realmente relacionar o ITEM:" & vbCrLf &
						   curItem.xProd & vbCrLf &
						   "com o PRODUTO:" & vbCrLf &
						   prodEncontrado.Produto & " ?"
			Else
				message = "Você deseja realmente relacionar todos os " &
						  CountItemsSelected & " ITENS selecionados" & vbCrLf &
						  "com o PRODUTO:" & vbCrLf &
						  prodEncontrado.Produto & " ?"
			End If
			'
			'--- ASK USER
			If AbrirDialog(message, "Relacionar Item/Produto",
						   frmDialog.DialogType.SIM_NAO,
						   frmDialog.DialogIcon.Question,
						   frmDialog.DialogDefaultButton.First) = DialogResult.No Then Exit Sub
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao OBTER o Produto para relacionar..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'
		'--- 2. TRY MAKE RELACIONAMENTO ITEM <=> PRODUTO
		'----------------------------------------------------------------------------------
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			MakeRelacionamentoItemProduto(prodEncontrado)
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Relacionar Item Produto..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- TRY MAKE RELACIONAMENTO ITEM <=> PRODUTO
	'----------------------------------------------------------------------------------
	Private Sub MakeRelacionamentoItemProduto(ProdutoEncontrado As clProduto)
		'
		'--- CHECK IF FORNECEDOR IS DEFINED
		If IsNothing(FornecedorNFe.IDPessoa) OrElse FornecedorNFe.IDPessoa = 0 Then
			AbrirDialog("O Fornecedor ainda não foi correlacionado com a NFe." + vbCrLf +
						"Favor fazer a correlação antes.",
						"Fornecedor Desconhecido", frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Exclamation)
			Exit Sub
		End If
		'
		'--- CREATE NEW TRANSACTION
		Dim acesso As New AcessoControlBLL
		Dim dbTran As Object = acesso.GetNewAcessoWithTransaction
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- RELACIONA ITEM => PRODUTO
			RelacionaItensProduto(ProdutoEncontrado, dbTran)
			TryEnableEstagioCompra()
			'
			'--- COMMIT TRANSACTION
			acesso.CommitAcessoWithTransaction(dbTran)
			'
			AbrirDialog("Relacionamento Item NFe & Produto realizado com sucesso!",
						"Sucesso", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			'
		Catch ex As Exception
			'
			'--- REMOVE A RELACAO ITEM PRODUTO
			RemoveRelacaoItemProdutoSelected()
			'
			'--- ROOLBACK TRANSACTION
			acesso.RollbackAcessoWithTransaction(dbTran)
			'
			'--- THROW EX
			Throw ex
			'
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Sub
	'
	'--- RELACIONAMENTO ITEM <=> PRODUTO
	'----------------------------------------------------------------------------------
	Private Sub RelacionaItensProduto(ProdutoEncontrado As clProduto, dbTran As Object)
		'
		Try
			'
			'--- CHECK PRECO DE COMPRA DIVERGENTE (ASK USER)
			Dim FirstItem As clNFeItem = dgvItens.SelectedRows(0).DataBoundItem
			CheckPrecoDivergente(FirstItem,
								 ProdutoEncontrado.PCompra,
								 ProdutoEncontrado.IDProduto,
								 dbTran)
			'
			'--- Insert ALL Selected ITEMS (PREENCHE A LISTA)
			For Each r In dgvItens.SelectedRows
				Dim Item As clNFeItem = r.DataBoundItem
				InsertNewProdutoIntoList(Item, ProdutoEncontrado)
			Next
			'
			'--- SAVE RELATION ITEM <=> PRODUTO (ASK USER)
			If AbrirDialog("Item(s) relacionado(s) ao Produto com sucesso!" & vbCrLf & vbCrLf &
						   "Você deseja GUARDAR/SALVAR essa relação do Fornecedor com o(s) Produto(s)?",
						   "Item Relacionado",
						   frmDialog.DialogType.SIM_NAO,
						   frmDialog.DialogIcon.Question,
						   frmDialog.DialogDefaultButton.First) = DialogResult.Yes Then
				'
				Dim cItensSelected As Integer = dgvItens.SelectedRows.Count
				Dim atualItem As Integer = 1
				'
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				For Each r In dgvItens.SelectedRows
					'
					'--- Emit Info
					Info.InfoShow("Salvando relação Item => Produto... Item " & Format(atualItem, "00") & " de " & Format(cItensSelected, "00"))
					'
					'--- Get Item to Save
					Dim Item As clNFeItem = r.DataBoundItem
					'
					'--- Save the Relacao
					SalvarRelacao(Item, dbTran)
					'
					atualItem += 1
					'
				Next
				'
				Info.InfoHide()
				'
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Sub
	'
	'--- REMOVE RELATION ITEM <=> PRODUTO OF SELECTED ITEMS
	'----------------------------------------------------------------------------------
	Private Sub RemoveRelacaoItemProdutoSelected()
		'
		For Each r As DataGridViewRow In dgvItens.SelectedRows
			Dim item As clNFeItem = r.DataBoundItem
			'
			item.IDProduto = Nothing
			item.RGProduto = Nothing
			item.Produto = ""
			item.PCompra = Nothing
			item.DescontoCompra = Nothing
			'
		Next
		'
	End Sub
	'
	'--- VERIFICA SE A LISTA DE ITENS ESTA OK PARA RELACIONAR PRODUTOS
	'----------------------------------------------------------------------------------
	Private Function VerifyToInsertNewProduto() As Boolean
		'
		If dgvItens.SelectedRows.Count = 0 Then
			AbrirDialog("Não há nenhum Item selecionado ainda", "Selecionar",
						frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Return False
		End If
		'
		Dim PCompra As Double = 0
		Dim VDesconto As Double = -1
		'
		For Each r In dgvItens.SelectedRows
			Dim item As clNFeItem = r.DataBoundItem
			'
			'--- CHECK IS NOT INSERTED
			If Not IsNothing(item.IDProduto) Then
				AbrirDialog("Existem itens selecionados que já possuem uma relação com um Produto", "Seleção Inválida",
							frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
				Return False
			End If
			'
			'--- CHECK if Same PRECO
			If PCompra = 0 Then
				PCompra = item.vUnCom
			Else
				If PCompra <> item.vUnCom Then
					AbrirDialog("Existem itens selecionados que possuem Preço de Compra diferentes..." & vbNewLine &
								"Favor selecionar apenas itens que tenham o mesmo Preço de Compra.", "Seleção Inválida",
								frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
					Return False
				End If
			End If
			'
			'--- CHECK if Same DESCONTO
			If VDesconto < 0 Then
				VDesconto = item.DescontoNFe
			Else
				If VDesconto <> item.DescontoNFe Then
					AbrirDialog("Existem itens selecionados que possuem Desconto de Compra diferentes..." & vbNewLine &
								"Favor selecionar apenas itens que tenham o mesmo Desconto de Compra.", "Seleção Inválida",
								frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
					Return False
				End If
			End If
			'
		Next
		'
		Return True
		'
	End Function
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
			'Dim item As clNFeItem = dgvItens.CurrentRow.DataBoundItem
			Dim item As clNFeItem = dgvItens.SelectedRows(0).DataBoundItem
			Dim pBLL As New ProdutoBLL
			Dim IDFilial As Integer = Obter_FilialPadrao()
			'
			Dim prod As clProduto = pBLL.GetProduto_PorID(item.IDProduto, IDFilial)
			'
			Dim frm As New frmProduto(EnumFlagAcao.EDITAR, prod, Me)
			frm.MdiParent = My.Application.OpenForms().Item(0)
			AreSelectedRows = True
			Me.Visible = False
			frm.Show()
			'AreSelectedRows = False
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
		'--- 1. CREATE NEW PRODUTO
		'----------------------------------------------------------------------------------
		Dim prodEncontrado As clProduto = Nothing
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Check LIST of Selected Items
			If Not VerifyToInsertNewProduto() Then Exit Sub
			'
			'--- Get IDProduto and clProduto
			'---------------------------------------------------------------------------------
			Dim FirstItem As clNFeItem = dgvItens.SelectedRows(0).DataBoundItem
			Dim pBLL As New ProdutoBLL
			'
			'--- CREATE NEW PRODUTO
			'---------------------------------------------------------------------------------
			Dim prod As New clProduto With {
				.IDProduto = Nothing,
				.Produto = FirstItem.xProd,
				.CodBarrasA = FirstItem.cEAN,
				.DescontoCompra = FirstItem.DescontoCompra,
				.Movimento = 1,
				.NCM = FirstItem.NCM,
				.PCompra = FirstItem.vProd
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
				'
				AreSelectedRows = True
				Me.Visible = False
				frm.ShowDialog()
				AreSelectedRows = False
				'
				If frm.DialogResult = DialogResult.OK Then
					prodEncontrado = frm.propProduto
				End If
				'
			End Using
			'
			'--- CHECK IF NEW PRODUTO WAS INSERTED
			'----------------------------------------------------------------------------------
			If IsNothing(prodEncontrado.IDProduto) Then Exit Sub
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao OBTER o Produto para relacionar..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'
		'--- 2. TRY MAKE RELACIONAMENTO ITEM <=> PRODUTO
		'----------------------------------------------------------------------------------
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			MakeRelacionamentoItemProduto(prodEncontrado)
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Relacionar Item Produto..." & vbNewLine &
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
		'--- 1. GET AND INSERT NEW PRODUTO
		'----------------------------------------------------------------------------------
		Dim prodEncontrado As clProduto = Nothing
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- Check LIST of Selected Items
			If Not VerifyToInsertNewProduto() Then Exit Sub
			'
			'--- get produto texto
			Dim FirstItem As clNFeItem = dgvItens.SelectedRows(0).DataBoundItem
			Dim RGProdAnteriorEscolhido As Integer
			'
			'--- Open frmProcura ProdutoAntigo
			Using frm As New frmProdutosAntigosProcurar(FirstItem.xProd, RGTipoAnterior, Me)
				'
				AreSelectedRows = True
				Visible = False
				frm.ShowDialog()
				'AreSelectedRows = False
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
			prodEncontrado = New clProduto With {
				.IDProduto = Nothing,
				.RGProduto = RGProdAnteriorEscolhido,
				.Produto = FirstItem.xProd,
				.CodBarrasA = FirstItem.cEAN,
				.DescontoCompra = FirstItem.DescontoNFe,
				.Movimento = 1,
				.NCM = FirstItem.NCM,
				.PCompra = FirstItem.vUnCom.Replace(".", ",")
				}
			'
			'--- CHECK IF PRODUTO RGPRODUTO ALREADY EXISTS
			'---------------------------------------------------------------------------------
			If Not VerificaRGProduto(prodEncontrado.RGProduto) Then
				Exit Sub
			End If
			'
			'---TRY OPEN PRODUTO FORM
			Using frmProd As New frmProduto(EnumFlagAcao.INSERIR, prodEncontrado, Me, RGProdAnteriorEscolhido)
				'
				AreSelectedRows = True
				Visible = False
				frmProd.ShowDialog()
				AreSelectedRows = False
				'
				If frmProd.DialogResult <> DialogResult.OK Then Exit Sub
				'
				prodEncontrado = frmProd.propProduto
				'
			End Using
			'
			'--- CHECK IF NEW PRODUTO WAS INSERTED
			'----------------------------------------------------------------------------------
			If IsNothing(prodEncontrado.IDProduto) Then Exit Sub
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao OBTER o Produto para relacionar..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
		'
		'--- 2. TRY MAKE RELACIONAMENTO ITEM <=> PRODUTO
		'----------------------------------------------------------------------------------
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			MakeRelacionamentoItemProduto(prodEncontrado)
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Relacionar Item Produto..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- CHECK RGPRODUTO IN DB (VERIFY IS ALREADY INSERTED)
	'----------------------------------------------------------------------------------
	Private Function VerificaRGProduto(RGProduto As Integer) As Boolean
		'
		Try
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			Dim prodBLL As New ProdutoBLL
			Dim lista As New List(Of clProduto)
			lista = prodBLL.GetProdutos_Where("RGProduto = " & RGProduto)
			'
			If lista.Count = 0 Then
				Return True
			Else
				Dim ProdRG As clProduto = lista(0)
				'
				AbrirDialog("Já foi encontrado um Produto com esse mesmo número de Reg. Interno..." & vbNewLine &
							ProdRG.Produto.ToUpper & vbNewLine &
							"Favor anexar o produto existente ou alterar o registro interno do Produto.",
							"Reg. Interno Duplicado", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
				Return False
				'
			End If
			'
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao Verificar o RGProduto do novo produto..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False
			'
		Finally
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
		End Try
		'
	End Function
	'
#End Region
	'
#Region "INSERT COMPRA FUNCTIONS"
	'
	'--- CHECK IF IS POSSIBLE CHANGE STATUS
	'----------------------------------------------------------------------------------
	Private Sub TryEnableEstagioCompra()
		'
		If ItensNFe.Count = 0 Then propEstagio = 1
		'
		'--- CHECK ESTAGIO
		If propEstagio <> 3 Then Exit Sub
		'
		'--- CHECK FOUND Fornecedor AND Transportadora
		If IsNothing(FornecedorNFe.IDPessoa) Then Exit Sub
		If Not IsNothing(TranspNFe) AndAlso IsNothing(TranspNFe.IDPessoa) Then Exit Sub
		'
		'--- CHECK ITEMS FOUND
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
	'--- SAVE / INSERT COMPRA
	'----------------------------------------------------------------------------------
	Private Sub btnSalvarCompra_Click(sender As Object, e As EventArgs) Handles btnSalvarCompra.Click
		'
		'--- Verifica o FORNECEDOR
		Dim IDFornecedor As Integer = FornecedorNFe.IDPessoa
		Dim FornecedorUF As String = FornecedorNFe.UF
		'
		'--- Pergunta ao Usuário se Deseja inserir nova COMPRA
		If AbrirDialog("Você deseja realmente inserir uma NOVA COMPRA?",
					   "Inserir Nova Compra",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question) <> DialogResult.Yes Then
			Exit Sub
		End If
		'
		'--- INFO
		'----------------------------------------------------------------------------------
		Info.InfoShow("Inserindo uma nova Compra...")
		'
		'--- DEFINE DBTRAN
		'---------------------------------------------------------------------------------------
		Dim acesso As New AcessoControlBLL
		Dim dbTran As Object = acesso.GetNewAcessoWithTransaction
		'
		'--- Insere um novo Registro de COMPRA
		'---------------------------------------------------------------------------------------
		Dim cmpBLL As New CompraBLL
		Dim newCompra As New clCompra
		Dim tranBLL As New TransacaoBLL
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
				.FreteCobrado = 0
				.ICMSValor = 0
				.Despesas = 0
				.Descontos = 0
				.TotalCompra = 0
				.Observacao = ""
				'
				'--- TRANPORTADORA e FRETE
				If Not IsNothing(TranspNFe) Then
					'
					.IDTransportadora = TranspNFe.IDPessoa
					.FreteTipo = CByte(NotaNFe.NFe.infNFe.transp.modFrete) + 1
					'
					If NotaNFe.NFe.infNFe.transp.vol.Count > 0 Then
						.Volumes = NotaNFe.NFe.infNFe.transp.vol(0).qVol
					Else
						.Volumes = 0
					End If

				Else
					.FreteTipo = 0 '--- sem frete
				End If
				'
			End With
			'
			newCompra = cmpBLL.SalvaNovaCompra_Compra(newCompra, dbTran)
			'
			If IsNothing(newCompra) Then
				Throw New Exception("Um erro ocorreu ao salvar ao Inserir Nova Compra")
			End If
			'
			'--- INFO
			'----------------------------------------------------------------------------------
			Info.InfoShow("Inserindo Duplicatas A Pagar")
			'
			'--- INSERT APAGAR DUPS
			If _APagarList.Count > 0 Then
				'
				If Not InsertAPagarDups(newCompra, dbTran) Then
					'--- roolback
					acesso.RollbackAcessoWithTransaction(dbTran)
					Exit Sub
				End If
				'
			End If
			'
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- INFO
			'----------------------------------------------------------------------------------
			Info.InfoShow("Inserindo Items da Compra...")
			'
			'--- INSERT ITEMS
			InsertCompraItens(newCompra, dbTran)
			'
			'--- INFO
			'----------------------------------------------------------------------------------
			Info.InfoShow("Inserindo o registro da NFe na Compra...")
			'
			'--- INSERT NOTA
			InsertCompraNota(newCompra, dbTran)
			'
			'--- COMMIT
			acesso.CommitAcessoWithTransaction(dbTran)
			'
			'--- INFO
			'----------------------------------------------------------------------------------
			Info.InfoShow("Abrindo a nova Compra...")
			'
			'--- OPEN NEW COMPRA
			Dim frm As New frmCompra(newCompra) With {
				.MdiParent = frmPrincipal,
				.StartPosition = FormStartPosition.CenterScreen
			}
			Close()
			frm.Show()
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
			'--- INFO HIDE
			'----------------------------------------------------------------------------------
			Info.InfoHide()
			'
			'--- Ampulheta OFF
			Cursor = Cursors.Default
			'
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
				'Format(CDbl(item.vUnCom.Replace(".", ",")), "#,##0.00")
				'
				Dim newItem As New clTransacaoItem With {
				.IDProduto = item.IDProduto,
				.RGProduto = item.RGProduto,
				.Produto = item.Produto,
				.TransacaoData = Compra.TransacaoData,
				.IDTransacao = Compra.IDCompra,
				.Preco = CDbl(item.vUnCom),
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
	'--- INSERT COMPRA NFE IN NEW COMPRA
	'----------------------------------------------------------------------------------
	Private Sub InsertCompraNota(Compra As clCompra, dbTran As Object)
		'
		Dim Nota As clNotaFiscal = Nothing
		'
		Try
			'--- Remove all letters of Chave
			Dim chave As String = NotaNFe.NFe.infNFe.Id
			chave = Regex.Replace(chave, "[^0-9.]", "")
			'
			'--- Get Emissao Data Nfe
			Dim emissao As String = NotaNFe.NFe.infNFe.ide.dhEmi '+ "2019-08-08T10:40:00-03:00"
			Dim EmissaoData As Date = Date.SpecifyKind(emissao, DateTimeKind.Utc)
			'
			'--- Insere o novo ITEM no BD
			Nota = New clNotaFiscal With {
				.ChaveAcesso = chave,
				.EmissaoData = EmissaoData,
				.IDTransacao = Compra.IDCompra,
				.NotaNumero = NotaNFe.NFe.infNFe.ide.nNF,
				.NotaSerie = NotaNFe.NFe.infNFe.ide.serie,
				.NotaTipo = 1,
				.NotaValor = NotaNFe.NFe.infNFe.total.ICMSTot.vNF.Replace(".", ",")
				}
			'
		Catch ex As Exception
			Throw New AppException("Houve um exceção ao OBTER os dados da NOTA no BD..." & vbNewLine & ex.Message)
			Exit Sub
		End Try
		'
		'--- INSERT NEW NOTA IN BD
		Try
			Dim notaBLL As New NotaFiscalBLL
			'
			'--- INSERT NOTA IN DB
			notaBLL.InserirNova_Nota(Nota, dbTran)
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Sub
	'
	'--- INSERT ALL COMPRA DUPS A PAGAR IN NEW COMPRA
	'----------------------------------------------------------------------------------
	Private Function InsertAPagarDups(Compra As clCompra, dbTran As Object) As Boolean
		'
		Dim pagBLL As New APagarBLL
		Dim RGBanco As Short? = Nothing
		Dim IDCobrancaForma As Integer? = Nothing
		'
		'--- GET COBRANÇA FORMA
		Try
			Using fDup As New frmDespesaParcelamento(Me, False)
				'
				fDup.ShowDialog()
				'
				If fDup.DialogResult <> DialogResult.OK Then Return False
				'
				IDCobrancaForma = fDup.propIDCobrancaForma
				RGBanco = fDup.propRGBanco
				'
			End Using
			'
			If IDCobrancaForma = 0 Then
				Throw New AppException("Forma de cobrança inválida...")
			End If
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
		'--- Insere o novo APAGAR no BD
		Try
			'
			For Each pag In _APagarList
				'
				pag.IDCobrancaForma = IDCobrancaForma '--- 5 is CobrancaBancaria
				pag.IDOrigem = Compra.IDCompra
				pag.IDPessoa = Compra.IDPessoaOrigem
				pag.IDFilial = Compra.IDPessoaDestino
				'
				If Not IsNothing(RGBanco) Then
					pag.RGBanco = RGBanco
				End If
				'
				'--- INSERT APAGAR IN DB
				pagBLL.InserirNovo_APagar(pag, dbTran)
				'
			Next
			'
			Return True
			'
		Catch ex As Exception
			Throw New AppException("Houve um exceção ao INSERIR o a PAGAR no BD..." & vbNewLine & ex.Message)
		End Try
		'
	End Function
	'
#End Region '/ INSERT COMPRA FUNCTIONS
	'
#Region "VISUAL DESIGN"
	'
	Private Sub showToolTip(control As Control)
		'
		' Cria a ToolTip e associa com o Form container.
		Dim toolTip1 As New ToolTip()
		'
		' Define o delay para a ToolTip.
		With toolTip1
			.AutoPopDelay = 2000
			.InitialDelay = 2000
			.ReshowDelay = 500
			.IsBalloon = True
			.UseAnimation = True
			.UseFading = True
		End With
		'
		If control.Tag = "" Then
			toolTip1.Show("Clique aqui...", control, control.Width - 30, -40, 2000)
		Else
			toolTip1.Show(control.Tag, control, control.Width - 30, -40, 2000)
		End If
		'
		'
	End Sub
	'
	'--- ENABLE TOOLSTRIP
	'----------------------------------------------------------------------------------
	Private Sub btn_EnabledChanged(sender As Object, e As EventArgs) Handles btnCorrelacao.EnabledChanged, btnSalvarCompra.EnabledChanged
		'
		Dim control As Control = DirectCast(sender, Control)
		'
		If control.Enabled = True Then
			showToolTip(control)
		End If
		'
	End Sub
	'
	Private Sub tspMenu_VisibleChanged(sender As Object, e As EventArgs) Handles tspMenuFornecedor.VisibleChanged, tspMenuTransp.VisibleChanged
		'
		Dim control As Control = DirectCast(sender, Control)
		'
		If control.Visible = True Then
			showToolTip(control)
		End If
		'
	End Sub
	'
	'--- RESIZE FONT SIZE LABEL TO FIT ALL TEXT
	'----------------------------------------------------------------------------------
	Private Sub ResizeFontLabel(myLabel As Label)
		'
		Dim lblFont As Font = New Font(myLabel.Font.FontFamily, myLabel.Font.Size, myLabel.Font.Style)
		'
		While myLabel.Width < TextRenderer.MeasureText(myLabel.Text, lblFont).Width
			myLabel.Font = New Font(myLabel.Font.FontFamily, myLabel.Font.Size - 0.5F, myLabel.Font.Style)
			lblFont = New Font(myLabel.Font.FontFamily, myLabel.Font.Size, myLabel.Font.Style)
		End While
		'
	End Sub
	'
	'--- ONCLICK OPEN MENU
	'----------------------------------------------------------------------------------
	Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenuFornecedor.Click, btnMenuTransp.Click
		DirectCast(sender, ToolStripSplitButton).ShowDropDown()
	End Sub
	'
#End Region '/ VISUAL DESIGN
	'
#Region "INSERT FORNECEDOR AND TRANSPORTADORA"
	'
	'--- INSERT NEW FORNECEDOR
	'----------------------------------------------------------------------------------
	Private Sub btnInserirFornecedor_Click(sender As Object, e As EventArgs) Handles btnInserirFornecedor.Click
		'
		Try
			'
			'--- OPEN FRM FORNECEDOR
			Dim newForn As clFornecedor = OpenFrmFornecedor(FornecedorNFe)
			'
			If IsNothing(newForn) Then Exit Sub
			'
			'--- FORNECEDOR DEFINIDO
			FornecedorNFe.IDPessoa = newForn.IDPessoa
			tspMenuFornecedor.Visible = False
			'
			AbrirDialog("Fornecedor encontrado:" & vbCrLf & vbCrLf & newForn.Cadastro,
						"Fornecedor",
						frmDialog.DialogType.OK,
						frmDialog.DialogIcon.Information)
			'
			'--- TRY MAKE CORRELACAO AGAIN
			btnCorrelacao_Click(sender, e)
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Inserir novo fornecedor..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		'
	End Sub
	'
	'--- VINCULAR A FORNECEDOR EXISTENTE
	'----------------------------------------------------------------------------------------------
	Private Sub btnVincularCNPJFornecedor_Click(sender As Object, e As EventArgs) Handles btnVincularCNPJFornecedor.Click
		'
		'--- ASK USER
		If AbrirDialog("Deseja vincular o CNPJ da NFe com um Fornecedor existente?" & vbCrLf &
					   "CNPJ: " & FornecedorNFe.CNPJ,
					   "Vincular CNPJ Fornecedor",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question) = DialogResult.No Then
			Return
		End If
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- GET FORNECEDOR
			Dim forn As clFornecedor = Nothing
			'
			Using frmF As New frmFornecedorProcurar(True, Me)
				'
				frmF.ShowDialog()
				If frmF.DialogResult <> DialogResult.OK Then Exit Sub
				'
				forn = frmF.propFornecedor_Escolha
				'
			End Using
			'
			'--- MAKE RELACAO
			FornecedorNFe.IDPessoa = forn.IDPessoa
			lblRazaoSocial.Text += " (" & forn.Cadastro & ")"
			tspMenuFornecedor.Visible = False
			lblCNPJ.Text += " >>> " & forn.CNPJ
			'
			'--- SAVE RELACAO ? ASK USER
			If AbrirDialog("Fornecedor NFe relacionado com sucesso!" & vbCrLf & vbCrLf &
						   "Você deseja GUARDAR/SALVAR essa relação do Fornecedor para futuras associações?",
						   "Fornecedor Relacionado",
						   frmDialog.DialogType.SIM_NAO,
						   frmDialog.DialogIcon.Question,
						   frmDialog.DialogDefaultButton.First) = DialogResult.Yes Then
				'
				Dim db As New PessoaBLL
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				db.CreateCNPJRelacionado(forn.IDPessoa, FornecedorNFe.CNPJ, FornecedorNFe.Cadastro, FornecedorNFe.InscricaoEstadual)
				'
			End If
			'
			'--- TRY MAKE CORRELACAO AGAIN
			btnCorrelacao_Click(sender, e)
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Vincular CNPJ..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'
	'--- INSERT NEW TRANSPORTADORA
	'----------------------------------------------------------------------------------------------
	Private Sub btnInserirTransportadora_Click(sender As Object, e As EventArgs) Handles btnInserirTransportadora.Click
		'
		Try
			'
			'--- OPEN FRM TRANSPORTADORA
			Dim newTransp As clTransportadora = OpenFrmTransportadora(TranspNFe)
			'
			If IsNothing(newTransp) Then Exit Sub
			'
			'--- TRANSPORTADORA DEFINIDO
			TranspNFe.IDPessoa = newTransp.IDPessoa
			tspMenuTransp.Visible = False
			'
			AbrirDialog("Transportadora encontrada:" & vbCrLf & vbCrLf & newTransp.Cadastro,
						"Transportadora", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
			'
			'--- TRY MAKE CORRELACAO AGAIN
			btnCorrelacao_Click(sender, e)
			'
		Catch ex As Exception
			'
			MessageBox.Show("Uma exceção ocorreu ao Inserir nova TRANSPORTADORA..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		'
	End Sub
	'
	'--- VINCULAR A TRANSPORTADORA EXISTENTE
	'----------------------------------------------------------------------------------------------
	Private Sub btnVincularCNPJTransp_Click(sender As Object, e As EventArgs) Handles btnVincularCNPJTransp.Click
		'
		'--- CHECK TranspNFe
		If TranspNFe Is Nothing Then
			Exit Sub
		End If
		'
		'--- ASK USER
		If AbrirDialog("Deseja vincular o CNPJ da Transportadora na NFe com uma já existente?" & vbCrLf &
					   "CNPJ: " & TranspNFe.CNPJ,
					   "Vincular CNPJ Transportadora",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question) = DialogResult.No Then
			Return
		End If
		'
		Try
			'--- Ampulheta ON
			Cursor = Cursors.WaitCursor
			'
			'--- GET TRANSPORTADORA
			Dim transp As clTransportadora = Nothing
			'
			Using frmT As New frmTransportadoraProcurar(True, Me)
				'
				frmT.ShowDialog()
				If frmT.DialogResult <> DialogResult.OK Then Exit Sub
				'
				transp = frmT.propTransportadora_Escolha
				'
			End Using
			'
			'--- MAKE RELACAO
			TranspNFe.IDPessoa = transp.IDPessoa
			lblTransportadora.Text += " (" & transp.Cadastro & ")"
			tspMenuTransp.Visible = False
			lblTranspCNPJ.Text += " >>> " & transp.CNPJ
			'
			'--- SAVE RELACAO ? ASK USER
			If AbrirDialog("Transportadora NFe relacionada com sucesso!" & vbCrLf & vbCrLf &
						   "Você deseja GUARDAR/SALVAR essa relação da Transportadora para futuras associações?",
						   "Transportadora Relacionada",
						   frmDialog.DialogType.SIM_NAO,
						   frmDialog.DialogIcon.Question,
						   frmDialog.DialogDefaultButton.First) = DialogResult.Yes Then
				'
				Dim db As New PessoaBLL
				'
				'--- Ampulheta ON
				Cursor = Cursors.WaitCursor
				'
				db.CreateCNPJRelacionado(transp.IDPessoa, TranspNFe.CNPJ, TranspNFe.Cadastro, TranspNFe.InscricaoEstadual)
				'
			End If
			'
			'--- TRY MAKE CORRELACAO AGAIN
			btnCorrelacao_Click(sender, e)
			'
		Catch ex As Exception
			MessageBox.Show("Uma exceção ocorreu ao Vincular CNPJ..." & vbNewLine &
							ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			'--- Ampulheta OFF
			Cursor = Cursors.Default
		End Try
		'
	End Sub
	'
	'--- CHECK IF IS POSSIBLE CHANGE STATUS
	'----------------------------------------------------------------------------------
	Private Sub TryEnableEstagioPesquisado()
		'
		If ItensNFe.Count = 0 Then propEstagio = 1
		'
		'--- CHECK ESTAGIO
		If propEstagio <> 2 Then Exit Sub
		'
		'--- CHECK FOUND Fornecedor AND Transportadora
		If IsNothing(FornecedorNFe.IDPessoa) Then Exit Sub
		If IsNothing(TranspNFe.IDPessoa) Then Exit Sub
		'
		'--- CHECK ITEMS FOUND
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
#End Region '/ INSERT FORNECEDOR AND TRANSPORTADORA
	'
End Class
