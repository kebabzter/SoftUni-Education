-- 5. Products by Price
SELECT [Name],Price, [Description]
FROM Products
ORDER BY Price DESC, [Name]

-- 6. Negative Feedback
SELECT f.ProductId, f.Rate,	f.[Description], f.CustomerId, c.Age, c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId=c.Id
WHERE f.Rate<5.0
ORDER BY f.ProductId DESC, f.Rate

-- 7. Customers without Feedback
SELECT CONCAT(c.FirstName,' ',c.LastName) AS CustomerName, c.PhoneNumber, c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id=f.CustomerId
WHERE f.Id IS NULL
ORDER BY c.Id

-- 8. Customers by Criteria
SELECT FirstName, Age, PhoneNumber
FROM Customers
WHERE Age>=21 AND FirstName LIKE '%an%' OR PhoneNumber LIKE '%38' AND CountryId<>(SELECT Id FROM Countries WHERE [Name]='Greece')
ORDER BY FirstName, Age DESC

-- 9. Middle Range Distributors
SELECT d.[Name] AS DistributorName,i.[Name] AS IngredientName,p.[Name] AS ProductName, AVG(f.Rate) AS AverageRate
FROM Distributors AS d
JOIN Ingredients AS i ON d.Id=i.DistributorId
JOIN ProductsIngredients AS pin ON i.Id=pin.IngredientId
JOIN Products AS p ON pin.ProductId=p.Id
JOIN Feedbacks AS f ON p.Id=f.ProductId
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY DistributorName, IngredientName, ProductName

-- 10. Country Representative
WITH countryDistrib (CountryName,DistributorName,IngredientsByDistributor, Ranked)
AS
(
SELECT c.Name AS CountryName,
           d.Name AS DisributorName,
           COUNT(i.DistributorId) AS IngredientsByDistributor,
           DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.DistributorId) DESC) AS Rank
FROM Countries AS c
         LEFT JOIN Distributors AS d ON d.CountryId = c.Id
         LEFT JOIN Ingredients AS i ON i.DistributorId = d.Id
GROUP BY c.[Name], d.[Name]
)

SELECT CountryName, DistributorName
FROM countryDistrib
WHERE ranked = 1
ORDER BY CountryName,
         DistributorName

-- 11. Customers with Countries
CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, c.Age, c.Gender, co.[Name]AS CountryName
FROM Customers AS c
JOIN Countries AS co ON c.CountryId=co.Id;

SELECT TOP(5) *
FROM v_UserWithCountries
 ORDER BY Age

 -- 12.	Delete Products
CREATE TRIGGER tr_DeleteProduct ON products
INSTEAD OF DELETE
AS
     BEGIN
         DECLARE @productId INT=(SELECT Id FROM deleted);
	    -- Delete Feedbacks
         DELETE FROM Feedbacks
         WHERE ProductId = @productId;
	    -- Delete ProductIngredient relations
         DELETE FROM ProductsIngredients
         WHERE ProductId = @productId;
	    -- Delete Product
         DELETE FROM Products
         WHERE Id = @productId;
     END;

	 DELETE FROM Products WHERE Id = 7
