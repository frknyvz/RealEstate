using Microsoft.AspNetCore.Mvc;
using RealEstate_UI.Services;

namespace RealEstate_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;

            #region St1 - Toplam İlan Sayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44394/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            #endregion

            #region St2 - Yayınladığım İlan Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44394/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeId = jsonData2;
            #endregion

            #region St3 - Aktif İlanlarım
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44394/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=" + id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusTrue = jsonData3;
            #endregion

            #region St4 - Pasif İlanlarım
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44394/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=" + id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusFalse = jsonData4;
            #endregion

            return View();
        }
    }
}
