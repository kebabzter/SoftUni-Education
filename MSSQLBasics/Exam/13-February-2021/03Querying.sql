-- 5. Commits
SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

-- 6. Front-end
SELECT Id, [Name], Size
FROM Files
WHERE Size>1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

-- 7. Issue Assignment
SELECT i.Id, CONCAT(u.Username,' : ',i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId=u.Id
ORDER BY i.Id DESC, i.AssigneeId

-- 8. Single Files
SELECT f.Id, f.[Name], CONCAT(f.Size,'KB') AS Size
FROM Files AS f
LEFT JOIN Files AS ff ON f.Id=ff.ParentId
WHERE ff.Id IS NULL
ORDER BY f.Id, f.[Name], f.Size DESC

-- 9. Commits in Repositories
SELECT TOP(5) r.Id, r.[Name], COUNT(c.Id) AS [Commits]
FROM RepositoriesContributors AS rc
JOIN Repositories AS r  ON r.Id = rc.RepositoryId
JOIN Commits AS c ON r.Id=c.RepositoryId
GROUP BY r.Id,  r.[Name]
ORDER BY [Commits] DESC, r.Id, r.[Name]

-- 10. Average Size
SELECT u.Username,AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON u.Id=c.ContributorId
JOIN Files AS f ON c.Id=f.CommitId
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC, u.Username

-- 11. All User Commits
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
RETURN (SELECT COUNT(u.Id)
       FROM Users AS u
       JOIN Commits AS c ON u.Id=c.ContributorId
       WHERE u.Username=@username)
END

-- 12.	Search for Files
CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(100))
AS
BEGIN
   SELECT Id, [Name], CONCAT(Size, 'KB') AS [Size]
   FROM Files
   WHERE CHARINDEX(@fileExtension, [Name]) > 0
   ORDER BY Id, [Name], Size DESC
END

EXEC usp_SearchForFiles 'txt'