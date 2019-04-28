<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContaProcurar
    Inherits NovaSiao.frmModNBorder

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
        Me.clnID = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnConta = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnAtivo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEscolher = New System.Windows.Forms.Button()
        Me.txtProcura = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(418, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(228, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(190, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Escolher a Conta"
        '
        'lstItens
        '
        Me.lstItens.ColorSortedColumn = System.Drawing.Color.Transparent
        Me.lstItens.Columns.Add(Me.clnID)
        Me.lstItens.Columns.Add(Me.clnConta)
        Me.lstItens.Columns.Add(Me.clnAtivo)
        Me.lstItens.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
        Me.lstItens.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstItens.HotTracking = ComponentOwl.BetterListView.BetterListViewHotTracking.ItemHot
        Me.lstItens.Location = New System.Drawing.Point(12, 92)
        Me.lstItens.Name = "lstItens"
        Me.lstItens.Size = New System.Drawing.Size(396, 306)
        Me.lstItens.TabIndex = 2
        '
        'clnID
        '
        Me.clnID.AllowResize = False
        Me.clnID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clnID.Name = "clnID"
        Me.clnID.Text = "ID"
        Me.clnID.Width = 60
        '
        'clnConta
        '
        Me.clnConta.AllowResize = False
        Me.clnConta.Name = "clnConta"
        Me.clnConta.Text = "Conta"
        Me.clnConta.Width = 230
        '
        'clnAtivo
        '
        Me.clnAtivo.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        Me.clnAtivo.AllowResize = False
        Me.clnAtivo.Name = "clnAtivo"
        Me.clnAtivo.Text = "Ativa"
        Me.clnAtivo.Width = 60
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(205, 405)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 41)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEscolher
        '
        Me.btnEscolher.FlatAppearance.BorderSize = 0
        Me.btnEscolher.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnEscolher.Location = New System.Drawing.Point(64, 405)
        Me.btnEscolher.Name = "btnEscolher"
        Me.btnEscolher.Size = New System.Drawing.Size(135, 41)
        Me.btnEscolher.TabIndex = 3
        Me.btnEscolher.Text = "&Escolher"
        Me.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEscolher.UseVisualStyleBackColor = True
        '
        'txtProcura
        '
        Me.txtProcura.Location = New System.Drawing.Point(12, 59)
        Me.txtProcura.Name = "txtProcura"
        Me.txtProcura.Size = New System.Drawing.Size(287, 27)
        Me.txtProcura.TabIndex = 1
        '
        'frmContaProcurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(418, 454)
        Me.Controls.Add(Me.txtProcura)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEscolher)
        Me.Controls.Add(Me.lstItens)
        Me.KeyPreview = True
        Me.Name = "frmContaProcurar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lstItens, 0)
        Me.Controls.SetChildIndex(Me.btnEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtProcura, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstItens As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnID As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnConta As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEscolher As Button
    Friend WithEvents txtProcura As TextBox
    Friend WithEvents clnAtivo As ComponentOwl.BetterListView.BetterListViewColumnHeader
End Class
