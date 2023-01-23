
/**********************************************************************************************************
	Appendix A: 4)
	Create a script that contains a statement
	for inserting new Superheroes into the database
	
*********************************************************************************************************/

USE SuperheroesDB;


-- Inserting new Superheroes
INSERT INTO [Superhero] ([Name], [Alias], [Origin]) VALUES 
	('Per Persen', 'Spider-man', 'Bit by spider'),
	('Pål Pålsen', 'Ant-man', 'Bit by ant'),
	('Espen Espensen', 'Rock-man', 'Hit by rock');


