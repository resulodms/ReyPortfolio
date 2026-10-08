using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioContext context= new MyPortfolioContext();
        public IActionResult Inbox()
        {
            var values = context.Messages.OrderByDescending(x => x.SendDate).ToList();

            return View(values);
        }

        public IActionResult ChangeIsReadTrue(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead=true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public IActionResult ChangeIsReadFalse(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = context.Messages.Find(id);
            context.Messages.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            if (value.IsRead == false)
            {
                value.IsRead = true;
                context.SaveChanges();
            }
            return View(value);
        }







    }
}
