using AutoMapper;
using Creed.Podcast.Domain;
using Creed.Podcast.WebApi.Models;

namespace Creed.Podcast.WebApi.MapperProfiles
{
    public class PodcastProfile : Profile
    {
        public PodcastProfile()
        {
            CreateMap<Domain.Entities.Podcast, PodcastDTO>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.PodcastId))
                .ForMember(p => p.Country, opt => opt.MapFrom(p => p.Region.Name))
                .ForMember(p => p.GenreIds, opt => opt.MapFrom(p => p.PodcastGenres.Select(x => x.GenreId)));

            CreateMap<PagedResults<Domain.Entities.Podcast>, BestPodcastsResponse>()
                .ForMember(p => p.Podcasts, opt => opt.MapFrom(p => p.Results));
        }
    }
}
