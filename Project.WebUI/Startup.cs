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
        public void ConfigureServices(IServiceCollection services) //Projelerimizde kullanaca��m�z servisleri ekledi�imiz aland�r.
        {
            services.AddControllersWithViews(); //Mvc'nin iskeletini eklemi� olduk. �lk eklenecek servislerdendir.
            services.AddDbContext<SqlContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Project1")));

            services.AddScoped(typeof(SqlRepo<>));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {

                opt.ExpireTimeSpan = TimeSpan.FromHours(5);
                opt.LoginPath = "/admin/giris";
                opt.LogoutPath = "/";

            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //Bir iste�in cevaba d�n��me hatt�d�r.Pipeline(Boru Hatt�) ismi verilir. S�ralamas� �nemlidir.
        {
            if (env.IsDevelopment()) // Sayfalar�n hatalar�yla ilgilidir.Geli�tirme ortam�ndaysa bunu g�ster.
            { //env �al��ma ortam� demektir.

                app.UseDeveloperExceptionPage(); // Geli�tirici istisna sayfas�n� kullan 

            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/hata/{0}"); // Canl�daysa bunu g�ster. 
                //Durum Kodu Sayfalar�n� Kullan
            }
            app.UseStaticFiles();

            app.UseRouting(); //Kendi �zel y�nlendirmemizdir.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }

}
