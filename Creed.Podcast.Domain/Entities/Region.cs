using System;
using System.Collections.Generic;

namespace Creed.Podcast.Domain.Entities
{
    public partial class Region
    {
        public Region()
        {
            //Podcasts = new HashSet<Podcast>();
        }

        public string RegionId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        //public virtual ICollection<Podcast> Podcasts { get; set; }
    }
}
