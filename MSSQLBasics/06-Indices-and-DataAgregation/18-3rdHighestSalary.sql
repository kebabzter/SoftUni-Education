WITH RankSalary (Department, Salary, Ranked) AS
(
SELECT DepartmentID, Salary,
           DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Ranked
    FROM Employees
)

SELECT DISTINCT Department, Salary AS ThirdHighestSalary
FROM RankSalary
WHERE Ranked=3