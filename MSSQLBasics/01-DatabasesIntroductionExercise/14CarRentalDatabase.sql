CREATE DATABASE CarRental 


CREATE TABLE Categories
(
  Id BIGINT PRIMARY KEY IDENTITY,
  CategoryName NVARCHAR(50) NOT NULL,
  DailyRate BIGINT NOT NULL,
  WeeklyRate BIGINT NOT NULL,
  MonthlyRate BIGINT NOT NULL,
  WeekendRate BIGINT NOT NULL
)


CREATE TABLE Cars
(
  Id BIGINT PRIMARY KEY IDENTITY,
  PlateNumber VARCHAR(20) NOT NULL,
  Manufacturer VARCHAR(30) NOT NULL,
  Model VARCHAR(30) NOT NULL,
  CarYear BIGINT NOT NULL,
  CategoryId BIGINT NOT NULL,
  Doors BIGINT,
  Picture VARBINARY(MAX),
  Condition VARCHAR(50),
  Available BIT NOT NULL
)


CREATE TABLE Employees
(
  Id BIGINT PRIMARY KEY IDENTITY,
  FirstName VARCHAR(30) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Title VARCHAR(200),
  Notes VARCHAR(MAX)
)


CREATE TABLE Customers
(
  Id BIGINT PRIMARY KEY IDENTITY,
  DriverLicenceNumber VARCHAR(50) NOT NULL,
  FullName VARCHAR(250) NOT NULL,
  [Address] VARCHAR(200),
  City VARCHAR(30), 
  ZIPCode VARCHAR(10),
  Notes VARCHAR(MAX)
)


CREATE TABLE RentalOrders
(
  Id BIGINT PRIMARY KEY IDENTITY,
  EmployeeId BIGINT NOT NULL,
  CustomerId BIGINT NOT NULL,
  CarId BIGINT NOT NULL,
  TankLevel VARCHAR(250),
  KilometrageStart BIGINT NOT NULL,
  KilometrageEnd BIGINT NOT NULL,
  TotalKilometrage BIGINT,
  StartDate DATETIME2 NOT NULL,
  EndDate DATETIME2 NOT NULL,
  TotalDays BIGINT,
  RateApplied VARCHAR(250),
  TaxRate VARCHAR(250),
  OrderStatus VARCHAR(250),
  Notes VARCHAR(MAX)
)


INSERT INTO Categories VALUES
('Category Name1',10,20,30,50),
('Category Name2',5,30,50,80),
('Category Name3',100,120,130,150)


INSERT INTO Cars VALUES
('PB1234AT','VW','Passat',2000,1,5,2,'cond1',0),
('PB4312TA','Opel','Corsa',2005,2,4,2,'cond2',1),
('PB4758TA','Nisan','Qashqai',2010,3,3,2,'cond3',0)


INSERT INTO Employees VALUES
('Pesho','Peshev','Title1','notes'),
('Gosho','Goshev',NULL,NULL),
('Mimi','Moneva','Title2',NULL)


INSERT INTO Customers VALUES
('Licence1','FullName1','Adress','Sofia','1000','notes'),
('Licence2','FullName2','Adress2','Plovdiv','4000',NULL),
('Licence3','FullName3',NULL,NULL,NULL,'notes2')


INSERT INTO RentalOrders VALUES
(1,1,1,'full',1000,2000,1000,'1/1/2020','1/2/2020',1,'rate applied','tax rate','order status','notes'),
(2,3,1,'full',2000,2000,0,'1/1/2020','1/3/2020',2,'rate applied2',NULL,'order status2','notes2'),
(3,2,1,'full',1500,2000,500,'1/1/2020','1/4/2020',3,NULL,'tax rate','order status3',NULL)
