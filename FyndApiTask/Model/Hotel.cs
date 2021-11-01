using Newtonsoft.Json;

namespace FyndApiTask.Model
{
    public class Hotel
    {
        [JsonProperty("classification")]
        public long Classification { get; set; }

        [JsonProperty("hotelID")]
        public long HotelId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reviewscore")]
        public double Reviewscore { get; set; }
    }
}
