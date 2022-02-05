using AutoMapper;
using Creed.Podcast.Domain.Entities;
using Creed.Podcast.Domain.Exceptions;
using Creed.Podcast.Domain.Interfaces;
using Creed.Podcast.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Creed.Podcast.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/potcast")]
    public class PodcastController : ControllerBase
    {
        private readonly ILogger<PodcastController> _logger;
        private readonly IGenericRepository<Genre> genericRepository;
        private readonly IPodcastService podcastService;
        private readonly IMapper mapper;

        public PodcastController(ILogger<PodcastController> logger,
            IGenericRepository<Genre> genericRepository,
            IPodcastService podcastService, 
            IMapper mapper)
        {
            _logger = logger;
            this.genericRepository = genericRepository;
            this.podcastService = podcastService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Search for best podcasts
        /// </summary>
        /// <param name="genre_id">Must be greather than 0</param>
        /// <param name="page">Must be greather than 0</param>
        /// <param name="region">ISO 3166-1 code, example us for United States</param>
        /// <param name="safe_mode">0 includes podcasts that constains explicit content, 1 explicit content are excluded</param>
        /// <returns></returns>
        /// <exception cref="DomainValidationException"></exception>
        /// <exception cref="DomainNotFoundException"></exception>
        [HttpGet()]
        [Route("best_podcasts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BestPodcastsResponse>> BestPodcasts([Required] int genre_id, [Required] int page, [Required] string region, [Required] int safe_mode)
        {
            if (safe_mode > 1 || safe_mode < 0)
                throw new DomainValidationException($"Parameter {nameof(safe_mode)} must be 1 or 0.");

            var pagedPodcasts = await podcastService.GetPagedPotcasts(genre_id, region, safe_mode == 1, page, 5);
            
            if(pagedPodcasts.IsEmpty())
                throw new DomainNotFoundException($"Not podcasts were found.");

            var genre = await genericRepository.GetById(genre_id);

            var response = mapper.Map<BestPodcastsResponse>(pagedPodcasts);            
            response.Id = genre.GenreId;
            response.Name = genre.Name;

            return Ok(response);
        }
    }
}