Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports CamadaBLL
'
Public Class frmLogin
    Private tentativa As Byte
    Private Logado As Boolean
    Private SQL As New SQLControl
    Private Fantasia As String = ""
    '
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' ler o arquivo de imagem da LOGO e captar o nome fantasia
        If File.Exists(Application.StartupPath & "\ConfigFiles\Config.xml") Then
            Dim myXML As New XmlDocument
            Dim myLogoArq As String

            Try
                '
                myXML.Load(Application.StartupPath & "\ConfigFiles\Config.xml")
                ' nome fantasia
                Fantasia = myXML.SelectSingleNode("Configuracao").SelectSingleNode("DadosEmpresa").ChildNodes(0).InnerText
                ' arquivo de imagem
                myLogoArq = myXML.SelectSingleNode("Configuracao").SelectSingleNode("ArquivoLogo").ChildNodes(1).InnerText
                picLogo.ImageLocation = myLogoArq
                '
            Catch ex As Exception

            End Try
        End If
        '
        ' Definir variáveis
        tentativa = 0
        Logado = False
        txtApelido.Focus()
        '
    End Sub
    '
    ' BOTÃO CONFIRMAR | OK
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        If VerificaCampos() = False Then Exit Sub
        '
        Try
            Me.Cursor = Cursors.WaitCursor
            SQL.AddParam("@UsuarioApelido", txtApelido.Text)
            SQL.AddParam("@UsuarioSenha", txtSenha.Text)
            SQL.ExecQuery("SELECT TOP 1 * " &
                          "FROM tblUsuario " &
                          "WHERE UsuarioApelido = @UsuarioApelido;")
            '
            If SQL.HasException Then
                Cursor = Cursors.Arrow
                MessageBox.Show("Não é possível conectar ao Banco de Dados SQL..." & vbNewLine &
                                "Verique a conexão com o servidor e tente novamente..." & vbNewLine &
                                SQL.Exception,
                                "Erro na Conexão", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Logado = False
                Me.Close()
                Exit Sub
            End If
            '
        Catch ex As Exception
            Throw ex
        Finally
            Cursor = Cursors.Arrow
        End Try
        '
        Try
            If SQL.RecordCount > 0 Then ' encotrou o registro do usuário
                '
                Dim r As DataRow = SQL.DBDT.Rows(0)
                '
                If txtSenha.Text = r("UsuarioSenha") Then ' compara a senha do usuário
                    '
                    UsuarioAtual = New CamadaDTO.clUsuario With {
                        .IdUser = r("IdUser"),
                        .UsuarioAcesso = r("UsuarioAcesso"),
                        .UsuarioApelido = r("UsuarioApelido")
                        }
                    Logado = True
                    '
                    ' Bem-vindo
                    MessageBox.Show("Seja Bem-Vindo: " & txtApelido.Text.ToUpper & vbNewLine & vbNewLine &
                                    "Acesso: " & CType(r("UsuarioAcesso"), CamadaDTO.EnumAcessoTipo).ToString.ToUpper,
                                    Fantasia, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.Yes
                    Me.Close()
                    SQL = Nothing
                    Exit Sub
                    '
                End If
                '
            End If
            '
            tentativa += 1
            '
            Select Case tentativa
                Case = 1
                    MessageBox.Show("Usuário ou Senha estão incorretas!" & vbCrLf &
                                    "Tente novamente..." & vbCrLf &
                                    "PRIMEIRA TENTATIVA de 3", "Senha e/ou Usuário Incorreto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtApelido.Focus()
                Case = 2
                    MessageBox.Show("Usuário ou Senha estão incorretas!" & vbCrLf &
                                    "Tente novamente..." & vbCrLf &
                                    "SEGUNDA TENTATIVA de 3", "Senha e/ou Usuário Incorreto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtApelido.Focus()
                Case = 3
                    MessageBox.Show("Usuário ou Senha estão incorretas!" & vbCrLf &
                                    "TERCEIRA TENTATIVA a aplicação será encerrada...", "Erro de Senha e Usuário",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Logado = False
                    Me.Close()
                    Exit Sub
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub
    '
    ' BOTÃO FECHAR
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Logado = False
        Me.Close()
    End Sub
    '
    Private Sub txtApelido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApelido.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            txtSenha.Focus()
        End If
    End Sub
    '
    Private Sub txtSenha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSenha.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            btnOK.Focus()
        End If
    End Sub
    '
    Private Function VerificaCampos() As Boolean
        'Verifica se o campo Apelido tem algum valor
        If Len(txtApelido.Text.Trim) = 0 Then
            MsgBox("Por Favor, preencha o campo Nome do Usuário...", vbInformation, "Nome do Usuário Vazio")
            txtApelido.Focus()
            Return False
            Exit Function
        End If
        'Verifica se o campo senha tem algum valor
        If Len(txtSenha.Text.Trim) < 8 Then
            MsgBox("Por Favor, preencha o campo da SENHA..." & vbCrLf &
                   "Sua SENHA precisa ter pelo menos 8 caracteres", vbInformation, "Senha Incompleta")
            txtSenha.Focus()
            Return False
            Exit Function
        End If
        Return True
    End Function
    '
    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            btnOK_Click(New Object, New System.EventArgs)
        ElseIf e.KeyCode = Keys.Escape Then
            btnCancel_Click(New Object, New System.EventArgs)
        End If
    End Sub
    '
    Private Sub frmLogin_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Logado = True Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.No
        End If
    End Sub
    '
    ' SELECIONAR TODO O TEXTO QUANDO RECEBE O FOCO NO CONTROLE
    Private Sub txtApelido_GotFocus(sender As Object, e As EventArgs) Handles txtApelido.GotFocus
        txtApelido.SelectAll()
    End Sub
    '
    Private Sub txtSenha_GotFocus(sender As Object, e As EventArgs) Handles txtSenha.GotFocus
        txtSenha.SelectAll()
    End Sub
End Class