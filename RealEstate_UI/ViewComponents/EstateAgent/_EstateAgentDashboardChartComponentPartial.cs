using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate_UI.Dtos.EstateAgentDtos;

namespace RealEstate_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardChartComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44394/api/EstateAgentChart");

            //var client2 = _httpClientFactory.CreateClient();
            //var responseMessage2 = await client2.GetAsync("https://localhost:44394/api/EstateAgentChart/GetAvgPriceForSaleChart");

            if (responseMessage.IsSuccessStatusCode /*&& responseMessage2.IsSuccessStatusCode*/)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDto>>(jsonData);
                //var values2 = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDto2>>(jsonData2);

                return View(values);
            }
            return View();
        }
    }
}
