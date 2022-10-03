SELECT u.Username,g.[Name] AS Game,COUNT(i.ItemTypeId),SUM(i.Price)
FROM Users AS u
JOIN UsersGames AS ug ON u.Id=ug.UserId
JOIN Games AS g ON g.Id=ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId=ug.Id
JOIN Items AS i ON ugi.ItemId=i.Id
GROUP BY u.Username,g.[Name]
HAVING COUNT(i.ItemTypeId)>=10
ORDER BY COUNT(i.ItemTypeId) DESC, SUM(i.Price) DESC, u.Username
