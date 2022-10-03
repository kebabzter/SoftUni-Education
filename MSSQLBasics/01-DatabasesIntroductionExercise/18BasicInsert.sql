INSERT INTO Towns ([Name]) VALUES
('Sofia'), 
('Plovdiv'), 
('Varna'), 
('Burgas')


INSERT INTO Departments ([Name]) VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'),
('Quality Assurance')


INSERT INTO Addresses (AddressText,TownId) VALUES
('Plovdiv',2)



INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4,'2013-2-1', 3500.00,1),
('Petar', 'Petrov', 'Petrov','Senior Engineer', 1,'2004-3-2', 4000.00,1),
('Maria', 'Petrova', 'Ivanova','Intern',5,'2016-8-28',	525.25,1),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2,'2007-12-9', 3000.00,1),
('Peter', 'Pan', 'Pan',	'Intern', 3, '2016-8-28', 599.88,1)


