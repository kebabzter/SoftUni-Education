WITH CountryPeakMountain (CountryName, [Highest Peak Name], HighestPeakElevation, Mountain, Ranked) AS
(SELECT c.CountryName, 
       ISNULL(p.PeakName,'(no highest peak)') AS [Highest Peak Name],
	   ISNULL(MAX(p.Elevation),0) AS HighestPeakElevation,
	   ISNULL(m.MountainRange,'(no mountain)') AS Mountain,
       DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
   FROM Countries AS c
   LEFT JOIN MountainsCountries AS mc ON c.CountryCode=mc.CountryCode
   LEFT JOIN Mountains AS m ON mc.MountainId=m.Id
   LEFT JOIN Peaks AS p ON m.Id=p.MountainId
   GROUP BY c.CountryName, p.PeakName, m.MountainRange)

SELECT TOP(5) CountryName, [Highest Peak Name], HighestPeakElevation, Mountain
FROM CountryPeakMountain
WHERE Ranked=1
ORDER BY CountryName,[Highest Peak Name]