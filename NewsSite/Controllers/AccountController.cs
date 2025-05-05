using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using NewsSite.Models.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyContext context;

        public AccountController()
        {
            context = new MyContext();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(StaffLoginViewModel data)
        {

            try
            {
                data.ReturnUrl = "";
                if (ModelState.IsValid)
                {

                    var users= context.Staff.ToList();  
                    var properUser= users.FirstOrDefault(x => x.UserName == data.Username && x.Password == data.Password);

                    if ( properUser is not null /*data.Username == "admin" && data.Password == "123456"*/)
                    {
                        // Cookie oluşturma
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, data.Username),
                            //new Claim(ClaimTypes.Role, "Admin")
                            new Claim("Id",properUser.Id.ToString()),
                            new Claim("Fullname", properUser.Name),
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }



            return View(data);

        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }




    }
}
