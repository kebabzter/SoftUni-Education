SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS [DeptName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
WHERE YEAR(e.HireDate)>=1999 AND (d.[Name] IN ('Sales','Finance'))
ORDER BY e.HireDate
