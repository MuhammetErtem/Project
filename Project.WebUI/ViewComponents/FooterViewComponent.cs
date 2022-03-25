using Project.BL.Repositories;
using Project.DAL.DbContexts;
using Project.DAL.Entities;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Project.WebUI.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        SqlRepo<Brand> repoBrand;
        SqlRepo<Category> repoCategory;
        public FooterViewComponent(SqlRepo<Brand> _repoBrand, SqlRepo<Category> _repoCategory)
        {
            repoBrand = _repoBrand;
            repoCategory = _repoCategory;
        }
        public IViewComponentResult Invoke()
        {
            FooterVM footerVM = new FooterVM
            {
                Brands = repoBrand.GetAll(),
                Categories = repoCategory.GetAll()
            };
            return View(footerVM);
        }
    }
}
