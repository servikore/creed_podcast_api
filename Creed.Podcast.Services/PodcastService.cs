using Creed.Podcast.Domain;
using Creed.Podcast.Domain.Exceptions;
using Creed.Podcast.Domain.Interfaces;

namespace Creed.Podcast.Services
{
    public class PodcastService : IPodcastService
    {
        private readonly IPodcastRepository podcastRepository;

        public PodcastService(IPodcastRepository podcastRepository)
        {
            this.podcastRepository = podcastRepository;
        }
        public Task<PagedResults<Domain.Entities.Podcast>> GetPagedPotcasts(int genreId, string region, bool saveMode, int page, int pageSize)
        {
            if (genreId < 1)
                throw new DomainValidationException($"Parameter {nameof(genreId)} must be greather than 0.");

            if (string.IsNullOrEmpty(region))
                throw new DomainValidationException($"Parameter {nameof(region)} can not be null or empty");

            if (page < 1)
                throw new DomainValidationException($"Parameter {nameof(page)} must be greather than 0.");

            if (pageSize < 1)
                throw new DomainValidationException($"Parameter {nameof(pageSize)} must be greather than 0.");

            return podcastRepository.GetPagedPotcasts(genreId, region, saveMode, page, pageSize);
        }
    }
}
