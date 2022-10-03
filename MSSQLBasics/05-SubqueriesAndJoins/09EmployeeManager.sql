SELECT e.EmployeeID, e.FirstName, m.EmployeeID AS ManagerID,m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID=m.EmployeeID
WHERE m.EmployeeID IN (3,7)
ORDER BY e.EmployeeID