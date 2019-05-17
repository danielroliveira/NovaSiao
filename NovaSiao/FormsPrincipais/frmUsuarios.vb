Imports CamadaBLL
Imports CamadaDTO
Imports ComponentOwl.BetterListView
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class frmUsuarios
    Private _user As clUsuario
    Private listUser As List(Of clUsuario)
    Private WithEvents bindUser As New BindingSource
    Private _Sit As EnumFlagEstado '= 1:Registro Salvo; 2:Registro Alterado; 3:Novo registro
    Private AtivarImage As Image = My.Resources.Switch_ON_PEQ
    Private DesativarImage As Image = My.Resources.Switch_OFF_PEQ
    '
#Region "EVENTO LOAD E PROPRIEDADE SIT"
    Private Property Sit As EnumFlagEstado
        Get
            Return _Sit
        End Get
        Set(value As EnumFlagEstado)
            _Sit = value
            If _Sit = EnumFlagEstado.RegistroSalvo Then
                btnSalvar.Enabled = False
                btnNovo.Enabled = True
                btnExcluir.Enabled = True
                btnCancelar.Enabled = False
                lblIdUser.Text = Format(_user.IdUser, "0000")
                AtivoButtonImage()
                blvUsuarios.ReadOnly = False
            ElseIf _Sit = EnumFlagEstado.Alterado Then
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnExcluir.Enabled = True
                btnCancelar.Enabled = True
                AtivoButtonImage()
                blvUsuarios.ReadOnly = True
            ElseIf _Sit = EnumFlagEstado.NovoRegistro Then
                txtUsuarioApelido.Select()
                btnSalvar.Enabled = True
                btnNovo.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = True
                lblIdUser.Text = "NOVO"
                AtivoButtonImage()
                blvUsuarios.ReadOnly = True
            End If
        End Set
    End Property
    ' EVENTO LOAD
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim userBLL As New UsuarioBLL

        listUser = userBLL.GetUsuarios
        PreencheListagem()

        If listUser.Count > 0 Then
            bindUser.MoveFirst()
            _user = listUser(0)
            Sit = EnumFlagEstado.RegistroSalvo
        Else
            bindUser.AddNew()
            _user = New clUsuario
            Sit = EnumFlagEstado.NovoRegistro
        End If

        bindUser.DataSource = _user

        PreencheDataBindings()
        lblIdUser.Text = Format(_user.IdUser, "0000")

    End Sub
#End Region
    '
#Region "BINDIGNS"
    Private Sub PreencheDataBindings()
        ' ADICIONANDO O DATABINDINGS AOS CONTROLES TEXT
        ' OS COMBOS JA SÃO ADICIONADOS DATABINDINGS QUANDO CARREGA

        lblIdUser.DataBindings.Add("Text", bindUser, "IdUser")
        txtUsuarioApelido.DataBindings.Add("Text", bindUser, "UsuarioApelido", True, DataSourceUpdateMode.OnPropertyChanged)
        txtUsuarioSenha.DataBindings.Add("Text", bindUser, "UsuarioSenha", True, DataSourceUpdateMode.OnPropertyChanged)

        ' FORMATA OS VALORES DO DATABINDING
        AddHandler lblIdUser.DataBindings("Text").Format, AddressOf idFormatRG

        ' CARREGA OS COMBOBOX
        CarregaComboAcesso()

        ' ADD HANDLER PARA DATABINGS
        AddHandler _user.AoAlterar, AddressOf HandlerAoAlterar
    End Sub
    Private Sub idFormatRG(sender As Object, e As System.Windows.Forms.ConvertEventArgs)
        e.Value = Format(e.Value, "0000")
    End Sub
    Private Sub HandlerAoAlterar()
        If _user.RegistroAlterado = True And Sit = EnumFlagEstado.RegistroSalvo Then
            Sit = EnumFlagEstado.Alterado
        End If
    End Sub
    Private Sub CarregaComboAcesso()
        Dim dtAcesso As New DataTable
        'Adiciona todas as possibilidades de instrucao
        dtAcesso.Columns.Add("UsuarioAcesso")
        dtAcesso.Columns.Add("Acesso")
        dtAcesso.Rows.Add(New Object() {1, "Administrador"}) ' linha 1 - Administrador
        dtAcesso.Rows.Add(New Object() {2, "Usuário Senior"}) ' linha 2 - Usuário Senior
        dtAcesso.Rows.Add(New Object() {3, "Usuário Comum"}) ' linha 3 - Usuário Comum
        With cmbUsuarioAcesso
            .DataSource = dtAcesso
            .ValueMember = "UsuarioAcesso"
            .DisplayMember = "Acesso"
            .DataBindings.Add("SelectedValue", bindUser, "UsuarioAcesso", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
    End Sub
#End Region

#Region "LISTAGEM FORMATACAO"
    ' FORMATAR A LISTAGEM DE USUÁRIOS
    Private Sub PreencheListagem()
        'blvUsuarios.Clear()
        blvUsuarios.DataSource = listUser

        With blvUsuarios.Columns("IdUser") ' column 0
            .Width = 70
            .DisplayMember = "IdUser"
        End With
        With blvUsuarios.Columns("UsuarioApelido") ' column 1
            .Width = 120
            .DisplayMember = "UsuarioApelido"
        End With
        With blvUsuarios.Columns("UsuarioAcessoTx") ' column 2
            .Width = 130
        End With
        With blvUsuarios.Columns("UsuarioAcesso") ' column 3
            .Width = 0
            .DisplayMember = "UsuarioAcesso"
        End With
    End Sub
    ' ALTERA USUARIO QUANDO SELECIONA LISTAGEM
    Private Sub blvUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles blvUsuarios.SelectedIndexChanged
        If blvUsuarios.SelectedItems.Count > 0 AndAlso IsNumeric(blvUsuarios.SelectedItems(0).Text) Then
            ' procura o usuário selecionado

            bindUser.CurrencyManager.Position = listUser.FindIndex(Function(u) u.IdUser = blvUsuarios.SelectedItems(0).Text)
            _user = listUser.Find(Function(u) u.IdUser = blvUsuarios.SelectedItems(0).Text)
            ' refaz o binding
            bindUser.CancelEdit()
            bindUser.DataSource = _user
            ' ADD HANDLER PARA DATABINGS
            AddHandler _user.AoAlterar, AddressOf HandlerAoAlterar
            ' ALTERA O SIT
            Sit = EnumFlagEstado.RegistroSalvo
        End If
    End Sub

    ' ALTERA A COR DO HEADER DO LISTBOX
    Private Sub blvUsuarios_DrawColumnHeader(sender As Object, eventArgs As BetterListViewDrawColumnHeaderEventArgs) Handles blvUsuarios.DrawColumnHeader
        If eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 AndAlso
            eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0 Then
            ' Pode Colocar: AndAlso eventArgs.ColumnHeader.Index = 1 AndAlso

            Dim brush As Brush = New LinearGradientBrush(eventArgs.ColumnHeaderBounds.BoundsOuter, Color.Transparent, Color.FromArgb(100, Color.LightSlateGray), LinearGradientMode.Vertical)
            Dim p As Pen = New Pen(Color.SlateGray, 2)

            eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter)


            eventArgs.Graphics.DrawLine(p, eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x1
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Height, 'y1
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Width + eventArgs.ColumnHeaderBounds.BoundsOuter.X, 'x2
                                        eventArgs.ColumnHeaderBounds.BoundsOuter.Height) 'y2
            brush.Dispose()
            p.Dispose()
        End If
    End Sub
    ' ESCREVE OS TEXTOS DE TIPO DE ACESSO NA LISTAGEM
    Private Sub blvUsuarios_DrawItem(sender As Object, eventArgs As BetterListViewDrawItemEventArgs) Handles blvUsuarios.DrawItem
        If IsNumeric(eventArgs.Item.Text) Then
            eventArgs.Item.Text = Format(CInt(eventArgs.Item.Text), "0000")
        End If

        If eventArgs.Item.SubItems(3).Text = "1" Then
            eventArgs.Item.SubItems(2).Text = "Administrador"
        ElseIf eventArgs.Item.SubItems(3).Text = "2" Then
            eventArgs.Item.SubItems(2).Text = "Usuário Senior"
        ElseIf eventArgs.Item.SubItems(3).Text = "3" Then
            eventArgs.Item.SubItems(2).Text = "Usuário Comum"
        End If

    End Sub
#End Region

#Region "ACAO DOS BOTOES"
    ' ATIVAR OU DESATIVAR USUARIO BOTÃO
    Private Sub btnAtivo_Click(sender As Object, e As EventArgs) Handles btnAtivo.Click
        If Sit = EnumFlagEstado.NovoRegistro Then
            MessageBox.Show("Você não pode DESATIVAR um Usuário Novo", "Desativar Usuário",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If _user.UsuarioAtivo = True Then ' Usuário ativo
            If MessageBox.Show("Você deseja realmente DESATIVAR o Usuário:" & vbNewLine &
                        txtUsuarioApelido.Text.ToUpper, "Desativar Usuário", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _user.BeginEdit()
                _user.UsuarioAtivo = False
                AtivoButtonImage()
            End If
        ElseIf _user.UsuarioAtivo = False Then ' Usuário Inativo
            If MessageBox.Show("Você deseja realmente ATIVAR o Usuário:" & vbNewLine &
            txtUsuarioApelido.Text.ToUpper, "Ativar Usuário", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _user.BeginEdit()
                _user.UsuarioAtivo = True
                AtivoButtonImage()
            End If
        End If
    End Sub
    ' BOTÃO CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        If Sit = EnumFlagEstado.Alterado Then ' REGISTRO ALTERADO
            If MessageBox.Show("Deseja cancelar todas as alterações feitas no registro atual?",
                   "Cancelar Alterações", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                bindUser.CancelEdit()
                txtUsuarioApelido.Focus()
                Sit = EnumFlagEstado.RegistroSalvo
            End If
        ElseIf Sit = EnumFlagEstado.NovoRegistro Then ' REGISTRO NOVO
            If blvUsuarios.Items.Count = 0 Then Exit Sub

            Sit = EnumFlagEstado.RegistroSalvo
            _user = listUser(0)
            bindUser.CancelEdit()
            bindUser.DataSource = _user

            Dim itemsFound As BetterListViewItemCollection
            itemsFound = blvUsuarios.FindItemsWithText(lblIdUser.Text)
            blvUsuarios.SelectedItems.[Set](itemsFound)
        End If
    End Sub
    ' BOTÃO NOVO REGISTRO
    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        blvUsuarios.SelectedItems.Clear()

        _user = New clUsuario
        bindUser.DataSource = _user

        Sit = EnumFlagEstado.NovoRegistro
        lblIdUser.Text = "NOVO"
    End Sub
    ' BOTÃO FECHAR
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
        MostraMenuPrincipal()
    End Sub
    ' BOTÃO SALVAR
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If VerificaDados() = False Then Exit Sub

        'Verifica se a Senha tem 8 caracteres
        If txtUsuarioSenha.Text.Trim.Length <> 8 Then
            MessageBox.Show("O Campo SENHA precisa ter exatamente oito (8) caracteres...", "Senha",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuarioSenha.Focus()
            txtUsuarioSenha.SelectAll()
            Exit Sub
        End If

        Dim uBLL As New UsuarioBLL
        Dim newID As Integer

        If Sit = EnumFlagEstado.NovoRegistro Then
            Try
                newID = uBLL.SalvaNovoUsuario_Procedure_ID(_user)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        ElseIf Sit = EnumFlagEstado.Alterado Then
            Try
                newID = uBLL.AtualizaUsuario_Procedure_ID(_user)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If newID <> 0 Then
            _user.IdUser = newID
            bindUser.EndEdit()
            listUser = uBLL.GetUsuarios
            PreencheListagem()
            Sit = EnumFlagEstado.RegistroSalvo
            MessageBox.Show("Registro de Usuário salvo com sucesso!", "Registro Salvo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    ' VALIDA CAMPOS
    Private Function VerificaDados() As Boolean
        Dim f As New Utilidades
        If Not f.VerificaControlesForm(txtUsuarioApelido, "Apelido do Usuário", epValida) Then
            txtUsuarioApelido.Focus()
            Return False
        ElseIf Not f.VerificaControlesForm(txtUsuarioSenha, "Senha do Usuário", epValida) Then
            txtUsuarioSenha.Focus()
            Return False
        ElseIf Not f.VerificaControlesForm(cmbUsuarioAcesso, "Acesso do Usuário", epValida) Then
            cmbUsuarioAcesso.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    ' BOTÃO EXCLUIR
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If IsNothing(_user.IdUser) Then Exit Sub

        If MessageBox.Show("Você deseja realmente excluir o Usuário:" & vbNewLine & vbNewLine &
                           _user.UsuarioApelido.ToUpper & vbNewLine & vbNewLine &
                           "Essa operação não tem retorno!", "Excluir Usuário", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Dim uBLL As New UsuarioBLL

        Try
            uBLL.DeletaUsuario_PorID(_user.IdUser)
            MessageBox.Show("Usuário Excluído com sucesso!", "Usuário Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information)
            listUser = uBLL.GetUsuarios
            PreencheListagem()
            Sit = EnumFlagEstado.RegistroSalvo
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

    End Sub
#End Region

#Region "OUTRAS FUNCOES"
    ' VALIDAR OS COMBOS
    Private Sub ValidaCombos(sender As Object, e As CancelEventArgs) Handles cmbUsuarioAcesso.Validating

        If Not IsNothing(DirectCast(sender, ComboBox).SelectedValue) Then
            e.Cancel = False
        Else
            MessageBox.Show("O Valor digitado não existe na listagem" & vbNewLine &
                             "Favor escolher um item da listagem...", "Escolha um item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Sit <> EnumFlagEstado.NovoRegistro AndAlso Not String.IsNullOrEmpty(DirectCast(sender, ComboBox).Text) Then
                e.Cancel = True
                DirectCast(sender, ComboBox).Focus()
                SendKeys.Send("%{DOWN}")
            End If
        End If
    End Sub

    ' ALTERA A IMAGEM E O TEXTO DO BOTÃO ATIVO E DESATIVO
    Private Sub AtivoButtonImage()
        If _user.UsuarioAtivo = True Then ' Nesse caso é Cliente Ativo
            btnAtivo.Image = AtivarImage
            btnAtivo.Text = "Usuário Ativo"
        ElseIf _user.UsuarioAtivo = False Then ' Nesse caso é Cliente Inativo
            btnAtivo.Image = DesativarImage
            btnAtivo.Text = "Usuário Inativo"
        End If
    End Sub
#End Region
End Class
