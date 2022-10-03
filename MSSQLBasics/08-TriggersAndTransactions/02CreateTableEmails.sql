CREATE TABLE NotificationEmails
(Id INT PRIMARY KEY IDENTITY, 
Recipient INT REFERENCES Accounts(id), 
[Subject] VARCHAR(MAX), 
Body VARCHAR(MAX)
) 

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
DECLARE @idAccount INT=(SELECT TOP(1) AccountId FROM inserted)
DECLARE @oldSum DECIMAL(18,2)=(SELECT TOP(1) OldSum FROM inserted)
DECLARE @newSum DECIMAL(18,2)=(SELECT TOP(1) NewSum FROM inserted)

INSERT INTO NotificationEmails (Recipient,[Subject],Body) VALUES
(@idAccount, 
'Balance change for account: '+CAST(@idAccount AS VARCHAR(30)), 
'On '+ CONVERT(VARCHAR(50),GETDATE(),100)+' your balance was changed from '+CAST(@oldSum AS VARCHAR(30))+' to '+CAST(@newSum AS VARCHAR(30))+'.')



UPDATE Accounts
SET Balance+=100
WHERE id=1


SELECT * FROM NotificationEmails