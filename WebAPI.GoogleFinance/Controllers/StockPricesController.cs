using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.GoogleFinance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockPricesController : ControllerBase
    {
        private readonly ILogger<StockPricesController> _logger;

        public StockPricesController(ILogger<StockPricesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStockPrices")]
        public async Task<StockPrice> Get(string ticker)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://google-finance4.p.rapidapi.com/ticker/?t=" + ticker + "&hl=en&gl=US"),
                Headers =
                {
                    { "X-RapidAPI-Key", "8944f88786msh4447c939bdfea62p171d31jsn8ab7034785f3" },
                    { "X-RapidAPI-Host", "google-finance4.p.rapidapi.com" },
                },
            };
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
                catch(Exception e)
                {
                    _logger.LogError(e.Message);
                    return new StockPrice();
                }
            }
        }     
    }
}




