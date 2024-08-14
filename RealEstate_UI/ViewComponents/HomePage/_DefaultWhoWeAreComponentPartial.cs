using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.ServiceDtos;
using RealEstate_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44394/api/WhoWeAreDetails");
            var responseMessage2 = await client2.GetAsync("https://localhost:44394/api/Services");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

                ViewBag.Title = value!.Select(x=>x.title).FirstOrDefault();
                ViewBag.Subtitle = value!.Select(x => x.subtitle).FirstOrDefault();
                ViewBag.Description1 = value!.Select(x => x.description1).FirstOrDefault();
                ViewBag.Description2 = value!.Select(x => x.description2).FirstOrDefault();
                return View(value2);
            }
            return View();
        }
    }
}
