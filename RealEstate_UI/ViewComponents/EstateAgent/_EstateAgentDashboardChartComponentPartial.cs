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

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDto>>(jsonData);

                return View(values ?? new List<ResultEstateAgentDashboardChartDto>());
            }

            return View(new List<ResultEstateAgentDashboardChartDto>());
        }
    }
}
