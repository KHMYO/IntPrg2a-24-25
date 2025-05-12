using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;

namespace NewsSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext context;   

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        context = new MyContext();
    }

    public IActionResult Index()
    {

        var allCategories = context.Categories.ToList();   
        allCategories=allCategories.Where(x=>x.IsActive==1 && x.Menu==1).ToList();

        ViewBag.MenuCategories = allCategories;




        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Deneme()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
