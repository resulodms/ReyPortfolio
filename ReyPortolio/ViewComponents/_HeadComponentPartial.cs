using Microsoft.AspNetCore.Mvc;

namespace ReyPortfolio.ViewComponents
{
    public class _HeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
