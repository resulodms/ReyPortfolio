using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;
using ReyPortfolio.DAL.Entities;

namespace ReyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext _context= new MyPortfolioContext();

        [HttpGet]
        public IActionResult Index()
        {
            var value = _context.Abouts.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(About about, IFormFile? cvFile)
        {
            if (cvFile != null && cvFile.Length > 0 && Path.GetExtension(cvFile.FileName).ToLower() == ".pdf")
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "cv.pdf");

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    cvFile.CopyTo(stream);
                }
            }

            _context.Abouts.Update(about);
            _context.SaveChanges();
            TempData["Mesaj"] = "Bilgiler başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
