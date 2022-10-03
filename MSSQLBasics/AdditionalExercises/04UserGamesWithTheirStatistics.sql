SELECT u.Username,g.[Name] AS Game, MAX(ch.[Name]) AS [Character],
       SUM(stat.Strength) + MAX(s.Strength) + MAX(st.Strength) as Strength,
	   SUM(stat.Defence) + MAX(s.Defence) + MAX(st.Defence) as Defence,
	   SUM(stat.Speed) + MAX(s.Speed) + MAX(st.Speed) as Speed,
	   SUM(stat.Mind) + MAX(s.Mind) + MAX(st.Mind) as Mind,
	   SUM(stat.Luck) + MAX(s.Luck) + MAX(st.Luck) as Luck
FROM Users AS u
JOIN UsersGames AS ug ON u.Id=ug.UserId
JOIN Games AS g ON g.Id=ug.GameId
JOIN GameTypes AS gt ON gt.Id=g.GameTypeId
JOIN [Statistics] AS s ON s.Id=gt.BonusStatsId
JOIN Characters AS ch ON ch.Id=ug.CharacterId
JOIN [Statistics] AS st ON st.Id=ch.StatisticId
JOIN UserGameItems AS ugi ON ugi.UserGameId=ug.Id
JOIN Items AS i ON i.id=ugi.ItemId
JOIN [Statistics] AS stat ON stat.Id=i.StatisticId
GROUP BY u.Username,g.[Name]
order by Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC