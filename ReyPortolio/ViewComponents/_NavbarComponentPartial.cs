using Microsoft.AspNetCore.Mvc;

namespace ReyPortfolio.ViewComponents
{
    public class _NavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
