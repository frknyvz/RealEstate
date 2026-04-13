using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace RealEstate_API.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCategoryCount()
        {

            #region Proccess1
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44394/api/Statistics/CategoryCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount",jsonData1);
            #endregion
        }
    }
}
