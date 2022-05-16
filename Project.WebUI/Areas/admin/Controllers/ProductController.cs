using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ProductController : Controller
    {
        SqlRepo<Product> repoProduct;
        SqlRepo<ProductPicture> repoProductPicture;
        SqlRepo<Brand> repoBrand;
        SqlRepo<SubCategory> repoSubCategory;
        public ProductController(SqlRepo<Product> _repoProduct, SqlRepo<Brand> _repoBrand, SqlRepo<SubCategory> _repoSubCategory, SqlRepo<ProductPicture> _repoProductPicture)
        {
            repoProduct = _repoProduct;
            repoSubCategory = _repoSubCategory;
            repoBrand = _repoBrand;
            repoProductPicture = _repoProductPicture;
        }

        public IActionResult Index(int? page)
        {
            return View(repoProduct.GetAll().Include(p => p.Brand).ToPagedList(page ?? 1, 10));
        }

        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM
            {
                Product = new Product { Enabled = true },
                ProductPicture = new ProductPicture(),
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
                var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "product");
                if (Request.Form.Files.Any())
                {
                    string productPath = dosyaYolu;
                    if (!Directory.Exists(productPath)) Directory.CreateDirectory(productPath);
                    using (var dosyaAkisi = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "product", Request.Form.Files["ProductPicture.Path"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["ProductPicture.Path"].CopyTo(dosyaAkisi);
                    }
                    model.ProductPicture.Path = "/img/product/" + Request.Form.Files["ProductPicture.Path"].FileName;
                }
                repoProduct.Add(model.Product);

                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Update(int id)
        {
            ProductVM productVM = new ProductVM
            {
                Product = repoProduct.GetBy(x => x.ID == id),
                Brands = repoBrand.GetAll(),
                SubCategories = repoSubCategory.GetAll()

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
