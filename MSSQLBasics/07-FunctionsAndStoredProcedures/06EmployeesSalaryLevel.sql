CREATE PROCEDURE usp_EmployeesBySalaryLevel @levelSalary VARCHAR(10)
AS
BEGIN
   SELECT FirstName AS [First Name], LastName AS [Last Name]
   FROM Employees
   WHERE dbo.ufn_GetSalaryLevel(Salary)=@levelSalary
END

EXEC usp_EmployeesBySalaryLevel 'High'