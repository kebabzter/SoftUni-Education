CREATE DATABASE Movies

CREATE TABLE Directors
(
   Id BIGINT PRIMARY KEY IDENTITY,
   DirectorName NVARCHAR(50) NOT NULL,
   Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
   Id BIGINT PRIMARY KEY IDENTITY,
   GenreName NVARCHAR(50) NOT NULL,
   Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
   Id BIGINT PRIMARY KEY IDENTITY,
   CategoryName NVARCHAR(50) NOT NULL,
   Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
   Id BIGINT PRIMARY KEY IDENTITY,
   Title NVARCHAR(50) NOT NULL,
   DirectorId BIGINT NOT NULL,
   CopyrightYear INT NOT NULL,
   [Length] BIGINT NOT NULL,
   GenreId BIGINT NOT NULL, 
   CategoryId BIGINT NOT NULL, 
   Rating BIGINT,
   Notes NVARCHAR(MAX)
)

INSERT INTO Directors VALUES
('Ime1', 'notes'),
('Ime2', NULL),
('Ime3', 'notes'),
('Ime4', NULL),
('Ime5', 'бележки')

INSERT INTO Genres VALUES
('Comedy', 'notes'),
('Crime', NULL),
('Action', 'notes'),
('Horror', NULL),
('Romance', 'notes')

INSERT INTO Categories VALUES
('for Kids', 'notes'),
('not 12', NULL),
('not 16', 'notes'),
('not 18', NULL),
('free', 'notes')

INSERT INTO Movies VALUES
('Title1',1, 2018,121, 1,5,12,NULL),
('Title2',5, 2018,125, 2,1,12,'notes'),
('Title3',2, 2018,118, 5,3,12,NULL),
('Title4',3, 2018,132, 3,2,12,'notes'),
('Title5',4, 2018,104, 4,4,12,'notes')
