Imports System.Xml
'
Public Class frmPedidoMensagens
    Const _defaultRowHeight As Integer = 30 '--- altura da ROW
    Private Sit As EnumFlagEstado
    Private _formOrigem As Form
    '
#Region "LOAD | NEW"
    '
    '--- SUB NEW
    Sub New(frmOrigem As Form)
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        FormataMensagens()
        If LerConfigXML() = False Then Close()
        Sit = EnumFlagEstado.RegistroSalvo
        _formOrigem = frmOrigem
        '
    End Sub
    '
#End Region
    '
#Region "XML FUNCTIONS"
    '
    ' LER O ARQUIVO XML
    '-----------------------------------------------------------------------------------------------
    Private Function LerConfigXML() As Boolean
        Dim myXML As New XmlDocument
        '
        Try
            myXML.Load(Application.StartupPath & "\ConfigFiles\Config.xml")
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao tentar abrir abrir o arquivo XML", "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
        Dim node As XmlNode = myXML.SelectSingleNode("Configuracao").SelectSingleNode("MensagemPedido")
        '
        If IsNothing(node) OrElse Not node.HasChildNodes Then Return True
        '
        For Each m As XmlNode In node.ChildNodes
            dgvMensagens.Rows.Add({m.InnerText})
        Next
        '
        Return True
        '
    End Function
    '
    ' GRAVAR/SALVAR ARQUIVO XML
    '-----------------------------------------------------------------------------------------------
    Private Function SalvarXML() As Boolean
        Dim myXML As New XmlDocument
        '
        '--- Verifica a existencia do arquivo config.xml
        Try
            myXML.Load(Application.StartupPath & "\ConfigFiles\Config.xml")
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao tentar abrir abrir o arquivo XML", "Exceção",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        '
        '--- verifica se existe node MENSAGEM PEDIDO
        Dim elemList As XmlNodeList = myXML.GetElementsByTagName("MensagemPedido")
        '
        '--- se não existir o node PAI entao cria
        If elemList.Count = 0 Then
            'Create a new node.
            Dim newNodeOrigem As XmlElement = myXML.CreateElement("MensagemPedido")
            myXML.SelectSingleNode("Configuracao").AppendChild(newNodeOrigem)
        End If
        '
        '--- seleciona o node PAI
        Dim node As XmlNode = myXML.SelectSingleNode("Configuracao").SelectSingleNode("MensagemPedido")
        '
        '--- exclui todas as mensagens anteriores do node PAI
        node.RemoveAll()
        '
        '--- adiciona novos nodes filhos pelo datagrid
        '--- verifica se existem alguma ROW criada com mensagem
        If dgvMensagens.Rows.Count = 0 Then
            MessageBox.Show("Não há nenhuma mensagem padrão criada...", "Mensagens Padrão",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If
        '
        '--- percorre pelas ROWS e cria novos nodes filhos
        For Each r As DataGridViewRow In dgvMensagens.Rows
            'pula caso for nova row
            If r.IsNewRow Then Continue For
            '
            'Create a new node.
            Dim newNode As XmlElement = myXML.CreateElement("MensagemPedidoItem")
            newNode.InnerText = r.Cells("clnMensagem").Value.ToString
            node.AppendChild(newNode)
            '
        Next
        '
        '--- grava o arquivo XML
        myXML.Save(Application.StartupPath & "\ConfigFiles\Config.xml")
        Return True
        '
    End Function
    '
#End Region
    '
#Region "DATAGRID FUNCTIONS"
    '
    '--- FORMATA O DATAGRIDVIEW
    Private Sub FormataMensagens()
        '
        ' altera as propriedades importantes
        dgvMensagens.MultiSelect = False
        dgvMensagens.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        dgvMensagens.ColumnHeadersVisible = True
        dgvMensagens.AllowUserToResizeRows = False
        dgvMensagens.AllowUserToResizeColumns = False
        dgvMensagens.RowHeadersVisible = True
        dgvMensagens.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgvMensagens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvMensagens.StandardTab = True
        '
        dgvMensagens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        '
    End Sub
    '
    '--- DEFINE O ALTURA PADRAO DA ROW
    Private Sub dgvMensagens_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvMensagens.RowPrePaint
        dgvMensagens.Rows(e.RowIndex).Height = _defaultRowHeight
    End Sub
    '
    '--- HABILITA O BTNSALVAR E ATUALIZA O SIT
    Private Sub dgvMensagens_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvMensagens.RowValidating
        If dgvMensagens.IsCurrentRowDirty Then
            btnSalvar.Enabled = True
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    '
    Private Sub dgvMensagens_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgvMensagens.UserDeletedRow
        btnSalvar.Enabled = True
        Sit = EnumFlagEstado.Alterado
    End Sub
    '
#End Region
    '
#Region "BUTTONS FUNCTIONS"
    '
    '--- FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        '
        '--- pergunta ao usuário
        If Sit <> EnumFlagEstado.RegistroSalvo Then
            '
            If MessageBox.Show("As alterações feitas ainda não foram salvas." & vbNewLine &
                               "Todas as alterações serão perdidas..." & vbNewLine &
                               "Deseja fechar assim mesmo?", "Fechar",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        End If
        '
        Close()
        '
    End Sub
    '
    '--- FECHAR
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnFechar_Click(sender, e)
    End Sub
    '
    '--- SALVAR GRAVAR NO CONFIG
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If SalvarXML() = True Then
            Sit = EnumFlagEstado.RegistroSalvo
            btnSalvar.Enabled = False
            '
            MessageBox.Show("Mensagens salvas com sucesso!", "Salvar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
        End If
        '
    End Sub
    '
#End Region
    '
#Region "EFEITOS VISUAIS"
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
End Class
