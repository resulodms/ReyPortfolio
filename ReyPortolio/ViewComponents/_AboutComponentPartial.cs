using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.ViewComponents
{
    
    public class _AboutComponentPartial:ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = _context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription = _context.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail = _context.Abouts.Select(x => x.Details).FirstOrDefault();
            ViewBag.hasCv = System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "cv.pdf"));
            return View();
        }
    }
}
