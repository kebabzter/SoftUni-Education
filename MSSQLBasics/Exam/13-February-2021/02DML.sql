-- Insert
INSERT INTO Files([Name], Size,	ParentId, CommitId)
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json',	14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus,	RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1,	4),
('Typo fix in Judge.html', 'open',	4, 3),
('Implement documentation for UsersService.cs',	'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

-- Update
UPDATE Issues
SET IssueStatus='closed'
WHERE AssigneeId=6

-- Delete
DELETE Files
WHERE ParentId=(SELECT Id FROM Files WHERE Id=(SELECT Id FROM Commits WHERE Id=(SELECT Id
                                           FROM Repositories
                                           WHERE [Name]='Softuni-Teamwork')))

DELETE Files
WHERE CommitId=(SELECT Id FROM Commits WHERE RepositoryId=(SELECT Id
                                           FROM Repositories
                                           WHERE [Name]='Softuni-Teamwork'))

DELETE Commits
WHERE RepositoryId=(SELECT Id
FROM Repositories
WHERE [Name]='Softuni-Teamwork')

DELETE Issues
WHERE RepositoryId=(SELECT Id
FROM Repositories
WHERE [Name]='Softuni-Teamwork')

DELETE RepositoriesContributors
WHERE RepositoryId=(SELECT Id
FROM Repositories
WHERE [Name]='Softuni-Teamwork')

DELETE Repositories
WHERE [Name]='Softuni-Teamwork'