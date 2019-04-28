<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdutoAlterarEstMinimoIdeal
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
        Me.txtEstoqueIdeal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEstoqueMinimo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblB = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(416, 50)
        '
        'lblTitulo
        '
        Me.lblTitulo.Location = New System.Drawing.Point(154, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(262, 50)
        Me.lblTitulo.Text = "Escolher Novos Valores"
        '
        'txtEstoqueIdeal
        '
        Me.txtEstoqueIdeal.Location = New System.Drawing.Point(162, 101)
        Me.txtEstoqueIdeal.Name = "txtEstoqueIdeal"
        Me.txtEstoqueIdeal.Size = New System.Drawing.Size(199, 27)
        Me.txtEstoqueIdeal.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Estoque Ideal"
        '
        'txtEstoqueMinimo
        '
        Me.txtEstoqueMinimo.ForeColor = System.Drawing.Color.Black
        Me.txtEstoqueMinimo.Location = New System.Drawing.Point(162, 68)
        Me.txtEstoqueMinimo.Name = "txtEstoqueMinimo"
        Me.txtEstoqueMinimo.Size = New System.Drawing.Size(199, 27)
        Me.txtEstoqueMinimo.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(42, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 19)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Estoque Mínimo"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.block
        Me.btnCancelar.Location = New System.Drawing.Point(203, 159)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 41)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAlterar
        '
        Me.btnAlterar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAlterar.FlatAppearance.BorderSize = 0
        Me.btnAlterar.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnAlterar.Location = New System.Drawing.Point(62, 159)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(135, 41)
        Me.btnAlterar.TabIndex = 17
        Me.btnAlterar.Text = "&Alterar"
        Me.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.BackColor = System.Drawing.Color.White
        Me.lblA.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblA.ForeColor = System.Drawing.Color.DarkGray
        Me.lblA.Location = New System.Drawing.Point(199, 71)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(158, 19)
        Me.lblA.TabIndex = 19
        Me.lblA.Text = "MANTER QDE ATUAL..."
        '
        'lblB
        '
        Me.lblB.AutoSize = True
        Me.lblB.BackColor = System.Drawing.Color.White
        Me.lblB.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB.ForeColor = System.Drawing.Color.DarkGray
        Me.lblB.Location = New System.Drawing.Point(199, 104)
        Me.lblB.Name = "lblB"
        Me.lblB.Size = New System.Drawing.Size(158, 19)
        Me.lblB.TabIndex = 19
        Me.lblB.Text = "MANTER QDE ATUAL..."
        '
        'frmProdutoAlterarEstMinimoIdeal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(416, 221)
        Me.Controls.Add(Me.lblB)
        Me.Controls.Add(Me.lblA)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAlterar)
        Me.Controls.Add(Me.txtEstoqueIdeal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEstoqueMinimo)
        Me.Controls.Add(Me.Label12)
        Me.KeyPreview = True
        Me.Name = "frmProdutoAlterarEstMinimoIdeal"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txtEstoqueMinimo, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtEstoqueIdeal, 0)
        Me.Controls.SetChildIndex(Me.btnAlterar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.lblA, 0)
        Me.Controls.SetChildIndex(Me.lblB, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEstoqueIdeal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEstoqueMinimo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAlterar As Button
    Friend WithEvents lblA As Label
    Friend WithEvents lblB As Label
End Class
