Public Class clTransferenciaCaixa
    '
    '--- PROPRIEDADES
    Property IDTransferencia As Integer
    Property IDContaCredito As Int16
    Property ContaCredito As String
    Property IDContaDebito As Int16
    Property ContaDebito As String
    Property IDFilial As Integer
    Property IDMeio As Byte
    Property Meio As String
    Property ApelidoFilial As String
    Property IDMovDebito As Integer
    Property IDMovCredito As Integer
    Property TransferenciaData As Date
    Property IDCaixa As Integer?
    Property Observacao As String
    '
    Private _TransferenciaValor As Decimal
    Private _ComissaoValor As Decimal
    '
    Property TransferenciaValor As Decimal
        '
        Get
            Return _TransferenciaValor
        End Get
        '
        Set(value As Decimal)
            '
            If value >= ComissaoValor Then
                _TransferenciaValor = value
            Else
                _TransferenciaValor = ComissaoValor
            End If
            '
        End Set
        '
    End Property
    '
    Property ComissaoValor As Decimal
        '
        Get
            Return _ComissaoValor
        End Get
        '
        Set(value As Decimal)
            '
            If value <= TransferenciaValor Then
                _ComissaoValor = value
            Else
                _ComissaoValor = TransferenciaValor
            End If
            '
        End Set
        '
    End Property
    '
    ReadOnly Property ValorReal As Decimal
        Get
            Return TransferenciaValor - ComissaoValor
        End Get
    End Property
    '
End Class
