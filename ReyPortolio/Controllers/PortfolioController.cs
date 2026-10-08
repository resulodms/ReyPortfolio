using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;
using ReyPortfolio.DAL.Entities;

namespace ReyPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult PortfolioList()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio Portfolio, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "portfolio");
                var fullPath = Path.Combine(folder, newFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                Portfolio.ImageUrl = "/images/portfolio/" + newFileName;
            }
            _context.Portfolios.Add(Portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            _context.Portfolios.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");

        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio, IFormFile? imageFile)
        {
            // 1. Yeni dosya seçildiyse kaydet
            if (imageFile != null && imageFile.Length > 0)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "portfolio");
                var fullPath = Path.Combine(folder, newFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                portfolio.ImageUrl = "/images/portfolio/" + newFileName;
            }

            // 2. Hâlâ boşsa mevcut görseli koru
            if (string.IsNullOrEmpty(portfolio.ImageUrl))
            {
                portfolio.ImageUrl = _context.Portfolios
                    .Where(x => x.PortfolioId == portfolio.PortfolioId)
                    .Select(x => x.ImageUrl)
                    .FirstOrDefault();
            }

            // 3. Güncelle
            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
