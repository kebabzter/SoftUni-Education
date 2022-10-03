SELECT TOP(5) c.CountryName, r.RiverName
FROM Continents AS co
LEFT JOIN Countries AS c ON co.ContinentCode=c.ContinentCode
LEFT JOIN CountriesRivers AS cr ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId=r.Id
WHERE co.ContinentCode='AF'
ORDER BY c.CountryName
