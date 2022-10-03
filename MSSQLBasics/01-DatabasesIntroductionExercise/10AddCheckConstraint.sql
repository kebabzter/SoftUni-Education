ALTER TABLE Users
ADD CONSTRAINT Change_Password_Len CHECK (LEN([Password])>5)