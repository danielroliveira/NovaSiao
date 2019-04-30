<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnString
    Inherits NovaSiao.frmModFinBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnObterArquivo = New System.Windows.Forms.Button()
        Me.btnCriarArquivo = New System.Windows.Forms.Button()
        Me.btnUsar = New System.Windows.Forms.Button()
        Me.txtConnString = New System.Windows.Forms.TextBox()
        Me.lblCaminho = New System.Windows.Forms.Label()
        Me.lstConn = New ComponentOwl.BetterListView.BetterListView()
        Me.clnNome = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnString = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.btnNovaString = New System.Windows.Forms.Button()
        Me.btnRemoverString = New System.Windows.Forms.Button()
        Me.btnSalvarArquivo = New System.Windows.Forms.Button()
        Me.btnAtualizar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.Panel1.SuspendLayout()
        CType(Me.lstConn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(717, 50)
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(436, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(281, 50)
        Me.lblTitulo.Text = "Definir Banco de Dados"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnObterArquivo
        '
        Me.btnObterArquivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnObterArquivo.Image = Global.NovaSiao.My.Resources.Resources.download
        Me.btnObterArquivo.Location = New System.Drawing.Point(18, 492)
        Me.btnObterArquivo.Name = "btnObterArquivo"
        Me.btnObterArquivo.Size = New System.Drawing.Size(160, 46)
        Me.btnObterArquivo.TabIndex = 2
        Me.btnObterArquivo.Text = "Abrir Arquivo"
        Me.btnObterArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObterArquivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnObterArquivo.UseVisualStyleBackColor = True
        '
        'btnCriarArquivo
        '
        Me.btnCriarArquivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCriarArquivo.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnCriarArquivo.Location = New System.Drawing.Point(184, 492)
        Me.btnCriarArquivo.Name = "btnCriarArquivo"
        Me.btnCriarArquivo.Size = New System.Drawing.Size(160, 46)
        Me.btnCriarArquivo.TabIndex = 2
        Me.btnCriarArquivo.Text = "Criar Arquivo"
        Me.btnCriarArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCriarArquivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCriarArquivo.UseVisualStyleBackColor = True
        '
        'btnUsar
        '
        Me.btnUsar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnUsar.Image = Global.NovaSiao.My.Resources.Resources.refresh1
        Me.btnUsar.Location = New System.Drawing.Point(515, 492)
        Me.btnUsar.Name = "btnUsar"
        Me.btnUsar.Size = New System.Drawing.Size(179, 46)
        Me.btnUsar.TabIndex = 2
        Me.btnUsar.Text = "USAR Conexão"
        Me.btnUsar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUsar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUsar.UseVisualStyleBackColor = True
        '
        'txtConnString
        '
        Me.txtConnString.Location = New System.Drawing.Point(18, 334)
        Me.txtConnString.Multiline = True
        Me.txtConnString.Name = "txtConnString"
        Me.txtConnString.Size = New System.Drawing.Size(491, 114)
        Me.txtConnString.TabIndex = 3
        '
        'lblCaminho
        '
        Me.lblCaminho.Location = New System.Drawing.Point(18, 67)
        Me.lblCaminho.Name = "lblCaminho"
        Me.lblCaminho.Size = New System.Drawing.Size(491, 30)
        Me.lblCaminho.TabIndex = 4
        Me.lblCaminho.Text = "Caminho do Arquivo"
        '
        'lstConn
        '
        Me.lstConn.Columns.Add(Me.clnNome)
        Me.lstConn.Columns.Add(Me.clnString)
        Me.lstConn.DisplayMember = "Nome"
        Me.lstConn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstConn.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstConn.Location = New System.Drawing.Point(22, 100)
        Me.lstConn.Name = "lstConn"
        Me.lstConn.Size = New System.Drawing.Size(672, 199)
        Me.lstConn.TabIndex = 5
        '
        'clnNome
        '
        Me.clnNome.DisplayMember = "Nome"
        Me.clnNome.Name = "clnNome"
        Me.clnNome.Text = "Nome"
        '
        'clnString
        '
        Me.clnString.DisplayMember = "connString"
        Me.clnString.Name = "clnString"
        Me.clnString.Text = "String Conexão"
        Me.clnString.Width = 500
        '
        'btnNovaString
        '
        Me.btnNovaString.Image = Global.NovaSiao.My.Resources.Resources.add
        Me.btnNovaString.Location = New System.Drawing.Point(522, 334)
        Me.btnNovaString.Name = "btnNovaString"
        Me.btnNovaString.Size = New System.Drawing.Size(124, 34)
        Me.btnNovaString.TabIndex = 6
        Me.btnNovaString.Text = "Nova"
        Me.btnNovaString.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovaString.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovaString.UseVisualStyleBackColor = True
        '
        'btnRemoverString
        '
        Me.btnRemoverString.Image = Global.NovaSiao.My.Resources.Resources.delete
        Me.btnRemoverString.Location = New System.Drawing.Point(522, 414)
        Me.btnRemoverString.Name = "btnRemoverString"
        Me.btnRemoverString.Size = New System.Drawing.Size(124, 34)
        Me.btnRemoverString.TabIndex = 6
        Me.btnRemoverString.Text = "Remover"
        Me.btnRemoverString.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemoverString.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemoverString.UseVisualStyleBackColor = True
        '
        'btnSalvarArquivo
        '
        Me.btnSalvarArquivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSalvarArquivo.Enabled = False
        Me.btnSalvarArquivo.Image = Global.NovaSiao.My.Resources.Resources.save
        Me.btnSalvarArquivo.Location = New System.Drawing.Point(350, 492)
        Me.btnSalvarArquivo.Name = "btnSalvarArquivo"
        Me.btnSalvarArquivo.Size = New System.Drawing.Size(159, 46)
        Me.btnSalvarArquivo.TabIndex = 6
        Me.btnSalvarArquivo.Text = "Salvar Arquivo"
        Me.btnSalvarArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvarArquivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvarArquivo.UseVisualStyleBackColor = True
        '
        'btnAtualizar
        '
        Me.btnAtualizar.Image = Global.NovaSiao.My.Resources.Resources.refresh
        Me.btnAtualizar.Location = New System.Drawing.Point(522, 374)
        Me.btnAtualizar.Name = "btnAtualizar"
        Me.btnAtualizar.Size = New System.Drawing.Size(124, 34)
        Me.btnAtualizar.TabIndex = 6
        Me.btnAtualizar.Text = "Atualizar"
        Me.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAtualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAtualizar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 312)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "String de Conexão"
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(685, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(20, 20)
        Me.btnClose.TabIndex = 55
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2003SILVER
        '
        'frmConnString
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(717, 550)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalvarArquivo)
        Me.Controls.Add(Me.btnRemoverString)
        Me.Controls.Add(Me.btnAtualizar)
        Me.Controls.Add(Me.btnNovaString)
        Me.Controls.Add(Me.lstConn)
        Me.Controls.Add(Me.lblCaminho)
        Me.Controls.Add(Me.txtConnString)
        Me.Controls.Add(Me.btnUsar)
        Me.Controls.Add(Me.btnCriarArquivo)
        Me.Controls.Add(Me.btnObterArquivo)
        Me.Name = "frmConnString"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnObterArquivo, 0)
        Me.Controls.SetChildIndex(Me.btnCriarArquivo, 0)
        Me.Controls.SetChildIndex(Me.btnUsar, 0)
        Me.Controls.SetChildIndex(Me.txtConnString, 0)
        Me.Controls.SetChildIndex(Me.lblCaminho, 0)
        Me.Controls.SetChildIndex(Me.lstConn, 0)
        Me.Controls.SetChildIndex(Me.btnNovaString, 0)
        Me.Controls.SetChildIndex(Me.btnAtualizar, 0)
        Me.Controls.SetChildIndex(Me.btnRemoverString, 0)
        Me.Controls.SetChildIndex(Me.btnSalvarArquivo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstConn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnObterArquivo As Button
    Friend WithEvents btnCriarArquivo As Button
    Friend WithEvents btnUsar As Button
    Friend WithEvents txtConnString As TextBox
    Friend WithEvents lblCaminho As Label
    Friend WithEvents lstConn As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnNome As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnString As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnNovaString As Button
    Friend WithEvents btnRemoverString As Button
    Friend WithEvents btnSalvarArquivo As Button
    Friend WithEvents btnAtualizar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
End Class
