using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project.WebUI.Controllers
{
    public class HomeController : Controller
    {
        SqlRepo<Slider> repoSlider;
        SqlRepo<Product> repoProduct;
        SqlRepo<Blog> repoBlog;
        SqlRepo<AnimalPicture> repoAnimalPicture;
        SqlRepo<SubCategory> repoSubCategory;

        public HomeController(SqlRepo<Slider> _repoSlider,
                              SqlRepo<Product> _repoProduct,
                              SqlRepo<Blog> _repoBlog,
                              SqlRepo<AnimalPicture> _repoAnimalPicture,
                              SqlRepo<SubCategory> _repoSubCategory)
        {
            repoSlider = _repoSlider;
            repoProduct = _repoProduct;
            repoBlog = _repoBlog;
            repoAnimalPicture = _repoAnimalPicture;
            repoSubCategory = _repoSubCategory;
        }
        public IActionResult Index(int id)
        {
            IndexVM indexVM = new IndexVM
            {
                Slider = repoSlider.GetAll().OrderBy(o => o.DisplayIndex).Where(o => o.Enabled),
                LatestProducts = repoProduct.GetAll().Include(i => i.ProductPictures).OrderByDescending(o => o.ID).Where(o => o.Enabled).Take(8),
                BestSellerProducts = repoProduct.GetAll().Include(i => i.ProductPictures).OrderByDescending(o => o.Stock < 10).Where(o => o.Enabled).Take(1),
                Blogs = repoBlog.GetAll().OrderByDescending(o => o.ID).Where(o => o.Enabled).Take(3),
                AnimalPictures = repoAnimalPicture.GetAll().OrderBy(o => Guid.NewGuid()).Take(6),
            };
            return View(indexVM);
        }

        public IActionResult Test()
        {
            return View();
        }
        public async Task<IActionResult> SubCategory(int id)
        {
            SubCategory model = await repoSubCategory.GetAll().Include(p => p.Category).Include(p => p.Products).ThenInclude(i => i.ProductPictures).SingleOrDefaultAsync(p => p.ID == id && p.Enabled);
            return View(model);
        }
        public async Task<IActionResult> Search(string keyword)
        {
            var keywords = Regex.Split(keyword, @"\s+").ToList();
            var model = repoProduct.GetAll().Include(i => i.ProductPictures).Include(p => p.Brand).Include(p => p.SubCategory).AsEnumerable().Where(p => keywords.Any(q => p.Name.ToLower().Contains(q.ToLower()))).ToList();
            return View(model);
        }
    }
}
