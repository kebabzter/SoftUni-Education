CREATE PROCEDURE usp_CalculateFutureValueForAccount @accountID INT, @interestRate FLOAT 
AS
BEGIN
SELECT a.Id, ah.FirstName,ah.LastName, a.Balance AS [Current Balance],dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
FROM AccountHolders AS ah
JOIN Accounts AS a ON ah.Id=a.AccountHolderId
WHERE a.Id=@accountID
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1