using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using X.PagedList;

namespace Project.WebUI.Controllers
{
    public class ProductController : Controller
    {
        SqlRepo<Product> repoProduct;
        SqlRepo<Category> repoCategory;
        SqlRepo<Brand> repoBrand;
        public ProductController(SqlRepo<Product> _repoProduct, SqlRepo<Brand> _repoBrand, SqlRepo<Category> _repoCategory)
        {
            repoProduct = _repoProduct;
            repoCategory = _repoCategory;
            repoBrand = _repoBrand;
        }
        public IActionResult Index(int? page)
        {
            ProductVM productVM = new ProductVM
            {
                CategoryList = repoCategory.GetAll(),
                BrandList = repoBrand.GetAll(),
                ListProduct = repoProduct.GetAll().Include(i => i.ProductPictures).Where(p => p.Enabled).OrderByDescending(o => o.ID).ToPagedList(page ?? 1, 5),
            };
            return View(productVM);

        }

        [Route("/urun/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            Product product = repoProduct.GetAll().Include(i => i.ProductPictures).Where(p => p.Enabled).FirstOrDefault(x => x.ID == id) ?? null;
            if (product != null)
            {
                ProductVM productVM = new ProductVM
                {
                    Product = product,
                    SimilarProducts = repoProduct.GetAll().Include(i => i.ProductPictures).Where(w => w.BrandID == product.BrandID && w.ID != product.ID).Where(p => p.Enabled).Take(4)
                };
                return View(productVM);
            }
            else return Redirect("/");
        }
    }
}