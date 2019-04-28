Imports System.ComponentModel
'
Public Enum EnumMovimentacaoOrigem
    Venda = 1           ' IDOrigem  :   tblVenda
    AReceberParcela = 2 ' IDOrigem  :   tblAReceberParcela
    Creditos = 3        ' IDOrigem  :   tblCreditos
    Devolucao = 4       ' IDOrigem  :   tblDevolucao
    APagar = 10         ' IDOrigem  :   tblAPagar
    Transferencia = 11  ' IDOrigem  :   tblTransferenciaCaixa
End Enum
'
Public Enum EnumMovimento
    Entrada = 1
    Saida = 2
    Transferencia = 3
End Enum
'
Public Class clMovimentacao : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    '
    Structure MovStructure ' alguns usam FRIEND em vez de DIM
        '
        '--- ORIGEM: qryMovimentacao
        '--------------------------------------
        Dim _IDMovimentacao As Integer
        Dim _IDOrigem As Integer
        Dim _Origem As Byte
        Dim _IDConta As Int16
        'Conta As String
        Dim _IDMovForma As Int16?
        Dim _IDMeio As Byte
        'Meio as String
        'MovForma As String
        'IDMovTipo As Int16
        'MovTipo as String
        'IDCartaoTipo as Byte?
        'Cartao As String
        Dim _MovData As Date
        Dim _MovValor As Double
        'MovValorRelativo as Double
        Dim _Creditar As Boolean
        Dim _Descricao As String
        Dim _Movimento As Byte ' 1:ENTRADA | 2:SAIDA | 3:TRANSFERENCIA
        'Mov as String
        Dim _IDCaixa As Integer?
        Dim _Observacao As String
        'IDFilial As Int
        'ApelidoFilial As String
        'IDContaPadrao  --> transferencia automatica
        'ContaPadrao
        '
    End Structure
    '
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private MData As MovStructure
    Private backupData As MovStructure
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    '
    Public Sub New()
        '
        MData = New MovStructure()
        With MData
            ._MovValor = 0
        End With
        '
    End Sub
    '
    Public Sub New(Origem As EnumMovimentacaoOrigem)
        '
        MData = New MovStructure()
        With MData
            ._MovValor = 0
            ._Origem = Origem
        End With
        '
    End Sub
    '
    Public Sub New(Origem As EnumMovimentacaoOrigem,
                   Movimento As EnumMovimento)
        '
        MData = New MovStructure()
        With MData
            ._MovValor = 0
            ._Origem = Origem
            ._Movimento = Movimento
        End With
        '
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = MData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.MData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New MovStructure()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public ReadOnly Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
    End Property
    '
#End Region
    '
#Region "PROPRIEDADES"
    '
    '--- Propriedade _IDMovimentacao
    Public Property IDMovimentacao() As Integer?
        Get
            Return MData._IDMovimentacao
        End Get
        Set(ByVal value As Integer?)
            If value <> MData._IDMovimentacao Then
                RaiseEvent AoAlterar()
            End If
            MData._IDMovimentacao = value
        End Set
    End Property
    '
    '--- Propriedade Origem
    Public Property Origem() As Byte
        Get
            Return MData._Origem
        End Get
        Set(ByVal value As Byte)
            If value <> MData._Origem Then
                RaiseEvent AoAlterar()
            End If
            MData._Origem = value
        End Set
    End Property
    '
    '--- Propriedade IDOrigem
    Public Property IDOrigem() As Integer
        Get
            Return MData._IDOrigem
        End Get
        Set(ByVal value As Integer)
            If value <> MData._IDOrigem Then
                RaiseEvent AoAlterar()
            End If
            MData._IDOrigem = value
        End Set
    End Property
    '
    '--- Propriedade IDConta
    Public Property IDConta() As Int16
        Get
            Return MData._IDConta
        End Get
        Set(ByVal value As Int16)
            If value <> MData._IDConta Then
                RaiseEvent AoAlterar()
            End If
            MData._IDConta = value
        End Set
    End Property
    '
    '--- Propriedade Conta
    '------------------------------------------------------
    Public Property Conta() As String
    '
    '--- Propriedade IDMeio
    '------------------------------------------------------
    Public Property IDMeio() As Byte
        Get
            Return MData._IDMeio
        End Get
        Set(ByVal value As Byte)
            '
            If Not value > 0 Then Throw New Exception("Meio de Pagamento inválido ou indefinido...")
            '
            If value <> MData._IDMeio Then
                RaiseEvent AoAlterar()
            End If
            MData._IDMeio = value
        End Set
    End Property
    '
    '--- Propriedade Meio
    '------------------------------------------------------
    Public Property Meio() As String
    '
    '--- Propriedade IDMovForma
    Public Property IDMovForma() As Int16?
        Get
            Return MData._IDMovForma
        End Get
        Set(ByVal value As Int16?)
            If value <> MData._IDMovForma Then
                RaiseEvent AoAlterar()
            End If
            MData._IDMovForma = value
        End Set
    End Property
    '
    '--- Propriedade MovForma
    '------------------------------------------------------
    Public Property MovForma() As String
    '
    '--- Propriedade IDMovTipo
    '------------------------------------------------------
    Public Property IDMovTipo() As Int16
    '
    '--- Propriedade MovTipo
    '------------------------------------------------------
    Public Property MovTipo() As String
    '
    '--- Propriedade IDCartaoTipo
    '------------------------------------------------------
    Public Property IDCartaoTipo() As Byte?
    '
    '--- Propriedade Cartao
    '------------------------------------------------------
    Public Property Cartao() As String
    '
    '--- Propriedade EntradaData
    Public Property MovData() As Date
        Get
            Return MData._MovData
        End Get
        Set(ByVal value As Date)
            If value <> MData._MovData Then
                RaiseEvent AoAlterar()
            End If
            MData._MovData = value
        End Set
    End Property
    '
    '--- Propriedade MovValor
    Public Property MovValor() As Double
        '
        Get
            Return MData._MovValor
        End Get
        '
        Set(ByVal value As Double)
            '
            If Math.Abs(value) <> Math.Abs(MData._MovValor) Then
                RaiseEvent AoAlterar()
            End If
            '
            '--- se for SAIDA tranforma o valor em negativo
            If MData._Movimento = 2 Then '--- SE FOR SAIDA
                MData._MovValor = If(value > 0, value * (-1), value)
            Else
                MData._MovValor = value
            End If
            '
        End Set
        '
    End Property
    '
    '--- Propriedade ValorReal
    '------------------------------------------------------
    Public ReadOnly Property MovValorReal() As Double
        '
        Get
            Return Math.Abs(MData._MovValor)
        End Get
        '
    End Property
    '
    '--- Propriedade Creditar
    Public Property Creditar() As Boolean
        Get
            Return MData._Creditar
        End Get
        Set(ByVal value As Boolean)
            If value <> MData._Creditar Then
                RaiseEvent AoAlterar()
            End If
            MData._Creditar = value
        End Set
    End Property
    '
    '--- Propriedade Descricao
    Public Property Descricao() As String
        Get
            Return MData._Descricao
        End Get
        Set(ByVal value As String)
            If value <> MData._Descricao Then
                RaiseEvent AoAlterar()
            End If
            MData._Descricao = value
        End Set
    End Property
    '
    '--- Propriedade Movimento
    '------------------------------------------------------
    Public Property Movimento() As Byte
        Get
            Return MData._Movimento
        End Get
        Set(ByVal value As Byte)
            If value <> MData._Movimento Then
                RaiseEvent AoAlterar()
            End If
            MData._Movimento = value
        End Set
    End Property
    '
    '--- Propriedade Mov
    '------------------------------------------------------
    Public Property Mov() As String
    '
    '--- Propriedade IDCaixa
    Public Property IDCaixa() As Integer?
        Get
            Return MData._IDCaixa
        End Get
        Set(ByVal value As Integer?)
            If value <> MData._IDCaixa Then
                RaiseEvent AoAlterar()
            End If
            MData._IDCaixa = value
        End Set
    End Property
    '
    '--- Propriedade Observacao
    Public Property Observacao() As String
        Get
            Return MData._Observacao
        End Get
        Set(ByVal value As String)
            If value <> MData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            MData._Observacao = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    '------------------------------------------------------
    Public Property IDFilial() As Integer
    '
    '--- Propriedade Filial
    '------------------------------------------------------
    Public Property ApelidoFilial() As String
    '
    '--- Propriedade IDContaPadrao --> Transf automatica
    '------------------------------------------------------
    Public Property IDContaPadrao() As Int16?
    Public Property ContaPadrao() As String
    '
#End Region
    '
End Class
