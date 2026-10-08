using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;
using ReyPortfolio.DAL.Entities;

namespace ReyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skill Skill)
        {
            _context.Skills.Add(Skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = _context.Skills.Find(id);
            _context.Skills.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SkillList");

        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill Skill)
        {
            _context.Skills.Update(Skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");

        }
    }
}
