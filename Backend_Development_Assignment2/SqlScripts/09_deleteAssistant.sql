
/**********************************************************************************************************
	Appendix A: 5)
	Create a script that contains a statement
	for deleting a assistant
	
*********************************************************************************************************/

USE SuperheroesDB;
GO

-- Updates superhero with id 1 - Spider man
DELETE FROM [Assistant]
WHERE [Name] = 'Petter Pettersen';
GO

