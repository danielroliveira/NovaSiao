Imports ComponentOwl.BetterListView

Public Class frmComboLista

	Private _origemLista As New Dictionary(Of Integer, String)
	Public Property propEscolha() As KeyValuePair(Of Integer, String)

	'SUB NEW | CONSTRUCTOR
	'------------------------------------------------------------------------------------------------------------
	Sub New(OrigemLista As Dictionary(Of Integer, String), SourceControl As TextBox, Optional DefaultID As Integer? = Nothing)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		StartPosition = FormStartPosition.Manual
		Dim point As Point = SourceControl.PointToScreen(Point.Empty)
		Location = New Point(point.X - 2, point.Y + SourceControl.Height)
		If OrigemLista.Count = 0 Then Return
		_origemLista = OrigemLista

		PreencheLista()

		Height = OrigemLista.Count * 29
		Width = SourceControl.Width
		lstItens.Width = SourceControl.Width
		clnItem.Width = SourceControl.Width - clnID.Width

		'--- HANDLERS
		AddHandler lstItens.ItemActivate, AddressOf ReturnSelectedItem
		AddHandler lstItens.PreviewKeyDown, AddressOf item_PreviewKeyDown
		AddHandler Me.PreviewKeyDown, AddressOf item_PreviewKeyDown

		'--- SELECT DEFAULT ID
		FindSelectDefautID(DefaultID)

	End Sub

	'SHOW - CLOSE IF ITEMS = 0
	'------------------------------------------------------------------------------------------------------------
	Private Sub frmComboLista_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

		'--- CHECK IF EXISTS ITEMS
		If _origemLista.Count = 0 Then
			Close()
		End If

	End Sub

	Private Sub ReturnSelectedItem()

		If lstItens.SelectedItems.Count = 0 Then Exit Sub

		Dim ID As Integer = lstItens.SelectedItems(0).Text
		Dim value As String = lstItens.SelectedItems(0).SubItems(1).Text
		propEscolha = New KeyValuePair(Of Integer, String)(ID, value)

		DialogResult = DialogResult.OK

	End Sub

	Public Sub PreencheLista()
		lstItens.MultiSelect = False
		lstItens.HideSelection = False
		clnID.Width = 22
		clnItem.Width = Width - clnID.Width - 30

		For Each item In _origemLista
			Dim vItem As BetterListViewItem = New BetterListViewItem(New String() {item.Key.ToString(), item.Value})
			vItem.UseItemStyleForSubItems = False
			vItem.SubItems(0).Font = New Font("Calibri", 7.0F, FontStyle.Regular, GraphicsUnit.Point, (CByte((0))))
			vItem.SubItems(0).BackColor = Color.LightSteelBlue
			vItem.SubItems(1).Font = New Font("Calibri", 12.0F, FontStyle.Regular, GraphicsUnit.Point, (CByte((0))))
			lstItens.Items.Add(vItem)
		Next

	End Sub


	Private Sub FindSelectDefautID(DefaultID As Integer?)

		If DefaultID IsNot Nothing Then

			For Each item As BetterListViewItem In lstItens

				If Convert.ToInt32(item.Text) = DefaultID Then
					item.Selected = True
				Else
					item.Selected = False
				End If
			Next
		Else

			If lstItens.Items.Count > 0 Then
				lstItens.Items(0).Selected = True
			End If
		End If

	End Sub


	Private Sub frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

		If e.KeyCode = Keys.Escape Then
			e.Handled = True
			DialogResult = DialogResult.Cancel

		ElseIf e.KeyCode = Keys.Up Then
			e.Handled = True
			If lstItens.Items.Count = 0 Then Return

			If lstItens.SelectedItems.Count > 0 Then
				Dim i As Integer = lstItens.SelectedItems(0).Index
				lstItens.Items(i).Selected = False

				If i = 0 Then
					lstItens.Items(lstItens.Items.Count - 1).Selected = True
				Else
					lstItens.Items(i - 1).Selected = True
				End If
			Else
				lstItens.Items(0).Selected = True
			End If

			lstItens.EnsureVisible(lstItens.SelectedItems(0))

		ElseIf e.KeyCode = Keys.Down Then
			e.Handled = True

			If lstItens.Items.Count > 0 Then

				If lstItens.SelectedItems.Count > 0 Then
					Dim i As Integer = lstItens.SelectedItems(0).Index
					lstItens.Items(i).Selected = False
					If i = lstItens.Items.Count - 1 Then i = -1
					lstItens.Items(i + 1).Selected = True
				Else
					lstItens.Items(0).Selected = True
				End If

				lstItens.EnsureVisible(lstItens.SelectedItems(0))
			End If

		ElseIf e.KeyCode = Keys.[Return] Then
			ReturnSelectedItem()
		End If

	End Sub

	Private Sub frmComboLista_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
		'
		If Char.IsNumber(e.KeyChar) Then

			For Each item As BetterListViewItem In lstItens

				If Integer.Parse(item.Text) = Integer.Parse(e.KeyChar.ToString()) Then
					item.Selected = True
					ReturnSelectedItem()
				Else
					item.Selected = False
				End If
			Next

			e.Handled = True

		ElseIf Char.IsLetter(e.KeyChar) Then
			e.Handled = True
		End If
		'
	End Sub

	Private Sub item_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles lstItens.PreviewKeyDown
		e.IsInputKey = True
	End Sub

End Class