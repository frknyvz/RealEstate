using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI.Dtos.MessageDtos;
using RealEstate_UI.Services;

namespace RealEstate_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponents
{
    public class _NavbarLast3MessageComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private string GetTimeAgo(DateTime date)
        {
            var span = DateTime.Now - date;

            if (span.TotalMinutes < 1)
                return "az önce";
            if (span.TotalMinutes < 60)
                return $"{(int)span.TotalMinutes} dakika önce";
            if (span.TotalHours < 24)
                return $"{(int)span.TotalHours} saat önce";
            if (span.TotalDays < 30)
                return $"{(int)span.TotalDays} gün önce";

            return date.ToString("dd.MM.yyyy");
        }

        public _NavbarLast3MessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService = null)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44394/api/Messages?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData); //listeleme işlemi için deserialize kullanılır
                
                foreach(var item in values)
                {
                    item.TimeAgo = GetTimeAgo(item.SendDate);
                }
                
                return View(values);
            }

            return View();
        }
    }
}
