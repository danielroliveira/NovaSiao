<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoImportarMigrar
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
        Me.txtFilial = New System.Windows.Forms.TextBox()
        Me.btnFilialEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstItens = New ComponentOwl.BetterListView.BetterListView()
        Me.clnIDPedido = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnData = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnFornecedor = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(621, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(352, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(269, 50)
        Me.lblTitulo.Text = "Importar Pedido"
        '
        'txtFilial
        '
        Me.txtFilial.Location = New System.Drawing.Point(145, 68)
        Me.txtFilial.Name = "txtFilial"
        Me.txtFilial.Size = New System.Drawing.Size(236, 27)
        Me.txtFilial.TabIndex = 14
        '
        'btnFilialEscolher
        '
        Me.btnFilialEscolher.AllowAnimations = True
        Me.btnFilialEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnFilialEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnFilialEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilialEscolher.Location = New System.Drawing.Point(387, 68)
        Me.btnFilialEscolher.Name = "btnFilialEscolher"
        Me.btnFilialEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnFilialEscolher.RoundedCornersRadius = 0
        Me.btnFilialEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnFilialEscolher.TabIndex = 13
        Me.btnFilialEscolher.TabStop = False
        Me.btnFilialEscolher.Text = "..."
        Me.btnFilialEscolher.UseCompatibleTextRendering = True
        Me.btnFilialEscolher.UseVisualStyleBackColor = False
        Me.btnFilialEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Escolha a Filial:"
        '
        'lstItens
        '
        Me.lstItens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstItens.ColorSortedColumn = System.Drawing.Color.LightBlue
        Me.lstItens.Columns.Add(Me.clnIDPedido)
        Me.lstItens.Columns.Add(Me.clnData)
        Me.lstItens.Columns.Add(Me.clnFornecedor)
        Me.lstItens.DisplayMember = "IDPedido"
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
        Me.lstItens.Size = New System.Drawing.Size(597, 293)
        Me.lstItens.TabIndex = 15
        '
        'clnIDPedido
        '
        Me.clnIDPedido.AllowResize = False
        Me.clnIDPedido.DisplayMember = "IDPedido"
        Me.clnIDPedido.Name = "clnIDPedido"
        Me.clnIDPedido.Text = "Reg."
        Me.clnIDPedido.ValueMember = "IDPedido"
        Me.clnIDPedido.Width = 50
        '
        'clnData
        '
        Me.clnData.DisplayMember = "InicioData"
        Me.clnData.Name = "clnData"
        Me.clnData.Text = "Data"
        Me.clnData.ValueMember = "InicioData"
        Me.clnData.Width = 100
        '
        'clnFornecedor
        '
        Me.clnFornecedor.AllowResize = False
        Me.clnFornecedor.DisplayMember = "Fornecedor"
        Me.clnFornecedor.Name = "clnFornecedor"
        Me.clnFornecedor.Text = "Fornecedor"
        Me.clnFornecedor.ValueMember = "IDFornecedor"
        Me.clnFornecedor.Width = 400
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(488, 414)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 41)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnImportar.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImportar.Location = New System.Drawing.Point(12, 414)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(121, 41)
        Me.btnImportar.TabIndex = 16
        Me.btnImportar.Text = "&Importar"
        Me.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'frmPedidoImportarMigrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(621, 467)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lstItens)
        Me.Controls.Add(Me.txtFilial)
        Me.Controls.Add(Me.btnFilialEscolher)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmPedidoImportarMigrar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnFilialEscolher, 0)
        Me.Controls.SetChildIndex(Me.txtFilial, 0)
        Me.Controls.SetChildIndex(Me.lstItens, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnImportar, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFilial As TextBox
    Friend WithEvents btnFilialEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents Label1 As Label
    Friend WithEvents lstItens As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnIDPedido As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnFornecedor As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnImportar As Button
    Friend WithEvents clnData As ComponentOwl.BetterListView.BetterListViewColumnHeader
End Class
