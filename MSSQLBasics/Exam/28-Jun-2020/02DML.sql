-- Insert
INSERT INTO Planets ([Name])
VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships ([Name], Manufacturer, LightSpeedRate)
VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed',	'Vidolov', 6)

-- Update
UPDATE Spaceships
SET LightSpeedRate=LightSpeedRate+1
WHERE Id BETWEEN 8 AND 12

-- Delete
DELETE TravelCards
WHERE JourneyId IN (1,2,3)

DELETE Journeys
WHERE Id IN (1,2,3)
