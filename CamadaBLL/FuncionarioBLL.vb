Imports CamadaDTO
Imports CamadaDAL
Imports System.Data.SqlClient
'
Public Class FuncionarioBLL
    '
    '=====================================================================================================
    ' GET LIST OF
    '=====================================================================================================
    Public Function GetFuncionarios() As List(Of clFuncionario)
        '
        Dim objdb As New AcessoDados
        Dim strSql As String = ""

        strSql = "SELECT * FROM qryFuncionario"

        Dim dr As SqlDataReader = objdb.ExecuteAndGetReader(strSql)
        Dim lista As New List(Of clFuncionario)
        While dr.Read
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
        End While
        dr.Close()
        Return lista
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
            Return objdb.ExecuteConsultaSQL_DataTable(strSql)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '=====================================================================================================
    ' UPDATE
    '=====================================================================================================
    Public Function AtualizaFuncionario_Procedure_ID(ByVal _func As clFuncionario) As Long
        Dim objDB As New AcessoDados
        '
        objDB.LimparParametros()
        '
        'Adiciona os Parâmetros
        objDB.AdicionarParametros("@IDPessoa", _func.IDPessoa)
        objDB.AdicionarParametros("@Cadastro", _func.Cadastro)
        objDB.AdicionarParametros("@CPF", _func.CPF)
        objDB.AdicionarParametros("@Sexo", _func.Sexo)
        objDB.AdicionarParametros("@NascimentoData", _func.NascimentoData)
        objDB.AdicionarParametros("@Identidade", _func.Identidade)
        objDB.AdicionarParametros("@IdentidadeOrgao", _func.IdentidadeOrgao)
        objDB.AdicionarParametros("@IdentidadeData", _func.IdentidadeData)
        objDB.AdicionarParametros("@Endereco", _func.Endereco)
        objDB.AdicionarParametros("@Bairro", _func.Bairro)
        objDB.AdicionarParametros("@Cidade", _func.Cidade)
        objDB.AdicionarParametros("@UF", _func.UF)
        objDB.AdicionarParametros("@CEP", _func.CEP)
        objDB.AdicionarParametros("@TelefoneA", _func.TelefoneA)
        objDB.AdicionarParametros("@TelefoneB", _func.TelefoneB)
        objDB.AdicionarParametros("@Email", _func.Email)
        objDB.AdicionarParametros("@AdmissaoData", _func.AdmissaoData)
        objDB.AdicionarParametros("@Ativo", _func.Ativo)
        objDB.AdicionarParametros("@Vendedor", _func.Vendedor)
        objDB.AdicionarParametros("@ApelidoFuncionario", _func.ApelidoFuncionario)
        objDB.AdicionarParametros("@IDFilial", _func.IDFilial)
        objDB.AdicionarParametros("@Comissao", _func.Comissao)
        objDB.AdicionarParametros("@VendaTipo", _func.VendaTipo)
        objDB.AdicionarParametros("@VendedorAtivo", _func.VendedorAtivo)
        '
        Try
            Return objDB.ExecutarManipulacao(CommandType.StoredProcedure, "uspFuncionario_Alterar")
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
    End Function
    '
    '=====================================================================================================
    ' INSERT
    '=====================================================================================================
    Public Function SalvaNovoFuncionario_Procedure_ID(ByVal _func As clFuncionario) As Long
        Dim objDB As New AcessoDados

        'Adiciona os Parâmetros
        objDB.AdicionarParametros("@Cadastro", _func.Cadastro)
        objDB.AdicionarParametros("@CPF", _func.CPF)
        objDB.AdicionarParametros("@Sexo", _func.Sexo)
        objDB.AdicionarParametros("@NascimentoData", _func.NascimentoData)
        objDB.AdicionarParametros("@Identidade", _func.Identidade)
        objDB.AdicionarParametros("@IdentidadeOrgao", _func.IdentidadeOrgao)
        objDB.AdicionarParametros("@IdentidadeData", _func.IdentidadeData)
        objDB.AdicionarParametros("@Endereco", _func.Endereco)
        objDB.AdicionarParametros("@Bairro", _func.Bairro)
        objDB.AdicionarParametros("@Cidade", _func.Cidade)
        objDB.AdicionarParametros("@UF", _func.UF)
        objDB.AdicionarParametros("@CEP", _func.CEP)
        objDB.AdicionarParametros("@TelefoneA", _func.TelefoneA)
        objDB.AdicionarParametros("@TelefoneB", _func.TelefoneB)
        objDB.AdicionarParametros("@Email", _func.Email)
        objDB.AdicionarParametros("@AdmissaoData", _func.AdmissaoData)
        objDB.AdicionarParametros("@Ativo", _func.Ativo)
        objDB.AdicionarParametros("@Vendedor", _func.Vendedor)
        objDB.AdicionarParametros("@ApelidoFuncionario", _func.ApelidoFuncionario)
        objDB.AdicionarParametros("@Comissao", _func.Comissao)
        objDB.AdicionarParametros("@VendaTipo", _func.VendaTipo)
        objDB.AdicionarParametros("@IDFilial", _func.IDFilial)
        'objDB.AdicionarParametros("@VendedorAtivo", _func.VendedorAtivo)) 'PADRAO 'TRUE'
        '
        Try
            Return objDB.ExecutarManipulacao(CommandType.StoredProcedure, "uspFuncionario_Inserir")
        Catch ex As Exception
            Throw ex
            Return Nothing
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

End Class
