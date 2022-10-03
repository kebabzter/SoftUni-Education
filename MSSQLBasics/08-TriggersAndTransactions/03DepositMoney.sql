CREATE PROCEDURE usp_DepositMoney @AccountId INT, @MoneyAmount DECIMAL(18,4)
AS
BEGIN TRANSACTION

DECLARE @account INT=(SELECT Id FROM Accounts WHERE Id=@AccountId)

IF (@account IS NULL)
BEGIN
   ROLLBACK
   RAISERROR('Invalid account!',16,1)
   RETURN
END

IF (@MoneyAmount<0)
BEGIN
   ROLLBACK
   RAISERROR('Amount not be negative!',16,1)
   RETURN
END

UPDATE Accounts
SET Balance+=@MoneyAmount
WHERE Id=@AccountId
COMMIT

EXEC usp_DepositMoney 1,200
SELECT* FROM Accounts WHERE Id=1