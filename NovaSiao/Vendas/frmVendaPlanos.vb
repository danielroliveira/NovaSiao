Imports CamadaBLL
Imports ComponentOwl.BetterListView
Imports System.Drawing.Drawing2D
'
Public Class frmVendaPlanos
	'
	Private dtPlanos As DataTable
	Private mySQL As New SQLControl
	Private WithEvents bindPlanos As New BindingSource
	Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
	'
	Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
	Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
	'
#Region "EVENTO LOAD E PROPRIEDADE SIT"
	Private Property Sit As EnumFlagEstado
		'
		Get
			Return _Sit
		End Get
		'
		Set(value As EnumFlagEstado)
			_Sit = value
			If _Sit = EnumFlagEstado.RegistroSalvo Then
				btnSalvar.Enabled = False
				btnNovo.Enabled = True
				btnExcluir.Enabled = True
				btnCancelar.Enabled = False
				AtivoButtonImage()
				lstPlanos.ReadOnly = False
			ElseIf _Sit = EnumFlagEstado.Alterado Then
				btnSalvar.Enabled = True
				btnNovo.Enabled = False
				btnExcluir.Enabled = True
				btnCancelar.Enabled = True
				AtivoButtonImage()
				lstPlanos.ReadOnly = True
			ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
				txtPlano.Select()
				btnSalvar.Enabled = True
				btnNovo.Enabled = False
				btnExcluir.Enabled = False
				btnCancelar.Enabled = True
				AtivoButtonImage()
				lstPlanos.ReadOnly = True
			End If
		End Set
		'
	End Property
	'
	' EVENTO LOAD
	Private Sub frmVendaPlanos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'
		mySQL.ExecQuery("SELECT * FROM tblVendaPlanos")
		dtPlanos = mySQL.DBDT
		'
		bindPlanos.DataSource = dtPlanos
		PreencheListagem()
		AddHandler bindPlanos.PositionChanged, AddressOf Handler_PositionChanged
		'
		If dtPlanos.Rows.Count > 0 Then
			bindPlanos.MoveFirst()
			Sit = EnumFlagEstado.RegistroSalvo
			PreencheDataBindings()
			Handler_PositionChanged()
		Else
			PreencheDataBindings()
			btnNovo_Click(New Object, New EventArgs)
		End If
		'
		bindPlanos.ResetCurrentItem()
		'
		' ADD HANDLER PARA DATATABLE
		AddHandler dtPlanos.ColumnChanging, AddressOf Handler_ColumnChanging
		'
		'---Cria os Tooltips
		Criar_Tooltips()
		'
	End Sub
	'
#End Region
	'
#Region "BINDIGNS"
	'
	Private Sub PreencheDataBindings()
		' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
		' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA
		'
		lblIDPlano.DataBindings.Add("Text", bindPlanos, "IDPlano", True, DataSourceUpdateMode.OnPropertyChanged)
		txtPlano.DataBindings.Add("Text", bindPlanos, "Plano", True, DataSourceUpdateMode.OnPropertyChanged)
		txtComJuros.DataBindings.Add("Text", bindPlanos, "ComJuros", True, DataSourceUpdateMode.OnPropertyChanged)
		txtMeses.DataBindings.Add("Text", bindPlanos, "Meses", True, DataSourceUpdateMode.OnPropertyChanged)
		rbtComEntradaSim.DataBindings.Add("Checked", bindPlanos, "Entrada", True, DataSourceUpdateMode.OnPropertyChanged)
		'
		' FORMATA OS VALORES DO DATABINDING
		AddHandler lblIDPlano.DataBindings("Text").Format, AddressOf idFormatRG
		AddHandler txtMeses.DataBindings("Text").Format, AddressOf idFormatRG
		AddHandler txtComJuros.DataBindings("Text").Format, AddressOf idFormatCur
		'
	End Sub
	'
	Private Sub idFormatRG(sender As Object, e As ConvertEventArgs)
		e.Value = Format(IIf(IsDBNull(e.Value), Nothing, e.Value), "00")
	End Sub
	'
	Private Sub idFormatCur(sender As Object, e As ConvertEventArgs)
		e.Value = Format(IIf(IsDBNull(e.Value), Nothing, e.Value), "0.00")
	End Sub
	'
	Private Sub Handler_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs)
		If Sit = EnumFlagEstado.RegistroSalvo Then
			Sit = EnumFlagEstado.Alterado
		End If
	End Sub
	'
	Private Sub Handler_PositionChanged()
		If rbtComEntradaSim.Checked = False Then rbtComEntradaNao.Checked = True
	End Sub
	'
#End Region
	'
#Region "LISTAGEM FORMATACAO"
	' FORMATAR A LISTAGEM
	Private Sub PreencheListagem()
		lstPlanos.DataSource = bindPlanos
		'
		With lstPlanos.Columns("clnIDPlano") ' column 0
			.Width = 50
			.DisplayMember = "IDPlano"
		End With
		'
		With lstPlanos.Columns("clnPlano") ' column 1
			.Width = 220
			.DisplayMember = "Plano"
		End With
		'
	End Sub
	' ALTERA USUARIO QUANDO SELECIONA LISTAGEM
	Private Sub lstPlanos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPlanos.SelectedIndexChanged
		'
		If lstPlanos.SelectedItems.Count > 0 AndAlso IsNumeric(lstPlanos.SelectedItems(0).Text) Then
			'
			'---procura o usuário selecionado
			bindPlanos.CancelEdit()
			'bindPlanos.Position = bindPlanos.Find("IDPlano", lstPlanos.SelectedItems(0).Text)
			'
			'---ALTERA O SIT
			Sit = EnumFlagEstado.RegistroSalvo
		End If
		'
	End Sub

	' ALTERA A COR DO HEADER DO LISTBOX
	Private Sub lstPlanos_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstPlanos.DrawColumnHeader
		If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso
			eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
			' Pode Colocar: AndAlso eventArgs.ColumnHeader.Index = 1 AndAlso
			'
			Dim brush As Brush = New LinearGradientBrush(eventArgs.ColumnHeaderBounds.BoundsOuter, Color.Transparent, Color.FromArgb(100, Color.LightSlateGray), LinearGradientMode.Vertical)
			Dim p As Pen = New Pen(Color.SlateGray, 2)
			'
			eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)
			'
			eventArgs.Graphics.DrawLine(p, eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x1
										eventArgs.ColumnHeaderBounds.BoundsOuter.Height, 'y1
										eventArgs.ColumnHeaderBounds.BoundsOuter.Width + eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x2
										eventArgs.ColumnHeaderBounds.BoundsOuter.Height) 'y2
			brush.Dispose()
			p.Dispose()
		End If
	End Sub
	' ESCREVE OS TEXTOS DE TIPO DE ACESSO NA LISTAGEM
	Private Sub lstFormas_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstPlanos.DrawItem
		If IsNumeric(eventArgs.Item.Text) Then
			eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "00")
		End If
	End Sub
#End Region
	'
#Region "ACAO DOS BOTOES"
	'
	' ATIVAR OU DESATIVAR USUARIO BOTÃO
	Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
		If Sit = EnumFlagEstado.NovoRegistro Then
			MessageBox.Show("Você não pode DESATIVAR um Plano Novo", "Desativar Plano",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If
		'
		Dim r As DataRow = dtPlanos.Rows(bindPlanos.Position)
		'
		If r("Ativo") = True Then '---usuario ativo
			If MessageBox.Show("Você deseja realmente DESATIVAR o Plano:" & vbNewLine &
			txtPlano.Text.ToUpper, "Desativar Plano", MessageBoxButtons.YesNo,
			MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
		Else '---Usuário Inativo
			If MessageBox.Show("Você deseja realmente ATIVAR o Plano:" & vbNewLine &
			txtPlano.Text.ToUpper, "Desativar Plano", MessageBoxButtons.YesNo,
			MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
		End If
		'
		r("Ativo") = Not r("Ativo")
		'
		If Sit = EnumFlagEstado.RegistroSalvo Then
			Sit = EnumFlagEstado.Alterado
		End If
		'
		AtivoButtonImage()
	End Sub
	'
	' BOTÃO CANCELAR
	Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
		If Sit = EnumFlagEstado.Alterado Then ' REGISTRO ALTERADO
			If MessageBox.Show("Deseja cancelar todas as alterações feitas no registro atual?",
				   "Cancelar Alterações", MessageBoxButtons.YesNo,
				   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
			bindPlanos.CancelEdit()
			dtPlanos.RejectChanges()
			txtPlano.Focus()
			Sit = EnumFlagEstado.RegistroSalvo
			Handler_PositionChanged()
		ElseIf Sit = EnumFlagEstado.NovoRegistro Then ' REGISTRO NOVO
			If lstPlanos.Items.Count = 1 Then
				MessageBox.Show("Não é possível cancelar porque não existe outro registro." & vbNewLine &
								"Se deseja sair apenas feche a janela!", "Cancelar Edição", MessageBoxButtons.OK,
								MessageBoxIcon.Information)
				Exit Sub
			End If
			'
			Sit = EnumFlagEstado.RegistroSalvo
			Handler_PositionChanged()
			bindPlanos.RemoveCurrent()
			bindPlanos.MoveFirst()
			'
		End If
	End Sub
	'
	' BOTÃO NOVO REGISTRO
	Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
		'
		'---cria um novo DataRow com valores padrão
		Dim row As DataRow
		row = dtPlanos.NewRow()
		row("Ativo") = True
		row("Meses") = 1
		row("ComJuros") = Format(0, "0.00")
		row("Entrada") = False
		'
		'---adiciona o NewROW
		dtPlanos.Rows.Add(row)
		bindPlanos.MoveLast()
		'
		'---altera o SIT
		Sit = EnumFlagEstado.NovoRegistro
		'
	End Sub
	'
	' BOTÃO FECHAR
	Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
		Close()
		MostraMenuPrincipal()
	End Sub
	'
	' BOTÃO SALVAR
	Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
		'
		If VerificaDados() = False Then Exit Sub
		'
		'---adiciona os parâmentros
		mySQL.AddParam("@IDPlano", lblIDPlano.Text)
		mySQL.AddParam("@Plano", txtPlano.Text)
		mySQL.AddParam("@Entrada", dtPlanos.Rows(bindPlanos.Position)("Entrada"))
		Dim dblComissao As Double
		mySQL.AddParam("@ComJuros", IIf(Double.TryParse(txtComJuros.Text, dblComissao), dblComissao, DBNull.Value))
		mySQL.AddParam("@Meses", IIf(String.IsNullOrEmpty(txtMeses.Text), DBNull.Value, txtMeses.Text))
		mySQL.AddParam("@Ativo", dtPlanos.Rows(bindPlanos.Position)("Ativo"))
		'
		If Sit = EnumFlagEstado.NovoRegistro Then
			'
			'---salva o NOVO registro
			mySQL.ExecQuery("INSERT INTO tblVendaPlanos " &
							"(Plano, Entrada, ComJuros, Meses, Ativo) " &
							"VALUES (@Plano, @Entrada, @ComJuros, @Meses, @Ativo);", True)
			'
		ElseIf Sit = EnumFlagEstado.Alterado Then
			'
			'---atualiza o registro ALTERADO
			mySQL.ExecQuery("UPDATE tblVendaPlanos " &
							"SET Plano=@Plano, Entrada=@Entrada, ComJuros=@ComJuros, " &
							"Meses=@Meses, Ativo=@Ativo WHERE IDPlano=@IDPlano;")
			'
		End If
		'
		If mySQL.HasException(True) Then
			MessageBox.Show("Esse Registro NÃO foi salvo com sucesso!", "Erro ao Salvar",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Else
			'---retorna o novo ID
			If Sit = EnumFlagEstado.NovoRegistro Then
				If mySQL.DBDT.Rows.Count > 0 Then
					Dim r As DataRow = mySQL.DBDT.Rows(0)
					lblIDPlano.Text = Format(r("LastID"), "00")
				End If
			End If
			'
			'---finaliza a edição
			bindPlanos.EndEdit()
			PreencheListagem()
			Sit = EnumFlagEstado.RegistroSalvo
			'
			'---informa o usuário
			MessageBox.Show("Registro salvo com sucesso!", "Registro Salvo",
							MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
		'
	End Sub
	'
	' VALIDA CAMPOS
	Private Function VerificaDados() As Boolean
		'
		If IsNumeric(lblIDPlano.Text) AndAlso CInt(lblIDPlano.Text) = 0 Then
			'
			AbrirDialog("Não é possível alterar o primeiro plano: PERSONALIZADO." & vbNewLine &
						"Esse registro é padrão do sistema.",
						"Plano Padrão", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			'
			bindPlanos.CancelEdit()
			dtPlanos.RejectChanges()
			txtPlano.Focus()
			Sit = EnumFlagEstado.RegistroSalvo
			Handler_PositionChanged()
			'
			Return False
			'
		End If
		'
		Dim f As New Utilidades
		If Not f.VerificaControlesForm(txtPlano, "Descrição do Plano", epValida) Then
			Return False
		ElseIf Not f.VerificaControlesForm(txtMeses, "Número de Meses do Plano", epValida) Then
			Return False
		ElseIf Not f.VerificaControlesForm(txtComJuros, "Juros aplicado no Plano", epValida) Then
			Return False
		Else
			Return True
		End If
	End Function
	'
	' BOTÃO EXCLUIR
	Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
		MsgBox("Ainda não implementado")
	End Sub
#End Region
	'
#Region "OUTRAS FUNCOES"
	' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
	Private Sub AtivoButtonImage()
		Try
			If dtPlanos.Rows(bindPlanos.Position)("Ativo") = True Then ' Nesse caso é Plano Ativo
				btnAtivo.Image = AtivarImage
				btnAtivo.Text = "Forma Ativa"
			ElseIf dtPlanos.Rows(bindPlanos.Position)("Ativo") = False Then ' Nesse caso é Plano Inativo
				btnAtivo.Image = DesativarImage
				btnAtivo.Text = "Forma Inativa"
			End If
		Catch ex As System.IndexOutOfRangeException
			btnAtivo.Image = AtivarImage
			btnAtivo.Text = "Forma Ativa"
		End Try
	End Sub
	'
	Private Sub Criar_Tooltips()
		' Cria a ToolTip e associa com o Form container.
		Dim toolTip1 As New ToolTip()
		' Define o delay para a ToolTip.
		With toolTip1
			.AutoPopDelay = 5000
			.InitialDelay = 500
			.ReshowDelay = 500
			.IsBalloon = True
		End With
		' Força a o texto da ToolTip a ser exibido mesmo que o form não esta ativo
		toolTip1.ShowAlways = True
		' Define o texto da ToolTip para o Button, TextBox, Checkbox e Label
		toolTip1.SetToolTip(lblMeses, "Número de parcelas retirando a parcela da entrada")
		toolTip1.SetToolTip(lblJuros, "Valor da taxa de Juros a ser aplicada no parcelamento")
		toolTip1.SetToolTip(gbEntrada, "Marque sim se esse plano tem pagamento na Entrada")
	End Sub
#End Region
	'
End Class
