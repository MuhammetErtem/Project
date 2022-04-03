using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class CategoryController : Controller
    {
        SqlRepo<Category> repoCategory;
        public CategoryController(SqlRepo<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }

        public IActionResult Index()
        {
            return View(repoCategory.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                if (repoCategory.GetBy(x => x.Name == model.Name) == null) repoCategory.Add(model);
                else TempData["hata"] = "Aynı kategori girilemez...";                    
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(repoCategory.GetBy(x=>x.ID==id));
        }

        [HttpPost]
        public IActionResult Update(Category model)
        {
            if (ModelState.IsValid) repoCategory.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoCategory.Remove(repoCategory.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
