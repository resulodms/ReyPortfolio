using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Entities;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.Contacts.FirstOrDefault();
            return View(values);
        }
    }
}
