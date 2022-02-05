--Needed for best_podcasts search
CREATE NONCLUSTERED INDEX Idx_Podcasts_Best_Podcasts ON [dbo].[Podcasts] (RegionId,ExplicitContent);

--Needed because Podcasts are ordered by title
CREATE NONCLUSTERED INDEX Idx_Podcasts_Title ON [dbo].[Podcasts] (Title);