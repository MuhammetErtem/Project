using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Models;
using Project.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.WebUI.Controllers
{
    public class CartController : Controller
    {
        SqlRepo<Product> repoProduct;
        SqlRepo<City> repoCity;
        SqlRepo<Distinct> repoDistinct;
        public CartController(SqlRepo<Product> _repoProduct, SqlRepo<City> _repoCity, SqlRepo<Distinct> _repoDistinct)
        {
            repoProduct = _repoProduct;
            repoCity = _repoCity;
            repoDistinct = _repoDistinct;
        }

        [Route("/sepetim")]
        public IActionResult Index()
        {
            if (Request.Cookies["SepetCookie"] != null)
            {
                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
                return View(carts);
            }
            else return Redirect("/");
        }

        [Route("/sepet/ekle")]
        public string AddCart(int productID, int quantity, int stock)
        {
            string result = "";
            List<Cart> carts;
            Product product = repoProduct.GetAll().Include(i => i.ProductPictures).First(x => x.ID == productID) ?? null;
            string picture = product.ProductPictures.First().Path;
            if (string.IsNullOrEmpty(picture)) picture = "/img/product/noproduct.jpg";
            Cart cart = new Cart
            {
                ID = product.ID,
                Name = product.Name,
                //Price = GeneralTool.GetCurrency(product.Price,product.Currency),
                Quantity = quantity,
                Picture = picture
            };
            if (Request.Cookies["SepetCookie"] == null)//sepet ile alakalı herhangi bir cookie yok yani ilk kez sepete ekleme işlemi
            {
                carts = new List<Cart>();
                carts.Add(cart);
            }
            else //daha önce sepete eklenen bir ürün var yani bir sepet cookie var
            {
                carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
                bool urunSepetteVarmi = false;
                foreach (Cart c in carts)
                {
                    if (c.ID == product.ID)//eğer ürün daha önce eklenen cookie de varsa miktarını artır
                    {
                        c.Quantity = quantity;
                        urunSepetteVarmi = true;
                    }
                }
                if (urunSepetteVarmi == false) carts.Add(cart);//eğer ürün daha önce eklenen cookie de yoksa cookideki listeye ekle
            }
            result = product.Name;
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Append("SepetCookie", JsonConvert.SerializeObject(carts), cookieOptions);
            return result;
        }

        [Route("/sepet/urunsayisiver")]
        public int GetCartCount()
        {
            int result = 0;
            if (Request.Cookies["SepetCookie"] != null)
            {
                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
                result = carts.Sum(c=>c.Quantity);
            }
            return result;
        }

        [Route("/sepetim/tamamla")]
        public IActionResult CheckOut()
        {
            if (Request.Cookies["SepetCookie"] != null)
            {
                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
                CheckOutVM checkOutVM=new CheckOutVM { Carts= carts,Order=new Order(),Cities=repoCity.GetAll()};
                return View(checkOutVM);
            }
            else return Redirect("/");
        }

        [Route("/sepet/ilcegetir")]
        public List<Distinct> getDistrict(int cityID)
        {
            return repoDistinct.GetAll(x=>x.CityID==cityID).ToList();
        }
    }
}
