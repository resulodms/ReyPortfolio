using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.ViewComponents
{
    public class _PortfolioComponentPartial:ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();

        public IViewComponentResult Invoke()
        {
            var values = _context.Portfolios.ToList();

            return View(values);
        }
    }
}
