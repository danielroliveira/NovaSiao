Imports CamadaBLL
Imports CamadaDTO

Public Class frmFilial
    Private _filial As clFilial
    Private _formOrigem As Form
    Private BindFil As New BindingSource
    Dim _Sit As Byte
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
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
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnCancelar.Enabled = False
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtApelidoFilial.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnCancelar.Enabled = True
                lblID.Text = "NOVO"
            End If
        End Set
    End Property
    '
    Public Property propFilial() As clFilial
        '
        Get
            Return _filial
        End Get
        Set(ByVal value As clFilial)
            _filial = value
            BindFil.DataSource = _filial
            AtivoButtonImage()
        End Set
        '
    End Property
    '
    Sub New(filial As clFilial, Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        propFilial = filial
        BindFil.DataSource = _filial
        PreencheDataBindings()
        _formOrigem = formOrigem
        '
        Sit = EnumFlagEstado.RegistroSalvo
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
        lblID.DataBindings.Add("Tag", BindFil, "IDPessoa")
        txtApelidoFilial.DataBindings.Add("Text", BindFil, "ApelidoFilial", True, DataSourceUpdateMode.OnPropertyChanged)
        txtAliquotaICMS.DataBindings.Add("Text", BindFil, "AliquotaICMS", True, DataSourceUpdateMode.OnPropertyChanged)
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblID.DataBindings("Tag").Format, AddressOf idFormatRG
        AddHandler BindFil.CurrentChanged, AddressOf handler_CurrentChanged
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(BindFil.CurrencyManager.Current, clFornecedor).AoAlterar, AddressOf HandlerAoAlterar
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
        ' ADD HANDLER PARA DATABINGS
        AddHandler DirectCast(BindFil.CurrencyManager.Current, clFornecedor).AoAlterar, AddressOf HandlerAoAlterar
        '
        '--- Nesse caso é um novo registro
        If IsNothing(DirectCast(BindFil.Current, clFornecedor).IDPessoa) Then
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
        If BindFil.Current.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
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
    '--- BTN NOVO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '
        propFilial = New clFilial
        Sit = EnumFlagEstado.NovoRegistro
        txtApelidoFilial.Focus()
        '
    End Sub
    '
    '--- BTN CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        BindFil.CancelEdit()
        Sit = EnumFlagEstado.RegistroSalvo
        '
    End Sub
    '
    '--- BTN PROCURAR
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR uma Nova Filial...", "Desativar Filial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        Dim filial As clFornecedor = BindFil.Current
        '
        If filial.Ativo = True Then ' Fornecedor Ativo
            '
            If MessageBox.Show("Você deseja realmente DESATIVAR a Filial:" & vbNewLine &
                        txtApelidoFilial.Text.ToUpper, "Inativar Filial", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                filial.BeginEdit()
                filial.Ativo = False
                AtivoButtonImage()
            End If
            '
        ElseIf filial.Ativo = False Then ' Fornecedor Inativo
            '
            If MessageBox.Show("Você deseja realmente ATIVAR a Filial:" & vbNewLine &
            txtApelidoFilial.Text.ToUpper, "Ativar Filial", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                filial.BeginEdit()
                filial.Ativo = True
                AtivoButtonImage()
            End If
            '
        End If
        '
    End Sub
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        Dim filial As clFilial = BindFil.Current
        '
        If filial.Ativo = True Then ' Nesse caso é Fornecedor Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Ativo"
        ElseIf filial.Ativo = False Then ' Nesse caso é Fornecedor Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Inativo"
        End If
        '
    End Sub
    '
    '--- BTN FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        AutoValidate = AutoValidate.Disable
        Me.Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
#End Region
    '
    '
#Region "SALVAR REGISTRO"

    ' SALVAR O REGISTRO
    '-----------------------------------------------------------------------------------------------
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs)

    End Sub
    '
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
