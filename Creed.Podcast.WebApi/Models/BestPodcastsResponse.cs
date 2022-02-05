using System.Text.Json.Serialization;

namespace Creed.Podcast.WebApi.Models
{
    public class BestPodcastsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PodcastDTO> Podcasts { get; set; }
        public int Total { get; set; }
        [JsonPropertyName("has_next")]
        public bool HasNext { get; set; }
        [JsonPropertyName("has_previous")]
        public bool HasPrevious { get; set; }
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }
        [JsonPropertyName("previous_page_number")]
        public int PreviousPageNumber { get; set; }
        [JsonPropertyName("next_page_number")]
        public int NextPageNumber { get; set; }
        [JsonPropertyName("listennotes_url")]
        public string ListenerNotesUrl => $"https://www.listennotes.com/{Name.Replace(" ","-").ToLower()}-{Id}/";
    }
}
