-- Read - mange											-- CRUD = Create Read Update Delete
SELECT Id, FirstName, LastName, BirthYear
FROM Person
-- WHERE BirthYear > 1980

-- Read - én
SELECT Id, FirstName, LastName, BirthYear
FROM Person
WHERE Id = 1001

-- Read - én - med parameter
DECLARE @Id int = 1;
SELECT Id, FirstName, LastName, BirthYear
FROM Person
WHERE Id = @Id

-- Create
DECLARE @FirstName varchar(max) = 'Terje';
DECLARE @LastName varchar(max) = 'Kolderup';
DECLARE @BirthYear int = 1975;
INSERT INTO Person (FirstName, LastName, BirthYear)
VALUES (@FirstName, @LastName, @BirthYear)

-- Delete
DECLARE @Id int = 1;
DELETE FROM Person WHERE Id = @Id

-- Update
DECLARE @FirstName varchar(max) = 'Petter';
DECLARE @LastName varchar(max) = 'Kolderup';
DECLARE @Id int = 2;
UPDATE Person 
SET LastName = @LastName, FirstName = @LastName
WHERE Id = @Id
-- WHERE BirthYear > @BirthYear



USE [getit]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 29.05.2019 15.11.53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[BirthYear] [int] NULL
) 


ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
