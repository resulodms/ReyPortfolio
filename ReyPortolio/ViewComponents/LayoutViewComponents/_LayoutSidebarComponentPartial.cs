using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Entities;
using ReyPortfolio.DAL.Context;
namespace ReyPortfolio.ViewComponents.LayoutViewComponents
{
    public class _LayoutSidebarComponentPartial: ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.portfolioCount = _context.Portfolios.Count();
            ViewBag.unreadMessageCount = _context.Messages.Where(x => x.IsRead == false).Count();
            return View();
        }
    }
}
