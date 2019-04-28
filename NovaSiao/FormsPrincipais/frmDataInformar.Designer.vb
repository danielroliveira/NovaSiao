<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataInformar
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
        Me.dtpDateInfo = New System.Windows.Forms.DateTimePicker()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(405, 40)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(216, 3)
        Me.lblTitulo.Size = New System.Drawing.Size(187, 32)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Informe a Data"
        '
        'dtpDateInfo
        '
        Me.dtpDateInfo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateInfo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateInfo.Location = New System.Drawing.Point(124, 109)
        Me.dtpDateInfo.Name = "dtpDateInfo"
        Me.dtpDateInfo.Size = New System.Drawing.Size(155, 31)
        Me.dtpDateInfo.TabIndex = 2
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitulo.Location = New System.Drawing.Point(12, 56)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(381, 43)
        Me.lblSubTitulo.TabIndex = 1
        Me.lblSubTitulo.Text = "Informe a Data"
        Me.lblSubTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnOK.Location = New System.Drawing.Point(55, 165)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(140, 41)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "&OK"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_24x24
        Me.btnCancelar.Location = New System.Drawing.Point(201, 165)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(140, 41)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmDataInformar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(405, 219)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblSubTitulo)
        Me.Controls.Add(Me.dtpDateInfo)
        Me.Name = "frmDataInformar"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dtpDateInfo, 0)
        Me.Controls.SetChildIndex(Me.lblSubTitulo, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtpDateInfo As DateTimePicker
    Friend WithEvents lblSubTitulo As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancelar As Button
End Class
