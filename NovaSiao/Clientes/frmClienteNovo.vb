Imports CamadaBLL
Imports CamadaDTO
Public Class frmClienteNovo
    ' EVENTO LOAD
    Private Sub frmClienteNovo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCNPJ.Focus()
    End Sub
    '
    ' SUPRIMIR A TECLA ENTER NO TXTCNPJ
    Private Sub txtCNPJ_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCNPJ.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '
    ' FORMATAR A MÁSCARA DO CPF OU CNPJ
    Private Sub txtCNPJ_Leave(sender As Object, e As EventArgs) Handles txtCNPJ.Leave
        '
        If IsNumeric(txtCNPJ.Text) Then
            If txtCNPJ.TextLength = 11 Then
                'txtCNPJ.Mask = "000,000,000-00"

                txtCNPJ.Text = txtCNPJ.Text.Insert(3, ".").Insert(7, ".").Insert(11, "-")

            ElseIf txtCNPJ.TextLength = 14 Then
                'txtCNPJ.Mask = "00,000,000/0000-00"
                txtCNPJ.Text = txtCNPJ.Text.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-")

            End If
        End If
        '
    End Sub
    '
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
    ' RETIRAR A FORMATAÇÃO DA MÁSCARA DO CPJ OU CNPJ
    Private Sub txtCNPJ_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCNPJ.KeyUp
        '
        If e.KeyCode = Keys.Delete Then
            txtCNPJ.Clear()
        End If
        '
    End Sub
    '
    ' FORMATAÇÃO
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
    Private Sub SelecionaTxtCNPJ()
        'txtCNPJ.Mask = ""
        txtCNPJ.Focus()
        txtCNPJ.SelectAll()
    End Sub
    '
    ' BUTTON OK
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ' VALIDAR O NÚMERO DE CPF OU CNPJ
        If ValidaCNP() = String.Empty Then Exit Sub
        '
        'VERIFICAR SE O CPF OU CNPJ JÁ ESTÁ CADASTRADO
        Dim cli As Object = VerPessoaExistente()
        '
        ' ABRIR O FORMULARIO DE CADASTRO DE NOVO CLIENTE
        '-------------------------------------------------------------------------------------------------------------------------
        If Not IsNothing(cli) AndAlso cli.GetType = GetType(clClientePF) Then ' CLIENTE PESSOA FÍSICA
            ' Fecha o Cliente PJ se estiver aberto 
            If Application.OpenForms.OfType(Of frmClientePJ)().Count() > 0 Then Application.OpenForms.OfType(Of frmClientePJ)().First.Close()
            '
            ' Abre o ClientePF se já não estiver aberto
            If Application.OpenForms.OfType(Of frmClientePF)().Count() = 0 Then
                If Not IsNothing(DirectCast(cli, clClientePF).IDPessoa) Then
                    Dim frmPF As New frmClientePF(EnumFlagAcao.EDITAR, DirectCast(cli, clClientePF))
                    frmPF.MdiParent = frmPrincipal
                    frmPF.Show()
                Else
                    Dim frmPF As New frmClientePF(EnumFlagAcao.INSERIR, DirectCast(cli, clClientePF))
                    frmPF.MdiParent = frmPrincipal
                    frmPF.Show()
                End If
            Else
                Dim frmPF As frmClientePF = Application.OpenForms.OfType(Of frmClientePF).First
                '
                If Not IsNothing(DirectCast(cli, clClientePF).IDPessoa) Then
                    frmPF.propAcao = EnumFlagAcao.EDITAR
                    frmPF.propClientePF = DirectCast(cli, clClientePF)
                    frmPF.Show()
                Else
                    frmPF.propAcao = EnumFlagAcao.INSERIR
                    frmPF.propClientePF = DirectCast(cli, clClientePF)
                    frmPF.Show()
                End If
            End If
        ElseIf Not IsNothing(cli) AndAlso cli.GetType = GetType(clClientePJ) Then ' CLIENTE PESSOA JURÍDICA
            ' Fecha o ClientePF se estiver aberto
            If Application.OpenForms.OfType(Of frmClientePF)().Count() > 0 Then Application.OpenForms.OfType(Of frmClientePF)().First.Close()
            '
            ' Abre o ClientePJ se já não estiver aberto
            If Application.OpenForms.OfType(Of frmClientePJ)().Count() = 0 Then
                If Not IsNothing(DirectCast(cli, clClientePJ).RGCliente) Then '--- verifica se já é cliente cadastrado
                    Dim frmPJ As New frmClientePJ(EnumFlagAcao.EDITAR, DirectCast(cli, clClientePJ))
                    frmPJ.Show()
                Else
                    Dim frmPJ As New frmClientePJ(EnumFlagAcao.INSERIR, DirectCast(cli, clClientePJ))
                    frmPJ.Show()
                End If
            Else
                Dim frmPJ As frmClientePJ = Application.OpenForms.OfType(Of frmClientePJ).First
                '
                If Not IsNothing(DirectCast(cli, clClientePJ).RGCliente) Then '--- verifica se já é cliente cadastrado
                    frmPJ.propAcao = EnumFlagAcao.EDITAR
                    frmPJ.propClientePJ = DirectCast(cli, clClientePJ)
                    frmPJ.Show()
                Else
                    frmPJ.propAcao = EnumFlagAcao.INSERIR
                    frmPJ.propClientePJ = DirectCast(cli, clClientePJ)
                    frmPJ.Show()
                End If
            End If
        Else
            MessageBox.Show("Não foi retornado nenhum valor", "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        '
        'FECHAR FORMULÁRIO
        Me.Close()
    End Sub
    '
    ' VERIFICA PESSOA EXISTENTE RETORNA UM clClientePF ou PJ
    Private Function VerPessoaExistente() As Object
        '
        Dim db As New PessoaBLL
        Dim myPessoa As Object = Nothing
        '
        Try
            '--- Ampulheta ON
            Cursor = Cursors.WaitCursor
            '
            myPessoa = db.ProcurarCNP_Pessoa(txtCNPJ.Text, "CLIENTE")
            '
            ' NÃO ENCOTROU NENHUM CLIENTE NO CPF/CNPJ RETORNA NOVO CLIENTE
            If IsNothing(myPessoa) Then
                If txtCNPJ.TextLength = 14 Then
                    Dim cli As New clClientePF
                    cli.CPF = txtCNPJ.Text
                    Return cli
                ElseIf txtCNPJ.TextLength = 18 Then
                    Dim cli As New clClientePJ
                    cli.CNPJ = txtCNPJ.Text
                    Return cli
                End If
            End If
            '
            ' VERIFICA SE A PESSOA ENCONTRADA É PF OU PJ
            If txtCNPJ.TextLength = 14 Then ' PESSOA FÍSICA
                '
                Select Case myPessoa.GetType()
                    Case Is = GetType(clPessoaFisica) ' É APENAS PessoaFisica
                        MessageBox.Show("Já Existe PESSOA FÍSICA cadastrada com esse mesmo CPF..." & vbCrLf & vbCrLf &
                                        "Os dados serão copiados para um NOVO CADASTRO de Cliente Pessoa Física",
                                        "CPF Já existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim cli As New clClientePF
                        Dim PF As clPessoaFisica = DirectCast(myPessoa, clPessoaFisica)
                        '
                        cli.IDPessoa = PF.IDPessoa
                        cli.PessoaTipo = PF.PessoaTipo
                        cli.InsercaoData = PF.InsercaoData
                        '
                        cli.Cadastro = PF.Cadastro
                        cli.CPF = PF.CPF
                        cli.NascimentoData = PF.NascimentoData
                        cli.Sexo = PF.Sexo
                        cli.Identidade = PF.Identidade
                        cli.IdentidadeOrgao = PF.IdentidadeOrgao
                        cli.IdentidadeData = PF.IdentidadeData
                        '
                        cli.Endereco = PF.Endereco
                        cli.Bairro = PF.Bairro
                        cli.Cidade = PF.Cidade
                        cli.UF = PF.UF
                        cli.CEP = PF.CEP
                        cli.Email = PF.Email
                        cli.EmailDestino = PF.EmailDestino
                        cli.EmailPrincipal = PF.EmailPrincipal
                        cli.TelefoneA = PF.TelefoneA
                        cli.TelefoneB = PF.TelefoneB
                        '
                        Return cli
                    Case Is = GetType(clClientePF) ' JÁ é um CLIENTE
                        MessageBox.Show("Já existe um CLIENTE PESSOA FÍSICA com esse mesmo CPF..." & vbCrLf & vbNewLine &
                                        "O cadastro do Cliente será aberto",
                                        "CPF Já existe como Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim cli As clClientePF = DirectCast(myPessoa, clClientePF)
                        Return cli
                        '
                End Select
                '
            ElseIf txtCNPJ.TextLength = 18 Then ' PESSOA JURIDICA
                '
                Select Case myPessoa.GetType()
                    Case Is = GetType(clPessoaJuridica) ' É APENAS PessoaJuridica
                        MessageBox.Show("Já Existe PESSOA JURÍDICA cadastrada com esse mesmo CNPJ..." & vbCrLf & vbCrLf &
                                        "Os dados serão copiados para um NOVO CADASTRO de Cliente Pessoa Jurídica",
                                        "CNPJ Já existe", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim cli As New clClientePJ
                        Dim PJ As clPessoaJuridica = DirectCast(myPessoa, clPessoaJuridica)
                        '
                        cli.IDPessoa = PJ.IDPessoa
                        cli.PessoaTipo = PJ.PessoaTipo
                        cli.InsercaoData = PJ.InsercaoData
                        '
                        cli.Endereco = PJ.Endereco
                        cli.Bairro = PJ.Bairro
                        cli.Cidade = PJ.Cidade
                        cli.UF = PJ.UF
                        cli.CEP = PJ.CEP
                        cli.Email = PJ.Email
                        cli.EmailDestino = PJ.EmailDestino
                        cli.EmailPrincipal = PJ.EmailPrincipal
                        cli.TelefoneA = PJ.TelefoneA
                        cli.TelefoneB = PJ.TelefoneB
                        '
                        cli.Cadastro = PJ.Cadastro
                        cli.CNPJ = PJ.CNPJ
                        cli.InscricaoEstadual = PJ.InscricaoEstadual
                        cli.NomeFantasia = PJ.NomeFantasia
                        cli.FundacaoData = PJ.FundacaoData
                        cli.ContatoNome = PJ.ContatoNome
                        '
                    Case Is = GetType(clClientePJ) ' JÁ É um Cliente
                        MessageBox.Show("Já existe um CLIENTE Pessoa Jurídica com esse mesmo CNPJ..." & vbCrLf & vbNewLine &
                                        "O cadastro do Cliente será aberto",
                                        "CNPJ Já existe como Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim cli As clClientePJ = DirectCast(myPessoa, clClientePJ)
                        Return cli
                End Select
                '
            End If
            '
        Catch ex As Exception
            MessageBox.Show("Uma exceção ocorreu ao procurar CPF/CNPJ..." & vbNewLine &
                            ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            '--- Ampulheta OFF
            Cursor = Cursors.Default
        End Try
        '
        Return Nothing
        '    
    End Function

    ' BUTTON CANCELAR
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()

        If Application.OpenForms.Count() = 1 Then
            MostraMenuPrincipal()
        End If
    End Sub
    ' VALIDAR O NÚMERO DO CNPJ OU CPF
    Private Function ValidaCNP() As String
        Dim obj As New Valida_CPF_CNPJ
        Try
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return String.Empty
        End Try
    End Function
    '
End Class