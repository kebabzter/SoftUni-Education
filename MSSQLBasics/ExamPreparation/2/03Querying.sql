-- 5. Teen Students

SELECT FirstName, LastName, Age
FROM Students
WHERE Age>=12
ORDER By FirstName, LastName

-- 6. Students Teachers

SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON s.Id=st.StudentId
GROUP BY s.FirstName, s.LastName


-- 7. Students to Go

 SELECT CONCAT(s.FirstName,' ',LastName) AS [Full Name]
FROM Students As s
LEFT JOIN StudentsExams AS se ON s.Id=se.StudentId
WHERE se.ExamId IS NULL
ORDER BY [Full Name]


-- 8. Top Students
SELECT TOP(10) s.FirstName AS [First Name],s.LastName AS [Last Name], FORMAT(AVG(se.Grade),'N2') AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON s.Id=se.StudentId
GROUP BY s.FirstName,s.LastName
ORDER BY Grade DESC, FirstName, LastName

-- 9. Not So In The Studying
SELECT CONCAT(s.FirstName,' ', s.MiddleName + ' ', s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id=ss.StudentId
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]


-- 10. Average Grade per Subject
SELECT s.[Name], AVG(ss.Grade) AS AverageGrade
FROM Subjects AS s
JOIN StudentsSubjects AS ss ON s.Id=ss.SubjectId
GROUP BY s.[Name], s.Id
ORDER BY s.Id

-- 11. Exam Grades
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
   IF (NOT EXISTS (SELECT 1 FROM StudentsExams WHERE StudentId=@studentId))
      RETURN 'The student with provided id does not exist in the school!'
   IF (@grade>6.00)
      RETURN 'Grade cannot be above 6.00!'
    DECLARE @count INT=(SELECT COUNT(*) FROM StudentsExams WHERE StudentId=@studentId AND Grade BETWEEN @grade AND @grade+0.5)
	DECLARE @studentName NVARCHAR(30)=(SELECT FirstName FROM Students WHERE Id=@studentId)
	RETURN CONCAT('You have to update ',@count,' grades for the student ',@studentName)
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

-- 12. Exclude from school
CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
 IF (NOT EXISTS (SELECT 1 FROM StudentsExams WHERE StudentId=@studentId))
      THROW 51010, 'This school has no student with the provided id!', 1

  DELETE FROM StudentsExams
  WHERE StudentId = @StudentId

  DELETE FROM StudentsSubjects
  WHERE StudentId = @StudentId

  DELETE FROM StudentsTeachers
  WHERE StudentId = @StudentId

  DELETE FROM Students
  WHERE Id = @StudentId
END

