Imports System.ComponentModel
'
Public Class clVenda : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure VendaDados ' alguns usam FRIEND em vez de DIM
        'tblTransacao =====================================================
        Dim _IDVenda As Integer?
        Dim _IDPessoaDestino As Integer
        Dim _IDPessoaOrigem As Integer
        Dim _IDOperacao As Byte
        Dim _IDSituacao As Byte
        Dim _IDUser As Integer
        Dim _CFOP As Int16
        Dim _TransacaoData As Date
        'tblVenda =====================================================
        Dim _IDDepartamento As Int16?
        Dim _IDVendedor As Integer
        Dim _CobrancaTipo As Byte 'tinyint
        Dim _JurosMes As Decimal
        Dim _Observacao As String
        Dim _IDVendaTipo As Byte
        Dim _AgregaDevolucao As Boolean
        Dim _ValorProdutos As Decimal '--- Valor dos PRODUTOS vendidos
        Dim _ValorFrete As Decimal '--- Valor do FRETE a ser cobrado na Venda
        Dim _ValorImpostos As Decimal '--- Valor dos IMPOSTOS a ser cobrado na Venda
        Dim _ValorAcrescimos As Decimal '--- Valor dos ACRECIMOS a ser cobrados
        Dim _ValorDevolucao As Decimal '--- Valor da DEVOLUCAO a ser ABATIDA
        'tblAReceber =====================================================
        Dim _IDAReceber As Integer?
        Dim _ValorPagoTotal As Decimal
        Dim _SituacaoAReceber As Byte '--- 0:EmAberto | 1:Pago | 2:Cancelada
        Dim _IDCobrancaForma As Int16? 'smallint
        Dim _IDPlano As Int16?
        'tblVendaFrete =====================================================
        Dim _IDTransportadora As Integer?
        Dim _FreteValor As Decimal?
        Dim _FreteTipo As Byte
        Dim _Volumes As Int16?
        Dim _IDAPagar As Integer?
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private VData As VendaDados
    Private backupData As VendaDados
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        VData = New VendaDados()
        With VData
            ._IDVenda = Nothing
            ._IDDepartamento = Nothing
            ._IDVendedor = Nothing
            ._TransacaoData = DateTime.Today
            ._CobrancaTipo = 0 'tinyint
            ._IDSituacao = 0
            ._IDVendaTipo = 1
            ._AgregaDevolucao = False
            ._ValorProdutos = 0
            ._ValorFrete = 0
            ._ValorImpostos = 0
            ._ValorAcrescimos = 0
            ._ValorDevolucao = 0
            ._JurosMes = 0
            ._SituacaoAReceber = 0
            ._ValorPagoTotal = 0
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = VData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.VData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New VendaDados()
            inTxn = False
        End If
    End Sub
    '
    '-- _EVENTO PUBLIC AOALTERAR
    Public Event AoAlterar()
    '
    Public Overrides Function ToString() As String
        Return IDVenda.ToString
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
    Property IDVenda() As Nullable(Of Integer)
        Get
            Return VData._IDVenda
        End Get
        Set(value As Nullable(Of Integer))
            VData._IDVenda = value
        End Set
    End Property
    '
    Property IDPessoaDestino() As Integer
        Get
            Return VData._IDPessoaDestino
        End Get
        Set(value As Integer)
            If Not IsNothing(VData._IDPessoaDestino) AndAlso value <> VData._IDPessoaDestino Then
                RaiseEvent AoAlterar()
            End If
            VData._IDPessoaDestino = value
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
            Return VData._IDPessoaOrigem
        End Get
        Set(ByVal value As Integer?)
            If value <> VData._IDPessoaOrigem Then
                RaiseEvent AoAlterar()
            End If
            VData._IDPessoaOrigem = value
        End Set
    End Property
    '
    '--- Propriedade IDOperacao
    Public Property IDOperacao() As Byte
        Get
            Return VData._IDOperacao
        End Get
        Set(ByVal value As Byte)
            If value <> VData._IDOperacao Then
                RaiseEvent AoAlterar()
            End If
            VData._IDOperacao = value
        End Set
    End Property
    '
    Property IDSituacao() As Byte
        Get
            Return VData._IDSituacao
        End Get
        Set(value As Byte)
            If Not IsNothing(VData._IDSituacao) AndAlso value <> VData._IDSituacao Then
                RaiseEvent AoAlterar()
            End If
            VData._IDSituacao = value
        End Set
    End Property
    '
    Property Situacao As String ' texto da Situacao da Venda
    '
    Property IDUser() As Integer
        Get
            Return VData._IDUser
        End Get
        Set(value As Integer)
            If Not IsNothing(VData._IDUser) AndAlso value <> VData._IDUser Then
                RaiseEvent AoAlterar()
            End If
            VData._IDUser = value
        End Set
    End Property
    '
    Property CFOP() As Int16
        Get
            Return VData._CFOP
        End Get
        Set(value As Int16)
            If Not IsNothing(VData._CFOP) AndAlso value <> VData._CFOP Then
                RaiseEvent AoAlterar()
            End If
            VData._CFOP = value
        End Set
    End Property
    '
    Property TransacaoData() As Date
        Get
            Return VData._TransacaoData
        End Get
        Set(value As Date)
            If Not IsNothing(VData._TransacaoData) AndAlso value <> VData._TransacaoData Then
                RaiseEvent AoAlterar()
            End If
            VData._TransacaoData = value
        End Set
    End Property
    '
    '===========================================================================================
    '--- TBLVENDA
    '===========================================================================================
    '
    Property IDDepartamento() As Nullable(Of Int16)
        Get
            Return VData._IDDepartamento
        End Get
        Set(value As Nullable(Of Int16))
            If Not IsNothing(VData._IDDepartamento) Then
                If value <> VData._IDDepartamento Then
                    RaiseEvent AoAlterar()
                End If
            End If
            VData._IDDepartamento = value
        End Set
    End Property
    '
    Property IDVendedor() As Nullable(Of Integer)
        Get
            Return VData._IDVendedor
        End Get
        Set(value As Nullable(Of Integer))
            If Not IsNothing(VData._IDVendedor) Then
                If value <> VData._IDVendedor Then
                    RaiseEvent AoAlterar()
                End If
            End If
            VData._IDVendedor = value
        End Set
    End Property
    '
    Public Property ApelidoFuncionario() As String
    '
    '
    '--- Propriedade AgregaDevolucao
    '------------------------------------------------------
    Public Property AgregaDevolucao() As Boolean
        Get
            Return VData._AgregaDevolucao
        End Get
        Set(ByVal value As Boolean)
            If value <> VData._AgregaDevolucao Then
                RaiseEvent AoAlterar()
            End If
            VData._AgregaDevolucao = value
        End Set
    End Property
    '
    Property CobrancaTipo() As Byte
        Get
            Return VData._CobrancaTipo
        End Get
        Set(value As Byte)
            If Not IsNothing(VData._CobrancaTipo) AndAlso value <> VData._CobrancaTipo Then
                RaiseEvent AoAlterar()
            End If
            VData._CobrancaTipo = value
        End Set
    End Property
    '
    Property JurosMes() As Decimal
        Get
            Return VData._JurosMes
        End Get
        Set(value As Decimal)
            If Not IsNothing(VData._JurosMes) AndAlso value <> VData._JurosMes Then
                RaiseEvent AoAlterar()
            End If
            VData._JurosMes = value
        End Set
    End Property
    '
    Property Observacao As String
        Get
            Return VData._Observacao
        End Get
        Set(value As String)
            If Not IsNothing(VData._Observacao) AndAlso value <> VData._Observacao Then
                RaiseEvent AoAlterar()
            End If
            VData._Observacao = value
        End Set
    End Property
    '
    Property IDVendaTipo() As Byte
        Get
            Return VData._IDVendaTipo
        End Get
        Set(value As Byte)
            If Not IsNothing(VData._IDVendaTipo) AndAlso value <> VData._IDVendaTipo Then
                RaiseEvent AoAlterar()
            End If
            VData._IDVendaTipo = value
        End Set
    End Property
    '
    '--- Propriedade ValorProdutos
    Public Property ValorProdutos() As Decimal
        Get
            Return VData._ValorProdutos
        End Get
        Set(ByVal value As Decimal)
            If CInt(value * 100) <> CInt(VData._ValorProdutos * 100) Then
                RaiseEvent AoAlterar()
            End If
            VData._ValorProdutos = value
        End Set
    End Property
    '
    '--- Propriedade ValorFrete
    Public Property ValorFrete() As Decimal
        Get
            Return VData._ValorFrete
        End Get
        Set(ByVal value As Decimal)
            If value <> VData._ValorFrete Then
                RaiseEvent AoAlterar()
            End If
            VData._ValorFrete = value
        End Set
    End Property
    '
    '--- Propriedade ValorImpostos
    Public Property ValorImpostos() As Decimal
        Get
            Return VData._ValorImpostos
        End Get
        Set(ByVal value As Decimal)
            If value <> VData._ValorImpostos Then
                RaiseEvent AoAlterar()
            End If
            VData._ValorImpostos = value
        End Set
    End Property
    '
    '--- Propriedade ValorAcrescimo
    Public Property ValorAcrescimos() As Decimal
        Get
            Return VData._ValorAcrescimos
        End Get
        Set(ByVal value As Decimal)
            If value <> VData._ValorAcrescimos Then
                RaiseEvent AoAlterar()
            End If
            VData._ValorAcrescimos = value
        End Set
    End Property
    '
    '--- Propriedade ValorDevolucao
    '------------------------------------------------------
    Public Property ValorDevolucao() As Decimal
        Get
            Return VData._ValorDevolucao
        End Get
        Set(ByVal value As Decimal)
            If value <> VData._ValorDevolucao Then
                RaiseEvent AoAlterar()
            End If
            VData._ValorDevolucao = value
        End Set
    End Property
    '
    '--- Propriedade TotalVenda
    ReadOnly Property TotalVenda() As Decimal
        Get
            Dim T = ValorProdutos + ValorFrete + ValorImpostos + ValorAcrescimos - ValorDevolucao
            Return If(T < 0, 0, T)
        End Get
    End Property
    '
    '===========================================================================================
    '--- TBLARECEBER
    '===========================================================================================
    '--- Propriedade IDAReceber
    Public Property IDAReceber() As Integer?
        Get
            Return VData._IDAReceber
        End Get
        Set(ByVal value As Integer?)
            If value <> VData._IDAReceber Then
                RaiseEvent AoAlterar()
            End If
            VData._IDAReceber = value
        End Set
    End Property
    '
    '--- Propriedade SituacaoAReceber
    Public Property SituacaoAReceber() As Byte
        Get
            Return VData._SituacaoAReceber
        End Get
        Set(ByVal value As Byte)
            If value <> VData._SituacaoAReceber Then
                RaiseEvent AoAlterar()
            End If
            VData._SituacaoAReceber = value
        End Set
    End Property
    '
    '--- Propriedade ValorPagoTotal
    Public Property ValorPagoTotal() As Decimal
        Get
            Return VData._ValorPagoTotal
        End Get
        Set(ByVal value As Decimal)
            If value <> VData._ValorPagoTotal Then
                RaiseEvent AoAlterar()
            End If
            VData._ValorPagoTotal = value
        End Set
    End Property
    '
    '--- Propriedade IDCobrancaForma
    Public Property IDCobrancaForma() As Int16?
        Get
            Return VData._IDCobrancaForma
        End Get
        Set(ByVal value As Int16?)
            If value <> VData._IDCobrancaForma Then
                RaiseEvent AoAlterar()
            End If
            VData._IDCobrancaForma = value
        End Set
    End Property
    '
    '--- Propriedade IDPlano
    Public Property IDPlano() As Int16?
        Get
            Return VData._IDPlano
        End Get
        Set(ByVal value As Int16?)
            If value <> VData._IDPlano Then
                RaiseEvent AoAlterar()
            End If
            VData._IDPlano = value
        End Set
    End Property
    '
    Public Property CobrancaForma As String
    '
    '===========================================================================================
    '--- TBLVENDAFRETE
    '===========================================================================================
    '
    '--- Propriedade IDTransportadora
    Public Property IDTransportadora() As Integer?
        Get
            Return VData._IDTransportadora
        End Get
        Set(ByVal value As Integer?)
            If Not IsNothing(VData._IDTransportadora) Then
                If value <> VData._IDTransportadora Then
                    RaiseEvent AoAlterar()
                End If
            End If
            VData._IDTransportadora = value
        End Set
    End Property
    '
    '--- Propriedade FreteValor
    Public Property FreteValor() As Decimal?
        Get
            Return VData._FreteValor
        End Get
        Set(ByVal value As Decimal?)
            If Not IsNothing(VData._FreteValor) Then
                If value <> VData._FreteValor Then
                    RaiseEvent AoAlterar()
                End If
            End If
            VData._FreteValor = value
        End Set
    End Property
    '
    '--- Propriedade FreteTipo
    Property FreteTipo() As Byte
        Get
            Return VData._FreteTipo
        End Get
        Set(value As Byte)
            If Not IsNothing(VData._FreteTipo) AndAlso value <> VData._FreteTipo Then
                RaiseEvent AoAlterar()
            End If
            VData._FreteTipo = value
        End Set
    End Property
    '
    '--- Propriedade Volumes
    Public Property Volumes() As Int16?
        Get
            Return VData._Volumes
        End Get
        Set(ByVal value As Int16?)
            If Not IsNothing(VData._Volumes) Then
                If value <> VData._Volumes Then
                    RaiseEvent AoAlterar()
                End If
            End If
            VData._Volumes = value
        End Set
    End Property
    '
    '--- Propriedade IDApagar do Frete
    Public Property IDApagar() As Integer?
        Get
            Return VData._IDAPagar
        End Get
        Set(ByVal value As Integer?)
            If Not IsNothing(VData._IDAPagar) Then
                If value <> VData._IDAPagar Then
                    RaiseEvent AoAlterar()
                End If
            End If
            VData._IDAPagar = value
        End Set
    End Property
    '
#End Region
    '
End Class
