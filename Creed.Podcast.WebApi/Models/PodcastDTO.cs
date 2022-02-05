using System.Text.Json.Serialization;

namespace Creed.Podcast.WebApi.Models
{
    public class PodcastDTO
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public string? Image { get; set; }
        public string? Thumbnail { get; set; }
        [JsonPropertyName("listennotes_url")]
        public string? ListennotesUrl { get; set; }
        [JsonPropertyName("total_episodes")]
        public int? TotalEpisodes { get; set; }
        public string? Description { get; set; }
        [JsonPropertyName("itunes_id")]
        public int? ItunesId { get; set; }
        public string? Rss { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? Website { get; set; }
        [JsonPropertyName("is_claimed")]
        public bool? IsClaimed { get; set; }        
        public string? Type { get; set; }
        [JsonPropertyName("genre_ids")]
        public List<int>? GenreIds { get; set; } = null;
    }
}
