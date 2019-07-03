Imports CamadaBLL
Imports CamadaDTO

Public Class frmFrete
    Private _frete As clFrete
    Private _formOrigem As Form
    Private bindFrete As New BindingSource
    Private IDTransportadora As Integer?
    Dim _Sit As Byte
    '
#Region "LOAD | NEW"
    '
    ' PROPRIEDADE SIT
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                lblID.Text = If(Format(_frete.IDTransacao, "0000"), "")
                btnSalvar.Enabled = False
                btnCancelar.Enabled = False
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtTransportadora.Focus()
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
                lblID.Text = "NOVA"
            End If
        End Set
    End Property
    '
    Public Property propFrete() As clFrete
        '
        Get
            Return _frete
        End Get
        Set(ByVal value As clFrete)
            '
            If IsNothing(value.IDTransacao) Then
                Sit = EnumFlagEstado.NovoRegistro
            End If
            '
            _frete = value
            bindFrete.DataSource = _frete
        End Set
        '
    End Property
    '
    Sub New(frete As clFrete, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propFrete = frete
        bindFrete.DataSource = _frete
        PreencheDataBindings()
        _formOrigem = formOrigem
        '
        If Not IsNothing(_frete.IDTransacao) Then Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
#End Region
    '
#Region "DATABINDINGS"

    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
        '
        lblID.DataBindings.Add("Tag", bindFrete, "IDTransacao")
        txtTransportadora.DataBindings.Add("Text", bindFrete, "Transportadora", True, DataSourceUpdateMode.OnPropertyChanged)
        txtConhecimento.DataBindings.Add("Text", bindFrete, "Conhecimento", True, DataSourceUpdateMode.OnPropertyChanged)
        txtFreteValor.DataBindings.Add("Text", bindFrete, "FreteValor", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpConhecimentoData.DataBindings.Add("Value", bindFrete, "ConhecimentoData", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler bindFrete.CurrentChanged, AddressOf handler_CurrentChanged
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(bindFrete.CurrencyManager.Current, clFrete).AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(bindFrete.CurrencyManager.Current, clFrete).AoAlterar, AddressOf HandlerAoAlterar
        '
        '--- Nesse caso é um novo registro
        If IsNothing(DirectCast(bindFrete.Current, clFrete).IDTransacao) Then
            Exit Sub
        Else
            ' LER O ID
            lblID.DataBindings.Item("Tag").ReadValue()
            ' ALTERAR PARA REGISTRO SALVO
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '
    End Sub
    '
    Private Sub HandlerAoAlterar()
        If bindFrete.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
        If IsDBNull(e.Value) Then Exit Sub
        e.Value = Format(e.Value, "0000")
    End Sub
    '
#End Region
    '
#Region "ACAO BOTOES"
    '
    '--- BTN CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        AutoValidate = AutoValidate.Disable
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
    Private Sub btnTransportadora_Click(sender As Object, e As EventArgs) Handles btnTransportadora.Click
        '
        '--- Ampulheta ON
        Cursor = Cursors.WaitCursor
        '
        Dim frmT As New frmTransportadoraProcurar(True, Me)
        Dim oldID As Integer? = IDTransportadora
        '
        frmT.ShowDialog()
        '
        '--- Ampulheta OFF
        Cursor = Cursors.Default
        '
        If frmT.DialogResult = DialogResult.Cancel Then
            txtTransportadora.Clear()
            IDTransportadora = Nothing
        Else
            Dim Transp As clTransportadora = frmT.propTransportadora_Escolha
            '
            txtTransportadora.Text = Transp.Cadastro
            IDTransportadora = Transp.IDPessoa
        End If
        '
        txtTransportadora.Focus()
        '
    End Sub
    '
#End Region
    '
#Region "CONTROLES"
    '
    '---------------------------------------------------------------------------------------
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    '---------------------------------------------------------------------------------------
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) _

        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    ' EVITA DIGITACAO DE TEXTO
    '---------------------------------------------------------------------------------------
    Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs)
        '
        If Char.IsNumber(e.KeyChar) OrElse New Char() {vbBack, ","}.Contains(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "."c Then
            DirectCast(sender, TextBox).SelectedText = ","
            e.Handled = True
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
#End Region '/ CONTROLES
    '
#Region "SALVAR REGISTRO"
    '
    ' SALVAR O REGISTRO
    '-----------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        '--- check if Apelido and Aliquota is OK
        If Not VerificaCampos() Then Return
        '
        '--- SAVE
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim db As New PessoaBLL
            '
            If Sit = EnumFlagEstado.NovoRegistro Then '--> SAVE NEW
                '
                Dim resolve As Object = db.InsertNewPessoa(_frete, PessoaBLL.EnumPessoaGrupo.FILIAL)
                '
                If Not IsNumeric(resolve) Then
                    Throw New Exception("Uma exceção inesperada ocorreu ao Salvar Registro")
                    Return
                End If
                '
                _frete.IDPessoa = resolve
                lblID.DataBindings.Item("Tag").ReadValue()
                '
            ElseIf Sit = EnumFlagEstado.Alterado Then '--> UPDATE
                '
                db.UpdatePessoa(_frete, PessoaBLL.EnumPessoaGrupo.FILIAL)
                '
            End If
            '
            MessageBox.Show("Filial Salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bindFrete.EndEdit()
            Sit = EnumFlagEstado.RegistroSalvo
            '
            DialogResult = DialogResult.OK
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Inserir Nova Filial..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
    End Sub
    '
    Private Function VerificaCampos() As Boolean
        '
        '--- FILIAL NAME
        '----------------------------------------------------------------------------------
        '
        '--- Tamanho Mínimo
        If txtApelidoFilial.Text.Length < 5 Then
            MessageBox.Show("O Apelido da Filial deve ter no mínimo de 5 caracteres...")
            txtApelidoFilial.Focus()
            Return False
        End If
        '
        '--- Transforma primeira em Maiuscula
        txtApelidoFilial.Text = Utilidades.PrimeiraLetraMaiuscula(txtApelidoFilial.Text)
        '
        '--- PROCURAR MESMO CADASTRO NOME
        '----------------------------------------------------------------------------------
        Dim db As New PessoaBLL
        Dim pes As clPessoa = db.ProcuraPessoaPeloCadastroNome(txtApelidoFilial.Text)
        '
        If Not IsNothing(pes) Then
            '
            If IsNothing(_frete.IDPessoa) OrElse _frete.IDPessoa = 0 Then '--> NOVO REGISTRO
                '
                MessageBox.Show("Já existe um cadastro de 'PESSOA' com esse mesmo 'NOME'...")
                txtApelidoFilial.Focus()
                Return False
                '
            Else '---> REGISTRO SALVO
                '
                If _frete.IDPessoa <> pes.IDPessoa Then
                    MessageBox.Show("Já existe um cadastro de 'PESSOA' com esse mesmo 'NOME'...")
                    txtApelidoFilial.Focus()
                    Return False
                End If
                '
            End If
            '
        End If
        '
        '--- ALIQUOTA ICMS
        '----------------------------------------------------------------------------------
        '
        If txtAliquotaICMS.Text.Trim.Length = 0 Then txtAliquotaICMS.Text = "0"
        '
        Dim icms As Double = 0
        Double.TryParse(txtAliquotaICMS.Text, icms)
        '
        If icms < 0 OrElse icms > 99 Then
            MessageBox.Show("O valor da Alíquota do ICMS deve estar entre 0 e 99")
            txtAliquotaICMS.Focus()
            Return False
        End If
        '
        Return True
        '
    End Function
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
