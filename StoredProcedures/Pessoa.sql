USE ProjetoContaBancaria
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[InsPessoa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[InsPessoa]
GO 

CREATE PROCEDURE [dbo].[InsPessoa]
	@Num_Cpf				DECIMAL(18,0),
	@Nom_Nome				VARCHAR(100),
	@Nom_Sobrenome			VARCHAR(100),
	@Dat_DataNascimento		DATE,
	@Ind_Sexo				CHAR(1),
	@Vlr_Renda				MONEY,
	@Num_NumeroConta		DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Pessoa.sql
	Objetivo..........: Insere entidade Pessoa.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[InsPessoa] '77397016022', 'Alysson', 'Estevam', '28-06-1999', 'M', '3000', '1520'
	*/

	BEGIN
		INSERT INTO [dbo].[Pessoas]
			(Num_Cpf, Nom_Nome, Nom_Sobrenome, Dat_DataNascimento, 
			Ind_Sexo, Vlr_Renda, Num_NumeroConta)
		VALUES(@Num_Cpf, @Nom_Nome, @Nom_Sobrenome, @Dat_DataNascimento, 
			@Ind_Sexo, @Vlr_Renda, @Num_NumeroConta)
		RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelPessoa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelPessoa]
GO 

CREATE PROCEDURE [dbo].[SelPessoa]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Pessoa.sql
	Objetivo..........: Seleciona todas as tuplas da tabela Pessoa.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[SelPessoa]
	*/

	BEGIN
		SELECT * 
		FROM [dbo].[Pessoas] WITH (NOLOCK)
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelPorIdPessoa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelPorIdPessoa]
GO 

CREATE PROCEDURE [dbo].[SelPorIdPessoa]
	@Num_Cpf	DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Pessoa.sql
	Objetivo..........: Seleciona uma tupla da tabela Pessoa correspondente ao ID recebido.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[SelPorIdPessoa] '77397016022'
	*/

	BEGIN
		SELECT * 
		FROM [dbo].[Pessoas] WITH (NOLOCK)
		WHERE Num_Cpf = @Num_Cpf
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[DelPessoa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[DelPessoa]
GO 

CREATE PROCEDURE [dbo].[DelPessoa]
	@Num_Cpf	DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Pessoa.sql
	Objetivo..........: Remove da tabela pessoa a instância com o ID especificado.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[DelPessoa] '77397016022'
	*/
	
	BEGIN 
		DELETE FROM [dbo].[Pessoas] 
		WHERE Num_Cpf = @Num_Cpf

		RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[UpdPessoa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[UpdPessoa]
GO 

CREATE PROCEDURE [dbo].[UpdPessoa]
	@Num_Cpf				DECIMAL(18,0),
	@Nom_Nome				VARCHAR(100),
	@Nom_Sobrenome			VARCHAR(100),
	@Dat_DataNascimento		DATE,
	@Ind_Sexo				CHAR(1),
	@Vlr_Renda				MONEY,
	@Num_NumeroConta		DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Pessoa.sql
	Objetivo..........: Altera os dados da instância especificada com os dados passados.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[UpdPessoa] '77397016022', 'Roberto', 'Falcão', '30/10/2005', 'M', '2000', '2050'
	*/

	BEGIN
		UPDATE [dbo].[Pessoas] 
			SET Nom_Nome = @Nom_Nome, 
				Nom_Sobrenome = @Nom_Sobrenome, 
				Dat_DataNascimento = @Dat_DataNascimento, 
				Ind_Sexo = @Ind_Sexo, 
				Vlr_Renda = @Vlr_Renda, 
				Num_NumeroConta = @Num_NumeroConta
		WHERE Num_Cpf = @Num_Cpf
		RETURN 0
	END
GO