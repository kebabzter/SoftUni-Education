-- 5. Select all military journeys
SELECT Id, FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart,
FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
WHERE Purpose='Military'
ORDER BY JourneyStart

-- 6. Select all pilots
SELECT c.Id, CONCAT(c.FirstName, ' ',c.LastName) AS full_name
FROM Colonists AS c 
JOIN TravelCards AS tc ON c.Id=tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

-- 7. Count colonists
SELECT COUNT(*) AS [Count]
FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id=tc.ColonistId
JOIN Journeys AS j ON tc.JourneyId=j.Id
WHERE j.Purpose='Technical'

-- 8. Select spaceships with pilots younger than 30 years
SELECT s.[Name], s.Manufacturer
FROM Spaceships AS s
JOIN Journeys AS j ON s.Id=j.SpaceshipId
JOIN TravelCards AS tc ON j.Id=tc.JourneyId
JOIN Colonists AS c ON tc.ColonistId=c.Id
WHERE DATEDIFF(year, c.BirthDate,'2019-01-01') <30 AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.[Name]

--9. Select all planets and their journey count
SELECT p.[Name], COUNT(j.JourneyStart) AS JourneysCount
FROM Planets AS p
JOIN Spaceports sp ON p.Id = sp.PlanetId
JOIN Journeys j on j.DestinationSpaceportId = sp.Id
GROUP BY p.[Name]
ORDER By JourneysCount DESC, p.[Name]


-- 10.	Select Second Oldest Important Colonist
SELECT k.JobDuringJourney, c.FirstName + ' ' + c.LastName AS FullName, k.JobRank
FROM (
     SELECT tc.JobDuringJourney AS JobDuringJourney, tc.ColonistId,
            DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY co.Birthdate ASC) AS JobRank
	 FROM TravelCards AS tc
     JOIN Colonists AS co ON co.Id = tc.ColonistId
     GROUP BY tc.JobDuringJourney, co.Birthdate, tc.ColonistId
     ) AS k
JOIN Colonists AS c ON c.Id = k.ColonistId
WHERE k.JobRank = 2
ORDER BY k.JobDuringJourney

-- 11. Get Colonists Count
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
RETURN (SELECT COUNT(*) 
		FROM Journeys AS j
		JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
		JOIN Planets AS p ON p.Id = s.PlanetId
		JOIN TravelCards AS tc ON tc.JourneyId = j.Id
		JOIN Colonists AS c ON c.Id = tc.ColonistId
		WHERE p.[Name] = @PlanetName)
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')

-- 12. Change Journey Purpose
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
IF NOT EXISTS (SELECT 1 FROM Journeys WHERE Id=@JourneyId)
	 THROW 50010, 'The journey does not exist!', 1;

IF @NewPurpose IN (SELECT Purpose FROM Journeys WHERE Id=@JourneyId )
	 THROW 50015, 'You cannot change the purpose!', 1;

UPDATE Journeys
SET Purpose=@NewPurpose
WHERE Id=@JourneyId
END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
