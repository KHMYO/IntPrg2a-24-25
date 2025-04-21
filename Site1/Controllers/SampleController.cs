using Microsoft.AspNetCore.Mvc;

namespace Site1.Controllers
{
    public class SampleController : Controller
    {
        //bir action örneği
        public IActionResult Index()
        {


            //.............

            return View();

        }

        public IActionResult Deneme()
        {
            return View();
        }


        public IActionResult Kobay()
        {

            var sayi = new Random().Next(1, 20);
            if (sayi % 2 == 0)
            {
                return View("EvenNumber");
            }
            else
            {
                return View("OddNumber");
            }


        }


    }
}
