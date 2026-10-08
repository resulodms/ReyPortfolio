using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;
using ReyPortfolio.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ReyPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Content("OK");
        }


    }
}
