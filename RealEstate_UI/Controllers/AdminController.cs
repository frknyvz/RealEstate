using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
