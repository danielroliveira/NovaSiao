Imports CamadaBLL
Imports CamadaDTO
'
Public Class frmCNPInserir
    '
    Private _formOrigem As Form = Nothing
    Private ExpectedType As String = ""
    Private _PessoaTipo As PessoaBLL.EnumPessoaGrupo
    Property propPessoa As Object
    '
#Region "SUB NEW | LOAD"
    '
    Sub New(PessoaTipo As PessoaBLL.EnumPessoaGrupo,
            Optional formOrigem As Form = Nothing,
            Optional CNPJ_or_CPF As String = "")
        '
        ' This call is required by the designer.
        InitializeComponent()
        '
        ' Add any initialization after the InitializeComponent() call.
        '
        _formOrigem = formOrigem '---> form will be changed color of panel1
        ExpectedType = CNPJ_or_CPF '---> define Type
        '
        propPessoaTipo = PessoaTipo
        '
    End Sub
    '
    ' EVENTO LOAD
    Private Sub frmCNPInserir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCNPJ.Focus()
    End Sub
    '
    '--- PESSOA TIPO PROPERTY
    '----------------------------------------------------------------------------------
    Private Property propPessoaTipo As PessoaBLL.EnumPessoaGrupo
        Get
            Return _PessoaTipo
        End Get
        Set(value As PessoaBLL.EnumPessoaGrupo)
            _PessoaTipo = value
            '
            Select Case _PessoaTipo
                Case PessoaBLL.EnumPessoaGrupo.CLIENTE
                    If ExpectedType = "CPF" Then
                        lblTitulo.Text = "Deseja inserir um Novo Cliente?"
                        lblSubtitulo.Text = "Informe o CPF do Novo Cliente..."
                    ElseIf ExpectedType = "CNPJ" Then
                        lblTitulo.Text = "Deseja inserir um Novo Cliente?"
                        lblSubtitulo.Text = "Informe o CNPJ do Novo Cliente..."
                    End If
                Case PessoaBLL.EnumPessoaGrupo.FORNECEDOR
                    lblTitulo.Text = "Deseja inserir um Novo Fornecedor?"
                    lblSubtitulo.Text = "Informe o CNPJ do Novo Fornecedor..."
                Case PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA
                    lblTitulo.Text = "Deseja inserir uma Nova Transportadora?"
                    lblSubtitulo.Text = "Informe o CNPJ da Nova Transportadora..."
                Case PessoaBLL.EnumPessoaGrupo.FUNCIONARIO
                    lblTitulo.Text = "Deseja inserir um Novo Funcionário?"
                    lblSubtitulo.Text = "Informe o CPF do Novo Funcionário..."
                Case PessoaBLL.EnumPessoaGrupo.CREDOR
                    If ExpectedType = "CPF" Then
                        lblTitulo.Text = "Deseja inserir um Novo Credor?"
                        lblSubtitulo.Text = "Informe o CPF do Novo Credor..."
                    ElseIf ExpectedType = "CNPJ" Then
                        lblTitulo.Text = "Deseja inserir um Novo Credor?"
                        lblSubtitulo.Text = "Informe o CNPJ do Novo Credor..."
                    End If
                Case PessoaBLL.EnumPessoaGrupo.FILIAL
                    lblTitulo.Text = "Deseja inserir uma Nova Filial?"
                    lblSubtitulo.Text = "Informe o CNPJ da Nova Filial..."
            End Select
            '
        End Set
        '
    End Property
    '
#End Region '/ SUB NEW | LOAD
    '
#Region "NAVEGACAO E FORMATACAO"
    '
    '--- SUPRIMIR A TECLA ENTER NO TXTCNPJ | ON PRESS DELETE CLEAR CNP
    '----------------------------------------------------------------------------------
    Private Sub txtCNPJ_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCNPJ.KeyDown
        '
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Delete Then
            txtCNPJ.Clear()
        End If
        '
    End Sub
    '
    ' FORMATAR A MÁSCARA DO CPF OU CNPJ
    '----------------------------------------------------------------------------------
    Private Sub txtCNPJ_Leave(sender As Object, e As EventArgs) Handles txtCNPJ.Leave
		'
		If txtCNPJ.Text.Trim.Length > 0 AndAlso IsNumeric(txtCNPJ.Text) Then
			Try
				txtCNPJ.Text = Utilidades.CNPConvert(txtCNPJ.Text)
			Catch ex As AppException
				AbrirDialog(ex.Message, "Valor Inválido", frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
			Catch ex As Exception
				'
				MessageBox.Show("Uma exceção ocorreu ao formatar CNP..." & vbNewLine &
								ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
				'
			End Try
		End If
		'
	End Sub
    '
    '--- ON ENTER RETIRA A FORMATACAO
    '----------------------------------------------------------------------------------
    Private Sub txtCNPJ_Enter(sender As Object, e As EventArgs) Handles txtCNPJ.Enter
        '
        If Not IsNumeric(txtCNPJ.Text) AndAlso txtCNPJ.Text.Length > 0 Then
            '
            Dim arr = txtCNPJ.Text.ToCharArray
            Dim newStr As String = ""

            For Each l In arr
                If Char.IsDigit(l) Then
                    newStr = newStr + l
                End If
            Next
            '
            txtCNPJ.Text = newStr
            '
        End If
        '
    End Sub
    '
    ' KEYPRESS PERMITE DIGITAR APENAS NUMEROS
    '----------------------------------------------------------------------------------
    Private Sub txtCNPJ_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCNPJ.KeyPress
        '
        ' NÃO PERMITIR DIGITAÇÃO DE LETRAS OU CONTROLES
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
            e.Handled = True
            lblNum.Text = "digite apenas números"
            lblNum.Visible = True
        End If
        '
        ' NÃO PERMITIR TEXTO MAIOR QUE 14 DÍGITOS
        If txtCNPJ.TextLength >= 14 And Char.IsNumber(e.KeyChar) Then
            e.Handled = True
            lblNum.Text = "CNPJ não pode ter mais do que 14 dígitos"
            lblNum.Visible = True
        End If
        '
    End Sub
    '
    '--- SELECIONAR CNP
    '----------------------------------------------------------------------------------
    Private Sub SelecionaTxtCNPJ()
        txtCNPJ.Focus()
        txtCNPJ.SelectAll()
    End Sub
    '
#End Region '/ NAVEGACAO E FORMATACAO
    '
#Region "FUNCOES INSERIR | BUTTONS"
    '
    '--- BUTTON OK
    '----------------------------------------------------------------------------------
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '
        '--- VERIFICA O NÚMERO DE DIGITOS CPF OU CNPJ
        If VerificaPermissaoCNP() = False Then Exit Sub
        '
        '--- VALIDAR O NÚMERO DE CPF OU CNPJ
        If ValidaCNP() = String.Empty Then Exit Sub
        '
        '--- VERIFICAR SE O CPF OU CNPJ JÁ ESTÁ CADASTRADO
        propPessoa = VerPessoaExistente()
        '
        '--- VERIFICA CNPJ RELACIONADO
        If IsNothing(propPessoa.IDPessoa) And txtCNPJ.TextLength = 18 Then
            If Not VerCNPJRelacionado() Then
                Exit Sub
            End If
        End If
        '
        '--- FECHAR FORMULÁRIO
        DialogResult = DialogResult.OK
        '
    End Sub
    '
    '--- VERIFICA PESSOA EXISTENTE RETORNA UM clClientePF ou PJ
    '----------------------------------------------------------------------------------
    Private Function VerPessoaExistente() As Object
        '
        Dim db As New PessoaBLL
        Dim myPessoa As Object = Nothing
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- PROCURA PESSOA PELO CNP
            myPessoa = db.ProcurarCNP_Pessoa(txtCNPJ.Text, propPessoaTipo)
            '
            '--- VERIFICA SE A PESSOA PROCURADA E PF OU PJ
            If txtCNPJ.TextLength = 14 Then ' PESSOA FISICA
                '
                '--- NÃO ENCOTROU NENHUM NO CPF/CNPJ RETORNA NEW PESSOA
                If IsNothing(myPessoa) Then
                    '
                    Select Case propPessoaTipo
                        Case PessoaBLL.EnumPessoaGrupo.CLIENTE
                            Dim pessoa As New clClientePF
                            pessoa.CPF = txtCNPJ.Text
                            Return pessoa
                        Case PessoaBLL.EnumPessoaGrupo.FUNCIONARIO
                            Dim pessoa As New clFuncionario
                            pessoa.CPF = txtCNPJ.Text
                            Return pessoa
                        Case PessoaBLL.EnumPessoaGrupo.CREDOR
                            Dim pessoa As New clCredor
                            pessoa.CNP = txtCNPJ.Text
                            pessoa.CredorTipo = 1
                            Return pessoa
                    End Select
                    '
                End If
                '
                '--- ENCONTROU UMA PESSOA FISICA CPF
                If TypeOf myPessoa Is clPessoaFisica Then
                    Dim PF As clPessoaFisica = DirectCast(myPessoa, clPessoaFisica)
                    Return PF
                End If
                '
                '--- ENCONTROU UMA PESSOA FISICA DO MESMO TIPO PROCURADO
                Select Case propPessoaTipo
                    Case PessoaBLL.EnumPessoaGrupo.CLIENTE
                        Dim pessoa As clClientePF = DirectCast(myPessoa, clClientePF)
                        Return pessoa
                    Case PessoaBLL.EnumPessoaGrupo.FUNCIONARIO
                        Dim pessoa As clFuncionario = DirectCast(myPessoa, clFuncionario)
                        Return pessoa
                    Case PessoaBLL.EnumPessoaGrupo.CREDOR
                        Dim pessoa As clCredor = DirectCast(myPessoa, clCredor)
                        Return pessoa
                End Select
                '
            ElseIf txtCNPJ.TextLength = 18 Then ' PESSOA JURIDICA
                '
                '--- NÃO ENCOTROU NENHUM NO CPF/CNPJ RETORNA NEW PESSOA
                If IsNothing(myPessoa) Then
                    '
                    Select Case propPessoaTipo
                        Case PessoaBLL.EnumPessoaGrupo.CLIENTE
                            Dim pessoa As New clClientePJ
                            pessoa.CNPJ = txtCNPJ.Text
                            Return pessoa
                        Case PessoaBLL.EnumPessoaGrupo.FORNECEDOR
                            Dim pessoa As New clFornecedor
                            pessoa.CNPJ = txtCNPJ.Text
                            Return pessoa
                        Case PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA
                            Dim pessoa As New clTransportadora
                            pessoa.CNPJ = txtCNPJ.Text
                            Return pessoa
                        Case PessoaBLL.EnumPessoaGrupo.CREDOR
                            Dim pessoa As New clCredor
                            pessoa.CredorTipo = 2
                            pessoa.CNP = txtCNPJ.Text
                            Return pessoa
                        Case PessoaBLL.EnumPessoaGrupo.FILIAL
                            Dim pessoa As New clFilial
                            pessoa.CNPJ = txtCNPJ.Text
                            Return pessoa
                    End Select
                    '
                End If
                '
                '--- ENCONTROU UMA PESSOA JURIDICA
                If TypeOf myPessoa Is clPessoaJuridica Then
                    Dim PJ As clPessoaJuridica = DirectCast(myPessoa, clPessoaJuridica)
                    Return PJ
                End If
                '
                '--- ENCONTROU UM PESSOA DO MESMO TIPO
                Select Case propPessoaTipo
                    Case PessoaBLL.EnumPessoaGrupo.CLIENTE
                        Dim pessoa As clClientePJ = DirectCast(myPessoa, clClientePJ)
                        Return pessoa
                    Case PessoaBLL.EnumPessoaGrupo.FORNECEDOR
                        Dim pessoa As clFornecedor = DirectCast(myPessoa, clFornecedor)
                        Return pessoa
                    Case PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA
                        Dim pessoa As clTransportadora = DirectCast(myPessoa, clTransportadora)
                        Return pessoa
                    Case PessoaBLL.EnumPessoaGrupo.CREDOR
                        Dim pessoa As clCredor = DirectCast(myPessoa, clCredor)
                        Return pessoa
                    Case PessoaBLL.EnumPessoaGrupo.FILIAL
                        Dim pessoa As clFilial = DirectCast(myPessoa, clFilial)
                        Return pessoa
                End Select
                '
            End If
            '
            '--- IF ANY CLASS WAS FIND
            Throw New AppException("Não foi retornado nenhum classe correspondente à pessoa...")
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao procurar CPF/CNPJ..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '    
    End Function
    '
    '--- VERIFICA PERMISSAO CNPJ OU CPF
    '----------------------------------------------------------------------------------
    Private Function VerificaPermissaoCNP() As Boolean

        '--- VERIFICA PERMISSAO CNPJ / CPF
        Dim CNPLenght As Integer = txtCNPJ.TextLength
        '
        If CNPLenght <> 14 AndAlso CNPLenght <> 18 Then
            AbrirDialog("Digite um número de CPF ou CNPJ Válido!", "CPF/CNPJ inválido",
                        frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
            SelecionaTxtCNPJ()
            Return False
        End If
        '
        Select Case propPessoaTipo
            '
            Case PessoaBLL.EnumPessoaGrupo.CLIENTE
                If ExpectedType = "CPF" AndAlso CNPLenght <> 14 Then
                    AbrirDialog("Digite um número de CPF Válido!", "CPF inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                ElseIf ExpectedType = "CNPJ" AndAlso CNPLenght <> 18 Then
                    AbrirDialog("Digite um número de CNPJ Válido!", "CNPJ inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                End If
            Case PessoaBLL.EnumPessoaGrupo.FUNCIONARIO
                If CNPLenght <> 14 Then
                    AbrirDialog("Digite um número de CPF Válido!", "CPF inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                End If
            Case PessoaBLL.EnumPessoaGrupo.FORNECEDOR
                If CNPLenght <> 18 Then
                    AbrirDialog("Digite um número de CNPJ Válido!", "CNPJ inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                End If
            Case PessoaBLL.EnumPessoaGrupo.TRANSPORTADORA
                If CNPLenght <> 18 Then
                    AbrirDialog("Digite um número CNPJ Válido!", "CNPJ inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                End If
            Case PessoaBLL.EnumPessoaGrupo.FILIAL
                If CNPLenght <> 18 Then
                    AbrirDialog("Digite um número CNPJ Válido!", "CNPJ inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                End If
            Case PessoaBLL.EnumPessoaGrupo.CREDOR
                If ExpectedType = "CPF" AndAlso CNPLenght <> 14 Then
                    AbrirDialog("Digite um número de CPF Válido!", "CPF inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                ElseIf ExpectedType = "CNPJ" AndAlso CNPLenght <> 18 Then
                    AbrirDialog("Digite um número de CNPJ Válido!", "CNPJ inválido",
                                frmDialog.DialogType.OK, frmDialog.DialogIcon.Exclamation)
                    SelecionaTxtCNPJ()
                    Return False
                End If
        End Select
        '
        Return True
        '
    End Function
    '
    '--- VALIDAR O NÚMERO DO CNPJ OU CPF
    '----------------------------------------------------------------------------------
    Private Function ValidaCNP() As String
        '
        Dim obj As New Valida_CPF_CNPJ
        '
        Try
            '
            If txtCNPJ.TextLength = 14 Then
                obj.cpf = txtCNPJ.Text
                If obj.isCpfValido = False Then
                    MessageBox.Show("O CPF digitado é inválido!", "CPF inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SelecionaTxtCNPJ()
                    Return String.Empty
                Else
                    Return "PF"
                End If
            ElseIf txtCNPJ.TextLength = 18 Then
                obj.cnpj = txtCNPJ.Text
                If obj.isCnpjValido = False Then
                    MessageBox.Show("O CNPJ digitado é inválido!", "CNPJ inválido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SelecionaTxtCNPJ()
                    Return String.Empty
                Else
                    Return "PJ"
                End If
            Else
                MessageBox.Show("Digite um número de CPF ou CNPJ Válido!", "CPF/CNPJ inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                SelecionaTxtCNPJ()
                Return String.Empty
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return String.Empty
        End Try
        '
    End Function
    '
    '--- VERIFICA SE O CNPJ ESTA RELACIONADO COM UMA PESSOA JURIDICA
    '----------------------------------------------------------------------------------
    Private Function VerCNPJRelacionado() As Boolean
        '
        Dim db As New PessoaBLL
        Dim Pessoa As Object = Nothing
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            '--- PROCURA CNPJ RELACIONADO PELO CNP
            Pessoa = db.ProcurarCNPJRelacionado(txtCNPJ.Text)
            If IsNothing(Pessoa) Then Return True
            '
            If AbrirDialog("Foi encontrado um registro desse CNPJ que está relacionado com o CNPJ de:" & vbNewLine &
                           Pessoa.Cadastro & vbNewLine &
                           "Deseja cadastrar esse novo CNPJ mesmo assim e remover a relação existente?",
                           "CNPJ Relacionado",
                           frmDialog.DialogType.SIM_NAO,
                           frmDialog.DialogIcon.Question,
                           frmDialog.DialogDefaultButton.Second) = DialogResult.No Then Return False
            '
            db.RemoverCNPJRelacionado(txtCNPJ.Text)
            Return True
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao Procurar CNPJ Relacionado..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            '
            '--- Ampulheta OFF
            Cursor = Cursors.Default
            '
        End Try
        '
    End Function
    '
    '--- BUTTON CANCELAR
    '----------------------------------------------------------------------------------
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        '
        DialogResult = DialogResult.Cancel
        '
        If Not IsNothing(_formOrigem) Then
            _formOrigem.Visible = True
        End If
        '
        If Application.OpenForms.Count() = 1 Then
            MostraMenuPrincipal()
        End If
        '
    End Sub
    '
#End Region '/ FUNCOES INSERIR | BUTTONS
    '
#Region "EFEITOS VISUAIS"
    '
    '-------------------------------------------------------------------------------------------------
    ' CRIAR EFEITO VISUAL DE FORM SELECIONADO
    '-------------------------------------------------------------------------------------------------
    Private Sub form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.Silver
        End If
    End Sub
    '
    Private Sub frmProdutoProcurar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not IsNothing(_formOrigem) Then
            Dim pnl As Panel = _formOrigem.Controls("Panel1")
            pnl.BackColor = Color.SlateGray
        End If
    End Sub
    '
#End Region
    '
End Class