
/****************************************************************
	Appendix A: 1)
	Create a script that contains a statement
	for creating a database.
	The database should be called SuperheroesDB
****************************************************************/

-- Drop database if exists
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'SuperheroesDB')
BEGIN
	DROP DATABASE [SuperheroesDB]
END
GO

-- Create database
CREATE DATABASE [SuperheroesDB]
GO


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


/*******************************************************************************
	Appendix A: 3)
	Create a script that contains a statement
	for creating the relationship between Superhero and Assistant
	
	The- relationship should be:
		- One Superhero can have multiple assistants, 
		  one assistant has one superhero they assist.
*******************************************************************************/

-- Add SuperheroId column
ALTER TABLE [Assistant]
ADD [SuperheroId] INT
GO

-- Create foreign key, linking [Assistant].[SuperheroId] with [Superhero].[Id]
ALTER TABLE [Assistant]
ADD CONSTRAINT FK_Superhero
FOREIGN KEY ([SuperheroId]) REFERENCES [Superhero]([Id])
GO


/**********************************************************************************************************
	Appendix A: 3)
	Create a script that contains a statement
	for creating the relationship between Superhero and Powers
	
	The- relationship should be:
		One Superhero can have many powers, and one power can be present on many Superheroes
		Many to many
*********************************************************************************************************/

-- Creating a junction table for many-to-many relationship
CREATE TABLE [Superhero_Power_Mapping](
	[SuperheroId] INT REFERENCES [Superhero]([Id]),
	[PowerId] INT REFERENCES [Power]([Id]),
	PRIMARY KEY ([SuperheroId], [PowerId])
);
GO


/**********************************************************************************************************
	Appendix A: 4)
	Create a script that contains a statement
	for inserting new Superheroes into the database
	
*********************************************************************************************************/


-- Inserting new Superheroes
INSERT INTO [Superhero] ([Name], [Alias], [Origin]) VALUES 
	('Per Persen', 'Spider-man', 'Bit by spider'),
	('Pål Pålsen', 'Ant-man', 'Bit by ant'),
	('Espen Espensen', 'Rock-man', 'Hit by rock');
GO


/**********************************************************************************************************
	Appendix A: 4)
	Create a script that contains a statement
	for inserting new Assistants into the database
	
*********************************************************************************************************/

-- Inserting new Assistants
INSERT INTO [Assistant] ([Name], [SuperheroId]) VALUES 
	('Frank Frankesen', 1),
	('Katrine Katrinesen', 2),
	('Petter Pettersen', 3);
GO


/**********************************************************************************************************
	Appendix A: 4)
	Create a script that contains a statement
	for inserting new Powers into the database
	
*********************************************************************************************************/

-- Inserting new Assistants
INSERT INTO [Power] ([Name], [Description]) VALUES 
	('Shoot webs', 'Shoot webs that stick to enemies'),
	('Shrink', 'Shrinks to an ant'),
	('Throw rock', 'Throws rocks'),
	('Fly', 'Flies in the air');
GO


/**********************************************************************************************************
	Appendix A: 5)
	Create a script that contains a statement
	for updating a Superheroes name
	
*********************************************************************************************************/

-- Updates superhero with id 1 - Spider man
UPDATE [Superhero]
SET [Name] = 'Peter Parker'
WHERE [Id] = 1;
GO


/**********************************************************************************************************
	Appendix A: 6)
	Create a script that contains a statement
	for deleting a assistant
	
*********************************************************************************************************/

-- Delete assistant
DELETE FROM [Assistant]
WHERE [Name] = 'Petter Pettersen';
GO