using System;
using System.Collections.Generic;

namespace Creed.Podcast.Domain.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            //PodcastGenres = new HashSet<PodcastGenre>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        //public virtual ICollection<PodcastGenre> PodcastGenres { get; set; }
    }
}
