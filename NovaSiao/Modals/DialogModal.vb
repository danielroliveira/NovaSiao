Module DialogModal

    Function AbrirDialog(message As String,
                         title As String,
                         type As frmDialog.DialogType,
                         icon As frmDialog.DialogIcon) As DialogResult
        '
        Dim f As New frmDialog(message, title, type, icon)

        f.ShowDialog()

        Return f.DialogResult

    End Function

End Module
