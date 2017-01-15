USE DvdLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdId')
		DROP PROCEDURE GetDvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvds')
		DROP PROCEDURE GetDvds

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsDirector')
		DROP PROCEDURE GetDvdsDirector
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsRating')
		DROP PROCEDURE GetDvdsRating
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsTitle')
		DROP PROCEDURE GetDvdsTitle
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsYear')
		DROP PROCEDURE GetDvdsYear
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateDvdId')
		DROP PROCEDURE UpdateDvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PostDvd')
		DROP PROCEDURE PostDvd
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteDvdId')
		DROP PROCEDURE DeleteDvdId
GO

CREATE PROCEDURE GetDvdId (
@dvdId int
) AS

BEGIN

	SELECT dvdId, title, releaseYear, director, rating, notes
	FROM Dvds 
	WHERE dvdId = @dvdId
End
GO

CREATE PROCEDURE GetDvds AS
BEGIN
	SELECT dvdId, title, releaseYear, director, rating, notes
	FROM Dvds
	ORDER BY dvdId
END

GO

CREATE PROCEDURE GetDvdsDirector(
@director varchar(50)
) AS
BEGIN
	SELECT dvdId, title, releaseYear, director, rating, notes
	FROM Dvds
	WHERE director = @director
	ORDER BY director
END
GO

CREATE PROCEDURE GetDvdsTitle(
@title varchar(50)
) AS
BEGIN
	SELECT dvdId, title, releaseYear, director, rating, notes
	FROM Dvds
	WHERE title = @title
	ORDER BY title
END
GO

CREATE PROCEDURE GetDvdsYear(
@releaseYear char(4)
) AS
BEGIN
	SELECT dvdId, title, releaseYear, director, rating, notes
	FROM Dvds
	WHERE releaseYear = @releaseYear
	ORDER BY releaseYear
END
GO

CREATE PROCEDURE GetDvdsRating(
@rating char(5)
) AS
BEGIN
	SELECT dvdId, title, releaseYear, director, rating, notes
	FROM Dvds
	WHERE rating = @rating
	ORDER BY rating
END
GO

CREATE PROCEDURE PostDvd (
@dvdId int output,
@title varchar(50),
@releaseYear char(4),
@director varchar(50),
@rating char(5),
@notes varchar(250)

) AS
BEGIN
	INSERT INTO Dvds(title,releaseYear,director,rating,notes)
	VALUES(@title, @releaseYear, @director, @rating, @notes)
SET @dvdId = SCOPE_IDENTITY();

END
GO

CREATE PROCEDURE UpdateDvdId (
@dvdId int,
@title varchar(50),
@releaseYear char(4),
@director varchar(50),
@rating varchar(5),
@notes varchar(250)
)AS
BEGIN
	UPDATE Dvds SET
	title = @title,
	releaseYear = @releaseYear,
	director = @director,
	rating = @rating,
	notes = @notes
	
	WHERE dvdId = @dvdId
END
GO

CREATE PROCEDURE DeleteDvdId (
@dvdId int
) AS

BEGIN

	BEGIN TRANSACTION

	DELETE FROM Dvds WHERE dvdId = @dvdId;
	
	COMMIT TRANSACTION

End
GO