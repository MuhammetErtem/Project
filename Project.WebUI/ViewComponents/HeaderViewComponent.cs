using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        SqlRepo<Category> repoCategory;
        public HeaderViewComponent(SqlRepo<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }
        public IViewComponentResult Invoke()
        {
            return View(repoCategory.GetAll());
        }
    }
}
