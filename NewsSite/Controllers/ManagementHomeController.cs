using Microsoft.AspNetCore.Mvc;

namespace NewsSite.Controllers
{
    public class ManagementHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
