SELECT CONCAT(FirstName,' ',LastName) AS Mechanic, [Status], IssueDate
FROM Mechanics AS m
JOIN Jobs As j ON m.MechanicId=j.MechanicId
ORDER BY m.MechanicId, IssueDate, JobId

--6
SELECT CONCAT(FirstName,' ',LastName) AS Client, DATEDIFF(DAY,IssueDate,'2017-04-24') AS [Days going], [Status]
FROM Clients AS c
JOIN Jobs AS j ON c.ClientId=j.ClientId
WHERE j.[Status]<>'Finished'
ORDER BY [Days going] DESC, c.ClientId

--7
SELECT CONCAT(FirstName,' ',LastName) AS Mechanic, AVG(DATEDIFF(DAY,IssueDate,FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs As j ON m.MechanicId=j.MechanicId
GROUP BY m.MechanicId, FirstName,LastName
ORDER BY m.MechanicId




--8
SELECT CONCAT(FirstName,' ',LastName) AS Available
FROM Mechanics AS m
LEFT JOIN Jobs As j ON j.MechanicId=m.MechanicId
WHERE j.JobId IS NULL OR 'Finished'=All(SELECT j.[Status] FROM Jobs AS j WHERE j.MechanicId=m.MechanicId)
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId

/*
SELECT CONCAT(FirstName,' ',LastName) AS Available
FROM Mechanics AS m
LEFT JOIN Jobs As j ON j.MechanicId=m.MechanicId
WHERE j.JobId IS NULL OR (SELECT COUNT(JobId) 
                          FROM Jobs 
						  WHERE [Status]<>'Finished' AND MechanicId=m.MechanicId
                          GROUP BY MechanicId, [Status]) IS NULL
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId
*/

--9
SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity),0) AS Total
FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE [Status]='Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--10
SELECT p.PartId,p.Description,pn.Quantity AS [Required],p.StockQty [In Stock], IIF(o.Delivered=0,op.Quantity,0) AS Ordered
FROM Parts AS p
LEFT JOIN PartsNeeded AS pn ON pn.PartId =p.PartId 
LEFT JOIN OrderParts AS op ON op.PartId=p.PartId
LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId=j.JobId
WHERE j.[Status] != 'Finished' AND p.StockQty+IIF(o.Delivered=0,op.Quantity,0)<pn.Quantity
ORDER BY p.PartId

--11
CREATE PROCEDURE usp_PlaceOrder(@JibId INT, @SerialNumber VARCHAR(50), @Quantity INT)
AS
BEGIN
   DECLARE @FinishJob VARCHAR(20)=(SELECT [Status] FROM Jobs WHERE JobId=@JibId)
   DECLARE  @partId INT=(SELECT partId FROM Parts WHERE SerialNumber=@SerialNumber)

   IF (@Quantity<=0)
      THROW 50012, 'Part quantity must be more than zero!',1
   ELSE
      IF(@FinishJob IS NULL)
         THROW 50013, 'Job not found!',1
      ELSE
         IF(@FinishJob='Finished')
            THROW 50011,'This job is not active!',1
         ELSE
            IF(@partId IS NULL)
               THROW 50014, 'Part not found!',1

   DECLARE @OrderId INT=(SELECT OrderId FROM Orders WHERE JobId=@JibId AND IssueDate IS NULL)

   IF (@OrderId IS NULL)
   BEGIN
      INSERT INTO Orders(JobId, IssueDate) VALUES
      (@JibId, NULL)
   END
   SET @OrderId =(SELECT OrderId FROM Orders WHERE JobId=@JibId AND IssueDate IS NULL)
   DECLARE @OrderPartExist INT=(SELECT OrderId FROM OrderParts WHERE OrderId=@OrderId AND PartId=@partId)

   IF(@OrderPartExist IS NULL)
   BEGIN
      INSERT INTO OrderParts (OrderId,PartId, Quantity) VALUES
      (@OrderId,@partId,@Quantity)
   END
   ELSE
   BEGIN
     UPDATE OrderParts
	 SET Quantity+=@Quantity
	 WHERE OrderId=@OrderId AND PartId=@partId
   END
END


DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH


--12
CREATE FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
   DECLARE @Result DECIMAL(18,2)=(
            SELECT SUM(p.Price*op.Quantity)
			FROM Orders AS o
			JOIN OrderParts AS op ON o.OrderId=op.OrderId
			JOIN Parts AS p ON op.PartId=p.PartId
			WHERE o.JobId=@JobId
			GROUP BY o.JobId)

    IF(@Result IS NULL)
      SET @Result=0

   RETURN @Result
END

SELECT dbo.udf_GetCost(1)