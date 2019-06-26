Imports System.ComponentModel

Public Class clDespesa : Implements IEditableObject
    '
#Region "ESTRUTURA DOS DADOS"
    Structure DespesaStructure ' alguns usam FRIEND em vez de DIM
        '--- Itens da tblDespesa
        Dim _IDDespesa As Integer?
        Dim _IDCredor As Integer?
        Dim _IDFilial As Integer?
        Dim _IDDespesaTipo As Integer?
        Dim _Descricao As String
        Dim _DespesaData? As Date
        Dim _DespesaValor As Decimal
        Dim _Parcelado As Boolean
        Dim _Bloqueada As Boolean
        Dim _ValorPagoTotal As Decimal?
        '--- Itens Importados outras TBL
        Dim _CNP As String
        Dim _Cadastro As String
        Dim _ApelidoFilial As String
        Dim _DespesaTipo As String
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private DespData As DespesaStructure
    Private backupData As DespesaStructure
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        DespData = New DespesaStructure()
        With DespData
            ._DespesaValor = 0
            ._Parcelado = False
            ._Bloqueada = False
            ._ValorPagoTotal = 0
            ._DespesaData = Today.ToShortDateString
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = DespData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.DespData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New DespesaStructure()
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
    '--- Propriedade IDDespesa
    Public Property IDDespesa() As Integer?
        Get
            Return DespData._IDDespesa
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDDespesa Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDDespesa = value
        End Set
    End Property
    '
    '--- Propriedade IDCredor
    Public Property IDCredor() As Integer?
        Get
            Return DespData._IDCredor
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDCredor Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDCredor = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    Public Property IDFilial() As Integer?
        Get
            Return DespData._IDFilial
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade IDDespesaTipo
    Public Property IDDespesaTipo() As Integer?
        Get
            Return DespData._IDDespesaTipo
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDDespesaTipo Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDDespesaTipo = value
        End Set
    End Property
    '
    '--- Propriedade Descricao
    Public Property Descricao() As String
        Get
            Return DespData._Descricao
        End Get
        Set(ByVal value As String)
            If value <> DespData._Descricao Then
                RaiseEvent AoAlterar()
            End If
            DespData._Descricao = value
        End Set
    End Property
    '
    '--- Propriedade DespesaData
    Public Property DespesaData() As Date?
        Get
            Return DespData._DespesaData
        End Get
        Set(ByVal value As Date?)
            If value <> DespData._DespesaData Then
                RaiseEvent AoAlterar()
            End If
            DespData._DespesaData = value
        End Set
    End Property
    '
    '--- Propriedade DespesaValor
    Public Property DespesaValor() As Decimal
        Get
            Return DespData._DespesaValor
        End Get
        Set(ByVal value As Decimal)
            If value <> DespData._DespesaValor Then
                RaiseEvent AoAlterar()
            End If
            DespData._DespesaValor = value
        End Set
    End Property
    '
    '--- Propriedade Parcelado
    Public Property Parcelado() As Boolean
        Get
            Return DespData._Parcelado
        End Get
        Set(ByVal value As Boolean)
            If value <> DespData._Parcelado Then
                RaiseEvent AoAlterar()
            End If
            DespData._Parcelado = value
        End Set
    End Property
    '
    '--- Propriedade Bloqueada
    Public Property Bloqueada() As Boolean
        Get
            Return DespData._Bloqueada
        End Get
        Set(ByVal value As Boolean)
            If value <> DespData._Bloqueada Then
                RaiseEvent AoAlterar()
            End If
            DespData._Bloqueada = value
        End Set
    End Property
    '
    '--- Propriedade ValorPagoTotal
    Public Property ValorPagoTotal() As Decimal?
        Get
            Return DespData._ValorPagoTotal
        End Get
        Set(ByVal value As Decimal?)
            If value <> DespData._ValorPagoTotal Then
                RaiseEvent AoAlterar()
            End If
            DespData._ValorPagoTotal = value
        End Set
    End Property

    '----------------------------------------------------------------------
    ' propriedades de outras tabelas
    '----------------------------------------------------------------------
    '
    '--- Propriedade Cadastro
    Public Property Cadastro() As String
        Get
            Return DespData._Cadastro
        End Get
        Set(ByVal value As String)
            If value <> DespData._Cadastro Then
                RaiseEvent AoAlterar()
            End If
            DespData._Cadastro = value
        End Set
    End Property
    '
    '--- Propriedade CNP
    Public Property CNP() As String
        Get
            Return DespData._CNP
        End Get
        Set(ByVal value As String)
            If value <> DespData._CNP Then
                RaiseEvent AoAlterar()
            End If
            DespData._CNP = value
        End Set
    End Property
    '
    '--- Propriedade ApelidoFilial
    Public Property ApelidoFilial() As String
        Get
            Return DespData._ApelidoFilial
        End Get
        Set(ByVal value As String)
            If value <> DespData._ApelidoFilial Then
                RaiseEvent AoAlterar()
            End If
            DespData._ApelidoFilial = value
        End Set
    End Property
    '
    '--- Propriedade DespesaTipo
    Public Property DespesaTipo() As String
        Get
            Return DespData._DespesaTipo
        End Get
        Set(ByVal value As String)
            If value <> DespData._DespesaTipo Then
                RaiseEvent AoAlterar()
            End If
            DespData._DespesaTipo = value
        End Set
    End Property
#End Region

End Class
'
Public Class clDespesaTipo
    Implements IEditableObject
    '
    Structure StructureDespesaTipo
        Dim _IDDespesaTipo As Integer?
        Dim _DespesaTipo As String
        Dim _Periodicidade As Byte? ' 0:Variavel | 1:Semanal | 2:Mensal | 3:Anual
        Dim _Variacao As Byte? ' 0:Despesa Fixa | 1:Despesa Variavel | 2:Custo
    End Structure
    '
    '--- variaveis de controle da classe
    Friend DTData As StructureDespesaTipo
    Friend DTData_Backup As StructureDespesaTipo
    Friend inTxn As Boolean = False
    '
    Public Event AoAlterar()
    '
    '--- Propriedade Generica
    Public Overridable Property RegistroAlterado As Boolean
        Get
            Return inTxn
        End Get
        Set(value As Boolean)
            inTxn = value
            RaiseEvent AoAlterar()
        End Set
    End Property
    '
    Sub New()
        DTData = New StructureDespesaTipo
        DTData._Periodicidade = 0
        DTData._Variacao = 1
    End Sub
    '
    '--- Implementacao
    Public Overridable Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not RegistroAlterado Then
            '--- reserva os dados para recuperacao futura
            DTData_Backup = DTData
            RegistroAlterado = True
        End If
    End Sub
    '
    Public Overridable Sub EndEdit() Implements IEditableObject.EndEdit
        If RegistroAlterado Then
            DTData_Backup = New StructureDespesaTipo()
            RegistroAlterado = False
        End If
    End Sub
    '
    Public Overridable Sub CancelEdit() Implements IEditableObject.CancelEdit
        If RegistroAlterado Then
            DTData = DTData_Backup
            RegistroAlterado = False
        End If
    End Sub
    '
    '--- PROPRIEDADES DA CLASSE
    '
    '--- Propriedade IDDespesaTipo
    Public Property IDDespesaTipo() As Integer?
        Get
            Return DTData._IDDespesaTipo
        End Get
        Set(ByVal value As Integer?)
            If value <> DTData._IDDespesaTipo Then
                RaiseEvent AoAlterar()
            End If
            DTData._IDDespesaTipo = value
        End Set
    End Property
    '
    '--- Propriedade DespesaTipo
    Public Property DespesaTipo() As String
        Get
            Return DTData._DespesaTipo
        End Get
        Set(ByVal value As String)
            If value <> DTData._DespesaTipo Then
                RaiseEvent AoAlterar()
            End If
            DTData._DespesaTipo = value
        End Set
    End Property
    '
    '--- Propriedade Periodicidade
    Public Property Periodicidade() As Byte?
        Get
            Return DTData._Periodicidade
        End Get
        Set(ByVal value As Byte?)
            If value <> DTData._Periodicidade Then
                RaiseEvent AoAlterar()
            End If
            DTData._Periodicidade = value
        End Set
    End Property
    '
    '--- Propriedade PeriodicidadeTexto
    Public ReadOnly Property PeriodicidadeTexto() As String
        '0:Variavel | 1:Semanal | 2:Mensal | 3:Anual
        Get
            Select Case Periodicidade
                Case 0
                    Return "Variavel"
                Case 1
                    Return "Semanal"
                Case 2
                    Return "Mensal"
                Case 3
                    Return "Anual"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    '
    '--- Propriedade Variacao
    Public Property Variacao() As Byte?
        Get
            Return DTData._Variacao
        End Get
        Set(ByVal value As Byte?)
            If value <> DTData._Variacao Then
                RaiseEvent AoAlterar()
            End If
            DTData._Variacao = value
        End Set
    End Property
    '
    '--- Propriedade VariacaoTexto
    Public ReadOnly Property VariacaoTexto() As String
        '0:Despesa Fixa | 1:Despesa Variavel | 2:Custo
        Get
            Select Case Variacao
                Case 0
                    Return "Despesa Fixa"
                Case 1
                    Return "Despesa Variavel"
                Case 2
                    Return "Custo"
                Case Else
                    Return ""
            End Select
        End Get
    End Property
    '
End Class
'
Public Class clDespesaPeriodica : Implements IEditableObject
#Region "ESTRUTURA DOS DADOS"
    Structure DespesaStructure ' alguns usam FRIEND em vez de DIM
        '--- Itens da tblDespesa
        Dim _IDDespesaPeriodica As Integer?
        Dim _IDCredor As Integer?
        Dim _IDFilial As Integer?
        Dim _IDDespesaTipo As Integer?
        Dim _Descricao As String
        Dim _IniciarData As Date
        Dim _DespesaValor As Decimal
        Dim _Ativa As Boolean
        Dim _Periodicidade As Byte? '--- 1:Semanal | 2:Mensal | 3:Anual
        Dim _DiaVencimento As Byte?
        Dim _MesVencimento As Byte?
        Dim _IDCobrancaForma As Int16?
        Dim _RGBanco As Int16?
        '--- Itens Importados outras TBL
        Dim _CNP As String
        Dim _Cadastro As String
        Dim _ApelidoFilial As String
        Dim _DespesaTipo As String
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private DespData As DespesaStructure
    Private backupData As DespesaStructure
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        DespData = New DespesaStructure()
        With DespData
            ._DespesaValor = 0
            ._Periodicidade = 2 '--- Mensal
            ._Ativa = True
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = DespData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.DespData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New DespesaStructure()
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
    '--- Propriedade IDDespesaPeriodica
    Public Property IDDespesaPeriodica() As Integer?
        Get
            Return DespData._IDDespesaPeriodica
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDDespesaPeriodica Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDDespesaPeriodica = value
        End Set
    End Property
    '
    '--- Propriedade IDCredor
    Public Property IDCredor() As Integer?
        Get
            Return DespData._IDCredor
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDCredor Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDCredor = value
        End Set
    End Property
    '
    '--- Propriedade IDFilial
    Public Property IDFilial() As Integer?
        Get
            Return DespData._IDFilial
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDFilial Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDFilial = value
        End Set
    End Property
    '
    '--- Propriedade IDDespesaTipo
    Public Property IDDespesaTipo() As Integer?
        Get
            Return DespData._IDDespesaTipo
        End Get
        Set(ByVal value As Integer?)
            If value <> DespData._IDDespesaTipo Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDDespesaTipo = value
        End Set
    End Property
    '
    '--- Propriedade Descricao
    Public Property Descricao() As String
        Get
            Return DespData._Descricao
        End Get
        Set(ByVal value As String)
            If value <> DespData._Descricao Then
                RaiseEvent AoAlterar()
            End If
            DespData._Descricao = value
        End Set
    End Property
    '
    '--- Propriedade IniciarData
    Public Property IniciarData() As Date
        Get
            Return DespData._IniciarData
        End Get
        Set(ByVal value As Date)
            If value <> DespData._IniciarData Then
                RaiseEvent AoAlterar()
            End If
            DespData._IniciarData = value
        End Set
    End Property
    '
    '--- Propriedade DespesaValor
    Public Property DespesaValor() As Decimal
        Get
            Return DespData._DespesaValor
        End Get
        Set(ByVal value As Decimal)
            If value <> DespData._DespesaValor Then
                RaiseEvent AoAlterar()
            End If
            DespData._DespesaValor = value
        End Set
    End Property
    '
    '--- Propriedade Ativa
    Public Property Ativa() As Boolean
        Get
            Return DespData._Ativa
        End Get
        Set(ByVal value As Boolean)
            If value <> DespData._Ativa Then
                RaiseEvent AoAlterar()
            End If
            DespData._Ativa = value
        End Set
    End Property
    '
    '--- Propriedade Periodicidade
    Public Property Periodicidade() As Byte?
        Get
            Return DespData._Periodicidade
        End Get
        Set(ByVal value As Byte?)
            If value <> DespData._Periodicidade Then
                RaiseEvent AoAlterar()
            End If
            DespData._Periodicidade = value
        End Set
    End Property
    '
    '--- Propriedade PeriodicidadeTexto
    Public ReadOnly Property PeriodicidadeTexto() As String
        Get
            Select Case Periodicidade
                Case 1
                    Return "Semanal"
                Case 2
                    Return "Mensal"
                Case 3
                    Return "Anual"
                Case Else
                    Return "Indefinida"
            End Select
        End Get
    End Property
    '
    '--- Propriedade DiaVencimento
    Public Property DiaVencimento() As Byte?
        Get
            Return DespData._DiaVencimento
        End Get
        Set(ByVal value As Byte?)
            If value <> DespData._DiaVencimento Then
                RaiseEvent AoAlterar()
            End If
            DespData._DiaVencimento = value
        End Set
    End Property
    '
    '--- Propriedade MesVencimento
    Public Property MesVencimento() As Byte?
        Get
            Return DespData._MesVencimento
        End Get
        Set(ByVal value As Byte?)
            If value <> IIf(IsNothing(DespData._MesVencimento), -1, DespData._MesVencimento) Then
                RaiseEvent AoAlterar()
            End If
            DespData._MesVencimento = value
        End Set
    End Property
    '
    '--- Propriedade IDCobrancaForma
    Public Property IDCobrancaForma() As Int16?
        Get
            Return DespData._IDCobrancaForma
        End Get
        Set(ByVal value As Int16?)
            If value <> DespData._IDCobrancaForma Then
                RaiseEvent AoAlterar()
            End If
            DespData._IDCobrancaForma = value
        End Set
    End Property
    '
    Public Property CobrancaForma As String
    '
    '--- Propriedade RGBanco
    Public Property RGBanco() As Int16?
        Get
            Return DespData._RGBanco
        End Get
        Set(ByVal value As Int16?)
            If value <> IIf(IsNothing(DespData._RGBanco), -1, DespData._RGBanco) Then
                RaiseEvent AoAlterar()
            End If
            DespData._RGBanco = value
        End Set
    End Property
    '
    Public Property BancoNome As String
    '
    '----------------------------------------------------------------------
    ' propriedades de outras tabelas
    '----------------------------------------------------------------------
    '
    '--- Propriedade Cadastro
    Public Property Cadastro() As String
        Get
            Return DespData._Cadastro
        End Get
        Set(ByVal value As String)
            If value <> DespData._Cadastro Then
                RaiseEvent AoAlterar()
            End If
            DespData._Cadastro = value
        End Set
    End Property
    '
    '--- Propriedade CNP
    Public Property CNP() As String
        Get
            Return DespData._CNP
        End Get
        Set(ByVal value As String)
            If value <> DespData._CNP Then
                RaiseEvent AoAlterar()
            End If
            DespData._CNP = value
        End Set
    End Property
    '
    '--- Propriedade ApelidoFilial
    Public Property ApelidoFilial() As String
    '
    '--- Propriedade DespesaTipo
    Public Property DespesaTipo() As String
    '
#End Region
    '
End Class
