<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAPagarQuitarAlteraValor
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnInserir = New System.Windows.Forms.Button()
        Me.btnDescartar = New System.Windows.Forms.Button()
        Me.lblTextoPrincipal = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnAlterar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnInserir, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDescartar, 0, 1)
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(41, 142)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(275, 131)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnAlterar
        '
        Me.btnAlterar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnAlterar.Location = New System.Drawing.Point(4, 47)
        Me.btnAlterar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(267, 34)
        Me.btnAlterar.TabIndex = 1
        Me.btnAlterar.Text = "Alterar o Valor da Despesa"
        Me.btnAlterar.UseVisualStyleBackColor = False
        '
        'btnInserir
        '
        Me.btnInserir.BackColor = System.Drawing.Color.AliceBlue
        Me.btnInserir.Location = New System.Drawing.Point(4, 4)
        Me.btnInserir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInserir.Name = "btnInserir"
        Me.btnInserir.Size = New System.Drawing.Size(267, 34)
        Me.btnInserir.TabIndex = 0
        Me.btnInserir.Text = "Inserir no Acréscimo"
        Me.btnInserir.UseVisualStyleBackColor = False
        '
        'btnDescartar
        '
        Me.btnDescartar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnDescartar.Location = New System.Drawing.Point(4, 90)
        Me.btnDescartar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDescartar.Name = "btnDescartar"
        Me.btnDescartar.Size = New System.Drawing.Size(267, 34)
        Me.btnDescartar.TabIndex = 2
        Me.btnDescartar.Text = "Descartar a Diferença"
        Me.btnDescartar.UseVisualStyleBackColor = False
        '
        'lblTextoPrincipal
        '
        Me.lblTextoPrincipal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTextoPrincipal.Location = New System.Drawing.Point(12, 9)
        Me.lblTextoPrincipal.Name = "lblTextoPrincipal"
        Me.lblTextoPrincipal.Size = New System.Drawing.Size(333, 121)
        Me.lblTextoPrincipal.TabIndex = 0
        Me.lblTextoPrincipal.Text = "O valor que você inseriu é maior que o valor do A Pagar que está em aberto"
        '
        'dlgAPagarQuitarAlteraValor
        '
        Me.AcceptButton = Me.btnInserir
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnDescartar
        Me.ClientSize = New System.Drawing.Size(357, 294)
        Me.Controls.Add(Me.lblTextoPrincipal)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAPagarQuitarAlteraValor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Acréscimo / Altera Valor"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnInserir As System.Windows.Forms.Button
    Friend WithEvents btnDescartar As System.Windows.Forms.Button
    Friend WithEvents lblTextoPrincipal As Label
    Friend WithEvents btnAlterar As Button
End Class
