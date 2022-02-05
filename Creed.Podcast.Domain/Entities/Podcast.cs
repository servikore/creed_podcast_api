using System;
using System.Collections.Generic;

namespace Creed.Podcast.Domain.Entities
{
    public partial class Podcast
    {
        public Podcast()
        {
            PodcastGenres = new HashSet<PodcastGenre>();            
        }

        public string PodcastId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public string? Image { get; set; }
        public string? Thumbnail { get; set; }
        public string? ListennotesUrl { get; set; }
        public int? TotalEpisodes { get; set; }
        public string? Description { get; set; }
        public int? ItunesId { get; set; }
        public string? Rss { get; set; }
        public string? Language { get; set; }
        public string? Website { get; set; }
        public bool? IsClaimed { get; set; }
        public bool? ExplicitContent { get; set; }
        public string? Type { get; set; }
        public string RegionId { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Region Region { get; set; } = null!;        
        public virtual ICollection<PodcastGenre> PodcastGenres { get; set; }
        
    }
}
