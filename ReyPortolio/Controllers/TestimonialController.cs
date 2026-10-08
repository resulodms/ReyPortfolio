using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;
using ReyPortfolio.DAL.Entities;

namespace ReyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial Testimonial, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "testimonial");
                var fullPath = Path.Combine(folder, newFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                Testimonial.ImageUrl = "/images/testimonial/" + newFileName;
            }

            _context.Testimonials.Add(Testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");

        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial Testimonial, IFormFile? imageFile)
        {
            // 1. Yeni dosya seçildiyse kaydet
            if (imageFile != null && imageFile.Length > 0)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "testimonial");
                var fullPath = Path.Combine(folder, newFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                Testimonial.ImageUrl = "/images/testimonial/" + newFileName;
            }

            // 2. Hâlâ boşsa mevcut görseli koru
            if (string.IsNullOrEmpty(Testimonial.ImageUrl))
            {
                Testimonial.ImageUrl = _context.Testimonials
                    .Where(x => x.TestimonialId == Testimonial.TestimonialId)
                    .Select(x => x.ImageUrl)
                    .FirstOrDefault();
            }
            _context.Testimonials.Update(Testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");

        }
    }
}
