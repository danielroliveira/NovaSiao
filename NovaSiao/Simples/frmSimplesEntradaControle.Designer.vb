<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSimplesEntradaControle
    Inherits NovaSiao.frmModNBorder

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lstItens = New ComponentOwl.BetterListView.BetterListView()
        Me.clnArquivo = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnID = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnTransacaoData = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnFilialOrigem = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnFilialDestino = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.clnRecebido = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnInserir = New System.Windows.Forms.Button()
        Me.txtPasta = New System.Windows.Forms.TextBox()
        Me.btnDefinePasta = New VIBlend.WinForms.Controls.vButton()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.Panel1.SuspendLayout()
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(789, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(457, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(332, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Controle de Simples Entrada"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstItens
        '
        Me.lstItens.ColorSortedColumn = System.Drawing.Color.Transparent
        Me.lstItens.Columns.Add(Me.clnArquivo)
        Me.lstItens.Columns.Add(Me.clnID)
        Me.lstItens.Columns.Add(Me.clnTransacaoData)
        Me.lstItens.Columns.Add(Me.clnFilialOrigem)
        Me.lstItens.Columns.Add(Me.clnFilialDestino)
        Me.lstItens.Columns.Add(Me.clnRecebido)
        Me.lstItens.DisplayMember = "IDSimplesSaida"
        Me.lstItens.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable
        Me.lstItens.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstItens.HotTracking = ComponentOwl.BetterListView.BetterListViewHotTracking.ItemHot
        Me.lstItens.Location = New System.Drawing.Point(12, 92)
        Me.lstItens.MultiSelect = False
        Me.lstItens.Name = "lstItens"
        Me.lstItens.Size = New System.Drawing.Size(765, 234)
        Me.lstItens.TabIndex = 2
        '
        'clnArquivo
        '
        Me.clnArquivo.Name = "clnArquivo"
        Me.clnArquivo.Text = "Arquivo XML"
        '
        'clnID
        '
        Me.clnID.AllowResize = False
        Me.clnID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clnID.Name = "clnID"
        Me.clnID.Text = "ID"
        Me.clnID.Width = 60
        '
        'clnTransacaoData
        '
        Me.clnTransacaoData.AllowResize = False
        Me.clnTransacaoData.Name = "clnTransacaoData"
        Me.clnTransacaoData.Text = "Data"
        '
        'clnFilialOrigem
        '
        Me.clnFilialOrigem.AllowResize = False
        Me.clnFilialOrigem.Name = "clnFilialOrigem"
        Me.clnFilialOrigem.Text = "Origem"
        Me.clnFilialOrigem.Width = 170
        '
        'clnFilialDestino
        '
        Me.clnFilialDestino.AllowResize = False
        Me.clnFilialDestino.Name = "clnFilialDestino"
        Me.clnFilialDestino.Text = "Destino"
        Me.clnFilialDestino.Width = 170
        '
        'clnRecebido
        '
        Me.clnRecebido.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        Me.clnRecebido.AllowResize = False
        Me.clnRecebido.Name = "clnRecebido"
        Me.clnRecebido.Text = "Rec"
        Me.clnRecebido.Width = 70
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(397, 342)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 41)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnInserir
        '
        Me.btnInserir.FlatAppearance.BorderSize = 0
        Me.btnInserir.Image = Global.NovaSiao.My.Resources.Resources.add_24x24
        Me.btnInserir.Location = New System.Drawing.Point(256, 342)
        Me.btnInserir.Name = "btnInserir"
        Me.btnInserir.Size = New System.Drawing.Size(135, 41)
        Me.btnInserir.TabIndex = 3
        Me.btnInserir.Text = "&Inserir"
        Me.btnInserir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInserir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInserir.UseVisualStyleBackColor = True
        '
        'txtPasta
        '
        Me.txtPasta.Location = New System.Drawing.Point(12, 59)
        Me.txtPasta.Name = "txtPasta"
        Me.txtPasta.ReadOnly = True
        Me.txtPasta.Size = New System.Drawing.Size(356, 27)
        Me.txtPasta.TabIndex = 1
        '
        'btnDefinePasta
        '
        Me.btnDefinePasta.AllowAnimations = True
        Me.btnDefinePasta.BackColor = System.Drawing.Color.Transparent
        Me.btnDefinePasta.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnDefinePasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDefinePasta.Location = New System.Drawing.Point(374, 59)
        Me.btnDefinePasta.Name = "btnDefinePasta"
        Me.btnDefinePasta.RoundedCornersMask = CType(15, Byte)
        Me.btnDefinePasta.RoundedCornersRadius = 0
        Me.btnDefinePasta.Size = New System.Drawing.Size(34, 27)
        Me.btnDefinePasta.TabIndex = 11
        Me.btnDefinePasta.Text = "..."
        Me.btnDefinePasta.UseCompatibleTextRendering = True
        Me.btnDefinePasta.UseVisualStyleBackColor = False
        Me.btnDefinePasta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(757, 12)
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
        'frmSimplesEntradaControle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(789, 396)
        Me.Controls.Add(Me.btnDefinePasta)
        Me.Controls.Add(Me.txtPasta)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnInserir)
        Me.Controls.Add(Me.lstItens)
        Me.KeyPreview = True
        Me.Name = "frmSimplesEntradaControle"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lstItens, 0)
        Me.Controls.SetChildIndex(Me.btnInserir, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtPasta, 0)
        Me.Controls.SetChildIndex(Me.btnDefinePasta, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstItens As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnID As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnFilialOrigem As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnInserir As Button
    Friend WithEvents txtPasta As TextBox
    Friend WithEvents clnRecebido As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnDefinePasta As VIBlend.WinForms.Controls.vButton
    Friend WithEvents clnFilialDestino As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents clnTransacaoData As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents clnArquivo As ComponentOwl.BetterListView.BetterListViewColumnHeader
End Class
