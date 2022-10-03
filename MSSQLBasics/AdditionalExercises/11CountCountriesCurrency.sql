SELECT c.CurrencyCode, c.[Description] AS Currency, COUNT(co.CountryCode) AS NumberOfCountries
FROM Currencies AS c
LEFT JOIN Countries AS co ON c.CurrencyCode=co.CurrencyCode
GROUP BY c.CurrencyCode, c.[Description]
ORDER BY COUNT(co.CountryCode) DESC, c.[Description]