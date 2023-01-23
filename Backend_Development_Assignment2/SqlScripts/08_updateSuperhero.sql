
/**********************************************************************************************************
	Appendix A: 5)
	Create a script that contains a statement
	for updating a Superheroes name
	
*********************************************************************************************************/

USE SuperheroesDB;


-- Updates superhero with id 1 - Spider man
UPDATE [Superhero]
SET [Name] = 'Peter Parker'
WHERE [Id] = 1;


