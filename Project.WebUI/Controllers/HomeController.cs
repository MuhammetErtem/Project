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
        SqlRepo<Blog> repoBlog;
        SqlRepo<AnimalPicture> repoAnimalPicture;

        public HomeController(SqlRepo<Slider> _repoSlider, 
                              SqlRepo<Product> _repoProduct,
                              SqlRepo<Blog> _repoBlog,
                              SqlRepo<AnimalPicture> _repoAnimalPicture)
        {
            repoSlider = _repoSlider;
            repoProduct = _repoProduct;
            repoBlog = _repoBlog;
            repoAnimalPicture = _repoAnimalPicture;
        }
        public IActionResult Index(int id)
        {
            IndexVM indexVM = new IndexVM
            {
                Slider = repoSlider.GetAll(),
                LatestProducts = repoProduct.GetAll().Include(i => i.ProductPictures).OrderByDescending(o => o.ID).Where(o => o.Enabled).Take(8),
                BestSellerProducts = repoProduct.GetAll().Include(i => i.ProductPictures).OrderBy(o => Guid.NewGuid()).Where(o => o.Enabled).Take(1),
                Blogs = repoBlog.GetAll().OrderByDescending(o => o.ID).Where(o => o.Enabled).Take(3),
                AnimalPictures = repoAnimalPicture.GetAll().OrderBy(o => Guid.NewGuid()).Take(6),
            };
            return View(indexVM);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
