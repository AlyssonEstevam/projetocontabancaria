USE ProjetoContaBancaria
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[InsOperacao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[InsOperacao]
GO 

CREATE PROCEDURE [dbo].[InsOperacao]
	@Dat_Data			DATE,
	@Nom_TipoOperacao	VARCHAR(50),
	@Ind_TipoMovimento	CHAR(1),
	@Vlr_Valor			DECIMAL(18,0),
	@Num_NumeroConta	DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Insere uma operação efetuada na tabela de operações.
	Autor.............: Alysson Estevam
 	Data..............: 17/01/2020
	Ex................: EXEC [dbo].[InsOperacao] '17/01/2020', 'SAQUE', 'D', '1000', '2050'
	*/

	BEGIN
		INSERT INTO [dbo].[Operacoes]
			(Dat_Data, Nom_TipoOperacao, 
			Ind_TipoMovimento, Vlr_Valor, Num_NumeroConta)
		VALUES(@Dat_Data, @Nom_TipoOperacao, 
			@Ind_TipoMovimento, @Vlr_Valor, @Num_NumeroConta)
		RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelOperacao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelOperacao]
GO 

CREATE PROCEDURE [dbo].[SelOperacao]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Seleciona todas as tuplas da tabela Operacoes.
	Autor.............: Alysson Estevam
 	Data..............: 17/01/2020
	Ex................: EXEC [dbo].[SelOperacao]
	*/

	BEGIN
		SELECT * 
		FROM [dbo].[Operacoes] WITH (NOLOCK) 
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelPorIdOperacao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelPorIdOperacao]
GO 

CREATE PROCEDURE [dbo].[SelPorIdOperacao]
	@Num_Codigo	DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Seleciona uma tupla da tabela Operacao correspondente ao ID recebido.
	Autor.............: Alysson Estevam
 	Data..............: 24/01/2020
	Ex................: EXEC [dbo].[SelPorIdOperacao] '15'
	*/

	BEGIN
		SELECT * 
		FROM [dbo].[Operacoes] WITH (NOLOCK) 
		WHERE Num_Codigo = @Num_Codigo
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelPorContaOperacao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelPorContaOperacao]
GO 

CREATE PROCEDURE [dbo].[SelPorContaOperacao]
	@Num_NumeroConta		DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Seleciona todas as operações da conta referenciada.
	Autor.............: Alysson Estevam
 	Data..............: 17/01/2020
	Ex................: EXEC [dbo].[SelPorContaOperacao] '2050'
	*/

	BEGIN
		SELECT * 
		FROM [dbo].[Operacoes] WITH (NOLOCK) 
		WHERE Num_NumeroConta = @Num_NumeroConta
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[UpdEstorno]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[UpdEstorno]
GO 

CREATE PROCEDURE [dbo].[UpdEstorno]
	@Num_Codigo			DECIMAL(18,0),
	@Ind_TipoMovimento	CHAR(1),
	@Vlr_Valor			DECIMAL(18,0),
	@Num_NumeroConta	DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Realiza a operação de estorno em uma operação.
	Autor.............: Alysson Estevam
 	Data..............: 24/01/2020
	Ex................: EXEC [dbo].[UpdEstorno] '15', 'D', '1000', '2050'
	*/

	BEGIN
		DECLARE @Vlr_TempSaldoAtual MONEY;
		SELECT @Vlr_TempSaldoAtual = Vlr_Saldo 
			FROM [dbo].[Contas] WITH (NOLOCK) 
			WHERE Num_NumeroConta = @Num_NumeroConta;

		IF(@Ind_TipoMovimento = 'C')
			SET @Vlr_TempSaldoAtual = @Vlr_TempSaldoAtual - @Vlr_Valor;
		ELSE IF(@Ind_TipoMovimento = 'D')
			SET @Vlr_TempSaldoAtual = @Vlr_TempSaldoAtual + @Vlr_Valor;

		UPDATE [dbo].[Contas]
		SET Vlr_Saldo = @Vlr_TempSaldoAtual
		WHERE Num_NumeroConta = @Num_NumeroConta;

		DELETE FROM [dbo].[Operacoes]
		WHERE Num_Codigo = @Num_Codigo;

		RETURN 0;
	END
GO