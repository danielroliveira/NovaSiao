Imports System.ComponentModel

Public Class clNotaFiscal : Implements IEditableObject
#Region "ESTRUTURA DOS DADOS"
    Structure NotaStructure ' alguns usam FRIEND em vez de DIM
        '--- Itens da tblAPagar
        Dim _IDNota As Integer?
        Dim _IDTransacao As Integer?
        Dim _EmissaoData As Date?
        Dim _NotaTipo As Byte? '1=NF-e | 2=CF | 3=Outro
        Dim _NotaSerie As Byte?
        Dim _NotaNumero As Integer?
        Dim _NotaValor As Decimal
        Dim _ChaveAcesso As String
    End Structure
#End Region
    '
#Region "PRIVATE VARIABLES"
    Private NotaData As NotaStructure
    Private backupData As NotaStructure
    Private inTxn As Boolean = False
#End Region
    '
#Region "IMPLEMENTS EVENTS"
    Public Sub New()
        NotaData = New NotaStructure()
        With NotaData
            ._NotaValor = 0
        End With
    End Sub
    '
    '-- IMPLEMENTS IEditableObject
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not inTxn Then
            Me.backupData = NotaData
            inTxn = True
        End If
    End Sub
    '
    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If inTxn Then
            Me.NotaData = backupData
            inTxn = False
        End If
    End Sub
    '
    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If inTxn Then
            backupData = New NotaStructure()
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
    '--- Propriedade IDNota
    Public Property IDNota() As Integer?
        Get
            Return NotaData._IDNota
        End Get
        Set(ByVal value As Integer?)
            If value <> NotaData._IDNota Then
                RaiseEvent AoAlterar()
            End If
            NotaData._IDNota = value
        End Set
    End Property
    '
    '--- Propriedade IDTransacao
    Public Property IDTransacao() As Integer?
        Get
            Return NotaData._IDTransacao
        End Get
        Set(ByVal value As Integer?)
            If value <> NotaData._IDTransacao Then
                RaiseEvent AoAlterar()
            End If
            NotaData._IDTransacao = value
        End Set
    End Property
    '
    '--- Propriedade EmissaoData
    Public Property EmissaoData() As Date?
        Get
            Return NotaData._EmissaoData
        End Get
        Set(ByVal value As Date?)
            If value <> NotaData._EmissaoData Then
                RaiseEvent AoAlterar()
            End If
            NotaData._EmissaoData = value
        End Set
    End Property
    '
    '--- Propriedade NotaTipo
    Public Property NotaTipo() As Byte?
        Get
            Return NotaData._NotaTipo
        End Get
        Set(ByVal value As Byte?)
            If value <> NotaData._NotaTipo Then
                RaiseEvent AoAlterar()
            End If
            NotaData._NotaTipo = value
        End Set
    End Property
    '
    '--- Propriedade NotaTipoDesc
    Public ReadOnly Property NotaTipoDesc() As String
        Get
            If Not IsNothing(NotaTipo) Then
                Select Case NotaTipo
                    Case 1
                        Return "NF-e"
                    Case 2
                        Return "Cupom Fiscal"
                    Case 3
                        Return "Outros Tipos"
                    Case Else
                        Return ""
                End Select
            Else
                Return ""
            End If
        End Get
    End Property
    '
    '--- Propriedade NotaSerie
    Public Property NotaSerie() As Byte?
        Get
            Return NotaData._NotaSerie
        End Get
        Set(ByVal value As Byte?)
            If value <> NotaData._NotaSerie Then
                RaiseEvent AoAlterar()
            End If
            NotaData._NotaSerie = value
        End Set
    End Property
    '
    '--- Propriedade NotaNumero
    Public Property NotaNumero() As Integer?
        Get
            Return NotaData._NotaNumero
        End Get
        Set(ByVal value As Integer?)
            If value <> NotaData._NotaNumero Then
                RaiseEvent AoAlterar()
            End If
            NotaData._NotaNumero = value
        End Set
    End Property
    '
    '--- Propriedade NotaValor
    Public Property NotaValor() As Decimal
        Get
            Return NotaData._NotaValor
        End Get
        Set(ByVal value As Decimal)
            If value <> NotaData._NotaValor Then
                RaiseEvent AoAlterar()
            End If
            NotaData._NotaValor = value
        End Set
    End Property
    '
    '--- Propriedade ChaveAcesso
    Public Property ChaveAcesso() As String
        Get
            Return NotaData._ChaveAcesso
        End Get
        Set(ByVal value As String)
            If value <> NotaData._ChaveAcesso Then
                RaiseEvent AoAlterar()
            End If
            NotaData._ChaveAcesso = value
        End Set
    End Property
    '
#End Region
    '
End Class
