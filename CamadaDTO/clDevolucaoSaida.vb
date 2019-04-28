Imports System.ComponentModel
'
Public Class clDevolucaoSaida : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure DevolucaoDados ' alguns usam FRIEND em vez de DIM
        '
        'tblTransacao =====================================================
        Dim _IDDevolucao As Integer?
        Dim _IDPessoaDestino As Integer
        Dim _IDPessoaOrigem As Integer
        Dim _IDOperacao As Byte
        Dim _IDSituacao As Byte
        Dim _IDUser As Integer
        Dim _CFOP As Int16
        Dim _TransacaoData As Date
        '--- PROPRIEDADES SOMENTE LEITURA
        'Property Cadastro
        'Property CNP
        'Property Cidade
        'Property UF
        'Property ApelidoFilial
        '
        'tblDevolucaoSaida =====================================================
        Dim _ValorProdutos As Decimal '--- Valor dos PRODUTOS vendidos
        Dim _ValorAcrescimos As Decimal '--- Valor dos ACRECIMOS a ser cobrados
        Dim _ValorDescontos As Decimal '--- Valor dos Descontos a serem desconsiderados
        Dim _TotalDevolucao As Decimal '--- Valor Total Final da devolução
        Dim _Enviada As Boolean '--- Se a devolucao já foi enviada ao fornecedor
        Dim _Creditada As Boolean '--- se a devolucao ja foi creditada em algum a pagar
        '--- PROPRIEDADES SOMENTE LEITURA
        'Property Situacao
        '
        'tblObservacao =====================================================
        Dim _Observacao As String
        '
        'tblAReceber =====================================================
        Dim _IDAReceber As Integer?
        Dim _ValorPagoTotal As Decimal
        Dim _SituacaoAReceber As Byte '--- 0:EmAberto | 1:Pago | 2:Cancelada
        '
        'tblVendaFrete =====================================================
        Dim _IDTransportadora As Integer?
        Dim _FreteValor As Decimal?
        Dim _FreteTipo As Byte
        Dim _Volumes As Int16?
        Dim _IDAPagar As Integer?
        '
    End Structure
    '
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private DevData As DevolucaoDados
    Private backupData As DevolucaoDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        DevData = New DevolucaoDados()
        With DevData
            ._IDSituacao = 0
            ._ValorProdutos = 0
            ._ValorAcrescimos = 0
            ._ValorDescontos = 0
            ._TotalDevolucao = 0
            ._SituacaoAReceber = 0
            ._ValorPagoTotal = 0
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = DevData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.DevData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New DevolucaoDados()
            inTxn = False
        End If
    End Sub
    '
    '-- EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    Public Event AoEnviadaAlterar()
    '
    Public Overrides Function ToString() As String
        Return IDDevolucao.ToString
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
    Property IDDevolucao() As Integer?
        Get
            Return DevData._IDDevolucao
        End Get
        Set(value As Integer?)
            DevData._IDDevolucao = value
        End Set
    End Property
    '
    Property IDPessoaDestino() As Integer
        Get
            Return DevData._IDPessoaDestino
        End Get
        Set(value As Integer)
            If Not IsNothing(DevData._IDPessoaDestino) AndAlso value <> DevData._IDPessoaDestino Then
                RaiseEvent AoAlterar()
            End If
            DevData._IDPessoaDestino = value
        End Set
    End Property
    '
    '--- PROPRIEDADES SOMENTE LEITURA
    Public Property Fornecedor
    Public Property Transportadora
    Public Property CNP
    Public Property Cidade
    Public Property UF
    Public Property ApelidoFilial
    '
    '--- Propriedade IDPessoaOrigem
    Public Property IDPessoaOrigem() As Integer?
        Get
            Return DevData._IDPessoaOrigem
        End Get
        Set(ByVal value As Integer?)
            If value <> DevData._IDPessoaOrigem Then
                RaiseEvent AoAlterar()
            End If
            DevData._IDPessoaOrigem = value
        End Set
    End Property
    '
    '--- Propriedade IDOperacao
    Public Property IDOperacao() As Byte
        Get
            Return DevData._IDOperacao
        End Get
        Set(ByVal value As Byte)
            If value <> DevData._IDOperacao Then
                RaiseEvent AoAlterar()
            End If
            DevData._IDOperacao = value
        End Set
    End Property
    '
    Property IDSituacao() As Byte
        Get
            Return DevData._IDSituacao
        End Get
        Set(value As Byte)
            If Not IsNothing(DevData._IDSituacao) AndAlso value <> DevData._IDSituacao Then
                RaiseEvent AoAlterar()
            End If
            DevData._IDSituacao = value
        End Set
    End Property
    '
    Property Situacao As String ' texto da Situacao da Venda
    '
    Property IDUser() As Integer
        Get
            Return DevData._IDUser
        End Get
        Set(value As Integer)
            If Not IsNothing(DevData._IDUser) AndAlso value <> DevData._IDUser Then
                RaiseEvent AoAlterar()
            End If
            DevData._IDUser = value
        End Set
    End Property
    '
    Property CFOP() As Int16
        Get
            Return DevData._CFOP
        End Get
        Set(value As Int16)
            If Not IsNothing(DevData._CFOP) AndAlso value <> DevData._CFOP Then
                RaiseEvent AoAlterar()
            End If
            DevData._CFOP = value
        End Set
    End Property
    '
    Property TransacaoData() As Date
        Get
            Return DevData._TransacaoData
        End Get
        Set(value As Date)
            If Not IsNothing(DevData._TransacaoData) AndAlso value <> DevData._TransacaoData Then
                RaiseEvent AoAlterar()
            End If
            DevData._TransacaoData = value
        End Set
    End Property
    '
    '===========================================================================================
    '--- TBLDEVOLUCAO
    '===========================================================================================
    '
    '--- Propriedade ValorProdutos
    Public Property ValorProdutos() As Decimal
        Get
            Return DevData._ValorProdutos
        End Get
        Set(ByVal value As Decimal)
            If CInt(value * 100) <> CInt(DevData._ValorProdutos * 100) Then
                RaiseEvent AoAlterar()
            End If
            DevData._ValorProdutos = value
        End Set
    End Property
    '
    '--- Propriedade ValorDescontos
    Public Property ValorDescontos() As Decimal
        Get
            Return DevData._ValorDescontos
        End Get
        Set(ByVal value As Decimal)
            If value <> DevData._ValorDescontos Then
                RaiseEvent AoAlterar()
            End If
            DevData._ValorDescontos = value
        End Set
    End Property
    '
    '--- Propriedade ValorAcrescimos
    Public Property ValorAcrescimos() As Decimal
        Get
            Return DevData._ValorAcrescimos
        End Get
        Set(ByVal value As Decimal)
            If value <> DevData._ValorAcrescimos Then
                RaiseEvent AoAlterar()
            End If
            DevData._ValorAcrescimos = value
        End Set
    End Property
    '
    '--- Propriedade TotalVenda
    ReadOnly Property ValorTotal() As Decimal
        Get
            Return ValorProdutos + ValorAcrescimos - ValorDescontos
        End Get
    End Property
    '
    '--- Propriedade Enviada
    '------------------------------------------------------
    Public Property Enviada() As Boolean
        Get
            Return DevData._Enviada
        End Get
        Set(ByVal value As Boolean)
            '
            If value <> DevData._Enviada Then
                RaiseEvent AoAlterar()
                DevData._Enviada = value
                RaiseEvent AoEnviadaAlterar()
            End If
            '
        End Set
    End Property
    '
    '--- Propriedade Creditada
    '------------------------------------------------------
    Public Property Creditada() As Boolean
        Get
            Return DevData._Creditada
        End Get
        Set(ByVal value As Boolean)
            If value <> DevData._Creditada Then
                RaiseEvent AoAlterar()
            End If
            DevData._Creditada = value
        End Set
    End Property
    '
    '===========================================================================================
    '--- TBLOBSERVACAO
    '===========================================================================================
    Property Observacao As String
        Get
            Return DevData._Observacao
        End Get
        Set(value As String)
            If Not IsNothing(DevData._Observacao) AndAlso value <> DevData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            DevData._Observacao = value
        End Set
    End Property
    '
    '===========================================================================================
    '--- TBLARECEBER
    '===========================================================================================
    '--- Propriedade IDAReceber
    Public Property IDAReceber() As Integer?
        Get
            Return DevData._IDAReceber
        End Get
        Set(ByVal value As Integer?)
            If value <> DevData._IDAReceber Then
                RaiseEvent AoAlterar()
            End If
            DevData._IDAReceber = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoAReceber
    Public Property SituacaoAReceber() As Byte
        Get
            Return DevData._SituacaoAReceber
        End Get
        Set(ByVal value As Byte)
            If value <> DevData._SituacaoAReceber Then
                RaiseEvent AoAlterar()
            End If
            DevData._SituacaoAReceber = value
        End Set
    End Property
    '
    '--- Propriedade ValorPagoTotal
    Public Property ValorPagoTotal() As Decimal
        Get
            Return DevData._ValorPagoTotal
        End Get
        Set(ByVal value As Decimal)
            If value <> DevData._ValorPagoTotal Then
                RaiseEvent AoAlterar()
            End If
            DevData._ValorPagoTotal = value
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
            Return DevData._IDTransportadora
        End Get
        Set(ByVal value As Integer?)
            If Not IsNothing(DevData._IDTransportadora) Then
                If value <> DevData._IDTransportadora Then
                    RaiseEvent AoAlterar()
                End If
            End If
            DevData._IDTransportadora = value
        End Set
    End Property
    '
    '--- Propriedade FreteValor
    Public Property FreteValor() As Decimal?
        Get
            Return DevData._FreteValor
        End Get
        Set(ByVal value As Decimal?)
            If Not IsNothing(DevData._FreteValor) Then
                If value <> DevData._FreteValor Then
                    RaiseEvent AoAlterar()
                End If
            End If
            DevData._FreteValor = value
        End Set
    End Property
    '
    '--- Propriedade FreteTipo
    Property FreteTipo() As Byte
        Get
            Return DevData._FreteTipo
        End Get
        Set(value As Byte)
            If Not IsNothing(DevData._FreteTipo) AndAlso value <> DevData._FreteTipo Then
                RaiseEvent AoAlterar()
            End If
            DevData._FreteTipo = value
        End Set
    End Property
    '
    '--- Propriedade Volumes
    Public Property Volumes() As Int16?
        Get
            Return DevData._Volumes
        End Get
        Set(ByVal value As Int16?)
            If Not IsNothing(DevData._Volumes) Then
                If value <> DevData._Volumes Then
                    RaiseEvent AoAlterar()
                End If
            End If
            DevData._Volumes = value
        End Set
    End Property
    '
    '--- Propriedade IDApagar do Frete
    Public Property IDApagar() As Integer?
        Get
            Return DevData._IDAPagar
        End Get
        Set(ByVal value As Integer?)
            If Not IsNothing(DevData._IDAPagar) Then
                If value <> DevData._IDAPagar Then
                    RaiseEvent AoAlterar()
                End If
            End If
            DevData._IDAPagar = value
        End Set
    End Property
    '
#End Region
    '
End Class
