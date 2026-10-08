using Microsoft.AspNetCore.Mvc;

namespace ReyPortfolio.ViewComponents.LayoutViewComponents
{
    public class _LayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
