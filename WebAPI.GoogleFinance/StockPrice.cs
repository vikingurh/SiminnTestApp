using Newtonsoft.Json;

namespace WebAPI.GoogleFinance
{
    public class StockPrice
    {
        public Info? info { get; set; }
        public Charts? charts { get; set; }
        public Stats? stats { get; set; }
    }

    public class Info
    {
        public string? type { get; set; }
        public string? title { get; set; }
        public string? ticker { get; set; }
        public List<string>? ticker_symbols { get; set; }
        public string? country_code { get; set; }
    }

    public class Charts
    {
        [JsonProperty("1day")]
        public List<Day>? days { get; set; }

        [JsonProperty("1month")]
        public List<Month>? months { get; set; }
    }

    public class Stats
    {
        public string? currency { get; set; }
    }

    public class Day
    {
        public string? date { get; set; }
        public double price { get; set; }
    }

    public class Month
    {
        public string? date { get; set; }
        public double price { get; set; }
    }
}