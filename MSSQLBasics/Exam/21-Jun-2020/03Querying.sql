SELECT a.FirstName,	a.LastName,	FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate, c.[Name] AS Hometown, a.Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id=a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.[Name]


SELECT c.[Name], COUNT(c.Id) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON c.Id=h.CityId
GROUP BY c.[Name]
ORDER BY COUNT(c.Id) DESC, c.[Name]


SELECT atr.AccountId, FirstName +' '+ LastName AS FullName,
MAX(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS LongestTtip,
MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS ShortestTtip
FROM Trips AS t
JOIN AccountsTrips AS atr ON t.Id=atr.TripId
JOIN Accounts AS a ON atr.AccountId=a.Id
WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
GROUP BY atr.AccountId, a.FirstName, a.LastName
ORDER BY LongestTtip DESC, ShortestTtip


SELECT TOP(10) c.Id, c.[Name] AS City,  c.CountryCode AS Country, COUNT(c.Id) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON c.Id=a.CityId
GROUP BY c.Id, c.CountryCode, c.[Name]
ORDER BY COUNT(c.Id) DESC


SELECT atr.AccountId AS Id, a.Email, ac.[Name] AS City, COUNT(*) AS Trips
FROM AccountsTrips AS atr
JOIN Accounts AS a ON atr.AccountId=a.Id
JOIN Cities AS ac ON ac.Id=a.CityId
JOIN Trips AS t ON atr.TripId=t.Id
JOIN Rooms AS r ON t.RoomId=r.Id
JOIN Hotels AS h ON r.HotelId=h.Id
JOIN Cities AS hc ON h.CityId=hc.Id
WHERE ac.Id=hc.Id
GROUP BY atr.AccountId, a.Email, ac.[Name]
ORDER BY COUNT(*) DESC, atr.AccountId


SELECT t.Id, 
CASE 
   WHEN a.MiddleName IS NULL THEN a.FirstName +' '+a.LastName
   ELSE a.FirstName +' '+ a.MiddleName+' '+a.LastName 
END AS FullName, 
ac.[Name] AS [From], hc.[Name] AS [To],
CASE
    WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
    ELSE CONVERT(VARCHAR(10),DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) +' '+'days'
END AS Duration
FROM Trips AS t
JOIN AccountsTrips AS atr ON t.Id=atr.TripId
JOIN Accounts AS a ON atr.AccountId=a.Id
JOIN Cities AS ac ON ac.Id=a.CityId
JOIN Rooms AS r ON r.Id=t.RoomId
JOIN Hotels AS h ON r.HotelId=h.Id
JOIN Cities AS hc ON h.CityId=hc.Id
ORDER BY FullName, t.Id


CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN
   DECLARE @Info VARCHAR(MAX)=(SELECT TOP(1) 'Room'+' '+CONVERT(VARCHAR,r.Id) +': '+r.Type+' ('+CONVERT(VARCHAR,r.Beds)+' beds) - $'+CONVERT(VARCHAR,(BaseRate+Price)*@People)
                 FROM Rooms AS r
				 JOIN Hotels AS h ON r.HotelId=h.Id
				 WHERE Beds>=@People AND HotelId=@HotelId AND
				    NOT EXISTS (SELECT* FROM Trips AS t WHERE t.RoomId=r.Id AND CancelDate IS NULL
					                                           AND @Date BETWEEN ArrivalDate AND ReturnDate)
				ORDER BY (BaseRate+Price)*@People DESC)
	IF @Info IS NULL
	   RETURN 'No rooms available'
	RETURN @Info
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)


CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
  DECLARE @TripHotelId INT= (SELECT r.HotelId
							FROM Trips AS t
							JOIN Rooms AS r ON r.Id=t.RoomId
							WHERE t.Id=@TripId)
  DECLARE @RoomTargetHotelId INT= (SELECT HotelId
                              FROM Rooms
							  WHERE Id=@TargetRoomId)

  IF(@TripHotelId!=@RoomTargetHotelId)
     THROW 50001, 'Target room is in another hotel!',1


  DECLARE @TripAccounts INT= (SELECT COUNT(*)
                              FROM AccountsTrips
							  WHERE TripId=@TripId)
  DECLARE @TargetRoomBeds INT=(SELECT Beds
                               FROM Rooms
							   WHERE Id=@TargetRoomId)
  IF(@TripAccounts>@TargetRoomBeds)
     THROW 50002, 'Not enough beds in target room!',1

  UPDATE Trips
  SET RoomId=@TargetRoomId
  WHERE Id=@TripId

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8


