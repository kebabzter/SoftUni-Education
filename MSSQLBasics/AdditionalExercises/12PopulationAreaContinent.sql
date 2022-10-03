SELECT c.ContinentName, SUM(co.AreaInSqKm) AS CountriesArea, SUM(CAST(co.[Population] AS FLOAT)) AS CountriesPopulation 
FROM Continents AS c
JOIN Countries AS co ON c.ContinentCode=co.ContinentCode
GROUP BY c.ContinentName
ORDER BY SUM(CAST(co.[Population] AS FLOAT)) DESC