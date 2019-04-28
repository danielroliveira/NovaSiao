Public Class dlgAPagarQuitarAlteraValor
    '
    Private _resposta As Byte '--- 1:INSERIR | 2:AUMENTAR | 3:DESCARTAR
    '
    Public Property Resposta() As Byte
        Get
            Return _resposta
        End Get
        Set(ByVal value As Byte)
            _resposta = value
            DialogResult = DialogResult.OK
            Me.Close()
        End Set
    End Property
    '
    Sub New(vlmax As Double, btlAlteraAtivo As Boolean)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        lblTextoPrincipal.Text = "O valor da Saída/Pagamento não pode ser maior que R$ " &
                                 Format(vlmax, "#,##0.00") & vbNewLine & vbNewLine &
                                 "O que você deseja fazer com a diferença do valor?"
        '
    End Sub
    '
    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Resposta = 1
    End Sub
    '
    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        Resposta = 2
    End Sub
    '
    Private Sub btnDescartar_Click(sender As Object, e As EventArgs) Handles btnDescartar.Click
        Resposta = 3
    End Sub
    '
End Class
