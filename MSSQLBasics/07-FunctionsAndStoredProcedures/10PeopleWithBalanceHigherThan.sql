CREATE   PROCEDURE usp_GetHoldersWithBalanceHigherThan @Number DECIMAL(18,2)
AS
BEGIN
SELECT FirstName, LastName
FROM AccountHolders AS ah
JOIN Accounts AS a ON ah.Id=a.AccountHolderId
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance)>@Number
ORDER BY FirstName, LastName
END