UPDATE Countries
SET CountryName='Burma'
WHERE CountryName='Myanmar'

INSERT INTO Monasteries ([Name], CountryCode)
SELECT 'Hanga Abbey', CountryCode FROM Countries WHERE CountryName='Tanzania'


INSERT INTO Monasteries ([Name], CountryCode)
SELECT 'Myin-Tin-Daik', CountryCode FROM Countries WHERE CountryName='Myanmar'


SELECT con.ContinentName AS ContinentName,
       cou.CountryName AS CountryName,
	   COUNT (m.Id) AS MonasteriesCount
FROM Continents AS con
JOIN Countries AS cou ON cou.ContinentCode = con.ContinentCode
LEFT JOIN Monasteries AS m ON m.CountryCode = cou.CountryCode
WHERE cou.IsDeleted = 0
GROUP BY con.ContinentName, cou.CountryName
ORDER BY MonasteriesCount DESC, CountryName
