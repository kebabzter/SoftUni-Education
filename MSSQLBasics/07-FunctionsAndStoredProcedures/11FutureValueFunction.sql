CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL (18,2), @yearlyInterestRate FLOAT, @numberYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
   RETURN @sum*(POWER(1+@yearlyInterestRate,@numberYears))
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)