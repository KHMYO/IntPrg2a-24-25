using Microsoft.AspNetCore.Mvc;

namespace NewsSite.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }


        public IActionResult OneNews(string title,int no)
        {
            ViewBag.Title = title;
            ViewBag.No = no;
            return View();
        }

    }
}
