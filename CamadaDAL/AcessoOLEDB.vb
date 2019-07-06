Imports System.Data.OleDb

Public Class AcessoOLEDB
    '
    '-------------------------------------------------------------------------------------------------------
    'DECLARAÇÃO DAS VARIÁVEIS
    '-------------------------------------------------------------------------------------------------------
    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim isTran As Boolean = False
    Private trans As OleDbTransaction
    Public ParamList As New List(Of OleDbParameter)
    '
#Region "GET CONNECTION"
    '
    '-------------------------------------------------------------------------------------------------------
    'SUB NEW
    '-------------------------------------------------------------------------------------------------------
    Public Sub New(databasePath As String)
        If Not Connect(databasePath) Then
            Exit Sub
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    'CONCETAR ABRIR A CONEXÃO
    '-------------------------------------------------------------------------------------------------------
    Private Function Connect(databasePath As String) As Boolean
        '
        Dim connstr As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" & databasePath
        Dim bln As Boolean
        '
        If conn Is Nothing Then
            '
            Try
                '
                If connstr <> String.Empty Then
                    conn = New OleDbConnection(connstr)
                    bln = True
                Else
                    bln = False
                End If
                '
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '
        Return bln
        '
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    ' FECHAR A CONEXÃO
    '-------------------------------------------------------------------------------------------------------
    Public Sub CloseConn()
        '
        If Not conn Is Nothing Then
            If Not conn.State = ConnectionState.Closed Then
                conn.Close()
            End If
        End If
        '
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    '--- LIMPAR PARAMETROS
    '-------------------------------------------------------------------------------------------------------
    Public Sub LimparParametros()
        ParamList.Clear()
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    '--- ADICIONAR PARAMETROS
    '-------------------------------------------------------------------------------------------------------
    Public Sub AdicionarParametros(nomeParametro As String, valorParametro As Object)
        ParamList.Add(New OleDbParameter(nomeParametro, valorParametro))
    End Sub
    '
#End Region '/ GET CONNECTION
    '
#Region "DATABASE CRUD COMMANDS"
    '
    '-------------------------------------------------------------------------------------------------------
    '--- EXECUTAR INSERT, UPDATE, DELETE
    '-------------------------------------------------------------------------------------------------------
    Public Function ExecutarManipulacao(comandType As CommandType, nomeStoredProcedureOuTextoSQL As String) As Object
        '
        Try
            '
            If conn.State = ConnectionState.Closed Then
                Throw New Exception("Sem conexão ao Database...")
            End If
            '
            cmd = New OleDbConnection().CreateCommand
            cmd.Connection = conn
            cmd.CommandType = comandType
            cmd.CommandText = nomeStoredProcedureOuTextoSQL
            cmd.CommandTimeout = 7200
            '
            ParamList.ForEach(Sub(p) cmd.Parameters.Add(p))
            '
            If Not isTran Then
                Return cmd.ExecuteScalar
                CloseConn()
            Else
                cmd.Transaction = trans
                Return cmd.ExecuteScalar
            End If
            '
        Catch ex As Exception
            '
            Throw ex
            '
        End Try
        '
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    '--- EXECUTAR CONSULTA
    '-------------------------------------------------------------------------------------------------------
    Public Function ExecutarConsulta(comandType As CommandType, nomeStoredProcedureOuTextoSQL As String) As DataTable
        '
        Try
            '
            If conn.State = ConnectionState.Closed Then
                Throw New Exception("Sem conexão ao Database...")
            End If
            '
            cmd = New OleDbConnection().CreateCommand
            cmd.Connection = conn
            cmd.CommandType = comandType
            cmd.CommandText = nomeStoredProcedureOuTextoSQL
            cmd.CommandTimeout = 7200
            '
            ParamList.ForEach(Sub(p) cmd.Parameters.Add(p))
            '
            '--- IF active transaction
            If isTran Then cmd.Transaction = trans

            Dim sqlDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            '
            Dim dtTable As New DataTable
            sqlDA.Fill(dtTable)
            '
            '--- Close connection if NOT active Transaction
            If Not isTran Then CloseConn()
            '
            Return dtTable
            '
        Catch ex As Exception
            '
            Throw ex
            '
        End Try
        '
    End Function
    '
#End Region '/ DATABASE CRUD COMMANDS
    '
#Region "TRANSACTION"
    '
    '=============================================================
    ' SQL TRANSACTIONS
    '=============================================================
    '
    '--- INICIA TRANSACTION
    Public Sub BeginTransaction()
        '
        If isTran Then Return
        '
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        '
        '--- isolation READUNCOMMITED level permite fazer SELECT em NOT COMMITED TRANSACTION
        Dim iso As IsolationLevel = IsolationLevel.ReadUncommitted
        '
        trans = conn.BeginTransaction(iso)
        isTran = True
        '
    End Sub
    '
    '--- COMMIT TRANSACTION
    Public Sub CommitTransaction()
        If Not isTran Then Return
        trans.Commit()
        conn.Close()
        trans = Nothing
        isTran = False
    End Sub
    '
    '--- ROLLBACK TRANSACTION
    Public Sub RollBackTransaction()
        If Not isTran Then Return
        trans.Rollback()
        conn.Close()
        trans = Nothing
        isTran = False
    End Sub
    '
    '--- RETURN IF EXISTS TRANSACTION
    Public ReadOnly Property isTransaction As Boolean
        Get
            Return isTran
        End Get
    End Property
    '
#End Region '/ TRANSACTION
    '
End Class
