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
        public IActionResult Index()
        {

            return View();
        }

        [Route("/urun/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            Product product = repoProduct.GetAll().Include(i => i.ProductPictures).FirstOrDefault(x => x.ID == id) ?? null;
            if (product != null)
            {
                ProductVM productVM = new ProductVM
                {
                    Product = product,
                    SimilarProducts = repoProduct.GetAll().Include(i => i.ProductPictures).Where(w => w.BrandID == product.BrandID && w.ID != product.ID).Take(4)
                };
                return View(productVM);
            }
            else return Redirect("/");
        }
    }
}