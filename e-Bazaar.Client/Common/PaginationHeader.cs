using System.Text.Json.Serialization;

namespace e_Bazaar.Client.Common
{
    public class PaginationHeader
    {
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }
        [JsonPropertyName("totalItems")] 
        public int TotalItems { get; set; }
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }
    }
}
