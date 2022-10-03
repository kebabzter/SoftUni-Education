CREATE TABLE People
(
  ID BIGINT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(200) NOT NULL,
  Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) <= 2048 * 1024),
  Height DECIMAL(5,2),
  [Weight] DECIMAL(5,2),
  Gender Char(1) NOT NULL CHECK(Gender = 'm' OR Gender = 'f'),
  Birthdate DATETIME2 NOT NULL,
  Biography NVARCHAR(MAX)
)


INSERT INTO People ([Name],Picture,Height,[Weight],Gender,Birthdate,Biography) VALUES
('Gosho','3',1.12,32.20,'m','1/5/2020','neshto'),
('Pesho',4,1.22,30.20,'m','8/5/2019',NULL),
('Maria',5,1.02,20.20,'f','1/7/2021','abv'),
('Ivan',6,1.12,30.20,'m','2/9/2018',NULL),
('Petar',7,1.42,37.20,'m','9/4/2017','bio')