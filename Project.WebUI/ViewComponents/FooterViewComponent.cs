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
        public FooterViewComponent(SqlRepo<Brand> _repoBrand)
        {
            repoBrand = _repoBrand;
        }
        public IViewComponentResult Invoke()
        {
            FooterVM footerVM = new FooterVM
            {
                Brands = repoBrand.GetAll(),
            };
            return View(footerVM);
        }
    }
}
