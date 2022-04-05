using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SubCategoryController : Controller
    {
        SqlRepo<SubCategory> repoSubCategory;
        public SubCategoryController(SqlRepo<SubCategory> _repoSubCategory)
        {
            repoSubCategory = _repoSubCategory;
        }

        public IActionResult Index()
        {
            return View(repoSubCategory.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubCategory model)
        {
            if (ModelState.IsValid)
            {
                if (repoSubCategory.GetBy(x => x.Name == model.Name) == null) repoSubCategory.Add(model);
                else TempData["hata"] = "Aynı kategori girilemez...";                    
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(repoSubCategory.GetBy(x=>x.ID==id));
        }

        [HttpPost]
        public IActionResult Update(SubCategory model)
        {
            if (ModelState.IsValid) repoSubCategory.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoSubCategory.Remove(repoSubCategory.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
