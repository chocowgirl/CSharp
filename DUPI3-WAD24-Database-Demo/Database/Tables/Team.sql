﻿CREATE TABLE [dbo].[Team]
(
	[Team_Id] INT NOT NULL IDENTITY CONSTRAINT [PK_Team] PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL,
	[Captain_Id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [UK_Team_Name] UNIQUE ([Name]), 
    CONSTRAINT [FK_Team_Captain] FOREIGN KEY ([Captain_Id]) REFERENCES [Person]([Person_Id])
)
