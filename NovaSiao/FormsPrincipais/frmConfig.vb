Imports System.IO
Imports System.Xml
Imports VIBlend.WinForms.Controls
Imports CamadaBLL
Imports CamadaDTO

Public Class frmConfig
    '
    ' VARIÁVEIS E PROPRIEDADES
    Dim Px, Py As Integer
    Dim Mover As Boolean
    Private _Conta As clConta
    Private IDConta_Config As Short?
    Private IDFilial_Config As Integer?
    Private _Sit As EnumFlagEstado
    Private ImageLogoMono As Image
    Private ImageLogoColor As Image
    Dim _VerAlteracao As Boolean = False
    '
#Region "LOAD"
    '
    Private Property Sit As EnumFlagEstado
        '
        Get
            Return _Sit
        End Get
        '
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnCancelar.Text = "Fechar"
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnCancelar.Text = "Cancelar"
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                btnSalvar.Enabled = True
                btnCancelar.Text = "Sair"
            End If
        End Set
        '
    End Property
    '
    ' EVENTO LOAD
    Private Sub frmConfig_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        If File.Exists(Application.StartupPath & "\ConfigFiles\Config.xml") Then
            '
            If LerConfigXML() = False Then
                MessageBox.Show("O arquivo de Configuração possui um erro de leitura..." & vbNewLine &
                                "Preencha todos os campos para gravar nova Configuração do Sistema.",
                                "Arquivo Corrompido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Sit = EnumFlagEstado.Alterado
            Else
                Sit = EnumFlagEstado.RegistroSalvo
            End If
            '
        Else
            '
            Sit = EnumFlagEstado.NovoRegistro
            '
        End If
        '
        '-- Get Conta Padrao
        If Not IsNothing(IDConta_Config) Then
            GetConta(IDConta_Config)
        Else
            _Conta = New clConta
        End If
        '
        '--- Verifica Data de Bloqueio da Conta
        VerficaBloqueioDataConta()
        '
        '--- Get Connection String
        Dim bBLL As New AcessoControlBLL
        txtStringConexao.Text = bBLL.GetConString
        '
        '--- Add Handlers
        HandlerChangedControles()
        _VerAlteracao = True
        addToolTipHandler()
        '
    End Sub
    '
    ' GET OS DADOS DA CONTA PADRAO
    Private Sub GetConta(IDConta As Byte)
        Dim mBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Get Dados da Conta
            _Conta = mBLL.Conta_GET_PorIDConta(IDConta)
            VerificaValoresDefault()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a Conta pelo ID..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _Conta = New clConta
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- VERIFICA INTEGRIDADE DO ARQUIVO DE CONFIG
    Private Sub VerificaValoresDefault()
        '
        '--- Descricao da Conta
        If Not _Conta.Conta.Equals(txtContaPadrao.Text) Then
            txtContaPadrao.Text = _Conta.Conta
            Sit = EnumFlagEstado.Alterado
        End If
        '
        '--- Descricao da Filial
        If Not _Conta.ApelidoFilial.Equals(txtFilialPadrao.Text) Then
            txtFilialPadrao.Text = _Conta.ApelidoFilial
            Sit = EnumFlagEstado.Alterado
        End If
        '
        '-- IDFilial
        If Not _Conta.IDFilial.Equals(IDFilial_Config) Then
            IDFilial_Config = _Conta.IDFilial
            Sit = EnumFlagEstado.Alterado
        End If
        '
    End Sub
    '
    Private Function LerLogosImagem() As Boolean
        '
        Dim resp As Boolean = False
        '
        ' Ler a imagem do arquivo da LOGO COLOR
        If txtLogoColorCaminho.Text.Length > 0 Then
            '
            Try
                ImageLogoColor = Image.FromFile(txtLogoColorCaminho.Text)
                'ImageLogoColor = Image.FromFile(Application.StartupPath + "\Imagens\LogoColor.png")
                picLogoColor.Image = ImageLogoColor
                '
                resp = True
                '
            Catch ex As Exception
                MessageBox.Show("O arquivo de imagem da LOGO Colorida não foi encontrado no caminho especificado:" & vbNewLine &
                                txtLogoMonoCaminho.Text, "Erro: Arquivo da Logo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                resp = False
                '
            End Try
            '
        End If
        '
        ' Ler a imagem do arquivo da LOGO MONO
        If txtLogoMonoCaminho.Text.Length > 0 Then
            '
            Try
                ImageLogoMono = Image.FromFile(txtLogoMonoCaminho.Text)
                'ImageLogoMono = Image.FromFile(Application.StartupPath + "\Imagens\LogoMono.png")
                picLogoMono.Image = ImageLogoMono
                '
            Catch ex As Exception
                MessageBox.Show("O arquivo de imagem da LOGO Monocromática não foi encontrado no caminho especificado:" & vbNewLine &
                                txtLogoMonoCaminho.Text, "Erro: Arquivo da Logo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                '
                resp = False
                '
            End Try
            '
        End If
        '
        Return resp
        '
    End Function
    '
#End Region
    '
#Region "ARQUIVO XML"
    '
    ' LER O ARQUIVO XML
    '-----------------------------------------------------------------------------------------------
    Private Function LerConfigXML() As Boolean
        Dim myXML As New XmlDocument
        '
        myXML.Load(Application.StartupPath & "\ConfigFiles\Config.xml")
        '
        On Error GoTo Error_Handler

        With myXML.SelectSingleNode("Configuracao")

            ' Lendo a PRIMEIRA Seção
            With .SelectSingleNode("ValoresPadrao")
                '
                dtpDataPadrao.Value = .SelectSingleNode("DataPadrao").InnerText
                IDFilial_Config = If(String.IsNullOrEmpty(.SelectSingleNode("FilialPadrao").InnerText), Nothing, .SelectSingleNode("FilialPadrao").InnerText)
                txtFilialPadrao.Text = .SelectSingleNode("FilialDescricao").InnerText
                IDConta_Config = If(String.IsNullOrEmpty(.SelectSingleNode("ContaPadrao").InnerText), Nothing, .SelectSingleNode("ContaPadrao").InnerText)
                txtContaPadrao.Text = .SelectSingleNode("ContaDescricao").InnerText
                lblDataBloqueio.Text = .SelectSingleNode("DataBloqueada").InnerText
                txtCidade.Text = .SelectSingleNode("Cidade").InnerText
                txtUF.Text = .SelectSingleNode("UF").InnerText
                txtNaturalidade.Text = .SelectSingleNode("Naturalidade").InnerText
                txtMensagem.Text = .SelectSingleNode("MensagemInicial").InnerText
                'IDProdutoTipoPadrao = .SelectSingleNode("IDProdutoTipoPadrao").InnerText
                'ProdutoTipoPadrao = .SelectSingleNode("ProdutoTipoPadrao").InnerText
                'IDProdutoSubTipoPadrao = .SelectSingleNode("IDProdutoSubTipoPadrao").InnerText
                'ProdutoSubTipoPadrao = .SelectSingleNode("ProdutoSubTipoPadrao").InnerText
                txtPermanencia.Text = .SelectSingleNode("TaxaPermanencia").InnerText.Replace(".", ",")
                chkEstoqueNegativo.Checked = .SelectSingleNode("EstoqueNegativo").InnerText
                txtDescontoMaximo.Text = .SelectSingleNode("DescontoMaximo").InnerText.Replace(".", ",")
                '
            End With
            '
            ' Lendo a SEGUNDA seção
            With .SelectSingleNode("DadosEmpresa")
                '
                txtRazao.Text = .SelectSingleNode("RazaoSocial").InnerText
                txtFantasia.Text = .SelectSingleNode("NomeFantasia").InnerText
                txtCNPJ.Text = .SelectSingleNode("CNPJ").InnerText
                txtIncricao.Text = .SelectSingleNode("InscricaoSocial").InnerText
                txtTelPrincipal.Text = .SelectSingleNode("TelefonePrincipal").InnerText
                txtTelGerencia.Text = .SelectSingleNode("TelefoneGerencia").InnerText
                txtContatoGerencia.Text = .SelectSingleNode("ContatoGerencia").InnerText
                txtTelFinanceiro.Text = .SelectSingleNode("TelefoneFinanceiro").InnerText
                txtContatoFinanceiro.Text = .SelectSingleNode("ContatoFinanceiro").InnerText
                '
            End With

            ' Lendo a TERCEIRA seção
            txtLogoMonoCaminho.Text = .SelectSingleNode("ArquivoLogo").ChildNodes(0).InnerText
            txtLogoColorCaminho.Text = .SelectSingleNode("ArquivoLogo").ChildNodes(1).InnerText
            '
            ' Lendo a QUARTA seção
            txtStringConexao.Text = .SelectSingleNode("ServidorDados").ChildNodes(0).InnerText
            chkVerBackup.Checked = CType(.SelectSingleNode("ServidorDados").ChildNodes(1).InnerText, Boolean)
            '
            If .SelectSingleNode("ServidorDados").ChildNodes(2).InnerText Then
                rbtServLocal.Checked = True
            Else
                rbtServRemoto.Checked = True
            End If
            '
        End With
        Return True
        '
Error_Handler:
        MessageBox.Show(Err.Description)
        Resume Next
        '
    End Function
    '
    ' CRIA ARQUIVO XML
    '-----------------------------------------------------------------------------------------------
    Private Function CriaConfigXML() As Boolean
        '
        Try
            '
            Dim writer As New XmlTextWriter("ConfigFiles\Config.xml", Nothing)
            With writer
                .WriteStartDocument()
                '
                'define a indentação do arquivo
                .Formatting = Formatting.Indented
                .WriteStartElement("Configuracao")

                ' Primeira Seção: VALORES PADRAO
                '----------------------------------------------------------------------------------
                .WriteStartElement("ValoresPadrao")
                ' Sub Elementos
                .WriteElementString("DataPadrao", dtpDataPadrao.Value.ToShortDateString)
                .WriteElementString("FilialPadrao", _Conta.IDFilial)
                .WriteElementString("FilialDescricao", _Conta.ApelidoFilial)
                .WriteElementString("ContaPadrao", _Conta.IDConta)
                .WriteElementString("ContaDescricao", _Conta.Conta)
                .WriteElementString("DataBloqueada", If(_Conta.BloqueioData, ""))
                .WriteElementString("Cidade", txtCidade.Text)
                .WriteElementString("UF", txtUF.Text)
                .WriteElementString("Naturalidade", txtNaturalidade.Text)
                .WriteElementString("MensagemInicial", txtMensagem.Text)
                .WriteElementString("IDProdutoTipoPadrao", "")
                .WriteElementString("ProdutoTipoPadrao", "")
                .WriteElementString("IDProdutoSubTipoPadrao", "")
                .WriteElementString("ProdutoSubTipoPadrao", "")
                .WriteElementString("TaxaPermanencia", txtPermanencia.Text.Replace(",", "."))
                .WriteElementString("EstoqueNegativo", chkEstoqueNegativo.Checked)
                .WriteElementString("DescontoMaximo", txtDescontoMaximo.Text.Replace(",", "."))
                'encerra o elemento
                .WriteEndElement()

                ' Segunda Seção: DADOS DA EMPRESA
                '----------------------------------------------------------------------------------
                .WriteStartElement("DadosEmpresa")
                ' Sub Elementos
                .WriteElementString("RazaoSocial", txtRazao.Text)
                .WriteElementString("NomeFantasia", txtFantasia.Text)
                .WriteElementString("CNPJ", txtCNPJ.Text)
                .WriteElementString("InscricaoSocial", txtIncricao.Text)
                .WriteElementString("TelefonePrincipal", txtTelPrincipal.Text)
                .WriteElementString("TelefoneGerencia", txtTelGerencia.Text)
                .WriteElementString("ContatoGerencia", txtContatoGerencia.Text)
                .WriteElementString("TelefoneFinanceiro", txtTelFinanceiro.Text)
                .WriteElementString("ContatoFinanceiro", txtContatoFinanceiro.Text)
                'encerra o elemento
                .WriteEndElement()

                ' Terceira Seção: ARQUIVOS IMPORTANTES
                '----------------------------------------------------------------------------------
                .WriteStartElement("ArquivoLogo")
                ' Sub Elementos
                .WriteElementString("ArquivoLogoMono", txtLogoMonoCaminho.Text)
                .WriteElementString("ArquivoLogoColor", txtLogoColorCaminho.Text)
                .WriteElementString("BackupDir", "")
                'encerra o elemento
                .WriteEndElement()

                ' Quarta Seção: SERVIDOR
                '----------------------------------------------------------------------------------
                .WriteStartElement("ServidorDados")
                ' Sub Elementos
                .WriteElementString("StringConexao", txtStringConexao.Text)
                .WriteElementString("ControlaBackup", chkVerBackup.Checked.ToString)
                .WriteElementString("ServidorLocal", rbtServLocal.Checked.ToString)
                'encerra o elemento
                .WriteEndElement()
                '
                'FECHA CONFIGURAÇÃO
                .WriteEndElement()
                'escreve o xml para o arquivo e fecha o objeto escritor
                .Close()
                '
                '--- return
                Return True
                '
            End With
            '
        Catch ex As Exception
            '
            MessageBox.Show(ex.Message)
            Return False
            '
        End Try
        '
    End Function
    '
#End Region
    '
#Region "FILIAL E CONTA"
    '
    Private Sub btnFilialAdd_Click(sender As Object, e As EventArgs) Handles btnFilialAdd.Click
        '
        '--- Abre o frmFilial
        Dim fFil As New frmFilial(New clFilial)
        '
        Me.Opacity = 0.6
        fFil.ShowDialog()
        Me.Opacity = 1
        '
    End Sub
    '
    Private Sub btnContaAdd_Click(sender As Object, e As EventArgs) Handles btnContaAdd.Click
        '
        '--- verifica se a Filial já foi escolhida
        If IsNothing(_Conta.IDFilial) Then
            MessageBox.Show("Favor escolher em primeiro lugar FILIAL PADRÃO", "Escolha Filial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAlteraFilial.Focus()
            Exit Sub
        End If
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContas(Me, _Conta.IDFilial, _Conta.ApelidoFilial)
        '
        Opacity = 0.6
        frmConta.ShowDialog()
        Opacity = 1
        '
    End Sub
    '
    Private Sub btnAlteraFilial_Click(sender As Object, e As EventArgs) Handles btnAlteraFilial.Click
        '
        '--- Abre o frmFilial
        Dim fFil As New frmFilialEscolher()
        '
        Me.Opacity = 0.6
        fFil.ShowDialog()
        Me.Opacity = 1
        '
        If fFil.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        If fFil.propIdFilial_Escolha <> _Conta.IDFilial Then
            Sit = EnumFlagEstado.Alterado
            _Conta = New clConta '--- clear _Conta as NEW clConta
            txtContaPadrao.Clear()
        End If
        '
        _Conta.IDFilial = fFil.propIdFilial_Escolha
        _Conta.ApelidoFilial = fFil.propFilial_Escolha
        txtFilialPadrao.Text = fFil.propFilial_Escolha
        '
    End Sub
    '
    Private Sub btnAlteraConta_Click(sender As Object, e As EventArgs) Handles btnAlteraConta.Click
        '
        '--- verifica se a Filial já foi escolhida
        If IsNothing(_Conta.IDFilial) Then
            MessageBox.Show("Favor escolher em primeiro lugar FILIAL PADRÃO", "Escolha Filial", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAlteraFilial.Focus()
            Exit Sub
        End If
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, _Conta.IDFilial, _Conta.IDConta)
        '
        Me.Opacity = 0.6
        frmConta.ShowDialog()
        Me.Opacity = 1
        '
        If frmConta.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        If frmConta.propConta_Escolha.IDConta <> _Conta.IDConta Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        _Conta = frmConta.propConta_Escolha
        txtContaPadrao.Text = frmConta.propConta_Escolha.Conta
        '
        '--- determina a DataPadrao do Sistema pela conta
        VerficaBloqueioDataConta()
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilialPadrao.KeyDown, txtContaPadrao.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtFilialPadrao"
                    btnAlteraFilial_Click(New Object, New EventArgs)
                    txtFilialPadrao.Text = txtFilialPadrao.Text.Replace("+", "")
                    txtFilialPadrao.SelectAll()
                Case "txtContaPadrao"
                    btnAlteraConta_Click(New Object, New EventArgs)
                    txtContaPadrao.Text = txtContaPadrao.Text.Replace("+", "")
                    txtContaPadrao.SelectAll()
            End Select
        ElseIf e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        Else
            e.Handled = True
            e.SuppressKeyPress = True
        End If
        '
    End Sub
    '
    '--- VERIFICA BLOQUEIO DA DATA INICIAL DA CONTA ESCOLHIDA
    'return FALSE se a DataBloqueio não for encontrada
    Private Function VerficaBloqueioDataConta() As Boolean
        '
        Dim blData As Date? = _Conta.BloqueioData
        '
        '--- DEFINE OS VALORES
        '---------------------------------------------------
        If Not IsNothing(blData) Then
            'blData = CDate(blData).AddDays(1)
            '
            '-- verifica se a data adicionada é DOMINGO, sendo adiciona um dia
            If CDate(blData).DayOfWeek = DayOfWeek.Sunday Then CDate(blData).AddDays(1)
            '
            '-- define a propriedade DATA PADRAO
            dtpDataPadrao.MinDate = blData
            dtpDataPadrao.MaxDate = Today
            dtpDataPadrao.Value = blData
            '
            '-- define a etiqueta
            lblDataBloqueio.Text = blData
            '
            Return True
            '
        Else '-- Se não houver DataBloqueio definida escolhe o dia de HOJE
            MessageBox.Show("A CONTA PADRÃO escolhida: " & txtContaPadrao.Text.ToUpper & vbNewLine &
                            "ainda não tem data de bloqueio definida..." & vbNewLine &
                            "A DATA PADRÃO do sistema será escolhida como" & vbNewLine &
                            "DATA ATUAL: " & Now.ToLongDateString, "Data Padrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '
            dtpDataPadrao.MinDate = Today.AddYears(-10)
            dtpDataPadrao.Value = Today.ToShortDateString
            dtpDataPadrao.MaxDate = Today
            '
            '-- define a etiqueta
            lblDataBloqueio.Text = dtpDataPadrao.MinDate
            '
            Return False
            '
        End If
        '
    End Function
    '
#End Region
    '
#Region "NAVEGABILIDADE E VALIDACOES"
    '
    ' CRIA TECLA DE ATALHO PARA O TAB
    '---------------------------------------------------------------------------------------------------
    Private Sub frmClientesPF_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '
        If e.Alt AndAlso e.KeyCode = Keys.D1 Then
            TabPrincipal.SelectedTab = Tab1
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D2 Then
            TabPrincipal.SelectedTab = Tab2
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D3 Then
            TabPrincipal.SelectedTab = Tab3
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D4 Then
            TabPrincipal.SelectedTab = Tab4
            tabPrincipal_SelectedIndexChanged(New Object, New System.EventArgs)
        End If
        '
    End Sub
    '
    Private Sub tabPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabPrincipal.SelectedIndexChanged
        '
        If TabPrincipal.SelectedIndex = 0 Then
            dtpDataPadrao.Focus()
        ElseIf TabPrincipal.SelectedIndex = 1 Then
            txtRazao.Focus()
        ElseIf TabPrincipal.SelectedIndex = 2 Then
            txtLogoColorCaminho.Focus()
            '--- somente faz a leitura dos logos nessa TAB
            LerLogosImagem()
        ElseIf TabPrincipal.SelectedIndex = 3 Then
            txtStringConexao.Focus()
        End If
        '
    End Sub
    '
    ' CAMPO UF SOMENTE MAIUSCULAS COM 2 CARACTERES
    Private Sub txtUF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUF.KeyPress
        ' MAXIMO DE 2 CARACTERES
        If Len(txtUF.Text) >= 2 And Not e.KeyChar = vbBack Then
            e.Handled = True
            Exit Sub
        End If

        ' SOMENTE LETRAS MAIUSCULA
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        ElseIf Char.IsLower(e.KeyChar) Then
            'Converte o texto para caixa alta
            txtUF.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub
    '
    ' EVENTO CHANGE DOS CONTROLES
    Private Sub HandlerChangedControles()
        '--- para cada TabPage no tabPrincipal
        For Each t As vTabPage In TabPrincipal.TabPages
            '--- para cada Controle no TabPage
            For Each c In t.Controls.OfType(Of TextBox)
                '--- se o controle for textbox então
                AddHandler c.TextChanged, AddressOf Controles_TextChanged
                c.ShortcutsEnabled = False
            Next
        Next
    End Sub
    '
    Private Sub Controles_TextChanged(sender As Object, e As EventArgs)
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
    End Sub
    '
    Private Sub dtpDataPadrao_ValueChanged(sender As Object, e As EventArgs) Handles dtpDataPadrao.ValueChanged
        '
        If _VerAlteracao AndAlso Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
    End Sub
    '
    Private Sub chkVerBackup_CheckedChanged(sender As Object, e As EventArgs) Handles _
        chkVerBackup.CheckedChanged,
        rbtServLocal.CheckedChanged,
        rbtServRemoto.CheckedChanged,
        chkEstoqueNegativo.CheckedChanged
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
    End Sub
    '
    '--- FAZER O txtTaxa formatar como 0,00
    Private Sub txtPermanencia_Validated(sender As Object, e As EventArgs) Handles txtPermanencia.Validated, txtDescontoMaximo.Validated
        If txtPermanencia.TextLength > 0 Then
            txtPermanencia.Text = FormatNumber(txtPermanencia.Text, 2, TriState.True, TriState.UseDefault, TriState.UseDefault)
        Else
            txtPermanencia.Text = "0,00"
        End If
    End Sub
    '
#End Region
    '
#Region "SALVAR DADOS"
    '
    ' SALVAR OS DADOS NO CONFIG
    '-----------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        ' Verifica os Dados
        If VerificaDados() = False Then
            Exit Sub
        End If
        '
        ' se existe o config.xml pergunta se deseja sobreescrever o arquivo
        If File.Exists(Application.StartupPath & "\ConfigFiles\Config.xml") Then
            If MessageBox.Show("Já existe um arquivo de Configuração salvo..." & vbNewLine &
                               "Deseja sobrescrever o arquivo de Configuração?",
                                "Salvar Configuração", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        End If
        '
        '--- Copia as imagens da LOGO para o diretorio padrao
        Copia_LogoColor()
        Copia_LogoMono()
        '
        ' cria o arquivo de configuração
        If CriaConfigXML() Then
            '
            Dim frmP As frmPrincipal = Application.OpenForms().Item("frmPrincipal")
            frmP.propContaPadrao = _Conta
            frmP.propDataPadrao = dtpDataPadrao.Value
            '
            MessageBox.Show("Arquivo de Configuração SALVO com sucesso!",
                            "Configuração do Sistema", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            '
            Sit = EnumFlagEstado.RegistroSalvo
        Else
            MessageBox.Show("Erro ao gravar o arquivo de Configuração",
                "Configuração do Sistema", MessageBoxButtons.OK,
                MessageBoxIcon.Stop)
        End If
        '
    End Sub
    '
    Private Function VerificaDados() As Boolean
        Dim f As New FuncoesUtilitarias
        '
        ' Verifica a validade de todos os campos
        ' Controles na TAB1
        TabPrincipal.SelectedTab = Tab1
        If Not f.VerificaControlesForm(dtpDataPadrao, "Data Padrão", EProvider) Then
            Return False
        End If
        '
        If IsNothing(_Conta) OrElse IsNothing(_Conta.IDConta) Then
            MessageBox.Show("A Conta Padrão não pode ficar vazia...", "Conta Padrão",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtContaPadrao.Focus()
            Return False
        End If
        '
        If IsNothing(_Conta.IDFilial) Then
            MessageBox.Show("A Filial Padrão não pode ficar vazio...", "Filial Padrão",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFilialPadrao.Focus()
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtCidade, "Cidade Padrão", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtUF, "Estado/UF Padrão", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtNaturalidade, "Naturalidade Padrão", EProvider) Then
            Return False
        End If
        '
        If txtDescontoMaximo.Text < 0 OrElse txtDescontoMaximo.Text > 100 Then
            AbrirDialog("O Desconto Máximo deve estar entre 0 e 100" & vbNewLine &
                        "Não pode ser negativo e nem pode ser maior que 100",
                        "Desconto Máximo", frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            txtDescontoMaximo.Focus()
            Return False
        End If
        '
        ' Controles na TAB2
        TabPrincipal.SelectedTab = Tab2
        If Not f.VerificaControlesForm(txtRazao, "Razão Social", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtFantasia, "Nome Fantasia", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtCNPJ, "CNPJ", EProvider) Then
            Return False
        End If
        '
        If Not f.VerificaControlesForm(txtIncricao, "Inscrição", EProvider) Then
            Return False
        End If
        '
        ' Se não encontra nenhum problema limpa o Eprovider e retorna true
        EProvider.Clear()
        TabPrincipal.SelectedTab = Tab1
        Return True
        '
    End Function
    '
#End Region
    '
#Region "LOGO MANUTENCAO"
    '
    Private Function Copia_LogoColor() As Boolean
        '
        Try
            '
            '--- se o arquivo foi selecionado
            If txtLogoColorCaminho.Text.Length > 0 Then
                '
                '--- copia LOGO COLOR
                If txtLogoColorCaminho.Text <> Application.StartupPath + "\Imagens\LogoColor.png" Then
                    File.Copy(txtLogoColorCaminho.Text, Application.StartupPath + "\Imagens\LogoColor.png", True)
                    txtLogoColorCaminho.Text = Application.StartupPath + "\Imagens\LogoColor.png"
                End If
                '
                '--- ler a imagem se estiver na TAB 2
                If TabPrincipal.SelectedIndex = 2 Then
                    ImageLogoColor = Image.FromFile(txtLogoColorCaminho.Text)
                    picLogoColor.Image = ImageLogoColor
                End If
                '
            Else
                Return False
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu ao copiar a LogoColor para o diretório padrão..." + vbNewLine +
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
        Return True
        '
    End Function
    '
    Private Function Copia_LogoMono() As Boolean
        '
        Try
            '
            '--- se o arquivo foi selecionado
            If txtLogoMonoCaminho.Text.Length > 0 Then
                '
                '--- copia LOGO MONO
                If txtLogoMonoCaminho.Text <> Application.StartupPath + "\Imagens\LogoMono.png" Then
                    File.Copy(txtLogoMonoCaminho.Text, Application.StartupPath + "\Imagens\LogoMono.png", True)
                    txtLogoMonoCaminho.Text = Application.StartupPath + "\Imagens\LogoMono.png"
                End If
                '
                '--- ler a imagem se estiver na TAB 2
                If TabPrincipal.SelectedIndex = 2 Then
                    ImageLogoMono = Image.FromFile(txtLogoMonoCaminho.Text)
                    picLogoMono.Image = ImageLogoMono
                End If
                '
            Else
                Return False
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu ao copiar a LogoMono para o diretório padrão..." + vbNewLine +
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
        Return True
        '
    End Function
    '
    ' PROCURAR A IMAGEM DA LOGO
    Private Sub btnProcurarImagem_Click(sender As Object, e As EventArgs) Handles btnProcurarImagem.Click ' logo MONO
        '
        Using OFD As New OpenFileDialog With {.Filter = "PNG (*.png)|*.png"}
            If OFD.ShowDialog = DialogResult.OK Then
                txtLogoMonoCaminho.Text = OFD.FileName
                ImageLogoMono = Image.FromFile(OFD.FileName)
                picLogoMono.Image = ImageLogoMono
                Sit = EnumFlagEstado.Alterado
            End If
        End Using
        '
    End Sub
    '
    Private Sub btnProcLogoColor_Click(sender As Object, e As EventArgs) Handles btnProcLogoColor.Click ' LOGO COLOR
        '
        Using OFD As New OpenFileDialog With {.Filter = "PNG (*.png)|*.png"}
            If OFD.ShowDialog = DialogResult.OK Then
                txtLogoColorCaminho.Text = OFD.FileName
                ImageLogoColor = Image.FromFile(OFD.FileName)
                picLogoColor.Image = ImageLogoColor
                Sit = EnumFlagEstado.Alterado
            End If
        End Using
        '
    End Sub
    '
#End Region
    '
#Region "BTN CANCELAR SAIR"
    '--------------------------------------------------------------------------------------------------------
    ' CANCELAR e SAIR
    '--------------------------------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If _Sit = EnumFlagEstado.Alterado Then
            '
            LerConfigXML()
            '
            '-- Get Conta Padrao
            If Not IsNothing(IDConta_Config) Then
                GetConta(IDConta_Config)
            Else
                _Conta = New clConta
            End If
            '
            Sit = EnumFlagEstado.RegistroSalvo
            '
        ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
            DialogResult = DialogResult.Cancel
            Close()
        Else
            DialogResult = DialogResult.Cancel
            Me.Close()
        End If
        '
    End Sub
    '
#End Region
    '
#Region "MOVER FORM SEM BORDA"
    ' MOVER O FORMULÁRIO SEM BORDA
    '-----------------------------------------------------------------------------------------------
    Private Sub Painel_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lblTitulo.MouseDown
        '
        Px = Cursor.Position.X - Me.Left
        Py = Cursor.Position.Y - Me.Top + Screen.PrimaryScreen.WorkingArea.Height - frmPrincipal.ClientSize.Height + Panel1.Height - 25
        '
        Mover = True
        '
    End Sub
    Private Sub Painel_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lblTitulo.MouseUp
        Mover = False
    End Sub
    '
    Private Sub Painel_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lblTitulo.MouseMove
        If Mover = True Then
            Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - Px,
                                                     MousePosition.Y - Me.Location.Y - Py))
        End If
    End Sub
    '
#End Region
    '
#Region "TOOLTIPS"
    '
    Private Sub addToolTipHandler()
        '
        ' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
        txtPermanencia.Tag = "Taxa de permanência padrão aplicada na Venda Crédito"
        txtDescontoMaximo.Tag = "Desconto Máximo permitido ao usuário padrão na Venda"
        chkEstoqueNegativo.Tag = "Permite produtos com estoque negativo..."
        '
        Dim listControles As New List(Of Control)
        '
        listControles.Add(txtPermanencia)
        listControles.Add(txtDescontoMaximo)
        listControles.Add(chkEstoqueNegativo)
        listControles.Add(txtFilialPadrao)
        listControles.Add(txtContaPadrao)
        '
        For Each c As Control In listControles
            AddHandler c.GotFocus, AddressOf showToolTip
            AddHandler c.MouseHover, AddressOf showToolTip
        Next
        '
    End Sub
    '
    Private Sub showToolTip(sender As Object, e As EventArgs)
        '
        Dim myControl As Control = DirectCast(sender, Control)
        '
        ' Cria a ToolTip e associa com o Form container.
        Dim toolTip1 As New ToolTip()
        '
        ' Define o delay para a ToolTip.
        With toolTip1
            .AutoPopDelay = 2000
            .InitialDelay = 1000
            .ReshowDelay = 500
            .IsBalloon = True
            .UseAnimation = True
            .UseFading = True
        End With
        '
        If myControl.Tag = "" Then
            toolTip1.Show("Pressione '+'  para escolher...", myControl, myControl.Width - 30, -40, 1000)
        Else
            toolTip1.Show(myControl.Tag, myControl, myControl.Width - 30, -40, 1000)
        End If
        '
        RemoveHandler myControl.GotFocus, AddressOf showToolTip
        'RemoveHandler myControl.MouseHover, AddressOf showToolTip
        '
    End Sub
    '
#End Region '// TOOLTIPS
    '
End Class