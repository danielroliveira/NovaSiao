Imports System.Xml
Imports CamadaBLL

Public Class frmEmailServer
    '
    Private SourceXMLFile As String = ""
    Private _ArquivoAlterado As Boolean = False
    '
#Region "NEW | OPEN | SHOW"
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ObterArquivo()
        '
    End Sub
    '
    Private Sub frmEmailServer_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        '
        If Not String.IsNullOrEmpty(SourceXMLFile) Then
            LoadXMLSettings()
            '--- add Handler Change
            HandlerChangedControles()
        Else
            '
            MessageBox.Show("Uma exceção ocorreu ao acessar o arquivo de configuração..." & vbNewLine &
                            "Arquivo XML não foi encontrado", "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End If
        '
    End Sub
    '
    Public Property ArquivoAlterado() As Boolean
        '
        Get
            Return _ArquivoAlterado
        End Get
        '
        Set(ByVal value As Boolean)
            '
            If value Then
                btnSalvar.Enabled = True
                btnCancelar.Text = "&Cancelar"
            Else
                btnSalvar.Enabled = False
                btnCancelar.Text = "&Fechar"
            End If
            '
            _ArquivoAlterado = value
            '
        End Set
        '
    End Property
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
#End Region '/ NEW | OPEN | SHOW
    '
#Region "BUTTONS"
    '
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If ArquivoAlterado Then
            LoadXMLSettings()
            ArquivoAlterado = False
        Else
            Close()
        End If
        '
    End Sub
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    '
#End Region '/ BUTTONS
    '
#Region "CONTROLES"
    '
    Private Sub txtSMTPPort_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSMTPPort.KeyPress
        '
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
        '
    End Sub
    '
    ' EVENTO CHANGE DOS CONTROLES
    Private Sub HandlerChangedControles()
        '--- para cada Controle no form
        For Each c In Controls.OfType(Of TextBox)
            '--- se o controle for textbox então
            AddHandler c.TextChanged, AddressOf Controles_TextChanged
            AddHandler c.KeyDown, AddressOf txtControl_KeyDown
        Next
        '
        AddHandler chkEnableSSL.CheckedChanged, AddressOf Controles_TextChanged
        AddHandler chkEnableSSL.KeyDown, AddressOf txtControl_KeyDown
        '
    End Sub
    '
    Private Sub Controles_TextChanged(sender As Object, e As EventArgs)
        '
        If Not ArquivoAlterado Then
            ArquivoAlterado = True
        End If
        '
    End Sub
    '
    '---------------------------------------------------------------------------------------
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    '---------------------------------------------------------------------------------------
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs)
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region '/ CONTROLES
    '
#Region "XML CONTROL"
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
        Try
            '
            '--- FILL ITEMS / TEXTBOX
            Dim setting As XmlNode = doc.GetElementsByTagName("emailServerSettings")(0)
            '
            txtUser.Text = setting.SelectSingleNode("emailUserName").InnerText
            txtPassword.Text = setting.SelectSingleNode("emailPassword").InnerText
            txtSMTPPort.Text = setting.SelectSingleNode("smtpPort").InnerText
            txtSMTPHost.Text = setting.SelectSingleNode("smtpHost").InnerText
            '
            If setting.SelectSingleNode("smtpEnableSSL").InnerText = "True" Then
                chkEnableSSL.Checked = True
            Else
                chkEnableSSL.Checked = False
            End If
            '
            txtLogoRemota.Text = setting.SelectSingleNode("logoRemotaURL").InnerText
            txtSite.Text = setting.SelectSingleNode("sitePadraoURL").InnerText
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
        Dim check1 As Boolean = doc.GetElementsByTagName("userSettings").Count = 1
        Dim check2 As Boolean = doc.GetElementsByTagName("MySettings").Count = 1
        Dim check3 As Boolean = doc.GetElementsByTagName("setting").Count > 0
        '
        If Not (check1 And check2 And check3) Then
            MessageBox.Show("Arquivo XML Inválido", "XML Inválido",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            SourceXMLFile = ""
            lblCaminho.Text = SourceXMLFile
            Return False
        End If
        '
        Dim root As XmlNode = doc.DocumentElement
        '
        If doc.GetElementsByTagName("emailServerSettings").Count = 0 Then
            '
            Dim elem As XmlElement = doc.CreateNode(XmlNodeType.Element, "emailServerSettings", "")
            Dim setting As XmlNode = root.AppendChild(elem)
            '
            EmailAppendChild(doc, setting, "emailUserName")
            EmailAppendChild(doc, setting, "emailPassword")
            EmailAppendChild(doc, setting, "smtpPort")
            EmailAppendChild(doc, setting, "smtpHost")
            EmailAppendChild(doc, setting, "smtpEnableSSL")
            EmailAppendChild(doc, setting, "logoRemotaURL")
            EmailAppendChild(doc, setting, "sitePadraoURL")
            '
        End If
        '
        doc.Save(SourceXMLFile)
        '
        Return True
        '
    End Function
    '
    Private Sub EmailAppendChild(doc As XmlDocument, setting As XmlNode, nodeName As String)
        Dim elem As XmlElement = doc.CreateNode(XmlNodeType.Element, nodeName, "")
        setting.AppendChild(elem)
    End Sub
    '
#End Region '/ XML CONTROL
    '
#Region "SAVE"
    '
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If Not VerificaDados() Then Exit Sub
        '        '
        Dim doc As New XmlDocument()
        '
        '--- Try open XML document
        Try
            doc.Load(SourceXMLFile)
            '
            Dim setting As XmlNode = doc.SelectSingleNode("configuration/emailServerSettings")
            '
            '--- remove all childs
            setting.RemoveAll()
            '
            '--- add all necessary childs
            EmailAppendChild(doc, setting, "emailUserName")
            EmailAppendChild(doc, setting, "emailPassword")
            EmailAppendChild(doc, setting, "smtpPort")
            EmailAppendChild(doc, setting, "smtpHost")
            EmailAppendChild(doc, setting, "smtpEnableSSL")
            EmailAppendChild(doc, setting, "logoRemotaURL")
            EmailAppendChild(doc, setting, "sitePadraoURL")
            '
            '--- save the values InnerText
            setting.SelectSingleNode("emailUserName").InnerText = txtUser.Text
            setting.SelectSingleNode("emailPassword").InnerText = txtPassword.Text
            setting.SelectSingleNode("smtpPort").InnerText = txtSMTPPort.Text
            setting.SelectSingleNode("smtpHost").InnerText = txtSMTPHost.Text
            '
            If chkEnableSSL.Checked Then
                setting.SelectSingleNode("smtpEnableSSL").InnerText = "True"
            Else
                setting.SelectSingleNode("smtpEnableSSL").InnerText = "False"
            End If
            '
            setting.SelectSingleNode("logoRemotaURL").InnerText = txtLogoRemota.Text
            setting.SelectSingleNode("sitePadraoURL").InnerText = txtSite.Text
            '
            doc.Save(SourceXMLFile)
            ArquivoAlterado = False
            '
            AbrirDialog("Configuração de Email salva com sucessso!",
                        "Salvo",
                        frmDialog.DialogType.OK,
                        frmDialog.DialogIcon.Information)
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar Arquivo de Configuração..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        End Try
        '
    End Sub
    '
    Private Function VerificaDados() As Boolean
        '
        '--- para cada Controle no form
        For Each c In Controls.OfType(Of TextBox)
            '
            '--- se for LogoRemota ou Site nao verifica
            If Not (c.Name = "txtLogoRemota" Or c.Name = "txtSite") Then
                '
                '--- verifica texto
                If c.Text.Trim.Length = 0 Then
                    AbrirDialog("Todos os campos precisam ser preenchidos",
                            "Campos Vazios", frmDialog.DialogType.OK,
                            frmDialog.DialogIcon.Exclamation)
                    c.Focus()
                    Return False
                End If
                '
            End If
            '
        Next
        '
        Return True
        '
    End Function
    '
#End Region '/ SAVE
    '
End Class
