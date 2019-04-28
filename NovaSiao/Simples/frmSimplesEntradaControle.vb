Imports System.Drawing.Drawing2D
Imports System.Xml
Imports CamadaBLL
Imports CamadaDTO
Imports ComponentOwl.BetterListView
'
Public Class frmSimplesEntradaControle
    '
    Private ItemAtivo As Image = My.Resources.accept
    Private ItemInativo As Image = My.Resources.block
    Private _formOrigem As Form = Nothing
    Private lstArquivos As New List(Of ArquivoXML)
    Private bindArquivos As New BindingSource
    '
    Private Class ArquivoXML
        Property ArquivoNome As String
        Property ArquivoPasta As String
        Property IDFilialOrigem As Integer
        Property FilialOrigem As String
        Property IDFilialDestino As Integer
        Property FilialDestino As String
        Property IDSimplesSaida As Integer
        Property SimplesSaidaData As Date
        Property Recebido As Boolean
    End Class
    '
#Region "SUB NEW | PROPERTYS"
    '
    Sub New(Optional formOrigem As Form = Nothing)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        txtPasta.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        ObterArquivosXML()
        PreencheListagem()
        '
        _formOrigem = formOrigem
        '
        bindArquivos.DataSource = lstArquivos
        lstItens.DataSource = bindArquivos
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM"
    '
    '--- OBTER OS TIPOS
    Private Sub ObterArquivosXML()
        '
        '--- remove all elements of list
        lstArquivos.Clear()
        '
        If String.IsNullOrEmpty(txtPasta.Text) Then Exit Sub
        '
        Dim di As New IO.DirectoryInfo(txtPasta.Text)
        Dim foundXML As IO.FileInfo() = di.GetFiles("*.xml")
        Dim fi As IO.FileInfo
        '
        For Each fi In foundXML
            '
            If fi.Name.StartsWith("SS") Then
                '
                Dim newItem As New ArquivoXML With {
                    .ArquivoNome = fi.Name,
                    .ArquivoPasta = fi.DirectoryName
                }
                '
                '--- fill new item with xml
                OpenXML_FillItem(fi.FullName, newItem)
                '
                '--- add in list of
                lstArquivos.Add(newItem)
                '
            End If
            '
        Next
        '
    End Sub
    '
    '--- OPEN THE XML AND FILL ITEM
    Private Sub OpenXML_FillItem(XMLFile As String, Item As ArquivoXML)
        Dim myXML As New XmlDocument
        '
        Try
            myXML.Load(XMLFile)
            '
            '--- Verifica se o ARQUIVO ja foi recebido
            '------------------------------------------------------------------
            Dim dados As XmlNode = myXML.GetElementsByTagName("Dados").Item(0)
            '
            If dados.Attributes.ItemOf("Recebido").Value Then
                Item.Recebido = True
            Else
                Item.Recebido = False
            End If
            '
            '--- Verifica a ORIGEM e o DESTINO da Simples Saida de Origem
            '------------------------------------------------------------------
            Dim nodeSS As XmlElement = myXML.GetElementsByTagName("clSimplesSaida")(0)
            '
            Item.IDFilialDestino = CInt(nodeSS.Item("IDPessoaDestino").InnerText)
            Item.FilialDestino = nodeSS.Item("PessoaDestino").InnerText
            Item.IDFilialOrigem = CInt(nodeSS.Item("IDPessoaOrigem").InnerText)
            Item.FilialOrigem = nodeSS.Item("PessoaOrigem").InnerText
            Item.IDSimplesSaida = CInt(nodeSS.Item("IDTransacao").InnerText)
            Item.SimplesSaidaData = nodeSS.Item("TransacaoData").InnerText
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Abrir ou Ler arquivo XML..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    '--- PREENCHE LISTAGEM
    Private Sub PreencheListagem()
        '
        ' populate ListView with our data
        bindArquivos.ResetBindings(False)
        '
        FormataListagem()
        '
    End Sub
    '
    '--- FORMATA LISTAGEM DE CLIENTE
    Private Sub FormataListagem()
        '
        lstItens.MultiSelect = False
        lstItens.HideSelection = False
        '
        clnArquivo.DisplayMember = "ArquivoNome"
        clnArquivo.ValueMember = "ArquivoPasta"
        '
        clnID.DisplayMember = "IDSimplesSaida"
        clnTransacaoData.DisplayMember = "SimplesSaidaData"
        '
        clnFilialOrigem.DisplayMember = "FilialOrigem"
        clnFilialOrigem.ValueMember = "IDFilialOrigem"
        '
        clnFilialDestino.DisplayMember = "FilialDestino"
        clnFilialDestino.ValueMember = "IDFilialDestino"
        '
        clnRecebido.ValueMember = "Recebido"
        clnRecebido.Width = 70
        '
    End Sub
    '
    '--- DESIGN DA LISTAGEM
    Private Sub lstListagem_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstItens.DrawColumnHeader
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
    Private Sub lstItens_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstItens.DrawItem
        '
        If IsNumeric(eventArgs.Item.SubItems(1).Text) Then
            eventArgs.Item.SubItems(1).Text = Format(CInt(eventArgs.Item.SubItems(1).Text), "0000")
        End If
        '
        eventArgs.Item.SubItems(5).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
        '
        If eventArgs.Item.SubItems(5).Value = "True" Then
            eventArgs.Item.SubItems(5).Image = ItemAtivo
        ElseIf eventArgs.Item.SubItems(5).Value = "False" Then
            eventArgs.Item.SubItems(5).Image = ItemInativo
        End If

    End Sub
    '
#End Region '\ SUB NEW | PROPERTYS
    '
#Region "BUTTONS FUNCTION"
    '
    Private Sub btnDefinePasta_Click(sender As Object, e As EventArgs) Handles btnDefinePasta.Click
        '
        Using FBDiag As New FolderBrowserDialog With {
            .Description = "Escolher Pasta de Origem",
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        }
            '
            If FBDiag.ShowDialog = DialogResult.OK Then
                txtPasta.Text = FBDiag.SelectedPath
            End If
            '
        End Using
        '
        ObterArquivosXML()
        PreencheListagem()
        '
    End Sub
    '
    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        '
        '--- Verifica a selecao da listagem
        If lstItens.SelectedItems.Count = 0 Then
            MessageBox.Show("Não nenhum ARQUIVO XML (Simples Saída) selecionado..." & vbNewLine &
                            "Favor antes selecione um ARQUIVO XML!",
                            "Escolher ARQUIVO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        '--- Verifica se o arquivo ja foi recebido no BD
        Dim sBLL As New SimplesMovimentacaoBLL
        Dim XMLfile As String = lstItens.SelectedItems(0).SubItems(0).Value & "\" & lstItens.SelectedItems(0).SubItems(0).Text
        '
        Try
            '
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            Dim simples As clSimplesEntrada = sBLL.VerificaEntrada(lstItens.SelectedItems(0).SubItems(1).Text)
            '
            '--- Se encontrar o registro de entrada do XML no BD
            If Not IsNothing(simples) Then
                '
                '--- update save XML => Recebido = TRUE
                Dim doc As New XmlDocument()
                doc.Load(XMLfile)
                Dim dados As XmlNode = doc.GetElementsByTagName("Dados").Item(0)
                dados.Attributes.ItemOf("Recebido").Value = True
                doc.Save(XMLfile)
                '
                '--- Notice e ask if need to open a SIMPLES ENTRADA
                If MessageBox.Show("Esse arquivo XML de Simples Saída já foi inserido no BD." & vbNewLine &
                                   "Você deseja abrir a Simples Entrada que foi gerada através dele?",
                                   "Arquivo Já Inserido",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) = DialogResult.Yes Then
                    '
                    '--- open Simples Entrada
                    AbreSimplesEntrada(simples)
                    '
                End If
                '
                Exit Sub
                '
            End If
            '
            Dim sXML As New SimplesXML
            Dim NewSimples As clSimplesEntrada = sXML.Insert_SimplesEntrada_XML(XMLfile)
            '
            If Not IsNothing(NewSimples) Then
                AbreSimplesEntrada(NewSimples)
            End If
            '
        Catch ex As Exception
            '
            MessageBox.Show("Uma exceção ocorreu ao Verificar Entrada da Simples Saída..." & vbNewLine &
            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
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
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        Close()
        MostraMenuPrincipal()
        '
    End Sub
    '
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnCancelar_Click(sender, e)
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
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
    '
#End Region
    '
#Region "OUTRAS FUNCOES"
    '
    '--- ABRIR FRMSIMPLESENTRADA E FECHA ME
    Private Sub AbreSimplesEntrada(simples As clSimplesEntrada)
        '
        '--- open Simples Entrada
        Dim frmSimples As New frmSimplesEntrada(simples) With {
            .MdiParent = frmPrincipal,
            .StartPosition = FormStartPosition.CenterScreen
        }
        '
        '--- fecha o form
        Close()
        '
        frmSimples.Show()
        '
    End Sub
    '
    '--- QUANDO PRESSIONA A TECLA ESC FECHA O FORMULARIO
    '--- QUANDO A TECLA CIMA E BAIXO NAVEGA ENTRE OS ITENS DA LISTAGEM
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnCancelar_Click(New Object, New EventArgs)
            '
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            '
            If lstItens.Items.Count > 0 Then
                If lstItens.SelectedItems.Count > 0 Then
                    Dim i As Integer = lstItens.SelectedItems(0).Index
                    '
                    lstItens.Items(i).Selected = False
                    '
                    If i = 0 Then
                        i = lstItens.Items.Count
                    End If
                    '
                    lstItens.Items(i - 1).Selected = True
                    lstItens.EnsureVisible(i - 1)
                Else
                    lstItens.Items(0).Selected = True
                    lstItens.EnsureVisible(0)
                End If
            End If
            '
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            '
            If lstItens.Items.Count > 0 Then
                If lstItens.SelectedItems.Count > 0 Then
                    Dim i As Integer = lstItens.SelectedItems(0).Index
                    '
                    lstItens.Items(i).Selected = False
                    '
                    If i = lstItens.Items.Count - 1 Then
                        i = -1
                    End If
                    '
                    lstItens.Items(i + 1).Selected = True
                    lstItens.EnsureVisible(i + 1)
                Else
                    lstItens.Items(0).Selected = True
                End If
            End If
            '
        End If
    End Sub
    '
    Private Sub txtPasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPasta.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
End Class
