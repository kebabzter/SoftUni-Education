SELECT i.[Name] AS [Item], i.Price, i.MinLevel, gt.[Name] AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS f ON i.id=f.ItemId
LEFT JOIN GameTypes AS gt ON gt.Id=f.GameTypeId
ORDER BY gt.[Name] DESC, i.[Name]