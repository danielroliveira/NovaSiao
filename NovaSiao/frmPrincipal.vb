Imports System.IO
Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmPrincipal
    '
    '========================================================================================================
    ' CONFIGURACAO INICIAL
    '========================================================================================================
#Region "FORM PRINCIPAL"
    Private _DataPadrao As Date
    Private _ContaPadrao As clConta
    '
    '========================================================================================================
    ' PROPRIEDADES PUBLICAS
    '========================================================================================================
    '
    '--- PROP DATA PADRAO: DEFINE O LABEL E A DATA PADRAO DO SISTEMA
    Public Property propDataPadrao() As Date
        Get
            Return _DataPadrao
        End Get
        Set(ByVal value As Date)
            _DataPadrao = value
            '
            '--- define a data padrao no config
            SetarDefault("DataPadrao", value.ToShortDateString)
            '
            '--- define a label da data padrao
            lblDataSis.Text = Format(value, "dd/MM")
            '
        End Set
    End Property
    '
    '--- PROP CONTA: DEFINE O LABEL DA CONTA PADRAO
    Public Property propContaPadrao() As clConta
        Get
            Return _ContaPadrao
        End Get
        Set(ByVal value As clConta)
            _ContaPadrao = value
            '
            '--- define a conta no config
            SetarDefault("ContaDescricao", value.Conta)
            SetarDefault("FilialDescricao", value.ApelidoFilial)
            '
            '--- define as labels da conta e Filial
            lblConta.Text = value.Conta
            lblFilial.Text = value.ApelidoFilial
            '
        End Set
    End Property
    '
    '========================================================================================================
    ' EVENTO LOAD
    '========================================================================================================
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        '--- INICIA APLICACAO COM O MENU DESABILITADO
        SContainerPrincipal.Enabled = False
        '
        ' VERIFICA SE EXISTE CONFIG DO CAMINHO DO BD
        '----------------------------------------------------------------
        Dim acessoBLL As New AcessoControlBLL
        '
        Dim TestAcesso As String = acessoBLL.GetConString
        '
        If String.IsNullOrEmpty(TestAcesso) Then
            Dim fcString As New frmConnString
            '
            fcString.ShowDialog()
            '
            If fcString.DialogResult = DialogResult.Cancel Then
                Application.Exit()
                Exit Sub
            End If
            '
        End If
        '
        ' ABRE E VERIFICA O LOGIN DO USUARIO
        '----------------------------------------------------------------
        Dim frmLog As New frmLogin
        Dim contaInicial As New clConta

        frmLog.ShowDialog()

        If frmLog.DialogResult = DialogResult.No Then
            Application.Exit()
            Exit Sub
        End If
        '
        ' VERFICA SE O ARQUIVO DE CONFIG FOI ENCONTRADO
        '----------------------------------------------------------------
        If VerificaConfig() = False Then
            Application.Exit()
            Exit Sub
        End If
        '        
        ' VERFICA SE HA CONTA PADRAO ATIVA
        '----------------------------------------------------------------
        contaInicial = Verifica_ContaFilial()
        '
        If IsNothing(contaInicial) OrElse IsNothing(contaInicial.IDConta) Then
            Application.Exit()
            Exit Sub
        End If
        '
        ' DETERMINA A CONTA ATIVA | FILIAL ATIVA | DATAPADRAO
        '----------------------------------------------------------------
        Try
            '
            If IsNothing(contaInicial.IDFilial) Then
                Throw New Exception("Não foi possível salvar arquivo de configuração...")
            End If
            '
            SetarDefault("FilialPadrao", contaInicial.IDFilial)
            propContaPadrao = contaInicial
            '
            '--- configurar DATAPADRAO
            If Not IsNothing(contaInicial.BloqueioData) Then
                '
                '--  adiciona um dia à data do caixa final ???
                Dim dtPadrao As Date = contaInicial.BloqueioData
                'dtPadrao = dtPadrao.AddDays(1)
                '
                '-- verifica se a data adicionada é DOMINGO, sendo adiciona um dia
                If dtPadrao.DayOfWeek = DayOfWeek.Sunday Then dtPadrao.AddDays(1)
                '
                '-- define a propriedade DATA PADRAO
                propDataPadrao = dtPadrao.ToShortDateString
                '
            Else
                '
                MessageBox.Show("A CONTA PADRÃO escolhida: " & contaInicial.Conta.ToUpper & vbNewLine &
                                "ainda não tem data de bloqueio definida..." & vbNewLine &
                                "Logo a DATA PADRÃO do sistema será escolhida como" & vbNewLine &
                                "DATA ATUAL: " & Now.ToLongDateString, "Data Padrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '
                propDataPadrao = Today.ToShortDateString
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção ao salvar o arquivo de configuração..." & vbNewLine &
                            ex.Message & vbNewLine & vbNewLine &
                            "O programa será finalizado...", "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
        '
        lblFilial.Text = ObterDefault("FilialDescricao")
        '
        'HABILITA A VERSAO E O TITULO
        '----------------------------------------------------------------
        Dim Versao As String = Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
        Dim EmpresaNomeFantasia As String = ObterConfigValorNode("NomeFantasia")
        lblVersao.Text = Versao
        lblTituloGeral.Text += ": " + EmpresaNomeFantasia
        '
        'HABILITA O MENU
        '----------------------------------------------------------------
        SContainerPrincipal.Enabled = True
        '
        ' ATUALIZA O MENU CONFORME O USUARIO ACESSO
        MenuUserAcesso()
        '
        ' INICIALIZA O TIMER DA HORA
        '----------------------------------------------------------------
        'lblHora.Text = DateTime.Now.ToShortTimeString
        '
        ' HABILITA O HANDLER DE ABERTURA DO MENU
        '----------------------------------------------------------------
        MenuOpen_AdHandler()

    End Sub
    '
    '========================================================================================================
    ' VERIFICA CONFIG
    '========================================================================================================
    Private Function VerificaConfig() As Boolean
        '
        If File.Exists(Application.StartupPath & "\ConfigFiles\Config.xml") = False Then
            '
            If UsuarioAtual.UsuarioAcesso > 1 Then ' não é administrador do sistema
                MessageBox.Show("Arquivo de Configuração não foi encontrado!" & vbNewLine &
                                "Seu LOGIN não tem acesso ao arquivo de Configuração..." & vbNewLine &
                                "Comunique-se com o administrador do sistema.",
                                "Erro de Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            MessageBox.Show("Arquivo de Configuração não foi encontrado!", "Erro de Arquivo", MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            '
            ' abre o form de config
            Dim frmC As New frmConfig
            frmC.ShowDialog()
            '
            ' se não existe o config, então fecha a aplicação
            If File.Exists(Application.StartupPath & "\ConfigFiles\Config.xml") = False Then
                MessageBox.Show("Arquivo de Configuração ainda não foi encontrado!" & vbNewLine &
                                "A aplicação será fechada...",
                                "Erro de Arquivo", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
        '
    End Function
    '
    '========================================================================================================
    ' VERIFICA CONTA | FILIAL | DATA PADRAO
    '========================================================================================================
    Private Function Verifica_ContaFilial() As clConta
        '
        Dim mBLL As New MovimentacaoBLL
        Dim AbrirConfig As Boolean = False
        Dim myConta As New clConta
        '
        '--- VERIFICA CONTA
        If IsNothing(Obter_ContaPadrao) Then
            AbrirConfig = True
        Else
            Try
                '
                myConta = mBLL.Conta_GET_PorIDConta(Obter_ContaPadrao)
                '
                If IsDBNull(myConta.IDConta) Then
                    AbrirConfig = True
                Else
                    AbrirConfig = False
                End If
                '
            Catch ex As Exception
                MessageBox.Show("Ocorreu uma exceção inesperada ao obter a Conta Padrão:" & vbNewLine &
                                ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
            '
        End If
        '
        If AbrirConfig = True Then
            MessageBox.Show("Ainda não foi encontrada nenhuma CONTA PADRÃO no sistema..." & vbNewLine & vbNewLine &
                            "Favor inserir e escolher uma CONTA padrão no arquivo do sistema", "Conta Padrão", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            '
            ' abre o form de config
            Dim frmC As New frmConfig
            frmC.ShowDialog()
            '
            ' TESTA NOVAMENTE
            ' se ainda não existe filial, então fecha a aplicação
            '---------------------------------------------------------------------------------
            If IsNothing(Obter_ContaPadrao) Then
                AbrirConfig = True
            Else
                Try
                    '
                    myConta = mBLL.Conta_GET_PorIDConta(Obter_ContaPadrao)
                    '
                    If IsDBNull(myConta.IDConta) Then
                        AbrirConfig = True
                    Else
                        AbrirConfig = False
                    End If
                    '
                Catch ex As Exception
                    MessageBox.Show("Ocorreu uma exceção inesperada ao obter a Conta Padrão:" & vbNewLine &
                                    ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                '
            End If
        End If
        '
        If AbrirConfig = True Then
            MessageBox.Show("Ainda não foi encontrado nenhuma Conta Padrão no sistema!" & vbNewLine &
                            "A aplicação será fechada...",
                            "Conta Inespecífica", MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation)
            Return Nothing
        Else
            Return myConta
        End If
        '
    End Function
    '
    '========================================================================================================
    'PERMITIR OU PROIBIR ACESSO DOS USERS AO MENU PRINCIPAL
    '========================================================================================================
    Private Sub MenuUserAcesso()
        '
        Dim c As ToolStripItem
        Dim t As ToolStripSplitButton
        '
        For Each c In tsPrincipal.Items
            If c.GetType Is GetType(ToolStripSplitButton) Then
                t = c
                Dim itm As ToolStripItem

                For Each itm In t.DropDownItems
                    If itm.GetType Is GetType(ToolStripMenuItem) Then
                        '
                        Select Case UsuarioAtual.UsuarioAcesso
                            '
                            Case 1 ' Administrador
                                itm.Enabled = True
                            Case 2 ' Usuário Senior
                                If itm.Tag = 1 Then
                                    itm.Enabled = False
                                Else
                                    itm.Enabled = True
                                End If
                            Case 3 ' Usuário Comum
                                If itm.Tag < 3 Then
                                    itm.Enabled = False
                                Else
                                    itm.Enabled = True
                                End If
                        End Select
                        '
                    End If
                Next
            End If
        Next
    End Sub
    '
    '========================================================================================================
    ' ACOES DO FORM PRINCIPAL
    '========================================================================================================
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Application.Exit()
    End Sub
    '
    Private Sub tsPrincipal_GotFocus(sender As Object, e As EventArgs) Handles tsPrincipal.GotFocus
        tsbClientes.Select()
    End Sub
    '
    Private Sub btnMinimizer_Click(sender As Object, e As EventArgs) Handles btnMinimizer.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    '
    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    lblHora.Text = DateTime.Now.ToShortTimeString
    'End Sub
    '
    Private Sub tsbButtonClick(sender As Object, e As EventArgs)
        '
        DirectCast(sender, ToolStripSplitButton).ShowDropDown()
        '
    End Sub
    '
    Private Sub MenuOpen_AdHandler()
        '
        For Each c In tsPrincipal.Items
            If (c.GetType Is GetType(ToolStripSplitButton)) Then
                AddHandler DirectCast(c, ToolStripSplitButton).ButtonClick, AddressOf tsbButtonClick
                AddHandler DirectCast(c, ToolStripSplitButton).MouseHover, AddressOf tsbButtonClick
            End If
        Next
        '
    End Sub
    '
#End Region
    '
    '========================================================================================================
    ' MENU CLIENTE
    '========================================================================================================
#Region "MENU CLIENTE"
    '
    Private Sub miClienteNovo_Click(sender As Object, e As EventArgs) Handles miClienteNovo.Click
        '
        Dim frmCN As New frmClienteNovo
        frmCN.MdiParent = Me
        frmCN.Show()
        OcultaMenuPrincipal()
        '
    End Sub
    '
    Private Sub miClienteProcurar_Click(sender As Object, e As EventArgs) Handles miClienteProcurar.Click
        '
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        Dim frm As New frmClienteProcurar
        frm.ShowDialog()
        '
        If frm.DialogResult = DialogResult.Cancel Then
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            Exit Sub
        End If
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            If frm.propClienteEscolhido.PessoaTipo = 1 Then ' PESSOA FÍSICA
                ' ABRIR FORMULÁRIO CLIENTEPF
                OcultaMenuPrincipal()

                Dim cliBll As New ClientePF_BLL

                Dim myCliPF As clClientePF = cliBll.GetClientePF_PorID(frm.propClienteEscolhido.IDPessoa)
                Dim frmCli As New frmClientePF(EnumFlagAcao.EDITAR, myCliPF)
                frmCli.MdiParent = Me
                frmCli.Show()
            ElseIf frm.propClienteEscolhido.PessoaTipo = 2 Then ' PESSOA JURÍDICA
                ' ABRIR FORMULÁRIO CLIENTEPJ
                OcultaMenuPrincipal()

                Dim cliBLL As New ClientePJ_BLL

                Dim myCliPJ As clClientePJ = cliBLL.GetClientesPJ_PorID(frm.propClienteEscolhido.IDPessoa)
                Dim frmCli As New frmClientePJ(EnumFlagAcao.EDITAR, myCliPJ)
                frmCli.MdiParent = Me
                frmCli.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MostraMenuPrincipal()
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try

    End Sub
    '
    Private Sub miClienteAtividades_Click(sender As Object, e As EventArgs) Handles miClienteAtividades.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmCA As New frmClienteAtividades
            frmCA.MdiParent = Me
            frmCA.Show()
            OcultaMenuPrincipal()
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
    Private Sub miGerarParaAniversariantes_Click(sender As Object, e As EventArgs) Handles miGerarParaAniversariantes.Click
        '
        Try
            '
            Dim MesRef As Integer = Month(Today)
            '
            Using fMes As New frmDataMesAno("Informe o Mês do Aniversário para consulta...", MesRef, Me)
                fMes.ShowDialog()
                If fMes.DialogResult <> vbOK Then Exit Sub
                '
                MesRef = fMes.propMes
                '
            End Using
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- INSERT NIVER
            Dim cBLL As New ClientePF_BLL
            Dim CountNiver As Integer = cBLL.ClienteSearchInsertAniversariantes(MesRef)
            Dim Mensagem As String = ""
            '
            If CountNiver = 0 Then
                Mensagem = "Não nenhum cliente com aniversário no mês selecionado..."
            ElseIf CountNiver = 1 Then
                Mensagem = "Operação de Inserção concluída com sucesso!" & vbNewLine &
                           "Foi inserido apenas 1(UM) Cliente."
            Else
                Mensagem = "Operação de Inserção concluída com sucesso!" & vbNewLine &
                           "Foram inseridos " & CountNiver & " Clientes."
            End If
            '
            AbrirDialog(Mensagem, "Operação Concluída", frmDialog.DialogType.OK, frmDialog.DialogIcon.Information)
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Gerar envio para os Clientes Aniversariantes..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub miEnvioMalaDiretaImpressão_Click(sender As Object, e As EventArgs) Handles miEnvioMalaDiretaImpressão.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmE As New frmEnvioListagem
            frmE.MdiParent = Me
            OcultaMenuPrincipal()
            frmE.Show()
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
#End Region
    '
    '========================================================================================================
    ' MENU CADASTROS
    '========================================================================================================
#Region "MENU CADASTROS"
    '
    Private Sub miFuncionarios_Click(sender As Object, e As EventArgs) Handles miFuncionarios.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmF As New frmFuncionarioProcurar
            OcultaMenuPrincipal()
            frmF.MdiParent = Me
            frmF.Show()
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
    Private Sub miTransportadoras_Click(sender As Object, e As EventArgs) Handles miTransportadoras.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmT As New frmTransportadoraProcurar
            OcultaMenuPrincipal()
            frmT.MdiParent = Me
            frmT.Show()
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
    Private Sub miFornecedores_Click(sender As Object, e As EventArgs) Handles miFornecedores.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmF As New frmFornecedorProcurar
            OcultaMenuPrincipal()
            frmF.MdiParent = Me
            frmF.Show()
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
    Private Sub miCredores_Click(sender As Object, e As EventArgs) Handles miCredores.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmC As New frmCredorProcurar
            OcultaMenuPrincipal()
            frmC.MdiParent = Me
            frmC.Show()
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
#End Region
    '
    '========================================================================================================
    ' MENU PRODUTOS
    '========================================================================================================
#Region "MENU PRODUTOS"
    '
    Private Sub miProdutoTipos_Click(sender As Object, e As EventArgs) Handles miProdutoTipos.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            OcultaMenuPrincipal()
            Dim f As New frmProdutoTipo(frmProdutoTipo.ProcurarPor.None)
            f.MdiParent = Me
            f.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao ABRIR formulário..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub miProdutoNovo_Click(sender As Object, e As EventArgs) Handles miProdutoNovo.Click
        OcultaMenuPrincipal()
        Dim prod As New frmProduto(EnumFlagAcao.INSERIR, New clProduto)
        prod.MdiParent = Me
        prod.Show()
    End Sub
    '
    Private Sub miEditarProduto_Click(sender As Object, e As EventArgs) Handles miEditarProduto.Click
        '
        Dim IDEscolhido As Integer? = Nothing
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            ' abre o form de procura
            Dim proc As New frmProdutoProcurar()
            '
            proc.ShowDialog()
            If proc.DialogResult = DialogResult.Cancel Then Exit Sub
            '
            If Not IsNumeric(proc.ProdutoEscolhido.RGProduto) Then Exit Sub
            '
            IDEscolhido = proc.ProdutoEscolhido.IDProduto
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir o formulário de Procura..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        Try
            Dim intFilial As Integer? = Obter_FilialPadrao()
            If IsNothing(intFilial) Then
                MessageBox.Show("Nenhuma Filial foi encotrada..." & vbNewLine &
                                "O Arquivo de Configuração do Sistema está ausente ou danificado." & vbNewLine &
                                "Certifique-se que o arquivo de configuração está presente...",
                                "Filial não encontrada!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            '
            Dim pBLL As New ProdutoBLL
            Dim clProd As New clProduto
            '
            clProd = pBLL.GetProduto_PorID(IDEscolhido, intFilial)
            '
            ' oculta menu principal
            OcultaMenuPrincipal()
            '
            ' abre o produto para edição
            Dim prod As New frmProduto(EnumFlagAcao.EDITAR, clProd)
            prod.MdiParent = Me
            prod.Show()
        Catch ex As Exception
            MostraMenuPrincipal()
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub
    '
    Private Sub miFabricantesMarcas_Click(sender As Object, e As EventArgs) Handles miFabricantesMarcas.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            OcultaMenuPrincipal()
            Dim f As New frmFabricante(False, Nothing)
            f.MdiParent = Me
            f.Show()
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
    Private Sub miProdutoListagem_Click(sender As Object, e As EventArgs) Handles miProdutoListagem.Click
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        OcultaMenuPrincipal()
        Dim f As New frmProdutoListagem
        f.MdiParent = Me
        f.Show()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
    End Sub
    '
    Private Sub miProdutoEtiquetaVenda_Click(sender As Object, e As EventArgs) Handles miProdutoEtiquetaVenda.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmP As New frmProdutoEtiquetaControle
            OcultaMenuPrincipal()
            frmP.MdiParent = Me
            frmP.Show()
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
    Private Sub miEstoqueInicial_Click(sender As Object, e As EventArgs) Handles miEstoqueInicial.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmE As New frmEstoqueInicial
            OcultaMenuPrincipal()
            frmE.MdiParent = Me
            frmE.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de Estoque Inicial..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub miAjusteEstoque_Click(sender As Object, e As EventArgs) Handles miAjusteEstoque.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmE As New frmEstoqueAjuste(New clEstoqueAjuste)
            OcultaMenuPrincipal()
            frmE.MdiParent = Me
            frmE.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de Ajuste de Estoque..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Sub miProcurarAjusteDeEstoque_Click(sender As Object, e As EventArgs) Handles miProcurarAjusteDeEstoque.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmE As New frmEstoqueAjusteProcurar()
            OcultaMenuPrincipal()
            frmE.MdiParent = Me
            frmE.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de Procurar Ajuste de Estoque..." & vbNewLine &
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
    '========================================================================================================
    ' MENU SAIDA DE PRODUTOS
    '========================================================================================================
#Region "MENU SAIDA DE PRODUTOS"
    '
    Private Sub miNovaVendaVista_Click(sender As Object, e As EventArgs) Handles miNovaVendaVista.Click
        Dim v As New AcaoGlobal
        Dim obj As Object = v.VendaAVista_Nova
        '
        If IsNothing(obj) Then Exit Sub
        '
        OcultaMenuPrincipal()
        Dim f As New frmVendaVista(obj)
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        '
    End Sub
    '
    Private Sub miNovaVendaPrazo_Click(sender As Object, e As EventArgs) Handles miNovaVendaPrazo.Click
        Dim v As New AcaoGlobal
        Dim obj As Object = v.VendaPrazo_Nova
        '
        If IsNothing(obj) Then Exit Sub
        '
        OcultaMenuPrincipal()
        Dim f As New frmVendaPrazo(obj)
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        '
    End Sub
    '
    Private Sub miProcurarOperacaoSaida_Click(sender As Object, e As EventArgs) Handles miProcurarOperacaoSaida.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmP As New frmOperacaoSaidaProcurar
            OcultaMenuPrincipal()
            frmP.MdiParent = Me
            frmP.Show()
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de Operação de Saída..." & vbNewLine &
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
    Private Sub miProcurarTroca_Click(sender As Object, e As EventArgs) Handles miProcurarTroca.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmP As New frmTrocaProcurar
            OcultaMenuPrincipal()
            frmP.MdiParent = Me
            frmP.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir o formulário de procurar TROCA..." & vbNewLine &
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
    Private Sub miNovaSimplesSaida_Click(sender As Object, e As EventArgs) Handles miNovaSimplesSaida.Click
        '
        Dim a As New AcaoGlobal
        Dim obj As Object = a.SimplesSaida_Nova
        '
        If IsNothing(obj) Then Exit Sub
        '
        OcultaMenuPrincipal()
        Dim f As New frmSimplesSaida(obj)
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        '
    End Sub
    '
    Private Sub miNovaDevolucaoSaida_Click(sender As Object, e As EventArgs) Handles miNovaDevolucaoSaida.Click
        '
        Dim a As New AcaoGlobal
        Dim obj As Object = a.DevolucaoSaida_Nova
        '
        If IsNothing(obj) Then Exit Sub
        '
        OcultaMenuPrincipal()
        Dim f As New frmDevolucaoSaida(obj)
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        '
    End Sub
    '
#End Region
    '
    '========================================================================================================
    ' MENU ENTRADA DE PRODUTOS
    '========================================================================================================
#Region "ENTRADA DE PRODUTOS"
    '
    Private Sub miNovaCompraNormal_Click(sender As Object, e As EventArgs) Handles miNovaCompraNormal.Click
        Dim c As New AcaoGlobal
        Dim obj As Object = c.Compra_Nova
        '
        If IsNothing(obj) Then Exit Sub
        '
        Try
            OcultaMenuPrincipal()
            Dim f As New frmCompra(obj)
            f.MdiParent = Me
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu ao abrir Nova Compra", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MostraMenuPrincipal()
        End Try
        '
    End Sub
    '
    Private Sub miNovaCompraNFeXML_Click(sender As Object, e As EventArgs) Handles miNovaCompraNFeXML.Click
        '
        Try
            OcultaMenuPrincipal()
            Dim f As New frmCompraGetNFe
            f.MdiParent = Me
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Catch ex As Exception
            MessageBox.Show("Um erro inesperado ocorreu ao abrir O Formulário de Criação de NFe", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MostraMenuPrincipal()
        End Try
        '
    End Sub
    '
    Private Sub miProcurarOperacaoEntrada_Click(sender As Object, e As EventArgs) Handles miProcurarOperacaoEntrada.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmP As New frmOperacaoEntradaProcurar
            OcultaMenuPrincipal()
            frmP.MdiParent = Me
            frmP.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de procurar operação de Entrada..." & vbNewLine &
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
    Private Sub miProcurarReserva_Click(sender As Object, e As EventArgs) Handles miProcurarReserva.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmR As New frmReservaProcurar
            OcultaMenuPrincipal()
            frmR.MdiParent = Me
            frmR.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de procurar Reserva..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub miNovaReserva_Click(sender As Object, e As EventArgs) Handles miNovaReserva.Click
        Dim clR As New clReserva
        Dim frmR As New frmReserva(clR)
        OcultaMenuPrincipal()
        frmR.MdiParent = Me
        frmR.Show()
    End Sub
    '
    Private Sub miControleDePedidos_Click(sender As Object, e As EventArgs) Handles miControleDePedidos.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            OcultaMenuPrincipal()
            Dim f As New frmPedidoProcurar
            f.MdiParent = Me
            f.Show()
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
    Private Sub miSimplesEntrada_Click(sender As Object, e As EventArgs) Handles miSimplesEntrada.Click
        '
        OcultaMenuPrincipal()
        Dim f As New frmSimplesEntradaControle
        f.MdiParent = Me
        f.Show()
        '
    End Sub
    '
#End Region
    '
    '========================================================================================================
    ' MENU A RECEBER
    '========================================================================================================
#Region "A RECEBER"
    Private Sub miAReceberCliente_Click(sender As Object, e As EventArgs) Handles miAReceberCliente.Click
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        Dim frmP As New frmClienteProcurar()
        frmP.ShowDialog()
        '
        If frmP.DialogResult = DialogResult.Cancel Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmR As New frmAReceberListCliente(frmP.propClienteEscolhido)
            OcultaMenuPrincipal()
            frmR.MdiParent = Me
            frmR.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário de A Receber..." & vbNewLine &
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
    Private Sub miAReceberMovInterna_Click(sender As Object, e As EventArgs) Handles miAReceberMovInterna.Click
        '
        Dim frmS As New frmAPagarReceberSimples(True)
        OcultaMenuPrincipal()
        frmS.MdiParent = Me
        frmS.Show()
        '
    End Sub
    '   
#End Region
    '
    '========================================================================================================
    ' MENU A PAGAR
    '========================================================================================================
#Region "A PAGAR"
    '
    Private Sub miTipoDeDespesa_Click(sender As Object, e As EventArgs) Handles miTipoDeDespesa.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmTd As New frmDespesaTipoProcurar
            OcultaMenuPrincipal()
            frmTd.MdiParent = Me
            frmTd.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário..." & vbNewLine &
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
    Private Sub miNovaDespesa_Click(sender As Object, e As EventArgs) Handles miNovaDespesa.Click
        Dim desp As New clDespesa

        Dim frmD As New frmDespesa(desp)
        OcultaMenuPrincipal()
        frmD.MdiParent = Me
        frmD.Show()
    End Sub
    '
    Private Sub miProcurarDespesa_Click(sender As Object, e As EventArgs) Handles miProcurarDespesa.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmD As New frmDespesaProcurar
            OcultaMenuPrincipal()
            frmD.MdiParent = Me
            frmD.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário..." & vbNewLine &
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
    Private Sub miAPagarProcurar_Click(sender As Object, e As EventArgs) Handles miAPagarProcurar.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmP As New frmAPagarProcurar
            OcultaMenuPrincipal()
            frmP.MdiParent = Me
            frmP.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Sub miDespesasPeriodicas_Click(sender As Object, e As EventArgs) Handles miDespesasPeriodicas.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmP As New frmDespesaPeriodicaProcurar
            OcultaMenuPrincipal()
            frmP.MdiParent = Me
            frmP.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir fomulário..." & vbNewLine &
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
    Private Sub miNovaDespesaQuitada_Click(sender As Object, e As EventArgs) Handles miNovaDespesaQuitada.Click
        Dim frmD As New frmDespesaSimples()
        OcultaMenuPrincipal()
        frmD.MdiParent = Me
        frmD.Show()
    End Sub
    '
    Private Sub miAPagarMovInterna_Click(sender As Object, e As EventArgs) Handles miAPagarMovInterna.Click
        '
        Dim frmS As New frmAPagarReceberSimples(False)
        OcultaMenuPrincipal()
        frmS.MdiParent = Me
        frmS.Show()
        '
    End Sub
    '
    Private Sub miFretes_Click(sender As Object, e As EventArgs) Handles miFretes.Click
        '
        Dim frmF As New frmFreteProcurar()
        OcultaMenuPrincipal()
        frmF.MdiParent = Me
        frmF.Show()
        '
    End Sub
    '
#End Region
    '
    '========================================================================================================
    ' MENU A CAIXA
    '========================================================================================================
#Region "CAIXA"
    '
    Private Sub miContas_Click(sender As Object, e As EventArgs) Handles miContas.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmC As New frmContas
            OcultaMenuPrincipal()
            frmC.MdiParent = Me
            frmC.Show()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário..." & vbNewLine &
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
    Private Sub miFormasDeMovimentacao_Click(sender As Object, e As EventArgs) Handles miFormasDeMovimentacao.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmC As New frmMovFormas
            OcultaMenuPrincipal()
            frmC.MdiParent = Me
            frmC.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir fomulário..." & vbNewLine &
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
    Private Sub miTiposDeMovimentacao_Click(sender As Object, e As EventArgs) Handles miTiposDeMovimentacao.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmC As New frmMovTipos()
            OcultaMenuPrincipal()
            frmC.MdiParent = Me
            frmC.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário..." & vbNewLine &
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
    Private Sub miTiposDeCartao_Click(sender As Object, e As EventArgs) Handles miTiposDeCartao.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmC As New frmCartaoTipos(False)
            OcultaMenuPrincipal()
            frmC.MdiParent = Me
            frmC.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao abrir formulário..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub

    Private Sub miFinalizarCaixa_Click(sender As Object, e As EventArgs) Handles miFinalizarCaixa.Click
        '
        OcultaMenuPrincipal()
        Dim f As New frmCaixaInserir
        Try
            f.MdiParent = Me
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
        Catch ex As Exception
            f.Dispose()
            MostraMenuPrincipal()
        End Try
        '
    End Sub
    '
    Private Sub miProcurarCaixa_Click(sender As Object, e As EventArgs) Handles miProcurarCaixa.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim frmC As New frmCaixaProcurar()
            OcultaMenuPrincipal()
            frmC.MdiParent = Me
            frmC.Show()
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
    Private Sub miTransferencias_Click(sender As Object, e As EventArgs) Handles miTransferencias.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            OcultaMenuPrincipal()
            Dim f As New frmTransferenciaProcurar
            '
            f.MdiParent = Me
            f.StartPosition = FormStartPosition.CenterScreen
            f.Show()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Abrir o Formulário de Transferências..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MostraMenuPrincipal()
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
#End Region
    '
    '========================================================================================================
    ' MENU CONFIGURACOES
    '========================================================================================================
#Region "MENU CONFIGURACOES"
    '
    Private Sub miConfiguracaoSistema_Click(sender As Object, e As EventArgs) Handles miConfiguracaoSistema.Click
        '
        If UsuarioAtual.UsuarioAcesso > 1 Then ' não é administrador do sistema
            MessageBox.Show("Seu LOGIN não tem acesso ao arquivo de Configuração..." & vbNewLine &
                            "Comunique-se com o administrador do sistema.",
                            "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim frmC As New frmConfig
            frmC.ShowDialog()
        End If
        '
    End Sub
    '
    Private Sub miConfiguracaoUsuarios_Click(sender As Object, e As EventArgs) Handles miConfiguracaoUsuarios.Click
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            OcultaMenuPrincipal()
            Dim f As New frmUsuarios
            f.MdiParent = Me
            f.Show()
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
    Private Sub miConfiguracaoDataPadrao_Click(sender As Object, e As EventArgs) Handles miConfiguracaoDataPadrao.Click
        OcultaMenuPrincipal()
        Dim f As New frmContaDataPadrao
        f.MdiParent = Me
        f.Show()
    End Sub
    '
    Private Sub miFazerBackup_Click(sender As Object, e As EventArgs) Handles miFazerBackup.Click
        '
        '--- verifica se o BD is LOCAL OR REMOTE
        Dim NodeServidorLocal As String = ObterConfigValorNode("ServidorLocal")
        '
        If NodeServidorLocal.ToUpper = "FALSE" Then
            '--- Aviso ao user
            MessageBox.Show("A operação de BACKUP não é possível em servidores REMOTOS.",
                            "Realizar Backup",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            '
            Exit Sub
        End If
        '
        '--- Open Form
        OcultaMenuPrincipal()
        Dim f As New frmBackup
        f.MdiParent = Me
        f.Show()
    End Sub
    '
    Private Sub miCFOP_Click(sender As Object, e As EventArgs) Handles miCFOP.Click
        '
        If UsuarioAtual.UsuarioAcesso > 1 Then ' não é administrador do sistema
            '
            MessageBox.Show("Seu LOGIN não tem acesso aos arquivos de Configuração..." & vbNewLine &
                            "Comunique-se com o administrador do sistema.",
                            "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '
        Else
            Dim frmC As New frmCFOP
            frmC.ShowDialog()
        End If
        '
    End Sub
    '
    Private Sub miEmailServer_Click(sender As Object, e As EventArgs) Handles miEmailServer.Click
        '
        If UsuarioAtual.UsuarioAcesso > 1 Then ' não é administrador do sistema
            '
            MessageBox.Show("Seu LOGIN não tem acesso aos arquivos de Configuração..." & vbNewLine &
                            "Comunique-se com o administrador do sistema.",
                            "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '
        Else
            Dim frmC As New frmEmailServer
            frmC.ShowDialog()
        End If
        '
    End Sub
    '
#End Region
    '
    '========================================================================================================
    ' INFO MESSAGE
    '========================================================================================================
#Region "INFO MESSAGE"
    '
    Public Sub InfoMessageShow(message As String)
        '
        lblInfoMessage.Text = message
        lblInfoMessage.Visible = True
        '
        If Panel1.BackColor <> Color.SlateGray Then
            lblInfoMessage.ForeColor = Color.LightSlateGray
        End If
        '
        lblInfoMessage.Refresh()
        '
    End Sub
    '
    Public Sub InfoMessageUpdate(message As String)
        '
        lblInfoMessage.Text = message
        lblInfoMessage.Visible = True
        '
        If Panel1.BackColor <> Color.SlateGray Then
            lblInfoMessage.ForeColor = Color.LightSlateGray
        End If
        '
        lblInfoMessage.Refresh()
        '
    End Sub
    '
    Public Sub InfoMessageHide()
        '
        lblInfoMessage.Visible = False
        lblInfoMessage.Text = ""
        '
    End Sub
    '
#End Region '/ INFO MESSAGE
    '
End Class
