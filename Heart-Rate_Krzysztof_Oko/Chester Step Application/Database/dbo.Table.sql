﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [First Name] NVARCHAR(50) NOT NULL, 
    [Last Name] NVARCHAR(50) NOT NULL, 
    [Tester Name] NVARCHAR(50) NOT NULL, 
    [Result] NVARCHAR(50) NOT NULL
)
