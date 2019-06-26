Imports CamadaDAL
Imports CamadaDTO
'
Public Class PessoaBLL
    '
#Region "ENUMS"
    '
    Enum EnumPessoaTipo
        CLIENTE_VAREJO = 0
        PESSOA_FISICA = 1
        PESSOA_JURIDICA = 2
        FILIAL = 3
        CREDOR_SIMPLES = 4
    End Enum
    '
    Enum EnumPessoaGrupo
        CLIENTE
        FORNECEDOR
        FUNCIONARIO
        TRANSPORTADORA
        CREDOR
        FILIAL
    End Enum
    '
#End Region '/ ENUMS
    '
#Region "UTILITIES FUNCTIONS"
    '
    '==========================================================================================
    ' DETACH PESSOA FISICA/JURIDICA OF NEW PESSOA
    '==========================================================================================
    Function DetachPessoaFisica(newPessoa As Object) As clPessoaFisica
        '
        Dim isCredorPF As Boolean = TypeOf newPessoa Is clCredor
        '
        Dim pf As New clPessoaFisica With {
            .IDPessoa = newPessoa.IDPessoa,
            .Cadastro = newPessoa.Cadastro,
            .CPF = If(Not isCredorPF, newPessoa.CPF, newPessoa.CNP),
            .PessoaTipo = newPessoa.PessoaTipo,
            .NascimentoData = If(Not isCredorPF, newPessoa.NascimentoData, Nothing),
            .Sexo = If(Not isCredorPF, newPessoa.Sexo, Nothing),
            .Endereco = newPessoa.Endereco,
            .Bairro = newPessoa.Bairro,
            .Cidade = newPessoa.Cidade,
            .UF = newPessoa.UF,
            .CEP = newPessoa.CEP,
            .TelefoneA = newPessoa.TelefoneA,
            .TelefoneB = newPessoa.TelefoneB,
            .Email = newPessoa.Email,
            .EmailDestino = newPessoa.EmailDestino,
            .EmailPrincipal = newPessoa.EmailPrincipal,
            .Identidade = If(Not isCredorPF, newPessoa.Identidade, Nothing),
            .IdentidadeData = If(Not isCredorPF, newPessoa.IdentidadeData, Nothing),
            .IdentidadeOrgao = If(Not isCredorPF, newPessoa.IdentidadeOrgao, Nothing),
            .InsercaoData = newPessoa.InsercaoData
        }
        '
        Return pf
        '
    End Function
    '
    Function DetachPessoaJuridica(newPessoa As Object) As clPessoaJuridica
        '
        Dim isCredorPF As Boolean = TypeOf newPessoa Is clCredor
        '
        Dim pj As New clPessoaJuridica With {
            .IDPessoa = newPessoa.IDPessoa,
            .Cadastro = newPessoa.Cadastro,
            .NomeFantasia = If(Not isCredorPF, newPessoa.NomeFantasia, Nothing),
            .PessoaTipo = newPessoa.PessoaTipo,
            .ContatoNome = If(Not isCredorPF, newPessoa.ContatoNome, Nothing),
            .Endereco = newPessoa.Endereco,
            .Bairro = newPessoa.Bairro,
            .Cidade = newPessoa.Cidade,
            .CEP = newPessoa.CEP,
            .UF = newPessoa.UF,
            .TelefoneA = newPessoa.TelefoneA,
            .TelefoneB = newPessoa.TelefoneB,
            .CNPJ = If(Not isCredorPF, newPessoa.CNPJ, newPessoa.CNP),
            .InscricaoEstadual = If(Not isCredorPF, newPessoa.InscricaoEstadual, Nothing),
            .Email = newPessoa.Email,
            .EmailDestino = newPessoa.EmailDestino,
            .EmailPrincipal = newPessoa.EmailPrincipal,
            .FundacaoData = If(Not isCredorPF, newPessoa.FundacaoData, Nothing),
            .InsercaoData = newPessoa.InsercaoData
        }
        '
        Return pj
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNÇÃO PROCURAR PESSOA POR CPF OU CNPJ E RETORNA UMA CLASSE
    ' DEPENDENDO DO ARGUMENTO DE PROCURA ProcurarEm 
    ' (CLIENTE | FORNECEDOR | FUNCIONARIO | TRANSPORTADORA | FILIAL | CREDOR)
    ' SE JÁ For CLIENTE RETORNA clClientePF ou clClientePJ
    ' SE JÁ FOR FORNECEDOR RETORNA clFornecedor;
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ProcurarCNP_Pessoa(CNP As String, ProcurarEm As EnumPessoaGrupo) As Object
        Dim db As New AcessoDados
        '
        Try
            'Adiciona os parametros
            db.LimparParametros()
            db.AdicionarParametros("@CNP", CNP)
            db.AdicionarParametros("@ProcurarEm", ProcurarEm)
            '
            'executa o procedure
            Dim dtPessoa As DataTable
            dtPessoa = db.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoa_ProcurarCNP_Pessoa")
            '
            ' VERIFICA O ROW RETORNADO
            If dtPessoa.Rows.Count = 0 Then
                Throw New Exception("Não houve retorno no procedure...")
                Return Nothing
            End If
            '
            Dim r As DataRow = dtPessoa.Rows(0)
            '
            ' SE NÃO ENCONTRAR NENHUM CPF/CNPJ IGUAL RETORNA NOTHING
            If IsDBNull(r("IDPessoa")) Then Return Nothing
            '
            ' SE ENCONTRAR RETORNA A PESSOA FISICA OU JURÍDICA
            '-------------------------------------------------------------------------------------------------------------------------------
            '
            ' SE FOR PESSOA FÍSICA
            If r("PessoaTipo") = 1 Then
                '
                If r("Encontrado") = False Then Return DirectCast(ConverteDtRow_Pessoa(r), clPessoaFisica) ' CLIENTE PF NÃO FOI ENCONTRADO (RETORNA clPessoaFisica)
                '
                Select Case ProcurarEm
                    Case EnumPessoaGrupo.CLIENTE ' VERIFICA O CLIENTE ENCONTRADO E RETORNA ClientePF
                        Return ConvertDtRow_Cliente(r)
                    Case EnumPessoaGrupo.FUNCIONARIO
                        Return ConvertDtRow_Funcionario(r)
                    Case EnumPessoaGrupo.CREDOR
                        Return CredorBLL.ConvertDtRow_Credor(r)
                    Case Else
                        Return DirectCast(ConverteDtRow_Pessoa(r), clPessoaFisica)
                End Select
                '
            Else ' SE FOR PESSOA JURÍDICA
                '
                If r("Encontrado") = False Then Return DirectCast(ConverteDtRow_Pessoa(r), clPessoaJuridica) ' CLIENTE PJ NÃO FOI ENCONTRADO (RETORNA clPessoaJuridica)
                '
                Select Case ProcurarEm
                    Case EnumPessoaGrupo.CLIENTE ' VERIFICA O CLIENTE ENCONTRADO E RETORNA ClientePJ
                        Return ConvertDtRow_Cliente(r) ' RETORNA ClientePJ
                    Case EnumPessoaGrupo.TRANSPORTADORA
                        Return ConvertDtRow_Transportadora(r)
                    Case EnumPessoaGrupo.FORNECEDOR
                        Return ConvertDtRow_Fornecedor(r)
                    Case EnumPessoaGrupo.CREDOR
                        Return CredorBLL.ConvertDtRow_Credor(r)
                    Case Else
                        Return DirectCast(ConverteDtRow_Pessoa(r), clPessoaJuridica)
                End Select
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '==========================================================================================
    ' Check PESSOA with the same "cadastro name"
    '==========================================================================================
    Private Sub CheckSameCadastro(CadastroNome As String,
                                  Optional IDPessoa As Integer? = Nothing)
        '
        Try
            '
            'executa a consulta
            Dim findPessoa As clPessoa = ProcuraPessoaPeloCadastroNome(CadastroNome)
            '
            ' VERIFICA O ROW RETORNADO
            If IsNothing(findPessoa) Then Return
            '
            If Not IsNothing(IDPessoa) Then
                If findPessoa.IDPessoa = IDPessoa Then Return
            End If
            '
            Dim PessoaTipo As Byte = findPessoa.PessoaTipo
            '
            Select Case PessoaTipo
                Case 1 '--> Pessoa Fisica
                    Throw New Exception("Já existe Pessoa Física com o mesmo nome de Cadastro..." &
                                        vbNewLine &
                                        "Cadastro: " & findPessoa.Cadastro.ToUpper &
                                        vbNewLine &
                                        "ID: " & Format(findPessoa.IDPessoa, "0000"))
                Case 2 '--> pessoa Juridica
                    Throw New Exception("Já existe Pessoa Jurídica com o mesmo nome de Cadastro..." &
                                        vbNewLine &
                                        "Cadastro: " & findPessoa.Cadastro.ToUpper &
                                        vbNewLine &
                                        "ID: " & Format(findPessoa.IDPessoa, "0000"))
                Case 3 '--> Filial
                    Throw New Exception("Já existe uma Filial com o mesmo nome de Cadastro..." &
                                        vbNewLine &
                                        "Cadastro: " & findPessoa.Cadastro.ToUpper &
                                        vbNewLine &
                                        "ID: " & Format(findPessoa.IDPessoa, "0000"))
                Case 4 '--> Credor Simples
                    Throw New Exception("Já existe um Credor com o mesmo nome de Cadastro..." &
                                        vbNewLine &
                                        "Cadastro: " & findPessoa.Cadastro.ToUpper &
                                        vbNewLine &
                                        "ID: " & Format(findPessoa.IDPessoa, "0000"))
                    '
                Case Else
                    Throw New Exception("Já existe um cadastro com a mesma designação de nome...")
            End Select
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '==========================================================================================
    ' LOOKING FOR PESSOA FROM CADASTRO NAME | RETURN CLPESSOA or NOTHING
    '==========================================================================================
    Public Function ProcuraPessoaPeloCadastroNome(Cadastro As String) As clPessoa
        '
        Dim db As New AcessoDados
        '
        'Adiciona os parametros
        db.LimparParametros()
        db.AdicionarParametros("@Cadastro", Cadastro.ToUpper)
        Dim myQuery As String = "SELECT IDPessoa, Cadastro, PessoaTipo, InsercaoData " &
                                "FROM tblPessoa WHERE UPPER(Cadastro) = @Cadastro;"
        '
        Try
            '
            'executa a consulta
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            '
            ' VERIFICA O ROW RETORNADO
            If dt.Rows.Count = 0 Then Return Nothing
            '
            Dim r As DataRow = dt.Rows(0)
            '
            Dim pessoa As New clPessoa With {
                .Cadastro = r("Cadastro"),
                .IDPessoa = r("IDPessoa"),
                .PessoaTipo = r("PessoaTipo"),
                .InsercaoData = r("InsercaoData")
            }
            '
            Return pessoa
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' VERIFICA SE JÁ EXISTE CLIENTE COM O RGCliente FORNECIDO E RETORNA O ClientePF ou ClientePJ
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ProcurarCliente_RG_Cliente(myRGCliente As Integer) As Object
        Dim db As New AcessoDados
        '
        db.LimparParametros()
        db.AdicionarParametros("@RGCliente", myRGCliente)
        '
        Try
            Dim myTable As DataTable = db.ExecutarConsulta(CommandType.StoredProcedure, "uspCliente_Procurar_PorRG")
            '
            Dim r As DataRow = myTable.Rows(0)
            '
            If Not IsDBNull(r("PessoaTipo")) Then
                Return ConvertDtRow_Cliente(r)
            Else ' NÃO ENCONTROU UM CLIENTE PESSOA FÍSICA COM ESSE RG
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' VERIFICA QUAL É O MAIOR RGCliente CADASTRADO E O RETORNA ACRESCIDO DE 1
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ProcurarNextRG() As Integer?
        Dim SQL As New SQLControl

        SQL.ExecQuery("SELECT MAX(tblPessoaCliente.RGCliente) FROM tblPessoaCliente")

        If SQL.HasException(True) Then
            Return Nothing
            Exit Function
        End If

        If SQL.RecordCount > 0 Then
            Dim r As DataRow = SQL.DBDT.Rows(0)
            Return CInt(r(0)) + 1
        Else
            Return 1
        End If
    End Function
    '
    '----------------------------------------------------------------------------------
    '--- CHECK CPF / CNPJ DUPLICATION IN TBLPESSOAFISICA / JURIDICA
    '----------------------------------------------------------------------------------
    Private Function CheckCPFDuplication(CPF As String, notIDPessoa As Integer) As Boolean
        '
        '--- CHECK DUPLICATION OF CPF
        '----------------------------------------------------------------------------------
        Dim db As New AcessoDados
        Dim myQuery As String
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@CPF", CPF)
        db.AdicionarParametros("@IDPessoa", notIDPessoa)
        '
        myQuery = "SELECT COUNT (*) AS Total FROM tblPessoaFisica WHERE CPF = @CPF AND IDPessoa <> @IDPessoa"
        '
        '--- CHECK
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            If dt.Rows.Count = 0 Then Throw New Exception("Não foi possível acessar o BD...")
            '
            If dt.Rows(0)("Total") > 0 Then
                Return True
            Else
                Return False
            End If
            '
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
    End Function
    '
    Private Function CheckCNPJDuplication(CNPJ As String, notIDPessoa As Integer) As Boolean
        '
        '--- CHECK DUPLICATION OF CPF
        '----------------------------------------------------------------------------------
        Dim db As New AcessoDados
        Dim myQuery As String
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@CNPJ", CNPJ)
        db.AdicionarParametros("@IDPessoa", notIDPessoa)
        '
        myQuery = "SELECT COUNT (*) AS Total FROM tblPessoaJuridica WHERE CNPJ = @CNPJ AND IDPessoa <> @IDPessoa"
        '
        '--- CHECK
        Try
            Dim dt As DataTable = db.ExecutarConsulta(CommandType.Text, myQuery)
            If dt.Rows.Count = 0 Then Throw New Exception("Não foi possível acessar o BD...")
            '
            If dt.Rows(0)("Total") > 0 Then
                Return True
            Else
                Return False
            End If
            '
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
    End Function
    '
#End Region '/ UTILITIES FUNCTIONS
    '
#Region "INSERTS GROUP"
    '
    '==========================================================================================
    ' ENTRY FUNCTIONS
    '==========================================================================================
    '
    '----------------------------------------------------------------------------------
    ' INSERT NEW PESSOA VERIFY
    ' Before check if Pessoa already exists, insert in tblPessoaFisica or tblPessoaJuridica
    '----------------------------------------------------------------------------------
    Public Function InsertNewPessoa(newPessoa As Object,
                                    PessoaGrupo As EnumPessoaGrupo) As Object
        '
        '--- 1) CHECK IF IS THERE CNP IN NEW PESSOA
        '----------------------------------------------------------------------------------
        '--- obtain CNP from Pessoa of CPF or CNPJ
        Dim CNP As String = ""
        Dim findResult As String = ""
        Dim findPessoa As Object = Nothing
        '
        If Array.Exists(newPessoa.GetType().GetProperties(), Function(x) x.Name = "CPF") Then
            CNP = newPessoa.CPF
        ElseIf Array.Exists(newPessoa.GetType().GetProperties(), Function(x) x.Name = "CNPJ") Then
            CNP = newPessoa.CNPJ
        ElseIf Array.Exists(newPessoa.GetType().GetProperties(), Function(x) x.Name = "CNP") Then
            CNP = newPessoa.CNP
        Else '--> caso credor simples nao ha CNP
            CNP = ""
        End If
        '
        '--- 2) LOOK FOR PESSOA OF IN THE SAME "NAME" OR SAME "CNP"
        '----------------------------------------------------------------------------------
        Try
            '
            If Not String.IsNullOrEmpty(CNP) Then
                '--- procura pessoa pelo CNP
                findPessoa = ProcurarCNP_Pessoa(CNP, PessoaGrupo)
                '
                '--- procurar pessoa com mesmo CADASTRO NOME
                If Not IsNothing(findPessoa) Then
                    '
                    '--- Verifica se ha pessoa com mesmo NOME DE CADASTRO mas com IDPessoa diferente
                    CheckSameCadastro(newPessoa.Cadastro, findPessoa.IDPessoa)
                    '
                End If
                '
            Else
                '
                '--- Verifica se ha pessoa com mesmo NOME DE CADASTRO
                CheckSameCadastro(newPessoa.Cadastro)
                '
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 3) CHECK CNP ALREADY INSERTED
        '----------------------------------------------------------------------------------
        '
        ' NÃO ENCOTROU NENHUMA PESSOA NO CPF/CNPJ RETORNA NOVO
        If Not IsNothing(findPessoa) Then
            '
            '--- verifica o tipo returned
            Select Case findPessoa.GetType()
                    '
                Case Is = GetType(clPessoaFisica) ' É PESSOAFISICA
                    findResult = "PessoaFisicaEncontrada"
                Case Is = GetType(clPessoaJuridica) ' É PESSOAJURIDICA
                    findResult = "PessoaJuridicaEncontrada"
                Case Else ' PESSOA ALREADY EXISTS IN GROUP
                    findResult = "PessoaMesmoTipoEncontrada"
                    '
            End Select
            '
        Else
            findResult = "Insert"
        End If
        '
        Try
            '
            Select Case findResult
            '
                Case "PessoaFisicaEncontrada" '--> UPDATE PESSOA FISICA
                    newPessoa.IDPessoa = findPessoa.IDPessoa
                    Return InsertPessoaGroup(newPessoa, PessoaGrupo, True)

                Case "PessoaJuridicaEncontrada" '--> UPDATE PESSOA JURIDICA
                    newPessoa.IDPessoa = findPessoa.IDPessoa
                    Return InsertPessoaGroup(newPessoa, PessoaGrupo, True)

                Case "PessoaMesmoTipoEncontrada" '--> RETURN PESSOA
                    Return newPessoa '--> DEVOLVE A PESSOA ENCONTRADA

                Case "Insert" '--> INSERT NEW PESSOA
                    Return InsertPessoaGroup(newPessoa, PessoaGrupo, False)

                Case Else
                    Throw New Exception("Não foi possível inserir uma nova pessoa...")
            End Select
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '----------------------------------------------------------------------------------
    ' INSERIR PESSOA PELO GRUPO
    '----------------------------------------------------------------------------------
    Private Function InsertPessoaGroup(newPessoa As Object,
                                       PessoaGrupo As EnumPessoaGrupo,
                                       AlreadyExists As Boolean) As Object
        '
        '--- get new Acesso with Transaction
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        Try
            '
            Select Case newPessoa.PessoaTipo
            '
                Case 1 '--> PESSOA FISICA
                    Dim PF As clPessoaFisica = DetachPessoaFisica(newPessoa)
                    '
                    '--- INSERT OR UPDATE PESSOA FISICA
                    If Not AlreadyExists Then
                        newPessoa.IDPessoa = InsertPessoaFisica(PF, db) '--> INSERT
                    Else
                        UpdatePessoaFisica(PF, db) '--> UPDATE
                    End If
                    ' 
                    Select Case PessoaGrupo '--> CASOS DE PF ( CLIENTEPF | FUNCIONARIO | CREDOR )
                        '
                        Case EnumPessoaGrupo.CLIENTE
                            InsertClientePF(DirectCast(newPessoa, clClientePF), db)

                        Case EnumPessoaGrupo.FUNCIONARIO
                            InsertFuncionario(DirectCast(newPessoa, clFuncionario), db)

                        Case EnumPessoaGrupo.CREDOR
                            InsertCredor(DirectCast(newPessoa, clCredor), db)

                    End Select
                    '
                Case 2 '--> PESSOA JURIDICA
                    Dim PJ As clPessoaJuridica = DetachPessoaJuridica(newPessoa)
                    '
                    '--- INSERT OR UPDATE PESSOA JURIDICA
                    If Not AlreadyExists Then
                        newPessoa.IDPessoa = InsertPessoaJuridica(PJ, db) '--> INSERT
                    Else
                        UpdatePessoaJuridica(PJ, db) '--> UPDATE
                    End If
                    '
                    Select Case PessoaGrupo '--> CASOS DE PJ (CLIENTEPJ | FORNECEDOR | TRANSPORTADORA | CREDOR )
                        '
                        Case EnumPessoaGrupo.CLIENTE
                            InsertClientePJ(DirectCast(newPessoa, clClientePJ), db)

                        Case EnumPessoaGrupo.FORNECEDOR
                            InsertFornecedor(DirectCast(newPessoa, clFornecedor), db)

                        Case EnumPessoaGrupo.TRANSPORTADORA
                            InsertTransportadora(DirectCast(newPessoa, clTransportadora), db)

                        Case EnumPessoaGrupo.CREDOR
                            InsertCredor(DirectCast(newPessoa, clCredor), db)

                    End Select
                    '
                Case 3 '---> FILIAL
                    '
                    '--- INSERT PESSOA SIMPLES
                    newPessoa.IDPessoa = InsertPessoaSimples(newPessoa.Cadastro,
                                                             EnumPessoaTipo.FILIAL,
                                                             db) '--> INSERT FILIAL
                    '
                    InsertFilial(DirectCast(newPessoa, clFilial), db)
                    '
                Case 4 '---> CREDOR SIMPLES
                    '
                    '--- INSERT PESSOA SIMPLES
                    newPessoa.IDPessoa = InsertPessoaSimples(newPessoa.Cadastro,
                                                             EnumPessoaTipo.CREDOR_SIMPLES,
                                                             db) '--> INSERT CREDOR SIMPLES
                    '
                    InsertCredor(DirectCast(newPessoa, clCredor), db)
                    '
            End Select
            '
        Catch ex As Exception
            db.RollBackTransaction()
            Throw ex
        End Try
        '
        '--- COMMIT TRANSACTION
        db.CommitTransaction()
        '
        '--- RETURN
        Return newPessoa.IDPessoa
        '
    End Function
    '
    '=====================================================================================================
    ' INSERTS
    '=====================================================================================================
    '
    '--- PESSOA SIMPLES
    Private Function InsertPessoaSimples(CadastroNome As String,
                                         PessoaTipo As EnumPessoaTipo,
                                         dbTran As AcessoDados) As Integer
        '
        '--- ACCESS DATABASE AND TRANSACTION
        '----------------------------------------------------------------------------------
        '
        Dim dt As DataTable = Nothing
        Dim myQuery As String = ""
        '
        '--- 1) INSERT IN TBLPESSOA AND OBTAIN NEW IDPESSOA
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@Cadastro", CadastroNome)
        dbTran.AdicionarParametros("@PessoaTipo", CByte(PessoaTipo))
        '
        myQuery = "INSERT INTO tblPessoa (PessoaTipo, Cadastro, InsercaoData) VALUES (@PessoaTipo, @Cadastro, GETDATE())"
        '
        '--- INSERT
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
            '
            '--- obter NewID
            dbTran.LimparParametros()
            myQuery = "SELECT @@IDENTITY As LastID;"
            dt = dbTran.ExecutarConsulta(CommandType.Text, myQuery)
            '
            Return dt.Rows(0)("LastID")
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Function
    '
    '--- PESSOA FISICA
    '----------------------------------------------------------------------------------
    Private Function InsertPessoaFisica(PF As clPessoaFisica,
                                        dbTran As AcessoDados) As Integer
        '
        '--- ACCESS DATABASE AND TRANSACTION
        '----------------------------------------------------------------------------------
        '
        Dim dt As DataTable = Nothing
        Dim myQuery As String = ""
        '
        '--- 1) INSERT IN TBLPESSOA AND OBTAIN NEW IDPESSOA
        '----------------------------------------------------------------------------------
        Try
            '
            PF.IDPessoa = InsertPessoaSimples(PF.Cadastro, EnumPessoaTipo.PESSOA_FISICA, dbTran)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT IN TBLPESSOAFISICA
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", PF.IDPessoa)
        dbTran.AdicionarParametros("@CPF", PF.CPF)
        dbTran.AdicionarParametros("@Sexo", If(PF.Sexo, DBNull.Value))
        dbTran.AdicionarParametros("@NascimentoData", If(PF.NascimentoData, DBNull.Value))
        dbTran.AdicionarParametros("@Identidade", If(PF.Identidade, DBNull.Value))
        dbTran.AdicionarParametros("@IdentidadeOrgao", If(PF.IdentidadeOrgao, DBNull.Value))
        dbTran.AdicionarParametros("@IdentidadeData", If(PF.IdentidadeData, DBNull.Value))
        '
        myQuery = "INSERT INTO tblPessoaFisica
			      (IDPessoa, CPF, Sexo, NascimentoData, Identidade, IdentidadeOrgao, IdentidadeData)
			      VALUES
			      (@IDPessoa, @CPF, @Sexo, @NascimentoData, @Identidade, @IdentidadeOrgao, @IdentidadeData)"
        '
        '--- INSERT
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 3) INSERT IN TBLPESSOAENDERECO
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", PF.IDPessoa)
        dbTran.AdicionarParametros("@Endereco", PF.Endereco)
        dbTran.AdicionarParametros("@Bairro", PF.Bairro)
        dbTran.AdicionarParametros("@Cidade", PF.Cidade)
        dbTran.AdicionarParametros("@UF", PF.UF)
        dbTran.AdicionarParametros("@CEP", PF.CEP)
        '
        myQuery = "INSERT INTO tblPessoaEndereco
			      (IDPessoa, Endereco, Bairro, Cidade, UF, CEP)
			      VALUES (@IDPessoa, @Endereco, @Bairro, @Cidade, @UF, @CEP)"
        '
        '--- INSERT
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 4) INSERT IN TBLPESSOATELEFONE IF NECESSARY
        '----------------------------------------------------------------------------------
        '
        '--- INSERT IF NECESSARY
        Dim checkTelefoneA As Boolean = Trim(If(PF.TelefoneA, "")).Length > 0  '(Not IsNothing(PF.TelefoneA)) AndAlso (PF.TelefoneA.Trim.Length > 0)
        Dim checkTelefoneB As Boolean = Trim(If(PF.TelefoneB, "")).Length > 0  '(Not IsNothing(PF.TelefoneB)) AndAlso (PF.TelefoneB.Trim.Length > 0)
        '
        If checkTelefoneA Or checkTelefoneB Then
            '
            '--- PARAMNS
            dbTran.LimparParametros()
            dbTran.AdicionarParametros("@IDPessoa", PF.IDPessoa)
            dbTran.AdicionarParametros("@TelefoneA", If(PF.TelefoneA, DBNull.Value))
            dbTran.AdicionarParametros("@TelefoneB", If(PF.TelefoneB, DBNull.Value))
            '
            myQuery = "INSERT INTO tblPessoaTelefone (IDPessoa, TelefoneA, TelefoneB) " &
                      "VALUES (@IDPessoa, @TelefoneA, @TelefoneB)"
            '
            Try
                dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
        '--- 5) INSERT IN TBLPESSOAEMAIL
        '----------------------------------------------------------------------------------
        '
        '--- INSERT IF NECESSARY
        Dim checkEmail = Trim(If(PF.Email, "")).Length > 0
        '
        If checkEmail Then
            '
            dbTran.LimparParametros()
            dbTran.AdicionarParametros("@IDPessoa", PF.IDPessoa)
            dbTran.AdicionarParametros("@Email", PF.Email)
            '
            myQuery = "INSERT INTO tblPessoaEmail (IDPessoa, Email, EmailDestino, EmailPrincipal) " &
                      "VALUES (@IDPessoa, @Email, 'Principal', 'TRUE')"
            '
            Try
                dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
        '--- RETURN
        Return PF.IDPessoa
        '
    End Function
    '
    '--- PESSOA JURIDICA
    '----------------------------------------------------------------------------------
    Private Function InsertPessoaJuridica(PJ As clPessoaJuridica,
                                          dbTran As AcessoDados) As Integer
        '
        '--- ACCESS DATABASE AND TRANSACTION
        '----------------------------------------------------------------------------------
        '
        Dim dt As DataTable = Nothing
        Dim myQuery As String = ""
        '
        '--- 1) INSERT IN TBLPESSOA AND OBTAIN NEW IDPESSOA
        '----------------------------------------------------------------------------------
        Try
            '
            PJ.IDPessoa = InsertPessoaSimples(PJ.Cadastro, EnumPessoaTipo.PESSOA_JURIDICA, dbTran)
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT IN TBLPESSOAJURIDICA
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
        dbTran.AdicionarParametros("@CNPJ", PJ.CNPJ)
        dbTran.AdicionarParametros("@InscricaoEstadual", If(PJ.InscricaoEstadual, DBNull.Value))
        dbTran.AdicionarParametros("@NomeFantasia", If(PJ.NomeFantasia, PJ.Cadastro))
        dbTran.AdicionarParametros("@FundacaoData", If(PJ.FundacaoData, DBNull.Value))
        dbTran.AdicionarParametros("@ContatoNome", If(PJ.ContatoNome, DBNull.Value))
        '
        myQuery = "INSERT INTO tblPessoaJuridica " &
                  "(IDPessoa, CNPJ, InscricaoEstadual, NomeFantasia, FundacaoData, ContatoNome) " &
                  "VALUES " &
                  "(@IDPessoa, @CNPJ, @InscricaoEstadual, @NomeFantasia, @FundacaoData, @ContatoNome)"
        '
        '--- INSERT
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 3) INSERT IN TBLPESSOAENDERECO
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
        dbTran.AdicionarParametros("@Endereco", PJ.Endereco)
        dbTran.AdicionarParametros("@Bairro", PJ.Bairro)
        dbTran.AdicionarParametros("@Cidade", PJ.Cidade)
        dbTran.AdicionarParametros("@UF", PJ.UF)
        dbTran.AdicionarParametros("@CEP", PJ.CEP)
        '
        myQuery = "INSERT INTO tblPessoaEndereco
			      (IDPessoa, Endereco, Bairro, Cidade, UF, CEP)
			      VALUES (@IDPessoa, @Endereco, @Bairro, @Cidade, @UF, @CEP)"
        '
        '--- INSERT
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 4) INSERT IN TBLPESSOATELEFONE IF NECESSARY
        '----------------------------------------------------------------------------------
        '
        '--- INSERT IF NECESSARY
        Dim checkTelefoneA As Boolean = Trim(If(PJ.TelefoneA, "")).Length > 0
        Dim checkTelefoneB As Boolean = Trim(If(PJ.TelefoneB, "")).Length > 0
        '
        If checkTelefoneA Or checkTelefoneB Then
            '
            '--- PARAMNS
            dbTran.LimparParametros()
            dbTran.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
            dbTran.AdicionarParametros("@TelefoneA", If(PJ.TelefoneA, DBNull.Value))
            dbTran.AdicionarParametros("@TelefoneB", If(PJ.TelefoneB, DBNull.Value))
            '
            myQuery = "INSERT INTO tblPessoaTelefone (IDPessoa, TelefoneA, TelefoneB) " &
                      "VALUES (@IDPessoa, @TelefoneA, @TelefoneB)"
            '
            Try
                dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
        '--- 5) INSERT IN TBLPESSOAEMAIL
        '----------------------------------------------------------------------------------
        '
        '--- INSERT IF NECESSARY
        Dim checkEmail = Trim(If(PJ.Email, "")).Length > 0
        '
        If checkEmail Then
            '
            dbTran.LimparParametros()
            dbTran.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
            dbTran.AdicionarParametros("@Email", PJ.Email)
            '
            myQuery = "INSERT INTO tblPessoaEmail (IDPessoa, Email, EmailDestino, EmailPrincipal) " &
                      "VALUES (@IDPessoa, @Email, 'Principal', 'TRUE')"
            '
            Try
                dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
        '--- RETURN
        Return PJ.IDPessoa
        '
    End Function
    '
    '--- FUNCIONARIO
    '----------------------------------------------------------------------------------
    Private Sub InsertFuncionario(_func As clFuncionario, dbTran As AcessoDados)
        '
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) INSERT tblPessoaFuncionario
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
        dbTran.AdicionarParametros("@AdmissaoData", _func.AdmissaoData)
        dbTran.AdicionarParametros("@Ativo", _func.Ativo)
        dbTran.AdicionarParametros("@Vendedor", _func.Vendedor)
        dbTran.AdicionarParametros("@ApelidoFuncionario", _func.ApelidoFuncionario)
        dbTran.AdicionarParametros("@IDFilial", _func.IDFilial)
        '
        myQuery = "INSERT INTO tblPessoaFuncionario " &
                  "( IDFuncionario, AdmissaoData, Ativo, Vendedor, ApelidoFuncionario, IDFilial ) " &
                  "VALUES " &
                  "( @IDPessoa, @AdmissaoData, @Ativo, @Vendedor, @ApelidoFuncionario, @IDFilial );"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT tblPessoaVendedor IF NECESSARY
        '----------------------------------------------------------------------------------
        If _func.Vendedor = True Then
            '
            '// PARAMNS
            dbTran.LimparParametros()
            dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
            dbTran.AdicionarParametros("@ApelidoVenda", _func.ApelidoFuncionario)
            dbTran.AdicionarParametros("@Comissao", _func.Comissao)
            dbTran.AdicionarParametros("@VendaTipo", _func.VendaTipo)
            dbTran.AdicionarParametros("@VendedorAtivo", _func.VendedorAtivo)
            '
            myQuery = "INSERT INTO tblPessoaVendedor " &
                      "(IDVendedor, ApelidoVenda, Comissao, VendaTipo, Ativo) " &
                      "VALUES " &
                      "(@IDPessoa, @ApelidoVenda, @Comissao, @VendaTipo, @VendedorAtivo);"
            '
            Try
                dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
    End Sub
    '
    '--- CLIENTE PF
    '----------------------------------------------------------------------------------
    Private Sub InsertClientePF(cliPF As clClientePF, dbTran As AcessoDados)
        '
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) INSERT TBLPESSOACLIENTE
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", cliPF.IDPessoa)
        dbTran.AdicionarParametros("@IDSituacao", cliPF.IDSituacao)
        dbTran.AdicionarParametros("@ClienteDesde", cliPF.ClienteDesde)
        dbTran.AdicionarParametros("@RGAtividade", cliPF.RGAtividade)
        dbTran.AdicionarParametros("@LimiteCompras", cliPF.LimiteCompras)
        dbTran.AdicionarParametros("@UltimaVenda", If(cliPF.UltimaVenda, DBNull.Value))
        dbTran.AdicionarParametros("@RGCliente", cliPF.RGCliente)
        '
        myQuery = "INSERT INTO tblPessoaCliente " &
                  "(IDCliente, IDSituacao, ClienteDesde, RGAtividade, LimiteCompras, " &
                  "UltimaVenda, RGCliente) " &
                  "VALUES " &
                  "(@IDPessoa, @IDSituacao, @ClienteDesde, @RGAtividade, @LimiteCompras, " &
                  "@UltimaVenda, @RGCliente);"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT TBLPESSOACLIENTEPF
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", cliPF.IDPessoa)
        dbTran.AdicionarParametros("@Naturalidade", cliPF.Naturalidade)
        dbTran.AdicionarParametros("@Pai", If(cliPF.Pai, DBNull.Value))
        dbTran.AdicionarParametros("@Mae", If(cliPF.Mae, DBNull.Value))
        dbTran.AdicionarParametros("@TrabalhoContratante", If(cliPF.TrabalhoContratante, DBNull.Value))
        dbTran.AdicionarParametros("@TrabalhoFuncao", If(cliPF.TrabalhoFuncao, DBNull.Value))
        dbTran.AdicionarParametros("@TrabalhoTelefone", If(cliPF.TrabalhoTelefone, DBNull.Value))
        dbTran.AdicionarParametros("@Renda", cliPF.Renda)
        dbTran.AdicionarParametros("@EstadoCivil", cliPF.EstadoCivil)
        dbTran.AdicionarParametros("@Conjuge", If(cliPF.Conjuge, DBNull.Value))
        dbTran.AdicionarParametros("@ConjugeRenda", If(cliPF.ConjugeRenda = 0, DBNull.Value, cliPF.ConjugeRenda))
        dbTran.AdicionarParametros("@Igreja", If(cliPF.Igreja, DBNull.Value))
        dbTran.AdicionarParametros("@IgrejaAtuacao", If(cliPF.IgrejaAtuacao, DBNull.Value))
        dbTran.AdicionarParametros("@IgrejaFuncao", If(cliPF.IgrejaFuncao, DBNull.Value))
        dbTran.AdicionarParametros("@FichaPrint", cliPF.FichaPrint)
        '
        myQuery = "INSERT INTO tblPessoaClientePF " &
                  "(IDCliente, Naturalidade, Pai, Mae, " &
                  "TrabalhoContratante, TrabalhoFuncao, TrabalhoTelefone, " &
                  "Renda, EstadoCivil, Conjuge, ConjugeRenda, " &
                  "Igreja, IgrejaAtuacao, IgrejaFuncao, FichaPrint) " &
                  "VALUES " &
                  "(@IDPessoa, @Naturalidade, @Pai, @Mae, " &
                  "@TrabalhoContratante, @TrabalhoFuncao, @TrabalhoTelefone, " &
                  "@Renda, @EstadoCivil, @Conjuge, @ConjugeRenda, " &
                  "@Igreja, @IgrejaAtuacao, @IgrejaFuncao, @FichaPrint);"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 3) INSERT OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        If Trim(If(cliPF.Observacao, "")).Length > 0 Then
            '
            Dim oBLL As New ObservacaoBLL
            '
            Try
                oBLL.SaveObservacao(4, cliPF.IDPessoa, cliPF.Observacao, dbTran)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
    End Sub
    '
    '--- CLIENTE PJ
    '----------------------------------------------------------------------------------
    Private Sub InsertClientePJ(cliPJ As clClientePJ, dbTran As AcessoDados)
        '
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) INSERT TBLPESSOACLIENTE
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", cliPJ.IDPessoa)
        dbTran.AdicionarParametros("@IDSituacao", cliPJ.IDSituacao)
        dbTran.AdicionarParametros("@ClienteDesde", If(cliPJ.ClienteDesde, Today))
        dbTran.AdicionarParametros("@RGAtividade", cliPJ.RGAtividade)
        dbTran.AdicionarParametros("@LimiteCompras", cliPJ.LimiteCompras)
        dbTran.AdicionarParametros("@UltimaVenda", If(cliPJ.UltimaVenda, DBNull.Value))
        dbTran.AdicionarParametros("@RGCliente", cliPJ.RGCliente)
        '
        myQuery = "INSERT INTO tblPessoaCliente " &
                  "(IDCliente, IDSituacao, ClienteDesde, RGAtividade, LimiteCompras, " &
                  "UltimaVenda, RGCliente) " &
                  "VALUES " &
                  "(@IDPessoa, @IDSituacao, @ClienteDesde, @RGAtividade, @LimiteCompras, " &
                  "@UltimaVenda, @RGCliente);"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        If Trim(If(cliPJ.Observacao, "")).Length > 0 Then
            '
            Dim oBLL As New ObservacaoBLL
            '
            Try
                oBLL.SaveObservacao(4, cliPJ.IDPessoa, cliPJ.Observacao, dbTran)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
    End Sub
    '
    '--- FORNECEDOR
    '----------------------------------------------------------------------------------
    Private Sub InsertFornecedor(forn As clFornecedor, dbTran As AcessoDados)
        '
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) INSERT TBLPESSOAFORNECEDOR
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", forn.IDPessoa)
        dbTran.AdicionarParametros("@Ativo", forn.Ativo)
        dbTran.AdicionarParametros("@Vendedor", If(forn.Vendedor, DBNull.Value))
        dbTran.AdicionarParametros("@EmailVendas", If(forn.EmailVendas, DBNull.Value))
        '
        myQuery = "INSERT INTO tblPessoaFornecedor " &
                  "(IDFornecedor, Ativo, Vendedor, EmailVendas) " &
                  "VALUES " &
                  "(@IDPessoa, @Ativo, @Vendedor, @EmailVendas);"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        If Trim(If(forn.Observacao, "")).Length > 0 Then
            '
            Dim oBLL As New ObservacaoBLL
            '
            Try
                oBLL.SaveObservacao(2, forn.IDPessoa, forn.Observacao, dbTran)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
    End Sub
    '
    '--- TRANSPORTADORA
    '----------------------------------------------------------------------------------
    Private Sub InsertTransportadora(transp As clTransportadora, dbTran As AcessoDados)
        '
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) INSERT TBLPESSOAFORNECEDOR
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", transp.IDPessoa)
        dbTran.AdicionarParametros("@Ativo", transp.Ativo)
        '
        myQuery = "INSERT INTO tblPessoaTransportadora " &
                  "(IDTransportadora, Ativo) " &
                  "VALUES " &
                  "(@IDPessoa, @Ativo);"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        If Trim(If(transp.Observacao, "")).Length > 0 Then
            '
            Dim oBLL As New ObservacaoBLL
            '
            Try
                oBLL.SaveObservacao(2, transp.IDPessoa, transp.Observacao, dbTran)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
    End Sub
    '
    '--- CREDOR
    '----------------------------------------------------------------------------------
    Private Sub InsertCredor(Credor As clCredor, dbTran As AcessoDados)
        '
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) INSERT TBLPESSOACREDOR
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", Credor.IDPessoa)
        dbTran.AdicionarParametros("@CredorTipo", Credor.CredorTipo)
        '
        myQuery = "INSERT INTO tblPessoaCredor " &
                  "(IDCredor, CredorTipo) " &
                  "VALUES " &
                  "(@IDPessoa, @CredorTipo);"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        If Trim(If(Credor.Observacao, "")).Length > 0 Then
            '
            Dim oBLL As New ObservacaoBLL
            '
            Try
                oBLL.SaveObservacao(15, Credor.IDPessoa, Credor.Observacao, dbTran)
            Catch ex As Exception
                Throw ex
            End Try
            '
        End If
        '
    End Sub
    '
    '--- FILIAL
    '----------------------------------------------------------------------------------
    Private Sub InsertFilial(Filial As clFilial, dbTran As AcessoDados)
        '
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) INSERT TBLPESSOAFILIAL
        '----------------------------------------------------------------------------------
        '// PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", Filial.IDPessoa)
        dbTran.AdicionarParametros("@ApelidoFilial", Filial.ApelidoFilial)
        dbTran.AdicionarParametros("@AliquotaICMS", Filial.AliquotaICMS)
        '
        myQuery = "INSERT INTO tblPessoaFilial (IDFilial, ApelidoFilial, AliquotaICMS, Ativo) " &
                  "VALUES (@IDPessoa, @ApelidoFilial, @AliquotaICMS ,'True')"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '


#End Region '/ INSERTS GROUP
    '
#Region "UPDATES GROUP"
    '
    '==========================================================================================
    ' ENTRY FUNCTIONS
    '==========================================================================================
    Public Function UpdatePessoa(myPessoa As Object,
                                 PessoaGrupo As EnumPessoaGrupo) As Boolean
        '
        '---1) CHECK CNP IS DUPLICATED
        '----------------------------------------------------------------------------------
        '--- obtain CNP from Pessoa of CPF or CNPJ
        Dim CNP As String = ""
        Dim findResult As String = ""
        Dim findPessoa As Object = Nothing
        '
        If Array.Exists(myPessoa.GetType().GetProperties(), Function(x) x.Name = "CPF") Then
            CNP = myPessoa.CPF
        ElseIf Array.Exists(myPessoa.GetType().GetProperties(), Function(x) x.Name = "CNPJ") Then
            CNP = myPessoa.CNPJ
        ElseIf Array.Exists(myPessoa.GetType().GetProperties(), Function(x) x.Name = "CNP") Then
            CNP = myPessoa.CNP
        Else '--> caso credor simples nao ha CNP
            CNP = ""
        End If
        '
        If myPessoa.PessoaTipo = 1 Then '---> Pessoa Fisica
            '
            Try
                If CheckCPFDuplication(CNP, myPessoa.IDPessoa) Then
                    Throw New Exception("O CPF informado já existe em outro registro de Pessoa Física...")
                End If
            Catch ex As Exception
                Throw ex
                Return False
            End Try
            '
        ElseIf myPessoa.PessoaTipo = 2 Then '---> Pessoa Juridica
            '
            Try
                If CheckCNPJDuplication(CNP, myPessoa.IDPessoa) Then
                    Throw New Exception("O CNPJ informado já existe em outro registro de Pessoa Jurídica...")
                End If
            Catch ex As Exception
                Throw ex
                Return False
            End Try
            '
        End If
        '
        '--- 2) CHECK DUPLICATION OF CADASTRO BEFORE UPDATE
        '----------------------------------------------------------------------------------
        Try
            Dim findedP As clPessoa = ProcuraPessoaPeloCadastroNome(myPessoa.Cadastro)
            '
            If Not IsNothing(findedP) Then
                If findedP.IDPessoa <> myPessoa.IDPessoa Then
                    Throw New Exception("O Nome do Cadastro informado já existe em outro registro de Pessoa...")
                End If
            End If
            '
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        '
        '--- 3) UPDATE FOR GROUP
        '----------------------------------------------------------------------------------
        '
        '--- get new Acesso with Transaction
        Dim db As New AcessoDados
        db.BeginTransaction()
        '
        Try
            '
            Select Case myPessoa.PessoaTipo
            '
                Case 1 '--> PESSOA FISICA
                    ' 
                    Select Case PessoaGrupo '--> CASOS DE PF ( CLIENTEPF | FUNCIONARIO | CREDOR )
                        '
                        Case EnumPessoaGrupo.CLIENTE
                            UpdateClientePF(DirectCast(myPessoa, clClientePF), db)

                        Case EnumPessoaGrupo.FUNCIONARIO
                            UpdateFuncionario(DirectCast(myPessoa, clFuncionario), db)

                        Case EnumPessoaGrupo.CREDOR
                            UpdateCredor(DirectCast(myPessoa, clCredor), db)

                    End Select
                    '
                    Dim PF As clPessoaFisica = DetachPessoaFisica(myPessoa)
                    UpdatePessoaFisica(PF, db) '--> UPDATE
                    '
                Case 2 '--> PESSOA JURIDICA
                    '
                    Select Case PessoaGrupo '--> CASOS DE PJ (CLIENTEPJ | FORNECEDOR | TRANSPORTADORA | CREDOR )
                        '
                        Case EnumPessoaGrupo.CLIENTE
                            UpdateClientePJ(DirectCast(myPessoa, clClientePJ), db)

                        Case EnumPessoaGrupo.FORNECEDOR
                            UpdateFornecedor(DirectCast(myPessoa, clFornecedor), db)

                        Case EnumPessoaGrupo.TRANSPORTADORA
                            UpdateTransportadora(DirectCast(myPessoa, clTransportadora), db)

                        Case EnumPessoaGrupo.CREDOR
                            UpdateCredor(DirectCast(myPessoa, clCredor), db)

                    End Select
                    '
                    Dim PJ As clPessoaJuridica = DetachPessoaJuridica(myPessoa)
                    UpdatePessoaJuridica(PJ, db) '--> UPDATE
                    '
                Case 4 '---> CREDOR SIMPLES
                    '
                    '--- UPDATE CREDOR
                    UpdateCredor(DirectCast(myPessoa, clCredor), db)
                    '
                    '--- UPDATE PESSOA SIMPLES
                    UpdatePessoaSimples(myPessoa.IDPessoa, myPessoa.Cadastro, myPessoa.PessoaTipo, db)
                    '
            End Select
            '
        Catch ex As Exception
            db.RollBackTransaction()
            Throw ex
            Return False
        End Try
        '
        db.CommitTransaction()
        Return True
        '
    End Function
    '
    '==========================================================================================
    ' UPDATES
    '==========================================================================================
    '
    '--- PESSOA SIMPLES
    '------------------------------------------------------------------------------------------
    Private Sub UpdatePessoaSimples(IDPessoa As Integer,
                                    CadastroNome As String,
                                    PessoaTipo As EnumPessoaTipo,
                                    dbTran As AcessoDados)
        '
        '--- ACCESS DATABASE AND TRANSACTION
        '----------------------------------------------------------------------------------
        '
        Dim dt As DataTable = Nothing
        Dim myQuery As String = ""
        '
        '--- 1) UPDATE TBLPESSOA
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", IDPessoa)
        dbTran.AdicionarParametros("@Cadastro", CadastroNome)
        dbTran.AdicionarParametros("@PessoaTipo", PessoaTipo)
        '
        myQuery = "UPDATE tblPessoa SET " &
                  "Cadastro = @Cadastro, PessoaTipo = @PessoaTipo " &
                  "WHERE IDPessoa = @IDPessoa"
        '
        '--- UPDATE
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- PESSOA FISICA
    '------------------------------------------------------------------------------------------
    Private Function UpdatePessoaFisica(PF As clPessoaFisica,
                                        dbTran As AcessoDados) As Integer?
        '
        '--- ACCESS DATABASE AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim db = If(dbTran, New AcessoDados)
        '
        Dim dt As DataTable = Nothing
        Dim myQuery As String = ""
        '
        '--- 1) UPDATE IN TBLPESSOA
        '----------------------------------------------------------------------------------
        Try
            UpdatePessoaSimples(PF.IDPessoa, PF.Cadastro, PF.PessoaTipo, dbTran)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) UPDATE IN TBLPESSOAFISICA
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PF.IDPessoa)
        db.AdicionarParametros("@CPF", PF.CPF)
        db.AdicionarParametros("@Sexo", PF.Sexo)
        db.AdicionarParametros("@NascimentoData", PF.NascimentoData)
        db.AdicionarParametros("@Identidade", PF.Identidade)
        db.AdicionarParametros("@IdentidadeOrgao", If(PF.IdentidadeOrgao, DBNull.Value))
        db.AdicionarParametros("@IdentidadeData", If(PF.IdentidadeData, DBNull.Value))
        '
        myQuery = "UPDATE tblPessoaFisica SET " &
                  "CPF = @CPF, " &
                  "Sexo = @Sexo, " &
                  "NascimentoData = @NascimentoData, " &
                  "Identidade = @Identidade, " &
                  "IdentidadeOrgao = @IdentidadeOrgao, " &
                  "IdentidadeData = @IdentidadeData " &
                  "WHERE " &
                  "IDPessoa = @IDPessoa"
        '
        '--- UPDATE
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- 3) UPDATE IN TBLPESSOAENDERECO
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PF.IDPessoa)
        db.AdicionarParametros("@Endereco", PF.Endereco)
        db.AdicionarParametros("@Bairro", PF.Bairro)
        db.AdicionarParametros("@Cidade", PF.Cidade)
        db.AdicionarParametros("@UF", PF.UF)
        db.AdicionarParametros("@CEP", PF.CEP)
        '
        myQuery = "UPDATE tblPessoaEndereco SET " &
                  "Endereco = @Endereco, " &
                  "Bairro = @Bairro, " &
                  "Cidade = @Cidade, " &
                  "UF = @UF, " &
                  "CEP = @CEP " &
                  "WHERE " &
                  "IDPessoa = @IDPessoa;"
        '
        '--- UPDATE
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- 4) UPDATE OR ADD IN TBLPESSOATELEFONE
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PF.IDPessoa)
        myQuery = "DELETE tblPessoaTelefone WHERE IDPessoa = @IDPessoa"
        '
        '--- DELETE
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- INSERT IF NECESSARY
        Dim checkTelefoneA As Boolean = Trim(If(PF.TelefoneA, "")).Length > 0  '(Not IsNothing(PF.TelefoneA)) AndAlso (PF.TelefoneA.Trim.Length > 0)
        Dim checkTelefoneB As Boolean = Trim(If(PF.TelefoneB, "")).Length > 0  '(Not IsNothing(PF.TelefoneB)) AndAlso (PF.TelefoneB.Trim.Length > 0)
        '
        If checkTelefoneA Or checkTelefoneB Then
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDPessoa", PF.IDPessoa)
            db.AdicionarParametros("@TelefoneA", If(PF.TelefoneA, DBNull.Value))
            db.AdicionarParametros("@TelefoneB", If(PF.TelefoneB, DBNull.Value))
            '
            myQuery = "INSERT INTO tblPessoaTelefone (IDPessoa, TelefoneA, TelefoneB) " &
                      "VALUES (@IDPessoa, @TelefoneA, @TelefoneB)"
            '
            Try
                db.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
            '
        End If
        '
        '--- 5) UPDATE OR ADD IN TBLPESSOAEMAIL
        '----------------------------------------------------------------------------------
        '
        '--- A. DELETE
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PF.IDPessoa)
        myQuery = "DELETE tblPessoaEmail WHERE IDPessoa = @IDPessoa"
        '
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- B. INSERT IF NECESSARY
        Dim checkEmail = Trim(If(PF.Email, "")).Length > 0
        '
        If checkEmail Then
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDPessoa", PF.IDPessoa)
            db.AdicionarParametros("@Email", PF.Email)
            '
            myQuery = "INSERT INTO tblPessoaEmail (IDPessoa, Email, EmailDestino, EmailPrincipal) " &
                      "VALUES (@IDPessoa, @Email, 'Principal', 'TRUE')"
            '
            Try
                db.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
            '
        End If
        '
        '--- RETURN
        Return PF.IDPessoa
        '
    End Function
    '
    '--- PESSOA JURIDICA
    '------------------------------------------------------------------------------------------
    Private Function UpdatePessoaJuridica(PJ As clPessoaJuridica,
                                          dbTran As AcessoDados) As Integer?
        '
        '--- ACCESS DATABASE AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim db = If(dbTran, New AcessoDados)
        '
        Dim dt As DataTable = Nothing
        Dim myQuery As String = ""
        '

        '
        '--- 2) UPDATE IN TBLPESSOA
        '----------------------------------------------------------------------------------
        Try
            UpdatePessoaSimples(PJ.IDPessoa, PJ.Cadastro, PJ.PessoaTipo, dbTran)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 3) UPDATE IN TBLPESSOAJURIDICA
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
        db.AdicionarParametros("@CNPJ", PJ.CNPJ)
        db.AdicionarParametros("@InscricaoEstadual", If(PJ.InscricaoEstadual, DBNull.Value))
        db.AdicionarParametros("@NomeFantasia", PJ.NomeFantasia)
        db.AdicionarParametros("@FundacaoData", If(PJ.FundacaoData, DBNull.Value))
        db.AdicionarParametros("@ContatoNome", If(PJ.ContatoNome, DBNull.Value))
        '
        myQuery = "UPDATE tblPessoaJuridica SET " &
                  "CNPJ = @CNPJ, " &
                  "InscricaoEstadual = @InscricaoEstadual, " &
                  "NomeFantasia = @NomeFantasia, " &
                  "FundacaoData = @FundacaoData, " &
                  "ContatoNome = @ContatoNome " &
                  "WHERE IDPessoa = @IDPessoa"
        '
        '--- UPDATE
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- 4) UPDATE IN TBLPESSOAENDERECO
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
        db.AdicionarParametros("@Endereco", PJ.Endereco)
        db.AdicionarParametros("@Bairro", PJ.Bairro)
        db.AdicionarParametros("@Cidade", PJ.Cidade)
        db.AdicionarParametros("@UF", PJ.UF)
        db.AdicionarParametros("@CEP", PJ.CEP)
        '
        myQuery = "UPDATE tblPessoaEndereco SET " &
                  "Endereco = @Endereco, " &
                  "Bairro = @Bairro, " &
                  "Cidade = @Cidade, " &
                  "UF = @UF, " &
                  "CEP = @CEP " &
                  "WHERE " &
                  "IDPessoa = @IDPessoa;"
        '
        '--- UPDATE
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- 5) UPDATE OR ADD IN TBLPESSOATELEFONE
        '----------------------------------------------------------------------------------
        '
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
        myQuery = "DELETE tblPessoaTelefone WHERE IDPessoa = @IDPessoa"
        '
        '--- DELETE
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- INSERT IF NECESSARY
        Dim checkTelefoneA As Boolean = Trim(If(PJ.TelefoneA, "")).Length > 0
        Dim checkTelefoneB As Boolean = Trim(If(PJ.TelefoneB, "")).Length > 0
        '
        If checkTelefoneA Or checkTelefoneB Then
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
            db.AdicionarParametros("@TelefoneA", If(PJ.TelefoneA, DBNull.Value))
            db.AdicionarParametros("@TelefoneB", If(PJ.TelefoneB, DBNull.Value))
            '
            myQuery = "INSERT INTO tblPessoaTelefone (IDPessoa, TelefoneA, TelefoneB) " &
                      "VALUES (@IDPessoa, @TelefoneA, @TelefoneB)"
            '
            Try
                db.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
            '
        End If
        '
        '--- 6) UPDATE OR ADD IN TBLPESSOAEMAIL
        '----------------------------------------------------------------------------------
        '
        '--- A. DELETE
        '--- PARAMNS
        db.LimparParametros()
        db.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
        myQuery = "DELETE tblPessoaEmail WHERE IDPessoa = @IDPessoa"
        '
        Try
            db.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
        '
        '--- B. INSERT IF NECESSARY
        Dim checkEmail = Trim(If(PJ.Email, "")).Length > 0
        '
        If checkEmail Then
            '
            db.LimparParametros()
            db.AdicionarParametros("@IDPessoa", PJ.IDPessoa)
            db.AdicionarParametros("@Email", PJ.TelefoneA)
            '
            myQuery = "INSERT INTO tblPessoaEmail (IDPessoa, Email, EmailDestino, EmailPrincipal) " &
                      "VALUES (@IDPessoa, @Email, 'Principal', 'TRUE')"
            '
            Try
                db.ExecutarManipulacao(CommandType.Text, myQuery)
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
            '
        End If
        '
        '--- RETURN
        Return PJ.IDPessoa
        '
    End Function
    '
    '--- FUNCIONARIO
    '------------------------------------------------------------------------------------------
    Private Sub UpdateFuncionario(ByVal _func As clFuncionario, dbTran As AcessoDados)
        '
        '--- ACESSO DB AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) UPDATE tblPessoaFuncionario
        '----------------------------------------------------------------------------------
        ' PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
        dbTran.AdicionarParametros("@AdmissaoData", _func.AdmissaoData)
        dbTran.AdicionarParametros("@Ativo", _func.Ativo)
        dbTran.AdicionarParametros("@Vendedor", _func.Vendedor)
        dbTran.AdicionarParametros("@ApelidoFuncionario", _func.ApelidoFuncionario)
        dbTran.AdicionarParametros("@IDFilial", _func.IDFilial)
        '
        myQuery = "UPDATE tblPessoaFuncionario SET " &
                  "AdmissaoData = @AdmissaoData " &
                  ", Ativo = @Ativo " &
                  ", Vendedor = @Vendedor " &
                  ", ApelidoFuncionario = @ApelidoFuncionario " &
                  ", IDFilial = @IDFilial " &
                  "WHERE IDFuncionario = @IDPessoa;"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT OR DELETE OR DISABLE IN tblPessoaVendedor
        '----------------------------------------------------------------------------------
        '
        '--- Check if exists Venda with this IDVendedor
        Try
            '--- FUNCIONARIO IS NOT VENDEDOR
            If _func.Vendedor = False Then
                '
                dbTran.LimparParametros()
                dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
                '
                myQuery = "SELECT COUNT(*) AS Total FROM tblVenda WHERE IDVendedor = @IDPessoa"
                '
                dt = dbTran.ExecutarConsulta(CommandType.Text, myQuery)
                If dt.Rows.Count = 0 Then Throw New Exception("Não foi possível consultar a tabela de Vendas...")
                '
                If dt.Rows(0)(0) = 0 Then '---> there aren't vendas with this funcionario
                    '
                    '--- DELETE tblPessoaVendedor
                    dbTran.LimparParametros()
                    dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
                    '
                    myQuery = "DELETE tblPessoaVendedor WHERE IDVendedor = @IDPessoa;"
                    dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
                    '
                Else
                    '
                    '--- UPDATE tblPessoaVendedor (ONLY DISABLE DON'T DELETE)
                    dbTran.LimparParametros()
                    dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
                    '
                    myQuery = "UPDATE tblPessoaVendedor SET " &
                              "Ativo = 'FALSE' " &
                              "WHERE IDVendedor = @IDPessoa;"
                    dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
                    '
                End If
                '
            Else '--- FUNCIONARIO IS VENDEDOR
                '
                dbTran.LimparParametros()
                dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
                '
                myQuery = "SELECT COUNT(*) AS Total FROM tblPessoaVendedor WHERE IDVendedor = @IDPessoa"
                dt = dbTran.ExecutarConsulta(CommandType.Text, myQuery)
                If dt.Rows.Count = 0 Then Throw New Exception("Não foi possível consultar a tabela de Vendedor...")
                '
                Dim funcIsVendedorInserido As Boolean = dt.Rows(0)(0) > 0
                '
                ' PARAMS
                dbTran.LimparParametros()
                dbTran.AdicionarParametros("@IDPessoa", _func.IDPessoa)
                dbTran.AdicionarParametros("@ApelidoVenda", _func.ApelidoFuncionario)
                dbTran.AdicionarParametros("@Comissao", If(_func.Comissao, 0))
                dbTran.AdicionarParametros("@VendaTipo", _func.VendaTipo)
                dbTran.AdicionarParametros("@VendedorAtivo", _func.VendedorAtivo)
                '
                '--- INSERT new tblPessoaVendedor
                If Not funcIsVendedorInserido Then '---> there aren't vendedor with this funcionario
                    '
                    myQuery = "INSERT INTO tblPessoaVendedor " &
                              "(IDVendedor, ApelidoVenda, Comissao, VendaTipo, Ativo) " &
                              "VALUES " &
                              "(@IDPessoa, @ApelidoVenda, @Comissao, @VendaTipo, @VendedorAtivo);"
                    dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
                    '
                Else
                    '
                    '--- UPDATE tblPessoaVendedor
                    myQuery = "UPDATE tblPessoaVendedor SET " &
                              "ApelidoVenda = @ApelidoVenda " &
                              ", Comissao = @Comissao " &
                              ", VendaTipo = @VendaTipo " &
                              ", Ativo = @VendedorAtivo " &
                              "WHERE IDVendedor = @IDPessoa;"
                    dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
                    '
                End If
                '
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CLIENTE PF
    '------------------------------------------------------------------------------------------
    Private Sub UpdateClientePF(cliPF As clClientePF, dbTran As AcessoDados)
        '
        '--- ACESSO DB AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) UPDATE tblPessoaCliente
        '----------------------------------------------------------------------------------
        ' PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", cliPF.IDPessoa)
        dbTran.AdicionarParametros("@IDSituacao", cliPF.IDSituacao)
        dbTran.AdicionarParametros("@ClienteDesde", cliPF.ClienteDesde)
        dbTran.AdicionarParametros("@RGAtividade", cliPF.RGAtividade)
        dbTran.AdicionarParametros("@LimiteCompras", cliPF.LimiteCompras)
        dbTran.AdicionarParametros("@UltimaVenda", cliPF.UltimaVenda)
        dbTran.AdicionarParametros("@RGCliente", cliPF.RGCliente)
        '
        myQuery = "UPDATE tblPessoaCliente SET " &
                  "IDSituacao = @IDSituacao, " &
                  "ClienteDesde = @ClienteDesde, " &
                  "RGAtividade = @RGAtividade, " &
                  "LimiteCompras = @LimiteCompras, " &
                  "UltimaVenda = @UltimaVenda, " &
                  "RGCliente = @RGCliente " &
                  "WHERE IDCliente = @IDPessoa"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) UPDATE tblPessoaClientePF
        '----------------------------------------------------------------------------------
        ' PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", cliPF.IDPessoa)
        dbTran.AdicionarParametros("@Naturalidade", cliPF.Naturalidade)
        dbTran.AdicionarParametros("@Pai", cliPF.Pai)
        dbTran.AdicionarParametros("@Mae", cliPF.Mae)
        dbTran.AdicionarParametros("@TrabalhoContratante", cliPF.TrabalhoContratante)
        dbTran.AdicionarParametros("@TrabalhoFuncao", cliPF.TrabalhoFuncao)
        dbTran.AdicionarParametros("@TrabalhoTelefone", cliPF.TrabalhoTelefone)
        dbTran.AdicionarParametros("@Renda", cliPF.Renda)
        dbTran.AdicionarParametros("@EstadoCivil", cliPF.EstadoCivil)
        dbTran.AdicionarParametros("@Conjuge", cliPF.Conjuge)
        dbTran.AdicionarParametros("@ConjugeRenda", cliPF.ConjugeRenda)
        dbTran.AdicionarParametros("@Igreja", cliPF.Igreja)
        dbTran.AdicionarParametros("@IgrejaAtuacao", cliPF.IgrejaAtuacao)
        dbTran.AdicionarParametros("@IgrejaFuncao", cliPF.IgrejaFuncao)
        dbTran.AdicionarParametros("@FichaPrint", cliPF.FichaPrint)
        '
        myQuery = "UPDATE tblPessoaClientePF SET " &
                  "Naturalidade = @Naturalidade, " &
                  "Pai = @Pai, Mae = @Mae, " &
                  "TrabalhoContratante = @TrabalhoContratante, " &
                  "TrabalhoFuncao = @TrabalhoFuncao, " &
                  "TrabalhoTelefone = @TrabalhoTelefone, " &
                  "Renda = @Renda, " &
                  "EstadoCivil = @EstadoCivil, " &
                  "Conjuge = @Conjuge, " &
                  "ConjugeRenda = @ConjugeRenda, " &
                  "Igreja = @Igreja, " &
                  "IgrejaAtuacao = @IgrejaAtuacao, " &
                  "IgrejaFuncao = @IgrejaFuncao, " &
                  "FichaPrint = @FichaPrint " &
                  "WHERE IDCliente = @IDPessoa;"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 3) INSERT/UPDATE OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        Dim oBLL As New ObservacaoBLL
        '
        Try
            oBLL.SaveObservacao(4, cliPF.IDPessoa, cliPF.Observacao, dbTran)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CLIENTE PJ
    '------------------------------------------------------------------------------------------
    Private Sub UpdateClientePJ(cliPJ As clClientePJ, dbTran As AcessoDados)
        '
        '--- ACESSO DB AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) UPDATE tblPessoaCliente
        '----------------------------------------------------------------------------------
        ' PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", cliPJ.IDPessoa)
        dbTran.AdicionarParametros("@IDSituacao", cliPJ.IDSituacao)
        dbTran.AdicionarParametros("@ClienteDesde", cliPJ.ClienteDesde)
        dbTran.AdicionarParametros("@RGAtividade", cliPJ.RGAtividade)
        dbTran.AdicionarParametros("@LimiteCompras", cliPJ.LimiteCompras)
        dbTran.AdicionarParametros("@UltimaVenda", cliPJ.UltimaVenda)
        dbTran.AdicionarParametros("@RGCliente", cliPJ.RGCliente)
        '
        myQuery = "UPDATE tblPessoaCliente SET " &
                  "IDSituacao = @IDSituacao, " &
                  "ClienteDesde = @ClienteDesde, " &
                  "RGAtividade = @RGAtividade, " &
                  "LimiteCompras = @LimiteCompras, " &
                  "UltimaVenda = @UltimaVenda, " &
                  "RGCliente = @RGCliente " &
                  "WHERE IDCliente = @IDPessoa"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT/UPDATE OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        Dim oBLL As New ObservacaoBLL
        '
        Try
            oBLL.SaveObservacao(4, cliPJ.IDPessoa, cliPJ.Observacao, dbTran)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- FORNECEDOR
    '------------------------------------------------------------------------------------------
    Private Sub UpdateFornecedor(forn As clFornecedor, dbTran As AcessoDados)
        '
        '--- ACESSO DB AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) UPDATE tblPessoaFornecedor
        '----------------------------------------------------------------------------------
        ' PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", forn.IDPessoa)
        dbTran.AdicionarParametros("@Ativo", forn.Ativo)
        dbTran.AdicionarParametros("@Vendedor", forn.Vendedor)
        dbTran.AdicionarParametros("@EmailVendas", forn.EmailVendas)
        '
        myQuery = "UPDATE tblPessoaFornecedor SET " &
                  "Ativo = @Ativo " &
                  ", Vendedor = @Vendedor " &
                  ", EmailVendas = @EmailVendas " &
                  "WHERE IDFornecedor = @IDPessoa;"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT/UPDATE OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        Dim oBLL As New ObservacaoBLL
        '
        Try
            oBLL.SaveObservacao(2, forn.IDPessoa, forn.Observacao, dbTran)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- TRANSPORTADORA
    '------------------------------------------------------------------------------------------
    Private Sub UpdateTransportadora(transp As clTransportadora, dbTran As AcessoDados)
        '
        '--- ACESSO DB AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) UPDATE tblPessoaTransportadora
        '----------------------------------------------------------------------------------
        ' PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", transp.IDPessoa)
        dbTran.AdicionarParametros("@Ativo", transp.Ativo)
        '
        myQuery = "UPDATE tblPessoaTransportadora SET " &
                  "Ativo = @Ativo " &
                  "WHERE IDTransportadora = @IDPessoa;"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT/UPDATE OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        Dim oBLL As New ObservacaoBLL
        '
        Try
            oBLL.SaveObservacao(2, transp.IDPessoa, transp.Observacao, dbTran)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub
    '
    '--- CREDOR
    '------------------------------------------------------------------------------------------
    Private Sub UpdateCredor(cred As clCredor, dbTran As AcessoDados)
        '
        '--- ACESSO DB AND TRANSACTION
        '----------------------------------------------------------------------------------
        Dim myQuery As String = ""
        Dim dt As DataTable = Nothing
        '
        '--- 1) UPDATE tblPessoaTransportadora
        '----------------------------------------------------------------------------------
        ' PARAMNS
        dbTran.LimparParametros()
        dbTran.AdicionarParametros("@IDPessoa", cred.IDPessoa)
        dbTran.AdicionarParametros("@Ativo", cred.Ativo)
        dbTran.AdicionarParametros("@CredorTipo", cred.CredorTipo)
        '
        myQuery = "UPDATE tblPessoaCredor SET " &
                  "CredorTipo = @CredorTipo " &
                  ",Ativo = @Ativo " &
                  "WHERE IDCredor = @IDPessoa;"
        '
        Try
            dbTran.ExecutarManipulacao(CommandType.Text, myQuery)
        Catch ex As Exception
            Throw ex
        End Try
        '
        '--- 2) INSERT/UPDATE OBSERVACAO IF NECESSARY
        '----------------------------------------------------------------------------------
        Dim oBLL As New ObservacaoBLL
        '
        Try
            oBLL.SaveObservacao(15, cred.IDPessoa, cred.Observacao, dbTran)
        Catch ex As Exception
            Throw ex
        End Try
        '
    End Sub

#End Region '/ UPDATES GROUP
    '
#Region "CONVERT ROW IN PESSOA OF"
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UM clPessoaFisica OU UM clPessoaJuridica
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConverteDtRow_Pessoa(myRow As DataRow) As Object
        If myRow("PessoaTipo") = 1 Then
            Dim PF As New clPessoaFisica
            '
            PF.IDPessoa = myRow("IDPessoa")
            PF.Cadastro = If(IsDBNull(myRow("Cadastro")), String.Empty, myRow("Cadastro"))
            PF.Sexo = If(IsDBNull(myRow("Sexo")), Nothing, myRow("Sexo"))
            PF.CPF = If(IsDBNull(myRow("CPF")), String.Empty, myRow("CPF"))
            PF.Identidade = If(IsDBNull(myRow("Identidade")), String.Empty, myRow("Identidade"))
            PF.IdentidadeOrgao = If(IsDBNull(myRow("IdentidadeOrgao")), String.Empty, myRow("IdentidadeOrgao"))
            PF.IdentidadeData = If(IsDBNull(myRow("IdentidadeData")), Nothing, myRow("IdentidadeData"))
            PF.NascimentoData = If(IsDBNull(myRow("NascimentoData")), Nothing, myRow("NascimentoData"))
            '
            PF.Endereco = If(IsDBNull(myRow("Endereco")), String.Empty, myRow("Endereco"))
            PF.Bairro = If(IsDBNull(myRow("Bairro")), String.Empty, myRow("Bairro"))
            PF.Cidade = If(IsDBNull(myRow("Cidade")), String.Empty, myRow("Cidade"))
            PF.UF = If(IsDBNull(myRow("UF")), String.Empty, myRow("UF"))
            PF.CEP = If(IsDBNull(myRow("CEP")), String.Empty, myRow("CEP"))
            '
            PF.Email = If(IsDBNull(myRow("Email")), String.Empty, myRow("Email"))
            PF.TelefoneA = If(IsDBNull(myRow("TelefoneA")), String.Empty, myRow("TelefoneA"))
            PF.TelefoneB = If(IsDBNull(myRow("TelefoneB")), String.Empty, myRow("TelefoneB"))
            '
            Return PF
        ElseIf myRow("PessoaTipo") = 2 Then
            Dim PJ As New clPessoaJuridica
            '
            With PJ
                .IDPessoa = If(IsDBNull(myRow("IDPessoa")), Nothing, myRow("IDPessoa"))
                .Cadastro = If(IsDBNull(myRow("Cadastro")), String.Empty, myRow("Cadastro"))
                .CNPJ = If(IsDBNull(myRow("CNPJ")), String.Empty, myRow("CNPJ"))
                .InscricaoEstadual = If(IsDBNull(myRow("InscricaoEstadual")), String.Empty, myRow("InscricaoEstadual"))
                .FundacaoData = If(IsDBNull(myRow("FundacaoData")), Nothing, myRow("FundacaoData"))
                .ContatoNome = If(IsDBNull(myRow("ContatoNome")), String.Empty, myRow("ContatoNome"))
                .NomeFantasia = If(IsDBNull(myRow("NomeFantasia")), String.Empty, myRow("NomeFantasia"))
                '
                .Endereco = If(IsDBNull(myRow("Endereco")), String.Empty, myRow("Endereco"))
                .Bairro = If(IsDBNull(myRow("Bairro")), String.Empty, myRow("Bairro"))
                .Cidade = If(IsDBNull(myRow("Cidade")), String.Empty, myRow("Cidade"))
                .UF = If(IsDBNull(myRow("UF")), String.Empty, myRow("UF"))
                .CEP = If(IsDBNull(myRow("CEP")), String.Empty, myRow("CEP"))
                '
                .Email = If(IsDBNull(myRow("Email")), String.Empty, myRow("Email"))
                .TelefoneA = If(IsDBNull(myRow("TelefoneA")), String.Empty, myRow("TelefoneA"))
                .TelefoneB = If(IsDBNull(myRow("TelefoneB")), String.Empty, myRow("TelefoneB"))
            End With
            '
            Return PJ
        Else
            Return Nothing
        End If
        '
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UM clClientePF OU UM clClientePJ
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Cliente(r As DataRow) As Object
        If r("PessoaTipo") = 1 Then
            Dim CliPF As New clClientePF
            With CliPF
                ' PESSOA FISICA
                .IDPessoa = r("IDPessoa")
                .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                .Sexo = If(IsDBNull(r("Sexo")), Nothing, r("Sexo"))
                .CPF = If(IsDBNull(r("CPF")), String.Empty, r("CPF"))
                .Identidade = If(IsDBNull(r("Identidade")), String.Empty, r("Identidade"))
                .IdentidadeOrgao = If(IsDBNull(r("IdentidadeOrgao")), String.Empty, r("IdentidadeOrgao"))
                .IdentidadeData = If(IsDBNull(r("IdentidadeData")), Nothing, r("IdentidadeData"))
                .NascimentoData = If(IsDBNull(r("NascimentoData")), Nothing, r("NascimentoData"))
                '
                .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
                .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
                .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
                .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
                .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
                '
                .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
                .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
                .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
                '
                ' PESSOA CLIENTE
                .IDSituacao = If(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
                .ClienteDesde = If(IsDBNull(r("ClienteDesde")), Nothing, r("ClienteDesde"))
                .RGAtividade = If(IsDBNull(r("RGAtividade")), Nothing, r("RGAtividade"))
                .LimiteCompras = If(IsDBNull(r("LimiteCompras")), Nothing, r("LimiteCompras"))
                .UltimaVenda = If(IsDBNull(r("UltimaVenda")), Nothing, r("UltimaVenda"))
                .RGCliente = If(IsDBNull(r("RGCliente")), Nothing, r("RGCliente"))
                .Observacao = If(IsDBNull(r("Observacao")), "", r("Observacao"))
                ' PESSOA CLIENTEPF
                .Naturalidade = If(IsDBNull(r("Naturalidade")), String.Empty, r("Naturalidade"))
                .Pai = If(IsDBNull(r("Pai")), String.Empty, r("Pai"))
                .Mae = If(IsDBNull(r("Mae")), String.Empty, r("Mae"))
                .TrabalhoContratante = If(IsDBNull(r("TrabalhoContratante")), String.Empty, r("TrabalhoContratante"))
                .TrabalhoFuncao = If(IsDBNull(r("TrabalhoFuncao")), String.Empty, r("TrabalhoFuncao"))
                .TrabalhoTelefone = If(IsDBNull(r("TrabalhoTelefone")), String.Empty, r("TrabalhoTelefone"))
                .Renda = If(IsDBNull(r("Renda")), Nothing, r("Renda"))
                .EstadoCivil = If(IsDBNull(r("EstadoCivil")), Nothing, r("EstadoCivil"))
                .Conjuge = If(IsDBNull(r("Conjuge")), String.Empty, r("Conjuge"))
                .ConjugeRenda = If(IsDBNull(r("ConjugeRenda")), Nothing, r("ConjugeRenda"))
                .Igreja = If(IsDBNull(r("Igreja")), String.Empty, r("Igreja"))
                .IgrejaAtuacao = If(IsDBNull(r("IgrejaAtuacao")), String.Empty, r("IgrejaAtuacao"))
                .IgrejaFuncao = If(IsDBNull(r("IgrejaFuncao")), String.Empty, r("IgrejaFuncao"))
                .FichaPrint = If(IsDBNull(r("FichaPrint")), Nothing, r("FichaPrint"))
            End With
            '
            Return CliPF
        Else
            Dim CliPJ As New clClientePJ
            '
            With CliPJ
                .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
                .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
                .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
                .InscricaoEstadual = If(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual"))
                .FundacaoData = If(IsDBNull(r("FundacaoData")), Nothing, r("FundacaoData"))
                .ContatoNome = If(IsDBNull(r("ContatoNome")), String.Empty, r("ContatoNome"))
                .NomeFantasia = If(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia"))
                '
                .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
                .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
                .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
                .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
                .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
                '
                .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
                .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
                .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
                '
                ' PESSOA CLIENTE
                .IDSituacao = If(IsDBNull(r("IDSituacao")), Nothing, r("IDSituacao"))
                .ClienteDesde = If(IsDBNull(r("ClienteDesde")), Nothing, r("ClienteDesde"))
                .RGAtividade = If(IsDBNull(r("RGAtividade")), Nothing, r("RGAtividade"))
                .LimiteCompras = If(IsDBNull(r("LimiteCompras")), Nothing, r("LimiteCompras"))
                .UltimaVenda = If(IsDBNull(r("UltimaVenda")), Nothing, r("UltimaVenda"))
                .RGCliente = If(IsDBNull(r("RGCliente")), Nothing, r("RGCliente"))
                .Observacao = If(IsDBNull(r("Observacao")), "", r("Observacao"))
            End With
            '
            Return CliPJ ' RETORNA ClientePJ
        End If
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UM clFuncionario
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Funcionario(r As DataRow) As clFuncionario
        Dim CliFunc As New clFuncionario
        With CliFunc
            ' PESSOA FISICA
            .IDPessoa = r("IDPessoa")
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            .Sexo = If(IsDBNull(r("Sexo")), Nothing, r("Sexo"))
            .CPF = If(IsDBNull(r("CPF")), String.Empty, r("CPF"))
            .Identidade = If(IsDBNull(r("Identidade")), String.Empty, r("Identidade"))
            .IdentidadeOrgao = If(IsDBNull(r("IdentidadeOrgao")), String.Empty, r("IdentidadeOrgao"))
            .IdentidadeData = If(IsDBNull(r("IdentidadeData")), Nothing, r("IdentidadeData"))
            .NascimentoData = If(IsDBNull(r("NascimentoData")), Nothing, r("NascimentoData"))
            '
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
            '
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
            .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
            .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
            '
            ' PESSOA FUNCIONARIO
            .AdmissaoData = If(IsDBNull(r("AdmissaoData")), Nothing, r("AdmissaoData"))
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
            .Vendedor = If(IsDBNull(r("AdmissaoData")), Nothing, r("AdmissaoData"))
            .ApelidoFuncionario = If(IsDBNull(r("ApelidoFuncionario")), String.Empty, r("ApelidoFuncionario"))
            ' PESSOA VENDEDOR
            .Comissao = If(IsDBNull(r("Comissao")), Nothing, r("Comissao"))
            .VendaTipo = If(IsDBNull(r("VendaTipo")), Nothing, r("VendaTipo"))
            .VendedorAtivo = If(IsDBNull(r("VendedorAtivo")), Nothing, r("VendedorAtivo"))
        End With
        '
        Return CliFunc
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' CONVERTE UM DATAROW EM UM CLTransportadora
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Transportadora(r As DataRow) As clTransportadora
        Dim Transp As New clTransportadora
        With Transp
            ' PESSOA JURIDICA
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
            .InscricaoEstadual = If(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual"))
            .FundacaoData = If(IsDBNull(r("FundacaoData")), Nothing, r("FundacaoData"))
            .ContatoNome = If(IsDBNull(r("ContatoNome")), String.Empty, r("ContatoNome"))
            .NomeFantasia = If(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia"))
            '
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
            '
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
            .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
            .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
            '
            ' PESSOA TRANSPORTADORA
            .IDPessoa = If(IsDBNull(r("IDTransportadora")), Nothing, r("IDTransportadora"))
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
            .Observacao = If(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        End With
        '
        Return Transp
    End Function
    '
    '------------------------------------------------------------------------------------------------------------------------------------------------
    ' FUNCAO QUE CONVERTE UM DATAROW EM UM clFornecedor
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Private Function ConvertDtRow_Fornecedor(r As DataRow) As clFornecedor
        Dim Forn As New clFornecedor
        With Forn
            ' PESSOA FISICA
            .IDPessoa = If(IsDBNull(r("IDPessoa")), Nothing, r("IDPessoa"))
            .Cadastro = If(IsDBNull(r("Cadastro")), String.Empty, r("Cadastro"))
            .CNPJ = If(IsDBNull(r("CNPJ")), String.Empty, r("CNPJ"))
            .InscricaoEstadual = If(IsDBNull(r("InscricaoEstadual")), String.Empty, r("InscricaoEstadual"))
            .FundacaoData = If(IsDBNull(r("FundacaoData")), Nothing, r("FundacaoData"))
            .ContatoNome = If(IsDBNull(r("ContatoNome")), String.Empty, r("ContatoNome"))
            .NomeFantasia = If(IsDBNull(r("NomeFantasia")), String.Empty, r("NomeFantasia"))
            '
            .Endereco = If(IsDBNull(r("Endereco")), String.Empty, r("Endereco"))
            .Bairro = If(IsDBNull(r("Bairro")), String.Empty, r("Bairro"))
            .Cidade = If(IsDBNull(r("Cidade")), String.Empty, r("Cidade"))
            .UF = If(IsDBNull(r("UF")), String.Empty, r("UF"))
            .CEP = If(IsDBNull(r("CEP")), String.Empty, r("CEP"))
            '
            .Email = If(IsDBNull(r("Email")), String.Empty, r("Email"))
            .TelefoneA = If(IsDBNull(r("TelefoneA")), String.Empty, r("TelefoneA"))
            .TelefoneB = If(IsDBNull(r("TelefoneB")), String.Empty, r("TelefoneB"))
            '
            ' PESSOA TRANSPORTADORA
            .IDPessoa = If(IsDBNull(r("IDFornecedor")), Nothing, r("IDFornecedor"))
            .Ativo = If(IsDBNull(r("Ativo")), Nothing, r("Ativo"))
            .Observacao = If(IsDBNull(r("Observacao")), String.Empty, r("Observacao"))
        End With
        '
        Return Forn
    End Function
    '
#End Region '/ CONVERT ROW IN PESSOA OF
    '
End Class
