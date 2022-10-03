SELECT CONCAT(FirstName,' ', MiddleName,' ', LastName) AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

/*
Ако искаме да няма 2 интервала когато второто име е NULL
SELECT CONCAT(FirstName,' ', MiddleName + ' ', LastName) AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
*/
