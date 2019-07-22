Imports System.Net.Mail
Imports System.Xml
Imports CamadaBLL

Public Class frmEmail
    '
    Private SourceXMLFile As String = ""
    Private logoLocalPath As String
    Private logoRemotaURL As String
    Private siteURL As String
    Private mail As New MailMessage()
    Private EmpresaNome As String
    '
    Private _mailTo As String
    Private _title As String
    Private _bodyTitle As String
    Private _bodyText As String
    '
    Private _userName As String
    Private _password As String
    Private _SMTPPort As Integer
    Private _txtSMTPHost As String
    Private _enableSSL As Boolean
    '
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        ObterArquivo()
        LoadXMLSettings()
        selecionaLogo()
        '
    End Sub
    '
    Sub New(mailTo As String,
            title As String,
            bodyText As String,
            bodyTitle As String,
            Optional anexo As String = "")
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        _mailTo = mailTo
        _title = title
        _bodyText = bodyText
        _bodyTitle = bodyTitle
        '
        If Trim(anexo) <> "" Then
            lstAttachments.Items.Add(anexo)
        End If
        '
        txtMailTo.Text = mailTo
        txtSubject.Text = title
        txtBodyMesssage.Text = bodyText
        '
        ObterArquivo()
        LoadXMLSettings()
        selecionaLogo()
        '
    End Sub
    '
    Private Sub selecionaLogo()
        '
        If String.IsNullOrEmpty(logoRemotaURL) Then
            logoLocalPath = ObterDadosEmpresa.ArquivoLogoMono ' LOGO LOCAL
            txtLogoPath.Text = logoLocalPath
        Else
            txtLogoPath.Text = logoRemotaURL
        End If
        '
        EmpresaNome = ObterDadosEmpresa.RazaoSocial
        '
    End Sub
    '
    Private Function getSMTPServer() As SmtpClient
        '
        Dim SmtpServer As New SmtpClient()
        '
        '--- CREDENTIALS
        Dim credentials As New Net.NetworkCredential()
        credentials.UserName = _userName
        credentials.Password = _password
        '
        '--- SMTP SERVER
        SmtpServer.UseDefaultCredentials = True
        SmtpServer.Credentials = credentials
        SmtpServer.Port = _SMTPPort
        SmtpServer.Host = _txtSMTPHost
        SmtpServer.EnableSsl = _enableSSL
        '
        Return SmtpServer
        '
    End Function
    '
    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- MAIL
            Using mail As MailMessage = New MailMessage()
                '
                '--- MAIL FROM
                mail.From = New MailAddress(_userName)
                '
                '--- MAIL TO
                Dim addr() As String = txtMailTo.Text.Split(",")
                Dim i As Byte
                For i = 0 To addr.Length - 1
                    mail.To.Add(addr(i))
                Next
                '
                '--- SUBJECT
                mail.Subject = txtSubject.Text
                '
                '--- ATTACHMENTS
                If lstAttachments.Items.Count <> 0 Then
                    For i = 0 To lstAttachments.Items.Count - 1
                        mail.Attachments.Add(New Attachment(lstAttachments.Items.Item(i)))
                    Next
                End If
                '
                mail.AlternateViews.Add(CreateHTMLBody)
                mail.IsBodyHtml = True
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                '
                '--- SEND EMAIL
                '-------------------------------------------------------------------
                getSMTPServer.Send(mail)
                '
            End Using
            '
            AbrirDialog("Mensagem enviada com sucesso!",
                        "Mensagem Enviada",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            '
            Close()
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Enviar e-mail..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Sub
    '
    Private Function CreateHTMLBody() As AlternateView
        '
        '--- check if exists LOGO
        Dim logoRemota As Boolean = Not String.IsNullOrEmpty(logoRemotaURL)
        '
        '--- BODY CONSTRUCTION
        Dim altView As AlternateView = Nothing
        Dim htmlview As String = "<html>"
        htmlview = htmlview + "<body>"
        '
        If logoRemota Then
            '
            '--- check include SITE
            If Not String.IsNullOrEmpty(siteURL) Then
                htmlview = htmlview + "<a href='www.novasiao.com.br'>"
                htmlview = htmlview + "<img src='" + logoRemotaURL + "' alt=companyname />"
                htmlview = htmlview + "</a>"
            Else
                htmlview = htmlview + "<img src='" + logoRemotaURL + "' alt=companyname />"
            End If
            '
        ElseIf Trim(logoLocalPath) <> "" Then
            '
            '--- DEFINE LOGO
            Dim logo As New LinkedResource(logoLocalPath)
            logo.ContentId = "Logo"
            altView.LinkedResources.Add(logo)
            '
            '--- check include SITE
            If Not String.IsNullOrEmpty(siteURL) Then
                htmlview = htmlview + "<a href='www.novasiao.com.br'>"
                htmlview = htmlview + "<img src=cid:Logo alt=companyname />"
                htmlview = htmlview + "</a>"
            Else
                htmlview = htmlview + "<img src=cid:Logo alt=companyname />"
            End If
            '
        End If
        '
        '--- check include EMPRESA NAME
        If Not String.IsNullOrEmpty(EmpresaNome) Then
            htmlview = htmlview + "<h1>" + EmpresaNome + "</h1>"
        End If
        '
        '--- check include BODY TITLE
        If Trim(_bodyTitle) <> "" Then htmlview = htmlview + "<h2>" + _bodyTitle + "</h2>"
        '
        '--- INCLUDE BODY MESSAGE
        htmlview = htmlview + "<hr style='border: 1px solid black' />"
        '
        If Trim(txtBodyMesssage.Text) <> "" Then
            '
            Dim lines As New List(Of String)
            Dim mensagens As String() = txtBodyMesssage.Text.Split(vbCrLf)
            lines = mensagens.ToList
            '
            For Each m In lines
                htmlview = htmlview + "<h4>" + m + "</h4>"
            Next
            '
        End If
        '
        htmlview = htmlview + "</body>"
        htmlview = htmlview + "</html>"
        '
        '--- ALTERNATIVE VIEW
        Dim mediaType As String = Net.Mime.MediaTypeNames.Text.Html
        altView = AlternateView.CreateAlternateViewFromString(htmlview, System.Text.Encoding.UTF8, mediaType)
        '
        Return altView
        '
    End Function
    '
    Private Sub btnAnexoIncluir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnexoIncluir.Click
        '
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            lstAttachments.Items.Add(OpenFileDialog1.FileName)
        End If
        '
    End Sub
    '
    Private Sub ObterArquivo()
        '
        Dim aBLL As New AcessoControlBLL
        '
        Try
            SourceXMLFile = aBLL.GetConfigXMLPath
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Obter acessar o arquivo do configuração XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Function LoadXMLSettings() As Boolean
        '
        Dim doc As New XmlDocument()
        '
        '--- Try open XML document
        Try
            doc.Load(SourceXMLFile)
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Ler o arquivo XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            '
        End Try
        '
        If Not VerificaArquivoXML(doc) Then Return False
        '
        '--- FILL ITEMS / TEXTBOX
        Try
            Dim setting As XmlNode = doc.GetElementsByTagName("emailServerSettings")(0)
            '
            _userName = setting.SelectSingleNode("emailUserName").InnerText
            txtMailFrom.Text = _userName
            _password = setting.SelectSingleNode("emailPassword").InnerText
            _SMTPPort = setting.SelectSingleNode("smtpPort").InnerText
            _txtSMTPHost = setting.SelectSingleNode("smtpHost").InnerText
            _enableSSL = setting.SelectSingleNode("smtpEnableSSL").InnerText = "True"
            logoRemotaURL = setting.SelectSingleNode("logoRemotaURL").InnerText
            siteURL = setting.SelectSingleNode("sitePadraoURL").InnerText
            '
            '--- RETURN
            Return True
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Ler o arquivo XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            '
        End Try
        '
    End Function
    '
    Private Function VerificaArquivoXML(doc As XmlDocument) As Boolean
        '
        '--- CHECK XML FILE
        Dim check1 As Boolean = doc.GetElementsByTagName("emailServerSettings").Count = 0
        '
        If check1 Then
            MessageBox.Show("A configuração do Email Padrão não foi realizada ainda...", "Configuração",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        '
        Return True
        '
    End Function
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAnexoExcluir_Click(sender As Object, e As EventArgs) Handles btnAnexoExcluir.Click
        'Remove os anexos
        If lstAttachments.SelectedIndex > -1 Then
            lstAttachments.Items.RemoveAt(lstAttachments.SelectedIndex)
        End If
    End Sub
    '
End Class