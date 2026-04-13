using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.ProductDtos;
using RealEstate_UI.Services;

namespace RealEstate_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService = null)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44394/api/Products/ProductAdvertListByEmployee?id="+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData); //listeleme işlemi için deserialize kullanılır
                return View(values);
            }

            return View();
        }
    }
}
