using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class HomeController : Controller
    {
        SqlRepo<Admin> repoAdmin;
        public HomeController(SqlRepo<Admin> _repoAdmin)
        {
            repoAdmin = _repoAdmin;
        }

        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/giris"),AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("/admin/giris"), AllowAnonymous,HttpPost]
        public async Task<IActionResult> Login(string mailaddress,string password,string ReturnUrl)
        {
            Admin admin = repoAdmin.GetBy(g => g.MailAddress == mailaddress && GeneralTool.getMD5(password) == g.Password) ?? null;
            if (admin != null)
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity("Project");
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name,admin.NameSurname));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email,admin.MailAddress));
                //claimsIdentity.AddClaim(new Claim("Iskonto",admin.x));

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
                claimsPrincipal.AddIdentity(claimsIdentity);


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = true });

                if (string.IsNullOrEmpty(ReturnUrl)) return Redirect("/admin");
                else return Redirect(ReturnUrl);

            }
            else ViewBag.mesaj = "Geçersiz mail adresi veya şifre..";
            return View();
        }

        [Route("/admin/cikis")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
