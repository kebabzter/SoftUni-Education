CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @parameter DECIMAL(18,4)
AS
BEGIN
   SELECT FirstName, LastName
   FROM Employees
   WHERE Salary>=@parameter
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100