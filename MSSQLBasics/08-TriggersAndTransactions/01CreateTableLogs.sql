CREATE TABLE Logs
(
  LogId INT PRIMARY KEY IDENTITY, 
  AccountId INT REFERENCES Accounts(Id), 
  OldSum DECIMAL(18,2), 
  NewSum DECIMAL(18,2)
)


CREATE TRIGGER tr_AddToLogsOnAccountUpdate ON Accounts FOR UPDATE
AS
DECLARE @newSum DECIMAL(18,2)=(SELECT Balance FROM inserted)
DECLARE @oldSum DECIMAL(18,2)=(SELECT Balance FROM deleted)
DECLARE @idAccount INT=(SELECT Id FROM inserted)

INSERT INTO Logs (AccountId,NewSum,OldSum) VALUES
(@idAccount,@newSum,@oldSum)



UPDATE Accounts
SET Balance+=10
WHERE id=1

SELECT * FROM Accounts
SELECT * FROM Logs