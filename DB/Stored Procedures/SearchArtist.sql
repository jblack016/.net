CREATE PROCEDURE dbo.SearchArtist @name varchar(100)

AS
BEGIN

	SELECT 
	artistID, 
	dateCreation, 
	title,
	biography, 
	imageURL, 
	heroURl
	FROM Artist 
	WHERE title = @name

END
