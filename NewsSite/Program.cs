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

            // e�er tek bit tane route kulan�lacaksa bu �ekilde yaz�lmaLI
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
           
            // E�ER UYGULAMADA B�RDEN �OK ROUTE KULANILACAKSA B�YLE YAZILMALIDIR
            app.UseEndpoints(endspoints => {

                endspoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Staff}/{action=index}/{id?}");

                endspoints.MapControllerRoute(
                    name: "contact",
                    pattern: "iletisim",
                    defaults: new {controller = "Home", action ="contact"});

                endspoints.MapControllerRoute(
                    name:"tekhaber",
                    pattern:"haber/{title}/{no}",
                    defaults: new {controller = "News",action="OneNews"});

                    
            
            
            });
            



            app.Run();
        }
    }
}
