CREATE TABLE Regions
(	
	RegionId NVarchar(5) Not Null Primary Key,
	[Name] NVarchar(50) Not Null,
	CreatedOn DateTime2(7) Default(GetUtcDate()),
	CreatedBy NVarchar(50),
	UpdatedOn DateTime2(7) Null,
	UpdatedBy NVarchar(50),
	DeletedOn DateTime2(7) Null
)
Go

CREATE TABLE Genres
(
	GenreId Int Primary Key,	
	[Name] NVarchar(50) Not Null,
	CreatedOn DateTime2(7) Default(GetUtcDate()),
	CreatedBy NVarchar(50),
	UpdatedOn DateTime2(7) Null,
	UpdatedBy NVarchar(50),
	DeletedOn DateTime2(7) Null
)
Go

CREATE TABLE Podcasts
(
	PodcastId Nvarchar(50) Primary Key,	
	Title NVarchar(500) Not Null,
	Publisher NVarchar(500) Not Null,
	[Image] NVarchar(500) Null,
	Thumbnail NVarchar(500) Null,
	ListennotesUrl NVarchar(500) Null,
	TotalEpisodes Int Null,
	[Description] NVarchar(500) Null,
	ItunesId Int Null,
	Rss NVarchar(500) Null,
	[Language] NVarchar(50) Null,	
	Website NVarchar(500) Null,	
	IsClaimed bit Default(0),
	ExplicitContent bit default(0),
	[Type] NVarchar(50),
	RegionId NVarchar(5) Not Null,
	CreatedOn DateTime2(7) Default(GetUtcDate()),
	CreatedBy NVarchar(50),
	UpdatedOn DateTime2(7) Null,
	UpdatedBy NVarchar(50),
	DeletedOn DateTime2(7) Null,
	CONSTRAINT FK_PodcastRegion_RegionId FOREIGN KEY (RegionId) REFERENCES Regions(RegionId)
)
Go

CREATE TABLE PodcastGenres
(	
	GenreId Int Not Null,
	PodcastId Nvarchar(50) Not Null,
	CreatedOn DateTime2(7) Default(GetUtcDate()),
	CreatedBy NVarchar(50),
	UpdatedOn DateTime2(7) Null,
	UpdatedBy NVarchar(50),
	DeletedOn DateTime2(7) Null,
	CONSTRAINT PK_PodcastGenres PRIMARY KEY (GenreId,PodcastId),
	CONSTRAINT FK_PodcastGenres_GenreId FOREIGN KEY (GenreId) REFERENCES Genres(GenreId),
	CONSTRAINT FK_PodcastGenres_PodcastId FOREIGN KEY (PodcastId) REFERENCES Podcasts(PodcastId)
)
Go