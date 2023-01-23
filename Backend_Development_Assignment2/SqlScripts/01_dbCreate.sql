
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


-- Create database
CREATE DATABASE [SuperheroesDB]



