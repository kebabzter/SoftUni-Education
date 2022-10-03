-- 5. Unassigned Reports
SELECT r.[Description], FORMAT(r.OpenDate,'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId=e.Id
WHERE e.Id IS NULL
ORDER BY r.OpenDate, r.[Description]

--- вариант 2
 SELECT r.[Description], FORMAT(r.OpenDate, 'dd-MM-yyyy') AS [OpenDate]
 FROM Reports AS r
 WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate, r.[Description]


-- 6. Reports & Categories
SELECT r.[Description], c.[Name] AS [CategoryName]
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY r.[Description], c.[Name]

-- 7. Most Reported Category
SELECT TOP(5) c.[Name] AS [CategoryName], COUNT(r.Id) AS [ReportsNumber]
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY COUNT(r.Id) DESC, c.[Name]

-- 8. Birthday Report
SELECT u.Username, c.[Name] AS [CategoryName]
FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)
      AND DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, r.OpenDate)
ORDER BY u.Username, c.[Name]

-- 9. Users per Employee 
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [FullName],
       COUNT(u.Id) AS [UsersCount]
FROM Reports AS r
FULL JOIN Employees AS e ON e.Id = r.EmployeeId
FULL JOIN Users AS u ON u.Id = r.UserId
WHERE e.FirstName IS NOT NULL
GROUP BY e.FirstName, e.LastName
ORDER BY [UsersCount] DESC,[FullName]

-- 10. Full Info
SELECT IIF(e.FirstName IS NULL OR e.FirstName = '', 'None', CONCAT(e.FirstName, ' ', e.LastName)) AS [Employee],
       ISNULL(d.[Name], 'None') AS [Department],
	   c.[Name] AS [Category],
	   r.[Description],
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
	   s.[Label] AS [Status],
	   u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
LEFT JOIN Categories AS c ON c.Id = r.CategoryId
LEFT JOIN [Status] AS s ON s.Id = r.StatusId
LEFT JOIN Users AS u ON u.Id = r.UserId
 ORDER BY e.FirstName DESC, e.LastName DESC, d.[Name], c.[Name], r.[Description], r.OpenDate, s.[Label], u.[Name]

 -- 11.	Hours to Complete
 CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
 RETURNS INT
 AS
 BEGIN
 IF (@StartDate IS NULL) OR (@EndDate IS NULL)
		RETURN 0
 RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
 END

 SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports


-- 12. Assign Employee
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
DECLARE @empDepartmentId INT = (SELECT e.DepartmentId
					            FROM Employees AS e
					            WHERE e.Id = @EmployeeId)

DECLARE @categDepartmentId INT = (SELECT c.DepartmentId
					              FROM Reports AS r
					              JOIN Categories AS c ON c.Id = r.CategoryId
					              WHERE r.Id = @reportId)

IF (@empDepartmentId <> @categDepartmentId)
BEGIN
	RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
	RETURN
END

UPDATE Reports
SET EmployeeId = @employeeId
WHERE Id = @reportId
END

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2