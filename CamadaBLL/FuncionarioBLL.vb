﻿Imports CamadaDTO
Imports CamadaDAL
'
Public Class FuncionarioBLL
    '
    '=====================================================================================================
    ' GET LIST OF
    '=====================================================================================================
    Public Function GetFuncionarios(Optional IDFilial As Integer? = Nothing,
                                    Optional Ativo As Boolean? = Nothing) As List(Of clFuncionario)
        '
        Try
            '
            Dim db As New AcessoDados
            Dim query As String = ""
            '
            query = "SELECT * FROM qryFuncionario "
            db.LimparParametros()
            '
            '--- INSERT PARAMETERS
            If Not IsNothing(IDFilial) Then
                db.AdicionarParametros("@IDFilial", IDFilial)
                query += " WHERE IDFilial = @IDFilial "
            End If
            '
            If Not IsNothing(Ativo) Then
                db.AdicionarParametros("@Ativo", Ativo)
                '
                If IsNothing(IDFilial) Then
                    query += " WHERE Ativo = @Ativo "
                Else
                    query += " AND Ativo = @Ativo "
                End If
                '
            End If
            '
            '--- INSERT ORDER BY
            query += " ORDER BY Cadastro"
            '
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
            Dim lista As New List(Of clFuncionario)
            If dt.Rows.Count = 0 Then Return lista
            '
            For Each dr As DataRow In dt.Rows
                Dim func As clFuncionario = New clFuncionario
                '
                func.IDPessoa = IIf(IsDBNull(dr("IDFuncionario")), Nothing, dr("IDFuncionario"))
                func.Cadastro = IIf(IsDBNull(dr("Cadastro")), String.Empty, dr("Cadastro"))
                func.CPF = IIf(IsDBNull(dr("CPF")), String.Empty, dr("CPF"))
                func.NascimentoData = IIf(IsDBNull(dr("NascimentoData")), Nothing, dr("NascimentoData"))
                func.Sexo = IIf(IsDBNull(dr("Sexo")), Nothing, dr("Sexo"))
                func.Identidade = IIf(IsDBNull(dr("Identidade")), String.Empty, dr("Identidade"))
                func.IdentidadeOrgao = IIf(IsDBNull(dr("IdentidadeOrgao")), String.Empty, dr("IdentidadeOrgao"))
                func.IdentidadeData = IIf(IsDBNull(dr("IdentidadeData")), Nothing, dr("IdentidadeData"))
                func.Endereco = IIf(IsDBNull(dr("Endereco")), String.Empty, dr("Endereco"))
                func.Bairro = IIf(IsDBNull(dr("Bairro")), String.Empty, dr("Bairro"))
                func.Cidade = IIf(IsDBNull(dr("Cidade")), String.Empty, dr("Cidade"))
                func.UF = IIf(IsDBNull(dr("UF")), String.Empty, dr("UF"))
                func.CEP = IIf(IsDBNull(dr("CEP")), String.Empty, dr("CEP"))
                func.TelefoneA = IIf(IsDBNull(dr("TelefoneA")), String.Empty, dr("TelefoneA"))
                func.TelefoneB = IIf(IsDBNull(dr("TelefoneB")), String.Empty, dr("TelefoneB"))
                func.Email = IIf(IsDBNull(dr("Email")), String.Empty, dr("Email"))
                func.AdmissaoData = IIf(IsDBNull(dr("AdmissaoData")), Nothing, dr("AdmissaoData"))
                func.Ativo = IIf(IsDBNull(dr("Ativo")), 0, dr("Ativo"))
                func.Vendedor = IIf(IsDBNull(dr("Vendedor")), Nothing, dr("Vendedor"))
                func.ApelidoFuncionario = IIf(IsDBNull(dr("ApelidoFuncionario")), String.Empty, dr("ApelidoFuncionario"))
                func.IDFilial = IIf(IsDBNull(dr("IDFilial")), Nothing, dr("IDFilial"))
                func.ApelidoFilial = IIf(IsDBNull(dr("ApelidoFilial")), String.Empty, dr("ApelidoFilial"))
                func.Comissao = IIf(IsDBNull(dr("Comissao")), Nothing, dr("Comissao"))
                func.VendaTipo = IIf(IsDBNull(dr("VendaTipo")), Nothing, dr("VendaTipo"))
                func.VendedorAtivo = IIf(IsDBNull(dr("VendedorAtivo")), Nothing, dr("VendedorAtivo"))
                lista.Add(func)
                '
            Next
            '
            dt.Dispose()
            '
            '--- RETURN
            Return lista
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '=====================================================================================================
    ' GET DATATABLE
    '=====================================================================================================
    Public Function GetFuncionarios_DT(Optional myWhere As String = "") As DataTable
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""
        '
        If Len(myWhere) = 0 Then
            strSql = "SELECT * FROM qryFuncionario"
        Else
            If Left(myWhere, 8) = "ORDER BY" Then
                strSql = "SELECT * FROM qryFuncionario " & myWhere
            Else
                strSql = "SELECT * FROM qryFuncionario WHERE " & myWhere
            End If
        End If
        '
        Try
            Return objdb.ExecutarConsulta(CommandType.Text, strSql)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '=====================================================================================================
    ' DELETE
    '=====================================================================================================
    Public Function DeletaFuncionario_PorID(ByVal _IDFuncionario As Long) As Boolean
        MsgBox("Ainda não implementado")
        Return False
    End Function
    '
    '=====================================================================================================
    ' GET QTDE DE VENDAS POR VENDEDOR 
    '=====================================================================================================
    Public Function FuncionarioVendedor_GetVendas(myID As Integer) As Integer?
        Dim SQL As New SQLControl
        Dim r As DataRow
        '
        Try
            SQL.ExecQuery("SELECT COUNT(IDVendedor) AS RETORNO FROM tblVenda WHERE IDVendedor = 1")
            '
            If SQL.HasException(True) Then
                Return Nothing
            End If
            '
            r = SQL.DBDT.Rows(0)
            '
            Return CInt(r("Retorno"))
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
End Class
