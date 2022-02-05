using System;
using System.Collections.Generic;

namespace Creed.Podcast.Domain.Entities
{
    public partial class PodcastGenre
    {
        public int GenreId { get; set; }
        public string PodcastId { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        //public virtual Podcast Podcast { get; set; } = null!;
    }
}
