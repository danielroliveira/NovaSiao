'
'==========================================================================================
' APP EXCEPTION
'==========================================================================================
Public Class AppException : Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class
