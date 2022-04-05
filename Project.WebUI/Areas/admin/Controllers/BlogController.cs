using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class BlogController : Controller
    {
        SqlRepo<Blog> repoBlog;

        public BlogController(SqlRepo<Blog> _repoBlog)
        {
            repoBlog = _repoBlog;
        }

        public IActionResult Index()
        {
            return View(repoBlog.GetAll().ToList().OrderByDescending(o=>o.ID));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog model)
        {
            if (ModelState.IsValid)
            {

                repoBlog.Add(model);

            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(repoBlog.GetBy(x => x.ID == id));

        }

        [HttpPost]
        public IActionResult Update(Blog model)
        {
            if (ModelState.IsValid)
            {
                repoBlog.Update(model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoBlog.Remove(repoBlog.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
