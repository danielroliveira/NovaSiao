Imports System.Data.SqlClient
'
Public Class AcessoDados
    '-------------------------------------------------------------------------------------------------------
    'DECLARAÇÃO DAS VARIÁVEIS
    '-------------------------------------------------------------------------------------------------------
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim isTran As Boolean = False
    Private trans As SqlTransaction
    Public ParamList As New List(Of SqlParameter)
    '
#Region "GET CONNECTION | OPEN | CLOSE"
    '
    '-------------------------------------------------------------------------------------------------------
    'SUB NEW
    '-------------------------------------------------------------------------------------------------------
    Public Sub New()
        If Not Connect() Then
            Exit Sub
        End If
    End Sub
    '
    '-------------------------------------------------------------------------------------------------------
    ' RETORNAR A CONECTION STRING
    '-------------------------------------------------------------------------------------------------------
    Public Shared Function GetConnectionString() As String
        '
        Dim retorno As New String("")
        '
        Try
            Dim connFile As String = My.MySettings.Default.ConexaoStringFile
            Dim connName As String = My.MySettings.Default.ConexaoStringName
            Dim getConn As New GetConnection
            '
            retorno = getConn.LoadConnectionString(connFile, connName)
            '
            If String.IsNullOrEmpty(retorno.Trim) Then
                Throw New Exception("Arquivo de Conexão Database inválido...")
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- veriica se há retorno da |DataDirectory|
        '--- substitui o |DataDirectory| pelo "CamadaDAL\Dados"
        If retorno.Contains("|DataDirectory|") Then
            Dim BaseDir As String = AppDomain.CurrentDomain.BaseDirectory
            '
            Dim findI As Integer
            '
            findI = BaseDir.IndexOf("\", 0)
            findI = BaseDir.IndexOf("\", findI + 1)
            findI = BaseDir.IndexOf("\", findI + 1)
            '
            BaseDir = BaseDir.Substring(0, findI) + "\CamadaDAL"
            '
            retorno = retorno.Replace("|DataDirectory|", BaseDir)
            '
        End If
        '
        Return retorno
        '
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    'CONCETAR ABRIR A CONEXÃO
    '-------------------------------------------------------------------------------------------------------
    Private Function Connect() As Boolean
        '
        Dim connstr As String = ""
        Dim bln As Boolean
        '
        If conn Is Nothing Then
            '
            Try
                connstr = GetConnectionString()
                '
                If connstr <> String.Empty Then
                    conn = New SqlConnection(connstr)
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
        ParamList.Add(New SqlParameter(nomeParametro, valorParametro))
    End Sub
    '
    '==========================================================================================
    ' GET CONFIG DB - CONNECTION XML PATH
    '==========================================================================================
    Public Shared Function GetConfigXMLPath() As String
        '
        Try
            Dim connFile As String = My.MySettings.Default.ConexaoStringFile
            '
            Return connFile
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
#End Region '/ GET CONNECTION | OPEN | CLOSE
    '
#Region "COMMANDS QUERY | INSERT | UPDATE | DELETE"
    '
    '-------------------------------------------------------------------------------------------------------
    '--- EXECUTAR INSERT, UPDATE, DELETE
    '-------------------------------------------------------------------------------------------------------
    Public Function ExecutarManipulacao(comandType As CommandType, nomeStoredProcedureOuTextoSQL As String) As Object
        '
        Try
            '
            If conn.State = ConnectionState.Closed Then Connect()
            '
            cmd = New SqlConnection().CreateCommand
            cmd.Connection = conn
            cmd.CommandType = comandType
            cmd.CommandText = nomeStoredProcedureOuTextoSQL
            cmd.CommandTimeout = 7200
            '
            ParamList.ForEach(Sub(p) cmd.Parameters.Add(p))
            '
            If Not isTran Then
                '
                '--- EXECUTE
                Dim obj As Object = cmd.ExecuteScalar
                '
                '--- CLOSE DB CONNECTION
                CloseConn()
                '
                '--- RETURN
                Return obj
                '
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
            If conn.State = ConnectionState.Closed Then Connect()
            '
            cmd = New SqlConnection().CreateCommand
            cmd.Connection = conn
            cmd.CommandType = comandType
            cmd.CommandText = nomeStoredProcedureOuTextoSQL
            cmd.CommandTimeout = 7200
            '
            ParamList.ForEach(Sub(p) cmd.Parameters.Add(p))
            '
            '--- IF active transaction
            If isTran Then cmd.Transaction = trans

            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            '
            Dim dtTable As New DataTable
            sqlDA.Fill(dtTable)
            '
            '--- Close connection if NOT active Transaction
            If Not isTran Then CloseConn()
            '
            '--- return
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
    '-------------------------------------------------------------------------------------------------------
    ' EXECUTAR UMA QUERY
    '-------------------------------------------------------------------------------------------------------
    Public Function ExecuteQuery(ByVal strCmdTxt As String) As Boolean
        Dim intRows As Integer
        '
        Try
            If conn.State = ConnectionState.Closed Then Connect()
            '
            ' VARIÁVEIS DO COMMAND
            cmd = New SqlCommand
            cmd.Connection = conn
            cmd.CommandText = strCmdTxt
            cmd.CommandType = CommandType.Text
            '
            If Not isTran Then
                'EXECUTA QUERY
                intRows = cmd.ExecuteNonQuery()
                ' Close Connection
                CloseConn()
            Else
                ' Add Active Transaction
                cmd.Transaction = trans
                'EXECUTA QUERY
                intRows = cmd.ExecuteNonQuery()
            End If
            '
        Catch ex As Exception
            '
            Throw ex
            '
        End Try
        '
        ' RETORNA A QUANTIDADE DE REGISTROS
        If intRows > 0 Then
            ExecuteQuery = True
        Else
            ExecuteQuery = False
        End If
        '
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    ' EXECUTAR UM COMMAND E OBTER DATAREADER
    '----------------------------------------------------------------------------
    Public Function ExecuteAndGetReader(ByVal strCmdTxt As String) As SqlDataReader
        '
        If conn.State = ConnectionState.Closed Then
            Try
                Connect()
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '
        cmd = New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = strCmdTxt
        cmd.CommandType = CommandType.Text
        '
        Try
            '
            If Not isTran Then
                Return cmd.ExecuteReader
            Else
                cmd.Transaction = trans
                Return cmd.ExecuteReader
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
    ' EXECUTAR UM PROCEDURE COM PARÂMETROS
    '----------------------------------------------------------------------------
    Public Function ExecuteProcedure(ByVal myProcedureName As String,
                                     Optional ByVal myParam As SqlParameterCollection = Nothing) As String
        '
        If conn.State = ConnectionState.Closed Then
            Try
                Connect()
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '
        cmd = New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = myProcedureName
        cmd.CommandType = CommandType.StoredProcedure
        '
        If Not IsNothing(myParam) Then
            For i As Integer = 0 To myParam.Count - 1
                cmd.Parameters.AddWithValue(myParam(i).ParameterName, myParam(i).Value)
            Next i
        End If
        '
        Try
            '
            If Not isTran Then
                Return cmd.ExecuteScalar
            Else
                cmd.Transaction = trans
                Return cmd.ExecuteScalar
            End If
            '
        Catch ex As SqlException
            '
            Throw ex
            '
        Finally
            '
            '--- CLOSE DB CONNECTION
            CloseConn()
            '
        End Try
        '
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    ' EXECUTAR UM PROCEDURE COM PARÂMETROS E OBTER O IDENTITY
    '----------------------------------------------------------------------------
    Public Function ExecuteProcedureID(ByVal myProcedureName As String,
                                       Optional ByVal myParam As SqlParameterCollection = Nothing) As String
        '
        Try
            If conn.State = ConnectionState.Closed Then Connect()
            '
            cmd = New SqlCommand
            cmd.Connection = conn
            cmd.CommandText = myProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            '
            If Not IsNothing(myParam) Then
                For i As Integer = 0 To myParam.Count - 1
                    cmd.Parameters.AddWithValue(myParam(i).ParameterName, myParam(i).Value)
                Next i
            End If
            '
            If Not isTran Then
                Return cmd.ExecuteScalar
            Else
                cmd.Transaction = trans
                Return cmd.ExecuteScalar
            End If
            '
        Catch ex As Exception
            '
            Throw ex
            '
        Finally
            '
            '--- CLOSE DB CONNECTION
            CloseConn()
            '
        End Try
        '
    End Function
    '
    '-------------------------------------------------------------------------------------------------------
    ' EXECUTAR UM COMMAND E OBTER DATATABLE
    '----------------------------------------------------------------------------
    Public Function ExecuteConsultaSQL_DataTable(nomeStoredProcedureOuTextoSQL As String,
                                                 Optional ByVal myParam As SqlParameterCollection = Nothing) As DataTable
        Try
            '--- Abre a conexão
            If conn.State = ConnectionState.Closed Then Connect()
            '
            '--- cria o commando
            cmd = conn.CreateCommand
            If IsNothing(myParam) Then
                cmd.CommandType = CommandType.Text
            Else
                cmd.CommandType = CommandType.StoredProcedure
                For Each sqlparameter As SqlParameter In myParam
                    'cmd.Parameters.Add(New SqlParameter(sqlparameter.ParameterName, sqlparameter.Value))
                    cmd.Parameters.AddWithValue(sqlparameter.ParameterName, sqlparameter.Value)
                Next
            End If
            cmd.CommandText = nomeStoredProcedureOuTextoSQL
            cmd.CommandTimeout = 1800
            '
            '--- verifica transaction
            If isTran Then cmd.Transaction = trans
            '
            '--- cria o Adapter e o DataTable
            Dim sqlDtAdapter As New SqlDataAdapter(cmd)
            Dim dtTable As New DataTable
            '
            '--- preenche o DataTable
            sqlDtAdapter.Fill(dtTable)
            '
            '--- close Connection if not Transaction
            If Not isTran Then CloseConn()
            '
            '--- Retorna
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
    '----------------------------------------------------------------------------
    ' EXECUTAR UM COMMAND E OBTER DATATABLE COM LIMITES DE REGISTROS
    '----------------------------------------------------------------------------
    Public Function ExecuteQueryLimited_Dt(QuerySQL As String,
                                           ByVal startRecord As Integer,
                                           ByVal maxRecords As Integer,
                                           Optional ByRef countTotal As Integer = 0) As DataTable
        Try
            '--- Abre a conexão
            If conn.State = ConnectionState.Closed Then Connect()
            '
            '--- GET NUMBER OF RECORDS
            '----------------------------------------------------------------------------
            '--- Get the COUNT query
            Dim fromPosition As Integer = QuerySQL.IndexOf("FROM")
            Dim countQuery As String = QuerySQL.Substring(fromPosition)
            countQuery = "SELECT COUNT(*) " + countQuery
            '
            '--- cria o commando
            cmd = conn.CreateCommand
            cmd.CommandType = CommandType.Text
            '
            '--- add params
            ParamList.ForEach(Sub(p) cmd.Parameters.Add(p))
            '
            cmd.CommandText = countQuery
            cmd.CommandTimeout = 1800
            '
            '--- cria o Adapter e o DataTable
            Dim sqlDtAdapter As New SqlDataAdapter(cmd)
            Dim dtCount As New DataTable
            '
            sqlDtAdapter.Fill(dtCount)
            '
            If dtCount.Rows.Count > 0 Then
                '
                Dim resp As Object = dtCount.Rows(0)(0)
                '
                If IsNumeric(resp) Then
                    countTotal = resp
                Else
                    Throw New Exception(resp.ToString)
                End If
                '
            Else
                Throw New Exception("Não houver retorno na contagem de registros...")
            End If
            '
            '--- return nothing if NO RECORDS
            If countTotal = 0 Then
                CloseConn()
                Return Nothing
            End If
            '
            cmd.Parameters.Clear()
            cmd.Dispose()
            '
            '--- RETURN ALL RECORDS
            '----------------------------------------------------------------------------
            '--- cria o commando
            cmd = conn.CreateCommand
            cmd.CommandType = CommandType.Text
            '
            '--- add params
            ParamList.ForEach(Sub(p) cmd.Parameters.Add(p))
            '
            cmd.CommandText = QuerySQL
            cmd.CommandTimeout = 1800
            sqlDtAdapter = New SqlDataAdapter(cmd)
            '
            Dim dt As New DataTable
            '
            '--- preenche o DataTable
            sqlDtAdapter.Fill(startRecord, maxRecords, dt)
            '
            '--- close Connection if not Transaction
            CloseConn()
            '
            '--- Retorna
            Return dt
            '
        Catch ex As Exception
            '
            CloseConn()
            Throw ex
            '
        End Try
        '
    End Function
#End Region '/ COMMANDS QUERY | INSERT | UPDATE | DELETE
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
