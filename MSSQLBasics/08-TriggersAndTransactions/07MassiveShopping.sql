DECLARE @userGameID INT=(SELECT Id FROM UsersGames WHERE UserId=9 AND GameId=87)
DECLARE @stamatCash DECIMAL(18,2)=(SELECT Cash FROM UsersGames WHERE Id=@userGameID)
DECLARE @itemsPrice DECIMAL(18,2)=(SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF(@stamatCash>=@itemsPrice)
BEGIN
   BEGIN TRANSACTION
   UPDATE UsersGames
   SET Cash-=@itemsPrice
   WHERE Id=@userGameID

   INSERT INTO UserGameItems (ItemId, UserGameId)
   SELECT Id, @userGameID FROM Items WHERE MinLevel BETWEEN 11 AND 12

   COMMIT
END

SET @stamatCash =(SELECT Cash FROM UsersGames WHERE Id=@userGameID)
SET @itemsPrice =(SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF(@stamatCash>=@itemsPrice)
BEGIN
   BEGIN TRANSACTION
   UPDATE UsersGames
   SET Cash-=@itemsPrice
   WHERE Id=@userGameID

   INSERT INTO UserGameItems (ItemId, UserGameId)
   SELECT Id, @userGameID FROM Items WHERE MinLevel BETWEEN 19 AND 21

   COMMIT
END

SELECT i.[Name]
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId=u.Id
JOIN Games AS g ON g.Id=ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId=ug.Id
JOIN Items AS i ON i.Id=ugi.ItemId
WHERE u.Username='Stamat' AND g.[Name]='Safflower'
ORDER BY i.[Name]