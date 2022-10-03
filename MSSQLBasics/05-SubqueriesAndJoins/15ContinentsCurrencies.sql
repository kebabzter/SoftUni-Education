WITH ContinentCurrencyUsage (ContinentCode, CurrencyCode, CurrencyUsage, Ranked) AS
(
SELECT ContinentCode,CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage, 
       DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
FROM Countries
GROUP BY ContinentCode, CurrencyCode
)

SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM ContinentCurrencyUsage
WHERE Ranked=1 AND CurrencyUsage>1
ORDER BY ContinentCode