
/*******************************************************************************
	Appendix A: 2)
	Create a script that contains a statement
	for creating the tables.
	The tables should be:
		Superhero [Id integer auto increment], [Name], [Alias], [Origin]
		Assistant [Id integer auto increment], [Name]
		Power	  [Id integer auto increment], [Name], [Description]
*******************************************************************************/

USE SuperheroesDB;

-- Superhero table
CREATE TABLE [Superhero] (
	[Id] INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	[Alias] NVARCHAR(50) NOT NULL,
	[Origin] NVARCHAR(50) NOT NULL
);
GO

-- Assistant table
CREATE TABLE [Assistant] (
	[Id] INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
);
GO

-- Power table
CREATE TABLE [Power] (
	[Id] INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	[Description] NVARCHAR(60) NOT NULL
);
GO



