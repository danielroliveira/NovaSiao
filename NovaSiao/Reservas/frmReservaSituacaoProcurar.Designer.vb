<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservaSituacaoProcurar
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
        Me.lstItens = New ComponentOwl.BetterListView.BetterListView()
        Me.clnSituacao = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.pnlAtivas = New System.Windows.Forms.Panel()
        Me.rbtInativas = New System.Windows.Forms.RadioButton()
        Me.rbtAtivas = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAtivas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(279, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(10, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(269, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Escolher Situação"
        '
        'lstItens
        '
        Me.lstItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstItens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstItens.ColorSortedColumn = System.Drawing.Color.LightBlue
        Me.lstItens.Columns.Add(Me.clnSituacao)
        Me.lstItens.DisplayMember = "SituacaoDescricao"
        Me.lstItens.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItens.FontColumns = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItens.ForeColor = System.Drawing.Color.Black
        Me.lstItens.ForeColorColumns = System.Drawing.Color.Black
        Me.lstItens.ForeColorGroups = System.Drawing.SystemColors.MenuHighlight
        Me.lstItens.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid
        Me.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
        Me.lstItens.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstItens.Location = New System.Drawing.Point(12, 111)
        Me.lstItens.MultiSelect = False
        Me.lstItens.Name = "lstItens"
        Me.lstItens.Size = New System.Drawing.Size(253, 209)
        Me.lstItens.TabIndex = 1
        Me.lstItens.TabStop = False
        Me.lstItens.ValueMember = "IDSituacaoReserva"
        '
        'clnSituacao
        '
        Me.clnSituacao.AllowResize = False
        Me.clnSituacao.DisplayMember = "SituacaoReserva"
        Me.clnSituacao.Name = "clnSituacao"
        Me.clnSituacao.Text = "Situação"
        Me.clnSituacao.ValueMember = "IDSituacaoReserva"
        Me.clnSituacao.Width = 250
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(144, 330)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 41)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEscolher
        '
        Me.btnEscolher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEscolher.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnEscolher.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.Location = New System.Drawing.Point(12, 330)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(121, 41)
        Me.btnEscolher.TabIndex = 2
        Me.btnEscolher.TabStop = False
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'pnlAtivas
        '
        Me.pnlAtivas.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlAtivas.Controls.Add(Me.rbtInativas)
        Me.pnlAtivas.Controls.Add(Me.rbtAtivas)
        Me.pnlAtivas.Location = New System.Drawing.Point(12, 60)
        Me.pnlAtivas.Name = "pnlAtivas"
        Me.pnlAtivas.Size = New System.Drawing.Size(253, 39)
        Me.pnlAtivas.TabIndex = 4
        '
        'rbtInativas
        '
        Me.rbtInativas.AutoSize = True
        Me.rbtInativas.Location = New System.Drawing.Point(122, 7)
        Me.rbtInativas.Name = "rbtInativas"
        Me.rbtInativas.Size = New System.Drawing.Size(114, 23)
        Me.rbtInativas.TabIndex = 1
        Me.rbtInativas.Text = "2. Concluídas"
        Me.rbtInativas.UseVisualStyleBackColor = True
        '
        'rbtAtivas
        '
        Me.rbtAtivas.AutoSize = True
        Me.rbtAtivas.Location = New System.Drawing.Point(29, 7)
        Me.rbtAtivas.Name = "rbtAtivas"
        Me.rbtAtivas.Size = New System.Drawing.Size(83, 23)
        Me.rbtAtivas.TabIndex = 0
        Me.rbtAtivas.Text = "1. Ativas"
        Me.rbtAtivas.UseVisualStyleBackColor = True
        '
        'frmReservaSituacaoProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(279, 383)
        Me.Controls.Add(Me.pnlAtivas)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lstItens)
        Me.KeyPreview = True
        Me.Name = "frmReservaSituacaoProcurar"
        Me.Controls.SetChildIndex(Me.lstItens, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.pnlAtivas, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAtivas.ResumeLayout(False)
        Me.pnlAtivas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstItens As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnSituacao As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEscolher As Button
    Friend WithEvents pnlAtivas As Panel
    Friend WithEvents rbtInativas As RadioButton
    Friend WithEvents rbtAtivas As RadioButton
End Class
