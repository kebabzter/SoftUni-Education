CREATE DATABASE University

CREATE TABLE Majors
(
  MajorID INT PRIMARY KEY,
  [Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Students
(
  StudentID INT PRIMARY KEY,
  StudentNumber VARCHAR(10) NOT NULL,
  StudentName VARCHAR(100) NOT NULL,
  MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
  PaymentID INT PRIMARY KEY,
  PaymentDate DATETIME2,
  PaymentAmount DECIMAL(15,2),
  StudentID INT REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Subjects
(
  SubjectID INT PRIMARY KEY,
  SubjectName VARCHAR(MAX) NOT NULL
)


CREATE TABLE Agenda
(
  StudentID INT REFERENCES Students(StudentID) NOT NULL,
  SubjectID INT REFERENCES Subjects(SubjectID) NOT NULL,
  PRIMARY KEY (StudentID,SubjectID)
)


	
