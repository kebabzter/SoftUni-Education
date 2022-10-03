WITH AvgSalaryDep (Department, AvgS) AS
(
SELECT DepartmentID, AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY DepartmentID
)

SELECT TOP (10) e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e, AvgSalaryDep AS avgSD
WHERE e.DepartmentID=avgSD.Department AND e.Salary>avgSD.AvgS
ORDER BY e.DepartmentID

--OR

SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
JOIN (SELECT DepartmentID, AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY DepartmentID) AS avgSalaryT ON e.DepartmentID=avgSalaryT.DepartmentID
WHERE e.Salary>avgSalaryT.AvgSalary
ORDER BY e.DepartmentID

--OR

SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
WHERE e.Salary>(SELECT AVG(Salary) AS AvgSalary
                  FROM Employees
				  WHERE DepartmentID=e.DepartmentID
                  GROUP BY DepartmentID)
ORDER BY e.DepartmentID