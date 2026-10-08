using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.ViewComponents
{
    public class _StatisticComponentPartial:ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {

            ViewBag.expcount = _context.Experiences.Count();
            ViewBag.skillCount = _context.Skills.Count();
            ViewBag.portfolioCount = _context.Portfolios.Count();
            ViewBag.testimonialCount = _context.Testimonials.Count();
            return View();
        }
    }
}
