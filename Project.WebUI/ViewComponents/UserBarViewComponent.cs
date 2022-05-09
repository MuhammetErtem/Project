using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Project.BL.Repositories;
using Project.WebUI.ViewModels;
using Project.DAL.Entities;

namespace Project.WebUI.ViewComponents
{
    public class UserBarViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public UserBarViewComponent(
            UserManager<User> userManager
            )
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            User model = null;

            if (User.Identity.IsAuthenticated)
                model = userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(model);

        }
    }
}
