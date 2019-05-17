Imports CamadaBLL
Imports CamadaDTO
Imports ComponentOwl.BetterListView
Imports System.Drawing.Drawing2D
'
Public Class frmContas
    '
    Private listConta As New List(Of clConta)
    Private bindConta As New BindingSource
    Private _conta As clConta
    '
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
    Private _formOrigem As Form
    Private _IDFilialPadrao As Integer
    Private _Sit As Byte
    Private VerAlteracao As Boolean = False
    '
#Region "LOAD | PROPERTYS"
    '
    ' PROPRIEDADE SIT
    Private Property Sit As EnumFlagEstado
        Get
            Sit = _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            Select Case _Sit
                Case EnumFlagEstado.RegistroSalvo
                    '
                    btnNovo.Enabled = True
                    btnSalvar.Enabled = False
                    btnSalvar.Text = "&Salvar"
                    btnSalvar.Image = My.Resources.save
                    btnFechar.Text = "&Fechar"
                    lstItens.ReadOnly = False
                    '
                Case EnumFlagEstado.Alterado
                    '
                    btnNovo.Enabled = False
                    btnSalvar.Enabled = True
                    btnSalvar.Text = "&Salvar"
                    btnSalvar.Image = My.Resources.save
                    btnFechar.Text = "&Cancelar"
                    lstItens.ReadOnly = True
                                        '
                Case EnumFlagEstado.NovoRegistro
                    '
                    btnNovo.Enabled = False
                    btnSalvar.Enabled = True
                    btnSalvar.Text = "&Salvar"
                    btnSalvar.Image = My.Resources.save
                    btnFechar.Text = "&Cancelar"
                    lstItens.ReadOnly = True
                    '
            End Select
        End Set
        '
    End Property
    '
    Sub New(Optional formOrigem As Form = Nothing,
            Optional idFilialPadrao As Integer? = Nothing,
            Optional FilialPadrao As String = "")
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        '--- Preenche lblFilial e _IDFilial
        '--- if idFilialPadrao isNothing then define
        If IsNothing(idFilialPadrao) Then
            lblFilial.Text = ObterDefault("FilialDescricao")
            _IDFilialPadrao = Obter_FilialPadrao()
        Else
            lblFilial.Text = FilialPadrao
            _IDFilialPadrao = idFilialPadrao
        End If
        '
        '--- obtem a lista de Contas
        ObtemDados()
        '
        '--- Prenche a Listagem
        PreencheListagem()
        '
        '--- Verifica se é novo registro
        If listConta.Count > 0 Then
            bindConta.MoveFirst()
            PreencheDataBindings()
            Sit = EnumFlagEstado.RegistroSalvo
            '
        Else
            bindConta.AddNew()
            Sit = EnumFlagEstado.NovoRegistro
            PreencheDataBindings()
        End If
        '
        _conta = bindConta.Current
        '
        '--- Verifica se o IDFilial é valido
        If IsNothing(_conta.IDFilial) Or _conta.IDFilial = 0 Then
            _conta.IDFilial = idFilialPadrao
            _conta.ApelidoFilial = FilialPadrao
        End If
        '
        VerAlteracao = True
        '
    End Sub
    '
    Private Sub ObtemDados()
        '
        Dim cBLL As New MovimentacaoBLL
        listConta = cBLL.Contas_GET_PorIDFilial(_IDFilialPadrao)
        bindConta.DataSource = listConta
        '
    End Sub
    '
#End Region
    '
#Region "DATA BINDGING"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblIDConta.DataBindings.Add("Text", bindConta, "IDConta", True)
        txtConta.DataBindings.Add("Text", bindConta, "Conta", True, DataSourceUpdateMode.OnPropertyChanged)
        lblFilial.DataBindings.Add("Text", bindConta, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        lblSaldoAtual.DataBindings.Add("Text", bindConta, "SaldoAtual", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' CARREGA O COMBO TIPO
        CarregaComboTipo()
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDConta.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblSaldoAtual.DataBindings("text").Format, AddressOf FormatCUR
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(bindConta.CurrencyManager.Current, clConta).AoAlterar, AddressOf Handler_AoAlterar
        AddHandler bindConta.CurrentChanged, AddressOf handler_CurrentChanged
        '
    End Sub
    '
    Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
        e.Value = Format(IIf(IsDBNull(e.Value), Nothing, e.Value), "00")
    End Sub
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
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
        Try

            _conta = DirectCast(bindConta.CurrencyManager.Current, clConta)
            '
            ' ADD HANDLER PARA DATABINGS
            AddHandler _conta.AoAlterar, AddressOf Handler_AoAlterar
            '
            '--- Nesse caso é um novo registro
            If Not IsNothing(_conta.IDConta) Then
                '
                ' LER O ID
                lblIDConta.DataBindings.Item("text").ReadValue()
                '
                ' ALTERAR PARA REGISTRO SALVO
                Sit = EnumFlagEstado.RegistroSalvo
                '
                ' VERIFICA O ATIVO BUTTON
                AtivoButtonImage()
                '
            End If
            '
        Catch ex As Exception
            Return
        End Try
        '
    End Sub
    '
#End Region '/ DATA BINDGING
    '
#Region "LISTAGEM FORMATACAO"
    '
    ' FORMATAR A LISTAGEM
    Private Sub PreencheListagem()
        '
        lstItens.DataSource = bindConta
        '
        With clnIDConta
            .Width = 50
            .DisplayMember = "IDConta"
        End With
        '
        With clnConta
            .Width = 250
            .DisplayMember = "Conta"
        End With
        '
    End Sub
    '
    ' ALTERA A COR DO HEADER DO LISTBOX
    Private Sub lstItens_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstItens.DrawColumnHeader
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
    Private Sub lstItens_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstItens.DrawItem
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "00")
        End If
    End Sub
    '
#End Region
    '
#Region "BUTONS"
    '
    ' BOTOES DO FORMULARIO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '
        lstItens.SelectedItems.Clear()
        '
        '---cria um novo DataRow com valores padrão
        Dim newConta As New clConta
        newConta.IDFilial = _IDFilialPadrao
        newConta.ApelidoFilial = lblFilial.Text
        '
        '---adiciona o NewROW
        listConta.Add(newConta)
        bindConta.MoveLast()
        '
        '---altera o SIT
        Sit = EnumFlagEstado.NovoRegistro
        '
        '---focus
        txtConta.Focus()
        '
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            '
            Close()
            '
            If IsNothing(_formOrigem) Then
                MostraMenuPrincipal()
            End If
            '
        ElseIf Sit = EnumFlagEstado.NovoRegistro Then
            '
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            '
            bindConta.CancelEdit()
            bindConta.MoveFirst()
            '
            Sit = EnumFlagEstado.RegistroSalvo
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            '
            If MessageBox.Show("Deseja cancelar todas as alterações realizadas?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            '
            bindConta.CancelEdit()
            AtivoButtonImage()
            '
            Sit = EnumFlagEstado.RegistroSalvo
            '
        End If
        '
    End Sub
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnFechar_Click(sender, e)
    End Sub
    '
    ' ATIVAR OU DESATIVAR USUARIO BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR uma Nova Conta", "Desativar Conta",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        If _conta.Ativo = True Then '--- ATIVA
            '
            If MessageBox.Show("Você deseja realmente DESATIVAR a Forma de Entrada:" &
                               vbNewLine &
                               txtConta.Text.ToUpper,
                               "Desativar Conta",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            '
        Else '--- INATIVO
            If MessageBox.Show("Você deseja realmente ATIVAR a Forma de Entrada:" &
                               vbNewLine &
                               txtConta.Text.ToUpper,
                               "Ativar Conta",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        End If
        '
        _conta.BeginEdit()
        _conta.Ativo = Not _conta.Ativo
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        AtivoButtonImage()
        '
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        Try
            If _conta.Ativo = True Then ' Nesse caso é Forma Ativo
                btnAtivo.Image = AtivarImage
                btnAtivo.Text = "Forma Ativa"
            ElseIf _conta.Ativo = False Then ' Nesse caso é Forma Inativo
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
#End Region
    '
#Region "SALVAR"
    '
    ' SALVAR REGISTRO
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            ' verifica preenchimento
            If Not VerificaControles() Then Return
            '
            ' verfica se já existe valor igual
            If VerificaDuplicado() Then Return
            '
            '-- salva novo
            SalvarNovoRegistro()
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            ' verifica preenchimento
            If Not VerificaControles() Then Return
            '
            ' verfica se já existe valor igual
            If VerificaDuplicado() Then Return
            '
            '-- salva novo
            SalvarAlteracaoRegistro()
            '
        End If
        '
    End Sub
    '
    '--- SALVAR UM NOVO REGISTRO
    Private Sub SalvarNovoRegistro()
        '
        '--- try salvar
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim mBLL As New MovimentacaoBLL
            '
            '--- Define o Valor do IDFilial
            _conta.IDFilial = _IDFilialPadrao
            '
            Dim newID As Integer = mBLL.Conta_Insert(_conta)
            _conta.IDConta = newID
            bindConta.EndEdit()
            bindConta.ResetBindings(False)
            '
            Sit = EnumFlagEstado.RegistroSalvo
            '
            MessageBox.Show("Sucesso ao salvar registro de Nova Conta",
                            "Registro Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar Registro..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    '--- SALVAR UM NOVO REGISTRO
    Private Sub SalvarAlteracaoRegistro()
        '
        '--- try salvar
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim mBLL As New MovimentacaoBLL
            '
            mBLL.Conta_Update(_conta)
            bindConta.EndEdit()
            Sit = EnumFlagEstado.RegistroSalvo
            '
            MessageBox.Show("Sucesso ao salvar alteração de registro da Conta",
                            "Registro Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Salvar Registro..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    ' VERIFICAR SE OS CONTROLES ESTAO PREENCHIDOS
    Private Function VerificaControles() As Boolean
        Dim f As New Utilidades
        '
        If Not f.VerificaDadosClasse(txtConta, "Descrição da Conta", _conta) Then
            Return False
        End If
        '
        If Not f.VerificaDadosClasse(cmbContaTipo, "Tipo da Conta", _conta) Then
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    ' VERIFICAR SE EXISTE UM REGISTRO COM A MESMA DESCRIÇÃO
    Private Function VerificaDuplicado() As Boolean
        '
        '---se não houver nenhum registro, Exit
        If listConta.Count = 0 Then
            Return False
        End If
        '
        '---verifica todos os ROWS procurando registro igual
        For Each c In listConta
            If c.Equals(_conta) Then Continue For '---se for a mesma ROW não verifica
            '
            If _conta.Conta = c.Conta Then
                MessageBox.Show("Já existe uma Conta com a mesma descrição:" & vbNewLine &
                txtConta.Text.ToUpper,
                "Conta Duplicado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation)
                txtConta.Focus()
                '
                '--- return
                Return True
            End If
            '
        Next
        '
        '---se não encontrar retorna FALSE
        Return False
        '
    End Function
    '
#End Region
    '
#Region "COMBO CONTROLE"
    '----------------------------------------------------------------------------
    ' PREENCHE O COMBO DOS TIPOS
    '----------------------------------------------------------------------------
    Private Sub CarregaComboTipo()
        '
        Dim dtTipo As New DataTable
        '
        '--- Adiciona as Colunas
        dtTipo.Columns.Add("idTIPO")
        dtTipo.Columns.Add("Tipo")
        '
        '--- Adiciona todas as possibilidades de Frete
        dtTipo.Rows.Add(New Object() {1, "Conta Local"})
        dtTipo.Rows.Add(New Object() {2, "Conta Bancária"})
        dtTipo.Rows.Add(New Object() {3, "Operadora de Cartão"})
        '
        With cmbContaTipo
            .DataSource = dtTipo
            .ValueMember = "idTIPO"
            .DisplayMember = "Tipo"
            .DataBindings.Add("SelectedValue", bindConta, "ContaTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS SUB-FORMULARIO PADRAO"
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.DarkSlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmAPagarItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If IsNothing(_formOrigem) Then Exit Sub
        '
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub




    '
#End Region
    '
End Class
