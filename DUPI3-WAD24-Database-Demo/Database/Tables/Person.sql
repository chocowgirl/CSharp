CREATE TABLE [dbo].[Person]
(
	[Person_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [First_Name] NVARCHAR(64) NOT NULL, 
    [Last_Name] NVARCHAR(64) NOT NULL,
    [Birth_Date] DATE NOT NULL,
    [Team_Id] INT,
    CONSTRAINT PK_Person PRIMARY KEY ([Person_Id]),
    CONSTRAINT [FK_Person_Team] FOREIGN KEY ([Team_Id]) REFERENCES [Team]([Team_Id]), 
    CONSTRAINT [CK_Person_Birth_Date] CHECK (DATEDIFF(YEAR,[Birth_Date],GETDATE()) >= 18)
)
