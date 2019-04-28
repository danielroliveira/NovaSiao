Module DialogModal

    Function abrirDialog(message As String, title As String, type As frmDialog.DialogType) As DialogResult
        Dim f As New frmDialog(frmDialog.DialogType.SIM_NAO)

        f.ShowDialog()

        Return f.DialogResult

    End Function

End Module
