Imports System.ComponentModel
Public Class clCompra : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure CompraStruc ' alguns usam FRIEND em vez de DIM
        '
        ' TBLTRANSACAO =====================================================
        Dim _IDCompra As Integer?
        Dim _IDPessoaDestino As Integer
        ' Cadastro As String
        ' CNP As String
        ' UF As String
        ' Cidade As String
        Dim _IDPessoaOrigem As Integer
        Dim _IDOperacao As Byte
        Dim _IDSituacao As Byte
        Dim _IDUser As Integer
        Dim _CFOP As Int16
        Dim _TransacaoData As Date
        '
        ' TBLCOMPRA =====================================================
        Dim _CobrancaTipo As Byte 'tinyint ==> 0 = SemCobrança | 1 = A Vista | 2 = Parcelada
        ' CobrancaTipoTexto As String
        Dim _FreteTipo As Byte ' 0="Sem Frete" | 1="Emitente" | 2="Destinatário" | 3=Reembolso | 4="A Cobrar"
        Dim _FreteCobrado As Decimal
        Dim _ICMSValor As Decimal
        Dim _Despesas As Decimal
        Dim _Descontos As Decimal
        Dim _TotalCompra As Decimal
        Dim _Observacao As String
        '
        ' TBLFRETE =====================================================
        Dim _IDTransportadora As Integer?
        ' Transportadora As String
        Dim _FreteValor As Decimal?
        Dim _Volumes As Int16?
        Dim _IDAPagar As Integer?
        '
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private CData As CompraStruc
    Private backupData As CompraStruc
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        CData = New CompraStruc()
        With CData
            ._IDCompra = Nothing
            ._TransacaoData = DateTime.Today
            ._CobrancaTipo = 0 'tinyint
            ._IDSituacao = 0
            ._FreteTipo = 0
            ._TotalCompra = 0
            ._FreteCobrado = 0
            ._ICMSValor = 0
            ._Descontos = 0
            ._Despesas = 0
            ._CobrancaTipo = 0 ' 0 = SemCobrança | 1 = A Vista | 2 = Parcelada
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = CData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.CData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New CompraStruc()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public Overrides Function ToString() As String
        Return IDCompra.ToString
    End Function
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
    '===========================================================================================
    '--- TBLTRANSACAO
    '===========================================================================================
    '
    Property IDCompra() As Nullable(Of Integer)
        Get
            Return CData._IDCompra
        End Get
        Set(value As Nullable(Of Integer))
            CData._IDCompra = value
        End Set
    End Property
    '
    Property IDPessoaDestino() As Integer
        Get
            Return CData._IDPessoaDestino
        End Get
        Set(value As Integer)
            If Not IsNothing(CData._IDPessoaDestino) AndAlso value <> CData._IDPessoaDestino Then
                RaiseEvent AoAlterar()
            End If
            CData._IDPessoaDestino = value
        End Set
    End Property
    '
    '--- PROPRIEDADES SOMENTE LEITURA
    Public Property Cadastro
    Public Property CNP
    Public Property Cidade
    Public Property UF
    Public Property ApelidoFilial
    '
    '--- Propriedade IDPessoaOrigem
    Public Property IDPessoaOrigem() As Integer?
        Get
            Return CData._IDPessoaOrigem
        End Get
        Set(ByVal value As Integer?)
            If value <> CData._IDPessoaOrigem Then
                RaiseEvent AoAlterar()
            End If
            CData._IDPessoaOrigem = value
        End Set
    End Property
    '
    '--- Propriedade IDOperacao
    Public Property IDOperacao() As Byte
        Get
            Return CData._IDOperacao
        End Get
        Set(ByVal value As Byte)
            If value <> CData._IDOperacao Then
                RaiseEvent AoAlterar()
            End If
            CData._IDOperacao = value
        End Set
    End Property
    '
    Property IDSituacao() As Byte
        Get
            Return CData._IDSituacao
        End Get
        Set(value As Byte)
            If Not IsNothing(CData._IDSituacao) AndAlso value <> CData._IDSituacao Then
                RaiseEvent AoAlterar()
            End If
            CData._IDSituacao = value
        End Set
    End Property
    '
    Property Situacao As String ' texto da Situacao da Venda
    '
    Property IDUser() As Integer
        Get
            Return CData._IDUser
        End Get
        Set(value As Integer)
            If Not IsNothing(CData._IDUser) AndAlso value <> CData._IDUser Then
                RaiseEvent AoAlterar()
            End If
            CData._IDUser = value
        End Set
    End Property
    '
    Property CFOP() As Int16
        Get
            Return CData._CFOP
        End Get
        Set(value As Int16)
            If Not IsNothing(CData._CFOP) AndAlso value <> CData._CFOP Then
                RaiseEvent AoAlterar()
            End If
            CData._CFOP = value
        End Set
    End Property
    '
    Property TransacaoData() As Date
        Get
            Return CData._TransacaoData
        End Get
        Set(value As Date)
            If Not IsNothing(CData._TransacaoData) AndAlso value <> CData._TransacaoData Then
                RaiseEvent AoAlterar()
            End If
            CData._TransacaoData = value
        End Set
    End Property
    '
    '===========================================================================================
    '--- TBLVENDA
    '===========================================================================================
    '
    Property CobrancaTipo() As Byte
        Get
            Return CData._CobrancaTipo
        End Get
        Set(value As Byte)
            If Not IsNothing(CData._CobrancaTipo) AndAlso value <> CData._CobrancaTipo Then
                RaiseEvent AoAlterar()
            End If
            CData._CobrancaTipo = value
        End Set
    End Property
    '
    Public Property CobrancaTipoTexto As String
    '
    Property FreteTipo() As Byte
        Get
            Return CData._FreteTipo
        End Get
        Set(value As Byte)
            If Not IsNothing(CData._FreteTipo) AndAlso value <> CData._FreteTipo Then
                RaiseEvent AoAlterar()
            End If
            CData._FreteTipo = value
        End Set
    End Property
    '
    '--- Propriedade FreteCobrado
    Public Property FreteCobrado() As Decimal
        Get
            Return CData._FreteCobrado
        End Get
        Set(ByVal value As Decimal)
            If value <> CData._FreteCobrado Then
                RaiseEvent AoAlterar()
            End If
            CData._FreteCobrado = value
        End Set
    End Property
    '
    '--- Propriedade ICMSValor
    Public Property ICMSValor() As Decimal
        Get
            Return CData._ICMSValor
        End Get
        Set(ByVal value As Decimal)
            If value <> CData._ICMSValor Then
                RaiseEvent AoAlterar()
            End If
            CData._ICMSValor = value
        End Set
    End Property
    '
    '--- Propriedade Despesas
    Public Property Despesas() As Decimal
        Get
            Return CData._Despesas
        End Get
        Set(ByVal value As Decimal)
            If value <> CData._Despesas Then
                RaiseEvent AoAlterar()
            End If
            CData._Despesas = value
        End Set
    End Property
    '
    '--- Propriedade Descontos
    Public Property Descontos() As Decimal
        Get
            Return CData._Descontos
        End Get
        Set(ByVal value As Decimal)
            If value <> CData._Descontos Then
                RaiseEvent AoAlterar()
            End If
            CData._Descontos = value
        End Set
    End Property
    '
    Property TotalCompra() As Decimal
        Get
            Return CData._TotalCompra
        End Get
        Set(value As Decimal)
            If Not IsNothing(CData._TotalCompra) AndAlso value <> CData._TotalCompra Then
                RaiseEvent AoAlterar()
            End If
            CData._TotalCompra = value
        End Set
    End Property
    '
    Property Observacao As String
        Get
            Return CData._Observacao
        End Get
        Set(value As String)
            If Not IsNothing(CData._Observacao) AndAlso value <> CData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            CData._Observacao = value
        End Set
    End Property
    '
    '===========================================================================================
    '--- TBLVENDAFRETE
    '===========================================================================================
    '
    '--- Propriedade IDTransportadora
    Public Property IDTransportadora() As Integer?
        Get
            Return CData._IDTransportadora
        End Get
        Set(ByVal value As Integer?)
            If Not IsNothing(CData._IDTransportadora) Then
                If value <> CData._IDTransportadora Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CData._IDTransportadora = value
        End Set
    End Property
    '
    Public Property Transportadora
    '
    '--- Propriedade FreteValor
    Public Property FreteValor() As Decimal?
        Get
            Return CData._FreteValor
        End Get
        Set(ByVal value As Decimal?)
            If Not IsNothing(CData._FreteValor) Then
                If value <> CData._FreteValor Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CData._FreteValor = value
        End Set
    End Property
    '
    '--- Propriedade Volumes
    Public Property Volumes() As Int16?
        Get
            Return CData._Volumes
        End Get
        Set(ByVal value As Int16?)
            If Not IsNothing(CData._Volumes) Then
                If value <> CData._Volumes Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CData._Volumes = value
        End Set
    End Property
    '
    '--- Propriedade IDApagar do Frete
    Public Property IDApagar() As Integer?
        Get
            Return CData._IDAPagar
        End Get
        Set(ByVal value As Integer?)
            If Not IsNothing(CData._IDAPagar) Then
                If value <> CData._IDAPagar Then
                    RaiseEvent AoAlterar()
                End If
            End If
            CData._IDAPagar = value
        End Set
    End Property
    '
#End Region
    '
End Class
