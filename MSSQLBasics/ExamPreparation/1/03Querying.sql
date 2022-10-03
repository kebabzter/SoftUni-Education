-- 5. The "Tr" Planes

SELECT *
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

-- 6. Flight Profits

SELECT FlightId, SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC, FlightId


-- 7. Passenger Trips

SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name], f.Origin, f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id=t.PassengerId
JOIN Flights AS f ON t.FlightId=f.Id
ORDER BY [Full Name], f.Origin, f.Destination

-- 8. Non Adventures People
SELECT p.FirstName AS [First Name], p.LastName AS [Last Name], p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id=t.PassengerId
WHERE t.Id IS NULL 
ORDER BY Age DESC, [First Name], [Last Name]

-- 9. Full Info

SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
       pl.[Name] AS [Plane Name],
	   CONCAT(f.Origin,' - ',f.Destination) AS Trip,
	   lt.[Type] AS [Luggage Type]
FROM Tickets AS t
JOIN Passengers AS p ON p.Id=t.PassengerId
JOIN Flights AS f ON t.FlightId=f.Id
JOIN Planes AS pl ON f.PlaneId=pl.Id
JOIN Luggages AS l ON t.LuggageId=l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId=lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]

-- 10. PSP

SELECT pl.[Name], pl.Seats, COUNT(p.Id) AS [Passengers Count]
FROM Planes AS pl
LEFT JOIN Flights AS f ON pl.Id=f.PlaneId
LEFT JOIN Tickets AS t ON f.Id=t.FlightId
LEFT JOIN Passengers AS p ON t.PassengerId=p.Id
GROUP BY pl.[Name], pl.Seats
ORDER BY [Passengers Count] DESC, pl.[Name], Seats

-- 11. Vacation
CREATE FUNCTION udf_CalculateTickets (@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS
BEGIN
   IF (@peopleCount<=0) RETURN 'Invalid people count!'
   IF (NOT EXISTS (SELECT 1 FROM Flights WHERE Origin=@origin AND Destination=@destination))
   RETURN 'Invalid flight!'
   RETURN CONCAT('Total price ',
   (SELECT TOP(1) t.Price
   FROM Tickets AS t
   JOIN Flights AS f ON t.FlightId=f.Id
   WHERE Origin=@origin AND Destination=@destination)*@peopleCount)
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)


-- 12. Wrong Data

CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
   UPDATE Flights
   SET DepartureTime=NULL, ArrivalTime=NULL
   WHERE DepartureTime<ArrivalTime
END

EXEC usp_CancelFlights