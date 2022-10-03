SELECT m.MountainRange,p.PeakName,p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId=m.ID 
WHERE p.MountainId=17
ORDER BY p.Elevation DESC
