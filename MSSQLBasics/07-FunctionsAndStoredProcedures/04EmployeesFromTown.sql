CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
BEGIN
   SELECT FirstName AS [First Name], LastName AS [Last Name]
   FROM Employees AS e
   JOIN Addresses AS a ON e.AddressID=a.AddressID
   JOIN Towns AS t ON a.TownID=t.TownID
   WHERE t.[Name]=@townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'