using Microsoft.AspNetCore.Authentication.Cookies;
using System.Formats.Tar;

namespace NewsSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(
                                opt =>
                                {
                                    opt.LoginPath = "/Account/Login";
                                    opt.LogoutPath = "/Account/Logout";
                                    opt.AccessDeniedPath = "/Account/AccessDenied";
                                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                                    opt.SlidingExpiration = true;
                                    opt.Cookie.Name = "SinginCookie";

                                }
                               );






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // eðer tek bit tane route kulanýlacaksa bu þekilde yazýlmaLI
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            // EÐER UYGULAMADA BÝRDEN ÇOK ROUTE KULANILACAKSA BÖYLE YAZILMALIDIR
            app.UseEndpoints(endspoints =>
            {

                endspoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");

                endspoints.MapControllerRoute(
                    name: "contact",
                    pattern: "iletisim",
                    defaults: new { controller = "Home", action = "contact" });

                endspoints.MapControllerRoute(
                    name: "tekhaber",
                    pattern: "haber/{title}/{no}",
                    defaults: new { controller = "News", action = "OneNews" });




            });




            app.Run();
        }
    }
}
