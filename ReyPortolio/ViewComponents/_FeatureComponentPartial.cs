using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;


namespace ReyPortfolio.ViewComponents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.Features.FirstOrDefault();
            return View(values);
        }
    }
}
