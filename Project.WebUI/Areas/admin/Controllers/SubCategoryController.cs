﻿using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project.WebUI.Areas.admin.ViewModels;

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

        public IActionResult Index()
        {
            return View(repoSubCategory.GetAll().Include(p => p.Category).ToList().OrderByDescending(o => o.ID));
        }

        public IActionResult Create()
        {
            SubCategoryVM subCategoryVM = new SubCategoryVM
            {
                SubCategory = new SubCategory(),
                Categories = repoCategory.GetAll()
            };
            return View(subCategoryVM);
        }

        [HttpPost]
        public IActionResult Create(SubCategory model)
        {

            if (ModelState.IsValid)
            {
                if (repoSubCategory.GetBy(x => x.Name == model.Name) == null) repoSubCategory.Add(model);
                else TempData["hata"] = "Aynı Alt Kategori Girilemez...";                    
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            SubCategoryVM subCategoryVM = new SubCategoryVM
            {
                SubCategory = repoSubCategory.GetBy(x=> x.ID == id ),
                Categories = repoCategory.GetAll()
            };
            return View(subCategoryVM);
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