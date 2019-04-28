<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClienteProcurar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcurar = New System.Windows.Forms.TextBox()
        Me.lstListagem = New ComponentOwl.BetterListView.BetterListView()
        Me.clnRGCadastro = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnCadastroNome = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnCNP = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnAtivoImagem = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnIDSituacao = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnPessoaTipo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnRGAtividade = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnUF = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnID = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.Painel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbRGAtividade = New Controles.ComboBox_OnlyValues()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbAtivo = New Controles.ComboBox_OnlyValues()
        Me.lblProc = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnProcurar = New System.Windows.Forms.Button()
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Painel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Procurar"
        '
        'txtProcurar
        '
        Me.txtProcurar.Location = New System.Drawing.Point(81, 72)
        Me.txtProcurar.Name = "txtProcurar"
        Me.txtProcurar.Size = New System.Drawing.Size(340, 27)
        Me.txtProcurar.TabIndex = 2
        '
        'lstListagem
        '
        Me.lstListagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstListagem.Columns.Add(Me.clnRGCadastro)
        Me.lstListagem.Columns.Add(Me.clnCadastroNome)
        Me.lstListagem.Columns.Add(Me.clnCNP)
        Me.lstListagem.Columns.Add(Me.clnAtivoImagem)
        Me.lstListagem.Columns.Add(Me.clnIDSituacao)
        Me.lstListagem.Columns.Add(Me.clnPessoaTipo)
        Me.lstListagem.Columns.Add(Me.clnRGAtividade)
        Me.lstListagem.Columns.Add(Me.clnUF)
        Me.lstListagem.Columns.Add(Me.clnID)
        Me.lstListagem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstListagem.FontColumns = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstListagem.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
        Me.lstListagem.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstListagem.Location = New System.Drawing.Point(12, 117)
        Me.lstListagem.MultiSelect = False
        Me.lstListagem.Name = "lstListagem"
        Me.lstListagem.Size = New System.Drawing.Size(637, 454)
        Me.lstListagem.TabIndex = 7
        '
        'clnRGCadastro
        '
        Me.clnRGCadastro.AllowResize = False
        Me.clnRGCadastro.ForeColor = System.Drawing.Color.Black
        Me.clnRGCadastro.Name = "clnRGCadastro"
        Me.clnRGCadastro.Text = "RG."
        Me.clnRGCadastro.Width = 50
        '
        'clnCadastroNome
        '
        Me.clnCadastroNome.AllowResize = False
        Me.clnCadastroNome.DisplayMember = "Cadastro"
        Me.clnCadastroNome.ForeColor = System.Drawing.Color.Black
        Me.clnCadastroNome.Name = "clnCadastroNome"
        Me.clnCadastroNome.Text = "Nome"
        Me.clnCadastroNome.Width = 300
        '
        'clnCNP
        '
        Me.clnCNP.AllowResize = False
        Me.clnCNP.ForeColor = System.Drawing.Color.Black
        Me.clnCNP.Name = "clnCNP"
        Me.clnCNP.Text = "CPF | CNPJ"
        Me.clnCNP.Width = 190
        '
        'clnAtivoImagem
        '
        Me.clnAtivoImagem.AlignHorizontalImage = ComponentOwl.BetterListView.BetterListViewImageAlignmentHorizontal.OverlayCenter
        Me.clnAtivoImagem.AllowResize = False
        Me.clnAtivoImagem.ForeColor = System.Drawing.Color.Black
        Me.clnAtivoImagem.Name = "clnAtivoImagem"
        Me.clnAtivoImagem.Text = "Ativo"
        Me.clnAtivoImagem.Width = 60
        '
        'clnIDSituacao
        '
        Me.clnIDSituacao.AllowResize = False
        Me.clnIDSituacao.Name = "clnIDSituacao"
        Me.clnIDSituacao.Width = 0
        '
        'clnPessoaTipo
        '
        Me.clnPessoaTipo.AllowResize = False
        Me.clnPessoaTipo.Name = "clnPessoaTipo"
        Me.clnPessoaTipo.Text = "PessoaTipo"
        Me.clnPessoaTipo.Width = 0
        '
        'clnRGAtividade
        '
        Me.clnRGAtividade.Name = "clnRGAtividade"
        Me.clnRGAtividade.Text = "RGAtividade"
        Me.clnRGAtividade.ValueMember = "RGAtividade"
        Me.clnRGAtividade.Width = 0
        '
        'clnUF
        '
        Me.clnUF.AllowResize = False
        Me.clnUF.Name = "clnUF"
        Me.clnUF.Text = "UF"
        Me.clnUF.ValueMember = "UF"
        Me.clnUF.Width = 0
        '
        'clnID
        '
        Me.clnID.AllowResize = False
        Me.clnID.DisplayMember = "IDPessoa"
        Me.clnID.Name = "clnID"
        Me.clnID.Text = "ID"
        Me.clnID.ValueMember = "IDPessoa"
        Me.clnID.Width = 0
        '
        'Painel
        '
        Me.Painel.BackColor = System.Drawing.Color.SlateGray
        Me.Painel.Controls.Add(Me.Label2)
        Me.Painel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Painel.Location = New System.Drawing.Point(0, 0)
        Me.Painel.Name = "Painel"
        Me.Painel.Size = New System.Drawing.Size(659, 50)
        Me.Painel.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(444, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 36)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Procurar Cliente"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(528, 582)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 42)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEscolher
        '
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnEscolher.Location = New System.Drawing.Point(401, 582)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(121, 42)
        Me.btnEscolher.TabIndex = 12
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(436, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tipo"
        '
        'cmbRGAtividade
        '
        Me.cmbRGAtividade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRGAtividade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRGAtividade.FormattingEnabled = True
        Me.cmbRGAtividade.Location = New System.Drawing.Point(479, 72)
        Me.cmbRGAtividade.Name = "cmbRGAtividade"
        Me.cmbRGAtividade.RestrictContentToListItems = True
        Me.cmbRGAtividade.Size = New System.Drawing.Size(170, 27)
        Me.cmbRGAtividade.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 596)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Situação"
        '
        'cmbAtivo
        '
        Me.cmbAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAtivo.FormattingEnabled = True
        Me.cmbAtivo.Location = New System.Drawing.Point(81, 593)
        Me.cmbAtivo.Name = "cmbAtivo"
        Me.cmbAtivo.RestrictContentToListItems = True
        Me.cmbAtivo.Size = New System.Drawing.Size(176, 27)
        Me.cmbAtivo.TabIndex = 9
        '
        'lblProc
        '
        Me.lblProc.BackColor = System.Drawing.Color.White
        Me.lblProc.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProc.Location = New System.Drawing.Point(234, 75)
        Me.lblProc.Margin = New System.Windows.Forms.Padding(0)
        Me.lblProc.Name = "lblProc"
        Me.lblProc.Size = New System.Drawing.Size(182, 19)
        Me.lblProc.TabIndex = 3
        Me.lblProc.Text = "Digite algo para procurar..."
        Me.lblProc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(576, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "PgDn | PgUp"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(186, 576)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Home | End"
        '
        'btnProcurar
        '
        Me.btnProcurar.Enabled = False
        Me.btnProcurar.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnProcurar.Location = New System.Drawing.Point(274, 582)
        Me.btnProcurar.Name = "btnProcurar"
        Me.btnProcurar.Size = New System.Drawing.Size(121, 42)
        Me.btnProcurar.TabIndex = 11
        Me.btnProcurar.Text = "&Procurar"
        Me.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProcurar.UseVisualStyleBackColor = True
        '
        'frmClienteProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 633)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblProc)
        Me.Controls.Add(Me.cmbAtivo)
        Me.Controls.Add(Me.cmbRGAtividade)
        Me.Controls.Add(Me.btnProcurar)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Painel)
        Me.Controls.Add(Me.lstListagem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtProcurar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClienteProcurar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procurar Clientes"
        CType(Me.lstListagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Painel.ResumeLayout(False)
        Me.Painel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProcurar As TextBox
    Friend WithEvents lstListagem As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnRGCadastro As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnCadastroNome As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnCNP As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnAtivoImagem As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents Painel As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEscolher As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents clnIDSituacao As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnPessoaTipo As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents clnRGAtividade As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnUF As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents cmbRGAtividade As Controles.ComboBox_OnlyValues
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbAtivo As Controles.ComboBox_OnlyValues
    Friend WithEvents clnID As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents lblProc As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnProcurar As Button
End Class
