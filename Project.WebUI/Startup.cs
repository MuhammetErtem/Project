using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.BL.Repositories;
using Project.DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebUI
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services) //Projelerimizde kullanacaðýmýz servisleri eklediðimiz alandýr.
        {
            services.AddControllersWithViews(); //Mvc'nin iskeletini eklemiþ olduk. Ýlk eklenecek servislerdendir.
            services.AddDbContext<SqlContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Project1")));

            services.AddScoped(typeof(SqlRepo<>));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {

                opt.ExpireTimeSpan = TimeSpan.FromHours(5);
                opt.LoginPath = "/admin/giris";
                opt.LogoutPath = "/";

            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //Bir isteðin cevaba dönüþme hattýdýr.Pipeline(Boru Hattý) ismi verilir. Sýralamasý önemlidir.
        {
            if (env.IsDevelopment()) // Sayfalarýn hatalarýyla ilgilidir.Geliþtirme ortamýndaysa bunu göster.
            { //env Çalýþma ortamý demektir.

                app.UseDeveloperExceptionPage(); // Geliþtirici istisna sayfasýný kullan 

            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/hata/{0}"); // Canlýdaysa bunu göster. 
                //Durum Kodu Sayfalarýný Kullan
            }
            app.UseStaticFiles();

            app.UseRouting(); //Kendi özel yönlendirmemizdir.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }

}
