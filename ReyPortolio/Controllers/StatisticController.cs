using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = _context.Skills.Count();
            ViewBag.v2 = _context.Messages.Count();
            ViewBag.v3 = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = _context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.portfolioCount = _context.Portfolios.Count();
            ViewBag.experienceCount = _context.Experiences.Count();
            ViewBag.testimonialCount = _context.Testimonials.Count();
            ViewBag.socialMediaCount = _context.SocialMedias.Count();
            ViewBag.todoDone = _context.ToDoLists.Where(x=>x.Status==true).Count();
            ViewBag.todoWaiting = _context.ToDoLists.Where(x=>x.Status==false).Count();
            ViewBag.skillAverage = _context.Skills.Any() ? Math.Round(_context.Skills.Average(x => x.Value)) : 0;
            ViewBag.lastSender = _context.Messages.OrderByDescending(x=>x.SendDate).Select(x=>x.NameSurname).FirstOrDefault();

            return View();
        }
    }
}
