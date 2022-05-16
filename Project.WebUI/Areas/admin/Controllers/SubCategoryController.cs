using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project.WebUI.Areas.admin.ViewModels;
using X.PagedList;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SubCategoryController : Controller
    {
        SqlRepo<SubCategory> repoSubCategory;
        SqlRepo<Category> repoCategory;

        public SubCategoryController(SqlRepo<SubCategory> _repoSubCategory, SqlRepo<Category> _repoCategory)
        {
            repoSubCategory = _repoSubCategory;
            repoCategory = _repoCategory;
        }

        public IActionResult Index(int? page)
        {
            return View(repoSubCategory.GetAll().Include(p => p.Category).ToPagedList(page ?? 1, 10));
        }

        public IActionResult Create()
        {
            SubCategoryVM subCategoryVM = new SubCategoryVM
            {
                SubCategory = new SubCategory { Enabled = true },
                Categories = repoCategory.GetAll()
            };
            return View(subCategoryVM);
        }

        [HttpPost]
        public IActionResult Create(SubCategoryVM model)
        {
            if (ModelState.IsValid)
            {
                if (repoSubCategory.GetBy(x => x.Name == model.SubCategory.Name) == null) repoSubCategory.Add(model.SubCategory);
                else TempData["hata"] = "Aynı Alt Kategori Girilemez...";

                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Update(int id)
        {
            SubCategoryVM subCategoryVM = new SubCategoryVM
            {
                SubCategory = repoSubCategory.GetBy(x => x.ID == id),
                Categories = repoCategory.GetAll()
            };
            return View(subCategoryVM);
        }

        [HttpPost]
        public IActionResult Update(SubCategory model)
        {
            if (repoSubCategory.GetBy(x => x.Name == model.Name) == null) repoSubCategory.Update(model);
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
