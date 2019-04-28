Imports CamadaDTO

Public Class frmAReceberItem
    Private _clParc As clAReceberParcela
    Private _acao As EnumFlagAcao
    Private _dtMinima As Date
    Private _formOrigem As Form
    Private _vlMaximo As Double
    Private BindRec As New BindingSource
    '
#Region "SUB NEW | PROPERTS"
    '
    '-------------------------------------------------------------------------------------------------
    ' SUB NEW
    '-------------------------------------------------------------------------------------------------
    Sub New(fOrigem As Form, VlMax As Double, dataMinima As Date,
            AReceber As clAReceberParcela, Acao As EnumFlagAcao,
            Optional Posicao As Point = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        ' 
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = fOrigem '--- DEFINE O FORMULARIO DE ORIGEM PARA RETORNAR
        _vlMaximo = VlMax
        _dtMinima = dataMinima
        propAReceber = AReceber '--- DEFINE E PREECHE A CLASSE
        propAcao = Acao
        '
        If Not IsNothing(Posicao) Then
            StartPosition = FormStartPosition.Manual
            Location = New Point(Posicao.X - Me.Width, Posicao.Y)
        End If
        '
    End Sub
    '
    '--- PROPRIEDADE PROPACAO
    '-------------------------------------------------------------------------------------------------
    Public Property propAcao() As EnumFlagAcao
        '
        Get
            Return _acao
        End Get
        '
        Set(ByVal value As EnumFlagAcao)
            _acao = value
            '
            If _acao = EnumFlagAcao.INSERIR Then
                btnOK.Text = "&Inserir"
                lblToolStripInfo.Text = "Inserindo Nova Parcela"
                lblTitulo.Text = "Inserir Parcela"
            ElseIf _acao = EnumFlagAcao.EDITAR Then
                btnOK.Text = "&Alterar"
                lblToolStripInfo.Text = "Editando Parcela"
                lblTitulo.Text = "Editar Parcela"
            End If
            '
        End Set
        '
    End Property
    '
    '--- PROPRIEDADE PROPITEM
    '-------------------------------------------------------------------------------------------------
    Public Property propAReceber() As clAReceberParcela
        Get
            Return _clParc
        End Get
        Set(ByVal value As clAReceberParcela)
            _clParc = value
            '
            If IsNothing(BindRec.DataSource) Then
                BindRec.DataSource = _clParc
                PreencheDataBindings()
            Else
                BindRec.Clear()
                BindRec.DataSource = _clParc
                BindRec.ResetBindings(True)
            End If
        End Set
    End Property
    '
#End Region '/ SUB NEW | PROPERTS
    '
#Region "BINDINGS"
    '
    '-------------------------------------------------------------------------------------------------
    ' BINDINGS DOS CAMPOS
    '-------------------------------------------------------------------------------------------------
    Private Sub PreencheDataBindings()
        '
        '--- PREENCHE OS DATABINDGS DOS CONTROLES
        '
        txtVencimento.DataBindings.Add("Text", BindRec, "Vencimento", True, DataSourceUpdateMode.OnPropertyChanged)
        txtParcelaValor.DataBindings.Add("Text", BindRec, "ParcelaValor", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPermanencia.DataBindings.Add("Text", BindRec, "PermanenciaTaxa", True, DataSourceUpdateMode.OnPropertyChanged)
        lblReg.DataBindings.Add("Text", BindRec, "CodRegistro")
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler txtParcelaValor.DataBindings("text").Format, AddressOf FormatCUR
        AddHandler txtPermanencia.DataBindings("text").Format, AddressOf FormatPerc
        AddHandler txtVencimento.DataBindings("text").Format, AddressOf FormatDate
        '
    End Sub
    '
    ' FORMATA OS BINDINGS
    Private Sub FormatCUR(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatCurrency(e.Value, 2)
    End Sub
    Private Sub FormatPerc(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0.00")
    End Sub
    Private Sub FormatDate(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = FormatDateTime(e.Value, DateFormat.ShortDate)
    End Sub
    '
#End Region '/ BINDINGS
    '
#Region "BUTTONS FUNCTION"
    '
    '-------------------------------------------------------------------------------------------------
    ' BTN INSERIR / FECHAR
    '-------------------------------------------------------------------------------------------------
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '-------------------------------------------------------------------
        ' VERIFICACOES
        '-------------------------------------------------------------------
        '--- Verifica VENCIMENTO é futuro ou atual da trasancao
        If IsNothing(_clParc.Vencimento) OrElse _clParc.Vencimento < _dtMinima Then
            MessageBox.Show("A data do VENCIMENTO não pode ser anterior à: " & vbNewLine &
                            _dtMinima.ToShortDateString, "Vencimento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtVencimento.Focus()
            txtVencimento.SelectAll()
            Exit Sub
        End If
        '
        '--- Verifica VALOR
        If IsNothing(_clParc.ParcelaValor) OrElse _clParc.ParcelaValor <= 0 Then
            MessageBox.Show("O Valor da Parcela não pode ser menor ou igual a Zero...",
                "Valor da Parcela", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtParcelaValor.Focus()
            txtParcelaValor.SelectAll()
        End If
        '
        '--- Verifica VALOR nao é maior que o vlmaximo
        If _clParc.ParcelaValor > _vlMaximo Then
            MessageBox.Show("O Valor da Parcela não pode ser maior que R$ " & Format(_vlMaximo, "#,##0.00"),
                            "Valor da Parcela", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtParcelaValor.Focus()
            txtParcelaValor.SelectAll()
            Exit Sub
        End If
        '
        '--- Verifica PERMANENCIA
        If IsNothing(_clParc.PermanenciaTaxa) OrElse _clParc.PermanenciaTaxa < 0 Then
            _clParc.PermanenciaTaxa = 0
        End If
        '
        '-------------------------------------------------------------------
        ' FECHA O DIALOG
        '-------------------------------------------------------------------
        BindRec.EndEdit()
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        BindRec.CancelEdit()
        DialogResult = DialogResult.Cancel
        '
    End Sub
    '
#End Region '/ BUTTONS FUNCTION
    '
#Region "NAVEGACAO"
    '
    '-------------------------------------------------------------------------------------------------
    ' NAVEGACAO ENTRE OS CAMPOS
    '-------------------------------------------------------------------------------------------------
    Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPermanencia.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = ","c Then
            e.Handled = False
        ElseIf e.KeyChar = "."c Then
            DirectCast(sender, TextBox).SelectedText = ","
            e.Handled = True
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    '
    Private Sub Text_GotFocus(sender As Object, e As EventArgs) Handles txtParcelaValor.GotFocus, txtPermanencia.GotFocus
        If CType(sender, TextBox).Text.Length > 0 Then sender.SelectAll()
    End Sub
    '
    Private Sub txtRGProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParcelaValor.KeyDown, txtPermanencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '
#End Region '/ NAVEGACAO
    '
#Region "DESIGN VISUAL"
    '
    '-------------------------------------------------------------------------------------------------
    ' CONSTRUIR UMA BORDA NO FORMULÁRIO
    '-------------------------------------------------------------------------------------------------
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        Dim pen As New Pen(Color.SlateGray, 3)

        e.Graphics.DrawRectangle(pen, rect)
    End Sub
    '
    Private Sub frmTransacaoItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            '
            btnCancelar_Click(New Object, New EventArgs)
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAReceberItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmAReceberItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region '/ DESIGN VISUAL
    '
End Class
