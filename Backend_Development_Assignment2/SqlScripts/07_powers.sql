
/**********************************************************************************************************
	Appendix A: 4)
	Create a script that contains a statement
	for inserting new Powers into the database
	
*********************************************************************************************************/

USE SuperheroesDB;
GO

-- Inserting new Assistants
INSERT INTO [Power] ([Name], [Description]) VALUES 
	('Shoot webs', 'Shoot webs that stick to enemies'),
	('Shrink', 'Shrinks to an ant'),
	('Throw rock', 'Throws rocks'),
	('Fly', 'Flies in the air');
GO

