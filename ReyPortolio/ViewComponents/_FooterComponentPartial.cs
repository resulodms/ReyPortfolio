using Microsoft.AspNetCore.Mvc;

namespace ReyPortfolio.ViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
