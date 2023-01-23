
/**********************************************************************************************************
	Appendix A: 4)
	Create a script that contains a statement
	for inserting new Assistants into the database
	
*********************************************************************************************************/

USE SuperheroesDB;
GO

-- Inserting new Assistants
INSERT INTO [Assistant] ([Name], [SuperheroId]) VALUES 
	('Frank Frankesen', 1),
	('Katrine Katrinesen', 2),
	('Petter Pettersen', 3);
GO

