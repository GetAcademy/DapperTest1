-- Read - mange											-- CRUD = Create Read Update Delete
SELECT Id, Fornavn, Etternavn, Fødselsår
FROM Person
-- WHERE Fødselsår > 1980

-- Read - én
SELECT Id, Fornavn, Etternavn, Fødselsår
FROM Person
WHERE Id = 1001

-- Read - én - med parameter
DECLARE @Id int = 1;
SELECT Id, Fornavn, Etternavn, Fødselsår
FROM Person
WHERE Id = @Id

-- Create
INSERT INTO Person (Fornavn, Etternavn, Fødselsår)
VALUES ('Terje', 'Kolderup', 1975)

-- Delete
DECLARE @Id int = 1;
DELETE FROM Person WHERE Id = @Id

-- Update
DECLARE @Id int = 2;
UPDATE Person 
SET Etternavn = 'Pettersen', Fornavn = 'Petter'
WHERE Id = @Id
-- WHERE Fødselsår > 1980



USE [getit]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 29.05.2019 15.11.53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fornavn] [nvarchar](max) NULL,
	[Etternavn] [nvarchar](max) NULL,
	[Fødselsår] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
