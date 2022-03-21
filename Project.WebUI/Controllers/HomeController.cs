using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Project.WebUI.Controllers
{
    public class HomeController : Controller
    {
        SqlRepo<Slider> repoSlider;
        SqlRepo<Product> repoProduct;
        public HomeController(SqlRepo<Slider> _repoSlider, SqlRepo<Product> _repoProduct)
        {
            repoSlider = _repoSlider;
            repoProduct = _repoProduct;
        }
        public IActionResult Index()
        {
            IndexVM indexVM = new IndexVM
            {
                Slider = repoSlider.GetAll(),
                LatestProducts = repoProduct.GetAll().Include(i => i.ProductPictures).OrderByDescending(o => o.ID).Take(8),
                BestSellerProducts = repoProduct.GetAll().Include(i => i.ProductPictures).OrderBy(o => Guid.NewGuid()).Take(8)
            };
            return View(indexVM);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
