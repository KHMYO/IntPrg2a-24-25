using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSite.Models;

namespace NewsSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyContext context;

        public CategoryController()
        {
            context = new MyContext();
        }

        public IActionResult ShowCategoryNews(int id)
        {
            // Burada id'ye göre haberleri filtreleyip listeleyeceğiz


            var newsList = context.News
                .Include(n => n.Staff)
                .Where(n => n.CategoryId == id)
                .ToList();



            return View(newsList);
        }


        public IActionResult Deneme(int id)
        {
            return View(id);
        }





    }
}
