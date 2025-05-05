using Microsoft.AspNetCore.Mvc;

namespace NewsSite.Areas.Management.Controllers
{
    [Area("Management")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
