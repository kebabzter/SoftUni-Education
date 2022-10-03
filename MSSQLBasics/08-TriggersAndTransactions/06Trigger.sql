--1
CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @itemId INT=(SELECT ItemId FROM inserted)
DECLARE @userGameId INT=(SELECT UserGameId FROM inserted)
DECLARE @itemLevel INT=(SELECT MinLevel FROM Items WHERE id=@itemId)
DECLARE @userGameLevel INT=(SELECT [Level] FROM UsersGames WHERE id=@userGameId)

if(@userGameLevel>=@itemLevel)
BEGIN
   INSERT INTO UserGameItems (ItemId,UserGameId) VALUES
   (@itemId,@userGameId)
END

--2
SELECT*
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId=u.Id
JOIN Games AS g ON g.Id=ug.GameId
WHERE g.[Name]='Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

UPDATE UsersGames
SET Cash+=50000
WHERE GameId=(SELECT Id FROM Games WHERE [Name]='Bali') AND
      UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))

--3
CREATE PROCEDURE usp_BuyItem @userId3 INT, @itemId3 INT, @gameId INT
AS
BEGIN TRANSACTION
DECLARE @user INT =(SELECT Id FROM Users WHERE Id=@userId3)
DECLARE @item INT =(SELECT Id FROM Items WHERE Id=@itemId3)

IF(@user IS NULL OR @item IS NULL)
BEGIN
ROLLBACK
RAISERROR('Invalid user or item id!',16,1)
RETURN
END

DECLARE @userCash DECIMAL(18,2)=(SELECT Cash FROM UsersGames WHERE UserId=@userId3 AND GameId=@gameId)
DECLARE @itemPrice DECIMAL(18,2)=(SELECT Price FROM Items WHERE Id=@itemId3)

IF(@userCash-@itemPrice<0)
BEGIN
ROLLBACK
RAISERROR('Insufficient funds!',16,2)
RETURN
END

UPDATE UsersGames
SET Cash-=@itemPrice
WHERE UserId=@userId3 AND GameId=@gameId

DECLARE @userGameId INT=(SELECT Id FROM UsersGames WHERE UserId=@userId3 AND GameId=@gameId)
INSERT INTO UserGameItems(ItemId, UserGameId) VALUES (@itemId3, @userGameId)
COMMIT

DECLARE @counter INT=251
WHILE(@counter<=299)
BEGIN
EXEC usp_BuyItem 22,@counter, 212
EXEC usp_BuyItem 37,@counter, 212
EXEC usp_BuyItem 52,@counter, 212
EXEC usp_BuyItem 61,@counter, 212
SET @counter+=1
END

DECLARE @counter2 INT=501
WHILE(@counter2<=539)
BEGIN
EXEC usp_BuyItem 22,@counter2, 212
EXEC usp_BuyItem 37,@counter2, 212
EXEC usp_BuyItem 52,@counter2, 212
EXEC usp_BuyItem 61,@counter2, 212
SET @counter2+=1
END

--4
SELECT u.Username, g.[Name], ug.Cash, i.[Name]
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId=u.Id
JOIN Games AS g ON g.Id=ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId=ug.Id
JOIN Items AS i ON i.Id=ugi.ItemId
WHERE g.[Name]='Bali'
ORDER BY u.Username, i.[Name]