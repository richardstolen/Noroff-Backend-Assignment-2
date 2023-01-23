
/**********************************************************************************************************
	Appendix A: 3)
	Create a script that contains a statement
	for creating the relationship between Superhero and Powers
	
	The- relationship should be:
		One Superhero can have many powers, and one power can be present on many Superheroes
		Many to many
*********************************************************************************************************/

USE SuperheroesDB;


-- Creating a junction table for many-to-many relationship
CREATE TABLE [Superhero_Power_Mapping](
	[SuperheroId] INT REFERENCES [Superhero]([Id]),
	[PowerId] INT REFERENCES [Power]([Id]),
	PRIMARY KEY ([SuperheroId], [PowerId])
);


