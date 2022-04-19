using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Project.WebUI.Controllers
{
    public class ProductController : Controller
    {
        SqlRepo<Product> repoProduct;
        public ProductController(SqlRepo<Product> _repoProduct)
        {
            repoProduct = _repoProduct;
        }
        public IActionResult Index(int id)
        {
            ProductVM productVM = new ProductVM
            {
                ListProduct = repoProduct.GetAll().Include(i => i.ProductPictures).Where(p => p.ID == id && p.Enabled).OrderByDescending(o => o.ID).Take(16),
        };
            return View(productVM);
    }

    [Route("/urun/{name}-{id}")]
    public IActionResult Detail(string name, int id)
    {
        Product product = repoProduct.GetAll().Include(i => i.ProductPictures).Where(p => p.ID == id && p.Enabled).FirstOrDefault(x => x.ID == id) ?? null;
        if (product != null)
        {
            ProductVM productVM = new ProductVM
            {
                Product = product,
                SimilarProducts = repoProduct.GetAll().Include(i => i.ProductPictures).Where(w => w.BrandID == product.BrandID && w.ID != product.ID).Where(p => p.ID == id && p.Enabled).Take(4)
            };
            return View(productVM);
        }
        else return Redirect("/");
    }
}
}