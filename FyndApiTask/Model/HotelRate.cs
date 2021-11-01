using Newtonsoft.Json;
using System;

namespace FyndApiTask.Model
{
    public class HotelRate
    {
        [JsonProperty("adults")]
        public long Adults { get; set; }

        [JsonProperty("los")]
        public long Los { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("rateDescription")]
        public string RateDescription { get; set; }

        [JsonProperty("rateID")]
        public long RateId { get; set; }

        [JsonProperty("rateName")]
        public string RateName { get; set; }

        [JsonProperty("rateTags")]
        public RateTag[] RateTags { get; set; }

        [JsonProperty("targetDay")]
        public DateTime TargetDay { get; set; }
    }

}
