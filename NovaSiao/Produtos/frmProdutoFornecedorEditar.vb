Imports CamadaDTO
'
Public Class frmProdutoFornecedorEditar
    '
    Private _prodForn As clProdutoFornecedor
    Private bindProd As New BindingSource
    Private _Sit As EnumFlagEstado
    Private _formOrigem As Form = Nothing
    '
#Region "SUB NEW"
    '
    Sub New(prodForn As clProdutoFornecedor, formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        _prodForn = prodForn
        bindProd.DataSource = _prodForn
        PreencheDataBindings()
        '
        If IsNothing(_prodForn.IDFornecedor) Then '--> NEW | INSERT
            Sit = EnumFlagEstado.NovoRegistro
        Else '--> SAVED | UPDATE
            Sit = EnumFlagEstado.RegistroSalvo
        End If
        '

        '
    End Sub
    '
    'PROPERTY SIT
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnCancelar.Enabled = False
                btnFornecedor.Enabled = True
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
                btnFornecedor.Enabled = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                btnSalvar.Enabled = True
                btnFornecedor.Enabled = True
                btnCancelar.Enabled = True
            End If
        End Set
    End Property




    '



#End Region '/ SUB NEW
    '
#Region "BINDINGS"
    '
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA

        lblIDTransacao.DataBindings.Add("Text", bindProd, "IDTransacao")
        lblApelidoFilial.DataBindings.Add("Text", bindProd, "ApelidoFilial")
        dtpUltimaEntrada.DataBindings.Add("Value", bindProd, "UltimaEntrada", True, DataSourceUpdateMode.OnPropertyChanged)

        lblRGProduto.DataBindings.Add("Text", bindProd, "RGProduto")
        lblProduto.DataBindings.Add("Text", bindProd, "Produto")
        lblFornecedor.DataBindings.Add("Text", bindProd, "Cadastro")

        txtPCompra.DataBindings.Add("Text", bindProd, "PCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescontoCompra.DataBindings.Add("Text", bindProd, "DescontoCompra", True, DataSourceUpdateMode.OnPropertyChanged)
        lblPrecoFinal.DataBindings.Add("Text", bindProd, "SubTotal")
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtPCompra.DataBindings("Text").Format, AddressOf FormatCUR
        AddHandler txtDescontoCompra.DataBindings("text").Format, AddressOf FormatPercent
        AddHandler lblRGProduto.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblIDTransacao.DataBindings("Text").Format, AddressOf idFormatRG
        AddHandler lblPrecoFinal.DataBindings("Text").Format, AddressOf FormatCUR
        '
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    '
    Private Sub FormatCUR(sender As Object, e As ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    '
    Private Sub FormatPercent(sender As Object, e As ConvertEventArgs)
        e.Value = Format(e.Value / 100, "0.00%")
    End Sub
    '
#End Region '/ BINDINGS
    '
#Region "BUTTONS FUNCTION"
    '
    '--- CLOSE FORM
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        DialogResult = DialogResult.Cancel
    End Sub
    '
    '--- BTN ESCOLHER FORNECEDOR
    Private Sub btnFornecedor_Click(sender As Object, e As EventArgs) Handles btnFornecedor.Click
        '
        Dim frmF As frmFornecedorProcurar
        Dim oldID As Integer?
        '
        oldID = _prodForn.IDFornecedor
        frmF = New frmFornecedorProcurar(True, Me)
        '
        ' revela o formulario dependendo do controle acionado
        frmF.ShowDialog()
        '
        ' ao fechar dialog verifica o resultado
        If frmF.DialogResult <> DialogResult.OK Then Exit Sub
        '
        lblFornecedor.Text = frmF.propFornecedor_Escolha.Cadastro
        _prodForn.Cadastro = frmF.propFornecedor_Escolha.Cadastro
        _prodForn.IDFornecedor = frmF.propFornecedor_Escolha.IDPessoa
        '
        ' altera o EnumFlagEstado para ALTERADO
        If IIf(IsNothing(oldID), 0, oldID) <> IIf(IsNothing(_prodForn.IDFornecedor), 0, _prodForn.IDFornecedor) Then
            '
            ' altera o EnumFlagEstado
            If Sit = EnumFlagEstado.RegistroSalvo Then Sit = EnumFlagEstado.Alterado
            '
        End If
        '
    End Sub



#End Region '/ BUTTONS FUNCTION
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        DialogResult = DialogResult.OK
    End Sub
    '
#End Region
    '
End Class
