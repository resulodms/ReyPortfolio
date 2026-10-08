using Microsoft.AspNetCore.Mvc;
using ReyPortfolio.DAL.Context;

namespace ReyPortfolio.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial:ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.toDoListCount = context.ToDoLists.Where(x=>x.Status==false).Count();

            var value = context.ToDoLists.Where(x=>x.Status==false).ToList();
            return View(value);
        }
    }
}
