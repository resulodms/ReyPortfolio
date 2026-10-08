using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;
using ReyPortfolio.DAL.Entities;

namespace ReyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();

        [HttpGet]
        public IActionResult Index()
        {
            var value = _context.Contacts.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Contact Contact)
        {
            _context.Contacts.Update(Contact);
            _context.SaveChanges();
            TempData["Mesaj"] = "Bilgiler başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
