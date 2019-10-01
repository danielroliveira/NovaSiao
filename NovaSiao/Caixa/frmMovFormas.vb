Imports CamadaBLL
Imports CamadaDTO
Imports ComponentOwl.BetterListView
Imports System.Drawing.Drawing2D
'
Public Class frmMovFormas
    '
    Private WithEvents listMovFormas As New List(Of clMovForma)
    Private WithEvents bindMovForma As New BindingSource
    Private _MovForma As clMovForma
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    '
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
    Private _IDFilial As Integer
    Private _IDConta As Int16
    '
#Region "EVENTO LOAD E PROPRIEDADE SIT"
    '
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            '
            _Sit = value
            '
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False
                lstFormas.ReadOnly = False
                '
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnExcluir.Enabled = True
                btnCancelar.Enabled = True
                lstFormas.ReadOnly = True
                '
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtMovForma.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = True
                lstFormas.ReadOnly = True
                '
            End If
            '
        End Set
        '
    End Property
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '
        '--- define a FilialPadrao
        _IDFilial = Obter_FilialPadrao()
        lblFilial.Text = ObterDefault("FilialDescricao")
        '
    End Sub
    '
    ' EVENTO LOAD
    Private Sub frmPagamentoFormas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ObterDados()
        bindMovForma.DataSource = listMovFormas
        '
        If listMovFormas.Count > 0 Then
            bindMovForma.MoveFirst()
            PreencheDataBindings()
            Sit = EnumFlagEstado.RegistroSalvo
            '
        Else
            bindMovForma.AddNew()
            DirectCast(bindMovForma.Current, clMovForma).IDFilial = _IDFilial
            Sit = EnumFlagEstado.NovoRegistro
            PreencheDataBindings()
        End If
        '
        _MovForma = bindMovForma.Current
        PreencheListagem()
        '
        ' HABILITA OU DESABILITA CONTROLES DO CARTAO
        VerificaCartaoTipo()
        '
        DirectCast(bindMovForma.Current, clMovForma).RegistroAlterado = False
        '
    End Sub
    '
    Private Sub ObterDados()
        '
        Dim fBLL As New MovimentacaoBLL
        '
        Try
            listMovFormas = fBLL.MovForma_GET_List(_IDFilial)
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao obter a lista das Formas de Pagamento..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "BINDIGNS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblIDMovForma.DataBindings.Add("Text", bindMovForma, "IDMovForma", True, DataSourceUpdateMode.OnPropertyChanged)
        txtMovForma.DataBindings.Add("Text", bindMovForma, "MovForma", True, DataSourceUpdateMode.OnPropertyChanged)
        txtComissao.DataBindings.Add("Text", bindMovForma, "Comissao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtParcelas.DataBindings.Add("Text", bindMovForma, "Parcelas", True, DataSourceUpdateMode.OnPropertyChanged)
        txtNoDias.DataBindings.Add("Text", bindMovForma, "NoDias", True, DataSourceUpdateMode.OnPropertyChanged)
        txtMovTipo.DataBindings.Add("Text", bindMovForma, "MovTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtCartao.DataBindings.Add("Text", bindMovForma, "Cartao", True, DataSourceUpdateMode.OnPropertyChanged)
        txtConta.DataBindings.Add("Text", bindMovForma, "ContaPadrao", True, DataSourceUpdateMode.OnPropertyChanged)
        'lblFilial.DataBindings.Add("Text", bindMovForma, "ApelidoFilial")
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDMovForma.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler txtParcelas.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler txtNoDias.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler txtComissao.DataBindings("Text").Format, AddressOf idFormatCur
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(bindMovForma.CurrencyManager.Current, clMovForma).AoAlterar, AddressOf Handler_AoAlterar
        AddHandler bindMovForma.CurrentChanged, AddressOf handler_CurrentChanged
        '
    End Sub
    '
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(IIf(IsDBNull(e.Value), Nothing, e.Value), "00")
    End Sub
    '
    Private Sub idFormatCur(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(IIf(IsDBNull(e.Value), Nothing, e.Value), "0.00")
    End Sub
    '
    Private Sub Handler_AoAlterar()
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
        '
        _MovForma = DirectCast(bindMovForma.CurrencyManager.Current, clMovForma)
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler _MovForma.AoAlterar, AddressOf Handler_AoAlterar
        '
        '--- Clear the Error Provider
        epValida.Clear()
        '
        '--- Nesse caso é um novo registro
        If Not IsNothing(_MovForma.IDMovForma) Then
            '
            ' LER O ID
            lblIDMovForma.DataBindings.Item("text").ReadValue()
            '
            ' ALTERAR PARA REGISTRO SALVO
            Sit = EnumFlagEstado.RegistroSalvo
            _MovForma.RegistroAlterado = False
            '
            ' VERIFICA O ATIVO BUTTON
            AtivoButtonImage()
            '
            ' HABILITA OU DESABILITA CONTROLES DO CARTAO
            VerificaCartaoTipo()
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM FORMATACAO"
    '
    ' FORMATAR A LISTAGEM
    Private Sub PreencheListagem()
        lstFormas.DataSource = bindMovForma
        '
        With clnIDMovForma ' column 0
            .Width = 50
            .DisplayMember = "IDMovForma"
        End With
        '
        With clnMovForma ' column 1
            .Width = 220
            .DisplayMember = "MovForma"
        End With
        '
    End Sub
    '
    ' ALTERA A COR DO HEADER DO LISTBOX
    Private Sub lstFormas_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstFormas.DrawColumnHeader
        '
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso
            eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            ' Pode Colocar: AndAlso eventArgs.ColumnHeader.Index = 1 AndAlso
            '
            Dim brush As Brush = New LinearGradientBrush(eventArgs.ColumnHeaderBounds.BoundsOuter, Color.Transparent, Color.FromArgb(100, Color.LightSlateGray), LinearGradientMode.Vertical)
            Dim p As Pen = New Pen(Color.SlateGray, 2)
            '
            eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)
            '
            eventArgs.Graphics.DrawLine(p, eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x1
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Height, 'y1
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Width + eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x2
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Height) 'y2
            brush.Dispose()
            p.Dispose()
        End If
        '
    End Sub
    '
    ' ESCREVE OS TEXTOS DE TIPO DE ACESSO NA LISTAGEM
    Private Sub lstFormas_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstFormas.DrawItem
        '
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "00")
        End If
        '
    End Sub
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    ' ATIVAR OU DESATIVAR FORMA BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR uma Nova Forma de Entrada", "Desativar Forma",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        If _MovForma.Ativo = True Then '---usuario ativo
            If MessageBox.Show("Você deseja realmente DESATIVAR a Forma de Entrada:" & vbNewLine &
            txtMovForma.Text.ToUpper, "Desativar Forma", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        Else '---Usuário Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR a Forma de Entrada:" & vbNewLine &
            txtMovForma.Text.ToUpper, "Ativar Forma", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        End If
        '
        DirectCast(bindMovForma.Current, clMovForma).BeginEdit()
        _MovForma.Ativo = Not _MovForma.Ativo
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        AtivoButtonImage()
        '
    End Sub
    '
    ' BOTÃO CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If Sit = EnumFlagEstado.Alterado Then ' REGISTRO ALTERADO
            If MessageBox.Show("Deseja cancelar todas as alterações feitas no registro atual?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                '
                bindMovForma.CancelEdit()
                txtMovForma.Focus()
                VerificaCartaoTipo()
                Sit = EnumFlagEstado.RegistroSalvo
                '
            End If
        ElseIf Sit = EnumFlagEstado.NovoRegistro Then ' REGISTRO NOVO
            If lstFormas.Items.Count = 0 Then
                MessageBox.Show("Não é possível cancelar porque não existe outro registro." & vbNewLine &
                                "Se deseja sair apenas feche a janela!", "Cancelar Edição", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            Sit = EnumFlagEstado.RegistroSalvo
            bindMovForma.RemoveCurrent()
            '
        End If
        '
    End Sub
    '
    ' BOTÃO NOVO REGISTRO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '
        lstFormas.SelectedItems.Clear()
        '
        '---cria um novo DataRow com valores padrão
        Dim row As New clMovForma
        row.Ativo = True
        row.Parcelas = 0
        row.Comissao = Format(0, "0.00")
        row.NoDias = Format(0, "00")
        row.IDFilial = _IDFilial
        row.ApelidoFilial = ObterDefault("FilialDescricao")
        '
        '---adiciona o NewROW
        listMovFormas.Add(row)
        bindMovForma.MoveLast()
        '
        '---altera o SIT
        Sit = EnumFlagEstado.NovoRegistro
        VerificaCartaoTipo()
        txtMovForma.Focus()
        '
    End Sub
    '
    ' BOTÃO FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    ' BOTÃO EXCLUIR
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        MsgBox("Ainda não implementado")
    End Sub
    '
    ' BUTON ABRIR FORMA TIPOS
    Private Sub btnMovTipos_Click(sender As Object, e As EventArgs) Handles btnMovTipos.Click
        '
        '---abre o formTipos
        Dim frmTipo As New frmMovTipoProcurar(Me)
        frmTipo.ShowDialog()
        '
        '---verifica os valores
        If frmTipo.DialogResult <> DialogResult.OK Then
            txtMovTipo.Focus()
            Exit Sub
        End If
        '
        '--- grava os novos valores
        txtMovTipo.Text = frmTipo.propMovTipo_Escolha
        _MovForma.IDMovTipo = frmTipo.propIdMovTipo_Escolha
        _MovForma.IDMeio = frmTipo.propMeio_Escolha
        txtMovTipo.Focus()
        txtMovTipo.SelectAll()
        '
        '--- habilita os controles caso desabilitados
        VerificaCartaoTipo()
        '
    End Sub
    '
    ' BUTON ABRIR CARTAO PROCURA
    Private Sub btnCartao_Click(sender As Object, e As EventArgs) Handles btnCartao.Click
        '
        Dim clF As clMovForma = DirectCast(bindMovForma.CurrencyManager.Current, clMovForma)
        '    
        '---abre o formTipos
        Dim frmCartao As New frmCartaoTipos(True, Me, clF.IDCartao)
        frmCartao.ShowDialog()
        '
        '---verifica os valores
        If frmCartao.DialogResult <> DialogResult.OK Then
            txtCartao.Focus()
            Exit Sub
        End If
        '
        '--- grava os novos valores
        txtCartao.Text = frmCartao.OrigemDesc_Escolhido
        clF.IDCartao = frmCartao.IDOrigem_Escolhido
        txtCartao.Focus()
        txtCartao.SelectAll()
        '
    End Sub
    '
    '--- VERIFICA SE E MOV CARTAO PARA HABILITAR OS CONTROLES
    Private Sub VerificaCartaoTipo(Optional AnulaPropriedades As Boolean = False)
        '
        If _MovForma.IDMeio <> 3 Then ' 1 --> DINHEIRO | 2 --> CHEQUE | 3 --> MEIO CARTAO
            '
            txtCartao.Enabled = False
            txtConta.Enabled = False
            txtParcelas.Enabled = False
            txtNoDias.Enabled = False
            txtComissao.Enabled = False
            btnContaEscolher.Enabled = False
            btnCartao.Enabled = False
            '
            If AnulaPropriedades Then
                With _MovForma
                    .IDCartao = Nothing
                    .ContaPadrao = Nothing
                    .Parcelas = Nothing
                    .NoDias = Nothing
                    .Comissao = Nothing
                End With
            End If
            '
        Else ' NESSE CASO = 3 (MEIO CARTAO)
            txtCartao.Enabled = True
            txtConta.Enabled = True
            txtParcelas.Enabled = True
            txtNoDias.Enabled = True
            txtComissao.Enabled = True
            btnContaEscolher.Enabled = True
            btnCartao.Enabled = True
        End If
        '
    End Sub
    '
    Private Sub btnContaEscolher_Click(sender As Object, e As EventArgs) Handles btnContaEscolher.Click
        '
        '--- Verifica se existe uma filial definida
        If IsNothing(_IDFilial) Then
            MessageBox.Show("É necessário definir a Filial para escolher a conta a partir dela..." & vbNewLine &
                            "Favor escolher uma Filial Padrão...",
                            "Escolher Filial",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return
        End If
        '
        Dim clF As clMovForma = DirectCast(bindMovForma.CurrencyManager.Current, clMovForma)
        '
        '--- Abre o frmContas
        Dim frmConta As New frmContaProcurar(Me, _IDFilial, _IDConta)
        '
        frmConta.ShowDialog()
        '
        If frmConta.DialogResult = DialogResult.Cancel Then Exit Sub
        '
        txtConta.Text = frmConta.propConta_Escolha.Conta
        _IDConta = frmConta.propConta_Escolha.IDConta
        clF.IDContaPadrao = _IDConta
        '
    End Sub
    '
#End Region
    '
#Region "SALVA REGISTRO"
    '
    '--- BTN SALVAR REGISTRO
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If VerificaDados() = False Then Exit Sub
        '
        Dim movBLL As New MovimentacaoBLL
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            Try
                Dim newID As Int16 = movBLL.MovForma_Inserir(_MovForma)
                '
                _MovForma.IDMovForma = newID
                lblIDMovForma.DataBindings("Text").ReadValue()
                '
                Sit = EnumFlagEstado.RegistroSalvo
                bindMovForma.EndEdit()
                bindMovForma.ResetBindings(True)
                '
                '---informa o usuário
                MessageBox.Show("Registro Inserido com sucesso!", "Registro Salvo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
            Catch ex As Exception
                MessageBox.Show("Esse Registro NÃO foi salvo com sucesso!" & vbNewLine &
                                ex.Message, "Exceção Inesperada",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            Try
                movBLL.MovForma_Update(_MovForma)
                '
                Sit = EnumFlagEstado.RegistroSalvo
                bindMovForma.EndEdit()
                '
                '---informa o usuário
                MessageBox.Show("Registro Atualizado com sucesso!", "Registro Salvo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
            Catch ex As Exception
                MessageBox.Show("Esse Registro NÃO foi salvo com sucesso!" & vbNewLine &
                                ex.Message, "Exceção Inesperada",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        '
    End Sub
    '
    ' VERIFICA OS DADOS ANTES DE SALVAR
    Private Function VerificaDados() As Boolean
		'
		If _MovForma.IDMovForma IsNot Nothing AndAlso _MovForma.IDMovForma = 1 Then
			AbrirDialog("Não é possível alterar a Forma de Movimentação: DINHEIRO." & vbNewLine &
						"Essa forma de movimentação é inserida autmaticamente pelo sistema.",
						"Forma de Movimentação Padrão",
						frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			bindMovForma.CancelEdit()
			txtMovForma.Focus()
			VerificaCartaoTipo()
			Sit = EnumFlagEstado.RegistroSalvo
			Return False
		End If
		'
		Dim f As New Utilidades
        '
        If Not f.VerificaDadosClasse(txtMovForma, "Descrição da Forma de Movimento", _MovForma, epValida) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(txtMovTipo, "Tipo da Forma de Pagamento", _MovForma, epValida) Then
            Return False
        End If
        '
        If Not IsNothing(_MovForma.IDCartao) Then
            '
            If Not f.VerificaDadosClasse(txtNoDias, "Intervalo/Prazo de pagamento do Cartão", _MovForma, epValida) Then
                Return False
            End If
            '
            If _MovForma.NoDias <= 0 Then
                MessageBox.Show("O número de dias não pode ser igual ou menor que Zero...", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNoDias.Focus()
                Return False
            End If
            '
            If Not f.VerificaDadosClasse(txtParcelas, "Quantidade de Parcelas de pagamento", _MovForma, epValida) Then
                Return False
            End If
            '
            If _MovForma.Parcelas < 0 Then
                MessageBox.Show("O número de parcelas não pode ser menor que Zero...", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtParcelas.Focus()
                Return False
            End If
            '
            If Not f.VerificaDadosClasse(txtComissao, "Comissão da Operadora de Cartão", _MovForma, epValida) Then
                Return False
            End If
            '
            If _MovForma.Comissao < 0 Or _MovForma.Comissao > 99 Then
                MessageBox.Show("A taxa de comissão não pode ser menor que Zero ou maior que 100%", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtComissao.Focus()
                Return False
            End If
            '
        Else
            VerificaCartaoTipo(True)
        End If
        '
        Return True
        '
    End Function
    '
#End Region
    '
#Region "ATALHOS E FUNCOES UTILITARIAS"
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        Try
            If _MovForma.Ativo = True Then ' Nesse caso é Forma Ativo
                btnAtivo.Image = AtivarImage
                btnAtivo.Text = "Forma Ativa"
            ElseIf _MovForma.Ativo = False Then ' Nesse caso é Forma Inativo
                btnAtivo.Image = DesativarImage
                btnAtivo.Text = "Forma Inativa"
            End If
        Catch ex As System.IndexOutOfRangeException
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Forma Ativa"
        End Try
        '
    End Sub
    '
    '
    '--- BLOQUEIA PRESS A TECLA (+)
    Private Sub me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        '
        If e.KeyChar = "+" Then
            '--- cria uma lista de controles que serao impedidos de receber '+'
            Dim controlesBloqueados As String() = {
                "txtMovForma",
                "txtMovTipo",
                "txtCartao",
                "txtConta"
            }
            '
            If controlesBloqueados.Contains(ActiveControl.Name) Then
                e.Handled = True
            End If
            '
        End If
        '
    End Sub
    '
    '--- EXECUTAR A FUNCAO DO BOTAO QUANDO PRESSIONA A TECLA (+) NO CONTROLE
    '--- ACIONA ATALHO TECLA (+) E (DEL) | IMPEDE INSERIR TEXTO NOS CONTROLES
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtMovTipo.KeyDown, txtCartao.KeyDown, txtConta.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            '
            Select Case ctr.Name
                Case "txtConta"
                    btnContaEscolher_Click(New Object, New EventArgs)
                Case "txtMovTipo"
                    btnMovTipos_Click(New Object, New EventArgs)
                Case "txtCartao"
                    btnCartao_Click(New Object, New EventArgs)
            End Select
            '
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtConta"
                    If Not IsNothing(_MovForma.IDContaPadrao) Then Sit = EnumFlagEstado.Alterado
                    txtConta.Clear()
                    _MovForma.IDContaPadrao = Nothing
                Case "txtMovTipo"
                    If Not IsNothing(_MovForma.IDMovTipo) Then Sit = EnumFlagEstado.Alterado
                    txtMovTipo.Clear()
                    _MovForma.IDMovTipo = Nothing
                Case "txtCartao"
                    If Not IsNothing(_MovForma.IDCartao) Then Sit = EnumFlagEstado.Alterado
                    txtCartao.Clear()
                    _MovForma.IDCartao = Nothing
                    VerificaCartaoTipo()
            End Select
            '
        Else
            '--- cria uma lista de controles que serão bloqueados de alteracao
            Dim controlesBloqueados As New List(Of String)
            controlesBloqueados.AddRange({"txtConta", "txtMovTipo", "txtCartao"})
            '
            If controlesBloqueados.Contains(ctr.Name) Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
        End If
        '
    End Sub
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMovForma.KeyDown, txtMovTipo.KeyDown,
            txtCartao.KeyDown, txtConta.KeyDown, txtParcelas.KeyDown, txtComissao.KeyDown, txtNoDias.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub

    Private Sub tsMenu_Enter(sender As Object, e As EventArgs) Handles tsMenu.Enter
        btnNovo.Select()
    End Sub
    '
#End Region
    '
End Class
