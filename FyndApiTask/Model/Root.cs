using Newtonsoft.Json;
using System.Collections.Generic;

namespace FyndApiTask.Model
{
    public class Root
    {
        [JsonProperty("hotel")]
        public Hotel Hotel { get; set; }

        [JsonProperty("hotelRates")]
        public List<HotelRate> HotelRates { get; set; }
    }
}
