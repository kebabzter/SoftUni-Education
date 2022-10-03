CREATE PROCEDURE usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @SenderId, @Amount
EXEC usp_DepositMoney @ReceiverId, @Amount
COMMIT


EXEC usp_TransferMoney 2,1,100
SELECT * FROM Accounts

