CREATE PROCEDURE usp_GetTownsStartingWith @parameter VARCHAR(100)
AS
BEGIN
   SELECT [Name] AS Town
   FROM Towns
   WHERE LEFT([Name],LEN(@parameter))=@parameter
END

EXEC usp_GetTownsStartingWith 'b'