using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.WebUI.Areas.admin.ViewModels;
using System.Linq;
using Project.WebUI.Tools;
using X.PagedList;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class CommentController : Controller
    {
        SqlRepo<Comment> repoComment;
        public CommentController(SqlRepo<Comment> _repoComment)
        {
            repoComment = _repoComment;
        }

        public IActionResult Index(int? page)
        {
            return View(repoComment.GetAll().ToPagedList(page ?? 1, 10));
        }
        public IActionResult Read(int id)
        {
            return View(repoComment.GetBy(x => x.ID == id));
        }
        public IActionResult Delete(int id)
        {
            repoComment.Remove(repoComment.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}

