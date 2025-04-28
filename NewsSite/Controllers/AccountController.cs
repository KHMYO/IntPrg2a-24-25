using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(StaffLoginViewModel data) {

            try
            {
                data.ReturnUrl = "";
                if (ModelState.IsValid)
                {
                    if (data.Username == "admin" && data.Password == "123456")
                    {
                        // Cookie oluşturma
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, data.Username),
                            //new Claim(ClaimTypes.Role, "Admin")
                            new Claim("Id","10")
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



    }
}
