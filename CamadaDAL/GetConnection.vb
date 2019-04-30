Imports System.Xml

Public Class GetConnection
    '
    Public Function LoadConnectionString(SourceXMLFile As String, stringName As String) As String
        '
        Dim doc As New XmlDocument()
        '
        '--- Try open XML document
        Try
            doc.Load(SourceXMLFile)
        Catch ex As Exception
            '
            Throw New Exception("Uma exceção ocorreu ao Ler o arquivo XML..." &
                                vbNewLine &
                                ex.Message)
            '
        End Try
        '
        For Each node As XmlNode In doc.GetElementsByTagName("setting")
            If node.Attributes().ItemOf("name").InnerText = stringName Then
                Return node.SelectSingleNode("value").InnerText
            End If
        Next
        '
        Return Nothing
        '
    End Function
    '
    Public Function SaveConnectionStringLocation(SourceXMLFile As String, stringName As String) As Boolean
        '
        Try
            My.MySettings.Default.ConexaoStringFile = SourceXMLFile
            My.MySettings.Default.ConexaoStringName = stringName
            My.MySettings.Default.Save()
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
    End Function
    '
End Class
