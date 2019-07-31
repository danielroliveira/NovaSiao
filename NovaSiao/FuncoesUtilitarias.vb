Imports System.Reflection
Imports System.Text.RegularExpressions
'
Public Class Utilidades
    '
    '--------------------------------------------------------------------------------------------------------------
    '--- FUNÇAO QUE VERIFICA OS VALORES DOS CONTROLES/CAMPOS E RETORNA SE ESTA PREENCHIDO
    '--------------------------------------------------------------------------------------------------------------
    Public Function VerificaControlesForm(ByVal myControl As Control,
                                          ByVal myControlTexto As String,
                                          Optional EProvider As ErrorProvider = Nothing) As Boolean

        ' VERIFICAÇÃO
        Select Case myControl.GetType()
            Case GetType(TextBox), GetType(Controles.Text_Monetario), GetType(Controles.Text_SoNumeros)
                If Len(myControl.Text.Trim) > 0 Then
                    Return True
                End If
            Case GetType(MaskedTextBox), GetType(Controles.MaskText_Data), GetType(Controles.MaskText_Telefone)
                If CType(myControl, MaskedTextBox).MaskCompleted = True Then
                    Return True
                End If
            Case GetType(ComboBox), GetType(Controles.ComboBox_OnlyValues)
                If CType(myControl, ComboBox).SelectedIndex <> -1 Then
                    Return True
                End If
            Case GetType(DateTimePicker)
                If Not IsNothing(CType(myControl, DateTimePicker).Value) Then
                    Return True
                End If
        End Select
        '
        ' MENSAGEM E ERROR PROVIDER
        MessageBox.Show("O campo " & myControlTexto.ToUpper & " não pode ficar vazio;" & vbCrLf &
                        "Preencha esse campo antes de Salvar o registro por favor...",
                        "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If IsNothing(EProvider) Then
            Dim EP As New ErrorProvider
            EP.SetError(myControl, "Preencha o valor desse campo!")
        Else
            EProvider.SetError(myControl, "Preencha o valor desse campo!")
        End If
        '
        myControl.Focus()
        '
        Return False
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------------------------
    '--- FUNÇAO QUE VERIFICA OS DADOS DO CONTROLES/CAMPOS E RETORNA SE ESTA PREENCHIDO
    '--------------------------------------------------------------------------------------------------------------
    Public Function VerificaDadosClasse(ByVal meuControle As Control,
                                        ByVal meuControleTexto As String,
                                        ByVal minhaClasse As Object,
                                        Optional EProvider As ErrorProvider = Nothing) As Boolean
        '
        '--- GET O NOME DA PROPERTY
        Dim myPropertyName As String
        '
        If Not IsNothing(meuControle.DataBindings("text")) Then
            myPropertyName = meuControle.DataBindings("text").BindingMemberInfo.BindingField
        ElseIf Not IsNothing(meuControle.DataBindings("SelectedValue")) Then
            myPropertyName = meuControle.DataBindings("SelectedValue").BindingMemberInfo.BindingField
        ElseIf Not IsNothing(meuControle.DataBindings("Value")) Then
            myPropertyName = meuControle.DataBindings("Value").BindingMemberInfo.BindingField
        Else
            MessageBox.Show("Um erro inesperado ocorreu ao verificar os controles...", "Erro Inseperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        '
        '--- GET PROPERTY
        Dim pInfo As PropertyInfo = minhaClasse.GetType.GetProperty(myPropertyName)
        '
        '--- VERIFY PROPERTY VALUE
        If IsNothing(pInfo.GetValue(minhaClasse)) Then
            '
            '--- MENSAGEM E ERROR PROVIDER
            MessageBox.Show("O campo " & meuControleTexto.ToUpper & " não pode ficar vazio;" & vbCrLf &
                            "Preencha esse campo antes de Salvar o registro por favor...",
                            "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            '--- CONTROLA O ERROR PROVIDER
            If IsNothing(EProvider) Then
                Dim EP As New ErrorProvider
                EP.SetError(meuControle, "Preencha o valor desse campo!")
            Else
                EProvider.SetError(meuControle, "Preencha o valor desse campo!")
            End If
            '
            '--- DEVOLVE O FOCO AO CONTROLE
            meuControle.Focus()
            '
            '--- RETORNA
            Return False
            '
        Else
            '--- RETORNA
            Return True
            '
        End If
        '
    End Function
    '
    '--------------------------------------------------------------------------------------------------------------
    '--- FUNÇÃO PARA REMOVER OS ACENTOS DE UMA STRING
    '--------------------------------------------------------------------------------------------------------------
    Function removeAcentos(ByVal myTexto As String) As String
        Dim vPos As Byte

        Const vComAcento = "ÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÒÓÔÕÖÙÚÛÜàáâãäåçèéêëìíîïòóôõöùúûü"
        Const vSemAcento = "AAAAAACEEEEIIIIOOOOOUUUUaaaaaaceeeeiiiiooooouuuu"

        For i = 1 To Len(myTexto)
            vPos = InStr(1, vComAcento, Mid(myTexto, i, 1))
            If vPos > 0 Then
                Mid(myTexto, i, 1) = Mid(vSemAcento, vPos, 1)
            End If
        Next
        removeAcentos = myTexto
    End Function

    '--------------------------------------------------------------------------------------------------------------
    ' FUNÇÃO QUE CONVERTE UMA LIST NUMA DATATABLE
    ' ### ALTERADA VERSÃO 2017/03
    '--------------------------------------------------------------------------------------------------------------
    Shared Function ConverterListParaDataTable(Of T)(items As List(Of T)) As DataTable
        Try
            Dim dataTable As New DataTable(GetType(T).Name)
            'Pega todas as propriedades
            Dim Propriedades As PropertyInfo() = GetType(T).GetProperties(BindingFlags.[Public] Or BindingFlags.Instance)

            For Each _propriedade As PropertyInfo In Propriedades
                'Define os nomes das colunas como os nomes das propriedades
                dataTable.Columns.Add(_propriedade.Name)
                dataTable.Columns(_propriedade.Name).DataType = If(Nullable.GetUnderlyingType(_propriedade.PropertyType), _propriedade.PropertyType)
            Next

            For Each item As T In items
                Dim valores = New Object(Propriedades.Length - 1) {}
                For i As Integer = 0 To Propriedades.Length - 1
                    'inclui os valores das propriedades nas linhas do datatable
                    valores(i) = Propriedades(i).GetValue(item, Nothing)
                Next
                dataTable.Rows.Add(valores)
            Next
            Return dataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    '--------------------------------------------------------------------------------------------------------------
    '--- GET THE FIRST DAY OF THE MONTH
    '--------------------------------------------------------------------------------------------------------------
    Public Function FirstDayOfMonth(ByVal sourceDate As Date) As Date
        Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
    End Function
    '
    '--------------------------------------------------------------------------------------------------------------
    '--- GET THE LAST DAY OF THE MONTH
    '--------------------------------------------------------------------------------------------------------------
    Public Function LastDayOfMonth(ByVal sourceDate As Date) As Date
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Return lastDay.AddMonths(1).AddDays(-1)
    End Function
    '
    '--------------------------------------------------------------------------------------------------------------
    '--- CONVERTE A PRIMEIRA LETRA DO NOME EM MAIUSCULA
    '--------------------------------------------------------------------------------------------------------------
    Public Shared Function PrimeiraLetraMaiuscula(ByVal Nome As String) As String
        '
        '--- Get chars quantity
        If Nome.Length = 0 Then Return ""
        '
        '--- CONVERT TO LOWER FIRST
        Nome = Nome.ToLower

        Dim palavrasExcluidas As String() = {
            "de", "da", "do", "e"
        }

        Dim resposta As String = ""
        Dim palavras As String() = Nome.Split(" ")
        '
        For Each palavra In palavras
            If Not palavrasExcluidas.Contains(palavra) Then
                Dim caracteres As Char() = palavra.ToArray()
                caracteres(0) = caracteres(0).ToString.ToUpper
                palavra = String.Join("", caracteres)
            End If
            '
            resposta = resposta + " " + palavra
            '
        Next
        '
        Return resposta.Trim
        '
    End Function
    '
    '----------------------------------------------------------------------------------
    '--- CHECK IS VALID EMAIL
    '----------------------------------------------------------------------------------
    Public Shared Function EmailCheck(email As String) As Boolean
        '
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(email, pattern)
        '
        If emailAddressMatch.Success Then
            Return True
        Else
            Return False
        End If
        '
    End Function
End Class
