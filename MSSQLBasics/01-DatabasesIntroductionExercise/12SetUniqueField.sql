ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (ID)

ALTER TABLE Users
ADD CONSTRAINT Change_Username_Len CHECK (LEN(Username)>3)