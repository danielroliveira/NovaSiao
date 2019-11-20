Imports CamadaBLL
Imports CamadaDTO
'
Public Class AcaoGlobal
	'
	'================================================================================
	' EFETUA NOVA VENDA A PRAZO
	'================================================================================
	Public Function VendaPrazo_Nova() As clVenda
		'
		'--- Questiona o VENDEDOR
		Dim fFunc As New frmFuncionarioEscolher(True)
		fFunc.ShowDialog()
		If fFunc.DialogResult = DialogResult.Cancel Then Return Nothing
		'
		Dim IDFunc As Integer = fFunc.IDEscolhido
		'
		'--- Questiona o CLIENTE
		Dim fCli As New frmClienteProcurar()
		fCli.ShowDialog()
		If fCli.DialogResult = DialogResult.Cancel Then Return Nothing
		'
		Dim IDCli As Integer = fCli.propClienteEscolhido.IDPessoa
		Dim UFCli As String = fCli.propClienteEscolhido.UF
		'
		'--- Pergunta ao Usuário se Deseja inserir nova venda
		If AbrirDialog("Você deseja realmente inserir uma nova Venda à Prazo?",
					   "Inserir Nova Venda", frmDialog.DialogType.OK,
					   frmDialog.DialogIcon.Question) <> DialogResult.OK Then
			Return Nothing
		End If
		'
		'--- Insere um novo Registro de Venda à Prazo
		'---------------------------------------------------------------------------------------
		Dim vndBLL As New VendaBLL
		Dim newVenda As New clVenda
		Dim tranBLL As New TransacaoBLL
		'
		Try
			'--- Define os valores iniciais
			With newVenda
				.IDPessoaDestino = IDCli
				.IDPessoaOrigem = Obter_FilialPadrao()
				.IDOperacao = 1
				.IDSituacao = TransacaoBLL.EnumTransacaoSituacao.INICIADA
				.IDUser = UsuarioAtual.IdUser
				If UFCli = ObterDefault("UF") Then
					.CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.Venda, TransacaoBLL.EnumCFOPUFDestino.DentroDaUF)
				Else
					.CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.Venda, TransacaoBLL.EnumCFOPUFDestino.ForaDaUF)
				End If
				.TransacaoData = ObterDefault("DataPadrao")
				.IDDepartamento = 1
				.IDVendedor = IDFunc
				.CobrancaTipo = 2 '--- venda à prazo
				.FreteTipo = 0
				.ValorProdutos = 0
				.ValorFrete = 0
				.ValorImpostos = 0
				.ValorAcrescimos = 0
				.JurosMes = 0
				.IDVendaTipo = 1 '--- varejo
			End With
			'
			newVenda = vndBLL.SalvaNovaVenda_Procedure_Venda(newVenda)
			If IsNothing(newVenda) Then
				MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Venda",
								"Inserir Nova Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return Nothing
			End If
		Catch ex As Exception
			MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Venda" & vbNewLine &
							vbNewLine & ex.Message,
							"Inserir Nova Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return Nothing
		End Try
		'
		Return newVenda
		'
	End Function
	'
	'================================================================================
	' EFETUA NOVA VENDA A VISTA
	'================================================================================
	Public Function VendaAVista_Nova() As clVenda
		'
		'--- Questiona o VENDEDOR
		Dim fFunc As New frmFuncionarioEscolher(True)
		fFunc.ShowDialog()
		If fFunc.DialogResult = DialogResult.Cancel Then Return Nothing
		'
		Dim IDFunc As Integer = fFunc.IDEscolhido
		'
		'--- Determina o CLIENTE VAREJO
		Dim IDCli As Integer = 0 '--- Cliente Varejo
		'
		'--- Define outros Valores
		Dim VendaData As Date = ObterDefault("DataPadrao")
		Dim FilialPadrao As String = ObterDefault("FilialDescricao")
		'
		'--- Pergunta ao Usuário se Deseja inserir nova venda
		If AbrirDialog("Você deseja realmente inserir uma NOVA VENDA À VISTA?" &
					   vbNewLine & vbNewLine &
					   "Data da Venda: " & VendaData & vbNewLine &
					   "Filial: " & FilialPadrao.ToUpper,
					   "Inserir Nova Venda", frmDialog.DialogType.OK,
					   frmDialog.DialogIcon.Question) <> DialogResult.OK Then Return Nothing
		'
		'--- Insere um novo Registro de Venda
		'---------------------------------------------------------------------------------------
		Dim vndBLL As New VendaBLL
		Dim newVenda As New clVenda
		Dim tranBLL As New TransacaoBLL
		'
		'--- Define os valores iniciais
		With newVenda
			.IDPessoaDestino = IDCli
			.IDPessoaOrigem = Obter_FilialPadrao()
			.ApelidoFilial = FilialPadrao
			.IDOperacao = 1
			.IDSituacao = TransacaoBLL.EnumTransacaoSituacao.INICIADA
			.IDUser = UsuarioAtual.IdUser
			.CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.Venda, TransacaoBLL.EnumCFOPUFDestino.DentroDaUF)
			.TransacaoData = VendaData
			.IDDepartamento = 1
			.IDVendedor = IDFunc
			.CobrancaTipo = 1 '--- venda à vista
			.FreteTipo = 0
			.ValorProdutos = 0
			.ValorFrete = 0
			.ValorImpostos = 0
			.ValorAcrescimos = 0
			.JurosMes = 0
			.IDVendaTipo = 1 '--- varejo
		End With
		'
		Try
			newVenda = vndBLL.SalvaNovaVenda_Procedure_Venda(newVenda)
			'
			If IsNothing(newVenda) Then
				MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Venda",
								"Inserir Nova Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return Nothing
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Venda" & vbNewLine &
							vbNewLine & ex.Message,
							"Inserir Nova Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return Nothing
		End Try
		'
		Return newVenda
		'
	End Function
	'
	'================================================================================
	' EFETUA NOVA COMPRA
	'================================================================================
	Public Function Compra_Nova() As clCompra
		'
		'--- Questiona o FORNECEDOR
		Dim fForn As New frmFornecedorProcurar(True)
		fForn.ShowDialog()
		If fForn.DialogResult = DialogResult.Cancel Then Return Nothing
		'
		Dim IDFornecedor As Integer = fForn.propFornecedor_Escolha.IDPessoa
		Dim FornecedorUF As String = fForn.propFornecedor_Escolha.UF
		'
		'--- Pergunta ao Usuário se Deseja inserir nova COMPRA
		If AbrirDialog("Você deseja inserir uma NOVA COMPRA?" & vbNewLine &
					   fForn.propFornecedor_Escolha.Cadastro,
					   "Inserir Nova Compra",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question) <> DialogResult.Yes Then
			Return Nothing
		End If
		'
		'--- Insere um novo Registro de COMPRA
		'---------------------------------------------------------------------------------------
		Dim cmpBLL As New CompraBLL
		Dim newCompra As New clCompra
		Dim tranBLL As New TransacaoBLL
		'
		Try
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
			newCompra = cmpBLL.SalvaNovaCompra_Compra(newCompra)
			If IsNothing(newCompra) Then
				MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Compra",
								"Inserir Nova Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return Nothing
			End If
		Catch ex As Exception
			MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Compra" & vbNewLine &
							vbNewLine & ex.Message,
							"Inserir Nova Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return Nothing
		End Try
		'
		Return newCompra
		'
	End Function
	'
	'================================================================================
	' EFETUA NOVA SIMPLES SAIDA
	'================================================================================
	Public Function SimplesSaida_Nova() As clSimplesSaida
		'
		'--- Questiona o CLIENTE
		Dim frmF As New frmFilialEscolher()
		frmF.ShowDialog()
		If frmF.DialogResult = DialogResult.Cancel Then Return Nothing
		'
		Dim IDFil As Integer = frmF.propFilial.IDPessoa
		Dim Filial As String = frmF.propFilial.ApelidoFilial
		'
		'--- Verifica se a Filial escolhida é a mesma filialPadrao
		Dim IDFilialPadrao As Integer = Obter_FilialPadrao()
		'
		If IDFil = IDFilialPadrao Then
			'--- Informa ao Usuário sobre Filial diferente
			MessageBox.Show("Não é possível efetuar uma Simples Saída para a Filial Padrão..." &
							vbNewLine &
							"A Filial escolhida precisa ser diferente da Filial Atual:" &
							vbNewLine & vbNewLine &
							ObterConfigValorNode("FilialDescricao").ToUpper,
							"Inserir Nova Simples Saída", MessageBoxButtons.OKCancel,
							MessageBoxIcon.Information)
			Return Nothing
		End If
		'
		'--- Pergunta ao Usuário se Deseja inserir nova simples Saída
		If AbrirDialog("Você deseja realmente inserir uma nova Simples Saída para a Filial" &
					   vbNewLine & vbNewLine & Filial.ToUpper,
					   "Inserir Nova Simples Saída", frmDialog.DialogType.OK,
					   frmDialog.DialogIcon.Question) <> DialogResult.OK Then
			Return Nothing
		End If
		'
		'--- Insere um novo Registro de Simples Saída
		'---------------------------------------------------------------------------------------
		Dim sBLL As New SimplesMovimentacaoBLL
		Dim newSimples As New clSimplesSaida With {
			.IDPessoaDestino = IDFil,
			.IDPessoaOrigem = IDFilialPadrao,
			.IDOperacao = 4, '--- SIMPLES SAIDA
			.CFOP = 1152,
			.IDSituacao = TransacaoBLL.EnumTransacaoSituacao.INICIADA,
			.IDUser = UsuarioAtual.IdUser,
			.TransacaoData = ObterDefault("DataPadrao")}
		'
		Try
			'Salva no BD
			newSimples = sBLL.InsertSimplesSaida_Procedure_Classe(newSimples)
			'
			If IsNothing(newSimples) Then
				MessageBox.Show("Um erro ocorreu ao inserir Nova Simples Saída",
								"Inserir Nova Simples Saída", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return Nothing
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Simples Saída" & vbNewLine &
							vbNewLine & ex.Message,
							"Inserir Nova Simples Saída", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return Nothing
		End Try
		'
		Return newSimples
		'
	End Function
	'
	'================================================================================
	' EFETUA NOVA DEVOLUCAO SAIDA
	'================================================================================
	Public Function DevolucaoSaida_Nova() As clDevolucaoSaida
		'
		'--- Questiona o FORNECEDOR
		Dim fForn As New frmFornecedorProcurar(True)
		fForn.ShowDialog()
		If fForn.DialogResult = DialogResult.Cancel Then Return Nothing
		'
		Dim IDFornecedor As Integer = fForn.propFornecedor_Escolha.IDPessoa
		Dim FornecedorUF As String = fForn.propFornecedor_Escolha.UF
		'
		'--- Pergunta ao Usuário se Deseja inserir nova DEVOLUCAO
		If AbrirDialog("Você deseja realmente criar uma NOVA DEVOLUÇÃO?",
					   "Inserir Nova Devolução", frmDialog.DialogType.OK,
					   frmDialog.DialogIcon.Question) <> DialogResult.OK Then
			Return Nothing
		End If
		'
		'--- Insere um novo Registro de DEVOLUCAO
		'---------------------------------------------------------------------------------------
		Dim devBLL As New DevolucaoSaidaBLL
		Dim newDev As New clDevolucaoSaida
		Dim tranBLL As New TransacaoBLL
		'
		Try
			'--- Define os valores iniciais
			With newDev
				.IDPessoaDestino = IDFornecedor
				.IDPessoaOrigem = Obter_FilialPadrao()
				.IDOperacao = 6
				.IDSituacao = TransacaoBLL.EnumTransacaoSituacao.INICIADA
				.IDUser = UsuarioAtual.IdUser
				If FornecedorUF = ObterDefault("UF") Then
					.CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.Compra, TransacaoBLL.EnumCFOPUFDestino.DentroDaUF)
				Else
					.CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.Compra, TransacaoBLL.EnumCFOPUFDestino.ForaDaUF)
				End If
				.TransacaoData = ObterDefault("DataPadrao")
				.FreteTipo = 0 '--- sem frete
				.ValorDescontos = 0
				.ValorAcrescimos = 0
				.Observacao = ""
			End With
			'
			newDev = devBLL.Insert_Devolucao(newDev)
			'
			If IsNothing(newDev) Then
				MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Devolução",
								"Inserir Nova Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return Nothing
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Devolução" & vbNewLine &
							vbNewLine & ex.Message,
							"Inserir Nova Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return Nothing
		End Try
		'
		Return newDev
		'
	End Function
	'
	'================================================================================
	' EFETUA NOVA CONSIGNACAO DE ENTRADA
	'================================================================================
	Public Function ConsignacaoEntrada_Nova() As clConsignacao
		'
		'--- Questiona o FORNECEDOR
		Dim fForn As New frmFornecedorProcurar(True)
		fForn.ShowDialog()
		If fForn.DialogResult = DialogResult.Cancel Then Return Nothing
		'
		Dim IDFornecedor As Integer = fForn.propFornecedor_Escolha.IDPessoa
		Dim FornecedorUF As String = fForn.propFornecedor_Escolha.UF
		'
		'--- Pergunta ao Usuário se Deseja inserir nova COMPRA
		If AbrirDialog("Você deseja inserir uma NOVA CONSIGNAÇÃO?" & vbNewLine &
					   fForn.propFornecedor_Escolha.Cadastro,
					   "Inserir Nova Consignação",
					   frmDialog.DialogType.SIM_NAO,
					   frmDialog.DialogIcon.Question) <> DialogResult.Yes Then
			Return Nothing
		End If
		'
		'--- Insere um novo Registro de COMPRA
		'---------------------------------------------------------------------------------------
		Dim consigBLL As New ConsignacaoBLL
		Dim newConsig As New clConsignacao
		Dim tranBLL As New TransacaoBLL
		'
		Try
			'--- Define os valores iniciais
			With newConsig
				.IDPessoaDestino = Obter_FilialPadrao()
				.IDPessoaOrigem = IDFornecedor
				.IDOperacao = 7
				.IDSituacao = TransacaoBLL.EnumTransacaoSituacao.INICIADA
				.IDUser = UsuarioAtual.IdUser
				If FornecedorUF = ObterDefault("UF") Then
					.CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.ConsignacaoEntrada, TransacaoBLL.EnumCFOPUFDestino.DentroDaUF)
				Else
					.CFOP = tranBLL.ObterCFOP(TransacaoBLL.EnumOperacao.ConsignacaoEntrada, TransacaoBLL.EnumCFOPUFDestino.ForaDaUF)
				End If
				.TransacaoData = ObterDefault("DataPadrao")
				.FreteTipo = 0 '--- sem frete
				.FreteCobrado = 0
				.ICMSValor = 0
				.Despesas = 0
				.Descontos = 0
				.TotalConsignacao = 0
				.Observacao = ""
			End With
			'
			newConsig = consigBLL.InsertConsignacaoEntrada(newConsig)
			'
			If IsNothing(newConsig) Then
				MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Consignação",
								"Inserir Nova Consignação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return Nothing
			End If
			'
		Catch ex As Exception
			MessageBox.Show("Um erro ocorreu ao salvar ao Inserir Nova Consignação" & vbNewLine &
							vbNewLine & ex.Message,
							"Inserir Nova Consignação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return Nothing
		End Try
		'
		Return newConsig
		'
	End Function
	'
End Class
'
'
'==========================================================================================
' CONTROLE DO INFO MESSAGE FRM PRINCIPAL
'==========================================================================================
Public Class Info
    '
    Public Shared Sub InfoShow(message As String)
        '
        Dim frmP As frmPrincipal = My.Application.OpenForms().OfType(Of frmPrincipal).First
        '
        frmP.InfoMessageShow(message)
        '
    End Sub
    '
    Public Shared Sub InfoHide()
        '
        Dim frmP As frmPrincipal = My.Application.OpenForms().OfType(Of frmPrincipal).First
        '
        frmP.InfoMessageHide()
        '
    End Sub
    '
End Class