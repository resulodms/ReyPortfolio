using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.ViewComponents
{
    public class _SocialMediaComponentPartial:ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();

        public IViewComponentResult Invoke()
        {
            var values = _context.SocialMedias.ToList();

            return View(values);
        }
    }
}
