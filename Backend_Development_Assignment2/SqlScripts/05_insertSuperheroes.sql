
/**********************************************************************************************************
	Appendix A: 4)
	Create a script that contains a statement
	for inserting new Superheroes into the database
	
	The- relationship should be:
		One Superhero can have many powers, and one power can be present on many Superheroes
		Many to many
*********************************************************************************************************/

USE SuperheroesDB;
GO

-- Inserting new Superheroes
INSERT INTO [Superhero] ([Name], [Alias], [Origin]) VALUES 
	('Per Persen', 'Spider-man', 'Bit by spider'),
	('Pål Pålsen', 'Ant-man', 'Bit by ant');
GO

