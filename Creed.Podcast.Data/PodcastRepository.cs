using Creed.Podcast.Domain;
using Creed.Podcast.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creed.Podcast.Data
{
    public class PodcastRepository : GenericRepository<Domain.Entities.Podcast>, IPodcastRepository
    {
        private readonly PodcastDbContext podcastDbContext;

        public PodcastRepository(PodcastDbContext podcastDbContext):base(podcastDbContext)
        {
            this.podcastDbContext = podcastDbContext;
        }
        public async Task<PagedResults<Domain.Entities.Podcast>> GetPagedPotcasts(int genreId, string region, bool saveMode, int page, int pageSize)
        {
            var query = podcastDbContext.Podcasts
                .Include(p => p.Region)
                .Include(p => p.PodcastGenres)
                    .ThenInclude(pg => pg.Genre)
                .Where(p => p.RegionId == region
                    && p.ExplicitContent == saveMode
                    && p.PodcastGenres.Any(x => x.GenreId == genreId));

            var totalRows = await query.CountAsync();

            if (totalRows == 0)
            {
                return PagedResults<Domain.Entities.Podcast>.Empty();                
            }
                
            var podcasts = await query.OrderBy(p => p.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)                
                .ToListAsync();

            return PagedResults<Domain.Entities.Podcast>.Generate(podcasts, totalRows, page, pageSize);

        }
    }
}
