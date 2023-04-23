CREATE TABLE [dbo].[Monkey]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [Name] NCHAR(100) NOT NULL, 
    [Location] NCHAR(100) NULL, 
    [Details] NCHAR(1000) NULL, 
    [Image] NVARCHAR(2083) NULL, 
    [Population] BIGINT NULL, 
    [Latitude] DECIMAL(18, 2) NOT NULL, 
    [Longitude] DECIMAL(18, 2) NOT NULL,
    CONSTRAINT PK_Monkey_Id PRIMARY KEY (Id),
)
