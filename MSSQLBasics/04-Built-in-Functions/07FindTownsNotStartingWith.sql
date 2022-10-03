SELECT *
FROM Towns
WHERE [Name] NOT LIKE '[r,b,d]%'
ORDER BY [Name]