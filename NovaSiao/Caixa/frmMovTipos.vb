Imports CamadaBLL
Imports ComponentOwl.BetterListView
Imports System.Drawing.Drawing2D
'
Public Class frmMovTipos
    '
    Private WithEvents dtTipos As DataTable
    Private WithEvents bindTipo As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    '
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
#Region "EVENTO LOAD E PROPRIEDADE SIT"
    '
    Private Property Sit As EnumFlagEstado
        '
        Get
            Return _Sit
        End Get
        '
        Set(value As EnumFlagEstado)
            '
            _Sit = value
            '
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False
                lstFormas.ReadOnly = False
                '
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnExcluir.Enabled = True
                btnCancelar.Enabled = True
                lstFormas.ReadOnly = True
                '
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtMovTipo.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = True
                lstFormas.ReadOnly = True
                '
            End If
            '
        End Set
        '
    End Property
    '
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '
        ObterDados()
        bindTipo.DataSource = dtTipos
        '
        If dtTipos.Rows.Count > 0 Then
            bindTipo.MoveFirst()
            PreencheDataBindings()
            Sit = EnumFlagEstado.RegistroSalvo
        Else
            bindTipo.AddNew()
            Sit = EnumFlagEstado.NovoRegistro
            PreencheDataBindings()
        End If
        '
        PreencheListagem()
        '
    End Sub
    '
    Private Sub ObterDados()
        '
        Dim fBLL As New MovimentacaoBLL
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            dtTipos = fBLL.MovTipo_GET_Dt
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Obter a lista dos Tipos de Movimentação..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
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
        lblIDMovTipo.DataBindings.Add("Text", bindTipo, "IDMovTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        txtMovTipo.DataBindings.Add("Text", bindTipo, "MovTipo", True, DataSourceUpdateMode.OnPropertyChanged)
        lblIDMovTipo.DataBindings.Add("Tag", bindTipo, "Ativo")
        '
        ' CARREGA O COMBO
        CarregaComboMeio()
        '
        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIDMovTipo.DataBindings("Text").Format, AddressOf idFormatRG
        '
        ' ADD HANDLER PARA DATABINGS
        AddHandler bindTipo.BindingComplete, AddressOf Handler_AoAlterar '--- quando faz alteração
        AddHandler bindTipo.CurrentChanged, AddressOf handler_CurrentChanged '---muda de registro
        '
    End Sub
    '
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(IIf(IsDBNull(e.Value), Nothing, e.Value), "00")
    End Sub
    '
    Private Sub Handler_AoAlterar(ByVal sender As Object,
                                  ByVal e As BindingCompleteEventArgs)
        '

        If Sit = EnumFlagEstado.RegistroSalvo Then
            '
            If e.BindingCompleteContext = BindingCompleteContext.DataSourceUpdate Then
                Sit = EnumFlagEstado.Alterado
            End If
            '
        End If
        '
    End Sub
    '
    Private Sub handler_CurrentChanged()
        '
        '--- Clear the Error Provider
        epValida.Clear()
        '
        '--- Nesse caso é um novo registro
        If Not IsDBNull(DirectCast(bindTipo.Current, DataRowView).Item("IDMovTipo")) Then
            '
            ' ALTERAR PARA REGISTRO SALVO
            Sit = EnumFlagEstado.RegistroSalvo
            '
            ' VERIFICA O ATIVO BUTTON
            AtivoButtonImage()
            '
        End If
        '
    End Sub
    '
    '--- COMBO MEIO
    Private Sub CarregaComboMeio()
        '
        Dim dtMeio As New DataTable
        'Adiciona todas as possibilidades de instrucao
        dtMeio.Columns.Add("IDMeio")
        dtMeio.Columns.Add("Meio")
        dtMeio.Rows.Add(New Object() {1, "Moeda"})
        dtMeio.Rows.Add(New Object() {2, "Cheque"})
        dtMeio.Rows.Add(New Object() {3, "Cartão"})
        '
        With cmbMeio
            .DataSource = dtMeio
            .ValueMember = "IDMeio"
            .DisplayMember = "Meio"
            .DataBindings.Add("SelectedValue", bindTipo, "IDMeio", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
        '
    End Sub
    '
#End Region
    '
#Region "LISTAGEM FORMATACAO"
    '
    ' FORMATAR A LISTAGEM
    Private Sub PreencheListagem()
        lstFormas.DataSource = bindTipo
        '
        With clnIDMovForma ' column 0
            .Width = 50
            .DisplayMember = "IDMovTipo"
        End With
        '
        With clnMovForma ' column 1
            .Width = 220
            .DisplayMember = "MovTipo"
        End With
        '
    End Sub
    '
    ' ALTERA A COR DO HEADER DO LISTBOX
    Private Sub lstFormas_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles lstFormas.DrawColumnHeader
        '
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
        '
    End Sub
    '
    ' ESCREVE OS TEXTOS DE TIPO DE ACESSO NA LISTAGEM
    Private Sub lstFormas_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles lstFormas.DrawItem
        '
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "00")
        End If
        '
    End Sub
#End Region
    '
#Region "ACAO DOS BOTOES"
    '
    ' ATIVAR OU DESATIVAR FORMA BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR um Novo Tipo de Movimentação", "Desativar Tipo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '
        If btnAtivo.Tag = True Then '---usuario ativo
            If MessageBox.Show("Você deseja realmente DESATIVAR a Forma de Entrada:" & vbNewLine &
            txtMovTipo.Text.ToUpper, "Desativar Forma", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        Else '---Usuário Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR a Forma de Entrada:" & vbNewLine &
            txtMovTipo.Text.ToUpper, "Ativar Forma", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        End If
        '
        lblIDMovTipo.Tag = Not lblIDMovTipo.Tag
        '
        If Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
        '
        AtivoButtonImage()
        '
    End Sub
    '
    ' BOTÃO CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        If Sit = EnumFlagEstado.Alterado Then ' REGISTRO ALTERADO
            If MessageBox.Show("Deseja cancelar todas as alterações feitas no registro atual?",
                               "Cancelar Alterações", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                '
                bindTipo.CancelEdit()
                txtMovTipo.Focus()
                AtivoButtonImage()
                Sit = EnumFlagEstado.RegistroSalvo
                '
            End If
        ElseIf Sit = EnumFlagEstado.NovoRegistro Then ' REGISTRO NOVO
            If lstFormas.Items.Count = 0 Then
                MessageBox.Show("Não é possível cancelar porque não existe outro registro." & vbNewLine &
                                "Se deseja sair apenas feche a janela!", "Cancelar Edição", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            bindTipo.RemoveCurrent()
            Sit = EnumFlagEstado.RegistroSalvo
            '
        End If
        '
    End Sub
    '
    ' BOTÃO NOVO REGISTRO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        '
        lstFormas.SelectedItems.Clear()
        '
        '---cria um novo DataRow com valores padrão
        Dim row As DataRow = dtTipos.NewRow
        row("Ativo") = True
        row("MovTipo") = ""
        '
        '---adiciona o NewROW
        dtTipos.Rows.Add(row)
        bindTipo.MoveLast()
        '
        '---altera o SIT
        Sit = EnumFlagEstado.NovoRegistro
        txtMovTipo.Focus()
        '
    End Sub
    '
    ' BOTÃO FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click, btnClose.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    '
    ' BOTÃO EXCLUIR
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        MsgBox("Ainda não implementado")
    End Sub
    '
#End Region
    '
#Region "SALVA REGISTRO"
    '
    '--- BTN SALVAR REGISTRO
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        '
        If VerificaDados() = False Then Exit Sub
        '
        Dim movBLL As New MovimentacaoBLL
        Dim row As DataRow = DirectCast(bindTipo.Current, DataRowView).Row
        '
        If Sit = EnumFlagEstado.NovoRegistro Then
            Try
                Dim newID As Int16 = movBLL.MovTipo_Inserir(row("MovTipo"), row("IDMeio"))
                '
                row("IDMovTipo") = newID
                lblIDMovTipo.DataBindings("Text").ReadValue()
                DirectCast(bindTipo.Current, DataRowView).Row.AcceptChanges()
                '
                Sit = EnumFlagEstado.RegistroSalvo
                '
                '---informa o usuário
                MessageBox.Show("Registro Inserido com sucesso!", "Registro Salvo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
            Catch ex As Exception
                MessageBox.Show("Esse Registro NÃO foi salvo com sucesso!" & vbNewLine &
                                ex.Message, "Exceção Inesperada",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            '
        ElseIf Sit = EnumFlagEstado.Alterado Then
            Try
                movBLL.MovTipo_Update(row("IDMovTipo"), row("MovTipo"), row("Ativo"), row("IDMeio"))
                '
                DirectCast(bindTipo.Current, DataRowView).Row.AcceptChanges()
                Sit = EnumFlagEstado.RegistroSalvo
                '
                '---informa o usuário
                MessageBox.Show("Registro Atualizado com sucesso!", "Registro Salvo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
            Catch ex As Exception
                MessageBox.Show("Esse Registro NÃO foi salvo com sucesso!" & vbNewLine &
                                ex.Message, "Exceção Inesperada",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        '
    End Sub
    '
    ' VERIFICA OS DADOS ANTES DE SALVAR
    Private Function VerificaDados() As Boolean
        '
        Dim r As DataRowView = bindTipo.Current
        '
        '--- verifica campo txtMovTipo
        If IsDBNull(r("MovTipo")) OrElse txtMovTipo.Text.Trim.Length = 0 Then
            MessageBox.Show("O campo DESCRIÇÃO não pode ficar vazio;" & vbCrLf &
                            "Favor preencher esse campo antes de Salvar o registro...",
                            "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            epValida.SetError(txtMovTipo, "Preencha esse Campo")
            txtMovTipo.Focus()
            Return False
        End If
        '
        '--- verifica combo meio de pagamento
        If IsDBNull(r("IDMeio")) OrElse cmbMeio.SelectedIndex = -1 Then
            MessageBox.Show("O campo MEIO DE PAGAMENTO não pode ficar vazio;" & vbCrLf &
                            "Favor preencher esse campo antes de Salvar o registro...",
                            "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            epValida.SetError(cmbMeio, "Preencha esse Campo")
            cmbMeio.Focus()
            Return False
        End If
        '
        '--- verifica duplicação de descricao movtipo
        For Each row In dtTipos.Rows
            If Not row.Equals(r.Row) Then
                If r("MovTipo").ToString.ToUpper = row("MovTipo").ToString.ToUpper Then
                    MessageBox.Show("A descrição do Tipo de Pagamento deve ser exclusiva..." & vbCrLf &
                                    "O campo descrição está DUPLICADO, favor usar uma descrição diferente.",
                                    "Campo Duplicado", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                    epValida.SetError(txtMovTipo, "Valor duplicado")
                    txtMovTipo.Focus()
                    Return False
                End If
            End If
        Next
        '
        Return True
        '
    End Function
    '
#End Region
    '
#Region "ATALHOS E FUNCOES UTILITARIAS"
    '
    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        '
        If lblIDMovTipo.Tag = True Then ' Nesse caso é Tipo Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Tipo Ativo"
        ElseIf lblIDMovTipo.Tag = False Then ' Nesse caso é Tipo Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Tipo Inativo"
        Else
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Tipo Ativo"
        End If
        '
    End Sub
    '
    '--- SUBSTITUI A TECLA (ENTER) PELA (TAB)
    Private Sub txtControl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMovTipo.KeyDown, txtMovTipo.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
        '
    End Sub
    '
#End Region
    '
End Class
