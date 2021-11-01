using Newtonsoft.Json;

namespace FyndApiTask.Model
{
    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("numericFloat")]
        public double NumericFloat { get; set; }

        [JsonProperty("numericInteger")]
        public long NumericInteger { get; set; }
    }
}
