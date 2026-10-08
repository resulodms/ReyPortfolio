using Microsoft.AspNetCore.Mvc;

namespace ReyPortfolio.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
