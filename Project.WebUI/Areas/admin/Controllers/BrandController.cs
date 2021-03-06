using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using X.PagedList;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class BrandController : Controller
    {
        SqlRepo<Brand> repoBrand;
        public BrandController(SqlRepo<Brand> _repoBrand)
        {
            repoBrand = _repoBrand;
        }

        public IActionResult Index(int? page)
        {
            return View(repoBrand.GetAll().ToPagedList(page ?? 1, 10));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand model)
        {

            if (ModelState.IsValid)
            {
                if (repoBrand.GetBy(x => x.Name == model.Name) == null) repoBrand.Add(model);
                else TempData["hata"] = "Aynı marka girilemez...";

                {
                    if (Request.Form.Files.Any())
                    {
                        string brandPicture = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "brand");
                        if (!Directory.Exists(brandPicture)) Directory.CreateDirectory(brandPicture);
                        using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "brand", Request.Form.Files["Picture"].FileName), FileMode.Create))
                        {
                            Request.Form.Files["Picture"].CopyTo(stream);
                        }
                        model.Picture = "/img/brand/" + Request.Form.Files["Picture"].FileName;
                    }

                }

                repoBrand.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            return View(repoBrand.GetBy(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult Update(Brand model)
        {
            repoBrand.Update(model);
            if (repoBrand.GetBy(x => x.Name == model.Name) == null) repoBrand.Add(model);
            else if (Request.Form.Files.Any())
            {
                {
                    string brandPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "brand");
                    if (!Directory.Exists(brandPath)) Directory.CreateDirectory(brandPath);
                    using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "brand", Request.Form.Files["Picture"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["Picture"].CopyTo(stream);
                    }
                    model.Picture = "/img/brand/" + Request.Form.Files["Picture"].FileName;
                }
                repoBrand.Update(model);
            }
            else TempData["hata"] = "Aynı marka girilemez...";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoBrand.Remove(repoBrand.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
