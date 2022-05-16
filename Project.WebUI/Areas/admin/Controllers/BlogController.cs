using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using X.PagedList;

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

        public IActionResult Index(int? page)
        {
            return View(repoBlog.GetAll().ToPagedList(page ?? 1, 10));
        }

        public IActionResult Create()
        {
            return View(new Blog());
        }

        [HttpPost]
        public IActionResult Create(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    string blogPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "blog");
                    if (!Directory.Exists(blogPath)) Directory.CreateDirectory(blogPath);
                    using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "blog", Request.Form.Files["Picture"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["Picture"].CopyTo(stream);
                    }
                    model.Picture = "/img/blog/" + Request.Form.Files["Picture"].FileName;
                }

                repoBlog.Add(model);

                model.RecDate = DateTime.Now;

                return RedirectToAction("Index");

            }
            return View();
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
                if (Request.Form.Files.Any())
                {
                    string blogPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "blog");
                    if (!Directory.Exists(blogPath)) Directory.CreateDirectory(blogPath);
                    using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "blog", Request.Form.Files["Picture"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["Picture"].CopyTo(stream);
                    }
                    model.Picture = "/img/blog/" + Request.Form.Files["Picture"].FileName;
                }

                repoBlog.Update(model);

                model.RecDate = DateTime.Now;

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
