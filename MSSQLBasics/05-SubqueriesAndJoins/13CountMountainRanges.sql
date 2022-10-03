SELECT c.CountryCode, COUNT(c.CountryCode) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode=mc.CountryCode
JOIN Mountains AS m ON mc.MountainId=m.Id
WHERE c.CountryCode IN ('BG','RU','US')
GROUP BY c.CountryCode
