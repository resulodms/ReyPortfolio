using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;
using ReyPortfolio.DAL.Entities;

namespace ReyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult SocialMediaList()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia SocialMedia)
        {
            _context.SocialMedias.Add(SocialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            _context.SocialMedias.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia SocialMedia)
        {
            _context.SocialMedias.Update(SocialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }
    }
}
