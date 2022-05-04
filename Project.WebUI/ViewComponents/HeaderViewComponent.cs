using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Project.WebUI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project.WebUI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        SqlRepo<Category> repoCategory;
        SqlRepo<SubCategory> repoSubCategory;
        public HeaderViewComponent(SqlRepo<Category> _repoCategory, SqlRepo<SubCategory> _repoSubCategory)
        {
            repoCategory = _repoCategory;
            repoSubCategory = _repoSubCategory;
        }
        public IViewComponentResult Invoke(int id)
        {
            HeaderVM headerVM = new HeaderVM
            {
                Categories = repoCategory.GetAll().Include(i => i.SubCategories).ToList(),
                SubCategories = repoSubCategory.GetAll().Include(i => i.Products)

            };
            return View(headerVM);
        }
    }
}
