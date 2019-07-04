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
        dtpConhecimentoData.MaxDate = Today
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
        AddHandler txtFreteValor.DataBindings("text").Format, AddressOf idFormatCur
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
    Private Sub idFormatCur(sender As Object, e As ConvertEventArgs)
        If IsDBNull(e.Value) Then Exit Sub
        e.Value = Format(e.Value, "C")
    End Sub
    '
#End Region
    '
#Region "ACAO BOTOES"
    '
    '--- FECHAR
    '----------------------------------------------------------------------------------
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        _frete.CancelEdit()
        AutoValidate = AutoValidate.Disable
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
    '--- BTN CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        _frete.CancelEdit()
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
        Dim Transp As clTransportadora = frmT.propTransportadora_Escolha
        '
        txtTransportadora.Text = Transp.Cadastro
        IDTransportadora = Transp.IDPessoa
        '
        If If(oldID, 0) <> If(IDTransportadora, 0) Then
            Sit = EnumFlagEstado.Alterado
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
    ' SOMENTE NUMEROS E LETRAS UPPER CASE
    '---------------------------------------------------------------------------------------
    Private Sub txtConhecimento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConhecimento.KeyPress
        '
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            DirectCast(sender, TextBox).SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        Else
            e.Handled = True
        End If
        '
    End Sub
    '
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransportadora.KeyDown
        '
        Dim ctr As Control = DirectCast(sender, Control)
        '
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            Select Case ctr.Name
                Case "txtTransportadora"
                    btnTransportadora_Click(New Object, New EventArgs)
            End Select
        ElseIf e.KeyCode = Keys.Delete Then
            Dim oldID As Integer? = IDTransportadora
            e.Handled = True
            Select Case ctr.Name
                Case "txtTransportadora"
                    txtTransportadora.Clear()
                    IDTransportadora = Nothing
                    If Not IsNothing(oldID) Then Sit = EnumFlagEstado.Alterado
            End Select
        Else
            e.Handled = True
            e.SuppressKeyPress = True
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
            Dim db As New FreteBLL
            '
            If Sit = EnumFlagEstado.NovoRegistro Then '--> SAVE NEW
                '
                MessageBox.Show("Salvar novo frete ainda não implementado...")
                '
            ElseIf Sit = EnumFlagEstado.Alterado Then '--> UPDATE
                '
                db.FreteUpdate(_frete)
                '
            End If
            '
            MessageBox.Show("Frete Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bindFrete.EndEdit()
            Sit = EnumFlagEstado.RegistroSalvo
            '
            DialogResult = DialogResult.OK
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
    Private Function VerificaCampos() As Boolean
        '
        Dim u As New Utilidades
        '
        If Not u.VerificaDadosClasse(txtTransportadora, "Transportadora", _frete) Then
            Return False
        End If
        '
        If Not u.VerificaDadosClasse(txtConhecimento, "Número do Conhecimento", _frete) Then
            Return False
        End If
        '
        If Not u.VerificaDadosClasse(dtpConhecimentoData, "Data do Conhecimento", _frete) Then
            Return False
        End If
        '
        If Not u.VerificaDadosClasse(txtFreteValor, "Valor do Frete", _frete) Then
            Return False
        End If
        '
        If txtFreteValor.Text <= 0 Then
            MessageBox.Show("O Valor do Frete não pode ser igual a Zero...",
                            "Valor do Frete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
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
