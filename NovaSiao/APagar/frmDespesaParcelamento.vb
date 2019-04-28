Imports CamadaBLL

Public Class frmDespesaParcelamento
    Property propIDCobrancaForma As Integer
    Property propCobrancaFormaTexto As String
    Property propRGBanco As Int16?
    Property propParcelas As Integer
    Property propComEntrada As Boolean
    Private _formOrigem As Form = Nothing
    '
#Region "LOAD/OPEN"
    Sub New(formOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        _formOrigem = formOrigem
        '
        CarregaCmbCobrancaForma()
        CarregaCmbBancos()
        '
    End Sub
#End Region
    '
#Region "PREENCHE COMBOS"
    '-------------------------------------------------------------------------------------------------
    ' PREENCHE COMBOS
    '-------------------------------------------------------------------------------------------------
    Private Sub CarregaCmbCobrancaForma()
        Dim pg As New APagarBLL
        '
        Try
            Dim dtForma As DataTable = pg.CobrancaFormas_APagar_GET
            '
            With cmbCobrancaForma
                .DataSource = dtForma
                .ValueMember = "IDCobrancaForma"
                .DisplayMember = "CobrancaForma"
                .SelectedIndex = -1
            End With
            '
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção inesperada ao obter a lista de Formas Pagamento:" & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub CarregaCmbBancos()
        Dim db As New BancosBLL
        '
        Try
            Dim dt As DataTable = db.GetBancosDt(True)
            '
            With cmbIDBanco
                .DataSource = dt
                .ValueMember = "RGBanco"
                .DisplayMember = "BancoNome"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            MessageBox.Show("Um erro aconteceu obter lista de Bancos" & vbNewLine &
            ex.Message, "Exceção Inesperada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
#End Region
    '
#Region "BUTTONS"
    '
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '--- Verifica os dados
        If txtParcelas.Text.Trim.Length = 0 Then
            MessageBox.Show("O número de parcelas não pode ficar vazio e não pode ser menor ou igual a zero.",
                            "Número de Parcelas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtParcelas.Focus()
            Exit Sub
        End If
        '
        If cmbCobrancaForma.SelectedIndex = -1 OrElse cmbCobrancaForma.Text.Length = 0 Then
            MessageBox.Show("Favor informar a forma de Cobrança da Parcela.",
                            "Forma de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbCobrancaForma.Focus()
            Exit Sub
        End If
        '
        propIDCobrancaForma = cmbCobrancaForma.SelectedValue
        propCobrancaFormaTexto = cmbCobrancaForma.Text
        propRGBanco = cmbIDBanco.SelectedValue
        propParcelas = txtParcelas.Text
        propComEntrada = chkEntrada.Checked
        '
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub
    '
#End Region
    '
#Region "CONTROLE"
    '
    '--- CONTROLA PRESS A TECLA (ENTER) NO CONTROLE
    '-----------------------------------------------------------------------------------------------------
    Private Sub Control_KeyDown_Enter(sender As Object, e As KeyEventArgs) Handles txtParcelas.KeyDown, chkEntrada.KeyDown
        '
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
    '--- CRIA UM ATALHO PARA OS COMBO BOX
    Private Sub cmbCobrancaForma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCobrancaForma.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
            '
            Dim dt As DataTable = cmbCobrancaForma.DataSource
            Dim rCount As Integer = dt.Rows.Count
            Dim item As Integer = e.KeyChar.ToString
            '
            If item <= rCount And item > 0 Then
                Dim Valor As Integer = dt.Rows(e.KeyChar.ToString - 1)("IDCobrancaForma")
                '
                cmbCobrancaForma.SelectedValue = Valor
                '
            End If
        End If
    End Sub
    '
#End Region
    '
#Region "FORM SEM BORDA / EFEITO"
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub frmAPagarItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.Silver
    End Sub
    '
    Private Sub frmAPagarItem_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Dim pnl As Panel = _formOrigem.Controls("Panel1")
        pnl.BackColor = Color.SlateGray
    End Sub
    '
#End Region
    '
End Class
