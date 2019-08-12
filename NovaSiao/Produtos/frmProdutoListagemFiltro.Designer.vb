<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdutoListagemFiltro
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
        Me.txtFabricante = New System.Windows.Forms.TextBox()
        Me.txtProdutoCategoria = New System.Windows.Forms.TextBox()
        Me.txtProdutoSubTipo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProduto = New System.Windows.Forms.TextBox()
        Me.txtProdutoTipo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAutor = New System.Windows.Forms.TextBox()
        Me.cmbMovimento = New Controles.ComboBox_OnlyValues()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAtivas = New System.Windows.Forms.Panel()
        Me.rbtInativas = New System.Windows.Forms.RadioButton()
        Me.rbtTodos = New System.Windows.Forms.RadioButton()
        Me.rbtAtivas = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlAtivas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(514, 50)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(286, 0)
        Me.lblTitulo.Size = New System.Drawing.Size(228, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Especificar Pesquisa"
        '
        'txtFabricante
        '
        Me.txtFabricante.Location = New System.Drawing.Point(175, 319)
        Me.txtFabricante.Name = "txtFabricante"
        Me.txtFabricante.Size = New System.Drawing.Size(199, 27)
        Me.txtFabricante.TabIndex = 13
        '
        'txtProdutoCategoria
        '
        Me.txtProdutoCategoria.Location = New System.Drawing.Point(175, 278)
        Me.txtProdutoCategoria.Name = "txtProdutoCategoria"
        Me.txtProdutoCategoria.Size = New System.Drawing.Size(199, 27)
        Me.txtProdutoCategoria.TabIndex = 11
        '
        'txtProdutoSubTipo
        '
        Me.txtProdutoSubTipo.Location = New System.Drawing.Point(175, 237)
        Me.txtProdutoSubTipo.Name = "txtProdutoSubTipo"
        Me.txtProdutoSubTipo.Size = New System.Drawing.Size(199, 27)
        Me.txtProdutoSubTipo.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(92, 322)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 19)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Fabricante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 19)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Subtipo | Classificação"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(97, 281)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Categoria"
        '
        'txtProduto
        '
        Me.txtProduto.Location = New System.Drawing.Point(175, 114)
        Me.txtProduto.Name = "txtProduto"
        Me.txtProduto.Size = New System.Drawing.Size(325, 27)
        Me.txtProduto.TabIndex = 3
        '
        'txtProdutoTipo
        '
        Me.txtProdutoTipo.Location = New System.Drawing.Point(175, 196)
        Me.txtProdutoTipo.Name = "txtProdutoTipo"
        Me.txtProdutoTipo.Size = New System.Drawing.Size(199, 27)
        Me.txtProdutoTipo.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(110, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Produto"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(58, 199)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 19)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Tipo de Produto"
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPesquisar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPesquisar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnPesquisar.Image = Global.NovaSiao.My.Resources.Resources.search_peq1
        Me.btnPesquisar.Location = New System.Drawing.Point(64, 417)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(142, 41)
        Me.btnPesquisar.TabIndex = 16
        Me.btnPesquisar.Text = "&Pesquisar"
        Me.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'btnLimpar
        '
        Me.btnLimpar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpar.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnLimpar.Image = Global.NovaSiao.My.Resources.Resources.limpar_24x24
        Me.btnLimpar.Location = New System.Drawing.Point(212, 417)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(142, 41)
        Me.btnLimpar.TabIndex = 17
        Me.btnLimpar.Text = "&Limpar"
        Me.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Autor"
        '
        'txtAutor
        '
        Me.txtAutor.Location = New System.Drawing.Point(175, 155)
        Me.txtAutor.Name = "txtAutor"
        Me.txtAutor.Size = New System.Drawing.Size(325, 27)
        Me.txtAutor.TabIndex = 5
        '
        'cmbMovimento
        '
        Me.cmbMovimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMovimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMovimento.FormattingEnabled = True
        Me.cmbMovimento.Location = New System.Drawing.Point(175, 360)
        Me.cmbMovimento.Name = "cmbMovimento"
        Me.cmbMovimento.RestrictContentToListItems = True
        Me.cmbMovimento.Size = New System.Drawing.Size(199, 27)
        Me.cmbMovimento.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 363)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Movimento"
        '
        'pnlAtivas
        '
        Me.pnlAtivas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAtivas.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.pnlAtivas.Controls.Add(Me.rbtInativas)
        Me.pnlAtivas.Controls.Add(Me.rbtTodos)
        Me.pnlAtivas.Controls.Add(Me.rbtAtivas)
        Me.pnlAtivas.Location = New System.Drawing.Point(12, 61)
        Me.pnlAtivas.Name = "pnlAtivas"
        Me.pnlAtivas.Size = New System.Drawing.Size(488, 39)
        Me.pnlAtivas.TabIndex = 1
        '
        'rbtInativas
        '
        Me.rbtInativas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtInativas.AutoSize = True
        Me.rbtInativas.Location = New System.Drawing.Point(223, 7)
        Me.rbtInativas.Name = "rbtInativas"
        Me.rbtInativas.Size = New System.Drawing.Size(78, 23)
        Me.rbtInativas.TabIndex = 1
        Me.rbtInativas.Tag = "2"
        Me.rbtInativas.Text = "Inativos"
        Me.rbtInativas.UseVisualStyleBackColor = True
        '
        'rbtTodos
        '
        Me.rbtTodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtTodos.AutoSize = True
        Me.rbtTodos.Location = New System.Drawing.Point(317, 7)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(65, 23)
        Me.rbtTodos.TabIndex = 2
        Me.rbtTodos.Tag = "3"
        Me.rbtTodos.Text = "Todos"
        Me.rbtTodos.UseVisualStyleBackColor = True
        '
        'rbtAtivas
        '
        Me.rbtAtivas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtAtivas.AutoSize = True
        Me.rbtAtivas.Checked = True
        Me.rbtAtivas.Location = New System.Drawing.Point(136, 7)
        Me.rbtAtivas.Name = "rbtAtivas"
        Me.rbtAtivas.Size = New System.Drawing.Size(67, 23)
        Me.rbtAtivas.TabIndex = 0
        Me.rbtAtivas.TabStop = True
        Me.rbtAtivas.Tag = "1"
        Me.rbtAtivas.Text = "Ativos"
        Me.rbtAtivas.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Brown
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.Location = New System.Drawing.Point(360, 417)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(142, 41)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmProdutoListagemFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(514, 470)
        Me.Controls.Add(Me.cmbMovimento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlAtivas)
        Me.Controls.Add(Me.txtFabricante)
        Me.Controls.Add(Me.txtProdutoCategoria)
        Me.Controls.Add(Me.txtProdutoSubTipo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtProduto)
        Me.Controls.Add(Me.txtProdutoTipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAutor)
        Me.KeyPreview = True
        Me.Name = "frmProdutoListagemFiltro"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.txtAutor, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnLimpar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnPesquisar, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtProdutoTipo, 0)
        Me.Controls.SetChildIndex(Me.txtProduto, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtProdutoSubTipo, 0)
        Me.Controls.SetChildIndex(Me.txtProdutoCategoria, 0)
        Me.Controls.SetChildIndex(Me.txtFabricante, 0)
        Me.Controls.SetChildIndex(Me.pnlAtivas, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbMovimento, 0)
        Me.Panel1.ResumeLayout(False)
        Me.pnlAtivas.ResumeLayout(False)
        Me.pnlAtivas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFabricante As TextBox
    Friend WithEvents txtProdutoCategoria As TextBox
    Friend WithEvents txtProdutoSubTipo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProduto As TextBox
    Friend WithEvents txtProdutoTipo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents btnLimpar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAutor As TextBox
    Friend WithEvents cmbMovimento As Controles.ComboBox_OnlyValues
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlAtivas As Panel
    Friend WithEvents rbtInativas As RadioButton
    Friend WithEvents rbtTodos As RadioButton
    Friend WithEvents rbtAtivas As RadioButton
    Friend WithEvents btnCancelar As Button
End Class
