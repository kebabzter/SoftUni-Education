WITH AverageSalaryDepartment (avgsalaryd) AS 
(
SELECT AVG(e.Salary)
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID=d.DepartmentID 
GROUP BY e.DepartmentID
)

SELECT MIN(avgsalaryd) AS MinAverageSalary
FROM AverageSalaryDepartment