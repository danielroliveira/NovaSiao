Imports System.ComponentModel
'
'========================================================================
' CLASSE PRIMARIA TRANSACAO
'========================================================================
Public MustInherit Class clTransacao
    '
    Structure TransacaoStructure
        Dim _IDTransacao As Integer?
        Dim _IDPessoaDestino As Integer
        Dim _IDPessoaOrigem As Integer
        Dim _IDOperacao As Byte
        Dim _IDSituacao As Byte
        Dim _IDUser As Integer
        Dim _CFOP As Int16
        Dim _TransacaoData As Date
        '
        '-------------------------------
        ' PROP PessoaOrigem As String
        ' PROP PessoaDestino As String
        ' PROP Situacao As String
        ' PROP Operacao As String
        '-------------------------------
        '
    End Structure
    '
    Friend TData As TransacaoStructure
    Friend TData_Backup As TransacaoStructure
    Friend inTxn As Boolean = False
    '
    Public Event AoAlterar()
    '
    '--- Propriedade Generica
    Public Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
        Set(value As Boolean)
            inTxn = value
        End Set
    End Property
    '
    '--- Propriedade que Aciona o evento AoAlterar
    Public Sub RaiseAoAlterar()
        RaiseEvent AoAlterar()
    End Sub
    '
    '--- Propriedade IDTransacao
    '------------------------------------------------------
    Public Property IDTransacao() As Integer
        Get
            Return TData._IDTransacao
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDTransacao Then
                RaiseEvent AoAlterar()
            End If
            TData._IDTransacao = value
        End Set
    End Property
    '
    '--- Propriedade IDPessoaDestino
    '------------------------------------------------------
    Public Property IDPessoaDestino() As Integer
        Get
            Return TData._IDPessoaDestino
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDPessoaDestino Then
                RaiseEvent AoAlterar()
            End If
            TData._IDPessoaDestino = value
        End Set
    End Property
    '
    '--- Propriedade IDPessoaOrigem
    '------------------------------------------------------
    Public Property IDPessoaOrigem() As Integer
        Get
            Return TData._IDPessoaOrigem
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDPessoaOrigem Then
                RaiseEvent AoAlterar()
            End If
            TData._IDPessoaOrigem = value
        End Set
    End Property
    '
    '--- Propriedade IDOperacao
    '------------------------------------------------------
    Public Property IDOperacao() As Integer
        Get
            Return TData._IDOperacao
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDOperacao Then
                RaiseEvent AoAlterar()
            End If
            TData._IDOperacao = value
        End Set
    End Property
    '
    '--- Propriedade IDSituacao
    '------------------------------------------------------
    Public Property IDSituacao() As Integer
        Get
            Return TData._IDSituacao
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDSituacao Then
                RaiseEvent AoAlterar()
            End If
            TData._IDSituacao = value
        End Set
    End Property
    '
    '--- Propriedade IDUser
    '------------------------------------------------------
    Public Property IDUser() As Integer
        Get
            Return TData._IDUser
        End Get
        Set(ByVal value As Integer)
            If value <> TData._IDUser Then
                RaiseEvent AoAlterar()
            End If
            TData._IDUser = value
        End Set
    End Property
    '
    '--- Propriedade CFOP
    '------------------------------------------------------
    Public Property CFOP() As Int16
        Get
            Return TData._CFOP
        End Get
        Set(ByVal value As Int16)
            If value <> TData._CFOP Then
                RaiseEvent AoAlterar()
            End If
            TData._CFOP = value
        End Set
    End Property
    '
    '--- Propriedade TransacaoData
    '------------------------------------------------------
    Public Property TransacaoData() As Date
        Get
            Return TData._TransacaoData
        End Get
        Set(ByVal value As Date)
            If value <> TData._TransacaoData Then
                RaiseEvent AoAlterar()
            End If
            TData._TransacaoData = value
        End Set
    End Property
    '
    '------------------------------------------------------
    ' PROPRIEDADES DE OUTRAS FONTES
    '------------------------------------------------------
    Property PessoaOrigem As String
    Property PessoaDestino As String
    Property Situacao As String
    Property Operacao As String
    '
End Class
'
'
'========================================================================
' CLASSE INTERMEDIARIA - SIMPLES (HERDA TRANSACAO)
'========================================================================
Public Class clSimples
    Inherits clTransacao
    '
    Structure SimplesStructure
        '
        Dim _ValorTotal As Decimal
        Dim _Observacao As String
        '
        ' PROP Movimento As String
        '
    End Structure
    '
    Friend SData As SimplesStructure
    Friend SData_Backup As SimplesStructure
    '
    '--- Propriedade ValorTotal
    '------------------------------------------------------
    Public Property ValorTotal() As Decimal
        Get
            Return SData._ValorTotal
        End Get
        Set(ByVal value As Decimal)
            If value <> SData._ValorTotal Then
                RaiseAoAlterar()
            End If
            SData._ValorTotal = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    '------------------------------------------------------
    Public Property Observacao() As String
        Get
            Return SData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> SData._Observacao Then
                RaiseAoAlterar()
            End If
            SData._Observacao = value
        End Set
    End Property
    '
End Class
'
'========================================================================
' CLASSE FIM - SIMPLES_SAIDA (HERDA SIMPLES)
'========================================================================
Public Class clSimplesSaida
    Inherits clSimples
    Implements IEditableObject
    '
    Structure SimplesSaidaStructure
        'tblSimplesSaida =================================================
        Dim _ArquivoGerado As Boolean
        Dim _ArquivoRecebido As Boolean
        '
        'tblAReceber =====================================================
        Dim _IDAReceber As Integer?
        Dim _SituacaoAReceber As Byte '--- 0:EmAberto | 1:Pago | 2:Cancelada
        Dim _ValorPagoTotal As Decimal
        Dim _IDCobrancaForma As Int16? 'smallint
        Dim _IDPlano As Int16?
        '
    End Structure
    '
    Friend SSaidaData As SimplesSaidaStructure
    Friend SSaidaData_Backup As SimplesSaidaStructure
    '
    Sub New()
        '
        SSaidaData = New SimplesSaidaStructure With {
            ._ValorPagoTotal = 0,
            ._IDCobrancaForma = 1,
            ._ArquivoGerado = False,
            ._ArquivoRecebido = False
        }
        '
        ' herdado de clTransacao
        TData = New TransacaoStructure With {
            ._IDSituacao = 1
        }
        '
        ' herdado de clSimples
        SData = New SimplesStructure With {
            ._ValorTotal = 0
        }
        '
    End Sub
    '
    Public Overridable Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            '--- reserva os dados para recuperacao futura
            TData_Backup = TData
            SData_Backup = SData
            SSaidaData_Backup = SSaidaData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overridable Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            TData_Backup = New TransacaoStructure
            SData_Backup = New SimplesStructure
            SSaidaData_Backup = New SimplesSaidaStructure
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overridable Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            TData = TData_Backup
            SData = SData_Backup
            SSaidaData = SSaidaData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    '--- Propriedade ArquivoGerado
    '------------------------------------------------------
    Public Property ArquivoGerado() As Boolean
        Get
            Return SSaidaData._ArquivoGerado
        End Get
        Set(ByVal value As Boolean)
            If value <> SSaidaData._ArquivoGerado Then
                RaiseAoAlterar()
            End If
            SSaidaData._ArquivoGerado = value
        End Set
    End Property
    '
    '--- Propriedade ArquivoRecebido
    '------------------------------------------------------
    Public Property ArquivoRecebido() As Boolean
        Get
            Return SSaidaData._ArquivoRecebido
        End Get
        Set(ByVal value As Boolean)
            If value <> SSaidaData._ArquivoRecebido Then
                RaiseAoAlterar()
            End If
            SSaidaData._ArquivoRecebido = value
        End Set
    End Property
    '
    '--- Propriedade IDAReceber
    '------------------------------------------------------
    Public Property IDAReceber() As Integer?
        Get
            Return SSaidaData._IDAReceber
        End Get
        Set(ByVal value As Integer?)
            If value <> SSaidaData._IDAReceber Then
                RaiseAoAlterar()
            End If
            SSaidaData._IDAReceber = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoAReceber
    '------------------------------------------------------
    Public Property SituacaoAReceber() As Byte
        Get
            Return SSaidaData._SituacaoAReceber
        End Get
        Set(ByVal value As Byte)
            If value <> SSaidaData._SituacaoAReceber Then
                RaiseAoAlterar()
            End If
            SSaidaData._SituacaoAReceber = value
        End Set
    End Property
    '
    '--- Propriedade ValorPagoTotal
    '------------------------------------------------------
    Public Property ValorPagoTotal() As Decimal
        Get
            Return SSaidaData._ValorPagoTotal
        End Get
        Set(ByVal value As Decimal)
            If value <> SSaidaData._ValorPagoTotal Then
                RaiseAoAlterar()
            End If
            SSaidaData._ValorPagoTotal = value
        End Set
    End Property
    '
    '--- Propriedade IDCobrancaForma
    '------------------------------------------------------
    Public Property IDCobrancaForma() As Int16
        Get
            Return SSaidaData._IDCobrancaForma
        End Get
        Set(ByVal value As Int16)
            If value <> SSaidaData._IDCobrancaForma Then
                RaiseAoAlterar()
            End If
            SSaidaData._IDCobrancaForma = value
        End Set
    End Property
    '
    '--- Propriedade IDPlano
    '------------------------------------------------------
    Public Property IDPlano() As Int16?
        Get
            Return SSaidaData._IDPlano
        End Get
        Set(ByVal value As Int16?)
            If value <> SSaidaData._IDPlano Then
                RaiseAoAlterar()
            End If
            SSaidaData._IDPlano = value
        End Set
    End Property
    '
End Class
'
'========================================================================
' CLASSE FIM - SIMPLES_SAIDA (HERDA SIMPLES)
'========================================================================
Public Class clSimplesEntrada
    Inherits clSimples
    Implements IEditableObject
    '
    Structure SimplesEntradaStructure
        '
        'tblSimplesEntrada =================================================
        Dim _IDTransacaoOrigem As Integer
        Dim _EntradaData As Date
        '
    End Structure
    '
    Friend SEntradaData As SimplesEntradaStructure
    Friend SEntradaData_Backup As SimplesEntradaStructure
    '
    Sub New()
        '
        SEntradaData = New SimplesEntradaStructure
        '
        ' herdado de clTransacao
        TData = New TransacaoStructure With {
            ._IDSituacao = 1
        }
        '
        ' herdado de clSimples
        SData = New SimplesStructure With {
            ._ValorTotal = 0
        }
        '
    End Sub
    '
    Public Overridable Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            '--- reserva os dados para recuperacao futura
            TData_Backup = TData
            SData_Backup = SData
            SEntradaData_Backup = SEntradaData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overridable Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            TData_Backup = New TransacaoStructure
            SData_Backup = New SimplesStructure
            SEntradaData_Backup = New SimplesEntradaStructure
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overridable Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            TData = TData_Backup
            SData = SData_Backup
            SEntradaData = SEntradaData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    '--- Propriedade IDTransacaoOrigem
    '------------------------------------------------------
    Public Property IDTransacaoOrigem() As Integer
        Get
            Return SEntradaData._IDTransacaoOrigem
        End Get
        Set(ByVal value As Integer)
            If value <> SEntradaData._IDTransacaoOrigem Then
                RaiseAoAlterar()
            End If
            SEntradaData._IDTransacaoOrigem = value
        End Set
    End Property
    '
    '--- Propriedade EntradaData
    '------------------------------------------------------
    Public Property EntradaData() As Date
        Get
            Return SEntradaData._EntradaData
        End Get
        Set(ByVal value As Date)
            If value <> SEntradaData._EntradaData Then
                RaiseAoAlterar()
            End If
            SEntradaData._EntradaData = value
        End Set
    End Property
    '
End Class