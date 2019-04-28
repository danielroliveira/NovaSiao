Imports CamadaBLL
Imports System.IO
Imports System.IO.Compression

Public Class frmBackup
    Private bckBLL As New BackupBLL
    Private ArquivoNome As String
    Private DirTemp As String
    Private BackupDirLocal As String
    '
#Region "SUB NEW"
    '
    Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        '--- obter o diretorio de Backup Padrão
        BackupDirLocal = ObterConfigValorNode("BackupDir")
        txtDirCaminho.Text = BackupDirLocal
        '
        Try
            '
            Dim dtProp As DataTable = bckBLL.getPropriedades
            '
            ArquivoNome = IIf(IsDBNull(dtProp(0)("BackupArquivoNome")), "", dtProp(0)("BackupArquivoNome"))
            DirTemp = IIf(IsDBNull(dtProp(0)("BackupDirTemp")), "", dtProp(0)("BackupDirTemp"))
            lblUltBackup.Text = IIf(IsDBNull(dtProp(0)("BackupData")), "Vazio", dtProp(0)("BackupData"))
            '
            DefineNomeArquivo()
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção aconteceu ao obter a lista de Banco de Dados..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
#End Region
    '
#Region "BUTONS FUNCTION"
    '
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        '
        '--- verifica o nome do arquivo de Backup
        If ArquivoNome.Length = 0 Then
            MessageBox.Show("É necessário definir o nome padrão do arquivo de Backup..." & vbNewLine &
                            "Não é possível realizar o Backup agora." & vbNewLine &
                            "Favor comunique ao adminsitrador do sistema", "Nome do Arquivo Vazio",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '
        '--- verifica se existe diretorio de backup
        If txtDirCaminho.Text.Trim.Length = 0 Then
            MessageBox.Show("É necessário definir a pasta em que o Backup será salvo..." & vbNewLine &
                            "Favor definir uma pasta antes de fazer o Backup", "Local do Backup",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '
        Try
            If bckBLL.backupDatabase(lblArquivoNome.Text, txtDirCaminho.Text.Trim, DirTemp) = True Then
                '
                '--- verifica se o arquivo de backup esta presente
                If Not File.Exists(txtDirCaminho.Text.Trim & "\TempBackup\" & lblArquivoNome.Text & ".bak") Then
                    Throw New Exception("Arquivo de Backup não foi encontrado...")
                End If
                '
                '--- compacta o arquivo de Backup
                ZipFile.CreateFromDirectory(txtDirCaminho.Text.Trim & "\TempBackup\", txtDirCaminho.Text.Trim & "\" & lblArquivoNome.Text & ".zip")
                '--- remove o diretorio temporario
                Directory.Delete(txtDirCaminho.Text.Trim & "\TempBackup\", True)
                '
                '--- dispara mensagem de sucesso
                MessageBox.Show("Backup Realizado com sucesso!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
            End If
        Catch ex As Exception
            MessageBox.Show("Uma exceção aconteceu ao realizar Backup do Banco de Dados..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '
    End Sub
    '
    Private Sub btnDirEscolher_Click(sender As Object, e As EventArgs) Handles btnDirEscolher.Click
        '
        Using FBDiag As New FolderBrowserDialog With {
            .Description = "Escolher Pasta de Backup"}
            '
            If FBDiag.ShowDialog = DialogResult.OK Then
                txtDirCaminho.Text = FBDiag.SelectedPath
                '
                SetarNode("BackupDir", FBDiag.SelectedPath)
            End If
            '
        End Using
        '
    End Sub
    '
    Private Sub btnRestaurar_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        MsgBox("Em implementação...")
    End Sub
    '
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
#End Region

#Region "FUNCOES NECESSARIAS"
    '
    Private Sub DefineNomeArquivo()
        '
        If ArquivoNome.Trim.Length = 0 Then
            lblArquivoNome.Text = ArquivoNome
            Exit Sub
        End If
        '
        Dim newArquivoNome As String = ArquivoNome
        '
        '--- verifica se deve inserir a Data no nome
        If chkInserirData.Checked = True Then
            newArquivoNome = newArquivoNome & "_" & Format(Now, "yyyyMMdd")
        End If
        '
        '--- verifica se deve inserir a Hora no nome
        If chkInserirHora.Checked = True Then
            newArquivoNome = newArquivoNome & "_" & Format(Now, "HHmm")
        End If
        '
        lblArquivoNome.Text = newArquivoNome
    End Sub
    '
    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chkInserirHora.CheckedChanged, chkInserirData.CheckedChanged
        If CanFocus = False Then Exit Sub
        '
        If DirectCast(sender, Control).Name = "chkInserirData" Then
            If chkInserirData.Checked = False Then
                chkInserirHora.Checked = False
                chkInserirHora.Enabled = False
            Else
                chkInserirHora.Checked = True
                chkInserirHora.Enabled = True
            End If
        End If
        '
        DefineNomeArquivo()
        '
    End Sub
    '
#End Region
    '
End Class
