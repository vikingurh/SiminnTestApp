using Newtonsoft.Json;
using SiminnTestApp.Data;

namespace SiminnTestApp.Services
{
    public class StockPriceService
    {
        public async Task<StockPrice> GetStockPricesAsync(string? ticker)
        {
            if (string.IsNullOrWhiteSpace(ticker))
            {
                return new StockPrice();
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri("https://localhost:7045/stockprices/?ticker=" + ticker) };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonConvert.DeserializeObject<StockPrice>(body);
                    if (result != null)
                    {
                        return result;
                    }
                    return new StockPrice();
                }
                catch (Exception e)
                {
                    //Log the error
                    return new StockPrice();
                }
            }
        }
    }
}