Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

Public Class ValidaXML
    '
    Private _validaXML As Boolean = True
    '
    Public Function ValidaXML(arquivoXML As String, arquivoXSD As String) As Boolean
        '
        _validaXML = True
        '
        If Not arquivoXML = String.Empty And Not arquivoXSD = String.Empty Then
            '
            '--- verifica a existencia do arquivo XML e XSD
            If File.Exists(arquivoXML) = False OrElse File.Exists(arquivoXSD) = False Then
                MessageBox.Show("Arquivo XML ou XSD não foram encontrados...", "Valida XML", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            '
            Dim settings As XmlReaderSettings = New XmlReaderSettings()
            settings.Schemas.Add("", arquivoXSD)
            settings.ValidationType = ValidationType.Schema
            AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
            '
            Using reader As XmlReader = XmlReader.Create(arquivoXML, settings)
                ' Parse the file. 
                While reader.Read()
                End While
                '
            End Using
            '
            '--- devolve o resultado
            Return _validaXML
            '
        Else
            MessageBox.Show("Informe o arquivo XML e o arquivo XSD.", "Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        '
    End Function
    '
    ' Display any warnings or errors.
    Private Sub ValidationCallBack(sender As Object, args As ValidationEventArgs)
        '
        If (args.Severity = XmlSeverityType.Warning) Then
            MessageBox.Show("CUIDADO: Não foi encontrado um Schema válido. A validação não ocorreu." & vbNewLine & args.Message, "Validação XML", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("ERRO de Validação: " & vbNewLine & args.Message, "Validação XML", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        '
        _validaXML = False
        '
    End Sub
    '
End Class
