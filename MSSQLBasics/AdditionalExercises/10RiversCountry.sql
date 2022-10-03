SELECT c.CountryName, co.ContinentName, COUNT(r.Id) AS RiversCount, ISNULL(SUM(r.[Length]),0) AS TotalLength
FROM Countries AS c
LEFT JOIN Continents AS co ON c.ContinentCode=co.ContinentCode
LEFT JOIN CountriesRivers AS cr ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId=r.Id
GROUP BY c.CountryName, co.ContinentName
ORDER BY COUNT(r.Id) DESC, SUM(r.[Length]) DESC, c.CountryName