CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
  DECLARE @result BIT
  DECLARE @countLetter INT=1
  WHILE(@countLetter<=LEN(@word))
  BEGIN
    DECLARE @currentLetter CHAR(1)=SUBSTRING(@word,@countLetter,1)
    IF(CHARINDEX(@currentLetter,@setOfLetters)=0)
	   RETURN 0
    SET @countLetter+=1
  END
  RETURN 1
END



SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia')

SELECT dbo.ufn_IsWordComprised('oistmiahf','halves')