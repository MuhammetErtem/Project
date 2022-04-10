using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ProductController : Controller
    {
        SqlRepo<Product> repoProduct;
        SqlRepo<Brand> repoBrand;
        SqlRepo<SubCategory> repoSubCategory;
        public ProductController(SqlRepo<Product> _repoProduct, SqlRepo<Brand> _repoBrand, SqlRepo<SubCategory> _repoSubCategory)
        {
            repoProduct = _repoProduct;
            repoSubCategory = _repoSubCategory;
            repoBrand = _repoBrand;
        }

        public IActionResult Index()
        {
            return View(repoProduct.GetAll().Include(p => p.Brand).ToList().OrderByDescending(o=>o.ID));
        }

        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                Brands = repoBrand.GetAll(),
                SubCategories = repoSubCategory.GetAll()
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {

                repoProduct.Add(model.Product);

            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ProductVM productVM = new ProductVM
            {
                Product = repoProduct.GetBy(x => x.ID == id),
                Brands = repoBrand.GetAll()
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Update(ProductVM model)
        {
            if (ModelState.IsValid) repoProduct.Update(model.Product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoProduct.Remove(repoProduct.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
