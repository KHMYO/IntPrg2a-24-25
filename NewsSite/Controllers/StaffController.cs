using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;

namespace NewsSite.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            MyContext db = new MyContext();
            var Calisanlar = db.Staff.ToList();
            ViewBag.Liste = Calisanlar;
            return View();
        }
        public IActionResult Index2()
        {
            MyContext db = new MyContext();
            var calisanlar = db.Staff.ToList();
            return View(calisanlar); //Çalışanlar değişkeni görünüme model olarak gönderildi.
        }
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(Staff data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Model bilgisi hatalı!");
                }
                MyContext db = new MyContext();
                db.Staff.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View(data);
            }
            
        }
    }
}
