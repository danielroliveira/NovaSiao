Imports CamadaDAL

Public Class EstoqueNormalizarBLL
	'
	'==========================================================================================
	'--- CHECK ESTOQUE NORMALIZADO BY PRODUTO AND FILIAL AND RETURN INTEGER
	'==========================================================================================
	Public Function GetEstoqueNormalizado(IDProduto As Integer, IDFilial As Integer) As Integer
		'
		Try
			Dim db As New AcessoDados
			'
			db.LimparParametros()
			db.AdicionarParametros("@IDProduto", IDProduto)
			db.AdicionarParametros("@IDFilial", IDFilial)
			'
			Dim query As String = "SELECT IDProduto, IDFilial, SUM(Quantidade) AS Estoque " &
								  "FROM qryEstoqueUnionTransacaoAjuste " &
								  "WHERE IDProduto = @IDProduto AND IDFilial = @IDFilial " &
								  "GROUP BY IDProduto, IDFilial"
			'
			Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, query)
			'
			If dt.Rows.Count = 0 Then
				Return 0
			End If
			'
			Return dt.Rows(0)("Estoque")
			'
		Catch ex As Exception
			Throw ex
		End Try
		'
	End Function
	'
End Class
