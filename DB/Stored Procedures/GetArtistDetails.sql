CREATE PROCEDURE dbo.GetArtistDetails @artistId int

AS
BEGIN

	SELECT
		Artist.artistID, 
		Artist.dateCreation, 
		Artist.title AS artistName,
		Artist.biography AS artistBio,
		Artist.imageURL AS artistImage,
		Artist.heroURl AS artistHero,
		Song.title AS songTitle,
		Song.bpm AS songBpm,
		Song.timeSignature AS songTimeSig,
		Song.multitracks AS songMT,
		Song.customMix AS songCm,
		Song.chart AS songChart,
		Song.rehearsalMix AS songRm,
		Song.patches AS songPatches,
		Song.proPresenter AS songPro,
		Album.title AS albumTitle,
		Album.imageURL AS albumImage,
		Album.year AS albumYear
	FROM Artist 
	LEFT JOIN Song ON Artist.artistId = Song.artistId
	LEFT JOIN Album ON Artist.artistId = Album.artistId
	WHERE Artist.artistID = @artistId
END
