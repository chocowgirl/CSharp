CREATE TABLE [dbo].[Activity]
(
	[User_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [First_Name] NVARCHAR(50) NOT NULL, 
    [Last_Name] NVARCHAR(50) NOT NULL,
    [Birth_Date] DATE NOT NULL,


)
