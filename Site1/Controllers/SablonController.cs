using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Site1.Controllers
{
    public class SablonController : Controller
    {
        public IActionResult Page1()
        {
            var rsayi = new Random().Next(20, 60);

            ViewData["sayi"] = rsayi;

            Console.Out.WriteLine("Üretilen sayı : " + rsayi);

            ViewBag.Title = "SAYFA BAŞLIĞI";


            return View();
        }
        public IActionResult Page2()
        {
            return View();
        }
    }
}
