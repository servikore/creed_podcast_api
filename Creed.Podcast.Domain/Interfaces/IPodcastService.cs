
namespace Creed.Podcast.Domain.Interfaces
{
    public interface IPodcastService
    {
        Task<PagedResults<Domain.Entities.Podcast>> GetPagedPotcasts(int genreId, string region, bool saveMode, int page, int pageSize);
    }
}
