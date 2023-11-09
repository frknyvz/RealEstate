using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.Layout
{
    public class _ScriptsViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
