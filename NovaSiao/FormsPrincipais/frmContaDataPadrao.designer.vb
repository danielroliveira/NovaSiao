<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContaDataPadrao
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
        Me.btnDefinir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFilialEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.btnContaEscolher = New VIBlend.WinForms.Controls.vButton()
        Me.txtFilial = New System.Windows.Forms.TextBox()
        Me.txtConta = New System.Windows.Forms.TextBox()
        Me.btnClose = New VIBlend.WinForms.Controls.vFormButton()
        Me.calDataPadrao = New System.Windows.Forms.MonthCalendar()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDataPadrao = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDataBloqueio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Size = New System.Drawing.Size(387, 50)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Controls.SetChildIndex(Me.lblTitulo, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnClose, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.None
        Me.lblTitulo.Location = New System.Drawing.Point(36, 0)
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(316, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Definir Conta | Data Padrão"
        '
        'btnDefinir
        '
        Me.btnDefinir.Image = Global.NovaSiao.My.Resources.Resources.accept
        Me.btnDefinir.Location = New System.Drawing.Point(67, 389)
        Me.btnDefinir.Name = "btnDefinir"
        Me.btnDefinir.Size = New System.Drawing.Size(120, 48)
        Me.btnDefinir.TabIndex = 6
        Me.btnDefinir.Text = "&Definir"
        Me.btnDefinir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDefinir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDefinir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.NovaSiao.My.Resources.Resources.Fechar_30px
        Me.btnCancelar.Location = New System.Drawing.Point(197, 389)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 48)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filial Padrão:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Conta Padrão:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(63, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(254, 45)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Defina a FILIAL, a CONTA e a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DATA PADRÃO do sistema..."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnFilialEscolher
        '
        Me.btnFilialEscolher.AllowAnimations = True
        Me.btnFilialEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnFilialEscolher.Enabled = False
        Me.btnFilialEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnFilialEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilialEscolher.Location = New System.Drawing.Point(328, 112)
        Me.btnFilialEscolher.Name = "btnFilialEscolher"
        Me.btnFilialEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnFilialEscolher.RoundedCornersRadius = 0
        Me.btnFilialEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnFilialEscolher.TabIndex = 9
        Me.btnFilialEscolher.TabStop = False
        Me.btnFilialEscolher.Text = "..."
        Me.btnFilialEscolher.UseCompatibleTextRendering = True
        Me.btnFilialEscolher.UseVisualStyleBackColor = False
        Me.btnFilialEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'btnContaEscolher
        '
        Me.btnContaEscolher.AllowAnimations = True
        Me.btnContaEscolher.BackColor = System.Drawing.Color.Transparent
        Me.btnContaEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnContaEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContaEscolher.Location = New System.Drawing.Point(328, 156)
        Me.btnContaEscolher.Name = "btnContaEscolher"
        Me.btnContaEscolher.RoundedCornersMask = CType(15, Byte)
        Me.btnContaEscolher.RoundedCornersRadius = 0
        Me.btnContaEscolher.Size = New System.Drawing.Size(34, 27)
        Me.btnContaEscolher.TabIndex = 10
        Me.btnContaEscolher.TabStop = False
        Me.btnContaEscolher.Text = "..."
        Me.btnContaEscolher.UseCompatibleTextRendering = True
        Me.btnContaEscolher.UseVisualStyleBackColor = False
        Me.btnContaEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'txtFilial
        '
        Me.txtFilial.Location = New System.Drawing.Point(117, 112)
        Me.txtFilial.Name = "txtFilial"
        Me.txtFilial.Size = New System.Drawing.Size(205, 27)
        Me.txtFilial.TabIndex = 11
        '
        'txtConta
        '
        Me.txtConta.Location = New System.Drawing.Point(117, 156)
        Me.txtConta.Name = "txtConta"
        Me.txtConta.Size = New System.Drawing.Size(205, 27)
        Me.txtConta.TabIndex = 12
        '
        'btnClose
        '
        Me.btnClose.AllowAnimations = True
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BorderStyle = VIBlend.WinForms.Controls.ButtonBorderStyle.NONE
        Me.btnClose.ButtonType = VIBlend.WinForms.Controls.vFormButtonType.CloseButton
        Me.btnClose.CausesValidation = False
        Me.btnClose.Location = New System.Drawing.Point(356, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = False
        Me.btnClose.RoundedCornersMask = CType(15, Byte)
        Me.btnClose.ShowFocusRectangle = False
        Me.btnClose.Size = New System.Drawing.Size(19, 20)
        Me.btnClose.TabIndex = 8
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        Me.btnClose.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLUEBLEND
        '
        'calDataPadrao
        '
        Me.calDataPadrao.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calDataPadrao.Location = New System.Drawing.Point(6, 6)
        Me.calDataPadrao.MaxDate = New Date(2900, 1, 1, 0, 0, 0, 0)
        Me.calDataPadrao.MaxSelectionCount = 1
        Me.calDataPadrao.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.calDataPadrao.Name = "calDataPadrao"
        Me.calDataPadrao.TabIndex = 23
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblDataPadrao)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblDataBloqueio)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.calDataPadrao)
        Me.Panel2.Location = New System.Drawing.Point(12, 200)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(362, 174)
        Me.Panel2.TabIndex = 24
        '
        'lblDataPadrao
        '
        Me.lblDataPadrao.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataPadrao.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDataPadrao.Location = New System.Drawing.Point(244, 107)
        Me.lblDataPadrao.Name = "lblDataPadrao"
        Me.lblDataPadrao.Size = New System.Drawing.Size(105, 25)
        Me.lblDataPadrao.TabIndex = 25
        Me.lblDataPadrao.Text = "01/01/2019"
        Me.lblDataPadrao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(244, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Data Padrão:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDataBloqueio
        '
        Me.lblDataBloqueio.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataBloqueio.ForeColor = System.Drawing.Color.Maroon
        Me.lblDataBloqueio.Location = New System.Drawing.Point(245, 55)
        Me.lblDataBloqueio.Name = "lblDataBloqueio"
        Me.lblDataBloqueio.Size = New System.Drawing.Size(105, 25)
        Me.lblDataBloqueio.TabIndex = 25
        Me.lblDataBloqueio.Text = "01/01/2019"
        Me.lblDataBloqueio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(245, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Data de Bloqueio:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmContaDataPadrao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.ClientSize = New System.Drawing.Size(387, 449)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtConta)
        Me.Controls.Add(Me.txtFilial)
        Me.Controls.Add(Me.btnContaEscolher)
        Me.Controls.Add(Me.btnFilialEscolher)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDefinir)
        Me.Controls.Add(Me.btnCancelar)
        Me.Name = "frmContaDataPadrao"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnDefinir, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnFilialEscolher, 0)
        Me.Controls.SetChildIndex(Me.btnContaEscolher, 0)
        Me.Controls.SetChildIndex(Me.txtFilial, 0)
        Me.Controls.SetChildIndex(Me.txtConta, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDefinir As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnFilialEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents btnContaEscolher As VIBlend.WinForms.Controls.vButton
    Friend WithEvents txtFilial As TextBox
    Friend WithEvents txtConta As TextBox
    Friend WithEvents btnClose As VIBlend.WinForms.Controls.vFormButton
    Friend WithEvents calDataPadrao As MonthCalendar
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblDataPadrao As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblDataBloqueio As Label
    Friend WithEvents Label4 As Label
End Class
