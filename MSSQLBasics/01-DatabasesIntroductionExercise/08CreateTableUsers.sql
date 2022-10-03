CREATE TABLE Users
(
  ID BIGINT PRIMARY KEY IDENTITY,
  [Username] VARCHAR(30) UNIQUE NOT NULL,
  [Password] VARCHAR(26) NOT NULL,  
  ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024),
  LastLoginTime DATETIME2,
  IsDeleted BIT NOT NULL
)

INSERT INTO Users([Username],[Password],ProfilePicture,LastLoginTime,IsDeleted) VALUES
('Gosho','goshi123',3,'1/5/2020',0),
('Pesho','peshi321',4,'2/5/2019',0),
('Maria','mimi147',5,'3/15/2021',0),
('Ivan','vani258',6,'4/7/2020',0),
('Petar','pepi369',7,'5/9/2019',0)

