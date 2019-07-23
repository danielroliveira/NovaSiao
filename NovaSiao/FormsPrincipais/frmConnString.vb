Imports System.Drawing.Drawing2D
Imports System.Xml
Imports ComponentOwl.BetterListView
Imports CamadaBLL

Public Class frmConnString
    '
    Private SourceXMLFile As String = ""
    Private ArquivoNovo As Boolean = False
    '
    Private _ArquivoAlterado As Boolean
    Private _SelectedString As String
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SelectedString = ""
        '
    End Sub
    '
    Private Property SelectedString() As String
        Get
            Return _SelectedString
        End Get
        Set(ByVal value As String)
            _SelectedString = value
            '
            If String.IsNullOrEmpty(value) Then
                btnAtualizar.Enabled = False
                btnRemoverString.Enabled = False
                btnUsar.Enabled = False
            Else
                btnAtualizar.Enabled = True
                btnRemoverString.Enabled = True
                '
                If ArquivoAlterado Or ArquivoNovo Then
                    btnUsar.Enabled = False
                Else
                    btnUsar.Enabled = True
                End If
                '
            End If
            '
        End Set
    End Property
    '
    Public Property ArquivoAlterado() As Boolean
        Get
            Return _ArquivoAlterado
        End Get
        Set(ByVal value As Boolean)
            _ArquivoAlterado = value
            '
            If value = True And lstConn.Items.Count > 0 Then
                btnSalvarArquivo.Enabled = True
                btnUsar.Enabled = False
            Else
                btnSalvarArquivo.Enabled = False
            End If
            '
        End Set
    End Property
    '
    Private Sub btnObterArquivo_Click(sender As Object, e As EventArgs) Handles btnObterArquivo.Click
        '
        Using OFD As New OpenFileDialog With {
            .Filter = "XML (*.xml)|*.xml",
            .InitialDirectory = Application.StartupPath
        }
            '
            If OFD.ShowDialog = DialogResult.OK Then
                SourceXMLFile = OFD.FileName
                lblCaminho.Text = SourceXMLFile
                ArquivoNovo = False
                ArquivoAlterado = False
                '
                LoadXMLConnection()
                '
            End If
            '
        End Using
        '
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    '
    Private Function LoadXMLConnection() As Boolean
        '
        Dim doc As New XmlDocument()
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            doc.Load(SourceXMLFile)
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
            '--- FILL LIST ITEMS
            lstConn.Items.Clear()
            Dim stringsConn As XmlNodeList = doc.GetElementsByTagName("setting")

            For Each conn As XmlNode In stringsConn
                lstConn.Items.Add(New String() {conn.Attributes("name").Value, conn.SelectSingleNode("value").InnerText})
            Next
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Ler arquivo XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        '--- RETURN
        Return True
        '
    End Function

    Private Sub lstConn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstConn.SelectedIndexChanged
        '
        If lstConn.SelectedItems.Count > 0 Then
            txtConnString.Text = lstConn.SelectedItems(0).SubItems(1).Text
            SelectedString = lstConn.SelectedItems(0).Text
        Else
            txtConnString.Text = ""
            SelectedString = ""
        End If
        '
    End Sub

    Private Sub btnNovaString_Click(sender As Object, e As EventArgs) Handles btnNovaString.Click
        '
        '--- check SourceXMLFile
        '----------------------------------------------------------------------------------
        If String.IsNullOrEmpty(SourceXMLFile) Then
            MessageBox.Show("Favor escolher antes um arquivo XML válido...",
                            "Arquivo XML Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '
        '--- check text on txtConnString
        '----------------------------------------------------------------------------------
        If txtConnString.Text.Trim.Length < 10 Then
            MessageBox.Show("String de Conexão inválida..." & vbNewLine &
                            "Favor entrar com uma nova String de Conexão válida",
                            "String Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtConnString.Focus()
            txtConnString.SelectAll()
            Exit Sub
        End If
        '
        Dim novaString = InputBox("Entre com o nome da Nova String...",
                                  "Nome da String", "")
        '
        If String.IsNullOrEmpty(novaString) Then
            Exit Sub
        End If
        '
        '--- check if duplicated string name
        '----------------------------------------------------------------------------------
        For Each item In lstConn.Items
            '
            If item.Text = novaString Then
                '
                MessageBox.Show("Já existe uma string de conexão com esse mesmo nome..." & vbNewLine &
                "Favor entrar com um nome diferente.",
                "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '
                Exit Sub
                '
            End If
            '
        Next
        '
        '--- execute
        '----------------------------------------------------------------------------------
        lstConn.Items.Add(New String() {novaString, txtConnString.Text.Trim})
        txtConnString.Clear()
        ArquivoAlterado = True
        '
    End Sub
    '
    Private Sub btnRemoverString_Click(sender As Object, e As EventArgs) Handles btnRemoverString.Click
        '
        If lstConn.Items.Count = 1 Then
            MessageBox.Show("Não é possível salvar arquivo de acesso do Servidor sem pelo menos uma String de Conexão",
                            "Somente uma String", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        If lstConn.SelectedItems.Count > 0 Then
            lstConn.Items.RemoveAt(lstConn.SelectedItems(0).Index)
            ArquivoAlterado = True
        End If
        '
    End Sub

    Private Sub btnAtualizar_Click(sender As Object, e As EventArgs) Handles btnAtualizar.Click
        '
        '--- check SourceXMLFile
        '----------------------------------------------------------------------------------
        If String.IsNullOrEmpty(SourceXMLFile) Then
            MessageBox.Show("Favor escolher antes um arquivo XML válido...",
                            "Arquivo XML Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '
        '--- check text on txtConnString
        '----------------------------------------------------------------------------------
        If txtConnString.Text.Trim.Length < 10 Then
            MessageBox.Show("String de Conexão inválida..." & vbNewLine &
                            "Favor entrar com uma nova String de Conexão válida",
                            "String Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtConnString.Focus()
            txtConnString.SelectAll()
            Exit Sub
        End If
        '
        If lstConn.SelectedItems.Count > 0 Then
            Dim novaString = lstConn.SelectedItems(0).Text
            '
            '--- execute
            '----------------------------------------------------------------------------------
            lstConn.Items.First(Function(x) x.Text = novaString).SubItems(1).Text = txtConnString.Text.Trim
            ArquivoAlterado = True
            '
        End If
        '
    End Sub

    Private Sub btnSalvarString_Click(sender As Object, e As EventArgs) Handles btnSalvarArquivo.Click
        '
        Try
            '
            Dim writer As New XmlTextWriter(SourceXMLFile, System.Text.Encoding.UTF8)
            '
            With writer
                .WriteStartDocument()
                '
                'define a indentação do arquivo
                .Formatting = Formatting.Indented
                .WriteStartElement("configuration")
                .WriteStartElement("userSettings")
                .WriteStartElement("MySettings")
                '
                For Each item In lstConn.Items
                    '
                    .WriteStartElement("setting")
                    '
                    ' atributo para marcar arquivo recebido
                    .WriteAttributeString("name", item.Text)
                    '
                    ' atributo para marcar arquivo devolvido e confirmado
                    .WriteAttributeString("serializeAs", "String")
                    '
                    .WriteElementString("value", item.SubItems(1).Text)
                    .WriteEndElement() ' setting
                    '
                Next
                '
                .WriteEndElement() ' END: MySettings
                .WriteEndElement() ' END: userSettings
                '
                '--- CONFIG EMAIL ELEMENTS
                .WriteStartElement("emailServerSettings") 'START
                '
                .WriteElementString("emailUserName", "")
                .WriteElementString("emailPassword", "")
                .WriteElementString("smtpPort", "")
                .WriteElementString("smtpHost", "")
                .WriteElementString("smtpEnableSSL", "")
                .WriteElementString("logoRemotaURL", "")
                .WriteElementString("sitePadraoURL", "")

                .WriteEndElement() ' END: emailServerSettings
                '
                .WriteEndElement() ' END: configuration
                .Close()
                '
            End With
            '
            ArquivoAlterado = False
            ArquivoNovo = False
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar Arquivo XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '
        End Try
        '
    End Sub

    Private Sub btnCriarArquivo_Click(sender As Object, e As EventArgs) Handles btnCriarArquivo.Click
        '
        Using OFD As New SaveFileDialog With {
            .Filter = "XML (*.xml)|*.xml",
            .InitialDirectory = Application.StartupPath
        }
            '
            If OFD.ShowDialog = DialogResult.OK Then
                '
                SourceXMLFile = OFD.FileName
                lblCaminho.Text = SourceXMLFile
                ArquivoNovo = True
                ArquivoAlterado = False
                '
            End If
            '
        End Using
        '
    End Sub
    '
    '--- DESIGN DA LISTAGEM
    Private Sub lstListagem_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstConn.DrawColumnHeader
        '
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            Dim brush As Brush = New LinearGradientBrush(eventArgs.ColumnHeaderBounds.BoundsOuter, Color.Transparent, Color.FromArgb(64, Color.SteelBlue), LinearGradientMode.Vertical)
            '
            eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)
            brush.Dispose()
            '
        End If
        '
    End Sub
    '
    Private Sub btnUsar_Click(sender As Object, e As EventArgs) Handles btnUsar.Click
        Dim acessoControl As New AcessoControlBLL
        '
        Try
            acessoControl.SaveConnString(SourceXMLFile, lstConn.SelectedItems(0).Text)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Salvar arquivo de configuração..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
End Class
