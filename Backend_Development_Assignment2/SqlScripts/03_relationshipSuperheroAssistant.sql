
/*******************************************************************************
	Appendix A: 3)
	Create a script that contains a statement
	for creating the relationship between Superhero and Assistant
	
	The- relationship should be:
		- One Superhero can have multiple assistants, 
		  one assistant has one superhero they assist.
*******************************************************************************/

USE SuperheroesDB;


-- Add SuperheroId column
ALTER TABLE [Assistant]
ADD [SuperheroId] INT


-- Create foreign key, linking [Assistant].[SuperheroId] with [Superhero].[Id]
ALTER TABLE [Assistant]
ADD CONSTRAINT FK_Superhero
FOREIGN KEY ([SuperheroId]) REFERENCES [Superhero]([Id])



