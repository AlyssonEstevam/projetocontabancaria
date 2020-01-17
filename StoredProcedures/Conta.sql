USE ProjetoContaBancaria
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[InsConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[InsConta]
GO 

CREATE PROCEDURE [dbo].[InsConta]
	@Num_NumeroConta	DECIMAL(18,0),
	@Vlr_Saldo			MONEY,
	@Ind_ContaAtiva		BIT

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Insere entidade Conta.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[InsConta] '1050', '0', '1'
	*/

	BEGIN
		DECLARE @Dat_DataAtual DATE;
		SET @Dat_DataAtual = GETDATE();

		INSERT INTO [dbo].[Contas]
			(Num_NumeroConta, Vlr_Saldo, 
			Dat_DataAbertura, Ind_ContaAtiva)
		VALUES(@Num_NumeroConta, @Vlr_Saldo, 
			@Dat_DataAtual, @Ind_ContaAtiva)
		RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelConta]
GO 

CREATE PROCEDURE [dbo].[SelConta]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Seleciona todas as tuplas da tabela Conta.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[SelConta]
	*/

	BEGIN
		SELECT * 
		FROM [dbo].[Contas] WITH (NOLOCK) 
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelPorIdConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelPorIdConta]
GO 

CREATE PROCEDURE [dbo].[SelPorIdConta]
	@Num_NumeroConta	DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Seleciona uma tupla da tabela Conta correspondente ao ID recebido.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[SelPorIdConta] '1050'
	*/

	BEGIN
		SELECT * 
		FROM [dbo].[Contas] WITH (NOLOCK) 
		WHERE Num_NumeroConta = @Num_NumeroConta
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[DelConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[DelConta]
GO 

CREATE PROCEDURE [dbo].[DelConta]
	@Num_NumeroConta DECIMAL(18,0)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Remove da tabela conta a instância com o ID especificado.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[DelConta] '1050'
	*/

	BEGIN
		DELETE FROM [dbo].[Contas] 
		WHERE Num_NumeroConta = @Num_NumeroConta

		RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[UpdConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[UpdConta]
GO

CREATE PROCEDURE [dbo].[UpdConta]

	@Num_NumeroConta	DECIMAL(18,0),
	@Vlr_Saldo			MONEY,
	@Dat_DataAbertura	DATE,
	@Ind_ContaAtiva		BIT

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Altera os dados da instância especificada com os dados passados.
	Autor.............: Alysson Estevam
 	Data..............: 14/01/2020
	Ex................: EXEC [dbo].[UpdConta] '1050', '1000', '14/01/2021', '0'
	*/

	BEGIN
		UPDATE [dbo].[Contas] 
			SET Vlr_Saldo = @Vlr_Saldo, 
				Dat_DataAbertura = @Dat_DataAbertura, 
				Ind_ContaAtiva = @Ind_ContaAtiva
		WHERE Num_NumeroConta = @Num_NumeroConta
		RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[UpdRealizaDeposito]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[UpdRealizaDeposito]
GO

CREATE PROCEDURE [dbo].[UpdRealizaDeposito]

	@Num_NumeroConta		DECIMAL(18,0),
	@Vlr_ValorDeposito		MONEY

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Realiza o depósito do valor especificado na conta especificada caso possível.
	Autor.............: Alysson Estevam
 	Data..............: 16/01/2020
	Comentários.......: Parâmetro Status :
						0 - Depósito realizado
						1 - Conta inativa
						2 - Valor de depósito negativo

	Ex................: EXEC [dbo].[UpdRealizaDeposito] '1050', '1000'
	*/

	BEGIN
		DECLARE @Ind_TempContaAtiva BIT;
		SELECT @Ind_TempContaAtiva = Ind_ContaAtiva 
		FROM [dbo].[Contas] WITH (NOLOCK) 
		WHERE Num_NumeroConta = @Num_NumeroConta;
		
		IF (@Ind_TempContaAtiva = 0)
			RETURN 1;
		IF (@Vlr_ValorDeposito <= 0)
			RETURN 2;
		ELSE
			DECLARE @Vlr_TempSaldoAtual MONEY;
			SELECT @Vlr_TempSaldoAtual = Vlr_Saldo 
			FROM [dbo].[Contas] WITH (NOLOCK) 
			WHERE Num_NumeroConta = @Num_NumeroConta;
		
			SET @Vlr_TempSaldoAtual = @Vlr_TempSaldoAtual + @Vlr_ValorDeposito;					

			UPDATE [dbo].[Contas] 
				SET Vlr_Saldo = @Vlr_TempSaldoAtual 
				WHERE Num_NumeroConta = @Num_NumeroConta;
			
			DECLARE @Dat_DataAtual DATE;
			SET @Dat_DataAtual = GETDATE();

			EXEC [dbo].[InsOperacao] @Dat_DataAtual, 'DEPOSITO', 'C', @Vlr_ValorDeposito, @Num_NumeroConta;

			RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[UpdRealizaSaque]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[UpdRealizaSaque]
GO

CREATE PROCEDURE [dbo].[UpdRealizaSaque]

	@Num_NumeroConta	DECIMAL(18,0),
	@Vlr_ValorSaque		MONEY

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Realiza o saque do valor especificado na conta especificada caso possível.
	Autor.............: Alysson Estevam
 	Data..............: 16/01/2020
	Comentários.......: Parâmetro Status :
						0 - Saque realizado
						1 - Conta inativa
						2 - Valor de saque negativo
						3 - Saldo atual insuficiente
	Ex................: EXEC [dbo].[UpdRealizaSaque] '1050', '1000'
	*/

	BEGIN
		DECLARE @Ind_TempContaAtiva BIT;
		SELECT @Ind_TempContaAtiva = Ind_ContaAtiva 
		FROM [dbo].[Contas] WITH (NOLOCK) 
		WHERE Num_NumeroConta = @Num_NumeroConta
		
		IF (@Ind_TempContaAtiva = 0)
			RETURN 1;
		IF (@Vlr_ValorSaque <= 0)
			RETURN 2;
		ELSE
			DECLARE @Vlr_TempSaldoAtual MONEY;
			SELECT @Vlr_TempSaldoAtual = Vlr_Saldo 
			FROM [dbo].[Contas] WITH (NOLOCK) 
			WHERE Num_NumeroConta = @Num_NumeroConta
		
			IF (@Vlr_ValorSaque > @Vlr_TempSaldoAtual)
				RETURN 3;
			ELSE
				SET @Vlr_TempSaldoAtual = @Vlr_TempSaldoAtual - @Vlr_ValorSaque;					

				UPDATE [dbo].[Contas] 
					SET Vlr_Saldo = @Vlr_TempSaldoAtual
					WHERE Num_NumeroConta = @Num_NumeroConta;

				DECLARE @Dat_DataAtual DATE;
				SET @Dat_DataAtual = GETDATE();

				EXEC [dbo].[InsOperacao] @Dat_DataAtual, 'SAQUE', 'D', @Vlr_ValorSaque, @Num_NumeroConta;
				RETURN 0
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[UpdRealizaTransferencia]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[UpdRealizaTransferencia]
GO

CREATE PROCEDURE [dbo].[UpdRealizaTransferencia]

	@Num_NumeroContaTransferindo	DECIMAL(18,0),
	@Num_NumeroContaRecebendo		DECIMAL(18,0),
	@Vlr_ValorTransferencia			MONEY

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Realiza a transferência do valor especificado para a conta especificada caso possível.
	Autor.............: Alysson Estevam
 	Data..............: 16/01/2020
	Comentários.......: Parâmetro Status :
						0 - Transferência realizada
						1 - Conta transferindo inativa
						2 - Conta recebendo inativa
						3 - Valor de transferência negativo
						4 - Conta que está transferindo não possui o valor no saldo atual
	Ex................: EXEC [dbo].[UpdRealizaTransferencia] '1859', '2050', '1000'
	*/

	BEGIN
		DECLARE @Ind_TempContaAtiva BIT;
		SELECT @Ind_TempContaAtiva = Ind_ContaAtiva 
		FROM [dbo].[Contas] WITH (NOLOCK) 
		WHERE Num_NumeroConta = @Num_NumeroContaTransferindo
		
		IF (@Ind_TempContaAtiva = 0)
			RETURN 1;
		ELSE
			SELECT @Ind_TempContaAtiva = Ind_ContaAtiva 
			FROM [dbo].[Contas] WITH (NOLOCK) 
			WHERE Num_NumeroConta = @Num_NumeroContaRecebendo
			
			IF (@Ind_TempContaAtiva = 0)
				RETURN 2;
			ELSE
				IF (@Vlr_ValorTransferencia <= 0)
					RETURN 3;
				ELSE
					DECLARE @tempSaldoAtualContaTransferindo MONEY;
					SELECT @tempSaldoAtualContaTransferindo = Vlr_Saldo 
					FROM [dbo].[Contas] WITH (NOLOCK) 
					WHERE Num_NumeroConta = @Num_NumeroContaTransferindo
		
					IF (@Vlr_ValorTransferencia > @tempSaldoAtualContaTransferindo)
						RETURN 4;
					ELSE
						DECLARE @tempSaldoAtualContaRecebendo MONEY;
						SELECT @tempSaldoAtualContaRecebendo = Vlr_Saldo 
						FROM [dbo].[Contas] WITH (NOLOCK) 
						WHERE Num_NumeroConta = @Num_NumeroContaRecebendo

						SET @tempSaldoAtualContaTransferindo = @tempSaldoAtualContaTransferindo - @Vlr_ValorTransferencia;
						SET @tempSaldoAtualContaRecebendo = @tempSaldoAtualContaRecebendo + @Vlr_ValorTransferencia;					

						UPDATE [dbo].[Contas] 
							SET Vlr_Saldo = @tempSaldoAtualContaTransferindo 
							WHERE Num_NumeroConta = @Num_NumeroContaTransferindo

						UPDATE [dbo].[Contas] 
							SET Vlr_Saldo = @tempSaldoAtualContaRecebendo 
							WHERE Num_NumeroConta = @Num_NumeroContaRecebendo

						DECLARE @Dat_DataAtual DATE;
						SET @Dat_DataAtual = GETDATE();

						EXEC [dbo].[InsOperacao] @Dat_DataAtual, 'TRANSFERENCIA', 'D', @Vlr_ValorTransferencia, @Num_NumeroContaTransferindo;
						EXEC [dbo].[InsOperacao] @Dat_DataAtual, 'TRANSFERENCIA', 'C', @Vlr_ValorTransferencia, @Num_NumeroContaRecebendo;
						RETURN 0
	END
GO