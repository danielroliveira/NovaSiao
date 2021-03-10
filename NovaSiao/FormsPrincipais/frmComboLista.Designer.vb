<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComboLista
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
		Me.lstItens = New ComponentOwl.BetterListView.BetterListView()
		Me.clnID = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
		Me.clnItem = New ComponentOwl.BetterListView.BetterListViewColumnHeader()
		CType(Me.lstItens, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'lstItens
		'
		Me.lstItens.Activation = System.Windows.Forms.ItemActivation.OneClick
		Me.lstItens.BackColor = System.Drawing.Color.AntiqueWhite
		Me.lstItens.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lstItens.Columns.Add(Me.clnID)
		Me.lstItens.Columns.Add(Me.clnItem)
		Me.lstItens.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstItens.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.None
		Me.lstItens.HScrollBarDisplayMode = ComponentOwl.BetterListView.BetterListViewScrollBarDisplayMode.Hide
		Me.lstItens.Location = New System.Drawing.Point(1, 2)
		Me.lstItens.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
		Me.lstItens.Name = "lstItens"
		Me.lstItens.ShowGroupExpandButtons = False
		Me.lstItens.Size = New System.Drawing.Size(247, 46)
		Me.lstItens.TabIndex = 1
		Me.lstItens.VScrollBarDisplayMode = ComponentOwl.BetterListView.BetterListViewScrollBarDisplayMode.Hide
		'
		'clnID
		'
		Me.clnID.Name = "clnID"
		Me.clnID.Text = "ID"
		Me.clnID.Width = 40
		'
		'clnItem
		'
		Me.clnItem.Name = "clnItem"
		Me.clnItem.Text = "Item"
		Me.clnItem.Width = 200
		'
		'frmComboLista
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.LightSlateGray
		Me.ClientSize = New System.Drawing.Size(249, 50)
		Me.Controls.Add(Me.lstItens)
		Me.Font = New System.Drawing.Font("Verdana", 12.0!)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.KeyPreview = True
		Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
		Me.Name = "frmComboLista"
		Me.Padding = New System.Windows.Forms.Padding(1, 2, 1, 2)
		Me.Text = "frmComboLista"
		Me.TopMost = True
		CType(Me.lstItens, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Private WithEvents lstItens As ComponentOwl.BetterListView.BetterListView
	Private WithEvents clnID As ComponentOwl.BetterListView.BetterListViewColumnHeader
	Private WithEvents clnItem As ComponentOwl.BetterListView.BetterListViewColumnHeader
End Class
