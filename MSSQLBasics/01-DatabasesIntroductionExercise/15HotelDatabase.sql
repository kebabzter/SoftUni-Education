CREATE DATABASE Hotel

CREATE TABLE Employees
(
  Id BIGINT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(50) NOT NULL, 
  Title NVARCHAR(100) NOT NULL,
  Notes NVARCHAR(MAX)
)



CREATE TABLE Customers
(
  AccountNumber BIGINT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(30) NOT NULL, 
  LastName NVARCHAR(50) NOT NULL, 
  PhoneNumber CHAR(10), 
  EmergencyName NVARCHAR(100), 
  EmergencyNumber CHAR(10), 
  Notes NVARCHAR(MAX)
)



CREATE TABLE RoomStatus
(
  RoomStatus BIT NOT NULL,
  Notes NVARCHAR(MAX)
)



CREATE TABLE RoomTypes
(
  RoomType NVARCHAR(30) NOT NULL,
  Notes NVARCHAR(MAX)
)



CREATE TABLE BedTypes
(
  BedType NVARCHAR(30) NOT NULL,
  Notes NVARCHAR(MAX)
)



CREATE TABLE Rooms
(
  RoomNumber BIGINT PRIMARY KEY, 
  RoomType NVARCHAR(30) NOT NULL, 
  BedType NVARCHAR(30) NOT NULL, 
  Rate INT, 
  RoomStatus BIT NOT NULL, 
  Notes NVARCHAR(MAX)
)



CREATE TABLE Payments
(
   Id BIGINT PRIMARY KEY IDENTITY,
   EmployeeId BIGINT NOT NULL, 
   PaymentDate DATETIME2 NOT NULL, 
   AccountNumber BIGINT NOT NULL, 
   FirstDateOccupied DATETIME2 NOT NULL, 
   LastDateOccupied DATETIME2 NOT NULL, 
   TotalDays INT NOT NULL, 
   AmountCharged DECIMAL (10,2), 
   TaxRate INT, 
   TaxAmount INT, 
   PaymentTotal DECIMAL(10,2), 
   Notes NVARCHAR(MAX)
)



CREATE TABLE Occupancies
(
   Id BIGINT PRIMARY KEY IDENTITY,
   EmployeeId BIGINT NOT NULL, 
   DateOccupied DATETIME2 NOT NULL, 
   AccountNumber BIGINT NOT NULL, 
   RoomNumber BIGINT NOT NULL,
   RateApplied INT, 
   PhoneCharge DECIMAL (10,2), 
   Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Gosho','Goshev','HR','notes'),
('Pesho','Peshev','Support',NULL),
('Mimi','Gosheva','Manager','notes2')


INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('Gosho','Goshev','0878121212','Petar Petrov','0899232323',NULL),
('Pesho','Peshev','0899123654','Ivan Ivanov','0899454545',NULL),
('Mimi','Gosheva','0878878787','Petar Petrov','0877897485','notes')


INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
(0,'notes'),
(1,'notes2'),
(0,NULL)


INSERT INTO RoomTypes (RoomType, Notes) VALUES
('one','notes'),
('second','notes2'),
('apartment', NULL)


INSERT INTO BedTypes (BedType, Notes) VALUES
('one','notes'),
('second','notes2'),
('one', NULL)


INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(120,'one','one',5,0,'notes'),
(220,'second','second',9,1,NULL),
(320,'apartment','one',10,0,'notes2')


INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1,'2020-12-01',2,'2020-12-01','2020-12-03',2,150,10,20,350.25,'notes'),
(2,'2019-12-01',1,'2019-12-01','2020-12-05',4,150,10,NULL,NULL,'notes2'),
(1,'2020-12-02',2,'2020-12-07','2020-12-09',2,250,NULL,NULL,NULL,NULL)


INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1,'2020-12-03',1,120,5,5.42,'notes'),
(3,'2020-12-02',2,120,NULL,10,NULL),
(2,'2020-12-05',3,120,5,NULL,'notes2')

