CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR (50))
RETURNS TABLE
AS
   RETURN SELECT
		  (
			SELECT SUM(Cash) AS SumCash
			FROM (
			      SELECT g.[Name], ug.Cash,
				  ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS RowNumber
				  FROM UsersGames AS ug
				  JOIN Games AS g ON ug.GameId=g.Id
				  WHERE g.[Name]=@gameName
				  ) AS SubQ
		    WHERE RowNumber%2<>0
          ) AS SumCash

SELECT * FROM dbo.ufn_CashInUsersGames ('Love in a mist')