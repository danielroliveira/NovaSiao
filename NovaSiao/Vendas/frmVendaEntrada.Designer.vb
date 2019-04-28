<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVendaEntrada
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblFilial = New System.Windows.Forms.Label()
        Me.lblConta = New System.Windows.Forms.Label()
        Me.txtValor = New Controles.Text_Monetario()
        Me.txtFormaTipo = New System.Windows.Forms.TextBox()
        Me.btnProcurarTipo = New VIBlend.WinForms.Controls.vButton()
        Me.lstItens = New ComponentOwl.BetterListView.BetterListView()
        Me.clnForma = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
        Me.txtPesquisa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPesquisa = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(362, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(136, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(226, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Entrada | Pagamento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 282)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Valor"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.dollar_currency_sign
        Me.btnOK.Location = New System.Drawing.Point(65, 318)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(111, 48)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "&Receber"
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(183, 318)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(111, 48)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblFilial
        '
        Me.lblFilial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFilial.BackColor = System.Drawing.Color.Gainsboro
        Me.lblFilial.Location = New System.Drawing.Point(4, 377)
        Me.lblFilial.Name = "lblFilial"
        Me.lblFilial.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblFilial.Size = New System.Drawing.Size(162, 23)
        Me.lblFilial.TabIndex = 13
        Me.lblFilial.Text = "Filial"
        Me.lblFilial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConta
        '
        Me.lblConta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConta.BackColor = System.Drawing.Color.Gainsboro
        Me.lblConta.Location = New System.Drawing.Point(169, 377)
        Me.lblConta.Name = "lblConta"
        Me.lblConta.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblConta.Size = New System.Drawing.Size(189, 23)
        Me.lblConta.TabIndex = 14
        Me.lblConta.Text = "Conta"
        Me.lblConta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValor
        '
        Me.txtValor.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Location = New System.Drawing.Point(65, 279)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(111, 31)
        Me.txtValor.TabIndex = 10
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFormaTipo
        '
        Me.txtFormaTipo.Location = New System.Drawing.Point(65, 70)
        Me.txtFormaTipo.Name = "txtFormaTipo"
        Me.txtFormaTipo.Size = New System.Drawing.Size(151, 27)
        Me.txtFormaTipo.TabIndex = 3
        '
        'btnProcurarTipo
        '
        Me.btnProcurarTipo.AllowAnimations = True
        Me.btnProcurarTipo.BackColor = System.Drawing.Color.Transparent
        Me.btnProcurarTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProcurarTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcurarTipo.Location = New System.Drawing.Point(222, 70)
        Me.btnProcurarTipo.Name = "btnProcurarTipo"
        Me.btnProcurarTipo.RoundedCornersMask = CType(15, Byte)
        Me.btnProcurarTipo.RoundedCornersRadius = 0
        Me.btnProcurarTipo.Size = New System.Drawing.Size(34, 27)
        Me.btnProcurarTipo.TabIndex = 4
        Me.btnProcurarTipo.TabStop = False
        Me.btnProcurarTipo.Text = "..."
        Me.btnProcurarTipo.UseCompatibleTextRendering = True
        Me.btnProcurarTipo.UseVisualStyleBackColor = False
        Me.btnProcurarTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'lstItens
        '
        Me.lstItens.ColorSortedColumn = System.Drawing.Color.Transparent
        Me.lstItens.Columns.Add(Me.clnForma)
        Me.lstItens.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItens.FontGroups = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.None
        Me.lstItens.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection
        Me.lstItens.HotTracking = ComponentOwl.BetterListView.BetterListViewHotTracking.ItemHot
        Me.lstItens.Location = New System.Drawing.Point(65, 103)
        Me.lstItens.MultiSelect = False
        Me.lstItens.Name = "lstItens"
        Me.lstItens.Size = New System.Drawing.Size(274, 170)
        Me.lstItens.TabIndex = 8
        Me.lstItens.TabStop = False
        '
        'clnForma
        '
        Me.clnForma.AllowResize = False
        Me.clnForma.Name = "clnForma"
        Me.clnForma.Text = "Forma de Pagamento"
        Me.clnForma.Width = 190
        '
        'txtPesquisa
        '
        Me.txtPesquisa.Location = New System.Drawing.Point(262, 70)
        Me.txtPesquisa.Name = "txtPesquisa"
        Me.txtPesquisa.Size = New System.Drawing.Size(77, 27)
        Me.txtPesquisa.TabIndex = 5
        Me.txtPesquisa.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Forma"
        '
        'lblPesquisa
        '
        Me.lblPesquisa.AutoSize = True
        Me.lblPesquisa.BackColor = System.Drawing.Color.Transparent
        Me.lblPesquisa.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesquisa.Location = New System.Drawing.Point(265, 56)
        Me.lblPesquisa.Name = "lblPesquisa"
        Me.lblPesquisa.Size = New System.Drawing.Size(32, 13)
        Me.lblPesquisa.TabIndex = 6
        Me.lblPesquisa.Text = "Filtro"
        Me.lblPesquisa.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "1:Dinheiro | 2:Débito | 3:Crédito | ..."
        '
        'frmVendaEntrada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(362, 404)
        Me.Controls.Add(Me.txtPesquisa)
        Me.Controls.Add(Me.lstItens)
        Me.Controls.Add(Me.btnProcurarTipo)
        Me.Controls.Add(Me.txtFormaTipo)
        Me.Controls.Add(Me.lblConta)
        Me.Controls.Add(Me.lblFilial)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblPesquisa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmVendaEntrada"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblPesquisa, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtValor, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.lblFilial, 0)
        Me.Controls.SetChildIndex(Me.lblConta, 0)
        Me.Controls.SetChildIndex(Me.txtFormaTipo, 0)
        Me.Controls.SetChildIndex(Me.btnProcurarTipo, 0)
        Me.Controls.SetChildIndex(Me.lstItens, 0)
        Me.Controls.SetChildIndex(Me.txtPesquisa, 0)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtValor As Controles.Text_Monetario
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblFilial As Label
    Friend WithEvents lblConta As Label
    Friend WithEvents txtFormaTipo As TextBox
    Friend WithEvents btnProcurarTipo As VIBlend.WinForms.Controls.vButton
    Friend WithEvents lstItens As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents clnForma As ComponentOwl.BetterListView.BetterListViewColumnHeader
    Friend WithEvents txtPesquisa As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPesquisa As Label
    Friend WithEvents Label4 As Label
End Class
