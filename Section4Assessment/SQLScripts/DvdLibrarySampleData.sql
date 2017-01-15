USE DvdLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DBReset')
		DROP PROCEDURE DBReset
GO
	
CREATE PROCEDURE DBReset AS
BEGIN
	
	DELETE FROM Dvds;
	DELETE FROM Ratings;

	DBCC CHECKIDENT (Dvds, reseed,0)
		
	INSERT INTO Ratings (rating)
	VALUES ('G'),
	('PG'),
	('PG-13'),
	('R'),
	('X');
		
	INSERT INTO Dvds (title, releaseYear, director, rating, notes)
	VALUES ('A Great Tale','2015', 'Sam Jones', 'PG', 'This really is a great tale!'),
	('A Good Tale','2012', 'Joe Smith', 'PG-13', 'This is a good tale!'),
	('A Director Test','2010', 'Joe Smith', 'R', 'Testing for directors'),
	('A Title Test','2009', 'Fiona Smith', 'G', 'Testing for a title match'),
	('A Title Test','2008', 'Jacob Smith', 'X', 'Testing for a title match!'),
	('A Rating Test','2007', 'Lyle Smith', 'PG-13', 'Testing for ratings'),
	('A releaseYear Test','2012', 'Peter Smith', 'R', 'Testing for release year!');

END
GO
